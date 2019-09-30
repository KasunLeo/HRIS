<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetAttnParam
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.chkRemoved = New System.Windows.Forms.CheckBox
        Me.desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.civilSt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fldNam = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtfldName = New System.Windows.Forms.TextBox
        Me.chkVisibleInRep = New System.Windows.Forms.CheckBox
        Me.PnlBottom = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.pnlDATA = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBottom.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.pnlDATA.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(644, 2)
        Me.Label4.TabIndex = 34
        '
        'chkRemoved
        '
        Me.chkRemoved.AutoSize = True
        Me.chkRemoved.BackColor = System.Drawing.Color.Transparent
        Me.chkRemoved.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemoved.ForeColor = System.Drawing.Color.Black
        Me.chkRemoved.Location = New System.Drawing.Point(10, 155)
        Me.chkRemoved.Name = "chkRemoved"
        Me.chkRemoved.Size = New System.Drawing.Size(80, 17)
        Me.chkRemoved.TabIndex = 25
        Me.chkRemoved.Text = "Removed"
        Me.chkRemoved.UseVisualStyleBackColor = False
        '
        'desc
        '
        Me.desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.desc.HeaderText = "Description"
        Me.desc.Name = "desc"
        Me.desc.ReadOnly = True
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.civilSt, Me.desc, Me.fldNam})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(234, 25)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.Size = New System.Drawing.Size(409, 296)
        Me.dgvData.TabIndex = 29
        Me.dgvData.Tag = "1"
        '
        'civilSt
        '
        Me.civilSt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.civilSt.HeaderText = "ID"
        Me.civilSt.Name = "civilSt"
        Me.civilSt.ReadOnly = True
        Me.civilSt.Width = 46
        '
        'fldNam
        '
        Me.fldNam.HeaderText = "Field Name"
        Me.fldNam.Name = "fldNam"
        Me.fldNam.ReadOnly = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(9, 65)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(218, 21)
        Me.txtName.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Description "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.Color.White
        Me.txtID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.Location = New System.Drawing.Point(9, 25)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(81, 21)
        Me.txtID.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.cmdSave)
        Me.pnlTop.Controls.Add(Me.cmdRefresh)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.Label25)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(644, 48)
        Me.pnlTop.TabIndex = 28
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
        Me.cmdSave.Location = New System.Drawing.Point(569, 10)
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
        Me.cmdRefresh.Location = New System.Drawing.Point(605, 10)
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
        Me.PictureBox1.Location = New System.Drawing.Point(5, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(60, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(257, 18)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Setup Attendance Parameters"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Feild Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtfldName
        '
        Me.txtfldName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfldName.Location = New System.Drawing.Point(9, 105)
        Me.txtfldName.Name = "txtfldName"
        Me.txtfldName.Size = New System.Drawing.Size(218, 21)
        Me.txtfldName.TabIndex = 24
        '
        'chkVisibleInRep
        '
        Me.chkVisibleInRep.AutoSize = True
        Me.chkVisibleInRep.BackColor = System.Drawing.Color.Transparent
        Me.chkVisibleInRep.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVisibleInRep.ForeColor = System.Drawing.Color.Black
        Me.chkVisibleInRep.Location = New System.Drawing.Point(10, 132)
        Me.chkVisibleInRep.Name = "chkVisibleInRep"
        Me.chkVisibleInRep.Size = New System.Drawing.Size(121, 17)
        Me.chkVisibleInRep.TabIndex = 25
        Me.chkVisibleInRep.Text = "Visible In Report"
        Me.chkVisibleInRep.UseVisualStyleBackColor = False
        '
        'PnlBottom
        '
        Me.PnlBottom.Controls.Add(Me.lblDesciption)
        Me.PnlBottom.Controls.Add(Me.Label4)
        Me.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlBottom.Location = New System.Drawing.Point(0, 327)
        Me.PnlBottom.Name = "PnlBottom"
        Me.PnlBottom.Size = New System.Drawing.Size(644, 44)
        Me.PnlBottom.TabIndex = 35
        Me.PnlBottom.Tag = "1"
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.Location = New System.Drawing.Point(8, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(205, 13)
        Me.lblDesciption.TabIndex = 55
        Me.lblDesciption.Text = "Add all attendance summary fields"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(365, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(274, 2)
        Me.Label17.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(234, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Summary Field List"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.pnlDATA)
        Me.pnlAllk.Controls.Add(Me.pnlTop)
        Me.pnlAllk.Controls.Add(Me.Label5)
        Me.pnlAllk.Controls.Add(Me.Label17)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(646, 421)
        Me.pnlAllk.TabIndex = 111
        '
        'pnlDATA
        '
        Me.pnlDATA.Controls.Add(Me.Panel1)
        Me.pnlDATA.Controls.Add(Me.PnlBottom)
        Me.pnlDATA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDATA.Location = New System.Drawing.Point(0, 48)
        Me.pnlDATA.Name = "pnlDATA"
        Me.pnlDATA.Size = New System.Drawing.Size(644, 371)
        Me.pnlDATA.TabIndex = 111
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtfldName)
        Me.Panel1.Controls.Add(Me.chkRemoved)
        Me.Panel1.Controls.Add(Me.chkVisibleInRep)
        Me.Panel1.Controls.Add(Me.dgvData)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 327)
        Me.Panel1.TabIndex = 36
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Location = New System.Drawing.Point(347, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(289, 2)
        Me.Label6.TabIndex = 110
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(231, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 13)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Parameters List"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSetAttnParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(646, 421)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSetAttnParam"
        Me.Text = "frmAttnParam"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBottom.ResumeLayout(False)
        Me.PnlBottom.PerformLayout()
        Me.pnlAllk.ResumeLayout(False)
        Me.pnlAllk.PerformLayout()
        Me.pnlDATA.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkRemoved As System.Windows.Forms.CheckBox
    Friend WithEvents desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents civilSt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtfldName As System.Windows.Forms.TextBox
    Friend WithEvents chkVisibleInRep As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PnlBottom As System.Windows.Forms.Panel
    Friend WithEvents fldNam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents pnlDATA As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
