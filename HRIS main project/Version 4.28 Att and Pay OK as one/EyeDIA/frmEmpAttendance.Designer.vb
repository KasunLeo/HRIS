<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpAttendance
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpAttendance))
        Me.dgvCals = New System.Windows.Forms.DataGridView
        Me.Month = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pnlChart = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.chartEmployee = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.ChartMonthEmp = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdPrevious = New System.Windows.Forms.Button
        Me.cmdNext = New System.Windows.Forms.Button
        Me.btnChart = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        CType(Me.dgvCals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlChart.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.chartEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.ChartMonthEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCals
        '
        Me.dgvCals.AllowUserToAddRows = False
        Me.dgvCals.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvCals.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCals.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Month, Me.d1, Me.D2, Me.D3, Me.D4, Me.D5, Me.D6, Me.D7, Me.D8, Me.D9, Me.D10, Me.D11, Me.D12, Me.D13, Me.D14, Me.D15, Me.D16, Me.D17, Me.D18, Me.D19, Me.D20, Me.D21, Me.D22, Me.D23, Me.D24, Me.D25, Me.D26, Me.D27, Me.D28, Me.D29, Me.D30, Me.D31})
        Me.dgvCals.Location = New System.Drawing.Point(2, 0)
        Me.dgvCals.Name = "dgvCals"
        Me.dgvCals.ReadOnly = True
        Me.dgvCals.RowHeadersVisible = False
        Me.dgvCals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCals.Size = New System.Drawing.Size(1010, 434)
        Me.dgvCals.TabIndex = 0
        Me.dgvCals.Tag = "1"
        '
        'Month
        '
        Me.Month.Frozen = True
        Me.Month.HeaderText = "Month"
        Me.Month.Name = "Month"
        Me.Month.ReadOnly = True
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.pnlChart)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.dgvCals)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1012, 437)
        Me.Panel2.TabIndex = 9
        '
        'pnlChart
        '
        Me.pnlChart.BackColor = System.Drawing.Color.Transparent
        Me.pnlChart.Controls.Add(Me.Panel4)
        Me.pnlChart.Controls.Add(Me.Panel5)
        Me.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChart.Location = New System.Drawing.Point(0, 0)
        Me.pnlChart.Name = "pnlChart"
        Me.pnlChart.Size = New System.Drawing.Size(1012, 437)
        Me.pnlChart.TabIndex = 29
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.chartEmployee)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(558, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(454, 437)
        Me.Panel4.TabIndex = 13
        '
        'chartEmployee
        '
        Me.chartEmployee.BackColor = System.Drawing.Color.Transparent
        Me.chartEmployee.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled
        Me.chartEmployee.BorderlineWidth = 0
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.Area3DStyle.WallWidth = 10
        ChartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled
        ChartArea1.IsSameFontSizeForAllAxes = True
        ChartArea1.Name = "ChartArea1"
        Me.chartEmployee.ChartAreas.Add(ChartArea1)
        Me.chartEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Alignment = System.Drawing.StringAlignment.Far
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top
        Legend1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.chartEmployee.Legends.Add(Legend1)
        Me.chartEmployee.Location = New System.Drawing.Point(0, 0)
        Me.chartEmployee.Name = "chartEmployee"
        Series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight
        Series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartEmployee.Series.Add(Series1)
        Me.chartEmployee.Size = New System.Drawing.Size(454, 437)
        Me.chartEmployee.TabIndex = 7
        Me.chartEmployee.Text = "Chart4"
        Title1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.White
        Title1.Name = "Title1"
        Title1.Text = "Attendance Upto Today "
        Me.chartEmployee.Titles.Add(Title1)
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.ChartMonthEmp)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(558, 437)
        Me.Panel5.TabIndex = 14
        '
        'ChartMonthEmp
        '
        Me.ChartMonthEmp.BackColor = System.Drawing.Color.Transparent
        Me.ChartMonthEmp.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled
        Me.ChartMonthEmp.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot
        Me.ChartMonthEmp.BorderlineWidth = 0
        ChartArea2.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Scaled
        ChartArea2.Name = "ChartArea1"
        Me.ChartMonthEmp.ChartAreas.Add(ChartArea2)
        Me.ChartMonthEmp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartMonthEmp.Location = New System.Drawing.Point(0, 0)
        Me.ChartMonthEmp.Name = "ChartMonthEmp"
        Series2.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100
        Series2.Name = "Series1"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomRight
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100
        Series3.Name = "Series2"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn100
        Series4.Name = "Series3"
        Series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.ChartMonthEmp.Series.Add(Series2)
        Me.ChartMonthEmp.Series.Add(Series3)
        Me.ChartMonthEmp.Series.Add(Series4)
        Me.ChartMonthEmp.Size = New System.Drawing.Size(558, 437)
        Me.ChartMonthEmp.TabIndex = 5
        Me.ChartMonthEmp.Text = "Chart3"
        Title2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.ForeColor = System.Drawing.Color.White
        Title2.Name = "Title1"
        Title2.Text = "Monthly Attendance"
        Me.ChartMonthEmp.Titles.Add(Title2)
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackColor = System.Drawing.Color.Transparent
        Me.cmdRefresh.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdRefresh.Location = New System.Drawing.Point(134, 6)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(88, 18)
        Me.cmdRefresh.TabIndex = 6
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        Me.cmdRefresh.Visible = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Location = New System.Drawing.Point(9, 466)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(888, 2)
        Me.Label15.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Turquoise
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdPrevious)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.cmdNext)
        Me.Panel1.Controls.Add(Me.btnChart)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 38)
        Me.Panel1.TabIndex = 96
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
        Me.cmdPrevious.Location = New System.Drawing.Point(9, 6)
        Me.cmdPrevious.Name = "cmdPrevious"
        Me.cmdPrevious.Size = New System.Drawing.Size(32, 26)
        Me.cmdPrevious.TabIndex = 33
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
        Me.cmdNext.Location = New System.Drawing.Point(74, 6)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(32, 26)
        Me.cmdNext.TabIndex = 32
        Me.cmdNext.Tag = "4"
        Me.cmdNext.UseVisualStyleBackColor = False
        Me.cmdNext.Visible = False
        '
        'btnChart
        '
        Me.btnChart.BackColor = System.Drawing.Color.Transparent
        Me.btnChart.BackgroundImage = Global.HRISforBB.My.Resources.Resources.webmail
        Me.btnChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnChart.FlatAppearance.BorderSize = 0
        Me.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChart.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChart.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnChart.Location = New System.Drawing.Point(970, 7)
        Me.btnChart.Name = "btnChart"
        Me.btnChart.Size = New System.Drawing.Size(35, 26)
        Me.btnChart.TabIndex = 31
        Me.btnChart.Tag = "1"
        Me.btnChart.Text = "3D Chart"
        Me.btnChart.UseVisualStyleBackColor = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(391, 10)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(231, 18)
        Me.Label25.TabIndex = 0
        Me.Label25.Text = "Attendance Review of Year"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmEmpAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 475)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmpAttendance"
        Me.Text = "Employee Attendance Details...."
        CType(Me.dgvCals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlChart.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.chartEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.ChartMonthEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCals As System.Windows.Forms.DataGridView
    Friend WithEvents Month As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlChart As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ChartMonthEmp As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents chartEmployee As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btnChart As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmdPrevious As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
End Class
