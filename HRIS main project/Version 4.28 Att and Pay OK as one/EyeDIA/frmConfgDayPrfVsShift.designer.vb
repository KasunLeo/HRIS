<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfgDayPrfVsShift
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.cmdCopyPrf = New System.Windows.Forms.Button
        Me.cmdCopy = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdCreateRule = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmbCopy = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.chkCalBegin = New System.Windows.Forms.CheckBox
        Me.txtMaxBeginOT = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.chkNightWEF = New System.Windows.Forms.CheckBox
        Me.chkCalLate = New System.Windows.Forms.CheckBox
        Me.dtpOTStart = New System.Windows.Forms.DateTimePicker
        Me.dtpNightStart = New System.Windows.Forms.DateTimePicker
        Me.chkCalearlyMin = New System.Windows.Forms.CheckBox
        Me.chkOTStart = New System.Windows.Forms.CheckBox
        Me.chkCalShiftIN = New System.Windows.Forms.CheckBox
        Me.chkCalLateMin = New System.Windows.Forms.CheckBox
        Me.chkCalNight = New System.Windows.Forms.CheckBox
        Me.txtLateGrase = New System.Windows.Forms.TextBox
        Me.cmbNrWorkDays = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbLvDays = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbAddDay = New System.Windows.Forms.ComboBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkNOTFrom = New System.Windows.Forms.CheckBox
        Me.chkNormalOT = New System.Windows.Forms.CheckBox
        Me.optNOutTime = New System.Windows.Forms.RadioButton
        Me.txtNWorkMins = New System.Windows.Forms.TextBox
        Me.dtpNOutTime = New System.Windows.Forms.DateTimePicker
        Me.optNWorkMins = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkDOtFrom = New System.Windows.Forms.CheckBox
        Me.chkDoubleOT = New System.Windows.Forms.CheckBox
        Me.optDOutTime = New System.Windows.Forms.RadioButton
        Me.txtDWorkMins = New System.Windows.Forms.TextBox
        Me.dtpDOutTime = New System.Windows.Forms.DateTimePicker
        Me.optDWorkMins = New System.Windows.Forms.RadioButton
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.chkWEFUpOT = New System.Windows.Forms.CheckBox
        Me.chkUpOT = New System.Windows.Forms.CheckBox
        Me.optUaOTTime = New System.Windows.Forms.RadioButton
        Me.txtUpOTmin = New System.Windows.Forms.TextBox
        Me.dtpWEFUpOT = New System.Windows.Forms.DateTimePicker
        Me.optUpOTMins = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkTOTFrom = New System.Windows.Forms.CheckBox
        Me.chkIsTOT = New System.Windows.Forms.CheckBox
        Me.optTOTTIme = New System.Windows.Forms.RadioButton
        Me.txtTotMinutes = New System.Windows.Forms.TextBox
        Me.dtpTOTTime = New System.Windows.Forms.DateTimePicker
        Me.optTOTMinutes = New System.Windows.Forms.RadioButton
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkDDedFrom = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.chkIsDinner = New System.Windows.Forms.CheckBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkDinnerWEF = New System.Windows.Forms.CheckBox
        Me.txtDinnerMins = New System.Windows.Forms.TextBox
        Me.dtpDinnerTime = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkLDedFrom = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.chkIsLunch = New System.Windows.Forms.CheckBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkLunchWEF = New System.Windows.Forms.CheckBox
        Me.txtDedLunchMin = New System.Windows.Forms.TextBox
        Me.dtpDedLunchTime = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.dgvDetails = New System.Windows.Forms.DataGridView
        Me.prfID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dyType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FrMins = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EdMins = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NrMins = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LvDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdDeleteRule = New System.Windows.Forms.Button
        Me.txtEndMins = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStartMins = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbDayType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbShiftName = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.pnlAllkk = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllkk.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 48)
        Me.Panel1.TabIndex = 20
        Me.Panel1.Tag = "1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(9, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 45
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.DimGray
        Me.Label25.Location = New System.Drawing.Point(64, 13)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(267, 18)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Day Type Vs Shift Configuration"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSave
        '
        Me.cmdSave.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSave.FlatAppearance.BorderSize = 0
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(206, 119)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(110, 26)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Tag = "1"
        Me.cmdSave.Text = "&Create Rule"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.TabControl1)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.cmdSave)
        Me.Panel3.Controls.Add(Me.dgvDetails)
        Me.Panel3.Controls.Add(Me.cmdDeleteRule)
        Me.Panel3.Controls.Add(Me.txtEndMins)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtStartMins)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.cmbDayType)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.cmbShiftName)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(922, 484)
        Me.Panel3.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.cmdCopyPrf)
        Me.Panel4.Controls.Add(Me.cmdCopy)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.cmdCreateRule)
        Me.Panel4.Controls.Add(Me.cmdRefresh)
        Me.Panel4.Controls.Add(Me.cmbCopy)
        Me.Panel4.Location = New System.Drawing.Point(1, 389)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(920, 48)
        Me.Panel4.TabIndex = 35
        Me.Panel4.Tag = "1"
        '
        'cmdCopyPrf
        '
        Me.cmdCopyPrf.BackColor = System.Drawing.Color.Transparent
        Me.cmdCopyPrf.BackgroundImage = Global.HRISforBB.My.Resources.Resources.COPPYK
        Me.cmdCopyPrf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdCopyPrf.FlatAppearance.BorderSize = 0
        Me.cmdCopyPrf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCopyPrf.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopyPrf.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdCopyPrf.Location = New System.Drawing.Point(405, 11)
        Me.cmdCopyPrf.Name = "cmdCopyPrf"
        Me.cmdCopyPrf.Size = New System.Drawing.Size(28, 28)
        Me.cmdCopyPrf.TabIndex = 92
        Me.cmdCopyPrf.Tag = "3"
        Me.cmdCopyPrf.UseVisualStyleBackColor = False
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(518, 25)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(23, 23)
        Me.cmdCopy.TabIndex = 24
        Me.cmdCopy.Text = "Copy"
        Me.cmdCopy.UseVisualStyleBackColor = True
        Me.cmdCopy.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Copy Profile To"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCreateRule
        '
        Me.cmdCreateRule.BackColor = System.Drawing.Color.Transparent
        Me.cmdCreateRule.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.cmdCreateRule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdCreateRule.FlatAppearance.BorderSize = 0
        Me.cmdCreateRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCreateRule.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateRule.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdCreateRule.Location = New System.Drawing.Point(848, 10)
        Me.cmdCreateRule.Name = "cmdCreateRule"
        Me.cmdCreateRule.Size = New System.Drawing.Size(28, 28)
        Me.cmdCreateRule.TabIndex = 91
        Me.cmdCreateRule.Tag = "3"
        Me.cmdCreateRule.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(884, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 90
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'cmbCopy
        '
        Me.cmbCopy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCopy.FormattingEnabled = True
        Me.cmbCopy.Location = New System.Drawing.Point(119, 15)
        Me.cmbCopy.Name = "cmbCopy"
        Me.cmbCopy.Size = New System.Drawing.Size(278, 21)
        Me.cmbCopy.TabIndex = 1
        Me.cmbCopy.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 440)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(922, 44)
        Me.Panel2.TabIndex = 34
        Me.Panel2.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(922, 2)
        Me.Label11.TabIndex = 32
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(432, 13)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(485, 377)
        Me.TabControl1.TabIndex = 33
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Controls.Add(Me.chkNightWEF)
        Me.TabPage3.Controls.Add(Me.chkCalLate)
        Me.TabPage3.Controls.Add(Me.dtpOTStart)
        Me.TabPage3.Controls.Add(Me.dtpNightStart)
        Me.TabPage3.Controls.Add(Me.chkCalearlyMin)
        Me.TabPage3.Controls.Add(Me.chkOTStart)
        Me.TabPage3.Controls.Add(Me.chkCalShiftIN)
        Me.TabPage3.Controls.Add(Me.chkCalLateMin)
        Me.TabPage3.Controls.Add(Me.chkCalNight)
        Me.TabPage3.Controls.Add(Me.txtLateGrase)
        Me.TabPage3.Controls.Add(Me.cmbNrWorkDays)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.cmbLvDays)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.cmbAddDay)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(477, 351)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Day Configuration"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkCalBegin)
        Me.GroupBox7.Controls.Add(Me.txtMaxBeginOT)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Location = New System.Drawing.Point(18, 283)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(418, 58)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "                                 "
        Me.GroupBox7.Visible = False
        '
        'chkCalBegin
        '
        Me.chkCalBegin.AutoSize = True
        Me.chkCalBegin.Location = New System.Drawing.Point(10, 3)
        Me.chkCalBegin.Name = "chkCalBegin"
        Me.chkCalBegin.Size = New System.Drawing.Size(135, 17)
        Me.chkCalBegin.TabIndex = 0
        Me.chkCalBegin.Text = "Calculate Begin OT"
        Me.chkCalBegin.UseVisualStyleBackColor = True
        Me.chkCalBegin.Visible = False
        '
        'txtMaxBeginOT
        '
        Me.txtMaxBeginOT.BackColor = System.Drawing.Color.White
        Me.txtMaxBeginOT.Location = New System.Drawing.Point(190, 20)
        Me.txtMaxBeginOT.Name = "txtMaxBeginOT"
        Me.txtMaxBeginOT.Size = New System.Drawing.Size(213, 21)
        Me.txtMaxBeginOT.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(14, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 13)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Begin OT Grace Minutes"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkNightWEF
        '
        Me.chkNightWEF.AutoSize = True
        Me.chkNightWEF.Location = New System.Drawing.Point(310, 130)
        Me.chkNightWEF.Name = "chkNightWEF"
        Me.chkNightWEF.Size = New System.Drawing.Size(107, 17)
        Me.chkNightWEF.TabIndex = 0
        Me.chkNightWEF.Text = "WEF Next Day"
        Me.chkNightWEF.UseVisualStyleBackColor = True
        '
        'chkCalLate
        '
        Me.chkCalLate.AutoSize = True
        Me.chkCalLate.Location = New System.Drawing.Point(28, 103)
        Me.chkCalLate.Name = "chkCalLate"
        Me.chkCalLate.Size = New System.Drawing.Size(149, 17)
        Me.chkCalLate.TabIndex = 0
        Me.chkCalLate.Text = "Grase Minute for Late"
        Me.chkCalLate.UseVisualStyleBackColor = True
        '
        'dtpOTStart
        '
        Me.dtpOTStart.CustomFormat = "hh:mm tt"
        Me.dtpOTStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOTStart.Location = New System.Drawing.Point(208, 155)
        Me.dtpOTStart.Name = "dtpOTStart"
        Me.dtpOTStart.ShowUpDown = True
        Me.dtpOTStart.Size = New System.Drawing.Size(96, 21)
        Me.dtpOTStart.TabIndex = 2
        Me.dtpOTStart.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'dtpNightStart
        '
        Me.dtpNightStart.CustomFormat = "hh:mm tt"
        Me.dtpNightStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNightStart.Location = New System.Drawing.Point(208, 128)
        Me.dtpNightStart.Name = "dtpNightStart"
        Me.dtpNightStart.ShowUpDown = True
        Me.dtpNightStart.Size = New System.Drawing.Size(96, 21)
        Me.dtpNightStart.TabIndex = 2
        Me.dtpNightStart.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'chkCalearlyMin
        '
        Me.chkCalearlyMin.AutoSize = True
        Me.chkCalearlyMin.Location = New System.Drawing.Point(28, 251)
        Me.chkCalearlyMin.Name = "chkCalearlyMin"
        Me.chkCalearlyMin.Size = New System.Drawing.Size(159, 17)
        Me.chkCalearlyMin.TabIndex = 0
        Me.chkCalearlyMin.Text = "Calculate Early Minutes"
        Me.chkCalearlyMin.UseVisualStyleBackColor = True
        '
        'chkOTStart
        '
        Me.chkOTStart.AutoSize = True
        Me.chkOTStart.Location = New System.Drawing.Point(28, 157)
        Me.chkOTStart.Name = "chkOTStart"
        Me.chkOTStart.Size = New System.Drawing.Size(106, 17)
        Me.chkOTStart.TabIndex = 0
        Me.chkOTStart.Text = "OT Start Time"
        Me.chkOTStart.UseVisualStyleBackColor = True
        '
        'chkCalShiftIN
        '
        Me.chkCalShiftIN.AutoSize = True
        Me.chkCalShiftIN.Location = New System.Drawing.Point(28, 185)
        Me.chkCalShiftIN.Name = "chkCalShiftIN"
        Me.chkCalShiftIN.Size = New System.Drawing.Size(230, 17)
        Me.chkCalShiftIN.TabIndex = 0
        Me.chkCalShiftIN.Text = "Calculate Work Hours using Shift IN"
        Me.chkCalShiftIN.UseVisualStyleBackColor = True
        '
        'chkCalLateMin
        '
        Me.chkCalLateMin.AutoSize = True
        Me.chkCalLateMin.Location = New System.Drawing.Point(28, 228)
        Me.chkCalLateMin.Name = "chkCalLateMin"
        Me.chkCalLateMin.Size = New System.Drawing.Size(154, 17)
        Me.chkCalLateMin.TabIndex = 0
        Me.chkCalLateMin.Text = "Calculate Late Minutes"
        Me.chkCalLateMin.UseVisualStyleBackColor = True
        '
        'chkCalNight
        '
        Me.chkCalNight.AutoSize = True
        Me.chkCalNight.Location = New System.Drawing.Point(28, 130)
        Me.chkCalNight.Name = "chkCalNight"
        Me.chkCalNight.Size = New System.Drawing.Size(82, 17)
        Me.chkCalNight.TabIndex = 0
        Me.chkCalNight.Text = "Night Day"
        Me.chkCalNight.UseVisualStyleBackColor = True
        '
        'txtLateGrase
        '
        Me.txtLateGrase.BackColor = System.Drawing.Color.White
        Me.txtLateGrase.Location = New System.Drawing.Point(208, 101)
        Me.txtLateGrase.Name = "txtLateGrase"
        Me.txtLateGrase.Size = New System.Drawing.Size(217, 21)
        Me.txtLateGrase.TabIndex = 22
        '
        'cmbNrWorkDays
        '
        Me.cmbNrWorkDays.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNrWorkDays.FormattingEnabled = True
        Me.cmbNrWorkDays.Items.AddRange(New Object() {"0.0", "0.5", "1.0"})
        Me.cmbNrWorkDays.Location = New System.Drawing.Point(208, 22)
        Me.cmbNrWorkDays.Name = "cmbNrWorkDays"
        Me.cmbNrWorkDays.Size = New System.Drawing.Size(217, 21)
        Me.cmbNrWorkDays.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Normal Work Days "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Leave Days "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLvDays
        '
        Me.cmbLvDays.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLvDays.FormattingEnabled = True
        Me.cmbLvDays.Items.AddRange(New Object() {"0.0", "0.5", "1.0"})
        Me.cmbLvDays.Location = New System.Drawing.Point(208, 48)
        Me.cmbLvDays.Name = "cmbLvDays"
        Me.cmbLvDays.Size = New System.Drawing.Size(217, 21)
        Me.cmbLvDays.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(28, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Additional Day "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbAddDay
        '
        Me.cmbAddDay.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAddDay.FormattingEnabled = True
        Me.cmbAddDay.Items.AddRange(New Object() {"0.0", "0.5", "1.0"})
        Me.cmbAddDay.Location = New System.Drawing.Point(208, 74)
        Me.cmbAddDay.Name = "cmbAddDay"
        Me.cmbAddDay.Size = New System.Drawing.Size(217, 21)
        Me.cmbAddDay.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(477, 351)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configure OT"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkNOTFrom)
        Me.GroupBox1.Controls.Add(Me.chkNormalOT)
        Me.GroupBox1.Controls.Add(Me.optNOutTime)
        Me.GroupBox1.Controls.Add(Me.txtNWorkMins)
        Me.GroupBox1.Controls.Add(Me.dtpNOutTime)
        Me.GroupBox1.Controls.Add(Me.optNWorkMins)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 73)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "                       "
        '
        'chkNOTFrom
        '
        Me.chkNOTFrom.AutoSize = True
        Me.chkNOTFrom.Location = New System.Drawing.Point(293, 18)
        Me.chkNOTFrom.Name = "chkNOTFrom"
        Me.chkNOTFrom.Size = New System.Drawing.Size(107, 17)
        Me.chkNOTFrom.TabIndex = 0
        Me.chkNOTFrom.Text = "WEF Next Day"
        Me.chkNOTFrom.UseVisualStyleBackColor = True
        '
        'chkNormalOT
        '
        Me.chkNormalOT.AutoSize = True
        Me.chkNormalOT.Location = New System.Drawing.Point(9, -1)
        Me.chkNormalOT.Name = "chkNormalOT"
        Me.chkNormalOT.Size = New System.Drawing.Size(87, 17)
        Me.chkNormalOT.TabIndex = 0
        Me.chkNormalOT.Text = "Normal OT"
        Me.chkNormalOT.UseVisualStyleBackColor = True
        '
        'optNOutTime
        '
        Me.optNOutTime.AutoSize = True
        Me.optNOutTime.BackColor = System.Drawing.Color.White
        Me.optNOutTime.Checked = True
        Me.optNOutTime.ForeColor = System.Drawing.Color.Black
        Me.optNOutTime.Location = New System.Drawing.Point(7, 17)
        Me.optNOutTime.Name = "optNOutTime"
        Me.optNOutTime.Size = New System.Drawing.Size(140, 17)
        Me.optNOutTime.TabIndex = 1
        Me.optNOutTime.TabStop = True
        Me.optNOutTime.Text = "Based On Out Time "
        Me.optNOutTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optNOutTime.UseVisualStyleBackColor = False
        '
        'txtNWorkMins
        '
        Me.txtNWorkMins.BackColor = System.Drawing.Color.White
        Me.txtNWorkMins.Location = New System.Drawing.Point(191, 43)
        Me.txtNWorkMins.Name = "txtNWorkMins"
        Me.txtNWorkMins.Size = New System.Drawing.Size(206, 21)
        Me.txtNWorkMins.TabIndex = 4
        '
        'dtpNOutTime
        '
        Me.dtpNOutTime.CustomFormat = "hh:mm tt"
        Me.dtpNOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpNOutTime.Location = New System.Drawing.Point(191, 16)
        Me.dtpNOutTime.Name = "dtpNOutTime"
        Me.dtpNOutTime.ShowUpDown = True
        Me.dtpNOutTime.Size = New System.Drawing.Size(96, 21)
        Me.dtpNOutTime.TabIndex = 2
        Me.dtpNOutTime.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'optNWorkMins
        '
        Me.optNWorkMins.AutoSize = True
        Me.optNWorkMins.BackColor = System.Drawing.Color.White
        Me.optNWorkMins.ForeColor = System.Drawing.Color.Black
        Me.optNWorkMins.Location = New System.Drawing.Point(7, 42)
        Me.optNWorkMins.Name = "optNWorkMins"
        Me.optNWorkMins.Size = New System.Drawing.Size(181, 17)
        Me.optNWorkMins.TabIndex = 3
        Me.optNWorkMins.Text = "Based On Working Minutes "
        Me.optNWorkMins.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optNWorkMins.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDOtFrom)
        Me.GroupBox2.Controls.Add(Me.chkDoubleOT)
        Me.GroupBox2.Controls.Add(Me.optDOutTime)
        Me.GroupBox2.Controls.Add(Me.txtDWorkMins)
        Me.GroupBox2.Controls.Add(Me.dtpDOutTime)
        Me.GroupBox2.Controls.Add(Me.optDWorkMins)
        Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(21, 104)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 73)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "                       "
        '
        'chkDOtFrom
        '
        Me.chkDOtFrom.AutoSize = True
        Me.chkDOtFrom.Location = New System.Drawing.Point(295, 18)
        Me.chkDOtFrom.Name = "chkDOtFrom"
        Me.chkDOtFrom.Size = New System.Drawing.Size(107, 17)
        Me.chkDOtFrom.TabIndex = 0
        Me.chkDOtFrom.Text = "WEF Next Day"
        Me.chkDOtFrom.UseVisualStyleBackColor = True
        '
        'chkDoubleOT
        '
        Me.chkDoubleOT.AutoSize = True
        Me.chkDoubleOT.Location = New System.Drawing.Point(9, -1)
        Me.chkDoubleOT.Name = "chkDoubleOT"
        Me.chkDoubleOT.Size = New System.Drawing.Size(86, 17)
        Me.chkDoubleOT.TabIndex = 0
        Me.chkDoubleOT.Text = "Double OT"
        Me.chkDoubleOT.UseVisualStyleBackColor = True
        '
        'optDOutTime
        '
        Me.optDOutTime.AutoSize = True
        Me.optDOutTime.BackColor = System.Drawing.Color.White
        Me.optDOutTime.Checked = True
        Me.optDOutTime.ForeColor = System.Drawing.Color.Black
        Me.optDOutTime.Location = New System.Drawing.Point(7, 17)
        Me.optDOutTime.Name = "optDOutTime"
        Me.optDOutTime.Size = New System.Drawing.Size(140, 17)
        Me.optDOutTime.TabIndex = 1
        Me.optDOutTime.TabStop = True
        Me.optDOutTime.Text = "Based On Out Time "
        Me.optDOutTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optDOutTime.UseVisualStyleBackColor = False
        '
        'txtDWorkMins
        '
        Me.txtDWorkMins.BackColor = System.Drawing.Color.White
        Me.txtDWorkMins.Location = New System.Drawing.Point(191, 43)
        Me.txtDWorkMins.Name = "txtDWorkMins"
        Me.txtDWorkMins.Size = New System.Drawing.Size(206, 21)
        Me.txtDWorkMins.TabIndex = 4
        '
        'dtpDOutTime
        '
        Me.dtpDOutTime.CustomFormat = "hh:mm tt"
        Me.dtpDOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDOutTime.Location = New System.Drawing.Point(191, 17)
        Me.dtpDOutTime.Name = "dtpDOutTime"
        Me.dtpDOutTime.ShowUpDown = True
        Me.dtpDOutTime.Size = New System.Drawing.Size(96, 21)
        Me.dtpDOutTime.TabIndex = 2
        Me.dtpDOutTime.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'optDWorkMins
        '
        Me.optDWorkMins.AutoSize = True
        Me.optDWorkMins.BackColor = System.Drawing.Color.White
        Me.optDWorkMins.ForeColor = System.Drawing.Color.Black
        Me.optDWorkMins.Location = New System.Drawing.Point(7, 42)
        Me.optDWorkMins.Name = "optDWorkMins"
        Me.optDWorkMins.Size = New System.Drawing.Size(181, 17)
        Me.optDWorkMins.TabIndex = 3
        Me.optDWorkMins.Text = "Based On Working Minutes "
        Me.optDWorkMins.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optDWorkMins.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkWEFUpOT)
        Me.GroupBox6.Controls.Add(Me.chkUpOT)
        Me.GroupBox6.Controls.Add(Me.optUaOTTime)
        Me.GroupBox6.Controls.Add(Me.txtUpOTmin)
        Me.GroupBox6.Controls.Add(Me.dtpWEFUpOT)
        Me.GroupBox6.Controls.Add(Me.optUpOTMins)
        Me.GroupBox6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(21, 262)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(408, 73)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "                       "
        '
        'chkWEFUpOT
        '
        Me.chkWEFUpOT.AutoSize = True
        Me.chkWEFUpOT.Location = New System.Drawing.Point(293, 18)
        Me.chkWEFUpOT.Name = "chkWEFUpOT"
        Me.chkWEFUpOT.Size = New System.Drawing.Size(107, 17)
        Me.chkWEFUpOT.TabIndex = 0
        Me.chkWEFUpOT.Text = "WEF Next Day"
        Me.chkWEFUpOT.UseVisualStyleBackColor = True
        '
        'chkUpOT
        '
        Me.chkUpOT.AutoSize = True
        Me.chkUpOT.Location = New System.Drawing.Point(9, -1)
        Me.chkUpOT.Name = "chkUpOT"
        Me.chkUpOT.Size = New System.Drawing.Size(121, 17)
        Me.chkUpOT.TabIndex = 0
        Me.chkUpOT.Text = "Un-Approved OT"
        Me.chkUpOT.UseVisualStyleBackColor = True
        '
        'optUaOTTime
        '
        Me.optUaOTTime.AutoSize = True
        Me.optUaOTTime.BackColor = System.Drawing.Color.White
        Me.optUaOTTime.Checked = True
        Me.optUaOTTime.ForeColor = System.Drawing.Color.Black
        Me.optUaOTTime.Location = New System.Drawing.Point(7, 17)
        Me.optUaOTTime.Name = "optUaOTTime"
        Me.optUaOTTime.Size = New System.Drawing.Size(140, 17)
        Me.optUaOTTime.TabIndex = 1
        Me.optUaOTTime.TabStop = True
        Me.optUaOTTime.Text = "Based On Out Time "
        Me.optUaOTTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optUaOTTime.UseVisualStyleBackColor = False
        '
        'txtUpOTmin
        '
        Me.txtUpOTmin.BackColor = System.Drawing.Color.White
        Me.txtUpOTmin.Location = New System.Drawing.Point(191, 43)
        Me.txtUpOTmin.Name = "txtUpOTmin"
        Me.txtUpOTmin.Size = New System.Drawing.Size(206, 21)
        Me.txtUpOTmin.TabIndex = 4
        '
        'dtpWEFUpOT
        '
        Me.dtpWEFUpOT.CustomFormat = "hh:mm tt"
        Me.dtpWEFUpOT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWEFUpOT.Location = New System.Drawing.Point(191, 17)
        Me.dtpWEFUpOT.Name = "dtpWEFUpOT"
        Me.dtpWEFUpOT.ShowUpDown = True
        Me.dtpWEFUpOT.Size = New System.Drawing.Size(96, 21)
        Me.dtpWEFUpOT.TabIndex = 2
        Me.dtpWEFUpOT.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'optUpOTMins
        '
        Me.optUpOTMins.AutoSize = True
        Me.optUpOTMins.BackColor = System.Drawing.Color.White
        Me.optUpOTMins.ForeColor = System.Drawing.Color.Black
        Me.optUpOTMins.Location = New System.Drawing.Point(7, 42)
        Me.optUpOTMins.Name = "optUpOTMins"
        Me.optUpOTMins.Size = New System.Drawing.Size(181, 17)
        Me.optUpOTMins.TabIndex = 3
        Me.optUpOTMins.Text = "Based On Working Minutes "
        Me.optUpOTMins.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optUpOTMins.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkTOTFrom)
        Me.GroupBox3.Controls.Add(Me.chkIsTOT)
        Me.GroupBox3.Controls.Add(Me.optTOTTIme)
        Me.GroupBox3.Controls.Add(Me.txtTotMinutes)
        Me.GroupBox3.Controls.Add(Me.dtpTOTTime)
        Me.GroupBox3.Controls.Add(Me.optTOTMinutes)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(21, 183)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(408, 73)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "                       "
        '
        'chkTOTFrom
        '
        Me.chkTOTFrom.AutoSize = True
        Me.chkTOTFrom.Location = New System.Drawing.Point(293, 18)
        Me.chkTOTFrom.Name = "chkTOTFrom"
        Me.chkTOTFrom.Size = New System.Drawing.Size(107, 17)
        Me.chkTOTFrom.TabIndex = 0
        Me.chkTOTFrom.Text = "WEF Next Day"
        Me.chkTOTFrom.UseVisualStyleBackColor = True
        '
        'chkIsTOT
        '
        Me.chkIsTOT.AutoSize = True
        Me.chkIsTOT.Location = New System.Drawing.Point(9, -1)
        Me.chkIsTOT.Name = "chkIsTOT"
        Me.chkIsTOT.Size = New System.Drawing.Size(77, 17)
        Me.chkIsTOT.TabIndex = 0
        Me.chkIsTOT.Text = "Triple OT"
        Me.chkIsTOT.UseVisualStyleBackColor = True
        '
        'optTOTTIme
        '
        Me.optTOTTIme.AutoSize = True
        Me.optTOTTIme.BackColor = System.Drawing.Color.White
        Me.optTOTTIme.Checked = True
        Me.optTOTTIme.ForeColor = System.Drawing.Color.Black
        Me.optTOTTIme.Location = New System.Drawing.Point(7, 17)
        Me.optTOTTIme.Name = "optTOTTIme"
        Me.optTOTTIme.Size = New System.Drawing.Size(140, 17)
        Me.optTOTTIme.TabIndex = 1
        Me.optTOTTIme.TabStop = True
        Me.optTOTTIme.Text = "Based On Out Time "
        Me.optTOTTIme.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optTOTTIme.UseVisualStyleBackColor = False
        '
        'txtTotMinutes
        '
        Me.txtTotMinutes.BackColor = System.Drawing.Color.White
        Me.txtTotMinutes.Location = New System.Drawing.Point(191, 43)
        Me.txtTotMinutes.Name = "txtTotMinutes"
        Me.txtTotMinutes.Size = New System.Drawing.Size(206, 21)
        Me.txtTotMinutes.TabIndex = 4
        '
        'dtpTOTTime
        '
        Me.dtpTOTTime.CustomFormat = "hh:mm tt"
        Me.dtpTOTTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTOTTime.Location = New System.Drawing.Point(191, 17)
        Me.dtpTOTTime.Name = "dtpTOTTime"
        Me.dtpTOTTime.ShowUpDown = True
        Me.dtpTOTTime.Size = New System.Drawing.Size(96, 21)
        Me.dtpTOTTime.TabIndex = 2
        Me.dtpTOTTime.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'optTOTMinutes
        '
        Me.optTOTMinutes.AutoSize = True
        Me.optTOTMinutes.BackColor = System.Drawing.Color.White
        Me.optTOTMinutes.ForeColor = System.Drawing.Color.Black
        Me.optTOTMinutes.Location = New System.Drawing.Point(7, 42)
        Me.optTOTMinutes.Name = "optTOTMinutes"
        Me.optTOTMinutes.Size = New System.Drawing.Size(181, 17)
        Me.optTOTMinutes.TabIndex = 3
        Me.optTOTMinutes.Text = "Based On Working Minutes "
        Me.optTOTMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optTOTMinutes.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(477, 351)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Meal Deductions"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkDDedFrom)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.chkIsDinner)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.chkDinnerWEF)
        Me.GroupBox5.Controls.Add(Me.txtDinnerMins)
        Me.GroupBox5.Controls.Add(Me.dtpDinnerTime)
        Me.GroupBox5.Location = New System.Drawing.Point(16, 135)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(440, 121)
        Me.GroupBox5.TabIndex = 24
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Dinner Deductions"
        '
        'chkDDedFrom
        '
        Me.chkDDedFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDDedFrom.FormattingEnabled = True
        Me.chkDDedFrom.Items.AddRange(New Object() {"Normal OT", "Double OT", "Triple OT", "Worked Hours"})
        Me.chkDDedFrom.Location = New System.Drawing.Point(214, 81)
        Me.chkDDedFrom.Name = "chkDDedFrom"
        Me.chkDDedFrom.Size = New System.Drawing.Size(217, 21)
        Me.chkDDedFrom.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(28, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Dinner Deduct From"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkIsDinner
        '
        Me.chkIsDinner.AutoSize = True
        Me.chkIsDinner.Location = New System.Drawing.Point(28, 29)
        Me.chkIsDinner.Name = "chkIsDinner"
        Me.chkIsDinner.Size = New System.Drawing.Size(155, 17)
        Me.chkIsDinner.TabIndex = 0
        Me.chkIsDinner.Text = "Deduct Dinner Minutes"
        Me.chkIsDinner.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(28, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Dinner Deduct From"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkDinnerWEF
        '
        Me.chkDinnerWEF.AutoSize = True
        Me.chkDinnerWEF.Location = New System.Drawing.Point(319, 56)
        Me.chkDinnerWEF.Name = "chkDinnerWEF"
        Me.chkDinnerWEF.Size = New System.Drawing.Size(107, 17)
        Me.chkDinnerWEF.TabIndex = 0
        Me.chkDinnerWEF.Text = "WEF Next Day"
        Me.chkDinnerWEF.UseVisualStyleBackColor = True
        '
        'txtDinnerMins
        '
        Me.txtDinnerMins.BackColor = System.Drawing.Color.White
        Me.txtDinnerMins.Location = New System.Drawing.Point(214, 27)
        Me.txtDinnerMins.Name = "txtDinnerMins"
        Me.txtDinnerMins.Size = New System.Drawing.Size(99, 21)
        Me.txtDinnerMins.TabIndex = 4
        '
        'dtpDinnerTime
        '
        Me.dtpDinnerTime.CustomFormat = "hh:mm tt"
        Me.dtpDinnerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDinnerTime.Location = New System.Drawing.Point(214, 54)
        Me.dtpDinnerTime.Name = "dtpDinnerTime"
        Me.dtpDinnerTime.ShowUpDown = True
        Me.dtpDinnerTime.Size = New System.Drawing.Size(96, 21)
        Me.dtpDinnerTime.TabIndex = 2
        Me.dtpDinnerTime.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkLDedFrom)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.chkIsLunch)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.chkLunchWEF)
        Me.GroupBox4.Controls.Add(Me.txtDedLunchMin)
        Me.GroupBox4.Controls.Add(Me.dtpDedLunchTime)
        Me.GroupBox4.Location = New System.Drawing.Point(16, 11)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(440, 118)
        Me.GroupBox4.TabIndex = 24
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Lunch Deductions"
        '
        'chkLDedFrom
        '
        Me.chkLDedFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLDedFrom.FormattingEnabled = True
        Me.chkLDedFrom.Items.AddRange(New Object() {"Normal OT", "Double OT", "Triple OT", "Worked Hours"})
        Me.chkLDedFrom.Location = New System.Drawing.Point(214, 73)
        Me.chkLDedFrom.Name = "chkLDedFrom"
        Me.chkLDedFrom.Size = New System.Drawing.Size(217, 21)
        Me.chkLDedFrom.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(23, 77)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Lunch Deduct From"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkIsLunch
        '
        Me.chkIsLunch.AutoSize = True
        Me.chkIsLunch.Location = New System.Drawing.Point(23, 20)
        Me.chkIsLunch.Name = "chkIsLunch"
        Me.chkIsLunch.Size = New System.Drawing.Size(150, 17)
        Me.chkIsLunch.TabIndex = 0
        Me.chkIsLunch.Text = "Deduct Lunch Minutes"
        Me.chkIsLunch.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(23, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Lunch Deduct From"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkLunchWEF
        '
        Me.chkLunchWEF.AutoSize = True
        Me.chkLunchWEF.Location = New System.Drawing.Point(319, 47)
        Me.chkLunchWEF.Name = "chkLunchWEF"
        Me.chkLunchWEF.Size = New System.Drawing.Size(107, 17)
        Me.chkLunchWEF.TabIndex = 0
        Me.chkLunchWEF.Text = "WEF Next Day"
        Me.chkLunchWEF.UseVisualStyleBackColor = True
        '
        'txtDedLunchMin
        '
        Me.txtDedLunchMin.BackColor = System.Drawing.Color.White
        Me.txtDedLunchMin.Location = New System.Drawing.Point(217, 18)
        Me.txtDedLunchMin.Name = "txtDedLunchMin"
        Me.txtDedLunchMin.Size = New System.Drawing.Size(96, 21)
        Me.txtDedLunchMin.TabIndex = 4
        '
        'dtpDedLunchTime
        '
        Me.dtpDedLunchTime.CustomFormat = "hh:mm tt"
        Me.dtpDedLunchTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDedLunchTime.Location = New System.Drawing.Point(217, 45)
        Me.dtpDedLunchTime.Name = "dtpDedLunchTime"
        Me.dtpDedLunchTime.ShowUpDown = True
        Me.dtpDedLunchTime.Size = New System.Drawing.Size(96, 21)
        Me.dtpDedLunchTime.TabIndex = 2
        Me.dtpDedLunchTime.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Location = New System.Drawing.Point(205, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(220, 2)
        Me.Label10.TabIndex = 31
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prfID, Me.dyType, Me.FrMins, Me.EdMins, Me.NrMins, Me.LvDays})
        Me.dgvDetails.GridColor = System.Drawing.Color.White
        Me.dgvDetails.Location = New System.Drawing.Point(3, 184)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowHeadersWidth = 12
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(420, 203)
        Me.dgvDetails.TabIndex = 6
        Me.dgvDetails.TabStop = False
        Me.dgvDetails.Tag = "1"
        '
        'prfID
        '
        Me.prfID.HeaderText = "Profile ID"
        Me.prfID.Name = "prfID"
        Me.prfID.ReadOnly = True
        Me.prfID.Visible = False
        '
        'dyType
        '
        Me.dyType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.dyType.HeaderText = "Day Type"
        Me.dyType.Name = "dyType"
        Me.dyType.ReadOnly = True
        Me.dyType.Width = 86
        '
        'FrMins
        '
        Me.FrMins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FrMins.HeaderText = "Start Mins"
        Me.FrMins.Name = "FrMins"
        Me.FrMins.ReadOnly = True
        '
        'EdMins
        '
        Me.EdMins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.EdMins.HeaderText = "End Mins"
        Me.EdMins.Name = "EdMins"
        Me.EdMins.ReadOnly = True
        Me.EdMins.Width = 82
        '
        'NrMins
        '
        Me.NrMins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NrMins.HeaderText = "NR Days"
        Me.NrMins.Name = "NrMins"
        Me.NrMins.ReadOnly = True
        Me.NrMins.Width = 81
        '
        'LvDays
        '
        Me.LvDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LvDays.HeaderText = "LV Days"
        Me.LvDays.Name = "LvDays"
        Me.LvDays.ReadOnly = True
        Me.LvDays.Width = 78
        '
        'cmdDeleteRule
        '
        Me.cmdDeleteRule.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.cmdDeleteRule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDeleteRule.FlatAppearance.BorderSize = 0
        Me.cmdDeleteRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDeleteRule.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteRule.ForeColor = System.Drawing.Color.White
        Me.cmdDeleteRule.Location = New System.Drawing.Point(322, 119)
        Me.cmdDeleteRule.Name = "cmdDeleteRule"
        Me.cmdDeleteRule.Size = New System.Drawing.Size(100, 26)
        Me.cmdDeleteRule.TabIndex = 2
        Me.cmdDeleteRule.Tag = "1"
        Me.cmdDeleteRule.Text = "&Delete Rule"
        Me.cmdDeleteRule.UseVisualStyleBackColor = True
        '
        'txtEndMins
        '
        Me.txtEndMins.BackColor = System.Drawing.Color.White
        Me.txtEndMins.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndMins.Location = New System.Drawing.Point(166, 92)
        Me.txtEndMins.Name = "txtEndMins"
        Me.txtEndMins.Size = New System.Drawing.Size(257, 21)
        Me.txtEndMins.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Ending Minutes "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStartMins
        '
        Me.txtStartMins.BackColor = System.Drawing.Color.White
        Me.txtStartMins.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartMins.Location = New System.Drawing.Point(166, 66)
        Me.txtStartMins.Name = "txtStartMins"
        Me.txtStartMins.Size = New System.Drawing.Size(257, 21)
        Me.txtStartMins.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(22, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Starting Minutes "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDayType
        '
        Me.cmbDayType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDayType.FormattingEnabled = True
        Me.cmbDayType.Items.AddRange(New Object() {"0.0", "0.5", "1.0"})
        Me.cmbDayType.Location = New System.Drawing.Point(166, 39)
        Me.cmbDayType.Name = "cmbDayType"
        Me.cmbDayType.Size = New System.Drawing.Size(257, 21)
        Me.cmbDayType.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Day Type "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbShiftName
        '
        Me.cmbShiftName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShiftName.FormattingEnabled = True
        Me.cmbShiftName.Items.AddRange(New Object() {"0.0", "0.5", "1.0"})
        Me.cmbShiftName.Location = New System.Drawing.Point(166, 13)
        Me.cmbShiftName.Name = "cmbShiftName"
        Me.cmbShiftName.Size = New System.Drawing.Size(257, 21)
        Me.cmbShiftName.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(5, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Added Shift Configuration List"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(21, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Shift Name "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlAllkk
        '
        Me.pnlAllkk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllkk.Controls.Add(Me.Panel3)
        Me.pnlAllkk.Controls.Add(Me.Panel1)
        Me.pnlAllkk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllkk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllkk.Name = "pnlAllkk"
        Me.pnlAllkk.Size = New System.Drawing.Size(924, 534)
        Me.pnlAllkk.TabIndex = 47
        '
        'frmConfgDayPrfVsShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 534)
        Me.Controls.Add(Me.pnlAllkk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmConfgDayPrfVsShift"
        Me.Text = "Day Type Vs Shift Configuration"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllkk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbDayType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbShiftName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtEndMins As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStartMins As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbLvDays As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbNrWorkDays As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents optNOutTime As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optDOutTime As System.Windows.Forms.RadioButton
    Friend WithEvents txtDWorkMins As System.Windows.Forms.TextBox
    Friend WithEvents dtpDOutTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents optDWorkMins As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNWorkMins As System.Windows.Forms.TextBox
    Friend WithEvents dtpNOutTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents optNWorkMins As System.Windows.Forms.RadioButton
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents chkNormalOT As System.Windows.Forms.CheckBox
    Friend WithEvents chkDoubleOT As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents cmbCopy As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbAddDay As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIsTOT As System.Windows.Forms.CheckBox
    Friend WithEvents optTOTTIme As System.Windows.Forms.RadioButton
    Friend WithEvents txtTotMinutes As System.Windows.Forms.TextBox
    Friend WithEvents dtpTOTTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents optTOTMinutes As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents chkNOTFrom As System.Windows.Forms.CheckBox
    Friend WithEvents chkDOtFrom As System.Windows.Forms.CheckBox
    Friend WithEvents chkTOTFrom As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtLateGrase As System.Windows.Forms.TextBox
    Friend WithEvents chkLunchWEF As System.Windows.Forms.CheckBox
    Friend WithEvents chkIsLunch As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDedLunchTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkDinnerWEF As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDinnerTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkIsDinner As System.Windows.Forms.CheckBox
    Friend WithEvents txtDinnerMins As System.Windows.Forms.TextBox
    Friend WithEvents txtDedLunchMin As System.Windows.Forms.TextBox
    Friend WithEvents chkNightWEF As System.Windows.Forms.CheckBox
    Friend WithEvents chkCalLate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpNightStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkCalNight As System.Windows.Forms.CheckBox
    Friend WithEvents cmdDeleteRule As System.Windows.Forms.Button
    Friend WithEvents prfID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dyType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FrMins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EdMins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NrMins As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkCalearlyMin As System.Windows.Forms.CheckBox
    Friend WithEvents chkCalLateMin As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkWEFUpOT As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpOT As System.Windows.Forms.CheckBox
    Friend WithEvents optUaOTTime As System.Windows.Forms.RadioButton
    Friend WithEvents txtUpOTmin As System.Windows.Forms.TextBox
    Friend WithEvents dtpWEFUpOT As System.Windows.Forms.DateTimePicker
    Friend WithEvents optUpOTMins As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMaxBeginOT As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpOTStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkOTStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkDDedFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chkLDedFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents chkCalShiftIN As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkCalBegin As System.Windows.Forms.CheckBox
    Friend WithEvents pnlAllkk As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmdCreateRule As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdCopyPrf As System.Windows.Forms.Button
End Class
