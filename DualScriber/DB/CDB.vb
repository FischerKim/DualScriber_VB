Imports Jhjo.Common
Imports Jhjo.DB
Imports Daekhon.Common

Public Class CDB
    Inherits ADB


#Region "SINGLE TON"
    Private Shared Src_It As CDB = Nothing

    Public Shared ReadOnly Property It() As CDB
        Get
            Dim OResult As CDB = Nothing

            Try
                If CDB.Src_It Is Nothing Then
                    CDB.Src_It = New CDB()
                End If

                OResult = CDB.Src_It
            Catch ex As Exception
                CError.Throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "CONST"
    Public Const TABLE_ENVIRONMENT As String = "ENVIRONMENT"
    Public Const ENVIRONMENT_NAME As String = "NAME"
    Public Const ENVIRONMENT_VALUE As String = "VALUE"

    Public Const TABLE_RECIPE_LIST As String = "RECIPE_LIST"
    Public Const RECIPE_LIST_ID As String = "ID"
    Public Const RECIPE_LIST_NAME As String = "NAME"

    Public Const TABLE_RECIPE_INFO As String = "RECIPE_INFO"
    Public Const RECIPE_INFO_ID As String = "ID"
    Public Const RECIPE_INFO_RECIPE As String = "RECIPE"
    Public Const RECIPE_INFO_STAGE As String = "STAGE"
    Public Const RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT As String = "ALIGNMENT_LEFTX_LIMIT"
    Public Const RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT As String = "ALIGNMENT_RIGHTX_LIMIT"
    Public Const RECIPE_INFO_ALIGNMENT_Y_LIMIT As String = "ALIGNMENT_Y_LIMIT"
    Public Const RECIPE_INFO_ALIGNMENT_T_LIMIT As String = "ALIGNMENT_T_LIMIT"
    Public Const RECIPE_INFO_EDGE_LEFT_TOP_MIN As String = "EDGE_LEFT_TOP_MIN"
    Public Const RECIPE_INFO_EDGE_LEFT_TOP_MAX As String = "EDGE_LEFT_TOP_MAX"
    Public Const RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN As String = "EDGE_LEFT_BOTTOM_MIN"
    Public Const RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX As String = "EDGE_LEFT_BOTTOM_MAX"
    Public Const RECIPE_INFO_EDGE_RIGHT_TOP_MIN As String = "EDGE_RIGHT_TOP_MIN"
    Public Const RECIPE_INFO_EDGE_RIGHT_TOP_MAX As String = "EDGE_RIGHT_TOP_MAX"
    Public Const RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN As String = "EDGE_RIGHT_BOTTOM_MIN"
    Public Const RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX As String = "EDGE_RIGHT_BOTTOM_MAX"

    Public Const TABLE_CALIBRATION_LIST As String = "CALIBRATION_LIST"
    Public Const CALIBRATION_LIST_STAGE As String = "STAGE"
    Public Const CALIBRATION_LIST_CALIBRATED As String = "CALIBRATED"
    Public Const CALIBRATION_LIST_CALIBRATION_X As String = "CALIBRATION_X"
    Public Const CALIBRATION_LIST_CALIBRATION_Y As String = "CALIBRATION_Y"
    Public Const CALIBRATION_LIST_EQUIP_LEFT_X As String = "EQUIP_LEFT_X"
    Public Const CALIBRATION_LIST_EQUIP_RIGHT_X As String = "EQUIP_RIGHT_X"
    Public Const CALIBRATION_LIST_EQUIP_Y As String = "EQUIP_Y"

    Public Const TABLE_CALIBRATION_INFO As String = "CALIBRATION_INFO"
    Public Const CALIBRATION_INFO_STAGE As String = "STAGE"
    Public Const CALIBRATION_INFO_LEFT_X As String = "LEFT_X"
    Public Const CALIBRATION_INFO_LEFT_Y As String = "LEFT_Y"
    Public Const CALIBRATION_INFO_RIGHT_X As String = "RIGHT_X"
    Public Const CALIBRATION_INFO_RIGHT_Y As String = "RIGHT_Y"

    Public Const TABLE_REPORT As String = "REPORT"
    Public Const REPORT_DATETIME As String = "DATETIME"
    Public Const REPORT_RECIPE As String = "RECIPE"
    Public Const REPORT_STAGE As String = "STAGE"
    Public Const REPORT_RESULT As String = "RESULT"
    Public Const REPORT_ALIGNMENT_VIEW_LEFT_X As String = "ALIGNMENT_VIEW_LEFT_X"
    Public Const REPORT_ALIGNMENT_VIEW_LEFT_Y As String = "ALIGNMENT_VIEW_LEFT_Y"
    Public Const REPORT_ALIGNMENT_VIEW_RIGHT_X As String = "ALIGNMENT_VIEW_RIGHT_X"
    Public Const REPORT_ALIGNMENT_VIEW_RIGHT_Y As String = "ALIGNMENT_VIEW_RIGHT_Y"
    Public Const REPORT_ALIGNMENT_EQUIP_LEFT_X As String = "ALIGNMENT_EQUIP_LEFT_X"
    Public Const REPORT_ALIGNMENT_EQUIP_RIGHT_X As String = "ALIGNMENT_EQUIP_RIGHT_X"
    Public Const REPORT_ALIGNMENT_EQUIP_Y As String = "ALIGNMENT_EQUIP_Y"
    Public Const REPORT_ALIGNMENT_EQUIP_T As String = "ALIGNMENT_EQUIP_T"
    Public Const REPORT_ALIGNMENT_NUM_OF_RETRY As String = "RETRY"
    Public Const REPORT_ALIGNMENT_TIME_ELAPSED As String = "TIME_ELAPSED"
    Public Const REPORT_LEFT_FILE As String = "LEFT_FILE"
    Public Const REPORT_RIGHT_FILE As String = "RIGHT_FILE"
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
    End Sub
#End Region


#Region "FUNCTION"
    Public Overrides Function Load() As Boolean
        Dim BResult As Boolean = False

        Try
            BResult = MyBase.Load()

            Dim ODeleteInfo As CAutoDeleteInfo = New CAutoDeleteInfo()
            ODeleteInfo.BEnabled = True
            ODeleteInfo.ETimeUnit = ETIME_UNIT.DAY
            ODeleteInfo.I32KeepPeriod = CEnvironment.It.DateToKeep_Days
            CDB.It.SetAutoDelete(CDB.TABLE_REPORT, ODeleteInfo)
        Catch ex As Exception
            CError.Throw(ex)
        End Try

        Return BResult
    End Function


    Protected Overrides Sub InitDB()
    End Sub
#End Region

End Class
