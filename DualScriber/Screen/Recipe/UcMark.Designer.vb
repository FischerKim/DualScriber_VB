<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcMark
    Inherits DualScriber.UcSubRecipe

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcMark))
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.CdpTrain = New Cognex.VisionPro.Display.CogDisplay()
        Me.LblTitlePolarity = New Jhjo.Component.CLabel()
        Me.LblTitleClutter = New Jhjo.Component.CLabel()
        Me.BtnTrainROI = New System.Windows.Forms.Button()
        Me.ChkPolarity = New System.Windows.Forms.CheckBox()
        Me.ChkClutter = New System.Windows.Forms.CheckBox()
        Me.LblTitleAcceptTheshold = New Jhjo.Component.CLabel()
        Me.LblTitleCoarseTheshold = New Jhjo.Component.CLabel()
        Me.NudAcceptThreshold = New System.Windows.Forms.NumericUpDown()
        Me.NudCoarseTheshold = New System.Windows.Forms.NumericUpDown()
        Me.ChkCoarseThreshold = New System.Windows.Forms.CheckBox()
        CType(Me.CdpTrain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAcceptThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudCoarseTheshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.DimGray
        Me.LblTitle.BDrawBorderBottom = True
        Me.LblTitle.BDrawBorderLeft = True
        Me.LblTitle.BDrawBorderRight = True
        Me.LblTitle.BDrawBorderTop = True
        Me.LblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitle.ForeColor = System.Drawing.Color.White
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.OColor = System.Drawing.Color.Black
        Me.LblTitle.Size = New System.Drawing.Size(393, 40)
        Me.LblTitle.TabIndex = 2
        Me.LblTitle.Text = "Mark"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CdpTrain
        '
        Me.CdpTrain.ColorMapLowerClipColor = System.Drawing.Color.Black
        Me.CdpTrain.ColorMapLowerRoiLimit = 0.0R
        Me.CdpTrain.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None
        Me.CdpTrain.ColorMapUpperClipColor = System.Drawing.Color.Black
        Me.CdpTrain.ColorMapUpperRoiLimit = 1.0R
        Me.CdpTrain.DoubleTapZoomCycleLength = 2
        Me.CdpTrain.DoubleTapZoomSensitivity = 2.5R
        Me.CdpTrain.Location = New System.Drawing.Point(0, 40)
        Me.CdpTrain.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpTrain.MouseWheelSensitivity = 1.0R
        Me.CdpTrain.Name = "CdpTrain"
        Me.CdpTrain.OcxState = CType(resources.GetObject("CdpTrain.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpTrain.Size = New System.Drawing.Size(393, 315)
        Me.CdpTrain.TabIndex = 7
        Me.CdpTrain.Tag = "A LEFT"
        '
        'LblTitlePolarity
        '
        Me.LblTitlePolarity.BackColor = System.Drawing.Color.DimGray
        Me.LblTitlePolarity.BDrawBorderBottom = True
        Me.LblTitlePolarity.BDrawBorderLeft = True
        Me.LblTitlePolarity.BDrawBorderRight = True
        Me.LblTitlePolarity.BDrawBorderTop = True
        Me.LblTitlePolarity.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitlePolarity.ForeColor = System.Drawing.Color.White
        Me.LblTitlePolarity.Location = New System.Drawing.Point(0, 405)
        Me.LblTitlePolarity.Name = "LblTitlePolarity"
        Me.LblTitlePolarity.OColor = System.Drawing.Color.Black
        Me.LblTitlePolarity.Size = New System.Drawing.Size(180, 40)
        Me.LblTitlePolarity.TabIndex = 8
        Me.LblTitlePolarity.Text = "Polarity"
        Me.LblTitlePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblTitlePolarity.Visible = False
        '
        'LblTitleClutter
        '
        Me.LblTitleClutter.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleClutter.BDrawBorderBottom = True
        Me.LblTitleClutter.BDrawBorderLeft = True
        Me.LblTitleClutter.BDrawBorderRight = True
        Me.LblTitleClutter.BDrawBorderTop = False
        Me.LblTitleClutter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleClutter.ForeColor = System.Drawing.Color.White
        Me.LblTitleClutter.Location = New System.Drawing.Point(0, 525)
        Me.LblTitleClutter.Name = "LblTitleClutter"
        Me.LblTitleClutter.OColor = System.Drawing.Color.Black
        Me.LblTitleClutter.Size = New System.Drawing.Size(180, 40)
        Me.LblTitleClutter.TabIndex = 8
        Me.LblTitleClutter.Text = "Clutter Scoring"
        Me.LblTitleClutter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnTrainROI
        '
        Me.BtnTrainROI.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnTrainROI.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnTrainROI.ForeColor = System.Drawing.Color.White
        Me.BtnTrainROI.Location = New System.Drawing.Point(240, 358)
        Me.BtnTrainROI.Name = "BtnTrainROI"
        Me.BtnTrainROI.Size = New System.Drawing.Size(150, 46)
        Me.BtnTrainROI.TabIndex = 9
        Me.BtnTrainROI.Text = "Image Grab"
        Me.BtnTrainROI.UseVisualStyleBackColor = False
        '
        'ChkPolarity
        '
        Me.ChkPolarity.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkPolarity.BackColor = System.Drawing.Color.SteelBlue
        Me.ChkPolarity.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.ChkPolarity.ForeColor = System.Drawing.Color.White
        Me.ChkPolarity.Location = New System.Drawing.Point(186, 405)
        Me.ChkPolarity.Name = "ChkPolarity"
        Me.ChkPolarity.Size = New System.Drawing.Size(203, 40)
        Me.ChkPolarity.TabIndex = 19
        Me.ChkPolarity.Text = "Apply"
        Me.ChkPolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkPolarity.UseVisualStyleBackColor = False
        Me.ChkPolarity.Visible = False
        '
        'ChkClutter
        '
        Me.ChkClutter.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkClutter.BackColor = System.Drawing.Color.SteelBlue
        Me.ChkClutter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.ChkClutter.ForeColor = System.Drawing.Color.White
        Me.ChkClutter.Location = New System.Drawing.Point(186, 525)
        Me.ChkClutter.Name = "ChkClutter"
        Me.ChkClutter.Size = New System.Drawing.Size(203, 40)
        Me.ChkClutter.TabIndex = 19
        Me.ChkClutter.Text = "Not Use"
        Me.ChkClutter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkClutter.UseVisualStyleBackColor = False
        '
        'LblTitleAcceptTheshold
        '
        Me.LblTitleAcceptTheshold.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAcceptTheshold.BDrawBorderBottom = True
        Me.LblTitleAcceptTheshold.BDrawBorderLeft = True
        Me.LblTitleAcceptTheshold.BDrawBorderRight = True
        Me.LblTitleAcceptTheshold.BDrawBorderTop = False
        Me.LblTitleAcceptTheshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAcceptTheshold.ForeColor = System.Drawing.Color.White
        Me.LblTitleAcceptTheshold.Location = New System.Drawing.Point(0, 445)
        Me.LblTitleAcceptTheshold.Name = "LblTitleAcceptTheshold"
        Me.LblTitleAcceptTheshold.OColor = System.Drawing.Color.Black
        Me.LblTitleAcceptTheshold.Size = New System.Drawing.Size(180, 40)
        Me.LblTitleAcceptTheshold.TabIndex = 8
        Me.LblTitleAcceptTheshold.Text = "Accept Thres."
        Me.LblTitleAcceptTheshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleCoarseTheshold
        '
        Me.LblTitleCoarseTheshold.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCoarseTheshold.BDrawBorderBottom = True
        Me.LblTitleCoarseTheshold.BDrawBorderLeft = True
        Me.LblTitleCoarseTheshold.BDrawBorderRight = True
        Me.LblTitleCoarseTheshold.BDrawBorderTop = False
        Me.LblTitleCoarseTheshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCoarseTheshold.ForeColor = System.Drawing.Color.White
        Me.LblTitleCoarseTheshold.Location = New System.Drawing.Point(0, 485)
        Me.LblTitleCoarseTheshold.Name = "LblTitleCoarseTheshold"
        Me.LblTitleCoarseTheshold.OColor = System.Drawing.Color.Black
        Me.LblTitleCoarseTheshold.Size = New System.Drawing.Size(180, 40)
        Me.LblTitleCoarseTheshold.TabIndex = 8
        Me.LblTitleCoarseTheshold.Text = "Coarse Thres."
        Me.LblTitleCoarseTheshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudAcceptThreshold
        '
        Me.NudAcceptThreshold.DecimalPlaces = 2
        Me.NudAcceptThreshold.Font = New System.Drawing.Font("맑은 고딕", 15.0!)
        Me.NudAcceptThreshold.Location = New System.Drawing.Point(186, 449)
        Me.NudAcceptThreshold.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudAcceptThreshold.Name = "NudAcceptThreshold"
        Me.NudAcceptThreshold.Size = New System.Drawing.Size(204, 34)
        Me.NudAcceptThreshold.TabIndex = 46
        Me.NudAcceptThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudAcceptThreshold.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudCoarseTheshold
        '
        Me.NudCoarseTheshold.DecimalPlaces = 2
        Me.NudCoarseTheshold.Font = New System.Drawing.Font("맑은 고딕", 15.0!)
        Me.NudCoarseTheshold.Location = New System.Drawing.Point(207, 488)
        Me.NudCoarseTheshold.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudCoarseTheshold.Name = "NudCoarseTheshold"
        Me.NudCoarseTheshold.Size = New System.Drawing.Size(183, 34)
        Me.NudCoarseTheshold.TabIndex = 47
        Me.NudCoarseTheshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudCoarseTheshold.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ChkCoarseThreshold
        '
        Me.ChkCoarseThreshold.AutoSize = True
        Me.ChkCoarseThreshold.Location = New System.Drawing.Point(186, 498)
        Me.ChkCoarseThreshold.Name = "ChkCoarseThreshold"
        Me.ChkCoarseThreshold.Size = New System.Drawing.Size(15, 14)
        Me.ChkCoarseThreshold.TabIndex = 48
        Me.ChkCoarseThreshold.UseVisualStyleBackColor = True
        '
        'UcMark
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ChkCoarseThreshold)
        Me.Controls.Add(Me.NudCoarseTheshold)
        Me.Controls.Add(Me.NudAcceptThreshold)
        Me.Controls.Add(Me.ChkClutter)
        Me.Controls.Add(Me.ChkPolarity)
        Me.Controls.Add(Me.BtnTrainROI)
        Me.Controls.Add(Me.LblTitleCoarseTheshold)
        Me.Controls.Add(Me.LblTitleAcceptTheshold)
        Me.Controls.Add(Me.LblTitleClutter)
        Me.Controls.Add(Me.LblTitlePolarity)
        Me.Controls.Add(Me.CdpTrain)
        Me.Controls.Add(Me.LblTitle)
        Me.Name = "UcMark"
        CType(Me.CdpTrain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAcceptThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudCoarseTheshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents CdpTrain As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents LblTitlePolarity As Jhjo.Component.CLabel
    Friend WithEvents LblTitleClutter As Jhjo.Component.CLabel
    Friend WithEvents BtnTrainROI As System.Windows.Forms.Button
    Friend WithEvents ChkPolarity As System.Windows.Forms.CheckBox
    Friend WithEvents ChkClutter As System.Windows.Forms.CheckBox
    Friend WithEvents LblTitleAcceptTheshold As Jhjo.Component.CLabel
    Friend WithEvents LblTitleCoarseTheshold As Jhjo.Component.CLabel
    Private WithEvents NudAcceptThreshold As System.Windows.Forms.NumericUpDown
    Private WithEvents NudCoarseTheshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents ChkCoarseThreshold As System.Windows.Forms.CheckBox

End Class
