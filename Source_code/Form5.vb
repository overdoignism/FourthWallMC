Public Class Form5
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Dim TheWriter As System.IO.StreamWriter =
            My.Computer.FileSystem.OpenTextFileWriter(Form1.SerWorkingDir + PDSC + "server.properties", False)

        Try
            TheWriter.WriteLine("#Minecraft server properties")
            TheWriter.WriteLine("#" + Now.ToString)

            TheWriter.WriteLine("motd=" + Motd_TextBox.Text)
            TheWriter.WriteLine("server-port=" + serverp_TextBox.Text)
            TheWriter.WriteLine("server-ip=" + serverip_TextBox.Text)
            TheWriter.WriteLine("level-name=" + leveln_TextBox.Text)
            TheWriter.WriteLine("level-seed=" + levels_TextBox.Text)
            TheWriter.WriteLine("level-type=" + levelt_ComboBox.Text)
            TheWriter.WriteLine("generate-structures=" + genstr_ComboBox.Text)
            TheWriter.WriteLine("generator-settings=" + genset_TextBox.Text)
            TheWriter.WriteLine("enable-command-block=" + encb_ComboBox.Text)
            TheWriter.WriteLine("difficulty=" + dif_ComboBox.Text)
            TheWriter.WriteLine("white-list=" + whil_ComboBox.Text)
            TheWriter.WriteLine("gamemode=" + gamem_ComboBox.Text)

            TheWriter.Close()

            Me.DialogResult = DialogResult.OK

        Catch ex As Exception

            MsgBox("Error happend during saving. Please check.", 0, "Error")
            If TheWriter IsNot Nothing Then TheWriter.Close()
            Me.DialogResult = DialogResult.Cancel

        End Try



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class