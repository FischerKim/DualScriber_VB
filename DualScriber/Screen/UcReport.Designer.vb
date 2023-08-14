<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcReport
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcReport))
        Me.PnlTitle = New Jhjo.Component.CPanel
        Me.LblTitle = New Jhjo.Component.CLabel
        Me.PnlSearch = New Jhjo.Component.CPanel
        Me.DtpDate = New System.Windows.Forms.DateTimePicker
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.PnlReport = New Jhjo.Component.CPanel
        Me.DgvReport = New System.Windows.Forms.DataGridView
        Me.PnlImage = New Jhjo.Component.CPanel
        Me.PnlRight = New Jhjo.Component.CPanel
        Me.CdpRight = New Cognex.VisionPro.Display.CogDisplay
        Me.PnlLeft = New Jhjo.Component.CPanel
        Me.CdpLeft = New Cognex.VisionPro.Display.CogDisplay
        Me.ColDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColRecipe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColStage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColItem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColResult = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColEquipLeftX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColEquipRightX = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColEquipY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColEquipT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PnlTitle.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
        Me.PnlReport.SuspendLayout()
        CType(Me.DgvReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlImage.SuspendLayout()
        Me.PnlRight.SuspendLayout()
        CType(Me.CdpRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlLeft.SuspendLayout()
        CType(Me.CdpLeft, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.OColor = System.Drawing.Color.Black
        Me.LblTitle.Size = New System.Drawing.Size(1280, 40)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Report"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlSearch
        '
        Me.PnlSearch.BDrawBorderBottom = True
        Me.PnlSearch.BDrawBorderLeft = False
        Me.PnlSearch.BDrawBorderRight = False
        Me.PnlSearch.BDrawBorderTop = False
        Me.PnlSearch.Controls.Add(Me.DtpDate)
        Me.PnlSearch.Controls.Add(Me.BtnSearch)
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(0, 40)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(1280, 50)
        Me.PnlSearch.TabIndex = 6
        '
        'DtpDate
        '
        Me.DtpDate.CustomFormat = "yyyy-MM-dd"
        Me.DtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDate.Location = New System.Drawing.Point(5, 9)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(1116, 30)
        Me.DtpDate.TabIndex = 7
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSearch.ForeColor = System.Drawing.Color.White
        Me.BtnSearch.Location = New System.Drawing.Point(1127, 2)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(150, 45)
        Me.BtnSearch.TabIndex = 8
        Me.BtnSearch.Text = "Search"
        Me.BtnSearch.UseVisualStyleBackColor = False
        '
        'PnlReport
        '
        Me.PnlReport.BDrawBorderBottom = False
        Me.PnlReport.BDrawBorderLeft = False
        Me.PnlReport.BDrawBorderRight = False
        Me.PnlReport.BDrawBorderTop = False
        Me.PnlReport.Controls.Add(Me.DgvReport)
        Me.PnlReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlReport.Location = New System.Drawing.Point(0, 583)
        Me.PnlReport.Name = "PnlReport"
        Me.PnlReport.Size = New System.Drawing.Size(1280, 346)
        Me.PnlReport.TabIndex = 7
        '
        'DgvReport
        '
        Me.DgvReport.AllowUserToAddRows = False
        Me.DgvReport.AllowUserToDeleteRows = False
        Me.DgvReport.AllowUserToResizeColumns = False
        Me.DgvReport.AllowUserToResizeRows = False
        Me.DgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvReport.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColDateTime, Me.ColRecipe, Me.ColStage, Me.ColItem, Me.ColResult, Me.ColEquipLeftX, Me.ColEquipRightX, Me.ColEquipY, Me.ColEquipT})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvReport.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgvReport.Location = New System.Drawing.Point(0, 0)
        Me.DgvReport.MultiSelect = False
        Me.DgvReport.Name = "DgvReport"
        Me.DgvReport.RowHeadersVisible = False
        Me.DgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvReport.Size = New System.Drawing.Size(1280, 346)
        Me.DgvReport.TabIndex = 1
        Me.DgvReport.TabStop = False
        '
        'PnlImage
        '
        Me.PnlImage.BDrawBorderBottom = False
        Me.PnlImage.BDrawBorderLeft = False
        Me.PnlImage.BDrawBorderRight = False
        Me.PnlImage.BDrawBorderTop = False
        Me.PnlImage.Controls.Add(Me.PnlRight)
        Me.PnlImage.Controls.Add(Me.PnlLeft)
        Me.PnlImage.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlImage.Location = New System.Drawing.Point(0, 90)
        Me.PnlImage.Name = "PnlImage"
        Me.PnlImage.Size = New System.Drawing.Size(1280, 493)
        Me.PnlImage.TabIndex = 7
        '
        'PnlRight
        '
        Me.PnlRight.BDrawBorderBottom = False
        Me.PnlRight.BDrawBorderLeft = False
        Me.PnlRight.BDrawBorderRight = False
        Me.PnlRight.BDrawBorderTop = False
        Me.PnlRight.Controls.Add(Me.CdpRight)
        Me.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlRight.Location = New System.Drawing.Point(640, 0)
        Me.PnlRight.Name = "PnlRight"
        Me.PnlRight.Size = New System.Drawing.Size(640, 493)
        Me.PnlRight.TabIndex = 7
        '
        'CdpRight
        '
        Me.CdpRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpRight.Location = New System.Drawing.Point(0, 0)
        Me.CdpRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpRight.MouseWheelSensitivity = 1
        Me.CdpRight.Name = "CdpRight"
        Me.CdpRight.OcxState = CType(resources.GetObject("CdpRight.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpRight.Size = New System.Drawing.Size(640, 493)
        Me.CdpRight.TabIndex = 7
        '
        'PnlLeft
        '
        Me.PnlLeft.BDrawBorderBottom = False
        Me.PnlLeft.BDrawBorderLeft = False
        Me.PnlLeft.BDrawBorderRight = False
        Me.PnlLeft.BDrawBorderTop = False
        Me.PnlLeft.Controls.Add(Me.CdpLeft)
        Me.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.PnlLeft.Name = "PnlLeft"
        Me.PnlLeft.Size = New System.Drawing.Size(640, 493)
        Me.PnlLeft.TabIndex = 6
        '
        'CdpLeft
        '
        Me.CdpLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpLeft.Location = New System.Drawing.Point(0, 0)
        Me.CdpLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpLeft.MouseWheelSensitivity = 1
        Me.CdpLeft.Name = "CdpLeft"
        Me.CdpLeft.OcxState = CType(resources.GetObject("CdpLeft.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpLeft.Size = New System.Drawing.Size(640, 493)
        Me.CdpLeft.TabIndex = 7
        '
        'ColDateTime
        '
        Me.ColDateTime.DataPropertyName = "DATETIME"
        Me.ColDateTime.FillWeight = 14.0!
        Me.ColDateTime.HeaderText = "DATETIME"
        Me.ColDateTime.Name = "ColDateTime"
        '
        'ColRecipe
        '
        Me.ColRecipe.DataPropertyName = "RECIPE"
        Me.ColRecipe.FillWeight = 13.0!
        Me.ColRecipe.HeaderText = "RECIPE"
        Me.ColRecipe.Name = "ColRecipe"
        '
        'ColStage
        '
        Me.ColStage.DataPropertyName = "STAGE"
        Me.ColStage.FillWeight = 5.0!
        Me.ColStage.HeaderText = "STAGE"
        Me.ColStage.Name = "ColStage"
        '
        'ColItem
        '
        Me.ColItem.DataPropertyName = "ITEM"
        Me.ColItem.FillWeight = 9.0!
        Me.ColItem.HeaderText = "ITEM"
        Me.ColItem.Name = "ColItem"
        '
        'ColResult
        '
        Me.ColResult.DataPropertyName = "RESULT"
        Me.ColResult.FillWeight = 7.0!
        Me.ColResult.HeaderText = "RESULT"
        Me.ColResult.Name = "ColResult"
        '
        'ColEquipLeftX
        '
        Me.ColEquipLeftX.DataPropertyName = "ALIGNMENT_EQUIP_LEFT_X"
        Me.ColEquipLeftX.FillWeight = 9.0!
        Me.ColEquipLeftX.HeaderText = "LEFT X"
        Me.ColEquipLeftX.Name = "ColEquipLeftX"
        '
        'ColEquipRightX
        '
        Me.ColEquipRightX.DataPropertyName = "ALIGNMENT_EQUIP_RIGHT_X"
        Me.ColEquipRightX.FillWeight = 9.0!
        Me.ColEquipRightX.HeaderText = "RIGHT X"
        Me.ColEquipRightX.Name = "ColEquipRightX"
        '
        'ColEquipY
        '
        Me.ColEquipY.DataPropertyName = "ALIGNMENT_EQUIP_Y"
        Me.ColEquipY.FillWeight = 9.0!
        Me.ColEquipY.HeaderText = "Y"
        Me.ColEquipY.Name = "ColEquipY"
        '
        'ColEquipT
        '
        Me.ColEquipT.DataPropertyName = "ALIGNMENT_EQUIP_T"
        Me.ColEquipT.FillWeight = 9.0!
        Me.ColEquipT.HeaderText = "T"
        Me.ColEquipT.Name = "ColEquipT"
        '
        'UcReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlReport)
        Me.Controls.Add(Me.PnlImage)
        Me.Controls.Add(Me.PnlSearch)
        Me.Controls.Add(Me.PnlTitle)
        Me.Name = "UcReport"
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlReport.ResumeLayout(False)
        CType(Me.DgvReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlImage.ResumeLayout(False)
        Me.PnlRight.ResumeLayout(False)
        CType(Me.CdpRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlLeft.ResumeLayout(False)
        CType(Me.CdpLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents PnlSearch As Jhjo.Component.CPanel
    Friend WithEvents DtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents PnlReport As Jhjo.Component.CPanel
    Friend WithEvents PnlImage As Jhjo.Component.CPanel
    Friend WithEvents PnlRight As Jhjo.Component.CPanel
    Friend WithEvents PnlLeft As Jhjo.Component.CPanel
    Friend WithEvents CdpRight As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents CdpLeft As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents DgvReport As System.Windows.Forms.DataGridView
    Friend WithEvents ColDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRecipe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEquipLeftX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEquipRightX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEquipY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEquipT As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
