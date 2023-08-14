Imports System.Threading
Imports Cognex.VisionPro
Imports Jhjo.Common
Imports Daekhon.Common
Imports System.IO
Imports System.Text
Imports Cognex.VisionPro.ImageFile

Public Class CDisplayTool
    Implements IDisposable

#Region "VARIABLE"
    Private m_OView As IImageExporter = Nothing

    Private m_objImageInfo As CImageInfo = Nothing
    Private m_OInterrupt As Object = Nothing

    Private m_OWorker As Thread = Nothing
    Private m_BDoWork As Boolean = False

    Private m_OImageExported As ImageExportedHandler = Nothing
    
    ' jht 그랩 수집 수량
    Private m_iGCCollectCount As Integer = 0
    ' jht 시뮬레이션 모드
    Private m_iSimulationMode As Integer = 0
    ' jht 프로그램 로딩 할 때 이미지 여러 장 로딩
    Private m_listSimulationImage As List(Of Bitmap) = Nothing
    ' jht 시뮬레이션 이미지 루프 카운트
    Private m_iSimulationImageCount As Integer = 0
#End Region


#Region "DELEGATE & EVENT"
    Public Delegate Sub ImageExportedHandler(ByVal OImageInfo As CImageInfo)
#End Region


#Region "PROPERTIES"
    Public Property OView() As IImageExporter
        Get
            Return Me.m_OView
        End Get
        Set(ByVal value As IImageExporter)
            Try
                If Not Me.m_OView Is Nothing Then
                    RemoveHandler Me.m_OView.Exported, AddressOf Me.OView_Exported
                End If

                Me.m_OView = value
                If Not Me.m_OView Is Nothing Then
                    AddHandler Me.m_OView.Exported, AddressOf Me.OView_Exported
                End If
            Catch ex As Exception
                CError.Throw(ex)
            End Try
        End Set
    End Property


    Public ReadOnly Property OCurrentImage() As CogImage8Grey
        Get
            Return Me.m_objImageInfo.OImage
        End Get
    End Property


    Public WriteOnly Property OImageExported() As ImageExportedHandler
        Set(ByVal value As ImageExportedHandler)
            Me.m_OImageExported = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        Try
            ' jht 시뮬레이션 모드 변수
            Me.m_iSimulationMode = CEnvironment.It.SimulationMode()
            ' jht 시뮬레이션 모드이면 프로그램 로딩 할 때 이미지 여러 장 로딩
            If 1 = Me.m_iSimulationMode Then
                Me.m_listSimulationImage = New List(Of Bitmap)
                ' 코그 이미지 파일 툴 생성
                Dim objCogImageFileTool As CogImageFileTool = New CogImageFileTool()
                ' 프로젝트 bin 폴더
                Dim strImagePath As String = String.Format(Environment.CurrentDirectory & "\SimulationImage")
                ' 폴더 내 파일 목록 불러오기
                Dim strFileNames As String() = System.IO.Directory.GetFiles(strImagePath & "\\")
                ' 폴더 내 파일 수만큼 루프
                For index As Integer = 0 To strFileNames.Count - 1 Step 1
                    objCogImageFileTool.Operator.Open(strFileNames(index), CogImageFileModeConstants.Read)
                    objCogImageFileTool.Run()
                    Me.m_listSimulationImage.Add(objCogImageFileTool.OutputImage.ToBitmap)
                Next
            End If

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


#Region "EVENT"
    Private Sub OView_Exported(ByVal OImage As Object)
        Try
            Monitor.Enter(Me.m_OInterrupt)
            ' jht 여기서 미리 로딩한 비트맵 이미지로 ImageInfo 객체 생성
            ' 시뮬레이션 이미지 리스트 수만큼 라이브 루프
            Dim OImageInfo As CImageInfo = Nothing
            ' 시뮬레이션 모드일 때 시뮬레이션 이미지 리스트 뽑아서 루프
            If 1 = Me.m_iSimulationMode Then
                OImageInfo = New CImageInfo(Me.m_listSimulationImage(Me.m_iSimulationImageCount))
                If Me.m_iSimulationImageCount >= Me.m_listSimulationImage.Count - 1 Then
                    Me.m_iSimulationImageCount = 0
                Else
                    Me.m_iSimulationImageCount = Me.m_iSimulationImageCount + 1
                End If
            Else
                OImageInfo = New CImageInfo(CType(OImage, Bitmap))
            End If
            ' 이미지 객체 갱신
            Me.m_objImageInfo = OImageInfo
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
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
                Me.m_OWorker.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub Work()
        Try
            While (Me.m_BDoWork = True)
                Try
                    Dim OImageInfo As CImageInfo = Me.m_objImageInfo

                    If Not OImageInfo Is Nothing Then
                        Me.OnImageExported(OImageInfo)
                    End If
                Catch ex As Exception
                    CError.Ignore(ex)
                End Try

                Thread.Sleep(10)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub


    Private Sub EndWork()
        Try
            If Not Me.m_OWorker Is Nothing Then
                Me.m_BDoWork = False

                Me.m_OWorker.Join()
                Me.m_OWorker = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    'Private Function GetImageInfoToDisplay() As CImageInfo
    '    Dim OResult As CImageInfo = Nothing

    '    Try
    '        Monitor.Enter(Me.m_OInterrupt)

    '        If Me.m_LstOImageInfo.Count >= 2 Then
    '            Me.m_LstOImageInfo.RemoveRange(0, Me.m_LstOImageInfo.Count - 2)

    '            OResult = Me.m_LstOImageInfo(0)
    '            Me.m_LstOImageInfo.RemoveAt(0)
    '        End If
    '    Catch ex As Exception
    '        CError.Throw(ex)
    '    Finally
    '        Monitor.Exit(Me.m_OInterrupt)
    '    End Try

    '    Return OResult
    'End Function


    Public Function GetImageInfoToAnalysis() As CImageInfo
        Dim OResult As CImageInfo = Nothing

        Try
            ' jht 이미지 받는 부분에서 동기화 진행할 필요는...없어 보임?
            'Monitor.Enter(Me.m_OInterrupt)
            OResult = Me.m_objImageInfo
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            'Monitor.Exit(Me.m_OInterrupt)
        End Try

        Return OResult
    End Function


    Private Sub OnImageExported(ByVal OImageInfo As CImageInfo)
        Try
            If Not Me.m_OImageExported Is Nothing Then
                Me.m_OImageExported(OImageInfo)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            Me.EndWork()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
