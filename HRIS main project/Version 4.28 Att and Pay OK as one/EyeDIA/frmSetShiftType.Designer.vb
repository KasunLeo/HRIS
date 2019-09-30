<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetShiftType
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
        Me.dgvShifts = New System.Windows.Forms.DataGridView
        Me.ShiftID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShiftName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OutTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkMin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtShiftName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.opt24Hour = New System.Windows.Forms.RadioButton
        Me.optNight = New System.Windows.Forms.RadioButton
        Me.optDay = New System.Windows.Forms.RadioButton
        Me.dtpShitStart = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpShiftEnd = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtpStartCIN = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpEndCIN = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpStartCOUT = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtpEndCOUT = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotWMins = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtShiftID = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtDayCount = New System.Windows.Forms.TextBox
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkOpenShift = New System.Windows.Forms.CheckBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtShortCode = New System.Windows.Forms.TextBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.chkWrkMin = New System.Windows.Forms.CheckBox
        Me.chkStrShift = New System.Windows.Forms.CheckBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblDesciption = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        CType(Me.dgvShifts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvShifts
        '
        Me.dgvShifts.AllowUserToAddRows = False
        Me.dgvShifts.BackgroundColor = System.Drawing.Color.White
        Me.dgvShifts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvShifts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShiftID, Me.ShiftName, Me.InTime, Me.OutTime, Me.WorkMin, Me.Status})
        Me.dgvShifts.GridColor = System.Drawing.Color.White
        Me.dgvShifts.Location = New System.Drawing.Point(312, 25)
        Me.dgvShifts.Name = "dgvShifts"
        Me.dgvShifts.ReadOnly = True
        Me.dgvShifts.RowHeadersVisible = False
        Me.dgvShifts.RowHeadersWidth = 12
        Me.dgvShifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShifts.Size = New System.Drawing.Size(343, 351)
        Me.dgvShifts.TabIndex = 16
        Me.dgvShifts.Tag = "1"
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
        Me.ShiftName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ShiftName.HeaderText = "Shift Name"
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.ReadOnly = True
        '
        'InTime
        '
        Me.InTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.InTime.HeaderText = "In Time"
        Me.InTime.Name = "InTime"
        Me.InTime.ReadOnly = True
        Me.InTime.Width = 76
        '
        'OutTime
        '
        Me.OutTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.OutTime.HeaderText = "Out Time"
        Me.OutTime.Name = "OutTime"
        Me.OutTime.ReadOnly = True
        Me.OutTime.Width = 84
        '
        'WorkMin
        '
        Me.WorkMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.WorkMin.HeaderText = "Sh Code"
        Me.WorkMin.Name = "WorkMin"
        Me.WorkMin.ReadOnly = True
        Me.WorkMin.Width = 81
        '
        'Status
        '
        Me.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Visible = False
        '
        'txtShiftName
        '
        Me.txtShiftName.Location = New System.Drawing.Point(12, 98)
        Me.txtShiftName.Name = "txtShiftName"
        Me.txtShiftName.Size = New System.Drawing.Size(239, 21)
        Me.txtShiftName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Shift Name "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'opt24Hour
        '
        Me.opt24Hour.AutoSize = True
        Me.opt24Hour.Location = New System.Drawing.Point(188, 55)
        Me.opt24Hour.Name = "opt24Hour"
        Me.opt24Hour.Size = New System.Drawing.Size(100, 17)
        Me.opt24Hour.TabIndex = 4
        Me.opt24Hour.Text = "24 Hour Shift"
        Me.opt24Hour.UseVisualStyleBackColor = True
        Me.opt24Hour.Visible = False
        '
        'optNight
        '
        Me.optNight.AutoSize = True
        Me.optNight.Location = New System.Drawing.Point(98, 56)
        Me.optNight.Name = "optNight"
        Me.optNight.Size = New System.Drawing.Size(84, 17)
        Me.optNight.TabIndex = 3
        Me.optNight.Text = "Night Shift"
        Me.optNight.UseVisualStyleBackColor = True
        '
        'optDay
        '
        Me.optDay.AutoSize = True
        Me.optDay.Checked = True
        Me.optDay.Location = New System.Drawing.Point(12, 56)
        Me.optDay.Name = "optDay"
        Me.optDay.Size = New System.Drawing.Size(78, 17)
        Me.optDay.TabIndex = 2
        Me.optDay.TabStop = True
        Me.optDay.Text = "Day Shift"
        Me.optDay.UseVisualStyleBackColor = True
        '
        'dtpShitStart
        '
        Me.dtpShitStart.CustomFormat = "hh:mm:ss tt"
        Me.dtpShitStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpShitStart.Location = New System.Drawing.Point(12, 145)
        Me.dtpShitStart.Name = "dtpShitStart"
        Me.dtpShitStart.ShowUpDown = True
        Me.dtpShitStart.Size = New System.Drawing.Size(109, 21)
        Me.dtpShitStart.TabIndex = 5
        Me.dtpShitStart.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Shift Start "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(138, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Shift End "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpShiftEnd
        '
        Me.dtpShiftEnd.CustomFormat = "hh:mm:ss tt"
        Me.dtpShiftEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpShiftEnd.Location = New System.Drawing.Point(141, 145)
        Me.dtpShiftEnd.Name = "dtpShiftEnd"
        Me.dtpShiftEnd.ShowUpDown = True
        Me.dtpShiftEnd.Size = New System.Drawing.Size(110, 21)
        Me.dtpShiftEnd.TabIndex = 6
        Me.dtpShiftEnd.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Clock IN Start "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartCIN
        '
        Me.dtpStartCIN.CustomFormat = "hh:mm:ss tt"
        Me.dtpStartCIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartCIN.Location = New System.Drawing.Point(12, 194)
        Me.dtpStartCIN.Name = "dtpStartCIN"
        Me.dtpStartCIN.ShowUpDown = True
        Me.dtpStartCIN.Size = New System.Drawing.Size(109, 21)
        Me.dtpStartCIN.TabIndex = 7
        Me.dtpStartCIN.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(467, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 21)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Clock IN End |"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Visible = False
        '
        'dtpEndCIN
        '
        Me.dtpEndCIN.CustomFormat = "hh:mm tt"
        Me.dtpEndCIN.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndCIN.Location = New System.Drawing.Point(562, 12)
        Me.dtpEndCIN.Name = "dtpEndCIN"
        Me.dtpEndCIN.ShowUpDown = True
        Me.dtpEndCIN.Size = New System.Drawing.Size(86, 21)
        Me.dtpEndCIN.TabIndex = 8
        Me.dtpEndCIN.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpEndCIN.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(138, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Half Day Start "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartCOUT
        '
        Me.dtpStartCOUT.CustomFormat = "hh:mm:ss tt"
        Me.dtpStartCOUT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartCOUT.Location = New System.Drawing.Point(141, 194)
        Me.dtpStartCOUT.Name = "dtpStartCOUT"
        Me.dtpStartCOUT.ShowUpDown = True
        Me.dtpStartCOUT.Size = New System.Drawing.Size(110, 21)
        Me.dtpStartCOUT.TabIndex = 9
        Me.dtpStartCOUT.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(9, 226)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Clock OUT End "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndCOUT
        '
        Me.dtpEndCOUT.CustomFormat = "hh:mm:ss tt"
        Me.dtpEndCOUT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndCOUT.Location = New System.Drawing.Point(12, 244)
        Me.dtpEndCOUT.Name = "dtpEndCOUT"
        Me.dtpEndCOUT.ShowUpDown = True
        Me.dtpEndCOUT.Size = New System.Drawing.Size(109, 21)
        Me.dtpEndCOUT.TabIndex = 10
        Me.dtpEndCOUT.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(138, 226)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Total Work Minutes "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotWMins
        '
        Me.txtTotWMins.Location = New System.Drawing.Point(141, 244)
        Me.txtTotWMins.Name = "txtTotWMins"
        Me.txtTotWMins.Size = New System.Drawing.Size(110, 21)
        Me.txtTotWMins.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(9, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Shift ID "
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShiftID
        '
        Me.txtShiftID.Location = New System.Drawing.Point(12, 24)
        Me.txtShiftID.Name = "txtShiftID"
        Me.txtShiftID.Size = New System.Drawing.Size(109, 21)
        Me.txtShiftID.TabIndex = 0
        Me.txtShiftID.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(9, 276)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Day Count "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDayCount
        '
        Me.txtDayCount.Location = New System.Drawing.Point(12, 293)
        Me.txtDayCount.Name = "txtDayCount"
        Me.txtDayCount.Size = New System.Drawing.Size(109, 21)
        Me.txtDayCount.TabIndex = 12
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.Transparent
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.Button2)
        Me.pnlTop.Controls.Add(Me.Button4)
        Me.pnlTop.Controls.Add(Me.Label14)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(656, 48)
        Me.pnlTop.TabIndex = 3
        Me.pnlTop.Tag = "1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(9, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(581, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 81
        Me.Button2.Tag = "3"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.Location = New System.Drawing.Point(617, 10)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(28, 28)
        Me.Button4.TabIndex = 82
        Me.Button4.Tag = "3"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(64, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(152, 14)
        Me.Label14.TabIndex = 80
        Me.Label14.Text = "Setup Company Shifts"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkOpenShift
        '
        Me.chkOpenShift.AutoSize = True
        Me.chkOpenShift.Checked = True
        Me.chkOpenShift.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpenShift.Location = New System.Drawing.Point(141, 297)
        Me.chkOpenShift.Name = "chkOpenShift"
        Me.chkOpenShift.Size = New System.Drawing.Size(90, 17)
        Me.chkOpenShift.TabIndex = 17
        Me.chkOpenShift.Text = "Open Shift "
        Me.chkOpenShift.UseVisualStyleBackColor = True
        Me.chkOpenShift.Visible = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.Transparent
        Me.cmdClose.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.Color.White
        Me.cmdClose.Location = New System.Drawing.Point(373, 11)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(88, 26)
        Me.cmdClose.TabIndex = 16
        Me.cmdClose.Tag = "1"
        Me.cmdClose.Text = "C&lose"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.Color.White
        Me.cmdRefresh.Location = New System.Drawing.Point(279, 11)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(88, 26)
        Me.cmdRefresh.TabIndex = 15
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.Text = "R&efresh"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.Transparent
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(185, 11)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(88, 26)
        Me.cmdSave.TabIndex = 14
        Me.cmdSave.Tag = "1"
        Me.cmdSave.Text = "S&ave"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(656, 2)
        Me.Label2.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(144, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Short Code "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShortCode
        '
        Me.txtShortCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShortCode.Location = New System.Drawing.Point(141, 24)
        Me.txtShortCode.MaxLength = 3
        Me.txtShortCode.Name = "txtShortCode"
        Me.txtShortCode.Size = New System.Drawing.Size(110, 21)
        Me.txtShortCode.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(300, 370)
        Me.TabControl1.TabIndex = 28
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkWrkMin)
        Me.TabPage1.Controls.Add(Me.chkStrShift)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.chkOpenShift)
        Me.TabPage1.Controls.Add(Me.txtShiftName)
        Me.TabPage1.Controls.Add(Me.dtpEndCOUT)
        Me.TabPage1.Controls.Add(Me.txtShortCode)
        Me.TabPage1.Controls.Add(Me.dtpStartCOUT)
        Me.TabPage1.Controls.Add(Me.txtTotWMins)
        Me.TabPage1.Controls.Add(Me.dtpStartCIN)
        Me.TabPage1.Controls.Add(Me.txtDayCount)
        Me.TabPage1.Controls.Add(Me.dtpShiftEnd)
        Me.TabPage1.Controls.Add(Me.txtShiftID)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.dtpShitStart)
        Me.TabPage1.Controls.Add(Me.optDay)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.opt24Hour)
        Me.TabPage1.Controls.Add(Me.optNight)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(292, 344)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Shift Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkWrkMin
        '
        Me.chkWrkMin.AutoSize = True
        Me.chkWrkMin.Location = New System.Drawing.Point(12, 325)
        Me.chkWrkMin.Name = "chkWrkMin"
        Me.chkWrkMin.Size = New System.Drawing.Size(181, 17)
        Me.chkWrkMin.TabIndex = 19
        Me.chkWrkMin.Text = "OT Based On Work Minutes"
        Me.chkWrkMin.UseVisualStyleBackColor = True
        '
        'chkStrShift
        '
        Me.chkStrShift.AutoSize = True
        Me.chkStrShift.Location = New System.Drawing.Point(141, 273)
        Me.chkStrShift.Name = "chkStrShift"
        Me.chkStrShift.Size = New System.Drawing.Size(87, 17)
        Me.chkStrShift.TabIndex = 18
        Me.chkStrShift.Text = "Strait Shift"
        Me.chkStrShift.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(292, 344)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Shift Parameters"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.dgvShifts)
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(656, 428)
        Me.Panel2.TabIndex = 29
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Location = New System.Drawing.Point(385, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(263, 2)
        Me.Label17.TabIndex = 118
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(310, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 117
        Me.Label3.Text = "Shift List"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblDesciption)
        Me.Panel3.Controls.Add(Me.cmdSave)
        Me.Panel3.Controls.Add(Me.cmdRefresh)
        Me.Panel3.Controls.Add(Me.dtpEndCIN)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 384)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(656, 44)
        Me.Panel3.TabIndex = 0
        Me.Panel3.Visible = False
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.ForeColor = System.Drawing.Color.DimGray
        Me.lblDesciption.Location = New System.Drawing.Point(12, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(158, 13)
        Me.lblDesciption.TabIndex = 57
        Me.lblDesciption.Text = "Add all shift configurations"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel2)
        Me.pnlAllk.Controls.Add(Me.pnlTop)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(658, 478)
        Me.pnlAllk.TabIndex = 77
        '
        'frmSetShiftType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(658, 478)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSetShiftType"
        Me.Text = "Shift Management "
        CType(Me.dgvShifts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents dgvShifts As System.Windows.Forms.DataGridView
    Friend WithEvents txtShiftName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents opt24Hour As System.Windows.Forms.RadioButton
    Friend WithEvents optNight As System.Windows.Forms.RadioButton
    Friend WithEvents optDay As System.Windows.Forms.RadioButton
    Friend WithEvents dtpShitStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpShiftEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpStartCIN As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpEndCIN As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpStartCOUT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpEndCOUT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotWMins As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtShiftID As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDayCount As System.Windows.Forms.TextBox
    Friend WithEvents chkOpenShift As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtShortCode As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkWrkMin As System.Windows.Forms.CheckBox
    Friend WithEvents chkStrShift As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ShiftID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OutTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkMin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
