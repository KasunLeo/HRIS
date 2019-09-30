<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBankFileHeader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBankFileHeader))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkRemove = New System.Windows.Forms.CheckBox()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.T4 = New System.Windows.Forms.TextBox()
        Me.T3 = New System.Windows.Forms.TextBox()
        Me.T2 = New System.Windows.Forms.TextBox()
        Me.T1 = New System.Windows.Forms.TextBox()
        Me.txtOriAccName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtOriAccNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOriBranchNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOriginatingBankNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(458, 66)
        Me.Panel1.TabIndex = 95
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Location = New System.Drawing.Point(0, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(458, 2)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Month"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(9, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Bank File Headers..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkRemove)
        Me.GroupBox1.Controls.Add(Me.Button18)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.cmdRefresh)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.T4)
        Me.GroupBox1.Controls.Add(Me.T3)
        Me.GroupBox1.Controls.Add(Me.T2)
        Me.GroupBox1.Controls.Add(Me.T1)
        Me.GroupBox1.Controls.Add(Me.txtOriAccName)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtOriAccNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtOriBranchNo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtOriginatingBankNo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 239)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Return Formats"
        '
        'chkRemove
        '
        Me.chkRemove.AutoSize = True
        Me.chkRemove.Location = New System.Drawing.Point(182, 179)
        Me.chkRemove.Name = "chkRemove"
        Me.chkRemove.Size = New System.Drawing.Size(73, 17)
        Me.chkRemove.TabIndex = 119
        Me.chkRemove.Text = "Remove"
        Me.chkRemove.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Button18.BackgroundImage = CType(resources.GetObject("Button18.BackgroundImage"), System.Drawing.Image)
        Me.Button18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button18.FlatAppearance.BorderSize = 0
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Location = New System.Drawing.Point(318, 15)
        Me.Button18.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(24, 24)
        Me.Button18.TabIndex = 118
        Me.Button18.TabStop = False
        Me.Button18.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(313, 204)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 26)
        Me.btnExit.TabIndex = 117
        Me.btnExit.Tag = "1"
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = CType(resources.GetObject("btnSave.BackgroundImage"), System.Drawing.Image)
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(219, 204)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 26)
        Me.btnSave.TabIndex = 116
        Me.btnSave.Tag = "1"
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Location = New System.Drawing.Point(291, 15)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(24, 24)
        Me.cmdRefresh.TabIndex = 115
        Me.cmdRefresh.TabStop = False
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(181, 44)
        Me.txtName.MaxLength = 20
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(220, 21)
        Me.txtName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Name"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(181, 17)
        Me.txtID.MaxLength = 4
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(106, 21)
        Me.txtID.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "ID"
        '
        'T4
        '
        Me.T4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T4.Enabled = False
        Me.T4.Location = New System.Drawing.Point(402, 159)
        Me.T4.MaxLength = 4
        Me.T4.Name = "T4"
        Me.T4.ReadOnly = True
        Me.T4.Size = New System.Drawing.Size(32, 14)
        Me.T4.TabIndex = 17
        '
        'T3
        '
        Me.T3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T3.Enabled = False
        Me.T3.Location = New System.Drawing.Point(402, 132)
        Me.T3.MaxLength = 4
        Me.T3.Name = "T3"
        Me.T3.ReadOnly = True
        Me.T3.Size = New System.Drawing.Size(32, 14)
        Me.T3.TabIndex = 16
        '
        'T2
        '
        Me.T2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T2.Enabled = False
        Me.T2.Location = New System.Drawing.Point(402, 105)
        Me.T2.MaxLength = 4
        Me.T2.Name = "T2"
        Me.T2.ReadOnly = True
        Me.T2.Size = New System.Drawing.Size(32, 14)
        Me.T2.TabIndex = 15
        '
        'T1
        '
        Me.T1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.T1.Enabled = False
        Me.T1.Location = New System.Drawing.Point(402, 78)
        Me.T1.MaxLength = 4
        Me.T1.Name = "T1"
        Me.T1.ReadOnly = True
        Me.T1.Size = New System.Drawing.Size(32, 14)
        Me.T1.TabIndex = 14
        '
        'txtOriAccName
        '
        Me.txtOriAccName.Location = New System.Drawing.Point(181, 152)
        Me.txtOriAccName.MaxLength = 20
        Me.txtOriAccName.Name = "txtOriAccName"
        Me.txtOriAccName.Size = New System.Drawing.Size(220, 21)
        Me.txtOriAccName.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 155)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(154, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Originating Acc Name(20)"
        '
        'txtOriAccNo
        '
        Me.txtOriAccNo.Location = New System.Drawing.Point(181, 125)
        Me.txtOriAccNo.MaxLength = 12
        Me.txtOriAccNo.Name = "txtOriAccNo"
        Me.txtOriAccNo.Size = New System.Drawing.Size(220, 21)
        Me.txtOriAccNo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Originating Acc No(12)"
        '
        'txtOriBranchNo
        '
        Me.txtOriBranchNo.Location = New System.Drawing.Point(181, 98)
        Me.txtOriBranchNo.MaxLength = 3
        Me.txtOriBranchNo.Name = "txtOriBranchNo"
        Me.txtOriBranchNo.Size = New System.Drawing.Size(106, 21)
        Me.txtOriBranchNo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Originating Branch No(3)"
        '
        'txtOriginatingBankNo
        '
        Me.txtOriginatingBankNo.Location = New System.Drawing.Point(181, 71)
        Me.txtOriginatingBankNo.MaxLength = 4
        Me.txtOriginatingBankNo.Name = "txtOriginatingBankNo"
        Me.txtOriginatingBankNo.Size = New System.Drawing.Size(106, 21)
        Me.txtOriginatingBankNo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(138, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Originating Bank No(4)"
        '
        'FrmBankFileHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(458, 316)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FrmBankFileHeader"
        Me.Text = "Bank File Headers"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents T4 As System.Windows.Forms.TextBox
    Friend WithEvents T3 As System.Windows.Forms.TextBox
    Friend WithEvents T2 As System.Windows.Forms.TextBox
    Friend WithEvents T1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOriAccName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtOriAccNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOriBranchNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOriginatingBankNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents chkRemove As System.Windows.Forms.CheckBox
End Class
