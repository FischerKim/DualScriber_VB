<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.PnlHeader = New Jhjo.Component.CPanel()
        Me.ChkUserMode = New System.Windows.Forms.CheckBox()
        Me.BtnMaximize = New System.Windows.Forms.Button()
        Me.BtnMinimize = New System.Windows.Forms.Button()
        Me.LblTime = New Jhjo.Component.CLabel()
        Me.LblRecipe = New Jhjo.Component.CLabel()
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.PnlFooter = New Jhjo.Component.CPanel()
        Me.BtnResetPassword = New System.Windows.Forms.Button()
        Me.BtnPCI = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnLog = New System.Windows.Forms.Button()
        Me.BtnReport = New System.Windows.Forms.Button()
        Me.BtnRecipe = New System.Windows.Forms.Button()
        Me.BtnSetup = New System.Windows.Forms.Button()
        Me.BtnAlignment = New System.Windows.Forms.Button()
        Me.PnlScreen = New Jhjo.Component.CPanel()
        Me.Timer1000 = New System.Windows.Forms.Timer(Me.components)
        Me.PnlHeader.SuspendLayout()
        Me.PnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BDrawBorderBottom = True
        Me.PnlHeader.BDrawBorderLeft = False
        Me.PnlHeader.BDrawBorderRight = False
        Me.PnlHeader.BDrawBorderTop = False
        Me.PnlHeader.Controls.Add(Me.ChkUserMode)
        Me.PnlHeader.Controls.Add(Me.BtnMaximize)
        Me.PnlHeader.Controls.Add(Me.BtnMinimize)
        Me.PnlHeader.Controls.Add(Me.LblTime)
        Me.PnlHeader.Controls.Add(Me.LblRecipe)
        Me.PnlHeader.Controls.Add(Me.LblTitle)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(1707, 53)
        Me.PnlHeader.TabIndex = 0
        '
        'ChkUserMode
        '
        Me.ChkUserMode.Appearance = System.Windows.Forms.Appearance.Button
        Me.ChkUserMode.BackColor = System.Drawing.Color.RoyalBlue
        Me.ChkUserMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.ChkUserMode.ForeColor = System.Drawing.Color.White
        Me.ChkUserMode.Location = New System.Drawing.Point(1017, 0)
        Me.ChkUserMode.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ChkUserMode.Name = "ChkUserMode"
        Me.ChkUserMode.Size = New System.Drawing.Size(192, 53)
        Me.ChkUserMode.TabIndex = 22
        Me.ChkUserMode.Text = "OP MODE"
        Me.ChkUserMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkUserMode.UseVisualStyleBackColor = False
        '
        'BtnMaximize
        '
        Me.BtnMaximize.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnMaximize.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnMaximize.ForeColor = System.Drawing.Color.White
        Me.BtnMaximize.Location = New System.Drawing.Point(1587, 2)
        Me.BtnMaximize.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnMaximize.Name = "BtnMaximize"
        Me.BtnMaximize.Size = New System.Drawing.Size(57, 46)
        Me.BtnMaximize.TabIndex = 3
        Me.BtnMaximize.Text = "+"
        Me.BtnMaximize.UseVisualStyleBackColor = False
        '
        'BtnMinimize
        '
        Me.BtnMinimize.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnMinimize.ForeColor = System.Drawing.Color.White
        Me.BtnMinimize.Location = New System.Drawing.Point(1645, 2)
        Me.BtnMinimize.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnMinimize.Name = "BtnMinimize"
        Me.BtnMinimize.Size = New System.Drawing.Size(57, 46)
        Me.BtnMinimize.TabIndex = 0
        Me.BtnMinimize.Text = "&_"
        Me.BtnMinimize.UseVisualStyleBackColor = False
        '
        'LblTime
        '
        Me.LblTime.BackColor = System.Drawing.Color.DimGray
        Me.LblTime.BDrawBorderBottom = True
        Me.LblTime.BDrawBorderLeft = False
        Me.LblTime.BDrawBorderRight = True
        Me.LblTime.BDrawBorderTop = False
        Me.LblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTime.ForeColor = System.Drawing.Color.White
        Me.LblTime.Location = New System.Drawing.Point(1208, 0)
        Me.LblTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTime.Name = "LblTime"
        Me.LblTime.OColor = System.Drawing.Color.Black
        Me.LblTime.Size = New System.Drawing.Size(375, 53)
        Me.LblTime.TabIndex = 2
        Me.LblTime.Text = "2015-03-21 13:11:11 123"
        Me.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblRecipe
        '
        Me.LblRecipe.BackColor = System.Drawing.Color.DimGray
        Me.LblRecipe.BDrawBorderBottom = True
        Me.LblRecipe.BDrawBorderLeft = False
        Me.LblRecipe.BDrawBorderRight = True
        Me.LblRecipe.BDrawBorderTop = False
        Me.LblRecipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblRecipe.ForeColor = System.Drawing.Color.White
        Me.LblRecipe.Location = New System.Drawing.Point(381, 0)
        Me.LblRecipe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblRecipe.Name = "LblRecipe"
        Me.LblRecipe.OColor = System.Drawing.Color.Black
        Me.LblRecipe.Size = New System.Drawing.Size(636, 53)
        Me.LblRecipe.TabIndex = 2
        Me.LblRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblTitle
        '
        Me.LblTitle.BackColor = System.Drawing.Color.Silver
        Me.LblTitle.BDrawBorderBottom = True
        Me.LblTitle.BDrawBorderLeft = False
        Me.LblTitle.BDrawBorderRight = True
        Me.LblTitle.BDrawBorderTop = False
        Me.LblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitle.ForeColor = System.Drawing.Color.Red
        Me.LblTitle.Location = New System.Drawing.Point(0, 0)
        Me.LblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.OColor = System.Drawing.Color.Black
        Me.LblTitle.Size = New System.Drawing.Size(381, 53)
        Me.LblTitle.TabIndex = 1
        Me.LblTitle.Text = "CEC 8.6G EDGE SCRIBER"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlFooter
        '
        Me.PnlFooter.BDrawBorderBottom = False
        Me.PnlFooter.BDrawBorderLeft = False
        Me.PnlFooter.BDrawBorderRight = False
        Me.PnlFooter.BDrawBorderTop = True
        Me.PnlFooter.Controls.Add(Me.BtnResetPassword)
        Me.PnlFooter.Controls.Add(Me.BtnPCI)
        Me.PnlFooter.Controls.Add(Me.BtnExit)
        Me.PnlFooter.Controls.Add(Me.BtnLog)
        Me.PnlFooter.Controls.Add(Me.BtnReport)
        Me.PnlFooter.Controls.Add(Me.BtnRecipe)
        Me.PnlFooter.Controls.Add(Me.BtnSetup)
        Me.PnlFooter.Controls.Add(Me.BtnAlignment)
        Me.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlFooter.Location = New System.Drawing.Point(0, 1044)
        Me.PnlFooter.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(1707, 58)
        Me.PnlFooter.TabIndex = 1
        '
        'BtnResetPassword
        '
        Me.BtnResetPassword.BackColor = System.Drawing.Color.BlueViolet
        Me.BtnResetPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold)
        Me.BtnResetPassword.ForeColor = System.Drawing.Color.White
        Me.BtnResetPassword.Location = New System.Drawing.Point(1251, 2)
        Me.BtnResetPassword.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnResetPassword.Name = "BtnResetPassword"
        Me.BtnResetPassword.Size = New System.Drawing.Size(245, 53)
        Me.BtnResetPassword.TabIndex = 9
        Me.BtnResetPassword.Tag = "LOG"
        Me.BtnResetPassword.Text = "Change Password"
        Me.BtnResetPassword.UseVisualStyleBackColor = False
        Me.BtnResetPassword.Visible = False
        '
        'BtnPCI
        '
        Me.BtnPCI.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnPCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnPCI.ForeColor = System.Drawing.Color.White
        Me.BtnPCI.Location = New System.Drawing.Point(628, 2)
        Me.BtnPCI.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnPCI.Name = "BtnPCI"
        Me.BtnPCI.Size = New System.Drawing.Size(200, 53)
        Me.BtnPCI.TabIndex = 2
        Me.BtnPCI.Tag = "PCI"
        Me.BtnPCI.Text = "&PCI"
        Me.BtnPCI.UseVisualStyleBackColor = False
        Me.BtnPCI.Visible = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExit.ForeColor = System.Drawing.Color.White
        Me.BtnExit.Location = New System.Drawing.Point(1503, 2)
        Me.BtnExit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(200, 53)
        Me.BtnExit.TabIndex = 7
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnLog
        '
        Me.BtnLog.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnLog.ForeColor = System.Drawing.Color.White
        Me.BtnLog.Location = New System.Drawing.Point(1044, 2)
        Me.BtnLog.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnLog.Name = "BtnLog"
        Me.BtnLog.Size = New System.Drawing.Size(200, 53)
        Me.BtnLog.TabIndex = 6
        Me.BtnLog.Tag = "LOG"
        Me.BtnLog.Text = "&Log"
        Me.BtnLog.UseVisualStyleBackColor = False
        '
        'BtnReport
        '
        Me.BtnReport.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnReport.ForeColor = System.Drawing.Color.White
        Me.BtnReport.Location = New System.Drawing.Point(836, 2)
        Me.BtnReport.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnReport.Name = "BtnReport"
        Me.BtnReport.Size = New System.Drawing.Size(200, 53)
        Me.BtnReport.TabIndex = 5
        Me.BtnReport.Tag = "REPORT"
        Me.BtnReport.Text = "Re&port"
        Me.BtnReport.UseVisualStyleBackColor = False
        '
        'BtnRecipe
        '
        Me.BtnRecipe.BackColor = System.Drawing.SystemColors.Control
        Me.BtnRecipe.Enabled = False
        Me.BtnRecipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnRecipe.ForeColor = System.Drawing.Color.White
        Me.BtnRecipe.Location = New System.Drawing.Point(420, 2)
        Me.BtnRecipe.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnRecipe.Name = "BtnRecipe"
        Me.BtnRecipe.Size = New System.Drawing.Size(200, 53)
        Me.BtnRecipe.TabIndex = 4
        Me.BtnRecipe.Tag = "RECIPE"
        Me.BtnRecipe.Text = "&Recipe"
        Me.BtnRecipe.UseVisualStyleBackColor = False
        '
        'BtnSetup
        '
        Me.BtnSetup.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSetup.ForeColor = System.Drawing.Color.White
        Me.BtnSetup.Location = New System.Drawing.Point(212, 2)
        Me.BtnSetup.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnSetup.Name = "BtnSetup"
        Me.BtnSetup.Size = New System.Drawing.Size(200, 53)
        Me.BtnSetup.TabIndex = 3
        Me.BtnSetup.Tag = "SETUP"
        Me.BtnSetup.Text = "&Setup"
        Me.BtnSetup.UseVisualStyleBackColor = False
        '
        'BtnAlignment
        '
        Me.BtnAlignment.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnAlignment.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnAlignment.ForeColor = System.Drawing.Color.White
        Me.BtnAlignment.Location = New System.Drawing.Point(4, 2)
        Me.BtnAlignment.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.BtnAlignment.Name = "BtnAlignment"
        Me.BtnAlignment.Size = New System.Drawing.Size(200, 53)
        Me.BtnAlignment.TabIndex = 1
        Me.BtnAlignment.Tag = "ALIGNMENT"
        Me.BtnAlignment.Text = "&Home"
        Me.BtnAlignment.UseVisualStyleBackColor = False
        '
        'PnlScreen
        '
        Me.PnlScreen.BDrawBorderBottom = False
        Me.PnlScreen.BDrawBorderLeft = False
        Me.PnlScreen.BDrawBorderRight = False
        Me.PnlScreen.BDrawBorderTop = False
        Me.PnlScreen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlScreen.Location = New System.Drawing.Point(0, 53)
        Me.PnlScreen.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PnlScreen.Name = "PnlScreen"
        Me.PnlScreen.Size = New System.Drawing.Size(1707, 991)
        Me.PnlScreen.TabIndex = 2
        '
        'Timer1000
        '
        Me.Timer1000.Enabled = True
        Me.Timer1000.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1707, 1102)
        Me.ControlBox = False
        Me.Controls.Add(Me.PnlScreen)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.PnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Daekhon Coporation - Dual Scriber"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlHeader As Jhjo.Component.CPanel
    Friend WithEvents PnlFooter As Jhjo.Component.CPanel
    Friend WithEvents PnlScreen As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents LblTime As Jhjo.Component.CLabel
    Friend WithEvents LblRecipe As Jhjo.Component.CLabel
    Friend WithEvents BtnMinimize As System.Windows.Forms.Button
    Friend WithEvents BtnAlignment As System.Windows.Forms.Button
    Friend WithEvents BtnRecipe As System.Windows.Forms.Button
    Friend WithEvents BtnSetup As System.Windows.Forms.Button
    Friend WithEvents BtnPCI As System.Windows.Forms.Button
    Friend WithEvents BtnReport As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnLog As System.Windows.Forms.Button
    Friend WithEvents Timer1000 As System.Windows.Forms.Timer
    Friend WithEvents BtnMaximize As System.Windows.Forms.Button
    Friend WithEvents ChkUserMode As System.Windows.Forms.CheckBox
    Friend WithEvents BtnResetPassword As System.Windows.Forms.Button
End Class
