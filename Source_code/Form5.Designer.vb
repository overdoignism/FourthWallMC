<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Motd_TextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.serverp_TextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.leveln_TextBox = New System.Windows.Forms.TextBox()
        Me.levels_TextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.levelt_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.genstr_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.genset_TextBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.encb_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dif_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.whil_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.serverip_TextBox = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.gamem_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Motd_TextBox
        '
        Me.Motd_TextBox.BackColor = System.Drawing.Color.White
        Me.Motd_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Motd_TextBox.ForeColor = System.Drawing.Color.Black
        Me.Motd_TextBox.Location = New System.Drawing.Point(189, 48)
        Me.Motd_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Motd_TextBox.MaxLength = 100
        Me.Motd_TextBox.Name = "Motd_TextBox"
        Me.Motd_TextBox.Size = New System.Drawing.Size(321, 26)
        Me.Motd_TextBox.TabIndex = 52
        Me.Motd_TextBox.Text = "A Minecraft Server (+4WMC)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "motd="
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(521, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "World name."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(521, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 16)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Minecraft server port."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(521, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 16)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Minecraft server title message."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "server-port="
        '
        'serverp_TextBox
        '
        Me.serverp_TextBox.BackColor = System.Drawing.Color.White
        Me.serverp_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serverp_TextBox.ForeColor = System.Drawing.Color.Black
        Me.serverp_TextBox.Location = New System.Drawing.Point(189, 84)
        Me.serverp_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.serverp_TextBox.MaxLength = 100
        Me.serverp_TextBox.Name = "serverp_TextBox"
        Me.serverp_TextBox.Size = New System.Drawing.Size(321, 26)
        Me.serverp_TextBox.TabIndex = 60
        Me.serverp_TextBox.Text = "25565"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 16)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "level-name="
        '
        'leveln_TextBox
        '
        Me.leveln_TextBox.BackColor = System.Drawing.Color.White
        Me.leveln_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.leveln_TextBox.ForeColor = System.Drawing.Color.Black
        Me.leveln_TextBox.Location = New System.Drawing.Point(189, 156)
        Me.leveln_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.leveln_TextBox.MaxLength = 100
        Me.leveln_TextBox.Name = "leveln_TextBox"
        Me.leveln_TextBox.Size = New System.Drawing.Size(321, 26)
        Me.leveln_TextBox.TabIndex = 62
        Me.leveln_TextBox.Text = "world"
        '
        'levels_TextBox
        '
        Me.levels_TextBox.BackColor = System.Drawing.Color.White
        Me.levels_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.levels_TextBox.ForeColor = System.Drawing.Color.Black
        Me.levels_TextBox.Location = New System.Drawing.Point(189, 192)
        Me.levels_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.levels_TextBox.MaxLength = 100
        Me.levels_TextBox.Name = "levels_TextBox"
        Me.levels_TextBox.Size = New System.Drawing.Size(321, 26)
        Me.levels_TextBox.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 195)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "level-seed="
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(521, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 16)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "World seed value."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 231)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 16)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "level-type="
        '
        'levelt_ComboBox
        '
        Me.levelt_ComboBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.levelt_ComboBox.FormattingEnabled = True
        Me.levelt_ComboBox.Items.AddRange(New Object() {"default", "flat", "largebiomes", "amplified", "buffet"})
        Me.levelt_ComboBox.Location = New System.Drawing.Point(189, 228)
        Me.levelt_ComboBox.Name = "levelt_ComboBox"
        Me.levelt_ComboBox.Size = New System.Drawing.Size(321, 26)
        Me.levelt_ComboBox.TabIndex = 67
        Me.levelt_ComboBox.Text = "default"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(521, 232)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "World type."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 269)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 16)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "generate-structures="
        '
        'genstr_ComboBox
        '
        Me.genstr_ComboBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.genstr_ComboBox.FormattingEnabled = True
        Me.genstr_ComboBox.Items.AddRange(New Object() {"true", "false"})
        Me.genstr_ComboBox.Location = New System.Drawing.Point(189, 264)
        Me.genstr_ComboBox.Name = "genstr_ComboBox"
        Me.genstr_ComboBox.Size = New System.Drawing.Size(321, 26)
        Me.genstr_ComboBox.TabIndex = 70
        Me.genstr_ComboBox.Text = "true"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(521, 268)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 16)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "Generate structures."
        '
        'genset_TextBox
        '
        Me.genset_TextBox.BackColor = System.Drawing.Color.White
        Me.genset_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.genset_TextBox.ForeColor = System.Drawing.Color.Black
        Me.genset_TextBox.Location = New System.Drawing.Point(189, 300)
        Me.genset_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.genset_TextBox.MaxLength = 100
        Me.genset_TextBox.Name = "genset_TextBox"
        Me.genset_TextBox.Size = New System.Drawing.Size(321, 26)
        Me.genset_TextBox.TabIndex = 74
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 305)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(130, 16)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "generator-settings="
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(521, 304)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 16)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Generator settings."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 341)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(165, 16)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "enable-command-block="
        '
        'encb_ComboBox
        '
        Me.encb_ComboBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.encb_ComboBox.FormattingEnabled = True
        Me.encb_ComboBox.Items.AddRange(New Object() {"true", "false"})
        Me.encb_ComboBox.Location = New System.Drawing.Point(189, 336)
        Me.encb_ComboBox.Name = "encb_ComboBox"
        Me.encb_ComboBox.Size = New System.Drawing.Size(321, 26)
        Me.encb_ComboBox.TabIndex = 76
        Me.encb_ComboBox.Text = "false"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(521, 340)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 16)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "Enable command block."
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 378)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 16)
        Me.Label17.TabIndex = 78
        Me.Label17.Text = "difficulty="
        '
        'dif_ComboBox
        '
        Me.dif_ComboBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dif_ComboBox.FormattingEnabled = True
        Me.dif_ComboBox.Items.AddRange(New Object() {"peaceful", "easy", "normal", "hard"})
        Me.dif_ComboBox.Location = New System.Drawing.Point(189, 372)
        Me.dif_ComboBox.Name = "dif_ComboBox"
        Me.dif_ComboBox.Size = New System.Drawing.Size(321, 26)
        Me.dif_ComboBox.TabIndex = 79
        Me.dif_ComboBox.Text = "normal"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(521, 376)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 16)
        Me.Label18.TabIndex = 80
        Me.Label18.Text = "Difficulty."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(118, 485)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(500, 16)
        Me.Label19.TabIndex = 81
        Me.Label19.Text = "These are the most basic settings, and also need to be set in the initial stage. " &
    ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label20.Location = New System.Drawing.Point(16, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(426, 19)
        Me.Label20.TabIndex = 82
        Me.Label20.Text = "All value in default. You can use these settings directly. "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.Location = New System.Drawing.Point(118, 508)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(413, 16)
        Me.Label21.TabIndex = 83
        Me.Label21.Text = "For other detail settings, please modify by yourself in the future."
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(84, 539)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(159, 36)
        Me.Button8.TabIndex = 84
        Me.Button8.Text = "OK && Save"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(296, 539)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(159, 36)
        Me.Button1.TabIndex = 85
        Me.Button1.Text = "Pass && Continue"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(504, 539)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(159, 36)
        Me.Button2.TabIndex = 86
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Maroon
        Me.Label22.Location = New System.Drawing.Point(521, 412)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(126, 16)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "Use while list or not."
        '
        'whil_ComboBox
        '
        Me.whil_ComboBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.whil_ComboBox.FormattingEnabled = True
        Me.whil_ComboBox.Items.AddRange(New Object() {"false", "true"})
        Me.whil_ComboBox.Location = New System.Drawing.Point(189, 408)
        Me.whil_ComboBox.Name = "whil_ComboBox"
        Me.whil_ComboBox.Size = New System.Drawing.Size(321, 26)
        Me.whil_ComboBox.TabIndex = 88
        Me.whil_ComboBox.Text = "false"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 414)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 16)
        Me.Label23.TabIndex = 87
        Me.Label23.Text = "white-list="
        '
        'serverip_TextBox
        '
        Me.serverip_TextBox.BackColor = System.Drawing.Color.White
        Me.serverip_TextBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serverip_TextBox.ForeColor = System.Drawing.Color.Black
        Me.serverip_TextBox.Location = New System.Drawing.Point(189, 120)
        Me.serverip_TextBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.serverip_TextBox.MaxLength = 100
        Me.serverip_TextBox.Name = "serverip_TextBox"
        Me.serverip_TextBox.Size = New System.Drawing.Size(321, 26)
        Me.serverip_TextBox.TabIndex = 92
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(12, 123)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 16)
        Me.Label24.TabIndex = 91
        Me.Label24.Text = "server-ip="
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Maroon
        Me.Label25.Location = New System.Drawing.Point(521, 124)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(223, 16)
        Me.Label25.TabIndex = 90
        Me.Label25.Text = "Minecraft server ip (Interface binding)."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Maroon
        Me.Label26.Location = New System.Drawing.Point(521, 448)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(83, 16)
        Me.Label26.TabIndex = 95
        Me.Label26.Text = "Game mode."
        '
        'gamem_ComboBox
        '
        Me.gamem_ComboBox.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gamem_ComboBox.FormattingEnabled = True
        Me.gamem_ComboBox.Items.AddRange(New Object() {"survival", "creative", "adventure", "spectator"})
        Me.gamem_ComboBox.Location = New System.Drawing.Point(189, 444)
        Me.gamem_ComboBox.Name = "gamem_ComboBox"
        Me.gamem_ComboBox.Size = New System.Drawing.Size(321, 26)
        Me.gamem_ComboBox.TabIndex = 94
        Me.gamem_ComboBox.Text = "survival"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 450)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 16)
        Me.Label27.TabIndex = 93
        Me.Label27.Text = "gamemode="
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(756, 584)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.gamem_ComboBox)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.serverip_TextBox)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.whil_ComboBox)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.dif_ComboBox)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.encb_ComboBox)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.genset_TextBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.genstr_ComboBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.levelt_ComboBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.levels_TextBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.leveln_TextBox)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.serverp_TextBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Motd_TextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form5"
        Me.Text = "The basic settings of server.properties."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Motd_TextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents serverp_TextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents leveln_TextBox As TextBox
    Friend WithEvents levels_TextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents levelt_ComboBox As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents genstr_ComboBox As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents genset_TextBox As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents encb_ComboBox As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents dif_ComboBox As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents whil_ComboBox As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents serverip_TextBox As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents gamem_ComboBox As ComboBox
    Friend WithEvents Label27 As Label
End Class
