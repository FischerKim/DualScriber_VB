Imports Jhjo.Common


Public Class CInspectionResult

#Region "VARIABLE"
    Private m_OTime As DateTime = DateTime.Now
    Private m_StrID As String = String.Empty
    Private m_EStage As ESTAGE = ESTAGE.A
    Private m_ETarget As EEDGE_TARGET = EEDGE_TARGET.NONE

    Private m_OLeft As CCutResult = Nothing
    Private m_ORight As CCutResult = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property OTime() As DateTime
        Get
            Return Me.m_OTime
        End Get
    End Property


    Public Property StrID() As String
        Get
            Return Me.m_StrID
        End Get
        Set(ByVal value As String)
            Me.m_StrID = value
        End Set
    End Property


    Public ReadOnly Property EStage() As ESTAGE
        Get
            Return Me.m_EStage
        End Get
    End Property


    Public ReadOnly Property ETarget() As EEDGE_TARGET
        Get
            Return Me.m_ETarget
        End Get
    End Property


    Public Property OLeft() As CCutResult
        Get
            Return Me.m_OLeft
        End Get
        Set(ByVal value As CCutResult)
            Me.m_OLeft = value
        End Set
    End Property


    Public Property ORight() As CCutResult
        Get
            Return Me.m_ORight
        End Get
        Set(ByVal value As CCutResult)
            Me.m_ORight = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal EStage As ESTAGE, ByVal ETarget As EEDGE_TARGET)
        Try
            Me.m_EStage = EStage
            Me.m_ETarget = ETarget
            Me.m_OLeft = New CCutResult()
            Me.m_ORight = New CCutResult()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
