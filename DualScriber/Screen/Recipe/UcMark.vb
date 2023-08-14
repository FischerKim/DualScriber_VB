Imports Cognex.VisionPro
Imports Cognex.VisionPro.PMAlign
Imports Jhjo.Common

Public Class UcMark
    Inherits UcSubRecipe

#Region "VARIABLE"
    Private m_OTool As CRecipeDesignTool = Nothing
    Private m_ORecipe As CogPMAlignTool = Nothing

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
    Private Sub BtnTrainROI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTrainROI.Click
        Try
            If (Me.m_OTool.CdpDesign.Image Is Nothing) Then
                CMsgBox.Warning("Please set image to train!")
                Return
            End If

            If (Me.BtnTrainROI.Text = "Image Grab") Then
                Me.BtnTrainROI.Text = "Train"

                Me.m_ORecipe.Pattern.TrainImage = Me.m_ORecipe.InputImage
                Me.m_OTool.CdpDesign.InteractiveGraphics.Add _
                ( _
                    CType(Me.m_ORecipe.Pattern.TrainRegion, Cognex.VisionPro.ICogGraphicInteractive), _
                    "ROI", _
                    True _
                )
                Me.CdpTrain.Image = Nothing

            Else
                Me.BtnTrainROI.Text = "Image Grab"

                Dim OBound As CogRectangle = CType(Me.m_ORecipe.Pattern.TrainRegion, Cognex.VisionPro.ICogRegion).EnclosingRectangle(CogCopyShapeConstants.All)
                Me.m_ORecipe.Pattern.Origin.TranslationX = OBound.CenterX
                Me.m_ORecipe.Pattern.Origin.TranslationY = OBound.CenterY
                Me.m_ORecipe.Pattern.Train()

                Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()
                ' 트레인 이미지 적용
                Me.CdpTrain.Image = Me.m_ORecipe.Pattern.GetTrainedPatternImage()
                ' jht 센터 라인 적용
                Me.CdpTrain.InteractiveGraphics.Clear()
                Dim objCenterLineX As CogLine = New CogLine()
                objCenterLineX.X = Me.m_ORecipe.Pattern.Origin.TranslationX
                objCenterLineX.Rotation = CogMisc.DegToRad(90)
                objCenterLineX.Color = CogColorConstants.Green
                objCenterLineX.LineStyle = CogGraphicLineStyleConstants.Dot
                objCenterLineX.Interactive = False
                Me.CdpTrain.InteractiveGraphics.Add(objCenterLineX, "LineX", True)
                Dim objCenterLineY As CogLine = New CogLine()
                objCenterLineY.Y = Me.m_ORecipe.Pattern.Origin.TranslationY
                objCenterLineY.Rotation = CogMisc.DegToRad(0)
                objCenterLineY.Color = CogColorConstants.Green
                objCenterLineY.LineStyle = CogGraphicLineStyleConstants.Dot
                objCenterLineY.Interactive = False
                Me.CdpTrain.InteractiveGraphics.Add(objCenterLineY, "LineY", True)
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "ETC EVENT"
    Private Sub ChkPolarity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPolarity.CheckedChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_ORecipe.Pattern.IgnorePolarity = Me.ChkPolarity.Checked

            If (Me.ChkPolarity.Checked = True) Then
                Me.ChkPolarity.Text = "Ignore"
            Else
                Me.ChkPolarity.Text = "Apply"
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub NudAcceptThreshold_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudAcceptThreshold.ValueChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_ORecipe.RunParams.AcceptThreshold = Convert.ToDouble(Me.NudAcceptThreshold.Value)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub ChkCoarseThreshold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCoarseThreshold.CheckedChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_BPreventEvent = True

            If (Me.ChkCoarseThreshold.Checked = True) Then
                Me.m_ORecipe.RunParams.CoarseAcceptThresholdEnabled = True

                Me.NudCoarseTheshold.Value = Me.m_ORecipe.RunParams.CoarseAcceptThreshold
                Me.NudCoarseTheshold.Controls(1).Text = Me.NudCoarseTheshold.Value.ToString("0.00")
                Me.NudCoarseTheshold.Enabled = True
            Else
                Me.m_ORecipe.RunParams.CoarseAcceptThresholdEnabled = False

                Me.NudCoarseTheshold.Controls(1).Text = String.Empty
                Me.NudCoarseTheshold.Enabled = False
            End If
        Catch ex As Exception
            CError.Show(ex)
        Finally
            Me.m_BPreventEvent = False
        End Try
    End Sub


    Private Sub NudCoarseTheshold_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NudCoarseTheshold.ValueChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_ORecipe.RunParams.CoarseAcceptThreshold = Convert.ToDouble(Me.NudCoarseTheshold.Value)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub ChkClutter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkClutter.CheckedChanged
        If (Me.m_ORecipe Is Nothing) Then Return
        If (Me.m_BPreventEvent = True) Then Return

        Try
            Me.m_ORecipe.RunParams.ScoreUsingClutter = Me.ChkClutter.Checked

            If (Me.ChkClutter.Checked = True) Then
                Me.ChkClutter.Text = "Use"
            Else
                Me.ChkClutter.Text = "Not Use"
            End If
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
                        Select Case (Me.m_OTool.EMark)
                            Case EMARK.INDEX1
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool1
                            Case EMARK.INDEX2
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool2
                            Case EMARK.INDEX3
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool3
                            Case EMARK.INDEX4
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool4
                        End Select
                    Else
                        Select Case (Me.m_OTool.EMark)
                            Case EMARK.INDEX1
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool1
                            Case EMARK.INDEX2
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool2
                            Case EMARK.INDEX3
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool3
                            Case EMARK.INDEX4
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool4
                        End Select
                    End If
                Else
                    If (Me.m_OTool.EView = EVIEW.LEFT) Then
                        Select Case (Me.m_OTool.EMark)
                            Case EMARK.INDEX1
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool1
                            Case EMARK.INDEX2
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool2
                            Case EMARK.INDEX3
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool3
                            Case EMARK.INDEX4
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool4
                        End Select
                    Else
                        Select Case (Me.m_OTool.EMark)
                            Case EMARK.INDEX1
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool1
                            Case EMARK.INDEX2
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool2
                            Case EMARK.INDEX3
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool3
                            Case EMARK.INDEX4
                                Me.m_ORecipe = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool4
                        End Select
                    End If
                End If


                Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()
                Me.m_OTool.CdpDesign.Image = Me.m_ORecipe.InputImage


                If (Me.m_ORecipe.Pattern.Trained = True) Then
                    Me.CdpTrain.Image = Me.m_ORecipe.Pattern.GetTrainedPatternImage()
                Else
                    Me.CdpTrain.Image = Nothing
                End If

                ' jht 센터 라인 적용
                Me.CdpTrain.InteractiveGraphics.Clear()
                Dim objCenterLineX As CogLine = New CogLine()
                objCenterLineX.X = Me.m_ORecipe.Pattern.Origin.TranslationX
                objCenterLineX.Rotation = CogMisc.DegToRad(90)
                objCenterLineX.Color = CogColorConstants.Green
                objCenterLineX.LineStyle = CogGraphicLineStyleConstants.Dot
                objCenterLineX.Interactive = False
                Me.CdpTrain.InteractiveGraphics.Add(objCenterLineX, "LineX", True)
                Dim objCenterLineY As CogLine = New CogLine()
                objCenterLineY.Y = Me.m_ORecipe.Pattern.Origin.TranslationY
                objCenterLineY.Rotation = CogMisc.DegToRad(0)
                objCenterLineY.Color = CogColorConstants.Green
                objCenterLineY.LineStyle = CogGraphicLineStyleConstants.Dot
                objCenterLineY.Interactive = False
                Me.CdpTrain.InteractiveGraphics.Add(objCenterLineY, "LineY", True)

                Me.BtnTrainROI.Text = "Image Grab"
                Me.BtnTrainROI.BackColor = Color.SteelBlue
                Me.BtnTrainROI.Enabled = True

                If (Me.m_ORecipe.Pattern.IgnorePolarity = True) Then
                    Me.ChkPolarity.Text = "Ignore"
                    Me.ChkPolarity.Checked = True
                    Me.ChkPolarity.BackColor = Color.SteelBlue
                    Me.ChkPolarity.Enabled = True
                Else
                    Me.ChkPolarity.Text = "Apply"
                    Me.ChkPolarity.Checked = False
                    Me.ChkPolarity.BackColor = Color.SteelBlue
                    Me.ChkPolarity.Enabled = True
                End If

                Me.NudAcceptThreshold.Value = Me.m_ORecipe.RunParams.AcceptThreshold
                Me.NudAcceptThreshold.Controls(1).Text = Me.NudAcceptThreshold.Value.ToString("0.00")
                Me.NudAcceptThreshold.Enabled = True

                If (Me.m_ORecipe.RunParams.CoarseAcceptThresholdEnabled = True) Then
                    Me.ChkCoarseThreshold.Checked = True
                    Me.ChkCoarseThreshold.Enabled = True

                    Me.NudCoarseTheshold.Value = Me.m_ORecipe.RunParams.CoarseAcceptThreshold
                    Me.NudCoarseTheshold.Controls(1).Text = Me.NudCoarseTheshold.Value.ToString("0.00")
                    Me.NudCoarseTheshold.Enabled = True
                Else
                    Me.ChkCoarseThreshold.Checked = False
                    Me.ChkCoarseThreshold.Enabled = True

                    Me.NudCoarseTheshold.Controls(1).Text = String.Empty
                    Me.NudCoarseTheshold.Enabled = False
                End If

                If (Me.m_ORecipe.RunParams.ScoreUsingClutter = True) Then
                    Me.ChkClutter.Text = "Use"
                    Me.ChkClutter.Checked = True
                    Me.ChkClutter.BackColor = Color.SteelBlue
                    Me.ChkClutter.Enabled = True
                Else
                    Me.ChkClutter.Text = "Not Use"
                    Me.ChkClutter.Checked = False
                    Me.ChkClutter.BackColor = Color.SteelBlue
                    Me.ChkClutter.Enabled = True
                End If
            Else
                Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()

                Me.CdpTrain.Image = Nothing

                Me.BtnTrainROI.Text = "Image Grab"
                Me.BtnTrainROI.BackColor = SystemColors.Control
                Me.BtnTrainROI.Enabled = False

                Me.ChkPolarity.Text = "Apply"
                Me.ChkPolarity.Checked = False
                Me.ChkPolarity.BackColor = SystemColors.Control
                Me.ChkPolarity.Enabled = False

                Me.NudAcceptThreshold.Controls(1).Text = String.Empty
                Me.NudAcceptThreshold.Enabled = False

                Me.ChkCoarseThreshold.Checked = False
                Me.ChkCoarseThreshold.Enabled = False

                Me.NudCoarseTheshold.Controls(1).Text = String.Empty
                Me.NudCoarseTheshold.Enabled = False

                Me.ChkClutter.Text = "Not Use"
                Me.ChkClutter.Checked = False
                Me.ChkClutter.BackColor = SystemColors.Control
                Me.ChkClutter.Enabled = False
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
                If (Me.BtnTrainROI.Text = "Train") Then
                    Me.m_ORecipe.Pattern.TrainImage = OImage
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region
    
End Class
