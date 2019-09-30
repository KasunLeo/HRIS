<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportViewer
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
        Me.cmdBrsReport = New System.Windows.Forms.Button
        Me.dgvDetails1 = New System.Windows.Forms.DataGridView
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EpfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AtDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Shift = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdShowInfo = New System.Windows.Forms.Button
        Me.dgvDetails = New System.Windows.Forms.DataGridView
        Me.ReportID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReportN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.chkCheck = New System.Windows.Forms.CheckBox
        Me.dgvEmps = New System.Windows.Forms.DataGridView
        Me.Catc = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.br = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.typ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.lnkTick = New System.Windows.Forms.LinkLabel
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.cmbDesg = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.cmbTitle = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblEmpSubDept = New System.Windows.Forms.Label
        Me.lblEmpAct = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbEmpSubCat = New System.Windows.Forms.ComboBox
        Me.cmbEmpAct = New System.Windows.Forms.ComboBox
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.lblCount = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.lblMonth9 = New System.Windows.Forms.Label
        Me.lblMonth8 = New System.Windows.Forms.Label
        Me.lblMonth7 = New System.Windows.Forms.Label
        Me.lblMonth3 = New System.Windows.Forms.Label
        Me.lblMonth4 = New System.Windows.Forms.Label
        Me.lblMonth10 = New System.Windows.Forms.Label
        Me.lblMonth12 = New System.Windows.Forms.Label
        Me.lblMonth6 = New System.Windows.Forms.Label
        Me.lblMonth5 = New System.Windows.Forms.Label
        Me.lblMonth11 = New System.Windows.Forms.Label
        Me.lblMonth2 = New System.Windows.Forms.Label
        Me.lblMonth1 = New System.Windows.Forms.Label
        Me.PictureBox24 = New System.Windows.Forms.PictureBox
        Me.PictureBox23 = New System.Windows.Forms.PictureBox
        Me.PictureBox22 = New System.Windows.Forms.PictureBox
        Me.PictureBox21 = New System.Windows.Forms.PictureBox
        Me.PictureBox20 = New System.Windows.Forms.PictureBox
        Me.PictureBox19 = New System.Windows.Forms.PictureBox
        Me.PictureBox18 = New System.Windows.Forms.PictureBox
        Me.PictureBox17 = New System.Windows.Forms.PictureBox
        Me.PictureBox16 = New System.Windows.Forms.PictureBox
        Me.PictureBox15 = New System.Windows.Forms.PictureBox
        Me.PictureBox14 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.chkViewResigned = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.chkMinutes = New System.Windows.Forms.CheckBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.lblCurDate = New System.Windows.Forms.Label
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbActual = New System.Windows.Forms.RadioButton
        Me.rdbNormal = New System.Windows.Forms.RadioButton
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblReportName = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtReportName = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        CType(Me.dgvDetails1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvEmps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdBrsReport
        '
        Me.cmdBrsReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdBrsReport.Location = New System.Drawing.Point(1106, 54)
        Me.cmdBrsReport.Name = "cmdBrsReport"
        Me.cmdBrsReport.Size = New System.Drawing.Size(27, 22)
        Me.cmdBrsReport.TabIndex = 1
        Me.cmdBrsReport.TabStop = False
        Me.cmdBrsReport.Text = "..."
        Me.cmdBrsReport.UseVisualStyleBackColor = True
        Me.cmdBrsReport.Visible = False
        '
        'dgvDetails1
        '
        Me.dgvDetails1.AllowUserToAddRows = False
        Me.dgvDetails1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpID, Me.EpfNo, Me.EmpName, Me.AtDate, Me.InTime, Me.OutDate, Me.OutTime, Me.DayType, Me.Shift})
        Me.dgvDetails1.Location = New System.Drawing.Point(1133, 237)
        Me.dgvDetails1.Name = "dgvDetails1"
        Me.dgvDetails1.ReadOnly = True
        Me.dgvDetails1.RowHeadersWidth = 12
        Me.dgvDetails1.Size = New System.Drawing.Size(36, 58)
        Me.dgvDetails1.TabIndex = 9
        Me.dgvDetails1.Visible = False
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
        Me.EpfNo.Width = 60
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        '
        'AtDate
        '
        Me.AtDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.AtDate.HeaderText = "Date"
        Me.AtDate.Name = "AtDate"
        Me.AtDate.ReadOnly = True
        Me.AtDate.Width = 59
        '
        'InTime
        '
        Me.InTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.InTime.HeaderText = "IN"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        Me.InTime.Width = 45
        '
        'OutDate
        '
        Me.OutDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutDate.HeaderText = "Out Date"
        Me.OutDate.Name = "OutDate"
        Me.OutDate.ReadOnly = True
        Me.OutDate.Width = 77
        '
        'OutTime
        '
        Me.OutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutTime.HeaderText = "OUT"
        Me.OutTime.Name = "OutTime"
        Me.OutTime.ReadOnly = True
        Me.OutTime.Width = 56
        '
        'DayType
        '
        Me.DayType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DayType.HeaderText = "Day Type"
        Me.DayType.Name = "DayType"
        Me.DayType.ReadOnly = True
        Me.DayType.Width = 79
        '
        'Shift
        '
        Me.Shift.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Shift.HeaderText = "Shift ID"
        Me.Shift.Name = "Shift"
        Me.Shift.ReadOnly = True
        Me.Shift.Width = 58
        '
        'cmdShowInfo
        '
        Me.cmdShowInfo.Location = New System.Drawing.Point(1143, 301)
        Me.cmdShowInfo.Name = "cmdShowInfo"
        Me.cmdShowInfo.Size = New System.Drawing.Size(30, 36)
        Me.cmdShowInfo.TabIndex = 2
        Me.cmdShowInfo.Text = "VIEW SELECTED EMPLOYEES ATTENDANCE"
        Me.cmdShowInfo.UseVisualStyleBackColor = True
        Me.cmdShowInfo.Visible = False
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgvDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.ColumnHeadersVisible = False
        Me.dgvDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ReportID, Me.ReportN, Me.Status})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetails.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetails.GridColor = System.Drawing.Color.White
        Me.dgvDetails.Location = New System.Drawing.Point(3, 17)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowHeadersWidth = 21
        Me.dgvDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvDetails.Size = New System.Drawing.Size(209, 457)
        Me.dgvDetails.TabIndex = 44
        '
        'ReportID
        '
        Me.ReportID.HeaderText = "Report ID"
        Me.ReportID.Name = "ReportID"
        Me.ReportID.ReadOnly = True
        Me.ReportID.Visible = False
        '
        'ReportN
        '
        Me.ReportN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ReportN.HeaderText = "                All Report Names"
        Me.ReportN.Name = "ReportN"
        Me.ReportN.ReadOnly = True
        '
        'Status
        '
        Me.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel6)
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1094, 477)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Employee(s)"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.chkCheck)
        Me.Panel6.Controls.Add(Me.dgvEmps)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 109)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1088, 365)
        Me.Panel6.TabIndex = 55
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Location = New System.Drawing.Point(4, 11)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.Size = New System.Drawing.Size(15, 14)
        Me.chkCheck.TabIndex = 56
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'dgvEmps
        '
        Me.dgvEmps.AllowUserToAddRows = False
        Me.dgvEmps.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmps.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Catc, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.nic, Me.br, Me.Dept, Me.Desg, Me.cat, Me.typ})
        Me.dgvEmps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmps.GridColor = System.Drawing.Color.White
        Me.dgvEmps.Location = New System.Drawing.Point(0, 0)
        Me.dgvEmps.Name = "dgvEmps"
        Me.dgvEmps.RowHeadersVisible = False
        Me.dgvEmps.RowHeadersWidth = 12
        Me.dgvEmps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmps.Size = New System.Drawing.Size(1088, 365)
        Me.dgvEmps.TabIndex = 55
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
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Employee ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 106
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Rel ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 67
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Employee Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'nic
        '
        Me.nic.HeaderText = "NIC Number"
        Me.nic.Name = "nic"
        '
        'br
        '
        Me.br.HeaderText = "Branch Name"
        Me.br.Name = "br"
        '
        'Dept
        '
        Me.Dept.HeaderText = "Department"
        Me.Dept.Name = "Dept"
        Me.Dept.ReadOnly = True
        '
        'Desg
        '
        Me.Desg.HeaderText = "Desgnation"
        Me.Desg.Name = "Desg"
        Me.Desg.ReadOnly = True
        Me.Desg.Width = 125
        '
        'cat
        '
        Me.cat.HeaderText = "Category"
        Me.cat.Name = "cat"
        '
        'typ
        '
        Me.typ.HeaderText = "Emp Type"
        Me.typ.Name = "typ"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.LinkLabel1)
        Me.Panel5.Controls.Add(Me.lnkTick)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.cmbCat)
        Me.Panel5.Controls.Add(Me.cmbDesg)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.cmbDept)
        Me.Panel5.Controls.Add(Me.cmbTitle)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.lblEmpSubDept)
        Me.Panel5.Controls.Add(Me.lblEmpAct)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.cmbEmpSubCat)
        Me.Panel5.Controls.Add(Me.cmbEmpAct)
        Me.Panel5.Controls.Add(Me.cmbBranch)
        Me.Panel5.Controls.Add(Me.cmbType)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 17)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1088, 92)
        Me.Panel5.TabIndex = 57
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.OrangeRed
        Me.LinkLabel1.Location = New System.Drawing.Point(855, 72)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(102, 13)
        Me.LinkLabel1.TabIndex = 55
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Un Tick Selected"
        '
        'lnkTick
        '
        Me.lnkTick.AutoSize = True
        Me.lnkTick.LinkColor = System.Drawing.Color.OrangeRed
        Me.lnkTick.Location = New System.Drawing.Point(766, 72)
        Me.lnkTick.Name = "lnkTick"
        Me.lnkTick.Size = New System.Drawing.Size(83, 13)
        Me.lnkTick.TabIndex = 49
        Me.lnkTick.TabStop = True
        Me.lnkTick.Text = "Tick Selected"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Employee Category"
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.White
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(151, 10)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(196, 21)
        Me.cmbCat.TabIndex = 45
        '
        'cmbDesg
        '
        Me.cmbDesg.BackColor = System.Drawing.Color.White
        Me.cmbDesg.FormattingEnabled = True
        Me.cmbDesg.Location = New System.Drawing.Point(151, 38)
        Me.cmbDesg.Name = "cmbDesg"
        Me.cmbDesg.Size = New System.Drawing.Size(196, 21)
        Me.cmbDesg.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(356, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Employee Title"
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(151, 64)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(196, 21)
        Me.cmbDept.TabIndex = 43
        '
        'cmbTitle
        '
        Me.cmbTitle.BackColor = System.Drawing.Color.White
        Me.cmbTitle.FormattingEnabled = True
        Me.cmbTitle.Location = New System.Drawing.Point(469, 64)
        Me.cmbTitle.Name = "cmbTitle"
        Me.cmbTitle.Size = New System.Drawing.Size(177, 21)
        Me.cmbTitle.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 42)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Employee Designation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Employee Type"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Employee Department"
        '
        'lblEmpSubDept
        '
        Me.lblEmpSubDept.AutoSize = True
        Me.lblEmpSubDept.Location = New System.Drawing.Point(656, 42)
        Me.lblEmpSubDept.Name = "lblEmpSubDept"
        Me.lblEmpSubDept.Size = New System.Drawing.Size(86, 13)
        Me.lblEmpSubDept.TabIndex = 51
        Me.lblEmpSubDept.Text = "Sub Category"
        '
        'lblEmpAct
        '
        Me.lblEmpAct.AutoSize = True
        Me.lblEmpAct.Location = New System.Drawing.Point(656, 14)
        Me.lblEmpAct.Name = "lblEmpAct"
        Me.lblEmpAct.Size = New System.Drawing.Size(85, 13)
        Me.lblEmpAct.TabIndex = 51
        Me.lblEmpAct.Text = "Employee Act"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(356, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Employee Branch"
        '
        'cmbEmpSubCat
        '
        Me.cmbEmpSubCat.BackColor = System.Drawing.Color.White
        Me.cmbEmpSubCat.FormattingEnabled = True
        Me.cmbEmpSubCat.Location = New System.Drawing.Point(769, 38)
        Me.cmbEmpSubCat.Name = "cmbEmpSubCat"
        Me.cmbEmpSubCat.Size = New System.Drawing.Size(177, 21)
        Me.cmbEmpSubCat.TabIndex = 50
        '
        'cmbEmpAct
        '
        Me.cmbEmpAct.BackColor = System.Drawing.Color.White
        Me.cmbEmpAct.FormattingEnabled = True
        Me.cmbEmpAct.Location = New System.Drawing.Point(769, 10)
        Me.cmbEmpAct.Name = "cmbEmpAct"
        Me.cmbEmpAct.Size = New System.Drawing.Size(177, 21)
        Me.cmbEmpAct.TabIndex = 50
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(469, 10)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(177, 21)
        Me.cmbBranch.TabIndex = 50
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(469, 38)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(177, 21)
        Me.cmbType.TabIndex = 49
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(295, 539)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 47
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1309, 477)
        Me.Panel2.TabIndex = 49
        '
        'Panel4
        '
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1094, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(215, 477)
        Me.Panel4.TabIndex = 46
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvDetails)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(215, 477)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.notcurved46
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.chkViewResigned)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.chkMinutes)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.dtpFromDate)
        Me.Panel3.Controls.Add(Me.dtpToDate)
        Me.Panel3.Controls.Add(Me.cmdPrevious)
        Me.Panel3.Controls.Add(Me.lblCurDate)
        Me.Panel3.Controls.Add(Me.cmdNext)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1309, 56)
        Me.Panel3.TabIndex = 48
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lblMonth9)
        Me.Panel8.Controls.Add(Me.lblMonth8)
        Me.Panel8.Controls.Add(Me.lblMonth7)
        Me.Panel8.Controls.Add(Me.lblMonth3)
        Me.Panel8.Controls.Add(Me.lblMonth4)
        Me.Panel8.Controls.Add(Me.lblMonth10)
        Me.Panel8.Controls.Add(Me.lblMonth12)
        Me.Panel8.Controls.Add(Me.lblMonth6)
        Me.Panel8.Controls.Add(Me.lblMonth5)
        Me.Panel8.Controls.Add(Me.lblMonth11)
        Me.Panel8.Controls.Add(Me.lblMonth2)
        Me.Panel8.Controls.Add(Me.lblMonth1)
        Me.Panel8.Controls.Add(Me.PictureBox24)
        Me.Panel8.Controls.Add(Me.PictureBox23)
        Me.Panel8.Controls.Add(Me.PictureBox22)
        Me.Panel8.Controls.Add(Me.PictureBox21)
        Me.Panel8.Controls.Add(Me.PictureBox20)
        Me.Panel8.Controls.Add(Me.PictureBox19)
        Me.Panel8.Controls.Add(Me.PictureBox18)
        Me.Panel8.Controls.Add(Me.PictureBox17)
        Me.Panel8.Controls.Add(Me.PictureBox16)
        Me.Panel8.Controls.Add(Me.PictureBox15)
        Me.Panel8.Controls.Add(Me.PictureBox14)
        Me.Panel8.Controls.Add(Me.PictureBox6)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(1079, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(230, 54)
        Me.Panel8.TabIndex = 85
        '
        'lblMonth9
        '
        Me.lblMonth9.AutoSize = True
        Me.lblMonth9.ForeColor = System.Drawing.Color.White
        Me.lblMonth9.Location = New System.Drawing.Point(86, 27)
        Me.lblMonth9.Name = "lblMonth9"
        Me.lblMonth9.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth9.TabIndex = 56
        Me.lblMonth9.Text = "9"
        Me.lblMonth9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth8
        '
        Me.lblMonth8.AutoSize = True
        Me.lblMonth8.ForeColor = System.Drawing.Color.White
        Me.lblMonth8.Location = New System.Drawing.Point(49, 27)
        Me.lblMonth8.Name = "lblMonth8"
        Me.lblMonth8.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth8.TabIndex = 55
        Me.lblMonth8.Text = "8"
        Me.lblMonth8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth7
        '
        Me.lblMonth7.AutoSize = True
        Me.lblMonth7.ForeColor = System.Drawing.Color.White
        Me.lblMonth7.Location = New System.Drawing.Point(12, 27)
        Me.lblMonth7.Name = "lblMonth7"
        Me.lblMonth7.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth7.TabIndex = 54
        Me.lblMonth7.Text = "7"
        Me.lblMonth7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth3
        '
        Me.lblMonth3.AutoSize = True
        Me.lblMonth3.ForeColor = System.Drawing.Color.White
        Me.lblMonth3.Location = New System.Drawing.Point(86, 6)
        Me.lblMonth3.Name = "lblMonth3"
        Me.lblMonth3.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth3.TabIndex = 53
        Me.lblMonth3.Text = "3"
        Me.lblMonth3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth4
        '
        Me.lblMonth4.AutoSize = True
        Me.lblMonth4.ForeColor = System.Drawing.Color.White
        Me.lblMonth4.Location = New System.Drawing.Point(123, 6)
        Me.lblMonth4.Name = "lblMonth4"
        Me.lblMonth4.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth4.TabIndex = 52
        Me.lblMonth4.Text = "4"
        Me.lblMonth4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth10
        '
        Me.lblMonth10.AutoSize = True
        Me.lblMonth10.ForeColor = System.Drawing.Color.White
        Me.lblMonth10.Location = New System.Drawing.Point(120, 28)
        Me.lblMonth10.Name = "lblMonth10"
        Me.lblMonth10.Size = New System.Drawing.Size(21, 13)
        Me.lblMonth10.TabIndex = 51
        Me.lblMonth10.Text = "10"
        Me.lblMonth10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth12
        '
        Me.lblMonth12.AutoSize = True
        Me.lblMonth12.ForeColor = System.Drawing.Color.White
        Me.lblMonth12.Location = New System.Drawing.Point(194, 28)
        Me.lblMonth12.Name = "lblMonth12"
        Me.lblMonth12.Size = New System.Drawing.Size(21, 13)
        Me.lblMonth12.TabIndex = 50
        Me.lblMonth12.Text = "12"
        Me.lblMonth12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth6
        '
        Me.lblMonth6.AutoSize = True
        Me.lblMonth6.ForeColor = System.Drawing.Color.White
        Me.lblMonth6.Location = New System.Drawing.Point(196, 6)
        Me.lblMonth6.Name = "lblMonth6"
        Me.lblMonth6.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth6.TabIndex = 49
        Me.lblMonth6.Text = "6"
        Me.lblMonth6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth5
        '
        Me.lblMonth5.AutoSize = True
        Me.lblMonth5.ForeColor = System.Drawing.Color.White
        Me.lblMonth5.Location = New System.Drawing.Point(159, 6)
        Me.lblMonth5.Name = "lblMonth5"
        Me.lblMonth5.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth5.TabIndex = 48
        Me.lblMonth5.Text = "5"
        Me.lblMonth5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth11
        '
        Me.lblMonth11.AutoSize = True
        Me.lblMonth11.ForeColor = System.Drawing.Color.White
        Me.lblMonth11.Location = New System.Drawing.Point(156, 27)
        Me.lblMonth11.Name = "lblMonth11"
        Me.lblMonth11.Size = New System.Drawing.Size(21, 13)
        Me.lblMonth11.TabIndex = 47
        Me.lblMonth11.Text = "11"
        Me.lblMonth11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth2
        '
        Me.lblMonth2.AutoSize = True
        Me.lblMonth2.ForeColor = System.Drawing.Color.White
        Me.lblMonth2.Location = New System.Drawing.Point(49, 5)
        Me.lblMonth2.Name = "lblMonth2"
        Me.lblMonth2.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth2.TabIndex = 46
        Me.lblMonth2.Text = "2"
        Me.lblMonth2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMonth1
        '
        Me.lblMonth1.AutoSize = True
        Me.lblMonth1.ForeColor = System.Drawing.Color.White
        Me.lblMonth1.Location = New System.Drawing.Point(11, 5)
        Me.lblMonth1.Name = "lblMonth1"
        Me.lblMonth1.Size = New System.Drawing.Size(14, 13)
        Me.lblMonth1.TabIndex = 45
        Me.lblMonth1.Text = "1"
        Me.lblMonth1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox24
        '
        Me.PictureBox24.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox24.Location = New System.Drawing.Point(188, 25)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox24.TabIndex = 15
        Me.PictureBox24.TabStop = False
        '
        'PictureBox23
        '
        Me.PictureBox23.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox23.Location = New System.Drawing.Point(151, 25)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox23.TabIndex = 14
        Me.PictureBox23.TabStop = False
        '
        'PictureBox22
        '
        Me.PictureBox22.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox22.Location = New System.Drawing.Point(114, 25)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox22.TabIndex = 13
        Me.PictureBox22.TabStop = False
        '
        'PictureBox21
        '
        Me.PictureBox21.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox21.Location = New System.Drawing.Point(77, 25)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox21.TabIndex = 12
        Me.PictureBox21.TabStop = False
        '
        'PictureBox20
        '
        Me.PictureBox20.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox20.Location = New System.Drawing.Point(40, 25)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox20.TabIndex = 11
        Me.PictureBox20.TabStop = False
        '
        'PictureBox19
        '
        Me.PictureBox19.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox19.Location = New System.Drawing.Point(3, 25)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox19.TabIndex = 10
        Me.PictureBox19.TabStop = False
        '
        'PictureBox18
        '
        Me.PictureBox18.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox18.Location = New System.Drawing.Point(188, 3)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox18.TabIndex = 9
        Me.PictureBox18.TabStop = False
        '
        'PictureBox17
        '
        Me.PictureBox17.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox17.Location = New System.Drawing.Point(151, 3)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox17.TabIndex = 8
        Me.PictureBox17.TabStop = False
        '
        'PictureBox16
        '
        Me.PictureBox16.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox16.Location = New System.Drawing.Point(114, 3)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox16.TabIndex = 7
        Me.PictureBox16.TabStop = False
        '
        'PictureBox15
        '
        Me.PictureBox15.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox15.Location = New System.Drawing.Point(77, 3)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox15.TabIndex = 6
        Me.PictureBox15.TabStop = False
        '
        'PictureBox14
        '
        Me.PictureBox14.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox14.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox14.TabIndex = 5
        Me.PictureBox14.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackgroundImage = Global.HRISforBB.My.Resources.Resources.frame1_wit_btn
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox6.Location = New System.Drawing.Point(40, 3)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(31, 19)
        Me.PictureBox6.TabIndex = 4
        Me.PictureBox6.TabStop = False
        '
        'chkViewResigned
        '
        Me.chkViewResigned.AutoSize = True
        Me.chkViewResigned.BackColor = System.Drawing.Color.Transparent
        Me.chkViewResigned.ForeColor = System.Drawing.Color.Black
        Me.chkViewResigned.Location = New System.Drawing.Point(754, 23)
        Me.chkViewResigned.Name = "chkViewResigned"
        Me.chkViewResigned.Size = New System.Drawing.Size(185, 17)
        Me.chkViewResigned.TabIndex = 42
        Me.chkViewResigned.Text = "View Resigned Employee(s)"
        Me.chkViewResigned.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(1309, 2)
        Me.Label5.TabIndex = 50
        '
        'chkMinutes
        '
        Me.chkMinutes.AutoSize = True
        Me.chkMinutes.BackColor = System.Drawing.Color.Transparent
        Me.chkMinutes.Location = New System.Drawing.Point(592, 23)
        Me.chkMinutes.Name = "chkMinutes"
        Me.chkMinutes.Size = New System.Drawing.Size(115, 17)
        Me.chkMinutes.TabIndex = 42
        Me.chkMinutes.Text = "Display Minutes"
        Me.chkMinutes.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(18, 25)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(150, 21)
        Me.txtSearch.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(331, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "To Date "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(15, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 13)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Employee Search Text"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(185, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "From Date "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(188, 25)
        Me.dtpFromDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpFromDate.TabIndex = 4
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(334, 25)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpToDate.TabIndex = 5
        '
        'cmdPrevious
        '
        Me.cmdPrevious.BackColor = System.Drawing.Color.Transparent
        Me.cmdPrevious.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Back
        Me.cmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdPrevious.FlatAppearance.BorderSize = 0
        Me.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPrevious.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdPrevious.Location = New System.Drawing.Point(467, 26)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(32, 26)
        Me.cmdPrevious.TabIndex = 73
        Me.cmdPrevious.Tag = "5"
        Me.cmdPrevious.UseVisualStyleBackColor = False
        '
        'lblCurDate
        '
        Me.lblCurDate.AutoSize = True
        Me.lblCurDate.BackColor = System.Drawing.Color.Transparent
        Me.lblCurDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurDate.ForeColor = System.Drawing.Color.DimGray
        Me.lblCurDate.Location = New System.Drawing.Point(502, 31)
        Me.lblCurDate.Name = "lblCurDate"
        Me.lblCurDate.Size = New System.Drawing.Size(32, 13)
        Me.lblCurDate.TabIndex = 74
        Me.lblCurDate.Text = "Day"
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.Transparent
        Me.cmdNext.BackgroundImage = Global.HRISforBB.My.Resources.Resources._next
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdNext.Location = New System.Drawing.Point(538, 26)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(32, 26)
        Me.cmdNext.TabIndex = 72
        Me.cmdNext.Tag = "5"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.rdbActual)
        Me.Panel1.Controls.Add(Me.rdbNormal)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblReportName)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.txtReportName)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1309, 48)
        Me.Panel1.TabIndex = 2
        '
        'rdbActual
        '
        Me.rdbActual.AutoSize = True
        Me.rdbActual.BackColor = System.Drawing.Color.Transparent
        Me.rdbActual.ForeColor = System.Drawing.Color.White
        Me.rdbActual.Location = New System.Drawing.Point(351, 3)
        Me.rdbActual.Name = "rdbActual"
        Me.rdbActual.Size = New System.Drawing.Size(99, 17)
        Me.rdbActual.TabIndex = 50
        Me.rdbActual.TabStop = True
        Me.rdbActual.Text = "Actual Cadre"
        Me.rdbActual.UseVisualStyleBackColor = False
        '
        'rdbNormal
        '
        Me.rdbNormal.AutoSize = True
        Me.rdbNormal.BackColor = System.Drawing.Color.Transparent
        Me.rdbNormal.ForeColor = System.Drawing.Color.White
        Me.rdbNormal.Location = New System.Drawing.Point(234, 3)
        Me.rdbNormal.Name = "rdbNormal"
        Me.rdbNormal.Size = New System.Drawing.Size(99, 17)
        Me.rdbNormal.TabIndex = 49
        Me.rdbNormal.TabStop = True
        Me.rdbNormal.Text = "Active Cadre"
        Me.rdbNormal.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.cmdReport)
        Me.Panel7.Controls.Add(Me.cmdRefresh)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1208, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(101, 48)
        Me.Panel7.TabIndex = 48
        '
        'cmdReport
        '
        Me.cmdReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdReport.BackgroundImage = Global.HRISforBB.My.Resources.Resources.PrintKasun
        Me.cmdReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdReport.FlatAppearance.BorderSize = 0
        Me.cmdReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdReport.Location = New System.Drawing.Point(24, 11)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(28, 28)
        Me.cmdReport.TabIndex = 46
        Me.cmdReport.Tag = "3"
        Me.cmdReport.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(60, 11)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 47
        Me.cmdRefresh.Tag = "3"
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
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'lblReportName
        '
        Me.lblReportName.AutoSize = True
        Me.lblReportName.BackColor = System.Drawing.Color.Transparent
        Me.lblReportName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReportName.ForeColor = System.Drawing.Color.White
        Me.lblReportName.Location = New System.Drawing.Point(481, 16)
        Me.lblReportName.Name = "lblReportName"
        Me.lblReportName.Size = New System.Drawing.Size(114, 13)
        Me.lblReportName.TabIndex = 41
        Me.lblReportName.Text = "Report Selection"
        Me.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(63, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(143, 18)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Report Selection"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtReportName
        '
        Me.txtReportName.AccessibleName = ""
        Me.txtReportName.BackColor = System.Drawing.Color.White
        Me.txtReportName.Location = New System.Drawing.Point(770, 9)
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.ReadOnly = True
        Me.txtReportName.Size = New System.Drawing.Size(22, 21)
        Me.txtReportName.TabIndex = 0
        Me.txtReportName.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(646, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 40
        Me.Label19.Text = "Selected Report"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label19.Visible = False
        '
        'frmReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1309, 581)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.cmdShowInfo)
        Me.Controls.Add(Me.dgvDetails1)
        Me.Controls.Add(Me.cmdBrsReport)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmReportViewer"
        Me.Text = "Show Reports"
        CType(Me.dgvDetails1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.dgvEmps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdBrsReport As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtReportName As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetails1 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdShowInfo As System.Windows.Forms.Button
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EpfNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AtDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Shift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDesg As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents dgvEmps As System.Windows.Forms.DataGridView
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents lblReportName As System.Windows.Forms.Label
    Friend WithEvents ReportID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkMinutes As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewResigned As System.Windows.Forms.CheckBox
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCurDate As System.Windows.Forms.Label
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Catc As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents br As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents typ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkTick As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents rdbActual As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMonth9 As System.Windows.Forms.Label
    Friend WithEvents lblMonth8 As System.Windows.Forms.Label
    Friend WithEvents lblMonth7 As System.Windows.Forms.Label
    Friend WithEvents lblMonth3 As System.Windows.Forms.Label
    Friend WithEvents lblMonth4 As System.Windows.Forms.Label
    Friend WithEvents lblMonth10 As System.Windows.Forms.Label
    Friend WithEvents lblMonth12 As System.Windows.Forms.Label
    Friend WithEvents lblMonth6 As System.Windows.Forms.Label
    Friend WithEvents lblMonth5 As System.Windows.Forms.Label
    Friend WithEvents lblMonth11 As System.Windows.Forms.Label
    Friend WithEvents lblMonth2 As System.Windows.Forms.Label
    Friend WithEvents lblMonth1 As System.Windows.Forms.Label
    Friend WithEvents lblEmpAct As System.Windows.Forms.Label
    Friend WithEvents cmbEmpAct As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpSubDept As System.Windows.Forms.Label
    Friend WithEvents cmbEmpSubCat As System.Windows.Forms.ComboBox
End Class
