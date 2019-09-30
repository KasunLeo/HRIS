<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRandomReport
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.cmdView = New System.Windows.Forms.Button
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbCategory = New System.Windows.Forms.ComboBox
        Me.dgvReports = New System.Windows.Forms.DataGridView
        Me.RepID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtTitle = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtQry = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblcount = New System.Windows.Forms.ToolStripStatusLabel
        Me.pbKasun = New System.Windows.Forms.ToolStripProgressBar
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblColumn = New System.Windows.Forms.ToolStripStatusLabel
        Me.dgvQuery = New System.Windows.Forms.DataGridView
        Me.cmbMonth = New System.Windows.Forms.ComboBox
        Me.cmbYear = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pnlDat = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.pnlAllkk = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDat.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlAllkk.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(966, 48)
        Me.Panel1.TabIndex = 31
        Me.Panel1.Tag = "1"
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
        Me.cmdSave.Location = New System.Drawing.Point(890, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 87
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
        Me.cmdRefresh.Location = New System.Drawing.Point(926, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 86
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(63, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(169, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Add Custom Report"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbDept)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.cmbCategory)
        Me.GroupBox1.Controls.Add(Me.dgvReports)
        Me.GroupBox1.Controls.Add(Me.txtTitle)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtQry)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(958, 215)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel5.Controls.Add(Me.cmdView)
        Me.Panel5.Controls.Add(Me.btnToExcel)
        Me.Panel5.Controls.Add(Me.btnGenerate)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(3, 164)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(952, 48)
        Me.Panel5.TabIndex = 59
        Me.Panel5.Tag = "1"
        '
        'cmdView
        '
        Me.cmdView.BackColor = System.Drawing.Color.Transparent
        Me.cmdView.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Connect
        Me.cmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdView.FlatAppearance.BorderSize = 0
        Me.cmdView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdView.Location = New System.Drawing.Point(5, 10)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(28, 28)
        Me.cmdView.TabIndex = 89
        Me.cmdView.Tag = "3"
        Me.cmdView.UseVisualStyleBackColor = False
        '
        'btnToExcel
        '
        Me.btnToExcel.BackColor = System.Drawing.Color.Transparent
        Me.btnToExcel.BackgroundImage = Global.HRISforBB.My.Resources.Resources.lkkkk
        Me.btnToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnToExcel.FlatAppearance.BorderSize = 0
        Me.btnToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnToExcel.Location = New System.Drawing.Point(41, 10)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(28, 28)
        Me.btnToExcel.TabIndex = 88
        Me.btnToExcel.Tag = "3"
        Me.btnToExcel.UseVisualStyleBackColor = False
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.Transparent
        Me.btnGenerate.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.btnGenerate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnGenerate.FlatAppearance.BorderSize = 0
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnGenerate.Location = New System.Drawing.Point(80, 10)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(28, 28)
        Me.btnGenerate.TabIndex = 87
        Me.btnGenerate.Tag = "3"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(719, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Deprtmnt"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(791, 37)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(160, 21)
        Me.cmbDept.TabIndex = 57
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(719, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Category"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCategory
        '
        Me.cmbCategory.BackColor = System.Drawing.Color.White
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(791, 12)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(160, 21)
        Me.cmbCategory.TabIndex = 55
        '
        'dgvReports
        '
        Me.dgvReports.AllowUserToAddRows = False
        Me.dgvReports.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RepID, Me.RpName})
        Me.dgvReports.GridColor = System.Drawing.Color.White
        Me.dgvReports.Location = New System.Drawing.Point(2, 8)
        Me.dgvReports.Name = "dgvReports"
        Me.dgvReports.ReadOnly = True
        Me.dgvReports.RowHeadersVisible = False
        Me.dgvReports.RowHeadersWidth = 12
        Me.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReports.Size = New System.Drawing.Size(317, 137)
        Me.dgvReports.TabIndex = 23
        Me.dgvReports.Tag = "1"
        '
        'RepID
        '
        Me.RepID.HeaderText = "Report ID"
        Me.RepID.Name = "RepID"
        Me.RepID.ReadOnly = True
        Me.RepID.Visible = False
        Me.RepID.Width = 88
        '
        'RpName
        '
        Me.RpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.RpName.HeaderText = "Report Name"
        Me.RpName.Name = "RpName"
        Me.RpName.ReadOnly = True
        '
        'txtTitle
        '
        Me.txtTitle.BackColor = System.Drawing.Color.White
        Me.txtTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(332, 33)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(250, 21)
        Me.txtTitle.TabIndex = 21
        Me.txtTitle.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(329, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Report Title"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(329, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Review Query"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtQry
        '
        Me.txtQry.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQry.Location = New System.Drawing.Point(332, 77)
        Me.txtQry.Multiline = True
        Me.txtQry.Name = "txtQry"
        Me.txtQry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQry.Size = New System.Drawing.Size(619, 68)
        Me.txtQry.TabIndex = 19
        Me.txtQry.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblcount, Me.pbKasun, Me.lblRow, Me.lblColumn})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 549)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(966, 22)
        Me.StatusStrip1.TabIndex = 50
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblcount
        '
        Me.lblcount.Name = "lblcount"
        Me.lblcount.Size = New System.Drawing.Size(40, 17)
        Me.lblcount.Text = "Count"
        '
        'pbKasun
        '
        Me.pbKasun.Name = "pbKasun"
        Me.pbKasun.Size = New System.Drawing.Size(100, 16)
        '
        'lblRow
        '
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(30, 17)
        Me.lblRow.Text = "Row"
        '
        'lblColumn
        '
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(50, 17)
        Me.lblColumn.Text = "Column"
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.BackgroundColor = System.Drawing.Color.White
        Me.dgvQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuery.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvQuery.Location = New System.Drawing.Point(3, 217)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersVisible = False
        Me.dgvQuery.RowHeadersWidth = 12
        Me.dgvQuery.Size = New System.Drawing.Size(964, 249)
        Me.dgvQuery.TabIndex = 48
        Me.dgvQuery.Tag = "1"
        '
        'cmbMonth
        '
        Me.cmbMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(185, 6)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(107, 21)
        Me.cmbMonth.TabIndex = 30
        '
        'cmbYear
        '
        Me.cmbYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(46, 6)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(79, 21)
        Me.cmbYear.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(137, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Month"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(530, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "To Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Year"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(311, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "From Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(394, 6)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(119, 21)
        Me.dtpFrDate.TabIndex = 26
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(592, 6)
        Me.dtpEndDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(116, 21)
        Me.dtpEndDate.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.notcurved46
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.dtpEndDate)
        Me.Panel3.Controls.Add(Me.cmbBranch)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.dtpFrDate)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cmbMonth)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbYear)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(966, 32)
        Me.Panel3.TabIndex = 52
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(724, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Branch"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(796, 6)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(160, 21)
        Me.cmbBranch.TabIndex = 52
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlDat)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(966, 501)
        Me.Panel2.TabIndex = 54
        '
        'pnlDat
        '
        Me.pnlDat.Controls.Add(Me.Panel4)
        Me.pnlDat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDat.Location = New System.Drawing.Point(0, 32)
        Me.pnlDat.Name = "pnlDat"
        Me.pnlDat.Size = New System.Drawing.Size(966, 469)
        Me.pnlDat.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.dgvQuery)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(966, 469)
        Me.Panel4.TabIndex = 55
        '
        'pnlAllkk
        '
        Me.pnlAllkk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllkk.Controls.Add(Me.Panel2)
        Me.pnlAllkk.Controls.Add(Me.Panel1)
        Me.pnlAllkk.Controls.Add(Me.StatusStrip1)
        Me.pnlAllkk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllkk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllkk.Name = "pnlAllkk"
        Me.pnlAllkk.Size = New System.Drawing.Size(968, 573)
        Me.pnlAllkk.TabIndex = 1
        '
        'frmRandomReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.ClientSize = New System.Drawing.Size(968, 573)
        Me.Controls.Add(Me.pnlAllkk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRandomReport"
        Me.Text = "Custom Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlDat.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlAllkk.ResumeLayout(False)
        Me.pnlAllkk.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtQry As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvReports As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblcount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pbKasun As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblRow As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblColumn As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dgvQuery As System.Windows.Forms.DataGridView
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDat As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RepID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAllkk As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
End Class
