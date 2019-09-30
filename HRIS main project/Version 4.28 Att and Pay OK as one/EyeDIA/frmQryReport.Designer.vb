<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQryReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.crDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayCol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dgvReportG = New System.Windows.Forms.DataGridView
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.cid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label13 = New System.Windows.Forms.Label
        Me.PicKasun = New System.Windows.Forms.PictureBox
        Me.lblProcessing = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCoun = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdbDOT = New System.Windows.Forms.RadioButton
        Me.rdbNOT = New System.Windows.Forms.RadioButton
        Me.rdbLetter = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReportG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicKasun, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAllk.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.crDate, Me.DayCol})
        Me.DataGridView1.Location = New System.Drawing.Point(601, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(161, 29)
        Me.DataGridView1.TabIndex = 0
        Me.DataGridView1.Visible = False
        '
        'crDate
        '
        Me.crDate.HeaderText = "Cr Date"
        Me.crDate.Name = "crDate"
        Me.crDate.ReadOnly = True
        '
        'DayCol
        '
        Me.DayCol.HeaderText = "DayCol"
        Me.DayCol.Name = "DayCol"
        Me.DayCol.ReadOnly = True
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(83, 9)
        Me.dtpFromDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(113, 21)
        Me.dtpFromDate.TabIndex = 6
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(277, 9)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(113, 21)
        Me.dtpToDate.TabIndex = 7
        '
        'dgvReportG
        '
        Me.dgvReportG.AllowUserToAddRows = False
        Me.dgvReportG.BackgroundColor = System.Drawing.Color.White
        Me.dgvReportG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReportG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReportG.GridColor = System.Drawing.Color.DimGray
        Me.dgvReportG.Location = New System.Drawing.Point(0, 0)
        Me.dgvReportG.Name = "dgvReportG"
        Me.dgvReportG.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportG.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReportG.RowHeadersWidth = 12
        Me.dgvReportG.RowTemplate.Height = 25
        Me.dgvReportG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportG.Size = New System.Drawing.Size(1003, 434)
        Me.dgvReportG.TabIndex = 0
        Me.dgvReportG.Tag = "1"
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.Button1)
        Me.pnlTop.Controls.Add(Me.btnRefresh)
        Me.pnlTop.Controls.Add(Me.Button3)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.DataGridView2)
        Me.pnlTop.Controls.Add(Me.Label13)
        Me.pnlTop.Controls.Add(Me.DataGridView1)
        Me.pnlTop.Controls.Add(Me.PicKasun)
        Me.pnlTop.Controls.Add(Me.lblProcessing)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(1003, 48)
        Me.pnlTop.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.sv
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(900, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 85
        Me.Button1.Tag = "3"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnRefresh.FlatAppearance.BorderSize = 0
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRefresh.Location = New System.Drawing.Point(968, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(28, 28)
        Me.btnRefresh.TabIndex = 84
        Me.btnRefresh.Tag = "3"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.lkkkk
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(934, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 83
        Me.Button3.Tag = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(6, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 43
        Me.PictureBox1.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cid, Me.cname, Me.shCode})
        Me.DataGridView2.Location = New System.Drawing.Point(312, 12)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(192, 35)
        Me.DataGridView2.TabIndex = 1
        Me.DataGridView2.Visible = False
        '
        'cid
        '
        Me.cid.HeaderText = "id"
        Me.cid.Name = "cid"
        Me.cid.ReadOnly = True
        '
        'cname
        '
        Me.cname.HeaderText = "name"
        Me.cname.Name = "cname"
        Me.cname.ReadOnly = True
        '
        'shCode
        '
        Me.shCode.HeaderText = "shCode"
        Me.shCode.Name = "shCode"
        Me.shCode.ReadOnly = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(61, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(203, 18)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "IN/OUT Report to Excel"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PicKasun
        '
        Me.PicKasun.BackColor = System.Drawing.Color.Transparent
        Me.PicKasun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicKasun.Image = Global.HRISforBB.My.Resources.Resources.ProcesRotating
        Me.PicKasun.Location = New System.Drawing.Point(868, 13)
        Me.PicKasun.Name = "PicKasun"
        Me.PicKasun.Size = New System.Drawing.Size(19, 20)
        Me.PicKasun.TabIndex = 21
        Me.PicKasun.TabStop = False
        Me.PicKasun.Visible = False
        '
        'lblProcessing
        '
        Me.lblProcessing.AutoSize = True
        Me.lblProcessing.BackColor = System.Drawing.Color.Transparent
        Me.lblProcessing.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessing.ForeColor = System.Drawing.Color.DarkGray
        Me.lblProcessing.Location = New System.Drawing.Point(768, 17)
        Me.lblProcessing.Name = "lblProcessing"
        Me.lblProcessing.Size = New System.Drawing.Size(94, 13)
        Me.lblProcessing.TabIndex = 22
        Me.lblProcessing.Text = "Processing...."
        Me.lblProcessing.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1003, 517)
        Me.Panel3.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvReportG)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1003, 478)
        Me.Panel4.TabIndex = 23
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.lblCoun)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 434)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1003, 44)
        Me.Panel5.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(8, 1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(942, 2)
        Me.Label3.TabIndex = 34
        '
        'lblCoun
        '
        Me.lblCoun.AutoSize = True
        Me.lblCoun.Location = New System.Drawing.Point(12, 10)
        Me.lblCoun.Name = "lblCoun"
        Me.lblCoun.Size = New System.Drawing.Size(0, 13)
        Me.lblCoun.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.notcurved46
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.rdbDOT)
        Me.Panel2.Controls.Add(Me.rdbNOT)
        Me.Panel2.Controls.Add(Me.rdbLetter)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dtpFromDate)
        Me.Panel2.Controls.Add(Me.dtpToDate)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1003, 39)
        Me.Panel2.TabIndex = 22
        '
        'rdbDOT
        '
        Me.rdbDOT.AutoSize = True
        Me.rdbDOT.BackColor = System.Drawing.Color.Transparent
        Me.rdbDOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rdbDOT.Location = New System.Drawing.Point(624, 11)
        Me.rdbDOT.Name = "rdbDOT"
        Me.rdbDOT.Size = New System.Drawing.Size(92, 17)
        Me.rdbDOT.TabIndex = 36
        Me.rdbDOT.TabStop = True
        Me.rdbDOT.Text = "DOT Report"
        Me.rdbDOT.UseVisualStyleBackColor = False
        '
        'rdbNOT
        '
        Me.rdbNOT.AutoSize = True
        Me.rdbNOT.BackColor = System.Drawing.Color.Transparent
        Me.rdbNOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rdbNOT.Location = New System.Drawing.Point(531, 11)
        Me.rdbNOT.Name = "rdbNOT"
        Me.rdbNOT.Size = New System.Drawing.Size(91, 17)
        Me.rdbNOT.TabIndex = 35
        Me.rdbNOT.TabStop = True
        Me.rdbNOT.Text = "NOT Report"
        Me.rdbNOT.UseVisualStyleBackColor = False
        '
        'rdbLetter
        '
        Me.rdbLetter.AutoSize = True
        Me.rdbLetter.BackColor = System.Drawing.Color.Transparent
        Me.rdbLetter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rdbLetter.Location = New System.Drawing.Point(395, 11)
        Me.rdbLetter.Name = "rdbLetter"
        Me.rdbLetter.Size = New System.Drawing.Size(132, 17)
        Me.rdbLetter.TabIndex = 2
        Me.rdbLetter.TabStop = True
        Me.rdbLetter.Text = "Short Code Report"
        Me.rdbLetter.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gray
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(0, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1003, 2)
        Me.Label2.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(215, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "To Date"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(3, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "From Date"
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel3)
        Me.pnlAllk.Controls.Add(Me.pnlTop)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(1005, 567)
        Me.pnlAllk.TabIndex = 23
        '
        'frmQryReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 567)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmQryReport"
        Me.Text = "frmQryReport"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReportG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicKasun, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents crDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayCol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvReportG As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PicKasun As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblProcessing As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents cid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdbLetter As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNOT As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblCoun As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rdbDOT As System.Windows.Forms.RadioButton
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
