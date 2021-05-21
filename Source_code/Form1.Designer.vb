<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.StartButton = New System.Windows.Forms.Button()
        Me.Send2MCSButton = New System.Windows.Forms.Button()
        Me.MCS_ConsoleTextbox = New System.Windows.Forms.TextBox()
        Me.MCS_Richtexbox = New System.Windows.Forms.RichTextBox()
        Me.SetupButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MCServerRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MCSState_Label = New System.Windows.Forms.Label()
        Me.ManServerTimeOutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.BackupButton = New System.Windows.Forms.Button()
        Me.KillTaskButton = New System.Windows.Forms.Button()
        Me.HelpAbout_Button = New System.Windows.Forms.Button()
        Me.RCState_Label = New System.Windows.Forms.Label()
        Me.ModeRC_Button = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Kill_Mux_Con = New System.Windows.Forms.Button()
        Me.EXE_Textbox = New System.Windows.Forms.RichTextBox()
        Me.RestartCon_Button = New System.Windows.Forms.Button()
        Me.EXECON_Stat_Label = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Send2Exe_TextBox = New System.Windows.Forms.TextBox()
        Me.ModeExeFW_Button = New System.Windows.Forms.Button()
        Me.Send2EXE_Button = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Selected_Player = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Player_Logout = New System.Windows.Forms.ListBox()
        Me.Player_Login = New System.Windows.Forms.ListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Queue_TextBox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.SerWorkingPath_TextBox = New System.Windows.Forms.TextBox()
        Me.AssiPlug_Det_TextBox = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.EXEWorkingPath_TextBox = New System.Windows.Forms.TextBox()
        Me.ServerLiveTime_Textbox = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Command_err_ListBox = New System.Windows.Forms.ListBox()
        Me.Note_ListBox = New System.Windows.Forms.ListBox()
        Me.SP1Mon = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.COMState_Label = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ServerType_Label = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.WaitPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BusyCrash = New System.Windows.Forms.Timer(Me.components)
        Me.BoxRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.QueueEXE_RunnerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PauseText_Button = New System.Windows.Forms.Button()
        Me.Stop_Button = New System.Windows.Forms.Button()
        Me.TheWorkerCleaner = New System.Windows.Forms.Timer(Me.components)
        Me.Pan_MCServer = New System.Windows.Forms.Panel()
        Me.Pan_Console = New System.Windows.Forms.Panel()
        Me.Pan_Player = New System.Windows.Forms.Panel()
        Me.Pan_Info = New System.Windows.Forms.Panel()
        Me.PanMC_Btn = New System.Windows.Forms.Button()
        Me.PanConsole_Btn = New System.Windows.Forms.Button()
        Me.PanPlayer_Btn = New System.Windows.Forms.Button()
        Me.PanInfo_Btn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.WaitPanel.SuspendLayout()
        Me.Pan_MCServer.SuspendLayout()
        Me.Pan_Console.SuspendLayout()
        Me.Pan_Player.SuspendLayout()
        Me.Pan_Info.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.StartButton.Location = New System.Drawing.Point(12, 11)
        Me.StartButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(121, 58)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start Server"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'Send2MCSButton
        '
        Me.Send2MCSButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Send2MCSButton.Location = New System.Drawing.Point(934, 570)
        Me.Send2MCSButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Send2MCSButton.Name = "Send2MCSButton"
        Me.Send2MCSButton.Size = New System.Drawing.Size(77, 29)
        Me.Send2MCSButton.TabIndex = 1
        Me.Send2MCSButton.Text = "Send"
        Me.Send2MCSButton.UseVisualStyleBackColor = True
        '
        'MCS_ConsoleTextbox
        '
        Me.MCS_ConsoleTextbox.BackColor = System.Drawing.Color.Black
        Me.MCS_ConsoleTextbox.Font = New System.Drawing.Font("Courier New", 12.0!)
        Me.MCS_ConsoleTextbox.ForeColor = System.Drawing.Color.Silver
        Me.MCS_ConsoleTextbox.Location = New System.Drawing.Point(88, 572)
        Me.MCS_ConsoleTextbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MCS_ConsoleTextbox.Name = "MCS_ConsoleTextbox"
        Me.MCS_ConsoleTextbox.Size = New System.Drawing.Size(842, 26)
        Me.MCS_ConsoleTextbox.TabIndex = 4
        '
        'MCS_Richtexbox
        '
        Me.MCS_Richtexbox.BackColor = System.Drawing.Color.Black
        Me.MCS_Richtexbox.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.MCS_Richtexbox.ForeColor = System.Drawing.Color.Silver
        Me.MCS_Richtexbox.Location = New System.Drawing.Point(5, 4)
        Me.MCS_Richtexbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MCS_Richtexbox.Name = "MCS_Richtexbox"
        Me.MCS_Richtexbox.ReadOnly = True
        Me.MCS_Richtexbox.Size = New System.Drawing.Size(1006, 561)
        Me.MCS_Richtexbox.TabIndex = 5
        Me.MCS_Richtexbox.Text = ""
        Me.MCS_Richtexbox.WordWrap = False
        '
        'SetupButton
        '
        Me.SetupButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SetupButton.Location = New System.Drawing.Point(12, 209)
        Me.SetupButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SetupButton.Name = "SetupButton"
        Me.SetupButton.Size = New System.Drawing.Size(121, 58)
        Me.SetupButton.TabIndex = 6
        Me.SetupButton.Text = "Setup"
        Me.SetupButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(216, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Socket Script Console: "
        '
        'MCServerRefreshTimer
        '
        Me.MCServerRefreshTimer.Enabled = True
        Me.MCServerRefreshTimer.Interval = 1000
        '
        'MCSState_Label
        '
        Me.MCSState_Label.AutoSize = True
        Me.MCSState_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.MCSState_Label.Location = New System.Drawing.Point(152, 10)
        Me.MCSState_Label.Name = "MCSState_Label"
        Me.MCSState_Label.Size = New System.Drawing.Size(34, 16)
        Me.MCSState_Label.TabIndex = 11
        Me.MCSState_Label.Text = "OFF"
        '
        'ManServerTimeOutTimer
        '
        Me.ManServerTimeOutTimer.Enabled = True
        Me.ManServerTimeOutTimer.Interval = 1000
        '
        'ExitButton
        '
        Me.ExitButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ExitButton.Location = New System.Drawing.Point(12, 634)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(121, 58)
        Me.ExitButton.TabIndex = 14
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'BackupButton
        '
        Me.BackupButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.BackupButton.Location = New System.Drawing.Point(12, 143)
        Me.BackupButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BackupButton.Name = "BackupButton"
        Me.BackupButton.Size = New System.Drawing.Size(121, 58)
        Me.BackupButton.TabIndex = 15
        Me.BackupButton.Text = "Backup Server"
        Me.BackupButton.UseVisualStyleBackColor = True
        '
        'KillTaskButton
        '
        Me.KillTaskButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.KillTaskButton.Location = New System.Drawing.Point(12, 502)
        Me.KillTaskButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.KillTaskButton.Name = "KillTaskButton"
        Me.KillTaskButton.Size = New System.Drawing.Size(121, 58)
        Me.KillTaskButton.TabIndex = 16
        Me.KillTaskButton.Text = "Kill all task"
        Me.KillTaskButton.UseVisualStyleBackColor = True
        '
        'HelpAbout_Button
        '
        Me.HelpAbout_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.HelpAbout_Button.Location = New System.Drawing.Point(12, 568)
        Me.HelpAbout_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.HelpAbout_Button.Name = "HelpAbout_Button"
        Me.HelpAbout_Button.Size = New System.Drawing.Size(121, 58)
        Me.HelpAbout_Button.TabIndex = 17
        Me.HelpAbout_Button.Text = "Help && About"
        Me.HelpAbout_Button.UseVisualStyleBackColor = True
        '
        'RCState_Label
        '
        Me.RCState_Label.AutoSize = True
        Me.RCState_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RCState_Label.Location = New System.Drawing.Point(377, 10)
        Me.RCState_Label.Name = "RCState_Label"
        Me.RCState_Label.Size = New System.Drawing.Size(34, 16)
        Me.RCState_Label.TabIndex = 18
        Me.RCState_Label.Text = "OFF"
        '
        'ModeRC_Button
        '
        Me.ModeRC_Button.BackColor = System.Drawing.Color.White
        Me.ModeRC_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ModeRC_Button.Location = New System.Drawing.Point(12, 275)
        Me.ModeRC_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModeRC_Button.Name = "ModeRC_Button"
        Me.ModeRC_Button.Size = New System.Drawing.Size(121, 58)
        Me.ModeRC_Button.TabIndex = 19
        Me.ModeRC_Button.Text = "Work Mode"
        Me.ModeRC_Button.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button1.Location = New System.Drawing.Point(5, 570)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Rapid"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Kill_Mux_Con
        '
        Me.Kill_Mux_Con.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Kill_Mux_Con.Location = New System.Drawing.Point(261, 540)
        Me.Kill_Mux_Con.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Kill_Mux_Con.Name = "Kill_Mux_Con"
        Me.Kill_Mux_Con.Size = New System.Drawing.Size(121, 58)
        Me.Kill_Mux_Con.TabIndex = 37
        Me.Kill_Mux_Con.Text = "Kill all Mux"
        Me.Kill_Mux_Con.UseVisualStyleBackColor = True
        '
        'EXE_Textbox
        '
        Me.EXE_Textbox.BackColor = System.Drawing.Color.Black
        Me.EXE_Textbox.Font = New System.Drawing.Font("Courier New", 9.0!)
        Me.EXE_Textbox.ForeColor = System.Drawing.Color.Silver
        Me.EXE_Textbox.Location = New System.Drawing.Point(6, 4)
        Me.EXE_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EXE_Textbox.Name = "EXE_Textbox"
        Me.EXE_Textbox.ReadOnly = True
        Me.EXE_Textbox.Size = New System.Drawing.Size(1006, 528)
        Me.EXE_Textbox.TabIndex = 29
        Me.EXE_Textbox.Text = ""
        Me.EXE_Textbox.WordWrap = False
        '
        'RestartCon_Button
        '
        Me.RestartCon_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RestartCon_Button.Location = New System.Drawing.Point(133, 540)
        Me.RestartCon_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RestartCon_Button.Name = "RestartCon_Button"
        Me.RestartCon_Button.Size = New System.Drawing.Size(121, 58)
        Me.RestartCon_Button.TabIndex = 36
        Me.RestartCon_Button.Text = "Restart Main"
        Me.RestartCon_Button.UseVisualStyleBackColor = True
        '
        'EXECON_Stat_Label
        '
        Me.EXECON_Stat_Label.AutoSize = True
        Me.EXECON_Stat_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.EXECON_Stat_Label.Location = New System.Drawing.Point(557, 548)
        Me.EXECON_Stat_Label.Name = "EXECON_Stat_Label"
        Me.EXECON_Stat_Label.Size = New System.Drawing.Size(34, 16)
        Me.EXECON_Stat_Label.TabIndex = 28
        Me.EXECON_Stat_Label.Text = "OFF"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(392, 548)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(168, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Main script console state:"
        '
        'Send2Exe_TextBox
        '
        Me.Send2Exe_TextBox.BackColor = System.Drawing.Color.Black
        Me.Send2Exe_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!)
        Me.Send2Exe_TextBox.ForeColor = System.Drawing.Color.Silver
        Me.Send2Exe_TextBox.Location = New System.Drawing.Point(390, 571)
        Me.Send2Exe_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Send2Exe_TextBox.Name = "Send2Exe_TextBox"
        Me.Send2Exe_TextBox.Size = New System.Drawing.Size(538, 26)
        Me.Send2Exe_TextBox.TabIndex = 26
        '
        'ModeExeFW_Button
        '
        Me.ModeExeFW_Button.BackColor = System.Drawing.Color.White
        Me.ModeExeFW_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ModeExeFW_Button.Location = New System.Drawing.Point(5, 540)
        Me.ModeExeFW_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModeExeFW_Button.Name = "ModeExeFW_Button"
        Me.ModeExeFW_Button.Size = New System.Drawing.Size(121, 58)
        Me.ModeExeFW_Button.TabIndex = 25
        Me.ModeExeFW_Button.Text = "Flood way (Main)"
        Me.ModeExeFW_Button.UseVisualStyleBackColor = False
        '
        'Send2EXE_Button
        '
        Me.Send2EXE_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Send2EXE_Button.Location = New System.Drawing.Point(933, 569)
        Me.Send2EXE_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Send2EXE_Button.Name = "Send2EXE_Button"
        Me.Send2EXE_Button.Size = New System.Drawing.Size(77, 29)
        Me.Send2EXE_Button.TabIndex = 25
        Me.Send2EXE_Button.Text = "Send"
        Me.Send2EXE_Button.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button6.Location = New System.Drawing.Point(628, 238)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(121, 58)
        Me.Button6.TabIndex = 46
        Me.Button6.Text = "Pardon"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(63, 558)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(527, 16)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "This list is re-generated after each Minecraft Server startup.  Not all played pl" &
    "ayer."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(625, 516)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(234, 16)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "You need press <Send> by yourself."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(625, 495)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(218, 16)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Just input to command send box."
        '
        'Selected_Player
        '
        Me.Selected_Player.AutoSize = True
        Me.Selected_Player.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Selected_Player.Location = New System.Drawing.Point(625, 66)
        Me.Selected_Player.Name = "Selected_Player"
        Me.Selected_Player.Size = New System.Drawing.Size(48, 16)
        Me.Selected_Player.TabIndex = 42
        Me.Selected_Player.Text = "(none)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(625, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Now selected:"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button5.Location = New System.Drawing.Point(628, 370)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(121, 58)
        Me.Button5.TabIndex = 40
        Me.Button5.Text = "DeOp"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button4.Location = New System.Drawing.Point(628, 304)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(121, 58)
        Me.Button4.TabIndex = 39
        Me.Button4.Text = "Op"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button3.Location = New System.Drawing.Point(628, 172)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(121, 58)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Ban"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button2.Location = New System.Drawing.Point(628, 106)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 58)
        Me.Button2.TabIndex = 35
        Me.Button2.Text = "Kick "
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(316, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Logged out:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(18, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Logged in (Online):"
        '
        'Player_Logout
        '
        Me.Player_Logout.FormattingEnabled = True
        Me.Player_Logout.ItemHeight = 15
        Me.Player_Logout.Location = New System.Drawing.Point(319, 40)
        Me.Player_Logout.Name = "Player_Logout"
        Me.Player_Logout.Size = New System.Drawing.Size(290, 499)
        Me.Player_Logout.Sorted = True
        Me.Player_Logout.TabIndex = 1
        '
        'Player_Login
        '
        Me.Player_Login.FormattingEnabled = True
        Me.Player_Login.ItemHeight = 15
        Me.Player_Login.Location = New System.Drawing.Point(21, 40)
        Me.Player_Login.Name = "Player_Login"
        Me.Player_Login.Size = New System.Drawing.Size(290, 499)
        Me.Player_Login.Sorted = True
        Me.Player_Login.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(44, 422)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(210, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Command error:  (Latest on top)"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.Queue_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.SerWorkingPath_TextBox)
        Me.GroupBox1.Controls.Add(Me.AssiPlug_Det_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.EXEWorkingPath_TextBox)
        Me.GroupBox1.Controls.Add(Me.ServerLiveTime_Textbox)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(30, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(961, 207)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "These information is generated after latest time 4WMC start or server start."
        '
        'Queue_TextBox
        '
        Me.Queue_TextBox.Location = New System.Drawing.Point(642, 49)
        Me.Queue_TextBox.Name = "Queue_TextBox"
        Me.Queue_TextBox.ReadOnly = True
        Me.Queue_TextBox.Size = New System.Drawing.Size(170, 21)
        Me.Queue_TextBox.TabIndex = 52
        Me.Queue_TextBox.Text = "Stopped"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(20, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(328, 16)
        Me.Label14.TabIndex = 36
        Me.Label14.Text = "Script console initialization folder full path (latest):"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(639, 30)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(241, 16)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "# instruction queuing (Main console):"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(20, 30)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(159, 16)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "Assist plug-in Detected: "
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button8.ForeColor = System.Drawing.Color.Black
        Me.Button8.Location = New System.Drawing.Point(846, 151)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(91, 40)
        Me.Button8.TabIndex = 50
        Me.Button8.Text = "Open"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(432, 30)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(113, 16)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Server live time:"
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Location = New System.Drawing.Point(846, 98)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(91, 40)
        Me.Button7.TabIndex = 49
        Me.Button7.Text = "Open"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'SerWorkingPath_TextBox
        '
        Me.SerWorkingPath_TextBox.Location = New System.Drawing.Point(24, 108)
        Me.SerWorkingPath_TextBox.Name = "SerWorkingPath_TextBox"
        Me.SerWorkingPath_TextBox.ReadOnly = True
        Me.SerWorkingPath_TextBox.Size = New System.Drawing.Size(803, 21)
        Me.SerWorkingPath_TextBox.TabIndex = 48
        '
        'AssiPlug_Det_TextBox
        '
        Me.AssiPlug_Det_TextBox.Location = New System.Drawing.Point(24, 49)
        Me.AssiPlug_Det_TextBox.Name = "AssiPlug_Det_TextBox"
        Me.AssiPlug_Det_TextBox.ReadOnly = True
        Me.AssiPlug_Det_TextBox.Size = New System.Drawing.Size(391, 21)
        Me.AssiPlug_Det_TextBox.TabIndex = 41
        Me.AssiPlug_Det_TextBox.Text = "?"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(20, 89)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(324, 16)
        Me.Label18.TabIndex = 47
        Me.Label18.Text = "Server and 4WMC working folder full path (latest):"
        '
        'EXEWorkingPath_TextBox
        '
        Me.EXEWorkingPath_TextBox.Location = New System.Drawing.Point(24, 161)
        Me.EXEWorkingPath_TextBox.Name = "EXEWorkingPath_TextBox"
        Me.EXEWorkingPath_TextBox.ReadOnly = True
        Me.EXEWorkingPath_TextBox.Size = New System.Drawing.Size(803, 21)
        Me.EXEWorkingPath_TextBox.TabIndex = 42
        '
        'ServerLiveTime_Textbox
        '
        Me.ServerLiveTime_Textbox.Location = New System.Drawing.Point(435, 49)
        Me.ServerLiveTime_Textbox.Name = "ServerLiveTime_Textbox"
        Me.ServerLiveTime_Textbox.ReadOnly = True
        Me.ServerLiveTime_Textbox.Size = New System.Drawing.Size(170, 21)
        Me.ServerLiveTime_Textbox.TabIndex = 43
        Me.ServerLiveTime_Textbox.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(41, 245)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(287, 16)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Note/Log/debug from system (Latest on top):"
        '
        'Command_err_ListBox
        '
        Me.Command_err_ListBox.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Command_err_ListBox.FormattingEnabled = True
        Me.Command_err_ListBox.ItemHeight = 15
        Me.Command_err_ListBox.Location = New System.Drawing.Point(44, 441)
        Me.Command_err_ListBox.Name = "Command_err_ListBox"
        Me.Command_err_ListBox.Size = New System.Drawing.Size(932, 139)
        Me.Command_err_ListBox.TabIndex = 14
        '
        'Note_ListBox
        '
        Me.Note_ListBox.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Note_ListBox.FormattingEnabled = True
        Me.Note_ListBox.ItemHeight = 15
        Me.Note_ListBox.Location = New System.Drawing.Point(41, 264)
        Me.Note_ListBox.Name = "Note_ListBox"
        Me.Note_ListBox.Size = New System.Drawing.Size(932, 139)
        Me.Note_ListBox.TabIndex = 45
        '
        'SP1Mon
        '
        Me.SP1Mon.Enabled = True
        Me.SP1Mon.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(468, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "COM:"
        '
        'COMState_Label
        '
        Me.COMState_Label.AutoSize = True
        Me.COMState_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.COMState_Label.Location = New System.Drawing.Point(516, 10)
        Me.COMState_Label.Name = "COMState_Label"
        Me.COMState_Label.Size = New System.Drawing.Size(34, 16)
        Me.COMState_Label.TabIndex = 27
        Me.COMState_Label.Text = "OFF"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SeaShell
        Me.Panel1.Controls.Add(Me.ServerType_Label)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.MCSState_Label)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.COMState_Label)
        Me.Panel1.Controls.Add(Me.RCState_Label)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(146, 657)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 36)
        Me.Panel1.TabIndex = 29
        '
        'ServerType_Label
        '
        Me.ServerType_Label.AutoSize = True
        Me.ServerType_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServerType_Label.Location = New System.Drawing.Point(748, 10)
        Me.ServerType_Label.Name = "ServerType_Label"
        Me.ServerType_Label.Size = New System.Drawing.Size(99, 16)
        Me.ServerType_Label.TabIndex = 40
        Me.ServerType_Label.Text = "Vanilla (or ND)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(591, 10)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 16)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Detected Server Type:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(29, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 16)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Minecraft Server:"
        '
        'WaitPanel
        '
        Me.WaitPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WaitPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WaitPanel.Controls.Add(Me.Label2)
        Me.WaitPanel.Location = New System.Drawing.Point(599, 300)
        Me.WaitPanel.Name = "WaitPanel"
        Me.WaitPanel.Size = New System.Drawing.Size(101, 50)
        Me.WaitPanel.TabIndex = 33
        Me.WaitPanel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Waiting..."
        '
        'BusyCrash
        '
        Me.BusyCrash.Interval = 10000
        '
        'BoxRefreshTimer
        '
        Me.BoxRefreshTimer.Enabled = True
        Me.BoxRefreshTimer.Interval = 250
        '
        'QueueEXE_RunnerTimer
        '
        Me.QueueEXE_RunnerTimer.Interval = 500
        '
        'PauseText_Button
        '
        Me.PauseText_Button.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PauseText_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PauseText_Button.Location = New System.Drawing.Point(12, 436)
        Me.PauseText_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PauseText_Button.Name = "PauseText_Button"
        Me.PauseText_Button.Size = New System.Drawing.Size(121, 58)
        Me.PauseText_Button.TabIndex = 37
        Me.PauseText_Button.Text = "Pause Text"
        Me.PauseText_Button.UseVisualStyleBackColor = False
        '
        'Stop_Button
        '
        Me.Stop_Button.Enabled = False
        Me.Stop_Button.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Stop_Button.Location = New System.Drawing.Point(12, 77)
        Me.Stop_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Stop_Button.Name = "Stop_Button"
        Me.Stop_Button.Size = New System.Drawing.Size(121, 58)
        Me.Stop_Button.TabIndex = 38
        Me.Stop_Button.Text = "Stop Server"
        Me.Stop_Button.UseVisualStyleBackColor = True
        '
        'TheWorkerCleaner
        '
        Me.TheWorkerCleaner.Enabled = True
        '
        'Pan_MCServer
        '
        Me.Pan_MCServer.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pan_MCServer.Controls.Add(Me.Button1)
        Me.Pan_MCServer.Controls.Add(Me.MCS_Richtexbox)
        Me.Pan_MCServer.Controls.Add(Me.MCS_ConsoleTextbox)
        Me.Pan_MCServer.Controls.Add(Me.Send2MCSButton)
        Me.Pan_MCServer.Location = New System.Drawing.Point(146, 41)
        Me.Pan_MCServer.Name = "Pan_MCServer"
        Me.Pan_MCServer.Size = New System.Drawing.Size(1016, 606)
        Me.Pan_MCServer.TabIndex = 39
        '
        'Pan_Console
        '
        Me.Pan_Console.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Pan_Console.Controls.Add(Me.EXE_Textbox)
        Me.Pan_Console.Controls.Add(Me.Kill_Mux_Con)
        Me.Pan_Console.Controls.Add(Me.ModeExeFW_Button)
        Me.Pan_Console.Controls.Add(Me.Send2EXE_Button)
        Me.Pan_Console.Controls.Add(Me.RestartCon_Button)
        Me.Pan_Console.Controls.Add(Me.Send2Exe_TextBox)
        Me.Pan_Console.Controls.Add(Me.EXECON_Stat_Label)
        Me.Pan_Console.Controls.Add(Me.Label11)
        Me.Pan_Console.Location = New System.Drawing.Point(146, 41)
        Me.Pan_Console.Name = "Pan_Console"
        Me.Pan_Console.Size = New System.Drawing.Size(1016, 606)
        Me.Pan_Console.TabIndex = 40
        '
        'Pan_Player
        '
        Me.Pan_Player.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Pan_Player.Controls.Add(Me.Button6)
        Me.Pan_Player.Controls.Add(Me.Label3)
        Me.Pan_Player.Controls.Add(Me.Label9)
        Me.Pan_Player.Controls.Add(Me.Player_Login)
        Me.Pan_Player.Controls.Add(Me.Label8)
        Me.Pan_Player.Controls.Add(Me.Player_Logout)
        Me.Pan_Player.Controls.Add(Me.Label7)
        Me.Pan_Player.Controls.Add(Me.Label4)
        Me.Pan_Player.Controls.Add(Me.Selected_Player)
        Me.Pan_Player.Controls.Add(Me.Button2)
        Me.Pan_Player.Controls.Add(Me.Label5)
        Me.Pan_Player.Controls.Add(Me.Button3)
        Me.Pan_Player.Controls.Add(Me.Button5)
        Me.Pan_Player.Controls.Add(Me.Button4)
        Me.Pan_Player.Location = New System.Drawing.Point(146, 41)
        Me.Pan_Player.Name = "Pan_Player"
        Me.Pan_Player.Size = New System.Drawing.Size(1016, 606)
        Me.Pan_Player.TabIndex = 41
        '
        'Pan_Info
        '
        Me.Pan_Info.BackColor = System.Drawing.Color.Maroon
        Me.Pan_Info.Controls.Add(Me.Label13)
        Me.Pan_Info.Controls.Add(Me.GroupBox1)
        Me.Pan_Info.Controls.Add(Me.Note_ListBox)
        Me.Pan_Info.Controls.Add(Me.Label17)
        Me.Pan_Info.Controls.Add(Me.Command_err_ListBox)
        Me.Pan_Info.Location = New System.Drawing.Point(146, 41)
        Me.Pan_Info.Name = "Pan_Info"
        Me.Pan_Info.Size = New System.Drawing.Size(1016, 606)
        Me.Pan_Info.TabIndex = 42
        '
        'PanMC_Btn
        '
        Me.PanMC_Btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanMC_Btn.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PanMC_Btn.Location = New System.Drawing.Point(146, 11)
        Me.PanMC_Btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanMC_Btn.Name = "PanMC_Btn"
        Me.PanMC_Btn.Size = New System.Drawing.Size(125, 29)
        Me.PanMC_Btn.TabIndex = 43
        Me.PanMC_Btn.Text = "Server Console"
        Me.PanMC_Btn.UseVisualStyleBackColor = False
        '
        'PanConsole_Btn
        '
        Me.PanConsole_Btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PanConsole_Btn.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PanConsole_Btn.Location = New System.Drawing.Point(273, 11)
        Me.PanConsole_Btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanConsole_Btn.Name = "PanConsole_Btn"
        Me.PanConsole_Btn.Size = New System.Drawing.Size(125, 29)
        Me.PanConsole_Btn.TabIndex = 44
        Me.PanConsole_Btn.Text = "Script Console"
        Me.PanConsole_Btn.UseVisualStyleBackColor = False
        '
        'PanPlayer_Btn
        '
        Me.PanPlayer_Btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanPlayer_Btn.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PanPlayer_Btn.Location = New System.Drawing.Point(400, 11)
        Me.PanPlayer_Btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanPlayer_Btn.Name = "PanPlayer_Btn"
        Me.PanPlayer_Btn.Size = New System.Drawing.Size(125, 29)
        Me.PanPlayer_Btn.TabIndex = 45
        Me.PanPlayer_Btn.Text = "Players (Detected)"
        Me.PanPlayer_Btn.UseVisualStyleBackColor = False
        '
        'PanInfo_Btn
        '
        Me.PanInfo_Btn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanInfo_Btn.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PanInfo_Btn.Location = New System.Drawing.Point(527, 11)
        Me.PanInfo_Btn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanInfo_Btn.Name = "PanInfo_Btn"
        Me.PanInfo_Btn.Size = New System.Drawing.Size(125, 29)
        Me.PanInfo_Btn.TabIndex = 46
        Me.PanInfo_Btn.Text = "Information"
        Me.PanInfo_Btn.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1177, 706)
        Me.Controls.Add(Me.PanInfo_Btn)
        Me.Controls.Add(Me.PanPlayer_Btn)
        Me.Controls.Add(Me.PanConsole_Btn)
        Me.Controls.Add(Me.PanMC_Btn)
        Me.Controls.Add(Me.Stop_Button)
        Me.Controls.Add(Me.PauseText_Button)
        Me.Controls.Add(Me.WaitPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ModeRC_Button)
        Me.Controls.Add(Me.HelpAbout_Button)
        Me.Controls.Add(Me.KillTaskButton)
        Me.Controls.Add(Me.BackupButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.SetupButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.Pan_Console)
        Me.Controls.Add(Me.Pan_Player)
        Me.Controls.Add(Me.Pan_MCServer)
        Me.Controls.Add(Me.Pan_Info)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "FourthWallMC < You don't need to break it, we put window on the wall. >  By overd" &
    "oingism Lab."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.WaitPanel.ResumeLayout(False)
        Me.WaitPanel.PerformLayout()
        Me.Pan_MCServer.ResumeLayout(False)
        Me.Pan_MCServer.PerformLayout()
        Me.Pan_Console.ResumeLayout(False)
        Me.Pan_Console.PerformLayout()
        Me.Pan_Player.ResumeLayout(False)
        Me.Pan_Player.PerformLayout()
        Me.Pan_Info.ResumeLayout(False)
        Me.Pan_Info.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StartButton As Button
    Friend WithEvents Send2MCSButton As Button
    Friend WithEvents MCS_ConsoleTextbox As TextBox
    Friend WithEvents MCS_Richtexbox As RichTextBox
    Friend WithEvents SetupButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents MCServerRefreshTimer As Timer
    Friend WithEvents MCSState_Label As Label
    Friend WithEvents ManServerTimeOutTimer As Timer
    Friend WithEvents ExitButton As Button
    Friend WithEvents BackupButton As Button
    Friend WithEvents KillTaskButton As Button
    Friend WithEvents HelpAbout_Button As Button
    Friend WithEvents RCState_Label As Label
    Friend WithEvents ModeRC_Button As Button
    Friend WithEvents Send2Exe_TextBox As TextBox
    Friend WithEvents Send2EXE_Button As Button
    Friend WithEvents ModeExeFW_Button As Button
    Friend WithEvents SP1 As System.IO.Ports.SerialPort
    Friend WithEvents SP1Mon As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents COMState_Label As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents WaitPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Player_Logout As ListBox
    Friend WithEvents Player_Login As ListBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Selected_Player As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents BusyCrash As Timer
    Friend WithEvents RestartCon_Button As Button
    Friend WithEvents EXECON_Stat_Label As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents BoxRefreshTimer As Timer
    Friend WithEvents Command_err_ListBox As ListBox
    Friend WithEvents Label13 As Label
    Friend WithEvents QueueEXE_RunnerTimer As Timer
    Friend WithEvents EXE_Textbox As RichTextBox
    Friend WithEvents PauseText_Button As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents ServerLiveTime_Textbox As TextBox
    Friend WithEvents EXEWorkingPath_TextBox As TextBox
    Friend WithEvents AssiPlug_Det_TextBox As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Note_ListBox As ListBox
    Friend WithEvents SerWorkingPath_TextBox As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Queue_TextBox As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Kill_Mux_Con As Button
    Friend WithEvents Stop_Button As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents ServerType_Label As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TheWorkerCleaner As Timer
    Friend WithEvents Pan_MCServer As Panel
    Friend WithEvents Pan_Console As Panel
    Friend WithEvents Pan_Player As Panel
    Friend WithEvents Pan_Info As Panel
    Friend WithEvents PanMC_Btn As Button
    Friend WithEvents PanConsole_Btn As Button
    Friend WithEvents PanPlayer_Btn As Button
    Friend WithEvents PanInfo_Btn As Button
End Class
