Imports System.IO
Imports smal_CS
Imports Jhjo.Common


Public Class CAlignmentAlogrithm

#Region "VARIABLE"
    Private m_OTool As WrapStaticLibSmal = Nothing

    Private m_I32Index As Integer = 0
    Private m_I32MarkCount As Integer = 2

    Private m_OCalibSource As List(Of List(Of Double)) = Nothing
    Private m_OCalibResult As List(Of List(Of Double)) = Nothing
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property OTool() As WrapStaticLibSmal
        Get
            Return Me.m_OTool
        End Get
    End Property


    Public ReadOnly Property I32Index() As Integer
        Get
            Return Me.m_I32Index
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRCTOR"
    Public Sub New(ByVal OTool As WrapStaticLibSmal, ByVal I32Index As Integer)
        Try
            Me.m_OTool = OTool
            Me.m_I32Index = I32Index

            Me.m_OCalibSource = New List(Of List(Of Double))
            Me.m_OCalibResult = New List(Of List(Of Double))
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region


#Region "FUNCTION"
    Public Sub SetStageKind(ByVal EKind As EEQUIP_TYPE)
        Try
            CAlignmentSet.It.BeginSync()

            Me.m_OTool.SmalSetStageType(Me.m_I32Index, CType(EKind, Integer))
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Function GetStageKind() As EEQUIP_TYPE
        Dim EResult As EEQUIP_TYPE = EEQUIP_TYPE.NONE

        Try
            CAlignmentSet.It.BeginSync()

            EResult = CType([Enum].ToObject(GetType(EEQUIP_TYPE), Me.m_OTool.SmalGetStageType(Me.m_I32Index)), EEQUIP_TYPE)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return EResult
    End Function


    Public Sub SetUVWParams(ByVal F64Radius As Double, ByVal LstF64BearAngle As List(Of Double), ByVal LstF64SlideDirection As List(Of Double))
        Try
            CAlignmentSet.It.BeginSync()

            Me.m_OTool.SmalSetUvwStageParams(Me.m_I32Index, F64Radius, LstF64BearAngle, LstF64SlideDirection)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Sub SetMaxMarkCount(ByVal I32Count As Integer)
        Try
            CAlignmentSet.It.BeginSync()

            If (I32Count < 2) Then
                Throw New Exception("To proceed alignment need over 2 marks!")
            End If

            Me.m_OTool.SmalSetMaxNumViews(Me.m_I32Index, I32Count)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Sub SetUseMarkCount(ByVal I32Count As Integer)
        Try
            CAlignmentSet.It.BeginSync()

            If (I32Count < 2) Then
                Throw New Exception("Current program only allows 2 marks to be used for an alignment.")
            End If

            Me.m_I32MarkCount = I32Count
            Me.m_OTool.SmalSetNumCameras(Me.m_I32Index, I32Count)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Function LoadCalibration(ByVal F64SectionXY As Double, ByVal I32PointXY As Integer, ByVal F64SectionT As Double, ByVal I32PointT As Integer) As Integer
        Dim I32Result As Integer = 0

        Try
            CAlignmentSet.It.BeginSync()

            If (I32PointXY < 3) Or (I32PointT < 3) Then
                Throw New Exception("Minimum of 3 points required for calibration.")
            End If

            Me.m_OCalibSource.Add(New List(Of Double))
            Me.m_OCalibSource.Add(New List(Of Double))
            Me.m_OCalibSource.Add(New List(Of Double))

            Me.m_OTool.SmalSetCalibPosParams(Me.m_I32Index, F64SectionXY, I32PointXY, F64SectionT, I32PointT)
            Me.m_OTool.SmalGetCalibPos(Me.m_I32Index, Me.m_OCalibSource)
            I32Result = Me.m_OCalibSource(0).Count

            If Me.m_I32MarkCount = 2 Then
                Me.m_OCalibResult = New List(Of List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
            ElseIf Me.m_I32MarkCount = 3 Then
                Me.m_OCalibResult = New List(Of List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
            ElseIf Me.m_I32MarkCount = 4 Then
                Me.m_OCalibResult = New List(Of List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
                Me.m_OCalibResult.Add(New List(Of Double))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return I32Result
    End Function


    Public Sub GetCalibrationMovement(ByVal I32CalibIndex As Integer, ByRef F64X As Double, ByRef F64Y As Double, ByRef F64T As Double)
        F64X = 0
        F64Y = 0
        F64T = 0

        Try
            F64X = Me.m_OCalibSource(0)(I32CalibIndex)
            F64Y = Me.m_OCalibSource(1)(I32CalibIndex)
            F64T = Me.m_OCalibSource(2)(I32CalibIndex)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

     Public Sub SetCalibResult_Orthogonal(ByVal F64X As Double, ByVal F64Y As Double, ByVal Left0_Right1 As Integer)
        Try
            'If (Not Me.m_I32MarkCount = ArrF64X.Length) Or (Not Me.m_I32MarkCount = ArrF64Y.Length) Then
            '    Throw New Exception("The used mark count is different with inputed mark count!")
            'End If

            If Left0_Right1 = 0 Then
                Me.m_OCalibResult(0).Add(F64Y)
                Me.m_OCalibResult(1).Add(F64X)
            End If
            If Left0_Right1 = 1 Then
                Me.m_OCalibResult(2).Add(F64Y)
                Me.m_OCalibResult(3).Add(F64X)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Public Sub SetCalibResult(ByVal ArrF64X As Double(), ByVal ArrF64Y As Double())
        Try
            If (Not Me.m_I32MarkCount = ArrF64X.Length) Or (Not Me.m_I32MarkCount = ArrF64Y.Length) Then
                Throw New Exception("Make sure both marks are seenable")
            End If

            If Me.m_I32MarkCount = 2 Then
                Me.m_OCalibResult(0).Add(ArrF64X(0))
                Me.m_OCalibResult(1).Add(ArrF64Y(0))
                Me.m_OCalibResult(2).Add(ArrF64X(1))
                Me.m_OCalibResult(3).Add(ArrF64Y(1))
            ElseIf Me.m_I32MarkCount = 3 Then
                Me.m_OCalibResult(0).Add(ArrF64X(0))
                Me.m_OCalibResult(1).Add(ArrF64Y(0))
                Me.m_OCalibResult(2).Add(ArrF64X(1))
                Me.m_OCalibResult(3).Add(ArrF64Y(1))
                Me.m_OCalibResult(4).Add(ArrF64X(2))
                Me.m_OCalibResult(5).Add(ArrF64Y(2))
            ElseIf Me.m_I32MarkCount = 4 Then
                Me.m_OCalibResult(0).Add(ArrF64X(0))
                Me.m_OCalibResult(1).Add(ArrF64Y(0))
                Me.m_OCalibResult(2).Add(ArrF64X(1))
                Me.m_OCalibResult(3).Add(ArrF64Y(1))
                Me.m_OCalibResult(4).Add(ArrF64X(2))
                Me.m_OCalibResult(5).Add(ArrF64Y(2))
                Me.m_OCalibResult(6).Add(ArrF64X(3))
                Me.m_OCalibResult(7).Add(ArrF64Y(3))
            End If
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub


    Public Function RunCalibration() As Boolean
        Dim BResult As Boolean = False

        Try
            CAlignmentSet.It.BeginSync()
            BResult = Me.m_OTool.SmalCalibrate(Me.m_I32Index, Me.m_OCalibResult)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function


    Public Sub SetTarget(ByVal I32MarkIndex As Integer, ByVal F64X As Double, ByVal F64Y As Double)
        Try
            CAlignmentSet.It.BeginSync()

            Dim OPosition As List(Of List(Of Double)) = New List(Of List(Of Double))
            OPosition.Add(New List(Of Double))
            OPosition.Add(New List(Of Double))
            OPosition(0).Add(F64X)
            OPosition(1).Add(F64Y)

            Me.m_OTool.SmalSetGoalPos(Me.m_I32Index, I32MarkIndex, OPosition)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub

    Public Sub SetTarget_Orthogonal(ByVal I32MarkIndex As Integer, ByVal F64X As Double, ByVal F64Y As Double)
        Try
            CAlignmentSet.It.BeginSync()

            Dim OPosition As List(Of List(Of Double)) = New List(Of List(Of Double))
            OPosition.Add(New List(Of Double))
            OPosition.Add(New List(Of Double))
            OPosition(0).Add(F64Y)
            OPosition(1).Add(F64X)

            Me.m_OTool.SmalSetGoalPos(Me.m_I32Index, I32MarkIndex, OPosition)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Sub SetViewOffset(ByVal I32ViewIndex As Integer, ByVal F64XOffset As Double, ByVal F64YOffset As Double)
        Try
            CAlignmentSet.It.BeginSync()

            Dim LstF64Offset As List(Of Double) = New List(Of Double)
            LstF64Offset.Add(F64XOffset)
            LstF64Offset.Add(F64YOffset)

            Me.m_OTool.SmalSetCameraOffset(Me.m_I32Index, I32ViewIndex, LstF64Offset)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Function GetTarget() As List(Of List(Of Double))
        Dim OResult As List(Of List(Of Double)) = Nothing

        Try
            CAlignmentSet.It.BeginSync()

            OResult = Me.m_OTool.SmalGetGoalPos(Me.m_I32Index, Me.m_I32MarkCount)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return OResult
    End Function


    Public Sub SetWeight(ByVal EHorizontal As EWEIGHT_HORIZON, ByVal EVertical As EWEIGHT_VERTICAL)
        Try
            CAlignmentSet.It.BeginSync()

            Dim OWeight As List(Of List(Of Double)) = New List(Of List(Of Double))()
            Dim ArrF64Value1 As Double() = Nothing
            Dim ArrF64Value2 As Double() = Nothing
            Dim ArrF64Value3 As Double() = Nothing

            If Me.m_I32MarkCount = 2 Then
                If (EHorizontal = EWEIGHT_HORIZON.LEFT) Then
                    ArrF64Value1 = New Double() {1.0, 0.0}
                    ArrF64Value2 = New Double() {0.5, 0.5}
                    ArrF64Value3 = New Double() {0.5, 0.5}
                ElseIf (EHorizontal = EWEIGHT_HORIZON.CENTER) Then
                    ArrF64Value1 = New Double() {0.5, 0.5}
                    ArrF64Value2 = New Double() {0.5, 0.5}
                    ArrF64Value3 = New Double() {0.5, 0.5}
                ElseIf (EHorizontal = EWEIGHT_HORIZON.RIGHT) Then
                    ArrF64Value1 = New Double() {0.0, 1.0}
                    ArrF64Value2 = New Double() {0.5, 0.5}
                    ArrF64Value3 = New Double() {0.5, 0.5}
                End If
            ElseIf Me.m_I32MarkCount = 3 Then
                If (EHorizontal = EWEIGHT_HORIZON.LEFT) Then
                    If (EVertical = EWEIGHT_VERTICAL.TOP) Then
                        ArrF64Value1 = New Double() {1.0, 0.0, 0.0}
                        ArrF64Value2 = New Double() {1.0, 0.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.MIDDLE) Then
                        ArrF64Value1 = New Double() {1.0, 0.0, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.BOTTOM) Then
                        ArrF64Value1 = New Double() {0.0, 0.0, 1.0}
                        ArrF64Value2 = New Double() {0.0, 0.0, 1.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    End If
                ElseIf (EHorizontal = EWEIGHT_HORIZON.CENTER) Then
                    If (EVertical = EWEIGHT_VERTICAL.TOP) Then
                        ArrF64Value1 = New Double() {0.5, 0.5, 0.0}
                        ArrF64Value2 = New Double() {1.0, 0.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.MIDDLE) Then
                        ArrF64Value1 = New Double() {0.5, 0.5, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.BOTTOM) Then
                        ArrF64Value1 = New Double() {0.5, 0.5, 0.0}
                        ArrF64Value2 = New Double() {0.0, 0.0, 1.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    End If
                ElseIf (EHorizontal = EWEIGHT_HORIZON.RIGHT) Then
                    If (EVertical = EWEIGHT_VERTICAL.TOP) Then
                        ArrF64Value1 = New Double() {0.0, 1.0, 0.0}
                        ArrF64Value2 = New Double() {0.0, 1.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.MIDDLE) Then
                        ArrF64Value1 = New Double() {0.0, 1.0, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.BOTTOM) Then
                        ArrF64Value1 = New Double() {0.0, 1.0, 0.0}
                        ArrF64Value2 = New Double() {0.0, 0.0, 1.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0}
                    End If
                End If
            ElseIf Me.m_I32MarkCount = 4 Then
                If (EHorizontal = EWEIGHT_HORIZON.LEFT) Then
                    If (EVertical = EWEIGHT_VERTICAL.TOP) Then
                        ArrF64Value1 = New Double() {1.0, 0.0, 0.0, 0.0}
                        ArrF64Value2 = New Double() {1.0, 0.0, 0.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.MIDDLE) Then
                        ArrF64Value1 = New Double() {1.0, 0.0, 0.0, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.BOTTOM) Then
                        ArrF64Value1 = New Double() {0.0, 0.0, 1.0, 0.0}
                        ArrF64Value2 = New Double() {0.0, 0.0, 1.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    End If
                ElseIf (EHorizontal = EWEIGHT_HORIZON.CENTER) Then
                    If (EVertical = EWEIGHT_VERTICAL.TOP) Then
                        ArrF64Value1 = New Double() {0.5, 0.5, 0.0, 0.0}
                        ArrF64Value2 = New Double() {1.0, 0.0, 0.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.MIDDLE) Then
                        ArrF64Value1 = New Double() {0.5, 0.5, 0.0, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.BOTTOM) Then
                        ArrF64Value1 = New Double() {0.5, 0.5, 0.0, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    End If
                ElseIf (EHorizontal = EWEIGHT_HORIZON.RIGHT) Then
                    If (EVertical = EWEIGHT_VERTICAL.TOP) Then
                        ArrF64Value1 = New Double() {0.0, 1.0, 0.0, 0.0}
                        ArrF64Value2 = New Double() {0.0, 1.0, 0.0, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.MIDDLE) Then
                        ArrF64Value1 = New Double() {0.0, 1.0, 0.0, 0.0}
                        ArrF64Value2 = New Double() {0.5, 0.0, 0.5, 0.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    ElseIf (EVertical = EWEIGHT_VERTICAL.BOTTOM) Then
                        ArrF64Value1 = New Double() {0.0, 0.0, 0.0, 1.0}
                        ArrF64Value2 = New Double() {0.0, 0.0, 0.0, 1.0}
                        ArrF64Value3 = New Double() {0.0, 1.0, 0.0, 0.0}
                    End If
                End If
            End If
            OWeight.Add(ArrF64Value1.ToList())
            OWeight.Add(ArrF64Value2.ToList())
            OWeight.Add(ArrF64Value3.ToList())

            Me.m_OTool.SmalSetAlignWeight(Me.m_I32Index, Me.m_I32MarkCount, OWeight)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try
    End Sub


    Public Function RunAlignment_Orthogonal(ByVal ArrF64X As Double(), ByVal ArrF64Y As Double(), ByRef F64X As Double, ByRef F64Y As Double, ByRef F64T As Double, ByRef Left0Right1 As Integer) As Boolean
        Dim BResult As Boolean = False
        F64X = 0
        F64Y = 0
        F64T = 0

        Try
            CAlignmentSet.It.BeginSync()

            Dim ArrI32Mark As Integer() = Nothing
            Dim ArrI32Target As Integer() = Nothing
            Dim OPosition As List(Of List(Of Double)) = New List(Of List(Of Double))()
            Dim LstF64Result As List(Of Double) = New List(Of Double)

            If Me.m_I32MarkCount = 2 Then
                ArrI32Mark = New Integer() {0, 1}
                ArrI32Target = New Integer() {0, 0}
                OPosition.Add(ArrF64Y.ToList())
                OPosition.Add(ArrF64X.ToList())
            ElseIf Me.m_I32MarkCount = 3 Then
                ArrI32Mark = New Integer() {0, 1, 2}
                ArrI32Target = New Integer() {0, 0, 0}
                OPosition.Add(ArrF64Y.ToList())
                OPosition.Add(ArrF64X.ToList())
            ElseIf Me.m_I32MarkCount = 4 Then
                ArrI32Mark = New Integer() {0, 1, 2, 3}
                ArrI32Target = New Integer() {0, 0, 0, 0}
                OPosition.Add(ArrF64Y.ToList())
                OPosition.Add(ArrF64X.ToList())
            End If

            BResult = Me.m_OTool.SmalAlign(Me.m_I32Index, ArrI32Mark.ToList(), ArrI32Target.ToList(), OPosition, LstF64Result)
            F64Y = LstF64Result(0)
            F64X = LstF64Result(1)
            If (Left0Right1 = 0) Then
                F64T = LstF64Result(2)
            Else
                F64T = -LstF64Result(2)
            End If

        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function


    Public Function RunAlignment(ByVal ArrF64X As Double(), ByVal ArrF64Y As Double(), ByRef F64X As Double, ByRef F64Y As Double, ByRef F64T As Double) As Boolean
        Dim BResult As Boolean = False
        F64X = 0
        F64Y = 0
        F64T = 0

        Try
            CAlignmentSet.It.BeginSync()

            Dim ArrI32Mark As Integer() = Nothing
            Dim ArrI32Target As Integer() = Nothing
            Dim OPosition As List(Of List(Of Double)) = New List(Of List(Of Double))()
            Dim LstF64Result As List(Of Double) = New List(Of Double)

            If Me.m_I32MarkCount = 2 Then
                ArrI32Mark = New Integer() {0, 1}
                ArrI32Target = New Integer() {0, 0}
                OPosition.Add(ArrF64X.ToList())
                OPosition.Add(ArrF64Y.ToList())
            ElseIf Me.m_I32MarkCount = 3 Then
                ArrI32Mark = New Integer() {0, 1, 2}
                ArrI32Target = New Integer() {0, 0, 0}
                OPosition.Add(ArrF64X.ToList())
                OPosition.Add(ArrF64Y.ToList())
            ElseIf Me.m_I32MarkCount = 4 Then
                ArrI32Mark = New Integer() {0, 1, 2, 3}
                ArrI32Target = New Integer() {0, 0, 0, 0}
                OPosition.Add(ArrF64X.ToList())
                OPosition.Add(ArrF64Y.ToList())
            End If

            BResult = Me.m_OTool.SmalAlign(Me.m_I32Index, ArrI32Mark.ToList(), ArrI32Target.ToList(), OPosition, LstF64Result)
            F64X = LstF64Result(0)
            F64Y = LstF64Result(1)
            F64T = LstF64Result(2)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function


    Public Function LoadFile(ByVal StrDirectory As String) As Boolean
        Dim BResult As Boolean = False

        Try
            CAlignmentSet.It.BeginSync()

            Dim StrFile As String = String.Format("{0}\Smal{1}.slc", StrDirectory, Me.m_I32Index)

            If File.Exists(StrFile) = True Then
                BResult = Me.m_OTool.SmalReadConfigFile(Me.m_I32Index, StrFile)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function

    Public Function LoadFilePartial(ByVal StrDirectory As String) As Boolean
        Dim BResult As Boolean = False

        Try
            CAlignmentSet.It.BeginSync()

            Dim StrFile As String = String.Format("{0}\SmalPartial{1}.slc", StrDirectory, Me.m_I32Index)

            If File.Exists(StrFile) = True Then
                BResult = Me.m_OTool.SmalReadConfigFile(Me.m_I32Index, StrFile)
            End If
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function


    Public Function SaveFile(ByVal StrDirectory As String) As Boolean
        Dim BResult As Boolean = False

        Try
            CAlignmentSet.It.BeginSync()

            Directory.CreateDirectory(StrDirectory)
            Dim StrFile As String = String.Format("{0}\Smal{1}.slc", StrDirectory, Me.m_I32Index)
            Me.m_OTool.SmalWriteConfigFile(Me.m_I32Index, StrFile)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function


    Public Function SaveFilePartial(ByVal StrDirectory As String) As Boolean
        Dim BResult As Boolean = False

        Try
            CAlignmentSet.It.BeginSync()

            Directory.CreateDirectory(StrDirectory)
            Dim StrFile As String = String.Format("{0}\SmalPartial{1}.slc", StrDirectory, Me.m_I32Index)
            Me.m_OTool.SmalWriteConfigFile(Me.m_I32Index, StrFile)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return BResult
    End Function


    Public Function GetCameraPosition() As List(Of List(Of Double))
        Dim OResult As List(Of List(Of Double)) = Nothing

        Try
            'Me.m_OTool.SmalGetCalibPos(Me.m_I32Index, OResult)
        Catch ex As Exception
        Finally

        End Try

        Return OResult
    End Function


    Public Function GetVersion() As String
        Dim StrResult As String = Nothing

        Try
            CAlignmentSet.It.BeginSync()

            Me.m_OTool.SmalGetVersion(StrResult)
        Catch ex As Exception
            CError.Throw(ex)
        Finally
            CAlignmentSet.It.EndSync()
        End Try

        Return StrResult
    End Function
#End Region

End Class


Public Enum EEQUIP_TYPE As Byte
    STAGE_XYT = 0
    STAGE_UVW = 1
    STAGE_TXY = 2
    STAGE_TX = 3
    NONE = Byte.MaxValue
End Enum


Public Enum EWEIGHT_HORIZON As Byte
    LEFT = 0
    CENTER = 1
    RIGHT = 2
End Enum


Public Enum EWEIGHT_VERTICAL As Byte
    TOP = 0
    MIDDLE = 1
    BOTTOM = 2
End Enum
