Imports System.IO
Imports System.Text
Imports PylonC.NET
Imports Jhjo.Common
Imports Jhjo.Tool
Imports Daekhon.Common

#Region "스텝 14"
Public Class frmPassword
#Region "VARIABLES"
#End Region

#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region


#Region "BUTTON EVENT"
    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        Try
            If (String.IsNullOrEmpty(Me.TxtBoxPassword.Text.Trim()) = True) Then
                CMsgBox.Warning("Please Input Password.")
            End If

            If (Me.TxtBoxPassword.Text = "1234") Then
                MyBase.DialogResult = DialogResult.OK
            ElseIf (Decoding(Me.TxtBoxPassword.Text)) Then
                MyBase.DialogResult = DialogResult.OK
            Else
                'CMsgBox.Warning("Please Input Correct Password.")
            End If

        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            MyBase.DialogResult = DialogResult.Cancel
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Function Decoding(ByVal StrUserInput As String) As Boolean
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(".\cipherText.txt")
        Dim wrapper As New Simple3DES(StrUserInput)
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            'MsgBox("The plain text is: " & plainText) //"default"
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox("Wrong Password")
            Return False
        Finally
            wrapper.Dispose()
        End Try
        Return True
    End Function

    Private Sub BtnReset_Click(sender As System.Object, e As System.EventArgs)
        'Encoding
        Dim plainText As String = "User"
        Dim password As String = InputBox("Enter the password:")

        Dim wrapper As New Simple3DES(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        'MsgBox("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText(".\cipherText.txt", cipherText, False)
        wrapper.Dispose()
    End Sub
#End Region
End Class

#End Region