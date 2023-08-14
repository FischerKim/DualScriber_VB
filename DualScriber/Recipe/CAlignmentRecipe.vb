Imports Jhjo.Common

Public Class CAlignmentRecipe
    Implements IDisposable

#Region "VARIABLE"
    Private m_StrName As String = Nothing
    Private m_StrDirectory As String = Nothing

    Private m_EStage As ESTAGE = EStage.NONE
    Private m_OLeft As CAnalysisRecipe = Nothing
    Private m_ORight As CAnalysisRecipe = Nothing

    Private m_F64AlignmentLeftXLimit As Double = 0.008
    Private m_F64AlignmentRightXLimit As Double = 0.008
    Private m_F64AlignmentYLimit As Double = 0.008
    Private m_F64AlignmentTLimit As Double = 0.0005

    Private m_F64EdgeLeftTopMin As Double = 1.96
    Private m_F64EdgeLeftTopMax As Double = 2.04
    Private m_F64EdgeLeftBottomMin As Double = 1.96
    Private m_F64EdgeLeftBottomMax As Double = 2.04
    Private m_F64EdgeRightTopMin As Double = 1.96
    Private m_F64EdgeRightTopMax As Double = 2.04
    Private m_F64EdgeRightBottomMin As Double = 1.96
    Private m_F64EdgeRightBottomMax As Double = 2.04

#End Region


#Region "PROPERTIES"
    Public ReadOnly Property StrName() As String
        Get
            Return Me.m_StrName
        End Get
    End Property


    Public ReadOnly Property StrDirectory() As String
        Get
            Return Me.m_StrDirectory
        End Get
    End Property


    Public ReadOnly Property EStage() As ESTAGE
        Get
            Return Me.m_EStage
        End Get
    End Property


    Public ReadOnly Property OLeft() As CAnalysisRecipe
        Get
            Return Me.m_OLeft
        End Get
    End Property


    Public ReadOnly Property ORight() As CAnalysisRecipe
        Get
            Return Me.m_ORight
        End Get
    End Property


    Public Property F64AlignmentLeftXLimit() As Double
        Get
            Return Me.m_F64AlignmentLeftXLimit
        End Get
        Set(ByVal value As Double)
            Me.m_F64AlignmentLeftXLimit = value
        End Set
    End Property


    Public Property F64AlignmentRightXLimit() As Double
        Get
            Return Me.m_F64AlignmentRightXLimit
        End Get
        Set(ByVal value As Double)
            Me.m_F64AlignmentRightXLimit = value
        End Set
    End Property


    Public Property F64AlignmentYLimit() As Double
        Get
            Return Me.m_F64AlignmentYLimit
        End Get
        Set(ByVal value As Double)
            Me.m_F64AlignmentYLimit = value
        End Set
    End Property


    Public Property F64AlignmentTLimit() As Double
        Get
            Return Me.m_F64AlignmentTLimit
        End Get
        Set(ByVal value As Double)
            Me.m_F64AlignmentTLimit = value
        End Set
    End Property


    Public Property F64EdgeLeftTopMin() As Double
        Get
            Return Me.m_F64EdgeLeftTopMin
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeLeftTopMin = value
        End Set
    End Property


    Public Property F64EdgeLeftTopMax() As Double
        Get
            Return Me.m_F64EdgeLeftTopMax
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeLeftTopMax = value
        End Set
    End Property


    Public Property F64EdgeLeftBottomMin() As Double
        Get
            Return Me.m_F64EdgeLeftBottomMin
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeLeftBottomMin = value
        End Set
    End Property


    Public Property F64EdgeLeftBottomMax() As Double
        Get
            Return Me.m_F64EdgeLeftBottomMax
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeLeftBottomMax = value
        End Set
    End Property


    Public Property F64EdgeRightTopMin() As Double
        Get
            Return Me.m_F64EdgeRightTopMin
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeRightTopMin = value
        End Set
    End Property


    Public Property F64EdgeRightTopMax() As Double
        Get
            Return Me.m_F64EdgeRightTopMax
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeRightTopMax = value
        End Set
    End Property


    Public Property F64EdgeRightBottomMin() As Double
        Get
            Return Me.m_F64EdgeRightBottomMin
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeRightBottomMin = value
        End Set
    End Property


    Public Property F64EdgeRightBottomMax() As Double
        Get
            Return Me.m_F64EdgeRightBottomMax
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeRightBottomMax = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal StrName As String, ByVal EStage As ESTAGE, ByVal StrDirectory As String)
        Try
            Me.m_StrName = StrName
            Me.m_EStage = EStage
            Me.m_StrDirectory = StrDirectory & "\" & Me.m_EStage.ToString()

            Me.m_OLeft = New CAnalysisRecipe(Me.m_StrName, EVIEW.LEFT, Me.m_StrDirectory)
            Me.m_ORight = New CAnalysisRecipe(Me.m_StrName, EVIEW.RIGHT, Me.m_StrDirectory)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub New(ByVal OSource As CAlignmentRecipe)
        Try
            Me.m_StrName = OSource.m_StrName
            Me.m_EStage = OSource.m_EStage
            Me.m_StrDirectory = OSource.m_StrDirectory

            Me.m_OLeft = New CAnalysisRecipe(OSource.m_OLeft)
            Me.m_ORight = New CAnalysisRecipe(OSource.m_ORight)

            Me.m_F64AlignmentLeftXLimit = OSource.m_F64AlignmentLeftXLimit
            Me.m_F64AlignmentRightXLimit = OSource.m_F64AlignmentRightXLimit
            Me.m_F64AlignmentYLimit = OSource.m_F64AlignmentYLimit
            Me.m_F64AlignmentTLimit = OSource.m_F64AlignmentTLimit

            Me.m_F64EdgeLeftTopMin = OSource.m_F64EdgeLeftTopMin
            Me.m_F64EdgeLeftTopMax = OSource.m_F64EdgeLeftTopMax
            Me.m_F64EdgeLeftBottomMin = OSource.m_F64EdgeLeftBottomMin
            Me.m_F64EdgeLeftBottomMax = OSource.m_F64EdgeLeftBottomMax
            Me.m_F64EdgeRightTopMin = OSource.m_F64EdgeRightTopMin
            Me.m_F64EdgeRightTopMax = OSource.m_F64EdgeRightTopMax
            Me.m_F64EdgeRightBottomMin = OSource.m_F64EdgeRightBottomMin
            Me.m_F64EdgeRightBottomMax = OSource.m_F64EdgeRightBottomMax
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Protected Overrides Sub Finalize()
        Try
            Me.Dispose()
            MyBase.Finalize()
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Sub Create()
        Try
            Me.m_OLeft.Create()
            Me.m_ORight.Create()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Load()
        Try
            Me.m_OLeft.Load()
            Me.m_ORight.Load()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Save()
        Try
            Me.m_OLeft.Save()
            Me.m_ORight.Save()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Copy(ByVal OSource As CAlignmentRecipe)
        Try
            Me.m_F64AlignmentLeftXLimit = OSource.m_F64AlignmentLeftXLimit
            Me.m_F64AlignmentRightXLimit = OSource.m_F64AlignmentRightXLimit
            Me.m_F64AlignmentYLimit = OSource.m_F64AlignmentYLimit
            Me.m_F64AlignmentTLimit = OSource.m_F64AlignmentTLimit

            Me.m_F64EdgeLeftTopMin = OSource.m_F64EdgeLeftTopMin
            Me.m_F64EdgeLeftTopMax = OSource.m_F64EdgeLeftTopMax
            Me.m_F64EdgeLeftBottomMin = OSource.m_F64EdgeLeftBottomMin
            Me.m_F64EdgeLeftBottomMax = OSource.m_F64EdgeLeftBottomMax
            Me.m_F64EdgeRightTopMin = OSource.m_F64EdgeRightTopMin
            Me.m_F64EdgeRightTopMax = OSource.m_F64EdgeRightTopMax
            Me.m_F64EdgeRightBottomMin = OSource.m_F64EdgeRightBottomMin
            Me.m_F64EdgeRightBottomMax = OSource.m_F64EdgeRightBottomMax
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
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

End Class