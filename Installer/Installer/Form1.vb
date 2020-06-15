Imports System.Security.AccessControl

Imports System.Net
Imports System.IO
Imports System.IO.Compression

Imports System.Windows
Imports Microsoft.Win32
Public Class Installer
    Private Sub Installer_Initialize(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = My.Resources.License
        Button3.Enabled = False
        Button3.Visible = False
        TextBox4.Visible = False
        TextBox4.Text = "C:\Program Files\CadCenter"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Button1.Visible = False Then Button1.Visible = True Else Button1.Visible = False
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        Button1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TabControl1.Enabled = False
        TabControl1.Visible = False
        Label2.Enabled = False
        Label2.Visible = False
        CheckBox1.Enabled = False
        CheckBox1.Visible = False
        Button3.Enabled = True
        Button3.Visible = True
        Button1.Enabled = False
        Button1.Visible = False
        TextBox4.Visible = True
        Label3.Visible = True
        Button4.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using clients As New WebClient()
            My.Computer.FileSystem.CreateDirectory(TextBox4.Text)
            My.Computer.Network.DownloadFile("https://www.cadcenter.pl/apps/tools.dll", TextBox4.Text + "\tools.zip")
            Dim Status As Boolean = False
            Dim FileZ As String = TextBox4.Text + "\tools.zip"
            While Status = False
                Threading.Thread.Sleep(1)
                If My.Computer.FileSystem.FileExists(FileZ) Then
                    Status = True
                End If
                Process.Start("regis.reg")
            End While
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = "C:\"
        dialog.Description = "Select Installation Path"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox4.Text = dialog.SelectedPath
        End If
    End Sub
End Class
