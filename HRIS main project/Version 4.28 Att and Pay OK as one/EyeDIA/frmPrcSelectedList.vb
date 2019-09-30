Imports System.Data.SqlClient

Public Class frmPrcSelectedlist
    Dim intEnrolID As Integer = 0
    Dim StrCatID As String
    Dim StrDeptID As String
    Dim StrDsgID As String

    Dim catSel As String = "0"
    Dim DesgSel As String = "0"
    Dim DeptSel As String = "0"

    Dim dblLateMins As Double = 0 ' fk_sqlDbl("SELECT LateMin FROM tblCompany WHERE compID = '" & StrCompID & "'")
    Dim dblOTRound As Double = 0
    Dim dblMinOT As Double = 0
    Dim intOTRndOption As Integer = 0

    Dim StrSelection As String

    'Private Sub cmdBrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrs.Click
    '    Dim frmBrsC As New frmSrchEmployee
    '    frmBrsC.ShowDialog()


    '    Dim cnOpn As New SqlConnection(sqlConString)
    '    cnOpn.Open()
    '    Try
    '        Dim cmOpn As New SqlCommand("SELECT * FROM tblEmployee WHERE REgID = '" & StrEmployeeID & "'", cnOpn)
    '        Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
    '        If drOpn.Read = True Then
    '            txtEmpID.Text = IIf(IsDBNull(drOpn.Item("RegID")), "", drOpn.Item("RegID"))
    '            txtEmpName.Text = IIf(IsDBNull(drOpn.Item("dispName")), "", drOpn.Item("dispName"))
    '            intEnrolID = IIf(IsDBNull(drOpn.Item("EnrolNo")), 0, drOpn.Item("EnrolNo"))

    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        cnOpn.Close()
    '    End Try


    'End Sub

    Dim maxVal As Integer = 0
    Dim minVal As Integer = 0
    Dim IntVal As Integer = 0

    Dim cYear As Integer
    Dim cMonth As Integer

    Private Sub chkCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCat.CheckedChanged
        If chkCat.CheckState = CheckState.Checked Then
            cmbCat.Enabled = True
            catSel = "1"
        Else
            cmbCat.Enabled = False
            catSel = "0"
        End If
    End Sub

    Private Sub chkDesig_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesig.CheckedChanged
        If chkDesig.CheckState = CheckState.Checked Then
            cmbDesg.Enabled = True
            DesgSel = "1"
        Else
            cmbDesg.Enabled = False
            DesgSel = "0"
        End If
    End Sub

    Private Sub chkDept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDept.CheckedChanged
        If chkDept.CheckState = CheckState.Checked Then
            cmbDept.Enabled = True
            DeptSel = "1"
        Else
            cmbDept.Enabled = False
            DeptSel = "0"
        End If
    End Sub

    Private Sub frmAttnProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        'Dim sqlTable As String = ""
        'sqlTable = " CREATE PROCEDURE sp_ResManualAdj ( @st DateTime ,@Ed DateTime )" & _
        '" AS BEGIN CREATE TABLE #TblM (EmpID Nvarchar (6),AtDate DateTime, InTime DateTime, OutTime DateTime,OutDate DateTime, InUpdate numeric (18,0),OutUpdate Numeric (18,0))" & _
        '" INSERT INTO #TblM select tblAtnManualAdj.EmpID,tblAtnManualAdj.AtDate,tblAtnManualAdj.MinTime, tblAtnManualAdj.mOutTime,tblAtnManualAdj.mOutDate,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate from tblAtnManualAdj,tblEmpRegister where tblEmpRegister.EmpID = tblAtnManualAdj.EmpID AND tblEmpRegister.AtDate = tblAtnManualAdj.AtDate AND tblAtnManualAdj.atdate between @st AND @ed AND tblAtnManualAdj.Status = 1 AND tblEmpRegister.AntStatus = 1" & _
        '" UPDATE tblEmpRegister SET tblEmpRegister.InTime1 = CASE WHEN #TblM.InUpdate = 1 THEN Convert(Nvarchar(5),#TblM.InTime,108) ELSE tblEmpRegister.InTime1 END,tblEmpRegister.OutTime1 = CASE WHEN #TblM.OutUpdate = 1 THEN Convert(Nvarchar(5),#TblM.OutTime,108) ELSE tblEmpRegister.OutTime1 END,tblEmpRegister.InUpdate = #TblM.InUpdate,tblEmpRegister.OutUpdate = #tblM.OutUpdate,tblEmpRegister.AntStatus = #tblM.InUpdate FROM tblEmpRegister,#tblM WHERE tblEmpRegister.EmpID = #tblM.EmpID AND tblEmpRegister.AtDate=#tblM.AtDate END"
        'FK_EQ(sqlTable, "S", "", False, False, False)

        cYear = Year(dtWorkingDate)
        cMonth = Month(dtWorkingDate)

        cmdYear.Text = cYear.ToString
        cmdMonth.Text = MonthName(cMonth)

        'Select date Information from the Main table 

        'If employee information are not cleared then get the employee detail from the main menu

        txtEmpID.Text = StrEmployeeID
        'Get the Employee Name 
        txtEmpName.Text = fk_RetString("SELECT dispName FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "'")

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

        cmdRefresh_Click(sender, e)

        If strKEmployeeID <> "" Then
            txtSearch.Text = strKEmployeeID
        End If

    End Sub

    Public Sub Exe_Qry(ByVal sqlQRY As String)
        Dim cnExe As New SqlConnection(sqlConString)
        cnExe.Open()
        Dim cmExe As New SqlCommand(sqlQRY, cnExe)

        cmExe.ExecuteNonQuery()

    End Sub

    Public Sub EmployeeSearch()

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.EnrolNo" Else sqlTag = "tblEmployee.EmpNo"

        Dim strQuery As String = "select  'true',dbo.tblEmployee.RegID,dbo." & sqlTag & ", dbo.tblEmployee.dispName," & _
        "dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 FROM dbo.tblEmployee " & _
        "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID " & _
        "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID " & _
        "LEFT OUTER JOIN dbo.tblSetTitle ON dbo.tblSetTitle.titleID=dbo.tblemployee.TitleID " & _
        "LEFT OUTER JOIN dbo.tblSEtEmpCategory ON dbo.tblSEtEmpCategory.CatID=dbo.tblEmployee.CatID " & _
        "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9  AND tblEmployee.DeptID In ('" & StrUserLvDept & "') AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblCBranchs.BrName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetEmpType.tDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetTitle.titleDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSEtEmpCategory.CatDesc LIKE '%" & txtSearch.Text & "%') " & _
        "order by " & sqlTag & ""

        Load_InformationtoGrid(strQuery, dgvEmps, 7)
        clr_Grid(dgvEmps)

        Label8.Text = "Employees in List : " & dgvEmps.RowCount

    End Sub

    '' ''Public Sub Process_Search()

    '' ''    Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
    '' ''    Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else sqlTag = "tblEmployee.enrolNo"

    '' ''    Dim strQuery As String = "select  'false',dbo.tblEmployee.RegID,dbo." & sqlTag & ", dbo.tblEmployee.dispName," & _
    '' ''    "dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 FROM dbo.tblEmployee " & _
    '' ''    "INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
    '' ''    "INNER JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
    '' ''    "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
    '' ''    "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
    '' ''    "dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
    '' ''    "dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
    '' ''    "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR " & _
    '' ''    "dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%' OR " & _
    '' ''    "dbo.tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%') " & _
    '' ''    "order by " & sqlTag & ""

    '' ''    Load_InformationtoGrid(strQuery, dgvEmps, 7)
    '' ''    clr_Grid(dgvEmps)

    '' ''    lblCount.Text = "Total Employees : " & dgvEmps.RowCount

    ''        StrSelection = catSel & DesgSel & DeptSel
    ''        StrCatID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbCat.Text & "'")
    ''        StrDesgID = fk_RetString("SELECT desgID FROM tblDesig WHERE DesgDesc = '" & cmbDesg.Text & "'")
    ''        StrDeptID = fk_RetString("SELECT DeptID FROM tblSetDept WHERE DeptName = '" & cmbDept.Text & "'")
    ''        Dim sqlQRY As String = ""

    ''        Select Case StrSelection
    ''            Case "000"
    ''                sqlQRY = "SELECT     'false',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9"
    ''            Case "001"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DeptID = '" & StrDeptID & "'"
    ''            Case "011"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DeptID = '" & StrDeptID & "' AND tblEmployee.DesigID = '" & StrDesgID & "'"
    ''            Case "111"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig. INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DeptID = '" & StrDeptID & "' AND tblEmployee.DesigID = '" & StrDesgID & "' AND tblEmployee.CatID = '" & StrCatID & "'"
    ''            Case "110"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DesigID = '" & StrDesgID & "' AND tblEmployee.CatID = '" & StrCatID & "'"
    ''            Case "100"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.CatID = '" & StrCatID & "'"
    ''            Case "010"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID,tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DesigID = '" & StrDesgID & "'"
    ''        End Select

    ''        Load_InformationtoGrid(sqlQRY, dgvEmps, 7)

    'End Sub

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

    'Private Function fk_RetMonthName(ByVal intMNo As Integer) As String
    '    Dim StrRes As String
    '    Select Case intMNo
    '        Case 1

    '        Case 2

    '        Case 3

    '        Case 4

    '        Case 5

    '        Case 6

    '        Case 7

    '        Case 8

    '        Case 9

    '        Case 10

    '        Case 11

    '        Case 12

    '    End Select

    'End Function


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

    Private Sub cmdProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcess.Click
        Dim StrEmpAll As String = "" ' All Employees selected in the grid 
        Me.Cursor = Cursors.WaitCursor
        pgbPrc.Minimum = 0
        pgbPrc.Maximum = fk_sqlDbl("SELECT Count(*) FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year (AtDate) = " & cYear & "")
        pgbPrc.Value = 0
        Dim bolSelect As Boolean
        'Select the Checked Employee list 
        With dgvEmps
            For iRs As Integer = 0 To .RowCount - 1
                bolSelect = .Item(0, iRs).Value
                If bolSelect = True Then
                    If StrEmpAll = "" Then
                        StrEmpAll = .Item(1, iRs).Value
                    Else
                        StrEmpAll = StrEmpAll & "'" & "," & "'" & .Item(1, iRs).Value
                    End If
                End If
            Next
        End With


        cYear = CInt(cmdYear.Text)
        cMonth = fk_RetMonthNumber(cmdMonth.Text)

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

        'Load Night shift Employees to the Grid from the AtTmp Table
        '        Dim sqlQ As String = "select AtTmp.*,tmp.ShiftMode,tmp.ShiftID,tmp.ClockIn,tmp.ClockOut from AtTmp " & _
        '" INNER JOIN tmp ON AtTmp.RegID = tmp.RegID and AtTmp.CheckDate = tmp.AtDate WHERE tmp.ShiftMode = 1 AND Month(atTmp.AtDate) = " & cMonth & " AND Year(atTmp.AtDate) = " & cYear & " Order By tmp.RegID"




        '        Load_InformationtoGrid(sqlQ, dgvNight, 9)
        '        Panel2.Controls.Clear()
        '        Panel2.Controls.Add(dgvNight)
        '        dgvNight.Dock = DockStyle.Fill

        'check the attendance for the data
        Dim StrTemp As String
        Dim dtTAtn As Date
        Dim dtOutDate As Date
        Dim InTime As DateTime
        Dim OutTime As DateTime
        'Dim clcIn As DateTime
        'Dim clcOut As DateTime
        Dim EmpSt As Boolean = False
        Dim MaxAtDate As Date
        Dim newAtTime As DateTime
        Dim intShMode As Integer
        Dim dtHalfDay As DateTime

        MaxAtDate = dtpToDate.Value ' fk_RetDate("SELECT Max(cDate) FROM tblDiMachine WHERE Year(cDate) = " & cYear & " AND Month(cDate) = " & cMonth & "")

        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlOpn As String = ""
        If optSelMonth.Checked = True Then
            sqlOpn = "select tblEmpRegister.EMpID,tblEmpRegister.CMonth,tblEmpRegister.cYear,tblEmpRegister.Atdate,tblSetShiftH.ShiftMode,tblSetShiftH.ShiftID,tblSetShiftH.ClockIn,tblSetShiftH.ClockOut,tblSetShiftH.hasMeal,tblSetShiftH.HalfDay" & _
 " from tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID" & _
" where tblEmpRegister.cMonth = " & cMonth & " AND tblEmpRegister.cYear = " & cYear & " AND tblEmpRegister.EMpID IN ('" & StrEmpAll & "') Order By tblEmpregister.EmpID,tblEmpRegister.AtDate"
        ElseIf optPeriod.Checked = True Then
            sqlOpn = "select tblEmpRegister.EMpID,tblEmpRegister.CMonth,tblEmpRegister.cYear,tblEmpRegister.Atdate,tblSetShiftH.ShiftMode,tblSetShiftH.ShiftID,tblSetShiftH.ClockIn,tblSetShiftH.ClockOut,tblSetShiftH.hasMeal,tblSetShiftH.HalfDay" & _
 " from tblEmpRegister INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID" & _
" where tblEmpRegister.AtDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.EMpID IN ('" & StrEmpAll & "') Order By tblEmpregister.EmpID,tblEmpRegister.AtDate"

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
                           " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblDiMachine.cTime <= '" & dtHalfDay & "' AND tblEmployee.RegID = '" & StrTemp & "'")


                            'Check for the existing record in the Attendance History
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'IN'")
                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                        'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'")
                                        cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'", cnExe)
                                        cmExe.ExecuteNonQuery()
                                    End If
                                End If

                            End If
                            newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblDiMachine.cTime > '" & DateAdd(DateInterval.Minute, intMinWorkMin, newAtTime) & "' AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'OT'")

                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "OT", "A", "1")
                                        'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'")
                                        cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'", cnExe)
                                        cmExe.ExecuteNonQuery()
                                    End If
                                End If
                            End If

                            'Only Meal calculating only for the day shift, it's not coded for the night shift/24 hour shifts
                            If IsMealAvbl = 1 Then
                                If intHasMeal = 1 Then
                                    newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                              " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                              " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND tblDiMachine.cTime >= '" & dtmealStat & "'  AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")

                                    'Check for the existing record in the Attendance History
                                    bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'LO'")
                                    If newAtTime <> DateSerial(1900, 1, 1) Then
                                        If dtTAtn <= MaxAtDate Then
                                            If bolExR = False Then
                                                dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "LO", "L", "1")
                                                'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'")
                                                cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'", cnExe)
                                                cmExe.ExecuteNonQuery()
                                            End If
                                        End If

                                    End If
                                    newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                                    " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                                    " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND (tblDiMachine.cTime >=  '" & dtmealStat & "' AND tblDiMachine.cTime <=  '" & dtMealClose & "' AND tblDiMachine.cTime >= '" & DateAdd(DateInterval.Minute, 10, newAtTime) & "' ) AND tblEmployee.RegID = '" & StrTemp & "' AND tblDiMachine.Capture = 0")

                                    bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'LI'")

                                    If newAtTime <> DateSerial(1900, 1, 1) Then
                                        If dtTAtn <= MaxAtDate Then
                                            If bolExR = False Then
                                                dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, OutTime, "LI", "L", "1")
                                                'Exe_Qry("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'")
                                                cmExe = New SqlCommand("UPDATE tblDiMachine SET Capture = 1 WHERE cTime = '" & newAtTime & "' AND cDate = '" & Format(dtTAtn, "yyyyMMdd") & "'", cnExe)
                                                cmExe.ExecuteNonQuery()
                                            End If
                                        End If
                                    End If
                                End If
                            End If

                        Case 1
                            newAtTime = fk_RetDateTime("select min(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'IN'")

                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                    End If

                                End If
                            End If

                            newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtOutDate, "yyyyMMdd") & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")

                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'OT'")
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
                            " WHERE tblDiMachine.cDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND tblDiMachine.cTime >= '" & InTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")
                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'IN'")

                            If newAtTime <> DateSerial(1900, 1, 1) Then
                                If dtTAtn <= MaxAtDate Then
                                    If bolExR = False Then
                                        dgvSetNight.Rows.Add(StrTemp, dtTAtn, dtTAtn, newAtTime, InTime, "IN", "A", "1")
                                    End If

                                End If
                            End If

                            newAtTime = fk_RetDateTime("select Max(tblDiMachine.cTime) FROM tblDiMachine " & _
                            " INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID " & _
                            " WHERE tblDiMachine.cDate = '" & Format(dtOutDate, "yyyyMMdd") & "' AND tblDiMachine.cTime <=  '" & OutTime & "' AND tblEmployee.RegID = '" & StrTemp & "'")

                            bolExR = fk_CheckEx("SELECT * FROM tblAtnHist WHERE RegID = '" & StrTemp & "' AND AtDate = '" & Format(dtTAtn, "yyyyMMdd") & "' AND InOut = 'OT'")
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
        'Dim iCol As Integer
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

        'Panel3.Controls.Clear()
        'Panel3.Controls.Add(dgvSetNight)
        'dgvSetNight.Dock = DockStyle.Fill


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
            sqlQRY = "DELETE FROM AtTmp WHERE AtDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND RegID  IN ('" & StrEmpAll & "')"
        ElseIf optSelMonth.Checked = True Then
            sqlQRY = "DELETE FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year(AtDate) = " & cYear & " AND RegID IN ('" & StrEmpAll & "')"
        End If

        cmSave.CommandText = sqlQRY
        cmSave.ExecuteNonQuery()
        pgbPrc.Value = 0
        Try
            With dgvSetNight
                minVal = 0
                maxVal = .RowCount
                IntVal = 0
                pgbPrc.Maximum = maxVal
                pgbPrc.Minimum = minVal

                For iRw = 0 To .RowCount - 2
                    st = .Item(7, iRw).Value
                    If st = 1 Then
                        sqlQRY = "INSERT INTO AtTmp (regID,AtDate,CheckDate,CheckTime,INOUT) VALUES ('" & .Item(0, iRw).Value & "', " & _
                        " '" & Format(CDate(.Item(1, iRw).Value), "yyyyMMdd") & "','" & Format(CDate(.Item(2, iRw).Value), "yyyyMMdd") & "','" & CDate(.Item(3, iRw).Value) & "','" & .Item(5, iRw).Value & "')"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()

                    End If

                    IntVal = IntVal + 1
                    pgbPrc.Value = IntVal

                Next
            End With

            'This is reposes, so need to delete the same information for the selected month before insert again
            'sqlQRY = "DELETE FROM tblMovements WHERE EmpID = " & intEnrolID & " AND Month(cdate) = " & cMonth & " AND Year (cDate) = " & cYear & ""
            'cmSave.CommandText = sqlQRY
            'cmSave.ExecuteNonQuery()

            ''Backup Movement infomration 

            'sqlQRY = "insert into tblMovements " & _
            '" Select MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode from tblDiMachine where cDate not in (select cDate from tblMovements) "

            'cmSave.CommandText = sqlQRY
            'cmSave.ExecuteNonQuery()

            'clear tblEmpRegiser for the selected date range for the selected Employee
            sqlQRY = "UPDATE tblEmpRegister SET tblEMpRegister.sInTime = tblSetShiftH.InTime, tblEmpRegister.sOutTime = CASE tblDayType.WorkUnit WHEN .5 THEN tblSetShiftH.HalfDay ELSE tblSetShiftH.OutTime END FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID  WHERE tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID IN ('" & StrEmpAll & "')"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "update tblEmpRegister SET InDate = '',InTime1 = '',OutDate = '',OutTime1 = '',InTime2 = '',OutTime2 = '',AntStatus =0,IsLate =0,IsEarly =0,IsLeave =0,IsoffdayWork =0,IsNightWork =0,InUpdate =0,OutUpdate=0,BeginOt = 0,EndOt =0 WHERE EmpID In ('" & StrEmpAll & "') AND AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Update In/Out Times in the system 
            sqlQRY = "update tblEmpRegister SET AntStatus = 1,InUpdate = 1,tblEmpRegister.InDate = AtTmp.CheckDate, tblEmpRegister.InTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'IN' AND tblEmpRegister.InUpdate In (0) " & _
            " update tblEmpRegister SET AntStatus = 1,OutUpdate = 1,tblEmpRegister.OutDate = AtTmp.CheckDate, tblEmpRegister.OutTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'OT' AND tblEmpRegister.OutUpdate In (0)"
            If IsMealAvbl = 1 Then
                sqlQRY = sqlQRY & " update tblEmpRegister SET tblEmpRegister.InTime2 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'LI'"
                sqlQRY = sqlQRY & " update tblEmpRegister SET tblEmpRegister.OutTime2 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'LO'"
            End If
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            trSave.Commit()
            'Phase 2 Started

            sqlQRY = ""
            sqlQRY = "update tblEmpRegister SET tblEmpRegister.WorkMins = CASE WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE DateDiff(minute,tblEmpRegister.AtDate+tblEmpRegister.InTime1,tblEmpRegister.OutDate+tblEmpRegister.OutTime1) END," & _
          " IsLate = 0," & _
          " tblEmpRegister.LateMins = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.sInTime,tblEmpRegister.InTime1) - " & dblLateMins & " < 0 THEN 0 Else DateDiff(minute,tblEmpRegister.sInTime,tblEmpRegister.InTime1) - " & dblLateMins & "  END," & _
          " IsEarly = 0," & _
          " tblEmpRegister.EarlyMins = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN  tblEmpRegister.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.OutTime1,tblEmpRegister.sOutTime) <0 THEN 0 Else DateDiff(minute,tblEmpRegister.OutTime1,tblEmpRegister.sOutTime) END," & _
          " tblEmpRegister.BeginOT = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblSetEmpCategory.OTAllc = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.InTime1,tblEmpRegister.sInTime) < 0 THEN 0 Else DateDiff(minute,tblEmpRegister.InTime1,tblEmpRegister.sInTime) END," & _
          " tblEmpRegister.EndOT = CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblSetEmpCategory.OTAllc = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblEmpRegister.sOutTime,tblEmpRegister.OutTime1) < 0 THEN 0 Else  DateDiff(minute,tblEmpRegister.sOutTime,tblEmpRegister.OutTime1) END," & _
          " tblEmpRegister.IsOffdayWork = CASE WHEN tblEmpRegister.ShiftID = '999' AND tblEmpRegister.AntStatus = 1 THEN 1 ELSE 0 END " & _
          " from tblEmpRegister " & _
          " INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID " & _
          " INNER JOIN tblEmployee ON tblEmpRegister.EmpID  = tblEmployee.RegID " & _
          " INNER JOIN tblSetEmpCategory ON tblEmployee.CatID = tblSetEmpCategory.CatID " & _
          " INNER JOIN tblDayTYpe ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AntStatus = 1 AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.EmpID In ('" & StrEmpAll & "')"

            'Update Late & Early Status 
            sqlQRY = sqlQRY & " update tblEmpRegister SET WorkHrs = CASE WHEN WorkHrs < 0 THEN 0 Else Round(WorkMins/60,2) End,isLate = CASE  WHEN LateMins <=0 THEN 0 Else 1 END,isEarly = CASE  WHEN EarlyMins <= 0 THEN 0 Else 1 End WHERE atDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID In ('" & StrEmpAll & "')"

            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET BgOTHrs = CASE  WHEN BeginOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN floor(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & " Else Round(ceiling(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID In ('" & StrEmpAll & "')"

            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET EdOTHrs = CASE  WHEN EndOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",1) Else Round(ceiling(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND EmpID In ('" & StrEmpAll & "')"

            FK_EQ(sqlQRY, "P", "", False, True, True)
            'sqlQRY = "update tblEmpRegister SET AntStatus = 1,InUpdate = 1,tblEmpRegister.InDate = AtTmp.CheckDate, tblEmpRegister.InTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'IN' AND tblEmpRegister.EmpID In ('" & StrEmpAll & "') AND AtTmp.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.InUpdate In (0) " & _
            '" update tblEmpRegister SET AntStatus = 1,OutUpdate = 1,tblEmpRegister.OutDate = AtTmp.CheckDate, tblEmpRegister.OutTime1 = AtTmp.CheckTime from AtTmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = AtTmp.RegID AND tblEmpRegister.AtDate = AtTmp.AtDate where AtTmp.InOut = 'OT' AND tblEmpRegister.EmpID In ('" & StrEmpAll & "') AND AtTmp.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.OutUpdate In (0)"
            'cmSave.CommandText = sqlQRY
            'cmSave.ExecuteNonQuery()

            'MsgBox("Process Completed", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
            Me.Cursor = Cursors.Default
        End Try

        Dim dgvAtnSum As DataGridView
        dgvAtnSum = New DataGridView
        Dim sqlQR As String = ""

        Dim dtPAtDate As Date

        Dim StrPEmpID As String
        Dim StrPSt As String = "P"
        Dim iRn As Integer

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
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],dbo.fk_RetDate(RegID,AtDate,'LO','02') As [Meal Out],dbo.fk_RetDate(RegID,AtDate,'LI','02') As [Meal IN],'P' from AtTmp WHERE AtDate >= '" & Format(dtLastProcess, "yyyyMMdd") & "' AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) AND RegID = '" & StrEmployeeID & "' group by RegID,AtDate"

            ElseIf optSelMonth.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],dbo.fk_RetDate(RegID,AtDate,'LO','02') As [Meal Out],dbo.fk_RetDate(RegID,AtDate,'LI','02') As [Meal IN],'P' from AtTmp WHERE  Year(AtDate) = " & cYear & " AND Month(AtDate) = " & cMonth & " AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) AND regID = '" & StrEmployeeID & "' group by RegID,AtDate"
            End If

            'CONVERT(varchar, AtDate, 105) As AtDate
            Load_InformationtoGrid(sqlQR, dgvAtnSum, 9)

            With dgvAtnSum

                For iRn = 0 To .RowCount - 2

                    StrPEmpID = .Item(0, iRn).Value
                    dtPAtDate = CDate(.Item(1, iRn).Value)
                    Dim StrPInDate As String = .Item(2, iRn).Value
                    Dim StrPInTime As String = .Item(3, iRn).Value
                    Dim StrPoutDate As String = .Item(4, iRn).Value
                    Dim StrPOutTime As String = .Item(5, iRn).Value

                    Dim iCols As Integer
                    If StrPInDate = "" Or StrPoutDate = "" Then
                        For iCols = 0 To .Columns.Count - 1
                            .Item(iCols, iRn).Style.BackColor = Color.Yellow
                        Next
                        StrPSt = "E"
                    Else
                        StrPSt = "P"
                    End If

                    .Item(8, iRn).Value = StrPSt

                Next
            End With

        Else
            With dgvAtnSum
                .Columns.Add("EmpID", "Employee ID")            ' - 0
                .Columns.Add("AtDate", "Attendance Date")       ' - 1
                .Columns.Add("InDate", "In Date")               ' - 2
                .Columns.Add("InTime", "In Time")               ' - 3
                .Columns.Add("OutDate", "Out Date")             ' - 4
                .Columns.Add("OutTime", "Out Time")             ' - 5
                .Columns.Add("RStatus", "R Status")             ' - 6

            End With
            If optPeriod.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],'P' from AtTmp WHERE AtDate >= '" & Format(dtLastProcess, "yyyyMMdd") & "' AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) AND regID = '" & StrEmployeeID & "' group by RegID,AtDate"

            ElseIf optSelMonth.Checked = True Then
                sqlQR = "select regID,AtDate,dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date],dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time]," & _
                " dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date],dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],'P' from AtTmp WHERE  Year(AtDate) = " & cYear & " AND Month(AtDate) = " & cMonth & " AND AtDate In (Select AtDate FROM tblEmpRegister WHERE EmpID = RegID AND Status = 1) AND regID = '" & StrEmployeeID & "'  group by RegID,AtDate"
            End If

            'CONVERT(varchar, AtDate, 105) As AtDate
            Load_InformationtoGrid(sqlQR, dgvAtnSum, 7)

            With dgvAtnSum

                For iRn = 0 To .RowCount - 2

                    StrPEmpID = .Item(0, iRn).Value
                    dtPAtDate = CDate(.Item(1, iRn).Value)
                    Dim StrPInDate As String = .Item(2, iRn).Value
                    Dim StrPInTime As String = .Item(3, iRn).Value
                    Dim StrPoutDate As String = .Item(4, iRn).Value
                    Dim StrPOutTime As String = .Item(5, iRn).Value

                    Dim iCols As Integer
                    If StrPInDate = "" Or StrPoutDate = "" Then
                        For iCols = 0 To .Columns.Count - 1
                            .Item(iCols, iRn).Style.BackColor = Color.Yellow
                        Next
                        StrPSt = "E"
                    Else
                        StrPSt = "P"
                    End If

                    .Item(6, iRn).Value = StrPSt

                Next
            End With
        End If

        'Open Tmp table

        'Panel3.Controls.Clear()
        'Panel3.Controls.Add(dgvAtnSum)
        'dgvAtnSum.Dock = DockStyle.Fill

    End Sub

    Public Sub _AtnTime(ByVal Emp As String, ByVal shMode As Integer, ByVal ClckIn As Date, ByVal clcOut As Date)

        Select Case shMode
            Case 0 'Day mode

            Case 1 ' Night mode

        End Select

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

        cYear = CInt(cmdYear.Text)
        cMonth = fk_RetMonthNumber(cmdMonth.Text)
        Dim dtLastProcess As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")

        'Generate report for the selected information 
        Dim sqlQR As String = ""

        If optPeriod.Checked = True Then
            sqlQR = "select regID, AtDate ,Month(AtDate), Year(AtDate),dbo.fk_RetDate(RegID,AtDate,'IN','01') As [In Date]," & _
        " dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time], dbo.fk_RetDate(RegID,AtDate,'OT','01') As [Out Date]," & _
        " dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],AtSt = CASE WHEN (dbo.fk_RetDate(RegID,AtDate,'OT','01') = '' OR dbo.fk_RetDate(RegID,AtDate,'IN','01') = '') THEN 'E' ELSE 'P' END   from AtTmp  WHERE AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND  RegID = '" & StrEmployeeID & "' group by RegID,AtDate"
        ElseIf optSelMonth.Checked = True Then
            sqlQR = "select regID, AtDate,Month(AtDate), Year(AtDate),dbo.fk_RetDateUps(RegID,AtDate,'IN','01') As [In Date], " & _
        " dbo.fk_RetDate(RegID,AtDate,'IN','02') As [In Time], dbo.fk_RetDateUps(RegID,AtDate,'OT','01') As [Out Date]," & _
        " dbo.fk_RetDate(RegID,AtDate,'OT','02') As [Out Time],AtSt = CASE WHEN (dbo.fk_RetDate(RegID,AtDate,'OT','01') = '' OR dbo.fk_RetDate(RegID,AtDate,'IN','01') = '') THEN 'E' ELSE 'P' END   from AtTmp  WHERE  Year(AtDate) = " & cYear & " AND Month(AtDate) = " & cMonth & " AND RegID = '" & StrEmployeeID & "'  group by RegID,AtDate"
        End If

        Dim sqlQRY As String
        Dim cnPrc As New SqlConnection(sqlConString)
        cnPrc.Open()
        Dim cmPrc As New SqlCommand
        cmPrc = cnPrc.CreateCommand
        Dim trPrc As SqlTransaction = cnPrc.BeginTransaction
        cmPrc.Transaction = trPrc
        Try
            sqlQRY = "DELETE FROM tblAtnReport"
            cmPrc.CommandText = sqlQRY
            cmPrc.ExecuteNonQuery()

            sqlQRY = "INSERT INTO tblAtnReport (RegID,AtDate,cMonth,cYear,ChkInDate,ChkInTime,ChkOutDate,ChkOutTime,Status) " & sqlQR
            cmPrc.CommandText = sqlQRY
            cmPrc.ExecuteNonQuery()

            trPrc.Commit()

        Catch ex As Exception
            MsgBox(ex.Message)
            trPrc.Rollback()
        Finally
            cnPrc.Close()
        End Try

        'Opne Report 
        Dim cnOpen As New SqlConnection(sqlConString)
        cnOpen.Open()
        Dim sqlOpen As String = "SELECT * FROM tblReports WHERE RepID = '001'"
        Try
            Dim cmOPen As New SqlCommand(sqlOpen, cnOpen)
            Dim drOpen As SqlDataReader = cmOPen.ExecuteReader
            If drOpen.Read = True Then
                StrRepFile = IIf(IsDBNull(drOpen.Item("RPath")), "", drOpen.Item("RPath"))
                StrRepTitle = IIf(IsDBNull(drOpen.Item("RName")), "", drOpen.Item("RName"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpen.Close()
        End Try

        StrRepFile = StrRepHeadPath & StrRepFile

        If optPeriod.Checked = True Then
            StrSelectionFomula = "{tblAtnReport.RegID} = '" & StrEmployeeID & "' AND {tblAtnReport.AtDate} >= Date(" & Year(dtLastProcess) & "," & Month(dtLastProcess) & "," & CInt(Format(dtLastProcess, "dd")) & ")"
        ElseIf optSelMonth.Checked = True Then
            StrSelectionFomula = "{tblAtnReport.RegID} = '" & StrEmployeeID & "' AND {tblAtnReport.cMonth} = " & cMonth & " AND {tblAtnReport.cYear} = " & cYear & " AND {tblEmployee.CompID} = '" & StrCompID & "'"
        End If

        Dim frmReg As New frmRepContainerAttn

        frmReg.WindowState = FormWindowState.Maximized

        frmReg.ShowDialog()

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click

        'Process_Search()

    End Sub

    Private Sub chkCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheck.CheckedChanged

        With dgvEmps
            For i As Integer = 0 To .RowCount - 1
                .Item(0, i).Value = chkCheck.CheckState
            Next
        End With

    End Sub

    Private Sub cmdnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cmdnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnRefresh.Click

        cmdReport_Click(sender, e)

    End Sub

    Private Sub cmdnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnProcess.Click

        Dim bolisMarked As Boolean = False

        For ik = 0 To dgvEmps.RowCount - 1
            'Dim t As Integer = Val(dgvEmps.Item(0, ik).Value)
            If dgvEmps.Item(0, ik).Value = True Or Val(dgvEmps.Item(0, ik).Value) = 0 Then
                bolisMarked = True
                ik = dgvEmps.RowCount - 1
            End If
        Next

        If bolisMarked = False Then
            MessageBox.Show("Please select at least one Employee", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        End If

        If MsgBox("Do you want to re-process these selected employee(s) ?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim StrEmpAll As String = "" ' All Employees selected in the grid 
        Me.Cursor = Cursors.WaitCursor
        pgbPrc.Minimum = 0
        pgbPrc.Maximum = fk_sqlDbl("SELECT Count(*) FROM AtTmp WHERE Month(AtDate) = " & cMonth & " AND Year (AtDate) = " & cYear & "")
        pgbPrc.Value = 0
        Dim bolSelect As Boolean
        'Select the Checked Employee list 
        With dgvEmps
            For iRs As Integer = 0 To .RowCount - 1
                bolSelect = .Item(0, iRs).Value
                If bolSelect = True Then
                    If StrEmpAll = "" Then
                        StrEmpAll = .Item(1, iRs).Value
                    Else
                        StrEmpAll = StrEmpAll & "'" & "," & "'" & .Item(1, iRs).Value
                    End If
                End If
            Next
        End With

        cYear = CInt(cmdYear.Text)
        cMonth = fk_RetMonthNumber(cmdMonth.Text)

        Dim bolExDate As Boolean = fk_CheckEx("SELECT * FROM tblCalendar WHERE cYear = " & cYear & " AND cMonth = " & cMonth & "")
        If bolExDate = False Then
            MsgBox("Calendar Has not generated, Please generate the Calendar Before the Process !!!", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim sqlQRY1 As String = ""
        '#ISA-099
        'sqlQRY1 = " update tblEmpRegister SET tblEmpRegister.sInTime = tblEmpRegister.AtDate+tblSetShiftH.InTime,tblEmpRegister.sOutTime = CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate+tblSetShiftH.OutTime ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.OutTime END," & _
        '   " tblEmpRegister.OutDate = CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate Else DateAdd(day,1,tblEmpRegister.atDate) END," & _
        '   " tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN, " & _
        '   " tblEmpRegister.ClockOut = CASE tblEmpRegister.OTApved WHEN 0 THEN CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT Else DateAdd(day,1,tblEmpRegister.atDate)+tblSetshiftH.EndCOUT END Else tblEmpRegister.ClockOut END  from tblSetShiftH " & _
        '   " INNER JOIN tblEmpRegister ON tblSetShiftH.ShiftID = tblEmpRegister.ShiftID WHERE tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.EmpID In ('" & StrEmpAll & "')"
        'FK_EQ(sqlQRY1, "S", "", False, False, True)

        'If intBaseOnClockRecord = 0 Then
        '    sSQL = "UPDATE tblEmpRegister SET antStatus=0,InTime1='',outTime='',inUpdate=0,outUpdate=0,isNightWork=0 WHERE regid in ('" & StrEmpAll & "') AND atDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
        '    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmpAll & "') AND EmpStatus <> 9 Order By RegID", dtpFrDate.Value, dtpToDate.Value, pgbPrc, 1, 0)
        'Else
        '    Process_Attendance(dtpFrDate.Value, dtpToDate.Value, StrEmpAll, "O", pgbPrc)
        'End If


        Select Case intBaseOnClockRecord
            Case 0
                sSQL = "UPDATE tblEmpRegister SET antStatus=0,InTime1='',outTime='',inUpdate=0,outUpdate=0,isNightWork=0 WHERE regid in ('" & StrEmpAll & "') AND atDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmpAll & "') AND EmpStatus <> 9 Order By RegID", dtpFrDate.Value, dtpToDate.Value, pgbPrc, 1, 0)
            Case 1
                Process_Attendance(dtpFrDate.Value, dtpToDate.Value, StrEmpAll, "O", pgbPrc)
            Case 2
                fk_ProcessStraght(dtpFrDate.Value, dtpToDate.Value, pgbPrc, "O", StrEmpAll)
        End Select
        Me.Cursor = Cursors.Default

        cmdRefresh_Click(sender, e)


    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        EmployeeSearch()
        'Process_Search()

    End Sub

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged

        txtSearch.Text = cmbDesg.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged

        txtSearch.Text = cmbCat.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged

        txtSearch.Text = cmbDept.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
        'txtSearch.Text = cmbDept.Text

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

        'Load Information 
        ListComboAll(cmbDesg, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "desgDesc")
        'Load Department
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0 Order By DeptID", "deptName")
        'Load Category
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")

        txtSearch.Text = "K"
        txtSearch.Text = ""
        chkCheck.CheckState = CheckState.Unchecked

        Dim dtLastDate As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        dtpFrDate.Value = DateSerial(Year(dtLastDate), Month(dtLastDate), 1)
        dtpToDate.Value = dtLastDate

        'With dgvEmps
        '    For i As Integer = 0 To .RowCount - 1
        '        .Item(0, i).Value = False
        '    Next
        'End With

    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged

        txtSearch.Text = cmbBranch.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged

        txtSearch.Text = cmbType.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTitle.SelectedIndexChanged

        txtSearch.Text = cmbTitle.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub chkTickSelcted_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkTickSelcted.MouseClick
        Try
            For i As Integer = 0 To dgvEmps.RowCount - 1
                If dgvEmps.Item(0, i).Selected = True Then
                    dgvEmps.Item(0, i).Value = chkTickSelcted.CheckState
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class