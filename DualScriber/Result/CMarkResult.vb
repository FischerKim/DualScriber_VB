Imports Jhjo.Common

Public Class CMarkResult
    : Implements IAnalysisResult

#Region "VARIABLE"
    Private m_EView As EVIEW = DualScriber.EVIEW.NONE
    Private m_OImageInfo As CImageInfo = Nothing

    Private m_BInspected As Boolean = False
    Private m_BOK As Boolean = False
    Private m_F64Score As Double = 0
    Private m_F64X As Double = 0
    Private m_F64Y As Double = 0
#End Region


#Region "PROPERTIES"
    Public Property EView() As EVIEW Implements IAnalysisResult.EView
        Get
            Return Me.m_EView
        End Get
        Set(ByVal value As EVIEW)
            Me.m_EView = value
        End Set
    End Property


    Public ReadOnly Property OImageInfo() As CImageInfo Implements IAnalysisResult.OImageInfo
        Get
            Return Me.m_OImageInfo
        End Get
    End Property


    Public Property BInspected() As Boolean Implements IAnalysisResult.BInspected
        Get
            Return Me.m_BInspected
        End Get
        Set(ByVal value As Boolean)
            Me.m_BInspected = value
        End Set
    End Property


    Public Property BOK() As Boolean Implements IAnalysisResult.BOK
        Get
            Return Me.m_BOK
        End Get
        Set(ByVal value As Boolean)
            Me.m_BOK = value
        End Set
    End Property

    '스텝 7 :  * 100 함.
    Public Property F64Score() As Double
        Get
            Return Me.m_F64Score * 100
        End Get
        Set(ByVal value As Double)
            Me.m_F64Score = value
        End Set
    End Property


    Public Property F64X() As Double
        Get
            Return Me.m_F64X
        End Get
        Set(ByVal value As Double)
            Me.m_F64X = value
        End Set
    End Property


    Public Property F64Y() As Double
        Get
            Return Me.m_F64Y
        End Get
        Set(ByVal value As Double)
            Me.m_F64Y = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal OImageInfo As CImageInfo)
        Try
            Me.m_OImageInfo = OImageInfo
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
