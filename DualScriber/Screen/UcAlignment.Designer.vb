<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcAlignment
    Inherits DualScriber.UcScreen

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcAlignment))
        Me.PnlLeft = New Jhjo.Component.CPanel()
        Me.PnlBImage = New System.Windows.Forms.Panel()
        Me.PnlBRight = New Jhjo.Component.CPanel()
        Me.CdpBRight = New Cognex.VisionPro.Display.CogDisplay()
        Me.PnlBRightBar = New Jhjo.Component.CPanel()
        Me.PnlBRightStatusBar = New Jhjo.Component.CPanel()
        Me.CdsBRight = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlBRightToolBar = New Jhjo.Component.CPanel()
        Me.BtnBRightClearChecker = New System.Windows.Forms.Button()
        Me.BtnBRightShowChecker = New System.Windows.Forms.Button()
        Me.CdtBRight = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.LblTitleBRightImage = New Jhjo.Component.CLabel()
        Me.PnlBLeft = New Jhjo.Component.CPanel()
        Me.CdpBLeft = New Cognex.VisionPro.Display.CogDisplay()
        Me.PnlBLeftBar = New Jhjo.Component.CPanel()
        Me.PnlBLeftStatusBar = New Jhjo.Component.CPanel()
        Me.CdsBLeft = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlBLeftToolBar = New Jhjo.Component.CPanel()
        Me.BtnBLeftClearChecker = New System.Windows.Forms.Button()
        Me.BtnBLeftShowChecker = New System.Windows.Forms.Button()
        Me.CdtBLeft = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.LblTitleBLeftImage = New Jhjo.Component.CLabel()
        Me.PnlAImage = New System.Windows.Forms.Panel()
        Me.PnlARight = New Jhjo.Component.CPanel()
        Me.CdpARight = New Cognex.VisionPro.Display.CogDisplay()
        Me.PnlARightBar = New Jhjo.Component.CPanel()
        Me.PnlARightStatusBar = New Jhjo.Component.CPanel()
        Me.CdsARight = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlARightToolBar = New Jhjo.Component.CPanel()
        Me.BtnARightClearChecker = New System.Windows.Forms.Button()
        Me.BtnARightShowChecker = New System.Windows.Forms.Button()
        Me.CdtARight = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.LblTitleARightImage = New Jhjo.Component.CLabel()
        Me.PnlALeft = New Jhjo.Component.CPanel()
        Me.CdpALeft = New Cognex.VisionPro.Display.CogDisplay()
        Me.LblTitleALeftImage = New Jhjo.Component.CLabel()
        Me.PnlALeftBar = New Jhjo.Component.CPanel()
        Me.PnlALeftStatusBar = New Jhjo.Component.CPanel()
        Me.CdsALeft = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlALeftToolBar = New Jhjo.Component.CPanel()
        Me.BtnALeftClearChecker = New System.Windows.Forms.Button()
        Me.BtnALeftShowChecker = New System.Windows.Forms.Button()
        Me.CdtALeft = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.PnlRight = New Jhjo.Component.CPanel()
        Me.PnlMessage = New Jhjo.Component.CPanel()
        Me.LtbMessage = New System.Windows.Forms.ListBox()
        Me.LblTitleMessage = New Jhjo.Component.CLabel()
        Me.PnlEdge = New Jhjo.Component.CPanel()
        Me.LblScore = New Jhjo.Component.CLabel()
        Me.LblTitleAEdgeTop = New Jhjo.Component.CLabel()
        Me.LblAEdgeTopRight = New Jhjo.Component.CLabel()
        Me.LblAEdgeBottomRight = New Jhjo.Component.CLabel()
        Me.LblBRightScore = New Jhjo.Component.CLabel()
        Me.LblBLeftScore = New Jhjo.Component.CLabel()
        Me.LblARightScore = New Jhjo.Component.CLabel()
        Me.LblALeftScore = New Jhjo.Component.CLabel()
        Me.LblSummary = New Jhjo.Component.CLabel()
        Me.CLabel7 = New Jhjo.Component.CLabel()
        Me.CLabel4 = New Jhjo.Component.CLabel()
        Me.CLabel8 = New Jhjo.Component.CLabel()
        Me.LblBStageTotalTimeElapsed = New Jhjo.Component.CLabel()
        Me.LblMaxRetries = New Jhjo.Component.CLabel()
        Me.LblAStageTotalTimeElapsed = New Jhjo.Component.CLabel()
        Me.CLabel1 = New Jhjo.Component.CLabel()
        Me.LblBStageTotalRetry = New Jhjo.Component.CLabel()
        Me.LblAStageTotalRetry = New Jhjo.Component.CLabel()
        Me.LblTitleAEdgeBottom = New Jhjo.Component.CLabel()
        Me.LblTitleEdge = New Jhjo.Component.CLabel()
        Me.LblTitleBEdgeBottom = New Jhjo.Component.CLabel()
        Me.LblTitleBEdgeTop = New Jhjo.Component.CLabel()
        Me.LblBEdgeBottomRight = New Jhjo.Component.CLabel()
        Me.LblBEdgeTopRight = New Jhjo.Component.CLabel()
        Me.LblBEdgeBottomLeft = New Jhjo.Component.CLabel()
        Me.LblBEdgeTopLeft = New Jhjo.Component.CLabel()
        Me.LblTitleEdgeRight = New Jhjo.Component.CLabel()
        Me.LblTitleEdgeLeft = New Jhjo.Component.CLabel()
        Me.LblTitleEdgeBlank = New Jhjo.Component.CLabel()
        Me.LblAEdgeTopLeft = New Jhjo.Component.CLabel()
        Me.LblAEdgeBottomLeft = New Jhjo.Component.CLabel()
        Me.PnlAlignment = New Jhjo.Component.CPanel()
        Me.LblTitleBAlignmentLeftX = New Jhjo.Component.CLabel()
        Me.LblTitleAAlignmentLeftX = New Jhjo.Component.CLabel()
        Me.LblTitleAAlignmentRightX = New Jhjo.Component.CLabel()
        Me.LblBAlignmentLeftXCurrent = New Jhjo.Component.CLabel()
        Me.LblBAlignmentLeftXTarget = New Jhjo.Component.CLabel()
        Me.LblAAlignmentLeftXCurrent = New Jhjo.Component.CLabel()
        Me.LblAAlignmentLeftXTarget = New Jhjo.Component.CLabel()
        Me.LblTitleAAlignmentT = New Jhjo.Component.CLabel()
        Me.LblTitleBAlignmentT = New Jhjo.Component.CLabel()
        Me.LblTitleAAlignmentY = New Jhjo.Component.CLabel()
        Me.LblTitleBAlignmentY = New Jhjo.Component.CLabel()
        Me.LblTitleBAlignmentRightX = New Jhjo.Component.CLabel()
        Me.LblTitleAlignmentCurrent = New Jhjo.Component.CLabel()
        Me.LblBAlignmentTCurrent = New Jhjo.Component.CLabel()
        Me.LblAAlignmentTCurrent = New Jhjo.Component.CLabel()
        Me.LblBAlignmentTTarget = New Jhjo.Component.CLabel()
        Me.LblAAlignmentTTarget = New Jhjo.Component.CLabel()
        Me.LblBAlignmentYCurrent = New Jhjo.Component.CLabel()
        Me.LblAAlignmentYCurrent = New Jhjo.Component.CLabel()
        Me.LblBAlignmentYTarget = New Jhjo.Component.CLabel()
        Me.LblAAlignmentYTarget = New Jhjo.Component.CLabel()
        Me.LblBAlignmentRightXCurrent = New Jhjo.Component.CLabel()
        Me.LblAAlignmentRightXCurrent = New Jhjo.Component.CLabel()
        Me.LblBAlignmentRightXTarget = New Jhjo.Component.CLabel()
        Me.LblAAlignmentRightXTarget = New Jhjo.Component.CLabel()
        Me.LblTitleAlignmentTarget = New Jhjo.Component.CLabel()
        Me.LblTitleAlignmentBlank = New Jhjo.Component.CLabel()
        Me.LblTitleAlignment = New Jhjo.Component.CLabel()
        Me.PnlButtom = New Jhjo.Component.CPanel()
        Me.BtnMoveBStage = New System.Windows.Forms.Button()
        Me.BtnMoveAStage = New System.Windows.Forms.Button()
        Me.BtnBManualRun = New System.Windows.Forms.Button()
        Me.BtnAManualRun = New System.Windows.Forms.Button()
        Me.BtnBManualShow = New System.Windows.Forms.Button()
        Me.BtnAManualShow = New System.Windows.Forms.Button()
        Me.BtnWheel = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.PnlTitle = New Jhjo.Component.CPanel()
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.NudDistX = New System.Windows.Forms.NumericUpDown()
        Me.LblTitleID = New Jhjo.Component.CLabel()
        Me.NudDistY = New System.Windows.Forms.NumericUpDown()
        Me.CLabel2 = New Jhjo.Component.CLabel()
        Me.PnlLeft.SuspendLayout()
        Me.PnlBImage.SuspendLayout()
        Me.PnlBRight.SuspendLayout()
        CType(Me.CdpBRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBRightBar.SuspendLayout()
        Me.PnlBRightStatusBar.SuspendLayout()
        Me.PnlBRightToolBar.SuspendLayout()
        Me.PnlBLeft.SuspendLayout()
        CType(Me.CdpBLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBLeftBar.SuspendLayout()
        Me.PnlBLeftStatusBar.SuspendLayout()
        Me.PnlBLeftToolBar.SuspendLayout()
        Me.PnlAImage.SuspendLayout()
        Me.PnlARight.SuspendLayout()
        CType(Me.CdpARight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlARightBar.SuspendLayout()
        Me.PnlARightStatusBar.SuspendLayout()
        Me.PnlARightToolBar.SuspendLayout()
        Me.PnlALeft.SuspendLayout()
        CType(Me.CdpALeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlALeftBar.SuspendLayout()
        Me.PnlALeftStatusBar.SuspendLayout()
        Me.PnlALeftToolBar.SuspendLayout()
        Me.PnlRight.SuspendLayout()
        Me.PnlMessage.SuspendLayout()
        Me.PnlEdge.SuspendLayout()
        Me.PnlAlignment.SuspendLayout()
        Me.PnlButtom.SuspendLayout()
        Me.PnlTitle.SuspendLayout()
        CType(Me.NudDistX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudDistY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlLeft
        '
        Me.PnlLeft.BDrawBorderBottom = False
        Me.PnlLeft.BDrawBorderLeft = False
        Me.PnlLeft.BDrawBorderRight = False
        Me.PnlLeft.BDrawBorderTop = False
        Me.PnlLeft.Controls.Add(Me.PnlBImage)
        Me.PnlLeft.Controls.Add(Me.PnlAImage)
        Me.PnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlLeft.Location = New System.Drawing.Point(0, 46)
        Me.PnlLeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlLeft.Name = "PnlLeft"
        Me.PnlLeft.Size = New System.Drawing.Size(1227, 968)
        Me.PnlLeft.TabIndex = 5
        '
        'PnlBImage
        '
        Me.PnlBImage.Controls.Add(Me.PnlBRight)
        Me.PnlBImage.Controls.Add(Me.PnlBLeft)
        Me.PnlBImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBImage.Location = New System.Drawing.Point(0, 485)
        Me.PnlBImage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBImage.Name = "PnlBImage"
        Me.PnlBImage.Size = New System.Drawing.Size(1227, 483)
        Me.PnlBImage.TabIndex = 1
        '
        'PnlBRight
        '
        Me.PnlBRight.BDrawBorderBottom = False
        Me.PnlBRight.BDrawBorderLeft = False
        Me.PnlBRight.BDrawBorderRight = False
        Me.PnlBRight.BDrawBorderTop = False
        Me.PnlBRight.Controls.Add(Me.CdpBRight)
        Me.PnlBRight.Controls.Add(Me.PnlBRightBar)
        Me.PnlBRight.Controls.Add(Me.LblTitleBRightImage)
        Me.PnlBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBRight.Location = New System.Drawing.Point(613, 0)
        Me.PnlBRight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBRight.Name = "PnlBRight"
        Me.PnlBRight.Size = New System.Drawing.Size(614, 483)
        Me.PnlBRight.TabIndex = 7
        '
        'CdpBRight
        '
        Me.CdpBRight.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpBRight.ColorMapLowerRoiLimit = 0R
        Me.CdpBRight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpBRight.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpBRight.ColorMapUpperRoiLimit = 1.0R
        Me.CdpBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpBRight.DoubleTapZoomCycleLength = 2
        Me.CdpBRight.DoubleTapZoomSensitivity = 2.5R
        Me.CdpBRight.Location = New System.Drawing.Point(0, 46)
        Me.CdpBRight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdpBRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpBRight.MouseWheelSensitivity = 1.0R
        Me.CdpBRight.Name = "CdpBRight"
        Me.CdpBRight.OcxState = CType(resources.GetObject("CdpBRight.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpBRight.Size = New System.Drawing.Size(614, 407)
        Me.CdpBRight.TabIndex = 8
        Me.CdpBRight.Tag = "B RIGHT"
        '
        'PnlBRightBar
        '
        Me.PnlBRightBar.BDrawBorderBottom = False
        Me.PnlBRightBar.BDrawBorderLeft = False
        Me.PnlBRightBar.BDrawBorderRight = False
        Me.PnlBRightBar.BDrawBorderTop = False
        Me.PnlBRightBar.Controls.Add(Me.PnlBRightStatusBar)
        Me.PnlBRightBar.Controls.Add(Me.PnlBRightToolBar)
        Me.PnlBRightBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlBRightBar.Location = New System.Drawing.Point(0, 453)
        Me.PnlBRightBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBRightBar.Name = "PnlBRightBar"
        Me.PnlBRightBar.Size = New System.Drawing.Size(614, 30)
        Me.PnlBRightBar.TabIndex = 7
        '
        'PnlBRightStatusBar
        '
        Me.PnlBRightStatusBar.BDrawBorderBottom = False
        Me.PnlBRightStatusBar.BDrawBorderLeft = False
        Me.PnlBRightStatusBar.BDrawBorderRight = False
        Me.PnlBRightStatusBar.BDrawBorderTop = False
        Me.PnlBRightStatusBar.Controls.Add(Me.CdsBRight)
        Me.PnlBRightStatusBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBRightStatusBar.Location = New System.Drawing.Point(324, 0)
        Me.PnlBRightStatusBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBRightStatusBar.Name = "PnlBRightStatusBar"
        Me.PnlBRightStatusBar.Size = New System.Drawing.Size(290, 30)
        Me.PnlBRightStatusBar.TabIndex = 5
        '
        'CdsBRight
        '
        Me.CdsBRight.CoordinateSpaceName = "*\#"
        Me.CdsBRight.CoordinateSpaceName3D = "*\#"
        Me.CdsBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsBRight.Location = New System.Drawing.Point(0, 0)
        Me.CdsBRight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdsBRight.Name = "CdsBRight"
        Me.CdsBRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsBRight.ShowPixelValuePane = False
        Me.CdsBRight.ShowZoomPane = False
        Me.CdsBRight.Size = New System.Drawing.Size(290, 30)
        Me.CdsBRight.TabIndex = 0
        Me.CdsBRight.Use3DCoordinateSpaceTree = False
        '
        'PnlBRightToolBar
        '
        Me.PnlBRightToolBar.BDrawBorderBottom = False
        Me.PnlBRightToolBar.BDrawBorderLeft = False
        Me.PnlBRightToolBar.BDrawBorderRight = False
        Me.PnlBRightToolBar.BDrawBorderTop = False
        Me.PnlBRightToolBar.Controls.Add(Me.BtnBRightClearChecker)
        Me.PnlBRightToolBar.Controls.Add(Me.BtnBRightShowChecker)
        Me.PnlBRightToolBar.Controls.Add(Me.CdtBRight)
        Me.PnlBRightToolBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBRightToolBar.Location = New System.Drawing.Point(0, 0)
        Me.PnlBRightToolBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBRightToolBar.Name = "PnlBRightToolBar"
        Me.PnlBRightToolBar.Size = New System.Drawing.Size(324, 30)
        Me.PnlBRightToolBar.TabIndex = 6
        '
        'BtnBRightClearChecker
        '
        Me.BtnBRightClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBRightClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBRightClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnBRightClearChecker.Location = New System.Drawing.Point(292, 3)
        Me.BtnBRightClearChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBRightClearChecker.Name = "BtnBRightClearChecker"
        Me.BtnBRightClearChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnBRightClearChecker.TabIndex = 61
        Me.BtnBRightClearChecker.Tag = "3"
        Me.BtnBRightClearChecker.UseVisualStyleBackColor = False
        '
        'BtnBRightShowChecker
        '
        Me.BtnBRightShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBRightShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBRightShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBRightShowChecker.Image = CType(resources.GetObject("BtnBRightShowChecker.Image"), System.Drawing.Image)
        Me.BtnBRightShowChecker.Location = New System.Drawing.Point(263, 3)
        Me.BtnBRightShowChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBRightShowChecker.Name = "BtnBRightShowChecker"
        Me.BtnBRightShowChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnBRightShowChecker.TabIndex = 60
        Me.BtnBRightShowChecker.Tag = "3"
        Me.BtnBRightShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBRightShowChecker.UseVisualStyleBackColor = False
        '
        'CdtBRight
        '
        Me.CdtBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtBRight.Location = New System.Drawing.Point(0, 0)
        Me.CdtBRight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdtBRight.Name = "CdtBRight"
        Me.CdtBRight.Size = New System.Drawing.Size(324, 30)
        Me.CdtBRight.TabIndex = 0
        '
        'LblTitleBRightImage
        '
        Me.LblTitleBRightImage.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBRightImage.BDrawBorderBottom = True
        Me.LblTitleBRightImage.BDrawBorderLeft = True
        Me.LblTitleBRightImage.BDrawBorderRight = False
        Me.LblTitleBRightImage.BDrawBorderTop = False
        Me.LblTitleBRightImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBRightImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBRightImage.ForeColor = System.Drawing.Color.White
        Me.LblTitleBRightImage.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBRightImage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBRightImage.Name = "LblTitleBRightImage"
        Me.LblTitleBRightImage.OColor = System.Drawing.Color.Black
        Me.LblTitleBRightImage.Size = New System.Drawing.Size(614, 46)
        Me.LblTitleBRightImage.TabIndex = 2
        Me.LblTitleBRightImage.Text = "#2 Right"
        Me.LblTitleBRightImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlBLeft
        '
        Me.PnlBLeft.BDrawBorderBottom = False
        Me.PnlBLeft.BDrawBorderLeft = False
        Me.PnlBLeft.BDrawBorderRight = False
        Me.PnlBLeft.BDrawBorderTop = False
        Me.PnlBLeft.Controls.Add(Me.CdpBLeft)
        Me.PnlBLeft.Controls.Add(Me.PnlBLeftBar)
        Me.PnlBLeft.Controls.Add(Me.LblTitleBLeftImage)
        Me.PnlBLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlBLeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBLeft.Name = "PnlBLeft"
        Me.PnlBLeft.Size = New System.Drawing.Size(613, 483)
        Me.PnlBLeft.TabIndex = 6
        '
        'CdpBLeft
        '
        Me.CdpBLeft.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpBLeft.ColorMapLowerRoiLimit = 0R
        Me.CdpBLeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpBLeft.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpBLeft.ColorMapUpperRoiLimit = 1.0R
        Me.CdpBLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpBLeft.DoubleTapZoomCycleLength = 2
        Me.CdpBLeft.DoubleTapZoomSensitivity = 2.5R
        Me.CdpBLeft.Location = New System.Drawing.Point(0, 46)
        Me.CdpBLeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdpBLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpBLeft.MouseWheelSensitivity = 1.0R
        Me.CdpBLeft.Name = "CdpBLeft"
        Me.CdpBLeft.OcxState = CType(resources.GetObject("CdpBLeft.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpBLeft.Size = New System.Drawing.Size(613, 407)
        Me.CdpBLeft.TabIndex = 8
        Me.CdpBLeft.Tag = "B LEFT"
        '
        'PnlBLeftBar
        '
        Me.PnlBLeftBar.BDrawBorderBottom = False
        Me.PnlBLeftBar.BDrawBorderLeft = False
        Me.PnlBLeftBar.BDrawBorderRight = False
        Me.PnlBLeftBar.BDrawBorderTop = False
        Me.PnlBLeftBar.Controls.Add(Me.PnlBLeftStatusBar)
        Me.PnlBLeftBar.Controls.Add(Me.PnlBLeftToolBar)
        Me.PnlBLeftBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlBLeftBar.Location = New System.Drawing.Point(0, 453)
        Me.PnlBLeftBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBLeftBar.Name = "PnlBLeftBar"
        Me.PnlBLeftBar.Size = New System.Drawing.Size(613, 30)
        Me.PnlBLeftBar.TabIndex = 7
        '
        'PnlBLeftStatusBar
        '
        Me.PnlBLeftStatusBar.BDrawBorderBottom = False
        Me.PnlBLeftStatusBar.BDrawBorderLeft = False
        Me.PnlBLeftStatusBar.BDrawBorderRight = False
        Me.PnlBLeftStatusBar.BDrawBorderTop = False
        Me.PnlBLeftStatusBar.Controls.Add(Me.CdsBLeft)
        Me.PnlBLeftStatusBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBLeftStatusBar.Location = New System.Drawing.Point(324, 0)
        Me.PnlBLeftStatusBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBLeftStatusBar.Name = "PnlBLeftStatusBar"
        Me.PnlBLeftStatusBar.Size = New System.Drawing.Size(289, 30)
        Me.PnlBLeftStatusBar.TabIndex = 5
        '
        'CdsBLeft
        '
        Me.CdsBLeft.CoordinateSpaceName = "*\#"
        Me.CdsBLeft.CoordinateSpaceName3D = "*\#"
        Me.CdsBLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsBLeft.Location = New System.Drawing.Point(0, 0)
        Me.CdsBLeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdsBLeft.Name = "CdsBLeft"
        Me.CdsBLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsBLeft.ShowPixelValuePane = False
        Me.CdsBLeft.ShowZoomPane = False
        Me.CdsBLeft.Size = New System.Drawing.Size(289, 30)
        Me.CdsBLeft.TabIndex = 0
        Me.CdsBLeft.Use3DCoordinateSpaceTree = False
        '
        'PnlBLeftToolBar
        '
        Me.PnlBLeftToolBar.BDrawBorderBottom = False
        Me.PnlBLeftToolBar.BDrawBorderLeft = False
        Me.PnlBLeftToolBar.BDrawBorderRight = False
        Me.PnlBLeftToolBar.BDrawBorderTop = False
        Me.PnlBLeftToolBar.Controls.Add(Me.BtnBLeftClearChecker)
        Me.PnlBLeftToolBar.Controls.Add(Me.BtnBLeftShowChecker)
        Me.PnlBLeftToolBar.Controls.Add(Me.CdtBLeft)
        Me.PnlBLeftToolBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBLeftToolBar.Location = New System.Drawing.Point(0, 0)
        Me.PnlBLeftToolBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlBLeftToolBar.Name = "PnlBLeftToolBar"
        Me.PnlBLeftToolBar.Size = New System.Drawing.Size(324, 30)
        Me.PnlBLeftToolBar.TabIndex = 6
        '
        'BtnBLeftClearChecker
        '
        Me.BtnBLeftClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBLeftClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBLeftClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnBLeftClearChecker.Location = New System.Drawing.Point(292, 3)
        Me.BtnBLeftClearChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBLeftClearChecker.Name = "BtnBLeftClearChecker"
        Me.BtnBLeftClearChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnBLeftClearChecker.TabIndex = 61
        Me.BtnBLeftClearChecker.Tag = "2"
        Me.BtnBLeftClearChecker.UseVisualStyleBackColor = False
        '
        'BtnBLeftShowChecker
        '
        Me.BtnBLeftShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBLeftShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBLeftShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBLeftShowChecker.Image = CType(resources.GetObject("BtnBLeftShowChecker.Image"), System.Drawing.Image)
        Me.BtnBLeftShowChecker.Location = New System.Drawing.Point(263, 3)
        Me.BtnBLeftShowChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBLeftShowChecker.Name = "BtnBLeftShowChecker"
        Me.BtnBLeftShowChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnBLeftShowChecker.TabIndex = 60
        Me.BtnBLeftShowChecker.Tag = "2"
        Me.BtnBLeftShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBLeftShowChecker.UseVisualStyleBackColor = False
        '
        'CdtBLeft
        '
        Me.CdtBLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtBLeft.Location = New System.Drawing.Point(0, 0)
        Me.CdtBLeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdtBLeft.Name = "CdtBLeft"
        Me.CdtBLeft.Size = New System.Drawing.Size(324, 30)
        Me.CdtBLeft.TabIndex = 0
        '
        'LblTitleBLeftImage
        '
        Me.LblTitleBLeftImage.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBLeftImage.BDrawBorderBottom = True
        Me.LblTitleBLeftImage.BDrawBorderLeft = False
        Me.LblTitleBLeftImage.BDrawBorderRight = False
        Me.LblTitleBLeftImage.BDrawBorderTop = False
        Me.LblTitleBLeftImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBLeftImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBLeftImage.ForeColor = System.Drawing.Color.White
        Me.LblTitleBLeftImage.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBLeftImage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBLeftImage.Name = "LblTitleBLeftImage"
        Me.LblTitleBLeftImage.OColor = System.Drawing.Color.Black
        Me.LblTitleBLeftImage.Size = New System.Drawing.Size(613, 46)
        Me.LblTitleBLeftImage.TabIndex = 2
        Me.LblTitleBLeftImage.Text = "#2 Left"
        Me.LblTitleBLeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlAImage
        '
        Me.PnlAImage.Controls.Add(Me.PnlARight)
        Me.PnlAImage.Controls.Add(Me.PnlALeft)
        Me.PnlAImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlAImage.Location = New System.Drawing.Point(0, 0)
        Me.PnlAImage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlAImage.Name = "PnlAImage"
        Me.PnlAImage.Size = New System.Drawing.Size(1227, 485)
        Me.PnlAImage.TabIndex = 0
        '
        'PnlARight
        '
        Me.PnlARight.BDrawBorderBottom = False
        Me.PnlARight.BDrawBorderLeft = False
        Me.PnlARight.BDrawBorderRight = False
        Me.PnlARight.BDrawBorderTop = False
        Me.PnlARight.Controls.Add(Me.CdpARight)
        Me.PnlARight.Controls.Add(Me.PnlARightBar)
        Me.PnlARight.Controls.Add(Me.LblTitleARightImage)
        Me.PnlARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlARight.Location = New System.Drawing.Point(613, 0)
        Me.PnlARight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlARight.Name = "PnlARight"
        Me.PnlARight.Size = New System.Drawing.Size(614, 485)
        Me.PnlARight.TabIndex = 5
        '
        'CdpARight
        '
        Me.CdpARight.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpARight.ColorMapLowerRoiLimit = 0R
        Me.CdpARight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpARight.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpARight.ColorMapUpperRoiLimit = 1.0R
        Me.CdpARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpARight.DoubleTapZoomCycleLength = 2
        Me.CdpARight.DoubleTapZoomSensitivity = 2.5R
        Me.CdpARight.Location = New System.Drawing.Point(0, 46)
        Me.CdpARight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdpARight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpARight.MouseWheelSensitivity = 1.0R
        Me.CdpARight.Name = "CdpARight"
        Me.CdpARight.OcxState = CType(resources.GetObject("CdpARight.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpARight.Size = New System.Drawing.Size(614, 409)
        Me.CdpARight.TabIndex = 7
        Me.CdpARight.Tag = "A RIGHT"
        '
        'PnlARightBar
        '
        Me.PnlARightBar.BDrawBorderBottom = False
        Me.PnlARightBar.BDrawBorderLeft = False
        Me.PnlARightBar.BDrawBorderRight = False
        Me.PnlARightBar.BDrawBorderTop = False
        Me.PnlARightBar.Controls.Add(Me.PnlARightStatusBar)
        Me.PnlARightBar.Controls.Add(Me.PnlARightToolBar)
        Me.PnlARightBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlARightBar.Location = New System.Drawing.Point(0, 455)
        Me.PnlARightBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlARightBar.Name = "PnlARightBar"
        Me.PnlARightBar.Size = New System.Drawing.Size(614, 30)
        Me.PnlARightBar.TabIndex = 6
        '
        'PnlARightStatusBar
        '
        Me.PnlARightStatusBar.BDrawBorderBottom = False
        Me.PnlARightStatusBar.BDrawBorderLeft = False
        Me.PnlARightStatusBar.BDrawBorderRight = False
        Me.PnlARightStatusBar.BDrawBorderTop = False
        Me.PnlARightStatusBar.Controls.Add(Me.CdsARight)
        Me.PnlARightStatusBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlARightStatusBar.Location = New System.Drawing.Point(324, 0)
        Me.PnlARightStatusBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlARightStatusBar.Name = "PnlARightStatusBar"
        Me.PnlARightStatusBar.Size = New System.Drawing.Size(290, 30)
        Me.PnlARightStatusBar.TabIndex = 5
        '
        'CdsARight
        '
        Me.CdsARight.CoordinateSpaceName = "*\#"
        Me.CdsARight.CoordinateSpaceName3D = "*\#"
        Me.CdsARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsARight.Location = New System.Drawing.Point(0, 0)
        Me.CdsARight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdsARight.Name = "CdsARight"
        Me.CdsARight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsARight.ShowPixelValuePane = False
        Me.CdsARight.ShowZoomPane = False
        Me.CdsARight.Size = New System.Drawing.Size(290, 30)
        Me.CdsARight.TabIndex = 0
        Me.CdsARight.Use3DCoordinateSpaceTree = False
        '
        'PnlARightToolBar
        '
        Me.PnlARightToolBar.BDrawBorderBottom = False
        Me.PnlARightToolBar.BDrawBorderLeft = False
        Me.PnlARightToolBar.BDrawBorderRight = False
        Me.PnlARightToolBar.BDrawBorderTop = False
        Me.PnlARightToolBar.Controls.Add(Me.BtnARightClearChecker)
        Me.PnlARightToolBar.Controls.Add(Me.BtnARightShowChecker)
        Me.PnlARightToolBar.Controls.Add(Me.CdtARight)
        Me.PnlARightToolBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlARightToolBar.Location = New System.Drawing.Point(0, 0)
        Me.PnlARightToolBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlARightToolBar.Name = "PnlARightToolBar"
        Me.PnlARightToolBar.Size = New System.Drawing.Size(324, 30)
        Me.PnlARightToolBar.TabIndex = 6
        '
        'BtnARightClearChecker
        '
        Me.BtnARightClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnARightClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnARightClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnARightClearChecker.Location = New System.Drawing.Point(292, 3)
        Me.BtnARightClearChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnARightClearChecker.Name = "BtnARightClearChecker"
        Me.BtnARightClearChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnARightClearChecker.TabIndex = 61
        Me.BtnARightClearChecker.Tag = "1"
        Me.BtnARightClearChecker.UseVisualStyleBackColor = False
        '
        'BtnARightShowChecker
        '
        Me.BtnARightShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnARightShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnARightShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnARightShowChecker.Image = CType(resources.GetObject("BtnARightShowChecker.Image"), System.Drawing.Image)
        Me.BtnARightShowChecker.Location = New System.Drawing.Point(263, 3)
        Me.BtnARightShowChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnARightShowChecker.Name = "BtnARightShowChecker"
        Me.BtnARightShowChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnARightShowChecker.TabIndex = 60
        Me.BtnARightShowChecker.Tag = "1"
        Me.BtnARightShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnARightShowChecker.UseVisualStyleBackColor = False
        '
        'CdtARight
        '
        Me.CdtARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtARight.Location = New System.Drawing.Point(0, 0)
        Me.CdtARight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdtARight.Name = "CdtARight"
        Me.CdtARight.Size = New System.Drawing.Size(324, 30)
        Me.CdtARight.TabIndex = 0
        '
        'LblTitleARightImage
        '
        Me.LblTitleARightImage.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleARightImage.BDrawBorderBottom = True
        Me.LblTitleARightImage.BDrawBorderLeft = True
        Me.LblTitleARightImage.BDrawBorderRight = False
        Me.LblTitleARightImage.BDrawBorderTop = False
        Me.LblTitleARightImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleARightImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleARightImage.ForeColor = System.Drawing.Color.White
        Me.LblTitleARightImage.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleARightImage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleARightImage.Name = "LblTitleARightImage"
        Me.LblTitleARightImage.OColor = System.Drawing.Color.Black
        Me.LblTitleARightImage.Size = New System.Drawing.Size(614, 46)
        Me.LblTitleARightImage.TabIndex = 2
        Me.LblTitleARightImage.Text = "#1 Right"
        Me.LblTitleARightImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlALeft
        '
        Me.PnlALeft.BDrawBorderBottom = False
        Me.PnlALeft.BDrawBorderLeft = False
        Me.PnlALeft.BDrawBorderRight = False
        Me.PnlALeft.BDrawBorderTop = False
        Me.PnlALeft.Controls.Add(Me.CdpALeft)
        Me.PnlALeft.Controls.Add(Me.LblTitleALeftImage)
        Me.PnlALeft.Controls.Add(Me.PnlALeftBar)
        Me.PnlALeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlALeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlALeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlALeft.Name = "PnlALeft"
        Me.PnlALeft.Size = New System.Drawing.Size(613, 485)
        Me.PnlALeft.TabIndex = 6
        '
        'CdpALeft
        '
        Me.CdpALeft.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpALeft.ColorMapLowerRoiLimit = 0R
        Me.CdpALeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpALeft.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpALeft.ColorMapUpperRoiLimit = 1.0R
        Me.CdpALeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpALeft.DoubleTapZoomCycleLength = 2
        Me.CdpALeft.DoubleTapZoomSensitivity = 2.5R
        Me.CdpALeft.Location = New System.Drawing.Point(0, 46)
        Me.CdpALeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdpALeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpALeft.MouseWheelSensitivity = 1.0R
        Me.CdpALeft.Name = "CdpALeft"
        Me.CdpALeft.OcxState = CType(resources.GetObject("CdpALeft.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpALeft.Size = New System.Drawing.Size(613, 409)
        Me.CdpALeft.TabIndex = 6
        Me.CdpALeft.Tag = "A LEFT"
        '
        'LblTitleALeftImage
        '
        Me.LblTitleALeftImage.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleALeftImage.BDrawBorderBottom = True
        Me.LblTitleALeftImage.BDrawBorderLeft = False
        Me.LblTitleALeftImage.BDrawBorderRight = False
        Me.LblTitleALeftImage.BDrawBorderTop = False
        Me.LblTitleALeftImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleALeftImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleALeftImage.ForeColor = System.Drawing.Color.White
        Me.LblTitleALeftImage.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleALeftImage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleALeftImage.Name = "LblTitleALeftImage"
        Me.LblTitleALeftImage.OColor = System.Drawing.Color.Black
        Me.LblTitleALeftImage.Size = New System.Drawing.Size(613, 46)
        Me.LblTitleALeftImage.TabIndex = 1
        Me.LblTitleALeftImage.Text = "#1 Left"
        Me.LblTitleALeftImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlALeftBar
        '
        Me.PnlALeftBar.BDrawBorderBottom = False
        Me.PnlALeftBar.BDrawBorderLeft = False
        Me.PnlALeftBar.BDrawBorderRight = False
        Me.PnlALeftBar.BDrawBorderTop = False
        Me.PnlALeftBar.Controls.Add(Me.PnlALeftStatusBar)
        Me.PnlALeftBar.Controls.Add(Me.PnlALeftToolBar)
        Me.PnlALeftBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlALeftBar.Location = New System.Drawing.Point(0, 455)
        Me.PnlALeftBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlALeftBar.Name = "PnlALeftBar"
        Me.PnlALeftBar.Size = New System.Drawing.Size(613, 30)
        Me.PnlALeftBar.TabIndex = 5
        '
        'PnlALeftStatusBar
        '
        Me.PnlALeftStatusBar.BDrawBorderBottom = False
        Me.PnlALeftStatusBar.BDrawBorderLeft = False
        Me.PnlALeftStatusBar.BDrawBorderRight = False
        Me.PnlALeftStatusBar.BDrawBorderTop = False
        Me.PnlALeftStatusBar.Controls.Add(Me.CdsALeft)
        Me.PnlALeftStatusBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlALeftStatusBar.Location = New System.Drawing.Point(324, 0)
        Me.PnlALeftStatusBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlALeftStatusBar.Name = "PnlALeftStatusBar"
        Me.PnlALeftStatusBar.Size = New System.Drawing.Size(289, 30)
        Me.PnlALeftStatusBar.TabIndex = 5
        '
        'CdsALeft
        '
        Me.CdsALeft.CoordinateSpaceName = "*\#"
        Me.CdsALeft.CoordinateSpaceName3D = "*\#"
        Me.CdsALeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsALeft.Location = New System.Drawing.Point(0, 0)
        Me.CdsALeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdsALeft.Name = "CdsALeft"
        Me.CdsALeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsALeft.ShowPixelValuePane = False
        Me.CdsALeft.ShowZoomPane = False
        Me.CdsALeft.Size = New System.Drawing.Size(289, 30)
        Me.CdsALeft.TabIndex = 0
        Me.CdsALeft.Use3DCoordinateSpaceTree = False
        '
        'PnlALeftToolBar
        '
        Me.PnlALeftToolBar.BDrawBorderBottom = False
        Me.PnlALeftToolBar.BDrawBorderLeft = False
        Me.PnlALeftToolBar.BDrawBorderRight = False
        Me.PnlALeftToolBar.BDrawBorderTop = False
        Me.PnlALeftToolBar.Controls.Add(Me.BtnALeftClearChecker)
        Me.PnlALeftToolBar.Controls.Add(Me.BtnALeftShowChecker)
        Me.PnlALeftToolBar.Controls.Add(Me.CdtALeft)
        Me.PnlALeftToolBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlALeftToolBar.Location = New System.Drawing.Point(0, 0)
        Me.PnlALeftToolBar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlALeftToolBar.Name = "PnlALeftToolBar"
        Me.PnlALeftToolBar.Size = New System.Drawing.Size(324, 30)
        Me.PnlALeftToolBar.TabIndex = 6
        '
        'BtnALeftClearChecker
        '
        Me.BtnALeftClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnALeftClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnALeftClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnALeftClearChecker.Location = New System.Drawing.Point(292, 3)
        Me.BtnALeftClearChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnALeftClearChecker.Name = "BtnALeftClearChecker"
        Me.BtnALeftClearChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnALeftClearChecker.TabIndex = 61
        Me.BtnALeftClearChecker.Tag = "0"
        Me.BtnALeftClearChecker.UseVisualStyleBackColor = False
        '
        'BtnALeftShowChecker
        '
        Me.BtnALeftShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnALeftShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnALeftShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnALeftShowChecker.Image = CType(resources.GetObject("BtnALeftShowChecker.Image"), System.Drawing.Image)
        Me.BtnALeftShowChecker.Location = New System.Drawing.Point(263, 3)
        Me.BtnALeftShowChecker.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnALeftShowChecker.Name = "BtnALeftShowChecker"
        Me.BtnALeftShowChecker.Size = New System.Drawing.Size(27, 23)
        Me.BtnALeftShowChecker.TabIndex = 60
        Me.BtnALeftShowChecker.Tag = "0"
        Me.BtnALeftShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnALeftShowChecker.UseVisualStyleBackColor = False
        '
        'CdtALeft
        '
        Me.CdtALeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtALeft.Location = New System.Drawing.Point(0, 0)
        Me.CdtALeft.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CdtALeft.Name = "CdtALeft"
        Me.CdtALeft.Size = New System.Drawing.Size(324, 30)
        Me.CdtALeft.TabIndex = 0
        '
        'PnlRight
        '
        Me.PnlRight.BDrawBorderBottom = False
        Me.PnlRight.BDrawBorderLeft = False
        Me.PnlRight.BDrawBorderRight = False
        Me.PnlRight.BDrawBorderTop = False
        Me.PnlRight.Controls.Add(Me.NudDistY)
        Me.PnlRight.Controls.Add(Me.CLabel2)
        Me.PnlRight.Controls.Add(Me.NudDistX)
        Me.PnlRight.Controls.Add(Me.LblTitleID)
        Me.PnlRight.Controls.Add(Me.PnlMessage)
        Me.PnlRight.Controls.Add(Me.PnlEdge)
        Me.PnlRight.Controls.Add(Me.PnlAlignment)
        Me.PnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PnlRight.Location = New System.Drawing.Point(1227, 46)
        Me.PnlRight.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlRight.Name = "PnlRight"
        Me.PnlRight.Size = New System.Drawing.Size(480, 968)
        Me.PnlRight.TabIndex = 5
        '
        'PnlMessage
        '
        Me.PnlMessage.BDrawBorderBottom = False
        Me.PnlMessage.BDrawBorderLeft = True
        Me.PnlMessage.BDrawBorderRight = False
        Me.PnlMessage.BDrawBorderTop = False
        Me.PnlMessage.Controls.Add(Me.LtbMessage)
        Me.PnlMessage.Controls.Add(Me.LblTitleMessage)
        Me.PnlMessage.Location = New System.Drawing.Point(0, 590)
        Me.PnlMessage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlMessage.Name = "PnlMessage"
        Me.PnlMessage.Size = New System.Drawing.Size(480, 379)
        Me.PnlMessage.TabIndex = 5
        '
        'LtbMessage
        '
        Me.LtbMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LtbMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LtbMessage.FormattingEnabled = True
        Me.LtbMessage.HorizontalScrollbar = True
        Me.LtbMessage.IntegralHeight = False
        Me.LtbMessage.ItemHeight = 20
        Me.LtbMessage.Location = New System.Drawing.Point(0, 27)
        Me.LtbMessage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.LtbMessage.Name = "LtbMessage"
        Me.LtbMessage.ScrollAlwaysVisible = True
        Me.LtbMessage.Size = New System.Drawing.Size(480, 352)
        Me.LtbMessage.TabIndex = 25
        '
        'LblTitleMessage
        '
        Me.LblTitleMessage.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleMessage.BDrawBorderBottom = True
        Me.LblTitleMessage.BDrawBorderLeft = True
        Me.LblTitleMessage.BDrawBorderRight = False
        Me.LblTitleMessage.BDrawBorderTop = True
        Me.LblTitleMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleMessage.ForeColor = System.Drawing.Color.White
        Me.LblTitleMessage.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleMessage.Name = "LblTitleMessage"
        Me.LblTitleMessage.OColor = System.Drawing.Color.Black
        Me.LblTitleMessage.Size = New System.Drawing.Size(480, 27)
        Me.LblTitleMessage.TabIndex = 24
        Me.LblTitleMessage.Text = "Message"
        Me.LblTitleMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlEdge
        '
        Me.PnlEdge.BDrawBorderBottom = False
        Me.PnlEdge.BDrawBorderLeft = False
        Me.PnlEdge.BDrawBorderRight = False
        Me.PnlEdge.BDrawBorderTop = False
        Me.PnlEdge.Controls.Add(Me.LblScore)
        Me.PnlEdge.Controls.Add(Me.LblTitleAEdgeTop)
        Me.PnlEdge.Controls.Add(Me.LblAEdgeTopRight)
        Me.PnlEdge.Controls.Add(Me.LblAEdgeBottomRight)
        Me.PnlEdge.Controls.Add(Me.LblBRightScore)
        Me.PnlEdge.Controls.Add(Me.LblBLeftScore)
        Me.PnlEdge.Controls.Add(Me.LblARightScore)
        Me.PnlEdge.Controls.Add(Me.LblALeftScore)
        Me.PnlEdge.Controls.Add(Me.LblSummary)
        Me.PnlEdge.Controls.Add(Me.CLabel7)
        Me.PnlEdge.Controls.Add(Me.CLabel4)
        Me.PnlEdge.Controls.Add(Me.CLabel8)
        Me.PnlEdge.Controls.Add(Me.LblBStageTotalTimeElapsed)
        Me.PnlEdge.Controls.Add(Me.LblMaxRetries)
        Me.PnlEdge.Controls.Add(Me.LblAStageTotalTimeElapsed)
        Me.PnlEdge.Controls.Add(Me.CLabel1)
        Me.PnlEdge.Controls.Add(Me.LblBStageTotalRetry)
        Me.PnlEdge.Controls.Add(Me.LblAStageTotalRetry)
        Me.PnlEdge.Controls.Add(Me.LblTitleAEdgeBottom)
        Me.PnlEdge.Controls.Add(Me.LblTitleEdge)
        Me.PnlEdge.Controls.Add(Me.LblTitleBEdgeBottom)
        Me.PnlEdge.Controls.Add(Me.LblTitleBEdgeTop)
        Me.PnlEdge.Controls.Add(Me.LblBEdgeBottomRight)
        Me.PnlEdge.Controls.Add(Me.LblBEdgeTopRight)
        Me.PnlEdge.Controls.Add(Me.LblBEdgeBottomLeft)
        Me.PnlEdge.Controls.Add(Me.LblBEdgeTopLeft)
        Me.PnlEdge.Controls.Add(Me.LblTitleEdgeRight)
        Me.PnlEdge.Controls.Add(Me.LblTitleEdgeLeft)
        Me.PnlEdge.Controls.Add(Me.LblTitleEdgeBlank)
        Me.PnlEdge.Controls.Add(Me.LblAEdgeTopLeft)
        Me.PnlEdge.Controls.Add(Me.LblAEdgeBottomLeft)
        Me.PnlEdge.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlEdge.Location = New System.Drawing.Point(0, 263)
        Me.PnlEdge.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlEdge.Name = "PnlEdge"
        Me.PnlEdge.Size = New System.Drawing.Size(480, 288)
        Me.PnlEdge.TabIndex = 6
        '
        'LblScore
        '
        Me.LblScore.BackColor = System.Drawing.Color.DimGray
        Me.LblScore.BDrawBorderBottom = True
        Me.LblScore.BDrawBorderLeft = True
        Me.LblScore.BDrawBorderRight = True
        Me.LblScore.BDrawBorderTop = False
        Me.LblScore.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblScore.ForeColor = System.Drawing.Color.White
        Me.LblScore.Location = New System.Drawing.Point(0, 263)
        Me.LblScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblScore.Name = "LblScore"
        Me.LblScore.OColor = System.Drawing.Color.Black
        Me.LblScore.Size = New System.Drawing.Size(160, 27)
        Me.LblScore.TabIndex = 51
        Me.LblScore.Text = "Score(L,R)"
        Me.LblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeTop
        '
        Me.LblTitleAEdgeTop.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeTop.BDrawBorderBottom = True
        Me.LblTitleAEdgeTop.BDrawBorderLeft = True
        Me.LblTitleAEdgeTop.BDrawBorderRight = True
        Me.LblTitleAEdgeTop.BDrawBorderTop = False
        Me.LblTitleAEdgeTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeTop.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeTop.Location = New System.Drawing.Point(0, 53)
        Me.LblTitleAEdgeTop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAEdgeTop.Name = "LblTitleAEdgeTop"
        Me.LblTitleAEdgeTop.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeTop.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAEdgeTop.TabIndex = 4
        Me.LblTitleAEdgeTop.Text = "#1 Front"
        Me.LblTitleAEdgeTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAEdgeTopRight
        '
        Me.LblAEdgeTopRight.BackColor = System.Drawing.Color.White
        Me.LblAEdgeTopRight.BDrawBorderBottom = True
        Me.LblAEdgeTopRight.BDrawBorderLeft = False
        Me.LblAEdgeTopRight.BDrawBorderRight = True
        Me.LblAEdgeTopRight.BDrawBorderTop = False
        Me.LblAEdgeTopRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAEdgeTopRight.ForeColor = System.Drawing.Color.White
        Me.LblAEdgeTopRight.Location = New System.Drawing.Point(320, 53)
        Me.LblAEdgeTopRight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAEdgeTopRight.Name = "LblAEdgeTopRight"
        Me.LblAEdgeTopRight.OColor = System.Drawing.Color.Black
        Me.LblAEdgeTopRight.Size = New System.Drawing.Size(160, 27)
        Me.LblAEdgeTopRight.TabIndex = 4
        Me.LblAEdgeTopRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAEdgeBottomRight
        '
        Me.LblAEdgeBottomRight.BackColor = System.Drawing.Color.White
        Me.LblAEdgeBottomRight.BDrawBorderBottom = True
        Me.LblAEdgeBottomRight.BDrawBorderLeft = False
        Me.LblAEdgeBottomRight.BDrawBorderRight = True
        Me.LblAEdgeBottomRight.BDrawBorderTop = False
        Me.LblAEdgeBottomRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAEdgeBottomRight.ForeColor = System.Drawing.Color.White
        Me.LblAEdgeBottomRight.Location = New System.Drawing.Point(320, 78)
        Me.LblAEdgeBottomRight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAEdgeBottomRight.Name = "LblAEdgeBottomRight"
        Me.LblAEdgeBottomRight.OColor = System.Drawing.Color.Black
        Me.LblAEdgeBottomRight.Size = New System.Drawing.Size(160, 27)
        Me.LblAEdgeBottomRight.TabIndex = 4
        Me.LblAEdgeBottomRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBRightScore
        '
        Me.LblBRightScore.BackColor = System.Drawing.Color.White
        Me.LblBRightScore.BDrawBorderBottom = True
        Me.LblBRightScore.BDrawBorderLeft = False
        Me.LblBRightScore.BDrawBorderRight = True
        Me.LblBRightScore.BDrawBorderTop = False
        Me.LblBRightScore.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblBRightScore.ForeColor = System.Drawing.Color.White
        Me.LblBRightScore.Location = New System.Drawing.Point(400, 263)
        Me.LblBRightScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBRightScore.Name = "LblBRightScore"
        Me.LblBRightScore.OColor = System.Drawing.Color.Black
        Me.LblBRightScore.Size = New System.Drawing.Size(80, 27)
        Me.LblBRightScore.TabIndex = 55
        Me.LblBRightScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBLeftScore
        '
        Me.LblBLeftScore.BackColor = System.Drawing.Color.White
        Me.LblBLeftScore.BDrawBorderBottom = True
        Me.LblBLeftScore.BDrawBorderLeft = False
        Me.LblBLeftScore.BDrawBorderRight = True
        Me.LblBLeftScore.BDrawBorderTop = False
        Me.LblBLeftScore.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblBLeftScore.ForeColor = System.Drawing.Color.White
        Me.LblBLeftScore.Location = New System.Drawing.Point(320, 263)
        Me.LblBLeftScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBLeftScore.Name = "LblBLeftScore"
        Me.LblBLeftScore.OColor = System.Drawing.Color.Black
        Me.LblBLeftScore.Size = New System.Drawing.Size(80, 27)
        Me.LblBLeftScore.TabIndex = 54
        Me.LblBLeftScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblARightScore
        '
        Me.LblARightScore.BackColor = System.Drawing.Color.White
        Me.LblARightScore.BDrawBorderBottom = True
        Me.LblARightScore.BDrawBorderLeft = False
        Me.LblARightScore.BDrawBorderRight = True
        Me.LblARightScore.BDrawBorderTop = False
        Me.LblARightScore.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblARightScore.ForeColor = System.Drawing.Color.White
        Me.LblARightScore.Location = New System.Drawing.Point(240, 263)
        Me.LblARightScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblARightScore.Name = "LblARightScore"
        Me.LblARightScore.OColor = System.Drawing.Color.Black
        Me.LblARightScore.Size = New System.Drawing.Size(80, 27)
        Me.LblARightScore.TabIndex = 53
        Me.LblARightScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblALeftScore
        '
        Me.LblALeftScore.BackColor = System.Drawing.Color.White
        Me.LblALeftScore.BDrawBorderBottom = True
        Me.LblALeftScore.BDrawBorderLeft = False
        Me.LblALeftScore.BDrawBorderRight = True
        Me.LblALeftScore.BDrawBorderTop = False
        Me.LblALeftScore.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblALeftScore.ForeColor = System.Drawing.Color.White
        Me.LblALeftScore.Location = New System.Drawing.Point(160, 263)
        Me.LblALeftScore.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblALeftScore.Name = "LblALeftScore"
        Me.LblALeftScore.OColor = System.Drawing.Color.Black
        Me.LblALeftScore.Size = New System.Drawing.Size(80, 27)
        Me.LblALeftScore.TabIndex = 52
        Me.LblALeftScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSummary
        '
        Me.LblSummary.BackColor = System.Drawing.Color.DimGray
        Me.LblSummary.BDrawBorderBottom = True
        Me.LblSummary.BDrawBorderLeft = True
        Me.LblSummary.BDrawBorderRight = False
        Me.LblSummary.BDrawBorderTop = False
        Me.LblSummary.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblSummary.ForeColor = System.Drawing.Color.White
        Me.LblSummary.Location = New System.Drawing.Point(0, 158)
        Me.LblSummary.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSummary.Name = "LblSummary"
        Me.LblSummary.OColor = System.Drawing.Color.Black
        Me.LblSummary.Size = New System.Drawing.Size(480, 27)
        Me.LblSummary.TabIndex = 41
        Me.LblSummary.Text = "Summary concerning the last success"
        Me.LblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel7
        '
        Me.CLabel7.BackColor = System.Drawing.Color.DimGray
        Me.CLabel7.BDrawBorderBottom = True
        Me.CLabel7.BDrawBorderLeft = False
        Me.CLabel7.BDrawBorderRight = False
        Me.CLabel7.BDrawBorderTop = False
        Me.CLabel7.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CLabel7.ForeColor = System.Drawing.Color.White
        Me.CLabel7.Location = New System.Drawing.Point(320, 183)
        Me.CLabel7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CLabel7.Name = "CLabel7"
        Me.CLabel7.OColor = System.Drawing.Color.Black
        Me.CLabel7.Size = New System.Drawing.Size(160, 27)
        Me.CLabel7.TabIndex = 46
        Me.CLabel7.Text = "Stage #2"
        Me.CLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel4
        '
        Me.CLabel4.BackColor = System.Drawing.Color.DimGray
        Me.CLabel4.BDrawBorderBottom = True
        Me.CLabel4.BDrawBorderLeft = True
        Me.CLabel4.BDrawBorderRight = True
        Me.CLabel4.BDrawBorderTop = False
        Me.CLabel4.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CLabel4.ForeColor = System.Drawing.Color.White
        Me.CLabel4.Location = New System.Drawing.Point(0, 237)
        Me.CLabel4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CLabel4.Name = "CLabel4"
        Me.CLabel4.OColor = System.Drawing.Color.Black
        Me.CLabel4.Size = New System.Drawing.Size(160, 27)
        Me.CLabel4.TabIndex = 48
        Me.CLabel4.Text = "Time Elapsed"
        Me.CLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CLabel8
        '
        Me.CLabel8.BackColor = System.Drawing.Color.DimGray
        Me.CLabel8.BDrawBorderBottom = True
        Me.CLabel8.BDrawBorderLeft = False
        Me.CLabel8.BDrawBorderRight = True
        Me.CLabel8.BDrawBorderTop = False
        Me.CLabel8.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CLabel8.ForeColor = System.Drawing.Color.White
        Me.CLabel8.Location = New System.Drawing.Point(160, 183)
        Me.CLabel8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CLabel8.Name = "CLabel8"
        Me.CLabel8.OColor = System.Drawing.Color.Black
        Me.CLabel8.Size = New System.Drawing.Size(160, 27)
        Me.CLabel8.TabIndex = 44
        Me.CLabel8.Text = "Stage #1"
        Me.CLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBStageTotalTimeElapsed
        '
        Me.LblBStageTotalTimeElapsed.BackColor = System.Drawing.Color.White
        Me.LblBStageTotalTimeElapsed.BDrawBorderBottom = True
        Me.LblBStageTotalTimeElapsed.BDrawBorderLeft = False
        Me.LblBStageTotalTimeElapsed.BDrawBorderRight = True
        Me.LblBStageTotalTimeElapsed.BDrawBorderTop = False
        Me.LblBStageTotalTimeElapsed.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblBStageTotalTimeElapsed.ForeColor = System.Drawing.Color.White
        Me.LblBStageTotalTimeElapsed.Location = New System.Drawing.Point(320, 237)
        Me.LblBStageTotalTimeElapsed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBStageTotalTimeElapsed.Name = "LblBStageTotalTimeElapsed"
        Me.LblBStageTotalTimeElapsed.OColor = System.Drawing.Color.Black
        Me.LblBStageTotalTimeElapsed.Size = New System.Drawing.Size(160, 27)
        Me.LblBStageTotalTimeElapsed.TabIndex = 50
        Me.LblBStageTotalTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMaxRetries
        '
        Me.LblMaxRetries.BackColor = System.Drawing.Color.DimGray
        Me.LblMaxRetries.BDrawBorderBottom = True
        Me.LblMaxRetries.BDrawBorderLeft = True
        Me.LblMaxRetries.BDrawBorderRight = True
        Me.LblMaxRetries.BDrawBorderTop = False
        Me.LblMaxRetries.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblMaxRetries.ForeColor = System.Drawing.Color.White
        Me.LblMaxRetries.Location = New System.Drawing.Point(0, 183)
        Me.LblMaxRetries.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblMaxRetries.Name = "LblMaxRetries"
        Me.LblMaxRetries.OColor = System.Drawing.Color.Black
        Me.LblMaxRetries.Size = New System.Drawing.Size(160, 27)
        Me.LblMaxRetries.TabIndex = 42
        Me.LblMaxRetries.Text = "Max Retries = 10"
        Me.LblMaxRetries.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAStageTotalTimeElapsed
        '
        Me.LblAStageTotalTimeElapsed.BackColor = System.Drawing.Color.White
        Me.LblAStageTotalTimeElapsed.BDrawBorderBottom = True
        Me.LblAStageTotalTimeElapsed.BDrawBorderLeft = False
        Me.LblAStageTotalTimeElapsed.BDrawBorderRight = True
        Me.LblAStageTotalTimeElapsed.BDrawBorderTop = False
        Me.LblAStageTotalTimeElapsed.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblAStageTotalTimeElapsed.ForeColor = System.Drawing.Color.White
        Me.LblAStageTotalTimeElapsed.Location = New System.Drawing.Point(160, 237)
        Me.LblAStageTotalTimeElapsed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAStageTotalTimeElapsed.Name = "LblAStageTotalTimeElapsed"
        Me.LblAStageTotalTimeElapsed.OColor = System.Drawing.Color.Black
        Me.LblAStageTotalTimeElapsed.Size = New System.Drawing.Size(160, 27)
        Me.LblAStageTotalTimeElapsed.TabIndex = 49
        Me.LblAStageTotalTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CLabel1
        '
        Me.CLabel1.BackColor = System.Drawing.Color.DimGray
        Me.CLabel1.BDrawBorderBottom = True
        Me.CLabel1.BDrawBorderLeft = True
        Me.CLabel1.BDrawBorderRight = True
        Me.CLabel1.BDrawBorderTop = False
        Me.CLabel1.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.CLabel1.ForeColor = System.Drawing.Color.White
        Me.CLabel1.Location = New System.Drawing.Point(0, 210)
        Me.CLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CLabel1.Name = "CLabel1"
        Me.CLabel1.OColor = System.Drawing.Color.Black
        Me.CLabel1.Size = New System.Drawing.Size(160, 27)
        Me.CLabel1.TabIndex = 43
        Me.CLabel1.Text = "Num. of Retries"
        Me.CLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBStageTotalRetry
        '
        Me.LblBStageTotalRetry.BackColor = System.Drawing.Color.White
        Me.LblBStageTotalRetry.BDrawBorderBottom = True
        Me.LblBStageTotalRetry.BDrawBorderLeft = False
        Me.LblBStageTotalRetry.BDrawBorderRight = True
        Me.LblBStageTotalRetry.BDrawBorderTop = False
        Me.LblBStageTotalRetry.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblBStageTotalRetry.ForeColor = System.Drawing.Color.White
        Me.LblBStageTotalRetry.Location = New System.Drawing.Point(320, 210)
        Me.LblBStageTotalRetry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBStageTotalRetry.Name = "LblBStageTotalRetry"
        Me.LblBStageTotalRetry.OColor = System.Drawing.Color.Black
        Me.LblBStageTotalRetry.Size = New System.Drawing.Size(160, 27)
        Me.LblBStageTotalRetry.TabIndex = 47
        Me.LblBStageTotalRetry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAStageTotalRetry
        '
        Me.LblAStageTotalRetry.BackColor = System.Drawing.Color.White
        Me.LblAStageTotalRetry.BDrawBorderBottom = True
        Me.LblAStageTotalRetry.BDrawBorderLeft = False
        Me.LblAStageTotalRetry.BDrawBorderRight = True
        Me.LblAStageTotalRetry.BDrawBorderTop = False
        Me.LblAStageTotalRetry.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.LblAStageTotalRetry.ForeColor = System.Drawing.Color.White
        Me.LblAStageTotalRetry.Location = New System.Drawing.Point(160, 210)
        Me.LblAStageTotalRetry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAStageTotalRetry.Name = "LblAStageTotalRetry"
        Me.LblAStageTotalRetry.OColor = System.Drawing.Color.Black
        Me.LblAStageTotalRetry.Size = New System.Drawing.Size(160, 27)
        Me.LblAStageTotalRetry.TabIndex = 45
        Me.LblAStageTotalRetry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitleAEdgeBottom
        '
        Me.LblTitleAEdgeBottom.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeBottom.BDrawBorderBottom = True
        Me.LblTitleAEdgeBottom.BDrawBorderLeft = True
        Me.LblTitleAEdgeBottom.BDrawBorderRight = True
        Me.LblTitleAEdgeBottom.BDrawBorderTop = False
        Me.LblTitleAEdgeBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeBottom.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeBottom.Location = New System.Drawing.Point(0, 78)
        Me.LblTitleAEdgeBottom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAEdgeBottom.Name = "LblTitleAEdgeBottom"
        Me.LblTitleAEdgeBottom.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeBottom.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAEdgeBottom.TabIndex = 4
        Me.LblTitleAEdgeBottom.Text = "#1 Rear"
        Me.LblTitleAEdgeBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleEdge
        '
        Me.LblTitleEdge.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleEdge.BDrawBorderBottom = True
        Me.LblTitleEdge.BDrawBorderLeft = True
        Me.LblTitleEdge.BDrawBorderRight = True
        Me.LblTitleEdge.BDrawBorderTop = False
        Me.LblTitleEdge.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleEdge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleEdge.ForeColor = System.Drawing.Color.White
        Me.LblTitleEdge.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleEdge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleEdge.Name = "LblTitleEdge"
        Me.LblTitleEdge.OColor = System.Drawing.Color.Black
        Me.LblTitleEdge.Size = New System.Drawing.Size(480, 27)
        Me.LblTitleEdge.TabIndex = 23
        Me.LblTitleEdge.Text = "Edge"
        Me.LblTitleEdge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBEdgeBottom
        '
        Me.LblTitleBEdgeBottom.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeBottom.BDrawBorderBottom = True
        Me.LblTitleBEdgeBottom.BDrawBorderLeft = True
        Me.LblTitleBEdgeBottom.BDrawBorderRight = True
        Me.LblTitleBEdgeBottom.BDrawBorderTop = False
        Me.LblTitleBEdgeBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeBottom.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeBottom.Location = New System.Drawing.Point(0, 132)
        Me.LblTitleBEdgeBottom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBEdgeBottom.Name = "LblTitleBEdgeBottom"
        Me.LblTitleBEdgeBottom.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeBottom.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleBEdgeBottom.TabIndex = 18
        Me.LblTitleBEdgeBottom.Text = "#2 Rear"
        Me.LblTitleBEdgeBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBEdgeTop
        '
        Me.LblTitleBEdgeTop.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeTop.BDrawBorderBottom = True
        Me.LblTitleBEdgeTop.BDrawBorderLeft = True
        Me.LblTitleBEdgeTop.BDrawBorderRight = True
        Me.LblTitleBEdgeTop.BDrawBorderTop = False
        Me.LblTitleBEdgeTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeTop.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeTop.Location = New System.Drawing.Point(0, 105)
        Me.LblTitleBEdgeTop.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBEdgeTop.Name = "LblTitleBEdgeTop"
        Me.LblTitleBEdgeTop.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeTop.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleBEdgeTop.TabIndex = 18
        Me.LblTitleBEdgeTop.Text = "#2 Front"
        Me.LblTitleBEdgeTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBEdgeBottomRight
        '
        Me.LblBEdgeBottomRight.BackColor = System.Drawing.Color.White
        Me.LblBEdgeBottomRight.BDrawBorderBottom = True
        Me.LblBEdgeBottomRight.BDrawBorderLeft = False
        Me.LblBEdgeBottomRight.BDrawBorderRight = True
        Me.LblBEdgeBottomRight.BDrawBorderTop = False
        Me.LblBEdgeBottomRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBEdgeBottomRight.ForeColor = System.Drawing.Color.White
        Me.LblBEdgeBottomRight.Location = New System.Drawing.Point(320, 132)
        Me.LblBEdgeBottomRight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBEdgeBottomRight.Name = "LblBEdgeBottomRight"
        Me.LblBEdgeBottomRight.OColor = System.Drawing.Color.Black
        Me.LblBEdgeBottomRight.Size = New System.Drawing.Size(160, 27)
        Me.LblBEdgeBottomRight.TabIndex = 21
        Me.LblBEdgeBottomRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBEdgeTopRight
        '
        Me.LblBEdgeTopRight.BackColor = System.Drawing.Color.White
        Me.LblBEdgeTopRight.BDrawBorderBottom = True
        Me.LblBEdgeTopRight.BDrawBorderLeft = False
        Me.LblBEdgeTopRight.BDrawBorderRight = True
        Me.LblBEdgeTopRight.BDrawBorderTop = False
        Me.LblBEdgeTopRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBEdgeTopRight.ForeColor = System.Drawing.Color.White
        Me.LblBEdgeTopRight.Location = New System.Drawing.Point(320, 105)
        Me.LblBEdgeTopRight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBEdgeTopRight.Name = "LblBEdgeTopRight"
        Me.LblBEdgeTopRight.OColor = System.Drawing.Color.Black
        Me.LblBEdgeTopRight.Size = New System.Drawing.Size(160, 27)
        Me.LblBEdgeTopRight.TabIndex = 21
        Me.LblBEdgeTopRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBEdgeBottomLeft
        '
        Me.LblBEdgeBottomLeft.BackColor = System.Drawing.Color.White
        Me.LblBEdgeBottomLeft.BDrawBorderBottom = True
        Me.LblBEdgeBottomLeft.BDrawBorderLeft = False
        Me.LblBEdgeBottomLeft.BDrawBorderRight = True
        Me.LblBEdgeBottomLeft.BDrawBorderTop = False
        Me.LblBEdgeBottomLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBEdgeBottomLeft.ForeColor = System.Drawing.Color.White
        Me.LblBEdgeBottomLeft.Location = New System.Drawing.Point(160, 132)
        Me.LblBEdgeBottomLeft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBEdgeBottomLeft.Name = "LblBEdgeBottomLeft"
        Me.LblBEdgeBottomLeft.OColor = System.Drawing.Color.Black
        Me.LblBEdgeBottomLeft.Size = New System.Drawing.Size(160, 27)
        Me.LblBEdgeBottomLeft.TabIndex = 20
        Me.LblBEdgeBottomLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBEdgeTopLeft
        '
        Me.LblBEdgeTopLeft.BackColor = System.Drawing.Color.White
        Me.LblBEdgeTopLeft.BDrawBorderBottom = True
        Me.LblBEdgeTopLeft.BDrawBorderLeft = False
        Me.LblBEdgeTopLeft.BDrawBorderRight = True
        Me.LblBEdgeTopLeft.BDrawBorderTop = False
        Me.LblBEdgeTopLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBEdgeTopLeft.ForeColor = System.Drawing.Color.White
        Me.LblBEdgeTopLeft.Location = New System.Drawing.Point(160, 105)
        Me.LblBEdgeTopLeft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBEdgeTopLeft.Name = "LblBEdgeTopLeft"
        Me.LblBEdgeTopLeft.OColor = System.Drawing.Color.Black
        Me.LblBEdgeTopLeft.Size = New System.Drawing.Size(160, 27)
        Me.LblBEdgeTopLeft.TabIndex = 20
        Me.LblBEdgeTopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitleEdgeRight
        '
        Me.LblTitleEdgeRight.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleEdgeRight.BDrawBorderBottom = True
        Me.LblTitleEdgeRight.BDrawBorderLeft = False
        Me.LblTitleEdgeRight.BDrawBorderRight = True
        Me.LblTitleEdgeRight.BDrawBorderTop = False
        Me.LblTitleEdgeRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleEdgeRight.ForeColor = System.Drawing.Color.White
        Me.LblTitleEdgeRight.Location = New System.Drawing.Point(320, 27)
        Me.LblTitleEdgeRight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleEdgeRight.Name = "LblTitleEdgeRight"
        Me.LblTitleEdgeRight.OColor = System.Drawing.Color.Black
        Me.LblTitleEdgeRight.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleEdgeRight.TabIndex = 7
        Me.LblTitleEdgeRight.Text = "Right"
        Me.LblTitleEdgeRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleEdgeLeft
        '
        Me.LblTitleEdgeLeft.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleEdgeLeft.BDrawBorderBottom = True
        Me.LblTitleEdgeLeft.BDrawBorderLeft = False
        Me.LblTitleEdgeLeft.BDrawBorderRight = True
        Me.LblTitleEdgeLeft.BDrawBorderTop = False
        Me.LblTitleEdgeLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleEdgeLeft.ForeColor = System.Drawing.Color.White
        Me.LblTitleEdgeLeft.Location = New System.Drawing.Point(160, 27)
        Me.LblTitleEdgeLeft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleEdgeLeft.Name = "LblTitleEdgeLeft"
        Me.LblTitleEdgeLeft.OColor = System.Drawing.Color.Black
        Me.LblTitleEdgeLeft.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleEdgeLeft.TabIndex = 6
        Me.LblTitleEdgeLeft.Text = "Left"
        Me.LblTitleEdgeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleEdgeBlank
        '
        Me.LblTitleEdgeBlank.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleEdgeBlank.BDrawBorderBottom = True
        Me.LblTitleEdgeBlank.BDrawBorderLeft = True
        Me.LblTitleEdgeBlank.BDrawBorderRight = True
        Me.LblTitleEdgeBlank.BDrawBorderTop = False
        Me.LblTitleEdgeBlank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleEdgeBlank.ForeColor = System.Drawing.Color.White
        Me.LblTitleEdgeBlank.Location = New System.Drawing.Point(0, 27)
        Me.LblTitleEdgeBlank.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleEdgeBlank.Name = "LblTitleEdgeBlank"
        Me.LblTitleEdgeBlank.OColor = System.Drawing.Color.Black
        Me.LblTitleEdgeBlank.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleEdgeBlank.TabIndex = 5
        Me.LblTitleEdgeBlank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAEdgeTopLeft
        '
        Me.LblAEdgeTopLeft.BackColor = System.Drawing.Color.White
        Me.LblAEdgeTopLeft.BDrawBorderBottom = True
        Me.LblAEdgeTopLeft.BDrawBorderLeft = False
        Me.LblAEdgeTopLeft.BDrawBorderRight = True
        Me.LblAEdgeTopLeft.BDrawBorderTop = False
        Me.LblAEdgeTopLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAEdgeTopLeft.ForeColor = System.Drawing.Color.White
        Me.LblAEdgeTopLeft.Location = New System.Drawing.Point(160, 53)
        Me.LblAEdgeTopLeft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAEdgeTopLeft.Name = "LblAEdgeTopLeft"
        Me.LblAEdgeTopLeft.OColor = System.Drawing.Color.Black
        Me.LblAEdgeTopLeft.Size = New System.Drawing.Size(160, 27)
        Me.LblAEdgeTopLeft.TabIndex = 4
        Me.LblAEdgeTopLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAEdgeBottomLeft
        '
        Me.LblAEdgeBottomLeft.BackColor = System.Drawing.Color.White
        Me.LblAEdgeBottomLeft.BDrawBorderBottom = True
        Me.LblAEdgeBottomLeft.BDrawBorderLeft = False
        Me.LblAEdgeBottomLeft.BDrawBorderRight = True
        Me.LblAEdgeBottomLeft.BDrawBorderTop = False
        Me.LblAEdgeBottomLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAEdgeBottomLeft.ForeColor = System.Drawing.Color.White
        Me.LblAEdgeBottomLeft.Location = New System.Drawing.Point(160, 78)
        Me.LblAEdgeBottomLeft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAEdgeBottomLeft.Name = "LblAEdgeBottomLeft"
        Me.LblAEdgeBottomLeft.OColor = System.Drawing.Color.Black
        Me.LblAEdgeBottomLeft.Size = New System.Drawing.Size(160, 27)
        Me.LblAEdgeBottomLeft.TabIndex = 4
        Me.LblAEdgeBottomLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnlAlignment
        '
        Me.PnlAlignment.BDrawBorderBottom = False
        Me.PnlAlignment.BDrawBorderLeft = False
        Me.PnlAlignment.BDrawBorderRight = False
        Me.PnlAlignment.BDrawBorderTop = False
        Me.PnlAlignment.Controls.Add(Me.LblTitleBAlignmentLeftX)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAAlignmentLeftX)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAAlignmentRightX)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentLeftXCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentLeftXTarget)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentLeftXCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentLeftXTarget)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAAlignmentT)
        Me.PnlAlignment.Controls.Add(Me.LblTitleBAlignmentT)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAAlignmentY)
        Me.PnlAlignment.Controls.Add(Me.LblTitleBAlignmentY)
        Me.PnlAlignment.Controls.Add(Me.LblTitleBAlignmentRightX)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAlignmentCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentTCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentTCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentTTarget)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentTTarget)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentYCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentYCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentYTarget)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentYTarget)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentRightXCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentRightXCurrent)
        Me.PnlAlignment.Controls.Add(Me.LblBAlignmentRightXTarget)
        Me.PnlAlignment.Controls.Add(Me.LblAAlignmentRightXTarget)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAlignmentTarget)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAlignmentBlank)
        Me.PnlAlignment.Controls.Add(Me.LblTitleAlignment)
        Me.PnlAlignment.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlAlignment.Location = New System.Drawing.Point(0, 0)
        Me.PnlAlignment.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlAlignment.Name = "PnlAlignment"
        Me.PnlAlignment.Size = New System.Drawing.Size(480, 263)
        Me.PnlAlignment.TabIndex = 5
        '
        'LblTitleBAlignmentLeftX
        '
        Me.LblTitleBAlignmentLeftX.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentLeftX.BDrawBorderBottom = True
        Me.LblTitleBAlignmentLeftX.BDrawBorderLeft = True
        Me.LblTitleBAlignmentLeftX.BDrawBorderRight = True
        Me.LblTitleBAlignmentLeftX.BDrawBorderTop = False
        Me.LblTitleBAlignmentLeftX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentLeftX.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentLeftX.Location = New System.Drawing.Point(0, 158)
        Me.LblTitleBAlignmentLeftX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBAlignmentLeftX.Name = "LblTitleBAlignmentLeftX"
        Me.LblTitleBAlignmentLeftX.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentLeftX.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleBAlignmentLeftX.TabIndex = 22
        Me.LblTitleBAlignmentLeftX.Text = "#2 XL"
        Me.LblTitleBAlignmentLeftX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAAlignmentLeftX
        '
        Me.LblTitleAAlignmentLeftX.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentLeftX.BDrawBorderBottom = True
        Me.LblTitleAAlignmentLeftX.BDrawBorderLeft = True
        Me.LblTitleAAlignmentLeftX.BDrawBorderRight = True
        Me.LblTitleAAlignmentLeftX.BDrawBorderTop = False
        Me.LblTitleAAlignmentLeftX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentLeftX.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentLeftX.Location = New System.Drawing.Point(0, 53)
        Me.LblTitleAAlignmentLeftX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAAlignmentLeftX.Name = "LblTitleAAlignmentLeftX"
        Me.LblTitleAAlignmentLeftX.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentLeftX.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAAlignmentLeftX.TabIndex = 4
        Me.LblTitleAAlignmentLeftX.Text = "#1 XL"
        Me.LblTitleAAlignmentLeftX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAAlignmentRightX
        '
        Me.LblTitleAAlignmentRightX.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentRightX.BDrawBorderBottom = True
        Me.LblTitleAAlignmentRightX.BDrawBorderLeft = True
        Me.LblTitleAAlignmentRightX.BDrawBorderRight = True
        Me.LblTitleAAlignmentRightX.BDrawBorderTop = False
        Me.LblTitleAAlignmentRightX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentRightX.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentRightX.Location = New System.Drawing.Point(0, 78)
        Me.LblTitleAAlignmentRightX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAAlignmentRightX.Name = "LblTitleAAlignmentRightX"
        Me.LblTitleAAlignmentRightX.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentRightX.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAAlignmentRightX.TabIndex = 4
        Me.LblTitleAAlignmentRightX.Text = "#1 XR"
        Me.LblTitleAAlignmentRightX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBAlignmentLeftXCurrent
        '
        Me.LblBAlignmentLeftXCurrent.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentLeftXCurrent.BDrawBorderBottom = True
        Me.LblBAlignmentLeftXCurrent.BDrawBorderLeft = False
        Me.LblBAlignmentLeftXCurrent.BDrawBorderRight = True
        Me.LblBAlignmentLeftXCurrent.BDrawBorderTop = False
        Me.LblBAlignmentLeftXCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentLeftXCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentLeftXCurrent.Location = New System.Drawing.Point(320, 158)
        Me.LblBAlignmentLeftXCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentLeftXCurrent.Name = "LblBAlignmentLeftXCurrent"
        Me.LblBAlignmentLeftXCurrent.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentLeftXCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentLeftXCurrent.TabIndex = 13
        Me.LblBAlignmentLeftXCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBAlignmentLeftXTarget
        '
        Me.LblBAlignmentLeftXTarget.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentLeftXTarget.BDrawBorderBottom = True
        Me.LblBAlignmentLeftXTarget.BDrawBorderLeft = False
        Me.LblBAlignmentLeftXTarget.BDrawBorderRight = True
        Me.LblBAlignmentLeftXTarget.BDrawBorderTop = False
        Me.LblBAlignmentLeftXTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentLeftXTarget.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentLeftXTarget.Location = New System.Drawing.Point(160, 158)
        Me.LblBAlignmentLeftXTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentLeftXTarget.Name = "LblBAlignmentLeftXTarget"
        Me.LblBAlignmentLeftXTarget.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentLeftXTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentLeftXTarget.TabIndex = 12
        Me.LblBAlignmentLeftXTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentLeftXCurrent
        '
        Me.LblAAlignmentLeftXCurrent.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentLeftXCurrent.BDrawBorderBottom = True
        Me.LblAAlignmentLeftXCurrent.BDrawBorderLeft = False
        Me.LblAAlignmentLeftXCurrent.BDrawBorderRight = True
        Me.LblAAlignmentLeftXCurrent.BDrawBorderTop = False
        Me.LblAAlignmentLeftXCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentLeftXCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentLeftXCurrent.Location = New System.Drawing.Point(320, 53)
        Me.LblAAlignmentLeftXCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentLeftXCurrent.Name = "LblAAlignmentLeftXCurrent"
        Me.LblAAlignmentLeftXCurrent.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentLeftXCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentLeftXCurrent.TabIndex = 4
        Me.LblAAlignmentLeftXCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentLeftXTarget
        '
        Me.LblAAlignmentLeftXTarget.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentLeftXTarget.BDrawBorderBottom = True
        Me.LblAAlignmentLeftXTarget.BDrawBorderLeft = False
        Me.LblAAlignmentLeftXTarget.BDrawBorderRight = True
        Me.LblAAlignmentLeftXTarget.BDrawBorderTop = False
        Me.LblAAlignmentLeftXTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentLeftXTarget.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentLeftXTarget.Location = New System.Drawing.Point(160, 53)
        Me.LblAAlignmentLeftXTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentLeftXTarget.Name = "LblAAlignmentLeftXTarget"
        Me.LblAAlignmentLeftXTarget.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentLeftXTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentLeftXTarget.TabIndex = 4
        Me.LblAAlignmentLeftXTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitleAAlignmentT
        '
        Me.LblTitleAAlignmentT.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentT.BDrawBorderBottom = True
        Me.LblTitleAAlignmentT.BDrawBorderLeft = True
        Me.LblTitleAAlignmentT.BDrawBorderRight = True
        Me.LblTitleAAlignmentT.BDrawBorderTop = False
        Me.LblTitleAAlignmentT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentT.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentT.Location = New System.Drawing.Point(0, 132)
        Me.LblTitleAAlignmentT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAAlignmentT.Name = "LblTitleAAlignmentT"
        Me.LblTitleAAlignmentT.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentT.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAAlignmentT.TabIndex = 4
        Me.LblTitleAAlignmentT.Text = "#1 T"
        Me.LblTitleAAlignmentT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBAlignmentT
        '
        Me.LblTitleBAlignmentT.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentT.BDrawBorderBottom = True
        Me.LblTitleBAlignmentT.BDrawBorderLeft = True
        Me.LblTitleBAlignmentT.BDrawBorderRight = True
        Me.LblTitleBAlignmentT.BDrawBorderTop = False
        Me.LblTitleBAlignmentT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentT.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentT.Location = New System.Drawing.Point(0, 237)
        Me.LblTitleBAlignmentT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBAlignmentT.Name = "LblTitleBAlignmentT"
        Me.LblTitleBAlignmentT.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentT.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleBAlignmentT.TabIndex = 17
        Me.LblTitleBAlignmentT.Text = "#2 T"
        Me.LblTitleBAlignmentT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAAlignmentY
        '
        Me.LblTitleAAlignmentY.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentY.BDrawBorderBottom = True
        Me.LblTitleAAlignmentY.BDrawBorderLeft = True
        Me.LblTitleAAlignmentY.BDrawBorderRight = True
        Me.LblTitleAAlignmentY.BDrawBorderTop = False
        Me.LblTitleAAlignmentY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentY.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentY.Location = New System.Drawing.Point(0, 105)
        Me.LblTitleAAlignmentY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAAlignmentY.Name = "LblTitleAAlignmentY"
        Me.LblTitleAAlignmentY.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentY.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAAlignmentY.TabIndex = 4
        Me.LblTitleAAlignmentY.Text = "#1 Y"
        Me.LblTitleAAlignmentY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBAlignmentY
        '
        Me.LblTitleBAlignmentY.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentY.BDrawBorderBottom = True
        Me.LblTitleBAlignmentY.BDrawBorderLeft = True
        Me.LblTitleBAlignmentY.BDrawBorderRight = True
        Me.LblTitleBAlignmentY.BDrawBorderTop = False
        Me.LblTitleBAlignmentY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentY.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentY.Location = New System.Drawing.Point(0, 210)
        Me.LblTitleBAlignmentY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBAlignmentY.Name = "LblTitleBAlignmentY"
        Me.LblTitleBAlignmentY.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentY.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleBAlignmentY.TabIndex = 16
        Me.LblTitleBAlignmentY.Text = "#2 Y"
        Me.LblTitleBAlignmentY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBAlignmentRightX
        '
        Me.LblTitleBAlignmentRightX.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentRightX.BDrawBorderBottom = True
        Me.LblTitleBAlignmentRightX.BDrawBorderLeft = True
        Me.LblTitleBAlignmentRightX.BDrawBorderRight = True
        Me.LblTitleBAlignmentRightX.BDrawBorderTop = False
        Me.LblTitleBAlignmentRightX.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentRightX.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentRightX.Location = New System.Drawing.Point(0, 183)
        Me.LblTitleBAlignmentRightX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleBAlignmentRightX.Name = "LblTitleBAlignmentRightX"
        Me.LblTitleBAlignmentRightX.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentRightX.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleBAlignmentRightX.TabIndex = 19
        Me.LblTitleBAlignmentRightX.Text = "#2 XR"
        Me.LblTitleBAlignmentRightX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAlignmentCurrent
        '
        Me.LblTitleAlignmentCurrent.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAlignmentCurrent.BDrawBorderBottom = True
        Me.LblTitleAlignmentCurrent.BDrawBorderLeft = False
        Me.LblTitleAlignmentCurrent.BDrawBorderRight = False
        Me.LblTitleAlignmentCurrent.BDrawBorderTop = False
        Me.LblTitleAlignmentCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAlignmentCurrent.ForeColor = System.Drawing.Color.White
        Me.LblTitleAlignmentCurrent.Location = New System.Drawing.Point(320, 27)
        Me.LblTitleAlignmentCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAlignmentCurrent.Name = "LblTitleAlignmentCurrent"
        Me.LblTitleAlignmentCurrent.OColor = System.Drawing.Color.Black
        Me.LblTitleAlignmentCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAlignmentCurrent.TabIndex = 4
        Me.LblTitleAlignmentCurrent.Text = "Current"
        Me.LblTitleAlignmentCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBAlignmentTCurrent
        '
        Me.LblBAlignmentTCurrent.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentTCurrent.BDrawBorderBottom = True
        Me.LblBAlignmentTCurrent.BDrawBorderLeft = False
        Me.LblBAlignmentTCurrent.BDrawBorderRight = True
        Me.LblBAlignmentTCurrent.BDrawBorderTop = False
        Me.LblBAlignmentTCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentTCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentTCurrent.Location = New System.Drawing.Point(320, 237)
        Me.LblBAlignmentTCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentTCurrent.Name = "LblBAlignmentTCurrent"
        Me.LblBAlignmentTCurrent.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentTCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentTCurrent.TabIndex = 15
        Me.LblBAlignmentTCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentTCurrent
        '
        Me.LblAAlignmentTCurrent.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentTCurrent.BDrawBorderBottom = True
        Me.LblAAlignmentTCurrent.BDrawBorderLeft = False
        Me.LblAAlignmentTCurrent.BDrawBorderRight = True
        Me.LblAAlignmentTCurrent.BDrawBorderTop = False
        Me.LblAAlignmentTCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentTCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentTCurrent.Location = New System.Drawing.Point(320, 132)
        Me.LblAAlignmentTCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentTCurrent.Name = "LblAAlignmentTCurrent"
        Me.LblAAlignmentTCurrent.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentTCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentTCurrent.TabIndex = 4
        Me.LblAAlignmentTCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBAlignmentTTarget
        '
        Me.LblBAlignmentTTarget.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentTTarget.BDrawBorderBottom = True
        Me.LblBAlignmentTTarget.BDrawBorderLeft = False
        Me.LblBAlignmentTTarget.BDrawBorderRight = True
        Me.LblBAlignmentTTarget.BDrawBorderTop = False
        Me.LblBAlignmentTTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentTTarget.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentTTarget.Location = New System.Drawing.Point(160, 237)
        Me.LblBAlignmentTTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentTTarget.Name = "LblBAlignmentTTarget"
        Me.LblBAlignmentTTarget.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentTTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentTTarget.TabIndex = 10
        Me.LblBAlignmentTTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentTTarget
        '
        Me.LblAAlignmentTTarget.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentTTarget.BDrawBorderBottom = True
        Me.LblAAlignmentTTarget.BDrawBorderLeft = False
        Me.LblAAlignmentTTarget.BDrawBorderRight = True
        Me.LblAAlignmentTTarget.BDrawBorderTop = False
        Me.LblAAlignmentTTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentTTarget.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentTTarget.Location = New System.Drawing.Point(160, 132)
        Me.LblAAlignmentTTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentTTarget.Name = "LblAAlignmentTTarget"
        Me.LblAAlignmentTTarget.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentTTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentTTarget.TabIndex = 4
        Me.LblAAlignmentTTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBAlignmentYCurrent
        '
        Me.LblBAlignmentYCurrent.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentYCurrent.BDrawBorderBottom = True
        Me.LblBAlignmentYCurrent.BDrawBorderLeft = False
        Me.LblBAlignmentYCurrent.BDrawBorderRight = True
        Me.LblBAlignmentYCurrent.BDrawBorderTop = False
        Me.LblBAlignmentYCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentYCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentYCurrent.Location = New System.Drawing.Point(320, 210)
        Me.LblBAlignmentYCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentYCurrent.Name = "LblBAlignmentYCurrent"
        Me.LblBAlignmentYCurrent.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentYCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentYCurrent.TabIndex = 9
        Me.LblBAlignmentYCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentYCurrent
        '
        Me.LblAAlignmentYCurrent.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentYCurrent.BDrawBorderBottom = True
        Me.LblAAlignmentYCurrent.BDrawBorderLeft = False
        Me.LblAAlignmentYCurrent.BDrawBorderRight = True
        Me.LblAAlignmentYCurrent.BDrawBorderTop = False
        Me.LblAAlignmentYCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentYCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentYCurrent.Location = New System.Drawing.Point(320, 105)
        Me.LblAAlignmentYCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentYCurrent.Name = "LblAAlignmentYCurrent"
        Me.LblAAlignmentYCurrent.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentYCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentYCurrent.TabIndex = 4
        Me.LblAAlignmentYCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBAlignmentYTarget
        '
        Me.LblBAlignmentYTarget.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentYTarget.BDrawBorderBottom = True
        Me.LblBAlignmentYTarget.BDrawBorderLeft = False
        Me.LblBAlignmentYTarget.BDrawBorderRight = True
        Me.LblBAlignmentYTarget.BDrawBorderTop = False
        Me.LblBAlignmentYTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentYTarget.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentYTarget.Location = New System.Drawing.Point(160, 210)
        Me.LblBAlignmentYTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentYTarget.Name = "LblBAlignmentYTarget"
        Me.LblBAlignmentYTarget.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentYTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentYTarget.TabIndex = 8
        Me.LblBAlignmentYTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentYTarget
        '
        Me.LblAAlignmentYTarget.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentYTarget.BDrawBorderBottom = True
        Me.LblAAlignmentYTarget.BDrawBorderLeft = False
        Me.LblAAlignmentYTarget.BDrawBorderRight = True
        Me.LblAAlignmentYTarget.BDrawBorderTop = False
        Me.LblAAlignmentYTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentYTarget.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentYTarget.Location = New System.Drawing.Point(160, 105)
        Me.LblAAlignmentYTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentYTarget.Name = "LblAAlignmentYTarget"
        Me.LblAAlignmentYTarget.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentYTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentYTarget.TabIndex = 4
        Me.LblAAlignmentYTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBAlignmentRightXCurrent
        '
        Me.LblBAlignmentRightXCurrent.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentRightXCurrent.BDrawBorderBottom = True
        Me.LblBAlignmentRightXCurrent.BDrawBorderLeft = False
        Me.LblBAlignmentRightXCurrent.BDrawBorderRight = True
        Me.LblBAlignmentRightXCurrent.BDrawBorderTop = False
        Me.LblBAlignmentRightXCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentRightXCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentRightXCurrent.Location = New System.Drawing.Point(320, 183)
        Me.LblBAlignmentRightXCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentRightXCurrent.Name = "LblBAlignmentRightXCurrent"
        Me.LblBAlignmentRightXCurrent.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentRightXCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentRightXCurrent.TabIndex = 11
        Me.LblBAlignmentRightXCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentRightXCurrent
        '
        Me.LblAAlignmentRightXCurrent.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentRightXCurrent.BDrawBorderBottom = True
        Me.LblAAlignmentRightXCurrent.BDrawBorderLeft = False
        Me.LblAAlignmentRightXCurrent.BDrawBorderRight = True
        Me.LblAAlignmentRightXCurrent.BDrawBorderTop = False
        Me.LblAAlignmentRightXCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentRightXCurrent.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentRightXCurrent.Location = New System.Drawing.Point(320, 78)
        Me.LblAAlignmentRightXCurrent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentRightXCurrent.Name = "LblAAlignmentRightXCurrent"
        Me.LblAAlignmentRightXCurrent.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentRightXCurrent.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentRightXCurrent.TabIndex = 4
        Me.LblAAlignmentRightXCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBAlignmentRightXTarget
        '
        Me.LblBAlignmentRightXTarget.BackColor = System.Drawing.Color.White
        Me.LblBAlignmentRightXTarget.BDrawBorderBottom = True
        Me.LblBAlignmentRightXTarget.BDrawBorderLeft = False
        Me.LblBAlignmentRightXTarget.BDrawBorderRight = True
        Me.LblBAlignmentRightXTarget.BDrawBorderTop = False
        Me.LblBAlignmentRightXTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblBAlignmentRightXTarget.ForeColor = System.Drawing.Color.Black
        Me.LblBAlignmentRightXTarget.Location = New System.Drawing.Point(160, 183)
        Me.LblBAlignmentRightXTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblBAlignmentRightXTarget.Name = "LblBAlignmentRightXTarget"
        Me.LblBAlignmentRightXTarget.OColor = System.Drawing.Color.Black
        Me.LblBAlignmentRightXTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblBAlignmentRightXTarget.TabIndex = 14
        Me.LblBAlignmentRightXTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblAAlignmentRightXTarget
        '
        Me.LblAAlignmentRightXTarget.BackColor = System.Drawing.Color.White
        Me.LblAAlignmentRightXTarget.BDrawBorderBottom = True
        Me.LblAAlignmentRightXTarget.BDrawBorderLeft = False
        Me.LblAAlignmentRightXTarget.BDrawBorderRight = True
        Me.LblAAlignmentRightXTarget.BDrawBorderTop = False
        Me.LblAAlignmentRightXTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.LblAAlignmentRightXTarget.ForeColor = System.Drawing.Color.Black
        Me.LblAAlignmentRightXTarget.Location = New System.Drawing.Point(160, 78)
        Me.LblAAlignmentRightXTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblAAlignmentRightXTarget.Name = "LblAAlignmentRightXTarget"
        Me.LblAAlignmentRightXTarget.OColor = System.Drawing.Color.Black
        Me.LblAAlignmentRightXTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblAAlignmentRightXTarget.TabIndex = 4
        Me.LblAAlignmentRightXTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTitleAlignmentTarget
        '
        Me.LblTitleAlignmentTarget.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAlignmentTarget.BDrawBorderBottom = True
        Me.LblTitleAlignmentTarget.BDrawBorderLeft = False
        Me.LblTitleAlignmentTarget.BDrawBorderRight = True
        Me.LblTitleAlignmentTarget.BDrawBorderTop = False
        Me.LblTitleAlignmentTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAlignmentTarget.ForeColor = System.Drawing.Color.White
        Me.LblTitleAlignmentTarget.Location = New System.Drawing.Point(160, 27)
        Me.LblTitleAlignmentTarget.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAlignmentTarget.Name = "LblTitleAlignmentTarget"
        Me.LblTitleAlignmentTarget.OColor = System.Drawing.Color.Black
        Me.LblTitleAlignmentTarget.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAlignmentTarget.TabIndex = 4
        Me.LblTitleAlignmentTarget.Text = "Target"
        Me.LblTitleAlignmentTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAlignmentBlank
        '
        Me.LblTitleAlignmentBlank.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAlignmentBlank.BDrawBorderBottom = True
        Me.LblTitleAlignmentBlank.BDrawBorderLeft = True
        Me.LblTitleAlignmentBlank.BDrawBorderRight = True
        Me.LblTitleAlignmentBlank.BDrawBorderTop = False
        Me.LblTitleAlignmentBlank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAlignmentBlank.ForeColor = System.Drawing.Color.White
        Me.LblTitleAlignmentBlank.Location = New System.Drawing.Point(0, 27)
        Me.LblTitleAlignmentBlank.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAlignmentBlank.Name = "LblTitleAlignmentBlank"
        Me.LblTitleAlignmentBlank.OColor = System.Drawing.Color.Black
        Me.LblTitleAlignmentBlank.Size = New System.Drawing.Size(160, 27)
        Me.LblTitleAlignmentBlank.TabIndex = 4
        Me.LblTitleAlignmentBlank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAlignment
        '
        Me.LblTitleAlignment.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAlignment.BDrawBorderBottom = True
        Me.LblTitleAlignment.BDrawBorderLeft = True
        Me.LblTitleAlignment.BDrawBorderRight = False
        Me.LblTitleAlignment.BDrawBorderTop = False
        Me.LblTitleAlignment.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleAlignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAlignment.ForeColor = System.Drawing.Color.White
        Me.LblTitleAlignment.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleAlignment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleAlignment.Name = "LblTitleAlignment"
        Me.LblTitleAlignment.OColor = System.Drawing.Color.Black
        Me.LblTitleAlignment.Size = New System.Drawing.Size(480, 27)
        Me.LblTitleAlignment.TabIndex = 3
        Me.LblTitleAlignment.Text = "Alignment"
        Me.LblTitleAlignment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlButtom
        '
        Me.PnlButtom.BDrawBorderBottom = False
        Me.PnlButtom.BDrawBorderLeft = False
        Me.PnlButtom.BDrawBorderRight = False
        Me.PnlButtom.BDrawBorderTop = True
        Me.PnlButtom.Controls.Add(Me.BtnMoveBStage)
        Me.PnlButtom.Controls.Add(Me.BtnMoveAStage)
        Me.PnlButtom.Controls.Add(Me.BtnBManualRun)
        Me.PnlButtom.Controls.Add(Me.BtnAManualRun)
        Me.PnlButtom.Controls.Add(Me.BtnBManualShow)
        Me.PnlButtom.Controls.Add(Me.BtnAManualShow)
        Me.PnlButtom.Controls.Add(Me.BtnWheel)
        Me.PnlButtom.Controls.Add(Me.BtnStop)
        Me.PnlButtom.Controls.Add(Me.BtnStart)
        Me.PnlButtom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButtom.Location = New System.Drawing.Point(0, 1014)
        Me.PnlButtom.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlButtom.Name = "PnlButtom"
        Me.PnlButtom.Size = New System.Drawing.Size(1707, 58)
        Me.PnlButtom.TabIndex = 5
        '
        'BtnMoveBStage
        '
        Me.BtnMoveBStage.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnMoveBStage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveBStage.ForeColor = System.Drawing.Color.White
        Me.BtnMoveBStage.Location = New System.Drawing.Point(1448, 2)
        Me.BtnMoveBStage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnMoveBStage.Name = "BtnMoveBStage"
        Me.BtnMoveBStage.Size = New System.Drawing.Size(180, 47)
        Me.BtnMoveBStage.TabIndex = 20
        Me.BtnMoveBStage.Text = "#2 Up"
        Me.BtnMoveBStage.UseVisualStyleBackColor = False
        '
        'BtnMoveAStage
        '
        Me.BtnMoveAStage.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnMoveAStage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveAStage.ForeColor = System.Drawing.Color.White
        Me.BtnMoveAStage.Location = New System.Drawing.Point(907, 2)
        Me.BtnMoveAStage.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnMoveAStage.Name = "BtnMoveAStage"
        Me.BtnMoveAStage.Size = New System.Drawing.Size(180, 47)
        Me.BtnMoveAStage.TabIndex = 19
        Me.BtnMoveAStage.Text = "#1 Up"
        Me.BtnMoveAStage.UseVisualStyleBackColor = False
        Me.BtnMoveAStage.Visible = False
        '
        'BtnBManualRun
        '
        Me.BtnBManualRun.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnBManualRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBManualRun.ForeColor = System.Drawing.Color.White
        Me.BtnBManualRun.Location = New System.Drawing.Point(1268, 2)
        Me.BtnBManualRun.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBManualRun.Name = "BtnBManualRun"
        Me.BtnBManualRun.Size = New System.Drawing.Size(180, 47)
        Me.BtnBManualRun.TabIndex = 18
        Me.BtnBManualRun.Text = "#2 Man. Run"
        Me.BtnBManualRun.UseVisualStyleBackColor = False
        '
        'BtnAManualRun
        '
        Me.BtnAManualRun.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnAManualRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAManualRun.ForeColor = System.Drawing.Color.White
        Me.BtnAManualRun.Location = New System.Drawing.Point(725, 2)
        Me.BtnAManualRun.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnAManualRun.Name = "BtnAManualRun"
        Me.BtnAManualRun.Size = New System.Drawing.Size(180, 47)
        Me.BtnAManualRun.TabIndex = 17
        Me.BtnAManualRun.Text = "#1 Man. Run"
        Me.BtnAManualRun.UseVisualStyleBackColor = False
        '
        'BtnBManualShow
        '
        Me.BtnBManualShow.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnBManualShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBManualShow.ForeColor = System.Drawing.Color.White
        Me.BtnBManualShow.Location = New System.Drawing.Point(1087, 2)
        Me.BtnBManualShow.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnBManualShow.Name = "BtnBManualShow"
        Me.BtnBManualShow.Size = New System.Drawing.Size(180, 47)
        Me.BtnBManualShow.TabIndex = 16
        Me.BtnBManualShow.Text = "#2 Man. On"
        Me.BtnBManualShow.UseVisualStyleBackColor = False
        '
        'BtnAManualShow
        '
        Me.BtnAManualShow.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnAManualShow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAManualShow.ForeColor = System.Drawing.Color.White
        Me.BtnAManualShow.Location = New System.Drawing.Point(545, 2)
        Me.BtnAManualShow.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnAManualShow.Name = "BtnAManualShow"
        Me.BtnAManualShow.Size = New System.Drawing.Size(180, 47)
        Me.BtnAManualShow.TabIndex = 15
        Me.BtnAManualShow.Text = "#1 Man. On"
        Me.BtnAManualShow.UseVisualStyleBackColor = False
        '
        'BtnWheel
        '
        Me.BtnWheel.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnWheel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWheel.ForeColor = System.Drawing.Color.White
        Me.BtnWheel.Location = New System.Drawing.Point(364, 2)
        Me.BtnWheel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnWheel.Name = "BtnWheel"
        Me.BtnWheel.Size = New System.Drawing.Size(180, 47)
        Me.BtnWheel.TabIndex = 6
        Me.BtnWheel.Text = "CL ON"
        Me.BtnWheel.UseVisualStyleBackColor = False
        '
        'BtnStop
        '
        Me.BtnStop.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.ForeColor = System.Drawing.Color.White
        Me.BtnStop.Location = New System.Drawing.Point(184, 2)
        Me.BtnStop.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(180, 47)
        Me.BtnStop.TabIndex = 6
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = False
        '
        'BtnStart
        '
        Me.BtnStart.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.Color.White
        Me.BtnStart.Location = New System.Drawing.Point(4, 2)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(180, 47)
        Me.BtnStart.TabIndex = 6
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = False
        '
        'PnlTitle
        '
        Me.PnlTitle.BDrawBorderBottom = False
        Me.PnlTitle.BDrawBorderLeft = False
        Me.PnlTitle.BDrawBorderRight = False
        Me.PnlTitle.BDrawBorderTop = False
        Me.PnlTitle.Controls.Add(Me.LblTitle)
        Me.PnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitle.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlTitle.Name = "PnlTitle"
        Me.PnlTitle.Size = New System.Drawing.Size(1707, 46)
        Me.PnlTitle.TabIndex = 4
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.DarkSlateGray
        Me.LblTitle.BDrawBorderBottom = True
        Me.LblTitle.BDrawBorderLeft = False
        Me.LblTitle.BDrawBorderRight = False
        Me.LblTitle.BDrawBorderTop = False
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitle.ForeColor = System.Drawing.Color.White
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.OColor = System.Drawing.Color.Black
        Me.LblTitle.Size = New System.Drawing.Size(1707, 46)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Alignment"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudDistX
        '
        Me.NudDistX.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NudDistX.Location = New System.Drawing.Point(137, 557)
        Me.NudDistX.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.NudDistX.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.NudDistX.Name = "NudDistX"
        Me.NudDistX.Size = New System.Drawing.Size(95, 26)
        Me.NudDistX.TabIndex = 7
        Me.NudDistX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleID
        '
        Me.LblTitleID.BackColor = System.Drawing.Color.SeaGreen
        Me.LblTitleID.BDrawBorderBottom = True
        Me.LblTitleID.BDrawBorderLeft = True
        Me.LblTitleID.BDrawBorderRight = True
        Me.LblTitleID.BDrawBorderTop = False
        Me.LblTitleID.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTitleID.ForeColor = System.Drawing.Color.White
        Me.LblTitleID.Location = New System.Drawing.Point(6, 557)
        Me.LblTitleID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitleID.Name = "LblTitleID"
        Me.LblTitleID.OColor = System.Drawing.Color.Black
        Me.LblTitleID.Size = New System.Drawing.Size(126, 27)
        Me.LblTitleID.TabIndex = 8
        Me.LblTitleID.Text = "Min Dist. X"
        Me.LblTitleID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudDistY
        '
        Me.NudDistY.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NudDistY.Location = New System.Drawing.Point(384, 557)
        Me.NudDistY.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.NudDistY.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.NudDistY.Name = "NudDistY"
        Me.NudDistY.Size = New System.Drawing.Size(95, 26)
        Me.NudDistY.TabIndex = 9
        Me.NudDistY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CLabel2
        '
        Me.CLabel2.BackColor = System.Drawing.Color.SeaGreen
        Me.CLabel2.BDrawBorderBottom = True
        Me.CLabel2.BDrawBorderLeft = True
        Me.CLabel2.BDrawBorderRight = True
        Me.CLabel2.BDrawBorderTop = False
        Me.CLabel2.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CLabel2.ForeColor = System.Drawing.Color.White
        Me.CLabel2.Location = New System.Drawing.Point(253, 557)
        Me.CLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CLabel2.Name = "CLabel2"
        Me.CLabel2.OColor = System.Drawing.Color.Black
        Me.CLabel2.Size = New System.Drawing.Size(126, 27)
        Me.CLabel2.TabIndex = 10
        Me.CLabel2.Text = "Min Dist. Y"
        Me.CLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcAlignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlLeft)
        Me.Controls.Add(Me.PnlRight)
        Me.Controls.Add(Me.PnlButtom)
        Me.Controls.Add(Me.PnlTitle)
        Me.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Name = "UcAlignment"
        Me.PnlLeft.ResumeLayout(False)
        Me.PnlBImage.ResumeLayout(False)
        Me.PnlBRight.ResumeLayout(False)
        CType(Me.CdpBRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBRightBar.ResumeLayout(False)
        Me.PnlBRightStatusBar.ResumeLayout(False)
        Me.PnlBRightToolBar.ResumeLayout(False)
        Me.PnlBLeft.ResumeLayout(False)
        CType(Me.CdpBLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBLeftBar.ResumeLayout(False)
        Me.PnlBLeftStatusBar.ResumeLayout(False)
        Me.PnlBLeftToolBar.ResumeLayout(False)
        Me.PnlAImage.ResumeLayout(False)
        Me.PnlARight.ResumeLayout(False)
        CType(Me.CdpARight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlARightBar.ResumeLayout(False)
        Me.PnlARightStatusBar.ResumeLayout(False)
        Me.PnlARightToolBar.ResumeLayout(False)
        Me.PnlALeft.ResumeLayout(False)
        CType(Me.CdpALeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlALeftBar.ResumeLayout(False)
        Me.PnlALeftStatusBar.ResumeLayout(False)
        Me.PnlALeftToolBar.ResumeLayout(False)
        Me.PnlRight.ResumeLayout(False)
        Me.PnlMessage.ResumeLayout(False)
        Me.PnlEdge.ResumeLayout(False)
        Me.PnlAlignment.ResumeLayout(False)
        Me.PnlButtom.ResumeLayout(False)
        Me.PnlTitle.ResumeLayout(False)
        CType(Me.NudDistX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudDistY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents PnlButtom As Jhjo.Component.CPanel
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents BtnStop As System.Windows.Forms.Button
    Friend WithEvents PnlLeft As Jhjo.Component.CPanel
    Friend WithEvents PnlBImage As System.Windows.Forms.Panel
    Friend WithEvents PnlAImage As System.Windows.Forms.Panel
    Friend WithEvents PnlALeft As Jhjo.Component.CPanel
    Friend WithEvents CdsALeft As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents BtnALeftShowChecker As System.Windows.Forms.Button
    Friend WithEvents BtnALeftClearChecker As System.Windows.Forms.Button
    Friend WithEvents LblTitleALeftImage As Jhjo.Component.CLabel
    Friend WithEvents PnlALeftBar As Jhjo.Component.CPanel
    Friend WithEvents PnlALeftToolBar As Jhjo.Component.CPanel
    Friend WithEvents CdtALeft As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents PnlALeftStatusBar As Jhjo.Component.CPanel
    Friend WithEvents CdpALeft As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents PnlBRight As Jhjo.Component.CPanel
    Friend WithEvents CdpBRight As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents PnlBRightBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBRightStatusBar As Jhjo.Component.CPanel
    Friend WithEvents CdsBRight As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents PnlBRightToolBar As Jhjo.Component.CPanel
    Friend WithEvents BtnBRightClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnBRightShowChecker As System.Windows.Forms.Button
    Friend WithEvents CdtBRight As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents LblTitleBRightImage As Jhjo.Component.CLabel
    Friend WithEvents PnlBLeft As Jhjo.Component.CPanel
    Friend WithEvents CdpBLeft As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents PnlBLeftBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBLeftStatusBar As Jhjo.Component.CPanel
    Friend WithEvents CdsBLeft As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents PnlBLeftToolBar As Jhjo.Component.CPanel
    Friend WithEvents BtnBLeftClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnBLeftShowChecker As System.Windows.Forms.Button
    Friend WithEvents CdtBLeft As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents LblTitleBLeftImage As Jhjo.Component.CLabel
    Friend WithEvents PnlARight As Jhjo.Component.CPanel
    Friend WithEvents CdpARight As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents PnlARightBar As Jhjo.Component.CPanel
    Friend WithEvents PnlARightStatusBar As Jhjo.Component.CPanel
    Friend WithEvents CdsARight As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents PnlARightToolBar As Jhjo.Component.CPanel
    Friend WithEvents BtnARightClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnARightShowChecker As System.Windows.Forms.Button
    Friend WithEvents CdtARight As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents LblTitleARightImage As Jhjo.Component.CLabel
    Friend WithEvents PnlRight As Jhjo.Component.CPanel
    Friend WithEvents PnlEdge As Jhjo.Component.CPanel
    Friend WithEvents PnlAlignment As Jhjo.Component.CPanel
    Friend WithEvents LblTitleAlignment As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentY As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentRightX As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentLeftX As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAlignmentBlank As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeTop As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentT As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAlignmentCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAlignmentTarget As Jhjo.Component.CLabel
    Friend WithEvents LblAEdgeTopLeft As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentTTarget As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentYTarget As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentRightXTarget As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentLeftXTarget As Jhjo.Component.CLabel
    Friend WithEvents LblAEdgeTopRight As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentTCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentYCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentRightXCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblAAlignmentLeftXCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblTitleEdgeRight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleEdgeLeft As Jhjo.Component.CLabel
    Friend WithEvents LblTitleEdgeBlank As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeTop As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentT As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentY As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentRightX As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentLeftX As Jhjo.Component.CLabel
    Friend WithEvents LblBEdgeTopRight As Jhjo.Component.CLabel
    Friend WithEvents LblBEdgeTopLeft As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentTCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentTTarget As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentYCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentYTarget As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentRightXCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentRightXTarget As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentLeftXCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblBAlignmentLeftXTarget As Jhjo.Component.CLabel
    Friend WithEvents LblTitleEdge As Jhjo.Component.CLabel
    Friend WithEvents PnlMessage As Jhjo.Component.CPanel
    Friend WithEvents LblTitleMessage As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeBottom As Jhjo.Component.CLabel
    Friend WithEvents LblAEdgeBottomRight As Jhjo.Component.CLabel
    Friend WithEvents LblAEdgeBottomLeft As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeBottom As Jhjo.Component.CLabel
    Friend WithEvents LblBEdgeBottomRight As Jhjo.Component.CLabel
    Friend WithEvents LblBEdgeBottomLeft As Jhjo.Component.CLabel
    Friend WithEvents LtbMessage As System.Windows.Forms.ListBox
    Friend WithEvents BtnWheel As System.Windows.Forms.Button
    Friend WithEvents BtnBManualRun As System.Windows.Forms.Button
    Friend WithEvents BtnAManualRun As System.Windows.Forms.Button
    Friend WithEvents BtnBManualShow As System.Windows.Forms.Button
    Friend WithEvents BtnAManualShow As System.Windows.Forms.Button
    Friend WithEvents BtnMoveAStage As System.Windows.Forms.Button
    Friend WithEvents BtnMoveBStage As System.Windows.Forms.Button
    Friend WithEvents LblBRightScore As Jhjo.Component.CLabel
    Friend WithEvents LblBLeftScore As Jhjo.Component.CLabel
    Friend WithEvents LblARightScore As Jhjo.Component.CLabel
    Friend WithEvents LblScore As Jhjo.Component.CLabel
    Friend WithEvents LblALeftScore As Jhjo.Component.CLabel
    Friend WithEvents LblSummary As Jhjo.Component.CLabel
    Friend WithEvents CLabel7 As Jhjo.Component.CLabel
    Friend WithEvents CLabel4 As Jhjo.Component.CLabel
    Friend WithEvents CLabel8 As Jhjo.Component.CLabel
    Friend WithEvents LblBStageTotalTimeElapsed As Jhjo.Component.CLabel
    Friend WithEvents LblMaxRetries As Jhjo.Component.CLabel
    Friend WithEvents LblAStageTotalTimeElapsed As Jhjo.Component.CLabel
    Friend WithEvents CLabel1 As Jhjo.Component.CLabel
    Friend WithEvents LblBStageTotalRetry As Jhjo.Component.CLabel
    Friend WithEvents LblAStageTotalRetry As Jhjo.Component.CLabel
    Friend WithEvents NudDistY As NumericUpDown
    Friend WithEvents CLabel2 As Jhjo.Component.CLabel
    Friend WithEvents NudDistX As NumericUpDown
    Friend WithEvents LblTitleID As Jhjo.Component.CLabel
End Class
