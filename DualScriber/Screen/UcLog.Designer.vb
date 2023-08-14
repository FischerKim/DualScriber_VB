<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UcLog
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
        Me.PnlTitle = New Jhjo.Component.CPanel()
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.PnlCurrent = New Jhjo.Component.CPanel()
        Me.LtbCurrent = New System.Windows.Forms.ListBox()
        Me.LblTitleCurrent = New Jhjo.Component.CLabel()
        Me.PnlReview = New Jhjo.Component.CPanel()
        Me.LtbReview = New System.Windows.Forms.ListBox()
        Me.PnlSearch = New Jhjo.Component.CPanel()
        Me.DtpDate = New System.Windows.Forms.DateTimePicker()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.LblTitleReview = New Jhjo.Component.CLabel()
        Me.PnlTitle.SuspendLayout()
        Me.PnlCurrent.SuspendLayout()
        Me.PnlReview.SuspendLayout()
        Me.PnlSearch.SuspendLayout()
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
        Me.LblTitle.Text = "Log"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCurrent
        '
        Me.PnlCurrent.BDrawBorderBottom = False
        Me.PnlCurrent.BDrawBorderLeft = False
        Me.PnlCurrent.BDrawBorderRight = False
        Me.PnlCurrent.BDrawBorderTop = False
        Me.PnlCurrent.Controls.Add(Me.LtbCurrent)
        Me.PnlCurrent.Controls.Add(Me.LblTitleCurrent)
        Me.PnlCurrent.Dock = System.Windows.Forms.DockStyle.Left
        Me.PnlCurrent.Location = New System.Drawing.Point(0, 40)
        Me.PnlCurrent.Name = "PnlCurrent"
        Me.PnlCurrent.Size = New System.Drawing.Size(640, 889)
        Me.PnlCurrent.TabIndex = 6
        '
        'LtbCurrent
        '
        Me.LtbCurrent.BackColor = System.Drawing.Color.Black
        Me.LtbCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LtbCurrent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LtbCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LtbCurrent.ForeColor = System.Drawing.Color.White
        Me.LtbCurrent.FormattingEnabled = True
        Me.LtbCurrent.IntegralHeight = False
        Me.LtbCurrent.ItemHeight = 25
        Me.LtbCurrent.Location = New System.Drawing.Point(0, 40)
        Me.LtbCurrent.Name = "LtbCurrent"
        Me.LtbCurrent.Size = New System.Drawing.Size(640, 849)
        Me.LtbCurrent.TabIndex = 4
        '
        'LblTitleCurrent
        '
        Me.LblTitleCurrent.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCurrent.BDrawBorderBottom = True
        Me.LblTitleCurrent.BDrawBorderLeft = True
        Me.LblTitleCurrent.BDrawBorderRight = False
        Me.LblTitleCurrent.BDrawBorderTop = False
        Me.LblTitleCurrent.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCurrent.ForeColor = System.Drawing.Color.White
        Me.LblTitleCurrent.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleCurrent.Name = "LblTitleCurrent"
        Me.LblTitleCurrent.OColor = System.Drawing.Color.Black
        Me.LblTitleCurrent.Size = New System.Drawing.Size(640, 40)
        Me.LblTitleCurrent.TabIndex = 3
        Me.LblTitleCurrent.Text = "Current Log"
        Me.LblTitleCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlReview
        '
        Me.PnlReview.BDrawBorderBottom = False
        Me.PnlReview.BDrawBorderLeft = True
        Me.PnlReview.BDrawBorderRight = False
        Me.PnlReview.BDrawBorderTop = False
        Me.PnlReview.Controls.Add(Me.LtbReview)
        Me.PnlReview.Controls.Add(Me.PnlSearch)
        Me.PnlReview.Controls.Add(Me.LblTitleReview)
        Me.PnlReview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlReview.Location = New System.Drawing.Point(640, 40)
        Me.PnlReview.Name = "PnlReview"
        Me.PnlReview.Size = New System.Drawing.Size(640, 889)
        Me.PnlReview.TabIndex = 6
        '
        'LtbReview
        '
        Me.LtbReview.BackColor = System.Drawing.Color.Black
        Me.LtbReview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LtbReview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LtbReview.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LtbReview.ForeColor = System.Drawing.Color.White
        Me.LtbReview.FormattingEnabled = True
        Me.LtbReview.HorizontalScrollbar = True
        Me.LtbReview.IntegralHeight = False
        Me.LtbReview.ItemHeight = 25
        Me.LtbReview.Location = New System.Drawing.Point(0, 90)
        Me.LtbReview.Name = "LtbReview"
        Me.LtbReview.Size = New System.Drawing.Size(640, 799)
        Me.LtbReview.TabIndex = 7
        '
        'PnlSearch
        '
        Me.PnlSearch.BDrawBorderBottom = True
        Me.PnlSearch.BDrawBorderLeft = True
        Me.PnlSearch.BDrawBorderRight = False
        Me.PnlSearch.BDrawBorderTop = False
        Me.PnlSearch.Controls.Add(Me.DtpDate)
        Me.PnlSearch.Controls.Add(Me.BtnSearch)
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(0, 40)
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(640, 50)
        Me.PnlSearch.TabIndex = 6
        '
        'DtpDate
        '
        Me.DtpDate.CustomFormat = "yyyy-MM-dd"
        Me.DtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpDate.Location = New System.Drawing.Point(6, 9)
        Me.DtpDate.Name = "DtpDate"
        Me.DtpDate.Size = New System.Drawing.Size(475, 30)
        Me.DtpDate.TabIndex = 9
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSearch.ForeColor = System.Drawing.Color.White
        Me.BtnSearch.Location = New System.Drawing.Point(487, 2)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(150, 45)
        Me.BtnSearch.TabIndex = 10
        Me.BtnSearch.Text = "Search"
        Me.BtnSearch.UseVisualStyleBackColor = False
        '
        'LblTitleReview
        '
        Me.LblTitleReview.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleReview.BDrawBorderBottom = True
        Me.LblTitleReview.BDrawBorderLeft = True
        Me.LblTitleReview.BDrawBorderRight = False
        Me.LblTitleReview.BDrawBorderTop = False
        Me.LblTitleReview.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleReview.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleReview.ForeColor = System.Drawing.Color.White
        Me.LblTitleReview.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleReview.Name = "LblTitleReview"
        Me.LblTitleReview.OColor = System.Drawing.Color.Black
        Me.LblTitleReview.Size = New System.Drawing.Size(640, 40)
        Me.LblTitleReview.TabIndex = 4
        Me.LblTitleReview.Text = "Review Log"
        Me.LblTitleReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UcLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PnlReview)
        Me.Controls.Add(Me.PnlCurrent)
        Me.Controls.Add(Me.PnlTitle)
        Me.Name = "UcLog"
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlCurrent.ResumeLayout(False)
        Me.PnlReview.ResumeLayout(False)
        Me.PnlSearch.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents PnlCurrent As Jhjo.Component.CPanel
    Friend WithEvents PnlReview As Jhjo.Component.CPanel
    Friend WithEvents LblTitleCurrent As Jhjo.Component.CLabel
    Friend WithEvents LblTitleReview As Jhjo.Component.CLabel
    Friend WithEvents PnlSearch As Jhjo.Component.CPanel
    Friend WithEvents DtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents LtbCurrent As System.Windows.Forms.ListBox
    Friend WithEvents LtbReview As System.Windows.Forms.ListBox

End Class
