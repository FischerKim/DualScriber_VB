Imports Jhjo.Common


Public Class frmMain

#Region "VARIABLE"
    Private m_OScreen As UcScreen = Nothing
    Private m_OAlignment As UcAlignment = Nothing
    Private m_OSetup As UcSetup = Nothing
    Private m_ORecipe As UcRecipe = Nothing
    Private m_OPCI As UcPCI = Nothing
    Private m_OReport As UcReport = Nothing
    Private m_OLog As UcLog = Nothing
    ' jht 가비지 정리 클래스
    Private m_objGarbageManager As CGarbageManager = Nothing
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()

        Try
            Me.ReadyCamera()
            Me.ReadyRecipe()
            Me.ReadyTool()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "EVENT"
#Region "FORM EVENT"
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CTool.It.ORecipeChanged = AddressOf Me.OTool_RecipeChanged
            CTool.It.OStageA.OOpenMessageBox = AddressOf Me.OAlignmentTool_OpenMessageBox
            CTool.It.OStageB.OOpenMessageBox = AddressOf Me.OAlignmentTool_OpenMessageBox

            CMotionController.It.OPLC.ORecipeChanged = AddressOf Me.OPLC_RecipeChanged


            Me.m_OAlignment = New UcAlignment()
            Me.m_OAlignment.Dock = DockStyle.Fill
            AddHandler Me.m_OAlignment.ScreenFixed, AddressOf Me.OScreen_ScreenFixed
            AddHandler Me.m_OAlignment.RequestFooterVisible, AddressOf Me.OAlignmentScreen_RequestFooterVisible
            ' jht 이벤트 연결
            AddHandler Me.m_OAlignment.ChangeStart, AddressOf Me.ChangeStart
            AddHandler Me.m_OAlignment.ChangeStop, AddressOf Me.ChangeStop

            Me.m_OSetup = New UcSetup()
            Me.m_OSetup.Dock = DockStyle.Fill
            AddHandler Me.m_OSetup.ScreenFixed, AddressOf Me.OScreen_ScreenFixed
            Me.m_ORecipe = New UcRecipe()
            Me.m_ORecipe.Dock = DockStyle.Fill
            AddHandler Me.m_ORecipe.ScreenFixed, AddressOf Me.OScreen_ScreenFixed
            Me.m_OPCI = New UcPCI()
            Me.m_OPCI.Dock = DockStyle.Fill
            AddHandler Me.m_OPCI.ScreenFixed, AddressOf Me.OScreen_ScreenFixed
            Me.m_OReport = New UcReport()
            Me.m_OReport.Dock = DockStyle.Fill
            AddHandler Me.m_OReport.ScreenFixed, AddressOf Me.OScreen_ScreenFixed
            Me.m_OLog = New UcLog()
            Me.m_OLog.Dock = DockStyle.Fill
            AddHandler Me.m_OLog.ScreenFixed, AddressOf Me.OScreen_ScreenFixed

            Me.m_OAlignment.Add()
            Me.PnlScreen.Controls.Add(Me.m_OAlignment)
            Me.m_OScreen = Me.m_OAlignment
            ' jht 가비지 정리 클래스
            Me.m_objGarbageManager = New CGarbageManager()
            ' jht OP Mode & Password
            Me.ChkUserMode.BackColor = Color.RoyalBlue
            Me.ChkUserMode.Text = "OP MODE"
            Me.BtnResetPassword.Visible = False
            Me.BtnResetPassword.Enabled = False
            Me.BtnResetPassword.BackColor = SystemColors.Control
            Me.BtnRecipe.Enabled = False
            Me.BtnRecipe.BackColor = SystemColors.Control

        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            ' jht 가비지 정리 클래스
            Me.m_objGarbageManager.Dispose()
            CMotionController.It.Dispose()
            '스텝 21 : CTool Dispose
            CTool.It.Dispose()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "BUTTON EVENT"
    Public Sub BtnMaximize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMaximize.Click
        Try
            If (Me.m_OAlignment.EScreenMode = ESCREEN_MODE.FULL_ALL) Then
                Me.m_OAlignment.ReplaceScreenMode(ESCREEN_MODE.ORIGINAL)
                Me.PnlFooter.Visible = True

                Me.BtnMaximize.BackColor = Color.SteelBlue
            Else
                Me.m_OAlignment.ReplaceScreenMode(ESCREEN_MODE.FULL_ALL)
                Me.PnlFooter.Visible = False

                Me.BtnMaximize.BackColor = Color.ForestGreen
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimize.Click
        Try
            MyBase.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAlignment.Click, BtnSetup.Click, BtnRecipe.Click, BtnPCI.Click, BtnReport.Click, BtnLog.Click
        Try
            Dim StrScreen As String = CType(CType(sender, Control).Tag, String)

            Select Case StrScreen
                Case "ALIGNMENT"
                    Me.SetScreen(Me.m_OAlignment)

                    Me.BtnMaximize.BackColor = Color.SteelBlue
                    Me.BtnMaximize.Enabled = True
                Case "SETUP"
                    Me.SetScreen(Me.m_OSetup)

                    Me.BtnMaximize.BackColor = SystemColors.Control
                    Me.BtnMaximize.Enabled = False
                Case "RECIPE"
                    Me.SetScreen(Me.m_ORecipe)

                    Me.BtnMaximize.BackColor = SystemColors.Control
                    Me.BtnMaximize.Enabled = False
                Case "PCI"
                    Me.SetScreen(Me.m_OPCI)

                    Me.BtnMaximize.BackColor = SystemColors.Control
                    Me.BtnMaximize.Enabled = False
                Case "REPORT"
                    Me.SetScreen(Me.m_OReport)

                    Me.BtnMaximize.BackColor = SystemColors.Control
                    Me.BtnMaximize.Enabled = False
                Case "LOG"
                    Me.SetScreen(Me.m_OLog)

                    Me.BtnMaximize.BackColor = SystemColors.Control
                    Me.BtnMaximize.Enabled = False
            End Select
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "ETC EVENT"
    ' jht 시작 시 UI 변경
    Private Sub ChangeStart()
        Try
            ' OP MODE로 변경 & 변경 막음
            Me.ChkUserMode.Checked = False
            Me.ChkUserMode.BackColor = Color.RoyalBlue
            Me.ChkUserMode.Text = "OP MODE"
            Me.ChkUserMode.Enabled = False
            Me.ChkUserMode.BackColor = SystemColors.Control
            ' 비밀번호 변경 버튼 숨김
            Me.BtnResetPassword.Visible = False
            Me.BtnResetPassword.Enabled = False
            Me.BtnResetPassword.BackColor = SystemColors.Control
            ' 레시피 버튼 막음
            Me.BtnRecipe.Enabled = False
            Me.BtnRecipe.BackColor = SystemColors.Control
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub

    ' jht 정지 시 UI 변경
    Private Sub ChangeStop()
        Try
            ' MODE 변경 풀음
            Me.ChkUserMode.Enabled = True
            Me.ChkUserMode.BackColor = Color.RoyalBlue
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub

    Private Sub Timer1000_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1000.Tick
        Try
            Me.LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

            If Not Me.m_OScreen Is Nothing Then
                Me.m_OScreen.Timer1000()
            End If
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub


    Private Sub OPLC_RecipeChanged(ByVal I32ID As Integer)
        Try
            If MyBase.InvokeRequired = True Then
                MyBase.BeginInvoke(New CPLC.RecipeRequestedHandler(AddressOf Me.OPLC_RecipeChanged), I32ID)
            Else
                If (CTool.It.OStageA.IsBusy() = False) AndAlso (CTool.It.OStageB.IsBusy() = False) Then
                    For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                        If (Not _Item.I32ID = I32ID) Then Continue For

                        CTool.It.ORecipe = New CRecipe(_Item)
                        CMotionController.It.OPLC.SetVisionRecipeID(I32ID)
                        Me.m_OAlignment.ROI_Change()
                        Exit For
                    Next
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OTool_RecipeChanged()
        Try
            If (Not CTool.It.ORecipe Is Nothing) Then
                Me.LblRecipe.Text = CTool.It.ORecipe.I32ID & "." & CTool.It.ORecipe.StrName
            End If

            Me.m_OScreen.ProcRecipeChanged()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OAlignmentTool_OpenMessageBox(ByVal StrMessage As String)
        Try
            If (MyBase.InvokeRequired = True) Then
                MyBase.BeginInvoke(New CAlignmentTool.OpenMessageBoxHandler(AddressOf Me.OAlignmentTool_OpenMessageBox), StrMessage)
            Else
                CMsgBox.Error(StrMessage)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OScreen_ScreenFixed(ByVal EScreen As ESCREEN, ByVal BIsFixed As Boolean)
        Try
            If BIsFixed = True Then
                If EScreen = DualScriber.ESCREEN.ALIGNMENT Then
                    Me.BtnSetup.BackColor = SystemColors.Control
                    Me.BtnRecipe.BackColor = SystemColors.Control
                    Me.BtnReport.BackColor = SystemColors.Control
                    Me.BtnLog.BackColor = SystemColors.Control
                    Me.BtnExit.BackColor = SystemColors.Control

                    Me.BtnSetup.Enabled = False
                    Me.BtnRecipe.Enabled = False
                    Me.BtnReport.Enabled = False
                    Me.BtnLog.Enabled = False
                    Me.BtnExit.Enabled = False
                Else
                    Me.BtnAlignment.BackColor = SystemColors.Control
                    Me.BtnSetup.BackColor = SystemColors.Control
                    Me.BtnRecipe.BackColor = SystemColors.Control
                    Me.BtnPCI.BackColor = SystemColors.Control
                    Me.BtnReport.BackColor = SystemColors.Control
                    Me.BtnLog.BackColor = SystemColors.Control
                    Me.BtnExit.BackColor = SystemColors.Control

                    Me.BtnAlignment.Enabled = False
                    Me.BtnSetup.Enabled = False
                    Me.BtnRecipe.Enabled = False
                    Me.BtnPCI.Enabled = False
                    Me.BtnReport.Enabled = False
                    Me.BtnLog.Enabled = False
                    Me.BtnExit.Enabled = False
                End If
            Else
                Me.BtnAlignment.BackColor = Color.SteelBlue
                Me.BtnSetup.BackColor = Color.SteelBlue
                Me.BtnRecipe.BackColor = Color.SteelBlue
                Me.BtnPCI.BackColor = Color.SteelBlue
                Me.BtnReport.BackColor = Color.SteelBlue
                Me.BtnLog.BackColor = Color.SteelBlue
                Me.BtnExit.BackColor = Color.SteelBlue

                Me.BtnAlignment.Enabled = True
                Me.BtnSetup.Enabled = True
                Me.BtnRecipe.Enabled = True
                Me.BtnPCI.Enabled = True
                Me.BtnReport.Enabled = True
                Me.BtnLog.Enabled = True
                Me.BtnExit.Enabled = True
                ' jht OP MODE 이면 레시피 막음
                If ChkUserMode.Text = "OP MODE" Then
                    Me.BtnRecipe.Enabled = False
                    Me.BtnRecipe.BackColor = SystemColors.Control
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
    Private Sub OAlignmentScreen_RequestFooterVisible(ByVal EScreenMode As ESCREEN_MODE)
        Try
            BtnMaximize.BackColor = Color.SteelBlue

            If (EScreenMode = ESCREEN_MODE.ORIGINAL) Then
                Me.PnlFooter.Visible = True
            ElseIf (EScreenMode = ESCREEN_MODE.FULL_ONE) Then
                Me.PnlFooter.Visible = False
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

#End Region
#End Region


#Region "FUNCTION"
    Private Sub ReadyCamera()
        Try
            CTool.It.OStageA.OLeft.ODisplayer.OView = CAcquisitionManager.It.OALeft
            CTool.It.OStageA.ORight.ODisplayer.OView = CAcquisitionManager.It.OARight
            CTool.It.OStageB.OLeft.ODisplayer.OView = CAcquisitionManager.It.OBLeft
            CTool.It.OStageB.ORight.ODisplayer.OView = CAcquisitionManager.It.OBRight
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub ReadyRecipe()
        Try
            Dim I32ID As Integer = CMotionController.It.OPLC.GetMotionRecipeID()

            For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                If (Not _Item.I32ID = I32ID) Then Continue For

                CTool.It.ORecipe = New CRecipe(_Item)
                Me.LblRecipe.Text = _Item.I32ID & "." & _Item.StrName
                CMotionController.It.OPLC.SetVisionRecipeID(I32ID)
                Exit For
            Next
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub ReadyTool()
        Try
            CTool.It.OStageA.F64SectionXY = CEnvironment.It.F64ASectionXY
            CTool.It.OStageA.I32PointXY = CEnvironment.It.I32APointXY
            CTool.It.OStageA.F64SectionT = CEnvironment.It.F64ASectionT
            CTool.It.OStageA.I32PointT = CEnvironment.It.I32APointT
            'CTool.It.OStageA.BLeftIsROIAll = (CEnvironment.It.StrALeftROIKind = "ALL")
            'CTool.It.OStageA.F64LeftROIX = CEnvironment.It.F64ALeftROIX
            'CTool.It.OStageA.F64LeftROIY = CEnvironment.It.F64ALeftROIY
            'CTool.It.OStageA.F64LeftROIWidth = CEnvironment.It.F64ALeftROIWidth
            'CTool.It.OStageA.F64LeftROIHeight = CEnvironment.It.F64ALeftROIHeight
            'CTool.It.OStageA.BRightIsROIAll = (CEnvironment.It.StrARightROIKind = "ALL")
            'CTool.It.OStageA.F64RightROIX = CEnvironment.It.F64ARightROIX
            'CTool.It.OStageA.F64RightROIY = CEnvironment.It.F64ARightROIY
            'CTool.It.OStageA.F64RightROIWidth = CEnvironment.It.F64ARightROIWidth
            'CTool.It.OStageA.F64RightROIHeight = CEnvironment.It.F64ARightROIHeight

            CTool.It.OStageB.F64SectionXY = CEnvironment.It.F64BSectionXY
            CTool.It.OStageB.I32PointXY = CEnvironment.It.I32BPointXY
            CTool.It.OStageB.F64SectionT = CEnvironment.It.F64BSectionT
            CTool.It.OStageB.I32PointT = CEnvironment.It.I32BPointT
            'CTool.It.OStageB.BLeftIsROIAll = (CEnvironment.It.StrBLeftROIKind = "ALL")
            'CTool.It.OStageB.F64LeftROIX = CEnvironment.It.F64BLeftROIX
            'CTool.It.OStageB.F64LeftROIY = CEnvironment.It.F64BLeftROIY
            'CTool.It.OStageB.F64LeftROIWidth = CEnvironment.It.F64BLeftROIWidth
            'CTool.It.OStageB.F64LeftROIHeight = CEnvironment.It.F64BLeftROIHeight
            'CTool.It.OStageB.BRightIsROIAll = (CEnvironment.It.StrBRightROIKind = "ALL")
            'CTool.It.OStageB.F64RightROIX = CEnvironment.It.F64BRightROIX
            'CTool.It.OStageB.F64RightROIY = CEnvironment.It.F64BRightROIY
            'CTool.It.OStageB.F64RightROIWidth = CEnvironment.It.F64BRightROIWidth
            'CTool.It.OStageB.F64RightROIHeight = CEnvironment.It.F64BRightROIHeight
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub SetScreen(ByVal OScreen As UcScreen)
        Try
            If Me.m_OScreen.GetType().Equals(OScreen.GetType()) = False Then
                Me.m_OScreen.Remove()
                OScreen.Add()

                Me.PnlScreen.Controls.Add(OScreen)
                OScreen.BringToFront()
                Me.PnlScreen.Controls.Remove(Me.m_OScreen)

                Me.m_OScreen = OScreen
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

    Private Sub ChkUserMode_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUserMode.CheckedChanged
        Try
            If (Me.ChkUserMode.Checked = True) Then
                Dim OWindow As New frmPassword()
                If (OWindow.ShowDialog() = DialogResult.OK) Then
                    Me.ChkUserMode.BackColor = Color.DarkRed
                    Me.ChkUserMode.Text = "PM MODE"
                    Me.BtnResetPassword.Visible = True
                    Me.BtnResetPassword.Enabled = True
                    Me.BtnResetPassword.BackColor = Color.BlueViolet
                    Me.BtnRecipe.Enabled = True
                    Me.BtnRecipe.BackColor = Color.SteelBlue
                End If
            Else
                Me.ChkUserMode.BackColor = Color.RoyalBlue
                Me.ChkUserMode.Text = "OP MODE"
                Me.BtnResetPassword.Visible = False
                Me.BtnResetPassword.Enabled = False
                Me.BtnResetPassword.BackColor = SystemColors.Control
                Me.BtnRecipe.Enabled = False
                Me.BtnRecipe.BackColor = SystemColors.Control
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub BtnResetPassword_Click(sender As Object, e As EventArgs) Handles BtnResetPassword.Click
        'Encoding
        Dim plainText As String = "User"
        Dim password As String = InputBox("Enter the password:")

        Dim wrapper As New Simple3DES(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        'MsgBox("The cipher text is: " & cipherText)
        My.Computer.FileSystem.WriteAllText(".\cipherText.txt", cipherText, False)
        wrapper.Dispose()
    End Sub
End Class