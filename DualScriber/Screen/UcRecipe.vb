Imports System.IO
Imports Cognex.VisionPro
Imports Jhjo.Common


Public Class UcRecipe
    Inherits UcScreen

#Region "VARIABLE"
    Private m_OTool As CRecipeDesignTool = Nothing
    Private m_EEdit As EEDIT = EEDIT.NONE
    Private m_BIsDetail As Boolean = False

    Private m_OScreen As UcSubRecipe = Nothing
    Private m_OMark As UcMark = Nothing
    Private m_OEdge As UcEdge = Nothing
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()

        Try
            Me.m_OTool = New CRecipeDesignTool(Me.CdpDesign)

            Me.m_OMark = New UcMark(Me.m_OTool)
            Me.m_OMark.Dock = DockStyle.Fill
            Me.m_OEdge = New UcEdge(Me.m_OTool)
            Me.m_OEdge.Dock = DockStyle.Fill
            Me.SetScreen(Me.m_OMark)


            Me.UpdateList()

            If (Me.LtbList.Items.Count > 0) Then
                Me.NudID.Value = 1
                Me.TxtName.Text = String.Empty
                Me.BtnAdd.BackColor = Color.SteelBlue
                Me.BtnModify.BackColor = Color.SteelBlue
                Me.BtnDelete.BackColor = Color.SteelBlue
                Me.BtnSave.BackColor = SystemColors.Control
                Me.BtnCancel.BackColor = SystemColors.Control
                Me.BtnRename.BackColor = Color.SteelBlue
                Me.BtnCopy.BackColor = Color.SteelBlue
                Me.BtnApply.BackColor = Color.SteelBlue

                Me.NudID.Enabled = True
                Me.TxtName.Enabled = True
                Me.BtnAdd.Enabled = True
                Me.BtnModify.Enabled = True
                Me.BtnDelete.Enabled = True
                Me.BtnSave.Enabled = False
                Me.BtnCancel.Enabled = False
                Me.BtnRename.Enabled = True
                Me.BtnCopy.Enabled = True
                Me.BtnApply.Enabled = True
            Else
                Me.NudID.Value = 1
                Me.TxtName.Text = String.Empty
                Me.BtnAdd.BackColor = Color.SteelBlue
                Me.BtnModify.BackColor = SystemColors.Control
                Me.BtnDelete.BackColor = SystemColors.Control
                Me.BtnSave.BackColor = SystemColors.Control
                Me.BtnCancel.BackColor = SystemColors.Control
                Me.BtnRename.BackColor = SystemColors.Control
                Me.BtnCopy.BackColor = SystemColors.Control
                Me.BtnApply.BackColor = SystemColors.Control

                Me.NudID.Enabled = True
                Me.TxtName.Enabled = True
                Me.BtnAdd.Enabled = True
                Me.BtnModify.Enabled = False
                Me.BtnDelete.Enabled = False
                Me.BtnSave.Enabled = False
                Me.BtnCancel.Enabled = False
                Me.BtnRename.Enabled = False
                Me.BtnCopy.Enabled = False
                Me.BtnApply.Enabled = False
            End If

            Me.BtnCameraALeft.BackColor = SystemColors.Control
            Me.BtnCameraARight.BackColor = SystemColors.Control
            Me.BtnCameraBLeft.BackColor = SystemColors.Control
            Me.BtnCameraBRight.BackColor = SystemColors.Control
            Me.BtnToolMark.BackColor = SystemColors.Control
            Me.BtnToolEdge.BackColor = SystemColors.Control
            Me.BtnImageGrab.BackColor = SystemColors.Control
            Me.BtnToolDetail.BackColor = SystemColors.Control
            Me.BtnIndex1.BackColor = SystemColors.Control
            Me.BtnIndex2.BackColor = SystemColors.Control
            Me.BtnIndex3.BackColor = SystemColors.Control
            Me.BtnIndex4.BackColor = SystemColors.Control
            Me.NudAAlignmentLeftXLimit.Controls(1).Text = String.Empty
            Me.NudAAlignmentRightXLimit.Controls(1).Text = String.Empty
            Me.NudAAlignmentYLimit.Controls(1).Text = String.Empty
            Me.NudAAlignmentTLimit.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftTopMin.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftTopMax.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftBottomMin.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftBottomMax.Controls(1).Text = String.Empty
            Me.NudAEdgeRightTopMin.Controls(1).Text = String.Empty
            Me.NudAEdgeRightTopMax.Controls(1).Text = String.Empty
            Me.NudAEdgeRightBottomMin.Controls(1).Text = String.Empty
            Me.NudAEdgeRightBottomMax.Controls(1).Text = String.Empty
            Me.NudBAlignmentLeftXLimit.Controls(1).Text = String.Empty
            Me.NudBAlignmentRightXLimit.Controls(1).Text = String.Empty
            Me.NudBAlignmentYLimit.Controls(1).Text = String.Empty
            Me.NudBAlignmentTLimit.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftTopMin.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftTopMax.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftBottomMin.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftBottomMax.Controls(1).Text = String.Empty
            Me.NudBEdgeRightTopMin.Controls(1).Text = String.Empty
            Me.NudBEdgeRightTopMax.Controls(1).Text = String.Empty
            Me.NudBEdgeRightBottomMin.Controls(1).Text = String.Empty
            Me.NudBEdgeRightBottomMax.Controls(1).Text = String.Empty

            Me.BtnCameraALeft.Enabled = False
            Me.BtnCameraARight.Enabled = False
            Me.BtnCameraBLeft.Enabled = False
            Me.BtnCameraBRight.Enabled = False
            Me.BtnToolMark.Enabled = False
            Me.BtnToolEdge.Enabled = False
            Me.BtnImageGrab.Enabled = False
            Me.BtnToolDetail.Enabled = False
            Me.BtnIndex1.Enabled = False
            Me.BtnIndex2.Enabled = False
            Me.BtnIndex3.Enabled = False
            Me.BtnIndex4.Enabled = False
            Me.CpePattern.Enabled = False
            Me.CceCaliper.Enabled = False
            Me.NudAAlignmentLeftXLimit.Enabled = False
            Me.NudAAlignmentRightXLimit.Enabled = False
            Me.NudAAlignmentYLimit.Enabled = False
            Me.NudAAlignmentTLimit.Enabled = False
            Me.NudAEdgeLeftTopMin.Enabled = False
            Me.NudAEdgeLeftTopMax.Enabled = False
            Me.NudAEdgeLeftBottomMin.Enabled = False
            Me.NudAEdgeLeftBottomMax.Enabled = False
            Me.NudAEdgeRightTopMin.Enabled = False
            Me.NudAEdgeRightTopMax.Enabled = False
            Me.NudAEdgeRightBottomMin.Enabled = False
            Me.NudAEdgeRightBottomMax.Enabled = False
            Me.NudBAlignmentLeftXLimit.Enabled = False
            Me.NudBAlignmentRightXLimit.Enabled = False
            Me.NudBAlignmentYLimit.Enabled = False
            Me.NudBAlignmentTLimit.Enabled = False
            Me.NudBEdgeLeftTopMin.Enabled = False
            Me.NudBEdgeLeftTopMax.Enabled = False
            Me.NudBEdgeLeftBottomMin.Enabled = False
            Me.NudBEdgeLeftBottomMax.Enabled = False
            Me.NudBEdgeRightTopMin.Enabled = False
            Me.NudBEdgeRightTopMax.Enabled = False
            Me.NudBEdgeRightBottomMin.Enabled = False
            Me.NudBEdgeRightBottomMax.Enabled = False
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "EVENT"
#Region "BUTTON EVENT"
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            Dim I32ID As Integer = Me.NudID.Value
            For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                If (Not _Item.I32ID = I32ID) Then Continue For

                CMsgBox.Warning("A recipe has same ID is already existed!")
                Return
            Next

            Dim StrName As String = Me.TxtName.Text.Trim()
            If (String.IsNullOrEmpty(StrName) = True) Then
                CMsgBox.Warning("Please input 'Name' of new recipe!")
                Return
            End If


            Me.m_EEdit = EEDIT.ADD
            Me.m_OTool.ORecipe = New CRecipe(I32ID, StrName)
            Me.m_OTool.ORecipe.Create()
            Me.m_OTool.EStage = ESTAGE.A
            Me.m_OTool.EView = EVIEW.LEFT
            Me.m_OTool.ETool = ETOOL.MARK
            Me.m_OTool.EMark = EMARK.INDEX1

            Me.m_OScreen.DoRefresh()


            Me.BtnAdd.BackColor = SystemColors.Control
            Me.BtnModify.BackColor = SystemColors.Control
            Me.BtnDelete.BackColor = SystemColors.Control
            Me.BtnSave.BackColor = Color.SteelBlue
            Me.BtnCancel.BackColor = Color.SteelBlue
            Me.BtnRename.BackColor = SystemColors.Control
            Me.BtnCopy.BackColor = SystemColors.Control
            Me.BtnApply.BackColor = SystemColors.Control
            Me.NudID.Enabled = False
            Me.TxtName.Enabled = False
            Me.BtnAdd.Enabled = False
            Me.BtnModify.Enabled = False
            Me.BtnDelete.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnRename.Enabled = False
            Me.BtnCopy.Enabled = False
            Me.BtnApply.Enabled = False

            Me.BtnCameraALeft.BackColor = Color.ForestGreen
            Me.BtnCameraARight.BackColor = Color.SteelBlue
            Me.BtnCameraBLeft.BackColor = Color.SteelBlue
            Me.BtnCameraBRight.BackColor = Color.SteelBlue
            Me.BtnToolMark.BackColor = Color.ForestGreen
            Me.BtnToolEdge.BackColor = Color.SteelBlue
            Me.BtnImageGrab.BackColor = Color.SteelBlue
            Me.BtnToolDetail.BackColor = Color.SteelBlue
            Me.BtnIndex1.BackColor = Color.ForestGreen
            Me.BtnIndex2.BackColor = Color.SteelBlue
            Me.BtnIndex3.BackColor = Color.SteelBlue
            Me.BtnIndex4.BackColor = Color.SteelBlue
            Me.NudAAlignmentLeftXLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentLeftXLimit
            Me.NudAAlignmentRightXLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentRightXLimit
            Me.NudAAlignmentYLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentYLimit
            Me.NudAAlignmentTLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentTLimit
            Me.NudAAlignmentLeftXLimit.Controls(1).Text = Me.NudAAlignmentLeftXLimit.Value.ToString("0.000")
            Me.NudAAlignmentRightXLimit.Controls(1).Text = Me.NudAAlignmentRightXLimit.Value.ToString("0.000")
            Me.NudAAlignmentYLimit.Controls(1).Text = Me.NudAAlignmentYLimit.Value.ToString("0.000")
            Me.NudAAlignmentTLimit.Controls(1).Text = Me.NudAAlignmentTLimit.Value.ToString("0.0000")
            Me.NudAEdgeLeftTopMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMin
            Me.NudAEdgeLeftTopMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMax
            Me.NudAEdgeLeftBottomMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMin
            Me.NudAEdgeLeftBottomMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMax
            Me.NudAEdgeRightTopMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMin
            Me.NudAEdgeRightTopMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMax
            Me.NudAEdgeRightBottomMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMin
            Me.NudAEdgeRightBottomMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMax
            Me.NudAEdgeLeftTopMin.Controls(1).Text = Me.NudAEdgeLeftTopMin.Value.ToString("0.000")
            Me.NudAEdgeLeftTopMax.Controls(1).Text = Me.NudAEdgeLeftTopMax.Value.ToString("0.000")
            Me.NudAEdgeLeftBottomMin.Controls(1).Text = Me.NudAEdgeLeftBottomMin.Value.ToString("0.000")
            Me.NudAEdgeLeftBottomMax.Controls(1).Text = Me.NudAEdgeLeftBottomMax.Value.ToString("0.000")
            Me.NudAEdgeRightTopMin.Controls(1).Text = Me.NudAEdgeRightTopMin.Value.ToString("0.000")
            Me.NudAEdgeRightTopMax.Controls(1).Text = Me.NudAEdgeRightTopMax.Value.ToString("0.000")
            Me.NudAEdgeRightBottomMin.Controls(1).Text = Me.NudAEdgeRightBottomMin.Value.ToString("0.000")
            Me.NudAEdgeRightBottomMax.Controls(1).Text = Me.NudAEdgeRightBottomMax.Value.ToString("0.000")
            Me.NudBAlignmentLeftXLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentLeftXLimit
            Me.NudBAlignmentRightXLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentRightXLimit
            Me.NudBAlignmentYLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentYLimit
            Me.NudBAlignmentTLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentTLimit
            Me.NudBAlignmentLeftXLimit.Controls(1).Text = Me.NudBAlignmentLeftXLimit.Value.ToString("0.000")
            Me.NudBAlignmentRightXLimit.Controls(1).Text = Me.NudBAlignmentRightXLimit.Value.ToString("0.000")
            Me.NudBAlignmentYLimit.Controls(1).Text = Me.NudBAlignmentYLimit.Value.ToString("0.000")
            Me.NudBAlignmentTLimit.Controls(1).Text = Me.NudBAlignmentTLimit.Value.ToString("0.0000")
            Me.NudBEdgeLeftTopMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMin
            Me.NudBEdgeLeftTopMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMax
            Me.NudBEdgeLeftBottomMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMin
            Me.NudBEdgeLeftBottomMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMax
            Me.NudBEdgeRightTopMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMin
            Me.NudBEdgeRightTopMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMax
            Me.NudBEdgeRightBottomMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMin
            Me.NudBEdgeRightBottomMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMax
            Me.NudBEdgeLeftTopMin.Controls(1).Text = Me.NudBEdgeLeftTopMin.Value.ToString("0.000")
            Me.NudBEdgeLeftTopMax.Controls(1).Text = Me.NudBEdgeLeftTopMax.Value.ToString("0.000")
            Me.NudBEdgeLeftBottomMin.Controls(1).Text = Me.NudBEdgeLeftBottomMin.Value.ToString("0.000")
            Me.NudBEdgeLeftBottomMax.Controls(1).Text = Me.NudBEdgeLeftBottomMax.Value.ToString("0.000")
            Me.NudBEdgeRightTopMin.Controls(1).Text = Me.NudBEdgeRightTopMin.Value.ToString("0.000")
            Me.NudBEdgeRightTopMax.Controls(1).Text = Me.NudBEdgeRightTopMax.Value.ToString("0.000")
            Me.NudBEdgeRightBottomMin.Controls(1).Text = Me.NudBEdgeRightBottomMin.Value.ToString("0.000")
            Me.NudBEdgeRightBottomMax.Controls(1).Text = Me.NudBEdgeRightBottomMax.Value.ToString("0.000")
            Me.BtnCameraALeft.Enabled = True
            Me.BtnCameraARight.Enabled = True
            Me.BtnCameraBLeft.Enabled = True
            Me.BtnCameraBRight.Enabled = True
            Me.BtnToolMark.Enabled = True
            Me.BtnToolEdge.Enabled = True
            Me.BtnImageGrab.Enabled = True
            Me.BtnToolDetail.Enabled = True
            Me.BtnIndex1.Enabled = True
            Me.BtnIndex2.Enabled = True
            Me.BtnIndex3.Enabled = True
            Me.BtnIndex4.Enabled = True
            Me.CpePattern.Enabled = True
            Me.CceCaliper.Enabled = True
            Me.NudAAlignmentLeftXLimit.Enabled = True
            Me.NudAAlignmentRightXLimit.Enabled = True
            Me.NudAAlignmentYLimit.Enabled = True
            Me.NudAAlignmentTLimit.Enabled = True
            Me.NudAEdgeLeftTopMin.Enabled = True
            Me.NudAEdgeLeftTopMax.Enabled = True
            Me.NudAEdgeLeftBottomMin.Enabled = True
            Me.NudAEdgeLeftBottomMax.Enabled = True
            Me.NudAEdgeRightTopMin.Enabled = True
            Me.NudAEdgeRightTopMax.Enabled = True
            Me.NudAEdgeRightBottomMin.Enabled = True
            Me.NudAEdgeRightBottomMax.Enabled = True
            Me.NudBAlignmentLeftXLimit.Enabled = True
            Me.NudBAlignmentRightXLimit.Enabled = True
            Me.NudBAlignmentYLimit.Enabled = True
            Me.NudBAlignmentTLimit.Enabled = True
            Me.NudBEdgeLeftTopMin.Enabled = True
            Me.NudBEdgeLeftTopMax.Enabled = True
            Me.NudBEdgeLeftBottomMin.Enabled = True
            Me.NudBEdgeLeftBottomMax.Enabled = True
            Me.NudBEdgeRightTopMin.Enabled = True
            Me.NudBEdgeRightTopMax.Enabled = True
            Me.NudBEdgeRightBottomMin.Enabled = True
            Me.NudBEdgeRightBottomMax.Enabled = True

            MyBase.OnScreenFixed(ESCREEN.RECIPE, True)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModify.Click
        Try
            Dim StrItem As String = CType(Me.LtbList.SelectedItem, String)
            If (String.IsNullOrEmpty(StrItem) = True) Then
                CMsgBox.Warning("Please select a recipe to modify!")
                Return
            End If


            Dim I32ID As Integer = Convert.ToInt32(StrItem.Substring(0, StrItem.IndexOf(".")))
            For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                If (Not _Item.I32ID = I32ID) Then Continue For

                Me.m_EEdit = EEDIT.MODIFY
                Me.m_OTool.ORecipe = New CRecipe(_Item)
                Me.m_OTool.ORecipe.Load()
                Me.m_OTool.EStage = ESTAGE.A
                Me.m_OTool.EView = EVIEW.LEFT
                Me.m_OTool.ETool = ETOOL.MARK
                Me.m_OTool.EMark = EMARK.INDEX1

                Me.m_OScreen.DoRefresh()
                Exit For
            Next


            Me.NudID.Value = Me.m_OTool.ORecipe.I32ID
            Me.TxtName.Text = Me.m_OTool.ORecipe.StrName
            Me.BtnAdd.BackColor = SystemColors.Control
            Me.BtnModify.BackColor = SystemColors.Control
            Me.BtnDelete.BackColor = SystemColors.Control
            Me.BtnSave.BackColor = Color.SteelBlue
            Me.BtnCancel.BackColor = Color.SteelBlue
            Me.BtnRename.BackColor = SystemColors.Control
            Me.BtnCopy.BackColor = SystemColors.Control
            Me.BtnApply.BackColor = SystemColors.Control
            Me.NudID.Enabled = False
            Me.TxtName.Enabled = False
            Me.BtnAdd.Enabled = False
            Me.BtnModify.Enabled = False
            Me.BtnDelete.Enabled = False
            Me.BtnSave.Enabled = True
            Me.BtnCancel.Enabled = True
            Me.BtnRename.Enabled = False
            Me.BtnCopy.Enabled = False
            Me.BtnApply.Enabled = False

            Me.BtnCameraALeft.BackColor = Color.ForestGreen
            Me.BtnCameraARight.BackColor = Color.SteelBlue
            Me.BtnCameraBLeft.BackColor = Color.SteelBlue
            Me.BtnCameraBRight.BackColor = Color.SteelBlue
            Me.BtnToolMark.BackColor = Color.ForestGreen
            Me.BtnToolEdge.BackColor = Color.SteelBlue
            Me.BtnImageGrab.BackColor = Color.SteelBlue
            Me.BtnToolDetail.BackColor = Color.SteelBlue
            Me.BtnIndex1.BackColor = Color.ForestGreen
            Me.BtnIndex2.BackColor = Color.SteelBlue
            Me.BtnIndex3.BackColor = Color.SteelBlue
            Me.BtnIndex4.BackColor = Color.SteelBlue
            If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool1.Pattern.Trained = True) Then
                Me.CdpMark1.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool1.Pattern.GetTrainedPatternImage()
            End If
            If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool2.Pattern.Trained = True) Then
                Me.CdpMark2.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool2.Pattern.GetTrainedPatternImage()
            End If
            If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool3.Pattern.Trained = True) Then
                Me.CdpMark3.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool3.Pattern.GetTrainedPatternImage()
            End If
            If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool4.Pattern.Trained = True) Then
                Me.CdpMark4.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool4.Pattern.GetTrainedPatternImage()
            End If
            Me.NudAAlignmentLeftXLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentLeftXLimit
            Me.NudAAlignmentRightXLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentRightXLimit
            Me.NudAAlignmentYLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentYLimit
            Me.NudAAlignmentTLimit.Value = Me.m_OTool.ORecipe.OStageA.F64AlignmentTLimit
            Me.NudAAlignmentLeftXLimit.Controls(1).Text = Me.NudAAlignmentLeftXLimit.Value.ToString("0.000")
            Me.NudAAlignmentRightXLimit.Controls(1).Text = Me.NudAAlignmentRightXLimit.Value.ToString("0.000")
            Me.NudAAlignmentYLimit.Controls(1).Text = Me.NudAAlignmentYLimit.Value.ToString("0.000")
            Me.NudAAlignmentTLimit.Controls(1).Text = Me.NudAAlignmentTLimit.Value.ToString("0.0000")
            Me.NudAEdgeLeftTopMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMin
            Me.NudAEdgeLeftTopMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMax
            Me.NudAEdgeLeftBottomMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMin
            Me.NudAEdgeLeftBottomMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMax
            Me.NudAEdgeRightTopMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMin
            Me.NudAEdgeRightTopMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMax
            Me.NudAEdgeRightBottomMin.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMin
            Me.NudAEdgeRightBottomMax.Value = Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMax
            Me.NudAEdgeLeftTopMin.Controls(1).Text = Me.NudAEdgeLeftTopMin.Value.ToString("0.000")
            Me.NudAEdgeLeftTopMax.Controls(1).Text = Me.NudAEdgeLeftTopMax.Value.ToString("0.000")
            Me.NudAEdgeLeftBottomMin.Controls(1).Text = Me.NudAEdgeLeftBottomMin.Value.ToString("0.000")
            Me.NudAEdgeLeftBottomMax.Controls(1).Text = Me.NudAEdgeLeftBottomMax.Value.ToString("0.000")
            Me.NudAEdgeRightTopMin.Controls(1).Text = Me.NudAEdgeRightTopMin.Value.ToString("0.000")
            Me.NudAEdgeRightTopMax.Controls(1).Text = Me.NudAEdgeRightTopMax.Value.ToString("0.000")
            Me.NudAEdgeRightBottomMin.Controls(1).Text = Me.NudAEdgeRightBottomMin.Value.ToString("0.000")
            Me.NudAEdgeRightBottomMax.Controls(1).Text = Me.NudAEdgeRightBottomMax.Value.ToString("0.000")
            Me.NudBAlignmentLeftXLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentLeftXLimit
            Me.NudBAlignmentRightXLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentRightXLimit
            Me.NudBAlignmentYLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentYLimit
            Me.NudBAlignmentTLimit.Value = Me.m_OTool.ORecipe.OStageB.F64AlignmentTLimit
            Me.NudBAlignmentLeftXLimit.Controls(1).Text = Me.NudBAlignmentLeftXLimit.Value.ToString("0.000")
            Me.NudBAlignmentRightXLimit.Controls(1).Text = Me.NudBAlignmentRightXLimit.Value.ToString("0.000")
            Me.NudBAlignmentYLimit.Controls(1).Text = Me.NudBAlignmentYLimit.Value.ToString("0.000")
            Me.NudBAlignmentTLimit.Controls(1).Text = Me.NudBAlignmentTLimit.Value.ToString("0.0000")
            Me.NudBEdgeLeftTopMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMin
            Me.NudBEdgeLeftTopMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMax
            Me.NudBEdgeLeftBottomMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMin
            Me.NudBEdgeLeftBottomMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMax
            Me.NudBEdgeRightTopMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMin
            Me.NudBEdgeRightTopMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMax
            Me.NudBEdgeRightBottomMin.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMin
            Me.NudBEdgeRightBottomMax.Value = Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMax
            Me.NudBEdgeLeftTopMin.Controls(1).Text = Me.NudBEdgeLeftTopMin.Value.ToString("0.000")
            Me.NudBEdgeLeftTopMax.Controls(1).Text = Me.NudBEdgeLeftTopMax.Value.ToString("0.000")
            Me.NudBEdgeLeftBottomMin.Controls(1).Text = Me.NudBEdgeLeftBottomMin.Value.ToString("0.000")
            Me.NudBEdgeLeftBottomMax.Controls(1).Text = Me.NudBEdgeLeftBottomMax.Value.ToString("0.000")
            Me.NudBEdgeRightTopMin.Controls(1).Text = Me.NudBEdgeRightTopMin.Value.ToString("0.000")
            Me.NudBEdgeRightTopMax.Controls(1).Text = Me.NudBEdgeRightTopMax.Value.ToString("0.000")
            Me.NudBEdgeRightBottomMin.Controls(1).Text = Me.NudBEdgeRightBottomMin.Value.ToString("0.000")
            Me.NudBEdgeRightBottomMax.Controls(1).Text = Me.NudBEdgeRightBottomMax.Value.ToString("0.000")
            Me.BtnCameraALeft.Enabled = True
            Me.BtnCameraARight.Enabled = True
            Me.BtnCameraBLeft.Enabled = True
            Me.BtnCameraBRight.Enabled = True
            Me.BtnToolMark.Enabled = True
            Me.BtnToolEdge.Enabled = True
            Me.BtnImageGrab.Enabled = True
            Me.BtnToolDetail.Enabled = True
            Me.BtnIndex1.Enabled = True
            Me.BtnIndex2.Enabled = True
            Me.BtnIndex3.Enabled = True
            Me.BtnIndex4.Enabled = True
            Me.CpePattern.Enabled = True
            Me.CceCaliper.Enabled = True
            Me.NudAAlignmentLeftXLimit.Enabled = True
            Me.NudAAlignmentRightXLimit.Enabled = True
            Me.NudAAlignmentYLimit.Enabled = True
            Me.NudAAlignmentTLimit.Enabled = True
            Me.NudAEdgeLeftTopMin.Enabled = True
            Me.NudAEdgeLeftTopMax.Enabled = True
            Me.NudAEdgeLeftBottomMin.Enabled = True
            Me.NudAEdgeLeftBottomMax.Enabled = True
            Me.NudAEdgeRightTopMin.Enabled = True
            Me.NudAEdgeRightTopMax.Enabled = True
            Me.NudAEdgeRightBottomMin.Enabled = True
            Me.NudAEdgeRightBottomMax.Enabled = True
            Me.NudBAlignmentLeftXLimit.Enabled = True
            Me.NudBAlignmentRightXLimit.Enabled = True
            Me.NudBAlignmentYLimit.Enabled = True
            Me.NudBAlignmentTLimit.Enabled = True
            Me.NudBEdgeLeftTopMin.Enabled = True
            Me.NudBEdgeLeftTopMax.Enabled = True
            Me.NudBEdgeLeftBottomMin.Enabled = True
            Me.NudBEdgeLeftBottomMax.Enabled = True
            Me.NudBEdgeRightTopMin.Enabled = True
            Me.NudBEdgeRightTopMax.Enabled = True
            Me.NudBEdgeRightBottomMin.Enabled = True
            Me.NudBEdgeRightBottomMax.Enabled = True

            MyBase.OnScreenFixed(ESCREEN.RECIPE, True)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            Dim StrItem As String = CType(Me.LtbList.SelectedItem, String)
            If (String.IsNullOrEmpty(StrItem) = True) Then
                CMsgBox.Warning("Please select a recipe to delete!")
                Return
            End If

            Dim I32ID As Integer = Convert.ToInt32(StrItem.Substring(0, StrItem.IndexOf(".")))
            If ((Not CTool.It.ORecipe Is Nothing) AndAlso (CTool.It.ORecipe.I32ID = I32ID)) Then
                CMsgBox.Warning("Cannot delete a recipe to use currently!")
                Return
            End If

            If (CMsgBox.OKCancel("Do you want to delete '" & StrItem & "' recipe, Really?") = DialogResult.OK) Then
                CDB.It(CDB.TABLE_RECIPE_LIST).DeleteRow(CDB.RECIPE_LIST_ID, I32ID)
                CDB.It(CDB.TABLE_RECIPE_INFO).DeleteRow(CDB.RECIPE_INFO_ID, I32ID)
                CDB.It(CDB.TABLE_RECIPE_LIST).Commit()
                CDB.It(CDB.TABLE_RECIPE_INFO).Commit()

                For _Index As Integer = 0 To CRecipeManager.It.LstORecipe.Count - 1 Step 1
                    If (Not CRecipeManager.It.LstORecipe(_Index).I32ID = I32ID) Then Continue For

                    CRecipeManager.It.LstORecipe(_Index).Delete()
                    CRecipeManager.It.LstORecipe.RemoveAt(_Index)
                    Exit For
                Next

                Me.UpdateList()
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Me.m_OTool.ORecipe.OStageA.F64AlignmentLeftXLimit = Convert.ToDouble(Me.NudAAlignmentLeftXLimit.Value)
            Me.m_OTool.ORecipe.OStageA.F64AlignmentRightXLimit = Convert.ToDouble(Me.NudAAlignmentRightXLimit.Value)
            Me.m_OTool.ORecipe.OStageA.F64AlignmentYLimit = Convert.ToDouble(Me.NudAAlignmentYLimit.Value)
            Me.m_OTool.ORecipe.OStageA.F64AlignmentTLimit = Convert.ToDouble(Me.NudAAlignmentTLimit.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMin = Convert.ToDouble(Me.NudAEdgeLeftTopMin.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMax = Convert.ToDouble(Me.NudAEdgeLeftTopMax.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMin = Convert.ToDouble(Me.NudAEdgeLeftBottomMin.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMax = Convert.ToDouble(Me.NudAEdgeLeftBottomMax.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMin = Convert.ToDouble(Me.NudAEdgeRightTopMin.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMax = Convert.ToDouble(Me.NudAEdgeRightTopMax.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMin = Convert.ToDouble(Me.NudAEdgeRightBottomMin.Value)
            Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMax = Convert.ToDouble(Me.NudAEdgeRightBottomMax.Value)
            Me.m_OTool.ORecipe.OStageB.F64AlignmentLeftXLimit = Convert.ToDouble(Me.NudBAlignmentLeftXLimit.Value)
            Me.m_OTool.ORecipe.OStageB.F64AlignmentRightXLimit = Convert.ToDouble(Me.NudBAlignmentRightXLimit.Value)
            Me.m_OTool.ORecipe.OStageB.F64AlignmentYLimit = Convert.ToDouble(Me.NudBAlignmentYLimit.Value)
            Me.m_OTool.ORecipe.OStageB.F64AlignmentTLimit = Convert.ToDouble(Me.NudBAlignmentTLimit.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMin = Convert.ToDouble(Me.NudBEdgeLeftTopMin.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMax = Convert.ToDouble(Me.NudBEdgeLeftTopMax.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMin = Convert.ToDouble(Me.NudBEdgeLeftBottomMin.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMax = Convert.ToDouble(Me.NudBEdgeLeftBottomMax.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMin = Convert.ToDouble(Me.NudBEdgeRightTopMin.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMax = Convert.ToDouble(Me.NudBEdgeRightTopMax.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMin = Convert.ToDouble(Me.NudBEdgeRightBottomMin.Value)
            Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMax = Convert.ToDouble(Me.NudBEdgeRightBottomMax.Value)
            Me.m_OTool.ORecipe.Save()


            If (Me.m_EEdit = EEDIT.ADD) Then
                Dim I32RowIndex As Integer = CDB.It(CDB.TABLE_RECIPE_LIST).InsertRow()
                CDB.It(CDB.TABLE_RECIPE_LIST).Update(I32RowIndex, CDB.RECIPE_LIST_ID, Me.m_OTool.ORecipe.I32ID)
                CDB.It(CDB.TABLE_RECIPE_LIST).Update(I32RowIndex, CDB.RECIPE_LIST_NAME, Me.m_OTool.ORecipe.StrName)

                I32RowIndex = CDB.It(CDB.TABLE_RECIPE_INFO).InsertRow()
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ID, Me.m_OTool.ORecipe.I32ID)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_RECIPE, Me.m_OTool.ORecipe.StrName)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_STAGE, Me.m_OTool.ORecipe.OStageA.EStage.ToString())
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentLeftXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentRightXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentYLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentTLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMax)

                I32RowIndex = CDB.It(CDB.TABLE_RECIPE_INFO).InsertRow()
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ID, Me.m_OTool.ORecipe.I32ID)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_RECIPE, Me.m_OTool.ORecipe.StrName)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_STAGE, Me.m_OTool.ORecipe.OStageB.EStage.ToString())
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentLeftXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentRightXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentYLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentTLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMax)

                CDB.It(CDB.TABLE_RECIPE_LIST).Commit()
                CDB.It(CDB.TABLE_RECIPE_INFO).Commit()


                CRecipeManager.It.LstORecipe.Add(New CRecipe(Me.m_OTool.ORecipe))
                Me.UpdateList()
            ElseIf (Me.m_EEdit = EEDIT.MODIFY) Then
                Dim I32RowIndex As Integer = CDB.It(CDB.TABLE_RECIPE_INFO).SelectRowIndex _
                ( _
                    New String(1) {CDB.RECIPE_INFO_ID, CDB.RECIPE_INFO_STAGE}, _
                    New Object(1) {Me.m_OTool.ORecipe.I32ID, Me.m_OTool.ORecipe.OStageA.EStage.ToString()} _
                )
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentLeftXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentRightXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentYLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT, Me.m_OTool.ORecipe.OStageA.F64AlignmentTLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeLeftBottomMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeRightTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageA.F64EdgeRightBottomMax)

                I32RowIndex = CDB.It(CDB.TABLE_RECIPE_INFO).SelectRowIndex _
                ( _
                    New String(1) {CDB.RECIPE_INFO_ID, CDB.RECIPE_INFO_STAGE}, _
                    New Object(1) {Me.m_OTool.ORecipe.I32ID, Me.m_OTool.ORecipe.OStageB.EStage.ToString()} _
                )
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentLeftXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentRightXLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentYLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT, Me.m_OTool.ORecipe.OStageB.F64AlignmentTLimit)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeLeftBottomMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeRightTopMax)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN, Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMin)
                CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX, Me.m_OTool.ORecipe.OStageB.F64EdgeRightBottomMax)

                CDB.It(CDB.TABLE_RECIPE_INFO).Commit()


                For _Index As Integer = 0 To CRecipeManager.It.LstORecipe.Count - 1 Step 1
                    If (Not CRecipeManager.It.LstORecipe(_Index).I32ID = Me.m_OTool.ORecipe.I32ID) Then Continue For

                    CRecipeManager.It.LstORecipe(_Index) = New CRecipe(Me.m_OTool.ORecipe)
                    Exit For
                Next

                If ((Not CTool.It.ORecipe Is Nothing) AndAlso (CTool.It.ORecipe.I32ID = Me.m_OTool.ORecipe.I32ID)) Then
                    CTool.It.ORecipe = New CRecipe(Me.m_OTool.ORecipe)
                End If
            End If

            Me.BtnCancel.PerformClick()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Try
            If (Not Me.m_OTool.ORecipe Is Nothing) Then
                Me.m_OTool.ORecipe.Dispose()
                Me.m_OTool.ORecipe = Nothing
            End If


            Me.m_EEdit = EEDIT.NONE
            Me.m_OTool.EStage = ESTAGE.NONE
            Me.m_OTool.EView = EVIEW.NONE
            Me.m_OTool.ETool = ETOOL.NONE
            Me.m_OTool.EMark = EMARK.NONE
            Me.m_OTool.CdpDesign.Image = Nothing
            Me.m_OTool.CdpDesign.InteractiveGraphics.Clear()

            Me.m_BIsDetail = False
            Me.SetScreen(Me.m_OMark)
            Me.PnlScreen.BringToFront()
            Me.CdpDesign.BringToFront()
            Me.m_OScreen.DoRefresh()
            

            If (Me.LtbList.Items.Count > 0) Then
                Me.NudID.Value = 1
                Me.TxtName.Text = String.Empty
                Me.BtnAdd.BackColor = Color.SteelBlue
                Me.BtnModify.BackColor = Color.SteelBlue
                Me.BtnDelete.BackColor = Color.SteelBlue
                Me.BtnSave.BackColor = SystemColors.Control
                Me.BtnCancel.BackColor = SystemColors.Control
                Me.BtnRename.BackColor = Color.SteelBlue
                Me.BtnCopy.BackColor = Color.SteelBlue
                Me.BtnApply.BackColor = Color.SteelBlue
                Me.NudID.Enabled = True
                Me.TxtName.Enabled = True
                Me.BtnAdd.Enabled = True
                Me.BtnModify.Enabled = True
                Me.BtnDelete.Enabled = True
                Me.BtnSave.Enabled = False
                Me.BtnCancel.Enabled = False
                Me.BtnRename.Enabled = True
                Me.BtnCopy.Enabled = True
                Me.BtnApply.Enabled = True
            Else
                Me.NudID.Value = 1
                Me.TxtName.Text = String.Empty
                Me.BtnAdd.BackColor = Color.SteelBlue
                Me.BtnModify.BackColor = SystemColors.Control
                Me.BtnDelete.BackColor = SystemColors.Control
                Me.BtnSave.BackColor = SystemColors.Control
                Me.BtnCancel.BackColor = SystemColors.Control
                Me.BtnRename.BackColor = SystemColors.Control
                Me.BtnCopy.BackColor = SystemColors.Control
                Me.BtnApply.BackColor = SystemColors.Control
                Me.NudID.Enabled = True
                Me.TxtName.Enabled = True
                Me.BtnAdd.Enabled = True
                Me.BtnModify.Enabled = False
                Me.BtnDelete.Enabled = False
                Me.BtnSave.Enabled = False
                Me.BtnCancel.Enabled = False
                Me.BtnRename.Enabled = False
                Me.BtnCopy.Enabled = False
                Me.BtnApply.Enabled = False
            End If

            Me.BtnCameraALeft.BackColor = SystemColors.Control
            Me.BtnCameraARight.BackColor = SystemColors.Control
            Me.BtnCameraBLeft.BackColor = SystemColors.Control
            Me.BtnCameraBRight.BackColor = SystemColors.Control
            Me.BtnToolMark.BackColor = SystemColors.Control
            Me.BtnToolEdge.BackColor = SystemColors.Control
            Me.BtnImageGrab.BackColor = SystemColors.Control
            Me.BtnToolDetail.BackColor = SystemColors.Control
            Me.BtnIndex1.BackColor = SystemColors.Control
            Me.BtnIndex2.BackColor = SystemColors.Control
            Me.BtnIndex3.BackColor = SystemColors.Control
            Me.BtnIndex4.BackColor = SystemColors.Control
            Me.CdpMark1.Image = Nothing
            Me.CdpMark2.Image = Nothing
            Me.CdpMark3.Image = Nothing
            Me.CdpMark4.Image = Nothing
            Me.CpePattern.Subject = Nothing
            Me.CceCaliper.Subject = Nothing
            Me.NudAAlignmentLeftXLimit.Controls(1).Text = String.Empty
            Me.NudAAlignmentRightXLimit.Controls(1).Text = String.Empty
            Me.NudAAlignmentYLimit.Controls(1).Text = String.Empty
            Me.NudAAlignmentTLimit.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftTopMin.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftTopMax.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftBottomMin.Controls(1).Text = String.Empty
            Me.NudAEdgeLeftBottomMax.Controls(1).Text = String.Empty
            Me.NudAEdgeRightTopMin.Controls(1).Text = String.Empty
            Me.NudAEdgeRightTopMax.Controls(1).Text = String.Empty
            Me.NudAEdgeRightBottomMin.Controls(1).Text = String.Empty
            Me.NudAEdgeRightBottomMax.Controls(1).Text = String.Empty
            Me.NudBAlignmentLeftXLimit.Controls(1).Text = String.Empty
            Me.NudBAlignmentRightXLimit.Controls(1).Text = String.Empty
            Me.NudBAlignmentYLimit.Controls(1).Text = String.Empty
            Me.NudBAlignmentTLimit.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftTopMin.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftTopMax.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftBottomMin.Controls(1).Text = String.Empty
            Me.NudBEdgeLeftBottomMax.Controls(1).Text = String.Empty
            Me.NudBEdgeRightTopMin.Controls(1).Text = String.Empty
            Me.NudBEdgeRightTopMax.Controls(1).Text = String.Empty
            Me.NudBEdgeRightBottomMin.Controls(1).Text = String.Empty
            Me.NudBEdgeRightBottomMax.Controls(1).Text = String.Empty
            Me.BtnCameraALeft.Enabled = False
            Me.BtnCameraARight.Enabled = False
            Me.BtnCameraBLeft.Enabled = False
            Me.BtnCameraBRight.Enabled = False
            Me.BtnToolMark.Enabled = False
            Me.BtnToolEdge.Enabled = False
            Me.BtnImageGrab.Enabled = False
            Me.BtnToolDetail.Enabled = False
            Me.BtnIndex1.Enabled = False
            Me.BtnIndex2.Enabled = False
            Me.BtnIndex3.Enabled = False
            Me.BtnIndex4.Enabled = False
            Me.CpePattern.Enabled = False
            Me.CceCaliper.Enabled = False
            Me.NudAAlignmentLeftXLimit.Enabled = False
            Me.NudAAlignmentRightXLimit.Enabled = False
            Me.NudAAlignmentYLimit.Enabled = False
            Me.NudAAlignmentTLimit.Enabled = False
            Me.NudAEdgeLeftTopMin.Enabled = False
            Me.NudAEdgeLeftTopMax.Enabled = False
            Me.NudAEdgeLeftBottomMin.Enabled = False
            Me.NudAEdgeLeftBottomMax.Enabled = False
            Me.NudAEdgeRightTopMin.Enabled = False
            Me.NudAEdgeRightTopMax.Enabled = False
            Me.NudAEdgeRightBottomMin.Enabled = False
            Me.NudAEdgeRightBottomMax.Enabled = False
            Me.NudBAlignmentLeftXLimit.Enabled = False
            Me.NudBAlignmentRightXLimit.Enabled = False
            Me.NudBAlignmentYLimit.Enabled = False
            Me.NudBAlignmentTLimit.Enabled = False
            Me.NudBEdgeLeftTopMin.Enabled = False
            Me.NudBEdgeLeftTopMax.Enabled = False
            Me.NudBEdgeLeftBottomMin.Enabled = False
            Me.NudBEdgeLeftBottomMax.Enabled = False
            Me.NudBEdgeRightTopMin.Enabled = False
            Me.NudBEdgeRightTopMax.Enabled = False
            Me.NudBEdgeRightBottomMin.Enabled = False
            Me.NudBEdgeRightBottomMax.Enabled = False

            MyBase.OnScreenFixed(ESCREEN.RECIPE, False)
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRename.Click
        Try
            Dim StrItem As String = CType(Me.LtbList.SelectedItem, String)
            If (String.IsNullOrEmpty(StrItem) = True) Then
                CMsgBox.Warning("Please select a recipe for renaming.")
                Return
            End If

            Dim I32ID As Integer = Convert.ToInt32(StrItem.Substring(0, StrItem.IndexOf(".")))
            If ((Not CTool.It.ORecipe Is Nothing) AndAlso (CTool.It.ORecipe.I32ID = I32ID)) Then
                CMsgBox.Warning("Cannot rename a recipe that is currently on the use.")
                Return
            End If

            Dim StrNewName As String = Me.TxtName.Text.Trim()
            If (String.IsNullOrEmpty(StrNewName) = True) Then
                CMsgBox.Warning("Please write a new name in the 'Name' section.")
                Return
            End If


            If (CMsgBox.OKCancel("Are you sure you want to rename '" & StrItem & "' recipe?") = DialogResult.OK) Then
                Dim I32RowIndex As Integer = CDB.It(CDB.TABLE_RECIPE_LIST).SelectRowIndex(CDB.RECIPE_LIST_ID, I32ID)
                CDB.It(CDB.TABLE_RECIPE_LIST).Update(I32RowIndex, CDB.RECIPE_LIST_NAME, StrNewName)

                Dim LstI32RowIndex As List(Of Integer) = CDB.It(CDB.TABLE_RECIPE_INFO).SelectRowIndexs(CDB.RECIPE_INFO_ID, I32ID)
                For _Index As Integer = 0 To LstI32RowIndex.Count - 1 Step 1
                    CDB.It(CDB.TABLE_RECIPE_INFO).Update(LstI32RowIndex(_Index), CDB.RECIPE_INFO_RECIPE, StrNewName)
                Next

                CDB.It(CDB.TABLE_RECIPE_LIST).Commit()
                CDB.It(CDB.TABLE_RECIPE_INFO).Commit()


                For _Index As Integer = 0 To CRecipeManager.It.LstORecipe.Count - 1 Step 1
                    If (Not CRecipeManager.It.LstORecipe(_Index).I32ID = I32ID) Then Continue For

                    CRecipeManager.It.LstORecipe(_Index).StrName = StrNewName
                    Exit For
                Next

                Me.UpdateList()
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Try
            Dim I32ID As Integer = Me.NudID.Value
            For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                If (Not _Item.I32ID = I32ID) Then Continue For

                CMsgBox.Warning("A recipe has same ID is already existed!")
                Return
            Next

            Dim StrName As String = Me.TxtName.Text.Trim()
            If (String.IsNullOrEmpty(StrName) = True) Then
                CMsgBox.Warning("Please input 'Name' of new recipe!")
                Return
            End If

            Dim StrItem As String = CType(Me.LtbList.SelectedItem, String)
            If (String.IsNullOrEmpty(StrItem) = True) Then
                CMsgBox.Warning("Please select a recipe to be copy!")
                Return
            End If


            Dim I32SourceID As Integer = Convert.ToInt32(StrItem.Substring(0, StrItem.IndexOf(".")))
            Dim ORecipe As CRecipe = Nothing
            For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                If (Not _Item.I32ID = I32SourceID) Then Continue For

                ORecipe = New CRecipe(I32ID, StrName)
                ORecipe.Copy(_Item)
                Exit For
            Next


            Dim I32RowIndex As Integer = CDB.It(CDB.TABLE_RECIPE_LIST).InsertRow()
            CDB.It(CDB.TABLE_RECIPE_LIST).Update(I32RowIndex, CDB.RECIPE_LIST_ID, ORecipe.I32ID)
            CDB.It(CDB.TABLE_RECIPE_LIST).Update(I32RowIndex, CDB.RECIPE_LIST_NAME, ORecipe.StrName)

            I32RowIndex = CDB.It(CDB.TABLE_RECIPE_INFO).InsertRow()
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ID, ORecipe.I32ID)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_RECIPE, ORecipe.StrName)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_STAGE, ORecipe.OStageA.EStage.ToString())
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT, ORecipe.OStageA.F64AlignmentLeftXLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT, ORecipe.OStageA.F64AlignmentRightXLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT, ORecipe.OStageA.F64AlignmentYLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT, ORecipe.OStageA.F64AlignmentTLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN, ORecipe.OStageA.F64EdgeLeftTopMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX, ORecipe.OStageA.F64EdgeLeftTopMax)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN, ORecipe.OStageA.F64EdgeLeftBottomMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX, ORecipe.OStageA.F64EdgeLeftBottomMax)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN, ORecipe.OStageA.F64EdgeRightTopMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX, ORecipe.OStageA.F64EdgeRightTopMax)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN, ORecipe.OStageA.F64EdgeRightBottomMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX, ORecipe.OStageA.F64EdgeRightBottomMax)

            I32RowIndex = CDB.It(CDB.TABLE_RECIPE_INFO).InsertRow()
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ID, ORecipe.I32ID)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_RECIPE, ORecipe.StrName)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_STAGE, ORecipe.OStageB.EStage.ToString())
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_LEFTX_LIMIT, ORecipe.OStageB.F64AlignmentLeftXLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_RIGHTX_LIMIT, ORecipe.OStageB.F64AlignmentRightXLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_Y_LIMIT, ORecipe.OStageB.F64AlignmentYLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_ALIGNMENT_T_LIMIT, ORecipe.OStageB.F64AlignmentTLimit)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MIN, ORecipe.OStageB.F64EdgeLeftTopMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_TOP_MAX, ORecipe.OStageB.F64EdgeLeftTopMax)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MIN, ORecipe.OStageB.F64EdgeLeftBottomMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_LEFT_BOTTOM_MAX, ORecipe.OStageB.F64EdgeLeftBottomMax)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MIN, ORecipe.OStageB.F64EdgeRightTopMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_TOP_MAX, ORecipe.OStageB.F64EdgeRightTopMax)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MIN, ORecipe.OStageB.F64EdgeRightBottomMin)
            CDB.It(CDB.TABLE_RECIPE_INFO).Update(I32RowIndex, CDB.RECIPE_INFO_EDGE_RIGHT_BOTTOM_MAX, ORecipe.OStageB.F64EdgeRightBottomMax)

            CDB.It(CDB.TABLE_RECIPE_LIST).Commit()
            CDB.It(CDB.TABLE_RECIPE_INFO).Commit()


            CRecipeManager.It.LstORecipe.Add(ORecipe)
            Me.UpdateList()
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApply.Click
        Try
            Dim StrItem As String = CType(Me.LtbList.SelectedItem, String)
            If (String.IsNullOrEmpty(StrItem) = True) Then
                CMsgBox.Warning("Please select a recipe to be appiled!")
                Return
            End If


            Dim I32ID As Integer = Convert.ToInt32(StrItem.Substring(0, StrItem.IndexOf(".")))
            If ((CTool.It.ORecipe Is Nothing) OrElse (Not CTool.It.ORecipe.I32ID = I32ID)) Then
                For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                    If (Not _Item.I32ID = I32ID) Then Continue For

                    CTool.It.ORecipe = New CRecipe(_Item)
                    CMotionController.It.OPLC.SetVisionRecipeID(_Item.I32ID)
                    Exit For
                Next
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnCamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCameraALeft.Click, BtnCameraARight.Click, BtnCameraBLeft.Click, BtnCameraBRight.Click
        Try
            Dim StrTag As String = CType(CType(sender, Control).Tag, String)

            Select Case StrTag
                Case "A_LEFT"
                    If ((Me.m_OTool.EStage = DualScriber.ESTAGE.A) AndAlso (Me.m_OTool.EView = EVIEW.LEFT)) Then Return

                    Me.m_OTool.EStage = DualScriber.ESTAGE.A
                    Me.m_OTool.EView = EVIEW.LEFT
                    Me.m_OScreen.DoRefresh()

                    Me.BtnCameraALeft.BackColor = Color.ForestGreen
                    Me.BtnCameraARight.BackColor = Color.SteelBlue
                    Me.BtnCameraBLeft.BackColor = Color.SteelBlue
                    Me.BtnCameraBRight.BackColor = Color.SteelBlue

                    If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool1.Pattern.Trained = True) Then
                        Me.CdpMark1.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool1.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark1.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool2.Pattern.Trained = True) Then
                        Me.CdpMark2.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool2.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark2.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool3.Pattern.Trained = True) Then
                        Me.CdpMark3.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool3.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark3.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool4.Pattern.Trained = True) Then
                        Me.CdpMark4.Image = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool4.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark4.Image = Nothing
                    End If
                Case "A_RIGHT"
                    If ((Me.m_OTool.EStage = DualScriber.ESTAGE.A) AndAlso (Me.m_OTool.EView = EVIEW.RIGHT)) Then Return

                    Me.m_OTool.EStage = DualScriber.ESTAGE.A
                    Me.m_OTool.EView = EVIEW.RIGHT
                    Me.m_OScreen.DoRefresh()

                    Me.BtnCameraALeft.BackColor = Color.SteelBlue
                    Me.BtnCameraARight.BackColor = Color.ForestGreen
                    Me.BtnCameraBLeft.BackColor = Color.SteelBlue
                    Me.BtnCameraBRight.BackColor = Color.SteelBlue

                    If (Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool1.Pattern.Trained = True) Then
                        Me.CdpMark1.Image = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool1.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark1.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool2.Pattern.Trained = True) Then
                        Me.CdpMark2.Image = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool2.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark2.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool3.Pattern.Trained = True) Then
                        Me.CdpMark3.Image = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool3.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark3.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool4.Pattern.Trained = True) Then
                        Me.CdpMark4.Image = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool4.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark4.Image = Nothing
                    End If
                Case "B_LEFT"
                    If ((Me.m_OTool.EStage = DualScriber.ESTAGE.B) AndAlso (Me.m_OTool.EView = EVIEW.LEFT)) Then Return

                    Me.m_OTool.EStage = DualScriber.ESTAGE.B
                    Me.m_OTool.EView = EVIEW.LEFT
                    Me.m_OScreen.DoRefresh()

                    Me.BtnCameraALeft.BackColor = Color.SteelBlue
                    Me.BtnCameraARight.BackColor = Color.SteelBlue
                    Me.BtnCameraBLeft.BackColor = Color.ForestGreen
                    Me.BtnCameraBRight.BackColor = Color.SteelBlue

                    If (Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool1.Pattern.Trained = True) Then
                        Me.CdpMark1.Image = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool1.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark1.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool2.Pattern.Trained = True) Then
                        Me.CdpMark2.Image = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool2.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark2.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool3.Pattern.Trained = True) Then
                        Me.CdpMark3.Image = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool3.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark3.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool4.Pattern.Trained = True) Then
                        Me.CdpMark4.Image = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool4.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark4.Image = Nothing
                    End If
                Case "B_RIGHT"
                    If ((Me.m_OTool.EStage = DualScriber.ESTAGE.B) AndAlso (Me.m_OTool.EView = EVIEW.RIGHT)) Then Return

                    Me.m_OTool.EStage = DualScriber.ESTAGE.B
                    Me.m_OTool.EView = EVIEW.RIGHT
                    Me.m_OScreen.DoRefresh()

                    Me.BtnCameraALeft.BackColor = Color.SteelBlue
                    Me.BtnCameraARight.BackColor = Color.SteelBlue
                    Me.BtnCameraBLeft.BackColor = Color.SteelBlue
                    Me.BtnCameraBRight.BackColor = Color.ForestGreen

                    If (Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool1.Pattern.Trained = True) Then
                        Me.CdpMark1.Image = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool1.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark1.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool2.Pattern.Trained = True) Then
                        Me.CdpMark2.Image = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool2.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark2.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool3.Pattern.Trained = True) Then
                        Me.CdpMark3.Image = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool3.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark3.Image = Nothing
                    End If
                    If (Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool4.Pattern.Trained = True) Then
                        Me.CdpMark4.Image = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool4.Pattern.GetTrainedPatternImage()
                    Else
                        Me.CdpMark4.Image = Nothing
                    End If
            End Select


            Me.m_BIsDetail = False
            Me.PnlScreen.BringToFront()
            Me.CdpDesign.BringToFront()
            Me.BtnToolDetail.BackColor = Color.SteelBlue
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToolMark.Click, BtnToolEdge.Click
        Try
            Dim ETool As ETOOL = CType([Enum].Parse(GetType(ETOOL), CType(CType(sender, Control).Tag, String)), ETOOL)
            If (ETool = Me.m_OTool.ETool) Then Return

            Me.m_OTool.ETool = ETool
            If (Me.m_OTool.ETool = DualScriber.ETOOL.MARK) Then
                Me.SetScreen(Me.m_OMark)

                Me.BtnToolMark.BackColor = Color.ForestGreen
                Me.BtnToolEdge.BackColor = Color.SteelBlue

                Me.BtnIndex1.BackColor = Color.ForestGreen
                Me.BtnIndex2.BackColor = Color.SteelBlue
                Me.BtnIndex3.BackColor = Color.SteelBlue
                Me.BtnIndex4.BackColor = Color.SteelBlue
                Me.BtnIndex1.Enabled = True
                Me.BtnIndex2.Enabled = True
                Me.BtnIndex3.Enabled = True
                Me.BtnIndex4.Enabled = True
            Else
                Me.SetScreen(Me.m_OEdge)

                Me.BtnToolMark.BackColor = Color.SteelBlue
                Me.BtnToolEdge.BackColor = Color.ForestGreen

                Me.BtnIndex1.BackColor = SystemColors.Control
                Me.BtnIndex2.BackColor = SystemColors.Control
                Me.BtnIndex3.BackColor = SystemColors.Control
                Me.BtnIndex4.BackColor = SystemColors.Control
                Me.BtnIndex1.Enabled = False
                Me.BtnIndex2.Enabled = False
                Me.BtnIndex3.Enabled = False
                Me.BtnIndex4.Enabled = False
            End If

            Me.m_BIsDetail = False
            Me.PnlScreen.BringToFront()
            Me.CdpDesign.BringToFront()
            Me.BtnToolDetail.BackColor = Color.SteelBlue
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIndex1.Click, BtnIndex2.Click, BtnIndex3.Click, BtnIndex4.Click
        Try
            Dim EMark As EMARK = CType([Enum].Parse(GetType(EMARK), CType(CType(sender, Control).Tag, String)), EMARK)
            If (EMark = Me.m_OTool.EMark) Then Return

            Me.m_OTool.EMark = EMark
            Me.m_OScreen.DoRefresh()

            Select Case (Me.m_OTool.EMark)
                Case DualScriber.EMARK.INDEX1
                    Me.BtnIndex1.BackColor = Color.ForestGreen
                    Me.BtnIndex2.BackColor = Color.SteelBlue
                    Me.BtnIndex3.BackColor = Color.SteelBlue
                    Me.BtnIndex4.BackColor = Color.SteelBlue
                Case DualScriber.EMARK.INDEX2
                    Me.BtnIndex1.BackColor = Color.SteelBlue
                    Me.BtnIndex2.BackColor = Color.ForestGreen
                    Me.BtnIndex3.BackColor = Color.SteelBlue
                    Me.BtnIndex4.BackColor = Color.SteelBlue
                Case DualScriber.EMARK.INDEX3
                    Me.BtnIndex1.BackColor = Color.SteelBlue
                    Me.BtnIndex2.BackColor = Color.SteelBlue
                    Me.BtnIndex3.BackColor = Color.ForestGreen
                    Me.BtnIndex4.BackColor = Color.SteelBlue
                Case DualScriber.EMARK.INDEX4
                    Me.BtnIndex1.BackColor = Color.SteelBlue
                    Me.BtnIndex2.BackColor = Color.SteelBlue
                    Me.BtnIndex3.BackColor = Color.SteelBlue
                    Me.BtnIndex4.BackColor = Color.ForestGreen
            End Select

            Me.m_BIsDetail = False
            Me.PnlScreen.BringToFront()
            Me.CdpDesign.BringToFront()
            Me.BtnToolDetail.BackColor = Color.SteelBlue
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnGrab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImageGrab.Click
        Try
            If (Me.m_OTool.EStage = ESTAGE.A) Then
                If (Me.m_OTool.EView = EVIEW.LEFT) Then
                    Me.m_OScreen.SetImage(CTool.It.OStageA.OLeft.ODisplayer.OCurrentImage)
                ElseIf (Me.m_OTool.EView = EVIEW.RIGHT) Then
                    Me.m_OScreen.SetImage(CTool.It.OStageA.ORight.ODisplayer.OCurrentImage)
                End If
            ElseIf (Me.m_OTool.EStage = ESTAGE.B) Then
                If (Me.m_OTool.EView = EVIEW.LEFT) Then
                    Me.m_OScreen.SetImage(CTool.It.OStageB.OLeft.ODisplayer.OCurrentImage)
                ElseIf (Me.m_OTool.EView = EVIEW.RIGHT) Then
                    Me.m_OScreen.SetImage(CTool.It.OStageB.ORight.ODisplayer.OCurrentImage)
                End If
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnToolDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnToolDetail.Click
        Try
            If (Me.m_BIsDetail = False) Then
                Me.m_BIsDetail = True
                Me.BtnToolDetail.BackColor = Color.ForestGreen

                If (Me.m_OTool.EStage = ESTAGE.A) Then
                    If (Me.m_OTool.EView = EVIEW.LEFT) Then
                        If (Me.m_OTool.ETool = ETOOL.MARK) Then
                            Select Case (Me.m_OTool.EMark)
                                Case EMARK.INDEX1
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool1
                                Case EMARK.INDEX2
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool2
                                Case EMARK.INDEX3
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool3
                                Case EMARK.INDEX4
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.OLeft.OMarkTool4
                            End Select
                            Me.PnlToolMark.BringToFront()
                        Else
                            Me.CceCaliper.Subject = Me.m_OTool.ORecipe.OStageA.OLeft.OEdgeTool
                            Me.PnlToolEdge.BringToFront()
                        End If
                    Else
                        If (Me.m_OTool.ETool = ETOOL.MARK) Then
                            Select Case (Me.m_OTool.EMark)
                                Case EMARK.INDEX1
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool1
                                Case EMARK.INDEX2
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool2
                                Case EMARK.INDEX3
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool3
                                Case EMARK.INDEX4
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageA.ORight.OMarkTool4
                            End Select
                            Me.PnlToolMark.BringToFront()
                        Else
                            Me.CceCaliper.Subject = Me.m_OTool.ORecipe.OStageA.ORight.OEdgeTool
                            Me.PnlToolEdge.BringToFront()
                        End If
                    End If
                Else
                    If (Me.m_OTool.EView = EVIEW.LEFT) Then
                        If (Me.m_OTool.ETool = ETOOL.MARK) Then
                            Select Case (Me.m_OTool.EMark)
                                Case EMARK.INDEX1
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool1
                                Case EMARK.INDEX2
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool2
                                Case EMARK.INDEX3
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool3
                                Case EMARK.INDEX4
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.OLeft.OMarkTool4
                            End Select
                            Me.PnlToolMark.BringToFront()
                        Else
                            Me.CceCaliper.Subject = Me.m_OTool.ORecipe.OStageB.OLeft.OEdgeTool
                            Me.PnlToolEdge.BringToFront()
                        End If
                    Else
                        If (Me.m_OTool.ETool = ETOOL.MARK) Then
                            Select Case (Me.m_OTool.EMark)
                                Case EMARK.INDEX1
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool1
                                Case EMARK.INDEX2
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool2
                                Case EMARK.INDEX3
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool3
                                Case EMARK.INDEX4
                                    Me.CpePattern.Subject = Me.m_OTool.ORecipe.OStageB.ORight.OMarkTool4
                            End Select
                            Me.PnlToolMark.BringToFront()
                        Else
                            Me.CceCaliper.Subject = Me.m_OTool.ORecipe.OStageB.ORight.OEdgeTool
                            Me.PnlToolEdge.BringToFront()
                        End If
                    End If
                End If
            Else
                Me.m_BIsDetail = False
                Me.BtnToolDetail.BackColor = Color.SteelBlue

                Me.m_OScreen.DoRefresh()
                Me.PnlScreen.BringToFront()
                Me.CdpDesign.BringToFront()
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region
#End Region


#Region "FUNCTION"
    Private Sub SetScreen(ByVal OScreen As UcSubRecipe)
        Try
            If (Me.m_OScreen Is Nothing) Then
                OScreen.Add()
                Me.PnlScreen.Controls.Add(OScreen)
                Me.PnlScreen.BringToFront()
                Me.CdpDesign.BringToFront()
                Me.m_OScreen = OScreen
            Else
                If (Not Me.m_OScreen.GetType().Equals(OScreen.GetType())) Then
                    Me.m_OScreen.Remove()
                    OScreen.Add()

                    Me.PnlScreen.Controls.Add(OScreen)
                    OScreen.BringToFront()
                    Me.PnlScreen.BringToFront()
                    Me.CdpDesign.BringToFront()
                    Me.m_OScreen.Controls.Remove(Me.m_OScreen)

                    Me.m_OScreen = OScreen
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub UpdateList()
        Try
            Dim LstI32ID As List(Of Integer) = New List(Of Integer)
            For Each _Item As CRecipe In CRecipeManager.It.LstORecipe
                LstI32ID.Add(_Item.I32ID)
            Next
            LstI32ID.Sort()

            Me.LtbList.Items.Clear()
            For Each _Item1 As Integer In LstI32ID
                For Each _Item2 As CRecipe In CRecipeManager.It.LstORecipe
                    If (Not _Item2.I32ID = _Item1) Then Continue For

                    Me.LtbList.Items.Add(_Item2.I32ID & "." & _Item2.StrName)
                    Exit For
                Next
            Next

            If (Me.LtbList.Items.Count > 0) Then
                Me.LtbList.SelectedIndex = 0
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "ENUM"
    Private Enum EEDIT As Byte
        NONE = 0
        ADD
        MODIFY
        DELETE
    End Enum
#End Region

End Class
