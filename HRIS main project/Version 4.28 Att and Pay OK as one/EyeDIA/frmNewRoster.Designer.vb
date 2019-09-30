<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewRoster
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbDesig = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgvCrShifts = New System.Windows.Forms.DataGridView
        Me.shID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dgvType = New System.Windows.Forms.DataGridView
        Me.dType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.aval = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.r = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.g = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.b = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbDayType = New System.Windows.Forms.ComboBox
        Me.rdbDayAndShift = New System.Windows.Forms.RadioButton
        Me.rdbShift = New System.Windows.Forms.RadioButton
        Me.rdbDay = New System.Windows.Forms.RadioButton
        Me.lblC = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.dgvEmployee = New System.Windows.Forms.DataGridView
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EpfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.pnlData = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.cmdApprove = New System.Windows.Forms.Button
        Me.cmdConfirm = New System.Windows.Forms.Button
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.pnlRight = New System.Windows.Forms.Panel
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmdShiftProcess = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblRowCoun = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblShift = New System.Windows.Forms.Label
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdEditOffDay = New System.Windows.Forms.Button
        Me.chkEditSelect = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbWorkDay = New System.Windows.Forms.ComboBox
        Me.cmbTitle = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCrShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.pnlData.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(566, 53)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(161, 21)
        Me.dtpFrDate.TabIndex = 41
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(844, 53)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(159, 21)
        Me.dtpToDate.TabIndex = 41
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(497, 134)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Type"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(497, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Branch"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(566, 131)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(161, 21)
        Me.cmbType.TabIndex = 33
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(566, 105)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(161, 21)
        Me.cmbBranch.TabIndex = 34
        '
        'cmbDept
        '
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(844, 105)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(159, 21)
        Me.cmbDept.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(763, 109)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Department "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(497, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "From Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(764, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "To Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(764, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Category "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDesig
        '
        Me.cmbDesig.FormattingEnabled = True
        Me.cmbDesig.Location = New System.Drawing.Point(844, 131)
        Me.cmbDesig.Name = "cmbDesig"
        Me.cmbDesig.Size = New System.Drawing.Size(159, 21)
        Me.cmbDesig.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(764, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Designation "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(497, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Name / ID"
        '
        'cmbCat
        '
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(844, 79)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(159, 21)
        Me.cmbCat.TabIndex = 11
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(566, 79)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(161, 21)
        Me.txtSearch.TabIndex = 15
        '
        'TabControl1
        '
        Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 19)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(479, 144)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl1.TabIndex = 39
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvCrShifts)
        Me.TabPage1.Location = New System.Drawing.Point(44, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(431, 136)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Change Shifts"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCrShifts
        '
        Me.dgvCrShifts.AllowUserToAddRows = False
        Me.dgvCrShifts.BackgroundColor = System.Drawing.Color.White
        Me.dgvCrShifts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCrShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCrShifts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.shID, Me.ShCode, Me.ShiftName, Me.InTime, Me.OutTime})
        Me.dgvCrShifts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCrShifts.GridColor = System.Drawing.Color.White
        Me.dgvCrShifts.Location = New System.Drawing.Point(3, 3)
        Me.dgvCrShifts.Name = "dgvCrShifts"
        Me.dgvCrShifts.RowHeadersVisible = False
        Me.dgvCrShifts.RowHeadersWidth = 12
        Me.dgvCrShifts.Size = New System.Drawing.Size(425, 130)
        Me.dgvCrShifts.TabIndex = 21
        Me.dgvCrShifts.Tag = "1"
        '
        'shID
        '
        Me.shID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.shID.HeaderText = "Sh ID"
        Me.shID.Name = "shID"
        Me.shID.ReadOnly = True
        Me.shID.Width = 65
        '
        'ShCode
        '
        Me.ShCode.HeaderText = "Short Code"
        Me.ShCode.Name = "ShCode"
        Me.ShCode.Width = 77
        '
        'ShiftName
        '
        Me.ShiftName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ShiftName.HeaderText = "Shift Name"
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.ReadOnly = True
        '
        'InTime
        '
        Me.InTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.InTime.HeaderText = "In Time"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        Me.InTime.Width = 76
        '
        'OutTime
        '
        Me.OutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutTime.HeaderText = "Out Time"
        Me.OutTime.Name = "OutTime"
        Me.OutTime.ReadOnly = True
        Me.OutTime.Width = 78
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(44, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(431, 136)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Rosters"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvType)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmbDayType)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 124)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Change Selected Day Mode"
        '
        'dgvType
        '
        Me.dgvType.AllowUserToAddRows = False
        Me.dgvType.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dType, Me.TName, Me.aval, Me.r, Me.g, Me.b})
        Me.dgvType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvType.GridColor = System.Drawing.Color.White
        Me.dgvType.Location = New System.Drawing.Point(3, 17)
        Me.dgvType.Name = "dgvType"
        Me.dgvType.ReadOnly = True
        Me.dgvType.RowHeadersVisible = False
        Me.dgvType.RowHeadersWidth = 12
        Me.dgvType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvType.Size = New System.Drawing.Size(413, 104)
        Me.dgvType.TabIndex = 12
        Me.dgvType.Tag = "1"
        '
        'dType
        '
        Me.dType.HeaderText = "Type ID"
        Me.dType.Name = "dType"
        Me.dType.ReadOnly = True
        Me.dType.Width = 77
        '
        'TName
        '
        Me.TName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TName.HeaderText = "Type Name"
        Me.TName.Name = "TName"
        Me.TName.ReadOnly = True
        '
        'aval
        '
        Me.aval.HeaderText = "aval"
        Me.aval.Name = "aval"
        Me.aval.ReadOnly = True
        Me.aval.Visible = False
        '
        'r
        '
        Me.r.HeaderText = "r val"
        Me.r.Name = "r"
        Me.r.ReadOnly = True
        Me.r.Visible = False
        '
        'g
        '
        Me.g.HeaderText = "gval"
        Me.g.Name = "g"
        Me.g.ReadOnly = True
        Me.g.Visible = False
        '
        'b
        '
        Me.b.HeaderText = "bval"
        Me.b.Name = "b"
        Me.b.ReadOnly = True
        Me.b.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(45, -22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Change Day Mode "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Visible = False
        '
        'cmbDayType
        '
        Me.cmbDayType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDayType.FormattingEnabled = True
        Me.cmbDayType.Location = New System.Drawing.Point(179, -25)
        Me.cmbDayType.Name = "cmbDayType"
        Me.cmbDayType.Size = New System.Drawing.Size(145, 21)
        Me.cmbDayType.TabIndex = 11
        Me.cmbDayType.Visible = False
        '
        'rdbDayAndShift
        '
        Me.rdbDayAndShift.AutoSize = True
        Me.rdbDayAndShift.BackColor = System.Drawing.Color.Transparent
        Me.rdbDayAndShift.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbDayAndShift.ForeColor = System.Drawing.Color.Black
        Me.rdbDayAndShift.Location = New System.Drawing.Point(776, 18)
        Me.rdbDayAndShift.Name = "rdbDayAndShift"
        Me.rdbDayAndShift.Size = New System.Drawing.Size(145, 16)
        Me.rdbDayAndShift.TabIndex = 45
        Me.rdbDayAndShift.TabStop = True
        Me.rdbDayAndShift.Text = "Copy Day Type and Shift"
        Me.rdbDayAndShift.UseVisualStyleBackColor = False
        '
        'rdbShift
        '
        Me.rdbShift.AutoSize = True
        Me.rdbShift.BackColor = System.Drawing.Color.Transparent
        Me.rdbShift.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbShift.ForeColor = System.Drawing.Color.Black
        Me.rdbShift.Location = New System.Drawing.Point(685, 19)
        Me.rdbShift.Name = "rdbShift"
        Me.rdbShift.Size = New System.Drawing.Size(75, 16)
        Me.rdbShift.TabIndex = 44
        Me.rdbShift.TabStop = True
        Me.rdbShift.Text = "Copy Shift"
        Me.rdbShift.UseVisualStyleBackColor = False
        '
        'rdbDay
        '
        Me.rdbDay.AutoSize = True
        Me.rdbDay.BackColor = System.Drawing.Color.Transparent
        Me.rdbDay.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbDay.ForeColor = System.Drawing.Color.Black
        Me.rdbDay.Location = New System.Drawing.Point(566, 19)
        Me.rdbDay.Name = "rdbDay"
        Me.rdbDay.Size = New System.Drawing.Size(96, 16)
        Me.rdbDay.TabIndex = 43
        Me.rdbDay.TabStop = True
        Me.rdbDay.Text = "Copy Day Type"
        Me.rdbDay.UseVisualStyleBackColor = False
        '
        'lblC
        '
        Me.lblC.AutoSize = True
        Me.lblC.Location = New System.Drawing.Point(497, 3)
        Me.lblC.Name = "lblC"
        Me.lblC.Size = New System.Drawing.Size(0, 13)
        Me.lblC.TabIndex = 43
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(932, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 2)
        Me.Label17.TabIndex = 44
        '
        'dgvEmployee
        '
        Me.dgvEmployee.AllowUserToAddRows = False
        Me.dgvEmployee.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpID, Me.EpfNo, Me.EmpName})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEmployee.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmployee.GridColor = System.Drawing.Color.White
        Me.dgvEmployee.Location = New System.Drawing.Point(3, 17)
        Me.dgvEmployee.Name = "dgvEmployee"
        Me.dgvEmployee.RowHeadersVisible = False
        Me.dgvEmployee.RowHeadersWidth = 21
        Me.dgvEmployee.Size = New System.Drawing.Size(995, 382)
        Me.dgvEmployee.TabIndex = 12
        Me.dgvEmployee.Tag = "1"
        '
        'EmpID
        '
        Me.EmpID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpID.HeaderText = "EmpID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Visible = False
        '
        'EpfNo
        '
        Me.EpfNo.HeaderText = "Rel ID"
        Me.EpfNo.Name = "EpfNo"
        Me.EpfNo.ReadOnly = True
        Me.EpfNo.Width = 77
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        Me.EmpName.Width = 115
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvEmployee)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1001, 402)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Roster Review of Selected Employee(s)"
        '
        'pnlData
        '
        Me.pnlData.Controls.Add(Me.Panel3)
        Me.pnlData.Controls.Add(Me.Panel4)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlData.Location = New System.Drawing.Point(0, 48)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(1001, 569)
        Me.pnlData.TabIndex = 46
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1001, 402)
        Me.Panel3.TabIndex = 36
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.TabControl1)
        Me.Panel4.Controls.Add(Me.lblC)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.cmbBranch)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.dtpFrDate)
        Me.Panel4.Controls.Add(Me.cmbDesig)
        Me.Panel4.Controls.Add(Me.dtpToDate)
        Me.Panel4.Controls.Add(Me.cmbType)
        Me.Panel4.Controls.Add(Me.cmdApprove)
        Me.Panel4.Controls.Add(Me.txtSearch)
        Me.Panel4.Controls.Add(Me.rdbDayAndShift)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.cmdConfirm)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.rdbShift)
        Me.Panel4.Controls.Add(Me.cmbCat)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.rdbDay)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.cmbDept)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 402)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1001, 167)
        Me.Panel4.TabIndex = 37
        '
        'cmdApprove
        '
        Me.cmdApprove.BackColor = System.Drawing.Color.Transparent
        Me.cmdApprove.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdApprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdApprove.FlatAppearance.BorderSize = 0
        Me.cmdApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdApprove.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApprove.ForeColor = System.Drawing.Color.White
        Me.cmdApprove.Location = New System.Drawing.Point(750, 68)
        Me.cmdApprove.Name = "cmdApprove"
        Me.cmdApprove.Size = New System.Drawing.Size(10, 26)
        Me.cmdApprove.TabIndex = 40
        Me.cmdApprove.Tag = "1"
        Me.cmdApprove.Text = "&Approve"
        Me.cmdApprove.UseVisualStyleBackColor = False
        Me.cmdApprove.Visible = False
        '
        'cmdConfirm
        '
        Me.cmdConfirm.BackColor = System.Drawing.Color.OrangeRed
        Me.cmdConfirm.BackgroundImage = Global.HRISforBB.My.Resources.Resources.COPPYK
        Me.cmdConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdConfirm.FlatAppearance.BorderSize = 0
        Me.cmdConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConfirm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConfirm.ForeColor = System.Drawing.Color.White
        Me.cmdConfirm.Location = New System.Drawing.Point(500, 13)
        Me.cmdConfirm.Name = "cmdConfirm"
        Me.cmdConfirm.Size = New System.Drawing.Size(26, 26)
        Me.cmdConfirm.TabIndex = 40
        Me.cmdConfirm.Tag = "6"
        Me.cmdConfirm.UseVisualStyleBackColor = False
        '
        'pnlAllk
        '
        Me.pnlAllk.Controls.Add(Me.pnlRight)
        Me.pnlAllk.Controls.Add(Me.pnlLeft)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(1011, 617)
        Me.pnlAllk.TabIndex = 49
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.pnlData)
        Me.pnlRight.Controls.Add(Me.pnlTop)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(10, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(1001, 617)
        Me.pnlRight.TabIndex = 1
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.Button3)
        Me.pnlTop.Controls.Add(Me.Button2)
        Me.pnlTop.Controls.Add(Me.cmdShiftProcess)
        Me.pnlTop.Controls.Add(Me.Button4)
        Me.pnlTop.Controls.Add(Me.cmdRefresh)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.lblRowCoun)
        Me.pnlTop.Controls.Add(Me.Label5)
        Me.pnlTop.Controls.Add(Me.Label25)
        Me.pnlTop.Controls.Add(Me.Button1)
        Me.pnlTop.Controls.Add(Me.lblShift)
        Me.pnlTop.Controls.Add(Me.cmdEdit)
        Me.pnlTop.Controls.Add(Me.GroupBox1)
        Me.pnlTop.Controls.Add(Me.cmbTitle)
        Me.pnlTop.Controls.Add(Me.Label7)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1001, 48)
        Me.pnlTop.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(264, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 49
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.selectNone
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(898, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 45
        Me.Button2.TabStop = False
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmdShiftProcess
        '
        Me.cmdShiftProcess.BackColor = System.Drawing.Color.Transparent
        Me.cmdShiftProcess.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdShiftProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdShiftProcess.FlatAppearance.BorderSize = 0
        Me.cmdShiftProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdShiftProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdShiftProcess.ForeColor = System.Drawing.Color.White
        Me.cmdShiftProcess.Location = New System.Drawing.Point(727, 10)
        Me.cmdShiftProcess.Name = "cmdShiftProcess"
        Me.cmdShiftProcess.Size = New System.Drawing.Size(88, 26)
        Me.cmdShiftProcess.TabIndex = 42
        Me.cmdShiftProcess.Tag = "1"
        Me.cmdShiftProcess.Text = "&Asn Shift"
        Me.cmdShiftProcess.UseVisualStyleBackColor = False
        Me.cmdShiftProcess.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.Location = New System.Drawing.Point(932, 10)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 28)
        Me.Button4.TabIndex = 47
        Me.Button4.Tag = "3"
        Me.Button4.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(966, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 48
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'lblRowCoun
        '
        Me.lblRowCoun.AutoSize = True
        Me.lblRowCoun.Location = New System.Drawing.Point(779, 39)
        Me.lblRowCoun.Name = "lblRowCoun"
        Me.lblRowCoun.Size = New System.Drawing.Size(0, 13)
        Me.lblRowCoun.TabIndex = 39
        Me.lblRowCoun.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(262, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(439, 16)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Click and drag any selected row to change day type or shift"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(65, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(165, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Roster Managment"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(180, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 25)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.White
        Me.lblShift.Location = New System.Drawing.Point(649, 24)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(264, 16)
        Me.lblShift.TabIndex = 10
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdEdit
        '
        Me.cmdEdit.ImageIndex = 0
        Me.cmdEdit.Location = New System.Drawing.Point(630, 39)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(30, 24)
        Me.cmdEdit.TabIndex = 24
        Me.cmdEdit.UseVisualStyleBackColor = True
        Me.cmdEdit.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdEditOffDay)
        Me.GroupBox1.Controls.Add(Me.chkEditSelect)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbWorkDay)
        Me.GroupBox1.Location = New System.Drawing.Point(707, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(37, 33)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'cmdEditOffDay
        '
        Me.cmdEditOffDay.ImageIndex = 0
        Me.cmdEditOffDay.Location = New System.Drawing.Point(176, 45)
        Me.cmdEditOffDay.Name = "cmdEditOffDay"
        Me.cmdEditOffDay.Size = New System.Drawing.Size(30, 24)
        Me.cmdEditOffDay.TabIndex = 24
        Me.cmdEditOffDay.UseVisualStyleBackColor = True
        '
        'chkEditSelect
        '
        Me.chkEditSelect.AutoSize = True
        Me.chkEditSelect.Location = New System.Drawing.Point(29, 19)
        Me.chkEditSelect.Name = "chkEditSelect"
        Me.chkEditSelect.Size = New System.Drawing.Size(131, 17)
        Me.chkEditSelect.TabIndex = 23
        Me.chkEditSelect.Text = "Edit Selected Day "
        Me.chkEditSelect.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(7, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 21)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Off Day Pattern"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbWorkDay
        '
        Me.cmbWorkDay.FormattingEnabled = True
        Me.cmbWorkDay.Location = New System.Drawing.Point(7, 46)
        Me.cmbWorkDay.Name = "cmbWorkDay"
        Me.cmbWorkDay.Size = New System.Drawing.Size(167, 21)
        Me.cmbWorkDay.TabIndex = 11
        '
        'cmbTitle
        '
        Me.cmbTitle.BackColor = System.Drawing.Color.White
        Me.cmbTitle.FormattingEnabled = True
        Me.cmbTitle.Location = New System.Drawing.Point(385, 3)
        Me.cmbTitle.Name = "cmbTitle"
        Me.cmbTitle.Size = New System.Drawing.Size(159, 21)
        Me.cmbTitle.TabIndex = 37
        Me.cmbTitle.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(330, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Title"
        Me.Label7.Visible = False
        '
        'pnlLeft
        '
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(10, 617)
        Me.pnlLeft.TabIndex = 0
        '
        'frmNewRoster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1011, 617)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmNewRoster"
        Me.Text = "frmNewRoster"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCrShifts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.pnlData.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlAllk.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdEditOffDay As System.Windows.Forms.Button
    Friend WithEvents chkEditSelect As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbWorkDay As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDesig As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbDayType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCrShifts As System.Windows.Forms.DataGridView
    Friend WithEvents cmdConfirm As System.Windows.Forms.Button
    Friend WithEvents dgvType As System.Windows.Forms.DataGridView
    Friend WithEvents dType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aval As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents g As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents b As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblC As System.Windows.Forms.Label
    Friend WithEvents cmdApprove As System.Windows.Forms.Button
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents shID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgvEmployee As System.Windows.Forms.DataGridView
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EpfNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRowCoun As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdShiftProcess As System.Windows.Forms.Button
    Friend WithEvents rdbDay As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDayAndShift As System.Windows.Forms.RadioButton
    Friend WithEvents rdbShift As System.Windows.Forms.RadioButton
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
