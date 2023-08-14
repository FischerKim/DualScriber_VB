Imports Cognex.VisionPro
Imports Jhjo.Common


Public Class CCalibrationTool

#Region "VARIABLE"
    Private m_BCalibrated As Boolean = False
    Private m_OImage As CogImage8Grey = Nothing
    Private m_F64CalibrationX As Double = 0
    Private m_F64CalibrationY As Double = 0
    Private m_F64EquipLeftX As Double = 0
    Private m_F64EquipRightX As Double = 0
    Private m_F64EquipY As Double = 0

    Private m_LstF64LeftX As List(Of Double) = Nothing
    Private m_LstF64LeftY As List(Of Double) = Nothing
    Private m_LstF64RightX As List(Of Double) = Nothing
    Private m_LstF64RightY As List(Of Double) = Nothing
#End Region


#Region "PROPERTIES"
    Public Property BCalibrated() As Boolean
        Get
            Return Me.m_BCalibrated
        End Get
        Set(ByVal value As Boolean)
            Me.m_BCalibrated = value
        End Set
    End Property


    Public Property OImage() As CogImage8Grey
        Get
            Return Me.m_OImage
        End Get
        Set(ByVal value As CogImage8Grey)
            Me.m_OImage = value
        End Set
    End Property


    Public Property F64CalibrationX() As Double
        Get
            Return Me.m_F64CalibrationX
        End Get
        Set(ByVal value As Double)
            Me.m_F64CalibrationX = value
        End Set
    End Property


    Public Property F64CalibrationY() As Double
        Get
            Return Me.m_F64CalibrationY
        End Get
        Set(ByVal value As Double)
            Me.m_F64CalibrationY = value
        End Set
    End Property


    Public Property F64EquipLeftX() As Double
        Get
            Return Me.m_F64EquipLeftX
        End Get
        Set(ByVal value As Double)
            Me.m_F64EquipLeftX = value
        End Set
    End Property


    Public Property F64EquipRightX() As Double
        Get
            Return Me.m_F64EquipRightX
        End Get
        Set(ByVal value As Double)
            Me.m_F64EquipRightX = value
        End Set
    End Property


    Public Property F64EquipY() As Double
        Get
            Return Me.m_F64EquipY
        End Get
        Set(ByVal value As Double)
            Me.m_F64EquipY = value
        End Set
    End Property


    Public ReadOnly Property LstF64LeftX() As List(Of Double)
        Get
            Return Me.m_LstF64LeftX
        End Get
    End Property


    Public ReadOnly Property LstF64LeftY() As List(Of Double)
        Get
            Return Me.m_LstF64LeftY
        End Get
    End Property


    Public ReadOnly Property LstF64RightX() As List(Of Double)
        Get
            Return Me.m_LstF64RightX
        End Get
    End Property


    Public ReadOnly Property LstF64RightY() As List(Of Double)
        Get
            Return Me.m_LstF64RightY
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        Try
            Me.m_LstF64LeftX = New List(Of Double)()
            Me.m_LstF64LeftY = New List(Of Double)()
            Me.m_LstF64RightX = New List(Of Double)()
            Me.m_LstF64RightY = New List(Of Double)()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Function DoCalibration() As Boolean
        Dim BResult As Boolean = False

        Try
            Dim OTool As CogFitCircleTool = New CogFitCircleTool()

            OTool.InputImage = Me.m_OImage
            OTool.RunParams.NumPoints = Me.m_LstF64LeftX.Count
            For _Index As Integer = 0 To Me.m_LstF64LeftX.Count - 1 Step 1
                OTool.RunParams.SetPoint(_Index, Me.m_LstF64LeftX(_Index), Me.m_LstF64LeftY(_Index))
            Next
            OTool.Run()

            If Not OTool.Result Is Nothing Then
                Dim OCircle As CogCircle = OTool.Result.GetCircle()

                If Not OCircle Is Nothing Then
                    Me.m_F64CalibrationX = Math.Round((Me.m_LstF64LeftX(0) - OCircle.CenterX) * CEnvironment.LEN_PER_PIXEL, 4)
                    Me.m_F64CalibrationY = Math.Round((OCircle.CenterY - Me.m_LstF64LeftY(0)) * CEnvironment.LEN_PER_PIXEL, 4)
                    Me.m_BCalibrated = True

                    BResult = True
                End If
            End If

            If Not OTool Is Nothing Then
                OTool.Dispose()
                OTool = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try

        Return BResult
    End Function


    Public Function DoAlignment(ByVal F64ImageCenterX As Double, ByVal F64ImageCenterY As Double, _
                                ByVal F64LeftX As Double, ByVal F64LeftY As Double, ByVal F64RightX As Double, ByVal F64RightY As Double, _
                                ByVal F64CurrentEquipLeftX As Double, ByVal F64CurrentEquipRightX As Double, ByVal F64CurrentEquipY As Double, ByVal F64CurrentDistanceBetweenCam As Double, _
                                ByVal F64CalibEquipLeftX As Double, ByVal F64CalibEquipRightX As Double, ByVal F64CalibEquipY As Double, _
                                ByVal F64CalibWidth As Double, ByVal F64CalibHeight As Double, _
                                ByRef F64ResultY As Double, ByRef F64ResultT As Double, ByRef F64ResultX1 As Double, ByRef F64ResultX2 As Double) As Boolean

        'X1 : 패턴1의X
        'Y1 : 패턴1의Y
        'X2 : 패턴2의X
        'Y2 : 패턴2의Y
        'H1 : HEAD1의 X위치
        'H2 : HEAD2의 X위치
        'Ystage : Y축의 위치
        'OH1 : 캘때의 HEAD1위치
        'OH2 : 캘때의 HEAD2위치
        'OYs : 캘때의 Y위치
        'Ox : Head1 로부터의 회전중심 X 
        'Oy : Head1 로부터의 회전중시 Y
        'Xoffset : x보정치
        'Yoffset : y보정치
        'Toffset : t보정치
        'CamDis : 카메라거리

        '2point align 계산 파라메터
        'XYDataUpdated(0) = False
        'XYDataUpdated(1) = False
        'XYDataUpdated(2) = False
        'XYDataUpdated(3) = False

        Dim Xs_Gap, Ys_Gap As Double

        Dim x(4), y(4) As Double
        ' ResofTheta As Double = 1820.4444
        Dim Rad2Deg As Double = (180 / Math.PI)
        Dim scale2 As Double
        scale2 = 0.001875

        'Dim ResofLinear As Double = 2000
        Dim Rx(4), Ry(4) As Double
        '각도값 (degree)
        Dim DTangent As Double
        '각도값 (Radian)
        Dim RTangent As Double

        '실제 치수로(mm) 환산된 단위계 사용





        '로깅처리
        'Invoke(Go_SystemProcess, New Object() {"패턴비전좌표정보 " & _
        '                                        Math.Round(PMToolFind(4).Results.Item(0).GetPose.TranslationX, 3).ToString & " " & _
        '                                        Math.Round(PMToolFind(4).Results.Item(0).GetPose.TranslationY, 3).ToString & " " & _
        '                                        Math.Round(PMToolFind(5).Results.Item(0).GetPose.TranslationX, 3).ToString & " " & _
        '                                        Math.Round(PMToolFind(5).Results.Item(0).GetPose.TranslationY, 3).ToString})
        Try

            Debug.Print("3 " & Math.Round(F64LeftX, 1) & " " & Math.Round(F64LeftY, 1) & " " & Math.Round(F64RightX, 1) & " " & Math.Round(F64RightY, 1))

        Catch ex As Exception
            Return False
            Exit Function
        End Try




        x(0) = F64LeftX * scale2
        y(0) = F64LeftY * scale2
        x(1) = F64RightX * scale2
        y(1) = F64RightY * scale2




        '패턴의 x위치값 기억
        Dim PattenX(4), PattenY As Double
        PattenX(0) = x(0)
        PattenX(1) = x(1)
        PattenX(2) = x(2)
        PattenX(3) = x(3)
        PattenY = y(0)

        '모션으로부터 현재 두 X축의 현 위치 값을 가지고 올것
        ' Xs_Gap = 577 + ((X1 - X2) * scale2) 'Math.Abs(H1 - H2)
        Xs_Gap = F64CurrentDistanceBetweenCam + ((F64LeftX - F64RightX) * scale2) 'Math.Abs(H1 - H2)
        '130827
        'Xs_Gap = Math.Abs(StageXPos(RealCamIndex(0)) - StageXPos(RealCamIndex(3)))
        Ys_Gap = y(0) - y(1)

        'x1-x4의 축간의 거리
        'Xs_Gap = Xs_Gap - 1296 * scale2  '화면 center 값 만큼 빼주고 mm로환산하기 위해서 1296을 scale2로 곱함
        'x4 = x4 + Xs_Gap



        'Xgap = (x4 - x1) 'x축 →+방향일경우
        'Ygap = (y4 - y1) 'y축 ↑+방향일경우
        DTangent = Math.Atan(Ys_Gap / Xs_Gap) ' 레디안
        'DTangent = 0
        '각도계산부 끝

        Dim XCenter(4) As Double
        '각 카메라의 좌표공간상의 위치(mm)
        XCenter(0) = (F64CalibEquipLeftX - F64CurrentEquipLeftX) + F64CalibWidth
        XCenter(1) = (F64CurrentDistanceBetweenCam) + F64CalibWidth  '추후 580을 카메라간 거리고 입력 할것


        '--------------------------------------------------------------------------------
        '1번 화면의 X Y 위치 계산



        '1:      번head()
        'x(0) = PMToolFind(0).Results.Item(0).GetPose.TranslationX * scale2
        x(0) = x(0) - (F64ImageCenterX * scale2)
        x(0) = XCenter(0) + x(0)

        'y(0) = PMToolFind(0).Results.Item(0).GetPose.TranslationY * scale2
        y(0) = F64ImageCenterY * scale2 - y(0)
        y(0) = (F64CalibEquipY - F64CurrentEquipY) + F64CalibHeight + y(0)


        '2번head
        'x(1) = PMToolFind(1).Results.Item(0).GetPose.TranslationX * scale2
        x(1) = x(1) - (F64ImageCenterX * scale2)
        x(1) = XCenter(1) + x(1)


        Dim R(4) As Double
        Dim dbDis(4) As Double
        '찾은 왼쪽 좌표의 이동후 X Y 위치 계산
        Dim Xs(4), Ys As Double

        '찾은 왼쪽 좌표의 이동후 X Y 위치에서의 OFFSET
        Dim Xshift(4), Yshift As Double

        '각 좌표의 반지름거리 및 각도R 계산(계산은 rad)
        dbDis(0) = CogMath.DistancePointPoint(0, 0, x(0), y(0), R(0))
        dbDis(1) = CogMath.DistancePointPoint(0, 0, x(1), y(0), R(1))


        '디그리 형으로 변환
        Dim RD(4) As Double
        RD(0) = R(0) * Rad2Deg
        RD(1) = R(1) * Rad2Deg


        '각 이동좌표 구하기
        Xs(0) = dbDis(0) * Math.Cos(R(0) - DTangent)
        Xs(1) = dbDis(1) * Math.Cos(R(1) - DTangent)

        Ys = dbDis(0) * Math.Sin(R(0) - DTangent)


        Xs(0) = Xs(0) - XCenter(0)
        Xs(1) = Xs(1) - XCenter(1)



        Ys = (F64CalibEquipY - F64CurrentEquipY) + F64CalibHeight - Ys
        Yshift = Ys

        'MsgBox("T=" & Math.Round(DTangent * Rad2Deg * nDir, 5).ToString & " Y=" & Yshift.ToString & " X1=" & Xs(0).ToString & " X2=" & Xs(1).ToString & " X3=" & Xs(2).ToString & " X4=" & Xs(3).ToString)


        '1번 화면의 X Y 위치 계산 종료
        '--------------------------------------------------------------------------------

        '텍스트박스 갱신
        'Invoke(Go_TextBoxUpdate, New Object() {Math.Round(Xshift(0), 5).ToString, 1})   'dX값
        'Invoke(Go_TextBoxUpdate, New Object() {Math.Round(Yshift, 5).ToString, 2})   'dY값
        'Invoke(Go_TextBoxUpdate, New Object() {Math.Round(DTangent * Rad2Deg * nDir, 5).ToString, 3}) 'dT값
        'Invoke(Go_TextBoxUpdate, New Object() {Math.Round(dbDis(0), 5).ToString, 6})   'R값


        RTangent = (DTangent * Rad2Deg)



        F64ResultY = Math.Round(Ys, 5) ' Yshift * 10000 ' * nDir   'Y
        F64ResultT = Math.Round(RTangent, 5)          'T
        F64ResultX1 = Math.Round(Xs(0), 4)  'HL
        F64ResultX2 = Math.Round(Xs(1), 4) '* -1 'HR

        If F64ResultY = 0 Then
            F64ResultY = 0.0001
        End If
        If F64ResultT = 0 Then
            F64ResultT = 0.00001
        End If
        If F64ResultX1 = 0 Then
            F64ResultX1 = 0.0001
        End If
        If F64ResultX2 = 0 Then
            F64ResultX2 = -0.0001
        End If '
        Return True
    End Function
#End Region

End Class
