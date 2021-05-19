

Imports System.Management
Imports System.Text.RegularExpressions


Public Class AntiBruteRDP
    Public WithEvents tmrMonitor As New Timers.Timer

    Public VERSION As String = My.Application.Info.Version.ToString()
    Public CASE_SENSITIVE As Integer = 0

    Public Shared WithEvents objEventSink As New ManagementEventWatcher
    Public Shared WithEvents tmrExpiredBlocks As New Timers.Timer
    Public Shared regexpSanitizeEventLog As New Regex("[^0-9a-zA-Z._ /:\-]")
    Public Shared regexpSanitizeIP As New Regex("[^0-9.]")
    Public Shared dictIPLastSeenTime As New Dictionary(Of String, String)
    Public Shared dictIPBadLogons As New Dictionary(Of String, String)
    Public Shared intBlockTimeout As Integer = 1000 ' how long until next failed try
    Public Shared intBlockAttempts As Integer = 3 'how many attempts
    Public Shared intBlackholeStyle = 1
    Public Shared intBlockDuration = 120 'how many seconds to block
    Public Shared blackHoleIPAddress As String
    Public Shared BlockDirectUsers As Array
    Public Const BLACKHOLE_ROUTE = 1
    Public Const BLACKHOLE_FIREWALL = 2
    'later maybe try to check per time multiple ip
    Public Shared dictUnblockTime As New Dictionary(Of String, String)
    Const EVENTLOG_ID_ERROR_WIN_XP = 3
    Public Const EVENTLOG_SOURCE = "AntiBruteRDP"
    Public Const EVENTLOG_TYPE_INFORMATION = "INFORMATION"
    Public Const EVENTLOG_TYPE_ERROR = "ERROR"
    Public Const EVENTLOG_ID_STARTED = 1
    Const EVENTLOG_ID_ERROR_NO_BLACKHOLE_IP = 2
    Const EVENTLOG_ID_BLOCK = 256
    Const EVENTLOG_ID_UNBLOCK = 257
    Public Sub RefreshSettings()
        intBlockTimeout = My.Settings.BlockTimeout   ' Timeout for attempts before a new attempt is considered attempt #1
        intBlockAttempts = My.Settings.BlockAttempts ' Number of failed logons in time window before IP will be blocked
        intBlockDuration = My.Settings.BlockDuration ' Expiration (in seconds) for IPs to be blocked
        blackHoleIPAddress = regexpSanitizeIP.Replace(My.Settings.BlackholeIP, "") ' Black hole IP address (if hard-specified)
        BlockDirectUsers = My.Settings.BlockUsers.Split(",")
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        LogEvent(EVENTLOG_ID_STARTED, EVENTLOG_TYPE_INFORMATION, "AntiBruteRDP started...")
        tmrMonitor.Interval = 5000
        tmrMonitor.Enabled = True
        RefreshSettings()
     
    End Sub

    Protected Overrides Sub OnStop()
        'tmrMonitor.Enabled = False
        LogEvent(EVENTLOG_ID_STARTED, EVENTLOG_TYPE_INFORMATION, "AntiBruteRDP stopped...")
    End Sub

    Public Sub New()



        MyBase.New()
        

        InitializeComponent()

        AutoLog = False
        Dim evt As New System.Diagnostics.EventLog
        If Not EventLog.SourceExists(EVENTLOG_SOURCE) Then
            EventLog.CreateEventSource(EVENTLOG_SOURCE, "RDPBruteLog")
        End If
        EventLog.Source = EVENTLOG_SOURCE



    End Sub
    Shared Sub LogEvent(ByVal ID As Integer, ByVal EventType As String, ByVal Message As String)

        Dim eType As EventLogEntryType

        If EventType = "INFORMATION" Then eType = EventLogEntryType.Information
        If EventType = "ERROR" Then eType = EventLogEntryType.Error

        ' Log an event to the Windows event log

        ' Sanitize input string
        Message = regexpSanitizeEventLog.Replace(Message, "")

        'Dim evtx As New EventLog
        'If Not EventLog.SourceExists(EVENTLOG_SOURCE) Then
        '    EventLog.CreateEventSource(EVENTLOG_SOURCE, "RDPBruteLog")
        'End If
        '    EventLog.Source = EVENTLOG_SOURCE

        EventLog.WriteEntry(EVENTLOG_SOURCE, Message, eType, ID)

    End Sub

    Private Sub tmrMonitor_Tick(sender As Object, e As EventArgs) Handles tmrMonitor.Elapsed
        tmrMonitor.Enabled = False
        'LogEvent(EVENTLOG_ID_STARTED, EVENTLOG_TYPE_INFORMATION, "AntiBruteRDP started...")

        setBlackholeStyle()
        objEventSink.Query = New WqlEventQuery("__InstanceCreationEvent", New TimeSpan(0, 0, 1), "TargetInstance ISA ""Win32_NTLogEvent"" AND TargetInstance.Logfile = ""Security"" AND TargetInstance.EventType = 5 AND (TargetInstance.EventIdentifier = 529 OR TargetInstance.EventIdentifier = 4625) AND (TargetInstance.SourceName = ""Security"" OR TargetInstance.SourceName = ""Microsoft-Windows-Security-Auditing"")")
        objEventSink.Start()
        tmrExpiredBlocks.Interval = 60000
        tmrExpiredBlocks.Enabled = True
        'tmrMonitor.Enabled = True
    End Sub



    Shared Sub setBlackholeStyle()

        'Get OS Version
        Dim searcher As New ManagementObjectSearcher("SELECT BuildNumber FROM Win32_OperatingSystem")
        Dim envVar As ManagementObject
        Dim buildNumber As Integer = 0
        For Each envVar In searcher.Get()
            buildNumber = envVar("BuildNumber")
        Next

        If buildNumber < 4000 Then intBlackholeStyle = BLACKHOLE_ROUTE Else intBlackholeStyle = BLACKHOLE_FIREWALL
        If buildNumber = 2600 Then
            'xp mana ada
            LogEvent(EVENTLOG_ID_ERROR_WIN_XP, EVENTLOG_TYPE_ERROR, "Fatal Error - Windows XP does not provide an IP address to black-hole in failure audit event log entries.")
        End If
        If intBlackholeStyle = BLACKHOLE_ROUTE Then
            blackHoleIPAddress = GetBlackholeIP()
            If blackHoleIPAddress Is vbNullString Then
                LogEvent(EVENTLOG_ID_ERROR_NO_BLACKHOLE_IP, EVENTLOG_TYPE_ERROR, "Fatal Error - Could not obtain an IP address for an interface with no default gateway specified.")
                End
            End If

        End If



    End Sub
    Shared Sub FailureEventCreated(ByVal sender As ManagementEventWatcher, ByVal e As EventArrivedEventArgs) Handles objEventSink.EventArrived
        Dim IP, user As String

        '  objEventSink.Stop()
        Dim inst As ManagementBaseObject = e.NewEvent("TargetInstance")
        ' Differentiate W2K3 and W2K8+
        If inst.Properties("SourceName").Value = "Microsoft-Windows-Security-Auditing" Then
            user = inst.Properties("InsertionStrings").Value(5)
            IP = inst.Properties("InsertionStrings").Value(19)
        Else
            ' Assume W2K3
            user = inst.Properties("InsertionStrings").Value(0)
            IP = inst.Properties("InsertionStrings").Value(11)
        End If


        ' Make sure only characters allowed in IP addresses are passed to external commands
        IP = regexpSanitizeIP.Replace(IP, "")

        ' If the event didn't generate both a username and IP address then do nothing
        If (IP <> "") And (user <> "") Then
            If BlockDirect(user) Then Block(IP) Else LogFailedLogonAttempt(IP)
        End If
        '  objEventSink.Start()
    End Sub

    ' Should an invalid logon from specified user result in an immediate block?
    Public Shared Function BlockDirect(user)
        
        If Not BlockDirectUsers.Length = 0 Then
            For Each userToBlock In BlockDirectUsers
                If UCase(user) = UCase(userToBlock) Then
                    BlockDirect = True
                    Exit Function
                End If
            Next
        End If
        BlockDirect = False
    End Function
    Public Shared Sub Block(ByVal IP As String)
        Try

            ' Block an IP address and set the time for the block expiration
            Dim strRunCommand, exe As String
            Dim intRemoveBlockTime As DateTime

            ' Block an IP address (either by black-hole routing it or adding a firewall rule)
            If intBlackholeStyle = BLACKHOLE_ROUTE Then
                exe = "route"
                strRunCommand = "add " & IP & " mask 255.255.255.255 " & blackHoleIPAddress
            End If
            If intBlackholeStyle = BLACKHOLE_FIREWALL Then
                exe = "netsh"
                strRunCommand = "advfirewall firewall add rule name=""Blackhole " & IP & """ dir=in protocol=any action=block remoteip=" & IP
            End If

            ExecuteDOSCmd(exe, strRunCommand)

            intRemoveBlockTime = Date.Now.AddSeconds(intBlockDuration)

            If Not dictUnblockTime.ContainsValue(intRemoveBlockTime) Then
                dictUnblockTime.Add(intRemoveBlockTime, IP)
            End If
            If Not dictUnblockTime.Item(intRemoveBlockTime).Contains(IP) Then dictUnblockTime.Add(intRemoveBlockTime, IP)

            LogEvent(EVENTLOG_ID_BLOCK, EVENTLOG_TYPE_INFORMATION, "Blocked " & IP & " until " & intRemoveBlockTime)

        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    ' Executes and waits for DOS command to complete
    Shared Function ExecuteDOSCmd(ByVal exe As String, Optional ByVal args As String = "") As String

        Dim retStr As String = ""
        Dim p As New Process()
        p.StartInfo.FileName = exe
        If args <> "" Then p.StartInfo.Arguments = args
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.CreateNoWindow = True
        p.Start()
        retStr = p.StandardOutput.ReadToEnd()
        p.WaitForExit()
        Return retStr

    End Function
    Private Shared Sub ExpireBlocks()
        Dim unblockTime As DateTime
        Dim ipAddress As New Collection

        For Each unblockTime In dictUnblockTime.Keys
            If unblockTime <= (Date.Now) Then
                'not possible attack per second
                '      For Each ipAddress In dictUnblockTime.Item(unblockTime)
                Unblock(dictUnblockTime.Item(unblockTime))
                ' Next ' ipAddress
                ipAddress.Add(unblockTime)
            End If
        Next 'timing

        'remove the expired IP
        For Each item In ipAddress
            dictUnblockTime.Remove(item)
        Next

    End Sub

    Shared Sub Unblock(ByVal IP As String)
        ' Unblock an IP address
        Dim strRunCommand, exe As String

        If intBlackholeStyle = BLACKHOLE_ROUTE Then
            exe = "route"
            strRunCommand = "delete " & IP & " mask 255.255.255.255 " & blackHoleIPAddress
        End If
        If intBlackholeStyle = BLACKHOLE_FIREWALL Then
            exe = "netsh"
            strRunCommand = "advfirewall firewall delete rule name=""Blackhole " & IP & """"
        End If

        ExecuteDOSCmd(exe, strRunCommand)

        LogEvent(EVENTLOG_ID_UNBLOCK, EVENTLOG_TYPE_INFORMATION, "Unblocked " & IP)
    End Sub

    Public Shared Sub LogFailedLogonAttempt(ByVal IP As String)
        ' Log failed logon attempts and, if necessary, block the IP address

        ' Have we already seen this IP address before?
        If dictIPLastSeenTime.ContainsKey(IP) Then

            ' Be sure that prior attempts, if they are older than intBlockTimeout, don't count it against the IP
            If (Date.Parse(dictIPLastSeenTime.Item(IP)).AddSeconds(intBlockTimeout)) <= (Date.Now) Then
                If dictIPBadLogons.ContainsKey(IP) Then dictIPBadLogons.Remove(IP)
            End If

            dictIPLastSeenTime.Item(IP) = (Date.Now())
        Else
            dictIPLastSeenTime.Add(IP, (Date.Now()))
        End If

        ' Does this IP address already have a history of bad logons?
        If dictIPBadLogons.ContainsKey(IP) Then
            dictIPBadLogons.Item(IP) = dictIPBadLogons.Item(IP) + 1
        Else
            dictIPBadLogons.Add(IP, 1)
        End If

        ' Should we block this IP address?
        If dictIPBadLogons.Item(IP) = intBlockAttempts Then Block(IP)
    End Sub


    Private Shared Sub tmrExpiredBlocks_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles tmrExpiredBlocks.Elapsed
        tmrExpiredBlocks.Enabled = False
        ExpireBlocks()
        tmrExpiredBlocks.Enabled = True
    End Sub
    Shared Function GetBlackholeIP() As String
        ' Sift through the NICs on the machine to locate a NIC's IP to use to blackhole offending hosts.
        ' Look for a NIC with no default gateway set and an IP address assigned. Return NULL if we can't
        ' find one.
        Try


            Dim query As WqlObjectQuery = New WqlObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE")
            Dim searcher As New ManagementObjectSearcher(query)
            Dim NICs As ManagementObject

            ' Scan for a NIC with no default gateway set and IP not 0.0.0.0
            For Each NICs In searcher.Get()
                If NICs.Properties("DefaultIPGateway").Value Is Nothing And (NICs.Properties("IPAddress").Value(0) <> "0.0.0.0") Then
                    Return NICs.Properties("IPAddress").Value(0)
                    Exit Function
                End If
            Next



            'For Each objNICConfig In NICs
            '    If objNICConfig.DefaultIPGateway = vbNullString And (objNICConfig.IPAddress(0) <> "0.0.0.0") Then
            '        '  If DEBUGGING Then WScript.Echo "Decided on black-hole IP address " & objNICConfig.IPAddress(0) & ", interface " & objNICConfig.Description
            '        GetBlackholeIP = objNICConfig.IPAddress(0)
            '        Exit Function
            '    End If
            'Next

            ' Couldn't find anything, return NULL to let caller know we failed
            Return vbNullString


        Catch ex As Exception
            LogEvent(EVENTLOG_ID_ERROR_NO_BLACKHOLE_IP, EVENTLOG_TYPE_ERROR, ex.Message.ToString)
        End Try

    End Function

End Class
