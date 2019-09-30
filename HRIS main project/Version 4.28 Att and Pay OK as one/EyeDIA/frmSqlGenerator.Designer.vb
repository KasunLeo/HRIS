<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSqlGenerator
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.chkLinkTable = New System.Windows.Forms.CheckBox
        Me.chkRemove = New System.Windows.Forms.CheckBox
        Me.txtTableID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTableLink = New System.Windows.Forms.TextBox
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbTFldList = New System.Windows.Forms.ComboBox
        Me.cmbTableList = New System.Windows.Forms.ComboBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.dgvTableList = New System.Windows.Forms.DataGridView
        Me.tableID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TableName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Descrip = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.r_Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.dgvAllFldList = New System.Windows.Forms.DataGridView
        Me.fCheckBox = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.rFldID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rfldname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.full_Name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FldDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.dgvAllTableList = New System.Windows.Forms.DataGridView
        Me.chkBox1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tblOrigN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.chkRemvReport = New System.Windows.Forms.CheckBox
        Me.cmbSavedReports = New System.Windows.Forms.ComboBox
        Me.txtReportFields = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtReportName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtReportID = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.dgvRepSelection = New System.Windows.Forms.DataGridView
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LTableName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvTableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.dgvAllFldList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvAllTableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.dgvRepSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(889, 401)
        Me.Panel2.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(889, 401)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(881, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Add Tables"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.chkLinkTable)
        Me.Panel4.Controls.Add(Me.chkRemove)
        Me.Panel4.Controls.Add(Me.txtTableID)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.txtTableLink)
        Me.Panel4.Controls.Add(Me.txtTableName)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.cmbTFldList)
        Me.Panel4.Controls.Add(Me.cmbTableList)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(448, 369)
        Me.Panel4.TabIndex = 6
        '
        'chkLinkTable
        '
        Me.chkLinkTable.AutoSize = True
        Me.chkLinkTable.Location = New System.Drawing.Point(56, 230)
        Me.chkLinkTable.Name = "chkLinkTable"
        Me.chkLinkTable.Size = New System.Drawing.Size(15, 14)
        Me.chkLinkTable.TabIndex = 55
        Me.chkLinkTable.UseVisualStyleBackColor = True
        '
        'chkRemove
        '
        Me.chkRemove.AutoSize = True
        Me.chkRemove.Location = New System.Drawing.Point(56, 315)
        Me.chkRemove.Name = "chkRemove"
        Me.chkRemove.Size = New System.Drawing.Size(15, 14)
        Me.chkRemove.TabIndex = 55
        Me.chkRemove.UseVisualStyleBackColor = True
        '
        'txtTableID
        '
        Me.txtTableID.Location = New System.Drawing.Point(56, 48)
        Me.txtTableID.Name = "txtTableID"
        Me.txtTableID.Size = New System.Drawing.Size(132, 21)
        Me.txtTableID.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Table ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 207)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Link with Table"
        '
        'txtTableLink
        '
        Me.txtTableLink.Location = New System.Drawing.Point(56, 268)
        Me.txtTableLink.Name = "txtTableLink"
        Me.txtTableLink.Size = New System.Drawing.Size(258, 21)
        Me.txtTableLink.TabIndex = 54
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(56, 134)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(258, 21)
        Me.txtTableName.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 292)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Enter Table Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Select Primary Key"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 249)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(181, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Link with (Table + Feild Name)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Select Table"
        '
        'cmbTFldList
        '
        Me.cmbTFldList.BackColor = System.Drawing.Color.White
        Me.cmbTFldList.FormattingEnabled = True
        Me.cmbTFldList.Location = New System.Drawing.Point(56, 180)
        Me.cmbTFldList.Name = "cmbTFldList"
        Me.cmbTFldList.Size = New System.Drawing.Size(258, 21)
        Me.cmbTFldList.TabIndex = 52
        '
        'cmbTableList
        '
        Me.cmbTableList.BackColor = System.Drawing.Color.White
        Me.cmbTableList.FormattingEnabled = True
        Me.cmbTableList.Location = New System.Drawing.Point(56, 91)
        Me.cmbTableList.Name = "cmbTableList"
        Me.cmbTableList.Size = New System.Drawing.Size(258, 21)
        Me.cmbTableList.TabIndex = 52
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvTableList)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(451, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(427, 369)
        Me.Panel3.TabIndex = 6
        '
        'dgvTableList
        '
        Me.dgvTableList.AllowUserToAddRows = False
        Me.dgvTableList.BackgroundColor = System.Drawing.Color.White
        Me.dgvTableList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTableList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tableID, Me.TableName, Me.Descrip, Me.PrK, Me.r_Status})
        Me.dgvTableList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTableList.GridColor = System.Drawing.Color.White
        Me.dgvTableList.Location = New System.Drawing.Point(0, 0)
        Me.dgvTableList.Name = "dgvTableList"
        Me.dgvTableList.ReadOnly = True
        Me.dgvTableList.RowHeadersVisible = False
        Me.dgvTableList.RowHeadersWidth = 12
        Me.dgvTableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTableList.Size = New System.Drawing.Size(427, 369)
        Me.dgvTableList.TabIndex = 5
        Me.dgvTableList.Tag = "1"
        '
        'tableID
        '
        Me.tableID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.tableID.HeaderText = "Table ID"
        Me.tableID.Name = "tableID"
        Me.tableID.ReadOnly = True
        Me.tableID.Visible = False
        '
        'TableName
        '
        Me.TableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.TableName.HeaderText = "Table Name"
        Me.TableName.Name = "TableName"
        Me.TableName.ReadOnly = True
        Me.TableName.Width = 99
        '
        'Descrip
        '
        Me.Descrip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descrip.HeaderText = "Description"
        Me.Descrip.Name = "Descrip"
        Me.Descrip.ReadOnly = True
        '
        'PrK
        '
        Me.PrK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.PrK.HeaderText = "PrimaryKey"
        Me.PrK.Name = "PrK"
        Me.PrK.ReadOnly = True
        Me.PrK.Width = 99
        '
        'r_Status
        '
        Me.r_Status.HeaderText = "rStatus"
        Me.r_Status.Name = "r_Status"
        Me.r_Status.ReadOnly = True
        Me.r_Status.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel6)
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(919, 468)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Add Table Feilds"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 42)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(913, 423)
        Me.Panel6.TabIndex = 7
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.dgvAllFldList)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(243, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(416, 423)
        Me.Panel8.TabIndex = 7
        '
        'dgvAllFldList
        '
        Me.dgvAllFldList.AllowUserToAddRows = False
        Me.dgvAllFldList.BackgroundColor = System.Drawing.Color.White
        Me.dgvAllFldList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAllFldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllFldList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fCheckBox, Me.rFldID, Me.Rfldname, Me.full_Name, Me.FldDesc})
        Me.dgvAllFldList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAllFldList.GridColor = System.Drawing.Color.White
        Me.dgvAllFldList.Location = New System.Drawing.Point(0, 0)
        Me.dgvAllFldList.Name = "dgvAllFldList"
        Me.dgvAllFldList.RowHeadersVisible = False
        Me.dgvAllFldList.RowHeadersWidth = 12
        Me.dgvAllFldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllFldList.Size = New System.Drawing.Size(416, 423)
        Me.dgvAllFldList.TabIndex = 7
        Me.dgvAllFldList.Tag = "1"
        '
        'fCheckBox
        '
        Me.fCheckBox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.fCheckBox.HeaderText = "[X]"
        Me.fCheckBox.Name = "fCheckBox"
        Me.fCheckBox.Width = 31
        '
        'rFldID
        '
        Me.rFldID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.rFldID.HeaderText = "Feild ID"
        Me.rFldID.Name = "rFldID"
        Me.rFldID.ReadOnly = True
        Me.rFldID.Visible = False
        '
        'Rfldname
        '
        Me.Rfldname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Rfldname.HeaderText = "Feild Name"
        Me.Rfldname.Name = "Rfldname"
        Me.Rfldname.ReadOnly = True
        Me.Rfldname.Width = 95
        '
        'full_Name
        '
        Me.full_Name.HeaderText = "Full Name"
        Me.full_Name.Name = "full_Name"
        Me.full_Name.Visible = False
        '
        'FldDesc
        '
        Me.FldDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.FldDesc.HeaderText = "Decription"
        Me.FldDesc.Name = "FldDesc"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.dgvAllTableList)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(243, 423)
        Me.Panel7.TabIndex = 7
        '
        'dgvAllTableList
        '
        Me.dgvAllTableList.AllowUserToAddRows = False
        Me.dgvAllTableList.BackgroundColor = System.Drawing.Color.White
        Me.dgvAllTableList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAllTableList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllTableList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkBox1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.tblOrigN})
        Me.dgvAllTableList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAllTableList.GridColor = System.Drawing.Color.White
        Me.dgvAllTableList.Location = New System.Drawing.Point(0, 0)
        Me.dgvAllTableList.Name = "dgvAllTableList"
        Me.dgvAllTableList.RowHeadersVisible = False
        Me.dgvAllTableList.RowHeadersWidth = 12
        Me.dgvAllTableList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllTableList.Size = New System.Drawing.Size(243, 423)
        Me.dgvAllTableList.TabIndex = 6
        Me.dgvAllTableList.Tag = "1"
        '
        'chkBox1
        '
        Me.chkBox1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.chkBox1.HeaderText = "[X]"
        Me.chkBox1.Name = "chkBox1"
        Me.chkBox1.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn1.HeaderText = "Table ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Table Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'tblOrigN
        '
        Me.tblOrigN.HeaderText = "tblOrigN"
        Me.tblOrigN.Name = "tblOrigN"
        Me.tblOrigN.ReadOnly = True
        Me.tblOrigN.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(913, 39)
        Me.Panel5.TabIndex = 7
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel10)
        Me.TabPage3.Controls.Add(Me.Panel9)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(919, 468)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Setup New Report"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.chkRemvReport)
        Me.Panel10.Controls.Add(Me.cmbSavedReports)
        Me.Panel10.Controls.Add(Me.txtReportFields)
        Me.Panel10.Controls.Add(Me.Label10)
        Me.Panel10.Controls.Add(Me.txtReportName)
        Me.Panel10.Controls.Add(Me.Label9)
        Me.Panel10.Controls.Add(Me.txtReportID)
        Me.Panel10.Controls.Add(Me.Label7)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(3, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(527, 462)
        Me.Panel10.TabIndex = 9
        '
        'chkRemvReport
        '
        Me.chkRemvReport.AutoSize = True
        Me.chkRemvReport.Location = New System.Drawing.Point(123, 438)
        Me.chkRemvReport.Name = "chkRemvReport"
        Me.chkRemvReport.Size = New System.Drawing.Size(129, 17)
        Me.chkRemvReport.TabIndex = 58
        Me.chkRemvReport.Text = "Delete this Report"
        Me.chkRemvReport.UseVisualStyleBackColor = True
        '
        'cmbSavedReports
        '
        Me.cmbSavedReports.BackColor = System.Drawing.Color.White
        Me.cmbSavedReports.FormattingEnabled = True
        Me.cmbSavedReports.Location = New System.Drawing.Point(240, 22)
        Me.cmbSavedReports.Name = "cmbSavedReports"
        Me.cmbSavedReports.Size = New System.Drawing.Size(258, 21)
        Me.cmbSavedReports.TabIndex = 57
        '
        'txtReportFields
        '
        Me.txtReportFields.Location = New System.Drawing.Point(123, 76)
        Me.txtReportFields.Multiline = True
        Me.txtReportFields.Name = "txtReportFields"
        Me.txtReportFields.Size = New System.Drawing.Size(398, 356)
        Me.txtReportFields.TabIndex = 56
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Selected Fields"
        '
        'txtReportName
        '
        Me.txtReportName.Location = New System.Drawing.Point(123, 49)
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.Size = New System.Drawing.Size(375, 21)
        Me.txtReportName.TabIndex = 56
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Report Name"
        '
        'txtReportID
        '
        Me.txtReportID.Location = New System.Drawing.Point(123, 22)
        Me.txtReportID.Name = "txtReportID"
        Me.txtReportID.Size = New System.Drawing.Size(111, 21)
        Me.txtReportID.TabIndex = 56
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Report ID"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.dgvRepSelection)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel9.Location = New System.Drawing.Point(530, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(386, 462)
        Me.Panel9.TabIndex = 8
        '
        'dgvRepSelection
        '
        Me.dgvRepSelection.AllowUserToAddRows = False
        Me.dgvRepSelection.BackgroundColor = System.Drawing.Color.White
        Me.dgvRepSelection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRepSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRepSelection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.LTableName, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.dgvRepSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRepSelection.GridColor = System.Drawing.Color.White
        Me.dgvRepSelection.Location = New System.Drawing.Point(0, 0)
        Me.dgvRepSelection.Name = "dgvRepSelection"
        Me.dgvRepSelection.RowHeadersVisible = False
        Me.dgvRepSelection.RowHeadersWidth = 12
        Me.dgvRepSelection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRepSelection.Size = New System.Drawing.Size(386, 462)
        Me.dgvRepSelection.TabIndex = 7
        Me.dgvRepSelection.Tag = "1"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewCheckBoxColumn1.HeaderText = "[X]"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 31
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn3.HeaderText = "Feild ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.HeaderText = "Feild Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'LTableName
        '
        Me.LTableName.HeaderText = "Table Name"
        Me.LTableName.Name = "LTableName"
        Me.LTableName.ReadOnly = True
        Me.LTableName.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Full Name"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.HeaderText = "Decription"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.cmdSave)
        Me.Panel1.Controls.Add(Me.cmdRefresh)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 48)
        Me.Panel1.TabIndex = 1
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
        Me.cmdSave.Location = New System.Drawing.Point(840, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(28, 28)
        Me.cmdSave.TabIndex = 61
        Me.cmdSave.Tag = "3"
        Me.cmdSave.UseVisualStyleBackColor = False
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
        Me.cmdRefresh.Location = New System.Drawing.Point(876, 10)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(28, 28)
        Me.cmdRefresh.TabIndex = 62
        Me.cmdRefresh.Tag = "3"
        Me.cmdRefresh.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.HRISforBB.My.Resources.Resources.time_icon
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(7, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(49, 47)
        Me.PictureBox1.TabIndex = 44
        Me.PictureBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Transparent
        Me.Label25.Location = New System.Drawing.Point(60, 17)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(181, 14)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "Query Builder Table Setup"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSqlGenerator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(889, 449)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSqlGenerator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSqlGenerator"
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvTableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.dgvAllFldList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        CType(Me.dgvAllTableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        CType(Me.dgvRepSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dgvTableList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbTableList As System.Windows.Forms.ComboBox
    Friend WithEvents txtTableID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkRemove As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTFldList As System.Windows.Forms.ComboBox
    Friend WithEvents tableID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descrip As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents r_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dgvAllTableList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents dgvAllFldList As System.Windows.Forms.DataGridView
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents chkBox1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tblOrigN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fCheckBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents rFldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rfldname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents full_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FldDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkLinkTable As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTableLink As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents dgvRepSelection As System.Windows.Forms.DataGridView
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtReportFields As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtReportName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtReportID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbSavedReports As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LTableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkRemvReport As System.Windows.Forms.CheckBox
End Class
