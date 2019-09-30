<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigLeaveProf
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
        Me.btnDelete = New System.Windows.Forms.Button
        Me.dgvCopy = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cmdPrcCopy = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.chkMStatus = New System.Windows.Forms.CheckBox
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.dsgID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dsgName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpCat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StartM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EndM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EntQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtStart = New System.Windows.Forms.TextBox
        Me.cmbEffMeth = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEntQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEnd = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.chkStatus = New System.Windows.Forms.CheckBox
        Me.dgvMMData = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpType1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtLvQty = New System.Windows.Forms.TextBox
        Me.cmbEntLeave = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbEndMonth = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbStartMonth = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbLeaveType = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbcategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.lblRowCoun = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvMMData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.dgvCopy)
        Me.Panel1.Controls.Add(Me.cmdPrcCopy)
        Me.Panel1.Controls.Add(Me.cmdCopy)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.cmbLeaveType)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cmbType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbcategory)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(782, 396)
        Me.Panel1.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Orange
        Me.btnDelete.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Delete
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Location = New System.Drawing.Point(737, 362)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(33, 28)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Tag = "3"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'dgvCopy
        '
        Me.dgvCopy.AllowUserToAddRows = False
        Me.dgvCopy.AllowUserToDeleteRows = False
        Me.dgvCopy.BackgroundColor = System.Drawing.Color.White
        Me.dgvCopy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCopy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCopy.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn15})
        Me.dgvCopy.GridColor = System.Drawing.Color.White
        Me.dgvCopy.Location = New System.Drawing.Point(8, 196)
        Me.dgvCopy.Name = "dgvCopy"
        Me.dgvCopy.RowHeadersVisible = False
        Me.dgvCopy.RowHeadersWidth = 12
        Me.dgvCopy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCopy.Size = New System.Drawing.Size(210, 140)
        Me.dgvCopy.TabIndex = 154
        Me.dgvCopy.Tag = "1"
        Me.dgvCopy.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn8.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.HeaderText = "Category"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn15.HeaderText = "[X]"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn15.Width = 50
        '
        'cmdPrcCopy
        '
        Me.cmdPrcCopy.Location = New System.Drawing.Point(6, 342)
        Me.cmdPrcCopy.Name = "cmdPrcCopy"
        Me.cmdPrcCopy.Size = New System.Drawing.Size(212, 23)
        Me.cmdPrcCopy.TabIndex = 153
        Me.cmdPrcCopy.Text = "Copy"
        Me.cmdPrcCopy.UseVisualStyleBackColor = True
        Me.cmdPrcCopy.Visible = False
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(6, 167)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(212, 23)
        Me.cmdCopy.TabIndex = 153
        Me.cmdCopy.Text = "Copy to Following Categories"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(237, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(533, 343)
        Me.TabControl1.TabIndex = 152
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkMStatus)
        Me.TabPage1.Controls.Add(Me.dgvData)
        Me.TabPage1.Controls.Add(Me.txtStart)
        Me.TabPage1.Controls.Add(Me.cmbEffMeth)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtEntQty)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtEnd)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(525, 317)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Monthly Base Leave Configuration"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkMStatus
        '
        Me.chkMStatus.AutoSize = True
        Me.chkMStatus.Location = New System.Drawing.Point(208, 120)
        Me.chkMStatus.Name = "chkMStatus"
        Me.chkMStatus.Size = New System.Drawing.Size(72, 17)
        Me.chkMStatus.TabIndex = 152
        Me.chkMStatus.Text = "Inactive"
        Me.chkMStatus.UseVisualStyleBackColor = True
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dsgID, Me.dsgName, Me.EmpCat, Me.EmpType, Me.StartM, Me.EndM, Me.EntQty, Me.st})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(6, 163)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(513, 140)
        Me.dgvData.TabIndex = 151
        Me.dgvData.Tag = "1"
        '
        'dsgID
        '
        Me.dsgID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dsgID.HeaderText = "ID"
        Me.dsgID.Name = "dsgID"
        Me.dsgID.ReadOnly = True
        Me.dsgID.Width = 46
        '
        'dsgName
        '
        Me.dsgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.dsgName.HeaderText = "Description"
        Me.dsgName.Name = "dsgName"
        Me.dsgName.ReadOnly = True
        '
        'EmpCat
        '
        Me.EmpCat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpCat.HeaderText = "Category"
        Me.EmpCat.Name = "EmpCat"
        Me.EmpCat.ReadOnly = True
        Me.EmpCat.Width = 85
        '
        'EmpType
        '
        Me.EmpType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpType.HeaderText = "Type"
        Me.EmpType.Name = "EmpType"
        Me.EmpType.ReadOnly = True
        Me.EmpType.Width = 59
        '
        'StartM
        '
        Me.StartM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StartM.HeaderText = "Start"
        Me.StartM.Name = "StartM"
        Me.StartM.ReadOnly = True
        Me.StartM.Width = 60
        '
        'EndM
        '
        Me.EndM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EndM.HeaderText = "End"
        Me.EndM.Name = "EndM"
        Me.EndM.ReadOnly = True
        Me.EndM.Width = 53
        '
        'EntQty
        '
        Me.EntQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EntQty.HeaderText = "Entitlement"
        Me.EntQty.Name = "EntQty"
        Me.EntQty.ReadOnly = True
        Me.EntQty.Width = 96
        '
        'st
        '
        Me.st.HeaderText = "status"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        Me.st.Visible = False
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(208, 12)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(199, 21)
        Me.txtStart.TabIndex = 148
        '
        'cmbEffMeth
        '
        Me.cmbEffMeth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEffMeth.FormattingEnabled = True
        Me.cmbEffMeth.Location = New System.Drawing.Point(208, 93)
        Me.cmbEffMeth.Name = "cmbEffMeth"
        Me.cmbEffMeth.Size = New System.Drawing.Size(199, 21)
        Me.cmbEffMeth.TabIndex = 145
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(80, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "Entitle Leave Qty"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(80, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Entitlement Method"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "Start Month(s)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEntQty
        '
        Me.txtEntQty.Location = New System.Drawing.Point(208, 66)
        Me.txtEntQty.Name = "txtEntQty"
        Me.txtEntQty.Size = New System.Drawing.Size(199, 21)
        Me.txtEntQty.TabIndex = 148
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Ending Month(s)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(208, 39)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(199, 21)
        Me.txtEnd.TabIndex = 148
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkStatus)
        Me.TabPage2.Controls.Add(Me.dgvMMData)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.txtLvQty)
        Me.TabPage2.Controls.Add(Me.cmbEntLeave)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.cmbEndMonth)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.cmbStartMonth)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(525, 317)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Quater Based Leave Configuration"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Location = New System.Drawing.Point(217, 124)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(72, 17)
        Me.chkStatus.TabIndex = 153
        Me.chkStatus.Text = "Inactive"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'dgvMMData
        '
        Me.dgvMMData.AllowUserToAddRows = False
        Me.dgvMMData.BackgroundColor = System.Drawing.Color.White
        Me.dgvMMData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMMData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMMData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.EmpType1, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dgvMMData.GridColor = System.Drawing.Color.White
        Me.dgvMMData.Location = New System.Drawing.Point(6, 171)
        Me.dgvMMData.Name = "dgvMMData"
        Me.dgvMMData.ReadOnly = True
        Me.dgvMMData.RowHeadersVisible = False
        Me.dgvMMData.RowHeadersWidth = 12
        Me.dgvMMData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMMData.Size = New System.Drawing.Size(513, 140)
        Me.dgvMMData.TabIndex = 152
        Me.dgvMMData.Tag = "1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 46
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.HeaderText = "Category"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 85
        '
        'EmpType1
        '
        Me.EmpType1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpType1.HeaderText = "Type"
        Me.EmpType1.Name = "EmpType1"
        Me.EmpType1.ReadOnly = True
        Me.EmpType1.Width = 59
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Start"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 60
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.HeaderText = "End"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 53
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.HeaderText = "Entitlement"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 96
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "status"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(89, 101)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 13)
        Me.Label11.TabIndex = 151
        Me.Label11.Text = "Entitle Leave Qty"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLvQty
        '
        Me.txtLvQty.Location = New System.Drawing.Point(217, 97)
        Me.txtLvQty.Name = "txtLvQty"
        Me.txtLvQty.Size = New System.Drawing.Size(199, 21)
        Me.txtLvQty.TabIndex = 150
        '
        'cmbEntLeave
        '
        Me.cmbEntLeave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEntLeave.FormattingEnabled = True
        Me.cmbEntLeave.Location = New System.Drawing.Point(217, 70)
        Me.cmbEntLeave.Name = "cmbEntLeave"
        Me.cmbEntLeave.Size = New System.Drawing.Size(199, 21)
        Me.cmbEntLeave.TabIndex = 147
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(89, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 13)
        Me.Label10.TabIndex = 146
        Me.Label10.Text = "Entitlement Method"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbEndMonth
        '
        Me.cmbEndMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndMonth.FormattingEnabled = True
        Me.cmbEndMonth.Location = New System.Drawing.Point(217, 43)
        Me.cmbEndMonth.Name = "cmbEndMonth"
        Me.cmbEndMonth.Size = New System.Drawing.Size(199, 21)
        Me.cmbEndMonth.TabIndex = 147
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(89, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 146
        Me.Label9.Text = "End Month"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbStartMonth
        '
        Me.cmbStartMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartMonth.FormattingEnabled = True
        Me.cmbStartMonth.Location = New System.Drawing.Point(217, 16)
        Me.cmbStartMonth.Name = "cmbStartMonth"
        Me.cmbStartMonth.Size = New System.Drawing.Size(199, 21)
        Me.cmbStartMonth.TabIndex = 147
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 146
        Me.Label4.Text = "Start Month"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLeaveType
        '
        Me.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLeaveType.FormattingEnabled = True
        Me.cmbLeaveType.Location = New System.Drawing.Point(9, 135)
        Me.cmbLeaveType.Name = "cmbLeaveType"
        Me.cmbLeaveType.Size = New System.Drawing.Size(209, 21)
        Me.cmbLeaveType.TabIndex = 145
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Leave Type"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(9, 94)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(209, 21)
        Me.cmbType.TabIndex = 145
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Employee Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbcategory
        '
        Me.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(9, 54)
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(209, 21)
        Me.cmbcategory.TabIndex = 145
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Employee Category"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.cmdSave)
        Me.pnlTop.Controls.Add(Me.cmdRefresh)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.Label25)
        Me.pnlTop.Controls.Add(Me.lblRowCoun)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(782, 48)
        Me.pnlTop.TabIndex = 7
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
        Me.cmdSave.Location = New System.Drawing.Point(695, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(33, 28)
        Me.cmdSave.TabIndex = 0
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
        Me.cmdRefresh.Location = New System.Drawing.Point(737, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(33, 28)
        Me.cmdRefresh.TabIndex = 1
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(57, 47)
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(63, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(141, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Leave Configure"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRowCoun
        '
        Me.lblRowCoun.AutoSize = True
        Me.lblRowCoun.ForeColor = System.Drawing.Color.White
        Me.lblRowCoun.Location = New System.Drawing.Point(547, 88)
        Me.lblRowCoun.Name = "lblRowCoun"
        Me.lblRowCoun.Size = New System.Drawing.Size(0, 13)
        Me.lblRowCoun.TabIndex = 33
        '
        'frmConfigLeaveProf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(782, 444)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConfigLeaveProf"
        Me.Text = "frmConfigLeaveProf"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvCopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvMMData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents lblRowCoun As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbcategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtEntQty As System.Windows.Forms.TextBox
    Friend WithEvents cmbEffMeth As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents cmbLeaveType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents cmbEntLeave As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbEndMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbStartMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvMMData As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtLvQty As System.Windows.Forms.TextBox
    Friend WithEvents dsgID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dsgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpCat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpType1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkMStatus As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents dgvCopy As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmdPrcCopy As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnDelete As System.Windows.Forms.Button
End Class
