Imports System.Security.Cryptography

Public NotInheritable Class Simple3DES
    Implements IDisposable


#Region "VARIABLES"
    Private TripleDes As New TripleDESCryptoServiceProvider
#End Region

#Region "CONSTRUCTOR"
    Public Sub New(ByVal key As String)
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Me.Dispose()
            MyBase.Finalize()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "FUNCTION"
    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider

        Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Public Function EncryptData(ByVal plaintext As String) As String
        Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)
        Dim ms As New System.IO.MemoryStream
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData(ByVal encryptedtext As String) As String
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
        Dim ms As New System.IO.MemoryStream
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            If (Not Me.TripleDes Is Nothing) Then
                Me.TripleDes = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

    '#Region "IDisposable Support"
    '    Private disposedValue As Boolean ' 중복 호출을 검색하려면

    '    ' IDisposable
    '    Protected Sub Dispose(disposing As Boolean)
    '        If Not Me.disposedValue Then
    '            If disposing Then
    '                ' TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
    '            End If

    '            ' TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 Finalize()를 재정의합니다.
    '            ' TODO: 큰 필드를 null로 설정합니다.
    '        End If
    '        Me.disposedValue = True
    '    End Sub

    '    ' TODO: 위의 Dispose(ByVal disposing As Boolean)에 관리되지 않는 리소스를 해제하기 위한 코드가 있는 경우에만 Finalize()를 재정의합니다.
    '    'Protected Overrides Sub Finalize()
    '    '    ' 이 코드는 변경하지 마십시오. 위의 Dispose(ByVal disposing As Boolean)에 정리 코드를 입력하십시오.
    '    '    Dispose(False)
    '    '    MyBase.Finalize()
    '    'End Sub

    '    ' 삭제 가능한 패턴을 올바르게 구현하기 위해 Visual Basic에서 추가한 코드입니다.
    '    Public Sub Dispose() Implements IDisposable.Dispose
    '        ' 이 코드는 변경하지 마십시오. 위의 Dispose(ByVal disposing As Boolean)에 정리 코드를 입력하십시오.
    '        Dispose(True)
    '        GC.SuppressFinalize(Me)
    '    End Sub
    '#End Region

End Class
