Imports Jhjo.Common
Imports Daekhon.Common
Imports Daekhon.Acquisition.Basler


Public Class CAcquisitionManager
    Implements IDisposable

#Region "SINGLE TON"
    Private Shared Src_It As CAcquisitionManager = Nothing

    Public Shared ReadOnly Property It() As CAcquisitionManager
        Get
            Dim OResult As CAcquisitionManager = Nothing

            Try
                If CAcquisitionManager.Src_It Is Nothing Then
                    CAcquisitionManager.Src_It = New CAcquisitionManager()
                End If

                OResult = CAcquisitionManager.Src_It
            Catch ex As Exception
                CError.throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "VARIABLE"
    Private m_OALeft As CBasler = Nothing
    Private m_OARight As CBasler = Nothing
    Private m_OBLeft As CBasler = Nothing
    Private m_OBRight As CBasler = Nothing
#End Region


#Region "PROPERTIES"
    Public Property OALeft() As CBasler
        Get
            Return Me.m_OALeft
        End Get
        Set(ByVal value As CBasler)
            Me.m_OALeft = value
        End Set
    End Property

    Public Property OARight() As CBasler
        Get
            Return Me.m_OARight
        End Get
        Set(ByVal value As CBasler)
            Me.m_OARight = value
        End Set
    End Property

    Public Property OBLeft() As CBasler
        Get
            Return Me.m_OBLeft
        End Get
        Set(ByVal value As CBasler)
            Me.m_OBLeft = value
        End Set
    End Property

    Public Property OBRight() As CBasler
        Get
            Return Me.m_OBRight
        End Get
        Set(ByVal value As CBasler)
            Me.m_OBRight = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
    End Sub

    Protected Overrides Sub Finalize()
        Me.Dispose()
        MyBase.Finalize()
    End Sub
#End Region


#Region "FUNCTION"
    Public Sub Dispose() Implements IDisposable.Dispose
        If Not Me.m_OALeft Is Nothing Then
            Me.m_OALeft.Dispose()
            Me.m_OALeft = Nothing
        End If

        If Not Me.m_OARight Is Nothing Then
            Me.m_OARight.Dispose()
            Me.m_OARight = Nothing
        End If

        If Not Me.m_OBLeft Is Nothing Then
            Me.m_OBLeft.Dispose()
            Me.m_OBLeft = Nothing
        End If

        If Not Me.m_OBRight Is Nothing Then
            Me.m_OBRight.Dispose()
            Me.m_OBRight = Nothing
        End If
    End Sub
#End Region

End Class


#Region "ENUM"
Public Enum ECAMERA As Byte
    NONE = 0
    A_LEFT
    A_RIGHT
    B_LEFT
    B_RIGHT
End Enum
#End Region

