Imports System.Data.SqlClient
Imports HRISforBB.cls_ExtendadHeadCount

#Region "Information"
'Author         : Kasun 
'Date           : 11/06/2012
'Finised        :
'Details        : Royal FW customer request this report module to view report detail, given the following format to view

#End Region
Public Class frmReportViewer

    Dim dtLastProcessed As Date
    Dim dtFromDate As Date
    Dim dtToDate As Date
    Dim bolLoad As Boolean = True
    Dim strshortlvID As String = ""
    Dim AdvanHRIDDetails As Integer
#Region "Declaration"
    Dim StrSelCategory As String = ""
    Dim StrSelDept As String = ""
    Dim StrSelBranch As String = "" ' Selected Company
    Dim strFormulaFromDB As String = ""
    Dim StrDeptReport As String
    Dim StrCatReport As String
    Dim strDeptID As String = ""
    Dim strBrnchID As String = ""
#End Region

    Private Sub frmReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AdvanHRIDDetails = fk_sqlDbl("select AdvanHRIDDetails from tblControl ")

        '--------- SHOW SPECIAL LABLES ---------
        'Modified By    : Kasun
        'Date           : 19/10/2018
        'Description    : Added new three lables & combos, need to visibale false when required
        '----------------------- START ------------------------------
        If AdvanHRIDDetails = 1 Then
            lblEmpAct.Visible = True : lblEmpSubDept.Visible = True
            cmbEmpAct.Visible = True : cmbEmpSubCat.Visible = True
        Else
            lblEmpAct.Visible = False : lblEmpSubDept.Visible = False
            cmbEmpAct.Visible = False : cmbEmpSubCat.Visible = False
        End If
        '--------------------- END -----------------------------------

        If UP("Report", "View report form") = False Then Exit Sub
        sSQL = "SELECT monthStart from tblControl"
        Dim intMonthStart As Integer = fk_sqlDbl(sSQL)
        'Create table Sele Categoies 
        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)

        Dim sqlTable As String = ""
        'Create table qry

        sqlTable = " DROP TABLE tblSumAttendance" : FK_EQ(sqlTable, "S", "", False, False, False)
        cmdRefresh_Click(sender, e)

        sqlTable = "CREATE TABLE tblSumAttendance (EmpID Nvarchar (6),AtDate DateTime,Total Numeric (18,0),TimeDetail Nvarchar (100),DayQ Nvarchar (10))"
        FK_EQ(sqlTable, "S", "", False, False, False)

    End Sub

    Public Sub proc_AttendanceSummary(ByVal stDate As Date, ByVal EdDate As Date)
        Dim sqlQRY As String = ""
        Dim dtStart As Date
        Dim dtLast As Date
        Dim fYear As Integer = dtpFromDate.Value.Year : Dim fMonth As Integer = dtpFromDate.Value.Month
        If StrReportID = "078" Then
            dtStart = dtpFromDate.Value.Date : dtLast = DateAdd(DateInterval.Day, 15, dtStart)
        Else
            dtStart = DateSerial(fYear, fMonth, 1) : dtLast = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtStart))
        End If

        sqlQRY = " DELETE FROM tblSumAttendance"
        sqlQRY = sqlQRY & " INSERT INTO tblSumAttendance Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,Count(tblEmpRegister.EmpID),'','' from tblEmpRegister,tblEmployee WHERE tblEmpRegister.EmpID = tblEmployee.RegID AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND  '" & Format(dtLast, "yyyyMMdd") & "' GROUP BY tblEmpRegister.EmpID,tblEmpRegister.AtDate"
        'sqlQRY = sqlQRY & " INSERT INTO tblSumAttendance Select EmpID,AtDate,Count(*),'','' from tblEmpRegister WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND  '" & Format(dtLast, "yyyyMMdd") & "' GROUP BY EmpID,AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "UPDATE tblSumAttendance SET DayQ = 'Day'+ Ltrim(Day(AtDate)) "
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Create Cross-Tab   : Table 
        FK_EQ("DROP TABLE tblCrossReport", "S", "", False, False, False)
        Dim sqlQ As String = "CREATE TABLE tblCrossReport (EmpID Nvarchar (6),cYear Numeric (18,0),cMonth Numeric (18,0))"
        FK_EQ(sqlQ, "S", "", False, False, False) : sqlQ = ""

        Dim intDayCount As Integer = DateDiff(DateInterval.Day, dtStart, dtLast)
        Dim StrFldName As String = "" 'Felid Name 
        For i As Integer = 1 To intDayCount + 1
            StrFldName = "Day" & i.ToString
            sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD " & StrFldName & " Nvarchar (100)"
        Next
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD OTDay15 Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD OTDay20 Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD OTDay25 Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD OTDay30 Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD OTAllDays Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD WrkDays Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD NPDays Numeric (18,2) NOT NULL Default 0"
        sqlQ = sqlQ & " ALTER TABLE tblCrossReport ADD LvDays Numeric (18,2) NOT NULL Default 0"

        FK_EQ(sqlQ, "S", "", False, False, True)

        'Update tblEmpRegister Status 
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,IsLeave Numeric (18,0),LvID Nvarchar (3),DayTypeID Nvarchar (2),DaySum Nvarchar (10))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,IsLeave,LeaveID,DayTypeID,'' FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND AntStatus = 0"
        sqlQRY = sqlQRY & " UPDATE #T SET #T.DaySum = #T.DaySum + ' ' + tblLeaveType.ShortCode FROM #T,tblLeaveType WHERE #T.LvID = tblLeaveType.lvID "
        sqlQRY = sqlQRY & " UPDATE #T SET #T.DaySum = #T.DaySum + ' ' + CASE WHEN tblDayType.WorkUnit = 0 OR tblDaytype.isInReport=1 THEN tblDayType.ShortCode ELSE '##' END FROM #T,tblDayType WHERE #T.DayTypeID = tblDayType.TypeID AND #T.IsLeave = 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DaySum = #T.DaySum FROM #T,tblEmpREgister WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)


        If StrReportID = "079" Then
            'Change code to get OT from approved OT table BOC requirement 2017 11 06 Kasun
            sqlQRY = "CREATE TABLE  #APOT (empID NVARCHAR (6),atDate DATETIME,ApNOT NUMERIC (18,2),ApDOT NUMERIC (18,2),ApTOT NUMERIC (18,2),Status NUMERIC (18,0)) INSERT INTO #APOT SELECT empID,atDate,apNOT,ApDOT,apTOT,status FROM tblAprovedOT WHERE atDate BETWEEN '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND status =0"
            sqlQRY = sqlQRY & "CREATE TABLE #TmpProc (EmpID Nvarchar (6),AtDate DateTime,TimeString Nvarchar (50))"
            sqlQRY = sqlQRY & " INSERT INTO #TmpProc Select tblSumAttendance.EMpID,tblSumAttendance.AtDate,CASE WHEN tblEmpRegister.AntStatus = 0 THEN tblEmpRegister.DaySum ELSE  Convert(Nvarchar(10),#APOT.apNOT+#APOT.apDOT+#APOT.apTOT)  + '" & vbCrLf & "' + CASE WHEN tblEmpRegister.inUpdate = 0 OR tblEmpRegister.AntStatus = 0 THEN '**:**' ELSE Convert(Nvarchar (5),tblEmpRegister.InTime1,108) END + '" & vbCrLf & "' + CASE WHEN tblEmpRegister.AntStatus = 0 OR tblEmpRegister.OutUpdate = 0 THEN '**:**' ELSE Convert(Nvarchar(5),tblEmpRegister.OutTime1,108) END END FROM tblEmpRegister INNER JOIN tblSumAttendance ON tblEmpRegister.EmpID = tblSumAttendance.EmpID AND tblEmpRegister.AtDate = tblSumAttendance.AtDate LEFT OUTER JOIN #APOT  ON #APOT.EmpID = tblSumAttendance.EmpID AND #APOT.AtDate = tblSumAttendance.AtDate WHERE tblSumAttendance.Total = 1 "
            sqlQRY = sqlQRY & " UPDATE tblSumAttendance SET tblSumAttendance.TimeDetail = #TmpProc.TimeString FROM #tmpProc INNER JOIN tblSumAttendance  ON tblSumAttendance.EmpID = #TmpProc.EmpID AND tblSumAttendance.AtDate = #TmpProc.AtDate WHERE tblSumAttendance.Total = 1"
            sqlQRY = sqlQRY & " UPDATE tblSumAttendance SET tblSumAttendance.TimeDetail ='0.00' + '" & vbCrLf & "' + Convert(Nvarchar (5),tblEmpRegister.InTime1,108) + '" & vbCrLf & "' + CASE WHEN tblEmpRegister.AntStatus = 0 OR tblEmpRegister.OutUpdate = 0 THEN '**:**' ELSE Convert(Nvarchar(5),tblEmpRegister.OutTime1,108) END  FROM tblSumAttendance,tblEmpRegister WHERE tblSumAttendance.EmpID = tblEmpRegister.EmpID AND tblSumAttendance.AtDate = tblEmpRegister.AtDate AND tblSumAttendance.TimeDetail IS NULL"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        Else
            ' 02. Get the InOut Information for the 1 Marked Employees
            sqlQRY = "CREATE TABLE #TmpProc (EmpID Nvarchar (6),AtDate DateTime,TimeString Nvarchar (50))"
            sqlQRY = sqlQRY & " INSERT INTO #TmpProc Select tblSumAttendance.EMpID,tblSumAttendance.AtDate,CASE WHEN tblEmpRegister.AntStatus = 0 THEN tblEmpRegister.DaySum ELSE Convert(Nvarchar(10),tblEmpRegister.COTHrs) + '" & vbCrLf & "' + CASE WHEN tblEmpRegister.inUpdate = 0 OR tblEmpRegister.AntStatus = 0 THEN '**:**' ELSE Convert(Nvarchar (5),tblEmpRegister.InTime1,108) END + '" & vbCrLf & "' + CASE WHEN tblEmpRegister.AntStatus = 0 OR tblEmpRegister.OutUpdate = 0 THEN '**:**' ELSE Convert(Nvarchar(5),tblEmpRegister.OutTime1,108) END END FROM tblEmpRegister INNER JOIN tblSumAttendance ON tblEmpRegister.EmpID = tblSumAttendance.EmpID AND tblEmpRegister.AtDate = tblSumAttendance.AtDate WHERE tblSumAttendance.Total = 1"
            sqlQRY = sqlQRY & " UPDATE tblSumAttendance SET tblSumAttendance.TimeDetail = #TmpProc.TimeString FROM #tmpProc INNER JOIN tblSumAttendance  ON tblSumAttendance.EmpID = #TmpProc.EmpID AND tblSumAttendance.AtDate = #TmpProc.AtDate WHERE tblSumAttendance.Total = 1"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        End If

        'UPDATE short leaves to report 2017 11 01 Kasun
        sSQL = "CREATE TABLE #T (empID NVARCHAR (6),atDate DATETIME,LeaveID NVARCHAR (3),LvShCode NVARCHAR (3))   INSERT INTO #T    SELECT tblEmpRegister.empID,tblEmpRegister.atDate ,tblEmpRegister.LeaveID,tblLeaveType.shortCode FROM tblEmpRegister,tblSumAttendance,tblLeaveType WHERE tblSumAttendance.EmpID=tblEmpRegister.EmpID AND tblSumAttendance.atDate=tblEmpRegister.atDate AND tblLeaveType.LvID=tblEmpRegister.LeaveID AND tblLeaveType.LvID='" & StrShortSumLvID & "' AND tblEmpRegister.antStatus=1    UPDATE tblSumAttendance SET timeDetail=timeDetail+ ' '+ #T.lvShCode FROM tblSumAttendance,#T WHERE tblSumAttendance.empID=#T.EMPID AND tblSumAttendance.atDate=#T.atDate    " : FK_EQ(sSQL, "S", "", False, False, True)
        'UPDATE half day leaves to report 2017 11 04 Kasun
        sSQL = "CREATE TABLE #T (empID NVARCHAR (6),atDate DATETIME,LeaveID NVARCHAR (3),LvShCode NVARCHAR (3))   INSERT INTO #T    SELECT tblEmpRegister.empID,tblEmpRegister.atDate ,tblEmpRegister.LeaveID,tblLeaveType.shortCode FROM tblEmpRegister,tblSumAttendance,tblLeaveType WHERE tblSumAttendance.EmpID=tblEmpRegister.EmpID AND tblSumAttendance.atDate=tblEmpRegister.atDate AND tblLeaveType.LvID=tblEmpRegister.LeaveID AND tblEmpRegister.antStatus=1 AND tblEmpRegister.NoLeave=0.5   UPDATE tblSumAttendance SET timeDetail=timeDetail+ ' '+ #T.lvShCode FROM tblSumAttendance,#T WHERE tblSumAttendance.empID=#T.EMPID AND tblSumAttendance.atDate=#T.atDate    " : FK_EQ(sSQL, "S", "", False, False, True)

        'Get the Year And   : mont hof t the first date
        Dim iGap As Integer = DateDiff(DateInterval.Day, dtStart, dtLast) + 1
        dtRepGStart = dtStart : dtRepGEnd = dtLast

        Select Case iGap
            Case 28
                strLoadReport = "crosstab28.rpt"
            Case 29
                strLoadReport = "crosstab29.rpt"
            Case 30
                strLoadReport = "crosstab30.rpt"
            Case 31
                strLoadReport = "crosstab31.rpt"
        End Select

        FK_EQ("EXEC sp_RunCrossTab '" & Format(dtStart, "yyyyMMdd") & "','" & Format(dtLast, "yyyyMMdd") & "','" & CStr(dtStart.Year) & "','" & CStr(dtStart.Month) & "'", "S", "", False, False, True)

        'Update Total OT

        'Update Days        : Summary
        sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AllDays Numeric (18,2),D15 Numeric (18,2),D2 Numeric (18,2),D25 Numeric (18,2),D3 Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #Tmp  SELECT EmpID,Sum(NrWorkDay),Sum(cOTHrs),Sum(DoubleOTHrs),0,Sum(TripleOTHrs) FROM tblEmpRegister WHERE atDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' GROUP By EmpID "
        sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.OTAllDays = #Tmp.AllDays,tblCrossReport.OTDay15 = #Tmp.D15,tblCrossReport.OTDay20 = #Tmp.D2 ,tblCrossReport.OTDay25 = #Tmp.D25, tblCrossReport.OTDay30 = #Tmp.D3 FROM tblCrossReport,#Tmp WHERE tblCrossReport.EmpID = #Tmp.EmpID"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        If StrReportID = "079" Then
            'Update Days        : Summary
            sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AllDays Numeric (18,2),D15 Numeric (18,2),D2 Numeric (18,2),D25 Numeric (18,2),D3 Numeric (18,2))"
            sqlQRY = sqlQRY & " INSERT INTO #Tmp  SELECT EmpID,count(atDate),CASE WHEN status = 0 THEN Sum(apNot) ELSE 0 END ,CASE WHEN status = 0 THEN Sum(apDOT) ELSE 0 END,0,CASE WHEN status = 0 THEN Sum(apTOT) ELSE 0 END FROM tblAprovedOT WHERE atDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND tblAprovedOT.status=0 GROUP By EmpID,status "
            sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.OTAllDays = #Tmp.AllDays,tblCrossReport.OTDay15 = #Tmp.D15+#Tmp.D2+#Tmp.D25,tblCrossReport.OTDay20 = #Tmp.D2 ,tblCrossReport.OTDay25 = #Tmp.D25, tblCrossReport.OTDay30 = #Tmp.D3 FROM tblCrossReport,#Tmp WHERE tblCrossReport.EmpID = #Tmp.EmpID"
            FK_EQ(sqlQRY, "S", "", False, False, True)

        Else
            'Update Days        : Summary
            sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AllDays Numeric (18,2),D15 Numeric (18,2),D2 Numeric (18,2),D25 Numeric (18,2),D3 Numeric (18,2))"
            sqlQRY = sqlQRY & " INSERT INTO #Tmp  SELECT EmpID,Sum(NrWorkDay),Sum(cOTHrs),Sum(DoubleOTHrs),0,Sum(TripleOTHrs) FROM tblEmpRegister WHERE atDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' GROUP By EmpID "
            sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.OTAllDays = #Tmp.AllDays,tblCrossReport.OTDay15 = #Tmp.D15,tblCrossReport.OTDay20 = #Tmp.D2 ,tblCrossReport.OTDay25 = #Tmp.D25, tblCrossReport.OTDay30 = #Tmp.D3 FROM tblCrossReport,#Tmp WHERE tblCrossReport.EmpID = #Tmp.EmpID"
            FK_EQ(sqlQRY, "S", "", False, False, True)

        End If
        'Update Working     : Days AND Absent Days 
        sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),WorkedDays Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #Tmp SELECT tblEmpRegister.EmpID,Sum(tblDayType.WorkUnit) FROM tblDayType,tblEmpRegister WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND tblEmpRegister.AntStatus = 1 GROUP By tblEmpRegister.EmpID"
        sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.WrkDays = #Tmp.WorkedDays FROM tblCrossReport,#Tmp WHERE tblCrossReport.EmpID = #Tmp.EmpID"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Kongahawaththa want to view actual nrWorkdays in this Report
        If ISViewActualWorkDayInSummary = 1 Then
            sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),WorkedDays Numeric (18,2))"
            sqlQRY = sqlQRY & " INSERT INTO #Tmp SELECT tblEmpRegister.EmpID,Sum(nrWorkday) FROM tblEmpRegister WHERE  tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' GROUP By tblEmpRegister.EmpID"
            sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.WrkDays = #Tmp.WorkedDays FROM tblCrossReport,#Tmp WHERE tblCrossReport.EmpID = #Tmp.EmpID"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        End If

        'Get the Taken      : Leave for the Period 
        'sqlQRY = " CREATE TABLE #Tmp (EmpID Nvarchar (6),NoLeave Numeric (18,2))"
        'sqlQRY = sqlQRY & " SELECT EmpID,Sum(NoLeave) FROM tblLeaveTRD,tblLeaveTRH WHERE tblLeaveTRH.RqID = tblLeaveTRD.RqID AND tblLeaveTRH.EmpID AND tblLeaveTRD.EmpID AND tblLeaveTRD.LvDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "'  GROUP By EmpID"
        'sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.LvDays = #Tmp.NoLeave FROM tblCrossReport,#Tmp WHERE tblCrossReport.EmpID = #Tmp.EmpID"
        'FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update NOPAY Days  : 
        'Dim dtblWorkDays As Double = fk_sqlDbl("SELECT Sum(tblDayType.WorkUnit) FROM tblEmpRegister,tblDayType WHERE tblCalendar.DayType = tblDayType.TypeID AND tblCalendar.[Date] Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "'")
        'sqlQRY = "UPDATE tblCrossReport SET NpDays = " & dtblWorkDays & ""
        'sqlQRY = "CREATE TABLE #T (EmpID Nvarchar(6),NWork Numeric (18,2))"
        'sqlQRY = sqlQRY & " INSERT INTO #T Select tblEmpRegister.EmpID,Sum(tblDayType.WorkUnit) FROM tblEmpRegister,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' GROUP By tblEmpRegister.EmpID"
        'sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.NpDays = #T.NWork FROM #T,tblCrossReport WHERE #T.EMpID = tblCrossReport.EmpID"
        'FK_EQ(sqlQRY, "S", "", False, False, True)

        'sqlQRY = "UPDATE tblCrossReport SET LvDays = CASE WHEN NpDays - WrkDays < 0 THEN 0 ELSE NpDays - WrkDays END" : FK_EQ(sqlQRY, "S", "", False, False, True)

        '5/7/2016 Due to Galpadithanna request made the modification to LvDays to update total absent accoring to his leave
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),MonthDays Numeric (18,2),PrDays Numeric (18,2),AbsDays Numeric (18,2),lvDays NUMERIC (18,0))"
        sqlQRY = sqlQRY & "INSERT INTO #T Select EmpID,DateDiff(Day,'" & Format(dtStart, "yyyyMMdd") & "','" & Format(dtLast, "yyyyMMdd") & "')+1,Sum(AntStatus),0,0 FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' GROUP By EmpID"
        sqlQRY = sqlQRY & " CREATE TABLE #TK (EmpID Nvarchar (6),lvDays Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #TK Select EmpID,Sum(noLeave) FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND leaveID<>'" & StrShortSumLvID & "' GROUP By EmpID"
        sqlQRY = sqlQRY & " UPDATE #T SET lvDays = #TK.lvDays FROM #TK,#T WHERE #T.EmpID=#TK.EmpID"
        'sqlQRY = sqlQRY & " UPDATE #T SET AbsDays = CASE WHEN MonthDays - (PrDays+lvDays) < 0 THEN 0 ELSE MonthDays - (PrDays+lvDays) END"
        sqlQRY = sqlQRY & " UPDATE #T SET AbsDays =lvDays"
        sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.LvDays = #T.AbsDays FROM #T,tblCrossReport WHERE #T.EmpID = tblCrossReport.EmpID "
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update NpDays his Late Days 
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar(6),NoVal Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,Count(EmpID) FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND IsLate = 1 GROUP by tblEmpRegister.EmpID"
        sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.NpDays = #T.NoVal FROM #T,tblCrossReport WHERE #T.EMpID = tblCrossReport.EmpID"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        sqlQ = "ALTER TABLE tblCrossReport ADD EmpName nvarchar (100) NOT Null Default ''" : FK_EQ(sqlQ, "S", "", False, False, False)

        sqlQRY = "UPDATE tblCrossReport SEt tblCrossReport.EmpName = tblEmployee.DispName FROM tblEmployee,tblCrossReport WHERE tblEmployee.RegID = tblCrossReport.EmpID" : FK_EQ(sqlQRY, "S", "", False, False, True)
        ''---- MODIFIED ON   : 28/11/2013 
        ''DESCRIPTION        : Update Worked Nightshift to the Cross Report
        'sqlQRY = "ALTER TABLE tblCrossReport ADD NoNights  Numeric (18,2) NOT NULL Default 0"
        'sqlQRY = sqlQRY & " CREATE TABLE #T (EmpID Nvarchar (6),NoDays Numeric (18,2))"
        'sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,Count(tblEmpRegister.EmpID) FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtLast, "yyyyMMdd") & "' AND tblSetShiftH.ShiftMode =1 AND tblEmpRegister.AntStatus = 1 GROUP BY tblEmpRegister.EmpID "
        'sqlQRY = sqlQRY & " UPDATE tblCrossReport SET tblCrossReport.NoNights = #T.NoDays FROM #T,tblCrossReport WHERE #T.EmpID = tblCrossReport.EmpID"
        'FK_EQ(sqlQRY, "S", "", False, False, True)

        dtpFromDate.Value = dtStart
        dtpToDate.Value = dtLast

    End Sub

    Public Sub SearchEmployee()

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag1 As String : If IsEpf = 0 Then sqlTag1 = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag1 = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag1 = "tblEmployee.EnrolNo" Else sqlTag1 = "tblEmployee.EmpNo"
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", (cmbDept.Text))
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", (cmbCat.Text))
        Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", (cmbDesg.Text))
        Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", (cmbBranch.Text))
        Dim StrType As String = IIf(cmbType.Text = "[ALL]", "", (cmbType.Text))
        Dim StrTitle As String = IIf(cmbTitle.Text = "[ALL]", "", (cmbTitle.Text))
        Dim StrRAct As String = IIf(cmbEmpAct.Text = "[ALL]", "", (cmbEmpAct.Text))
        Dim StrRSubCat As String = IIf(cmbEmpSubCat.Text = "[ALL]", "", (cmbEmpSubCat.Text))

        Dim srtQueryTableNames As String = "" : Dim strQueryJoin As String = "" : Dim strQueryWhere As String = ""
        'Dim AdvanHRIDDetails As Integer = fk_sqlDbl("select AdvanHRIDDetails from tblControl ")
        If AdvanHRIDDetails = 1 Then strQueryWhere = " dbo.tblSetSubCatHRIS.Dscrb LIKE '" & StrRSubCat & "%' AND dbo.tblSetActTypesHRIS.Dscrb LIKE '" & StrRAct & "%' AND " : srtQueryTableNames = ",tblSetSubCatHRIS,tblSetActTypesHRIS" : strQueryJoin = "AND dbo.tblEmployee.SubCatID = dbo.tblSetSubCatHRIS.CatID AND   dbo.tblEmployee.ActType = dbo.tblSetActTypesHRIS.ActID"

        If chkViewResigned.Checked = True Then
            sSQL = "SELECT     'true',dbo.tblEmployee.RegID,RIGHT('00000'+CAST( " & sqlTag1 & "  AS VARCHAR(6)),6) as ' " & sqlTag1.Split("."c)(1) & " ' ," & _
 "dbo.tblEmployee.DispName, dbo.tblEmployee.NICNumber,dbo.tblCBranchs.BrName,dbo.tblSetDept.DeptName, " & _
         "dbo.tblDesig.desgDesc, tblSetEmpCategory.CatDesc,tblsetemptype.tDesc FROM    " & _
         "dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany, " & _
         " tblsettitle,tblsetemptype " & srtQueryTableNames & " " & _
          "where   dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
         " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
          "dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
        "dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
             "dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
       "dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
    "dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID " & strQueryJoin & " AND   " & _
          "tblEmployee.EMPstatus=9 AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
         "AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR     " & _
         "dbo.tblEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR    " & _
         "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND  " & _
         "(dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
         "dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND   " & _
            "dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
         "dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
         " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND " & strQueryWhere & "  " & _
         "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%')   " & _
        "ORDER BY " & sqlTag1 & ""
            FK_LoadGrid(sSQL, dgvEmps)
        Else

            If rdbNormal.Checked = True Then
                sSQL = "SELECT     'true',dbo.tblEmployee.RegID,RIGHT('00000'+CAST( " & sqlTag1 & "  AS VARCHAR(6)),6) as ' " & sqlTag1.Split("."c)(1) & " ' ," & _
 "dbo.tblEmployee.DispName, dbo.tblEmployee.NICNumber,dbo.tblCBranchs.BrName,dbo.tblSetDept.DeptName, " & _
         "dbo.tblDesig.desgDesc, tblSetEmpCategory.CatDesc,tblsetemptype.tDesc FROM    " & _
         "dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany,tblsettitle,tblsetemptype " & srtQueryTableNames & "  " & _
          "where   dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
         " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
          "dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
        "dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
             "dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
       "dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
    "dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID " & strQueryJoin & " AND   " & _
          "tblEmployee.EMPstatus=1 AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
         "AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR     " & _
         "dbo.tblEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR    " & _
         "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND  " & _
         "(dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
         "dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND   " & _
            "dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & strQueryWhere & "  " & _
         "dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND " & strQueryWhere & " " & _
         "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%')  ORDER BY " & sqlTag1 & ""

            Else
                sSQL = "CREATE TABLE #T (trSt NVARCHAR (6),regID NVARCHAR (6),enrolNo NVARCHAR (6),dispName NVARCHAR (256),NICNumber NVARCHAR (14),brName NVARCHAR (278),deptName NVARCHAR (267),desgName NVARCHAR (278),catDesg NVARCHAR (256),tDesc NVARCHAR (188),empStatus NUMERIC (18,0))" & _
"INSERT INTO #T SELECT     'true',dbo.tblEmployee.RegID,RIGHT('00000'+CAST( " & sqlTag1 & "  AS VARCHAR(6)),6) as ' " & sqlTag1.Split("."c)(1) & " ' ," & _
 "dbo.tblEmployee.DispName, dbo.tblEmployee.NICNumber,dbo.tblCBranchs.BrName,dbo.tblSetDept.DeptName, " & _
         "dbo.tblDesig.desgDesc, tblSetEmpCategory.CatDesc,tblsetemptype.tDesc,tblEmployee.EMPstatus FROM    " & _
         "dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany,tblsettitle,tblsetemptype " & srtQueryTableNames & "  " & _
          "where   dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
         " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
          "dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
        "dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
             "dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
       "dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
    "dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID " & strQueryJoin & " AND   " & _
          "tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND  dbo.tblEmployee.regDate <= '" & Format(dtpFromDate.Value, "yyyyMMdd") & "'  " & _
         "AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR     " & _
         "dbo.tblEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR    " & _
         "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND  " & _
         "(dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
         "dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND   " & _
            "dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
         "dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
         " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND " & strQueryWhere & "  " & _
         "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%')   " & _
        "ORDER BY " & sqlTag1 & " UPDATE #T SET #T.empStatus=1 FROM tblREmpHist,#T WHERE #T.regID=tblREmpHist.regID  AND  dbo.tblREmpHist.regDate <= '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND  dbo.tblREmpHist.resDate>= '" & Format(dtpFromDate.Value, "yyyyMMdd") & "'   AND  dbo.tblREmpHist.rstatus=0; SELECT * FROM #T WHERE empStatus=1"
            End If

            FK_LoadGrid(sSQL, dgvEmps)
        End If

        clr_Grid(dgvEmps)
        For X As Integer = 0 To dgvEmps.Columns.Count - 1
            'dgvSearchK.Columns(X).HeaderText = UCase(dgvSearchK.Columns(X).HeaderText)
            dgvEmps.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        dgvEmps.Columns(1).Visible = False
        GroupBox1.Text = "Total Employees : " & dgvEmps.RowCount
        chkCheck.CheckState = CheckState.Checked
    End Sub

    Public Sub EmployeeSearch()

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else sqlTag = "tblEmployee.enrolNo"

        Dim strQuery As String = "select  'true',dbo.tblEmployee.RegID,dbo." & sqlTag & ", dbo.tblEmployee.dispName," & _
        "dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 FROM dbo.tblEmployee " & _
        "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID " & _
        "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID " & _
        "LEFT OUTER JOIN dbo.tblSetTitle ON dbo.tblSetTitle.titleID=dbo.tblemployee.TitleID " & _
        "LEFT OUTER JOIN dbo.tblSEtEmpCategory ON dbo.tblSEtEmpCategory.CatID=dbo.tblEmployee.CatID " & _
        "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.empNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%') AND " & _
        "(dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblCBranchs.BrName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetEmpType.tDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetTitle.titleDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSEtEmpCategory.CatDesc LIKE '%" & txtSearch.Text & "%') " & _
        "order by " & sqlTag & ""

        Load_InformationtoGrid(strQuery, dgvEmps, 7)
        clr_Grid(dgvEmps)
        'and tblEmployee.empStatus <> 9 
        lblCount.Text = "Total Employees : " & dgvEmps.RowCount

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'Show Informaiton 
        'Department 
        rdbNormal.Checked = True
        FK_Clear(Me)
        bolLoad = True
        ListComboAll(cmbDesg, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "desgDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0  AND deptid in ('" & StrUserLvDept & "') Order By DeptID", "deptName")
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType WHERE Status = 0 order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] WHERE Status = 0 order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")
        ListComboAll(cmbEmpAct, "SELECT Dscrb FROM [tblSetActTypesHRIS] WHERE Status = 0 order by ActID asc", "Dscrb")
        ListComboAll(cmbEmpSubCat, "SELECT Dscrb FROM [tblSetSubCatHRIS] WHERE Status = 0 order by CatID asc", "Dscrb")
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox1.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
        txtSearch.Text = "K"
        txtSearch.Text = ""

        dtLastProcessed = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        dtpToDate.Value = dtLastProcessed
        dtpFromDate.Value = New Date(dtLastProcessed.Year, dtLastProcessed.Month, 1)
        bolLoad = False
        Load_Main()
        lblReportName.Text = ""
        'chkCheck.CheckState = CheckState.Checked
        chkMinutes.CheckState = fk_sqlDbl("select IsDispMinutes from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Public Sub Load_Main()

        dgvDetails.Rows.Clear()

        'Dim StrID As String
        'Dim StrDesc As String

        ''Load Information from the Report Header 
        'Dim sqlQRY As String
        'Dim cnHead As New SqlConnection(sqlConString)
        'cnHead.Open()
        'sqlQRY = "SELECT * FROM tblRepGroups WHERE status = 0 Order By mID"
        'Try
        '    Dim cmHead As New SqlCommand(sqlQRY, cnHead)
        '    Dim drHead As SqlDataReader = cmHead.ExecuteReader
        '    Do While drHead.Read = True
        '        StrID = IIf(IsDBNull(drHead.Item("mID")), "", drHead.Item("mID"))
        '        StrDesc = IIf(IsDBNull(drHead.Item("Descr")), "", drHead.Item("Descr"))
        '        dgvDetails.Rows.Add(StrID, StrDesc, "M")
        '        Load_Sub(StrID)
        '    Loop
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnHead.Close()
        'End Try

        sSQL = "CREATE TABLE #T	(repID NVARCHAR (3),mID NVARCHAR (2),rName NVARCHAR (256)); INSERT INTO #T select '000',mID,'<'+ ' ' +Descr+' '+ '>' from tblRepGroups INSERT INTO #T select repID,mID,rName from tblreports WHERE MID='01' AND tblreports.repID in ('" & StrUserLvReport & "') and status=0; SELECT mID,rName,repID FROM #T ORDER BY  mID,repID"
        Load_InformationtoGrid(sSQL, dgvDetails, 3)
        'Color Header and Subs 
        dgvDetails.RowTemplate.Height = 30
        With dgvDetails
            For iRow As Integer = 0 To .RowCount - 1
                If .Item(2, iRow).Value = "000" Then 'Main Header 
                    For iCol As Integer = 0 To .ColumnCount - 1
                        .Item(iCol, iRow).Style.BackColor = Color.SteelBlue
                        .Item(iCol, iRow).Style.ForeColor = Color.White
                    Next
                Else
                    For iCol As Integer = 0 To .ColumnCount - 1
                        .Item(iCol, iRow).Style.BackColor = Color.White
                        .Item(iCol, iRow).Style.ForeColor = Color.SteelBlue
                    Next
                End If
            Next
        End With

    End Sub

    Public Sub Load_Sub(ByVal StrHeadID As String)

        Dim StrID As String
        Dim StrDesc As String

        Dim sqlQRY As String
        Dim cnSub As New SqlConnection(sqlConString)
        sqlQRY = "SELECT * FROM tblReports WHERE mID = '" & StrHeadID & "' AND Status = 1 AND tblreports.repID in ('" & StrUserLvReport & "') Order By RepID"
        cnSub.Open()
        Try
            Dim cmSub As New SqlCommand(sqlQRY, cnSub)
            Dim drSub As SqlDataReader = cmSub.ExecuteReader
            Do While drSub.Read = True
                StrID = IIf(IsDBNull(drSub.Item("RepID")), "", drSub.Item("RepID"))
                StrDesc = IIf(IsDBNull(drSub.Item("rName")), "", drSub.Item("rName"))
                dgvDetails.Rows.Add(StrID, StrDesc, "S")
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnSub.Close()
        End Try

    End Sub

    Private Sub cmdBrsReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsReport.Click
        StrReportID = ""
        'Dim frmRepS As New frmSelectReport
        'frmRepS.ShowDialog()

        'Show Report Related Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblReports WHERE RepID = '" & StrReportID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                StrCatReport = IIf(IsDBNull(drShw.Item("rPath")), "", drShw.Item("rPath"))
                StrDeptReport = IIf(IsDBNull(drShw.Item("rcPath")), "", drShw.Item("rcPath"))
                txtReportName.Text = IIf(IsDBNull(drShw.Item("rName")), "", drShw.Item("rName"))
                strFormulaFromDB = IIf(IsDBNull(drShw.Item("rFormula")), "", drShw.Item("rFormula"))

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub txtReportName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReportName.KeyPress, dtpToDate.KeyPress, dtpFromDate.KeyPress
        If AscW(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmdShowInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowInfo.Click
        'Insert Selected Category to SelCategory 

        '        Dim sqlQRY As String = ""
        '        StrSelCategory = ""
        '        StrSelDept = ""
        '        With dgvCategory
        '            For i As Integer = 0 To .RowCount - 1
        '                If .Item(0, i).Value = True Then sqlQRY = sqlQRY & " INSERT INTO tblSelCat (CatID,CatDesc) VALUES ('" & .Item(1, i).Value & "','" & .Item(2, i).Value & "')"
        '                If .Item(0, i).Value = True Then If StrSelCategory = "" Then StrSelCategory = .Item(1, i).Value Else StrSelCategory = StrSelCategory & "','" & .Item(1, i).Value


        '            Next
        '        End With

        '        'Insert Selected Department 
        '        With dgvDepartment
        '            For i As Integer = 0 To .RowCount - 1
        '                If .Item(0, i).Value = True Then sqlQRY = sqlQRY & " INSERT INTO tblSelDept (DeptID,DeptName) VALUES ('" & .Item(1, i).Value & "','" & .Item(2, i).Value & "')"
        '                If .Item(2, i).Value = True Then If StrSelDept = "" Then StrSelDept = .Item(1, i).Value Else StrSelDept = StrSelDept & "','" & .Item(1, i).Value
        '            Next
        '        End With

        '        FK_EQ(sqlQRY, "S", "", False, False, False)

        '        If StrSelCategory = "" Then MsgBox("Please select even One Category", MsgBoxStyle.Information) : Exit Sub
        '        If StrSelDept = "" Then MsgBox("Please Select Even One Department", MsgBoxStyle.Information) : Exit Sub

        '        sqlQRY = "select tblEmployee.RegID,tblEmployee.EpfNo,tblEmployee.dispName,tblEmpRegister.AtDate,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.InTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),tblEmpRegister.OutDate,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblEmpRegister.OutTime1,100),7)),7),'AM',' AM'),'PM',' PM') as varchar) ,tblEmpRegister.DayTypeID,tblEmpRegister.ShiftID,tblEmpRegister.LeaveID,tblEmpregister.IsLeave " & _
        '" FROM tblEmployee INNER JOIN tblEmpRegister ON tblEmployee.RegID = tblEmpRegister.EmpID WHERE tblEmployee.DeptID IN ('" & StrSelDept & "') AND tblEmployee.CatID in ('" & StrSelCategory & "') AND tblEmployee.BrID LIKE '%" & StrSelBranch & "%' AND tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblEmpregister.EmpID LIKE '" & StrEmployeeID & "%'"
        '        Load_InformationtoGrid(sqlQRY, dgvDetails1, 9)

    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        If UP("Report", "View allowed reports") = False Then Exit Sub

        StrShortSumLvID = fk_RetString("select ShortLvID FROM tblControl")

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        If txtReportName.Text = "" Then MessageBox.Show("Please select Report Name from List", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        dtpFromDate_Leave(sender, e)
        dtpToDate_Leave(sender, e)

        sSQL = "Delete from tblTReport;"
        For X As Integer = 0 To dgvEmps.RowCount - 1
            If CBool(dgvEmps.Item(0, X).Value) = True Then
                sSQL = sSQL & "Insert into tblTReport (EmpID) values ('" & dgvEmps.Item(1, X).Value & "'); "
            End If
        Next

        Dim strQuery As String = "UPDATE tblCompany SET IsDispMinutes='" & chkMinutes.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "E", "", False, False, False)

        If FK_EQ(sSQL, "P", "", False, False, False) = True Then

            If dtFromDate > dtToDate Then MessageBox.Show("Please select Correct From Date", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpFromDate.Value = dtpToDate.Value : Exit Sub
            'If dtToDate > dtLastProcessed Then MessageBox.Show("There are no Processed data to This Date range, System will Automaticaly set to Last Prosessed Date now", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpToDate.Value = dtLastProcessed : cmdReport_Click(sender, e) : Exit Sub

        End If

        'If txtEmployee.Text = "" Then StrEmployeeID = ""
        'If optCatReport.Checked = True Then strLoadReport = StrCatReport Else strLoadReport = StrDeptReport
        Dim FromDate As String = Format(dtpFromDate.Value, "yyyy, MM, dd")
        Dim ToDate As String = Format(dtpToDate.Value, "yyyy, MM, dd")

        ''Dim sqlTable As String
        ''sqlTable = "CREATE TABLE tblTReport (EmpID Nvarchar (6))"
        ''FK_EQ(sqlTable, "S", "", False, False, False)

        ' ''Delete the existing informatio nof the table 
        ''sqlTable = "DELETE FROM tblTReport"
        ''FK_EQ(sqlTable, "S", "", False, False, False)

        ' ''Insert selected Information to the report 
        Dim sqlQRY As String = ""
        ''StrSelCategory = ""
        ''StrSelDept = ""
        ''With dgvCategory
        ''    For i As Integer = 0 To .RowCount - 1
        ''        If .Item(0, i).Value = True Then If StrSelCategory = "" Then StrSelCategory = .Item(1, i).Value Else StrSelCategory = StrSelCategory & "','" & .Item(1, i).Value
        ''    Next
        ''End With

        ' ''Insert Selected Department 
        ''With dgvDepartment
        ''    For i As Integer = 0 To .RowCount - 1
        ''        If .Item(0, i).Value = True Then If StrSelDept = "" Then StrSelDept = .Item(1, i).Value Else StrSelDept = StrSelDept & "','" & .Item(1, i).Value
        ''    Next
        ''End With

        ''If StrSelCategory = "" Then MsgBox("Please select even One Category", MsgBoxStyle.Information) : Exit Sub
        ''If StrSelDept = "" Then MsgBox("Please Select Even One Department", MsgBoxStyle.Information) : Exit Sub

        ''sqlQRY = "insert into tblTReport select tblEmployee.RegID FROM tblEmployee  WHERE tblEmployee.DeptID IN ('" & StrSelDept & "') AND tblEmployee.CatID in ('" & StrSelCategory & "') AND tblEmployee.BrID LIKE '%" & StrSelBranch & "%' AND tblEmployee.RegID LIKE '%" & StrEmployeeID & "%'"
        ''FK_EQ(sqlQRY, "S", "", False, False, False)

        Dim sqlReportQRY As String
        Dim StrTFormula As String = ""

        mod_ReportAttendance.ReportID = StrReportID

        Select Case StrReportID

            Case "011" 'Employee Information report
                StrTFormula = " AND {tblEmployee.RegDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmployee.RegDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "003"
                StrTFormula = " AND {tblDiMachine.cDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblDiMachine.cDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "009" 'Leave Analisys Report
                sqlQRY = "DELETE FROM tblLvBalReport"
                sqlQRY = sqlQRY & " INSERT INTO tblLvBalReport SELECT EmpID,LeaveID,NoLeaves,TakenLeave,0 FROM tblEmpLeaveD WHERE cYear = " & dtpFromDate.Value.Year & ""
                sqlQRY = sqlQRY & " CREATE TABLE #T (EmpID Nvarchar (6),LeaveID Nvarchar (3),TknLv Numeric (18,2))"
                sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblLeaveTRH.EmpID,tblLeaveTRD.LvType,Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRH,tblLeaveTRD WHERE tblLeaveTRH.EmpID = tblLeaveTRD.EmpID AND tblLeaveTRH.RqID  = tblLeaveTRD.RqID AND tblLeaveTRD.lvDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  AND tblLeaveTRD.Status = 0 GROUP By tblLeaveTRH.EmpID,tblLeaveTRD.LvType"
                sqlQRY = sqlQRY & " UPDATE tblLvBalReport SET BalLv = CASE WHEN EntLv-TknLv < 0 THEN 0 ELSE EntLv-TknLv END"
                FK_EQ(sqlQRY, "S", "", False, False, True)

            Case "019"
                StrTFormula = " AND {tblDiMachine.cDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblDiMachine.cDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "012"
                StrTFormula = " AND {tblDiMachine.cDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblDiMachine.cDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "013"
                StrTFormula = ""
            Case "014"
                '10/8/2012
                'Summary report Generate QRY 
                sqlReportQRY = "CREATE TABLE tblHeadCountR (DeptID Nvarchar (3), DeptName Nvarchar (100),frDate DateTime, EdDate DateTime,NoPresent Numeric (18,2) NOT NULL Default 0,NoAbsent Numeric (18,2) NOT NULL Default 0,NoLeave Numeric (18,0) NOT NULL Default 0,NoOff Numeric (18,2) NOT NULL Default 0,Total Numeric (18,2) NOT NULL Default 0,CompID Nvarchar (3))"
                FK_EQ(sqlReportQRY, "S", "", False, False, False)
                sqlReportQRY = "CREATE TABLE tblHCTemt (DeptID Nvarchar (3),Total Numeric (18,0))"
                FK_EQ(sqlReportQRY, "S", "", False, False, False)
                sqlReportQRY = "Delete FROM tblHeadCountR"
                FK_EQ(sqlReportQRY, "S", "", False, False, False)
                Dim dtRDate As Date = dtpFromDate.Value
                Dim strWhere As String = ""

                If strDeptID = "" And StrBranchID = "" Then
                    strWhere = ""
                ElseIf strDeptID <> "" And StrBranchID = "" Then
                    strWhere = strDeptID
                ElseIf strDeptID <> "" And StrBranchID <> "" Then
                    strWhere = strDeptID & " " & StrBranchID
                ElseIf strDeptID = "" And StrBranchID <> "" Then
                    strWhere = strDeptID & " " & StrBranchID
                End If

                sqlReportQRY = "INSERT INTO tblHeadCountR (DeptID,DeptName,FrDate,EdDate,CompID ) Select DeptID,DeptName,'" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpFromDate.Value, "yyyyMMdd") & "','001' FROM tblSetDept WHERE status =0"
                sqlReportQRY = sqlReportQRY & " DELETE FROM tblHCTemt"
                sqlReportQRY = sqlReportQRY & " INSERT INTO tblHCTemt SELECT tblEmployee.DeptID,Count(tblEmpRegister.EmpID) FROM tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID WHERE tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND tblEmpRegister.AntStatus = 1 AND tblEmployee.EmpStatus <> 9 " & strWhere & " GROUP By tblEmployee.DeptID"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHCTemt SET Total = 0 WHERE total is Null"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHeadCountR SET NoPresent = tblHCTemt.Total FROM tblHCTemt INNER JOIN tblHeadCountR ON tblHeadCountR.DeptID = tblHCTemt.DeptID"

                sqlReportQRY = sqlReportQRY & " DELETE FROM tblHCTemt"
                sqlReportQRY = sqlReportQRY & " INSERT INTO tblHCTemt SELECT tblEmployee.DeptID,Count(tblEmpRegister.EmpID) FROM tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID " & _
                " WHERE tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND tblDayType.WorkUnit <> 0 AND tblEmpRegister.AntStatus = 0 AND tblEmpRegister.NoLeave = 0 AND tblEmployee.EmpStatus <> 9 " & strWhere & " GROUP By tblEmployee.DeptID"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHCTemt SET Total = 0 WHERE total is Null"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHeadCountR SET NoAbsent = tblHCTemt.Total FROM tblHCTemt INNER JOIN tblHeadCountR ON tblHeadCountR.DeptID = tblHCTemt.DeptID"

                sqlReportQRY = sqlReportQRY & " DELETE FROM tblHCTemt"
                sqlReportQRY = sqlReportQRY & " INSERT INTO tblHCTemt SELECT tblEmployee.DeptID,Count(tblEmpRegister.EmpID) FROM tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID WHERE tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND  tblEmpRegister.NoLeave <> 0 AND tblEmpRegister.AntStatus = 0 AND tblEmployee.EmpStatus <> 9 " & strWhere & " GROUP By tblEmployee.DeptID"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHCTemt SET Total = 0 WHERE total is Null"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHeadCountR SET NoLeave = tblHCTemt.Total FROM tblHCTemt INNER JOIN tblHeadCountR ON tblHeadCountR.DeptID = tblHCTemt.DeptID"

                sqlReportQRY = sqlReportQRY & " DELETE FROM tblHCTemt"
                sqlReportQRY = sqlReportQRY & " INSERT INTO tblHCTemt SELECT tblEmployee.DeptID,Count(tblEmpRegister.EmpID) FROM tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID " & _
                " WHERE tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND  tblEmpRegister.AntStatus = 0 AND tblDayType.WorkUnit=0 AND tblEmployee.EmpStatus <> 9 " & strWhere & " GROUP By tblEmployee.DeptID"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHCTemt SET Total = 0 WHERE total is Null"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHeadCountR SET NoOff = tblHCTemt.Total FROM tblHCTemt INNER JOIN tblHeadCountR ON tblHeadCountR.DeptID = tblHCTemt.DeptID"

                sqlReportQRY = sqlReportQRY & " DELETE FROM tblHCTemt"
                sqlReportQRY = sqlReportQRY & " INSERT INTO tblHCTemt SELECT tblEmployee.DeptID,Count(tblEmpRegister.EmpID) FROM tblEmpRegister INNER JOIN tblEmployee ON tblEmployee.RegID = tblEmpRegister.EmpID WHERE tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND tblEmployee.EmpStatus <> 9 " & strWhere & " GROUP By tblEmployee.DeptID"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHCTemt SET Total = 0 WHERE total is Null"
                sqlReportQRY = sqlReportQRY & " UPDATE tblHeadCountR SET Total = tblHCTemt.Total FROM tblHCTemt INNER JOIN tblHeadCountR ON tblHeadCountR.DeptID = tblHCTemt.DeptID"

                FK_EQ(sqlReportQRY, "S", "", False, False, True)

                'Now Generate the Informatoin for the Report 

            Case "008" 'Leave Taken Report
                StrTFormula = " AND {tblLeaveTRD.LvDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblLeaveTRD.LvDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')"

            Case "015"
                sqlReportQRY = ""
                sqlReportQRY = "if exists (select * from sys.Objects where name = 'tblReportOTSum') Begin DROP TABLE tblReportOTSum end"
                FK_EQ(sqlReportQRY, "S", "", False, False, False)
                sqlReportQRY = "if exists (select * from sys.Objects where name = 'tmpDeptOT') Begin DROP TABLE tmpDeptOT end"
                FK_EQ(sqlReportQRY, "S", "", False, False, False)

                Dim dblDevider As Double = 0
                sSQL = "SELECT OTRepDevide FROM tblCompany where compID='" & StrCompID & "'" : dblDevider = fk_sqlDbl(sSQL)

                sqlReportQRY = "CREATE TABLE tblDeptAllOT (EmpID nvarchar (6),DeptID Nvarchar (3),BasicSalary Numeric (18,2),WrkDays Numeric (18,2),TotDays Numeric (18,2),NormalOT Numeric (18,2),NOTAmount Numeric (18,2),DoubleOT Numeric (18,2),DOTAmount Numeric (18,2),TripleOT Numeric (18,2),TOTAmount Numeric (18,2))" : FK_EQ(sqlReportQRY, "S", "", False, False, False)
                sqlReportQRY = "INSERT INTO tblDeptAllOT SELECT tblPayrollEMployee.RegID,tblPayrollEmployee.DeptID,tblPayrollEmployee.BasicSalary,0,0,0,0,0,0,0,0 FROM tblPayrollEmployee" : FK_EQ(sqlReportQRY, "S", "", False, False, False)
                sqlReportQRY = "CREATE TABLE #T (EmpID Nvarchar (6),WrkDays Numeric (18,2),[NOT] Numeric (18,2),DOT Numeric (18,2),TOT Numeric (18,2)) " & _
                " INSERT INTO #T SELECT tblEmpRegister.EmpID,Sum(NRWorkDay),Sum(NormalOTHrs),Sum(DoubleOTHrs),0 FROM tblEmpRegister WHERE AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' GROUP BY EmpID" & _
                " UPDATE tblDeptAllOT SET tblDeptAllOT.WrkDays = #T.WrkDays,tblDeptAllOT.NormalOT = #T.[NOT], tblDeptAllOT.DoubleOT = #T.DOT FROM #T,tblDeptAllOT WHERE #T.EmpID = tblDeptAllOT.EmpID " & _
                " UPDATE tblDeptAllOT SET NOTAmount = ((BasicSalary * NormalOT)/" & dblDevider & " * 1.5),DOTAmount = ((BasicSalary * DoubleOT)/" & dblDevider & " * 2)"
                FK_EQ(sqlReportQRY, "S", "", False, False, True)

                sqlReportQRY = "CREATE TABLE tblReportOTSum(DeptID Nvarchar(3),DeptName Nvarchar (100),NoEmp Numeric (18,0),NormalOT Numeric (18,2),DoubleOT Numeric (18,2),CompID Nvarchar (3))" & _
                " Declare @st DateTime " & _
                " Declare @ed DateTime " & _
                " SET @st = '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' " & _
                " SET @ed = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' " & _
                " INSERT INTO tblReportOTSum (DeptID,DeptName,NoEmp,NormalOT,DoubleOT,CompID) " & _
                " SELECT tblEmployee.DeptID,tblSetDept.DeptName,Count(tblEmployee.RegID),0,0,'001' FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 GROUP By tblEmployee.DeptID,tblSetDept.DeptName " & _
                " CREATE TABLE tmpDeptOT (DeptID Nvarchar (3),NoOT Numeric (18,2),DbOT Numeric (18,2)) " & _
                " INSERT INTO tmpDeptOT " & _
                " SELECT tblEmployee.DeptID,Sum(tblDeptAllOT.NOTAmount),Sum(tblDeptAllOT.DOTAmount) FROM tblEmployee INNER JOIN tblDeptAllOT ON tblEmployee.RegID = tblDeptAllOT.EmpID WHERE tblEmployee.EmpStatus <> 9 GROUP By tblEmployee.DeptID " & _
                " UPDATE tblReportOTSum SET tblReportOTSum.NormalOT = tmpDeptOT.NoOT,tblReportOTSum.DoubleOT = tmpDeptOT.DbOT FROM tmpDeptOT  INNER JOIN tblReportOTSum ON tblReportOTSum.DeptID = tmpDeptOT.DeptID "
                FK_EQ(sqlReportQRY, "S", "", False, False, True)

            Case "016" 'Attendance Detail IN/OUT Report
                proc_AttendanceSummary(dtpFromDate.Value, dtpToDate.Value)

            Case "022"
                '############### Extended Report Modification #################
                'Open Parameters 
                sqlQRY = "SELECT NoPayID,AnlLvID,CasLvID,MedLvID,IsExtSumRep FROM tblControl"
                fk_Return_MultyString(sqlQRY, 5)

                StrNpSumLvID = fk_ReadGRID(0) : StrAnSumLvID = fk_ReadGRID(1) : StrCaSumLvID = fk_ReadGRID(2) : StrMdSumLvID = fk_ReadGRID(3) : intIsExtSumRep = fk_ReadGRID(4)

                '############### END ##################
                sqlQRY = " exec sp_PayrolRun '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
                FK_EQ(sqlQRY, "S", "", False, False, True)
                StrTFormula = "  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
                If intIsExtSumRep = 1 Then
                    Dim StrAllLv As String = ""
                    StrAllLv = "" & StrNpSumLvID & "','" & StrAnSumLvID & "','" & StrCaSumLvID & "','" & StrMdSumLvID & ""

                    sqlQRY = " CREATE TABLE #ALLv (EmpID Nvarchar (6),LeaveID Nvarchar (3),TknLv Numeric (18,2)) " & _
                    " INSERT INTO #ALLv SELECT tblLeaveTRD.EmpID,tblLeaveTRD.lvType,Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRH,tblLeaveTRD,tblLeaveType WHERE " & _
                    " tblLeaveTRH.RqID = tblLeaveTRD.RqID And tblLeaveTRH.EmpID = tblLeaveTRD.EmpID And tblLeaveTRD.LvType = tblLeaveType.LvID " & _
                    " AND tblLeaveTRD.LvDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRD.Status = 0 AND tblLeaveType.EffDay = 1 AND tblLeaveType.Status = 0 GROUP BY tblLeaveTRD.EmpID,tblLeaveTRD.LvType " & _
                    " UPDATE tblPayrollSummary SET tblPayrollSummary.NopayLeave = #ALLv.TknLv FROM #ALLv,tblPayrollSummary WHERE #ALLv.EmpID = tblPayrollSummary.EmpID AND #ALLv.LeaveID = '" & StrNpSumLvID & "'" & _
                    " UPDATE tblPayrollSummary SET tblPayrollSummary.AnlLeave = #ALLv.TknLv FROM #ALLv,tblPayrollSummary WHERE #ALLv.EmpID = tblPayrollSummary.EmpID AND #ALLv.LeaveID = '" & StrAnSumLvID & "'" & _
                    " UPDATE tblPayrollSummary SET tblPayrollSummary.CasLeave = #ALLv.TknLv FROM #ALLv,tblPayrollSummary WHERE #ALLv.EmpID = tblPayrollSummary.EmpID AND #ALLv.LeaveID = '" & StrCaSumLvID & "'" & _
                    " UPDATE tblPayrollSummary SET tblPayrollSummary.MedLeave = #ALLv.TknLv FROM #ALLv,tblPayrollSummary WHERE #ALLv.EmpID = tblPayrollSummary.EmpID AND #ALLv.LeaveID = '" & StrMdSumLvID & "'" & _
                    " CREATE TABLE #OTHER (EmpID NVARCHAR (6),totOther NUMERIC (18,2)) " & _
                    " INSERT INTO #OTHER SELECT EmpID,Sum(TknLv) FROM #ALLv WHERE #ALLv.LeaveID NOT IN ('" & StrAllLv & "')  GROUP BY EmpID; " & _
                    " UPDATE tblPayrollSummary SET OthLeave = 0 " & _
                    " UPDATE tblPayrollSummary SET tblPayrollSummary.OthLeave = #OTHER.totOther FROM #OTHER,tblPayrollSUmmary WHERE #OTHER.EmpID = tblPayrollSummary.EmpID " & _
                    " CREATE TABLE #T (EmpID Nvarchar (6),TotVal Numeric (18,2)) " & _
                    " INSERT INTO #T SELECT EmpID,Sum(TknLv) FROM #ALLv GROUP BY EmpID " & _
                    " UPDATE tblPayrollSummary SET LvDays = 0 " & _
                    " UPDATE tblPayrollSummary SET tblPayrollSummary.LvDays = #T.TotVal FROM #T,tblPayrollSUmmary WHERE #T.EmpID = tblPayrollSummary.EmpID " & _
                    " UPDATE tblPayrollSummary SET NpDays = CASE WHEN AlvDays - LvDays < 0 THEN 0 ELSE AlvDays-LvDays END "
                    FK_EQ(sqlQRY, "S", "", False, False, True)
                End If
            Case "037" 'Roster View Report
                Gen_RosterReview(dtpFromDate.Value, dtpToDate.Value)
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "039"

                sqlQRY = "Exec sp_Resing '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "', " & IsEpf
                'Get the Total Employees 
                intTotEmps = fk_sqlDbl("SELECT Count(RegID) FROM tblEmployee WHERE EMpStatus <> 9")

            Case "021"
                sqlQRY = "Exec sp_UpdateDiv '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "029"
                sqlQRY = "Exec sp_UpdateDiv '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "040"
                Dim dblDevider As Double = 0
                sSQL = "SELECT OTRepDevide FROM tblCompany where compID='" & StrCompID & "'" : dblDevider = fk_sqlDbl(sSQL)

                sqlQRY = " DELETE FROM tblOTCosting" : FK_EQ(sqlQRY, "S", "", False, False, True)
                sqlQRY = " INSERT INTO tblOTCosting SELECT tblPayrollEmployee.RegID,tblEmpRegister.AtDate,tblPayrollEmployee .BasicSalary ,tblEmpRegister.NormalOTHrs,tblEmpRegister.DoubleOTHrs ,tblEmpRegister.TripleOTHrs ,0,0,0 FROM tblPayrollEmployee ,tblEmpRegister WHERE tblPayrollEmployee .RegID = tblEmpRegister.EmpID AND tblEmpRegister.AtDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
                sqlQRY = " UPDATE tblOTCosting SET NOTAmount = (BSalary/" & dblDevider & " * 1.5) * NOTHrs"
                sqlQRY = sqlQRY & " UPDATE tblOTCosting SET DOTAmount = (BSalary/" & dblDevider & " * 2) * DOTHrs "
                sqlQRY = sqlQRY & " UPDATE tblOTCosting SET TOTAmount = (BSalary/" & dblDevider & " * 3) * TOTHrs " : FK_EQ(sqlQRY, "S", "", False, False, True)

            Case "041"
                sqlQRY = "Exec sp_UpdateDiv '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "042"
                proc_AttendanceSummaryT(dtpFromDate.Value.Date, dtpToDate.Value.Date)

                'Manual Adjust detail report *****************************Kasun 20150704
            Case "043"
                sqlQRY = "Exec SP_MovementDetailReport '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
                StrTFormula = " AND {tblMovement.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblMovement.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
                'Manual Adjust detail report *****************************Kasun 20150704

            Case "046"
                dtpToDate.Value = dtpFromDate.Value
                StrRpToDate = StrRpFromDate
                StrTFormula = "AND {tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "
            Case "047"
                dtpToDate.Value = dtpFromDate.Value
                StrRpToDate = StrRpFromDate
                StrTFormula = "{tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "
            Case "048"
                dtpToDate.Value = dtpFromDate.Value
                StrRpToDate = StrRpFromDate
                StrTFormula = "{tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "
            Case "049"
                dtpToDate.Value = dtpFromDate.Value
                StrRpToDate = StrRpFromDate
                StrTFormula = "AND {tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "
            Case "050"
                StrTFormula = " AND {tblEmpLeaveD.cYear}= " & dtpFromDate.Value.Year & " "
            Case "051"
                sqlQRY = "Exec sp_UpdateDiv '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
            Case "053"
                StrRpToDate = StrRpFromDate
                StrTFormula = "AND {tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "
            Case "055"
                StrRpToDate = StrRpFromDate
                StrTFormula = "AND {tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "

            Case "062" 'OT Naration
                StrTFormula = " AND {tblAprovedOT.status} =0 AND {tblAprovedOT.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblAprovedOT.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')"

            Case "065"
                sqlQRY = "Exec sp_EmpTimeSheet '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "','" & strshortlvID & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
                StrTFormula = " AND {tblTimeSheet.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblTimeSheet.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "066" 'Attendance Detail IN/OUT Report
                proc_AttendanceSummary(dtpFromDate.Value, dtpToDate.Value)

            Case "067" 'Employee ID Card
                StrTFormula = " AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "068" 'Employee Resign report
                StrTFormula = " {tblREmpHist.ResDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblREmpHist.ResDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "069" 'Employee Joined report
                StrTFormula = " AND {tblEmployee.RegDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmployee.RegDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "070" 'Bata report for anuradha agency
                sSQL = "DELETE FROM tmpbataReport INSERT INTO tmpbataReport SELECT    dbo.tblEmployee.RegID,  dbo.tblEmployee.EpfNo, dbo.tblEmployee.EnrolNo,tblEmployee.NICNumber,  dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName ,convert(varchar (8), tblempregister.atDate, 112) 'AttendanceDay',dbo.tblempregister.inTime1 as 'InTime',tblempregister.outTime1 'OutTime',tblempregister.workHrs as 'WorkHours', tblleavetype.lvDesc,tblempregister.doubleOTHrs as 'CompulsaryOT',tblempregister.BgOTHrs as 'Morning OT', tblempregister.EdOTHrs-tblempregister.doubleOTHrs as 'Evening OT',tblPayrollemployee.BasicSalary as 'Bata Rate',(tblPayrollemployee.BasicSalary*tblempregister.BgOTHrs) AS 'Morning Bata',(tblPayrollemployee.daysPay*(tblempregister.EdOTHrs-tblempregister.doubleOTHrs)) AS 'Evening Bata' FROM dbo.tblEmployee LEFT OUTER JOIN     dbo.tblCivilStatus ON dbo.tblEmployee.CivilStID = dbo.tblCivilStatus.StID LEFT OUTER JOIN  dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER  JOIN dbo.tblGender ON dbo.tblEmployee.GenderID = dbo.tblGender.GenID LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER  JOIN dbo.tblSetEmpType ON dbo.tblEmployee.EmpTypeID = dbo.tblSetEmpType.TypeID LEFT OUTER  JOIN dbo.tblCBranchs ON dbo.tblEmployee.brID = dbo.tblCBranchs.brID LEFT OUTER  JOIN dbo.tblempregister ON dbo.tblEmployee.RegID = dbo.tblempregister.EMPID  LEFT OUTER  JOIN dbo.tblleavetype ON dbo.tblempregister.leaveID = dbo.tblleavetype.LVID LEFT OUTER  JOIN dbo.tblPayrollemployee ON dbo.tblPayrollemployee.regID = dbo.tblEmployee.regID WHERE tblempregister.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  ORDER BY dbo.tblSetDept.DeptName "
                FK_EQ(sSQL, "P", "", False, False, False)
                'StrTFormula = " AND {tmpbataReport.attendanceDay}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tmpbataReport.attendanceDay} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "') "
            Case "072" 'Confirmation Due report
                StrTFormula = " AND {tblEmployee.confirmDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmployee.confirmDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "073" 'Gender and category
                StrTFormula = " AND {tblEmployee.empStatus}<>9 AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "074" 'Rejoined employees
                sSQL = "DELETE FROM tblReJoined; INSERT INTO tblReJoined SELECT RegID ,empNo,NICNumber,dispName,deptID,desigID,EmpTypeID,CatID,BrID,regDate,statusDate from tblEmployee Where NICNumber IN (select NICNumber from tblemployee WHERE len(NICNumber)>8  group by NICNumber having count(NICNumber)>1 )ORDER BY NICNumber UPDATE tblReJoined SET	Department=tblsetDept.deptName from tblReJoined,tblSetDept WHERE tblReJoined.Department=tblSetDept.DeptID UPDATE tblReJoined SET	Designation=tbldesig.desgDesc from tblReJoined,tbldesig WHERE tblReJoined.Designation=tbldesig.desgID UPDATE tblReJoined SET	Category=tblSetEmpCategory.catDesc from tblReJoined,tblSetEmpCategory WHERE tblReJoined.Category=tblSetEmpCategory.catID UPDATE tblReJoined SET	EmpType=tblSetEmpType.tDesc from tblReJoined,tblSetEmpType WHERE tblReJoined.EmpType=tblSetEmpType.TypeID UPDATE tblReJoined SET	Branch=tblCbranchs.brName from tblReJoined,tblCbranchs WHERE tblReJoined.Branch=tblCbranchs.BrID "
                FK_EQ(sSQL, "P", "", False, False, False)

            Case "075" 'Manual Adjust Log
                sSQL = "DELETE FROM tblMovementHistory; INSERT INTO tblMovementHistory SELECT '',empID,'',cDate,tTime,crUser,'','' from tblDiMachineManual WHERE cdate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' ; INSERT INTO tblMovementHistory SELECT '',empID,'',cDate,'','',tTime,crUser from tblDiMachineRemove WHERE cdate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' ; UPDATE tblMovementHistory SET regID=tblEmployee.RegID,dispName=tblEmployee.dispName  FROM tblMovementHistory,tblEmployee WHERE tblMovementHistory.enrolNo=tblEmployee.enrolNo ;UPDATE tblMovementHistory SET addedBy=tblUsers.userName FROM tblMovementHistory,tblUsers WHERE tblMovementHistory.addedBy=tblUsers.UserID;UPDATE tblMovementHistory SET removedBy=tblUsers.userName FROM tblMovementHistory,tblUsers WHERE tblMovementHistory.removedBy=tblUsers.UserID"
                FK_EQ(sSQL, "P", "", False, False, True)

            Case "076" 'Relations Information Report

            Case "077" 'Leave Type wise Report
                StrTFormula = " AND {tblLeaveTRD.LvDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblLeaveTRD.LvDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')"

            Case "078" 'Attendance 15 days
                proc_AttendanceSummary(dtpFromDate.Value, dtpToDate.Value)

            Case "079" 'Attendance Detail IN/OUT Report
                proc_AttendanceSummary(dtpFromDate.Value, dtpToDate.Value)

            Case "080"
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

            Case "081"
                dtpToDate.Value = dtpFromDate.Value
                StrRpToDate = StrRpFromDate
                StrTFormula = "{tblEmpRegister.AtDate}= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*' "
            Case "082"
                sqlQRY = "Exec SP_NopaySummaryReport '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
                'StrTFormula = " AND {Absent_rpt_month_Detalis.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {Absent_rpt_month_Detalis.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')"
            Case "083"
                sqlQRY = "Exec SP_NopaySummaryReportSum '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
                'StrTFormula = " AND {Absent_rpt_month_summery.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {Absent_rpt_month_summery.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')"
            Case "084"
                sqlQRY = "Exec SP_AprovedOT_Rpt '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
            Case "085" 'All Gender and category
                StrTFormula = " AND {tblEmployee.empStatus}<>9 AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"
                '20180828 prasanna add unauthorised nopany
            Case "086"
                StrTFormula = "{tblTReport.EmpID} = {tblEmployee.RegID}  AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "') and  {tblDayType.WorkUnit} > 0  and {tblEmpRegister.LeaveID} <> {tblControl.ShortLvID} "
            Case "087" 'Fantasia ID cards
                StrTFormula = ""
            Case "088" 'Employee Profile Information Report
                StrTFormula = ""
                'Added by kasun |2018-11-02 | for lake house---------------
            Case "090"
                Dim dtCYear As Integer = dtpFromDate.Value.Year
                sqlQRY = FK_EQ("Exec sp_RunLv " & dtCYear & "", "S", "", False, False, True)
                'Added by kasun |2018-11-02 | for lake house---------------

                'Prasannas code by Kasun|2018-11-08|Add new report for fantasia***************************
            Case "091"
                sqlQRY = FK_EQ("Exec sp_OtTimeCardForEmployee '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'", "S", "", False, False, True)
                'Prasannas code by Kasun|2018-11-08|Add new report for fantasia***************************

            Case "301"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "302"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "303"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "304"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "305"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "306"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "307"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "308"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "309"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "310"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "311"
                StrTFormula = ""
                sb_FantasiaReports(StrReportID)
            Case "312"
                StrTFormula = ""
                'sb_FantasiaReports(StrReportID)
            Case Else
                StrTFormula = " AND {tblEmpRegister.AtDate}>= Date('" & Format(dtpFromDate.Value, "yyyy,MM,dd") & "') AND  {tblEmpRegister.AtDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "')  AND {tblEmployee.BrID} LIKE '" & StrSelBranch & "*'"

        End Select

        StrRpFromDate = Format(dtpFromDate.Value, "dd/MMM/yyyy")
        StrRpToDate = Format(dtpToDate.Value, "dd/MMM/yyyy")

        'StrRepFile = Application.StartupPath & "\Reports\" & strLoadReport
        ''If StrTFormula = "" Then StrSelectionFomula = strFormulaFromDB Else StrSelectionFomula = strFormulaFromDB & StrTFormula
        ''Dim frmRepCont As New frmRepContainer
        ''frmRepCont.ShowDialog()

        'Modification Transaction Number : Kasun 20161230
        Dim intTriD As Integer = fk_sqlDbl("SELECT rpVTrID+1 FROM tblControl")
        sSQL = "SELECT count(*) FROM tblTReport"
        Dim intTotEmp As Integer = fk_sqlDbl(sSQL)
        sSQL = "INSERT INTO tblReportViewHistory (rAID,crUser,crTime,rDesc,rStatus,rEmpCount) VALUES (" & intTriD & ",'" & StrUserID & "',getDate(),'View report - ID " & StrReportID & " and name " & StrRepTitle & " for " & intTotEmp & " of emplyee(s)',0," & intTotEmp & ")"
        sSQL = sSQL & "UPDATE tblControl SET rpVTrID=" & intTriD & " WHERE GrpID='001'"
        FK_EQ(sSQL, "P", "", False, False, True)

        Me.Cursor = Cursors.Default
        'StrRepFile = Application.StartupPath & "\Reports\" & strLoadReport
        StrSelectionFomula = strFormulaFromDB & StrTFormula
        Dim frmRepCont As New frmRepContainerAttn
        frmRepCont.Show()

    End Sub

    Public Sub proc_AttendanceSummaryT(ByVal stDate As Date, ByVal EdDate As Date)
        Dim sqlQRY As String = ""
        sqlQRY = " DELETE FROM tblSumAttendance"
        sqlQRY = sqlQRY & " INSERT INTO tblSumAttendance Select EmpID,AtDate,Count(*),'','' from tblGetInOut WHERE AtDate Between '" & Format(stDate, "yyyyMMdd") & "' AND  '" & Format(EdDate, "yyyyMMdd") & "' GROUP BY EmpID,AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, False)
        ' 02. Get the InOut Information for the 1 Marked Employees
        sqlQRY = "CREATE TABLE #TmpProc (EmpID Nvarchar (6),AtDate DateTime,TimeString Nvarchar (50))"
        sqlQRY = sqlQRY & " INSERT INTO #TmpProc Select tblSumAttendance.EMpID,tblSumAttendance.AtDate,Convert(Nvarchar (5),tblGetInOut.InTime,108) + '-' + Convert(Nvarchar(5),tblGetInOut.OutTime,108) FROM tblGetInOut INNER JOIN tblSumAttendance ON tblGetInOut.EmpID = tblSumAttendance.EmpID AND tblGetInOut.AtDate = tblSumAttendance.AtDate WHERE tblSumAttendance.Total = 1"
        sqlQRY = sqlQRY & " UPDATE tblSumAttendance SET tblSumAttendance.TimeDetail = #TmpProc.TimeString FROM #tmpProc INNER JOIN tblSumAttendance  ON tblSumAttendance.EmpID = #TmpProc.EmpID AND tblSumAttendance.AtDate = #TmpProc.AtDate WHERE tblSumAttendance.Total = 1"
        FK_EQ(sqlQRY, "S", "", False, False, False)

        'Load Other Information to the GRID And Update Details
        Dim dgvAll As New DataGridView
        dgvAll = New DataGridView
        With dgvAll
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .Columns.Add("EmpID", "Employee Name")
            .Columns.Add("AtDate", "Attendance Date")
            .Columns.Add("Total", "Total")
            .Columns.Add("InOut", "Time Detail")
        End With

        'Load Other Information to Above Grid
        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblSumAttendance WHERE Total > 1")
        If bolEx = True Then
            Load_InformationtoGrid("SELECT EmpID,AtDate,Total FROM tblSumAttendance WHERE Total > 1 Order By EmpID,AtDate", dgvAll, 3)
            Dim StrEmp As String = "" : Dim dtAtDate As Date
            Dim StrReturnValue As String
            Dim sqlUpString As String = ""
            With dgvAll
                For i As Integer = 0 To .RowCount - 1
                    StrEmp = .Item(0, i).Value : dtAtDate = .Item(1, i).Value
                    StrReturnValue = fk_Return_ATTime(StrEmp, dtAtDate)
                    sqlUpString = sqlUpString & " UPDATE tblSumAttendance SET TimeDetail = '" & StrReturnValue & "' WHERE EmpID = '" & StrEmp & "' AND AtDate = '" & Format(dtAtDate, "yyyyMMdd") & "'"
                Next
            End With
            FK_EQ(sqlUpString, "S", "", False, False, True)
        End If
        'UPDATE Off days to report
        sSQL = "CREATE TABLE #T (empID NVARCHAR (6),atDate DATETIME,DayTypeID NVARCHAR (3),DyShCode NVARCHAR (3))  INSERT INTO #T   SELECT tblEmpRegister.empID,tblEmpRegister.atDate ,tblEmpRegister.dayTypeID,tbldaytype.shortCode FROM tblEmpRegister,tblSumAttendance,tbldaytype WHERE tblSumAttendance.EmpID=tblEmpRegister.EmpID AND tblSumAttendance.atDate=tblEmpRegister.atDate AND tblDayType.typeid=tblEmpRegister.DayTypeID and tbldaytype.WorkUnit=0   UPDATE tblSumAttendance SET timeDetail= #T.dyShCode FROM tblSumAttendance,#T WHERE tblSumAttendance.empID=#T.EMPID AND tblSumAttendance.atDate=#T.atDate " : FK_EQ(sSQL, "S", "", False, False, True)
        'UPDATE leaves to report
        sSQL = "CREATE TABLE #T (empID NVARCHAR (6),atDate DATETIME,LeaveID NVARCHAR (3),LvShCode NVARCHAR (3))   INSERT INTO #T    SELECT tblEmpRegister.empID,tblEmpRegister.atDate ,tblEmpRegister.LeaveID,tblLeaveType.shortCode FROM tblEmpRegister,tblSumAttendance,tblLeaveType WHERE tblSumAttendance.EmpID=tblEmpRegister.EmpID AND tblSumAttendance.atDate=tblEmpRegister.atDate AND tblLeaveType.LvID=tblEmpRegister.LeaveID     UPDATE tblSumAttendance SET timeDetail=timeDetail+ ' '+ #T.lvShCode FROM tblSumAttendance,#T WHERE tblSumAttendance.empID=#T.EMPID AND tblSumAttendance.atDate=#T.atDate    " : FK_EQ(sSQL, "S", "", False, False, True)

    End Sub

    Public Function Gen_RosterReview(ByVal st As Date, ByVal ed As Date) As Boolean
        'Update tblEmployee Shift ID to shSummary Column
        Dim sqlQRY As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.shSummary = tblSetShiftH.ShortCode FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.AllShifts = tblSetShiftH.ShiftID AND tblEmpRegister.EmpID In (Select EmpID FROM tblTReport) AND tblEmpRegister.AtDate Between '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

            'Update Day Type Status 
            sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,DayType Nvarchar (3))"
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblDayType.ShortCode FROM tblEmpRegister,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.AtDate BEtween '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "' AND tblEmpRegister.EmpID In (SELECT EmpID FROM tblTReport) AND tblDayType.WorkUnit = 0"
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.shSummary = #T.DayType FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate"
            FK_EQ(sqlQRY, "S", "", False, False, True)

            'Update Off Day Marked Employees
            sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, WorkUnit Numeric (18,2),shortCode nvarchar(3))"
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblDayType.WOrkUnit,tblDayType.shortCode FROM tblEMpRegister,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.EmpID In (SELECT EmpID FROM tblTReport) AND tblEmpRegister.AtDate Between '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "'"
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.shSummary = #T.shortCode FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate AND #T.WorkUnit =0"
            FK_EQ(sqlQRY, "S", "", False, False, True)

            'Update Leave Status 
            'sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,LvNo Numeric (18,2))"
            'sqlQRY = sqlQRY & " INSERT INTO #T Select tblLeaveTRH.EmpID,tblLeaveTRD.LvDate,tblLeaveTRD.NoLeave FROM tblLeaveTRH,tblLeaveTRD WHERE tblLeaveTRH.EmpID = tblLeaveTRD.EmpID AND tblLeaveTRD.LvDate Between '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "' AND tblLeaveTRH.EmpID in (SELECT empID from tblTReport) AND tblLeaveTRH.Status = 0"
            sqlQRY = "UPDATE tblEmpREgister SET tblEmpRegister.shSummary =shSummary+' '+tblLeaveType.shortCode FROM tblLeaveType,tblEmpRegister WHERE tblEmpRegister.leaveID = tblLeaveType.LvID AND  tblEmpRegister.EmpID In (SELECT EmpID FROM tblTReport) AND tblEmpRegister.AtDate Between '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "' AND tblEmpRegister.LeaveID<>'" & StrShortSumLvID & "'  AND tblEmpRegister.NoLeave<>0.5"
            FK_EQ(sqlQRY, "S", "", False, False, True)

            'UPDATE short leaves to report 2017 11 01 Kasun
            sSQL = "CREATE TABLE #T (empID NVARCHAR (6),atDate DATETIME,LeaveID NVARCHAR (3),LvShCode NVARCHAR (3))   INSERT INTO #T    SELECT tblEmpRegister.empID,tblEmpRegister.atDate ,tblEmpRegister.LeaveID,ltrim(tblLeaveType.shortCode) FROM tblEmpRegister,tblLeaveType WHERE tblLeaveType.LvID=tblEmpRegister.LeaveID AND tblLeaveType.LvID='" & StrShortSumLvID & "' AND tblEmpRegister.antStatus=1 AND tblEmpRegister.AtDate Between '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "'   UPDATE tblEmpRegister SET shSummary=shSummary+' '+'S'+ #T.lvShCode FROM tblEmpRegister,#T WHERE tblEmpRegister.empID=#T.EMPID AND tblEmpRegister.atDate=#T.atDate    " : FK_EQ(sSQL, "S", "", False, False, True)
            'UPDATE half day leaves to report 2017 11 04 Kasun
            sSQL = "CREATE TABLE #T (empID NVARCHAR (6),atDate DATETIME,LeaveID NVARCHAR (3),LvShCode NVARCHAR (4)) INSERT INTO #T SELECT tblEmpRegister.empID,tblEmpRegister.atDate ,tblEmpRegister.LeaveID,ltrim(tblLeaveType.shortCode) FROM tblEmpRegister,tblLeaveType WHERE tblLeaveType.LvID=tblEmpRegister.LeaveID AND tblEmpRegister.antStatus=1 AND tblEmpRegister.NoLeave=0.5 AND tblEmpRegister.AtDate Between '" & Format(st, "yyyyMMdd") & "' AND '" & Format(ed, "yyyyMMdd") & "' UPDATE tblEmpRegister SET shSummary='H'+#T.lvShCode FROM tblEmpRegister,#T WHERE tblEmpRegister.empID=#T.EMPID AND tblEmpRegister.atDate=#T.atDate " : FK_EQ(sSQL, "S", "", False, False, True)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try


    End Function

    Private Sub dgvDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetails.Click

        'If Header that won't show
        With dgvDetails
            If .Item(2, .CurrentRow.Index).Value = "000" Then
                Dim strmID As String = Trim(.Item(0, .CurrentRow.Index).Value)
                sSQL = "CREATE TABLE #T	(repID NVARCHAR (3),mID NVARCHAR (2),rName NVARCHAR (256)); INSERT INTO #T select '000',mID,'<'+ ' ' +Descr+' '+ '>' from tblRepGroups INSERT INTO #T select repID,mID,rName from tblreports WHERE MID='" & strmID & "' AND tblreports.repID in ('" & StrUserLvReport & "'); SELECT mID,rName,repID FROM #T ORDER BY  mID,repID"
                Load_InformationtoGrid(sSQL, dgvDetails, 3)
            Else
                StrReportID = .Item(2, .CurrentRow.Index).Value
            End If
            For iRow As Integer = 0 To .RowCount - 1
                If .Item(2, iRow).Value = "000" Then 'Main Header 
                    For iCol As Integer = 0 To .ColumnCount - 1
                        .Item(iCol, iRow).Style.BackColor = Color.SteelBlue
                        .Item(iCol, iRow).Style.ForeColor = Color.White
                    Next
                Else
                    For iCol As Integer = 0 To .ColumnCount - 1
                        .Item(iCol, iRow).Style.BackColor = Color.White
                        .Item(iCol, iRow).Style.ForeColor = Color.SteelBlue
                    Next
                End If
            Next
        End With

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblReports WHERE RepID = '" & StrReportID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                StrCatReport = IIf(IsDBNull(drShw.Item("rPath")), "", drShw.Item("rPath"))
                StrDeptReport = IIf(IsDBNull(drShw.Item("rcPath")), "", drShw.Item("rcPath"))
                txtReportName.Text = IIf(IsDBNull(drShw.Item("rName")), "", drShw.Item("rName"))
                strFormulaFromDB = IIf(IsDBNull(drShw.Item("rFormula")), "", drShw.Item("rFormula"))
                lblReportName.Text = "The Selected Report is -> " & txtReportName.Text
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub dgvDetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetails.DoubleClick
        cmdReport_Click(sender, e)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Length Mod 2 = 0 Then
            SearchEmployee()
        End If
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        If bolLoad = False Then
            SearchEmployee()
        End If
        'txtSearch.Text = cmbCat.Text
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox1.Controls
        '    If TypeOf ctrl Is ComboBox Then
        '        ctrl.Text = ""
        '    End If
        'Next
    End Sub

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged
        If bolLoad = False Then
            SearchEmployee()
        End If
        'txtSearch.Text = cmbDesg.Text
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox1.Controls
        '    If TypeOf ctrl Is ComboBox Then
        '        ctrl.Text = ""
        '    End If
        'Next
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        If bolLoad = False Then
            SearchEmployee()
        End If
        If cmbDept.Text = "[ALL]" Then
            strDeptID = ""
        Else
            strDeptID = fk_RetString("SELECT DeptID FROM tblsetDept WHERE DeptName = '" & cmbDept.Text & "'")
            strDeptID = " AND tblEmployee.DeptID = '" & strDeptID & "'"
        End If
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged, cmbEmpAct.SelectedIndexChanged, cmbEmpSubCat.SelectedIndexChanged
        If bolLoad = False Then
            SearchEmployee()
        End If
        If cmbBranch.Text = "[ALL]" Then
            StrBranchID = ""
        Else
            StrBranchID = fk_RetString("SELECT BrID FROM tblCBranchs WHERE BrName = '" & cmbBranch.Text & "' AND CompID = '" & StrCompID & "'")
            StrBranchID = " AND tblEmployee.brID = '" & StrBranchID & "'"
        End If

    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If bolLoad = False Then
            SearchEmployee()
        End If
    End Sub

    Private Sub cmbTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTitle.SelectedIndexChanged
        If bolLoad = False Then
            SearchEmployee()
        End If
    End Sub

    Private Sub dtpFromDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFromDate.Leave
        Try
            dtFromDate = dtpFromDate.Value.Date

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtpToDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpToDate.Leave
        Try
            dtToDate = dtpToDate.Value.Date

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkViewResigned_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkViewResigned.Click
        SearchEmployee()
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, -2, dtpToDate.Value.Date)
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpFromDate.Value.Date)
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpToDate.Value.Date)
        dtpFromDate.Value = DateAdd(DateInterval.Day, -1, dtpToDate.Value.Date)
    End Sub

    Private Sub dgvDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellContentClick

    End Sub

    Private Sub chkCheck_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkCheck.MouseClick
        For i As Integer = 0 To dgvEmps.RowCount - 1
            dgvEmps.Item(0, i).Value = chkCheck.CheckState
        Next
    End Sub

    Private Sub lnkTick_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkTick.LinkClicked
        Try
            For i As Integer = 0 To dgvEmps.RowCount - 1
                If dgvEmps.Item(0, i).Selected = True Then
                    dgvEmps.Item(0, i).Value = True
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            For i As Integer = 0 To dgvEmps.RowCount - 1
                If dgvEmps.Item(0, i).Selected = True Then
                    dgvEmps.Item(0, i).Value = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub rdbActual_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbActual.MouseClick
        SearchEmployee()
    End Sub

    Private Sub rdbNormal_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbNormal.MouseClick
        SearchEmployee()
    End Sub


    Private Sub MoonthDateAdjuest(ByVal ClickCrMonth As Integer)
        Dim NextMonth As Integer
        Dim iNextYear
        Dim cYear As Integer = Date.Today.Year
        If ClickCrMonth < 12 Then
            NextMonth = ClickCrMonth + 1
            iNextYear = cYear
        Else
            NextMonth = 1
            iNextYear = cYear + 1
        End If
        Dim AtnPrcDate As DateTime = fk_RetString("select AtnPrcDate from tblcompany")
        Dim StartDay As Integer = fk_RetString("SELECT StartDay FROM  tblcompany")
        Dim fromDate As DateTime = ClickCrMonth & "/" & StartDay & "/" & cYear
        Dim toDate As DateTime = NextMonth & "/" & StartDay & "/" & iNextYear



        'If dtpToDate.Value >= AtnPrcDate Then
        '    dtpToDate.Value = AtnPrcDate
        '    Dim atBaseDate As DateTime = AtnPrcDate.Month & "/" & StartDay & "/" & cYear
        '    dtpFromDate.Value = atBaseDate.AddMonths(-1)
        'ElseIf dtpToDate.Value < AtnPrcDate Then
        dtpFromDate.Value = fromDate
        dtpToDate.Value = toDate.AddDays(-1)
        'End If

    End Sub


    Private Sub lblMonth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth1.Click
        MoonthDateAdjuest(1)
    End Sub

    Private Sub lblMonth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth2.Click
        MoonthDateAdjuest(2)
    End Sub

    Private Sub lblMonth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth3.Click
        MoonthDateAdjuest(3)
    End Sub

    Private Sub lblMonth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth4.Click
        MoonthDateAdjuest(4)
    End Sub

    Private Sub lblMonth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth5.Click
        MoonthDateAdjuest(5)
    End Sub

    Private Sub lblMonth6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth6.Click
        MoonthDateAdjuest(6)
    End Sub

    Private Sub lblMonth7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth7.Click
        MoonthDateAdjuest(7)
    End Sub

    Private Sub lblMonth8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth8.Click
        MoonthDateAdjuest(8)
    End Sub

    Private Sub lblMonth9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth9.Click
        MoonthDateAdjuest(9)
    End Sub

    Private Sub lblMonth10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth10.Click
        MoonthDateAdjuest(10)
    End Sub

    Private Sub lblMonth11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth11.Click
        MoonthDateAdjuest(11)
    End Sub

    Private Sub lblMonth12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth12.Click
        MoonthDateAdjuest(12)
    End Sub

    Public Sub sb_FantasiaReports(ByVal SRepID As String)


        Me.Cursor = Cursors.WaitCursor
        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag1 As String : If IsEpf = 0 Then sqlTag1 = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag1 = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag1 = "tblEmployee.EnrolNo" Else sqlTag1 = "tblEmployee.EmpNo"
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", (cmbDept.Text))
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", (cmbCat.Text))
        Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", (cmbDesg.Text))
        Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", (cmbBranch.Text))
        Dim StrType As String = IIf(cmbType.Text = "[ALL]", "", (cmbType.Text))
        Dim StrTitle As String = IIf(cmbTitle.Text = "[ALL]", "", (cmbTitle.Text))
        Dim StrActName As String = IIf(cmbEmpAct.Text = "[ALL]", "", (cmbEmpAct.Text))

        StrRBranchName = cmbBranch.Text
        StrRActName = cmbEmpAct.Text
        StrRCatName = cmbCat.Text

        Select Case SRepID
            Case "301"
                fk_HeadCountR1(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpFromDate.Value)
                dtpToDate.Value = dtpFromDate.Value

            Case "302"
                fk_HeadCountR1(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpToDate.Value)

            Case "303"
                fk_HeadCountR1(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpToDate.Value)
            Case "304"
                fk_HeadCountR1(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpToDate.Value)
            Case "305"
                fk_HeadCountR1(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpToDate.Value)
            Case "306"

            Case "307"

            Case "308"
                fk_DeptAgeAnalisys(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpToDate.Value)
            Case "309"
                fk_DeptAgeAnalisys(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpFromDate.Value)
                dtpToDate.Value = dtpFromDate.Value
            Case "310"
                fk_DeptNCityAnalysis(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpFromDate.Value)
                dtpToDate.Value = dtpFromDate.Value
            Case "311"
                fk_GetDateInAct_Emps(txtSearch.Text, StrDesigName, StrDeptname, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtpFromDate.Value, dtpToDate.Value)


            Case "312"

        End Select

        Me.Cursor = Cursors.Default
    End Sub

    
End Class