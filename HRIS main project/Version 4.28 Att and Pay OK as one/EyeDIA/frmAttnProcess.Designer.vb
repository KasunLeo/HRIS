<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttnProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAttnProcess))
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txtCurrent = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtlast = New System.Windows.Forms.TextBox
        Me.pgbPrc = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkCloseDay = New System.Windows.Forms.CheckBox
        Me.dtpMaxDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpLRDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optSelMonth = New System.Windows.Forms.RadioButton
        Me.cmdYear = New System.Windows.Forms.Button
        Me.optPeriod = New System.Windows.Forms.RadioButton
        Me.cmdMonth = New System.Windows.Forms.Button
        Me.cmdyPrv = New System.Windows.Forms.Button
        Me.cmdmPrv = New System.Windows.Forms.Button
        Me.cmdYNext = New System.Windows.Forms.Button
        Me.cmdmNext = New System.Windows.Forms.Button
        Me.cmdClear = New System.Windows.Forms.Button
        Me.cmdProcess = New System.Windows.Forms.Button
        Me.chkView = New System.Windows.Forms.CheckBox
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdReport = New System.Windows.Forms.Button
        Me.dgvEmployee = New System.Windows.Forms.DataGridView
        Me.Pick = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EpfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.atDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shiftName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlBotom = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotom.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.txtCurrent)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtlast)
        Me.Panel3.Controls.Add(Me.pgbPrc)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(490, 50)
        Me.Panel3.TabIndex = 0
        '
        'txtCurrent
        '
        Me.txtCurrent.BackColor = System.Drawing.Color.White
        Me.txtCurrent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrent.Location = New System.Drawing.Point(374, 11)
        Me.txtCurrent.Name = "txtCurrent"
        Me.txtCurrent.ReadOnly = True
        Me.txtCurrent.Size = New System.Drawing.Size(97, 21)
        Me.txtCurrent.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(283, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Current Date "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtlast
        '
        Me.txtlast.BackColor = System.Drawing.Color.White
        Me.txtlast.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlast.Location = New System.Drawing.Point(118, 11)
        Me.txtlast.Name = "txtlast"
        Me.txtlast.ReadOnly = True
        Me.txtlast.Size = New System.Drawing.Size(97, 21)
        Me.txtlast.TabIndex = 11
        '
        'pgbPrc
        '
        Me.pgbPrc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbPrc.Location = New System.Drawing.Point(0, 44)
        Me.pgbPrc.Name = "pgbPrc"
        Me.pgbPrc.Size = New System.Drawing.Size(490, 6)
        Me.pgbPrc.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(11, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Processed Date "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmdClear)
        Me.GroupBox1.Controls.Add(Me.cmdProcess)
        Me.GroupBox1.Location = New System.Drawing.Point(256, 23)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(45, 22)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCloseDay)
        Me.GroupBox3.Controls.Add(Me.dtpMaxDate)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtpLRDate)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 87)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(21, 43)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Process Date "
        '
        'chkCloseDay
        '
        Me.chkCloseDay.AutoSize = True
        Me.chkCloseDay.Checked = True
        Me.chkCloseDay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCloseDay.Location = New System.Drawing.Point(258, 16)
        Me.chkCloseDay.Name = "chkCloseDay"
        Me.chkCloseDay.Size = New System.Drawing.Size(208, 17)
        Me.chkCloseDay.TabIndex = 20
        Me.chkCloseDay.Text = "Closed For the Day When Finish"
        Me.chkCloseDay.UseVisualStyleBackColor = True
        '
        'dtpMaxDate
        '
        Me.dtpMaxDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpMaxDate.Enabled = False
        Me.dtpMaxDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMaxDate.Location = New System.Drawing.Point(133, 42)
        Me.dtpMaxDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpMaxDate.Name = "dtpMaxDate"
        Me.dtpMaxDate.Size = New System.Drawing.Size(118, 21)
        Me.dtpMaxDate.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 23)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Current Date |"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpLRDate
        '
        Me.dtpLRDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpLRDate.Enabled = False
        Me.dtpLRDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLRDate.Location = New System.Drawing.Point(133, 16)
        Me.dtpLRDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpLRDate.Name = "dtpLRDate"
        Me.dtpLRDate.Size = New System.Drawing.Size(118, 21)
        Me.dtpLRDate.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 23)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Last Run Date |"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSelMonth)
        Me.GroupBox2.Controls.Add(Me.cmdYear)
        Me.GroupBox2.Controls.Add(Me.optPeriod)
        Me.GroupBox2.Controls.Add(Me.cmdMonth)
        Me.GroupBox2.Controls.Add(Me.cmdyPrv)
        Me.GroupBox2.Controls.Add(Me.cmdmPrv)
        Me.GroupBox2.Controls.Add(Me.cmdYNext)
        Me.GroupBox2.Controls.Add(Me.cmdmNext)
        Me.GroupBox2.Location = New System.Drawing.Point(332, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(51, 70)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        Me.GroupBox2.Visible = False
        '
        'optSelMonth
        '
        Me.optSelMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSelMonth.Location = New System.Drawing.Point(15, 19)
        Me.optSelMonth.Name = "optSelMonth"
        Me.optSelMonth.Size = New System.Drawing.Size(218, 24)
        Me.optSelMonth.TabIndex = 6
        Me.optSelMonth.Text = "SELECTED MONTH"
        Me.optSelMonth.UseVisualStyleBackColor = True
        '
        'cmdYear
        '
        Me.cmdYear.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdYear.FlatAppearance.BorderSize = 0
        Me.cmdYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYear.Location = New System.Drawing.Point(61, 51)
        Me.cmdYear.Name = "cmdYear"
        Me.cmdYear.Size = New System.Drawing.Size(92, 29)
        Me.cmdYear.TabIndex = 3
        Me.cmdYear.UseVisualStyleBackColor = True
        '
        'optPeriod
        '
        Me.optPeriod.Checked = True
        Me.optPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPeriod.Location = New System.Drawing.Point(240, 19)
        Me.optPeriod.Name = "optPeriod"
        Me.optPeriod.Size = New System.Drawing.Size(218, 24)
        Me.optPeriod.TabIndex = 6
        Me.optPeriod.TabStop = True
        Me.optPeriod.Text = "FROM LAST RUN DATE"
        Me.optPeriod.UseVisualStyleBackColor = True
        '
        'cmdMonth
        '
        Me.cmdMonth.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdMonth.FlatAppearance.BorderSize = 0
        Me.cmdMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMonth.Location = New System.Drawing.Point(253, 51)
        Me.cmdMonth.Name = "cmdMonth"
        Me.cmdMonth.Size = New System.Drawing.Size(147, 29)
        Me.cmdMonth.TabIndex = 2
        Me.cmdMonth.UseVisualStyleBackColor = True
        '
        'cmdyPrv
        '
        Me.cmdyPrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdyPrv.Location = New System.Drawing.Point(15, 50)
        Me.cmdyPrv.Name = "cmdyPrv"
        Me.cmdyPrv.Size = New System.Drawing.Size(44, 30)
        Me.cmdyPrv.TabIndex = 1
        Me.cmdyPrv.Text = "<<"
        Me.cmdyPrv.UseVisualStyleBackColor = True
        '
        'cmdmPrv
        '
        Me.cmdmPrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmPrv.Location = New System.Drawing.Point(206, 50)
        Me.cmdmPrv.Name = "cmdmPrv"
        Me.cmdmPrv.Size = New System.Drawing.Size(44, 30)
        Me.cmdmPrv.TabIndex = 1
        Me.cmdmPrv.Text = "<<"
        Me.cmdmPrv.UseVisualStyleBackColor = True
        '
        'cmdYNext
        '
        Me.cmdYNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYNext.Location = New System.Drawing.Point(155, 50)
        Me.cmdYNext.Name = "cmdYNext"
        Me.cmdYNext.Size = New System.Drawing.Size(44, 30)
        Me.cmdYNext.TabIndex = 5
        Me.cmdYNext.Text = ">>"
        Me.cmdYNext.UseVisualStyleBackColor = True
        '
        'cmdmNext
        '
        Me.cmdmNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmNext.Location = New System.Drawing.Point(402, 50)
        Me.cmdmNext.Name = "cmdmNext"
        Me.cmdmNext.Size = New System.Drawing.Size(44, 30)
        Me.cmdmNext.TabIndex = 5
        Me.cmdmNext.Text = ">>"
        Me.cmdmNext.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(552, 101)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(98, 39)
        Me.cmdClear.TabIndex = 5
        Me.cmdClear.Text = "CLEAR"
        Me.cmdClear.UseVisualStyleBackColor = True
        Me.cmdClear.Visible = False
        '
        'cmdProcess
        '
        Me.cmdProcess.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(166, 7)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(50, 15)
        Me.cmdProcess.TabIndex = 5
        Me.cmdProcess.Text = "PROCESS"
        Me.cmdProcess.UseVisualStyleBackColor = True
        Me.cmdProcess.Visible = False
        '
        'chkView
        '
        Me.chkView.AutoSize = True
        Me.chkView.BackColor = System.Drawing.Color.Gray
        Me.chkView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkView.ForeColor = System.Drawing.Color.White
        Me.chkView.Location = New System.Drawing.Point(243, 0)
        Me.chkView.Name = "chkView"
        Me.chkView.Size = New System.Drawing.Size(143, 17)
        Me.chkView.TabIndex = 12
        Me.chkView.Text = "Show Only Presence"
        Me.chkView.UseVisualStyleBackColor = False
        Me.chkView.Visible = False
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.cmdSave)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.Label25)
        Me.pnlTop.Controls.Add(Me.GroupBox1)
        Me.pnlTop.Controls.Add(Me.chkView)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(490, 48)
        Me.pnlTop.TabIndex = 0
        Me.pnlTop.Tag = "1"
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
        Me.cmdSave.Location = New System.Drawing.Point(451, 9)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 45
        Me.cmdSave.Tag = "5"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(11, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(66, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(171, 18)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Attendance Process"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdReport
        '
        Me.cmdReport.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.Location = New System.Drawing.Point(889, 8)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(107, 35)
        Me.cmdReport.TabIndex = 5
        Me.cmdReport.Text = "REPORT"
        Me.cmdReport.UseVisualStyleBackColor = True
        Me.cmdReport.Visible = False
        '
        'dgvEmployee
        '
        Me.dgvEmployee.AllowUserToAddRows = False
        Me.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pick, Me.EmpID, Me.EpfNo, Me.EmpName, Me.atDate, Me.ShiftID, Me.shiftName, Me.InTime, Me.OutDate, Me.OutTime})
        Me.dgvEmployee.Location = New System.Drawing.Point(0, 118)
        Me.dgvEmployee.Name = "dgvEmployee"
        Me.dgvEmployee.RowHeadersWidth = 21
        Me.dgvEmployee.Size = New System.Drawing.Size(847, 325)
        Me.dgvEmployee.TabIndex = 26
        '
        'Pick
        '
        Me.Pick.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Pick.HeaderText = "[Select]"
        Me.Pick.Name = "Pick"
        Me.Pick.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Pick.Visible = False
        '
        'EmpID
        '
        Me.EmpID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpID.HeaderText = "Employee ID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Visible = False
        '
        'EpfNo
        '
        Me.EpfNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EpfNo.HeaderText = "E.P.F. No"
        Me.EpfNo.Name = "EpfNo"
        Me.EpfNo.ReadOnly = True
        Me.EpfNo.Width = 79
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpName.HeaderText = "Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        '
        'atDate
        '
        Me.atDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.atDate.HeaderText = "Date"
        Me.atDate.Name = "atDate"
        Me.atDate.ReadOnly = True
        Me.atDate.Width = 59
        '
        'ShiftID
        '
        Me.ShiftID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ShiftID.HeaderText = "Shift ID"
        Me.ShiftID.Name = "ShiftID"
        Me.ShiftID.ReadOnly = True
        Me.ShiftID.Visible = False
        '
        'shiftName
        '
        Me.shiftName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.shiftName.HeaderText = "Shift Name"
        Me.shiftName.Name = "shiftName"
        Me.shiftName.ReadOnly = True
        Me.shiftName.Width = 95
        '
        'InTime
        '
        Me.InTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.InTime.HeaderText = "InTime"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        Me.InTime.Width = 72
        '
        'OutDate
        '
        Me.OutDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutDate.HeaderText = "Out Date"
        Me.OutDate.Name = "OutDate"
        Me.OutDate.ReadOnly = True
        Me.OutDate.Width = 83
        '
        'OutTime
        '
        Me.OutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutTime.HeaderText = "Out Time"
        Me.OutTime.Name = "OutTime"
        Me.OutTime.ReadOnly = True
        Me.OutTime.Width = 84
        '
        'pnlBotom
        '
        Me.pnlBotom.BackColor = System.Drawing.Color.White
        Me.pnlBotom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlBotom.Controls.Add(Me.Label5)
        Me.pnlBotom.Controls.Add(Me.dgvEmployee)
        Me.pnlBotom.Controls.Add(Me.cmdReport)
        Me.pnlBotom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotom.Location = New System.Drawing.Point(0, 50)
        Me.pnlBotom.Name = "pnlBotom"
        Me.pnlBotom.Size = New System.Drawing.Size(490, 50)
        Me.pnlBotom.TabIndex = 1
        Me.pnlBotom.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(468, 2)
        Me.Label5.TabIndex = 30
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel1)
        Me.pnlAllk.Controls.Add(Me.pnlTop)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(492, 150)
        Me.pnlAllk.TabIndex = 31
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.pnlBotom)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 100)
        Me.Panel1.TabIndex = 12
        '
        'frmAttnProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 150)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAttnProcess"
        Me.Text = "Attendance Process"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotom.ResumeLayout(False)
        Me.pnlAllk.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents optSelMonth As System.Windows.Forms.RadioButton
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents cmdmNext As System.Windows.Forms.Button
    Friend WithEvents cmdYNext As System.Windows.Forms.Button
    Friend WithEvents cmdmPrv As System.Windows.Forms.Button
    Friend WithEvents cmdyPrv As System.Windows.Forms.Button
    Friend WithEvents cmdMonth As System.Windows.Forms.Button
    Friend WithEvents cmdYear As System.Windows.Forms.Button
    Friend WithEvents pgbPrc As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpMaxDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpLRDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkCloseDay As System.Windows.Forms.CheckBox
    Friend WithEvents txtlast As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCurrent As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkView As System.Windows.Forms.CheckBox
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents dgvEmployee As System.Windows.Forms.DataGridView
    Friend WithEvents Pick As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EpfNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents atDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shiftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlBotom As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
End Class
