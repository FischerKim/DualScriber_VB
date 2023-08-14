Imports Jhjo.Common


Public Class UcPCI
    Inherits UcScreen

#Region "VARIABLE"
    Private m_BInReady As Boolean = False
    Private m_BInStageAAlignStart As Boolean = False
    Private m_BInStageBAlignStart As Boolean = False
    Private m_BInStageAEdgeStart As Boolean = False
    Private m_BInStageBEdgeStart As Boolean = False
    Private m_BInStageAInitialize As Boolean = False
    Private m_BInStageBInitialize As Boolean = False

    Private m_BOutStageAReady As Boolean = False
    Private m_BOutStageABusy As Boolean = False
    Private m_BOutStageAAlignRetry As Boolean = False
    Private m_BOutStageAAlignOK As Boolean = False
    Private m_BOutStageAEdgeOK As Boolean = False
    Private m_BOutStageAAlignLeftNG As Boolean = False
    Private m_BOutStageAAlignRightNG As Boolean = False
    Private m_BOutStageAEdgeNG As Boolean = False
    Private m_BOutStageBReady As Boolean = False
    Private m_BOutStageBBusy As Boolean = False
    Private m_BOutStageBAlignRetry As Boolean = False
    Private m_BOutStageBAlignOK As Boolean = False
    Private m_BOutStageBEdgeOK As Boolean = False
    Private m_BOutStageBAlignLeftNG As Boolean = False
    Private m_BOutStageBAlignRightNG As Boolean = False
    Private m_BOutStageBEdgeNG As Boolean = False
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()
    End Sub
#End Region


#Region "FUNCTION"
    Public Overrides Sub Add()
        Try
            Me.DisplayIO()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Overrides Sub Timer1000()
        Try
            Me.DisplayIO()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub UpdateIO()
        Try
            CMotionController.It.OPCI.BeginSync()

            Me.m_BInReady = CMotionController.It.OPCI.BInReady
            Me.m_BInStageAAlignStart = CMotionController.It.OPCI.BInStageAAlignStart
            Me.m_BInStageAEdgeStart = CMotionController.It.OPCI.BInStageAEdgeStart
            Me.m_BInStageAInitialize = CMotionController.It.OPCI.BInStageAInitialize
            Me.m_BInStageBAlignStart = CMotionController.It.OPCI.BInStageBAlignStart
            Me.m_BInStageBEdgeStart = CMotionController.It.OPCI.BInStageBEdgeStart
            Me.m_BInStageBInitialize = CMotionController.It.OPCI.BInStageBInitialize

            Me.m_BOutStageAReady = CMotionController.It.OPCI.BOutStageAReady
            Me.m_BOutStageABusy = CMotionController.It.OPCI.BOutStageABusy
            Me.m_BOutStageAAlignRetry = CMotionController.It.OPCI.BOutStageAAlignRetry
            Me.m_BOutStageAAlignOK = CMotionController.It.OPCI.BOutStageAAlignOK
            Me.m_BOutStageAEdgeOK = CMotionController.It.OPCI.BOutStageAEdgeOK
            Me.m_BOutStageAAlignLeftNG = CMotionController.It.OPCI.BOutStageAAlignLeftNG
            Me.m_BOutStageAAlignRightNG = CMotionController.It.OPCI.BOutStageAAlignRightNG
            Me.m_BOutStageAEdgeNG = CMotionController.It.OPCI.BOutStageAEdgeNG
            Me.m_BOutStageBReady = CMotionController.It.OPCI.BOutStageBReady
            Me.m_BOutStageBBusy = CMotionController.It.OPCI.BOutStageBBusy
            Me.m_BOutStageBAlignRetry = CMotionController.It.OPCI.BOutStageBAlignRetry
            Me.m_BOutStageBAlignOK = CMotionController.It.OPCI.BOutStageBAlignOK
            Me.m_BOutStageBEdgeOK = CMotionController.It.OPCI.BOutStageBEdgeOK
            Me.m_BOutStageBAlignLeftNG = CMotionController.It.OPCI.BOutStageBAlignLeftNG
            Me.m_BOutStageBAlignRightNG = CMotionController.It.OPCI.BOutStageBAlignRightNG
            Me.m_BOutStageBEdgeNG = CMotionController.It.OPCI.BOutStageBEdgeNG
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CMotionController.It.OPCI.EndSync()
        End Try
    End Sub


    Private Sub DisplayIO()
        Try
            Me.LblInReady.BackColor = CType(IIf(Me.m_BInReady, Color.ForestGreen, Color.DimGray), Color)
            Me.LblInStageAAlignStart.BackColor = CType(IIf(Me.m_BInStageAAlignStart, Color.ForestGreen, Color.DimGray), Color)
            Me.LblInStageBAlignStart.BackColor = CType(IIf(Me.m_BInStageBAlignStart, Color.ForestGreen, Color.DimGray), Color)
            Me.LblInStageAEdgeStart.BackColor = CType(IIf(Me.m_BInStageAEdgeStart, Color.ForestGreen, Color.DimGray), Color)
            Me.LblInStageBEdgeStart.BackColor = CType(IIf(Me.m_BInStageBEdgeStart, Color.ForestGreen, Color.DimGray), Color)
            Me.LblInStageAAlignOK.BackColor = CType(IIf(Me.m_BInStageAInitialize, Color.ForestGreen, Color.DimGray), Color)
            Me.LblInStageBAlignOK.BackColor = CType(IIf(Me.m_BInStageBInitialize, Color.ForestGreen, Color.DimGray), Color)

            Me.LblOutStageAReady.BackColor = CType(IIf(Me.m_BOutStageAReady, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageABusy.BackColor = CType(IIf(Me.m_BOutStageABusy, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageAAlignRetry.BackColor = CType(IIf(Me.m_BOutStageAAlignRetry, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageAAlignOK.BackColor = CType(IIf(Me.m_BOutStageAAlignOK, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageAEdgeOK.BackColor = CType(IIf(Me.m_BOutStageAEdgeOK, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageAAlignLeftNG.BackColor = CType(IIf(Me.m_BOutStageAAlignLeftNG, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageAAlignRightNG.BackColor = CType(IIf(Me.m_BOutStageAAlignRightNG, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageAEdgeNG.BackColor = CType(IIf(Me.m_BOutStageAEdgeNG, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBReady.BackColor = CType(IIf(Me.m_BOutStageBReady, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBBusy.BackColor = CType(IIf(Me.m_BOutStageBBusy, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBAlignRetry.BackColor = CType(IIf(Me.m_BOutStageBAlignRetry, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBAlignOK.BackColor = CType(IIf(Me.m_BOutStageBAlignOK, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBEdgeOK.BackColor = CType(IIf(Me.m_BOutStageBEdgeOK, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBAlignLeftNG.BackColor = CType(IIf(Me.m_BOutStageBAlignLeftNG, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBAlignRightNG.BackColor = CType(IIf(Me.m_BOutStageBAlignRightNG, Color.ForestGreen, Color.DimGray), Color)
            Me.LblOutStageBEdgeNG.BackColor = CType(IIf(Me.m_BOutStageBEdgeNG, Color.ForestGreen, Color.DimGray), Color)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
