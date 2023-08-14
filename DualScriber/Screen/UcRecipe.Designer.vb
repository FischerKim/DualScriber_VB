<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcRecipe
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UcRecipe))
        Me.PnlList = New Jhjo.Component.CPanel
        Me.LtbList = New System.Windows.Forms.ListBox
        Me.PnlEdit = New Jhjo.Component.CPanel
        Me.BtnRename = New System.Windows.Forms.Button
        Me.NudID = New System.Windows.Forms.NumericUpDown
        Me.LblTitleID = New Jhjo.Component.CLabel
        Me.LblTitleName = New Jhjo.Component.CLabel
        Me.BtnApply = New System.Windows.Forms.Button
        Me.BtnCopy = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnModify = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.PnlLeft = New Jhjo.Component.CPanel
        Me.LblTitle = New Jhjo.Component.CLabel
        Me.PnlTitle = New Jhjo.Component.CPanel
        Me.PnlRight = New Jhjo.Component.CPanel
        Me.TabDetail = New System.Windows.Forms.TabControl
        Me.PageTool = New System.Windows.Forms.TabPage
        Me.CdpDesign = New Cognex.VisionPro.Display.CogDisplay
        Me.PnlScreen = New Jhjo.Component.CPanel
        Me.PnlToolEdge = New Jhjo.Component.CPanel
        Me.CceCaliper = New Cognex.VisionPro.Caliper.CogCaliperEditV2
        Me.PnlToolMark = New Jhjo.Component.CPanel
        Me.CpePattern = New Cognex.VisionPro.PMAlign.CogPMAlignEditV2
        Me.PageLimit = New System.Windows.Forms.TabPage
        Me.PnlLimit = New Jhjo.Component.CPanel
        Me.PnlBLimit = New Jhjo.Component.CPanel
        Me.PnlBEdgeLimit = New Jhjo.Component.CPanel
        Me.PnlBEdgeRightLimit = New Jhjo.Component.CPanel
        Me.LblTitleBEdgeRightLimit = New Jhjo.Component.CLabel
        Me.LblTitleBEdgeRightBottomMin = New Jhjo.Component.CLabel
        Me.NudBEdgeRightTopMin = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBEdgeRightBottomMax = New Jhjo.Component.CLabel
        Me.LblTitleBEdgeRightTopMin = New Jhjo.Component.CLabel
        Me.NudBEdgeRightBottomMax = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBEdgeRightTopMax = New Jhjo.Component.CLabel
        Me.NudBEdgeRightBottomMin = New System.Windows.Forms.NumericUpDown
        Me.NudBEdgeRightTopMax = New System.Windows.Forms.NumericUpDown
        Me.PnlBEdgeLeftLimit = New Jhjo.Component.CPanel
        Me.LblTitleBEdgeLeftLimit = New Jhjo.Component.CLabel
        Me.LblTitleBEdgeLeftBottomMin = New Jhjo.Component.CLabel
        Me.NudBEdgeLeftTopMin = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBEdgeLeftBottomMax = New Jhjo.Component.CLabel
        Me.LblTitleBEdgeLeftTopMin = New Jhjo.Component.CLabel
        Me.NudBEdgeLeftBottomMax = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBEdgeLeftTopMax = New Jhjo.Component.CLabel
        Me.NudBEdgeLeftBottomMin = New System.Windows.Forms.NumericUpDown
        Me.NudBEdgeLeftTopMax = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBEdgeLimit = New Jhjo.Component.CLabel
        Me.PnlBAlignmentLimit = New Jhjo.Component.CPanel
        Me.LblTitleBAlignmentLimit = New Jhjo.Component.CLabel
        Me.LblTitleBAlignmentRightXLimit = New Jhjo.Component.CLabel
        Me.LblTitleBAlignmentLeftXLimit = New Jhjo.Component.CLabel
        Me.LblTitleBAlignmentYLimit = New Jhjo.Component.CLabel
        Me.NudBAlignmentTLimit = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBAlignmentTLimit = New Jhjo.Component.CLabel
        Me.NudBAlignmentLeftXLimit = New System.Windows.Forms.NumericUpDown
        Me.NudBAlignmentRightXLimit = New System.Windows.Forms.NumericUpDown
        Me.NudBAlignmentYLimit = New System.Windows.Forms.NumericUpDown
        Me.LblTitleBLimit = New Jhjo.Component.CLabel
        Me.PnlALimit = New Jhjo.Component.CPanel
        Me.PnlAEdgeLimit = New Jhjo.Component.CPanel
        Me.PnlAEdgeRightLimit = New Jhjo.Component.CPanel
        Me.LblTitleAEdgeRightBottomMin = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeRightTopMin = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeRightBottomMax = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeRightTopMax = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeRightLimit = New Jhjo.Component.CLabel
        Me.NudAEdgeRightBottomMax = New System.Windows.Forms.NumericUpDown
        Me.NudAEdgeRightBottomMin = New System.Windows.Forms.NumericUpDown
        Me.NudAEdgeRightTopMin = New System.Windows.Forms.NumericUpDown
        Me.NudAEdgeRightTopMax = New System.Windows.Forms.NumericUpDown
        Me.PnlAEdgeLeftLimit = New Jhjo.Component.CPanel
        Me.LblTitleAEdgeLeftLimit = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeLeftBottomMin = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeLeftTopMin = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeLeftBottomMax = New Jhjo.Component.CLabel
        Me.LblTitleAEdgeLeftTopMax = New Jhjo.Component.CLabel
        Me.NudAEdgeLeftBottomMax = New System.Windows.Forms.NumericUpDown
        Me.NudAEdgeLeftBottomMin = New System.Windows.Forms.NumericUpDown
        Me.NudAEdgeLeftTopMax = New System.Windows.Forms.NumericUpDown
        Me.NudAEdgeLeftTopMin = New System.Windows.Forms.NumericUpDown
        Me.LblTitleAEdgeLimit = New Jhjo.Component.CLabel
        Me.PnlAAlignmentLimit = New Jhjo.Component.CPanel
        Me.LblTitleAAlignmentLeftXLimit = New Jhjo.Component.CLabel
        Me.LblTitleAAlignmentLimit = New Jhjo.Component.CLabel
        Me.LblTitleAAlignmentYLimit = New Jhjo.Component.CLabel
        Me.LblTitleAAlignmentTLimit = New Jhjo.Component.CLabel
        Me.NudAAlignmentLeftXLimit = New System.Windows.Forms.NumericUpDown
        Me.LblTitleAAlignmentRightXLimit = New Jhjo.Component.CLabel
        Me.NudAAlignmentRightXLimit = New System.Windows.Forms.NumericUpDown
        Me.NudAAlignmentYLimit = New System.Windows.Forms.NumericUpDown
        Me.NudAAlignmentTLimit = New System.Windows.Forms.NumericUpDown
        Me.LblTitleALimit = New Jhjo.Component.CLabel
        Me.PnlKind = New Jhjo.Component.CPanel
        Me.PnlKind3 = New Jhjo.Component.CPanel
        Me.PnlMark = New Jhjo.Component.CPanel
        Me.PnlMark4 = New Jhjo.Component.CPanel
        Me.CdpMark4 = New Cognex.VisionPro.Display.CogDisplay
        Me.PnlMark3 = New Jhjo.Component.CPanel
        Me.CdpMark3 = New Cognex.VisionPro.Display.CogDisplay
        Me.PnlMark2 = New Jhjo.Component.CPanel
        Me.CdpMark2 = New Cognex.VisionPro.Display.CogDisplay
        Me.PnlMark1 = New Jhjo.Component.CPanel
        Me.CdpMark1 = New Cognex.VisionPro.Display.CogDisplay
        Me.PnlIndex = New Jhjo.Component.CPanel
        Me.LblTitleIndex = New Jhjo.Component.CLabel
        Me.BtnIndex4 = New System.Windows.Forms.Button
        Me.BtnIndex3 = New System.Windows.Forms.Button
        Me.BtnIndex2 = New System.Windows.Forms.Button
        Me.BtnIndex1 = New System.Windows.Forms.Button
        Me.PnlKind1 = New Jhjo.Component.CPanel
        Me.PnlEtc = New Jhjo.Component.CPanel
        Me.LblTitleEtc = New Jhjo.Component.CLabel
        Me.BtnToolDetail = New System.Windows.Forms.Button
        Me.BtnImageGrab = New System.Windows.Forms.Button
        Me.PnlTool = New Jhjo.Component.CPanel
        Me.LblTitleTool = New Jhjo.Component.CLabel
        Me.BtnToolEdge = New System.Windows.Forms.Button
        Me.BtnToolMark = New System.Windows.Forms.Button
        Me.PnlCamera = New Jhjo.Component.CPanel
        Me.LblTitleCamera = New Jhjo.Component.CLabel
        Me.BtnCameraBRight = New System.Windows.Forms.Button
        Me.BtnCameraARight = New System.Windows.Forms.Button
        Me.BtnCameraBLeft = New System.Windows.Forms.Button
        Me.BtnCameraALeft = New System.Windows.Forms.Button
        Me.PnlList.SuspendLayout()
        Me.PnlEdit.SuspendLayout()
        CType(Me.NudID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlLeft.SuspendLayout()
        Me.PnlTitle.SuspendLayout()
        Me.PnlRight.SuspendLayout()
        Me.TabDetail.SuspendLayout()
        Me.PageTool.SuspendLayout()
        CType(Me.CdpDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlToolEdge.SuspendLayout()
        CType(Me.CceCaliper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlToolMark.SuspendLayout()
        CType(Me.CpePattern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PageLimit.SuspendLayout()
        Me.PnlLimit.SuspendLayout()
        Me.PnlBLimit.SuspendLayout()
        Me.PnlBEdgeLimit.SuspendLayout()
        Me.PnlBEdgeRightLimit.SuspendLayout()
        CType(Me.NudBEdgeRightTopMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBEdgeRightBottomMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBEdgeRightBottomMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBEdgeRightTopMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBEdgeLeftLimit.SuspendLayout()
        CType(Me.NudBEdgeLeftTopMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBEdgeLeftBottomMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBEdgeLeftBottomMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBEdgeLeftTopMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBAlignmentLimit.SuspendLayout()
        CType(Me.NudBAlignmentTLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBAlignmentLeftXLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBAlignmentRightXLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBAlignmentYLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlALimit.SuspendLayout()
        Me.PnlAEdgeLimit.SuspendLayout()
        Me.PnlAEdgeRightLimit.SuspendLayout()
        CType(Me.NudAEdgeRightBottomMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAEdgeRightBottomMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAEdgeRightTopMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAEdgeRightTopMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAEdgeLeftLimit.SuspendLayout()
        CType(Me.NudAEdgeLeftBottomMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAEdgeLeftBottomMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAEdgeLeftTopMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAEdgeLeftTopMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlAAlignmentLimit.SuspendLayout()
        CType(Me.NudAAlignmentLeftXLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAAlignmentRightXLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAAlignmentYLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudAAlignmentTLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlKind.SuspendLayout()
        Me.PnlKind3.SuspendLayout()
        Me.PnlMark.SuspendLayout()
        Me.PnlMark4.SuspendLayout()
        CType(Me.CdpMark4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMark3.SuspendLayout()
        CType(Me.CdpMark3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMark2.SuspendLayout()
        CType(Me.CdpMark2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlMark1.SuspendLayout()
        CType(Me.CdpMark1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlIndex.SuspendLayout()
        Me.PnlKind1.SuspendLayout()
        Me.PnlEtc.SuspendLayout()
        Me.PnlTool.SuspendLayout()
        Me.PnlCamera.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlList
        '
        Me.PnlList.BDrawBorderBottom = False
        Me.PnlList.BDrawBorderLeft = False
        Me.PnlList.BDrawBorderRight = False
        Me.PnlList.BDrawBorderTop = False
        Me.PnlList.Controls.Add(Me.LtbList)
        Me.PnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlList.Location = New System.Drawing.Point(0, 0)
        Me.PnlList.Name = "PnlList"
        Me.PnlList.Size = New System.Drawing.Size(200, 400)
        Me.PnlList.TabIndex = 4
        '
        'LtbList
        '
        Me.LtbList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LtbList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LtbList.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.LtbList.FormattingEnabled = True
        Me.LtbList.IntegralHeight = False
        Me.LtbList.ItemHeight = 16
        Me.LtbList.Location = New System.Drawing.Point(0, 0)
        Me.LtbList.Name = "LtbList"
        Me.LtbList.Size = New System.Drawing.Size(200, 400)
        Me.LtbList.TabIndex = 5
        '
        'PnlEdit
        '
        Me.PnlEdit.BDrawBorderBottom = False
        Me.PnlEdit.BDrawBorderLeft = False
        Me.PnlEdit.BDrawBorderRight = False
        Me.PnlEdit.BDrawBorderTop = True
        Me.PnlEdit.Controls.Add(Me.BtnRename)
        Me.PnlEdit.Controls.Add(Me.NudID)
        Me.PnlEdit.Controls.Add(Me.LblTitleID)
        Me.PnlEdit.Controls.Add(Me.LblTitleName)
        Me.PnlEdit.Controls.Add(Me.BtnApply)
        Me.PnlEdit.Controls.Add(Me.BtnCopy)
        Me.PnlEdit.Controls.Add(Me.BtnCancel)
        Me.PnlEdit.Controls.Add(Me.BtnSave)
        Me.PnlEdit.Controls.Add(Me.BtnDelete)
        Me.PnlEdit.Controls.Add(Me.BtnModify)
        Me.PnlEdit.Controls.Add(Me.BtnAdd)
        Me.PnlEdit.Controls.Add(Me.TxtName)
        Me.PnlEdit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlEdit.Location = New System.Drawing.Point(0, 400)
        Me.PnlEdit.Name = "PnlEdit"
        Me.PnlEdit.Size = New System.Drawing.Size(200, 489)
        Me.PnlEdit.TabIndex = 3
        '
        'BtnRename
        '
        Me.BtnRename.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnRename.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnRename.ForeColor = System.Drawing.Color.White
        Me.BtnRename.Location = New System.Drawing.Point(5, 338)
        Me.BtnRename.Name = "BtnRename"
        Me.BtnRename.Size = New System.Drawing.Size(192, 46)
        Me.BtnRename.TabIndex = 9
        Me.BtnRename.Text = "ReName"
        Me.BtnRename.UseVisualStyleBackColor = False
        '
        'NudID
        '
        Me.NudID.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudID.Location = New System.Drawing.Point(86, 5)
        Me.NudID.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.NudID.Name = "NudID"
        Me.NudID.Size = New System.Drawing.Size(110, 30)
        Me.NudID.TabIndex = 6
        Me.NudID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleID
        '
        Me.LblTitleID.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleID.BDrawBorderBottom = True
        Me.LblTitleID.BDrawBorderLeft = True
        Me.LblTitleID.BDrawBorderRight = True
        Me.LblTitleID.BDrawBorderTop = False
        Me.LblTitleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleID.ForeColor = System.Drawing.Color.White
        Me.LblTitleID.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleID.Name = "LblTitleID"
        Me.LblTitleID.OColor = System.Drawing.Color.Black
        Me.LblTitleID.Size = New System.Drawing.Size(80, 40)
        Me.LblTitleID.TabIndex = 6
        Me.LblTitleID.Text = "ID"
        Me.LblTitleID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleName
        '
        Me.LblTitleName.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleName.BDrawBorderBottom = True
        Me.LblTitleName.BDrawBorderLeft = True
        Me.LblTitleName.BDrawBorderRight = True
        Me.LblTitleName.BDrawBorderTop = False
        Me.LblTitleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleName.ForeColor = System.Drawing.Color.White
        Me.LblTitleName.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleName.Name = "LblTitleName"
        Me.LblTitleName.OColor = System.Drawing.Color.Black
        Me.LblTitleName.Size = New System.Drawing.Size(80, 40)
        Me.LblTitleName.TabIndex = 6
        Me.LblTitleName.Text = "Name"
        Me.LblTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnApply
        '
        Me.BtnApply.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnApply.ForeColor = System.Drawing.Color.White
        Me.BtnApply.Location = New System.Drawing.Point(4, 440)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(192, 46)
        Me.BtnApply.TabIndex = 5
        Me.BtnApply.Text = "Apply"
        Me.BtnApply.UseVisualStyleBackColor = False
        '
        'BtnCopy
        '
        Me.BtnCopy.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCopy.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCopy.ForeColor = System.Drawing.Color.White
        Me.BtnCopy.Location = New System.Drawing.Point(4, 389)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(192, 46)
        Me.BtnCopy.TabIndex = 5
        Me.BtnCopy.Text = "Copy"
        Me.BtnCopy.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCancel.ForeColor = System.Drawing.Color.White
        Me.BtnCancel.Location = New System.Drawing.Point(4, 286)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(192, 46)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSave.ForeColor = System.Drawing.Color.White
        Me.BtnSave.Location = New System.Drawing.Point(4, 235)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(192, 46)
        Me.BtnSave.TabIndex = 5
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnDelete.ForeColor = System.Drawing.Color.White
        Me.BtnDelete.Location = New System.Drawing.Point(4, 184)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(192, 46)
        Me.BtnDelete.TabIndex = 5
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnModify
        '
        Me.BtnModify.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnModify.ForeColor = System.Drawing.Color.White
        Me.BtnModify.Location = New System.Drawing.Point(4, 133)
        Me.BtnModify.Name = "BtnModify"
        Me.BtnModify.Size = New System.Drawing.Size(192, 46)
        Me.BtnModify.TabIndex = 5
        Me.BtnModify.Text = "Modify"
        Me.BtnModify.UseVisualStyleBackColor = False
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnAdd.ForeColor = System.Drawing.Color.White
        Me.BtnAdd.Location = New System.Drawing.Point(4, 82)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(192, 46)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.TxtName.Location = New System.Drawing.Point(86, 46)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(110, 30)
        Me.TxtName.TabIndex = 3
        '
        'PnlLeft
        '
        Me.PnlLeft.BDrawBorderBottom = False
        Me.PnlLeft.BDrawBorderLeft = False
        Me.PnlLeft.BDrawBorderRight = False
        Me.PnlLeft.BDrawBorderTop = False
        Me.PnlLeft.Controls.Add(Me.PnlList)
        Me.PnlLeft.Controls.Add(Me.PnlEdit)
        Me.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlLeft.Location = New System.Drawing.Point(0, 40)
        Me.PnlLeft.Name = "PnlLeft"
        Me.PnlLeft.Size = New System.Drawing.Size(200, 889)
        Me.PnlLeft.TabIndex = 4
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
        Me.LblTitle.Text = "Recipe"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.PnlTitle.TabIndex = 3
        '
        'PnlRight
        '
        Me.PnlRight.BDrawBorderBottom = False
        Me.PnlRight.BDrawBorderLeft = True
        Me.PnlRight.BDrawBorderRight = False
        Me.PnlRight.BDrawBorderTop = False
        Me.PnlRight.Controls.Add(Me.TabDetail)
        Me.PnlRight.Controls.Add(Me.PnlKind)
        Me.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlRight.Location = New System.Drawing.Point(200, 40)
        Me.PnlRight.Name = "PnlRight"
        Me.PnlRight.Size = New System.Drawing.Size(1080, 889)
        Me.PnlRight.TabIndex = 5
        '
        'TabDetail
        '
        Me.TabDetail.Controls.Add(Me.PageTool)
        Me.TabDetail.Controls.Add(Me.PageLimit)
        Me.TabDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.TabDetail.Location = New System.Drawing.Point(0, 280)
        Me.TabDetail.Name = "TabDetail"
        Me.TabDetail.SelectedIndex = 0
        Me.TabDetail.Size = New System.Drawing.Size(1080, 609)
        Me.TabDetail.TabIndex = 7
        '
        'PageTool
        '
        Me.PageTool.BackColor = System.Drawing.SystemColors.Control
        Me.PageTool.Controls.Add(Me.CdpDesign)
        Me.PageTool.Controls.Add(Me.PnlScreen)
        Me.PageTool.Controls.Add(Me.PnlToolEdge)
        Me.PageTool.Controls.Add(Me.PnlToolMark)
        Me.PageTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.PageTool.Location = New System.Drawing.Point(4, 34)
        Me.PageTool.Name = "PageTool"
        Me.PageTool.Padding = New System.Windows.Forms.Padding(3)
        Me.PageTool.Size = New System.Drawing.Size(1072, 571)
        Me.PageTool.TabIndex = 0
        Me.PageTool.Text = "Tool"
        '
        'CdpDesign
        '
        Me.CdpDesign.Location = New System.Drawing.Point(396, 3)
        Me.CdpDesign.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpDesign.MouseWheelSensitivity = 1
        Me.CdpDesign.Name = "CdpDesign"
        Me.CdpDesign.OcxState = CType(resources.GetObject("CdpDesign.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpDesign.Size = New System.Drawing.Size(673, 565)
        Me.CdpDesign.TabIndex = 3
        '
        'PnlScreen
        '
        Me.PnlScreen.BDrawBorderBottom = False
        Me.PnlScreen.BDrawBorderLeft = False
        Me.PnlScreen.BDrawBorderRight = False
        Me.PnlScreen.BDrawBorderTop = False
        Me.PnlScreen.Location = New System.Drawing.Point(3, 3)
        Me.PnlScreen.Name = "PnlScreen"
        Me.PnlScreen.Size = New System.Drawing.Size(393, 565)
        Me.PnlScreen.TabIndex = 1
        '
        'PnlToolEdge
        '
        Me.PnlToolEdge.BDrawBorderBottom = False
        Me.PnlToolEdge.BDrawBorderLeft = False
        Me.PnlToolEdge.BDrawBorderRight = False
        Me.PnlToolEdge.BDrawBorderTop = False
        Me.PnlToolEdge.Controls.Add(Me.CceCaliper)
        Me.PnlToolEdge.Location = New System.Drawing.Point(3, 3)
        Me.PnlToolEdge.Name = "PnlToolEdge"
        Me.PnlToolEdge.Size = New System.Drawing.Size(1066, 565)
        Me.PnlToolEdge.TabIndex = 1
        '
        'CceCaliper
        '
        Me.CceCaliper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CceCaliper.Location = New System.Drawing.Point(0, 0)
        Me.CceCaliper.MinimumSize = New System.Drawing.Size(489, 0)
        Me.CceCaliper.Name = "CceCaliper"
        Me.CceCaliper.Size = New System.Drawing.Size(1066, 565)
        Me.CceCaliper.SuspendElectricRuns = False
        Me.CceCaliper.TabIndex = 0
        '
        'PnlToolMark
        '
        Me.PnlToolMark.BDrawBorderBottom = False
        Me.PnlToolMark.BDrawBorderLeft = False
        Me.PnlToolMark.BDrawBorderRight = False
        Me.PnlToolMark.BDrawBorderTop = False
        Me.PnlToolMark.Controls.Add(Me.CpePattern)
        Me.PnlToolMark.Location = New System.Drawing.Point(3, 3)
        Me.PnlToolMark.Name = "PnlToolMark"
        Me.PnlToolMark.Size = New System.Drawing.Size(1066, 565)
        Me.PnlToolMark.TabIndex = 1
        '
        'CpePattern
        '
        Me.CpePattern.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CpePattern.Location = New System.Drawing.Point(0, 0)
        Me.CpePattern.MinimumSize = New System.Drawing.Size(489, 0)
        Me.CpePattern.Name = "CpePattern"
        Me.CpePattern.Size = New System.Drawing.Size(1066, 565)
        Me.CpePattern.SuspendElectricRuns = False
        Me.CpePattern.TabIndex = 0
        '
        'PageLimit
        '
        Me.PageLimit.BackColor = System.Drawing.SystemColors.Control
        Me.PageLimit.Controls.Add(Me.PnlLimit)
        Me.PageLimit.Location = New System.Drawing.Point(4, 34)
        Me.PageLimit.Name = "PageLimit"
        Me.PageLimit.Padding = New System.Windows.Forms.Padding(3)
        Me.PageLimit.Size = New System.Drawing.Size(1072, 571)
        Me.PageLimit.TabIndex = 1
        Me.PageLimit.Text = "Limit"
        '
        'PnlLimit
        '
        Me.PnlLimit.BDrawBorderBottom = False
        Me.PnlLimit.BDrawBorderLeft = False
        Me.PnlLimit.BDrawBorderRight = False
        Me.PnlLimit.BDrawBorderTop = False
        Me.PnlLimit.Controls.Add(Me.PnlBLimit)
        Me.PnlLimit.Controls.Add(Me.PnlALimit)
        Me.PnlLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlLimit.Location = New System.Drawing.Point(3, 3)
        Me.PnlLimit.Name = "PnlLimit"
        Me.PnlLimit.Size = New System.Drawing.Size(1066, 565)
        Me.PnlLimit.TabIndex = 6
        '
        'PnlBLimit
        '
        Me.PnlBLimit.BDrawBorderBottom = True
        Me.PnlBLimit.BDrawBorderLeft = True
        Me.PnlBLimit.BDrawBorderRight = True
        Me.PnlBLimit.BDrawBorderTop = False
        Me.PnlBLimit.Controls.Add(Me.PnlBEdgeLimit)
        Me.PnlBLimit.Controls.Add(Me.PnlBAlignmentLimit)
        Me.PnlBLimit.Controls.Add(Me.LblTitleBLimit)
        Me.PnlBLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBLimit.Location = New System.Drawing.Point(534, 0)
        Me.PnlBLimit.Name = "PnlBLimit"
        Me.PnlBLimit.Size = New System.Drawing.Size(532, 565)
        Me.PnlBLimit.TabIndex = 2
        '
        'PnlBEdgeLimit
        '
        Me.PnlBEdgeLimit.BDrawBorderBottom = True
        Me.PnlBEdgeLimit.BDrawBorderLeft = True
        Me.PnlBEdgeLimit.BDrawBorderRight = False
        Me.PnlBEdgeLimit.BDrawBorderTop = False
        Me.PnlBEdgeLimit.Controls.Add(Me.PnlBEdgeRightLimit)
        Me.PnlBEdgeLimit.Controls.Add(Me.PnlBEdgeLeftLimit)
        Me.PnlBEdgeLimit.Controls.Add(Me.LblTitleBEdgeLimit)
        Me.PnlBEdgeLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBEdgeLimit.Location = New System.Drawing.Point(0, 160)
        Me.PnlBEdgeLimit.Name = "PnlBEdgeLimit"
        Me.PnlBEdgeLimit.Size = New System.Drawing.Size(532, 405)
        Me.PnlBEdgeLimit.TabIndex = 9
        '
        'PnlBEdgeRightLimit
        '
        Me.PnlBEdgeRightLimit.BDrawBorderBottom = True
        Me.PnlBEdgeRightLimit.BDrawBorderLeft = True
        Me.PnlBEdgeRightLimit.BDrawBorderRight = False
        Me.PnlBEdgeRightLimit.BDrawBorderTop = False
        Me.PnlBEdgeRightLimit.Controls.Add(Me.LblTitleBEdgeRightLimit)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.LblTitleBEdgeRightBottomMin)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.NudBEdgeRightTopMin)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.LblTitleBEdgeRightBottomMax)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.LblTitleBEdgeRightTopMin)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.NudBEdgeRightBottomMax)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.LblTitleBEdgeRightTopMax)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.NudBEdgeRightBottomMin)
        Me.PnlBEdgeRightLimit.Controls.Add(Me.NudBEdgeRightTopMax)
        Me.PnlBEdgeRightLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlBEdgeRightLimit.Location = New System.Drawing.Point(267, 40)
        Me.PnlBEdgeRightLimit.Name = "PnlBEdgeRightLimit"
        Me.PnlBEdgeRightLimit.Size = New System.Drawing.Size(265, 365)
        Me.PnlBEdgeRightLimit.TabIndex = 7
        '
        'LblTitleBEdgeRightLimit
        '
        Me.LblTitleBEdgeRightLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeRightLimit.BDrawBorderBottom = True
        Me.LblTitleBEdgeRightLimit.BDrawBorderLeft = True
        Me.LblTitleBEdgeRightLimit.BDrawBorderRight = False
        Me.LblTitleBEdgeRightLimit.BDrawBorderTop = False
        Me.LblTitleBEdgeRightLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBEdgeRightLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeRightLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeRightLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBEdgeRightLimit.Name = "LblTitleBEdgeRightLimit"
        Me.LblTitleBEdgeRightLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeRightLimit.Size = New System.Drawing.Size(265, 40)
        Me.LblTitleBEdgeRightLimit.TabIndex = 6
        Me.LblTitleBEdgeRightLimit.Text = "Right Limit"
        Me.LblTitleBEdgeRightLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBEdgeRightBottomMin
        '
        Me.LblTitleBEdgeRightBottomMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeRightBottomMin.BDrawBorderBottom = True
        Me.LblTitleBEdgeRightBottomMin.BDrawBorderLeft = True
        Me.LblTitleBEdgeRightBottomMin.BDrawBorderRight = True
        Me.LblTitleBEdgeRightBottomMin.BDrawBorderTop = False
        Me.LblTitleBEdgeRightBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeRightBottomMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeRightBottomMin.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleBEdgeRightBottomMin.Name = "LblTitleBEdgeRightBottomMin"
        Me.LblTitleBEdgeRightBottomMin.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeRightBottomMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeRightBottomMin.TabIndex = 4
        Me.LblTitleBEdgeRightBottomMin.Text = "Rear Min"
        Me.LblTitleBEdgeRightBottomMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBEdgeRightTopMin
        '
        Me.NudBEdgeRightTopMin.DecimalPlaces = 3
        Me.NudBEdgeRightTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeRightTopMin.Location = New System.Drawing.Point(125, 46)
        Me.NudBEdgeRightTopMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeRightTopMin.Name = "NudBEdgeRightTopMin"
        Me.NudBEdgeRightTopMin.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeRightTopMin.TabIndex = 5
        Me.NudBEdgeRightTopMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBEdgeRightBottomMax
        '
        Me.LblTitleBEdgeRightBottomMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeRightBottomMax.BDrawBorderBottom = True
        Me.LblTitleBEdgeRightBottomMax.BDrawBorderLeft = True
        Me.LblTitleBEdgeRightBottomMax.BDrawBorderRight = True
        Me.LblTitleBEdgeRightBottomMax.BDrawBorderTop = False
        Me.LblTitleBEdgeRightBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeRightBottomMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeRightBottomMax.Location = New System.Drawing.Point(0, 160)
        Me.LblTitleBEdgeRightBottomMax.Name = "LblTitleBEdgeRightBottomMax"
        Me.LblTitleBEdgeRightBottomMax.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeRightBottomMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeRightBottomMax.TabIndex = 4
        Me.LblTitleBEdgeRightBottomMax.Text = "Rear Max"
        Me.LblTitleBEdgeRightBottomMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBEdgeRightTopMin
        '
        Me.LblTitleBEdgeRightTopMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeRightTopMin.BDrawBorderBottom = True
        Me.LblTitleBEdgeRightTopMin.BDrawBorderLeft = True
        Me.LblTitleBEdgeRightTopMin.BDrawBorderRight = True
        Me.LblTitleBEdgeRightTopMin.BDrawBorderTop = False
        Me.LblTitleBEdgeRightTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeRightTopMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeRightTopMin.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleBEdgeRightTopMin.Name = "LblTitleBEdgeRightTopMin"
        Me.LblTitleBEdgeRightTopMin.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeRightTopMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeRightTopMin.TabIndex = 4
        Me.LblTitleBEdgeRightTopMin.Text = "Front Min"
        Me.LblTitleBEdgeRightTopMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBEdgeRightBottomMax
        '
        Me.NudBEdgeRightBottomMax.DecimalPlaces = 3
        Me.NudBEdgeRightBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeRightBottomMax.Location = New System.Drawing.Point(125, 165)
        Me.NudBEdgeRightBottomMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeRightBottomMax.Name = "NudBEdgeRightBottomMax"
        Me.NudBEdgeRightBottomMax.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeRightBottomMax.TabIndex = 5
        Me.NudBEdgeRightBottomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBEdgeRightTopMax
        '
        Me.LblTitleBEdgeRightTopMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeRightTopMax.BDrawBorderBottom = True
        Me.LblTitleBEdgeRightTopMax.BDrawBorderLeft = True
        Me.LblTitleBEdgeRightTopMax.BDrawBorderRight = True
        Me.LblTitleBEdgeRightTopMax.BDrawBorderTop = False
        Me.LblTitleBEdgeRightTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeRightTopMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeRightTopMax.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleBEdgeRightTopMax.Name = "LblTitleBEdgeRightTopMax"
        Me.LblTitleBEdgeRightTopMax.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeRightTopMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeRightTopMax.TabIndex = 4
        Me.LblTitleBEdgeRightTopMax.Text = "Front Max"
        Me.LblTitleBEdgeRightTopMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBEdgeRightBottomMin
        '
        Me.NudBEdgeRightBottomMin.DecimalPlaces = 3
        Me.NudBEdgeRightBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeRightBottomMin.Location = New System.Drawing.Point(125, 125)
        Me.NudBEdgeRightBottomMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeRightBottomMin.Name = "NudBEdgeRightBottomMin"
        Me.NudBEdgeRightBottomMin.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeRightBottomMin.TabIndex = 5
        Me.NudBEdgeRightBottomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudBEdgeRightTopMax
        '
        Me.NudBEdgeRightTopMax.DecimalPlaces = 3
        Me.NudBEdgeRightTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeRightTopMax.Location = New System.Drawing.Point(125, 85)
        Me.NudBEdgeRightTopMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeRightTopMax.Name = "NudBEdgeRightTopMax"
        Me.NudBEdgeRightTopMax.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeRightTopMax.TabIndex = 5
        Me.NudBEdgeRightTopMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlBEdgeLeftLimit
        '
        Me.PnlBEdgeLeftLimit.BDrawBorderBottom = True
        Me.PnlBEdgeLeftLimit.BDrawBorderLeft = True
        Me.PnlBEdgeLeftLimit.BDrawBorderRight = False
        Me.PnlBEdgeLeftLimit.BDrawBorderTop = False
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.LblTitleBEdgeLeftLimit)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.LblTitleBEdgeLeftBottomMin)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.NudBEdgeLeftTopMin)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.LblTitleBEdgeLeftBottomMax)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.LblTitleBEdgeLeftTopMin)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.NudBEdgeLeftBottomMax)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.LblTitleBEdgeLeftTopMax)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.NudBEdgeLeftBottomMin)
        Me.PnlBEdgeLeftLimit.Controls.Add(Me.NudBEdgeLeftTopMax)
        Me.PnlBEdgeLeftLimit.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlBEdgeLeftLimit.Location = New System.Drawing.Point(0, 40)
        Me.PnlBEdgeLeftLimit.Name = "PnlBEdgeLeftLimit"
        Me.PnlBEdgeLeftLimit.Size = New System.Drawing.Size(267, 365)
        Me.PnlBEdgeLeftLimit.TabIndex = 7
        '
        'LblTitleBEdgeLeftLimit
        '
        Me.LblTitleBEdgeLeftLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeLeftLimit.BDrawBorderBottom = True
        Me.LblTitleBEdgeLeftLimit.BDrawBorderLeft = True
        Me.LblTitleBEdgeLeftLimit.BDrawBorderRight = False
        Me.LblTitleBEdgeLeftLimit.BDrawBorderTop = False
        Me.LblTitleBEdgeLeftLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBEdgeLeftLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeLeftLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeLeftLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBEdgeLeftLimit.Name = "LblTitleBEdgeLeftLimit"
        Me.LblTitleBEdgeLeftLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeLeftLimit.Size = New System.Drawing.Size(267, 40)
        Me.LblTitleBEdgeLeftLimit.TabIndex = 6
        Me.LblTitleBEdgeLeftLimit.Text = "Left Limit"
        Me.LblTitleBEdgeLeftLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBEdgeLeftBottomMin
        '
        Me.LblTitleBEdgeLeftBottomMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeLeftBottomMin.BDrawBorderBottom = True
        Me.LblTitleBEdgeLeftBottomMin.BDrawBorderLeft = True
        Me.LblTitleBEdgeLeftBottomMin.BDrawBorderRight = True
        Me.LblTitleBEdgeLeftBottomMin.BDrawBorderTop = False
        Me.LblTitleBEdgeLeftBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeLeftBottomMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeLeftBottomMin.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleBEdgeLeftBottomMin.Name = "LblTitleBEdgeLeftBottomMin"
        Me.LblTitleBEdgeLeftBottomMin.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeLeftBottomMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeLeftBottomMin.TabIndex = 4
        Me.LblTitleBEdgeLeftBottomMin.Text = "Rear Min"
        Me.LblTitleBEdgeLeftBottomMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBEdgeLeftTopMin
        '
        Me.NudBEdgeLeftTopMin.DecimalPlaces = 3
        Me.NudBEdgeLeftTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeLeftTopMin.Location = New System.Drawing.Point(125, 46)
        Me.NudBEdgeLeftTopMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeLeftTopMin.Name = "NudBEdgeLeftTopMin"
        Me.NudBEdgeLeftTopMin.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeLeftTopMin.TabIndex = 5
        Me.NudBEdgeLeftTopMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBEdgeLeftBottomMax
        '
        Me.LblTitleBEdgeLeftBottomMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeLeftBottomMax.BDrawBorderBottom = True
        Me.LblTitleBEdgeLeftBottomMax.BDrawBorderLeft = True
        Me.LblTitleBEdgeLeftBottomMax.BDrawBorderRight = True
        Me.LblTitleBEdgeLeftBottomMax.BDrawBorderTop = False
        Me.LblTitleBEdgeLeftBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeLeftBottomMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeLeftBottomMax.Location = New System.Drawing.Point(0, 160)
        Me.LblTitleBEdgeLeftBottomMax.Name = "LblTitleBEdgeLeftBottomMax"
        Me.LblTitleBEdgeLeftBottomMax.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeLeftBottomMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeLeftBottomMax.TabIndex = 4
        Me.LblTitleBEdgeLeftBottomMax.Text = "Rear Max"
        Me.LblTitleBEdgeLeftBottomMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBEdgeLeftTopMin
        '
        Me.LblTitleBEdgeLeftTopMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeLeftTopMin.BDrawBorderBottom = True
        Me.LblTitleBEdgeLeftTopMin.BDrawBorderLeft = True
        Me.LblTitleBEdgeLeftTopMin.BDrawBorderRight = True
        Me.LblTitleBEdgeLeftTopMin.BDrawBorderTop = False
        Me.LblTitleBEdgeLeftTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeLeftTopMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeLeftTopMin.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleBEdgeLeftTopMin.Name = "LblTitleBEdgeLeftTopMin"
        Me.LblTitleBEdgeLeftTopMin.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeLeftTopMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeLeftTopMin.TabIndex = 4
        Me.LblTitleBEdgeLeftTopMin.Text = "Front Min"
        Me.LblTitleBEdgeLeftTopMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBEdgeLeftBottomMax
        '
        Me.NudBEdgeLeftBottomMax.DecimalPlaces = 3
        Me.NudBEdgeLeftBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeLeftBottomMax.Location = New System.Drawing.Point(125, 165)
        Me.NudBEdgeLeftBottomMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeLeftBottomMax.Name = "NudBEdgeLeftBottomMax"
        Me.NudBEdgeLeftBottomMax.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeLeftBottomMax.TabIndex = 5
        Me.NudBEdgeLeftBottomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBEdgeLeftTopMax
        '
        Me.LblTitleBEdgeLeftTopMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeLeftTopMax.BDrawBorderBottom = True
        Me.LblTitleBEdgeLeftTopMax.BDrawBorderLeft = True
        Me.LblTitleBEdgeLeftTopMax.BDrawBorderRight = True
        Me.LblTitleBEdgeLeftTopMax.BDrawBorderTop = False
        Me.LblTitleBEdgeLeftTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeLeftTopMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeLeftTopMax.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleBEdgeLeftTopMax.Name = "LblTitleBEdgeLeftTopMax"
        Me.LblTitleBEdgeLeftTopMax.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeLeftTopMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBEdgeLeftTopMax.TabIndex = 4
        Me.LblTitleBEdgeLeftTopMax.Text = "Front Max"
        Me.LblTitleBEdgeLeftTopMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBEdgeLeftBottomMin
        '
        Me.NudBEdgeLeftBottomMin.DecimalPlaces = 3
        Me.NudBEdgeLeftBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeLeftBottomMin.Location = New System.Drawing.Point(125, 125)
        Me.NudBEdgeLeftBottomMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeLeftBottomMin.Name = "NudBEdgeLeftBottomMin"
        Me.NudBEdgeLeftBottomMin.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeLeftBottomMin.TabIndex = 5
        Me.NudBEdgeLeftBottomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudBEdgeLeftTopMax
        '
        Me.NudBEdgeLeftTopMax.DecimalPlaces = 3
        Me.NudBEdgeLeftTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBEdgeLeftTopMax.Location = New System.Drawing.Point(125, 85)
        Me.NudBEdgeLeftTopMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBEdgeLeftTopMax.Name = "NudBEdgeLeftTopMax"
        Me.NudBEdgeLeftTopMax.Size = New System.Drawing.Size(135, 30)
        Me.NudBEdgeLeftTopMax.TabIndex = 5
        Me.NudBEdgeLeftTopMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBEdgeLimit
        '
        Me.LblTitleBEdgeLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBEdgeLimit.BDrawBorderBottom = True
        Me.LblTitleBEdgeLimit.BDrawBorderLeft = True
        Me.LblTitleBEdgeLimit.BDrawBorderRight = False
        Me.LblTitleBEdgeLimit.BDrawBorderTop = False
        Me.LblTitleBEdgeLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBEdgeLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBEdgeLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBEdgeLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBEdgeLimit.Name = "LblTitleBEdgeLimit"
        Me.LblTitleBEdgeLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBEdgeLimit.Size = New System.Drawing.Size(532, 40)
        Me.LblTitleBEdgeLimit.TabIndex = 5
        Me.LblTitleBEdgeLimit.Text = "Edge Limit (mm)"
        Me.LblTitleBEdgeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlBAlignmentLimit
        '
        Me.PnlBAlignmentLimit.BDrawBorderBottom = True
        Me.PnlBAlignmentLimit.BDrawBorderLeft = True
        Me.PnlBAlignmentLimit.BDrawBorderRight = False
        Me.PnlBAlignmentLimit.BDrawBorderTop = False
        Me.PnlBAlignmentLimit.Controls.Add(Me.LblTitleBAlignmentLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.LblTitleBAlignmentRightXLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.LblTitleBAlignmentLeftXLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.LblTitleBAlignmentYLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.NudBAlignmentTLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.LblTitleBAlignmentTLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.NudBAlignmentLeftXLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.NudBAlignmentRightXLimit)
        Me.PnlBAlignmentLimit.Controls.Add(Me.NudBAlignmentYLimit)
        Me.PnlBAlignmentLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlBAlignmentLimit.Location = New System.Drawing.Point(0, 40)
        Me.PnlBAlignmentLimit.Name = "PnlBAlignmentLimit"
        Me.PnlBAlignmentLimit.Size = New System.Drawing.Size(532, 120)
        Me.PnlBAlignmentLimit.TabIndex = 8
        '
        'LblTitleBAlignmentLimit
        '
        Me.LblTitleBAlignmentLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentLimit.BDrawBorderBottom = True
        Me.LblTitleBAlignmentLimit.BDrawBorderLeft = True
        Me.LblTitleBAlignmentLimit.BDrawBorderRight = False
        Me.LblTitleBAlignmentLimit.BDrawBorderTop = False
        Me.LblTitleBAlignmentLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBAlignmentLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBAlignmentLimit.Name = "LblTitleBAlignmentLimit"
        Me.LblTitleBAlignmentLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentLimit.Size = New System.Drawing.Size(532, 40)
        Me.LblTitleBAlignmentLimit.TabIndex = 16
        Me.LblTitleBAlignmentLimit.Text = "Alignment Limit (X, Y=mm, T=deg)"
        Me.LblTitleBAlignmentLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBAlignmentRightXLimit
        '
        Me.LblTitleBAlignmentRightXLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentRightXLimit.BDrawBorderBottom = True
        Me.LblTitleBAlignmentRightXLimit.BDrawBorderLeft = True
        Me.LblTitleBAlignmentRightXLimit.BDrawBorderRight = True
        Me.LblTitleBAlignmentRightXLimit.BDrawBorderTop = False
        Me.LblTitleBAlignmentRightXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentRightXLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentRightXLimit.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleBAlignmentRightXLimit.Name = "LblTitleBAlignmentRightXLimit"
        Me.LblTitleBAlignmentRightXLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentRightXLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBAlignmentRightXLimit.TabIndex = 4
        Me.LblTitleBAlignmentRightXLimit.Text = "X Right"
        Me.LblTitleBAlignmentRightXLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBAlignmentLeftXLimit
        '
        Me.LblTitleBAlignmentLeftXLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentLeftXLimit.BDrawBorderBottom = True
        Me.LblTitleBAlignmentLeftXLimit.BDrawBorderLeft = True
        Me.LblTitleBAlignmentLeftXLimit.BDrawBorderRight = True
        Me.LblTitleBAlignmentLeftXLimit.BDrawBorderTop = False
        Me.LblTitleBAlignmentLeftXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentLeftXLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentLeftXLimit.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleBAlignmentLeftXLimit.Name = "LblTitleBAlignmentLeftXLimit"
        Me.LblTitleBAlignmentLeftXLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentLeftXLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBAlignmentLeftXLimit.TabIndex = 4
        Me.LblTitleBAlignmentLeftXLimit.Text = "X Left"
        Me.LblTitleBAlignmentLeftXLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleBAlignmentYLimit
        '
        Me.LblTitleBAlignmentYLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentYLimit.BDrawBorderBottom = True
        Me.LblTitleBAlignmentYLimit.BDrawBorderLeft = True
        Me.LblTitleBAlignmentYLimit.BDrawBorderRight = True
        Me.LblTitleBAlignmentYLimit.BDrawBorderTop = False
        Me.LblTitleBAlignmentYLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentYLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentYLimit.Location = New System.Drawing.Point(267, 40)
        Me.LblTitleBAlignmentYLimit.Name = "LblTitleBAlignmentYLimit"
        Me.LblTitleBAlignmentYLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentYLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBAlignmentYLimit.TabIndex = 4
        Me.LblTitleBAlignmentYLimit.Text = "Y"
        Me.LblTitleBAlignmentYLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBAlignmentTLimit
        '
        Me.NudBAlignmentTLimit.DecimalPlaces = 4
        Me.NudBAlignmentTLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBAlignmentTLimit.Location = New System.Drawing.Point(393, 85)
        Me.NudBAlignmentTLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBAlignmentTLimit.Name = "NudBAlignmentTLimit"
        Me.NudBAlignmentTLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudBAlignmentTLimit.TabIndex = 5
        Me.NudBAlignmentTLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBAlignmentTLimit
        '
        Me.LblTitleBAlignmentTLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBAlignmentTLimit.BDrawBorderBottom = True
        Me.LblTitleBAlignmentTLimit.BDrawBorderLeft = True
        Me.LblTitleBAlignmentTLimit.BDrawBorderRight = True
        Me.LblTitleBAlignmentTLimit.BDrawBorderTop = False
        Me.LblTitleBAlignmentTLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBAlignmentTLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBAlignmentTLimit.Location = New System.Drawing.Point(267, 80)
        Me.LblTitleBAlignmentTLimit.Name = "LblTitleBAlignmentTLimit"
        Me.LblTitleBAlignmentTLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBAlignmentTLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleBAlignmentTLimit.TabIndex = 4
        Me.LblTitleBAlignmentTLimit.Text = "T"
        Me.LblTitleBAlignmentTLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudBAlignmentLeftXLimit
        '
        Me.NudBAlignmentLeftXLimit.DecimalPlaces = 3
        Me.NudBAlignmentLeftXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBAlignmentLeftXLimit.Location = New System.Drawing.Point(125, 46)
        Me.NudBAlignmentLeftXLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBAlignmentLeftXLimit.Name = "NudBAlignmentLeftXLimit"
        Me.NudBAlignmentLeftXLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudBAlignmentLeftXLimit.TabIndex = 5
        Me.NudBAlignmentLeftXLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudBAlignmentRightXLimit
        '
        Me.NudBAlignmentRightXLimit.DecimalPlaces = 3
        Me.NudBAlignmentRightXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBAlignmentRightXLimit.Location = New System.Drawing.Point(125, 85)
        Me.NudBAlignmentRightXLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBAlignmentRightXLimit.Name = "NudBAlignmentRightXLimit"
        Me.NudBAlignmentRightXLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudBAlignmentRightXLimit.TabIndex = 5
        Me.NudBAlignmentRightXLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudBAlignmentYLimit
        '
        Me.NudBAlignmentYLimit.DecimalPlaces = 3
        Me.NudBAlignmentYLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudBAlignmentYLimit.Location = New System.Drawing.Point(393, 46)
        Me.NudBAlignmentYLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudBAlignmentYLimit.Name = "NudBAlignmentYLimit"
        Me.NudBAlignmentYLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudBAlignmentYLimit.TabIndex = 5
        Me.NudBAlignmentYLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleBLimit
        '
        Me.LblTitleBLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBLimit.BDrawBorderBottom = True
        Me.LblTitleBLimit.BDrawBorderLeft = True
        Me.LblTitleBLimit.BDrawBorderRight = False
        Me.LblTitleBLimit.BDrawBorderTop = True
        Me.LblTitleBLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleBLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleBLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleBLimit.Name = "LblTitleBLimit"
        Me.LblTitleBLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleBLimit.Size = New System.Drawing.Size(532, 40)
        Me.LblTitleBLimit.TabIndex = 6
        Me.LblTitleBLimit.Text = "ST #2 Limit"
        Me.LblTitleBLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlALimit
        '
        Me.PnlALimit.BDrawBorderBottom = True
        Me.PnlALimit.BDrawBorderLeft = True
        Me.PnlALimit.BDrawBorderRight = False
        Me.PnlALimit.BDrawBorderTop = False
        Me.PnlALimit.Controls.Add(Me.PnlAEdgeLimit)
        Me.PnlALimit.Controls.Add(Me.PnlAAlignmentLimit)
        Me.PnlALimit.Controls.Add(Me.LblTitleALimit)
        Me.PnlALimit.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlALimit.Location = New System.Drawing.Point(0, 0)
        Me.PnlALimit.Name = "PnlALimit"
        Me.PnlALimit.Size = New System.Drawing.Size(534, 565)
        Me.PnlALimit.TabIndex = 6
        '
        'PnlAEdgeLimit
        '
        Me.PnlAEdgeLimit.BDrawBorderBottom = True
        Me.PnlAEdgeLimit.BDrawBorderLeft = True
        Me.PnlAEdgeLimit.BDrawBorderRight = False
        Me.PnlAEdgeLimit.BDrawBorderTop = False
        Me.PnlAEdgeLimit.Controls.Add(Me.PnlAEdgeRightLimit)
        Me.PnlAEdgeLimit.Controls.Add(Me.PnlAEdgeLeftLimit)
        Me.PnlAEdgeLimit.Controls.Add(Me.LblTitleAEdgeLimit)
        Me.PnlAEdgeLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlAEdgeLimit.Location = New System.Drawing.Point(0, 160)
        Me.PnlAEdgeLimit.Name = "PnlAEdgeLimit"
        Me.PnlAEdgeLimit.Size = New System.Drawing.Size(534, 405)
        Me.PnlAEdgeLimit.TabIndex = 12
        '
        'PnlAEdgeRightLimit
        '
        Me.PnlAEdgeRightLimit.BDrawBorderBottom = True
        Me.PnlAEdgeRightLimit.BDrawBorderLeft = True
        Me.PnlAEdgeRightLimit.BDrawBorderRight = False
        Me.PnlAEdgeRightLimit.BDrawBorderTop = False
        Me.PnlAEdgeRightLimit.Controls.Add(Me.LblTitleAEdgeRightBottomMin)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.LblTitleAEdgeRightTopMin)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.LblTitleAEdgeRightBottomMax)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.LblTitleAEdgeRightTopMax)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.LblTitleAEdgeRightLimit)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.NudAEdgeRightBottomMax)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.NudAEdgeRightBottomMin)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.NudAEdgeRightTopMin)
        Me.PnlAEdgeRightLimit.Controls.Add(Me.NudAEdgeRightTopMax)
        Me.PnlAEdgeRightLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlAEdgeRightLimit.Location = New System.Drawing.Point(267, 40)
        Me.PnlAEdgeRightLimit.Name = "PnlAEdgeRightLimit"
        Me.PnlAEdgeRightLimit.Size = New System.Drawing.Size(267, 365)
        Me.PnlAEdgeRightLimit.TabIndex = 9
        '
        'LblTitleAEdgeRightBottomMin
        '
        Me.LblTitleAEdgeRightBottomMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeRightBottomMin.BDrawBorderBottom = True
        Me.LblTitleAEdgeRightBottomMin.BDrawBorderLeft = True
        Me.LblTitleAEdgeRightBottomMin.BDrawBorderRight = True
        Me.LblTitleAEdgeRightBottomMin.BDrawBorderTop = False
        Me.LblTitleAEdgeRightBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeRightBottomMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeRightBottomMin.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleAEdgeRightBottomMin.Name = "LblTitleAEdgeRightBottomMin"
        Me.LblTitleAEdgeRightBottomMin.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeRightBottomMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeRightBottomMin.TabIndex = 8
        Me.LblTitleAEdgeRightBottomMin.Text = "Rear Min"
        Me.LblTitleAEdgeRightBottomMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeRightTopMin
        '
        Me.LblTitleAEdgeRightTopMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeRightTopMin.BDrawBorderBottom = True
        Me.LblTitleAEdgeRightTopMin.BDrawBorderLeft = True
        Me.LblTitleAEdgeRightTopMin.BDrawBorderRight = True
        Me.LblTitleAEdgeRightTopMin.BDrawBorderTop = False
        Me.LblTitleAEdgeRightTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeRightTopMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeRightTopMin.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleAEdgeRightTopMin.Name = "LblTitleAEdgeRightTopMin"
        Me.LblTitleAEdgeRightTopMin.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeRightTopMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeRightTopMin.TabIndex = 9
        Me.LblTitleAEdgeRightTopMin.Text = "Front Min"
        Me.LblTitleAEdgeRightTopMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeRightBottomMax
        '
        Me.LblTitleAEdgeRightBottomMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeRightBottomMax.BDrawBorderBottom = True
        Me.LblTitleAEdgeRightBottomMax.BDrawBorderLeft = True
        Me.LblTitleAEdgeRightBottomMax.BDrawBorderRight = True
        Me.LblTitleAEdgeRightBottomMax.BDrawBorderTop = False
        Me.LblTitleAEdgeRightBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeRightBottomMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeRightBottomMax.Location = New System.Drawing.Point(0, 160)
        Me.LblTitleAEdgeRightBottomMax.Name = "LblTitleAEdgeRightBottomMax"
        Me.LblTitleAEdgeRightBottomMax.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeRightBottomMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeRightBottomMax.TabIndex = 6
        Me.LblTitleAEdgeRightBottomMax.Text = "Rear Max"
        Me.LblTitleAEdgeRightBottomMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeRightTopMax
        '
        Me.LblTitleAEdgeRightTopMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeRightTopMax.BDrawBorderBottom = True
        Me.LblTitleAEdgeRightTopMax.BDrawBorderLeft = True
        Me.LblTitleAEdgeRightTopMax.BDrawBorderRight = True
        Me.LblTitleAEdgeRightTopMax.BDrawBorderTop = False
        Me.LblTitleAEdgeRightTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeRightTopMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeRightTopMax.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleAEdgeRightTopMax.Name = "LblTitleAEdgeRightTopMax"
        Me.LblTitleAEdgeRightTopMax.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeRightTopMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeRightTopMax.TabIndex = 7
        Me.LblTitleAEdgeRightTopMax.Text = "Front Max"
        Me.LblTitleAEdgeRightTopMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeRightLimit
        '
        Me.LblTitleAEdgeRightLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeRightLimit.BDrawBorderBottom = True
        Me.LblTitleAEdgeRightLimit.BDrawBorderLeft = True
        Me.LblTitleAEdgeRightLimit.BDrawBorderRight = False
        Me.LblTitleAEdgeRightLimit.BDrawBorderTop = False
        Me.LblTitleAEdgeRightLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleAEdgeRightLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeRightLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeRightLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleAEdgeRightLimit.Name = "LblTitleAEdgeRightLimit"
        Me.LblTitleAEdgeRightLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeRightLimit.Size = New System.Drawing.Size(267, 40)
        Me.LblTitleAEdgeRightLimit.TabIndex = 5
        Me.LblTitleAEdgeRightLimit.Text = "Right Limit"
        Me.LblTitleAEdgeRightLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudAEdgeRightBottomMax
        '
        Me.NudAEdgeRightBottomMax.DecimalPlaces = 3
        Me.NudAEdgeRightBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeRightBottomMax.Location = New System.Drawing.Point(125, 165)
        Me.NudAEdgeRightBottomMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeRightBottomMax.Name = "NudAEdgeRightBottomMax"
        Me.NudAEdgeRightBottomMax.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeRightBottomMax.TabIndex = 5
        Me.NudAEdgeRightBottomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAEdgeRightBottomMin
        '
        Me.NudAEdgeRightBottomMin.DecimalPlaces = 3
        Me.NudAEdgeRightBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeRightBottomMin.Location = New System.Drawing.Point(125, 125)
        Me.NudAEdgeRightBottomMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeRightBottomMin.Name = "NudAEdgeRightBottomMin"
        Me.NudAEdgeRightBottomMin.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeRightBottomMin.TabIndex = 5
        Me.NudAEdgeRightBottomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAEdgeRightTopMin
        '
        Me.NudAEdgeRightTopMin.DecimalPlaces = 3
        Me.NudAEdgeRightTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeRightTopMin.Location = New System.Drawing.Point(125, 46)
        Me.NudAEdgeRightTopMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeRightTopMin.Name = "NudAEdgeRightTopMin"
        Me.NudAEdgeRightTopMin.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeRightTopMin.TabIndex = 5
        Me.NudAEdgeRightTopMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAEdgeRightTopMax
        '
        Me.NudAEdgeRightTopMax.DecimalPlaces = 3
        Me.NudAEdgeRightTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeRightTopMax.Location = New System.Drawing.Point(125, 85)
        Me.NudAEdgeRightTopMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeRightTopMax.Name = "NudAEdgeRightTopMax"
        Me.NudAEdgeRightTopMax.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeRightTopMax.TabIndex = 5
        Me.NudAEdgeRightTopMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PnlAEdgeLeftLimit
        '
        Me.PnlAEdgeLeftLimit.BDrawBorderBottom = True
        Me.PnlAEdgeLeftLimit.BDrawBorderLeft = True
        Me.PnlAEdgeLeftLimit.BDrawBorderRight = False
        Me.PnlAEdgeLeftLimit.BDrawBorderTop = False
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.LblTitleAEdgeLeftLimit)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.LblTitleAEdgeLeftBottomMin)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.LblTitleAEdgeLeftTopMin)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.LblTitleAEdgeLeftBottomMax)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.LblTitleAEdgeLeftTopMax)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.NudAEdgeLeftBottomMax)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.NudAEdgeLeftBottomMin)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.NudAEdgeLeftTopMax)
        Me.PnlAEdgeLeftLimit.Controls.Add(Me.NudAEdgeLeftTopMin)
        Me.PnlAEdgeLeftLimit.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlAEdgeLeftLimit.Location = New System.Drawing.Point(0, 40)
        Me.PnlAEdgeLeftLimit.Name = "PnlAEdgeLeftLimit"
        Me.PnlAEdgeLeftLimit.Size = New System.Drawing.Size(267, 365)
        Me.PnlAEdgeLeftLimit.TabIndex = 8
        '
        'LblTitleAEdgeLeftLimit
        '
        Me.LblTitleAEdgeLeftLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeLeftLimit.BDrawBorderBottom = True
        Me.LblTitleAEdgeLeftLimit.BDrawBorderLeft = True
        Me.LblTitleAEdgeLeftLimit.BDrawBorderRight = False
        Me.LblTitleAEdgeLeftLimit.BDrawBorderTop = False
        Me.LblTitleAEdgeLeftLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleAEdgeLeftLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeLeftLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeLeftLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleAEdgeLeftLimit.Name = "LblTitleAEdgeLeftLimit"
        Me.LblTitleAEdgeLeftLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeLeftLimit.Size = New System.Drawing.Size(267, 40)
        Me.LblTitleAEdgeLeftLimit.TabIndex = 5
        Me.LblTitleAEdgeLeftLimit.Text = "Left Limit"
        Me.LblTitleAEdgeLeftLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeLeftBottomMin
        '
        Me.LblTitleAEdgeLeftBottomMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeLeftBottomMin.BDrawBorderBottom = True
        Me.LblTitleAEdgeLeftBottomMin.BDrawBorderLeft = True
        Me.LblTitleAEdgeLeftBottomMin.BDrawBorderRight = True
        Me.LblTitleAEdgeLeftBottomMin.BDrawBorderTop = False
        Me.LblTitleAEdgeLeftBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeLeftBottomMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeLeftBottomMin.Location = New System.Drawing.Point(0, 120)
        Me.LblTitleAEdgeLeftBottomMin.Name = "LblTitleAEdgeLeftBottomMin"
        Me.LblTitleAEdgeLeftBottomMin.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeLeftBottomMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeLeftBottomMin.TabIndex = 4
        Me.LblTitleAEdgeLeftBottomMin.Text = "Rear Min"
        Me.LblTitleAEdgeLeftBottomMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeLeftTopMin
        '
        Me.LblTitleAEdgeLeftTopMin.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeLeftTopMin.BDrawBorderBottom = True
        Me.LblTitleAEdgeLeftTopMin.BDrawBorderLeft = True
        Me.LblTitleAEdgeLeftTopMin.BDrawBorderRight = True
        Me.LblTitleAEdgeLeftTopMin.BDrawBorderTop = False
        Me.LblTitleAEdgeLeftTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeLeftTopMin.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeLeftTopMin.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleAEdgeLeftTopMin.Name = "LblTitleAEdgeLeftTopMin"
        Me.LblTitleAEdgeLeftTopMin.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeLeftTopMin.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeLeftTopMin.TabIndex = 4
        Me.LblTitleAEdgeLeftTopMin.Text = "Front Min"
        Me.LblTitleAEdgeLeftTopMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeLeftBottomMax
        '
        Me.LblTitleAEdgeLeftBottomMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeLeftBottomMax.BDrawBorderBottom = True
        Me.LblTitleAEdgeLeftBottomMax.BDrawBorderLeft = True
        Me.LblTitleAEdgeLeftBottomMax.BDrawBorderRight = True
        Me.LblTitleAEdgeLeftBottomMax.BDrawBorderTop = False
        Me.LblTitleAEdgeLeftBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeLeftBottomMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeLeftBottomMax.Location = New System.Drawing.Point(0, 160)
        Me.LblTitleAEdgeLeftBottomMax.Name = "LblTitleAEdgeLeftBottomMax"
        Me.LblTitleAEdgeLeftBottomMax.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeLeftBottomMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeLeftBottomMax.TabIndex = 4
        Me.LblTitleAEdgeLeftBottomMax.Text = "Rear Max"
        Me.LblTitleAEdgeLeftBottomMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAEdgeLeftTopMax
        '
        Me.LblTitleAEdgeLeftTopMax.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeLeftTopMax.BDrawBorderBottom = True
        Me.LblTitleAEdgeLeftTopMax.BDrawBorderLeft = True
        Me.LblTitleAEdgeLeftTopMax.BDrawBorderRight = True
        Me.LblTitleAEdgeLeftTopMax.BDrawBorderTop = False
        Me.LblTitleAEdgeLeftTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeLeftTopMax.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeLeftTopMax.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleAEdgeLeftTopMax.Name = "LblTitleAEdgeLeftTopMax"
        Me.LblTitleAEdgeLeftTopMax.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeLeftTopMax.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAEdgeLeftTopMax.TabIndex = 4
        Me.LblTitleAEdgeLeftTopMax.Text = "Front Max"
        Me.LblTitleAEdgeLeftTopMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudAEdgeLeftBottomMax
        '
        Me.NudAEdgeLeftBottomMax.DecimalPlaces = 3
        Me.NudAEdgeLeftBottomMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeLeftBottomMax.Location = New System.Drawing.Point(125, 165)
        Me.NudAEdgeLeftBottomMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeLeftBottomMax.Name = "NudAEdgeLeftBottomMax"
        Me.NudAEdgeLeftBottomMax.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeLeftBottomMax.TabIndex = 5
        Me.NudAEdgeLeftBottomMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAEdgeLeftBottomMin
        '
        Me.NudAEdgeLeftBottomMin.DecimalPlaces = 3
        Me.NudAEdgeLeftBottomMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeLeftBottomMin.Location = New System.Drawing.Point(125, 125)
        Me.NudAEdgeLeftBottomMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeLeftBottomMin.Name = "NudAEdgeLeftBottomMin"
        Me.NudAEdgeLeftBottomMin.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeLeftBottomMin.TabIndex = 5
        Me.NudAEdgeLeftBottomMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAEdgeLeftTopMax
        '
        Me.NudAEdgeLeftTopMax.DecimalPlaces = 3
        Me.NudAEdgeLeftTopMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeLeftTopMax.Location = New System.Drawing.Point(125, 85)
        Me.NudAEdgeLeftTopMax.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeLeftTopMax.Name = "NudAEdgeLeftTopMax"
        Me.NudAEdgeLeftTopMax.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeLeftTopMax.TabIndex = 5
        Me.NudAEdgeLeftTopMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAEdgeLeftTopMin
        '
        Me.NudAEdgeLeftTopMin.DecimalPlaces = 3
        Me.NudAEdgeLeftTopMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAEdgeLeftTopMin.Location = New System.Drawing.Point(125, 46)
        Me.NudAEdgeLeftTopMin.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAEdgeLeftTopMin.Name = "NudAEdgeLeftTopMin"
        Me.NudAEdgeLeftTopMin.Size = New System.Drawing.Size(135, 30)
        Me.NudAEdgeLeftTopMin.TabIndex = 5
        Me.NudAEdgeLeftTopMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleAEdgeLimit
        '
        Me.LblTitleAEdgeLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAEdgeLimit.BDrawBorderBottom = True
        Me.LblTitleAEdgeLimit.BDrawBorderLeft = True
        Me.LblTitleAEdgeLimit.BDrawBorderRight = False
        Me.LblTitleAEdgeLimit.BDrawBorderTop = False
        Me.LblTitleAEdgeLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleAEdgeLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAEdgeLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAEdgeLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleAEdgeLimit.Name = "LblTitleAEdgeLimit"
        Me.LblTitleAEdgeLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAEdgeLimit.Size = New System.Drawing.Size(534, 40)
        Me.LblTitleAEdgeLimit.TabIndex = 4
        Me.LblTitleAEdgeLimit.Text = "Edge Limit (mm)"
        Me.LblTitleAEdgeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlAAlignmentLimit
        '
        Me.PnlAAlignmentLimit.BDrawBorderBottom = True
        Me.PnlAAlignmentLimit.BDrawBorderLeft = True
        Me.PnlAAlignmentLimit.BDrawBorderRight = False
        Me.PnlAAlignmentLimit.BDrawBorderTop = False
        Me.PnlAAlignmentLimit.Controls.Add(Me.LblTitleAAlignmentLeftXLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.LblTitleAAlignmentLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.LblTitleAAlignmentYLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.LblTitleAAlignmentTLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.NudAAlignmentLeftXLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.LblTitleAAlignmentRightXLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.NudAAlignmentRightXLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.NudAAlignmentYLimit)
        Me.PnlAAlignmentLimit.Controls.Add(Me.NudAAlignmentTLimit)
        Me.PnlAAlignmentLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlAAlignmentLimit.Location = New System.Drawing.Point(0, 40)
        Me.PnlAAlignmentLimit.Name = "PnlAAlignmentLimit"
        Me.PnlAAlignmentLimit.Size = New System.Drawing.Size(534, 120)
        Me.PnlAAlignmentLimit.TabIndex = 11
        '
        'LblTitleAAlignmentLeftXLimit
        '
        Me.LblTitleAAlignmentLeftXLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentLeftXLimit.BDrawBorderBottom = True
        Me.LblTitleAAlignmentLeftXLimit.BDrawBorderLeft = True
        Me.LblTitleAAlignmentLeftXLimit.BDrawBorderRight = True
        Me.LblTitleAAlignmentLeftXLimit.BDrawBorderTop = False
        Me.LblTitleAAlignmentLeftXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentLeftXLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentLeftXLimit.Location = New System.Drawing.Point(0, 40)
        Me.LblTitleAAlignmentLeftXLimit.Name = "LblTitleAAlignmentLeftXLimit"
        Me.LblTitleAAlignmentLeftXLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentLeftXLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAAlignmentLeftXLimit.TabIndex = 4
        Me.LblTitleAAlignmentLeftXLimit.Text = "X Left"
        Me.LblTitleAAlignmentLeftXLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAAlignmentLimit
        '
        Me.LblTitleAAlignmentLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentLimit.BDrawBorderBottom = True
        Me.LblTitleAAlignmentLimit.BDrawBorderLeft = True
        Me.LblTitleAAlignmentLimit.BDrawBorderRight = False
        Me.LblTitleAAlignmentLimit.BDrawBorderTop = False
        Me.LblTitleAAlignmentLimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleAAlignmentLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentLimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleAAlignmentLimit.Name = "LblTitleAAlignmentLimit"
        Me.LblTitleAAlignmentLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentLimit.Size = New System.Drawing.Size(534, 40)
        Me.LblTitleAAlignmentLimit.TabIndex = 14
        Me.LblTitleAAlignmentLimit.Text = "Alignment Limit (X, Y=mm, T=deg)"
        Me.LblTitleAAlignmentLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAAlignmentYLimit
        '
        Me.LblTitleAAlignmentYLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentYLimit.BDrawBorderBottom = True
        Me.LblTitleAAlignmentYLimit.BDrawBorderLeft = True
        Me.LblTitleAAlignmentYLimit.BDrawBorderRight = True
        Me.LblTitleAAlignmentYLimit.BDrawBorderTop = False
        Me.LblTitleAAlignmentYLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentYLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentYLimit.Location = New System.Drawing.Point(267, 40)
        Me.LblTitleAAlignmentYLimit.Name = "LblTitleAAlignmentYLimit"
        Me.LblTitleAAlignmentYLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentYLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAAlignmentYLimit.TabIndex = 4
        Me.LblTitleAAlignmentYLimit.Text = "Y"
        Me.LblTitleAAlignmentYLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleAAlignmentTLimit
        '
        Me.LblTitleAAlignmentTLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentTLimit.BDrawBorderBottom = True
        Me.LblTitleAAlignmentTLimit.BDrawBorderLeft = True
        Me.LblTitleAAlignmentTLimit.BDrawBorderRight = True
        Me.LblTitleAAlignmentTLimit.BDrawBorderTop = False
        Me.LblTitleAAlignmentTLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentTLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentTLimit.Location = New System.Drawing.Point(267, 80)
        Me.LblTitleAAlignmentTLimit.Name = "LblTitleAAlignmentTLimit"
        Me.LblTitleAAlignmentTLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentTLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAAlignmentTLimit.TabIndex = 4
        Me.LblTitleAAlignmentTLimit.Text = "T"
        Me.LblTitleAAlignmentTLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudAAlignmentLeftXLimit
        '
        Me.NudAAlignmentLeftXLimit.DecimalPlaces = 3
        Me.NudAAlignmentLeftXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAAlignmentLeftXLimit.Location = New System.Drawing.Point(125, 46)
        Me.NudAAlignmentLeftXLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAAlignmentLeftXLimit.Name = "NudAAlignmentLeftXLimit"
        Me.NudAAlignmentLeftXLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudAAlignmentLeftXLimit.TabIndex = 5
        Me.NudAAlignmentLeftXLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleAAlignmentRightXLimit
        '
        Me.LblTitleAAlignmentRightXLimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleAAlignmentRightXLimit.BDrawBorderBottom = True
        Me.LblTitleAAlignmentRightXLimit.BDrawBorderLeft = True
        Me.LblTitleAAlignmentRightXLimit.BDrawBorderRight = True
        Me.LblTitleAAlignmentRightXLimit.BDrawBorderTop = False
        Me.LblTitleAAlignmentRightXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleAAlignmentRightXLimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleAAlignmentRightXLimit.Location = New System.Drawing.Point(0, 80)
        Me.LblTitleAAlignmentRightXLimit.Name = "LblTitleAAlignmentRightXLimit"
        Me.LblTitleAAlignmentRightXLimit.OColor = System.Drawing.Color.Black
        Me.LblTitleAAlignmentRightXLimit.Size = New System.Drawing.Size(120, 40)
        Me.LblTitleAAlignmentRightXLimit.TabIndex = 4
        Me.LblTitleAAlignmentRightXLimit.Text = "X Right "
        Me.LblTitleAAlignmentRightXLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'NudAAlignmentRightXLimit
        '
        Me.NudAAlignmentRightXLimit.DecimalPlaces = 3
        Me.NudAAlignmentRightXLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAAlignmentRightXLimit.Location = New System.Drawing.Point(125, 85)
        Me.NudAAlignmentRightXLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAAlignmentRightXLimit.Name = "NudAAlignmentRightXLimit"
        Me.NudAAlignmentRightXLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudAAlignmentRightXLimit.TabIndex = 5
        Me.NudAAlignmentRightXLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAAlignmentYLimit
        '
        Me.NudAAlignmentYLimit.DecimalPlaces = 3
        Me.NudAAlignmentYLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAAlignmentYLimit.Location = New System.Drawing.Point(393, 46)
        Me.NudAAlignmentYLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAAlignmentYLimit.Name = "NudAAlignmentYLimit"
        Me.NudAAlignmentYLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudAAlignmentYLimit.TabIndex = 5
        Me.NudAAlignmentYLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'NudAAlignmentTLimit
        '
        Me.NudAAlignmentTLimit.DecimalPlaces = 4
        Me.NudAAlignmentTLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.NudAAlignmentTLimit.Location = New System.Drawing.Point(393, 85)
        Me.NudAAlignmentTLimit.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.NudAAlignmentTLimit.Name = "NudAAlignmentTLimit"
        Me.NudAAlignmentTLimit.Size = New System.Drawing.Size(135, 30)
        Me.NudAAlignmentTLimit.TabIndex = 5
        Me.NudAAlignmentTLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTitleALimit
        '
        Me.LblTitleALimit.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleALimit.BDrawBorderBottom = True
        Me.LblTitleALimit.BDrawBorderLeft = True
        Me.LblTitleALimit.BDrawBorderRight = False
        Me.LblTitleALimit.BDrawBorderTop = True
        Me.LblTitleALimit.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleALimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleALimit.ForeColor = System.Drawing.Color.White
        Me.LblTitleALimit.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleALimit.Name = "LblTitleALimit"
        Me.LblTitleALimit.OColor = System.Drawing.Color.Black
        Me.LblTitleALimit.Size = New System.Drawing.Size(534, 40)
        Me.LblTitleALimit.TabIndex = 10
        Me.LblTitleALimit.Text = "ST #1 Limit"
        Me.LblTitleALimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlKind
        '
        Me.PnlKind.BDrawBorderBottom = False
        Me.PnlKind.BDrawBorderLeft = False
        Me.PnlKind.BDrawBorderRight = False
        Me.PnlKind.BDrawBorderTop = False
        Me.PnlKind.Controls.Add(Me.PnlKind3)
        Me.PnlKind.Controls.Add(Me.PnlKind1)
        Me.PnlKind.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlKind.Location = New System.Drawing.Point(0, 0)
        Me.PnlKind.Name = "PnlKind"
        Me.PnlKind.Size = New System.Drawing.Size(1080, 280)
        Me.PnlKind.TabIndex = 0
        '
        'PnlKind3
        '
        Me.PnlKind3.BDrawBorderBottom = False
        Me.PnlKind3.BDrawBorderLeft = False
        Me.PnlKind3.BDrawBorderRight = False
        Me.PnlKind3.BDrawBorderTop = False
        Me.PnlKind3.Controls.Add(Me.PnlMark)
        Me.PnlKind3.Controls.Add(Me.PnlIndex)
        Me.PnlKind3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlKind3.Location = New System.Drawing.Point(400, 0)
        Me.PnlKind3.Name = "PnlKind3"
        Me.PnlKind3.Size = New System.Drawing.Size(680, 280)
        Me.PnlKind3.TabIndex = 4
        '
        'PnlMark
        '
        Me.PnlMark.BDrawBorderBottom = False
        Me.PnlMark.BDrawBorderLeft = False
        Me.PnlMark.BDrawBorderRight = False
        Me.PnlMark.BDrawBorderTop = False
        Me.PnlMark.Controls.Add(Me.PnlMark4)
        Me.PnlMark.Controls.Add(Me.PnlMark3)
        Me.PnlMark.Controls.Add(Me.PnlMark2)
        Me.PnlMark.Controls.Add(Me.PnlMark1)
        Me.PnlMark.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMark.Location = New System.Drawing.Point(0, 90)
        Me.PnlMark.Name = "PnlMark"
        Me.PnlMark.Size = New System.Drawing.Size(680, 190)
        Me.PnlMark.TabIndex = 4
        '
        'PnlMark4
        '
        Me.PnlMark4.BDrawBorderBottom = False
        Me.PnlMark4.BDrawBorderLeft = False
        Me.PnlMark4.BDrawBorderRight = False
        Me.PnlMark4.BDrawBorderTop = False
        Me.PnlMark4.Controls.Add(Me.CdpMark4)
        Me.PnlMark4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMark4.Location = New System.Drawing.Point(510, 0)
        Me.PnlMark4.Name = "PnlMark4"
        Me.PnlMark4.Size = New System.Drawing.Size(170, 190)
        Me.PnlMark4.TabIndex = 3
        '
        'CdpMark4
        '
        Me.CdpMark4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpMark4.Location = New System.Drawing.Point(0, 0)
        Me.CdpMark4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpMark4.MouseWheelSensitivity = 1
        Me.CdpMark4.Name = "CdpMark4"
        Me.CdpMark4.OcxState = CType(resources.GetObject("CdpMark4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpMark4.Size = New System.Drawing.Size(170, 190)
        Me.CdpMark4.TabIndex = 2
        '
        'PnlMark3
        '
        Me.PnlMark3.BDrawBorderBottom = False
        Me.PnlMark3.BDrawBorderLeft = False
        Me.PnlMark3.BDrawBorderRight = False
        Me.PnlMark3.BDrawBorderTop = False
        Me.PnlMark3.Controls.Add(Me.CdpMark3)
        Me.PnlMark3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlMark3.Location = New System.Drawing.Point(340, 0)
        Me.PnlMark3.Name = "PnlMark3"
        Me.PnlMark3.Size = New System.Drawing.Size(170, 190)
        Me.PnlMark3.TabIndex = 2
        '
        'CdpMark3
        '
        Me.CdpMark3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpMark3.Location = New System.Drawing.Point(0, 0)
        Me.CdpMark3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpMark3.MouseWheelSensitivity = 1
        Me.CdpMark3.Name = "CdpMark3"
        Me.CdpMark3.OcxState = CType(resources.GetObject("CdpMark3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpMark3.Size = New System.Drawing.Size(170, 190)
        Me.CdpMark3.TabIndex = 2
        '
        'PnlMark2
        '
        Me.PnlMark2.BDrawBorderBottom = False
        Me.PnlMark2.BDrawBorderLeft = False
        Me.PnlMark2.BDrawBorderRight = False
        Me.PnlMark2.BDrawBorderTop = False
        Me.PnlMark2.Controls.Add(Me.CdpMark2)
        Me.PnlMark2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlMark2.Location = New System.Drawing.Point(170, 0)
        Me.PnlMark2.Name = "PnlMark2"
        Me.PnlMark2.Size = New System.Drawing.Size(170, 190)
        Me.PnlMark2.TabIndex = 1
        '
        'CdpMark2
        '
        Me.CdpMark2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpMark2.Location = New System.Drawing.Point(0, 0)
        Me.CdpMark2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpMark2.MouseWheelSensitivity = 1
        Me.CdpMark2.Name = "CdpMark2"
        Me.CdpMark2.OcxState = CType(resources.GetObject("CdpMark2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpMark2.Size = New System.Drawing.Size(170, 190)
        Me.CdpMark2.TabIndex = 2
        '
        'PnlMark1
        '
        Me.PnlMark1.BDrawBorderBottom = False
        Me.PnlMark1.BDrawBorderLeft = False
        Me.PnlMark1.BDrawBorderRight = False
        Me.PnlMark1.BDrawBorderTop = False
        Me.PnlMark1.Controls.Add(Me.CdpMark1)
        Me.PnlMark1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlMark1.Location = New System.Drawing.Point(0, 0)
        Me.PnlMark1.Name = "PnlMark1"
        Me.PnlMark1.Size = New System.Drawing.Size(170, 190)
        Me.PnlMark1.TabIndex = 0
        '
        'CdpMark1
        '
        Me.CdpMark1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CdpMark1.Location = New System.Drawing.Point(0, 0)
        Me.CdpMark1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1
        Me.CdpMark1.MouseWheelSensitivity = 1
        Me.CdpMark1.Name = "CdpMark1"
        Me.CdpMark1.OcxState = CType(resources.GetObject("CdpMark1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CdpMark1.Size = New System.Drawing.Size(170, 190)
        Me.CdpMark1.TabIndex = 1
        '
        'PnlIndex
        '
        Me.PnlIndex.BDrawBorderBottom = True
        Me.PnlIndex.BDrawBorderLeft = True
        Me.PnlIndex.BDrawBorderRight = False
        Me.PnlIndex.BDrawBorderTop = False
        Me.PnlIndex.Controls.Add(Me.LblTitleIndex)
        Me.PnlIndex.Controls.Add(Me.BtnIndex4)
        Me.PnlIndex.Controls.Add(Me.BtnIndex3)
        Me.PnlIndex.Controls.Add(Me.BtnIndex2)
        Me.PnlIndex.Controls.Add(Me.BtnIndex1)
        Me.PnlIndex.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlIndex.Location = New System.Drawing.Point(0, 0)
        Me.PnlIndex.Name = "PnlIndex"
        Me.PnlIndex.Size = New System.Drawing.Size(680, 90)
        Me.PnlIndex.TabIndex = 3
        '
        'LblTitleIndex
        '
        Me.LblTitleIndex.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleIndex.BDrawBorderBottom = True
        Me.LblTitleIndex.BDrawBorderLeft = True
        Me.LblTitleIndex.BDrawBorderRight = False
        Me.LblTitleIndex.BDrawBorderTop = False
        Me.LblTitleIndex.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleIndex.ForeColor = System.Drawing.Color.White
        Me.LblTitleIndex.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleIndex.Name = "LblTitleIndex"
        Me.LblTitleIndex.OColor = System.Drawing.Color.Black
        Me.LblTitleIndex.Size = New System.Drawing.Size(680, 40)
        Me.LblTitleIndex.TabIndex = 2
        Me.LblTitleIndex.Text = "Index"
        Me.LblTitleIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnIndex4
        '
        Me.BtnIndex4.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnIndex4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnIndex4.ForeColor = System.Drawing.Color.White
        Me.BtnIndex4.Location = New System.Drawing.Point(511, 42)
        Me.BtnIndex4.Name = "BtnIndex4"
        Me.BtnIndex4.Size = New System.Drawing.Size(162, 46)
        Me.BtnIndex4.TabIndex = 5
        Me.BtnIndex4.Tag = "INDEX4"
        Me.BtnIndex4.Text = "4"
        Me.BtnIndex4.UseVisualStyleBackColor = False
        '
        'BtnIndex3
        '
        Me.BtnIndex3.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnIndex3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnIndex3.ForeColor = System.Drawing.Color.White
        Me.BtnIndex3.Location = New System.Drawing.Point(343, 42)
        Me.BtnIndex3.Name = "BtnIndex3"
        Me.BtnIndex3.Size = New System.Drawing.Size(162, 46)
        Me.BtnIndex3.TabIndex = 5
        Me.BtnIndex3.Tag = "INDEX3"
        Me.BtnIndex3.Text = "3"
        Me.BtnIndex3.UseVisualStyleBackColor = False
        '
        'BtnIndex2
        '
        Me.BtnIndex2.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnIndex2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnIndex2.ForeColor = System.Drawing.Color.White
        Me.BtnIndex2.Location = New System.Drawing.Point(175, 42)
        Me.BtnIndex2.Name = "BtnIndex2"
        Me.BtnIndex2.Size = New System.Drawing.Size(162, 46)
        Me.BtnIndex2.TabIndex = 5
        Me.BtnIndex2.Tag = "INDEX2"
        Me.BtnIndex2.Text = "2"
        Me.BtnIndex2.UseVisualStyleBackColor = False
        '
        'BtnIndex1
        '
        Me.BtnIndex1.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnIndex1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnIndex1.ForeColor = System.Drawing.Color.White
        Me.BtnIndex1.Location = New System.Drawing.Point(7, 42)
        Me.BtnIndex1.Name = "BtnIndex1"
        Me.BtnIndex1.Size = New System.Drawing.Size(162, 46)
        Me.BtnIndex1.TabIndex = 5
        Me.BtnIndex1.Tag = "INDEX1"
        Me.BtnIndex1.Text = "1"
        Me.BtnIndex1.UseVisualStyleBackColor = False
        '
        'PnlKind1
        '
        Me.PnlKind1.BDrawBorderBottom = False
        Me.PnlKind1.BDrawBorderLeft = False
        Me.PnlKind1.BDrawBorderRight = False
        Me.PnlKind1.BDrawBorderTop = False
        Me.PnlKind1.Controls.Add(Me.PnlEtc)
        Me.PnlKind1.Controls.Add(Me.PnlTool)
        Me.PnlKind1.Controls.Add(Me.PnlCamera)
        Me.PnlKind1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlKind1.Location = New System.Drawing.Point(0, 0)
        Me.PnlKind1.Name = "PnlKind1"
        Me.PnlKind1.Size = New System.Drawing.Size(400, 280)
        Me.PnlKind1.TabIndex = 0
        '
        'PnlEtc
        '
        Me.PnlEtc.BDrawBorderBottom = True
        Me.PnlEtc.BDrawBorderLeft = True
        Me.PnlEtc.BDrawBorderRight = False
        Me.PnlEtc.BDrawBorderTop = False
        Me.PnlEtc.Controls.Add(Me.LblTitleEtc)
        Me.PnlEtc.Controls.Add(Me.BtnToolDetail)
        Me.PnlEtc.Controls.Add(Me.BtnImageGrab)
        Me.PnlEtc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlEtc.Location = New System.Drawing.Point(200, 140)
        Me.PnlEtc.Name = "PnlEtc"
        Me.PnlEtc.Size = New System.Drawing.Size(200, 140)
        Me.PnlEtc.TabIndex = 2
        '
        'LblTitleEtc
        '
        Me.LblTitleEtc.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleEtc.BDrawBorderBottom = True
        Me.LblTitleEtc.BDrawBorderLeft = True
        Me.LblTitleEtc.BDrawBorderRight = False
        Me.LblTitleEtc.BDrawBorderTop = False
        Me.LblTitleEtc.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleEtc.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleEtc.ForeColor = System.Drawing.Color.White
        Me.LblTitleEtc.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleEtc.Name = "LblTitleEtc"
        Me.LblTitleEtc.OColor = System.Drawing.Color.Black
        Me.LblTitleEtc.Size = New System.Drawing.Size(200, 40)
        Me.LblTitleEtc.TabIndex = 2
        Me.LblTitleEtc.Text = "Etc"
        Me.LblTitleEtc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnToolDetail
        '
        Me.BtnToolDetail.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnToolDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnToolDetail.ForeColor = System.Drawing.Color.White
        Me.BtnToolDetail.Location = New System.Drawing.Point(4, 92)
        Me.BtnToolDetail.Name = "BtnToolDetail"
        Me.BtnToolDetail.Size = New System.Drawing.Size(192, 46)
        Me.BtnToolDetail.TabIndex = 5
        Me.BtnToolDetail.Text = "Detail"
        Me.BtnToolDetail.UseVisualStyleBackColor = False
        '
        'BtnImageGrab
        '
        Me.BtnImageGrab.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnImageGrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImageGrab.ForeColor = System.Drawing.Color.White
        Me.BtnImageGrab.Location = New System.Drawing.Point(4, 43)
        Me.BtnImageGrab.Name = "BtnImageGrab"
        Me.BtnImageGrab.Size = New System.Drawing.Size(192, 46)
        Me.BtnImageGrab.TabIndex = 5
        Me.BtnImageGrab.Text = "Grab"
        Me.BtnImageGrab.UseVisualStyleBackColor = False
        '
        'PnlTool
        '
        Me.PnlTool.BDrawBorderBottom = True
        Me.PnlTool.BDrawBorderLeft = True
        Me.PnlTool.BDrawBorderRight = False
        Me.PnlTool.BDrawBorderTop = False
        Me.PnlTool.Controls.Add(Me.LblTitleTool)
        Me.PnlTool.Controls.Add(Me.BtnToolEdge)
        Me.PnlTool.Controls.Add(Me.BtnToolMark)
        Me.PnlTool.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlTool.Location = New System.Drawing.Point(0, 140)
        Me.PnlTool.Name = "PnlTool"
        Me.PnlTool.Size = New System.Drawing.Size(200, 140)
        Me.PnlTool.TabIndex = 1
        '
        'LblTitleTool
        '
        Me.LblTitleTool.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleTool.BDrawBorderBottom = True
        Me.LblTitleTool.BDrawBorderLeft = True
        Me.LblTitleTool.BDrawBorderRight = False
        Me.LblTitleTool.BDrawBorderTop = False
        Me.LblTitleTool.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleTool.ForeColor = System.Drawing.Color.White
        Me.LblTitleTool.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleTool.Name = "LblTitleTool"
        Me.LblTitleTool.OColor = System.Drawing.Color.Black
        Me.LblTitleTool.Size = New System.Drawing.Size(200, 40)
        Me.LblTitleTool.TabIndex = 2
        Me.LblTitleTool.Text = "Tool"
        Me.LblTitleTool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnToolEdge
        '
        Me.BtnToolEdge.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnToolEdge.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnToolEdge.ForeColor = System.Drawing.Color.White
        Me.BtnToolEdge.Location = New System.Drawing.Point(4, 92)
        Me.BtnToolEdge.Name = "BtnToolEdge"
        Me.BtnToolEdge.Size = New System.Drawing.Size(192, 46)
        Me.BtnToolEdge.TabIndex = 5
        Me.BtnToolEdge.Tag = "EDGE"
        Me.BtnToolEdge.Text = "Edge"
        Me.BtnToolEdge.UseVisualStyleBackColor = False
        '
        'BtnToolMark
        '
        Me.BtnToolMark.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnToolMark.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnToolMark.ForeColor = System.Drawing.Color.White
        Me.BtnToolMark.Location = New System.Drawing.Point(4, 43)
        Me.BtnToolMark.Name = "BtnToolMark"
        Me.BtnToolMark.Size = New System.Drawing.Size(192, 46)
        Me.BtnToolMark.TabIndex = 5
        Me.BtnToolMark.Tag = "MARK"
        Me.BtnToolMark.Text = "Mark"
        Me.BtnToolMark.UseVisualStyleBackColor = False
        '
        'PnlCamera
        '
        Me.PnlCamera.BDrawBorderBottom = True
        Me.PnlCamera.BDrawBorderLeft = True
        Me.PnlCamera.BDrawBorderRight = False
        Me.PnlCamera.BDrawBorderTop = False
        Me.PnlCamera.Controls.Add(Me.LblTitleCamera)
        Me.PnlCamera.Controls.Add(Me.BtnCameraBRight)
        Me.PnlCamera.Controls.Add(Me.BtnCameraARight)
        Me.PnlCamera.Controls.Add(Me.BtnCameraBLeft)
        Me.PnlCamera.Controls.Add(Me.BtnCameraALeft)
        Me.PnlCamera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlCamera.Location = New System.Drawing.Point(0, 0)
        Me.PnlCamera.Name = "PnlCamera"
        Me.PnlCamera.Size = New System.Drawing.Size(400, 140)
        Me.PnlCamera.TabIndex = 0
        '
        'LblTitleCamera
        '
        Me.LblTitleCamera.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCamera.BDrawBorderBottom = True
        Me.LblTitleCamera.BDrawBorderLeft = True
        Me.LblTitleCamera.BDrawBorderRight = False
        Me.LblTitleCamera.BDrawBorderTop = False
        Me.LblTitleCamera.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCamera.ForeColor = System.Drawing.Color.White
        Me.LblTitleCamera.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleCamera.Name = "LblTitleCamera"
        Me.LblTitleCamera.OColor = System.Drawing.Color.Black
        Me.LblTitleCamera.Size = New System.Drawing.Size(400, 40)
        Me.LblTitleCamera.TabIndex = 2
        Me.LblTitleCamera.Text = "Camera"
        Me.LblTitleCamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCameraBRight
        '
        Me.BtnCameraBRight.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCameraBRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCameraBRight.ForeColor = System.Drawing.Color.White
        Me.BtnCameraBRight.Location = New System.Drawing.Point(204, 91)
        Me.BtnCameraBRight.Name = "BtnCameraBRight"
        Me.BtnCameraBRight.Size = New System.Drawing.Size(192, 46)
        Me.BtnCameraBRight.TabIndex = 5
        Me.BtnCameraBRight.Tag = "B_RIGHT"
        Me.BtnCameraBRight.Text = "#2 - Right"
        Me.BtnCameraBRight.UseVisualStyleBackColor = False
        '
        'BtnCameraARight
        '
        Me.BtnCameraARight.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCameraARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCameraARight.ForeColor = System.Drawing.Color.White
        Me.BtnCameraARight.Location = New System.Drawing.Point(4, 91)
        Me.BtnCameraARight.Name = "BtnCameraARight"
        Me.BtnCameraARight.Size = New System.Drawing.Size(192, 46)
        Me.BtnCameraARight.TabIndex = 5
        Me.BtnCameraARight.Tag = "A_RIGHT"
        Me.BtnCameraARight.Text = "#1 - Right"
        Me.BtnCameraARight.UseVisualStyleBackColor = False
        '
        'BtnCameraBLeft
        '
        Me.BtnCameraBLeft.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCameraBLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCameraBLeft.ForeColor = System.Drawing.Color.White
        Me.BtnCameraBLeft.Location = New System.Drawing.Point(204, 42)
        Me.BtnCameraBLeft.Name = "BtnCameraBLeft"
        Me.BtnCameraBLeft.Size = New System.Drawing.Size(192, 46)
        Me.BtnCameraBLeft.TabIndex = 5
        Me.BtnCameraBLeft.Tag = "B_LEFT"
        Me.BtnCameraBLeft.Text = "#2 - Left"
        Me.BtnCameraBLeft.UseVisualStyleBackColor = False
        '
        'BtnCameraALeft
        '
        Me.BtnCameraALeft.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnCameraALeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCameraALeft.ForeColor = System.Drawing.Color.White
        Me.BtnCameraALeft.Location = New System.Drawing.Point(4, 42)
        Me.BtnCameraALeft.Name = "BtnCameraALeft"
        Me.BtnCameraALeft.Size = New System.Drawing.Size(192, 46)
        Me.BtnCameraALeft.TabIndex = 5
        Me.BtnCameraALeft.Tag = "A_LEFT"
        Me.BtnCameraALeft.Text = "#1 - Left"
        Me.BtnCameraALeft.UseVisualStyleBackColor = False
        '
        'UcRecipe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.PnlRight)
        Me.Controls.Add(Me.PnlLeft)
        Me.Controls.Add(Me.PnlTitle)
        Me.Name = "UcRecipe"
        Me.PnlList.ResumeLayout(False)
        Me.PnlEdit.ResumeLayout(False)
        Me.PnlEdit.PerformLayout()
        CType(Me.NudID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlLeft.ResumeLayout(False)
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlRight.ResumeLayout(False)
        Me.TabDetail.ResumeLayout(False)
        Me.PageTool.ResumeLayout(False)
        CType(Me.CdpDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlToolEdge.ResumeLayout(False)
        CType(Me.CceCaliper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlToolMark.ResumeLayout(False)
        CType(Me.CpePattern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PageLimit.ResumeLayout(False)
        Me.PnlLimit.ResumeLayout(False)
        Me.PnlBLimit.ResumeLayout(False)
        Me.PnlBEdgeLimit.ResumeLayout(False)
        Me.PnlBEdgeRightLimit.ResumeLayout(False)
        CType(Me.NudBEdgeRightTopMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBEdgeRightBottomMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBEdgeRightBottomMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBEdgeRightTopMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBEdgeLeftLimit.ResumeLayout(False)
        CType(Me.NudBEdgeLeftTopMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBEdgeLeftBottomMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBEdgeLeftBottomMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBEdgeLeftTopMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBAlignmentLimit.ResumeLayout(False)
        CType(Me.NudBAlignmentTLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBAlignmentLeftXLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBAlignmentRightXLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBAlignmentYLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlALimit.ResumeLayout(False)
        Me.PnlAEdgeLimit.ResumeLayout(False)
        Me.PnlAEdgeRightLimit.ResumeLayout(False)
        CType(Me.NudAEdgeRightBottomMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAEdgeRightBottomMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAEdgeRightTopMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAEdgeRightTopMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAEdgeLeftLimit.ResumeLayout(False)
        CType(Me.NudAEdgeLeftBottomMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAEdgeLeftBottomMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAEdgeLeftTopMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAEdgeLeftTopMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlAAlignmentLimit.ResumeLayout(False)
        CType(Me.NudAAlignmentLeftXLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAAlignmentRightXLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAAlignmentYLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudAAlignmentTLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlKind.ResumeLayout(False)
        Me.PnlKind3.ResumeLayout(False)
        Me.PnlMark.ResumeLayout(False)
        Me.PnlMark4.ResumeLayout(False)
        CType(Me.CdpMark4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMark3.ResumeLayout(False)
        CType(Me.CdpMark3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMark2.ResumeLayout(False)
        CType(Me.CdpMark2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlMark1.ResumeLayout(False)
        CType(Me.CdpMark1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlIndex.ResumeLayout(False)
        Me.PnlKind1.ResumeLayout(False)
        Me.PnlEtc.ResumeLayout(False)
        Me.PnlTool.ResumeLayout(False)
        Me.PnlCamera.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlList As Jhjo.Component.CPanel
    Friend WithEvents PnlEdit As Jhjo.Component.CPanel
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents PnlLeft As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnApply As System.Windows.Forms.Button
    Friend WithEvents BtnCopy As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnModify As System.Windows.Forms.Button
    Friend WithEvents LtbList As System.Windows.Forms.ListBox
    Friend WithEvents PnlRight As Jhjo.Component.CPanel
    Friend WithEvents PnlKind As Jhjo.Component.CPanel
    Friend WithEvents PnlCamera As Jhjo.Component.CPanel
    Friend WithEvents LblTitleCamera As Jhjo.Component.CLabel
    Friend WithEvents BtnCameraARight As System.Windows.Forms.Button
    Friend WithEvents BtnCameraALeft As System.Windows.Forms.Button
    Friend WithEvents BtnCameraBRight As System.Windows.Forms.Button
    Friend WithEvents BtnCameraBLeft As System.Windows.Forms.Button
    Friend WithEvents PnlEtc As Jhjo.Component.CPanel
    Friend WithEvents LblTitleEtc As Jhjo.Component.CLabel
    Friend WithEvents BtnImageGrab As System.Windows.Forms.Button
    Friend WithEvents PnlTool As Jhjo.Component.CPanel
    Friend WithEvents LblTitleTool As Jhjo.Component.CLabel
    Friend WithEvents BtnToolEdge As System.Windows.Forms.Button
    Friend WithEvents BtnToolMark As System.Windows.Forms.Button
    Friend WithEvents PnlIndex As Jhjo.Component.CPanel
    Friend WithEvents LblTitleIndex As Jhjo.Component.CLabel
    Friend WithEvents BtnIndex4 As System.Windows.Forms.Button
    Friend WithEvents BtnIndex3 As System.Windows.Forms.Button
    Friend WithEvents BtnIndex2 As System.Windows.Forms.Button
    Friend WithEvents BtnIndex1 As System.Windows.Forms.Button
    Friend WithEvents PnlKind3 As Jhjo.Component.CPanel
    Friend WithEvents PnlMark As Jhjo.Component.CPanel
    Friend WithEvents PnlMark1 As Jhjo.Component.CPanel
    Friend WithEvents PnlMark4 As Jhjo.Component.CPanel
    Friend WithEvents PnlMark3 As Jhjo.Component.CPanel
    Friend WithEvents PnlMark2 As Jhjo.Component.CPanel
    Friend WithEvents CdpMark1 As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents CdpMark4 As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents CdpMark3 As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents CdpMark2 As Cognex.VisionPro.Display.CogDisplay
    Friend WithEvents PnlScreen As Jhjo.Component.CPanel
    Friend WithEvents PnlBLimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleAEdgeLeftTopMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeRightTopMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeLeftTopMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeLeftTopMax As Jhjo.Component.CLabel
    Friend WithEvents NudBEdgeRightTopMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBEdgeLeftTopMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAEdgeLeftTopMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAEdgeLeftTopMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents PnlLimit As Jhjo.Component.CPanel
    Friend WithEvents PnlALimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleBAlignmentLeftXLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentLeftXLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentTLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentRightXLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentRightXLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentYLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAAlignmentYLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBAlignmentTLimit As Jhjo.Component.CLabel
    Friend WithEvents NudBAlignmentTLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAAlignmentTLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBAlignmentYLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAAlignmentYLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBAlignmentRightXLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAAlignmentRightXLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBAlignmentLeftXLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAAlignmentLeftXLimit As System.Windows.Forms.NumericUpDown
    Friend WithEvents TabDetail As System.Windows.Forms.TabControl
    Friend WithEvents PageLimit As System.Windows.Forms.TabPage
    Friend WithEvents LblTitleName As Jhjo.Component.CLabel
    Friend WithEvents LblTitleID As Jhjo.Component.CLabel
    Friend WithEvents NudID As System.Windows.Forms.NumericUpDown
    Friend WithEvents LblTitleBLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleALimit As Jhjo.Component.CLabel
    Friend WithEvents PnlBAlignmentLimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleBAlignmentLimit As Jhjo.Component.CLabel
    Friend WithEvents PnlAAlignmentLimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleAAlignmentLimit As Jhjo.Component.CLabel
    Friend WithEvents PnlAEdgeLimit As Jhjo.Component.CPanel
    Friend WithEvents PnlAEdgeRightLimit As Jhjo.Component.CPanel
    Friend WithEvents PnlAEdgeLeftLimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleAEdgeLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeRightLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeLeftLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeLeftBottomMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeLeftBottomMax As Jhjo.Component.CLabel
    Friend WithEvents NudAEdgeLeftBottomMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAEdgeLeftBottomMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents PnlBEdgeLimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleBEdgeLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeRightBottomMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeRightTopMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeRightBottomMax As Jhjo.Component.CLabel
    Friend WithEvents LblTitleAEdgeRightTopMax As Jhjo.Component.CLabel
    Friend WithEvents NudAEdgeRightBottomMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAEdgeRightBottomMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAEdgeRightTopMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudAEdgeRightTopMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents PnlBEdgeRightLimit As Jhjo.Component.CPanel
    Friend WithEvents PnlBEdgeLeftLimit As Jhjo.Component.CPanel
    Friend WithEvents LblTitleBEdgeRightLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeLeftLimit As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeRightBottomMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeRightBottomMax As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeRightTopMax As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeLeftBottomMin As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeLeftBottomMax As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBEdgeLeftTopMax As Jhjo.Component.CLabel
    Friend WithEvents NudBEdgeRightBottomMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBEdgeRightBottomMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBEdgeRightTopMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBEdgeLeftBottomMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBEdgeLeftBottomMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NudBEdgeLeftTopMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents BtnRename As System.Windows.Forms.Button
    Friend WithEvents PnlKind1 As Jhjo.Component.CPanel
    Friend WithEvents BtnToolDetail As System.Windows.Forms.Button
    Friend WithEvents PnlToolEdge As Jhjo.Component.CPanel
    Friend WithEvents PnlToolMark As Jhjo.Component.CPanel
    Friend WithEvents CceCaliper As Cognex.VisionPro.Caliper.CogCaliperEditV2
    Friend WithEvents CpePattern As Cognex.VisionPro.PMAlign.CogPMAlignEditV2
    Friend WithEvents CdpDesign As Cognex.VisionPro.Display.CogDisplay
    Private WithEvents PageTool As System.Windows.Forms.TabPage

End Class
