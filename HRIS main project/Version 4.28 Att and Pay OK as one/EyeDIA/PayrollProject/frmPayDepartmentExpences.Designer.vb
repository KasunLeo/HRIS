<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartmentExpences
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartmentExpences))
        Me.dgvSearchK = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nic = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bSalary = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkTick = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbReligion = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbEmpType = New System.Windows.Forms.ComboBox()
        Me.cmbGender = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbSubCategory = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.cmbPayCenter = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbbranch = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbProcessCategory = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbCostCenter = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbDesignation = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PG = New System.Windows.Forms.ProgressBar()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rdPermanant = New System.Windows.Forms.RadioButton()
        Me.rdTemporary = New System.Windows.Forms.RadioButton()
        Me.cmbSalarySheet = New System.Windows.Forms.ComboBox()
        Me.dtpPayDate = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvDept = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        CType(Me.dgvSearchK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvDept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSearchK
        '
        Me.dgvSearchK.AllowUserToAddRows = False
        Me.dgvSearchK.AllowUserToDeleteRows = False
        Me.dgvSearchK.BackgroundColor = System.Drawing.Color.White
        Me.dgvSearchK.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSearchK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearchK.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn2, Me.nic, Me.cName, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.bSalary, Me.branch, Me.cat})
        Me.dgvSearchK.Location = New System.Drawing.Point(-3, 120)
        Me.dgvSearchK.Name = "dgvSearchK"
        Me.dgvSearchK.RowHeadersWidth = 6
        Me.dgvSearchK.Size = New System.Drawing.Size(967, 256)
        Me.dgvSearchK.TabIndex = 185
        Me.dgvSearchK.Tag = "1"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 22
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Reg ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 53
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "EMP No"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 55
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 156
        '
        'nic
        '
        Me.nic.HeaderText = "NIC"
        Me.nic.Name = "nic"
        Me.nic.Width = 88
        '
        'cName
        '
        Me.cName.HeaderText = "Company"
        Me.cName.Name = "cName"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Designation"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 102
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Department"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
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
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SkyBlue
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(-3, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(967, 21)
        Me.Label12.TabIndex = 186
        Me.Label12.Text = "Process Following Selected List"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Payslip Process"
        '
        'chkTick
        '
        Me.chkTick.AutoSize = True
        Me.chkTick.Location = New System.Drawing.Point(7, 133)
        Me.chkTick.Name = "chkTick"
        Me.chkTick.Size = New System.Drawing.Size(15, 14)
        Me.chkTick.TabIndex = 188
        Me.chkTick.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbReligion)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.cmbEmpType)
        Me.GroupBox1.Controls.Add(Me.cmbGender)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.cmbSubCategory)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.cmbDepartment)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbCompany)
        Me.GroupBox1.Controls.Add(Me.cmbPayCenter)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cmbbranch)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbProcessCategory)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbCostCenter)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.cmbDesignation)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 394)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(946, 130)
        Me.GroupBox1.TabIndex = 187
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter Employee(s)"
        '
        'cmbReligion
        '
        Me.cmbReligion.FormattingEnabled = True
        Me.cmbReligion.Location = New System.Drawing.Point(767, 100)
        Me.cmbReligion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbReligion.Name = "cmbReligion"
        Me.cmbReligion.Size = New System.Drawing.Size(162, 21)
        Me.cmbReligion.TabIndex = 200
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(680, 103)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 201
        Me.Label21.Text = "Religion"
        '
        'cmbEmpType
        '
        Me.cmbEmpType.FormattingEnabled = True
        Me.cmbEmpType.Location = New System.Drawing.Point(449, 100)
        Me.cmbEmpType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbEmpType.Name = "cmbEmpType"
        Me.cmbEmpType.Size = New System.Drawing.Size(162, 21)
        Me.cmbEmpType.TabIndex = 197
        '
        'cmbGender
        '
        Me.cmbGender.FormattingEnabled = True
        Me.cmbGender.Location = New System.Drawing.Point(126, 100)
        Me.cmbGender.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbGender.Name = "cmbGender"
        Me.cmbGender.Size = New System.Drawing.Size(162, 21)
        Me.cmbGender.TabIndex = 196
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(368, 104)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 198
        Me.Label22.Text = "Emp. Type"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(18, 103)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 199
        Me.Label23.Text = "Gender"
        '
        'cmbSubCategory
        '
        Me.cmbSubCategory.FormattingEnabled = True
        Me.cmbSubCategory.Location = New System.Drawing.Point(767, 72)
        Me.cmbSubCategory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSubCategory.Name = "cmbSubCategory"
        Me.cmbSubCategory.Size = New System.Drawing.Size(162, 21)
        Me.cmbSubCategory.TabIndex = 164
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(680, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 165
        Me.Label16.Text = "Sub Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label3.Location = New System.Drawing.Point(18, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 161
        Me.Label3.Text = "Employee Name "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(126, 18)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(162, 21)
        Me.txtSearch.TabIndex = 160
        '
        'cmbDepartment
        '
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(449, 72)
        Me.cmbDepartment.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(162, 21)
        Me.cmbDepartment.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(368, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Branch"
        '
        'cmbCompany
        '
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(126, 72)
        Me.cmbCompany.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(162, 21)
        Me.cmbCompany.TabIndex = 145
        '
        'cmbPayCenter
        '
        Me.cmbPayCenter.FormattingEnabled = True
        Me.cmbPayCenter.Location = New System.Drawing.Point(767, 18)
        Me.cmbPayCenter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPayCenter.Name = "cmbPayCenter"
        Me.cmbPayCenter.Size = New System.Drawing.Size(162, 21)
        Me.cmbPayCenter.TabIndex = 149
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(680, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 156
        Me.Label20.Text = "Pay Center"
        '
        'cmbbranch
        '
        Me.cmbbranch.FormattingEnabled = True
        Me.cmbbranch.Location = New System.Drawing.Point(449, 45)
        Me.cmbbranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbbranch.Name = "cmbbranch"
        Me.cmbbranch.Size = New System.Drawing.Size(162, 21)
        Me.cmbbranch.TabIndex = 147
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(368, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 151
        Me.Label6.Text = "Designation"
        '
        'cmbProcessCategory
        '
        Me.cmbProcessCategory.BackColor = System.Drawing.Color.White
        Me.cmbProcessCategory.FormattingEnabled = True
        Me.cmbProcessCategory.Location = New System.Drawing.Point(126, 45)
        Me.cmbProcessCategory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbProcessCategory.Name = "cmbProcessCategory"
        Me.cmbProcessCategory.Size = New System.Drawing.Size(162, 21)
        Me.cmbProcessCategory.TabIndex = 144
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(368, 76)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 153
        Me.Label10.Text = "Department"
        '
        'cmbCostCenter
        '
        Me.cmbCostCenter.FormattingEnabled = True
        Me.cmbCostCenter.Location = New System.Drawing.Point(767, 45)
        Me.cmbCostCenter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCostCenter.Name = "cmbCostCenter"
        Me.cmbCostCenter.Size = New System.Drawing.Size(162, 21)
        Me.cmbCostCenter.TabIndex = 150
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(18, 75)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 154
        Me.Label17.Text = "Company"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(680, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 13)
        Me.Label19.TabIndex = 157
        Me.Label19.Text = "Cost Center"
        '
        'cmbDesignation
        '
        Me.cmbDesignation.FormattingEnabled = True
        Me.cmbDesignation.Location = New System.Drawing.Point(449, 18)
        Me.cmbDesignation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Size = New System.Drawing.Size(162, 21)
        Me.cmbDesignation.TabIndex = 146
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 13)
        Me.Label11.TabIndex = 155
        Me.Label11.Text = "Process Category"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(771, 531)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 26)
        Me.Button1.TabIndex = 177
        Me.Button1.Tag = "1"
        Me.Button1.Text = "&View"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(865, 531)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 26)
        Me.Button2.TabIndex = 180
        Me.Button2.Tag = "1"
        Me.Button2.Text = "&Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PG
        '
        Me.PG.Location = New System.Drawing.Point(0, 380)
        Me.PG.Name = "PG"
        Me.PG.Size = New System.Drawing.Size(964, 6)
        Me.PG.TabIndex = 178
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.SilverLighkllllk
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.rdPermanant)
        Me.Panel3.Controls.Add(Me.rdTemporary)
        Me.Panel3.Controls.Add(Me.cmbSalarySheet)
        Me.Panel3.Controls.Add(Me.dtpPayDate)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.cmbYear)
        Me.Panel3.Controls.Add(Me.cmdRefresh)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.cmbMonth)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(961, 34)
        Me.Panel3.TabIndex = 184
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(1155, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.Text = "Pay Date"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rdPermanant
        '
        Me.rdPermanant.AutoSize = True
        Me.rdPermanant.Location = New System.Drawing.Point(875, 9)
        Me.rdPermanant.Name = "rdPermanant"
        Me.rdPermanant.Size = New System.Drawing.Size(91, 17)
        Me.rdPermanant.TabIndex = 9
        Me.rdPermanant.Text = "Permanant "
        Me.rdPermanant.UseVisualStyleBackColor = True
        '
        'rdTemporary
        '
        Me.rdTemporary.AutoSize = True
        Me.rdTemporary.Checked = True
        Me.rdTemporary.Location = New System.Drawing.Point(783, 9)
        Me.rdTemporary.Name = "rdTemporary"
        Me.rdTemporary.Size = New System.Drawing.Size(91, 17)
        Me.rdTemporary.TabIndex = 8
        Me.rdTemporary.TabStop = True
        Me.rdTemporary.Text = "Temporary "
        Me.rdTemporary.UseVisualStyleBackColor = True
        '
        'cmbSalarySheet
        '
        Me.cmbSalarySheet.FormattingEnabled = True
        Me.cmbSalarySheet.Location = New System.Drawing.Point(414, 7)
        Me.cmbSalarySheet.Name = "cmbSalarySheet"
        Me.cmbSalarySheet.Size = New System.Drawing.Size(179, 21)
        Me.cmbSalarySheet.TabIndex = 20
        '
        'dtpPayDate
        '
        Me.dtpPayDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPayDate.Location = New System.Drawing.Point(671, 7)
        Me.dtpPayDate.Name = "dtpPayDate"
        Me.dtpPayDate.Size = New System.Drawing.Size(101, 21)
        Me.dtpPayDate.TabIndex = 162
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label13.Location = New System.Drawing.Point(0, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(961, 2)
        Me.Label13.TabIndex = 168
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(13, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Year"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(53, 7)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(81, 21)
        Me.cmbYear.TabIndex = 16
        '
        'cmdRefresh
        '
        Me.cmdRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(140, 5)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(24, 24)
        Me.cmdRefresh.TabIndex = 81
        Me.cmdRefresh.TabStop = False
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.DimGray
        Me.Label15.Location = New System.Drawing.Point(604, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(65, 13)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Pay Date"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(184, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Month"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(318, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Sheet Format"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(233, 7)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(65, 21)
        Me.cmbMonth.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.dgvDept)
        Me.Panel1.Controls.Add(Me.dgv)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(961, 66)
        Me.Panel1.TabIndex = 179
        '
        'dgvDept
        '
        Me.dgvDept.AllowUserToAddRows = False
        Me.dgvDept.AllowUserToDeleteRows = False
        Me.dgvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDept.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dgvDept.Location = New System.Drawing.Point(441, 11)
        Me.dgvDept.Name = "dgvDept"
        Me.dgvDept.ReadOnly = True
        Me.dgvDept.RowHeadersWidth = 15
        Me.dgvDept.RowTemplate.Height = 23
        Me.dgvDept.Size = New System.Drawing.Size(36, 45)
        Me.dgvDept.TabIndex = 46
        Me.dgvDept.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Page"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "C1"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "C2"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "C3"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "C4"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "C5"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(483, 11)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.Size = New System.Drawing.Size(36, 45)
        Me.dgv.TabIndex = 45
        Me.dgv.Visible = False
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(961, 2)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(577, 537)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(41, 13)
        Me.lblCount.TabIndex = 189
        Me.lblCount.Text = "Count"
        '
        'frmDepartmentExpences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(961, 560)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.dgvSearchK)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.chkTick)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PG)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmDepartmentExpences"
        Me.Text = "DepartmentExpences"
        CType(Me.dgvSearchK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvDept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSearchK As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bSalary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents branch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkTick As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSubCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPayCenter As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbbranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbProcessCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbCostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PG As System.Windows.Forms.ProgressBar
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdPermanant As System.Windows.Forms.RadioButton
    Friend WithEvents rdTemporary As System.Windows.Forms.RadioButton
    Friend WithEvents cmbSalarySheet As System.Windows.Forms.ComboBox
    Friend WithEvents dtpPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDept As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents cmbReligion As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
