<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataZKFace302D
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataZKFace302D))
        Me.pgbUpdate = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvInfo = New System.Windows.Forms.DataGridView
        Me.mID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DevNm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ipAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.St = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grbDevice = New System.Windows.Forms.GroupBox
        Me.lblState = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.grbFileka = New System.Windows.Forms.GroupBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.Cnt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VryMode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Input = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ddDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.atTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WrkCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdOpen = New System.Windows.Forms.Button
        Me.optFile = New System.Windows.Forms.RadioButton
        Me.optDevice = New System.Windows.Forms.RadioButton
        Me.ofdFile = New System.Windows.Forms.OpenFileDialog
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdDownload_D = New System.Windows.Forms.Button
        Me.cmdnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdDownload = New System.Windows.Forms.Button
        Me.cmdConnect = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbDevice.SuspendLayout()
        Me.grbFileka.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pgbUpdate
        '
        Me.pgbUpdate.Dock = System.Windows.Forms.DockStyle.Top
        Me.pgbUpdate.Location = New System.Drawing.Point(0, 48)
        Me.pgbUpdate.Name = "pgbUpdate"
        Me.pgbUpdate.Size = New System.Drawing.Size(555, 6)
        Me.pgbUpdate.TabIndex = 22
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvInfo)
        Me.GroupBox2.Controls.Add(Me.grbDevice)
        Me.GroupBox2.Controls.Add(Me.grbFileka)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 77)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(539, 198)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Device Information"
        '
        'dgvInfo
        '
        Me.dgvInfo.AllowUserToAddRows = False
        Me.dgvInfo.BackgroundColor = System.Drawing.Color.White
        Me.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mID, Me.DevNm, Me.ipAdd, Me.Port, Me.ConStatus, Me.St})
        Me.dgvInfo.GridColor = System.Drawing.Color.White
        Me.dgvInfo.Location = New System.Drawing.Point(3, 15)
        Me.dgvInfo.Name = "dgvInfo"
        Me.dgvInfo.ReadOnly = True
        Me.dgvInfo.RowHeadersVisible = False
        Me.dgvInfo.RowHeadersWidth = 12
        Me.dgvInfo.RowTemplate.Height = 23
        Me.dgvInfo.Size = New System.Drawing.Size(251, 137)
        Me.dgvInfo.TabIndex = 18
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
        'grbDevice
        '
        Me.grbDevice.Controls.Add(Me.lblState)
        Me.grbDevice.Controls.Add(Me.Label1)
        Me.grbDevice.Controls.Add(Me.txtIP)
        Me.grbDevice.Controls.Add(Me.Label2)
        Me.grbDevice.Controls.Add(Me.txtPort)
        Me.grbDevice.Location = New System.Drawing.Point(386, 12)
        Me.grbDevice.Name = "grbDevice"
        Me.grbDevice.Size = New System.Drawing.Size(145, 140)
        Me.grbDevice.TabIndex = 21
        Me.grbDevice.TabStop = False
        Me.grbDevice.Text = "Download from Device"
        Me.grbDevice.Visible = False
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblState.ForeColor = System.Drawing.Color.Navy
        Me.lblState.Location = New System.Drawing.Point(48, 113)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(185, 13)
        Me.lblState.TabIndex = 20
        Me.lblState.Text = "Current State:Disconnected"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "IP Address |"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIP
        '
        Me.txtIP.BackColor = System.Drawing.Color.White
        Me.txtIP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIP.Location = New System.Drawing.Point(125, 21)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(108, 21)
        Me.txtIP.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Port |"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.Color.White
        Me.txtPort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(125, 47)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(108, 21)
        Me.txtPort.TabIndex = 16
        '
        'grbFileka
        '
        Me.grbFileka.Controls.Add(Me.ListBox1)
        Me.grbFileka.Controls.Add(Me.TextBox1)
        Me.grbFileka.Controls.Add(Me.Button1)
        Me.grbFileka.Controls.Add(Me.Label3)
        Me.grbFileka.Location = New System.Drawing.Point(256, 12)
        Me.grbFileka.Name = "grbFileka"
        Me.grbFileka.Size = New System.Drawing.Size(172, 140)
        Me.grbFileka.TabIndex = 21
        Me.grbFileka.TabStop = False
        Me.grbFileka.Text = "Select the File"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(16, 165)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(296, 82)
        Me.ListBox1.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(105, 16)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(155, 23)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Location = New System.Drawing.Point(722, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(167, 41)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "DOWNLOAD"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Select File |"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.dgvData)
        Me.GroupBox3.Location = New System.Drawing.Point(285, 160)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(45, 32)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Downloaded Data"
        Me.GroupBox3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, -12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(12, 38)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Cnt, Me.EmpID, Me.VryMode, Me.Input, Me.ddDate, Me.atTime, Me.WrkCode})
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(3, 17)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowTemplate.Height = 23
        Me.dgvData.Size = New System.Drawing.Size(39, 12)
        Me.dgvData.TabIndex = 0
        '
        'Cnt
        '
        Me.Cnt.HeaderText = "Count"
        Me.Cnt.Name = "Cnt"
        Me.Cnt.ReadOnly = True
        Me.Cnt.Width = 80
        '
        'EmpID
        '
        Me.EmpID.HeaderText = "Employee ID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        '
        'VryMode
        '
        Me.VryMode.HeaderText = "Verify Mode"
        Me.VryMode.Name = "VryMode"
        Me.VryMode.ReadOnly = True
        '
        'Input
        '
        Me.Input.HeaderText = "Input"
        Me.Input.Name = "Input"
        Me.Input.ReadOnly = True
        Me.Input.Width = 60
        '
        'ddDate
        '
        Me.ddDate.HeaderText = "Date"
        Me.ddDate.Name = "ddDate"
        Me.ddDate.ReadOnly = True
        Me.ddDate.Width = 80
        '
        'atTime
        '
        Me.atTime.HeaderText = "Time"
        Me.atTime.Name = "atTime"
        Me.atTime.ReadOnly = True
        Me.atTime.Width = 80
        '
        'WrkCode
        '
        Me.WrkCode.HeaderText = "Work Code"
        Me.WrkCode.Name = "WrkCode"
        Me.WrkCode.ReadOnly = True
        Me.WrkCode.Width = 90
        '
        'cmdOpen
        '
        Me.cmdOpen.BackColor = System.Drawing.Color.Transparent
        Me.cmdOpen.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasnFile
        Me.cmdOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdOpen.FlatAppearance.BorderSize = 0
        Me.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOpen.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpen.ForeColor = System.Drawing.Color.White
        Me.cmdOpen.Location = New System.Drawing.Point(442, 10)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(28, 28)
        Me.cmdOpen.TabIndex = 2
        Me.cmdOpen.Tag = "1"
        Me.cmdOpen.UseVisualStyleBackColor = False
        '
        'optFile
        '
        Me.optFile.AutoSize = True
        Me.optFile.Location = New System.Drawing.Point(153, 56)
        Me.optFile.Name = "optFile"
        Me.optFile.Size = New System.Drawing.Size(77, 17)
        Me.optFile.TabIndex = 20
        Me.optFile.Text = "From File"
        Me.optFile.UseVisualStyleBackColor = True
        Me.optFile.Visible = False
        '
        'optDevice
        '
        Me.optDevice.AutoSize = True
        Me.optDevice.Checked = True
        Me.optDevice.Location = New System.Drawing.Point(13, 56)
        Me.optDevice.Name = "optDevice"
        Me.optDevice.Size = New System.Drawing.Size(97, 17)
        Me.optDevice.TabIndex = 20
        Me.optDevice.TabStop = True
        Me.optDevice.Text = "From Device"
        Me.optDevice.UseVisualStyleBackColor = True
        '
        'ofdFile
        '
        Me.ofdFile.FileName = "OpenFileDialog1"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(555, 2)
        Me.Label7.TabIndex = 57
        '
        'cmdDownload_D
        '
        Me.cmdDownload_D.BackColor = System.Drawing.Color.Transparent
        Me.cmdDownload_D.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdDownload_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDownload_D.FlatAppearance.BorderSize = 0
        Me.cmdDownload_D.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDownload_D.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownload_D.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdDownload_D.Location = New System.Drawing.Point(361, 9)
        Me.cmdDownload_D.Name = "cmdDownload_D"
        Me.cmdDownload_D.Size = New System.Drawing.Size(88, 26)
        Me.cmdDownload_D.TabIndex = 22
        Me.cmdDownload_D.Tag = "1"
        Me.cmdDownload_D.Text = "Download"
        Me.cmdDownload_D.UseVisualStyleBackColor = False
        '
        'cmdnClose
        '
        Me.cmdnClose.BackColor = System.Drawing.Color.Transparent
        Me.cmdnClose.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdnClose.FlatAppearance.BorderSize = 0
        Me.cmdnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdnClose.Location = New System.Drawing.Point(455, 9)
        Me.cmdnClose.Name = "cmdnClose"
        Me.cmdnClose.Size = New System.Drawing.Size(88, 26)
        Me.cmdnClose.TabIndex = 22
        Me.cmdnClose.Tag = "1"
        Me.cmdnClose.Text = "Close"
        Me.cmdnClose.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.cmdOpen)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.cmdDownload)
        Me.Panel1.Controls.Add(Me.cmdConnect)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 48)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Tag = "1"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(520, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 49
        Me.Button3.Tag = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Connect
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.Location = New System.Drawing.Point(479, 10)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 28)
        Me.Button4.TabIndex = 50
        Me.Button4.Tag = "3"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(7, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(62, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(339, 18)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Download Data (ZK Face Detection 302)"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdDownload
        '
        Me.cmdDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdDownload.Location = New System.Drawing.Point(722, 40)
        Me.cmdDownload.Name = "cmdDownload"
        Me.cmdDownload.Size = New System.Drawing.Size(12, 12)
        Me.cmdDownload.TabIndex = 19
        Me.cmdDownload.Text = "DOWNLOAD"
        Me.cmdDownload.UseVisualStyleBackColor = True
        Me.cmdDownload.Visible = False
        '
        'cmdConnect
        '
        Me.cmdConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdConnect.Location = New System.Drawing.Point(520, 50)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(12, 11)
        Me.cmdConnect.TabIndex = 19
        Me.cmdConnect.Text = "CONNECT"
        Me.cmdConnect.UseVisualStyleBackColor = True
        Me.cmdConnect.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdRefresh)
        Me.GroupBox1.Location = New System.Drawing.Point(808, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(66, 17)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attendance Download"
        Me.GroupBox1.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(17, 407)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(304, 41)
        Me.cmdRefresh.TabIndex = 19
        Me.cmdRefresh.Text = "REFRESH"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        Me.cmdRefresh.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.ForeColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.Location = New System.Drawing.Point(456, 58)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(80, 13)
        Me.LinkLabel1.TabIndex = 21
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Clear All Log"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblDesciption)
        Me.Panel2.Controls.Add(Me.cmdnClose)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmdDownload_D)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 312)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(555, 44)
        Me.Panel2.TabIndex = 60
        Me.Panel2.Tag = "1"
        Me.Panel2.Visible = False
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.Location = New System.Drawing.Point(9, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(317, 13)
        Me.lblDesciption.TabIndex = 58
        Me.lblDesciption.Text = "Connect to device or select log file and click download"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDataZKFace302D
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(555, 356)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.pgbUpdate)
        Me.Controls.Add(Me.optFile)
        Me.Controls.Add(Me.optDevice)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDataZKFace302D"
        Me.Text = "DOWNLOAD ATTENDANCE DATA"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbDevice.ResumeLayout(False)
        Me.grbDevice.PerformLayout()
        Me.grbFileka.ResumeLayout(False)
        Me.grbFileka.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInfo As System.Windows.Forms.DataGridView
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdDownload As System.Windows.Forms.Button
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Private WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Cnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Input As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ddDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents atTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WrkCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents optDevice As System.Windows.Forms.RadioButton
    Friend WithEvents optFile As System.Windows.Forms.RadioButton
    Friend WithEvents grbFileka As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ofdFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents grbDevice As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pgbUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdDownload_D As System.Windows.Forms.Button
    Friend WithEvents cmdnClose As System.Windows.Forms.Button
    Friend WithEvents mID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DevNm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ipAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents St As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
