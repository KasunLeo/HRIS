<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetLeaveType
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
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtShortCod = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.dsgID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shortCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dsgName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbUpdateNextYear = New System.Windows.Forms.ComboBox
        Me.cmbAlowFutureLv = New System.Windows.Forms.ComboBox
        Me.cmbOthLv = New System.Windows.Forms.ComboBox
        Me.cmbChkLateEarly = New System.Windows.Forms.ComboBox
        Me.cmbChkLimit = New System.Windows.Forms.ComboBox
        Me.cmbEffNos = New System.Windows.Forms.ComboBox
        Me.cmbLvMode = New System.Windows.Forms.ComboBox
        Me.chkStatus = New System.Windows.Forms.CheckBox
        Me.txtMaxLate = New System.Windows.Forms.TextBox
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllk.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtShortCod)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.dgvData)
        Me.Panel2.Controls.Add(Me.cmbUpdateNextYear)
        Me.Panel2.Controls.Add(Me.cmbAlowFutureLv)
        Me.Panel2.Controls.Add(Me.cmbOthLv)
        Me.Panel2.Controls.Add(Me.cmbChkLateEarly)
        Me.Panel2.Controls.Add(Me.cmbChkLimit)
        Me.Panel2.Controls.Add(Me.cmbEffNos)
        Me.Panel2.Controls.Add(Me.cmbLvMode)
        Me.Panel2.Controls.Add(Me.chkStatus)
        Me.Panel2.Controls.Add(Me.txtMaxLate)
        Me.Panel2.Controls.Add(Me.txtDesc)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(656, 462)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblDesciption)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Controls.Add(Me.cmdSave)
        Me.Panel3.Controls.Add(Me.cmdRefresh)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 418)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(656, 44)
        Me.Panel3.TabIndex = 111
        Me.Panel3.Tag = "3"
        Me.Panel3.Visible = False
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.ForeColor = System.Drawing.Color.DimGray
        Me.lblDesciption.Location = New System.Drawing.Point(5, 15)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(116, 13)
        Me.lblDesciption.TabIndex = 54
        Me.lblDesciption.Text = "Add all leave types"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(656, 2)
        Me.Label13.TabIndex = 53
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.Transparent
        Me.cmdClose.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.Color.White
        Me.cmdClose.Location = New System.Drawing.Point(560, 9)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(88, 26)
        Me.cmdClose.TabIndex = 16
        Me.cmdClose.Tag = "1"
        Me.cmdClose.Text = "C&lose"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(372, 9)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(88, 26)
        Me.cmdSave.TabIndex = 14
        Me.cmdSave.Tag = "1"
        Me.cmdSave.Text = "S&ave"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.Color.White
        Me.cmdRefresh.Location = New System.Drawing.Point(466, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(88, 26)
        Me.cmdRefresh.TabIndex = 15
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.Text = "R&efresh"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(389, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(357, 2)
        Me.Label17.TabIndex = 110
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(276, 4)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 13)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "Leave Type List"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtShortCod
        '
        Me.txtShortCod.BackColor = System.Drawing.Color.White
        Me.txtShortCod.Location = New System.Drawing.Point(143, 22)
        Me.txtShortCod.MaxLength = 4
        Me.txtShortCod.Name = "txtShortCod"
        Me.txtShortCod.Size = New System.Drawing.Size(127, 21)
        Me.txtShortCod.TabIndex = 26
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(140, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Short Code"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dsgID, Me.shortCode, Me.dsgName, Me.st})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(278, 23)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(378, 378)
        Me.dgvData.TabIndex = 14
        Me.dgvData.Tag = "1"
        '
        'dsgID
        '
        Me.dsgID.HeaderText = "Type ID "
        Me.dsgID.Name = "dsgID"
        Me.dsgID.ReadOnly = True
        Me.dsgID.Visible = False
        Me.dsgID.Width = 77
        '
        'shortCode
        '
        Me.shortCode.HeaderText = "Short Code"
        Me.shortCode.Name = "shortCode"
        Me.shortCode.ReadOnly = True
        Me.shortCode.Width = 102
        '
        'dsgName
        '
        Me.dsgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dsgName.HeaderText = "Description"
        Me.dsgName.Name = "dsgName"
        Me.dsgName.ReadOnly = True
        '
        'st
        '
        Me.st.HeaderText = "status"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        Me.st.Visible = False
        Me.st.Width = 66
        '
        'cmbUpdateNextYear
        '
        Me.cmbUpdateNextYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUpdateNextYear.FormattingEnabled = True
        Me.cmbUpdateNextYear.Location = New System.Drawing.Point(8, 340)
        Me.cmbUpdateNextYear.Name = "cmbUpdateNextYear"
        Me.cmbUpdateNextYear.Size = New System.Drawing.Size(262, 21)
        Me.cmbUpdateNextYear.TabIndex = 16
        '
        'cmbAlowFutureLv
        '
        Me.cmbAlowFutureLv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlowFutureLv.FormattingEnabled = True
        Me.cmbAlowFutureLv.Location = New System.Drawing.Point(8, 300)
        Me.cmbAlowFutureLv.Name = "cmbAlowFutureLv"
        Me.cmbAlowFutureLv.Size = New System.Drawing.Size(262, 21)
        Me.cmbAlowFutureLv.TabIndex = 16
        '
        'cmbOthLv
        '
        Me.cmbOthLv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOthLv.FormattingEnabled = True
        Me.cmbOthLv.Location = New System.Drawing.Point(8, 220)
        Me.cmbOthLv.Name = "cmbOthLv"
        Me.cmbOthLv.Size = New System.Drawing.Size(262, 21)
        Me.cmbOthLv.TabIndex = 16
        '
        'cmbChkLateEarly
        '
        Me.cmbChkLateEarly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChkLateEarly.FormattingEnabled = True
        Me.cmbChkLateEarly.Location = New System.Drawing.Point(8, 260)
        Me.cmbChkLateEarly.Name = "cmbChkLateEarly"
        Me.cmbChkLateEarly.Size = New System.Drawing.Size(129, 21)
        Me.cmbChkLateEarly.TabIndex = 16
        '
        'cmbChkLimit
        '
        Me.cmbChkLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbChkLimit.FormattingEnabled = True
        Me.cmbChkLimit.Location = New System.Drawing.Point(8, 182)
        Me.cmbChkLimit.Name = "cmbChkLimit"
        Me.cmbChkLimit.Size = New System.Drawing.Size(262, 21)
        Me.cmbChkLimit.TabIndex = 16
        '
        'cmbEffNos
        '
        Me.cmbEffNos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEffNos.FormattingEnabled = True
        Me.cmbEffNos.Location = New System.Drawing.Point(8, 142)
        Me.cmbEffNos.Name = "cmbEffNos"
        Me.cmbEffNos.Size = New System.Drawing.Size(262, 21)
        Me.cmbEffNos.TabIndex = 16
        '
        'cmbLvMode
        '
        Me.cmbLvMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLvMode.FormattingEnabled = True
        Me.cmbLvMode.Location = New System.Drawing.Point(8, 101)
        Me.cmbLvMode.Name = "cmbLvMode"
        Me.cmbLvMode.Size = New System.Drawing.Size(262, 21)
        Me.cmbLvMode.TabIndex = 16
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.BackColor = System.Drawing.Color.Transparent
        Me.chkStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.ForeColor = System.Drawing.Color.Black
        Me.chkStatus.Location = New System.Drawing.Point(8, 365)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(80, 17)
        Me.chkStatus.TabIndex = 15
        Me.chkStatus.Text = "Removed"
        Me.chkStatus.UseVisualStyleBackColor = False
        '
        'txtMaxLate
        '
        Me.txtMaxLate.BackColor = System.Drawing.Color.White
        Me.txtMaxLate.Location = New System.Drawing.Point(143, 260)
        Me.txtMaxLate.MaxLength = 40
        Me.txtMaxLate.Name = "txtMaxLate"
        Me.txtMaxLate.Size = New System.Drawing.Size(127, 21)
        Me.txtMaxLate.TabIndex = 12
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.Color.White
        Me.txtDesc.Location = New System.Drawing.Point(8, 62)
        Me.txtDesc.MaxLength = 40
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(262, 21)
        Me.txtDesc.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Update Balance to Next Year in Year End"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 284)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Allow to Apply Future Leave"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(191, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Allow Other Leave in Same day "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 244)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Check Late or Early"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.Location = New System.Drawing.Point(8, 22)
        Me.txtCode.MaxLength = 3
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(129, 21)
        Me.txtCode.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Check Leave Limit "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Effect Attendace Nos "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(140, 244)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(123, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Max Late / Early Min"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Leave Effecting Mode "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Leave Name "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Type ID "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(656, 48)
        Me.Panel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(581, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 57
        Me.Button2.Tag = "3"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(617, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 58
        Me.Button3.Tag = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(61, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(132, 14)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Setup Leave Types"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(279, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel2)
        Me.pnlAllk.Controls.Add(Me.Panel1)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(658, 512)
        Me.pnlAllk.TabIndex = 43
        '
        'frmSetLeaveType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(658, 512)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSetLeaveType"
        Me.Text = "Leave Types...."
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEffNos As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLvMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbChkLimit As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbOthLv As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmbAlowFutureLv As System.Windows.Forms.ComboBox
    Friend WithEvents cmbChkLateEarly As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMaxLate As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtShortCod As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dsgID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shortCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dsgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmbUpdateNextYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
