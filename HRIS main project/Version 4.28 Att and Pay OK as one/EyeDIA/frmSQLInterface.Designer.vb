<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSQLInterface
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdRun = New System.Windows.Forms.Button
        Me.cmdView = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.dgvQuery = New System.Windows.Forms.DataGridView
        Me.txtQuery = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnToExcel = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.pbKasun = New System.Windows.Forms.ToolStripProgressBar
        Me.Button1 = New System.Windows.Forms.Button
        Me.pnlData = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pnlAlld = New System.Windows.Forms.Panel
        Me.pgBar = New System.Windows.Forms.ToolStripProgressBar
        Me.lblcount = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblColumn = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlData.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAlld.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(778, 2)
        Me.Label7.TabIndex = 37
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 48)
        Me.Panel1.TabIndex = 36
        Me.Panel1.Tag = "1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(8, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 76
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(63, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Query Browser"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdRun
        '
        Me.cmdRun.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRun.FlatAppearance.BorderSize = 0
        Me.cmdRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRun.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRun.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRun.Location = New System.Drawing.Point(488, 15)
        Me.cmdRun.Name = "cmdRun"
        Me.cmdRun.Size = New System.Drawing.Size(88, 26)
        Me.cmdRun.TabIndex = 35
        Me.cmdRun.TabStop = False
        Me.cmdRun.Tag = "1"
        Me.cmdRun.Text = "Run"
        Me.cmdRun.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdView.FlatAppearance.BorderSize = 0
        Me.cmdView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdView.Location = New System.Drawing.Point(582, 15)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(88, 26)
        Me.cmdView.TabIndex = 32
        Me.cmdView.TabStop = False
        Me.cmdView.Tag = "1"
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.cmdExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdExit.FlatAppearance.BorderSize = 0
        Me.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdExit.Location = New System.Drawing.Point(676, 15)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(88, 26)
        Me.cmdExit.TabIndex = 33
        Me.cmdExit.TabStop = False
        Me.cmdExit.Tag = "1"
        Me.cmdExit.Text = "&Exit"
        Me.cmdExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'dgvQuery
        '
        Me.dgvQuery.AllowUserToDeleteRows = False
        Me.dgvQuery.BackgroundColor = System.Drawing.Color.White
        Me.dgvQuery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQuery.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvQuery.Location = New System.Drawing.Point(2, 88)
        Me.dgvQuery.Name = "dgvQuery"
        Me.dgvQuery.RowHeadersVisible = False
        Me.dgvQuery.RowHeadersWidth = 12
        Me.dgvQuery.Size = New System.Drawing.Size(775, 243)
        Me.dgvQuery.TabIndex = 38
        Me.dgvQuery.Tag = "1"
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(8, 22)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(763, 60)
        Me.txtQuery.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Query"
        '
        'btnToExcel
        '
        Me.btnToExcel.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.btnToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnToExcel.FlatAppearance.BorderSize = 0
        Me.btnToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToExcel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnToExcel.Location = New System.Drawing.Point(394, 15)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(88, 26)
        Me.btnToExcel.TabIndex = 41
        Me.btnToExcel.TabStop = False
        Me.btnToExcel.Tag = "1"
        Me.btnToExcel.Text = "To Excel"
        Me.btnToExcel.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pgBar, Me.lblcount, Me.lblColumn, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(778, 22)
        Me.StatusStrip1.TabIndex = 42
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pbKasun
        '
        Me.pbKasun.Name = "pbKasun"
        Me.pbKasun.Size = New System.Drawing.Size(100, 16)
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.buttonklllk
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(6, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 26)
        Me.Button1.TabIndex = 43
        Me.Button1.TabStop = False
        Me.Button1.Tag = "1"
        Me.Button1.Text = "R&efresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlData
        '
        Me.pnlData.BackColor = System.Drawing.Color.White
        Me.pnlData.Controls.Add(Me.Panel2)
        Me.pnlData.Controls.Add(Me.Label2)
        Me.pnlData.Controls.Add(Me.dgvQuery)
        Me.pnlData.Controls.Add(Me.txtQuery)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlData.Location = New System.Drawing.Point(0, 48)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(778, 434)
        Me.pnlData.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Controls.Add(Me.cmdView)
        Me.Panel2.Controls.Add(Me.btnToExcel)
        Me.Panel2.Controls.Add(Me.cmdRun)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 390)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 44)
        Me.Panel2.TabIndex = 45
        '
        'pnlAlld
        '
        Me.pnlAlld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAlld.Controls.Add(Me.pnlData)
        Me.pnlAlld.Controls.Add(Me.Panel1)
        Me.pnlAlld.Controls.Add(Me.StatusStrip1)
        Me.pnlAlld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlld.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlld.Name = "pnlAlld"
        Me.pnlAlld.Size = New System.Drawing.Size(780, 506)
        Me.pnlAlld.TabIndex = 78
        '
        'pgBar
        '
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(100, 16)
        '
        'lblcount
        '
        Me.lblcount.Name = "lblcount"
        Me.lblcount.Size = New System.Drawing.Size(40, 17)
        Me.lblcount.Text = "Count"
        '
        'lblColumn
        '
        Me.lblColumn.Name = "lblColumn"
        Me.lblColumn.Size = New System.Drawing.Size(50, 17)
        Me.lblColumn.Text = "Column"
        '
        'lblRow
        '
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(30, 17)
        Me.lblRow.Text = "Row"
        '
        'frmSQLInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 506)
        Me.Controls.Add(Me.pnlAlld)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSQLInterface"
        Me.Text = "SQLInterface"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvQuery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlData.ResumeLayout(False)
        Me.pnlData.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlAlld.ResumeLayout(False)
        Me.pnlAlld.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdRun As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents dgvQuery As System.Windows.Forms.DataGridView
    Friend WithEvents txtQuery As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnToExcel As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pbKasun As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAlld As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pgBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblcount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblColumn As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRow As System.Windows.Forms.ToolStripStatusLabel
End Class
