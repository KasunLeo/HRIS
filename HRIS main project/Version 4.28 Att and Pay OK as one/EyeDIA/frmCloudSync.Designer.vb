<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCloudSync
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
        Me.btnConnectrmtSvr = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.btnDownload = New System.Windows.Forms.Button
        Me.lblStatus = New System.Windows.Forms.Label
        Me.dgvDownCloud = New System.Windows.Forms.DataGridView
        Me.btnSave = New System.Windows.Forms.Button
        Me.lblRowCount = New System.Windows.Forms.Label
        Me.pgbUpdate = New System.Windows.Forms.ProgressBar
        Me.txtLocationID = New System.Windows.Forms.TextBox
        Me.txtDeviceID = New System.Windows.Forms.TextBox
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LocationID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.crLine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VrfyMode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Input = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cDatec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WrkCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.capture = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EditMode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvDownCloud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConnectrmtSvr
        '
        Me.btnConnectrmtSvr.Location = New System.Drawing.Point(778, 51)
        Me.btnConnectrmtSvr.Name = "btnConnectrmtSvr"
        Me.btnConnectrmtSvr.Size = New System.Drawing.Size(75, 23)
        Me.btnConnectrmtSvr.TabIndex = 0
        Me.btnConnectrmtSvr.Text = "Connect"
        Me.btnConnectrmtSvr.UseVisualStyleBackColor = True
        Me.btnConnectrmtSvr.Visible = False
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(778, 161)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        Me.btnDownload.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(3, 6)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(196, 13)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.Text = "Current State : Not Connected to Server"
        '
        'dgvDownCloud
        '
        Me.dgvDownCloud.AllowUserToAddRows = False
        Me.dgvDownCloud.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvDownCloud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDownCloud.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LocationID, Me.crLine, Me.EmpID, Me.VrfyMode, Me.Input, Me.cDatec, Me.cTime, Me.WrkCode, Me.capture, Me.tTime, Me.EditMode, Me.dAID, Me.dStatus})
        Me.dgvDownCloud.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDownCloud.GridColor = System.Drawing.Color.White
        Me.dgvDownCloud.Location = New System.Drawing.Point(0, 0)
        Me.dgvDownCloud.Name = "dgvDownCloud"
        Me.dgvDownCloud.ReadOnly = True
        Me.dgvDownCloud.RowHeadersVisible = False
        Me.dgvDownCloud.RowHeadersWidth = 12
        Me.dgvDownCloud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDownCloud.Size = New System.Drawing.Size(524, 168)
        Me.dgvDownCloud.TabIndex = 85
        Me.dgvDownCloud.Tag = "1"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(778, 80)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 86
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'lblRowCount
        '
        Me.lblRowCount.AutoSize = True
        Me.lblRowCount.Location = New System.Drawing.Point(394, 6)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRowCount.Size = New System.Drawing.Size(50, 13)
        Me.lblRowCount.TabIndex = 87
        Me.lblRowCount.Text = "Count : 0"
        '
        'pgbUpdate
        '
        Me.pgbUpdate.Dock = System.Windows.Forms.DockStyle.Top
        Me.pgbUpdate.Location = New System.Drawing.Point(0, 0)
        Me.pgbUpdate.Name = "pgbUpdate"
        Me.pgbUpdate.Size = New System.Drawing.Size(524, 2)
        Me.pgbUpdate.TabIndex = 88
        '
        'txtLocationID
        '
        Me.txtLocationID.Location = New System.Drawing.Point(597, 1)
        Me.txtLocationID.Name = "txtLocationID"
        Me.txtLocationID.Size = New System.Drawing.Size(100, 20)
        Me.txtLocationID.TabIndex = 89
        Me.txtLocationID.Visible = False
        '
        'txtDeviceID
        '
        Me.txtDeviceID.Location = New System.Drawing.Point(597, 27)
        Me.txtDeviceID.Name = "txtDeviceID"
        Me.txtDeviceID.Size = New System.Drawing.Size(100, 20)
        Me.txtDeviceID.TabIndex = 90
        Me.txtDeviceID.Visible = False
        '
        'Panel9
        '
        Me.Panel9.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel9.Controls.Add(Me.Button3)
        Me.Panel9.Controls.Add(Me.Button4)
        Me.Panel9.Controls.Add(Me.PictureBox1)
        Me.Panel9.Controls.Add(Me.txtDeviceID)
        Me.Panel9.Controls.Add(Me.Label25)
        Me.Panel9.Controls.Add(Me.txtLocationID)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(524, 47)
        Me.Panel9.TabIndex = 91
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
        Me.Button3.Location = New System.Drawing.Point(431, 8)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(31, 28)
        Me.Button3.TabIndex = 47
        Me.Button3.Tag = "5"
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
        Me.Button4.Location = New System.Drawing.Point(397, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 28)
        Me.Button4.TabIndex = 48
        Me.Button4.Tag = "5"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(63, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(182, 18)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "Download Cloud Data"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblRowCount)
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 215)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 28)
        Me.Panel1.TabIndex = 92
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pgbUpdate)
        Me.Panel2.Controls.Add(Me.dgvDownCloud)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(524, 168)
        Me.Panel2.TabIndex = 93
        '
        'LocationID
        '
        Me.LocationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.LocationID.DataPropertyName = "LocationID"
        Me.LocationID.HeaderText = "LocationID"
        Me.LocationID.Name = "LocationID"
        Me.LocationID.ReadOnly = True
        Me.LocationID.Width = 84
        '
        'crLine
        '
        Me.crLine.DataPropertyName = "crLine"
        Me.crLine.HeaderText = "crLine"
        Me.crLine.Name = "crLine"
        Me.crLine.ReadOnly = True
        Me.crLine.Visible = False
        '
        'EmpID
        '
        Me.EmpID.DataPropertyName = "EmpID"
        Me.EmpID.HeaderText = "EmpID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        '
        'VrfyMode
        '
        Me.VrfyMode.DataPropertyName = "VrfyMode"
        Me.VrfyMode.HeaderText = "VrfyMode"
        Me.VrfyMode.Name = "VrfyMode"
        Me.VrfyMode.ReadOnly = True
        Me.VrfyMode.Visible = False
        '
        'Input
        '
        Me.Input.DataPropertyName = "Input"
        Me.Input.HeaderText = "Input"
        Me.Input.Name = "Input"
        Me.Input.ReadOnly = True
        Me.Input.Visible = False
        '
        'cDatec
        '
        Me.cDatec.DataPropertyName = "cDate"
        Me.cDatec.HeaderText = "cDatec"
        Me.cDatec.Name = "cDatec"
        Me.cDatec.ReadOnly = True
        Me.cDatec.Visible = False
        '
        'cTime
        '
        Me.cTime.DataPropertyName = "cTime"
        Me.cTime.HeaderText = "cTime"
        Me.cTime.Name = "cTime"
        Me.cTime.ReadOnly = True
        Me.cTime.Visible = False
        '
        'WrkCode
        '
        Me.WrkCode.DataPropertyName = "WrkCode"
        Me.WrkCode.HeaderText = "WrkCode"
        Me.WrkCode.Name = "WrkCode"
        Me.WrkCode.ReadOnly = True
        Me.WrkCode.Visible = False
        '
        'capture
        '
        Me.capture.DataPropertyName = "capture"
        Me.capture.HeaderText = "capture"
        Me.capture.Name = "capture"
        Me.capture.ReadOnly = True
        Me.capture.Visible = False
        '
        'tTime
        '
        Me.tTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tTime.DataPropertyName = "tTime"
        Me.tTime.HeaderText = "Time"
        Me.tTime.Name = "tTime"
        Me.tTime.ReadOnly = True
        '
        'EditMode
        '
        Me.EditMode.DataPropertyName = "EditMode"
        Me.EditMode.HeaderText = "EditMode"
        Me.EditMode.Name = "EditMode"
        Me.EditMode.ReadOnly = True
        Me.EditMode.Visible = False
        '
        'dAID
        '
        Me.dAID.DataPropertyName = "dAID"
        Me.dAID.HeaderText = "Batch ID "
        Me.dAID.Name = "dAID"
        Me.dAID.ReadOnly = True
        '
        'dStatus
        '
        Me.dStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.dStatus.DataPropertyName = "dStatus"
        Me.dStatus.HeaderText = "Status"
        Me.dStatus.Name = "dStatus"
        Me.dStatus.ReadOnly = True
        Me.dStatus.Width = 62
        '
        'frmCloudSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(524, 243)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.btnConnectrmtSvr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCloudSync"
        Me.Text = "frmCloudSync"
        CType(Me.dgvDownCloud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConnectrmtSvr As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents dgvDownCloud As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblRowCount As System.Windows.Forms.Label
    Friend WithEvents pgbUpdate As System.Windows.Forms.ProgressBar
    Friend WithEvents txtLocationID As System.Windows.Forms.TextBox
    Friend WithEvents txtDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents crLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VrfyMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Input As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cDatec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WrkCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents capture As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
