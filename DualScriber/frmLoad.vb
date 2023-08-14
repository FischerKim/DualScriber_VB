Imports System.IO
Imports System.Text
Imports PylonC.NET
Imports Jhjo.Common
Imports Jhjo.Tool
Imports Daekhon.Common
Imports Daekhon.Acquisition.Basler


Public Class frmLoad

#Region "VARIABLE"
    Private m_OALeft As CCameraInfo = Nothing
    Private m_OARight As CCameraInfo = Nothing
    Private m_OBLeft As CCameraInfo = Nothing
    Private m_OBRight As CCameraInfo = Nothing
#End Region


#Region "EVENT"
#Region "FORM EVENT"
    Private Sub frmLoad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CImageSaveTool.USE_DELETE = True
            CImageSaveTool.DELETE_TIME_UNIT = ETIME_UNIT.DAY
            CImageSaveTool.IMAGE_MANAGE_DIR = New List(Of String)
            CImageSaveTool.IMAGE_MANAGE_DIR.Add(".\Image\1\Alignment\{0:yyyy}\{0:MM}\{0:dd}")
            CImageSaveTool.IMAGE_MANAGE_DIR.Add(".\Image\1\Edge\{0:yyyy}\{0:MM}\{0:dd}")
            CImageSaveTool.IMAGE_MANAGE_DIR.Add(".\Image\2\Alignment\{0:yyyy}\{0:MM}\{0:dd}")
            CImageSaveTool.IMAGE_MANAGE_DIR.Add(".\Image\2\Edge\{0:yyyy}\{0:MM}\{0:dd}")
            
            CLogSaveTool.USE_DELETE = True
            CLogSaveTool.DELETE_TIME_UNIT = ETIME_UNIT.DAY
            CLogSaveTool.LOG_MANAGE_PATH = New List(Of String)
            CLogSaveTool.LOG_MANAGE_PATH.Add(".\Log\{0:yyyy}\{0:MM}\{0:yyyy}-{0:MM}-{0:dd}.txt")
            
            If File.Exists(Environment.CurrentDirectory & "\System.ini") = False Then
                File.WriteAllText(Environment.CurrentDirectory & "\System.ini", My.Resources.System)
            End If

            Dim OALeft As StringBuilder = New StringBuilder()
            Dim OARight As StringBuilder = New StringBuilder()
            Dim OBLeft As StringBuilder = New StringBuilder()
            Dim OBRight As StringBuilder = New StringBuilder()
            GetPrivateProfileString("A-LEFT", "Serial", String.Empty, OALeft, 255, Environment.CurrentDirectory & "\System.ini")
            GetPrivateProfileString("A-RIGHT", "Serial", String.Empty, OARight, 255, Environment.CurrentDirectory & "\System.ini")
            GetPrivateProfileString("B-LEFT", "Serial", String.Empty, OBLeft, 255, Environment.CurrentDirectory & "\System.ini")
            GetPrivateProfileString("B-RIGHT", "Serial", String.Empty, OBRight, 255, Environment.CurrentDirectory & "\System.ini")


            Dim U32Count As UInteger = Pylon.EnumerateDevices()
            If Not U32Count = 0 Then
                For _Index As UInteger = 0 To U32Count - 1 Step 1
                    Dim OHandle As PYLON_DEVICE_INFO_HANDLE = Pylon.GetDeviceInfoHandle(_Index)
                    Dim StrSerial As String = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber")

                    If StrSerial = OALeft.ToString() Then
                        Me.m_OALeft = New CCameraInfo()
                        Me.m_OALeft.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName")
                        Me.m_OALeft.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName")
                        Me.m_OALeft.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber")
                        Me.m_OALeft.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress")
                        Me.m_OALeft.OKey = _Index
                    End If
                    If StrSerial = OARight.ToString() Then
                        Me.m_OARight = New CCameraInfo()
                        Me.m_OARight.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName")
                        Me.m_OARight.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName")
                        Me.m_OARight.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber")
                        Me.m_OARight.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress")
                        Me.m_OARight.OKey = _Index
                    End If
                    If StrSerial = OBLeft.ToString() Then
                        Me.m_OBLeft = New CCameraInfo()
                        Me.m_OBLeft.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName")
                        Me.m_OBLeft.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName")
                        Me.m_OBLeft.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber")
                        Me.m_OBLeft.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress")
                        Me.m_OBLeft.OKey = _Index
                    End If
                    If StrSerial = OBRight.ToString() Then
                        Me.m_OBRight = New CCameraInfo()
                        Me.m_OBRight.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName")
                        Me.m_OBRight.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName")
                        Me.m_OBRight.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber")
                        Me.m_OBRight.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress")
                        Me.m_OBRight.OKey = _Index
                    End If
                Next
            End If


            If Not Me.m_OALeft Is Nothing Then
                Me.LblALeft.Text = Me.m_OALeft.StrIP
            End If
            If Not Me.m_OARight Is Nothing Then
                Me.LblARight.Text = Me.m_OARight.StrIP
            End If
            If Not Me.m_OBLeft Is Nothing Then
                Me.LblBLeft.Text = Me.m_OBLeft.StrIP
            End If
            If Not Me.m_OBRight Is Nothing Then
                Me.LblBRight.Text = Me.m_OBRight.StrIP
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "BUTTON EVENT"
    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Try
            Dim OWindow As frmCameraSelector = New frmCameraSelector()
            OWindow.OALeft = Me.m_OALeft
            OWindow.OARight = Me.m_OARight
            OWindow.OBLeft = Me.m_OBLeft
            OWindow.OBRight = Me.m_OBRight

            If OWindow.ShowDialog = DialogResult.OK Then
                Me.m_OALeft = OWindow.OALeft
                Me.m_OARight = OWindow.OARight
                Me.m_OBLeft = OWindow.OBLeft
                Me.m_OBRight = OWindow.OBRight

                If Not Me.m_OALeft Is Nothing Then
                    Me.LblALeft.Text = Me.m_OALeft.StrIP
                Else
                    Me.LblALeft.Text = String.Empty
                End If
                If Not Me.m_OARight Is Nothing Then
                    Me.LblARight.Text = Me.m_OARight.StrIP
                Else
                    Me.LblARight.Text = String.Empty
                End If
                If Not Me.m_OBLeft Is Nothing Then
                    Me.LblBLeft.Text = Me.m_OBLeft.StrIP
                Else
                    Me.LblBLeft.Text = String.Empty
                End If
                If Not Me.m_OBRight Is Nothing Then
                    Me.LblBRight.Text = Me.m_OBRight.StrIP
                Else
                    Me.LblBRight.Text = String.Empty
                End If
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        Try
            If ((Me.m_OALeft Is Nothing) OrElse _
                (Me.m_OARight Is Nothing) OrElse _
                (Me.m_OBLeft Is Nothing) OrElse _
                (Me.m_OBRight Is Nothing)) Then
                CMsgBox.Warning("Please fill all four blanks by clicking 'select' button. If not appearing on a list, please check the physical connection or ip address of cameras.")
                Return
            End If

            WritePrivateProfileString("A-LEFT", "Company", Me.m_OALeft.StrVender, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("A-LEFT", "Product", Me.m_OALeft.StrModel, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("A-LEFT", "Serial", Me.m_OALeft.StrSerial, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("A-LEFT", "IP", Me.m_OALeft.StrIP, Environment.CurrentDirectory + "\System.ini")

            WritePrivateProfileString("A-RIGHT", "Company", Me.m_OARight.StrVender, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("A-RIGHT", "Product", Me.m_OARight.StrModel, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("A-RIGHT", "Serial", Me.m_OARight.StrSerial, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("A-RIGHT", "IP", Me.m_OARight.StrIP, Environment.CurrentDirectory + "\System.ini")

            WritePrivateProfileString("B-LEFT", "Company", Me.m_OBLeft.StrVender, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("B-LEFT", "Product", Me.m_OBLeft.StrModel, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("B-LEFT", "Serial", Me.m_OBLeft.StrSerial, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("B-LEFT", "IP", Me.m_OBLeft.StrIP, Environment.CurrentDirectory + "\System.ini")

            WritePrivateProfileString("B-RIGHT", "Company", Me.m_OBRight.StrVender, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("B-RIGHT", "Product", Me.m_OBRight.StrModel, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("B-RIGHT", "Serial", Me.m_OBRight.StrSerial, Environment.CurrentDirectory + "\System.ini")
            WritePrivateProfileString("B-RIGHT", "IP", Me.m_OBRight.StrIP, Environment.CurrentDirectory + "\System.ini")


            CDB.It.Load()
            CRecipeManager.It.Load()
            CMotionController.It.Open()

            CAcquisitionManager.It.OALeft = New CBasler(Me.m_OALeft)
            CAcquisitionManager.It.OARight = New CBasler(Me.m_OARight)
            CAcquisitionManager.It.OBLeft = New CBasler(Me.m_OBLeft)
            CAcquisitionManager.It.OBRight = New CBasler(Me.m_OBRight)

            CImageSaveTool.IMAGE_MANAGE_PERIOD = CEnvironment.It.DateToKeep_Days
            CImageSaveTool.It.Load()
            CLogSaveTool.LOG_MANAGE_PERIOD = CEnvironment.It.DateToKeep_Days
            CLogSaveTool.It.Load()

            MyBase.DialogResult = DialogResult.OK
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
#End Region
#End Region


#Region "DECLARE FUNCTION"
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal StrAppName As String, ByVal StrKeyName As String, ByVal StrDefault As String, ByVal OValue As StringBuilder, ByVal I32Size As Integer, ByVal StrFile As String) As Boolean
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal StrAppName As String, ByVal StrKeyName As String, ByVal StrValue As String, ByVal StrFile As String) As Boolean
#End Region

End Class