<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRosterAssign
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
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbDesig = New System.Windows.Forms.ComboBox
        Me.dgvShdule = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdUpdate = New System.Windows.Forms.Button
        Me.txtSeldate = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSelShft = New System.Windows.Forms.TextBox
        Me.dgvLineShift = New System.Windows.Forms.DataGridView
        Me.shiftno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.adate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shiftid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbDayType = New System.Windows.Forms.ComboBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdEditOffDay = New System.Windows.Forms.Button
        Me.chkEditSelect = New System.Windows.Forms.CheckBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbWorkDay = New System.Windows.Forms.ComboBox
        Me.cmdEdit = New System.Windows.Forms.Button
        Me.dgvCrShifts = New System.Windows.Forms.DataGridView
        Me.selec = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.shID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkCrYears = New System.Windows.Forms.CheckBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbWrkCode = New System.Windows.Forms.ComboBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblRowCoun = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkCheck = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbTitle = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.dgvEmployee = New System.Windows.Forms.DataGridView
        Me.Pick = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EpfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.depart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlBotom = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.pnlData = New System.Windows.Forms.Panel
        Me.pnlD2 = New System.Windows.Forms.Panel
        Me.pnlAllD = New System.Windows.Forms.Panel
        CType(Me.dgvShdule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLineShift, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCrShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotom.SuspendLayout()
        Me.pnlData.SuspendLayout()
        Me.pnlD2.SuspendLayout()
        Me.pnlAllD.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(7, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Department "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDept
        '
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(85, 45)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(161, 21)
        Me.cmbDept.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Category "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCat
        '
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(85, 97)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(161, 21)
        Me.cmbCat.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Designation "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDesig
        '
        Me.cmbDesig.FormattingEnabled = True
        Me.cmbDesig.Location = New System.Drawing.Point(85, 71)
        Me.cmbDesig.Name = "cmbDesig"
        Me.cmbDesig.Size = New System.Drawing.Size(161, 21)
        Me.cmbDesig.TabIndex = 11
        '
        'dgvShdule
        '
        Me.dgvShdule.AllowUserToAddRows = False
        Me.dgvShdule.BackgroundColor = System.Drawing.Color.White
        Me.dgvShdule.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShdule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShdule.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvShdule.Location = New System.Drawing.Point(520, 37)
        Me.dgvShdule.Name = "dgvShdule"
        Me.dgvShdule.ReadOnly = True
        Me.dgvShdule.RowHeadersVisible = False
        Me.dgvShdule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvShdule.Size = New System.Drawing.Size(473, 244)
        Me.dgvShdule.TabIndex = 14
        Me.dgvShdule.Tag = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(519, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Year "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(561, 9)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(116, 21)
        Me.cmbYear.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(782, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Month "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(836, 9)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(136, 21)
        Me.cmbMonth.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(105, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Selected Date"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(389, 4)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(166, 34)
        Me.cmdUpdate.TabIndex = 21
        Me.cmdUpdate.Text = "Shift(s) Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        Me.cmdUpdate.Visible = False
        '
        'txtSeldate
        '
        Me.txtSeldate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeldate.Location = New System.Drawing.Point(239, 27)
        Me.txtSeldate.Name = "txtSeldate"
        Me.txtSeldate.Size = New System.Drawing.Size(145, 21)
        Me.txtSeldate.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkGray
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(561, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 21)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Selected Shift "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Visible = False
        '
        'txtSelShft
        '
        Me.txtSelShft.Location = New System.Drawing.Point(204, 15)
        Me.txtSelShft.Name = "txtSelShft"
        Me.txtSelShft.Size = New System.Drawing.Size(167, 21)
        Me.txtSelShft.TabIndex = 15
        Me.txtSelShft.Visible = False
        '
        'dgvLineShift
        '
        Me.dgvLineShift.AllowUserToAddRows = False
        Me.dgvLineShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLineShift.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.shiftno, Me.adate, Me.shiftid})
        Me.dgvLineShift.Location = New System.Drawing.Point(655, 6)
        Me.dgvLineShift.Name = "dgvLineShift"
        Me.dgvLineShift.ReadOnly = True
        Me.dgvLineShift.Size = New System.Drawing.Size(97, 73)
        Me.dgvLineShift.TabIndex = 22
        Me.dgvLineShift.Visible = False
        '
        'shiftno
        '
        Me.shiftno.HeaderText = "Shift No"
        Me.shiftno.Name = "shiftno"
        Me.shiftno.ReadOnly = True
        '
        'adate
        '
        Me.adate.HeaderText = "At Date"
        Me.adate.Name = "adate"
        Me.adate.ReadOnly = True
        '
        'shiftid
        '
        Me.shiftid.HeaderText = "Shift ID"
        Me.shiftid.Name = "shiftid"
        Me.shiftid.ReadOnly = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(105, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(116, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Change Day Mode "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDayType
        '
        Me.cmbDayType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDayType.FormattingEnabled = True
        Me.cmbDayType.Location = New System.Drawing.Point(239, 53)
        Me.cmbDayType.Name = "cmbDayType"
        Me.cmbDayType.Size = New System.Drawing.Size(145, 21)
        Me.cmbDayType.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cmbDayType)
        Me.GroupBox2.Controls.Add(Me.txtSeldate)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(455, 101)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Change Selected Day Mode"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdEditOffDay)
        Me.GroupBox1.Controls.Add(Me.chkEditSelect)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbWorkDay)
        Me.GroupBox1.Location = New System.Drawing.Point(444, 12)
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
        'cmdEdit
        '
        Me.cmdEdit.ImageIndex = 0
        Me.cmdEdit.Location = New System.Drawing.Point(503, 18)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(30, 24)
        Me.cmdEdit.TabIndex = 24
        Me.cmdEdit.UseVisualStyleBackColor = True
        Me.cmdEdit.Visible = False
        '
        'dgvCrShifts
        '
        Me.dgvCrShifts.AllowUserToAddRows = False
        Me.dgvCrShifts.BackgroundColor = System.Drawing.Color.White
        Me.dgvCrShifts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCrShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCrShifts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selec, Me.shID, Me.ShiftName, Me.InTime, Me.OutTime})
        Me.dgvCrShifts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCrShifts.GridColor = System.Drawing.Color.White
        Me.dgvCrShifts.Location = New System.Drawing.Point(3, 3)
        Me.dgvCrShifts.Name = "dgvCrShifts"
        Me.dgvCrShifts.RowHeadersVisible = False
        Me.dgvCrShifts.RowHeadersWidth = 12
        Me.dgvCrShifts.Size = New System.Drawing.Size(463, 108)
        Me.dgvCrShifts.TabIndex = 20
        Me.dgvCrShifts.Tag = "1"
        '
        'selec
        '
        Me.selec.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.selec.HeaderText = "PICK"
        Me.selec.Name = "selec"
        Me.selec.Width = 42
        '
        'shID
        '
        Me.shID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.shID.HeaderText = "Shift ID"
        Me.shID.Name = "shID"
        Me.shID.ReadOnly = True
        Me.shID.Width = 76
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
        Me.OutTime.Width = 84
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.cmdSave)
        Me.pnlTop.Controls.Add(Me.cmdRefresh)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.Label25)
        Me.pnlTop.Controls.Add(Me.cmdEdit)
        Me.pnlTop.Controls.Add(Me.GroupBox1)
        Me.pnlTop.Controls.Add(Me.dgvLineShift)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1000, 48)
        Me.pnlTop.TabIndex = 4
        Me.pnlTop.Tag = "1"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdSave.Location = New System.Drawing.Point(925, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 45
        Me.cmdSave.Tag = "3"
        Me.cmdSave.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(961, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 46
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
        Me.PictureBox1.TabIndex = 41
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
        Me.Label25.Size = New System.Drawing.Size(227, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Change Working Day Mode"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(520, 287)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(477, 140)
        Me.TabControl1.TabIndex = 28
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(469, 114)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Change Day Type"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvCrShifts)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(469, 114)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Assign Shift to Roster"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(469, 114)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Assign Calendar Profile"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkCrYears)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cmbWrkCode)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(455, 101)
        Me.GroupBox4.TabIndex = 28
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Select the Calendar Profile"
        '
        'chkCrYears
        '
        Me.chkCrYears.AutoSize = True
        Me.chkCrYears.Location = New System.Drawing.Point(179, 46)
        Me.chkCrYears.Name = "chkCrYears"
        Me.chkCrYears.Size = New System.Drawing.Size(158, 17)
        Me.chkCrYears.TabIndex = 12
        Me.chkCrYears.Text = "Effect for selected Year"
        Me.chkCrYears.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(70, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(99, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Calendar Profile"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbWrkCode
        '
        Me.cmbWrkCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWrkCode.FormattingEnabled = True
        Me.cmbWrkCode.Location = New System.Drawing.Point(175, 20)
        Me.cmbWrkCode.Name = "cmbWrkCode"
        Me.cmbWrkCode.Size = New System.Drawing.Size(211, 21)
        Me.cmbWrkCode.TabIndex = 11
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(85, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(410, 21)
        Me.txtSearch.TabIndex = 15
        '
        'lblRowCoun
        '
        Me.lblRowCoun.AutoSize = True
        Me.lblRowCoun.Location = New System.Drawing.Point(7, 15)
        Me.lblRowCoun.Name = "lblRowCoun"
        Me.lblRowCoun.Size = New System.Drawing.Size(0, 13)
        Me.lblRowCoun.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Name / ID"
        '
        'chkCheck
        '
        Me.chkCheck.AutoSize = True
        Me.chkCheck.Location = New System.Drawing.Point(6, 129)
        Me.chkCheck.Name = "chkCheck"
        Me.chkCheck.Size = New System.Drawing.Size(15, 14)
        Me.chkCheck.TabIndex = 32
        Me.chkCheck.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmbTitle)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.cmbType)
        Me.GroupBox3.Controls.Add(Me.cmbBranch)
        Me.GroupBox3.Controls.Add(Me.cmbDept)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cmbDesig)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.chkCheck)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.cmbCat)
        Me.GroupBox3.Controls.Add(Me.txtSearch)
        Me.GroupBox3.Controls.Add(Me.dgvEmployee)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(505, 421)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Employee Selection"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(281, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Title"
        '
        'cmbTitle
        '
        Me.cmbTitle.BackColor = System.Drawing.Color.White
        Me.cmbTitle.FormattingEnabled = True
        Me.cmbTitle.Location = New System.Drawing.Point(336, 98)
        Me.cmbTitle.Name = "cmbTitle"
        Me.cmbTitle.Size = New System.Drawing.Size(159, 21)
        Me.cmbTitle.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(281, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(34, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Type"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(281, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Branch"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(336, 72)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(159, 21)
        Me.cmbType.TabIndex = 33
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(336, 45)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(159, 21)
        Me.cmbBranch.TabIndex = 34
        '
        'dgvEmployee
        '
        Me.dgvEmployee.AllowUserToAddRows = False
        Me.dgvEmployee.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pick, Me.EmpID, Me.EpfNo, Me.EmpName, Me.desig, Me.depart})
        Me.dgvEmployee.GridColor = System.Drawing.Color.White
        Me.dgvEmployee.Location = New System.Drawing.Point(1, 125)
        Me.dgvEmployee.Name = "dgvEmployee"
        Me.dgvEmployee.RowHeadersVisible = False
        Me.dgvEmployee.RowHeadersWidth = 21
        Me.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmployee.Size = New System.Drawing.Size(503, 294)
        Me.dgvEmployee.TabIndex = 12
        Me.dgvEmployee.Tag = "1"
        '
        'Pick
        '
        Me.Pick.HeaderText = ""
        Me.Pick.Name = "Pick"
        Me.Pick.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Pick.Width = 24
        '
        'EmpID
        '
        Me.EmpID.HeaderText = "EmpID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Visible = False
        Me.EmpID.Width = 77
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
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        '
        'desig
        '
        Me.desig.HeaderText = "Designation"
        Me.desig.Name = "desig"
        Me.desig.Width = 88
        '
        'depart
        '
        Me.depart.HeaderText = "Department"
        Me.depart.Name = "depart"
        Me.depart.Width = 88
        '
        'pnlBotom
        '
        Me.pnlBotom.Controls.Add(Me.Label17)
        Me.pnlBotom.Controls.Add(Me.Label10)
        Me.pnlBotom.Controls.Add(Me.txtSelShft)
        Me.pnlBotom.Controls.Add(Me.lblRowCoun)
        Me.pnlBotom.Controls.Add(Me.cmdUpdate)
        Me.pnlBotom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotom.Location = New System.Drawing.Point(0, 481)
        Me.pnlBotom.Name = "pnlBotom"
        Me.pnlBotom.Size = New System.Drawing.Size(1000, 44)
        Me.pnlBotom.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(1000, 2)
        Me.Label17.TabIndex = 39
        '
        'pnlData
        '
        Me.pnlData.Controls.Add(Me.pnlD2)
        Me.pnlData.Controls.Add(Me.pnlBotom)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlData.Location = New System.Drawing.Point(0, 48)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(1000, 525)
        Me.pnlData.TabIndex = 37
        '
        'pnlD2
        '
        Me.pnlD2.Controls.Add(Me.Label5)
        Me.pnlD2.Controls.Add(Me.Label6)
        Me.pnlD2.Controls.Add(Me.cmbYear)
        Me.pnlD2.Controls.Add(Me.cmbMonth)
        Me.pnlD2.Controls.Add(Me.dgvShdule)
        Me.pnlD2.Controls.Add(Me.TabControl1)
        Me.pnlD2.Controls.Add(Me.GroupBox3)
        Me.pnlD2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlD2.Location = New System.Drawing.Point(0, 0)
        Me.pnlD2.Name = "pnlD2"
        Me.pnlD2.Size = New System.Drawing.Size(1000, 481)
        Me.pnlD2.TabIndex = 37
        '
        'pnlAllD
        '
        Me.pnlAllD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllD.Controls.Add(Me.pnlData)
        Me.pnlAllD.Controls.Add(Me.pnlTop)
        Me.pnlAllD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllD.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllD.Name = "pnlAllD"
        Me.pnlAllD.Size = New System.Drawing.Size(1002, 575)
        Me.pnlAllD.TabIndex = 43
        '
        'frmRosterAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1002, 575)
        Me.Controls.Add(Me.pnlAllD)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRosterAssign"
        Me.Text = "Roster Manager"
        CType(Me.dgvShdule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLineShift, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCrShifts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotom.ResumeLayout(False)
        Me.pnlBotom.PerformLayout()
        Me.pnlData.ResumeLayout(False)
        Me.pnlD2.ResumeLayout(False)
        Me.pnlD2.PerformLayout()
        Me.pnlAllD.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDesig As System.Windows.Forms.ComboBox
    Friend WithEvents dgvShdule As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCrShifts As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbWorkDay As System.Windows.Forms.ComboBox
    Friend WithEvents txtSeldate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSelShft As System.Windows.Forms.TextBox
    Friend WithEvents dgvLineShift As System.Windows.Forms.DataGridView
    Friend WithEvents shiftno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents adate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shiftid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents selec As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents shID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkEditSelect As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbDayType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents cmdEditOffDay As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblRowCoun As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkCheck As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvEmployee As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Pick As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EpfNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents depart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbWrkCode As System.Windows.Forms.ComboBox
    Friend WithEvents chkCrYears As System.Windows.Forms.CheckBox
    Friend WithEvents pnlBotom As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAllD As System.Windows.Forms.Panel
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    Friend WithEvents pnlD2 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
