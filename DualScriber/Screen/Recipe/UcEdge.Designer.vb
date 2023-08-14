<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcEdge
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
        Me.LblTitle = New Jhjo.Component.CLabel
        Me.LblTitlePolarity = New Jhjo.Component.CLabel
        Me.CmbPolarity = New System.Windows.Forms.ComboBox
        Me.LblTitleContrastThreshold = New Jhjo.Component.CLabel
        Me.LblTitleHalfPixel = New Jhjo.Component.CLabel
        Me.NudContrastThreshold = New System.Windows.Forms.NumericUpDown
        Me.NudHalfPixel = New System.Windows.Forms.NumericUpDown
        Me.BtnInspect = New System.Windows.Forms.Button
        CType(Me.NudContrastThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudHalfPixel, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LblTitle.TabIndex = 3
        Me.LblTitle.Text = "Edge"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitlePolarity
        '
        Me.LblTitlePolarity.BackColor = System.Drawing.Color.DimGray
        Me.LblTitlePolarity.BDrawBorderBottom = True
        Me.LblTitlePolarity.BDrawBorderLeft = True
        Me.LblTitlePolarity.BDrawBorderRight = True
        Me.LblTitlePolarity.BDrawBorderTop = False
        Me.LblTitlePolarity.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitlePolarity.ForeColor = System.Drawing.Color.White
        Me.LblTitlePolarity.Location = New System.Drawing.Point(0, 40)
        Me.LblTitlePolarity.Name = "LblTitlePolarity"
        Me.LblTitlePolarity.OColor = System.Drawing.Color.Black
        Me.LblTitlePolarity.Size = New System.Drawing.Size(180, 40)
        Me.LblTitlePolarity.TabIndex = 9
        Me.LblTitlePolarity.Text = "Polarity"
        Me.LblTitlePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmbPolarity
        '
        Me.CmbPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbPolarity.Font = New System.Drawing.Font("맑은 고딕", 15.0!)
        Me.CmbPolarity.FormattingEnabled = True
        Me.CmbPolarity.Items.AddRange(New Object() {"DarkToLight", "LightToDark", "DontCare"})
        Me.CmbPolarity.Location = New System.Drawing.Point(186, 42)
        Me.CmbPolarity.Name = "CmbPolarity"
        Me.CmbPolarity.Size = New System.Drawing.Size(204, 36)
        Me.CmbPolarity.TabIndex = 33
        '
        'LblTitleContrastThreshold
        '
        Me.LblTitleContrastThreshold.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleContrastThreshold.BDrawBorderBottom = True
        Me.LblTitleContrastThreshold.BDrawBorderLeft = True
        Me.LblTitleContrastThreshold.BDrawBorderRight = True
        Me.LblTitleContrastThreshold.BDrawBorderTop = False
        Me.LblTitleContrastThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleContrastThreshold.ForeColor = System.Drawing.Color.White
        Me.LblTitleContrastThreshold.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleContrastThreshold.Name = "LblTitleContrastThreshold"
        Me.LblTitleContrastThreshold.OColor = System.Drawing.Color.Black
        Me.LblTitleContrastThreshold.Size = New System.Drawing.Size(180, 40)
        Me.LblTitleContrastThreshold.TabIndex = 9
        Me.LblTitleContrastThreshold.Text = "Con. Threshold"
        Me.LblTitleContrastThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleHalfPixel
        '
        Me.LblTitleHalfPixel.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleHalfPixel.BDrawBorderBottom = True
        Me.LblTitleHalfPixel.BDrawBorderLeft = True
        Me.LblTitleHalfPixel.BDrawBorderRight = True
        Me.LblTitleHalfPixel.BDrawBorderTop = False
        Me.LblTitleHalfPixel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleHalfPixel.ForeColor = System.Drawing.Color.White
        Me.LblTitleHalfPixel.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleHalfPixel.Name = "LblTitleHalfPixel"
        Me.LblTitleHalfPixel.OColor = System.Drawing.Color.Black
        Me.LblTitleHalfPixel.Size = New System.Drawing.Size(180, 40)
        Me.LblTitleHalfPixel.TabIndex = 9
        Me.LblTitleHalfPixel.Text = "Half Pixel"
        Me.LblTitleHalfPixel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudContrastThreshold
        '
        Me.NudContrastThreshold.Font = New System.Drawing.Font("맑은 고딕", 15.0!)
        Me.NudContrastThreshold.Location = New System.Drawing.Point(186, 83)
        Me.NudContrastThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NudContrastThreshold.Name = "NudContrastThreshold"
        Me.NudContrastThreshold.Size = New System.Drawing.Size(204, 34)
        Me.NudContrastThreshold.TabIndex = 45
        Me.NudContrastThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudContrastThreshold.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NudHalfPixel
        '
        Me.NudHalfPixel.Font = New System.Drawing.Font("맑은 고딕", 15.0!)
        Me.NudHalfPixel.Location = New System.Drawing.Point(186, 123)
        Me.NudHalfPixel.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudHalfPixel.Name = "NudHalfPixel"
        Me.NudHalfPixel.Size = New System.Drawing.Size(204, 34)
        Me.NudHalfPixel.TabIndex = 45
        Me.NudHalfPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudHalfPixel.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BtnInspect
        '
        Me.BtnInspect.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnInspect.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnInspect.ForeColor = System.Drawing.Color.White
        Me.BtnInspect.Location = New System.Drawing.Point(240, 163)
        Me.BtnInspect.Name = "BtnInspect"
        Me.BtnInspect.Size = New System.Drawing.Size(150, 45)
        Me.BtnInspect.TabIndex = 46
        Me.BtnInspect.Text = "Inspect"
        Me.BtnInspect.UseVisualStyleBackColor = False
        '
        'UcEdge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BtnInspect)
        Me.Controls.Add(Me.NudHalfPixel)
        Me.Controls.Add(Me.NudContrastThreshold)
        Me.Controls.Add(Me.CmbPolarity)
        Me.Controls.Add(Me.LblTitleHalfPixel)
        Me.Controls.Add(Me.LblTitleContrastThreshold)
        Me.Controls.Add(Me.LblTitlePolarity)
        Me.Controls.Add(Me.LblTitle)
        Me.Name = "UcEdge"
        CType(Me.NudContrastThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudHalfPixel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents LblTitlePolarity As Jhjo.Component.CLabel
    Private WithEvents CmbPolarity As System.Windows.Forms.ComboBox
    Friend WithEvents LblTitleContrastThreshold As Jhjo.Component.CLabel
    Friend WithEvents LblTitleHalfPixel As Jhjo.Component.CLabel
    Private WithEvents NudContrastThreshold As System.Windows.Forms.NumericUpDown
    Private WithEvents NudHalfPixel As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnInspect As System.Windows.Forms.Button

End Class
