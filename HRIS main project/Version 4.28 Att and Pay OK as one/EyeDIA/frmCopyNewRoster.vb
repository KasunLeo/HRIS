Imports System.Data.SqlClient

Public Class frmCopyNewRoster

    Private Sub cmdBrsEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsEmp.Click

        StrEmployeeID = ""

        LoadForm(New frmEmployeeSearch)

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim intISEpf As Integer = fk_sqlDbl("SELECT isEpf FROM tblCompany")
        Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno,tblemployee.EnrolNo,tblEmployee.EmpNo " & _
        " FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"

        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                If intISEpf = 0 Then
                    txtEmpID.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                ElseIf intISEpf = 1 Then
                    txtEmpID.Text = IIf(IsDBNull(drShw.Item("epfno")), "", drShw.Item("epfno"))
                ElseIf intISEpf = 2 Then
                    txtEmpID.Text = IIf(IsDBNull(drShw.Item("EnrolNo")), "", drShw.Item("EnrolNo"))
                Else
                    txtEmpID.Text = IIf(IsDBNull(drShw.Item("EmpNo")), "", drShw.Item("EmpNo"))
                End If
                txtEmpName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                StrEmployeeID = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub frmCopyNewRoster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
        If strKEmployeeID <> "" Then
            Dim cnShw As New SqlConnection(sqlConString)
            cnShw.Open()
            Dim intISEpf As Integer = fk_sqlDbl("SELECT isEpf FROM tblCompany")
            Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno,tblemployee.EnrolNo,tblEmployee.EmpNo " & _
            " FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & strKEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"

            Try
                Dim cmShw As New SqlCommand(sqlQRY, cnShw)
                Dim drShw As SqlDataReader = cmShw.ExecuteReader
                If drShw.Read = True Then
                    If intISEpf = 0 Then
                        txtEmpID.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                    ElseIf intISEpf = 1 Then
                        txtEmpID.Text = IIf(IsDBNull(drShw.Item("epfno")), "", drShw.Item("epfno"))
                    ElseIf intISEpf = 2 Then
                        txtEmpID.Text = IIf(IsDBNull(drShw.Item("EnrolNo")), "", drShw.Item("EnrolNo"))
                    Else
                        txtEmpID.Text = IIf(IsDBNull(drShw.Item("EmpNo")), "", drShw.Item("EmpNo"))
                    End If
                    txtEmpName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                    StrEmployeeID = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                    dtpFrDate.Value = dtKfrDate
                    dtpToDate.Value = dtKtoDate
                    strKEmployeeID = ""
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnShw.Close()
            End Try
        End If
    End Sub

    Public Sub _CopyRosters(ByVal StrSurceEmployee As String, ByVal StrDestEmployees As String, ByVal dtStart As Date, ByVal dtEnd As Date)
        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If
        If StrDestEmployees = "" Then MessageBox.Show("Please select employe(s) to be copy the sample employees roster", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        'Get Select Source Employee Attendance for the period
        Dim sqlQRY As String = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, ShiftID Nvarchar (3))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,AllShifts FROM tblEmpRegister WHERE EmpID = '" & StrSurceEmployee & "' AND AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'"
        'Get Detail From Source to Destination Employees 
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.AllShifts = #T.ShiftID FROM #T,tblEmpRegister WHERE #T.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.EmpID In ('" & StrDestEmployees & "')"

        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Public Sub CopyDayType(ByVal StrSurceEmployee As String, ByVal StrDestEmployees As String, ByVal dtStart As Date, ByVal dtEnd As Date)
        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If
        If StrDestEmployees = "" Then MessageBox.Show("Please select employe(s) to be copy the sample employees roster", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        'Get Select Source Employee Attendance for the period
        Dim sqlQRY As String = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, DayTypeID Nvarchar (3))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,DayTypeID FROM tblEmpRegister WHERE EmpID = '" & StrSurceEmployee & "' AND AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'"
        'Get Detail From Source to Destination Employees 
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DayTypeID = #T.DayTypeID FROM #T,tblEmpRegister WHERE #T.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.EmpID In ('" & StrDestEmployees & "')"

        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Public Sub _CopyRosterAndShift(ByVal StrSurceEmployee As String, ByVal StrDestEmployees As String, ByVal dtStart As Date, ByVal dtEnd As Date)
        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If
        If StrDestEmployees = "" Then MessageBox.Show("Please select employe(s) to be copy the sample employees roster", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        'Get Select Source Employee Attendance for the period
        Dim sqlQRY As String = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, ShiftID Nvarchar (3))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,AllShifts FROM tblEmpRegister WHERE EmpID = '" & StrSurceEmployee & "' AND AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'"
        'Get Detail From Source to Destination Employees 
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.AllShifts = #T.ShiftID FROM #T,tblEmpRegister WHERE #T.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.EmpID In ('" & StrDestEmployees & "'); INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Change Employee shifts of  " & Replace(StrDestEmployees, "'", "") & " and get source employee as  " & StrSurceEmployee & " of date rage Between " & Format(dtStart, "yyyyMMdd") & " AND " & Format(dtEnd, "yyyyMMdd") & " and ShiftID ' ,'" & StrUserID & "',getdate ())"

        FK_EQ(sqlQRY, "S", "", False, False, True)

        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, DayTypeID Nvarchar (3))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,DayTypeID FROM tblEmpRegister WHERE EmpID = '" & StrSurceEmployee & "' AND AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'"
        'Get Detail From Source to Destination Employees 
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DayTypeID = #T.DayTypeID FROM #T,tblEmpRegister WHERE #T.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.EmpID In ('" & StrDestEmployees & "'); INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Change Employee Day Type of  " & Replace(StrDestEmployees, "'", "") & " and get source employee as  " & StrSurceEmployee & " of date rage Between " & Format(dtStart, "yyyyMMdd") & " AND " & Format(dtEnd, "yyyyMMdd") & "' ,'" & StrUserID & "',getdate ())"

        FK_EQ(sqlQRY, "S", "", False, True, True)

    End Sub

    Public Sub _Search()
        If txtSearch.Text = "[ALL]" Then txtSearch.Text = ""
        Dim StrDesgName As String = IIf(cmbDesig.Text = "[ALL]", "", cmbDesig.Text)
        Dim StrDeptName As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.enrolNo" Else sqlTag = "tblEmployee.EmpNo"

        Dim sqlVIEW As String = ""
        sqlVIEW = "SELECT tblEmployee.RegID," & sqlTag & ", tblEmployee.DispName, 'False' FROM tblEmployee,tblDesig,tblSetDept,tblSetEmpCategory WHERE (tblEmployee.DeptID = tblSetDept.DeptID AND tblEmployee.DesigID = tblDesig.DesgID AND tblEmployee.CatID = tblSetEmpCategory.CatID) AND tblEmployee.EMpStatus <>9  AND tblEmployee.DeptID In ('" & StrUserLvDept & "') AND " & _
        " (tblDesig.DesgDesc LIKE '" & StrDesgName & "%' AND tblSetDept.DeptName LIKE '" & StrDeptName & "%' AND tblSetEmpCategory.CatDesc LIKE '" & StrCatName & "%') AND (tblEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR " & sqlTag & " LIKE '%" & txtSearch.Text & "%') ORDER By " & sqlTag & ""
        Load_InformationtoGrid(sqlVIEW, dgvDepartment, 4) : clr_Grid(dgvDepartment)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        ListComboAll(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "deptName")
        ListComboAll(cmbCat, "SELECT * FROM tblSetEmpCategory WHERE status = 0 Order By CatID", "CatDesc")
        ListComboAll(cmbDesig, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "DesgDesc")
        _Search()
        chkAlk.CheckState = CheckState.Checked

        txtEmpID.Clear() : txtEmpName.Clear() : txtSearch.Clear()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If
        If txtEmpID.Text = "" Then MessageBox.Show("Please select a sample employee", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cmdBrsEmp_Click(sender, e)

        If MsgBox("Do you want to process Copy Shift Option for the selected Date Range ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim StrEmps As String
        StrEmps = fk_getGridCLICK(dgvDepartment, 3, 0)
        StrEmps = fk_SplitToSQL_in(StrEmps)

        If intSelecTab = 1 Then
            CopyDayType(StrEmployeeID, StrEmps, dtpFrDate.Value, dtpToDate.Value)
        ElseIf intSelecTab = 2 Then
            _CopyRosters(StrEmployeeID, StrEmps, dtpFrDate.Value, dtpToDate.Value)
        ElseIf intSelecTab = 3 Then
            _CopyRosterAndShift(StrEmployeeID, StrEmps, dtpFrDate.Value, dtpToDate.Value)
        End If

        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        _Search()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        _Search()
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        _Search()
    End Sub

    Private Sub cmbDesig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesig.SelectedIndexChanged
        _Search()
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        _Search()
    End Sub

    Private Sub chkAlk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlk.CheckedChanged
        For i As Integer = 0 To dgvDepartment.RowCount - 1
            dgvDepartment.Item(3, i).Value = chkAlk.CheckState
        Next
    End Sub

End Class