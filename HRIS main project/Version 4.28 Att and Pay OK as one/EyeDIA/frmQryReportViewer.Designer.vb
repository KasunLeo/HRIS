<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQryReportViewer
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
        Me.rdbActual = New System.Windows.Forms.RadioButton
        Me.rdbNormal = New System.Windows.Forms.RadioButton
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.cmdReport = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtReportName = New System.Windows.Forms.TextBox
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.cmbDesg = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.cmbTitle = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblEmpSubDept = New System.Windows.Forms.Label
        Me.lblEmpShift = New System.Windows.Forms.Label
        Me.lblEmpAct = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbEmpSubCat = New System.Windows.Forms.ComboBox
        Me.cmbNearCity = New System.Windows.Forms.ComboBox
        Me.cmbEmpAct = New System.Windows.Forms.ComboBox
        Me.cmbBranch = New System.Windows.Forms.ComboBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.dgvAllFldList = New System.Windows.Forms.DataGridView
        Me.fCheckBox = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.rFldID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rfldname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.full_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FldDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dgvFldAllList = New System.Windows.Forms.DataGridView
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvAllFldList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvFldAllList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.rdbActual)
        Me.Panel1.Controls.Add(Me.rdbNormal)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.txtReportName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(989, 48)
        Me.Panel1.TabIndex = 3
        '
        'rdbActual
        '
        Me.rdbActual.AutoSize = True
        Me.rdbActual.BackColor = System.Drawing.Color.Transparent
        Me.rdbActual.ForeColor = System.Drawing.Color.White
        Me.rdbActual.Location = New System.Drawing.Point(778, 12)
        Me.rdbActual.Name = "rdbActual"
        Me.rdbActual.Size = New System.Drawing.Size(99, 17)
        Me.rdbActual.TabIndex = 50
        Me.rdbActual.TabStop = True
        Me.rdbActual.Text = "Actual Cadre"
        Me.rdbActual.UseVisualStyleBackColor = False
        Me.rdbActual.Visible = False
        '
        'rdbNormal
        '
        Me.rdbNormal.AutoSize = True
        Me.rdbNormal.BackColor = System.Drawing.Color.Transparent
        Me.rdbNormal.ForeColor = System.Drawing.Color.White
        Me.rdbNormal.Location = New System.Drawing.Point(673, 12)
        Me.rdbNormal.Name = "rdbNormal"
        Me.rdbNormal.Size = New System.Drawing.Size(99, 17)
        Me.rdbNormal.TabIndex = 49
        Me.rdbNormal.TabStop = True
        Me.rdbNormal.Text = "Active Cadre"
        Me.rdbNormal.UseVisualStyleBackColor = False
        Me.rdbNormal.Visible = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.cmdReport)
        Me.Panel7.Controls.Add(Me.cmdRefresh)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(888, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(101, 48)
        Me.Panel7.TabIndex = 48
        '
        'cmdReport
        '
        Me.cmdReport.BackColor = System.Drawing.Color.Transparent
        Me.cmdReport.BackgroundImage = Global.HRISforBB.My.Resources.Resources.PrintKasun
        Me.cmdReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdReport.FlatAppearance.BorderSize = 0
        Me.cmdReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdReport.Location = New System.Drawing.Point(24, 11)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(28, 28)
        Me.cmdReport.TabIndex = 46
        Me.cmdReport.Tag = "3"
        Me.cmdReport.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(60, 11)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 47
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 1)
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
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(63, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(329, 18)
        Me.Label25.TabIndex = 21
        Me.Label25.Text = "Employee Information to Query Report"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtReportName
        '
        Me.txtReportName.AccessibleName = ""
        Me.txtReportName.BackColor = System.Drawing.Color.White
        Me.txtReportName.Location = New System.Drawing.Point(624, 10)
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.ReadOnly = True
        Me.txtReportName.Size = New System.Drawing.Size(22, 21)
        Me.txtReportName.TabIndex = 0
        Me.txtReportName.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtSearch)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.cmbCat)
        Me.Panel5.Controls.Add(Me.cmbDesg)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.cmbDept)
        Me.Panel5.Controls.Add(Me.cmbTitle)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.lblEmpSubDept)
        Me.Panel5.Controls.Add(Me.lblEmpShift)
        Me.Panel5.Controls.Add(Me.lblEmpAct)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.cmbEmpSubCat)
        Me.Panel5.Controls.Add(Me.cmbNearCity)
        Me.Panel5.Controls.Add(Me.cmbEmpAct)
        Me.Panel5.Controls.Add(Me.cmbBranch)
        Me.Panel5.Controls.Add(Me.cmbType)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(989, 127)
        Me.Panel5.TabIndex = 58
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(151, 14)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(495, 21)
        Me.txtSearch.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Search Text"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Employee Category"
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.Color.White
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(151, 41)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(196, 21)
        Me.cmbCat.TabIndex = 45
        '
        'cmbDesg
        '
        Me.cmbDesg.BackColor = System.Drawing.Color.White
        Me.cmbDesg.FormattingEnabled = True
        Me.cmbDesg.Location = New System.Drawing.Point(151, 69)
        Me.cmbDesg.Name = "cmbDesg"
        Me.cmbDesg.Size = New System.Drawing.Size(196, 21)
        Me.cmbDesg.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(356, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Employee Title"
        '
        'cmbDept
        '
        Me.cmbDept.BackColor = System.Drawing.Color.White
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(151, 95)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(196, 21)
        Me.cmbDept.TabIndex = 43
        '
        'cmbTitle
        '
        Me.cmbTitle.BackColor = System.Drawing.Color.White
        Me.cmbTitle.FormattingEnabled = True
        Me.cmbTitle.Location = New System.Drawing.Point(469, 95)
        Me.cmbTitle.Name = "cmbTitle"
        Me.cmbTitle.Size = New System.Drawing.Size(177, 21)
        Me.cmbTitle.TabIndex = 53
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(134, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Employee Designation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(356, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Employee Type"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Employee Department"
        '
        'lblEmpSubDept
        '
        Me.lblEmpSubDept.AutoSize = True
        Me.lblEmpSubDept.Location = New System.Drawing.Point(656, 73)
        Me.lblEmpSubDept.Name = "lblEmpSubDept"
        Me.lblEmpSubDept.Size = New System.Drawing.Size(86, 13)
        Me.lblEmpSubDept.TabIndex = 51
        Me.lblEmpSubDept.Text = "Sub Category"
        '
        'lblEmpShift
        '
        Me.lblEmpShift.AutoSize = True
        Me.lblEmpShift.Location = New System.Drawing.Point(656, 99)
        Me.lblEmpShift.Name = "lblEmpShift"
        Me.lblEmpShift.Size = New System.Drawing.Size(78, 13)
        Me.lblEmpShift.TabIndex = 51
        Me.lblEmpShift.Text = "Nearest City"
        '
        'lblEmpAct
        '
        Me.lblEmpAct.AutoSize = True
        Me.lblEmpAct.Location = New System.Drawing.Point(656, 45)
        Me.lblEmpAct.Name = "lblEmpAct"
        Me.lblEmpAct.Size = New System.Drawing.Size(85, 13)
        Me.lblEmpAct.TabIndex = 51
        Me.lblEmpAct.Text = "Employee Act"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(356, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Employee Branch"
        '
        'cmbEmpSubCat
        '
        Me.cmbEmpSubCat.BackColor = System.Drawing.Color.White
        Me.cmbEmpSubCat.FormattingEnabled = True
        Me.cmbEmpSubCat.Location = New System.Drawing.Point(769, 69)
        Me.cmbEmpSubCat.Name = "cmbEmpSubCat"
        Me.cmbEmpSubCat.Size = New System.Drawing.Size(177, 21)
        Me.cmbEmpSubCat.TabIndex = 50
        '
        'cmbNearCity
        '
        Me.cmbNearCity.BackColor = System.Drawing.Color.White
        Me.cmbNearCity.FormattingEnabled = True
        Me.cmbNearCity.Location = New System.Drawing.Point(769, 95)
        Me.cmbNearCity.Name = "cmbNearCity"
        Me.cmbNearCity.Size = New System.Drawing.Size(177, 21)
        Me.cmbNearCity.TabIndex = 50
        '
        'cmbEmpAct
        '
        Me.cmbEmpAct.BackColor = System.Drawing.Color.White
        Me.cmbEmpAct.FormattingEnabled = True
        Me.cmbEmpAct.Location = New System.Drawing.Point(769, 41)
        Me.cmbEmpAct.Name = "cmbEmpAct"
        Me.cmbEmpAct.Size = New System.Drawing.Size(177, 21)
        Me.cmbEmpAct.TabIndex = 50
        '
        'cmbBranch
        '
        Me.cmbBranch.BackColor = System.Drawing.Color.White
        Me.cmbBranch.FormattingEnabled = True
        Me.cmbBranch.Location = New System.Drawing.Point(469, 41)
        Me.cmbBranch.Name = "cmbBranch"
        Me.cmbBranch.Size = New System.Drawing.Size(177, 21)
        Me.cmbBranch.TabIndex = 50
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.White
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(469, 69)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(177, 21)
        Me.cmbType.TabIndex = 49
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvAllFldList)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 175)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 332)
        Me.Panel2.TabIndex = 59
        '
        'dgvAllFldList
        '
        Me.dgvAllFldList.AllowUserToAddRows = False
        Me.dgvAllFldList.BackgroundColor = System.Drawing.Color.White
        Me.dgvAllFldList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAllFldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllFldList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fCheckBox, Me.rFldID, Me.Rfldname, Me.full_Name, Me.FldDesc})
        Me.dgvAllFldList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAllFldList.GridColor = System.Drawing.Color.White
        Me.dgvAllFldList.Location = New System.Drawing.Point(0, 0)
        Me.dgvAllFldList.Name = "dgvAllFldList"
        Me.dgvAllFldList.RowHeadersVisible = False
        Me.dgvAllFldList.RowHeadersWidth = 12
        Me.dgvAllFldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllFldList.Size = New System.Drawing.Size(236, 332)
        Me.dgvAllFldList.TabIndex = 8
        Me.dgvAllFldList.Tag = "1"
        '
        'fCheckBox
        '
        Me.fCheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.fCheckBox.HeaderText = "[X]"
        Me.fCheckBox.Name = "fCheckBox"
        Me.fCheckBox.Width = 31
        '
        'rFldID
        '
        Me.rFldID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.rFldID.HeaderText = "Feild ID"
        Me.rFldID.Name = "rFldID"
        Me.rFldID.ReadOnly = True
        Me.rFldID.Visible = False
        '
        'Rfldname
        '
        Me.Rfldname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Rfldname.HeaderText = "Feild Name"
        Me.Rfldname.Name = "Rfldname"
        Me.Rfldname.ReadOnly = True
        Me.Rfldname.Visible = False
        '
        'full_Name
        '
        Me.full_Name.HeaderText = "Full Name"
        Me.full_Name.Name = "full_Name"
        Me.full_Name.Visible = False
        '
        'FldDesc
        '
        Me.FldDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FldDesc.HeaderText = "Decription"
        Me.FldDesc.Name = "FldDesc"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvFldAllList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(236, 175)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(753, 332)
        Me.Panel3.TabIndex = 59
        '
        'dgvFldAllList
        '
        Me.dgvFldAllList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFldAllList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFldAllList.Location = New System.Drawing.Point(0, 0)
        Me.dgvFldAllList.Name = "dgvFldAllList"
        Me.dgvFldAllList.Size = New System.Drawing.Size(753, 332)
        Me.dgvFldAllList.TabIndex = 0
        '
        'frmQryReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(989, 507)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmQryReportViewer"
        Me.Text = "frmQryReportViewer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvAllFldList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvFldAllList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbActual As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNormal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtReportName As System.Windows.Forms.TextBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDesg As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblEmpSubDept As System.Windows.Forms.Label
    Friend WithEvents lblEmpShift As System.Windows.Forms.Label
    Friend WithEvents lblEmpAct As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbEmpSubCat As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNearCity As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEmpAct As System.Windows.Forms.ComboBox
    Friend WithEvents cmbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvAllFldList As System.Windows.Forms.DataGridView
    Friend WithEvents fCheckBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents rFldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rfldname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents full_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FldDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvFldAllList As System.Windows.Forms.DataGridView
End Class
