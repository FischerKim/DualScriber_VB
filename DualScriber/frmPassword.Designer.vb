<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassword
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
        Me.PnlTitle = New Jhjo.Component.CPanel()
        Me.TxtBoxPassword = New System.Windows.Forms.TextBox()
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnEnter = New System.Windows.Forms.Button()
        Me.PnlTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlTitle
        '
        Me.PnlTitle.BDrawBorderBottom = False
        Me.PnlTitle.BDrawBorderLeft = False
        Me.PnlTitle.BDrawBorderRight = False
        Me.PnlTitle.BDrawBorderTop = False
        Me.PnlTitle.Controls.Add(Me.TxtBoxPassword)
        Me.PnlTitle.Controls.Add(Me.LblTitle)
        Me.PnlTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitle.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitle.Name = "PnlTitle"
        Me.PnlTitle.Size = New System.Drawing.Size(313, 40)
        Me.PnlTitle.TabIndex = 0
        '
        'TxtBoxPassword
        '
        Me.TxtBoxPassword.Font = New System.Drawing.Font("굴림", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TxtBoxPassword.Location = New System.Drawing.Point(154, 0)
        Me.TxtBoxPassword.Name = "TxtBoxPassword"
        Me.TxtBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtBoxPassword.Size = New System.Drawing.Size(155, 35)
        Me.TxtBoxPassword.TabIndex = 1
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.DarkTurquoise
        Me.LblTitle.BDrawBorderBottom = True
        Me.LblTitle.BDrawBorderLeft = False
        Me.LblTitle.BDrawBorderRight = False
        Me.LblTitle.BDrawBorderTop = False
        Me.LblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitle.ForeColor = System.Drawing.Color.White
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.OColor = System.Drawing.Color.Black
        Me.LblTitle.Size = New System.Drawing.Size(154, 40)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Password"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.ForeColor = System.Drawing.Color.White
        Me.BtnExit.Location = New System.Drawing.Point(159, 40)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(154, 46)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnEnter
        '
        Me.BtnEnter.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEnter.ForeColor = System.Drawing.Color.White
        Me.BtnEnter.Location = New System.Drawing.Point(0, 40)
        Me.BtnEnter.Name = "BtnEnter"
        Me.BtnEnter.Size = New System.Drawing.Size(154, 46)
        Me.BtnEnter.TabIndex = 1
        Me.BtnEnter.Text = "&Enter"
        Me.BtnEnter.UseVisualStyleBackColor = False
        '
        'frmPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(313, 88)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.PnlTitle)
        Me.Controls.Add(Me.BtnEnter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Password"
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents BtnEnter As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents TxtBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
End Class
