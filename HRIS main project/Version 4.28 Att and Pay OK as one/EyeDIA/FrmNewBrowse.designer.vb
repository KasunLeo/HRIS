<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewBrowse
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
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvSearch = New System.Windows.Forms.DataGridView
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.pnlData = New System.Windows.Forms.Panel
        Me.pnlGrid = New System.Windows.Forms.Panel
        Me.pblSearch = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblEmpNam = New System.Windows.Forms.Label
        Me.lblCount = New System.Windows.Forms.Label
        Me.pnlTopk = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.txtTitle = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlAllk = New System.Windows.Forms.Panel
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.pnlData.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        Me.pblSearch.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlTopk.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAllk.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.BackgroundColor = System.Drawing.Color.White
        Me.dgvSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSearch.Location = New System.Drawing.Point(0, 0)
        Me.dgvSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersVisible = False
        Me.dgvSearch.RowHeadersWidth = 23
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.Size = New System.Drawing.Size(666, 355)
        Me.dgvSearch.TabIndex = 7
        Me.dgvSearch.TabStop = False
        Me.dgvSearch.Tag = "1"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlData)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 48)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(666, 409)
        Me.Panel3.TabIndex = 12
        '
        'pnlData
        '
        Me.pnlData.Controls.Add(Me.pnlGrid)
        Me.pnlData.Controls.Add(Me.pblSearch)
        Me.pnlData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlData.Location = New System.Drawing.Point(0, 0)
        Me.pnlData.Name = "pnlData"
        Me.pnlData.Size = New System.Drawing.Size(666, 383)
        Me.pnlData.TabIndex = 14
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.Add(Me.dgvSearch)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 28)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(666, 355)
        Me.pnlGrid.TabIndex = 9
        '
        'pblSearch
        '
        Me.pblSearch.BackColor = System.Drawing.Color.White
        Me.pblSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pblSearch.Controls.Add(Me.Label1)
        Me.pblSearch.Controls.Add(Me.txtSearch)
        Me.pblSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pblSearch.Location = New System.Drawing.Point(0, 0)
        Me.pblSearch.Name = "pblSearch"
        Me.pblSearch.Size = New System.Drawing.Size(666, 28)
        Me.pblSearch.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Searching Text"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(117, 4)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(546, 21)
        Me.txtSearch.TabIndex = 6
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.lblEmpNam)
        Me.Panel4.Controls.Add(Me.lblCount)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 383)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(666, 26)
        Me.Panel4.TabIndex = 13
        '
        'lblEmpNam
        '
        Me.lblEmpNam.AutoSize = True
        Me.lblEmpNam.ForeColor = System.Drawing.Color.DimGray
        Me.lblEmpNam.Location = New System.Drawing.Point(319, 7)
        Me.lblEmpNam.Name = "lblEmpNam"
        Me.lblEmpNam.Size = New System.Drawing.Size(0, 13)
        Me.lblEmpNam.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.ForeColor = System.Drawing.Color.DimGray
        Me.lblCount.Location = New System.Drawing.Point(11, 7)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 0
        '
        'pnlTopk
        '
        Me.pnlTopk.BackColor = System.Drawing.Color.White
        Me.pnlTopk.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlTopk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlTopk.Controls.Add(Me.PictureBox1)
        Me.pnlTopk.Controls.Add(Me.Button9)
        Me.pnlTopk.Controls.Add(Me.txtTitle)
        Me.pnlTopk.Controls.Add(Me.Label2)
        Me.pnlTopk.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopk.Location = New System.Drawing.Point(0, 0)
        Me.pnlTopk.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlTopk.Name = "pnlTopk"
        Me.pnlTopk.Size = New System.Drawing.Size(666, 48)
        Me.pnlTopk.TabIndex = 9
        Me.pnlTopk.Tag = "1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(8, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(322, 27)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(25, 14)
        Me.Button9.TabIndex = 40
        Me.Button9.Tag = "2"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'txtTitle
        '
        Me.txtTitle.AutoSize = True
        Me.txtTitle.BackColor = System.Drawing.Color.Transparent
        Me.txtTitle.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.ForeColor = System.Drawing.Color.Transparent
        Me.txtTitle.Location = New System.Drawing.Point(64, 15)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(221, 18)
        Me.txtTitle.TabIndex = 2
        Me.txtTitle.Text = "Search Items in Database"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(0, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(666, 2)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        '
        'pnlAllk
        '
        Me.pnlAllk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAllk.Controls.Add(Me.Panel3)
        Me.pnlAllk.Controls.Add(Me.pnlTopk)
        Me.pnlAllk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAllk.Location = New System.Drawing.Point(0, 0)
        Me.pnlAllk.Name = "pnlAllk"
        Me.pnlAllk.Size = New System.Drawing.Size(668, 459)
        Me.pnlAllk.TabIndex = 42
        '
        'FrmNewBrowse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(668, 459)
        Me.Controls.Add(Me.pnlAllk)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNewBrowse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search in Database.."
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.pnlData.ResumeLayout(False)
        Me.pnlGrid.ResumeLayout(False)
        Me.pblSearch.ResumeLayout(False)
        Me.pblSearch.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlTopk.ResumeLayout(False)
        Me.pnlTopk.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAllk.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents dgvSearch As System.Windows.Forms.DataGridView
    Friend WithEvents txtTitle As System.Windows.Forms.Label
    Friend WithEvents pnlTopk As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents pblSearch As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents lblEmpNam As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents pnlData As System.Windows.Forms.Panel
    Friend WithEvents pnlAllk As System.Windows.Forms.Panel
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
