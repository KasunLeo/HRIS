<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpShift
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
        Me.pnlAllData = New System.Windows.Forms.Panel
        Me.dgvCals = New System.Windows.Forms.DataGridView
        Me.cMonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.d1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D21 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D22 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D24 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D25 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D29 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.pnlAllData.SuspendLayout()
        CType(Me.dgvCals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAllData
        '
        Me.pnlAllData.BackColor = System.Drawing.Color.White
        Me.pnlAllData.Controls.Add(Me.dgvCals)
        Me.pnlAllData.Controls.Add(Me.Panel1)
        Me.pnlAllData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAllData.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllData.Name = "pnlAllData"
        Me.pnlAllData.Size = New System.Drawing.Size(1012, 475)
        Me.pnlAllData.TabIndex = 0
        '
        'dgvCals
        '
        Me.dgvCals.AllowUserToAddRows = False
        Me.dgvCals.BackgroundColor = System.Drawing.Color.White
        Me.dgvCals.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cMonth, Me.d1, Me.D2, Me.D3, Me.D4, Me.D5, Me.D6, Me.D7, Me.D8, Me.D9, Me.D10, Me.D11, Me.D12, Me.D13, Me.D14, Me.D15, Me.D16, Me.D17, Me.D18, Me.D19, Me.D20, Me.D21, Me.D22, Me.D23, Me.D24, Me.D25, Me.D26, Me.D27, Me.D28, Me.D29, Me.D30, Me.D31})
        Me.dgvCals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCals.GridColor = System.Drawing.Color.Silver
        Me.dgvCals.Location = New System.Drawing.Point(0, 38)
        Me.dgvCals.Name = "dgvCals"
        Me.dgvCals.ReadOnly = True
        Me.dgvCals.RowHeadersVisible = False
        Me.dgvCals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCals.Size = New System.Drawing.Size(1012, 437)
        Me.dgvCals.TabIndex = 0
        Me.dgvCals.Tag = "1"
        '
        'cMonth
        '
        Me.cMonth.Frozen = True
        Me.cMonth.HeaderText = "Month"
        Me.cMonth.Name = "cMonth"
        Me.cMonth.ReadOnly = True
        '
        'd1
        '
        Me.d1.HeaderText = "1"
        Me.d1.Name = "d1"
        Me.d1.ReadOnly = True
        '
        'D2
        '
        Me.D2.HeaderText = "2"
        Me.D2.Name = "D2"
        Me.D2.ReadOnly = True
        '
        'D3
        '
        Me.D3.HeaderText = "3"
        Me.D3.Name = "D3"
        Me.D3.ReadOnly = True
        '
        'D4
        '
        Me.D4.HeaderText = "4"
        Me.D4.Name = "D4"
        Me.D4.ReadOnly = True
        '
        'D5
        '
        Me.D5.HeaderText = "5"
        Me.D5.Name = "D5"
        Me.D5.ReadOnly = True
        '
        'D6
        '
        Me.D6.HeaderText = "6"
        Me.D6.Name = "D6"
        Me.D6.ReadOnly = True
        '
        'D7
        '
        Me.D7.HeaderText = "7"
        Me.D7.Name = "D7"
        Me.D7.ReadOnly = True
        '
        'D8
        '
        Me.D8.HeaderText = "8"
        Me.D8.Name = "D8"
        Me.D8.ReadOnly = True
        '
        'D9
        '
        Me.D9.HeaderText = "9"
        Me.D9.Name = "D9"
        Me.D9.ReadOnly = True
        '
        'D10
        '
        Me.D10.HeaderText = "10"
        Me.D10.Name = "D10"
        Me.D10.ReadOnly = True
        '
        'D11
        '
        Me.D11.HeaderText = "11"
        Me.D11.Name = "D11"
        Me.D11.ReadOnly = True
        '
        'D12
        '
        Me.D12.HeaderText = "12"
        Me.D12.Name = "D12"
        Me.D12.ReadOnly = True
        '
        'D13
        '
        Me.D13.HeaderText = "13"
        Me.D13.Name = "D13"
        Me.D13.ReadOnly = True
        '
        'D14
        '
        Me.D14.HeaderText = "14"
        Me.D14.Name = "D14"
        Me.D14.ReadOnly = True
        '
        'D15
        '
        Me.D15.HeaderText = "15"
        Me.D15.Name = "D15"
        Me.D15.ReadOnly = True
        '
        'D16
        '
        Me.D16.HeaderText = "16"
        Me.D16.Name = "D16"
        Me.D16.ReadOnly = True
        '
        'D17
        '
        Me.D17.HeaderText = "17"
        Me.D17.Name = "D17"
        Me.D17.ReadOnly = True
        '
        'D18
        '
        Me.D18.HeaderText = "18"
        Me.D18.Name = "D18"
        Me.D18.ReadOnly = True
        '
        'D19
        '
        Me.D19.HeaderText = "19"
        Me.D19.Name = "D19"
        Me.D19.ReadOnly = True
        '
        'D20
        '
        Me.D20.HeaderText = "20"
        Me.D20.Name = "D20"
        Me.D20.ReadOnly = True
        '
        'D21
        '
        Me.D21.HeaderText = "21"
        Me.D21.Name = "D21"
        Me.D21.ReadOnly = True
        '
        'D22
        '
        Me.D22.HeaderText = "22"
        Me.D22.Name = "D22"
        Me.D22.ReadOnly = True
        '
        'D23
        '
        Me.D23.HeaderText = "23"
        Me.D23.Name = "D23"
        Me.D23.ReadOnly = True
        '
        'D24
        '
        Me.D24.HeaderText = "24"
        Me.D24.Name = "D24"
        Me.D24.ReadOnly = True
        '
        'D25
        '
        Me.D25.HeaderText = "25"
        Me.D25.Name = "D25"
        Me.D25.ReadOnly = True
        '
        'D26
        '
        Me.D26.HeaderText = "26"
        Me.D26.Name = "D26"
        Me.D26.ReadOnly = True
        '
        'D27
        '
        Me.D27.HeaderText = "27"
        Me.D27.Name = "D27"
        Me.D27.ReadOnly = True
        '
        'D28
        '
        Me.D28.HeaderText = "28"
        Me.D28.Name = "D28"
        Me.D28.ReadOnly = True
        '
        'D29
        '
        Me.D29.HeaderText = "29"
        Me.D29.Name = "D29"
        Me.D29.ReadOnly = True
        '
        'D30
        '
        Me.D30.HeaderText = "30"
        Me.D30.Name = "D30"
        Me.D30.ReadOnly = True
        '
        'D31
        '
        Me.D31.HeaderText = "31"
        Me.D31.Name = "D31"
        Me.D31.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdPrevious)
        Me.Panel1.Controls.Add(Me.cmdNext)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 38)
        Me.Panel1.TabIndex = 95
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
        Me.cmdPrevious.TabIndex = 18
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
        Me.cmdNext.TabIndex = 17
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
        Me.Label25.Location = New System.Drawing.Point(338, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(337, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Employee Shift Varience of Current Year"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEmpShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 475)
        Me.Controls.Add(Me.pnlAllData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEmpShift"
        Me.Text = "CHANGE SHIFT"
        Me.pnlAllData.ResumeLayout(False)
        CType(Me.dgvCals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlAllData As System.Windows.Forms.Panel
    Friend WithEvents dgvCals As System.Windows.Forms.DataGridView
    Friend WithEvents cMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
End Class
