Imports System.Threading
Imports ACTMULTILib
Imports Jhjo.Common
Imports System.Text


Public Class CPLC
    Implements IDisposable

#Region "VARIABLE"
    Private m_ODevice As ActEasyIF = Nothing
    Private m_BConnected As Boolean = False
    Private m_OInterrupt As Object = Nothing

    Private m_OWorker As Thread = Nothing
    Private m_BDoWork As Boolean = False

    Private m_I32RecipeID As Integer = 0
    Private m_I32StageABeginCalibration As Integer = 0
    Private m_I32StageAStartMovement As Integer = 0
    Private m_I32StageAFinishMovement As Integer = 0
    Private m_I32StageALeftStartCalcDegree As Integer = 0
    Private m_I32StageARightStartCalcDegree As Integer = 0
    Private m_I32StageBBeginCalibration As Integer = 0
    Private m_I32StageBStartMovement As Integer = 0
    Private m_I32StageBFinishMovement As Integer = 0
    Private m_I32StageBLeftStartCalcDegree As Integer = 0
    Private m_I32StageBRightStartCalcDegree As Integer = 0

    Private m_I32BeforeRecipeID As Integer = 0
    Private m_I32BeforeStageABeginCalibration As Integer = 0
    Private m_I32BeforeStageAStartMovement As Integer = 0
    Private m_I32BeforeStageAFinishMovement As Integer = 0
    Private m_I32BeforeStageALeftStartCalcDegree As Integer = 0
    Private m_I32BeforeStageARightStartCalcDegree As Integer = 0
    Private m_I32BeforeStageBBeginCalibration As Integer = 0
    Private m_I32BeforeStageBStartMovement As Integer = 0
    Private m_I32BeforeStageBFinishMovement As Integer = 0
    Private m_I32BeforeStageBLeftStartCalcDegree As Integer = 0
    Private m_I32BeforeStageBRightStartCalcDegree As Integer = 0

    '20170822
    Private m_I32OverSize_A As Integer = 0
    Private m_I32OverSize_B As Integer = 0
    Private m_I32StageShiftforOversized As Integer = 0

    Private m_F64StageALeftWheel As Double = 0
    Private m_F64StageARightWheel As Double = 0
    Private m_F64StageBLeftWheel As Double = 0
    Private m_F64StageBRightWheel As Double = 0
    Private m_F64CurrentStageALeftWheel As Double = 0
    Private m_F64CurrentStageARightWheel As Double = 0
    Private m_F64CurrentStageBLeftWheel As Double = 0
    Private m_F64CurrentStageBRightWheel As Double = 0

    Private m_F64TopHorizontalOnCalcDegree As Double = 0
    Private m_F64BottomHorizontalOnCalcDegree As Double = 0
    Private m_F64VerticalOnCalcDegree As Double = 0

    Private m_ORecipeRequested As RecipeRequestedHandler = Nothing
    Private m_OStageABeginCalibration As BeginCalibrationHandler = Nothing
    Private m_OStageAEndMovement As EndMovementHandler = Nothing
    Private m_OStageACalcDegree As CalcDegreeRequestedHandler = Nothing
    Private m_OStageBBeginCalibration As BeginCalibrationHandler = Nothing
    Private m_OStageBEndMovement As EndMovementHandler = Nothing
    Private m_OStageBCalcDegree As CalcDegreeRequestedHandler = Nothing
    Private m_OWheelPositionChanged As WheelPositionChangedHandler = Nothing
#End Region


#Region "DELEGATE & EVENT"
    Public Delegate Sub RecipeRequestedHandler(ByVal I32ID As Integer)
    Public Delegate Sub BeginCalibrationHandler()
    Public Delegate Sub EndMovementHandler()
    Public Delegate Sub WheelPositionChangedHandler(ByVal F64StageALeftWheel As Double, ByVal F64StageARightWheel As Double, ByVal F64StageBLeftWheel As Double, ByVal F64StageBRightWheel As Double)
    Public Delegate Sub CalcDegreeRequestedHandler(ByVal EView As EVIEW, ByVal F64TopHorizontal As Double, ByVal F64BottomHorizontal As Double, ByVal F64Vertical As Double)
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property ODevice() As ActEasyIF
        Get
            Return Me.m_ODevice
        End Get
    End Property


    Public ReadOnly Property BConnected() As Boolean
        Get
            Return Me.m_BConnected
        End Get
    End Property


    Public ReadOnly Property F64StageALeftWheel() As Double
        Get
            Return Me.m_F64StageALeftWheel
        End Get
    End Property


    Public ReadOnly Property F64StageARightWheel() As Double
        Get
            Return Me.m_F64StageARightWheel
        End Get
    End Property


    Public ReadOnly Property F64StageBLeftWheel() As Double
        Get
            Return Me.m_F64StageBLeftWheel
        End Get
    End Property


    Public ReadOnly Property F64StageBRightWheel() As Double
        Get
            Return Me.m_F64StageBRightWheel
        End Get
    End Property


    Public WriteOnly Property ORecipeChanged() As RecipeRequestedHandler
        Set(ByVal value As RecipeRequestedHandler)
            Me.m_ORecipeRequested = value
        End Set
    End Property


    Public WriteOnly Property OStageABeginCalibration() As BeginCalibrationHandler
        Set(ByVal value As BeginCalibrationHandler)
            Me.m_OStageABeginCalibration = value
        End Set
    End Property


    Public WriteOnly Property OStageAEndMovement() As EndMovementHandler
        Set(ByVal value As EndMovementHandler)
            Me.m_OStageAEndMovement = value
        End Set
    End Property


    Public WriteOnly Property OStageACalcDegree() As CalcDegreeRequestedHandler
        Set(ByVal value As CalcDegreeRequestedHandler)
            Me.m_OStageACalcDegree = value
        End Set
    End Property


    Public WriteOnly Property OStageBBeginCalibration() As BeginCalibrationHandler
        Set(ByVal value As BeginCalibrationHandler)
            Me.m_OStageBBeginCalibration = value
        End Set
    End Property


    Public WriteOnly Property OStageBEndMovement() As EndMovementHandler
        Set(ByVal value As EndMovementHandler)
            Me.m_OStageBEndMovement = value
        End Set
    End Property


    Public WriteOnly Property OStageBCalcDegree() As CalcDegreeRequestedHandler
        Set(ByVal value As CalcDegreeRequestedHandler)
            Me.m_OStageBCalcDegree = value
        End Set
    End Property


    Public WriteOnly Property OWheelPositionChanged() As WheelPositionChangedHandler
        Set(ByVal value As WheelPositionChangedHandler)
            Me.m_OWheelPositionChanged = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        Try
            Me.m_ODevice = New ActEasyIF()
            Me.m_ODevice.ActLogicalStationNumber = 0
            Me.m_OInterrupt = New Object()

            If (Me.m_ODevice.Open() = 0) Then
                Me.m_BConnected = True
                Me.Initialize()

                Me.GetWheelPosition(Me.m_F64CurrentStageALeftWheel, Me.m_F64CurrentStageARightWheel, Me.m_F64CurrentStageBLeftWheel, Me.m_F64CurrentStageBRightWheel)
                Me.m_F64StageALeftWheel = Me.m_F64CurrentStageALeftWheel
                Me.m_F64StageARightWheel = Me.m_F64CurrentStageARightWheel
                Me.m_F64StageBLeftWheel = Me.m_F64CurrentStageBLeftWheel
                Me.m_F64StageBRightWheel = Me.m_F64CurrentStageBRightWheel

                Me.BeginWork()
            Else
                CMsgBox.Error("Failed to connect PLC!")
            End If
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


#Region "FUNCTION"
    Public Sub Initialize()
        Try
            Me.m_ODevice.WriteDeviceBlock("D6116", 1, 0) '1번 스테이지 IsStartMovement
            Me.m_ODevice.WriteDeviceBlock("D6167", 1, 0) '1번 스테이지 EndMovement
            Me.m_ODevice.WriteDeviceBlock("D6165", 1, 0) '1번 스테이지 캘리브레이션 시작
            Me.m_ODevice.WriteDeviceBlock("D6166", 1, 0) '1번 스테이지 캘리브레이션 스탭 이동 시 신호줌
            Me.m_ODevice.WriteDeviceBlock("D6168", 1, 0) '1번 스테이지 캘리브레이션 성공여부 보내줌 (1 = 성공, 2 = 실패)
            Me.m_ODevice.WriteDeviceBlock("D6115", 1, 0) '1번 스테이지 캘리브레이션 시작 유무 확인
            Me.m_ODevice.WriteDeviceBlock("D6125", 1, 0) '1번 스테이지 SHIFT 조작(0: 초기상태, 1:SHIFT 상태)
            Me.m_ODevice.WriteDeviceBlock("D6127", 1, 0) '1번 스테이지 SHIFT 초기화

            Me.m_ODevice.WriteDeviceBlock("D6131", 1, 0) '2번 스테이지 IsStartMovement
            Me.m_ODevice.WriteDeviceBlock("D6182", 1, 0) '2번 스테이지 EndMovement
            Me.m_ODevice.WriteDeviceBlock("D6180", 1, 0) '2번 스테이지 캘리브레이션 시작
            Me.m_ODevice.WriteDeviceBlock("D6181", 1, 0) '2번 스테이지 캘리브레이션 스탭 이동 시 신호줌
            Me.m_ODevice.WriteDeviceBlock("D6183", 1, 0) '2번 스테이지 캘리브레이션 성공여부 보내줌 (1 = 성공, 2 = 실패)
            Me.m_ODevice.WriteDeviceBlock("D6130", 1, 0) '2번 스테이지 캘리브레이션 시작 유무 확인
            Me.m_ODevice.WriteDeviceBlock("D6126", 1, 0) '2번 스테이지 SHIFT 조작(0: 초기상태, 1:SHIFT 상태)
            Me.m_ODevice.WriteDeviceBlock("D6128", 1, 0) '2번 스테이지 SHIFT 초기화
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Initialize(ByVal EStage As ESTAGE)
        Try
            If (EStage = ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6116", 1, 0) '1번 스테이지 IsStartMovement
                Me.m_ODevice.WriteDeviceBlock("D6167", 1, 0) '1번 스테이지 EndMovement
                Me.m_ODevice.WriteDeviceBlock("D6165", 1, 0) '1번 스테이지 캘리브레이션 시작
                Me.m_ODevice.WriteDeviceBlock("D6166", 1, 0) '1번 스테이지 캘리브레이션 스탭 이동 시 신호줌
                Me.m_ODevice.WriteDeviceBlock("D6168", 1, 0) '1번 스테이지 캘리브레이션 성공여부 보내줌 (1 = 성공, 2 = 실패)
                Me.m_ODevice.WriteDeviceBlock("D6115", 1, 0) '1번 스테이지 캘리브레이션 시작 유무 확인
                Me.m_ODevice.WriteDeviceBlock("D6125", 1, 0) '1번 스테이지 SHIFT 조작(0: 초기상태, 1:SHIFT 상태)
                Me.m_ODevice.WriteDeviceBlock("D6127", 1, 0) '1번 스테이지 SHIFT 초기화
            Else
                Me.m_ODevice.WriteDeviceBlock("D6131", 1, 0) '2번 스테이지 IsStartMovement
                Me.m_ODevice.WriteDeviceBlock("D6182", 1, 0) '2번 스테이지 EndMovement
                Me.m_ODevice.WriteDeviceBlock("D6180", 1, 0) '2번 스테이지 캘리브레이션 시작
                Me.m_ODevice.WriteDeviceBlock("D6181", 1, 0) '2번 스테이지 캘리브레이션 스탭 이동 시 신호줌
                Me.m_ODevice.WriteDeviceBlock("D6183", 1, 0) '2번 스테이지 캘리브레이션 성공여부 보내줌 (1 = 성공, 2 = 실패)
                Me.m_ODevice.WriteDeviceBlock("D6130", 1, 0) '2번 스테이지 캘리브레이션 시작 유무 확인
                Me.m_ODevice.WriteDeviceBlock("D6126", 1, 0) '2번 스테이지 SHIFT 조작(0: 초기상태, 1:SHIFT 상태)
                Me.m_ODevice.WriteDeviceBlock("D6128", 1, 0) '2번 스테이지 SHIFT 초기화
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub BeginWork()
        Try
            If (Me.m_OWorker Is Nothing) Then
                Me.m_BDoWork = True

                Me.m_OWorker = New Thread(AddressOf Me.Work)
                Me.m_OWorker.IsBackground = True
                Me.m_OWorker.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub Work()
        Try
            While (Me.m_BDoWork = True)
                Try
                    Me.ReadRequest()
                Catch ex As Exception
                    CError.Ignore(ex)
                End Try

                Thread.Sleep(200)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub


    Private Sub EndWork()
        Try
            If (Not Me.m_OWorker Is Nothing) Then
                Me.m_BDoWork = False

                Me.m_OWorker.Join()
                Me.m_OWorker = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub ReadRequest()
        Try
            'Recipe(Changed)
            Me.m_I32RecipeID = Me.GetMotionRecipeID()
            If (Not Me.m_I32RecipeID = Me.m_I32BeforeRecipeID) Then
                Me.m_I32BeforeRecipeID = Me.m_I32RecipeID
                Me.OnRecipeRequested(Me.m_I32RecipeID)
            End If

            'Stage A Request Calibration
            Me.m_I32StageABeginCalibration = Me.IsBeginCalibration(ESTAGE.A)
            If (Not Me.m_I32StageABeginCalibration = Me.m_I32BeforeStageABeginCalibration) Then
                Me.m_I32BeforeStageABeginCalibration = Me.m_I32StageABeginCalibration

                If (Me.m_I32StageABeginCalibration = 1) Then
                    Me.OnStageABeginCalibration()
                ElseIf (Me.m_I32StageABeginCalibration = 0) Then
                    Me.EndCalibration(ESTAGE.A)
                End If
            End If

            'Stage A Start Movement
            Me.m_I32StageAStartMovement = Me.IsStartMovement(ESTAGE.A)
            If (Not Me.m_I32StageAStartMovement = Me.m_I32BeforeStageAStartMovement) Then
                Me.m_I32BeforeStageAStartMovement = Me.m_I32StageAStartMovement

                If (Me.m_I32StageAStartMovement = 1) Then
                    Me.InitBeginMovement(ESTAGE.A)
                End If
            End If

            'Stage A Finish Movement
            Me.m_I32StageAFinishMovement = Me.IsFinishMovement(ESTAGE.A)
            If (Not Me.m_I32StageAFinishMovement = Me.m_I32BeforeStageAFinishMovement) Then
                Me.m_I32BeforeStageAFinishMovement = Me.m_I32StageAFinishMovement

                If (Me.m_I32StageAFinishMovement = 1) Then
                    Me.EndMovement(ESTAGE.A, 1)
                ElseIf (Me.m_I32StageAFinishMovement = 0) Then
                    Me.EndMovement(ESTAGE.A, 0)
                    Me.OnStageAEndMovement()
                End If
            End If


            'Stage A Calc Degree
            Me.m_I32StageALeftStartCalcDegree = Me.GetCalcDegreeRequest(ESTAGE.A, EVIEW.LEFT)
            If (Not Me.m_I32StageALeftStartCalcDegree = Me.m_I32BeforeStageALeftStartCalcDegree) Then
                Me.m_I32BeforeStageALeftStartCalcDegree = Me.m_I32StageALeftStartCalcDegree

                If (Me.m_I32StageALeftStartCalcDegree = 1) Then
                    Me.GetCalcDegreeCondition _
                    ( _
                        ESTAGE.A, EVIEW.LEFT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                    Me.OnStageACalcDegree _
                    ( _
                        EVIEW.LEFT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                ElseIf (Me.m_I32StageALeftStartCalcDegree = 0) Then
                    Me.InitCalcDegree(ESTAGE.A, EVIEW.LEFT)
                End If
            End If


            Me.m_I32StageARightStartCalcDegree = Me.GetCalcDegreeRequest(ESTAGE.A, EVIEW.RIGHT)
            If (Not Me.m_I32StageARightStartCalcDegree = Me.m_I32BeforeStageARightStartCalcDegree) Then
                Me.m_I32BeforeStageARightStartCalcDegree = Me.m_I32StageARightStartCalcDegree

                If (Me.m_I32StageARightStartCalcDegree = 1) Then
                    Me.GetCalcDegreeCondition _
                    ( _
                        ESTAGE.A, EVIEW.RIGHT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                    Me.OnStageACalcDegree _
                    ( _
                        EVIEW.RIGHT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                ElseIf (Me.m_I32StageARightStartCalcDegree = 0) Then
                    Me.InitCalcDegree(ESTAGE.A, EVIEW.RIGHT)
                End If
            End If




            'Stage B Request Calibration
            Me.m_I32StageBBeginCalibration = Me.IsBeginCalibration(ESTAGE.B)
            If Not (Me.m_I32StageBBeginCalibration = Me.m_I32BeforeStageBBeginCalibration) Then
                Me.m_I32BeforeStageBBeginCalibration = Me.m_I32StageBBeginCalibration

                If (Me.m_I32StageBBeginCalibration = 1) Then
                    Me.OnStageBBeginCalibration()
                ElseIf (Me.m_I32StageBBeginCalibration = 0) Then
                    Me.EndCalibration(ESTAGE.B)
                End If
            End If

            'Stage B Begin Movement
            Me.m_I32StageBStartMovement = Me.IsStartMovement(ESTAGE.B)
            If (Not Me.m_I32StageBStartMovement = Me.m_I32BeforeStageBStartMovement) Then
                Me.m_I32BeforeStageBStartMovement = Me.m_I32StageBStartMovement

                If (Me.m_I32StageBStartMovement = 1) Then
                    Me.InitBeginMovement(ESTAGE.B)
                End If
            End If

            'Stage B End Movement
            Me.m_I32StageBFinishMovement = Me.IsFinishMovement(ESTAGE.B)
            If (Not Me.m_I32StageBFinishMovement = Me.m_I32BeforeStageBFinishMovement) Then
                Me.m_I32BeforeStageBFinishMovement = Me.m_I32StageBFinishMovement

                If (Me.m_I32StageBFinishMovement = 1) Then
                    Me.EndMovement(ESTAGE.B, 1)
                ElseIf (Me.m_I32StageBFinishMovement = 0) Then
                    Me.EndMovement(ESTAGE.B, 0)
                    Me.OnStageBEndMovement()
                End If
            End If


            'Stage B Calc Degree
            Me.m_I32StageBLeftStartCalcDegree = Me.GetCalcDegreeRequest(ESTAGE.B, EVIEW.LEFT)
            If (Not Me.m_I32StageBLeftStartCalcDegree = Me.m_I32BeforeStageBLeftStartCalcDegree) Then
                Me.m_I32BeforeStageBLeftStartCalcDegree = Me.m_I32StageBLeftStartCalcDegree

                If (Me.m_I32StageBLeftStartCalcDegree = 1) Then
                    Me.GetCalcDegreeCondition _
                    ( _
                        ESTAGE.B, EVIEW.LEFT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                    Me.OnStageBCalcDegree _
                    ( _
                        EVIEW.LEFT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                ElseIf (Me.m_I32StageBLeftStartCalcDegree = 0) Then
                    Me.InitCalcDegree(ESTAGE.B, EVIEW.LEFT)
                End If
            End If


            Me.m_I32StageBRightStartCalcDegree = Me.GetCalcDegreeRequest(ESTAGE.B, EVIEW.RIGHT)
            If (Not Me.m_I32StageBRightStartCalcDegree = Me.m_I32BeforeStageBRightStartCalcDegree) Then
                Me.m_I32BeforeStageBRightStartCalcDegree = Me.m_I32StageBRightStartCalcDegree

                If (Me.m_I32StageBRightStartCalcDegree = 1) Then
                    Me.GetCalcDegreeCondition _
                    ( _
                        ESTAGE.B, EVIEW.RIGHT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                    Me.OnStageBCalcDegree _
                    ( _
                        EVIEW.RIGHT, _
                        Me.m_F64TopHorizontalOnCalcDegree, Me.m_F64BottomHorizontalOnCalcDegree, Me.m_F64VerticalOnCalcDegree _
                    )
                ElseIf (Me.m_I32StageBRightStartCalcDegree = 0) Then
                    Me.InitCalcDegree(ESTAGE.B, EVIEW.RIGHT)
                End If
            End If



            'Wheel Position
            Me.GetWheelPosition(Me.m_F64CurrentStageALeftWheel, Me.m_F64CurrentStageARightWheel, Me.m_F64CurrentStageBLeftWheel, Me.m_F64CurrentStageBRightWheel)
            If ((Not Me.m_F64StageALeftWheel = Me.m_F64CurrentStageALeftWheel) OrElse _
                (Not Me.m_F64StageARightWheel = Me.m_F64CurrentStageARightWheel) OrElse _
                (Not Me.m_F64StageBLeftWheel = Me.m_F64CurrentStageBLeftWheel) OrElse _
                (Not Me.m_F64StageBRightWheel = Me.m_F64CurrentStageBRightWheel)) Then
                Me.m_F64StageALeftWheel = Me.m_F64CurrentStageALeftWheel
                Me.m_F64StageARightWheel = Me.m_F64CurrentStageARightWheel
                Me.m_F64StageBLeftWheel = Me.m_F64CurrentStageBLeftWheel
                Me.m_F64StageBRightWheel = Me.m_F64CurrentStageBRightWheel

                Me.OnWheelPositionChanged(Me.m_F64StageALeftWheel, Me.m_F64StageARightWheel, Me.m_F64StageBLeftWheel, Me.m_F64StageBRightWheel)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Function IsRequestRecipe() As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.ReadDeviceBlock("D6100", 1, I32Result)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    'Public Sub ResponseRecipe(ByVal I32Value As Integer)
    '    Try
    '        Monitor.Enter(Me.m_OInterrupt)

    '        Me.m_ODevice.WriteDeviceBlock("D6150", 1, I32Value)
    '    Catch ex As Exception
    '        CError.Throw(ex)
    '    Finally
    '        Monitor.Exit(Me.m_OInterrupt)
    '    End Try
    'End Sub


    Public Function GetMotionRecipeID() As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.ReadDeviceBlock("D6101", 1, I32Result)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Public Sub Initialize_Calibration()
        Try

            Me.m_ODevice.WriteDeviceBlock("D6124", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6129", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6127", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6128", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6115", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6130", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6165", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6180", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6125", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6126", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6170", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6190", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6181", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6169", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6184", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6116", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6131", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6166", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6169", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6181", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6184", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6117", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6132", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6167", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6182", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6168", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6183", 1, 0)
            Me.m_ODevice.WriteDeviceBlock("D6165", 1, 0)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Function VectorAddition() As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.ReadDeviceBlock("D6158", 1, I32Result)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function

    Public Function GetBLeftOrRightStandard() As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.ReadDeviceBlock("D6124", 1, I32Result)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Public Function GetBOversize_A() As Integer 'check whether the product is oversized, applies for both stage A and B.
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.ReadDeviceBlock("D6137", 1, I32Result)
            Me.m_I32OverSize_A = I32Result
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Public Function GetBOversize_B() As Integer 'check whether the product is oversized, applies for both stage A and B.
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.ReadDeviceBlock("D6138", 1, I32Result)
            Me.m_I32OverSize_B = I32Result
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function

    '20170822
    Public Function IsBShifted(ByVal EStage As ESTAGE) As Integer 'check whether the stage have shifted from its original position
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock("D6127", 1, I32Result)
            Else
                Me.m_ODevice.ReadDeviceBlock("D6128", 1, I32Result)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Public Function GetProductID(ByVal EStage As ESTAGE) As String
        Dim StrResult As String = String.Empty

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim ArrI16Value As Short() = New Short(9) {}
            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock2("D6200", 10, ArrI16Value(0))
            Else
                Me.m_ODevice.ReadDeviceBlock2("D6210", 10, ArrI16Value(0))
            End If

            Dim LstArrI8Value As List(Of Byte()) = New List(Of Byte())
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(0)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(1)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(2)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(3)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(4)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(5)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(6)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(7)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(8)))
            LstArrI8Value.Add(BitConverter.GetBytes(ArrI16Value(9)))

            Dim ArrI8String As Byte() = New Byte(19) {}
            ArrI8String(0) = LstArrI8Value(0)(0)
            ArrI8String(1) = LstArrI8Value(0)(1)
            ArrI8String(2) = LstArrI8Value(1)(0)
            ArrI8String(3) = LstArrI8Value(1)(1)
            ArrI8String(4) = LstArrI8Value(2)(0)
            ArrI8String(5) = LstArrI8Value(2)(1)
            ArrI8String(6) = LstArrI8Value(3)(0)
            ArrI8String(7) = LstArrI8Value(3)(1)
            ArrI8String(8) = LstArrI8Value(4)(0)
            ArrI8String(9) = LstArrI8Value(4)(1)
            ArrI8String(10) = LstArrI8Value(5)(0)
            ArrI8String(11) = LstArrI8Value(5)(1)
            ArrI8String(12) = LstArrI8Value(6)(0)
            ArrI8String(13) = LstArrI8Value(6)(1)
            ArrI8String(14) = LstArrI8Value(7)(0)
            ArrI8String(15) = LstArrI8Value(7)(1)
            ArrI8String(16) = LstArrI8Value(8)(0)
            ArrI8String(17) = LstArrI8Value(8)(1)
            ArrI8String(18) = LstArrI8Value(9)(0)
            ArrI8String(19) = LstArrI8Value(9)(1)

            StrResult = Encoding.Default.GetString(ArrI8String)
        Catch ex As Exception
            Throw ex
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return StrResult
    End Function


    Public Sub SetVisionRecipeID(ByVal I32ID As Integer)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_ODevice.WriteDeviceBlock("D6151", 1, I32ID)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    'Public Function GetVisionRecipeID() As Integer
    '    Dim I32Result As Integer = 0

    '    Try
    '        Monitor.Enter(Me.m_OInterrupt)

    '        Me.m_ODevice.ReadDeviceBlock("D6151", 1, I32Result)
    '    Catch ex As Exception
    '        CError.Throw(ex)
    '    Finally
    '        Monitor.Exit(Me.m_OInterrupt)
    '    End Try

    '    Return I32Result
    'End Function


    Private Function IsBeginCalibration(ByVal EStage As ESTAGE) As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock("D6115", 1, I32Result)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.ReadDeviceBlock("D6130", 1, I32Result)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Public Sub StartCalibration(ByVal EStage As ESTAGE, ByVal BStart As Boolean)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                If (BStart = True) Then
                    Me.m_ODevice.WriteDeviceBlock("D6165", 1, 1)
                Else
                    Me.m_ODevice.WriteDeviceBlock("D6165", 1, 2)
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (BStart = True) Then
                    Me.m_ODevice.WriteDeviceBlock("D6180", 1, 1)
                Else
                    Me.m_ODevice.WriteDeviceBlock("D6180", 1, 2)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    '20170822
    Public Sub InitBIsShift(ByVal EStage As ESTAGE) 'when plc is done with shifting it will signal those addresses, upon receival, PC will init.
        If (EStage = DualScriber.ESTAGE.A) Then
            Me.m_ODevice.WriteDeviceBlock("D6127", 1, 0)
        ElseIf (EStage = DualScriber.ESTAGE.B) Then
            Me.m_ODevice.WriteDeviceBlock("D6128", 1, 0)
        End If
    End Sub

    Public Sub InitBShift(ByVal EStage As ESTAGE) 'when plc is done with shifting it will signal those addresses, upon receival, PC will init.
        If (EStage = DualScriber.ESTAGE.A) Then 'Delete for error 20190409
            Me.m_ODevice.WriteDeviceBlock("D6125", 1, 0)
        ElseIf (EStage = DualScriber.ESTAGE.B) Then
            Me.m_ODevice.WriteDeviceBlock("D6126", 1, 0)
        End If
    End Sub


    '20170822
    Public Sub DoBShift(ByVal EStage As ESTAGE) 'if 1, PLC executes a shift, PLC should initialize 6125 or 6126 to 0. and assign 1 to 6127 or 6128 upon completion if received PC will initialize 6127 or 6128 to 0
        If (EStage = DualScriber.ESTAGE.A) Then
            Me.m_ODevice.WriteDeviceBlock("D6125", 1, 1)
        ElseIf (EStage = DualScriber.ESTAGE.B) Then
            Me.m_ODevice.WriteDeviceBlock("D6126", 1, 1)
        End If
    End Sub


    Public Sub BeginMovement(ByVal EStage As ESTAGE, ByVal F64LeftX As Double, ByVal F64RightX As Double, ByVal F64Y As Double, ByVal F64T As Double)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim I32LeftX As Integer = Convert.ToInt32(F64LeftX * 10000)
            Dim I32RightX As Integer = Convert.ToInt32(F64RightX * 10000)
            Dim I32Y As Integer = Convert.ToInt32(F64Y * 10000)
            Dim I32T As Integer = Convert.ToInt32(F64T * 100000)

            Dim ArrU8LeftX As Byte() = BitConverter.GetBytes(I32LeftX)
            Dim ArrU8RightX As Byte() = BitConverter.GetBytes(I32RightX)
            Dim ArrU8Y As Byte() = BitConverter.GetBytes(I32Y)
            Dim ArrU8T As Byte() = BitConverter.GetBytes(I32T)

            Dim ArrI16Value As Short() = New Short(7) {}
            ArrI16Value(0) = BitConverter.ToInt16(ArrU8LeftX, 0)
            ArrI16Value(1) = BitConverter.ToInt16(ArrU8LeftX, 2)
            ArrI16Value(2) = BitConverter.ToInt16(ArrU8RightX, 0)
            ArrI16Value(3) = BitConverter.ToInt16(ArrU8RightX, 2)
            ArrI16Value(4) = BitConverter.ToInt16(ArrU8Y, 0)
            ArrI16Value(5) = BitConverter.ToInt16(ArrU8Y, 2)
            ArrI16Value(6) = BitConverter.ToInt16(ArrU8T, 0)
            ArrI16Value(7) = BitConverter.ToInt16(ArrU8T, 2)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock2("D6170", 8, ArrI16Value(0))
                Me.m_ODevice.WriteDeviceBlock("D6166", 1, 1)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock2("D6190", 8, ArrI16Value(0))
                Me.m_ODevice.WriteDeviceBlock("D6181", 1, 1)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendReCalibration(ByVal EStage As ESTAGE)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6169", 1, 1)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock("D6184", 1, 1)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Function IsStartMovement(ByVal EStage As ESTAGE) As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock("D6116", 1, I32Result)


            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.ReadDeviceBlock("D6131", 1, I32Result)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Private Sub InitBeginMovement(ByVal EStage As ESTAGE)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6166", 1, 0)
                Me.m_ODevice.WriteDeviceBlock("D6169", 1, 0)
                Thread.Sleep(1000)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock("D6181", 1, 0)
                Me.m_ODevice.WriteDeviceBlock("D6184", 1, 0)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Function IsFinishMovement(ByVal EStage As ESTAGE) As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock("D6117", 1, I32Result)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.ReadDeviceBlock("D6132", 1, I32Result)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Private Sub EndMovement(ByVal EStage As ESTAGE, ByVal I32Value As Integer)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6167", 1, I32Value)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock("D6182", 1, I32Value)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub FinishCalibration(ByVal EStage As ESTAGE, ByVal BIsSuccess As Boolean)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                If (BIsSuccess = True) Then
                    Me.m_ODevice.WriteDeviceBlock("D6168", 1, 1)
                Else
                    Me.m_ODevice.WriteDeviceBlock("D6168", 1, 2)
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (BIsSuccess = True) Then
                    Me.m_ODevice.WriteDeviceBlock("D6183", 1, 1)
                Else
                    Me.m_ODevice.WriteDeviceBlock("D6183", 1, 2)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub EndCalibration(ByVal EStage As ESTAGE)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6168", 1, 0)
                Me.m_ODevice.WriteDeviceBlock("D6165", 1, 0)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock("D6183", 1, 0)
                Me.m_ODevice.WriteDeviceBlock("D6180", 1, 0)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendAlignmentResult(ByVal EStage As ESTAGE, ByVal F64LeftX As Double, ByVal F64RightX As Double, ByVal F64Y As Double, ByVal F64T As Double)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim I32LeftX As Integer = Convert.ToInt32(F64LeftX * 10000)
            Dim I32RightX As Integer = Convert.ToInt32(F64RightX * -10000)
            Dim I32Y As Integer = Convert.ToInt32(F64Y * 10000)
            Dim I32T As Integer = Convert.ToInt32(F64T * 100000)

            '20190427 sfa request
            If (I32LeftX = 0) Then I32LeftX = 1
            If (I32RightX = 0) Then I32RightX = 1
            If (I32Y = 0) Then I32Y = 1
            If (I32T = 0) Then I32T = 1

            Dim ArrU8LeftX As Byte() = BitConverter.GetBytes(I32LeftX)
            Dim ArrU8RightX As Byte() = BitConverter.GetBytes(I32RightX)
            Dim ArrU8Y As Byte() = BitConverter.GetBytes(I32Y)
            Dim ArrU8T As Byte() = BitConverter.GetBytes(I32T)

            Dim ArrI16Value As Short() = New Short(7) {}
            ArrI16Value(0) = BitConverter.ToInt16(ArrU8Y, 0)
            ArrI16Value(1) = BitConverter.ToInt16(ArrU8Y, 2)
            ArrI16Value(2) = BitConverter.ToInt16(ArrU8T, 0)
            ArrI16Value(3) = BitConverter.ToInt16(ArrU8T, 2)
            ArrI16Value(4) = BitConverter.ToInt16(ArrU8LeftX, 0)
            ArrI16Value(5) = BitConverter.ToInt16(ArrU8LeftX, 2)
            ArrI16Value(6) = BitConverter.ToInt16(ArrU8RightX, 0)
            ArrI16Value(7) = BitConverter.ToInt16(ArrU8RightX, 2)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock2("D6000", 8, ArrI16Value(0))
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock2("D6010", 8, ArrI16Value(0))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendManualAlignment(ByVal EStage As ESTAGE)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6120", 1, 1)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock("D6121", 1, 1)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub GetEdgeRequest(ByVal EStage As ESTAGE, ByRef ELeftRequest As EEDGE_REQUEST, ByRef ERightRequest As EEDGE_REQUEST)
        ELeftRequest = EEDGE_REQUEST.NONE
        ERightRequest = EEDGE_REQUEST.NONE

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim I32LeftRequest As Integer = 0
            Dim I32RightRequest As Integer = 0

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock("D6090", 1, I32LeftRequest)
                Me.m_ODevice.ReadDeviceBlock("D6091", 1, I32RightRequest)
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.ReadDeviceBlock("D6092", 1, I32LeftRequest)
                Me.m_ODevice.ReadDeviceBlock("D6093", 1, I32RightRequest)
            End If

            ELeftRequest = CType([Enum].ToObject(GetType(EEDGE_REQUEST), I32LeftRequest), EEDGE_REQUEST)
            ERightRequest = CType([Enum].ToObject(GetType(EEDGE_REQUEST), I32RightRequest), EEDGE_REQUEST)
        Catch ex As Exception
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub GetEquipInfo(ByVal EStage As ESTAGE, ByRef F64LeftX As Double, ByRef F64RightX As Double, ByRef F64Y As Double)
        F64LeftX = 0
        F64RightX = 0
        F64Y = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim ArrI16Value As Short() = New Short(5) {}
            Dim ArrU8Value As Byte() = New Byte(11) {}

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock2("D6050", 6, ArrI16Value(0))
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.ReadDeviceBlock2("D6060", 6, ArrI16Value(0))
            End If

            'Left X
            Dim ArrU8Value1 As Byte() = BitConverter.GetBytes(ArrI16Value(0))
            Dim ArrU8Value2 As Byte() = BitConverter.GetBytes(ArrI16Value(1))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 0, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 2, 2)
            'Right X
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(2))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(3))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 4, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 6, 2)
            'Y
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(4))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(5))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 8, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 10, 2)

            F64LeftX = BitConverter.ToInt32(ArrU8Value, 0)
            F64RightX = BitConverter.ToInt32(ArrU8Value, 4)
            F64Y = BitConverter.ToInt32(ArrU8Value, 8)

            F64LeftX = F64LeftX / 10000D
            F64RightX = F64RightX / 10000D
            F64Y = F64Y / 10000D
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub GetEquipInfo(ByVal EStage As ESTAGE, ByRef F64LeftX As Double, ByRef F64RightX As Double, ByRef F64Y As Double, ByRef F64T As Double)
        F64LeftX = 0
        F64RightX = 0
        F64Y = 0
        F64T = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim ArrI16Value As Short() = New Short(7) {}
            Dim ArrU8Value As Byte() = New Byte(15) {}

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.ReadDeviceBlock2("D6050", 8, ArrI16Value(0))
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.ReadDeviceBlock2("D6060", 8, ArrI16Value(0))
            End If

            'Left X
            Dim ArrU8Value1 As Byte() = BitConverter.GetBytes(ArrI16Value(0))
            Dim ArrU8Value2 As Byte() = BitConverter.GetBytes(ArrI16Value(1))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 0, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 2, 2)
            'Right X
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(2))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(3))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 4, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 6, 2)
            'Y
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(4))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(5))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 8, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 10, 2)

            'T
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(6))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(7))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 12, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 14, 2)

            F64LeftX = BitConverter.ToInt32(ArrU8Value, 0)
            F64RightX = BitConverter.ToInt32(ArrU8Value, 4)
            F64Y = BitConverter.ToInt32(ArrU8Value, 8)
            F64T = BitConverter.ToInt32(ArrU8Value, 12)

            F64LeftX = F64LeftX / 10000D
            F64RightX = F64RightX / 10000D
            F64Y = F64Y / 10000D
            F64T = F64T / 100000D
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub GetWheelPosition(ByRef F64StageALeftWheel As Double, ByRef F64StageARightWheel As Double, ByRef F64StageBLeftWheel As Double, ByRef F64StageBRightWheel As Double)
        F64StageALeftWheel = 0
        F64StageARightWheel = 0
        F64StageBLeftWheel = 0
        F64StageBRightWheel = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim ArrI16Value As Short() = New Short(7) {}
            Dim ArrU8Value As Byte() = New Byte(15) {}

            Me.m_ODevice.ReadDeviceBlock2("D6140", 8, ArrI16Value(0))

            'ST #1 Left
            Dim ArrU8Value1 As Byte() = BitConverter.GetBytes(ArrI16Value(0))
            Dim ArrU8Value2 As Byte() = BitConverter.GetBytes(ArrI16Value(1))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 0, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 2, 2)
            'ST #1 Right
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(2))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(3))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 4, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 6, 2)
            'ST #2 Left
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(4))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(5))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 8, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 10, 2)
            'ST #1 Right
            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(6))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(7))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 12, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 14, 2)

            F64StageALeftWheel = BitConverter.ToInt32(ArrU8Value, 0)
            F64StageARightWheel = BitConverter.ToInt32(ArrU8Value, 4)
            F64StageBLeftWheel = BitConverter.ToInt32(ArrU8Value, 8)
            F64StageBRightWheel = BitConverter.ToInt32(ArrU8Value, 12)

            F64StageALeftWheel = F64StageALeftWheel / 10000D
            F64StageARightWheel = F64StageARightWheel / 10000D
            F64StageBLeftWheel = F64StageBLeftWheel / 10000D
            F64StageBRightWheel = F64StageBRightWheel / 10000D
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendEstimatedLength(ByVal ECamera As ECAMERA, ByVal F64Length As Double)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim I32Value As Integer = Convert.ToInt32(F64Length * 10000)
            Dim ArrU8Value As Byte() = BitConverter.GetBytes(I32Value)
            Dim ArrI16Value As Short() = New Short(1) {}
            ArrI16Value(0) = BitConverter.ToInt16(ArrU8Value, 0)
            ArrI16Value(1) = BitConverter.ToInt16(ArrU8Value, 2)

            If (ECamera = DualScriber.ECAMERA.A_LEFT) Then
                Me.m_ODevice.WriteDeviceBlock2("D6240", 2, ArrI16Value(0))
            ElseIf (ECamera = DualScriber.ECAMERA.A_RIGHT) Then
                Me.m_ODevice.WriteDeviceBlock2("D6242", 2, ArrI16Value(0))
            ElseIf (ECamera = DualScriber.ECAMERA.B_LEFT) Then
                Me.m_ODevice.WriteDeviceBlock2("D6244", 2, ArrI16Value(0))
            ElseIf (ECamera = DualScriber.ECAMERA.B_RIGHT) Then
                Me.m_ODevice.WriteDeviceBlock2("D6246", 2, ArrI16Value(0))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Function GetCalcDegreeRequest(ByVal EStage As ESTAGE, ByVal EView As EVIEW) As Integer
        Dim I32Result As Integer = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.ReadDeviceBlock("D6300", 1, I32Result)
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.ReadDeviceBlock("D6301", 1, I32Result)
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.ReadDeviceBlock("D6305", 1, I32Result)
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.ReadDeviceBlock("D6306", 1, I32Result)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return I32Result
    End Function


    Private Sub GetCalcDegreeCondition _
    ( _
        ByVal EStage As ESTAGE, ByVal EView As EVIEW, _
        ByRef F64TopHorizontal As Double, ByRef F64BottomHorizontal As Double, ByRef F64Vertical As Double _
    )
        F64TopHorizontal = 0
        F64BottomHorizontal = 0
        F64Vertical = 0

        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim ArrI16Value As Short() = New Short(9) {}
            Dim ArrU8Value As Byte() = New Byte(11) {}

            If (EStage = DualScriber.ESTAGE.A) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.ReadDeviceBlock2("D6320", 10, ArrI16Value(0))
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.ReadDeviceBlock2("D6330", 10, ArrI16Value(0))
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.ReadDeviceBlock2("D6360", 10, ArrI16Value(0))
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.ReadDeviceBlock2("D6370", 10, ArrI16Value(0))
                End If
            End If

            Dim ArrU8Value1 As Byte() = BitConverter.GetBytes(ArrI16Value(0))
            Dim ArrU8Value2 As Byte() = BitConverter.GetBytes(ArrI16Value(1))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 0, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 2, 2)

            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(4))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(5))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 4, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 6, 2)

            ArrU8Value1 = BitConverter.GetBytes(ArrI16Value(8))
            ArrU8Value2 = BitConverter.GetBytes(ArrI16Value(9))
            Array.Copy(ArrU8Value1, 0, ArrU8Value, 8, 2)
            Array.Copy(ArrU8Value2, 0, ArrU8Value, 10, 2)

            F64TopHorizontal = BitConverter.ToInt32(ArrU8Value, 0)
            F64BottomHorizontal = BitConverter.ToInt32(ArrU8Value, 4)
            F64Vertical = BitConverter.ToInt32(ArrU8Value, 8)

            F64TopHorizontal = F64TopHorizontal / 10000D
            F64BottomHorizontal = F64BottomHorizontal / 10000D
            F64Vertical = F64Vertical / 10000D
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendCalcDegreeResult(ByVal EStage As ESTAGE, ByVal EView As EVIEW, ByVal F64Value As Double)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Dim I32Value As Integer = Convert.ToInt32(F64Value * 100000)
            Dim ArrU8Value As Byte() = BitConverter.GetBytes(I32Value)
            Dim ArrI16Value As Short() = New Short(1) {}
            ArrI16Value(0) = BitConverter.ToInt16(ArrU8Value, 0)
            ArrI16Value(1) = BitConverter.ToInt16(ArrU8Value, 2)

            If (EStage = DualScriber.ESTAGE.A) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.WriteDeviceBlock2("D6250", 2, ArrI16Value(0))
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.WriteDeviceBlock2("D6252", 2, ArrI16Value(0))
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.WriteDeviceBlock2("D6260", 2, ArrI16Value(0))
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.WriteDeviceBlock2("D6262", 2, ArrI16Value(0))
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub CompletedCalcDegree(ByVal EStage As ESTAGE, ByVal EView As EVIEW)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6230", 1, 1)
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6231", 1, 1)
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6235", 1, 1)
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6236", 1, 1)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub InitCalcDegree(ByVal EStage As ESTAGE, ByVal EView As EVIEW)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6230", 1, 0)
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6231", 1, 0)
                End If
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                If (EView = DualScriber.EVIEW.LEFT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6235", 1, 0)
                ElseIf (EView = DualScriber.EVIEW.RIGHT) Then
                    Me.m_ODevice.WriteDeviceBlock("D6236", 1, 0)
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendErrorCode(ByVal EStage As ESTAGE, ByVal EError As EERROR)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (EStage = DualScriber.ESTAGE.A) Then
                Me.m_ODevice.WriteDeviceBlock("D6094", 1, CType(EError, Integer))
            ElseIf (EStage = DualScriber.ESTAGE.B) Then
                Me.m_ODevice.WriteDeviceBlock("D6095", 1, CType(EError, Integer))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub OnRecipeRequested(ByVal I32ID As Integer)
        Try
            If (Not Me.m_ORecipeRequested Is Nothing) Then
                Me.m_ORecipeRequested(I32ID)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageABeginCalibration()
        Try
            If (Not Me.m_OStageABeginCalibration Is Nothing) Then
                Me.m_OStageABeginCalibration()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageBBeginCalibration()
        Try
            If (Not Me.m_OStageBBeginCalibration Is Nothing) Then
                Me.m_OStageBBeginCalibration()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageAEndMovement()
        Try
            If (Not Me.m_OStageAEndMovement Is Nothing) Then
                Me.m_OStageAEndMovement()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageBEndMovement()
        Try
            If (Not Me.m_OStageBEndMovement Is Nothing) Then
                Me.m_OStageBEndMovement()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageACalcDegree _
    ( _
       ByVal EView As EVIEW, _
       ByVal F64TopHorizontal As Double, _
       ByVal F64BottomHorizontal As Double, _
       ByVal F64Vertical As Double _
    )
        Try
            If (Not Me.m_OStageACalcDegree Is Nothing) Then
                Me.m_OStageACalcDegree(EView, F64TopHorizontal, F64BottomHorizontal, F64Vertical)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageBCalcDegree _
    ( _
       ByVal EView As EVIEW, _
       ByVal F64TopHorizontal As Double, _
       ByVal F64BottomHorizontal As Double, _
       ByVal F64Vertical As Double _
    )
        Try
            If (Not Me.m_OStageBCalcDegree Is Nothing) Then
                Me.m_OStageBCalcDegree(EView, F64TopHorizontal, F64BottomHorizontal, F64Vertical)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnWheelPositionChanged(ByVal F64StageALeftWheel As Double, ByVal F64StageARightWheel As Double, ByVal F64StageBLeftWheel As Double, ByVal F64StageBRightWheel As Double)
        Try
            If (Not Me.m_OWheelPositionChanged Is Nothing) Then
                Me.m_OWheelPositionChanged(F64StageALeftWheel, F64StageARightWheel, F64StageBLeftWheel, F64StageBRightWheel)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Function Close() As Boolean
        Dim BResult As Boolean = False

        Try
            If (Me.m_BConnected = True) Then
                Me.m_ODevice.Close()
                Me.m_BConnected = False
            End If

            BResult = True
        Catch ex As Exception
            CError.Throw(ex)
        End Try

        Return BResult
    End Function


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            Me.EndWork()
            Me.Close()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
