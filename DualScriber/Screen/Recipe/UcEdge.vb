Imports Cognex.VisionPro.Caliper
Imports Jhjo.Common
Imports Cognex.VisionPro

Public Class UcEdge
    Inherits UcSubRecipe

#Region "VARIABLE"
    Private m_OTool As CRecipeDesignTool = Nothing
    Private m_ORecipe As CogCaliperTool = Nothing

    Private m_BPreventEvent As Boolean = False
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal OTool As CRecipeDesignTool)
        InitializeComponent()

        Try
            Me.m_OTool = OTool
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "EVENT"
#Region "BUTTON EVENT"
    Private Sub BtnInspect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInspect.Click
        Try
            If (Me.m_OTool.CdpDesign.Image Is Nothing) Then
                CMsgBox.Warning("Please set image to inspect")
                Return
            End If

            Me.m_ORecipe.Run()
            If ((Not Me.m_ORecipe.Results Is Nothing) AndAlso (Me.m_ORecipe.Results.Count > 0)) Then
                Me.m_OTool.CdpDesign.StaticGraphics.Clear()
                Me.m_OTool.CdpDesign.StaticGraphics.Add _
                ( _
                    Me.m_ORecipe.Results(0).CreateResultGraphics(CogCaliperResultGraphicConstants.All), _
                    "RESULT" _
                )
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "ETC EVENT"
    Private Sub CmbPolarity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbPolarity.SelectedIndexChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Select Case (Me.CmbPolarity.Text)
                Case "DarkToLight"
                    Me.m_ORecipe.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight
                Case "LightToDark"
                    Me.m_ORecipe.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark
                Case "DontCare"
                    Me.m_ORecipe.RunParams.Edge0Polarity = CogCaliperPolarityConstants.DontCare
            End Select
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub NudContrastThreshold_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudContrastThreshold.ValueChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_ORecipe.RunParams.ContrastThreshold = Convert.ToInt32(Me.NudContrastThreshold.Value)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub NudHalfPixel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudHalfPixel.ValueChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_ORecipe.RunParams.FilterHalfSizeInPixels = Convert.ToInt32(Me.NudHalfPixel.Value)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region
#End Region


#Region "FUNCTION"
    Public Overrides Sub Add()
        Try
            Me.DoRefresh()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Overrides Sub Remove()
        Try
            Me.m_OTool.CdpDesign.StaticGraphics.Clear()
            Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Overrides Sub DoRefresh()
        Try
            Me.m_BPreventEvent = True

            If (Not Me.m_OTool.ORecipe Is Nothing) Then
                If (Me.m_OTool.EStage = ESTAGE.A) Then
                    If (Me.m_OTool.EView = EVIEW.LEFT) Then
                        Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.OLeft.OEdgeTool
                    Else
                        Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.ORight.OEdgeTool
                    End If
                Else
                    If (Me.m_OTool.EView = EVIEW.LEFT) Then
                        Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.OLeft.OEdgeTool
                    Else
                        Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.ORight.OEdgeTool
                    End If
                End If


                Me.m_OTool.CdpDesign.StaticGraphics.Clear()
                Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()
                Me.m_OTool.CdpDesign.Image = Me.m_ORecipe.InputImage
                Me.m_OTool.CdpDesign.InteractiveGraphics.Add(Me.m_ORecipe.Region, "ROI", True)

                Me.CmbPolarity.Text = Me.m_ORecipe.RunParams.Edge0Polarity.ToString()
                Me.CmbPolarity.Enabled = True

                Me.NudContrastThreshold.Value = Me.m_ORecipe.RunParams.ContrastThreshold
                Me.NudContrastThreshold.Controls(1).Text = Me.NudContrastThreshold.Value.ToString()
                Me.NudContrastThreshold.Enabled = True

                Me.NudHalfPixel.Value = Me.m_ORecipe.RunParams.FilterHalfSizeInPixels
                Me.NudHalfPixel.Controls(1).Text = Me.NudHalfPixel.Value.ToString()
                Me.NudHalfPixel.Enabled = True
            Else
                Me.m_OTool.CdpDesign.StaticGraphics.Clear()
                Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()

                Me.CmbPolarity.SelectedIndex = -1
                Me.CmbPolarity.Enabled = False

                Me.NudContrastThreshold.Controls(1).Text = String.Empty
                Me.NudContrastThreshold.Enabled = False

                Me.NudHalfPixel.Controls(1).Text = String.Empty
                Me.NudHalfPixel.Enabled = False
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Me.m_BPreventEvent = False
        End Try
    End Sub


    Public Overrides Sub SetImage(ByVal OImage As CogImage8Grey)
        Try
            If (Not OImage Is Nothing) Then
                Me.m_OTool.CdpDesign.Image = OImage
                Me.m_ORecipe.InputImage = OImage
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
