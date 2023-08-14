Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop

Public Class CExcelFile
    Implements IDisposable


#Region "VARIABLE"
    Private m_OFile As FileInfo = Nothing

    Private m_OApplication As Excel.Application = Nothing
    Private m_OWorkBooks As Excel.Workbooks = Nothing
    Private m_OWorkBook As Excel.Workbook = Nothing
    Private m_OSheets As Excel.Sheets = Nothing
    Private m_OSheet As Excel.Worksheet = Nothing
    Private m_OCells As Excel.Range = Nothing
    Private m_OCell As Excel.Range = Nothing
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal StrFile As String)
        Try
            Me.m_OFile = New FileInfo(StrFile)

            Me.m_OApplication = CreateObject("Excel.Application")
            Me.m_OApplication.DisplayAlerts = False
            Me.m_OWorkBooks = Me.m_OApplication.Workbooks
            Me.m_OWorkBook = Me.m_OWorkBooks.Open(Me.m_OFile.FullName)
            Me.m_OSheets = Me.m_OWorkBook.Worksheets
            Me.m_OSheet = Me.m_OSheets(1)
            Me.m_OCells = Me.m_OSheet.Cells
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Protected Overrides Sub Finalize()
        Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Function Read(ByVal StrCol As String, ByVal I32Row As Integer) As String
        Dim StrResult As String = String.Empty

        Try
            Me.m_OCell = Me.m_OCells(I32Row, StrCol)
            StrResult = Me.m_OCell.Value2
            Marshal.ReleaseComObject(Me.m_OCell)
        Catch ex As Exception
            If (Not Me.m_OCell Is Nothing) Then Marshal.ReleaseComObject(Me.m_OCell)
            Throw ex
        End Try

        Return StrResult
    End Function


    Public Sub Write(ByVal StrCol As String, ByVal I32Row As Integer, ByVal OData As Object)
        Try
            Me.m_OCell = Me.m_OCells(I32Row, StrCol)
            Me.m_OCell.Value2 = OData
            Marshal.ReleaseComObject(Me.m_OCell)
        Catch ex As Exception
            If (Not Me.m_OCell Is Nothing) Then Marshal.ReleaseComObject(Me.m_OCell)
            Throw ex
        End Try
    End Sub


    Public Sub Save()
        Try
            Me.m_OWorkBook.SaveAs(Me.m_OFile.FullName)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub Dispose() Implements IDisposable.Dispose
        Try
            If (Not Me.m_OCells Is Nothing) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.m_OCells)
                Me.m_OCells = Nothing
            End If
            If (Not Me.m_OSheet Is Nothing) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.m_OSheet)
                Me.m_OSheet = Nothing
            End If
            If (Not Me.m_OSheets Is Nothing) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.m_OSheets)
                Me.m_OSheets = Nothing
            End If
            If (Not Me.m_OWorkBook Is Nothing) Then
                Me.m_OWorkBook.Close()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.m_OWorkBook)
                Me.m_OWorkBook = Nothing
            End If
            If (Not Me.m_OWorkBooks Is Nothing) Then
                Me.m_OWorkBooks.Close()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.m_OWorkBooks)
                Me.m_OWorkBooks = Nothing
            End If
            If (Not Me.m_OApplication Is Nothing) Then
                Me.m_OApplication.Quit()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Me.m_OApplication)
                Me.m_OApplication = Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
