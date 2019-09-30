Public Class frmNewPayrollSummary
    Dim sqlQRY As String = ""
    Dim StrColumnList As String = "" : Dim StrDefaultValueSet As String = "" : Dim StrColumnName As String
    Dim intColNumber As Integer : Dim intAllColuns As Integer = 0 : Dim StrFullFeild
    Dim strAllBranchs As String = ""
    Dim strAllCategories As String = ""

    Private Sub frmNewPayrollSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControlHandlers(Me)
        CenterFormThemed(Me, Panel1, Label25)
        sqlQRY = "CREATE TABLE tblMonthlySummary (EmpID nvarchar (6),cYear Numeric (18,0),cMonth Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)

        cmdRefresh_Click(sender, e)

    End Sub

    Public Sub Creat_TableStructureReview(ByVal iYear As Integer, ByVal iMonth As Integer)
        Dim dgv As New DataGridView
        Dim StrnFldName As String = ""
        With dgv
            .Columns.Add("cID", "cID")
            .Columns.Add("cDesc", "cDesc")
            .Columns.Add("cName", "cName")
        End With
        sqlQRY = "SELECT pID,fldName,Descr FROM tblATTParam WHERE VisibleInR = 1 Order By pID" : Load_InformationtoGrid(sqlQRY, dgv, 3)
        dgvData.Columns.Clear()
        With dgvData
            .Columns.Add("RegID", "RegID") : .Columns(0).Visible = False
            .Columns.Add("EmpID", "EmpID") : .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns.Add("DispName", "Employee Name") : .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns.Add("cYear", "Year") : .Columns(3).Visible = False : .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns.Add("cMonth", "Month") : .Columns(4).Visible = False : .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            intColNumber = 5
        End With
        StrFullFeild = ""
        With dgv
            For i As Integer = 0 To .RowCount - 2
                StrnFldName = .Item(1, i).Value : StrColumnName = .Item(2, i).Value
                'sqlQRY = "ALTER TABLE tblMonthlySummary ADD " & StrnFldName & " Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)
                dgvData.Columns.Add(StrnFldName, StrColumnName) : dgvData.Columns(intColNumber).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : intColNumber = intColNumber + 1
                If StrColumnList = "" Then
                    StrColumnList = StrnFldName
                    StrFullFeild = "tblMonthlySummary." & StrnFldName
                    StrDefaultValueSet = "0"
                Else
                    StrColumnList = StrColumnList + "," & StrnFldName
                    StrFullFeild = StrFullFeild & "," & "tblMonthlySummary." & StrnFldName
                    StrDefaultValueSet = StrDefaultValueSet + "," + "0"
                End If
            Next
        End With

        'Review Details in the grid 
        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.EnrolNo" Else sqlTag = "tblEmployee.EmpNo"

        'Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", "and tblemployee.brid ='" & FK_GetIDR(cmbBranch.Text) & "'")

        'Reveiew Master Information 
        sqlQRY = "SELECT tblEmployee.RegID, " & sqlTag & ",tblEmployee.DispName,tblMonthlySummary.cYear,tblMonthlySummary.cMonth " & StrFullFeild & " FROM tblEmployee,tblMonthlySummary WHERE tblEmployee.RegID = tblMonthlySummary.EmpID AND tblMonthlySummary.cYear = " & iYear & " AND tblMonthlySummary.cMonth = " & iMonth & " AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "')   Order By " & sqlTag
        Load_InformationtoGrid(sqlQRY, dgvData, intColNumber) : clr_Grid(dgvData)
        GroupBox1.Text = "Total Employees : " & dgvData.RowCount
    End Sub

    Public Sub Creat_TableStructure()
        Dim dgv As New DataGridView
        Dim StrnFldName As String = ""
        With dgv
            .Columns.Add("cID", "cID")
            .Columns.Add("cDesc", "cDesc")
            .Columns.Add("cName", "cName")
        End With
        sqlQRY = "SELECT pID,fldName,Descr FROM tblATTParam Order By pID" : Load_InformationtoGrid(sqlQRY, dgv, 3)
        With dgvData
            .Columns.Add("RegID", "RegID") : .Columns(0).Visible = False
            .Columns.Add("EmpID", "EmpID") : .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns.Add("DispName", "Employee Name") : .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            .Columns.Add("cYear", "Year") : .Columns(3).Visible = False : .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns.Add("cMonth", "Month") : .Columns(4).Visible = False : .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            intColNumber = 5
        End With

        StrFullFeild = ""
        'StrDefaultValueSet = "0"
        StrColumnList = ""
        With dgv
            For i As Integer = 0 To .RowCount - 2
                StrnFldName = .Item(1, i).Value : StrColumnName = .Item(2, i).Value
                sqlQRY = "ALTER TABLE tblMonthlySummary ADD " & StrnFldName & " Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)
                dgvData.Columns.Add(StrnFldName, StrColumnName) : dgvData.Columns(intColNumber).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader : intColNumber = intColNumber + 1
                If StrColumnList = "" Then
                    StrColumnList = StrnFldName
                    StrFullFeild = "tblMonthlySummary." & StrnFldName
                    StrDefaultValueSet = "0"
                Else
                    StrColumnList = StrColumnList + "," & StrnFldName
                    StrFullFeild = StrFullFeild & "," & "tblMonthlySummary." & StrnFldName
                    StrDefaultValueSet = StrDefaultValueSet + "," + "0"
                End If
            Next
        End With

    End Sub

    Public Sub _GenerateMasterRecordSet(ByVal iYear As Integer, ByVal iMonth As Integer)
        Try
            'Dim StrBranch As String = IIf(cmbBranch.Text = "[ALL]", "", "and tblEmployee.brid='" & FK_GetIDR(cmbBranch.Text) & "'")
            strAllBranchs = fk_getGridCLICK(dgvBranches, 0, 1)
            strAllBranchs = fk_SplitToSQL_in(strAllBranchs)

            strAllCategories = fk_getGridCLICK(dgvCat, 0, 1)
            strAllCategories = fk_SplitToSQL_in(strAllCategories)

            sqlQRY = "DELETe  tblMonthlySummary FROM tblMonthlySummary INNER JOIN tblEmployee ON tblMonthlySummary.empID=tblEmployee.regid WHERE tblMonthlySummary.cYear = " & iYear & " AND tblMonthlySummary.cMonth = " & iMonth & " AND tblEmployee.BrID In ('" & strAllBranchs & "') AND tblEmployee.catID In ('" & strAllCategories & "')  " : FK_EQ(sqlQRY, "S", "", False, False, False)
            'sqlQRY = "DELETE tblMonthlySummary FROM tblMonthlySummary WHERE regid in (select regid from tblREmpHist where resdate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' and '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = "INSERT INTO tblMonthlySummary SELECT RegID," & iYear & "," & iMonth & ", " & StrDefaultValueSet & " FROM tblEmployee WHERE EmpStatus <> 9  AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "')  " : FK_EQ(sqlQRY, "S", "", False, False, True)
            ''sqlQRY = "INSERT INTO tblMonthlySummary SELECT RegID," & iYear & "," & iMonth & ", " & StrDefaultValueSet & " FROM tblEmployee WHERE regid in (select tblEmployee.regid from tblREmpHist,tblEmployee where tblREmpHist.regid=tblemployee.regid and tblREmpHist.resdate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' and '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'   AND tblEmployee.BrID In ('" & strAllBranchs & "')  ) " : FK_EQ(sqlQRY, "S", "", False, False, True)

            Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
            Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.EnrolNo" Else sqlTag = "tblEmployee.EmpNo"

            'Reveiew Master Information 
            sqlQRY = "SELECT distinct tblEmployee.RegID, " & sqlTag & ",tblEmployee.DispName,tblMonthlySummary.cYear,tblMonthlySummary.cMonth, " & StrFullFeild & " FROM tblEmployee,tblMonthlySummary WHERE tblEmployee.RegID = tblMonthlySummary.EmpID AND tblMonthlySummary.cYear = " & iYear & " AND tblMonthlySummary.cMonth = " & iMonth & " Order By " & sqlTag
            Load_InformationtoGrid(sqlQRY, dgvData, intColNumber) : clr_Grid(dgvData)
            GroupBox1.Text = "Total Employees : " & dgvData.RowCount

           

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
    End Sub

    Public Sub _GenerateMasterRecordSetEx(ByVal iYear As Integer, ByVal iMonth As Integer)
        Try
            strAllBranchs = fk_getGridCLICK(dgvBranches, 0, 1)
            strAllBranchs = fk_SplitToSQL_in(strAllBranchs)

            strAllCategories = fk_getGridCLICK(dgvCat, 0, 1)
            strAllCategories = fk_SplitToSQL_in(strAllCategories)

            IsGetResignedToSummary = fk_sqlDbl("select IsGetResignedToSummary from tblcompany where compID='" & StrCompID & "'")
            IsRemoveNewFromSummary = fk_sqlDbl("select IsRemoveNewFromSummary from tblcompany where compID='" & StrCompID & "'")
            Dim stYear As String = iYear.ToString().PadLeft(4, "0")
            Dim stMonth As String = iMonth.ToString().PadLeft(2, "0")
            sqlQRY = "DELETE  tblMonthlySummary FROM tblMonthlySummary INNER JOIN tblEmployee ON tblMonthlySummary.empID=tblEmployee.regid WHERE tblMonthlySummary.cYear = " & iYear & " AND tblMonthlySummary.cMonth = " & iMonth & " AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "') " : FK_EQ(sqlQRY, "S", "", False, False, False)
            'sqlQRY = "DELETE tblMonthlySummary FROM tblMonthlySummary WHERE regid in (select regid from tblREmpHist where resdate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' and '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = "INSERT INTO tblMonthlySummary SELECT RegID," & iYear & "," & iMonth & ", " & StrDefaultValueSet & " FROM tblEmployee WHERE EmpStatus <> 9   AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "')  " : FK_EQ(sqlQRY, "S", "", False, False, True)
            If IsGetResignedToSummary = 1 Then
                sqlQRY = "INSERT INTO tblMonthlySummary SELECT RegID," & iYear & "," & iMonth & ", " & StrDefaultValueSet & " FROM tblEmployee WHERE regid in (select tblEmployee.regid from tblREmpHist INNER JOIN tblEmployee ON tblREmpHist.regid=tblemployee.regid WHERE (cast(tblREmpHist.lprcYear as char(4))+''+ case when len(cast(tblREmpHist.lPrcMonth as char(2)))=1 then '0'+cast(tblREmpHist.lPrcMonth as char(2) ) else cast(tblREmpHist.lPrcMonth as char(2))end >= " & stYear & stMonth & ") AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "') ) " : FK_EQ(sqlQRY, "S", "", False, False, True)
                sSQL = "DELETE FROM tblThisMonthResigned; INSERT INTO tblThisMonthResigned SELECT regID,ResDate,lPrcYear,LprcMonth from tblREmpHist WHERE (cast(tblREmpHist.lprcYear as char(4))+''+ case when len(cast(tblREmpHist.lPrcMonth as char(2)))=1 then '0'+cast(tblREmpHist.lPrcMonth as char(2) ) else cast(tblREmpHist.lPrcMonth as char(2))end >= " & stYear & stMonth & ")  " : FK_EQ(sSQL, "S", "", False, False, True)
            End If

            If IsRemoveNewFromSummary = 1 Then
                ' sqlQRY = "DELETE FROM tblThisMonthJoined; INSERT INTO tblThisMonthJoined SELECT RegID,regDate," & iYear & "," & iMonth & " FROM tblEmployee WHERE tblemployee.regDate between '" & Format(DateAdd(DateInterval.Day, 1, dtpEndDate.Value), "yyyyMMdd") & "' and '" & Format(dtWorkingDate, "yyyyMMdd") & "'  AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "') " : FK_EQ(sqlQRY, "S", "", False, False, True)
                ' sqlQRY = "DELETE FROM tblMonthlySummary WHERE empid IN (select regid FROM tblEmployee WHERE tblemployee.regDate between '" & Format(DateAdd(DateInterval.Day, 1, dtpEndDate.Value), "yyyyMMdd") & "' and '" & Format(dtWorkingDate, "yyyyMMdd") & "'  AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "') ) " : FK_EQ(sqlQRY, "S", "", False, False, True)

                sqlQRY = "DELETE FROM tblThisMonthJoined; INSERT INTO tblThisMonthJoined SELECT RegID,regDate," & iYear & "," & iMonth & " FROM tblEmployee WHERE tblemployee.regDate between '" & Format(DateAdd(DateInterval.Day, 1, dtpEndDate.Value), "yyyyMMdd") & "' and '" & Format(dtWorkingDate, "yyyyMMdd") & "'  AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "') " : FK_EQ(sqlQRY, "S", "", False, False, True)
                sqlQRY = "DELETE FROM tblMonthlySummary WHERE empid IN (select regid FROM tblEmployee WHERE tblemployee.regDate between '" & Format(DateAdd(DateInterval.Day, 1, dtpEndDate.Value), "yyyyMMdd") & "' and '" & Format(dtWorkingDate, "yyyyMMdd") & "'  AND tblEmployee.BrID In ('" & strAllBranchs & "')  AND tblEmployee.catID In ('" & strAllCategories & "') ) " : FK_EQ(sqlQRY, "S", "", False, False, True)

            End If
        Catch ex As Exception

        End Try

        'Execute Parameters 
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("cID", "cID")
            .Columns.Add("Qry", "Qry")
        End With

        'Load Executing Information 
        sqlQRY = "SELECT cID,sqlQRY FROM tblAttnFldConfig WHERE status = 0 Order By cID"
        Load_InformationtoGrid(sqlQRY, dgv, 2)
        Dim rString1 As String = " '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'"
        Dim rString2 As String = " '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"
        Dim intCurrentYear As Integer = cmbYear.Text
        Dim intCurrentMonth As Integer = cmbMonth.SelectedIndex + 1
        For i As Integer = 0 To dgv.RowCount - 2
            sqlQRY = dgv.Item(1, i).Value
            sqlQRY = Replace(sqlQRY, "@st", rString1)
            sqlQRY = Replace(sqlQRY, "@ed", rString2)
            sqlQRY = Replace(sqlQRY, "@cYear", intCurrentYear)
            sqlQRY = Replace(sqlQRY, "@cMonth", intCurrentMonth)
            FK_EQ(sqlQRY, "S", "", False, False, True)
        Next
        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.EnrolNo" Else sqlTag = "tblEmployee.EmpNo"

        'Reveiew Master Information 
        Creat_TableStructureReview(intCurrentYear, intCurrentMonth)
        'sqlQRY = "SELECT tblEmployee.RegID, " & sqlTag & ",tblEmployee.DispName,tblMonthlySummary.cYear,tblMonthlySummary.cMonth, " & StrFullFeild & " FROM tblEmployee,tblMonthlySummary WHERE tblEmployee.RegID = tblMonthlySummary.EmpID AND tblMonthlySummary.cYear = " & iYear & " AND tblMonthlySummary.cMonth = " & iMonth & " Order By " & sqlTag
        'Load_InformationtoGrid(sqlQRY, dgvData, intColNumber) : clr_Grid(dgvData)

        'If isSyncResigned = 1 Then
        '    sSQL = "update tblPayrollEmployee Set comid=tblemployee.compid,  DispName=tblEmployee.DispName,EmIDNum=tblEmployee.NicNumber,DeptID=tblEmployee.DeptID, EPFNo=tblEmployee.EpfNo,ETPNo=tblEmployee.EpfNo,        DesigID = tblEmployee.DesigID,status=tblEmployee.empStatus,birthDate=tblemployee.DofB,joiningDate=tblemployee.RegDate,genderID=tblemployee.genderID , BrID= tblemployee.BrID,sub_CatID= tblemployee.catid   from tblEmployee inner join  tblPayrollEmployee on tblPayrollEmployee.RegID=tblEmployee.RegID  WHERE tblEmployee.RegID IN (SELECT distinct empID from tblMonthlySummary where cyear=" & iYear & " and cmonth=" & iMonth & ")"
        '    sSQL = sSQL & " update tblPayrollEmployee set Status=0 where RegID in (SELECT distinct empID from tblMonthlySummary where cyear=" & iYear & " and cmonth=" & iMonth & ") update tblPayrollEmployee set Status=1 where RegID not in (SELECT distinct empID from tblMonthlySummary where cyear=" & iYear & " and cmonth=" & iMonth & ") "
        '    sSQL = sSQL & " update tblPayrollEmployee set genderID=0 where RegID in (Select RegID from tblEmployee where genderID='001')  and status=0;  update tblPayrollEmployee set genderID=1 where RegID in (Select RegID from tblEmployee where genderid='002')  and status=0"
        '    sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'FrmSync','Do the Syncronize All Employees Prcess from Attendance side','" & strUserID & "',0,'')"
        'End If
        lblResigned.Text = "This Month Resigned : " & fk_sqlDbl("select count(*) from tblThisMonthResigned")

        lblJoined.Text = "Next Month Joined : " & fk_sqlDbl("select count(*) from tblThisMonthJoined")

    End Sub

    Public Sub _LoadYear()
        cmbYear.Items.Clear()
        For i As Integer = 2013 To 2025
            cmbYear.Items.Add(i.ToString)
        Next
    End Sub

    Public Sub _LoadMonth()
        cmbMonth.Items.Clear()
        For i As Integer = 1 To 12
            cmbMonth.Items.Add(MonthName(i))
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim iYear As Integer = CInt(cmbYear.Text)
        Dim iMonth As Integer = cmbMonth.SelectedIndex + 1
        _GenerateMasterRecordSetEx(iYear, iMonth)
        cmdSave.Enabled = False
    End Sub

    Private Sub cmdToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToExcel.Click
        If MsgBox("Do You want to create excel file with this data", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ExporttoExcel(dgvData, intColNumber)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        _LoadYear()
        _LoadMonth()

        sSQL = "SELECT 'True',brID,brName FROM tblcbranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID"
        Load_InformationtoGrid(sSQL, dgvBranches, 3)

        sSQL = "SELECT 'True',catID,catDesc FROM tblSEtEmpCategory WHERE status=0 ORDER BY catDesc"
        Load_InformationtoGrid(sSQL, dgvCat, 3)

        cmbYear.Text = Now.Date.Year
        cmbMonth.Text = MonthName(Now.Date.Month)
        Creat_TableStructure()
        _GenerateMasterRecordSet(Now.Date.Year, Now.Date.Month)
        cmdSave.Enabled = True
        chkAll.Checked = True
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        dtpFrDate.Value = DateSerial(cmbYear.Text, cmbMonth.SelectedIndex + 1, 1)
        dtpEndDate.Value = DateSerial(cmbYear.Text, cmbMonth.SelectedIndex + 2, 0)
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For i As Integer = 0 To dgvBranches.RowCount - 1
            dgvBranches.Item(0, i).Value = chkAll.CheckState
        Next
    End Sub

    Private Sub chkAllCat_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllCat.CheckedChanged
        For i As Integer = 0 To dgvCat.RowCount - 1
            dgvCat.Item(0, i).Value = chkAllCat.CheckState
        Next
    End Sub

End Class