<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportExtraDaystoLeave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportExtraDaystoLeave))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkCheck = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbDesg = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbTitle = New System.Windows.Forms.ComboBox
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dgvEmps = New System.Windows.Forms.DataGridView
        Me.Catc = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EPFNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Desg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dept = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sts = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvLvTypes = New System.Windows.Forms.DataGridView
        Me.dsgID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dsgName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoLv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EvtLv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvExtraDay = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkImport = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTotImported = New System.Windows.Forms.TextBox
        Me.txtEntitled = New System.Windows.Forms.TextBox
        Me.txtNewEntitlement = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvEmps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvLvTypes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExtraDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkCheck)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cmbDept)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmbDesg)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmbTitle)
        Me.GroupBox3.Controls.Add(Me.cmbBranch)
        Me.GroupBox3.Controls.Add(Me.cmbCat)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.cmbType)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.dgvEmps)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(642, 458)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Selected Employee(s)"
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Location = New System.Drawing.Point(5, 112)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.Size = New System.Drawing.Size(15, 14)
        Me.chkCheck.TabIndex = 32
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Employee Designation"
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(462, 24)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(170, 21)
        Me.cmbDept.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(327, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Employee Title"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(327, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(135, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Employee Department"
        '
        'cmbDesg
        '
        Me.cmbDesg.BackColor = System.Drawing.Color.White
        Me.cmbDesg.FormattingEnabled = True
        Me.cmbDesg.Location = New System.Drawing.Point(144, 24)
        Me.cmbDesg.Name = "cmbDesg"
        Me.cmbDesg.Size = New System.Drawing.Size(170, 21)
        Me.cmbDesg.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Employee Category"
        '
        'cmbTitle
        '
        Me.cmbTitle.BackColor = System.Drawing.Color.White
        Me.cmbTitle.FormattingEnabled = True
        Me.cmbTitle.Location = New System.Drawing.Point(462, 78)
        Me.cmbTitle.Name = "cmbTitle"
        Me.cmbTitle.Size = New System.Drawing.Size(170, 21)
        Me.cmbTitle.TabIndex = 49
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(462, 51)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(170, 21)
        Me.cmbBranch.TabIndex = 46
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.White
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(144, 78)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(170, 21)
        Me.cmbCat.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 13)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "Employee Type"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(144, 51)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(170, 21)
        Me.cmbType.TabIndex = 45
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(327, 54)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 13)
        Me.Label16.TabIndex = 47
        Me.Label16.Text = "Employee Branch"
        '
        'dgvEmps
        '
        Me.dgvEmps.AllowUserToAddRows = False
        Me.dgvEmps.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmps.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Catc, Me.EmpID, Me.EPFNo, Me.EmpName, Me.Desg, Me.Dept, Me.sts})
        Me.dgvEmps.GridColor = System.Drawing.Color.White
        Me.dgvEmps.Location = New System.Drawing.Point(1, 107)
        Me.dgvEmps.Name = "dgvEmps"
        Me.dgvEmps.RowHeadersVisible = False
        Me.dgvEmps.RowHeadersWidth = 12
        Me.dgvEmps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmps.Size = New System.Drawing.Size(638, 345)
        Me.dgvEmps.TabIndex = 31
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
        Me.EPFNo.Width = 88
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
        Me.Desg.Width = 155
        '
        'Dept
        '
        Me.Dept.HeaderText = "Department"
        Me.Dept.Name = "Dept"
        Me.Dept.ReadOnly = True
        Me.Dept.Width = 155
        '
        'sts
        '
        Me.sts.HeaderText = "Status"
        Me.sts.Name = "sts"
        Me.sts.ReadOnly = True
        Me.sts.Visible = False
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(749, 6)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpToDate.TabIndex = 17
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(521, 6)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpFrDate.TabIndex = 17
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(148, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(256, 21)
        Me.txtSearch.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(969, 48)
        Me.Panel1.TabIndex = 10
        Me.Panel1.Tag = "1"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = CType(resources.GetObject("cmdSave.BackgroundImage"), System.Drawing.Image)
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdSave.Location = New System.Drawing.Point(894, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 47
        Me.cmdSave.Tag = "3"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRefresh.Location = New System.Drawing.Point(932, 10)
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
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(61, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(240, 18)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Import Extra Days as Leave"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(969, 2)
        Me.Label11.TabIndex = 36
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.notcurved46
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.dtpToDate)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.dtpFrDate)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(969, 32)
        Me.Panel3.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(969, 2)
        Me.Label1.TabIndex = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(8, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Employee Search Text"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(689, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "To Date "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(445, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "From Date "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvLvTypes
        '
        Me.dgvLvTypes.AllowUserToAddRows = False
        Me.dgvLvTypes.BackgroundColor = System.Drawing.Color.White
        Me.dgvLvTypes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLvTypes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dsgID, Me.dsgName, Me.NoLv, Me.EvtLv, Me.st})
        Me.dgvLvTypes.GridColor = System.Drawing.Color.White
        Me.dgvLvTypes.Location = New System.Drawing.Point(664, 245)
        Me.dgvLvTypes.Name = "dgvLvTypes"
        Me.dgvLvTypes.ReadOnly = True
        Me.dgvLvTypes.RowHeadersVisible = False
        Me.dgvLvTypes.RowHeadersWidth = 12
        Me.dgvLvTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLvTypes.Size = New System.Drawing.Size(299, 213)
        Me.dgvLvTypes.TabIndex = 52
        Me.dgvLvTypes.Tag = "1"
        '
        'dsgID
        '
        Me.dsgID.HeaderText = "EmpID"
        Me.dsgID.Name = "dsgID"
        Me.dsgID.ReadOnly = True
        Me.dsgID.Visible = False
        Me.dsgID.Width = 77
        '
        'dsgName
        '
        Me.dsgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dsgName.HeaderText = "Description"
        Me.dsgName.Name = "dsgName"
        Me.dsgName.ReadOnly = True
        '
        'NoLv
        '
        Me.NoLv.HeaderText = "Tot Leave"
        Me.NoLv.Name = "NoLv"
        Me.NoLv.ReadOnly = True
        Me.NoLv.Width = 88
        '
        'EvtLv
        '
        Me.EvtLv.HeaderText = "Utiized Leave"
        Me.EvtLv.Name = "EvtLv"
        Me.EvtLv.ReadOnly = True
        Me.EvtLv.Width = 88
        '
        'st
        '
        Me.st.HeaderText = "status"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        Me.st.Visible = False
        Me.st.Width = 66
        '
        'dgvExtraDay
        '
        Me.dgvExtraDay.AllowUserToAddRows = False
        Me.dgvExtraDay.BackgroundColor = System.Drawing.Color.White
        Me.dgvExtraDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvExtraDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExtraDay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.chkImport, Me.DataGridViewTextBoxColumn4})
        Me.dgvExtraDay.GridColor = System.Drawing.Color.White
        Me.dgvExtraDay.Location = New System.Drawing.Point(664, 27)
        Me.dgvExtraDay.Name = "dgvExtraDay"
        Me.dgvExtraDay.RowHeadersVisible = False
        Me.dgvExtraDay.RowHeadersWidth = 12
        Me.dgvExtraDay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExtraDay.Size = New System.Drawing.Size(299, 149)
        Me.dgvExtraDay.TabIndex = 52
        Me.dgvExtraDay.Tag = "1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "EmpID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 77
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Att Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Additional Day"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 88
        '
        'chkImport
        '
        Me.chkImport.HeaderText = ""
        Me.chkImport.Name = "chkImport"
        Me.chkImport.Width = 24
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "status"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(661, 229)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "All Leave Types"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(770, 236)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(195, 2)
        Me.Label3.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(661, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 13)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Extra Days Summary"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(808, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(155, 2)
        Me.Label13.TabIndex = 56
        '
        'txtTotImported
        '
        Me.txtTotImported.Location = New System.Drawing.Point(766, 201)
        Me.txtTotImported.Name = "txtTotImported"
        Me.txtTotImported.Size = New System.Drawing.Size(94, 21)
        Me.txtTotImported.TabIndex = 58
        '
        'txtEntitled
        '
        Me.txtEntitled.Location = New System.Drawing.Point(664, 201)
        Me.txtEntitled.Name = "txtEntitled"
        Me.txtEntitled.Size = New System.Drawing.Size(94, 21)
        Me.txtEntitled.TabIndex = 59
        '
        'txtNewEntitlement
        '
        Me.txtNewEntitlement.Location = New System.Drawing.Point(868, 201)
        Me.txtNewEntitlement.Name = "txtNewEntitlement"
        Me.txtNewEntitlement.Size = New System.Drawing.Size(94, 21)
        Me.txtNewEntitlement.TabIndex = 60
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(661, 184)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "Total entitled"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(763, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 13)
        Me.Label17.TabIndex = 62
        Me.Label17.Text = "To be Imported"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(865, 184)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 13)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "New Entitlement"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(940, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 24)
        Me.Button2.TabIndex = 64
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.dgvLvTypes)
        Me.Panel2.Controls.Add(Me.Label18)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.dgvExtraDay)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtNewEntitlement)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtEntitled)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtTotImported)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 80)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(969, 511)
        Me.Panel2.TabIndex = 65
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 467)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(969, 44)
        Me.Panel4.TabIndex = 65
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel2)
        Me.pnlAllk.Controls.Add(Me.Panel3)
        Me.pnlAllk.Controls.Add(Me.Panel1)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(971, 593)
        Me.pnlAllk.TabIndex = 4
        '
        'frmImportExtraDaystoLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(971, 593)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmImportExtraDaystoLeave"
        Me.Text = "Import Extra Days to Leave"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvEmps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvLvTypes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExtraDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbDesg As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvEmps As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvLvTypes As System.Windows.Forms.DataGridView
    Friend WithEvents dgvExtraDay As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Catc As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EPFNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Desg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dsgID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dsgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoLv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EvtLv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkImport As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTotImported As System.Windows.Forms.TextBox
    Friend WithEvents txtEntitled As System.Windows.Forms.TextBox
    Friend WithEvents txtNewEntitlement As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
