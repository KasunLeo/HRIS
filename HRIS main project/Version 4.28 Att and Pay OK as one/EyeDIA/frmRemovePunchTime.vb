Imports System.Data.SqlClient

Public Class frmRemovePunchTime

    Dim sTablek As New DataSet
    Dim strWhereClouse As String = ""
    Dim strSearchFor As String = "Original"
    Dim strDispCount As String = ""
    Dim strWhereClause As String

    Dim strSelectDate As String = ""
    Dim strDisplaySelected As String = ""
    Dim strCollectDisplay As String = ""
    Dim intEmp As Integer = 0
    Dim StrSelShift As String = ""
    Dim bolOK As Boolean = False
    Dim StrSelShiftID As String = ""

    Private Sub frmRemovePunchTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If UP("Remove punch times", "View punch time") = False Then Exit Sub
       
        ControlHandlers(Me)
        'CenterFormThemed(Me, pnlTopSet, Label6)
        If dtGlobalDate = "12:00:00 AM" Then
            dtGlobalDate = dtLastProcessed
        End If
        dtpFromDate.Value = dtGlobalDate
        dtpToDate.Value = dtGlobalDate

        FillComboAll(cmbDesg, "SELECT (desgdesc+'='+DesgID) FROM tblDesig WHERE Status = 0 Order By desgDesc")
        FillComboAll(cmbDept, "select (DeptName+'='+DeptID) From tblSetDept WHERE Status = 0 Order By deptName")
        FillComboAll(cmbCat, "select CatDesc+'='+catid From tblSEtEmpCategory WHERE Status = 0 Order By catDesc")
        FillComboAll(cmbShiftName, "select shiftName+'='+shiftID From tblSEtShiftH WHERE Status = 0 Order By shiftName")
        FillComboAll(cmbType, "select tDesc+'='+typeID from tblSetEmpType order by tDesc asc")
        FillComboAll(cmbBranch, "SELECT BrName+'='+BrID FROM [tblCBranchs] order by BrID asc")

        'CadreSearch()
        dtpFromDate.Value = dtGlobalDate
        dtpToDate.Value = dtGlobalDate
        'chkAutoRefresh.Checked = True
        'IsRunAutoCalculation = fk_sqlDbl("select IsRunAutoCalculation from tblcompany where compID='" & StrCompID & "'")
        'chkAutoCalculate.CheckState = IsRunAutoCalculation
        'End IfPunchTimeSearch
        strSearchFor = "Original"
        ViewInformation(0)
        PunchTimeSearch()
        InitialLoad()
        'ViewEmployee()
        rdbOriginal.Checked = True
        chkAutoRefresh.Checked = True

    End Sub

    Private Sub ViewInformation(ByVal intFirstTime As Integer)
        Me.Cursor = Cursors.WaitCursor

        Try
            Select Case intFirstTime
                Case 1
                    Fk_FillDataSet("exec SP_ViewPunchTime '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")

                Case 0
                    Fk_FillDataSet("exec SP_ViewPunchTime '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")

            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'sSQL = "select  convert(int,sum(antStatus)) as Present, convert(int,sum(isLeave)) as Leave, convert(int,sum(islate)) as Late, sum(case WHEN antStatus=0 THEN 1 ELSE 0 END) as 'Absent',   convert(int,sum(CASE WHEN antStatus=1 and outUpdate=0 then 1 else 0 end)) as 'Incomplete', convert(int,sum(CASE WHEN normalOT >0 then 1 else 0 end)) as NOTHrs,convert(int,sum(CASE WHEN totalOT >0 then 1 else 0 end)) as totalOTHrs,convert(int,sum(CASE WHEN doubleOT >0 then 1 else 0 end)) as doubleOT,convert(int,sum(CASE WHEN tripleOT>0 then 1 else 0 end)) as tripleOT,convert(int,sum(CASE WHEN workUnit=0 then 1 else 0 end)) as OffDay,convert(int,count(atDate)) as Cadre,convert(int,sum(CASE WHEN antStatus=1 and isLeave=1 then 1 else 0 end)) as PressentLeave,convert(int,sum(CASE WHEN antStatus=1 and workUnit=0 then 1 else 0 end)) as PressentOf,convert(int,sum(CASE WHEN antStatus=1 and nrWorkDay=0.5 then 1 else 0 end)) as HalfDay,convert(int,sum(CASE WHEN workUnit<>0 and nrWorkDay=0 and isLeave=0 then 1 else 0 end)) as Nopay, " & _
        '" convert(int,sum(CASE WHEN CONVERT(VARCHAR(5),tblVAtSummary.intime,108) =CONVERT(VARCHAR(5),tblVAtSummary.outtime,108) and tblVAtSummary.intime<>'1900-01-01 00:00:00.000' then 1 else 0 end)) as Duplicate ,convert(int,sum(CASE WHEN antStatus=1 and outUpdate=0 then 1 else 0 end)) as Night from tblVAtSummary,tblemployee where tblVAtSummary.EmpID=tblemployee.regid and tblVAtSummary.atdate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') and tblVAtSummary.shiftLine=1"
        'fk_Return_MultyString(sSQL, 17)




        Me.Cursor = Cursors.Default
    End Sub


    Public Sub Fk_FillDataSet(ByVal strSQLQuery As String)
        Dim CN As New SqlConnection(sqlConString)
        Dim sBol As Boolean = False
        Try
            sTablek.Clear()
            CN.Open()
            Dim ADP As New SqlDataAdapter
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTablek, "tblPunchTime")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Public Sub ViewEmployee()
        Me.Cursor = Cursors.WaitCursor
        strWhereClause = " tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"


        sSQL = "select RegID,RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as '" & sqlTag1.Split("."c)(1) & "' ,DispName AS 'Employee Name',NICNumber AS 'NIC Number',callName AS 'Calling Name',CONVERT(VARCHAR(11),tblEmployee.regDate,106) AS 'Joining Date',CONVERT(VARCHAR(11),tblEmployee.dOFb,106) AS 'Birth Date' FROM tblEmployee WHERE " & strWhereClause & " AND (DispName like '%" & TextBox1.Text & "%' OR " & sqlTag1 & " like '%" & TextBox1.Text & "%' OR NICNumber like '%" & TextBox1.Text & "%' OR firstName like '%" & TextBox1.Text & "%' OR surName like '%" & TextBox1.Text & "%' OR callName like '%" & TextBox1.Text & "%') ORDER BY " & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvAllEmp)
        dgvAllEmp.Columns(0).Visible = False
        For X As Integer = 0 To dgvAllEmp.Columns.Count - 1
            dgvAllEmp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Next
        lblEmpCount.Text = "Employee List : " & dgvAllEmp.RowCount
        pnlMostRLeft.Width = 357
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub InitialLoad()

        Dim dv As DataView = New DataView(sTablek.Tables("tblPunchTime"))
        'sSQL = "Empstatus<>9  " & strWhereClouse & " "
        dv.RowFilter = sSQL
        'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
        Dim dt As New DataTable
        dt = dv.ToTable(True, "RegID", "EmpNo", "DispName", "CDate", "cTime", "department", "category", "designation", "shiftName", "branch", "capture", "editMode", "deptID", "desigId", "BrID", "ShiftID", "crLine", "MacID", "enrolNo", "ttime")
        dgvData.DataSource = dt

        With dgvData
            .Columns(0).HeaderText = "Reg ID"
            '.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Emp No"
            '.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).HeaderText = "Employee Name"
            '.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(3).HeaderText = "Punch Date"
            '.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(4).HeaderText = "Punch Time"
            '.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(5).HeaderText = "Department"
            '.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(6).HeaderText = "Category"
            '.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(7).HeaderText = "Designation"
            '.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(8).HeaderText = "Shift"
            '.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(9).HeaderText = "Branch"
            '.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(10).HeaderText = "Capture"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(11).HeaderText = "Capture"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(12).HeaderText = "Capture"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(13).HeaderText = "Capture"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(14).HeaderText = "Capture"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(15).HeaderText = "Capture"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        End With

        For k As Integer = 11 To dgvData.Columns.Count - 1
            dgvData.Columns(k).Visible = False
        Next

        For l As Integer = 1 To 11
            dgvData.Columns(l).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next

    End Sub

    Public Sub PunchTimeSearch()

        Try
            Me.Cursor = Cursors.WaitCursor
            'chkNightOnly.Checked = False
            If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 31 Then
                MessageBox.Show("Maximum date range is month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If

            Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", FK_GetIDR(cmbDept.Text))
            Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", FK_GetIDR(cmbCat.Text))
            Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", FK_GetIDR(cmbDesg.Text))
            Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", FK_GetIDR(cmbShiftName.Text))
            Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))
            Dim strTypeName As String = IIf(cmbType.Text = "[ALL]", "", FK_GetIDR(cmbType.Text))

            Select Case strSearchFor
                Case "Original"
                    strWhereClouse = "AND capture=0 AND EditMode=0"
                    strDispCount = "Total"
                Case "Manual"
                    strWhereClouse = "AND capture=0 AND EditMode=1"
                    strDispCount = "Total"
                Case "All"
                    strWhereClouse = "AND capture=0 "
                    strDispCount = "Total"

            End Select

            Dim dv As DataView = New DataView(sTablek.Tables("tblPunchTime"))
            sSQL = "capture=0  " & strWhereClouse & " AND (EmpNo LIKE '%" + txtSearch.Text.Trim() + "%' OR DispName LIKE '%" + txtSearch.Text.Trim() + "%' OR EmpNo LIKE '%" + txtSearch.Text.Trim() + "%') and deptID in ('" & StrUserLvDept & "') AND  brID IN ('" & StrUserLvBranch & "') AND  (DesigID LIKE '%" + StrDesigName.Trim() + "%' AND deptID LIKE '%" + StrDeptname.Trim() + "%' AND catID LIKE '%" + StrSubCatName.Trim() + "%' AND ShiftID LIKE '%" + strShiftName.Trim() + "%'  AND brID LIKE '%" + StrBranchName.Trim() + "%'  )"
            dv.RowFilter = sSQL
            dv.Sort = " EmpNo ASC"
            'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
            Dim dt As New DataTable
            dt = dv.ToTable(True, "RegID", "EmpNo", "DispName", "CDate", "cTime", "department", "category", "designation", "shiftName", "branch", "capture", "editMode", "deptID", "desigId", "BrID", "ShiftID", "crLine", "MacID", "enrolNo", "ttime")
            dgvData.DataSource = dt
            Label1.Text = "Total rows " & dgvData.RowCount

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Public Sub PunchTimeSearchSelected()

        Try
            Me.Cursor = Cursors.WaitCursor
            'chkNightOnly.Checked = False
            If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 31 Then
                MessageBox.Show("Maximum date range is month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If

            Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", FK_GetIDR(cmbDept.Text))
            Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", FK_GetIDR(cmbCat.Text))
            Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", FK_GetIDR(cmbDesg.Text))
            Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", FK_GetIDR(cmbShiftName.Text))
            Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))
            Dim strTypeName As String = IIf(cmbType.Text = "[ALL]", "", FK_GetIDR(cmbType.Text))

            Select Case strSearchFor
                Case "Original"
                    strWhereClouse = "AND capture=0 AND EditMode=0"
                    strDispCount = "Total"
                Case "Manual"
                    strWhereClouse = "AND capture=0 AND EditMode=1"
                    strDispCount = "Total"
                Case "All"
                    strWhereClouse = "AND capture=0 "
                    strDispCount = "Total"
            End Select

            StrEmployeeID = Trim(dgvAllEmp.CurrentRow.Cells(0).Value)
            Dim dv As DataView = New DataView(sTablek.Tables("tblPunchTime"))
            sSQL = "capture=0  " & strWhereClouse & " AND RegID = '" + StrEmployeeID + "'"
            dv.RowFilter = sSQL
            dv.Sort = " EmpNo ASC"
            'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
            Dim dt As New DataTable
            dt = dv.ToTable(True, "RegID", "EmpNo", "DispName", "CDate", "cTime", "department", "category", "designation", "shiftName", "branch", "capture", "editMode", "deptID", "desigId", "BrID", "ShiftID", "crLine", "MacID", "enrolNo", "ttime")
            dgvData.DataSource = dt
            Label1.Text = "Total rows " & dgvData.RowCount

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        PunchTimeSearch()
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        PunchTimeSearch()
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        PunchTimeSearch()
    End Sub

    Private Sub cmbShiftName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShiftName.SelectedIndexChanged
        PunchTimeSearch()
    End Sub

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged
        PunchTimeSearch()
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        PunchTimeSearch()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        strSearchFor = "Original"
        ViewInformation(0)
        PunchTimeSearch()
        'InitialLoad()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If pnlMostRLeft.Width = 357 Then
            pnlMostRLeft.Width = 4
        ElseIf pnlMostRLeft.Width = 4 Then
            ViewEmployee()
        End If
    End Sub

    Public Sub getSelectedArea()
        If DateDiff(DateInterval.Day, dtpFromDate.Value.Date, dtpToDate.Value.Date) > 0 Then MessageBox.Show("You can change only one day through this screen.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpFromDate.Value = dtpToDate.Value : Exit Sub

        Dim selectedCellCount As Integer = _
        dgvData.GetCellCount(DataGridViewElementStates.Selected)
        Dim intRow As Integer : Dim intColumn As Integer : Dim strCellName As String
        Dim StrcEmpID As String = ""
        Dim strSelDate As String
        strDisplaySelected = ""
        strCollectDisplay = ""
        'Dim selectedRowCount As Integer = _
        'dgvEmployee.SelectedRows.Count
        'Dim intCurrentColumn As Integer = dgvData.se/
        Try
            intEmp = 0
            If selectedCellCount > 0 Then
                dgvTempDGV.Rows.Clear()
                dgvTempDGV.Columns.Clear()
                dgvTempDGV.Columns.Add("RegID", "Reg ID")
                dgvTempDGV.Columns.Add("EnrolNo", "Enro lNo")
                dgvTempDGV.Columns.Add("tTime", "Tot Time")
                dgvTempDGV.Columns.Add("crLine", "Line")
                dgvTempDGV.Columns.Add("MacID", "Mac ID")

                If dgvData.AreAllCellsSelected(True) Then
                    MessageBox.Show("All cells are selected", "Selected Cells")
                Else
                    strCellName = ""
                    Dim i As Integer
                    For i = 0 To selectedCellCount - 1
                        Try
                            intRow = (dgvData.SelectedCells(i).RowIndex _
                                                       .ToString())
                            intColumn = (dgvData.SelectedCells(i).ColumnIndex _
                                .ToString())
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try

                        'dgvData.Item(intColumn, intRow).Selected = False

                        If intColumn = 1 Then
                            strSelDate = Trim(dgvData.Item(0, intRow).Value)
                            strCollectDisplay = Trim(dgvData.Item(1, intRow).Value)
                            'strSelDate = Format(dtDate, "yyyyMMdd")
                            strCellName = strCellName & "'" & strSelDate & "'" & ","
                            strDisplaySelected = strDisplaySelected & "'" & strCollectDisplay & "'" & ","
                            'dgvData.Item(1, intRow).Selected = True
                            intEmp = intEmp + 1
                            dgvTempDGV.Rows.Add(Trim(dgvData.Item(0, intRow).Value), Val(dgvData.Item(18, intRow).Value), CDate(dgvData.Item(19, intRow).Value), Trim(dgvData.Item(16, intRow).Value), Trim(dgvData.Item(17, intRow).Value))
                        End If

                    Next i

                    If strCellName = "" Then Exit Sub
                    lblSelectedEmpoyees.Text = "Selected Employee(s ) : " & intEmp & "     " & Replace(strDisplaySelected, "'", "")
                    strCellName = Microsoft.VisualBasic.Left(strCellName, strCellName.Length - 1)
                    strKEmployeeID = strCellName

                    If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 1 Then
                        MessageBox.Show("You can edit only one day attendance at one time through this screen, Please select one only one day", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpToDate.Value = dtpFromDate.Value : ViewInformation(0) : PunchTimeSearch() : Exit Sub
                    End If

                    If intSelecTab = 0 Then

                        'ShiftSave()

                    End If
                End If

                'fk_SaveSelectedShift(StrcEmpID, strCellName, StrSelShiftID, intTabSelected)

                If intSelecTab = 0 Then

                    Dim k As Integer
                    For k = 0 To selectedCellCount - 1

                        intRow = (dgvData.SelectedCells(k).RowIndex _
                            .ToString())
                        intColumn = (dgvData.SelectedCells(k).ColumnIndex _
                            .ToString())
                        If 1 = intColumn Then
                            'dgvData.Rows.Remove(dgvData.Rows(intRow))
                            'dgvData.Item(1, intRow).Value = True
                        End If
                    Next k

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RemovePunchedTime()
        If UP("Daily attendance", "Remove employee punch time(s)") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        getSelectedArea()

        If strKEmployeeID = "" Then MessageBox.Show("Please select punch time record(s) to remove", "Attention", MessageBoxButtons.OK) : Exit Sub

        'sSQL = "select regID from tblemployee where regid in(" & strKEmployeeID & ")"
        'Fk_FillGrid(sSQL, dgvTempDGV)

        sSQL = ""

        'Try
        '    Dim i As Integer = 0
        '    Dim Mylist As New List(Of Integer)
        '    For Each row As DataGridViewRow In dgvData.SelectedRows
        '        Mylist.Add(row.Index)
        '    Next

        '    Mylist.Sort()

        '    'Dim value As String = String.Join(",", Mylist)

        '    For Each index As Integer In Mylist
        '        dgvTempDGV.Rows(i).Cells("Omschrijving").Value = dgvData.Rows(index).Cells("Activity").Value
        '        i = i + 1
        '    Next
        'Catch ex As Exception

        'End Try

        For I As Integer = 0 To dgvTempDGV.RowCount - 1
            Dim dtTTime As DateTime : Dim intCrRow As Integer
            StrEmployeeID = Trim(dgvTempDGV.Item(0, I).Value)
            dtTTime = dgvTempDGV.Item(2, I).Value
            intCrRow = Val(dgvTempDGV.Item(3, I).Value)
            Dim intEnrol As Integer = Val(dgvTempDGV.Item(1, I).Value)
            Dim strMacID As String = Trim(dgvTempDGV.Item(4, I).Value)
            sSQL = sSQL & " UPDATE tblDiMachine SET Capture = 9 WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "' AND crLine = " & intCrRow & " AND MacID='" & strMacID & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Delete attendance time from table Enrol No : " & intEnrol & " AND tTime : " & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & " AND crLine : " & intCrRow & " and Note " & FK_Rep(txtNote.Text) & "','" & StrUserID & "',getdate (),'" & StrEmployeeID & "'); " & _
                   "UPDATE tblDiMachineManual SET Capture = 9 WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "'  AND MacID='" & strMacID & "'" & _
                   "INSERT INTO tbldimachineRemove SELECT [MacID],[EmpID],[Input],[cDate],[cTime],[capture],[tTime],'" & StrUserID & "',getdate (),'" & txtNote.Text & "'," & intCrRow & " FROM [tbldimachine] WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "'  AND MacID='" & strMacID & "'"
        Next



        If FK_EQ(sSQL, "S", "", False, False, True) = True Then
            bolOK = True
        Else
            bolOK = False
        End If

        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        strKEmployeeID = strKEmployeeID.Remove(0, 1)
        strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)
        pgb.Visible = True
        If bolOK = True Then
            If intBaseOnClockRecord = 0 Then
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & strKEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtpToDate.Value, dtFingerPrintMaxDate, pgb, 0, 0)
            Else
                Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, strKEmployeeID, "O", pgb)
            End If
        End If

        pgb.Visible = False

        'chkNightOnly.Checked = False
        If chkAutoRefresh.Checked = True Then
            ViewInformation(0)
            PunchTimeSearch()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        RemovePunchedTime()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length = 0 Or TextBox1.Text.Length Mod 2 = 1 Then
            ViewEmployee()
        End If
    End Sub

    Private Sub dgvAllEmp_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvAllEmp.MouseClick
        PunchTimeSearchSelected()
    End Sub

    'Private Sub chkManual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkManual.Click
    '    If chkManual.Checked = True Then
    '        strSearchFor = "Manual"
    '    Else
    '        strSearchFor = "Original"
    '    End If
    'End Sub

    Private Sub dgvData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvData.MouseClick
        If e.Button = MouseButtons.Right Then
            Button5_Click(sender, e)
        End If
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, -1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, -1, dtpToDate.Value)
        ViewInformation(0)
        PunchTimeSearch()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, 1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        ViewInformation(0)
        PunchTimeSearch()
    End Sub

    Private Sub rdbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAll.MouseClick
        If rdbAll.Checked = True Then
            strSearchFor = "All"
        End If
        ViewInformation(0)
        PunchTimeSearch()
    End Sub

    Private Sub rdbManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbManual.MouseClick
        If rdbManual.Checked = True Then
            strSearchFor = "Manual"
        End If
        ViewInformation(0)
        PunchTimeSearch()
    End Sub

    Private Sub rdbOriginal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbOriginal.MouseClick
        If rdbOriginal.Checked = True Then
            strSearchFor = "Original"
        End If
        ViewInformation(0)
        PunchTimeSearch()
    End Sub

End Class