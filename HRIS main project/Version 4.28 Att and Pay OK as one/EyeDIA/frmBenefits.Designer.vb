<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBenefits
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
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.TagID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dsgName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HOD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.st = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboxBenifitsItems = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtpSubmithDate = New System.Windows.Forms.DateTimePicker
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkStatus = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.dtpRemoveDate = New System.Windows.Forms.DateTimePicker
        Me.lblInactiveDate = New System.Windows.Forms.Label
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(38, 194)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(276, 112)
        Me.txtRemark.TabIndex = 99
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TagID, Me.dsgName, Me.shCode, Me.HOD, Me.st})
        Me.dgvData.GridColor = System.Drawing.Color.White
        Me.dgvData.Location = New System.Drawing.Point(357, 105)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowHeadersWidth = 12
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(643, 323)
        Me.dgvData.TabIndex = 102
        Me.dgvData.Tag = "1"
        '
        'TagID
        '
        Me.TagID.HeaderText = "TagID"
        Me.TagID.Name = "TagID"
        Me.TagID.ReadOnly = True
        Me.TagID.Visible = False
        '
        'dsgName
        '
        Me.dsgName.HeaderText = "Description"
        Me.dsgName.Name = "dsgName"
        Me.dsgName.ReadOnly = True
        Me.dsgName.Width = 300
        '
        'shCode
        '
        Me.shCode.FillWeight = 66.0!
        Me.shCode.HeaderText = "Submit Date"
        Me.shCode.Name = "shCode"
        Me.shCode.ReadOnly = True
        '
        'HOD
        '
        Me.HOD.FillWeight = 150.0!
        Me.HOD.HeaderText = "Return Date"
        Me.HOD.Name = "HOD"
        Me.HOD.ReadOnly = True
        '
        'st
        '
        Me.st.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.st.HeaderText = "Remark"
        Me.st.Name = "st"
        Me.st.ReadOnly = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(12, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 16)
        Me.Label8.TabIndex = 150
        Me.Label8.Text = "Benefits Details"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(138, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(878, 3)
        Me.Label9.TabIndex = 149
        '
        'cboxBenifitsItems
        '
        Me.cboxBenifitsItems.FormattingEnabled = True
        Me.cboxBenifitsItems.Location = New System.Drawing.Point(38, 105)
        Me.cboxBenifitsItems.Name = "cboxBenifitsItems"
        Me.cboxBenifitsItems.Size = New System.Drawing.Size(276, 21)
        Me.cboxBenifitsItems.TabIndex = 151
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 152
        Me.Label11.Text = "Benefits Items"
        '
        'dtpSubmithDate
        '
        Me.dtpSubmithDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpSubmithDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSubmithDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSubmithDate.Location = New System.Drawing.Point(38, 148)
        Me.dtpSubmithDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpSubmithDate.Name = "dtpSubmithDate"
        Me.dtpSubmithDate.Size = New System.Drawing.Size(129, 21)
        Me.dtpSubmithDate.TabIndex = 153
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpReturnDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReturnDate.Location = New System.Drawing.Point(185, 147)
        Me.dtpReturnDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(129, 21)
        Me.dtpReturnDate.TabIndex = 154
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(172, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Return Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Submit Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "Remark"
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.Location = New System.Drawing.Point(242, 312)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(72, 17)
        Me.chkStatus.TabIndex = 158
        Me.chkStatus.Text = "Inactive"
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 38)
        Me.Panel1.TabIndex = 97
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(375, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(154, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Employee Benifits"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'dtpRemoveDate
        '
        Me.dtpRemoveDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpRemoveDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRemoveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRemoveDate.Location = New System.Drawing.Point(38, 348)
        Me.dtpRemoveDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpRemoveDate.Name = "dtpRemoveDate"
        Me.dtpRemoveDate.Size = New System.Drawing.Size(129, 21)
        Me.dtpRemoveDate.TabIndex = 159
        Me.dtpRemoveDate.Value = New Date(1900, 1, 1, 13, 49, 0, 0)
        '
        'lblInactiveDate
        '
        Me.lblInactiveDate.AutoSize = True
        Me.lblInactiveDate.Location = New System.Drawing.Point(38, 332)
        Me.lblInactiveDate.Name = "lblInactiveDate"
        Me.lblInactiveDate.Size = New System.Drawing.Size(71, 13)
        Me.lblInactiveDate.TabIndex = 160
        Me.lblInactiveDate.Text = "Inactive Date"
        '
        'frmBenefits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1022, 472)
        Me.Controls.Add(Me.lblInactiveDate)
        Me.Controls.Add(Me.dtpRemoveDate)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpReturnDate)
        Me.Controls.Add(Me.dtpSubmithDate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboxBenifitsItems)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.txtRemark)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBenefits"
        Me.Text = "frmBenefits"
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboxBenifitsItems As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpSubmithDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents TagID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dsgName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents st As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpRemoveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInactiveDate As System.Windows.Forms.Label
End Class
