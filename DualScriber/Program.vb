Imports PylonC.NET
Imports Cognex.VisionPro
Imports Jhjo.Common


Public Class Program
    Public Shared Sub Main()
        Try
            'Dim BExistCaliper As Boolean = CogMisc.IsLicensedFeatureEnabled("VxCaliper")
            'Dim BExistPMAlign As Boolean = CogMisc.IsLicensedFeatureEnabled("VxPatMax")
            'If BExistCaliper = False Or BExistPMAlign = False Then
            '    CMsgBox.Warning("Please connect Cognex License!")
            '    Return
            'End If

            Dim BExistBlob As Boolean = CogMisc.IsLicensedFeatureEnabled("VxBlob")
            If BExistBlob = False Then
                CMsgBox.Warning("Please connect Cognex License!")
                Return
            End If

            Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "1000") 'ms
            Pylon.Initialize()

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

            Dim OWindow As frmLoad = New frmLoad()
            If OWindow.ShowDialog() = DialogResult.OK Then
                Application.Run(New frmMain())
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
End Class
