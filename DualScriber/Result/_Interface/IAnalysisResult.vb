Imports Jhjo.Common

Public Interface IAnalysisResult
    Property EView() As EVIEW
    ReadOnly Property OImageInfo() As CImageInfo
    Property BInspected() As Boolean
    Property BOK() As Boolean
End Interface
