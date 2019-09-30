<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSortLeaveApprov
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
        Me.pnllTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtrPerson = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtLvBalance = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpFrtime = New System.Windows.Forms.DateTimePicker
        Me.dtpToTime = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txttoDType = New System.Windows.Forms.TextBox
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dgvSpLv = New System.Windows.Forms.DataGridView
        Me.lDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Shift = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdLvday = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AplLv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LvStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AntStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LvType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.late = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.early = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvLeaveAllk = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtRelID = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtempName = New System.Windows.Forms.TextBox
        Me.pnllTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSpLv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvLeaveAllk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnllTop
        '
        Me.pnllTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnllTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnllTop.Controls.Add(Me.cmdSave)
        Me.pnllTop.Controls.Add(Me.cmdRefresh)
        Me.pnllTop.Controls.Add(Me.PictureBox1)
        Me.pnllTop.Controls.Add(Me.Label16)
        Me.pnllTop.Controls.Add(Me.GroupBox2)
        Me.pnllTop.Controls.Add(Me.Label8)
        Me.pnllTop.Controls.Add(Me.txttoDType)
        Me.pnllTop.Controls.Add(Me.dtpToDate)
        Me.pnllTop.Controls.Add(Me.dgvSpLv)
        Me.pnllTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnllTop.Location = New System.Drawing.Point(0, 0)
        Me.pnllTop.Name = "pnllTop"
        Me.pnllTop.Size = New System.Drawing.Size(888, 48)
        Me.pnllTop.TabIndex = 1
        Me.pnllTop.Tag = "1"
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
        Me.cmdSave.Location = New System.Drawing.Point(810, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 45
        Me.cmdSave.Tag = "6"
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
        Me.cmdRefresh.Location = New System.Drawing.Point(846, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 46
        Me.cmdRefresh.Tag = "6"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(56, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(158, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "Short Leave Bulk Apply"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.txtrPerson)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.txtLvBalance)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtpFrtime)
        Me.GroupBox2.Controls.Add(Me.dtpToTime)
        Me.GroupBox2.Location = New System.Drawing.Point(869, -41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(21, 35)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Leave Details"
        Me.GroupBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(264, 220)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(222, 17)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "If medical leave - report submited"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(27, 243)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(623, 64)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Remarks"
        '
        'txtrPerson
        '
        Me.txtrPerson.BackColor = System.Drawing.Color.White
        Me.txtrPerson.Location = New System.Drawing.Point(273, 165)
        Me.txtrPerson.Name = "txtrPerson"
        Me.txtrPerson.Size = New System.Drawing.Size(376, 21)
        Me.txtrPerson.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(9, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(258, 23)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Responsible Person During Leave |"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(23, 44)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(625, 109)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "  Set Leave Day(s)"
        '
        'txtLvBalance
        '
        Me.txtLvBalance.BackColor = System.Drawing.Color.White
        Me.txtLvBalance.Enabled = False
        Me.txtLvBalance.Location = New System.Drawing.Point(-23, 15)
        Me.txtLvBalance.Name = "txtLvBalance"
        Me.txtLvBalance.Size = New System.Drawing.Size(111, 21)
        Me.txtLvBalance.TabIndex = 2
        Me.txtLvBalance.Visible = False
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-157, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 23)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Leave Balance |"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Visible = False
        '
        'dtpFrtime
        '
        Me.dtpFrtime.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrtime.Location = New System.Drawing.Point(0, 12)
        Me.dtpFrtime.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrtime.Name = "dtpFrtime"
        Me.dtpFrtime.Size = New System.Drawing.Size(109, 21)
        Me.dtpFrtime.TabIndex = 6
        Me.dtpFrtime.Visible = False
        '
        'dtpToTime
        '
        Me.dtpToTime.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTime.Location = New System.Drawing.Point(0, 33)
        Me.dtpToTime.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToTime.Name = "dtpToTime"
        Me.dtpToTime.Size = New System.Drawing.Size(109, 21)
        Me.dtpToTime.TabIndex = 6
        Me.dtpToTime.Visible = False
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(430, -62)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 23)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Leave To |"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Visible = False
        '
        'txttoDType
        '
        Me.txttoDType.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txttoDType.Location = New System.Drawing.Point(569, -31)
        Me.txttoDType.Name = "txttoDType"
        Me.txttoDType.ReadOnly = True
        Me.txttoDType.Size = New System.Drawing.Size(79, 21)
        Me.txttoDType.TabIndex = 8
        Me.txttoDType.Visible = False
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(470, -28)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(93, 21)
        Me.dtpToDate.TabIndex = 7
        Me.dtpToDate.Visible = False
        '
        'dgvSpLv
        '
        Me.dgvSpLv.AllowUserToAddRows = False
        Me.dgvSpLv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSpLv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lDate, Me.Shift, Me.cmdLvday, Me.AplLv, Me.LvStatus, Me.AntStatus, Me.LvType, Me.late, Me.early})
        Me.dgvSpLv.Location = New System.Drawing.Point(776, -50)
        Me.dgvSpLv.Name = "dgvSpLv"
        Me.dgvSpLv.RowHeadersVisible = False
        Me.dgvSpLv.RowHeadersWidth = 28
        Me.dgvSpLv.Size = New System.Drawing.Size(12, 19)
        Me.dgvSpLv.TabIndex = 11
        '
        'lDate
        '
        Me.lDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.lDate.HeaderText = "Date"
        Me.lDate.Name = "lDate"
        Me.lDate.ReadOnly = True
        Me.lDate.Width = 59
        '
        'Shift
        '
        Me.Shift.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Shift.HeaderText = "Shift"
        Me.Shift.Name = "Shift"
        Me.Shift.ReadOnly = True
        '
        'cmdLvday
        '
        Me.cmdLvday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.cmdLvday.HeaderText = "Leave"
        Me.cmdLvday.Name = "cmdLvday"
        Me.cmdLvday.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cmdLvday.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cmdLvday.Width = 47
        '
        'AplLv
        '
        Me.AplLv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.AplLv.HeaderText = "ApplyLv"
        Me.AplLv.Name = "AplLv"
        Me.AplLv.ReadOnly = True
        Me.AplLv.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AplLv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AplLv.Visible = False
        '
        'LvStatus
        '
        Me.LvStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LvStatus.HeaderText = "LeaveStatus"
        Me.LvStatus.Name = "LvStatus"
        Me.LvStatus.ReadOnly = True
        Me.LvStatus.Visible = False
        '
        'AntStatus
        '
        Me.AntStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.AntStatus.HeaderText = "Attn Stt"
        Me.AntStatus.Name = "AntStatus"
        Me.AntStatus.ReadOnly = True
        Me.AntStatus.Visible = False
        '
        'LvType
        '
        Me.LvType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LvType.HeaderText = "Leave TYpe"
        Me.LvType.Name = "LvType"
        Me.LvType.ReadOnly = True
        Me.LvType.Visible = False
        '
        'late
        '
        Me.late.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.late.HeaderText = "late"
        Me.late.Name = "late"
        Me.late.ReadOnly = True
        Me.late.Visible = False
        '
        'early
        '
        Me.early.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.early.HeaderText = "early"
        Me.early.Name = "early"
        Me.early.ReadOnly = True
        Me.early.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.dgvLeaveAllk)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 404)
        Me.Panel1.TabIndex = 2
        '
        'dgvLeaveAllk
        '
        Me.dgvLeaveAllk.AllowUserToAddRows = False
        Me.dgvLeaveAllk.BackgroundColor = System.Drawing.Color.White
        Me.dgvLeaveAllk.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLeaveAllk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLeaveAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLeaveAllk.GridColor = System.Drawing.Color.White
        Me.dgvLeaveAllk.Location = New System.Drawing.Point(0, 0)
        Me.dgvLeaveAllk.Name = "dgvLeaveAllk"
        Me.dgvLeaveAllk.ReadOnly = True
        Me.dgvLeaveAllk.RowHeadersVisible = False
        Me.dgvLeaveAllk.RowHeadersWidth = 28
        Me.dgvLeaveAllk.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLeaveAllk.Size = New System.Drawing.Size(888, 404)
        Me.dgvLeaveAllk.TabIndex = 41
        Me.dgvLeaveAllk.TabStop = False
        Me.dgvLeaveAllk.Tag = "1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.notcurved46
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label22)
        Me.Panel3.Controls.Add(Me.txtRelID)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtDept)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.txtempName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(888, 32)
        Me.Panel3.TabIndex = 42
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.DimGray
        Me.Label22.Location = New System.Drawing.Point(4, 10)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(92, 13)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Employee No"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRelID
        '
        Me.txtRelID.BackColor = System.Drawing.Color.White
        Me.txtRelID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRelID.Location = New System.Drawing.Point(101, 7)
        Me.txtRelID.MaxLength = 6
        Me.txtRelID.Name = "txtRelID"
        Me.txtRelID.Size = New System.Drawing.Size(73, 21)
        Me.txtRelID.TabIndex = 47
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(515, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Department"
        '
        'txtDept
        '
        Me.txtDept.BackColor = System.Drawing.Color.White
        Me.txtDept.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDept.Location = New System.Drawing.Point(605, 6)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(168, 21)
        Me.txtDept.TabIndex = 2
        Me.txtDept.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(201, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Name "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtempName
        '
        Me.txtempName.BackColor = System.Drawing.Color.White
        Me.txtempName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtempName.Location = New System.Drawing.Point(253, 6)
        Me.txtempName.Name = "txtempName"
        Me.txtempName.ReadOnly = True
        Me.txtempName.Size = New System.Drawing.Size(258, 21)
        Me.txtempName.TabIndex = 1
        Me.txtempName.TabStop = False
        '
        'frmSortLeaveApprov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 452)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnllTop)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSortLeaveApprov"
        Me.Text = "frmSortLeaveApprov"
        Me.pnllTop.ResumeLayout(False)
        Me.pnllTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvSpLv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvLeaveAllk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnllTop As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtrPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLvBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFrtime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txttoDType As System.Windows.Forms.TextBox
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvSpLv As System.Windows.Forms.DataGridView
    Friend WithEvents lDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Shift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdLvday As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AplLv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AntStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents late As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents early As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvLeaveAllk As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtRelID As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtempName As System.Windows.Forms.TextBox
End Class
