Imports Jhjo.Common


Public Class CAlignmentResult

#Region "VARIABLE"
    Private m_OTime As DateTime = DateTime.MinValue

    Private m_EStage As ESTAGE = EStage.NONE
    Private m_OLeft As CMarkResult = Nothing
    Private m_ORight As CMarkResult = Nothing

    Private m_EResult As ERESULT = EResult.NONE
    Private m_EView As EVIEW = EVIEW.NONE
    Private m_F64MotionLeftX As Double = 0
    Private m_F64MotionRightX As Double = 0
    Private m_F64MotionY As Double = 0
    Private m_F64MotionT As Double = 0
    ' jht Retry & Tact
    Private m_F64RetryCount As Integer = 0
    Private m_OTimeElapsed As TimeSpan
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property OTime() As DateTime
        Get
            Return Me.m_OTime
        End Get
    End Property


    Public ReadOnly Property EStage() As ESTAGE
        Get
            Return Me.m_EStage
        End Get
    End Property


    Public Property OLeft() As CMarkResult
        Get
            Return Me.m_OLeft
        End Get
        Set(ByVal value As CMarkResult)
            Me.m_OLeft = value
        End Set
    End Property


    Public Property ORight() As CMarkResult
        Get
            Return Me.m_ORight
        End Get
        Set(ByVal value As CMarkResult)
            Me.m_ORight = value
        End Set
    End Property


    Public Property EResult() As ERESULT
        Get
            Return Me.m_EResult
        End Get
        Set(ByVal value As ERESULT)
            Me.m_EResult = value
        End Set
    End Property


    Public Property EView() As EVIEW
        Get
            Return Me.m_EView
        End Get
        Set(ByVal value As EVIEW)
            Me.m_EView = value
        End Set
    End Property


    Public Property F64MotionLeftX() As Double
        Get
            Return Me.m_F64MotionLeftX
        End Get
        Set(ByVal value As Double)
            Me.m_F64MotionLeftX = value
        End Set
    End Property


    Public Property F64MotionRightX() As Double
        Get
            Return Me.m_F64MotionRightX
        End Get
        Set(ByVal value As Double)
            Me.m_F64MotionRightX = value
        End Set
    End Property


    Public Property F64MotionY() As Double
        Get
            Return Me.m_F64MotionY
        End Get
        Set(ByVal value As Double)
            Me.m_F64MotionY = value
        End Set
    End Property


    Public Property F64MotionT() As Double
        Get
            Return Me.m_F64MotionT
        End Get
        Set(ByVal value As Double)
            Me.m_F64MotionT = value
        End Set
    End Property

    Public Property F64RetryCount() As Integer
        Get
            Return Me.m_F64RetryCount
        End Get
        Set(ByVal value As Integer)
            Me.m_F64RetryCount = value
        End Set
    End Property

    Public Property OTimeElapsed() As TimeSpan
        Get
            Return Me.m_OTimeElapsed
        End Get
        Set(ByVal value As TimeSpan)
            Me.m_OTimeElapsed = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal EStage As ESTAGE)
        Try
            Me.m_OTime = DateTime.Now
            Me.m_EStage = EStage
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub New(ByVal EStage As ESTAGE, ByVal OLeft As CMarkResult, ByVal ORight As CMarkResult)
        Try
            Me.m_OTime = DateTime.Now
            Me.m_EStage = EStage
            Me.m_OLeft = OLeft
            Me.m_ORight = ORight
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
