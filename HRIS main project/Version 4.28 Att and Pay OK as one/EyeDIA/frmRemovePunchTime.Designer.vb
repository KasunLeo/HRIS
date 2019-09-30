<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemovePunchTime
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdbOriginal = New System.Windows.Forms.RadioButton
        Me.rdbManual = New System.Windows.Forms.RadioButton
        Me.dgvTempDGV = New System.Windows.Forms.DataGridView
        Me.rdbAll = New System.Windows.Forms.RadioButton
        Me.btnRemove = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbShiftName = New System.Windows.Forms.ComboBox
        Me.cmbDesg = New System.Windows.Forms.ComboBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label31 = New System.Windows.Forms.Label
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.Label30 = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.pnlGriData = New System.Windows.Forms.Panel
        Me.pnlLeft = New System.Windows.Forms.Panel
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.chkAutoRefresh = New System.Windows.Forms.CheckBox
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.lblCurDate = New System.Windows.Forms.Label
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlRight = New System.Windows.Forms.Panel
        Me.pnlMostRLeft = New System.Windows.Forms.Panel
        Me.dgvAllEmp = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.pnlEditHistory = New System.Windows.Forms.Panel
        Me.pgb = New System.Windows.Forms.ProgressBar
        Me.lblSelectedEmpoyees = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblEmpCount = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        CType(Me.dgvTempDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGriData.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnlMostRLeft.SuspendLayout()
        CType(Me.dgvAllEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlEditHistory.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.rdbOriginal)
        Me.Panel2.Controls.Add(Me.rdbManual)
        Me.Panel2.Controls.Add(Me.dgvTempDGV)
        Me.Panel2.Controls.Add(Me.rdbAll)
        Me.Panel2.Controls.Add(Me.btnRemove)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbShiftName)
        Me.Panel2.Controls.Add(Me.cmbDesg)
        Me.Panel2.Controls.Add(Me.cmbType)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.cmbBranch)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.cmbDept)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbCat)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.dtpToDate)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.dtpFromDate)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 98)
        Me.Panel2.TabIndex = 74
        '
        'rdbOriginal
        '
        Me.rdbOriginal.AutoSize = True
        Me.rdbOriginal.ForeColor = System.Drawing.Color.White
        Me.rdbOriginal.Location = New System.Drawing.Point(818, 71)
        Me.rdbOriginal.Name = "rdbOriginal"
        Me.rdbOriginal.Size = New System.Drawing.Size(119, 17)
        Me.rdbOriginal.TabIndex = 170
        Me.rdbOriginal.TabStop = True
        Me.rdbOriginal.Text = "Original Records"
        Me.rdbOriginal.UseVisualStyleBackColor = True
        '
        'rdbManual
        '
        Me.rdbManual.AutoSize = True
        Me.rdbManual.ForeColor = System.Drawing.Color.White
        Me.rdbManual.Location = New System.Drawing.Point(697, 71)
        Me.rdbManual.Name = "rdbManual"
        Me.rdbManual.Size = New System.Drawing.Size(115, 17)
        Me.rdbManual.TabIndex = 169
        Me.rdbManual.TabStop = True
        Me.rdbManual.Text = "Manual Records"
        Me.rdbManual.UseVisualStyleBackColor = True
        '
        'dgvTempDGV
        '
        Me.dgvTempDGV.AllowUserToAddRows = False
        Me.dgvTempDGV.AllowUserToDeleteRows = False
        Me.dgvTempDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTempDGV.Location = New System.Drawing.Point(687, 45)
        Me.dgvTempDGV.Name = "dgvTempDGV"
        Me.dgvTempDGV.ReadOnly = True
        Me.dgvTempDGV.Size = New System.Drawing.Size(22, 23)
        Me.dgvTempDGV.TabIndex = 117
        Me.dgvTempDGV.Visible = False
        '
        'rdbAll
        '
        Me.rdbAll.AutoSize = True
        Me.rdbAll.ForeColor = System.Drawing.Color.White
        Me.rdbAll.Location = New System.Drawing.Point(602, 70)
        Me.rdbAll.Name = "rdbAll"
        Me.rdbAll.Size = New System.Drawing.Size(89, 17)
        Me.rdbAll.TabIndex = 168
        Me.rdbAll.TabStop = True
        Me.rdbAll.Text = "All Records"
        Me.rdbAll.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Transparent
        Me.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRemove.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRemove.Location = New System.Drawing.Point(494, 66)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(93, 26)
        Me.btnRemove.TabIndex = 167
        Me.btnRemove.Tag = "4"
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(6, 54)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 84
        Me.Label21.Text = "Shift Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(170, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 13)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Employee Designation"
        '
        'cmbShiftName
        '
        Me.cmbShiftName.BackColor = System.Drawing.Color.White
        Me.cmbShiftName.FormattingEnabled = True
        Me.cmbShiftName.Location = New System.Drawing.Point(7, 70)
        Me.cmbShiftName.Name = "cmbShiftName"
        Me.cmbShiftName.Size = New System.Drawing.Size(157, 21)
        Me.cmbShiftName.TabIndex = 76
        '
        'cmbDesg
        '
        Me.cmbDesg.BackColor = System.Drawing.Color.White
        Me.cmbDesg.FormattingEnabled = True
        Me.cmbDesg.Location = New System.Drawing.Point(172, 70)
        Me.cmbDesg.Name = "cmbDesg"
        Me.cmbDesg.Size = New System.Drawing.Size(157, 21)
        Me.cmbDesg.TabIndex = 78
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(336, 70)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(152, 21)
        Me.cmbType.TabIndex = 80
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(334, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 13)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "Employee Type"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(368, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 24)
        Me.Button2.TabIndex = 75
        Me.Button2.Tag = "3"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Search Text"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.HIDEK
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(899, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 26)
        Me.Button1.TabIndex = 73
        Me.Button1.Tag = "4"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(261, 6)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 13)
        Me.Label31.TabIndex = 70
        Me.Label31.Text = "To Day"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(405, 22)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(157, 21)
        Me.cmbBranch.TabIndex = 60
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(404, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(120, 13)
        Me.Label16.TabIndex = 61
        Me.Label16.Text = "Employee Branch"
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(568, 22)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(157, 21)
        Me.cmbDept.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(568, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(152, 13)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Employee Department"
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.White
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(731, 22)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(152, 21)
        Me.cmbCat.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(729, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "Employee Category"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(6, 22)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(149, 21)
        Me.txtSearch.TabIndex = 54
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "yyyy MMM dd"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(264, 22)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 21)
        Me.dtpToDate.TabIndex = 65
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(160, 6)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(70, 13)
        Me.Label30.TabIndex = 69
        Me.Label30.Text = "From Day"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "yyyy MMM dd"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(163, 22)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(94, 21)
        Me.dtpFromDate.TabIndex = 66
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(574, 6)
        Me.txtNote.MaxLength = 56
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(189, 21)
        Me.txtNote.TabIndex = 167
        '
        'pnlGriData
        '
        Me.pnlGriData.Controls.Add(Me.pnlLeft)
        Me.pnlGriData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGriData.Location = New System.Drawing.Point(0, 98)
        Me.pnlGriData.Name = "pnlGriData"
        Me.pnlGriData.Size = New System.Drawing.Size(970, 382)
        Me.pnlGriData.TabIndex = 75
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.dgvData)
        Me.pnlLeft.Controls.Add(Me.Panel3)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(970, 382)
        Me.pnlLeft.TabIndex = 0
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.Size = New System.Drawing.Size(970, 349)
        Me.dgvData.TabIndex = 25
        Me.dgvData.Tag = "1"
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.txtNote)
        Me.Panel3.Controls.Add(Me.chkAutoRefresh)
        Me.Panel3.Controls.Add(Me.Label48)
        Me.Panel3.Controls.Add(Me.Label49)
        Me.Panel3.Controls.Add(Me.Label44)
        Me.Panel3.Controls.Add(Me.Label45)
        Me.Panel3.Controls.Add(Me.Label46)
        Me.Panel3.Controls.Add(Me.Label47)
        Me.Panel3.Controls.Add(Me.Button5)
        Me.Panel3.Controls.Add(Me.lblCurDate)
        Me.Panel3.Controls.Add(Me.cmdPrevious)
        Me.Panel3.Controls.Add(Me.cmdNext)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 349)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(970, 33)
        Me.Panel3.TabIndex = 26
        '
        'chkAutoRefresh
        '
        Me.chkAutoRefresh.AutoSize = True
        Me.chkAutoRefresh.BackColor = System.Drawing.Color.Transparent
        Me.chkAutoRefresh.ForeColor = System.Drawing.Color.Coral
        Me.chkAutoRefresh.Location = New System.Drawing.Point(783, 9)
        Me.chkAutoRefresh.Name = "chkAutoRefresh"
        Me.chkAutoRefresh.Size = New System.Drawing.Size(100, 17)
        Me.chkAutoRefresh.TabIndex = 167
        Me.chkAutoRefresh.Text = "Auto Refresh"
        Me.chkAutoRefresh.UseVisualStyleBackColor = False
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(1101, 13)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(56, 13)
        Me.Label48.TabIndex = 166
        Me.Label48.Text = "Half Day"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Purple
        Me.Label49.Location = New System.Drawing.Point(1083, 13)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(16, 13)
        Me.Label49.TabIndex = 165
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(1181, 12)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(51, 13)
        Me.Label44.TabIndex = 164
        Me.Label44.Text = "Off Day"
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Orange
        Me.Label45.Location = New System.Drawing.Point(1163, 12)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(16, 13)
        Me.Label45.TabIndex = 163
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(1013, 12)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(63, 13)
        Me.Label46.TabIndex = 162
        Me.Label46.Text = "Work Day"
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.SteelBlue
        Me.Label47.Location = New System.Drawing.Point(995, 12)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(16, 13)
        Me.Label47.TabIndex = 161
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button5.Location = New System.Drawing.Point(191, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(93, 26)
        Me.Button5.TabIndex = 72
        Me.Button5.Tag = "4"
        Me.Button5.Text = "List"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'lblCurDate
        '
        Me.lblCurDate.AutoSize = True
        Me.lblCurDate.BackColor = System.Drawing.Color.Transparent
        Me.lblCurDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurDate.ForeColor = System.Drawing.Color.White
        Me.lblCurDate.Location = New System.Drawing.Point(442, 10)
        Me.lblCurDate.Name = "lblCurDate"
        Me.lblCurDate.Size = New System.Drawing.Size(91, 13)
        Me.lblCurDate.TabIndex = 71
        Me.lblCurDate.Text = "2106-Mar-12"
        '
        'cmdPrevious
        '
        Me.cmdPrevious.BackColor = System.Drawing.Color.Transparent
        Me.cmdPrevious.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Back
        Me.cmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdPrevious.FlatAppearance.BorderSize = 0
        Me.cmdPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPrevious.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdPrevious.Location = New System.Drawing.Point(407, 3)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(32, 26)
        Me.cmdPrevious.TabIndex = 70
        Me.cmdPrevious.Tag = "6"
        Me.cmdPrevious.UseVisualStyleBackColor = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.Transparent
        Me.cmdNext.BackgroundImage = Global.HRISforBB.My.Resources.Resources._next
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.cmdNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdNext.Location = New System.Drawing.Point(536, 3)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(32, 26)
        Me.cmdNext.TabIndex = 69
        Me.cmdNext.Tag = "6"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Type word to search "
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.pnlGriData)
        Me.pnlRight.Controls.Add(Me.Panel2)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRight.Location = New System.Drawing.Point(4, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(970, 480)
        Me.pnlRight.TabIndex = 77
        '
        'pnlMostRLeft
        '
        Me.pnlMostRLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlMostRLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMostRLeft.Controls.Add(Me.dgvAllEmp)
        Me.pnlMostRLeft.Controls.Add(Me.Panel1)
        Me.pnlMostRLeft.Controls.Add(Me.pnlEditHistory)
        Me.pnlMostRLeft.Controls.Add(Me.Panel4)
        Me.pnlMostRLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMostRLeft.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMostRLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlMostRLeft.Name = "pnlMostRLeft"
        Me.pnlMostRLeft.Size = New System.Drawing.Size(4, 480)
        Me.pnlMostRLeft.TabIndex = 108
        '
        'dgvAllEmp
        '
        Me.dgvAllEmp.AllowUserToAddRows = False
        Me.dgvAllEmp.BackgroundColor = System.Drawing.Color.White
        Me.dgvAllEmp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAllEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllEmp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAllEmp.GridColor = System.Drawing.Color.White
        Me.dgvAllEmp.Location = New System.Drawing.Point(0, 69)
        Me.dgvAllEmp.Name = "dgvAllEmp"
        Me.dgvAllEmp.ReadOnly = True
        Me.dgvAllEmp.RowHeadersVisible = False
        Me.dgvAllEmp.RowHeadersWidth = 28
        Me.dgvAllEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllEmp.Size = New System.Drawing.Size(2, 377)
        Me.dgvAllEmp.TabIndex = 42
        Me.dgvAllEmp.TabStop = False
        Me.dgvAllEmp.Tag = "1"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(2, 21)
        Me.Panel1.TabIndex = 98
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(24, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(0, 19)
        Me.TextBox1.TabIndex = 43
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(24, 19)
        Me.Button3.TabIndex = 77
        Me.Button3.Tag = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'pnlEditHistory
        '
        Me.pnlEditHistory.Controls.Add(Me.pgb)
        Me.pnlEditHistory.Controls.Add(Me.lblSelectedEmpoyees)
        Me.pnlEditHistory.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEditHistory.Location = New System.Drawing.Point(0, 446)
        Me.pnlEditHistory.Name = "pnlEditHistory"
        Me.pnlEditHistory.Size = New System.Drawing.Size(2, 32)
        Me.pnlEditHistory.TabIndex = 118
        '
        'pgb
        '
        Me.pgb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgb.Location = New System.Drawing.Point(0, 30)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(2, 2)
        Me.pgb.TabIndex = 122
        '
        'lblSelectedEmpoyees
        '
        Me.lblSelectedEmpoyees.AutoSize = True
        Me.lblSelectedEmpoyees.Location = New System.Drawing.Point(11, 10)
        Me.lblSelectedEmpoyees.Name = "lblSelectedEmpoyees"
        Me.lblSelectedEmpoyees.Size = New System.Drawing.Size(44, 13)
        Me.lblSelectedEmpoyees.TabIndex = 0
        Me.lblSelectedEmpoyees.Text = "Label5"
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel4.Controls.Add(Me.lblEmpCount)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(2, 48)
        Me.Panel4.TabIndex = 41
        '
        'lblEmpCount
        '
        Me.lblEmpCount.AutoSize = True
        Me.lblEmpCount.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpCount.ForeColor = System.Drawing.Color.Transparent
        Me.lblEmpCount.Location = New System.Drawing.Point(11, 15)
        Me.lblEmpCount.Name = "lblEmpCount"
        Me.lblEmpCount.Size = New System.Drawing.Size(98, 13)
        Me.lblEmpCount.TabIndex = 19
        Me.lblEmpCount.Text = "Employee List"
        Me.lblEmpCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmRemovePunchTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 480)
        Me.Controls.Add(Me.pnlRight)
        Me.Controls.Add(Me.pnlMostRLeft)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmRemovePunchTime"
        Me.Text = "frmRemovePunchTime"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvTempDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGriData.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlRight.ResumeLayout(False)
        Me.pnlMostRLeft.ResumeLayout(False)
        CType(Me.dgvAllEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlEditHistory.ResumeLayout(False)
        Me.pnlEditHistory.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlGriData As System.Windows.Forms.Panel
    Friend WithEvents pnlLeft As System.Windows.Forms.Panel
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents lblCurDate As System.Windows.Forms.Label
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlRight As System.Windows.Forms.Panel
    Friend WithEvents pnlMostRLeft As System.Windows.Forms.Panel
    Friend WithEvents dgvAllEmp As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents pnlEditHistory As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblEmpCount As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbShiftName As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDesg As System.Windows.Forms.ComboBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblSelectedEmpoyees As System.Windows.Forms.Label
    Friend WithEvents dgvTempDGV As System.Windows.Forms.DataGridView
    Friend WithEvents pgb As System.Windows.Forms.ProgressBar
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents chkAutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents rdbOriginal As System.Windows.Forms.RadioButton
    Friend WithEvents rdbManual As System.Windows.Forms.RadioButton
    Friend WithEvents rdbAll As System.Windows.Forms.RadioButton
End Class
