Public Class frmRandomReport

    Dim StrSvStatus As String
    Dim StrRID As String = ""
    Dim intcolomncount As Integer = 0
    Dim strClickTitle As String = ""

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Random Report", "View random report") = False Then Exit Sub
        If txtQry.Text = "" Then MsgBox("Enter Query", MsgBoxStyle.Information) : Exit Sub
        If txtTitle.Text = "" Then MsgBox("Enter Report Name ", MsgBoxStyle.Information) : Exit Sub
        Dim bolSave As Boolean = False
        Dim sqlQRY As String
        Select Case StrSvStatus
            Case "S"
                StrRID = fk_GenSerial("SELECT NoRRp FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblRandomRep VALUES ('" & StrRID & "','" & txtTitle.Text & "','" & Replace(txtQry.Text, "'", "`") & "')"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoRRp = NoRRp + 1"
                bolSave = FK_EQ(sqlQRY, "S", "", False, True, True)

            Case "E"
                sqlQRY = "UPDATE tblRandomRep SET RepName = '" & txtTitle.Text & "',RpQry = '" & Replace(txtQry.Text, "'", "`") & "' WHERE RepID = '" & StrRID & "'"
                bolSave = FK_EQ(sqlQRY, "E", "", False, True, True)
        End Select

        If bolSave = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub frmRandomReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterForm(Me)
        ControlHandlers(Me)
        If StrUlvlID = "HRIS" Then
            txtQry.Visible = True
        End If
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        StrSvStatus = "S"
        Dim crtl As Control
        For Each crtl In Me.GroupBox1.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        StrRID = fk_GenSerial("SELECT NoRRp FROM tblControl", 3)
        txtTitle.Text = StrRID

        Load_InformationtoGrid("SELECT RepID,RepName FROM tblRandomRep Order By repID", dgvReports, 2) : clr_Grid(dgvReports)
        btnToExcel.Enabled = False
        cmdView.Enabled = True
        dgvQuery.DataSource = Nothing
        dgvQuery.Columns.Clear()
        dgvQuery.Rows.Clear()
        lblColumn.Text = "Column"
        lblRow.Text = "Row"
        lblcount.Text = "Count"

        cmbMonth.Items.Clear()
        For i As Integer = 1 To 12
            cmbMonth.Items.Add(MonthName(i))
        Next

        cmbYear.Items.Clear()
        For i As Integer = Now.Date.Year - 5 To Now.Date.Year + 5
            cmbYear.Items.Add(i.ToString)
        Next

        ListComboAll(cmbBranch, "SELECT BRName FROM [tblCBranchs] order by BrID asc", "BrName")
        ListComboAll(cmbCategory, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0  AND deptid in ('" & StrUserLvDept & "') Order By DeptID", "deptName")

        cmbYear.Text = Now.Date.Year
        cmbMonth.Text = MonthName(Now.Date.Month)
        cmbBranch.SelectedIndex = 1
        cmbCategory.SelectedIndex = 0
        cmbDept.SelectedIndex = 0
    End Sub

    Private Sub dgvReports_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvReports.DoubleClick
        StrRID = dgvReports.Item(0, dgvReports.CurrentRow.Index).Value
        sSQL = "SELECT RepID,RepName,RpQry FROM tblRandomRep WHERE RepID = '" & StrRID & "'"
        fk_Return_MultyString(sSQL, 3)
        txtTitle.Text = fk_ReadGRID(1)
        txtQry.Text = Replace(fk_ReadGRID(2), "`", "'")
        StrSvStatus = "E"
        cmdView.Enabled = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        'VARIABLE WE CAN USE IN THIS MODULE *********************************************************************
        '@ST='20160101'
        '@ED='20160131'
        '@CMONTH='10'
        '@BRID='001'
        '@CYEAR='2016'
        '@CATID='001'
        '@DEPTID='001'
        'VARIABLE WE CAN USE IN THIS MODULE *********************************************************************

        If txtQry.Text = "" Then MessageBox.Show("Please type query to view", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtQry.Focus() : Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim strBRID As String = fk_RetString("SELECT BRID FROM [tblCBranchs] WHERE brName='" & cmbBranch.Text & "'")
        Dim strCat As String = fk_RetString("select catID from  tblSEtEmpCategory WHERE catDesc='" & cmbCategory.Text & "'")
        Dim strDept As String = fk_RetString("select deptID from tblsetdept WHERE deptName='" & cmbDept.Text & "'")

        Dim strVariable As String = "DECLARE @ST AS DATETIME; DECLARE @ED AS DATETIME; DECLARE @CYEAR AS NUMERIC(18,0); DECLARE @CMONTH AS NUMERIC (18,0);DECLARE @BRID AS NVARCHAR(3);DECLARE @CATID AS NVARCHAR(3);DECLARE @DEPTID AS NVARCHAR(3); SET @ST='" & Format(dtpFrDate.Value, "yyyyMMdd") & "'; SET @ED='" & Format(dtpEndDate.Value, "yyyyMMdd") & "'; SET @CYEAR= YEAR('" & Format(dtpFrDate.Value, "yyyyMMdd") & "'); SET @CMONTH= MONTH('" & Format(dtpFrDate.Value, "yyyyMMdd") & "');SET @BRID='" & strBRID & "';SET @CATID='" & strCat & "';SET @DEPTID='" & strDept & "' "
        sSQL = strVariable & " " & txtQry.Text
        Fk_FillGrid(sSQL, dgvQuery)
        clr_Grid(dgvQuery)
        intcolomncount = dgvQuery.ColumnCount
        lblcount.Text = "Total rows : " & dgvQuery.RowCount - 1
        Me.Cursor = Cursors.Default
        btnToExcel.Enabled = True
    End Sub

    Private Sub txtQuery_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQry.LostFocus
        'If txtQry.Text <> "" Then
        Dim strK As String = Microsoft.VisualBasic.Left(txtQry.Text.ToUpper, 6)
        If strK = "SELECT" Then
            cmdView.Enabled = True
        Else
            cmdView.Enabled = False
        End If
        'End If
    End Sub

    Private Sub dgvQuery_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuery.CellClick
        lblRow.Text = "Current row : " & dgvQuery.CurrentRow.Index + 1
        lblColumn.Text = "Current cell : " & dgvQuery.CurrentCell.ColumnIndex + 1
    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        If dgvQuery.RowCount < 1 Then MessageBox.Show("Please load data to gridview by typing correct select query", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgvQuery.Focus() : Exit Sub
        If MsgBox("Are you sure you want to Export this Data to Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'Get company name and address
        sSQL = "SELECT cName,Add1 + ' ' +Add2 + ' ' + Add3 FROM tblcompany"
        fk_Return_MultyString(sSQL, 2)
        Dim strComName As String = fk_ReadGRID(0)
        Dim strComAddres As String = fk_ReadGRID(1)

        ExporttoExcelWithHeader(dgvQuery, intcolomncount, strComName, Trim(txtTitle.Text) & " - " & dgvQuery.RowCount, 0, strComAddres)
        'ExporttoExcel(dgvQuery, intcolomncount)
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        dtpFrDate.Value = DateSerial(cmbYear.Text, cmbMonth.SelectedIndex + 1, 1)
        dtpEndDate.Value = DateSerial(cmbYear.Text, cmbMonth.SelectedIndex + 2, 0)
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim strBRID As String = fk_RetString("SELECT BRID FROM [tblCBranchs] WHERE brName='" & cmbBranch.Text & "'")
        Dim strCat As String = fk_RetString("select catID from  tblSEtEmpCategory WHERE catDesc='" & cmbCategory.Text & "'")
        Dim strDept As String = fk_RetString("select deptID from tblsetdept WHERE deptName='" & cmbDept.Text & "'")

        Dim strVariable As String = "DECLARE @ST AS DATETIME; DECLARE @ED AS DATETIME; DECLARE @CYEAR AS NUMERIC(18,0); DECLARE @CMONTH AS NUMERIC (18,0);DECLARE @BRID AS NVARCHAR(3);DECLARE @CATID AS NVARCHAR(3);DECLARE @DEPTID AS NVARCHAR(3); SET @ST='" & Format(dtpFrDate.Value, "yyyyMMdd") & "'; SET @ED='" & Format(dtpEndDate.Value, "yyyyMMdd") & "'; SET @CYEAR= YEAR('" & Format(dtpFrDate.Value, "yyyyMMdd") & "'); SET @CMONTH= MONTH('" & Format(dtpFrDate.Value, "yyyyMMdd") & "');SET @BRID='" & strBRID & "';SET @CATID='" & strCat & "';SET @DEPTID='" & strDept & "' "

        If txtQry.Text <> "" Then
            sSQL = strVariable & " " & txtQry.Text
            FK_EQ(sSQL, "P", "", False, True, True)
        End If
    End Sub

End Class