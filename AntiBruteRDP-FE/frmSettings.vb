Imports System.Configuration
Imports System.Management
Imports System.Xml
Imports System.ServiceProcess

Public Class frmSettings
    Public Shared WithEvents objEventSink As New ManagementEventWatcher
    Public config = ConfigurationManager.OpenExeConfiguration("AntiBruteRDP.exe")
    Public Shared valBlock As String = "0"
    Public Shared ValUnblock As String = "0"
    Public settingsSection As UserSettingsGroup = config.GetSectionGroup("userSettings")
    Public BruteSettings As ClientSettingsSection = settingsSection.Sections.Item("AntiBruteRDP.My.MySettings")
    Private Shared ttip As New ToolTip()
    Public Shared tipsec As Integer = 5000

    Private Sub frmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        e.Cancel = True
        tray.ShowBalloonTip(2000, "AntiBruteRDP", "AntiBruteRDP will keep running in tray..", ToolTipIcon.Info)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If Not svc.ServiceHandle.IsInvalid Then




                For Each st In BruteSettings.Settings
                    'get setting name and value
                    Dim value As String = st.Value.ValueXml.InnerText

                    If st.name = "BlockUsers" Then txtBlockUsers.Text = value
                    If st.name = "BlockTimeout" Then txtBlockTimeout.Text = value
                    If st.name = "BlockAttempts" Then txtBlockAttempts.Text = value
                    If st.name = "BlockDuration" Then txtBlockDuration.Text = value
                    If st.name = "BlackholeIP" Then txtBlackholeIP.Text = value
                    If st.name = "NotifyOnBlock" And value = "1" Then chkNotifyOnBlock.Checked = True : valBlock = "1"
                    If st.name = "NotifyOnUnblock" And value = "1" Then chkNotifyOnUnblock.Checked = True : ValUnblock = "1"


                Next
                cmbBlockUsers.Items.Clear()
                For Each x In txtBlockUsers.Text.Split(",")
                    cmbBlockUsers.Items.Add(x)
                Next
                cmbBlockUsers.SelectedIndex = cmbBlockUsers.Items.Count - cmbBlockUsers.Items.Count

                If svc.Status = ServiceControllerStatus.Running Then picStatus.BackgroundImage = My.Resources.started : btnStart.Enabled = False : btnStop.Enabled = True
                If svc.Status = ServiceControllerStatus.Stopped Then picStatus.BackgroundImage = My.Resources.stopped : btnStop.Enabled = False : btnStart.Enabled = True


                Dim ApplicationTitle As String
                If My.Application.Info.Title <> "" Then
                    ApplicationTitle = My.Application.Info.Title
                Else
                    ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
                End If
                Me.Text = String.Format("About {0}", ApplicationTitle)
                Me.LabelProductName.Text = My.Application.Info.ProductName
                Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
                Me.LabelCopyright.Text = My.Application.Info.Copyright
                Me.LabelCompanyName.Text = My.Application.Info.CompanyName
                Me.TextBoxDescription.Text = My.Application.Info.Description


                objEventSink.Query = New WqlEventQuery("__InstanceCreationEvent", New TimeSpan(0, 0, 1), "TargetInstance ISA ""Win32_NTLogEvent"" AND TargetInstance.Logfile = ""RDPBruteLog"" AND TargetInstance.EventType = 3 AND (TargetInstance.EventIdentifier = 256 OR TargetInstance.EventIdentifier = 257) AND (TargetInstance.SourceName = ""AntiBruteRDP"")")
                objEventSink.Start()


            End If

            
        Catch ex As Exception
            If ex.InnerException.Message.ToString().Contains("not exist") Then
                MsgBox(ex.Message & " " & ex.InnerException.Message & " Please reinstall the application.", MsgBoxStyle.Critical, "Fatal Error")
                End
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
    Public Shared Sub FailureEventCreated(ByVal sender As ManagementEventWatcher, ByVal e As EventArrivedEventArgs) Handles objEventSink.EventArrived
        Dim notify As String

        '  objEventSink.Stop()
        Dim inst As ManagementBaseObject = e.NewEvent("TargetInstance")
        ' Differentiate W2K3 and W2K8+
        ' If inst.Properties("SourceName").Value = "Microsoft-Windows-Security-Auditing" Then
        notify = inst.Properties("InsertionStrings").Value(0)



        If notify.StartsWith("Blocked") And valBlock = 1 Then tray.ShowBalloonTip(tipsec, "Blocked", notify, ToolTipIcon.Warning)
        If notify.StartsWith("Unblocked") And ValUnblock = 1 Then tray.ShowBalloonTip(tipsec, "Unblocked", notify, ToolTipIcon.Info)


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        ttip.Show("The users specified here will be blocked directly at first failure attempts", txtBlockUsers, 5000)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            If chkNotifyOnBlock.Checked = True Then valBlock = 1 Else valBlock = 0
            If chkNotifyOnUnblock.Checked = True Then ValUnblock = 1 Else ValUnblock = 0

            BruteSettings.Settings.Clear()




            Dim setCol As New SettingElementCollection

            setCol.Add(New SettingElement("BlockUsers", SettingsSerializeAs.String))
            setCol.Add(New SettingElement("BlockTimeout", SettingsSerializeAs.String))
            setCol.Add(New SettingElement("BlockAttempts", SettingsSerializeAs.String))
            setCol.Add(New SettingElement("BlockDuration", SettingsSerializeAs.String))
            setCol.Add(New SettingElement("BlackholeIP", SettingsSerializeAs.String))
            setCol.Add(New SettingElement("NotifyOnBlock", SettingsSerializeAs.String))
            setCol.Add(New SettingElement("NotifyOnUnblock", SettingsSerializeAs.String))

            For Each ts As SettingElement In setCol
                Dim value As New SettingValueElement
                value.ValueXml = New XmlDocument().CreateElement("value")

                If ts.Name = "BlockUsers" Then value.ValueXml.InnerText = txtBlockUsers.Text : ts.Value = value : BruteSettings.Settings.Add(ts)
                If ts.Name = "BlockTimeout" Then value.ValueXml.InnerText = txtBlockTimeout.Text : ts.Value = value : BruteSettings.Settings.Add(ts)
                If ts.Name = "BlockAttempts" Then value.ValueXml.InnerText = txtBlockAttempts.Text : ts.Value = value : BruteSettings.Settings.Add(ts)
                If ts.Name = "BlockDuration" Then value.ValueXml.InnerText = txtBlockDuration.Text : ts.Value = value : BruteSettings.Settings.Add(ts)
                If ts.Name = "BlackholeIP" Then value.ValueXml.InnerText = txtBlackholeIP.Text : ts.Value = value : BruteSettings.Settings.Add(ts)
                If ts.Name = "NotifyOnBlock" Then value.ValueXml.InnerText = valBlock : ts.Value = value : BruteSettings.Settings.Add(ts)
                If ts.Name = "NotifyOnUnblock" Then value.ValueXml.InnerText = ValUnblock : ts.Value = value : BruteSettings.Settings.Add(ts)

            Next



            config.Save(ConfigurationSaveMode.Modified, False)

            MsgBox("Settings saved sucessfully! Please restart the services to apply the changes.", MsgBoxStyle.Information, "Setting saved!")
            tabber.SelectTab("tabService")


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR!")
        End Try

    End Sub




    Private Sub traymenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles traymenu.Opening

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Dim Result As DialogResult = MsgBox("Exit AntiBruteRDP?", MsgBoxStyle.YesNo, "Confirm")
        If Result = DialogResult.Yes Then End Else Me.Hide()
    End Sub

    Private Sub mnuSettings_Click(sender As Object, e As EventArgs) Handles mnuSettings.Click
        tabber.SelectTab("tabSettings")
        Me.Show()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim item = InputBox("Enter username to block, each separated by comma", "Add/remove usernames to block", txtBlockUsers.Text)

        If item.ToString <> "" Then
            cmbBlockUsers.Items.Clear()
            For Each x In item.Split(",")
                cmbBlockUsers.Items.Add(x)
            Next
            txtBlockUsers.Text = item
        End If

        cmbBlockUsers.SelectedIndex = cmbBlockUsers.Items.Count - cmbBlockUsers.Items.Count

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Try

            lblStatus.Visible = True
            lblStatus.Text = "Starting service..."
            Me.Refresh()
            svc.Start()
            Threading.Thread.Sleep(5000)
            svc.Refresh()
            If svc.Status = ServiceControllerStatus.Running Then picStatus.BackgroundImage = My.Resources.started : btnStart.Enabled = False : btnStop.Enabled = True
            If svc.Status = ServiceControllerStatus.Stopped Then picStatus.BackgroundImage = My.Resources.stopped : btnStop.Enabled = False : btnStart.Enabled = True
            lblStatus.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Try



            lblStatus.Visible = True
            lblStatus.Text = "Stopping service..."
            Me.Refresh()
            svc.Stop()
            Threading.Thread.Sleep(5000)
            svc.Refresh()
            If svc.Status = ServiceControllerStatus.Running Then picStatus.BackgroundImage = My.Resources.started : btnStart.Enabled = False : btnStop.Enabled = True
            If svc.Status = ServiceControllerStatus.Stopped Then picStatus.BackgroundImage = My.Resources.stopped : btnStop.Enabled = False : btnStart.Enabled = True
            lblStatus.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.Hide()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        svc.Refresh()
        If svc.Status = ServiceControllerStatus.Running Then picStatus.BackgroundImage = My.Resources.started : btnStart.Enabled = False : btnStop.Enabled = True
        If svc.Status = ServiceControllerStatus.Stopped Then picStatus.BackgroundImage = My.Resources.stopped : btnStop.Enabled = False : btnStart.Enabled = True

    End Sub

    Private Sub txtBlockTimeout_GotFocus(sender As Object, e As EventArgs) Handles txtBlockTimeout.MouseHover
        ttip.Show("Timeout for attempts before a new attempt is considered attempt #1", txtBlockTimeout, tipsec)
    End Sub

    Private Sub txtBlockAttempts_GotFocus(sender As Object, e As EventArgs) Handles txtBlockAttempts.MouseHover
        ttip.Show("Number of failed logons in time window before IP will be blocked", txtBlockAttempts, tipsec)
    End Sub

    Private Sub txtBlockDuration_GotFocus(sender As Object, e As EventArgs) Handles txtBlockDuration.MouseHover
        ttip.Show("Expiration (in seconds) for IPs to be blocked", txtBlockDuration, tipsec)
    End Sub

    Private Sub cmbBlockUsers_MouseHover(sender As Object, e As EventArgs) Handles cmbBlockUsers.MouseHover
        ttip.Show("Usernames that attempted logons for result in immediate blocking", cmbBlockUsers, tipsec)
    End Sub

    Private Sub txtBlackholeIP_GotFocus(sender As Object, e As EventArgs) Handles txtBlackholeIP.MouseHover
        ttip.Show("Sets Blackhole IP address (applies only to Windows Server 2003)", txtBlackholeIP, tipsec)
    End Sub

    Private Shared Sub tray_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tray.MouseDoubleClick
        frmSettings.tabber.SelectTab("tabAbout")
        frmSettings.Show()
    End Sub

    Private Sub tabber_Selected(sender As Object, e As TabControlEventArgs) Handles tabber.Selected
        If e.TabPage.Name = "tabSettings" Then Me.Text = "AntiBruteRDP Configuration"
        If e.TabPage.Name = "tabService" Then Me.Text = "AntiBruteRDP Service Configuration"
        If e.TabPage.Name = "tabAbout" Then Me.Text = "About AntiBruteRDP"
    End Sub
End Class
