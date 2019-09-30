<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOTAuthorize
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblCount = New System.Windows.Forms.Label
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.cmbDesg = New System.Windows.Forms.ComboBox
        Me.dgvDetails = New System.Windows.Forms.DataGridView
        Me.RegID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.wDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.wrDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.inTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WrkHors = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotOT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NrOT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dOT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TripleOT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtEmpName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtExNOT = New System.Windows.Forms.TextBox
        Me.txtExDOT = New System.Windows.Forms.TextBox
        Me.txtExtOT = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtApvNOT = New System.Windows.Forms.TextBox
        Me.txtApvDOT = New System.Windows.Forms.TextBox
        Me.txtApvTOT = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtDept = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cmbType)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.lblCount)
        Me.GroupBox1.Controls.Add(Me.dtpToDate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpFrDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbBranch)
        Me.GroupBox1.Controls.Add(Me.cmbDept)
        Me.GroupBox1.Controls.Add(Me.cmbCat)
        Me.GroupBox1.Controls.Add(Me.cmbDesg)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(910, 101)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(640, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Type"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(643, 73)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(202, 21)
        Me.cmbType.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(851, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 24)
        Me.Button1.TabIndex = 31
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(601, 12)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 30
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(20, 73)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(118, 21)
        Me.dtpToDate.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(406, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Branch"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "To Date "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(406, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Department "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(166, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Designation"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(643, 28)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(202, 21)
        Me.txtSearch.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(640, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Search Text"
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(20, 28)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(118, 21)
        Me.dtpFrDate.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(166, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Category"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "From Date "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(409, 73)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(202, 21)
        Me.cmbBranch.TabIndex = 17
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(409, 28)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(202, 21)
        Me.cmbDept.TabIndex = 16
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.White
        Me.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(169, 28)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(211, 21)
        Me.cmbCat.TabIndex = 19
        '
        'cmbDesg
        '
        Me.cmbDesg.BackColor = System.Drawing.Color.White
        Me.cmbDesg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDesg.FormattingEnabled = True
        Me.cmbDesg.Location = New System.Drawing.Point(169, 73)
        Me.cmbDesg.Name = "cmbDesg"
        Me.cmbDesg.Size = New System.Drawing.Size(211, 21)
        Me.cmbDesg.TabIndex = 18
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RegID, Me.EmpID, Me.wDate, Me.wrDate, Me.inTime, Me.OutTime, Me.WrkHors, Me.TotOT, Me.NrOT, Me.dOT, Me.TripleOT})
        Me.dgvDetails.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvDetails.Location = New System.Drawing.Point(9, 175)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowHeadersWidth = 26
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(910, 239)
        Me.dgvDetails.TabIndex = 3
        Me.dgvDetails.Tag = "1"
        '
        'RegID
        '
        Me.RegID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.RegID.HeaderText = "RegID"
        Me.RegID.Name = "RegID"
        Me.RegID.ReadOnly = True
        Me.RegID.Visible = False
        '
        'EmpID
        '
        Me.EmpID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpID.HeaderText = "Emp ID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Width = 75
        '
        'wDate
        '
        Me.wDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.wDate.HeaderText = "Name"
        Me.wDate.Name = "wDate"
        Me.wDate.ReadOnly = True
        '
        'wrDate
        '
        Me.wrDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.wrDate.HeaderText = "Date"
        Me.wrDate.Name = "wrDate"
        Me.wrDate.ReadOnly = True
        Me.wrDate.Width = 59
        '
        'inTime
        '
        Me.inTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.inTime.HeaderText = "In Time"
        Me.inTime.Name = "inTime"
        Me.inTime.ReadOnly = True
        Me.inTime.Width = 76
        '
        'OutTime
        '
        Me.OutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutTime.HeaderText = "Out Time"
        Me.OutTime.Name = "OutTime"
        Me.OutTime.ReadOnly = True
        Me.OutTime.Width = 84
        '
        'WrkHors
        '
        Me.WrkHors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.WrkHors.HeaderText = "Work Hours"
        Me.WrkHors.Name = "WrkHors"
        Me.WrkHors.ReadOnly = True
        Me.WrkHors.Width = 98
        '
        'TotOT
        '
        Me.TotOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TotOT.HeaderText = "Total OT"
        Me.TotOT.Name = "TotOT"
        Me.TotOT.ReadOnly = True
        Me.TotOT.Width = 79
        '
        'NrOT
        '
        Me.NrOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NrOT.HeaderText = "Normal OT"
        Me.NrOT.Name = "NrOT"
        Me.NrOT.ReadOnly = True
        Me.NrOT.Width = 93
        '
        'dOT
        '
        Me.dOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dOT.HeaderText = "Double OT"
        Me.dOT.Name = "dOT"
        Me.dOT.ReadOnly = True
        Me.dOT.Width = 92
        '
        'TripleOT
        '
        Me.TripleOT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.TripleOT.HeaderText = "Triple OT"
        Me.TripleOT.Name = "TripleOT"
        Me.TripleOT.ReadOnly = True
        Me.TripleOT.Width = 83
        '
        'txtEmpName
        '
        Me.txtEmpName.Location = New System.Drawing.Point(141, 448)
        Me.txtEmpName.Name = "txtEmpName"
        Me.txtEmpName.ReadOnly = True
        Me.txtEmpName.Size = New System.Drawing.Size(264, 21)
        Me.txtEmpName.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 451)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Employee Name |"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(590, 427)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Normal OT (B)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(696, 427)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Double OT (A)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(802, 427)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Triple OT"
        '
        'txtExNOT
        '
        Me.txtExNOT.Location = New System.Drawing.Point(590, 448)
        Me.txtExNOT.Name = "txtExNOT"
        Me.txtExNOT.ReadOnly = True
        Me.txtExNOT.Size = New System.Drawing.Size(100, 21)
        Me.txtExNOT.TabIndex = 20
        Me.txtExNOT.Text = "0"
        Me.txtExNOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExDOT
        '
        Me.txtExDOT.Location = New System.Drawing.Point(696, 448)
        Me.txtExDOT.Name = "txtExDOT"
        Me.txtExDOT.ReadOnly = True
        Me.txtExDOT.Size = New System.Drawing.Size(100, 21)
        Me.txtExDOT.TabIndex = 20
        Me.txtExDOT.Text = "0"
        Me.txtExDOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtOT
        '
        Me.txtExtOT.Location = New System.Drawing.Point(802, 448)
        Me.txtExtOT.Name = "txtExtOT"
        Me.txtExtOT.ReadOnly = True
        Me.txtExtOT.Size = New System.Drawing.Size(100, 21)
        Me.txtExtOT.TabIndex = 20
        Me.txtExtOT.Text = "0"
        Me.txtExtOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(446, 451)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Existing OT Values |"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(446, 478)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Approved OT Values |"
        '
        'txtApvNOT
        '
        Me.txtApvNOT.Location = New System.Drawing.Point(590, 475)
        Me.txtApvNOT.Name = "txtApvNOT"
        Me.txtApvNOT.Size = New System.Drawing.Size(100, 21)
        Me.txtApvNOT.TabIndex = 20
        Me.txtApvNOT.Text = "0"
        Me.txtApvNOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtApvDOT
        '
        Me.txtApvDOT.Location = New System.Drawing.Point(696, 475)
        Me.txtApvDOT.Name = "txtApvDOT"
        Me.txtApvDOT.Size = New System.Drawing.Size(100, 21)
        Me.txtApvDOT.TabIndex = 20
        Me.txtApvDOT.Text = "0"
        Me.txtApvDOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtApvTOT
        '
        Me.txtApvTOT.Location = New System.Drawing.Point(802, 475)
        Me.txtApvTOT.Name = "txtApvTOT"
        Me.txtApvTOT.Size = New System.Drawing.Size(100, 21)
        Me.txtApvTOT.TabIndex = 20
        Me.txtApvTOT.Text = "0"
        Me.txtApvTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(26, 478)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Department |"
        '
        'txtDept
        '
        Me.txtDept.Location = New System.Drawing.Point(141, 475)
        Me.txtDept.Name = "txtDept"
        Me.txtDept.ReadOnly = True
        Me.txtDept.Size = New System.Drawing.Size(264, 21)
        Me.txtDept.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 48)
        Me.Panel1.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.webmail
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(242, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 26)
        Me.Button2.TabIndex = 34
        Me.Button2.Tag = "1"
        Me.Button2.Text = "Report"
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(852, 11)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 47
        Me.Button3.Tag = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.Location = New System.Drawing.Point(886, 11)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 28)
        Me.Button4.TabIndex = 48
        Me.Button4.Tag = "3"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(7, 1)
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
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(62, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(146, 18)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "OT Authorization"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(590, 501)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(312, 21)
        Me.txtRemark.TabIndex = 32
        Me.txtRemark.Text = "-"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(446, 509)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "OT Remark"
        '
        'frmOTAuthorize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(928, 545)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtApvTOT)
        Me.Controls.Add(Me.txtApvDOT)
        Me.Controls.Add(Me.txtExtOT)
        Me.Controls.Add(Me.txtApvNOT)
        Me.Controls.Add(Me.txtExDOT)
        Me.Controls.Add(Me.txtExNOT)
        Me.Controls.Add(Me.txtDept)
        Me.Controls.Add(Me.txtEmpName)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmOTAuthorize"
        Me.Text = "frmOTAuthorize"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDesg As System.Windows.Forms.ComboBox
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents RegID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wrDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WrkHors As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NrOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TripleOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtEmpName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtExNOT As System.Windows.Forms.TextBox
    Friend WithEvents txtExDOT As System.Windows.Forms.TextBox
    Friend WithEvents txtExtOT As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtApvNOT As System.Windows.Forms.TextBox
    Friend WithEvents txtApvDOT As System.Windows.Forms.TextBox
    Friend WithEvents txtApvTOT As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDept As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
End Class
