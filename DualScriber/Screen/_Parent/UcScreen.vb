Public Class UcScreen

#Region "DELEGATE & EVENT"
    Public Delegate Sub ScreenFixedHandler(ByVal EScreen As ESCREEN, ByVal BIsFixed As Boolean)
    Public Event ScreenFixed As ScreenFixedHandler
#End Region


#Region "FUNCTION"
    Public Overridable Sub Add()
    End Sub


    Public Overridable Sub Remove()
    End Sub


    Public Overridable Sub Timer1000()
    End Sub


    Public Overridable Sub ProcRecipeChanged()
    End Sub


    Protected Sub OnScreenFixed(ByVal EScreen As ESCREEN, ByVal BIsFixed As Boolean)
        RaiseEvent ScreenFixed(EScreen, BIsFixed)
    End Sub
#End Region

End Class


#Region "ENUM"
Public Enum ESCREEN As Byte
    ALIGNMENT = 0
    SETUP
    RECIPE
    IO
    REPORT
    LOG
End Enum
#End Region
