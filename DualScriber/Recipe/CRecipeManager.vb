Imports System.Data
Imports Jhjo.Common


Public Class CRecipeManager

#Region "SINGLE TON"
    Private Shared Src_It As CRecipeManager = Nothing

    Public Shared ReadOnly Property It() As CRecipeManager
        Get
            Dim OResult As CRecipeManager = Nothing

            Try
                If CRecipeManager.Src_It Is Nothing Then
                    CRecipeManager.Src_It = New CRecipeManager()
                End If

                OResult = CRecipeManager.Src_It
            Catch ex As Exception
                CError.throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "VARIABLE"
    Private m_LstORecipe As List(Of CRecipe) = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property LstORecipe() As List(Of CRecipe)
        Get
            Return Me.m_LstORecipe
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
        Try
            Me.m_LstORecipe = New List(Of CRecipe)()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Sub Load()
        Try
            Me.LoadRecipeList()
            Me.LoadRecipeInfo()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub LoadRecipeList()
        Try
            Dim ODataSource As DataTable = CDB.It(CDB.TABLE_RECIPE_LIST).Select()

            Dim I32ID As Integer = 0
            Dim StrName As String = 0
            For Each _Item As DataRow In ODataSource.Rows
                I32ID = CType(_Item(CDB.RECIPE_LIST_ID), Integer)
                StrName = CType(_Item(CDB.RECIPE_LIST_NAME), String)
                Me.m_LstORecipe.Add(New CRecipe(I32ID, StrName))
            Next

            If Not ODataSource Is Nothing Then
                ODataSource.Dispose()
                ODataSource = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub LoadRecipeInfo()
        Try
            Dim ODataSource As DataTable = CDB.It(CDB.TABLE_RECIPE_INFO).Select()

            For Each _Item1 As DataRow In ODataSource.Rows
                For Each _Item2 As CRecipe In Me.m_LstORecipe
                    If Not CType(_Item1(CDB.RECIPE_INFO_ID), Integer) = _Item2.I32ID Then Continue For

                    If CType(_Item1(CDB.RECIPE_INFO_STAGE), String) = ESTAGE.A.ToString() Then
                        _Item2.OStageA.F64AlignmentLeftXLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT), Double)
                        _Item2.OStageA.F64AlignmentRightXLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT), Double)
                        _Item2.OStageA.F64AlignmentYLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT), Double)
                        _Item2.OStageA.F64AlignmentTLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT), Double)
                        _Item2.OStageA.F64EdgeLeftTopMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN), Double)
                        _Item2.OStageA.F64EdgeLeftTopMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX), Double)
                        _Item2.OStageA.F64EdgeLeftBottomMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN), Double)
                        _Item2.OStageA.F64EdgeLeftBottomMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX), Double)
                        _Item2.OStageA.F64EdgeRightTopMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN), Double)
                        _Item2.OStageA.F64EdgeRightTopMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX), Double)
                        _Item2.OStageA.F64EdgeRightBottomMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN), Double)
                        _Item2.OStageA.F64EdgeRightBottomMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX), Double)
                    ElseIf CType(_Item1(CDB.RECIPE_INFO_STAGE), String) = ESTAGE.B.ToString() Then
                        _Item2.OStageB.F64AlignmentLeftXLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT), Double)
                        _Item2.OStageB.F64AlignmentRightXLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT), Double)
                        _Item2.OStageB.F64AlignmentYLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT), Double)
                        _Item2.OStageB.F64AlignmentTLimit = CType(_Item1(CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT), Double)
                        _Item2.OStageB.F64EdgeLeftTopMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN), Double)
                        _Item2.OStageB.F64EdgeLeftTopMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX), Double)
                        _Item2.OStageB.F64EdgeLeftBottomMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN), Double)
                        _Item2.OStageB.F64EdgeLeftBottomMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX), Double)
                        _Item2.OStageB.F64EdgeRightTopMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN), Double)
                        _Item2.OStageB.F64EdgeRightTopMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX), Double)
                        _Item2.OStageB.F64EdgeRightBottomMin = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN), Double)
                        _Item2.OStageB.F64EdgeRightBottomMax = CType(_Item1(CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX), Double)
                    End If

                    Exit For
                Next
            Next

            If Not ODataSource Is Nothing Then
                ODataSource.Dispose()
                ODataSource = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
