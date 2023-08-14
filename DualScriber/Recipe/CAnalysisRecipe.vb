Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Imports Cognex.VisionPro
Imports Cognex.VisionPro.PMAlign
Imports Cognex.VisionPro.Caliper

Imports Jhjo.Common


Public Class CAnalysisRecipe
    Implements IDisposable

#Region "CONST"
    Private Const FILE_MARK_TOOL1 As String = "MarkTool1.vpp"
    Private Const FILE_MARK_TOOL2 As String = "MarkTool2.vpp"
    Private Const FILE_MARK_TOOL3 As String = "MarkTool3.vpp"
    Private Const FILE_MARK_TOOL4 As String = "MarkTool4.vpp"
    Private Const FILE_EDGE_TOOL As String = "EdgeTool.vpp"
#End Region


#Region "VARIABLE"
    Private m_StrName As String = Nothing
    Private m_EView As EVIEW = EView.NONE
    Private m_StrDirectory As String = String.Empty

    Private m_OMarkTool1 As CogPMAlignTool = Nothing
    Private m_OMarkTool2 As CogPMAlignTool = Nothing
    Private m_OMarkTool3 As CogPMAlignTool = Nothing
    Private m_OMarkTool4 As CogPMAlignTool = Nothing

    Private m_OEdgeTool As CogCaliperTool = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property StrName() As String
        Get
            Return Me.m_StrName
        End Get
    End Property


    Public ReadOnly Property EView() As EVIEW
        Get
            Return Me.m_EView
        End Get
    End Property


    Public ReadOnly Property StrDirectory() As String
        Get
            Return Me.m_StrDirectory
        End Get
    End Property


    Public ReadOnly Property OMarkTool1() As CogPMAlignTool
        Get
            Return Me.m_OMarkTool1
        End Get
    End Property


    Public ReadOnly Property OMarkTool2() As CogPMAlignTool
        Get
            Return Me.m_OMarkTool2
        End Get
    End Property


    Public ReadOnly Property OMarkTool3() As CogPMAlignTool
        Get
            Return Me.m_OMarkTool3
        End Get
    End Property


    Public ReadOnly Property OMarkTool4() As CogPMAlignTool
        Get
            Return Me.m_OMarkTool4
        End Get
    End Property


    Public ReadOnly Property OEdgeTool() As CogCaliperTool
        Get
            Return Me.m_OEdgeTool
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal StrName As String, ByVal EView As EVIEW, ByVal StrDirectory As String)
        Try
            Me.m_StrName = StrName
            Me.m_EView = EView
            Me.m_StrDirectory = StrDirectory & "\" & EView.ToString()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub New(ByVal OSource As CAnalysisRecipe)
        Try
            Me.m_StrName = OSource.m_StrName
            Me.m_EView = OSource.m_EView
            Me.m_StrDirectory = OSource.m_StrDirectory
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
    Public Sub Create()
        Try
            Me.m_OMarkTool1 = New CogPMAlignTool()
            Me.m_OMarkTool1.RunParams.CoarseAcceptThresholdEnabled = True
            Me.m_OMarkTool1.RunParams.CoarseAcceptThreshold = 0.6D
            Me.m_OMarkTool1.RunParams.AcceptThreshold = 0.8D

            Me.m_OMarkTool2 = New CogPMAlignTool()
            Me.m_OMarkTool2.RunParams.CoarseAcceptThresholdEnabled = True
            Me.m_OMarkTool2.RunParams.CoarseAcceptThreshold = 0.6D
            Me.m_OMarkTool2.RunParams.AcceptThreshold = 0.8D

            Me.m_OMarkTool3 = New CogPMAlignTool()
            Me.m_OMarkTool3.RunParams.CoarseAcceptThresholdEnabled = True
            Me.m_OMarkTool3.RunParams.CoarseAcceptThreshold = 0.6D
            Me.m_OMarkTool3.RunParams.AcceptThreshold = 0.8D

            Me.m_OMarkTool4 = New CogPMAlignTool()
            Me.m_OMarkTool4.RunParams.CoarseAcceptThresholdEnabled = True
            Me.m_OMarkTool4.RunParams.CoarseAcceptThreshold = 0.6D
            Me.m_OMarkTool4.RunParams.AcceptThreshold = 0.8D

            If (Me.m_EView = DualScriber.EVIEW.LEFT) Then
                Dim OPosition As CogCaliperScorerPosition = New CogCaliperScorerPosition()
                OPosition.SetXYParameters(10000, 100, 0, 1, 0.1)

                Me.m_OEdgeTool = New CogCaliperTool()
                Me.m_OEdgeTool.Region.SetOriginLengthsRotationSkew(0, 0, 2556, 958, CogMisc.DegToRad(0), 0)
                Me.m_OEdgeTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge
                Me.m_OEdgeTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight
                Me.m_OEdgeTool.RunParams.ContrastThreshold = 3
                Me.m_OEdgeTool.RunParams.FilterHalfSizeInPixels = 2
                Me.m_OEdgeTool.RunParams.MaxResults = 1
                Me.m_OEdgeTool.RunParams.SingleEdgeScorers.Clear()
                Me.m_OEdgeTool.RunParams.SingleEdgeScorers.Add(OPosition)
            Else
                Dim OPosition As CogCaliperScorerPosition = New CogCaliperScorerPosition()
                OPosition.SetXYParameters(10000, 100, 0, 1, 0.1)

                Me.m_OEdgeTool = New CogCaliperTool()
                Me.m_OEdgeTool.Region.SetOriginLengthsRotationSkew(1278, 958, 2556, 958, CogMisc.DegToRad(180), 0)
                Me.m_OEdgeTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge
                Me.m_OEdgeTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight
                Me.m_OEdgeTool.RunParams.ContrastThreshold = 3
                Me.m_OEdgeTool.RunParams.FilterHalfSizeInPixels = 2
                Me.m_OEdgeTool.RunParams.MaxResults = 1
                Me.m_OEdgeTool.RunParams.SingleEdgeScorers.Clear()
                Me.m_OEdgeTool.RunParams.SingleEdgeScorers.Add(OPosition)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Load()
        Try
            Me.m_OMarkTool1 = CType(CogSerializer.LoadObjectFromFile(StrDirectory & "\" & FILE_MARK_TOOL1, GetType(BinaryFormatter), CogSerializationOptionsConstants.All), CogPMAlignTool)
            Me.m_OMarkTool2 = CType(CogSerializer.LoadObjectFromFile(StrDirectory & "\" & FILE_MARK_TOOL2, GetType(BinaryFormatter), CogSerializationOptionsConstants.All), CogPMAlignTool)
            Me.m_OMarkTool3 = CType(CogSerializer.LoadObjectFromFile(StrDirectory & "\" & FILE_MARK_TOOL3, GetType(BinaryFormatter), CogSerializationOptionsConstants.All), CogPMAlignTool)
            Me.m_OMarkTool4 = CType(CogSerializer.LoadObjectFromFile(StrDirectory & "\" & FILE_MARK_TOOL4, GetType(BinaryFormatter), CogSerializationOptionsConstants.All), CogPMAlignTool)
            Me.m_OEdgeTool = CType(CogSerializer.LoadObjectFromFile(StrDirectory & "\" & FILE_EDGE_TOOL, GetType(BinaryFormatter), CogSerializationOptionsConstants.All), CogCaliperTool)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Save()
        Try
            Directory.CreateDirectory(Me.m_StrDirectory)

            CogSerializer.SaveObjectToFile(Me.m_OMarkTool1, StrDirectory & "\" & FILE_MARK_TOOL1, GetType(BinaryFormatter), CogSerializationOptionsConstants.All)
            CogSerializer.SaveObjectToFile(Me.m_OMarkTool2, StrDirectory & "\" & FILE_MARK_TOOL2, GetType(BinaryFormatter), CogSerializationOptionsConstants.All)
            CogSerializer.SaveObjectToFile(Me.m_OMarkTool3, StrDirectory & "\" & FILE_MARK_TOOL3, GetType(BinaryFormatter), CogSerializationOptionsConstants.All)
            CogSerializer.SaveObjectToFile(Me.m_OMarkTool4, StrDirectory & "\" & FILE_MARK_TOOL4, GetType(BinaryFormatter), CogSerializationOptionsConstants.All)
            CogSerializer.SaveObjectToFile(Me.m_OEdgeTool, StrDirectory & "\" & FILE_EDGE_TOOL, GetType(BinaryFormatter), CogSerializationOptionsConstants.All)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            If Not Me.m_OMarkTool1 Is Nothing Then
                Me.m_OMarkTool1.Dispose()
                Me.m_OMarkTool1 = Nothing
            End If
            If Not Me.m_OMarkTool2 Is Nothing Then
                Me.m_OMarkTool2.Dispose()
                Me.m_OMarkTool2 = Nothing
            End If
            If Not Me.m_OMarkTool3 Is Nothing Then
                Me.m_OMarkTool3.Dispose()
                Me.m_OMarkTool3 = Nothing
            End If
            If Not Me.m_OMarkTool4 Is Nothing Then
                Me.m_OMarkTool4.Dispose()
                Me.m_OMarkTool4 = Nothing
            End If
            If Not Me.m_OEdgeTool Is Nothing Then
                Me.m_OEdgeTool.Dispose()
                Me.m_OEdgeTool = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class



