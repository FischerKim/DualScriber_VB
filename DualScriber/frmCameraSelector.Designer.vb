<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCameraSelector
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DgvList = New System.Windows.Forms.DataGridView
        Me.ColModel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColIP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColSerial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BtnClose = New System.Windows.Forms.Button
        Me.PnlTitle = New Jhjo.Component.CPanel
        Me.LblTitle = New Jhjo.Component.CLabel
        Me.PnlButton = New Jhjo.Component.CPanel
        Me.BtnApply = New System.Windows.Forms.Button
        Me.PnlData = New Jhjo.Component.CPanel
        Me.PnlList = New Jhjo.Component.CPanel
        Me.PnlInfo = New Jhjo.Component.CPanel
        Me.LblTitleBRight = New Jhjo.Component.CLabel
        Me.BtnSelectBRight = New System.Windows.Forms.Button
        Me.BtnSelectARight = New System.Windows.Forms.Button
        Me.BtnSelectBLeft = New System.Windows.Forms.Button
        Me.BtnSelectALeft = New System.Windows.Forms.Button
        Me.LblTitleBLeft = New Jhjo.Component.CLabel
        Me.LblTitleARight = New Jhjo.Component.CLabel
        Me.LblBRight = New Jhjo.Component.CLabel
        Me.LblBLeft = New Jhjo.Component.CLabel
        Me.LblARight = New Jhjo.Component.CLabel
        Me.LblALeft = New Jhjo.Component.CLabel
        Me.LblTitleALeft = New Jhjo.Component.CLabel
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlTitle.SuspendLayout()
        Me.PnlButton.SuspendLayout()
        Me.PnlData.SuspendLayout()
        Me.PnlList.SuspendLayout()
        Me.PnlInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvList
        '
        Me.DgvList.AllowUserToAddRows = False
        Me.DgvList.AllowUserToDeleteRows = False
        Me.DgvList.AllowUserToResizeColumns = False
        Me.DgvList.AllowUserToResizeRows = False
        Me.DgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DgvList.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColModel, Me.ColIP, Me.ColSerial})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgvList.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgvList.Location = New System.Drawing.Point(0, 0)
        Me.DgvList.MultiSelect = False
        Me.DgvList.Name = "DgvList"
        Me.DgvList.RowHeadersVisible = False
        Me.DgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvList.Size = New System.Drawing.Size(513, 282)
        Me.DgvList.TabIndex = 0
        Me.DgvList.TabStop = False
        '
        'ColModel
        '
        Me.ColModel.DataPropertyName = "MODEL"
        Me.ColModel.HeaderText = "Model"
        Me.ColModel.Name = "ColModel"
        '
        'ColIP
        '
        Me.ColIP.DataPropertyName = "IP"
        Me.ColIP.HeaderText = "IP"
        Me.ColIP.Name = "ColIP"
        '
        'ColSerial
        '
        Me.ColSerial.DataPropertyName = "SERIAL"
        Me.ColSerial.HeaderText = "Serial"
        Me.ColSerial.Name = "ColSerial"
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnClose.ForeColor = System.Drawing.Color.White
        Me.BtnClose.Location = New System.Drawing.Point(360, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(150, 45)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = False
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
        Me.PnlTitle.Size = New System.Drawing.Size(513, 40)
        Me.PnlTitle.TabIndex = 2
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
        Me.LblTitle.Size = New System.Drawing.Size(513, 40)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "Select Camera"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlButton
        '
        Me.PnlButton.BDrawBorderBottom = False
        Me.PnlButton.BDrawBorderLeft = False
        Me.PnlButton.BDrawBorderRight = False
        Me.PnlButton.BDrawBorderTop = True
        Me.PnlButton.Controls.Add(Me.BtnApply)
        Me.PnlButton.Controls.Add(Me.BtnClose)
        Me.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButton.Location = New System.Drawing.Point(0, 522)
        Me.PnlButton.Name = "PnlButton"
        Me.PnlButton.Size = New System.Drawing.Size(513, 50)
        Me.PnlButton.TabIndex = 3
        '
        'BtnApply
        '
        Me.BtnApply.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnApply.ForeColor = System.Drawing.Color.White
        Me.BtnApply.Location = New System.Drawing.Point(204, 2)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(150, 45)
        Me.BtnApply.TabIndex = 4
        Me.BtnApply.Text = "&Apply"
        Me.BtnApply.UseVisualStyleBackColor = False
        '
        'PnlData
        '
        Me.PnlData.BDrawBorderBottom = False
        Me.PnlData.BDrawBorderLeft = False
        Me.PnlData.BDrawBorderRight = False
        Me.PnlData.BDrawBorderTop = False
        Me.PnlData.Controls.Add(Me.PnlList)
        Me.PnlData.Controls.Add(Me.PnlInfo)
        Me.PnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlData.Location = New System.Drawing.Point(0, 40)
        Me.PnlData.Name = "PnlData"
        Me.PnlData.Size = New System.Drawing.Size(513, 482)
        Me.PnlData.TabIndex = 4
        '
        'PnlList
        '
        Me.PnlList.BDrawBorderBottom = False
        Me.PnlList.BDrawBorderLeft = False
        Me.PnlList.BDrawBorderRight = False
        Me.PnlList.BDrawBorderTop = False
        Me.PnlList.Controls.Add(Me.DgvList)
        Me.PnlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlList.Location = New System.Drawing.Point(0, 200)
        Me.PnlList.Name = "PnlList"
        Me.PnlList.Size = New System.Drawing.Size(513, 282)
        Me.PnlList.TabIndex = 1
        '
        'PnlInfo
        '
        Me.PnlInfo.BDrawBorderBottom = True
        Me.PnlInfo.BDrawBorderLeft = False
        Me.PnlInfo.BDrawBorderRight = False
        Me.PnlInfo.BDrawBorderTop = False
        Me.PnlInfo.Controls.Add(Me.LblTitleBRight)
        Me.PnlInfo.Controls.Add(Me.BtnSelectBRight)
        Me.PnlInfo.Controls.Add(Me.BtnSelectARight)
        Me.PnlInfo.Controls.Add(Me.BtnSelectBLeft)
        Me.PnlInfo.Controls.Add(Me.BtnSelectALeft)
        Me.PnlInfo.Controls.Add(Me.LblTitleBLeft)
        Me.PnlInfo.Controls.Add(Me.LblTitleARight)
        Me.PnlInfo.Controls.Add(Me.LblBRight)
        Me.PnlInfo.Controls.Add(Me.LblBLeft)
        Me.PnlInfo.Controls.Add(Me.LblARight)
        Me.PnlInfo.Controls.Add(Me.LblALeft)
        Me.PnlInfo.Controls.Add(Me.LblTitleALeft)
        Me.PnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlInfo.Location = New System.Drawing.Point(0, 0)
        Me.PnlInfo.Name = "PnlInfo"
        Me.PnlInfo.Size = New System.Drawing.Size(513, 200)
        Me.PnlInfo.TabIndex = 0
        '
        'LblTitleBRight
        '
        Me.LblTitleBRight.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBRight.BDrawBorderBottom = True
        Me.LblTitleBRight.BDrawBorderLeft = False
        Me.LblTitleBRight.BDrawBorderRight = True
        Me.LblTitleBRight.BDrawBorderTop = False
        Me.LblTitleBRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBRight.ForeColor = System.Drawing.Color.White
        Me.LblTitleBRight.Location = New System.Drawing.Point(0, 150)
        Me.LblTitleBRight.Name = "LblTitleBRight"
        Me.LblTitleBRight.OColor = System.Drawing.Color.Black
        Me.LblTitleBRight.Size = New System.Drawing.Size(150, 50)
        Me.LblTitleBRight.TabIndex = 3
        Me.LblTitleBRight.Text = "#2 Right"
        Me.LblTitleBRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnSelectBRight
        '
        Me.BtnSelectBRight.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSelectBRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSelectBRight.ForeColor = System.Drawing.Color.White
        Me.BtnSelectBRight.Location = New System.Drawing.Point(356, 153)
        Me.BtnSelectBRight.Name = "BtnSelectBRight"
        Me.BtnSelectBRight.Size = New System.Drawing.Size(150, 45)
        Me.BtnSelectBRight.TabIndex = 3
        Me.BtnSelectBRight.Tag = "B_RIGHT"
        Me.BtnSelectBRight.Text = "Select"
        Me.BtnSelectBRight.UseVisualStyleBackColor = False
        '
        'BtnSelectARight
        '
        Me.BtnSelectARight.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSelectARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSelectARight.ForeColor = System.Drawing.Color.White
        Me.BtnSelectARight.Location = New System.Drawing.Point(356, 53)
        Me.BtnSelectARight.Name = "BtnSelectARight"
        Me.BtnSelectARight.Size = New System.Drawing.Size(150, 45)
        Me.BtnSelectARight.TabIndex = 1
        Me.BtnSelectARight.Tag = "A_RIGHT"
        Me.BtnSelectARight.Text = "Select"
        Me.BtnSelectARight.UseVisualStyleBackColor = False
        '
        'BtnSelectBLeft
        '
        Me.BtnSelectBLeft.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSelectBLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSelectBLeft.ForeColor = System.Drawing.Color.White
        Me.BtnSelectBLeft.Location = New System.Drawing.Point(356, 103)
        Me.BtnSelectBLeft.Name = "BtnSelectBLeft"
        Me.BtnSelectBLeft.Size = New System.Drawing.Size(150, 45)
        Me.BtnSelectBLeft.TabIndex = 2
        Me.BtnSelectBLeft.Tag = "B_LEFT"
        Me.BtnSelectBLeft.Text = "Select"
        Me.BtnSelectBLeft.UseVisualStyleBackColor = False
        '
        'BtnSelectALeft
        '
        Me.BtnSelectALeft.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSelectALeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSelectALeft.ForeColor = System.Drawing.Color.White
        Me.BtnSelectALeft.Location = New System.Drawing.Point(356, 3)
        Me.BtnSelectALeft.Name = "BtnSelectALeft"
        Me.BtnSelectALeft.Size = New System.Drawing.Size(150, 45)
        Me.BtnSelectALeft.TabIndex = 0
        Me.BtnSelectALeft.Tag = "A_LEFT"
        Me.BtnSelectALeft.Text = "Select"
        Me.BtnSelectALeft.UseVisualStyleBackColor = False
        '
        'LblTitleBLeft
        '
        Me.LblTitleBLeft.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleBLeft.BDrawBorderBottom = True
        Me.LblTitleBLeft.BDrawBorderLeft = False
        Me.LblTitleBLeft.BDrawBorderRight = True
        Me.LblTitleBLeft.BDrawBorderTop = False
        Me.LblTitleBLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleBLeft.ForeColor = System.Drawing.Color.White
        Me.LblTitleBLeft.Location = New System.Drawing.Point(0, 100)
        Me.LblTitleBLeft.Name = "LblTitleBLeft"
        Me.LblTitleBLeft.OColor = System.Drawing.Color.Black
        Me.LblTitleBLeft.Size = New System.Drawing.Size(150, 50)
        Me.LblTitleBLeft.TabIndex = 3
        Me.LblTitleBLeft.Text = "#2 Left"
        Me.LblTitleBLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleARight
        '
        Me.LblTitleARight.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleARight.BDrawBorderBottom = True
        Me.LblTitleARight.BDrawBorderLeft = False
        Me.LblTitleARight.BDrawBorderRight = True
        Me.LblTitleARight.BDrawBorderTop = False
        Me.LblTitleARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleARight.ForeColor = System.Drawing.Color.White
        Me.LblTitleARight.Location = New System.Drawing.Point(0, 50)
        Me.LblTitleARight.Name = "LblTitleARight"
        Me.LblTitleARight.OColor = System.Drawing.Color.Black
        Me.LblTitleARight.Size = New System.Drawing.Size(150, 50)
        Me.LblTitleARight.TabIndex = 3
        Me.LblTitleARight.Text = "#1 Right"
        Me.LblTitleARight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBRight
        '
        Me.LblBRight.BackColor = System.Drawing.Color.White
        Me.LblBRight.BDrawBorderBottom = True
        Me.LblBRight.BDrawBorderLeft = False
        Me.LblBRight.BDrawBorderRight = True
        Me.LblBRight.BDrawBorderTop = False
        Me.LblBRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblBRight.ForeColor = System.Drawing.Color.Black
        Me.LblBRight.Location = New System.Drawing.Point(150, 150)
        Me.LblBRight.Name = "LblBRight"
        Me.LblBRight.OColor = System.Drawing.Color.Black
        Me.LblBRight.Size = New System.Drawing.Size(200, 50)
        Me.LblBRight.TabIndex = 3
        Me.LblBRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBLeft
        '
        Me.LblBLeft.BackColor = System.Drawing.Color.White
        Me.LblBLeft.BDrawBorderBottom = True
        Me.LblBLeft.BDrawBorderLeft = False
        Me.LblBLeft.BDrawBorderRight = True
        Me.LblBLeft.BDrawBorderTop = False
        Me.LblBLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblBLeft.ForeColor = System.Drawing.Color.Black
        Me.LblBLeft.Location = New System.Drawing.Point(150, 100)
        Me.LblBLeft.Name = "LblBLeft"
        Me.LblBLeft.OColor = System.Drawing.Color.Black
        Me.LblBLeft.Size = New System.Drawing.Size(200, 50)
        Me.LblBLeft.TabIndex = 3
        Me.LblBLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblARight
        '
        Me.LblARight.BackColor = System.Drawing.Color.White
        Me.LblARight.BDrawBorderBottom = True
        Me.LblARight.BDrawBorderLeft = False
        Me.LblARight.BDrawBorderRight = True
        Me.LblARight.BDrawBorderTop = False
        Me.LblARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblARight.ForeColor = System.Drawing.Color.Black
        Me.LblARight.Location = New System.Drawing.Point(150, 50)
        Me.LblARight.Name = "LblARight"
        Me.LblARight.OColor = System.Drawing.Color.Black
        Me.LblARight.Size = New System.Drawing.Size(200, 50)
        Me.LblARight.TabIndex = 3
        Me.LblARight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblALeft
        '
        Me.LblALeft.BackColor = System.Drawing.Color.White
        Me.LblALeft.BDrawBorderBottom = True
        Me.LblALeft.BDrawBorderLeft = False
        Me.LblALeft.BDrawBorderRight = True
        Me.LblALeft.BDrawBorderTop = False
        Me.LblALeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblALeft.ForeColor = System.Drawing.Color.Black
        Me.LblALeft.Location = New System.Drawing.Point(150, 0)
        Me.LblALeft.Name = "LblALeft"
        Me.LblALeft.OColor = System.Drawing.Color.Black
        Me.LblALeft.Size = New System.Drawing.Size(200, 50)
        Me.LblALeft.TabIndex = 3
        Me.LblALeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitleALeft
        '
        Me.LblTitleALeft.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleALeft.BDrawBorderBottom = True
        Me.LblTitleALeft.BDrawBorderLeft = False
        Me.LblTitleALeft.BDrawBorderRight = True
        Me.LblTitleALeft.BDrawBorderTop = False
        Me.LblTitleALeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleALeft.ForeColor = System.Drawing.Color.White
        Me.LblTitleALeft.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleALeft.Name = "LblTitleALeft"
        Me.LblTitleALeft.OColor = System.Drawing.Color.Black
        Me.LblTitleALeft.Size = New System.Drawing.Size(150, 50)
        Me.LblTitleALeft.TabIndex = 3
        Me.LblTitleALeft.Text = "#1 Left"
        Me.LblTitleALeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCameraSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 572)
        Me.Controls.Add(Me.PnlData)
        Me.Controls.Add(Me.PnlButton)
        Me.Controls.Add(Me.PnlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCameraSelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Camera"
        CType(Me.DgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlButton.ResumeLayout(False)
        Me.PnlData.ResumeLayout(False)
        Me.PnlList.ResumeLayout(False)
        Me.PnlInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DgvList As System.Windows.Forms.DataGridView
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents PnlButton As Jhjo.Component.CPanel
    Friend WithEvents BtnApply As System.Windows.Forms.Button
    Friend WithEvents PnlData As Jhjo.Component.CPanel
    Friend WithEvents PnlList As Jhjo.Component.CPanel
    Friend WithEvents PnlInfo As Jhjo.Component.CPanel
    Friend WithEvents LblTitleBRight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBLeft As Jhjo.Component.CLabel
    Friend WithEvents LblTitleARight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleALeft As Jhjo.Component.CLabel
    Friend WithEvents LblBRight As Jhjo.Component.CLabel
    Friend WithEvents LblBLeft As Jhjo.Component.CLabel
    Friend WithEvents LblARight As Jhjo.Component.CLabel
    Friend WithEvents LblALeft As Jhjo.Component.CLabel
    Friend WithEvents BtnSelectBRight As System.Windows.Forms.Button
    Friend WithEvents BtnSelectARight As System.Windows.Forms.Button
    Friend WithEvents BtnSelectBLeft As System.Windows.Forms.Button
    Friend WithEvents BtnSelectALeft As System.Windows.Forms.Button
    Friend WithEvents ColModel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSerial As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
