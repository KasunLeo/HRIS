<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeaveImport
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
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.lblRowCoun = New System.Windows.Forms.Label
        Me.cmbDesig = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbCat = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbDept = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dgvEmployee = New System.Windows.Forms.DataGridView
        Me.EmpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EpfNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pick = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.catID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pgb = New System.Windows.Forms.ProgressBar
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.lblYear = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlData = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlAlldat = New System.Windows.Forms.Panel
        Me.txtMaxShLvPrMonth = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtShLvMinPerMnth = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.pnlData.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAlldat.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pnlTop.Size = New System.Drawing.Size(687, 48)
        Me.pnlTop.TabIndex = 5
        Me.pnlTop.Tag = "1"
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.procesKasun
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdSave.Location = New System.Drawing.Point(612, 10)
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
        Me.cmdRefresh.Location = New System.Drawing.Point(648, 10)
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
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(61, 14)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(146, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Leave Generator"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRowCoun
        '
        Me.lblRowCoun.AutoSize = True
        Me.lblRowCoun.ForeColor = System.Drawing.Color.White
        Me.lblRowCoun.Location = New System.Drawing.Point(469, 88)
        Me.lblRowCoun.Name = "lblRowCoun"
        Me.lblRowCoun.Size = New System.Drawing.Size(0, 13)
        Me.lblRowCoun.TabIndex = 33
        '
        'cmbDesig
        '
        Me.cmbDesig.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDesig.FormattingEnabled = True
        Me.cmbDesig.Location = New System.Drawing.Point(8, 106)
        Me.cmbDesig.Name = "cmbDesig"
        Me.cmbDesig.Size = New System.Drawing.Size(238, 21)
        Me.cmbDesig.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Designation "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCat
        '
        Me.cmbCat.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCat.FormattingEnabled = True
        Me.cmbCat.Location = New System.Drawing.Point(8, 69)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(238, 21)
        Me.cmbCat.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Category "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDept
        '
        Me.cmbDept.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDept.FormattingEnabled = True
        Me.cmbDept.Location = New System.Drawing.Point(8, 29)
        Me.cmbDept.Name = "cmbDept"
        Me.cmbDept.Size = New System.Drawing.Size(238, 21)
        Me.cmbDept.TabIndex = 27
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(79, 13)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "Department "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvEmployee
        '
        Me.dgvEmployee.AllowUserToAddRows = False
        Me.dgvEmployee.BackgroundColor = System.Drawing.Color.White
        Me.dgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmployee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EmpID, Me.EpfNo, Me.EmpName, Me.Pick, Me.catID})
        Me.dgvEmployee.GridColor = System.Drawing.Color.White
        Me.dgvEmployee.Location = New System.Drawing.Point(252, 28)
        Me.dgvEmployee.Name = "dgvEmployee"
        Me.dgvEmployee.RowHeadersVisible = False
        Me.dgvEmployee.RowHeadersWidth = 12
        Me.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmployee.Size = New System.Drawing.Size(434, 236)
        Me.dgvEmployee.TabIndex = 29
        Me.dgvEmployee.Tag = "1"
        '
        'EmpID
        '
        Me.EmpID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EmpID.HeaderText = "Employee ID"
        Me.EmpID.Name = "EmpID"
        Me.EmpID.ReadOnly = True
        Me.EmpID.Visible = False
        '
        'EpfNo
        '
        Me.EpfNo.HeaderText = "E.P.F. No"
        Me.EpfNo.Name = "EpfNo"
        Me.EpfNo.ReadOnly = True
        Me.EpfNo.Width = 88
        '
        'EmpName
        '
        Me.EmpName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.EmpName.HeaderText = "Employee Name"
        Me.EmpName.Name = "EmpName"
        Me.EmpName.ReadOnly = True
        '
        'Pick
        '
        Me.Pick.HeaderText = "  "
        Me.Pick.Name = "Pick"
        Me.Pick.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Pick.Width = 24
        '
        'catID
        '
        Me.catID.HeaderText = "CatID"
        Me.catID.Name = "catID"
        Me.catID.ReadOnly = True
        Me.catID.Visible = False
        '
        'pgb
        '
        Me.pgb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgb.Location = New System.Drawing.Point(0, 277)
        Me.pgb.Name = "pgb"
        Me.pgb.Size = New System.Drawing.Size(687, 6)
        Me.pgb.TabIndex = 30
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(668, 32)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(15, 14)
        Me.chkAll.TabIndex = 31
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(687, 2)
        Me.Label17.TabIndex = 32
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.lblYear)
        Me.pnlBottom.Controls.Add(Me.lblDescription)
        Me.pnlBottom.Controls.Add(Me.Label17)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 283)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(687, 44)
        Me.pnlBottom.TabIndex = 34
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.ForeColor = System.Drawing.Color.DimGray
        Me.lblYear.Location = New System.Drawing.Point(644, 16)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 34
        Me.lblYear.Text = "Year"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.ForeColor = System.Drawing.Color.DimGray
        Me.lblDescription.Location = New System.Drawing.Point(6, 16)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(359, 13)
        Me.lblDescription.TabIndex = 33
        Me.lblDescription.Text = "Generate employee(s) leaves for the year based on category"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(346, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 2)
        Me.Label2.TabIndex = 116
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(250, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Employee List"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlData
        '
        Me.pnlData.Controls.Add(Me.Panel1)
        Me.pnlData.Controls.Add(Me.pnlBottom)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlData.Location = New System.Drawing.Point(0, 48)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(687, 327)
        Me.pnlData.TabIndex = 117
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtMaxShLvPrMonth)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtShLvMinPerMnth)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbCat)
        Me.Panel1.Controls.Add(Me.chkAll)
        Me.Panel1.Controls.Add(Me.cmbDesig)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.pgb)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbDept)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.dgvEmployee)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(687, 283)
        Me.Panel1.TabIndex = 35
        '
        'pnlAlldat
        '
        Me.pnlAlldat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAlldat.Controls.Add(Me.pnlData)
        Me.pnlAlldat.Controls.Add(Me.pnlTop)
        Me.pnlAlldat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlldat.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlldat.Name = "pnlAlldat"
        Me.pnlAlldat.Size = New System.Drawing.Size(689, 377)
        Me.pnlAlldat.TabIndex = 44
        '
        'txtMaxShLvPrMonth
        '
        Me.txtMaxShLvPrMonth.Enabled = False
        Me.txtMaxShLvPrMonth.Location = New System.Drawing.Point(8, 245)
        Me.txtMaxShLvPrMonth.Name = "txtMaxShLvPrMonth"
        Me.txtMaxShLvPrMonth.Size = New System.Drawing.Size(236, 21)
        Me.txtMaxShLvPrMonth.TabIndex = 120
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(201, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Maximum No of Leaves per Month"
        '
        'txtShLvMinPerMnth
        '
        Me.txtShLvMinPerMnth.Enabled = False
        Me.txtShLvMinPerMnth.Location = New System.Drawing.Point(8, 202)
        Me.txtShLvMinPerMnth.Name = "txtShLvMinPerMnth"
        Me.txtShLvMinPerMnth.Size = New System.Drawing.Size(234, 21)
        Me.txtShLvMinPerMnth.TabIndex = 118
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 186)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(215, 13)
        Me.Label23.TabIndex = 117
        Me.Label23.Text = "Total Short Leave Minutes per Month"
        '
        'frmLeaveImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(689, 377)
        Me.Controls.Add(Me.pnlAlldat)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLeaveImport"
        Me.Text = "frmLeaveImport"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.pnlData.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAlldat.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbDesig As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvEmployee As System.Windows.Forms.DataGridView
    Friend WithEvents pgb As System.Windows.Forms.ProgressBar
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblRowCoun As System.Windows.Forms.Label
    Friend WithEvents EmpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EpfNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pick As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents catID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlAlldat As System.Windows.Forms.Panel
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents txtMaxShLvPrMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtShLvMinPerMnth As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
End Class
