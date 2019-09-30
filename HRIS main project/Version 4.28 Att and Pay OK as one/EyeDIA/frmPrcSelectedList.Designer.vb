<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrcSelectedlist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrcSelectedlist))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbTitle = New System.Windows.Forms.ComboBox
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbDesg = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.chkCheck = New System.Windows.Forms.CheckBox
        Me.dgvEmps = New System.Windows.Forms.DataGridView
        Me.Catc = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EPFNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sts = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pgbPrc = New System.Windows.Forms.ProgressBar
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.cmdBrs = New System.Windows.Forms.Button
        Me.txtEmpName = New System.Windows.Forms.TextBox
        Me.txtEmpID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdnRefresh = New System.Windows.Forms.Button
        Me.chkProcessAtt = New System.Windows.Forms.CheckBox
        Me.chkManualAdj = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optPeriod = New System.Windows.Forms.RadioButton
        Me.cmdYear = New System.Windows.Forms.Button
        Me.cmdMonth = New System.Windows.Forms.Button
        Me.optSelMonth = New System.Windows.Forms.RadioButton
        Me.cmdyPrv = New System.Windows.Forms.Button
        Me.cmdmPrv = New System.Windows.Forms.Button
        Me.cmdYNext = New System.Windows.Forms.Button
        Me.cmdmNext = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdProcess = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chkTickSelcted = New System.Windows.Forms.CheckBox
        Me.cmdnProcess = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.chkCat = New System.Windows.Forms.CheckBox
        Me.chkDesig = New System.Windows.Forms.CheckBox
        Me.chkDept = New System.Windows.Forms.CheckBox
        Me.cmdFind = New System.Windows.Forms.Button
        Me.pnlAllDt = New System.Windows.Forms.Panel
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvEmps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllDt.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.cmdBrs)
        Me.Panel2.Controls.Add(Me.txtEmpName)
        Me.Panel2.Controls.Add(Me.txtEmpID)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(888, 474)
        Me.Panel2.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Controls.Add(Me.chkCheck)
        Me.Panel4.Controls.Add(Me.dgvEmps)
        Me.Panel4.Controls.Add(Me.pgbPrc)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(888, 436)
        Me.Panel4.TabIndex = 32
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(445, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(441, 2)
        Me.Label17.TabIndex = 112
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(347, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Employee List"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.cmbTitle)
        Me.GroupBox3.Controls.Add(Me.dtpToDate)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.dtpFrDate)
        Me.GroupBox3.Controls.Add(Me.cmbType)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbBranch)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cmbDesg)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmbCat)
        Me.GroupBox3.Controls.Add(Me.cmbDept)
        Me.GroupBox3.Controls.Add(Me.txtSearch)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(332, 416)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select Employees and Date Range"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Employee Title"
        '
        'cmbTitle
        '
        Me.cmbTitle.BackColor = System.Drawing.Color.White
        Me.cmbTitle.FormattingEnabled = True
        Me.cmbTitle.Location = New System.Drawing.Point(156, 183)
        Me.cmbTitle.Name = "cmbTitle"
        Me.cmbTitle.Size = New System.Drawing.Size(170, 21)
        Me.cmbTitle.TabIndex = 49
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(156, 260)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(118, 21)
        Me.dtpToDate.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 160)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Employee Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(67, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "To Date "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(4, 134)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Employee Branch"
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(156, 233)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(118, 21)
        Me.dtpFrDate.TabIndex = 17
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(156, 157)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(170, 21)
        Me.cmbType.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(67, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "From Date "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(156, 131)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(170, 21)
        Me.cmbBranch.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Employee Department"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Type any word to search "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Employee Designation"
        '
        'cmbDesg
        '
        Me.cmbDesg.BackColor = System.Drawing.Color.White
        Me.cmbDesg.FormattingEnabled = True
        Me.cmbDesg.Location = New System.Drawing.Point(156, 79)
        Me.cmbDesg.Name = "cmbDesg"
        Me.cmbDesg.Size = New System.Drawing.Size(170, 21)
        Me.cmbDesg.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Employee Category"
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.White
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(156, 53)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(170, 21)
        Me.cmbCat.TabIndex = 1
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(156, 105)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(170, 21)
        Me.cmbDept.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(156, 27)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(170, 21)
        Me.txtSearch.TabIndex = 11
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Location = New System.Drawing.Point(352, 28)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.Size = New System.Drawing.Size(15, 14)
        Me.chkCheck.TabIndex = 4
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'dgvEmps
        '
        Me.dgvEmps.AllowUserToAddRows = False
        Me.dgvEmps.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmps.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Catc, Me.EmpID, Me.EPFNo, Me.EmpName, Me.Desg, Me.Dept, Me.sts})
        Me.dgvEmps.GridColor = System.Drawing.Color.White
        Me.dgvEmps.Location = New System.Drawing.Point(348, 24)
        Me.dgvEmps.Name = "dgvEmps"
        Me.dgvEmps.RowHeadersVisible = False
        Me.dgvEmps.RowHeadersWidth = 12
        Me.dgvEmps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmps.Size = New System.Drawing.Size(539, 396)
        Me.dgvEmps.TabIndex = 2
        Me.dgvEmps.Tag = "1"
        '
        'Catc
        '
        Me.Catc.Frozen = True
        Me.Catc.HeaderText = ""
        Me.Catc.Name = "Catc"
        Me.Catc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Catc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Catc.Width = 22
        '
        'EmpID
        '
        Me.EmpID.Frozen = True
        Me.EmpID.HeaderText = "Employee ID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Visible = False
        '
        'EPFNo
        '
        Me.EPFNo.Frozen = True
        Me.EPFNo.HeaderText = "E.P.F. No"
        Me.EPFNo.Name = "EPFNo"
        Me.EPFNo.ReadOnly = True
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        '
        'Desg
        '
        Me.Desg.HeaderText = "Desgnation"
        Me.Desg.Name = "Desg"
        Me.Desg.ReadOnly = True
        Me.Desg.Width = 88
        '
        'Dept
        '
        Me.Dept.HeaderText = "Department"
        Me.Dept.Name = "Dept"
        Me.Dept.ReadOnly = True
        Me.Dept.Width = 88
        '
        'sts
        '
        Me.sts.HeaderText = "Status"
        Me.sts.Name = "sts"
        Me.sts.ReadOnly = True
        Me.sts.Visible = False
        '
        'pgbPrc
        '
        Me.pgbPrc.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgbPrc.Location = New System.Drawing.Point(0, 432)
        Me.pgbPrc.Name = "pgbPrc"
        Me.pgbPrc.Size = New System.Drawing.Size(888, 4)
        Me.pgbPrc.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.lblCount)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 436)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(888, 38)
        Me.Panel3.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(888, 2)
        Me.Label11.TabIndex = 30
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(346, 19)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 29
        '
        'cmdBrs
        '
        Me.cmdBrs.Location = New System.Drawing.Point(260, -29)
        Me.cmdBrs.Name = "cmdBrs"
        Me.cmdBrs.Size = New System.Drawing.Size(37, 22)
        Me.cmdBrs.TabIndex = 16
        Me.cmdBrs.Text = "..."
        Me.cmdBrs.UseVisualStyleBackColor = True
        Me.cmdBrs.Visible = False
        '
        'txtEmpName
        '
        Me.txtEmpName.BackColor = System.Drawing.Color.White
        Me.txtEmpName.Location = New System.Drawing.Point(304, -28)
        Me.txtEmpName.Name = "txtEmpName"
        Me.txtEmpName.ReadOnly = True
        Me.txtEmpName.Size = New System.Drawing.Size(378, 21)
        Me.txtEmpName.TabIndex = 14
        Me.txtEmpName.Visible = False
        '
        'txtEmpID
        '
        Me.txtEmpID.BackColor = System.Drawing.Color.White
        Me.txtEmpID.Location = New System.Drawing.Point(125, -28)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.ReadOnly = True
        Me.txtEmpID.Size = New System.Drawing.Size(130, 21)
        Me.txtEmpID.TabIndex = 14
        Me.txtEmpID.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, -29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 23)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Employee |"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'cmdnRefresh
        '
        Me.cmdnRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.webmail
        Me.cmdnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdnRefresh.FlatAppearance.BorderSize = 0
        Me.cmdnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdnRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnRefresh.ForeColor = System.Drawing.Color.White
        Me.cmdnRefresh.Location = New System.Drawing.Point(132, 15)
        Me.cmdnRefresh.Name = "cmdnRefresh"
        Me.cmdnRefresh.Size = New System.Drawing.Size(88, 26)
        Me.cmdnRefresh.TabIndex = 10
        Me.cmdnRefresh.Tag = "1"
        Me.cmdnRefresh.Text = "Print"
        Me.cmdnRefresh.UseVisualStyleBackColor = True
        Me.cmdnRefresh.Visible = False
        '
        'chkProcessAtt
        '
        Me.chkProcessAtt.AutoSize = True
        Me.chkProcessAtt.Checked = True
        Me.chkProcessAtt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkProcessAtt.Location = New System.Drawing.Point(428, 25)
        Me.chkProcessAtt.Name = "chkProcessAtt"
        Me.chkProcessAtt.Size = New System.Drawing.Size(164, 17)
        Me.chkProcessAtt.TabIndex = 6
        Me.chkProcessAtt.Text = "Re-Prossess Attendance"
        Me.chkProcessAtt.UseVisualStyleBackColor = True
        Me.chkProcessAtt.Visible = False
        '
        'chkManualAdj
        '
        Me.chkManualAdj.AutoSize = True
        Me.chkManualAdj.Location = New System.Drawing.Point(428, 3)
        Me.chkManualAdj.Name = "chkManualAdj"
        Me.chkManualAdj.Size = New System.Drawing.Size(189, 17)
        Me.chkManualAdj.TabIndex = 5
        Me.chkManualAdj.Text = "Process Manual Adjestments"
        Me.chkManualAdj.UseVisualStyleBackColor = True
        Me.chkManualAdj.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optPeriod)
        Me.GroupBox2.Controls.Add(Me.cmdYear)
        Me.GroupBox2.Controls.Add(Me.cmdMonth)
        Me.GroupBox2.Controls.Add(Me.optSelMonth)
        Me.GroupBox2.Controls.Add(Me.cmdyPrv)
        Me.GroupBox2.Controls.Add(Me.cmdmPrv)
        Me.GroupBox2.Controls.Add(Me.cmdYNext)
        Me.GroupBox2.Controls.Add(Me.cmdmNext)
        Me.GroupBox2.Location = New System.Drawing.Point(707, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(22, 28)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        Me.GroupBox2.Visible = False
        '
        'optPeriod
        '
        Me.optPeriod.Checked = True
        Me.optPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPeriod.Location = New System.Drawing.Point(-56, 19)
        Me.optPeriod.Name = "optPeriod"
        Me.optPeriod.Size = New System.Drawing.Size(218, 24)
        Me.optPeriod.TabIndex = 6
        Me.optPeriod.TabStop = True
        Me.optPeriod.Text = "FROM LAST RUN DATE"
        Me.optPeriod.UseVisualStyleBackColor = True
        Me.optPeriod.Visible = False
        '
        'cmdYear
        '
        Me.cmdYear.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdYear.FlatAppearance.BorderSize = 0
        Me.cmdYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYear.Location = New System.Drawing.Point(-224, 49)
        Me.cmdYear.Name = "cmdYear"
        Me.cmdYear.Size = New System.Drawing.Size(92, 29)
        Me.cmdYear.TabIndex = 3
        Me.cmdYear.UseVisualStyleBackColor = True
        Me.cmdYear.Visible = False
        '
        'cmdMonth
        '
        Me.cmdMonth.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdMonth.FlatAppearance.BorderSize = 0
        Me.cmdMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMonth.Location = New System.Drawing.Point(-31, 49)
        Me.cmdMonth.Name = "cmdMonth"
        Me.cmdMonth.Size = New System.Drawing.Size(147, 29)
        Me.cmdMonth.TabIndex = 2
        Me.cmdMonth.UseVisualStyleBackColor = True
        Me.cmdMonth.Visible = False
        '
        'optSelMonth
        '
        Me.optSelMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optSelMonth.Location = New System.Drawing.Point(-281, 19)
        Me.optSelMonth.Name = "optSelMonth"
        Me.optSelMonth.Size = New System.Drawing.Size(218, 24)
        Me.optSelMonth.TabIndex = 6
        Me.optSelMonth.Text = "SELECTED MONTH"
        Me.optSelMonth.UseVisualStyleBackColor = True
        Me.optSelMonth.Visible = False
        '
        'cmdyPrv
        '
        Me.cmdyPrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdyPrv.Location = New System.Drawing.Point(-269, 48)
        Me.cmdyPrv.Name = "cmdyPrv"
        Me.cmdyPrv.Size = New System.Drawing.Size(44, 30)
        Me.cmdyPrv.TabIndex = 1
        Me.cmdyPrv.Text = "<<"
        Me.cmdyPrv.UseVisualStyleBackColor = True
        Me.cmdyPrv.Visible = False
        '
        'cmdmPrv
        '
        Me.cmdmPrv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmPrv.Location = New System.Drawing.Point(-78, 48)
        Me.cmdmPrv.Name = "cmdmPrv"
        Me.cmdmPrv.Size = New System.Drawing.Size(44, 30)
        Me.cmdmPrv.TabIndex = 1
        Me.cmdmPrv.Text = "<<"
        Me.cmdmPrv.UseVisualStyleBackColor = True
        Me.cmdmPrv.Visible = False
        '
        'cmdYNext
        '
        Me.cmdYNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdYNext.Location = New System.Drawing.Point(-129, 48)
        Me.cmdYNext.Name = "cmdYNext"
        Me.cmdYNext.Size = New System.Drawing.Size(44, 30)
        Me.cmdYNext.TabIndex = 5
        Me.cmdYNext.Text = ">>"
        Me.cmdYNext.UseVisualStyleBackColor = True
        Me.cmdYNext.Visible = False
        '
        'cmdmNext
        '
        Me.cmdmNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmNext.Location = New System.Drawing.Point(118, 48)
        Me.cmdmNext.Name = "cmdmNext"
        Me.cmdmNext.Size = New System.Drawing.Size(44, 30)
        Me.cmdmNext.TabIndex = 5
        Me.cmdmNext.Text = ">>"
        Me.cmdmNext.UseVisualStyleBackColor = True
        Me.cmdmNext.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(658, 8)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(43, 10)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "CLOSE"
        Me.cmdClose.UseVisualStyleBackColor = True
        Me.cmdClose.Visible = False
        '
        'cmdReport
        '
        Me.cmdReport.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.Location = New System.Drawing.Point(647, 19)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(49, 10)
        Me.cmdReport.TabIndex = 5
        Me.cmdReport.Text = "REPORT"
        Me.cmdReport.UseVisualStyleBackColor = True
        Me.cmdReport.Visible = False
        '
        'cmdProcess
        '
        Me.cmdProcess.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(651, 31)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(37, 10)
        Me.cmdProcess.TabIndex = 5
        Me.cmdProcess.Text = "PROCESS"
        Me.cmdProcess.UseVisualStyleBackColor = True
        Me.cmdProcess.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdnRefresh)
        Me.Panel1.Controls.Add(Me.chkTickSelcted)
        Me.Panel1.Controls.Add(Me.cmdnProcess)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.chkCat)
        Me.Panel1.Controls.Add(Me.chkDesig)
        Me.Panel1.Controls.Add(Me.chkDept)
        Me.Panel1.Controls.Add(Me.cmdFind)
        Me.Panel1.Controls.Add(Me.chkProcessAtt)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.chkManualAdj)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Controls.Add(Me.cmdProcess)
        Me.Panel1.Controls.Add(Me.cmdReport)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 48)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Tag = "1"
        '
        'chkTickSelcted
        '
        Me.chkTickSelcted.AutoSize = True
        Me.chkTickSelcted.BackColor = System.Drawing.Color.Transparent
        Me.chkTickSelcted.ForeColor = System.Drawing.Color.White
        Me.chkTickSelcted.Location = New System.Drawing.Point(694, 17)
        Me.chkTickSelcted.Name = "chkTickSelcted"
        Me.chkTickSelcted.Size = New System.Drawing.Size(102, 17)
        Me.chkTickSelcted.TabIndex = 95
        Me.chkTickSelcted.Text = "Tick Selected"
        Me.chkTickSelcted.UseVisualStyleBackColor = False
        '
        'cmdnProcess
        '
        Me.cmdnProcess.BackColor = System.Drawing.Color.Transparent
        Me.cmdnProcess.BackgroundImage = Global.HRISforBB.My.Resources.Resources.procesKasun
        Me.cmdnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdnProcess.FlatAppearance.BorderSize = 0
        Me.cmdnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdnProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdnProcess.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdnProcess.Location = New System.Drawing.Point(814, 10)
        Me.cmdnProcess.Name = "cmdnProcess"
        Me.cmdnProcess.Size = New System.Drawing.Size(28, 28)
        Me.cmdnProcess.TabIndex = 94
        Me.cmdnProcess.Tag = "3"
        Me.cmdnProcess.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(848, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 93
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(9, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(64, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(267, 18)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Process Selected Employee List"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkCat
        '
        Me.chkCat.AutoSize = True
        Me.chkCat.Location = New System.Drawing.Point(270, 0)
        Me.chkCat.Name = "chkCat"
        Me.chkCat.Size = New System.Drawing.Size(79, 17)
        Me.chkCat.TabIndex = 0
        Me.chkCat.Text = "Category"
        Me.chkCat.UseVisualStyleBackColor = True
        Me.chkCat.Visible = False
        '
        'chkDesig
        '
        Me.chkDesig.AutoSize = True
        Me.chkDesig.Location = New System.Drawing.Point(300, 23)
        Me.chkDesig.Name = "chkDesig"
        Me.chkDesig.Size = New System.Drawing.Size(93, 17)
        Me.chkDesig.TabIndex = 0
        Me.chkDesig.Text = "Designation"
        Me.chkDesig.UseVisualStyleBackColor = True
        Me.chkDesig.Visible = False
        '
        'chkDept
        '
        Me.chkDept.AutoSize = True
        Me.chkDept.Location = New System.Drawing.Point(428, 44)
        Me.chkDept.Name = "chkDept"
        Me.chkDept.Size = New System.Drawing.Size(94, 17)
        Me.chkDept.TabIndex = 0
        Me.chkDept.Text = "Department"
        Me.chkDept.UseVisualStyleBackColor = True
        Me.chkDept.Visible = False
        '
        'cmdFind
        '
        Me.cmdFind.BackgroundImage = Global.HRISforBB.My.Resources.Resources.webmail
        Me.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFind.FlatAppearance.BorderSize = 0
        Me.cmdFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFind.ForeColor = System.Drawing.Color.White
        Me.cmdFind.Location = New System.Drawing.Point(599, 26)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(46, 26)
        Me.cmdFind.TabIndex = 3
        Me.cmdFind.Tag = "1"
        Me.cmdFind.Text = "F&ind"
        Me.cmdFind.UseVisualStyleBackColor = True
        Me.cmdFind.Visible = False
        '
        'pnlAllDt
        '
        Me.pnlAllDt.Controls.Add(Me.Panel2)
        Me.pnlAllDt.Controls.Add(Me.Panel1)
        Me.pnlAllDt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllDt.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllDt.Name = "pnlAllDt"
        Me.pnlAllDt.Size = New System.Drawing.Size(888, 522)
        Me.pnlAllDt.TabIndex = 42
        '
        'frmPrcSelectedlist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(888, 522)
        Me.Controls.Add(Me.pnlAllDt)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrcSelectedlist"
        Me.Text = "Process Selected Employee"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvEmps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllDt.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents pgbPrc As System.Windows.Forms.ProgressBar
    Friend WithEvents optPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents optSelMonth As System.Windows.Forms.RadioButton
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents cmdmNext As System.Windows.Forms.Button
    Friend WithEvents cmdYNext As System.Windows.Forms.Button
    Friend WithEvents cmdmPrv As System.Windows.Forms.Button
    Friend WithEvents cmdyPrv As System.Windows.Forms.Button
    Friend WithEvents cmdMonth As System.Windows.Forms.Button
    Friend WithEvents cmdYear As System.Windows.Forms.Button
    Friend WithEvents cmdBrs As System.Windows.Forms.Button
    Friend WithEvents txtEmpName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents chkDept As System.Windows.Forms.CheckBox
    Friend WithEvents cmbDesg As System.Windows.Forms.ComboBox
    Friend WithEvents chkCat As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesig As System.Windows.Forms.CheckBox
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents dgvEmps As System.Windows.Forms.DataGridView
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkManualAdj As System.Windows.Forms.CheckBox
    Friend WithEvents cmdnRefresh As System.Windows.Forms.Button
    Friend WithEvents chkProcessAtt As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Catc As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EPFNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlAllDt As System.Windows.Forms.Panel
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdnProcess As System.Windows.Forms.Button
    Friend WithEvents chkTickSelcted As System.Windows.Forms.CheckBox
End Class
