Imports Cognex.VisionPro
Imports System.IO
Imports System.Threading
Imports Jhjo.Common


Public Class UcAlignment
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
    Private m_OTextALeftVisionLine As CogGraphicLabel = Nothing
    Private m_OTextARightVisionLine As CogGraphicLabel = Nothing
    Private m_OTextBLeftVisionLine As CogGraphicLabel = Nothing
    Private m_OTextBRightVisionLine As CogGraphicLabel = Nothing

    Private m_OLineALeftWheel As CogLine = Nothing
    Private m_OLineARightWheel As CogLine = Nothing
    Private m_OLineBLeftWheel As CogLine = Nothing
    Private m_OLineBRightWheel As CogLine = Nothing
    Private m_OTextALeftWheelLine As CogGraphicLabel = Nothing
    Private m_OTextARightWheelLine As CogGraphicLabel = Nothing
    Private m_OTextBLeftWheelLine As CogGraphicLabel = Nothing
    Private m_OTextBRightWheelLine As CogGraphicLabel = Nothing

    Private m_OTargetALeft As CogPointMarker = Nothing
    Private m_OTargetARight As CogPointMarker = Nothing
    Private m_OTargetBLeft As CogPointMarker = Nothing
    Private m_OTargetBRight As CogPointMarker = Nothing
    ' jht 검사 중 ROI 표시
    Private m_OROIAlignALeft As CogRectangle = Nothing
    Private m_OROIAlignARight As CogRectangle = Nothing
    Private m_OROIAlignBLeft As CogRectangle = Nothing
    Private m_OROIAlignBRight As CogRectangle = Nothing

    Private m_OAManualAlignmentLeftMarker As CogPointMarker = Nothing
    Private m_OAManualAlignmentRightMarker As CogPointMarker = Nothing
    Private m_OBManualAlignmentLeftMarker As CogPointMarker = Nothing
    Private m_OBManualAlignmentRightMarker As CogPointMarker = Nothing

    Private m_OAManualAlignmentLeftMarker_PartialLeft As CogPointMarker = Nothing
    Private m_OAManualAlignmentRightMarker_PartialLeft As CogPointMarker = Nothing
    Private m_OBManualAlignmentLeftMarker_PartialLeft As CogPointMarker = Nothing
    Private m_OBManualAlignmentRightMarker_PartialLeft As CogPointMarker = Nothing

    Private m_OAManualAlignmentLeftMarker_PartialRight As CogPointMarker = Nothing
    Private m_OAManualAlignmentRightMarker_PartialRight As CogPointMarker = Nothing
    Private m_OBManualAlignmentLeftMarker_PartialRight As CogPointMarker = Nothing
    Private m_OBManualAlignmentRightMarker_PartialRight As CogPointMarker = Nothing

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

    Private m_EScreenMode As ESCREEN_MODE = ESCREEN_MODE.ORIGINAL
    Private m_OALeftInterrupt As Object = Nothing
    Private m_OARightInterrupt As Object = Nothing
    Private m_OBLeftInterrupt As Object = Nothing
    Private m_OBRightInterrupt As Object = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property EScreenMode() As ESCREEN_MODE
        Get
            Return Me.m_EScreenMode
        End Get
    End Property
#End Region


#Region "DELEGATE & EVENT"
    ' jht 시작 버튼 눌렀을 경우 변경 UI
    Public Delegate Sub ChangeStartHandler()
    Public Event ChangeStart As ChangeStartHandler
    ' jht 정지 버튼 눌렀을 경우 변경 UI
    Public Delegate Sub ChangeStopHandler()
    Public Event ChangeStop As ChangeStopHandler

    Public Delegate Sub RequestFooterVisibleHandler(ByVal EScreenMode As ESCREEN_MODE)
    Public Event RequestFooterVisible As RequestFooterVisibleHandler
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()

        Try
            Me.m_OLineALeftX = New CogLine()
            Me.m_OLineALeftX.X = CAcquisitionManager.It.OALeft.I32Width / 2D
            Me.m_OLineALeftX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineALeftX.Color = CogColorConstants.Yellow
            Me.m_OLineALeftX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineALeftX.Interactive = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OLineALeftX, "LineX", True)
            Me.m_OLineALeftY = New CogLine()
            Me.m_OLineALeftY.Y = CAcquisitionManager.It.OALeft.I32Height / 2D
            Me.m_OLineALeftY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineALeftY.Color = CogColorConstants.Yellow
            Me.m_OLineALeftY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineALeftY.Interactive = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OLineALeftY, "LineY", True)
            Me.m_OLineARightX = New CogLine()
            Me.m_OLineARightX.X = CAcquisitionManager.It.OARight.I32Width / 2D
            Me.m_OLineARightX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineARightX.Color = CogColorConstants.Yellow
            Me.m_OLineARightX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineARightX.Interactive = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OLineARightX, "LineX", True)
            Me.m_OLineARightY = New CogLine()
            Me.m_OLineARightY.Y = CAcquisitionManager.It.OARight.I32Height / 2D
            Me.m_OLineARightY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineARightY.Color = CogColorConstants.Yellow
            Me.m_OLineARightY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineARightY.Interactive = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OLineARightY, "LineY", True)
            Me.m_OLineBLeftX = New CogLine()
            Me.m_OLineBLeftX.X = CAcquisitionManager.It.OBLeft.I32Width / 2D
            Me.m_OLineBLeftX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineBLeftX.Color = CogColorConstants.Yellow
            Me.m_OLineBLeftX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineBLeftX.Interactive = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OLineBLeftX, "LineX", True)
            Me.m_OLineBLeftY = New CogLine()
            Me.m_OLineBLeftY.Y = CAcquisitionManager.It.OBLeft.I32Height / 2D
            Me.m_OLineBLeftY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineBLeftY.Color = CogColorConstants.Yellow
            Me.m_OLineBLeftY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineBLeftY.Interactive = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OLineBLeftY, "LineY", True)
            Me.m_OLineBRightX = New CogLine()
            Me.m_OLineBRightX.X = CAcquisitionManager.It.OBRight.I32Width / 2D
            Me.m_OLineBRightX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineBRightX.Color = CogColorConstants.Yellow
            Me.m_OLineBRightX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineBRightX.Interactive = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OLineBRightX, "LineX", True)
            Me.m_OLineBRightY = New CogLine()
            Me.m_OLineBRightY.Y = CAcquisitionManager.It.OBRight.I32Height / 2D
            Me.m_OLineBRightY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLineBRightY.Color = CogColorConstants.Yellow
            Me.m_OLineBRightY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLineBRightY.Interactive = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OLineBRightY, "LineY", True)
            Me.m_OTextALeftVisionLine = New CogGraphicLabel()
            Me.m_OTextALeftVisionLine.Text = "VL"
            Me.m_OTextALeftVisionLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextALeftVisionLine.X = Me.m_OLineALeftX.X + 50
            Me.m_OTextALeftVisionLine.Y = 30
            Me.m_OTextALeftVisionLine.Color = CogColorConstants.Yellow
            Me.m_OTextALeftVisionLine.Interactive = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OTextALeftVisionLine, "VisionText", True)
            Me.m_OTextARightVisionLine = New CogGraphicLabel()
            Me.m_OTextARightVisionLine.Text = "VL"
            Me.m_OTextARightVisionLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextARightVisionLine.X = Me.m_OLineARightX.X + 50
            Me.m_OTextARightVisionLine.Y = 30
            Me.m_OTextARightVisionLine.Color = CogColorConstants.Yellow
            Me.m_OTextARightVisionLine.Interactive = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OTextARightVisionLine, "VisionText", True)
            Me.m_OTextBLeftVisionLine = New CogGraphicLabel()
            Me.m_OTextBLeftVisionLine.Text = "VL"
            Me.m_OTextBLeftVisionLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextBLeftVisionLine.X = Me.m_OLineBLeftX.X + 50
            Me.m_OTextBLeftVisionLine.Y = 30
            Me.m_OTextBLeftVisionLine.Color = CogColorConstants.Yellow
            Me.m_OTextBLeftVisionLine.Interactive = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OTextBLeftVisionLine, "VisionText", True)
            Me.m_OTextBRightVisionLine = New CogGraphicLabel()
            Me.m_OTextBRightVisionLine.Text = "VL"
            Me.m_OTextBRightVisionLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextBRightVisionLine.X = Me.m_OLineBRightX.X + 50
            Me.m_OTextBRightVisionLine.Y = 30
            Me.m_OTextBRightVisionLine.Color = CogColorConstants.Yellow
            Me.m_OTextBRightVisionLine.Interactive = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OTextBRightVisionLine, "VisionText", True)

            Me.m_OLineALeftWheel = New CogLine()
            Me.m_OLineALeftWheel.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineALeftWheel.Color = CogColorConstants.Red
            Me.m_OLineALeftWheel.Visible = False
            Me.m_OLineALeftWheel.Interactive = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OLineALeftWheel, "WheelLine", True)
            Me.m_OLineARightWheel = New CogLine()
            Me.m_OLineARightWheel.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineARightWheel.Color = CogColorConstants.Red
            Me.m_OLineARightWheel.Visible = False
            Me.m_OLineARightWheel.Interactive = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OLineARightWheel, "WheelLine", True)
            Me.m_OLineBLeftWheel = New CogLine()
            Me.m_OLineBLeftWheel.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineBLeftWheel.Color = CogColorConstants.Red
            Me.m_OLineBLeftWheel.Visible = False
            Me.m_OLineBLeftWheel.Interactive = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OLineBLeftWheel, "WheelLine", True)
            Me.m_OLineBRightWheel = New CogLine()
            Me.m_OLineBRightWheel.Rotation = CogMisc.DegToRad(90)
            Me.m_OLineBRightWheel.Color = CogColorConstants.Red
            Me.m_OLineBRightWheel.Visible = False
            Me.m_OLineBRightWheel.Interactive = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OLineBRightWheel, "WheelLine", True)
            Me.m_OTextALeftWheelLine = New CogGraphicLabel()
            Me.m_OTextALeftWheelLine.Text = "CL"
            Me.m_OTextALeftWheelLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextALeftWheelLine.Y = 30
            Me.m_OTextALeftWheelLine.Color = CogColorConstants.Red
            Me.m_OTextALeftWheelLine.Visible = False
            Me.m_OTextALeftWheelLine.Interactive = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OTextALeftWheelLine, "WheelText", True)
            Me.m_OTextARightWheelLine = New CogGraphicLabel()
            Me.m_OTextARightWheelLine.Text = "CL"
            Me.m_OTextARightWheelLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextARightWheelLine.Y = 30
            Me.m_OTextARightWheelLine.Color = CogColorConstants.Red
            Me.m_OTextARightWheelLine.Visible = False
            Me.m_OTextARightWheelLine.Interactive = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OTextARightWheelLine, "WheelText", True)
            Me.m_OTextBLeftWheelLine = New CogGraphicLabel()
            Me.m_OTextBLeftWheelLine.Text = "CL"
            Me.m_OTextBLeftWheelLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextBLeftWheelLine.Y = 30
            Me.m_OTextBLeftWheelLine.Color = CogColorConstants.Red
            Me.m_OTextBLeftWheelLine.Visible = False
            Me.m_OTextBLeftWheelLine.Interactive = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OTextBLeftWheelLine, "WheelText", True)
            Me.m_OTextBRightWheelLine = New CogGraphicLabel()
            Me.m_OTextBRightWheelLine.Text = "CL"
            Me.m_OTextBRightWheelLine.Font = New Font("Microsoft Sans Serif", 10.0F)
            Me.m_OTextBRightWheelLine.Y = 30
            Me.m_OTextBRightWheelLine.Color = CogColorConstants.Red
            Me.m_OTextBRightWheelLine.Visible = False
            Me.m_OTextBRightWheelLine.Interactive = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OTextBRightWheelLine, "WheelText", True)

            Me.m_OTargetALeft = New CogPointMarker()
            Me.m_OTargetALeft.X = CAcquisitionManager.It.OALeft.I32Width / 2D
            Me.m_OTargetALeft.Y = CAcquisitionManager.It.OALeft.I32Height / 2D
            Me.m_OTargetALeft.Color = CogColorConstants.Green
            Me.m_OTargetALeft.SizeInScreenPixels = 100
            Me.m_OTargetALeft.Interactive = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OTargetALeft, "Target", True)
            Me.m_OTargetARight = New CogPointMarker()
            Me.m_OTargetARight.X = CAcquisitionManager.It.OARight.I32Width / 2D
            Me.m_OTargetARight.Y = CAcquisitionManager.It.OARight.I32Height / 2D
            Me.m_OTargetARight.Color = CogColorConstants.Green
            Me.m_OTargetARight.SizeInScreenPixels = 100
            Me.m_OTargetARight.Interactive = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OTargetARight, "Target", True)
            Me.m_OTargetBLeft = New CogPointMarker()
            Me.m_OTargetBLeft.X = CAcquisitionManager.It.OBLeft.I32Width / 2D
            Me.m_OTargetBLeft.Y = CAcquisitionManager.It.OBLeft.I32Height / 2D
            Me.m_OTargetBLeft.Color = CogColorConstants.Green
            Me.m_OTargetBLeft.SizeInScreenPixels = 100
            Me.m_OTargetBLeft.Interactive = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OTargetBLeft, "Target", True)
            Me.m_OTargetBRight = New CogPointMarker()
            Me.m_OTargetBRight.X = CAcquisitionManager.It.OBRight.I32Width / 2D
            Me.m_OTargetBRight.Y = CAcquisitionManager.It.OBRight.I32Height / 2D
            Me.m_OTargetBRight.Color = CogColorConstants.Green
            Me.m_OTargetBRight.SizeInScreenPixels = 100
            Me.m_OTargetBRight.Interactive = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OTargetBRight, "Target", True)

            Me.m_OAManualAlignmentLeftMarker = New CogPointMarker()
            Me.m_OAManualAlignmentLeftMarker.X = 100
            Me.m_OAManualAlignmentLeftMarker.Y = 100
            Me.m_OAManualAlignmentLeftMarker.Color = CogColorConstants.Orange
            Me.m_OAManualAlignmentLeftMarker.SelectedColor = CogColorConstants.Orange
            Me.m_OAManualAlignmentLeftMarker.DragColor = CogColorConstants.Orange
            Me.m_OAManualAlignmentLeftMarker.SizeInScreenPixels = 100
            Me.m_OAManualAlignmentLeftMarker.Interactive = True
            Me.m_OAManualAlignmentLeftMarker.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OAManualAlignmentLeftMarker.Visible = False
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OAManualAlignmentLeftMarker, "A Left Mark Position", True)
            Me.m_OAManualAlignmentRightMarker = New CogPointMarker()
            Me.m_OAManualAlignmentRightMarker.X = 100
            Me.m_OAManualAlignmentRightMarker.Y = 100
            Me.m_OAManualAlignmentRightMarker.Color = CogColorConstants.Orange
            Me.m_OAManualAlignmentRightMarker.SelectedColor = CogColorConstants.Orange
            Me.m_OAManualAlignmentRightMarker.DragColor = CogColorConstants.Orange
            Me.m_OAManualAlignmentRightMarker.SizeInScreenPixels = 100
            Me.m_OAManualAlignmentRightMarker.Interactive = True
            Me.m_OAManualAlignmentRightMarker.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OAManualAlignmentRightMarker.Visible = False
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OAManualAlignmentRightMarker, "A Right Mark Position", True)
            Me.m_OBManualAlignmentLeftMarker = New CogPointMarker()
            Me.m_OBManualAlignmentLeftMarker.X = 100
            Me.m_OBManualAlignmentLeftMarker.Y = 100
            Me.m_OBManualAlignmentLeftMarker.Color = CogColorConstants.Orange
            Me.m_OBManualAlignmentLeftMarker.SelectedColor = CogColorConstants.Orange
            Me.m_OBManualAlignmentLeftMarker.DragColor = CogColorConstants.Orange
            Me.m_OBManualAlignmentLeftMarker.SizeInScreenPixels = 100
            Me.m_OBManualAlignmentLeftMarker.Interactive = True
            Me.m_OBManualAlignmentLeftMarker.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OBManualAlignmentLeftMarker.Visible = False
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OBManualAlignmentLeftMarker, "B Left Mark Position", True)
            Me.m_OBManualAlignmentRightMarker = New CogPointMarker()
            Me.m_OBManualAlignmentRightMarker.X = 100
            Me.m_OBManualAlignmentRightMarker.Y = 100
            Me.m_OBManualAlignmentRightMarker.Color = CogColorConstants.Orange
            Me.m_OBManualAlignmentRightMarker.SelectedColor = CogColorConstants.Orange
            Me.m_OBManualAlignmentRightMarker.DragColor = CogColorConstants.Orange
            Me.m_OBManualAlignmentRightMarker.SizeInScreenPixels = 100
            Me.m_OBManualAlignmentRightMarker.Interactive = True
            Me.m_OBManualAlignmentRightMarker.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OBManualAlignmentRightMarker.Visible = False
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OBManualAlignmentRightMarker, "B Right Mark Position", True)

            Me.m_OAManualAlignmentLeftMarker_PartialLeft = New CogPointMarker()
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.X = 100
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Y = 100
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Color = CogColorConstants.Purple
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.SelectedColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.DragColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.SizeInScreenPixels = 100
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Interactive = True
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Visible = False
            Me.m_OAManualAlignmentLeftMarker_PartialLeft.TipText = "Upper"
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OAManualAlignmentLeftMarker_PartialLeft, "A Left(Partial Left) Mark Position", True)
            Me.m_OAManualAlignmentRightMarker_PartialLeft = New CogPointMarker()
            Me.m_OAManualAlignmentRightMarker_PartialLeft.X = 100
            Me.m_OAManualAlignmentRightMarker_PartialLeft.Y = 100
            Me.m_OAManualAlignmentRightMarker_PartialLeft.Color = CogColorConstants.Purple
            Me.m_OAManualAlignmentRightMarker_PartialLeft.SelectedColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentRightMarker_PartialLeft.DragColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentRightMarker_PartialLeft.SizeInScreenPixels = 100
            Me.m_OAManualAlignmentRightMarker_PartialLeft.Interactive = True
            Me.m_OAManualAlignmentRightMarker_PartialLeft.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OAManualAlignmentRightMarker_PartialLeft.Visible = False
            Me.m_OAManualAlignmentRightMarker_PartialLeft.TipText = "Upper"
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OAManualAlignmentRightMarker_PartialLeft, "A Right(Partial Left) Mark Position", True)
            Me.m_OBManualAlignmentLeftMarker_PartialLeft = New CogPointMarker()
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.X = 100
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Y = 100
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Color = CogColorConstants.Purple
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.SelectedColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.DragColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.SizeInScreenPixels = 100
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Interactive = True
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Visible = False
            Me.m_OBManualAlignmentLeftMarker_PartialLeft.TipText = "Upper"
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OBManualAlignmentLeftMarker_PartialLeft, "B Left(Partial Left) Mark Position", True)
            Me.m_OBManualAlignmentRightMarker_PartialLeft = New CogPointMarker()
            Me.m_OBManualAlignmentRightMarker_PartialLeft.X = 100
            Me.m_OBManualAlignmentRightMarker_PartialLeft.Y = 100
            Me.m_OBManualAlignmentRightMarker_PartialLeft.Color = CogColorConstants.Purple
            Me.m_OBManualAlignmentRightMarker_PartialLeft.SelectedColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentRightMarker_PartialLeft.DragColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentRightMarker_PartialLeft.SizeInScreenPixels = 100
            Me.m_OBManualAlignmentRightMarker_PartialLeft.Interactive = True
            Me.m_OBManualAlignmentRightMarker_PartialLeft.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OBManualAlignmentRightMarker_PartialLeft.Visible = False
            Me.m_OBManualAlignmentRightMarker_PartialLeft.TipText = "Upper"
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OBManualAlignmentRightMarker_PartialLeft, "B Right(Partial Left) Mark Position", True)

            Me.m_OAManualAlignmentLeftMarker_PartialRight = New CogPointMarker()
            Me.m_OAManualAlignmentLeftMarker_PartialRight.X = 100
            Me.m_OAManualAlignmentLeftMarker_PartialRight.Y = 100
            Me.m_OAManualAlignmentLeftMarker_PartialRight.Color = CogColorConstants.Purple
            Me.m_OAManualAlignmentLeftMarker_PartialRight.SelectedColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentLeftMarker_PartialRight.DragColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentLeftMarker_PartialRight.SizeInScreenPixels = 100
            Me.m_OAManualAlignmentLeftMarker_PartialRight.Interactive = True
            Me.m_OAManualAlignmentLeftMarker_PartialRight.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OAManualAlignmentLeftMarker_PartialRight.Visible = False
            Me.m_OAManualAlignmentLeftMarker_PartialRight.TipText = "Below"
            Me.CdpALeft.InteractiveGraphics.Add(Me.m_OAManualAlignmentLeftMarker_PartialRight, "A Left(Partial Right) Mark Position", True)
            Me.m_OAManualAlignmentRightMarker_PartialRight = New CogPointMarker()
            Me.m_OAManualAlignmentRightMarker_PartialRight.X = 100
            Me.m_OAManualAlignmentRightMarker_PartialRight.Y = 100
            Me.m_OAManualAlignmentRightMarker_PartialRight.Color = CogColorConstants.Purple
            Me.m_OAManualAlignmentRightMarker_PartialRight.SelectedColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentRightMarker_PartialRight.DragColor = CogColorConstants.Purple
            Me.m_OAManualAlignmentRightMarker_PartialRight.SizeInScreenPixels = 100
            Me.m_OAManualAlignmentRightMarker_PartialRight.Interactive = True
            Me.m_OAManualAlignmentRightMarker_PartialRight.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OAManualAlignmentRightMarker_PartialRight.Visible = False
            Me.m_OAManualAlignmentRightMarker_PartialRight.TipText = "Below"
            Me.CdpARight.InteractiveGraphics.Add(Me.m_OAManualAlignmentRightMarker_PartialRight, "A Right(Partial Right) Mark Position", True)
            Me.m_OBManualAlignmentLeftMarker_PartialRight = New CogPointMarker()
            Me.m_OBManualAlignmentLeftMarker_PartialRight.X = 100
            Me.m_OBManualAlignmentLeftMarker_PartialRight.Y = 100
            Me.m_OBManualAlignmentLeftMarker_PartialRight.Color = CogColorConstants.Purple
            Me.m_OBManualAlignmentLeftMarker_PartialRight.SelectedColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentLeftMarker_PartialRight.DragColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentLeftMarker_PartialRight.SizeInScreenPixels = 100
            Me.m_OBManualAlignmentLeftMarker_PartialRight.Interactive = True
            Me.m_OBManualAlignmentLeftMarker_PartialRight.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OBManualAlignmentLeftMarker_PartialRight.Visible = False
            Me.m_OBManualAlignmentLeftMarker_PartialRight.TipText = "Below"
            Me.CdpBLeft.InteractiveGraphics.Add(Me.m_OBManualAlignmentLeftMarker_PartialRight, "B Left(Partial Right) Mark Position", True)
            Me.m_OBManualAlignmentRightMarker_PartialRight = New CogPointMarker()
            Me.m_OBManualAlignmentRightMarker_PartialRight.X = 100
            Me.m_OBManualAlignmentRightMarker_PartialRight.Y = 100
            Me.m_OBManualAlignmentRightMarker_PartialRight.Color = CogColorConstants.Purple
            Me.m_OBManualAlignmentRightMarker_PartialRight.SelectedColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentRightMarker_PartialRight.DragColor = CogColorConstants.Purple
            Me.m_OBManualAlignmentRightMarker_PartialRight.SizeInScreenPixels = 100
            Me.m_OBManualAlignmentRightMarker_PartialRight.Interactive = True
            Me.m_OBManualAlignmentRightMarker_PartialRight.GraphicDOFEnable = CogPointMarkerDOFConstants.Position
            Me.m_OBManualAlignmentRightMarker_PartialRight.Visible = False
            Me.m_OBManualAlignmentRightMarker_PartialRight.TipText = "Below"
            Me.CdpBRight.InteractiveGraphics.Add(Me.m_OBManualAlignmentRightMarker_PartialRight, "B Right(Partial Right) Mark Position", True)


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

            Me.BtnStart.BackColor = Color.SteelBlue
            Me.BtnStop.BackColor = SystemColors.Control
            Me.BtnAManualShow.BackColor = SystemColors.Control
            Me.BtnAManualRun.BackColor = SystemColors.Control
            Me.BtnBManualShow.BackColor = SystemColors.Control
            Me.BtnBManualRun.BackColor = SystemColors.Control
            Me.BtnStart.Enabled = True
            Me.BtnStop.Enabled = False
            Me.BtnAManualShow.Enabled = False
            Me.BtnAManualRun.Enabled = False
            Me.BtnBManualShow.Enabled = False
            Me.BtnBManualRun.Enabled = False

            Me.m_OALeftInterrupt = New Object()
            Me.m_OARightInterrupt = New Object()
            Me.m_OBLeftInterrupt = New Object()
            Me.m_OBRightInterrupt = New Object()

            ' jht Max Retry
            Me.LblMaxRetries.Text = "Max Retries = " + CEnvironment.It.MaxRetry.ToString()
            ' jht Camera Gain & Exposure Time Set
            CAcquisitionManager.It.OALeft.I32Gain = CEnvironment.It.Cam1Gain
            CAcquisitionManager.It.OALeft.I32ExposureTime = CEnvironment.It.Cam1Exp
            CAcquisitionManager.It.OARight.I32Gain = CEnvironment.It.Cam2Gain
            CAcquisitionManager.It.OARight.I32ExposureTime = CEnvironment.It.Cam2Exp
            CAcquisitionManager.It.OBLeft.I32Gain = CEnvironment.It.Cam3Gain
            CAcquisitionManager.It.OBLeft.I32ExposureTime = CEnvironment.It.Cam3Exp
            CAcquisitionManager.It.OBRight.I32Gain = CEnvironment.It.Cam4Gain
            CAcquisitionManager.It.OBRight.I32ExposureTime = CEnvironment.It.Cam4Exp
        Catch ex As Exception
            CError.Throw(ex)
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
                Me.m_OROIAlignALeft.Color = CogColorConstants.Yellow
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
                Me.m_OROIAlignARight.Color = CogColorConstants.Yellow
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
                Me.m_OROIAlignBLeft.Color = CogColorConstants.Yellow
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
                Me.m_OROIAlignBRight.Color = CogColorConstants.Yellow
                Me.m_OROIAlignBRight.SelectedLineStyle = CogGraphicLineStyleConstants.DashDotDot
                Me.m_OROIAlignBRight.Interactive = False
                Me.m_OROIAlignBRight.GraphicDOFEnable = CogRectangleDOFConstants.None
                Me.CdpBRight.InteractiveGraphics.Add(Me.m_OROIAlignBRight, "ROI_D", True)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStart.Click
        Try
            ' jht 시작 시 UI 변경
            RaiseEvent ChangeStart()

            Dim I32ID As Integer = CMotionController.It.OPLC.GetMotionRecipeID()

            If ((CTool.It.ORecipe Is Nothing) OrElse (Not I32ID = CTool.It.ORecipe.I32ID)) Then
                For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                    If (Not _Item.I32ID = I32ID) Then Continue For

                    CTool.It.ORecipe = New CRecipe(_Item)
                    CMotionController.It.OPLC.SetVisionRecipeID(I32ID)
                    Exit For
                Next
            End If

            If (CTool.It.OStageA.IsBusy() = False) AndAlso (CTool.It.OStageB.IsBusy() = False) Then
                Return
            End If


            CAcquisitionManager.It.OALeft.Start()
            CAcquisitionManager.It.OARight.Start()
            CAcquisitionManager.It.OBLeft.Start()
            CAcquisitionManager.It.OBRight.Start()

            CTool.It.OStageA.BeginInspection()
            CTool.It.OStageB.BeginInspection()

            ' jht 시뮬레이션 PLC 검사 시작 신호
            If 1 = CEnvironment.It.SimulationMode() Then
                CMotionController.It.OPCI.BeginSimulation()
            End If
            ' jht ROI 지정
            ROI_Change()

            Me.BtnStart.BackColor = SystemColors.Control
            Me.BtnStop.BackColor = Color.SteelBlue
            Me.BtnAManualShow.BackColor = Color.SteelBlue
            Me.BtnAManualRun.BackColor = SystemColors.Control
            Me.BtnBManualShow.BackColor = Color.SteelBlue
            Me.BtnBManualRun.BackColor = SystemColors.Control
            Me.BtnStart.Enabled = False
            Me.BtnStop.Enabled = True
            Me.BtnAManualShow.Enabled = True
            Me.BtnAManualRun.Enabled = False
            Me.BtnBManualShow.Enabled = True
            Me.BtnBManualRun.Enabled = False

            MyBase.OnScreenFixed(ESCREEN.ALIGNMENT, True)
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

                ' jht 시뮬레이션 PLC 검사 종료 신호
                If 1 = CEnvironment.It.SimulationMode() Then
                    CMotionController.It.OPCI.EndSimulation()
                End If
                ' jht 정지 시 UI 변경
                RaiseEvent ChangeStop()

                CTool.It.OStageA.EndInspection()
                CTool.It.OStageB.EndInspection()

                CAcquisitionManager.It.OALeft.Stop()
                CAcquisitionManager.It.OARight.Stop()
                CAcquisitionManager.It.OBLeft.Stop()
                CAcquisitionManager.It.OBRight.Stop()

                Me.BtnStart.BackColor = Color.SteelBlue
                Me.BtnStop.BackColor = SystemColors.Control
                Me.BtnAManualShow.Text = "#1 Man. On"
                Me.BtnAManualShow.BackColor = SystemColors.Control
                Me.BtnAManualRun.BackColor = SystemColors.Control
                Me.BtnBManualShow.Text = "#2 Man. On"
                Me.BtnBManualShow.BackColor = SystemColors.Control
                Me.BtnBManualRun.BackColor = SystemColors.Control

                Me.BtnStart.Enabled = True
                Me.BtnStop.Enabled = False
                Me.BtnAManualShow.Enabled = False
                Me.BtnAManualRun.Enabled = False
                Me.BtnBManualShow.Enabled = False
                Me.BtnBManualRun.Enabled = False

                Me.m_OAManualAlignmentLeftMarker.Visible = False
                Me.m_OAManualAlignmentRightMarker.Visible = False
                Me.m_OBManualAlignmentLeftMarker.Visible = False
                Me.m_OBManualAlignmentRightMarker.Visible = False

                Me.m_OAManualAlignmentLeftMarker_PartialLeft.Visible = False
                Me.m_OAManualAlignmentRightMarker_PartialLeft.Visible = False
                Me.m_OBManualAlignmentLeftMarker_PartialLeft.Visible = False
                Me.m_OBManualAlignmentRightMarker_PartialLeft.Visible = False

                Me.m_OAManualAlignmentLeftMarker_PartialRight.Visible = False
                Me.m_OAManualAlignmentRightMarker_PartialRight.Visible = False
                Me.m_OBManualAlignmentLeftMarker_PartialRight.Visible = False
                Me.m_OBManualAlignmentRightMarker_PartialRight.Visible = False

                MyBase.OnScreenFixed(ESCREEN.ALIGNMENT, False)
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


    Private Sub BtnWheel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWheel.Click
        Try
            Try
                Monitor.Enter(Me.m_OALeftInterrupt)
                Monitor.Enter(Me.m_OARightInterrupt)
                Monitor.Enter(Me.m_OBLeftInterrupt)
                Monitor.Enter(Me.m_OBRightInterrupt)

                If (Me.BtnWheel.Text = "CL ON") Then
                    Me.BtnWheel.Text = "CL OFF"
                    Me.m_OLineALeftWheel.Visible = True
                    Me.m_OTextALeftWheelLine.Visible = True
                    Me.m_OLineARightWheel.Visible = True
                    Me.m_OTextARightWheelLine.Visible = True
                    Me.m_OLineBLeftWheel.Visible = True
                    Me.m_OTextBLeftWheelLine.Visible = True
                    Me.m_OLineBRightWheel.Visible = True
                    Me.m_OTextBRightWheelLine.Visible = True
                Else
                    Me.BtnWheel.Text = "CL ON"
                    Me.m_OLineALeftWheel.Visible = False
                    Me.m_OTextALeftWheelLine.Visible = False
                    Me.m_OLineARightWheel.Visible = False
                    Me.m_OTextARightWheelLine.Visible = False
                    Me.m_OLineBLeftWheel.Visible = False
                    Me.m_OTextBLeftWheelLine.Visible = False
                    Me.m_OLineBRightWheel.Visible = False
                    Me.m_OTextBRightWheelLine.Visible = False
                End If
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


    Private Sub BtnMoveAStage_Click(sender As System.Object, e As System.EventArgs) Handles BtnMoveAStage.Click
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)

            'Me.CdpALeft.StaticGraphics.Clear()
            'Me.CdpARight.StaticGraphics.Clear()

            If (Me.BtnMoveAStage.Text = "#1 Up") Then
                Me.BtnMoveAStage.Text = "#1 Down"
                CMotionController.It.OPLC.DoBShift(ESTAGE.A)
                Me.m_OAManualAlignmentLeftMarker_PartialLeft.Interactive = False
                Me.m_OAManualAlignmentRightMarker_PartialLeft.Interactive = False
                Me.m_OAManualAlignmentLeftMarker_PartialRight.Interactive = True
                Me.m_OAManualAlignmentRightMarker_PartialRight.Interactive = True
            Else
                Me.BtnMoveAStage.Text = "#1 Up"
                CMotionController.It.OPLC.InitBShift(ESTAGE.A)
                Me.m_OAManualAlignmentLeftMarker_PartialLeft.Interactive = True
                Me.m_OAManualAlignmentRightMarker_PartialLeft.Interactive = True
                Me.m_OAManualAlignmentLeftMarker_PartialRight.Interactive = False
                Me.m_OAManualAlignmentRightMarker_PartialRight.Interactive = False
            End If
        Catch ex As Exception
            CError.Show(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub


    Private Sub BtnMoveBStage_Click(sender As System.Object, e As System.EventArgs) Handles BtnMoveBStage.Click
        Try
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            'Me.CdpBLeft.StaticGraphics.Clear()
            'Me.CdpBRight.StaticGraphics.Clear()

            If (Me.BtnMoveBStage.Text = "#2 Up") Then
                Me.BtnMoveBStage.Text = "#2 Down"
                CMotionController.It.OPLC.DoBShift(ESTAGE.B)
                Me.m_OBManualAlignmentLeftMarker_PartialLeft.Interactive = False
                Me.m_OBManualAlignmentRightMarker_PartialLeft.Interactive = False

                Me.m_OBManualAlignmentLeftMarker_PartialRight.Interactive = True
                Me.m_OBManualAlignmentRightMarker_PartialRight.Interactive = True
            Else
                Me.BtnMoveBStage.Text = "#2 Up"
                CMotionController.It.OPLC.InitBShift(ESTAGE.B)

                Me.m_OBManualAlignmentLeftMarker_PartialLeft.Interactive = True
                Me.m_OBManualAlignmentRightMarker_PartialLeft.Interactive = True

                Me.m_OBManualAlignmentLeftMarker_PartialRight.Interactive = False
                Me.m_OBManualAlignmentRightMarker_PartialRight.Interactive = False
            End If
        Catch ex As Exception
            CError.Show(ex)
        Finally
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try

    End Sub



    Private Sub BtnAManualShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAManualShow.Click
        Try
            Try
                Monitor.Enter(Me.m_OALeftInterrupt)
                Monitor.Enter(Me.m_OARightInterrupt)
                If (CMotionController.It.OPLC.GetBOversize_A() = 0) Then
                    If (Me.BtnAManualShow.Text = "#1 Man. On") Then
                        Me.BtnAManualShow.Text = "#1 Man. Off"
                        Me.BtnAManualRun.BackColor = Color.SteelBlue
                        Me.BtnAManualRun.Enabled = True

                        Me.m_OAManualAlignmentLeftMarker.Visible = True
                        Me.m_OAManualAlignmentRightMarker.Visible = True
                    Else
                        Me.BtnAManualShow.Text = "#1 Man. On"
                        Me.BtnAManualRun.BackColor = SystemColors.Control
                        Me.BtnAManualRun.Enabled = False

                        Me.m_OAManualAlignmentLeftMarker.Visible = False
                        Me.m_OAManualAlignmentRightMarker.Visible = False
                    End If
                Else
                    If (CMotionController.It.OPLC.GetBLeftOrRightStandard = 0) Then
                        If (Me.BtnAManualShow.Text = "#1 Man. On") Then
                            Me.BtnAManualShow.Text = "#1 Man. Off"
                            Me.BtnAManualRun.BackColor = Color.SteelBlue
                            Me.BtnAManualRun.Enabled = True

                            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Visible = True
                            Me.m_OAManualAlignmentLeftMarker_PartialRight.Visible = True


                            If (Me.BtnMoveAStage.Text = "#1 Down") Then
                                Me.BtnMoveAStage.PerformClick()
                            End If
                        Else
                            Me.BtnAManualShow.Text = "#1 Man. On"
                            Me.BtnAManualRun.BackColor = SystemColors.Control
                            Me.BtnAManualRun.Enabled = False

                            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Visible = False
                            Me.m_OAManualAlignmentLeftMarker_PartialRight.Visible = False
                        End If
                    Else
                        If (Me.BtnAManualShow.Text = "#1 Man. On") Then
                            Me.BtnAManualShow.Text = "#1 Man. Off"
                            Me.BtnAManualRun.BackColor = Color.SteelBlue
                            Me.BtnAManualRun.Enabled = True

                            Me.m_OAManualAlignmentRightMarker_PartialLeft.Visible = True
                            Me.m_OAManualAlignmentRightMarker_PartialRight.Visible = True

                            If (Me.BtnMoveAStage.Text = "#1 Down") Then
                                Me.BtnMoveAStage.PerformClick()
                            End If
                        Else
                            Me.BtnAManualShow.Text = "#1 Man. On"
                            Me.BtnAManualRun.BackColor = SystemColors.Control
                            Me.BtnAManualRun.Enabled = False

                            Me.m_OAManualAlignmentRightMarker_PartialLeft.Visible = False
                            Me.m_OAManualAlignmentRightMarker_PartialRight.Visible = False
                        End If
                    End If
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Monitor.Exit(Me.m_OALeftInterrupt)
                Monitor.Exit(Me.m_OARightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnAManualRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAManualRun.Click
        Try
            Try
                Monitor.Enter(Me.m_OALeftInterrupt)
                Monitor.Enter(Me.m_OARightInterrupt)
                If (CMsgBox.OKCancel("Do you want to align with the above position?") = DialogResult.OK) Then
                    If (CMotionController.It.OPLC.GetBOversize_A() = 0) Then
                        CTool.It.OStageA.RunManualAlignment _
                            ( _
                                CType(Me.CdpALeft.Image, CogImage8Grey), _
                                CType(Me.CdpARight.Image, CogImage8Grey), _
                                Me.m_OAManualAlignmentLeftMarker.X, _
                                Me.m_OAManualAlignmentLeftMarker.Y, _
                                Me.m_OAManualAlignmentRightMarker.X, _
                                Me.m_OAManualAlignmentRightMarker.Y _
                            )

                        Me.BtnAManualShow.Text = "#1 Man. On"
                        Me.BtnAManualRun.BackColor = SystemColors.Control
                        Me.BtnAManualRun.Enabled = False

                        Me.m_OAManualAlignmentLeftMarker.Visible = False
                        Me.m_OAManualAlignmentRightMarker.Visible = False
                    Else
                        If (CMotionController.It.OPLC.GetBLeftOrRightStandard = 0) Then
                            CTool.It.OStageA.RunPartialManualAlignment _
                            ( _
                                CType(Me.CdpALeft.Image, CogImage8Grey), _
                                Me.m_OAManualAlignmentLeftMarker_PartialLeft.X, _
                                Me.m_OAManualAlignmentLeftMarker_PartialLeft.Y, _
                                Me.m_OAManualAlignmentLeftMarker_PartialRight.X, _
                                Me.m_OAManualAlignmentLeftMarker_PartialRight.Y _
                            )

                            Me.BtnAManualShow.Text = "#1 Man. On"
                            Me.BtnAManualRun.BackColor = SystemColors.Control
                            Me.BtnAManualRun.Enabled = False

                            Me.m_OAManualAlignmentLeftMarker_PartialLeft.Visible = False
                            Me.m_OAManualAlignmentLeftMarker_PartialRight.Visible = False
                        Else
                            CTool.It.OStageA.RunPartialManualAlignment _
                            ( _
                                CType(Me.CdpARight.Image, CogImage8Grey), _
                                Me.m_OAManualAlignmentRightMarker_PartialLeft.X, _
                                Me.m_OAManualAlignmentRightMarker_PartialLeft.Y, _
                                Me.m_OAManualAlignmentRightMarker_PartialRight.X, _
                                Me.m_OAManualAlignmentRightMarker_PartialRight.Y _
                            )

                            Me.BtnAManualShow.Text = "#1 Man. On"
                            Me.BtnAManualRun.BackColor = SystemColors.Control
                            Me.BtnAManualRun.Enabled = False

                            Me.m_OAManualAlignmentRightMarker_PartialLeft.Visible = False
                            Me.m_OAManualAlignmentRightMarker_PartialRight.Visible = False
                        End If
                    End If
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                If (Me.BtnMoveAStage.Text = "#1 Down") Then
                    Me.BtnMoveAStage.PerformClick()
                End If
                Monitor.Exit(Me.m_OALeftInterrupt)
                Monitor.Exit(Me.m_OARightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnBManualShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBManualShow.Click
        Try
            Try
                Monitor.Enter(Me.m_OBLeftInterrupt)
                Monitor.Enter(Me.m_OBRightInterrupt)
                If (CMotionController.It.OPLC.GetBOversize_B() = 0) Then
                    If (Me.BtnBManualShow.Text = "#2 Man. On") Then
                        Me.BtnBManualShow.Text = "#2 Man. Off"
                        Me.BtnBManualRun.BackColor = Color.SteelBlue
                        Me.BtnBManualRun.Enabled = True

                        Me.m_OBManualAlignmentLeftMarker.Visible = True
                        Me.m_OBManualAlignmentRightMarker.Visible = True
                    Else
                        Me.BtnBManualShow.Text = "#2 Man. On"
                        Me.BtnBManualRun.BackColor = SystemColors.Control
                        Me.BtnBManualRun.Enabled = False

                        Me.m_OBManualAlignmentLeftMarker.Visible = False
                        Me.m_OBManualAlignmentRightMarker.Visible = False
                    End If
                Else
                    If (CMotionController.It.OPLC.GetBLeftOrRightStandard = 0) Then
                        If (Me.BtnBManualShow.Text = "#2 Man. On") Then
                            Me.BtnBManualShow.Text = "#2 Man. Off"
                            Me.BtnBManualRun.BackColor = Color.SteelBlue
                            Me.BtnBManualRun.Enabled = True

                            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Visible = True
                            Me.m_OBManualAlignmentLeftMarker_PartialRight.Visible = True

                            If (Me.BtnMoveBStage.Text = "#2 Down") Then
                                Me.BtnMoveBStage.PerformClick()
                            End If
                        Else
                            Me.BtnBManualShow.Text = "#2 Man. On"
                            Me.BtnBManualRun.BackColor = SystemColors.Control
                            Me.BtnBManualRun.Enabled = False

                            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Visible = False
                            Me.m_OBManualAlignmentLeftMarker_PartialRight.Visible = False
                        End If
                    Else
                        If (Me.BtnBManualShow.Text = "#2 Man. On") Then
                            Me.BtnBManualShow.Text = "#2 Man. Off"
                            Me.BtnBManualRun.BackColor = Color.SteelBlue
                            Me.BtnBManualRun.Enabled = True

                            Me.m_OBManualAlignmentRightMarker_PartialLeft.Visible = True
                            Me.m_OBManualAlignmentRightMarker_PartialRight.Visible = True


                            If (Me.BtnMoveBStage.Text = "#2 Down") Then
                                Me.BtnMoveBStage.PerformClick()
                            End If
                        Else
                            Me.BtnBManualShow.Text = "#2 Man. On"
                            Me.BtnBManualRun.BackColor = SystemColors.Control
                            Me.BtnBManualRun.Enabled = False

                            Me.m_OBManualAlignmentRightMarker_PartialLeft.Visible = False
                            Me.m_OBManualAlignmentRightMarker_PartialRight.Visible = False
                        End If
                    End If
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Monitor.Exit(Me.m_OBLeftInterrupt)
                Monitor.Exit(Me.m_OBRightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnBManualRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBManualRun.Click
        Try
            Try
                Monitor.Enter(Me.m_OBLeftInterrupt)
                Monitor.Enter(Me.m_OBRightInterrupt)
                If (CMsgBox.OKCancel("Do you want to align with the above position?") = DialogResult.OK) Then
                    If (CMotionController.It.OPLC.GetBOversize_B() = 0) Then
                        CTool.It.OStageB.RunManualAlignment _
                            ( _
                                CType(Me.CdpBLeft.Image, CogImage8Grey), _
                                CType(Me.CdpBRight.Image, CogImage8Grey), _
                                Me.m_OBManualAlignmentLeftMarker.X, _
                                Me.m_OBManualAlignmentLeftMarker.Y, _
                                Me.m_OBManualAlignmentRightMarker.X, _
                                Me.m_OBManualAlignmentRightMarker.Y _
                            )

                        Me.BtnBManualShow.Text = "#2 Man. On"
                        Me.BtnBManualRun.BackColor = SystemColors.Control
                        Me.BtnBManualRun.Enabled = False

                        Me.m_OBManualAlignmentLeftMarker.Visible = False
                        Me.m_OBManualAlignmentRightMarker.Visible = False
                    Else
                        If (CMotionController.It.OPLC.GetBLeftOrRightStandard = 0) Then
                            CTool.It.OStageB.RunPartialManualAlignment _
                            ( _
                                CType(Me.CdpBLeft.Image, CogImage8Grey), _
                                Me.m_OBManualAlignmentLeftMarker_PartialLeft.X, _
                                Me.m_OBManualAlignmentLeftMarker_PartialLeft.Y, _
                                Me.m_OBManualAlignmentLeftMarker_PartialRight.X, _
                                Me.m_OBManualAlignmentLeftMarker_PartialRight.Y _
                            )

                            Me.BtnBManualShow.Text = "#2 Man. On"
                            Me.BtnBManualRun.BackColor = SystemColors.Control
                            Me.BtnBManualRun.Enabled = False

                            Me.m_OBManualAlignmentLeftMarker_PartialLeft.Visible = False
                            Me.m_OBManualAlignmentLeftMarker_PartialRight.Visible = False
                        Else
                            CTool.It.OStageB.RunPartialManualAlignment _
                            ( _
                                CType(Me.CdpBRight.Image, CogImage8Grey), _
                                Me.m_OBManualAlignmentRightMarker_PartialLeft.X, _
                                Me.m_OBManualAlignmentRightMarker_PartialLeft.Y, _
                                Me.m_OBManualAlignmentRightMarker_PartialRight.X, _
                                Me.m_OBManualAlignmentRightMarker_PartialRight.Y _
                            )

                            Me.BtnBManualShow.Text = "#2 Man. On"
                            Me.BtnBManualRun.BackColor = SystemColors.Control
                            Me.BtnBManualRun.Enabled = False

                            Me.m_OBManualAlignmentRightMarker_PartialLeft.Visible = False
                            Me.m_OBManualAlignmentRightMarker_PartialRight.Visible = False
                        End If
                    End If
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                If (Me.BtnMoveBStage.Text = "#2 Down") Then
                    Me.BtnMoveBStage.PerformClick()
                End If
                Monitor.Exit(Me.m_OBLeftInterrupt)
                Monitor.Exit(Me.m_OBRightInterrupt)
            End Try
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "ETC EVENT"
    Private Sub StageALeft_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            ' jht 이미지 콜백 갱신
            'Monitor.Enter(Me.m_OALeftInterrupt)
            Me.CdpALeft.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            'Monitor.Exit(Me.m_OALeftInterrupt)
        End Try
    End Sub


    Private Sub StageARight_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            ' jht 이미지 콜백 갱신
            'Monitor.Enter(Me.m_OARightInterrupt)
            Me.CdpARight.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            'Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub


    Private Sub StageBLeft_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            ' jht 이미지 콜백 갱신
            'Monitor.Enter(Me.m_OBLeftInterrupt)
            Me.CdpBLeft.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            'Monitor.Exit(Me.m_OBLeftInterrupt)
        End Try
    End Sub


    Private Sub StageBRight_ImageExported(ByVal OImageInfo As CImageInfo)
        Try
            ' jht 이미지 콜백 갱신
            'Monitor.Enter(Me.m_OBRightInterrupt)
            Me.CdpBRight.Image = OImageInfo.OImage
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            'Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Sub StageA_AlignmentRan(ByVal OResult As CAlignmentResult) '여기서 가끔 무한정지가 됨 Control.Invoke() hangs application
        Try
            If MyBase.InvokeRequired = True Then
                Me.DisplayAMark(OResult)
                MyBase.BeginInvoke(New CAlignmentTool.AlignmentRanHandler(AddressOf Me.StageA_AlignmentRan), OResult)
            Else
                If (OResult.EResult = ERESULT.RETRY) Then
                    Me.LblAAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 4).ToString("0.00000")
                    Me.LblAAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 4).ToString("0.00000")
                    Me.LblAAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 4).ToString("0.00000")
                    Me.LblAAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 5).ToString("0.000000")
                    Me.LblAAlignmentLeftXCurrent.ForeColor = Color.Black
                    Me.LblAAlignmentRightXCurrent.ForeColor = Color.Black
                    Me.LblAAlignmentYCurrent.ForeColor = Color.Black
                    Me.LblAAlignmentTCurrent.ForeColor = Color.Black
                    Me.LblAAlignmentLeftXCurrent.BackColor = Color.White
                    Me.LblAAlignmentRightXCurrent.BackColor = Color.White
                    Me.LblAAlignmentYCurrent.BackColor = Color.White
                    Me.LblAAlignmentTCurrent.BackColor = Color.White
                    ' jht Retry & TactTime

                    Me.LblAStageTotalRetry.ForeColor = Color.Black
                    Me.LblAStageTotalTimeElapsed.ForeColor = Color.Black

                    Me.LblAStageTotalRetry.BackColor = Color.White
                    Me.LblAStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                    Me.LblAStageTotalTimeElapsed.BackColor = Color.White
                    Me.LblAStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
                ElseIf (OResult.EResult = ERESULT.OK) Then
                    Me.LblAAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 4).ToString("0.00000")
                    Me.LblAAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 4).ToString("0.00000")
                    Me.LblAAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 4).ToString("0.00000")
                    Me.LblAAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 5).ToString("0.000000")
                    Me.LblAAlignmentLeftXCurrent.ForeColor = Color.White
                    Me.LblAAlignmentRightXCurrent.ForeColor = Color.White
                    Me.LblAAlignmentYCurrent.ForeColor = Color.White
                    Me.LblAAlignmentTCurrent.ForeColor = Color.White
                    Me.LblAAlignmentLeftXCurrent.BackColor = Color.ForestGreen
                    Me.LblAAlignmentRightXCurrent.BackColor = Color.ForestGreen
                    Me.LblAAlignmentYCurrent.BackColor = Color.ForestGreen
                    Me.LblAAlignmentTCurrent.BackColor = Color.ForestGreen
                    ' jht Retry & TactTime

                    Me.LblAStageTotalRetry.ForeColor = Color.White
                    Me.LblAStageTotalTimeElapsed.ForeColor = Color.White
                    Me.LblAStageTotalRetry.BackColor = Color.ForestGreen
                    Me.LblAStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                    Me.LblAStageTotalTimeElapsed.BackColor = Color.ForestGreen
                    Me.LblAStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + "." + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
                ElseIf (OResult.EResult = ERESULT.NG) Then
                    Me.LblAAlignmentLeftXCurrent.Text = "NG"
                    Me.LblAAlignmentRightXCurrent.Text = "NG"
                    Me.LblAAlignmentYCurrent.Text = "NG"
                    Me.LblAAlignmentTCurrent.Text = "NG"
                    Me.LblAAlignmentLeftXCurrent.ForeColor = Color.White
                    Me.LblAAlignmentRightXCurrent.ForeColor = Color.White
                    Me.LblAAlignmentYCurrent.ForeColor = Color.White
                    Me.LblAAlignmentTCurrent.ForeColor = Color.White
                    Me.LblAAlignmentLeftXCurrent.BackColor = Color.Red
                    Me.LblAAlignmentRightXCurrent.BackColor = Color.Red
                    Me.LblAAlignmentYCurrent.BackColor = Color.Red
                    Me.LblAAlignmentTCurrent.BackColor = Color.Red
                    ' jht Retry & TactTime

                    Me.LblAStageTotalRetry.ForeColor = Color.White
                    Me.LblAStageTotalTimeElapsed.ForeColor = Color.White
                    Me.LblAStageTotalRetry.BackColor = Color.Red
                    Me.LblAStageTotalRetry.Text = "-"
                    Me.LblAStageTotalTimeElapsed.BackColor = Color.Red
                    Me.LblAStageTotalTimeElapsed.Text = "-"
                End If
                Me.LblALeftScore.Text = OResult.OLeft.F64Score.ToString("0.0")
                Me.LblARightScore.Text = OResult.ORight.F64Score.ToString("0.0")
                If (OResult.OLeft.F64Score > 100) Then
                    Me.LblALeftScore.Text = 100
                End If
                If (OResult.ORight.F64Score > 100) Then
                    Me.LblARightScore.Text = 100
                End If

                If (OResult.OLeft.BOK = False) Then
                    Me.LblALeftScore.BackColor = Color.DarkRed
                Else
                    Me.LblALeftScore.BackColor = Color.ForestGreen
                End If
                If (OResult.ORight.BOK = False) Then
                    Me.LblARightScore.BackColor = Color.DarkRed
                Else
                    Me.LblARightScore.BackColor = Color.ForestGreen
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub StageA_EdgeRan(ByVal OResult As CInspectionResult)
        Try
            If MyBase.InvokeRequired = True Then
                Me.DisplayAEdge(OResult)
                MyBase.BeginInvoke(New CAlignmentTool.EdgeRanHandler(AddressOf Me.StageA_EdgeRan), OResult)
            Else
                If (OResult.ETarget = EEDGE_TARGET.FRONT) Then
                    If (OResult.OLeft.BInspected = True) Then
                        Me.LblAEdgeTopLeft.Text = Math.Round(OResult.OLeft.F64Length, 3).ToString()
                        If (OResult.OLeft.BOK = True) Then
                            Me.LblAEdgeTopLeft.BackColor = Color.ForestGreen
                        Else
                            Me.LblAEdgeTopLeft.BackColor = Color.Red
                        End If
                    Else
                        Me.LblAEdgeTopLeft.Text = String.Empty
                        Me.LblAEdgeTopLeft.BackColor = Color.White
                    End If
                    If (OResult.ORight.BInspected = True) Then
                        Me.LblAEdgeTopRight.Text = Math.Round(OResult.ORight.F64Length, 3).ToString()
                        If (OResult.ORight.BOK = True) Then
                            Me.LblAEdgeTopRight.BackColor = Color.ForestGreen
                        Else
                            Me.LblAEdgeTopRight.BackColor = Color.Red
                        End If
                    Else
                        Me.LblAEdgeTopRight.Text = String.Empty
                        Me.LblAEdgeTopRight.BackColor = Color.White
                    End If
                ElseIf (OResult.ETarget = EEDGE_TARGET.REAR) Then
                    If (OResult.OLeft.BInspected = True) Then
                        Me.LblAEdgeBottomLeft.Text = Math.Round(OResult.OLeft.F64Length, 3).ToString()
                        If (OResult.OLeft.BOK = True) Then
                            Me.LblAEdgeBottomLeft.BackColor = Color.ForestGreen
                        Else
                            Me.LblAEdgeBottomLeft.BackColor = Color.Red
                        End If
                    Else
                        Me.LblAEdgeBottomLeft.Text = String.Empty
                        Me.LblAEdgeBottomLeft.BackColor = Color.White
                    End If
                    If (OResult.ORight.BInspected = True) Then
                        Me.LblAEdgeBottomRight.Text = Math.Round(OResult.ORight.F64Length, 3).ToString()
                        If (OResult.ORight.BOK = True) Then
                            Me.LblAEdgeBottomRight.BackColor = Color.ForestGreen
                        Else
                            Me.LblAEdgeBottomRight.BackColor = Color.Red
                        End If
                    Else
                        Me.LblAEdgeBottomRight.Text = String.Empty
                        Me.LblAEdgeBottomRight.BackColor = Color.White
                    End If
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub StageB_AlignmentRan(ByVal OResult As CAlignmentResult)
        Try
            If MyBase.InvokeRequired = True Then
                Me.DisplayBMark(OResult)
                MyBase.BeginInvoke(New CAlignmentTool.AlignmentRanHandler(AddressOf Me.StageB_AlignmentRan), OResult)
            Else
                If (OResult.EResult = ERESULT.RETRY) Then
                    Me.LblBAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 4).ToString("0.00000")
                    Me.LblBAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 4).ToString("0.00000")
                    Me.LblBAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 4).ToString("0.00000")
                    Me.LblBAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 5).ToString("0.000000")
                    Me.LblBAlignmentLeftXCurrent.ForeColor = Color.Black
                    Me.LblBAlignmentRightXCurrent.ForeColor = Color.Black
                    Me.LblBAlignmentYCurrent.ForeColor = Color.Black
                    Me.LblBAlignmentTCurrent.ForeColor = Color.Black
                    Me.LblBAlignmentLeftXCurrent.BackColor = Color.White
                    Me.LblBAlignmentRightXCurrent.BackColor = Color.White
                    Me.LblBAlignmentYCurrent.BackColor = Color.White
                    Me.LblBAlignmentTCurrent.BackColor = Color.White
                    ' jht Retry & TactTime

                    Me.LblBStageTotalRetry.ForeColor = Color.Black
                    Me.LblBStageTotalTimeElapsed.ForeColor = Color.Black
                    Me.LblBStageTotalRetry.BackColor = Color.White
                    Me.LblBStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                    Me.LblBStageTotalTimeElapsed.BackColor = Color.White
                    Me.LblBStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
                ElseIf (OResult.EResult = ERESULT.OK) Then
                    Me.LblBAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 4).ToString("0.00000")
                    Me.LblBAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 4).ToString("0.00000")
                    Me.LblBAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 4).ToString("0.00000")
                    Me.LblBAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 5).ToString("0.000000")
                    Me.LblBAlignmentLeftXCurrent.ForeColor = Color.White
                    Me.LblBAlignmentRightXCurrent.ForeColor = Color.White
                    Me.LblBAlignmentYCurrent.ForeColor = Color.White
                    Me.LblBAlignmentTCurrent.ForeColor = Color.White
                    Me.LblBAlignmentLeftXCurrent.BackColor = Color.ForestGreen
                    Me.LblBAlignmentRightXCurrent.BackColor = Color.ForestGreen
                    Me.LblBAlignmentYCurrent.BackColor = Color.ForestGreen
                    Me.LblBAlignmentTCurrent.BackColor = Color.ForestGreen
                    ' jht Retry & TactTime

                    Me.LblBStageTotalRetry.ForeColor = Color.White
                    Me.LblBStageTotalTimeElapsed.ForeColor = Color.White
                    Me.LblBStageTotalRetry.BackColor = Color.ForestGreen
                    Me.LblBStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                    Me.LblBStageTotalTimeElapsed.BackColor = Color.ForestGreen
                    Me.LblBStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + "." + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
                ElseIf (OResult.EResult = ERESULT.NG) Then
                    Me.LblBAlignmentLeftXCurrent.Text = "NG"
                    Me.LblBAlignmentRightXCurrent.Text = "NG"
                    Me.LblBAlignmentYCurrent.Text = "NG"
                    Me.LblBAlignmentTCurrent.Text = "NG"
                    Me.LblBAlignmentLeftXCurrent.ForeColor = Color.White
                    Me.LblBAlignmentRightXCurrent.ForeColor = Color.White
                    Me.LblBAlignmentYCurrent.ForeColor = Color.White
                    Me.LblBAlignmentTCurrent.ForeColor = Color.White
                    Me.LblBAlignmentLeftXCurrent.BackColor = Color.Red
                    Me.LblBAlignmentRightXCurrent.BackColor = Color.Red
                    Me.LblBAlignmentYCurrent.BackColor = Color.Red
                    Me.LblBAlignmentTCurrent.BackColor = Color.Red
                    ' jht Retry & TactTime

                    Me.LblBStageTotalRetry.ForeColor = Color.White
                    Me.LblBStageTotalTimeElapsed.ForeColor = Color.White
                    Me.LblBStageTotalRetry.BackColor = Color.Red
                    Me.LblBStageTotalRetry.Text = "-"
                    Me.LblBStageTotalTimeElapsed.BackColor = Color.Red
                    Me.LblBStageTotalTimeElapsed.Text = "-"
                End If

                Me.LblBLeftScore.Text = OResult.OLeft.F64Score.ToString("0.0")
                Me.LblBRightScore.Text = OResult.ORight.F64Score.ToString("0.0")
                If (OResult.OLeft.F64Score > 100) Then
                    Me.LblBLeftScore.Text = 100
                End If
                If (OResult.ORight.F64Score > 100) Then
                    Me.LblBRightScore.Text = 100
                End If
                ' jht Score
                If (OResult.OLeft.BOK = False) Then
                    Me.LblBLeftScore.BackColor = Color.DarkRed
                Else
                    Me.LblBLeftScore.BackColor = Color.ForestGreen
                End If
                If (OResult.ORight.BOK = False) Then
                    Me.LblBRightScore.BackColor = Color.DarkRed
                Else
                    Me.LblBRightScore.BackColor = Color.ForestGreen
                End If
                End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub StageB_EdgeRan(ByVal OResult As CInspectionResult)
        Try
            If MyBase.InvokeRequired = True Then
                Me.DisplayBEdge(OResult)
                MyBase.BeginInvoke(New CAlignmentTool.EdgeRanHandler(AddressOf Me.StageB_EdgeRan), OResult)
            Else
                If (OResult.ETarget = EEDGE_TARGET.FRONT) Then
                    If (OResult.OLeft.BInspected = True) Then
                        Me.LblBEdgeTopLeft.Text = Math.Round(OResult.OLeft.F64Length, 3).ToString()
                        If (OResult.OLeft.BOK = True) Then
                            Me.LblBEdgeTopLeft.BackColor = Color.ForestGreen
                        Else
                            Me.LblBEdgeTopLeft.BackColor = Color.Red
                        End If
                    Else
                        Me.LblBEdgeTopLeft.Text = String.Empty
                        Me.LblBEdgeTopLeft.BackColor = Color.White
                    End If
                    If (OResult.ORight.BInspected = True) Then
                        Me.LblBEdgeTopRight.Text = Math.Round(OResult.ORight.F64Length, 3).ToString()
                        If (OResult.ORight.BOK = True) Then
                            Me.LblBEdgeTopRight.BackColor = Color.ForestGreen
                        Else
                            Me.LblBEdgeTopRight.BackColor = Color.Red
                        End If
                    Else
                        Me.LblBEdgeTopRight.Text = String.Empty
                        Me.LblBEdgeTopRight.BackColor = Color.White
                    End If
                ElseIf (OResult.ETarget = EEDGE_TARGET.REAR) Then
                    If (OResult.OLeft.BInspected = True) Then
                        Me.LblBEdgeBottomLeft.Text = Math.Round(OResult.OLeft.F64Length, 3).ToString()
                        If (OResult.OLeft.BOK = True) Then
                            Me.LblBEdgeBottomLeft.BackColor = Color.ForestGreen
                        Else
                            Me.LblBEdgeBottomLeft.BackColor = Color.Red
                        End If
                    Else
                        Me.LblBEdgeBottomLeft.Text = String.Empty
                        Me.LblBEdgeBottomLeft.BackColor = Color.White
                    End If
                    If (OResult.ORight.BInspected = True) Then
                        Me.LblBEdgeBottomRight.Text = Math.Round(OResult.ORight.F64Length, 3).ToString()
                        If (OResult.ORight.BOK = True) Then
                            Me.LblBEdgeBottomRight.BackColor = Color.ForestGreen
                        Else
                            Me.LblBEdgeBottomRight.BackColor = Color.Red
                        End If
                    Else
                        Me.LblBEdgeBottomRight.Text = String.Empty
                        Me.LblBEdgeBottomRight.BackColor = Color.White
                    End If
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OPLC_WheelPositionChanged(ByVal F64StageALeftWheel As Double, ByVal F64StageARightWheel As Double, ByVal F64StageBLeftWheel As Double, ByVal F64StageBRightWheel As Double)
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            F64StageALeftWheel = F64StageALeftWheel / CEnvironment.LEN_PER_PIXEL
            F64StageARightWheel = (F64StageARightWheel / CEnvironment.LEN_PER_PIXEL) * -1
            F64StageBLeftWheel = F64StageBLeftWheel / CEnvironment.LEN_PER_PIXEL
            F64StageBRightWheel = (F64StageBRightWheel / CEnvironment.LEN_PER_PIXEL) * -1

            Me.m_OLineALeftWheel.X = Me.m_OLineALeftX.X + F64StageALeftWheel
            Me.m_OTextALeftWheelLine.X = Me.m_OLineALeftX.X + F64StageALeftWheel + 50
            Me.m_OLineARightWheel.X = Me.m_OLineARightX.X + F64StageARightWheel
            Me.m_OTextARightWheelLine.X = Me.m_OLineARightX.X + F64StageARightWheel + 50
            Me.m_OLineBLeftWheel.X = Me.m_OLineBLeftX.X + F64StageBLeftWheel
            Me.m_OTextBLeftWheelLine.X = Me.m_OLineBLeftX.X + F64StageBLeftWheel + 50
            Me.m_OLineBRightWheel.X = Me.m_OLineBLeftX.X + F64StageBRightWheel
            Me.m_OTextBRightWheelLine.X = Me.m_OLineBLeftX.X + F64StageBRightWheel + 50
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Sub OLogTool_SendMessage(ByVal StrMessage As String)
        Try
            If MyBase.InvokeRequired = True Then
                MyBase.BeginInvoke(New CLogTool.SendMessageHandler(AddressOf OLogTool_SendMessage), StrMessage)
            Else
                Me.LtbMessage.Items.Add(StrMessage)
                Me.LtbMessage.SelectedIndex = Me.LtbMessage.Items.Count - 1
                If Me.LtbMessage.Items.Count >= 100 Then
                    Me.LtbMessage.Items.RemoveAt(0)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub CdpImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CdpALeft.Click, CdpARight.Click, CdpBLeft.Click, CdpBRight.Click
        Try
            Dim StrDisplayTag As String = CType(CType(sender, Control).Tag, String)
            Dim BSendValueToPLC As Boolean = False
            Dim F64Value As Double = 0

            Select Case StrDisplayTag
                Case "A LEFT"
                    If (Me.m_BCaliperAbleAL = False) Then Exit Sub

                    F64Value = Me.CalcLengthAboutALeft(BSendValueToPLC)
                    If (BSendValueToPLC = True) Then
                        CMotionController.It.OPLC.SendEstimatedLength(ECAMERA.A_LEFT, F64Value)
                    End If
                Case "A RIGHT"
                    If (Me.m_BCaliperAbleAR = False) Then Exit Sub

                    F64Value = Me.CalcLengthAboutARight(BSendValueToPLC)
                    If (BSendValueToPLC = True) Then
                        CMotionController.It.OPLC.SendEstimatedLength(ECAMERA.A_RIGHT, F64Value)
                    End If
                Case "B LEFT"
                    If (Me.m_BCaliperAbleBL = False) Then Exit Sub

                    F64Value = Me.CalcLengthAboutBLeft(BSendValueToPLC)
                    If (BSendValueToPLC = True) Then
                        CMotionController.It.OPLC.SendEstimatedLength(ECAMERA.B_LEFT, F64Value)
                    End If
                Case "B RIGHT"
                    If (Me.m_BCaliperAbleBR = False) Then Exit Sub

                    F64Value = Me.CalcLengthAboutBRight(BSendValueToPLC)
                    If (BSendValueToPLC = True) Then
                        CMotionController.It.OPLC.SendEstimatedLength(ECAMERA.B_RIGHT, F64Value)
                    End If
            End Select
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub CdpImage_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CdpALeft.MouseMove, CdpARight.MouseMove, CdpBLeft.MouseMove, CdpBRight.MouseMove
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


    Public Sub CdpImage_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CdpARight.DoubleClick, CdpBRight.DoubleClick, CdpBLeft.DoubleClick, CdpALeft.DoubleClick
        Try
            Dim StrTag = CType(CType(sender, Control).Tag, String)

            Try
                Select Case (StrTag)
                    Case "A LEFT"
                        Monitor.Enter(Me.m_OALeftInterrupt)
                    Case "A RIGHT"
                        Monitor.Enter(Me.m_OARightInterrupt)
                    Case "B LEFT"
                        Monitor.Enter(Me.m_OBLeftInterrupt)
                    Case "B RIGHT"
                        Monitor.Enter(Me.m_OBRightInterrupt)
                End Select

                If (Me.m_EScreenMode = ESCREEN_MODE.ORIGINAL) Then
                    Me.m_EScreenMode = ESCREEN_MODE.FULL_ONE

                    Me.PnlTitle.Visible = False
                    Me.PnlRight.Visible = False
                    Me.PnlButtom.Visible = False

                    If (StrTag = "A LEFT") Then
                        Me.PnlBImage.Visible = False
                        Me.PnlARight.Visible = False
                        Me.PnlAImage.Dock = DockStyle.Fill
                        Me.PnlALeft.Dock = DockStyle.Fill
                    ElseIf (StrTag = "A RIGHT") Then
                        Me.PnlBImage.Visible = False
                        Me.PnlALeft.Visible = False
                        Me.PnlAImage.Dock = DockStyle.Fill
                    ElseIf (StrTag = "B LEFT") Then
                        Me.PnlAImage.Visible = False
                        Me.PnlBRight.Visible = False
                        Me.PnlBLeft.Dock = DockStyle.Fill
                    ElseIf (StrTag = "B RIGHT") Then
                        Me.PnlAImage.Visible = False
                        Me.PnlBLeft.Visible = False
                    End If
                ElseIf (Me.m_EScreenMode = ESCREEN_MODE.FULL_ALL) Then
                    Me.m_EScreenMode = ESCREEN_MODE.FULL_ONE

                    If (StrTag = "A LEFT") Then
                        Me.PnlBImage.Visible = False
                        Me.PnlARight.Visible = False
                        Me.PnlAImage.Dock = DockStyle.Fill
                        Me.PnlALeft.Dock = DockStyle.Fill
                    ElseIf (StrTag = "A RIGHT") Then
                        Me.PnlBImage.Visible = False
                        Me.PnlALeft.Visible = False
                        Me.PnlAImage.Dock = DockStyle.Fill
                    ElseIf (StrTag = "B LEFT") Then
                        Me.PnlAImage.Visible = False
                        Me.PnlBRight.Visible = False
                        Me.PnlBLeft.Dock = DockStyle.Fill
                    ElseIf (StrTag = "B RIGHT") Then
                        Me.PnlAImage.Visible = False
                        Me.PnlBLeft.Visible = False
                    End If
                ElseIf (Me.m_EScreenMode = ESCREEN_MODE.FULL_ONE) Then
                    Me.m_EScreenMode = ESCREEN_MODE.ORIGINAL

                    Me.PnlTitle.Visible = True
                    Me.PnlRight.Visible = True
                    Me.PnlButtom.Visible = True
                    Me.PnlAImage.Visible = True
                    Me.PnlBImage.Visible = True
                    Me.PnlALeft.Visible = True
                    Me.PnlARight.Visible = True
                    Me.PnlBLeft.Visible = True
                    Me.PnlBRight.Visible = True

                    Me.PnlAImage.Dock = DockStyle.Top
                    Me.PnlALeft.Dock = DockStyle.Left
                    Me.PnlBLeft.Dock = DockStyle.Left

                    Me.PnlAImage.Size = New Size(Me.PnlLeft.Size.Width, Me.PnlLeft.Size.Height / 2)
                    Me.PnlALeft.Size = New Size(Me.PnlAImage.Size.Width / 2, Me.PnlAImage.Height)
                    Me.PnlBLeft.Size = New Size(Me.PnlBImage.Size.Width / 2, Me.PnlBImage.Height)
                End If

                RaiseEvent RequestFooterVisible(Me.m_EScreenMode)
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                Select Case (StrTag)
                    Case "A LEFT"
                        Monitor.Exit(Me.m_OALeftInterrupt)
                    Case "A RIGHT"
                        Monitor.Exit(Me.m_OARightInterrupt)
                    Case "B LEFT"
                        Monitor.Exit(Me.m_OBLeftInterrupt)
                    Case "B RIGHT"
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
            CTool.It.OStageA.OAlignmentRan = AddressOf Me.StageA_AlignmentRan
            CTool.It.OStageA.OEdgeRan = AddressOf Me.StageA_EdgeRan
            CTool.It.OStageB.OAlignmentRan = AddressOf Me.StageB_AlignmentRan
            CTool.It.OStageB.OEdgeRan = AddressOf Me.StageB_EdgeRan
            CTool.It.OStageA.ODisplayPartial = AddressOf Me.DisplayAMarkLeft0Right1
            CTool.It.OStageB.ODisplayPartial = AddressOf Me.DisplayBMarkLeft0Right1

            'CTool.It.OStageA.ODisplayPartialData = AddressOf Me.DisplayAData
            'CTool.It.OStageB.ODisplayPartialData = AddressOf Me.DisplayBData
            CMotionController.It.OPLC.OWheelPositionChanged = AddressOf Me.OPLC_WheelPositionChanged
            CLogTool.It.OSendMessage = AddressOf Me.OLogTool_SendMessage

            'Wheel
            Dim F64StageALeftWheel As Double = CMotionController.It.OPLC.F64StageALeftWheel / CEnvironment.LEN_PER_PIXEL
            Dim F64StageARightWheel As Double = (CMotionController.It.OPLC.F64StageARightWheel / CEnvironment.LEN_PER_PIXEL) * -1
            Dim F64StageBLeftWheel As Double = CMotionController.It.OPLC.F64StageBLeftWheel / CEnvironment.LEN_PER_PIXEL
            Dim F64StageBRightWheel As Double = (CMotionController.It.OPLC.F64StageBRightWheel / CEnvironment.LEN_PER_PIXEL) * -1

            Me.m_OLineALeftWheel.X = Me.m_OLineALeftX.X + F64StageALeftWheel
            Me.m_OTextALeftWheelLine.X = Me.m_OLineALeftX.X + F64StageALeftWheel + 50
            Me.m_OLineARightWheel.X = Me.m_OLineARightX.X + F64StageARightWheel
            Me.m_OTextARightWheelLine.X = Me.m_OLineARightX.X + F64StageARightWheel + 50
            Me.m_OLineBLeftWheel.X = Me.m_OLineBLeftX.X + F64StageBLeftWheel
            Me.m_OTextBLeftWheelLine.X = Me.m_OLineBLeftX.X + F64StageBLeftWheel + 50
            Me.m_OLineBRightWheel.X = Me.m_OLineBLeftX.X + F64StageBRightWheel
            Me.m_OTextBRightWheelLine.X = Me.m_OLineBLeftX.X + F64StageBRightWheel + 50

            'Target
            If (Not CTool.It.ORecipe Is Nothing) Then
                Me.LblAAlignmentLeftXTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentLeftXLimit.ToString("0.00000")
                Me.LblAAlignmentRightXTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentRightXLimit.ToString("0.00000")
                Me.LblAAlignmentYTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentYLimit.ToString("0.00000")
                Me.LblAAlignmentTTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentTLimit.ToString("0.00000")
                Me.LblBAlignmentLeftXTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentLeftXLimit.ToString("0.00000")
                Me.LblBAlignmentRightXTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentRightXLimit.ToString("0.00000")
                Me.LblBAlignmentYTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentYLimit.ToString("0.00000")
                Me.LblBAlignmentTTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentTLimit.ToString("0.00000")
            End If
            ' jht Max Retry
            Me.LblMaxRetries.Text = "Max Retries = " + CEnvironment.It.MaxRetry.ToString()



            Me.NudDistX.Value = Convert.ToDecimal(CEnvironment.It.MinDistanceX)
            Me.NudDistY.Value = Convert.ToDecimal(CEnvironment.It.MinDistanceY)

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
            CTool.It.OStageA.OAlignmentRan = Nothing
            CTool.It.OStageA.OEdgeRan = Nothing
            CTool.It.OStageB.OAlignmentRan = Nothing
            CTool.It.OStageB.OEdgeRan = Nothing
            CTool.It.OStageA.ODisplayPartial = Nothing
            CTool.It.OStageB.ODisplayPartial = Nothing
            CTool.It.OStageA.ODisplayPartialData = Nothing
            CTool.It.OStageB.ODisplayPartialData = Nothing
            CMotionController.It.OPLC.OWheelPositionChanged = Nothing
            CLogTool.It.OSendMessage = Nothing
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Overrides Sub ProcRecipeChanged()
        Try
            'Target => Alignment Limit
            Me.LblAAlignmentLeftXTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentLeftXLimit.ToString()
            Me.LblAAlignmentRightXTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentRightXLimit.ToString()
            Me.LblAAlignmentYTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentYLimit.ToString()
            Me.LblAAlignmentTTarget.Text = CTool.It.ORecipe.OStageA.F64AlignmentTLimit.ToString()
            Me.LblBAlignmentLeftXTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentLeftXLimit.ToString()
            Me.LblBAlignmentRightXTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentRightXLimit.ToString()
            Me.LblBAlignmentYTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentYLimit.ToString()
            Me.LblBAlignmentTTarget.Text = CTool.It.ORecipe.OStageB.F64AlignmentTLimit.ToString()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub DisplayAMarkLeft0Right1(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
        Try
            If MyBase.InvokeRequired = True Then
                'Monitor.Enter(Me.m_OALeftInterrupt)
                'Monitor.Enter(Me.m_OARightInterrupt)
                If I32Side = 0 Then
                    Me.CdpALeft.StaticGraphics.Clear()
                Else
                    Me.CdpARight.StaticGraphics.Clear()
                End If

                If I32Side = 0 Then '스테이지 A; 왼쪽 사이드 얼라인일 경우
                    If Not OResult.OLeft Is Nothing AndAlso (I32LogicalSide = 0) Then
                        If (OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.OLeft.F64X
                            OPointMarker.Y = OResult.OLeft.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpALeft.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                    If Not OResult.ORight Is Nothing AndAlso (I32LogicalSide = 1) Then
                        If (OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.ORight.F64X
                            OPointMarker.Y = OResult.ORight.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpALeft.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If

                Else '오른쪽 사이드 얼라인일 경우 
                    If (Not OResult.OLeft Is Nothing) AndAlso (I32LogicalSide = 0) Then
                        If (OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.OLeft.F64X
                            OPointMarker.Y = OResult.OLeft.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpARight.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                    If Not OResult.ORight Is Nothing AndAlso (I32LogicalSide = 1) Then
                        If (OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.ORight.F64X
                            OPointMarker.Y = OResult.ORight.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpARight.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                End If
                MyBase.BeginInvoke(New CAlignmentTool.PartialDisplayHandler(AddressOf Me.DisplayAMarkLeft0Right1), OResult, I32Side, I32LogicalSide)
            Else
                DisplayAData(OResult, I32Side, I32LogicalSide)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            'Monitor.Exit(Me.m_OALeftInterrupt)
            'Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub


    Private Sub DisplayAData(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)

          
            'If MyBase.InvokeRequired = True Then
            '    MyBase.BeginInvoke(New CAlignmentTool.PartialDisplayDataHandler(AddressOf Me.DisplayAData), OResult, I32Side, I32LogicalSide)
            'Else
            If (OResult.EResult = ERESULT.RETRY) Then
                Me.LblAAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 3).ToString
                Me.LblAAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 3).ToString
                Me.LblAAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 3).ToString
                Me.LblAAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 4).ToString
                Me.LblAAlignmentLeftXCurrent.ForeColor = Color.Black
                Me.LblAAlignmentRightXCurrent.ForeColor = Color.Black
                Me.LblAAlignmentYCurrent.ForeColor = Color.Black
                Me.LblAAlignmentTCurrent.ForeColor = Color.Black
                Me.LblAAlignmentLeftXCurrent.BackColor = Color.White
                Me.LblAAlignmentRightXCurrent.BackColor = Color.White
                Me.LblAAlignmentYCurrent.BackColor = Color.White
                Me.LblAAlignmentTCurrent.BackColor = Color.White
                ' jht Retry & TactTime

                Me.LblAStageTotalRetry.ForeColor = Color.Black
                Me.LblAStageTotalRetry.BackColor = Color.White
                Me.LblAStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                Me.LblAStageTotalTimeElapsed.ForeColor = Color.Black
                Me.LblAStageTotalTimeElapsed.BackColor = Color.White
                Me.LblAStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
            ElseIf (OResult.EResult = ERESULT.OK) Then
                Me.LblAAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 3).ToString
                Me.LblAAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 3).ToString
                Me.LblAAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 3).ToString
                Me.LblAAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 4).ToString
                Me.LblAAlignmentLeftXCurrent.ForeColor = Color.White
                Me.LblAAlignmentRightXCurrent.ForeColor = Color.White
                Me.LblAAlignmentYCurrent.ForeColor = Color.White
                Me.LblAAlignmentTCurrent.ForeColor = Color.White
                Me.LblAAlignmentLeftXCurrent.BackColor = Color.ForestGreen
                Me.LblAAlignmentRightXCurrent.BackColor = Color.ForestGreen
                Me.LblAAlignmentYCurrent.BackColor = Color.ForestGreen
                Me.LblAAlignmentTCurrent.BackColor = Color.ForestGreen
                ' jht Retry & TactTime

                Me.LblAStageTotalRetry.ForeColor = Color.White
                Me.LblAStageTotalRetry.BackColor = Color.ForestGreen
                Me.LblAStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                Me.LblAStageTotalTimeElapsed.ForeColor = Color.White
                Me.LblAStageTotalTimeElapsed.BackColor = Color.ForestGreen
                Me.LblAStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + "." + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
            ElseIf (OResult.EResult = ERESULT.NG) Then
                Me.LblAAlignmentLeftXCurrent.Text = "NG"
                Me.LblAAlignmentRightXCurrent.Text = "NG"
                Me.LblAAlignmentYCurrent.Text = "NG"
                Me.LblAAlignmentTCurrent.Text = "NG"
                Me.LblAAlignmentLeftXCurrent.ForeColor = Color.White
                Me.LblAAlignmentRightXCurrent.ForeColor = Color.White
                Me.LblAAlignmentYCurrent.ForeColor = Color.White
                Me.LblAAlignmentTCurrent.ForeColor = Color.White
                Me.LblAAlignmentLeftXCurrent.BackColor = Color.Red
                Me.LblAAlignmentRightXCurrent.BackColor = Color.Red
                Me.LblAAlignmentYCurrent.BackColor = Color.Red
                Me.LblAAlignmentTCurrent.BackColor = Color.Red
                ' jht Retry & TactTime

                Me.LblAStageTotalRetry.ForeColor = Color.White
                Me.LblAStageTotalTimeElapsed.ForeColor = Color.White
                Me.LblAStageTotalRetry.BackColor = Color.Red
                Me.LblAStageTotalRetry.Text = "-"
                Me.LblAStageTotalTimeElapsed.BackColor = Color.Red
                Me.LblAStageTotalTimeElapsed.Text = "-"
            End If
            If (Not OResult Is Nothing AndAlso Not OResult.OLeft Is Nothing AndAlso Not OResult.ORight Is Nothing) Then
                'End If
                Me.LblALeftScore.Text = OResult.OLeft.F64Score.ToString("0.0")
                Me.LblARightScore.Text = OResult.ORight.F64Score.ToString("0.0")
                If (OResult.OLeft.F64Score > 100) Then
                    Me.LblALeftScore.Text = 100
                End If
                If (OResult.ORight.F64Score > 100) Then
                    Me.LblARightScore.Text = 100
                End If

                If (OResult.OLeft.BOK = False) Then
                    Me.LblALeftScore.BackColor = Color.DarkRed
                Else
                    Me.LblALeftScore.BackColor = Color.ForestGreen
                End If
                If (OResult.ORight.BOK = False) Then
                    Me.LblARightScore.BackColor = Color.DarkRed
                Else
                    Me.LblARightScore.BackColor = Color.ForestGreen
                End If

                'Me.LblAStageTotalRetry.BackColor = Color.ForestGreen
                'Me.LblAStageTotalTimeElapsed.BackColor = Color.ForestGreen
                'Me.LblAStageTotalRetry.ForeColor = Color.White
                'Me.LblAStageTotalTimeElapsed.ForeColor = Color.White
                'Me.LblAStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                'Me.LblAStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub

    Private Sub DisplayBData(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
        Try
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            'If MyBase.InvokeRequired = True Then
            '    MyBase.BeginInvoke(New CAlignmentTool.PartialDisplayDataHandler(AddressOf Me.DisplayBData), OResult, I32Side, I32LogicalSide)
            'Else
        
            If (OResult.EResult = ERESULT.RETRY) Then
                Me.LblBAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 3).ToString
                Me.LblBAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 3).ToString
                Me.LblBAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 3).ToString
                Me.LblBAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 4).ToString
                Me.LblBAlignmentLeftXCurrent.ForeColor = Color.Black
                Me.LblBAlignmentRightXCurrent.ForeColor = Color.Black
                Me.LblBAlignmentYCurrent.ForeColor = Color.Black
                Me.LblBAlignmentTCurrent.ForeColor = Color.Black
                Me.LblBAlignmentLeftXCurrent.BackColor = Color.White
                Me.LblBAlignmentRightXCurrent.BackColor = Color.White
                Me.LblBAlignmentYCurrent.BackColor = Color.White
                Me.LblBAlignmentTCurrent.BackColor = Color.White
                ' jht Retry & TactTime
                Me.LblBStageTotalRetry.ForeColor = Color.Black
                Me.LblBStageTotalRetry.BackColor = Color.White
                Me.LblBStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                Me.LblBStageTotalTimeElapsed.ForeColor = Color.Black
                Me.LblBStageTotalTimeElapsed.BackColor = Color.White
                Me.LblBStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
            ElseIf (OResult.EResult = ERESULT.OK) Then
                Me.LblBAlignmentLeftXCurrent.Text = Math.Round(OResult.F64MotionLeftX, 3).ToString
                Me.LblBAlignmentRightXCurrent.Text = Math.Round(OResult.F64MotionRightX, 3).ToString
                Me.LblBAlignmentYCurrent.Text = Math.Round(OResult.F64MotionY, 3).ToString
                Me.LblBAlignmentTCurrent.Text = Math.Round(OResult.F64MotionT, 4).ToString
                Me.LblBAlignmentLeftXCurrent.ForeColor = Color.White
                Me.LblBAlignmentRightXCurrent.ForeColor = Color.White
                Me.LblBAlignmentYCurrent.ForeColor = Color.White
                Me.LblBAlignmentTCurrent.ForeColor = Color.White
                Me.LblBAlignmentLeftXCurrent.BackColor = Color.ForestGreen
                Me.LblBAlignmentRightXCurrent.BackColor = Color.ForestGreen
                Me.LblBAlignmentYCurrent.BackColor = Color.ForestGreen
                Me.LblBAlignmentTCurrent.BackColor = Color.ForestGreen
                ' jht Retry & TactTime
                Me.LblBStageTotalRetry.ForeColor = Color.White
                Me.LblBStageTotalRetry.BackColor = Color.ForestGreen
                Me.LblBStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                Me.LblBStageTotalTimeElapsed.ForeColor = Color.White
                Me.LblBStageTotalTimeElapsed.BackColor = Color.ForestGreen
                Me.LblBStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + "." + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"
            ElseIf (OResult.EResult = ERESULT.NG) Then
                Me.LblBAlignmentLeftXCurrent.Text = "NG"
                Me.LblBAlignmentRightXCurrent.Text = "NG"
                Me.LblBAlignmentYCurrent.Text = "NG"
                Me.LblBAlignmentTCurrent.Text = "NG"
                Me.LblBAlignmentLeftXCurrent.ForeColor = Color.White
                Me.LblBAlignmentRightXCurrent.ForeColor = Color.White
                Me.LblBAlignmentYCurrent.ForeColor = Color.White
                Me.LblBAlignmentTCurrent.ForeColor = Color.White
                Me.LblBAlignmentLeftXCurrent.BackColor = Color.Red
                Me.LblBAlignmentRightXCurrent.BackColor = Color.Red
                Me.LblBAlignmentYCurrent.BackColor = Color.Red
                Me.LblBAlignmentTCurrent.BackColor = Color.Red
                ' jht Retry & TactTime
                Me.LblBStageTotalRetry.ForeColor = Color.White
                Me.LblBStageTotalTimeElapsed.ForeColor = Color.White
                Me.LblBStageTotalRetry.BackColor = Color.Red
                Me.LblBStageTotalRetry.Text = "-"
                Me.LblBStageTotalTimeElapsed.BackColor = Color.Red
                Me.LblBStageTotalTimeElapsed.Text = "-"
            End If
            If (Not OResult Is Nothing AndAlso Not OResult.OLeft Is Nothing AndAlso Not OResult.ORight Is Nothing) Then

                'End If
                Me.LblBLeftScore.Text = OResult.OLeft.F64Score.ToString("0.0")
                Me.LblBRightScore.Text = OResult.ORight.F64Score.ToString("0.0")
                If (OResult.OLeft.F64Score > 100) Then
                    Me.LblBLeftScore.Text = 100
                End If
                If (OResult.ORight.F64Score > 100) Then
                    Me.LblBRightScore.Text = 100
                End If

                If (OResult.OLeft.BOK = False) Then
                    Me.LblBLeftScore.BackColor = Color.DarkRed
                Else
                    Me.LblBLeftScore.BackColor = Color.ForestGreen
                End If
                If (OResult.ORight.BOK = False) Then
                    Me.LblBRightScore.BackColor = Color.DarkRed
                Else
                    Me.LblBRightScore.BackColor = Color.ForestGreen
                End If

                'Me.LblBStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"

                'Me.LblBStageTotalRetry.BackColor = Color.ForestGreen
                'Me.LblBStageTotalTimeElapsed.BackColor = Color.ForestGreen
                'Me.LblBStageTotalRetry.ForeColor = Color.White
                'Me.LblBStageTotalTimeElapsed.ForeColor = Color.White
                'Me.LblBStageTotalRetry.Text = OResult.F64RetryCount.ToString()
                'Me.LblBStageTotalTimeElapsed.Text = OResult.OTimeElapsed.Seconds.ToString() + " . " + OResult.OTimeElapsed.Milliseconds.ToString() + " Sec"

            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub

    Private Sub DisplayBMarkLeft0Right1(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
        Try
            If MyBase.InvokeRequired = True Then

                'Monitor.Enter(Me.m_OBLeftInterrupt)
                'Monitor.Enter(Me.m_OBRightInterrupt)

                If I32Side = 0 Then
                    Me.CdpBLeft.StaticGraphics.Clear()
                Else
                    Me.CdpBRight.StaticGraphics.Clear()
                End If

                If I32Side = 0 Then
                    If (Not OResult.OLeft Is Nothing) AndAlso (I32LogicalSide = 0) Then
                        If (OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.OLeft.F64X
                            OPointMarker.Y = OResult.OLeft.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpBLeft.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                    If (Not OResult.ORight Is Nothing) AndAlso (I32LogicalSide = 1) Then
                        If (OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.ORight.F64X
                            OPointMarker.Y = OResult.ORight.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpBLeft.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                Else
                    If Not OResult.OLeft Is Nothing AndAlso (I32LogicalSide = 0) Then
                        If (OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.OLeft.F64X
                            OPointMarker.Y = OResult.OLeft.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpBRight.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                    If Not OResult.ORight Is Nothing AndAlso (I32LogicalSide = 1) Then
                        If (OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True) Then
                            Dim OPointMarker As CogPointMarker = New CogPointMarker()
                            OPointMarker.X = OResult.ORight.F64X
                            OPointMarker.Y = OResult.ORight.F64Y
                            OPointMarker.Color = CogColorConstants.Red
                            OPointMarker.SizeInScreenPixels = 100
                            Me.CdpBRight.StaticGraphics.Add(OPointMarker, "Result")
                        End If
                    End If
                End If

                MyBase.BeginInvoke(New CAlignmentTool.PartialDisplayHandler(AddressOf Me.DisplayBMarkLeft0Right1), OResult, I32Side, I32LogicalSide)
            Else
                DisplayBData(OResult, I32Side, I32LogicalSide)
            End If
            'Monitor.Exit(Me.m_OBLeftInterrupt)
            'Monitor.Exit(Me.m_OBRightInterrupt)

        Catch ex As Exception
            CError.Throw(ex)
        Finally
        End Try
    End Sub
    Private Sub DisplayAMark(ByVal OResult As CAlignmentResult)
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)

            Me.CdpALeft.StaticGraphics.Clear()
            Me.CdpARight.StaticGraphics.Clear()

            If Not OResult.OLeft Is Nothing Then
                If (OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True) Then
                    Dim OPointMarker As CogPointMarker = New CogPointMarker()
                    OPointMarker.X = OResult.OLeft.F64X
                    OPointMarker.Y = OResult.OLeft.F64Y
                    OPointMarker.Color = CogColorConstants.Red
                    OPointMarker.SizeInScreenPixels = 100
                    Me.CdpALeft.StaticGraphics.Add(OPointMarker, "Result")
                End If
            End If
            If Not OResult.ORight Is Nothing Then
                If (OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True) Then
                    Dim OPointMarker As CogPointMarker = New CogPointMarker()
                    OPointMarker.X = OResult.ORight.F64X
                    OPointMarker.Y = OResult.ORight.F64Y
                    OPointMarker.Color = CogColorConstants.Red
                    OPointMarker.SizeInScreenPixels = 100
                    Me.CdpARight.StaticGraphics.Add(OPointMarker, "Result")
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub


    Private Sub DisplayAEdge(ByVal OResult As CInspectionResult)
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)

            Me.CdpALeft.StaticGraphics.Clear()
            Me.CdpARight.StaticGraphics.Clear()

            If (OResult.OLeft.BInspected = True) Then
                Dim OLine As CogLine = New CogLine()
                OLine.X = OResult.OLeft.OEdgeInfo.F64X
                OLine.Rotation = CogMisc.DegToRad(90)
                OLine.Color = CogColorConstants.Magenta
                Me.CdpALeft.StaticGraphics.Add(OLine, "Edge")
            End If

            If (OResult.ORight.BInspected = True) Then
                Dim OLine As CogLine = New CogLine()
                OLine.X = OResult.ORight.OEdgeInfo.F64X
                OLine.Rotation = CogMisc.DegToRad(90)
                OLine.Color = CogColorConstants.Magenta
                Me.CdpARight.StaticGraphics.Add(OLine, "Edge")
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
        End Try
    End Sub


    Private Sub DisplayBMark(ByVal OResult As CAlignmentResult)
        Try
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            Me.CdpBLeft.StaticGraphics.Clear()
            Me.CdpBRight.StaticGraphics.Clear()

            If Not OResult.OLeft Is Nothing Then
                If (OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True) Then
                    Dim OPointMarker As CogPointMarker = New CogPointMarker()
                    OPointMarker.X = OResult.OLeft.F64X
                    OPointMarker.Y = OResult.OLeft.F64Y
                    OPointMarker.Color = CogColorConstants.Red
                    OPointMarker.SizeInScreenPixels = 100
                    Me.CdpBLeft.StaticGraphics.Add(OPointMarker, "Result")
                End If
            End If
            If Not OResult.ORight Is Nothing Then
                If (OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True) Then
                    Dim OPointMarker As CogPointMarker = New CogPointMarker()
                    OPointMarker.X = OResult.ORight.F64X
                    OPointMarker.Y = OResult.ORight.F64Y
                    OPointMarker.Color = CogColorConstants.Red
                    OPointMarker.SizeInScreenPixels = 100
                    Me.CdpBRight.StaticGraphics.Add(OPointMarker, "Result")
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Sub DisplayBEdge(ByVal OResult As CInspectionResult)
        Try
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            Me.CdpBLeft.StaticGraphics.Clear()
            Me.CdpBRight.StaticGraphics.Clear()

            If (OResult.OLeft.BInspected = True) Then
                Dim OLine As CogLine = New CogLine()
                OLine.X = OResult.OLeft.OEdgeInfo.F64X
                OLine.Rotation = CogMisc.DegToRad(90)
                OLine.Color = CogColorConstants.Magenta
                Me.CdpBLeft.StaticGraphics.Add(OLine, "Edge")
            End If

            If (OResult.ORight.BInspected = True) Then
                Dim OLine As CogLine = New CogLine()
                OLine.X = OResult.ORight.OEdgeInfo.F64X
                OLine.Rotation = CogMisc.DegToRad(90)
                OLine.Color = CogColorConstants.Magenta
                Me.CdpBRight.StaticGraphics.Add(OLine, "Edge")
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub


    Private Function CalcLengthAboutALeft(ByRef BSendValue) As Double
        BSendValue = False
        Dim F64Result As Double = 0

        Try
            Monitor.Enter(Me.m_OALeftInterrupt)

            Dim OPoint As Point = New Point(MousePosition.X, MousePosition.Y)
            OPoint = Me.CdpALeft.PointToClient(OPoint)

            Dim F64X As Double = 0
            Dim F64Y As Double = 0
            Dim OTransform As CogTransform2DLinear = Me.CdpALeft.GetTransform("#", "*")
            OTransform.MapPoint(OPoint.X, OPoint.Y, F64X, F64Y)

            Dim F64Width As Double = 0
            Dim F64Height As Double = 0
            If (Me.m_ArrBIsSecond(0) = False) Then
                Me.m_ArrBIsSecond(0) = True

                Me.m_ArrOLineSegment(0).SetStartEnd(Me.m_ArrOLineSegment(0).StartX, Me.m_ArrOLineSegment(0).StartY, F64X, F64Y)
                Me.m_ArrOLineSegment(0).SetStartEnd(F64X, F64Y, Me.m_ArrOLineSegment(0).EndX, Me.m_ArrOLineSegment(0).EndY)
                Me.m_ArrOLineX1(0).X = F64X
                Me.m_ArrOLineX2(0).X = F64X
                Me.m_ArrOLineSegment(0).Visible = True
                Me.m_ArrOLineX2(0).Visible = True
            ElseIf (Me.m_ArrBIsSecond(0) = True) Then
                Me.m_ArrBIsSecond(0) = False
                Me.m_BCaliperAbleAL = False

                Me.m_ArrOLineSegment(0).SetStartEnd(Me.m_ArrOLineSegment(0).StartX, Me.m_ArrOLineSegment(0).StartY, F64X, F64Y)
                Me.m_ArrOLineX2(0).X = F64X

                F64Width = Math.Abs(Me.m_ArrOLineSegment(0).StartX - Me.m_ArrOLineSegment(0).EndX)
                F64Height = Math.Abs(Me.m_ArrOLineSegment(0).StartY - Me.m_ArrOLineSegment(0).EndY)
                Me.m_ArrOWidth(0).Text = "Width : " & Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Width, 3) & "pix)"
                Me.m_ArrOHeight(0).Text = "Height : " & Math.Round(F64Height * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Height, 3) & "pix)"
                Me.m_ArrOWidth(0).Visible = True
                Me.m_ArrOHeight(0).Visible = True

                BSendValue = True
                F64Result = Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL, 4)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
        End Try

        Return F64Result
    End Function


    Private Function CalcLengthAboutARight(ByRef BSendValue) As Double
        BSendValue = False
        Dim F64Result As Double = 0

        Try
            Monitor.Enter(Me.m_OARightInterrupt)

            Dim OPoint As Point = New Point(MousePosition.X, MousePosition.Y)
            OPoint = Me.CdpARight.PointToClient(OPoint)

            Dim F64X As Double = 0
            Dim F64Y As Double = 0
            Dim OTransform As CogTransform2DLinear = Me.CdpARight.GetTransform("#", "*")
            OTransform.MapPoint(OPoint.X, OPoint.Y, F64X, F64Y)

            Dim F64Width As Double = 0
            Dim F64Height As Double = 0
            If (Me.m_ArrBIsSecond(1) = False) Then
                Me.m_ArrBIsSecond(1) = True

                Me.m_ArrOLineSegment(1).SetStartEnd(Me.m_ArrOLineSegment(1).StartX, Me.m_ArrOLineSegment(1).StartY, F64X, F64Y)
                Me.m_ArrOLineSegment(1).SetStartEnd(F64X, F64Y, Me.m_ArrOLineSegment(1).EndX, Me.m_ArrOLineSegment(1).EndY)
                Me.m_ArrOLineX1(1).X = F64X
                Me.m_ArrOLineX2(1).X = F64X
                Me.m_ArrOLineSegment(1).Visible = True
                Me.m_ArrOLineX2(1).Visible = True
            ElseIf (Me.m_ArrBIsSecond(1) = True) Then
                Me.m_ArrBIsSecond(1) = False
                Me.m_BCaliperAbleAR = False

                Me.m_ArrOLineSegment(1).SetStartEnd(Me.m_ArrOLineSegment(1).StartX, Me.m_ArrOLineSegment(1).StartY, F64X, F64Y)
                Me.m_ArrOLineX2(1).X = F64X

                F64Width = Math.Abs(Me.m_ArrOLineSegment(1).StartX - Me.m_ArrOLineSegment(1).EndX)
                F64Height = Math.Abs(Me.m_ArrOLineSegment(1).StartY - Me.m_ArrOLineSegment(1).EndY)
                Me.m_ArrOWidth(1).Text = "Width : " & Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Width, 3) & "pix)"
                Me.m_ArrOHeight(1).Text = "Height : " & Math.Round(F64Height * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Height, 3) & "pix)"
                Me.m_ArrOWidth(1).Visible = True
                Me.m_ArrOHeight(1).Visible = True

                BSendValue = True
                F64Result = Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL, 4)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OARightInterrupt)
        End Try

        Return F64Result
    End Function


    Private Function CalcLengthAboutBLeft(ByRef BSendValue) As Double
        BSendValue = False
        Dim F64Result As Double = 0

        Try
            Monitor.Enter(Me.m_OBLeftInterrupt)

            Dim OPoint As Point = New Point(MousePosition.X, MousePosition.Y)
            OPoint = Me.CdpBLeft.PointToClient(OPoint)

            Dim F64X As Double = 0
            Dim F64Y As Double = 0
            Dim OTransform As CogTransform2DLinear = Me.CdpBLeft.GetTransform("#", "*")
            OTransform.MapPoint(OPoint.X, OPoint.Y, F64X, F64Y)

            Dim F64Width As Double = 0
            Dim F64Height As Double = 0
            If (Me.m_ArrBIsSecond(2) = False) Then
                Me.m_ArrBIsSecond(2) = True

                Me.m_ArrOLineSegment(2).SetStartEnd(Me.m_ArrOLineSegment(2).StartX, Me.m_ArrOLineSegment(2).StartY, F64X, F64Y)
                Me.m_ArrOLineSegment(2).SetStartEnd(F64X, F64Y, Me.m_ArrOLineSegment(2).EndX, Me.m_ArrOLineSegment(2).EndY)
                Me.m_ArrOLineX1(2).X = F64X
                Me.m_ArrOLineX2(2).X = F64X
                Me.m_ArrOLineSegment(2).Visible = True
                Me.m_ArrOLineX2(2).Visible = True
            ElseIf (Me.m_ArrBIsSecond(2) = True) Then
                Me.m_ArrBIsSecond(2) = False
                Me.m_BCaliperAbleBL = False

                Me.m_ArrOLineSegment(2).SetStartEnd(Me.m_ArrOLineSegment(2).StartX, Me.m_ArrOLineSegment(2).StartY, F64X, F64Y)
                Me.m_ArrOLineX2(2).X = F64X

                F64Width = Math.Abs(Me.m_ArrOLineSegment(2).StartX - Me.m_ArrOLineSegment(2).EndX)
                F64Height = Math.Abs(Me.m_ArrOLineSegment(2).StartY - Me.m_ArrOLineSegment(2).EndY)
                Me.m_ArrOWidth(2).Text = "Width : " & Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Width, 3) & "pix)"
                Me.m_ArrOHeight(2).Text = "Height : " & Math.Round(F64Height * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Height, 3) & "pix)"
                Me.m_ArrOWidth(2).Visible = True
                Me.m_ArrOHeight(2).Visible = True

                BSendValue = True
                F64Result = Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL, 4)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBLeftInterrupt)
        End Try

        Return F64Result
    End Function


    Private Function CalcLengthAboutBRight(ByRef BSendValue) As Double
        BSendValue = False
        Dim F64Result As Double = 0

        Try
            Monitor.Enter(Me.m_OBRightInterrupt)

            Dim OPoint As Point = New Point(MousePosition.X, MousePosition.Y)
            OPoint = Me.CdpBRight.PointToClient(OPoint)

            Dim F64X As Double = 0
            Dim F64Y As Double = 0
            Dim OTransform As CogTransform2DLinear = Me.CdpBRight.GetTransform("#", "*")
            OTransform.MapPoint(OPoint.X, OPoint.Y, F64X, F64Y)

            Dim F64Width As Double = 0
            Dim F64Height As Double = 0
            If (Me.m_ArrBIsSecond(3) = False) Then
                Me.m_ArrBIsSecond(3) = True
                Me.m_ArrOLineSegment(3).SetStartEnd(Me.m_ArrOLineSegment(3).StartX, Me.m_ArrOLineSegment(3).StartY, F64X, F64Y)
                Me.m_ArrOLineSegment(3).SetStartEnd(F64X, F64Y, Me.m_ArrOLineSegment(3).EndX, Me.m_ArrOLineSegment(3).EndY)
                Me.m_ArrOLineX1(3).X = F64X
                Me.m_ArrOLineX2(3).X = F64X
                Me.m_ArrOLineSegment(3).Visible = True
                Me.m_ArrOLineX2(3).Visible = True
            ElseIf (Me.m_ArrBIsSecond(3) = True) Then
                Me.m_ArrBIsSecond(3) = False
                Me.m_ArrOLineSegment(3).SetStartEnd(Me.m_ArrOLineSegment(3).StartX, Me.m_ArrOLineSegment(3).StartY, F64X, F64Y)
                Me.m_ArrOLineX2(3).X = F64X
                Me.m_BCaliperAbleBR = False

                F64Width = Math.Abs(Me.m_ArrOLineSegment(3).StartX - Me.m_ArrOLineSegment(3).EndX)
                F64Height = Math.Abs(Me.m_ArrOLineSegment(3).StartY - Me.m_ArrOLineSegment(3).EndY)
                Me.m_ArrOWidth(3).Text = "Width : " & Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Width, 3) & "pix)"
                Me.m_ArrOHeight(3).Text = "Height : " & Math.Round(F64Height * CEnvironment.LEN_PER_PIXEL * 1000, 1) & "um" & "(" & Math.Round(F64Height, 3) & "pix)"
                Me.m_ArrOWidth(3).Visible = True
                Me.m_ArrOHeight(3).Visible = True

                BSendValue = True
                F64Result = Math.Round(F64Width * CEnvironment.LEN_PER_PIXEL, 4)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try

        Return F64Result
    End Function


    Public Sub ReplaceScreenMode(ByVal EScreenMode As ESCREEN_MODE)
        Try
            Monitor.Enter(Me.m_OALeftInterrupt)
            Monitor.Enter(Me.m_OARightInterrupt)
            Monitor.Enter(Me.m_OBLeftInterrupt)
            Monitor.Enter(Me.m_OBRightInterrupt)

            If (EScreenMode = ESCREEN_MODE.ORIGINAL) Then
                Me.m_EScreenMode = ESCREEN_MODE.ORIGINAL

                Me.PnlTitle.Visible = True
                Me.PnlRight.Visible = True
                Me.PnlButtom.Visible = True
                Me.PnlALeft.Visible = True
                Me.PnlARight.Visible = True
                Me.PnlBLeft.Visible = True
                Me.PnlBRight.Visible = True

                Me.PnlAImage.Dock = DockStyle.Top
                Me.PnlALeft.Dock = DockStyle.Left
                Me.PnlBLeft.Dock = DockStyle.Left

                Me.PnlAImage.Size = New Size(Me.PnlLeft.Size.Width, Me.PnlLeft.Size.Height / 2)
                Me.PnlALeft.Size = New Size(Me.PnlAImage.Size.Width / 2, Me.PnlAImage.Height)
                Me.PnlBLeft.Size = New Size(Me.PnlBImage.Size.Width / 2, Me.PnlBImage.Height)
            Else
                If (Me.m_EScreenMode = ESCREEN_MODE.ORIGINAL) Then
                    Me.m_EScreenMode = ESCREEN_MODE.FULL_ALL

                    Me.PnlTitle.Visible = False
                    Me.PnlRight.Visible = False
                    Me.PnlButtom.Visible = False

                    Me.PnlAImage.Size = New Size(Me.PnlLeft.Size.Width, Me.PnlLeft.Size.Height / 2)
                    Me.PnlALeft.Size = New Size(Me.PnlAImage.Size.Width / 2, Me.PnlAImage.Height)
                    Me.PnlBLeft.Size = New Size(Me.PnlBImage.Size.Width / 2, Me.PnlBImage.Height)
                ElseIf (Me.m_EScreenMode = ESCREEN_MODE.FULL_ONE) Then
                    Me.m_EScreenMode = ESCREEN_MODE.FULL_ALL

                    Me.PnlAImage.Visible = True
                    Me.PnlBImage.Visible = True
                    Me.PnlALeft.Visible = True
                    Me.PnlARight.Visible = True
                    Me.PnlBLeft.Visible = True
                    Me.PnlBRight.Visible = True

                    Me.PnlAImage.Dock = DockStyle.Top
                    Me.PnlALeft.Dock = DockStyle.Left
                    Me.PnlBLeft.Dock = DockStyle.Left

                    Me.PnlAImage.Size = New Size(Me.PnlLeft.Size.Width, Me.PnlLeft.Size.Height / 2)
                    Me.PnlALeft.Size = New Size(Me.PnlAImage.Size.Width / 2, Me.PnlAImage.Height)
                    Me.PnlBLeft.Size = New Size(Me.PnlBImage.Size.Width / 2, Me.PnlBImage.Height)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OALeftInterrupt)
            Monitor.Exit(Me.m_OARightInterrupt)
            Monitor.Exit(Me.m_OBLeftInterrupt)
            Monitor.Exit(Me.m_OBRightInterrupt)
        End Try
    End Sub

    Private Sub NudDistX_ValueChanged(sender As Object, e As EventArgs) Handles NudDistX.ValueChanged
        CEnvironment.It.MinDistanceX = Convert.ToDouble(NudDistX.Value)
        CEnvironment.It.Commit()
    End Sub

    Private Sub NudDistY_ValueChanged(sender As Object, e As EventArgs) Handles NudDistY.ValueChanged
        CEnvironment.It.MinDistanceY = Convert.ToDouble(NudDistY.Value)
        CEnvironment.It.Commit()
    End Sub
#End Region

End Class

#Region "ENUM"
Public Enum ESCREEN_MODE As Byte
    ORIGINAL
    FULL_ALL
    FULL_ONE
End Enum
#End Region
