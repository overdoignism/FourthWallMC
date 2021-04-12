Public Class Form4
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox2.Text + " true"
        Form1.SendTo_Console(0)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox2.Text + " false"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox1.Text + " true"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox1.Text + " false"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox3.Text + " true"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox3.Text + " false"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Visible = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox5.Text + " true"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox5.Text + " false"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox6.Text + " true"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox6.Text + " false"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox7.Text + " true"
        Form1.SendTo_Console(0)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox7.Text + " false"
        Form1.SendTo_Console(0)
    End Sub
End Class