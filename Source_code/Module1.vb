Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.Management

Module Module1

    Public Structure GeekCommand_Rtn
        Dim TheCommandPart As String
        Dim TheMessagePart As String
        Dim IsUsable As Boolean
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
    Public Man_Who_LastSending As String
    Public Man_Who_LastSending_ForCheck As String = ""
    'Public Man_ThisTime_W2Say As Boolean Abolished 
    Public Man_Use_InJ As Boolean = True
    Public Man_EXE_FirstExec As String
    Public Man_Flood_ToEXE As Integer '0=None 1=EXE2F  2=F2EXE
    Public Man_EXE_FDFilter As String
    Public Man_EXE_FDFilterList() As String
    Public Man_CBAT_Workable As Integer = 1

    Public Man_COM_Port As String
    Public Man_COM_Buad As Integer = 9600
    Public Man_COM_LineEnd As Integer
    Public Man_COM_LEArry() As String = {"", vbCr, vbLf, vbCrLf}
    Public Man_COM_TxFilter As String = ""
    Public Man_COM_TxFilterList() As String

    Public ZIP_EXE_Location As String
    Public ZIP_Launch_Parameter As String
    Public ZIP_TIME_Format As String = "yyyyMMddHHmmss"

    Public MCServer_CPU_Now As Single
    Public MCServer_CPU_Peak As Single
    Public MCServer_CPU_Wait As Integer
    Public MCServer_RAM_Now As Long
    Public MCServer_RAM_Peak As Long
    Public The_ProcessInstanceName As String

    Public InNeed_Detect_AbnormalEnd As Boolean
    Public Det_AE_Run As String
    Public Det_AE_RunPara As String = "$TIME$ $FAIL$"
    Public Det_AE_Times As Integer
    Public DAE_TIME_Format As String = "yyyyMMddHHmmss"

    Public EXECommand_ViaSay As Boolean

    'Public BurstMode As Integer = 0
    Public Origial_Path As String

    'Detect EssentialsX Installed
    Public IsEssentialsX_Installed As Integer
    Public FthWallMC_Server_Bypass As Integer

    Public LogInlayer() As String
    Public LogOutPlayer() As String

    Public MCServerType As String = "Vanilla(or not detected)"
    Public MCServerVer As String
    Public ServerStart_Tick As UInt64

    Public WaitBusyLongAsCrash As Integer
    Public WaitBLAC_Count As Integer

    Public Return_PreFix As String = ""

    Public variableString(9) As String

    Public Local_IP_ADDR As String = "Any"

    Public Const Queued_EXE_depth = 99
    Public Queued_EXE_Command(Queued_EXE_depth) As String
    Public Queued_EXE_Command_StoredIDX As Integer = 0
    Public Queued_EXE_Command_WalkedIDX As Integer = 0
    Public Queued_EXE_Command_Enable As Boolean = False

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Function GetTickCount64() As UInt64
    End Function

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

        Man_CBAT_Workable = Form2.CBlockat_CheckBox.CheckState

        Man_Who_CanWork = Form2.PRIID_Textbox.Text
        Man_Use_InJ = Form2.EXEside_Prefix_Checkbox.Checked
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

        Make_List_Array()
        SaveXML()
    End Sub

    Public Sub SaveXML()

        Try
            Dim Save_XML As New XmlTextWriter(Origial_Path + "\Setting.xml", Encoding.UTF8)
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
            createNode(Save_XML, "Man_Use_InJ", Man_Use_InJ)
            createNode(Save_XML, "Man_EXE_FirstExec", Man_EXE_FirstExec)
            createNode(Save_XML, "Man_COM_Port", Man_COM_Port)
            createNode(Save_XML, "Man_COM_Buad", Man_COM_Buad.ToString)
            createNode(Save_XML, "Man_COM_TxFilter", Man_COM_TxFilter)
            createNode(Save_XML, "Man_COM_LineEnd", Man_COM_LineEnd)
            createNode(Save_XML, "Man_EXE_FDFilter", Man_EXE_FDFilter)
            createNode(Save_XML, "IsAgree", IsAgree)
            createNode(Save_XML, "Man_CBAT_Workable", Man_CBAT_Workable)
            createNode(Save_XML, "Det_AE_Run", Det_AE_Run)
            createNode(Save_XML, "EXECommand_ViaSay", EXECommand_ViaSay)
            createNode(Save_XML, "Det_AE_RunPara", Det_AE_RunPara)
            createNode(Save_XML, "DAE_TIME_Format", DAE_TIME_Format)
            createNode(Save_XML, "WaitBusyLongAsCrash", WaitBusyLongAsCrash)
            createNode(Save_XML, "Local_IP_ADDR", Local_IP_ADDR)

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
            LoadFile_Fin = Origial_Path + "\Setting.xml"
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

            TmpNode = Node1.SelectSingleNode("Man_Use_InJ")
            If TmpNode IsNot Nothing Then Man_Use_InJ = TmpNode.InnerText

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

            TmpNode = Node1.SelectSingleNode("Man_CBAT_Workable")
            If TmpNode IsNot Nothing Then Man_CBAT_Workable = TmpNode.InnerText

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
        Form2.Autoexe_Textbox.Text = Man_EXE_FirstExec
        Form2.COMFilter_Textbox.Text = Man_COM_TxFilter
        Form2.MCFilter_Textbox.Text = Man_EXE_FDFilter
        Form2.CBlockat_CheckBox.CheckState = Man_CBAT_Workable

        Form2.ManPortNum.Value = Man_Port_Number
        Form2.EXEside_Prefix_Checkbox.Checked = Man_Use_InJ

        Form2.ComPortList.Text = Man_COM_Port
        Form2.COMLineEnd.SelectedIndex = Man_COM_LineEnd
        Form2.ComPortSPD_NumericUpDown.Value = Man_COM_Buad

        Form2.DetAE_Run_TextBox.Text = Det_AE_Run
        Form2.DetAE_Para_TextBox.Text = Det_AE_RunPara
        Form2.DetAETimeS_Textbox.Text = DAE_TIME_Format

        Form2.ExeViaSay_Checkbox.Checked = EXECommand_ViaSay
        Form2.WaitBusyLongAsCrash_NumericUpDown.Value = WaitBusyLongAsCrash

        Form3.Iagree_CheckBox.Checked = IsAgree


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
            MsgBox("Alert: The setting for local IP was disappear." + vbNewLine + vbNewLine +
                   "(Maybe caused by Network adapter change.) " + vbNewLine + vbNewLine +
                  "Now set to ""Any"". Please note.", 0, "Alert")
        End If

    End Sub

    Private Sub createNode(XMLWriter As XmlTextWriter, NodeName As String, NodeValue As String)

        XMLWriter.WriteStartElement(NodeName)
        XMLWriter.WriteString(NodeValue)
        XMLWriter.WriteEndElement()

    End Sub

    Public Function GetServerBrand(TestStr As String) As String

        If InStr(TestStr, " PAPER") > 0 Then Return "Paper"
        If InStr(TestStr, " FABRIC") > 0 Then Return "Fabric"
        If InStr(TestStr, " FORGE") > 0 Then Return "Forge"
        If InStr(TestStr, " SPIGOT") > 0 Then Return "Spigot"

        Return "Vanilla(or not detected)"

    End Function

    Public Sub Make_List_Array()

        Dim TmpString As String
        TmpString = "CONSOLE;" + Man_Who_CanWork
        TmpString = Replace(TmpString, " ;", ";")
        TmpString = Replace(TmpString, "; ", ";")
        Man_Who_CanWorkList = TmpString.Split(CType(";", Char()), StringSplitOptions.RemoveEmptyEntries)

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
    Public Function Para_Go(TheString As String, ExeViaSay As Boolean) As GeekCommand_Rtn

        Dim GeekCommandRtnV1, GeekCommandRtnV2 As New GeekCommand_Rtn
        GeekCommandRtnV1.IsUsable = False
        GeekCommandRtnV2.IsUsable = False

        Dim Get_AfterW As String
        Dim Get_SenderID As String
        Dim Get_SendToID As String
        Dim Get_AfterID As String
        Dim Tmp_Index1, Tmp_Index2, Tmp_Index3 As Integer
        Dim TheStringUP As String = TheString.ToUpper

        '==========================V1 detect========================
        Tmp_Index2 = InStr(TheStringUP, "]:") + 3 'L=2
        Tmp_Index3 = InStr(TheStringUP, " ISSUED SERVER COMMAND: /W ") 'L=27
        If ((Tmp_Index3 > Tmp_Index2) AndAlso (TheStringUP.Length > Tmp_Index3 + 27 + 6)) Then
            'Get SenderID
            Get_SenderID = TheString.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)
            'Get AfterW
            Get_AfterW = TheString.Substring(Tmp_Index3 + 26)
            'Get SendToID
            Tmp_Index1 = InStr(Get_AfterW, " ")
            Get_SendToID = Get_AfterW.Substring(0, Tmp_Index1).Trim

            If The_Man_has_right_V1(Get_SenderID, Get_SendToID) Then
                Get_AfterID = Get_AfterW.Substring(Tmp_Index1)
                If Get_AfterID.Length > 2 Then
                    GeekCommandRtnV1.TheCommandPart = Get_AfterID.Substring(0, 1)
                    GeekCommandRtnV1.TheMessagePart = Get_AfterID.Substring(1)
                    GeekCommandRtnV1.IsUsable = True
                End If
            End If
        End If

        If GeekCommandRtnV1.IsUsable Then Return GeekCommandRtnV1

        '==========================V2 detect 1 ========================
        If ExeViaSay Then
            Tmp_Index2 = InStr(TheStringUP, "]: <") + 4
            Tmp_Index3 = InStr(Tmp_Index2, TheStringUP, ">")
            If (Tmp_Index3 > Tmp_Index2) AndAlso (Tmp_Index2 > 0) Then
                Get_SenderID = TheString.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)
                If The_Man_has_right_V2(Get_SenderID) Then
                    Get_AfterID = TheString.Substring(Tmp_Index3).Trim
                    If Get_AfterID.Length > 2 Then
                        GeekCommandRtnV2.TheCommandPart = Get_AfterID.Substring(0, 1)
                        GeekCommandRtnV2.TheMessagePart = Get_AfterID.Substring(1)
                        GeekCommandRtnV2.IsUsable = True
                    End If
                End If
            End If
        End If


        If GeekCommandRtnV2.IsUsable Then Return GeekCommandRtnV2


        '==========================V2 detect 2 ========================
        If ExeViaSay Then
            Tmp_Index2 = InStr(TheStringUP, "]: [") + 4
            Tmp_Index3 = InStr(Tmp_Index2, TheStringUP, "]")
            If (Tmp_Index3 > Tmp_Index2) AndAlso (Tmp_Index2 > 0) Then
                Get_SenderID = TheString.Substring(Tmp_Index2 - 1, Tmp_Index3 - Tmp_Index2)
                If The_Man_has_right_V2(Get_SenderID) Then
                    Get_AfterID = TheString.Substring(Tmp_Index3).Trim
                    If Get_AfterID.Length > 2 Then
                        GeekCommandRtnV2.TheCommandPart = Get_AfterID.Substring(0, 1)
                        GeekCommandRtnV2.TheMessagePart = Get_AfterID.Substring(1)
                        GeekCommandRtnV2.IsUsable = True
                    End If
                End If
            End If
        End If


        If GeekCommandRtnV2.IsUsable Then Return GeekCommandRtnV2

        Return GeekCommandRtnV1

    End Function

    Public Function GetProcessInstanceName(pid As Integer) As String

        Dim Cats As New PerformanceCounterCategory("Process")
        Dim instances() As String = Cats.GetInstanceNames()

        GetProcessInstanceName = ""

        For Each instance_Str As String In instances

            Dim cnt As New PerformanceCounter("Process", "ID Process", instance_Str, True)

            If cnt.RawValue = CLng(pid) Then
                Return instance_Str
            End If
        Next

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

        If (Check_Sender_String.Length >= 15) AndAlso (Man_CBAT_Workable = 1) Then 'CommandBlock send all pass
            If (Check_Sender_String.Substring(0, 15) = "CommandBlock at") Then
                If (Check_Sendto_String = "CommandBlock") Then
                    Man_Who_LastSending_ForCheck = Check_Sender_String
                    Return True
                End If
            End If
        End If

        For Each TestOP_List As String In Man_Who_CanWorkList
            If Check_Sender_String = TestOP_List Then  'Normal player send
                If Check_Sender_String = Check_Sendto_String Then
                    Man_Who_LastSending = Check_Sender_String
                    Man_Who_LastSending_ForCheck = Check_Sender_String
                    Return True
                ElseIf (Check_Sender_String.Length > 15) AndAlso (Check_Sender_String.Substring(0, 15) = "CommandBlock at") Then 'CommandBlock send need set
                    If (Check_Sendto_String = "CommandBlock") Then
                        Man_Who_LastSending_ForCheck = Check_Sender_String
                        Return True
                    End If
                End If
            End If
        Next

        Return False

    End Function

    Public Function The_Man_has_right_V2(Check_Sender_String As String) As Boolean

        If Check_Sender_String = "@" Then
            Man_Who_LastSending_ForCheck = "@"
            Return True
        End If

        For Each TestOP_List As String In Man_Who_CanWorkList
            If Check_Sender_String = TestOP_List Then
                Man_Who_LastSending = Check_Sender_String
                Man_Who_LastSending_ForCheck = Check_Sender_String
                Return True
            End If
        Next

        Return False

    End Function

    Public Function Check_If_Misjudge(TheString As String) As Boolean

        TheString = Replace(TheString, " [MINECRAFT/DEDICATEDSERVER]", "")

        If InStr(TheString, "INFO]: * @") > 0 Then Return False
        If (InStr(TheString, "INFO]: <") > 0) Then Return False
        If (InStr(TheString, "INFO]: [") > 0) Then Return False
        If (InStr(TheString, "ISSUED SERVER COMMAND:") > 0) Then Return False

        Return True

    End Function

    Public Function Ticket_Return(TheString As String, CheckTarget As String) As String

        Ticket_Return = "-2"

        If InStr(TheString.ToUpper, " UNKNOWN DIMENSION") > 0 Then Return "-4"

        Dim TMP_TICK1_IDX As Integer
        TMP_TICK1_IDX = InStr(TheString.ToUpper, " THE TIME IS ")

        If TMP_TICK1_IDX > 0 Then
            Return TheString.Substring(TMP_TICK1_IDX + 12)
        End If

    End Function


    Public Function Locate_Return(TheString As String, CheckTarget As String) As String

        Locate_Return = "-2"
        If CheckTarget Is Nothing Then Exit Function

        Dim TheStringUp As String = TheString.ToUpper
        Dim TheStringWorking As String

        If InStr(TheStringUp, CheckTarget.ToUpper) = 0 Then Exit Function

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

    Public Function RawRead_Return(TheString As String, CheckTarget() As String) As String

        RawRead_Return = "-2"
        If CheckTarget Is Nothing Then Exit Function

        Dim TheStringUp As String = TheString.ToUpper
        Dim TMP_IDX As Integer
        TMP_IDX = InStr(TheStringUp, "INFO]:")
        If TMP_IDX = 0 Then TMP_IDX = InStr(TheStringUp, "RVER]:")

        If CheckTarget(2) <> "" Then
            If InStr(TheStringUp, CheckTarget(2).ToUpper) > 0 Then
                Return "-4"
            End If
        End If

        If TMP_IDX > 0 Then
            If InStr(TheStringUp, CheckTarget(0).ToUpper) > 0 Then
                If InStr(TheStringUp, CheckTarget(1).ToUpper) > 0 Then
                    RawRead_Return = TheString.Substring(TMP_IDX + 6)
                End If
            End If
        End If

    End Function

    Public Sub What_RU_Waiting(ByRef WaitingStr As String, WaitingTimes_ds As Integer)

        WaitingTimes_ds = WaitingTimes_ds * 10
        Dim LoopWait As Integer = 0
        Do
            System.Threading.Thread.Sleep(10)
            My.Application.DoEvents()
            If (WaitingStr <> "-1") And (WaitingStr <> "-2") Then Exit Do
            LoopWait += 1
        Loop Until LoopWait = WaitingTimes_ds

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

    Public Sub Clear_EXE_Queue()
        For idx00 As Integer = 0 To Queued_EXE_depth
            Queued_EXE_Command(idx00) = ""
        Next
        Queued_EXE_Command_StoredIDX = 0
        Queued_EXE_Command_WalkedIDX = 0
    End Sub



End Module
