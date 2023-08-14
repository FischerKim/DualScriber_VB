Imports System.IO
Imports Cognex.VisionPro
Imports Jhjo.Common
Imports Jhjo.DB


Public Class UcReport
    Inherits UcScreen

#Region "VARIABLE"
    Private m_OLeftX As CogLine = Nothing
    Private m_OLeftY As CogLine = Nothing
    Private m_ORightX As CogLine = Nothing
    Private m_ORightY As CogLine = Nothing

    Private m_OLeftTarget As CogPointMarker = Nothing
    Private m_ORightTarget As CogPointMarker = Nothing
    Private m_OLeftCurrent As CogPointMarker = Nothing
    Private m_ORightCurrent As CogPointMarker = Nothing

    Private m_OLeftEdge As CogLine = Nothing
    Private m_ORightEdge As CogLine = Nothing

    Private m_BPreventEvent As Boolean = False
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()

        Try
            Me.DgvReport.AutoGenerateColumns = False


            Me.m_OLeftX = New CogLine()
            Me.m_OLeftX.Rotation = CogMisc.DegToRad(90)
            Me.m_OLeftX.Color = CogColorConstants.Yellow
            Me.m_OLeftX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLeftX.GraphicDOFEnable = CogLineDOFConstants.None
            Me.CdpLeft.InteractiveGraphics.Add(Me.m_OLeftX, "LineX", True)
            Me.m_OLeftY = New CogLine()
            Me.m_OLeftY.Rotation = CogMisc.DegToRad(0)
            Me.m_OLeftY.Color = CogColorConstants.Yellow
            Me.m_OLeftY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_OLeftY.GraphicDOFEnable = CogLineDOFConstants.None
            Me.CdpLeft.InteractiveGraphics.Add(Me.m_OLeftY, "LineY", True)
            Me.m_ORightX = New CogLine()
            Me.m_ORightX.Rotation = CogMisc.DegToRad(90)
            Me.m_ORightX.Color = CogColorConstants.Yellow
            Me.m_ORightX.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_ORightX.GraphicDOFEnable = CogLineDOFConstants.None
            Me.CdpRight.InteractiveGraphics.Add(Me.m_ORightX, "LineX", True)
            Me.m_ORightY = New CogLine()
            Me.m_ORightY.Rotation = CogMisc.DegToRad(0)
            Me.m_ORightY.Color = CogColorConstants.Yellow
            Me.m_ORightY.LineStyle = CogGraphicLineStyleConstants.Dot
            Me.m_ORightY.GraphicDOFEnable = CogLineDOFConstants.None
            Me.CdpRight.InteractiveGraphics.Add(Me.m_ORightY, "LineY", True)

            Me.m_OLeftTarget = New CogPointMarker()
            Me.m_OLeftTarget.Color = CogColorConstants.Green
            Me.m_OLeftTarget.SizeInScreenPixels = 100
            Me.m_OLeftTarget.Visible = False
            Me.m_OLeftTarget.Interactive = False
            Me.m_OLeftTarget.GraphicDOFEnable = CogPointMarkerDOFConstants.None
            Me.CdpLeft.InteractiveGraphics.Add(Me.m_OLeftTarget, "Mark", True)
            Me.m_ORightTarget = New CogPointMarker()
            Me.m_ORightTarget.Color = CogColorConstants.Green
            Me.m_ORightTarget.SizeInScreenPixels = 100
            Me.m_ORightTarget.Visible = False
            Me.m_ORightTarget.Interactive = False
            Me.m_ORightTarget.GraphicDOFEnable = CogPointMarkerDOFConstants.None
            Me.CdpRight.InteractiveGraphics.Add(Me.m_ORightTarget, "Mark", True)
            Me.m_OLeftCurrent = New CogPointMarker()
            Me.m_OLeftCurrent.Color = CogColorConstants.Red
            Me.m_OLeftCurrent.SizeInScreenPixels = 100
            Me.m_OLeftCurrent.Visible = False
            Me.m_OLeftCurrent.Interactive = False
            Me.m_OLeftCurrent.GraphicDOFEnable = CogPointMarkerDOFConstants.None
            Me.CdpLeft.InteractiveGraphics.Add(Me.m_OLeftCurrent, "Mark", True)
            Me.m_ORightCurrent = New CogPointMarker()
            Me.m_ORightCurrent.Color = CogColorConstants.Red
            Me.m_ORightCurrent.SizeInScreenPixels = 100
            Me.m_ORightCurrent.Visible = False
            Me.m_ORightCurrent.Interactive = False
            Me.m_ORightCurrent.GraphicDOFEnable = CogPointMarkerDOFConstants.None
            Me.CdpRight.InteractiveGraphics.Add(Me.m_ORightCurrent, "Mark", True)

            Me.m_OLeftEdge = New CogLine()
            Me.m_OLeftEdge.Rotation = CogMisc.DegToRad(90)
            Me.m_OLeftEdge.Color = CogColorConstants.Red
            Me.m_OLeftEdge.Visible = False
            Me.m_OLeftEdge.Interactive = False
            Me.m_OLeftEdge.GraphicDOFEnable = CogLineDOFConstants.None
            Me.CdpLeft.InteractiveGraphics.Add(Me.m_OLeftEdge, "Edge", True)
            Me.m_ORightEdge = New CogLine()
            Me.m_ORightEdge.Rotation = CogMisc.DegToRad(90)
            Me.m_ORightEdge.Color = CogColorConstants.Red
            Me.m_ORightEdge.Visible = False
            Me.m_ORightEdge.Interactive = False
            Me.m_ORightEdge.GraphicDOFEnable = CogLineDOFConstants.None
            Me.CdpRight.InteractiveGraphics.Add(Me.m_ORightEdge, "Edge", True)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "EVENT"
#Region "BUTTON EVENT"
    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim ODataSource As DataTable = Nothing
            If Not Me.DgvReport.DataSource Is Nothing Then
                ODataSource = CType(Me.DgvReport.DataSource, DataTable)
            End If

            Dim OTable As IDynamicTable = CDB.It.GetDynamicTable(CDB.TABLE_REPORT)
            Me.DgvReport.DataSource = OTable.Select(Me.DtpDate.Value, True)

            If Not ODataSource Is Nothing Then
                ODataSource.Dispose()
                ODataSource = Nothing
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "ETC EVENT"
    Private Sub DgvReport_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DgvReport.SelectionChanged
        If Me.m_BPreventEvent = True Then Return
        If Me.DgvReport.CurrentRow Is Nothing Then Return

        Try
            Me.CdpLeft.DrawingEnabled = False
            Me.CdpRight.DrawingEnabled = False

            Dim ORow As DataRow = CType(Me.DgvReport.CurrentRow.DataBoundItem, DataRowView).Row

            Me.CdpLeft.Image = Me.GetImage(ORow(CDB.REPORT_LEFT_FILE).ToString())
            Me.CdpRight.Image = Me.GetImage(ORow(CDB.REPORT_RIGHT_FILE).ToString())

            If Not Me.CdpLeft.Image Is Nothing Then
                If (String.IsNullOrEmpty(ORow(CDB.REPORT_ALIGNMENT_VIEW_LEFT_X)) = False) And _
                   (String.IsNullOrEmpty(ORow(CDB.REPORT_ALIGNMENT_VIEW_LEFT_Y)) = False) Then
                    Me.m_OLeftCurrent.X = CType(ORow(CDB.REPORT_ALIGNMENT_VIEW_LEFT_X), Double)
                    Me.m_OLeftCurrent.Y = CType(ORow(CDB.REPORT_ALIGNMENT_VIEW_LEFT_Y), Double)
                    Me.m_OLeftCurrent.Visible = True
                Else
                    Me.m_OLeftCurrent.Visible = False
                End If

                Me.m_OLeftX.X = Me.CdpLeft.Image.Width / 2D
                Me.m_OLeftY.Y = Me.CdpLeft.Image.Height / 2D

                Me.m_OLeftTarget.X = Me.CdpLeft.Image.Width / 2D
                Me.m_OLeftTarget.Y = Me.CdpLeft.Image.Height / 2D
                Me.m_OLeftTarget.Visible = True

                Me.m_OLeftEdge.Visible = False
            End If

            If Not Me.CdpRight.Image Is Nothing Then
                If (String.IsNullOrEmpty(ORow(CDB.REPORT_ALIGNMENT_VIEW_RIGHT_X)) = False) And _
                   (String.IsNullOrEmpty(ORow(CDB.REPORT_ALIGNMENT_VIEW_RIGHT_Y)) = False) Then
                    Me.m_ORightCurrent.X = CType(ORow(CDB.REPORT_ALIGNMENT_VIEW_RIGHT_X), Double)
                    Me.m_ORightCurrent.Y = CType(ORow(CDB.REPORT_ALIGNMENT_VIEW_RIGHT_Y), Double)
                    Me.m_ORightCurrent.Visible = True
                Else
                    Me.m_ORightCurrent.Visible = False
                End If

                Me.m_ORightX.X = Me.CdpRight.Image.Width / 2D
                Me.m_ORightY.Y = Me.CdpRight.Image.Height / 2D

                Me.m_ORightTarget.X = Me.CdpRight.Image.Width / 2D
                Me.m_ORightTarget.Y = Me.CdpRight.Image.Height / 2D
                Me.m_ORightTarget.Visible = True

                Me.m_ORightEdge.Visible = False
            End If
        Catch ex As Exception
            CError.Show(ex)
        Finally
            Me.CdpLeft.DrawingEnabled = True
            Me.CdpRight.DrawingEnabled = True
        End Try
    End Sub
#End Region
#End Region


#Region "FUNCTION"
    Public Overrides Sub Remove()
        Try
            Me.m_BPreventEvent = True

            Me.DtpDate.Value = DateTime.Now
            Me.CdpLeft.Image = Nothing
            Me.CdpRight.Image = Nothing

            If Not Me.DgvReport.DataSource Is Nothing Then
                Dim ODataSource As DataTable = CType(Me.DgvReport.DataSource, DataTable)
                Me.DgvReport.DataSource = Nothing
                ODataSource.Dispose()
                ODataSource = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Me.m_BPreventEvent = False
        End Try
    End Sub


    Private Function GetImage(ByVal StrFile As String) As CogImage8Grey
        Dim OResult As CogImage8Grey = Nothing

        Try
            If String.IsNullOrEmpty(StrFile) = False Then
                If File.Exists(StrFile) = True Then
                    Dim OImage As Bitmap = CType(Bitmap.FromFile(StrFile, True), Bitmap)
                    OResult = New CogImage8Grey(OImage)
                    OImage.Dispose()
                    OImage = Nothing
                End If
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try

        Return OResult
    End Function
#End Region

End Class
