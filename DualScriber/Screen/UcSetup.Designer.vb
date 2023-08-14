<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcSetup))
        Me.PnlTitle = New Jhjo.Component.CPanel()
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.PnlRight = New Jhjo.Component.CPanel()
        Me.PnlCamera = New Jhjo.Component.CPanel()
        Me.LblMaxRetry = New Jhjo.Component.CLabel()
        Me.LblTitleAlignmentOption = New Jhjo.Component.CLabel()
        Me.NudExpoTime = New System.Windows.Forms.NumericUpDown()
        Me.NudMaxRetry = New System.Windows.Forms.NumericUpDown()
        Me.NudGain = New System.Windows.Forms.NumericUpDown()
        Me.CmbCamera = New System.Windows.Forms.ComboBox()
        Me.LblTitleExpoTime = New Jhjo.Component.CLabel()
        Me.BtnApplyAlignment = New System.Windows.Forms.Button()
        Me.BtnApplyCamera = New System.Windows.Forms.Button()
        Me.LblTitleGain = New Jhjo.Component.CLabel()
        Me.LblTitleCamera = New Jhjo.Component.CLabel()
        Me.LblTitleCameraOption = New Jhjo.Component.CLabel()
        Me.CPanel2 = New Jhjo.Component.CPanel()
        Me.CmbROIView = New System.Windows.Forms.ComboBox()
        Me.ChkROIKind = New System.Windows.Forms.CheckBox()
        Me.NudROIHeight = New System.Windows.Forms.NumericUpDown()
        Me.NudROIWidth = New System.Windows.Forms.NumericUpDown()
        Me.LblTitleROIHeight = New Jhjo.Component.CLabel()
        Me.LblTitleROICamera = New Jhjo.Component.CLabel()
        Me.LblTitleROIKind = New Jhjo.Component.CLabel()
        Me.LblTitleROIWidth = New Jhjo.Component.CLabel()
        Me.BtnROICenter = New System.Windows.Forms.Button()
        Me.BtnROIGoBack = New System.Windows.Forms.Button()
        Me.BtnROIApply = New System.Windows.Forms.Button()
        Me.BtnROIShape = New System.Windows.Forms.Button()
        Me.LblTitleAlignmentROI = New Jhjo.Component.CLabel()
        Me.CPanel1 = New Jhjo.Component.CPanel()
        Me.NudBPointT = New System.Windows.Forms.NumericUpDown()
        Me.NudBPointXY = New System.Windows.Forms.NumericUpDown()
        Me.NudAPointT = New System.Windows.Forms.NumericUpDown()
        Me.NudBSectionT = New System.Windows.Forms.NumericUpDown()
        Me.BtnApplyCalibInfo = New System.Windows.Forms.Button()
        Me.NudBSectionXY = New System.Windows.Forms.NumericUpDown()
        Me.NudASectionT = New System.Windows.Forms.NumericUpDown()
        Me.NudAPointXY = New System.Windows.Forms.NumericUpDown()
        Me.NudASectionXY = New System.Windows.Forms.NumericUpDown()
        Me.LblTitlePoint = New Jhjo.Component.CLabel()
        Me.LblTitleSection = New Jhjo.Component.CLabel()
        Me.LblTitleBT = New Jhjo.Component.CLabel()
        Me.LblTitleBXY = New Jhjo.Component.CLabel()
        Me.LblTitleAT = New Jhjo.Component.CLabel()
        Me.LblTitleAXY = New Jhjo.Component.CLabel()
        Me.LblTitleBlank = New Jhjo.Component.CLabel()
        Me.LblTitleCalibInfo = New Jhjo.Component.CLabel()
        Me.PnlButton = New Jhjo.Component.CPanel()
        Me.BtnForceStop = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.PnlLeft = New Jhjo.Component.CPanel()
        Me.PnlB = New Jhjo.Component.CPanel()
        Me.PnlBRight = New Jhjo.Component.CPanel()
        Me.CdpBRight = New Cognex.VisionPro.Display.CogDisplay()
        Me.LblTitleBRight = New Jhjo.Component.CLabel()
        Me.PnlBRightBar = New Jhjo.Component.CPanel()
        Me.PnlBRightStatusBar = New Jhjo.Component.CPanel()
        Me.CdsBRight = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlBRightToolBar = New Jhjo.Component.CPanel()
        Me.BtnBRightClearChecker = New System.Windows.Forms.Button()
        Me.BtnBRightShowChecker = New System.Windows.Forms.Button()
        Me.CdtBRight = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.PnlBLeft = New Jhjo.Component.CPanel()
        Me.CdpBLeft = New Cognex.VisionPro.Display.CogDisplay()
        Me.LblTitleBLeft = New Jhjo.Component.CLabel()
        Me.PnlBLeftBar = New Jhjo.Component.CPanel()
        Me.PnlBLeftStatusBar = New Jhjo.Component.CPanel()
        Me.CdsBLeft = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlBLeftToolBar = New Jhjo.Component.CPanel()
        Me.BtnBLeftClearChecker = New System.Windows.Forms.Button()
        Me.BtnBLeftShowChecker = New System.Windows.Forms.Button()
        Me.CdtBLeft = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.PnlA = New Jhjo.Component.CPanel()
        Me.PnlARight = New Jhjo.Component.CPanel()
        Me.CdpARight = New Cognex.VisionPro.Display.CogDisplay()
        Me.LblTitleARight = New Jhjo.Component.CLabel()
        Me.PnlARightBar = New Jhjo.Component.CPanel()
        Me.PnlARightStatusBar = New Jhjo.Component.CPanel()
        Me.CdsARight = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlARightToolBar = New Jhjo.Component.CPanel()
        Me.BtnARightClearChecker = New System.Windows.Forms.Button()
        Me.BtnARightShowChecker = New System.Windows.Forms.Button()
        Me.CdtARight = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.PnlALeft = New Jhjo.Component.CPanel()
        Me.CdpALeft = New Cognex.VisionPro.Display.CogDisplay()
        Me.LblTitleALeft = New Jhjo.Component.CLabel()
        Me.PnlALeftBar = New Jhjo.Component.CPanel()
        Me.PnlALeftStatusBar = New Jhjo.Component.CPanel()
        Me.CdsALeft = New Cognex.VisionPro.CogDisplayStatusBarV2()
        Me.PnlALeftToolBar = New Jhjo.Component.CPanel()
        Me.BtnALeftClearChecker = New System.Windows.Forms.Button()
        Me.BtnALeftShowChecker = New System.Windows.Forms.Button()
        Me.CdtALeft = New Cognex.VisionPro.CogDisplayToolbarV2()
        Me.PnlTitle.SuspendLayout()
        Me.PnlRight.SuspendLayout()
        Me.PnlCamera.SuspendLayout()
        CType(Me.NudExpoTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudMaxRetry, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudGain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CPanel2.SuspendLayout()
        CType(Me.NudROIHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudROIWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CPanel1.SuspendLayout()
        CType(Me.NudBPointT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBPointXY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAPointT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBSectionT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBSectionXY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudASectionT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAPointXY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudASectionXY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlButton.SuspendLayout()
        Me.PnlLeft.SuspendLayout()
        Me.PnlB.SuspendLayout()
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
        Me.PnlA.SuspendLayout()
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
        Me.SuspendLayout()
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
        Me.PnlTitle.Name = "PnlTitle"
        Me.PnlTitle.Size = New System.Drawing.Size(1280, 40)
        Me.PnlTitle.TabIndex = 5
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
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.OColor = System.Drawing.Color.Black
        Me.LblTitle.Size = New System.Drawing.Size(1280, 40)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Setup"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlRight
        '
        Me.PnlRight.BDrawBorderBottom = False
        Me.PnlRight.BDrawBorderLeft = False
        Me.PnlRight.BDrawBorderRight = False
        Me.PnlRight.BDrawBorderTop = False
        Me.PnlRight.Controls.Add(Me.PnlCamera)
        Me.PnlRight.Controls.Add(Me.CPanel2)
        Me.PnlRight.Controls.Add(Me.CPanel1)
        Me.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlRight.Location = New System.Drawing.Point(920, 40)
        Me.PnlRight.Name = "PnlRight"
        Me.PnlRight.Size = New System.Drawing.Size(360, 839)
        Me.PnlRight.TabIndex = 6
        '
        'PnlCamera
        '
        Me.PnlCamera.BDrawBorderBottom = False
        Me.PnlCamera.BDrawBorderLeft = False
        Me.PnlCamera.BDrawBorderRight = False
        Me.PnlCamera.BDrawBorderTop = False
        Me.PnlCamera.Controls.Add(Me.LblMaxRetry)
        Me.PnlCamera.Controls.Add(Me.LblTitleAlignmentOption)
        Me.PnlCamera.Controls.Add(Me.NudExpoTime)
        Me.PnlCamera.Controls.Add(Me.NudMaxRetry)
        Me.PnlCamera.Controls.Add(Me.NudGain)
        Me.PnlCamera.Controls.Add(Me.CmbCamera)
        Me.PnlCamera.Controls.Add(Me.LblTitleExpoTime)
        Me.PnlCamera.Controls.Add(Me.BtnApplyAlignment)
        Me.PnlCamera.Controls.Add(Me.BtnApplyCamera)
        Me.PnlCamera.Controls.Add(Me.LblTitleGain)
        Me.PnlCamera.Controls.Add(Me.LblTitleCamera)
        Me.PnlCamera.Controls.Add(Me.LblTitleCameraOption)
        Me.PnlCamera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlCamera.Location = New System.Drawing.Point(0, 290)
        Me.PnlCamera.Name = "PnlCamera"
        Me.PnlCamera.Size = New System.Drawing.Size(360, 441)
        Me.PnlCamera.TabIndex = 6
        '
        'LblMaxRetry
        '
        Me.LblMaxRetry.BackColor = System.Drawing.Color.DimGray
        Me.LblMaxRetry.BDrawBorderBottom = True
        Me.LblMaxRetry.BDrawBorderLeft = True
        Me.LblMaxRetry.BDrawBorderRight = True
        Me.LblMaxRetry.BDrawBorderTop = False
        Me.LblMaxRetry.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblMaxRetry.ForeColor = System.Drawing.Color.White
        Me.LblMaxRetry.Location = New System.Drawing.Point(0, 250)
        Me.LblMaxRetry.Name = "LblMaxRetry"
        Me.LblMaxRetry.OColor = System.Drawing.Color.Black
        Me.LblMaxRetry.Size = New System.Drawing.Size(150, 40)
        Me.LblMaxRetry.TabIndex = 15
        Me.LblMaxRetry.Text = "Max Retry"
        Me.LblMaxRetry.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAlignmentOption
        '
        Me.LblTitleAlignmentOption.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAlignmentOption.BDrawBorderBottom = True
        Me.LblTitleAlignmentOption.BDrawBorderLeft = True
        Me.LblTitleAlignmentOption.BDrawBorderRight = False
        Me.LblTitleAlignmentOption.BDrawBorderTop = True
        Me.LblTitleAlignmentOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAlignmentOption.ForeColor = System.Drawing.Color.White
        Me.LblTitleAlignmentOption.Location = New System.Drawing.Point(0, 210)
        Me.LblTitleAlignmentOption.Name = "LblTitleAlignmentOption"
        Me.LblTitleAlignmentOption.OColor = System.Drawing.Color.Black
        Me.LblTitleAlignmentOption.Size = New System.Drawing.Size(360, 40)
        Me.LblTitleAlignmentOption.TabIndex = 14
        Me.LblTitleAlignmentOption.Text = "Alignment Option"
        Me.LblTitleAlignmentOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudExpoTime
        '
        Me.NudExpoTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudExpoTime.Location = New System.Drawing.Point(153, 125)
        Me.NudExpoTime.Name = "NudExpoTime"
        Me.NudExpoTime.Size = New System.Drawing.Size(206, 30)
        Me.NudExpoTime.TabIndex = 13
        Me.NudExpoTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudMaxRetry
        '
        Me.NudMaxRetry.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudMaxRetry.Location = New System.Drawing.Point(153, 255)
        Me.NudMaxRetry.Name = "NudMaxRetry"
        Me.NudMaxRetry.Size = New System.Drawing.Size(206, 30)
        Me.NudMaxRetry.TabIndex = 13
        Me.NudMaxRetry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudMaxRetry.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'NudGain
        '
        Me.NudGain.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudGain.Location = New System.Drawing.Point(153, 85)
        Me.NudGain.Name = "NudGain"
        Me.NudGain.Size = New System.Drawing.Size(206, 30)
        Me.NudGain.TabIndex = 13
        Me.NudGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmbCamera
        '
        Me.CmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.CmbCamera.FormattingEnabled = True
        Me.CmbCamera.Items.AddRange(New Object() {"#1 LEFT", "#1 RIGHT", "#2 LEFT", "#2 RIGHT"})
        Me.CmbCamera.Location = New System.Drawing.Point(153, 44)
        Me.CmbCamera.Name = "CmbCamera"
        Me.CmbCamera.Size = New System.Drawing.Size(206, 33)
        Me.CmbCamera.TabIndex = 12
        '
        'LblTitleExpoTime
        '
        Me.LblTitleExpoTime.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleExpoTime.BDrawBorderBottom = True
        Me.LblTitleExpoTime.BDrawBorderLeft = True
        Me.LblTitleExpoTime.BDrawBorderRight = True
        Me.LblTitleExpoTime.BDrawBorderTop = False
        Me.LblTitleExpoTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleExpoTime.ForeColor = System.Drawing.Color.White
        Me.LblTitleExpoTime.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleExpoTime.Name = "LblTitleExpoTime"
        Me.LblTitleExpoTime.OColor = System.Drawing.Color.Black
        Me.LblTitleExpoTime.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleExpoTime.TabIndex = 11
        Me.LblTitleExpoTime.Text = "Ex. Time"
        Me.LblTitleExpoTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnApplyAlignment
        '
        Me.BtnApplyAlignment.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnApplyAlignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnApplyAlignment.ForeColor = System.Drawing.Color.White
        Me.BtnApplyAlignment.Location = New System.Drawing.Point(207, 294)
        Me.BtnApplyAlignment.Name = "BtnApplyAlignment"
        Me.BtnApplyAlignment.Size = New System.Drawing.Size(150, 46)
        Me.BtnApplyAlignment.TabIndex = 8
        Me.BtnApplyAlignment.Tag = ""
        Me.BtnApplyAlignment.Text = "Apply"
        Me.BtnApplyAlignment.UseVisualStyleBackColor = False
        '
        'BtnApplyCamera
        '
        Me.BtnApplyCamera.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnApplyCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnApplyCamera.ForeColor = System.Drawing.Color.White
        Me.BtnApplyCamera.Location = New System.Drawing.Point(207, 161)
        Me.BtnApplyCamera.Name = "BtnApplyCamera"
        Me.BtnApplyCamera.Size = New System.Drawing.Size(150, 46)
        Me.BtnApplyCamera.TabIndex = 8
        Me.BtnApplyCamera.Tag = ""
        Me.BtnApplyCamera.Text = "Apply"
        Me.BtnApplyCamera.UseVisualStyleBackColor = False
        '
        'LblTitleGain
        '
        Me.LblTitleGain.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleGain.BDrawBorderBottom = True
        Me.LblTitleGain.BDrawBorderLeft = True
        Me.LblTitleGain.BDrawBorderRight = True
        Me.LblTitleGain.BDrawBorderTop = False
        Me.LblTitleGain.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleGain.ForeColor = System.Drawing.Color.White
        Me.LblTitleGain.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleGain.Name = "LblTitleGain"
        Me.LblTitleGain.OColor = System.Drawing.Color.Black
        Me.LblTitleGain.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleGain.TabIndex = 11
        Me.LblTitleGain.Text = "Gain"
        Me.LblTitleGain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleCamera
        '
        Me.LblTitleCamera.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCamera.BDrawBorderBottom = True
        Me.LblTitleCamera.BDrawBorderLeft = True
        Me.LblTitleCamera.BDrawBorderRight = True
        Me.LblTitleCamera.BDrawBorderTop = False
        Me.LblTitleCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCamera.ForeColor = System.Drawing.Color.White
        Me.LblTitleCamera.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleCamera.Name = "LblTitleCamera"
        Me.LblTitleCamera.OColor = System.Drawing.Color.Black
        Me.LblTitleCamera.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleCamera.TabIndex = 11
        Me.LblTitleCamera.Text = "Camera"
        Me.LblTitleCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleCameraOption
        '
        Me.LblTitleCameraOption.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCameraOption.BDrawBorderBottom = True
        Me.LblTitleCameraOption.BDrawBorderLeft = True
        Me.LblTitleCameraOption.BDrawBorderRight = False
        Me.LblTitleCameraOption.BDrawBorderTop = True
        Me.LblTitleCameraOption.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleCameraOption.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCameraOption.ForeColor = System.Drawing.Color.White
        Me.LblTitleCameraOption.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleCameraOption.Name = "LblTitleCameraOption"
        Me.LblTitleCameraOption.OColor = System.Drawing.Color.Black
        Me.LblTitleCameraOption.Size = New System.Drawing.Size(360, 40)
        Me.LblTitleCameraOption.TabIndex = 10
        Me.LblTitleCameraOption.Text = "Camera Option"
        Me.LblTitleCameraOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CPanel2
        '
        Me.CPanel2.BDrawBorderBottom = False
        Me.CPanel2.BDrawBorderLeft = False
        Me.CPanel2.BDrawBorderRight = False
        Me.CPanel2.BDrawBorderTop = False
        Me.CPanel2.Controls.Add(Me.CmbROIView)
        Me.CPanel2.Controls.Add(Me.ChkROIKind)
        Me.CPanel2.Controls.Add(Me.NudROIHeight)
        Me.CPanel2.Controls.Add(Me.NudROIWidth)
        Me.CPanel2.Controls.Add(Me.LblTitleROIHeight)
        Me.CPanel2.Controls.Add(Me.LblTitleROICamera)
        Me.CPanel2.Controls.Add(Me.LblTitleROIKind)
        Me.CPanel2.Controls.Add(Me.LblTitleROIWidth)
        Me.CPanel2.Controls.Add(Me.BtnROICenter)
        Me.CPanel2.Controls.Add(Me.BtnROIGoBack)
        Me.CPanel2.Controls.Add(Me.BtnROIApply)
        Me.CPanel2.Controls.Add(Me.BtnROIShape)
        Me.CPanel2.Controls.Add(Me.LblTitleAlignmentROI)
        Me.CPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CPanel2.Enabled = False
        Me.CPanel2.Location = New System.Drawing.Point(0, 731)
        Me.CPanel2.Name = "CPanel2"
        Me.CPanel2.Size = New System.Drawing.Size(360, 108)
        Me.CPanel2.TabIndex = 8
        Me.CPanel2.Visible = False
        '
        'CmbROIView
        '
        Me.CmbROIView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbROIView.Enabled = False
        Me.CmbROIView.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.CmbROIView.FormattingEnabled = True
        Me.CmbROIView.Items.AddRange(New Object() {"#1 LEFT", "#1 RIGHT", "#2 LEFT", "#2 RIGHT"})
        Me.CmbROIView.Location = New System.Drawing.Point(153, 44)
        Me.CmbROIView.Name = "CmbROIView"
        Me.CmbROIView.Size = New System.Drawing.Size(206, 33)
        Me.CmbROIView.TabIndex = 19
        Me.CmbROIView.Visible = False
        '
        'ChkROIKind
        '
        Me.ChkROIKind.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkROIKind.BackColor = System.Drawing.Color.SteelBlue
        Me.ChkROIKind.Enabled = False
        Me.ChkROIKind.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.ChkROIKind.ForeColor = System.Drawing.Color.White
        Me.ChkROIKind.Location = New System.Drawing.Point(153, 80)
        Me.ChkROIKind.Name = "ChkROIKind"
        Me.ChkROIKind.Size = New System.Drawing.Size(206, 40)
        Me.ChkROIKind.TabIndex = 18
        Me.ChkROIKind.Text = "ALL"
        Me.ChkROIKind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkROIKind.UseVisualStyleBackColor = False
        Me.ChkROIKind.Visible = False
        '
        'NudROIHeight
        '
        Me.NudROIHeight.DecimalPlaces = 3
        Me.NudROIHeight.Enabled = False
        Me.NudROIHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudROIHeight.Location = New System.Drawing.Point(153, 165)
        Me.NudROIHeight.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudROIHeight.Name = "NudROIHeight"
        Me.NudROIHeight.Size = New System.Drawing.Size(206, 30)
        Me.NudROIHeight.TabIndex = 17
        Me.NudROIHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudROIHeight.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NudROIHeight.Visible = False
        '
        'NudROIWidth
        '
        Me.NudROIWidth.DecimalPlaces = 3
        Me.NudROIWidth.Enabled = False
        Me.NudROIWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudROIWidth.Location = New System.Drawing.Point(153, 125)
        Me.NudROIWidth.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudROIWidth.Name = "NudROIWidth"
        Me.NudROIWidth.Size = New System.Drawing.Size(206, 30)
        Me.NudROIWidth.TabIndex = 17
        Me.NudROIWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudROIWidth.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NudROIWidth.Visible = False
        '
        'LblTitleROIHeight
        '
        Me.LblTitleROIHeight.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleROIHeight.BDrawBorderBottom = True
        Me.LblTitleROIHeight.BDrawBorderLeft = True
        Me.LblTitleROIHeight.BDrawBorderRight = True
        Me.LblTitleROIHeight.BDrawBorderTop = False
        Me.LblTitleROIHeight.Enabled = False
        Me.LblTitleROIHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleROIHeight.ForeColor = System.Drawing.Color.White
        Me.LblTitleROIHeight.Location = New System.Drawing.Point(0, 160)
        Me.LblTitleROIHeight.Name = "LblTitleROIHeight"
        Me.LblTitleROIHeight.OColor = System.Drawing.Color.Black
        Me.LblTitleROIHeight.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleROIHeight.TabIndex = 14
        Me.LblTitleROIHeight.Text = "Height (mm)"
        Me.LblTitleROIHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTitleROIHeight.Visible = False
        '
        'LblTitleROICamera
        '
        Me.LblTitleROICamera.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleROICamera.BDrawBorderBottom = True
        Me.LblTitleROICamera.BDrawBorderLeft = True
        Me.LblTitleROICamera.BDrawBorderRight = True
        Me.LblTitleROICamera.BDrawBorderTop = False
        Me.LblTitleROICamera.Enabled = False
        Me.LblTitleROICamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleROICamera.ForeColor = System.Drawing.Color.White
        Me.LblTitleROICamera.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleROICamera.Name = "LblTitleROICamera"
        Me.LblTitleROICamera.OColor = System.Drawing.Color.Black
        Me.LblTitleROICamera.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleROICamera.TabIndex = 14
        Me.LblTitleROICamera.Text = "Camera"
        Me.LblTitleROICamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTitleROICamera.Visible = False
        '
        'LblTitleROIKind
        '
        Me.LblTitleROIKind.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleROIKind.BDrawBorderBottom = True
        Me.LblTitleROIKind.BDrawBorderLeft = True
        Me.LblTitleROIKind.BDrawBorderRight = True
        Me.LblTitleROIKind.BDrawBorderTop = False
        Me.LblTitleROIKind.Enabled = False
        Me.LblTitleROIKind.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleROIKind.ForeColor = System.Drawing.Color.White
        Me.LblTitleROIKind.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleROIKind.Name = "LblTitleROIKind"
        Me.LblTitleROIKind.OColor = System.Drawing.Color.Black
        Me.LblTitleROIKind.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleROIKind.TabIndex = 14
        Me.LblTitleROIKind.Text = "Kind"
        Me.LblTitleROIKind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTitleROIKind.Visible = False
        '
        'LblTitleROIWidth
        '
        Me.LblTitleROIWidth.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleROIWidth.BDrawBorderBottom = True
        Me.LblTitleROIWidth.BDrawBorderLeft = True
        Me.LblTitleROIWidth.BDrawBorderRight = True
        Me.LblTitleROIWidth.BDrawBorderTop = False
        Me.LblTitleROIWidth.Enabled = False
        Me.LblTitleROIWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleROIWidth.ForeColor = System.Drawing.Color.White
        Me.LblTitleROIWidth.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleROIWidth.Name = "LblTitleROIWidth"
        Me.LblTitleROIWidth.OColor = System.Drawing.Color.Black
        Me.LblTitleROIWidth.Size = New System.Drawing.Size(150, 40)
        Me.LblTitleROIWidth.TabIndex = 14
        Me.LblTitleROIWidth.Text = "Width (mm)"
        Me.LblTitleROIWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTitleROIWidth.Visible = False
        '
        'BtnROICenter
        '
        Me.BtnROICenter.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnROICenter.Enabled = False
        Me.BtnROICenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnROICenter.ForeColor = System.Drawing.Color.White
        Me.BtnROICenter.Location = New System.Drawing.Point(207, 203)
        Me.BtnROICenter.Name = "BtnROICenter"
        Me.BtnROICenter.Size = New System.Drawing.Size(150, 46)
        Me.BtnROICenter.TabIndex = 8
        Me.BtnROICenter.Tag = ""
        Me.BtnROICenter.Text = "Center"
        Me.BtnROICenter.UseVisualStyleBackColor = False
        Me.BtnROICenter.Visible = False
        '
        'BtnROIGoBack
        '
        Me.BtnROIGoBack.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnROIGoBack.Enabled = False
        Me.BtnROIGoBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnROIGoBack.ForeColor = System.Drawing.Color.White
        Me.BtnROIGoBack.Location = New System.Drawing.Point(51, 252)
        Me.BtnROIGoBack.Name = "BtnROIGoBack"
        Me.BtnROIGoBack.Size = New System.Drawing.Size(150, 46)
        Me.BtnROIGoBack.TabIndex = 8
        Me.BtnROIGoBack.Tag = ""
        Me.BtnROIGoBack.Text = "Go Back"
        Me.BtnROIGoBack.UseVisualStyleBackColor = False
        Me.BtnROIGoBack.Visible = False
        '
        'BtnROIApply
        '
        Me.BtnROIApply.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnROIApply.Enabled = False
        Me.BtnROIApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnROIApply.ForeColor = System.Drawing.Color.White
        Me.BtnROIApply.Location = New System.Drawing.Point(207, 252)
        Me.BtnROIApply.Name = "BtnROIApply"
        Me.BtnROIApply.Size = New System.Drawing.Size(150, 46)
        Me.BtnROIApply.TabIndex = 8
        Me.BtnROIApply.Tag = ""
        Me.BtnROIApply.Text = "Apply"
        Me.BtnROIApply.UseVisualStyleBackColor = False
        Me.BtnROIApply.Visible = False
        '
        'BtnROIShape
        '
        Me.BtnROIShape.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnROIShape.Enabled = False
        Me.BtnROIShape.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnROIShape.ForeColor = System.Drawing.Color.White
        Me.BtnROIShape.Location = New System.Drawing.Point(51, 203)
        Me.BtnROIShape.Name = "BtnROIShape"
        Me.BtnROIShape.Size = New System.Drawing.Size(150, 46)
        Me.BtnROIShape.TabIndex = 8
        Me.BtnROIShape.Tag = ""
        Me.BtnROIShape.Text = "Shape"
        Me.BtnROIShape.UseVisualStyleBackColor = False
        Me.BtnROIShape.Visible = False
        '
        'LblTitleAlignmentROI
        '
        Me.LblTitleAlignmentROI.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAlignmentROI.BDrawBorderBottom = True
        Me.LblTitleAlignmentROI.BDrawBorderLeft = True
        Me.LblTitleAlignmentROI.BDrawBorderRight = False
        Me.LblTitleAlignmentROI.BDrawBorderTop = True
        Me.LblTitleAlignmentROI.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleAlignmentROI.Enabled = False
        Me.LblTitleAlignmentROI.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAlignmentROI.ForeColor = System.Drawing.Color.White
        Me.LblTitleAlignmentROI.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleAlignmentROI.Name = "LblTitleAlignmentROI"
        Me.LblTitleAlignmentROI.OColor = System.Drawing.Color.Black
        Me.LblTitleAlignmentROI.Size = New System.Drawing.Size(360, 40)
        Me.LblTitleAlignmentROI.TabIndex = 11
        Me.LblTitleAlignmentROI.Text = "Alignment ROI"
        Me.LblTitleAlignmentROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTitleAlignmentROI.Visible = False
        '
        'CPanel1
        '
        Me.CPanel1.BDrawBorderBottom = False
        Me.CPanel1.BDrawBorderLeft = True
        Me.CPanel1.BDrawBorderRight = False
        Me.CPanel1.BDrawBorderTop = False
        Me.CPanel1.Controls.Add(Me.NudBPointT)
        Me.CPanel1.Controls.Add(Me.NudBPointXY)
        Me.CPanel1.Controls.Add(Me.NudAPointT)
        Me.CPanel1.Controls.Add(Me.NudBSectionT)
        Me.CPanel1.Controls.Add(Me.BtnApplyCalibInfo)
        Me.CPanel1.Controls.Add(Me.NudBSectionXY)
        Me.CPanel1.Controls.Add(Me.NudASectionT)
        Me.CPanel1.Controls.Add(Me.NudAPointXY)
        Me.CPanel1.Controls.Add(Me.NudASectionXY)
        Me.CPanel1.Controls.Add(Me.LblTitlePoint)
        Me.CPanel1.Controls.Add(Me.LblTitleSection)
        Me.CPanel1.Controls.Add(Me.LblTitleBT)
        Me.CPanel1.Controls.Add(Me.LblTitleBXY)
        Me.CPanel1.Controls.Add(Me.LblTitleAT)
        Me.CPanel1.Controls.Add(Me.LblTitleAXY)
        Me.CPanel1.Controls.Add(Me.LblTitleBlank)
        Me.CPanel1.Controls.Add(Me.LblTitleCalibInfo)
        Me.CPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CPanel1.Location = New System.Drawing.Point(0, 0)
        Me.CPanel1.Name = "CPanel1"
        Me.CPanel1.Size = New System.Drawing.Size(360, 290)
        Me.CPanel1.TabIndex = 7
        '
        'NudBPointT
        '
        Me.NudBPointT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBPointT.Location = New System.Drawing.Point(244, 205)
        Me.NudBPointT.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudBPointT.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NudBPointT.Name = "NudBPointT"
        Me.NudBPointT.Size = New System.Drawing.Size(115, 30)
        Me.NudBPointT.TabIndex = 16
        Me.NudBPointT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudBPointT.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NudBPointXY
        '
        Me.NudBPointXY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBPointXY.Location = New System.Drawing.Point(244, 165)
        Me.NudBPointXY.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudBPointXY.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NudBPointXY.Name = "NudBPointXY"
        Me.NudBPointXY.Size = New System.Drawing.Size(115, 30)
        Me.NudBPointXY.TabIndex = 16
        Me.NudBPointXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudBPointXY.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NudAPointT
        '
        Me.NudAPointT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAPointT.Location = New System.Drawing.Point(244, 125)
        Me.NudAPointT.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudAPointT.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NudAPointT.Name = "NudAPointT"
        Me.NudAPointT.Size = New System.Drawing.Size(115, 30)
        Me.NudAPointT.TabIndex = 16
        Me.NudAPointT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudAPointT.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NudBSectionT
        '
        Me.NudBSectionT.DecimalPlaces = 3
        Me.NudBSectionT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBSectionT.Location = New System.Drawing.Point(123, 205)
        Me.NudBSectionT.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudBSectionT.Name = "NudBSectionT"
        Me.NudBSectionT.Size = New System.Drawing.Size(115, 30)
        Me.NudBSectionT.TabIndex = 16
        Me.NudBSectionT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudBSectionT.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'BtnApplyCalibInfo
        '
        Me.BtnApplyCalibInfo.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnApplyCalibInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnApplyCalibInfo.ForeColor = System.Drawing.Color.White
        Me.BtnApplyCalibInfo.Location = New System.Drawing.Point(207, 241)
        Me.BtnApplyCalibInfo.Name = "BtnApplyCalibInfo"
        Me.BtnApplyCalibInfo.Size = New System.Drawing.Size(150, 46)
        Me.BtnApplyCalibInfo.TabIndex = 8
        Me.BtnApplyCalibInfo.Tag = ""
        Me.BtnApplyCalibInfo.Text = "Apply"
        Me.BtnApplyCalibInfo.UseVisualStyleBackColor = False
        '
        'NudBSectionXY
        '
        Me.NudBSectionXY.DecimalPlaces = 3
        Me.NudBSectionXY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBSectionXY.Location = New System.Drawing.Point(123, 165)
        Me.NudBSectionXY.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudBSectionXY.Name = "NudBSectionXY"
        Me.NudBSectionXY.Size = New System.Drawing.Size(115, 30)
        Me.NudBSectionXY.TabIndex = 16
        Me.NudBSectionXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudBSectionXY.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'NudASectionT
        '
        Me.NudASectionT.DecimalPlaces = 3
        Me.NudASectionT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudASectionT.Location = New System.Drawing.Point(123, 125)
        Me.NudASectionT.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudASectionT.Name = "NudASectionT"
        Me.NudASectionT.Size = New System.Drawing.Size(115, 30)
        Me.NudASectionT.TabIndex = 16
        Me.NudASectionT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudASectionT.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'NudAPointXY
        '
        Me.NudAPointXY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAPointXY.Location = New System.Drawing.Point(244, 85)
        Me.NudAPointXY.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudAPointXY.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NudAPointXY.Name = "NudAPointXY"
        Me.NudAPointXY.Size = New System.Drawing.Size(115, 30)
        Me.NudAPointXY.TabIndex = 16
        Me.NudAPointXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudAPointXY.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'NudASectionXY
        '
        Me.NudASectionXY.DecimalPlaces = 3
        Me.NudASectionXY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudASectionXY.Location = New System.Drawing.Point(125, 85)
        Me.NudASectionXY.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NudASectionXY.Name = "NudASectionXY"
        Me.NudASectionXY.Size = New System.Drawing.Size(115, 30)
        Me.NudASectionXY.TabIndex = 16
        Me.NudASectionXY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudASectionXY.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'LblTitlePoint
        '
        Me.LblTitlePoint.BackColor = System.Drawing.Color.DimGray
        Me.LblTitlePoint.BDrawBorderBottom = True
        Me.LblTitlePoint.BDrawBorderLeft = False
        Me.LblTitlePoint.BDrawBorderRight = False
        Me.LblTitlePoint.BDrawBorderTop = False
        Me.LblTitlePoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitlePoint.ForeColor = System.Drawing.Color.White
        Me.LblTitlePoint.Location = New System.Drawing.Point(241, 40)
        Me.LblTitlePoint.Name = "LblTitlePoint"
        Me.LblTitlePoint.OColor = System.Drawing.Color.Black
        Me.LblTitlePoint.Size = New System.Drawing.Size(121, 40)
        Me.LblTitlePoint.TabIndex = 15
        Me.LblTitlePoint.Text = "Point"
        Me.LblTitlePoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleSection
        '
        Me.LblTitleSection.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleSection.BDrawBorderBottom = True
        Me.LblTitleSection.BDrawBorderLeft = False
        Me.LblTitleSection.BDrawBorderRight = True
        Me.LblTitleSection.BDrawBorderTop = False
        Me.LblTitleSection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleSection.ForeColor = System.Drawing.Color.White
        Me.LblTitleSection.Location = New System.Drawing.Point(120, 40)
        Me.LblTitleSection.Name = "LblTitleSection"
        Me.LblTitleSection.OColor = System.Drawing.Color.Black
        Me.LblTitleSection.Size = New System.Drawing.Size(121, 40)
        Me.LblTitleSection.TabIndex = 15
        Me.LblTitleSection.Text = "Section"
        Me.LblTitleSection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBT
        '
        Me.LblTitleBT.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBT.BDrawBorderBottom = True
        Me.LblTitleBT.BDrawBorderLeft = True
        Me.LblTitleBT.BDrawBorderRight = True
        Me.LblTitleBT.BDrawBorderTop = False
        Me.LblTitleBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBT.ForeColor = System.Drawing.Color.White
        Me.LblTitleBT.Location = New System.Drawing.Point(0, 200)
        Me.LblTitleBT.Name = "LblTitleBT"
        Me.LblTitleBT.OColor = System.Drawing.Color.Black
        Me.LblTitleBT.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBT.TabIndex = 14
        Me.LblTitleBT.Text = "T (#2)"
        Me.LblTitleBT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBXY
        '
        Me.LblTitleBXY.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBXY.BDrawBorderBottom = True
        Me.LblTitleBXY.BDrawBorderLeft = True
        Me.LblTitleBXY.BDrawBorderRight = True
        Me.LblTitleBXY.BDrawBorderTop = False
        Me.LblTitleBXY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBXY.ForeColor = System.Drawing.Color.White
        Me.LblTitleBXY.Location = New System.Drawing.Point(0, 160)
        Me.LblTitleBXY.Name = "LblTitleBXY"
        Me.LblTitleBXY.OColor = System.Drawing.Color.Black
        Me.LblTitleBXY.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBXY.TabIndex = 13
        Me.LblTitleBXY.Text = "X - Y (#2)"
        Me.LblTitleBXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAT
        '
        Me.LblTitleAT.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAT.BDrawBorderBottom = True
        Me.LblTitleAT.BDrawBorderLeft = True
        Me.LblTitleAT.BDrawBorderRight = True
        Me.LblTitleAT.BDrawBorderTop = False
        Me.LblTitleAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAT.ForeColor = System.Drawing.Color.White
        Me.LblTitleAT.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleAT.Name = "LblTitleAT"
        Me.LblTitleAT.OColor = System.Drawing.Color.Black
        Me.LblTitleAT.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAT.TabIndex = 14
        Me.LblTitleAT.Text = "T (#1)"
        Me.LblTitleAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAXY
        '
        Me.LblTitleAXY.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAXY.BDrawBorderBottom = True
        Me.LblTitleAXY.BDrawBorderLeft = True
        Me.LblTitleAXY.BDrawBorderRight = True
        Me.LblTitleAXY.BDrawBorderTop = False
        Me.LblTitleAXY.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAXY.ForeColor = System.Drawing.Color.White
        Me.LblTitleAXY.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleAXY.Name = "LblTitleAXY"
        Me.LblTitleAXY.OColor = System.Drawing.Color.Black
        Me.LblTitleAXY.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAXY.TabIndex = 13
        Me.LblTitleAXY.Text = "X - Y (#1)"
        Me.LblTitleAXY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBlank
        '
        Me.LblTitleBlank.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBlank.BDrawBorderBottom = True
        Me.LblTitleBlank.BDrawBorderLeft = True
        Me.LblTitleBlank.BDrawBorderRight = True
        Me.LblTitleBlank.BDrawBorderTop = False
        Me.LblTitleBlank.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBlank.ForeColor = System.Drawing.Color.White
        Me.LblTitleBlank.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleBlank.Name = "LblTitleBlank"
        Me.LblTitleBlank.OColor = System.Drawing.Color.Black
        Me.LblTitleBlank.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBlank.TabIndex = 12
        Me.LblTitleBlank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleCalibInfo
        '
        Me.LblTitleCalibInfo.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCalibInfo.BDrawBorderBottom = True
        Me.LblTitleCalibInfo.BDrawBorderLeft = True
        Me.LblTitleCalibInfo.BDrawBorderRight = False
        Me.LblTitleCalibInfo.BDrawBorderTop = False
        Me.LblTitleCalibInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleCalibInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCalibInfo.ForeColor = System.Drawing.Color.White
        Me.LblTitleCalibInfo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleCalibInfo.Name = "LblTitleCalibInfo"
        Me.LblTitleCalibInfo.OColor = System.Drawing.Color.Black
        Me.LblTitleCalibInfo.Size = New System.Drawing.Size(360, 40)
        Me.LblTitleCalibInfo.TabIndex = 11
        Me.LblTitleCalibInfo.Text = "Calibration Info."
        Me.LblTitleCalibInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlButton
        '
        Me.PnlButton.BDrawBorderBottom = False
        Me.PnlButton.BDrawBorderLeft = False
        Me.PnlButton.BDrawBorderRight = False
        Me.PnlButton.BDrawBorderTop = True
        Me.PnlButton.Controls.Add(Me.BtnForceStop)
        Me.PnlButton.Controls.Add(Me.BtnStop)
        Me.PnlButton.Controls.Add(Me.BtnStart)
        Me.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButton.Location = New System.Drawing.Point(0, 879)
        Me.PnlButton.Name = "PnlButton"
        Me.PnlButton.Size = New System.Drawing.Size(1280, 50)
        Me.PnlButton.TabIndex = 6
        '
        'BtnForceStop
        '
        Me.BtnForceStop.BackColor = System.Drawing.Color.DarkRed
        Me.BtnForceStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnForceStop.ForeColor = System.Drawing.Color.White
        Me.BtnForceStop.Location = New System.Drawing.Point(273, 2)
        Me.BtnForceStop.Name = "BtnForceStop"
        Me.BtnForceStop.Size = New System.Drawing.Size(135, 41)
        Me.BtnForceStop.TabIndex = 8
        Me.BtnForceStop.Text = "Force Stop"
        Me.BtnForceStop.UseVisualStyleBackColor = False
        '
        'BtnStop
        '
        Me.BtnStop.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.ForeColor = System.Drawing.Color.White
        Me.BtnStop.Location = New System.Drawing.Point(138, 2)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(135, 41)
        Me.BtnStop.TabIndex = 7
        Me.BtnStop.Text = "Stop"
        Me.BtnStop.UseVisualStyleBackColor = False
        '
        'BtnStart
        '
        Me.BtnStart.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.Color.White
        Me.BtnStart.Location = New System.Drawing.Point(3, 2)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(135, 41)
        Me.BtnStart.TabIndex = 7
        Me.BtnStart.Text = "Start"
        Me.BtnStart.UseVisualStyleBackColor = False
        '
        'PnlLeft
        '
        Me.PnlLeft.BDrawBorderBottom = False
        Me.PnlLeft.BDrawBorderLeft = False
        Me.PnlLeft.BDrawBorderRight = False
        Me.PnlLeft.BDrawBorderTop = False
        Me.PnlLeft.Controls.Add(Me.PnlB)
        Me.PnlLeft.Controls.Add(Me.PnlA)
        Me.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlLeft.Location = New System.Drawing.Point(0, 40)
        Me.PnlLeft.Name = "PnlLeft"
        Me.PnlLeft.Size = New System.Drawing.Size(920, 839)
        Me.PnlLeft.TabIndex = 6
        '
        'PnlB
        '
        Me.PnlB.BDrawBorderBottom = False
        Me.PnlB.BDrawBorderLeft = False
        Me.PnlB.BDrawBorderRight = False
        Me.PnlB.BDrawBorderTop = False
        Me.PnlB.Controls.Add(Me.PnlBRight)
        Me.PnlB.Controls.Add(Me.PnlBLeft)
        Me.PnlB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlB.Location = New System.Drawing.Point(0, 420)
        Me.PnlB.Name = "PnlB"
        Me.PnlB.Size = New System.Drawing.Size(920, 419)
        Me.PnlB.TabIndex = 6
        '
        'PnlBRight
        '
        Me.PnlBRight.BDrawBorderBottom = False
        Me.PnlBRight.BDrawBorderLeft = False
        Me.PnlBRight.BDrawBorderRight = False
        Me.PnlBRight.BDrawBorderTop = False
        Me.PnlBRight.Controls.Add(Me.CdpBRight)
        Me.PnlBRight.Controls.Add(Me.LblTitleBRight)
        Me.PnlBRight.Controls.Add(Me.PnlBRightBar)
        Me.PnlBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBRight.Location = New System.Drawing.Point(460, 0)
        Me.PnlBRight.Name = "PnlBRight"
        Me.PnlBRight.Size = New System.Drawing.Size(460, 419)
        Me.PnlBRight.TabIndex = 8
        '
        'CdpBRight
        '
        Me.CdpBRight.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpBRight.ColorMapLowerRoiLimit = 0.0R
        Me.CdpBRight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpBRight.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpBRight.ColorMapUpperRoiLimit = 1.0R
        Me.CdpBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpBRight.DoubleTapZoomCycleLength = 2
        Me.CdpBRight.DoubleTapZoomSensitivity = 2.5R
        Me.CdpBRight.Location = New System.Drawing.Point(0, 40)
        Me.CdpBRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpBRight.MouseWheelSensitivity = 1.0R
        Me.CdpBRight.Name = "CdpBRight"
        Me.CdpBRight.OcxState = CType(resources.GetObject("CdpBRight.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpBRight.Size = New System.Drawing.Size(460, 353)
        Me.CdpBRight.TabIndex = 10
        Me.CdpBRight.Tag = "B RIGHT"
        '
        'LblTitleBRight
        '
        Me.LblTitleBRight.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBRight.BDrawBorderBottom = True
        Me.LblTitleBRight.BDrawBorderLeft = True
        Me.LblTitleBRight.BDrawBorderRight = False
        Me.LblTitleBRight.BDrawBorderTop = True
        Me.LblTitleBRight.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBRight.ForeColor = System.Drawing.Color.White
        Me.LblTitleBRight.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBRight.Name = "LblTitleBRight"
        Me.LblTitleBRight.OColor = System.Drawing.Color.Black
        Me.LblTitleBRight.Size = New System.Drawing.Size(460, 40)
        Me.LblTitleBRight.TabIndex = 8
        Me.LblTitleBRight.Text = "#2 Right"
        Me.LblTitleBRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PnlBRightBar.Location = New System.Drawing.Point(0, 393)
        Me.PnlBRightBar.Name = "PnlBRightBar"
        Me.PnlBRightBar.Size = New System.Drawing.Size(460, 26)
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
        Me.PnlBRightStatusBar.Location = New System.Drawing.Point(243, 0)
        Me.PnlBRightStatusBar.Name = "PnlBRightStatusBar"
        Me.PnlBRightStatusBar.Size = New System.Drawing.Size(217, 26)
        Me.PnlBRightStatusBar.TabIndex = 8
        '
        'CdsBRight
        '
        Me.CdsBRight.CoordinateSpaceName = "*\#"
        Me.CdsBRight.CoordinateSpaceName3D = "*\#"
        Me.CdsBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsBRight.Location = New System.Drawing.Point(0, 0)
        Me.CdsBRight.Name = "CdsBRight"
        Me.CdsBRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsBRight.ShowPixelValuePane = False
        Me.CdsBRight.ShowZoomPane = False
        Me.CdsBRight.Size = New System.Drawing.Size(217, 26)
        Me.CdsBRight.TabIndex = 1
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
        Me.PnlBRightToolBar.Name = "PnlBRightToolBar"
        Me.PnlBRightToolBar.Size = New System.Drawing.Size(243, 26)
        Me.PnlBRightToolBar.TabIndex = 7
        '
        'BtnBRightClearChecker
        '
        Me.BtnBRightClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBRightClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBRightClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnBRightClearChecker.Location = New System.Drawing.Point(219, 3)
        Me.BtnBRightClearChecker.Name = "BtnBRightClearChecker"
        Me.BtnBRightClearChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnBRightClearChecker.TabIndex = 65
        Me.BtnBRightClearChecker.Tag = "3"
        Me.BtnBRightClearChecker.UseVisualStyleBackColor = False
        '
        'BtnBRightShowChecker
        '
        Me.BtnBRightShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBRightShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBRightShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBRightShowChecker.Image = CType(resources.GetObject("BtnBRightShowChecker.Image"), System.Drawing.Image)
        Me.BtnBRightShowChecker.Location = New System.Drawing.Point(197, 3)
        Me.BtnBRightShowChecker.Name = "BtnBRightShowChecker"
        Me.BtnBRightShowChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnBRightShowChecker.TabIndex = 64
        Me.BtnBRightShowChecker.Tag = "3"
        Me.BtnBRightShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBRightShowChecker.UseVisualStyleBackColor = False
        '
        'CdtBRight
        '
        Me.CdtBRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtBRight.Location = New System.Drawing.Point(0, 0)
        Me.CdtBRight.Name = "CdtBRight"
        Me.CdtBRight.Size = New System.Drawing.Size(243, 26)
        Me.CdtBRight.TabIndex = 1
        '
        'PnlBLeft
        '
        Me.PnlBLeft.BDrawBorderBottom = False
        Me.PnlBLeft.BDrawBorderLeft = False
        Me.PnlBLeft.BDrawBorderRight = False
        Me.PnlBLeft.BDrawBorderTop = False
        Me.PnlBLeft.Controls.Add(Me.CdpBLeft)
        Me.PnlBLeft.Controls.Add(Me.LblTitleBLeft)
        Me.PnlBLeft.Controls.Add(Me.PnlBLeftBar)
        Me.PnlBLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlBLeft.Name = "PnlBLeft"
        Me.PnlBLeft.Size = New System.Drawing.Size(460, 419)
        Me.PnlBLeft.TabIndex = 7
        '
        'CdpBLeft
        '
        Me.CdpBLeft.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpBLeft.ColorMapLowerRoiLimit = 0.0R
        Me.CdpBLeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpBLeft.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpBLeft.ColorMapUpperRoiLimit = 1.0R
        Me.CdpBLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpBLeft.DoubleTapZoomCycleLength = 2
        Me.CdpBLeft.DoubleTapZoomSensitivity = 2.5R
        Me.CdpBLeft.Location = New System.Drawing.Point(0, 40)
        Me.CdpBLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpBLeft.MouseWheelSensitivity = 1.0R
        Me.CdpBLeft.Name = "CdpBLeft"
        Me.CdpBLeft.OcxState = CType(resources.GetObject("CdpBLeft.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpBLeft.Size = New System.Drawing.Size(460, 353)
        Me.CdpBLeft.TabIndex = 10
        Me.CdpBLeft.Tag = "B LEFT"
        '
        'LblTitleBLeft
        '
        Me.LblTitleBLeft.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBLeft.BDrawBorderBottom = True
        Me.LblTitleBLeft.BDrawBorderLeft = False
        Me.LblTitleBLeft.BDrawBorderRight = False
        Me.LblTitleBLeft.BDrawBorderTop = True
        Me.LblTitleBLeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBLeft.ForeColor = System.Drawing.Color.White
        Me.LblTitleBLeft.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBLeft.Name = "LblTitleBLeft"
        Me.LblTitleBLeft.OColor = System.Drawing.Color.Black
        Me.LblTitleBLeft.Size = New System.Drawing.Size(460, 40)
        Me.LblTitleBLeft.TabIndex = 8
        Me.LblTitleBLeft.Text = "#2 Left"
        Me.LblTitleBLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PnlBLeftBar.Location = New System.Drawing.Point(0, 393)
        Me.PnlBLeftBar.Name = "PnlBLeftBar"
        Me.PnlBLeftBar.Size = New System.Drawing.Size(460, 26)
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
        Me.PnlBLeftStatusBar.Location = New System.Drawing.Point(243, 0)
        Me.PnlBLeftStatusBar.Name = "PnlBLeftStatusBar"
        Me.PnlBLeftStatusBar.Size = New System.Drawing.Size(217, 26)
        Me.PnlBLeftStatusBar.TabIndex = 8
        '
        'CdsBLeft
        '
        Me.CdsBLeft.CoordinateSpaceName = "*\#"
        Me.CdsBLeft.CoordinateSpaceName3D = "*\#"
        Me.CdsBLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsBLeft.Location = New System.Drawing.Point(0, 0)
        Me.CdsBLeft.Name = "CdsBLeft"
        Me.CdsBLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsBLeft.ShowPixelValuePane = False
        Me.CdsBLeft.ShowZoomPane = False
        Me.CdsBLeft.Size = New System.Drawing.Size(217, 26)
        Me.CdsBLeft.TabIndex = 1
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
        Me.PnlBLeftToolBar.Name = "PnlBLeftToolBar"
        Me.PnlBLeftToolBar.Size = New System.Drawing.Size(243, 26)
        Me.PnlBLeftToolBar.TabIndex = 7
        '
        'BtnBLeftClearChecker
        '
        Me.BtnBLeftClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBLeftClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBLeftClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnBLeftClearChecker.Location = New System.Drawing.Point(219, 3)
        Me.BtnBLeftClearChecker.Name = "BtnBLeftClearChecker"
        Me.BtnBLeftClearChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnBLeftClearChecker.TabIndex = 65
        Me.BtnBLeftClearChecker.Tag = "2"
        Me.BtnBLeftClearChecker.UseVisualStyleBackColor = False
        '
        'BtnBLeftShowChecker
        '
        Me.BtnBLeftShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnBLeftShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBLeftShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBLeftShowChecker.Image = CType(resources.GetObject("BtnBLeftShowChecker.Image"), System.Drawing.Image)
        Me.BtnBLeftShowChecker.Location = New System.Drawing.Point(197, 3)
        Me.BtnBLeftShowChecker.Name = "BtnBLeftShowChecker"
        Me.BtnBLeftShowChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnBLeftShowChecker.TabIndex = 64
        Me.BtnBLeftShowChecker.Tag = "2"
        Me.BtnBLeftShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBLeftShowChecker.UseVisualStyleBackColor = False
        '
        'CdtBLeft
        '
        Me.CdtBLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtBLeft.Location = New System.Drawing.Point(0, 0)
        Me.CdtBLeft.Name = "CdtBLeft"
        Me.CdtBLeft.Size = New System.Drawing.Size(243, 26)
        Me.CdtBLeft.TabIndex = 1
        '
        'PnlA
        '
        Me.PnlA.BDrawBorderBottom = False
        Me.PnlA.BDrawBorderLeft = False
        Me.PnlA.BDrawBorderRight = False
        Me.PnlA.BDrawBorderTop = False
        Me.PnlA.Controls.Add(Me.PnlARight)
        Me.PnlA.Controls.Add(Me.PnlALeft)
        Me.PnlA.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlA.Location = New System.Drawing.Point(0, 0)
        Me.PnlA.Name = "PnlA"
        Me.PnlA.Size = New System.Drawing.Size(920, 420)
        Me.PnlA.TabIndex = 6
        '
        'PnlARight
        '
        Me.PnlARight.BDrawBorderBottom = False
        Me.PnlARight.BDrawBorderLeft = False
        Me.PnlARight.BDrawBorderRight = False
        Me.PnlARight.BDrawBorderTop = False
        Me.PnlARight.Controls.Add(Me.CdpARight)
        Me.PnlARight.Controls.Add(Me.LblTitleARight)
        Me.PnlARight.Controls.Add(Me.PnlARightBar)
        Me.PnlARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlARight.Location = New System.Drawing.Point(460, 0)
        Me.PnlARight.Name = "PnlARight"
        Me.PnlARight.Size = New System.Drawing.Size(460, 420)
        Me.PnlARight.TabIndex = 6
        '
        'CdpARight
        '
        Me.CdpARight.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpARight.ColorMapLowerRoiLimit = 0.0R
        Me.CdpARight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpARight.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpARight.ColorMapUpperRoiLimit = 1.0R
        Me.CdpARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpARight.DoubleTapZoomCycleLength = 2
        Me.CdpARight.DoubleTapZoomSensitivity = 2.5R
        Me.CdpARight.Location = New System.Drawing.Point(0, 40)
        Me.CdpARight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpARight.MouseWheelSensitivity = 1.0R
        Me.CdpARight.Name = "CdpARight"
        Me.CdpARight.OcxState = CType(resources.GetObject("CdpARight.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpARight.Size = New System.Drawing.Size(460, 354)
        Me.CdpARight.TabIndex = 9
        Me.CdpARight.Tag = "A RIGHT"
        '
        'LblTitleARight
        '
        Me.LblTitleARight.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleARight.BDrawBorderBottom = True
        Me.LblTitleARight.BDrawBorderLeft = True
        Me.LblTitleARight.BDrawBorderRight = False
        Me.LblTitleARight.BDrawBorderTop = False
        Me.LblTitleARight.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleARight.ForeColor = System.Drawing.Color.White
        Me.LblTitleARight.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleARight.Name = "LblTitleARight"
        Me.LblTitleARight.OColor = System.Drawing.Color.Black
        Me.LblTitleARight.Size = New System.Drawing.Size(460, 40)
        Me.LblTitleARight.TabIndex = 8
        Me.LblTitleARight.Text = "#1 Right"
        Me.LblTitleARight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PnlARightBar.Location = New System.Drawing.Point(0, 394)
        Me.PnlARightBar.Name = "PnlARightBar"
        Me.PnlARightBar.Size = New System.Drawing.Size(460, 26)
        Me.PnlARightBar.TabIndex = 7
        '
        'PnlARightStatusBar
        '
        Me.PnlARightStatusBar.BDrawBorderBottom = False
        Me.PnlARightStatusBar.BDrawBorderLeft = False
        Me.PnlARightStatusBar.BDrawBorderRight = False
        Me.PnlARightStatusBar.BDrawBorderTop = False
        Me.PnlARightStatusBar.Controls.Add(Me.CdsARight)
        Me.PnlARightStatusBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlARightStatusBar.Location = New System.Drawing.Point(243, 0)
        Me.PnlARightStatusBar.Name = "PnlARightStatusBar"
        Me.PnlARightStatusBar.Size = New System.Drawing.Size(217, 26)
        Me.PnlARightStatusBar.TabIndex = 8
        '
        'CdsARight
        '
        Me.CdsARight.CoordinateSpaceName = "*\#"
        Me.CdsARight.CoordinateSpaceName3D = "*\#"
        Me.CdsARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsARight.Location = New System.Drawing.Point(0, 0)
        Me.CdsARight.Name = "CdsARight"
        Me.CdsARight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsARight.ShowPixelValuePane = False
        Me.CdsARight.ShowZoomPane = False
        Me.CdsARight.Size = New System.Drawing.Size(217, 26)
        Me.CdsARight.TabIndex = 1
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
        Me.PnlARightToolBar.Name = "PnlARightToolBar"
        Me.PnlARightToolBar.Size = New System.Drawing.Size(243, 26)
        Me.PnlARightToolBar.TabIndex = 7
        '
        'BtnARightClearChecker
        '
        Me.BtnARightClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnARightClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnARightClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnARightClearChecker.Location = New System.Drawing.Point(219, 3)
        Me.BtnARightClearChecker.Name = "BtnARightClearChecker"
        Me.BtnARightClearChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnARightClearChecker.TabIndex = 65
        Me.BtnARightClearChecker.Tag = "1"
        Me.BtnARightClearChecker.UseVisualStyleBackColor = False
        '
        'BtnARightShowChecker
        '
        Me.BtnARightShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnARightShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnARightShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnARightShowChecker.Image = CType(resources.GetObject("BtnARightShowChecker.Image"), System.Drawing.Image)
        Me.BtnARightShowChecker.Location = New System.Drawing.Point(197, 3)
        Me.BtnARightShowChecker.Name = "BtnARightShowChecker"
        Me.BtnARightShowChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnARightShowChecker.TabIndex = 64
        Me.BtnARightShowChecker.Tag = "1"
        Me.BtnARightShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnARightShowChecker.UseVisualStyleBackColor = False
        '
        'CdtARight
        '
        Me.CdtARight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtARight.Location = New System.Drawing.Point(0, 0)
        Me.CdtARight.Name = "CdtARight"
        Me.CdtARight.Size = New System.Drawing.Size(243, 26)
        Me.CdtARight.TabIndex = 1
        '
        'PnlALeft
        '
        Me.PnlALeft.BDrawBorderBottom = False
        Me.PnlALeft.BDrawBorderLeft = False
        Me.PnlALeft.BDrawBorderRight = False
        Me.PnlALeft.BDrawBorderTop = False
        Me.PnlALeft.Controls.Add(Me.CdpALeft)
        Me.PnlALeft.Controls.Add(Me.LblTitleALeft)
        Me.PnlALeft.Controls.Add(Me.PnlALeftBar)
        Me.PnlALeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlALeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlALeft.Name = "PnlALeft"
        Me.PnlALeft.Size = New System.Drawing.Size(460, 420)
        Me.PnlALeft.TabIndex = 6
        '
        'CdpALeft
        '
        Me.CdpALeft.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpALeft.ColorMapLowerRoiLimit = 0.0R
        Me.CdpALeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpALeft.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpALeft.ColorMapUpperRoiLimit = 1.0R
        Me.CdpALeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpALeft.DoubleTapZoomCycleLength = 2
        Me.CdpALeft.DoubleTapZoomSensitivity = 2.5R
        Me.CdpALeft.Location = New System.Drawing.Point(0, 40)
        Me.CdpALeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpALeft.MouseWheelSensitivity = 1.0R
        Me.CdpALeft.Name = "CdpALeft"
        Me.CdpALeft.OcxState = CType(resources.GetObject("CdpALeft.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpALeft.Size = New System.Drawing.Size(460, 354)
        Me.CdpALeft.TabIndex = 8
        Me.CdpALeft.Tag = "A LEFT"
        '
        'LblTitleALeft
        '
        Me.LblTitleALeft.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleALeft.BDrawBorderBottom = True
        Me.LblTitleALeft.BDrawBorderLeft = False
        Me.LblTitleALeft.BDrawBorderRight = False
        Me.LblTitleALeft.BDrawBorderTop = False
        Me.LblTitleALeft.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleALeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleALeft.ForeColor = System.Drawing.Color.White
        Me.LblTitleALeft.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleALeft.Name = "LblTitleALeft"
        Me.LblTitleALeft.OColor = System.Drawing.Color.Black
        Me.LblTitleALeft.Size = New System.Drawing.Size(460, 40)
        Me.LblTitleALeft.TabIndex = 7
        Me.LblTitleALeft.Text = "#1 Left"
        Me.LblTitleALeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PnlALeftBar.Location = New System.Drawing.Point(0, 394)
        Me.PnlALeftBar.Name = "PnlALeftBar"
        Me.PnlALeftBar.Size = New System.Drawing.Size(460, 26)
        Me.PnlALeftBar.TabIndex = 6
        '
        'PnlALeftStatusBar
        '
        Me.PnlALeftStatusBar.BDrawBorderBottom = False
        Me.PnlALeftStatusBar.BDrawBorderLeft = False
        Me.PnlALeftStatusBar.BDrawBorderRight = False
        Me.PnlALeftStatusBar.BDrawBorderTop = False
        Me.PnlALeftStatusBar.Controls.Add(Me.CdsALeft)
        Me.PnlALeftStatusBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlALeftStatusBar.Location = New System.Drawing.Point(243, 0)
        Me.PnlALeftStatusBar.Name = "PnlALeftStatusBar"
        Me.PnlALeftStatusBar.Size = New System.Drawing.Size(217, 26)
        Me.PnlALeftStatusBar.TabIndex = 6
        '
        'CdsALeft
        '
        Me.CdsALeft.CoordinateSpaceName = "*\#"
        Me.CdsALeft.CoordinateSpaceName3D = "*\#"
        Me.CdsALeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdsALeft.Location = New System.Drawing.Point(0, 0)
        Me.CdsALeft.Name = "CdsALeft"
        Me.CdsALeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CdsALeft.ShowPixelValuePane = False
        Me.CdsALeft.ShowZoomPane = False
        Me.CdsALeft.Size = New System.Drawing.Size(217, 26)
        Me.CdsALeft.TabIndex = 1
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
        Me.PnlALeftToolBar.Name = "PnlALeftToolBar"
        Me.PnlALeftToolBar.Size = New System.Drawing.Size(243, 26)
        Me.PnlALeftToolBar.TabIndex = 6
        '
        'BtnALeftClearChecker
        '
        Me.BtnALeftClearChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnALeftClearChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnALeftClearChecker.Image = Global.DualScriber.My.Resources.Resources.ERA
        Me.BtnALeftClearChecker.Location = New System.Drawing.Point(219, 3)
        Me.BtnALeftClearChecker.Name = "BtnALeftClearChecker"
        Me.BtnALeftClearChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnALeftClearChecker.TabIndex = 63
        Me.BtnALeftClearChecker.Tag = "0"
        Me.BtnALeftClearChecker.UseVisualStyleBackColor = False
        '
        'BtnALeftShowChecker
        '
        Me.BtnALeftShowChecker.BackColor = System.Drawing.Color.Transparent
        Me.BtnALeftShowChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnALeftShowChecker.Font = New System.Drawing.Font("굴림", 1.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnALeftShowChecker.Image = CType(resources.GetObject("BtnALeftShowChecker.Image"), System.Drawing.Image)
        Me.BtnALeftShowChecker.Location = New System.Drawing.Point(197, 3)
        Me.BtnALeftShowChecker.Name = "BtnALeftShowChecker"
        Me.BtnALeftShowChecker.Size = New System.Drawing.Size(20, 20)
        Me.BtnALeftShowChecker.TabIndex = 62
        Me.BtnALeftShowChecker.Tag = "0"
        Me.BtnALeftShowChecker.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnALeftShowChecker.UseVisualStyleBackColor = False
        '
        'CdtALeft
        '
        Me.CdtALeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdtALeft.Location = New System.Drawing.Point(0, 0)
        Me.CdtALeft.Name = "CdtALeft"
        Me.CdtALeft.Size = New System.Drawing.Size(243, 26)
        Me.CdtALeft.TabIndex = 1
        '
        'UcSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlRight)
        Me.Controls.Add(Me.PnlLeft)
        Me.Controls.Add(Me.PnlButton)
        Me.Controls.Add(Me.PnlTitle)
        Me.Name = "UcSetup"
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlRight.ResumeLayout(False)
        Me.PnlCamera.ResumeLayout(False)
        CType(Me.NudExpoTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudMaxRetry, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudGain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CPanel2.ResumeLayout(False)
        CType(Me.NudROIHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudROIWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CPanel1.ResumeLayout(False)
        CType(Me.NudBPointT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBPointXY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAPointT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBSectionT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBSectionXY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudASectionT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAPointXY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudASectionXY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlButton.ResumeLayout(False)
        Me.PnlLeft.ResumeLayout(False)
        Me.PnlB.ResumeLayout(False)
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
        Me.PnlA.ResumeLayout(False)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents PnlRight As Jhjo.Component.CPanel
    Friend WithEvents PnlButton As Jhjo.Component.CPanel
    Friend WithEvents BtnStart As System.Windows.Forms.Button
    Friend WithEvents BtnStop As System.Windows.Forms.Button
    Friend WithEvents PnlLeft As Jhjo.Component.CPanel
    Friend WithEvents PnlA As Jhjo.Component.CPanel
    Friend WithEvents PnlB As Jhjo.Component.CPanel
    Friend WithEvents PnlALeft As Jhjo.Component.CPanel
    Friend WithEvents PnlARight As Jhjo.Component.CPanel
    Friend WithEvents PnlBRight As Jhjo.Component.CPanel
    Friend WithEvents PnlBLeft As Jhjo.Component.CPanel
    Friend WithEvents PnlALeftBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBRightBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBLeftBar As Jhjo.Component.CPanel
    Friend WithEvents PnlARightBar As Jhjo.Component.CPanel
    Friend WithEvents PnlALeftToolBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBRightToolBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBLeftToolBar As Jhjo.Component.CPanel
    Friend WithEvents PnlARightToolBar As Jhjo.Component.CPanel
    Friend WithEvents PnlALeftStatusBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBRightStatusBar As Jhjo.Component.CPanel
    Friend WithEvents PnlBLeftStatusBar As Jhjo.Component.CPanel
    Friend WithEvents PnlARightStatusBar As Jhjo.Component.CPanel
    Friend WithEvents CdtBRight As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents CdtBLeft As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents CdtARight As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents CdtALeft As Cognex.VisionPro.CogDisplayToolbarV2
    Friend WithEvents CdsBRight As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents CdsBLeft As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents CdsARight As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents CdsALeft As Cognex.VisionPro.CogDisplayStatusBarV2
    Friend WithEvents LblTitleBRight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBLeft As Jhjo.Component.CLabel
    Friend WithEvents LblTitleARight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleALeft As Jhjo.Component.CLabel
    Friend WithEvents CdpARight As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents CdpALeft As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents PnlCamera As Jhjo.Component.CPanel
    Friend WithEvents LblTitleCameraOption As Jhjo.Component.CLabel
    Friend WithEvents LblTitleCamera As Jhjo.Component.CLabel
    Friend WithEvents LblTitleExpoTime As Jhjo.Component.CLabel
    Friend WithEvents LblTitleGain As Jhjo.Component.CLabel
    Friend WithEvents CmbCamera As System.Windows.Forms.ComboBox
    Friend WithEvents NudExpoTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudGain As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnApplyCamera As System.Windows.Forms.Button
    Friend WithEvents BtnALeftClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnALeftShowChecker As System.Windows.Forms.Button
    Friend WithEvents BtnBRightClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnBRightShowChecker As System.Windows.Forms.Button
    Friend WithEvents BtnBLeftClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnBLeftShowChecker As System.Windows.Forms.Button
    Friend WithEvents BtnARightClearChecker As System.Windows.Forms.Button
    Friend WithEvents BtnARightShowChecker As System.Windows.Forms.Button
    Friend WithEvents CPanel1 As Jhjo.Component.CPanel
    Friend WithEvents LblTitleCalibInfo As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAT As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAXY As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBlank As Jhjo.Component.CLabel
    Friend WithEvents LblTitlePoint As Jhjo.Component.CLabel
    Friend WithEvents LblTitleSection As Jhjo.Component.CLabel
    Friend WithEvents NudAPointT As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudASectionT As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAPointXY As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudASectionXY As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblTitleBT As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBXY As Jhjo.Component.CLabel
    Friend WithEvents NudBPointT As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBPointXY As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBSectionT As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBSectionXY As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnApplyCalibInfo As System.Windows.Forms.Button
    Friend WithEvents CPanel2 As Jhjo.Component.CPanel
    Friend WithEvents LblTitleAlignmentROI As Jhjo.Component.CLabel
    Friend WithEvents NudROIWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblTitleROIWidth As Jhjo.Component.CLabel
    Friend WithEvents NudROIHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblTitleROIHeight As Jhjo.Component.CLabel
    Friend WithEvents BtnROIShape As System.Windows.Forms.Button
    Friend WithEvents LblTitleROIKind As Jhjo.Component.CLabel
    Friend WithEvents ChkROIKind As System.Windows.Forms.CheckBox
    Friend WithEvents BtnROICenter As System.Windows.Forms.Button
    Friend WithEvents LblTitleROICamera As Jhjo.Component.CLabel
    Friend WithEvents CmbROIView As System.Windows.Forms.ComboBox
    Friend WithEvents BtnROIApply As System.Windows.Forms.Button
    Friend WithEvents BtnROIGoBack As System.Windows.Forms.Button
    Friend WithEvents CdpBRight As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents CdpBLeft As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents BtnForceStop As System.Windows.Forms.Button
    Friend WithEvents LblTitleAlignmentOption As Jhjo.Component.CLabel
    Friend WithEvents BtnApplyAlignment As System.Windows.Forms.Button
    Friend WithEvents LblMaxRetry As Jhjo.Component.CLabel
    Friend WithEvents NudMaxRetry As System.Windows.Forms.NumericUpDown

End Class
