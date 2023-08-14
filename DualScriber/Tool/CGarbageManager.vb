Imports System.Threading
Imports Jhjo.Common

Public Class CGarbageManager
    Implements IDisposable
    Private m_ThreadProcess As Thread = Nothing
    Private m_bThreadProcess As Boolean = False

    Public Sub New()
        Try
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

    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            Me.EndWork()
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub BeginWork()
        Try
            If Me.m_ThreadProcess Is Nothing Then
                Me.m_bThreadProcess = True

                Me.m_ThreadProcess = New Thread(AddressOf Me.Work)
                Me.m_ThreadProcess.IsBackground = True
                Me.m_ThreadProcess.Start()
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Private Sub Work()
        Try
            While (Me.m_bThreadProcess = True)
                Try
                    GC.Collect()
                Catch
                End Try

                Thread.Sleep(1000)
            End While
        Catch ex As Exception
            CError.Ignore(ex)
        End Try
    End Sub

    Private Sub EndWork()
        Try
            If Not Me.m_ThreadProcess Is Nothing Then
                Me.m_bThreadProcess = False

                Me.m_ThreadProcess.Join()
                Me.m_ThreadProcess = Nothing
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

End Class