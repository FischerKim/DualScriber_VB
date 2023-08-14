Imports Cognex.VisionPro
Imports Jhjo.Common
Imports System.IO
Imports System.Threading


Public Class UcSetup
    Inherits UcScreen

#Region "VARIABLE"
    Private m_OLineALeftX As CogLine = Nothing
    Private m_OLineALeftY As CogLine = Nothing
    Private m_OLineARightX As CogLine = Nothing
    Private m_OLineARightY As CogLine = Nothing
    Private m_OLineBLeftX As CogLine = Nothing
    Private m_OLineBLeftY As CogLine = Nothing
    Private m_OLineBRightX As CogLine = Nothing
    Private m_OLineBRightY As CogLine = Nothing

    Private m_StrALeftROIKind As String = String.Empty
    Private m_F64ALeftROIRealWidth As Double = 0
    Private m_F64ALeftROIRealHeight As Double = 0
    Private m_OROIALeft As CogRectangle = Nothing

    Private m_StrARightROIKind As String = String.Empty
    Private m_F64ARightROIRealWidth As Double = 0
    Private m_F64ARightROIRealHeight As Double = 0
    Private m_OROIARight As CogRectangle = Nothing

    Private m_StrBLeftROIKind As String = String.Empty
    Private m_F64BLeftROIRealWidth As Double = 0
    Private m_F64BLeftROIRealHeight As Double = 0
    Private m_OROIBLeft As CogRectangle = Nothing

    Private m_StrBRightROIKind As String = String.Empty
    Private m_F64BRightROIRealWidth As Double = 0
    Private m_F64BRightROIRealHeight As Double = 0
    Private m_OROIBRight As CogRectangle = Nothing

    Private m_ArrOLineSegment As CogLineSegment() = Nothing
    Private m_ArrOLineX1 As CogLine() = Nothing
    Private m_ArrOLineX2 As CogLine() = Nothing
    Private m_ArrBIsSecond As Boolean() = Nothing
    Private m_ArrOWidth As CogGraphicLabel() = Nothing
    Private m_ArrOHeight As CogGraphicLabel() = Nothing
    Private m_BCaliperAbleAL As Boolean = Nothing
    Private m_BCaliperAbleAR As Boolean = Nothing
    Private m_BCaliperAbleBL As Boolean = Nothing
    Private m_BCaliperAbleBR As Boolean = Nothing

    Private m_BPreventEvent As Boolean = False
    Private m_OALeftInterrupt As Object = Nothing
    Private m_OARightInterrupt As Object = Nothing
    Private m_OBLeftInterrupt As Object = Nothing
    Private m_OBRightInterrupt As Object = Nothing

    ' 검사 중 ROI 표시
    Private m_OROIAlignALeft As CogRectangle = Nothing
    Private m_OROIAlignARight As CogRectangle = Nothing
    Private m_OROIAlignBLeft As CogRectangle = Nothing
    Private m_OROIAlignBRight As CogRectangle = Nothing
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()

        Try
            Me.m_BPreventEvent = True

            Me.m_OLineALeftX = New CogLine()
            Me.m_OLineALeftX.X = CAcquisitionManager.It.OALeft.I32Width / 2D
            Me.m_OLineALeftX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineALeftX.Color = CogColorConstants.Yellow
            Me.m_OLineALeftX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OLineALeftX, "LineX", True)
            Me.m_OLineALeftY = New CogLine()
            Me.m_OLineALeftY.Y = CAcquisitionManager.It.OALeft.I32Height / 2D
            Me.m_OLineALeftY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineALeftY.Color = CogColorConstants.Yellow
            Me.m_OLineALeftY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OLineALeftY, "LineY", True)
            Me.m_OLineARightX = New CogLine()
            Me.m_OLineARightX.X = CAcquisitionManager.It.OARight.I32Width / 2D
            Me.m_OLineARightX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineARightX.Color = CogColorConstants.Yellow
            Me.m_OLineARightX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OLineARightX, "LineX", True)
            Me.m_OLineARightY = New CogLine()
            Me.m_OLineARightY.Y = CAcquisitionManager.It.OARight.I32Height / 2D
            Me.m_OLineARightY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineARightY.Color = CogColorConstants.Yellow
            Me.m_OLineARightY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OLineARightY, "LineY", True)
            Me.m_OLineBLeftX = New CogLine()
            Me.m_OLineBLeftX.X = CAcquisitionManager.It.OBLeft.I32Width / 2D
            Me.m_OLineBLeftX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineBLeftX.Color = CogColorConstants.Yellow
            Me.m_OLineBLeftX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OLineBLeftX, "LineX", True)
            Me.m_OLineBLeftY = New CogLine()
            Me.m_OLineBLeftY.Y = CAcquisitionManager.It.OBLeft.I32Height / 2D
            Me.m_OLineBLeftY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineBLeftY.Color = CogColorConstants.Yellow
            Me.m_OLineBLeftY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OLineBLeftY, "LineY", True)
            Me.m_OLineBRightX = New CogLine()
            Me.m_OLineBRightX.X = CAcquisitionManager.It.OBRight.I32Width / 2D
            Me.m_OLineBRightX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineBRightX.Color = CogColorConstants.Yellow
            Me.m_OLineBRightX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OLineBRightX, "LineX", True)
            Me.m_OLineBRightY = New CogLine()
            Me.m_OLineBRightY.Y = CAcquisitionManager.It.OBRight.I32Height / 2D
            Me.m_OLineBRightY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineBRightY.Color = CogColorConstants.Yellow
            Me.m_OLineBRightY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OLineBRightY, "LineY", True)

            Me.m_OROIALeft = New CogRectangle()
            Me.m_OROIALeft.Color = CogColorConstants.Blue
            Me.m_OROIALeft.Interactive = True
            Me.m_OROIALeft.GraphicDOFEnable = CogRectangleDOFConstants.Position
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OROIALeft, "ROI", True)
            Me.m_OROIARight = New CogRectangle()
            Me.m_OROIARight.Color = CogColorConstants.Blue
            Me.m_OROIARight.Interactive = True
            Me.m_OROIARight.GraphicDOFEnable = CogRectangleDOFConstants.Position
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OROIARight, "ROI", True)
            Me.m_OROIBLeft = New CogRectangle()
            Me.m_OROIBLeft.Color = CogColorConstants.Blue
            Me.m_OROIBLeft.Interactive = True
            Me.m_OROIBLeft.GraphicDOFEnable = CogRectangleDOFConstants.Position
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OROIBLeft, "ROI", True)
            Me.m_OROIBRight = New CogRectangle()
            Me.m_OROIBRight.Color = CogColorConstants.Blue
            Me.m_OROIBRight.Interactive = True
            Me.m_OROIBRight.GraphicDOFEnable = CogRectangleDOFConstants.Position
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OROIBRight, "ROI", True)

            Me.m_ArrOLineSegment = New CogLineSegment(3) {}
            Me.m_ArrOLineX1 = New CogLine(3) {}
            Me.m_ArrOLineX2 = New CogLine(3) {}
            Me.m_ArrBIsSecond = New Boolean(3) {}
            Me.m_ArrOWidth = New CogGraphicLabel(3) {}
            Me.m_ArrOHeight = New CogGraphicLabel(3) {}
            For _Index As Integer = 0 To Me.m_ArrOLineSegment.Length - 1 Step 1
                Me.m_ArrBIsSecond(_Index) = False

                Me.m_ArrOLineSegment(_Index) = New CogLineSegment()
                Me.m_ArrOLineSegment(_Index).StartX = 20
                Me.m_ArrOLineSegment(_Index).StartY = 150
                Me.m_ArrOLineSegment(_Index).EndX = 120
                Me.m_ArrOLineSegment(_Index).EndY = 150
                Me.m_ArrOLineSegment(_Index).Color = CogColorConstants.Magenta
                Me.m_ArrOLineSegment(_Index).SelectedColor = CogColorConstants.Magenta
                Me.m_ArrOLineSegment(_Index).DragColor = CogColorConstants.Magenta
                Me.m_ArrOLineSegment(_Index).Visible = False
                Me.m_ArrOLineSegment(_Index).Interactive = False
                Me.m_ArrOLineSegment(_Index).GraphicDOFEnable = CogLineSegmentDOFConstants.None

                Me.m_ArrOLineX1(_Index) = New CogLine()
                Me.m_ArrOLineX1(_Index).X = 20
                Me.m_ArrOLineX1(_Index).Rotation = CogMisc.DegToRad(90)
                Me.m_ArrOLineX1(_Index).Color = CogColorConstants.Magenta
                Me.m_ArrOLineX1(_Index).SelectedColor = CogColorConstants.Magenta
                Me.m_ArrOLineX1(_Index).DragColor = CogColorConstants.Magenta
                Me.m_ArrOLineX1(_Index).Visible = False
                Me.m_ArrOLineX1(_Index).Interactive = False
                Me.m_ArrOLineX1(_Index).GraphicDOFEnable = CogLineDOFConstants.None

                Me.m_ArrOLineX2(_Index) = New CogLine()
                Me.m_ArrOLineX2(_Index).X = 120
                Me.m_ArrOLineX2(_Index).Rotation = CogMisc.DegToRad(90)
                Me.m_ArrOLineX2(_Index).Color = CogColorConstants.Magenta
                Me.m_ArrOLineX2(_Index).SelectedColor = CogColorConstants.Magenta
                Me.m_ArrOLineX2(_Index).DragColor = CogColorConstants.Magenta
                Me.m_ArrOLineX2(_Index).Visible = False
                Me.m_ArrOLineX2(_Index).Interactive = False
                Me.m_ArrOLineX2(_Index).GraphicDOFEnable = CogLineDOFConstants.None

                Me.m_ArrOWidth(_Index) = New CogGraphicLabel()
                Me.m_ArrOWidth(_Index).Text = "Width : " & (CEnvironment.LEN_PER_PIXEL * 100 * 1000).ToString() & "um(100pix)"
                Me.m_ArrOWidth(_Index).Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft
                Me.m_ArrOWidth(_Index).Color = CogColorConstants.Magenta
                Me.m_ArrOWidth(_Index).X = 20
                Me.m_ArrOWidth(_Index).Y = 900
                Me.m_ArrOWidth(_Index).Visible = False
                Me.m_ArrOWidth(_Index).Interactive = False
                Me.m_ArrOWidth(_Index).GraphicDOFEnable = CogGraphicLabelDOFConstants.None
                Me.m_ArrOWidth(_Index).BackgroundColor = CogColorConstants.White

                Me.m_ArrOHeight(_Index) = New CogGraphicLabel()
                Me.m_ArrOHeight(_Index).Text = "Height : 0um(0pix)"
                Me.m_ArrOHeight(_Index).Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft
                Me.m_ArrOHeight(_Index).Color = CogColorConstants.Magenta
                Me.m_ArrOHeight(_Index).X = 20
                Me.m_ArrOHeight(_Index).Y = 950
                Me.m_ArrOHeight(_Index).Visible = False
                Me.m_ArrOHeight(_Index).Interactive = False
                Me.m_ArrOHeight(_Index).GraphicDOFEnable = CogGraphicLabelDOFConstants.None
                Me.m_ArrOHeight(_Index).BackgroundColor = CogColorConstants.White
            Next
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_ArrOLineSegment(0), "LengthChecker", True)
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_ArrOLineX1(0), "X1", True)
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_ArrOLineX2(0), "X2", True)
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_ArrOWidth(0), "Width", True)
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_ArrOHeight(0), "Height", True)
            Me.CdpARight.InteractiveGraphics.Add(Me.m_ArrOLineSegment(1), "LengthChecker", True)
            Me.CdpARight.InteractiveGraphics.Add(Me.m_ArrOLineX1(1), "X1", True)
            Me.CdpARight.InteractiveGraphics.Add(Me.m_ArrOLineX2(1), "X2", True)
            Me.CdpARight.InteractiveGraphics.Add(Me.m_ArrOWidth(1), "Width", True)
            Me.CdpARight.InteractiveGraphics.Add(Me.m_ArrOHeight(1), "Height", True)
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_ArrOLineSegment(2), "LengthChecker", True)
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_ArrOLineX1(2), "X1", True)
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_ArrOLineX2(2), "X2", True)
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_ArrOWidth(2), "Width", True)
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_ArrOHeight(2), "Height", True)
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_ArrOLineSegment(3), "LengthChecker", True)
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_ArrOLineX1(3), "X1", True)
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_ArrOLineX2(3), "X2", True)
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_ArrOWidth(3), "Width", True)
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_ArrOHeight(3), "Height", True)

            Me.CdtALeft.Display = Me.CdpALeft
            Me.CdtARight.Display = Me.CdpARight
            Me.CdtBLeft.Display = Me.CdpBLeft
            Me.CdtBRight.Display = Me.CdpBRight
            Me.CdsALeft.Display = Me.CdpALeft
            Me.CdsARight.Display = Me.CdpARight
            Me.CdsBLeft.Display = Me.CdpBLeft
            Me.CdsBRight.Display = Me.CdpBRight

            Me.NudASectionXY.Value = CEnvironment.It.F64ASectionXY
            Me.NudAPointXY.Value = CEnvironment.It.I32APointXY
            Me.NudASectionT.Value = CEnvironment.It.F64ASectionT
            Me.NudAPointT.Value = CEnvironment.It.I32APointT
            Me.NudBSectionXY.Value = CEnvironment.It.F64BSectionXY
            Me.NudBPointXY.Value = CEnvironment.It.I32BPointXY
            Me.NudBSectionT.Value = CEnvironment.It.F64BSectionT
            Me.NudBPointT.Value = CEnvironment.It.I32BPointT

            Me.BtnStart.BackColor = Color.SteelBlue
            Me.BtnStop.BackColor = SystemColors.Control
            Me.BtnStart.Enabled = True
            Me.BtnStop.Enabled = False

            Me.m_OALeftInterrupt = New Object()
            Me.m_OARightInterrupt = New Object()
            Me.m_OBLeftInterrupt = New Object()
            Me.m_OBRightInterrupt = New Object()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Me.m_BPreventEvent = False
        End Try
    End Sub
#End Region


#Region "EVENT"
#Region "BUTTON EVENT"
    Private Sub BtnShowChecker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnALeftShowChecker.Click, BtnARightShowChecker.Click, BtnBLeftShowChecker.Click, BtnBRightShowChecker.Click
        Try
            Dim I32Index As Integer = Convert.ToInt32(CType(CType(sender, Control).Tag, String))

            Try
                Select Case (I32Index)
                    Case 0
                        Monitor.Enter(Me.m_OALeftInterrupt)
                        Me.m_BCaliperAbleAL = True
                    Case 1
                        Monitor.Enter(Me.m_OARightInterrupt)
                        Me.m_BCaliperAbleAR = True
                    Case 2
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                        Me.m_BCaliperAbleBL = True
                    Case 3
                        Monitor.Enter(Me.m_OBRightInterrupt)
                        Me.m_BCaliperAbleBR = True
                End Select

                Me.m_ArrOLineSegment(I32Index).Visible = False
                Me.m_ArrOLineX1(I32Index).Visible = False
                Me.m_ArrOLineX2(I32Index).Visible = False
                Me.m_ArrOWidth(I32Index).Visible = False
                Me.m_ArrOHeight(I32Index).Visible = False
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (I32Index)
                    Case 0
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case 1
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case 2
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case 3
                        Monitor.Exit(Me.m_OBRightInterrupt)
                End Select
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnClearChecker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnALeftClearChecker.Click, BtnARightClearChecker.Click, BtnBLeftClearChecker.Click, BtnBRightClearChecker.Click
        Try
            Dim I32Index As Integer = Convert.ToInt32(CType(CType(sender, Control).Tag, String))

            Try
                Select Case (I32Index)
                    Case 0
                        Monitor.Enter(Me.m_OALeftInterrupt)
                    Case 1
                        Monitor.Enter(Me.m_OARightInterrupt)
                    Case 2
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                    Case 3
                        Monitor.Enter(Me.m_OBRightInterrupt)
                End Select

                Me.m_ArrOLineSegment(I32Index).Visible = False
                Me.m_ArrOLineX1(I32Index).Visible = False
                Me.m_ArrOLineX2(I32Index).Visible = False
                Me.m_ArrOWidth(I32Index).Visible = False
                Me.m_ArrOHeight(I32Index).Visible = False
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (I32Index)
                    Case 0
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case 1
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case 2
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case 3
                        Monitor.Exit(Me.m_OBRightInterrupt)
                End Select
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub

    'check the section data
    Private Sub BtnApplyCalibInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApplyCalibInfo.Click
        Try
            Dim F64ASectionXY As Double = Convert.ToDouble(Me.NudASectionXY.Value)
            Dim I32APointXY As Integer = Convert.ToInt32(Me.NudAPointXY.Value)
            Dim F64ASectionT As Double = Convert.ToDouble(Me.NudASectionT.Value)
            Dim I32APointT As Integer = Convert.ToInt32(Me.NudAPointT.Value)
            Dim F64BSectionXY As Double = Convert.ToDouble(Me.NudBSectionXY.Value)
            Dim I32BPointXY As Integer = Convert.ToInt32(Me.NudBPointXY.Value)
            Dim F64BSectionT As Double = Convert.ToDouble(Me.NudBSectionT.Value)
            Dim I32BPointT As Integer = Convert.ToInt32(Me.NudBPointT.Value)

            CEnvironment.It.F64ASectionXY = F64ASectionXY
            CEnvironment.It.I32APointXY = I32APointXY
            CEnvironment.It.F64ASectionT = F64ASectionT
            CEnvironment.It.I32APointT = I32APointT
            CEnvironment.It.F64BSectionXY = F64BSectionXY
            CEnvironment.It.I32BPointXY = I32BPointXY
            CEnvironment.It.F64BSectionT = F64BSectionT
            CEnvironment.It.I32BPointT = I32BPointT
            CEnvironment.It.Commit()

            CTool.It.OStageA.F64SectionXY = F64ASectionXY
            CTool.It.OStageA.I32PointXY = I32APointXY
            CTool.It.OStageA.F64SectionT = F64ASectionT
            CTool.It.OStageA.I32PointT = I32APointT
            CTool.It.OStageB.F64SectionXY = F64BSectionXY
            CTool.It.OStageB.I32PointXY = I32BPointXY
            CTool.It.OStageB.F64SectionT = F64BSectionT
            CTool.It.OStageB.I32PointT = I32BPointT
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnApplyCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApplyCamera.Click
        Try
            Select Case Me.CmbCamera.Text
                Case "#1 LEFT"
                    CAcquisitionManager.It.OALeft.I32Gain = Convert.ToInt32(Me.NudGain.Value)
                    CAcquisitionManager.It.OALeft.I32ExposureTime = Convert.ToInt32(Me.NudExpoTime.Value)
                    CEnvironment.It.Cam1Gain = CAcquisitionManager.It.OALeft.I32Gain
                    CEnvironment.It.Cam1Exp = CAcquisitionManager.It.OALeft.I32ExposureTime
                Case "#1 RIGHT"
                    CAcquisitionManager.It.OARight.I32Gain = Convert.ToInt32(Me.NudGain.Value)
                    CAcquisitionManager.It.OARight.I32ExposureTime = Convert.ToInt32(Me.NudExpoTime.Value)
                    CEnvironment.It.Cam2Gain = CAcquisitionManager.It.OARight.I32Gain
                    CEnvironment.It.Cam2Exp = CAcquisitionManager.It.OARight.I32ExposureTime
                Case "#2 LEFT"
                    CAcquisitionManager.It.OBLeft.I32Gain = Convert.ToInt32(Me.NudGain.Value)
                    CAcquisitionManager.It.OBLeft.I32ExposureTime = Convert.ToInt32(Me.NudExpoTime.Value)
                    CEnvironment.It.Cam3Gain = CAcquisitionManager.It.OBLeft.I32Gain
                    CEnvironment.It.Cam3Exp = CAcquisitionManager.It.OBLeft.I32ExposureTime
                Case "#2 RIGHT"
                    CAcquisitionManager.It.OBRight.I32Gain = Convert.ToInt32(Me.NudGain.Value)
                    CAcquisitionManager.It.OBRight.I32ExposureTime = Convert.ToInt32(Me.NudExpoTime.Value)
                    CEnvironment.It.Cam4Gain = CAcquisitionManager.It.OBRight.I32Gain
                    CEnvironment.It.Cam4Exp = CAcquisitionManager.It.OBRight.I32ExposureTime
            End Select

            CEnvironment.It.Commit()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnROIShape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnROIShape.Click
        Try
            Try
                Select Case (Me.CmbROIView.Text)
                    Case "#1 LEFT"
                        Monitor.Enter(Me.m_OALeftInterrupt)
                    Case "#1 RIGHT"
                        Monitor.Enter(Me.m_OARightInterrupt)
                    Case "#2 LEFT"
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                    Case "#2 RIGHT"
                        Monitor.Enter(Me.m_OBRightInterrupt)
                End Select

                If (Me.ChkROIKind.Checked = True) Then
                    Select Case (Me.CmbROIView.Text)
                        Case "#1 LEFT"
                            Me.m_StrALeftROIKind = "ROI"
                            Me.m_F64ALeftROIRealWidth = Me.NudROIWidth.Value
                            Me.m_F64ALeftROIRealHeight = Me.NudROIHeight.Value
                            Me.m_OROIALeft.Width = (Me.m_F64ALeftROIRealWidth / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIALeft.Height = (Me.m_F64ALeftROIRealHeight / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIALeft.Visible = True
                        Case "#1 RIGHT"
                            Me.m_StrARightROIKind = "ROI"
                            Me.m_F64ARightROIRealWidth = Me.NudROIWidth.Value
                            Me.m_F64ARightROIRealHeight = Me.NudROIHeight.Value
                            Me.m_OROIARight.Width = (Me.m_F64ARightROIRealWidth / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIARight.Height = (Me.m_F64ARightROIRealHeight / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIARight.Visible = True
                        Case "#2 LEFT"
                            Me.m_StrBLeftROIKind = "ROI"
                            Me.m_F64BLeftROIRealWidth = Me.NudROIWidth.Value
                            Me.m_F64BLeftROIRealHeight = Me.NudROIHeight.Value
                            Me.m_OROIBLeft.Width = (Me.m_F64BLeftROIRealWidth / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIBLeft.Height = (Me.m_F64BLeftROIRealHeight / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIBLeft.Visible = True
                        Case "#2 RIGHT"
                            Me.m_StrBRightROIKind = "ROI"
                            Me.m_F64BRightROIRealWidth = Me.NudROIWidth.Value
                            Me.m_F64BRightROIRealHeight = Me.NudROIHeight.Value
                            Me.m_OROIBRight.Width = (Me.m_F64BRightROIRealWidth / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIBRight.Height = (Me.m_F64BRightROIRealHeight / CEnvironment.LEN_PER_PIXEL)
                            Me.m_OROIBRight.Visible = True
                    End Select
                Else
                    Select Case Me.CmbROIView.Text
                        Case "#1 LEFT"
                            Me.m_StrALeftROIKind = "ALL"
                            Me.m_OROIALeft.Visible = False
                        Case "#1 RIGHT"
                            Me.m_StrARightROIKind = "ALL"
                            Me.m_OROIARight.Visible = False
                        Case "#2 LEFT"
                            Me.m_StrBLeftROIKind = "ALL"
                            Me.m_OROIBLeft.Visible = False
                        Case "#2 RIGHT"
                            Me.m_StrBRightROIKind = "ALL"
                            Me.m_OROIBRight.Visible = False
                    End Select
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (Me.CmbROIView.Text)
                    Case "#1 LEFT"
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case "#1 RIGHT"
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case "#2 LEFT"
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case "#2 RIGHT"
                        Monitor.Exit(Me.m_OBRightInterrupt)
                End Select
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnROICenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnROICenter.Click
        Try
            Try
                Select Case (Me.CmbROIView.Text)
                    Case "#1 LEFT"
                        Monitor.Enter(Me.m_OALeftInterrupt)
                    Case "#1 RIGHT"
                        Monitor.Enter(Me.m_OARightInterrupt)
                    Case "#2 LEFT"
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                    Case "#2 RIGHT"
                        Monitor.Enter(Me.m_OBRightInterrupt)
                End Select

                Select Case (Me.CmbROIView.Text)
                    Case "#1 LEFT"
                        If (Me.m_StrALeftROIKind = "ROI") Then
                            Me.m_OROIALeft.X = (CAcquisitionManager.It.OALeft.I32Width / 2D) - (Me.m_OROIALeft.Width / 2D)
                            Me.m_OROIALeft.Y = (CAcquisitionManager.It.OALeft.I32Height / 2D) - (Me.m_OROIALeft.Height / 2D)
                        End If
                    Case "#1 RIGHT"
                        If (Me.m_StrARightROIKind = "ROI") Then
                            Me.m_OROIARight.X = (CAcquisitionManager.It.OARight.I32Width / 2D) - (Me.m_OROIARight.Width / 2D)
                            Me.m_OROIARight.Y = (CAcquisitionManager.It.OARight.I32Height / 2D) - (Me.m_OROIARight.Height / 2D)
                        End If
                    Case "#2 LEFT"
                        If (Me.m_StrBLeftROIKind = "ROI") Then
                            Me.m_OROIBLeft.X = (CAcquisitionManager.It.OBLeft.I32Width / 2D) - (Me.m_OROIBLeft.Width / 2D)
                            Me.m_OROIBLeft.Y = (CAcquisitionManager.It.OBLeft.I32Height / 2D) - (Me.m_OROIBLeft.Height / 2D)
                        End If
                    Case "#2 RIGHT"
                        If (Me.m_StrBRightROIKind = "ROI") Then
                            Me.m_OROIBRight.X = (CAcquisitionManager.It.OBRight.I32Width / 2D) - (Me.m_OROIBRight.Width / 2D)
                            Me.m_OROIBRight.Y = (CAcquisitionManager.It.OBRight.I32Height / 2D) - (Me.m_OROIBRight.Height / 2D)
                        End If
                End Select
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (Me.CmbROIView.Text)
                    Case "#1 LEFT"
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case "#1 RIGHT"
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case "#2 LEFT"
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case "#2 RIGHT"
                        Monitor.Exit(Me.m_OBRightInterrupt)
                End Select
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnROIGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnROIGoBack.Click
        Try
            Me.m_BPreventEvent = True

            Me.InitROIInfo()
            Me.DisplayROIInfo()
        Catch ex As Exception
            CError.Show(ex)
        Finally
            Me.m_BPreventEvent = False
        End Try
    End Sub


    Private Sub BtnROIApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnROIApply.Click
        Try
            Try
                Monitor.Enter(Me.m_OALeftInterrupt)
                Monitor.Enter(Me.m_OARightInterrupt)
                Monitor.Enter(Me.m_OBLeftInterrupt)
                Monitor.Enter(Me.m_OBRightInterrupt)

                CEnvironment.It.StrALeftROIKind = Me.m_StrALeftROIKind
                CEnvironment.It.F64ALeftROIRealWidth = Me.m_F64ALeftROIRealWidth
                CEnvironment.It.F64ALeftROIRealHeight = Me.m_F64ALeftROIRealHeight
                CEnvironment.It.F64ALeftROIX = Me.m_OROIALeft.X
                CEnvironment.It.F64ALeftROIY = Me.m_OROIALeft.Y
                CEnvironment.It.F64ALeftROIWidth = Me.m_OROIALeft.Width
                CEnvironment.It.F64ALeftROIHeight = Me.m_OROIALeft.Height

                CEnvironment.It.StrARightROIKind = Me.m_StrARightROIKind
                CEnvironment.It.F64ARightROIRealWidth = Me.m_F64ARightROIRealWidth
                CEnvironment.It.F64ARightROIRealHeight = Me.m_F64ARightROIRealHeight
                CEnvironment.It.F64ARightROIX = Me.m_OROIARight.X
                CEnvironment.It.F64ARightROIY = Me.m_OROIARight.Y
                CEnvironment.It.F64ARightROIWidth = Me.m_OROIARight.Width
                CEnvironment.It.F64ARightROIHeight = Me.m_OROIARight.Height

                CEnvironment.It.StrBLeftROIKind = Me.m_StrBLeftROIKind
                CEnvironment.It.F64BLeftROIRealWidth = Me.m_F64BLeftROIRealWidth
                CEnvironment.It.F64BLeftROIRealHeight = Me.m_F64BLeftROIRealHeight
                CEnvironment.It.F64BLeftROIX = Me.m_OROIBLeft.X
                CEnvironment.It.F64BLeftROIY = Me.m_OROIBLeft.Y
                CEnvironment.It.F64BLeftROIWidth = Me.m_OROIBLeft.Width
                CEnvironment.It.F64BLeftROIHeight = Me.m_OROIBLeft.Height

                CEnvironment.It.StrBRightROIKind = Me.m_StrBRightROIKind
                CEnvironment.It.F64BRightROIRealWidth = Me.m_F64BRightROIRealWidth
                CEnvironment.It.F64BRightROIRealHeight = Me.m_F64BRightROIRealHeight
                CEnvironment.It.F64BRightROIX = Me.m_OROIBRight.X
                CEnvironment.It.F64BRightROIY = Me.m_OROIBRight.Y
                CEnvironment.It.F64BRightROIWidth = Me.m_OROIBRight.Width
                CEnvironment.It.F64BRightROIHeight = Me.m_OROIBRight.Height
                CEnvironment.It.Commit()


                'CTool.It.OStageA.BLeftIsROIAll = (CEnvironment.It.StrALeftROIKind = "ALL")
                'CTool.It.OStageA.F64LeftROIX = CEnvironment.It.F64ALeftROIX
                'CTool.It.OStageA.F64LeftROIY = CEnvironment.It.F64ALeftROIY
                'CTool.It.OStageA.F64LeftROIWidth = CEnvironment.It.F64ALeftROIWidth
                'CTool.It.OStageA.F64LeftROIHeight = CEnvironment.It.F64ALeftROIHeight
                'CTool.It.OStageA.BRightIsROIAll = (CEnvironment.It.StrARightROIKind = "ALL")
                'CTool.It.OStageA.F64RightROIX = CEnvironment.It.F64ARightROIX
                'CTool.It.OStageA.F64RightROIY = CEnvironment.It.F64ARightROIY
                'CTool.It.OStageA.F64RightROIWidth = CEnvironment.It.F64ARightROIWidth
                'CTool.It.OStageA.F64RightROIHeight = CEnvironment.It.F64ARightROIHeight

                'CTool.It.OStageB.BLeftIsROIAll = (CEnvironment.It.StrBLeftROIKind = "ALL")
                'CTool.It.OStageB.F64LeftROIX = CEnvironment.It.F64BLeftROIX
                'CTool.It.OStageB.F64LeftROIY = CEnvironment.It.F64BLeftROIY
                'CTool.It.OStageB.F64LeftROIWidth = CEnvironment.It.F64BLeftROIWidth
                'CTool.It.OStageB.F64LeftROIHeight = CEnvironment.It.F64BLeftROIHeight
                'CTool.It.OStageB.BRightIsROIAll = (CEnvironment.It.StrBRightROIKind = "ALL")
                'CTool.It.OStageB.F64RightROIX = CEnvironment.It.F64BRightROIX
                'CTool.It.OStageB.F64RightROIY = CEnvironment.It.F64BRightROIY
                'CTool.It.OStageB.F64RightROIWidth = CEnvironment.It.F64BRightROIWidth
                'CTool.It.OStageB.F64RightROIHeight = CEnvironment.It.F64BRightROIHeight
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Monitor.Exit(Me.m_OALeftInterrupt)
                Monitor.Exit(Me.m_OARightInterrupt)
                Monitor.Exit(Me.m_OBLeftInterrupt)
                Monitor.Exit(Me.m_OBRightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        Try
            CAcquisitionManager.It.OALeft.Start()
            CAcquisitionManager.It.OARight.Start()
            CAcquisitionManager.It.OBLeft.Start()
            CAcquisitionManager.It.OBRight.Start()

            CTool.It.OStageA.BeginCalibration()
            CTool.It.OStageB.BeginCalibration()
            ' ROI 지정
            ROI_Change()

            Me.BtnStart.BackColor = SystemColors.Control
            Me.BtnStop.BackColor = Color.SteelBlue
            Me.BtnStart.Enabled = False
            Me.BtnStop.Enabled = True

            MyBase.OnScreenFixed(ESCREEN.SETUP, True)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStop.Click
        Try
            Try
                Monitor.Enter(Me.m_OALeftInterrupt)
                Monitor.Enter(Me.m_OARightInterrupt)
                Monitor.Enter(Me.m_OBLeftInterrupt)
                Monitor.Enter(Me.m_OBRightInterrupt)

                CTool.It.OStageA.EndCalibration()
                CTool.It.OStageB.EndCalibration()

                CAcquisitionManager.It.OALeft.Stop()
                CAcquisitionManager.It.OARight.Stop()
                CAcquisitionManager.It.OBLeft.Stop()
                CAcquisitionManager.It.OBRight.Stop()

                Me.CdpALeft.StaticGraphics.Clear()
                Me.CdpARight.StaticGraphics.Clear()
                Me.CdpBLeft.StaticGraphics.Clear()
                Me.CdpBRight.StaticGraphics.Clear()

                Me.BtnStart.BackColor = Color.SteelBlue
                Me.BtnStop.BackColor = SystemColors.Control
                Me.BtnStart.Enabled = True
                Me.BtnStop.Enabled = False

                CMotionController.It.OPLC.Initialize_Calibration()

                MyBase.OnScreenFixed(ESCREEN.SETUP, False)
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Monitor.Exit(Me.m_OALeftInterrupt)
                Monitor.Exit(Me.m_OARightInterrupt)
                Monitor.Exit(Me.m_OBLeftInterrupt)
                Monitor.Exit(Me.m_OBRightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "ETC EVENT"
    Private Sub CmbROIView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbROIView.SelectedIndexChanged
        If Me.m_BPreventEvent = True Then Return

        Try
            Me.m_BPreventEvent = True
            Me.DisplayROIInfo()
        Catch ex As Exception
            CError.Show(ex)
        Finally
            Me.m_BPreventEvent = False
        End Try
    End Sub


    Private Sub ChkROIKind_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkROIKind.CheckedChanged
        If Me.m_BPreventEvent = True Then Return

        Try
            If (Me.ChkROIKind.Checked = True) Then
                Me.ChkROIKind.Text = "ROI"
                Select Case Me.CmbROIView.Text
                    Case "#1 LEFT"
                        Me.NudROIWidth.Value = Me.m_F64ALeftROIRealWidth
                        Me.NudROIHeight.Value = Me.m_F64ALeftROIRealHeight
                    Case "#1 RIGHT"
                        Me.NudROIWidth.Value = Me.m_F64ARightROIRealWidth
                        Me.NudROIHeight.Value = Me.m_F64ARightROIRealHeight
                    Case "#2 LEFT"
                        Me.NudROIWidth.Value = Me.m_F64BLeftROIRealWidth
                        Me.NudROIHeight.Value = Me.m_F64BLeftROIRealHeight
                    Case "#2 RIGHT"
                        Me.NudROIWidth.Value = Me.m_F64BRightROIRealWidth
                        Me.NudROIHeight.Value = Me.m_F64BRightROIRealHeight
                End Select
                Me.NudROIWidth.Controls(1).Text = Me.NudROIWidth.Value.ToString("0.000")
                Me.NudROIHeight.Controls(1).Text = Me.NudROIHeight.Value.ToString("0.000")
                Me.NudROIWidth.Enabled = True
                Me.NudROIHeight.Enabled = True
            Else
                Me.ChkROIKind.Text = "ALL"
                Me.NudROIWidth.Controls(1).Text = String.Empty
                Me.NudROIHeight.Controls(1).Text = String.Empty
                Me.NudROIWidth.Enabled = False
                Me.NudROIHeight.Enabled = False
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub CmbCamera_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCamera.SelectedIndexChanged
        If Me.m_BPreventEvent = True Then Return

        Try
            Me.DisplayCameraInfo()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub StageALeft_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)

            Me.CdpALeft.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
        End Try
    End Sub


    Private Sub StageARight_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            Monitor.Enter(Me.m_OARightInterrupt)

            Me.CdpARight.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub


    Private Sub StageBLeft_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            Monitor.Enter(Me.m_OBLeftInterrupt)

            Me.CdpBLeft.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBLeftInterrupt)
        End Try
    End Sub


    Private Sub StageBRight_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            Monitor.Enter(Me.m_OBRightInterrupt)

            Me.CdpBRight.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Sub StageA_CalibrationStart()
        Try
            If (MyBase.InvokeRequired = True) Then
                MyBase.BeginInvoke(New CAlignmentTool.CalibrationStartHandler(AddressOf Me.StageA_CalibrationStart))
            Else
                Try
                    Monitor.Enter(Me.m_OALeftInterrupt)
                    Monitor.Enter(Me.m_OARightInterrupt)
                
                    Me.CdpALeft.StaticGraphics.Clear()
                    Me.CdpARight.StaticGraphics.Clear()

                    Me.BtnStop.BackColor = SystemColors.Control
                    Me.BtnStop.Enabled = False
                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OALeftInterrupt)
                    Monitor.Exit(Me.m_OARightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub GraphicClear()
        Try
            If (MyBase.InvokeRequired = True) Then
                MyBase.BeginInvoke(New CAlignmentTool.ClearGraphicHandler(AddressOf Me.GraphicClear))
            Else
                Try
                    Monitor.Enter(Me.m_OALeftInterrupt)
                    Monitor.Enter(Me.m_OARightInterrupt)

                    Me.CdpALeft.StaticGraphics.Clear()
                    Me.CdpARight.StaticGraphics.Clear()
                    Me.CdpBLeft.StaticGraphics.Clear()
                    Me.CdpBRight.StaticGraphics.Clear()
                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OALeftInterrupt)
                    Monitor.Exit(Me.m_OARightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    '20170822
    Private Sub StageA_PartialCalibrationRan(ByVal OResult As CMarkResult, ByVal I32Left0Right1 As Integer)
        Try
            If MyBase.InvokeRequired = True Then
                MyBase.BeginInvoke(New CAlignmentTool.PartialCalibrationRanHandler(AddressOf Me.StageA_PartialCalibrationRan), OResult, I32Left0Right1)
            Else
                Try
                    Monitor.Enter(Me.m_OALeftInterrupt)
                    Monitor.Enter(Me.m_OARightInterrupt)
                    If (I32Left0Right1 = 0) Then
                        If (Not OResult Is Nothing) Then
                            If ((OResult.BInspected = True) AndAlso (OResult.BOK = True)) Then
                                Dim OLeftPoint As CogPointMarker = New CogPointMarker()
                                OLeftPoint.X = OResult.F64X
                                OLeftPoint.Y = OResult.F64Y
                                OLeftPoint.Color = CogColorConstants.Green
                                OLeftPoint.SizeInScreenPixels = 30
                                Me.CdpALeft.StaticGraphics.Add(OLeftPoint, "Point")
                            End If
                        End If
                    Else
                        If (Not OResult Is Nothing) Then
                            If ((OResult.BInspected = True) AndAlso (OResult.BOK = True)) Then

                                Dim ORightPoint As CogPointMarker = New CogPointMarker()
                                ORightPoint.X = OResult.F64X
                                ORightPoint.Y = OResult.F64Y
                                ORightPoint.Color = CogColorConstants.Green
                                ORightPoint.SizeInScreenPixels = 30
                                Me.CdpARight.StaticGraphics.Add(ORightPoint, "Point")
                            End If
                        End If
                    End If

                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OALeftInterrupt)
                    Monitor.Exit(Me.m_OARightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub StageA_CalibrationRan(ByVal OLeftResult As CMarkResult, ByVal ORightResult As CMarkResult)
        Try
            If MyBase.InvokeRequired = True Then
                MyBase.BeginInvoke(New CAlignmentTool.CalibrationRanHandler(AddressOf Me.StageA_CalibrationRan), OLeftResult, ORightResult)
            Else
                Try
                    Monitor.Enter(Me.m_OALeftInterrupt)
                    Monitor.Enter(Me.m_OARightInterrupt)
                
                    If (Not OLeftResult Is Nothing) AndAlso (Not ORightResult Is Nothing) Then
                        If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) AndAlso _
                           ((ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True)) Then
                            Dim OLeftPoint As CogPointMarker = New CogPointMarker()
                            OLeftPoint.X = OLeftResult.F64X
                            OLeftPoint.Y = OLeftResult.F64Y
                            OLeftPoint.Color = CogColorConstants.Green
                            OLeftPoint.SizeInScreenPixels = 30
                            Me.CdpALeft.StaticGraphics.Add(OLeftPoint, "Point")

                            Dim ORightPoint As CogPointMarker = New CogPointMarker()
                            ORightPoint.X = ORightResult.F64X
                            ORightPoint.Y = ORightResult.F64Y
                            ORightPoint.Color = CogColorConstants.Green
                            ORightPoint.SizeInScreenPixels = 30
                            Me.CdpARight.StaticGraphics.Add(ORightPoint, "Point")
                        End If
                    End If
                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OALeftInterrupt)
                    Monitor.Exit(Me.m_OARightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub StageA_CalibrationFinish(ByVal BIsSuccess As Boolean, ByVal StrMessage As String)
        Try
            If (MyBase.InvokeRequired = True) Then
                MyBase.BeginInvoke(New CAlignmentTool.CalibrationFinishHandler(AddressOf Me.StageA_CalibrationFinish), BIsSuccess, StrMessage)
            Else
                Me.BtnStop.BackColor = Color.SteelBlue
                Me.BtnStop.Enabled = True
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub StageB_CalibrationStart()
        Try
            If (MyBase.InvokeRequired = True) Then
                MyBase.BeginInvoke(New CAlignmentTool.CalibrationStartHandler(AddressOf Me.StageB_CalibrationStart))
            Else
                Try
                    Monitor.Enter(Me.m_OBLeftInterrupt)
                    Monitor.Enter(Me.m_OBRightInterrupt)

                    Me.CdpBLeft.StaticGraphics.Clear()
                    Me.CdpBRight.StaticGraphics.Clear()

                    Me.BtnStop.BackColor = SystemColors.Control
                    Me.BtnStop.Enabled = False
                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OBLeftInterrupt)
                    Monitor.Exit(Me.m_OBRightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    '20170822
    Private Sub StageB_PartialCalibrationRan(ByVal OResult As CMarkResult, ByVal I32Left0Right1 As Integer)
        Try
            If MyBase.InvokeRequired = True Then
                MyBase.BeginInvoke(New CAlignmentTool.PartialCalibrationRanHandler(AddressOf Me.StageB_PartialCalibrationRan), OResult, I32Left0Right1)
            Else
                Try
                    Monitor.Enter(Me.m_OBLeftInterrupt)
                    Monitor.Enter(Me.m_OBRightInterrupt)
                    If (I32Left0Right1 = 0) Then
                        If (Not OResult Is Nothing) Then
                            If ((OResult.BInspected = True) AndAlso (OResult.BOK = True)) Then
                                Dim OLeftPoint As CogPointMarker = New CogPointMarker()
                                OLeftPoint.X = OResult.F64X
                                OLeftPoint.Y = OResult.F64Y
                                OLeftPoint.Color = CogColorConstants.Green
                                OLeftPoint.SizeInScreenPixels = 30
                                Me.CdpBLeft.StaticGraphics.Add(OLeftPoint, "Point")
                            End If
                        End If
                    Else
                        If (Not OResult Is Nothing) Then
                            If ((OResult.BInspected = True) AndAlso (OResult.BOK = True)) Then

                                Dim ORightPoint As CogPointMarker = New CogPointMarker()
                                ORightPoint.X = OResult.F64X
                                ORightPoint.Y = OResult.F64Y
                                ORightPoint.Color = CogColorConstants.Green
                                ORightPoint.SizeInScreenPixels = 30
                                Me.CdpBRight.StaticGraphics.Add(ORightPoint, "Point")
                            End If
                        End If
                    End If

                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OBLeftInterrupt)
                    Monitor.Exit(Me.m_OBRightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub StageB_CalibrationRan(ByVal OLeftResult As CMarkResult, ByVal ORightResult As CMarkResult)
        Try
            If MyBase.InvokeRequired = True Then
                MyBase.BeginInvoke(New CAlignmentTool.CalibrationRanHandler(AddressOf Me.StageB_CalibrationRan), OLeftResult, ORightResult)
            Else
                Try
                    Monitor.Enter(Me.m_OBLeftInterrupt)
                    Monitor.Enter(Me.m_OBRightInterrupt)

                    If (Not OLeftResult Is Nothing) AndAlso (Not ORightResult Is Nothing) Then
                        If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) AndAlso _
                           ((ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True)) Then
                            Dim OLeftPoint As CogPointMarker = New CogPointMarker()
                            OLeftPoint.X = OLeftResult.F64X
                            OLeftPoint.Y = OLeftResult.F64Y
                            OLeftPoint.Color = CogColorConstants.Green
                            OLeftPoint.SizeInScreenPixels = 30
                            Me.CdpBLeft.StaticGraphics.Add(OLeftPoint, "Point")

                            Dim ORightPoint As CogPointMarker = New CogPointMarker()
                            ORightPoint.X = ORightResult.F64X
                            ORightPoint.Y = ORightResult.F64Y
                            ORightPoint.Color = CogColorConstants.Green
                            ORightPoint.SizeInScreenPixels = 30
                            Me.CdpBRight.StaticGraphics.Add(ORightPoint, "Point")
                        End If
                    End If
                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Monitor.Exit(Me.m_OBLeftInterrupt)
                    Monitor.Exit(Me.m_OBRightInterrupt)
                End Try
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub StageB_CalibrationFinish(ByVal BIsSuccess As Boolean, ByVal StrMessage As String)
        Try
            If (MyBase.InvokeRequired = True) Then
                MyBase.BeginInvoke(New CAlignmentTool.CalibrationFinishHandler(AddressOf Me.StageB_CalibrationFinish), BIsSuccess, StrMessage)
            Else
                Me.BtnStop.BackColor = Color.SteelBlue
                Me.BtnStop.Enabled = True
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub CdpImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CdpALeft.Click, CdpARight.Click, CdpBLeft.Click, CdpBRight.Click
        Try
            'tag: A LEFT, A RIGHT, B LEFT, B RIGHT in the display
            Dim StrDisplayTag As String = CType(CType(sender, Control).Tag, String)

            Dim I32Index As Integer = 0
            Select Case StrDisplayTag
                Case "A LEFT"
                    I32Index = 0
                Case "A RIGHT"
                    I32Index = 1
                Case "B LEFT"
                    I32Index = 2
                Case "B RIGHT"
                    I32Index = 3
            End Select

            Try
                Select Case (I32Index)
                    Case 0
                        Monitor.Enter(Me.m_OALeftInterrupt)
                        If (Me.m_BCaliperAbleAL = False) Then Exit Sub
                    Case 1
                        Monitor.Enter(Me.m_OARightInterrupt)
                        If (Me.m_BCaliperAbleAR = False) Then Exit Sub
                    Case 2
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                        If (Me.m_BCaliperAbleBL = False) Then Exit Sub
                    Case 3
                        Monitor.Enter(Me.m_OBRightInterrupt)
                        If (Me.m_BCaliperAbleBR = False) Then Exit Sub
                End Select

                Dim OPoint As Point = New Point(MousePosition.X, MousePosition.Y)
                OPoint = sender.PointToClient(OPoint)

                Dim F64X As Double = 0
                Dim F64Y As Double = 0
                Dim OTransform As CogTransform2DLinear = sender.GetTransform("#", "*")
                OTransform.MapPoint(OPoint.X, OPoint.Y, F64X, F64Y)

                Dim F64Width As Double = 0
                Dim F64Height As Double = 0
                If (Me.m_ArrBIsSecond(I32Index) = False) Then
                    Me.m_ArrBIsSecond(I32Index) = True
                    'X1 is the base
                    Me.m_ArrOLineSegment(I32Index).SetStartEnd(Me.m_ArrOLineSegment(I32Index).StartX, Me.m_ArrOLineSegment(I32Index).StartY, F64X, F64Y)
                    Me.m_ArrOLineSegment(I32Index).SetStartEnd(F64X, F64Y, Me.m_ArrOLineSegment(I32Index).EndX, Me.m_ArrOLineSegment(I32Index).EndY)
                    Me.m_ArrOLineX1(I32Index).X = F64X
                    Me.m_ArrOLineX2(I32Index).X = F64X
                    Me.m_ArrOLineSegment(I32Index).Visible = True
                    Me.m_ArrOLineX2(I32Index).Visible = True
                ElseIf (Me.m_ArrBIsSecond(I32Index) = True) Then
                    Me.m_ArrBIsSecond(I32Index) = False
                    Me.m_ArrOLineSegment(I32Index).SetStartEnd(Me.m_ArrOLineSegment(I32Index).StartX, Me.m_ArrOLineSegment(I32Index).StartY, F64X, F64Y)
                    Me.m_ArrOLineX2(I32Index).X = F64X
                    Select Case (I32Index)
                        Case 0
                            Me.m_BCaliperAbleAL = False
                        Case 1
                            Me.m_BCaliperAbleAR = False
                        Case 2
                            Me.m_BCaliperAbleBL = False
                        Case 3
                            Me.m_BCaliperAbleBR = False
                    End Select

                    F64Width = Math.Abs(Me.m_ArrOLineSegment(I32Index).StartX - Me.m_ArrOLineSegment(I32Index).EndX)
                    F64Height = Math.Abs(Me.m_ArrOLineSegment(I32Index).StartY - Me.m_ArrOLineSegment(I32Index).EndY)
                    Me.m_ArrOWidth(I32Index).Text = "Width : " & Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL * 1000) & "um" & "(" & Math.Round(F64Width, 3) & "pix)"
                    Me.m_ArrOHeight(I32Index).Text = "Height : " & Math.Round(F64Height * CEnvironment.LEN_PER_PIXEL * 1000) & "um" & "(" & Math.Round(F64Height, 3) & "pix)"
                    Me.m_ArrOWidth(I32Index).Visible = True
                    Me.m_ArrOHeight(I32Index).Visible = True
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (I32Index)
                    Case 0
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case 1
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case 2
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case 3
                        Monitor.Exit(Me.m_OBRightInterrupt)
                End Select
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub CdpImage_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CdpALeft.MouseMove, CdpBRight.MouseMove, CdpBLeft.MouseMove, CdpARight.MouseMove
        Try
            'tag: A LEFT, A RIGHT, B LEFT, B RIGHT in the display
            Dim StrDisplayTag As String = CType(CType(sender, Control).Tag, String)

            Dim I32Index As Integer = 0
            Select Case StrDisplayTag
                Case "A LEFT"
                    I32Index = 0
                Case "A RIGHT"
                    I32Index = 1
                Case "B LEFT"
                    I32Index = 2
                Case "B RIGHT"
                    I32Index = 3
            End Select

            Try
                Select Case (I32Index)
                    Case 0
                        Monitor.Enter(Me.m_OALeftInterrupt)
                        If (Me.m_BCaliperAbleAL = False) Then Exit Sub
                    Case 1
                        Monitor.Enter(Me.m_OARightInterrupt)
                        If (Me.m_BCaliperAbleAR = False) Then Exit Sub
                    Case 2
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                        If (Me.m_BCaliperAbleBL = False) Then Exit Sub
                    Case 3
                        Monitor.Enter(Me.m_OBRightInterrupt)
                        If (Me.m_BCaliperAbleBR = False) Then Exit Sub
                End Select


                Dim OPoint As Point = New Point(MousePosition.X, MousePosition.Y)
                OPoint = sender.PointToClient(OPoint)

                Dim F64X As Double = 0
                Dim F64Y As Double = 0
                Dim OTransform As CogTransform2DLinear = sender.GetTransform("#", "*")
                OTransform.MapPoint(OPoint.X, OPoint.Y, F64X, F64Y)

                Dim F64Width As Double = 0
                Dim F64Height As Double = 0
                If (Me.m_ArrBIsSecond(I32Index) = False) Then
                    Me.m_ArrOLineX1(I32Index).Visible = True
                    Me.m_ArrOLineX1(I32Index).X = F64X
                ElseIf (Me.m_ArrBIsSecond(I32Index) = True) Then
                    Me.m_ArrOLineSegment(I32Index).SetStartEnd(Me.m_ArrOLineSegment(I32Index).StartX, Me.m_ArrOLineSegment(I32Index).StartY, F64X, F64Y)
                    Me.m_ArrOLineX2(I32Index).X = F64X
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (I32Index)
                    Case 0
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case 1
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case 2
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case 3
                        Monitor.Exit(Me.m_OBRightInterrupt)
                End Select
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region
#End Region


#Region "FUNCTION"
    Public Overrides Sub Add()
        Try
            CTool.It.OStageA.OLeft.ODisplayer.OImageExported = AddressOf Me.StageALeft_ImageExported
            CTool.It.OStageA.ORight.ODisplayer.OImageExported = AddressOf Me.StageARight_ImageExported
            CTool.It.OStageB.OLeft.ODisplayer.OImageExported = AddressOf Me.StageBLeft_ImageExported
            CTool.It.OStageB.ORight.ODisplayer.OImageExported = AddressOf Me.StageBRight_ImageExported
            CTool.It.OStageA.OCalibrationStart = AddressOf Me.StageA_CalibrationStart
            CTool.It.OStageA.OCalibrationRan = AddressOf Me.StageA_CalibrationRan
            CTool.It.OStageA.OCalibrationFinish = AddressOf Me.StageA_CalibrationFinish
            CTool.It.OStageB.OCalibrationStart = AddressOf Me.StageB_CalibrationStart
            CTool.It.OStageB.OCalibrationRan = AddressOf Me.StageB_CalibrationRan
            CTool.It.OStageB.OCalibrationFinish = AddressOf Me.StageB_CalibrationFinish

            '20170822
            CTool.It.OStageA.OPartialCalibrationRan = AddressOf Me.StageA_PartialCalibrationRan
            CTool.It.OStageB.OPartialCalibrationRan = AddressOf Me.StageB_PartialCalibrationRan
            CTool.It.OStageA.OGraphicClear = AddressOf Me.GraphicClear
            CTool.It.OStageB.OGraphicClear = AddressOf Me.GraphicClear


            Me.CmbROIView.SelectedIndex = 0
            Me.InitROIInfo()
            Me.DisplayROIInfo()

            Me.CmbCamera.SelectedIndex = 0
            Me.DisplayCameraInfo()
            ' jht Update Max Retry
            Me.NudMaxRetry.Minimum = 0
            Me.NudMaxRetry.Maximum = 100
            Me.NudMaxRetry.Value = CEnvironment.It.MaxRetry
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Overrides Sub Remove()
        Try
            CTool.It.OStageA.OLeft.ODisplayer.OImageExported = Nothing
            CTool.It.OStageA.ORight.ODisplayer.OImageExported = Nothing
            CTool.It.OStageB.OLeft.ODisplayer.OImageExported = Nothing
            CTool.It.OStageB.ORight.ODisplayer.OImageExported = Nothing
            CTool.It.OStageA.OCalibrationStart = Nothing
            CTool.It.OStageA.OCalibrationRan = Nothing
            CTool.It.OStageA.OCalibrationFinish = Nothing
            CTool.It.OStageB.OCalibrationStart = Nothing
            CTool.It.OStageB.OCalibrationRan = Nothing
            CTool.It.OStageB.OCalibrationFinish = Nothing
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub InitROIInfo()
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            Me.m_StrALeftROIKind = CEnvironment.It.StrALeftROIKind
            Me.m_F64ALeftROIRealWidth = CEnvironment.It.F64ALeftROIRealWidth
            Me.m_F64ALeftROIRealHeight = CEnvironment.It.F64ALeftROIRealHeight
            Me.m_OROIALeft.X = CEnvironment.It.F64ALeftROIX
            Me.m_OROIALeft.Y = CEnvironment.It.F64ALeftROIY
            Me.m_OROIALeft.Width = CEnvironment.It.F64ALeftROIWidth
            Me.m_OROIALeft.Height = CEnvironment.It.F64ALeftROIHeight
            Me.m_OROIALeft.Visible = False '(Not Me.m_StrALeftROIKind = "ALL")

            Me.m_StrARightROIKind = CEnvironment.It.StrARightROIKind
            Me.m_F64ARightROIRealWidth = CEnvironment.It.F64ARightROIRealWidth
            Me.m_F64ARightROIRealHeight = CEnvironment.It.F64ARightROIRealHeight
            Me.m_OROIARight.X = CEnvironment.It.F64ARightROIX
            Me.m_OROIARight.Y = CEnvironment.It.F64ARightROIY
            Me.m_OROIARight.Width = CEnvironment.It.F64ARightROIWidth
            Me.m_OROIARight.Height = CEnvironment.It.F64ARightROIHeight
            Me.m_OROIARight.Visible = False ' (Not Me.m_StrARightROIKind = "ALL")

            Me.m_StrBLeftROIKind = CEnvironment.It.StrBLeftROIKind
            Me.m_F64BLeftROIRealWidth = CEnvironment.It.F64BLeftROIRealWidth
            Me.m_F64BLeftROIRealHeight = CEnvironment.It.F64BLeftROIRealHeight
            Me.m_OROIBLeft.X = CEnvironment.It.F64BLeftROIX
            Me.m_OROIBLeft.Y = CEnvironment.It.F64BLeftROIY
            Me.m_OROIBLeft.Width = CEnvironment.It.F64BLeftROIWidth
            Me.m_OROIBLeft.Height = CEnvironment.It.F64BLeftROIHeight
            Me.m_OROIBLeft.Visible = False ' (Not Me.m_StrBLeftROIKind = "ALL")

            Me.m_StrBRightROIKind = CEnvironment.It.StrBRightROIKind
            Me.m_F64BRightROIRealWidth = CEnvironment.It.F64BRightROIRealWidth
            Me.m_F64BRightROIRealHeight = CEnvironment.It.F64BRightROIRealHeight
            Me.m_OROIBRight.X = CEnvironment.It.F64BRightROIX
            Me.m_OROIBRight.Y = CEnvironment.It.F64BRightROIY
            Me.m_OROIBRight.Width = CEnvironment.It.F64BRightROIWidth
            Me.m_OROIBRight.Height = CEnvironment.It.F64BRightROIHeight
            Me.m_OROIBRight.Visible = False '(Not Me.m_StrBRightROIKind = "ALL")
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Sub DisplayROIInfo()
        Try
            Console.WriteLine(Me.CmbROIView.Text)

            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            Select Case Me.CmbROIView.Text
                Case "#1 LEFT"
                    If Me.m_StrALeftROIKind = "ALL" Then
                        Me.ChkROIKind.Text = "ALL"
                        Me.ChkROIKind.Checked = False
                        Me.NudROIWidth.Controls(1).Text = String.Empty
                        Me.NudROIHeight.Controls(1).Text = String.Empty
                        Me.NudROIWidth.Enabled = False
                        Me.NudROIHeight.Enabled = False
                    Else
                        Me.ChkROIKind.Text = "ROI"
                        Me.ChkROIKind.Checked = True
                        Me.NudROIWidth.Value = Me.m_F64ALeftROIRealWidth
                        Me.NudROIWidth.Controls(1).Text = Me.NudROIWidth.Value.ToString("0.000")
                        Me.NudROIHeight.Value = Me.m_F64ALeftROIRealHeight
                        Me.NudROIHeight.Controls(1).Text = Me.NudROIHeight.Value.ToString("0.000")
                        Me.NudROIWidth.Enabled = True
                        Me.NudROIHeight.Enabled = True
                    End If
                Case "#1 RIGHT"
                    If Me.m_StrARightROIKind = "ALL" Then
                        Me.ChkROIKind.Text = "ALL"
                        Me.ChkROIKind.Checked = False
                        Me.NudROIWidth.Controls(1).Text = String.Empty
                        Me.NudROIHeight.Controls(1).Text = String.Empty
                        Me.NudROIWidth.Enabled = False
                        Me.NudROIHeight.Enabled = False
                    Else
                        Me.ChkROIKind.Text = "ROI"
                        Me.ChkROIKind.Checked = True
                        Me.NudROIWidth.Value = Me.m_F64ARightROIRealWidth
                        Me.NudROIWidth.Controls(1).Text = Me.NudROIWidth.Value.ToString("0.000")
                        Me.NudROIHeight.Value = Me.m_F64ARightROIRealHeight
                        Me.NudROIHeight.Controls(1).Text = Me.NudROIHeight.Value.ToString("0.000")
                        Me.NudROIWidth.Enabled = True
                        Me.NudROIHeight.Enabled = True
                    End If
                Case "#2 LEFT"
                    If Me.m_StrBLeftROIKind = "ALL" Then
                        Me.ChkROIKind.Text = "ALL"
                        Me.ChkROIKind.Checked = False
                        Me.NudROIWidth.Controls(1).Text = String.Empty
                        Me.NudROIHeight.Controls(1).Text = String.Empty
                        Me.NudROIWidth.Enabled = False
                        Me.NudROIHeight.Enabled = False
                    Else
                        Me.ChkROIKind.Text = "ROI"
                        Me.ChkROIKind.Checked = True
                        Me.NudROIWidth.Value = Me.m_F64BLeftROIRealWidth
                        Me.NudROIWidth.Controls(1).Text = Me.NudROIWidth.Value.ToString("0.000")
                        Me.NudROIHeight.Value = Me.m_F64BLeftROIRealHeight
                        Me.NudROIHeight.Controls(1).Text = Me.NudROIHeight.Value.ToString("0.000")
                        Me.NudROIWidth.Enabled = True
                        Me.NudROIHeight.Enabled = True
                    End If
                Case "#2 RIGHT"
                    If Me.m_StrBRightROIKind = "ALL" Then
                        Me.ChkROIKind.Text = "ALL"
                        Me.ChkROIKind.Checked = False
                        Me.NudROIWidth.Controls(1).Text = String.Empty
                        Me.NudROIHeight.Controls(1).Text = String.Empty
                        Me.NudROIWidth.Enabled = False
                        Me.NudROIHeight.Enabled = False
                    Else
                        Me.ChkROIKind.Text = "ROI"
                        Me.ChkROIKind.Checked = True
                        Me.NudROIWidth.Value = Me.m_F64BRightROIRealWidth
                        Me.NudROIWidth.Controls(1).Text = Me.NudROIWidth.Value.ToString("0.000")
                        Me.NudROIHeight.Value = Me.m_F64BRightROIRealHeight
                        Me.NudROIHeight.Controls(1).Text = Me.NudROIHeight.Value.ToString("0.000")
                        Me.NudROIWidth.Enabled = True
                        Me.NudROIHeight.Enabled = True
                    End If
            End Select

            Console.WriteLine("Width Value = " & Me.NudROIWidth.Value)
            Console.WriteLine("Height Value = " & Me.NudROIHeight.Value)
            Console.WriteLine("Width Text = " & Me.NudROIWidth.Controls(1).Text)
            Console.WriteLine("Height Text = " & Me.NudROIHeight.Controls(1).Text)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Sub DisplayCameraInfo()
        Try
            Select Case Me.CmbCamera.Text
                Case "#1 LEFT"
                    Me.NudGain.Minimum = CAcquisitionManager.It.OALeft.I32GainMin
                    Me.NudGain.Maximum = CAcquisitionManager.It.OALeft.I32GainMax
                    Me.NudGain.Value = CAcquisitionManager.It.OALeft.I32Gain
                    Me.NudExpoTime.Minimum = CAcquisitionManager.It.OALeft.I32ExposureTimeMin
                    Me.NudExpoTime.Maximum = CAcquisitionManager.It.OALeft.I32ExposureTimeMax
                    Me.NudExpoTime.Value = CAcquisitionManager.It.OALeft.I32ExposureTime
                Case "#1 RIGHT"
                    Me.NudGain.Minimum = CAcquisitionManager.It.OARight.I32GainMin
                    Me.NudGain.Maximum = CAcquisitionManager.It.OARight.I32GainMax
                    Me.NudGain.Value = CAcquisitionManager.It.OARight.I32Gain
                    Me.NudExpoTime.Minimum = CAcquisitionManager.It.OARight.I32ExposureTimeMin
                    Me.NudExpoTime.Maximum = CAcquisitionManager.It.OARight.I32ExposureTimeMax
                    Me.NudExpoTime.Value = CAcquisitionManager.It.OARight.I32ExposureTime
                Case "#2 LEFT"
                    Me.NudGain.Minimum = CAcquisitionManager.It.OBLeft.I32GainMin
                    Me.NudGain.Maximum = CAcquisitionManager.It.OBLeft.I32GainMax
                    Me.NudGain.Value = CAcquisitionManager.It.OBLeft.I32Gain
                    Me.NudExpoTime.Minimum = CAcquisitionManager.It.OBLeft.I32ExposureTimeMin
                    Me.NudExpoTime.Maximum = CAcquisitionManager.It.OBLeft.I32ExposureTimeMax
                    Me.NudExpoTime.Value = CAcquisitionManager.It.OBLeft.I32ExposureTime
                Case "#2 RIGHT"
                    Me.NudGain.Minimum = CAcquisitionManager.It.OBRight.I32GainMin
                    Me.NudGain.Maximum = CAcquisitionManager.It.OBRight.I32GainMax
                    Me.NudGain.Value = CAcquisitionManager.It.OBRight.I32Gain
                    Me.NudExpoTime.Minimum = CAcquisitionManager.It.OBRight.I32ExposureTimeMin
                    Me.NudExpoTime.Maximum = CAcquisitionManager.It.OBRight.I32ExposureTimeMax
                    Me.NudExpoTime.Value = CAcquisitionManager.It.OBRight.I32ExposureTime
            End Select
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region
    

    Private Sub BtnForceStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnForceStop.Click
        Try
            Try
                Monitor.Enter(Me.m_OALeftInterrupt)
                Monitor.Enter(Me.m_OARightInterrupt)
                Monitor.Enter(Me.m_OBLeftInterrupt)
                Monitor.Enter(Me.m_OBRightInterrupt)

                CTool.It.OStageA.ForceStop()
                CTool.It.OStageB.ForceStop()
                CTool.It.OStageA.EndCalibration()
                CTool.It.OStageB.EndCalibration()

                CAcquisitionManager.It.OALeft.Stop()
                CAcquisitionManager.It.OARight.Stop()
                CAcquisitionManager.It.OBLeft.Stop()
                CAcquisitionManager.It.OBRight.Stop()

                Me.CdpALeft.StaticGraphics.Clear()
                Me.CdpARight.StaticGraphics.Clear()
                Me.CdpBLeft.StaticGraphics.Clear()
                Me.CdpBRight.StaticGraphics.Clear()

                Me.BtnStart.BackColor = Color.SteelBlue
                Me.BtnStop.BackColor = SystemColors.Control
                Me.BtnStart.Enabled = True
                Me.BtnStop.Enabled = False

                CMotionController.It.OPLC.Initialize_Calibration()

                MyBase.OnScreenFixed(ESCREEN.SETUP, False)
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Monitor.Exit(Me.m_OALeftInterrupt)
                Monitor.Exit(Me.m_OARightInterrupt)
                Monitor.Exit(Me.m_OBLeftInterrupt)
                Monitor.Exit(Me.m_OBRightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub

    Private Sub BtnApplyAlignment_Click(sender As Object, e As EventArgs) Handles BtnApplyAlignment.Click
        Try
            CEnvironment.It.MaxRetry = Me.NudMaxRetry.Value
            CEnvironment.It.Commit()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub

    Public Sub ROI_Change()
        Try
            If ((CTool.It.OStageA Is Nothing) Or
                 (CTool.It.OStageA.OLeft Is Nothing) Or
                 (CTool.It.OStageA.OLeft.ORecipe Is Nothing) Or
                 (CTool.It.OStageA.ORight Is Nothing) Or
                 (CTool.It.OStageA.ORight.ORecipe Is Nothing) Or
                 (CTool.It.OStageB Is Nothing) Or
                 (CTool.It.OStageB.OLeft Is Nothing) Or
                 (CTool.It.OStageB.OLeft.ORecipe Is Nothing) Or
                 (CTool.It.OStageB.ORight Is Nothing) Or
                 (CTool.It.OStageB.ORight.ORecipe Is Nothing)
                ) Then
                Return
            End If
            ' 기존에 지정된 ROI 그래픽 객체 있으면 날려버림
            If (Not Me.CdpALeft.InteractiveGraphics.FindItem("ROI_A", Display.CogDisplayZOrderConstants.Front) = -1) Then
                Me.CdpALeft.InteractiveGraphics.Remove("ROI_A")
            End If
            If (Not Me.CdpARight.InteractiveGraphics.FindItem("ROI_B", Display.CogDisplayZOrderConstants.Front) = -1) Then
                Me.CdpARight.InteractiveGraphics.Remove("ROI_B")
            End If

            If (Not Me.CdpBLeft.InteractiveGraphics.FindItem("ROI_C", Display.CogDisplayZOrderConstants.Front) = -1) Then
                Me.CdpBLeft.InteractiveGraphics.Remove("ROI_C")
            End If

            If (Not Me.CdpBRight.InteractiveGraphics.FindItem("ROI_D", Display.CogDisplayZOrderConstants.Front) = -1) Then
                Me.CdpBRight.InteractiveGraphics.Remove("ROI_D")
            End If
            ' 레시피에서 ROI CogRectangle 아닌 경우 에러 메세지
            '1
            If (Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Left Mark1) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Right Mark1) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Left Mark1) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Right Mark1) Type as CogRectangle")
                Return
            End If
            '2
            If (Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool2.SearchRegion Is Nothing AndAlso
               Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool2.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Left Mark2) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageA.ORight.ORecipe.OMarkTool2.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageA.ORight.ORecipe.OMarkTool2.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Right Mark2) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool2.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool2.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Left Mark2) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.ORight.ORecipe.OMarkTool2.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.ORight.ORecipe.OMarkTool2.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Right Mark2) Type as CogRectangle")
                Return
            End If
            '3
            If (Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool3.SearchRegion Is Nothing AndAlso
               Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool3.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Left Mark3) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageA.ORight.ORecipe.OMarkTool3.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageA.ORight.ORecipe.OMarkTool3.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Right Mark3) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool3.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool3.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Left Mark3) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.ORight.ORecipe.OMarkTool3.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.ORight.ORecipe.OMarkTool3.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Right Mark3) Type as CogRectangle")
                Return
            End If
            '4
            If (Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool4.SearchRegion Is Nothing AndAlso
               Not CTool.It.OStageA.OLeft.ORecipe.OMarkTool4.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Left Mark4) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageA.ORight.ORecipe.OMarkTool4.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageA.ORight.ORecipe.OMarkTool4.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage A Right Mark4) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool4.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.OLeft.ORecipe.OMarkTool4.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Left Mark4) Type as CogRectangle")
                Return
            End If
            If (Not CTool.It.OStageB.ORight.ORecipe.OMarkTool4.SearchRegion Is Nothing AndAlso
                Not CTool.It.OStageB.ORight.ORecipe.OMarkTool4.SearchRegion.GetType().ToString() = "Cognex.VisionPro.CogRectangle") Then
                MessageBox.Show("Please Assign a ROI (Stage B Right Mark4) Type as CogRectangle")
                Return
            End If

            '# ####################################################################################
            '# Align 용 ROI 지정
            '# ####################################################################################
            ' A LEFT ROI
            If Not CType(CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle) Is Nothing Then
                Me.m_OROIAlignALeft = New CogRectangle()
                Me.m_OROIAlignALeft.X = CType(CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).X
                Me.m_OROIAlignALeft.Y = CType(CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Y
                Me.m_OROIAlignALeft.Width = CType(CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Width
                Me.m_OROIAlignALeft.Height = CType(CTool.It.OStageA.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Height
                Me.m_OROIAlignALeft.Color = CogColorConstants.Purple
                Me.m_OROIAlignALeft.SelectedLineStyle = CogGraphicLineStyleConstants.DashDotDot
                Me.m_OROIAlignALeft.Interactive = False
                Me.m_OROIAlignALeft.GraphicDOFEnable = CogRectangleDOFConstants.None
                Me.CdpALeft.InteractiveGraphics.Add(Me.m_OROIAlignALeft, "ROI_A", True)
            End If
            ' A RIGHT ROI
            If Not CType(CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle) Is Nothing Then
                Me.m_OROIAlignARight = New CogRectangle()
                Me.m_OROIAlignARight.X = CType(CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).X
                Me.m_OROIAlignARight.Y = CType(CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Y
                Me.m_OROIAlignARight.Width = CType(CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Width
                Me.m_OROIAlignARight.Height = CType(CTool.It.OStageA.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Height
                Me.m_OROIAlignARight.Color = CogColorConstants.Purple
                Me.m_OROIAlignARight.SelectedLineStyle = CogGraphicLineStyleConstants.DashDotDot
                Me.m_OROIAlignARight.Interactive = False
                Me.m_OROIAlignARight.GraphicDOFEnable = CogRectangleDOFConstants.None
                Me.CdpARight.InteractiveGraphics.Add(Me.m_OROIAlignARight, "ROI_B", True)
            End If
            ' B LEFT ROI
            If Not CType(CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle) Is Nothing Then
                Me.m_OROIAlignBLeft = New CogRectangle()
                Me.m_OROIAlignBLeft.X = CType(CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).X
                Me.m_OROIAlignBLeft.Y = CType(CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Y
                Me.m_OROIAlignBLeft.Width = CType(CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Width
                Me.m_OROIAlignBLeft.Height = CType(CTool.It.OStageB.OLeft.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Height
                Me.m_OROIAlignBLeft.Color = CogColorConstants.Purple
                Me.m_OROIAlignBLeft.SelectedLineStyle = CogGraphicLineStyleConstants.DashDotDot
                Me.m_OROIAlignBLeft.Interactive = False
                Me.m_OROIAlignBLeft.GraphicDOFEnable = CogRectangleDOFConstants.None
                Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OROIAlignBLeft, "ROI_C", True)
            End If
            ' B RIGHT ROI
            If Not CType(CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle) Is Nothing Then
                Me.m_OROIAlignBRight = New CogRectangle()
                Me.m_OROIAlignBRight.X = CType(CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).X
                Me.m_OROIAlignBRight.Y = CType(CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Y
                Me.m_OROIAlignBRight.Width = CType(CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Width
                Me.m_OROIAlignBRight.Height = CType(CTool.It.OStageB.ORight.ORecipe.OMarkTool1.SearchRegion, CogRectangle).Height
                Me.m_OROIAlignBRight.Color = CogColorConstants.Purple
                Me.m_OROIAlignBRight.SelectedLineStyle = CogGraphicLineStyleConstants.DashDotDot
                Me.m_OROIAlignBRight.Interactive = False
                Me.m_OROIAlignBRight.GraphicDOFEnable = CogRectangleDOFConstants.None
                Me.CdpBRight.InteractiveGraphics.Add(Me.m_OROIAlignBRight, "ROI_D", True)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

End Class
