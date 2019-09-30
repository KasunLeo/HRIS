<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyNewRoster
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
        Me.Label13 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAlk = New System.Windows.Forms.CheckBox
        Me.dgvDepartment = New System.Windows.Forms.DataGridView
        Me.LvAplID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PICK = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbDesig = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdBrsEmp = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtEmpID = New System.Windows.Forms.TextBox
        Me.lblIsEpf = New System.Windows.Forms.Label
        Me.txtEmpName = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(404, 48)
        Me.Panel1.TabIndex = 11
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
        Me.cmdSave.Location = New System.Drawing.Point(321, 10)
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
        Me.cmdRefresh.Location = New System.Drawing.Point(357, 10)
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
        Me.PictureBox1.Location = New System.Drawing.Point(8, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(63, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(176, 18)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Copy Roster Pattern"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.webmail
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(227, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 26)
        Me.Button1.TabIndex = 38
        Me.Button1.Tag = "1"
        Me.Button1.Text = "&Search"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAlk)
        Me.GroupBox1.Controls.Add(Me.dgvDepartment)
        Me.GroupBox1.Controls.Add(Me.cmbDept)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbDesig)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbCat)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(389, 466)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select employee(s)  to be copy"
        '
        'chkAlk
        '
        Me.chkAlk.AutoSize = True
        Me.chkAlk.Location = New System.Drawing.Point(358, 27)
        Me.chkAlk.Name = "chkAlk"
        Me.chkAlk.Size = New System.Drawing.Size(15, 14)
        Me.chkAlk.TabIndex = 60
        Me.chkAlk.UseVisualStyleBackColor = True
        '
        'dgvDepartment
        '
        Me.dgvDepartment.AllowUserToAddRows = False
        Me.dgvDepartment.BackgroundColor = System.Drawing.Color.White
        Me.dgvDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDepartment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LvAplID, Me.EmpID, Me.EmpName, Me.PICK})
        Me.dgvDepartment.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDepartment.Location = New System.Drawing.Point(6, 17)
        Me.dgvDepartment.Name = "dgvDepartment"
        Me.dgvDepartment.RowHeadersVisible = False
        Me.dgvDepartment.RowHeadersWidth = 20
        Me.dgvDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDepartment.Size = New System.Drawing.Size(377, 318)
        Me.dgvDepartment.TabIndex = 59
        '
        'LvAplID
        '
        Me.LvAplID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LvAplID.HeaderText = "RegID"
        Me.LvAplID.Name = "LvAplID"
        Me.LvAplID.ReadOnly = True
        Me.LvAplID.Visible = False
        '
        'EmpID
        '
        Me.EmpID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.EmpID.HeaderText = "Employee ID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Width = 97
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        '
        'PICK
        '
        Me.PICK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.PICK.HeaderText = "   "
        Me.PICK.Name = "PICK"
        Me.PICK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PICK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.PICK.Width = 38
        '
        'cmbDept
        '
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(92, 343)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(281, 21)
        Me.cmbDept.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(7, 346)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Department "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 410)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Category "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDesig
        '
        Me.cmbDesig.FormattingEnabled = True
        Me.cmbDesig.Location = New System.Drawing.Point(92, 375)
        Me.cmbDesig.Name = "cmbDesig"
        Me.cmbDesig.Size = New System.Drawing.Size(281, 21)
        Me.cmbDesig.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Designation "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 441)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Name / ID"
        '
        'cmbCat
        '
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(92, 407)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(281, 21)
        Me.cmbCat.TabIndex = 11
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(92, 438)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(281, 21)
        Me.txtSearch.TabIndex = 15
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(265, 74)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(112, 21)
        Me.dtpToDate.TabIndex = 39
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(209, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "To Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(83, 74)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(112, 21)
        Me.dtpFrDate.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "From Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdBrsEmp)
        Me.GroupBox2.Controls.Add(Me.dtpToDate)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtEmpID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblIsEpf)
        Me.GroupBox2.Controls.Add(Me.txtEmpName)
        Me.GroupBox2.Controls.Add(Me.dtpFrDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 531)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(389, 101)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Source Employee && Target Date Range"
        '
        'cmdBrsEmp
        '
        Me.cmdBrsEmp.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.cmdBrsEmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdBrsEmp.FlatAppearance.BorderSize = 0
        Me.cmdBrsEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBrsEmp.Location = New System.Drawing.Point(205, 20)
        Me.cmdBrsEmp.Name = "cmdBrsEmp"
        Me.cmdBrsEmp.Size = New System.Drawing.Size(25, 24)
        Me.cmdBrsEmp.TabIndex = 61
        Me.cmdBrsEmp.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 60
        Me.Label6.Text = "Name "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmpID
        '
        Me.txtEmpID.BackColor = System.Drawing.Color.White
        Me.txtEmpID.Location = New System.Drawing.Point(83, 21)
        Me.txtEmpID.Name = "txtEmpID"
        Me.txtEmpID.ReadOnly = True
        Me.txtEmpID.Size = New System.Drawing.Size(116, 21)
        Me.txtEmpID.TabIndex = 57
        '
        'lblIsEpf
        '
        Me.lblIsEpf.AutoSize = True
        Me.lblIsEpf.Location = New System.Drawing.Point(11, 24)
        Me.lblIsEpf.Name = "lblIsEpf"
        Me.lblIsEpf.Size = New System.Drawing.Size(25, 13)
        Me.lblIsEpf.TabIndex = 58
        Me.lblIsEpf.Text = "ID "
        Me.lblIsEpf.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEmpName
        '
        Me.txtEmpName.Location = New System.Drawing.Point(83, 48)
        Me.txtEmpName.Name = "txtEmpName"
        Me.txtEmpName.Size = New System.Drawing.Size(294, 21)
        Me.txtEmpName.TabIndex = 59
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblDesciption)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 665)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(404, 17)
        Me.Panel2.TabIndex = 102
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.ForeColor = System.Drawing.Color.DimGray
        Me.lblDesciption.Location = New System.Drawing.Point(6, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(142, 13)
        Me.lblDesciption.TabIndex = 102
        Me.lblDesciption.Text = "Copy sample employee"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel1)
        Me.pnlAllk.Controls.Add(Me.Panel2)
        Me.pnlAllk.Controls.Add(Me.GroupBox1)
        Me.pnlAllk.Controls.Add(Me.GroupBox2)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(406, 684)
        Me.pnlAllk.TabIndex = 25
        '
        'frmCopyNewRoster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(406, 684)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCopyNewRoster"
        Me.Text = "frmCopyNewRoster"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDesig As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvDepartment As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBrsEmp As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEmpID As System.Windows.Forms.TextBox
    Friend WithEvents lblIsEpf As System.Windows.Forms.Label
    Friend WithEvents txtEmpName As System.Windows.Forms.TextBox
    Friend WithEvents chkAlk As System.Windows.Forms.CheckBox
    Friend WithEvents LvAplID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PICK As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
