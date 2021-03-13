Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Imports System.ComponentModel
'Imports System.Windows.Forms
Imports System.IO.Ports
Imports System.Runtime.InteropServices
Public Class Form1

    Structure ClientWorker
        Dim TheSocket As Sockets.TcpClient
        Dim IsUsing As Boolean
        Dim DeadTime As Long
    End Structure

    ' Why so many public declared here ??
    ' Because Multi-thread works. I don't want process what the sync/async/lock or something.
    ' Anyway it's work.

    Const CM_Type_W As String = "#"
    Const CM_Type_SAY As String = "$"

    Const CM_ServerState_Flag As String = "*"
    Const CM_ServerGetFlag As String = "+"

    Const WM_VSCROLL As Integer = 277
    Const SB_PAGEBOTTOM As Integer = 7

    Const TCP_timeout_s As Integer = 21
    Const Get_timeout_ds As Integer = 41

    Private cpuCounter As System.Diagnostics.PerformanceCounter

    Dim MC_Process As New System.Diagnostics.Process()
    Dim ZIP_Process As New System.Diagnostics.Process()
    Dim EXE_Process As New System.Diagnostics.Process()

    Public Shared Get_Process_Error_String As String
    Public Shared ErrorHappend As Boolean

    Const Saved_String_Max As Integer = 127
    Public Shared Saved_String_IDX As Integer = 0
    Public Shared Saved_String(Saved_String_Max) As String
    Public Shared Show_String As String
    Private Delegate Sub UpdateUICB(ByVal MyText As String, ByVal c As Control)
    Public myStreamWriter As StreamWriter

    Const EXE_Saved_String_Max As Integer = 127
    Public Shared EXE_Saved_String_IDX As Integer = 0
    Public Shared EXE_Saved_String(Saved_String_Max) As String
    Public Shared EXE_Show_String As String
    Private Delegate Sub EXE_UpdateUICB(ByVal MyText As String, ByVal c As Control)
    Public EXE_myStreamWriter As StreamWriter

    Public FthWallMC_Server As Integer = 0 '0 = Offline 1 = Trying 2= Online
    Public FthWallMC_Server_TcpListerner As Sockets.TcpListener


    Public Clients() As ClientWorker
    Public Clients_Now_Max As Integer = -1

    Public MC_Server_WorkState As Integer = 0 ' 0=off  1=BUSY  2=on

    Public Waiting_Input As Boolean
    Public Waiting_Input_count As Integer

    Dim MC_IS_LAUNCHED As Boolean
    Dim ZIP_IS_LAUNCHED As Boolean
    Dim EXE_IS_LAUNCHED As Boolean

    Dim Reciver_Data(0) As Byte
    Dim Reciver_str_Last As String
    Dim ReallyClose As Boolean
    Dim LoadFont As Font

    'Send to Console UP+DOWN key Get recent use
    Dim Send2Recent(9) As String
    Dim Send2Idx As Integer
    Dim Send2IdxLast As Integer


    'Get the time tick
    Dim I_Asking_Tick(1) As Boolean
    Dim Time_AskMap(1) As String
    Dim Time_TickReturn(1) As String

    'Get the locate
    Dim I_Asking_Locate(1) As Boolean
    Dim IAL_Argu_Pos(1) As String
    Dim IAL_Argu_Findwhat(1) As String
    Dim IAL_Return(1) As String

    'Get the locatebiome
    Dim I_Asking_LocateBiome(1) As Boolean
    Dim IALB_Argu_Pos(1) As String
    Dim IALB_Argu_Findwhat(1) As String
    Dim IALB_Return(1) As String

    'Data get block
    Dim I_Asking_Data_Block(1) As Boolean
    Dim IADB_Argu_Findwhat As String = "has the following block data:"
    Dim IADB_Return(1) As String

    'Data get entity
    Dim I_Asking_Data_Entity(1) As Boolean
    Dim IADE_Argu_Findwhat As String = "has the following entity data:"
    Dim IADE_Return(1) As String

    'Data get storage
    'Dim I_Asking_Data_Storage(1) As Boolean
    'Dim IADS_Argu_Pos(1) As String
    'Dim IADS_Argu_Findwhat(1) As String
    'Dim IADS_Return(1) As String

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As IntPtr, lParam As IntPtr) As Integer
    End Function


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Man_Who_LastSending = "CONSOLE"
        Form2.COMLineEnd.SelectedIndex = 0

        '=====Serial Port init
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Form2.ComPortList.Items.Add(sp)
        Next
        Form2.ComPortList.SelectedIndex = 0
        Man_COM_Port = "off"
        '======================

        Origial_Path = Directory.GetCurrentDirectory

        If My.Computer.FileSystem.FileExists(Origial_Path + "\Setting.xml") Then
            LoadXML()
        End If

        'Fix wired bug
        TabControl1.SelectedIndex = 1
        My.Application.DoEvents()
        TabControl1.SelectedIndex = 0
        My.Application.DoEvents()

        '??? What this for
        CheckForIllegalCrossThreadCalls = False

        If My.Computer.FileSystem.FileExists(Origial_Path + "\FontToLoad.otf") Then
            LoadFont = New Font(LoadFontFile(Origial_Path + "\FontToLoad.otf"), 9, FontStyle.Regular)
            MCS_Richtexbox.Font = LoadFont
            EXE_Texbox.Font = LoadFont
            Form3.Help_RichTextBox.Font = LoadFont
        End If

        MCS_Richtexbox.LanguageOption = RichTextBoxLanguageOptions.UIFonts

        'The .net component is shitty
        Form3.Help_RichTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        Form3.Visible = True
        Form3.Visible = False
        Form3.Help_RichTextBox.Text = My.Resources.HelpResource

        My.Application.DoEvents()

        If My.Application.CommandLineArgs().Count > 0 Then
            If My.Application.CommandLineArgs(0).ToLower = "now" Then
                Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter)
            End If
        End If

        RCState_Label.ForeColor = Color.FromArgb(255, 128, 128, 255)
        ModeRC_Button.Text = "RemoteCon" + vbNewLine + "Normal (0)"
        ModeExeFW_Button.Text = "EXE Flood way" + vbNewLine + "MC←EXE"
        ModeExeBM_Button.Text = "EXE Back mode" + vbNewLine + """Whisper"""

    End Sub

    Public Function Start_Management_Server() As Boolean

        If Man_Port_Number = 0 Then
            Start_Management_Server = True
            Exit Function
        End If

        If FthWallMC_Server > 0 Then
            Start_Management_Server = True
            Exit Function
        End If

        ManServerRefreshTimer.Enabled = False

        If FthWallMC_Server <> 2 Then

            FthWallMC_Server = 1
            Try
                FthWallMC_Server_TcpListerner = New Sockets.TcpListener(IPAddress.Any, Man_Port_Number)
                FthWallMC_Server_TcpListerner.Start()
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                FthWallMC_Server = 2
            Catch ex As Exception
                FthWallMC_Server = 1
            End Try

        End If

        ManServerRefreshTimer.Enabled = True

        Return True

    End Function

    Public Function Stop_Management_Server() As Boolean

        Dim TmpState As Integer = FthWallMC_Server

        ManServerRefreshTimer.Enabled = False
        Waiting_Input = False

        If FthWallMC_Server = 0 Then
            Stop_Management_Server = True
            Exit Function
        End If

        If FthWallMC_Server >= 1 Then
            FthWallMC_Server = 1
            Try

                For Each TmpClient As ClientWorker In Clients
                    TmpClient.TheSocket.Close()
                    TmpClient.IsUsing = False
                    TmpClient.DeadTime = 0
                    TmpClient.TheSocket.Dispose()
                Next

                FthWallMC_Server_TcpListerner.Stop()
                FthWallMC_Server = 0

            Catch ex As Exception

                FthWallMC_Server = TmpState
                RCState_Label.Text = "ERROR"
                Return False

            End Try

        End If

        RCState_Label.Text = "OFF"
        ManServerRefreshTimer.Enabled = True

        Return True


    End Function
    Sub Handler_Client(ByVal state As Object)

        Dim Tmp_Idx1 As Integer
        Dim Found_Client_Space As Boolean = False

        Try
            For Tmp_Idx1 = 0 To Clients_Now_Max
                If Clients(Tmp_Idx1).IsUsing = False Then
                    Found_Client_Space = True
                    Exit For
                End If
            Next

            If Not Found_Client_Space Then
                Clients_Now_Max += 1
                ReDim Preserve Clients(Clients_Now_Max)
                Tmp_Idx1 = Clients_Now_Max
            End If

            Clients(Tmp_Idx1).DeadTime = 1
            Clients(Tmp_Idx1).IsUsing = True
            Clients(Tmp_Idx1).TheSocket = FthWallMC_Server_TcpListerner.AcceptTcpClient

        Catch ex As Exception

            If Man_TCP_ErrorTimes <= 10 Then
                Man_TCP_ErrorTimes += 1
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            Else
                MsgBox("Uncoveable error happend too many times when start Management Server. Abort.", 0, "Error")
                FthWallMC_Server = 0
            End If

            Exit Sub

        End Try

        Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)

        Try

            Dim SocketNetworkStream As Sockets.NetworkStream = Clients(Tmp_Idx1).TheSocket.GetStream
            Dim ErrorType As Integer = 0
            Dim Man_Pwd_Length As Integer = Man_Password.Length

            Waiting_Input_count = 0

            Dim Rcv_Bytes(Clients(Tmp_Idx1).TheSocket.ReceiveBufferSize) As Byte
            Dim Rcv_Str As String = ""
            Dim Compare_Pwd, Command_Mode, Command_Str As String

            Compare_Pwd = ""
            Command_Mode = ""
            Command_Str = ""

            If SocketNetworkStream.CanRead Then

                Waiting_Input = True

                SocketNetworkStream.Read(Rcv_Bytes, 0, Clients(Tmp_Idx1).TheSocket.ReceiveBufferSize)

                Rcv_Str = Replace(Encoding.UTF8.GetString(Rcv_Bytes), vbNullChar, "")
                Rcv_Str = Replace(Rcv_Str, vbCr, "")
                Rcv_Str = Replace(Rcv_Str, vbLf, "")


                If Rcv_Str Is Nothing Then
                    Rcv_Str = ""
                    ErrorType = 1
                ElseIf Rcv_Str.Length < Man_Pwd_Length + 5 Then
                    ErrorType = 1
                ElseIf Rcv_Str.Substring(0, Man_Pwd_Length) <> Man_Password Then
                    ErrorType = 1
                Else

                    Command_Mode = Rcv_Str.Substring(Man_Pwd_Length + 1, 2).ToLower

                    Select Case Command_Mode
                        Case "cm"
                        Case "bk"
                        Case "in"
                        Case "sy"
                        Case "gt"
                        Case "gl"
                        Case "gb"
                        Case "gd"
                        Case "ss"
                        Case "db"
                        Case "de"
                            'Case "ds"
                        Case Else
                            ErrorType = 1
                    End Select

                End If

                If ErrorType = 0 Then

                    If MC_Server_WorkState = 1 Then

                        ErrorType = 5

                    Else

                        Command_Str = Rcv_Str.Substring(Man_Pwd_Length + 4)

                        If Command_Str = "" Then
                            ErrorType = 1
                        Else

                            Select Case FthWallMC_Server_Bypass

                                Case 0

                                    ErrorType = Process_RC_Request(Command_Mode, Command_Str, Tmp_Idx1)

                                Case 1
                                    ErrorType = 4

                                Case 2
                                    ErrorType = 5

                            End Select

                        End If

                    End If

                End If

                Select Case ErrorType
                    Case 0
                        SendToClients("OK", Clients(Tmp_Idx1).TheSocket) 'Bad password or command format.
                    Case 1
                        SendToClients("BAD", Clients(Tmp_Idx1).TheSocket) 'Bad password or command format.
                    Case 2
                        SendToClients("NOT-ON", Clients(Tmp_Idx1).TheSocket)'Minecraft server is offline.
                    Case 3
                        SendToClients("NOT-OFF", Clients(Tmp_Idx1).TheSocket) 'Need Minecraft server be offline.
                    Case 4

                        If Command_Mode = "sy" Then Write_To_Console("say " + Command_Str)
                        SendToClients("PASS", Clients(Tmp_Idx1).TheSocket) 'Server want pass this task.

                    Case 5
                        SendToClients("BUSY", Clients(Tmp_Idx1).TheSocket) 'Server is busy. please wait.

                    Case 99
                        'Displayed by above code

                End Select

            End If

            SocketNetworkStream.Close()
            CloseASocket(Clients(Tmp_Idx1))
            Waiting_Input = False

        Catch ex As Exception

            Try
                CloseASocket(Clients(Tmp_Idx1))
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                Waiting_Input = False
            Finally
            End Try

        End Try

    End Sub

    Private Function Process_RC_Request(Command_Mode As String, Command_Str As String, ClientIdx As Integer) As Integer

        Process_RC_Request = 0

        If Command_Mode = "cm" Then

            Select Case Command_Str.ToLower

                Case "start"
                    If MC_Server_WorkState <> 0 Then
                        Return 3
                    Else
                        SendToClients(Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter), Clients(ClientIdx).TheSocket)
                        Return 99
                    End If

                Case "backup"

                    If MC_Server_WorkState <> 0 Then
                        Return 3
                    Else
                        SendToClients(Start_Server_Backup_Process(ZIP_Launch_Parameter, ZIP_EXE_Location, ZIP_TIME_Format), Clients(ClientIdx).TheSocket)
                        Return 99
                    End If

                Case "info1"

                    If MC_Server_WorkState = 0 Then
                        SendToClients("OFF", Clients(ClientIdx).TheSocket)
                    ElseIf MC_Server_WorkState = 1 Then
                        SendToClients("BUSY", Clients(ClientIdx).TheSocket)
                    Else
                        SendToClients("ON", Clients(ClientIdx).TheSocket)
                    End If

                    Return 99

                Case "kill"
                    kill_task()
                    Return 0

                Case Else
                    Return 1

            End Select


        ElseIf Command_Mode = "bk" Then

            If MC_Server_WorkState <> 0 Then
                Return 3
            Else
                SendToClients(Start_Server_Backup_Process(Command_Str, ZIP_EXE_Location, ZIP_TIME_Format), Clients(ClientIdx).TheSocket)
                Return 99
            End If

        ElseIf Command_Mode = "ss" Then

            Process_RC_Request = Get_Full_MCServer_Control(Command_Str)
            Exit Function

        ElseIf Command_Mode = "in" Then

            If MC_Server_WorkState = 0 Then
                Return 2
            Else
                Write_To_Console(Command_Str)
                Return 0
            End If

        ElseIf Command_Mode = "sy" Then

            If MC_Server_WorkState = 0 Then
                Return 2
            Else
                Write_To_Console("say " + Command_Str)
                Return 0
            End If

        Else

            Process_RC_Request = 1

            If (MC_Server_WorkState = 2) AndAlso (FthWallMC_Server_Bypass = 0) Then

                Process_RC_Request = Process_Get_Command(Command_Mode, Command_Str, 0, Clients(ClientIdx))
                Process_RC_Request = 99

            ElseIf (MC_Server_WorkState = 1) OrElse (FthWallMC_Server_Bypass = 2) Then

                SendToClients("-2", Clients(ClientIdx).TheSocket) 'Busy
                Process_RC_Request = 99

            Else

                SendToClients("-3", Clients(ClientIdx).TheSocket) 'Pass or error
                Process_RC_Request = 99

            End If

        End If

    End Function

    Function Process_Get_Command(Command_Mode As String, Command_str As String, RCorEXE_Mode As Integer, Optional ByRef TmpClientWork As ClientWorker = Nothing) As String

        Process_Get_Command = 1

        If Command_Mode = "gt" Then

            Process_Get_Command = 0

            I_Asking_Tick(RCorEXE_Mode) = True
            Time_TickReturn(RCorEXE_Mode) = "-1"
            Time_AskMap(RCorEXE_Mode) = Command_str

            Write_To_Console("execute in " + Time_AskMap(RCorEXE_Mode) + " run time query daytime")
            What_RU_Waiting(Time_TickReturn(RCorEXE_Mode), Get_timeout_ds)

            If RCorEXE_Mode = 0 Then SendToClients(Time_TickReturn(0), TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console(Time_TickReturn(1))

            Time_TickReturn(RCorEXE_Mode) = ""
            Time_AskMap(RCorEXE_Mode) = ""
            I_Asking_Tick(RCorEXE_Mode) = False

        ElseIf Command_Mode = "gl" Then

            Process_Get_Command = 0

            I_Asking_Locate(RCorEXE_Mode) = True
            IAL_Return(RCorEXE_Mode) = "-1"

            Dim Argus() As String = Command_str.Split(",")
            If UBound(Argus) < 2 Then Return 1

            IAL_Argu_Pos(RCorEXE_Mode) = Argus(0) '/positioned 500 100 500 /as Overdoingism
            If Argus(1) <> "" Then Argus(1) = " in " + Argus(1) '/in the_nether
            IAL_Argu_Findwhat(RCorEXE_Mode) = Argus(2) '/ocean
            Write_To_Console("execute " + IAL_Argu_Pos(RCorEXE_Mode) + Argus(1) + " run locate " + Argus(2))
            What_RU_Waiting(IAL_Return(RCorEXE_Mode), Get_timeout_ds)

            If RCorEXE_Mode = 0 Then SendToClients(IAL_Return(0), TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IAL_Return(1))

            IAL_Return(RCorEXE_Mode) = "" : IAL_Argu_Pos(RCorEXE_Mode) = "" : IAL_Argu_Findwhat(RCorEXE_Mode) = "" : I_Asking_Locate(RCorEXE_Mode) = False

        ElseIf Command_Mode = "gb" Then

            Process_Get_Command = 0

            I_Asking_LocateBiome(RCorEXE_Mode) = True
            IALB_Return(RCorEXE_Mode) = "-1"

            Dim Argus() As String = Command_str.Split(",")
            If UBound(Argus) < 2 Then Return 1

            IALB_Argu_Pos(RCorEXE_Mode) = Argus(0) '/positioned 500 100 500 /as Overdoingism

            If Argus(1) <> "" Then Argus(1) = " in " + Argus(1) '/in the_nether

            IALB_Argu_Findwhat(RCorEXE_Mode) = Argus(2) '/ocean

            Write_To_Console("execute " + IALB_Argu_Pos(RCorEXE_Mode) + Argus(1) + " run locatebiome " + Argus(2))
            What_RU_Waiting(IALB_Return(RCorEXE_Mode), Get_timeout_ds)

            If RCorEXE_Mode = 0 Then SendToClients(IALB_Return(0), TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IALB_Return(1))

            IALB_Return(RCorEXE_Mode) = "" : IALB_Argu_Pos(RCorEXE_Mode) = "" : IALB_Argu_Findwhat(RCorEXE_Mode) = "" : I_Asking_LocateBiome(RCorEXE_Mode) = False


        ElseIf Command_Mode = "db" Then

            Process_Get_Command = 0

            I_Asking_Data_Block(RCorEXE_Mode) = True
            IADB_Return(RCorEXE_Mode) = "-1"

            Write_To_Console(Command_str)
            What_RU_Waiting(IADB_Return(RCorEXE_Mode), Get_timeout_ds)

            If RCorEXE_Mode = 0 Then SendToClients(IADB_Return(0), TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IADB_Return(1))

            IADB_Return(RCorEXE_Mode) = "" : I_Asking_Data_Block(RCorEXE_Mode) = False

        ElseIf Command_Mode = "de" Then

            Process_Get_Command = 0

            I_Asking_Data_Entity(RCorEXE_Mode) = True
            IADE_Return(RCorEXE_Mode) = "-1"

            Write_To_Console(Command_str)
            What_RU_Waiting(IADE_Return(RCorEXE_Mode), Get_timeout_ds)

            If RCorEXE_Mode = 0 Then SendToClients(IADE_Return(0), TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IADE_Return(1))

            'ElseIf Command_Mode = "ds" Then


        End If
    End Function

    Sub CloseASocket(ByRef NowWorker As ClientWorker)

        NowWorker.TheSocket.Close()
        NowWorker.TheSocket.Dispose()
        NowWorker.IsUsing = False
        NowWorker.DeadTime = 0

    End Sub

    Sub SendToClients(ByVal Data As String, ByRef NowClient As Sockets.TcpClient)

        If FthWallMC_Server = 2 Then

            Try
                'Dim TX1 As New StreamWriter(NowClient.GetStream) 'UTF8
                Dim TX2 As New BinaryWriter(NowClient.GetStream)
                Dim Bytes() As Byte = Encoding.UTF8.GetBytes(Data)

                TX2.Write(Bytes, 0, Bytes.Length)
                TX2.Flush()
                TX2.Dispose()

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Function Start_MC_Server_Process(The_JAVA_Arguments As String, The_FileName As String, The_JAR_BAT_File As String, The_MC_Arguments As String) As String

        Dim Launch_File As String = ""
        Dim The_Arguments As String = ""
        MCS_Richtexbox.Text = "Starting Minecraft Server..."
        Start_MC_Server_Process = ""

        Try

            If Not My.Computer.FileSystem.FileExists(The_JAR_BAT_File) Then
                MCS_Richtexbox.Text += vbNewLine + "Server JAR file / Batch file not present. Please setup first."
                Start_MC_Server_Process = "NEED-SETUP"
                Exit Function
            End If

            If The_JAR_BAT_File.Length > 5 Then
                If The_JAR_BAT_File.Substring(The_JAR_BAT_File.Length - 4, 4).ToLower = ".bat" Then
                    Launch_File = The_JAR_BAT_File
                    The_Arguments = The_MC_Arguments
                    MCServer_BAT_Mode = True
                Else

                    If The_FileName.Length >= 4 Then
                        If The_FileName.Substring(The_FileName.Length - 4).ToUpper <> ".EXE" Then The_FileName = The_FileName + ".exe"
                    End If

                    If Not My.Computer.FileSystem.FileExists(The_FileName) Then

                        Dim pathStr() As String = Environment.GetEnvironmentVariable("path").Split(";")
                        Dim pathTry As String
                        Dim pathTryGet As Boolean = False

                        For Each pathTry In pathStr
                            If My.Computer.FileSystem.FileExists(pathTry + "\" + The_FileName) Then
                                The_FileName = pathTry + "\" + The_FileName
                                pathTryGet = True
                                Exit For
                            End If
                        Next

                        If pathTryGet = False Then
                            MCS_Richtexbox.Text += vbNewLine + "JVM java.exe not present. Please setup first."
                            Start_MC_Server_Process = "NEED-SETUP"
                            Exit Function
                        End If

                    End If
                    Launch_File = The_FileName
                    The_Arguments = The_JAVA_Arguments + " -jar " + """" + The_JAR_BAT_File + """ " + The_MC_Arguments
                    MCServer_BAT_Mode = False
                End If
            End If

            Directory.SetCurrentDirectory(My.Computer.FileSystem.GetFileInfo(MCServer_JAR_BAT_Location).DirectoryName)
            MC_Server_WorkState = 1

            If My.Computer.FileSystem.DirectoryExists(".\plugins") Then
                Dim FindEssPlugIn() As String = Directory.GetFiles(".\plugins\", "Essentials*.jar")
                If FindEssPlugIn IsNot Nothing AndAlso FindEssPlugIn.Length > 0 Then
                    IsEssentialsX_Installed = 2
                Else
                    IsEssentialsX_Installed = 1
                End If
            Else
                IsEssentialsX_Installed = 1
            End If


            StartButton.Enabled = False
            BackupButton.Enabled = False
            My.Application.DoEvents()

            ReDim Saved_String(Saved_String_Max)
            Saved_String(0) = "Starting Minecraft Server..." + vbNewLine
            Saved_String_IDX = 1

            MC_Process = New System.Diagnostics.Process()

            ErrorHappend = False

            With MC_Process.StartInfo
                .WorkingDirectory = ""
                .FileName = Launch_File
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                '.StandardOutputEncoding = Encoding.UTF8
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .Arguments = The_Arguments
            End With

            MC_Process.EnableRaisingEvents = True
            MC_Process.SynchronizingObject = Me

            ' Set our event handler to asynchronously read the sort output.
            AddHandler MC_Process.OutputDataReceived, AddressOf OutputHandler
            AddHandler MC_Process.ErrorDataReceived, AddressOf ErrOutputHandler
            AddHandler MC_Process.Exited, AddressOf ExitHandler

            My.Application.DoEvents()

            MC_Process.Start()
            MC_Process.BeginOutputReadLine()
            MC_Process.BeginErrorReadLine()

            MC_IS_LAUNCHED = True
            KillTaskButton.Enabled = True

            The_ProcessInstanceName = GetProcessInstanceName(MC_Process.Id)

            Do
                cpuCounter = New System.Diagnostics.PerformanceCounter("Process", "% Processor Time", The_ProcessInstanceName)
                My.Application.DoEvents()
                If cpuCounter IsNot Nothing Then Exit Do
            Loop

            MCServer_CPU_Peak = 0
            MCServer_RAM_Peak = 0
            MCServer_CPU_Wait = 0
            Start_MC_Server_Process = "OK"

        Catch ex As Exception

            MC_Server_WorkState = 0
            MCS_Richtexbox.Text += vbNewLine + ex.Message + vbNewLine
            Start_MC_Server_Process = "ERROR"

        End Try


        'Start EXE here
        Start_EXE_Process(Man_EXE_FirstExec)

    End Function

    Private Sub UpdateUI(ByVal MyText As String, ByVal c As Control)

        If InvokeRequired() Then

            Dim cb As New UpdateUICB(AddressOf UpdateUI)
            Me.Invoke(cb, MyText, c)

        Else
            c.Text = MyText
        End If
    End Sub

    Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)

        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then

            Dim Tmp_String_Org As String = outLine.Data
            Dim Tmp_String As String = Tmp_String_Org.ToUpper
            Dim Tmp_String2 As String = ""

            Dim IDX_TMP_01 As Integer


            For IDX_TMP_01 = 0 To 1

                '============= Get tick command =========
                If Check_If_Misjudge(Tmp_String, I_Asking_Tick(IDX_TMP_01)) Then
                    Dim TMP_TICK1_IDX As Integer
                    TMP_TICK1_IDX = InStr(Tmp_String, " THE TIME IS ")
                    If TMP_TICK1_IDX > 0 Then
                        Time_TickReturn(IDX_TMP_01) = Tmp_String_Org.Substring(TMP_TICK1_IDX + 12)
                    End If
                End If


                '============= Get Locate =========
                If Check_If_Misjudge(Tmp_String, I_Asking_Locate(IDX_TMP_01)) Then
                    IAL_Return(IDX_TMP_01) = Locate_Return(Tmp_String_Org, IAL_Argu_Findwhat(IDX_TMP_01))
                End If

                '============= Get LocateBiome =========
                If Check_If_Misjudge(Tmp_String, I_Asking_LocateBiome(IDX_TMP_01)) Then
                    IALB_Return(IDX_TMP_01) = Locate_Return(Tmp_String_Org, IALB_Argu_Findwhat(IDX_TMP_01))
                End If

                '============= Data Get Block =========
                If Check_If_Misjudge(Tmp_String, I_Asking_Data_Block(IDX_TMP_01)) Then
                    IADB_Return(IDX_TMP_01) = Data_Return(Tmp_String_Org, IADB_Argu_Findwhat)
                End If

                '============= Data Get Entity =========
                If Check_If_Misjudge(Tmp_String, I_Asking_Data_Entity(IDX_TMP_01)) Then
                    IADE_Return(IDX_TMP_01) = Data_Return(Tmp_String_Org, IADE_Argu_Findwhat)
                End If

            Next


            '=============Serial Port Out==========
            If SP1.IsOpen Then
                If Man_COM_TxFilterList IsNot Nothing Then
                    For Each Tmp_String2 In Man_COM_TxFilterList
                        If InStr(Tmp_String_Org, Tmp_String2) > 0 Then
                            SP1.Write(Tmp_String_Org + Man_COM_LEArry(Man_COM_LineEnd))
                            Exit For
                        End If
                    Next
                Else
                    SP1.Write(Tmp_String_Org + Man_COM_LEArry(Man_COM_LineEnd))
                End If
            End If
            '======================================

            '================Flood To EXE=============MC→EXE
            If Man_Flood_ToEXE = 2 Then
                If Man_EXE_FDFilterList IsNot Nothing Then
                    For Each Tmp_String2 In Man_EXE_FDFilterList
                        If InStr(Tmp_String_Org, Tmp_String2) > 0 Then
                            EXE_Write_To_Console(Tmp_String_Org)
                            Exit For
                        End If
                    Next
                Else
                    EXE_Write_To_Console(Tmp_String_Org)
                End If
            End If
            '======================================

            Dim Tmp_Index1, Tmp_Index2, Tmp_Index3 As Integer

            '===================================== Console Text Buffer

            Saved_String(Saved_String_IDX) = Tmp_String_Org + vbNewLine

            If Saved_String_IDX >= Saved_String_Max Then
                Saved_String_IDX = 0
            Else
                Saved_String_IDX += 1
            End If

            '============================================ Console Text Buffer Show up

            If BurstMode = 0 Then

                Show_String = ""

                For Tmp_Index1 = Saved_String_IDX To Saved_String_Max
                    Show_String += Saved_String(Tmp_Index1)
                Next

                For Tmp_Index1 = 0 To Saved_String_IDX - 1
                    Show_String += Saved_String(Tmp_Index1)
                Next

                BoxRefreshTimer.Enabled = False
                UpdateUI(Show_String, MCS_Richtexbox)
                BoxRefreshTimer.Enabled = True

            End If
            '=============================================

            Do 'ALL In Game Command Parsing In this Fake DO-LOOP

                '================================================ Server state Detect
                If MC_Server_WorkState < 2 Then 'Start detect
                    Tmp_Index2 = InStr(Replace(Tmp_String, "SERVER THREAD/", ""), "INFO]: DONE")
                    If (Tmp_Index2 > 0) AndAlso (Tmp_Index2 < 16) Then
                        MC_Server_WorkState = 2
                        Exit Do
                    End If
                ElseIf MC_Server_WorkState = 2 Then 'Stop detect 
                    Tmp_Index2 = InStr(Replace(Tmp_String, "SERVER THREAD/", ""), "INFO]: STOPPING THE SERVER")
                    If (Tmp_Index2 > 0) AndAlso (Tmp_Index2 < 16) Then
                        MC_Server_WorkState = 1
                        Exit Do
                    End If
                End If
                '====================================================================

                If MC_Server_WorkState = 2 Then

                    If SP1.IsOpen Then
                        Try
                            SP1.Write(Tmp_String + Man_COM_LEArry(Man_COM_LineEnd))
                        Catch ex As Exception
                        End Try
                    End If

                    '================================================ GeekCommand Detect

                    Dim Get_AfterW As String
                    Dim Get_SenderID As String
                    Dim Get_SendToID As String
                    Dim Get_AfterID As String
                    Dim Get_TypeCommand As String
                    Dim Get_Message As String

                    Tmp_Index2 = InStr(Tmp_String, " INFO]:") + 8 'L=7
                    Tmp_Index3 = InStr(Tmp_String, " ISSUED SERVER COMMAND: /W ") 'L=27

                    If ((Tmp_Index3 > Tmp_Index2) AndAlso (Tmp_String.Length > Tmp_Index3 + 27 + 6)) Then

                        'Get SenderID
                        Get_SenderID = Tmp_String_Org.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)

                        'Get AfterW
                        Get_AfterW = Tmp_String_Org.Substring(Tmp_Index3 + 26)

                        'Get SendToID
                        Tmp_Index1 = InStr(Get_AfterW, " ")
                        Get_SendToID = Get_AfterW.Substring(0, Tmp_Index1).Trim

                        'Check Man Right
                        If Not The_Man_has_right(Get_SenderID, Get_SendToID) Then Exit Do

                        Get_AfterID = Get_AfterW.Substring(Tmp_Index1)
                        If Get_AfterID.Length <= 1 Then Exit Do
                        Get_TypeCommand = Get_AfterID.Substring(0, 1)
                        Get_Message = Get_AfterID.Substring(1)

                        Select Case Get_TypeCommand

                            Case CM_Type_W 'Output to EXE, EXE w back

                                If Not EXE_IS_LAUNCHED Then
                                    Start_EXE_Process(Man_EXE_FirstExec)
                                End If

                                Man_ThisTime_W2Say = False
                                EXE_Write_To_Console(Get_Message)

                            Case CM_Type_SAY 'Output to EXE, EXE say back

                                If Not EXE_IS_LAUNCHED Then
                                    Start_EXE_Process(Man_EXE_FirstExec)
                                End If

                                Man_ThisTime_W2Say = True
                                EXE_Write_To_Console(Get_Message)

                            Case CM_ServerState_Flag

                                Get_Full_MCServer_Control(Get_Message)

                            Case Else

                                Exit Do

                        End Select

                    Else

                        Exit Do

                    End If

                End If

                '================================================ GeekCommand Detect

                Exit Do
            Loop

        End If

    End Sub

    Sub ErrOutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        ' Collect the sort command output.

        If Not String.IsNullOrEmpty(outLine.Data) Then

            Dim Tmp_Index1 As Integer
            ' Add the text to the collected output.

            Saved_String(Saved_String_IDX) = outLine.Data + vbNewLine
            If Saved_String_IDX >= Saved_String_Max Then
                Saved_String_IDX = 0
            Else
                Saved_String_IDX += 1
            End If

            Show_String = ""
            For Tmp_Index1 = Saved_String_IDX To Saved_String_Max
                Show_String += Saved_String(Tmp_Index1)
            Next

            For Tmp_Index1 = 0 To Saved_String_IDX - 1
                Show_String += Saved_String(Tmp_Index1)
            Next

            ErrorHappend = True
        End If

        UpdateUI(Show_String, MCS_Richtexbox)
        BoxRefreshTimer.Enabled = True

    End Sub

    Public Sub Write_To_Console(Write_Str_Data As String)

        If MC_Server_WorkState <> 2 Then Exit Sub

        myStreamWriter = MC_Process.StandardInput
        myStreamWriter.WriteLine(Write_Str_Data)

    End Sub

    Private Sub ExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        MC_Server_WorkState = 0
        MCS_Richtexbox.Text += "Minecraft Server Is Stopped." + vbCrLf

    End Sub

    Private Function Start_Server_Backup_Process(The_Arguments As String, The_FileName As String, TimeFormatReplace As String) As String

        MCS_Richtexbox.Text = "Starting Minecraft Server Backup..."
        Start_Server_Backup_Process = ""

        Try

            If Not My.Computer.FileSystem.FileExists(ZIP_EXE_Location) Then
                MCS_Richtexbox.Text += vbNewLine + "Backup / Compressor progarm Not present. Please setup first."
                Start_Server_Backup_Process = "NEED-SETUP"
                Exit Function
            End If

            MC_Server_WorkState = 1
            Directory.SetCurrentDirectory(My.Computer.FileSystem.GetFileInfo(The_FileName).DirectoryName)

            StartButton.Enabled = False
            BackupButton.Enabled = False
            My.Application.DoEvents()

            ReDim Saved_String(Saved_String_Max)
            Saved_String(0) = "Starting Minecraft Server Backup..." + vbNewLine
            Saved_String_IDX = 1

            ZIP_Process = New System.Diagnostics.Process()

            ErrorHappend = False

            With ZIP_Process.StartInfo
                .WorkingDirectory = ""
                .FileName = The_FileName
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .Arguments = Replace(The_Arguments, "$TIME$", Now.ToString(TimeFormatReplace))
            End With

            ZIP_Process.EnableRaisingEvents = True
            ZIP_Process.SynchronizingObject = Me

            ' Set our event handler to asynchronously read the sort output.
            AddHandler ZIP_Process.OutputDataReceived, AddressOf OutputHandler
            AddHandler ZIP_Process.ErrorDataReceived, AddressOf ErrOutputHandler
            AddHandler ZIP_Process.Exited, AddressOf ZipExitHandler

            My.Application.DoEvents()

            ZIP_Process.Start()
            ZIP_Process.BeginOutputReadLine()
            ZIP_Process.BeginErrorReadLine()

            ZIP_IS_LAUNCHED = True
            KillTaskButton.Enabled = True

            Start_Server_Backup_Process = "OK"

        Catch ex As Exception

            MC_Server_WorkState = 0
            MCS_Richtexbox.Text += vbNewLine + ex.Message + vbNewLine
            Start_Server_Backup_Process = "Error"

        End Try


    End Function
    Private Sub ZipExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        MC_Server_WorkState = 0
        MCS_Richtexbox.Text += "Backup process End." + vbCrLf

    End Sub

    Private Function Start_EXE_Process(FirstExec As String) As String

        Start_EXE_Process = ""

        Try

            EXE_Process = New System.Diagnostics.Process()

            ErrorHappend = False

            If FirstExec IsNot Nothing Then
                If FirstExec <> "" Then
                    FirstExec = "-NoExit -Command " + FirstExec
                End If
            End If

            With EXE_Process.StartInfo
                .WorkingDirectory = ""
                .FileName = "powershell.exe"
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .Arguments = FirstExec
            End With

            EXE_Process.EnableRaisingEvents = True
            EXE_Process.SynchronizingObject = Me

            AddHandler EXE_Process.OutputDataReceived, AddressOf EXE_OutputHandler
            AddHandler EXE_Process.ErrorDataReceived, AddressOf EXE_OutputHandler
            AddHandler EXE_Process.Exited, AddressOf EXE_ExitHandler

            My.Application.DoEvents()

            EXE_Process.Start()
            EXE_Process.BeginOutputReadLine()
            EXE_Process.BeginErrorReadLine()

            EXE_IS_LAUNCHED = True
            Send2EXE_Button.Enabled = True
            Send2Exe_TextBox.Enabled = True
            Start_EXE_Process = "OK"

        Catch ex As Exception

            EXE_Texbox.Text += vbNewLine + ex.Message + vbNewLine
            Start_EXE_Process = "Error"

        End Try

    End Function

    Private Sub EXE_UpdateUI(ByVal MyText As String, ByVal c As Control)

        If InvokeRequired() Then

            Dim cb As New EXE_UpdateUICB(AddressOf EXE_UpdateUI)
            Me.Invoke(cb, MyText, c)

        Else
            c.Text = MyText
        End If

    End Sub

    Sub EXE_OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)

        If Not String.IsNullOrEmpty(outLine.Data) Then

            Dim Tmp_String_Org As String = outLine.Data
            Dim Tmp_Index1 As Integer

            '===================================== EXE Console Text Buffer

            EXE_Saved_String(EXE_Saved_String_IDX) = Tmp_String_Org + vbNewLine

            If EXE_Saved_String_IDX >= EXE_Saved_String_Max Then
                EXE_Saved_String_IDX = 0
            Else
                EXE_Saved_String_IDX += 1
            End If

            '===================================== EXE Console Text Buffer show up

            If BurstMode = 0 Then

                EXE_Show_String = ""

                For Tmp_Index1 = Saved_String_IDX To EXE_Saved_String_Max
                    EXE_Show_String += EXE_Saved_String(Tmp_Index1)
                Next

                For Tmp_Index1 = 0 To EXE_Saved_String_IDX - 1
                    EXE_Show_String += EXE_Saved_String(Tmp_Index1)
                Next

                EXE_BoxRefreshTimer.Enabled = False
                EXE_UpdateUI(EXE_Show_String, EXE_Texbox)
                EXE_BoxRefreshTimer.Enabled = True

            End If

            '====================================

            If MC_Server_WorkState = 2 Then

                '====================EXE foold to MC + injection
                If Man_Use_InJ AndAlso Tmp_String_Org.Substring(0, 1) = "~" Then

                    Dim ResultCode As Integer = 1

                    If Tmp_String_Org.Length > 5 Then

                        'ServerState Control
                        If Tmp_String_Org.Substring(1, 1) = CM_ServerState_Flag Then
                            ResultCode = Get_Full_MCServer_Control(Tmp_String_Org.Substring(2))
                        End If

                        'Get xxx Command
                        If Tmp_String_Org.ToUpper.Substring(1, 1) = CM_ServerGetFlag Then
                            Dim Command_Mode As String = Tmp_String_Org.ToLower.Substring(2, 2)
                            Dim Command_Str As String = Tmp_String_Org.Substring(5)
                            ResultCode = Process_Get_Command(Command_Mode, Command_Str, 1)
                        End If


                    End If

                    If ResultCode = 1 Then Write_To_Console(Tmp_String_Org.Substring(1))

                Else

                    If Man_Flood_ToEXE = 1 Then 'MC←EXE

                        If Man_ThisTime_W2Say Then
                            Write_To_Console("say " + Tmp_String_Org)
                        Else
                            Write_To_Console("w " + Man_Who_LastSending + " " + Tmp_String_Org)
                        End If

                    End If

                End If
                '==============================================

            End If

        End If

    End Sub

    Public Sub EXE_Write_To_Console(Write_Str_Data As String)

        If Not EXE_IS_LAUNCHED Then Exit Sub

        EXE_myStreamWriter = EXE_Process.StandardInput
        EXE_myStreamWriter.WriteLine(Write_Str_Data)

    End Sub

    Private Sub EXE_ExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        EXE_IS_LAUNCHED = False
        Send2EXE_Button.Enabled = False
        Send2Exe_TextBox.Enabled = False

    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        If Form3.Iagree_CheckBox.Checked = False Then
            MsgBox("Need the agree to use. Please click 'Help & About'.", 0, "Confirm")
            Exit Sub
        End If

        Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter)

    End Sub

    Private Sub Send2MCSButton_Click(sender As Object, e As EventArgs) Handles Send2MCSButton.Click
        SendTo_MincraftServer()
    End Sub

    Private Sub SetupButton_Click(sender As Object, e As EventArgs) Handles SetupButton.Click
        If MC_Server_WorkState = 1 Then Exit Sub
        Form2.Show()
        Form2.BringToFront()
    End Sub

    Private Sub BoxRefreshTimer_Tick(sender As Object, e As EventArgs) Handles BoxRefreshTimer.Tick

        SendMessage(MCS_Richtexbox.Handle, WM_VSCROLL, CType(SB_PAGEBOTTOM, IntPtr), IntPtr.Zero)
        BoxRefreshTimer.Enabled = False

    End Sub

    Private Sub ManServerRefreshTimer_Tick(sender As Object, e As EventArgs) Handles ManServerRefreshTimer.Tick

        If (Man_Port_Number > 0) And (Man_TCP_ErrorTimes < 10) Then

            If Man_Port_Number_OLD <> Man_Port_Number Then
                Man_Port_Number_OLD = Man_Port_Number
                Stop_Management_Server()
                My.Application.DoEvents()
                Start_Management_Server()
            Else
                Start_Management_Server()
            End If

        Else

            If FthWallMC_Server > 0 Then
                Stop_Management_Server()
            End If

        End If

        Select Case FthWallMC_Server

            Case 0
                RCState_Label.Text = "OFF"
                RCState_Label.ForeColor = Color.FromArgb(255, 128, 128, 255)

            Case 1
                RCState_Label.Text = "Try"
                RCState_Label.ForeColor = Color.FromArgb(255, 238, 238, 128)
            Case 2
                RCState_Label.Text = "ON"
                RCState_Label.ForeColor = Color.FromArgb(255, 64, 238, 64)
        End Select

        Select Case FthWallMC_Server_Bypass
            Case 0
                ModeRC_Button.Text = "RemoteCon" + vbNewLine + "Normal (0)"
                ModeRC_Button.BackColor = Color.White
            Case 1
                ModeRC_Button.Text = "RemoteCon" + vbNewLine + "Pass (1)"
                ModeRC_Button.BackColor = Color.Orange
            Case 2
                ModeRC_Button.Text = "RemoteCon" + vbNewLine + "Busy (2)"
                ModeRC_Button.BackColor = Color.Yellow
        End Select

        Select Case Man_Flood_ToEXE

            Case 0, 2

                If Man_Flood_ToEXE = 0 Then
                    ModeExeFW_Button.BackColor = Color.White
                    ModeExeFW_Button.Text = "EXE Flood way" + vbNewLine + "MC↮EXE"
                Else
                    ModeExeFW_Button.BackColor = Color.Pink
                    ModeExeFW_Button.Text = "EXE Flood way" + vbNewLine + "MC→EXE"
                End If

                ModeExeBM_Button.BackColor = Color.Gray
                Select Case Man_ThisTime_W2Say
                    Case False
                        ModeExeBM_Button.Text = "MC←EXE use" + vbNewLine + """Whisper"" (N/A)"
                    Case True
                        ModeExeBM_Button.Text = "MC←EXE use" + vbNewLine + """Say"" (N/A)"
                End Select

            Case 1

                ModeExeFW_Button.BackColor = Color.LightSkyBlue
                ModeExeFW_Button.Text = "EXE Flood way" + vbNewLine + "MC←EXE"

                Select Case Man_ThisTime_W2Say
                    Case False
                        ModeExeBM_Button.BackColor = Color.Wheat
                        ModeExeBM_Button.Text = "MC←EXE use" + vbNewLine + """Whisper"""
                    Case True
                        ModeExeBM_Button.BackColor = Color.LightYellow
                        ModeExeBM_Button.Text = "MC←EXE use" + vbNewLine + """Say"""
                End Select

        End Select

        Select Case BurstMode

            Case 1
                BurstModeButton.Text = "Burst Mode" + vbNewLine + "ON"
                BurstModeButton.BackColor = Color.GreenYellow

            Case 0
                BurstModeButton.Text = "Burst Mode" + vbNewLine + "OFF"
                BurstModeButton.BackColor = Color.White

        End Select

    End Sub


    Private Sub MCServerRefreshTimer_Tick(sender As Object, e As EventArgs) Handles MCServerRefreshTimer.Tick

        Select Case MC_Server_WorkState

            Case 0

                MCSState_Label.Text = "Minecraft Server: OFF"

                If MCServer_BAT_Mode Then
                    CPUUsage_Label.Text = "CPU: " + "N/A (using BAT)"
                    MemUsage_Label.Text = "Mem: " + "N/A (using BAT)"
                Else
                    CPUUsage_Label.Text = "CPU: " + "0.0% / " + MCServer_CPU_Peak.ToString("0.0") + "%"
                    MemUsage_Label.Text = "Mem: " + "0 MB / " + (MCServer_RAM_Peak / 1048576).ToString("0.0") + " MB"
                End If

                StartButton.Enabled = True
                BackupButton.Enabled = True
                KillTaskButton.Enabled = False

            Case 1

                MCSState_Label.Text = "Minecraft Server: BUSY"

                If MCServer_BAT_Mode Then
                    CPUUsage_Label.Text = "CPU: " + "N/A (using BAT)"
                    MemUsage_Label.Text = "Mem: " + "N/A (using BAT)"
                End If

                StartButton.Enabled = False
                BackupButton.Enabled = False
                KillTaskButton.Enabled = True

            Case 2

                MCSState_Label.Text = "Minecraft Server: ON"

                StartButton.Enabled = False
                BackupButton.Enabled = False
                KillTaskButton.Enabled = True

                Try

                    If Not MC_Process.HasExited Then

                        If MCServer_BAT_Mode Then

                            CPUUsage_Label.Text = "CPU: " + "N/A (using BAT)"
                            MemUsage_Label.Text = "Mem: " + "N/A (using BAT)"

                        ElseIf MC_Server_WorkState = 2 Then

                            If cpuCounter IsNot Nothing Then

                                MC_Process.Refresh()

                                MCServer_CPU_Now = CSng(cpuCounter.NextValue()) / Environment.ProcessorCount

                                If MCServer_CPU_Wait > 10 Then
                                    If MCServer_CPU_Now > MCServer_CPU_Peak Then MCServer_CPU_Peak = MCServer_CPU_Now
                                Else
                                    MCServer_CPU_Wait += 1
                                End If

                                CPUUsage_Label.Text = "CPU: " + MCServer_CPU_Now.ToString("0.0") + "% / " + MCServer_CPU_Peak.ToString("0.0") + "%"

                                MCServer_RAM_Now = MC_Process.WorkingSet64
                                If MCServer_RAM_Now > MCServer_RAM_Peak Then MCServer_RAM_Peak = MCServer_RAM_Now
                                MemUsage_Label.Text = "Mem: " + (MCServer_RAM_Now / 1048576).ToString("0.0") + " MB / " + (MCServer_RAM_Peak / 1048576).ToString("0.0") + " MB"

                            End If

                        End If

                    Else
                        MC_Server_WorkState = 0
                    End If

                Catch ex As Exception

                    MCS_Richtexbox.Text += vbNewLine + "MCServerRefreshTimer_Tick: " + ex.Message + vbNewLine

                End Try

        End Select

    End Sub
    Public Sub SendTo_MincraftServer()

        If MC_Server_WorkState <> 2 Then Exit Sub

        Write_To_Console(MCS_ConsoleTextbox.Text)

        Send2Recent(Send2IdxLast) = MCS_ConsoleTextbox.Text
        Send2IdxLast += 1
        If Send2IdxLast > 9 Then Send2IdxLast = 0
        Send2Idx = Send2IdxLast

        MCS_ConsoleTextbox.Text = ""

    End Sub

    Private Sub CloseForm(sender As Object, ByRef e As CancelEventArgs)

        If MsgBox("Exit?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

            If MC_Server_WorkState = 2 Then
                MCS_ConsoleTextbox.Text = "stop"
                SendTo_MincraftServer()
                Dim WaitCount As Integer
                WaitPanel.Visible = True

                Do
                    My.Application.DoEvents()
                    Thread.Sleep(100)
                    WaitCount += 1
                    If MC_Server_WorkState = 0 Then
                        ReallyClose = True
                        Me.Close()
                        End
                    End If
                Loop Until WaitCount = 200

                WaitPanel.Visible = False
                If MsgBox("Looks like auto-shutdown is fault or take time too long." + vbNewLine + vbNewLine +
                          "Do you still want exit? ", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    ReallyClose = True
                    Me.Close()
                    End
                End If

            ElseIf MC_Server_WorkState = 1 Then

                If MsgBox("Some missions are still working, it's will make problem if force to exit. Sure? ", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    ReallyClose = True
                    Me.Close()
                    End
                End If

            Else
                ReallyClose = True
                Me.Close()
                End

            End If
        Else

            If sender Is Me Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles MCS_ConsoleTextbox.KeyUp

        Select Case e.KeyCode

            Case Keys.Enter
                SendTo_MincraftServer()

            Case Keys.Up

                Send2Idx -= 1
                If Send2Idx < 0 Then Send2Idx = 9
                MCS_ConsoleTextbox.Text = Send2Recent(Send2Idx)

            Case Keys.Down

                Send2Idx += 1
                If Send2Idx > 9 Then Send2Idx = 0
                MCS_ConsoleTextbox.Text = Send2Recent(Send2Idx)

        End Select

    End Sub

    Private Sub ManServerTimeOutTimer_Tick(sender As Object, e As EventArgs) Handles ManServerTimeOutTimer.Tick

        If Clients_Now_Max = -1 Then Exit Sub

        For Each TempClient As ClientWorker In Clients
            If TempClient.DeadTime >= 1 Then
                TempClient.DeadTime += 1
                If TempClient.DeadTime >= TCP_timeout_s Then
                    SendToClients("TIMEOUT", TempClient.TheSocket)
                    TempClient.IsUsing = False
                    TempClient.DeadTime = 0
                    TempClient.TheSocket.Close()
                End If
            End If
        Next

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click

        Dim e1 As New CancelEventArgs
        CloseForm(sender, e1)

    End Sub

    Private Sub BackupButton_Click(sender As Object, e As EventArgs) Handles BackupButton.Click

        Start_Server_Backup_Process(ZIP_Launch_Parameter, ZIP_EXE_Location, ZIP_TIME_Format)

    End Sub

    Private Sub KillTaskButton_Click(sender As Object, e As EventArgs) Handles KillTaskButton.Click

        If MsgBox("**WARNING** " + vbNewLine + vbNewLine + "It's will terminate the operation, " + vbNewLine + vbNewLine _
                + "and may cause some datas collapse, unsaved data lost, or other problems!!!" + vbNewLine + vbNewLine _
               + "Are you sure?", MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.No Then Exit Sub

        kill_task()

    End Sub

    Private Sub kill_task()

        If MC_IS_LAUNCHED Then
            If Not MC_Process.HasExited Then
                MC_Process.Kill()
            End If
        End If

        If ZIP_IS_LAUNCHED Then
            If Not ZIP_Process.HasExited Then
                ZIP_Process.Kill()
            End If
        End If

    End Sub

    Private Sub ModeRC_Button_Click(sender As Object, e As EventArgs) Handles ModeRC_Button.Click

        FthWallMC_Server_Bypass += 1
        FthWallMC_Server_Bypass = FthWallMC_Server_Bypass Mod 3

    End Sub

    Private Sub EXEBoxRefreshTimer_Tick(sender As Object, e As EventArgs) Handles EXE_BoxRefreshTimer.Tick

        SendMessage(EXE_Texbox.Handle, WM_VSCROLL, CType(SB_PAGEBOTTOM, IntPtr), IntPtr.Zero)
        EXE_BoxRefreshTimer.Enabled = False

    End Sub

    Private Sub Send2EXEButton_Click(sender As Object, e As EventArgs) Handles Send2EXE_Button.Click
        EXE_Write_To_Console(Send2Exe_TextBox.Text)
        Send2Exe_TextBox.Text = ""
    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles Send2Exe_TextBox.KeyUp
        If e.KeyCode = Keys.Enter Then
            EXE_Write_To_Console(Send2Exe_TextBox.Text)
            Send2Exe_TextBox.Text = ""
        End If
    End Sub

    Private Sub ModeCFW_Button_Click(sender As Object, e As EventArgs) Handles ModeExeFW_Button.Click

        Man_Flood_ToEXE += 1
        If Man_Flood_ToEXE = 3 Then Man_Flood_ToEXE = 0

    End Sub

    Private Sub SP1Mon_Tick(sender As Object, e As EventArgs) Handles SP1Mon.Tick

        If Man_COM_Port Is Nothing Then  Exit Sub 


        If Man_COM_Port.ToLower = "off" Then
            If SP1.IsOpen Then
                SP1.Close()
            End If
            COMState_Label.Text = "OFF"
            Exit Sub
        Else
            Try
                If Not SP1.IsOpen Then

                    SP1.PortName = Man_COM_Port
                    SP1.BaudRate = Man_COM_Buad
                    SP1.Open()
                    SP1.DiscardInBuffer()

                ElseIf (Man_COM_Buad <> SP1.BaudRate) OrElse (Man_COM_Port <> SP1.PortName) Then

                    SP1.DiscardInBuffer()
                    SP1.DiscardOutBuffer()
                    SP1.Close()
                    My.Application.DoEvents()
                    SP1.PortName = Man_COM_Port
                    SP1.BaudRate = Man_COM_Buad
                    SP1.Open()
                    SP1.DiscardInBuffer()

                End If
            Catch ex As Exception
                COMState_Label.Text = Man_COM_Port + " (Error)"
                Exit Sub
            End Try

            COMState_Label.Text = Man_COM_Port + " (ON)"
            Exit Sub
        End If

    End Sub

    Private Sub SP1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SP1.DataReceived

        Dim Reciver_Data_Long As Integer
        Reciver_Data_Long = SP1.BytesToRead
        ReDim Reciver_Data(Reciver_Data_Long)
        SP1.Read(Reciver_Data, 0, Reciver_Data_Long)

        Dim TmpString1 As String = UnicodeBytesToString(Reciver_Data, Reciver_Data_Long)
        Dim Reciver_ReadySeand(0) As String

        Dim TmpIdx1, TmpIdx2 As Integer

        If InStr(TmpString1, vbCrLf) > 0 Then
            Reciver_ReadySeand = TmpString1.Split(vbCrLf)
        ElseIf InStr(TmpString1, vbCr) > 0 Then
            Reciver_ReadySeand = TmpString1.Split(vbCr)
        ElseIf InStr(TmpString1, vbLf) > 0 Then
            Reciver_ReadySeand = TmpString1.Split(vbLf)
        Else
            Reciver_str_Last += TmpString1
            Exit Sub
        End If

        TmpIdx2 = UBound(Reciver_ReadySeand)

        If TmpIdx2 > 0 Then

            Reciver_ReadySeand(0) = Reciver_str_Last + Reciver_ReadySeand(0)

            For TmpIdx1 = 0 To TmpIdx2 - 1
                Reciver_ReadySeand(TmpIdx1) = Replace(Reciver_ReadySeand(TmpIdx1), vbCr, "")
                Reciver_ReadySeand(TmpIdx1) = Replace(Reciver_ReadySeand(TmpIdx1), vbLf, "")
                Write_To_Console(Reciver_ReadySeand(TmpIdx1))
            Next

            Reciver_str_Last = Replace(Reciver_ReadySeand(TmpIdx2), vbCr, "")
            Reciver_str_Last = Replace(Reciver_str_Last, vbLf, "")

        End If

    End Sub

    Private Function UnicodeBytesToString(ByVal bytes() As Byte, data_long As Integer) As String

        For idx As Integer = 0 To UBound(bytes)
            If bytes(idx) < 10 Then bytes(idx) = 32
            If bytes(idx) > 126 Then bytes(idx) = 32
        Next

        Return System.Text.Encoding.ASCII.GetString(bytes, 0, data_long)
    End Function

    Private Sub ModeCBM_Button_Click(sender As Object, e As EventArgs) Handles ModeExeBM_Button.Click
        Man_ThisTime_W2Say = Not Man_ThisTime_W2Say
    End Sub

    Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles HelpAbout_Button.Click
        Form3.Show()
        Form3.BringToFront()
    End Sub


    Private Sub MCS_Richtexbox_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles MCS_Richtexbox.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub BurstModeButton_Click(sender As Object, e As EventArgs) Handles BurstModeButton.Click
        BurstMode = BurstMode Xor 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Form4.BringToFront()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If ReallyClose = False Then
            CloseForm(sender, e)
        End If

    End Sub


End Class
