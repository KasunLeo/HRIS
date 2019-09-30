<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepContainerAttn
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
        Me.pnlAllk = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.crptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.pnlAllk.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel3)
        Me.pnlAllk.Controls.Add(Me.pnlTop)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(864, 484)
        Me.pnlAllk.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.crptViewer)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(862, 434)
        Me.Panel3.TabIndex = 18
        '
        'crptViewer
        '
        Me.crptViewer.ActiveViewIndex = -1
        Me.crptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crptViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crptViewer.Location = New System.Drawing.Point(0, 0)
        Me.crptViewer.Name = "crptViewer"
        Me.crptViewer.SelectionFormula = ""
        Me.crptViewer.Size = New System.Drawing.Size(862, 434)
        Me.crptViewer.TabIndex = 0
        Me.crptViewer.ViewTimeSelectionFormula = ""
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.Panel4)
        Me.pnlTop.Controls.Add(Me.lblReport)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(862, 48)
        Me.pnlTop.TabIndex = 17
        Me.pnlTop.Tag = "1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(10, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Button9)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(753, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(109, 48)
        Me.Panel4.TabIndex = 5
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImage = Global.HRISforBB.My.Resources.Resources.button_login
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(81, 3)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(25, 14)
        Me.Button9.TabIndex = 41
        Me.Button9.Tag = "2"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'lblReport
        '
        Me.lblReport.AutoSize = True
        Me.lblReport.BackColor = System.Drawing.Color.Transparent
        Me.lblReport.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReport.ForeColor = System.Drawing.Color.DimGray
        Me.lblReport.Location = New System.Drawing.Point(65, 15)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(125, 18)
        Me.lblReport.TabIndex = 0
        Me.lblReport.Text = "Report Viewer"
        Me.lblReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmRepContainerAt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 484)
        Me.Controls.Add(Me.pnlAllk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRepContainerAt"
        Me.Text = "Attendance Reports...."
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlAllk.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents crptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
