Imports System.Threading
Imports Jhjo.Common


Public Class CPCI
    Implements IDisposable

#Region "CONST"
    ' jht ticks 사용하지 않고 Stopwatch 사용
    Private Const WAIT_DELAY As Integer = 1000 '1s
#End Region


#Region "VARIABLE"
    Private m_I16Device As Short = 0
    Private m_BConnected As Boolean = False
    Private m_OInterrupt As Object = Nothing

    Private m_OWorker As Thread = Nothing
    Private m_BDoWork As Boolean = False
    ' jht Process Input 스레드 나눔
    Private m_ThreadProcessInput As Thread = Nothing
    Private m_bThreadProcessInput As Boolean = False

    Private m_U16Input As UShort = 0
    Private m_U16Output As UShort = 0
    Private m_U16BeforeInput As UShort = 0
    Private m_U16BeforeOutput As UShort = 0

    Private m_BInReady As Boolean = False
    Private m_BInStageAAlignStart As Boolean = False
    Private m_BInStageBAlignStart As Boolean = False
    Private m_BInStageAEdgeStart As Boolean = False
    Private m_BInStageBEdgeStart As Boolean = False
    Private m_BInStageAInitialize As Boolean = False
    Private m_BInStageBInitialize As Boolean = False

    Private m_BBeforeInReady As Boolean = False
    Private m_BBeforeInStageAAlignStart As Boolean = False
    Private m_BBeforeInStageBAlignStart As Boolean = False
    Private m_BBeforeInStageAEdgeStart As Boolean = False
    Private m_BBeforeInStageBEdgeStart As Boolean = False
    Private m_BBeforeInStageAInitialize As Boolean = False
    Private m_BBeforeInStageBInitialize As Boolean = False

    Private m_BOutStageAReady As Boolean = False
    Private m_BOutStageABusy As Boolean = False
    Private m_BOutStageAAlignRetry As Boolean = False
    Private m_BOutStageAAlignOK As Boolean = False
    Private m_BOutStageAEdgeOK As Boolean = False
    Private m_BOutStageAAlignLeftNG As Boolean = False
    Private m_BOutStageAAlignRightNG As Boolean = False
    Private m_BOutStageAEdgeNG As Boolean = False
    Private m_BOutStageBReady As Boolean = False
    Private m_BOutStageBBusy As Boolean = False
    Private m_BOutStageBAlignRetry As Boolean = False
    Private m_BOutStageBAlignOK As Boolean = False
    Private m_BOutStageBEdgeOK As Boolean = False
    Private m_BOutStageBAlignLeftNG As Boolean = False
    Private m_BOutStageBAlignRightNG As Boolean = False
    Private m_BOutStageBEdgeNG As Boolean = False
    ' jht ticks 사용하지 않고 Stopwatch 사용
    Private m_objStopWatchHeartBeat As Stopwatch = New Stopwatch()
    Private m_objStopWatchStageAAlignmentResponsed As Stopwatch = New Stopwatch()
    Private m_objStopWatchStageBAlignmentResponsed As Stopwatch = New Stopwatch()
    Private m_objStopWatchStageAEdgeResponsed As Stopwatch = New Stopwatch()
    Private m_objStopWatchStageBEdgeResponsed As Stopwatch = New Stopwatch()

    Private m_OStageAAlignmentRequested As AlignmentRequestedHandler = Nothing
    Private m_OStageBAlignmentRequested As AlignmentRequestedHandler = Nothing
    Private m_OStartAEdgeRequested As EdgeRequestedHandler = Nothing
    Private m_OStartBEdgeRequested As EdgeRequestedHandler = Nothing
    Private m_OStageAInitalizeRequested As InitializeRequestedHandler = Nothing
    Private m_OStageBInitalizeRequested As InitializeRequestedHandler = Nothing
    ' jht 시뮬레이션 스레드
    Private m_ThreadSimulation As Thread = Nothing
    Private m_bThreadSimulation As Boolean = False
    ' jht 시뮬레이션 모드
    Private m_iSimulationMode As Integer = 0
    ' jht 시뮬레이션 시작
    Private m_bSimulationStart As Boolean = False
    ' jht 시뮬레이션 검사 On, Off
    Private m_bSimulationInspection As Boolean = False
#End Region


#Region "DELEGATE & EVENT"
    Public Delegate Sub AlignmentRequestedHandler()
    Public Delegate Sub EdgeRequestedHandler()
    Public Delegate Sub InitializeRequestedHandler()
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property BConnected() As Boolean
        Get
            Return Me.m_BConnected
        End Get
    End Property


#Region "OUTPUT PROPERTIES"
    Public ReadOnly Property BOutStageAReady() As Boolean
        Get
            Return Me.m_BOutStageAReady
        End Get
    End Property


    Public ReadOnly Property BOutStageABusy() As Boolean
        Get
            Return Me.m_BOutStageABusy
        End Get
    End Property


    Public ReadOnly Property BOutStageAAlignRetry() As Boolean
        Get
            Return Me.m_BOutStageAAlignRetry
        End Get
    End Property


    Public ReadOnly Property BOutStageAAlignOK() As Boolean
        Get
            Return Me.m_BOutStageAAlignOK
        End Get
    End Property


    Public ReadOnly Property BOutStageAEdgeOK() As Boolean
        Get
            Return Me.m_BOutStageAEdgeOK
        End Get
    End Property


    Public ReadOnly Property BOutStageAAlignLeftNG() As Boolean
        Get
            Return Me.m_BOutStageAAlignLeftNG
        End Get
    End Property


    Public ReadOnly Property BOutStageAAlignRightNG() As Boolean
        Get
            Return Me.m_BOutStageAAlignRightNG
        End Get
    End Property


    Public ReadOnly Property BOutStageAEdgeNG() As Boolean
        Get
            Return Me.m_BOutStageAEdgeNG
        End Get
    End Property


    Public ReadOnly Property BOutStageBReady() As Boolean
        Get
            Return Me.m_BOutStageBReady
        End Get
    End Property


    Public ReadOnly Property BOutStageBBusy() As Boolean
        Get
            Return Me.m_BOutStageBBusy
        End Get
    End Property


    Public ReadOnly Property BOutStageBAlignRetry() As Boolean
        Get
            Return Me.m_BOutStageBAlignRetry
        End Get
    End Property


    Public ReadOnly Property BOutStageBAlignOK() As Boolean
        Get
            Return Me.m_BOutStageBAlignOK
        End Get
    End Property


    Public ReadOnly Property BOutStageBEdgeOK() As Boolean
        Get
            Return Me.m_BOutStageBEdgeOK
        End Get
    End Property


    Public ReadOnly Property BOutStageBAlignLeftNG() As Boolean
        Get
            Return Me.m_BOutStageBAlignLeftNG
        End Get
    End Property


    Public ReadOnly Property BOutStageBAlignRightNG() As Boolean
        Get
            Return Me.m_BOutStageBAlignRightNG
        End Get
    End Property


    Public ReadOnly Property BOutStageBEdgeNG() As Boolean
        Get
            Return Me.m_BOutStageBEdgeNG
        End Get
    End Property
#End Region


#Region "INPUT PROPERTIES"
    Public ReadOnly Property BInReady() As Boolean
        Get
            Return Me.m_BInReady
        End Get
    End Property


    Public ReadOnly Property BInStageAAlignStart() As Boolean
        Get
            Return Me.m_BInStageAAlignStart
        End Get
    End Property


    Public ReadOnly Property BInStageBAlignStart() As Boolean
        Get
            Return Me.m_BInStageBAlignStart
        End Get
    End Property


    Public ReadOnly Property BInStageAEdgeStart() As Boolean
        Get
            Return Me.m_BInStageAEdgeStart
        End Get
    End Property


    Public ReadOnly Property BInStageBEdgeStart() As Boolean
        Get
            Return Me.m_BInStageBEdgeStart
        End Get
    End Property


    Public ReadOnly Property BInStageAInitialize() As Boolean
        Get
            Return Me.m_BInStageAInitialize
        End Get
    End Property


    Public ReadOnly Property BInStageBInitialize() As Boolean
        Get
            Return Me.m_BInStageBInitialize
        End Get
    End Property
#End Region


#Region "CALL PROPERTIES"
    Public WriteOnly Property OStageAAlignmentRequested() As AlignmentRequestedHandler
        Set(ByVal value As AlignmentRequestedHandler)
            Me.m_OStageAAlignmentRequested = value
        End Set
    End Property


    Public WriteOnly Property OStageBAlignmentRequested() As AlignmentRequestedHandler
        Set(ByVal value As AlignmentRequestedHandler)
            Me.m_OStageBAlignmentRequested = value
        End Set
    End Property


    Public WriteOnly Property OStartAEdgeRequested() As EdgeRequestedHandler
        Set(ByVal value As EdgeRequestedHandler)
            Me.m_OStartAEdgeRequested = value
        End Set
    End Property


    Public WriteOnly Property OStartBEdgeRequested() As EdgeRequestedHandler
        Set(ByVal value As EdgeRequestedHandler)
            Me.m_OStartBEdgeRequested = value
        End Set
    End Property


    Public WriteOnly Property OStageAInitalizeRequested() As InitializeRequestedHandler
        Set(ByVal value As InitializeRequestedHandler)
            Me.m_OStageAInitalizeRequested = value
        End Set
    End Property


    Public WriteOnly Property OStageBInitalizeRequested() As InitializeRequestedHandler
        Set(ByVal value As InitializeRequestedHandler)
            Me.m_OStageBInitalizeRequested = value
        End Set
    End Property
#End Region
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        Try
            Me.Regist()
            ' jht ticks 사용하지 않고 Stopwatch 사용
            Me.m_objStopWatchHeartBeat.Start()
            Me.m_OInterrupt = New Object()
            ' jht 시뮬레이션 모드 변수 갱신
            Me.m_iSimulationMode = CEnvironment.It.SimulationMode()

            If (Me.m_BConnected = True) Then
                Me.BeginWork()
            Else
                CMsgBox.Error("Cannot connect to PCI7230")
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
    Public Function Regist() As Boolean
        Dim BResult As Boolean = False

        Try
            If (Me.m_BConnected = False) Then
                Me.m_I16Device = PCI.Register_Card(PCI.PCI_7230, 0)
                Me.m_BConnected = (Me.m_I16Device >= 0)
            End If

            If (Me.m_BConnected = True) Then
                PCI.DO_WritePort(Me.m_I16Device, 0, 0)
            End If

            BResult = Me.m_BConnected
        Catch ex As Exception
            CError.Ignore(ex)
        End Try

        Return BResult
    End Function


    Public Sub Release()
        Try
            If Me.m_BConnected = True Then
                PCI.Release_Card(Me.m_I16Device)
                Me.m_BConnected = False
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub BeginWork()
        Try
            If Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = True

                Me.m_OWorker = New Thread(AddressOf Me.Work)
                Me.m_OWorker.IsBackground = True
                Me.m_OWorker.Start()
            End If

            ' jht Process Input Thread
            If Me.m_ThreadProcessInput Is Nothing Then
                Me.m_bThreadProcessInput = True
                Me.m_ThreadProcessInput = New Thread(AddressOf Me.WorkProcessInput)
                Me.m_ThreadProcessInput.IsBackground = True
                Me.m_ThreadProcessInput.Start()
            End If

            ' jht 시뮬레이션 스레드 추가
            If 1 = Me.m_iSimulationMode Then
                If Me.m_ThreadSimulation Is Nothing Then
                    Me.m_bThreadSimulation = True
                    Me.m_ThreadSimulation = New Thread(AddressOf Me.WorkSimulation)
                    Me.m_ThreadSimulation.IsBackground = True
                    Me.m_ThreadSimulation.Start()
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub Work()
        Try
            While (Me.m_BDoWork = True)
                Try
                    Me.ProcessInput()
                    Me.ProcessOutput()
                Catch
                End Try

                Thread.Sleep(50)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub

    ' jht Process Input Thread
    Private Sub WorkProcessInput()
        Try
            While (Me.m_bThreadProcessInput = True)
                Try
                    Me.m_BInReady = (Me.m_U16Input And CType(EINPUT.PLC_READY, UShort)) = CType(EINPUT.PLC_READY, UShort)
                    Me.m_BInStageAAlignStart = (Me.m_U16Input And CType(EINPUT.STAGEA_ALIGN_START, UShort)) = CType(EINPUT.STAGEA_ALIGN_START, UShort)
                    Me.m_BInStageBAlignStart = (Me.m_U16Input And CType(EINPUT.STAGEB_ALIGN_START, UShort)) = CType(EINPUT.STAGEB_ALIGN_START, UShort)
                    Me.m_BInStageAEdgeStart = (Me.m_U16Input And CType(EINPUT.STAGEA_EDGE_START, UShort)) = CType(EINPUT.STAGEA_EDGE_START, UShort)
                    Me.m_BInStageBEdgeStart = (Me.m_U16Input And CType(EINPUT.STAGEB_EDGE_START, UShort)) = CType(EINPUT.STAGEB_EDGE_START, UShort)
                    Me.m_BInStageAInitialize = (Me.m_U16Input And CType(EINPUT.STAGEA_INITIALIZE, UShort)) = CType(EINPUT.STAGEA_INITIALIZE, UShort)
                    Me.m_BInStageBInitialize = (Me.m_U16Input And CType(EINPUT.STAGEB_INITIALIZE, UShort)) = CType(EINPUT.STAGEB_INITIALIZE, UShort)

                    ' jht 시뮬레이션 모드
                    If 1 = Me.m_iSimulationMode Then
                        ' 시뮬레이션 검사 True이면 Align Start 신호 True로 False면 False로 줌
                        If True = Me.m_bSimulationInspection Then
                            Me.m_BInStageAAlignStart = True
                            Me.m_BInStageBAlignStart = True
                        Else
                            Me.m_BInStageAAlignStart = False
                            Me.m_BInStageBAlignStart = False
                        End If
                    End If

                    If (Not Me.m_BInStageAInitialize = Me.m_BBeforeInStageAInitialize) And (Me.m_BInStageAInitialize = True) Then
                        Me.OnStageAInitalizeRequested()
                        Me.InitStageAOutput()
                    Else
                        'Alignment A
                        If Not Me.m_BInStageAAlignStart = Me.m_BBeforeInStageAAlignStart Then
                            If Me.m_BInStageAAlignStart = True Then
                                Me.OnStageAAlignmentRequested()
                            ElseIf BInStageAAlignStart = False Then
                                Me.InitStageAAlignmentResult()
                            End If
                        End If
                        'Edge A
                        If Not Me.m_BInStageAEdgeStart = Me.m_BBeforeInStageAEdgeStart Then
                            If Me.m_BInStageAEdgeStart = True Then
                                Me.OnStartAEdgeRequested()
                            Else
                                Me.InitStageAEdgeResult()
                            End If
                        End If
                    End If

                    If (Not Me.m_BInStageBInitialize = Me.m_BBeforeInStageBInitialize) And (Me.m_BInStageBInitialize = True) Then
                        Me.OnStageBInitalizeRequested()
                        Me.InitStageBOutput()
                    Else
                        'Alignment B
                        If Not Me.m_BInStageBAlignStart = Me.m_BBeforeInStageBAlignStart Then
                            If Me.m_BInStageBAlignStart = True Then
                                Me.OnStageBAlignmentRequested()
                            ElseIf BInStageBAlignStart = False Then
                                Me.InitStageBAlignmentResult()
                            End If
                        End If
                        'Edge B
                        If Not Me.m_BInStageBEdgeStart = Me.m_BBeforeInStageBEdgeStart Then
                            If Me.m_BInStageBEdgeStart = True Then
                                Me.OnStartBEdgeRequested()
                            Else
                                Me.InitStageBEdgeResult()
                            End If
                        End If
                    End If


                    Me.m_U16BeforeInput = Me.m_U16Input
                    Me.m_BBeforeInReady = Me.m_BInReady
                    Me.m_BBeforeInStageAAlignStart = Me.m_BInStageAAlignStart
                    Me.m_BBeforeInStageBAlignStart = Me.m_BInStageBAlignStart
                    Me.m_BBeforeInStageAEdgeStart = Me.m_BInStageAEdgeStart
                    Me.m_BBeforeInStageBEdgeStart = Me.m_BInStageBEdgeStart
                    Me.m_BBeforeInStageAInitialize = Me.m_BInStageAInitialize
                    Me.m_BBeforeInStageBInitialize = Me.m_BInStageBInitialize
                Catch
                End Try

                Thread.Sleep(50)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub

    ' jht 시뮬레이션 스레드 추가
    Private Sub WorkSimulation()
        Try
            ' jht 해당 부분에서 A, B On - 1 sec delay - Off - 3.5 sec delay 반복
            Dim iInspectionOnDelay As Integer = 1000
            Dim iInspectionOffDelay As Integer = 3500
            Dim objStopWatch As Stopwatch = New Stopwatch()

            While (Me.m_bThreadSimulation = True)
                Try
                    ' 설비 정지인 경우
                    If False = Me.m_bSimulationStart Then
                        ' 타이머 도는 중인 경우
                        If True = objStopWatch.IsRunning Then
                            ' 검사 IO OFF
                            Me.m_bSimulationInspection = False
                            ' 타이머 OFF
                            objStopWatch.Stop()
                            objStopWatch.Reset()
                        End If
                        Thread.Sleep(iInspectionOffDelay)
                        Continue While
                    End If

                    ' 검사 IO OFF 인 경우
                    If False = Me.m_bSimulationInspection Then
                        If False = objStopWatch.IsRunning Then
                            ' 검사 IO ON
                            Me.m_bSimulationInspection = True
                            ' 타이머 ON
                            objStopWatch.Start()
                        End If
                    End If
                    If iInspectionOnDelay <= objStopWatch.ElapsedMilliseconds Then
                        ' 검사 IO OFF
                        Me.m_bSimulationInspection = False
                        ' 타이머 OFF
                        objStopWatch.Stop()
                        objStopWatch.Reset()
                    End If
                Catch
                End Try

                Thread.Sleep(iInspectionOffDelay)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub

    Private Sub EndWork()
        Try
            If Not Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = False

                Me.m_OWorker.Join()
                Me.m_OWorker = Nothing
            End If
            ' jht Process Input Thread
            If Not Me.m_ThreadProcessInput Is Nothing Then
                Me.m_bThreadProcessInput = False
                Me.m_ThreadProcessInput.Join()
                Me.m_ThreadProcessInput = Nothing
            End If
            ' jht 시뮬레이션 스레드 추가
            If 1 = Me.m_iSimulationMode Then
                Me.m_bThreadSimulation = False
                Me.m_ThreadSimulation.Join()
                Me.m_ThreadSimulation = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub ProcessInput()
        Try
            PCI.DI_ReadPort(Me.m_I16Device, 0, Me.m_U16Input)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub ProcessOutput()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            ' jht ticks 사용하지 않고 Stopwatch 사용
            'HeartBeat
            If Me.m_objStopWatchHeartBeat.ElapsedMilliseconds >= WAIT_DELAY Then
                Me.m_BOutStageAReady = Not Me.m_BOutStageAReady
                Me.m_BOutStageBReady = Not Me.m_BOutStageBReady
                Me.m_objStopWatchHeartBeat.Stop()
                Me.m_objStopWatchHeartBeat.Reset()
                Me.m_objStopWatchHeartBeat.Start()
            End If
            'Stage A Alignment Timeout
            If Me.m_objStopWatchStageAAlignmentResponsed.ElapsedMilliseconds >= WAIT_DELAY Then
                Me.m_BOutStageAAlignOK = False
                Me.m_BOutStageAAlignRetry = False
                Me.m_BOutStageAAlignLeftNG = False
                Me.m_BOutStageAAlignRightNG = False
                Me.m_objStopWatchStageAAlignmentResponsed.Stop()
                Me.m_objStopWatchStageAAlignmentResponsed.Reset()
            End If
            'Stage A Edge Timeout
            If Me.m_objStopWatchStageAEdgeResponsed.ElapsedMilliseconds >= WAIT_DELAY Then
                Me.m_BOutStageAEdgeOK = False
                Me.m_BOutStageAEdgeNG = False
                Me.m_objStopWatchStageAEdgeResponsed.Stop()
                Me.m_objStopWatchStageAEdgeResponsed.Reset()
            End If
            'Stage B Alignment Timeout
            If Me.m_objStopWatchStageBAlignmentResponsed.ElapsedMilliseconds >= WAIT_DELAY Then
                Me.m_BOutStageBAlignOK = False
                Me.m_BOutStageBAlignRetry = False
                Me.m_BOutStageBAlignLeftNG = False
                Me.m_BOutStageBAlignRightNG = False
                Me.m_objStopWatchStageBAlignmentResponsed.Stop()
                Me.m_objStopWatchStageBAlignmentResponsed.Reset()
            End If
            'Stage B Edge Timeout
            If Me.m_objStopWatchStageBEdgeResponsed.ElapsedMilliseconds >= WAIT_DELAY Then
                Me.m_BOutStageBEdgeOK = False
                Me.m_BOutStageBEdgeNG = False
                Me.m_objStopWatchStageBEdgeResponsed.Stop()
                Me.m_objStopWatchStageBEdgeResponsed.Reset()
            End If

            Me.m_U16Output = CType(IIf(Me.m_BOutStageAReady, EOUTPUT.STAGEA_READY, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageABusy, EOUTPUT.STAGEA_BUSY, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageAAlignRetry, EOUTPUT.STAGEA_ALIGN_RETRY, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageAAlignOK, EOUTPUT.STAGEA_ALIGN_OK, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageAEdgeOK, EOUTPUT.STAGEA_EDGE_OK, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageAAlignLeftNG, EOUTPUT.STAGEA_ALIGN_LEFT_NG, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageAAlignRightNG, EOUTPUT.STAGEA_ALIGN_RIGHT_NG, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageAEdgeNG, EOUTPUT.STAGEA_EDGE_NG, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBReady, EOUTPUT.STAGEB_READY, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBBusy, EOUTPUT.STAGEB_BUSY, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBAlignRetry, EOUTPUT.STAGEB_ALIGN_RETRY, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBAlignOK, EOUTPUT.STAGEB_ALIGN_OK, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBEdgeOK, EOUTPUT.STAGEB_EDGE_OK, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBAlignLeftNG, EOUTPUT.STAGEB_ALIGN_LEFT_NG, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBAlignRightNG, EOUTPUT.STAGEB_ALIGN_RIGHT_NG, EOUTPUT.NONE), UShort)
            Me.m_U16Output += CType(IIf(Me.m_BOutStageBEdgeNG, EOUTPUT.STAGEB_EDGE_NG, EOUTPUT.NONE), UShort)

            ' jht PLC IO Write 하는 부분 무조건 들어가도록 수정
            PCI.DO_WritePort(Me.m_I16Device, 0, Me.m_U16Output)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub

    Public Sub BeginSimulation()
        Me.m_bSimulationStart = True
    End Sub

    Public Sub EndSimulation()
        Me.m_bSimulationStart = False
    End Sub

    Private Sub InitStageAOutput()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BOutStageABusy = False
            Me.m_BOutStageAAlignRetry = False
            Me.m_BOutStageAAlignOK = False
            Me.m_BOutStageAAlignLeftNG = False
            Me.m_BOutStageAAlignRightNG = False
            Me.m_BOutStageAEdgeOK = False
            Me.m_BOutStageAEdgeNG = False
            Me.m_objStopWatchStageAAlignmentResponsed.Stop()
            Me.m_objStopWatchStageAAlignmentResponsed.Reset()
            Me.m_objStopWatchStageAEdgeResponsed.Stop()
            Me.m_objStopWatchStageAEdgeResponsed.Reset()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub InitStageAAlignmentResult()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BOutStageAAlignOK = False
            Me.m_BOutStageAAlignRetry = False
            Me.m_BOutStageAAlignLeftNG = False
            Me.m_BOutStageAAlignRightNG = False
            Me.m_objStopWatchStageAAlignmentResponsed.Stop()
            Me.m_objStopWatchStageAAlignmentResponsed.Reset()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub InitStageAEdgeResult()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BOutStageAEdgeOK = False
            Me.m_BOutStageAEdgeNG = False
            Me.m_objStopWatchStageAEdgeResponsed.Stop()
            Me.m_objStopWatchStageAEdgeResponsed.Reset()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub InitStageBOutput()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BOutStageBBusy = False
            Me.m_BOutStageBAlignOK = False
            Me.m_BOutStageBAlignRetry = False
            Me.m_BOutStageBAlignLeftNG = False
            Me.m_BOutStageBAlignRightNG = False
            Me.m_BOutStageBEdgeOK = False
            Me.m_BOutStageBEdgeNG = False
            Me.m_objStopWatchStageBAlignmentResponsed.Stop()
            Me.m_objStopWatchStageBAlignmentResponsed.Reset()
            Me.m_objStopWatchStageBEdgeResponsed.Stop()
            Me.m_objStopWatchStageBEdgeResponsed.Reset()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub InitStageBAlignmentResult()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BOutStageBAlignOK = False
            Me.m_BOutStageBAlignRetry = False
            Me.m_BOutStageBAlignLeftNG = False
            Me.m_BOutStageBAlignRightNG = False
            Me.m_objStopWatchStageBAlignmentResponsed.Stop()
            Me.m_objStopWatchStageBAlignmentResponsed.Reset()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Sub InitStageBEdgeResult()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BOutStageBEdgeOK = False
            Me.m_BOutStageBEdgeNG = False
            Me.m_objStopWatchStageBEdgeResponsed.Stop()
            Me.m_objStopWatchStageBEdgeResponsed.Reset()
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub Busy(ByVal EStage As ESTAGE)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If EStage = DualScriber.ESTAGE.A Then
                Me.m_BOutStageABusy = True
            Else
                Me.m_BOutStageBBusy = True
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendAlignmentResult(ByVal EStage As ESTAGE, ByVal EResult As ERESULT, ByVal EView As EVIEW)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If EStage = DualScriber.ESTAGE.A Then
                If EResult = DualScriber.ERESULT.OK Then
                    Me.m_BOutStageAAlignOK = True
                ElseIf EResult = DualScriber.ERESULT.RETRY Then
                    Me.m_BOutStageAAlignRetry = True
                ElseIf EResult = DualScriber.ERESULT.NG Then
                    If EView = DualScriber.EVIEW.LEFT Then
                        Me.m_BOutStageAAlignLeftNG = True
                    ElseIf EView = DualScriber.EVIEW.RIGHT Then
                        Me.m_BOutStageAAlignRightNG = True
                    End If
                End If

                Me.m_BOutStageABusy = False
                ' jht ticks 사용하지 않고 Stopwatch 사용
                If Me.m_objStopWatchStageAAlignmentResponsed.IsRunning Then
                    Me.m_objStopWatchStageAAlignmentResponsed.Stop()
                    Me.m_objStopWatchStageAAlignmentResponsed.Reset()
                End If
                Me.m_objStopWatchStageAAlignmentResponsed.Start()
            Else
                If EResult = DualScriber.ERESULT.OK Then
                    Me.m_BOutStageBAlignOK = True
                ElseIf EResult = DualScriber.ERESULT.RETRY Then
                    Me.m_BOutStageBAlignRetry = True
                ElseIf EResult = DualScriber.ERESULT.NG Then
                    If EView = DualScriber.EVIEW.LEFT Then
                        Me.m_BOutStageBAlignLeftNG = True
                    ElseIf EView = DualScriber.EVIEW.RIGHT Then
                        Me.m_BOutStageBAlignRightNG = True
                    End If
                End If

                Me.m_BOutStageBBusy = False
                ' jht ticks 사용하지 않고 Stopwatch 사용
                If Me.m_objStopWatchStageBAlignmentResponsed.IsRunning Then
                    Me.m_objStopWatchStageBAlignmentResponsed.Stop()
                    Me.m_objStopWatchStageBAlignmentResponsed.Reset()
                End If
                Me.m_objStopWatchStageBAlignmentResponsed.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub SendEdgeResult(ByVal EStage As ESTAGE, ByVal EResult As ERESULT)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If EStage = DualScriber.ESTAGE.A Then
                If EResult = DualScriber.ERESULT.OK Then
                    Me.m_BOutStageAEdgeOK = True
                ElseIf EResult = DualScriber.ERESULT.NG Then
                    Me.m_BOutStageAEdgeNG = True
                End If

                Me.m_BOutStageABusy = False
                ' jht ticks 사용하지 않고 Stopwatch 사용
                If Me.m_objStopWatchStageAEdgeResponsed.IsRunning Then
                    Me.m_objStopWatchStageAEdgeResponsed.Stop()
                    Me.m_objStopWatchStageAEdgeResponsed.Reset()
                End If
                Me.m_objStopWatchStageAEdgeResponsed.Start()
            Else
                If EResult = DualScriber.ERESULT.OK Then
                    Me.m_BOutStageBEdgeOK = True
                ElseIf EResult = DualScriber.ERESULT.NG Then
                    Me.m_BOutStageBEdgeNG = True
                End If

                Me.m_BOutStageBBusy = False
                ' jht ticks 사용하지 않고 Stopwatch 사용
                If Me.m_objStopWatchStageBEdgeResponsed.IsRunning Then
                    Me.m_objStopWatchStageBEdgeResponsed.Stop()
                    Me.m_objStopWatchStageBEdgeResponsed.Reset()
                End If
                Me.m_objStopWatchStageBEdgeResponsed.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


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


    Private Sub OnStageAAlignmentRequested()
        Try
            If Not Me.m_OStageAAlignmentRequested Is Nothing Then
                Me.m_OStageAAlignmentRequested()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageBAlignmentRequested()
        Try
            If Not Me.m_OStageBAlignmentRequested Is Nothing Then
                Me.m_OStageBAlignmentRequested()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStartAEdgeRequested()
        Try
            If Not Me.m_OStartAEdgeRequested Is Nothing Then
                Me.m_OStartAEdgeRequested()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStartBEdgeRequested()
        Try
            If Not Me.m_OStartBEdgeRequested Is Nothing Then
                Me.m_OStartBEdgeRequested()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageAInitalizeRequested()
        Try
            If Not Me.m_OStageAInitalizeRequested Is Nothing Then
                Me.m_OStageAInitalizeRequested()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnStageBInitalizeRequested()
        Try
            If Not Me.m_OStageBInitalizeRequested Is Nothing Then
                Me.m_OStageBInitalizeRequested()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            Me.EndWork()
            Me.Release()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class

#Region "ENUM"
Public Enum EOUTPUT As UShort
    NONE = 0
    STAGEA_READY = 1
    STAGEA_BUSY = 2
    STAGEA_ALIGN_RETRY = 4
    STAGEA_ALIGN_OK = 8
    STAGEA_EDGE_OK = 16
    STAGEA_ALIGN_LEFT_NG = 32
    STAGEA_ALIGN_RIGHT_NG = 64
    STAGEA_EDGE_NG = 128
    STAGEB_READY = 256
    STAGEB_BUSY = 512
    STAGEB_ALIGN_RETRY = 1024
    STAGEB_ALIGN_OK = 2048
    STAGEB_EDGE_OK = 4096
    STAGEB_ALIGN_LEFT_NG = 8192
    STAGEB_ALIGN_RIGHT_NG = 16384
    STAGEB_EDGE_NG = 32768
End Enum


Public Enum EINPUT As UShort
    NONE = 0
    PLC_READY = 1
    STAGEA_ALIGN_START = 2
    STAGEB_ALIGN_START = 4
    STAGEA_EDGE_START = 8
    STAGEB_EDGE_START = 16
    STAGEA_INITIALIZE = 32
    STAGEB_INITIALIZE = 64
End Enum
#End Region

#Region "ENUM"
Public Enum ERESULT As Byte
    NONE = 0
    OK
    NG
    RETRY
End Enum
#End Region
