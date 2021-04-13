Imports System.ComponentModel

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BrowseJAR_Button.Click

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "JAR File (*.jar)|*.jar|Batch File (*.bat)|*.bat"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            JARPATH_Textbox.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BrowseJVM_Button.Click

        OpenFileDialog1.FileName = "Java.exe"
        OpenFileDialog1.Filter = "JVM Java.exe|Java.exe"
        OpenFileDialog1.DefaultExt = "exe"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            JVM_Textbox.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles SetupOK_Button.Click

        Before_Save()
        Me.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles SetupCancel_Button.Click

        Make_Value_In_Box()
        Me.Close()

    End Sub



    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles BackupTimeS_Textbox.TextChanged

        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "/", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "\", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "?", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "*", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, ":", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, """", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "|", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "$", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, ">", "")
        BackupTimeS_Textbox.Text = Replace(BackupTimeS_Textbox.Text, "<", "")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles BrowseBackup_Button.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "*Executable Files|*.exe;*.bat"

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            BackupExe_Textbox.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Make_Value_In_Box()
    End Sub

    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Get_All_IP_Addr()
        Make_SerialPort_List()
        Make_Value_In_Box()
        ShowEssX_Det(EssentialsDetected)

    End Sub

    Private Sub BrowseTER_Button_Click(sender As Object, e As EventArgs) Handles BrowseTER_Button.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "*.*|*.*"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            DetAE_Run_TextBox.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Benefits with EssentialsX Plugin:" + vbCrLf + vbCrLf +
        "1. CONSOLE is an ID." + vbCrLf + vbCrLf +
        "2. CommandBlock is workable.", 0, "Help")
    End Sub

    Private Sub CSPID_Chk_CheckedChanged(sender As Object, e As EventArgs) Handles CSPID_Chk.CheckedChanged
        If CSPID_Chk.Checked Then
            Label38.Text = "Who has NOT command sending privilege? (ID, not nickname)"
        Else
            Label38.Text = "Who has command sending privilege? (ID, not nickname)"
        End If
    End Sub
End Class