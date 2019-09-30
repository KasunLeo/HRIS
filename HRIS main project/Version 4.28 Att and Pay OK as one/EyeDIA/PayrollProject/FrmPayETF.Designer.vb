<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPayETF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPayETF))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdbGroup = New System.Windows.Forms.RadioButton()
        Me.rdbBranch = New System.Windows.Forms.RadioButton()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvMonth = New System.Windows.Forms.DataGridView()
        Me.Sel = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBL = New System.Windows.Forms.Label()
        Me.rdbNone = New System.Windows.Forms.RadioButton()
        Me.rdbAll = New System.Windows.Forms.RadioButton()
        Me.cmbbranch = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbEmployee = New System.Windows.Forms.ComboBox()
        Me.cmbEmployer = New System.Windows.Forms.ComboBox()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRegNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.PB = New System.Windows.Forms.ProgressBar()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbNumber = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbQuater = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdbEPF = New System.Windows.Forms.RadioButton()
        Me.rdbETF = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.rdbGroup)
        Me.Panel1.Controls.Add(Me.rdbBranch)
        Me.Panel1.Controls.Add(Me.lblMonth)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LBL)
        Me.Panel1.Controls.Add(Me.rdbNone)
        Me.Panel1.Controls.Add(Me.rdbAll)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(988, 48)
        Me.Panel1.TabIndex = 94
        '
        'rdbGroup
        '
        Me.rdbGroup.AutoSize = True
        Me.rdbGroup.BackColor = System.Drawing.Color.Transparent
        Me.rdbGroup.ForeColor = System.Drawing.Color.White
        Me.rdbGroup.Location = New System.Drawing.Point(891, 3)
        Me.rdbGroup.Name = "rdbGroup"
        Me.rdbGroup.Size = New System.Drawing.Size(89, 17)
        Me.rdbGroup.TabIndex = 180
        Me.rdbGroup.TabStop = True
        Me.rdbGroup.Text = "Group wise"
        Me.rdbGroup.UseVisualStyleBackColor = False
        '
        'rdbBranch
        '
        Me.rdbBranch.AutoSize = True
        Me.rdbBranch.BackColor = System.Drawing.Color.Transparent
        Me.rdbBranch.ForeColor = System.Drawing.Color.White
        Me.rdbBranch.Location = New System.Drawing.Point(750, 3)
        Me.rdbBranch.Name = "rdbBranch"
        Me.rdbBranch.Size = New System.Drawing.Size(109, 17)
        Me.rdbBranch.TabIndex = 179
        Me.rdbBranch.TabStop = True
        Me.rdbBranch.Text = "Company wise"
        Me.rdbBranch.UseVisualStyleBackColor = False
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.BackColor = System.Drawing.Color.Transparent
        Me.lblMonth.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonth.ForeColor = System.Drawing.Color.White
        Me.lblMonth.Location = New System.Drawing.Point(593, 24)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(0, 18)
        Me.lblMonth.TabIndex = 178
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvMonth)
        Me.GroupBox1.Controls.Add(Me.Button12)
        Me.GroupBox1.Controls.Add(Me.Button11)
        Me.GroupBox1.Location = New System.Drawing.Point(446, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(55, 21)
        Me.GroupBox1.TabIndex = 177
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'dgvMonth
        '
        Me.dgvMonth.AllowUserToAddRows = False
        Me.dgvMonth.BackgroundColor = System.Drawing.Color.White
        Me.dgvMonth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMonth.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sel, Me.Column1, Me.Column2})
        Me.dgvMonth.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMonth.Location = New System.Drawing.Point(6, 20)
        Me.dgvMonth.Name = "dgvMonth"
        Me.dgvMonth.RowHeadersWidth = 12
        Me.dgvMonth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMonth.Size = New System.Drawing.Size(231, 146)
        Me.dgvMonth.TabIndex = 96
        Me.dgvMonth.Tag = "1"
        '
        'Sel
        '
        Me.Sel.HeaderText = ""
        Me.Sel.Name = "Sel"
        Me.Sel.Width = 35
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Year"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Month"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Button12
        '
        Me.Button12.BackgroundImage = CType(resources.GetObject("Button12.BackgroundImage"), System.Drawing.Image)
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Location = New System.Drawing.Point(243, 42)
        Me.Button12.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(24, 24)
        Me.Button12.TabIndex = 97
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.BackgroundImage = CType(resources.GetObject("Button11.BackgroundImage"), System.Drawing.Image)
        Me.Button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button11.FlatAppearance.BorderSize = 0
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Location = New System.Drawing.Point(243, 67)
        Me.Button11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(24, 24)
        Me.Button11.TabIndex = 98
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Location = New System.Drawing.Point(0, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(988, 2)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Label8"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(46, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 16)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "ETF Six Month Returns"
        '
        'LBL
        '
        Me.LBL.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.LBL.Location = New System.Drawing.Point(537, 6)
        Me.LBL.Name = "LBL"
        Me.LBL.Size = New System.Drawing.Size(176, 18)
        Me.LBL.TabIndex = 135
        Me.LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBL.Visible = False
        '
        'rdbNone
        '
        Me.rdbNone.AutoSize = True
        Me.rdbNone.Location = New System.Drawing.Point(305, 24)
        Me.rdbNone.Name = "rdbNone"
        Me.rdbNone.Size = New System.Drawing.Size(93, 17)
        Me.rdbNone.TabIndex = 125
        Me.rdbNone.TabStop = True
        Me.rdbNone.Text = "Select None"
        Me.rdbNone.UseVisualStyleBackColor = True
        Me.rdbNone.Visible = False
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.Location = New System.Drawing.Point(221, 24)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(78, 17)
        Me.rdbAll.TabIndex = 124
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "Select All"
        Me.rdbAll.UseVisualStyleBackColor = True
        Me.rdbAll.Visible = False
        '
        'cmbbranch
        '
        Me.cmbbranch.FormattingEnabled = True
        Me.cmbbranch.Location = New System.Drawing.Point(777, 24)
        Me.cmbbranch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbbranch.Name = "cmbbranch"
        Me.cmbbranch.Size = New System.Drawing.Size(203, 21)
        Me.cmbbranch.TabIndex = 179
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(165, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "Salary for EPF"
        '
        'cmbEmployee
        '
        Me.cmbEmployee.FormattingEnabled = True
        Me.cmbEmployee.Location = New System.Drawing.Point(168, 24)
        Me.cmbEmployee.Name = "cmbEmployee"
        Me.cmbEmployee.Size = New System.Drawing.Size(191, 21)
        Me.cmbEmployee.TabIndex = 116
        '
        'cmbEmployer
        '
        Me.cmbEmployer.FormattingEnabled = True
        Me.cmbEmployer.Location = New System.Drawing.Point(7, 24)
        Me.cmbEmployer.Name = "cmbEmployer"
        Me.cmbEmployer.Size = New System.Drawing.Size(156, 21)
        Me.cmbEmployer.TabIndex = 115
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.EmpName, Me.MemNo, Me.NIC, Me.DataGridViewTextBoxColumn2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14})
        Me.dgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgv.Location = New System.Drawing.Point(0, 125)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 12
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(988, 395)
        Me.dgv.TabIndex = 119
        Me.dgv.Tag = "1"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "RegID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 68
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpName.HeaderText = "Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.Width = 65
        '
        'MemNo
        '
        Me.MemNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.MemNo.HeaderText = "MemNo"
        Me.MemNo.Name = "MemNo"
        Me.MemNo.Width = 74
        '
        'NIC
        '
        Me.NIC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NIC.HeaderText = "NICNo"
        Me.NIC.Name = "NIC"
        Me.NIC.Width = 69
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn2.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 59
        '
        'Column3
        '
        Me.Column3.HeaderText = "TotalEarnings"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Contribution"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "TotalEarnings"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Contribution"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "TotalEarnings"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "Contribution"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = "TotalEarnings"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "Contribution"
        Me.Column10.Name = "Column10"
        '
        'Column11
        '
        Me.Column11.HeaderText = "TotalEarnings"
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.HeaderText = "Contribution"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.HeaderText = "TotalEarnings"
        Me.Column13.Name = "Column13"
        '
        'Column14
        '
        Me.Column14.HeaderText = "Contribution"
        Me.Column14.Name = "Column14"
        '
        'btnProcess
        '
        Me.btnProcess.BackgroundImage = CType(resources.GetObject("btnProcess.BackgroundImage"), System.Drawing.Image)
        Me.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnProcess.FlatAppearance.BorderSize = 0
        Me.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.ForeColor = System.Drawing.Color.White
        Me.btnProcess.Location = New System.Drawing.Point(798, 536)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(88, 26)
        Me.btnProcess.TabIndex = 120
        Me.btnProcess.Tag = "1"
        Me.btnProcess.Text = "P&rocess"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(892, 536)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 26)
        Me.btnPrint.TabIndex = 121
        Me.btnPrint.Tag = "1"
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(361, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "EPF Reg No"
        '
        'txtRegNo
        '
        Me.txtRegNo.Location = New System.Drawing.Point(364, 24)
        Me.txtRegNo.Name = "txtRegNo"
        Me.txtRegNo.Size = New System.Drawing.Size(77, 21)
        Me.txtRegNo.TabIndex = 123
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(4, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 117
        Me.Label10.Text = "ETF Field"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(11, 522)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(969, 2)
        Me.Label11.TabIndex = 174
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Location = New System.Drawing.Point(12, 545)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 175
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(1, 524)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(986, 5)
        Me.PB.TabIndex = 176
        Me.PB.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbYear)
        Me.Panel2.Controls.Add(Me.cmbbranch)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbNumber)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbQuater)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.cmbEmployer)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cmbEmployee)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtRegNo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(988, 61)
        Me.Panel2.TabIndex = 177
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(778, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Branch"
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(446, 24)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(71, 21)
        Me.cmbYear.TabIndex = 131
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(658, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 13)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Member Number"
        '
        'cmbNumber
        '
        Me.cmbNumber.FormattingEnabled = True
        Me.cmbNumber.Items.AddRange(New Object() {"Register ID=01", "EPF Number=02", "ETF Number=03", "EMP Number=04"})
        Me.cmbNumber.Location = New System.Drawing.Point(661, 24)
        Me.cmbNumber.Name = "cmbNumber"
        Me.cmbNumber.Size = New System.Drawing.Size(111, 21)
        Me.cmbNumber.TabIndex = 129
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(520, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Quater"
        '
        'cmbQuater
        '
        Me.cmbQuater.FormattingEnabled = True
        Me.cmbQuater.Items.AddRange(New Object() {"Select=0", "First Quater = 1", "Second Quater = 2"})
        Me.cmbQuater.Location = New System.Drawing.Point(523, 24)
        Me.cmbQuater.Name = "cmbQuater"
        Me.cmbQuater.Size = New System.Drawing.Size(133, 21)
        Me.cmbQuater.TabIndex = 126
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(443, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Year"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(988, 2)
        Me.Label5.TabIndex = 76
        '
        'rdbEPF
        '
        Me.rdbEPF.AutoSize = True
        Me.rdbEPF.BackColor = System.Drawing.Color.Transparent
        Me.rdbEPF.ForeColor = System.Drawing.Color.DimGray
        Me.rdbEPF.Location = New System.Drawing.Point(581, 543)
        Me.rdbEPF.Name = "rdbEPF"
        Me.rdbEPF.Size = New System.Drawing.Size(87, 17)
        Me.rdbEPF.TabIndex = 181
        Me.rdbEPF.TabStop = True
        Me.rdbEPF.Text = "EPF Report"
        Me.rdbEPF.UseVisualStyleBackColor = False
        '
        'rdbETF
        '
        Me.rdbETF.AutoSize = True
        Me.rdbETF.BackColor = System.Drawing.Color.Transparent
        Me.rdbETF.ForeColor = System.Drawing.Color.DimGray
        Me.rdbETF.Location = New System.Drawing.Point(685, 543)
        Me.rdbETF.Name = "rdbETF"
        Me.rdbETF.Size = New System.Drawing.Size(87, 17)
        Me.rdbETF.TabIndex = 182
        Me.rdbETF.TabStop = True
        Me.rdbETF.Text = "ETF Report"
        Me.rdbETF.UseVisualStyleBackColor = False
        '
        'FrmPayETF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(988, 569)
        Me.Controls.Add(Me.rdbETF)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.rdbEPF)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmPayETF"
        Me.Text = "ETF Six Month Returns"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LBL As System.Windows.Forms.Label
    Friend WithEvents dgvMonth As System.Windows.Forms.DataGridView
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Sel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbEmployee As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmployer As System.Windows.Forms.ComboBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRegNo As System.Windows.Forms.TextBox
    Friend WithEvents rdbNone As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents PB As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbQuater As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbNumber As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rdbGroup As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBranch As System.Windows.Forms.RadioButton
    Friend WithEvents rdbEPF As System.Windows.Forms.RadioButton
    Friend WithEvents rdbETF As System.Windows.Forms.RadioButton
End Class
