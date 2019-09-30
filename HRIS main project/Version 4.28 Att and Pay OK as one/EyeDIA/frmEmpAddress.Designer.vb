<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpAddress
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.dgvEmAdd = New System.Windows.Forms.DataGridView
        Me.addID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.adTpID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AdType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Add1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.add2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Add3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkStDef = New System.Windows.Forms.CheckBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.chkRemove = New System.Windows.Forms.CheckBox
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmbAddType = New System.Windows.Forms.ComboBox
        Me.txtAdID = New System.Windows.Forms.TextBox
        Me.txtLine3 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtLine2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLine1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        CType(Me.dgvEmAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.dgvEmAdd)
        Me.Panel2.Controls.Add(Me.chkStDef)
        Me.Panel2.Controls.Add(Me.chkRemove)
        Me.Panel2.Controls.Add(Me.cmbAddType)
        Me.Panel2.Controls.Add(Me.txtAdID)
        Me.Panel2.Controls.Add(Me.txtLine3)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtLine2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtLine1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1012, 437)
        Me.Panel2.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Location = New System.Drawing.Point(9, 462)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(888, 2)
        Me.Label15.TabIndex = 27
        '
        'dgvEmAdd
        '
        Me.dgvEmAdd.AllowUserToAddRows = False
        Me.dgvEmAdd.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvEmAdd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvEmAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmAdd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.addID, Me.adTpID, Me.AdType, Me.Add1, Me.add2, Me.Add3, Me.st})
        Me.dgvEmAdd.Location = New System.Drawing.Point(3, 202)
        Me.dgvEmAdd.Name = "dgvEmAdd"
        Me.dgvEmAdd.ReadOnly = True
        Me.dgvEmAdd.RowHeadersWidth = 12
        Me.dgvEmAdd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmAdd.Size = New System.Drawing.Size(1006, 232)
        Me.dgvEmAdd.TabIndex = 0
        Me.dgvEmAdd.Tag = "1"
        '
        'addID
        '
        Me.addID.HeaderText = "Address ID"
        Me.addID.Name = "addID"
        Me.addID.ReadOnly = True
        '
        'adTpID
        '
        Me.adTpID.HeaderText = "AdtyID"
        Me.adTpID.Name = "adTpID"
        Me.adTpID.ReadOnly = True
        Me.adTpID.Visible = False
        '
        'AdType
        '
        Me.AdType.HeaderText = "Address Type"
        Me.AdType.Name = "AdType"
        Me.AdType.ReadOnly = True
        Me.AdType.Width = 120
        '
        'Add1
        '
        Me.Add1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Add1.HeaderText = "Line 1"
        Me.Add1.Name = "Add1"
        Me.Add1.ReadOnly = True
        '
        'add2
        '
        Me.add2.HeaderText = "Line 2"
        Me.add2.Name = "add2"
        Me.add2.ReadOnly = True
        Me.add2.Width = 180
        '
        'Add3
        '
        Me.Add3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Add3.HeaderText = "Line 3"
        Me.Add3.Name = "Add3"
        Me.Add3.ReadOnly = True
        '
        'st
        '
        Me.st.HeaderText = "Status"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        Me.st.Visible = False
        '
        'chkStDef
        '
        Me.chkStDef.AutoSize = True
        Me.chkStDef.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStDef.ForeColor = System.Drawing.Color.Black
        Me.chkStDef.Location = New System.Drawing.Point(306, 156)
        Me.chkStDef.Name = "chkStDef"
        Me.chkStDef.Size = New System.Drawing.Size(108, 17)
        Me.chkStDef.TabIndex = 20
        Me.chkStDef.Text = "Set As Default"
        Me.chkStDef.UseVisualStyleBackColor = True
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
        Me.cmdRefresh.Location = New System.Drawing.Point(972, 5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 11
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'chkRemove
        '
        Me.chkRemove.AutoSize = True
        Me.chkRemove.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemove.ForeColor = System.Drawing.Color.Black
        Me.chkRemove.Location = New System.Drawing.Point(306, 179)
        Me.chkRemove.Name = "chkRemove"
        Me.chkRemove.Size = New System.Drawing.Size(80, 17)
        Me.chkRemove.TabIndex = 19
        Me.chkRemove.Text = "Removed"
        Me.chkRemove.UseVisualStyleBackColor = True
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
        Me.cmdSave.Location = New System.Drawing.Point(936, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 10
        Me.cmdSave.Tag = "1"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'cmbAddType
        '
        Me.cmbAddType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAddType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAddType.FormattingEnabled = True
        Me.cmbAddType.Location = New System.Drawing.Point(306, 48)
        Me.cmbAddType.Name = "cmbAddType"
        Me.cmbAddType.Size = New System.Drawing.Size(169, 21)
        Me.cmbAddType.TabIndex = 18
        '
        'txtAdID
        '
        Me.txtAdID.BackColor = System.Drawing.SystemColors.Control
        Me.txtAdID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdID.Location = New System.Drawing.Point(306, 20)
        Me.txtAdID.Name = "txtAdID"
        Me.txtAdID.ReadOnly = True
        Me.txtAdID.Size = New System.Drawing.Size(80, 21)
        Me.txtAdID.TabIndex = 16
        '
        'txtLine3
        '
        Me.txtLine3.BackColor = System.Drawing.Color.White
        Me.txtLine3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine3.Location = New System.Drawing.Point(306, 130)
        Me.txtLine3.MaxLength = 50
        Me.txtLine3.Name = "txtLine3"
        Me.txtLine3.Size = New System.Drawing.Size(388, 21)
        Me.txtLine3.TabIndex = 16
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(213, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Address ID "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLine2
        '
        Me.txtLine2.BackColor = System.Drawing.Color.White
        Me.txtLine2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine2.Location = New System.Drawing.Point(306, 104)
        Me.txtLine2.MaxLength = 50
        Me.txtLine2.Name = "txtLine2"
        Me.txtLine2.Size = New System.Drawing.Size(388, 21)
        Me.txtLine2.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(213, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Address Type "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(213, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Line 3"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(213, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Line 1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLine1
        '
        Me.txtLine1.BackColor = System.Drawing.Color.White
        Me.txtLine1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine1.Location = New System.Drawing.Point(306, 76)
        Me.txtLine1.MaxLength = 50
        Me.txtLine1.Name = "txtLine1"
        Me.txtLine1.Size = New System.Drawing.Size(388, 21)
        Me.txtLine1.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(213, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Line 2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdPrevious)
        Me.Panel1.Controls.Add(Me.cmdNext)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 38)
        Me.Panel1.TabIndex = 96
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
        Me.cmdPrevious.TabIndex = 35
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
        Me.cmdNext.TabIndex = 34
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
        Me.Label25.Location = New System.Drawing.Point(375, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(263, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Employee Address Information"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEmpAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 475)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEmpAddress"
        Me.Text = "Employee Address Detail"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvEmAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents dgvEmAdd As System.Windows.Forms.DataGridView
    Friend WithEvents txtAdID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbAddType As System.Windows.Forms.ComboBox
    Friend WithEvents txtLine3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLine1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRemove As System.Windows.Forms.CheckBox
    Friend WithEvents chkStDef As System.Windows.Forms.CheckBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents addID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents adTpID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Add1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents add2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Add3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
End Class
