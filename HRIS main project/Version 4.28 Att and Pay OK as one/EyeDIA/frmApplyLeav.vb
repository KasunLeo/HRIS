Imports System.Data.SqlClient

Public Class frmApplyLeavdatra
    Dim StrAplLeaveID As String
    Dim StrLvID As String
    Dim dblTotLv As Double
    Dim dblTknLv As Double
    Dim StrSvStatus As String = "S"
    Dim StrCompID As String = "001"
    Dim crMonth As Integer = 0
    Dim crYear As Integer
    Dim lvMinDate As Date
    Dim intChkLimit As Integer = 0
    Dim intYrCount As Integer = 0
    Dim intEffDay As Integer = 0
    Dim intAllowOthLv As Integer = 0
    Dim dtPrStartDate As Date
    Dim dtPrEndDate As Date
    Dim intAprvLv As Integer = 0 : Dim intLAntStatus As Integer = 0
    Dim strTogle As String = "A"
    Dim StrStatus As String
    Dim intSelectedYear As Integer = 0
    Dim intExsixted As Integer = 0
    Dim intSelectedMonth As Integer = 0
    Dim dblBalShLvQty As Double
    Dim dblBalShLvMin As Double
    Dim intTotShLvMinPerMonth As Integer
    Dim intMaxNoShLvPerMnth As Integer
    Dim intMinMnPerShLv As Integer
    Dim intThisMnthLvMin As Integer
    Dim intThisMonthBalMin As Integer
    Dim intThisMonthBalQty As Integer
    Dim intThisMonthLvMinTotal As Integer
    Dim intThisMonthLvQtyTotal As Integer
    Dim IsChkShLvBalMin As Integer
    Dim strExLeStatus As String = ""

    Dim dblLateMins As Double
    Dim dblOTRound As Double
    Dim dblMinOT As Double
    Dim intOTRndOption As Double
    Dim intMonthStart As Integer
    Dim LeaveShowdays As Integer

    Dim MaxmunMonthEndDate As DateTime

    Public Sub CompanyParameter()
        sSQL = "SELECT Latemin,OTRound,MinHrsOT,OTRndOption,monthStart FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        fk_Return_MultyString(sSQL, 5)
        dblLateMins = fk_ReadGRID(0)
        dblOTRound = fk_ReadGRID(1)
        dblMinOT = fk_ReadGRID(2)
        intOTRndOption = fk_ReadGRID(3)
        intMonthStart = fk_ReadGRID(4)
    End Sub

    Private Sub frmApplyLeav_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Leave", "View leave apply screen") = False Then Exit Sub
        intExsixted = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE compID='001'")
        cmbCurrentYear.Text = intExsixted
        intSelectedYear = cmbCurrentYear.Text

        CenterFormThemed(Me, pnllTop, Label16)
        ControlHandlers(Me)
        If strKEmployeeID <> "" Then
            If dtGlobalDate = "12:00:00 AM" Then
                dtGlobalDate = dtLastProcessed
            End If
            dtpAplLvDate.Value = dtGlobalDate
            dtpFrDate.Value = dtGlobalDate

            'View Employee information using the EMployee
            Dim cnShw As New SqlConnection(sqlConString)
            cnShw.Open()
            Dim sqlQRY As String = "select tblEmployee.RegID," & sqlTag1 & " as 'RelID',tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno " & _
            " FROM tblEmployee LEFT OUTER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & strKEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
            Try
                Dim cmShw As New SqlCommand(sqlQRY, cnShw)
                Dim drShw As SqlDataReader = cmShw.ExecuteReader
                If drShw.Read = True Then
                    txtCode.Text = IIf(IsDBNull(drShw.Item("epfno")), "", drShw.Item("epfno"))
                    txtempName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                    txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))
                    txtRelID.Text = IIf(IsDBNull(drShw.Item("RelID")), "", drShw.Item("RelID"))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnShw.Close()
            End Try

            'Load_InformationtoGrid("select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID", dgvLvHistory, 5)
            'clr_Grid(dgvLvHistory)
            '****** Modified On 29/Aug/2014 ****
            'Get Monthly Leave Balance for the selected month
            ''FK_EQ("EXEC sp_SetLeaveBalance " & dtpFrDate.Value.Year & "," & dtpFrDate.Value.Month & ",'" & StrEmployeeID & "'", "S", "", False, False, True)



            '***** 
            sSQL = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & strKEmployeeID & "' AND tblEmpLeaveD.cYear = " & intSelectedYear & " Order By tblEmpLeaveD.LeaveID"
            ''sSQL = "SELECT LeaveID,lvName,EntLeave,TknLeave,BalLeave FROM tblTmpLeave Order By LeaveID"
            Load_InformationtoGrid(sSQL, dgvLvHistory, 5)
            clr_Grid(dgvLvHistory)

            Dim sqlLv As String = "select tblLeaveTRD.Lvdate,tblLeaveTRD.LvType,tblLeaveType.LvDesc,tblLeaveTRD.NoLeave,tblLeaveTRH.AuthLeave FROM tblLeaveTRD " & _
                " INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqiD AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID" & _
                " INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.lvID WHERE tblLeaveTRH.EmpID = '" & strKEmployeeID & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.cYear = " & intSelectedYear & " Order By tblLeaveTRD.LvDate"
            Load_InformationtoGrid(sqlLv, dgvLvK, 5)
            ' clr_Grid(dgvLvK)
            With dgvLvK
                Dim intPP As Integer = 0

                For Each row As DataGridViewRow In .Rows
                    intPP = .Item(4, row.Index).Value

                    If intPP = 0 Then row.DefaultCellStyle.BackColor = lblPost.BackColor Else row.DefaultCellStyle.BackColor = lblPre.BackColor
                Next
            End With

            StrStatus = "Cader"

            ComboBox1.Focus()
        Else
            cmdRefresh_Click(sender, e)
        End If

        btnCadre_Click(sender, e)

        For i As Integer = 1 To 12
            cmbMonth.Items.Add(i)
        Next

        cmbMonth.Text = dtpFrDate.Value.Month
        intSelectedMonth = cmbMonth.Text
        StrShortSumLvID = fk_RetString("select ShortLvID FROM tblControl")
        sSQL = "SELECT totShLvMinPerMonth,maxNoShLvPerMnth,minMnPerShLv,IsChkShLvBalMin FROM tblControl"
        fk_Return_MultyString(sSQL, 4)
        intTotShLvMinPerMonth = fk_ReadGRID(0) : intMaxNoShLvPerMnth = fk_ReadGRID(1) : intMinMnPerShLv = fk_ReadGRID(2) : IsChkShLvBalMin = fk_ReadGRID(3)
        btnHalf.Visible = True
        CompanyParameter()

        DateTimePickerMinDateControl()
    End Sub


    Private Sub DateTimePickerMinDateControl()
        '2018-08-03 DateTimePicker MinDate Control -prasanna
        Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")
        Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")

        MaxmunMonthEndDate = New DateTime(maxYear, maxMonth, 1).AddDays(-1)
        'dtpFD.MinDate = New DateTime(maxYear, maxMonth, 1).AddMonths(1)
        'dtpToD.MinDate = New DateTime(maxYear, maxMonth, 1).AddMonths(1)
    End Sub


    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.pnlMain.BackColor
    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.pnlMain.BackColor
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)
        dgvLvHistory.Rows.Clear()
        dgvLvK.Rows.Clear()
        rdbDay.Checked = True

        'Get the Current Month
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlOpn As String = "SELECT * FROM tblCompany WHERE compID = '" & StrCompID & "'"
        Try
            Dim cmOPn As New SqlCommand(sqlOpn, cnOpn)
            Dim dropn As SqlDataReader = cmOPn.ExecuteReader
            If dropn.Read = True Then
                crMonth = IIf(IsDBNull(dropn.Item("cMonth")), 0, dropn.Item("cMonth"))
                crYear = IIf(IsDBNull(dropn.Item("cYear")), 0, dropn.Item("cYear"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try
        'Get the 
        Try
            lvMinDate = DateSerial(intSelectedYear, crMonth, 1) 'IIf(IsDBNull(drProf.Item("stDate")), DateSerial(1900, 1, 1), drProf.Item("stDate"))
            dtPrStartDate = DateSerial(crYear, crMonth, 1)
            dtPrEndDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(intSelectedYear, crMonth, 1)))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim iR As Integer = fk_sqlDbl("SELECT NoAplLv FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        Dim StrAplLeaveID = fk_CreateSerial(5, iR)
        lblRQID.Text = StrAplLeaveID
        'Load Leave TYpes 
        ListCombo(ComboBox1, "select * From tblLeaveType Order By LvID", "lvDesc")


        dtpAplLvDate.MaxDate = DateSerial(Val(intSelectedYear) + 1, 1, 1)
        dtpAplLvDate.MinDate = DateSerial(Val(intSelectedYear) - 1, 12, 31)
        dtpFrDate.MaxDate = DateSerial(Val(intSelectedYear) + 1, 1, 1)
        dtpFrDate.MinDate = DateSerial(Val(intSelectedYear) - 1, 12, 31)


        StrSvStatus = "S"
        txtCode.Focus()
        txtFrDtype.Text = dtpFrDate.Value.DayOfWeek.ToString
        txttoDType.Text = dtpToDate.Value.DayOfWeek.ToString
        dgvSpLv.Rows.Clear()
        dgvEmp.Rows.Clear()

        dgvLeaveTake.Rows.Clear()

        dtpToD.Value = dtLastProcessed
        txtRemark.Text = "-"
        chkApprovLv.Checked = True

        lblShLvBalMin.Visible = False
        lblShLvBalQty.Visible = False

        pnlWarrning.Height = 0
    End Sub

    Public Sub leave_checks(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()

        Dim sqlQ As String = "select tblEmpLeaveD.EmpID,tblEmpLeaveD.CompID,tblEmpLeaveD.cYear,tblEmpLeaveD.LeaveID, " & _
       " tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave,tblEmpLeaveD.Status,tblLeaveType.EffDay,tblLeaveType.lvmode,tblLeaveType.AllowOthLv,tblLeaveType.ChkLimit,tblLvAplMeth.mCount From tblEmpLeaveD " & _
       " INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID  INNER JOIN tblLvAplMeth ON tblLeaveType.LvMode = tblLvAplMeth.mID WHERE tblLeaveType.LvDesc = '" & ComboBox1.Text & "' AND " & _
       " tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.CompID = '" & StrCompID & "' AND cYear = " & intSelectedYear & ""
        dblTotLv = 0
        dblTknLv = 0
        txtLvBalance.Text = "0"

        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                dblTotLv = IIf(IsDBNull(drShw.Item("NoLeaves")), 0, drShw.Item("NoLeaves"))
                dblTknLv = IIf(IsDBNull(drShw.Item("TakenLeave")), 0, drShw.Item("TakenLeave"))
                txtLvBalance.Text = dblTotLv - dblTknLv
                txtLvsBalance.Text = dblTotLv - dblTknLv
                StrLvID = IIf(IsDBNull(drShw.Item("LeaveID")), "", drShw.Item("LeaveID"))
                intChkLimit = IIf(IsDBNull(drShw.Item("ChkLimit")), 0, drShw.Item("ChkLimit"))
                intYrCount = IIf(IsDBNull(drShw.Item("mCount")), 0, drShw.Item("mCount"))
                intEffDay = IIf(IsDBNull(drShw.Item("EffDay")), 0, drShw.Item("EffDay"))
                intAllowOthLv = IIf(IsDBNull(drShw.Item("AllowOthLv")), 0, drShw.Item("AllowOthLv"))
                'if Year count not = 1 then sould cal seperately
                If intYrCount = 12 Then
                    dblTknLv = fk_sqlDbl("SELECT Sum(NoLeave) FROM tblLeaveTRD WHERE LvType = '" & StrLvID & "' AND LvDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND EmpID = '" & StrEmployeeID & "'")
                    dblTotLv = dblTotLv / intYrCount
                    txtLvBalance.Text = dblTotLv - dblTknLv
                    txtLvsBalance.Text = txtLvBalance.Text
                End If
            End If

            'If intChkLimit = 1 Then chkApprovLv.Visible = False : chkApprovLv.CheckState = CheckState.Unchecked Else chkApprovLv.Visible = True : chkApprovLv.CheckState = CheckState.Unchecked
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        leave_checks(dtPrStartDate, dtPrEndDate)

    End Sub

    Private Sub TextBox4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAplLv.Leave, txtLvsBalance.Leave
        'If txtAplLv.Text = "" Then txtAplLv.Text = "0"
        'If txtLvBalance.Text = "" Then txtLvBalance.Text = "0"
        'If CDbl(txtLvBalance.Text) < CDbl(txtAplLv.Text) Then
        '    MsgBox("Sorry you don't have this much of leave", MsgBoxStyle.Information)
        '    txtAplLv.Text = "0"
        '    txtAplLv.SelectAll()
        '    txtAplLv.Focus()
        '    Exit Sub
        'End If
    End Sub

    Public Function calc_Leave(ByVal stDate As Date, ByVal edDate As Date) As Double
        Dim dtVal As Double
        dtVal = DateDiff(DateInterval.Day, stDate, edDate) + 1
        Return dtVal
    End Function

    Private Sub dtpFrDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFrDate.Leave, dtpFrtime.Leave, dtpToTime.Leave
        'Get the Day type and show the Value


        'dtpToDate.MinDate = dtpFrDate.Value
        ''txtAplLv.Text = calc_Leave(dtpFrDate.Value, dtpToDate.Value)
        'txtAplLv.Text = fk_sqlDbl("SELECT Sum(WorkingType) FROM tblCalendar WHERE [Date] Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "'")
    End Sub



    Private Sub dtpFrDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrDate.ValueChanged, dtpFrtime.ValueChanged, dtpToTime.ValueChanged
        ''Get the Selected Day Shift In time for the selected Employee
        'dtpFrtime.Text = fk_RetDate("SELECT tblSetShiftH.InTime FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE tblEmpRegister.AtDate = '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "'")
        'dtpToDate.MinDate = dtpFrDate.Value
        'txtAplLv.Text = fk_sqlDbl("SELECT Sum(tblDayType.WorkUnit) FROM tblDayType INNER JOIN tblEmpRegister ON tblEmpRegister.DayTypeID = tblDayType.TypeID " & _
        '" WHERE tblEmpRegister.AtDate between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID = '" & txtCode.Text & "'")
        txtFrDtype.Text = dtpFrDate.Value.DayOfWeek.ToString
        cmbMonth.Text = dtpFrDate.Value.Month
        'Get the Attendance status of the selected date

    End Sub

    'Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged, dtpToDate.Leave
    '    'txtAplLv.Text = calc_Leave(dtpFrDate.Value, dtpToDate.Value)
    '    'Set the Shift Out Time as the Selected Date Shift OutDate
    '    dtpToTime.Text = fk_RetDate("SELECT tblSetShiftH.OutTime FROM tblSetShiftH Inner Join tblEmpRegister ON  tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE  tblEmpRegister.AtDate = '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "'")

    '    txtAplLv.Text = fk_sqlDbl("SELECT Sum(tblDayType.WorkUnit) FROM tblDayType INNER JOIN tblEmpRegister ON tblEmpRegister.DayTypeID = tblDayType.TypeID " & _
    '    " WHERE tblEmpRegister.AtDate between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID = '" & txtCode.Text & "'")

    '    txttoDType.Text = dtpToDate.Value.DayOfWeek.ToString


    '    'Fil_Leave()


    'End Sub

    Public Sub Fil_Leave()
        Dim sqlQ As String
        Dim dblTotLeave As Double
        'CASE tblEmpRegister.IsLeave WHEN 1 THEN tblDayType.WorkUnit -(tblEmpRegister.NoLeave+tblEmpRegister.NRWorkDay) ELSE tblEmpRegister.NoLeave END
        sqlQ = "SELECT tblEmpRegister.AtDate,tblSetShiftH.ShiftName,tblDayType.WorkUnit - (tblEmpRegister.NRWorkDay+tblEmpRegister.NoLeave),tblDayType.WorkUnit - (tblEmpRegister.NRWorkDay+tblEmpRegister.NoLeave),tblEmpRegister.IsLeave,tblEmpRegister.AntStatus,tblEmpRegister.NoLeave,tblEmpRegister.IsLate,tblEmpRegister.IsEarly FROM tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' Order By tblEmpRegister.AtDate"
        'sqlQ = "SELECT tblEmpRegister.AtDate,tblSetShiftH.ShiftName,CASE WHEN tblDayType.WorkUnit-tblEmpRegister.NoLeave < 0 THEN 0 Else tblDayType.WorkUnit-tblEmpRegister.NoLeave END,CASE WHEN tblDayType.WorkUnit-tblEmpRegister.NoLeave < 0 THEN 0 ELSE tblDayType.WorkUnit-tblEmpRegister.NoLeave END,tblEmpRegister.IsLeave,tblEmpRegister.AntStatus,tblEmpRegister.LeaveID,tblEmpRegister.IsLate,tblEmpRegister.IsEarly FROM tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' Order By tblEmpRegister.AtDate"
        Load_InformationtoGrid(sqlQ, dgvSpLv, 9)
        'Color the Taken leaves
        Dim isLeave As Integer = 0
        Dim intAtStatus As Integer = 0

        With dgvSpLv
            For iRow As Integer = 0 To .RowCount - 1
                isLeave = .Item(4, iRow).Value
                intAtStatus = .Item(5, iRow).Value
                dblTotLeave = dblTotLeave + (CDbl(.Item(2, iRow).Value) - CDbl(.Item(3, iRow).Value))
                For iCol As Integer = 0 To .ColumnCount - 1
                    If isLeave = 0 And intAtStatus = 1 Then
                        .Item(iCol, iRow).Style.BackColor = Color.White
                    ElseIf isLeave = 0 And intAtStatus = 0 Then
                        .Item(iCol, iRow).Style.BackColor = Color.LightBlue
                    ElseIf isLeave = 1 Then
                        .Item(iCol, iRow).Style.BackColor = Color.Yellow
                    End If
                Next
            Next
        End With
        txtAplLv.Text = dblTotLeave.ToString
    End Sub



    'Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    '    'Check Entered Leave 
    '    'Leave Start Date Will receiv from 
    '    Dim dtStartD As Date : Dim dtEndD As Date
    '    fk_Return_MultyString("SELECT cYear,cMonth,StDate,EdDate FROM tblPrfDays WHERE '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' Between stDate AND EdDate", 4)
    '    dtStartD = fk_ReadGRID(2) : dtEndD = fk_ReadGRID(3)
    '    leave_checks(dtStartD, dtEndD)


    '    fk_Return_MultyString("select LvID,LvDesc,EffDay,lvMode,ChkLimit,AllowOthLv FROM tblLeaveType WHERE LvID = '" & StrLvID & "'", 6) 'Load Leave configuration to the system

    '    Dim inLvCount As Integer
    '    inLvCount = fk_ReadGRID(2)
    '    intAllowOthLv = fk_ReadGRID(5)
    '    Dim dblLvVal As Double = 0
    '    Dim intLate As Integer = 0 : Dim intEarly As Integer = 0
    '    Dim BolAplLeave As Boolean = False
    '    Dim StrLE As String
    '    Dim isLeave As Integer = 0
    '    With dgvSpLv
    '        For iRow As Integer = 0 To .RowCount - 1
    '            isLeave = .Item(4, iRow).Value
    '            intAllowOthLv = fk_sqlDbl("SELECT AllowOthLv FROM tblLeaveType WHERE LvID = '" & StrLvID & "'") : If .Item(6, iRow).Value = "" Then intAllowOthLv = 1
    '            If isLeave = 1 And (CDbl(.Item(3, iRow).Value) - CDbl(.Item(6, iRow).Value)) < 0 Then BolAplLeave = True : iRow = .RowCount - 1
    '            dblLvVal = CDbl(.Item(2, iRow).Value)
    '            If dblLvVal < 0 Then MsgBox("Invalied Leave Qty ", MsgBoxStyle.Information) : iRow = .RowCount - 1 : Exit Sub
    '            If isLeave = 1 And intAllowOthLv = 0 Then BolAplLeave = True : iRow = .RowCount - 1
    '            intLate = CInt(.Item(7, iRow).Value) : intEarly = CInt(.Item(8, iRow).Value)
    '        Next
    '    End With

    '    If BolAplLeave = True Then
    '        MsgBox("Found Applied Leave Information on selected date range, Please check & Enter again", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If
    '    Dim bolAtn As Boolean = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE antStatus = 1  AND atDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' AND EmpID = '" & StrEmployeeID & "'")
    '    If bolAtn = True Then
    '        Dim bolLate As Boolean = False
    '        bolLate = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE isLate = 1 AND atDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' AND EmpID = '" & StrEmployeeID & "'")
    '        If bolLate = True Then bolAtn = False Else bolAtn = True

    '        If bolLate = False Then
    '            Dim bolEarly As Boolean = False
    '            bolEarly = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE isEarly = 1 AND atDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "' AND EmpID = '" & StrEmployeeID & "'")
    '            If bolEarly = True Then bolAtn = False Else bolAtn = True
    '        End If
    '    End If

    '    If bolAtn = True Then
    '        MsgBox("Found Precent date for the selected date range, please check & Retry", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If
    '    'Check Non Working Date Selection


    '    Dim dgvLv As DataGridView
    '    dgvLv = New DataGridView
    '    With dgvLv
    '        .Columns.Add("LeavID", "Leave ID")  '-0
    '        .Columns.Add("Date", "Leave Date")  '-1
    '        .Columns.Add("DayType", "Day Type") '-2
    '        .Columns.Add("EffLv", "No Leave")   '-3
    '    End With
    '    Dim sqlQ As String = "select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.DayTypeID, " & _
    '    " tblDayType.WorkUnit from tblEmpRegister INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID" & _
    '    " WHERE tblEmpRegister.empID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value, strRetDateTimeFormat) & "'"
    '    Dim bolFollow As Boolean = True
    '    ' bolFollow = fk_CheckEx ("SELECT * FROM tblEmpRegister WHERE AtDate Between '" & format(dtpFrDate.Value ,strRetDateTimeFormat) & "' AND '" & Format(dtpToDate.Value ,strRetDateTimeFormat) & "' AND AntStatus = 1
    '    Load_InformationtoGrid(sqlQ, dgvLv, 4)

    '    Dim iWorkHr As Double
    '    '= fk_sqlDbl("SELECT WorkingType FROM tblCalendar WHERE [Date] = '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "'")
    '    '        If iWorkHr = 0 Then
    '    '            MsgBox("Can't Select Non working date for the From Date", MsgBoxStyle.Critical)
    '    '            Exit Sub
    '    '        End If

    '    iWorkHr = fk_sqlDbl("select tblDayType.workUnit from tblDayType INNER JOIN tblEmpregister ON tblDayType.TypeID = tblEmpRegister.DayTypeID WHERE tblEmpRegister.AtDate = '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID = '" & StrEmployeeID & "'")
    '    If iWorkHr = 0 Then
    '        MsgBox("Can't Select the Non working Date for the To Date", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    StrAplLeaveID = fk_RetString("SELECT lvID FROM tblLeaveType WHERE Lvdesc = '" & ComboBox1.Text & "'")
    '    If StrAplLeaveID = "" Then
    '        MsgBox("Select the Leave Type", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If
    '    If txtLvBalance.Text = "" Then txtLvBalance.Text = "0"
    '    If intChkLimit = 1 Then If CDbl(txtLvBalance.Text) <= 0 Then MsgBox("No Available Leave for the Selected Leave Type", MsgBoxStyle.Information) : Exit Sub
    '    If intChkLimit = 1 Then If CDbl(txtLvBalance.Text) - CDbl(txtAplLv.Text) < 0 Then MsgBox("No Enough Leave to Apply", MsgBoxStyle.Information) : Exit Sub



    '    If CDbl(txtAplLv.Text) <= 0 Then
    '        MsgBox("No Applied Leave found", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If

    '    'Dim dblRmnLv As Double = CDbl(txtLvBalance.Text) - CDbl(txtAplLv.Text)
    '    'If dblRmnLv < 0 Then
    '    '    MsgBox("No Enough Leave to Apply", MsgBoxStyle.Information)
    '    '    Exit Sub
    '    'End If

    '    If StrSvStatus = "S" Then
    '        Dim iR As Integer = fk_sqlDbl("SELECT NoAplLv FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
    '        StrAplLeaveID = fk_CreateSerial(5, iR)
    '    End If


    'End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown

        If e.KeyCode = Keys.F2 Then cmdBrsC_Click(sender, e)

    End Sub

    Private Sub txtCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.Leave


    End Sub



    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
        'Dim intNos As Integer = 0
        'If txtCode.Text = "" Then
        '    txtempName.Text = ""
        '    txtDept.Text = ""
        '    dgvEmp.Visible = False
        'End If
        'If txtCode.Text.Length >= 6 Then
        '    Dim intisEpf As Integer = fk_sqlDbl("SELECT isEpf FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        '    Select Case intisEpf
        '        Case 0
        '            StrEmployeeID = txtCode.Text
        '        Case 1
        '            StrEmployeeID = fk_RetString("SELECT RegID FROM tblEmployee WHERE EpfNo = '" & txtCode.Text & "'")
        '        Case 2
        '            StrEmployeeID = fk_RetString("SELECT RegID FROM tblEmployee WHERE EnrolNo = " & CInt(txtCode.Text) & "'")

        '    End Select




        '    Dim cnShw As New SqlConnection(sqlConString)
        '    cnShw.Open()
        '    Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblEmployee.EpfNo " & _
        '    " FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        '    Try
        '        Dim cmShw As New SqlCommand(sqlQRY, cnShw)
        '        Dim drShw As SqlDataReader = cmShw.ExecuteReader
        '        If drShw.Read Then
        '            StrEmployeeID = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
        '            txtCode.Text = IIf(IsDBNull(drShw.Item("EpfNo")), "", drShw.Item("EpfNo"))
        '            txtempName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
        '            txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))

        '        End If
        '        ComboBox1.Focus()
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    Finally
        '        cnShw.Close()
        '    End Try


        '    Load_InformationtoGrid("select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID", dgvLvHistory, 5)
        '    clr_Grid(dgvLvHistory)

        '    Dim sqlLv As String = "select tblLeaveTRD.Lvdate,tblLeaveTRD.LvType,tblLeaveType.LvDesc,tblLeaveTRD.NoLeave,tblLeaveTRH.AuthLeave FROM tblLeaveTRD " & _
        '        " INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqiD " & _
        '        " INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.lvID WHERE tblLeaveTRH.EmpID = '" & StrEmployeeID & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.cYear = " & intCurrentYear & " Order By tblLeaveTRD.LvDate"
        '    Load_InformationtoGrid(sqlLv, dgvLvK, 5)
        '    ' clr_Grid(dgvLvK)
        '    With dgvLvK
        '        Dim intPP As Integer = 0

        '        For Each row As DataGridViewRow In .Rows
        '            intPP = .Item(4, row.Index).Value

        '            If intPP = 0 Then row.DefaultCellStyle.BackColor = lblPost.BackColor Else row.DefaultCellStyle.BackColor = lblPre.BackColor
        '        Next
        '    End With


        '    ComboBox1.Focus()
        'End If
    End Sub

    Private Sub dgvEmp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvEmp.KeyDown

        If e.KeyCode = Keys.Enter Then
            StrEmployeeID = dgvEmp.Item(0, dgvEmp.CurrentRow.Index).Value
            dgvEmp.Visible = False
            Dim cnShw As New SqlConnection(sqlConString)
            cnShw.Open()
            Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno " & _
            " FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
            Try


                Dim cmShw As New SqlCommand(sqlQRY, cnShw)
                Dim drShw As SqlDataReader = cmShw.ExecuteReader
                If drShw.Read Then
                    txtCode.Text = IIf(IsDBNull(drShw.Item("epfno")), "", drShw.Item("epfno"))
                    txtempName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                    txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))

                End If
                ComboBox1.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnShw.Close()
            End Try
        End If

        'Get the Employee Current Year Leave Balance 
        Load_InformationtoGrid("select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave,(tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intSelectedYear & " Order By tblEmpLeaveD.LeaveID", dgvLvHistory, 5)
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
     txtAplLv.KeyPress, txtRemark.KeyPress, dtpToDate.KeyPress, dtpFrDate.KeyPress, _
     dtpAplLvDate.KeyPress, ComboBox1.KeyPress, txtrPerson.KeyPress, dtpFrtime.KeyPress, dtpToTime.KeyPress, txtLvsBalance.KeyPress
        Dim crtl As Control
        crtl = sender
        If AscW(e.KeyChar) = 13 Then
            Select Case crtl.Name
                Case "ComboBox1"
                    dtpFrDate.Focus()
                Case "dtpFrDate"
                    dtpToDate.Focus()
                    'Case "dtpFrtime"
                    '    dtpToDate.Focus()
                Case "dtpToDate"
                    dgvSpLv.Focus()
                Case "txtAplLv"
                    dtpAplLvDate.Focus()
                Case "DateTimePicker3"

                    txtRemark.Focus()
                Case "TextBox6"
                    cmdSave_Click(sender, e)
            End Select
        End If
    End Sub

    Private Sub dgvSpLv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSpLv.KeyDown, dgvLeaveTake.KeyDown
        Dim dblLv As Double = 0
        If e.KeyCode = Keys.Enter Then
            With dgvSpLv
                For i As Integer = 0 To .RowCount - 1
                    dblLv = dblLv + CDbl(.Item(2, i).Value)
                Next
            End With
            txtAplLv.Text = dblLv

            txtAplLv.Focus()
        End If
    End Sub

    Private Sub cmdSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dgvSpLv.RowCount <= 0 Then MsgBox("No Active dates selected Range") : Exit Sub
        Dim dblLv As Double = 0

        With dgvSpLv
            For i As Integer = 0 To .RowCount - 1
                dblLv = dblLv + CDbl(.Item(2, i).Value)
            Next
        End With
        txtAplLv.Text = dblLv

        txtAplLv.Focus()
    End Sub

    Private Sub txtAplLv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAplLv.KeyDown, txtLvsBalance.KeyDown
        If e.KeyCode = Keys.F5 Then
            cmdSync_Click(sender, e)
        End If
    End Sub

    Private Sub LeaveSave()


        '20180817 prasanna After month End Can't Apply Leave  preview days  
        If UserLevelID <> "000" Then
            If dtpFrDate.Value <= MaxmunMonthEndDate Then MsgBox("Cant Apply Leaves  : Your Last Month ('" & MaxmunMonthEndDate & "') Is Over  ", MsgBoxStyle.Information) : Exit Sub
        End If


        If ComboBox1.Text = "NONE" Then Exit Sub
        If Trim(cmbLvNew.Text) = "" Or Trim(cmbLvNew.Text) = "0" Then MessageBox.Show("Please select leave quantity, wheather full day or half day", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        Dim dblEffDays As Double = 0 : Dim intChkLimit As Integer = 0 : Dim intAlOther As Integer = 0 : Dim intAlwFuture As Integer = 0
        Dim intChkLateErly As Integer = 0 : Dim intLEmins As Integer = 0 : Dim intMonthC As Integer = 0
        Dim intLvLateMins As Integer = 0 : Dim intLvEarlyMins As Integer = 0 : Dim intAtnSt As Integer = 0
        Dim StrLEStatus As String = "" : Dim intLStatus As Integer = 0 : Dim intEStatus As Integer = 0 : Dim dblWorkUnit As Decimal : Dim dblNrWorkD As Decimal : Dim dblLvPosiibleD As Decimal : Dim intShiftMin As Integer : Dim strExstLvID As String : Dim intExLatestatus As Integer : Dim intExEarlyStatus As Integer
        '01. Check the basic conditions
        Dim sqlView As String = "select tblLeaveType.EffDay,tblLeaveType.ChkLimit,tblLeaveType.AllowOthLv,tblLeaveType.AllowFutureLv,tblLeaveType.ChkLateEarly,tblLeaveType.LateEarlyMin,tblLvAplMeth.mCount FROM tblLeaveType,tblLvAplMeth WHERE tblLeaveType.LvMode = tblLvAplMeth.mID AND tblLeaveType.LvID = '" & StrLvID & "'"
        fk_Return_MultyString(sqlView, 7)
        dblEffDays = fk_ReadGRID(0) : intChkLimit = fk_ReadGRID(1) : intAlOther = fk_ReadGRID(2) : intAlwFuture = fk_ReadGRID(3)
        intChkLateErly = fk_ReadGRID(4) : intLEmins = fk_ReadGRID(5) : intMonthC = fk_ReadGRID(6)

        If StrLvID = "" Then MsgBox("Please select the leave type", MsgBoxStyle.Information) : Exit Sub
        If ComboBox1.Text = "" Then MsgBox("Please select the leave type", MsgBoxStyle.Information) : Exit Sub
        '01.2 Check for the deferant leave type
        Dim bolLeaveType As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 0, StrLvID, "F")
        If bolLeaveType = True Then MsgBox("You can't process with defferant leave type in single leave application", MsgBoxStyle.Information) : Exit Sub
        '01.3 Check Same Date found in the grid 
        Dim bolSaveDate As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 2, Format(dtpFrDate.Value, "dd/MM/yyyy"), "T")
        If bolSaveDate = True Then MsgBox("Duplicate Leave Date", MsgBoxStyle.Critical) : Exit Sub
        '01.4 Get the Applied leave count in the grid and match with balance leave 
        Dim dblApl As Double = fk_GridSum(dgvLeaveTake, 3) : Dim dblNewTake As Double = dblApl + CDbl(cmbLvNew.Text) : Dim dblAvblLv As Double = 0
        dblAvblLv = CDbl(txtLvsBalance.Text) - dblNewTake
        If intChkLimit = 1 And StrLvID <> StrShortSumLvID Then ' If system is checking the leave limit this function should 
            If dblAvblLv < 0 Then MsgBox("You don't have enough leave balance to process with leave", MsgBoxStyle.Critical) : Exit Sub
        End If

        Dim intDayDef As Integer = DateDiff(DateInterval.Day, dtpAplLvDate.Value, dtpFrDate.Value)
        If intAlwFuture = 0 Then If intDayDef < 0 Then MsgBox("This leave type is not allowing you to apply future Leave", MsgBoxStyle.Information) : Exit Sub 'System is checking the leave apply approval for the future
        'Get the Late Early Mins for the select date from Employee Register
        sqlView = "select tblEmpRegister.LateMins,tblEmpRegister.EarlyMins,tblEmpRegister.AntStatus,tblDayType.WorkUnit,tblEmpRegister.nrWorkDay,tblDayType.WorkUnit-tblEmpRegister.nrWorkDay,datediff(mi,tblEmpRegister.sInTime,tblEmpRegister.sOutTime),tblEmpRegister.LEStatus,tblEmpRegister.LeaveID,tblEmpRegister.isLate,tblEmpRegister.isEarly from tblEmpRegister,tblDayType WHERE tblEmpRegister.dayTypeID=tblDayType.typeID AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate = '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "'" : fk_Return_MultyString(sqlView, 11)
        intLvLateMins = fk_ReadGRID(0) : intLvEarlyMins = fk_ReadGRID(1) : intAtnSt = fk_ReadGRID(2) : dblWorkUnit = fk_ReadGRID(3) : dblNrWorkD = fk_ReadGRID(4) : dblLvPosiibleD = fk_ReadGRID(5) : intShiftMin = fk_ReadGRID(6) : strExLeStatus = fk_ReadGRID(7) : strExstLvID = fk_ReadGRID(8) : intExLatestatus = fk_ReadGRID(9) : intExEarlyStatus = fk_ReadGRID(10)

        If dblLvPosiibleD <= 0 And StrLvID <> StrShortSumLvID Then
            'restrict capability to apply leave for ful/half day fully coverd days (Not restrict short leaves)
            Dim dr1 As DialogResult = MessageBox.Show("You don't want to apply leave for this type of days. Any way do you want to apply a leave for this day?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            If dr1 = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If dblLvPosiibleD < Val(cmbLvNew.Text) And StrLvID <> StrShortSumLvID Then
            'restrict capability to apply leave for ful/half day fully coverd days (Not restrict short leaves)
            Dim dr As DialogResult = MessageBox.Show("You don't want to apply this much of leave for selected date. Its enough if you can apply " & dblLvPosiibleD & " leave. Any way do you want to continue? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            If dr = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If intLvLateMins > 0 Then intLStatus = 1 Else intLStatus = 0
        If intLvEarlyMins > 0 Then intEStatus = 1 Else intEStatus = 0
        StrLEStatus = intLStatus.ToString & "|" & intEStatus.ToString

        If intLStatus = 1 Then bolLate = True Else bolLate = False
        If intEStatus = 1 Then bolEarly = True Else bolEarly = False

        If StrLEStatus = "1|1" Then
            'If CDbl(cmbLvNew.Text) <= 1 Then
            dtGlobalDate = dtpFrDate.Value.Date

            intGlbLateMinutes = intLvLateMins
            intGlbEarlyMinutes = intLvEarlyMins

            'To be view late has covered by previous leave Kasun K01 - 2018-06-09
            If strExLeStatus = "1|0" Then
                intGlbLateMinutes = 0
            End If
            'To be view early has covered by previous leave Kasun K01 - 2018-06-09
            If strExLeStatus = "0|1" Then
                intGlbEarlyMinutes = 0
            End If

            LoadForm(New frmLeaveApplyMessage)

            'MessageBox.Show("System has identified both late and early minutes for selected date. How do you want to right of the late/early", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            intLStatus = intGlbLateStatus
            intEStatus = intGlbEarlyStatus
            'Generate leave status Kasun K01 - 2018-06-09
            StrLEStatus = intLStatus.ToString & "|" & intEStatus.ToString

            If strExLeStatus = "0|0" Then
                'This will update in tblEmpRegister when applying second leave for same day
                strExLeStatus = StrLEStatus
            ElseIf strExLeStatus = "0|1" Then
                strExLeStatus = "1|0"
                StrLEStatus = "1|1"
            ElseIf strExLeStatus = "1|0" Then
                strExLeStatus = "0|1"
                StrLEStatus = "1|1"
            End If
        End If
        Dim intLvMonth As Integer = dtpFrDate.Value.Month
        'Validate short leaves
        If StrShortSumLvID = StrLvID Then
            If dblNrWorkD <= 0 Then
                MessageBox.Show("You can't apply short leave for non worked days", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If
            intThisMonthLvMinTotal = 0
            intThisMonthLvQtyTotal = 0
            For ik As Integer = 0 To dgvLeaveTake.RowCount - 1
                Dim dblMin As Double = Val(dgvLeaveTake.Item(11, ik).Value)
                intThisMonthLvMinTotal = intThisMonthLvMinTotal + dblMin
                intThisMonthLvQtyTotal = intThisMonthLvQtyTotal + Val(dgvLeaveTake.Item(3, ik).Value)
                If intLvMonth <> Val(dgvLeaveTake.Item(12, ik).Value) Then
                    MessageBox.Show("You cant apply short leave for differnet months", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
                End If
            Next
            intThisMonthLvMinTotal = intThisMonthLvMinTotal + intThisMnthLvMin
            intThisMonthLvQtyTotal = intThisMonthLvQtyTotal + 1
            intThisMonthBalMin = dblBalShLvMin - intThisMonthLvMinTotal
            intThisMonthBalQty = dblBalShLvQty - intThisMonthLvQtyTotal
            If IsChkShLvBalMin = 1 Then
                If intThisMonthBalMin < 0 Then
                    MessageBox.Show("You dont have enough leave minutes balance for this month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    intThisMonthLvMinTotal = intThisMonthLvMinTotal - intThisMnthLvMin
                    intThisMonthLvQtyTotal = intThisMonthLvQtyTotal - 1
                    intThisMonthBalMin = dblBalShLvMin - intThisMonthLvMinTotal
                    intThisMonthBalQty = dblBalShLvQty - intThisMonthLvQtyTotal
                    Exit Sub

                End If
            End If

            If intThisMonthBalQty < 0 Then
                MessageBox.Show("You dont have enough leave quantity balance for this month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                intThisMonthLvMinTotal = intThisMonthLvMinTotal - intThisMnthLvMin
                intThisMonthLvQtyTotal = intThisMonthLvQtyTotal - 1
                intThisMonthBalMin = dblBalShLvMin - intThisMonthLvMinTotal
                intThisMonthBalQty = dblBalShLvQty - intThisMonthLvQtyTotal
                Exit Sub
            End If

        End If

        If strExstLvID = StrLvID Then
            MessageBox.Show("You are not allowed to apply same type leave twice a day", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        End If

        'Check applied leave sum for selected date without short leave Kasun K01 - 2018-06-09
        Dim dblAplLvQ As Double = fk_sqlDbl("SELECT Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRD,tblLeaveTRH WHERE (tblLeaveTRD.EmpID = tblLeaveTRH.EmpID AND tblLeaveTRD.RqID = tblLeaveTRH.RqID) AND  tblLeaveTRD.EmpID = '" & StrEmployeeID & "' AND tblLeaveTRD.LvDate = '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRD.lvType<>'" & StrShortSumLvID & "'")

        'Check whether applying leave type is short leave or not Kasun K01 - 2018-06-09
        If StrLvID <> StrShortSumLvID Then
            If 1 - (dblAplLvQ + CDbl(cmbLvNew.Text)) < 0 Then MsgBox("You have Already applied leave for same date", MsgBoxStyle.Critical) : Exit Sub
        End If

        'Don't Allow Leave If employee's perfect attendance record 
        Dim bolAll As Boolean = False
        bolAll = fk_CheckEx("SELECT EmpID FROM tblEmpRegister WHERE AntStatus = 1 AND isLate = 0 AND isLate = 0 AND EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtpFrDate.Value, strRetDateTimeFormat) & "'")
        If bolAll = True Then
            If MsgBox("This employee found perfect attendance record for the selected date, Do you want to Apply Leave ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Dim intAL As Integer = 0 : Dim intAE As Integer = 0
        If intLStatus = 1 Then intAL = 0 Else intAL = intExLatestatus
        If intEStatus = 1 Then intAE = 0 Else intAE = intExEarlyStatus

        If intThisMnthLvMin = 0 Then intThisMnthLvMin = intMinMnPerShLv : intThisMonthLvMinTotal = intMinMnPerShLv
        If StrShortSumLvID <> StrLvID Then
            intThisMnthLvMin = intShiftMin * Val(cmbLvNew.Text)
        End If
        With dgvLeaveTake
            .Rows.Add(StrLvID, ComboBox1.Text, Format(dtpFrDate.Value, "dd/MM/yyyy"), cmbLvNew.Text, txtFrDtype.Text, dtpFrDate.Value, intAL.ToString, intAE.ToString, StrLEStatus, intLStatus, intEStatus, intThisMnthLvMin, intLvMonth, strExLeStatus)
        End With
        txtAplLv.Text = fk_GridSum(dgvLeaveTake, 3)

    End Sub

    Public Function RoundToSignificance(ByVal number As Integer, _
       ByVal significance As Integer) As Integer
        'Round number up or down to the nearest multiple of significance'
        Dim d As Double
        d = number / significance
        d = Math.Ceiling(d)
        RoundToSignificance = d * significance
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFul.Click
        cmbLvNew.Text = 1
        LeaveSave()
    End Sub

    Public Sub Apply_Lv_Old()
        'Check Leave availablity
        If StrLvID = "" Then MsgBox("Please select leave type", MsgBoxStyle.Information) : Exit Sub
        Dim dblApl As Double = fk_GridSum(dgvLeaveTake, 3) : Dim dblNewTake As Double = dblApl + CDbl(cmbLvNew.Text) : Dim dblAvblLv As Double = 0
        dblAvblLv = CDbl(txtLvsBalance.Text) - dblNewTake
        If dblAvblLv < 0 Then MsgBox("You don't have enough leave balance to process with leave", MsgBoxStyle.Critical) : Exit Sub
        'Check Same Date found in the grid 
        Dim bolSaveDate As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 2, Format(dtpFrDate.Value, strRetDateTimeFormat), "T")
        If bolSaveDate = True Then MsgBox("Duplicate Leave Date", MsgBoxStyle.Critical) : Exit Sub
        'Check Deferant Leave Type
        Dim bolLeaveType As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 0, StrLvID, "F")
        If bolLeaveType = True Then MsgBox("You can't process with deferant leave type in single leave application", MsgBoxStyle.Information) : Exit Sub
        If CDbl(cmbLvNew.Text) = 0 Or CDbl(cmbLvNew.Text) > 1 Then MsgBox("Please enter valied Leave number", MsgBoxStyle.Critical) : Exit Sub

    End Sub

    Public Function fk_GridSum(ByVal dgv As DataGridView, ByVal intCol As Integer) As Double
        Dim dblRetun As Double = 0
        With dgv
            For i As Integer = 0 To .RowCount - 1
                dblRetun = dblRetun + CDbl(.Item(intCol, i).Value)
            Next
        End With

        Return dblRetun
    End Function

    Public Function fk_RetGridDuplicate(ByVal dgv As DataGridView, ByVal intCol As Integer, ByVal EnterVal As String, ByVal RetRq As String) As Boolean
        Dim bolReturn As Boolean = False : Dim StrCurrentVal As String = ""

        With dgv
            For i As Integer = 0 To .RowCount - 1
                StrCurrentVal = .Item(intCol, i).Value
                Select Case RetRq
                    Case "T"
                        If StrCurrentVal = EnterVal Then bolReturn = True : i = .RowCount - 1
                    Case "F"
                        If StrCurrentVal <> EnterVal Then bolReturn = True : i = .RowCount - 1
                End Select

            Next
        End With
        Return bolReturn
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Leave", "Apply Leave") = False Then Exit Sub

        If StrLvID = "" Then MsgBox("No Leave Type ", MsgBoxStyle.Information) : Exit Sub
        If Val(txtAplLv.Text) <= 0 Then MsgBox("No Applied Leave", MsgBoxStyle.Information) : Exit Sub
        If dgvLeaveTake.RowCount < 0 Then MsgBox("No Applied Leave", MsgBoxStyle.Information) : Exit Sub
        If txtRemark.Text = "" Then MsgBox("Please type remark", MsgBoxStyle.Information) : txtRemark.Focus() : Exit Sub

        'Add this to re validate leave ID 
        StrLvID = dgvLeaveTake.Rows(0).Cells(0).Value

        'Generate the Leave Transaction ID 
        Dim dblLvs As Double = 0
        With dgvLeaveTake
            For i As Integer = 0 To .RowCount - 1
                dblLvs = dblLvs + (CDbl(.Item(3, i).Value))
            Next
        End With

        'Save Information 
        Dim sqlQRY As String = "" : txtAplLv.Text = dblLvs
        Dim StrLeaveID As String = "" : StrLeaveID = fk_GenSerial("SELECT NoAplLv FROM tblCompany WHERE CompID = '" & StrCompID & "'", 5)
        lblRQID.Text = StrAplLeaveID

        'Save to the Database Header 
        sqlQRY = "INSERT INTO tblLeaveTRH (RqID,EmpID,CompID,RqDate,cYear,cMonth,LvID,NoLves,FrDate,FrTime,ClsDate,ClsTime,CovDuty,AprBy,AprDate,AprStatus,Rsubmit,Status," & _
        " AuthLeave,Remark,lvMin) VALUES ('" & StrLeaveID & "','" & StrEmployeeID & "','" & StrCompID & "','" & Format(dtpAplLvDate.Value, strRetDateTimeFormat) & "'," & Year(dtpFrDate.Value) & ", " & _
        " " & Month(dtpAplLvDate.Value) & ", '" & StrLvID & "'," & CDbl(txtAplLv.Text) & ",'','','','','','" & StrUserID.Substring(0, 3) & "' ,''," & chkApprovLv.CheckState & ",0,0," & chkApprovLv.CheckState & ",'" & txtRemark.Text & "'," & CDbl(intThisMonthLvMinTotal) & ")"
        'Save Leave Details updated this Kasun K01 - 2018-06-09
        Dim dtLeaveDate As Date
        With dgvLeaveTake
            For i As Integer = 0 To .RowCount - 1
                sqlQRY = sqlQRY & " INSERT INTO tblLeaveTRD (RqID,EmpID,LvDate,LvType,NoLeave,Status,AuthLeave,lvMin,LEStatus) VALUES ('" & StrLeaveID & "', " & _
               " '" & StrEmployeeID & "','" & Format(CDate(.Item(5, i).Value), strRetDateTimeFormat) & "','" & .Item(0, i).Value & "'," & CDbl(.Item(3, i).Value) & ", 0, " & chkApprovLv.CheckState & "," & CDbl(.Item(11, i).Value) & ",'" & (.Item(13, i).Value) & "')"
                dtLeaveDate = CDate(.Item(5, i).Value)
                sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET IsLate = " & CInt(.Item(6, i).Value) & ", isEarly = " & CInt(.Item(7, i).Value) & ",LEStatus = '" & (.Item(8, i).Value) & "',leaveID='" & .Item(0, i).Value & "',NoLeave=" & CDbl(.Item(3, i).Value) & ",isLeave=1  WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtLeaveDate, strRetDateTimeFormat) & "'"
                If intEffDay = 0 Then
                    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET nrWorkDay=1,AutoLeaveNo=0 WHERE nrWorkDay<>0 AND EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtLeaveDate, strRetDateTimeFormat) & "'"
                End If
            Next
        End With

        If StrShortSumLvID = StrLvID And intThisMonthLvMinTotal <> 0 Then
            'Update taken short leave
            sqlQRY = sqlQRY & " UPDATE tblEmpShortLeaveD SET usedMins = usedMins + " & CDbl(intThisMonthLvMinTotal) & ",balMin=balMin-" & CDbl(intThisMonthLvMinTotal) & ",usedQty=usedQty+" & CDbl(intThisMonthLvQtyTotal) & ",balQty=balQty-" & CDbl(intThisMonthLvQtyTotal) & " WHERE EmpID = '" & StrEmployeeID & "' AND cYear = " & intSelectedYear & " AND cMonth=" & dtpFrDate.Value.Month & ""
        End If
        'Update Employee Leave Taken 
        sqlQRY = sqlQRY & " UPDATE tblEmpLeaveD SET TakenLeave = TakenLeave + " & CDbl(txtAplLv.Text) & " WHERE EmpID = '" & StrEmployeeID & "' AND LeaveID = '" & StrLvID & "' AND cYear = " & intSelectedYear & ""

        sqlQRY = sqlQRY & " UPDATE tblCompany SET NoAplLv = NoAplLv + 1 WHERE CompID = '" & StrCompID & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)

        'Dim dtMinDate As Date = CDate(dgvLeaveTake.Item(5, 0).Value)
        'Dim dtMaxDate As Date = CDate(dgvLeaveTake.Item(5, 0).Value)
        'Dim dtDate As Date = CDate(dgvLeaveTake.Item(5, 0).Value)
        'With dgvLeaveTake
        '    For ik As Integer = 0 To .RowCount - 1
        '        dtDate = CDate(.Item(5, ik).Value)
        '        If dtDate < dtMinDate Then dtMinDate = dtDate
        '        If dtDate > dtMaxDate Then dtMaxDate = dtDate
        '    Next
        'End With

        'process_AttendanceParameters(dtMinDate, dtMaxDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)

        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdBrsC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        sSQL = "SELECT     dbo.tblEmployee.RegID," & sqlTagName & ", dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
        "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then


                'pb_ShowEmployee(StrEmployeeID)

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try

        'StrEmployeeID = ""

        'Dim frmBrs As New frmSrchEmployee
        'frmBrs.ShowDialog()

        cmdRefresh_Click(sender, e)

        ViewLeaveInfo()
    End Sub

    Private Sub ViewLeaveInfo()
        'View Employee information using the EMployee
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "select tblEmployee.RegID," & sqlTag1 & " as 'RelID',tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno " & _
        " FROM tblEmployee LEFT OUTER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                txtempName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))
                txtRelID.Text = IIf(IsDBNull(drShw.Item("RelID")), "", drShw.Item("RelID"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

        '****************** NEW MODIFICATION FOR SHEROTON************************
        'NUMBER     : LV-20170710
        'AUTHOR     : Kasun
        'Date       : 10/Jul/2017
        'Details    : this will only effect when it selected the new leave mechanizm, it never damaged to the exisiting process.
        '************************* END ******************************************

        If intIsNewLeaveC = 1 Then
            'LV-20170710
            sqlQRY = "Exec sp_CalLeave 1,1,12," & intSelectedYear & ",'" & StrEmployeeID & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
        End If

        'Load_InformationtoGrid("select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID", dgvLvHistory, 5)
        'clr_Grid(dgvLvHistory)
        '****** Modified On 29/Aug/2014 ****
        'Get Monthly Leave Balance for the selected month
        ''FK_EQ("EXEC sp_SetLeaveBalance " & dtpFrDate.Value.Year & "," & dtpFrDate.Value.Month & ",'" & StrEmployeeID & "'", "S", "", False, False, True)

        '***** 
        sSQL = "CREATE TABLE #T (EmpID NVARCHAR (6),LeaveID NVARCHAR (3),LvDesc NVARCHAR (267),NoLeaves NUMERIC (18,2),TakenLeave NUMERIC (18,2),balLeave NUMERIC (18,2),cYear NUMERIC (18,0)) INSERT INTO #T select tblEmpLeaveD.empID,tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END," & intSelectedYear & " From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID =  '" & StrEmployeeID & "'  AND tblEmpLeaveD.cYear = " & intSelectedYear & " Order By tblEmpLeaveD.LeaveID UPDATE #T SET #T.balLeave=(tblEmpShortLeaveD.totQty-tblEmpShortLeaveD.usedQty),#T.noLeaves=tblEmpShortLeaveD.totQty,#T.TakenLeave=tblEmpShortLeaveD.usedQty FROM tblEmpShortLeaveD,#T WHERE tblEmpShortLeaveD.EmpID=#T.EmpID AND tblEmpShortLeaveD.cYear=#T.cYear AND tblEmpShortLeaveD.cYear=" & intSelectedYear & " AND tblEmpShortLeaveD.cMonth=" & intSelectedMonth & " AND #T.leaveID='" & StrShortSumLvID & "' SELECT LeaveID,LvDesc,NoLeaves,TakenLeave,balLeave FROM #T "
        ''''sSQL = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intSelectedYear & " Order By tblEmpLeaveD.LeaveID"
        ''sSQL = "SELECT LeaveID,lvName,EntLeave,TknLeave,BalLeave FROM tblTmpLeave Order By LeaveID"
        Load_InformationtoGrid(sSQL, dgvLvHistory, 5)
        clr_Grid(dgvLvHistory)

        Dim sqlLv As String = "select tblLeaveTRD.Lvdate,tblLeaveTRD.LvType,tblLeaveType.LvDesc,tblLeaveTRD.NoLeave,tblLeaveTRH.AuthLeave FROM tblLeaveTRD " & _
            " INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqiD AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID" & _
            " INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.lvID WHERE tblLeaveTRH.EmpID = '" & StrEmployeeID & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.cYear = " & intSelectedYear & " Order By tblLeaveTRD.LvDate"
        Load_InformationtoGrid(sqlLv, dgvLvK, 5)
        ' clr_Grid(dgvLvK)
        With dgvLvK
            Dim intPP As Integer = 0

            For Each row As DataGridViewRow In .Rows
                intPP = .Item(4, row.Index).Value

                If intPP = 0 Then row.DefaultCellStyle.BackColor = lblPost.BackColor Else row.DefaultCellStyle.BackColor = lblPre.BackColor
            Next
        End With

        ComboBox1.Focus()

    End Sub

    Private Sub dgvLvHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLvHistory.Click
        If dgvLvHistory.RowCount = 0 Then

            Exit Sub
        End If
        ComboBox1.Text = Trim(dgvLvHistory.CurrentRow.Cells(1).Value)
        dtPrStartDate = DateSerial(dtpFrDate.Value.Year, dtpFrDate.Value.Month, intMonthStart)
        dtPrEndDate = DateAdd(DateInterval.Month, 1, dtPrStartDate)

        leave_checks(dtPrStartDate.Date, dtPrEndDate.Date)
        If StrShortSumLvID = StrLvID Then
            'sSQL = "SELECT tblEmpShortLeaveD.totMins-tblEmpShortLeaveD.UsedMins,tblEmpShortLeaveD.totQty-tblEmpShortLeaveD.usedQty FROM tblEmpShortLeaveD WHERE tblEmpShortLeaveD.EmpID='" & StrEmployeeID & "' AND tblEmpShortLeaveD.cYear=" & intSelectedYear & "  AND tblEmpShortLeaveD.cMonth=" & intSelectedMonth & ""
            'Dim dtTo As Date = DateAdd(DateInterval.Month, 1, DateSerial(dtpFrDate.Value.Year, dtpFrDate.Value.Month, 1))
            'dtTo = DateAdd(DateInterval.Day, -1, dtTo)
            Dim dtFr As Date = DateSerial(dtpFrDate.Value.Year, dtpFrDate.Value.Month, 1)
            sSQL = "EXEC [SP_ViewShortLeaveSelected] '" & StrEmployeeID & "' ,'" & Format(dtFr, strRetDateTimeFormat) & "','" & Format(dtFr, strRetDateTimeFormat) & "'," & intTotShLvMinPerMonth & "," & intMinMnPerShLv & ",1," & dtpFrDate.Value.Year & "," & dtpFrDate.Value.Month & ""
            fk_Return_MultyString(sSQL, 13)
            dblBalShLvMin = fk_ReadGRID(11)
            dblBalShLvQty = fk_ReadGRID(12)
            intThisMnthLvMin = fk_ReadGRID(10)
            txtLvBalance.Text = dblBalShLvQty
            lblShLvBalMin.Text = "Bal. Short Leave Minutes : " & dblBalShLvMin
            lblShLvBalQty.Text = "Bal. Short Leave Quantity : " & dblBalShLvQty
            lblShLvBalMin.Visible = True
            lblShLvBalQty.Visible = True
            btnHalf.Visible = False
        Else
            lblShLvBalMin.Visible = False
            lblShLvBalQty.Visible = False
            btnHalf.Visible = True

        End If
    End Sub


    ' for leave daye limit after month end process -- prasanna
    Private Sub ShowDateLimitForLeaves(ByVal ShowmaxDays As Integer, ByVal SelectRbtn As String)
        Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lLeaveApply = 1  )")
        Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lLeaveApply = 1  )")
        Dim dateLimitEdit As DateTime = New Date(maxYear, maxMonth, 1)

        LeaveShowdays = DateDiff(DateInterval.Day, dateLimitEdit, dtLastProcessed)
        If SelectRbtn = "Day" Then
            If LeaveShowdays >= ShowmaxDays Then : LeaveShowdays = 1 : Else : LeaveShowdays = LeaveShowdays : End If
        ElseIf SelectRbtn = "Week" Then
            If LeaveShowdays >= ShowmaxDays Then : LeaveShowdays = 6 : Else : LeaveShowdays = LeaveShowdays : End If
        ElseIf SelectRbtn = "Month" Then
            LeaveShowdays = LeaveShowdays
        End If

    End Sub


    Private Sub btnAbsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbsent.Click
        StrStatus = "Absent"
        Dim dtFrom As Date
        Label26.Text = "Absent Employee List"
        If rdbWeek.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -6, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Week"
        ElseIf rdbMonth.Checked = True Then

            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)

            ''  dtFrom = DateAdd(DateInterval.Day, -30, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Month"
        ElseIf rdbDtR.Checked = True Then
            dtFrom = dtpFD.Value
            dtLastProcessed = dtpToD.Value
            Label26.Text = Label26.Text & " for Range of Dates"
        Else
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -1, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Day"
        End If
        sSQL = "select tblEmployee.regID," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',convert(nvarchar (10),tblEmpRegister.atDate,111) AS 'Absent Day',tblDayType.typeName as 'Day Type',TBLLEAVETYPE.LvDesc AS 'Applied Leave' FROM tblEmpRegister LEFT OUTER JOIN tblEmployee  ON tblEmpRegister.empID=tblEmployee.regID LEFT OUTER JOIN tblDayType ON tblEmpRegister.dayTypeID=tblDayType.typeID LEFT OUTER JOIN TBLLEAVETYPE ON TBLLEAVETYPE.LvID=tblEmpregister.LeaveID WHERE tblDayType.workUnit<>0 and tblEmpregister.antStatus=0 and tblemployee.Empstatus<>9  and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblEmpRegister.atDate BETWEEN '" & Format(dtFrom, strRetDateTimeFormat) & "' AND '" & Format(dtLastProcessed, strRetDateTimeFormat) & "' AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' ) ORDER BY tblEmployee.empno"
        Fk_FillGrid(sSQL, dgvLeaveAllk)
        dgvLeaveAllk.Columns(0).Visible = False
        If dgvLeaveAllk.RowCount > 0 Then
            For k As Integer = 0 To dgvLeaveAllk.Columns.Count - 1
                dgvLeaveAllk.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        End If
        Label26.Text = Label26.Text & " : " & dgvLeaveAllk.RowCount
    End Sub

    Private Sub btnLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeave.Click
        StrStatus = "OnLeave"
        Dim dtFrom As Date
        Label26.Text = "On Leave Employee List"
        If rdbWeek.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -6, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Week"
        ElseIf rdbMonth.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -30, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Month"
        ElseIf rdbDtR.Checked = True Then
            dtFrom = dtpFD.Value
            dtLastProcessed = dtpToD.Value
            Label26.Text = Label26.Text & " for Range of Dates"
        Else
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -1, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Day"
        End If
        sSQL = "SELECT tblLeaveTRD.EmpID," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name', tblLeaveTRD.LvDate as 'Leave Date',tblLeaveTRD.rqID,tblleavetype.shortCode as 'Type',tblLeaveTRD.NoLeave AS 'Count',tblLeaveTRH.remark as 'Remark' FROM tblLeaveTRD LEFT OUTER JOIN tblLeaveTRH ON tblLeaveTRH.RqID=tblLeaveTRD.RqID AND tblLeaveTRH.EmpID=tblLeaveTRD.EmpID LEFT OUTER JOIN tblEmployee ON tblEmployee.RegID= tblLeaveTRH.EmpID LEFT OUTER JOIN dbo.tblleavetype ON dbo.tblleavetype.lvID=dbo.tblLeaveTRD.lvType   LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID  LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  WHERE tblLeaveTRH.status=0 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblLeaveTRD.LvDate BETWEEN '" & Format(dtFrom, strRetDateTimeFormat) & "' AND '" & Format(dtLastProcessed, strRetDateTimeFormat) & "' AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' ) ORDER BY tblLeaveTRH.EmpID,tblLeaveTRD.LvDate"
        Fk_FillGrid(sSQL, dgvLeaveAllk)
        dgvLeaveAllk.Columns(0).Visible = False
        dgvLeaveAllk.Columns(4).Visible = False
        If dgvLeaveAllk.RowCount > 0 Then
            For k As Integer = 0 To dgvLeaveAllk.Columns.Count - 1
                dgvLeaveAllk.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Next
        End If
        Label26.Text = Label26.Text & " : " & dgvLeaveAllk.RowCount
    End Sub

    Private Sub btnPrLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrLeave.Click
        StrStatus = "PrLeave"
        Dim dtFrom As Date
        Label26.Text = "Present - Leave Employee List"
        If rdbWeek.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -6, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Week"
        ElseIf rdbMonth.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -30, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Month"
        ElseIf rdbDtR.Checked = True Then
            dtFrom = dtpFD.Value
            dtLastProcessed = dtpToD.Value
            Label26.Text = Label26.Text & " for Range of Dates"
        Else
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -1, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Day"
        End If
        sSQL = "select tblEmployee.regID," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',convert(nvarchar (10),tblEmpRegister.atDate,111) AS 'Present Day',tblLeaveType.shortCode as 'Leave Type',tblEmpRegister.NoLeave as 'Count',convert(nvarchar (8),tblEmpRegister.inTime1,108) as 'In Time',convert(nvarchar (10),tblEmpRegister.outTime1,108) as 'Out Time' FROM tblEmpRegister,tblEmployee,tblLeaveType WHERE tblEmpRegister.empID=tblEmployee.regID and tblEmpRegister.leaveID=tblLeaveType.lvID  and tblEmpregister.antStatus=1 AND tblEmpregister.isLeave=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblEmpRegister.atDate BETWEEN '" & Format(dtFrom, strRetDateTimeFormat) & "' AND '" & Format(dtLastProcessed, strRetDateTimeFormat) & "' AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' ) ORDER BY tblEmployee.empno"
        Fk_FillGrid(sSQL, dgvLeaveAllk)
        dgvLeaveAllk.Columns(0).Visible = False
        If dgvLeaveAllk.RowCount > 0 Then
            For k As Integer = 0 To dgvLeaveAllk.Columns.Count - 1
                dgvLeaveAllk.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Next
        End If
        Label26.Text = Label26.Text & " : " & dgvLeaveAllk.RowCount
    End Sub

    Private Sub btnHalfday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHalfday.Click
        StrStatus = "Halfday"

        Dim dtFrom As Date
        Label26.Text = "Half Day Employee List"
        If rdbWeek.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -6, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Week"
        ElseIf rdbMonth.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -30, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Month"
        ElseIf rdbDtR.Checked = True Then
            dtFrom = dtpFD.Value
            dtLastProcessed = dtpToD.Value
            Label26.Text = Label26.Text & " for Range of Dates"
        Else
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -1, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Day"
        End If
        sSQL = "select tblEmployee.regID," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',convert(nvarchar (10),tblEmpRegister.atDate,111) AS 'Present Day',tblLeaveType.shortCode as 'Leave Type',tblEmpRegister.NoLeave as 'Count',convert(nvarchar (8),tblEmpRegister.inTime1,108) as 'In Time',convert(nvarchar (10),tblEmpRegister.outTime1,108) as 'Out Time',tblEmpregister.nrWorkDay as 'Worked Day' FROM tblEmpRegister LEFT OUTER JOIN tblEmployee ON tblEmpRegister.empID=tblEmployee.regID LEFT OUTER JOIN tblLeaveType ON tblEmpRegister.leaveID=tblLeaveType.lvID LEFT OUTER JOIN tblDayType on tblEmpRegister.dayTypeID=tblDayType.typeID WHERE tblEmpregister.antStatus=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblEmpregister.autoLeaveNo=0.5 AND tblEmpRegister.atDate BETWEEN '" & Format(dtFrom, strRetDateTimeFormat) & "' AND '" & Format(dtLastProcessed, strRetDateTimeFormat) & "' AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' ) ORDER BY tblEmployee.empno"
        Fk_FillGrid(sSQL, dgvLeaveAllk)
        dgvLeaveAllk.Columns(0).Visible = False
        If dgvLeaveAllk.RowCount > 0 Then
            For k As Integer = 0 To dgvLeaveAllk.Columns.Count - 1
                dgvLeaveAllk.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Next
        End If
        Label26.Text = Label26.Text & " : " & dgvLeaveAllk.RowCount
    End Sub

    Private Sub btnHalf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHalf.Click
        cmbLvNew.Text = 0.5
        LeaveSave()
    End Sub

    Private Sub cmdScroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScroll.Click
        If strTogle = "A" Then
            strTogle = "B"
            StrEmployeeID = strKEmployeeID
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmApplyLeavdatrange
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)

            frmReg.Show()
        Else
            strTogle = "A"
            Me.pnlDynamic.Controls.Clear()
            Me.pnlDynamic.Controls.Add(pnlApplyLeave)
        End If
    End Sub

    Private Sub btnCadre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCadre.Click
        StrStatus = "Cadre"

        Dim dtFrom As Date
        Label26.Text = "Total Employee List"
        If rdbWeek.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            'dtFrom = DateAdd(DateInterval.Day, -6, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Week"
        ElseIf rdbMonth.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            'dtFrom = DateAdd(DateInterval.Day, -30, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Month"
        ElseIf rdbDtR.Checked = True Then
            dtFrom = dtpFD.Value
            dtLastProcessed = dtpToD.Value
            Label26.Text = Label26.Text & " for Range of Dates"
        Else
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -1, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Day"
        End If
        sSQL = "select tblEmployee.regID," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',convert(nvarchar (10),tblEmpRegister.atDate,111) AS 'Day',tblEmpRegister.NoLeave as 'Lv Count',convert(nvarchar (8),tblEmpRegister.inTime1,108) as 'In Time',convert(nvarchar (10),tblEmpRegister.outTime1,108) as 'Out Time',tblEmpregister.nrWorkDay as 'Worked Day' FROM tblEmpRegister LEFT OUTER JOIN tblEmployee ON tblEmpRegister.empID=tblEmployee.regID LEFT OUTER JOIN tblLeaveType ON tblEmpRegister.leaveID=tblLeaveType.lvID LEFT OUTER JOIN tblDayType on tblEmpRegister.dayTypeID=tblDayType.typeID WHERE tblDayType.workUnit<>0 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblEmpRegister.atDate BETWEEN '" & Format(dtFrom, strRetDateTimeFormat) & "' AND '" & Format(dtLastProcessed, strRetDateTimeFormat) & "' AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' ) ORDER BY tblEmployee.empno"
        Fk_FillGrid(sSQL, dgvLeaveAllk)
        dgvLeaveAllk.Columns(0).Visible = False
        If dgvLeaveAllk.RowCount > 0 Then
            For k As Integer = 0 To dgvLeaveAllk.Columns.Count - 1
                dgvLeaveAllk.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader

            Next
        End If

        For k2 As Integer = 0 To dgvLeaveAllk.RowCount - 1
            Dim dblN As Double = CDbl(dgvLeaveAllk.Item(7, k2).Value)
            If dblN = 0.5 Then
                For kk As Integer = 0 To dgvLeaveAllk.ColumnCount - 1
                    dgvLeaveAllk.Item(kk, k2).Style.BackColor = Color.Purple
                Next
            ElseIf dblN = 0.0 Then
                For kk As Integer = 0 To dgvLeaveAllk.ColumnCount - 1
                    dgvLeaveAllk.Item(kk, k2).Style.BackColor = Color.RosyBrown
                Next
            End If
        Next
        Label26.Text = Label26.Text & " : " & dgvLeaveAllk.RowCount
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Load Cancel Leave
        strTogle = "C"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmNewLeaveCancel
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()

    End Sub

    Private Sub dgvLeaveAllk_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLeaveAllk.CellDoubleClick
        cmbCurrentYear.Text = intSelectedYear
        If strTogle = "A" Then
            'strKEmployeeID = StrEmployeeID
            StrEmployeeID = Trim(dgvLeaveAllk.CurrentRow.Cells(0).Value)
            dtGlobalDate = CDate(dgvLeaveAllk.CurrentRow.Cells(3).Value)
            If Format(dtGlobalDate, strRetDateTimeFormat) > Format(dtpFrDate.MaxDate, strRetDateTimeFormat) Then
                MessageBox.Show("Selected date is newer date than selected year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            ElseIf Format(dtGlobalDate, strRetDateTimeFormat) < Format(dtpFrDate.MinDate, strRetDateTimeFormat) Then
                MessageBox.Show("Selected date is older date than selected year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If
            Me.ViewLeaveInfo()
            dtpFrDate.Value = dtGlobalDate
            dtpAplLvDate.Value = dtGlobalDate
            'refresh
            lblShLvBalMin.Visible = False
            lblShLvBalQty.Visible = False
            dgvLeaveTake.Rows.Clear()

        ElseIf strTogle = "B" Then
            StrEmployeeID = Trim(dgvLeaveAllk.CurrentRow.Cells(0).Value)
            strKEmployeeID = StrEmployeeID
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmApplyLeavdatrange
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()

        Else
            StrEmployeeID = Trim(dgvLeaveAllk.CurrentRow.Cells(0).Value)
            strKEmployeeID = StrEmployeeID
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmNewLeaveCancel
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If
    End Sub

    Public Function DoGetEmployeeID() As String

        Return StrEmployeeID

    End Function

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Length = 0 Or txtSearch.Text.Length Mod 2 = 1 Then
            If StrStatus = "OnLeave" Then
                btnLeave_Click(sender, e)
            ElseIf StrStatus = "Absent" Then
                btnAbsent_Click(sender, e)
            ElseIf StrStatus = "Halfday" Then
                btnHalfday_Click(sender, e)
            ElseIf StrStatus = "PrLeave" Then
                btnPrLeave_Click(sender, e)
            ElseIf StrStatus = "Cadre" Then
                btnCadre_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtRelID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRelID.TextChanged
        If txtSearch.Text.Length = 0 Or txtSearch.Text.Length Mod 2 = 1 Then
            txtSearch.Text = txtRelID.Text
        End If
    End Sub

    Private Sub rdbDtR_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbDtR.MouseClick
        If rdbDtR.Checked = True Then
            dtpFD.Enabled = True
            dtpToD.Enabled = True
        Else
            dtpFD.Enabled = False
            dtpToD.Enabled = False
        End If
        dtLastProcessed = fk_RetDate("select atnPrcDate FROM tblCompany")
    End Sub

    Private Sub rdbDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDay.Click
        dtLastProcessed = fk_RetDate("select atnPrcDate FROM tblCompany")

        ShowDateLimitForLeaves(1, "Day")
    End Sub

    Private Sub rdbMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbMonth.Click
        dtLastProcessed = fk_RetDate("select atnPrcDate FROM tblCompany")

        ShowDateLimitForLeaves(30, "Month")
    End Sub

    Private Sub rdbWeek_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbWeek.Click
        dtLastProcessed = fk_RetDate("select atnPrcDate FROM tblCompany")

        ShowDateLimitForLeaves(6, "Week")
    End Sub

    Private Sub dtpAplLvDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpAplLvDate.ValueChanged
        dtpFrDate.Value = dtpAplLvDate.Value
    End Sub

    Private Sub btnNormalizk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNormalizk.Click
        Dim dr As DialogResult = MessageBox.Show("Do you really want to rollback system year to previous year ? If you do this process, then you must change current year manually later.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If dr = Windows.Forms.DialogResult.Yes Then
            intExsixted = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE compID='001'")
            If Val(cmbCurrentYear.Text) = intExsixted Then
                cmbCurrentYear.Text = intExsixted - 1
                dtpToD.Value = fk_RetDate("select atnPrcDate FROM tblCompany")
            ElseIf Val(cmbCurrentYear.Text) <> intExsixted Then
                cmbCurrentYear.Text = intExsixted
                dtpToD.Value = fk_RetDate("select DateAdd(yy, -1, atnPrcDate) FROM tblCompany")
            End If
            'If intExsixted <> Val(cmbCurrentYear.Text) Then
            dtpAplLvDate.MaxDate = DateSerial(Val(cmbCurrentYear.Text) + 1, 1, 1)
            dtpAplLvDate.MinDate = DateSerial(Val(cmbCurrentYear.Text) - 1, 12, 31)
            dtpFrDate.MaxDate = DateSerial(Val(cmbCurrentYear.Text) + 1, 1, 1)
            dtpFrDate.MinDate = DateSerial(Val(cmbCurrentYear.Text) - 1, 12, 31)
            sSQL = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Roll back the current year from " & intExsixted & " to " & cmbCurrentYear.Text & " ','" & StrUserID & "',getdate ())" : FK_EQ(sSQL, "E", "", False, True, True)
            intSelectedYear = cmbCurrentYear.Text
        End If
        'End If

    End Sub

    Private Sub cmbMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedValueChanged
        'Dim dr As DialogResult = MessageBox.Show("Do you really want to change the current leave appling month", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        'If dr = Windows.Forms.DialogResult.Yes Then
        If cmbMonth.Text <> "" Then
            intSelectedMonth = Val(cmbMonth.Text)
            'dtpFrDate.Value = DateSerial(dtpFrDate.Value.Year, intSelectedMonth, 1)
            ViewLeaveInfo()
            dgvLeaveTake.Rows.Clear()
        End If
        'End If
    End Sub

    Private Sub btnShortLeav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShortLeav.Click
        StrStatus = "ShLv"

        Dim dtFrom As Date
        Label26.Text = "Total Employee List"
        If rdbWeek.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            'dtFrom = DateAdd(DateInterval.Day, -6, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Week"
        ElseIf rdbMonth.Checked = True Then
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -30, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Month"
        ElseIf rdbDtR.Checked = True Then
            dtFrom = dtpFD.Value
            dtLastProcessed = dtpToD.Value
            Label26.Text = Label26.Text & " for Range of Dates"
        Else
            dtFrom = DateAdd(DateInterval.Day, -LeaveShowdays, dtLastProcessed)
            ' dtFrom = DateAdd(DateInterval.Day, -1, dtLastProcessed)
            Label26.Text = Label26.Text & " for Last Day"
        End If
        sSQL = "CREATE TABLE #T (RegID NVARCHAR (6),EpfNO NVARCHAR (6),EmployeeName NVARCHAR (256),atDate DATETIME,LateMins NUMERIC (18,0),shCode NVARCHAR (5),inTime DATETIME,outTime DATETIME,nrWorkDay NUMERIC (18,2),earlyMins NUMERIC (18,0),DueMins NUMERIC (18,0)); INSERT INTO #T select tblEmployee.regID," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',convert(nvarchar (10),tblEmpRegister.atDate,111) AS 'Day',CASE WHEN tblEmpRegister.isLate=0 THEN 0 ELSE tblEmpRegister.LateMins END as 'Late Mins','LTE',convert(nvarchar (8),tblEmpRegister.inTime1,108) as 'In Time',convert(nvarchar (10),tblEmpRegister.outTime1,108) as 'Out Time',tblEmpregister.nrWorkDay as 'Worked Day',CASE WHEN tblEmpRegister.isEarly =0 THEN 0 ELSE tblEmpregister.EarlyMins END AS 'EarlyMins',tblEmpregister.divMin FROM tblEmpRegister LEFT OUTER JOIN tblEmployee ON tblEmpRegister.empID=tblEmployee.regID LEFT OUTER JOIN tblLeaveType ON tblEmpRegister.leaveID=tblLeaveType.lvID LEFT OUTER JOIN tblDayType on tblEmpRegister.dayTypeID=tblDayType.typeID WHERE tblDayType.workUnit<>0 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblEmpRegister.atDate BETWEEN '" & Format(dtFrom, strRetDateTimeFormat) & "' AND '" & Format(dtLastProcessed, strRetDateTimeFormat) & "' AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' ) ORDER BY tblEmployee.empno " & _
        " UPDATE #T SET #T.LateMins=#T.LateMins+#T.earlyMins ,#T.shCode='ER|LT' WHERE #T.earlyMins<>0 and #T.LateMins<>0; UPDATE #T SET #T.LateMins=#T.earlyMins ,#T.shCode='ERL' WHERE #T.earlyMins<>0 and #T.LateMins=0; UPDATE #T SET #T.LateMins=#T.DueMins ,#T.shCode='DUE' WHERE #T.DueMins<>0; DELETE FROM #T WHERE #T.LateMins=0; SELECT RegID,EpfNo AS 'Emp No',EmployeeName AS 'Employee Name',atDate AS 'Date',LateMins AS 'Mins',shCode AS 'Code',convert(nvarchar (8),inTime,108) AS 'In Time',convert(nvarchar (8),outTime,108) AS 'Out Time',nrWorkDay AS 'Wrk Day' FROM #T"
        Fk_FillGrid(sSQL, dgvLeaveAllk)
        dgvLeaveAllk.Columns(0).Visible = False
        If dgvLeaveAllk.RowCount > 0 Then
            For k As Integer = 0 To dgvLeaveAllk.Columns.Count - 1
                dgvLeaveAllk.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader

            Next
        End If

        For k2 As Integer = 0 To dgvLeaveAllk.RowCount - 1
            Dim dblN As Double = CDbl(dgvLeaveAllk.Item(8, k2).Value)
            If dblN = 0.5 Then
                For kk As Integer = 0 To dgvLeaveAllk.ColumnCount - 1
                    dgvLeaveAllk.Item(kk, k2).Style.BackColor = Color.Purple
                Next
            ElseIf dblN = 0.0 Then
                For kk As Integer = 0 To dgvLeaveAllk.ColumnCount - 1
                    dgvLeaveAllk.Item(kk, k2).Style.BackColor = Color.RosyBrown
                Next
            End If
        Next
        Label26.Text = Label26.Text & " : " & dgvLeaveAllk.RowCount
    End Sub


  
   
End Class