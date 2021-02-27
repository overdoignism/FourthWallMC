Public Class Form3
    Private Sub Ok_Button_Click(sender As Object, e As EventArgs) Handles Ok_Button.Click

        Before_Save()
        Me.Hide()

    End Sub


    Private Sub Help_RichTextBox_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles Help_RichTextBox.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

End Class