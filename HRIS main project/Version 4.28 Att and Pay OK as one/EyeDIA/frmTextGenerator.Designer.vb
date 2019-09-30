<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextGenerator
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.lblLast = New System.Windows.Forms.Label
        Me.dgvBranches = New System.Windows.Forms.DataGridView
        Me.chkTr = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.brID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.brName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rdDefault = New System.Windows.Forms.RadioButton
        Me.pgb = New System.Windows.Forms.ProgressBar
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.MacID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DefCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DefCol2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TimeD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rdbHRIS = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.rdbK14 = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.dgvTransfer = New System.Windows.Forms.DataGridView
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBranches, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAll)
        Me.GroupBox1.Controls.Add(Me.lblLast)
        Me.GroupBox1.Controls.Add(Me.dgvBranches)
        Me.GroupBox1.Controls.Add(Me.rdDefault)
        Me.GroupBox1.Controls.Add(Me.pgb)
        Me.GroupBox1.Controls.Add(Me.dgvData)
        Me.GroupBox1.Controls.Add(Me.rdbHRIS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rdbK14)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpFrDate)
        Me.GroupBox1.Controls.Add(Me.dtpEndDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(835, 420)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Location = New System.Drawing.Point(592, 24)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(15, 14)
        Me.chkAll.TabIndex = 48
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'lblLast
        '
        Me.lblLast.AutoSize = True
        Me.lblLast.Location = New System.Drawing.Point(6, 386)
        Me.lblLast.Name = "lblLast"
        Me.lblLast.Size = New System.Drawing.Size(0, 13)
        Me.lblLast.TabIndex = 48
        '
        'dgvBranches
        '
        Me.dgvBranches.AllowUserToAddRows = False
        Me.dgvBranches.AllowUserToDeleteRows = False
        Me.dgvBranches.BackgroundColor = System.Drawing.Color.White
        Me.dgvBranches.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBranches.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkTr, Me.brID, Me.brName})
        Me.dgvBranches.GridColor = System.Drawing.Color.White
        Me.dgvBranches.Location = New System.Drawing.Point(586, 20)
        Me.dgvBranches.Name = "dgvBranches"
        Me.dgvBranches.RowHeadersVisible = False
        Me.dgvBranches.RowHeadersWidth = 12
        Me.dgvBranches.Size = New System.Drawing.Size(230, 210)
        Me.dgvBranches.TabIndex = 47
        Me.dgvBranches.Tag = "1"
        '
        'chkTr
        '
        Me.chkTr.HeaderText = "  "
        Me.chkTr.Name = "chkTr"
        Me.chkTr.Width = 24
        '
        'brID
        '
        Me.brID.HeaderText = "ID"
        Me.brID.Name = "brID"
        Me.brID.Visible = False
        Me.brID.Width = 67
        '
        'brName
        '
        Me.brName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.brName.HeaderText = "Branch Name"
        Me.brName.Name = "brName"
        '
        'rdDefault
        '
        Me.rdDefault.AutoSize = True
        Me.rdDefault.Location = New System.Drawing.Point(176, 20)
        Me.rdDefault.Name = "rdDefault"
        Me.rdDefault.Size = New System.Drawing.Size(72, 17)
        Me.rdDefault.TabIndex = 47
        Me.rdDefault.TabStop = True
        Me.rdDefault.Text = "Scienter"
        Me.rdDefault.UseVisualStyleBackColor = True
        '
        'pgb
        '
        Me.pgb.Location = New System.Drawing.Point(0, 408)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(835, 6)
        Me.pgb.TabIndex = 10
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MacID, Me.DefCol, Me.EmpID, Me.DefCol2, Me.DateD, Me.TimeD})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(73, 196)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(282, 34)
        Me.dgvData.TabIndex = 15
        Me.dgvData.Tag = "1"
        Me.dgvData.Visible = False
        '
        'MacID
        '
        Me.MacID.HeaderText = "MacID"
        Me.MacID.Name = "MacID"
        Me.MacID.ReadOnly = True
        '
        'DefCol
        '
        Me.DefCol.HeaderText = "Defcol"
        Me.DefCol.Name = "DefCol"
        Me.DefCol.ReadOnly = True
        '
        'EmpID
        '
        Me.EmpID.HeaderText = "EmpID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        '
        'DefCol2
        '
        Me.DefCol2.HeaderText = "DefCol2"
        Me.DefCol2.Name = "DefCol2"
        Me.DefCol2.ReadOnly = True
        '
        'DateD
        '
        Me.DateD.HeaderText = "DateD"
        Me.DateD.Name = "DateD"
        Me.DateD.ReadOnly = True
        '
        'TimeD
        '
        Me.TimeD.HeaderText = "TimeD"
        Me.TimeD.Name = "TimeD"
        Me.TimeD.ReadOnly = True
        '
        'rdbHRIS
        '
        Me.rdbHRIS.AutoSize = True
        Me.rdbHRIS.Location = New System.Drawing.Point(282, 20)
        Me.rdbHRIS.Name = "rdbHRIS"
        Me.rdbHRIS.Size = New System.Drawing.Size(63, 17)
        Me.rdbHRIS.TabIndex = 46
        Me.rdbHRIS.TabStop = True
        Me.rdbHRIS.Text = "HRIS"
        Me.rdbHRIS.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(53, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "To Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdbK14
        '
        Me.rdbK14.AutoSize = True
        Me.rdbK14.Location = New System.Drawing.Point(379, 20)
        Me.rdbK14.Name = "rdbK14"
        Me.rdbK14.Size = New System.Drawing.Size(66, 17)
        Me.rdbK14.TabIndex = 45
        Me.rdbK14.TabStop = True
        Me.rdbK14.Text = "Zk-K14"
        Me.rdbK14.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(53, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "From Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(176, 72)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpFrDate.TabIndex = 34
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(176, 111)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpEndDate.TabIndex = 35
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.dgvTransfer)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 48)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(3, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 93
        Me.PictureBox1.TabStop = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(822, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 91
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.procesKasun
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdSave.Location = New System.Drawing.Point(785, 9)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 90
        Me.cmdSave.Tag = "3"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(55, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(235, 18)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Generate Summary Textfile"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvTransfer
        '
        Me.dgvTransfer.AllowUserToAddRows = False
        Me.dgvTransfer.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvTransfer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTransfer.GridColor = System.Drawing.Color.White
        Me.dgvTransfer.Location = New System.Drawing.Point(332, 3)
        Me.dgvTransfer.Name = "dgvTransfer"
        Me.dgvTransfer.ReadOnly = True
        Me.dgvTransfer.RowHeadersVisible = False
        Me.dgvTransfer.RowHeadersWidth = 12
        Me.dgvTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransfer.Size = New System.Drawing.Size(125, 34)
        Me.dgvTransfer.TabIndex = 43
        Me.dgvTransfer.Tag = "1"
        Me.dgvTransfer.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmTextGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(859, 486)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmTextGenerator"
        Me.Text = "frmTextGenerator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBranches, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pgb As System.Windows.Forms.ProgressBar
    Friend WithEvents dgvTransfer As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents rdbK14 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHRIS As System.Windows.Forms.RadioButton
    Friend WithEvents rdDefault As System.Windows.Forms.RadioButton
    Friend WithEvents lblLast As System.Windows.Forms.Label
    Friend WithEvents dgvBranches As System.Windows.Forms.DataGridView
    Friend WithEvents chkTr As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents brID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TimeD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DefCol2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DefCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MacID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
End Class
