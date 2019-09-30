Public Class frmOTAuthorize

    Dim StrEmpID As String = "" : Dim dtWorkDate As Date
    Dim bolLoad As Boolean = True

    Private Sub frmOTAuthorize_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)

        'Create Tables 
        Dim sqlTable As String = ""
        sqlTable = "CREATE TABLE tblAprovedOT (EmpID nvarchar (6),AtDate DateTime,ExNOT Numeric (18,2),ExDOT Numeric (18,2),ExTOT Numeric (18,2),ApNOT Numeric (18,2),ApDOT Numeric (18,2),ApTOT Numeric (18,2),UserID Nvarchar (3),Status Numeric (18,0))" : FK_EQ(sqlTable, "S", "", False, False, False)
        sSQL = "ALTER TABLE tblAprovedOT ADD remarks nvarchar (256) not null default '-'" : FK_EQ(sSQL, "S", "", False, False, False)
        sSQL = "CREATE TABLE [dbo].[tblAprovedOTRemotely]([EmpID] [nvarchar](6) NULL,[AtDate] [datetime] NULL,[ExNOT] [numeric](18, 2) NULL,[ExDOT] [numeric](18, 2) NULL,[ExTOT] [numeric](18, 2) NULL,[ApNOT] [numeric](18, 2) NULL,[ApDOT] [numeric](18, 2) NULL,[ApTOT] [numeric](18, 2) NULL,[UserID] [nvarchar](3) NULL,[Status] [numeric](18, 0) NULL,[remarks] [nvarchar](256) NOT NULL DEFAULT ('-')) " : FK_EQ(sSQL, "S", "", False, False, False)

        cmdRefresh_Click(sender, e)
    End Sub

    Public Sub Process_Search()
        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.enrolNo" Else sqlTag = "tblEmployee.EmpNo"
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", (cmbDept.Text))
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", (cmbCat.Text))
        Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", (cmbDesg.Text))
        Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", (cmbBranch.Text))
        Dim StrType As String = IIf(cmbType.Text = "[ALL]", "", (cmbType.Text))

        sSQL = "CREATE TABLE #T (RegID NVARCHAR (6),EnrolNo NVARCHAR(6),DispName NVARCHAR (345),DeptID NVARCHAR (3),DesigID NVARCHAR (3),BranchID NVARCHAR (3),CatID NVARCHAR (3),TypeID NVARCHAR (3),Department NVARCHAR (246),Designation NVARCHAR (146),Branch NVARCHAR (245),Category NVARCHAR (145),EmpType NVARCHAR (245),atDate DATETIME,inTime DATETIME ,OutTime DATETIME,workHrs NUMERIC (18,2),COTHrs NUMERIC (18,2),NormalOTHrs NUMERIC (18,2),DoubleOTHrs NUMERIC (18,2),TripleOTHrs NUMERIC (18,2)) INSERT INTO #T select  tblEmpRegister.EmpID,RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as '" & sqlTag1.Split("."c)(1) & "' ,tblEmployee.DispName, tblEmployee.DeptID,tblEmployee.DesigID,tblEmployee.brID,tblEmployee.catID,tblEmployee.EmpTypeID,'D','DS','BR','CA','TY',tblEmpRegister.AtDate,Convert(Nvarchar(5),tblEmpRegister.InTime1,108),Convert(Nvarchar(5),tblEmpRegister.OutTime1,108),tblEmpRegister.WorkHrs,tblEmpRegister.COThrs,tblEmpRegister.NormalOThrs,tblEmpRegister.DoubleOTHrs,tblEmpRegister.TripleOThrs FROM  tblEmpRegister,tblEmployee WHERE tblEmployee.RegID=tblEmpRegister.empID AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' AND tblEmpREgister.AntStatus = 1  AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') UPDATE #T SET Designation=tblDesig.desgDesc FROM  dbo.tblDesig WHERE  #T.DesigID = dbo.tblDesig.DesgID UPDATE #T SET Department=tblSetDept.deptName FROM  dbo.tblSetDept WHERE  #T.deptID = dbo.tblSetDept.DeptID UPDATE #T SET Branch=tblCBranchs.brName FROM  dbo.tblCBranchs WHERE  #T.branchID = dbo.tblCBranchs.brID UPDATE #T SET category=tblSetEmpCategory.catDesc FROM  dbo.tblSetEmpCategory WHERE  #T.catID = dbo.tblSetEmpCategory.catID UPDATE #T SET EmpType=tblSetEmpType.tDesc FROM  dbo.tblSetEmpType WHERE  #T.typeID = dbo.tblSetEmpType.typeID " & _
        "SELECT RegID,enrolNo,dispName,atDate,Convert(Nvarchar(5),InTime,108),Convert(Nvarchar(5),outtime,108),workHrs,COTHrs,NormalOTHrs,DoubleOTHrs,TripleOTHrs FROM #T WHERE  (dbo.#T.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.#T.DispName LIKE '% " & txtSearch.Text & " %' OR     " & _
         "dbo.#T.EnrolNo LIKE '%" & txtSearch.Text & "%')  AND    " & _
          "(dbo.#T.Designation LIKE '%" & StrDesigName & "%' AND " & _
        "dbo.#T.Department LIKE '%" & StrDeptname & "%' AND " & _
        "dbo.#T.Branch LIKE '%" & StrBranchName & "%' AND " & _
        " #T.Category LIKE '" & StrSubCatName & "%' AND " & _
        "dbo.#T.EmpType LIKE '%" & StrType & "%') "

        'Dim strQuery As String = "select  dbo.tblEmployee.RegID,dbo." & sqlTag & ", dbo.tblEmployee.dispName," & _
        '"tblEmpRegister.AtDate,Convert(Nvarchar(5),tblEmpRegister.InTime1,108),Convert(Nvarchar(5),tblEmpRegister.OutTime1,108),tblEmpRegister.WorkHrs,tblEmpRegister.COThrs,tblEmpRegister.NormalOThrs,tblEmpRegister.DoubleOTHrs,tblEmpRegister.TripleOThrs FROM dbo.tblEmployee " & _
        '"INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        '"INNER JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        '"Inner Join dbo.tblSetEmpType ON dbo.tblEmployee.EmpTypeID = dbo.tblSetEmpType.TypeID " & _
        '" INNER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID = dbo.tblEmployee.BrID " & _
        '" INNER JOIN tblSetEmpCategory ON tblEmployee.CatID = tblSetEmpCategory.CatID " & _
        '" INNER JOIN tblEmpRegister ON tblEmployee.RegID = tblEmpRegister.EmpID " & _
        '"WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%' OR " & _
        '"dbo.tblCBranchs.BrName LIKE '%" & txtSearch.Text & "%' OR " & _
        '" tblSetEmpCategory.CatDesc LIKE '" & txtSearch.Text & "%' OR " & _
        '"dbo.tblSetEmpType.tDesc LIKE '%" & txtSearch.Text & "%') AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' AND tblEmpREgister.AntStatus = 1 " & _
        '"order by tblEmpRegister.AtDate , " & sqlTag & ""

        Load_InformationtoGrid(sSQL, dgvDetails, 11)
        clr_Grid(dgvDetails)

        lblCount.Text = "Total Employees : " & dgvDetails.RowCount

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged
        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        bolLoad = True
        dtpToDate.Value = dtLastProcessed
        dtpFrDate.Value = dtLastProcessed
        ListComboAll(cmbDesg, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "desgDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0  AND deptid in ('" & StrUserLvDept & "') Order By DeptID", "deptName")
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType WHERE Status = 0 order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] WHERE Status = 0 order by BrID asc", "BrName")
        bolLoad = False
        Process_Search()

    End Sub

    Private Sub dtpFrDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrDate.ValueChanged
        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub dgvDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetails.Click

        Try
            With dgvDetails
                StrEmpID = .Item(0, .CurrentRow.Index).Value
                dtWorkDate = .Item(3, .CurrentRow.Index).Value
                StrEmployeeID = StrEmpID
                _OpenSELECTEDDay(StrEmpID, dtWorkDate)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _OpenSELECTEDDay(ByVal EmpID As String, ByVal WorkDate As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "SELECT tblEmployee.RegID,tblEmployee.DispName,tblSetDept.DeptName,tblEmpRegister.NOrmalOTHrs,tblEmpRegister.DoubleOTHrs,tblEmpRegister.TripleOTHrs FROM tblEmployee,tblSetDept,tblEmpRegister WHERE tblEmployee.DeptID = tblSetDept.DeptID AND tblEmployee.RegID = tblEmpRegister.EmpID AND tblEmpRegister.AtDate = '" & Format(WorkDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID = '" & EmpID & "'"
        fk_Return_MultyString(sqlQRY, 6)
        txtEmpName.Text = fk_ReadGRID(1)
        txtDept.Text = fk_ReadGRID(2)
        txtExNOT.Text = fk_ReadGRID(3)
        txtExDOT.Text = fk_ReadGRID(4)
        txtExtOT.Text = fk_ReadGRID(5)

        txtApvNOT.Text = fk_ReadGRID(3)
        txtApvDOT.Text = fk_ReadGRID(4)
        txtApvTOT.Text = fk_ReadGRID(5)

        sSQL = "SELECT remarks FROM tblAprovedOT WHERE atDate= '" & Format(WorkDate, strRetDateTimeFormat) & "' AND EmpID = '" & EmpID & "' and STATUS=0"
        txtRemark.Text = fk_RetString(sSQL)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If UP("Over Time", "Edit OT Hours") = False Then Exit Sub
        Dim StrChgNOT As String = "0" : Dim StrChgDOT As String = "0" : Dim StrChgTOT As String = "0" : Dim StrChgValue As String = ""
        If CDbl(txtExNOT.Text) = CDbl(txtApvNOT.Text) Then StrChgNOT = "0" Else StrChgNOT = "1"
        If CDbl(txtExDOT.Text) = CDbl(txtApvDOT.Text) Then StrChgDOT = "0" Else StrChgDOT = "1"
        If CDbl(txtExtOT.Text) = CDbl(txtApvTOT.Text) Then StrChgTOT = "0" Else StrChgTOT = "1"
        If txtRemark.Text = "" Then MessageBox.Show("Please enter OT Narration", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Dim sqlQRY As String = ""

        StrChgValue = StrChgNOT & StrChgDOT & StrChgTOT
        If StrChgValue = "000" Then MsgBox("No Value deferances", MsgBoxStyle.Question)
        If MsgBox("Do you want to save date?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If dtWorkDate = "12:00:00 AM" Then MessageBox.Show("Please select date", "Ättention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        sqlQRY = "UPDATE tblAprovedOT SET Status = 1 WHERE EmpID = '" & StrEmpID & "' AND AtDate = '" & Format(dtWorkDate, strRetDateTimeFormat) & "'"
        sqlQRY = sqlQRY & " INSERT INTO tblAprovedOT (EmpID,AtDate,ExNOT,ExDOT,ExTOT,ApNOT,ApDOT,ApTOT,UserID,Status,remarks) VALUES " & _
        " ('" & StrEmpID & "','" & Format(dtWorkDate, strRetDateTimeFormat) & "'," & CDbl(txtExNOT.Text) & "," & CDbl(txtExDOT.Text) & "," & CDbl(txtExtOT.Text) & "," & CDbl(txtApvNOT.Text) & "," & CDbl(txtApvDOT.Text) & "," & CDbl(txtApvTOT.Text) & ",'" & Microsoft.VisualBasic.Left(StrUserID, 3) & "',0,'" & FK_Rep(txtRemark.Text) & "')"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET NormalOThrs = " & CDbl(txtApvNOT.Text) & ",DoubleOThrs = " & CDbl(txtApvDOT.Text) & ",TripleOThrs = " & CDbl(txtApvTOT.Text) & " WHERE EmpID = '" & StrEmpID & "' AND AtDate = '" & Format(dtWorkDate, strRetDateTimeFormat) & "'"

        FK_EQ(sqlQRY, "S", "", False, True, True)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If bolLoad = False Then Process_Search()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StrReportID = "056"
        _ReportView(StrReportID)
    End Sub

    Public Sub _ReportView(ByVal StrRID As String)
        Dim FromDate As String = Format(dtpFrDate.Value, "yyyy, MM, dd")
        Dim ToDate As String = Format(dtpToDate.Value, "yyyy, MM, dd")
        Dim StrTFormula As String = ""
        StrReportID = StrRID
        mod_ReportAttendance.ReportID = StrReportID
        Select Case StrReportID
            Case "056"
                StrTFormula = "{tblaprovedot.atdate}>= Date('" & Format(dtpFrDate.Value, "yyyy,MM,dd") & "') AND  {tblaprovedot.atdate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')"
        End Select
        StrRpFromDate = Format(dtpFrDate.Value, "dd/MMM/yyyy")
        StrRpToDate = Format(dtpToDate.Value, "dd/MMM/yyyy")

        'StrRepFile = Application.StartupPath & "\Reports\" & strLoadReport
        ''If StrTFormula = "" Then StrSelectionFomula = strFormulaFromDB Else StrSelectionFomula = strFormulaFromDB & StrTFormula
        ''Dim frmRepCont As New frmRepContainer
        ''frmRepCont.ShowDialog()

        Me.Cursor = Cursors.Default
        'StrRepFile = Application.StartupPath & "\Reports\" & strLoadReport
        StrSelectionFomula = StrTFormula
        Dim frmRepCont As New frmRepContainerAttn
        frmRepCont.Show()

    End Sub

End Class