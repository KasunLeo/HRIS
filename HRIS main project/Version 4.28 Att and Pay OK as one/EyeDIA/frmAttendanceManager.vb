Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmAttendanceManager

    Dim intLoad As Integer = 0
    Dim strWhereClouse As String = ""
    Dim strSearchFor As String = "Cadre"
    Dim strDispCount As String = ""

    Dim StrSelShiftID As String = ""
    Dim dtLongString As String = "" : Dim StrAllColumn As String = ""
    Dim intNoDay As Integer : Dim intTabSelected As Integer = 4
    Dim StrEmpAll As String = ""
    Dim bolOK As Boolean = False
    Dim StrSelShift As String = ""

    Dim strSelestedMac As String = "001"
    Dim StrnDayTypID As String = ""
    Dim strNDay As String = ""
    Dim clrDay As Color = Color.White
    Dim strClick As String = "1"
    Dim AtnDate1 As Date
    Dim dtMin As DateTime
    Dim dblLateMins As Double
    Dim dblOTRound As Double
    Dim dblMinOT As Double
    Dim intOTRndOption As Double

    Dim sTablek As New DataSet
    Dim strBulkID As String
    Dim strSelectDate As String = ""
    Dim strDisplaySelected As String = ""
    Dim strCollectDisplay As String = ""
    Dim intEmp As Integer = 0
    Dim clrWork As Color : Dim clrOf As Color : Dim clrHD As Color

    Dim MaxmunMonthEndDate As DateTime


    Private Sub AttendanceManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PreVentFlicker()
        If UP("Daily attendance", "View daily attendance") = False Then Exit Sub
        pnlHide.Width = 0
        pnlOption.Height = 0
        'pnlHide.Visible = False
        ControlHandlers(Me)
        'CenterFormThemed(Me, pnlTopSet, Label6)
        If dtGlobalDate = "12:00:00 AM" Then
            dtGlobalDate = dtLastProcessed
        End If
        dtpFromDate.Value = dtGlobalDate
        dtpToDate.Value = dtGlobalDate
        intLoad = 0
        FillComboAll(cmbDesg, "SELECT (desgdesc+'='+DesgID) FROM tblDesig WHERE Status = 0 Order By desgDesc")
        FillComboAll(cmbDept, "select (DeptName+'='+DeptID) From tblSetDept WHERE Status = 0  and deptID in ('" & StrUserLvDept & "') Order By deptName")
        FillComboAll(cmbCat, "select CatDesc+'='+catid From tblSEtEmpCategory WHERE Status = 0 Order By catDesc")
        FillComboAll(cmbShiftName, "select shiftName+'='+shiftID From tblSEtShiftH WHERE Status = 0 Order By shiftName")
        FillComboAll(cmbShiftType, "select CASE WHEN shiftMode=0 THEN 'Day Shift=D' ELSE 'Night Shift=N' END AS 'shiftMode' From tblSEtShiftH WHERE Status = 0 Order By shiftID")
        FillComboAll(cmbType, "select tDesc+'='+typeID from tblSetEmpType order by tDesc asc")
        FillComboAll(cmbBranch, "SELECT BrName+'='+BrID FROM [tblCBranchs] WHERE BrID IN ('" & StrUserLvBranch & "')  order by BrID asc")
        FillComboAll(cmbTitle, "SELECT titleDesc+'='+titleID FROM [tblSetTitle] order by titleID asc")
        dtMin = fk_RetDate("select tblCompany.NightShiftStart from tblcompany ")

        'chkEarlyHur.Checked = True
        'chkLateHour.Checked = True
        'chkOTHour.Checked = True
        'chkWorkHrs.Checked = True

        'CadreSearch()

        'CadreSearch()
        dtpFromDate.Value = dtGlobalDate
        dtpToDate.Value = dtGlobalDate
        intLoad = 1
        intSelecTab = 0
        CompanyParameter()
        chkAutoRefresh.Checked = True
        IsRunAutoCalculation = fk_sqlDbl("select IsRunAutoCalculation from tblcompany where compID='" & StrCompID & "'")
        chkAutoCalculate.CheckState = IsRunAutoCalculation
        Button2_Click(sender, e)
        intLoad = 0

        DateTimePickerMinDateControl()
    End Sub


    Private Sub DateTimePickerMinDateControl()
        '2018-08-03 DateTimePicker MinDate Control -prasanna
        Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")
        Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")

        MaxmunMonthEndDate = New DateTime(maxYear, maxMonth, 1).AddDays(-1)

        'dtpFromDate.MinDate = New DateTime(maxYear, maxMonth, 1)
        'dtpToDate.MinDate = New DateTime(maxYear, maxMonth, 1)
    End Sub


    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With
    End Sub

    Private Sub InitialLoad()
        Dim dv As DataView = New DataView(sTablek.Tables("tblEmployeeV"))
        sSQL = "Empstatus<>9  " & strWhereClouse & " "
        dv.RowFilter = sSQL
        'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
        Dim dt As New DataTable
        dt = dv.ToTable(True, "EmpID", "EmpNo", "DispName", "InDate", "inTime", "OutDate", "outTime", "workHrs", "shiftName", "dayType", "totalOT", "nrWorkDay", "LateMins", "EarlyMins", "LvName", "DueMins", "DName", "adDay", "normalOT", "doubleOT", "tripleOT", "isNightWork", "lunchMins", "dinnerMins", "antStatus", "OutUpdate", "inUpdate", "isLate", "isLeave", "Empstatus", "deptID", "brID", "desigName", "deptName", "catName", "brName", "workUnit", "InTimeNoSec", "OutTimeNoSec", "shiftLine", "isSplit", "DesigID", "TypeID", "ShiftID", "titleID", "catID", "genderID", "shiftMode", "dateGap")
        dgvData.DataSource = dt

        With dgvData
            .Columns(0).HeaderText = "Reg ID"
            '.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Emp No"
            '.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).HeaderText = "Employee Name"
            '.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(3).HeaderText = "In Date"
            '.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(4).HeaderText = "In Time"
            '.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(5).HeaderText = "Out Date"
            '.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(6).HeaderText = "Out Time"
            '.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(7).HeaderText = "Wrk Hours"
            '.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(8).HeaderText = "Shift"
            '.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(9).HeaderText = "Day Type"
            '.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(10).HeaderText = "Tot OT"
            '.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(11).HeaderText = "Wrk Day"
            '.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(12).HeaderText = "Late Min"
            '.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(13).HeaderText = "Early Min"
            '.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(14).HeaderText = "Leave Type"
            .Columns(15).HeaderText = "Due Min"
            .Columns(16).HeaderText = "Dy Name"
            .Columns(17).HeaderText = "Ext Day"
            '.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(18).HeaderText = "Nrml OT"
            '.Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(19).HeaderText = "Dble OT"
            '.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(20).HeaderText = "Trpl OT"
            '.Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(21).HeaderText = "Lunch Mins"
            '.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(22).HeaderText = "Dinner Mins"
            '.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(23).HeaderText = "Night Work"
            '.Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With

        For k As Integer = 24 To dgvData.Columns.Count - 1
            dgvData.Columns(k).Visible = False
        Next

        For l As Integer = 1 To 24
            dgvData.Columns(l).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        'For k As Integer = 9 To 24
        '    dgvData.Columns(k).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Next
    End Sub

    Public Sub CompanyParameter()
        sSQL = "SELECT Latemin,OTRound,MinHrsOT,OTRndOption FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        fk_Return_MultyString(sSQL, 4)
        dblLateMins = fk_ReadGRID(0)
        dblOTRound = fk_ReadGRID(1)
        dblMinOT = fk_ReadGRID(2)
        intOTRndOption = fk_ReadGRID(3)
    End Sub

    Private Sub ViewInformation(ByVal intFirstTime As Integer)
        Me.Cursor = Cursors.WaitCursor
        btnConfrmNight.Enabled = False
        chkNightOnly.Enabled = False
        chkNightAll.Enabled = False
        'sSQL = "delete from tAtManager; INSERT INTO  tAtManager  
        'select convert (varchar(11),tblEmpRegister.atdate,106) as 'Date'  ,tblEmployee.regid,tblEmployee.deptid,tblEmployee.catID,tblEmployee.desigID,tblEmpRegister.allShifts,tblEmployee.BrID,tblEmployee.EmpTypeID,tblEmployee.titleID,tblGetInOut.inTime,tblGetInOut.outTime,tblEmpRegister.dayTypeid,tblEmpRegister.nrWorkDay,tblEmpRegister.workHrs,tblEmpRegister.NormalOTHrs,tblEmpRegister.doubleOTHrs,tblEmpRegister.tripleOTHrs,tblEmpRegister.lateMins,tblEmpRegister.earlyMins,case when tblEmpRegister.antstatus='1' then '1' else '0' end  as 'p'  ,case when tblEmpRegister.antstatus='0' then '1' else '0' end  as 'a',case when tblEmpRegister.islate='1' then '1' else '0' end  as 'lt' ,case when tblEmpRegister.isleave='1' then '1' else '0' end  as 'lv',0  as 'tot',CASE WHEN tbldaytype.workUnit=0 then 1 else 0 end as 'isOf',tblEmployee.enrolNo,tblGetInOut.inUpdate,tblGetInOut.OutUpdate,tblGetInOut.shiftLine FROM tblEmpRegister inner join tblemployee on tblEmpRegister.empID=tblemployee.regID inner join tblGetinOut on tblGetinOut.empid=tblempregister.empid AND tblGetinOut.atDate=tblEmpRegister.atdate INNER JOIN tblDayType ON tblEmpregister.dayTypeid =tbldaytype.typeid where tblEmpRegister.atdate  BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' and  tblemployee.empstatus <> 9 AND tblEmployee.DeptID In  ('" & StrUserLvDept & "')  order by tblGetinOut.empID,tblEmpRegister.atDate"
        'FK_EQ(sSQL, "P", "", False, False, True)
        Try
            Select Case intFirstTime
                Case 1
                    Fk_FillDataSet("exec sp_DataSetSearchSingle '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")

                Case 0
                    Fk_FillDataSet("exec sp_DataSetSearch '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")

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
            ADP.Fill(sTablek, "tblEmployeeV")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Public Sub Fk_FillDataSetNight(ByVal strSQLQuery As String)
        Dim CN As New SqlConnection(sqlConString)
        Dim sBol As Boolean = False
        Try
            sTablek.Clear()
            CN.Open()
            Dim ADP As New SqlDataAdapter
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTablek, "tblEmployeeVN")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Private Sub CadreSearch()
        Me.Cursor = Cursors.WaitCursor
        'chkNightOnly.Checked = False
        If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 31 Then
            MessageBox.Show("Maximum date range is month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        End If

        Dim ctrl As Control
        For Each ctrl In Me.TableLayoutPanel2.Controls
            If TypeOf ctrl Is Panel And ctrl.Tag = 2 Then ctrl.BackColor = Color.Coral
            If TypeOf ctrl Is Label And ctrl.Tag = 2 Then ctrl.ForeColor = Color.Coral
        Next

        Select Case strSearchFor
            Case "Cadre"
                strWhereClouse = "AND shiftLine=1 "
                strDispCount = "Total"
                Panel43.BackColor = Color.Navy
                lblCCardre.ForeColor = Color.Navy
            Case "Present"
                strWhereClouse = " AND antStatus=1"
                strDispCount = "Present"
                Panel44.BackColor = Color.Navy
                lblCPresent.ForeColor = Color.Navy
            Case "PresentLeave"
                strWhereClouse = "AND shiftLine=1 AND isLeave=1 AND antStatus=1"
                strDispCount = ""
                Panel45.BackColor = Color.Navy
                lblCLeve.ForeColor = Color.Navy
            Case "Late"
                strWhereClouse = "AND shiftLine=1 AND isLate=1"
                strDispCount = "Late"
                Panel46.BackColor = Color.Navy
                lBlCLate.ForeColor = Color.Navy
            Case "Incomplete"
                strWhereClouse = "AND antStatus=1 AND nrWorkDay=0 AND outUpdate=0 AND shiftLine=1"
                strDispCount = "Incomplete"
                lblCInccom.ForeColor = Color.Navy
                Panel47.BackColor = Color.Navy
            Case "PresentOff"
                strWhereClouse = "AND shiftLine=1 AND antStatus=1 AND workUnit=0"
                strDispCount = "Present Off"
                Panel48.BackColor = Color.Navy
                lblCPreOffk.ForeColor = Color.Navy
            Case "Duplicate"
                strWhereClouse = "AND shiftLine=1 AND InTimeNoSec =outTimeNoSec and inUpdate=1"
                strDispCount = "Duplicate"
                Panel49.BackColor = Color.Navy
                lblCDup.ForeColor = Color.Navy
            Case "OverTime"
                strWhereClouse = " AND totalOT>0"
                strDispCount = "Overtime"
                Panel50.BackColor = Color.Navy
                lblCOt.ForeColor = Color.Navy
            Case "Absent"
                If chkAbsent.Checked = True Then
                    strWhereClouse = "AND shiftLine=1 AND antStatus=0 AND isLeave=0 AND workUnit<>0"
                Else
                    strWhereClouse = "AND shiftLine=1 AND antStatus=0"
                End If
                strDispCount = "Absent"
                Panel51.BackColor = Color.Navy
                lblCAb.ForeColor = Color.Navy
            Case "OffDay"
                strWhereClouse = "AND shiftLine=1 AND workUnit=0 "
                strDispCount = "Off Day"
                Panel52.BackColor = Color.Navy
                lblCOf.ForeColor = Color.Navy
            Case "HalfDay"
                strWhereClouse = "AND shiftLine=1 AND nrWorkDay=0.5"
                strDispCount = "Half Day"
                Panel53.BackColor = Color.Navy
                lblCHalfday.ForeColor = Color.Navy
            Case "OnLeave"
                strWhereClouse = "AND shiftLine=1 AND isLeave=1 "
                strDispCount = "On Leave"
                Panel54.BackColor = Color.Navy
                lblCLeave.ForeColor = Color.Navy
            Case "Nopay"
                strWhereClouse = "AND shiftLine=1 AND nrWorkDay=0 AND isLeave=0 AND workUnit<>0"
                strDispCount = "Nopay"
                Panel55.BackColor = Color.Navy
                lblCNop.ForeColor = Color.Navy
            Case "FixNight"
                strWhereClouse = "AND dateGap=1"
                strDispCount = "Fixed Night"
                Panel16.BackColor = Color.Navy
                lblCFix.ForeColor = Color.Navy
            Case "NightWorked"
                strWhereClouse = "AND shiftLine=1 AND antStatus=1 AND outUpdate=0"
                strDispCount = "Night Worked"
                Panel56.BackColor = Color.Navy
                lblCNight.ForeColor = Color.Navy
            Case "SplitDay"
                strWhereClouse = "AND isSplit=1"
                strDispCount = "Split Duty"
                Panel15.BackColor = Color.Navy
                lblCSplit.ForeColor = Color.Navy
            Case "ExtraDay"
                strWhereClouse = "AND antStatus=1 AND adDay<>0"
                strDispCount = "Extra Day"
                Panel14.BackColor = Color.Navy
                lblCExtraDay.ForeColor = Color.Navy

        End Select

        Try
            Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", FK_GetIDR(cmbDept.Text))
            Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", FK_GetIDR(cmbCat.Text))
            Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", FK_GetIDR(cmbDesg.Text))
            Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", FK_GetIDR(cmbShiftName.Text))
            Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))
            Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))
            Dim strTypeName As String = IIf(cmbType.Text = "[ALL]", "", FK_GetIDR(cmbType.Text))
            Dim strTitle As String = IIf(cmbTitle.Text = "[ALL]", "", FK_GetIDR(cmbTitle.Text))

            'Dim strWorkHour As String = IIf(chkWorkHrs.CheckState = CheckState.Unchecked, "", ",WorkHrs AS 'Work Hrs'")
            'Dim strOTHour As String = IIf(chkOTHour.CheckState = CheckState.Unchecked, "", ",NormalOTHrs AS 'Normal OTHrs'")
            'Dim strLateMins As String = IIf(chkLateHour.CheckState = CheckState.Unchecked, "", ",LateMins AS 'Late Mins'")
            'Dim strEarlyMins As String = IIf(chkEarlyHur.CheckState = CheckState.Unchecked, "", ",EarlyMins AS 'Early Mins'")

            'Dim srtRandomQuery As String = strWorkHour & strOTHour & strLateMins & strEarlyMins

            If strSearchFor = "NightWorked" Then
                chkNightOnly.Enabled = True
                If chkNightOnly.Checked = True Then
                    btnConfrmNight.Enabled = True
                    chkNightAll.Enabled = True
                    Fk_FillDataSetNight("exec SP_NightConfirm  '" & Format(dtpToDate.Value, "yyyyMMdd") & "'")

                    Dim dv2 As DataView = New DataView(sTablek.Tables("tblEmployeeVN"))
                    Dim dt2 As New DataTable
                    sSQL = "Empstatus<>9   AND (EmpNo LIKE '%" + txtSearch.Text.Trim() + "%' OR DispName LIKE '%" + txtSearch.Text.Trim() + "%') and deptID in ('" & StrUserLvDept & "') AND  brID IN ('" & StrUserLvBranch & "') AND  (DesigID LIKE '%" + StrDesigName.Trim() + "%' AND deptID LIKE '%" + StrDeptname.Trim() + "%' AND catID LIKE '%" + StrSubCatName.Trim() + "%'  AND brID LIKE '%" + StrBranchName.Trim() + "%' AND TypeID LIKE '%" + strTypeName.Trim() + "%' AND titleID LIKE '%" + strTitle.Trim() + "%' ) "
                    dv2.RowFilter = sSQL
                    dv2.Sort = " EmpNo ASC"
                    dt2 = dv2.ToTable(True, "RegID", "EmpNo", "DispName", "InDate", "inTime", "OutDate", "outTime", "workHrs", "shiftName", "dayType", "normalOT", "doubleOT", "tripleOT", "totalOT", "Confirm", "shiftMode")
                    dgvData.DataSource = dt2

                    dgvData.ReadOnly = False

                    With dgvData
                        .Columns(0).HeaderText = "Reg ID"
                        .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(0).Visible = False
                        .Columns(1).HeaderText = "Emp No"
                        .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(2).HeaderText = "Employee Name"
                        .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(3).HeaderText = "In Date"
                        .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(4).HeaderText = "In Time"
                        .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(5).HeaderText = "Out Date"
                        .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(6).HeaderText = "Out Time"
                        .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                        .Columns(7).HeaderText = "Work Hours"
                        .Columns(7).Width = 46
                        .Columns(8).HeaderText = "Shift"
                        .Columns(8).Width = 46
                        .Columns(9).HeaderText = "Day Type"
                        .Columns(9).Width = 46
                        .Columns(10).HeaderText = "Normal OT"
                        .Columns(10).Width = 44
                        .Columns(11).HeaderText = "Double OT"
                        .Columns(11).Width = 44
                        .Columns(12).HeaderText = "Triple OT"
                        .Columns(12).Width = 44
                        .Columns(13).HeaderText = "Normal Day"
                        .Columns(13).Width = 44
                        .Columns(14).HeaderText = "Confirm"
                        .Columns(14).Width = 28
                        .Columns(15).HeaderText = "shiftMode"
                        .Columns(15).Width = 24
                    End With

                    For K As Integer = 0 To dgvData.RowCount - 1
                        If CBool(dgvData.Item(14, K).Value) = True Then
                            dgvData.Rows(K).Cells(14).Style.BackColor = Color.Navy : dgvData.Item(14, K).Value = False
                        Else
                            dgvData.Rows(K).Cells(14).Style.BackColor = Color.White
                        End If
                    Next

                    For l As Integer = 0 To dgvData.RowCount - 1
                        If Val(dgvData.Item(15, l).Value) = 0 Then
                            dgvData.Item(14, l).Value = False
                        Else
                            dgvData.Item(14, l).Value = True
                        End If
                    Next

                    strDispCount = strDispCount & " Records : " & dgvData.RowCount
                    Label1.Text = strDispCount
                    Me.Cursor = Cursors.Default
                    Exit Sub
                ElseIf chkNightOnly.Checked = False Then
                    intLoad = 1
                End If
                'sSQL = "CREATE TABLE #AtManager (atDate datetime,enrolNo numeric (18,0)) INSERT INTO #AtManager select tblEmpRegister.atDate,tblEmployee.enrolNo from tblEmpRegister,tblEmployee WHERE  tblEmployee.RegID=tblEmpRegister.EmpID AND tblEmpRegister.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' and tblEmpRegister.outupdate=0 and tblEmpRegister.antStatus=1 order by tblEmpRegister.outupdate "
                'sSQL = sSQL & "  select tblDiMachine.EmpID,atDate,Min(tblDiMachine.tTime) AS 'Ttime' Into #T_Time From #AtManager,tblDiMachine WHERE #AtManager.EnrolNo = tblDiMachine.EmpID  AND tblDiMachine.cDate = DateAdd(Day,1,#AtManager.atDate) AND tblDiMachine.Capture In (0,1,2,3) GROUP BY tblDiMachine.EmpID ,tblDiMachine.cDate ,#AtManager.atDate ; UPDATE #AtManager SET #AtManager.OutTime = #T_Time.tTime  FROM #T_Time,#AtManager WHERE #T_Time.EmpID = #AtManager.EnrolNo AND #T_Time.atDate = #AtManager.AtDate; "
            Else
                btnConfrmNight.Enabled = False
                chkNightOnly.Checked = False
                chkNightOnly.Enabled = False
                chkNightAll.Enabled = False
                sSQL = ""
                'intLoad = 1
                'ViewInformation(0)
            End If

            'dgvData.Columns.Add("regID", "Reg ID")
            'dgvData.Columns.Add("Name", "Name")
            'dgvData.Columns.Add("Intime", "Intime")
            'dgvData.Columns.Add("outTime", "outTime")
            'dgvData.Columns.Add("workHours", "workHours")
            'dgvData.Columns.Add("OTHour", "OTHour")

            '  " & strWhereClouse & " " & " " & " and 
            Dim dv As DataView = New DataView(sTablek.Tables("tblEmployeeV"))
            sSQL = "Empstatus<>9  " & strWhereClouse & " AND (EmpNo LIKE '%" + txtSearch.Text.Trim() + "%' OR DispName LIKE '%" + txtSearch.Text.Trim() + "%' OR EmpID LIKE '%" + txtSearch.Text.Trim() + "%') and deptID in ('" & StrUserLvDept & "') AND  brID IN ('" & StrUserLvBranch & "') AND  (DesigID LIKE '%" + StrDesigName.Trim() + "%' AND deptID LIKE '%" + StrDeptname.Trim() + "%' AND catID LIKE '%" + StrSubCatName.Trim() + "%' AND ShiftID LIKE '%" + strShiftName.Trim() + "%'  AND brID LIKE '%" + StrBranchName.Trim() + "%' AND TypeID LIKE '%" + strTypeName.Trim() + "%' AND titleID LIKE '%" + strTitle.Trim() + "%' AND shiftMode LIKE '%" + strShiftMod.Trim() + "%')"
            dv.RowFilter = sSQL
            dv.Sort = " EmpNo ASC,shiftLine"
            'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
            Dim dt As New DataTable
            dt = dv.ToTable(True, "EmpID", "EmpNo", "DispName", "InDate", "inTime", "OutDate", "outTime", "workHrs", "shiftName", "dayType", "totalOT", "nrWorkDay", "LateMins", "EarlyMins", "LvName", "DueMins", "DName", "adDay", "normalOT", "doubleOT", "tripleOT", "lunchMins", "dinnerMins", "isNightWork", "antStatus", "OutUpdate", "inUpdate", "isLate", "isLeave", "Empstatus", "deptID", "brID", "desigName", "deptName", "catName", "brName", "workUnit", "InTimeNoSec", "OutTimeNoSec", "shiftLine", "isSplit", "DesigID", "TypeID", "ShiftID", "titleID", "catID", "genderID", "shiftMode", "dateGap")
            dgvData.DataSource = dt

            lblCAb.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =0")), "0", dt.Compute("Count(EmpNo)", "AntStatus=0"))
            lBlCLate.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 AND isLate=1"))
            lblCPresent.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1"))
            lblCLeave.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "isLeave = 1"))
            lblCInccom.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 AND outUpdate = 0 AND shiftLine=1 AND nrWorkDay=0"))
            lblCOt.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 AND totalOT>0"))
            lblCOf.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "workUnit=0"))
            lblCCardre.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 or AntStatus =0"))
            lblCLeve.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "isLeave = 1 AND AntStatus =1"))
            lblCPreOffk.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 AND workUnit=0"))
            lblCHalfday.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "nrWorkDay = 0.5"))
            lblCNop.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =0")), "0", dt.Compute("Count(EmpNo)", "nrWorkDay =0 AND workUnit <>0 AND isLeave=0 AND shiftLine=1 "))
            lblCDup.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "inTimeNoSec=outTimeNoSec and inUpdate=1"))
            lblCNight.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 AND outUpdate=0 AND shiftLine=1  AND nrWorkDay=0"))
            lblCExtraDay.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "AntStatus =1")), "0", dt.Compute("Count(EmpNo)", "AntStatus =1 AND adDay<>0"))
            lblCSplit.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "")), "0", dt.Compute("Count(EmpNo)", "isSplit=1"))
            lblCFix.Text = IIf(IsDBNull(dt.Compute("Count(EmpNo)", "")), "0", dt.Compute("Count(EmpNo)", "dateGap=1"))

            'sSQL = "atDate  " & strWhereClouse & " " & " " & " and Empstatus<>9 and deptID in ('" & StrUserLvDept & "')   brID IN ('" & StrUserLvBranch & "') AND (dbo.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.DispName LIKE '% " & txtSearch.Text & " %' OR     " & _
            ' " dbo.tblEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR    " & _
            ' " dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND  (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%' AND dbo.TBLCBranchs.brName LIKE '" & StrBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

            '& " " & " and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND  tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.DispName LIKE '% " & txtSearch.Text & " %' OR     " & _
            '" dbo.tblEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR    " & _
            '" dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND  (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%' AND dbo.TBLCBranchs.brName LIKE '" & StrBranchName & "%')  "
            'dgvData.DataSource = dv

            'Else
            '    dgvData.DataSource = sTablek
            '    dgvData.DataMember = "tblEmployeeV"
            'End If

            'dgvData.cel
            'With dgvData
            '    .Columns(0).HeaderText = "Reg ID"
            '    .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(0).Visible = False
            '    .Columns(1).HeaderText = "Emp No"
            '    .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(2).HeaderText = "Employee Name"
            '    .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(3).HeaderText = "In Date"
            '    .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(4).HeaderText = "In Time"
            '    .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(5).HeaderText = "Out Date"
            '    .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(6).HeaderText = "Out Time"
            '    .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(7).HeaderText = "Work Hours"
            '    .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(8).HeaderText = "Shift"
            '    .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(9).HeaderText = "Day Type"
            '    .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(10).HeaderText = "Normal OT"
            '    .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(11).HeaderText = "Double OT"
            '    .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(12).HeaderText = "Triple OT"
            '    .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(13).HeaderText = "Total OT"
            '    .Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(14).HeaderText = "Due Minutes"
            '    .Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(15).HeaderText = "Extra Day"
            '    .Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(16).HeaderText = "Night Day"
            '    .Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            '    .Columns(17).HeaderText = "Leave Type"
            '    .Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'End With
            ''Fk_FillGrid(sSQL, dgvData)
            ''dgvData.ReadOnly = False
            ''dgvData.Columns(2).ReadOnly = True
            ''dgvData.Columns(3).ReadOnly = True
            strDispCount = strDispCount & " Records : " & dgvData.RowCount

            Label1.Text = strDispCount

            With dgvData
                For iRows As Integer = 0 To .RowCount - 1
                    Dim dblWorkUnit As Double = CDbl(.Item(36, iRows).Value)

                    If dblWorkUnit = 0.5 Then
                        'For k As Integer = 0 To 20
                        .Item(9, iRows).Style.BackColor = Color.Purple
                        'Next
                    ElseIf dblWorkUnit = 1 Then
                        'For k As Integer = 0 To 20
                        .Item(9, iRows).Style.BackColor = Color.SteelBlue
                        'Next
                    ElseIf dblWorkUnit = 0 Then
                        'For k As Integer = 0 To 20
                        .Item(9, iRows).Style.BackColor = Color.Pink
                        'Next
                    End If

                    Dim dblShiftLine As Double = CDbl(.Item(39, iRows).Value)
                    If dblShiftLine > 1 Then
                        .Item(4, iRows).Style.BackColor = Color.Green : .Item(6, iRows).Style.BackColor = Color.Green
                    End If
                Next
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Public Function fk_MasterFormat(ByVal dgv As DataGridView) As Boolean
        With dgv


            .Columns(0).HeaderText = "Reg ID"
            .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(1).HeaderText = "Emp No"
            .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(2).HeaderText = "Employee Name"
            .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(3).HeaderText = "In Date"
            .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(4).HeaderText = "In Time"
            .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(5).HeaderText = "Out Date"
            .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(6).HeaderText = "Out Time"
            .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(7).HeaderText = "Work Hours"
            .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(8).HeaderText = "Shift"
            .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(9).HeaderText = "Day Type"
            .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(10).HeaderText = "Normal OT"
            .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(11).HeaderText = "Double OT"
            .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(12).HeaderText = "Triple OT"
            .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(13).HeaderText = "Total OT"
            .Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(14).HeaderText = "Due Minutes"
            .Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(15).HeaderText = "Extra Day"
            .Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(16).HeaderText = "Night Day"
            .Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            .Columns(17).HeaderText = "Leave Type"
            .Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End With

        'For Each col As DataGridViewColumn In dgvData.Columns
        '    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        'Next
    End Function

    Private Sub lblPresent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        strSearchFor = "Present"
        CadreSearch()
    End Sub

    Private Sub lblAbsent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCAb.Click
        strSearchFor = "Absent"
        CadreSearch()
    End Sub

    Private Sub lblLate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lBlCLate.Click
        strSearchFor = "Late"
        CadreSearch()
    End Sub

    Private Sub lblLeave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCLeave.Click
        strSearchFor = "OnLeave"
        CadreSearch()
    End Sub

    Private Sub Label8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCOt.Click
        strSearchFor = "OverTime"
        CadreSearch()
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCOf.Click
        strSearchFor = "OffDay"
        CadreSearch()
    End Sub

    Private Sub lblTot_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCInccom.Click
        strSearchFor = "Incomplete"
        CadreSearch()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If pnlOption.Height = 48 Then
            pnlOption.Height = 0
        ElseIf pnlOption.Height = 0 Then
            pnlOption.Height = 48
        End If
    End Sub

    Private Sub lblCCardre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCCardre.Click
        strSearchFor = "Cadre"
        Button2_Click(sender, e) 'If intLoad = 1 Then
        '    Button2_Click(sender, e)
        'Else
        'ViewInformation(0)
        'CadreSearch()
        'End If
    End Sub

    Private Sub lblCDup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCDup.Click
        strSearchFor = "Duplicate"
        CadreSearch()
    End Sub

    Private Sub lblCPresent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCPresent.Click
        strSearchFor = "Present"
        CadreSearch()
    End Sub

    Private Sub dtpToDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged
        If Format(dtpSelectDatek.Value, "yyyyMMdd") <> Format(dtpToDate.Value, "yyyyMMdd") Then
            dtpSelectDatek.Value = dtpToDate.Value
        End If
        lblCurDate.Text = Format(dtpToDate.Value, "yyyy-MMM-dd")
        'lblDate.Text = Format(dtpToDate.Value, "yyyy-MMM-dd")
        'If intLoad = 1 Then
        '    ViewInformation()
        '    CadreSearch()
        'End If
    End Sub

    Private Sub lblCLeve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCLeve.Click
        strSearchFor = "PresentLeave"
        CadreSearch()
    End Sub

    Private Sub lblCPreOffk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCPreOffk.Click
        strSearchFor = "PresentOff"
        CadreSearch()
    End Sub

    Private Sub Label32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDuplicate.Click
        strSearchFor = "Duplicate"
        CadreSearch()
    End Sub

    Private Sub lblCHalfday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCHalfday.Click
        strSearchFor = "HalfDay"
        CadreSearch()
    End Sub

    Private Sub lblCNop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCNop.Click
        strSearchFor = "Nopay"
        CadreSearch()
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        'If intLoad = 1 Then
        CadreSearch()
        'End If
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub cmbTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTitle.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub cmbShiftName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShiftName.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub cmbShiftType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShiftType.SelectedIndexChanged
        If intLoad = 1 Then
            CadreSearch()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Length >= 6 Then
            CadreSearch()
        End If
        If txtSearch.Text.Length Mod 2 = 0 Then
            CadreSearch()
        End If
    End Sub

    Private Sub dgvData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        If pnlHide.Width = 366 Then
            AtnDate1 = CDate(dgvData.CurrentRow.Cells(3).Value)
            StrEmployeeID = Trim(dgvData.CurrentRow.Cells(0).Value)
            If dgvData.CurrentRow.Cells(1).Selected = True Then
                If strClick = 1 Then ViewFinger() Else ViewAttendanceSAllDays()
            End If
        End If
        strKEmployeeID = StrEmployeeID
    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        Me.Visible = False
        strKEmployeeID = Trim(dgvData.CurrentRow.Cells(0).Value)
        'frmMainAttendance.pnlAllDynamic.Controls.
        Dim frmReg As New frmIndividualAttendanceEdit
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()

        Me.Visible = True
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, -1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, -1, dtpToDate.Value)
        ViewInformation(0)
        CadreSearch()
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, 1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        ViewInformation(0)
        CadreSearch()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        '20180817 prasanna After month End Can't Change preview days attendance
        If UserLevelID <> "000" Then
            If dtpFromDate.Value <= MaxmunMonthEndDate Then MsgBox("Cant Adjustment   : Your Last Month ('" & MaxmunMonthEndDate & "') Is Over  ", MsgBoxStyle.Information) : Exit Sub
        End If
        '-----------------------------


        If pnlHide.Width = 0 Then
            pnlHide.Width = 366
            btnTime_Click(sender, e)
        ElseIf pnlHide.Width = 366 Then
            pnlHide.Width = 0
        End If

        sSQL = "select 'False',machinid,mDesc from tbldeviceinfo where status=0"
        Load_InformationtoGrid(sSQL, dgvMachin, 3)

        sSQL = "SELECT ShiftID,ShortCode,case when shiftmode =0 then 'Day' else 'Night' end as 'Shift Mode',CONVERT(VARCHAR(8),inTime,108) AS 'In Time',CONVERT(VARCHAR(8),outTime,108) AS 'Out Time' FROM tblSetShiftH WHERE shiftID IN ('" & StrUserLvShifts & "') Order By ShiftID"
        Load_InformationtoGrid(sSQL, dgvAllShifts, 5)

        Load_InformationtoGrid("select TypeID,TypeName,shortCode,workUnit,Clra,clrr,clrg,clrb From tblDayTYpe WHERE Status =0 Order By TypeID", dgvDayType, 8)

    End Sub

    Public Sub getSelectedArea()
        If DateDiff(DateInterval.Day, dtpFromDate.Value.Date, dtpToDate.Value.Date) > 0 Then MessageBox.Show("You can change only one day through this screen.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpFromDate.Value = dtpToDate.Value : Exit Sub

        If intSelecTab = 3 Then
            dgvData.ClearSelection()
            For kk As Integer = 0 To dgvData.RowCount - 1
                dgvData.Item(1, kk).Selected = True
            Next

        End If
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
                        If intSelecTab = 3 Then
                            'If intColumn = 14 Then
                            If CBool(dgvData.Item(14, intRow).Value) = True Then
                                strSelDate = Trim(dgvData.Item(0, intRow).Value)
                                strCollectDisplay = Trim(dgvData.Item(1, intRow).Value)
                                strCellName = strCellName & "'" & strSelDate & "'" & ","
                                strDisplaySelected = strDisplaySelected & "'" & strCollectDisplay & "'" & ","
                                intEmp = intEmp + 1
                            End If

                            'End If

                        Else
                            If intColumn = 1 Then
                                strSelDate = Trim(dgvData.Item(0, intRow).Value)
                                strCollectDisplay = Trim(dgvData.Item(1, intRow).Value)
                                'strSelDate = Format(dtDate, "yyyyMMdd")
                                strCellName = strCellName & "'" & strSelDate & "'" & ","
                                strDisplaySelected = strDisplaySelected & "'" & strCollectDisplay & "'" & ","
                                'dgvData.Item(1, intRow).Selected = True
                                intEmp = intEmp + 1
                            End If
                        End If


                    Next i

                    If strCellName = "" Then Exit Sub
                    lblSelectedEmpoyees.Text = "Selected Employee(s ) : " & intEmp & "     " & Replace(strDisplaySelected, "'", "")
                    strCellName = Microsoft.VisualBasic.Left(strCellName, strCellName.Length - 1)
                    strKEmployeeID = strCellName

                    If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 1 Then
                        MessageBox.Show("You can edit only one day attendance at one time through this screen, Please select one only one day", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpToDate.Value = dtpFromDate.Value : ViewInformation(0) : CadreSearch() : Exit Sub
                    End If

                    If intSelecTab = 0 Then
                        rdbDayType.Checked = False
                        rdbShift.Checked = True
                        rdbAddFinger.Checked = False
                        ShiftSave()
                    ElseIf intSelecTab = 1 Then
                        rdbDayType.Checked = True
                        rdbShift.Checked = False
                        rdbAddFinger.Checked = False
                        DayTypeSave()
                    ElseIf intSelecTab = 2 Then
                        rdbDayType.Checked = False
                        rdbShift.Checked = False
                        rdbAddFinger.Checked = True
                        AddFingerTime()
                    End If
                End If

                'fk_SaveSelectedShift(StrcEmpID, strCellName, StrSelShiftID, intTabSelected)

                If bolOK = False Then Exit Sub

                If intSelecTab = 0 Then

                    Dim k As Integer
                    For k = 0 To selectedCellCount - 1

                        intRow = (dgvData.SelectedCells(k).RowIndex _
                            .ToString())
                        intColumn = (dgvData.SelectedCells(k).ColumnIndex _
                            .ToString())
                        If 1 = intColumn Then
                            dgvData.Item(8, intRow).Value = StrSelShift
                            'dgvData.Item(1, intRow).Value = True
                        End If
                    Next k
                ElseIf intSelecTab = 1 Then
                    Dim l As Integer
                    For l = 0 To selectedCellCount - 1

                        intRow = (dgvData.SelectedCells(l).RowIndex _
                            .ToString())
                        intColumn = (dgvData.SelectedCells(l).ColumnIndex _
                            .ToString())
                        If 1 = intColumn Then
                            dgvData.Item(9, intRow).Style.BackColor = clrDay
                            dgvData.Item(9, intRow).Value = strNDay
                            'dgvData.Item(1, intRow).Value = True
                        End If
                        'dgvEmployee.Item(intColumn, intRow).Value = StrSelShiftID
                    Next l

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Public Function fk_SaveSelectedShift(ByVal StrnEmpID As String, ByVal strAllDate As String, ByVal StrnShiftID As String, ByVal intWatSave As Integer) As Boolean
    '    Dim sqlQRY As String
    '    'Check Approved Options
    '    Dim bolAllw As Boolean = False
    '    sSQL = "SELECT * FROM tblEmpRegister WHERE EmpID = '" & StrnEmpID & "' AND AtDate in  (" & strAllDate & ") AND rOption = 2"
    '    bolAllw = fk_CheckEx(sSQL)
    '    If bolAllw = True Then MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Function

    '    If intRosterOpt <= 1 Then
    '        MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Function
    '    End If

    '    Select Case intWatSave
    '        Case 0
    '            StrnShiftID = fk_ReturnShiftID(StrnShiftID)
    '            sqlQRY = "UPDATE tblEmpRegister SET AllShifts = '" & StrnShiftID & "' WHERE EmpID = '" & StrnEmpID & "' AND AtDate in (" & strAllDate & ");  INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Change Employee Roster of  " & StrnEmpID & " to shift " & StrnShiftID & " of days " & Replace(strAllDate, "'", "") & "' ,'" & StrUserID & "',getdate ())"
    '            If FK_EQ(sqlQRY, "S", "", False, False, True) = True Then
    '                bolOK = True
    '            Else
    '                bolOK = False
    '            End If
    '        Case 1
    '            sqlQRY = "UPDATE tblEmpRegister SET DayTypeID = '" & StrnShiftID & "' WHERE EmpID = '" & StrnEmpID & "' AND AtDate in (" & strAllDate & ");  INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Change Employee Day Type of  " & StrnEmpID & " to Type " & StrnShiftID & " of days " & Replace(strAllDate, "'", "") & "' ,'" & StrUserID & "',getdate ())"
    '            If FK_EQ(sqlQRY, "S", "", False, False, True) = True Then
    '                bolOK = True
    '            Else
    '                bolOK = False
    '            End If
    '            'Color Cell
    '    End Select

    'End Function

    Public Function fk_ReturnShiftID(ByVal StrShCodes As String) As String
        Dim StrRval As String = Nothing

        Try
            StrRval = fk_RetString("SELECT ShiftID FROM tblSetShiftH WHERE ShortCode = '" & StrShCodes & "'")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Return StrRval
    End Function

    Private Sub dgvData_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        If dgvData.CurrentRow.Cells(1).Value = True Then
            dgvData.CurrentRow.Cells(2).Selected = True
        End If
    End Sub

    Private Sub AddFingerTime()
        intSelecTab = 2
        Try
            Me.Cursor = Cursors.WaitCursor
            If strKEmployeeID = "" Then MsgBox("Please select the Employee ", MsgBoxStyle.Information) : Exit Sub
            'Dim dgvTempDGV As New DataGridView
            sSQL = "select enrolno,regID from tblemployee where regid in(" & strKEmployeeID & ")"
            Fk_FillGrid(sSQL, dgvTempDGV)

            If MsgBox("Do you want to add manually attendance record to employee(s) of  " & strKEmployeeID & " - for " & Format(dtpToDate.Value, "yyyy-MM-dd") & "  ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

            Dim intTriD As Integer = fk_sqlDbl("SELECT fxTrID+1 FROM tblControl")

            sSQL = ""
            For I As Integer = 0 To dgvTempDGV.RowCount - 1
                sSQL = sSQL & "INSERT INTO tblDiMachine (MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode,Capture,tTime,EditMode) VALUES " & _
                                  " ('" & strSelestedMac & "',1," & Val(dgvTempDGV.Item(0, I).Value) & ",1,1,'" & Format(dtpToDate.Value, "yyyyMMdd") & "','" & Format(dtpTime.Value, "hh:mm tt") & "',0,0,'',1)"
                sSQL = sSQL & " INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Add attendance data manually for Enrol No :  " & Val(dgvTempDGV.Item(0, I).Value) & " and Date : " & Format(dtpToDate.Value, "yyyyMMdd") & " and Time : " & Format(dtpTime.Value, "hh:mm tt") & " and Device : " & strSelestedMac & " and Note " & FK_Rep(txtNote.Text) & "' ,'" & StrUserID & "',getdate (),'" & Val(dgvTempDGV.Item(1, I).Value) & "')  ; "
                sSQL = sSQL & "INSERT INTO [tbldimachineManual] (MacID,EmpID,Input,cDate,cTime,Capture,tTime,crUser,crDate,remark,trID,rowNo) VALUES " & _
                                  " ('" & strSelestedMac & "'," & Val(dgvTempDGV.Item(0, I).Value) & ",1,'" & Format(dtpToDate.Value, "yyyyMMdd") & "','" & Format(dtpTime.Value, "hh:mm tt") & "',0,'','" & StrUserID & "',getdate (),'" & txtNote.Text & "'," & intTriD & "," & I & ")"
                sSQL = sSQL & " UPDATE tblDiMachine SET tTime = cDate+cTime WHERE cDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "'; UPDATE tblEmpRegister SET textNote ='" & txtNote.Text & "' WHERE atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND empID in(" & strKEmployeeID & "); UPDATE tblControl SET fxTrID=" & intTriD & " WHERE GrpID='001' ;UPDATE tblDiMachineManual SET tTime = cDate+cTime WHERE cDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
            Next
            FK_EQ(sSQL, "S", "", False, False, True)
            dgvData.Focus()
            Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
            strKEmployeeID = strKEmployeeID.Remove(0, 1)
            strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)
            pgb.Visible = True

            '#ISA-099

            'If intBaseOnClockRecord = 0 Then
            '    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & strKEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtpToDate.Value, dtFingerPrintMaxDate, pgb, 0, 0)
            'Else
            '    Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, strKEmployeeID, "O", pgb)
            'End If

            Select Case intBaseOnClockRecord
                Case 0
                    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & strKEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtpToDate.Value, dtFingerPrintMaxDate, pgb, 0, 0)
                Case 1
                    Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, strKEmployeeID, "O", pgb)
                Case 2
                    fk_ProcessStraght(dtpToDate.Value, dtpToDate.Value, pgb, "O", strKEmployeeID)
            End Select
            pgb.Visible = False

            If chkAutoRefresh.Checked = True Then
                ViewInformation(0)
                CadreSearch()
            End If

            'Process Attendance
            'btnShow_Click(sender, e)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ShiftSave()
        intSelecTab = 0
        Dim bolAllw As Boolean = False
        sSQL = "SELECT empid FROM tblEmpRegister WHERE EmpID in (" & strKEmployeeID & ") AND AtDate =  '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND rOption = 2"
        bolAllw = fk_CheckEx(sSQL)
        If bolAllw = True Then MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        If StrSelShiftID = "" Then MessageBox.Show("Please select shift to copy", "Edit Shift", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If

        sSQL = "select regID from tblemployee where regid in(" & strKEmployeeID & ")"
        Fk_FillGrid(sSQL, dgvTempDGV)

        sSQL = ""
        For I As Integer = 0 To dgvTempDGV.RowCount - 1
            sSQL = sSQL & "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Change Employee Shift of  " & dgvTempDGV.Item(0, I).Value & " to Shift " & StrSelShiftID & " of day " & Format(dtpToDate.Value, "yyyyMMdd") & "' ,'" & StrUserID & "',getdate (),'" & dgvTempDGV.Item(0, I).Value & " ');"
        Next

        sSQL = sSQL & "UPDATE tblEmpRegister SET AllShifts = '" & StrSelShiftID & "' WHERE EmpID in (" & strKEmployeeID & ") AND AtDate ='" & Format(dtpToDate.Value, "yyyyMMdd") & "';  "
        If FK_EQ(sSQL, "S", "", False, False, True) = True Then
            bolOK = True
        Else
            bolOK = False
        End If

    End Sub

    Private Sub dgvMachin_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMachin.CellClick
        For l As Integer = 0 To dgvMachin.RowCount - 1
            dgvMachin.Item(0, l).Value = False
        Next
        dgvMachin.CurrentRow.Cells(0).Value = True
        strSelestedMac = dgvMachin.CurrentRow.Cells(1).Value.ToString
    End Sub

    Private Sub DayTypeSave()
        intSelecTab = 1
        Dim bolAllw As Boolean = False
        sSQL = "SELECT empid FROM tblEmpRegister WHERE EmpID in (" & strKEmployeeID & ") AND AtDate =  '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND rOption = 2"
        bolAllw = fk_CheckEx(sSQL)
        If bolAllw = True Then MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        If StrnDayTypID = "" Then MessageBox.Show("Please select day type to copy", "Edit Day Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If

        sSQL = "select regID from tblemployee where regid in(" & strKEmployeeID & ")"
        Fk_FillGrid(sSQL, dgvTempDGV)

        sSQL = ""
        For I As Integer = 0 To dgvTempDGV.RowCount - 1
            sSQL = sSQL & "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Change Employee Day Type of  " & dgvTempDGV.Item(0, I).Value & " to day type " & StrnDayTypID & " of day " & Format(dtpToDate.Value, "yyyyMMdd") & "' ,'" & StrUserID & "',getdate (),'" & dgvTempDGV.Item(0, I).Value & " ');"
        Next

        sSQL = sSQL & "UPDATE tblEmpRegister SET DayTypeID = '" & StrnDayTypID & "' WHERE EmpID in (" & strKEmployeeID & ") AND AtDate ='" & Format(dtpToDate.Value, "yyyyMMdd") & "';"
        If FK_EQ(sSQL, "S", "", False, False, True) = True Then
            bolOK = True
        Else
            bolOK = False
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If intLoad = 1 Then
        ViewInformation(1)

        InitialLoad()
        'End If
        strSearchFor = "Cadre"
        ViewInformation(0)
        CadreSearch()
        intLoad = 0
    End Sub

    Private Sub btnDayTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDayTypeEdit.Click
        If UP("Daily attendance", "Edit employee(s) day types") = False Then Exit Sub
        StrnDayTypID = dgvDayType.CurrentRow.Cells(0).Value.ToString
        strNDay = dgvDayType.CurrentRow.Cells(2).Value.ToString
        clrDay = Color.FromArgb(CInt(dgvDayType.Item(4, dgvDayType.CurrentRow.Index).Value), dgvDayType.Item(5, dgvDayType.CurrentRow.Index).Value, dgvDayType.Item(6, dgvDayType.CurrentRow.Index).Value, dgvDayType.Item(7, dgvDayType.CurrentRow.Index).Value)

        intSelecTab = 1
        getSelectedArea()
        rdbDayType.Checked = True
        rdbShift.Checked = False
        rdbAddFinger.Checked = False
    End Sub

    Private Sub btnShiftEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftEdit.Click
        If UP("Daily attendance", "Edit employee(s) shift") = False Then Exit Sub
        intSelecTab = 0
        getSelectedArea()
        rdbDayType.Checked = False
        rdbShift.Checked = True
        rdbAddFinger.Checked = False
    End Sub

    Private Sub btnAddFinger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFinger.Click
        If UP("Daily attendance", "Add punch times") = False Then Exit Sub
        intSelecTab = 2
        getSelectedArea()
        rdbDayType.Checked = False
        rdbShift.Checked = False
        rdbAddFinger.Checked = True
    End Sub

    Private Sub dgvAllShifts_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllShifts.CellClick

    End Sub

    Private Sub dgvDayType_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDayType.CellDoubleClick
        btnDayTypeEdit_Click(sender, e)
    End Sub

    Private Sub dgvAllShifts_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllShifts.CellDoubleClick
        StrSelShiftID = dgvAllShifts.CurrentRow.Cells(0).Value.ToString
        StrSelShift = dgvAllShifts.CurrentRow.Cells(1).Value.ToString
        btnShiftEdit_Click(sender, e)
    End Sub

    Private Sub rdbAddFinger_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbAddFinger.Click
        If rdbAddFinger.Checked = True Then
            rdbDayType.Checked = False
            rdbShift.Checked = False
        End If
    End Sub

    Private Sub rdbDayType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDayType.Click
        If rdbDayType.Checked = True Then
            rdbShift.Checked = False
            rdbAddFinger.Checked = False
        End If
    End Sub

    Private Sub rdbShift_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbShift.Click
        If rdbShift.Checked = False Then
            rdbAddFinger.Checked = False
            rdbDayType.Checked = False
        End If
    End Sub

    Private Sub ViewFinger()
        If UP("Daily attendance", "View finger times") = False Then Exit Sub
        strClick = 1
        Dim prvDate As Date : Dim nextDate As Date
        If AtnDate1 = "12:00:00 AM" Then Exit Sub
        prvDate = DateAdd(DateInterval.Day, -1, AtnDate1) : nextDate = DateAdd(DateInterval.Day, 1, AtnDate1)
        Dim sqlLoad As String = "DECLARE @EnrolNO AS NUMERIC(18,0); SET @EnrolNO = (SELECT EnrolNo FROM tblEmployee WHERE RegID='" & StrEmployeeID & "') ; SELECT tblDiMachine.crLine,Convert(Nvarchar (10),tblDiMachine.cDate,110),cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblDiMachine.cTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),tblDimachine.tTime,Case when tblDiMachine.EditMode = 0 THEN 'A' Else 'M' ENd,macID,empid FROM tblDiMachine WHERE tblDiMachine.cDate Between '" & Format(prvDate, "yyyyMMdd") & "' AND '" & Format(nextDate, "yyyyMMdd") & "' AND tblDiMachine.Capture In (0,1,2,3) AND tblDimachine.EmpID=@EnrolNO Order By tblDiMachine.cDate,tblDimachine.cTime"
        Load_InformationtoGrid(sqlLoad, dgvAtnTimes, 7)
        Dim strType As String = ""
        With dgvAtnTimes
            For iRows As Integer = 0 To .RowCount - 1

                Dim strCompare As Date = DateTime.Parse(.Item(1, iRows).Value, CultureInfo.InvariantCulture)
                ''CDate(.Item(1, iRows).Value)
                strType = CStr(.Item(4, iRows).Value)
                If Format(AtnDate1, "yyyyMMdd") = Format(strCompare, "yyyyMMdd") Then
                    For iCols As Integer = 0 To .ColumnCount - 1
                        .Item(iCols, iRows).Style.BackColor = Color.SteelBlue
                    Next
                End If
                If strType = "M" Then
                    For iCols As Integer = 0 To .ColumnCount - 1
                        .Item(iCols, iRows).Style.BackColor = Color.Red
                    Next
                End If
            Next

        End With
        pnlPunchTime.Width = 366
        dgvAtnTimes.ReadOnly = True

    End Sub

    Private Sub ViewAttendanceSAllDays()
        strClick = 2
        'load for casting
        If AtnDate1 = "12:00:00 AM" Then Exit Sub
        Dim prvDate As Date : Dim nextDate As Date
        prvDate = DateAdd(DateInterval.Day, -1, AtnDate1) : nextDate = DateAdd(DateInterval.Day, 1, AtnDate1)
        sSQL = "select Convert(Nvarchar (10),atdate,111),Convert(Nvarchar(5),InTime,108),Convert(Nvarchar(10),OutTime,111),Convert(Nvarchar(5),OutTime,108),InUpdate,OutUpdate from tblGetInOut where empid = '" & StrEmployeeID & "'  and atdate between '" & Format(prvDate, "yyyyMMdd") & "' AND '" & Format(nextDate, "yyyyMMdd") & "' Order by atDate,inTime"
        Load_InformationtoGrid(sSQL, dgvForcast, 6)
        Dim StrVal As String
        With dgvForcast
            Dim i As Integer = 0
            For Each row As DataGridViewRow In .Rows
                i = row.Index
                StrVal = .Item(4, i).Value & .Item(5, i).Value
                If StrVal = "11" Then row.DefaultCellStyle.BackColor = Color.White Else row.DefaultCellStyle.BackColor = Color.AliceBlue
            Next
        End With
        pnlPunchTime.Width = 0
    End Sub

    Private Sub lnkHistory_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkHistory.LinkClicked
        strClick = 1
        ViewFinger()
    End Sub

    Private Sub lnkPunch_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkPunch.LinkClicked
        strClick = 2
        ViewAttendanceSAllDays()
    End Sub

    Private Sub RemoveBulkPunchedTime()
        If UP("Daily attendance", "Bulkly Remove employee punch time(s)") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor

        'Select required data
        getSelectedAreaToRemoveTime()

        If dgvTempDGVk.RowCount = 0 Then MessageBox.Show("Please select punch time record(s) from 'Time' column to remove", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Me.Cursor = Cursors.Default : Exit Sub
        If MsgBox("Do you want to remove " & dgvTempDGVk.RowCount & " time records ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

        sSQL = ""

        For I As Integer = 0 To dgvTempDGVk.RowCount - 1
            Dim dtTTime As DateTime : Dim intCrRow As Integer
            StrEmployeeID = Trim(dgvTempDGVk.Item(0, I).Value)
            dtTTime = dgvTempDGVk.Item(2, I).Value
            intCrRow = Val(dgvTempDGVk.Item(3, I).Value)
            Dim intEnrol As Integer = Val(dgvTempDGVk.Item(1, I).Value)
            Dim strMacID As String = Trim(dgvTempDGVk.Item(4, I).Value)
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
        'strKEmployeeID = strKEmployeeID.Remove(0, 1)
        'strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)
        pgb.Visible = True
        If bolOK = True Then
            Select Case intBaseOnClockRecord
                Case 0
                    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtpToDate.Value, dtFingerPrintMaxDate, pgb, 0, 0)
                Case 1
                    Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
                Case 2
                    fk_ProcessStraght(dtpToDate.Value, dtFingerPrintMaxDate, pgb, "O", strKEmployeeID)

            End Select
        End If
        If chkAutoRefresh.Checked = True Then
            ViewInformation(0)
            CadreSearch()
        End If


        pgb.Visible = False

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub getSelectedAreaToRemoveTime()

        Dim selectedCellCount As Integer = _
        dgvAtnTimes.GetCellCount(DataGridViewElementStates.Selected)
        Dim intRow As Integer : Dim intColumn As Integer : Dim strCellName As String
        Dim StrcEmpID As String = ""
        Dim strSelDate As String
        strDisplaySelected = ""
        strCollectDisplay = ""
        'Dim selectedRowCount As Integer = _
        'dgvEmployee.SelectedRows.Count
        'Dim intCurrentColumn As Integer = dgvData.se/
        If selectedCellCount = 0 Then MessageBox.Show("Please select punched times to remove", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        Try
            intEmp = 0
            If selectedCellCount > 0 Then
                dgvTempDGVk.Rows.Clear()
                dgvTempDGVk.Columns.Clear()
                dgvTempDGVk.Columns.Add("RegID", "Reg ID")
                dgvTempDGVk.Columns.Add("EnrolNo", "Enro lNo")
                dgvTempDGVk.Columns.Add("tTime", "Tot Time")
                dgvTempDGVk.Columns.Add("crLine", "Line")
                dgvTempDGVk.Columns.Add("MacID", "Mac ID")

                If dgvAtnTimes.AreAllCellsSelected(True) Then
                    MessageBox.Show("All cells are selected", "Selected Cells")
                Else
                    strCellName = ""
                    Dim i As Integer
                    For i = 0 To selectedCellCount - 1
                        Try
                            intRow = (dgvAtnTimes.SelectedCells(i).RowIndex _
                                                       .ToString())
                            intColumn = (dgvAtnTimes.SelectedCells(i).ColumnIndex _
                                .ToString())
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try

                        'dgvData.Item(intColumn, intRow).Selected = False

                        If intColumn = 2 Then
                            'strSelDate = Trim(dgvAtnTimes.Item(0, intRow).Value)
                            'strCollectDisplay = Trim(dgvAtnTimes.Item(1, intRow).Value)
                            ''strSelDate = Format(dtDate, "yyyyMMdd")
                            'strCellName = strCellName & "'" & strSelDate & "'" & ","
                            'strDisplaySelected = strDisplaySelected & "'" & strCollectDisplay & "'" & ","
                            'dgvData.Item(1, intRow).Selected = True
                            intEmp = intEmp + 1
                            dgvTempDGVk.Rows.Add(StrEmployeeID, dgvAtnTimes.Item(6, intRow).Value, dgvAtnTimes.Item(3, intRow).Value, Trim(dgvAtnTimes.Item(0, intRow).Value), dgvAtnTimes.Item(5, intRow).Value)
                        End If
                    Next i

                    If strCellName = "" Then Exit Sub
                    'lblSelectedEmpoyees.Text = "Selected Employee(s ) : " & intEmp & "     " & Replace(strDisplaySelected, "'", "")
                    'strCellName = Microsoft.VisualBasic.Left(strCellName, strCellName.Length - 1)
                    'strKEmployeeID = strCellName

                    'If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 1 Then
                    '    MessageBox.Show("You can edit only one day attendance at one time through this screen, Please select one only one day", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpToDate.Value = dtpFromDate.Value : ViewInformation(0) : Exit Sub
                    'End If

                    'If intSelecTab = 0 Then

                    '    'ShiftSave()

                    'End If
                End If

                'fk_SaveSelectedShift(StrcEmpID, strCellName, StrSelShiftID, intTabSelected)

                'If intSelecTab = 0 Then

                '    Dim k As Integer
                '    For k = 0 To selectedCellCount - 1

                '        intRow = (dgvData.SelectedCells(k).RowIndex _
                '            .ToString())
                '        intColumn = (dgvData.SelectedCells(k).ColumnIndex _
                '            .ToString())
                '        If 1 = intColumn Then
                '            'dgvData.Rows.Remove(dgvData.Rows(intRow))
                '            'dgvData.Item(1, intRow).Value = True
                '        End If
                '    Next k

                'End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EemoveFinger()

        If UP("Daily attendance", "Remove employee punch time(s)") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        If MsgBox("Do you want to remove selected time ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim sqlQRY As String = ""
        Me.Cursor = Cursors.WaitCursor
        Dim dtTTime As DateTime : Dim intCrRow As Integer
        dtTTime = dgvAtnTimes.CurrentRow.Cells(3).Value
        intCrRow = Val(dgvAtnTimes.CurrentRow.Cells(0).Value)
        Dim intEnrol As Integer = Val(dgvAtnTimes.CurrentRow.Cells(6).Value)
        Dim strMacID As String = Trim(dgvAtnTimes.CurrentRow.Cells(5).Value)
        sSQL = "UPDATE tblDiMachine SET Capture = 9 WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "' AND crLine = " & intCrRow & " AND MacID='" & strMacID & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Delete attendance time from table Enrol No : " & intEnrol & " AND tTime : " & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & " AND crLine : " & intCrRow & " and Note " & FK_Rep(txtNote.Text) & "','" & StrUserID & "',getdate (),'" & StrEmployeeID & "'); " & _
        "UPDATE tblDiMachineManual SET Capture = 9 WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "'  AND MacID='" & strMacID & "'" & _
        "INSERT INTO tbldimachineRemove SELECT [MacID],[EmpID],[Input],[cDate],[cTime],[capture],[tTime],'" & StrUserID & "',getdate (),'" & txtNote.Text & "'," & intCrRow & " FROM [tbldimachine] WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "'  AND MacID='" & strMacID & "'"
        If FK_EQ(sSQL, "D", "", False, False, True) = True Then
            dgvAtnTimes.Rows.Remove(dgvAtnTimes.CurrentRow)
        End If
        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        '#ISA-099

        'If intBaseOnClockRecord = 0 Then
        '    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", AtnDate1, dtFingerPrintMaxDate, pgb, 0, 0)
        'Else
        '    Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
        'End If

        Select Case intBaseOnClockRecord
            Case 0
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", AtnDate1, dtFingerPrintMaxDate, pgb, 0, 0)
            Case 1
                Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
            Case 2
                fk_ProcessStraght(dtpToDate.Value, dtFingerPrintMaxDate, pgb, "O", StrEmployeeID)
        End Select
        If chkAutoRefresh.Checked = True Then
            ViewInformation(0)
            CadreSearch()
        End If
        'btnShow_Click(sender, e)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub dgvAtnTimes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAtnTimes.CellDoubleClick
        EemoveFinger()
    End Sub

    Private Sub lblCCardre_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCPresent.MouseHover, lblCPreOffk.MouseHover, lblCOt.MouseHover, lblCOf.MouseHover, lblCNop.MouseHover, lblCLeve.MouseHover, lblCLeave.MouseHover, lBlCLate.MouseHover, lblCInccom.MouseHover, lblCHalfday.MouseHover, lblCDup.MouseHover, lblCCardre.MouseHover, lblCAb.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblCCardre_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCPresent.MouseLeave, lblCPreOffk.MouseLeave, lblCOt.MouseLeave, lblCOf.MouseLeave, lblCNop.MouseLeave, lblCLeve.MouseLeave, lblCLeave.MouseLeave, lBlCLate.MouseLeave, lblCInccom.MouseLeave, lblCHalfday.MouseLeave, lblCDup.MouseLeave, lblCCardre.MouseLeave, lblCAb.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvData.MouseClick
        If e.Button = MouseButtons.Right Then
            Button5_Click(sender, e)
        End If
    End Sub

    Private Sub lblCNight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCNight.Click
        strSearchFor = "NightWorked"
        chkNightOnly.Checked = True
        CadreSearch()
        lblCNight.Text = dgvData.RowCount
    End Sub

    Private Sub btnConfrmNight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfrmNight.Click
        intSelecTab = 3
        getSelectedArea()
        NightConfirm()
    End Sub

    Private Sub btnNormalizk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNormalizk.Click
        If UP("Daily attendance", "Normalize night fixed records") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim sqlQRY As String = ""
        'Check Night Shift Existance
        Dim intV As Integer = 0
        If AtnDate1 = Nothing Then MsgBox("Please select the dates", MsgBoxStyle.Information) : Me.Cursor = Cursors.Default : Exit Sub
        sqlQRY = "SELECT * FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate = '" & Format(AtnDate1, "yyyyMMdd") & "' AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND DateDiff(Day,tblEmpRegister.ClockIn,tblEmpRegister.ClockOut)>0"
        Dim bolRet As Boolean = fk_CheckEx(sqlQRY)
        If bolRet = False Then MsgBox("You are allowed to normalize only night fixed records", MsgBoxStyle.Critical) : Me.Cursor = Cursors.Default : Exit Sub
        Dim strSelEmpNo As String = Trim(dgvData.CurrentRow.Cells(1).Value)
        Dim strSelName As String = Trim(dgvData.CurrentRow.Cells(2).Value)
        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, AtnDate1)
        If MsgBox("Do you want to process rollback, this will clear the night shift and process attendance as fresh attendance," & vbCrLf & "Do you want to Normalise Employee " & strSelEmpNo & " - " & strSelName & " - " & AtnDate1 & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

        'Normalize Clock In Clock out in EmpRegister
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN, tblEmpRegister.ClockOut = DateAdd(Day,tblSetShiftH.ShiftMode,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(AtnDate1, "yyyyMMdd") & "' AND '" & Format(dtFingerPrintMaxDate, "yyyyMMdd") & "' AND tblEmpRegister.EMpID = '" & StrEmployeeID & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Normalize attendance data of table Date Between : " & Format(AtnDate1, "yyyyMMdd") & " AND " & Format(dtFingerPrintMaxDate, "yyyyMMdd") & " Reg ID :  " & StrEmployeeID & "','" & StrUserID & "',getdate ())" : FK_EQ(sqlQRY, "S", "", False, False, True)

        '#ISA-099
        Select Case intBaseOnClockRecord
            Case 0

                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", AtnDate1, dtFingerPrintMaxDate, pgb, 0, 0)
            Case 1
                Process_Attendance(AtnDate1, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
            Case 2
                fk_ProcessStraght(AtnDate1, dtFingerPrintMaxDate, pgb, "O", strKEmployeeID)

        End Select


        If chkAutoRefresh.Checked = True Then
            ViewInformation(0)
            CadreSearch()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub NightConfirm()
        If UP("Daily attendance", "Confirm night worked attendance") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        intSelecTab = 3
        getSelectedArea()

        If strKEmployeeID = "" Then MessageBox.Show("Please select employee(s) to confirm night day", "Attention", MessageBoxButtons.OK) : Exit Sub

        sSQL = "select regID from tblemployee where regid in(" & strKEmployeeID & ")"
        Fk_FillGrid(sSQL, dgvTempDGV)

        sSQL = ""
        For I As Integer = 0 To dgvTempDGV.RowCount - 1
            sSQL = sSQL & "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Confirm employee(s) night shift of  " & dgvTempDGV.Item(0, I).Value & " to Shift " & StrSelShiftID & " of day " & Format(dtpToDate.Value, "yyyyMMdd") & "' ,'" & StrUserID & "',getdate (),'" & dgvTempDGV.Item(0, I).Value & "');"
        Next

        sSQL = sSQL & "UPDATE tblEmpRegister SET OutUpdate = 1,OutTime1 = dbo.fk_NextDayTime(EmpID,AtDate),ClockOut = DateAdd(second,1,dbo.fk_NextDayTime(EmpID,AtDate)) WHERE EmpID In (" & strKEmployeeID & ") AND AtDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"


        If FK_EQ(sSQL, "S", "", False, False, True) = True Then
            bolOK = True
        Else
            bolOK = False
        End If

        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        strKEmployeeID = strKEmployeeID.Remove(0, 1)
        strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)
        pgb.Visible = True
        If intBaseOnClockRecord = 0 Then
            fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & strKEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtpToDate.Value, dtFingerPrintMaxDate, pgb, 0, 0)
        Else
            Process_Attendance(dtpToDate.Value, dtFingerPrintMaxDate, strKEmployeeID, "O", pgb)
        End If

        pgb.Visible = False

        strSearchFor = "Cadre"
        chkNightOnly.Checked = False
        'If chkAutoRefresh.Checked = True Then
        ViewInformation(0)
        CadreSearch()
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkNightOnly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNightOnly.Click
        If chkNightOnly.Checked = True Then
            strSearchFor = "NightWorked"
            CadreSearch()
        Else
            intLoad = 1
            Button2_Click(sender, e)
        End If
    End Sub

    Private Sub Panel43_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel56.MouseHover, Panel55.MouseHover, Panel54.MouseHover, Panel53.MouseHover, Panel52.MouseHover, Panel51.MouseHover, Panel50.MouseHover, Panel49.MouseHover, Panel48.MouseHover, Panel47.MouseHover, Panel46.MouseHover, Panel45.MouseHover, Panel44.MouseHover, Panel43.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Panel43_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel56.MouseLeave, Panel55.MouseLeave, Panel54.MouseLeave, Panel53.MouseLeave, Panel52.MouseLeave, Panel51.MouseLeave, Panel50.MouseLeave, Panel49.MouseLeave, Panel48.MouseLeave, Panel47.MouseLeave, Panel46.MouseLeave, Panel45.MouseLeave, Panel44.MouseLeave, Panel43.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Panel43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel43.Click
        lblCCardre_Click(sender, e)
    End Sub

    Private Sub Panel44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel44.Click
        lblCPresent_Click(sender, e)
    End Sub

    Private Sub Panel45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel45.Click
        lblCLeve_Click(sender, e)
    End Sub

    Private Sub Panel46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel46.Click
        lblLate_Click(sender, e)
    End Sub

    Private Sub Panel47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel47.Click
        lblTot_Click(sender, e)
    End Sub

    Private Sub Panel48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel48.Click
        lblCPreOffk_Click(sender, e)
    End Sub

    Private Sub Panel49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel49.Click
        lblCDup_Click(sender, e)
    End Sub

    Private Sub Panel50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel50.Click
        Label8_Click(sender, e)
    End Sub

    Private Sub Panel51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel51.Click
        lblAbsent_Click(sender, e)
    End Sub

    Private Sub Panel52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel52.Click
        Label13_Click(sender, e)
    End Sub

    Private Sub Panel53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel53.Click
        lblCHalfday_Click(sender, e)
    End Sub

    Private Sub Panel54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel54.Click
        lblLeave_Click(sender, e)
    End Sub

    Private Sub Panel55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel55.Click
        lblCNop_Click(sender, e)
    End Sub

    Private Sub Panel56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel56.Click
        lblCNight_Click(sender, e)
    End Sub

    Private Sub btnDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDay.Click
        pnlDayType.Width = 366
        pnlShift.Width = 0
        pnlFinger.Width = 0
        btnTime.BackColor = Color.Coral
        btnShift.BackColor = Color.Coral
        btnDay.BackColor = Color.Navy
        Label8.ForeColor = Color.Coral
        Label6.ForeColor = Color.Coral
        Label5.ForeColor = Color.Navy
    End Sub

    Private Sub btnShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShift.Click
        pnlShift.Width = 366
        pnlFinger.Width = 0
        pnlDayType.Width = 0
        btnTime.BackColor = Color.Coral
        btnShift.BackColor = Color.Navy
        btnDay.BackColor = Color.Coral
        Label8.ForeColor = Color.Coral
        Label6.ForeColor = Color.Navy
        Label5.ForeColor = Color.Coral
    End Sub

    Private Sub btnTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTime.Click
        pnlFinger.Width = 366
        pnlShift.Width = 0
        pnlDayType.Width = 0
        btnTime.BackColor = Color.Navy
        btnShift.BackColor = Color.Coral
        btnDay.BackColor = Color.Coral
        Label8.ForeColor = Color.Navy
        Label6.ForeColor = Color.Coral
        Label5.ForeColor = Color.Coral
    End Sub

    Private Sub lblCExtraDay_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCExtraDay.MouseClick
        strSearchFor = "ExtraDay"
        CadreSearch()
    End Sub

    Private Sub lblCSplit_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCSplit.MouseClick
        strSearchFor = "SplitDay"
        CadreSearch()
    End Sub

    Private Sub Panel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel14.Click
        lblCExtraDay_MouseClick(sender, e)
    End Sub

    Private Sub Panel15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel15.Click
        lblCSplit_MouseClick(sender, e)
    End Sub

    Private Sub dgvData_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        'clr_Grid(dgvData)
    End Sub

    Private Sub Panel16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel16.Click
        lblCFix_MouseClick(sender, e)
    End Sub

    Private Sub lblCFix_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCFix.MouseClick
        strSearchFor = "FixNight"
        CadreSearch()
    End Sub

    Private Sub btnRemAttendanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemAttendanc.Click
        RemoveBulkPunchedTime()
    End Sub

    Private Sub btnReprocesk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprocesk.Click
        ReprocessSelected()
    End Sub

    Private Sub bttnOTProces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOTProces.Click
        Me.Cursor = Cursors.WaitCursor
        process_AttendanceParameters(dtpFromDate.Value, dtpToDate.Value, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        If chkAutoRefresh.Checked = True Then
            ViewInformation(0)
            CadreSearch()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReprocessSelected()
        If UP("Daily attendance", "Reproces attendance") = False Then Exit Sub
        intSelecTab = 4
        getSelectedArea()

        Try
            Me.Cursor = Cursors.WaitCursor
            strSelectDate = Format(dtpToDate.Value, "yyyyMMdd")
            If strSelectDate = "" Then
                MessageBox.Show("Please select date(s) to reprocess", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If
            sSQL = "select tblEmpRegister.empid,convert(nvarchar(10),tblEmpRegister.atdate,111) as 'dDate' from tblEmpRegister ,tblEmployee where tblEmpRegister.empid=tblEmployee.regid and tblEmpRegister.atdate in ('" & strSelectDate & "') AND tblEmpRegister.EmpID in (" & strKEmployeeID & ") order by tblEmpRegister.atdate"
            Fk_FillGrid(sSQL, dgvTempDGV)

            Dim dtFrDate As Date = CDate(dgvTempDGV.Item(1, 0).Value)
            Dim dtToDate As Date = CDate(dgvTempDGV.Item(1, dgvTempDGV.RowCount - 1).Value)

            If MsgBox("Do you want to reprocess " & strKEmployeeID & " for dates of " & dtFrDate & " to " & dtToDate & " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub
            strKEmployeeID = strKEmployeeID.Remove(0, 1)
            strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)

            '#ISA-099
            'If intBaseOnClockRecord = 0 Then
            '    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID in ('" & strKEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtFrDate, dtToDate, pgb, 0, 0)
            'Else
            '    Process_Attendance(dtFrDate, dtToDate, strKEmployeeID, "O", pgb)
            'End If

            Select Case intBaseOnClockRecord
                Case 0
                    fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID in ('" & strKEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtFrDate, dtToDate, pgb, 0, 0)
                Case 1
                    Process_Attendance(dtFrDate, dtToDate, strKEmployeeID, "O", pgb)
                Case 2
                    fk_ProcessStraght(dtFrDate, dtpToDate.Value, pgb, "O", strKEmployeeID)
            End Select
            If chkAutoRefresh.Checked = True Then
                ViewInformation(0)
                CadreSearch()
            End If

            dtpTime.Focus()
            'Process Attendance
            'btnShow_Click(sender, e)
            Me.Cursor = Cursors.Default
            'StrEmployeeID = ""
            'strKEmployeeID = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub chkAbsent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAbsent.Click
        ViewInformation(0)
        strSearchFor = "Absent"
        CadreSearch()
    End Sub

    Private Sub chkAutoCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAutoCalculate.Click
        sSQL = "UPDATE tblCompany SET IsRunAutoCalculation='" & chkAutoCalculate.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, False)
        IsRunAutoCalculation = fk_sqlDbl("select IsRunAutoCalculation from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub dtpSelectDatek_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSelectDatek.ValueChanged
        If Format(dtpSelectDatek.Value, "yyyyMMdd") <> Format(dtpToDate.Value, "yyyyMMdd") Then
            dtpFromDate.Value = dtpSelectDatek.Value
            dtpToDate.Value = dtpSelectDatek.Value
            Button2_Click(sender, e)
        End If
    End Sub

    Private Sub chkAll_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkSelectAll.MouseClick
        If chkSelectAll.Checked = True Then
            dgvData.ClearSelection()
            For kk As Integer = 0 To dgvData.RowCount - 1
                dgvData.Item(1, kk).Selected = True
            Next
        Else
            dgvData.ClearSelection()
        End If
    End Sub

    Private Sub chkSelectAll_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkNightAll.MouseClick
        For i As Integer = 0 To dgvData.RowCount - 1
            dgvData.Item(14, i).Value = chkNightAll.CheckState
        Next
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

End Class