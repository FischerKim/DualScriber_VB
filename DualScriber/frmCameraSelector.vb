Imports System.Data
Imports PylonC.NET
Imports Jhjo.Common
Imports Daekhon.Common


Public Class frmCameraSelector

#Region "VARIABLE"
    Private m_OALeft As CCameraInfo = Nothing
    Private m_OARight As CCameraInfo = Nothing
    Private m_OBLeft As CCameraInfo = Nothing
    Private m_OBRight As CCameraInfo = Nothing
#End Region


#Region "PROPERTIES"
    Public Property OALeft() As CCameraInfo
        Get
            Return Me.m_OALeft
        End Get
        Set(ByVal value As CCameraInfo)
            Me.m_OALeft = value
        End Set
    End Property


    Public Property OARight() As CCameraInfo
        Get
            Return Me.m_OARight
        End Get
        Set(ByVal value As CCameraInfo)
            Me.m_OARight = value
        End Set
    End Property


    Public Property OBLeft() As CCameraInfo
        Get
            Return Me.m_OBLeft
        End Get
        Set(ByVal value As CCameraInfo)
            Me.m_OBLeft = value
        End Set
    End Property


    Public Property OBRight() As CCameraInfo
        Get
            Return Me.m_OBRight
        End Get
        Set(ByVal value As CCameraInfo)
            Me.m_OBRight = value
        End Set
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New()
        InitializeComponent()

        Try
            Me.DgvList.AutoGenerateColumns = False
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "EVENT"
#Region "FORM EVENT"
    Private Sub frmCameraSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ODataSource As DataTable = New DataTable()
            ODataSource.Columns.Add("COMPANY", GetType(String))
            ODataSource.Columns.Add("MODEL", GetType(String))
            ODataSource.Columns.Add("IP", GetType(String))
            ODataSource.Columns.Add("SERIAL", GetType(String))
            ODataSource.Columns.Add("KEY", GetType(UInteger))

            Dim U32Count As UInteger = Pylon.EnumerateDevices()
            If U32Count > 0 Then
                For _Index As UInteger = 0 To U32Count - 1 Step 1
                    Dim OHandle As PYLON_DEVICE_INFO_HANDLE = Pylon.GetDeviceInfoHandle(_Index)

                    Dim ORow As DataRow = ODataSource.NewRow()
                    ORow("COMPANY") = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName")
                    ORow("MODEL") = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName")
                    ORow("IP") = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress")
                    ORow("SERIAL") = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber")
                    ORow("KEY") = _Index
                    ODataSource.Rows.Add(ORow)
                Next

                Me.DgvList.DataSource = ODataSource


                If Not Me.m_OALeft Is Nothing Then
                    Me.LblALeft.Text = Me.m_OALeft.StrIP
                End If
                If Not Me.m_OARight Is Nothing Then
                    Me.LblARight.Text = Me.m_OARight.StrIP
                End If
                If Not Me.m_OBLeft Is Nothing Then
                    Me.LblBLeft.Text = Me.m_OBLeft.StrIP
                End If
                If Not Me.m_OBRight Is Nothing Then
                    Me.LblBRight.Text = Me.m_OBRight.StrIP
                End If
            End If
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region


#Region "BUTTON EVENT"
    Private Sub BtnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelectALeft.Click, BtnSelectBRight.Click, BtnSelectBLeft.Click, BtnSelectARight.Click
        Try
            If Me.DgvList.CurrentRow Is Nothing Then
                CMsgBox.Warning("Please select camera infomation!")
                Return
            End If


            Dim StrKind As String = CType(CType(sender, Button).Tag, String)
            Dim StrIP As String = CType((CType(Me.DgvList.CurrentRow.DataBoundItem, DataRowView)).Row("IP"), String)

            Select Case (StrKind)
                Case "A_LEFT"
                    Me.LblALeft.Text = StrIP

                    If Me.LblARight.Text = StrIP Then
                        Me.LblARight.Text = String.Empty
                    End If
                    If Me.LblBLeft.Text = StrIP Then
                        Me.LblBLeft.Text = String.Empty
                    End If
                    If Me.LblBRight.Text = StrIP Then
                        Me.LblBRight.Text = String.Empty
                    End If

                Case "A_RIGHT"
                    Me.LblARight.Text = StrIP

                    If Me.LblALeft.Text = StrIP Then
                        Me.LblALeft.Text = String.Empty
                    End If
                    If Me.LblBLeft.Text = StrIP Then
                        Me.LblBLeft.Text = String.Empty
                    End If
                    If Me.LblBRight.Text = StrIP Then
                        Me.LblBRight.Text = String.Empty
                    End If

                Case "B_LEFT"
                    Me.LblBLeft.Text = StrIP

                    If Me.LblALeft.Text = StrIP Then
                        Me.LblALeft.Text = String.Empty
                    End If
                    If Me.LblARight.Text = StrIP Then
                        Me.LblARight.Text = String.Empty
                    End If
                    If Me.LblBRight.Text = StrIP Then
                        Me.LblBRight.Text = String.Empty
                    End If

                Case "B_RIGHT"
                    Me.LblBRight.Text = StrIP

                    If Me.LblALeft.Text = StrIP Then
                        Me.LblALeft.Text = String.Empty
                    End If
                    If Me.LblARight.Text = StrIP Then
                        Me.LblARight.Text = String.Empty
                    End If
                    If Me.LblBLeft.Text = StrIP Then
                        Me.LblBLeft.Text = String.Empty
                    End If
            End Select
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApply.Click
        Try
            If String.IsNullOrEmpty(Me.LblALeft.Text) = True Then
                Me.m_OALeft = Nothing
            End If
            If String.IsNullOrEmpty(Me.LblARight.Text) = True Then
                Me.m_OARight = Nothing
            End If
            If String.IsNullOrEmpty(Me.LblBLeft.Text) = True Then
                Me.m_OBLeft = Nothing
            End If
            If String.IsNullOrEmpty(Me.LblBRight.Text) = True Then
                Me.m_OBRight = Nothing
            End If


            Dim ODataSource As DataTable = CType(Me.DgvList.DataSource, DataTable)

            For Each _Item As DataRow In ODataSource.Rows
                If CType(_Item("IP"), String) = Me.LblALeft.Text Then
                    If Me.m_OALeft Is Nothing Then
                        Me.m_OALeft = New CCameraInfo()
                    End If
                    Me.m_OALeft.StrVender = CType(_Item("COMPANY"), String)
                    Me.m_OALeft.StrModel = CType(_Item("MODEL"), String)
                    Me.m_OALeft.StrIP = CType(_Item("IP"), String)
                    Me.m_OALeft.StrSerial = CType(_Item("SERIAL"), String)
                    Me.m_OALeft.OKey = CType(_Item("KEY"), UInteger)
                ElseIf CType(_Item("IP"), String) = Me.LblARight.Text Then
                    If Me.m_OARight Is Nothing Then
                        Me.m_OARight = New CCameraInfo()
                    End If
                    Me.m_OARight.StrVender = CType(_Item("COMPANY"), String)
                    Me.m_OARight.StrModel = CType(_Item("MODEL"), String)
                    Me.m_OARight.StrIP = CType(_Item("IP"), String)
                    Me.m_OARight.StrSerial = CType(_Item("SERIAL"), String)
                    Me.m_OARight.OKey = CType(_Item("KEY"), UInteger)
                ElseIf CType(_Item("IP"), String) = Me.LblBLeft.Text Then
                    If Me.m_OBLeft Is Nothing Then
                        Me.m_OBLeft = New CCameraInfo()
                    End If
                    Me.m_OBLeft.StrVender = CType(_Item("COMPANY"), String)
                    Me.m_OBLeft.StrModel = CType(_Item("MODEL"), String)
                    Me.m_OBLeft.StrIP = CType(_Item("IP"), String)
                    Me.m_OBLeft.StrSerial = CType(_Item("SERIAL"), String)
                    Me.m_OBLeft.OKey = CType(_Item("KEY"), UInteger)
                ElseIf CType(_Item("IP"), String) = Me.LblBRight.Text Then
                    If Me.m_OBRight Is Nothing Then
                        Me.m_OBRight = New CCameraInfo()
                    End If
                    Me.m_OBRight.StrVender = CType(_Item("COMPANY"), String)
                    Me.m_OBRight.StrModel = CType(_Item("MODEL"), String)
                    Me.m_OBRight.StrIP = CType(_Item("IP"), String)
                    Me.m_OBRight.StrSerial = CType(_Item("SERIAL"), String)
                    Me.m_OBRight.OKey = CType(_Item("KEY"), UInteger)
                End If
            Next


            MyBase.DialogResult = DialogResult.OK
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub


    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Try
            MyBase.DialogResult = DialogResult.OK
        Catch ex As Exception
            CError.Show(ex)
        End Try
    End Sub
#End Region
#End Region

End Class