<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownSelector
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
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.dgvDownloadHistory = New System.Windows.Forms.DataGridView
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.lblSelectCount = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.mID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DevNm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ipAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.St = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.rdbDownload = New System.Windows.Forms.RadioButton
        Me.rdbSync = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.dgvDaySummary = New System.Windows.Forms.DataGridView
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.pnlDynamic2 = New System.Windows.Forms.Panel
        Me.pnlDynamic = New System.Windows.Forms.Panel
        Me.pnlSyncData = New System.Windows.Forms.Panel
        Me.dgvSyncedData = New System.Windows.Forms.DataGridView
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnSearchSync = New System.Windows.Forms.Button
        Me.btnSaveSync = New System.Windows.Forms.Button
        Me.dtpToSync = New System.Windows.Forms.DateTimePicker
        Me.dtpFrSync = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.pnlProcessk = New System.Windows.Forms.Panel
        Me.rbCloudSync = New System.Windows.Forms.RadioButton
        Me.pnlAllk.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvDownloadHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvDaySummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.pnlDynamic2.SuspendLayout()
        Me.pnlDynamic.SuspendLayout()
        Me.pnlSyncData.SuspendLayout()
        CType(Me.dgvSyncedData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAllk
        '
        Me.pnlAllk.Controls.Add(Me.Panel2)
        Me.pnlAllk.Controls.Add(Me.Panel1)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(811, 522)
        Me.pnlAllk.TabIndex = 47
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(555, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(256, 522)
        Me.Panel2.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvDownloadHistory)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(200, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(56, 522)
        Me.Panel4.TabIndex = 1
        '
        'dgvDownloadHistory
        '
        Me.dgvDownloadHistory.AllowUserToAddRows = False
        Me.dgvDownloadHistory.BackgroundColor = System.Drawing.Color.White
        Me.dgvDownloadHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDownloadHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDownloadHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDownloadHistory.GridColor = System.Drawing.Color.White
        Me.dgvDownloadHistory.Location = New System.Drawing.Point(0, 48)
        Me.dgvDownloadHistory.Name = "dgvDownloadHistory"
        Me.dgvDownloadHistory.ReadOnly = True
        Me.dgvDownloadHistory.RowHeadersVisible = False
        Me.dgvDownloadHistory.RowHeadersWidth = 12
        Me.dgvDownloadHistory.RowTemplate.Height = 23
        Me.dgvDownloadHistory.Size = New System.Drawing.Size(56, 474)
        Me.dgvDownloadHistory.TabIndex = 21
        '
        'Panel8
        '
        Me.Panel8.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Controls.Add(Me.lblSelectCount)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(56, 48)
        Me.Panel8.TabIndex = 22
        '
        'lblSelectCount
        '
        Me.lblSelectCount.AutoSize = True
        Me.lblSelectCount.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectCount.ForeColor = System.Drawing.Color.White
        Me.lblSelectCount.Location = New System.Drawing.Point(6, 17)
        Me.lblSelectCount.Name = "lblSelectCount"
        Me.lblSelectCount.Size = New System.Drawing.Size(208, 13)
        Me.lblSelectCount.TabIndex = 1
        Me.lblSelectCount.Text = "Selected Date Punch Times Review"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dgvData)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 522)
        Me.Panel3.TabIndex = 0
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mID, Me.DevNm, Me.ipAdd, Me.Port, Me.ConStatus, Me.St})
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(0, 47)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.RowTemplate.Height = 23
        Me.dgvData.Size = New System.Drawing.Size(198, 473)
        Me.dgvData.TabIndex = 19
        '
        'mID
        '
        Me.mID.HeaderText = "Dev No"
        Me.mID.Name = "mID"
        Me.mID.ReadOnly = True
        Me.mID.Width = 88
        '
        'DevNm
        '
        Me.DevNm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DevNm.HeaderText = "Device Name"
        Me.DevNm.Name = "DevNm"
        Me.DevNm.ReadOnly = True
        '
        'ipAdd
        '
        Me.ipAdd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ipAdd.HeaderText = "IP Address"
        Me.ipAdd.Name = "ipAdd"
        Me.ipAdd.ReadOnly = True
        Me.ipAdd.Visible = False
        '
        'Port
        '
        Me.Port.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Port.HeaderText = "Port"
        Me.Port.Name = "Port"
        Me.Port.ReadOnly = True
        Me.Port.Visible = False
        '
        'ConStatus
        '
        Me.ConStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ConStatus.HeaderText = "Status"
        Me.ConStatus.Name = "ConStatus"
        Me.ConStatus.ReadOnly = True
        Me.ConStatus.Visible = False
        '
        'St
        '
        Me.St.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.St.HeaderText = "Status"
        Me.St.Name = "St"
        Me.St.ReadOnly = True
        Me.St.Visible = False
        '
        'Panel7
        '
        Me.Panel7.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Controls.Add(Me.rbCloudSync)
        Me.Panel7.Controls.Add(Me.rdbDownload)
        Me.Panel7.Controls.Add(Me.rdbSync)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(198, 47)
        Me.Panel7.TabIndex = 20
        '
        'rdbDownload
        '
        Me.rdbDownload.AutoSize = True
        Me.rdbDownload.BackColor = System.Drawing.Color.Transparent
        Me.rdbDownload.ForeColor = System.Drawing.Color.White
        Me.rdbDownload.Location = New System.Drawing.Point(7, 4)
        Me.rdbDownload.Name = "rdbDownload"
        Me.rdbDownload.Size = New System.Drawing.Size(81, 17)
        Me.rdbDownload.TabIndex = 71
        Me.rdbDownload.TabStop = True
        Me.rdbDownload.Text = "Download"
        Me.rdbDownload.UseVisualStyleBackColor = False
        '
        'rdbSync
        '
        Me.rdbSync.AutoSize = True
        Me.rdbSync.BackColor = System.Drawing.Color.Transparent
        Me.rdbSync.ForeColor = System.Drawing.Color.White
        Me.rdbSync.Location = New System.Drawing.Point(104, 3)
        Me.rdbSync.Name = "rdbSync"
        Me.rdbSync.Size = New System.Drawing.Size(95, 17)
        Me.rdbSync.TabIndex = 70
        Me.rdbSync.TabStop = True
        Me.rdbSync.Text = "Synchronize"
        Me.rdbSync.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.pnlDynamic2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 522)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgvDaySummary)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 356)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(555, 166)
        Me.Panel5.TabIndex = 1
        '
        'dgvDaySummary
        '
        Me.dgvDaySummary.AllowUserToAddRows = False
        Me.dgvDaySummary.BackgroundColor = System.Drawing.Color.White
        Me.dgvDaySummary.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDaySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDaySummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDaySummary.GridColor = System.Drawing.Color.White
        Me.dgvDaySummary.Location = New System.Drawing.Point(0, 33)
        Me.dgvDaySummary.Name = "dgvDaySummary"
        Me.dgvDaySummary.ReadOnly = True
        Me.dgvDaySummary.RowHeadersVisible = False
        Me.dgvDaySummary.RowHeadersWidth = 12
        Me.dgvDaySummary.RowTemplate.Height = 23
        Me.dgvDaySummary.Size = New System.Drawing.Size(555, 133)
        Me.dgvDaySummary.TabIndex = 20
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.dtpFromDate)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(555, 33)
        Me.Panel6.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(225, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Data Downloading History For Date Of"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "yyyy MMM dd"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(232, 6)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(94, 21)
        Me.dtpFromDate.TabIndex = 67
        '
        'pnlDynamic2
        '
        Me.pnlDynamic2.Controls.Add(Me.pnlDynamic)
        Me.pnlDynamic2.Controls.Add(Me.pnlProcessk)
        Me.pnlDynamic2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDynamic2.Location = New System.Drawing.Point(0, 0)
        Me.pnlDynamic2.Name = "pnlDynamic2"
        Me.pnlDynamic2.Size = New System.Drawing.Size(555, 356)
        Me.pnlDynamic2.TabIndex = 0
        '
        'pnlDynamic
        '
        Me.pnlDynamic.Controls.Add(Me.pnlSyncData)
        Me.pnlDynamic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDynamic.Location = New System.Drawing.Point(0, 0)
        Me.pnlDynamic.Name = "pnlDynamic"
        Me.pnlDynamic.Size = New System.Drawing.Size(555, 256)
        Me.pnlDynamic.TabIndex = 1
        '
        'pnlSyncData
        '
        Me.pnlSyncData.Controls.Add(Me.dgvSyncedData)
        Me.pnlSyncData.Controls.Add(Me.Panel9)
        Me.pnlSyncData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSyncData.Location = New System.Drawing.Point(0, 0)
        Me.pnlSyncData.Name = "pnlSyncData"
        Me.pnlSyncData.Size = New System.Drawing.Size(555, 256)
        Me.pnlSyncData.TabIndex = 0
        '
        'dgvSyncedData
        '
        Me.dgvSyncedData.AllowUserToAddRows = False
        Me.dgvSyncedData.BackgroundColor = System.Drawing.Color.White
        Me.dgvSyncedData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSyncedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSyncedData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSyncedData.GridColor = System.Drawing.Color.White
        Me.dgvSyncedData.Location = New System.Drawing.Point(0, 47)
        Me.dgvSyncedData.Name = "dgvSyncedData"
        Me.dgvSyncedData.ReadOnly = True
        Me.dgvSyncedData.RowHeadersVisible = False
        Me.dgvSyncedData.RowHeadersWidth = 12
        Me.dgvSyncedData.RowTemplate.Height = 23
        Me.dgvSyncedData.Size = New System.Drawing.Size(555, 209)
        Me.dgvSyncedData.TabIndex = 22
        '
        'Panel9
        '
        Me.Panel9.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel9.Controls.Add(Me.Label6)
        Me.Panel9.Controls.Add(Me.Label5)
        Me.Panel9.Controls.Add(Me.btnSearchSync)
        Me.Panel9.Controls.Add(Me.btnSaveSync)
        Me.Panel9.Controls.Add(Me.dtpToSync)
        Me.Panel9.Controls.Add(Me.dtpFrSync)
        Me.Panel9.Controls.Add(Me.Label4)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(555, 47)
        Me.Panel9.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(368, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(223, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "From"
        '
        'btnSearchSync
        '
        Me.btnSearchSync.BackColor = System.Drawing.Color.Transparent
        Me.btnSearchSync.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.btnSearchSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSearchSync.FlatAppearance.BorderSize = 0
        Me.btnSearchSync.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btnSearchSync.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSearchSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSync.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchSync.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSearchSync.Location = New System.Drawing.Point(494, 12)
        Me.btnSearchSync.Name = "btnSearchSync"
        Me.btnSearchSync.Size = New System.Drawing.Size(24, 24)
        Me.btnSearchSync.TabIndex = 76
        Me.btnSearchSync.Tag = "3"
        Me.btnSearchSync.UseVisualStyleBackColor = False
        '
        'btnSaveSync
        '
        Me.btnSaveSync.BackColor = System.Drawing.Color.Transparent
        Me.btnSaveSync.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.btnSaveSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnSaveSync.FlatAppearance.BorderSize = 0
        Me.btnSaveSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSync.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSync.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSaveSync.Location = New System.Drawing.Point(524, 10)
        Me.btnSaveSync.Name = "btnSaveSync"
        Me.btnSaveSync.Size = New System.Drawing.Size(28, 28)
        Me.btnSaveSync.TabIndex = 71
        Me.btnSaveSync.Tag = "3"
        Me.btnSaveSync.UseVisualStyleBackColor = False
        '
        'dtpToSync
        '
        Me.dtpToSync.CustomFormat = "yyyy MMM dd"
        Me.dtpToSync.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToSync.Location = New System.Drawing.Point(391, 12)
        Me.dtpToSync.Name = "dtpToSync"
        Me.dtpToSync.Size = New System.Drawing.Size(94, 21)
        Me.dtpToSync.TabIndex = 69
        '
        'dtpFrSync
        '
        Me.dtpFrSync.CustomFormat = "yyyy MMM dd"
        Me.dtpFrSync.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrSync.Location = New System.Drawing.Point(263, 12)
        Me.dtpFrSync.Name = "dtpFrSync"
        Me.dtpFrSync.Size = New System.Drawing.Size(94, 21)
        Me.dtpFrSync.TabIndex = 68
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(195, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Select date range to synchronize"
        '
        'pnlProcessk
        '
        Me.pnlProcessk.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlProcessk.Location = New System.Drawing.Point(0, 256)
        Me.pnlProcessk.Name = "pnlProcessk"
        Me.pnlProcessk.Size = New System.Drawing.Size(555, 100)
        Me.pnlProcessk.TabIndex = 0
        '
        'rbCloudSync
        '
        Me.rbCloudSync.AutoSize = True
        Me.rbCloudSync.BackColor = System.Drawing.Color.Transparent
        Me.rbCloudSync.ForeColor = System.Drawing.Color.White
        Me.rbCloudSync.Location = New System.Drawing.Point(7, 24)
        Me.rbCloudSync.Name = "rbCloudSync"
        Me.rbCloudSync.Size = New System.Drawing.Size(90, 17)
        Me.rbCloudSync.TabIndex = 73
        Me.rbCloudSync.TabStop = True
        Me.rbCloudSync.Text = "Cloud Sync"
        Me.rbCloudSync.UseVisualStyleBackColor = False
        '
        'frmDownSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(811, 522)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDownSelector"
        Me.Text = "frmDownSelector"
        Me.pnlAllk.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvDownloadHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvDaySummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlDynamic2.ResumeLayout(False)
        Me.pnlDynamic.ResumeLayout(False)
        Me.pnlSyncData.ResumeLayout(False)
        CType(Me.dgvSyncedData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents mID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DevNm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ipAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents St As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlDynamic2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dgvDaySummary As System.Windows.Forms.DataGridView
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvDownloadHistory As System.Windows.Forms.DataGridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lblSelectCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlProcessk As System.Windows.Forms.Panel
    Friend WithEvents pnlDynamic As System.Windows.Forms.Panel
    Friend WithEvents pnlSyncData As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents dtpToSync As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrSync As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSaveSync As System.Windows.Forms.Button
    Friend WithEvents dgvSyncedData As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearchSync As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdbDownload As System.Windows.Forms.RadioButton
    Friend WithEvents rdbSync As System.Windows.Forms.RadioButton
    Friend WithEvents rbCloudSync As System.Windows.Forms.RadioButton
End Class
