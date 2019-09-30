<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonthEndProcess
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
        Me.chkLeaveApply = New System.Windows.Forms.CheckBox
        Me.CboxYear = New System.Windows.Forms.ComboBox
        Me.CboxMonth = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkLeaveCancel = New System.Windows.Forms.CheckBox
        Me.chkAttendanceAdjuest = New System.Windows.Forms.CheckBox
        Me.chkRosterChange = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblAttenAdust = New System.Windows.Forms.Label
        Me.lblRosterChange = New System.Windows.Forms.Label
        Me.lblLvCancelDate = New System.Windows.Forms.Label
        Me.lblLvApplyDate = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkLeaveApply
        '
        Me.chkLeaveApply.AutoSize = True
        Me.chkLeaveApply.Location = New System.Drawing.Point(255, 67)
        Me.chkLeaveApply.Name = "chkLeaveApply"
        Me.chkLeaveApply.Size = New System.Drawing.Size(88, 17)
        Me.chkLeaveApply.TabIndex = 1
        Me.chkLeaveApply.Text = "Leave Apply "
        Me.chkLeaveApply.UseVisualStyleBackColor = True
        '
        'CboxYear
        '
        Me.CboxYear.FormattingEnabled = True
        Me.CboxYear.Location = New System.Drawing.Point(24, 28)
        Me.CboxYear.Name = "CboxYear"
        Me.CboxYear.Size = New System.Drawing.Size(138, 21)
        Me.CboxYear.TabIndex = 2
        '
        'CboxMonth
        '
        Me.CboxMonth.FormattingEnabled = True
        Me.CboxMonth.Location = New System.Drawing.Point(255, 28)
        Me.CboxMonth.Name = "CboxMonth"
        Me.CboxMonth.Size = New System.Drawing.Size(134, 21)
        Me.CboxMonth.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Leave cancel "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(252, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Month"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Year"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Attendance Adjustment"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Roster Change "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Leave Apply"
        '
        'chkLeaveCancel
        '
        Me.chkLeaveCancel.AutoSize = True
        Me.chkLeaveCancel.Location = New System.Drawing.Point(255, 90)
        Me.chkLeaveCancel.Name = "chkLeaveCancel"
        Me.chkLeaveCancel.Size = New System.Drawing.Size(92, 17)
        Me.chkLeaveCancel.TabIndex = 11
        Me.chkLeaveCancel.Text = "Leave Cancel"
        Me.chkLeaveCancel.UseVisualStyleBackColor = True
        '
        'chkAttendanceAdjuest
        '
        Me.chkAttendanceAdjuest.AutoSize = True
        Me.chkAttendanceAdjuest.Location = New System.Drawing.Point(24, 67)
        Me.chkAttendanceAdjuest.Name = "chkAttendanceAdjuest"
        Me.chkAttendanceAdjuest.Size = New System.Drawing.Size(136, 17)
        Me.chkAttendanceAdjuest.TabIndex = 12
        Me.chkAttendanceAdjuest.Text = "Attendance Adjustment"
        Me.chkAttendanceAdjuest.UseVisualStyleBackColor = True
        '
        'chkRosterChange
        '
        Me.chkRosterChange.AutoSize = True
        Me.chkRosterChange.Location = New System.Drawing.Point(24, 90)
        Me.chkRosterChange.Name = "chkRosterChange"
        Me.chkRosterChange.Size = New System.Drawing.Size(97, 17)
        Me.chkRosterChange.TabIndex = 13
        Me.chkRosterChange.Text = "Roster Change"
        Me.chkRosterChange.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAttenAdust)
        Me.GroupBox1.Controls.Add(Me.lblRosterChange)
        Me.GroupBox1.Controls.Add(Me.lblLvCancelDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblLvApplyDate)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(34, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 152)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Last Process Details"
        '
        'lblAttenAdust
        '
        Me.lblAttenAdust.AutoSize = True
        Me.lblAttenAdust.Location = New System.Drawing.Point(211, 105)
        Me.lblAttenAdust.Name = "lblAttenAdust"
        Me.lblAttenAdust.Size = New System.Drawing.Size(69, 13)
        Me.lblAttenAdust.TabIndex = 16
        Me.lblAttenAdust.Text = "lblAttenAdust"
        '
        'lblRosterChange
        '
        Me.lblRosterChange.AutoSize = True
        Me.lblRosterChange.Location = New System.Drawing.Point(211, 82)
        Me.lblRosterChange.Name = "lblRosterChange"
        Me.lblRosterChange.Size = New System.Drawing.Size(85, 13)
        Me.lblRosterChange.TabIndex = 17
        Me.lblRosterChange.Text = "lblRosterChange"
        '
        'lblLvCancelDate
        '
        Me.lblLvCancelDate.AutoSize = True
        Me.lblLvCancelDate.Location = New System.Drawing.Point(211, 34)
        Me.lblLvCancelDate.Name = "lblLvCancelDate"
        Me.lblLvCancelDate.Size = New System.Drawing.Size(85, 13)
        Me.lblLvCancelDate.TabIndex = 18
        Me.lblLvCancelDate.Text = "lblLvCancelDate"
        '
        'lblLvApplyDate
        '
        Me.lblLvApplyDate.AutoSize = True
        Me.lblLvApplyDate.Location = New System.Drawing.Point(211, 57)
        Me.lblLvApplyDate.Name = "lblLvApplyDate"
        Me.lblLvApplyDate.Size = New System.Drawing.Size(78, 13)
        Me.lblLvApplyDate.TabIndex = 15
        Me.lblLvApplyDate.Text = "lblLvApplyDate"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel9.Controls.Add(Me.Button3)
        Me.Panel9.Controls.Add(Me.PictureBox1)
        Me.Panel9.Controls.Add(Me.Label25)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(492, 47)
        Me.Panel9.TabIndex = 92
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(435, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(31, 28)
        Me.Button3.TabIndex = 47
        Me.Button3.Tag = "5"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(63, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(163, 18)
        Me.Label25.TabIndex = 45
        Me.Label25.Text = "Month End Process"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAttendanceAdjuest)
        Me.GroupBox2.Controls.Add(Me.chkLeaveCancel)
        Me.GroupBox2.Controls.Add(Me.chkRosterChange)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.chkLeaveApply)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.CboxMonth)
        Me.GroupBox2.Controls.Add(Me.CboxYear)
        Me.GroupBox2.Location = New System.Drawing.Point(34, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 126)
        Me.GroupBox2.TabIndex = 93
        Me.GroupBox2.TabStop = False
        '
        'frmMonthEndProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(492, 398)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMonthEndProcess"
        Me.Text = "frmMonthEndProcess"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkLeaveApply As System.Windows.Forms.CheckBox
    Friend WithEvents CboxYear As System.Windows.Forms.ComboBox
    Friend WithEvents CboxMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkLeaveCancel As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttendanceAdjuest As System.Windows.Forms.CheckBox
    Friend WithEvents chkRosterChange As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAttenAdust As System.Windows.Forms.Label
    Friend WithEvents lblRosterChange As System.Windows.Forms.Label
    Friend WithEvents lblLvCancelDate As System.Windows.Forms.Label
    Friend WithEvents lblLvApplyDate As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
