<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.txtBlockTimeout = New System.Windows.Forms.TextBox()
        Me.txtBlockAttempts = New System.Windows.Forms.TextBox()
        Me.txtBlockDuration = New System.Windows.Forms.TextBox()
        Me.txtBlackholeIP = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.tabber = New System.Windows.Forms.TabControl()
        Me.tabSettings = New System.Windows.Forms.TabPage()
        Me.txtBlockUsers = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cmbBlockUsers = New System.Windows.Forms.ComboBox()
        Me.chkNotifyOnUnblock = New System.Windows.Forms.CheckBox()
        Me.chkNotifyOnBlock = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabService = New System.Windows.Forms.TabPage()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.picStatus = New System.Windows.Forms.PictureBox()
        Me.tabAbout = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.TextBoxDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.traymenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.svc = New System.ServiceProcess.ServiceController()
        Me.tmrMon = New System.Windows.Forms.Timer(Me.components)
        Me.tabber.SuspendLayout
        Me.tabSettings.SuspendLayout
        Me.tabService.SuspendLayout
        CType(Me.picStatus,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabAbout.SuspendLayout
        Me.TableLayoutPanel.SuspendLayout
        CType(Me.LogoPictureBox,System.ComponentModel.ISupportInitialize).BeginInit
        Me.traymenu.SuspendLayout
        Me.SuspendLayout
        '
        'txtBlockTimeout
        '
        Me.txtBlockTimeout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBlockTimeout.Location = New System.Drawing.Point(162, 50)
        Me.txtBlockTimeout.Name = "txtBlockTimeout"
        Me.txtBlockTimeout.Size = New System.Drawing.Size(122, 22)
        Me.txtBlockTimeout.TabIndex = 1
        '
        'txtBlockAttempts
        '
        Me.txtBlockAttempts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBlockAttempts.Location = New System.Drawing.Point(162, 76)
        Me.txtBlockAttempts.Name = "txtBlockAttempts"
        Me.txtBlockAttempts.Size = New System.Drawing.Size(122, 22)
        Me.txtBlockAttempts.TabIndex = 2
        '
        'txtBlockDuration
        '
        Me.txtBlockDuration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBlockDuration.Location = New System.Drawing.Point(162, 102)
        Me.txtBlockDuration.Name = "txtBlockDuration"
        Me.txtBlockDuration.Size = New System.Drawing.Size(122, 22)
        Me.txtBlockDuration.TabIndex = 3
        '
        'txtBlackholeIP
        '
        Me.txtBlackholeIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBlackholeIP.Location = New System.Drawing.Point(162, 128)
        Me.txtBlackholeIP.Name = "txtBlackholeIP"
        Me.txtBlackholeIP.Size = New System.Drawing.Size(122, 22)
        Me.txtBlackholeIP.TabIndex = 4
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(116, 208)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = true
        '
        'tabber
        '
        Me.tabber.Controls.Add(Me.tabSettings)
        Me.tabber.Controls.Add(Me.tabService)
        Me.tabber.Controls.Add(Me.tabAbout)
        Me.tabber.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabber.Location = New System.Drawing.Point(0, 0)
        Me.tabber.Name = "tabber"
        Me.tabber.SelectedIndex = 0
        Me.tabber.Size = New System.Drawing.Size(324, 271)
        Me.tabber.TabIndex = 6
        '
        'tabSettings
        '
        Me.tabSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tabSettings.Controls.Add(Me.txtBlockUsers)
        Me.tabSettings.Controls.Add(Me.btnAdd)
        Me.tabSettings.Controls.Add(Me.cmbBlockUsers)
        Me.tabSettings.Controls.Add(Me.chkNotifyOnUnblock)
        Me.tabSettings.Controls.Add(Me.chkNotifyOnBlock)
        Me.tabSettings.Controls.Add(Me.Label5)
        Me.tabSettings.Controls.Add(Me.Label4)
        Me.tabSettings.Controls.Add(Me.Label3)
        Me.tabSettings.Controls.Add(Me.Label2)
        Me.tabSettings.Controls.Add(Me.Label1)
        Me.tabSettings.Controls.Add(Me.txtBlackholeIP)
        Me.tabSettings.Controls.Add(Me.btnUpdate)
        Me.tabSettings.Controls.Add(Me.txtBlockTimeout)
        Me.tabSettings.Controls.Add(Me.txtBlockAttempts)
        Me.tabSettings.Controls.Add(Me.txtBlockDuration)
        Me.tabSettings.Location = New System.Drawing.Point(4, 22)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSettings.Size = New System.Drawing.Size(316, 245)
        Me.tabSettings.TabIndex = 0
        Me.tabSettings.Text = "General Settings"
        Me.tabSettings.UseVisualStyleBackColor = true
        '
        'txtBlockUsers
        '
        Me.txtBlockUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBlockUsers.Location = New System.Drawing.Point(162, 156)
        Me.txtBlockUsers.Name = "txtBlockUsers"
        Me.txtBlockUsers.Size = New System.Drawing.Size(122, 22)
        Me.txtBlockUsers.TabIndex = 15
        Me.txtBlockUsers.Visible = false
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnAdd.Location = New System.Drawing.Point(286, 22)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(24, 23)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = true
        '
        'cmbBlockUsers
        '
        Me.cmbBlockUsers.FormattingEnabled = true
        Me.cmbBlockUsers.Location = New System.Drawing.Point(164, 23)
        Me.cmbBlockUsers.Name = "cmbBlockUsers"
        Me.cmbBlockUsers.Size = New System.Drawing.Size(121, 21)
        Me.cmbBlockUsers.TabIndex = 13
        '
        'chkNotifyOnUnblock
        '
        Me.chkNotifyOnUnblock.AutoSize = true
        Me.chkNotifyOnUnblock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkNotifyOnUnblock.Location = New System.Drawing.Point(23, 182)
        Me.chkNotifyOnUnblock.Name = "chkNotifyOnUnblock"
        Me.chkNotifyOnUnblock.Size = New System.Drawing.Size(146, 20)
        Me.chkNotifyOnUnblock.TabIndex = 12
        Me.chkNotifyOnUnblock.Text = "Notify on unblock"
        Me.chkNotifyOnUnblock.UseVisualStyleBackColor = true
        '
        'chkNotifyOnBlock
        '
        Me.chkNotifyOnBlock.AutoSize = true
        Me.chkNotifyOnBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkNotifyOnBlock.Location = New System.Drawing.Point(23, 156)
        Me.chkNotifyOnBlock.Name = "chkNotifyOnBlock"
        Me.chkNotifyOnBlock.Size = New System.Drawing.Size(130, 20)
        Me.chkNotifyOnBlock.TabIndex = 11
        Me.chkNotifyOnBlock.Text = "Notify on block"
        Me.chkNotifyOnBlock.UseVisualStyleBackColor = true
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Blackhole IP"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Block Duration"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Attempts"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Attempts Timeouts"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Direct Block Users"
        '
        'tabService
        '
        Me.tabService.Controls.Add(Me.btnRefresh)
        Me.tabService.Controls.Add(Me.lblStatus)
        Me.tabService.Controls.Add(Me.btnStop)
        Me.tabService.Controls.Add(Me.btnStart)
        Me.tabService.Controls.Add(Me.Label6)
        Me.tabService.Controls.Add(Me.picStatus)
        Me.tabService.Location = New System.Drawing.Point(4, 22)
        Me.tabService.Name = "tabService"
        Me.tabService.Padding = New System.Windows.Forms.Padding(3)
        Me.tabService.Size = New System.Drawing.Size(316, 245)
        Me.tabService.TabIndex = 1
        Me.tabService.Text = "Services"
        Me.tabService.UseVisualStyleBackColor = true
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(193, 115)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = true
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = true
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblStatus.Location = New System.Drawing.Point(95, 162)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(66, 16)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "Startring"
        Me.lblStatus.Visible = false
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnStop.Location = New System.Drawing.Point(193, 86)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = true
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnStart.Location = New System.Drawing.Point(193, 57)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = true
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(75, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(147, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "AntiBruteRDP status"
        '
        'picStatus
        '
        Me.picStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picStatus.Image = Global.AntiBruteRDP_FE.My.Resources.Resources.started
        Me.picStatus.Location = New System.Drawing.Point(33, 50)
        Me.picStatus.Name = "picStatus"
        Me.picStatus.Size = New System.Drawing.Size(109, 99)
        Me.picStatus.TabIndex = 1
        Me.picStatus.TabStop = false
        '
        'tabAbout
        '
        Me.tabAbout.Controls.Add(Me.TableLayoutPanel)
        Me.tabAbout.Location = New System.Drawing.Point(4, 22)
        Me.tabAbout.Name = "tabAbout"
        Me.tabAbout.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAbout.Size = New System.Drawing.Size(316, 245)
        Me.tabAbout.TabIndex = 2
        Me.tabAbout.Text = "About"
        Me.tabAbout.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(310, 239)
        Me.TableLayoutPanel.TabIndex = 1
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Image = Global.AntiBruteRDP_FE.My.Resources.Resources.banner2
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
        Me.LogoPictureBox.Size = New System.Drawing.Size(102, 233)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = false
        '
        'LabelProductName
        '
        Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelProductName.Location = New System.Drawing.Point(114, 0)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(193, 17)
        Me.LabelProductName.TabIndex = 0
        Me.LabelProductName.Text = "Product Name"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelVersion.Location = New System.Drawing.Point(114, 23)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(193, 17)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Location = New System.Drawing.Point(114, 46)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(193, 17)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCompanyName.Location = New System.Drawing.Point(114, 69)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 17)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(193, 17)
        Me.LabelCompanyName.TabIndex = 0
        Me.LabelCompanyName.Text = "Company Name"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescription.Location = New System.Drawing.Point(114, 95)
        Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.TextBoxDescription.Multiline = true
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = true
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxDescription.Size = New System.Drawing.Size(193, 113)
        Me.TextBoxDescription.TabIndex = 0
        Me.TextBoxDescription.TabStop = false
        Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(232, 214)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 22)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'tray
        '
        Me.tray.ContextMenuStrip = Me.traymenu
        Me.tray.Icon = CType(resources.GetObject("tray.Icon"),System.Drawing.Icon)
        Me.tray.Text = "AntiBruteRDP Tray"
        Me.tray.Visible = true
        '
        'traymenu
        '
        Me.traymenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSettings, Me.mnuExit})
        Me.traymenu.Name = "traymenu"
        Me.traymenu.Size = New System.Drawing.Size(149, 48)
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(148, 22)
        Me.mnuSettings.Text = "Show Settings"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(148, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'svc
        '
        Me.svc.ServiceName = "AntiBruteRDP"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 271)
        Me.Controls.Add(Me.tabber)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AntiRDPBrute Front End"
        Me.tabber.ResumeLayout(false)
        Me.tabSettings.ResumeLayout(false)
        Me.tabSettings.PerformLayout
        Me.tabService.ResumeLayout(false)
        Me.tabService.PerformLayout
        CType(Me.picStatus,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabAbout.ResumeLayout(false)
        Me.TableLayoutPanel.ResumeLayout(false)
        Me.TableLayoutPanel.PerformLayout
        CType(Me.LogoPictureBox,System.ComponentModel.ISupportInitialize).EndInit
        Me.traymenu.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents txtBlockTimeout As System.Windows.Forms.TextBox
    Friend WithEvents txtBlockAttempts As System.Windows.Forms.TextBox
    Friend WithEvents txtBlockDuration As System.Windows.Forms.TextBox
    Friend WithEvents txtBlackholeIP As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents tabber As System.Windows.Forms.TabControl
    Friend WithEvents tabSettings As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabService As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picStatus As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents traymenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents svc As System.ServiceProcess.ServiceController
    Friend WithEvents cmbBlockUsers As System.Windows.Forms.ComboBox
    Friend WithEvents chkNotifyOnUnblock As System.Windows.Forms.CheckBox
    Friend WithEvents chkNotifyOnBlock As System.Windows.Forms.CheckBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtBlockUsers As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents tabAbout As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents tmrMon As System.Windows.Forms.Timer
    Public Shared WithEvents tray As System.Windows.Forms.NotifyIcon

End Class
