Imports System.Drawing
Imports Cognex.VisionPro
Imports Jhjo.Common

Public Class CImageInfo

#Region "VARIABLE"
    Private m_OTime As DateTime
    Private m_OImage As CogImage8Grey
#End Region


#Region "PROPERTIES"
    Public ReadOnly Property OTime() As DateTime
        Get
            Return Me.m_OTime
        End Get
    End Property


    Public ReadOnly Property OImage() As CogImage8Grey
        Get
            Return Me.m_OImage
        End Get
    End Property
#End Region


#Region "CONSTRUCTOR & DESTRUCTOR"
    Public Sub New(ByVal OImage As CogImage8Grey)
        Try
            Me.m_OTime = DateTime.Now
            Me.m_OImage = OImage
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub

    Public Sub New(ByVal OImage As Bitmap)
        Try
            Me.m_OTime = DateTime.Now
            Me.m_OImage = New CogImage8Grey(OImage)
        Catch ex As Exception
            CError.Throw(ex)
        End Try
    End Sub
#End Region

End Class
