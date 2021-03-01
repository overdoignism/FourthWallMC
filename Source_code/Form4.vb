Public Class Form4
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox4.Text
        Form1.SendTo_MincraftServer()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox2.Text + " true"
        Form1.SendTo_MincraftServer()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox2.Text + " false"
        Form1.SendTo_MincraftServer()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox1.Text + " true"
        Form1.SendTo_MincraftServer()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.MCS_ConsoleTextbox.Text = TextBox1.Text + " false"
        Form1.SendTo_MincraftServer()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.TextBox3.Text = TextBox1.Text + " true"
        Form1.SendTo_MincraftServer()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.TextBox3.Text = TextBox1.Text + " false"
        Form1.SendTo_MincraftServer()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Visible = False
    End Sub



End Class