<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTaxand_Stamps
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTaxand_Stamps))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbID = New System.Windows.Forms.ComboBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSalItem1 = New System.Windows.Forms.ComboBox()
        Me.cmbSalItem2 = New System.Windows.Forms.ComboBox()
        Me.txtFormula = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LstCurrent = New System.Windows.Forms.ListBox()
        Me.LstAll = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.CHKRemove = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvTaxGrid1 = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvTaxEmployee = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvTaxGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTaxEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(785, 66)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(233, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Set PAYE Tax and Stamps Fees"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(785, 2)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'cmbID
        '
        Me.cmbID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbID.FormattingEnabled = True
        Me.cmbID.Location = New System.Drawing.Point(111, 82)
        Me.cmbID.Name = "cmbID"
        Me.cmbID.Size = New System.Drawing.Size(123, 21)
        Me.cmbID.TabIndex = 138
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Location = New System.Drawing.Point(240, 80)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(24, 24)
        Me.cmdRefresh.TabIndex = 137
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 13)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Total Field"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 13)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Deduction Field"
        '
        'cmbSalItem1
        '
        Me.cmbSalItem1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalItem1.FormattingEnabled = True
        Me.cmbSalItem1.Location = New System.Drawing.Point(111, 109)
        Me.cmbSalItem1.Name = "cmbSalItem1"
        Me.cmbSalItem1.Size = New System.Drawing.Size(275, 21)
        Me.cmbSalItem1.TabIndex = 132
        '
        'cmbSalItem2
        '
        Me.cmbSalItem2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSalItem2.FormattingEnabled = True
        Me.cmbSalItem2.Location = New System.Drawing.Point(111, 136)
        Me.cmbSalItem2.Name = "cmbSalItem2"
        Me.cmbSalItem2.Size = New System.Drawing.Size(275, 21)
        Me.cmbSalItem2.TabIndex = 134
        '
        'txtFormula
        '
        Me.txtFormula.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFormula.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormula.Location = New System.Drawing.Point(0, 214)
        Me.txtFormula.Multiline = True
        Me.txtFormula.Name = "txtFormula"
        Me.txtFormula.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtFormula.Size = New System.Drawing.Size(785, 169)
        Me.txtFormula.TabIndex = 139
        Me.txtFormula.Text = "update tblTempTax set Amount=(DedSalAmount*2/100)-2000 where DedSalAmount>900" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(392, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 141
        Me.Label6.Text = "@TotalField"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(488, 386)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(290, 13)
        Me.Label7.TabIndex = 142
        Me.Label7.Tag = "1"
        Me.Label7.Text = "TotsalID,DedSalID,RegID,Amount,DedSalAmount"
        '
        'LstCurrent
        '
        Me.LstCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstCurrent.FormattingEnabled = True
        Me.LstCurrent.Location = New System.Drawing.Point(660, 94)
        Me.LstCurrent.Name = "LstCurrent"
        Me.LstCurrent.Size = New System.Drawing.Size(114, 91)
        Me.LstCurrent.TabIndex = 143
        '
        'LstAll
        '
        Me.LstAll.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LstAll.FormattingEnabled = True
        Me.LstAll.Location = New System.Drawing.Point(540, 94)
        Me.LstAll.Name = "LstAll"
        Me.LstAll.Size = New System.Drawing.Size(114, 91)
        Me.LstAll.TabIndex = 144
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(660, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 17)
        Me.Label8.TabIndex = 145
        Me.Label8.Text = "Current Formula"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SkyBlue
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(540, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 17)
        Me.Label10.TabIndex = 146
        Me.Label10.Text = "All Formula"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(596, 411)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 26)
        Me.btnSave.TabIndex = 147
        Me.btnSave.Tag = "1"
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(690, 411)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 26)
        Me.btnExit.TabIndex = 148
        Me.btnExit.Tag = "1"
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'CHKRemove
        '
        Me.CHKRemove.AutoSize = True
        Me.CHKRemove.Location = New System.Drawing.Point(111, 163)
        Me.CHKRemove.Name = "CHKRemove"
        Me.CHKRemove.Size = New System.Drawing.Size(73, 17)
        Me.CHKRemove.TabIndex = 149
        Me.CHKRemove.Text = "Remove"
        Me.CHKRemove.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(785, 17)
        Me.Label5.TabIndex = 150
        Me.Label5.Text = "Current Formula"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvTaxGrid1
        '
        Me.dgvTaxGrid1.AllowUserToAddRows = False
        Me.dgvTaxGrid1.AllowUserToDeleteRows = False
        Me.dgvTaxGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTaxGrid1.Location = New System.Drawing.Point(944, 76)
        Me.dgvTaxGrid1.Name = "dgvTaxGrid1"
        Me.dgvTaxGrid1.ReadOnly = True
        Me.dgvTaxGrid1.Size = New System.Drawing.Size(182, 66)
        Me.dgvTaxGrid1.TabIndex = 151
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(824, 184)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 23)
        Me.Button1.TabIndex = 152
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvTaxEmployee
        '
        Me.dgvTaxEmployee.AllowUserToAddRows = False
        Me.dgvTaxEmployee.AllowUserToDeleteRows = False
        Me.dgvTaxEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTaxEmployee.Location = New System.Drawing.Point(954, 148)
        Me.dgvTaxEmployee.Name = "dgvTaxEmployee"
        Me.dgvTaxEmployee.ReadOnly = True
        Me.dgvTaxEmployee.Size = New System.Drawing.Size(182, 66)
        Me.dgvTaxEmployee.TabIndex = 153
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(954, 258)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 35)
        Me.Button2.TabIndex = 154
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Location = New System.Drawing.Point(5, 402)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(774, 2)
        Me.Label11.TabIndex = 155
        '
        'FrmTaxand_Stamps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(785, 444)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgvTaxEmployee)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvTaxGrid1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CHKRemove)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LstAll)
        Me.Controls.Add(Me.LstCurrent)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtFormula)
        Me.Controls.Add(Me.cmbID)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbSalItem1)
        Me.Controls.Add(Me.cmbSalItem2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmTaxand_Stamps"
        Me.Text = "Tax Calculation Formulas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvTaxGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTaxEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbID As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSalItem1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSalItem2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtFormula As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LstCurrent As System.Windows.Forms.ListBox
    Friend WithEvents LstAll As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents CHKRemove As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvTaxGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvTaxEmployee As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
