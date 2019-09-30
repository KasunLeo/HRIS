<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBackupDB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackupDB))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BunifuRating1 = New Bunifu.Framework.UI.BunifuRating()
        Me.BunifuSwitch1 = New Bunifu.Framework.UI.BunifuSwitch()
        Me.BunifuProgressBar1 = New Bunifu.Framework.UI.BunifuProgressBar()
        Me.BunifuMaterialTextbox1 = New Bunifu.Framework.UI.BunifuMaterialTextbox()
        Me.BunifuGauge2 = New Bunifu.Framework.UI.BunifuGauge()
        Me.BunifuCircleProgressbar1 = New Bunifu.Framework.UI.BunifuCircleProgressbar()
        Me.BunifuGradientPanel1 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuDropdown1 = New Bunifu.Framework.UI.BunifuDropdown()
        Me.BunifuDatepicker1 = New Bunifu.Framework.UI.BunifuDatepicker()
        Me.BunifuCheckbox1 = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblDesciption = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdBackup = New System.Windows.Forms.Button()
        Me.cmdBrsPath = New System.Windows.Forms.Button()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompName = New System.Windows.Forms.TextBox()
        Me.txtK = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBkpPath = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.fbdPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlAlld = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.BunifuElipse2 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.BunifuHTTP_Utils1 = New Bunifu.Framework.UI.BunifuHTTP_Utils(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlAlld.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.BunifuRating1)
        Me.Panel2.Controls.Add(Me.BunifuSwitch1)
        Me.Panel2.Controls.Add(Me.BunifuProgressBar1)
        Me.Panel2.Controls.Add(Me.BunifuMaterialTextbox1)
        Me.Panel2.Controls.Add(Me.BunifuGauge2)
        Me.Panel2.Controls.Add(Me.BunifuCircleProgressbar1)
        Me.Panel2.Controls.Add(Me.BunifuGradientPanel1)
        Me.Panel2.Controls.Add(Me.BunifuFlatButton1)
        Me.Panel2.Controls.Add(Me.BunifuDropdown1)
        Me.Panel2.Controls.Add(Me.BunifuDatepicker1)
        Me.Panel2.Controls.Add(Me.BunifuCheckbox1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.cmdBrsPath)
        Me.Panel2.Controls.Add(Me.lblCompany)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtCompName)
        Me.Panel2.Controls.Add(Me.txtK)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtBkpPath)
        Me.Panel2.Controls.Add(Me.txtUser)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(557, 558)
        Me.Panel2.TabIndex = 0
        '
        'BunifuRating1
        '
        Me.BunifuRating1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuRating1.ForeColor = System.Drawing.Color.SeaGreen
        Me.BunifuRating1.Location = New System.Drawing.Point(301, 266)
        Me.BunifuRating1.Name = "BunifuRating1"
        Me.BunifuRating1.Size = New System.Drawing.Size(194, 26)
        Me.BunifuRating1.TabIndex = 41
        Me.BunifuRating1.Value = 20
        Me.BunifuRating1.Visible = False
        '
        'BunifuSwitch1
        '
        Me.BunifuSwitch1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuSwitch1.BorderRadius = 0
        Me.BunifuSwitch1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuSwitch1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BunifuSwitch1.Location = New System.Drawing.Point(456, 327)
        Me.BunifuSwitch1.Name = "BunifuSwitch1"
        Me.BunifuSwitch1.Oncolor = System.Drawing.Color.SeaGreen
        Me.BunifuSwitch1.Onoffcolor = System.Drawing.Color.DarkGray
        Me.BunifuSwitch1.Size = New System.Drawing.Size(51, 19)
        Me.BunifuSwitch1.TabIndex = 40
        Me.BunifuSwitch1.Textcolor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BunifuSwitch1.Value = True
        Me.BunifuSwitch1.Visible = False
        '
        'BunifuProgressBar1
        '
        Me.BunifuProgressBar1.BackColor = System.Drawing.Color.Silver
        Me.BunifuProgressBar1.BorderRadius = 5
        Me.BunifuProgressBar1.Location = New System.Drawing.Point(11, 393)
        Me.BunifuProgressBar1.MaximumValue = 100
        Me.BunifuProgressBar1.Name = "BunifuProgressBar1"
        Me.BunifuProgressBar1.ProgressColor = System.Drawing.Color.Teal
        Me.BunifuProgressBar1.Size = New System.Drawing.Size(172, 10)
        Me.BunifuProgressBar1.TabIndex = 39
        Me.BunifuProgressBar1.Value = 0
        Me.BunifuProgressBar1.Visible = False
        '
        'BunifuMaterialTextbox1
        '
        Me.BunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.BunifuMaterialTextbox1.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.BunifuMaterialTextbox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty
        Me.BunifuMaterialTextbox1.HintText = ""
        Me.BunifuMaterialTextbox1.isPassword = False
        Me.BunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.Blue
        Me.BunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.Gray
        Me.BunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.Blue
        Me.BunifuMaterialTextbox1.LineThickness = 3
        Me.BunifuMaterialTextbox1.Location = New System.Drawing.Point(277, 92)
        Me.BunifuMaterialTextbox1.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuMaterialTextbox1.Name = "BunifuMaterialTextbox1"
        Me.BunifuMaterialTextbox1.Size = New System.Drawing.Size(173, 33)
        Me.BunifuMaterialTextbox1.TabIndex = 38
        Me.BunifuMaterialTextbox1.Text = "BunifuMaterialTextbox1"
        Me.BunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'BunifuGauge2
        '
        Me.BunifuGauge2.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.BunifuGauge2.BackgroundImage = CType(resources.GetObject("BunifuGauge2.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGauge2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BunifuGauge2.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.BunifuGauge2.ImeMode = System.Windows.Forms.ImeMode.Hangul
        Me.BunifuGauge2.Location = New System.Drawing.Point(276, 298)
        Me.BunifuGauge2.Margin = New System.Windows.Forms.Padding(6)
        Me.BunifuGauge2.Name = "BunifuGauge2"
        Me.BunifuGauge2.ProgressBgColor = System.Drawing.Color.Gray
        Me.BunifuGauge2.ProgressColor1 = System.Drawing.Color.SeaGreen
        Me.BunifuGauge2.ProgressColor2 = System.Drawing.Color.Tomato
        Me.BunifuGauge2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BunifuGauge2.Size = New System.Drawing.Size(174, 134)
        Me.BunifuGauge2.Suffix = ""
        Me.BunifuGauge2.TabIndex = 37
        Me.BunifuGauge2.TabStop = False
        Me.BunifuGauge2.Thickness = 15
        Me.BunifuGauge2.Value = 0
        Me.BunifuGauge2.Visible = False
        '
        'BunifuCircleProgressbar1
        '
        Me.BunifuCircleProgressbar1.animated = False
        Me.BunifuCircleProgressbar1.animationIterval = 5
        Me.BunifuCircleProgressbar1.animationSpeed = 300
        Me.BunifuCircleProgressbar1.BackColor = System.Drawing.Color.White
        Me.BunifuCircleProgressbar1.BackgroundImage = CType(resources.GetObject("BunifuCircleProgressbar1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuCircleProgressbar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!)
        Me.BunifuCircleProgressbar1.ForeColor = System.Drawing.Color.SeaGreen
        Me.BunifuCircleProgressbar1.LabelVisible = True
        Me.BunifuCircleProgressbar1.LineProgressThickness = 8
        Me.BunifuCircleProgressbar1.LineThickness = 5
        Me.BunifuCircleProgressbar1.Location = New System.Drawing.Point(451, 138)
        Me.BunifuCircleProgressbar1.Margin = New System.Windows.Forms.Padding(10, 9, 10, 9)
        Me.BunifuCircleProgressbar1.MaxValue = 100
        Me.BunifuCircleProgressbar1.Name = "BunifuCircleProgressbar1"
        Me.BunifuCircleProgressbar1.ProgressBackColor = System.Drawing.Color.Gainsboro
        Me.BunifuCircleProgressbar1.ProgressColor = System.Drawing.Color.SeaGreen
        Me.BunifuCircleProgressbar1.Size = New System.Drawing.Size(96, 96)
        Me.BunifuCircleProgressbar1.TabIndex = 30
        Me.BunifuCircleProgressbar1.Value = 10
        Me.BunifuCircleProgressbar1.Visible = False
        '
        'BunifuGradientPanel1
        '
        Me.BunifuGradientPanel1.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.DarkGray
        Me.BunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White
        Me.BunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Tomato
        Me.BunifuGradientPanel1.GradientTopRight = System.Drawing.Color.LightGreen
        Me.BunifuGradientPanel1.Location = New System.Drawing.Point(8, 315)
        Me.BunifuGradientPanel1.Name = "BunifuGradientPanel1"
        Me.BunifuGradientPanel1.Quality = 10
        Me.BunifuGradientPanel1.Size = New System.Drawing.Size(245, 64)
        Me.BunifuGradientPanel1.TabIndex = 35
        Me.BunifuGradientPanel1.Visible = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = CType(resources.GetObject("BunifuFlatButton1.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(8, 266)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(245, 48)
        Me.BunifuFlatButton1.TabIndex = 33
        Me.BunifuFlatButton1.Text = "BunifuFlatButton1"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Visible = False
        '
        'BunifuDropdown1
        '
        Me.BunifuDropdown1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuDropdown1.BorderRadius = 3
        Me.BunifuDropdown1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuDropdown1.ForeColor = System.Drawing.Color.White
        Me.BunifuDropdown1.Items = New String(-1) {}
        Me.BunifuDropdown1.Location = New System.Drawing.Point(7, 223)
        Me.BunifuDropdown1.Name = "BunifuDropdown1"
        Me.BunifuDropdown1.NomalColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuDropdown1.onHoverColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.BunifuDropdown1.selectedIndex = -1
        Me.BunifuDropdown1.Size = New System.Drawing.Size(246, 37)
        Me.BunifuDropdown1.TabIndex = 32
        Me.BunifuDropdown1.Visible = False
        '
        'BunifuDatepicker1
        '
        Me.BunifuDatepicker1.BackColor = System.Drawing.Color.SeaGreen
        Me.BunifuDatepicker1.BorderRadius = 0
        Me.BunifuDatepicker1.ForeColor = System.Drawing.Color.White
        Me.BunifuDatepicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.BunifuDatepicker1.FormatCustom = Nothing
        Me.BunifuDatepicker1.Location = New System.Drawing.Point(7, 181)
        Me.BunifuDatepicker1.Name = "BunifuDatepicker1"
        Me.BunifuDatepicker1.Size = New System.Drawing.Size(246, 36)
        Me.BunifuDatepicker1.TabIndex = 31
        Me.BunifuDatepicker1.Value = New Date(2018, 12, 15, 11, 40, 43, 32)
        Me.BunifuDatepicker1.Visible = False
        '
        'BunifuCheckbox1
        '
        Me.BunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BunifuCheckbox1.Checked = True
        Me.BunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.BunifuCheckbox1.ForeColor = System.Drawing.Color.White
        Me.BunifuCheckbox1.Location = New System.Drawing.Point(360, 148)
        Me.BunifuCheckbox1.Name = "BunifuCheckbox1"
        Me.BunifuCheckbox1.Size = New System.Drawing.Size(20, 20)
        Me.BunifuCheckbox1.TabIndex = 29
        Me.BunifuCheckbox1.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblDesciption)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmdClose)
        Me.Panel3.Controls.Add(Me.cmdBackup)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 514)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(557, 44)
        Me.Panel3.TabIndex = 28
        Me.Panel3.Tag = ""
        '
        'lblDesciption
        '
        Me.lblDesciption.AutoSize = True
        Me.lblDesciption.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesciption.Location = New System.Drawing.Point(5, 16)
        Me.lblDesciption.Name = "lblDesciption"
        Me.lblDesciption.Size = New System.Drawing.Size(268, 13)
        Me.lblDesciption.TabIndex = 56
        Me.lblDesciption.Text = "Choose backup  path and click Backup button"
        Me.lblDesciption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(557, 2)
        Me.Label3.TabIndex = 27
        '
        'cmdClose
        '
        Me.cmdClose.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunAtorabn
        Me.cmdClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdClose.FlatAppearance.BorderSize = 0
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmdClose.Location = New System.Drawing.Point(395, 9)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(88, 26)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Tag = "1"
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        Me.cmdClose.Visible = False
        '
        'cmdBackup
        '
        Me.cmdBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBackup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBackup.ForeColor = System.Drawing.Color.Orange
        Me.cmdBackup.Location = New System.Drawing.Point(301, 9)
        Me.cmdBackup.Name = "cmdBackup"
        Me.cmdBackup.Size = New System.Drawing.Size(88, 26)
        Me.cmdBackup.TabIndex = 2
        Me.cmdBackup.Tag = "1"
        Me.cmdBackup.Text = "Backup "
        Me.cmdBackup.UseVisualStyleBackColor = True
        Me.cmdBackup.Visible = False
        '
        'cmdBrsPath
        '
        Me.cmdBrsPath.BackColor = System.Drawing.Color.Transparent
        Me.cmdBrsPath.BackgroundImage = Global.HRISforBB.My.Resources.Resources.Searchk
        Me.cmdBrsPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.cmdBrsPath.FlatAppearance.BorderSize = 0
        Me.cmdBrsPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdBrsPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBrsPath.Location = New System.Drawing.Point(467, 62)
        Me.cmdBrsPath.Name = "cmdBrsPath"
        Me.cmdBrsPath.Size = New System.Drawing.Size(22, 22)
        Me.cmdBrsPath.TabIndex = 20
        Me.cmdBrsPath.UseVisualStyleBackColor = False
        '
        'lblCompany
        '
        Me.lblCompany.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblCompany.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCompany.Location = New System.Drawing.Point(41, 382)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(488, 21)
        Me.lblCompany.TabIndex = 25
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblCompany.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Company "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompName
        '
        Me.txtCompName.BackColor = System.Drawing.Color.White
        Me.txtCompName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompName.Location = New System.Drawing.Point(8, 24)
        Me.txtCompName.Name = "txtCompName"
        Me.txtCompName.Size = New System.Drawing.Size(456, 21)
        Me.txtCompName.TabIndex = 18
        '
        'txtK
        '
        Me.txtK.BackColor = System.Drawing.Color.White
        Me.txtK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtK.Location = New System.Drawing.Point(8, 144)
        Me.txtK.Name = "txtK"
        Me.txtK.Size = New System.Drawing.Size(222, 21)
        Me.txtK.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Backup Path "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Current Time "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBkpPath
        '
        Me.txtBkpPath.BackColor = System.Drawing.Color.White
        Me.txtBkpPath.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBkpPath.Location = New System.Drawing.Point(8, 64)
        Me.txtBkpPath.Name = "txtBkpPath"
        Me.txtBkpPath.Size = New System.Drawing.Size(456, 21)
        Me.txtBkpPath.TabIndex = 18
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.White
        Me.txtUser.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(8, 104)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(222, 21)
        Me.txtUser.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Current User "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'pnlAlld
        '
        Me.pnlAlld.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAlld.Controls.Add(Me.Panel2)
        Me.pnlAlld.Controls.Add(Me.Panel1)
        Me.pnlAlld.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAlld.Location = New System.Drawing.Point(0, 0)
        Me.pnlAlld.Name = "pnlAlld"
        Me.pnlAlld.Size = New System.Drawing.Size(559, 608)
        Me.pnlAlld.TabIndex = 29
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(557, 48)
        Me.Panel1.TabIndex = 8
        Me.Panel1.Tag = "1"
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
        Me.Button1.Location = New System.Drawing.Point(395, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 38)
        Me.Button1.TabIndex = 43
        Me.Button1.Tag = "3"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.refresh
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(454, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 44
        Me.Button3.Tag = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(7, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(62, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(150, 18)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Backup Database"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BunifuDragControl1
        '
        Me.BunifuDragControl1.Fixed = True
        Me.BunifuDragControl1.Horizontal = True
        Me.BunifuDragControl1.TargetControl = Nothing
        Me.BunifuDragControl1.Vertical = True
        '
        'BunifuElipse2
        '
        Me.BunifuElipse2.ElipseRadius = 5
        Me.BunifuElipse2.TargetControl = Me
        '
        'BunifuHTTP_Utils1
        '
        Me.BunifuHTTP_Utils1.JobName = ""
        Me.BunifuHTTP_Utils1.Url = ""
        '
        'frmBackupDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 608)
        Me.Controls.Add(Me.pnlAlld)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBackupDB"
        Me.Text = "Backup Database"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlAlld.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtBkpPath As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCompName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdBackup As System.Windows.Forms.Button
    Friend WithEvents fbdPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtK As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdBrsPath As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblDesciption As System.Windows.Forms.Label
    Friend WithEvents pnlAlld As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BunifuProgressBar1 As Bunifu.Framework.UI.BunifuProgressBar
    Friend WithEvents BunifuMaterialTextbox1 As Bunifu.Framework.UI.BunifuMaterialTextbox
    Friend WithEvents BunifuGauge2 As Bunifu.Framework.UI.BunifuGauge
    Friend WithEvents BunifuCircleProgressbar1 As Bunifu.Framework.UI.BunifuCircleProgressbar
    Friend WithEvents BunifuGradientPanel1 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuDropdown1 As Bunifu.Framework.UI.BunifuDropdown
    Friend WithEvents BunifuDatepicker1 As Bunifu.Framework.UI.BunifuDatepicker
    Friend WithEvents BunifuCheckbox1 As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents BunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents BunifuElipse2 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents BunifuHTTP_Utils1 As Bunifu.Framework.UI.BunifuHTTP_Utils
    Friend WithEvents BunifuRating1 As Bunifu.Framework.UI.BunifuRating
    Friend WithEvents BunifuSwitch1 As Bunifu.Framework.UI.BunifuSwitch
End Class
