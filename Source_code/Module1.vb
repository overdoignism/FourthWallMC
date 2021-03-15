Imports System.Xml
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Drawing.Text

Module Module1

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
    Public Man_ThisTime_W2Say As Boolean
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

    Public BurstMode As Integer = 0
    Public Origial_Path As String

    'Detect EssentialsX Installed
    Public IsEssentialsX_Installed As Integer

    Public FthWallMC_Server_Bypass As Integer



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

            Save_XML.WriteEndElement()
            Save_XML.Flush()
            My.Application.DoEvents()
            Save_XML.Close()

        Catch ex As Exception
            MsgBox("Err:", 0, ex.Message)
        End Try

    End Sub

    Public Sub LoadXML()

        Dim Load_XML As New XmlDocument()
        Dim TmpNode As XmlNode

        Try

            Load_XML.Load(Origial_Path + "\Setting.xml")
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

            If Man_Who_CanWork IsNot Nothing Then
                Make_List_Array()
            Else
                ReDim Man_Who_CanWorkList(0)
                Man_Who_CanWorkList(0) = ""
            End If


        Catch ex As Exception
            MsgBox("Err:", 0, ex.Message)
        End Try

        Make_Value_In_Box()

    End Sub

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

        Form3.Iagree_CheckBox.Checked = IsAgree

    End Sub

    Private Sub createNode(XMLWriter As XmlTextWriter, NodeName As String, NodeValue As String)

        XMLWriter.WriteStartElement(NodeName)
        XMLWriter.WriteString(NodeValue)
        XMLWriter.WriteEndElement()

    End Sub

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


    Public Function The_Man_has_right(Check_Sender_String As String, Check_Sendto_String As String) As Boolean


        If (Check_Sender_String.Length >= 15) AndAlso (Man_CBAT_Workable = 1) Then
            If (Check_Sender_String.Substring(0, 15) = "CommandBlock at") Then
                If (Check_Sendto_String = "CommandBlock") Then
                    Man_Who_LastSending = "CONSOLE"
                    Return True
                End If
            End If
        End If


        For Each TestOP_List As String In Man_Who_CanWorkList
            If Check_Sender_String = TestOP_List Then
                If Check_Sender_String = Check_Sendto_String Then
                    Man_Who_LastSending = Check_Sendto_String
                    Return True
                ElseIf (Check_Sender_String.Length > 15) AndAlso (Check_Sender_String.Substring(0, 15) = "CommandBlock at") Then
                    If (Check_Sendto_String = "CommandBlock") Then
                        Man_Who_LastSending = "CONSOLE"
                        Return True
                    End If
                End If
            End If
        Next

        Return False

    End Function
    Public Function Check_If_Misjudge(TheString As String, ChkIsBoolen As Boolean) As Boolean

        If ChkIsBoolen = False Then Return False
        Check_If_Misjudge = False

        TheString = Replace(TheString, " [MINECRAFT/DEDICATEDSERVER]", "")

        If InStr(TheString, "INFO]: * @") > 0 Then
            Return False
        End If

        If (InStr(TheString, "INFO]: <") > 0) Then
            Return False
        End If

        If (InStr(TheString, "INFO]: [") > 0) Then
            Return False
        End If

        If (InStr(TheString, "ISSUED SERVER COMMAND:") > 0) Then
            Return False
        End If

        Return True

    End Function

    Public Function Locate_Return(TheString As String, CheckTarget As String) As String

        Locate_Return = "-1"
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
                    TheStringWorking = Replace(TheStringWorking, "] (", ",")
                    TheStringWorking = Replace(TheStringWorking, " ", "")

                    Return TheStringWorking
                End If
            End If
        End If

    End Function

    Public Function RawRead_Return(TheString As String, CheckTarget() As String) As String

        RawRead_Return = "-1"
        If CheckTarget Is Nothing Then Exit Function

        Dim TheStringUp As String = TheString.ToUpper
        Dim TMP_IDX As Integer
        TMP_IDX = InStr(TheStringUp, "INFO]:")
        If TMP_IDX = 0 Then TMP_IDX = InStr(TheStringUp, "RVER]:")

        If TMP_IDX > 0 Then
            If InStr(TheStringUp, CheckTarget(0).ToUpper) > 0 Then
                If InStr(TheStringUp, CheckTarget(1).ToUpper) > 0 Then
                    RawRead_Return = TheString.Substring(TMP_IDX + 6)
                End If
            End If
        End If


        If CheckTarget(2) <> "" Then
            If InStr(TheStringUp, CheckTarget(2).ToUpper) > 0 Then
                RawRead_Return = "-4"
            End If
        End If


    End Function

    Public Sub What_RU_Waiting(ByRef WaitingStr As String, WaitingTimes_ds As Integer)

        Dim LoopWait As Integer = 0

        Do
            System.Threading.Thread.Sleep(100)
            My.Application.DoEvents()
            If WaitingStr <> "-1" Then Exit Do
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

        If TheString.Length >= 4 Then

            Dim ServerSetting() As String = TheString.Split(",")
            Dim TmpIdx1, TmpIdx2 As Integer

            TmpIdx1 = UBound(ServerSetting)
            If TmpIdx1 <> 3 Then Return 1

            For TmpIdx2 = 0 To 3
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
                        Case 2
                            If (TmpIdx1 >= 0) AndAlso (TmpIdx1 <= 1) Then
                                Man_ThisTime_W2Say = TmpIdx1
                            End If
                        Case 3
                            If (TmpIdx1 >= 0) AndAlso (TmpIdx1 <= 1) Then
                                BurstMode = TmpIdx1
                            End If
                    End Select
                End If
            Next

            Return 0
        Else
            Return 1
        End If


    End Function

End Module
