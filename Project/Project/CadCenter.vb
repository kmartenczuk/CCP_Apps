Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.Windows
Imports Autodesk.AutoCAD.Runtime


Public Class CadCenter
    <CommandMethod("CadCenter")>
    Public Shared Sub Start()
        Dim ccpDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim ribbonControl As Autodesk.Windows.RibbonControl = Autodesk.Windows.ComponentManager.Ribbon
        Dim RibbonCHK As RibbonTab = ribbonControl.FindTab("CadCenter")
        If RibbonCHK Is Nothing Then
            Call MenuNInstalled.Menu()
        Else
            If RibbonCHK.IsVisible = True Then Call MenuInstalled.Menu() Else Call MenuHidden.Menu()
        End If
    End Sub
End Class
