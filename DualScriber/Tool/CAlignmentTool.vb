Imports System.Text
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.IO
Imports Cognex.VisionPro
Imports Jhjo.Common
Imports Jhjo.DB
Imports Jhjo.Tool


Public Class CAlignmentTool
    Implements IDisposable

#Region "CONST"
    Private Const WAIT_TICK As Long = 100000000 '10s
    Private Const EQUIP_INFO_FILE As String = "EquipInfo.ini"
    Private Const EQUIP_INFO_FILE_PARTIAL As String = "EquipInfoPartial.ini"
#End Region


#Region "VARIABLE"
    'Common
    Private m_EAnalysis As EAnalysis = EAnalysis.NONE
    Private m_EStage As ESTAGE = EStage.NONE
    Private m_ORecipe As CAlignmentRecipe = Nothing
    Private m_OAlgorithm As CAlignmentAlogrithm = Nothing
    Private m_OLeft As CAnalysisTool = Nothing
    Private m_ORight As CAnalysisTool = Nothing
    Private m_OInterrupt As Object = Nothing

    'Ready Calibration
    Private m_F64SectionXY As Double = 0
    Private m_I32PointXY As Integer = 0
    Private m_F64SectionT As Double = 0
    Private m_I32PointT As Integer = 0


    'Run Calibration
    Private m_BStartCalibration As Boolean = False
    Private m_BRunCalibration As Boolean = False
    Private m_BProcCalibration As Boolean = False
    Private m_BProcMovement As Boolean = False
    Private m_I64StartMovementTick As Long = Long.MaxValue

    Private m_I32CalibrationCount As Integer = 0
    Private m_I32CalibrationIndex As Integer = 0
    Private m_F64CalibrationMotionLeftX As Double = 0
    Private m_F64CalibrationMotionRightX As Double = 0
    Private m_F64CalibrationMotionY As Double = 0

    'Run Alignment
    Private m_BRunAlignment_A As Boolean = False
    Private m_BRunAlignment_B As Boolean = False
    Private m_F64AlignmentStdMotionLeftX As Double = 0
    Private m_F64AlignmentStdMotionRightX As Double = 0
    Private m_F64AlignmentStdMotionY As Double = 0
    Private m_F64AlignmentMotionLeftX As Double = 0
    Private m_F64AlignmentMotionRightX As Double = 0
    Private m_F64AlignmentMotionY As Double = 0
    Private m_F64AlignmentMotionT As Double = 0

    'Run Edge
    Private m_BRunEdge As Boolean = False
    Private m_ELeftRequest As EEDGE_REQUEST = EEDGE_REQUEST.NONE
    Private m_ERightRequest As EEDGE_REQUEST = EEDGE_REQUEST.NONE
    Private m_F64EdgeMotionLeftX As Double = 0
    Private m_F64EdgeMotionRightX As Double = 0
    Private m_F64EdgeMotionY As Double = 0
    Private m_OEdgeTopResult As CInspectionResult = Nothing
    Private m_OEdgeBottomResult As CInspectionResult = Nothing

    'Common
    Private m_F64X As Double = 0
    Private m_F64Y As Double = 0
    Private m_F64T As Double = 0
    Private m_F64BeforeX As Double = 0
    Private m_F64BeforeY As Double = 0
    Private m_F64BeforeT As Double = 0

    Private m_F64ResultLeftX As Double = 0
    Private m_F64ResultRightX As Double = 0
    Private m_F64ResultY As Double = 0
    Private m_F64ResultT As Double = 0

    'Thread
    Private m_OWorker As Thread = Nothing
    Private m_BDoWork As Boolean = False

    'CallBack
    Private m_OCalibrationStart As CalibrationStartHandler = Nothing
    Private m_OCalibrationRan As CalibrationRanHandler = Nothing
    Private m_OCalibrationFinish As CalibrationFinishHandler = Nothing
    Private m_OAlignmentRan As AlignmentRanHandler = Nothing
    Private m_ODisplayPartial As PartialDisplayHandler = Nothing

    Private m_ODisplayPartialData As PartialDisplayDataHandler = Nothing
    Private m_OEdgeRan As EdgeRanHandler = Nothing
    Private m_OOpenMessageBox As OpenMessageBoxHandler = Nothing

    '20170822
    Private m_OPartialCalibrationRan As PartialCalibrationRanHandler = Nothing
    Private m_OGraphicClear As ClearGraphicHandler = Nothing
    '20170822
    Private m_OTmpLeftMarkResult As CMarkResult = Nothing
    Private m_OTmpRightMarkResult As CMarkResult = Nothing

    Private m_OTmpResultforVectorAdditionA As CMarkResult = Nothing
    Private m_OTmpResultforVectorAdditionB As CMarkResult = Nothing

    Private m_BWaitForShift As Boolean = False
    'Private m_BShift As Boolean = False
    Private m_BFirstCalibrationComplete As Boolean = False
    Private m_BSecondCalibrationComplete As Boolean = False
    Private m_BLeftAlignmentComplete As Boolean = False
    Private m_BRightAlignmentComplete As Boolean = False

    Private m_BTmp As Boolean = False
    ' jht Retry 변수
    Private m_I32RetryCount As Integer = 0
    ' jht Tact
    Private m_OTimeElapsed As TimeSpan
    Private m_OTimeBegin As DateTime
    ' jht 시뮬레이션 모드
    Private m_iSimulationMode As Integer = 0

    Private m_BMarkRequest As Boolean = False

    Private m_IsGDM As Boolean = False
    Private m_I32DelayCount As Integer = 0
#End Region


#Region "DELEGATE & EVENT"
    Public Delegate Sub CalibrationStartHandler()
    Public Delegate Sub CalibrationRanHandler(ByVal OLeftResult As CMarkResult, ByVal ORightResult As CMarkResult)
    Public Delegate Sub CalibrationFinishHandler(ByVal BIsSuccess As Boolean, ByVal StrMessage As String)
    Public Delegate Sub AlignmentRanHandler(ByVal OResult As CAlignmentResult)
    Public Delegate Sub PartialDisplayHandler(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
    Public Delegate Sub PartialDisplayDataHandler(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)

    Public Delegate Sub EdgeRanHandler(ByVal OResult As CInspectionResult)
    Public Delegate Sub OpenMessageBoxHandler(ByVal StrMessage As String)
    '20170822
    Public Delegate Sub PartialCalibrationRanHandler(ByVal OResult As CMarkResult, ByVal I32Left0Right1 As Integer)
    Public Delegate Sub ClearGraphicHandler()
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property EStage() As ESTAGE
        Get
            Return Me.m_EStage
        End Get
    End Property

    Public ReadOnly Property OLeft() As CAnalysisTool
        Get
            Return Me.m_OLeft
        End Get
    End Property

    Public ReadOnly Property ORight() As CAnalysisTool
        Get
            Return Me.m_ORight
        End Get
    End Property

    Public Property ORecipe() As CAlignmentRecipe
        Get
            Return Me.m_ORecipe
        End Get
        Set(ByVal value As CAlignmentRecipe)
            Try
                If Not value Is Nothing Then
                    Me.m_ORecipe = value
                    Me.m_OLeft.ORecipe = value.OLeft
                    Me.m_ORight.ORecipe = value.ORight
                    If ((CMotionController.It.OPLC.GetBOversize_A() = 1 AndAlso Me.m_EStage = EStage.A) Or
                          (CMotionController.It.OPLC.GetBOversize_B() = 1 AndAlso Me.m_EStage = EStage.B)) Then
                        Me.LoadCalibration_Partial()
                    Else

                        Me.LoadCalibration()
                    End If
                Else
                    Me.m_ORecipe = Nothing
                    Me.m_OLeft.ORecipe = Nothing
                    Me.m_ORight.ORecipe = Nothing
                End If
            Catch ex As Exception
                CError.Throw(ex)
            End Try
        End Set
    End Property

    Public Property F64SectionXY() As Double
        Get
            Return Me.m_F64SectionXY
        End Get
        Set(ByVal value As Double)
            Me.m_F64SectionXY = value
        End Set
    End Property

    Public Property I32PointXY() As Integer
        Get
            Return Me.m_I32PointXY
        End Get
        Set(ByVal value As Integer)
            Me.m_I32PointXY = value
        End Set
    End Property

    Public Property F64SectionT() As Double
        Get
            Return Me.m_F64SectionT
        End Get
        Set(ByVal value As Double)
            Me.m_F64SectionT = value
        End Set
    End Property

    Public Property I32PointT() As Integer
        Get
            Return Me.m_I32PointT
        End Get
        Set(ByVal value As Integer)
            Me.m_I32PointT = value
        End Set
    End Property

    Public WriteOnly Property OCalibrationStart() As CalibrationStartHandler
        Set(ByVal value As CalibrationStartHandler)
            Me.m_OCalibrationStart = value
        End Set
    End Property

    Public WriteOnly Property OCalibrationRan() As CalibrationRanHandler
        Set(ByVal value As CalibrationRanHandler)
            Me.m_OCalibrationRan = value
        End Set
    End Property

    Public WriteOnly Property OCalibrationFinish() As CalibrationFinishHandler
        Set(ByVal value As CalibrationFinishHandler)
            Me.m_OCalibrationFinish = value
        End Set
    End Property

    Public WriteOnly Property OPartialCalibrationRan() As PartialCalibrationRanHandler
        Set(ByVal value As PartialCalibrationRanHandler)
            Me.m_OPartialCalibrationRan = value
        End Set
    End Property

    Public WriteOnly Property OGraphicClear() As ClearGraphicHandler
        Set(ByVal value As ClearGraphicHandler)
            Me.m_OGraphicClear = value
        End Set
    End Property

    Public WriteOnly Property OAlignmentRan() As AlignmentRanHandler
        Set(ByVal value As AlignmentRanHandler)
            Me.m_OAlignmentRan = value
        End Set
    End Property

    Public WriteOnly Property ODisplayPartial() As PartialDisplayHandler
        Set(ByVal value As PartialDisplayHandler)
            Me.m_ODisplayPartial = value
        End Set
    End Property

    Public WriteOnly Property ODisplayPartialData() As PartialDisplayDataHandler
        Set(ByVal value As PartialDisplayDataHandler)
            Me.m_ODisplayPartialData = value
        End Set
    End Property

    Public WriteOnly Property OEdgeRan() As EdgeRanHandler
        Set(ByVal value As EdgeRanHandler)
            Me.m_OEdgeRan = value
        End Set
    End Property

    Public WriteOnly Property OOpenMessageBox() As OpenMessageBoxHandler
        Set(ByVal value As OpenMessageBoxHandler)
            Me.m_OOpenMessageBox = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal EStage As ESTAGE, ByVal OStage As CAlignmentAlogrithm)
        Try
            Me.m_EStage = EStage
            Me.m_OAlgorithm = OStage
            Me.m_OAlgorithm.SetStageKind(EEQUIP_TYPE.STAGE_XYT)
            Me.m_OAlgorithm.SetMaxMarkCount(2)
            Me.m_OAlgorithm.SetUseMarkCount(2)
            Me.m_OLeft = New CAnalysisTool(EVIEW.LEFT, EStage)
            Me.m_ORight = New CAnalysisTool(EVIEW.RIGHT, EStage)
            Me.m_iSimulationMode = CEnvironment.It.SimulationMode()
            Me.m_OInterrupt = New Object()

            If (Me.m_EStage = DualScriber.ESTAGE.A) Then
                CMotionController.It.OPLC.OStageABeginCalibration = AddressOf Me.OPLC_BeginCalibration
                CMotionController.It.OPLC.OStageAEndMovement = AddressOf Me.OPLC_EndMovement
                CMotionController.It.OPLC.OStageACalcDegree = AddressOf Me.OPLC_CalcDegree

                CMotionController.It.OPCI.OStageAInitalizeRequested = AddressOf Me.OPCI_DoInitialize_A
                CMotionController.It.OPCI.OStageAAlignmentRequested = AddressOf Me.OPCI_BeginAlignment_A
                CMotionController.It.OPCI.OStartAEdgeRequested = AddressOf Me.OPCI_BeginEdge_A
            ElseIf (Me.m_EStage = DualScriber.ESTAGE.B) Then
                CMotionController.It.OPLC.OStageBBeginCalibration = AddressOf Me.OPLC_BeginCalibration
                CMotionController.It.OPLC.OStageBEndMovement = AddressOf Me.OPLC_EndMovement
                CMotionController.It.OPLC.OStageBCalcDegree = AddressOf Me.OPLC_CalcDegree

                CMotionController.It.OPCI.OStageBInitalizeRequested = AddressOf Me.OPCI_DoInitialize_B
                CMotionController.It.OPCI.OStageBAlignmentRequested = AddressOf Me.OPCI_BeginAlignment_B
                CMotionController.It.OPCI.OStartBEdgeRequested = AddressOf Me.OPCI_BeginEdge_B
            End If

            Me.BeginWork()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Protected Overrides Sub Finalize()
        Try
            MyBase.Finalize()
            Me.Dispose()
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub
#End Region


#Region "EVENT"
    Private Sub OPCI_DoInitialize_A()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            If (Me.m_EStage = ESTAGE.A) Then
                If Me.m_EAnalysis = EAnalysis.CALIBRATION Then
                    If (Me.m_BRunCalibration = True) Then
                        Me.m_BStartCalibration = False
                        Me.m_BRunCalibration = False
                        Me.m_BProcCalibration = False
                        Me.m_BProcMovement = False
                        Me.m_I64StartMovementTick = Long.MaxValue
                        Me.m_I32CalibrationCount = 0
                        Me.m_I32CalibrationIndex = 0
                        CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    End If
                ElseIf Me.m_EAnalysis = EAnalysis.INSPECTION Then
                    Me.m_BRunAlignment_A = False
                    Me.m_BRunEdge = False
                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = False
                    Me.m_BWaitForShift = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    CMotionController.It.OPLC.Initialize(Me.m_EStage)
                    m_OTmpResultforVectorAdditionA = Nothing
                End If
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Init. Requested"))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub

    Private Sub OPCI_DoInitialize_B()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            If (Me.m_EStage = EStage.B) Then
                If Me.m_EAnalysis = EAnalysis.CALIBRATION Then
                    If (Me.m_BRunCalibration = True) Then
                        Me.m_BStartCalibration = False
                        Me.m_BRunCalibration = False
                        Me.m_BProcCalibration = False
                        Me.m_BProcMovement = False
                        Me.m_I64StartMovementTick = Long.MaxValue
                        Me.m_I32CalibrationCount = 0
                        Me.m_I32CalibrationIndex = 0
                        CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    End If
                ElseIf Me.m_EAnalysis = EAnalysis.INSPECTION Then
                    Me.m_BRunAlignment_B = False
                    Me.m_BRunEdge = False
                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = False
                    Me.m_BWaitForShift = False
                    m_OTmpResultforVectorAdditionB = Nothing
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    CMotionController.It.OPLC.Initialize(Me.m_EStage)
                End If
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Init. Requested"))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub

    Private Sub OPLC_BeginCalibration()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.NONE)
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting Calibration"))

            If (Not Me.m_ORecipe Is Nothing) AndAlso (Me.m_EAnalysis = EAnalysis.CALIBRATION) Then
                If Me.m_BRunCalibration = False Then
                    CMotionController.It.OPLC.GetEquipInfo _
                    ( _
                        Me.m_EStage, _
                        Me.m_F64CalibrationMotionLeftX, _
                        Me.m_F64CalibrationMotionRightX, _
                        Me.m_F64CalibrationMotionY, _
                        Me.m_F64T _
                    )
                    CMotionController.It.OPLC.StartCalibration(Me.m_EStage, True)

                    Me.m_I32CalibrationCount = Me.m_OAlgorithm.LoadCalibration(Me.m_F64SectionXY, Me.m_I32PointXY, Me.m_F64SectionT, Me.m_I32PointT)
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BStartCalibration = True
                    Me.m_BRunCalibration = True
                    Me.m_BProcCalibration = True
                    Me.OnCalibrationStart()

                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Start Calibration"))
                End If
            Else
                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_NOT_READY)
                CMotionController.It.OPLC.StartCalibration(Me.m_EStage, False)

                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Fail Calibration(Not Ready)"))
                Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Fail Calibration(Not Ready)")
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub OPLC_EndMovement()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If Me.m_EAnalysis = EAnalysis.CALIBRATION Then
                If (Me.m_BRunCalibration = True) AndAlso (Me.m_BProcMovement = True) Then
                    Me.m_OLeft.RequestMark()
                    Me.m_ORight.RequestMark()
                    Me.m_BProcCalibration = True
                    Me.m_BProcMovement = False
                    Me.m_I64StartMovementTick = Long.MaxValue
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Next Step "))
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub OPLC_CalcDegree _
    ( _
        ByVal EView As EVIEW, _
        ByVal F64TopHorizontal As Double, ByVal F64BottomHorizontal As Double, ByVal F64Vertical As Double _
    )
        Try
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Start Calc Degree(" & EView.ToString() & ")"))

            Dim F64Result As Double = 0
            If ((Not F64TopHorizontal = F64BottomHorizontal) AndAlso (Not F64Vertical = 0)) Then
                F64Result = Math.Abs((F64BottomHorizontal - F64TopHorizontal) / F64Vertical)
                F64Result = F64Result * 180 / Math.PI
                F64Result = Math.Round(F64Result, 5)
            End If

            CMotionController.It.OPLC.SendCalcDegreeResult(Me.m_EStage, EView, F64Result)
            CMotionController.It.OPLC.CompletedCalcDegree(Me.m_EStage, EView)
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Top Horizontal = " & F64TopHorizontal & "(" & EView.ToString() & ")"))
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Bottom Horizontal = " & F64BottomHorizontal & "(" & EView.ToString() & ")"))
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Vertical = " & F64Vertical & "(" & EView.ToString() & ")"))
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Result = " & F64Result & "(" & EView.ToString() & ")"))
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Completed Calc Degree(" & EView.ToString() & ")"))
        Catch ex As Exception
            CError.Throw(ex)
        Finally

        End Try
    End Sub


    Private Sub OPCI_BeginAlignment_A()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (Me.m_EStage = ESTAGE.A) Then
                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.NONE)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting Alignment"))

                If (Not Me.m_EAnalysis = EAnalysis.INSPECTION) OrElse (Me.m_BRunEdge = True) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_NOT_READY)
                    CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Not Ready)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Not Ready)")
                    Return
                End If

                Me.m_BRunAlignment_A = True
                Me.m_OLeft.RequestMark()
                Me.m_ORight.RequestMark()

                CMotionController.It.OPCI.Busy(Me.m_EStage)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Send Busy(Alignment)"))

            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub

    Private Sub OPCI_BeginAlignment_B()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (Me.m_EStage = ESTAGE.B) Then
                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.NONE)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting Alignment"))

                If (Not Me.m_EAnalysis = EAnalysis.INSPECTION) OrElse (Me.m_BRunEdge = True) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_NOT_READY)
                    CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Not Ready)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Not Ready)")
                    Return
                End If

                Me.m_BRunAlignment_B = True
                Me.m_OLeft.RequestMark()
                Me.m_ORight.RequestMark()

                CMotionController.It.OPCI.Busy(Me.m_EStage)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Send Busy(Alignment)"))

            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub OPCI_BeginEdge_A()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            If (Me.m_EStage = ESTAGE.A) Then
                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.NONE)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting Edge Inspection"))

                If (Not Me.m_EAnalysis = EAnalysis.INSPECTION OrElse Me.m_BRunAlignment_A = True) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_NOT_READY)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Not Ready)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Not Ready)")
                    Return
                End If

                CMotionController.It.OPLC.GetEdgeRequest(Me.m_EStage, Me.m_ELeftRequest, Me.m_ERightRequest)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge Left Request(" & CType(Me.m_ELeftRequest, Integer) & ")"))
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge Right Request(" & CType(Me.m_ERightRequest, Integer) & ")"))

                If ((Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso (Me.m_ERightRequest = EEDGE_REQUEST.NONE)) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_NO_REQUEST)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (No Request)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (No Request)")
                    Return
                End If

                If ((Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso
                    (Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) AndAlso
                    (Not Me.m_ELeftRequest = Me.m_ERightRequest)) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_DIFFER_REQUEST)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Differ Request)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Differ Request)")
                    Return
                End If

                If ((Me.m_ELeftRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ELeftRequest = EEDGE_REQUEST.THIRD)) Then
                    Me.m_OLeft.RequestMark()
                ElseIf ((Me.m_ELeftRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ELeftRequest = EEDGE_REQUEST.FOURTH)) Then
                    Me.m_OLeft.RequestEdge()
                End If
                If ((Me.m_ERightRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.THIRD)) Then
                    Me.m_ORight.RequestMark()
                ElseIf ((Me.m_ERightRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.FOURTH)) Then
                    Me.m_ORight.RequestEdge()
                End If

                Me.m_BRunEdge = True
                CMotionController.It.OPCI.Busy(Me.m_EStage)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Send Busy(Edge)"))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub OPCI_BeginEdge_B()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            If (Me.m_EStage = ESTAGE.B) Then
                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.NONE)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting Edge Inspection"))

                If (Not Me.m_EAnalysis = EAnalysis.INSPECTION OrElse Me.m_BRunAlignment_B = True) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_NOT_READY)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Not Ready)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Not Ready)")
                    Return
                End If

                CMotionController.It.OPLC.GetEdgeRequest(Me.m_EStage, Me.m_ELeftRequest, Me.m_ERightRequest)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge Left Request(" & CType(Me.m_ELeftRequest, Integer) & ")"))
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge Right Request(" & CType(Me.m_ERightRequest, Integer) & ")"))

                If ((Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso (Me.m_ERightRequest = EEDGE_REQUEST.NONE)) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_NO_REQUEST)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (No Request)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (No Request)")
                    Return
                End If

                If ((Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso
                    (Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) AndAlso
                    (Not Me.m_ELeftRequest = Me.m_ERightRequest)) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_DIFFER_REQUEST)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Differ Request)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge NG (Differ Request)")
                    Return
                End If

                If ((Me.m_ELeftRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ELeftRequest = EEDGE_REQUEST.THIRD)) Then
                    Me.m_OLeft.RequestMark()
                ElseIf ((Me.m_ELeftRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ELeftRequest = EEDGE_REQUEST.FOURTH)) Then
                    Me.m_OLeft.RequestEdge()
                End If
                If ((Me.m_ERightRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.THIRD)) Then
                    Me.m_ORight.RequestMark()
                ElseIf ((Me.m_ERightRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.FOURTH)) Then
                    Me.m_ORight.RequestEdge()
                End If

                Me.m_BRunEdge = True
                CMotionController.It.OPCI.Busy(Me.m_EStage)
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Send Busy(Edge)"))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Private Sub BeginWork()
        Try
            CMotionController.It.OPLC.InitBIsShift(Me.m_EStage)
            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
            If Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = True

                Me.m_OWorker = New Thread(AddressOf Me.Work)

                'Me.m_OWorker.SetApartmentState(ApartmentState.STA) '0427
                'Me.m_OWorker.Priority = ThreadPriority.Highest
                Me.m_OWorker.IsBackground = True
                Me.m_OWorker.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub Work()
        Try
            While (Me.m_BDoWork)
                Try
                    Monitor.Enter(Me.m_OInterrupt)

                    If (Me.m_I32RetryCount = 0) Then
                        Me.m_OTimeBegin = DateTime.Now
                        Me.m_OTimeElapsed = TimeSpan.Zero
                    End If

                    m_I32DelayCount += 1
                    If (m_I32DelayCount > 100) Then
                        m_I32DelayCount = 0
                        If ((CMotionController.It.OPLC.GetBOversize_A() = 1 AndAlso Me.m_EStage = EStage.A) Or
                            (CMotionController.It.OPLC.GetBOversize_B() = 1 AndAlso Me.m_EStage = EStage.B)) AndAlso
                            (Me.m_IsGDM = False) Then
                            Me.m_IsGDM = True
                            Me.LoadCalibration_Partial()
                        ElseIf ((CMotionController.It.OPLC.GetBOversize_A() = 0 AndAlso Me.m_EStage = EStage.A) Or
                            (CMotionController.It.OPLC.GetBOversize_B() = 0 AndAlso Me.m_EStage = EStage.B)) AndAlso
                            (Me.m_IsGDM = True) Then
                            Me.m_IsGDM = False
                            Me.LoadCalibration()
                        End If
                    End If

                    'On partial calibration context, there is a two cases we have to deal with. first where we take left side of the product to be our objectives and other is a right side as a standard.
                    'So we ask PLC upon determining which side would we take measures, which is called GetBLeftOrRightStandard().
                    'm_BRunCalibration gets initialized by PLC and terminates when NG occurs or Calibration finishes
                    If (Me.m_EAnalysis = EAnalysis.CALIBRATION) AndAlso (Me.m_BRunCalibration = True) Then
                        If ((CMotionController.It.OPLC.GetBOversize_A() = 1 AndAlso Me.m_EStage = EStage.A) Or
                           (CMotionController.It.OPLC.GetBOversize_B() = 1 AndAlso Me.m_EStage = EStage.B)) Then
                            If (CMotionController.It.OPLC.IsBShifted(Me.m_EStage) = 0) AndAlso (Me.m_BWaitForShift = False) Then
                                Me.m_BTmp = True 'this ensures that you only move stage once after a first mark inspection routine

                                If (Me.m_BFirstCalibrationComplete = True) Then
                                    Me.m_BWaitForShift = True
                                    CMotionController.It.OPLC.DoBShift(Me.m_EStage)
                                Else
                                    If (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0) Then
                                        Me.RunCalibrationLeft()
                                    ElseIf (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 1) Then
                                        Me.RunCalibrationRight_RightStandard()
                                    End If
                                End If
                            ElseIf (((CMotionController.It.OPLC.IsBShifted(Me.m_EStage) = 1)) AndAlso (Me.m_BWaitForShift = True)) Then
                                If (Me.m_BTmp = True) Then
                                    Me.OnGraphicClear()
                                    Me.Move()
                                    Me.m_BTmp = False
                                End If
                                CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                                If (Me.m_BSecondCalibrationComplete = True) Then
                                    Me.m_BFirstCalibrationComplete = False
                                    Me.m_BSecondCalibrationComplete = False
                                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                                    Me.m_BWaitForShift = False
                                Else
                                    If (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0) Then
                                        Me.RunCalibrationRight()
                                    ElseIf (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 1) Then
                                        Me.RunCalibrationLeft_RightStandard()
                                    End If
                                End If
                            End If
                        Else
                            Me.RunCalibration()
                        End If
                    ElseIf Me.m_EAnalysis = EAnalysis.INSPECTION Then
                        If (Me.m_BRunAlignment_A = True AndAlso Me.m_EStage = EStage.A) OrElse
                            (Me.m_BRunAlignment_B = True AndAlso Me.m_EStage = EStage.B) Then
                            If ((CMotionController.It.OPLC.GetBOversize_A() = 1 AndAlso Me.m_EStage = EStage.A) Or
                                (CMotionController.It.OPLC.GetBOversize_B() = 1 AndAlso Me.m_EStage = EStage.B)) Then
                                If (CMotionController.It.OPLC.IsBShifted(Me.m_EStage) = 0) AndAlso (Me.m_BWaitForShift = False) Then '정위치 일 경우
                                    Me.m_BTmp = True

                                    If ((CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0 AndAlso Me.m_BLeftAlignmentComplete = True) Or
                                        (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 1 AndAlso Me.m_BRightAlignmentComplete = True)) Then
                                        Me.m_BWaitForShift = True
                                        CMotionController.It.OPLC.DoBShift(Me.m_EStage)
                                    Else
                                        If (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0) Then
                                            Me.RunAlignmentLeft() '왼쪽 세로면에 따른 얼라인 (스테이지 별로 관리)
                                        ElseIf (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 1) Then
                                            Me.RunAlignmentRight_RightStandard() '오른쪽 면에 따른 얼라인
                                        End If

                                    End If
                                ElseIf (((CMotionController.It.OPLC.IsBShifted(Me.m_EStage) = 1)) AndAlso (Me.m_BWaitForShift = True)) Then '위치 이동 한 경우
                                    If (Me.m_BTmp = True) Then
                                        'Thread.Sleep(1000)
                                        Me.OnGraphicClear()
                                        Me.m_BTmp = False
                                    End If

                                    If ((CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0 AndAlso Me.m_BRightAlignmentComplete = True) Or
                                        (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 1 AndAlso Me.m_BLeftAlignmentComplete = True)) Then
                                        Me.m_BWaitForShift = False
                                        CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                                        Me.m_BLeftAlignmentComplete = False
                                        Me.m_BRightAlignmentComplete = False
                                        If (Me.m_EStage = EStage.A) Then
                                            Me.m_BRunAlignment_A = False
                                        Else

                                            Me.m_BRunAlignment_B = False
                                        End If
                                    Else
                                        If (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0) Then
                                            Me.RunAlignmentRight()
                                        ElseIf (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 1) Then
                                            Me.RunAlignmentLeft_RightStandard()
                                        End If
                                    End If
                                End If
                            Else
                                Me.RunAlignment()
                            End If
                        ElseIf Me.m_BRunEdge = True Then
                            Me.RunEdge()
                        End If
                    End If
                Catch ex As Exception
                    CError.Ignore(ex)
                Finally
                    Monitor.Exit(Me.m_OInterrupt)
                End Try

                Thread.Sleep(10)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub


    Private Sub EndWork()
        Try
            If Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = False

                Me.m_OWorker.Join()
                Me.m_OWorker = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub BeginCalibration()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            Me.m_EAnalysis = EAnalysis.CALIBRATION
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub Move()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            'Send Movement XY swap
            Me.m_OAlgorithm.GetCalibrationMovement(Me.m_I32CalibrationIndex, Me.m_F64Y, Me.m_F64X, Me.m_F64T)

            If Me.m_I32CalibrationIndex = 0 Then
                Me.m_F64ResultLeftX = Me.m_F64X
                Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                Me.m_F64ResultY = Me.m_F64Y
                Me.m_F64ResultT = Me.m_F64T
            Else
                Me.m_F64ResultLeftX = Me.m_F64X - Me.m_F64BeforeX
                Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                Me.m_F64ResultY = Me.m_F64Y - Me.m_F64BeforeY
                Me.m_F64ResultT = Me.m_F64T - Me.m_F64BeforeT
            End If
            Me.m_F64BeforeX = Me.m_F64X
            Me.m_F64BeforeY = Me.m_F64Y
            Me.m_F64BeforeT = Me.m_F64T

            'If (Not Me.m_I32CalibrationIndex = 0) Then
            CMotionController.It.OPLC.SendReCalibration(Me.m_EStage)
            'End If
            CMotionController.It.OPLC.BeginMovement(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)  'left should move also to prevent collision
            '(Me.m_BProcCalibration = True) AndAlso (Me.m_BProcMovement = False) Then
            Me.m_BStartCalibration = False
            Me.m_BProcCalibration = False
            Me.m_BProcMovement = True
            Me.m_I64StartMovementTick = DateTime.Now.Ticks

            CLogTool.It.SetLog _
            ( _
                New CLog _
                ( _
                    "ST#" & CType(Me.m_EStage, Integer) & " : Send Calibration Movement " & _
                    "LX(On Hold), " & _
                    "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " & _
                    "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                    "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                ) _
            )

        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub

    Public Sub ForceStop()
        Try
            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_MOTION_TIME_OUT)
            CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

            Me.m_I32CalibrationCount = 0
            Me.m_I32CalibrationIndex = 0
            Me.m_BStartCalibration = False
            Me.m_BRunCalibration = False
            Me.m_BFirstCalibrationComplete = False
            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
            Me.m_BWaitForShift = False
            Me.m_BProcCalibration = False
            Me.m_BProcMovement = False
            Me.m_I64StartMovementTick = Long.MaxValue

            Me.OnCalibrationFinish(False, "Stage " & CType(Me.m_EStage, Integer) & " Calibration Failed by Motion Timeout")
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion Timeout)"))
            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed (Motion Timeout)")
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub RunCalibrationLeft()
        Try
            'Section to check the timeout after operation initiated
            If (Me.m_BProcCalibration = False) AndAlso (Me.m_BProcMovement = True) Then
                If (DateTime.Now.Ticks - Me.m_I64StartMovementTick > WAIT_TICK) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_MOTION_TIME_OUT)
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    Me.m_BFirstCalibrationComplete = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.OnCalibrationFinish(False, "Stage " & CType(Me.m_EStage, Integer) & " Calibration Failed by Motion Timeout")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion Timeout)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed (Motion Timeout)")
                End If
            End If


            If (Me.m_BProcCalibration = True) AndAlso (Me.m_BProcMovement = False) Then
                'Image Processing;
                If Me.m_BStartCalibration = False Then
                    'getting the mark from left
                    Dim OLeftResult As CMarkResult = Me.m_OLeft.GetMarkResult()
                    'Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()
                    If (Not OLeftResult Is Nothing) Then
                        If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) Then
                            Me.m_OAlgorithm.SetCalibResult_Orthogonal _
                            ( _
                                OLeftResult.F64X, _
                                OLeftResult.F64Y, _
                                0 _
                            )
                            Me.OnPartialCalibrationRan(OLeftResult, 0)
                            Me.m_I32CalibrationIndex += 1

                            CLogTool.It.SetLog _
                            ( _
                                New CLog _
                                ( _
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Calibration Axis " & _
                                    "L(" & Math.Round(OLeftResult.F64X, 3) & ", " & Math.Round(OLeftResult.F64Y, 3) & ") " & _
                                    "R(On Hold)" _
                                ) _
                            )
                        Else
                            If ((OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False)) Then
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_LEFT_UNKNOWN)
                            End If
                            CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

                            Me.m_BStartCalibration = False
                            Me.m_BRunCalibration = False
                            Me.m_BFirstCalibrationComplete = False
                            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                            Me.m_BWaitForShift = False
                            Me.m_BProcCalibration = False
                            Me.m_BProcMovement = False
                            Me.m_I32CalibrationCount = 0
                            Me.m_I32CalibrationIndex = 0
                            Me.m_I64StartMovementTick = Long.MaxValue

                            Me.OnCalibrationFinish(False, "Fail stage " & CType(Me.m_EStage, Integer) & " (Left) partial calibration by unknown point!")
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Fail (Left) partial calibration(Unknown point)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Fail (Left) partial calibration(Unknown point)")
                            Return
                        End If
                    Else
                        Return
                    End If
                End If


                If Me.m_I32CalibrationIndex < Me.m_I32CalibrationCount Then
                    'Send Movement
                    Me.m_OAlgorithm.GetCalibrationMovement(Me.m_I32CalibrationIndex, Me.m_F64Y, Me.m_F64X, Me.m_F64T)

                    If Me.m_I32CalibrationIndex = 0 Then
                        Me.m_F64ResultLeftX = Me.m_F64X
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y
                        Me.m_F64ResultT = Me.m_F64T
                    Else
                        Me.m_F64ResultLeftX = Me.m_F64X - Me.m_F64BeforeX
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y - Me.m_F64BeforeY
                        Me.m_F64ResultT = Me.m_F64T - Me.m_F64BeforeT
                    End If
                    Me.m_F64BeforeX = Me.m_F64X
                    Me.m_F64BeforeY = Me.m_F64Y
                    Me.m_F64BeforeT = Me.m_F64T

                    If (Not Me.m_I32CalibrationIndex = 0) Then
                        CMotionController.It.OPLC.SendReCalibration(Me.m_EStage)
                    End If
                    CMotionController.It.OPLC.BeginMovement(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)

                    Me.m_BStartCalibration = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = True
                    Me.m_I64StartMovementTick = DateTime.Now.Ticks

                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Calibration Movement " & _
                            "LX(" & Math.Round(Me.m_F64ResultLeftX, 3) & "), " & _
                            "RX(On Hold), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                        ) _
                    )
                ElseIf Me.m_I32CalibrationIndex = Me.m_I32CalibrationCount Then

                    'initializing for right side to calibrate
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BFirstCalibrationComplete = True
                    Me.m_BSecondCalibrationComplete = False

                    'Finish Calibration -- Only perform after right side is finished 20170724
                    'CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, True)

                    'Me.m_OAlgorithm.RunCalibration()
                    'Me.m_F64AlignmentStdMotionLeftX = Me.m_F64CalibrationMotionLeftX
                    'Me.m_F64AlignmentStdMotionRightX = Me.m_F64CalibrationMotionRightX
                    'Me.m_F64AlignmentStdMotionY = Me.m_F64CalibrationMotionY
                    'Me.SaveCalibration()


                    'Me.m_BStartCalibration = False
                    'Me.m_BRunCalibration = False
                    'Me.m_BProcCalibration = False
                    'Me.m_BProcMovement = False
                    'Me.m_I32CalibrationCount = 0
                    'Me.m_I32CalibrationIndex = 0
                    'Me.m_I64StartMovementTick = Long.MaxValue

                    'Me.m_OCalibrationFinish(True, "Success stage " & CType(Me.m_EStage, Integer) & " calibration!")
                    'CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Success calibration"))
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunCalibrationRight()
        Try
            'Process Timeout Stage Movement
            If (Me.m_BProcCalibration = False) AndAlso (Me.m_BProcMovement = True) Then
                If (DateTime.Now.Ticks - Me.m_I64StartMovementTick > WAIT_TICK) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_MOTION_TIME_OUT)
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    Me.m_BFirstCalibrationComplete = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.OnCalibrationFinish(False, "Stage " & CType(Me.m_EStage, Integer) & " Calibration Failed by Motion Timeout")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion Timeout)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed (Motion Timeout)")
                End If
            End If


            If (Me.m_BProcCalibration = True) AndAlso (Me.m_BProcMovement = False) Then
                'Image Processing; so we need to part the left and right from this sector.
                If Me.m_BStartCalibration = False Then
                    'Dim OLeftResult As CMarkResult = Me.m_OLeft.GetMarkResult()
                    Dim ORightResult As CMarkResult = Me.m_OLeft.GetMarkResult()
                    If (Not ORightResult Is Nothing) Then
                        If (ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True) Then
                            Me.m_OAlgorithm.SetCalibResult_Orthogonal _
                            ( _
                                ORightResult.F64X, _
                                ORightResult.F64Y, _
                                1 _
                            )
                            Me.OnPartialCalibrationRan(ORightResult, 0)

                            Me.m_I32CalibrationIndex += 1

                            CLogTool.It.SetLog _
                            ( _
                                New CLog _
                                ( _
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Calibration Axis " & _
                                    "L(On Hold) " & _
                                    "R(" & Math.Round(ORightResult.F64X, 3) & ", " & Math.Round(ORightResult.F64Y, 3) & ")" _
                                ) _
                            )
                        Else
                            If ((ORightResult.BInspected = False) OrElse (ORightResult.BOK = False)) Then
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_RIGHT_UNKNOWN)
                            End If
                            CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)
                            Me.m_BWaitForShift = False
                            Me.m_BStartCalibration = False
                            Me.m_BRunCalibration = False
                            Me.m_BFirstCalibrationComplete = False
                            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                            Me.m_BProcCalibration = False
                            Me.m_BProcMovement = False
                            Me.m_I32CalibrationCount = 0
                            Me.m_I32CalibrationIndex = 0
                            Me.m_I64StartMovementTick = Long.MaxValue

                            Me.OnCalibrationFinish(False, "Failed Stage " & CType(Me.m_EStage, Integer) & " Calibration due to unrecognizable point")
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Failed Calibration(Unknown point)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Failed Calibration(Unknown point)")
                            Return
                        End If
                    Else
                        Return
                    End If
                End If


                If Me.m_I32CalibrationIndex < Me.m_I32CalibrationCount Then
                    'Send Movement
                    Me.m_OAlgorithm.GetCalibrationMovement(Me.m_I32CalibrationIndex, Me.m_F64Y, Me.m_F64X, Me.m_F64T)

                    If Me.m_I32CalibrationIndex = 0 Then
                        Me.m_F64ResultLeftX = Me.m_F64X
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y
                        Me.m_F64ResultT = Me.m_F64T
                    Else
                        Me.m_F64ResultLeftX = Me.m_F64X - Me.m_F64BeforeX
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y - Me.m_F64BeforeY
                        Me.m_F64ResultT = Me.m_F64T - Me.m_F64BeforeT
                    End If
                    Me.m_F64BeforeX = Me.m_F64X
                    Me.m_F64BeforeY = Me.m_F64Y
                    Me.m_F64BeforeT = Me.m_F64T

                    If (Not Me.m_I32CalibrationIndex = 0) Then
                        CMotionController.It.OPLC.SendReCalibration(Me.m_EStage)
                    End If
                    CMotionController.It.OPLC.BeginMovement(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)  'left should move also to prevent collision

                    Me.m_BStartCalibration = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = True
                    Me.m_I64StartMovementTick = DateTime.Now.Ticks

                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Calibration Movement " & _
                            "LX(On Hold), " & _
                            "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                        ) _
                    )
                ElseIf Me.m_I32CalibrationIndex = Me.m_I32CalibrationCount Then
                    'Finish Calibration
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, True)

                    Me.m_OAlgorithm.RunCalibration()
                    Me.m_F64AlignmentStdMotionLeftX = Me.m_F64CalibrationMotionLeftX
                    Me.m_F64AlignmentStdMotionRightX = Me.m_F64CalibrationMotionRightX
                    Me.m_F64AlignmentStdMotionY = Me.m_F64CalibrationMotionY
                    Me.SaveCalibration_Partial()

                    Me.m_BFirstCalibrationComplete = False
                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.m_OCalibrationFinish(True, "Success. Stage " & CType(Me.m_EStage, Integer) & " Calibration Completed.")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Completed (Success)"))
                    CMsgBox.Info("Finished Calibration Successfully")
                    Me.m_BSecondCalibrationComplete = True
                    Me.m_BFirstCalibrationComplete = False
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunCalibrationLeft_RightStandard()
        Try
            'Process Timeout Stage Movement
            If (Me.m_BProcCalibration = False) AndAlso (Me.m_BProcMovement = True) Then
                If (DateTime.Now.Ticks - Me.m_I64StartMovementTick > WAIT_TICK) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_MOTION_TIME_OUT)
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    Me.m_BFirstCalibrationComplete = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.OnCalibrationFinish(False, "Stage " & CType(Me.m_EStage, Integer) & " Calibration Failed by Motion Timeout")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion Timeout)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed (Motion Timeout)")
                End If
            End If


            If (Me.m_BProcCalibration = True) AndAlso (Me.m_BProcMovement = False) Then
                'Image Processing;
                If Me.m_BStartCalibration = False Then
                    Dim OLeftResult As CMarkResult = Me.m_ORight.GetMarkResult()
                    'Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()
                    If (Not OLeftResult Is Nothing) Then
                        If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) Then
                            Me.m_OAlgorithm.SetCalibResult_Orthogonal _
                            ( _
                                OLeftResult.F64X, _
                                OLeftResult.F64Y, _
                                0 _
                            )
                            Me.OnPartialCalibrationRan(OLeftResult, 1)
                            Me.m_I32CalibrationIndex += 1

                            CLogTool.It.SetLog _
                            ( _
                                New CLog _
                                ( _
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Calibration Axis " & _
                                    "L(" & Math.Round(OLeftResult.F64X, 3) & ", " & Math.Round(OLeftResult.F64Y, 3) & ") " & _
                                    "R(On Hold)" _
                                ) _
                            )
                        Else
                            If ((OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False)) Then
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_LEFT_UNKNOWN)
                            End If
                            CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)
                            Me.m_BWaitForShift = False
                            Me.m_BStartCalibration = False
                            Me.m_BRunCalibration = False
                            Me.m_BFirstCalibrationComplete = False
                            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                            Me.m_BProcCalibration = False
                            Me.m_BProcMovement = False
                            Me.m_I32CalibrationCount = 0
                            Me.m_I32CalibrationIndex = 0
                            Me.m_I64StartMovementTick = Long.MaxValue

                            Me.OnCalibrationFinish(False, "Fail stage " & CType(Me.m_EStage, Integer) & " (Left) partial calibration by unknown point!")
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Fail (Left) partial calibration(Unknown point)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Fail (Left) partial calibration(Unknown point)")
                            Return
                        End If
                    Else
                        Return
                    End If
                End If


                If Me.m_I32CalibrationIndex < Me.m_I32CalibrationCount Then
                    'Send Movement
                    Me.m_OAlgorithm.GetCalibrationMovement(Me.m_I32CalibrationIndex, Me.m_F64Y, Me.m_F64X, Me.m_F64T)

                    If Me.m_I32CalibrationIndex = 0 Then
                        Me.m_F64ResultLeftX = Me.m_F64X
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y
                        Me.m_F64ResultT = Me.m_F64T
                    Else
                        Me.m_F64ResultLeftX = Me.m_F64X - Me.m_F64BeforeX
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y - Me.m_F64BeforeY
                        Me.m_F64ResultT = Me.m_F64T - Me.m_F64BeforeT
                    End If
                    Me.m_F64BeforeX = Me.m_F64X
                    Me.m_F64BeforeY = Me.m_F64Y
                    Me.m_F64BeforeT = Me.m_F64T

                    If (Not Me.m_I32CalibrationIndex = 0) Then
                        CMotionController.It.OPLC.SendReCalibration(Me.m_EStage)
                    End If
                    CMotionController.It.OPLC.BeginMovement(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)

                    Me.m_BStartCalibration = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = True
                    Me.m_I64StartMovementTick = DateTime.Now.Ticks

                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Calibration Movement " & _
                            "LX(" & Math.Round(Me.m_F64ResultLeftX, 3) & "), " & _
                            "RX(On Hold), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                        ) _
                    )
                ElseIf Me.m_I32CalibrationIndex = Me.m_I32CalibrationCount Then
                    'Finish Calibration
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, True)

                    Me.m_OAlgorithm.RunCalibration()
                    Me.m_F64AlignmentStdMotionLeftX = Me.m_F64CalibrationMotionLeftX
                    Me.m_F64AlignmentStdMotionRightX = Me.m_F64CalibrationMotionRightX
                    Me.m_F64AlignmentStdMotionY = Me.m_F64CalibrationMotionY
                    Me.SaveCalibration_Partial()
                    Me.m_BFirstCalibrationComplete = False

                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.m_OCalibrationFinish(True, "Success. Stage " & CType(Me.m_EStage, Integer) & " Calibration Completed.")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Completed (Success)"))
                    CMsgBox.Info("Finished Calibration Successfully")
                    Me.m_BSecondCalibrationComplete = True
                    Me.m_BFirstCalibrationComplete = False
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunCalibrationRight_RightStandard()
        Try
            'Process Timeout Stage Movement
            If (Me.m_BProcCalibration = False) AndAlso (Me.m_BProcMovement = True) Then
                If (DateTime.Now.Ticks - Me.m_I64StartMovementTick > WAIT_TICK) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_MOTION_TIME_OUT)
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    Me.m_BFirstCalibrationComplete = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.OnCalibrationFinish(False, "Stage " & CType(Me.m_EStage, Integer) & " Calibration Failed by Motion Timeout")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion Timeout)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed (Motion Timeout)")
                End If
            End If


            If (Me.m_BProcCalibration = True) AndAlso (Me.m_BProcMovement = False) Then
                'Image Processing; so we need to part the left and right from this sector.
                If Me.m_BStartCalibration = False Then
                    'Dim OLeftResult As CMarkResult = Me.m_OLeft.GetMarkResult()
                    Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()
                    If (Not ORightResult Is Nothing) Then
                        If (ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True) Then
                            Me.m_OAlgorithm.SetCalibResult_Orthogonal _
                            ( _
                                ORightResult.F64X, _
                                ORightResult.F64Y, _
                                1 _
                            )
                            Me.OnPartialCalibrationRan(ORightResult, 1)

                            Me.m_I32CalibrationIndex += 1

                            CLogTool.It.SetLog _
                            ( _
                                New CLog _
                                ( _
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Calibration Axis " & _
                                    "L(On Hold) " & _
                                    "R(" & Math.Round(ORightResult.F64X, 3) & ", " & Math.Round(ORightResult.F64Y, 3) & ")" _
                                ) _
                            )
                        Else
                            If ((ORightResult.BInspected = False) OrElse (ORightResult.BOK = False)) Then
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_RIGHT_UNKNOWN)
                            End If
                            CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)
                            Me.m_BFirstCalibrationComplete = False
                            Me.m_BStartCalibration = False
                            Me.m_BRunCalibration = False
                            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                            Me.m_BWaitForShift = False
                            Me.m_BProcCalibration = False
                            Me.m_BProcMovement = False
                            Me.m_I32CalibrationCount = 0
                            Me.m_I32CalibrationIndex = 0
                            Me.m_I64StartMovementTick = Long.MaxValue

                            Me.OnCalibrationFinish(False, "Failed Stage " & CType(Me.m_EStage, Integer) & " Calibration due to unrecognizable point")
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Failed Calibration(Unknown point)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Failed Calibration(Unknown point)")
                            Return
                        End If
                    Else
                        Return
                    End If
                End If


                If Me.m_I32CalibrationIndex < Me.m_I32CalibrationCount Then
                    'Send Movement
                    Me.m_OAlgorithm.GetCalibrationMovement(Me.m_I32CalibrationIndex, Me.m_F64Y, Me.m_F64X, Me.m_F64T)

                    If Me.m_I32CalibrationIndex = 0 Then
                        Me.m_F64ResultLeftX = Me.m_F64X
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y
                        Me.m_F64ResultT = Me.m_F64T
                    Else
                        Me.m_F64ResultLeftX = Me.m_F64X - Me.m_F64BeforeX
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y - Me.m_F64BeforeY
                        Me.m_F64ResultT = Me.m_F64T - Me.m_F64BeforeT
                    End If
                    Me.m_F64BeforeX = Me.m_F64X
                    Me.m_F64BeforeY = Me.m_F64Y
                    Me.m_F64BeforeT = Me.m_F64T

                    If (Not Me.m_I32CalibrationIndex = 0) Then
                        CMotionController.It.OPLC.SendReCalibration(Me.m_EStage)
                    End If
                    CMotionController.It.OPLC.BeginMovement(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)  'left should move also to prevent collision

                    Me.m_BStartCalibration = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = True
                    Me.m_I64StartMovementTick = DateTime.Now.Ticks

                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Calibration Movement " & _
                            "LX(On Hold), " & _
                            "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                        ) _
                    )
                ElseIf Me.m_I32CalibrationIndex = Me.m_I32CalibrationCount Then
                    'initializing for other side to calibrate
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BFirstCalibrationComplete = True
                    Me.m_BSecondCalibrationComplete = False
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunCalibration()
        Try
            'Process Timeout Stage Movement
            If (Me.m_BProcCalibration = False) AndAlso (Me.m_BProcMovement = True) Then
                If (Math.Abs(DateTime.Now.Ticks - Me.m_I64StartMovementTick) > WAIT_TICK) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_MOTION_TIME_OUT)
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)

                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    Me.m_BFirstCalibrationComplete = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.OnCalibrationFinish(False, "Failed Stage " & CType(Me.m_EStage, Integer) & " Calibration by motion timeout!")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion timeout)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Failed(Motion timeout)")
                End If
            End If


            If (Me.m_BProcCalibration = True) AndAlso (Me.m_BProcMovement = False) Then
                'Image Processing
                If Me.m_BStartCalibration = False Then
                    Dim OLeftResult As CMarkResult = Me.m_OLeft.GetMarkResult()
                    Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()
                    If (Not OLeftResult Is Nothing) AndAlso (Not ORightResult Is Nothing) Then
                        If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) AndAlso _
                           ((ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True)) Then
                            Me.m_OAlgorithm.SetCalibResult _
                            ( _
                                New Double() {OLeftResult.F64X, ORightResult.F64X}, _
                                New Double() {OLeftResult.F64Y, ORightResult.F64Y} _
                            )
                            Me.OnCalibrationRan(OLeftResult, ORightResult)
                            Me.m_I32CalibrationIndex += 1

                            CLogTool.It.SetLog _
                            ( _
                                New CLog _
                                ( _
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Calibration Axis " & _
                                    "L(" & Math.Round(OLeftResult.F64X, 3) & ", " & Math.Round(OLeftResult.F64Y, 3) & ") " & _
                                    "R(" & Math.Round(ORightResult.F64X, 3) & ", " & Math.Round(ORightResult.F64Y, 3) & ")" _
                                ) _
                            )
                        Else
                            If ((OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False)) Then
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_LEFT_UNKNOWN)
                            Else
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.CALIBRATION_RIGHT_UNKNOWN)
                            End If
                            CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, False)
                            Me.m_BFirstCalibrationComplete = False
                            Me.m_BStartCalibration = False
                            Me.m_BRunCalibration = False
                            CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                            Me.m_BWaitForShift = False
                            Me.m_BProcCalibration = False
                            Me.m_BProcMovement = False
                            Me.m_I32CalibrationCount = 0
                            Me.m_I32CalibrationIndex = 0
                            Me.m_I64StartMovementTick = Long.MaxValue

                            Me.OnCalibrationFinish(False, "Failed Stage " & CType(Me.m_EStage, Integer) & " Calibration due to unrecognizable point!")
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Failed Calibration(Unknown point)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Failed Calibration(Unknown point)")
                            Return
                        End If
                    Else
                        Return
                    End If
                End If


                If Me.m_I32CalibrationIndex < Me.m_I32CalibrationCount Then
                    'Send Movement
                    Me.m_OAlgorithm.GetCalibrationMovement(Me.m_I32CalibrationIndex, Me.m_F64X, Me.m_F64Y, Me.m_F64T)

                    If Me.m_I32CalibrationIndex = 0 Then
                        Me.m_F64ResultLeftX = Me.m_F64X
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y
                        Me.m_F64ResultT = Me.m_F64T
                    Else
                        Me.m_F64ResultLeftX = Me.m_F64X - Me.m_F64BeforeX
                        Me.m_F64ResultRightX = Me.m_F64ResultLeftX * -1
                        Me.m_F64ResultY = Me.m_F64Y - Me.m_F64BeforeY
                        Me.m_F64ResultT = Me.m_F64T - Me.m_F64BeforeT
                    End If
                    Me.m_F64BeforeX = Me.m_F64X
                    Me.m_F64BeforeY = Me.m_F64Y
                    Me.m_F64BeforeT = Me.m_F64T

                    If (Not Me.m_I32CalibrationIndex = 0) Then
                        CMotionController.It.OPLC.SendReCalibration(Me.m_EStage)
                    End If
                    CMotionController.It.OPLC.BeginMovement(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)

                    Me.m_BStartCalibration = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = True
                    Me.m_I64StartMovementTick = DateTime.Now.Ticks

                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Calibration Movement " & _
                            "LX(" & Math.Round(Me.m_F64ResultLeftX, 3) & "), " & _
                            "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                        ) _
                    )
                ElseIf Me.m_I32CalibrationIndex = Me.m_I32CalibrationCount Then
                    'Finish Calibration
                    CMotionController.It.OPLC.FinishCalibration(Me.m_EStage, True)
                    Me.m_BFirstCalibrationComplete = False
                    Me.m_OAlgorithm.RunCalibration()
                    Me.m_F64AlignmentStdMotionLeftX = Me.m_F64CalibrationMotionLeftX
                    Me.m_F64AlignmentStdMotionRightX = Me.m_F64CalibrationMotionRightX
                    Me.m_F64AlignmentStdMotionY = Me.m_F64CalibrationMotionY
                    Me.SaveCalibration()


                    Me.m_BStartCalibration = False
                    Me.m_BRunCalibration = False
                    CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                    Me.m_BWaitForShift = False
                    Me.m_BProcCalibration = False
                    Me.m_BProcMovement = False
                    Me.m_I32CalibrationCount = 0
                    Me.m_I32CalibrationIndex = 0
                    Me.m_I64StartMovementTick = Long.MaxValue

                    Me.m_OCalibrationFinish(True, "Stage " & CType(Me.m_EStage, Integer) & " Calibration Completed (Success)")
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Calibration Completed (Success)"))
                    CMsgBox.Info("Finished Calibration Successfully")
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub LoadCalibration()
        Try
            Dim StrFile As String = Me.m_ORecipe.StrDirectory & "\" & EQUIP_INFO_FILE

            If (File.Exists(StrFile) = True) Then
                Dim OLeftX As StringBuilder = New StringBuilder()
                Dim ORightX As StringBuilder = New StringBuilder()
                Dim OY As StringBuilder = New StringBuilder()

                GetPrivateProfileString("INFO", "LEFT_X", String.Empty, OLeftX, 255, StrFile)
                GetPrivateProfileString("INFO", "RIGHT_X", String.Empty, ORightX, 255, StrFile)
                GetPrivateProfileString("INFO", "Y", String.Empty, OY, 255, StrFile)

                Me.m_OAlgorithm.LoadFile(Me.m_ORecipe.StrDirectory)
                Me.m_F64AlignmentStdMotionLeftX = Convert.ToDouble(OLeftX.ToString())
                Me.m_F64AlignmentStdMotionRightX = Convert.ToDouble(ORightX.ToString())
                Me.m_F64AlignmentStdMotionY = Convert.ToDouble(OY.ToString())
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub LoadCalibration_Partial()
        Try
            Dim StrFile As String = Me.m_ORecipe.StrDirectory & "\" & EQUIP_INFO_FILE_PARTIAL

            If (File.Exists(StrFile) = True) Then
                Dim OLeftX As StringBuilder = New StringBuilder()
                Dim ORightX As StringBuilder = New StringBuilder()
                Dim OY As StringBuilder = New StringBuilder()

                GetPrivateProfileString("INFO", "LEFT_X", String.Empty, OLeftX, 255, StrFile)
                GetPrivateProfileString("INFO", "RIGHT_X", String.Empty, ORightX, 255, StrFile)
                GetPrivateProfileString("INFO", "Y", String.Empty, OY, 255, StrFile)

                Me.m_OAlgorithm.LoadFilePartial(Me.m_ORecipe.StrDirectory)
                Me.m_F64AlignmentStdMotionLeftX = Convert.ToDouble(OLeftX.ToString())
                Me.m_F64AlignmentStdMotionRightX = Convert.ToDouble(ORightX.ToString())
                Me.m_F64AlignmentStdMotionY = Convert.ToDouble(OY.ToString())
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub SaveCalibration()
        Try
            Dim StrFile As String = Me.m_ORecipe.StrDirectory & "\" & EQUIP_INFO_FILE

            If (File.Exists(StrFile) = False) Then
                File.WriteAllText(StrFile, My.Resources.EquipInfo)
            End If

            Me.m_OAlgorithm.SaveFile(Me.m_ORecipe.StrDirectory)
            WritePrivateProfileString("INFO", "LEFT_X", Me.m_F64AlignmentStdMotionLeftX, StrFile)
            WritePrivateProfileString("INFO", "RIGHT_X", Me.m_F64AlignmentStdMotionRightX, StrFile)
            WritePrivateProfileString("INFO", "Y", Me.m_F64AlignmentStdMotionY, StrFile)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub SaveCalibration_Partial()
        Try
            Dim StrFile As String = Me.m_ORecipe.StrDirectory & "\" & EQUIP_INFO_FILE_PARTIAL

            If (File.Exists(StrFile) = False) Then
                File.WriteAllText(StrFile, My.Resources.EquipInfo)
            End If

            Me.m_OAlgorithm.SaveFilePartial(Me.m_ORecipe.StrDirectory)
            WritePrivateProfileString("INFO", "LEFT_X", Me.m_F64AlignmentStdMotionLeftX, StrFile)
            WritePrivateProfileString("INFO", "RIGHT_X", Me.m_F64AlignmentStdMotionRightX, StrFile)
            WritePrivateProfileString("INFO", "Y", Me.m_F64AlignmentStdMotionY, StrFile)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub EndCalibration()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If ((CMotionController.It.OPLC.GetBOversize_A() = 1 AndAlso Me.m_EStage = EStage.A) Or (CMotionController.It.OPLC.GetBOversize_B() = 1 AndAlso Me.m_EStage = EStage.B)) Then
                CMotionController.It.OPLC.InitBShift(Me.m_EStage)
                Me.m_BWaitForShift = False
            End If
            Me.m_EAnalysis = EAnalysis.NONE
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub BeginInspection()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            Me.m_EAnalysis = EAnalysis.INSPECTION
            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Begin Inspection"))
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub RunAlignmentLeft()
        Try
            If (m_BMarkRequest = False) Then
                Me.m_OLeft.RequestMark()
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting GOA 1st Mark..."))
                m_BMarkRequest = True
            End If

            Dim OTmpResult As CMarkResult = Me.m_OLeft.GetMarkResult()
            Me.m_OTmpLeftMarkResult = OTmpResult
            If (Not OTmpResult Is Nothing) Then
                Me.m_I32RetryCount += 1
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : GOA 1st Mark Found..."))
                m_BMarkRequest = False
                'OTmpResult = Nothing
                If (Not Me.m_OTmpLeftMarkResult Is Nothing AndAlso Me.m_OTmpLeftMarkResult.BOK = True) Then
                    Me.m_BLeftAlignmentComplete = True
                    Me.m_BRightAlignmentComplete = False

                    Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, Me.m_OTmpLeftMarkResult, Nothing)
                    'OResult.F64RetryCount = Me.m_I32RetryCount

                    Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                    OResult.OTimeElapsed = Me.m_OTimeElapsed

                    'Console.WriteLine(
                    Me.OnDisplayPartial(OResult, 0, 0)
                    Me.m_OLeft.InitMarkResult()
                End If

                'Cannot Find Mark
                If (Me.m_OTmpLeftMarkResult.BInspected = False) OrElse (Me.m_OTmpLeftMarkResult.BOK = False) Then
                    Me.m_I32RetryCount = 0
                    'Left NG
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_LEFT_UNKNOWN)
                    CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)

                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left Partial unknown point)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left Partial unknown point)")
                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = False
                    If (Me.m_EStage = EStage.A) Then
                        Me.m_BRunAlignment_A = False
                    Else
                        Me.m_BRunAlignment_B = False
                    End If
                    Return
                End If

                If (CMotionController.It.OPLC.VectorAddition() = 0) Then
                    If (Me.m_EStage = EStage.A) Then
                        m_OTmpResultforVectorAdditionA = Nothing
                    Else
                        m_OTmpResultforVectorAdditionB = Nothing
                    End If
                End If

                If (CMotionController.It.OPLC.VectorAddition() = 1) AndAlso _
                    ((Not m_OTmpResultforVectorAdditionA Is Nothing AndAlso Me.m_EStage = EStage.A) OrElse _
                     (Not m_OTmpResultforVectorAdditionB Is Nothing AndAlso Me.m_EStage = EStage.B)) _
                    Then
                    Me.m_I32RetryCount = 0
                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = False
                    If (Me.m_EStage = EStage.A) Then
                        Me.m_BRunAlignment_A = False
                    Else

                        Me.m_BRunAlignment_B = False
                    End If

                    If (Not Me.m_OTmpLeftMarkResult Is Nothing AndAlso Me.m_OTmpLeftMarkResult.BOK = True) Then

                        'Target
                        Me.m_OAlgorithm.SetTarget_Orthogonal(0, m_OTmpLeftMarkResult.OImageInfo.OImage.Width / 2D, m_OTmpLeftMarkResult.OImageInfo.OImage.Height / 2D)
                        Me.m_OAlgorithm.SetTarget_Orthogonal(1, m_OTmpLeftMarkResult.OImageInfo.OImage.Width / 2D, m_OTmpLeftMarkResult.OImageInfo.OImage.Height / 2D)
                        Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
                        Me.m_OAlgorithm.RunAlignment_Orthogonal _
                        (
                          New Double() {m_OTmpLeftMarkResult.OImageInfo.OImage.Width / 2D, m_OTmpLeftMarkResult.OImageInfo.OImage.Width / 2D},
                          New Double() {m_OTmpLeftMarkResult.F64Y, m_OTmpLeftMarkResult.F64Y},
                          Me.m_F64ResultLeftX, Me.m_F64ResultY, Me.m_F64ResultT,
                          0
                        )

                        CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, 0, 0, Me.m_F64ResultY, 0)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.OK, EVIEW.NONE)

                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : OK (Additional Alignment)"))
                        CLogTool.It.SetLog _
                        ( _
                            New CLog _
                            ( _
                                "ST#" & CType(Me.m_EStage, Integer) & " : Send Additional Movement " &
                                "Y(" & Math.Round(Me.m_F64ResultY, 3) & ") "
                            ) _
                        )
                    Else
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Fail To Give Additional Movement"))
                    End If


                    Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                    If (Me.m_EStage = EStage.A) Then
                        Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, m_OTmpLeftMarkResult, m_OTmpResultforVectorAdditionA)
                        OResult.EResult = ERESULT.OK
                        OResult.EView = EVIEW.RIGHT
                        OResult.F64MotionLeftX = 0 'Me.m_F64ResultLeftX
                        OResult.F64MotionRightX = 0 'Me.m_F64ResultRightX
                        OResult.F64MotionY = Me.m_F64ResultY
                        OResult.F64MotionT = 0 'Me.m_F64ResultT
                        OResult.F64RetryCount = Me.m_I32RetryCount
                        OResult.OTimeElapsed = Me.m_OTimeElapsed
                        Me.SendAlignmentToFile(OResult)
                        m_OTmpResultforVectorAdditionA = Nothing
                    Else
                        Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, m_OTmpLeftMarkResult, m_OTmpResultforVectorAdditionB)
                        OResult.EResult = ERESULT.OK
                        OResult.EView = EVIEW.RIGHT
                        OResult.F64MotionLeftX = 0 'Me.m_F64ResultLeftX
                        OResult.F64MotionRightX = 0 'Me.m_F64ResultRightX
                        OResult.F64MotionY = Me.m_F64ResultY
                        OResult.F64MotionT = 0 'Me.m_F64ResultT
                        OResult.F64RetryCount = Me.m_I32RetryCount
                        OResult.OTimeElapsed = Me.m_OTimeElapsed
                        Me.SendAlignmentToFile(OResult)
                        m_OTmpResultforVectorAdditionB = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunAlignmentRight()
        Try
            If (m_BMarkRequest = False) Then
                Me.m_OLeft.RequestMark()
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting GOA 2nd Mark..."))
                m_BMarkRequest = True
            End If

            Dim OLeftResult As CMarkResult = Me.m_OTmpLeftMarkResult
            Dim ORightResult As CMarkResult = Me.m_OLeft.GetMarkResult()

            If (Me.m_EStage = EStage.A) Then
                Me.m_OTmpResultforVectorAdditionA = ORightResult
            Else
                Me.m_OTmpResultforVectorAdditionB = ORightResult
            End If

            If (Not OLeftResult Is Nothing) AndAlso (Not ORightResult Is Nothing) Then
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : GOA 2nd Mark Found..."))
                m_BMarkRequest = False
                Me.m_OTmpLeftMarkResult = Nothing
                Me.m_BRightAlignmentComplete = True
                Me.m_BLeftAlignmentComplete = True '20190427

                Dim EResult As ERESULT = EResult.NONE
                Dim EView As EVIEW = EView.NONE
                If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) AndAlso _
                   ((ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True)) Then
                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Alignment Axis " & _
                            "L(" & Math.Round(OLeftResult.F64X, 3) & ", " & Math.Round(OLeftResult.F64Y, 3) & ") " & _
                            "R(" & Math.Round(ORightResult.F64X, 3) & ", " & Math.Round(ORightResult.F64Y, 3) & ")" _
                        ) _
                    )

                    'Camera Offset
                    Dim F64TTT As Double = 0
                    CMotionController.It.OPLC.GetEquipInfo _
                    ( _
                        Me.m_EStage, _
                        Me.m_F64AlignmentMotionLeftX, _
                        Me.m_F64AlignmentMotionRightX, _
                        Me.m_F64AlignmentMotionY, _
                        F64TTT _
                    )

                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion LX = " & Me.m_F64AlignmentMotionLeftX))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion RX = N/A"))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion Y = " & Me.m_F64AlignmentMotionY))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion T = " & F64TTT))


                    Me.m_F64AlignmentMotionLeftX = Me.m_F64AlignmentMotionLeftX - Me.m_F64AlignmentStdMotionLeftX
                    Me.m_F64AlignmentMotionRightX = 0 '(Me.m_F64AlignmentMotionRightX - Me.m_F64AlignmentStdMotionRightX) * -1
                    Me.m_F64AlignmentMotionY = (Me.m_F64AlignmentMotionY - Me.m_F64AlignmentStdMotionY) * -1 '↑+

                    Me.m_OAlgorithm.SetViewOffset(0, Me.m_F64AlignmentMotionLeftX, Me.m_F64AlignmentMotionY)
                    Me.m_OAlgorithm.SetViewOffset(1, Me.m_F64AlignmentMotionRightX, Me.m_F64AlignmentMotionY)

                    'Target
                    Me.m_OAlgorithm.SetTarget_Orthogonal(0, OLeftResult.OImageInfo.OImage.Width / 2D, OLeftResult.OImageInfo.OImage.Height / 2D)
                    Me.m_OAlgorithm.SetTarget_Orthogonal(1, ORightResult.OImageInfo.OImage.Width / 2D, ORightResult.OImageInfo.OImage.Height / 2D)

                    'Left Orthogonal Alignment
                    Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
                    Me.m_OAlgorithm.RunAlignment_Orthogonal _
                    ( _
                        New Double() {OLeftResult.F64X, ORightResult.F64X}, _
                        New Double() {OLeftResult.F64Y, ORightResult.F64Y}, _
                        Me.m_F64ResultLeftX, Me.m_F64ResultY, Me.m_F64ResultT, _
                        0
                    )

                    If (Me.m_I32RetryCount > CEnvironment.It.MaxRetry) Then
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.MAX_RETRY_REACHED)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.LEFT)
                        Me.m_I32RetryCount = 0
                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.LEFT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Max Retry Limit Reached"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Max Retry Limit Reached")
                        Return
                    End If

                    'Review
                    If ((Math.Abs(Me.m_F64ResultLeftX) > Me.m_ORecipe.F64AlignmentLeftXLimit) OrElse _
                        (Math.Abs(Me.m_F64ResultRightX) > Me.m_ORecipe.F64AlignmentRightXLimit) OrElse _
                        (Math.Abs(Me.m_F64ResultY) > Me.m_ORecipe.F64AlignmentYLimit) OrElse _
                        (Math.Abs(Me.m_F64ResultT) > Me.m_ORecipe.F64AlignmentTLimit)) Then
                        If ((Math.Abs(Me.m_F64ResultLeftX) > 5) OrElse _
                            (Math.Abs(Me.m_F64ResultRightX) > 5) OrElse _
                            (Math.Abs(Me.m_F64ResultY) > 5) OrElse _
                            (Math.Abs(Me.m_F64ResultT) > 5)) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_CALIBRATION_ERROR)
                            CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.LEFT)
                            Me.m_I32RetryCount = 0
                            'Need Calibration
                            EResult = DualScriber.ERESULT.NG
                            EView = DualScriber.EVIEW.LEFT
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Need Calibration)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Need Calibration)")
                        Else
                            CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)
                            CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.RETRY, EView.NONE)
                            'Me.m_I32RetryCount += 1
                            'Retry
                            EResult = DualScriber.ERESULT.RETRY
                            EView = DualScriber.EVIEW.NONE
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment Retry"))
                            CLogTool.It.SetLog _
                            ( _
                                New CLog _
                                ( _
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Send Alignment Movement " & _
                                    "LX(" & Math.Round(Me.m_F64ResultLeftX, 3) & "), " & _
                                    "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " & _
                                    "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                                    "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                                ) _
                            )
                        End If
                    Else
                        'OK
                        EResult = DualScriber.ERESULT.OK
                        EView = DualScriber.EVIEW.NONE
                        ' Tact
                        Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.OK, EView.NONE)
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment OK"))
                    End If
                Else
                    'Cannot Find Mark
                    If (OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False) Then
                        'Left NG
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_LEFT_UNKNOWN)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.LEFT)
                        Me.m_I32RetryCount = 0
                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.LEFT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left unknown point)"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left unknown point)")
                    ElseIf (ORightResult.BInspected = False) OrElse (ORightResult.BOK = False) Then
                        'Right NG
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_RIGHT_UNKNOWN)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.RIGHT)
                        Me.m_I32RetryCount = 0
                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.RIGHT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right unknown point)"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right unknown point)")
                    End If
                End If


                Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, OLeftResult, ORightResult)
                OResult.EResult = EResult
                OResult.EView = EView
                If Not EResult = DualScriber.ERESULT.NG Then
                    OResult.F64MotionLeftX = Me.m_F64ResultLeftX
                    OResult.F64MotionRightX = Me.m_F64ResultRightX
                    OResult.F64MotionY = Me.m_F64ResultY
                    OResult.F64MotionT = Me.m_F64ResultT
                End If
                Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                OResult.F64RetryCount = Me.m_I32RetryCount
                OResult.OTimeElapsed = Me.m_OTimeElapsed
          
                Me.OnDisplayPartial(OResult, 0, 1)
                Me.SendAlignmentToFile(OResult)

                If (EResult = DualScriber.ERESULT.OK) Then
                    Me.m_I32RetryCount = 0
                    Me.m_OTimeElapsed = TimeSpan.Zero
                End If

                'Me.m_BRightAlignmentComplete = True
                'Me.m_BLeftAlignmentComplete = False
            End If

            'Me.m_OLeft.InitMarkResult()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunAlignmentRight_RightStandard()
        Try
            If (m_BMarkRequest = False) Then
                Me.m_ORight.RequestMark()
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting GOA 1st Mark..."))
                m_BMarkRequest = True
            End If

            Dim OTmpResult As CMarkResult = Me.m_ORight.GetMarkResult()
            Me.m_OTmpRightMarkResult = OTmpResult
            If (Not OTmpResult Is Nothing) Then
                Me.m_I32RetryCount += 1
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : GOA 1st Mark Found..."))
                m_BMarkRequest = False
                'OTmpResult = Nothing

                If (Not Me.m_OTmpRightMarkResult Is Nothing AndAlso Me.m_OTmpRightMarkResult.BOK = True) Then

                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = True

                    Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, Me.m_OTmpRightMarkResult, Nothing)
                    Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                    'OResult.F64RetryCount = Me.m_I32RetryCount
                    OResult.OTimeElapsed = Me.m_OTimeElapsed
                    Me.OnDisplayPartial(OResult, 1, 0) '스테이지 A 또는 B의 오른쪽 카메라 화면

                    Me.m_ORight.InitMarkResult()
                End If

                'Cannot Find Mark
                If (Me.m_OTmpRightMarkResult.BInspected = False) OrElse (Me.m_OTmpRightMarkResult.BOK = False) Then
                    CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_RIGHT_UNKNOWN)
                    CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.RIGHT)
                    Me.m_I32RetryCount = 0
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right Partial unknown point)"))
                    Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right Partial unknown point)")
                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = False
                    If (Me.m_EStage = EStage.A) Then
                        Me.m_BRunAlignment_A = False
                    Else

                        Me.m_BRunAlignment_B = False
                    End If
                    Return
                End If


                If (CMotionController.It.OPLC.VectorAddition() = 0) Then
                    If (Me.m_EStage = EStage.A) Then
                        m_OTmpResultforVectorAdditionA = Nothing
                    Else
                        m_OTmpResultforVectorAdditionB = Nothing
                    End If
                End If

                If (CMotionController.It.OPLC.VectorAddition() = 1) AndAlso _
                    ((Not m_OTmpResultforVectorAdditionA Is Nothing AndAlso Me.m_EStage = EStage.A) OrElse _
                     (Not m_OTmpResultforVectorAdditionB Is Nothing AndAlso Me.m_EStage = EStage.B)) _
                    Then

                    Me.m_I32RetryCount = 0
                    Me.m_BLeftAlignmentComplete = False
                    Me.m_BRightAlignmentComplete = False
                    If (Me.m_EStage = EStage.A) Then
                        Me.m_BRunAlignment_A = False
                    Else

                        Me.m_BRunAlignment_B = False
                    End If

                    If (Not Me.m_OTmpRightMarkResult Is Nothing AndAlso Me.m_OTmpRightMarkResult.BOK = True) Then
                        'Target
                        Me.m_OAlgorithm.SetTarget_Orthogonal(0, m_OTmpRightMarkResult.OImageInfo.OImage.Width / 2D, m_OTmpRightMarkResult.OImageInfo.OImage.Height / 2D)
                        Me.m_OAlgorithm.SetTarget_Orthogonal(1, m_OTmpRightMarkResult.OImageInfo.OImage.Width / 2D, m_OTmpRightMarkResult.OImageInfo.OImage.Height / 2D)
                        Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
                        Me.m_OAlgorithm.RunAlignment_Orthogonal _
                      ( _
                          New Double() {m_OTmpRightMarkResult.OImageInfo.OImage.Width / 2D, m_OTmpRightMarkResult.OImageInfo.OImage.Width / 2D}, _
                          New Double() {m_OTmpRightMarkResult.F64Y, m_OTmpRightMarkResult.F64Y}, _
                          Me.m_F64ResultLeftX, Me.m_F64ResultY, Me.m_F64ResultT, _
                          0
                      )

                        CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, 0, 0, Me.m_F64ResultY, 0)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.OK, EVIEW.NONE)

                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : OK (Additional Alignment)"))
                        CLogTool.It.SetLog _
                        ( _
                            New CLog _
                            ( _
                                "ST#" & CType(Me.m_EStage, Integer) & " : Send Additional Movement " &
                                "Y(" & Math.Round(Me.m_F64ResultY, 3) & ") "
                            ) _
                        )
                    Else
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Fail To Give Additional Movement"))
                    End If



                    Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                    If (Me.m_EStage = EStage.A) Then
                        Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, m_OTmpRightMarkResult, m_OTmpResultforVectorAdditionA)
                        OResult.EResult = ERESULT.OK
                        OResult.EView = EVIEW.RIGHT
                        OResult.F64MotionLeftX = 0 'Me.m_F64ResultLeftX
                        OResult.F64MotionRightX = 0 'Me.m_F64ResultRightX
                        OResult.F64MotionY = Me.m_F64ResultY
                        OResult.F64MotionT = 0 'Me.m_F64ResultT
                        OResult.F64RetryCount = Me.m_I32RetryCount
                        OResult.OTimeElapsed = Me.m_OTimeElapsed

                        Me.SendAlignmentToFile(OResult)
                        m_OTmpResultforVectorAdditionA = Nothing
                    Else
                        Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, m_OTmpRightMarkResult, m_OTmpResultforVectorAdditionB)
                        OResult.EResult = ERESULT.OK
                        OResult.EView = EVIEW.RIGHT
                        OResult.F64MotionLeftX = 0 'Me.m_F64ResultLeftX
                        OResult.F64MotionRightX = 0 'Me.m_F64ResultRightX
                        OResult.F64MotionY = Me.m_F64ResultY
                        OResult.F64MotionT = 0 'Me.m_F64ResultT
                        OResult.F64RetryCount = Me.m_I32RetryCount
                        OResult.OTimeElapsed = Me.m_OTimeElapsed

                        Me.SendAlignmentToFile(OResult)
                        m_OTmpResultforVectorAdditionB = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunAlignmentLeft_RightStandard()
        Try
            If (m_BMarkRequest = False) Then
                Me.m_ORight.RequestMark()
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Requesting GOA 2nd Mark..."))
                m_BMarkRequest = True
            End If


            Dim OLeftResult As CMarkResult = Me.m_OTmpRightMarkResult
            Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()

            If (Me.m_EStage = EStage.A) Then
                Me.m_OTmpResultforVectorAdditionA = ORightResult
            Else
                Me.m_OTmpResultforVectorAdditionB = ORightResult
            End If

            If (Not OLeftResult Is Nothing) AndAlso (Not ORightResult Is Nothing) Then
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : GOA 2nd Mark Found..."))
                m_BMarkRequest = False
                Me.m_OTmpRightMarkResult = Nothing
                Me.m_BRightAlignmentComplete = True '20190427
                Me.m_BLeftAlignmentComplete = True

                Dim EResult As ERESULT = EResult.NONE
                Dim EView As EVIEW = EView.NONE
                If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) AndAlso
                   ((ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True)) Then
                    CLogTool.It.SetLog _
                    (
                        New CLog _
                        (
                            "ST#" & CType(Me.m_EStage, Integer) & " : Alignment Axis " &
                            "L(" & Math.Round(OLeftResult.F64X, 3) & ", " & Math.Round(OLeftResult.F64Y, 3) & ") " &
                            "R(" & Math.Round(ORightResult.F64X, 3) & ", " & Math.Round(ORightResult.F64Y, 3) & ")"
                        )
                    )

                    'Camera Offset
                    Dim F64TTT As Double = 0
                    CMotionController.It.OPLC.GetEquipInfo _
                    (
                        Me.m_EStage,
                        Me.m_F64AlignmentMotionLeftX,
                        Me.m_F64AlignmentMotionRightX,
                        Me.m_F64AlignmentMotionY,
                        F64TTT
                    )

                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion LX = N/A"))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion RX = " & Me.m_F64AlignmentMotionRightX))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion Y = " & Me.m_F64AlignmentMotionY))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion T = " & F64TTT))

                    Me.m_F64AlignmentMotionLeftX = 0 'Me.m_F64AlignmentMotionLeftX - Me.m_F64AlignmentStdMotionLeftX
                    Me.m_F64AlignmentMotionRightX = (Me.m_F64AlignmentMotionRightX - Me.m_F64AlignmentStdMotionRightX) * -1
                    Me.m_F64AlignmentMotionY = (Me.m_F64AlignmentMotionY - Me.m_F64AlignmentStdMotionY) * -1 '↑+

                    Me.m_OAlgorithm.SetViewOffset(0, Me.m_F64AlignmentMotionLeftX, Me.m_F64AlignmentMotionY)
                    Me.m_OAlgorithm.SetViewOffset(1, Me.m_F64AlignmentMotionRightX, Me.m_F64AlignmentMotionY)
                    'Target
                    Me.m_OAlgorithm.SetTarget_Orthogonal(0, OLeftResult.OImageInfo.OImage.Width / 2D, OLeftResult.OImageInfo.OImage.Height / 2D)
                    Me.m_OAlgorithm.SetTarget_Orthogonal(1, ORightResult.OImageInfo.OImage.Width / 2D, ORightResult.OImageInfo.OImage.Height / 2D)

                    'Right Orthogonal Alignment _ Right Standard
                    Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
                    Me.m_OAlgorithm.RunAlignment_Orthogonal _
                    (
                        New Double() {OLeftResult.F64X, ORightResult.F64X},
                        New Double() {OLeftResult.F64Y, ORightResult.F64Y},
                        Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT,
                        1
                    )

                    If (Me.m_I32RetryCount > CEnvironment.It.MaxRetry) Then
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.MAX_RETRY_REACHED)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.LEFT)
                        Me.m_I32RetryCount = 0
                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.LEFT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Max Retry Limit Reached"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Max Retry Limit Reached")
                        Return
                    End If

                    'Review
                    If ((Math.Abs(Me.m_F64ResultLeftX) > Me.m_ORecipe.F64AlignmentLeftXLimit) OrElse
                        (Math.Abs(Me.m_F64ResultRightX) > Me.m_ORecipe.F64AlignmentRightXLimit) OrElse
                        (Math.Abs(Me.m_F64ResultY) > Me.m_ORecipe.F64AlignmentYLimit) OrElse
                        (Math.Abs(Me.m_F64ResultT) > Me.m_ORecipe.F64AlignmentTLimit)) Then
                        If ((Math.Abs(Me.m_F64ResultLeftX) > 5) OrElse
                            (Math.Abs(Me.m_F64ResultRightX) > 5) OrElse
                            (Math.Abs(Me.m_F64ResultY) > 5) OrElse
                            (Math.Abs(Me.m_F64ResultT) > 5)) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_CALIBRATION_ERROR)
                            CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.LEFT)
                            Me.m_I32RetryCount = 0
                            'Need Calibration
                            EResult = DualScriber.ERESULT.NG
                            EView = DualScriber.EVIEW.LEFT
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Need Calibration)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Need Calibration)")
                        Else
                            CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)
                            CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.RETRY, EView.NONE)
                            'Me.m_I32RetryCount += 1
                            'Retry
                            EResult = DualScriber.ERESULT.RETRY
                            EView = DualScriber.EVIEW.NONE
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment Retry"))
                            CLogTool.It.SetLog _
                            (
                                New CLog _
                                (
                                    "ST#" & CType(Me.m_EStage, Integer) & " : Send Alignment Movement " &
                                    "LX(" & Math.Round(Me.m_F64ResultLeftX, 3) & "), " &
                                    "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " &
                                    "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " &
                                    "T(" & Math.Round(Me.m_F64ResultT, 4) & "), "
                                )
                            )
                        End If
                    Else
                        'OK
                        EResult = DualScriber.ERESULT.OK
                        EView = DualScriber.EVIEW.NONE
                        ' Tact
                        Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.OK, EView.NONE)
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment OK"))
                    End If
                Else
                    'Cannot Find Mark
                    If (OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False) Then
                        'Left NG
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_LEFT_UNKNOWN)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.LEFT)
                        Me.m_I32RetryCount = 0
                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.LEFT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left unknown point)"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left unknown point)")
                    ElseIf (ORightResult.BInspected = False) OrElse (ORightResult.BOK = False) Then
                        'Right NG
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_RIGHT_UNKNOWN)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, EResult.NG, EView.RIGHT)
                        Me.m_I32RetryCount = 0
                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.RIGHT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right unknown point)"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right unknown point)")
                    End If
                End If

                Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, OLeftResult, ORightResult)
                OResult.EResult = EResult
                OResult.EView = EView
                If Not EResult = DualScriber.ERESULT.NG Then
                    OResult.F64MotionLeftX = Me.m_F64ResultLeftX
                    OResult.F64MotionRightX = Me.m_F64ResultRightX
                    OResult.F64MotionY = Me.m_F64ResultY
                    OResult.F64MotionT = Me.m_F64ResultT
                End If
                Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                OResult.F64RetryCount = Me.m_I32RetryCount
                OResult.OTimeElapsed = Me.m_OTimeElapsed
             
                Me.OnDisplayPartial(OResult, 1, 1)
                Me.SendAlignmentToFile(OResult)

                If (EResult = DualScriber.ERESULT.OK) Then
                    Me.m_I32RetryCount = 0
                    Me.m_OTimeElapsed = TimeSpan.Zero
                End If
            End If
            'Me.m_ORight.InitMarkResult()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunAlignment()
        Try
            Dim OLeftResult As CMarkResult = Me.m_OLeft.GetMarkResult()
            Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()

            If (Not OLeftResult Is Nothing) AndAlso (Not ORightResult Is Nothing) Then
                If (Me.m_EStage = ESTAGE.A) Then
                    Me.m_BRunAlignment_A = False
                Else

                    Me.m_BRunAlignment_B = False
                End If

                Dim EResult As ERESULT = ERESULT.NONE
                Dim EView As EVIEW = EVIEW.NONE
                If ((OLeftResult.BInspected = True) AndAlso (OLeftResult.BOK = True)) AndAlso
                   ((ORightResult.BInspected = True) AndAlso (ORightResult.BOK = True)) Then
                    ' 소수점 자리 4
                    CLogTool.It.SetLog _
                    (
                        New CLog _
                        (
                            "ST#" & CType(Me.m_EStage, Integer) & " : Alignment Axis " &
                            "L(" & Math.Round(OLeftResult.F64X, 4) & ", " & Math.Round(OLeftResult.F64Y, 4) & ") " &
                            "R(" & Math.Round(ORightResult.F64X, 4) & ", " & Math.Round(ORightResult.F64Y, 4) & ")"
                        )
                    )

                    ' jht Max Retry NG
                    If (Me.m_I32RetryCount > CEnvironment.It.MaxRetry) Then
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & "Max Retry Num. Reached!"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Max Retry Num. Reached!")

                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.MAX_RETRY_REACHED)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)

                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.NONE

                        'Me.m_BLeftAlignmentComplete = False
                        'Me.m_BRightAlignmentComplete = False

                        Me.m_I32RetryCount = 0
                        Return
                    End If


                    'Camera Offset
                    Dim F64TTT As Double = 0
                    CMotionController.It.OPLC.GetEquipInfo _
                    (
                        Me.m_EStage,
                        Me.m_F64AlignmentMotionLeftX,
                        Me.m_F64AlignmentMotionRightX,
                        Me.m_F64AlignmentMotionY,
                        F64TTT
                    )

                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion LX = " & Me.m_F64AlignmentMotionLeftX))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion RX = " & Me.m_F64AlignmentMotionRightX))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion Y = " & Me.m_F64AlignmentMotionY))
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Motion T = " & F64TTT))

                    Me.m_F64AlignmentMotionLeftX = Me.m_F64AlignmentMotionLeftX - Me.m_F64AlignmentStdMotionLeftX
                    Me.m_F64AlignmentMotionRightX = (Me.m_F64AlignmentMotionRightX - Me.m_F64AlignmentStdMotionRightX) * -1
                    Me.m_F64AlignmentMotionY = (Me.m_F64AlignmentMotionY - Me.m_F64AlignmentStdMotionY) * -1 '↑+
                    'Me.m_F64AlignmentMotionY = Me.m_F64AlignmentMotionY - Me.m_F64AlignmentStdMotionY '↓+

                    Me.m_OAlgorithm.SetViewOffset(0, Me.m_F64AlignmentMotionLeftX, Me.m_F64AlignmentMotionY)
                    Me.m_OAlgorithm.SetViewOffset(1, Me.m_F64AlignmentMotionRightX, Me.m_F64AlignmentMotionY)

                    'Target
                    Me.m_OAlgorithm.SetTarget(0, OLeftResult.OImageInfo.OImage.Width / 2D, OLeftResult.OImageInfo.OImage.Height / 2D)
                    Me.m_OAlgorithm.SetTarget(1, ORightResult.OImageInfo.OImage.Width / 2D, ORightResult.OImageInfo.OImage.Height / 2D)

                    'Left Alignment
                    Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
                    Me.m_OAlgorithm.RunAlignment _
                    (
                        New Double() {OLeftResult.F64X, ORightResult.F64X},
                        New Double() {OLeftResult.F64Y, ORightResult.F64Y},
                        Me.m_F64ResultLeftX, Me.m_F64ResultY, Me.m_F64ResultT
                    )
                    'Right Alignment
                    Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.RIGHT, EWEIGHT_VERTICAL.TOP)
                    Me.m_OAlgorithm.RunAlignment _
                    (
                        New Double() {OLeftResult.F64X, ORightResult.F64X},
                        New Double() {OLeftResult.F64Y, ORightResult.F64Y},
                        Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT
                    )
                    ' 반올림 추가
                    If ((Math.Abs(Math.Round(Me.m_F64ResultLeftX, 4)) > Me.m_ORecipe.F64AlignmentLeftXLimit) OrElse
                        (Math.Abs(Math.Round(Me.m_F64ResultRightX, 4)) > Me.m_ORecipe.F64AlignmentRightXLimit) OrElse
                        (Math.Abs(Math.Round(Me.m_F64ResultY, 4)) > Me.m_ORecipe.F64AlignmentYLimit) OrElse
                        (Math.Abs(Math.Round(Me.m_F64ResultT, 5)) > Me.m_ORecipe.F64AlignmentTLimit)) Then
                        If ((Math.Abs(Me.m_F64ResultLeftX) > 5) OrElse
                            (Math.Abs(Me.m_F64ResultRightX) > 5) OrElse
                            (Math.Abs(Me.m_F64ResultY) > 5) OrElse
                            (Math.Abs(Me.m_F64ResultT) > 5)) Then
                            ' Retry 리셋
                            Me.m_I32RetryCount = 0

                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_CALIBRATION_ERROR)
                            CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)

                            'Need Calibration
                            EResult = DualScriber.ERESULT.NG
                            EView = DualScriber.EVIEW.LEFT
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Need Calibration)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Need Calibration)")
                        Else
                            ' jht 시뮬레이션인 경우 OK로 보냄
                            If 1 = Me.m_iSimulationMode Then
                                'OK
                                EResult = DualScriber.ERESULT.OK
                                EView = DualScriber.EVIEW.NONE
                                ' Tact
                                Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin

                                CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.OK, EVIEW.NONE)
                                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Simulation Alignment OK"))
                            Else
                                CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)
                                CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.RETRY, EVIEW.NONE)
                                ' Retry 증가
                                Me.m_I32RetryCount += 1
                                'Retry
                                EResult = DualScriber.ERESULT.RETRY
                                EView = DualScriber.EVIEW.NONE
                                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment Retry"))
                                ' 소수점 3 -> 4
                                CLogTool.It.SetLog _
                                (
                                    New CLog _
                                    (
                                        "ST#" & CType(Me.m_EStage, Integer) & " : Send Alignment Movement " &
                                        "LX(" & Math.Round(Me.m_F64ResultLeftX, 4) & "), " &
                                        "RX(" & Math.Round(Me.m_F64ResultRightX, 4) & "), " &
                                        "Y(" & Math.Round(Me.m_F64ResultY, 4) & "), " &
                                        "T(" & Math.Round(Me.m_F64ResultT, 5) & "), "
                                    )
                                )
                            End If
                        End If
                    Else
                        'OK
                        EResult = DualScriber.ERESULT.OK
                        EView = DualScriber.EVIEW.NONE
                        Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.OK, EVIEW.NONE)
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment OK"))
                    End If
                Else
                    'Cannot Find Mark
                    If (OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False) Then
                        'Left NG
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_LEFT_UNKNOWN)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)
                        ' Retry 리셋
                        Me.m_I32RetryCount = 0

                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.LEFT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left unknown point)"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Left unknown point)")
                    ElseIf (ORightResult.BInspected = False) OrElse (ORightResult.BOK = False) Then
                        'Right NG
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_RIGHT_UNKNOWN)
                        CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.RIGHT)
                        ' Retry 리셋
                        Me.m_I32RetryCount = 0

                        EResult = DualScriber.ERESULT.NG
                        EView = DualScriber.EVIEW.RIGHT
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right unknown point)"))
                        Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Alignment NG(Right unknown point)")
                    End If
                End If

                Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, OLeftResult, ORightResult)
                OResult.EResult = EResult
                OResult.EView = EView
                OResult.F64RetryCount = Me.m_I32RetryCount
                OResult.OTimeElapsed = Me.m_OTimeElapsed
                If (EResult = DualScriber.ERESULT.OK) Then
                    Me.m_I32RetryCount = 0
                    Me.m_OTimeElapsed = TimeSpan.Zero
                End If
                If Not EResult = DualScriber.ERESULT.NG Then
                    OResult.F64MotionLeftX = Me.m_F64ResultLeftX
                    OResult.F64MotionRightX = Me.m_F64ResultRightX
                    OResult.F64MotionY = Me.m_F64ResultY
                    OResult.F64MotionT = Me.m_F64ResultT
                End If

                Me.OnAlignmentRan(OResult)
                Me.SendAlignmentToFile(OResult)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub RunPartialManualAlignment _
   ( _
       ByVal OImage As CogImage8Grey, _
       ByVal F64LeftX As Double, ByVal F64LeftY As Double, ByVal F64RightX As Double, ByVal F64RightY As Double _
   )
        Try
            Monitor.Enter(Me.m_OInterrupt)
            If (Me.m_EStage = ESTAGE.A) Then
                Me.m_BRunAlignment_A = False
            Else

                Me.m_BRunAlignment_B = False
            End If

            Dim EResult As ERESULT = EResult.NONE
            Dim EView As EVIEW = EView.NONE
            'the image is used so that we can find the center X,Y
            Dim OLeftResult As CMarkResult = New CMarkResult(New CImageInfo(OImage))
            OLeftResult.EView = DualScriber.EVIEW.LEFT
            OLeftResult.BInspected = True
            OLeftResult.BOK = True
            OLeftResult.F64Score = 100
            OLeftResult.F64X = F64LeftX
            OLeftResult.F64Y = F64LeftY

            Dim ORightResult As CMarkResult = New CMarkResult(New CImageInfo(OImage))
            ORightResult.EView = DualScriber.EVIEW.LEFT
            ORightResult.BInspected = True
            ORightResult.BOK = True
            ORightResult.F64Score = 100
            ORightResult.F64X = F64RightX
            ORightResult.F64Y = F64RightY

            CLogTool.It.SetLog _
            ( _
                New CLog _
                ( _
                    "ST#" & CType(Me.m_EStage, Integer) & " : Manual Alignment Axis " & _
                    "L(" & Math.Round(OLeftResult.F64X, 3) & ", " & Math.Round(OLeftResult.F64Y, 3) & ") " & _
                    "R(" & Math.Round(ORightResult.F64X, 3) & ", " & Math.Round(ORightResult.F64Y, 3) & ")" _
                ) _
            )

            'Calc Offset
            CMotionController.It.OPLC.GetEquipInfo _
            ( _
                Me.m_EStage, _
                Me.m_F64AlignmentMotionLeftX, _
                Me.m_F64AlignmentMotionRightX, _
                Me.m_F64AlignmentMotionY, _
                Me.m_F64AlignmentMotionT _
            )
            Me.m_F64AlignmentMotionLeftX = Me.m_F64AlignmentMotionLeftX - Me.m_F64AlignmentStdMotionLeftX
            Me.m_F64AlignmentMotionRightX = (Me.m_F64AlignmentMotionRightX - Me.m_F64AlignmentStdMotionRightX) * -1
            Me.m_F64AlignmentMotionY = (Me.m_F64AlignmentMotionY - Me.m_F64AlignmentStdMotionY) * -1 '↑+orga

            'Calc Movement
            Me.m_OAlgorithm.SetViewOffset(0, Me.m_F64AlignmentMotionLeftX, Me.m_F64AlignmentMotionY)
            Me.m_OAlgorithm.SetViewOffset(1, Me.m_F64AlignmentMotionRightX, Me.m_F64AlignmentMotionY)

            Me.m_OAlgorithm.SetTarget_Orthogonal(0, OLeftResult.OImageInfo.OImage.Width / 2D, OLeftResult.OImageInfo.OImage.Height / 2D)
            Me.m_OAlgorithm.SetTarget_Orthogonal(1, ORightResult.OImageInfo.OImage.Width / 2D, ORightResult.OImageInfo.OImage.Height / 2D)
            If (CMotionController.It.OPLC.GetBLeftOrRightStandard() = 0) Then
                Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
                'Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.RIGHT, EWEIGHT_VERTICAL.MIDDLE)
                Me.m_OAlgorithm.RunAlignment_Orthogonal _
                ( _
                    New Double() {OLeftResult.F64X, ORightResult.F64X}, _
                    New Double() {OLeftResult.F64Y, ORightResult.F64Y}, _
                    Me.m_F64ResultLeftX, Me.m_F64ResultY, Me.m_F64ResultT, _
                    0
                )
            Else
                Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.RIGHT, EWEIGHT_VERTICAL.TOP)
                'Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.RIGHT, EWEIGHT_VERTICAL.MIDDLE)
                Me.m_OAlgorithm.RunAlignment_Orthogonal _
                ( _
                    New Double() {OLeftResult.F64X, ORightResult.F64X}, _
                    New Double() {OLeftResult.F64Y, ORightResult.F64Y}, _
                    Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT, _
                    1
                )
            End If


            'Judge Movement Status
            If ((Math.Abs(Me.m_F64ResultLeftX) > 0) OrElse _
                (Math.Abs(Me.m_F64ResultRightX) > 0) OrElse _
                (Math.Abs(Me.m_F64ResultY) > 0) OrElse _
                (Math.Abs(Me.m_F64ResultT) > 0)) Then
                If ((Math.Abs(Me.m_F64ResultLeftX) > 5) OrElse _
                    (Math.Abs(Me.m_F64ResultRightX) > 5) OrElse _
                    (Math.Abs(Me.m_F64ResultY) > 5) OrElse _
                    (Math.Abs(Me.m_F64ResultT) > 5)) Then
                    EResult = DualScriber.ERESULT.NG
                    EView = DualScriber.EVIEW.LEFT
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Manual Alignment NG(Need Calibration)"))
                Else
                    CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)
                    CMotionController.It.OPLC.SendManualAlignment(Me.m_EStage)

                    EResult = DualScriber.ERESULT.RETRY
                    EView = DualScriber.EVIEW.NONE
                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Manual Alignment Movement " & _
                            "LX(" & Math.Round(Me.m_F64ResultLeftX, 3) & "), " & _
                            "RX(" & Math.Round(Me.m_F64ResultRightX, 3) & "), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 3) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 4) & "), " _
                        ) _
                    )
                End If
            Else
                EResult = DualScriber.ERESULT.OK
                EView = DualScriber.EVIEW.NONE
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Manual Alignment OK"))
            End If

            'Display To Screen
            Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, OLeftResult, ORightResult)
            OResult.EResult = EResult
            OResult.EView = EView
            If Not EResult = DualScriber.ERESULT.NG Then
                OResult.F64MotionLeftX = Me.m_F64ResultLeftX
                OResult.F64MotionRightX = Me.m_F64ResultRightX
                OResult.F64MotionY = Me.m_F64ResultY
                OResult.F64MotionT = Me.m_F64ResultT
            End If

            Me.OnAlignmentRan(OResult)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub RunManualAlignment _
   ( _
       ByVal OLeftImage As CogImage8Grey, ByVal ORightImage As CogImage8Grey, _
       ByVal F64LeftX As Double, ByVal F64LeftY As Double, ByVal F64RightX As Double, ByVal F64RightY As Double _
   )
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (Me.m_EStage = ESTAGE.A) Then
                Me.m_BRunAlignment_A = False
            Else

                Me.m_BRunAlignment_B = False
            End If
            Dim EResult As ERESULT = EResult.NONE
            Dim EView As EVIEW = EView.NONE

            Dim OLeftResult As CMarkResult = New CMarkResult(New CImageInfo(OLeftImage))
            OLeftResult.EView = DualScriber.EVIEW.LEFT
            OLeftResult.BInspected = True
            OLeftResult.BOK = True
            OLeftResult.F64Score = 1
            OLeftResult.F64X = F64LeftX
            OLeftResult.F64Y = F64LeftY

            Dim ORightResult As CMarkResult = New CMarkResult(New CImageInfo(ORightImage))
            ORightResult.EView = DualScriber.EVIEW.LEFT
            ORightResult.BInspected = True
            ORightResult.BOK = True
            ORightResult.F64Score = 1
            ORightResult.F64X = F64RightX
            ORightResult.F64Y = F64RightY

            CLogTool.It.SetLog _
            ( _
                New CLog _
                ( _
                    "ST#" & CType(Me.m_EStage, Integer) & " : Manual Alignment Axis " & _
                    "L(" & Math.Round(OLeftResult.F64X, 4) & ", " & Math.Round(OLeftResult.F64Y, 4) & ") " & _
                    "R(" & Math.Round(ORightResult.F64X, 4) & ", " & Math.Round(ORightResult.F64Y, 4) & ")" _
                ) _
            )

            'Calc Offset
            CMotionController.It.OPLC.GetEquipInfo _
            ( _
                Me.m_EStage, _
                Me.m_F64AlignmentMotionLeftX, _
                Me.m_F64AlignmentMotionRightX, _
                Me.m_F64AlignmentMotionY, _
                Me.m_F64AlignmentMotionT _
            )
            Me.m_F64AlignmentMotionLeftX = Me.m_F64AlignmentMotionLeftX - Me.m_F64AlignmentStdMotionLeftX
            Me.m_F64AlignmentMotionRightX = (Me.m_F64AlignmentMotionRightX - Me.m_F64AlignmentStdMotionRightX) * -1
            Me.m_F64AlignmentMotionY = (Me.m_F64AlignmentMotionY - Me.m_F64AlignmentStdMotionY) * -1 '↑+orga

            'Calc Movement
            Me.m_OAlgorithm.SetViewOffset(0, Me.m_F64AlignmentMotionLeftX, Me.m_F64AlignmentMotionY)
            Me.m_OAlgorithm.SetViewOffset(1, Me.m_F64AlignmentMotionRightX, Me.m_F64AlignmentMotionY)
            Me.m_OAlgorithm.SetTarget(0, OLeftResult.OImageInfo.OImage.Width / 2D, OLeftResult.OImageInfo.OImage.Height / 2D)
            Me.m_OAlgorithm.SetTarget(1, ORightResult.OImageInfo.OImage.Width / 2D, ORightResult.OImageInfo.OImage.Height / 2D)
            Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.LEFT, EWEIGHT_VERTICAL.TOP)
            Me.m_OAlgorithm.RunAlignment _
            ( _
                New Double() {OLeftResult.F64X, ORightResult.F64X}, _
                New Double() {OLeftResult.F64Y, ORightResult.F64Y}, _
                Me.m_F64ResultLeftX, Me.m_F64ResultY, Me.m_F64ResultT _
            )
            Me.m_OAlgorithm.SetWeight(EWEIGHT_HORIZON.RIGHT, EWEIGHT_VERTICAL.TOP)
            Me.m_OAlgorithm.RunAlignment _
            ( _
                New Double() {OLeftResult.F64X, ORightResult.F64X}, _
                New Double() {OLeftResult.F64Y, ORightResult.F64Y}, _
                Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT _
            )

            'Judge Movement Status
            If ((Math.Abs(Me.m_F64ResultLeftX) > 0) OrElse _
                (Math.Abs(Me.m_F64ResultRightX) > 0) OrElse _
                (Math.Abs(Me.m_F64ResultY) > 0) OrElse _
                (Math.Abs(Me.m_F64ResultT) > 0)) Then
                If ((Math.Abs(Me.m_F64ResultLeftX) > 5) OrElse _
                    (Math.Abs(Me.m_F64ResultRightX) > 5) OrElse _
                    (Math.Abs(Me.m_F64ResultY) > 5) OrElse _
                    (Math.Abs(Me.m_F64ResultT) > 5)) Then
                    ' Retry 리셋
                    Me.m_I32RetryCount = 0

                    EResult = DualScriber.ERESULT.NG
                    EView = DualScriber.EVIEW.LEFT
                    CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Manual Alignment NG(Need Calibration)"))
                Else
                    ' Retry 증가
                    Me.m_I32RetryCount += 1

                    CMotionController.It.OPLC.SendAlignmentResult(Me.m_EStage, Me.m_F64ResultLeftX, Me.m_F64ResultRightX, Me.m_F64ResultY, Me.m_F64ResultT)
                    CMotionController.It.OPLC.SendManualAlignment(Me.m_EStage)

                    EResult = DualScriber.ERESULT.RETRY
                    EView = DualScriber.EVIEW.NONE
                    CLogTool.It.SetLog _
                    ( _
                        New CLog _
                        ( _
                            "ST#" & CType(Me.m_EStage, Integer) & " : Send Manual Alignment Movement " & _
                            "LX(" & Math.Round(Me.m_F64ResultLeftX, 4) & "), " & _
                            "RX(" & Math.Round(Me.m_F64ResultRightX, 4) & "), " & _
                            "Y(" & Math.Round(Me.m_F64ResultY, 4) & "), " & _
                            "T(" & Math.Round(Me.m_F64ResultT, 5) & "), " _
                        ) _
                    )
                End If
            Else
                EResult = DualScriber.ERESULT.OK
                EView = DualScriber.EVIEW.NONE
                Me.m_OTimeElapsed = DateTime.Now - Me.m_OTimeBegin
                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Manual Alignment OK"))
            End If

            'Display To Screen
            Dim OResult As CAlignmentResult = New CAlignmentResult(Me.m_EStage, OLeftResult, ORightResult)
            OResult.EResult = EResult
            OResult.EView = EView
            OResult.F64RetryCount = Me.m_I32RetryCount
            OResult.OTimeElapsed = Me.m_OTimeElapsed
            If (EResult = DualScriber.ERESULT.OK) Then
                Me.m_I32RetryCount = 0
                Me.m_OTimeElapsed = TimeSpan.Zero
            End If
            If Not EResult = DualScriber.ERESULT.NG Then
                OResult.F64MotionLeftX = Me.m_F64ResultLeftX
                OResult.F64MotionRightX = Me.m_F64ResultRightX
                OResult.F64MotionY = Me.m_F64ResultY
                OResult.F64MotionT = Me.m_F64ResultT
            End If

            Me.OnAlignmentRan(OResult)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub SendAlignmentToFile(ByVal OResult As CAlignmentResult)
        Try
            Dim OTime As DateTime = DateTime.Now
            Dim StrLeft As String = String.Empty
            Dim StrRight As String = String.Empty

            If (Not OResult.OLeft Is Nothing) Then
                Dim OLeftFile As CImageSaveFile = New CImageSaveFile(OTime, OResult.OLeft.OImageInfo.OImage.ToBitmap())
                OLeftFile.StrDirectory = ".\Image\" & CType(Me.m_EStage, Integer) & "\Alignment\{0:yyyy}\{0:MM}\{0:dd}\{0:HH.mm.ss fff}"
                OLeftFile.StrFile = "Left.jpg"
                OLeftFile.OFormat = ImageFormat.Jpeg

                StrLeft = OLeftFile.GetFile()
                CImageSaveTool.It.Set(OLeftFile)
            End If

            If (Not OResult.ORight Is Nothing) Then
                Dim ORightFile As CImageSaveFile = New CImageSaveFile(OTime, OResult.ORight.OImageInfo.OImage.ToBitmap())
                ORightFile.StrDirectory = ".\Image\" & CType(Me.m_EStage, Integer) & "\Alignment\{0:yyyy}\{0:MM}\{0:dd}\{0:HH.mm.ss fff}"
                ORightFile.StrFile = "Right.jpg"
                ORightFile.OFormat = ImageFormat.Jpeg

                StrRight = ORightFile.GetFile()
                CImageSaveTool.It.Set(ORightFile)
            End If

            Dim OTable As IDynamicTable = CDB.It.GetDynamicTable(CDB.TABLE_REPORT)
            Try
                OTable.BeginSyncData()

                Dim I32RowIndex As Integer = OTable.InsertRow()
                OTable.Update(I32RowIndex, CDB.REPORT_DATETIME, OTime.ToString("yyyy.MM.dd HH:mm:ss fff"))
                OTable.Update(I32RowIndex, CDB.REPORT_RECIPE, Me.m_ORecipe.StrName)
                OTable.Update(I32RowIndex, CDB.REPORT_STAGE, CType(OResult.EStage, Integer).ToString())

                If ((OResult.EResult = ERESULT.OK) OrElse (OResult.EResult = ERESULT.RETRY)) Then
                    OTable.Update(I32RowIndex, CDB.REPORT_RESULT, OResult.EResult.ToString())
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_LEFT_X, Math.Round(OResult.OLeft.F64X, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_LEFT_Y, Math.Round(OResult.OLeft.F64Y, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_RIGHT_X, Math.Round(OResult.ORight.F64X, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_RIGHT_Y, Math.Round(OResult.ORight.F64Y, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_EQUIP_LEFT_X, Math.Round(OResult.F64MotionLeftX, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_EQUIP_RIGHT_X, Math.Round(OResult.F64MotionRightX, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_EQUIP_Y, Math.Round(OResult.F64MotionY, 4))
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_EQUIP_T, Math.Round(OResult.F64MotionT, 5))
                    ' If ((CMotionController.It.OPLC.GetBOversize_A() = 1 AndAlso Me.m_EStage = EStage.A) Or (CMotionController.It.OPLC.GetBOversize_B() = 1 AndAlso Me.m_EStage = EStage.B)) Then
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_NUM_OF_RETRY, OResult.F64RetryCount)
                    OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_TIME_ELAPSED, OResult.OTimeElapsed.ToString())
                    '   End If
                    OTable.Update(I32RowIndex, CDB.REPORT_LEFT_FILE, StrLeft)
                    OTable.Update(I32RowIndex, CDB.REPORT_RIGHT_FILE, StrRight)
                ElseIf (OResult.EResult = ERESULT.NG) Then
                    If (OResult.EView = EVIEW.LEFT) Then
                        OTable.Update(I32RowIndex, CDB.REPORT_RESULT, "NG(L)")
                    ElseIf (OResult.EView = EVIEW.RIGHT) Then
                        OTable.Update(I32RowIndex, CDB.REPORT_RESULT, "NG(R)")
                    End If

                    If (Not OResult.OLeft Is Nothing) Then
                        OTable.Update(I32RowIndex, CDB.REPORT_LEFT_FILE, StrLeft)

                        If ((OResult.OLeft.BInspected = True) AndAlso (OResult.OLeft.BOK = True)) Then
                            OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_LEFT_X, Math.Round(OResult.OLeft.F64X, 4))
                            OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_LEFT_Y, Math.Round(OResult.OLeft.F64Y, 4))
                        End If
                    End If

                    If (Not OResult.ORight Is Nothing) Then
                        OTable.Update(I32RowIndex, CDB.REPORT_RIGHT_FILE, StrRight)

                        If ((OResult.ORight.BInspected = True) AndAlso (OResult.ORight.BOK = True)) Then
                            OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_RIGHT_X, Math.Round(OResult.ORight.F64X, 4))
                            OTable.Update(I32RowIndex, CDB.REPORT_ALIGNMENT_VIEW_RIGHT_Y, Math.Round(OResult.ORight.F64Y, 4))
                        End If
                    End If
                End If
            Catch ex As Exception
                CError.Throw(ex)
            Finally
                OTable.EndSyncData()
            End Try
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub RunEdge()
        Try
            If (((Me.m_ELeftRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ELeftRequest = EEDGE_REQUEST.THIRD)) OrElse _
                ((Me.m_ERightRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.THIRD))) Then

                Dim OLeftResult As CMarkResult = Me.m_OLeft.GetMarkResult()
                Dim ORightResult As CMarkResult = Me.m_ORight.GetMarkResult()

                If (((Me.m_ELeftRequest = EEDGE_REQUEST.NONE) OrElse (Not OLeftResult Is Nothing)) AndAlso _
                    ((Me.m_ERightRequest = EEDGE_REQUEST.NONE) OrElse (Not ORightResult Is Nothing))) Then
                    Me.m_BRunEdge = False

                    If ((Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso _
                        ((OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False))) Then
                        If (Me.m_ELeftRequest = EEDGE_REQUEST.FIRST) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_FIRST_LEFT_MARK_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 1 NG (Not Found Left Mark)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 1 NG (Not Found Left Mark)")
                            Return
                        ElseIf (Me.m_ELeftRequest = EEDGE_REQUEST.THIRD) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_THIRD_LEFT_MARK_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 3 NG (Not Found Left Mark)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 3 NG (Not Found Left Mark)")
                            Return
                        End If
                    End If

                    If ((Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) AndAlso _
                        ((ORightResult.BInspected = False) OrElse (ORightResult.BOK = False))) Then
                        If (Me.m_ERightRequest = EEDGE_REQUEST.FIRST) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_FIRST_RIGHT_MARK_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 1 NG (Not Found Right Mark)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 1 NG (Not Found Right Mark)")
                            Return
                        ElseIf (Me.m_ERightRequest = EEDGE_REQUEST.THIRD) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_THIRD_RIGHT_MARK_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 3 NG (Not Found Right Mark)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 3 NG (Not Found Right Mark)")
                            Return
                        End If
                    End If


                    CMotionController.It.OPLC.GetEquipInfo(Me.m_EStage, Me.m_F64EdgeMotionLeftX, Me.m_F64EdgeMotionRightX, Me.m_F64EdgeMotionY)
                    CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.OK)
                    If (Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) Then
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge " & CType(Me.m_ELeftRequest, Integer) & " OK"))
                    End If
                    If (Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) Then
                        CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge " & CType(Me.m_ERightRequest, Integer) & " OK"))
                    End If

                    If ((Me.m_ELeftRequest = EEDGE_REQUEST.FIRST) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.FIRST)) Then
                        Me.m_OEdgeTopResult = New CInspectionResult(Me.m_EStage, EEDGE_TARGET.FRONT)
                        Me.m_OEdgeTopResult.StrID = CMotionController.It.OPLC.GetProductID(Me.m_EStage)
                        Me.m_OEdgeTopResult.OLeft.F64MarkCamera = Me.m_F64EdgeMotionLeftX
                        Me.m_OEdgeTopResult.ORight.F64MarkCamera = Me.m_F64EdgeMotionRightX
                        Me.m_OEdgeTopResult.OLeft.F64CutMinLimit = Me.m_ORecipe.F64EdgeLeftTopMin
                        Me.m_OEdgeTopResult.OLeft.F64CutMaxLimit = Me.m_ORecipe.F64EdgeLeftTopMax
                        Me.m_OEdgeTopResult.ORight.F64CutMinLimit = Me.m_ORecipe.F64EdgeRightTopMin
                        Me.m_OEdgeTopResult.ORight.F64CutMaxLimit = Me.m_ORecipe.F64EdgeRightTopMax
                        Me.m_OEdgeTopResult.OLeft.OMarkInfo = OLeftResult
                        Me.m_OEdgeTopResult.ORight.OMarkInfo = ORightResult
                    ElseIf ((Me.m_ELeftRequest = EEDGE_REQUEST.THIRD) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.THIRD)) Then
                        Me.m_OEdgeBottomResult = New CInspectionResult(Me.m_EStage, EEDGE_TARGET.REAR)
                        Me.m_OEdgeBottomResult.StrID = CMotionController.It.OPLC.GetProductID(Me.m_EStage)
                        Me.m_OEdgeBottomResult.OLeft.F64MarkCamera = Me.m_F64EdgeMotionLeftX
                        Me.m_OEdgeBottomResult.ORight.F64MarkCamera = Me.m_F64EdgeMotionRightX
                        Me.m_OEdgeBottomResult.OLeft.F64CutMinLimit = Me.m_ORecipe.F64EdgeLeftBottomMax
                        Me.m_OEdgeBottomResult.OLeft.F64CutMaxLimit = Me.m_ORecipe.F64EdgeLeftBottomMax
                        Me.m_OEdgeBottomResult.ORight.F64CutMinLimit = Me.m_ORecipe.F64EdgeRightBottomMin
                        Me.m_OEdgeBottomResult.ORight.F64CutMaxLimit = Me.m_ORecipe.F64EdgeRightBottomMax
                        Me.m_OEdgeBottomResult.OLeft.OMarkInfo = OLeftResult
                        Me.m_OEdgeBottomResult.ORight.OMarkInfo = ORightResult
                    End If
                End If
            ElseIf (((Me.m_ELeftRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ELeftRequest = EEDGE_REQUEST.FOURTH)) OrElse _
                    ((Me.m_ERightRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.FOURTH))) Then


                Dim OLeftResult As CEdgeResult = Me.m_OLeft.GetEdgeResult()
                Dim ORightResult As CEdgeResult = Me.m_ORight.GetEdgeResult()

                If (((Me.m_ELeftRequest = EEDGE_REQUEST.NONE) OrElse (Not OLeftResult Is Nothing)) AndAlso _
                    ((Me.m_ERightRequest = EEDGE_REQUEST.NONE) OrElse (Not ORightResult Is Nothing))) Then
                    Me.m_BRunEdge = False

                    If ((Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso _
                        ((OLeftResult.BInspected = False) OrElse (OLeftResult.BOK = False))) Then
                        If (Me.m_ELeftRequest = EEDGE_REQUEST.SECOND) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_LEFT_LINE_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Not Found Left Line)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Not Found Left Line)")
                            Return
                        ElseIf (Me.m_ELeftRequest = EEDGE_REQUEST.FOURTH) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_FOURTH_LEFT_LINE_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Not Found Left Line)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Not Found Left Line)")
                            Return
                        End If
                    End If

                    If ((Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) AndAlso _
                        ((ORightResult.BInspected = False) OrElse (ORightResult.BOK = False))) Then
                        If (Me.m_ERightRequest = EEDGE_REQUEST.SECOND) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_RIGHT_LINE_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Not Found Right Line)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Not Found Right Line)")
                            Return
                        ElseIf (Me.m_ERightRequest = EEDGE_REQUEST.FOURTH) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_FOURTH_RIGHT_LINE_UNKNOWN)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Not Found Right Line)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Not Found Right Line)")
                            Return
                        End If
                    End If


                    CMotionController.It.OPLC.GetEquipInfo(Me.m_EStage, Me.m_F64EdgeMotionLeftX, Me.m_F64EdgeMotionRightX, Me.m_F64EdgeMotionY)

                    If ((Me.m_ELeftRequest = EEDGE_REQUEST.SECOND) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.SECOND)) Then
                        Me.m_OEdgeTopResult.OLeft.F64EdgeCamera = Me.m_F64EdgeMotionLeftX
                        Me.m_OEdgeTopResult.ORight.F64EdgeCamera = Me.m_F64EdgeMotionRightX
                        Me.m_OEdgeTopResult.OLeft.OEdgeInfo = OLeftResult
                        Me.m_OEdgeTopResult.ORight.OEdgeInfo = ORightResult

                        If ((Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso ((Me.m_OEdgeTopResult Is Nothing) OrElse (Me.m_OEdgeTopResult.OLeft.OMarkInfo Is Nothing))) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_FIRST_NOTING)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Nothing 1 Left Result)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Nothing 1 Left Result)")
                            Return
                        End If
                        If ((Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) AndAlso ((Me.m_OEdgeTopResult Is Nothing) OrElse (Me.m_OEdgeTopResult.ORight.OMarkInfo Is Nothing))) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_FIRST_NOTING)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Nothing 1 Right Result)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Nothing 1 Right Result)")
                            Return
                        End If


                        If (Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) Then
                            Me.m_OEdgeTopResult.OLeft.BInspected = True
                            Me.m_OEdgeTopResult.OLeft.F64Length = _
                                (Me.m_OEdgeTopResult.OLeft.F64MarkCamera - Me.m_OEdgeTopResult.OLeft.F64EdgeCamera) + _
                                (((Me.m_OEdgeTopResult.OLeft.OMarkInfo.F64X - (Me.m_OEdgeTopResult.OLeft.OMarkInfo.OImageInfo.OImage.Width / 2D)) * CEnvironment.LEN_PER_PIXEL) + _
                                (((Me.m_OEdgeTopResult.OLeft.OEdgeInfo.OImageInfo.OImage.Width / 2D) - Me.m_OEdgeTopResult.OLeft.OEdgeInfo.F64X)) * CEnvironment.LEN_PER_PIXEL)

                            If ((Me.m_OEdgeTopResult.OLeft.F64Length < Me.m_ORecipe.F64EdgeLeftTopMin) OrElse _
                                (Me.m_OEdgeTopResult.OLeft.F64Length > Me.m_ORecipe.F64EdgeLeftTopMax)) Then
                                Me.m_OEdgeTopResult.OLeft.BOK = False
                            End If
                        End If
                        If (Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) Then
                            Me.m_OEdgeTopResult.ORight.BInspected = True
                            Me.m_OEdgeTopResult.ORight.F64Length = _
                                (Me.m_OEdgeTopResult.ORight.F64MarkCamera - Me.m_OEdgeTopResult.ORight.F64EdgeCamera) + _
                                (((Me.m_OEdgeTopResult.ORight.OMarkInfo.OImageInfo.OImage.Width / 2D) - Me.m_OEdgeTopResult.ORight.OMarkInfo.F64X) * CEnvironment.LEN_PER_PIXEL) + _
                                ((Me.m_OEdgeTopResult.ORight.OEdgeInfo.F64X - (Me.m_OEdgeTopResult.ORight.OEdgeInfo.OImageInfo.OImage.Width / 2D)) * CEnvironment.LEN_PER_PIXEL)

                            If ((Me.m_OEdgeTopResult.ORight.F64Length < Me.m_ORecipe.F64EdgeRightTopMin) OrElse _
                                (Me.m_OEdgeTopResult.ORight.F64Length > Me.m_ORecipe.F64EdgeRightTopMax)) Then
                                Me.m_OEdgeTopResult.ORight.BOK = False
                            End If
                        End If


                        If (((Me.m_OEdgeTopResult.OLeft.BInspected = False) OrElse (Me.m_OEdgeTopResult.OLeft.BOK = True)) AndAlso _
                            ((Me.m_OEdgeTopResult.ORight.BInspected = False) OrElse (Me.m_OEdgeTopResult.ORight.BOK = True))) Then
                            'OK
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.OK)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 OK"))
                        Else
                            If ((Me.m_OEdgeTopResult.OLeft.BInspected = True) AndAlso (Me.m_OEdgeTopResult.OLeft.BOK = False)) Then
                                'NG
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_LEFT_RANGE_OVER)
                                CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Left Over Range)"))
                                Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Left Over Range)")
                            ElseIf ((Me.m_OEdgeTopResult.OLeft.BInspected = True) AndAlso (Me.m_OEdgeTopResult.OLeft.BOK = False)) Then
                                'NG
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_RIGHT_RANGE_OVER)
                                CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Right Over Range)"))
                                Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 2 NG (Right Over Range)")
                            End If
                        End If

                        Me.SendEdgeToFile(Me.m_OEdgeTopResult)
                        Me.OnEdgeRan(Me.m_OEdgeTopResult)
                        Me.m_OEdgeTopResult = Nothing
                    ElseIf ((Me.m_ELeftRequest = EEDGE_REQUEST.FOURTH) OrElse (Me.m_ERightRequest = EEDGE_REQUEST.FOURTH)) Then
                        Me.m_OEdgeBottomResult.OLeft.F64EdgeCamera = Me.m_F64EdgeMotionLeftX
                        Me.m_OEdgeBottomResult.ORight.F64EdgeCamera = Me.m_F64EdgeMotionRightX
                        Me.m_OEdgeBottomResult.OLeft.OEdgeInfo = OLeftResult
                        Me.m_OEdgeBottomResult.ORight.OEdgeInfo = ORightResult

                        If ((Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) AndAlso ((Me.m_OEdgeBottomResult Is Nothing) OrElse (Me.m_OEdgeBottomResult.OLeft.OMarkInfo Is Nothing))) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_FOURTH_THIRD_NOTHING)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Nothing 3 Left Result)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Nothing 3 Left Result)")
                            Return
                        End If
                        If ((Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) AndAlso ((Me.m_OEdgeBottomResult Is Nothing) OrElse (Me.m_OEdgeBottomResult.ORight.OMarkInfo Is Nothing))) Then
                            CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_FOURTH_THIRD_NOTHING)
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Nothing 3 Right Result)"))
                            Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Nothing 3 Right Result)")
                            Return
                        End If


                        If (Not Me.m_ELeftRequest = EEDGE_REQUEST.NONE) Then
                            Me.m_OEdgeBottomResult.OLeft.BInspected = True
                            Me.m_OEdgeBottomResult.OLeft.F64Length = _
                                (Me.m_OEdgeBottomResult.OLeft.F64MarkCamera - Me.m_OEdgeBottomResult.OLeft.F64EdgeCamera) + _
                                (((Me.m_OEdgeBottomResult.OLeft.OMarkInfo.F64X - (Me.m_OEdgeBottomResult.OLeft.OMarkInfo.OImageInfo.OImage.Width / 2D)) * CEnvironment.LEN_PER_PIXEL) + _
                                (((Me.m_OEdgeBottomResult.OLeft.OEdgeInfo.OImageInfo.OImage.Width / 2D) - Me.m_OEdgeBottomResult.OLeft.OEdgeInfo.F64X)) * CEnvironment.LEN_PER_PIXEL)

                            If ((Me.m_OEdgeBottomResult.OLeft.F64Length < Me.m_ORecipe.F64EdgeLeftBottomMin) OrElse _
                                (Me.m_OEdgeBottomResult.OLeft.F64Length > Me.m_ORecipe.F64EdgeLeftBottomMax)) Then
                                Me.m_OEdgeBottomResult.OLeft.BOK = False
                            End If
                        End If
                        If (Not Me.m_ERightRequest = EEDGE_REQUEST.NONE) Then
                            Me.m_OEdgeBottomResult.ORight.BInspected = True
                            Me.m_OEdgeBottomResult.ORight.F64Length = _
                                (Me.m_OEdgeBottomResult.ORight.F64MarkCamera - Me.m_OEdgeBottomResult.ORight.F64EdgeCamera) + _
                                (((Me.m_OEdgeBottomResult.ORight.OMarkInfo.OImageInfo.OImage.Width / 2D) - Me.m_OEdgeBottomResult.ORight.OMarkInfo.F64X) * CEnvironment.LEN_PER_PIXEL) + _
                                ((Me.m_OEdgeBottomResult.ORight.OEdgeInfo.F64X - (Me.m_OEdgeBottomResult.ORight.OEdgeInfo.OImageInfo.OImage.Width / 2D)) * CEnvironment.LEN_PER_PIXEL)

                            If ((Me.m_OEdgeBottomResult.ORight.F64Length < Me.m_ORecipe.F64EdgeRightBottomMin) OrElse _
                                (Me.m_OEdgeBottomResult.ORight.F64Length > Me.m_ORecipe.F64EdgeRightBottomMax)) Then
                                Me.m_OEdgeBottomResult.ORight.BOK = False
                            End If
                        End If


                        If (((Me.m_OEdgeBottomResult.OLeft.BInspected = False) OrElse (Me.m_OEdgeBottomResult.OLeft.BOK = True)) AndAlso _
                            ((Me.m_OEdgeBottomResult.ORight.BInspected = False) OrElse (Me.m_OEdgeBottomResult.ORight.BOK = True))) Then
                            'OK
                            CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.OK)
                            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 OK"))
                        Else
                            If ((Me.m_OEdgeBottomResult.OLeft.BInspected = True) AndAlso (Me.m_OEdgeBottomResult.OLeft.BOK = False)) Then
                                'NG
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_LEFT_RANGE_OVER)
                                CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Left Over Range)"))
                                Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Left Over Range)")
                            ElseIf ((Me.m_OEdgeBottomResult.OLeft.BInspected = True) AndAlso (Me.m_OEdgeBottomResult.OLeft.BOK = False)) Then
                                'NG
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.EDGE_SECOND_RIGHT_RANGE_OVER)
                                CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
                                CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Right Over Range)"))
                                Me.OnOpenMessageBox("ST#" & CType(Me.m_EStage, Integer) & " : Edge 4 NG (Right Over Range)")
                            End If
                        End If

                        Me.SendEdgeToFile(Me.m_OEdgeBottomResult)
                        Me.OnEdgeRan(Me.m_OEdgeBottomResult)
                        Me.m_OEdgeBottomResult = Nothing
                    End If
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub SendEdgeToFile(ByVal OResult As CInspectionResult)
        Try
            Dim OTime As DateTime = DateTime.Now

            If (OResult.OLeft.BInspected = True) Then
                Dim OMarkFile As CImageSaveFile = New CImageSaveFile(OTime, OResult.OLeft.OMarkInfo.OImageInfo.OImage.ToBitmap())
                OMarkFile.StrDirectory = ".\Image\" & CType(Me.m_EStage, Integer) & "\Edge\{0:yyyy}\{0:MM}\{0:dd}\{0:HH.mm.ss fff}"
                OMarkFile.StrFile = "Left_Mark.jpg"
                OMarkFile.OFormat = ImageFormat.Jpeg
                CImageSaveTool.It.Set(OMarkFile)

                Dim OEdgeFile As CImageSaveFile = New CImageSaveFile(OTime, OResult.OLeft.OEdgeInfo.OImageInfo.OImage.ToBitmap())
                OEdgeFile.StrDirectory = ".\Image\" & CType(Me.m_EStage, Integer) & "\Edge\{0:yyyy}\{0:MM}\{0:dd}\{0:HH.mm.ss fff}"
                OEdgeFile.StrFile = "Left_Edge.jpg"
                OEdgeFile.OFormat = ImageFormat.Jpeg
                CImageSaveTool.It.Set(OEdgeFile)
            End If
            If (OResult.ORight.BInspected = True) Then
                Dim OMarkFile As CImageSaveFile = New CImageSaveFile(OTime, OResult.ORight.OMarkInfo.OImageInfo.OImage.ToBitmap())
                OMarkFile.StrDirectory = ".\Image\" & CType(Me.m_EStage, Integer) & "\Edge\{0:yyyy}\{0:MM}\{0:dd}\{0:HH.mm.ss fff}"
                OMarkFile.StrFile = "Right_Mark.jpg"
                OMarkFile.OFormat = ImageFormat.Jpeg
                CImageSaveTool.It.Set(OMarkFile)

                Dim OEdgeFile As CImageSaveFile = New CImageSaveFile(OTime, OResult.ORight.OEdgeInfo.OImageInfo.OImage.ToBitmap())
                OEdgeFile.StrDirectory = ".\Image\" & CType(Me.m_EStage, Integer) & "\Edge\{0:yyyy}\{0:MM}\{0:dd}\{0:HH.mm.ss fff}"
                OEdgeFile.StrFile = "Right_Edge.jpg"
                OEdgeFile.OFormat = ImageFormat.Jpeg
                CImageSaveTool.It.Set(OEdgeFile)
            End If

            CExcelManager.It.Write(Me.m_ORecipe.StrName, OResult)


            'Dim OTable As IDynamicTable = CDB.It.GetDynamicTable(CDB.TABLE_EDGE)

            'Try
            '    OTable.BeginSyncData()

            '    Dim I32RowIndex As Integer = OTable.InsertRow()
            '    OTable.Update(I32RowIndex, CDB.EDGE_DATETIME, OTime.ToString("yyyy.MM.dd HH:mm:ss fff"))
            '    OTable.Update(I32RowIndex, CDB.EDGE_STAGE, CType(Me.m_EStage, Integer).ToString())
            '    OTable.Update(I32RowIndex, CDB.EDGE_ITEM, OResult.ETarget.ToString())
            '    If (OResult.OLeft.BInspected = True) Then
            '        OTable.Update(I32RowIndex, CDB.EDGE_LEFT_LEN, Math.Round(OResult.OLeft.F64Length, 3))
            '        OTable.Update(I32RowIndex, CDB.EDGE_LEFT_RESULT, OResult.OLeft.BOK)
            '    End If
            '    If (OResult.ORight.BInspected = True) Then
            '        OTable.Update(I32RowIndex, CDB.EDGE_RIGHT_LEN, Math.Round(OResult.ORight.F64Length, 3))
            '        OTable.Update(I32RowIndex, CDB.EDGE_RIGHT_RESULT, OResult.ORight.BOK)
            '    End If
            'Catch ex As Exception
            '    CError.Throw(ex)
            'Finally
            '    OTable.EndSyncData()
            'End Try
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub



    Public Sub EndInspection()
        Try
            Monitor.Enter(Me.m_OInterrupt)
            ' for busy signal off 20190409
            If (Me.m_BRunAlignment_A = True AndAlso Me.m_EStage = ESTAGE.A) OrElse
               (Me.m_BRunAlignment_B = True AndAlso Me.m_EStage = ESTAGE.B) Then
                CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.LEFT)
                CMotionController.It.OPCI.SendAlignmentResult(Me.m_EStage, ERESULT.NG, EVIEW.RIGHT)
            End If

            If Me.m_BRunEdge = True Then
                CMotionController.It.OPCI.SendEdgeResult(Me.m_EStage, ERESULT.NG)
            End If

            ' inspection Terminate
            Me.m_BRunEdge = False
            If (Me.m_EStage = ESTAGE.A) Then
                Me.m_BRunAlignment_A = False
            Else

                Me.m_BRunAlignment_B = False
            End If
            Me.m_EAnalysis = EAnalysis.NONE

            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : End Inspection"))

            'While (True)
            '    Try
            '        ' jht 검사 정지 시 동기화 락 문제 있음
            '        Monitor.Enter(Me.m_OInterrupt)

            '        If ((Me.m_BRunAlignment = False) AndAlso (Me.m_BRunEdge = False)) Then
            '            Me.m_BRunEdge = False
            '            Me.m_BRunAlignment = False
            '            Me.m_EAnalysis = EAnalysis.NONE
            '            CLogTool.It.SetLog(New CLog("ST#" & CType(Me.m_EStage, Integer) & " : End Inspection"))
            '            Exit While
            '        End If
            '    Catch ex As Exception
            '        CError.Throw(ex)
            '    Finally
            '        Monitor.Exit(Me.m_OInterrupt)
            '    End Try

            '    Thread.Sleep(10)
            'End While

        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Function IsBusy() As Boolean
        Dim BResult As Boolean = True

        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (Me.m_EAnalysis = EAnalysis.INSPECTION) Then
                If (((Me.m_BRunAlignment_A = False AndAlso Me.m_EStage = ESTAGE.A) OrElse
                (Me.m_BRunAlignment_B = False AndAlso Me.m_EStage = ESTAGE.B)) _
                    AndAlso (Me.m_BRunEdge = False)) Then
                    BResult = False
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return BResult
    End Function


    Public Sub BeginSync()
        Try
            Monitor.Enter(Me.m_OInterrupt)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub EndSync()
        Try
            Monitor.Exit(Me.m_OInterrupt)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnCalibrationStart()
        Try
            If Not Me.m_OCalibrationStart Is Nothing Then
                Me.m_OCalibrationStart()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnPartialCalibrationRan(ByVal OResult As CMarkResult, ByVal I32Left0Right1 As Integer)
        Try
            If Not Me.m_OPartialCalibrationRan Is Nothing Then
                Me.m_OPartialCalibrationRan(OResult, I32Left0Right1)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub OnGraphicClear()
        Try
            If Not Me.m_OGraphicClear Is Nothing Then
                Me.m_OGraphicClear()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnCalibrationRan(ByVal OLeftResult As CMarkResult, ByVal ORightResult As CMarkResult)
        Try
            If Not Me.m_OCalibrationRan Is Nothing Then
                Me.m_OCalibrationRan(OLeftResult, ORightResult)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnCalibrationFinish(ByVal BIsSuccess As Boolean, ByVal StrMessage As String)
        Try
            If Not Me.m_OCalibrationFinish Is Nothing Then
                Me.m_OCalibrationFinish(BIsSuccess, StrMessage)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnAlignmentRan(ByVal OResult As CAlignmentResult)
        Try
            If Not Me.m_OAlignmentRan Is Nothing Then
                Me.m_OAlignmentRan(OResult)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub OnDisplayPartial(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
        Try
            If Not Me.m_ODisplayPartial Is Nothing Then
                Me.m_ODisplayPartial(OResult, I32Side, I32LogicalSide)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub OnDisplayPartialData(ByVal OResult As CAlignmentResult, ByVal I32Side As Integer, ByVal I32LogicalSide As Integer)
        Try
            If Not Me.m_ODisplayPartialData Is Nothing Then
                Me.m_ODisplayPartialData(OResult, I32Side, I32LogicalSide)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnEdgeRan(ByVal OResult As CInspectionResult)
        Try
            If Not Me.m_OEdgeRan Is Nothing Then
                Me.m_OEdgeRan(OResult)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnOpenMessageBox(ByVal StrMessage As String)
        Try
            If (Not Me.m_OOpenMessageBox Is Nothing) Then
                Me.m_OOpenMessageBox(StrMessage)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            Me.EndWork()

            If Not Me.m_OLeft Is Nothing Then
                Me.m_OLeft.Dispose()
                Me.m_OLeft = Nothing
            End If

            If Not Me.m_ORight Is Nothing Then
                Me.m_ORight.Dispose()
                Me.m_ORight = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "DECLARE FUNCTION"
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal StrAppName As String, ByVal StrKeyName As String, ByVal StrDefault As String, ByVal OValue As StringBuilder, ByVal I32Size As Integer, ByVal StrFile As String) As Boolean
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal StrAppName As String, ByVal StrKeyName As String, ByVal StrValue As String, ByVal StrFile As String) As Boolean
#End Region


#Region "ENUM"
    Private Enum EAnalysis As Byte
        NONE = 0
        CALIBRATION
        INSPECTION
    End Enum
#End Region

End Class


#Region "ENUM"
Public Enum EVIEW As Byte
    NONE = 0
    LEFT
    RIGHT
End Enum


Public Enum EEDGE_REQUEST As Byte
    NONE = 0
    FIRST
    SECOND
    THIRD
    FOURTH
End Enum


Public Enum EEDGE_TARGET As Byte
    NONE = 0
    FRONT
    REAR
End Enum


Public Enum EERROR As Byte
    NONE = 0
    CALIBRATION_NOT_READY = 1
    CALIBRATION_LEFT_UNKNOWN = 2
    CALIBRATION_RIGHT_UNKNOWN = 3
    CALIBRATION_MOTION_TIME_OUT = 4

    ALIGNMENT_NOT_READY = 11
    ALIGNMENT_CALIBRATION_ERROR = 12
    ALIGNMENT_LEFT_UNKNOWN = 13
    ALIGNMENT_RIGHT_UNKNOWN = 14
    ALIGNMENT_LEFT_ROI_OVER = 15
    ALIGNMENT_RIGHT_ROI_OVER = 16

    EDGE_NOT_READY = 21
    EDGE_NO_REQUEST = 22
    EDGE_DIFFER_REQUEST = 23
    EDGE_FIRST_LEFT_MARK_UNKNOWN = 24
    EDGE_FIRST_RIGHT_MARK_UNKNOWN = 25

    EDGE_SECOND_FIRST_NOTING = 26
    EDGE_SECOND_LEFT_LINE_UNKNOWN = 27
    EDGE_SECOND_RIGHT_LINE_UNKNOWN = 28
    EDGE_SECOND_LEFT_RANGE_OVER = 29
    EDGE_SECOND_RIGHT_RANGE_OVER = 30

    EDGE_THIRD_LEFT_MARK_UNKNOWN = 31
    EDGE_THIRD_RIGHT_MARK_UNKNOWN = 32
    EDGE_FOURTH_THIRD_NOTHING = 33
    EDGE_FOURTH_LEFT_LINE_UNKNOWN = 34
    EDGE_FOURTH_RIGHT_LINE_UNKNOWN = 35

    EDGE_FOURTH_LEFT_RANGE_OVER = 36
    EDGE_FOURTH_RIGHT_RANGE_OVER = 37

    MAX_RETRY_REACHED = 38
End Enum
#End Region