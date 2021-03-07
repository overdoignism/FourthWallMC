﻿Imports System.IO
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
    Const CM_FloodMode As String = "+"
    Const CM_ServerMode As String = "-"
    Const CM_W_SAY_CHG As String = "*"
    Const CM_BurstMode As String = "/"

    Const WM_VSCROLL As Integer = 277
    Const SB_PAGEBOTTOM As Integer = 7

    Private cpuCounter As System.Diagnostics.PerformanceCounter

    Dim MC_Process As New System.Diagnostics.Process()
    Dim ZIP_Process As New System.Diagnostics.Process()
    Dim CMD_Process As New System.Diagnostics.Process()

    Public Shared Get_Process_Error_String As String
    Public Shared ErrorHappend As Boolean

    Const Saved_String_Max As Integer = 127
    Public Shared Saved_String_IDX As Integer = 0
    Public Shared Saved_String(Saved_String_Max) As String
    Public Shared Show_String As String
    Private Delegate Sub UpdateUICB(ByVal MyText As String, ByVal c As Control)
    Public myStreamWriter As StreamWriter

    Const CMD_Saved_String_Max As Integer = 127
    Public Shared CMD_Saved_String_IDX As Integer = 0
    Public Shared CMD_Saved_String(Saved_String_Max) As String
    Public Shared CMD_Show_String As String
    Private Delegate Sub CMD_UpdateUICB(ByVal MyText As String, ByVal c As Control)
    Public CMD_myStreamWriter As StreamWriter

    Public FthWallMC_Server As Integer = 0 '0 = Offline 1 = Trying 2= Online
    Public FthWallMC_Server_TcpListerner As Sockets.TcpListener
    Public FthWallMC_Server_Bypass As Integer

    Public Clients() As ClientWorker
    Public Clients_Now_Max As Integer = -1

    Public MC_Server_WorkState As Integer = 0 ' 0=off  1=BUSY  2=on

    Public Waiting_Input As Boolean
    Public Waiting_Input_count As Integer

    Dim MC_IS_LAUNCHED As Boolean
    Dim ZIP_IS_LAUNCHED As Boolean
    Dim CMD_IS_LAUNCHED As Boolean

    Dim Reciver_Data(0) As Byte
    Dim Reciver_str_Last As String
    Dim ReallyClose As Boolean
    Dim LoadFont As Font

    'Send to Console UP+DOWN key Get recent use
    Dim Send2Recent(9) As String
    Dim Send2Idx As Integer
    Dim Send2IdxLast As Integer

    'Detect EssentialsX Installed
    Dim IsEssentialsX_Installed As Integer

    'Get the time tick
    Dim I_Asking_Tick(1) As Boolean
    Dim Time_AskMap(1) As String
    Dim Time_TickReturn(1) As String



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
            CMD_Texbox.Font = LoadFont
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
        ModeCFW_Button.Text = "CMD Flood way" + vbNewLine + "MC←CMD"
        ModeCBM_Button.Text = "CMD Back mode" + vbNewLine + """Whisper"""

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

        If FthWallMC_Server = 0 Then
            FthWallMC_Server = 1
            Try
                FthWallMC_Server_TcpListerner = New Sockets.TcpListener(IPAddress.Any, Man_Port_Number)
                FthWallMC_Server_TcpListerner.Start()
                Threading.ThreadPool.QueueUserWorkItem(AddressOf Handler_Client)
                FthWallMC_Server = 2
            Catch ex As Exception
                FthWallMC_Server = 0
            End Try
            FthWallMC_Server = 2
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
                        Case "in"
                        Case "sy"
                        Case "gt"
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

        Dim Testing As Boolean
        Process_RC_Request = 0

        If Command_Mode = "cm" Then

            Select Case Command_Str.ToLower

                Case "start"
                    If MC_Server_WorkState <> 0 Then
                        Process_RC_Request = 3
                    Else
                        SendToClients(Start_MC_Server_Process(JVM_Launch_Parameter, JVM_JAVA_EXE_Location, MCServer_JAR_BAT_Location, MCServer_Launch_Parameter), Clients(ClientIdx).TheSocket)
                    End If

                Case "backup"
                    If MC_Server_WorkState <> 0 Then
                        Process_RC_Request = 3
                    Else
                        SendToClients(Start_Server_Backup_Process(ZIP_Launch_Parameter, ZIP_EXE_Location, ZIP_TIME_Format), Clients(ClientIdx).TheSocket)
                    End If

                Case "info1"
                    If MC_Server_WorkState = 0 Then
                        SendToClients("OFF", Clients(ClientIdx).TheSocket)
                    ElseIf MC_Server_WorkState = 1 Then
                        SendToClients("BUSY", Clients(ClientIdx).TheSocket)
                    Else
                        SendToClients("ON", Clients(ClientIdx).TheSocket)
                    End If

                Case "kill"
                    kill_task()
                    SendToClients("OK", Clients(ClientIdx).TheSocket)

                Case Else
                    Testing = True

            End Select


            If Command_Str.Length = 2 And Testing = True Then

                Select Case Command_Str.Substring(0, 1)

                    Case CM_FloodMode
                        Man_Flood_ToCMD = Val(Command_Str.Substring(1, 1)) Mod 3
                        SendToClients("OK", Clients(ClientIdx).TheSocket)

                    Case CM_W_SAY_CHG
                        Man_ThisTime_W2Say = Val(Command_Str.Substring(1, 1)) Mod 2
                        SendToClients("OK", Clients(ClientIdx).TheSocket)

                    Case CM_BurstMode
                        BurstMode = Val(Command_Str.Substring(1, 1)) Mod 2
                        SendToClients("OK", Clients(ClientIdx).TheSocket)

                    Case Else
                        Process_RC_Request = 1

                End Select

            Else

                Process_RC_Request = 1

            End If

        ElseIf Command_Mode = "in" Then

            If MC_Server_WorkState = 0 Then
                Process_RC_Request = 2
            Else
                Write_To_Console(Command_Str)
                SendToClients("OK", Clients(ClientIdx).TheSocket)
            End If

        ElseIf Command_Mode = "sy" Then

            If MC_Server_WorkState = 0 Then
                Process_RC_Request = 2
            Else
                Write_To_Console("say " + Command_Str)
                SendToClients("OK", Clients(ClientIdx).TheSocket)
            End If

        ElseIf Command_Mode = "gt" Then

            Process_RC_Request = 0

            If (MC_Server_WorkState = 2) AndAlso (FthWallMC_Server_Bypass = 0) Then

                I_Asking_Tick(0) = True
                Time_TickReturn(0) = "-1"

                If IsEssentialsX_Installed = 2 Then
                    Time_AskMap(0) = Command_Str
                    Write_To_Console("time")
                Else
                    Time_AskMap(0) = Command_Str
                    Write_To_Console("execute in " + Time_AskMap(0) + " run time query daytime")
                End If

                Dim LoopWait As Integer = 0

                Do
                    Thread.Sleep(100)
                    My.Application.DoEvents()
                    If Time_TickReturn(0) <> "-1" Then Exit Do
                    LoopWait += 1
                Loop Until LoopWait = 11

                SendToClients(Time_TickReturn(0), Clients(ClientIdx).TheSocket)

                Time_TickReturn(0) = ""
                Time_AskMap(0) = ""
                I_Asking_Tick(0) = False

            ElseIf (MC_Server_WorkState = 1) OrElse (FthWallMC_Server_Bypass = 2) Then
                SendToClients("-2", Clients(ClientIdx).TheSocket) 'Busy
            Else
                SendToClients("-3", Clients(ClientIdx).TheSocket) 'Pass or error
            End If

        Else
            Process_RC_Request = 1
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
                Dim TX1 As New StreamWriter(NowClient.GetStream) 'UTF8
                TX1.Write(Data) 'WriteLine
                TX1.Flush()
                TX1.Dispose()
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
                    If Not My.Computer.FileSystem.FileExists(The_FileName) Then
                        MCS_Richtexbox.Text += vbNewLine + "JVM java.exe not present. Please setup first."
                        Start_MC_Server_Process = "NEED-SETUP"
                        Exit Function
                    End If
                    Launch_File = The_FileName
                    The_Arguments = The_JAVA_Arguments + " -jar " + """" + The_JAR_BAT_File + """ " + The_MC_Arguments
                    MCServer_BAT_Mode = False
                End If
            End If

            Directory.SetCurrentDirectory(My.Computer.FileSystem.GetFileInfo(MCServer_JAR_BAT_Location).DirectoryName)


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
            Loop Until cpuCounter IsNot Nothing


            MCServer_CPU_Peak = 0
            MCServer_RAM_Peak = 0
            MCServer_CPU_Wait = 0
            MC_Server_WorkState = 1
            Start_MC_Server_Process = "OK"

        Catch ex As Exception

            MC_Server_WorkState = 0
            MCS_Richtexbox.Text += vbNewLine + ex.Message + vbNewLine
            Start_MC_Server_Process = "ERROR"

        End Try


        'Start CMD here
        Start_CMD_Process(Man_CMD_FirstExec)

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

            '=============Ask tick command from RC=========Start
            For TickTestIdx As Integer = 0 To 1
                If I_Asking_Tick(TickTestIdx) Then
                    If InStr(Tmp_String, "INFO]: * @") = 0 Then
                        If (InStr(Tmp_String, "INFO]: <") = 0) AndAlso (InStr(Tmp_String, "INFO]: [") = 0) Then
                            Dim TMP_TICK1_IDX As Integer
                            If IsEssentialsX_Installed = 2 Then
                                If InStr(Tmp_String_Org, Time_AskMap(TickTestIdx) + " ") > 0 Then
                                    TMP_TICK1_IDX = InStr(Tmp_String, " TICKS")
                                    If TMP_TICK1_IDX > 0 Then
                                        Dim TMP_TICK2_IDX As Integer = InStrRev(Tmp_String, " ", TMP_TICK1_IDX - 1)
                                        If TMP_TICK2_IDX > 0 AndAlso TMP_TICK1_IDX > TMP_TICK2_IDX Then
                                            Time_TickReturn(TickTestIdx) = Tmp_String_Org.Substring(TMP_TICK2_IDX, TMP_TICK1_IDX - TMP_TICK2_IDX)
                                        End If
                                    End If
                                End If
                            Else
                                TMP_TICK1_IDX = InStr(Tmp_String, " THE TIME IS ")
                                If TMP_TICK1_IDX > 0 Then
                                    Time_TickReturn(TickTestIdx) = Tmp_String_Org.Substring(TMP_TICK1_IDX + 12)
                                End If
                            End If

                        End If
                    End If
                End If
            Next
            '=============Ask tick command from RC=========End


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

            '================Flood To CMD=============MC→CMD
            If Man_Flood_ToCMD = 2 Then
                If Man_CMD_FDFilterList IsNot Nothing Then
                    For Each Tmp_String2 In Man_CMD_FDFilterList
                        If InStr(Tmp_String_Org, Tmp_String2) > 0 Then
                            CMD_Write_To_Console(Tmp_String_Org)
                            Exit For
                        End If
                    Next
                Else
                    CMD_Write_To_Console(Tmp_String_Org)
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
                    'W I #x (+5

                    If ((Tmp_Index3 > Tmp_Index2) AndAlso (Tmp_String.Length > Tmp_Index3 + 27 + 6)) Then

                        'Get SenderID
                        Get_SenderID = Tmp_String_Org.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)

                        'Get AfterW
                        Get_AfterW = Tmp_String_Org.Substring(Tmp_Index3 + 26)

                        'Get SendToID
                        Dim TmpVal1 As Integer = InStr(Get_AfterW, " ")
                        Get_SendToID = Get_AfterW.Substring(0, TmpVal1).Trim

                        '[15:39:38] [Server thread/INFO]: CommandBlock at 38,63,-42 issued server command: /w CommandBlock at #4WMC-MugenRailway 38 64 -42 S

                        'Check Man Right
                        If Not The_Man_has_right(Get_SenderID, Get_SendToID) Then Exit Do

                        'ElseIf (Get_SenderID.Length > 15) AndAlso (Get_SenderID.Substring(0, 15) = "CommandBlock at") Then
                        '        If Get_SendToID = "CommandBlock" Then
                        '            Man_Who_LastSending = "CONSOLE"
                        '        Else
                        '            Exit Do
                        '        End If
                        '    ElseIf (Get_SenderID.Length >= 15) AndAlso (Man_CBAT_Workable = True) Then
                        '        If Get_SenderID.Substring(0, 15) = "CommandBlock at" Then
                        '            If Get_SendToID = "CommandBlock" Then
                        '                Man_Who_LastSending = "CONSOLE"
                        '            Else
                        '                Exit Do
                        '            End If
                        '        Else
                        '            Exit Do
                        '        End If
                        '    Else
                        '        Exit Do
                        '    End If

                        'Get AfterID
                        Get_AfterID = Get_AfterW.Substring(TmpVal1)
                        If Get_AfterID.Length <= 1 Then Exit Do
                        Get_TypeCommand = Get_AfterID.Substring(0, 1)
                        Get_Message = Get_AfterID.Substring(1)

                        Select Case Get_TypeCommand

                            Case CM_Type_W 'Output to CMD, CMD w back

                                If Not CMD_IS_LAUNCHED Then
                                    Start_CMD_Process(Man_CMD_FirstExec)
                                End If

                                Man_ThisTime_W2Say = False
                                CMD_Write_To_Console(Get_Message)

                            Case CM_Type_SAY 'Output to CMD, CMD say back

                                If Not CMD_IS_LAUNCHED Then
                                    Start_CMD_Process(Man_CMD_FirstExec)
                                End If

                                Man_ThisTime_W2Say = True
                                CMD_Write_To_Console(Get_Message)

                            Case CM_FloodMode 'Flood to CMD

                                Select Case Val(Get_Message)
                                    Case 0
                                        Man_Flood_ToCMD = 0
                                    Case 1
                                        Man_Flood_ToCMD = 1
                                    Case 2
                                        Man_Flood_ToCMD = 2
                                End Select

                            Case CM_ServerMode 'working mode swtch

                                Select Case Val(Get_Message)
                                    Case 0
                                        FthWallMC_Server_Bypass = 0
                                    Case 1
                                        FthWallMC_Server_Bypass = 1
                                    Case 2
                                        FthWallMC_Server_Bypass = 2
                                End Select

                            Case CM_W_SAY_CHG 'working mode swtch

                                Select Case Val(Get_Message)
                                    Case 0
                                        Man_ThisTime_W2Say = False
                                    Case 1
                                        Man_ThisTime_W2Say = True
                                End Select


                            Case CM_BurstMode 'BurstMode

                                Select Case Val(Get_Message)
                                    Case 0
                                        BurstMode = 0
                                    Case 1
                                        BurstMode = 1
                                End Select

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
            MC_Server_WorkState = 1

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

    Private Function Start_CMD_Process(FirstExec As String) As String

        Start_CMD_Process = ""

        Try

            CMD_Process = New System.Diagnostics.Process()

            ErrorHappend = False

            With CMD_Process.StartInfo
                .WorkingDirectory = ""
                .FileName = "cmd.exe"
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .RedirectStandardInput = True
                .UseShellExecute = False
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .Arguments = "/k " + FirstExec
            End With

            CMD_Process.EnableRaisingEvents = True
            CMD_Process.SynchronizingObject = Me

            AddHandler CMD_Process.OutputDataReceived, AddressOf CMD_OutputHandler
            AddHandler CMD_Process.ErrorDataReceived, AddressOf CMD_OutputHandler
            AddHandler CMD_Process.Exited, AddressOf CMD_ExitHandler

            My.Application.DoEvents()

            CMD_Process.Start()
            CMD_Process.BeginOutputReadLine()
            CMD_Process.BeginErrorReadLine()

            CMD_IS_LAUNCHED = True
            Send2CMDButton.Enabled = True
            TextBox3.Enabled = True
            Start_CMD_Process = "OK"

        Catch ex As Exception

            CMD_Texbox.Text += vbNewLine + ex.Message + vbNewLine
            Start_CMD_Process = "Error"

        End Try


    End Function

    Private Sub CMD_UpdateUI(ByVal MyText As String, ByVal c As Control)

        If InvokeRequired() Then

            Dim cb As New CMD_UpdateUICB(AddressOf CMD_UpdateUI)
            Me.Invoke(cb, MyText, c)

        Else
            c.Text = MyText
        End If

    End Sub

    Sub CMD_OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)

        If Not String.IsNullOrEmpty(outLine.Data) Then

            Dim Tmp_String_Org As String = outLine.Data
            Dim Tmp_Index1 As Integer

            '===================================== CMD Console Text Buffer

            CMD_Saved_String(CMD_Saved_String_IDX) = Tmp_String_Org + vbNewLine

            If CMD_Saved_String_IDX >= CMD_Saved_String_Max Then
                CMD_Saved_String_IDX = 0
            Else
                CMD_Saved_String_IDX += 1
            End If

            '===================================== CMD Console Text Buffer show up

            If BurstMode = 0 Then

                CMD_Show_String = ""

                For Tmp_Index1 = Saved_String_IDX To CMD_Saved_String_Max
                    CMD_Show_String += CMD_Saved_String(Tmp_Index1)
                Next

                For Tmp_Index1 = 0 To CMD_Saved_String_IDX - 1
                    CMD_Show_String += CMD_Saved_String(Tmp_Index1)
                Next


                CMDBoxRefreshTimer.Enabled = False
                CMD_UpdateUI(CMD_Show_String, CMD_Texbox)
                CMDBoxRefreshTimer.Enabled = True

            End If

            '====================================

            If MC_Server_WorkState = 2 Then

                '====================CMD foold to MC + injection
                If Man_Use_InJ AndAlso Tmp_String_Org.Substring(0, 1) = "~" Then

                    If Tmp_String_Org.Length = 3 Then

                        Select Case Tmp_String_Org.Substring(1, 1)

                            Case CM_FloodMode

                                Select Case Tmp_String_Org.Substring(2, 1)
                                    Case 0
                                        Man_Flood_ToCMD = 0
                                    Case 1
                                        Man_Flood_ToCMD = 1
                                    Case 2
                                        Man_Flood_ToCMD = 2
                                End Select

                            Case CM_ServerMode

                                Select Case Tmp_String_Org.Substring(2, 1)
                                    Case 0
                                        FthWallMC_Server_Bypass = 0
                                    Case 1
                                        FthWallMC_Server_Bypass = 1
                                    Case 2
                                        FthWallMC_Server_Bypass = 2
                                End Select

                            Case CM_W_SAY_CHG

                                Select Case Tmp_String_Org.Substring(2, 1)
                                    Case 0
                                        Man_ThisTime_W2Say = False
                                    Case 1
                                        Man_ThisTime_W2Say = True
                                End Select

                            Case CM_BurstMode

                                Select Case Tmp_String_Org.Substring(2, 1)
                                    Case 0
                                        BurstMode = 0
                                    Case 1
                                        BurstMode = 1
                                End Select

                            Case Else

                                Write_To_Console(Tmp_String_Org.Substring(1))

                        End Select

                    ElseIf Tmp_String_Org.Length > 4 Then

                        If Tmp_String_Org.Substring(0, 4).ToUpper = "~GT," Then

                            I_Asking_Tick(1) = True
                            Time_TickReturn(1) = "-1"
                            Time_AskMap(1) = Tmp_String_Org.Substring(4)

                            If IsEssentialsX_Installed = 2 Then
                                Write_To_Console("time")
                            Else
                                Write_To_Console("execute in " + Time_AskMap(1) + " run time query daytime")
                            End If

                            Dim LoopWait As Integer = 0

                            Do
                                Thread.Sleep(100)
                                My.Application.DoEvents()
                                If Time_TickReturn(1) <> "-1" Then Exit Do
                                LoopWait += 1
                            Loop Until LoopWait = 11

                            CMD_Write_To_Console(Time_TickReturn(1))

                            Time_TickReturn(1) = ""
                            Time_AskMap(1) = ""
                            I_Asking_Tick(1) = False

                        Else

                            Write_To_Console(Tmp_String_Org.Substring(1))

                        End If

                    Else

                        Write_To_Console(Tmp_String_Org.Substring(1))

                    End If

                Else

                    If Man_Flood_ToCMD = 1 Then 'MC←CMD

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

    Public Sub CMD_Write_To_Console(Write_Str_Data As String)

        If Not CMD_IS_LAUNCHED Then Exit Sub

        CMD_myStreamWriter = CMD_Process.StandardInput
        CMD_myStreamWriter.WriteLine(Write_Str_Data)

    End Sub

    Private Sub CMD_ExitHandler(sendingProcess As Object, ByVal e As System.EventArgs)

        CMD_IS_LAUNCHED = False
        Send2CMDButton.Enabled = False
        TextBox3.Enabled = False

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

        Select Case Man_Flood_ToCMD

            Case 0, 2

                If Man_Flood_ToCMD = 0 Then
                    ModeCFW_Button.BackColor = Color.White
                    ModeCFW_Button.Text = "CMD Flood way" + vbNewLine + "MC↮CMD"
                Else
                    ModeCFW_Button.BackColor = Color.Pink
                    ModeCFW_Button.Text = "CMD Flood way" + vbNewLine + "MC→CMD"
                End If

                ModeCBM_Button.BackColor = Color.Gray
                Select Case Man_ThisTime_W2Say
                    Case False
                        ModeCBM_Button.Text = "MC←CMD use" + vbNewLine + """Whisper"" (N/A)"
                    Case True
                        ModeCBM_Button.Text = "MC←CMD use" + vbNewLine + """Say"" (N/A)"
                End Select

            Case 1

                ModeCFW_Button.BackColor = Color.LightSkyBlue
                ModeCFW_Button.Text = "CMD Flood way" + vbNewLine + "MC←CMD"

                Select Case Man_ThisTime_W2Say
                    Case False
                        ModeCBM_Button.BackColor = Color.Wheat
                        ModeCBM_Button.Text = "MC←CMD use" + vbNewLine + """Whisper"""
                    Case True
                        ModeCBM_Button.BackColor = Color.LightYellow
                        ModeCBM_Button.Text = "MC←CMD use" + vbNewLine + """Say"""
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

        Select Case IsEssentialsX_Installed
            Case 0
                EssentialsDetected.Text = "?"
            Case 1
                EssentialsDetected.Text = "NO"
            Case 2
                EssentialsDetected.Text = "YES"
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

            Case 2

                MCSState_Label.Text = "Minecraft Server: ON"

                Try

                    If Not MC_Process.HasExited Then

                        If MCServer_BAT_Mode Then

                            CPUUsage_Label.Text = "CPU: " + "N/A (using BAT)"
                            MemUsage_Label.Text = "Mem: " + "N/A (using BAT)"

                        ElseIf MC_Server_WorkState = 2 Then

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
                If TempClient.DeadTime >= 11 Then
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

    Private Sub CMDBoxRefreshTimer_Tick(sender As Object, e As EventArgs) Handles CMDBoxRefreshTimer.Tick

        SendMessage(CMD_Texbox.Handle, WM_VSCROLL, CType(SB_PAGEBOTTOM, IntPtr), IntPtr.Zero)
        CMDBoxRefreshTimer.Enabled = False

    End Sub

    Private Sub Send2CMDButton_Click(sender As Object, e As EventArgs) Handles Send2CMDButton.Click
        CMD_Write_To_Console(TextBox3.Text)
        TextBox3.Text = ""
    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        If e.KeyCode = Keys.Enter Then
            CMD_Write_To_Console(TextBox3.Text)
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub ModeCFW_Button_Click(sender As Object, e As EventArgs) Handles ModeCFW_Button.Click

        Man_Flood_ToCMD += 1
        If Man_Flood_ToCMD = 3 Then Man_Flood_ToCMD = 0

    End Sub

    Private Sub SP1Mon_Tick(sender As Object, e As EventArgs) Handles SP1Mon.Tick

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

    Private Sub ModeCBM_Button_Click(sender As Object, e As EventArgs) Handles ModeCBM_Button.Click
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
