<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpReDeductions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpReDeductions))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pbBank = New System.Windows.Forms.PictureBox()
        Me.pbBranch = New System.Windows.Forms.PictureBox()
        Me.pbAccount = New System.Windows.Forms.PictureBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtRegID = New System.Windows.Forms.TextBox()
        Me.cmbSalaryitem = New System.Windows.Forms.ComboBox()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmbBank = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.cmbReason = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmpNo = New System.Windows.Forms.TextBox()
        Me.cmbBranch = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBAccount = New System.Windows.Forms.TextBox()
        Me.dgvReq = New System.Windows.Forms.DataGridView()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEpfNo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPSD = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbApprovedBy = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSalDeduID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSalID = New System.Windows.Forms.TextBox()
        Me.txtBank = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.pbBank, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvReq, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pbBank)
        Me.Panel2.Controls.Add(Me.pbBranch)
        Me.Panel2.Controls.Add(Me.pbAccount)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dgv)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.cmbBank)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtDetails)
        Me.Panel2.Controls.Add(Me.cmbReason)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txtEmpNo)
        Me.Panel2.Controls.Add(Me.cmbBranch)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtBAccount)
        Me.Panel2.Controls.Add(Me.dgvReq)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtEpfNo)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtPSD)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.cmbApprovedBy)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(844, 499)
        Me.Panel2.TabIndex = 1
        '
        'pbBank
        '
        Me.pbBank.BackgroundImage = CType(resources.GetObject("pbBank.BackgroundImage"), System.Drawing.Image)
        Me.pbBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbBank.InitialImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.pbBank.Location = New System.Drawing.Point(182, 175)
        Me.pbBank.Name = "pbBank"
        Me.pbBank.Size = New System.Drawing.Size(21, 22)
        Me.pbBank.TabIndex = 180
        Me.pbBank.TabStop = False
        Me.pbBank.Tag = "2"
        '
        'pbBranch
        '
        Me.pbBranch.BackgroundImage = Global.HRISforBB.My.Resources.Resources._2
        Me.pbBranch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbBranch.InitialImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.pbBranch.Location = New System.Drawing.Point(182, 216)
        Me.pbBranch.Name = "pbBranch"
        Me.pbBranch.Size = New System.Drawing.Size(21, 22)
        Me.pbBranch.TabIndex = 179
        Me.pbBranch.TabStop = False
        Me.pbBranch.Tag = "2"
        '
        'pbAccount
        '
        Me.pbAccount.BackgroundImage = CType(resources.GetObject("pbAccount.BackgroundImage"), System.Drawing.Image)
        Me.pbAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbAccount.InitialImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.pbAccount.Location = New System.Drawing.Point(182, 259)
        Me.pbAccount.Name = "pbAccount"
        Me.pbAccount.Size = New System.Drawing.Size(21, 22)
        Me.pbAccount.TabIndex = 178
        Me.pbAccount.TabStop = False
        Me.pbAccount.Tag = "2"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(402, 50)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(138, 13)
        Me.Label22.TabIndex = 177
        Me.Label22.Text = "Installment Shedule"
        '
        'Label23
        '
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Location = New System.Drawing.Point(521, 59)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(318, 2)
        Me.Label23.TabIndex = 176
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 13)
        Me.Label10.TabIndex = 175
        Me.Label10.Text = "Bank Information"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(124, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(269, 2)
        Me.Label5.TabIndex = 174
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dgv.Location = New System.Drawing.Point(405, 69)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersWidth = 12
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(423, 211)
        Me.dgv.TabIndex = 99
        '
        'Column1
        '
        Me.Column1.HeaderText = "Installment"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 77
        '
        'Column2
        '
        Me.Column2.HeaderText = "Year"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 88
        '
        'Column3
        '
        Me.Column3.HeaderText = "Month"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 77
        '
        'Column4
        '
        Me.Column4.HeaderText = "Amount"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 88
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = "FullSalary"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(142, 53)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Details"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.SilverLighkllllk
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.Label20)
        Me.Panel4.Controls.Add(Me.txtRegID)
        Me.Panel4.Controls.Add(Me.cmbSalaryitem)
        Me.Panel4.Controls.Add(Me.dtpTo)
        Me.Panel4.Controls.Add(Me.dtpFrom)
        Me.Panel4.Controls.Add(Me.txtAmount)
        Me.Panel4.Controls.Add(Me.CheckBox1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(844, 49)
        Me.Panel4.TabIndex = 173
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(634, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 176
        Me.Label3.Text = "Amount"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(521, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 174
        Me.Label1.Text = "To Date"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button4
        '
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(105, 19)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(24, 24)
        Me.Button4.TabIndex = 97
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(402, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "From Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label18.Location = New System.Drawing.Point(0, 47)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(844, 2)
        Me.Label18.TabIndex = 168
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(11, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Reg ID"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DimGray
        Me.Label20.Location = New System.Drawing.Point(142, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Salary Item"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRegID
        '
        Me.txtRegID.Location = New System.Drawing.Point(12, 22)
        Me.txtRegID.Name = "txtRegID"
        Me.txtRegID.Size = New System.Drawing.Size(87, 21)
        Me.txtRegID.TabIndex = 0
        '
        'cmbSalaryitem
        '
        Me.cmbSalaryitem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalaryitem.FormattingEnabled = True
        Me.cmbSalaryitem.Location = New System.Drawing.Point(145, 22)
        Me.cmbSalaryitem.Name = "cmbSalaryitem"
        Me.cmbSalaryitem.Size = New System.Drawing.Size(248, 21)
        Me.cmbSalaryitem.TabIndex = 14
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(521, 22)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 21)
        Me.dtpTo.TabIndex = 6
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(405, 22)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 21)
        Me.dtpFrom.TabIndex = 5
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(637, 22)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAmount.Size = New System.Drawing.Size(86, 21)
        Me.txtAmount.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(752, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(86, 17)
        Me.CheckBox1.TabIndex = 20
        Me.CheckBox1.Text = "Full Salary"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmbBank
        '
        Me.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBank.FormattingEnabled = True
        Me.cmbBank.Location = New System.Drawing.Point(14, 176)
        Me.cmbBank.Name = "cmbBank"
        Me.cmbBank.Size = New System.Drawing.Size(162, 21)
        Me.cmbBank.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(206, 244)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Reason"
        '
        'txtDetails
        '
        Me.txtDetails.Location = New System.Drawing.Point(145, 70)
        Me.txtDetails.MaxLength = 10
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(248, 66)
        Me.txtDetails.TabIndex = 26
        '
        'cmbReason
        '
        Me.cmbReason.FormattingEnabled = True
        Me.cmbReason.Location = New System.Drawing.Point(209, 259)
        Me.cmbReason.Name = "cmbReason"
        Me.cmbReason.Size = New System.Drawing.Size(184, 21)
        Me.cmbReason.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.PowderBlue
        Me.Label17.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(0, 293)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(844, 18)
        Me.Label17.TabIndex = 18
        Me.Label17.Text = "Existing Details"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Branch"
        '
        'txtEmpNo
        '
        Me.txtEmpNo.Location = New System.Drawing.Point(14, 69)
        Me.txtEmpNo.Name = "txtEmpNo"
        Me.txtEmpNo.Size = New System.Drawing.Size(85, 21)
        Me.txtEmpNo.TabIndex = 24
        '
        'cmbBranch
        '
        Me.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(14, 217)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(162, 21)
        Me.cmbBranch.TabIndex = 15
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Emp No"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 244)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Acco. No"
        '
        'txtBAccount
        '
        Me.txtBAccount.Location = New System.Drawing.Point(14, 260)
        Me.txtBAccount.MaxLength = 12
        Me.txtBAccount.Name = "txtBAccount"
        Me.txtBAccount.Size = New System.Drawing.Size(162, 21)
        Me.txtBAccount.TabIndex = 7
        '
        'dgvReq
        '
        Me.dgvReq.AllowUserToAddRows = False
        Me.dgvReq.AllowUserToDeleteRows = False
        Me.dgvReq.BackgroundColor = System.Drawing.Color.White
        Me.dgvReq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReq.GridColor = System.Drawing.Color.White
        Me.dgvReq.Location = New System.Drawing.Point(0, 314)
        Me.dgvReq.Name = "dgvReq"
        Me.dgvReq.ReadOnly = True
        Me.dgvReq.RowHeadersWidth = 12
        Me.dgvReq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReq.Size = New System.Drawing.Size(844, 182)
        Me.dgvReq.TabIndex = 1
        Me.dgvReq.Tag = "1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Bank"
        '
        'txtEpfNo
        '
        Me.txtEpfNo.Location = New System.Drawing.Point(14, 114)
        Me.txtEpfNo.Name = "txtEpfNo"
        Me.txtEpfNo.Size = New System.Drawing.Size(87, 21)
        Me.txtEpfNo.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 98)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Epf No"
        '
        'txtPSD
        '
        Me.txtPSD.Location = New System.Drawing.Point(209, 176)
        Me.txtPSD.MaxLength = 10
        Me.txtPSD.Name = "txtPSD"
        Me.txtPSD.Size = New System.Drawing.Size(184, 21)
        Me.txtPSD.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(207, 202)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Approved By"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(207, 160)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Payslip Desc"
        '
        'cmbApprovedBy
        '
        Me.cmbApprovedBy.FormattingEnabled = True
        Me.cmbApprovedBy.Location = New System.Drawing.Point(209, 218)
        Me.cmbApprovedBy.Name = "cmbApprovedBy"
        Me.cmbApprovedBy.Size = New System.Drawing.Size(184, 21)
        Me.cmbApprovedBy.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(844, 66)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.lblTotal)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtSalDeduID)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtSalID)
        Me.Panel3.Controls.Add(Me.txtBank)
        Me.Panel3.Controls.Add(Me.txtBranch)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(844, 66)
        Me.Panel3.TabIndex = 23
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.White
        Me.lblTotal.Location = New System.Drawing.Point(634, 27)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(57, 13)
        Me.lblTotal.TabIndex = 177
        Me.lblTotal.Text = "Amount"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 64)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(844, 2)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(12, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(243, 16)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Employee Request Deductions..."
        '
        'txtSalDeduID
        '
        Me.txtSalDeduID.BackColor = System.Drawing.Color.White
        Me.txtSalDeduID.Location = New System.Drawing.Point(467, 20)
        Me.txtSalDeduID.Name = "txtSalDeduID"
        Me.txtSalDeduID.ReadOnly = True
        Me.txtSalDeduID.Size = New System.Drawing.Size(86, 21)
        Me.txtSalDeduID.TabIndex = 0
        Me.txtSalDeduID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(383, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ID"
        Me.Label2.Visible = False
        '
        'txtSalID
        '
        Me.txtSalID.Location = New System.Drawing.Point(844, 15)
        Me.txtSalID.Name = "txtSalID"
        Me.txtSalID.ReadOnly = True
        Me.txtSalID.Size = New System.Drawing.Size(46, 21)
        Me.txtSalID.TabIndex = 2
        Me.txtSalID.Visible = False
        '
        'txtBank
        '
        Me.txtBank.Location = New System.Drawing.Point(593, 3)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.ReadOnly = True
        Me.txtBank.Size = New System.Drawing.Size(53, 21)
        Me.txtBank.TabIndex = 16
        Me.txtBank.Visible = False
        '
        'txtBranch
        '
        Me.txtBranch.Location = New System.Drawing.Point(559, 39)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.ReadOnly = True
        Me.txtBranch.Size = New System.Drawing.Size(53, 21)
        Me.txtBranch.TabIndex = 17
        Me.txtBranch.Visible = False
        '
        'Label21
        '
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Location = New System.Drawing.Point(0, 565)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(844, 2)
        Me.Label21.TabIndex = 178
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(12, 579)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 179
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(558, 572)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 26)
        Me.Button2.TabIndex = 98
        Me.Button2.Tag = "1"
        Me.Button2.Text = "&Print"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.BackgroundImage = CType(resources.GetObject("cmdCancel.BackgroundImage"), System.Drawing.Image)
        Me.cmdCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCancel.FlatAppearance.BorderSize = 0
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(746, 572)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 26)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Tag = "1"
        Me.cmdCancel.Text = "&Close"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.Color.White
        Me.cmdRefresh.Location = New System.Drawing.Point(652, 572)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(88, 26)
        Me.cmdRefresh.TabIndex = 1
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.Text = "&Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImage = CType(resources.GetObject("cmdSave.BackgroundImage"), System.Drawing.Image)
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(464, 572)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(88, 26)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Tag = "1"
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'frmEmpReDeductions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(844, 603)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdSave)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmEmpReDeductions"
        Me.Text = "Employee Request Deductions.."
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbBank, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBranch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.dgvReq, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBAccount As System.Windows.Forms.TextBox
    Friend WithEvents txtRegID As System.Windows.Forms.TextBox
    Friend WithEvents txtSalDeduID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbApprovedBy As System.Windows.Forms.ComboBox
    Friend WithEvents cmbReason As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtSalID As System.Windows.Forms.TextBox
    Friend WithEvents dgvReq As System.Windows.Forms.DataGridView
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBank As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBranch As System.Windows.Forms.TextBox
    Friend WithEvents txtBank As System.Windows.Forms.TextBox
    Friend WithEvents txtPSD As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSalaryitem As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtDetails As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpNo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtEpfNo As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents pbAccount As System.Windows.Forms.PictureBox
    Friend WithEvents pbBank As System.Windows.Forms.PictureBox
    Friend WithEvents pbBranch As System.Windows.Forms.PictureBox
End Class
