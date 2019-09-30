Imports System.Data.SqlClient

Public Class frmAttnProcess

    Dim maxVal As Integer = 0
    Dim minVal As Integer = 0
    Dim IntVal As Integer = 0
    Dim dblLateMins As Double = 0 ' fk_sqlDbl("SELECT LateMin FROM tblCompany WHERE compID = '" & StrCompID & "'")
    Dim dblOTRound As Double = 0
    Dim dblMinOT As Double = 0
    Dim intOTRndOption As Integer = 0
    Dim cYear As Integer
    Dim cMonth As Integer

    Private Sub frmAttnProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)

       
        'Update Time to tTime
        'Open Company Table 
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlQRY As String = "SELECT * FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlQRY, cnOpn)
            Dim drOPn As SqlDataReader = cmOpn.ExecuteReader
            If drOPn.Read = True Then
                dblLateMins = IIf(IsDBNull(drOPn.Item("Latemin")), 0, drOPn.Item("Latemin"))
                dblOTRound = IIf(IsDBNull(drOPn.Item("OTRound")), 0, drOPn.Item("OTRound"))
                dblMinOT = IIf(IsDBNull(drOPn.Item("MinHrsOT")), 0, drOPn.Item("MinHrsOT"))
                intOTRndOption = IIf(IsDBNull(drOPn.Item("OTRndOption")), 0, drOPn.Item("OTRndOption"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try

        Dim dtLastDate As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        sSQL = "SELECT Max(CDate) FROM tblDiMachine WHERE cDate >= '" & Format(dtLastDate, strRetDateTimeFormat) & "'"
        Dim dtMaxDate As Date = fk_RetDate(sSQL)
        dtpLRDate.Value = dtLastDate
        dtpMaxDate.Value = dtMaxDate

        txtlast.Text = Format(dtLastDate, "dd/MMM/yyyy")
        txtCurrent.Text = Format(dtMaxDate, "dd/MMM/yyyy")

        cYear = Year(dtWorkingDate)
        cMonth = Month(dtWorkingDate)

        cmdYear.Text = cYear.ToString
        cmdMonth.Text = MonthName(cMonth)

    End Sub

    Public Sub Exe_Qry(ByVal sqlQRY As String)
        Dim cnExe As New SqlConnection(sqlConString)
        cnExe.Open()
        Dim cmExe As New SqlCommand(sqlQRY, cnExe)

        cmExe.ExecuteNonQuery()

    End Sub

    Public Function fk_NextMonth(ByVal cMnth As Integer) As String
        Dim StrRt As String = ""

        If cMnth = 12 Then
            cMnth = 0
        End If
        Dim Res As Integer

        Try
            Res = cMnth + 1
            StrRt = MonthName(Res)
        Catch ex As Exception

        End Try

        Return StrRt
    End Function

    Public Function fk_PrvMonth(ByVal cMnth As Integer) As String
        Dim StrRt As String = ""
        If cMnth = 1 Then
            cMnth = 13
        End If
        Dim Res As Integer
        Try
            Res = cMnth - 1
            StrRt = MonthName(Res)
        Catch ex As Exception

        End Try

        Return StrRt

    End Function

    Private Function fk_NextYear(ByVal cYr As Integer) As Integer
        Dim Res As Integer
        Try
            Res = cYr + 1
        Catch ex As Exception

        End Try
        Return Res
    End Function

    Private Function fk_PrvYear(ByVal cYr As Integer) As Integer
        Dim Res As Integer
        Try
            Res = cYr - 1
        Catch ex As Exception

        End Try
        Return Res
    End Function

    Private Function fk_RetMonthNumber(ByVal StrMName As String) As Integer
        Dim Res As Integer
        Select Case StrMName
            Case "January"
                Res = 1
            Case "February"
                Res = 2
            Case "March"
                Res = 3
            Case "April"
                Res = 4
            Case "May"
                Res = 5
            Case "June"
                Res = 6
            Case "July"
                Res = 7
            Case "August"
                Res = 8
            Case "September"
                Res = 9
            Case "October"
                Res = 10
            Case "November"
                Res = 11
            Case "December"
                Res = 12
        End Select

        Return Res
    End Function

    Private Function fk_RetMonthName(ByVal intMNo As Integer) As String
        Dim StrRes As String
        Select Case intMNo
            Case 1

            Case 2

            Case 3

            Case 4

            Case 5

            Case 6

            Case 7

            Case 8

            Case 9

            Case 10

            Case 11

            Case 12

        End Select
    End Function


    Private Sub cmdYNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYNext.Click
        cmdYear.Text = fk_NextYear(CInt(cmdYear.Text))

    End Sub

    Private Sub cmdyPrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdyPrv.Click
        cmdYear.Text = fk_PrvYear(CInt(cmdYear.Text))
    End Sub

    Private Sub cmdmNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmNext.Click
        Dim iM As Integer = fk_RetMonthNumber(cmdMonth.Text)
        cmdMonth.Text = fk_NextMonth(iM)

    End Sub

    Private Sub cmdmPrv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmPrv.Click
        Dim iM As Integer = fk_RetMonthNumber(cmdMonth.Text)

        cmdMonth.Text = fk_PrvMonth(iM)
    End Sub

    '0114821688

    Private Sub cmdProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcess.Click
        'Date : 25/7/2012
        Dim sqlQRY1 As String = ""
        sqlQRY1 = " update tblEmpRegister SET tblEmpRegister.sInTime = tblSetShiftH.InTime,tblEmpRegister.sOutTime = tblSetShiftH.OutTime," & _
          " tblEmpRegister.OutDate = CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate Else DateAdd(day,1,tblEmpRegister.atDate) END," & _
          " tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.ClockIn, " & _
          " tblEmpRegister.ClockOut = CASE tblEmpRegister.OTApved WHEN 0 THEN CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate Else DateAdd(day,1,tblEmpRegister.atDate)+tblSetshiftH.ClockOut END Else tblEmpRegister.ClockOut END  from tblSetShiftH " & _
          " INNER JOIN tblEmpRegister ON tblSetShiftH.ShiftID = tblEmpRegister.ShiftID WHERE tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
        FK_EQ(sqlQRY1, "S", "", False, False, False)

        Dim atTmpMax As Double = fk_sqlDbl("SELECT Count(*) FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year (AtDate) = " & cYear & "")
        pgbPrc.Minimum = 0
        pgbPrc.Value = 0
        cYear = CInt(cmdYear.Text)
        cMonth = fk_RetMonthNumber(cmdMonth.Text)
        'Check the Calendar first
        Dim bolExDate As Boolean = fk_CheckEx("SELECT * FROM tblCalendar WHERE cYear = " & cYear & " AND cMonth = " & cMonth & "")

        If bolExDate = False Then
            MsgBox("Calendar Has not generated, Please generate the Calendar Before the Process !!!", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim cnExe As New SqlConnection(sqlConString)
        cnExe.Open()
        Dim cmExe As SqlCommand
        'Clear the Update Status 
        cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 0", cnExe)
        cmExe.ExecuteNonQuery()


        Dim StrShiftID As String

        Dim dtmealStat As Date
        Dim dtMealClose As Date
        Dim intHasMeal As Integer

        Dim dtLastProcess As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        Dim dgvNight As DataGridView
        dgvNight = New DataGridView
        With dgvNight
            .Columns.Add("EmpID", "Employee ID")
            .Columns.Add("AtDate", "Attn Date")
            .Columns.Add("ChkDate", "CheckDate")
            .Columns.Add("ChkTime", "Check Time")
            .Columns.Add("INOut", "In Out")
            .Columns.Add("ShiftMode", "Shift Mode")
            .Columns.Add("ShftID", "Shift ID")
            .Columns.Add("ClcIn", "Clock In")
            .Columns.Add("ClcOut", "Clock Out")
        End With

        Dim dgvSetNight As DataGridView
        dgvSetNight = New DataGridView
        With dgvSetNight
            .Columns.Add("EmpID", "Employee ID")
            .Columns.Add("AtDate", "Atn Date")
            .Columns.Add("ChkDate", "Check Date")
            .Columns.Add("ChkTime", "Check Time")
            .Columns.Add("Checking", "Checking Time")
            .Columns.Add("InOut", "In Out")
            .Columns.Add("Mode", "Mode")
            .Columns.Add("St", "Status")
        End With


        Dim StrTemp As String
        Dim dtTAtn As Date
        Dim dtOutDate As Date
        Dim InTime As DateTime
        Dim OutTime As DateTime
        Dim clcIn As DateTime
        Dim clcOut As DateTime
        Dim EmpSt As Boolean = False
        Dim MaxAtDate As Date
        Dim newAtTime As DateTime
        Dim intShMode As Integer
        Dim dtHalfDay As DateTime

        'Get the Item Max Value
        Dim intPrgMax As Integer
        MaxAtDate = dtpMaxDate.Value  '  fk_RetDate("SELECT Max(cDate) FROM tblDiMachine WHERE Year(cDate) = " & cYear & " AND Month(cDate) = " & cMonth & "")

        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlOpn As String = ""
        If optSelMonth.Checked = True Then
            sqlOpn = "select tblEmpRegister.EMpID,tblEmpRegister.CMonth,tblEmpRegister.cYear,tblEmpRegister.Atdate,tblSetShiftH.ShiftMode,tblSetShiftH.ShiftID,tblEmpRegister.ClockIn,tblEmpRegister.ClockOut,tblSetShiftH.hasMeal,tblSetShiftH.HalfDay" & _
 " from tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID" & _
" where tblEmpRegister.cMonth = " & cMonth & " AND tblEmpRegister.cYear = " & cYear & " Order By tblEmpregister.EmpID,tblEmpRegister.AtDate"
        ElseIf optPeriod.Checked = True Then
            sqlOpn = "select tblEmpRegister.EMpID,tblEmpRegister.CMonth,tblEmpRegister.cYear,tblEmpRegister.Atdate,tblSetShiftH.ShiftMode,tblSetShiftH.ShiftID,tblEmpRegister.ClockIn,tblEmpRegister.ClockOut,tblSetShiftH.hasMeal,tblSetShiftH.HalfDay" & _
 " from tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID" & _
" where tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'  Order By tblEmpregister.EmpID,tblEmpRegister.AtDate"

            'Get the Value for the Max 
            intPrgMax = fk_sqlDbl("SELECT Count(*) FROM tblEmpRegister WHERE atDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'")
            pgbPrc.Maximum = intPrgMax
        End If
        Try
            Dim cmOpn As New SqlCommand(sqlOpn, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            Do While drOpn.Read = True
                'Get the In time first
                pgbPrc.Value = pgbPrc.Value + 1
                StrShiftID = IIf(IsDBNull(drOpn.Item("shiftID")), "", drOpn.Item("ShiftID"))
                StrTemp = IIf(IsDBNull(drOpn.Item("EMpID")), "", drOpn.Item("EMpID"))
                EmpSt = fk_CheckEx("SELECT * FROM tblEmployee WHERE RegID = '" & StrTemp & "' AND EmpStatus <> 9")
                dtTAtn = IIf(IsDBNull(drOpn.Item("Atdate")), "", drOpn.Item("Atdate"))
                dtOutDate = DateAdd(DateInterval.Day, 1, dtTAtn)
                InTime = IIf(IsDBNull(drOpn.Item("ClockIn")), "", drOpn.Item("ClockIn"))
                OutTime = IIf(IsDBNull(drOpn.Item("ClockOut")), "", drOpn.Item("ClockOut"))
                intShMode = IIf(IsDBNull(drOpn.Item("ShiftMode")), 0, drOpn.Item("ShiftMode"))
                intHasMeal = IIf(IsDBNull(drOpn.Item("HasMeal")), 0, drOpn.Item("HasMeal"))
                dtHalfDay = IIf(IsDBNull(drOpn.Item("HalfDay")), DateSerial(1900, 1, 1), drOpn.Item("HalfDay"))

                If intHasMeal = 1 Then 'Open Meal table 
                    'Open Meal Table
                    Dim cnMeal As New SqlConnection(sqlConString)
                    cnMeal.Open()
                    Dim sqlMeal As String = "SELECT * FROM tblMealOuts WHERE ShiftID = '" & StrShiftID & "'"
                    Try
                        Dim cmMeal As New SqlCommand(sqlMeal, cnMeal)
                        Dim drMeal As SqlDataReader = cmMeal.ExecuteReader
                        If drMeal.Read = True Then
                            dtmealStat = IIf(IsDBNull(drMeal.Item("ClockStart")), DateSerial(1900, 1, 1), drMeal.Item("ClockStart"))
                            dtMealClose = IIf(IsDBNull(drMeal.Item("ClockEnd")), DateSerial(1900, 1, 1), drMeal.Item("ClockEnd"))
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        cnMeal.Close()
                    End Try
                End If
                Dim bolExR As Boolean = False
                'Get the Intime First
                If EmpSt = True Then
                    '' ''Select Case intShMode
                    '' ''    Case 0
                    '' ''        newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''       " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''       " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblDiMachine.cTime <= '" & dtHalfDay & "' AND tblEmployee.RegID = '" & StrTemp & "'")


                    '' ''        'Check for the existing record in the Attendance History
                    '' ''        bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")
                    '' ''        If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''            If dtTAtn <= MaxAtDate Then
                    '' ''                If bolExR = False Then
                    '' ''                    dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                    '' ''                    'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                    '' ''                    'cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                    '' ''                    cmExe.ExecuteNonQuery()
                    '' ''                End If
                    '' ''            End If

                    '' ''        End If
                    '' ''        newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''        " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''        " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblDiMachine.cTime > '" & DateAdd(DateInterval.Minute, intMinWorkMin, newAtTime) & "' AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")
                    '' ''        bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")

                    '' ''        If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''            If dtTAtn <= MaxAtDate Then
                    '' ''                If bolExR = False Then
                    '' ''                    dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "OT", "A", "1")
                    '' ''                    'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                    '' ''                    'cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                    '' ''                    cmExe.ExecuteNonQuery()
                    '' ''                End If
                    '' ''            End If
                    '' ''        End If

                    '' ''        'Only Meal calculating only for the day shift, it's not coded for the night shift/24 hour shifts
                    '' ''        If IsMealAvbl = 1 Then
                    '' ''            If intHasMeal = 1 Then
                    '' ''                newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''          " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''          " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & dtmealStat & "'  AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")

                    '' ''                'Check for the existing record in the Attendance History
                    '' ''                bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'LO'")
                    '' ''                If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''                    If dtTAtn <= MaxAtDate Then
                    '' ''                        If bolExR = False Then
                    '' ''                            dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "LO", "L", "1")
                    '' ''                            'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                    '' ''                            cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                    '' ''                            cmExe.ExecuteNonQuery()
                    '' ''                        End If
                    '' ''                    End If

                    '' ''                End If
                    '' ''                newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''                " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''                " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND (tblDiMachine.cTime >=  '" & dtmealStat & "' AND tblDiMachine.cTime <=  '" & dtMealClose & "' AND tblDiMachine.cTime >= '" & DateAdd(DateInterval.Minute, 10, newAtTime) & "' ) AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")

                    '' ''                bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'LI'")

                    '' ''                If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''                    If dtTAtn <= MaxAtDate Then
                    '' ''                        If bolExR = False Then
                    '' ''                            dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "LI", "L", "1")
                    '' ''                            'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                    '' ''                            cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                    '' ''                            cmExe.ExecuteNonQuery()
                    '' ''                        End If
                    '' ''                    End If
                    '' ''                End If
                    '' ''            End If
                    '' ''        End If

                    '' ''    Case 1
                    '' ''        newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''        " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''        " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")
                    '' ''        bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")

                    '' ''        If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''            If dtTAtn <= MaxAtDate Then
                    '' ''                If bolExR = False Then
                    '' ''                    dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                    '' ''                End If

                    '' ''            End If
                    '' ''        End If

                    '' ''        newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''        " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''        " WHERE tblDiMachine.cDate = '" & Format(dtOutDate, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")

                    '' ''        bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")
                    '' ''        If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''            If dtTAtn <= MaxAtDate Then
                    '' ''                If bolExR = False Then
                    '' ''                    dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtOutDate, newAtTime, OutTime, "OT", "A", "1")
                    '' ''                End If
                    '' ''            End If
                    '' ''        End If

                    '' ''    Case 2
                    '' ''        newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''        " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''        " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")
                    '' ''        bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")

                    '' ''        If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''            If dtTAtn <= MaxAtDate Then
                    '' ''                If bolExR = False Then
                    '' ''                    dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                    '' ''                End If

                    '' ''            End If
                    '' ''        End If

                    '' ''        newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                    '' ''        " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    '' ''        " WHERE tblDiMachine.cDate = '" & Format(dtOutDate, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")

                    '' ''        bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")
                    '' ''        If newAtTime <> DateSerial(1900, 1, 1) Then
                    '' ''            If dtTAtn <= MaxAtDate Then
                    '' ''                If bolExR = False Then
                    '' ''                    dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtOutDate, newAtTime, OutTime, "OT", "A", "1")
                    '' ''                End If
                    '' ''            End If
                    '' ''        End If

                    ''''End Select
                    newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                      " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                      " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblDiMachine.cTime <= '" & dtHalfDay & "' AND tblEmployee.RegID = '" & StrTemp & "'")


                    'Check for the existing record in the Attendance History
                    ' bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")
                    If StrTemp = "000087" Then
                        MsgBox("")
                    End If
                    If newAtTime <> DateSerial(1900, 1, 1) Then
                        If dtTAtn <= MaxAtDate Then
                            If bolExR = False Then
                                dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                                'cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                                'cmExe.ExecuteNonQuery()
                            End If
                        End If

                    End If
                    newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                    " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                    " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblDiMachine.cTime > '" & DateAdd(DateInterval.Minute, intMinWorkMin, newAtTime) & "' AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")
                    ' bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")

                    If newAtTime <> DateSerial(1900, 1, 1) Then
                        If dtTAtn <= MaxAtDate Then
                            If bolExR = False Then
                                dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "OT", "A", "1")
                                'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                                'cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                                cmExe.ExecuteNonQuery()
                            End If
                        End If
                    End If
                End If
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try

        Dim ItR As Integer
        Dim iCol As Integer
        Dim pIn As DateTime
        Dim xIn As DateTime
        Dim gap As Integer
        With dgvSetNight

            For ItR = 0 To .RowCount - 2
                pIn = CDate(.Item(3, ItR).Value)
                xIn = CDate(.Item(4, ItR).Value)
                gap = Math.Abs(DateDiff(DateInterval.Hour, pIn, xIn))
                If gap > 10 Then
                    .Item(6, ItR).Value = "0"
                    .Rows(ItR).Visible = False
                    'For iCol = 0 To .Columns.Count - 1
                    '    .Item(iCol, ItR).Style.BackColor = Color.GreenYellow
                    'Next
                End If

            Next
        End With

        pnlBotom.Controls.Clear()
        pnlBotom.Controls.Add(dgvSetNight)
        dgvSetNight.Dock = DockStyle.Fill


        'regID,AtDate,CheckDate,CheckTime,INOUT
        'Now brow the 
        Dim iRw As Integer
        Dim st As Integer
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""
        If optPeriod.Checked = True Then
            sqlQRY = "DELETE FROM AtTmp WHERE AtDate between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
        ElseIf optSelMonth.Checked = True Then
            sqlQRY = "DELETE FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year(AtDate) = " & cYear & ""
        End If

        cmSave.CommandText = sqlQRY
        cmSave.ExecuteNonQuery()
        pgbPrc.Minimum = 0
        Try
            With dgvSetNight
                minVal = 0
                maxVal = .RowCount - 1
                IntVal = 0
                pgbPrc.Maximum = maxVal
                pgbPrc.Minimum = minVal

                For iRw = 0 To .RowCount - 2
                    st = .Item(7, iRw).Value
                    If st = 1 Then
                        sqlQRY = "INSERT INTO AtTmp (regID,AtDate,CheckDate,CheckTime,INOUT,TodayIn) VALUES ('" & .Item(0, iRw).Value & "', " & _
                        " '" & Format(CDate(.Item(1, iRw).Value), strRetDateTimeFormat) & "','" & Format(CDate(.Item(2, iRw).Value), strRetDateTimeFormat) & "','" & CDate(.Item(3, iRw).Value) & "','" & .Item(5, iRw).Value & "',0)"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()

                    End If

                    IntVal = IntVal + 1
                    pgbPrc.Value = IntVal

                Next
            End With

            'Backup Movement infomration 
            sqlQRY = "insert into tblMovements " & _
            " Select MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode from tblDiMachine where cDate not in (select cDate from tblMovements) "

            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'UPdate Today In Information in AtTmp Table 
            sqlQRY = "UPDATE atTmp SET TOdayIn = 1 WHERE AtDate = '" & Format(MaxAtDate, strRetDateTimeFormat) & "' AND INOUT = 'IN'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            Dim dtCloseDate As Date = dtpMaxDate.Value 'DateAdd(DateInterval.Day, -1, dtpMaxDate.Value)
            If chkCloseDay.Checked = True Then 'if request to close for the last run date, 

                sqlQRY = "UPDATE tblCompany SET AtnPrcDate  = '" & Format(dtCloseDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'"
                cmSave.CommandText = sqlQRY
                cmSave.ExecuteNonQuery()
            Else
                If MsgBox("You have not selected to closed the day when finish, " & vbCrLf & _
                           "This will effect to last run date. " & vbCrLf & _
                           "Press Yes, if you want to close the Day.", vbYesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then

                    sqlQRY = "UPDATE tblCompany SET AtnPrcDate  = '" & Format(dtCloseDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                End If
            End If

            'Update In Time to tblEmpRegister Table 
            sqlQRY = "update tblEmpRegister SET AntStatus = 1,InUpdate = 1,tblEmpRegister.InDate = AtTmp.CheckDate, tblEmpRegister.InTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'IN' AND tblEmpRegister.InUpdate In (0) " & _
            " update tblEmpRegister SET AntStatus = 1,OutUpdate = 1,tblEmpRegister.OutDate = AtTmp.CheckDate, tblEmpRegister.OutTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'OT' AND tblEmpRegister.OutUpdate In (0)"
            If IsMealAvbl = 1 Then
                sqlQRY = sqlQRY & " update tblEmpRegister SET tblEmpRegister.InTime2 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'LI'"
                sqlQRY = sqlQRY & " update tblEmpRegister SET tblEmpRegister.OutTime2 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'LO'"
            End If
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Update Late, And other calculated & analisys parts in the system
            sqlQRY = "update tblEmpRegister SET tblEmpRegister.WorkMins = CASE WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE DateDiff(minute,tblEmpRegister.AtDate+tblEmpRegister.InTime1,tblEmpRegister.OutDate+tblEmpRegister.OutTime1) END," & _
            " IsLate = 0," & _
            " tblEmpRegister.LateMins = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.sInTime,tblEmpRegister.InTime1) - " & dblLateMins & " < 0 THEN 0 Else DateDiff(minute,tblEmpRegister.sInTime,tblEmpRegister.InTime1) - " & dblLateMins & "  END," & _
            " IsEarly = 0," & _
            " tblEmpRegister.EarlyMins = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN  tblEmpRegister.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.OutTime1,tblEmpRegister.sOutTime) <0 THEN 0 Else DateDiff(minute,tblEmpRegister.OutTime1,tblEmpRegister.sOutTime) END," & _
            " tblEmpRegister.BeginOT = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblemp_subCategory.OTAllw = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.InTime1,tblEmpRegister.sInTime) < 0 THEN 0 Else DateDiff(minute,tblEmpRegister.InTime1,tblEmpRegister.sInTime) END," & _
            " tblEmpRegister.EndOT = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblemp_subCategory.OTAllw = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.sOutTime,tblEmpRegister.OutTime1) < 0 THEN 0 Else  DateDiff(minute,tblEmpRegister.sOutTime,tblEmpRegister.OutTime1) END," & _
            " tblEmpRegister.IsOffdayWork = CASE WHEN tblDayType.WorkUnit = 0 AND tblEmpRegister.AntStatus = 1 THEN 1 ELSE 0 END " & _
            " from tblEmpRegister " & _
            " INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID " & _
            " INNER JOIN tblEmployee ON tblEmpRegister.EmpID  = tblEmployee.RegID " & _
            " INNER JOIN tblSetEmpCategory ON tblEmployee.CatID = tblSetEmpCategory.CatID " & _
            " INNER JOIN tblDayTYpe ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AntStatus = 1 AND tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Update Late & Early Status 
            sqlQRY = "update tblEmpRegister SET WorkHrs = CASE WHEN WorkHrs < 0 THEN 0 Else Round(WorkMins/60,2) End,isLate = CASE  WHEN LateMins <=0 THEN 0 Else 1 END,isEarly = CASE  WHEN EarlyMins <= 0 THEN 0 Else 1 End WHERE atDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "UPDATE tblEmpRegister SET BgOTHrs = CASE  WHEN BeginOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN floor(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & " Else Round(ceiling(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "UPDATE tblEmpRegister SET EdOTHrs = CASE  WHEN EndOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",1) Else Round(ceiling(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()


            'Count Compulsory OT


            'Update OT Hours for the rounded figures 
            'Generate Shift IN/OUT Time here 
            sqlQRY = "UPDATE tblEmpRegister SET tblEMpRegister.sInTime = tblSetShiftH.InTime, " & _
            " tblEmpRegister.sOutTime = CASE tblDayType.WorkUnit WHEN .5 THEN tblSetShiftH.HalfDay ELSE tblSetShiftH.OutTime END " & _
            " FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AtDate >= '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()


            trSave.Commit()



        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

        _reprocess_OutLessEmp("select tblEmpRegister.EMpID,tblEmpRegister.CMonth,tblEmpRegister.cYear,tblEmpRegister.Atdate,tblSetShiftH.ShiftMode,tblSetShiftH.ShiftID,tblSetShiftH.ClockIn,tblSetShiftH.ClockOut,tblSetShiftH.hasMeal,tblSetShiftH.HalfDay" & _
      " from tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID" & _
      " where tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "' AND tblEmpRegister.AntStatus = 1 AND tblEmpRegister.OutUpdate = 0  Order By tblEmpregister.EmpID,tblEmpRegister.AtDate")


        Dim dgvAtnSum As DataGridView
        dgvAtnSum = New DataGridView
        Dim sqlQR As String = ""


        'Dim dtPAtDate As Date

        'Dim StrPEmpID As String
        'Dim StrPSt As String = "P"
        'Dim iRn As Integer

        If IsMealAvbl = 1 Then
            With dgvAtnSum
                .Columns.Add("EmpID", "Employee ID")            ' - 0
                .Columns.Add("AtDate", "Attendance Date")       ' - 1
                .Columns.Add("InDate", "In Date")               ' - 2
                .Columns.Add("InTime", "In Time")               ' - 3
                .Columns.Add("OutDate", "Out Date")             ' - 4
                .Columns.Add("OutTime", "Out Time")             ' - 5
                .Columns.Add("MealOut", "Meal Out")             ' - 6
                .Columns.Add("MealIn", "Meal In")               ' - 7
                .Columns.Add("RStatus", "R Status")             ' - 8

            End With

            If optPeriod.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],dbo.fk_RetDate(RegID,AtDate,'LO','02') As [Meal Out],dbo.fk_RetDate(RegID,AtDate,'LI','02') As [Meal IN],'P' from AtTmp WHERE AtDate >= '" & Format(dtLastProcess, strRetDateTimeFormat) & "' AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) group by RegID,AtDate,TodayIn"


            ElseIf optSelMonth.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],dbo.fk_RetDate(RegID,AtDate,'LO','02') As [Meal Out],dbo.fk_RetDate(RegID,AtDate,'LI','02') As [Meal IN],'P' from AtTmp WHERE  Year(AtDate) = " & cYear & " AND Month(AtDate) = " & cMonth & " AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) group by RegID,AtDate,TodayIn"
            End If

            'CONVERT(varchar, AtDate, 105) As AtDate
            Load_InformationtoGrid(sqlQR, dgvAtnSum, 9)

            '    With dgvAtnSum

        End If



        Dim dtLastDate As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")

        Dim dtMaxDate As Date = fk_RetDate("SELECT Max(CDate) FROM tblDiMachine WHERE cDate >= '" & Format(dtLastDate, strRetDateTimeFormat) & "'")
        dtpLRDate.Value = dtLastDate
        dtpMaxDate.Value = dtMaxDate

        txtlast.Text = Format(dtLastDate, strDispDateTimeFormat)
        txtCurrent.Text = Format(dtMaxDate, strDispDateTimeFormat)

        'Open Tmp table

        pnlBotom.Controls.Clear()
        pnlBotom.Controls.Add(dgvAtnSum)
        dgvAtnSum.Dock = DockStyle.Fill


        MsgBox("Process Completed", MsgBoxStyle.Information)
    End Sub

    Public Sub _reprocess_OutLessEmp(ByVal passSQL As String)
        Dim atTmpMax As Double = fk_sqlDbl("SELECT Count(*) FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year (AtDate) = " & cYear & "")
        pgbPrc.Minimum = 0
        pgbPrc.Value = 0
        cYear = CInt(cmdYear.Text)
        cMonth = fk_RetMonthNumber(cmdMonth.Text)

        Dim cnExe As New SqlConnection(sqlConString)
        cnExe.Open()
        Dim cmExe As SqlCommand
        'Clear the Update Status 
        cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 0", cnExe)
        cmExe.ExecuteNonQuery()

        Dim StrShiftID As String

        Dim dtmealStat As Date
        Dim dtMealClose As Date
        Dim intHasMeal As Integer

        Dim dtLastProcess As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        Dim dgvNight As DataGridView
        dgvNight = New DataGridView
        With dgvNight
            .Columns.Add("EmpID", "Employee ID")
            .Columns.Add("AtDate", "Attn Date")
            .Columns.Add("ChkDate", "CheckDate")
            .Columns.Add("ChkTime", "Check Time")
            .Columns.Add("INOut", "In Out")
            .Columns.Add("ShiftMode", "Shift Mode")
            .Columns.Add("ShftID", "Shift ID")
            .Columns.Add("ClcIn", "Clock In")
            .Columns.Add("ClcOut", "Clock Out")
        End With

        Dim dgvSetNight As DataGridView
        dgvSetNight = New DataGridView
        With dgvSetNight
            .Columns.Add("EmpID", "Employee ID")
            .Columns.Add("AtDate", "Atn Date")
            .Columns.Add("ChkDate", "Check Date")
            .Columns.Add("ChkTime", "Check Time")
            .Columns.Add("Checking", "Checking Time")
            .Columns.Add("InOut", "In Out")
            .Columns.Add("Mode", "Mode")
            .Columns.Add("St", "Status")
        End With


        Dim StrTemp As String
        Dim dtTAtn As Date
        Dim dtOutDate As Date
        Dim InTime As DateTime
        Dim OutTime As DateTime
        Dim clcIn As DateTime
        Dim clcOut As DateTime
        Dim EmpSt As Boolean = False
        Dim MaxAtDate As Date
        Dim newAtTime As DateTime
        Dim intShMode As Integer
        Dim dtHalfDay As DateTime

        'Get the Item Max Value
        Dim intPrgMax As Integer
        MaxAtDate = dtpMaxDate.Value  '  fk_RetDate("SELECT Max(cDate) FROM tblDiMachine WHERE Year(cDate) = " & cYear & " AND Month(cDate) = " & cMonth & "")

        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlOpn As String = ""
        If optSelMonth.Checked = True Then
            sqlOpn = "select tblEmpRegister.EMpID,tblEmpRegister.CMonth,tblEmpRegister.cYear,tblEmpRegister.Atdate,tblSetShiftH.ShiftMode,tblSetShiftH.ShiftID,tblSetShiftH.ClockIn,tblSetShiftH.ClockOut,tblSetShiftH.hasMeal,tblSetShiftH.HalfDay" & _
 " from tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID" & _
" where tblEmpRegister.cMonth = " & cMonth & " AND tblEmpRegister.cYear = " & cYear & " Order By tblEmpregister.EmpID,tblEmpRegister.AtDate"
        ElseIf optPeriod.Checked = True Then
            sqlOpn = passSQL

            'Get the Value for the Max 
            intPrgMax = fk_sqlDbl("SELECT Count(*) FROM tblEmpRegister WHERE atDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "' AND tblEmpRegister.AntStatus = 1 AND tblEmpRegister.OutUpdate = 0")
            pgbPrc.Maximum = intPrgMax

        End If
        Try
            Dim cmOpn As New SqlCommand(sqlOpn, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            Do While drOpn.Read = True
                'Get the In time first
                pgbPrc.Value = pgbPrc.Value + 1
                StrShiftID = IIf(IsDBNull(drOpn.Item("shiftID")), "", drOpn.Item("ShiftID"))
                StrTemp = IIf(IsDBNull(drOpn.Item("EMpID")), "", drOpn.Item("EMpID"))
                EmpSt = fk_CheckEx("SELECT * FROM tblEmployee WHERE RegID = '" & StrTemp & "' AND EmpStatus <> 9")
                dtTAtn = IIf(IsDBNull(drOpn.Item("Atdate")), "", drOpn.Item("Atdate"))
                dtOutDate = DateAdd(DateInterval.Day, 1, dtTAtn)
                InTime = IIf(IsDBNull(drOpn.Item("ClockIn")), "", drOpn.Item("ClockIn"))
                OutTime = IIf(IsDBNull(drOpn.Item("ClockOut")), "", drOpn.Item("ClockOut"))
                intShMode = IIf(IsDBNull(drOpn.Item("ShiftMode")), 0, drOpn.Item("ShiftMode"))
                intHasMeal = IIf(IsDBNull(drOpn.Item("HasMeal")), 0, drOpn.Item("HasMeal"))
                dtHalfDay = IIf(IsDBNull(drOpn.Item("HalfDay")), DateSerial(1900, 1, 1), drOpn.Item("HalfDay"))

                If intHasMeal = 1 Then 'Open Meal table 
                    'Open Meal Table
                    Dim cnMeal As New SqlConnection(sqlConString)
                    cnMeal.Open()
                    Dim sqlMeal As String = "SELECT * FROM tblMealOuts WHERE ShiftID = '" & StrShiftID & "'"
                    Try
                        Dim cmMeal As New SqlCommand(sqlMeal, cnMeal)
                        Dim drMeal As SqlDataReader = cmMeal.ExecuteReader
                        If drMeal.Read = True Then
                            dtmealStat = IIf(IsDBNull(drMeal.Item("ClockStart")), DateSerial(1900, 1, 1), drMeal.Item("ClockStart"))
                            dtMealClose = IIf(IsDBNull(drMeal.Item("ClockEnd")), DateSerial(1900, 1, 1), drMeal.Item("ClockEnd"))
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        cnMeal.Close()
                    End Try
                End If
                Dim bolExR As Boolean = False
                'Get the Intime First
                If EmpSt = True Then
                    Select Case intShMode
                        Case 0
                            newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                           " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                           " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblDiMachine.cTime <= '" & dtHalfDay & "' AND tblEmployee.RegID = '" & StrTemp & "'")


                            'Check for the existing record in the Attendance History
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")
                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                        'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                                        'cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                                        cmExe.ExecuteNonQuery()
                                    End If
                                End If

                            End If
                            newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblDiMachine.cTime > '" & DateAdd(DateInterval.Minute, intMinWorkMin, newAtTime) & "' AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")

                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "OT", "A", "1")
                                        'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                                        'cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                                        cmExe.ExecuteNonQuery()
                                    End If
                                End If
                            End If

                            'Only Meal calculating only for the day shift, it's not coded for the night shift/24 hour shifts
                            If IsMealAvbl = 1 Then
                                If intHasMeal = 1 Then
                                    newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                              " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                              " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & dtmealStat & "'  AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")

                                    'Check for the existing record in the Attendance History
                                    bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'LO'")
                                    If newAtTime <> DateSerial(1900, 1, 1) Then
                                        If dtTAtn <= MaxAtDate Then
                                            If bolExR = False Then
                                                dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "LO", "L", "1")
                                                'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                                                cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                                                cmExe.ExecuteNonQuery()
                                            End If
                                        End If

                                    End If
                                    newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                                    " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                                    " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND (tblDiMachine.cTime >=  '" & dtmealStat & "' AND tblDiMachine.cTime <=  '" & dtMealClose & "' AND tblDiMachine.cTime >= '" & DateAdd(DateInterval.Minute, 10, newAtTime) & "' ) AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")

                                    bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'LI'")

                                    If newAtTime <> DateSerial(1900, 1, 1) Then
                                        If dtTAtn <= MaxAtDate Then
                                            If bolExR = False Then
                                                dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "LI", "L", "1")
                                                'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'")
                                                cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "'", cnExe)
                                                cmExe.ExecuteNonQuery()
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Case 1
                            newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")

                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                    End If

                                End If
                            End If

                            newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtOutDate, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")

                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")
                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtOutDate, newAtTime, OutTime, "OT", "A", "1")
                                    End If
                                End If
                            End If

                        Case 2
                            newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'IN'")

                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                    End If

                                End If
                            End If

                            newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtOutDate, strRetDateTimeFormat) & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")

                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, strRetDateTimeFormat) & "' AND InOut = 'OT'")
                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtOutDate, newAtTime, OutTime, "OT", "A", "1")
                                    End If
                                End If
                            End If
                    End Select
                End If
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try

        Dim ItR As Integer
        Dim iCol As Integer
        Dim pIn As DateTime
        Dim xIn As DateTime
        Dim gap As Integer
        With dgvSetNight

            For ItR = 0 To .RowCount - 2
                pIn = CDate(.Item(3, ItR).Value)
                xIn = CDate(.Item(4, ItR).Value)
                gap = Math.Abs(DateDiff(DateInterval.Hour, pIn, xIn))
                If gap > 10 Then
                    .Item(6, ItR).Value = "0"
                    .Rows(ItR).Visible = False
                    'For iCol = 0 To .Columns.Count - 1
                    '    .Item(iCol, ItR).Style.BackColor = Color.GreenYellow
                    'Next
                End If

            Next
        End With

        pnlBotom.Controls.Clear()
        pnlBotom.Controls.Add(dgvSetNight)
        dgvSetNight.Dock = DockStyle.Fill


        'regID,AtDate,CheckDate,CheckTime,INOUT
        'Now brow the 
        Dim iRw As Integer
        Dim st As Integer
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""
        If optPeriod.Checked = True Then
            sqlQRY = "DELETE FROM AtTmp WHERE AtDate between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
        ElseIf optSelMonth.Checked = True Then
            sqlQRY = "DELETE FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year(AtDate) = " & cYear & ""
        End If

        cmSave.CommandText = sqlQRY
        cmSave.ExecuteNonQuery()
        pgbPrc.Minimum = 0
        Try
            With dgvSetNight
                minVal = 0
                maxVal = .RowCount - 1
                IntVal = 0
                pgbPrc.Maximum = maxVal
                pgbPrc.Minimum = minVal

                For iRw = 0 To .RowCount - 2
                    st = .Item(7, iRw).Value
                    If st = 1 Then
                        sqlQRY = "INSERT INTO AtTmp (regID,AtDate,CheckDate,CheckTime,INOUT,TodayIn) VALUES ('" & .Item(0, iRw).Value & "', " & _
                        " '" & Format(CDate(.Item(1, iRw).Value), strRetDateTimeFormat) & "','" & Format(CDate(.Item(2, iRw).Value), strRetDateTimeFormat) & "','" & CDate(.Item(3, iRw).Value) & "','" & .Item(5, iRw).Value & "',0)"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()

                    End If

                    IntVal = IntVal + 1
                    pgbPrc.Value = IntVal

                Next
            End With

            'Backup Movement infomration 
            sqlQRY = "insert into tblMovements " & _
            " Select MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode from tblDiMachine where cDate not in (select cDate from tblMovements) "

            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'UPdate Today In Information in AtTmp Table 
            sqlQRY = "UPDATE atTmp SET TOdayIn = 1 WHERE AtDate = '" & Format(MaxAtDate, strRetDateTimeFormat) & "' AND INOUT = 'IN'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            Dim dtCloseDate As Date = dtpMaxDate.Value 'DateAdd(DateInterval.Day, -1, dtpMaxDate.Value)
            If chkCloseDay.Checked = True Then 'if request to close for the last run date, 

                sqlQRY = "UPDATE tblCompany SET AtnPrcDate  = '" & Format(dtCloseDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'"
                cmSave.CommandText = sqlQRY
                cmSave.ExecuteNonQuery()
            Else
                If MsgBox("You have not selected to closed the day when finish, " & vbCrLf & _
                           "This will effect to last run date. " & vbCrLf & _
                           "Press Yes, if you want to close the Day.", vbYesNo + MsgBoxStyle.Critical) = MsgBoxResult.Yes Then

                    sqlQRY = "UPDATE tblCompany SET AtnPrcDate  = '" & Format(dtCloseDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                End If
            End If

            'Update In Time to tblEmpRegister Table 
            sqlQRY = "update tblEmpRegister SET AntStatus = 1,InUpdate = 1,tblEmpRegister.InDate = AtTmp.CheckDate, tblEmpRegister.InTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'IN' AND tblEmpRegister.InUpdate In (0) " & _
            " update tblEmpRegister SET AntStatus = 1,OutUpdate = 1,tblEmpRegister.OutDate = AtTmp.CheckDate, tblEmpRegister.OutTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'OT' AND tblEmpRegister.OutUpdate In (0)"
            If IsMealAvbl = 1 Then
                sqlQRY = sqlQRY & " update tblEmpRegister SET tblEmpRegister.InTime2 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'LI'"
                sqlQRY = sqlQRY & " update tblEmpRegister SET tblEmpRegister.OutTime2 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'LO'"
            End If
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Update Late, And other calculated & analisys parts in the system
            sqlQRY = "update tblEmpRegister SET tblEmpRegister.WorkMins = CASE WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE DateDiff(minute,tblEmpRegister.AtDate+tblEmpRegister.InTime1,tblEmpRegister.OutDate+tblEmpRegister.OutTime1) END," & _
            " IsLate = 0," & _
            " tblEmpRegister.LateMins = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.sInTime,tblEmpRegister.InTime1) - " & dblLateMins & " < 0 THEN 0 Else DateDiff(minute,tblEmpRegister.sInTime,tblEmpRegister.InTime1) - " & dblLateMins & "  END," & _
            " IsEarly = 0," & _
            " tblEmpRegister.EarlyMins = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN  tblEmpRegister.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.OutTime1,tblEmpRegister.sOutTime) <0 THEN 0 Else DateDiff(minute,tblEmpRegister.OutTime1,tblEmpRegister.sOutTime) END," & _
            " tblEmpRegister.BeginOT = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblemp_subCategory.OTAllw = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.InTime1,tblEmpRegister.sInTime) < 0 THEN 0 Else DateDiff(minute,tblEmpRegister.InTime1,tblEmpRegister.sInTime) END," & _
            " tblEmpRegister.EndOT = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblemp_subCategory.OTAllw = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.sOutTime,tblEmpRegister.OutTime1) < 0 THEN 0 Else  DateDiff(minute,tblEmpRegister.sOutTime,tblEmpRegister.OutTime1) END," & _
            " tblEmpRegister.IsOffdayWork = CASE WHEN tblEmpRegister.ShiftID = '999' AND tblEmpRegister.AntStatus = 1 THEN 1 ELSE 0 END " & _
            " from tblEmpRegister " & _
            " INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID " & _
            " INNER JOIN tblEmployee ON tblEmpRegister.EmpID  = tblEmployee.RegID " & _
            " INNER JOIN tblSetEmpCategory ON tblEmployee.CatID = tblSetEmpCategory.CatID " & _
            " INNER JOIN tblDayTYpe ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AntStatus = 1 AND tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Update Late & Early Status 
            sqlQRY = "update tblEmpRegister SET WorkHrs = CASE WHEN WorkHrs < 0 THEN 0 Else Round(WorkMins/60,2) End,isLate = CASE  WHEN LateMins <=0 THEN 0 Else 1 END,isEarly = CASE  WHEN EarlyMins <= 0 THEN 0 Else 1 End WHERE atDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "UPDATE tblEmpRegister SET BgOTHrs = CASE  WHEN BeginOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN floor(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & " Else Round(ceiling(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "UPDATE tblEmpRegister SET EdOTHrs = CASE  WHEN EndOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",1) Else Round(ceiling(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()


            'Count Compulsory OT


            'Update OT Hours for the rounded figures 
            'Generate Shift IN/OUT Time here 
            sqlQRY = "UPDATE tblEmpRegister SET tblEMpRegister.sInTime = tblSetShiftH.InTime, " & _
            " tblEmpRegister.sOutTime = CASE tblDayType.WorkUnit WHEN .5 THEN tblSetShiftH.HalfDay ELSE tblSetShiftH.OutTime END " & _
            " FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AtDate >= '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()


            trSave.Commit()

            'MsgBox("Process Completed", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try




        Dim dgvAtnSum As DataGridView
        dgvAtnSum = New DataGridView
        Dim sqlQR As String = ""


        'Dim dtPAtDate As Date

        'Dim StrPEmpID As String
        'Dim StrPSt As String = "P"
        'Dim iRn As Integer

        If IsMealAvbl = 1 Then
            With dgvAtnSum
                .Columns.Add("EmpID", "Employee ID")            ' - 0
                .Columns.Add("AtDate", "Attendance Date")       ' - 1
                .Columns.Add("InDate", "In Date")               ' - 2
                .Columns.Add("InTime", "In Time")               ' - 3
                .Columns.Add("OutDate", "Out Date")             ' - 4
                .Columns.Add("OutTime", "Out Time")             ' - 5
                .Columns.Add("MealOut", "Meal Out")             ' - 6
                .Columns.Add("MealIn", "Meal In")               ' - 7
                .Columns.Add("RStatus", "R Status")             ' - 8

            End With

            If optPeriod.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],dbo.fk_RetDate(RegID,AtDate,'LO','02') As [Meal Out],dbo.fk_RetDate(RegID,AtDate,'LI','02') As [Meal IN],'P' from AtTmp WHERE AtDate >= '" & Format(dtLastProcess, strRetDateTimeFormat) & "' AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) group by RegID,AtDate,TodayIn"


            ElseIf optSelMonth.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],dbo.fk_RetDate(RegID,AtDate,'LO','02') As [Meal Out],dbo.fk_RetDate(RegID,AtDate,'LI','02') As [Meal IN],'P' from AtTmp WHERE  Year(AtDate) = " & cYear & " AND Month(AtDate) = " & cMonth & " AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) group by RegID,AtDate,TodayIn"
            End If

            'CONVERT(varchar, AtDate, 105) As AtDate
            Load_InformationtoGrid(sqlQR, dgvAtnSum, 9)

            '    With dgvAtnSum

        End If
    End Sub
    Public Sub _AtnTime(ByVal Emp As String, ByVal shMode As Integer, ByVal ClckIn As Date, ByVal clcOut As Date)

        Select Case shMode
            Case 0 'Day mode

            Case 1 ' Night mode

        End Select
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click

    End Sub

    Private Function fk_RetDateTime(ByVal sqlQ As String) As DateTime
        Dim dtRes As DateTime
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Try
            Dim cmOpn As New SqlCommand(sqlQ, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            If drOpn.Read = True Then
                dtRes = IIf(IsDBNull(drOpn.Item(0)), DateSerial(1900, 1, 1), drOpn.Item(0))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try

        Return dtRes

    End Function

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        'cYear = CInt(cmdYear.Text)
        'cMonth = fk_RetMonthNumber(cmdMonth.Text)
        'Dim dtLastProcess As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")

        ''Generate report for the selected information 
        'Dim sqlQR As String = ""
        'optPeriod.Checked = True
        'If optPeriod.Checked = True Then
        '    sqlQR = "select regID, AtDate ,Month(AtDate), Year(AtDate),dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date]," & _
        '" dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time], dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date]," & _
        '" dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],AtSt = CASE WHEN (dbo.fk_RetDate(RegID,AtDate,'OT','01') = '' OR dbo.fk_RetDate(RegID,AtDate,'IN','01') = '') THEN 'E' ELSE 'P' END   from AtTmp  WHERE AtDate between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "' group by RegID,AtDate"
        'ElseIf optSelMonth.Checked = True Then
        '    sqlQR = "select regID, AtDate,Month(AtDate), Year(AtDate),dbo.fk_RetDateUps(RegID,AtDate,'IN','01') As [In Date], " & _
        '" dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time], dbo.fk_RetDateUps(RegID,AtDate,'OT','01') As [Out Date]," & _
        '" dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],AtSt = CASE WHEN (dbo.fk_RetDate(RegID,AtDate,'OT','01') = '' OR dbo.fk_RetDate(RegID,AtDate,'IN','01') = '') THEN 'E' ELSE 'P' END   from AtTmp  WHERE  Year(AtDate) = " & cYear & " AND Month(AtDate) = " & cMonth & " group by RegID,AtDate"
        'End If

        'Dim sqlQRY As String
        'Dim cnPrc As New SqlConnection(sqlConString)
        'cnPrc.Open()
        'Dim cmPrc As New SqlCommand
        'cmPrc = cnPrc.CreateCommand
        'Dim trPrc As SqlTransaction = cnPrc.BeginTransaction
        'cmPrc.Transaction = trPrc
        'Try
        '    sqlQRY = "DELETE FROM tblAtnReport"
        '    cmPrc.CommandText = sqlQRY
        '    cmPrc.ExecuteNonQuery()

        '    sqlQRY = "INSERT INTO tblAtnReport (RegID,AtDate,cMonth,cYear,ChkInDate,ChkInTime,ChkOutDate,ChkOutTime,Status) " & sqlQR
        '    cmPrc.CommandText = sqlQRY
        '    cmPrc.ExecuteNonQuery()

        '    trPrc.Commit()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    trPrc.Rollback()
        'Finally
        '    cnPrc.Close()
        'End Try


        ''Opne Report 
        'Dim cnOpen As New SqlConnection(sqlConString)
        'cnOpen.Open()
        'Dim sqlOpen As String = "SELECT * FROM tblReports WHERE RepID = '001'"
        'Try
        '    Dim cmOPen As New SqlCommand(sqlOpen, cnOpen)
        '    Dim drOpen As SqlDataReader = cmOPen.ExecuteReader
        '    If drOpen.Read = True Then
        '        StrRepFile = IIf(IsDBNull(drOpen.Item("RPath")), "", drOpen.Item("RPath"))
        '        StrRepTitle = IIf(IsDBNull(drOpen.Item("RName")), "", drOpen.Item("RName"))
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnOpen.Close()
        'End Try

        'StrRepFile = StrRepHeadPath & StrRepFile

        'If optPeriod.Checked = True Then
        '    StrSelectionFomula = "{tblAtnReport.AtDate} >= Date(" & Year(dtLastProcess) & "," & Month(dtLastProcess) & "," & CInt(Format(dtLastProcess, "dd")) & ")"
        'ElseIf optSelMonth.Checked = True Then
        '    StrSelectionFomula = "{tblAtnReport.cMonth} = " & cMonth & " AND {tblAtnReport.cYear} = " & cYear & " AND {tblEmployee.CompID} = '" & StrCompID & "'"
        'End If




        'Dim frmReg As New frmRepContainer

        'frmReg.WindowState = FormWindowState.Maximized



        'frmReg.ShowDialog()

        'Dim frmDes As New frmRepSelection
        'StrRepHeadPath = Application.StartupPath & "\"
        'strLoadReport = "rpt_HeadCount.rpt"
        'StrRepTitle = "Employee Daily Attendance Detail Report"
        'With frmDes
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .MinimizeBox = False
        '    .MaximizeBox = False
        '    .ShowDialog()
        'End With

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub chkView_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkView.CheckedChanged
        Dim sqlQR As String
        If chkView.Checked = True Then
            sqlQR = "SELECT tblEmpRegister.EmpID,tblEmployee.EpfNo,tblEmpRegister.AtDate,tblEmpRegister.InDate,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.InTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar), " & _
        " tblEmpRegister.OutDate, cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.OutTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),'P',1 From tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID WHERE tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "' AND tblEmpRegister.AntStatus = 1 Order By tblEmpRegister.AtDate,tblEmpRegister.EmpID"
        Else
            sqlQR = "SELECT tblEmpRegister.EmpID,tblEmployee.EpfNo,tblEmpRegister.AtDate,tblEmpRegister.InDate,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.InTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar), " & _
        " tblEmpRegister.OutDate, cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.OutTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),'P',1 From tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID WHERE tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "' Order By tblEmpRegister.AtDate,tblEmpRegister.EmpID"
        End If

        Dim dgvAtnSum As DataGridView
        dgvAtnSum = New DataGridView

        With dgvAtnSum
            .Columns.Add("EmpID", "Employee ID")            ' - 0
            .Columns(0).Visible = False
            .Columns.Add("EpfNo", "EPF Number")
            .Columns.Add("AtDate", "Attendance Date")       ' - 1
            .Columns.Add("InDate", "In Date")               ' - 2
            .Columns.Add("InTime", "In Time")               ' - 3
            .Columns.Add("OutDate", "Out Date")             ' - 4
            .Columns.Add("OutTime", "Out Time")             ' - 5
            .Columns.Add("RStatus", "R Status")             ' - 6

            .Columns.Add("TodayIn", "Today In")             ' - 7

        End With

        Load_InformationtoGrid(sqlQR, dgvAtnSum, 9)
        pgbPrc.Value = 0

        With dgvAtnSum
            pgbPrc.Maximum = .RowCount - 1
            For iRn = 0 To .RowCount - 2

                Dim StrPEmpID As String = .Item(0, iRn).Value
                Dim dtPAtDate As Date = CDate(.Item(2, iRn).Value)
                Dim StrPInDate As String = .Item(3, iRn).Value
                Dim StrPInTime As String = .Item(4, iRn).Value
                Dim StrPoutDate As String = .Item(5, iRn).Value
                Dim StrPOutTime As String = .Item(6, iRn).Value
                Dim intTodayIn As Integer = .Item(8, iRn).Value
                Dim iCols As Integer
                Dim StrPSt As String = "P"
                pgbPrc.Value = pgbPrc.Value + 1

                If intTodayIn = 1 Then 'if today in record it's automaticall P record
                    StrPSt = "P"
                Else

                    If StrPInDate = "" Or StrPoutDate = "" Then
                        For iCols = 0 To .Columns.Count - 1
                            .Item(iCols, iRn).Style.BackColor = Color.Yellow
                        Next
                        StrPSt = "E"
                    Else
                        StrPSt = "P"
                    End If
                End If
                .Item(7, iRn).Value = StrPSt
            Next

        End With

        pnlBotom.Controls.Clear()
        pnlBotom.Controls.Add(dgvAtnSum)
        dgvAtnSum.Dock = DockStyle.Fill

    End Sub

    Public Sub single_shiftProcess()
        Dim sqlQRY1 As String = ""
        sqlQRY1 = " update tblEmpRegister SET tblEmpRegister.sInTime = tblEmpRegister.AtDate+tblSetShiftH.InTime,tblEmpRegister.sOutTime = CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate+tblSetShiftH.OutTime ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.OutTime END," & _
          " tblEmpRegister.OutDate = CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate Else DateAdd(day,1,tblEmpRegister.atDate) END," & _
          " tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN, " & _
          " tblEmpRegister.ClockOut = CASE tblEmpRegister.OTApved WHEN 0 THEN CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT Else DateAdd(day,1,tblEmpRegister.atDate)+tblSetshiftH.EndCOUT END Else tblEmpRegister.ClockOut END  from tblSetShiftH " & _
          " INNER JOIN tblEmpRegister ON tblSetShiftH.ShiftID = tblEmpRegister.ShiftID WHERE tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
        FK_EQ(sqlQRY1, "S", "", False, False, False)

        Process_Attendance(dtpLRDate.Value, dtpMaxDate.Value, "", "A", pgbPrc)
        Dim sqlList As String = ""
        sqlList = "SELECT  'false',tblEmployee.RegID,tblEmployee.EpfNo,tblEmployee.dispName,tblEmpRegister.AtDate," & _
        " tblEmpRegister.ShiftID,tblSetShiftH.ShiftName,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.InTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),tblEmpRegister.OutDate," & _
        " cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.OutTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar) FROM tblEmpRegister INNER JOIN tblEmployee ON tblEmpRegister.EmpID = tblEmployee.RegID " & _
        " INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "' AND tblEmployee.EmpStatus <> 9 ORDER BY tblEmployee.RegID"
        Load_InformationtoGrid(sqlList, dgvEmployee, 10)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Daily Download", "Do the attendance process") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        Dim sqlQRY1 As String = ""
        'sqlQRY1 = " update tblGetINOUT SET tblGetINOUT.sInTime = tblGetINOUT.AtDate+tblSetShiftH.InTime,tblGetINOUT.sOutTime = CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblGetINOUT.AtDate+tblSetShiftH.OutTime ELSE DateAdd(Day,1,tblGetINOUT.AtDate)+tblSetShiftH.OutTime END," & _
        '  " tblGetINOUT.OutDate = CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblGetINOUT.AtDate Else DateAdd(day,1,tblGetINOUT.atDate) END," & _
        '  " tblGetINOUT.ClockIn = tblGetINOUT.AtDate+tblSetShiftH.StartCIN, " & _
        '  " tblGetINOUT.ClockOut = CASE tblGetINOUT.OTApved WHEN 0 THEN CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblGetINOUT.AtDate+tblSetShiftH.EndCOUT Else DateAdd(day,1,tblGetINOUT.atDate)+tblSetshiftH.EndCOUT END Else tblGetINOUT.ClockOut END  from tblSetShiftH " & _
        '  " INNER JOIN tblGetINOUT ON tblSetShiftH.ShiftID = tblEmpRegister.ShiftID WHERE tblGetINOUT.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
        sqlQRY1 = " update tblEmpRegister SET tblEmpRegister.sInTime = tblSetShiftH.InTime,tblEmpRegister.sOutTime = tblSetShiftH.OutTime," & _
                  " tblEmpRegister.OutDate = CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate Else DateAdd(day,1,tblEmpRegister.atDate) END," & _
                  " tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.ClockIn, " & _
                  " tblEmpRegister.ClockOut = CASE tblEmpRegister.OTApved WHEN 0 THEN CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate Else DateAdd(day,1,tblEmpRegister.atDate)+tblSetshiftH.ClockOut END Else tblEmpRegister.ClockOut END  from tblSetShiftH " & _
                  " INNER JOIN tblEmpRegister ON tblSetShiftH.ShiftID = tblEmpRegister.ShiftID WHERE tblEmpRegister.AtDate Between '" & Format(dtpLRDate.Value, strRetDateTimeFormat) & "' AND '" & Format(dtpMaxDate.Value, strRetDateTimeFormat) & "'"
        FK_EQ(sqlQRY1, "S", "", False, False, False)
        'If MsgBox("Do you want to Update remort location data to the main system ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
        '    LoadForm(New frmDataSync)
        'End If

        'If intBaseOnClockRecord = 0 Then
        '    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE EmpStatus <> 9 Order By RegID", dtpLRDate.Value, dtpMaxDate.Value, pgbPrc, 1, 1)
        'Else
        '    Process_Attendance(dtpLRDate.Value, dtpMaxDate.Value, "", "A", pgbPrc)
        'End If

        Select Case intBaseOnClockRecord
            Case 0
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE EmpStatus <> 9 Order By RegID", dtpLRDate.Value, dtpMaxDate.Value, pgbPrc, 1, 1)
            Case 1
                Process_Attendance(dtpLRDate.Value, dtpMaxDate.Value, "", "A", pgbPrc)
            Case 2
                fk_ProcessStraght(dtpLRDate.Value, dtpMaxDate.Value, pgbPrc, "A", "")
        End Select


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdSave_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.MouseEnter
        sSQL = "SELECT Max(CDate) FROM tblDiMachine"
        Dim dtMaxDatek As Date = fk_RetDate(sSQL)
        dtpMaxDate.Value = dtMaxDatek
        txtCurrent.Text = Format(dtMaxDatek, strDispDateTimeFormat)
    End Sub

End Class