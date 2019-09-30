
Imports System.Data.SqlClient

Public Class frmApplyLeavdatrange
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

    Private Sub frmApplyLeav_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label16)
        ControlHandlers(Me)
        If strKEmployeeID <> "" Then
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
            sSQL = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & strKEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID"
            ''sSQL = "SELECT LeaveID,lvName,EntLeave,TknLeave,BalLeave FROM tblTmpLeave Order By LeaveID"
            Load_InformationtoGrid(sSQL, dgvLvHistory, 5)
            clr_Grid(dgvLvHistory)

            Dim sqlLv As String = "select tblLeaveTRD.Lvdate,tblLeaveTRD.LvType,tblLeaveType.LvDesc,tblLeaveTRD.NoLeave,tblLeaveTRH.AuthLeave FROM tblLeaveTRD " & _
                " INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqiD AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID" & _
                " INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.lvID WHERE tblLeaveTRH.EmpID = '" & strKEmployeeID & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.cYear = " & intCurrentYear & " Order By tblLeaveTRD.LvDate"
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
            dtpFrDate.Value = dtGlobalDate
            dtpToDate.Value = dtGlobalDate
        Else
            cmdRefresh_Click(sender, e)
        End If
    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor
    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)
        dgvLvHistory.Rows.Clear()
        dgvLvK.Rows.Clear()

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
            lvMinDate = DateSerial(crYear, crMonth, 1) 'IIf(IsDBNull(drProf.Item("stDate")), DateSerial(1900, 1, 1), drProf.Item("stDate"))
            dtPrStartDate = DateSerial(crYear, crMonth, 1)
            dtPrEndDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(crYear, crMonth, 1)))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim iR As Integer = fk_sqlDbl("SELECT NoAplLv FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        Dim StrAplLeaveID = fk_CreateSerial(5, iR)
        lblRQID.Text = StrAplLeaveID

        'Load Leave TYpes 
        ListCombo(ComboBox1, "select * From tblLeaveType Order By LvID", "lvDesc")

        StrSvStatus = "S"
        txtCode.Focus()
        txtFrDtype.Text = dtpFrDate.Value.DayOfWeek.ToString
        txttoDType.Text = dtpToDate.Value.DayOfWeek.ToString
        dgvSpLv.Rows.Clear()
        dgvEmp.Rows.Clear()

        dgvLeaveTake.Rows.Clear()

    End Sub

    Public Sub leave_checks(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()

        Dim sqlQ As String = "select tblEmpLeaveD.EmpID,tblEmpLeaveD.CompID,tblEmpLeaveD.cYear,tblEmpLeaveD.LeaveID, " & _
       " tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave,tblEmpLeaveD.Status,tblLeaveType.EffDay,tblLeaveType.lvmode,tblLeaveType.AllowOthLv,tblLeaveType.ChkLimit,tblLvAplMeth.mCount From tblEmpLeaveD " & _
       " INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID  INNER JOIN tblLvAplMeth ON tblLeaveType.LvMode = tblLvAplMeth.mID WHERE tblLeaveType.LvDesc = '" & ComboBox1.Text & "' AND " & _
       " tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.CompID = '" & StrCompID & "' AND cYear = " & intCurrentYear & ""
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
                    dblTknLv = fk_sqlDbl("SELECT Sum(NoLeave) FROM tblLeaveTRD WHERE LvType = '" & StrLvID & "' AND LvDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND EmpID = '" & StrEmployeeID & "'")
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
        'txtAplLv.Text = fk_sqlDbl("SELECT Sum(WorkingType) FROM tblCalendar WHERE [Date] Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")
    End Sub



    Private Sub dtpFrDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrDate.ValueChanged, dtpFrtime.ValueChanged, dtpToTime.ValueChanged
        ''Get the Selected Day Shift In time for the selected Employee
        'dtpFrtime.Text = fk_RetDate("SELECT tblSetShiftH.InTime FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE tblEmpRegister.AtDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'")
        'dtpToDate.MinDate = dtpFrDate.Value
        'txtAplLv.Text = fk_sqlDbl("SELECT Sum(tblDayType.WorkUnit) FROM tblDayType INNER JOIN tblEmpRegister ON tblEmpRegister.DayTypeID = tblDayType.TypeID " & _
        '" WHERE tblEmpRegister.AtDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.EmpID = '" & txtCode.Text & "'")
        txtFrDtype.Text = dtpFrDate.Value.DayOfWeek.ToString

        'Get the Attendance status of the selected date

    End Sub

    'Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged, dtpToDate.Leave
    '    'txtAplLv.Text = calc_Leave(dtpFrDate.Value, dtpToDate.Value)
    '    'Set the Shift Out Time as the Selected Date Shift OutDate
    '    dtpToTime.Text = fk_RetDate("SELECT tblSetShiftH.OutTime FROM tblSetShiftH Inner Join tblEmpRegister ON  tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE  tblEmpRegister.AtDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")

    '    txtAplLv.Text = fk_sqlDbl("SELECT Sum(tblDayType.WorkUnit) FROM tblDayType INNER JOIN tblEmpRegister ON tblEmpRegister.DayTypeID = tblDayType.TypeID " & _
    '    " WHERE tblEmpRegister.AtDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.EmpID = '" & txtCode.Text & "'")

    '    txttoDType.Text = dtpToDate.Value.DayOfWeek.ToString


    '    'Fil_Leave()


    'End Sub

    Public Sub Fil_Leave()
        Dim sqlQ As String
        Dim dblTotLeave As Double
        'CASE tblEmpRegister.IsLeave WHEN 1 THEN tblDayType.WorkUnit -(tblEmpRegister.NoLeave+tblEmpRegister.NRWorkDay) ELSE tblEmpRegister.NoLeave END
        sqlQ = "SELECT tblEmpRegister.AtDate,tblSetShiftH.ShiftName,tblDayType.WorkUnit - (tblEmpRegister.NRWorkDay+tblEmpRegister.NoLeave),tblDayType.WorkUnit - (tblEmpRegister.NRWorkDay+tblEmpRegister.NoLeave),tblEmpRegister.IsLeave,tblEmpRegister.AntStatus,tblEmpRegister.NoLeave,tblEmpRegister.IsLate,tblEmpRegister.IsEarly FROM tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' Order By tblEmpRegister.AtDate"
        'sqlQ = "SELECT tblEmpRegister.AtDate,tblSetShiftH.ShiftName,CASE WHEN tblDayType.WorkUnit-tblEmpRegister.NoLeave < 0 THEN 0 Else tblDayType.WorkUnit-tblEmpRegister.NoLeave END,CASE WHEN tblDayType.WorkUnit-tblEmpRegister.NoLeave < 0 THEN 0 ELSE tblDayType.WorkUnit-tblEmpRegister.NoLeave END,tblEmpRegister.IsLeave,tblEmpRegister.AntStatus,tblEmpRegister.LeaveID,tblEmpRegister.IsLate,tblEmpRegister.IsEarly FROM tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' Order By tblEmpRegister.AtDate"
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
    '    fk_Return_MultyString("SELECT cYear,cMonth,StDate,EdDate FROM tblPrfDays WHERE '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' Between stDate AND EdDate", 4)
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
    '    Dim bolAtn As Boolean = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE antStatus = 1  AND atDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID = '" & StrEmployeeID & "'")
    '    If bolAtn = True Then
    '        Dim bolLate As Boolean = False
    '        bolLate = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE isLate = 1 AND atDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID = '" & StrEmployeeID & "'")
    '        If bolLate = True Then bolAtn = False Else bolAtn = True

    '        If bolLate = False Then
    '            Dim bolEarly As Boolean = False
    '            bolEarly = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE isEarly = 1 AND atDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID = '" & StrEmployeeID & "'")
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
    '    " WHERE tblEmpRegister.empID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
    '    Dim bolFollow As Boolean = True
    '    ' bolFollow = fk_CheckEx ("SELECT * FROM tblEmpRegister WHERE AtDate Between '" & format(dtpFrDate.Value ,"yyyyMMdd") & "' AND '" & Format(dtpToDate.Value ,"yyyyMMdd") & "' AND AntStatus = 1
    '    Load_InformationtoGrid(sqlQ, dgvLv, 4)

    '    Dim iWorkHr As Double
    '    '= fk_sqlDbl("SELECT WorkingType FROM tblCalendar WHERE [Date] = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'")
    '    '        If iWorkHr = 0 Then
    '    '            MsgBox("Can't Select Non working date for the From Date", MsgBoxStyle.Critical)
    '    '            Exit Sub
    '    '        End If

    '    iWorkHr = fk_sqlDbl("select tblDayType.workUnit from tblDayType INNER JOIN tblEmpregister ON tblDayType.TypeID = tblEmpRegister.DayTypeID WHERE tblEmpRegister.AtDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.EmpID = '" & StrEmployeeID & "'")
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
        Load_InformationtoGrid("select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave,(tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID", dgvLvHistory, 5)


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

    Private Sub dgvLeaveTake_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvLeaveTake.CellMouseDoubleClick
        dgvLeaveTake.Rows.Remove(dgvLeaveTake.CurrentRow)
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

    Private Sub dgvEmp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmp.CellContentClick

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
    Public Function fk_NewAddLeave(ByVal dtStart As Date, ByVal dtEnd As Date) As Boolean
        Dim dblEffDays As Double = 0 : Dim intChkLimit As Integer = 0 : Dim intAlOther As Integer = 0 : Dim intAlwFuture As Integer = 0
        Dim intChkLateErly As Integer = 0 : Dim intLEmins As Integer = 0 : Dim intMonthC As Integer = 0
        Dim intLvLateMins As Integer = 0 : Dim intLvEarlyMins As Integer = 0 : Dim intAtnSt As Integer = 0
        Dim StrLEStatus As String = "" : Dim intLStatus As Integer = 0 : Dim intEStatus As Integer = 0
        '01. Check the basic conditions
        Dim sqlView As String = "select tblLeaveType.EffDay,tblLeaveType.ChkLimit,tblLeaveType.AllowOthLv,tblLeaveType.AllowFutureLv,tblLeaveType.ChkLateEarly,tblLeaveType.LateEarlyMin,tblLvAplMeth.mCount FROM tblLeaveType,tblLvAplMeth WHERE tblLeaveType.LvMode = tblLvAplMeth.mID AND tblLeaveType.LvID = '" & StrLvID & "'"
        fk_Return_MultyString(sqlView, 7)
        dblEffDays = fk_ReadGRID(0) : intChkLimit = fk_ReadGRID(1) : intAlOther = fk_ReadGRID(2) : intAlwFuture = fk_ReadGRID(3)
        intChkLateErly = fk_ReadGRID(4) : intLEmins = fk_ReadGRID(5) : intMonthC = fk_ReadGRID(6)

        If StrLvID = "" Then MsgBox("Please Select the Leave Type") : Exit Function
        If dgvLeaveTake.RowCount > 0 Then MsgBox("You are not allowing to add two date ranges") : Exit Function
        'Check Existing Applied Leave between the selected date range don't allow
        Dim bolExLeave As Boolean = False
        bolExLeave = fk_CheckEx("SELECT tblLeaveTrD.* FRoM tblLeaveTRD,tblLeaveTRH WHERE tblLeaveTRD.RqID = tblLeaveTRH.RqID AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID AND tblLeaveTRD.LvDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND tblLeaveTRD.Status = 0 AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.EmpID  = '" & StrEmployeeID & "'")
        If bolExLeave = True Then MsgBox("System found Applied Leave Between the Leave Selected Period") : Exit Function
        'Get the selected Date Range Total Leave to Check the Leave availablity
        Dim dblAvblLv As Double = 0
        Dim dblNewTake As Double = 0 : dblNewTake = fk_sqlDbl("SELECT Sum(tblDayType.WorkUnit) FROM tblEmpRegister,tblDayType WHERE tblEmpRegister.DayTYpeID = tblDayType.TypeID AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate BEtween  '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'")
        dblAvblLv = CDbl(txtLvsBalance.Text) - dblNewTake
        If intChkLimit = 1 Then
            If dblAvblLv < 0 Then MsgBox("You don't have enough leave balance to process with leave", MsgBoxStyle.Critical) : Exit Function
        End If
        Dim intDayDef As Integer = DateDiff(DateInterval.Day, dtpAplLvDate.Value, dtpFrDate.Value)
        If intAlwFuture = 0 Then If intDayDef < 0 Then MsgBox("This leave type is not allowing you to apply future Leave", MsgBoxStyle.Information) : Exit Function 'System is checking the leave apply approval for the future

        sqlView = "select LateMins,EarlyMins,AntStatus from tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'"
        intLvLateMins = fk_ReadGRID(0) : intLvEarlyMins = fk_ReadGRID(1) : intAtnSt = fk_ReadGRID(2)
        If intLvLateMins > 0 Then intLStatus = 1 Else intLStatus = 0 : If intLvEarlyMins > 0 Then intEStatus = 1 Else intEStatus = 0
        StrLEStatus = intLStatus.ToString & "|" & intEStatus.ToString

        If StrLEStatus = "1|1" Then
            If CDbl(cmbLvNew.Text) < 1 Then
                MsgBox("System is having late & early both", MsgBoxStyle.Critical) : Exit Function
            End If
        End If
        'Don't Allow Leave If employee's perfect attendance record 
        Dim bolAll As Boolean = False
        bolAll = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE AntStatus = 1 AND isLate = 0 AND isLate = 0 AND EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'")
        If bolAll = True Then
            If MsgBox("This employee found attendance record for the selected date, Do you want to Apply Leave ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
        End If
        Dim sqlQRY As String = ""
        sqlQRY = "SELECT '" & StrLvID & "','" & ComboBox1.Text & "',tblEmpRegister.AtDate,tblDayType.WorkUnit,DateName(dw,tblEmpRegister.AtDate), tblEmpRegister.AtDate,tblEmpRegister.isLate,tblEmpRegister.IsEarly,'' from tblEmpRegister,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' And tblDayType.WorkUnit <> 0 AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' Order By tblEmpRegister.AtDate"

        Load_InformationtoGrid(sqlQRY, dgvLeaveTake, 9) : clr_Grid(dgvLeaveTake)
        txtAplLv.Text = dblNewTake
    End Function

    Public Sub _OldLeaveProcess()
        If Trim(cmbLvNew.Text) = "" Or Trim(cmbLvNew.Text) = "0" Then MessageBox.Show("Please select leave quantity, wheather full day or half day", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        Dim dblEffDays As Double = 0 : Dim intChkLimit As Integer = 0 : Dim intAlOther As Integer = 0 : Dim intAlwFuture As Integer = 0
        Dim intChkLateErly As Integer = 0 : Dim intLEmins As Integer = 0 : Dim intMonthC As Integer = 0
        Dim intLvLateMins As Integer = 0 : Dim intLvEarlyMins As Integer = 0 : Dim intAtnSt As Integer = 0
        Dim StrLEStatus As String = "" : Dim intLStatus As Integer = 0 : Dim intEStatus As Integer = 0
        '01. Check the basic conditions
        Dim sqlView As String = "select tblLeaveType.EffDay,tblLeaveType.ChkLimit,tblLeaveType.AllowOthLv,tblLeaveType.AllowFutureLv,tblLeaveType.ChkLateEarly,tblLeaveType.LateEarlyMin,tblLvAplMeth.mCount FROM tblLeaveType,tblLvAplMeth WHERE tblLeaveType.LvMode = tblLvAplMeth.mID AND tblLeaveType.LvID = '" & StrLvID & "'"
        fk_Return_MultyString(sqlView, 7)
        dblEffDays = fk_ReadGRID(0) : intChkLimit = fk_ReadGRID(1) : intAlOther = fk_ReadGRID(2) : intAlwFuture = fk_ReadGRID(3)
        intChkLateErly = fk_ReadGRID(4) : intLEmins = fk_ReadGRID(5) : intMonthC = fk_ReadGRID(6)

        If StrLvID = "" Then MsgBox("Please select the leave type", MsgBoxStyle.Information) : Exit Sub
        '01.2 Check for the deferant leave type
        Dim bolLeaveType As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 0, StrLvID, "F")
        If bolLeaveType = True Then MsgBox("You can't process with deferant leave type in single leave application", MsgBoxStyle.Information) : Exit Sub
        '01.3 Check Same Date found in the grid 
        Dim bolSaveDate As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 2, Format(dtpFrDate.Value, "dd/MM/yyyy"), "T")
        If bolSaveDate = True Then MsgBox("Duplicate Leave Date", MsgBoxStyle.Critical) : Exit Sub
        '01.4 Get the Applied leave count in the grid and match with balance leave 
        Dim dblApl As Double = fk_GridSum(dgvLeaveTake, 3) : Dim dblNewTake As Double = dblApl + CDbl(cmbLvNew.Text) : Dim dblAvblLv As Double = 0
        dblAvblLv = CDbl(txtLvsBalance.Text) - dblNewTake
        If intChkLimit = 1 Then ' If system is checking the leave limit this function should 
            If dblAvblLv < 0 Then MsgBox("You don't have enough leave balance to process with leave", MsgBoxStyle.Critical) : Exit Sub
        End If

        Dim intDayDef As Integer = DateDiff(DateInterval.Day, dtpAplLvDate.Value, dtpFrDate.Value)
        If intAlwFuture = 0 Then If intDayDef < 0 Then MsgBox("This leave type is not allowing you to apply future Leave", MsgBoxStyle.Information) : Exit Sub 'System is checking the leave apply approval for the future
        'Get the Late Early Mins for the select date from Employee Register
        sqlView = "select LateMins,EarlyMins,AntStatus from tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'"
        intLvLateMins = fk_ReadGRID(0) : intLvEarlyMins = fk_ReadGRID(1) : intAtnSt = fk_ReadGRID(2)
        If intLvLateMins > 0 Then intLStatus = 1 Else intLStatus = 0 : If intLvEarlyMins > 0 Then intEStatus = 1 Else intEStatus = 0
        StrLEStatus = intLStatus.ToString & "|" & intEStatus.ToString

        If StrLEStatus = "1|1" Then
            If CDbl(cmbLvNew.Text) < 1 Then
                MsgBox("System is having late & early both", MsgBoxStyle.Critical) : Exit Sub
            End If
        End If

        '01.5 
        sSQL = "SELECT Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRD,tblLeaveTRH WHERE (tblLeaveTRD.EmpID = tblLeaveTRH.EmpID AND tblLeaveTRD.RqID = tblLeaveTRH.RqID) AND  tblLeaveTRD.EmpID = '" & StrEmployeeID & "' AND tblLeaveTRD.LvDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND tblLeaveTRH.Status = 0"
        Dim dblAplLvQ As Double = fk_sqlDbl(sSQL)
        If 1 - (dblAplLvQ + CDbl(cmbLvNew.Text)) < 0 Then MsgBox("You have Already applied leave for same date", MsgBoxStyle.Critical) : Exit Sub

        'Don't Allow Leave If employee's perfect attendance record 
        Dim bolAll As Boolean = False
        bolAll = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE AntStatus = 1 AND isLate = 0 AND isLate = 0 AND EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtpFrDate.Value, "yyyyMMdd") & "'")
        If bolAll = True Then
            If MsgBox("This employee found perfect attendance record for the selected date, Do you want to Apply Leave ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If
        Dim intAL As Integer = 0 : Dim intAE As Integer = 0
        If intLStatus = 1 Then intAL = 0 Else intAL = intLStatus
        If intEStatus = 1 Then intAE = 0 Else intAE = intEStatus

        With dgvLeaveTake
            .Rows.Add(StrLvID, ComboBox1.Text, Format(dtpFrDate.Value, "dd/MM/yyyy"), cmbLvNew.Text, txtFrDtype.Text, dtpFrDate.Value, intAL.ToString, intAE.ToString, StrLEStatus)
        End With
        txtAplLv.Text = fk_GridSum(dgvLeaveTake, 3)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        fk_NewAddLeave(dtpFrDate.Value, dtptoLvDate.Value)

    End Sub

    Public Sub Apply_Lv_Old()
        'Check Leave availablity
        If StrLvID = "" Then MsgBox("Please select leave type", MsgBoxStyle.Information) : Exit Sub
        Dim dblApl As Double = fk_GridSum(dgvLeaveTake, 3) : Dim dblNewTake As Double = dblApl + CDbl(cmbLvNew.Text) : Dim dblAvblLv As Double = 0
        dblAvblLv = CDbl(txtLvsBalance.Text) - dblNewTake
        If dblAvblLv < 0 Then MsgBox("You don't have enough leave balance to process with leave", MsgBoxStyle.Critical) : Exit Sub
        'Check Same Date found in the grid 
        Dim bolSaveDate As Boolean = fk_RetGridDuplicate(dgvLeaveTake, 2, Format(dtpFrDate.Value, "dd/MM/yyyy"), "T")
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
        If UP("Leave", "Apply leave") = False Then Exit Sub
        txtAplLv.Text = fk_GridSum(dgvLeaveTake, 3)
        If StrLvID = "" Then MsgBox("No Leave Type ", MsgBoxStyle.Information) : Exit Sub
        If CDbl(txtAplLv.Text) <= 0 Then MsgBox("No Applied Leave", MsgBoxStyle.Information) : Exit Sub
        If dgvLeaveTake.RowCount < 0 Then MsgBox("No Applied Leave", MsgBoxStyle.Information) : Exit Sub
        If txtRemark.Text = "" Then MsgBox("Please type remark", MsgBoxStyle.Information) : txtRemark.Focus() : Exit Sub

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
        " AuthLeave,Remark,lvMin) VALUES ('" & StrLeaveID & "','" & StrEmployeeID & "','" & StrCompID & "','" & Format(dtpAplLvDate.Value, "yyyyMMdd") & "'," & Year(dtpAplLvDate.Value) & ", " & _
        " " & Month(dtpAplLvDate.Value) & ", '" & StrLvID & "'," & CDbl(txtAplLv.Text) & ",'','','','','','" & StrUserID.Substring(0, 3) & "' ,''," & chkApprovLv.CheckState & ",0,0," & chkApprovLv.CheckState & ",'" & txtRemark.Text & "',0)"
        'Save Leave Details 
        Dim dtLeaveDate As Date
        With dgvLeaveTake
            For i As Integer = 0 To .RowCount - 1
                sqlQRY = sqlQRY & " INSERT INTO tblLeaveTRD (RqID,EmpID,LvDate,LvType,NoLeave,Status,AuthLeave,lvMin) VALUES ('" & StrLeaveID & "', " & _
               " '" & StrEmployeeID & "','" & Format(CDate(.Item(5, i).Value), "yyyyMMdd") & "','" & .Item(0, i).Value & "'," & CDbl(.Item(3, i).Value) & ", 0, " & chkApprovLv.CheckState & ",0)"
                dtLeaveDate = CDate(.Item(5, i).Value)
                sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET IsLate = " & CInt(.Item(6, i).Value) & ", isEarly = " & CInt(.Item(7, i).Value) & ",LEStatus = '" & .Item(8, i).Value & "'  WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtLeaveDate, "yyyyMMdd") & "'"
                If intEffDay = 0 Then
                    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET nrWorkDay=1,AutoLeaveNo=0 WHERE nrWorkDay<>0 AND EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtLeaveDate, "yyyyMMdd") & "'"
                End If
            Next
        End With
        'Update Employee Leave Taken 
        sqlQRY = sqlQRY & " UPDATE tblEmpLeaveD SET TakenLeave = TakenLeave + " & CDbl(txtAplLv.Text) & " WHERE EmpID = '" & StrEmployeeID & "' AND LeaveID = '" & StrLvID & "' AND cYear = " & intCurrentYear & ""
        sqlQRY = sqlQRY & " UPDATE tblCompany SET NoAplLv = NoAplLv + 1 WHERE CompID = '" & StrCompID & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdBrsC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
        "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblEmployee.RegID"

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
        'Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")

        'Dim sqlTag1 As String : If IsEpf = 0 Then sqlTag1 = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag1 = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag1 = "tblEmployee.EnrolNo" Else sqlTag1 = "tblEmployee.EmpNo"

        ViewLeave2()

    End Sub

    Public Sub ViewLeave2()
        'View Employee information using the EMployee
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "select tblEmployee.RegID," & sqlTag1 & " as 'RelID', tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno " & _
        " FROM tblEmployee LEFT OUTER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                txtempName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))
                txtRemark.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
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
        sSQL = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID"
        ''sSQL = "SELECT LeaveID,lvName,EntLeave,TknLeave,BalLeave FROM tblTmpLeave Order By LeaveID"
        Load_InformationtoGrid(sSQL, dgvLvHistory, 5)
        clr_Grid(dgvLvHistory)

        Dim sqlLv As String = "select tblLeaveTRD.Lvdate,tblLeaveTRD.LvType,tblLeaveType.LvDesc,tblLeaveTRD.NoLeave,tblLeaveTRH.AuthLeave FROM tblLeaveTRD " & _
            " INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqiD AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID" & _
            " INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.lvID WHERE tblLeaveTRH.EmpID = '" & StrEmployeeID & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.cYear = " & intCurrentYear & " Order By tblLeaveTRD.LvDate"
        Load_InformationtoGrid(sqlLv, dgvLvK, 5)
        ' clr_Grid(dgvLvK)
        With dgvLvK
            Dim intPP As Integer = 0

            For Each row As DataGridViewRow In .Rows
                intPP = .Item(4, row.Index).Value

                If intPP = 0 Then row.DefaultCellStyle.BackColor = lblPost.BackColor Else row.DefaultCellStyle.BackColor = lblPre.BackColor
            Next
        End With
        dtpFrDate.Value = dtGlobalDate
        dtpAplLvDate.Value = dtGlobalDate
        dtptoLvDate.Value = DateAdd(DateInterval.Day, 1, dtGlobalDate)
        ComboBox1.Focus()
    End Sub

    Private Sub dgvLvHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLvHistory.Click
        ComboBox1.Text = Trim(dgvLvHistory.CurrentRow.Cells(1).Value)
        leave_checks(dtPrStartDate, dtPrEndDate)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        LoadForm(New frmNewLeaveCancel)
    End Sub

End Class