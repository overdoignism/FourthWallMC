Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Net
Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Runtime.InteropServices
Imports System.Net.Sockets

Public Class Form1
    Structure ClientWorker
        Dim TheSocket As Sockets.TcpClient
        Dim IsUsing As Boolean
        Dim DeadTime As Long
    End Structure

    ' Why so many public declared here ??
    ' Because Multi-thread works. I don't want process what the sync/async/lock or something.
    ' Anyway it's work.

    Private cpuCounter As System.Diagnostics.PerformanceCounter

    Dim MC_Process As New System.Diagnostics.Process()
    Dim ZIP_Process As New System.Diagnostics.Process()

    Public Shared Get_Process_Error_String As String

    Const Saved_String_Max2 As Integer = 2047
    Public Shared Saved_String_IDX2 As Integer = 0
    Public Shared Saved_String2(Saved_String_Max2) As String
    Public Shared Show_String2 As String
    Public Shared Show_String2_old As String
    'Private Delegate Sub UpdateUICB(ByVal MyText As String, ByVal c As Control)
    Public myStreamWriter As StreamWriter

    Const EXE_Saved_String_Max2 As Integer = 2047
    Public Shared EXE_Saved_String_IDX2 As Integer = 0
    Public Shared EXE_Saved_String2(EXE_Saved_String_Max2) As String
    Public Shared EXE_Show_String2 As String
    Public Shared EXE_Show_String2_old As String
    'Private Delegate Sub EXE_UpdateUICB(ByVal MyText As String, ByVal c As Control)

    Public FthWallMC_Server As Integer = 0 '0 = Offline 1 = Trying 2= Online
    Public FthWallMC_Server_TcpListerner As Sockets.TcpListener

    Public Clients() As ClientWorker
    Public Clients_Now_Max As Integer = -1

    Public MC_Server_WorkState As Integer = 0 ' 0=off  1=BUSY  2=on

    Public Waiting_Input As Boolean
    Public Waiting_Input_count As Integer

    Dim MC_IS_LAUNCHED As Boolean
    Dim ZIP_IS_LAUNCHED As Boolean

    Dim Reciver_Data(0) As Byte
    Dim Reciver_str_Last As String
    Dim ReallyClose As Boolean
    Dim Closing_Socket As Boolean
    Dim LoadFont As Font

    'Mux
    Const HowManyMux_Arry As Integer = 9
    Const HowManyMux_ArryADD1 As Integer = HowManyMux_Arry + 1
    Dim Mux(HowManyMux_Arry) As ScriptCake

    'Send to Console UP+DOWN key Get recent use
    Dim Send2Recent(1)() As String
    Dim Send2Idx() As Integer = {0, 0}
    Dim Send2IdxLast() As Integer = {0, 0}

    'Get the time tick
    Dim I_Asking_Tick(HowManyMux_ArryADD1) As Boolean
    Dim Time_AskMap(HowManyMux_ArryADD1) As String
    Dim Time_TickReturn(HowManyMux_ArryADD1) As String

    'Get the locate
    Dim I_Asking_Locate(HowManyMux_ArryADD1) As Boolean
    Dim IAL_Argu_Pos(HowManyMux_ArryADD1) As String
    Dim IAL_Argu_Findwhat(HowManyMux_ArryADD1) As String
    Dim IAL_Argu_Findwhat2(HowManyMux_ArryADD1) As String
    Dim IAL_Return(HowManyMux_ArryADD1) As String

    'Get the locatebiome
    Dim I_Asking_LocateBiome(HowManyMux_ArryADD1) As Boolean
    Dim IALB_Argu_Pos(HowManyMux_ArryADD1) As String
    Dim IALB_Argu_Findwhat(HowManyMux_ArryADD1) As String
    Dim IALB_Argu_Findwhat2(HowManyMux_ArryADD1) As String
    Dim IALB_Return(HowManyMux_ArryADD1) As String

    'Raw Read Back
    Dim I_Asking_RawRead(HowManyMux_ArryADD1) As Boolean
    Dim IARR_Argu_Findwhat(HowManyMux_ArryADD1)() As String
    Dim IARR_Return(HowManyMux_ArryADD1) As String

    Dim OneTime_A_Listbox_Act As Boolean
    Dim ExeWorkingDir As String = ""
    Public SerWorkingDir As String = ""


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Get_All_IP_Addr()
        ReDim Send2Recent(0)(9)
        ReDim Send2Recent(1)(9)
        Man_Who_LastSending = FwmcWorker
        Man_Who_LastSending_wBack = "CONSOLE"
        Form2.COMLineEnd.SelectedIndex = 0
        Add_to_NoteListbox("FourthWallMC System start.")
        Me.Text = "FourthWallMC v" + FwmcVer + " < You don't need to break it, we put window on the wall. >  By overdoingism Lab."
        RestartCon_Button.Text = "Restart Main" + vbCrLf + "Console"
        Kill_Mux_Con.Text = "Kill all Mux" + vbCrLf + "Console"
        RCState_Label.ForeColor = Color.FromArgb(255, 128, 128, 255)
        ModeRC_Button.Text = "Work Mode" + vbCrLf + "Normal (0)"
        ModeExeFW_Button.Text = "Flood way (Main)" + vbCrLf + "MC←Console"

        DetectOS_and_var()

        '=====Serial Port init
        'SP1 serial port...
        'The code is for Compatible with .net 5
        SP1_Init()
        Make_SerialPort_List()
        Man_COM_Port = "off"
        '======================

        '=========Load settings
        Origial_Path = Directory.GetCurrentDirectory
        If My.Computer.FileSystem.FileExists(Origial_Path + PDSC + "Setting.xml") Then
            Dim ErrorTest As String = LoadXML()
            If ErrorTest <> "" Then MsgBox("(Loading setting)" + ErrorTest, "", "Error")
        End If

        '=========Detect working folder and set
        SerWorkingDir = GSet_Jar_as_Work_folder(MCServer_JAR_BAT_Location, True)
        If SerWorkingDir <> "" Then SerWorkingPath_TextBox.Text = SerWorkingDir

        '============Fix wired bug
        TabControl1.SelectedIndex = 1
        My.Application.DoEvents()
        TabControl1.SelectedIndex = 0
        My.Application.DoEvents()

        '??? What this for
        CheckForIllegalCrossThreadCalls = False

        Try
            If My.Computer.FileSystem.FileExists(Origial_Path + PDSC + "FontToLoad.otf") Then
                LoadFont = New Font(LoadFontFile(Origial_Path + PDSC + "FontToLoad.otf"), 9, FontStyle.Regular)
                MCS_Richtexbox.Font = LoadFont
                EXE_Textbox.Font = LoadFont
                Form3.Help_RichTextBox.Font = LoadFont
            End If

            MCS_Richtexbox.LanguageOption = RichTextBoxLanguageOptions.UIFonts
            EXE_Textbox.LanguageOption = RichTextBoxLanguageOptions.UIFonts

            Add_to_NoteListbox("FontToLoad.otf found and loaded.")
            My.Application.DoEvents()
        Catch ex As Exception

        End Try

        If My.Application.CommandLineArgs().Count > 0 Then
            If My.Application.CommandLineArgs(0).ToLower = "now" Then
                Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter)
            End If
        End If

        Start_EXE_Process(Man_EXE_FirstExec, 0, "Main", FwmcWorker)

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

        MCServerRefreshTimer.Enabled = False

        If FthWallMC_Server <> 2 Then

            FthWallMC_Server = 1
            Try

                If Local_IP_ADDR = "Any" Then
                    FthWallMC_Server_TcpListerner = New Sockets.TcpListener(IPAddress.IPv6Any, Man_Port_Number)
                    FthWallMC_Server_TcpListerner.Server.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, False)
                ElseIf Local_IP_ADDR = "IPv4 Any" Then
                    FthWallMC_Server_TcpListerner = New Sockets.TcpListener(IPAddress.Any, Man_Port_Number)
                ElseIf Local_IP_ADDR = "IPv6 Any" Then
                    FthWallMC_Server_TcpListerner = New Sockets.TcpListener(IPAddress.IPv6Any, Man_Port_Number)
                Else
                    FthWallMC_Server_TcpListerner = New Sockets.TcpListener(IPAddress.Parse(Local_IP_ADDR), Man_Port_Number)
                End If

                FthWallMC_Server_TcpListerner.Start()
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                FthWallMC_Server = 2
            Catch ex As Exception
                FthWallMC_Server = 1
                Add_to_NoteListbox("Start_Management_Server():" + ex.Message)
            End Try

        End If

        MCServerRefreshTimer.Enabled = True
        Closing_Socket = False

        Return True

    End Function

    Public Function Stop_Management_Server() As Boolean

        Dim TmpState As Integer = FthWallMC_Server
        Closing_Socket = True

        MCServerRefreshTimer.Enabled = False
        Waiting_Input = False

        If FthWallMC_Server = 0 Then
            Stop_Management_Server = True
            Exit Function
        End If

        If FthWallMC_Server >= 1 Then
            FthWallMC_Server = 1
            Try

                If Clients IsNot Nothing Then
                    For Each TmpClient As ClientWorker In Clients
                        If TmpClient.TheSocket IsNot Nothing Then
                            TmpClient.TheSocket.Close()
                            TmpClient.IsUsing = False
                            TmpClient.DeadTime = 0
                            TmpClient.TheSocket.Dispose()
                        End If
                    Next
                End If

                FthWallMC_Server_TcpListerner.Stop()
                FthWallMC_Server = 0

            Catch ex As Exception

                FthWallMC_Server = TmpState
                RCState_Label.Text = "ERROR"
                Add_to_NoteListbox("Stop_Management_Server():" + ex.Message)
                Return False

            End Try

        End If

        RCState_Label.Text = "OFF"
        MCServerRefreshTimer.Enabled = True

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

            Add_to_NoteListbox("Handler_Client()1:" + ex.Message)

            If Closing_Socket Then
                FthWallMC_Server = 0
                Exit Sub
            End If

            If Man_TCP_ErrorTimes <= 10 Then
                Man_TCP_ErrorTimes += 1
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
            Else
                MsgBox("Uncoveable error happend too many times when start RC Server. Abort.", 0, "Error")
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
            Dim Command_Mode, Command_Str As String

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
                ElseIf Rcv_Str.Substring(0, Man_Pwd_Length + 1) <> Man_Password + ";" Then
                    ErrorType = 1
                Else

                    Command_Mode = Rcv_Str.Substring(Man_Pwd_Length + 1, 2).ToLower
                    Command_Str = Rcv_Str.Substring(Man_Pwd_Length + 4)

                    If Command_Str.Length = 0 Then ErrorType = 1
                    If Rcv_Str.Substring(Man_Pwd_Length + 3, 1) <> ";" Then ErrorType = 1

                End If

                If ErrorType = 0 Then
                    Process_Get_Command(Command_Mode, Command_Str, 0, -1, "", Clients(Tmp_Idx1))
                Else
                    Command_err_ListBox.Items.Insert(0, "HANC:" + Command_Mode + ";" + Command_Str)
                    SendToClients("BAD", Clients(Tmp_Idx1).TheSocket)
                End If

            End If

            SocketNetworkStream.Close()
            CloseASocket(Clients(Tmp_Idx1))
            Waiting_Input = False

        Catch ex As Exception

            Add_to_NoteListbox("Handler_Client()2:" + ex.Message)
            Try
                CloseASocket(Clients(Tmp_Idx1))
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                Waiting_Input = False
            Finally
            End Try

        End Try

    End Sub

    Function Process_Get_Command(Command_Mode As String, Command_str As String, RCorEXE_Mode As Integer, Mux_slot As Integer, Return_PreFix As String,
                                 Optional ByRef TmpClientWork As ClientWorker = Nothing) As Integer

        Process_Get_Command = 0
        Dim WorkString As String = ""
        Dim WrongFmt As Integer = 0
        Command_Mode = Command_Mode.ToLower

        Select Case Command_Mode
            '======== all time
            Case "sy" 'Say to server (whatever)
            Case "sf" 'Load settings from file
            Case "vr" 'Var Read
            Case "vw" 'Var Write
            Case "vc" 'Var Read & Clear
            Case "ss" 'Set setting (4WMC 2 mode)
            Case "pr" 'Get Login/Logout player
            Case "eq" 'Put in Game Main EXE Console request to Queue
            Case "mu" 'The Console Muxer command
           '===============
            Case "cm" 'Command
           '============ need workable state is ok
            Case "bk" 'Backup with differnt settings
            Case "gt" 'Get ticket
            Case "gl" 'Get Locate
            Case "gb" 'Get Biome
            Case "rr" 'Raw Read
            Case "in" 'MC server command insert
            Case Else
                If RCorEXE_Mode = 0 Then SendToClients("BAD", TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console("BAD", Return_PreFix, Mux_slot)
                Command_err_ListBox.Items.Insert(0, "PGC1:" + Command_Mode + ";" + Command_str + ";" + RCorEXE_Mode.ToString)
                Return 1
        End Select

        If Command_Mode = "sy" Then

            If MC_Server_WorkState = 2 Then
                Write_To_Console("say " + Command_str)
            End If

            If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
            Return 1

        ElseIf Command_Mode = "sf" Then

            WorkString = LoadXML(Command_str)
            If WorkString = "" Then WorkString = "OK"

            If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
            Return 1

        ElseIf Command_Mode = "cm" Then

            Select Case Command_str.ToLower

                Case "info1"
                    If RCorEXE_Mode = 2 Then Return 2

                    If MC_Server_WorkState = 0 Then
                        WorkString = "OFF"
                    ElseIf MC_Server_WorkState = 1 Then
                        WorkString = "BUSY"
                    ElseIf MC_Server_WorkState = 2 Then
                        WorkString = "ON"
                    End If

                Case "info2"
                    Select Case FthWallMC_Server_Bypass
                        Case 0
                            WorkString = "OK"
                        Case 1
                            WorkString = "PASS"
                        Case 2
                            WorkString = "WAIT"
                    End Select

                Case "info3"
                    If RCorEXE_Mode = 2 Then Return 2
                    WorkString = GetLiveTime2(MC_Server_WorkState) + ";" + MCServerType + ";" + FwmcVer

                Case "kill"
                    kill_task()
                    WorkString = "OK"

                Case "kill2"
                    kill_task(False)
                    WorkString = "OK"

                Case "kill3"
                    Restart_EXEConsole("!_CM_KILL3")
                    WorkString = "OK"

                Case "sender"
                    If RCorEXE_Mode = 0 Then WorkString = "!_N/A"
                    If RCorEXE_Mode = 1 Then
                        If Mux(Mux_slot).Last_Sender <> "" Then
                            WorkString = Mux(Mux_slot).Last_Sender
                        Else
                            WorkString = "!_N/A"
                        End If
                    End If

                Case "launcher"
                    If RCorEXE_Mode = 0 Then WorkString = "!_N/A"
                    If RCorEXE_Mode = 1 Then
                        If Mux(Mux_slot).Last_Sender <> "" Then
                            WorkString = Mux(Mux_slot).The_Launcher
                        Else
                            WorkString = "!_N/A"
                        End If
                    End If

            End Select

            If WorkString <> "" Then
                If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                Return 1
            End If

        ElseIf Command_Mode = "eq" Then

            Select Case Command_str.ToLower
                Case "start"
                    If Queued_EXE_Command_Enable = False Then
                        Queued_EXE_Command_Enable = True
                        QueueEXE_RunnerTimer.Enabled = False
                        Queue_TextBox.Text = "Queuing"
                    End If
                    If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                    Return 1
                Case "stop"
                    If Queued_EXE_Command_Enable = True Then
                        Queued_EXE_Command_Enable = False
                        QueueEXE_RunnerTimer.Enabled = True
                        Queue_TextBox.Text = "Stopped and Launching"
                    End If
                    If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                    Return 1
                Case "clear"
                    Clear_EXE_Queue(False)
                    If Queued_EXE_Command_Enable Then
                        Queue_TextBox.Text = "Queuing"
                    Else
                        Queue_TextBox.Text = "Stopped"
                    End If
                    If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                    Return 1
                Case Else
                    WrongFmt = 1
            End Select

            If WrongFmt = 0 Then
                If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                Return 1
            End If

        ElseIf Command_Mode = "ss" Then

            If Get_Full_MCServer_Control(Command_str) = 0 Then
                WrongFmt = 1
            Else
                If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                Return 1
            End If

        ElseIf Command_Mode = "vr" Then

            If (Command_str.Length < 1) Then
                WrongFmt = 1
            Else
                WorkString = variableString(Val(Command_str.Substring(0, 1)))
                If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                Return 1
            End If

        ElseIf Command_Mode = "vc" Then

            If (Command_str.Length < 1) Then
                WrongFmt = 1
            Else
                WorkString = variableString(Val(Command_str.Substring(0, 1)))
                variableString(Val(Command_str.Substring(0, 1))) = ""
                If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                Return 1
            End If

        ElseIf Command_Mode = "vw" Then

            If (Command_str.Length < 2) OrElse (Command_str.Substring(1, 1) <> ";") Then
                WrongFmt = 1
            Else
                variableString(Val(Command_str.Substring(0, 1))) = Command_str.Substring(2)

                If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                Return 1

            End If

        ElseIf Command_Mode = "pr" Then

            If Command_str.ToLower = "login" Then
                For TmpIDXa01 As Integer = 0 To (Player_Login.Items.Count - 1)
                    WorkString += Player_Login.Items(TmpIDXa01)
                    If TmpIDXa01 <> (Player_Login.Items.Count - 1) Then WorkString += ";"
                Next
            ElseIf Command_str.ToLower = "logout" Then
                For TmpIDXa01 As Integer = 0 To (Player_Logout.Items.Count - 1)
                    WorkString += Player_Logout.Items(TmpIDXa01)
                    If TmpIDXa01 <> (Player_Logout.Items.Count - 1) Then WorkString += ";"
                Next
            Else
                WrongFmt = 1
            End If

            If WrongFmt = 0 Then
                If WorkString = "" Then WorkString = "(none)"
                If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                Return 1
            End If

        ElseIf Command_Mode = "mu" Then

            If Mux_slot = -1 Then
                If RCorEXE_Mode = 0 Then SendToClients("EXE CONSOLE ONLY", TmpClientWork.TheSocket)
                Return 1
            End If

            Select Case Command_str
                Case "info1"
                    If RCorEXE_Mode = 1 Then
                        EXE_Write_To_Console("(" + Mux_slot.ToString + ")SSP:" + Mux(Mux_slot).Script_Specify_Prefix +
                                           ";ASP:" + Mux(Mux_slot).Alias_Specify_Prefix + ";", Return_PreFix, Mux_slot)
                    End If
                    Return 1
            End Select

            If Command_str.Length > 4 Then
                Select Case Command_str.Substring(0, 3).ToLower
                    Case "rv;"
                        WorkString = Command_str.Substring(3)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console(Get_Var_From_Alias_Prefix(WorkString, False), Return_PreFix, Mux_slot)
                        Return 1
                    Case "rc;"
                        WorkString = Command_str.Substring(3)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console(Get_Var_From_Alias_Prefix(WorkString, True), Return_PreFix, Mux_slot)
                        Return 1
                    Case "wv;"
                        Mux(Mux_slot).The_Cake_Var = Command_str.Substring(3)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                        Return 1
                    Case "st;"
                        Mux(Mux_slot).Alias_Specify_Prefix = Command_str.Substring(3)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                        Return 1
                    Case "go;"

                        Dim TmpStr() As String = Command_str.Substring(3).Split(";")

                        If UBound(TmpStr) = 1 Then
                            Dim Launcher As String = ""
                            If RCorEXE_Mode = 0 Then Launcher = "Socket script"
                            If RCorEXE_Mode = 1 Then Launcher = Mux(Mux_slot).Script_Specify_Prefix
                            Select Case Launch_Cake_Form_Prefix(TmpStr(0), TmpStr(1), Launcher)
                                Case -1
                                    WorkString = "SLOT FULL"
                                Case -2
                                    WorkString = "DUPLICATE NAME"
                                Case 1
                                    WorkString = "OK"
                            End Select
                        Else
                            WorkString = "BAD*"
                        End If

                        If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                        Return 1

                    Case Else
                        WrongFmt = 1
                End Select
            Else
                WrongFmt = 1
            End If

        End If

        'Below is PASS/WAIT effect command ======================================================

        If WrongFmt = 0 Then

            If FthWallMC_Server_Bypass = 0 Then

                If Command_Mode = "cm" Then

                    If Command_str = "" Then
                        WorkString = "BAD*"
                    ElseIf MC_Server_WorkState = 2 Then
                        WorkString = "NOT-OFF"
                    ElseIf MC_Server_WorkState = 1 Then
                        WorkString = "BUSY"
                    Else
                        Select Case Command_str.ToLower
                            Case "start"
                                WorkString = Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter)
                            Case "backup"
                                WorkString = Start_Server_Backup_Process(ZIP_Launch_Parameter, ZIP_EXE_Location, ZIP_TIME_Format)
                            Case Else
                                WrongFmt = 1
                        End Select
                    End If

                    If WrongFmt = 0 Then
                        If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                        Return 1
                    End If


                ElseIf Command_Mode = "bk" Then

                    If MC_Server_WorkState = 2 Then
                        WorkString = "NOT-OFF"
                    ElseIf MC_Server_WorkState = 1 Then
                        WorkString = "BUSY"
                    Else
                        WorkString = Start_Server_Backup_Process(Command_str, ZIP_EXE_Location, ZIP_TIME_Format)
                    End If

                    If RCorEXE_Mode = 0 Then SendToClients(WorkString, TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console(WorkString, Return_PreFix, Mux_slot)
                    Return 1

                End If

                'Below is must return command ===================== split Line =================================
                If RCorEXE_Mode = 2 Then Return 2

                'Below is must ON / not BUSY need command ===================== split Line =================================
                If MC_Server_WorkState = 0 Then
                    If RCorEXE_Mode = 0 Then SendToClients("NOT-ON", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("NOT-ON", Return_PreFix, Mux_slot)
                    Return 1
                ElseIf MC_Server_WorkState = 1 Then
                    If RCorEXE_Mode = 0 Then SendToClients("BUSY", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("BUSY", Return_PreFix, Mux_slot)
                    Return 1
                End If

                If RCorEXE_Mode = 0 Then Mux_slot = HowManyMux_ArryADD1

                If Command_Mode = "in" Then

                    Write_To_Console(Command_str)
                    If RCorEXE_Mode = 0 Then SendToClients("OK", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("OK", Return_PreFix, Mux_slot)
                    Return 1

                ElseIf Command_Mode = "gt" Then

                    I_Asking_Tick(Mux_slot) = True
                    Time_TickReturn(Mux_slot) = "-1"
                    Time_AskMap(Mux_slot) = Command_str

                    Write_To_Console("execute in " + Time_AskMap(Mux_slot) + " run time query daytime")
                    What_RU_Waiting(Time_TickReturn(Mux_slot), Get_timeout_ds, I_Asking_Tick(Mux_slot))

                    If RCorEXE_Mode = 0 Then SendToClients(Time_TickReturn(Mux_slot), TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console(Time_TickReturn(Mux_slot), Return_PreFix, Mux_slot)

                    Return 1

                ElseIf Command_Mode = "gl" Then

                    IAL_Return(Mux_slot) = "-1"
                    Dim Argus() As String = Command_str.Split(";")

                    If UBound(Argus) < 2 Then
                        WrongFmt = 1
                    Else
                        I_Asking_Locate(Mux_slot) = True
                        IAL_Argu_Pos(Mux_slot) = Argus(0) '/positioned 500 100 500 /as Overdoingism
                        IAL_Argu_Findwhat(Mux_slot) = Argus(1)
                        IAL_Argu_Findwhat2(Mux_slot) = Argus(2) '/ocean
                        If Argus(1) <> "" Then Argus(1) = " in " + Argus(1) '/in the_nether

                        Write_To_Console("execute " + IAL_Argu_Pos(Mux_slot) + Argus(1) + " run locate " + Argus(2))
                        What_RU_Waiting(IAL_Return(Mux_slot), Get_timeout_ds, I_Asking_Locate(Mux_slot))

                        If RCorEXE_Mode = 0 Then SendToClients(IAL_Return(Mux_slot), TmpClientWork.TheSocket)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IAL_Return(Mux_slot), Return_PreFix, Mux_slot)

                        Return 1
                    End If

                ElseIf Command_Mode = "gb" Then

                    IALB_Return(Mux_slot) = "-1"
                    Dim Argus() As String = Command_str.Split(";")

                    If UBound(Argus) < 2 Then
                        WrongFmt = 1
                    Else
                        I_Asking_LocateBiome(Mux_slot) = True
                        IALB_Argu_Pos(Mux_slot) = Argus(0) '/positioned 500 100 500 /as Overdoingism
                        IALB_Argu_Findwhat(Mux_slot) = Argus(1)
                        IALB_Argu_Findwhat2(Mux_slot) = Argus(2) '/ocean
                        If Argus(1) <> "" Then Argus(1) = " in " + Argus(1) '/in the_nether

                        Write_To_Console("execute " + IALB_Argu_Pos(Mux_slot) + Argus(1) + " run locatebiome " + Argus(2))
                        What_RU_Waiting(IALB_Return(Mux_slot), Get_timeout_ds, I_Asking_LocateBiome(Mux_slot))

                        If RCorEXE_Mode = 0 Then SendToClients(IALB_Return(Mux_slot), TmpClientWork.TheSocket)
                        If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IALB_Return(Mux_slot), Return_PreFix, Mux_slot)

                        Return 1
                    End If

                ElseIf Command_Mode = "rr" Then

                    Dim ErrFlag As Integer = 0

                    'Error control
                    IARR_Return(Mux_slot) = "-1"
                    Dim ParseArray() As String = Command_str.Split(";")
                    If ParseArray.Length < 4 Then ErrFlag = 1
                    Dim All_MCCommand As String = Get_All_MCCommand(Command_str)
                    If All_MCCommand = "" Then ErrFlag = 1
                    If ErrFlag = 1 Then Return 1

                    ReDim IARR_Argu_Findwhat(Mux_slot)(2)
                    IARR_Argu_Findwhat(Mux_slot)(0) = ParseArray(0) 'Yes 1
                    IARR_Argu_Findwhat(Mux_slot)(1) = ParseArray(1) 'Yes 2
                    IARR_Argu_Findwhat(Mux_slot)(2) = ParseArray(2) 'No 1

                    I_Asking_RawRead(Mux_slot) = True
                    Write_To_Console(All_MCCommand)
                    What_RU_Waiting(IARR_Return(Mux_slot), Get_timeout_ds, I_Asking_RawRead(Mux_slot))

                    If RCorEXE_Mode = 0 Then SendToClients(IARR_Return(Mux_slot), TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console(IARR_Return(Mux_slot), Return_PreFix, Mux_slot)

                    'Because raw read back is so big to cause crash. It's a fix but not sure why.
                    'If RCorEXE_Mode = 1 Then
                    '    Dim thread As New Threading.Thread(Sub() EXE_Write_To_Console_Thread(IARR_Return(Mux_slot), Return_PreFix, Mux_slot))
                    '    thread.Start()
                    'End If

                    Return 1

                Else

                    If RCorEXE_Mode = 0 Then SendToClients("BAD", TmpClientWork.TheSocket)
                    If RCorEXE_Mode = 1 Then EXE_Write_To_Console("BAD", Return_PreFix, Mux_slot)
                    Command_err_ListBox.Items.Insert(0, "PGC2:" + Command_Mode + ";" + Command_str + ";" + RCorEXE_Mode.ToString)
                    Return 1
                End If

            ElseIf FthWallMC_Server_Bypass = 1 Then

                If RCorEXE_Mode = 0 Then SendToClients("PASS", TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console("PASS", Return_PreFix, Mux_slot)
                Return 1

            ElseIf FthWallMC_Server_Bypass = 2 Then

                If RCorEXE_Mode = 0 Then SendToClients("WAIT", TmpClientWork.TheSocket)
                If RCorEXE_Mode = 1 Then EXE_Write_To_Console("WAIT", Return_PreFix, Mux_slot)
                Return 1

            End If

        End If

        If WrongFmt = 1 Then
            If RCorEXE_Mode = 0 Then SendToClients("BAD*", TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console("BAD*", Return_PreFix, Mux_slot)
            Command_err_ListBox.Items.Insert(0, "PGC3:" + Command_Mode + ";" + Command_str + ";" + RCorEXE_Mode.ToString)
            Return 1
        Else
            If RCorEXE_Mode = 0 Then SendToClients("BAD", TmpClientWork.TheSocket)
            If RCorEXE_Mode = 1 Then EXE_Write_To_Console("BAD", Return_PreFix, Mux_slot)
            Command_err_ListBox.Items.Insert(0, "PGC4:" + Command_Mode + ";" + Command_str + ";" + RCorEXE_Mode.ToString)
        End If

        Return 0

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

                Add_to_NoteListbox("SenToClients():" + ex.Message)
            End Try

        End If

    End Sub

    Private Function Start_MC_Server_Process(The_JAVA_Arguments As String, The_FileName As String, The_JAR_BAT_File As String,
                                             The_MC_Arguments As String, Optional ButtonClick As Boolean = False) As String

        If MC_Server_WorkState <> 0 Then Return "NOT-OFF"

        Dim Launch_File As String = ""
        Dim The_Arguments As String = ""
        MCS_Richtexbox.Text = "Starting Minecraft Server..."
        Start_MC_Server_Process = ""
        MCServerType = "Vanilla (or ND)"
        ServerType_TextBox.Text = MCServerType
        IsEssentialsX_Installed = 0
        Add_to_NoteListbox("Start_MC_Server_Process()")

        Try

            If The_JAR_BAT_File.Length > 5 Then

                If The_JAR_BAT_File.Substring(The_JAR_BAT_File.Length - 4, 4).ToLower = ".bat" Then
                    Launch_File = The_JAR_BAT_File
                    The_Arguments = The_MC_Arguments
                    MCServer_BAT_Mode = True
                Else

                    '=================================== Windows code ===============================
                    If InStr(What_is_the_OS.ToUpper, "MICROSOFT WINDOWS") > 0 Then

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
                                MCS_Richtexbox.Text += vbCrLf + "JVM java.exe not present. Please setup first."
                                Return "NEED-SETUP"
                            End If

                        End If

                    Else '=================== ND =============================================================

                        If Not My.Computer.FileSystem.FileExists(The_FileName) Then
                            MCS_Richtexbox.Text += vbCrLf + "JVM java.exe not present. Please setup first."
                            Return "NEED-SETUP"
                        End If

                    End If

                    Launch_File = The_FileName
                    The_Arguments = The_JAVA_Arguments + " -jar " + """" + The_JAR_BAT_File + """ " + The_MC_Arguments
                    MCServer_BAT_Mode = False
                End If
            End If

            '====================Working folder==========
            SerWorkingDir = GSet_Jar_as_Work_folder(The_JAR_BAT_File, True)

            If SerWorkingDir = "" Then
                MCS_Richtexbox.Text += vbCrLf + "Server JAR file / Batch file not present. Please setup first."
                Return "NEED-SETUP"
            Else
                SerWorkingPath_TextBox.Text = SerWorkingDir

                If (SerWorkingDir <> ExeWorkingDir) AndAlso (Mux(0).Is_Working = True) Then 'warning
                    Add_to_NoteListbox("You may need restart Main script console to work properly.", "WARN:Server working folder is different from Main script console's one.")
                End If
            End If

            '=====================EULA========================
            If Not Test_EULA(SerWorkingDir) Then
                If ButtonClick = True Then
                    If MsgBox("Eula.txt is not exist, or not set true." + vbCrLf + vbCrLf + "Do you agreement the EULA: https://account.mojang.com/documents/minecraft_eula ?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
                        MCS_Richtexbox.Text += "abort."
                        Exit Function
                    Else
                        Dim EULA As IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(SerWorkingDir + PDSC + "eula.txt", False, UTF8Encoding.UTF8)
                        EULA.WriteLine("#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://account.mojang.com/documents/minecraft_eula).")
                        EULA.WriteLine("eula=true")
                        EULA.Close()
                    End If
                Else
                    MCS_Richtexbox.Text += "abort."
                    Return "NO-EULA"
                End If
            End If

            '================server.properties==============
            If Not My.Computer.FileSystem.FileExists(SerWorkingDir + PDSC + "server.properties") Then
                If ButtonClick = True Then
                    Dim Res As DialogResult = Form5.ShowDialog
                    Select Case Res
                        Case DialogResult.OK
                        Case DialogResult.Cancel
                            Return ("CANCELED")
                    End Select
                End If
            End If


            '======================plugin detect============
            If My.Computer.FileSystem.DirectoryExists("." + PDSC + "plugins") Then
                Dim FindEssPlugIn() As String = Directory.GetFiles("." + PDSC +
                                                                   "plugins" + Path.DirectorySeparatorChar, "Essentials*.jar")
                If FindEssPlugIn IsNot Nothing AndAlso FindEssPlugIn.Length > 0 Then
                    IsEssentialsX_Installed = 2
                Else
                    IsEssentialsX_Installed = 1
                End If
            Else
                IsEssentialsX_Installed = 1
            End If

            ShowEssX_Det(EssX_Det_TextBox)
            '================================================

            MC_Server_WorkState = 1
            StartButton.Enabled = False
            BackupButton.Enabled = False
            My.Application.DoEvents()

            ReDim Saved_String2(Saved_String_Max2)
            Saved_String2(0) = "Starting Minecraft Server..." + vbCrLf
            Saved_String_IDX2 = 1

            MC_Process = New System.Diagnostics.Process()

            With MC_Process.StartInfo
                .WorkingDirectory = ""
                .FileName = Launch_File
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .Arguments = The_Arguments
            End With

            MC_Process.EnableRaisingEvents = True
            MC_Process.SynchronizingObject = Me

            ' Set our event handler to asynchronously read the sort output.
            AddHandler MC_Process.OutputDataReceived, AddressOf OutputHandler
            AddHandler MC_Process.ErrorDataReceived, AddressOf OutputHandler 'ErrOutputHandler
            AddHandler MC_Process.Exited, AddressOf ExitHandler

            My.Application.DoEvents()

            MC_Process.Start()
            MC_Process.BeginOutputReadLine()
            MC_Process.BeginErrorReadLine()

            MC_IS_LAUNCHED = True

            ServerStart_Tick2 = DateDiff(DateInterval.Second, New Date(2010, 1, 1, 12, 0, 0), Now)
            Start_MC_Server_Process = "OK"
            InNeed_Detect_AbnormalEnd = True

            If Not Mux(0).Is_Working Then
                Start_EXE_Process(Man_EXE_FirstExec, 0, "Main", FwmcWorker)
            End If

        Catch ex As Exception

            MC_Server_WorkState = 0
            MCS_Richtexbox.Text += vbCrLf + ex.Message + vbCrLf
            Start_MC_Server_Process = "ERROR"
            Add_to_NoteListbox("Start_MC_Server_Process():" + ex.Message)
        End Try

        PlayerClear()

    End Function

    'Private Sub UpdateUI(ByVal MyText As String, ByVal c As Control)
    '    If InvokeRequired() Then
    '        Dim cb As New UpdateUICB(AddressOf UpdateUI)
    '        Me.Invoke(cb, MyText, c)
    '    Else
    '        c.Text = MyText
    '    End If
    'End Sub

    Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)

        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then

            Dim Tmp_String_Org As String = outLine.Data
            Dim Tmp_String As String = Tmp_String_Org.ToUpper
            Dim TmpIdx1, TmpIdx2 As Integer

            'BoxRefreshTimer.Enabled = False

            '=============Serial Port Out==========
            If SP1.IsOpen Then
                If Man_COM_TxFilterList IsNot Nothing Then
                    For Each Tmp_String2 As String In Man_COM_TxFilterList
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

            '================Flood To Man console=============MC→Main
            If Man_Flood_ToEXE = 2 Then
                If Man_EXE_FDFilterList IsNot Nothing Then
                    For Each Tmp_String2 As String In Man_EXE_FDFilterList
                        If InStr(Tmp_String_Org, Tmp_String2) > 0 Then
                            EXE_Write_To_Console(Tmp_String_Org, "", 0)
                            Exit For
                        End If
                    Next
                Else
                    EXE_Write_To_Console(Tmp_String_Org, "", 0)
                End If
            End If
            '======================================

            '===================================== Console Text Full Buffer
            Saved_String2(Saved_String_IDX2) = Tmp_String_Org + vbCrLf 'Full Buffer
            If Saved_String_IDX2 >= Saved_String_Max2 Then
                Saved_String_IDX2 = 0
            Else
                Saved_String_IDX2 += 1
            End If
            '======================================

            Do 'ALL In Game Command Parsing In this Fake DO-LOOP

                If MC_Server_WorkState = 2 Then

                    If Check_If_Misjudge(Tmp_String) Then 'Need check

                        If MC_Server_WorkState = 2 Then 'Stop detect 
                            '"SERVER THREAD/" " [MINECRAFT/DEDICATEDSERVER]"

                            If InStr(Tmp_String, "]: STOPPING SERVER") > 5 Then
                                InNeed_Detect_AbnormalEnd = False
                                MC_Server_WorkState = 1

                                If WaitBusyLongAsCrash > 0 Then
                                    WaitBLAC_Count = 0
                                    BusyCrash.Enabled = True
                                End If

                                Exit Do

                            End If
                        End If

                        If ParseLogInOut(Tmp_String_Org) Then Exit Do 'Login-out Detect

                        For IDX_TMP_01 As Integer = 0 To 10   ' Get Command process return

                            '============= Get tick command =========
                            If I_Asking_Tick(IDX_TMP_01) Then
                                Time_TickReturn(IDX_TMP_01) = Ticket_Return(Tmp_String_Org)
                            End If

                            '============= Get Locate =========
                            If I_Asking_Locate(IDX_TMP_01) Then
                                IAL_Return(IDX_TMP_01) = Locate_Return(Tmp_String_Org, IAL_Argu_Findwhat(IDX_TMP_01), IAL_Argu_Findwhat2(IDX_TMP_01))
                            End If

                            '============= Get LocateBiome =========
                            If I_Asking_LocateBiome(IDX_TMP_01) Then
                                IALB_Return(IDX_TMP_01) = Locate_Return(Tmp_String_Org, IALB_Argu_Findwhat(IDX_TMP_01), IALB_Argu_Findwhat2(IDX_TMP_01))
                            End If

                            '============= Raw Read Back =========
                            If I_Asking_RawRead(IDX_TMP_01) Then
                                IARR_Return(IDX_TMP_01) = RawRead_Return(Tmp_String_Org, IARR_Argu_Findwhat(IDX_TMP_01))
                            End If

                        Next

                    End If

                    '================================================ GeekCommand Detect

                    Dim GeekCommand As GeekCommand_Rtn = Para_Go(Tmp_String_Org, EXECommand_ViaSay)

                    If GeekCommand.IsUsable Then

                        '=============================================== Mux console Command Detect ==========================

                        Dim InputPrefix As String
                        'init var / split prefix
                        If GeekCommand.TheCommandPart = CM_MakeSubScripts Then

                            If GeekCommand.TheMessagePart.Length >= 4 Then

                                TmpIdx1 = InStr(GeekCommand.TheMessagePart, CM_Type_W)
                                TmpIdx2 = InStr(GeekCommand.TheMessagePart, CM_Type_W2)

                                If (TmpIdx1 >= 2) AndAlso (TmpIdx1 > TmpIdx2) Then 'Launch

                                    InputPrefix = GeekCommand.TheMessagePart.Substring(0, TmpIdx1 - 1)
                                    If Not Launch_Cake_Form_Prefix(InputPrefix, GeekCommand.TheMessagePart.Substring(TmpIdx1), Man_Who_LastSending) Then
                                        'MUX is full, what to do
                                    End If

                                ElseIf (TmpIdx2 >= 2) AndAlso (TmpIdx2 > TmpIdx1) Then 'Send command

                                    InputPrefix = GeekCommand.TheMessagePart.Substring(0, TmpIdx2 - 1)

                                    Dim Mux_Slot As Integer = Get_Cake_Slot_From_Prefix(InputPrefix)
                                    If Mux_Slot > -1 Then
                                        Mux(Mux_Slot).Last_Sender = Man_Who_LastSending
                                        EXE_Write_To_Console(GeekCommand.TheMessagePart.Substring(TmpIdx2), "", Mux_Slot)
                                    End If

                                End If
                            End If

                        End If

                        '=============================================== Main console Command Detect ==========================

                        Select Case GeekCommand.TheCommandPart

                            Case CM_Type_W 'Output to main console, console w back

                                If Not Mux(0).Is_Working Then Start_EXE_Process(Man_EXE_FirstExec, 0, "Main", Man_Who_LastSending)

                                If Queued_EXE_Command_Enable = True Then

                                    If Queued_EXE_Command_StoredIDX = Queued_EXE_MAX_depth Then
                                        If Queued_EXE_Command(0) = "" Then
                                            Queued_EXE_Command_StoredIDX = 0
                                            Queued_EXE_Command(Queued_EXE_Command_StoredIDX) = GeekCommand.TheMessagePart
                                            Queued_EXE_Command_Sender(Queued_EXE_Command_StoredIDX) = Man_Who_LastSending
                                        End If
                                    Else
                                        If Queued_EXE_Command(Queued_EXE_Command_StoredIDX + 1) = "" Then
                                            Queued_EXE_Command_StoredIDX += 1
                                            Queued_EXE_Command(Queued_EXE_Command_StoredIDX) = GeekCommand.TheMessagePart
                                            Queued_EXE_Command_Sender(Queued_EXE_Command_StoredIDX) = Man_Who_LastSending
                                        End If
                                    End If

                                Else
                                    Mux(0).Last_Sender = Man_Who_LastSending
                                    EXE_Write_To_Console(GeekCommand.TheMessagePart, "", 0)
                                End If

                            Case CM_Type_W2

                                If Not Mux(0).Is_Working Then Start_EXE_Process(Man_EXE_FirstExec, 0, "Main", Man_Who_LastSending)
                                Mux(0).Last_Sender = Man_Who_LastSending
                                EXE_Write_To_Console(GeekCommand.TheMessagePart, "", 0)

                            Case CM_Type_VarWri 'Var Write

                                If GeekCommand.TheMessagePart.Length > 2 Then
                                    If GeekCommand.TheMessagePart.Substring(1, 1) = ";" Then
                                        variableString(Val(GeekCommand.TheMessagePart.Substring(0, 1))) = GeekCommand.TheMessagePart.Substring(2)
                                    End If
                                ElseIf GeekCommand.TheMessagePart.Length > 1 Then
                                    variableString(Val(GeekCommand.TheMessagePart.Substring(0, 1))) = ""
                                End If

                            Case CM_ServerState_Flag

                                If GeekCommand.TheMessagePart.Length >= 6 Then
                                    If GeekCommand.TheMessagePart.Substring(0, 5).ToUpper = "KILL;" Then
                                        Dim TmpWorkStr As String = GeekCommand.TheMessagePart.Substring(5)
                                        For TmpIdx1 = 1 To 9
                                            If (Mux(TmpIdx1).Script_Specify_Prefix = TmpWorkStr) OrElse (Mux(TmpIdx1).Alias_Specify_Prefix = TmpWorkStr) Then
                                                Kill_EXE_Console_ByMux(TmpIdx1)
                                            End If
                                        Next
                                    End If
                                End If

                                Select Case GeekCommand.TheMessagePart.ToUpper
                                    Case "RSTC"
                                        Restart_EXEConsole(Man_Who_LastSending)
                                    Case "KILLMUX"
                                        Kill_All_Mux_Console()
                                    Case "SHOWMUX"
                                        For TmpIdx1 = 0 To 9
                                            If Mux(TmpIdx1).Is_Working Then
                                                Write_To_Console("say (" + TmpIdx1.ToString + ")SSP:" + Mux(TmpIdx1).Script_Specify_Prefix +
                                                                    ";ASP:" + Mux(TmpIdx1).Alias_Specify_Prefix + ";")
                                            End If
                                        Next
                                    Case Else
                                        Get_Full_MCServer_Control(GeekCommand.TheMessagePart)
                                End Select
                                Exit Do
                            Case Else

                                Exit Do

                        End Select

                    Else

                        Exit Do

                    End If

                ElseIf MC_Server_WorkState = 1 Then

                    If (MCServerType = "Vanilla (or ND)") OrElse (MCServerType = "CraftBukkit") Then 'Server type detect
                        MCServerType = GetServerBrand(Tmp_String, MCServerType)
                    End If

                    If InStr(Tmp_String, "]: DONE") > 5 Then 'Start detect
                        MC_Server_WorkState = 2
                        Exit Do
                    End If

                End If

                Exit Do
            Loop

        End If

    End Sub
    Public Sub Write_To_Console(Write_Str_Data As String)

        If MC_Server_WorkState <> 2 Then Exit Sub
        If Write_Str_Data.ToUpper = "STOP" Then InNeed_Detect_AbnormalEnd = False

        myStreamWriter = MC_Process.StandardInput
        myStreamWriter.WriteLine(Write_Str_Data)

    End Sub

    Private Sub ExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        MC_Server_WorkState = 0
        MCS_Richtexbox.Text += "Minecraft Server Is Stopped." + vbCrLf

    End Sub

    Private Function Start_Server_Backup_Process(The_Arguments As String, The_FileName As String, TimeFormatReplace As String) As String

        If MC_Server_WorkState <> 0 Then Return "NOT-OFF"

        MCS_Richtexbox.Text = "Starting Minecraft Server Backup..."
        Start_Server_Backup_Process = ""
        Add_to_NoteListbox("Start_Server_Backup_Process()")

        Try

            If Not My.Computer.FileSystem.FileExists(ZIP_EXE_Location) Then
                MCS_Richtexbox.Text += vbCrLf + "Backup / Compressor progarm Not present. Please setup first."
                Start_Server_Backup_Process = "NEED-SETUP"
                Exit Function
            End If

            MC_Server_WorkState = 1
            Directory.SetCurrentDirectory(My.Computer.FileSystem.GetFileInfo(The_FileName).DirectoryName)

            StartButton.Enabled = False
            BackupButton.Enabled = False
            My.Application.DoEvents()

            ReDim Saved_String2(Saved_String_Max2)
            Saved_String2(0) = "Starting Minecraft Server Backup..." + vbCrLf
            Saved_String_IDX2 = 1

            ZIP_Process = New System.Diagnostics.Process()

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
            AddHandler ZIP_Process.ErrorDataReceived, AddressOf OutputHandler 'ErrOutputHandler
            AddHandler ZIP_Process.Exited, AddressOf ZipExitHandler

            My.Application.DoEvents()

            ZIP_Process.Start()
            ZIP_Process.BeginOutputReadLine()
            ZIP_Process.BeginErrorReadLine()

            ZIP_IS_LAUNCHED = True
            Start_Server_Backup_Process = "OK"

        Catch ex As Exception

            MC_Server_WorkState = 0
            MCS_Richtexbox.Text += vbCrLf + ex.Message + vbCrLf
            Start_Server_Backup_Process = "Error"
            Add_to_NoteListbox("Start_Server_Backup_Process():" + ex.Message)
        End Try

    End Function
    Private Sub ZipExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        MC_Server_WorkState = 0
        MCS_Richtexbox.Text += "Backup process End." + vbCrLf

    End Sub

    Private Function Start_EXE_Process(The_Arguments As String, Mux_Slot As Integer, Default_Script_Prefix As String, The_Launcher As String) As String

        Start_EXE_Process = ""
        Clear_EXE_Queue(True)
        Add_to_NoteListbox("Start_EXE_Process(" + The_Arguments + "," + Mux_Slot.ToString + "," + Default_Script_Prefix + ")")

        Try

            If The_Arguments IsNot Nothing Then
                If The_Arguments <> "" Then
                    If Mux_Slot = 0 Then
                        The_Arguments = Console_Main_Arguments.Trim + " " + The_Arguments
                    Else
                        The_Arguments = Console_Mux_Arguments.Trim + " " + The_Arguments
                    End If
                End If
            End If

            '===================== Main script console
            If Mux_Slot = 0 Then
                'detect main script console working folder 
                If SerWorkingDir = "" Then SerWorkingDir = GSet_Jar_as_Work_folder(MCServer_JAR_BAT_Location, True)
                ExeWorkingDir = SerWorkingDir
                EXEWorkingPath_TextBox.Text = ExeWorkingDir

                If ExeWorkingDir = "" Then
                    EXE_Textbox.Text = "Main scrtipt console will not start-up until the server setup done."
                    Return "NEED-SETUP"
                End If
            End If

            Mux(Mux_Slot).Script_Process = New System.Diagnostics.Process()

            With Mux(Mux_Slot).Script_Process.StartInfo
                .WorkingDirectory = ExeWorkingDir
                .FileName = Console_Shell_Exec
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .Arguments = The_Arguments
                '.StandardOutputEncoding = Encoding.UTF8
                '.StandardErrorEncoding = Encoding.UTF8 
            End With

            Mux(Mux_Slot).Script_Process.EnableRaisingEvents = True
            Mux(Mux_Slot).Script_Process.SynchronizingObject = Me

            AddHandler Mux(Mux_Slot).Script_Process.OutputDataReceived, AddressOf EXE_OutputHandler
            AddHandler Mux(Mux_Slot).Script_Process.ErrorDataReceived, AddressOf EXE_OutputHandler
            AddHandler Mux(Mux_Slot).Script_Process.Exited, AddressOf EXE_ExitHandler

            My.Application.DoEvents()

            Mux(Mux_Slot).Script_Process.Start()
            Mux(Mux_Slot).Script_Process.BeginOutputReadLine()
            Mux(Mux_Slot).Script_Process.BeginErrorReadLine()

            Mux(Mux_Slot).Is_Working = True
            Mux(Mux_Slot).Work_start_ticket = DateDiff(DateInterval.Second, New Date(2010, 1, 1, 12, 0, 0), Now)
            Mux(Mux_Slot).PID = Mux(Mux_Slot).Script_Process.Id
            Mux(Mux_Slot).Script_Specify_Prefix = Default_Script_Prefix
            Mux(Mux_Slot).Alias_Specify_Prefix = Default_Script_Prefix
            Mux(Mux_Slot).Script_Exec_Total_String = The_Arguments 'not need?
            Mux(Mux_Slot).The_Cake_Var = ""
            Mux(Mux_Slot).Last_Sender = The_Launcher
            Mux(Mux_Slot).The_Launcher = The_Launcher

            Start_EXE_Process = "OK"

        Catch ex As Exception

            EXE_Textbox.Text += vbCrLf + ex.Message + vbCrLf

            Start_EXE_Process = "Error"
            Add_to_NoteListbox("Start_EXE_Process(" + The_Arguments + "," + Mux_Slot.ToString + "," + Default_Script_Prefix + "):" + ex.Message)

            ClearCake(Mux_Slot)
            Return -2

        End Try

    End Function

    Sub EXE_OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)

        If Not String.IsNullOrEmpty(outLine.Data) Then

            Dim Mux_Slot As Integer = Get_Cake_Slot_From_PID(sendingProcess.Id)
            If Mux_Slot < 0 Then Exit Sub

            Dim Logging_Mark As String = "(" + Now.ToString("yyMMdd-hhmmss") + " " + Mux_Slot.ToString + " " + Mux(Mux_Slot).Script_Specify_Prefix + ") "
            Dim Return_PreFix As String = ""

            Dim Tmp_String_Org As String = outLine.Data

            'EXE_BoxRefreshTimer.Enabled = False
            'My.Application.DoEvents()

            '===================================== EXE Console Text Buffer (Full buffer)
            EXE_Saved_String2(EXE_Saved_String_IDX2) = Logging_Mark + Tmp_String_Org + vbCrLf 'Full buffer
            If EXE_Saved_String_IDX2 >= EXE_Saved_String_Max2 Then
                EXE_Saved_String_IDX2 = 0
            Else
                EXE_Saved_String_IDX2 += 1
            End If

            '==================== MC + injection ==========================
            If Tmp_String_Org.Substring(0, 1) = "*" Then
                If Tmp_String_Org.Length > 3 Then
                    Dim TmpIDX01 As Integer = InStr(Tmp_String_Org, "~")
                    If TmpIDX01 > 0 Then
                        Return_PreFix = Tmp_String_Org.Substring(1, TmpIDX01 - 2) + "*"
                        Tmp_String_Org = Tmp_String_Org.Substring(TmpIDX01 - 1)
                    End If
                End If
            End If
            '==================== MC + injection end ==========================

            If Tmp_String_Org.Substring(0, 1) = "~" Then

                If Tmp_String_Org.Length >= 5 Then

                    Dim Command_Mode As String = Tmp_String_Org.ToLower.Substring(2, 2)
                    Dim Command_Str As String = Tmp_String_Org.Substring(5)

                    'Get xxx Command
                    If Tmp_String_Org.Substring(1, 1) = CM_ServerGetFlag Then
                        If Tmp_String_Org.Substring(4, 1) = ";" Then
                            Process_Get_Command(Command_Mode, Command_Str, 1, Mux_Slot, Return_PreFix)
                        Else
                            Command_err_ListBox.Items.Insert(0, "EXEO:" + Command_Mode + ";" + Command_Str)
                            EXE_Write_To_Console("BAD", Return_PreFix, Mux_Slot)
                        End If
                        Exit Sub
                    End If

                    'Get xxx Command NoBack
                    If Tmp_String_Org.Substring(1, 1) = CM_ServerGetFlag_NoBack Then
                        If Tmp_String_Org.Substring(4, 1) = ";" Then
                            Process_Get_Command(Command_Mode, Command_Str, 2, Mux_Slot, Return_PreFix)
                        Else
                            Command_err_ListBox.Items.Insert(0, "EXEO:" + Command_Mode + ";" + Command_Str)
                        End If
                        Exit Sub
                    End If

                    Write_To_Console(Tmp_String_Org.Substring(1))

                Else

                    Write_To_Console(Tmp_String_Org.Substring(1))

                End If

            Else

                '====================EXE foold to MC ===============
                If Man_Flood_ToEXE = 1 Then 'MC←EXE
                    If Mux_Slot = 0 Then Write_To_Console("w " + Man_Who_LastSending_wBack + " " + Tmp_String_Org)
                End If

            End If
            '==============================================

        End If

    End Sub

    Public Sub EXE_Write_To_Console(Write_Str_Data As String, ThePreFix As String, Mux_Slot As Integer)

        If Not Mux(Mux_Slot).Is_Working Then Exit Sub


        If Write_Str_Data.Length <= 256 Then

            Try
                Mux(Mux_Slot).Script_myStreamWriter = Mux(Mux_Slot).Script_Process.StandardInput
                Mux(Mux_Slot).Script_myStreamWriter.WriteLine(ThePreFix + Write_Str_Data)
            Catch ex As Exception

                Mux(Mux_Slot).Is_Working = False '??
                Add_to_NoteListbox("Write_to_Script(" + Write_Str_Data + "," + ThePreFix + "," + Mux_Slot.ToString + "):" + ex.Message)
            End Try

        Else

            Dim thread As New Threading.Thread(Sub() EXE_Write_To_Console_Thread(IARR_Return(Mux_Slot), ThePreFix, Mux_Slot))
            thread.Start()

        End If

    End Sub

    Public Sub EXE_Write_To_Console_Thread(Write_Str_Data As String, ThePreFix As String, Mux_Slot As Integer)

        Try
            Mux(Mux_Slot).Script_myStreamWriter = Mux(Mux_Slot).Script_Process.StandardInput
            Mux(Mux_Slot).Script_myStreamWriter.WriteLine(ThePreFix + Write_Str_Data)
        Catch ex As Exception
            Mux(Mux_Slot).Is_Working = False
            Add_to_NoteListbox("Write_to_Script(" + Write_Str_Data + "," + ThePreFix + "," + Mux_Slot.ToString + "):" + ex.Message)
        End Try

        'It's dirty more then political (maybe)

    End Sub

    Private Sub EXE_ExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        Dim Mux_Slot As Integer = Get_Cake_Slot_From_PID(sendingProcess.Id)
        ClearCake(Mux_Slot)

    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        If Form3.Iagree_CheckBox.Checked = False Then
            MsgBox("Need the agree to use. Please click 'Help & About'.", 0, "Confirm")
            Exit Sub
        End If

        Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter, True)

    End Sub

    Private Sub Send2MCSButton_Click(sender As Object, e As EventArgs) Handles Send2MCSButton.Click
        SendTo_Console(0)
    End Sub

    Private Sub SetupButton_Click(sender As Object, e As EventArgs) Handles SetupButton.Click
        If MC_Server_WorkState = 1 Then Exit Sub
        Form2.Show()
        Form2.BringToFront()
    End Sub

    Private Sub Abnormal_WorkStop()
        InNeed_Detect_AbnormalEnd = False
        Det_AE_Times += 1

        Try
            If Det_AE_Run <> "" Then

                Dim RunAE As New ProcessStartInfo()
                Dim TmpRAEstr As String = Replace(Det_AE_RunPara, "$TIME$", Now.ToString(DAE_TIME_Format))
                TmpRAEstr = Replace(TmpRAEstr, "$FAIL$", Det_AE_Times.ToString)
                RunAE.FileName = Det_AE_Run
                RunAE.Arguments = TmpRAEstr
                Process.Start(RunAE)

            End If
        Catch ex As Exception
            Add_to_NoteListbox("Abnormal_WorkStop():" + ex.Message)
        End Try
    End Sub
    Private Sub MCServerRefreshTimer_Tick(sender As Object, e As EventArgs) Handles MCServerRefreshTimer.Tick

        If ReallyClose = True Then Exit Sub

        Select Case MC_Server_WorkState

            Case 0

                MCSState_Label.Text = "Minecraft Server: OFF"

                StartButton.Enabled = True
                BackupButton.Enabled = True
                WaitBLAC_Count = 0
                BusyCrash.Enabled = False
                Stop_Button.Enabled = False

                If InNeed_Detect_AbnormalEnd = True Then
                    Add_to_NoteListbox("An abnormal stop has detected. It's " + (Det_AE_Times + 1).ToString + " times")
                    Abnormal_WorkStop()
                End If

            Case 1

                MCSState_Label.Text = "Minecraft Server: BUSY"

                StartButton.Enabled = False
                BackupButton.Enabled = False
                Stop_Button.Enabled = False

            Case 2

                MCSState_Label.Text = "Minecraft Server: ON"
                ServerType_TextBox.Text = MCServerType

                StartButton.Enabled = False
                BackupButton.Enabled = False
                Stop_Button.Enabled = True
                WaitBLAC_Count = 0
                BusyCrash.Enabled = False

                If TabControl1.SelectedIndex = 3 Then
                    Dim NowTicket As Long = GetLiveTime2(MC_Server_WorkState)
                    Dim ts As TimeSpan = TimeSpan.FromSeconds(NowTicket)
                    ServerLiveTime_Textbox.Text = NowTicket.ToString + " (" + (NowTicket \ 86400).ToString + ":" + (New DateTime(ts.Ticks)).ToString("HH:mm:ss") + ")"
                End If

        End Select

        If Mux(0).Is_Working Then
            EXECON_Stat_Label.Text = "ON"
        Else
            EXECON_Stat_Label.Text = "OFF"
        End If

        If Not Closing_Socket Then
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
                    Add_to_NoteListbox("TCP error over 10 times. socket stopped.")
                    Stop_Management_Server()
                End If
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
                ModeRC_Button.Text = "Work Mode" + vbCrLf + "Normal (0)"
                ModeRC_Button.BackColor = Color.White
            Case 1
                ModeRC_Button.Text = "Work Mode" + vbCrLf + "Pass (1)"
                ModeRC_Button.BackColor = Color.Orange
            Case 2
                ModeRC_Button.Text = "Work Mode" + vbCrLf + "Wait (2)"
                ModeRC_Button.BackColor = Color.Yellow
        End Select

        Select Case Man_Flood_ToEXE
            Case 0
                ModeExeFW_Button.BackColor = Color.White
                ModeExeFW_Button.Text = "Flood way (Main)" + vbCrLf + "MC↮Console (0)" + vbCrLf + "None"
            Case 1
                ModeExeFW_Button.BackColor = Color.LightSkyBlue
                ModeExeFW_Button.Text = "Flood way (Main)" + vbCrLf + "MC←Console (1)" + vbCrLf + "Use whisper"
            Case 2
                ModeExeFW_Button.BackColor = Color.Pink
                ModeExeFW_Button.Text = "Flood way (Main)" + vbCrLf + "MC→Console (2)" + vbCrLf + "Flooding"
        End Select

    End Sub
    Public Sub SendTo_Console(ModeSelect As Integer)

        If ModeSelect = 0 Then
            If MC_Server_WorkState <> 2 Then Exit Sub
            Write_To_Console(MCS_ConsoleTextbox.Text)
            Send2Recent(ModeSelect)(Send2IdxLast(ModeSelect)) = MCS_ConsoleTextbox.Text
            MCS_ConsoleTextbox.Text = ""
        ElseIf ModeSelect = 1 Then
            EXE_Write_To_Console(Send2Exe_TextBox.Text, "", 0)
            Send2Recent(ModeSelect)(Send2IdxLast(ModeSelect)) = Send2Exe_TextBox.Text
            Send2Exe_TextBox.Text = ""
        End If

        Send2IdxLast(ModeSelect) += 1
        If Send2IdxLast(ModeSelect) > 9 Then Send2IdxLast(ModeSelect) = 0
        Send2Idx(ModeSelect) = Send2IdxLast(ModeSelect)

    End Sub

    Private Sub CloseForm(sender As Object, ByRef e As CancelEventArgs)

        e.Cancel = False

        If MsgBox("Exit?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

            If MC_Server_WorkState = 2 Then
                MCS_ConsoleTextbox.Text = "stop"
                SendTo_Console(0)
                Dim WaitCount As Integer
                WaitPanel.Visible = True

                Do
                    My.Application.DoEvents()
                    Thread.Sleep(100)
                    WaitCount += 1
                    If MC_Server_WorkState = 0 Then
                        ALL_END()
                    End If
                Loop Until WaitCount = CloseForm_wait_ds

                WaitPanel.Visible = False
                If MsgBox("Looks like auto-shutdown is fault or take time too long." + vbCrLf + vbCrLf +
                          "Do you still want exit? ", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    ALL_END()

                End If

            ElseIf MC_Server_WorkState = 1 Then

                If MsgBox("Some missions are still working, it's will make problem if force to exit. Sure? ", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    ALL_END()
                End If

            Else
                ALL_END()
            End If
        Else

            If sender Is Me Then
                e.Cancel = True
            End If

        End If

    End Sub

    Private Sub ALL_END()

        ReallyClose = True
        Closing_Socket = True
        Stop_Management_Server()
        kill_task()

        MCServerRefreshTimer.Enabled = False

        Try
            'Me.Close()
            End
        Catch ex As Exception
            End
        End Try

    End Sub

    Private Sub MCS_ConsoleTextbox_KeyUp(sender As Object, e As KeyEventArgs) Handles MCS_ConsoleTextbox.KeyUp
        GetKeyUp(sender, e, 0)
    End Sub

    Private Sub Send2Exe_TextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles Send2Exe_TextBox.KeyUp
        GetKeyUp(sender, e, 1)
    End Sub

    Sub GetKeyUp(sender As Object, e As KeyEventArgs, FromWhich As Integer)

        Select Case e.KeyCode
            Case Keys.Enter
                SendTo_Console(FromWhich)
            Case Keys.Up
                Send2Idx(FromWhich) -= 1
                If Send2Idx(FromWhich) < 0 Then Send2Idx(FromWhich) = 9
                sender.Text = Send2Recent(FromWhich)(Send2Idx(FromWhich))
            Case Keys.Down
                Send2Idx(FromWhich) += 1
                If Send2Idx(FromWhich) > 9 Then Send2Idx(FromWhich) = 0
                sender.Text = Send2Recent(FromWhich)(Send2Idx(FromWhich))
        End Select

    End Sub

    Private Sub ManServerTimeOutTimer_Tick(sender As Object, e As EventArgs) Handles ManServerTimeOutTimer.Tick

        If Clients_Now_Max = -1 Then Exit Sub

        For Each TempClient As ClientWorker In Clients
            Try
                If TempClient.DeadTime >= 1 Then
                    TempClient.DeadTime += 1
                    If TempClient.DeadTime >= TCP_timeout_s Then
                        SendToClients("TIMEOUT", TempClient.TheSocket)
                        TempClient.IsUsing = False
                        TempClient.DeadTime = 0
                        TempClient.TheSocket.Close()
                    End If
                End If
            Catch ex As Exception
                Add_to_NoteListbox("ManServerTimeOutTimer_Tick():" + ex.Message)
            End Try
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

        If MsgBox("**WARNING** " + vbCrLf + vbCrLf + "It's will terminate all operation, " + vbCrLf + vbCrLf _
                + "and may cause some datas collapse, unsaved data lost, or other problems!!!" + vbCrLf + vbCrLf _
               + "Are you sure?", MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.No Then Exit Sub

        kill_task()

    End Sub

    Private Sub kill_task(Optional Kill_EXE_Console As Boolean = True)

        Add_to_NoteListbox("kill_task(" + Kill_EXE_Console.ToString + ")")

        Try
            If MC_IS_LAUNCHED Then
                If Not MC_Process.HasExited Then
                    InNeed_Detect_AbnormalEnd = False
                    MC_Process.Kill()
                End If
            End If
        Catch ex As Exception
            Add_to_NoteListbox("kill_task()1:" + ex.Message)
        End Try

        Try
            If ZIP_IS_LAUNCHED Then
                If Not ZIP_Process.HasExited Then
                    ZIP_Process.Kill()
                End If
            End If
        Catch ex As Exception
            Add_to_NoteListbox("kill_task()2:" + ex.Message)
        End Try

        If Kill_EXE_Console Then
            Kill_EXE_Console_ByMux(0)
        End If

        For TmpIdx As Integer = 1 To HowManyMux_Arry
            Kill_EXE_Console_ByMux(TmpIdx)
        Next

    End Sub
    Private Sub Kill_EXE_Console_ByMux(Mux_Slot As Integer)

        If Mux_Slot = 0 Then Clear_EXE_Queue(True)

        Try
            If Mux(Mux_Slot).Is_Working Then
                If Not Mux(Mux_Slot).Script_Process.HasExited Then
                    killChildrenProcessesOf(Mux(Mux_Slot).Script_Process.Id)
                    Mux(Mux_Slot).Script_Process.Kill()
                    System.Threading.Thread.Sleep(50)
                    ClearCake(Mux_Slot)
                End If
            End If
        Catch ex As Exception
            Add_to_NoteListbox("Kill_EXE_Console_ByMux():" + Mux_Slot.ToString + "," + ex.Message)
        End Try

    End Sub
    Private Sub ModeRC_Button_Click(sender As Object, e As EventArgs) Handles ModeRC_Button.Click

        FthWallMC_Server_Bypass += 1
        FthWallMC_Server_Bypass = FthWallMC_Server_Bypass Mod 3

    End Sub

    Private Sub Send2EXEButton_Click(sender As Object, e As EventArgs) Handles Send2EXE_Button.Click
        EXE_Write_To_Console(Send2Exe_TextBox.Text, "", 0)
        Send2Exe_TextBox.Text = ""
    End Sub

    Private Sub ModeCFW_Button_Click(sender As Object, e As EventArgs) Handles ModeExeFW_Button.Click

        Man_Flood_ToEXE += 1
        If Man_Flood_ToEXE = 3 Then Man_Flood_ToEXE = 0

    End Sub

    Private Sub SP1Mon_Tick(sender As Object, e As EventArgs) Handles SP1Mon.Tick

        If Man_COM_Port Is Nothing Then Exit Sub

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

    Private Sub SP1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)

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
    Private Sub HelpButton_Click(sender As Object, e As EventArgs) Handles HelpAbout_Button.Click

        'The .net component is really shitty
        Form3.Show()
        Form3.BringToFront()
        Form3.Iagree_CheckBox.Checked = IsAgree
        Form3.Help_RichTextBox.LanguageOption = RichTextBoxLanguageOptions.UIFonts
        Form3.Help_RichTextBox.Text = My.Resources.HelpResource

    End Sub
    Private Sub MCS_Richtexbox_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles MCS_Richtexbox.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form4.Show()
        Form4.BringToFront()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If ReallyClose = False Then
            CloseForm(sender, e)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Player_Login.SelectedIndexChanged
        If OneTime_A_Listbox_Act Then Exit Sub
        OneTime_A_Listbox_Act = True
        Player_Logout.ClearSelected()
        Selected_Player.Text = Player_Login.SelectedItem
        If Selected_Player.Text = "" Then Selected_Player.Text = "(none)"
        OneTime_A_Listbox_Act = False
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Player_Logout.SelectedIndexChanged
        If OneTime_A_Listbox_Act Then Exit Sub
        OneTime_A_Listbox_Act = True
        Player_Login.ClearSelected()
        Selected_Player.Text = Player_Logout.SelectedItem
        If Selected_Player.Text = "" Then Selected_Player.Text = "(none)"
        OneTime_A_Listbox_Act = False
    End Sub

    Private Sub PlayerClear()
        Player_Login.ClearSelected()
        Player_Logout.ClearSelected()
        Selected_Player.Text = "(none)"
        Player_Login.Items.Clear()
        Player_Logout.Items.Clear()
    End Sub

    Public Function ParseLogInOut(TheString As String) As Boolean

        If MC_Server_WorkState <> 2 Then Return False

        Dim TmpIDXs1, TmpIDXs2, TmpIDXs3, TmpIDXs4 As Integer
        Dim TmpStrUp As String = TheString.ToUpper
        Dim TmpResStr As String
        ParseLogInOut = False

        TmpIDXs1 = InStr(TmpStrUp, "]:")
        TmpIDXs2 = InStr(TmpStrUp, "JOINED THE GAME")
        TmpIDXs3 = InStr(TmpStrUp, "LEFT THE GAME")

        If (TmpIDXs2 > TmpIDXs1) AndAlso (TmpIDXs1 > 0) Then

            TmpResStr = TheString.Substring(TmpIDXs1 + 2, TmpIDXs2 - TmpIDXs1 - 4)

            Player_Login.Items.Add(TmpResStr)

            For TmpIDXs4 = (Player_Logout.Items.Count - 1) To 0 Step -1
                If Player_Logout.Items(TmpIDXs4) = TmpResStr Then
                    Player_Logout.Items.RemoveAt(TmpIDXs4)
                End If
            Next

            ParseLogInOut = True

        ElseIf (TmpIDXs3 > TmpIDXs1) AndAlso (TmpIDXs1 > 0) Then

            TmpResStr = TheString.Substring(TmpIDXs1 + 2, TmpIDXs3 - TmpIDXs1 - 4)

            Player_Logout.Items.Add(TmpResStr)

            For TmpIDXs4 = (Player_Login.Items.Count - 1) To 0 Step -1
                If Player_Login.Items(TmpIDXs4) = TmpResStr Then
                    Player_Login.Items.RemoveAt(TmpIDXs4)
                End If
            Next

            ParseLogInOut = True
        End If

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Selected_Player.Text <> "(none)" Then MCS_ConsoleTextbox.Text = "kick " + Selected_Player.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Selected_Player.Text <> "(none)" Then MCS_ConsoleTextbox.Text = "ban " + Selected_Player.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Selected_Player.Text <> "(none)" Then MCS_ConsoleTextbox.Text = "op " + Selected_Player.Text
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Selected_Player.Text <> "(none)" Then MCS_ConsoleTextbox.Text = "deop " + Selected_Player.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Selected_Player.Text <> "(none)" Then MCS_ConsoleTextbox.Text = "pardon " + Selected_Player.Text
    End Sub

    Private Sub BusyCrash_Tick(sender As Object, e As EventArgs) Handles BusyCrash.Tick

        If WaitBusyLongAsCrash = 0 Then
            WaitBLAC_Count = 0
            Exit Sub
        End If

        WaitBLAC_Count += 1

        If (WaitBLAC_Count * 60) > WaitBusyLongAsCrash Then
            InNeed_Detect_AbnormalEnd = False
            BusyCrash.Enabled = False
            WaitBLAC_Count = 0
            Add_to_NoteListbox("Waiting time for busy is too long, regarded as crashed and stop.")
            kill_task()
            Abnormal_WorkStop()
        End If

    End Sub

    Private Sub RestartCon_Button_Click(sender As Object, e As EventArgs) Handles RestartCon_Button.Click

        If MsgBox("Restart Console will terminate the working of console," + vbCrLf + vbCrLf +
                  "It's not a routine means, are you really want to do?", MsgBoxStyle.OkCancel, "Alert") = MsgBoxResult.Ok Then
            Restart_EXEConsole(FwmcWorker)
        End If

    End Sub

    Sub Restart_EXEConsole(Who_is_launcher As String)

        Add_to_NoteListbox("Restart_EXEConsole():Main")
        Try
            Kill_EXE_Console_ByMux(0)
            System.Threading.Thread.Sleep(100)
            Start_EXE_Process(Man_EXE_FirstExec, 0, "Main", Who_is_launcher)
        Catch ex As Exception
            Add_to_NoteListbox("Restart_EXEConsole():" + ex.Message)
        End Try

    End Sub

    Private Sub MCS_Richtexbox_TextChanged(sender As Object, e As EventArgs) Handles MCS_Richtexbox.TextChanged
        MCS_Richtexbox.SelectionStart = MCS_Richtexbox.Text.Length
        MCS_Richtexbox.ScrollToCaret()
        My.Application.DoEvents()
        MCS_Richtexbox.ScrollToCaret()
        My.Application.DoEvents()
    End Sub

    Private Sub EXE_Textbox_TextChanged(sender As Object, e As EventArgs) Handles EXE_Textbox.TextChanged
        EXE_Textbox.SelectionStart = EXE_Textbox.Text.Length
        EXE_Textbox.ScrollToCaret()
        My.Application.DoEvents()
        EXE_Textbox.ScrollToCaret()
        My.Application.DoEvents()
    End Sub

    Private Sub BoxRefreshTimer_Tick(sender As Object, e As EventArgs) Handles BoxRefreshTimer.Tick

        Dim Tmp_Index1 As Integer
        Dim LittleShowIdx As Integer

        Show_String2 = ""

        For Tmp_Index1 = Saved_String_IDX2 - 1 To 0 Step -1
            If LittleShowIdx = 47 Then Exit For
            Show_String2 = Saved_String2(Tmp_Index1) + Show_String2
            LittleShowIdx += 1
        Next
        For Tmp_Index1 = Saved_String_Max2 To Saved_String_IDX2 Step -1
            If LittleShowIdx = 47 Then Exit For
            Show_String2 = Saved_String2(Tmp_Index1) + Show_String2
            LittleShowIdx += 1
        Next

        If Show_String2 <> Show_String2_old Then
            MCS_Richtexbox.Text = Show_String2
            Show_String2_old = Show_String2
        End If

        LittleShowIdx = 0

        EXE_Show_String2 = ""
        For Tmp_Index1 = EXE_Saved_String_IDX2 - 1 To 0 Step -1
            If LittleShowIdx = 47 Then Exit For
            EXE_Show_String2 = EXE_Saved_String2(Tmp_Index1) + EXE_Show_String2
            LittleShowIdx += 1
        Next
        For Tmp_Index1 = EXE_Saved_String_Max2 To EXE_Saved_String_IDX2 Step -1
            If LittleShowIdx = 47 Then Exit For
            EXE_Show_String2 = EXE_Saved_String2(Tmp_Index1) + EXE_Show_String2
            LittleShowIdx += 1
        Next

        If EXE_Show_String2 <> EXE_Show_String2_old Then
            EXE_Textbox.Text = EXE_Show_String2
            EXE_Show_String2_old = EXE_Show_String2
        End If

        My.Application.DoEvents()

    End Sub

    Private Sub QueueEXE_RunnerTimer_Tick(sender As Object, e As EventArgs) Handles QueueEXE_RunnerTimer.Tick

        If Queued_EXE_Command_Enable = True Then Exit Sub
        If Mux(0).Is_Working = False Then Exit Sub

        Dim Queued_EXE_Command_WalkTo As Integer = (Queued_EXE_Command_WalkedIDX + 1) Mod (Queued_EXE_MAX_depth + 1)
        If Queued_EXE_Command(Queued_EXE_Command_WalkTo) <> "" Then
            EXE_Write_To_Console(Queued_EXE_Command(Queued_EXE_Command_WalkTo), "", 0)
            Mux(0).Last_Sender = Queued_EXE_Command_Sender(Queued_EXE_Command_WalkTo)
            Queued_EXE_Command_Sender(Queued_EXE_Command_WalkTo) = ""
            Queued_EXE_Command(Queued_EXE_Command_WalkTo) = ""
            Queued_EXE_Command_WalkedIDX = Queued_EXE_Command_WalkTo
        Else
            QueueEXE_RunnerTimer.Enabled = False
            Queue_TextBox.Text = "Stopped"
        End If

    End Sub

    Private Sub PauseText_Button_Click(sender As Object, e As EventArgs) Handles PauseText_Button.Click

        If BoxRefreshTimer.Enabled = True Then

            BoxRefreshTimer.Enabled = False
            For Tmp_Index1 = Saved_String_IDX2 - 1 To 0 Step -1
                Show_String2 = Saved_String2(Tmp_Index1) + Show_String2
            Next
            For Tmp_Index1 = Saved_String_Max2 To Saved_String_IDX2 Step -1
                Show_String2 = Saved_String2(Tmp_Index1) + Show_String2
            Next

            MCS_Richtexbox.Text = Show_String2

            EXE_Show_String2 = ""
            For Tmp_Index1 = EXE_Saved_String_IDX2 - 1 To 0 Step -1
                EXE_Show_String2 = EXE_Saved_String2(Tmp_Index1) + EXE_Show_String2
            Next
            For Tmp_Index1 = EXE_Saved_String_Max2 To EXE_Saved_String_IDX2 Step -1
                EXE_Show_String2 = EXE_Saved_String2(Tmp_Index1) + EXE_Show_String2
            Next
            EXE_Textbox.Text = EXE_Show_String2

            PauseText_Button.Text = "Pause Text" + vbCrLf + "(Paused)"

            My.Application.DoEvents()

            PauseText_Button.BackColor = Color.FromArgb(216, 216, 255)
        Else

            PauseText_Button.Text = "Pause Text"
            BoxRefreshTimer.Enabled = True
            PauseText_Button.BackColor = Color.FromArgb(224, 224, 224)
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        If SerWorkingPath_TextBox.Text <> "" Then
            If My.Computer.FileSystem.DirectoryExists(SerWorkingPath_TextBox.Text) Then
                Process.Start(GUI_OpenFolder, SerWorkingPath_TextBox.Text)
            End If
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If EXEWorkingPath_TextBox.Text <> "" Then
            If My.Computer.FileSystem.DirectoryExists(EXEWorkingPath_TextBox.Text) Then
                Process.Start(GUI_OpenFolder, EXEWorkingPath_TextBox.Text)
            End If
        End If

    End Sub

    Sub Add_to_NoteListbox(What_to_add As String, Optional What_to_add2 As String = "")

        Note_ListBox.Items.Insert(0, Now.ToString("(yyyyMMdd-HHmmss) ") + "----")
        Note_ListBox.Items.Insert(0, Now.ToString("(yyyyMMdd-HHmmss) ") + What_to_add)
        If What_to_add2 <> "" Then Note_ListBox.Items.Insert(0, Now.ToString("(yyyyMMdd-hhmmss) ") + What_to_add2)

        If Note_ListBox.Items.Count > 100 Then
            Note_ListBox.Items.RemoveAt(Note_ListBox.Items.Count - 1)
            Note_ListBox.Items.RemoveAt(Note_ListBox.Items.Count - 1)
            Note_ListBox.Items.RemoveAt(Note_ListBox.Items.Count - 1)
        End If

    End Sub

    Sub SP1_Init()
        Me.SP1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SP1.ReadBufferSize = 64
        Me.SP1.ReadTimeout = 1
        Me.SP1.WriteBufferSize = 16
        Me.SP1.WriteTimeout = 10
    End Sub

    Private Function Get_Cake_Slot_From_PID(Mux_PID As Integer) As Integer
        For TmpIDX As Integer = 0 To HowManyMux_Arry
            If Mux(TmpIDX).PID = Mux_PID Then
                Return TmpIDX
            End If
        Next
        Return -1
    End Function

    Private Function Get_Cake_Slot_From_Prefix(Mux_Prefix As String) As Integer
        For TmpIDX As Integer = 0 To HowManyMux_Arry
            If Mux(TmpIDX).Is_Working Then
                If (Mux(TmpIDX).Script_Specify_Prefix = Mux_Prefix) OrElse (Mux(TmpIDX).Alias_Specify_Prefix = Mux_Prefix) Then
                    Return TmpIDX
                End If
            End If
        Next
        Return -1
    End Function

    Private Function Launch_Cake_Form_Prefix(Mux_Prefix As String, Launch_Command As String, Who_is_launcher As String) As Integer

        Dim Last_Get_Idle As Integer = -1

        If (Mux_Prefix = "") Or (Launch_Command = "") Then Return -3

        For TmpIdx1 = 1 To HowManyMux_Arry

            If (Mux_Prefix = Mux(TmpIdx1).Script_Specify_Prefix) OrElse (Mux_Prefix = Mux(TmpIdx1).Alias_Specify_Prefix) Then
                Return -2
            End If

            If Not Mux(TmpIdx1).Is_Working Then
                Last_Get_Idle = TmpIdx1
            End If
        Next

        If Last_Get_Idle > -1 Then
            Start_EXE_Process(Launch_Command, Last_Get_Idle, Mux_Prefix, Who_is_launcher)
            Return 1
        Else
            Return -1
        End If

    End Function

    Private Sub ClearCake(Mux_Slot As Integer)

        If Mux_Slot = -1 Then Exit Sub
        Mux(Mux_Slot).Is_Working = False
        Mux(Mux_Slot).Work_start_ticket = 0
        Mux(Mux_Slot).PID = 0
        Mux(Mux_Slot).Script_Specify_Prefix = ""
        Mux(Mux_Slot).Script_Exec_Total_String = ""
        Mux(Mux_Slot).Alias_Specify_Prefix = ""
        Mux(Mux_Slot).The_Cake_Var = ""
        Mux(Mux_Slot).Last_Sender = ""

        'ReDim EXE_Saved_String2(EXE_Saved_String_Max2)
        'EXE_Saved_String2(0) = "Starting Console with server folder." + vbCrLf
        'EXE_Saved_String_IDX2 = 1

    End Sub

    Private Sub Kill_All_Mux_Console()

        Add_to_NoteListbox("KillAllMux()")
        For Idx01 As Integer = 1 To HowManyMux_Arry
            Kill_EXE_Console_ByMux(Idx01)
        Next

    End Sub

    Private Function Get_Var_From_Alias_Prefix(The_SPrefix As String, Read_then_Clear As Boolean) As String

        Dim Total_Str As String = ""

        For Idx01 As Integer = 0 To HowManyMux_Arry
            If Mux(Idx01).Alias_Specify_Prefix = The_SPrefix Then
                Total_Str += Mux(Idx01).The_Cake_Var + ";"
                If Read_then_Clear Then Mux(Idx01).The_Cake_Var = ""
            End If
        Next

        If Total_Str <> "" Then
            Return Total_Str
        Else
            Return "?"
        End If

    End Function

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub Kill_Mux_Con_Click(sender As Object, e As EventArgs) Handles Kill_Mux_Con.Click
        If MsgBox("**WARNING** " + vbCrLf + vbCrLf + "It's will terminate all of script mux console, " + vbCrLf + vbCrLf _
        + "and may cause some datas collapse, unsaved data lost, or other problems!!!" + vbCrLf + vbCrLf _
       + "Are you sure?", MsgBoxStyle.YesNo, "WARNING") = MsgBoxResult.No Then Exit Sub

        Kill_All_Mux_Console()
    End Sub

    Private Sub Stop_Button_Click(sender As Object, e As EventArgs) Handles Stop_Button.Click
        Write_To_Console("stop")
    End Sub

End Class

