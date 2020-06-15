Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.ApplicationServices
Public Class MenuNInstalled
    Public Shared Sub Menu()
        Dim ccpDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ccpDialog As PromptKeywordOptions = New PromptKeywordOptions("")
        Dim ccpDialogRes As PromptResult
        ccpDialog.Message = vbCrLf + "Is not loaded. Choose an Option: "
        ccpDialog.Keywords.Add("Load")
        ccpDialog.Keywords.Add("Help")
        ccpDialog.Keywords.Add("Exit")
        ccpDialog.Keywords.Default = "Load"
        ccpDialog.AllowNone = False
        ccpDialogRes = ccpDoc.Editor.GetKeywords(ccpDialog)
        If ccpDialogRes.Status = PromptStatus.Cancel Then Exit Sub
        If ccpDialogRes.StringResult = "Load" Then
            Call Installer.Installer.CadCenter_Tab()
        End If
        If ccpDialogRes.StringResult = "Help" Then Call Installer.Installer.CadCenter_Tab()
        If ccpDialogRes.StringResult = "Exit" Then Exit Sub
    End Sub
End Class
