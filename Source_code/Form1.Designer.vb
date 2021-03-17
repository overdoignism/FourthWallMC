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
        Me.BoxRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ManServerRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MCServerRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MCSState_Label = New System.Windows.Forms.Label()
        Me.ManServerTimeOutTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CPUUsage_Label = New System.Windows.Forms.Label()
        Me.MemUsage_Label = New System.Windows.Forms.Label()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.BackupButton = New System.Windows.Forms.Button()
        Me.KillTaskButton = New System.Windows.Forms.Button()
        Me.HelpAbout_Button = New System.Windows.Forms.Button()
        Me.RCState_Label = New System.Windows.Forms.Label()
        Me.ModeRC_Button = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Send2Exe_TextBox = New System.Windows.Forms.TextBox()
        Me.EXE_Texbox = New System.Windows.Forms.TextBox()
        Me.Send2EXE_Button = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
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
        Me.EXE_BoxRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ModeExeFW_Button = New System.Windows.Forms.Button()
        Me.SP1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SP1Mon = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.COMState_Label = New System.Windows.Forms.Label()
        Me.ModeExeBM_Button = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BurstModeButton = New System.Windows.Forms.Button()
        Me.WaitPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.WaitPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Send2MCSButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Send2MCSButton.Location = New System.Drawing.Point(934, 572)
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
        Me.MCS_ConsoleTextbox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCS_ConsoleTextbox.ForeColor = System.Drawing.Color.Silver
        Me.MCS_ConsoleTextbox.Location = New System.Drawing.Point(87, 574)
        Me.MCS_ConsoleTextbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MCS_ConsoleTextbox.Name = "MCS_ConsoleTextbox"
        Me.MCS_ConsoleTextbox.Size = New System.Drawing.Size(842, 26)
        Me.MCS_ConsoleTextbox.TabIndex = 4
        '
        'MCS_Richtexbox
        '
        Me.MCS_Richtexbox.BackColor = System.Drawing.Color.Black
        Me.MCS_Richtexbox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCS_Richtexbox.ForeColor = System.Drawing.Color.Silver
        Me.MCS_Richtexbox.Location = New System.Drawing.Point(6, 7)
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
        Me.SetupButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetupButton.Location = New System.Drawing.Point(12, 139)
        Me.SetupButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SetupButton.Name = "SetupButton"
        Me.SetupButton.Size = New System.Drawing.Size(121, 58)
        Me.SetupButton.TabIndex = 6
        Me.SetupButton.Text = "Setup"
        Me.SetupButton.UseVisualStyleBackColor = True
        '
        'BoxRefreshTimer
        '
        Me.BoxRefreshTimer.Interval = 500
        '
        'ManServerRefreshTimer
        '
        Me.ManServerRefreshTimer.Enabled = True
        Me.ManServerRefreshTimer.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(196, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Management RemoteCon: "
        '
        'MCServerRefreshTimer
        '
        Me.MCServerRefreshTimer.Enabled = True
        Me.MCServerRefreshTimer.Interval = 1000
        '
        'MCSState_Label
        '
        Me.MCSState_Label.AutoSize = True
        Me.MCSState_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MCSState_Label.Location = New System.Drawing.Point(16, 10)
        Me.MCSState_Label.Name = "MCSState_Label"
        Me.MCSState_Label.Size = New System.Drawing.Size(147, 16)
        Me.MCSState_Label.TabIndex = 11
        Me.MCSState_Label.Text = "Minecraft Server: OFF"
        '
        'ManServerTimeOutTimer
        '
        Me.ManServerTimeOutTimer.Enabled = True
        Me.ManServerTimeOutTimer.Interval = 1000
        '
        'CPUUsage_Label
        '
        Me.CPUUsage_Label.AutoSize = True
        Me.CPUUsage_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CPUUsage_Label.Location = New System.Drawing.Point(471, 10)
        Me.CPUUsage_Label.Name = "CPUUsage_Label"
        Me.CPUUsage_Label.Size = New System.Drawing.Size(111, 16)
        Me.CPUUsage_Label.TabIndex = 12
        Me.CPUUsage_Label.Text = "CPU: 0.0% / 0.0%"
        '
        'MemUsage_Label
        '
        Me.MemUsage_Label.AutoSize = True
        Me.MemUsage_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MemUsage_Label.Location = New System.Drawing.Point(646, 10)
        Me.MemUsage_Label.Name = "MemUsage_Label"
        Me.MemUsage_Label.Size = New System.Drawing.Size(143, 16)
        Me.MemUsage_Label.TabIndex = 13
        Me.MemUsage_Label.Text = "Mem: 0.0 MB / 0.0 MB"
        '
        'ExitButton
        '
        Me.ExitButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitButton.Location = New System.Drawing.Point(11, 631)
        Me.ExitButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(121, 58)
        Me.ExitButton.TabIndex = 14
        Me.ExitButton.Text = "Exit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'BackupButton
        '
        Me.BackupButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackupButton.Location = New System.Drawing.Point(12, 75)
        Me.BackupButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BackupButton.Name = "BackupButton"
        Me.BackupButton.Size = New System.Drawing.Size(121, 58)
        Me.BackupButton.TabIndex = 15
        Me.BackupButton.Text = "Backup Server"
        Me.BackupButton.UseVisualStyleBackColor = True
        '
        'KillTaskButton
        '
        Me.KillTaskButton.Enabled = False
        Me.KillTaskButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KillTaskButton.Location = New System.Drawing.Point(11, 503)
        Me.KillTaskButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.KillTaskButton.Name = "KillTaskButton"
        Me.KillTaskButton.Size = New System.Drawing.Size(121, 58)
        Me.KillTaskButton.TabIndex = 16
        Me.KillTaskButton.Text = "Kill Task"
        Me.KillTaskButton.UseVisualStyleBackColor = True
        '
        'HelpAbout_Button
        '
        Me.HelpAbout_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpAbout_Button.Location = New System.Drawing.Point(11, 567)
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
        Me.RCState_Label.BackColor = System.Drawing.Color.Black
        Me.RCState_Label.Font = New System.Drawing.Font("Arial Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RCState_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RCState_Label.Location = New System.Drawing.Point(384, 10)
        Me.RCState_Label.Name = "RCState_Label"
        Me.RCState_Label.Size = New System.Drawing.Size(37, 18)
        Me.RCState_Label.TabIndex = 18
        Me.RCState_Label.Text = "OFF"
        '
        'ModeRC_Button
        '
        Me.ModeRC_Button.BackColor = System.Drawing.Color.White
        Me.ModeRC_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeRC_Button.Location = New System.Drawing.Point(11, 227)
        Me.ModeRC_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModeRC_Button.Name = "ModeRC_Button"
        Me.ModeRC_Button.Size = New System.Drawing.Size(121, 58)
        Me.ModeRC_Button.TabIndex = 19
        Me.ModeRC_Button.Text = "RemoteCon"
        Me.ModeRC_Button.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(141, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1026, 635)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.MCS_Richtexbox)
        Me.TabPage1.Controls.Add(Me.MCS_ConsoleTextbox)
        Me.TabPage1.Controls.Add(Me.Send2MCSButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1018, 607)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Server console"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(5, 572)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 29)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Rapid"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.Send2Exe_TextBox)
        Me.TabPage2.Controls.Add(Me.EXE_Texbox)
        Me.TabPage2.Controls.Add(Me.Send2EXE_Button)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1018, 607)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "EXE console"
        '
        'Send2Exe_TextBox
        '
        Me.Send2Exe_TextBox.BackColor = System.Drawing.Color.Black
        Me.Send2Exe_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Send2Exe_TextBox.ForeColor = System.Drawing.Color.Silver
        Me.Send2Exe_TextBox.Location = New System.Drawing.Point(6, 574)
        Me.Send2Exe_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Send2Exe_TextBox.Name = "Send2Exe_TextBox"
        Me.Send2Exe_TextBox.Size = New System.Drawing.Size(923, 26)
        Me.Send2Exe_TextBox.TabIndex = 26
        '
        'EXE_Texbox
        '
        Me.EXE_Texbox.BackColor = System.Drawing.Color.Black
        Me.EXE_Texbox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EXE_Texbox.ForeColor = System.Drawing.Color.Silver
        Me.EXE_Texbox.Location = New System.Drawing.Point(6, 6)
        Me.EXE_Texbox.MaxLength = 1048576
        Me.EXE_Texbox.Multiline = True
        Me.EXE_Texbox.Name = "EXE_Texbox"
        Me.EXE_Texbox.ReadOnly = True
        Me.EXE_Texbox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.EXE_Texbox.Size = New System.Drawing.Size(1006, 560)
        Me.EXE_Texbox.TabIndex = 0
        '
        'Send2EXE_Button
        '
        Me.Send2EXE_Button.Enabled = False
        Me.Send2EXE_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Send2EXE_Button.Location = New System.Drawing.Point(935, 573)
        Me.Send2EXE_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Send2EXE_Button.Name = "Send2EXE_Button"
        Me.Send2EXE_Button.Size = New System.Drawing.Size(77, 29)
        Me.Send2EXE_Button.TabIndex = 25
        Me.Send2EXE_Button.Text = "Send"
        Me.Send2EXE_Button.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.Button6)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Selected_Player)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Button5)
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.Button3)
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Player_Logout)
        Me.TabPage3.Controls.Add(Me.Player_Login)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1018, 607)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Players (Detected)"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(652, 252)
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
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(87, 572)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(527, 16)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "This list is re-generated after each Minecraft Server startup.  Not all played pl" &
    "ayer."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(649, 530)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(234, 16)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "You need press <Send> by yourself."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(649, 509)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(218, 16)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Just input to command send box."
        '
        'Selected_Player
        '
        Me.Selected_Player.AutoSize = True
        Me.Selected_Player.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Selected_Player.Location = New System.Drawing.Point(649, 80)
        Me.Selected_Player.Name = "Selected_Player"
        Me.Selected_Player.Size = New System.Drawing.Size(48, 16)
        Me.Selected_Player.TabIndex = 42
        Me.Selected_Player.Text = "(none)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(649, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Now selected:"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(652, 384)
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
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(652, 318)
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
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(652, 186)
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
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(652, 120)
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
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(340, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Logged out:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(130, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Logged in (Online):"
        '
        'Player_Logout
        '
        Me.Player_Logout.FormattingEnabled = True
        Me.Player_Logout.ItemHeight = 15
        Me.Player_Logout.Location = New System.Drawing.Point(343, 54)
        Me.Player_Logout.Name = "Player_Logout"
        Me.Player_Logout.Size = New System.Drawing.Size(290, 499)
        Me.Player_Logout.Sorted = True
        Me.Player_Logout.TabIndex = 1
        '
        'Player_Login
        '
        Me.Player_Login.FormattingEnabled = True
        Me.Player_Login.ItemHeight = 15
        Me.Player_Login.Location = New System.Drawing.Point(45, 54)
        Me.Player_Login.Name = "Player_Login"
        Me.Player_Login.Size = New System.Drawing.Size(290, 499)
        Me.Player_Login.Sorted = True
        Me.Player_Login.TabIndex = 0
        '
        'EXE_BoxRefreshTimer
        '
        Me.EXE_BoxRefreshTimer.Interval = 500
        '
        'ModeExeFW_Button
        '
        Me.ModeExeFW_Button.BackColor = System.Drawing.Color.White
        Me.ModeExeFW_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeExeFW_Button.Location = New System.Drawing.Point(11, 290)
        Me.ModeExeFW_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModeExeFW_Button.Name = "ModeExeFW_Button"
        Me.ModeExeFW_Button.Size = New System.Drawing.Size(121, 58)
        Me.ModeExeFW_Button.TabIndex = 25
        Me.ModeExeFW_Button.Text = "EXE Flood way"
        Me.ModeExeFW_Button.UseVisualStyleBackColor = False
        '
        'SP1
        '
        Me.SP1.ReadBufferSize = 64
        Me.SP1.ReadTimeout = 1
        Me.SP1.WriteBufferSize = 16
        Me.SP1.WriteTimeout = 10
        '
        'SP1Mon
        '
        Me.SP1Mon.Enabled = True
        Me.SP1Mon.Interval = 1000
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(883, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "COM:"
        '
        'COMState_Label
        '
        Me.COMState_Label.AutoSize = True
        Me.COMState_Label.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMState_Label.Location = New System.Drawing.Point(931, 10)
        Me.COMState_Label.Name = "COMState_Label"
        Me.COMState_Label.Size = New System.Drawing.Size(34, 16)
        Me.COMState_Label.TabIndex = 27
        Me.COMState_Label.Text = "OFF"
        '
        'ModeExeBM_Button
        '
        Me.ModeExeBM_Button.BackColor = System.Drawing.Color.White
        Me.ModeExeBM_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModeExeBM_Button.Location = New System.Drawing.Point(11, 354)
        Me.ModeExeBM_Button.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModeExeBM_Button.Name = "ModeExeBM_Button"
        Me.ModeExeBM_Button.Size = New System.Drawing.Size(121, 58)
        Me.ModeExeBM_Button.TabIndex = 28
        Me.ModeExeBM_Button.Text = "EXE Back mode"
        Me.ModeExeBM_Button.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SeaShell
        Me.Panel1.Controls.Add(Me.MCSState_Label)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.COMState_Label)
        Me.Panel1.Controls.Add(Me.RCState_Label)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.CPUUsage_Label)
        Me.Panel1.Controls.Add(Me.MemUsage_Label)
        Me.Panel1.Location = New System.Drawing.Point(148, 654)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 36)
        Me.Panel1.TabIndex = 29
        '
        'BurstModeButton
        '
        Me.BurstModeButton.BackColor = System.Drawing.Color.White
        Me.BurstModeButton.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BurstModeButton.Location = New System.Drawing.Point(11, 418)
        Me.BurstModeButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BurstModeButton.Name = "BurstModeButton"
        Me.BurstModeButton.Size = New System.Drawing.Size(121, 58)
        Me.BurstModeButton.TabIndex = 30
        Me.BurstModeButton.Text = "Burst Mode"
        Me.BurstModeButton.UseVisualStyleBackColor = False
        '
        'WaitPanel
        '
        Me.WaitPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.WaitPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.WaitPanel.Controls.Add(Me.Label2)
        Me.WaitPanel.Location = New System.Drawing.Point(600, 300)
        Me.WaitPanel.Name = "WaitPanel"
        Me.WaitPanel.Size = New System.Drawing.Size(101, 50)
        Me.WaitPanel.TabIndex = 33
        Me.WaitPanel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Waiting..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1177, 700)
        Me.Controls.Add(Me.WaitPanel)
        Me.Controls.Add(Me.BurstModeButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ModeExeBM_Button)
        Me.Controls.Add(Me.ModeExeFW_Button)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ModeRC_Button)
        Me.Controls.Add(Me.HelpAbout_Button)
        Me.Controls.Add(Me.KillTaskButton)
        Me.Controls.Add(Me.BackupButton)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.SetupButton)
        Me.Controls.Add(Me.StartButton)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "FourthWallMC v0.78 < You don't need to break it, we put window on the wall. >  By" &
    " overdoingism Lab."
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.WaitPanel.ResumeLayout(False)
        Me.WaitPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents StartButton As Button
    Friend WithEvents Send2MCSButton As Button
    Friend WithEvents MCS_ConsoleTextbox As TextBox
    Friend WithEvents MCS_Richtexbox As RichTextBox
    Friend WithEvents SetupButton As Button
    Friend WithEvents BoxRefreshTimer As Timer
    Friend WithEvents ManServerRefreshTimer As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents MCServerRefreshTimer As Timer
    Friend WithEvents MCSState_Label As Label
    Friend WithEvents ManServerTimeOutTimer As Timer
    Friend WithEvents CPUUsage_Label As Label
    Friend WithEvents MemUsage_Label As Label
    Friend WithEvents ExitButton As Button
    Friend WithEvents BackupButton As Button
    Friend WithEvents KillTaskButton As Button
    Friend WithEvents HelpAbout_Button As Button
    Friend WithEvents RCState_Label As Label
    Friend WithEvents ModeRC_Button As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents EXE_BoxRefreshTimer As Timer
    Friend WithEvents EXE_Texbox As TextBox
    Friend WithEvents Send2Exe_TextBox As TextBox
    Friend WithEvents Send2EXE_Button As Button
    Friend WithEvents ModeExeFW_Button As Button
    Friend WithEvents SP1 As IO.Ports.SerialPort
    Friend WithEvents SP1Mon As Timer
    Friend WithEvents Label6 As Label
    Friend WithEvents COMState_Label As Label
    Friend WithEvents ModeExeBM_Button As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BurstModeButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents WaitPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage3 As TabPage
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
End Class
