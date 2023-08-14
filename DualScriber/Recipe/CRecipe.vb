Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Jhjo.Common

Public Class CRecipe
    : Implements IDisposable

#Region "CONST"
    Private Const DIRECTORY_RECIPE_ROOT As String = ".\Recipe"
#End Region


#Region "VARIABLE"
    Private m_I32ID As Integer = 0
    Private m_StrName As String = Nothing
    Private m_StrDirectory As String = Nothing

    Private m_OStageA As CAlignmentRecipe = Nothing
    Private m_OStageB As CAlignmentRecipe = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property I32ID() As Integer
        Get
            Return Me.m_I32ID
        End Get
    End Property


    Public Property StrName() As String
        Get
            Return Me.m_StrName
        End Get
        Set(ByVal value As String)
            Me.m_StrName = value
        End Set
    End Property


    Public ReadOnly Property StrDirectory() As String
        Get
            Return Me.m_StrDirectory
        End Get
    End Property


    Public ReadOnly Property OStageA() As CAlignmentRecipe
        Get
            Return Me.m_OStageA
        End Get
    End Property


    Public ReadOnly Property OStageB() As CAlignmentRecipe
        Get
            Return Me.m_OStageB
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal I32Index As Integer, ByVal StrName As String)
        Try
            Me.m_I32ID = I32Index
            Me.m_StrName = StrName
            Me.m_StrDirectory = DIRECTORY_RECIPE_ROOT & "\" & Me.m_I32ID

            Me.m_OStageA = New CAlignmentRecipe(Me.m_StrName, ESTAGE.A, Me.m_StrDirectory)
            Me.m_OStageB = New CAlignmentRecipe(Me.m_StrName, ESTAGE.B, Me.m_StrDirectory)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub New(ByVal OSource As CRecipe)
        Try
            Me.m_I32ID = OSource.m_I32ID
            Me.m_StrName = OSource.m_StrName
            Me.m_StrDirectory = OSource.m_StrDirectory

            Me.m_OStageA = New CAlignmentRecipe(OSource.m_OStageA)
            Me.m_OStageB = New CAlignmentRecipe(OSource.m_OStageB)
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
            Me.m_OStageA.Create()
            Me.m_OStageB.Create()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Load()
        Try
            Me.m_OStageA.Load()
            Me.m_OStageB.Load()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Save()
        Try
            Me.m_OStageA.Save()
            Me.m_OStageB.Save()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Delete()
        Try
            Directory.Delete(Me.m_StrDirectory, True)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Copy(ByVal OSource As CRecipe)
        Try
            FileSystem.CopyDirectory(OSource.m_StrDirectory, Me.m_StrDirectory, True)

            Me.m_OStageA.Copy(OSource.m_OStageA)
            Me.m_OStageB.Copy(OSource.m_OStageB)
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
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region
End Class
