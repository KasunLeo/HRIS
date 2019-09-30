<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeviceInfo
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.chkIsNetwork = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbDownload = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.chkRemort = New System.Windows.Forms.CheckBox
        Me.pbCount = New System.Windows.Forms.ProgressBar
        Me.dtpInsDate = New System.Windows.Forms.DateTimePicker
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.chkStatus = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.dsgID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dsgName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDivNo = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.pnlAllData = New System.Windows.Forms.Panel
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.txtLocationID = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtLocationID)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.chkIsNetwork)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.cmbDownload)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.chkRemort)
        Me.Panel2.Controls.Add(Me.pbCount)
        Me.Panel2.Controls.Add(Me.dtpInsDate)
        Me.Panel2.Controls.Add(Me.txtIPAddress)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Controls.Add(Me.chkStatus)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.dgvData)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtPort)
        Me.Panel2.Controls.Add(Me.txtDesc)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtDivNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(678, 430)
        Me.Panel2.TabIndex = 9
        '
        'chkIsNetwork
        '
        Me.chkIsNetwork.AutoSize = True
        Me.chkIsNetwork.Location = New System.Drawing.Point(9, 318)
        Me.chkIsNetwork.Name = "chkIsNetwork"
        Me.chkIsNetwork.Size = New System.Drawing.Size(89, 17)
        Me.chkIsNetwork.TabIndex = 114
        Me.chkIsNetwork.Text = "In Network"
        Me.chkIsNetwork.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(351, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(298, 2)
        Me.Label17.TabIndex = 112
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(262, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 111
        Me.Label9.Text = "Devices List"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblDesciption)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 386)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(678, 44)
        Me.Panel3.TabIndex = 10
        Me.Panel3.Tag = ""
        Me.Panel3.Visible = False
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.Location = New System.Drawing.Point(9, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(229, 13)
        Me.lblDesciption.TabIndex = 26
        Me.lblDesciption.Text = "Add all devices(terminals) information "
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(678, 2)
        Me.Label3.TabIndex = 25
        '
        'cmbDownload
        '
        Me.cmbDownload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDownload.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDownload.FormattingEnabled = True
        Me.cmbDownload.Items.AddRange(New Object() {"Realand 50 T", "ZK Before INO1 Device", "Realand Device New", "Realand Face Detetion", "ZK K14 Device", "ZK Device File Only", "ZK Face Detection"})
        Me.cmbDownload.Location = New System.Drawing.Point(9, 245)
        Me.cmbDownload.Name = "cmbDownload"
        Me.cmbDownload.Size = New System.Drawing.Size(247, 21)
        Me.cmbDownload.TabIndex = 66
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 229)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "Download Form"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkRemort
        '
        Me.chkRemort.AutoSize = True
        Me.chkRemort.Location = New System.Drawing.Point(9, 272)
        Me.chkRemort.Name = "chkRemort"
        Me.chkRemort.Size = New System.Drawing.Size(150, 17)
        Me.chkRemort.TabIndex = 26
        Me.chkRemort.Text = "Remort Finger Device"
        Me.chkRemort.UseVisualStyleBackColor = True
        Me.chkRemort.Visible = False
        '
        'pbCount
        '
        Me.pbCount.Dock = System.Windows.Forms.DockStyle.Top
        Me.pbCount.Location = New System.Drawing.Point(0, 0)
        Me.pbCount.Name = "pbCount"
        Me.pbCount.Size = New System.Drawing.Size(678, 4)
        Me.pbCount.TabIndex = 22
        '
        'dtpInsDate
        '
        Me.dtpInsDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpInsDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInsDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInsDate.Location = New System.Drawing.Point(9, 115)
        Me.dtpInsDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpInsDate.Name = "dtpInsDate"
        Me.dtpInsDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpInsDate.TabIndex = 2
        '
        'txtIPAddress
        '
        Me.txtIPAddress.BackColor = System.Drawing.Color.White
        Me.txtIPAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIPAddress.Location = New System.Drawing.Point(9, 161)
        Me.txtIPAddress.MaxLength = 20
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(121, 21)
        Me.txtIPAddress.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Device ID "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(9, 22)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(112, 21)
        Me.txtCode.TabIndex = 0
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.Location = New System.Drawing.Point(9, 295)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(80, 17)
        Me.chkStatus.TabIndex = 21
        Me.chkStatus.Text = "Removed"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Description "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Installation Date "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dsgID, Me.dsgName, Me.st})
        Me.dgvData.Location = New System.Drawing.Point(265, 28)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(390, 352)
        Me.dgvData.TabIndex = 20
        Me.dgvData.Tag = "1"
        '
        'dsgID
        '
        Me.dsgID.HeaderText = "ID "
        Me.dsgID.Name = "dsgID"
        Me.dsgID.ReadOnly = True
        Me.dsgID.Width = 77
        '
        'dsgName
        '
        Me.dsgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dsgName.HeaderText = "Description"
        Me.dsgName.Name = "dsgName"
        Me.dsgName.ReadOnly = True
        '
        'st
        '
        Me.st.HeaderText = "status"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        Me.st.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(134, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Device Number "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.Color.White
        Me.txtPort.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(137, 161)
        Me.txtPort.MaxLength = 10
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(119, 21)
        Me.txtPort.TabIndex = 5
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.Color.White
        Me.txtDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(9, 66)
        Me.txtDesc.MaxLength = 30
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(247, 21)
        Me.txtDesc.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "IP Address "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(134, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Device Port "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDivNo
        '
        Me.txtDivNo.BackColor = System.Drawing.Color.White
        Me.txtDivNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDivNo.Location = New System.Drawing.Point(137, 115)
        Me.txtDivNo.MaxLength = 10
        Me.txtDivNo.Name = "txtDivNo"
        Me.txtDivNo.Size = New System.Drawing.Size(119, 21)
        Me.txtDivNo.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(678, 48)
        Me.Panel1.TabIndex = 8
        Me.Panel1.Tag = "1"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdSave.Location = New System.Drawing.Point(582, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 45
        Me.cmdSave.Tag = "3"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRefresh.Location = New System.Drawing.Point(618, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 46
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(11, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(66, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(180, 14)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Setup Device  Information"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAllData
        '
        Me.pnlAllData.Controls.Add(Me.Panel2)
        Me.pnlAllData.Controls.Add(Me.Panel1)
        Me.pnlAllData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllData.Location = New System.Drawing.Point(223, 0)
        Me.pnlAllData.Name = "pnlAllData"
        Me.pnlAllData.Size = New System.Drawing.Size(678, 478)
        Me.pnlAllData.TabIndex = 113
        '
        'pnlLeft
        '
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(223, 478)
        Me.pnlLeft.TabIndex = 114
        '
        'txtLocationID
        '
        Me.txtLocationID.BackColor = System.Drawing.Color.White
        Me.txtLocationID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocationID.Location = New System.Drawing.Point(9, 204)
        Me.txtLocationID.MaxLength = 10
        Me.txtLocationID.Name = "txtLocationID"
        Me.txtLocationID.Size = New System.Drawing.Size(119, 21)
        Me.txtLocationID.TabIndex = 115
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 188)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "Location ID"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDeviceInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(901, 478)
        Me.Controls.Add(Me.pnlAllData)
        Me.Controls.Add(Me.pnlLeft)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDeviceInfo"
        Me.Text = "Device Information Setup ...."
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllData.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkRemort As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pbCount As System.Windows.Forms.ProgressBar
    Friend WithEvents dtpInsDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDivNo As System.Windows.Forms.TextBox
    Friend WithEvents dsgID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dsgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbDownload As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents pnlAllData As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents chkIsNetwork As System.Windows.Forms.CheckBox
    Friend WithEvents txtLocationID As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
