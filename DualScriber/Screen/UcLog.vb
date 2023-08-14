Imports System.IO
Imports Jhjo.Common
Imports Jhjo.Tool


Public Class UcLog
    Inherits UcScreen

#Region "CONST"
    Private Const LOG_FILE As String = ".\Log\{0:yyyy}\{0:MM}\{0:yyyy}-{0:MM}-{0:dd}.txt"
#End Region


#Region "EVENT"
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Me.LtbReview.Items.Clear()

            Dim StrFile As String = String.Format(LOG_FILE, Me.DtpDate.Value)
            If (File.Exists(StrFile) = True) Then
                Dim OReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(StrFile)

                While (OReader.Peek() >= 0)
                    Me.LtbReview.Items.Add(OReader.ReadLine())
                End While

                OReader.Close()
                OReader.Dispose()
                OReader = Nothing
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Overrides Sub Add()
        Try
            CLogTool.It.BeginSync()

            Me.LtbCurrent.Items.Clear()

            For Each _Item As CLog In CLogTool.It.LstOLog
                Me.LtbCurrent.Items.Add(_Item.GetLog())
            Next
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CLogTool.It.EndSync()
        End Try
    End Sub
#End Region

End Class
