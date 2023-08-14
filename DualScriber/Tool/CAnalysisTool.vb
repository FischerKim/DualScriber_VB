Imports System.Threading
Imports Cognex.VisionPro
Imports Daekhon.Common
Imports Jhjo.Common
Imports Cognex.VisionPro.PMAlign
Imports Jhjo.Tool

Public Class CAnalysisTool
    Implements IDisposable

#Region "VARIABLE"
    Private m_EView As EVIEW = EVIEW.NONE
    Private m_EStage As ESTAGE = ESTAGE.NONE
    Private m_ODisplayer As CDisplayTool = Nothing

    Private m_ORecipe As CAnalysisRecipe = Nothing
    Private m_ORecipeInterrupt As Object = Nothing

    Private m_OWorker As Thread = Nothing
    Private m_BDoWork As Boolean = False

    Private m_BInspectMark As Boolean = False
    Private m_BInspectEdge As Boolean = False
    Private m_OMarkResult As CMarkResult = Nothing
    Private m_OEdgeResult As CEdgeResult = Nothing
    Private m_OInterrupt As Object = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property EView() As EVIEW
        Get
            Return Me.m_EView
        End Get
    End Property


    Public ReadOnly Property ODisplayer() As CDisplayTool
        Get
            Return Me.m_ODisplayer
        End Get
    End Property


    Public Property ORecipe() As CAnalysisRecipe
        Get
            Return Me.m_ORecipe
        End Get
        Set(ByVal value As CAnalysisRecipe)
            Me.m_ORecipe = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal EView As EVIEW, ByVal EStage As ESTAGE)
        Try
            Me.m_EView = EView
            Me.m_ODisplayer = New CDisplayTool()

            Me.m_ORecipeInterrupt = New Object()
            Me.m_OInterrupt = New Object()

            Me.BeginWork()
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
    Private Sub BeginWork()
        Try
            If Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = True

                Me.m_OWorker = New Thread(AddressOf Me.Work)
                Me.m_OWorker.IsBackground = True
                'Me.m_OWorker.SetApartmentState(ApartmentState.STA) '0427
                Me.m_OWorker.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub Work()
        Try
            While (Me.m_BDoWork)
                Try
                    Monitor.Enter(Me.m_OInterrupt)

                    If (Me.m_BInspectMark = True) Then
                        Dim OImageInfo As CImageInfo = Me.m_ODisplayer.GetImageInfoToAnalysis()

                        If Not OImageInfo Is Nothing Then
                            Me.m_BInspectMark = False
                            Me.m_OMarkResult = Me.DoInspectMark(OImageInfo)
                        End If
                    ElseIf (Me.m_BInspectEdge = True) Then
                        Dim OImageInfo As CImageInfo = Me.m_ODisplayer.GetImageInfoToAnalysis()

                        If Not OImageInfo Is Nothing Then
                            Me.m_BInspectEdge = False
                            Me.m_OEdgeResult = Me.DoInspectEdge(OImageInfo)
                        End If
                    End If
                Catch ex As Exception
                    CError.Ignore(ex)
                Finally
                    Monitor.Exit(Me.m_OInterrupt)
                End Try

                Thread.Sleep(10)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub


    Private Sub EndWork()
        Try
            If Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = False

                Me.m_OWorker.Join()
                Me.m_OWorker = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub RequestMark()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BInspectMark = True
            Me.m_OMarkResult = Nothing
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Function DoInspectMark(ByVal OImageInfo As CImageInfo) As CMarkResult
        Dim OResult As CMarkResult = Nothing

        Try
            Monitor.Enter(Me.m_ORecipeInterrupt)

            If Not Me.m_ORecipe Is Nothing Then
                If Me.m_ORecipe.OMarkTool4.Pattern.Trained = True Then
                    Me.DoInspectPattern(Me.m_ORecipe.OMarkTool1, OImageInfo, OResult)
                    'If Not OResult Is Nothing Then Return OResult
                End If

                If Me.m_ORecipe.OMarkTool3.Pattern.Trained = True Then
                    Me.DoInspectPattern(Me.m_ORecipe.OMarkTool2, OImageInfo, OResult)
                    'If Not OResult Is Nothing Then Return OResult
                End If

                If Me.m_ORecipe.OMarkTool2.Pattern.Trained = True Then
                    Me.DoInspectPattern(Me.m_ORecipe.OMarkTool3, OImageInfo, OResult)
                    'If Not OResult Is Nothing Then Return OResult
                End If

                If Me.m_ORecipe.OMarkTool1.Pattern.Trained = True Then
                    Me.DoInspectPattern(Me.m_ORecipe.OMarkTool4, OImageInfo, OResult)
                End If

                If Not OResult Is Nothing Then Return OResult

                OResult = New CMarkResult(OImageInfo)
                OResult.EView = Me.m_EView
                OResult.BInspected = True
                OResult.BOK = False
            Else
                OResult = New CMarkResult(OImageInfo)
                OResult.EView = Me.m_EView
                OResult.BInspected = False
                OResult.BOK = False
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_ORecipeInterrupt)
        End Try

        Return OResult
    End Function


    Private Sub DoInspectPattern(ByVal OTool As CogPMAlignTool, ByVal OImageInfo As CImageInfo, ByRef OResult As CMarkResult)
        'Dim OResult As CMarkResult = Nothing

        Try
            OTool.InputImage = OImageInfo.OImage
            OTool.Run()

            If Not OTool.Results Is Nothing Then
                If OTool.Results.Count = 1 Then
                    Dim OToolResult As CogTransform2DLinear = OTool.Results(0).GetPose()

                    OResult = New CMarkResult(OImageInfo)
                    OResult.BInspected = True
                    OResult.BOK = True
                    OResult.F64Score = OTool.Results(0).Score

                    If Not ((OResult.F64X = 0) AndAlso (OResult.F64Y = 0)) Then
                        Dim DistanceX As Double = Math.Abs(OResult.F64X - OToolResult.TranslationX)
                        Dim DistanceY As Double = Math.Abs(OResult.F64Y - OToolResult.TranslationY)
                        If (DistanceX > CEnvironment.It.MinDistanceX) Or (DistanceY > CEnvironment.It.MinDistanceY) Then
                            If (Me.m_EView = EVIEW.LEFT) Then
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_LEFT_UNKNOWN)
                            Else
                                CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_RIGHT_UNKNOWN)
                            End If

                            CLogTool.It.SetLog(New CLog("Alternate Pattern Recognized"))
                        End If
                    End If

                    OResult.F64X = OToolResult.TranslationX
                    OResult.F64Y = OToolResult.TranslationY
                ElseIf OTool.Results.Count > 1 Then
                    If (Me.m_EView = EVIEW.LEFT) Then
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_LEFT_UNKNOWN)
                    Else
                        CMotionController.It.OPLC.SendErrorCode(Me.m_EStage, EERROR.ALIGNMENT_RIGHT_UNKNOWN)
                    End If

                    CLogTool.It.SetLog(New CLog("More than One Align Mark Found!"))
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try

        'Return OResult
    End Sub


    Public Function GetMarkResult() As CMarkResult
        Dim OResult As CMarkResult = Nothing

        Try
            Monitor.Enter(Me.m_OInterrupt)
            OResult = Me.m_OMarkResult
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return OResult
    End Function

    Public Function InitMarkResult() As CMarkResult
        Dim OResult As CMarkResult = Nothing

        Try
            Monitor.Enter(Me.m_OInterrupt)
            Me.m_OMarkResult = Nothing
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return OResult
    End Function

    Public Sub RequestEdge()
        Try
            Monitor.Enter(Me.m_OInterrupt)

            Me.m_BInspectEdge = True
            Me.m_OEdgeResult = Nothing
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Private Function DoInspectEdge(ByVal OImageInfo As CImageInfo) As CEdgeResult
        Dim OResult As CEdgeResult = Nothing

        Try
            Monitor.Enter(Me.m_ORecipeInterrupt)

            OResult = New CEdgeResult(OImageInfo)
            OResult.EView = Me.m_EView

            If Not Me.m_ORecipe Is Nothing Then
                Me.m_ORecipe.OEdgeTool.InputImage = OImageInfo.OImage
                Me.m_ORecipe.OEdgeTool.Run()

                OResult.BInspected = True
                If ((Not Me.m_ORecipe.OEdgeTool.Results Is Nothing) AndAlso (Me.m_ORecipe.OEdgeTool.Results.Count > 0)) Then
                    OResult.BOK = True
                    OResult.F64X = Me.m_ORecipe.OEdgeTool.Results.Item(0).Edge0.PositionX
                    OResult.F64Y = Me.m_ORecipe.OEdgeTool.Results.Item(0).Edge0.PositionY
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_ORecipeInterrupt)
        End Try

        Return OResult
    End Function


    Public Function GetEdgeResult() As CEdgeResult
        Dim OResult As CEdgeResult = Nothing

        Try
            Monitor.Enter(Me.m_OInterrupt)
            OResult = Me.m_OEdgeResult
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return OResult
    End Function


    Public Sub BeginSyncRecipe()
        Try
            Monitor.Enter(Me.m_ORecipeInterrupt)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub EndSyncRecipe()
        Try
            Monitor.Exit(Me.m_ORecipeInterrupt)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            Me.EndWork()

            If Not Me.m_ODisplayer Is Nothing Then
                Me.m_ODisplayer.Dispose()
                Me.m_ODisplayer = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region
End Class


#Region "ENUM"
Public Enum ETOOL As Byte
    NONE = 0
    MARK
    EDGE
End Enum


Public Enum EMARK As Byte
    NONE = 0
    INDEX1
    INDEX2
    INDEX3
    INDEX4
End Enum
#End Region