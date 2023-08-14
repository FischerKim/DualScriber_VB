Public Class CCutResult

#Region "VARIABLE"
    Private m_BInspected As Boolean = False
    Private m_BOK As Boolean = True
    Private m_F64Length As Double = 0

    Private m_F64MarkCamera As Double = 0
    Private m_F64EdgeCamera As Double = 0

    Private m_F64CutMinLimit As Double = 0
    Private m_F64CutMaxLimit As Double = 0

    Private m_OMarkInfo As CMarkResult = Nothing
    Private m_OEdgeInfo As CEdgeResult = Nothing
#End Region


#Region "PROPERTIES"
    Public Property BInspected() As Boolean
        Get
            Return Me.m_BInspected
        End Get
        Set(ByVal value As Boolean)
            Me.m_BInspected = value
        End Set
    End Property


    Public Property BOK() As Boolean
        Get
            Return Me.m_BOK
        End Get
        Set(ByVal value As Boolean)
            Me.m_BOK = value
        End Set
    End Property


    Public Property F64Length() As Double
        Get
            Return Me.m_F64Length
        End Get
        Set(ByVal value As Double)
            Me.m_F64Length = value
        End Set
    End Property


    Public Property F64MarkCamera() As Double
        Get
            Return Me.m_F64MarkCamera
        End Get
        Set(ByVal value As Double)
            Me.m_F64MarkCamera = value
        End Set
    End Property


    Public Property F64EdgeCamera() As Double
        Get
            Return Me.m_F64EdgeCamera
        End Get
        Set(ByVal value As Double)
            Me.m_F64EdgeCamera = value
        End Set
    End Property


    Public Property F64CutMinLimit() As Double
        Get
            Return Me.m_F64CutMinLimit
        End Get
        Set(ByVal value As Double)
            Me.m_F64CutMinLimit = value
        End Set
    End Property


    Public Property F64CutMaxLimit() As Double
        Get
            Return Me.m_F64CutMaxLimit
        End Get
        Set(ByVal value As Double)
            Me.m_F64CutMaxLimit = value
        End Set
    End Property


    Public Property OMarkInfo() As CMarkResult
        Get
            Return Me.m_OMarkInfo
        End Get
        Set(ByVal value As CMarkResult)
            Me.m_OMarkInfo = value
        End Set
    End Property


    Public Property OEdgeInfo() As CEdgeResult
        Get
            Return Me.m_OEdgeInfo
        End Get
        Set(ByVal value As CEdgeResult)
            Me.m_OEdgeInfo = value
        End Set
    End Property
#End Region

End Class
