<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssignFormula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignFormula))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFormula = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.dgvAmount = New System.Windows.Forms.DataGridView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSubCategory = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbCostCenter = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCompany = New System.Windows.Forms.ComboBox()
        Me.cmbPayCenter = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbbranch = New System.Windows.Forms.ComboBox()
        Me.cmbPrCatagory = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDesignation = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbDept = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.rdbInverse = New System.Windows.Forms.RadioButton()
        Me.rdbNone = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdAllk = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.chkMonth = New System.Windows.Forms.CheckBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.salid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(12, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Selected Formula"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormula
        '
        Me.cmbFormula.BackColor = System.Drawing.Color.White
        Me.cmbFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormula.FormattingEnabled = True
        Me.cmbFormula.Location = New System.Drawing.Point(139, 7)
        Me.cmbFormula.Name = "cmbFormula"
        Me.cmbFormula.Size = New System.Drawing.Size(239, 21)
        Me.cmbFormula.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(880, 553)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 26)
        Me.Button1.TabIndex = 33
        Me.Button1.Tag = "1"
        Me.Button1.Text = "&Exit"
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
        Me.Button2.Location = New System.Drawing.Point(786, 553)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 26)
        Me.Button2.TabIndex = 90
        Me.Button2.Tag = "1"
        Me.Button2.Text = "&Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.dgvAmount)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 66)
        Me.Panel1.TabIndex = 94
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(625, 25)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(73, 24)
        Me.Button7.TabIndex = 98
        Me.Button7.Text = "&All"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'dgvAmount
        '
        Me.dgvAmount.AllowUserToAddRows = False
        Me.dgvAmount.AllowUserToDeleteRows = False
        Me.dgvAmount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAmount.Location = New System.Drawing.Point(393, 5)
        Me.dgvAmount.Name = "dgvAmount"
        Me.dgvAmount.ReadOnly = True
        Me.dgvAmount.Size = New System.Drawing.Size(34, 28)
        Me.dgvAmount.TabIndex = 88
        Me.dgvAmount.Visible = False
        '
        'Button5
        '
        Me.Button5.BackgroundImage = Global.HRISforBB.My.Resources.Resources.button2ind
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(495, 23)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(88, 26)
        Me.Button5.TabIndex = 63
        Me.Button5.Tag = "1"
        Me.Button5.Text = "S&how All "
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(783, 25)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 24)
        Me.Button3.TabIndex = 97
        Me.Button3.Text = "&None"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(704, 25)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(73, 24)
        Me.Button4.TabIndex = 99
        Me.Button4.Text = "&Inverse"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Location = New System.Drawing.Point(0, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(980, 2)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Month"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(312, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Assign Formulas to Selected Employee(s)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSubCategory)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Controls.Add(Me.cmbCostCenter)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cmbCompany)
        Me.GroupBox2.Controls.Add(Me.cmbPayCenter)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.cmbbranch)
        Me.GroupBox2.Controls.Add(Me.cmbPrCatagory)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbDesignation)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cmbDept)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 109)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(956, 104)
        Me.GroupBox2.TabIndex = 95
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Employees"
        '
        'cmbSubCategory
        '
        Me.cmbSubCategory.FormattingEnabled = True
        Me.cmbSubCategory.Location = New System.Drawing.Point(407, 72)
        Me.cmbSubCategory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSubCategory.Name = "cmbSubCategory"
        Me.cmbSubCategory.Size = New System.Drawing.Size(206, 21)
        Me.cmbSubCategory.TabIndex = 174
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(319, 79)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 13)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Sub Category"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label2.Location = New System.Drawing.Point(14, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Any word"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(102, 20)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(191, 21)
        Me.txtSearch.TabIndex = 172
        '
        'cmbCostCenter
        '
        Me.cmbCostCenter.FormattingEnabled = True
        Me.cmbCostCenter.Location = New System.Drawing.Point(748, 72)
        Me.cmbCostCenter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCostCenter.Name = "cmbCostCenter"
        Me.cmbCostCenter.Size = New System.Drawing.Size(201, 21)
        Me.cmbCostCenter.TabIndex = 170
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(638, 77)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 13)
        Me.Label19.TabIndex = 171
        Me.Label19.Text = "Cost Center"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(319, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Branch"
        '
        'cmbCompany
        '
        Me.cmbCompany.FormattingEnabled = True
        Me.cmbCompany.Location = New System.Drawing.Point(407, 46)
        Me.cmbCompany.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCompany.Name = "cmbCompany"
        Me.cmbCompany.Size = New System.Drawing.Size(206, 21)
        Me.cmbCompany.TabIndex = 159
        '
        'cmbPayCenter
        '
        Me.cmbPayCenter.FormattingEnabled = True
        Me.cmbPayCenter.Location = New System.Drawing.Point(748, 20)
        Me.cmbPayCenter.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPayCenter.Name = "cmbPayCenter"
        Me.cmbPayCenter.Size = New System.Drawing.Size(201, 21)
        Me.cmbPayCenter.TabIndex = 161
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(638, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(71, 13)
        Me.Label20.TabIndex = 166
        Me.Label20.Text = "Pay Center"
        '
        'cmbbranch
        '
        Me.cmbbranch.FormattingEnabled = True
        Me.cmbbranch.Location = New System.Drawing.Point(407, 20)
        Me.cmbbranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbbranch.Name = "cmbbranch"
        Me.cmbbranch.Size = New System.Drawing.Size(206, 21)
        Me.cmbbranch.TabIndex = 160
        '
        'cmbPrCatagory
        '
        Me.cmbPrCatagory.BackColor = System.Drawing.Color.White
        Me.cmbPrCatagory.FormattingEnabled = True
        Me.cmbPrCatagory.Location = New System.Drawing.Point(748, 46)
        Me.cmbPrCatagory.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPrCatagory.Name = "cmbPrCatagory"
        Me.cmbPrCatagory.Size = New System.Drawing.Size(201, 21)
        Me.cmbPrCatagory.TabIndex = 158
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(319, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 164
        Me.Label17.Text = "Company"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(638, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 13)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "Process Category"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label5.Location = New System.Drawing.Point(14, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Designation"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDesignation
        '
        Me.cmbDesignation.FormattingEnabled = True
        Me.cmbDesignation.Location = New System.Drawing.Point(102, 72)
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Size = New System.Drawing.Size(191, 21)
        Me.cmbDesignation.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label9.Location = New System.Drawing.Point(14, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Department"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDept
        '
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(102, 46)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(191, 21)
        Me.cmbDept.TabIndex = 62
        '
        'Button6
        '
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(692, 553)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(88, 26)
        Me.Button6.TabIndex = 101
        Me.Button6.Tag = "1"
        Me.Button6.Text = "&Save All"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(0, 538)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(980, 4)
        Me.PB.TabIndex = 102
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Location = New System.Drawing.Point(12, 219)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(78, 17)
        Me.rdbAll.TabIndex = 103
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "Select All"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'rdbInverse
        '
        Me.rdbInverse.AutoSize = True
        Me.rdbInverse.Location = New System.Drawing.Point(98, 219)
        Me.rdbInverse.Name = "rdbInverse"
        Me.rdbInverse.Size = New System.Drawing.Size(108, 17)
        Me.rdbInverse.TabIndex = 103
        Me.rdbInverse.TabStop = True
        Me.rdbInverse.Text = "Select Inverse"
        Me.rdbInverse.UseVisualStyleBackColor = True
        '
        'rdbNone
        '
        Me.rdbNone.AutoSize = True
        Me.rdbNone.Location = New System.Drawing.Point(212, 219)
        Me.rdbNone.Name = "rdbNone"
        Me.rdbNone.Size = New System.Drawing.Size(93, 17)
        Me.rdbNone.TabIndex = 103
        Me.rdbNone.TabStop = True
        Me.rdbNone.Text = "Select None"
        Me.rdbNone.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.cmdAllk)
        Me.Panel3.Controls.Add(Me.cmdRefresh)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.cmbFormula)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 66)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(980, 34)
        Me.Panel3.TabIndex = 172
        '
        'cmdAllk
        '
        Me.cmdAllk.BackgroundImage = CType(resources.GetObject("cmdAllk.BackgroundImage"), System.Drawing.Image)
        Me.cmdAllk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdAllk.FlatAppearance.BorderSize = 0
        Me.cmdAllk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAllk.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAllk.ForeColor = System.Drawing.Color.White
        Me.cmdAllk.Location = New System.Drawing.Point(384, 6)
        Me.cmdAllk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdAllk.Name = "cmdAllk"
        Me.cmdAllk.Size = New System.Drawing.Size(48, 24)
        Me.cmdAllk.TabIndex = 171
        Me.cmdAllk.Tag = ""
        Me.cmdAllk.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Location = New System.Drawing.Point(448, 5)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(24, 24)
        Me.cmdRefresh.TabIndex = 100
        Me.cmdRefresh.TabStop = False
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label13.Location = New System.Drawing.Point(0, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(980, 2)
        Me.Label13.TabIndex = 168
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(6, 543)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(969, 2)
        Me.Label11.TabIndex = 173
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(12, 560)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 174
        '
        'chkMonth
        '
        Me.chkMonth.AutoSize = True
        Me.chkMonth.Location = New System.Drawing.Point(17, 255)
        Me.chkMonth.Name = "chkMonth"
        Me.chkMonth.Size = New System.Drawing.Size(15, 14)
        Me.chkMonth.TabIndex = 190
        Me.chkMonth.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.BackgroundColor = System.Drawing.Color.White
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.salid, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.DGV.Location = New System.Drawing.Point(0, 242)
        Me.DGV.Name = "DGV"
        Me.DGV.RowHeadersWidth = 12
        Me.DGV.Size = New System.Drawing.Size(980, 296)
        Me.DGV.TabIndex = 191
        Me.DGV.Tag = "1"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 24
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "REGID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "EMP No"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 55
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "NIC Number"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 95
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "Employee Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Salary Componant"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 147
        '
        'salid
        '
        Me.salid.HeaderText = "Sal ID"
        Me.salid.Name = "salid"
        Me.salid.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Designation"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 138
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Department"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 177
        '
        'frmAssignFormula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(980, 583)
        Me.Controls.Add(Me.chkMonth)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.rdbNone)
        Me.Controls.Add(Me.rdbInverse)
        Me.Controls.Add(Me.rdbAll)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmAssignFormula"
        Me.Text = "frmAssignFormula"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbFormula As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbDesignation As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
    Friend WithEvents dgvAmount As System.Windows.Forms.DataGridView
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdbInverse As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNone As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPayCenter As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbbranch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPrCatagory As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmbSubCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbCostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmdAllk As System.Windows.Forms.Button
    Friend WithEvents chkMonth As System.Windows.Forms.CheckBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
