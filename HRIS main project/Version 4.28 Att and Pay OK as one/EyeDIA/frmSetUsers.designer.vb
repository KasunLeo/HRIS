<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetUsers
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
        Me.txtRePw = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbUserVLv = New System.Windows.Forms.ComboBox()
        Me.cmbUserLevel = New System.Windows.Forms.ComboBox()
        Me.dgvUlv = New System.Windows.Forms.DataGridView()
        Me.LvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LvName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lgname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usrLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.viewLv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rostOp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.report = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkUlvStatus = New System.Windows.Forms.CheckBox()
        Me.txtPw = New System.Windows.Forms.TextBox()
        Me.txtLogName = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbRosterOpt = New System.Windows.Forms.ComboBox()
        Me.cmdBrsC = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDesciption = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbReporVlV = New System.Windows.Forms.ComboBox()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.pnlReportLevel = New System.Windows.Forms.Panel()
        Me.pnlBranchLevel = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        CType(Me.dgvUlv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRePw
        '
        Me.txtRePw.Location = New System.Drawing.Point(151, 193)
        Me.txtRePw.MaxLength = 10
        Me.txtRePw.Name = "txtRePw"
        Me.txtRePw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRePw.Size = New System.Drawing.Size(146, 21)
        Me.txtRePw.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(148, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 13)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Re-Enter Password "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbUserVLv
        '
        Me.cmbUserVLv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserVLv.FormattingEnabled = True
        Me.cmbUserVLv.Location = New System.Drawing.Point(5, 234)
        Me.cmbUserVLv.Name = "cmbUserVLv"
        Me.cmbUserVLv.Size = New System.Drawing.Size(140, 21)
        Me.cmbUserVLv.TabIndex = 2
        Me.cmbUserVLv.Visible = False
        '
        'cmbUserLevel
        '
        Me.cmbUserLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserLevel.FormattingEnabled = True
        Me.cmbUserLevel.Location = New System.Drawing.Point(5, 151)
        Me.cmbUserLevel.Name = "cmbUserLevel"
        Me.cmbUserLevel.Size = New System.Drawing.Size(292, 21)
        Me.cmbUserLevel.TabIndex = 2
        '
        'dgvUlv
        '
        Me.dgvUlv.AllowUserToAddRows = False
        Me.dgvUlv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvUlv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUlv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUlv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LvID, Me.LvName, Me.lgname, Me.usrLevel, Me.viewLv, Me.rostOp, Me.report, Me.Status})
        Me.dgvUlv.GridColor = System.Drawing.Color.White
        Me.dgvUlv.Location = New System.Drawing.Point(340, 74)
        Me.dgvUlv.Name = "dgvUlv"
        Me.dgvUlv.ReadOnly = True
        Me.dgvUlv.RowHeadersVisible = False
        Me.dgvUlv.RowHeadersWidth = 12
        Me.dgvUlv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUlv.Size = New System.Drawing.Size(630, 271)
        Me.dgvUlv.TabIndex = 47
        Me.dgvUlv.Tag = "1"
        '
        'LvID
        '
        Me.LvID.HeaderText = "ID"
        Me.LvID.Name = "LvID"
        Me.LvID.ReadOnly = True
        Me.LvID.Visible = False
        Me.LvID.Width = 44
        '
        'LvName
        '
        Me.LvName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LvName.HeaderText = "User Name"
        Me.LvName.Name = "LvName"
        Me.LvName.ReadOnly = True
        '
        'lgname
        '
        Me.lgname.HeaderText = "Login Name"
        Me.lgname.Name = "lgname"
        Me.lgname.ReadOnly = True
        '
        'usrLevel
        '
        Me.usrLevel.HeaderText = "User Level"
        Me.usrLevel.Name = "usrLevel"
        Me.usrLevel.ReadOnly = True
        '
        'viewLv
        '
        Me.viewLv.HeaderText = "View Level"
        Me.viewLv.Name = "viewLv"
        Me.viewLv.ReadOnly = True
        Me.viewLv.Width = 94
        '
        'rostOp
        '
        Me.rostOp.HeaderText = "Rost Option"
        Me.rostOp.Name = "rostOp"
        Me.rostOp.ReadOnly = True
        '
        'report
        '
        Me.report.HeaderText = "Report Level"
        Me.report.Name = "report"
        Me.report.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status "
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'chkUlvStatus
        '
        Me.chkUlvStatus.AutoSize = True
        Me.chkUlvStatus.Location = New System.Drawing.Point(154, 277)
        Me.chkUlvStatus.Name = "chkUlvStatus"
        Me.chkUlvStatus.Size = New System.Drawing.Size(72, 17)
        Me.chkUlvStatus.TabIndex = 5
        Me.chkUlvStatus.Text = "Inactive"
        Me.chkUlvStatus.UseVisualStyleBackColor = True
        '
        'txtPw
        '
        Me.txtPw.Location = New System.Drawing.Point(5, 193)
        Me.txtPw.MaxLength = 10
        Me.txtPw.Name = "txtPw"
        Me.txtPw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPw.Size = New System.Drawing.Size(140, 21)
        Me.txtPw.TabIndex = 3
        '
        'txtLogName
        '
        Me.txtLogName.Location = New System.Drawing.Point(89, 71)
        Me.txtLogName.MaxLength = 10
        Me.txtLogName.Name = "txtLogName"
        Me.txtLogName.Size = New System.Drawing.Size(208, 21)
        Me.txtLogName.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(5, 111)
        Me.txtUserName.MaxLength = 10
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(292, 21)
        Me.txtUserName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Login Password "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Login Name "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 218)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "User View Level "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "User Level"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "User Name "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUserID
        '
        Me.txtUserID.BackColor = System.Drawing.Color.White
        Me.txtUserID.Location = New System.Drawing.Point(5, 71)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.ReadOnly = True
        Me.txtUserID.Size = New System.Drawing.Size(78, 21)
        Me.txtUserID.TabIndex = 44
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(5, 55)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 13)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "User ID "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdClose
        '
        Me.cmdClose.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdClose.Location = New System.Drawing.Point(562, 9)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(88, 26)
        Me.cmdClose.TabIndex = 8
        Me.cmdClose.Tag = "1"
        Me.cmdClose.Text = "C&lose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRefresh.Location = New System.Drawing.Point(468, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(88, 26)
        Me.cmdRefresh.TabIndex = 7
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.Text = "R&efresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdSave.Location = New System.Drawing.Point(374, 9)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(88, 26)
        Me.cmdSave.TabIndex = 6
        Me.cmdSave.Tag = "1"
        Me.cmdSave.Text = "S&ave"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button12)
        Me.Panel1.Controls.Add(Me.Button13)
        Me.Panel1.Controls.Add(Me.txtCod)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(976, 48)
        Me.Panel1.TabIndex = 18
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Transparent
        Me.Button12.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button12.FlatAppearance.BorderSize = 0
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button12.Location = New System.Drawing.Point(906, 10)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(28, 28)
        Me.Button12.TabIndex = 76
        Me.Button12.Tag = "3"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.Transparent
        Me.Button13.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button13.FlatAppearance.BorderSize = 0
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button13.Location = New System.Drawing.Point(942, 10)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(28, 28)
        Me.Button13.TabIndex = 77
        Me.Button13.Tag = "3"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'txtCod
        '
        Me.txtCod.BackColor = System.Drawing.Color.White
        Me.txtCod.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCod.Location = New System.Drawing.Point(340, 18)
        Me.txtCod.MaxLength = 50
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(60, 21)
        Me.txtCod.TabIndex = 27
        Me.txtCod.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(63, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 14)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Add New User"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(976, 2)
        Me.Label2.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 259)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Roster Options"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbRosterOpt
        '
        Me.cmbRosterOpt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRosterOpt.FormattingEnabled = True
        Me.cmbRosterOpt.Items.AddRange(New Object() {"View Permission", "Confirm Permission", "Confirm & Approval Permission"})
        Me.cmbRosterOpt.Location = New System.Drawing.Point(5, 275)
        Me.cmbRosterOpt.Name = "cmbRosterOpt"
        Me.cmbRosterOpt.Size = New System.Drawing.Size(140, 21)
        Me.cmbRosterOpt.TabIndex = 2
        '
        'cmdBrsC
        '
        Me.cmdBrsC.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.cmdBrsC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdBrsC.FlatAppearance.BorderSize = 0
        Me.cmdBrsC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBrsC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrsC.Location = New System.Drawing.Point(303, 110)
        Me.cmdBrsC.Name = "cmdBrsC"
        Me.cmdBrsC.Size = New System.Drawing.Size(22, 22)
        Me.cmdBrsC.TabIndex = 53
        Me.cmdBrsC.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblDesciption)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmdSave)
        Me.Panel2.Controls.Add(Me.cmdRefresh)
        Me.Panel2.Controls.Add(Me.cmdClose)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 344)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(976, 25)
        Me.Panel2.TabIndex = 54
        Me.Panel2.Visible = False
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.Location = New System.Drawing.Point(9, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(144, 13)
        Me.lblDesciption.TabIndex = 55
        Me.lblDesciption.Text = "Add all user information"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(406, 63)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(319, 2)
        Me.Label17.TabIndex = 110
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(337, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Users List"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.pnlBottom)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(976, 702)
        Me.Panel3.TabIndex = 111
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel2)
        Me.Panel5.Controls.Add(Me.Panel1)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.cmbUserVLv)
        Me.Panel5.Controls.Add(Me.chkUlvStatus)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.cmbReporVlV)
        Me.Panel5.Controls.Add(Me.cmbRosterOpt)
        Me.Panel5.Controls.Add(Me.txtUserName)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.txtLogName)
        Me.Panel5.Controls.Add(Me.cmbUserLevel)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.cmdBrsC)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.txtPw)
        Me.Panel5.Controls.Add(Me.dgvUlv)
        Me.Panel5.Controls.Add(Me.txtRePw)
        Me.Panel5.Controls.Add(Me.txtUserID)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(976, 369)
        Me.Panel5.TabIndex = 114
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(151, 218)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Report ViewLevel"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbReporVlV
        '
        Me.cmbReporVlV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReporVlV.FormattingEnabled = True
        Me.cmbReporVlV.Items.AddRange(New Object() {"View Permission", "Confirm Permission", "Confirm & Approval Permission"})
        Me.cmbReporVlV.Location = New System.Drawing.Point(151, 234)
        Me.cmbReporVlV.Name = "cmbReporVlV"
        Me.cmbReporVlV.Size = New System.Drawing.Size(146, 21)
        Me.cmbReporVlV.TabIndex = 112
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.pnlReportLevel)
        Me.pnlBottom.Controls.Add(Me.pnlBranchLevel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 369)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(976, 333)
        Me.pnlBottom.TabIndex = 111
        '
        'pnlReportLevel
        '
        Me.pnlReportLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReportLevel.Location = New System.Drawing.Point(488, 0)
        Me.pnlReportLevel.Name = "pnlReportLevel"
        Me.pnlReportLevel.Size = New System.Drawing.Size(488, 333)
        Me.pnlReportLevel.TabIndex = 1
        '
        'pnlBranchLevel
        '
        Me.pnlBranchLevel.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBranchLevel.Location = New System.Drawing.Point(0, 0)
        Me.pnlBranchLevel.Name = "pnlBranchLevel"
        Me.pnlBranchLevel.Size = New System.Drawing.Size(488, 333)
        Me.pnlBranchLevel.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(976, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(48, 702)
        Me.Panel4.TabIndex = 112
        '
        'frmSetUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSetUsers"
        Me.Text = "New Users ..."
        CType(Me.dgvUlv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents dgvUlv As System.Windows.Forms.DataGridView
    Friend WithEvents chkUlvStatus As System.Windows.Forms.CheckBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbUserLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLogName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPw As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRePw As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbUserVLv As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbRosterOpt As System.Windows.Forms.ComboBox
    Friend WithEvents cmdBrsC As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pnlReportLevel As System.Windows.Forms.Panel
    Friend WithEvents pnlBranchLevel As System.Windows.Forms.Panel
    Friend WithEvents LvID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lgname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usrLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents viewLv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rostOp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents report As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbReporVlV As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
End Class
