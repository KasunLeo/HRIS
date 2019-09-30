<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployeePayItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeePayItem))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvAdAtForm = New System.Windows.Forms.DataGridView()
        Me.dgvFormula = New System.Windows.Forms.DataGridView()
        Me.dgvFixed = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvEmp = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bSalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbDesignation = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbCostCenter = New System.Windows.Forms.ComboBox()
        Me.cmbPrCatagory = New System.Windows.Forms.ComboBox()
        Me.cmbbranch = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbPayCenter = New System.Windows.Forms.ComboBox()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbReligion = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbEmpType = New System.Windows.Forms.ComboBox()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkAttendanceAllowan = New System.Windows.Forms.CheckBox()
        Me.cmbSubCategory = New System.Windows.Forms.ComboBox()
        Me.chkFormula = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.chkFixed = New System.Windows.Forms.CheckBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtDept = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmPnO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkTick = New System.Windows.Forms.CheckBox()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAdAtForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFixed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.dgvAdAtForm)
        Me.Panel1.Controls.Add(Me.dgvFormula)
        Me.Panel1.Controls.Add(Me.dgvFixed)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(949, 66)
        Me.Panel1.TabIndex = 72
        '
        'dgvAdAtForm
        '
        Me.dgvAdAtForm.AllowUserToAddRows = False
        Me.dgvAdAtForm.AllowUserToDeleteRows = False
        Me.dgvAdAtForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdAtForm.Location = New System.Drawing.Point(589, 4)
        Me.dgvAdAtForm.Name = "dgvAdAtForm"
        Me.dgvAdAtForm.ReadOnly = True
        Me.dgvAdAtForm.Size = New System.Drawing.Size(85, 58)
        Me.dgvAdAtForm.TabIndex = 72
        Me.dgvAdAtForm.Visible = False
        '
        'dgvFormula
        '
        Me.dgvFormula.AllowUserToAddRows = False
        Me.dgvFormula.AllowUserToDeleteRows = False
        Me.dgvFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFormula.Location = New System.Drawing.Point(499, 4)
        Me.dgvFormula.Name = "dgvFormula"
        Me.dgvFormula.ReadOnly = True
        Me.dgvFormula.Size = New System.Drawing.Size(85, 58)
        Me.dgvFormula.TabIndex = 71
        Me.dgvFormula.Visible = False
        '
        'dgvFixed
        '
        Me.dgvFixed.AllowUserToAddRows = False
        Me.dgvFixed.AllowUserToDeleteRows = False
        Me.dgvFixed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFixed.Location = New System.Drawing.Point(407, 4)
        Me.dgvFixed.Name = "dgvFixed"
        Me.dgvFixed.ReadOnly = True
        Me.dgvFixed.Size = New System.Drawing.Size(85, 58)
        Me.dgvFixed.TabIndex = 70
        Me.dgvFixed.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label12.Location = New System.Drawing.Point(9, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(228, 16)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Copy Salary Items to Other(s)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label10.Location = New System.Drawing.Point(0, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(949, 2)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Employee No"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvEmp
        '
        Me.dgvEmp.AllowUserToAddRows = False
        Me.dgvEmp.AllowUserToDeleteRows = False
        Me.dgvEmp.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column7, Me.Column8, Me.Column6, Me.nic, Me.comp, Me.Column1, Me.Column2, Me.bSalary, Me.branch, Me.cat})
        Me.dgvEmp.Location = New System.Drawing.Point(3, 122)
        Me.dgvEmp.Name = "dgvEmp"
        Me.dgvEmp.RowHeadersWidth = 6
        Me.dgvEmp.Size = New System.Drawing.Size(946, 269)
        Me.dgvEmp.TabIndex = 141
        Me.dgvEmp.Tag = "1"
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 22
        '
        'Column7
        '
        Me.Column7.HeaderText = "Reg ID"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column7.Width = 53
        '
        'Column8
        '
        Me.Column8.HeaderText = "EMP No"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column8.Width = 55
        '
        'Column6
        '
        Me.Column6.HeaderText = "Name"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column6.Width = 156
        '
        'nic
        '
        Me.nic.HeaderText = "NIC"
        Me.nic.Name = "nic"
        Me.nic.Width = 88
        '
        'comp
        '
        Me.comp.HeaderText = "Compavy"
        Me.comp.Name = "comp"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Designation"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 102
        '
        'Column2
        '
        Me.Column2.HeaderText = "Department"
        Me.Column2.Name = "Column2"
        '
        'bSalary
        '
        Me.bSalary.HeaderText = "Bas Salary"
        Me.bSalary.Name = "bSalary"
        Me.bSalary.Width = 77
        '
        'branch
        '
        Me.branch.HeaderText = "Branch Name"
        Me.branch.Name = "branch"
        '
        'cat
        '
        Me.cat.HeaderText = "Category"
        Me.cat.Name = "cat"
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImage = CType(resources.GetObject("cmdSave.BackgroundImage"), System.Drawing.Image)
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(755, 551)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(88, 26)
        Me.cmdSave.TabIndex = 159
        Me.cmdSave.Tag = "1"
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SkyBlue
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-3, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(952, 21)
        Me.Label3.TabIndex = 142
        Me.Label3.Text = "Copy To Following Selected List"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdExit
        '
        Me.cmdExit.BackgroundImage = CType(resources.GetObject("cmdExit.BackgroundImage"), System.Drawing.Image)
        Me.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.White
        Me.cmdExit.Location = New System.Drawing.Point(849, 551)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(88, 26)
        Me.cmdExit.TabIndex = 143
        Me.cmdExit.Tag = "1"
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(358, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 151
        Me.Label7.Text = "Designation"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(358, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 153
        Me.Label9.Text = "Department"
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRefresh.BackgroundImage = CType(resources.GetObject("btnRefresh.BackgroundImage"), System.Drawing.Image)
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(294, 20)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(24, 24)
        Me.btnRefresh.TabIndex = 158
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(657, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 13)
        Me.Label19.TabIndex = 157
        Me.Label19.Text = "Cost Center"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 13)
        Me.Label13.TabIndex = 155
        Me.Label13.Text = "Process Category"
        '
        'cmbDesignation
        '
        Me.cmbDesignation.FormattingEnabled = True
        Me.cmbDesignation.Location = New System.Drawing.Point(439, 20)
        Me.cmbDesignation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Size = New System.Drawing.Size(162, 21)
        Me.cmbDesignation.TabIndex = 146
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(18, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 154
        Me.Label17.Text = "Company"
        '
        'cmbCostCenter
        '
        Me.cmbCostCenter.FormattingEnabled = True
        Me.cmbCostCenter.Location = New System.Drawing.Point(744, 47)
        Me.cmbCostCenter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCostCenter.Name = "cmbCostCenter"
        Me.cmbCostCenter.Size = New System.Drawing.Size(162, 21)
        Me.cmbCostCenter.TabIndex = 150
        '
        'cmbPrCatagory
        '
        Me.cmbPrCatagory.BackColor = System.Drawing.Color.White
        Me.cmbPrCatagory.FormattingEnabled = True
        Me.cmbPrCatagory.Location = New System.Drawing.Point(126, 47)
        Me.cmbPrCatagory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPrCatagory.Name = "cmbPrCatagory"
        Me.cmbPrCatagory.Size = New System.Drawing.Size(162, 21)
        Me.cmbPrCatagory.TabIndex = 144
        '
        'cmbbranch
        '
        Me.cmbbranch.FormattingEnabled = True
        Me.cmbbranch.Location = New System.Drawing.Point(439, 47)
        Me.cmbbranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbbranch.Name = "cmbbranch"
        Me.cmbbranch.Size = New System.Drawing.Size(162, 21)
        Me.cmbbranch.TabIndex = 147
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(657, 23)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 156
        Me.Label20.Text = "Pay Center"
        '
        'cmbPayCenter
        '
        Me.cmbPayCenter.FormattingEnabled = True
        Me.cmbPayCenter.Location = New System.Drawing.Point(744, 20)
        Me.cmbPayCenter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPayCenter.Name = "cmbPayCenter"
        Me.cmbPayCenter.Size = New System.Drawing.Size(162, 21)
        Me.cmbPayCenter.TabIndex = 149
        '
        'cmbCompany
        '
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(126, 74)
        Me.cmbCompany.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(162, 21)
        Me.cmbCompany.TabIndex = 145
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Branch"
        '
        'cmbDepartment
        '
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(439, 74)
        Me.cmbDepartment.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(162, 21)
        Me.cmbDepartment.TabIndex = 148
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(126, 20)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(162, 21)
        Me.txtSearch.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.Location = New System.Drawing.Point(18, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Employee Name "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbReligion)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cmbEmpType)
        Me.GroupBox1.Controls.Add(Me.cmbGender)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.chkAttendanceAllowan)
        Me.GroupBox1.Controls.Add(Me.cmbSubCategory)
        Me.GroupBox1.Controls.Add(Me.chkFormula)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.chkFixed)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.cmbDepartment)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbCompany)
        Me.GroupBox1.Controls.Add(Me.cmbPayCenter)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cmbbranch)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbPrCatagory)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbCostCenter)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.cmbDesignation)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 392)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(925, 153)
        Me.GroupBox1.TabIndex = 162
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Employee(s)"
        '
        'cmbReligion
        '
        Me.cmbReligion.FormattingEnabled = True
        Me.cmbReligion.Location = New System.Drawing.Point(744, 101)
        Me.cmbReligion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbReligion.Name = "cmbReligion"
        Me.cmbReligion.Size = New System.Drawing.Size(162, 21)
        Me.cmbReligion.TabIndex = 188
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(657, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 189
        Me.Label18.Text = "Act Type"
        '
        'cmbEmpType
        '
        Me.cmbEmpType.FormattingEnabled = True
        Me.cmbEmpType.Location = New System.Drawing.Point(439, 101)
        Me.cmbEmpType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbEmpType.Name = "cmbEmpType"
        Me.cmbEmpType.Size = New System.Drawing.Size(162, 21)
        Me.cmbEmpType.TabIndex = 185
        '
        'cmbGender
        '
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Location = New System.Drawing.Point(126, 101)
        Me.cmbGender.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(162, 21)
        Me.cmbGender.TabIndex = 184
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(358, 104)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(67, 13)
        Me.Label21.TabIndex = 186
        Me.Label21.Text = "Emp. Type"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(18, 104)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 13)
        Me.Label22.TabIndex = 187
        Me.Label22.Text = "Gender"
        '
        'chkAttendanceAllowan
        '
        Me.chkAttendanceAllowan.AutoSize = True
        Me.chkAttendanceAllowan.Location = New System.Drawing.Point(744, 131)
        Me.chkAttendanceAllowan.Name = "chkAttendanceAllowan"
        Me.chkAttendanceAllowan.Size = New System.Drawing.Size(170, 17)
        Me.chkAttendanceAllowan.TabIndex = 75
        Me.chkAttendanceAllowan.Text = "Update Attendance Fields"
        Me.chkAttendanceAllowan.UseVisualStyleBackColor = True
        '
        'cmbSubCategory
        '
        Me.cmbSubCategory.FormattingEnabled = True
        Me.cmbSubCategory.Location = New System.Drawing.Point(744, 74)
        Me.cmbSubCategory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSubCategory.Name = "cmbSubCategory"
        Me.cmbSubCategory.Size = New System.Drawing.Size(162, 21)
        Me.cmbSubCategory.TabIndex = 168
        '
        'chkFormula
        '
        Me.chkFormula.AutoSize = True
        Me.chkFormula.Location = New System.Drawing.Point(439, 131)
        Me.chkFormula.Name = "chkFormula"
        Me.chkFormula.Size = New System.Drawing.Size(152, 17)
        Me.chkFormula.TabIndex = 74
        Me.chkFormula.Text = "Update Formula Fields"
        Me.chkFormula.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(657, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 169
        Me.Label16.Text = "Sub Category"
        '
        'chkFixed
        '
        Me.chkFixed.AutoSize = True
        Me.chkFixed.Location = New System.Drawing.Point(126, 131)
        Me.chkFixed.Name = "chkFixed"
        Me.chkFixed.Size = New System.Drawing.Size(136, 17)
        Me.chkFixed.TabIndex = 73
        Me.chkFixed.Text = "Update Fixed Fields"
        Me.chkFixed.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(12, 558)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 162
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(435, 7)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(252, 21)
        Me.txtName.TabIndex = 166
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label4.Location = New System.Drawing.Point(388, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 167
        Me.Label4.Text = "Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNo
        '
        Me.txtNo.Location = New System.Drawing.Point(121, 7)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.ReadOnly = True
        Me.txtNo.Size = New System.Drawing.Size(86, 21)
        Me.txtNo.TabIndex = 163
        '
        'Button6
        '
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(209, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(24, 24)
        Me.Button6.TabIndex = 165
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label11.Location = New System.Drawing.Point(9, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 13)
        Me.Label11.TabIndex = 164
        Me.Label11.Text = "Selected Reg ID"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.txtDept)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtEmPnO)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtName)
        Me.Panel3.Controls.Add(Me.txtNo)
        Me.Panel3.Controls.Add(Me.Button6)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(949, 34)
        Me.Panel3.TabIndex = 169
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(784, 7)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(159, 21)
        Me.txtDept.TabIndex = 171
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label8.Location = New System.Drawing.Point(697, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 172
        Me.Label8.Text = "Department"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmPnO
        '
        Me.txtEmPnO.Location = New System.Drawing.Point(293, 7)
        Me.txtEmPnO.Name = "txtEmPnO"
        Me.txtEmPnO.ReadOnly = True
        Me.txtEmPnO.Size = New System.Drawing.Size(86, 21)
        Me.txtEmPnO.TabIndex = 170
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label6.Location = New System.Drawing.Point(235, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 169
        Me.Label6.Text = "Emp No"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(949, 2)
        Me.Label5.TabIndex = 168
        '
        'chkTick
        '
        Me.chkTick.AutoSize = True
        Me.chkTick.Location = New System.Drawing.Point(12, 133)
        Me.chkTick.Name = "chkTick"
        Me.chkTick.Size = New System.Drawing.Size(15, 14)
        Me.chkTick.TabIndex = 162
        Me.chkTick.UseVisualStyleBackColor = True
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(383, 563)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(289, 8)
        Me.PB.TabIndex = 170
        Me.PB.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(301, 558)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(57, 13)
        Me.lblProgress.TabIndex = 162
        Me.lblProgress.Text = "Progress"
        Me.lblProgress.Visible = False
        '
        'frmEmployeePayItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(949, 583)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.chkTick)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvEmp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdExit)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmEmployeePayItem"
        Me.Text = "Copy Salary Items to Other(s)"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvAdAtForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFormula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFixed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgvEmp As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbCostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbPayCenter As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNo As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkTick As System.Windows.Forms.CheckBox
    Friend WithEvents dgvFixed As System.Windows.Forms.DataGridView
    Friend WithEvents dgvFormula As System.Windows.Forms.DataGridView
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents dgvAdAtForm As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSubCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkFixed As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttendanceAllowan As System.Windows.Forms.CheckBox
    Friend WithEvents chkFormula As System.Windows.Forms.CheckBox
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bSalary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents branch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmPnO As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbReligion As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
