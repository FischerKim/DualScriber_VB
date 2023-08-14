Imports Cognex.VisionPro.Display
Imports Jhjo.Common

Public Class CRecipeDesignTool

#Region "VARIABLE"
    Private m_ORecipe As CRecipe = Nothing
    Private m_CdpDesign As CogDisplay = Nothing

    Private m_EStage As ESTAGE = ESTAGE.NONE
    Private m_EView As EVIEW = EVIEW.NONE
    Private m_ETool As ETOOL = ETOOL.NONE
    Private m_EMark As EMARK = EMARK.NONE
#End Region


#Region "PROPERTIES"
    Public Property ORecipe() As CRecipe
        Get
            Return Me.m_ORecipe
        End Get
        Set(ByVal value As CRecipe)
            Me.m_ORecipe = value
        End Set
    End Property


    Public ReadOnly Property CdpDesign() As CogDisplay
        Get
            Return Me.m_CdpDesign
        End Get
    End Property


    Public Property EStage() As ESTAGE
        Get
            Return Me.m_EStage
        End Get
        Set(ByVal value As ESTAGE)
            Me.m_EStage = value
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


    Public Property ETool() As ETOOL
        Get
            Return Me.m_ETool
        End Get
        Set(ByVal value As ETOOL)
            Me.m_ETool = value
        End Set
    End Property


    Public Property EMark() As EMARK
        Get
            Return Me.m_EMark
        End Get
        Set(ByVal value As EMARK)
            Me.m_EMark = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal CdpDesign As CogDisplay)
        Try
            Me.m_CdpDesign = CdpDesign
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
