Imports Jhjo.Common


Public Class CEnvironment

#Region "SINGLE TON"
    Private Shared Src_It As CEnvironment = Nothing

    Public Shared ReadOnly Property It() As CEnvironment
        Get
            Dim OResult As CEnvironment = Nothing

            Try
                If CEnvironment.Src_It Is Nothing Then
                    CEnvironment.Src_It = New CEnvironment()
                End If

                OResult = CEnvironment.Src_It
            Catch ex As Exception
                CError.Throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "CONST"
    ' 카메라 스팩이 달라서 값 바뀜 0.00375D->0.003214
    Public Const LEN_PER_PIXEL As Double = 0.003214
    Public Const RECIPE_IMAGE_DIR As String = ".\RECIPE\IMAGE"
    Public Const RECIPE_IMAGE_FILE As String = ".\RECIPE\IMAGE\{2}_STAGE{0}_{1}.bmp"

    Private Const STAGE_A_SECTION_XY As String = "STAGE_A_SECTION_XY"
    Private Const STAGE_A_POINT_XY As String = "STAGE_A_POINT_XY"
    Private Const STAGE_A_SECTION_T As String = "STAGE_A_SECTION_T"
    Private Const STAGE_A_POINT_T As String = "STAGE_A_POINT_T"
    Private Const STAGE_B_SECTION_XY As String = "STAGE_B_SECTION_XY"
    Private Const STAGE_B_POINT_XY As String = "STAGE_B_POINT_XY"
    Private Const STAGE_B_SECTION_T As String = "STAGE_B_SECTION_T"
    Private Const STAGE_B_POINT_T As String = "STAGE_B_POINT_T"
    Private Const ROI_KIND_A_LEFT As String = "ROI_KIND_A_LEFT"
    Private Const ROI_REAL_WIDTH_A_LEFT As String = "ROI_REAL_WIDTH_A_LEFT"
    Private Const ROI_REAL_HEIGHT_A_LEFT As String = "ROI_REAL_HEIGHT_A_LEFT"
    Private Const ROI_X_A_LEFT As String = "ROI_X_A_LEFT"
    Private Const ROI_Y_A_LEFT As String = "ROI_Y_A_LEFT"
    Private Const ROI_WIDTH_A_LEFT As String = "ROI_WIDTH_A_LEFT"
    Private Const ROI_HEIGHT_A_LEFT As String = "ROI_HEIGHT_A_LEFT"
    Private Const ROI_KIND_A_RIGHT As String = "ROI_KIND_A_RIGHT"
    Private Const ROI_REAL_WIDTH_A_RIGHT As String = "ROI_REAL_WIDTH_A_RIGHT"
    Private Const ROI_REAL_HEIGHT_A_RIGHT As String = "ROI_REAL_HEIGHT_A_RIGHT"
    Private Const ROI_X_A_RIGHT As String = "ROI_X_A_RIGHT"
    Private Const ROI_Y_A_RIGHT As String = "ROI_Y_A_RIGHT"
    Private Const ROI_WIDTH_A_RIGHT As String = "ROI_WIDTH_A_RIGHT"
    Private Const ROI_HEIGHT_A_RIGHT As String = "ROI_HEIGHT_A_RIGHT"
    Private Const ROI_KIND_B_LEFT As String = "ROI_KIND_B_LEFT"
    Private Const ROI_REAL_WIDTH_B_LEFT As String = "ROI_REAL_WIDTH_B_LEFT"
    Private Const ROI_REAL_HEIGHT_B_LEFT As String = "ROI_REAL_HEIGHT_B_LEFT"
    Private Const ROI_X_B_LEFT As String = "ROI_X_B_LEFT"
    Private Const ROI_Y_B_LEFT As String = "ROI_Y_B_LEFT"
    Private Const ROI_WIDTH_B_LEFT As String = "ROI_WIDTH_B_LEFT"
    Private Const ROI_HEIGHT_B_LEFT As String = "ROI_HEIGHT_B_LEFT"
    Private Const ROI_KIND_B_RIGHT As String = "ROI_KIND_B_RIGHT"
    Private Const ROI_REAL_WIDTH_B_RIGHT As String = "ROI_REAL_WIDTH_B_RIGHT"
    Private Const ROI_REAL_HEIGHT_B_RIGHT As String = "ROI_REAL_HEIGHT_B_RIGHT"
    Private Const ROI_X_B_RIGHT As String = "ROI_X_B_RIGHT"
    Private Const ROI_Y_B_RIGHT As String = "ROI_Y_B_RIGHT"
    Private Const ROI_WIDTH_B_RIGHT As String = "ROI_WIDTH_B_RIGHT"
    Private Const ROI_HEIGHT_B_RIGHT As String = "ROI_HEIGHT_B_RIGHT"
    ' jht Max Retry & Day & Gain & Exposure Time & Simulation Mode
    Private Const MAX_RETRY As String = "MAX_RETRY"
    Private Const DATA_DAYS_TO_KEEP As String = "DATA_DAYS_TO_KEEP"
    Private Const CAM1_GAIN As String = "CAM1_GAIN"
    Private Const CAM1_EXPOSURE As String = "CAM1_EXPOSURE"
    Private Const CAM2_GAIN As String = "CAM2_GAIN"
    Private Const CAM2_EXPOSURE As String = "CAM2_EXPOSURE"
    Private Const CAM3_GAIN As String = "CAM3_GAIN"
    Private Const CAM3_EXPOSURE As String = "CAM3_EXPOSURE"
    Private Const CAM4_GAIN As String = "CAM4_GAIN"
    Private Const CAM4_EXPOSURE As String = "CAM4_EXPOSURE"
    Private Const SIMULATION_MODE As String = "SIMULATION_MODE"


    Private Const MIN_DISTANCE_X As String = "MIN_DISTANCE_X"
    Private Const MIN_DISTANCE_Y As String = "MIN_DISTANCE_Y"
#End Region


#Region "PROPERTIES"
    ' jht Max Retry & Day & Gain & Exposure Time & Simulation Mode
    Public Property MaxRetry() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(MAX_RETRY))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(MAX_RETRY, value)
        End Set
    End Property

    Public Property DateToKeep_Days() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(DATA_DAYS_TO_KEEP))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(DATA_DAYS_TO_KEEP, value)
        End Set
    End Property

    Public Property Cam1Gain() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM1_GAIN))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM1_GAIN, value)
        End Set
    End Property

    Public Property Cam1Exp() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM1_EXPOSURE))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM1_EXPOSURE, value)
        End Set
    End Property

    Public Property Cam2Gain() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM2_GAIN))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM2_GAIN, value)
        End Set
    End Property

    Public Property Cam2Exp() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM2_EXPOSURE))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM2_EXPOSURE, value)
        End Set
    End Property

    Public Property Cam3Gain() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM3_GAIN))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM3_GAIN, value)
        End Set
    End Property

    Public Property Cam3Exp() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM3_EXPOSURE))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM3_EXPOSURE, value)
        End Set
    End Property
    Public Property Cam4Gain() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM4_GAIN))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM4_GAIN, value)
        End Set
    End Property

    Public Property Cam4Exp() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(CAM4_EXPOSURE))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(CAM4_EXPOSURE, value)
        End Set
    End Property

    Public Property MinDistanceX() As Double
        Get
            Return Convert.ToDouble(Me.GetData(MIN_DISTANCE_X))
        End Get
        Set(value As Double)
            Me.SetData(SIMULATION_MODE, value)
        End Set
    End Property

    Public Property MinDistanceY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(MIN_DISTANCE_Y))
        End Get
        Set(value As Double)
            Me.SetData(SIMULATION_MODE, value)
        End Set
    End Property


    Public Property SimulationMode() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(SIMULATION_MODE))
        End Get
        Set(value As Integer)
            Me.SetData(SIMULATION_MODE, value)
        End Set
    End Property

#Region "CALIBRATION"
    Public Property F64ASectionXY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(STAGE_A_SECTION_XY))
        End Get
        Set(ByVal value As Double)
            Me.SetData(STAGE_A_POINT_XY, value)
        End Set
    End Property


    Public Property I32APointXY() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(STAGE_A_POINT_XY))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(STAGE_A_POINT_XY, value)
        End Set
    End Property


    Public Property F64ASectionT() As Double
        Get
            Return Convert.ToDouble(Me.GetData(STAGE_A_SECTION_T))
        End Get
        Set(ByVal value As Double)
            Me.SetData(STAGE_A_SECTION_T, value)
        End Set
    End Property


    Public Property I32APointT() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(STAGE_A_POINT_T))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(STAGE_A_POINT_T, value)
        End Set
    End Property


    Public Property F64BSectionXY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(STAGE_B_SECTION_XY))
        End Get
        Set(ByVal value As Double)
            Me.SetData(STAGE_B_SECTION_XY, value)
        End Set
    End Property


    Public Property I32BPointXY() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(STAGE_B_POINT_XY))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(STAGE_B_POINT_XY, value)
        End Set
    End Property


    Public Property F64BSectionT() As Double
        Get
            Return Convert.ToDouble(Me.GetData(STAGE_B_SECTION_T))
        End Get
        Set(ByVal value As Double)
            Me.SetData(STAGE_B_SECTION_T, value)
        End Set
    End Property


    Public Property I32BPointT() As Integer
        Get
            Return Convert.ToInt32(Me.GetData(STAGE_B_POINT_T))
        End Get
        Set(ByVal value As Integer)
            Me.SetData(STAGE_B_POINT_T, value)
        End Set
    End Property
#End Region


#Region "ALIGNMENT ROI"
#Region "A LEFT ROI"
    Public Property StrALeftROIKind() As String
        Get
            Return Me.GetData(ROI_KIND_A_LEFT)
        End Get
        Set(ByVal value As String)
            Me.SetData(ROI_KIND_A_LEFT, value)
        End Set
    End Property


    Public Property F64ALeftROIRealWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_WIDTH_A_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_WIDTH_A_LEFT, value)
        End Set
    End Property


    Public Property F64ALeftROIRealHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_HEIGHT_A_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_HEIGHT_A_LEFT, value)
        End Set
    End Property


    Public Property F64ALeftROIX() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_X_A_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_X_A_LEFT, value)
        End Set
    End Property


    Public Property F64ALeftROIY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_Y_A_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_Y_A_LEFT, value)
        End Set
    End Property


    Public Property F64ALeftROIWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_WIDTH_A_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_WIDTH_A_LEFT, value)
        End Set
    End Property


    Public Property F64ALeftROIHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_HEIGHT_A_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_HEIGHT_A_LEFT, value)
        End Set
    End Property
#End Region


#Region "A RIGHT ROI"
    Public Property StrARightROIKind() As String
        Get
            Return Me.GetData(ROI_KIND_A_RIGHT)
        End Get
        Set(ByVal value As String)
            Me.SetData(ROI_KIND_A_RIGHT, value)
        End Set
    End Property


    Public Property F64ARightROIRealWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_WIDTH_A_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_WIDTH_A_RIGHT, value)
        End Set
    End Property


    Public Property F64ARightROIRealHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_HEIGHT_A_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_HEIGHT_A_RIGHT, value)
        End Set
    End Property


    Public Property F64ARightROIX() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_X_A_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_X_A_RIGHT, value)
        End Set
    End Property


    Public Property F64ARightROIY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_Y_A_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_Y_A_RIGHT, value)
        End Set
    End Property


    Public Property F64ARightROIWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_WIDTH_A_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_WIDTH_A_RIGHT, value)
        End Set
    End Property


    Public Property F64ARightROIHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_HEIGHT_A_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_HEIGHT_A_RIGHT, value)
        End Set
    End Property
#End Region


#Region "B LEFT ROI"
    Public Property StrBLeftROIKind() As String
        Get
            Return Me.GetData(ROI_KIND_B_LEFT)
        End Get
        Set(ByVal value As String)
            Me.SetData(ROI_KIND_B_LEFT, value)
        End Set
    End Property


    Public Property F64BLeftROIRealWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_WIDTH_B_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_WIDTH_B_LEFT, value)
        End Set
    End Property


    Public Property F64BLeftROIRealHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_HEIGHT_B_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_HEIGHT_B_LEFT, value)
        End Set
    End Property


    Public Property F64BLeftROIX() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_X_B_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_X_B_LEFT, value)
        End Set
    End Property


    Public Property F64BLeftROIY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_Y_B_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_Y_B_LEFT, value)
        End Set
    End Property


    Public Property F64BLeftROIWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_WIDTH_B_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_WIDTH_B_LEFT, value)
        End Set
    End Property


    Public Property F64BLeftROIHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_HEIGHT_B_LEFT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_HEIGHT_B_LEFT, value)
        End Set
    End Property
#End Region


#Region "B RIGHT ROI"
    Public Property StrBRightROIKind() As String
        Get
            Return Me.GetData(ROI_KIND_B_RIGHT)
        End Get
        Set(ByVal value As String)
            Me.SetData(ROI_KIND_B_RIGHT, value)
        End Set
    End Property


    Public Property F64BRightROIRealWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_WIDTH_B_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_WIDTH_B_RIGHT, value)
        End Set
    End Property


    Public Property F64BRightROIRealHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_REAL_HEIGHT_B_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_REAL_HEIGHT_B_RIGHT, value)
        End Set
    End Property


    Public Property F64BRightROIX() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_X_B_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_X_B_RIGHT, value)
        End Set
    End Property


    Public Property F64BRightROIY() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_Y_B_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_Y_B_RIGHT, value)
        End Set
    End Property


    Public Property F64BRightROIWidth() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_WIDTH_B_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_WIDTH_B_RIGHT, value)
        End Set
    End Property


    Public Property F64BRightROIHeight() As Double
        Get
            Return Convert.ToDouble(Me.GetData(ROI_HEIGHT_B_RIGHT))
        End Get
        Set(ByVal value As Double)
            Me.SetData(ROI_HEIGHT_B_RIGHT, value)
        End Set
    End Property
#End Region
#End Region
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
    End Sub
#End Region


#Region "FUNCTION"
    Private Function GetData(ByVal StrName As String) As String
        Dim StrResult As String = Nothing

        Try
            Dim I32RowIndex As Integer = CDB.It(CDB.TABLE_ENVIRONMENT).SelectRowIndex(CDB.ENVIRONMENT_NAME, StrName)
            Dim OValue As Object = CDB.It(CDB.TABLE_ENVIRONMENT).Select(I32RowIndex, CDB.ENVIRONMENT_VALUE)

            If Not OValue Is Nothing Then
                StrResult = CType(OValue, String)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try

        Return StrResult
    End Function


    Private Sub SetData(ByVal StrName As String, ByVal OValue As Object)
        Try
            Dim I32RowIndex As Integer = CDB.It(CDB.TABLE_ENVIRONMENT).SelectRowIndex(CDB.ENVIRONMENT_NAME, StrName)
            CDB.It(CDB.TABLE_ENVIRONMENT).Update(I32RowIndex, CDB.ENVIRONMENT_VALUE, OValue.ToString())
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Commit()
        Try
            CDB.It(CDB.TABLE_ENVIRONMENT).Commit()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
