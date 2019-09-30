<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpRelationInfo
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
        Me.pnlAll = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.chkEmergency = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbNo = New System.Windows.Forms.RadioButton
        Me.rdbYes = New System.Windows.Forms.RadioButton
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.cmbOccupation = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtAddres = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtRelName = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtNIC = New System.Windows.Forms.TextBox
        Me.txtMob = New System.Windows.Forms.TextBox
        Me.dtpBirth = New System.Windows.Forms.DateTimePicker
        Me.cmbRelation = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.pbRelSave = New System.Windows.Forms.PictureBox
        Me.Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.relation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dateofb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mob = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.addres = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.desig = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.remark = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlAll.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbRelSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlAll
        '
        Me.pnlAll.Controls.Add(Me.Panel2)
        Me.pnlAll.Controls.Add(Me.Panel1)
        Me.pnlAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAll.Location = New System.Drawing.Point(0, 0)
        Me.pnlAll.Name = "pnlAll"
        Me.pnlAll.Size = New System.Drawing.Size(1012, 475)
        Me.pnlAll.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkEmergency)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtRemark)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.cmbOccupation)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtAddres)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.dgvData)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.txtRelName)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.txtNIC)
        Me.Panel2.Controls.Add(Me.txtMob)
        Me.Panel2.Controls.Add(Me.dtpBirth)
        Me.Panel2.Controls.Add(Me.cmbRelation)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1012, 437)
        Me.Panel2.TabIndex = 96
        '
        'chkEmergency
        '
        Me.chkEmergency.AutoSize = True
        Me.chkEmergency.Location = New System.Drawing.Point(848, 107)
        Me.chkEmergency.Name = "chkEmergency"
        Me.chkEmergency.Size = New System.Drawing.Size(138, 17)
        Me.chkEmergency.TabIndex = 171
        Me.chkEmergency.Text = "Emergency Contact"
        Me.chkEmergency.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbNo)
        Me.GroupBox1.Controls.Add(Me.rdbYes)
        Me.GroupBox1.Location = New System.Drawing.Point(468, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 44)
        Me.GroupBox1.TabIndex = 170
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Is Occupied"
        '
        'rdbNo
        '
        Me.rdbNo.AutoSize = True
        Me.rdbNo.Location = New System.Drawing.Point(80, 18)
        Me.rdbNo.Name = "rdbNo"
        Me.rdbNo.Size = New System.Drawing.Size(40, 17)
        Me.rdbNo.TabIndex = 170
        Me.rdbNo.TabStop = True
        Me.rdbNo.Text = "No"
        Me.rdbNo.UseVisualStyleBackColor = True
        '
        'rdbYes
        '
        Me.rdbYes.AutoSize = True
        Me.rdbYes.Location = New System.Drawing.Point(10, 18)
        Me.rdbYes.Name = "rdbYes"
        Me.rdbYes.Size = New System.Drawing.Size(44, 17)
        Me.rdbYes.TabIndex = 169
        Me.rdbYes.TabStop = True
        Me.rdbYes.Text = "Yes"
        Me.rdbYes.UseVisualStyleBackColor = True
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(603, 49)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(366, 20)
        Me.txtRemark.TabIndex = 168
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(600, 33)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 13)
        Me.Label24.TabIndex = 167
        Me.Label24.Text = "Remark"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(602, 88)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(70, 13)
        Me.Label23.TabIndex = 166
        Me.Label23.Text = "Occupation"
        '
        'cmbOccupation
        '
        Me.cmbOccupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOccupation.FormattingEnabled = True
        Me.cmbOccupation.Location = New System.Drawing.Point(603, 105)
        Me.cmbOccupation.Name = "cmbOccupation"
        Me.cmbOccupation.Size = New System.Drawing.Size(222, 21)
        Me.cmbOccupation.TabIndex = 165
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(883, 4)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(119, 13)
        Me.Label21.TabIndex = 160
        Me.Label21.Text = "Emergency Contact"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkKhaki
        Me.Label22.Location = New System.Drawing.Point(865, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(16, 13)
        Me.Label22.TabIndex = 159
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Name of Relation"
        '
        'txtAddres
        '
        Me.txtAddres.Location = New System.Drawing.Point(209, 105)
        Me.txtAddres.Multiline = True
        Me.txtAddres.Name = "txtAddres"
        Me.txtAddres.Size = New System.Drawing.Size(253, 20)
        Me.txtAddres.TabIndex = 140
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(10, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 16)
        Me.Label8.TabIndex = 148
        Me.Label8.Text = "Relations Details"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(206, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Relationship"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(136, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(878, 3)
        Me.Label9.TabIndex = 147
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToResizeColumns = False
        Me.dgvData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Name, Me.relation, Me.dateofb, Me.nic, Me.mob, Me.addres, Me.desig, Me.remark})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(12, 133)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(988, 270)
        Me.dgvData.TabIndex = 139
        Me.dgvData.Tag = "1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(464, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Date of Birth"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(360, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 35
        Me.Label14.Text = "NIC Number"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(208, 88)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(53, 13)
        Me.Label32.TabIndex = 67
        Me.Label32.Text = "Address"
        '
        'txtRelName
        '
        Me.txtRelName.Location = New System.Drawing.Point(12, 50)
        Me.txtRelName.Multiline = True
        Me.txtRelName.Name = "txtRelName"
        Me.txtRelName.Size = New System.Drawing.Size(191, 20)
        Me.txtRelName.TabIndex = 36
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(9, 89)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(43, 13)
        Me.Label31.TabIndex = 66
        Me.Label31.Text = "Mobile" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtNIC
        '
        Me.txtNIC.Location = New System.Drawing.Point(363, 50)
        Me.txtNIC.Multiline = True
        Me.txtNIC.Name = "txtNIC"
        Me.txtNIC.Size = New System.Drawing.Size(99, 20)
        Me.txtNIC.TabIndex = 42
        '
        'txtMob
        '
        Me.txtMob.Location = New System.Drawing.Point(12, 105)
        Me.txtMob.MaxLength = 10
        Me.txtMob.Multiline = True
        Me.txtMob.Name = "txtMob"
        Me.txtMob.Size = New System.Drawing.Size(191, 20)
        Me.txtMob.TabIndex = 45
        Me.txtMob.Text = "1234567890"
        '
        'dtpBirth
        '
        Me.dtpBirth.CustomFormat = "dd/MMM/yyyy"
        Me.dtpBirth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBirth.Location = New System.Drawing.Point(467, 49)
        Me.dtpBirth.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpBirth.Name = "dtpBirth"
        Me.dtpBirth.Size = New System.Drawing.Size(129, 21)
        Me.dtpBirth.TabIndex = 136
        '
        'cmbRelation
        '
        Me.cmbRelation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRelation.FormattingEnabled = True
        Me.cmbRelation.Location = New System.Drawing.Point(209, 49)
        Me.cmbRelation.Name = "cmbRelation"
        Me.cmbRelation.Size = New System.Drawing.Size(148, 21)
        Me.cmbRelation.TabIndex = 138
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cmdPrevious)
        Me.Panel1.Controls.Add(Me.cmdNext)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.pbRelSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 38)
        Me.Panel1.TabIndex = 95
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(974, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 18
        Me.Button2.Tag = "3"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmdPrevious
        '
        Me.cmdPrevious.BackColor = System.Drawing.Color.Transparent
        Me.cmdPrevious.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Back
        Me.cmdPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdPrevious.FlatAppearance.BorderSize = 0
        Me.cmdPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdPrevious.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrevious.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdPrevious.Location = New System.Drawing.Point(12, 6)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(32, 26)
        Me.cmdPrevious.TabIndex = 16
        Me.cmdPrevious.Tag = "4"
        Me.cmdPrevious.UseVisualStyleBackColor = False
        Me.cmdPrevious.Visible = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.Transparent
        Me.cmdNext.BackgroundImage = Global.HRISforBB.My.Resources.Resources._next
        Me.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdNext.Location = New System.Drawing.Point(77, 6)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(32, 26)
        Me.cmdNext.TabIndex = 15
        Me.cmdNext.Tag = "4"
        Me.cmdNext.UseVisualStyleBackColor = False
        Me.cmdNext.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(445, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(123, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Family Details"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbRelSave
        '
        Me.pbRelSave.BackColor = System.Drawing.Color.Transparent
        Me.pbRelSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.pbRelSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbRelSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbRelSave.Location = New System.Drawing.Point(939, 5)
        Me.pbRelSave.Name = "pbRelSave"
        Me.pbRelSave.Size = New System.Drawing.Size(28, 28)
        Me.pbRelSave.TabIndex = 136
        Me.pbRelSave.TabStop = False
        Me.pbRelSave.Tag = "5"
        '
        'Name
        '
        Me.Name.HeaderText = "Name"
        Me.Name.Name = "Name"
        Me.Name.ReadOnly = True
        Me.Name.Width = 132
        '
        'relation
        '
        Me.relation.HeaderText = "Relationship"
        Me.relation.Name = "relation"
        Me.relation.ReadOnly = True
        Me.relation.Width = 129
        '
        'dateofb
        '
        Me.dateofb.HeaderText = "Date of Birth"
        Me.dateofb.Name = "dateofb"
        Me.dateofb.ReadOnly = True
        Me.dateofb.Width = 96
        '
        'nic
        '
        Me.nic.HeaderText = "NIC Number"
        Me.nic.Name = "nic"
        Me.nic.ReadOnly = True
        Me.nic.Width = 102
        '
        'mob
        '
        Me.mob.HeaderText = "Mobile"
        Me.mob.Name = "mob"
        Me.mob.ReadOnly = True
        Me.mob.Width = 84
        '
        'addres
        '
        Me.addres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.addres.HeaderText = "Address"
        Me.addres.Name = "addres"
        Me.addres.ReadOnly = True
        '
        'desig
        '
        Me.desig.HeaderText = "Designation"
        Me.desig.Name = "desig"
        Me.desig.ReadOnly = True
        Me.desig.Width = 125
        '
        'remark
        '
        Me.remark.HeaderText = "Remarks"
        Me.remark.Name = "remark"
        Me.remark.ReadOnly = True
        Me.remark.Width = 156
        '
        'frmEmpRelationInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 475)
        Me.Controls.Add(Me.pnlAll)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        'Me.Name = "frmEmpRelationInfo"
        Me.Text = "RelationsInfo"
        Me.pnlAll.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbRelSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlAll As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAddres As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtRelName As System.Windows.Forms.TextBox
    Friend WithEvents txtNIC As System.Windows.Forms.TextBox
    Friend WithEvents txtMob As System.Windows.Forms.TextBox
    Friend WithEvents cmbRelation As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents pbRelSave As System.Windows.Forms.PictureBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmbOccupation As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbYes As System.Windows.Forms.RadioButton
    Friend WithEvents chkEmergency As System.Windows.Forms.CheckBox
    Friend WithEvents rdbNo As System.Windows.Forms.RadioButton
    Friend WithEvents Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents relation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateofb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mob As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents addres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents desig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
