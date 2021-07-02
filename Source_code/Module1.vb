Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Management

Module Module1

    Public Const FwmcVer As String = "1.21"

    Public Const CM_Type_W As String = "#"
    Public Const CM_Type_W2 As String = "%"
    Public Const CM_Type_VarWri As String = "$"
    Public Const CM_ServerState_Flag As String = "*"
    Public Const CM_ServerGetFlag As String = "+"
    Public Const CM_ServerGetFlag_NoBack As String = "-"
    Public Const CM_MakeSubScripts As String = "!"

    Public Const WM_VSCROLL As Integer = 277
    Public Const SB_PAGEBOTTOM As Integer = 7

    Public Const TCP_timeout_s As Integer = 21
    Public Const Get_timeout_ds As Integer = 50
    Public Const Get_timeout_ds_4WMCWroker As Integer = 100
    Public Const CloseForm_wait_ds As Integer = 200

    Public Const FwmcWorker As String = "!4WMC"
    Public Const FwmcSocketWorker As String = "!SOCKET"
    Public Const ALLSENDER As String = "!ALL"
    Public Const NASENDER As String = "!NA"
    Public Const CNSENDER As String = "!COMMAND"

    'Public Const RemoteConsoleSender As String = "@RemoteConsole"
    Public Const CommandBlockSender As String = "@CommandBlock"

    Public SeqVal As Integer = 256

    Public Structure ScriptCake
        Dim Script_Process As System.Diagnostics.Process
        'Dim Script_myStreamWriter As System.IO.StreamWriter
        Dim Is_Working As Boolean
        Dim Script_Exec_Total_String As String
        Dim PID As Integer

        Dim Script_Specify_Prefix As String
        Dim Alias_Specify_Prefix As String
        Dim Work_start_ticket As Long
        'Dim Is_Recive_Anything_RAW As Integer
        Dim The_Cake_Var As String

        Dim Last_Sender As String
        Dim Last_Sender_World As String
        Dim The_Launcher As String
    End Structure


    Public Structure GeekCommand_Rtn
        Dim TheCommandPart As String
        Dim TheMessagePart As String
        Dim IsUsable As Boolean
    End Structure

    Public Structure The4WMC_Worker_Return
        Dim The_ID_Code As String
        Dim TheReturn As String
        Dim WorkingState As Integer
        Dim WaitingCount As Integer
        Dim ReturnPrefix As String
        Dim IsSocket As Boolean
        Dim TheMuxSolt As Integer
    End Structure

    Public Structure Little_Return
        Dim Argu As String
        Dim Argu_Findwhat1 As String
        Dim Argu_Findwhat2 As String
        Dim Argu_Findwhat3 As String
        Dim TheReturn As String
        Dim ReturnPrefix As String
        Dim WorkingState As Integer
        Dim WaitingCount As Integer
        Dim IsSocket As Boolean
        Dim TheMuxSlot As Integer
    End Structure

    Public IsAgree As Boolean

    Public MCServer_JAR_BAT_Location As String
    Public MCServer_BAT_Mode As Boolean
    Public JVM_JAVA_EXE_Location As String
    Public JVM_Launch_Parameter As String
    Public MCServer_Launch_Parameter As String

    Public Man_TCP_ErrorTimes As Integer
    Public Man_Port_Number As Integer = 0
    Public Man_Port_Number_OLD As Integer
    Public Man_Password As String = "password"

    Public Man_Who_CanWork As String = "who1;who2"
    Public Man_Who_CanWorkList() As String
    Public Man_Who_CanSend As String = ""
    Public Man_Who_CanSendList() As String
    Public Man_Who_CanOrNot As Integer = 1

    Public Man_Who_LastSending As String
    Public Man_Who_LastSending_wBack As String
    Public Man_Who_LastSending_World As String
    'Public Man_ThisTime_W2Say As Boolean Abolished 
    'Public Man_Use_InJ As Boolean = True
    Public Man_EXE_FirstExec As String
    Public Man_Flood_ToEXE As Integer '0=None 1=EXE2F  2=F2EXE
    Public Man_EXE_FDFilter As String
    Public Man_EXE_FDFilterList() As String

    Public Man_COM_Port As String
    Public Man_COM_Buad As Integer = 9600
    Public Man_COM_LineEnd As Integer
    Public Man_COM_LEArry() As String = {"", vbCr, vbLf, vbCrLf}
    Public Man_COM_TxFilter As String = ""
    Public Man_COM_TxFilterList() As String

    Public ZIP_EXE_Location As String
    Public ZIP_Launch_Parameter As String
    Public ZIP_TIME_Format As String = "yyyyMMddHHmmss"

    Public InNeed_Detect_AbnormalEnd As Boolean
    Public InNeed_Detect_AbnormalEnd_PASS As Boolean
    Public Det_AE_Run As String
    Public Det_AE_RunPara As String = "$TIME$ $FAIL$"
    Public Det_AE_Times As Integer
    Public DAE_TIME_Format As String = "yyyyMMddHHmmss"

    Public EXECommand_ViaSay As Boolean
    Public EXECommand_ViaW As Boolean = True
    Public FWMCWorkerPLUGIN_ver As Single = 0
    Public Stop_Check As Boolean

    'Public BurstMode As Integer = 0
    Public Origial_Path As String

    'Detect EssentialsX Installed
    Public FthWallMC_Server_Bypass As Integer

    Public LogInlayer() As String
    Public LogOutPlayer() As String

    Public MCServerType As String = "Vanilla (or ND)"
    Public MCServerVer As String
    Public ServerStart_Tic_k As UInt64
    Public ServerStart_Tick2 As Long

    Public WaitBusyLongAsCrash As Integer
    Public WaitBLAC_Count As Integer

    'Public Return_PreFix As String = ""

    Public variableString(9) As String

    Public Local_IP_ADDR As String = "Any"

    Public Const Queued_EXE_MAX_depth = 99
    Public Queued_EXE_Command(Queued_EXE_MAX_depth) As String
    Public Queued_EXE_Command_Sender(Queued_EXE_MAX_depth) As String
    Public Queued_EXE_Command_StoredIDX As Integer = 0
    Public Queued_EXE_Command_WalkedIDX As Integer = 0
    Public Queued_EXE_Command_Enable As Boolean = False

    Public What_is_the_OS As String
    Public Console_Shell_Exec As String = "Powershell.exe"
    Public Console_Main_Arguments As String = "-NoExit -Command"
    Public Console_Mux_Arguments As String = "-Command"
    Public PDSC As String = "\"
    Public GUI_OpenFolder As String = "explorer.exe"
    Public UseANormal As Boolean

    Public UnicodeSupp As Boolean = True
    'Public DoGC As Boolean
    Public Sub Before_Save()

        MCServer_JAR_BAT_Location = Form2.JARPATH_Textbox.Text
        JVM_JAVA_EXE_Location = Form2.JVM_Textbox.Text
        JVM_Launch_Parameter = Form2.JVMPar_Textbox.Text
        MCServer_Launch_Parameter = Form2.MCSPar_Textbox.Text
        Man_Password = Form2.RCPassword_Textbox.Text
        Man_Port_Number = Form2.ManPortNum.Value

        ZIP_EXE_Location = Form2.BackupExe_Textbox.Text
        ZIP_Launch_Parameter = Form2.BackupPar_Textbox.Text
        ZIP_TIME_Format = Form2.BackupTimeS_Textbox.Text

        Man_Who_CanWork = Form2.PRIID_Textbox.Text
        Man_EXE_FirstExec = Form2.Autoexe_Textbox.Text
        Man_EXE_FDFilter = Form2.MCFilter_Textbox.Text

        Man_COM_Port = Form2.ComPortList.Text
        Man_COM_LineEnd = Form2.COMLineEnd.SelectedIndex
        Man_COM_Buad = Form2.ComPortSPD_NumericUpDown.Value
        Man_COM_TxFilter = Form2.COMFilter_Textbox.Text

        IsAgree = Form3.Iagree_CheckBox.Checked

        Det_AE_Run = Form2.DetAE_Run_TextBox.Text
        Det_AE_RunPara = Form2.DetAE_Para_TextBox.Text
        DAE_TIME_Format = Form2.DetAETimeS_Textbox.Text

        EXECommand_ViaSay = Form2.ExeViaSay_Checkbox.Checked

        Local_IP_ADDR = Form2.L_IPaddr_Combobox.SelectedItem.ToString

        WaitBusyLongAsCrash = Form2.WaitBusyLongAsCrash_NumericUpDown.Value

        Console_Shell_Exec = Form2.Console_Shell_Exec_Textbox.Text
        Console_Main_Arguments = Form2.Console_Main_Arguments_Textbox.Text
        Console_Mux_Arguments = Form2.Console_Mux_Arguments_Textbox.Text

        GUI_OpenFolder = Form2.GUI_FolderOpen_TXTBOX.Text

        Man_Who_CanOrNot = Form2.CSPID_Chk.CheckState
        Man_Who_CanSend = Form2.CSPID_Textbox.Text

        EXECommand_ViaW = Form2.CESx_CheckBox.Checked

        Stop_Check = Form2.STOP_Chk.Checked
        UseANormal = Form2.UseAN_Checkbox.Checked

        UnicodeSupp = Form2.UnicodeSup_Checkbox.Checked

        Make_List_Array()
        SaveXML()
    End Sub

    Public Sub SaveXML()

        Try
            Dim Save_XML As New XmlTextWriter(Origial_Path + PDSC + "Setting.xml", Encoding.UTF8)
            Save_XML.WriteStartDocument()
            Save_XML.Formatting = Formatting.Indented
            Save_XML.WriteStartElement("Setup")
            createNode(Save_XML, "MCServer_JAR_BAT_Location", MCServer_JAR_BAT_Location)
            createNode(Save_XML, "JVM_JAVA_EXE_Location", JVM_JAVA_EXE_Location)
            createNode(Save_XML, "JVM_Launch_Parameter", JVM_Launch_Parameter)
            createNode(Save_XML, "MCServer_Launch_Parameter", MCServer_Launch_Parameter)
            createNode(Save_XML, "Man_Port_Number", Man_Port_Number)
            createNode(Save_XML, "Man_Password", Man_Password)
            createNode(Save_XML, "Man_Who_CanWork", Man_Who_CanWork)
            createNode(Save_XML, "ZIP_EXE_Location", ZIP_EXE_Location)
            createNode(Save_XML, "ZIP_Launch_Parameter", ZIP_Launch_Parameter)
            createNode(Save_XML, "ZIP_TIME_Format", ZIP_TIME_Format)
            createNode(Save_XML, "Man_EXE_FirstExec", Man_EXE_FirstExec)
            createNode(Save_XML, "Man_COM_Port", Man_COM_Port)
            createNode(Save_XML, "Man_COM_Buad", Man_COM_Buad.ToString)
            createNode(Save_XML, "Man_COM_TxFilter", Man_COM_TxFilter)
            createNode(Save_XML, "Man_COM_LineEnd", Man_COM_LineEnd)
            createNode(Save_XML, "Man_EXE_FDFilter", Man_EXE_FDFilter)
            createNode(Save_XML, "IsAgree", IsAgree)
            createNode(Save_XML, "Det_AE_Run", Det_AE_Run)
            createNode(Save_XML, "Det_AE_RunPara", Det_AE_RunPara)
            createNode(Save_XML, "DAE_TIME_Format", DAE_TIME_Format)
            createNode(Save_XML, "WaitBusyLongAsCrash", WaitBusyLongAsCrash)
            createNode(Save_XML, "Local_IP_ADDR", Local_IP_ADDR)
            createNode(Save_XML, "Console_Shell_Exec", Console_Shell_Exec)
            createNode(Save_XML, "Console_Main_Arguments", Console_Main_Arguments)
            createNode(Save_XML, "Console_Mux_Arguments", Console_Mux_Arguments)
            createNode(Save_XML, "GUI_OpenFolder", GUI_OpenFolder)
            createNode(Save_XML, "Man_Who_CanSend", Man_Who_CanSend)
            createNode(Save_XML, "Man_Who_CanOrNot", Man_Who_CanOrNot)

            createNode(Save_XML, "EXECommand_ViaSay", EXECommand_ViaSay)
            createNode(Save_XML, "EXECommand_ViaW", EXECommand_ViaW)
            createNode(Save_XML, "Stop_Check", Stop_Check)
            createNode(Save_XML, "UseANormal", UseANormal)

            createNode(Save_XML, "UnicodeSupp", UnicodeSupp)


            Save_XML.WriteEndElement()
            Save_XML.Flush()
            My.Application.DoEvents()
            Save_XML.Close()

        Catch ex As Exception
            MsgBox("Err:", 0, ex.Message)
        End Try

    End Sub

    Public Function LoadXML(Optional LoadFile As String = "") As String

        Dim Load_XML As New XmlDocument()
        Dim TmpNode As XmlNode
        Dim LoadFile_Fin As String
        LoadXML = ""


        If LoadFile = "" Then
            LoadFile_Fin = Origial_Path + PDSC + "Setting.xml"
        Else
            If Not My.Computer.FileSystem.FileExists(LoadFile) Then
                Return "ERROR-File not exist."
            End If
            LoadFile_Fin = LoadFile
        End If

        Try

            Load_XML.Load(LoadFile_Fin)
            Dim nodes As XmlNodeList = Load_XML.DocumentElement.SelectNodes("/Setup")
            Dim Node1 As XmlNode = nodes.ItemOf(0)

            TmpNode = Node1.SelectSingleNode("MCServer_JAR_BAT_Location")
            If TmpNode IsNot Nothing Then MCServer_JAR_BAT_Location = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("JVM_JAVA_EXE_Location")
            If TmpNode IsNot Nothing Then JVM_JAVA_EXE_Location = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("JVM_Launch_Parameter")
            If TmpNode IsNot Nothing Then JVM_Launch_Parameter = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("MCServer_Launch_Parameter")
            If TmpNode IsNot Nothing Then MCServer_Launch_Parameter = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_Port_Number")
            If TmpNode IsNot Nothing Then Man_Port_Number = Val(TmpNode.InnerText)
            Man_Port_Number_OLD = Man_Port_Number

            TmpNode = Node1.SelectSingleNode("Man_Who_CanWork")
            If TmpNode IsNot Nothing Then Man_Who_CanWork = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_Password")
            If TmpNode IsNot Nothing Then Man_Password = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("ZIP_EXE_Location")
            If TmpNode IsNot Nothing Then ZIP_EXE_Location = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("ZIP_Launch_Parameter")
            If TmpNode IsNot Nothing Then ZIP_Launch_Parameter = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("ZIP_TIME_Format")
            If TmpNode IsNot Nothing Then ZIP_TIME_Format = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_EXE_FirstExec")
            If TmpNode IsNot Nothing Then Man_EXE_FirstExec = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_EXE_FDFilter")
            If TmpNode IsNot Nothing Then Man_EXE_FDFilter = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_COM_Port")
            If TmpNode IsNot Nothing Then Man_COM_Port = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_COM_Buad")
            If TmpNode IsNot Nothing Then Man_COM_Buad = Val(TmpNode.InnerText)
            If Man_COM_Buad = 0 Then Man_COM_Buad = 9600

            TmpNode = Node1.SelectSingleNode("Man_COM_TxFilter")
            If TmpNode IsNot Nothing Then Man_COM_TxFilter = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_COM_LineEnd")
            If TmpNode IsNot Nothing Then Man_COM_LineEnd = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("IsAgree")
            If TmpNode IsNot Nothing Then IsAgree = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Det_AE_Run")
            If TmpNode IsNot Nothing Then Det_AE_Run = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("EXECommand_ViaSay")
            If TmpNode IsNot Nothing Then EXECommand_ViaSay = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Det_AE_RunPara")
            If TmpNode IsNot Nothing Then Det_AE_RunPara = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("DAE_TIME_Format")
            If TmpNode IsNot Nothing Then DAE_TIME_Format = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("WaitBusyLongAsCrash")
            If TmpNode IsNot Nothing Then WaitBusyLongAsCrash = Val(TmpNode.InnerText)

            TmpNode = Node1.SelectSingleNode("Local_IP_ADDR")
            If TmpNode IsNot Nothing Then Local_IP_ADDR = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Console_Shell_Exec")
            If TmpNode IsNot Nothing Then Console_Shell_Exec = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Console_Main_Arguments")
            If TmpNode IsNot Nothing Then Console_Main_Arguments = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Console_Mux_Arguments")
            If TmpNode IsNot Nothing Then Console_Mux_Arguments = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("GUI_OpenFolder")
            If TmpNode IsNot Nothing Then GUI_OpenFolder = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_Who_CanSend")
            If TmpNode IsNot Nothing Then Man_Who_CanSend = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Man_Who_CanOrNot")
            If TmpNode IsNot Nothing Then Man_Who_CanOrNot = Val(TmpNode.InnerText)

            TmpNode = Node1.SelectSingleNode("EXECommand_ViaW")
            If TmpNode IsNot Nothing Then EXECommand_ViaW = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("Stop_Check")
            If TmpNode IsNot Nothing Then Stop_Check = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("UseANormal")
            If TmpNode IsNot Nothing Then UseANormal = TmpNode.InnerText

            TmpNode = Node1.SelectSingleNode("UnicodeSupp")
            If TmpNode IsNot Nothing Then UnicodeSupp = TmpNode.InnerText

            If Man_Who_CanWork IsNot Nothing Then
                Make_List_Array()
            Else
                ReDim Man_Who_CanWorkList(0)
                Man_Who_CanWorkList(0) = ""
            End If

        Catch ex As Exception
            LoadXML = "ERROR-" + ex.Message
        End Try

        Make_Value_In_Box()

    End Function

    Public Sub Make_Value_In_Box()

        Form2.JARPATH_Textbox.Text = MCServer_JAR_BAT_Location
        Form2.JVM_Textbox.Text = JVM_JAVA_EXE_Location
        Form2.JVMPar_Textbox.Text = JVM_Launch_Parameter
        Form2.MCSPar_Textbox.Text = MCServer_Launch_Parameter
        Form2.RCPassword_Textbox.Text = Man_Password

        Form2.BackupExe_Textbox.Text = ZIP_EXE_Location
        Form2.BackupPar_Textbox.Text = ZIP_Launch_Parameter
        Form2.BackupTimeS_Textbox.Text = ZIP_TIME_Format
        Form2.PRIID_Textbox.Text = Man_Who_CanWork
        Form2.CSPID_Textbox.Text = Man_Who_CanSend
        Form2.CSPID_Chk.CheckState = Man_Who_CanOrNot

        Form2.Autoexe_Textbox.Text = Man_EXE_FirstExec
        Form2.COMFilter_Textbox.Text = Man_COM_TxFilter
        Form2.MCFilter_Textbox.Text = Man_EXE_FDFilter

        Form2.ManPortNum.Value = Man_Port_Number

        Form2.ComPortList.Text = Man_COM_Port
        Form2.COMLineEnd.SelectedIndex = Man_COM_LineEnd
        Form2.ComPortSPD_NumericUpDown.Value = Man_COM_Buad

        Form2.DetAE_Run_TextBox.Text = Det_AE_Run
        Form2.DetAE_Para_TextBox.Text = Det_AE_RunPara
        Form2.DetAETimeS_Textbox.Text = DAE_TIME_Format

        Form2.ExeViaSay_Checkbox.Checked = EXECommand_ViaSay
        Form2.CESx_CheckBox.Checked = EXECommand_ViaW
        Form2.WaitBusyLongAsCrash_NumericUpDown.Value = WaitBusyLongAsCrash

        Form2.Console_Shell_Exec_Textbox.Text = Console_Shell_Exec
        Form2.Console_Main_Arguments_Textbox.Text = Console_Main_Arguments
        Form2.Console_Mux_Arguments_Textbox.Text = Console_Mux_Arguments
        Form2.GUI_FolderOpen_TXTBOX.Text = GUI_OpenFolder

        Form2.STOP_Chk.Checked = Stop_Check
        Form2.UseAN_Checkbox.Checked = UseANormal

        Form2.UnicodeSup_Checkbox.Checked = UnicodeSupp

        Form3.Iagree_CheckBox.Checked = IsAgree

        MakeInterface_IN_COMBOBOX()

    End Sub

    Public Sub MakeInterface_IN_COMBOBOX()

        '=======for IP
        Dim Find_In_List As Boolean = False
        For IDX01 As Integer = 0 To Form2.L_IPaddr_Combobox.Items.Count - 1
            If Form2.L_IPaddr_Combobox.Items(IDX01).ToString = Local_IP_ADDR Then
                Form2.L_IPaddr_Combobox.SelectedIndex() = IDX01
                Find_In_List = True
                Exit For
            End If
        Next

        If Not Find_In_List Then
            Form2.L_IPaddr_Combobox.SelectedIndex() = 0
            Local_IP_ADDR = "Any"
            MsgBox("Alert: The setting for local IP was disappear." + vbCrLf + vbCrLf +
                   "(Maybe caused by Network adapter change.) " + vbCrLf + vbCrLf +
                  "Now set to ""Any"". Please note.", 0, "Alert")
        End If

    End Sub

    Private Sub createNode(XMLWriter As XmlTextWriter, NodeName As String, NodeValue As String)

        XMLWriter.WriteStartElement(NodeName)
        XMLWriter.WriteString(NodeValue)
        XMLWriter.WriteEndElement()

    End Sub

    Public Function GetServerBrand(TestStr As String, OldDetect As String) As String

        Dim TestReturn As String = OldDetect

        If OldDetect <> "Paper" OrElse OldDetect <> "Spigot" Then
            If InStr(TestStr, " CRAFTBUKKIT") > 0 Then
                Return "CraftBukkit"
            End If
        End If

        If InStr(TestStr, " PAPER") > 0 Then TestReturn = "Paper"
        If InStr(TestStr, " FABRIC") > 0 Then TestReturn = "Fabric"
        If InStr(TestStr, " FORGE") > 0 Then TestReturn = "Forge"
        If InStr(TestStr, " SPIGOT") > 0 Then TestReturn = "Spigot"

        Return TestReturn

    End Function

    Public Sub Make_List_Array()

        Dim TmpString As String

        '==============================Who can Execute==================
        TmpString = Man_Who_CanWork
        If TmpString <> "" Then
            TmpString = Replace(TmpString, " ;", ";")
            TmpString = Replace(TmpString, "; ", ";")
            Man_Who_CanWorkList = TmpString.Split(CType(";", Char()), StringSplitOptions.RemoveEmptyEntries)
        Else
            ReDim Man_Who_CanWorkList(0)
            Man_Who_CanWorkList(0) = ""
        End If

        '==============================Who can send==================
        TmpString = Man_Who_CanSend
        If TmpString <> "" Then
            TmpString = Replace(TmpString, " ;", ";")
            TmpString = Replace(TmpString, "; ", ";")
            Man_Who_CanSendList = TmpString.Split(CType(";", Char()), StringSplitOptions.RemoveEmptyEntries)
        Else
            ReDim Man_Who_CanSendList(0)
            Man_Who_CanSendList(0) = ""
        End If


        If Man_COM_TxFilter <> "" Then
            Man_COM_TxFilterList = Man_COM_TxFilter.Split(CType(";", Char()), StringSplitOptions.RemoveEmptyEntries)
        Else
            Man_COM_TxFilterList = Nothing
        End If

        If Man_EXE_FDFilter <> "" Then
            Man_EXE_FDFilterList = Man_EXE_FDFilter.Split(CType(";", Char()), StringSplitOptions.RemoveEmptyEntries)
        Else
            Man_EXE_FDFilterList = Nothing
        End If

    End Sub
    Public Function Para_Go(TheString As String) As GeekCommand_Rtn

        Dim GeekCommandRtn As New GeekCommand_Rtn
        GeekCommandRtn.IsUsable = False
        'GeekCommandRtnV2.IsUsable = False

        Dim Get_AfterW As String
        Dim Get_SenderID As String
        Dim Get_SendToID As String
        Dim Get_AfterID As String
        Dim Tmp_Index1, Tmp_Index2, Tmp_Index3 As Integer
        Dim TheStringUP As String = TheString.ToUpper


        'Public EXECommand_ViaSay As Boolean
        'Public EXECommand_ViaW As Boolean
        'Public FWMCWorkerPLUGIN_ver As Single

        '========================== 4WMC Worker detect =====================
        If FWMCWorkerPLUGIN_ver > 0 Then
            Tmp_Index2 = InStr(TheStringUP, "INFO]: [4WMC-WORKER] <CMD>")
            Tmp_Index3 = InStr(TheStringUP, "INFO]: ")

            If (Tmp_Index2 > 0) AndAlso (Tmp_Index2 = Tmp_Index3) Then
                Tmp_Index2 += 26
                Tmp_Index3 = InStr(Tmp_Index2 + 1, TheString, " ")
                Get_SenderID = TheString.Substring(Tmp_Index2, Tmp_Index3 - Tmp_Index2).TrimEnd
                Get_AfterID = TheString.Substring(Tmp_Index3).TrimEnd

                If The_Man_has_right_V2(Get_SenderID) OrElse The_Man_has_Sending_right_V2(Get_SenderID, Get_AfterID) Then
                    GeekCommandRtn.TheCommandPart = Get_AfterID.Substring(0, 1)
                    GeekCommandRtn.TheMessagePart = Get_AfterID.Substring(1)
                    GeekCommandRtn.IsUsable = True
                End If
            End If
            If GeekCommandRtn.IsUsable Then Return GeekCommandRtn
        End If


        '==========================V1 detect========================
        If EXECommand_ViaW Then
            Tmp_Index2 = InStr(TheStringUP, "]:") + 3 'L=2
            Tmp_Index3 = InStr(TheStringUP, " ISSUED SERVER COMMAND: /W ") 'L=27
            If ((Tmp_Index3 > Tmp_Index2) AndAlso (TheStringUP.Length > Tmp_Index3 + 27 + 6)) Then

                Get_SenderID = TheString.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2) 'Get SenderID
                Get_AfterW = TheString.Substring(Tmp_Index3 + 26) 'Get AfterW
                Tmp_Index1 = InStr(Get_AfterW, " ") 'Get SendToID
                Get_SendToID = Get_AfterW.Substring(0, Tmp_Index1).Trim

                Get_AfterID = Get_AfterW.Substring(Tmp_Index1)
                If Get_AfterID.Length > 2 Then
                    If The_Man_has_right_V1(Get_SenderID, Get_SendToID) OrElse The_Man_has_Sending_right_V1(Get_SenderID, Get_SendToID, Get_AfterID) Then
                        GeekCommandRtn.TheCommandPart = Get_AfterID.Substring(0, 1)
                        GeekCommandRtn.TheMessagePart = Get_AfterID.Substring(1)
                        GeekCommandRtn.IsUsable = True
                    End If
                End If
            End If
            If GeekCommandRtn.IsUsable Then Return GeekCommandRtn
        End If


        '==========================V2 detect 1 ========================
        If EXECommand_ViaSay Then
            Tmp_Index2 = InStr(TheStringUP, "]: <") + 4
            Tmp_Index3 = InStr(Tmp_Index2, TheStringUP, ">")
            If (Tmp_Index3 > Tmp_Index2) AndAlso (Tmp_Index2 > 0) Then
                Get_SenderID = TheString.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)
                Get_AfterID = TheString.Substring(Tmp_Index3).Trim
                If Get_AfterID.Length > 2 Then
                    If The_Man_has_right_V2(Get_SenderID) OrElse The_Man_has_Sending_right_V2(Get_SenderID, Get_AfterID) Then
                        GeekCommandRtn.TheCommandPart = Get_AfterID.Substring(0, 1)
                        GeekCommandRtn.TheMessagePart = Get_AfterID.Substring(1)
                        GeekCommandRtn.IsUsable = True
                    End If
                End If
            End If
            If GeekCommandRtn.IsUsable Then Return GeekCommandRtn
        End If



        '==========================V2 detect 2 ========================
        If EXECommand_ViaSay Then
            Tmp_Index2 = InStr(TheStringUP, "]: [") + 4
            Tmp_Index3 = InStr(Tmp_Index2, TheStringUP, "]")
            If (Tmp_Index3 > Tmp_Index2) AndAlso (Tmp_Index2 > 0) Then
                Get_SenderID = TheString.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)
                Get_AfterID = TheString.Substring(Tmp_Index3).Trim
                If Get_AfterID.Length > 2 Then
                    If The_Man_has_right_V2(Get_SenderID) OrElse The_Man_has_Sending_right_V2(Get_SenderID, Get_AfterID) Then
                        GeekCommandRtn.TheCommandPart = Get_AfterID.Substring(0, 1)
                        GeekCommandRtn.TheMessagePart = Get_AfterID.Substring(1)
                        GeekCommandRtn.IsUsable = True
                    End If
                End If
            End If
            If GeekCommandRtn.IsUsable Then Return GeekCommandRtn
        End If


        Return GeekCommandRtn

    End Function

    Public Function LoadFontFile(FontFilePatch As String) As FontFamily

        Dim PFC As New PrivateFontCollection
        Dim IFC As New InstalledFontCollection
        Dim OutputFF As FontFamily
        Try
            PFC.AddFontFile(FontFilePatch)
            OutputFF = PFC.Families(0)
        Catch ex As Exception
            OutputFF = IFC.Families(0)
        End Try

        Return OutputFF

    End Function

    Public Function The_Man_has_right_V1(Check_Sender_String As String, Check_Sendto_String As String) As Boolean

        If (Check_Sender_String.Length >= 15) Then 'CommandBlock send all pass
            If (Check_Sender_String.Substring(0, 15) = "CommandBlock at") Then
                If (Check_Sendto_String = "CommandBlock") Then
                    Man_Who_LastSending = "@" + Replace(Check_Sender_String, " at ", ":")
                    Return True
                End If
            End If
        End If

        If Man_Who_CanWorkList(0) = "" Then Return False
        If Check_Sender_String <> Check_Sendto_String Then Return False

        For Each TestOP_List As String In Man_Who_CanWorkList
            If Check_Sender_String = TestOP_List Then  'Normal player send
                Man_Who_LastSending = Check_Sender_String
                Man_Who_LastSending_wBack = Man_Who_LastSending
                Return True
            End If
        Next

        Return False

    End Function

    Public Function The_Man_has_right_V2(Check_Sender_String As String) As Boolean

        Man_Who_LastSending_World = "?"
        Dim TMP() As String = Check_Sender_String.Split(";")
        TMP(0) = Replace(TMP(0), ";", "")

        If Check_Sender_String = ("@CommandBlock:minecart") Then
            Man_Who_LastSending = Check_Sender_String
            If UBound(TMP) = 1 Then Man_Who_LastSending_World = TMP(1)
            Return True
        End If

        If Check_Sender_String.StartsWith("@CommandBlock:") Then
            Man_Who_LastSending = TMP(0) '"@" + Replace(TMP(0), "*", "")
            If UBound(TMP) = 1 Then Man_Who_LastSending_World = TMP(1)
            Return True
        End If

        If Check_Sender_String = ("@CONSOLE") Then
            Man_Who_LastSending = Check_Sender_String
            Return True
        End If

        If Check_Sender_String = "@" Then
            Man_Who_LastSending = CommandBlockSender
            Return True
        End If

        If Man_Who_CanWorkList(0) = "" Then Return False

        For Each TestOP_List As String In Man_Who_CanWorkList
            If TMP(0) = TestOP_List Then
                Man_Who_LastSending = TMP(0)
                Man_Who_LastSending_wBack = Man_Who_LastSending
                If UBound(TMP) = 1 Then Man_Who_LastSending_World = TMP(1)
                Return True
            End If
        Next

        Return False

    End Function

    Public Function The_Man_has_Sending_right_V1(Check_Sender_String As String, Check_Sendto_String As String, TotalMessage As String) As Boolean

        If Not The_Man_has_Sending_right_MessageTest(TotalMessage) Then Return False
        If Check_Sender_String <> Check_Sendto_String Then Return False

        Dim TrueOrFalse As Boolean = False
        If Man_Who_CanOrNot = 0 Then TrueOrFalse = True
        If Man_Who_CanSendList(0) = "" Then
            If TrueOrFalse Then Man_Who_LastSending = ALLSENDER
            Return TrueOrFalse
        End If

        For Each TestOP_List As String In Man_Who_CanSendList
            If Check_Sender_String = TestOP_List Then
                If TrueOrFalse Then Man_Who_LastSending = Check_Sender_String
                Return TrueOrFalse
            End If
        Next

        If Not TrueOrFalse Then Man_Who_LastSending = Check_Sender_String
        Return Not TrueOrFalse

    End Function

    Public Function The_Man_has_Sending_right_V2(Check_Sender_String As String, TotalMessage As String) As Boolean

        If Not The_Man_has_Sending_right_MessageTest(TotalMessage) Then Return False

        Dim TrueOrFalse As Boolean = False
        If Man_Who_CanOrNot = 0 Then TrueOrFalse = True

        Man_Who_LastSending_World = "?"
        Dim TMP() As String = Check_Sender_String.Split(";")
        TMP(0) = Replace(TMP(0), ";", "")

        If Man_Who_CanSendList(0) = "" Then
            If TrueOrFalse Then
                If UBound(TMP) = 1 Then Man_Who_LastSending_World = TMP(1)
                Man_Who_LastSending = ALLSENDER
            End If
            Return TrueOrFalse
        End If

        For Each TestOP_List As String In Man_Who_CanSendList
            If TMP(0) = TestOP_List Then
                If TrueOrFalse Then
                    Man_Who_LastSending = TMP(0)
                    If UBound(TMP) = 1 Then Man_Who_LastSending_World = TMP(1)
                End If
                Return TrueOrFalse
            End If
        Next

        If Not TrueOrFalse Then Man_Who_LastSending = TMP(0)
        Return Not TrueOrFalse

    End Function


    Public Function The_Man_has_Sending_right_MessageTest(TotalMessage As String) As Boolean
        If TotalMessage.Substring(0, 1) <> CM_MakeSubScripts Then Return False
        If TotalMessage.Length <= 3 Then Return False
        Dim TmpIdx1 As Integer = InStr(TotalMessage, CM_Type_W2)
        If TmpIdx1 < 3 Then Return False
        If InStr(TotalMessage, CM_Type_W) > TmpIdx1 Then Return False
        Return True
    End Function

    Public Function Check_If_Misjudge(TheString As String) As Boolean

        'TheString = Replace(TheString, " [MINECRAFT/DEDICATEDSERVER]", "")
        If InStr(TheString, "]: * @") > 0 Then Return False
        If (InStr(TheString, "]: <") > 0) Then Return False
        If (InStr(TheString, "ISSUED SERVER COMMAND:") > 0) Then Return False
        If (InStr(TheString, "]: [") > 0) Then Return False

        Return True

    End Function

    Public Function Ticket_Return(TheString As String) As String  ', CheckTarget As String) As String

        Ticket_Return = "#Er2"

        If InStr(TheString.ToUpper, " UNKNOWN DIMENSION") > 0 Then Return "#Er4"

        Dim TMP_TICK1_IDX As Integer
        TMP_TICK1_IDX = InStr(TheString.ToUpper, " THE TIME IS ")

        If TMP_TICK1_IDX > 0 Then
            Return TheString.Substring(TMP_TICK1_IDX + 12)
        End If

    End Function

    Public Function Locate_Return(TheString As String, CheckTarget1 As String, CheckTarget2 As String) As String

        Locate_Return = "#Er2"
        If CheckTarget1 Is Nothing Then Exit Function

        Dim TheStringUp As String = TheString.ToUpper
        Dim TheStringWorking As String

        If (InStr(TheStringUp, CheckTarget1.ToUpper) > 0) Then
            If InStr(TheStringUp, " UNKNOWN ") > 0 Then
                Locate_Return = "#Er4"
            End If
        End If

        If (InStr(TheStringUp, CheckTarget2.ToUpper) > 0) Then
            If InStr(TheStringUp, "NO BIOME") > 0 Then
                Locate_Return = "#Er4"
            End If
        End If

        If InStr(TheStringUp, CheckTarget2.ToUpper) = 0 Then Exit Function

        Dim TMP_IDX, TMP_IDX2 As Integer
        TMP_IDX = InStr(TheStringUp, "INFO]: THE NEAREST ")
        If TMP_IDX = 0 Then TMP_IDX = InStr(TheStringUp, "RVER]: THE NEAREST ")

        TMP_IDX = InStr(TMP_IDX + 2, TheStringUp, "IS AT")

        If TMP_IDX > 0 Then
            If TheStringUp.Length > TMP_IDX + 20 Then
                TMP_IDX += 6
                TMP_IDX2 = InStr(TMP_IDX + 3, TheStringUp, "BLOCKS AWAY")
                If TMP_IDX2 > TMP_IDX Then
                    TheStringWorking = TheString.Substring(TMP_IDX, (TMP_IDX2 - TMP_IDX) - 1)
                    TheStringWorking = Replace(TheStringWorking, "] (", ";")
                    TheStringWorking = Replace(TheStringWorking, ",", ";")
                    TheStringWorking = Replace(TheStringWorking, " ", "")

                    Return TheStringWorking
                End If
            End If
        End If

    End Function

    Public Function RawRead_Return(TheString As String, CheckTarget As Little_Return) As String

        RawRead_Return = "#Er2"
        'If CheckTarget Is Nothing Then Exit Function

        Dim TheStringUp As String = TheString.ToUpper
        Dim TMP_IDX As Integer
        TMP_IDX = InStr(TheStringUp, "INFO]:")
        If TMP_IDX = 0 Then TMP_IDX = InStr(TheStringUp, "RVER]:")

        If CheckTarget.Argu_Findwhat3 <> "" Then
            If InStr(TheStringUp, CheckTarget.Argu_Findwhat3.ToUpper) > 0 Then
                Return "#Er4"
            End If
        End If

        If TMP_IDX > 0 Then
            If InStr(TheStringUp, CheckTarget.Argu_Findwhat1.ToUpper) > 0 Then
                If InStr(TheStringUp, CheckTarget.Argu_Findwhat2.ToUpper) > 0 Then
                    RawRead_Return = TheString.Substring(TMP_IDX + 6)
                End If
            End If
        End If

    End Function

    Public Sub What_RU_Waiting(ByRef WaitingStr As String, WaitingTimes_ds As Integer, ByRef WaitingFlag As Integer)

        Dim LoopWait As Integer = 0
        Do
            Task.Delay(100).Wait()
            My.Application.DoEvents()
            If WaitingFlag = 2 Then
                WaitingFlag = 3
                Exit Do
            End If
            LoopWait += 1
        Loop Until LoopWait = WaitingTimes_ds

        WaitingFlag = 3

    End Sub

    Public Sub Waiting_4_4WMCWorker(ByRef WaitingFor As The4WMC_Worker_Return, WaitingTimes_ds As Integer)

        Dim LoopWait As Integer = 0
        Dim WaitingTime As Integer = WaitingTimes_ds * 10
        Do
            Task.Delay(10).Wait()
            My.Application.DoEvents()
            If WaitingFor.WorkingState = 2 Then
                Exit Sub
            End If
            LoopWait += 1
        Loop Until LoopWait = WaitingTime

        WaitingFor.TheReturn = "#Er2"

    End Sub

    Public Function Get_All_MCCommand(TheString As String)

        Get_All_MCCommand = ""

        If TheString.Length > 0 Then

            Dim TMP0, TMP1 As Integer
            TMP1 = 0

            For TMP0 = 0 To TheString.Length - 2
                If TheString.Substring(TMP0, 1) = ";" Then
                    TMP1 = TMP1 + 1
                    If TMP1 = 3 Then
                        Return TheString.Substring(TMP0 + 1)
                    End If
                End If
            Next

        End If

    End Function

    Public Function Get_Full_MCServer_Control(TheString As String) As Integer

        If TheString.Length >= 2 Then

            Dim ServerSetting() As String = TheString.Split(";")
            Dim TmpIdx1, TmpIdx2 As Integer

            TmpIdx1 = UBound(ServerSetting)
            If TmpIdx1 <> 1 Then Return 0

            For TmpIdx2 = 0 To TmpIdx1
                If ServerSetting(TmpIdx2) <> "" Then
                    TmpIdx1 = Val(ServerSetting(TmpIdx2))
                    Select Case TmpIdx2
                        Case 0
                            If (TmpIdx1 >= 0) AndAlso (TmpIdx1 <= 2) Then
                                FthWallMC_Server_Bypass = TmpIdx1
                            End If
                        Case 1
                            If (TmpIdx1 >= 0) AndAlso (TmpIdx1 <= 2) Then
                                Man_Flood_ToEXE = TmpIdx1
                            End If
                    End Select
                End If
            Next

            Return 1
        Else
            Return 0
        End If

    End Function

    Public Function UnicodeBytesToString(ByVal bytes() As Byte, data_long As Integer) As String

        For idx As Integer = 0 To UBound(bytes)
            If bytes(idx) < 10 Then bytes(idx) = 32
            If bytes(idx) > 126 Then bytes(idx) = 32
        Next

        Return System.Text.Encoding.ASCII.GetString(bytes, 0, data_long)
    End Function

    Sub killChildrenProcessesOf(ByVal parentProcessId As UInt32)

        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" & parentProcessId)

        Dim Collection As ManagementObjectCollection
        Collection = searcher.Get()

        If (Collection.Count > 0) Then

            For Each item In Collection
                Dim childProcessId As Int32
                childProcessId = Convert.ToInt32(item("ProcessId"))
                If Not (childProcessId = Process.GetCurrentProcess().Id) Then

                    killChildrenProcessesOf(childProcessId)

                    Dim childProcess As Process
                    childProcess = Process.GetProcessById(childProcessId)
                    childProcess.Kill()
                End If
            Next
        End If
    End Sub

    Public Sub Get_All_IP_Addr()

        Form2.L_IPaddr_Combobox.Items.Clear()
        Form2.L_IPaddr_Combobox.Items.Add("Any")
        Form2.L_IPaddr_Combobox.Items.Add("IPv4 Any")
        Form2.L_IPaddr_Combobox.Items.Add("IPv6 Any")
        Form2.L_IPaddr_Combobox.Items.Add("127.0.0.1")
        Form2.L_IPaddr_Combobox.Items.Add("::1")

        Dim strHostName As String = Dns.GetHostName()
        Dim IPHostE As IPHostEntry = Dns.GetHostEntry(strHostName)

        For Each IP_ADDRS As IPAddress In IPHostE.AddressList
            If IP_ADDRS.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                Form2.L_IPaddr_Combobox.Items.Add(IP_ADDRS.ToString)
            ElseIf IP_ADDRS.AddressFamily = Sockets.AddressFamily.InterNetworkV6 Then

                Form2.L_IPaddr_Combobox.Items.Add(IP_ADDRS.ToString)
            End If
        Next

        Form2.L_IPaddr_Combobox.SelectedIndex = 0

    End Sub

    Public Sub Clear_EXE_Queue(QueueGoAllStop As Boolean)

        For idx00 As Integer = 0 To Queued_EXE_MAX_depth
            Queued_EXE_Command(idx00) = ""
        Next
        Queued_EXE_Command_StoredIDX = 0
        Queued_EXE_Command_WalkedIDX = 0

        If QueueGoAllStop Then
            Queued_EXE_Command_Enable = False
            Form1.QueueEXE_RunnerTimer.Enabled = False
            Form1.Queue_TextBox.Text = "Stopped"
        End If

    End Sub



    Public Function GetLiveTime2(MC_Server_WorkState As Integer) As String

        If MC_Server_WorkState <> 2 Then Return ("-1")
        If ServerStart_Tick2 = 0 Then Return ("-1")

        Dim TimeTest As Long
        TimeTest = DateDiff(DateInterval.Second, New Date(2010, 1, 1, 12, 0, 0), Now)
        Return TimeTest - ServerStart_Tick2

    End Function
    Public Sub Make_SerialPort_List()

        Dim sp2() As String = System.IO.Ports.SerialPort.GetPortNames()
        Form2.ComPortList.Items.Clear()
        Form2.ComPortList.Items.Add("OFF")
        For Each sp As String In sp2 'My.Computer.Ports.SerialPortNames
            Form2.ComPortList.Items.Add(sp)
        Next
        Form2.ComPortList.SelectedIndex = 0

    End Sub

    Public Function Test_EULA(EULA_FILE As String) As Boolean

        Try
            If Not My.Computer.FileSystem.FileExists(EULA_FILE + PDSC + "eula.txt") Then
                Return False
            End If

            Dim EULA_R As IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(EULA_FILE + PDSC + "eula.txt")
            Dim Eula_File_Str As String
            Dim Tmpidx1 As Integer

            Do Until EULA_R.EndOfStream
                Eula_File_Str = EULA_R.ReadLine
                Tmpidx1 = InStr(Eula_File_Str.ToLower, "eula=true")
                If InStr(Eula_File_Str.ToLower, "eula=true") > 0 Then
                    EULA_R.Close()
                    Return True
                End If
            Loop
            EULA_R.Close()

        Catch ex As Exception

        End Try
        Return False

    End Function

    Public Sub DetectOS_and_var()

        What_is_the_OS = Environment.OSVersion.VersionString
        PDSC = Path.DirectorySeparatorChar

        If InStr(What_is_the_OS.ToUpper, "MICROSOFT WINDOWS") > 0 Then
            Console_Shell_Exec = "Powershell.exe"
            Console_Main_Arguments = "-NoExit -Command"
            Console_Mux_Arguments = "-Command"
            GUI_OpenFolder = "explorer.exe"
        End If

    End Sub

    Public Function GSet_Jar_as_Work_folder(folder_path As String, set_self_folder As Boolean) As String

        Try
            If Not My.Computer.FileSystem.FileExists(folder_path) Then
                Return ""
            End If

            Dim SerWorkingDir As String
            SerWorkingDir = My.Computer.FileSystem.GetFileInfo(folder_path).DirectoryName
            If set_self_folder Then Directory.SetCurrentDirectory(SerWorkingDir)

            Return SerWorkingDir
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function Gen_Rnd_IDcode() As String

        'Randomize()
        Dim RndNum As New Random()
        Dim TmpStr As String
        TmpStr = Int32_to_x62(RndNum.Next(240000, 14500000))
        'TmpStr += Int32_to_x62(RndNum.Next(240000, 14500000))
        Return TmpStr

    End Function

    Public Function Int32_to_x62(InVal As Integer) As String

        Dim x62Str() As Char = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C",
        "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
        "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

        Dim OutputStr As String = ""

        Dim Tmp1, Tmp2 As Integer

        Tmp2 = InVal

        Do

            Tmp1 = Tmp2 Mod 62

            Tmp2 = (Tmp2 - Tmp1) / 62

            OutputStr = x62Str(Tmp1) + OutputStr

        Loop While Tmp2 > 0

        Return OutputStr

    End Function

End Module
