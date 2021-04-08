<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.BrowseJAR_Button = New System.Windows.Forms.Button()
        Me.JARPATH_Textbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.JVM_Textbox = New System.Windows.Forms.TextBox()
        Me.BrowseJVM_Button = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.JVMPar_Textbox = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SetupOK_Button = New System.Windows.Forms.Button()
        Me.SetupCancel_Button = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MCSPar_Textbox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ManPortNum = New System.Windows.Forms.NumericUpDown()
        Me.RCPassword_Textbox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BackupExe_Textbox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BackupTimeS_Textbox = New System.Windows.Forms.TextBox()
        Me.BrowseBackup_Button = New System.Windows.Forms.Button()
        Me.BackupPar_Textbox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.ExeViaSay_Checkbox = New System.Windows.Forms.CheckBox()
        Me.EssentialsDetected = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CBlockat_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.MCFilter_Textbox = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Autoexe_Textbox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PRIID_Textbox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.EXEside_Prefix_Checkbox = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.L_IPaddr_Combobox = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.WaitBusyLongAsCrash_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.DetAETimeS_Textbox = New System.Windows.Forms.TextBox()
        Me.DetAE_Para_TextBox = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.BrowseTER_Button = New System.Windows.Forms.Button()
        Me.DetAE_Run_TextBox = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.COMLineEnd = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComPortList = New System.Windows.Forms.ComboBox()
        Me.COMFilter_Textbox = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComPortSPD_NumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Console_Main_Arguments_Textbox = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Console_Mux_Arguments_Textbox = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Console_Shell_Exec_Textbox = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        CType(Me.ManPortNum, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.WaitBusyLongAsCrash_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ComPortSPD_NumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BrowseJAR_Button
        '
        Me.BrowseJAR_Button.Location = New System.Drawing.Point(18, 28)
        Me.BrowseJAR_Button.Name = "BrowseJAR_Button"
        Me.BrowseJAR_Button.Size = New System.Drawing.Size(87, 36)
        Me.BrowseJAR_Button.TabIndex = 0
        Me.BrowseJAR_Button.Text = "Browse"
        Me.BrowseJAR_Button.UseVisualStyleBackColor = True
        '
        'JARPATH_Textbox
        '
        Me.JARPATH_Textbox.Location = New System.Drawing.Point(117, 42)
        Me.JARPATH_Textbox.MaxLength = 1024
        Me.JARPATH_Textbox.Name = "JARPATH_Textbox"
        Me.JARPATH_Textbox.Size = New System.Drawing.Size(683, 21)
        Me.JARPATH_Textbox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(384, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Server JAR file location (Or use an existing BAT, but not recommend) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(309, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "JVM Java.exe location (Not necessary when using BAT):"
        '
        'JVM_Textbox
        '
        Me.JVM_Textbox.Location = New System.Drawing.Point(117, 97)
        Me.JVM_Textbox.MaxLength = 1024
        Me.JVM_Textbox.Name = "JVM_Textbox"
        Me.JVM_Textbox.Size = New System.Drawing.Size(683, 21)
        Me.JVM_Textbox.TabIndex = 4
        '
        'BrowseJVM_Button
        '
        Me.BrowseJVM_Button.Location = New System.Drawing.Point(18, 83)
        Me.BrowseJVM_Button.Name = "BrowseJVM_Button"
        Me.BrowseJVM_Button.Size = New System.Drawing.Size(87, 36)
        Me.BrowseJVM_Button.TabIndex = 3
        Me.BrowseJVM_Button.Text = "Browse"
        Me.BrowseJVM_Button.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(115, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(297, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "JVM launch parameter (Only available in JAR launch):"
        '
        'JVMPar_Textbox
        '
        Me.JVMPar_Textbox.Location = New System.Drawing.Point(117, 150)
        Me.JVMPar_Textbox.MaxLength = 1024
        Me.JVMPar_Textbox.Name = "JVMPar_Textbox"
        Me.JVMPar_Textbox.Size = New System.Drawing.Size(683, 21)
        Me.JVMPar_Textbox.TabIndex = 6
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SetupOK_Button
        '
        Me.SetupOK_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetupOK_Button.Location = New System.Drawing.Point(850, 40)
        Me.SetupOK_Button.Name = "SetupOK_Button"
        Me.SetupOK_Button.Size = New System.Drawing.Size(87, 36)
        Me.SetupOK_Button.TabIndex = 8
        Me.SetupOK_Button.Text = "Ok && Save"
        Me.SetupOK_Button.UseVisualStyleBackColor = True
        '
        'SetupCancel_Button
        '
        Me.SetupCancel_Button.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SetupCancel_Button.Location = New System.Drawing.Point(850, 92)
        Me.SetupCancel_Button.Name = "SetupCancel_Button"
        Me.SetupCancel_Button.Size = New System.Drawing.Size(87, 36)
        Me.SetupCancel_Button.TabIndex = 9
        Me.SetupCancel_Button.Text = "Cancel"
        Me.SetupCancel_Button.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(117, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "MC server launch parameter:"
        '
        'MCSPar_Textbox
        '
        Me.MCSPar_Textbox.Location = New System.Drawing.Point(117, 202)
        Me.MCSPar_Textbox.MaxLength = 1024
        Me.MCSPar_Textbox.Name = "MCSPar_Textbox"
        Me.MCSPar_Textbox.Size = New System.Drawing.Size(683, 21)
        Me.MCSPar_Textbox.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Connect  Port: (0 = off)"
        '
        'ManPortNum
        '
        Me.ManPortNum.Location = New System.Drawing.Point(20, 45)
        Me.ManPortNum.Maximum = New Decimal(New Integer() {65500, 0, 0, 0})
        Me.ManPortNum.Name = "ManPortNum"
        Me.ManPortNum.Size = New System.Drawing.Size(74, 21)
        Me.ManPortNum.TabIndex = 14
        Me.ManPortNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ManPortNum.Value = New Decimal(New Integer() {25566, 0, 0, 0})
        '
        'RCPassword_Textbox
        '
        Me.RCPassword_Textbox.Location = New System.Drawing.Point(171, 45)
        Me.RCPassword_Textbox.MaxLength = 15
        Me.RCPassword_Textbox.Name = "RCPassword_Textbox"
        Me.RCPassword_Textbox.Size = New System.Drawing.Size(161, 21)
        Me.RCPassword_Textbox.TabIndex = 15
        Me.RCPassword_Textbox.Text = "password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(168, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 15)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(115, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(290, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Backup / Compressor program location: (EXE / BAT)"
        '
        'BackupExe_Textbox
        '
        Me.BackupExe_Textbox.Location = New System.Drawing.Point(117, 42)
        Me.BackupExe_Textbox.MaxLength = 1024
        Me.BackupExe_Textbox.Name = "BackupExe_Textbox"
        Me.BackupExe_Textbox.Size = New System.Drawing.Size(683, 21)
        Me.BackupExe_Textbox.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(117, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(220, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Filename timestamp format: ( $TIME$ )"
        '
        'BackupTimeS_Textbox
        '
        Me.BackupTimeS_Textbox.Location = New System.Drawing.Point(116, 148)
        Me.BackupTimeS_Textbox.MaxLength = 16
        Me.BackupTimeS_Textbox.Name = "BackupTimeS_Textbox"
        Me.BackupTimeS_Textbox.Size = New System.Drawing.Size(152, 21)
        Me.BackupTimeS_Textbox.TabIndex = 20
        Me.BackupTimeS_Textbox.Text = "yyyyMMddHHmmss"
        '
        'BrowseBackup_Button
        '
        Me.BrowseBackup_Button.Location = New System.Drawing.Point(18, 28)
        Me.BrowseBackup_Button.Name = "BrowseBackup_Button"
        Me.BrowseBackup_Button.Size = New System.Drawing.Size(87, 36)
        Me.BrowseBackup_Button.TabIndex = 21
        Me.BrowseBackup_Button.Text = "Browse"
        Me.BrowseBackup_Button.UseVisualStyleBackColor = True
        '
        'BackupPar_Textbox
        '
        Me.BackupPar_Textbox.Location = New System.Drawing.Point(117, 96)
        Me.BackupPar_Textbox.MaxLength = 1024
        Me.BackupPar_Textbox.Name = "BackupPar_Textbox"
        Me.BackupPar_Textbox.Size = New System.Drawing.Size(683, 21)
        Me.BackupPar_Textbox.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(116, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(500, 15)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Backup / Compressor program parameter:  ( Use $TIME$ will be replaced with timest" &
    "amp)"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Controls.Add(Me.Label25)
        Me.GroupBox5.Controls.Add(Me.ExeViaSay_Checkbox)
        Me.GroupBox5.Controls.Add(Me.EssentialsDetected)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.CBlockat_CheckBox)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.MCFilter_Textbox)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.PRIID_Textbox)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Location = New System.Drawing.Point(23, 28)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(771, 224)
        Me.GroupBox5.TabIndex = 23
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Script console"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(377, 149)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(244, 15)
        Me.Label31.TabIndex = 40
        Me.Label31.Text = """CommandBlock"" all have privilege (by ""@"")"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(379, 172)
        Me.Label25.Name = "Label25"
        Me.Label25.Padding = New System.Windows.Forms.Padding(2)
        Me.Label25.Size = New System.Drawing.Size(322, 22)
        Me.Label25.TabIndex = 39
        Me.Label25.Text = "This option is useful for vanilla/forge etc., server."
        '
        'ExeViaSay_Checkbox
        '
        Me.ExeViaSay_Checkbox.AutoSize = True
        Me.ExeViaSay_Checkbox.Location = New System.Drawing.Point(379, 126)
        Me.ExeViaSay_Checkbox.Name = "ExeViaSay_Checkbox"
        Me.ExeViaSay_Checkbox.Size = New System.Drawing.Size(176, 19)
        Me.ExeViaSay_Checkbox.TabIndex = 38
        Me.ExeViaSay_Checkbox.Text = "Execute command via ""say"""
        Me.ExeViaSay_Checkbox.UseVisualStyleBackColor = True
        '
        'EssentialsDetected
        '
        Me.EssentialsDetected.AutoSize = True
        Me.EssentialsDetected.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.EssentialsDetected.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EssentialsDetected.Location = New System.Drawing.Point(324, 110)
        Me.EssentialsDetected.Name = "EssentialsDetected"
        Me.EssentialsDetected.Size = New System.Drawing.Size(16, 16)
        Me.EssentialsDetected.TabIndex = 37
        Me.EssentialsDetected.Text = "?"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(180, 110)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(147, 16)
        Me.Label23.TabIndex = 36
        Me.Label23.Text = "EssentialsX Detected: "
        '
        'CBlockat_CheckBox
        '
        Me.CBlockat_CheckBox.AutoSize = True
        Me.CBlockat_CheckBox.Checked = True
        Me.CBlockat_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBlockat_CheckBox.Location = New System.Drawing.Point(23, 172)
        Me.CBlockat_CheckBox.Name = "CBlockat_CheckBox"
        Me.CBlockat_CheckBox.Size = New System.Drawing.Size(217, 19)
        Me.CBlockat_CheckBox.TabIndex = 35
        Me.CBlockat_CheckBox.Text = """CommandBlock"" all have privilege"
        Me.CBlockat_CheckBox.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 195)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(253, 15)
        Me.Label22.TabIndex = 34
        Me.Label22.Text = "Else use full ""CommandBlock at x,y,z"" to work"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(21, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(321, 15)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "(Leave blank if not used, Case sensitive,  Separate use ; )"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(376, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(321, 15)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "(Leave blank if not used, Case sensitive,  Separate use ; )"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(21, 111)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(148, 15)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "With EssentialsX Plug-in: "
        '
        'MCFilter_Textbox
        '
        Me.MCFilter_Textbox.Location = New System.Drawing.Point(379, 53)
        Me.MCFilter_Textbox.Name = "MCFilter_Textbox"
        Me.MCFilter_Textbox.Size = New System.Drawing.Size(320, 21)
        Me.MCFilter_Textbox.TabIndex = 30
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(376, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(144, 15)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "MC→Console Flood filter"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(19, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(162, 15)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "2. CommandBlock workable"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(19, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(225, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "1. CONSOLE is an ID (Always available)"
        '
        'Autoexe_Textbox
        '
        Me.Autoexe_Textbox.Location = New System.Drawing.Point(379, 49)
        Me.Autoexe_Textbox.MaxLength = 65535
        Me.Autoexe_Textbox.Name = "Autoexe_Textbox"
        Me.Autoexe_Textbox.Size = New System.Drawing.Size(320, 21)
        Me.Autoexe_Textbox.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(376, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(223, 15)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "The auto-exec when Main console start:"
        '
        'PRIID_Textbox
        '
        Me.PRIID_Textbox.Location = New System.Drawing.Point(24, 53)
        Me.PRIID_Textbox.MaxLength = 65535
        Me.PRIID_Textbox.Name = "PRIID_Textbox"
        Me.PRIID_Textbox.Size = New System.Drawing.Size(320, 21)
        Me.PRIID_Textbox.TabIndex = 18
        Me.PRIID_Textbox.Text = "who1;who2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(215, 15)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Who has privilege? (ID, not nickname)"
        '
        'EXEside_Prefix_Checkbox
        '
        Me.EXEside_Prefix_Checkbox.AutoSize = True
        Me.EXEside_Prefix_Checkbox.Checked = True
        Me.EXEside_Prefix_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EXEside_Prefix_Checkbox.Enabled = False
        Me.EXEside_Prefix_Checkbox.Location = New System.Drawing.Point(437, 557)
        Me.EXEside_Prefix_Checkbox.Name = "EXEside_Prefix_Checkbox"
        Me.EXEside_Prefix_Checkbox.Size = New System.Drawing.Size(383, 19)
        Me.EXEside_Prefix_Checkbox.TabIndex = 22
        Me.EXEside_Prefix_Checkbox.Text = "EXE side start with ~(tilde) is server command injection (invisible)"
        Me.EXEside_Prefix_Checkbox.UseVisualStyleBackColor = True
        Me.EXEside_Prefix_Checkbox.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.L_IPaddr_Combobox)
        Me.GroupBox4.Controls.Add(Me.Label34)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.ManPortNum)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.RCPassword_Textbox)
        Me.GroupBox4.Location = New System.Drawing.Point(26, 23)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(771, 96)
        Me.GroupBox4.TabIndex = 22
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Remote control"
        '
        'L_IPaddr_Combobox
        '
        Me.L_IPaddr_Combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.L_IPaddr_Combobox.FormattingEnabled = True
        Me.L_IPaddr_Combobox.Items.AddRange(New Object() {"Any"})
        Me.L_IPaddr_Combobox.Location = New System.Drawing.Point(363, 45)
        Me.L_IPaddr_Combobox.Name = "L_IPaddr_Combobox"
        Me.L_IPaddr_Combobox.Size = New System.Drawing.Size(163, 23)
        Me.L_IPaddr_Combobox.TabIndex = 19
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(361, 29)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(100, 15)
        Me.Label34.TabIndex = 18
        Me.Label34.Text = "Local IP address"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(828, 600)
        Me.TabControl1.TabIndex = 27
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.BrowseJAR_Button)
        Me.TabPage1.Controls.Add(Me.JARPATH_Textbox)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.MCSPar_Textbox)
        Me.TabPage1.Controls.Add(Me.BrowseJVM_Button)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.JVM_Textbox)
        Me.TabPage1.Controls.Add(Me.JVMPar_Textbox)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(820, 572)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "MC server setting"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(820, 572)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Management setting"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.WaitBusyLongAsCrash_NumericUpDown)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.DetAETimeS_Textbox)
        Me.GroupBox2.Controls.Add(Me.DetAE_Para_TextBox)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.BrowseTER_Button)
        Me.GroupBox2.Controls.Add(Me.DetAE_Run_TextBox)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(771, 249)
        Me.GroupBox2.TabIndex = 25
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "What to execute if MCS abnormal termination:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(228, 208)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(140, 15)
        Me.Label33.TabIndex = 32
        Me.Label33.Text = "(in minutes. 0 = not use)"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(120, 188)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(574, 15)
        Me.Label32.TabIndex = 31
        Me.Label32.Text = "How long does it not return from BUSY mode, identify as crashed, and execute acti" &
    "ons (include kill task)."
        '
        'WaitBusyLongAsCrash_NumericUpDown
        '
        Me.WaitBusyLongAsCrash_NumericUpDown.Location = New System.Drawing.Point(123, 206)
        Me.WaitBusyLongAsCrash_NumericUpDown.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.WaitBusyLongAsCrash_NumericUpDown.Name = "WaitBusyLongAsCrash_NumericUpDown"
        Me.WaitBusyLongAsCrash_NumericUpDown.ReadOnly = True
        Me.WaitBusyLongAsCrash_NumericUpDown.Size = New System.Drawing.Size(90, 21)
        Me.WaitBusyLongAsCrash_NumericUpDown.TabIndex = 30
        Me.WaitBusyLongAsCrash_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(458, 138)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(293, 15)
        Me.Label30.TabIndex = 29
        Me.Label30.Text = "you may use $FAIL$ to determine to avoid over run."
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(460, 123)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(175, 15)
        Me.Label29.TabIndex = 28
        Me.Label29.Text = "If there is a restart command,"
        '
        'DetAETimeS_Textbox
        '
        Me.DetAETimeS_Textbox.Location = New System.Drawing.Point(119, 150)
        Me.DetAETimeS_Textbox.MaxLength = 16
        Me.DetAETimeS_Textbox.Name = "DetAETimeS_Textbox"
        Me.DetAETimeS_Textbox.Size = New System.Drawing.Size(152, 21)
        Me.DetAETimeS_Textbox.TabIndex = 25
        Me.DetAETimeS_Textbox.Text = "yyyyMMddHHmmss"
        '
        'DetAE_Para_TextBox
        '
        Me.DetAE_Para_TextBox.Location = New System.Drawing.Point(120, 99)
        Me.DetAE_Para_TextBox.MaxLength = 1024
        Me.DetAE_Para_TextBox.Name = "DetAE_Para_TextBox"
        Me.DetAE_Para_TextBox.Size = New System.Drawing.Size(631, 21)
        Me.DetAE_Para_TextBox.TabIndex = 27
        Me.DetAE_Para_TextBox.Text = "$TIME$ $FAIL$"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(120, 135)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(169, 15)
        Me.Label27.TabIndex = 24
        Me.Label27.Text = "Timestamp format: ( $TIME$ )"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(119, 84)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(541, 15)
        Me.Label28.TabIndex = 26
        Me.Label28.Text = "Parameter:  ( Use $TIME$ will be replaced with timestamp, $FAIL$ will be replaced" &
    " with fail times.)"
        '
        'BrowseTER_Button
        '
        Me.BrowseTER_Button.Location = New System.Drawing.Point(20, 32)
        Me.BrowseTER_Button.Name = "BrowseTER_Button"
        Me.BrowseTER_Button.Size = New System.Drawing.Size(87, 36)
        Me.BrowseTER_Button.TabIndex = 3
        Me.BrowseTER_Button.Text = "Browse"
        Me.BrowseTER_Button.UseVisualStyleBackColor = True
        '
        'DetAE_Run_TextBox
        '
        Me.DetAE_Run_TextBox.Location = New System.Drawing.Point(119, 46)
        Me.DetAE_Run_TextBox.MaxLength = 1024
        Me.DetAE_Run_TextBox.Name = "DetAE_Run_TextBox"
        Me.DetAE_Run_TextBox.Size = New System.Drawing.Size(632, 21)
        Me.DetAE_Run_TextBox.TabIndex = 4
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(119, 31)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(137, 15)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "If not use, leave it blank."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(232, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.COMLineEnd)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.ComPortList)
        Me.GroupBox1.Controls.Add(Me.COMFilter_Textbox)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ComPortSPD_NumericUpDown)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 401)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(771, 140)
        Me.GroupBox1.TabIndex = 24
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Serial Port (Fully redirect) ( N,8,1 Soft flow )"
        '
        'COMLineEnd
        '
        Me.COMLineEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.COMLineEnd.FormattingEnabled = True
        Me.COMLineEnd.Items.AddRange(New Object() {"None", "13 (\r)", "10 (\n)", "13+10 (Win)"})
        Me.COMLineEnd.Location = New System.Drawing.Point(300, 46)
        Me.COMLineEnd.Name = "COMLineEnd"
        Me.COMLineEnd.Size = New System.Drawing.Size(121, 23)
        Me.COMLineEnd.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(297, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 15)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Line end type:"
        '
        'ComPortList
        '
        Me.ComPortList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComPortList.FormattingEnabled = True
        Me.ComPortList.Items.AddRange(New Object() {"OFF"})
        Me.ComPortList.Location = New System.Drawing.Point(20, 46)
        Me.ComPortList.Name = "ComPortList"
        Me.ComPortList.Size = New System.Drawing.Size(121, 23)
        Me.ComPortList.TabIndex = 20
        '
        'COMFilter_Textbox
        '
        Me.COMFilter_Textbox.Location = New System.Drawing.Point(20, 101)
        Me.COMFilter_Textbox.Name = "COMFilter_Textbox"
        Me.COMFilter_Textbox.Size = New System.Drawing.Size(366, 21)
        Me.COMFilter_Textbox.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(17, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(362, 15)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "Tx filter (Leave blank if not used, Case sensitive,  Separate use ; )"
        '
        'ComPortSPD_NumericUpDown
        '
        Me.ComPortSPD_NumericUpDown.Increment = New Decimal(New Integer() {9600, 0, 0, 0})
        Me.ComPortSPD_NumericUpDown.Location = New System.Drawing.Point(173, 48)
        Me.ComPortSPD_NumericUpDown.Maximum = New Decimal(New Integer() {230400, 0, 0, 0})
        Me.ComPortSPD_NumericUpDown.Minimum = New Decimal(New Integer() {9600, 0, 0, 0})
        Me.ComPortSPD_NumericUpDown.Name = "ComPortSPD_NumericUpDown"
        Me.ComPortSPD_NumericUpDown.ReadOnly = True
        Me.ComPortSPD_NumericUpDown.Size = New System.Drawing.Size(90, 21)
        Me.ComPortSPD_NumericUpDown.TabIndex = 17
        Me.ComPortSPD_NumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ComPortSPD_NumericUpDown.Value = New Decimal(New Integer() {9600, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 15)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "COM Port:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(171, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 15)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Speed (bps)"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.Label24)
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Controls.Add(Me.EXEside_Prefix_Checkbox)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(820, 572)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Script Console setting"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(127, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Padding = New System.Windows.Forms.Padding(2)
        Me.Label24.Size = New System.Drawing.Size(444, 22)
        Me.Label24.TabIndex = 37
        Me.Label24.Text = " ( Execute command in world is best with Spigot / PaperMC Server )"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.BrowseBackup_Button)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.BackupTimeS_Textbox)
        Me.TabPage3.Controls.Add(Me.BackupPar_Textbox)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.BackupExe_Textbox)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(820, 572)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Backup setting"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.Label35)
        Me.GroupBox3.Controls.Add(Me.Console_Main_Arguments_Textbox)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.Console_Mux_Arguments_Textbox)
        Me.GroupBox3.Controls.Add(Me.Label46)
        Me.GroupBox3.Controls.Add(Me.Console_Shell_Exec_Textbox)
        Me.GroupBox3.Controls.Add(Me.Label47)
        Me.GroupBox3.Controls.Add(Me.Autoexe_Textbox)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(23, 277)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(771, 165)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Console Shell settings  (If you don't know the purpose, please do not modify it. " &
    ")"
        '
        'Console_Main_Arguments_Textbox
        '
        Me.Console_Main_Arguments_Textbox.Location = New System.Drawing.Point(24, 120)
        Me.Console_Main_Arguments_Textbox.Name = "Console_Main_Arguments_Textbox"
        Me.Console_Main_Arguments_Textbox.Size = New System.Drawing.Size(320, 21)
        Me.Console_Main_Arguments_Textbox.TabIndex = 30
        Me.Console_Main_Arguments_Textbox.Text = "-NoExit -Command"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(23, 102)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(239, 15)
        Me.Label43.TabIndex = 29
        Me.Label43.Text = "Main console auto-exec launch parameter:"
        '
        'Console_Mux_Arguments_Textbox
        '
        Me.Console_Mux_Arguments_Textbox.Location = New System.Drawing.Point(379, 120)
        Me.Console_Mux_Arguments_Textbox.MaxLength = 65535
        Me.Console_Mux_Arguments_Textbox.Name = "Console_Mux_Arguments_Textbox"
        Me.Console_Mux_Arguments_Textbox.Size = New System.Drawing.Size(320, 21)
        Me.Console_Mux_Arguments_Textbox.TabIndex = 23
        Me.Console_Mux_Arguments_Textbox.Text = "-Command"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(376, 102)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(178, 15)
        Me.Label46.TabIndex = 24
        Me.Label46.Text = "Mux console launch parameter:"
        '
        'Console_Shell_Exec_Textbox
        '
        Me.Console_Shell_Exec_Textbox.Location = New System.Drawing.Point(24, 49)
        Me.Console_Shell_Exec_Textbox.MaxLength = 65535
        Me.Console_Shell_Exec_Textbox.Name = "Console_Shell_Exec_Textbox"
        Me.Console_Shell_Exec_Textbox.Size = New System.Drawing.Size(320, 21)
        Me.Console_Shell_Exec_Textbox.TabIndex = 18
        Me.Console_Shell_Exec_Textbox.Text = "Powershell.exe"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(21, 32)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(258, 15)
        Me.Label47.TabIndex = 19
        Me.Label47.Text = "The Shell (Filename or command name only):"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(376, 73)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(144, 15)
        Me.Label35.TabIndex = 31
        Me.Label35.Text = "(Leave blank if not used.)"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 625)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.SetupCancel_Button)
        Me.Controls.Add(Me.SetupOK_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form2"
        Me.Text = "Setup"
        CType(Me.ManPortNum, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.WaitBusyLongAsCrash_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ComPortSPD_NumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BrowseJAR_Button As Button
    Friend WithEvents JARPATH_Textbox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents JVM_Textbox As TextBox
    Friend WithEvents BrowseJVM_Button As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents JVMPar_Textbox As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SetupOK_Button As Button
    Friend WithEvents SetupCancel_Button As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents MCSPar_Textbox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ManPortNum As NumericUpDown
    Friend WithEvents RCPassword_Textbox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents BackupExe_Textbox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents BackupTimeS_Textbox As TextBox
    Friend WithEvents BrowseBackup_Button As Button
    Friend WithEvents BackupPar_Textbox As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents PRIID_Textbox As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents EXEside_Prefix_Checkbox As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Autoexe_Textbox As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents COMFilter_Textbox As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ComPortSPD_NumericUpDown As NumericUpDown
    Friend WithEvents ComPortList As ComboBox
    Friend WithEvents COMLineEnd As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents MCFilter_Textbox As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents CBlockat_CheckBox As CheckBox
    Friend WithEvents Label22 As Label
    Friend WithEvents EssentialsDetected As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents ExeViaSay_Checkbox As CheckBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BrowseTER_Button As Button
    Friend WithEvents DetAE_Run_TextBox As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents DetAETimeS_Textbox As TextBox
    Friend WithEvents DetAE_Para_TextBox As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents WaitBusyLongAsCrash_NumericUpDown As NumericUpDown
    Friend WithEvents Label34 As Label
    Friend WithEvents L_IPaddr_Combobox As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Console_Main_Arguments_Textbox As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Console_Mux_Arguments_Textbox As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents Console_Shell_Exec_Textbox As TextBox
    Friend WithEvents Label47 As Label
    Friend WithEvents Label35 As Label
End Class
