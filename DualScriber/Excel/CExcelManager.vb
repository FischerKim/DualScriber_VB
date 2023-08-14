Imports System.IO
Imports System.Threading
Imports System.Text


Public Class CExcelManager

#Region "SINGLE TON"
    Private Shared SrcIt As CExcelManager = Nothing


    Public Shared ReadOnly Property It() As CExcelManager
        Get
            Dim OResult As CExcelManager = Nothing

            Try
                If (CExcelManager.SrcIt Is Nothing) Then
                    CExcelManager.SrcIt = New CExcelManager()
                End If

                OResult = CExcelManager.SrcIt
            Catch ex As Exception
                Throw ex
            End Try

            Return OResult
        End Get
    End Property
#End Region


#Region "CONST"
    Private Const DIR_RECIPE As String = "./Excel/{0}/{1}"
    Private Const FILE_EXCEL_SAMPLE As String = "./Excel/{0}/Sample.xls"
    Private Const FILE_INI_SAMPLE As String = "./Excel/{0}/Info.ini"
    Private Const FILE_EXCEL As String = "./Excel/{0}/{1}/{2}.xls"
    Private Const FILE_INI As String = "./Excel/{0}/{1}/Info.ini"

    Private Const INI_APP = "INFO"
    Private Const INI_KEY_FILE_COUNT As String = "FILE_COUNT"
    Private Const INI_KEY_ROW_INDEX As String = "ROW_INDEX"

    Private Const EXCEL_TIME_COL As String = "A"
    Private Const EXCEL_GLASS_ID As String = "B"
    Private Const EXCEL_ST_LEFT_FRONT As String = "C"
    Private Const EXCEL_ST_LEFT_REAR As String = "D"
    Private Const EXCEL_ST_RIGHT_FRONT As String = "E"
    Private Const EXCEL_ST_RIGHT_REAR As String = "F"

    Private Const INIT_ROW_INDEX As Integer = 9
    Private Const MAX_ROW_COUNT As Integer = 58
#End Region


#Region "VARIABLE"
    Private m_StrDir As String = String.Empty
    Private m_StrExcelFile As String = String.Empty
    Private m_StrIniFile As String = String.Empty
    Private m_I32FileCount As String = 0
    Private m_I32RowIndex As String = 0
    Private m_OFile As CExcelFile = Nothing

    Private m_OInterrupt As Object = Nothing
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Protected Sub New()
        Try
            Me.m_OInterrupt = New Object()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Sub Write(ByVal StrRecipe As String, ByVal OResult As CInspectionResult)
        Try
            Monitor.Enter(Me.m_OInterrupt)


            Me.m_StrDir = String.Format(DIR_RECIPE, CType(OResult.EStage, Integer), StrRecipe)

            If (Directory.Exists(Me.m_StrDir) = False) Then
                Me.m_StrExcelFile = String.Format(FILE_EXCEL, CType(OResult.EStage, Integer), StrRecipe, 1)
                Me.m_StrIniFile = String.Format(FILE_INI, CType(OResult.EStage, Integer), StrRecipe)
                Me.m_I32FileCount = 1
                Me.m_I32RowIndex = INIT_ROW_INDEX

                Directory.CreateDirectory(Me.m_StrDir)
                File.Copy(String.Format(FILE_EXCEL_SAMPLE, CType(OResult.EStage, Integer)), Me.m_StrExcelFile)
                File.Copy(String.Format(FILE_INI_SAMPLE, CType(OResult.EStage, Integer)), Me.m_StrIniFile)
            Else
                Dim OFileCount As StringBuilder = New StringBuilder()
                Dim ORowIndex As StringBuilder = New StringBuilder()
                GetPrivateProfileString(INI_APP, INI_KEY_FILE_COUNT, 0, OFileCount, 255, String.Format(FILE_INI, CType(OResult.EStage, Integer), StrRecipe))
                GetPrivateProfileString(INI_APP, INI_KEY_ROW_INDEX, 0, ORowIndex, 255, String.Format(FILE_INI, CType(OResult.EStage, Integer), StrRecipe))

                Me.m_StrExcelFile = String.Format(FILE_EXCEL, CType(OResult.EStage, Integer), StrRecipe, OFileCount.ToString())
                Me.m_StrIniFile = String.Format(FILE_INI, CType(OResult.EStage, Integer), StrRecipe)
                Me.m_I32FileCount = Convert.ToInt32(OFileCount.ToString())
                Me.m_I32RowIndex = Convert.ToInt32(ORowIndex.ToString())

                If (Me.m_I32RowIndex > MAX_ROW_COUNT) Then
                    Me.m_OFile = New CExcelFile(Me.m_StrExcelFile)

                    If (Not Me.m_OFile.Read(EXCEL_GLASS_ID, Me.m_I32RowIndex) = OResult.StrID) Then
                        Me.m_StrExcelFile = String.Format(FILE_EXCEL, CType(OResult.EStage, Integer), StrRecipe, Me.m_I32FileCount + 1)
                        Me.m_I32FileCount += 1
                        Me.m_I32RowIndex = INIT_ROW_INDEX

                        File.Copy(String.Format(FILE_EXCEL_SAMPLE, CType(OResult.EStage, Integer)), Me.m_StrExcelFile)
                    End If

                    Me.m_OFile.Dispose()
                    Me.m_OFile = Nothing
                End If
            End If


            Me.m_OFile = New CExcelFile(Me.m_StrExcelFile)
            Me.m_OFile.Write("C", 3, StrRecipe)
            Me.m_OFile.Write("F", 4, DateTime.Now.ToString("yyyy.MM.dd"))
            If (OResult.ETarget = EEDGE_TARGET.FRONT) Then
                Me.m_I32RowIndex += 1

                Me.m_OFile.Write(EXCEL_GLASS_ID, Me.m_I32RowIndex, OResult.StrID)
                If (OResult.OLeft.BInspected = True) Then
                    Me.m_OFile.Write(EXCEL_ST_LEFT_FRONT, Me.m_I32RowIndex, Math.Round((OResult.OLeft.F64Length - ((OResult.OLeft.F64CutMinLimit + OResult.OLeft.F64CutMaxLimit) / 2)) * 1000))
                End If
                If (OResult.ORight.BInspected = True) Then
                    Me.m_OFile.Write(EXCEL_ST_RIGHT_FRONT, Me.m_I32RowIndex, Math.Round((OResult.ORight.F64Length - ((OResult.ORight.F64CutMinLimit + OResult.ORight.F64CutMaxLimit) / 2)) * 1000))
                End If
            Else
                If (Not Me.m_OFile.Read(EXCEL_GLASS_ID, Me.m_I32RowIndex) = OResult.StrID) Then
                    Me.m_I32RowIndex += 1

                    Me.m_OFile.Write(EXCEL_GLASS_ID, Me.m_I32RowIndex, OResult.StrID)
                    If (OResult.OLeft.BInspected = True) Then
                        Me.m_OFile.Write(EXCEL_ST_LEFT_REAR, Me.m_I32RowIndex, Math.Round((OResult.OLeft.F64Length - ((OResult.OLeft.F64CutMinLimit + OResult.OLeft.F64CutMaxLimit) / 2)) * 1000))
                    End If
                    If (OResult.ORight.BInspected = True) Then
                        Me.m_OFile.Write(EXCEL_ST_RIGHT_REAR, Me.m_I32RowIndex, Math.Round((OResult.ORight.F64Length - ((OResult.ORight.F64CutMinLimit + OResult.ORight.F64CutMaxLimit) / 2)) * 1000))
                    End If
                Else
                    Me.m_OFile.Write(EXCEL_GLASS_ID, Me.m_I32RowIndex, OResult.StrID)
                    If (OResult.OLeft.BInspected = True) Then
                        Me.m_OFile.Write(EXCEL_ST_LEFT_REAR, Me.m_I32RowIndex, Math.Round((OResult.OLeft.F64Length - ((OResult.OLeft.F64CutMinLimit + OResult.OLeft.F64CutMaxLimit) / 2)) * 1000))
                    End If
                    If (OResult.ORight.BInspected = True) Then
                        Me.m_OFile.Write(EXCEL_ST_RIGHT_REAR, Me.m_I32RowIndex, Math.Round((OResult.ORight.F64Length - ((OResult.ORight.F64CutMinLimit + OResult.ORight.F64CutMaxLimit) / 2)) * 1000))
                    End If
                End If
            End If
            Me.m_OFile.Save()
            Me.m_OFile.Dispose()
            Me.m_OFile = Nothing

            WritePrivateProfileString(INI_APP, INI_KEY_FILE_COUNT, Me.m_I32FileCount, Me.m_StrIniFile)
            WritePrivateProfileString(INI_APP, INI_KEY_ROW_INDEX, Me.m_I32RowIndex, Me.m_StrIniFile)
        Catch ex As Exception
            Throw ex
        Finally
            Monitor.Exit(Me.m_OInterrupt)
        End Try
    End Sub
#End Region


#Region "DECLARE FUNCTION"
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal StrAppName As String, ByVal StrKeyName As String, ByVal StrDefault As String, ByVal OValue As StringBuilder, ByVal I32Size As Integer, ByVal StrFile As String) As Boolean
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal StrAppName As String, ByVal StrKeyName As String, ByVal StrValue As String, ByVal StrFile As String) As Boolean
#End Region

End Class