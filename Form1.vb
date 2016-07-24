Imports System.IO

Public Class Form1



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Public Sub 打开ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 打开ToolStripMenuItem.Click
        OpenFileDialog1.Title = "打开ROM"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "gba文件|*.gba"
        OpenFileDialog1.ShowDialog()
        filepath_label.Text = OpenFileDialog1.FileName
    End Sub

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.Title = "打开ROM"
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "gba文件|*.gba"
        OpenFileDialog1.ShowDialog()
        filepath_label.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If filepath_label.Text <> "未加载" Then
            Dim poke_editor As New poke_editor_form()
            poke_editor.Show()
        End If
    End Sub
End Class
