Imports System.Data.SqlClient
Imports System.Globalization

Public Class frmIndividualAttendanceEdit

    Dim intLoad As Integer = 0
    Dim strWhereClouse As String = ""
    Dim strSearchFor As String = "Cadre"
    Dim strDispCount As String = ""
    Dim StrSelShiftID As String = ""
    Dim dtLongString As String = "" : Dim StrAllColumn As String = "" ' All Column List
    Dim intNoDay As Integer : Dim intTabSelected As Integer = 0
    Dim StrEmpAll As String = ""
    Dim bolOK As Boolean = False
    Dim strSelDate As String = ""

    Dim StrSelShift As String = ""

    Dim strSelestedMac As String = "001"
    Dim StrnDayTypID As String = ""
    Dim strNDay As String = ""
    Dim clrDay As Color = Color.White
    Dim AtnDate1 As Date
    Dim strClick As String = "1"
    Dim strSelectDate As String = ""
    Dim sTableVI As New DataSet
    Dim dtMin As DateTime
    Dim dblLateMins As Double
    Dim dblOTRound As Double
    Dim dblMinOT As Double
    Dim intOTRndOption As Double
    Dim sTablek As New DataSet
    Dim dtDate As Date
    Dim bolIsNightFixed As Boolean = False

    Dim MaxmunMonthEndDate As DateTime

    Private Sub ViewData()

        Try
            Me.Cursor = Cursors.WaitCursor
            'ControlHandlers(Me)
            ''CenterFormThemed(Me, pnlTopSet, Label6)
            'If dtGlobalDate = "12:00:00 AM" Then
            '    dtGlobalDate = dtLastProcessed
            'End If

            'CadreSearch()
            If strKEmployeeID <> "" Then
                'sSQL = " delete from tkIndividual; INSERT INTO tkIndividual SELECT tblEmpRegister.atDate,tblEmployee.regID," & sqlTag1 & " AS 'empNO',tblEmployee.deptID,tblEmployee.catID,tblEmployee.desigID,tblEmpRegister.allShifts,tblEmployee.brID,tblEmployee.empTypeID,tblEmployee.titleID,'','',tblEmpRegister.DayTypeID,tblEmpRegister.nrWorkday,tblEmpRegister.workHrs,tblEmpRegister.normalOTHrs,tblEmpRegister.doubleOTHrs,tblEmpRegister.tripleOTHrs,tblEmpRegister.lateMins,tblEmpRegister.earlyMins,case when tblEmpRegister.antstatus='1' then '1' else '0' end  as 'p'  ,case when tblEmpRegister.antstatus='0' then '1' else '0' end  as 'a',case when tblEmpRegister.islate='1' then '1' else '0' end  as 'lt' ,case when tblEmpRegister.isleave='1' then '1' else '0' end  as 'lv',0  as 'tot',0 from tblEmployee LEFT OUTER JOIN tblEmpRegister on tblEmpRegister.EmpID=tblEmployee.RegID WHERE tblEmployee.regID='" & strKEmployeeID & "' and tblEmpRegister.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' ; UPDATE tkIndividual SET tkIndividual.inTime=tblGetInOut.inTime,tkIndividual.outTime=tblGetInOut.outTime FROM tblGetInOut,tkIndividual where  tblGetInOut.atDate=tkIndividual.atDate and tblGetInOut.empID=tkIndividual.regID AND tblGetInOut.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'; UPDATE tkIndividual SET  tkIndividual.isOf=CASE WHEN tbldayType.workUnit=0 THEN 1 ELSE 0 END FROM tblDayType,tkIndividual WHERE tblDayType.typeID=tkIndividual.dayTypeID and tkIndividual.atDate  BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'" & _
                '"SELECT tkIndividual.regid AS 'Reg ID',CONVERT(VARCHAR(10),tkIndividual.atDate,111) AS 'In Date',CASE WHEN CONVERT(VARCHAR(8),tkIndividual.inTime,108)='00:00:00' THEN '' ELSE CONVERT(VARCHAR(8),tkIndividual.inTime,108) END  AS 'In Time',CONVERT(VARCHAR(10),tkIndividual.outTime,111) AS 'Out Date',CASE WHEN CONVERT(VARCHAR(8),tkIndividual.outTime,108)='00:00:00' THEN '' ELSE CONVERT(VARCHAR(8),tkIndividual.outTime,108) END AS 'Out Time',CASE WHEN tkIndividual.workHrs=0 THEN 0 ELSE tkIndividual.workHrs END AS 'Work Hrs',tblSetShifth.shortCode AS 'Shift',CASE WHEN tkIndividual.nrWorkDay=0 THEN 0 ELSE tkIndividual.nrWorkDay END AS 'Work Day',tbldaytype.shortCode AS 'Day Type',tkIndividual.normalOTHrs AS 'Normal OTHrs',CASE WHEN tkIndividual.DoubleOTHrs=0 THEN 0 ELSE tkIndividual.DoubleOTHrs END AS  'Double OTHrs',CASE WHEN tkIndividual.tripleOTHrs=0 THEN 0 ELSE tkIndividual.tripleOTHrs END AS 'Triple OTHrs',CASE WHEN tkIndividual.lateMins=0 THEN 0 ELSE tkIndividual.lateMins END AS 'Late Mins',CASE WHEN tkIndividual.earlyMins=0 THEN 0 ELSE tkIndividual.earlyMins END AS 'Early Mins' FROM tkIndividual,tblSetShiftH,tblDayType WHERE tblSetShiftH.shiftID=tkIndividual.shiftID AND tblDayType.typeID=tkIndividual.dayTypeID ORDER BY tkIndividual.atDate"
                'Fk_FillGrid(sSQL, dgvData)
                'dgvData.Columns(0).Visible = False
                'For X As Integer = 0 To dgvData.Columns.Count - 1
                '    dgvData.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                'Next

                StrEmployeeID = strKEmployeeID
                Fk_FillDataSet("exec [sp_DataSetIndividual] '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & strKEmployeeID & "'")
                Dim dv As DataView = New DataView(sTableVI.Tables("tblEmployeeVI"))
                sSQL = "Empstatus<>9  " & strWhereClouse & " and deptID in ('" & StrUserLvDept & "') AND  brID IN ('" & StrUserLvBranch & "')"
                dv.RowFilter = sSQL
                'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
                Dim dt As New DataTable
                dt = dv.ToTable(True, "EmpID", "InDate", "inTime", "OutDate", "outTime", "workHrs", "shiftName", "dayType", "nrWorkDay", "totalOT", "LateMins", "EarlyMins", "DueMins", "adDay", "LvName", "isNightWork", "normalOT", "doubleOT", "tripleOT", "lunchMins", "dinnerMins", "antStatus", "OutUpdate", "inUpdate", "isLate", "isLeave", "Empstatus", "DeptID", "BrID", "desigName", "deptName", "catName", "brName", "workUnit", "InTimeNoSec", "OutTimeNoSec", "shiftLine", "isSplit", "dispName", "enrolNo", "EmpNo")
                dgvData.DataSource = dt

                With dgvData
                    .Columns(0).HeaderText = "Reg ID"
                    .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(1).HeaderText = "In Date"
                    .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(2).HeaderText = "In Time"
                    .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(3).HeaderText = "Out Date"
                    .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(4).HeaderText = "Out Time"
                    .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(5).HeaderText = "Work Hours"
                    .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(6).HeaderText = "Shift"
                    .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(7).HeaderText = "Day Type"
                    .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(8).HeaderText = "Work Day"
                    .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(9).HeaderText = "Total OT"
                    .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(10).HeaderText = "Late Mins"
                    .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(11).HeaderText = "Early Mins"
                    .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(12).HeaderText = "Due Mins"
                    .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(13).HeaderText = "Additnal Day"
                    .Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(14).HeaderText = "Leave Name"
                    .Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(15).HeaderText = "Night Work"
                    .Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(16).HeaderText = "Normal OT"
                    .Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(17).HeaderText = "Double OT"
                    .Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(18).HeaderText = "Triple OT"
                    .Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(19).HeaderText = "Lunch Mins"
                    .Columns(19).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .Columns(20).HeaderText = "Dinner Mins"
                    .Columns(20).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End With

                ViewInformation()
                CadreSearch()

                With dgvData
                    For iRows As Integer = 0 To .RowCount - 1
                        Dim dblWorkUnit As Double = CDbl(.Item(33, iRows).Value)
                        If dblWorkUnit = 0.5 Then
                            'For k As Integer = 0 To 20
                            .Item(7, iRows).Style.BackColor = Color.Purple
                            'Next
                        ElseIf dblWorkUnit = 1 Then
                            'For k As Integer = 0 To 20
                            .Item(7, iRows).Style.BackColor = Color.SteelBlue
                            'Next
                        ElseIf dblWorkUnit = 0 Then
                            'For k As Integer = 0 To 20
                            .Item(7, iRows).Style.BackColor = Color.Pink
                            'Next
                        End If

                    Next
                End With

                'sSQL = "select  convert(int,sum(p)) as Present, convert(int,sum(lv)) as Leave, convert(int,sum(lt)) as Late, convert(int,sum(a)) as Absent, convert(int,sum(CASE WHEN P=1 and outtime='1900-01-01 00:00:00.000' then 1 else 0 end)) as Incomplete, convert(int,sum(CASE WHEN normalOTHrs >0 then normalOTHrs else 0 end)) as NOTHrs,convert(int,sum(CASE WHEN workHrs >0 then workHrs else 0 end)) as WorkHrs,convert(int,sum(CASE WHEN doubleOTHrs >0 then doubleOTHrs else 0 end)) as doubleOTHrs,convert(int,sum(CASE WHEN tripleOTHRS >0 then tripleOTHRS else 0 end)) as tripleOTHRS,convert(int,sum(isOf)) as OffDay,convert(int,sum(CASE WHEN P=1 and isOf=1 then 1 else 0 end)) as PressentOf,convert(int,sum(CASE WHEN P=1 and nrWorkDay=0.5 then 1 else 0 end)) as HalfDay,convert(int,sum(CASE WHEN isOf=0 and nrWorkDay=0  then 1-lv else 0 end)) as Nopay,convert(int,sum(CASE WHEN CONVERT(VARCHAR(5),intime,108) =CONVERT(VARCHAR(5),outtime,108) and intime<>'1900-01-01 00:00:00.000' then 1 else 0 end)) as Duplicate from tkIndividual"
                'fk_Return_MultyString(sSQL, 14)


                'lblCAb.Text = fk_ReadGRID(3).ToString().PadLeft(3, "0")
                'lBlCLate.Text = fk_ReadGRID(2).ToString().PadLeft(3, "0")
                'lblCPresent.Text = fk_ReadGRID(0).ToString().PadLeft(3, "0")
                'lblCLeave.Text = fk_ReadGRID(1).ToString().PadLeft(3, "0")
                'lblCInccom.Text = fk_ReadGRID(4).ToString().PadLeft(3, "0")
                'lblCNOT.Text = fk_ReadGRID(5).ToString().PadLeft(3, "0")
                'lblWHrs.Text = fk_ReadGRID(6).ToString().PadLeft(3, "0")
                'lblCDOT.Text = fk_ReadGRID(7).ToString().PadLeft(3, "0")
                'lblCTOT.Text = fk_ReadGRID(8).ToString().PadLeft(3, "0")
                'lblCOf.Text = fk_ReadGRID(9).ToString().PadLeft(3, "0")
                'lblCPreOffk.Text = fk_ReadGRID(10).ToString().PadLeft(3, "0")
                'lblCHalfday.Text = fk_ReadGRID(11).ToString().PadLeft(3, "0")
                'lblCNop.Text = fk_ReadGRID(13).ToString().PadLeft(3, "0")
                ''lblC.Text = fk_ReadGRID(13).ToString().PadLeft(3, "0")

            End If

            '   sSQL = "SELECT    " & sqlTag1 & ", dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc,TBLCBranchs.brName," & sqlTagName & ",dbo.tblEmployee.dOfB ,dbo.tblEmployee.regID " & _
            '"FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.TBLCBranchs ON TBLCBranchs.brID=tblEmployee.brID " & _
            '"LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblemployee.regID='" & strKEmployeeID & "' and tblemployee.deptID in ('" & StrUserLvDept & "') ORDER BY tblEmployee.RegID"
            '   fk_Return_MultyString(sSQL, 10)

            '   'fk_ReadGRID(3).ToString()

            '   lblName.Text = fk_ReadGRID(1).ToString()
            '   lblBranchtop.Text = "Branch : " & fk_ReadGRID(6).ToString()
            '   lblDesignation.Text = "Designation : " & fk_ReadGRID(4).ToString()
            '   lblEmpNumb.Text = "Emp No : " & fk_ReadGRID(7).ToString()
            '   StrEmployeeID = fk_ReadGRID(9).ToString()
            '   lblEnrolNo.Text = fk_ReadGRID(3)

            Me.Cursor = Cursors.Default
            'strKEmployeeID = ""

            'ViewInformation()
            'CadreSearch()
            'dtpFromDate.Value = dtGlobalDate
            'dtpToDate.Value = dtGlobalDate
            intLoad = 1
            intSelecTab = 3
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ViewInformation()
        Me.Cursor = Cursors.WaitCursor
        Try
            Fk_FillDataSet("exec [sp_DataSetIndividual] '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpToDate.Value, "yyyyMMdd") & "','" & strKEmployeeID & "'")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub Fk_FillDataSet(ByVal strSQLQuery As String)
        Dim CN As New SqlConnection(sqlConString)
        Dim sBol As Boolean = False
        Try
            sTableVI.Clear()
            CN.Open()
            Dim ADP As New SqlDataAdapter
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTableVI, "tblEmployeeVI")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Private Sub CadreSearch()
        Try
            Me.Cursor = Cursors.WaitCursor
            chkAbsent.Enabled = False
            If DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value) > 365 Then
                MessageBox.Show("Maximum date range is one year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If

            Dim ctrl As Control
            For Each ctrl In Me.TableLayoutPanel2.Controls
                If TypeOf ctrl Is Panel And ctrl.Tag = 2 Then ctrl.BackColor = Color.Navy
                If TypeOf ctrl Is Label And ctrl.Tag = 2 Then ctrl.ForeColor = Color.Navy
            Next

            Select Case strSearchFor
                Case "Cadre"
                    strWhereClouse = ""
                    strDispCount = "Cadre"
                Case "Present"
                    strWhereClouse = "AND antStatus=1"
                    strDispCount = "Present"
                    Panel44.BackColor = Color.Orange
                    lblCPresent.ForeColor = Color.Orange
                Case "PresentLeave"
                    'strWhereClouse = "AND isLeave=1 AND antStatus=1"
                    'strDispCount = ""
                    'Panel48.BackColor = Color.Orange
                    'lblCPreOff.ForeColor = Color.Orange
                Case "Late"
                    strWhereClouse = "AND isLate=1"
                    strDispCount = "Late"
                    Panel46.BackColor = Color.Orange
                    lBlCLate.ForeColor = Color.Orange
                Case "Incomplete"
                    strWhereClouse = "AND antStatus=1 AND nrWorkDay=0 AND shiftLine=1"
                    strDispCount = "Incomplete"
                    Panel47.BackColor = Color.Orange
                    lblCInccom.ForeColor = Color.Orange
                Case "PresentOff"
                    strWhereClouse = "AND antStatus=1 AND workUnit=0"
                    strDispCount = "Present Off"
                    Panel48.BackColor = Color.Orange
                    lblCPreOffk.ForeColor = Color.Orange
                    'Case "Duplicate"
                    '    strWhereClouse = "AND InTimeNoSec =outTimeNoSec and inUpdate=1"
                    '    strDispCount = "Duplicate"
                    '    Panel44.BackColor = Color.Orange
                    'Case "OverTime"
                    '    strWhereClouse = "AND totalOT>0"
                    '    strDispCount = "Overtime"
                    '    Panel44.BackColor = Color.Orange
                Case "Absent"
                    chkAbsent.Enabled = True
                    If chkAbsent.Checked = True Then
                        strWhereClouse = "AND antStatus=0 AND isLeave=0 AND workUnit<>0"
                    Else
                        strWhereClouse = "AND antStatus=0"
                    End If
                    strDispCount = "Absent"
                    Panel51.BackColor = Color.Orange
                    lblCAb.ForeColor = Color.Orange
                Case "OffDay"
                    strWhereClouse = "AND workUnit=0 "
                    strDispCount = "Off Day"
                    Panel52.BackColor = Color.Orange
                    lblCOf.ForeColor = Color.Orange
                Case "HalfDay"
                    strWhereClouse = "AND nrWorkDay=0.5"
                    strDispCount = "Half Day"
                    Panel53.BackColor = Color.Orange
                    lblCHalfday.ForeColor = Color.Orange
                Case "OnLeave"
                    strWhereClouse = "AND isLeave=1"
                    strDispCount = "On Leave"
                    Panel54.BackColor = Color.Orange
                    lblCLeave.ForeColor = Color.Orange
                Case "Nopay"
                    strWhereClouse = "AND nrWorkDay=0 AND isLeave=0 AND workUnit<>0 AND shiftLine=1 "
                    strDispCount = "Nopay"
                    Panel2.BackColor = Color.Orange
                    lblCNop.ForeColor = Color.Orange
                    'Case "SplitDay"
                    '    strWhereClouse = "AND antStatus=1 AND shiftLine=2"
                    '    strDispCount = "Shift Break"
                Case "NormalOT"
                    strWhereClouse = "AND antStatus=1 AND normalOT<>0"
                    strDispCount = "Normal OT"
                    Panel55.BackColor = Color.Orange
                    lblCNOT.ForeColor = Color.Orange
                Case "DoubleOT"
                    strWhereClouse = "AND antStatus=1 AND doubleOT<>0"
                    strDispCount = "Double OT"
                    Panel50.BackColor = Color.Orange
                    lblCDOT.ForeColor = Color.Orange
                Case "TripleOT"
                    strWhereClouse = "AND antStatus=1 AND tripleOT<>0"
                    strDispCount = "Triple OT"
                    Panel8.BackColor = Color.Orange
                    lblCTOT.ForeColor = Color.Orange
                Case "WorkHours"
                    strWhereClouse = "AND antStatus=1 AND workHrs<>0"
                    strDispCount = "Work Hours"
                    Panel6.BackColor = Color.Orange
                    lblWHrs.ForeColor = Color.Orange
                Case "FixNight"
                    'strWhereClouse = "AND dateGap=1"
                    strDispCount = "Fixed Night"
                    Panel16.BackColor = Color.Orange
                    lblCF.ForeColor = Color.Orange
                Case "NightShift"
                    strWhereClouse = "AND shiftLine=1 AND antStatus=1 AND shiftMode=1"
                    strDispCount = "Night Worked"
                    Panel12.BackColor = Color.Orange
                    lblCNight.ForeColor = Color.Orange
                Case "SplitDay"
                    strWhereClouse = "AND shiftLine=2"
                    strDispCount = "Split Duty"
                    Panel15.BackColor = Color.Orange
                    lblCSplit.ForeColor = Color.Orange
                Case "ExtraDay"
                    strWhereClouse = "AND antStatus=1 AND adDay<>0"
                    strDispCount = "Extra Day"
                    Panel14.BackColor = Color.Orange
                    lblCExtra.ForeColor = Color.Orange
            End Select
        Catch ex As Exception

        End Try



        If strSearchFor = "NightShift" Then
            'chkNightOnly.Enabled = True
            'If chkNightOnly.Checked = True Then
            btnConfrmNight.Enabled = True
            If dgvData.CurrentCell Is Nothing Then MessageBox.Show("Please select date from list", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            dtDate = CDate(dgvData.CurrentRow.Cells(1).Value)
            Fk_FillDataSetNight("exec SP_NightConfirmSingle  '" & Format(dtDate, "yyyyMMdd") & "','" & StrEmployeeID & "'")
            Dim dv2 As DataView = New DataView(sTablek.Tables("tblEmployeeVN"))
            Dim dt2 As New DataTable
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
                .Columns(15).Visible = False
            End With

            For K As Integer = 0 To dgvData.RowCount - 1
                If CBool(dgvData.Item(14, K).Value) = True Then
                    dgvData.Rows(K).Cells(14).Style.BackColor = Color.Orange : dgvData.Item(14, K).Value = False
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
            'ElseIf chkNightOnly.Checked = False Then
            '    intLoad = 1
            'End If
            'sSQL = "CREATE TABLE #AtManager (atDate datetime,enrolNo numeric (18,0)) INSERT INTO #AtManager select tblEmpRegister.atDate,tblEmployee.enrolNo from tblEmpRegister,tblEmployee WHERE  tblEmployee.RegID=tblEmpRegister.EmpID AND tblEmpRegister.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' and tblEmpRegister.outupdate=0 and tblEmpRegister.antStatus=1 order by tblEmpRegister.outupdate "
            'sSQL = sSQL & "  select tblDiMachine.EmpID,atDate,Min(tblDiMachine.tTime) AS 'Ttime' Into #T_Time From #AtManager,tblDiMachine WHERE #AtManager.EnrolNo = tblDiMachine.EmpID  AND tblDiMachine.cDate = DateAdd(Day,1,#AtManager.atDate) AND tblDiMachine.Capture In (0,1,2,3) GROUP BY tblDiMachine.EmpID ,tblDiMachine.cDate ,#AtManager.atDate ; UPDATE #AtManager SET #AtManager.OutTime = #T_Time.tTime  FROM #T_Time,#AtManager WHERE #T_Time.EmpID = #AtManager.EnrolNo AND #T_Time.atDate = #AtManager.AtDate; "
        Else
            btnConfrmNight.Enabled = False

            sSQL = ""
            'intLoad = 1
            'ViewInformation(0)
        End If



        Try
            Dim dv As DataView = New DataView(sTableVI.Tables("tblEmployeeVI"))
            sSQL = "Empstatus<>9  " & strWhereClouse & " and deptID in ('" & StrUserLvDept & "') AND  brID IN ('" & StrUserLvBranch & "')"
            dv.RowFilter = sSQL
            'dv.RowFilter = "DispName LIKE '%" & txtSearch.Text & "%' OR DeptID LIKE '%" & txtSearch.Text & "%'"
            Dim dt As New DataTable
            dt = dv.ToTable(True, "EmpID", "InDate", "inTime", "OutDate", "outTime", "workHrs", "shiftName", "dayType", "nrWorkDay", "totalOT", "LateMins", "EarlyMins", "DueMins", "adDay", "LvName", "isNightWork", "normalOT", "doubleOT", "tripleOT", "lunchMins", "dinnerMins", "antStatus", "OutUpdate", "inUpdate", "isLate", "isLeave", "Empstatus", "DeptID", "BrID", "desigName", "deptName", "catName", "brName", "workUnit", "InTimeNoSec", "OutTimeNoSec", "shiftLine", "isSplit", "dispName", "enrolNo", "EmpNo")
            dgvData.DataSource = dt

            If dt.Rows.Count > 0 Then
                lblName.Text = dt(0).Item("dispName").ToString
                lblBranchtop.Text = "Branch : " & dt(0).Item("brName").ToString
                lblDesignation.Text = "Designation : " & dt(0).Item("desigName").ToString
                lblEmpNumb.Text = "Emp No : " & dt(0).Item("EmpNo").ToString
                StrEmployeeID = dt(0).Item("EmpID").ToString
                lblEnrolNo.Text = dt(0).Item("enrolNo").ToString
            End If

            lblCAb.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =0")), "0", dt.Compute("Count(EmpID)", "AntStatus=0"))
            lBlCLate.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 AND isLate=1"))
            lblCPresent.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 And shiftLine = 1"))
            lblCLeave.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "isLeave = 1"))
            lblCInccom.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 AND outUpdate = 0 And shiftLine = 1"))
            lblCNOT.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 AND normalOT>0"))
            lblCOf.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "workUnit=0"))
            'lblWHrs.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "")), "0", dt.Compute("Count(EmpID)", "sum(workHrs)"))
            'lblCLeve.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "isLeave = 1"))
            lblCPreOffk.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 AND workUnit=0"))
            lblCHalfday.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "nrWorkDay = 0.5"))
            lblCNop.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =0")), "0", dt.Compute("Count(EmpID)", "nrWorkDay =0 AND workUnit <>0 AND isLeave=0 AND shiftLine=1 "))
            lblCF.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "inTimeNoSec=outTimeNoSec and inUpdate=1"))
            lblCNight.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 AND outUpdate = 0 AND shiftLine=1"))
            lblCExtra.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "AntStatus =1")), "0", dt.Compute("Count(EmpID)", "AntStatus =1 AND adDay<>0"))
            lblCSplit.Text = IIf(IsDBNull(dt.Compute("Count(EmpID)", "")), "0", dt.Compute("Count(EmpID)", "shiftLine=2"))
            Dim dblNot As Double = 0
            Dim dblDOT As Double = 0
            Dim dblTOT As Double = 0
            Dim dblWorkHrs As Double = 0
            For k As Integer = 0 To dgvData.RowCount - 1
                dblNot = dblNot + Val(dgvData.Item(16, k).Value)
                dblDOT = dblDOT + Val(dgvData.Item(17, k).Value)
                dblTOT = dblTOT + Val(dgvData.Item(18, k).Value)
                If Val(dgvData.Item(36, k).Value) < 2 Then
                    dblWorkHrs = dblWorkHrs + Val(dgvData.Item(5, k).Value)
                End If
            Next
            lblWHrs.Text = dblWorkHrs
            lblCNOT.Text = dblNot
            lblCDOT.Text = dblDOT
            lblCTOT.Text = dblTOT
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


            'Fk_FillGrid(sSQL, dgvData)
            dgvData.Columns(0).Visible = False
            'dgvData.ReadOnly = False
            'dgvData.Columns(2).ReadOnly = True
            'dgvData.Columns(3).ReadOnly = True
            'For X As Integer = 0 To dgvData.Columns.Count - 1
            '    dgvData.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            'Next
            'clr_Grid(dgvDepertment)
            'strDispCount = strDispCount & " Records : " & dgvData.RowCount

            'Label1.Text = strDispCount

            With dgvData
                .Columns(0).HeaderText = "Reg ID"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).HeaderText = "In Date"
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(2).HeaderText = "In Time"
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(3).HeaderText = "Out Date"
                .Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(4).HeaderText = "Out Time"
                .Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(5).HeaderText = "Work Hours"
                .Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(6).HeaderText = "Shift"
                .Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(7).HeaderText = "Day Type"
                .Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(8).HeaderText = "Work Day"
                .Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(9).HeaderText = "Total OT"
                .Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(10).HeaderText = "Late Mins"
                .Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(11).HeaderText = "Early Mins"
                .Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(12).HeaderText = "Due Mins"
                .Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(13).HeaderText = "Additnal Day"
                .Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(14).HeaderText = "Leave Name"
                .Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(15).HeaderText = "Night Work"
                .Columns(15).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(16).HeaderText = "Normal OT"
                .Columns(16).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(17).HeaderText = "Double OT"
                .Columns(17).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(18).HeaderText = "Triple OT"
                .Columns(18).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(19).HeaderText = "Lunch Mins"
                .Columns(19).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(20).HeaderText = "Dinner Mins"
                .Columns(20).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            strDispCount = strDispCount & " Records : " & dgvData.RowCount

            Label15.Text = strDispCount

            Me.Cursor = Cursors.Default
            intLoad = 1
            intSelecTab = 3

            For k As Integer = 21 To dgvData.Columns.Count - 1
                dgvData.Columns(k).Visible = False
            Next

            ''COLOR UP THE DAY TYPE COLUMN
            With dgvData
                For iRows As Integer = 0 To .RowCount - 1
                    Dim dblWorkUnit As Double = CDbl(.Item(33, iRows).Value)
                    If dblWorkUnit = 0.5 Then
                        'For k As Integer = 0 To 20
                        .Item(7, iRows).Style.BackColor = Color.Purple
                        'Next
                    ElseIf dblWorkUnit = 1 Then
                        'For k As Integer = 0 To 20
                        .Item(7, iRows).Style.BackColor = Color.SteelBlue
                        'Next
                    ElseIf dblWorkUnit = 0 Then
                        'For k As Integer = 0 To 20
                        .Item(7, iRows).Style.BackColor = Color.Pink
                        'Next
                    End If

                    Dim dblShiftLine As Double = CDbl(.Item(36, iRows).Value)
                    If dblShiftLine > 1 Then
                        .Item(3, iRows).Style.BackColor = Color.Green : .Item(4, iRows).Style.BackColor = Color.Green
                    End If
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
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

    Private Sub NightConfirm()
        If UP("Daily attendance", "Confirm night worked attendance") = False Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        'intSelecTab = 3
        'getSelectedArea()

        If dgvData.Rows(0).Cells(14).Value = False Then MessageBox.Show("Please select day to confirm night day", "Attention", MessageBoxButtons.OK) : Exit Sub

        'sSQL = "select regID from tblemployee where regid in(" & strKEmployeeID & ")"
        'Fk_FillGrid(sSQL, dgvTempDGV)

        'sSQL = ""
        'For I As Integer = 0 To dgvTempDGV.RowCount - 1
        sSQL = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Confirm employee(s) night shift of  " & StrEmployeeID & " to Shift " & StrSelShiftID & " of day " & Format(dtDate, "yyyyMMdd") & "' ,'" & StrUserID & "',getdate (),'" & StrEmployeeID & "');"
        'Next

        sSQL = sSQL & "UPDATE tblEmpRegister SET OutUpdate = 1,OutTime1 = dbo.fk_NextDayTime(EmpID,AtDate),ClockOut = DateAdd(second,1,dbo.fk_NextDayTime(EmpID,AtDate)) WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtDate, "yyyyMMdd") & "'"


        If FK_EQ(sSQL, "S", "", False, False, True) = True Then
            bolOK = True
        Else
            bolOK = False
        End If

        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, dtDate)
        'strKEmployeeID = StrEmployeeID
        'strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)
        pgb.Visible = True
        If intBaseOnClockRecord = 0 Then
            fk_ProcessAttendanceNEW(StrEmployeeID, dtDate, dtFingerPrintMaxDate, pgb, 0, 0)
        Else
            Process_Attendance(dtDate, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
        End If

        pgb.Visible = False
        bolIsNightFixed = True
        strSearchFor = "Cadre"

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmIndividualAttendanceEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Daily attendance", "View daily attendance") = False Then Exit Sub
        dtpToDate.Value = dtLastProcessed
        dtpFromDate.Value = DateAdd(DateInterval.Month, -1, dtpToDate.Value)
        'dtpFromDate.Value = DateAdd(DateInterval.Day, 1, dtpFromDate.Value)
        intLoad = 0
        pnlButtonSet.Height = 114
        PNLHide.Width = 0
        ControlHandlers(Me)
        strSearchFor = "Cadre"
        ViewData()
        CompanyParameter()

        DateTimePickerMinDateControl()
    End Sub


    Private Sub DateTimePickerMinDateControl()
        '2018-08-03 DateTimePicker MinDate Control -prasanna
        Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")
        Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")

        MaxmunMonthEndDate = New DateTime(maxYear, maxMonth, 1).AddDays(-1)
        'dtpFromDate.MinDate = New DateTime(maxYear, maxMonth, 1).AddMonths(1)
        'dtpToDate.MinDate = New DateTime(maxYear, maxMonth, 1).AddMonths(1)
    End Sub

    Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged
        If intLoad = 1 Then
            ViewData()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If pnlButtonSet.Height = 114 Then
            pnlButtonSet.Height = 0
        ElseIf pnlButtonSet.Height = 0 Then
            pnlButtonSet.Height = 114
        End If
    End Sub

    Public Sub getSelectedArea()
        Dim selectedCellCount As Integer = _
        dgvData.GetCellCount(DataGridViewElementStates.Selected)
        Dim intRow As Integer : Dim intColumn As Integer : Dim strCellName As String
        Dim StrcEmpID As String = "" : Dim dtDate As Date
        Dim strc
        'Dim selectedRowCount As Integer 
        'dgvEmployee.SelectedRows.Count
        Dim intCurrentRow As Integer = dgvData.CurrentRow.Index
        Try
            If selectedCellCount > 0 Then

                If dgvData.AreAllCellsSelected(True) Then
                    MessageBox.Show("All cells are selected", "Selected Cells")
                Else
                    strCellName = ""
                    Dim i As Integer
                    For i = 0 To selectedCellCount - 1

                        intRow = (dgvData.SelectedCells(i).RowIndex _
                            .ToString())
                        intColumn = (dgvData.SelectedCells(i).ColumnIndex _
                            .ToString())
                        If intColumn = 1 Then
                            dtDate = CDate(dgvData.Item(1, intRow).Value)
                            strSelDate = Format(dtDate, "yyyyMMdd")
                            'If strSelDate <> "19000101" Then
                            strCellName = strCellName & "'" & strSelDate & "'" & ","
                            'End If
                            AtnDate1 = dtDate
                        End If

                    Next i

                    If strCellName = "" Then Exit Sub

                    strCellName = Microsoft.VisualBasic.Left(strCellName, strCellName.Length - 1)
                    strSelectDate = strCellName
                    'If StrSelShiftID = "" Then MsgBox("Please select the Shift", MsgBoxStyle.Information) : Exit Sub

                    If intSelecTab = 0 Then
                        rdbShift.Checked = True
                        ShiftSave()
                    ElseIf intSelecTab = 1 Then
                        rdbDayType.Checked = True
                        DayTypeSave()
                    ElseIf intSelecTab = 2 Then
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
                            dgvData.Item(6, intRow).Value = StrSelShift
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
                            dtDate = dgvData.Item(1, intRow).Value
                            strSelDate = Format(dtDate, "yyyyMMdd")
                            'If strSelDate <> "19000101" Then
                            dgvData.Item(7, intRow).Style.BackColor = clrDay
                            dgvData.Item(7, intRow).Value = strNDay
                            'End If
                        End If
                        'dgvEmployee.Item(intColumn, intRow).Value = StrSelShiftID
                    Next l

                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Function fk_ReturnShiftID(ByVal StrShCodes As String) As String
        Dim StrRval As String = Nothing

        Try
            StrRval = fk_RetString("SELECT ShiftID FROM tblSetShiftH WHERE ShortCode = '" & StrShCodes & "'")
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Return StrRval
    End Function

    Private Sub dgvData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick
        If dgvData.CurrentRow.Cells(1).Selected = True Then
            AtnDate1 = CDate(dgvData.CurrentRow.Cells(1).Value)
            If PNLHide.Width = 364 Then
                If strClick = 1 Then ViewFinger() Else ViewAttendanceSAllDays()
            End If
        End If

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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        '20180817 prasanna After month End Can't Change preview days attendance
        If UserLevelID <> "000" Then
            If dtpFromDate.Value <= MaxmunMonthEndDate Then MsgBox("Cant Adjustment   : Your Last Month ('" & MaxmunMonthEndDate & "') Is Over  ", MsgBoxStyle.Information) : Exit Sub
        End If



        If PNLHide.Width = 0 Then
            PNLHide.Width = 364
            btnTime_Click(sender, e)
        ElseIf PNLHide.Width = 364 Then
            PNLHide.Width = 0
        End If

        sSQL = "select 'False',machinid,mDesc from tbldeviceinfo where status=0"
        Load_InformationtoGrid(sSQL, dgvMachin, 3)

        sSQL = "SELECT ShiftID,ShortCode,case when shiftmode =0 then 'Day' else 'Night' end as 'Shift Mode',CONVERT(VARCHAR(8),inTime,108) AS 'In Time',CONVERT(VARCHAR(8),outTime,108) AS 'Out Time' FROM tblSetShiftH WHERE shiftID IN ('" & StrUserLvShifts & "') Order By ShiftID"
        Load_InformationtoGrid(sSQL, dgvAllShifts, 5)

        Load_InformationtoGrid("select TypeID,TypeName,shortCode,workUnit,Clra,clrr,clrg,clrb From tblDayTYpe WHERE Status =0 Order By TypeID", dgvDayType, 8)

    End Sub

    Private Sub AddFingerTime()
        'intSelecTab = 2
        Try
            Me.Cursor = Cursors.WaitCursor
            If strKEmployeeID = "" Then MsgBox("Please select the Employee ", MsgBoxStyle.Information) : Exit Sub
            'Dim dgvTempDGV As New DataGridView
            sSQL = "select tblEmpRegister.empid,convert(nvarchar(10),tblEmpRegister.atdate,111) as 'dDate' from tblEmpRegister ,tblEmployee where tblEmpRegister.empid=tblEmployee.regid and tblEmpRegister.atdate in (" & strSelectDate & ") AND tblEmpRegister.EmpID='" & StrEmployeeID & "' order by tblEmpRegister.atdate"
            Fk_FillGrid(sSQL, dgvTempDGV)

            If MsgBox("Do you want to add manually attendance record to employee of  " & lblName.Text & " for dates of " & strSelectDate & "  ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim intTriD As Integer = fk_sqlDbl("SELECT fxTrID+1 FROM tblControl")

            sSQL = ""
            Dim dtDate As Date
            For I As Integer = 0 To dgvTempDGV.RowCount - 1
                dtDate = CDate(dgvTempDGV.Item(1, I).Value)
                'strSelDate = Format(dtDate, "yyyyMMdd")
                sSQL = sSQL & "INSERT INTO tblDiMachine (MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode,Capture,tTime,EditMode) VALUES " & _
                                  " ('" & strSelestedMac & "',1," & Val(lblEnrolNo.Text) & ",1,1,'" & Format(dtDate, "yyyyMMdd") & "','" & Format(dtpTime.Value, "hh:mm tt") & "',0,0,'',1)"
                sSQL = sSQL & " INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Add attendance data manually for Enrol No :  " & Val(lblEnrolNo.Text) & " and Date : " & Format(dtDate, "yyyyMMdd") & " and Time : " & Format(dtpTime.Value, "hh:mm tt") & " and Device : " & strSelestedMac & " and Note " & FK_Rep(txtNote.Text) & "' ,'" & StrUserID & "',getdate (),'" & StrEmployeeID & "')  ;  "
                sSQL = sSQL & "INSERT INTO [tbldimachineManual] (MacID,EmpID,Input,cDate,cTime,Capture,tTime,crUser,crDate,remark,trID,rowNo) VALUES " & _
                                  " ('" & strSelestedMac & "'," & Val(lblEnrolNo.Text) & ",1,'" & Format(dtDate, "yyyyMMdd") & "','" & Format(dtpTime.Value, "hh:mm tt") & "',0,'','" & StrUserID & "',getdate (),'" & txtNote.Text & "'," & intTriD & "," & I & ")"
                sSQL = sSQL & " UPDATE tblDiMachine SET tTime = cDate+cTime WHERE EmpID = " & Val(lblEnrolNo.Text) & " AND cDate in  (" & strSelectDate & "); UPDATE tblEmpRegister SET textNote ='" & txtNote.Text & "' WHERE atDate in (" & strSelectDate & ") AND empID='" & StrEmployeeID & "' ; UPDATE tblControl SET fxTrID=" & intTriD & " WHERE GrpID='001' ;UPDATE tblDiMachineManual SET tTime = cDate+cTime WHERE cDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
            Next
            FK_EQ(sSQL, "S", "", False, False, True)
            'dgvDetails.Focus()
            Dim dtFrDate As Date = CDate(dgvTempDGV.Item(1, 0).Value)
            Dim dtToDate As Date = CDate(dgvTempDGV.Item(1, dgvTempDGV.RowCount - 1).Value)

            If intBaseOnClockRecord = 0 Then
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtFrDate, dtToDate, pgb, 0, 0)
            Else
                Process_Attendance(dtFrDate, dtToDate, StrEmployeeID, "O", pgb)
            End If

            ViewData()
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

    Private Sub ShiftSave()
        'intSelecTab = 0
        Dim bolAllw As Boolean = False
        sSQL = "SELECT empid FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate in (" & strSelectDate & ") AND rOption = 2"
        bolAllw = fk_CheckEx(sSQL)
        If bolAllw = True Then MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        If StrSelShiftID = "" Then MessageBox.Show("Please select shift to copy", "Edit Shift", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If

        sSQL = "select tblEmpRegister.empid,convert(nvarchar(10),tblEmpRegister.atdate,112)  from tblEmpRegister ,tblEmployee where tblEmpRegister.empid=tblEmployee.regid and tblEmpRegister.atdate in (" & strSelectDate & ") AND tblEmpRegister.EmpID='" & StrEmployeeID & "'"
        Fk_FillGrid(sSQL, dgvTempDGV)

        sSQL = ""
        For I As Integer = 0 To dgvTempDGV.RowCount - 1
            sSQL = sSQL & "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Change Employee Shift of  " & dgvTempDGV.Item(0, I).Value & " to Shift " & StrSelShiftID & " of day " & dgvTempDGV.Item(1, I).Value & "' ,'" & StrUserID & "',getdate (),'" & dgvTempDGV.Item(0, I).Value & "');"
        Next

        sSQL = sSQL & "UPDATE tblEmpRegister SET AllShifts = '" & StrSelShiftID & "' WHERE EmpID = '" & StrEmployeeID & "' AND AtDate in (" & strSelectDate & ") "
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
        'intSelecTab = 1
        Dim bolAllw As Boolean = False
        sSQL = "SELECT empid FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate in (" & strSelectDate & ") AND rOption = 2"
        bolAllw = fk_CheckEx(sSQL)
        If bolAllw = True Then MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        If StrnDayTypID = "" Then MessageBox.Show("Please select day type to copy", "Edit Day Type", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Sub
        End If

        sSQL = "select tblEmpRegister.empid,convert(nvarchar(10),tblEmpRegister.atdate,112)  from tblEmpRegister ,tblEmployee where tblEmpRegister.empid=tblEmployee.regid and tblEmpRegister.atdate in (" & strSelectDate & ") AND tblEmpRegister.EmpID='" & StrEmployeeID & "'"
        Fk_FillGrid(sSQL, dgvTempDGV)

        sSQL = ""
        For I As Integer = 0 To dgvTempDGV.RowCount - 1
            sSQL = sSQL & "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Change Employee Day Type of  " & dgvTempDGV.Item(0, I).Value & " to day type " & StrnDayTypID & " of day " & Format(dtpToDate.Value, "yyyyMMdd") & "' ,'" & StrUserID & "',getdate (),'" & dgvTempDGV.Item(0, I).Value & " ');"
        Next

        sSQL = sSQL & "UPDATE tblEmpRegister SET DayTypeID = '" & StrnDayTypID & "' WHERE EmpID = '" & StrEmployeeID & "' AND AtDate  in (" & strSelectDate & ") ;"
        If FK_EQ(sSQL, "S", "", False, False, True) = True Then
            bolOK = True
        Else
            bolOK = False
        End If

    End Sub

    Private Sub dgvDayType_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDayType.CellClick
        StrnDayTypID = dgvDayType.CurrentRow.Cells(0).Value.ToString
        strNDay = dgvDayType.CurrentRow.Cells(2).Value.ToString
        clrDay = Color.FromArgb(CInt(dgvDayType.Item(4, dgvDayType.CurrentRow.Index).Value), dgvDayType.Item(5, dgvDayType.CurrentRow.Index).Value, dgvDayType.Item(6, dgvDayType.CurrentRow.Index).Value, dgvDayType.Item(7, dgvDayType.CurrentRow.Index).Value)
    End Sub

    Private Sub btnDayTypeEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDayTypeEdit.Click
        If UP("Daily attendance", "Edit employee(s) day types") = False Then Exit Sub
        intSelecTab = 1
        getSelectedArea()
        rdbDayType.Checked = True
    End Sub

    Private Sub btnShiftEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShiftEdit.Click
        If UP("Daily attendance", "Edit employee(s) shift") = False Then Exit Sub
        intSelecTab = 0
        getSelectedArea()
        rdbShift.Checked = True
    End Sub

    Private Sub btnAddFinger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFinger.Click
        If UP("Daily attendance", "Add punch times") = False Then Exit Sub
        intSelecTab = 2
        rdbAddFinger.Checked = True
        getSelectedArea()
    End Sub

    Private Sub dgvAllShifts_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllShifts.CellClick
        StrSelShiftID = dgvAllShifts.CurrentRow.Cells(0).Value.ToString
        StrSelShift = dgvAllShifts.CurrentRow.Cells(1).Value.ToString
    End Sub

    Private Sub dgvDayType_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDayType.CellDoubleClick
        btnDayTypeEdit_Click(sender, e)
    End Sub

    Private Sub dgvAllShifts_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllShifts.CellDoubleClick
        btnShiftEdit_Click(sender, e)
    End Sub

    Private Sub rdbAddFinger_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbAddFinger.CheckedChanged
        If rdbAddFinger.Checked = True Then
            rdbDayType.Checked = False
            rdbShift.Checked = False
        End If
    End Sub

    Private Sub rdbDayType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDayType.CheckedChanged
        If rdbDayType.Checked = True Then
            rdbShift.Checked = False
            rdbAddFinger.Checked = False
        End If
    End Sub

    Private Sub rdbShift_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbShift.CheckedChanged
        If rdbShift.Checked = True Then
            rdbAddFinger.Checked = False
            rdbDayType.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If PNLHide.Width = 0 Then
            PNLHide.Width = 364
        ElseIf PNLHide.Width = 364 Then
            PNLHide.Width = 0
        End If
    End Sub

    Private Sub ViewFinger()
        If UP("Daily attendance", "View finger times") = False Then Exit Sub
        strClick = 1
        Dim prvDate As Date : Dim nextDate As Date
        If AtnDate1 = "12:00:00 AM" Then Exit Sub
        prvDate = DateAdd(DateInterval.Day, -1, AtnDate1) : nextDate = DateAdd(DateInterval.Day, 1, AtnDate1)
        Dim sqlLoad As String = "DECLARE @EnrolNO AS NUMERIC(18,0); SET @EnrolNO = (SELECT EnrolNo FROM tblEmployee WHERE RegID='" & StrEmployeeID & "') ; SELECT tblDiMachine.crLine,Convert(Nvarchar (10),tblDiMachine.cDate,110),cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblDiMachine.cTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),tblDimachine.tTime,Case when tblDiMachine.EditMode = 0 THEN 'A' Else 'M' ENd,macID,empid FROM tblDiMachine WHERE tblDiMachine.cDate Between '" & Format(prvDate, "yyyyMMdd") & "' AND '" & Format(nextDate, "yyyyMMdd") & "' AND tblDiMachine.Capture In (0,1,2,3) AND tblDimachine.EmpID=@EnrolNO Order By tblDiMachine.cDate,tblDimachine.cTime"
        ' Dim sqlLoad As String = "SELECT tblDiMachine.crLine,Convert(Nvarchar (10),tblDiMachine.cDate,110),cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,tblDiMachine.cTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),tblDimachine.tTime,Case when tblDiMachine.EditMode = 0 THEN 'A' Else 'M' ENd,MacID,EmpID FROM tblDiMachine INNER JOIN tblEmployee ON tblEmployee.EnrolNo = tblDiMachine.EmpID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblDiMachine.cDate Between '" & Format(prvDate, "yyyyMMdd") & "' AND '" & Format(nextDate, "yyyyMMdd") & "' AND tblDiMachine.Capture In (0,1,2,3) Order By tblDiMachine.cDate,tblDimachine.cTime"
        Load_InformationtoGrid(sqlLoad, dgvAtnTimes, 6)
        Dim strType As String = ""
        With dgvAtnTimes
            For iRows As Integer = 0 To .RowCount - 1
                Dim strCompare As Date = DateTime.Parse(.Item(1, iRows).Value, CultureInfo.InvariantCulture)
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
        If MsgBox("Do you want to remove " & dgvTempDGVk.RowCount & " time records ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

        If dgvTempDGVk.RowCount = 0 Then MessageBox.Show("Please select punch time record(s) to remove", "Attention", MessageBoxButtons.OK) : Me.Cursor = Cursors.Default : Exit Sub
        sSQL = ""
        Dim dtTTime As DateTime
        Dim dtTO As DateTime = dgvTempDGVk.Item(2, 0).Value
        For I As Integer = 0 To dgvTempDGVk.RowCount - 1
            Dim intCrRow As Integer
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

        Dim dtFingerPrintMaxDate As Date = dtTTime.Date
        If Format(dtFingerPrintMaxDate, "yyyyMMdd") = Format(dtTO, "yyyyMMdd") Then
            dtFingerPrintMaxDate = DateAdd(DateInterval.Day, -1, dtFingerPrintMaxDate)
        End If
        'strKEmployeeID = strKEmployeeID.Remove(0, 1)
        'strKEmployeeID = strKEmployeeID.Remove(strKEmployeeID.Length - 1, 1)
        pgb.Visible = True
        If bolOK = True Then
            If intBaseOnClockRecord = 0 Then
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtTO.Date, dtFingerPrintMaxDate, pgb, 0, 0)
            Else
                Process_Attendance(dtFingerPrintMaxDate, dtTO.Date, StrEmployeeID, "O", pgb)
            End If
        End If

        ViewData()

        pgb.Visible = False

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub getSelectedAreaToRemoveTime()

        Dim selectedCellCount As Integer = _
        dgvAtnTimes.GetCellCount(DataGridViewElementStates.Selected)
        Dim intRow As Integer : Dim intColumn As Integer : Dim strCellName As String
        Dim StrcEmpID As String = ""
        Dim strSelDate As String
        'strDisplaySelected = ""
        'strCollectDisplay = ""
        'Dim selectedRowCount As Integer = _
        'dgvEmployee.SelectedRows.Count
        'Dim intCurrentColumn As Integer = dgvData.se/
        If selectedCellCount = 0 Then MessageBox.Show("Please select punched times to remove", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        Try
            'intEmp = 0
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
                            'intEmp = intEmp + 1
                            dgvTempDGVk.Rows.Add(StrEmployeeID, Val(lblEnrolNo.Text), dgvAtnTimes.Item(3, intRow).Value, Trim(dgvAtnTimes.Item(0, intRow).Value), dgvAtnTimes.Item(5, intRow).Value)
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

    Private Sub RemoveAttendanceTime()
        intSelecTab = 3
        Me.Cursor = Cursors.WaitCursor
        If MsgBox("Do you want to remove selected time ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub
        Dim sqlQRY As String = ""
        Me.Cursor = Cursors.WaitCursor
        Dim dtTTime As DateTime : Dim intCrRow As Integer : Dim dtDat As DateTime
        dtTTime = dgvAtnTimes.CurrentRow.Cells(3).Value
        intCrRow = Val(dgvAtnTimes.CurrentRow.Cells(0).Value)
        ' dtDat = dgvAtnTimes.CurrentRow.Cells(1).Value
        dtDat = DateTime.Parse(dgvAtnTimes.CurrentRow.Cells(1).Value, CultureInfo.InvariantCulture)

       



        Dim strMacID As String = dgvAtnTimes.CurrentRow.Cells(5).Value
        Dim intEnrol As Integer = Val(lblEnrolNo.Text)
        sSQL = "UPDATE tblDiMachine SET Capture = 9 WHERE EmpID = " & Val(lblEnrolNo.Text) & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "' AND crLine = " & intCrRow & "; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Delete attendance time from table Enrol No : " & Val(lblEnrolNo.Text) & " AND tTime : " & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & " AND crLine : " & intCrRow & " and Note " & FK_Rep(txtNote.Text) & "','" & StrUserID & "',getdate (),'" & StrEmployeeID & "')" & _
        "UPDATE tblDiMachineManual SET Capture = 9 WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "'  AND MacID='" & strMacID & "'" & _
        "INSERT INTO tbldimachineRemove SELECT [MacID],[EmpID],[Input],[cDate],[cTime],[capture],[tTime],'" & StrUserID & "',getdate (),'" & txtNote.Text & "'," & intCrRow & " FROM [tbldimachine] WHERE EmpID = " & intEnrol & " AND tTime = '" & Format(dtTTime, "yyyyMMdd HH:mm:ss.fff") & "'  AND MacID='" & strMacID & "'"

        If FK_EQ(sSQL, "D", "", False, False, True) = True Then
            dgvAtnTimes.Rows.Remove(dgvAtnTimes.CurrentRow)
        End If
        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, dtDat)
        If intBaseOnClockRecord = 0 Then
            fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtDat, dtFingerPrintMaxDate, pgb, 0, 0)
        Else
            Process_Attendance(dtDat, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
        End If

        ViewData()
        dtpTime.Focus()
        'btnShow_Click(sender, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvAtnTimes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAtnTimes.CellDoubleClick
        RemoveAttendanceTime()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        strSearchFor = "Cadre"
        ViewData()
    End Sub

    Private Sub ReprocessSelected()
        intSelecTab = 3
        getSelectedArea()

        Try
            Me.Cursor = Cursors.WaitCursor
            If strSelectDate = "" Then
                MessageBox.Show("Please select date(s) to reprocess", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            End If
            sSQL = "select tblEmpRegister.empid,convert(nvarchar(10),tblEmpRegister.atdate,111) as 'dDate' from tblEmpRegister ,tblEmployee where tblEmpRegister.empid=tblEmployee.regid and tblEmpRegister.atdate in (" & strSelectDate & ") AND tblEmpRegister.EmpID='" & StrEmployeeID & "' order by tblEmpRegister.atdate"
            Fk_FillGrid(sSQL, dgvTempDGV)


            Dim dtFrDate As Date = CDate(dgvTempDGV.Item(1, 0).Value)
            Dim dtToDate As Date = CDate(dgvTempDGV.Item(1, dgvTempDGV.RowCount - 1).Value)
            If MsgBox("Do you want to reprocess " & lblName.Text & " for dates of " & dtFrDate & " to " & dtToDate & " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

            If intBaseOnClockRecord = 0 Then
                fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", dtFrDate, dtToDate, pgb, 0, 0)
            Else
                Process_Attendance(dtFrDate, dtToDate, StrEmployeeID, "O", pgb)
            End If

            ViewData()
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

    Private Sub dgvData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvData.MouseClick
        If e.Button = MouseButtons.Right Then
            Button5_Click(sender, e)
        End If
    End Sub

    Private Sub lblCPresent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCPresent.Click
        strSearchFor = "Present"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCAb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCAb.Click
        strSearchFor = "Absent"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lBlCLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lBlCLate.Click
        strSearchFor = "Late"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCInccom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCInccom.Click
        strSearchFor = "Incomplete"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCPreOffk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCPreOffk.Click
        strSearchFor = "PresentOff"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblWHrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWHrs.Click
        strSearchFor = "WorkHours"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCNOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCNOT.Click
        strSearchFor = "NormalOT"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCDOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCDOT.Click
        strSearchFor = "DoubleOT"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCTOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCTOT.Click
        strSearchFor = "TripleOT"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCOf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCOf.Click
        strSearchFor = "OffDay"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCHalfday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCHalfday.Click
        strSearchFor = "HalfDay"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCLeave.Click
        strSearchFor = "OnLeave"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCNop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCNop.Click
        strSearchFor = "Nopay"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub


    Private Sub lblCNight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCNight.Click
        strSearchFor = "NightShift"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCExtra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCExtra.Click
        strSearchFor = "ExtraDay"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCSplit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCSplit.Click
        strSearchFor = "SplitDay"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub lblCF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCF.Click
        strSearchFor = "FixNight"
        If bolIsNightFixed = True Then
            ViewData()
            bolIsNightFixed = False
        Else
            CadreSearch()
        End If
    End Sub

    Private Sub cmdNextDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextDay.Click
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
    End Sub

    Private Sub cmdPrevDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevDay.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, -1, dtpFromDate.Value)
    End Sub

    Private Sub btnNormalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim sqlQRY As String = ""
        'Check Night Shift Existance
        Dim intV As Integer = 0
        If AtnDate1 = Nothing Then MsgBox("Please select the dates", MsgBoxStyle.Information) : Exit Sub
        sqlQRY = "SELECT * FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate = '" & Format(AtnDate1, "yyyyMMdd") & "' AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND DateDiff(Day,tblEmpRegister.ClockIn,tblEmpRegister.ClockOut)>0"
        Dim bolRet As Boolean = fk_CheckEx(sqlQRY)
        If bolRet = False Then MsgBox("You are allowed to normalize only night fixed records", MsgBoxStyle.Critical) : Exit Sub
        Dim strSelEmpNo As String = Trim(dgvData.CurrentRow.Cells(1).Value)
        Dim strSelName As String = Trim(dgvData.CurrentRow.Cells(2).Value)
        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, AtnDate1)
        If MsgBox("Do you want to process rollback, this will clear the night shift and process attendance as fresh attendance," & vbCrLf & "Do you want to Normalise Employee " & strSelEmpNo & " - " & strSelName & " - " & AtnDate1 & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'Normalize Clock In Clock out in EmpRegister
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN, tblEmpRegister.ClockOut = DateAdd(Day,tblSetShiftH.ShiftMode,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(AtnDate1, "yyyyMMdd") & "' AND '" & Format(dtFingerPrintMaxDate, "yyyyMMdd") & "' AND tblEmpRegister.EMpID = '" & StrEmployeeID & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Normalize attendance data of table Date Between : " & Format(AtnDate1, "yyyyMMdd") & " AND " & Format(dtFingerPrintMaxDate, "yyyyMMdd") & " Reg ID :  " & StrEmployeeID & "','" & StrUserID & "',getdate ())" : FK_EQ(sqlQRY, "S", "", False, False, True)

        If intBaseOnClockRecord = 0 Then
            fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", AtnDate1, dtFingerPrintMaxDate, pgb, 0, 0)
        Else
            Process_Attendance(AtnDate1, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
        End If

        ViewData()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTime.Click
        pnlTime.Width = 364
        pnlDay.Width = 0
        pnlShift.Width = 0
        btnTime.BackColor = Color.Orange
        btnShift.BackColor = Color.Navy
        btnDay.BackColor = Color.Navy
        Label16.ForeColor = Color.Orange
        Label17.ForeColor = Color.Navy
        Label18.ForeColor = Color.Navy
    End Sub

    Private Sub btnShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShift.Click
        pnlTime.Width = 0
        pnlDay.Width = 0
        pnlShift.Width = 364
        btnTime.BackColor = Color.Navy
        btnShift.BackColor = Color.Orange
        btnDay.BackColor = Color.Navy
        Label16.ForeColor = Color.Navy
        Label17.ForeColor = Color.Orange
        Label18.ForeColor = Color.Navy
    End Sub

    Private Sub btnDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDay.Click
        pnlTime.Width = 0
        pnlDay.Width = 364
        pnlShift.Width = 0
        btnTime.BackColor = Color.Navy
        btnShift.BackColor = Color.Navy
        btnDay.BackColor = Color.Orange
        Label16.ForeColor = Color.Navy
        Label17.ForeColor = Color.Navy
        Label18.ForeColor = Color.Orange
    End Sub

    Private Sub Panel44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel44.Click
        lblCPresent_Click(sender, e)
    End Sub

    Private Sub Panel51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel51.Click
        lblCAb_Click(sender, e)
    End Sub

    Private Sub Panel46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel46.Click
        lBlCLate_Click(sender, e)
    End Sub

    Private Sub Panel47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel47.Click
        lblCInccom_Click(sender, e)
    End Sub

    Private Sub Panel48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel48.Click
        lblCPreOffk_Click(sender, e)
    End Sub

    Private Sub Panel55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel55.Click
        lblCNOT_Click(sender, e)
    End Sub

    Private Sub Panel50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel50.Click
        lblCDOT_Click(sender, e)
    End Sub

    Private Sub Panel8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel8.Click
        lblCTOT_Click(sender, e)
    End Sub

    Private Sub Panel52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel52.Click
        lblCOf_Click(sender, e)
    End Sub

    Private Sub Panel53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel53.Click
        lblCHalfday_Click(sender, e)
    End Sub

    Private Sub Panel54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel54.Click
        lblCLeave_Click(sender, e)
    End Sub

    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click
        lblCNop_Click(sender, e)
    End Sub

    Private Sub Panel12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel12.Click
        lblCNight_Click(sender, e)
    End Sub

    Private Sub Panel14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel14.Click
        lblCExtra_Click(sender, e)
    End Sub

    Private Sub Panel15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel15.Click
        lblCSplit_Click(sender, e)
    End Sub

    Private Sub Panel16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel16.Click
        lblCF_Click(sender, e)
    End Sub

    Private Sub Panel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel6.Click
        lblWHrs_Click(sender, e)
    End Sub

    Private Sub btnReprocess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprocess.Click
        ReprocessSelected()
    End Sub

    Private Sub btnOTProces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOTProces.Click
        intSelecTab = 3
        Me.Cursor = Cursors.WaitCursor
        getSelectedArea()

        Me.Cursor = Cursors.WaitCursor
        If strSelectDate = "" Then
            MessageBox.Show("Please select date(s) to reprocess", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        End If
        sSQL = "select tblEmpRegister.empid,convert(nvarchar(10),tblEmpRegister.atdate,111) as 'dDate' from tblEmpRegister ,tblEmployee where tblEmpRegister.empid=tblEmployee.regid and tblEmpRegister.atdate in (" & strSelectDate & ") AND tblEmpRegister.EmpID='" & StrEmployeeID & "' order by tblEmpRegister.atdate"
        Fk_FillGrid(sSQL, dgvTempDGV)

        Dim dtFrDate As Date = CDate(dgvTempDGV.Item(1, 0).Value)
        Dim dtToDate As Date = CDate(dgvTempDGV.Item(1, dgvTempDGV.RowCount - 1).Value)
        If MsgBox("Do you want to run calculations " & lblName.Text & " for dates of " & dtFrDate & " to " & dtToDate & " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Me.Cursor = Cursors.Default : Exit Sub

        'process_AttendanceParameters(dtpFromDate.Value, dtpToDate.Value, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        process_AttendanceParameters(dtFrDate, dtToDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        ViewData()
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub CompanyParameter()
        sSQL = "SELECT Latemin,OTRound,MinHrsOT,OTRndOption FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        fk_Return_MultyString(sSQL, 4)
        dblLateMins = fk_ReadGRID(0)
        dblOTRound = fk_ReadGRID(1)
        dblMinOT = fk_ReadGRID(2)
        intOTRndOption = fk_ReadGRID(3)
    End Sub

    Private Sub btnRemAttendanc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemAttendanc.Click
        If UP("Daily attendance", "Remove employee punch time(s)") = False Then Exit Sub
        RemoveBulkPunchedTime()
    End Sub

    Private Sub btnNormalizk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNormalizk.Click
        intSelecTab = 3
        Me.Cursor = Cursors.WaitCursor
        Dim sqlQRY As String = ""
        'Check Night Shift Existance
        Dim intV As Integer = 0
        If AtnDate1 = Nothing Then MsgBox("Please select the dates", MsgBoxStyle.Information) : Exit Sub
        sqlQRY = "SELECT * FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate = '" & Format(AtnDate1, "yyyyMMdd") & "' AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND DateDiff(Day,tblEmpRegister.ClockIn,tblEmpRegister.ClockOut)>0"
        Dim bolRet As Boolean = fk_CheckEx(sqlQRY)
        If bolRet = False Then MsgBox("You are allowed to normalize only night fixed records", MsgBoxStyle.Critical) : Exit Sub
        Dim strSelEmpNo As String = lblEnrolNo.Text
        Dim strSelName As String = lblName.Text
        Dim dtFingerPrintMaxDate As Date = DateAdd(DateInterval.Day, 1, AtnDate1)
        If MsgBox("Do you want to process rollback, this will clear the night shift and process attendance as fresh attendance," & vbCrLf & "Do you want to Normalise Employee " & strSelEmpNo & " - " & strSelName & " - " & AtnDate1 & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        'Normalize Clock In Clock out in EmpRegister
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN, tblEmpRegister.ClockOut = DateAdd(Day,tblSetShiftH.ShiftMode,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(AtnDate1, "yyyyMMdd") & "' AND '" & Format(dtFingerPrintMaxDate, "yyyyMMdd") & "' AND tblEmpRegister.EMpID = '" & StrEmployeeID & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Normalize attendance data of table Date Between : " & Format(AtnDate1, "yyyyMMdd") & " AND " & Format(dtFingerPrintMaxDate, "yyyyMMdd") & " Reg ID :  " & StrEmployeeID & "','" & StrUserID & "',getdate ())" : FK_EQ(sqlQRY, "S", "", False, False, True)

        If intBaseOnClockRecord = 0 Then
            fk_ProcessAttendanceNEW("SELECT RegID,'',EnrolNo FROM tblEmployee WHERE RegID In ('" & StrEmployeeID & "') AND EmpStatus <> 9 Order By RegID", AtnDate1, dtFingerPrintMaxDate, pgb, 0, 0)
        Else
            Process_Attendance(AtnDate1, dtFingerPrintMaxDate, StrEmployeeID, "O", pgb)
        End If

        ViewData()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkAbsent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAbsent.Click
        ViewData()
    End Sub

    Private Sub chkAll_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkAll.MouseClick
        If chkAll.Checked = True Then
            dgvData.ClearSelection()
            For kk As Integer = 0 To dgvData.RowCount - 1
                dgvData.Item(1, kk).Selected = True
            Next
        Else
            dgvData.ClearSelection()
        End If
    End Sub

    Private Sub btnConfrmNight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfrmNight.Click
        NightConfirm()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtNote_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNote.KeyPress
        If AscW(e.KeyChar) = 13 Then
            btnAddFinger_Click(sender, e)
        End If
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