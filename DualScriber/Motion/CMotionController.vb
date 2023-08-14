Imports System.Threading
Imports Jhjo.Common


Public Class CMotionController
    Implements IDisposable

#Region "SINGLE TON"
    Private Shared Src_It As CMotionController = Nothing

    Public Shared ReadOnly Property It() As CMotionController
        Get
            Dim OResult As CMotionController = Nothing

            Try
                If CMotionController.Src_It Is Nothing Then
                    CMotionController.Src_It = New CMotionController()
                End If

                OResult = CMotionController.Src_It
            Catch ex As Exception
                CError.Throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "VARIABLE"
    Private m_OPCI As CPCI = Nothing
    Private m_OPLC As CPLC = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property OPCI() As CPCI
        Get
            Return Me.m_OPCI
        End Get
    End Property


    Public ReadOnly Property OPLC() As CPLC
        Get
            Return Me.m_OPLC
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
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
    Public Sub Open()
        Try
            Me.m_OPCI = New CPCI()
            Me.m_OPLC = New CPLC()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            If Not Me.m_OPCI Is Nothing Then
                Me.m_OPCI.Dispose()
                Me.m_OPCI = Nothing
            End If
            If Not Me.m_OPLC Is Nothing Then
                Me.m_OPLC.Dispose()
                Me.m_OPLC = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
