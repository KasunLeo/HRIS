<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChgCodes
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
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cmbDetail = New System.Windows.Forms.ComboBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlTop = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        Me.pnlDta = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpTrDate = New System.Windows.Forms.DateTimePicker
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlTop.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllk.SuspendLayout()
        Me.pnlDta.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(307, 2)
        Me.Label13.TabIndex = 36
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(5, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "New Selection "
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDetail
        '
        Me.cmbDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDetail.FormattingEnabled = True
        Me.cmbDetail.Location = New System.Drawing.Point(8, 63)
        Me.cmbDetail.Name = "cmbDetail"
        Me.cmbDetail.Size = New System.Drawing.Size(288, 21)
        Me.cmbDetail.TabIndex = 39
        '
        'txtDescription
        '
        Me.txtDescription.BackColor = System.Drawing.Color.White
        Me.txtDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.Location = New System.Drawing.Point(8, 109)
        Me.txtDescription.MaxLength = 100
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(288, 68)
        Me.txtDescription.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Remarks"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTop
        '
        Me.pnlTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTop.Controls.Add(Me.cmdSave)
        Me.pnlTop.Controls.Add(Me.PictureBox1)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(307, 48)
        Me.pnlTop.TabIndex = 12
        Me.pnlTop.Tag = "1"
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
        Me.cmdSave.Location = New System.Drawing.Point(268, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Tag = "3"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(4, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(60, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(75, 13)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Edit Codes"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.pnlDta)
        Me.pnlAllk.Controls.Add(Me.pnlTop)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(309, 243)
        Me.pnlAllk.TabIndex = 15
        '
        'pnlDta
        '
        Me.pnlDta.Controls.Add(Me.Label2)
        Me.pnlDta.Controls.Add(Me.dtpTrDate)
        Me.pnlDta.Controls.Add(Me.Panel1)
        Me.pnlDta.Controls.Add(Me.Label15)
        Me.pnlDta.Controls.Add(Me.cmbDetail)
        Me.pnlDta.Controls.Add(Me.Label1)
        Me.pnlDta.Controls.Add(Me.txtDescription)
        Me.pnlDta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDta.Location = New System.Drawing.Point(0, 48)
        Me.pnlDta.Name = "pnlDta"
        Me.pnlDta.Size = New System.Drawing.Size(307, 193)
        Me.pnlDta.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Transaction Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpTrDate
        '
        Me.dtpTrDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpTrDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTrDate.Location = New System.Drawing.Point(10, 21)
        Me.dtpTrDate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpTrDate.Name = "dtpTrDate"
        Me.dtpTrDate.Size = New System.Drawing.Size(286, 21)
        Me.dtpTrDate.TabIndex = 43
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 183)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 10)
        Me.Panel1.TabIndex = 42
        '
        'frmChgCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(309, 243)
        Me.Controls.Add(Me.pnlAllk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmChgCodes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Code"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllk.ResumeLayout(False)
        Me.pnlDta.ResumeLayout(False)
        Me.pnlDta.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbDetail As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents pnlDta As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpTrDate As System.Windows.Forms.DateTimePicker
End Class
