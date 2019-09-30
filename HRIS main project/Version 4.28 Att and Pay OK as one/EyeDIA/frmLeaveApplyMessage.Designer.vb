<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeaveApplyMessage
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkLate = New System.Windows.Forms.CheckBox
        Me.chkEarly = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.lblEmpNo = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblLate = New System.Windows.Forms.Label
        Me.lblEarly = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(433, 38)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This employee has late and early both for selected day." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please select what do yo" & _
            "u want to cover from this leave"
        '
        'chkLate
        '
        Me.chkLate.AutoSize = True
        Me.chkLate.Location = New System.Drawing.Point(181, 147)
        Me.chkLate.Name = "chkLate"
        Me.chkLate.Size = New System.Drawing.Size(102, 17)
        Me.chkLate.TabIndex = 1
        Me.chkLate.Text = "Right off Late"
        Me.chkLate.UseVisualStyleBackColor = True
        '
        'chkEarly
        '
        Me.chkEarly.AutoSize = True
        Me.chkEarly.Location = New System.Drawing.Point(181, 177)
        Me.chkEarly.Name = "chkEarly"
        Me.chkEarly.Size = New System.Drawing.Size(107, 17)
        Me.chkEarly.TabIndex = 2
        Me.chkEarly.Text = "Right off Early"
        Me.chkEarly.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(357, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Date  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Employee Name :"
        '
        'Panel11
        '
        Me.Panel11.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel11.Controls.Add(Me.cmdSave)
        Me.Panel11.Controls.Add(Me.lblEmpNo)
        Me.Panel11.Controls.Add(Me.PictureBox1)
        Me.Panel11.Controls.Add(Me.Label16)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(520, 48)
        Me.Panel11.TabIndex = 76
        '
        'lblEmpNo
        '
        Me.lblEmpNo.AutoSize = True
        Me.lblEmpNo.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpNo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpNo.ForeColor = System.Drawing.Color.White
        Me.lblEmpNo.Location = New System.Drawing.Point(357, 17)
        Me.lblEmpNo.Name = "lblEmpNo"
        Me.lblEmpNo.Size = New System.Drawing.Size(50, 16)
        Me.lblEmpNo.TabIndex = 79
        Me.lblEmpNo.Text = "000002"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 23
        Me.PictureBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.DimGray
        Me.Label16.Location = New System.Drawing.Point(61, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(211, 13)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Apply Leave for Selected Dates"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.BackColor = System.Drawing.Color.Transparent
        Me.lblName.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.DimGray
        Me.lblName.Location = New System.Drawing.Point(138, 8)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(76, 16)
        Me.lblName.TabIndex = 77
        Me.lblName.Text = "Employee "
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.DimGray
        Me.lblDate.Location = New System.Drawing.Point(413, 8)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(38, 16)
        Me.lblDate.TabIndex = 78
        Me.lblDate.Text = "Date"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.notcurved46
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblDate)
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(520, 32)
        Me.Panel1.TabIndex = 79
        '
        'lblLate
        '
        Me.lblLate.AutoSize = True
        Me.lblLate.BackColor = System.Drawing.Color.Transparent
        Me.lblLate.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLate.Location = New System.Drawing.Point(40, 146)
        Me.lblLate.Name = "lblLate"
        Me.lblLate.Size = New System.Drawing.Size(97, 16)
        Me.lblLate.TabIndex = 79
        Me.lblLate.Text = "Late Minutes :"
        '
        'lblEarly
        '
        Me.lblEarly.AutoSize = True
        Me.lblEarly.BackColor = System.Drawing.Color.Transparent
        Me.lblEarly.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEarly.Location = New System.Drawing.Point(40, 176)
        Me.lblEarly.Name = "lblEarly"
        Me.lblEarly.Size = New System.Drawing.Size(103, 16)
        Me.lblEarly.TabIndex = 80
        Me.lblEarly.Text = "Early Minutes :"
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
        Me.cmdSave.Location = New System.Drawing.Point(480, 11)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 80
        Me.cmdSave.Tag = "6"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'frmLeaveApplyMessage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 212)
        Me.Controls.Add(Me.lblEarly)
        Me.Controls.Add(Me.lblLate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.chkEarly)
        Me.Controls.Add(Me.chkLate)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLeaveApplyMessage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLeaveApplyMessage"
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLate As System.Windows.Forms.CheckBox
    Friend WithEvents chkEarly As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEmpNo As System.Windows.Forms.Label
    Friend WithEvents lblLate As System.Windows.Forms.Label
    Friend WithEvents lblEarly As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
End Class
