Imports System.Threading
Imports smal_CS
Imports Jhjo.Common

Public Class CAlignmentSet
    Implements IDisposable

#Region "SINGLE TON"
    Private Shared Src_It As CAlignmentSet = Nothing

    Public Shared ReadOnly Property It() As CAlignmentSet
        Get
            Dim OResult As CAlignmentSet = Nothing

            Try
                If CAlignmentSet.Src_It Is Nothing Then
                    CAlignmentSet.Src_It = New CAlignmentSet()
                End If

                OResult = CAlignmentSet.Src_It
            Catch ex As Exception
                CError.Throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "VARIABLE"
    Private m_OTool As WrapStaticLibSmal = Nothing
    Private m_LstOEquip As List(Of CAlignmentAlogrithm) = Nothing
    Private m_OInterrupt As Object = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property OTool() As WrapStaticLibSmal
        Get
            Return Me.m_OTool
        End Get
    End Property


    Public ReadOnly Property LstOEquip() As List(Of CAlignmentAlogrithm)
        Get
            Return Me.m_LstOEquip
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
        Try
            Me.m_OTool = New WrapStaticLibSmal()
            Me.m_LstOEquip = New List(Of CAlignmentAlogrithm)
            Me.m_OInterrupt = New Object()
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
    Public Sub Load(ByVal I32Count As Integer)
        Try
            Me.m_OTool.SmalSetNumStage(I32Count)

            For _Index As Integer = 0 To I32Count - 1 Step 1
                Me.m_LstOEquip.Add(New CAlignmentAlogrithm(Me.m_OTool, _Index))
            Next
        Catch ex As Exception
            CError.Throw(ex)
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


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            If Not Me.m_OTool Is Nothing Then
                Me.m_OTool.Dispose()
                Me.m_OTool = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
