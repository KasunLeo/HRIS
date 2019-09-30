<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpLeave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpLeave))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtLvQty = New System.Windows.Forms.TextBox
        Me.dgvLvHist = New System.Windows.Forms.DataGridView
        Me.lvID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lvName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LvQt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LvTkn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BalLv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtLvName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdReport = New System.Windows.Forms.Button
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.dgvLvHistory = New System.Windows.Forms.DataGridView
        Me.LvDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LvType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Levname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoLev = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFrDate = New System.Windows.Forms.DateTimePicker
        Me.pnlAllData = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvLvHist, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvLvHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllData.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1012, 437)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtLvQty)
        Me.TabPage1.Controls.Add(Me.dgvLvHist)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtLvName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1004, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Leave Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtLvQty
        '
        Me.txtLvQty.BackColor = System.Drawing.Color.White
        Me.txtLvQty.Location = New System.Drawing.Point(423, 50)
        Me.txtLvQty.Name = "txtLvQty"
        Me.txtLvQty.Size = New System.Drawing.Size(168, 21)
        Me.txtLvQty.TabIndex = 19
        '
        'dgvLvHist
        '
        Me.dgvLvHist.AllowUserToAddRows = False
        Me.dgvLvHist.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvLvHist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLvHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLvHist.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.lvID, Me.lvName, Me.LvQt, Me.LvTkn, Me.BalLv})
        Me.dgvLvHist.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvLvHist.Location = New System.Drawing.Point(8, 109)
        Me.dgvLvHist.Name = "dgvLvHist"
        Me.dgvLvHist.ReadOnly = True
        Me.dgvLvHist.RowHeadersVisible = False
        Me.dgvLvHist.RowHeadersWidth = 12
        Me.dgvLvHist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLvHist.Size = New System.Drawing.Size(990, 294)
        Me.dgvLvHist.TabIndex = 1
        Me.dgvLvHist.Tag = "1"
        '
        'lvID
        '
        Me.lvID.HeaderText = "Type ID"
        Me.lvID.Name = "lvID"
        Me.lvID.ReadOnly = True
        '
        'lvName
        '
        Me.lvName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.lvName.HeaderText = "Leave Type"
        Me.lvName.Name = "lvName"
        Me.lvName.ReadOnly = True
        '
        'LvQt
        '
        Me.LvQt.HeaderText = "Leave Entitle"
        Me.LvQt.Name = "LvQt"
        Me.LvQt.ReadOnly = True
        Me.LvQt.Width = 133
        '
        'LvTkn
        '
        Me.LvTkn.HeaderText = "Leave Taken"
        Me.LvTkn.Name = "LvTkn"
        Me.LvTkn.ReadOnly = True
        Me.LvTkn.Width = 133
        '
        'BalLv
        '
        Me.BalLv.HeaderText = "Leave balance"
        Me.BalLv.Name = "BalLv"
        Me.BalLv.ReadOnly = True
        Me.BalLv.Width = 133
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(308, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Entitle Leave(s) "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLvName
        '
        Me.txtLvName.BackColor = System.Drawing.Color.White
        Me.txtLvName.Location = New System.Drawing.Point(423, 24)
        Me.txtLvName.Name = "txtLvName"
        Me.txtLvName.Size = New System.Drawing.Size(168, 21)
        Me.txtLvName.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(308, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Leave Type "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.dtpToDate)
        Me.TabPage2.Controls.Add(Me.dgvLvHistory)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.dtpFrDate)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1004, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Leave History "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(5, 436)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(888, 2)
        Me.Label5.TabIndex = 33
        '
        'cmdReport
        '
        Me.cmdReport.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdReport.FlatAppearance.BorderSize = 0
        Me.cmdReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdReport.Location = New System.Drawing.Point(191, 6)
        Me.cmdReport.Name = "cmdReport"
        Me.cmdReport.Size = New System.Drawing.Size(88, 26)
        Me.cmdReport.TabIndex = 1
        Me.cmdReport.Tag = "1"
        Me.cmdReport.Text = "Report"
        Me.cmdReport.UseVisualStyleBackColor = True
        Me.cmdReport.Visible = False
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(471, 448)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(113, 21)
        Me.dtpToDate.TabIndex = 21
        '
        'dgvLvHistory
        '
        Me.dgvLvHistory.AllowUserToAddRows = False
        Me.dgvLvHistory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvLvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLvHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LvDate, Me.LvType, Me.Levname, Me.NoLev})
        Me.dgvLvHistory.GridColor = System.Drawing.Color.White
        Me.dgvLvHistory.Location = New System.Drawing.Point(187, 13)
        Me.dgvLvHistory.Name = "dgvLvHistory"
        Me.dgvLvHistory.ReadOnly = True
        Me.dgvLvHistory.RowHeadersVisible = False
        Me.dgvLvHistory.RowHeadersWidth = 12
        Me.dgvLvHistory.Size = New System.Drawing.Size(525, 390)
        Me.dgvLvHistory.TabIndex = 0
        '
        'LvDate
        '
        Me.LvDate.HeaderText = "Leave Date"
        Me.LvDate.Name = "LvDate"
        Me.LvDate.ReadOnly = True
        '
        'LvType
        '
        Me.LvType.HeaderText = "Leave Type"
        Me.LvType.Name = "LvType"
        Me.LvType.ReadOnly = True
        Me.LvType.Visible = False
        '
        'Levname
        '
        Me.Levname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Levname.HeaderText = "Leave Name"
        Me.Levname.Name = "Levname"
        Me.Levname.ReadOnly = True
        '
        'NoLev
        '
        Me.NoLev.HeaderText = "No Leave"
        Me.NoLev.Name = "NoLev"
        Me.NoLev.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(184, 452)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "From Date "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(416, 452)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "To Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFrDate
        '
        Me.dtpFrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpFrDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrDate.Location = New System.Drawing.Point(259, 448)
        Me.dtpFrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFrDate.Name = "dtpFrDate"
        Me.dtpFrDate.Size = New System.Drawing.Size(115, 21)
        Me.dtpFrDate.TabIndex = 21
        '
        'pnlAllData
        '
        Me.pnlAllData.Controls.Add(Me.TabControl1)
        Me.pnlAllData.Controls.Add(Me.Panel1)
        Me.pnlAllData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllData.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllData.Name = "pnlAllData"
        Me.pnlAllData.Size = New System.Drawing.Size(1012, 475)
        Me.pnlAllData.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdReport)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cmdPrevious)
        Me.Panel1.Controls.Add(Me.cmdNext)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 38)
        Me.Panel1.TabIndex = 94
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
        Me.Button1.Location = New System.Drawing.Point(936, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 28)
        Me.Button1.TabIndex = 17
        Me.Button1.Tag = "3"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(974, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(28, 28)
        Me.Button2.TabIndex = 18
        Me.Button2.Tag = "3"
        Me.Button2.UseVisualStyleBackColor = False
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
        Me.cmdPrevious.TabIndex = 16
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
        Me.cmdNext.TabIndex = 15
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
        Me.Label25.Location = New System.Drawing.Point(447, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(119, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Leave Details"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEmpLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 475)
        Me.Controls.Add(Me.pnlAllData)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmpLeave"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Employee Entitle Leave"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvLvHist, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvLvHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllData.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvLvHist As System.Windows.Forms.DataGridView
    Friend WithEvents txtLvQty As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLvName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvLvHistory As System.Windows.Forms.DataGridView
    Friend WithEvents cmdReport As System.Windows.Forms.Button
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFrDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlAllData As System.Windows.Forms.Panel
    Friend WithEvents LvDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Levname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoLev As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lvID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lvName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvQt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LvTkn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalLv As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
