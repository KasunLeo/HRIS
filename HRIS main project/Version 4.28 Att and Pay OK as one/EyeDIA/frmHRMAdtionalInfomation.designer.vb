<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHRMAdtionalInfomation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHRMAdtionalInfomation))
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbSubCat = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbAct = New System.Windows.Forms.ComboBox
        Me.DeptID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.deptName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.cmbNearestCity = New System.Windows.Forms.ComboBox
        Me.cmbDisasterArea = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.dtpFirstJoin = New System.Windows.Forms.DateTimePicker
        Me.txtEpfNo = New System.Windows.Forms.TextBox
        Me.pnlMostRight = New System.Windows.Forms.Panel
        Me.txtAgeFromFirstJoin = New System.Windows.Forms.TextBox
        Me.pbDisasEdit = New System.Windows.Forms.PictureBox
        Me.pbNewDisasterArea = New System.Windows.Forms.PictureBox
        Me.pbNearCtyEdit = New System.Windows.Forms.PictureBox
        Me.pbNewNearCity = New System.Windows.Forms.PictureBox
        Me.pbEditEpf = New System.Windows.Forms.PictureBox
        Me.pbSubCatEdit = New System.Windows.Forms.PictureBox
        Me.pbActEdit = New System.Windows.Forms.PictureBox
        Me.pnlMyTop = New System.Windows.Forms.Panel
        Me.Label40 = New System.Windows.Forms.Label
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.pbAddNewAct = New System.Windows.Forms.PictureBox
        Me.pbEditFirstJoin = New System.Windows.Forms.PictureBox
        Me.pbEditName = New System.Windows.Forms.PictureBox
        Me.pbNewSubCategory = New System.Windows.Forms.PictureBox
        Me.CboxNewEmployee = New System.Windows.Forms.CheckBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.cmbSubDept = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.pnlMostRight.SuspendLayout()
        CType(Me.pbDisasEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbNewDisasterArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbNearCtyEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbNewNearCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditEpf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSubCatEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbActEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMyTop.SuspendLayout()
        CType(Me.pbAddNewAct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditFirstJoin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbEditName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbNewSubCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(4, 309)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(4, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "First Join Date"
        '
        'cmbSubCat
        '
        Me.cmbSubCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubCat.FormattingEnabled = True
        Me.cmbSubCat.Location = New System.Drawing.Point(123, 66)
        Me.cmbSubCat.Name = "cmbSubCat"
        Me.cmbSubCat.Size = New System.Drawing.Size(183, 21)
        Me.cmbSubCat.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(4, 283)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "EPF No"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(123, 306)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(194, 21)
        Me.txtName.TabIndex = 9
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(4, 362)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(120, 13)
        Me.Label35.TabIndex = 69
        Me.Label35.Text = "Age From First Join "
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(5, 71)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 13)
        Me.Label28.TabIndex = 49
        Me.Label28.Text = "Sub Category"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(5, 44)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(25, 13)
        Me.Label26.TabIndex = 46
        Me.Label26.Text = "Act"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(3, 232)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 16)
        Me.Label13.TabIndex = 137
        Me.Label13.Text = "History Details"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(3, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 16)
        Me.Label11.TabIndex = 139
        Me.Label11.Text = "Profile HR Codes"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Location = New System.Drawing.Point(131, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(258, 3)
        Me.Label12.TabIndex = 138
        '
        'cmbAct
        '
        Me.cmbAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAct.FormattingEnabled = True
        Me.cmbAct.Location = New System.Drawing.Point(123, 41)
        Me.cmbAct.Name = "cmbAct"
        Me.cmbAct.Size = New System.Drawing.Size(183, 21)
        Me.cmbAct.TabIndex = 2
        '
        'DeptID
        '
        Me.DeptID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DeptID.HeaderText = "Doc ID"
        Me.DeptID.Name = "DeptID"
        Me.DeptID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeptID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DeptID.Visible = False
        '
        'deptName
        '
        Me.deptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.deptName.HeaderText = "Document Name"
        Me.deptName.Name = "deptName"
        Me.deptName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.deptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(83, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(129, 16)
        Me.Label6.TabIndex = 146
        Me.Label6.Text = "Location Related"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Location = New System.Drawing.Point(218, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(361, 3)
        Me.Label14.TabIndex = 147
        '
        'cmbNearestCity
        '
        Me.cmbNearestCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNearestCity.FormattingEnabled = True
        Me.cmbNearestCity.Location = New System.Drawing.Point(218, 44)
        Me.cmbNearestCity.Name = "cmbNearestCity"
        Me.cmbNearestCity.Size = New System.Drawing.Size(194, 21)
        Me.cmbNearestCity.TabIndex = 159
        '
        'cmbDisasterArea
        '
        Me.cmbDisasterArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDisasterArea.FormattingEnabled = True
        Me.cmbDisasterArea.Location = New System.Drawing.Point(218, 71)
        Me.cmbDisasterArea.Name = "cmbDisasterArea"
        Me.cmbDisasterArea.Size = New System.Drawing.Size(194, 21)
        Me.cmbDisasterArea.TabIndex = 162
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(101, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 13)
        Me.Label18.TabIndex = 166
        Me.Label18.Text = "Disaster Area Type"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(101, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 167
        Me.Label19.Text = "Nearest City"
        '
        'dtpFirstJoin
        '
        Me.dtpFirstJoin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFirstJoin.Location = New System.Drawing.Point(123, 332)
        Me.dtpFirstJoin.Name = "dtpFirstJoin"
        Me.dtpFirstJoin.Size = New System.Drawing.Size(194, 21)
        Me.dtpFirstJoin.TabIndex = 168
        '
        'txtEpfNo
        '
        Me.txtEpfNo.Location = New System.Drawing.Point(123, 280)
        Me.txtEpfNo.Name = "txtEpfNo"
        Me.txtEpfNo.Size = New System.Drawing.Size(194, 21)
        Me.txtEpfNo.TabIndex = 170
        '
        'pnlMostRight
        '
        Me.pnlMostRight.Controls.Add(Me.Panel4)
        Me.pnlMostRight.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMostRight.Location = New System.Drawing.Point(0, 205)
        Me.pnlMostRight.Name = "pnlMostRight"
        Me.pnlMostRight.Size = New System.Drawing.Size(610, 232)
        Me.pnlMostRight.TabIndex = 119
        '
        'txtAgeFromFirstJoin
        '
        Me.txtAgeFromFirstJoin.Location = New System.Drawing.Point(123, 359)
        Me.txtAgeFromFirstJoin.Name = "txtAgeFromFirstJoin"
        Me.txtAgeFromFirstJoin.ReadOnly = True
        Me.txtAgeFromFirstJoin.Size = New System.Drawing.Size(107, 21)
        Me.txtAgeFromFirstJoin.TabIndex = 9
        '
        'pbDisasEdit
        '
        Me.pbDisasEdit.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbDisasEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDisasEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbDisasEdit.Location = New System.Drawing.Point(446, 69)
        Me.pbDisasEdit.Name = "pbDisasEdit"
        Me.pbDisasEdit.Size = New System.Drawing.Size(22, 22)
        Me.pbDisasEdit.TabIndex = 164
        Me.pbDisasEdit.TabStop = False
        Me.pbDisasEdit.Tag = "5"
        '
        'pbNewDisasterArea
        '
        Me.pbNewDisasterArea.BackgroundImage = Global.HRISforBB.My.Resources.Resources.kasunAdd
        Me.pbNewDisasterArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbNewDisasterArea.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbNewDisasterArea.Location = New System.Drawing.Point(418, 69)
        Me.pbNewDisasterArea.Name = "pbNewDisasterArea"
        Me.pbNewDisasterArea.Size = New System.Drawing.Size(22, 22)
        Me.pbNewDisasterArea.TabIndex = 163
        Me.pbNewDisasterArea.TabStop = False
        Me.pbNewDisasterArea.Tag = "5"
        '
        'pbNearCtyEdit
        '
        Me.pbNearCtyEdit.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbNearCtyEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbNearCtyEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbNearCtyEdit.Location = New System.Drawing.Point(446, 42)
        Me.pbNearCtyEdit.Name = "pbNearCtyEdit"
        Me.pbNearCtyEdit.Size = New System.Drawing.Size(22, 22)
        Me.pbNearCtyEdit.TabIndex = 161
        Me.pbNearCtyEdit.TabStop = False
        Me.pbNearCtyEdit.Tag = "5"
        '
        'pbNewNearCity
        '
        Me.pbNewNearCity.BackgroundImage = Global.HRISforBB.My.Resources.Resources.kasunAdd
        Me.pbNewNearCity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbNewNearCity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbNewNearCity.Location = New System.Drawing.Point(418, 42)
        Me.pbNewNearCity.Name = "pbNewNearCity"
        Me.pbNewNearCity.Size = New System.Drawing.Size(22, 22)
        Me.pbNewNearCity.TabIndex = 160
        Me.pbNewNearCity.TabStop = False
        Me.pbNewNearCity.Tag = "5"
        '
        'pbEditEpf
        '
        Me.pbEditEpf.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbEditEpf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbEditEpf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditEpf.Location = New System.Drawing.Point(343, 277)
        Me.pbEditEpf.Name = "pbEditEpf"
        Me.pbEditEpf.Size = New System.Drawing.Size(22, 22)
        Me.pbEditEpf.TabIndex = 152
        Me.pbEditEpf.TabStop = False
        Me.pbEditEpf.Tag = "5"
        '
        'pbSubCatEdit
        '
        Me.pbSubCatEdit.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbSubCatEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbSubCatEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbSubCatEdit.Location = New System.Drawing.Point(340, 66)
        Me.pbSubCatEdit.Name = "pbSubCatEdit"
        Me.pbSubCatEdit.Size = New System.Drawing.Size(22, 22)
        Me.pbSubCatEdit.TabIndex = 151
        Me.pbSubCatEdit.TabStop = False
        Me.pbSubCatEdit.Tag = "5"
        '
        'pbActEdit
        '
        Me.pbActEdit.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbActEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbActEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbActEdit.Location = New System.Drawing.Point(340, 39)
        Me.pbActEdit.Name = "pbActEdit"
        Me.pbActEdit.Size = New System.Drawing.Size(22, 22)
        Me.pbActEdit.TabIndex = 150
        Me.pbActEdit.TabStop = False
        Me.pbActEdit.Tag = "5"
        '
        'pnlMyTop
        '
        Me.pnlMyTop.BackColor = System.Drawing.Color.Transparent
        Me.pnlMyTop.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.pnlMyTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMyTop.Controls.Add(Me.Label40)
        Me.pnlMyTop.Controls.Add(Me.cmdRefresh)
        Me.pnlMyTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMyTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMyTop.Name = "pnlMyTop"
        Me.pnlMyTop.Size = New System.Drawing.Size(1012, 38)
        Me.pnlMyTop.TabIndex = 46
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.BackColor = System.Drawing.Color.Transparent
        Me.Label40.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(393, 9)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(221, 18)
        Me.Label40.TabIndex = 0
        Me.Label40.Text = "Adtional HRM Information"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cmdRefresh.Location = New System.Drawing.Point(973, 5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 11
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'pbAddNewAct
        '
        Me.pbAddNewAct.BackgroundImage = Global.HRISforBB.My.Resources.Resources.kasunAdd
        Me.pbAddNewAct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAddNewAct.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbAddNewAct.Location = New System.Drawing.Point(312, 39)
        Me.pbAddNewAct.Name = "pbAddNewAct"
        Me.pbAddNewAct.Size = New System.Drawing.Size(22, 22)
        Me.pbAddNewAct.TabIndex = 124
        Me.pbAddNewAct.TabStop = False
        Me.pbAddNewAct.Tag = "5"
        '
        'pbEditFirstJoin
        '
        Me.pbEditFirstJoin.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbEditFirstJoin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbEditFirstJoin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditFirstJoin.Location = New System.Drawing.Point(343, 330)
        Me.pbEditFirstJoin.Name = "pbEditFirstJoin"
        Me.pbEditFirstJoin.Size = New System.Drawing.Size(22, 22)
        Me.pbEditFirstJoin.TabIndex = 117
        Me.pbEditFirstJoin.TabStop = False
        Me.pbEditFirstJoin.Tag = "5"
        '
        'pbEditName
        '
        Me.pbEditName.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.pbEditName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbEditName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbEditName.Location = New System.Drawing.Point(343, 303)
        Me.pbEditName.Name = "pbEditName"
        Me.pbEditName.Size = New System.Drawing.Size(22, 22)
        Me.pbEditName.TabIndex = 119
        Me.pbEditName.TabStop = False
        Me.pbEditName.Tag = "5"
        '
        'pbNewSubCategory
        '
        Me.pbNewSubCategory.BackgroundImage = Global.HRISforBB.My.Resources.Resources.kasunAdd
        Me.pbNewSubCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbNewSubCategory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbNewSubCategory.Location = New System.Drawing.Point(312, 66)
        Me.pbNewSubCategory.Name = "pbNewSubCategory"
        Me.pbNewSubCategory.Size = New System.Drawing.Size(22, 22)
        Me.pbNewSubCategory.TabIndex = 115
        Me.pbNewSubCategory.TabStop = False
        Me.pbNewSubCategory.Tag = "5"
        '
        'CboxNewEmployee
        '
        Me.CboxNewEmployee.AutoSize = True
        Me.CboxNewEmployee.Location = New System.Drawing.Point(123, 387)
        Me.CboxNewEmployee.Name = "CboxNewEmployee"
        Me.CboxNewEmployee.Size = New System.Drawing.Size(110, 17)
        Me.CboxNewEmployee.TabIndex = 171
        Me.CboxNewEmployee.Text = "New Employee"
        Me.CboxNewEmployee.UseVisualStyleBackColor = True
        Me.CboxNewEmployee.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.KasunEdit7
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(340, 93)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.TabIndex = 175
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "5"
        '
        'cmbSubDept
        '
        Me.cmbSubDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubDept.FormattingEnabled = True
        Me.cmbSubDept.Location = New System.Drawing.Point(123, 93)
        Me.cmbSubDept.Name = "cmbSubDept"
        Me.cmbSubDept.Size = New System.Drawing.Size(183, 21)
        Me.cmbSubDept.TabIndex = 172
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Sub Department"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.HRISforBB.My.Resources.Resources.kasunAdd
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(312, 93)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox2.TabIndex = 174
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = "5"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.pbNewSubCategory)
        Me.Panel1.Controls.Add(Me.cmbSubDept)
        Me.Panel1.Controls.Add(Me.pbEditName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.pbEditFirstJoin)
        Me.Panel1.Controls.Add(Me.CboxNewEmployee)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.pbAddNewAct)
        Me.Panel1.Controls.Add(Me.txtEpfNo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.dtpFirstJoin)
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.txtAgeFromFirstJoin)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbSubCat)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.pbEditEpf)
        Me.Panel1.Controls.Add(Me.cmbAct)
        Me.Panel1.Controls.Add(Me.pbSubCatEdit)
        Me.Panel1.Controls.Add(Me.pbActEdit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 437)
        Me.Panel1.TabIndex = 176
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 38)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1012, 437)
        Me.Panel2.TabIndex = 177
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.pnlMostRight)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.pbNewNearCity)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.cmbNearestCity)
        Me.Panel3.Controls.Add(Me.pbDisasEdit)
        Me.Panel3.Controls.Add(Me.pbNearCtyEdit)
        Me.Panel3.Controls.Add(Me.cmbDisasterArea)
        Me.Panel3.Controls.Add(Me.pbNewDisasterArea)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(402, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(610, 437)
        Me.Panel3.TabIndex = 177
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(121, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(258, 3)
        Me.Label2.TabIndex = 176
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(253, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(357, 232)
        Me.Panel4.TabIndex = 0
        '
        'frmHRMAdtionalInfomation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1012, 475)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlMyTop)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHRMAdtionalInfomation"
        Me.Text = "HRM Infomation"
        Me.pnlMostRight.ResumeLayout(False)
        CType(Me.pbDisasEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbNewDisasterArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbNearCtyEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbNewNearCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditEpf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSubCatEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbActEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMyTop.ResumeLayout(False)
        Me.pnlMyTop.PerformLayout()
        CType(Me.pbAddNewAct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditFirstJoin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbEditName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbNewSubCategory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbSubCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents pnlMyTop As System.Windows.Forms.Panel
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents pbEditFirstJoin As System.Windows.Forms.PictureBox
    Friend WithEvents pbEditName As System.Windows.Forms.PictureBox
    Friend WithEvents pbNewSubCategory As System.Windows.Forms.PictureBox
    Friend WithEvents pbAddNewAct As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbAct As System.Windows.Forms.ComboBox
    'Friend WithEvents pic As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DeptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deptName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pbEditEpf As System.Windows.Forms.PictureBox
    Friend WithEvents pbActEdit As System.Windows.Forms.PictureBox
    Friend WithEvents pbSubCatEdit As System.Windows.Forms.PictureBox
    Friend WithEvents pbNearCtyEdit As System.Windows.Forms.PictureBox
    Friend WithEvents cmbNearestCity As System.Windows.Forms.ComboBox
    Friend WithEvents pbNewNearCity As System.Windows.Forms.PictureBox
    Friend WithEvents pbDisasEdit As System.Windows.Forms.PictureBox
    Friend WithEvents cmbDisasterArea As System.Windows.Forms.ComboBox
    Friend WithEvents pbNewDisasterArea As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpFirstJoin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEpfNo As System.Windows.Forms.TextBox
    Friend WithEvents pnlMostRight As System.Windows.Forms.Panel
    Friend WithEvents txtAgeFromFirstJoin As System.Windows.Forms.TextBox
    Friend WithEvents CboxNewEmployee As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbSubDept As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel

End Class
