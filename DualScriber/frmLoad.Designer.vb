<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoad
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
        Me.LblTitle = New Jhjo.Component.CLabel()
        Me.PnlButton = New Jhjo.Component.CPanel()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnEnter = New System.Windows.Forms.Button()
        Me.PnlCamera = New Jhjo.Component.CPanel()
        Me.LblTitleBRight = New Jhjo.Component.CLabel()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.LblTitleBLeft = New Jhjo.Component.CLabel()
        Me.LblTitleARight = New Jhjo.Component.CLabel()
        Me.LblBRight = New Jhjo.Component.CLabel()
        Me.LblBLeft = New Jhjo.Component.CLabel()
        Me.LblARight = New Jhjo.Component.CLabel()
        Me.LblALeft = New Jhjo.Component.CLabel()
        Me.LblTitleALeft = New Jhjo.Component.CLabel()
        Me.LblTitleCameraInfo = New Jhjo.Component.CLabel()
        Me.PnlTitle.SuspendLayout()
        Me.PnlButton.SuspendLayout()
        Me.PnlCamera.SuspendLayout()
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
        Me.PnlTitle.Size = New System.Drawing.Size(401, 37)
        Me.PnlTitle.TabIndex = 0
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
        Me.LblTitle.Size = New System.Drawing.Size(401, 37)
        Me.LblTitle.TabIndex = 0
        Me.LblTitle.Text = "Dual Scriber"
        Me.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlButton
        '
        Me.PnlButton.BDrawBorderBottom = False
        Me.PnlButton.BDrawBorderLeft = False
        Me.PnlButton.BDrawBorderRight = False
        Me.PnlButton.BDrawBorderTop = False
        Me.PnlButton.Controls.Add(Me.BtnExit)
        Me.PnlButton.Controls.Add(Me.BtnEnter)
        Me.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlButton.Location = New System.Drawing.Point(0, 268)
        Me.PnlButton.Name = "PnlButton"
        Me.PnlButton.Size = New System.Drawing.Size(401, 46)
        Me.PnlButton.TabIndex = 1
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExit.ForeColor = System.Drawing.Color.White
        Me.BtnExit.Location = New System.Drawing.Point(223, 2)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(175, 42)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnEnter
        '
        Me.BtnEnter.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnEnter.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnEnter.ForeColor = System.Drawing.Color.White
        Me.BtnEnter.Location = New System.Drawing.Point(41, 2)
        Me.BtnEnter.Name = "BtnEnter"
        Me.BtnEnter.Size = New System.Drawing.Size(175, 42)
        Me.BtnEnter.TabIndex = 1
        Me.BtnEnter.Text = "&Enter"
        Me.BtnEnter.UseVisualStyleBackColor = False
        '
        'PnlCamera
        '
        Me.PnlCamera.BDrawBorderBottom = True
        Me.PnlCamera.BDrawBorderLeft = False
        Me.PnlCamera.BDrawBorderRight = False
        Me.PnlCamera.BDrawBorderTop = False
        Me.PnlCamera.Controls.Add(Me.LblTitleBRight)
        Me.PnlCamera.Controls.Add(Me.BtnSelect)
        Me.PnlCamera.Controls.Add(Me.LblTitleBLeft)
        Me.PnlCamera.Controls.Add(Me.LblTitleARight)
        Me.PnlCamera.Controls.Add(Me.LblBRight)
        Me.PnlCamera.Controls.Add(Me.LblBLeft)
        Me.PnlCamera.Controls.Add(Me.LblARight)
        Me.PnlCamera.Controls.Add(Me.LblALeft)
        Me.PnlCamera.Controls.Add(Me.LblTitleALeft)
        Me.PnlCamera.Controls.Add(Me.LblTitleCameraInfo)
        Me.PnlCamera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlCamera.Location = New System.Drawing.Point(0, 37)
        Me.PnlCamera.Name = "PnlCamera"
        Me.PnlCamera.Size = New System.Drawing.Size(401, 231)
        Me.PnlCamera.TabIndex = 2
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
        Me.LblTitleBRight.Location = New System.Drawing.Point(0, 148)
        Me.LblTitleBRight.Name = "LblTitleBRight"
        Me.LblTitleBRight.OColor = System.Drawing.Color.Black
        Me.LblTitleBRight.Size = New System.Drawing.Size(175, 37)
        Me.LblTitleBRight.TabIndex = 2
        Me.LblTitleBRight.Text = "St. #2 Right Cam"
        Me.LblTitleBRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSelect.ForeColor = System.Drawing.Color.White
        Me.BtnSelect.Location = New System.Drawing.Point(223, 187)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(175, 42)
        Me.BtnSelect.TabIndex = 0
        Me.BtnSelect.Text = "&Select"
        Me.BtnSelect.UseVisualStyleBackColor = False
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
        Me.LblTitleBLeft.Location = New System.Drawing.Point(0, 111)
        Me.LblTitleBLeft.Name = "LblTitleBLeft"
        Me.LblTitleBLeft.OColor = System.Drawing.Color.Black
        Me.LblTitleBLeft.Size = New System.Drawing.Size(175, 37)
        Me.LblTitleBLeft.TabIndex = 2
        Me.LblTitleBLeft.Text = "St. #2 Left Cam"
        Me.LblTitleBLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.LblTitleARight.Location = New System.Drawing.Point(0, 74)
        Me.LblTitleARight.Name = "LblTitleARight"
        Me.LblTitleARight.OColor = System.Drawing.Color.Black
        Me.LblTitleARight.Size = New System.Drawing.Size(175, 37)
        Me.LblTitleARight.TabIndex = 2
        Me.LblTitleARight.Text = "St. #1 Right Cam"
        Me.LblTitleARight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblBRight
        '
        Me.LblBRight.BackColor = System.Drawing.Color.White
        Me.LblBRight.BDrawBorderBottom = True
        Me.LblBRight.BDrawBorderLeft = False
        Me.LblBRight.BDrawBorderRight = False
        Me.LblBRight.BDrawBorderTop = False
        Me.LblBRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblBRight.ForeColor = System.Drawing.Color.Black
        Me.LblBRight.Location = New System.Drawing.Point(175, 148)
        Me.LblBRight.Name = "LblBRight"
        Me.LblBRight.OColor = System.Drawing.Color.Black
        Me.LblBRight.Size = New System.Drawing.Size(226, 37)
        Me.LblBRight.TabIndex = 2
        Me.LblBRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblBLeft
        '
        Me.LblBLeft.BackColor = System.Drawing.Color.White
        Me.LblBLeft.BDrawBorderBottom = True
        Me.LblBLeft.BDrawBorderLeft = False
        Me.LblBLeft.BDrawBorderRight = False
        Me.LblBLeft.BDrawBorderTop = False
        Me.LblBLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblBLeft.ForeColor = System.Drawing.Color.Black
        Me.LblBLeft.Location = New System.Drawing.Point(175, 111)
        Me.LblBLeft.Name = "LblBLeft"
        Me.LblBLeft.OColor = System.Drawing.Color.Black
        Me.LblBLeft.Size = New System.Drawing.Size(226, 37)
        Me.LblBLeft.TabIndex = 2
        Me.LblBLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblARight
        '
        Me.LblARight.BackColor = System.Drawing.Color.White
        Me.LblARight.BDrawBorderBottom = True
        Me.LblARight.BDrawBorderLeft = False
        Me.LblARight.BDrawBorderRight = False
        Me.LblARight.BDrawBorderTop = False
        Me.LblARight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblARight.ForeColor = System.Drawing.Color.Black
        Me.LblARight.Location = New System.Drawing.Point(175, 74)
        Me.LblARight.Name = "LblARight"
        Me.LblARight.OColor = System.Drawing.Color.Black
        Me.LblARight.Size = New System.Drawing.Size(226, 37)
        Me.LblARight.TabIndex = 2
        Me.LblARight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblALeft
        '
        Me.LblALeft.BackColor = System.Drawing.Color.White
        Me.LblALeft.BDrawBorderBottom = True
        Me.LblALeft.BDrawBorderLeft = False
        Me.LblALeft.BDrawBorderRight = False
        Me.LblALeft.BDrawBorderTop = False
        Me.LblALeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.LblALeft.ForeColor = System.Drawing.Color.Black
        Me.LblALeft.Location = New System.Drawing.Point(175, 37)
        Me.LblALeft.Name = "LblALeft"
        Me.LblALeft.OColor = System.Drawing.Color.Black
        Me.LblALeft.Size = New System.Drawing.Size(226, 37)
        Me.LblALeft.TabIndex = 2
        Me.LblALeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.LblTitleALeft.Location = New System.Drawing.Point(0, 37)
        Me.LblTitleALeft.Name = "LblTitleALeft"
        Me.LblTitleALeft.OColor = System.Drawing.Color.Black
        Me.LblTitleALeft.Size = New System.Drawing.Size(175, 37)
        Me.LblTitleALeft.TabIndex = 2
        Me.LblTitleALeft.Text = "St. #1 Left Cam"
        Me.LblTitleALeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTitleCameraInfo
        '
        Me.LblTitleCameraInfo.BackColor = System.Drawing.Color.DimGray
        Me.LblTitleCameraInfo.BDrawBorderBottom = True
        Me.LblTitleCameraInfo.BDrawBorderLeft = False
        Me.LblTitleCameraInfo.BDrawBorderRight = False
        Me.LblTitleCameraInfo.BDrawBorderTop = False
        Me.LblTitleCameraInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitleCameraInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitleCameraInfo.ForeColor = System.Drawing.Color.White
        Me.LblTitleCameraInfo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitleCameraInfo.Name = "LblTitleCameraInfo"
        Me.LblTitleCameraInfo.OColor = System.Drawing.Color.Black
        Me.LblTitleCameraInfo.Size = New System.Drawing.Size(401, 37)
        Me.LblTitleCameraInfo.TabIndex = 1
        Me.LblTitleCameraInfo.Text = "Camera Info"
        Me.LblTitleCameraInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmLoad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 314)
        Me.Controls.Add(Me.PnlCamera)
        Me.Controls.Add(Me.PnlButton)
        Me.Controls.Add(Me.PnlTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load"
        Me.PnlTitle.ResumeLayout(False)
        Me.PnlButton.ResumeLayout(False)
        Me.PnlCamera.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlTitle As Jhjo.Component.CPanel
    Friend WithEvents PnlButton As Jhjo.Component.CPanel
    Friend WithEvents PnlCamera As Jhjo.Component.CPanel
    Friend WithEvents LblTitle As Jhjo.Component.CLabel
    Friend WithEvents BtnEnter As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents LblTitleALeft As Jhjo.Component.CLabel
    Friend WithEvents LblTitleCameraInfo As Jhjo.Component.CLabel
    Friend WithEvents LblTitleARight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBRight As Jhjo.Component.CLabel
    Friend WithEvents LblTitleBLeft As Jhjo.Component.CLabel
    Friend WithEvents LblBRight As Jhjo.Component.CLabel
    Friend WithEvents LblBLeft As Jhjo.Component.CLabel
    Friend WithEvents LblARight As Jhjo.Component.CLabel
    Friend WithEvents LblALeft As Jhjo.Component.CLabel
    Friend WithEvents BtnSelect As System.Windows.Forms.Button
End Class
