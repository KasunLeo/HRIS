<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeFromExcel
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtExcelFile = New System.Windows.Forms.TextBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.OFD = New System.Windows.Forms.OpenFileDialog
        Me.cmbSheet = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.lblCoun = New System.Windows.Forms.Label
        Me.btnVerify = New System.Windows.Forms.Button
        Me.btnSync = New System.Windows.Forms.Button
        Me.btnAtendance = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(866, 48)
        Me.Panel1.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label4.Location = New System.Drawing.Point(0, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(866, 2)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Label4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(8, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(181, 16)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Import Data From Excel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Excel File"
        '
        'txtExcelFile
        '
        Me.txtExcelFile.Location = New System.Drawing.Point(84, 76)
        Me.txtExcelFile.Name = "txtExcelFile"
        Me.txtExcelFile.Size = New System.Drawing.Size(542, 21)
        Me.txtExcelFile.TabIndex = 16
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(0, 104)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 12
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(866, 389)
        Me.dgv.TabIndex = 31
        Me.dgv.Tag = "1"
        '
        'cmbSheet
        '
        Me.cmbSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSheet.FormattingEnabled = True
        Me.cmbSheet.Location = New System.Drawing.Point(739, 77)
        Me.cmbSheet.Name = "cmbSheet"
        Me.cmbSheet.Size = New System.Drawing.Size(114, 21)
        Me.cmbSheet.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(656, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Sheet Name"
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(9, 494)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(849, 2)
        Me.Label13.TabIndex = 123
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(577, 501)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 26)
        Me.btnSave.TabIndex = 99
        Me.btnSave.Tag = "1"
        Me.btnSave.Text = "&Import"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(765, 501)
        Me.Button8.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(88, 26)
        Me.Button8.TabIndex = 122
        Me.Button8.Tag = "1"
        Me.Button8.Text = "&Exit"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(671, 501)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 26)
        Me.Button4.TabIndex = 91
        Me.Button4.Tag = "1"
        Me.Button4.Text = "&Refresh"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(627, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 30
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblCoun
        '
        Me.lblCoun.AutoSize = True
        Me.lblCoun.Location = New System.Drawing.Point(119, 508)
        Me.lblCoun.Name = "lblCoun"
        Me.lblCoun.Size = New System.Drawing.Size(0, 13)
        Me.lblCoun.TabIndex = 124
        '
        'btnVerify
        '
        Me.btnVerify.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.btnVerify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerify.FlatAppearance.BorderSize = 0
        Me.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerify.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerify.ForeColor = System.Drawing.Color.White
        Me.btnVerify.Location = New System.Drawing.Point(483, 501)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(88, 26)
        Me.btnVerify.TabIndex = 125
        Me.btnVerify.Tag = "1"
        Me.btnVerify.Text = "&Verify"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'btnSync
        '
        Me.btnSync.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.btnSync.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSync.FlatAppearance.BorderSize = 0
        Me.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSync.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSync.ForeColor = System.Drawing.Color.White
        Me.btnSync.Location = New System.Drawing.Point(11, 501)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(88, 26)
        Me.btnSync.TabIndex = 126
        Me.btnSync.Tag = "1"
        Me.btnSync.Text = "&Sync"
        Me.btnSync.UseVisualStyleBackColor = True
        '
        'btnAtendance
        '
        Me.btnAtendance.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.btnAtendance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAtendance.FlatAppearance.BorderSize = 0
        Me.btnAtendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAtendance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtendance.ForeColor = System.Drawing.Color.White
        Me.btnAtendance.Location = New System.Drawing.Point(325, 501)
        Me.btnAtendance.Name = "btnAtendance"
        Me.btnAtendance.Size = New System.Drawing.Size(88, 26)
        Me.btnAtendance.TabIndex = 127
        Me.btnAtendance.Tag = "1"
        Me.btnAtendance.Text = "&Atendance"
        Me.btnAtendance.UseVisualStyleBackColor = True
        '
        'FrmEmployeeFromExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(866, 535)
        Me.Controls.Add(Me.btnAtendance)
        Me.Controls.Add(Me.btnSync)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.lblCoun)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmbSheet)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtExcelFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmEmployeeFromExcel"
        Me.Text = "Get Data From Excel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtExcelFile As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbSheet As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents lblCoun As System.Windows.Forms.Label
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents btnSync As System.Windows.Forms.Button
    Friend WithEvents btnAtendance As System.Windows.Forms.Button
End Class
