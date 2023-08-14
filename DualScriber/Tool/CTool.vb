Imports System.Data
Imports System.Threading
Imports Jhjo.Common
Imports Jhjo.Tool

Public Class CTool
    Implements IDisposable

#Region "SINGLE TON"
    Private Shared Src_It As CTool = Nothing

    Public Shared ReadOnly Property It() As CTool
        Get
            Dim OResult As CTool = Nothing

            Try
                If CTool.Src_It Is Nothing Then
                    CTool.Src_It = New CTool()
                End If

                OResult = CTool.Src_It
            Catch ex As Exception
                CError.Throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "VARIABLE"
    Private m_ORecipe As CRecipe = Nothing
    Private m_OStageA As CAlignmentTool = Nothing
    Private m_OStageB As CAlignmentTool = Nothing

    Private m_ORecipeChanged As RecipeChangedHandler = Nothing
#End Region


#Region "DELETAGE & EVENT"
    Public Delegate Sub RecipeChangedHandler()
#End Region


#Region "PROPERTIES"
    Public Property ORecipe() As CRecipe
        Get
            Return Me.m_ORecipe
        End Get
        Set(ByVal value As CRecipe)
            Try
                Try
                    Me.m_OStageA.BeginSync()
                    Me.m_OStageB.BeginSync()
                    Me.m_OStageA.OLeft.BeginSyncRecipe()
                    Me.m_OStageA.ORight.BeginSyncRecipe()
                    Me.m_OStageB.OLeft.BeginSyncRecipe()
                    Me.m_OStageB.ORight.BeginSyncRecipe()

                    If Not Me.m_ORecipe Is Nothing Then
                        Me.m_ORecipe.Dispose()
                        Me.m_ORecipe = Nothing
                    End If

                    If Not value Is Nothing Then
                        value.Load()
                        Me.m_ORecipe = value
                        Me.m_OStageA.ORecipe = value.OStageA
                        Me.m_OStageB.ORecipe = value.OStageB
                    Else
                        Me.m_ORecipe = value
                        Me.m_OStageA.ORecipe = Nothing
                        Me.m_OStageB.ORecipe = Nothing
                    End If
                Catch ex As Exception
                    CError.Throw(ex)
                Finally
                    Me.m_OStageA.EndSync()
                    Me.m_OStageB.EndSync()
                    Me.m_OStageA.OLeft.EndSyncRecipe()
                    Me.m_OStageA.ORight.EndSyncRecipe()
                    Me.m_OStageB.OLeft.EndSyncRecipe()
                    Me.m_OStageB.ORight.EndSyncRecipe()
                End Try

                Me.OnRecipeChanged()
            Catch ex As Exception
                CError.Throw(ex)
            End Try
        End Set
    End Property


    Public ReadOnly Property OStageA() As CAlignmentTool
        Get
            Return Me.m_OStageA
        End Get
    End Property


    Public ReadOnly Property OStageB() As CAlignmentTool
        Get
            Return Me.m_OStageB
        End Get
    End Property


    Public WriteOnly Property ORecipeChanged() As RecipeChangedHandler
        Set(ByVal value As RecipeChangedHandler)
            Me.m_ORecipeChanged = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
        Try
            CAlignmentSet.It.Load(2)

            Me.m_OStageA = New CAlignmentTool(ESTAGE.A, CAlignmentSet.It.LstOEquip(0))
            Me.m_OStageB = New CAlignmentTool(ESTAGE.B, CAlignmentSet.It.LstOEquip(1))
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
    Private Sub OnRecipeChanged()
        Try
            If (Not Me.m_ORecipeChanged Is Nothing) Then
                Me.m_ORecipeChanged()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            If Not Me.m_OStageA Is Nothing Then
                Me.m_OStageA.Dispose()
                Me.m_OStageA = Nothing
            End If

            If Not Me.m_OStageB Is Nothing Then
                Me.m_OStageB.Dispose()
                Me.m_OStageB = Nothing
            End If

            If Not CAlignmentSet.It Is Nothing Then
                CAlignmentSet.It.Dispose()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class


#Region "ENUM"
Public Enum ESTAGE As Byte
    NONE = 0
    A = 1
    B = 2
End Enum
#End Region
