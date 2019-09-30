<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWeekShdl
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
        Me.dtpRegDate = New System.Windows.Forms.DateTimePicker
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dgvInfo = New System.Windows.Forms.DataGridView
        Me.dayID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmbWorkDes = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.shID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shortName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkStatus = New System.Windows.Forms.CheckBox
        Me.txtsName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDesc = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.dtpRegDate)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 48)
        Me.Panel1.TabIndex = 0
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
        Me.cmdSave.Location = New System.Drawing.Point(628, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 46
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
        Me.cmdRefresh.Location = New System.Drawing.Point(664, 10)
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
        Me.PictureBox1.Location = New System.Drawing.Point(9, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'dtpRegDate
        '
        Me.dtpRegDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRegDate.Location = New System.Drawing.Point(336, 14)
        Me.dtpRegDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpRegDate.Name = "dtpRegDate"
        Me.dtpRegDate.Size = New System.Drawing.Size(80, 21)
        Me.dtpRegDate.TabIndex = 18
        Me.dtpRegDate.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(70, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(190, 18)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "Setup Calendar Profile"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.dgvInfo)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(697, 395)
        Me.Panel2.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(502, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(190, 2)
        Me.Label17.TabIndex = 118
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(334, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(165, 13)
        Me.Label12.TabIndex = 117
        Me.Label12.Text = "Work Type of Each Days"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvInfo
        '
        Me.dgvInfo.AllowUserToAddRows = False
        Me.dgvInfo.BackgroundColor = System.Drawing.Color.White
        Me.dgvInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dayID, Me.DayName, Me.ShiftID, Me.ShiftName, Me.WorkID, Me.cmbWorkDes})
        Me.dgvInfo.GridColor = System.Drawing.Color.White
        Me.dgvInfo.Location = New System.Drawing.Point(336, 28)
        Me.dgvInfo.Name = "dgvInfo"
        Me.dgvInfo.RowHeadersVisible = False
        Me.dgvInfo.RowHeadersWidth = 12
        Me.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInfo.Size = New System.Drawing.Size(362, 262)
        Me.dgvInfo.TabIndex = 17
        Me.dgvInfo.Tag = "1"
        '
        'dayID
        '
        Me.dayID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dayID.HeaderText = "DayID"
        Me.dayID.Name = "dayID"
        Me.dayID.ReadOnly = True
        Me.dayID.Visible = False
        '
        'DayName
        '
        Me.DayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DayName.HeaderText = "Day Name"
        Me.DayName.Name = "DayName"
        Me.DayName.ReadOnly = True
        Me.DayName.Width = 92
        '
        'ShiftID
        '
        Me.ShiftID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ShiftID.HeaderText = "ShiftID"
        Me.ShiftID.Name = "ShiftID"
        Me.ShiftID.ReadOnly = True
        Me.ShiftID.Visible = False
        '
        'ShiftName
        '
        Me.ShiftName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ShiftName.HeaderText = "ShiftName"
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.ReadOnly = True
        Me.ShiftName.Visible = False
        '
        'WorkID
        '
        Me.WorkID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.WorkID.HeaderText = "Work ID"
        Me.WorkID.Name = "WorkID"
        Me.WorkID.ReadOnly = True
        Me.WorkID.Visible = False
        '
        'cmbWorkDes
        '
        Me.cmbWorkDes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cmbWorkDes.HeaderText = "Work Type"
        Me.cmbWorkDes.Name = "cmbWorkDes"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblDesciption)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 351)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(697, 44)
        Me.Panel3.TabIndex = 19
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.ForeColor = System.Drawing.Color.DimGray
        Me.lblDesciption.Location = New System.Drawing.Point(8, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(174, 13)
        Me.lblDesciption.TabIndex = 58
        Me.lblDesciption.Text = "Add all calendar profile types"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(697, 2)
        Me.Label11.TabIndex = 26
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvData)
        Me.GroupBox1.Controls.Add(Me.chkStatus)
        Me.GroupBox1.Controls.Add(Me.txtsName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDesc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 284)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Schedule Name"
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.shID, Me.shortName, Me.description})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(2, 117)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(310, 161)
        Me.dgvData.TabIndex = 17
        Me.dgvData.Tag = "1"
        '
        'shID
        '
        Me.shID.HeaderText = "ID"
        Me.shID.Name = "shID"
        Me.shID.ReadOnly = True
        Me.shID.Visible = False
        '
        'shortName
        '
        Me.shortName.HeaderText = "Short Name"
        Me.shortName.Name = "shortName"
        Me.shortName.ReadOnly = True
        '
        'description
        '
        Me.description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.description.HeaderText = "Descrption"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.Location = New System.Drawing.Point(110, 97)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(80, 17)
        Me.chkStatus.TabIndex = 16
        Me.chkStatus.Text = "Removed"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'txtsName
        '
        Me.txtsName.BackColor = System.Drawing.Color.White
        Me.txtsName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsName.Location = New System.Drawing.Point(110, 45)
        Me.txtsName.MaxLength = 3
        Me.txtsName.Name = "txtsName"
        Me.txtsName.Size = New System.Drawing.Size(81, 21)
        Me.txtsName.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Short Name "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDesc
        '
        Me.txtDesc.BackColor = System.Drawing.Color.White
        Me.txtDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(110, 71)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(169, 21)
        Me.txtDesc.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 23)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Effect From |"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Description "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(110, 19)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(80, 21)
        Me.txtCode.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Shedule ID "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel2)
        Me.pnlAllk.Controls.Add(Me.Panel1)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(699, 445)
        Me.pnlAllk.TabIndex = 77
        '
        'frmWeekShdl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(699, 445)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmWeekShdl"
        Me.Text = "SET CALENDAR PROFILE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents dgvInfo As System.Windows.Forms.DataGridView
    Friend WithEvents txtsName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpRegDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dayID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbWorkDes As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents shID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shortName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
