Imports System.Threading
Imports Jhjo.Common
Imports Jhjo.Tool

Public Class CLogTool

#Region "SINGLE TON"
    Private Shared Src_It As CLogTool = Nothing


    Public Shared ReadOnly Property It() As CLogTool
        Get
            Dim OResult As CLogTool = Nothing

            Try
                If (CLogTool.Src_It Is Nothing) Then
                    CLogTool.Src_It = New CLogTool()
                End If

                OResult = CLogTool.Src_It
            Catch ex As Exception
                CError.Throw(ex)
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "VARIABLE"
    Private m_LstOLog As List(Of CLog) = Nothing
    Private m_OFile As CLogSaveFile = Nothing
    Private m_OInterrupt As Object = Nothing

    Private m_OTime As DateTime = DateTime.Now
    Private m_OSendMessage As SendMessageHandler = Nothing
#End Region


#Region "DELEGATE & EVENT"
    Public Delegate Sub SendMessageHandler(ByVal StrText As String)
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property LstOLog() As List(Of CLog)
        Get
            Return Me.m_LstOLog
        End Get
    End Property


    Public WriteOnly Property OSendMessage() As SendMessageHandler
        Set(ByVal value As SendMessageHandler)
            Me.m_OSendMessage = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        Try
            Me.m_LstOLog = New List(Of CLog)
            Me.m_OFile = New CLogSaveFile(".\Log")
            Me.m_OInterrupt = New Object()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Sub SetLog(ByVal OLog As CLog)
        Try
            Monitor.Enter(Me.m_OInterrupt)

            If (Not Me.m_OTime.Day = OLog.OTime.Day) Then
                Me.m_LstOLog.Clear()
                Me.m_OTime = OLog.OTime
            End If

            Me.OnSendMessage(OLog.GetLog())
            Me.m_LstOLog.Add(OLog)
            Me.m_OFile.SetLog(OLog)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub


    Public Sub BeginSync()
        Try
            Monitor.Enter(Me.m_OInterrupt)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Sub EndSync()
        Try
            Monitor.Exit(Me.m_OInterrupt)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Private Sub OnSendMessage(ByVal StrText As String)
        Try
            If (Not Me.m_OSendMessage Is Nothing) Then
                Me.m_OSendMessage(StrText)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
