Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.Windows
Public Class MenuInstalled
    Public Shared Sub Menu()
        Dim ccpDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ccpDialog As PromptKeywordOptions = New PromptKeywordOptions("")
        Dim ccpDialogRes As PromptResult
        ccpDialog.Message = vbCrLf + "Choose: "
        ccpDialog.Keywords.Add("Hide")
        ccpDialog.Keywords.Add("Help")
        ccpDialog.Keywords.Add("Exit")
        ccpDialog.Keywords.Default = "Hide"
        ccpDialog.AllowNone = False
        ccpDialogRes = ccpDoc.Editor.GetKeywords(ccpDialog)
        If ccpDialogRes.Status = PromptStatus.Cancel Then Exit Sub
        If ccpDialogRes.StringResult = "Hide" Then
            Dim ribbonControl As Autodesk.Windows.RibbonControl = Autodesk.Windows.ComponentManager.Ribbon
            Dim InstallCHK As RibbonTab = ribbonControl.FindTab("CadCenter")
            If InstallCHK IsNot Nothing Then
                InstallCHK.IsVisible = False
                InstallCHK.IsEnabled = False
            Else
                MsgBox("Tab is not loaded")
            End If
        End If
        If ccpDialogRes.StringResult = "Help" Then Exit Sub
        If ccpDialogRes.StringResult = "Exit" Then Exit Sub
    End Sub
End Class
