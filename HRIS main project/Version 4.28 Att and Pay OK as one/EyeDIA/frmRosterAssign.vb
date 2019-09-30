Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmRosterAssign
#Region "Declarations"
    Dim intYear As Integer = 0
    Dim intMonth As Integer = 0
    Dim intStartDay As Integer = 0
    Dim dtSelectedDate As Date 'Selected date for the shift assign
    Dim iAtRow As Integer = 0 : Dim iAtCol As Integer = 0
    Dim StrOffDayShd As String = "" 'Off day shedule 
    Dim StrEmpAll As String = ""
    Dim dtLoopStartday As Date : Dim dtLoopsEnDday As Date
    Dim StrChgMode As String = "00"
    Dim StrAllShifts As String
    Dim iCurrentRow As Integer = 0
    Dim iCurrentCol As Integer = 0
    Dim iCount As Integer = 0
    Dim StrDTypeID As String = ""

    Public Event CurrentCellDirtyStateChanged As EventHandler

#End Region

    Sub dataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dgvCrShifts.CurrentCellDirtyStateChanged

        If dgvCrShifts.IsCurrentCellDirty Then
            dgvCrShifts.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub


    ' If a check box cell is clicked, this event handler disables  
    ' or enables the button in the same row as the clicked cell.
    Public Sub dataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvCrShifts.CellValueChanged

        If dgvCrShifts.Columns(e.ColumnIndex).Name = "selec" Then
            Dim checkCell As DataGridViewCheckBoxCell = CType(dgvCrShifts.Rows(e.RowIndex).Cells("selec"), DataGridViewCheckBoxCell)
            dgvCrShifts.Invalidate()
        End If
        iCount = 0
        StrSelectShift = ""
        With dgvCrShifts
            If .RowCount <= 0 Then Exit Sub
            iCurrentRow = .CurrentRow.Index
            'iCurrentCol = .CurrentCell.ColumnIndex
            If iCurrentCol = 0 Then
                For i As Integer = 0 To .RowCount - 1
                    If .Item(0, i).Value = True Then
                        iCount = iCount + 1
                        If iCount > 2 Then MsgBox("You allow to select only Max 2 shifts per day", MsgBoxStyle.Information) : .Item(0, iCurrentRow).Value = 0 : Exit Sub
                        If StrSelectShift = "" Then StrSelectShift = .Item(1, i).Value Else StrSelectShift = StrSelectShift & "|" & .Item(1, i).Value
                    End If
                Next
            End If
        End With

    End Sub

    Private Sub frmGenWeek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Roster/ Shift", "View roster assigning form") = False Then Exit Sub

        CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)

        'Create New table to save the information of the multiple shift adding 
        Dim sqlTable As String = ""

        sqlTable = "CREATE  FUNCTION [dbo].[fk_CountRegister]  (@EmpID nvarchar(6),@stDate DateTime,@edDate DateTime) RETURNS Numeric (18,0) AS  BEGIN  " & _
        " declare @Return Numeric (18,0) SET @Return = (SELECT Count(*) FROM tblEmpRegister WHERE EmpId = @empID AND atDate Between @stDate AND @edDate) " & _
        " if @return is null 	set @return = 0 return @return end"
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "CREATE TABLE tblEShiftPlanH (EmpID Nvarchar (6),AtDate DateTime,NoShifts Numeric (18,0),AntStatus Numeric (18,0),WorkedShifts Numeric (18,0),WorkMins Numeric (18,2),DayCount Numeric (18,2),DayTypeID Nvarchar (2),IsLeave Nvarchar (3),NoLeave Numeric(18,2),IsLate Numeric (18,0),LateMins Numeric (18,0),IsEarly Numeric (18,0),EarlyMin Numeric (18,0),BOTMins Numeric (18,0),BgOTHrs Numeric (18,2),EODMins Numeric (18,0),EdOTHrs Numeric (18,2))"
        FK_EQ(sqlTable, "S", "", False, False, False)

        'New Modification on 5/8/2012
        sqlTable = "CREATE TABLE tblGetINOUT (EmpID Nvarchar (6),AtDate DateTime,AntStatus Numeric (18,0),ShiftID Nvarchar (3),InTime DateTime,OutDate DateTime,OutTime DateTime," & _
        " sInTime DateTime,sOutTime DateTime,ClockIn DateTime,ClockOut DateTime,WorkMin Numeric (18,0),LateMin Numeric (18,0), " & _
        " IsLate Numeric (18,0),EarlyMin Numeric (18,0),IsEarly Numeric (18,0),InUpdate Numeric (18,0),OutUpdate Numeric (18,0), " & _
        " mInUpdate Numeric (18,0),mOutUpdate Numeric (18,0), BOTMin Numeric (18,0),EOTMin Numeric (18,0),OTMin Numeric (18,0)) "
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "CREATE TABLE tblEShiftPlanD (EmpID Nvarchar (6),AtDate DateTime,ShiftID Nvarchar (3),InTime DateTime,OutDate DateTime, " & _
        " OutTime DateTime,WorkMins Numeric (18,0),AntStatus Numeric (18,0),ClockIN DateTime, ClockOut DateTime,DayCount Numeric (18,2),OTAuth Numeric (18,0),InUpdate Numeric (18,0),OutUpdate Numeric(18,0), EditIn Numeric (18,0),EditOut Numeric (18,0),AtEdit Numeric (18,0))"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblEmpRegister Add AllShifts Nvarchar (100)"
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblEmployee ADD WrkCode Nvarchar (3) NOT NULL Default ''"
        FK_EQ(sqlTable, "S", "", False, False, False)

        cmdRefresh_Click(sender, e)

    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.BackColor

    'End Sub

    Public Sub set_Grid()

        With dgvShdule
            .RowTemplate.Height = 40
            .RowHeadersWidth = 21
            .Columns.Clear()
            'Add default value 
            .Columns.Add("DayDesc", "Description") '-0
            .Columns.Add("mnDay", "MON") : .Columns(1).Visible = False ' -1 
            .Columns.Add("mnShift", "MON") '-2
            .Columns.Add("tuDay", "TUE") : .Columns(3).Visible = False  ' -3
            .Columns.Add("tuShift", "TUE") ' -4
            .Columns.Add("WdDay", "WED") : .Columns(5).Visible = False ' -5
            .Columns.Add("wdShift", "WED") ' -6
            .Columns.Add("ThDay", "THU") : .Columns(7).Visible = False  ' -7
            .Columns.Add("thShift", "THU") ' -8
            .Columns.Add("FrDay", "FRI") : .Columns(9).Visible = False  ' -9
            .Columns.Add("FrShift", "FRI") ' -10
            .Columns.Add("StDay", "SAT") : .Columns(11).Visible = False  ' -11
            .Columns.Add("StShift", "SAT") ' -12
            .Columns.Add("SuDay", "SUN") : .Columns(13).Visible = False  ' -13
            .Columns.Add("SuShift", "SUN") ' -14

            For i As Integer = 1 To 14
                .Columns(i).Width = 50
            Next

        End With

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)
        'Dim StrAllDept As String = fk_SplitToSQL_in(StrAccessDept)

        set_Grid()
        'Load Combo box information 
        ListComboAll(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 AND DeptID IN ('" & StrUserLvDept & "')  Order By DeptID", "deptName")
        ListComboAll(cmbCat, "SELECT * FROM tblSetEmpCategory WHERE status = 0 Order By CatID", "CatDesc")
        ListComboAll(cmbDesig, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "DesgDesc")
        ListCombo(cmbWorkDay, "SELECT * FROM tblWkSheduleH WHERE Status = 0 Order By ShdID", "ShdName")
        intStartDay = fk_sqlDbl("SELECT StartDay FROM tblCompany WHERE CompID = '" & StrCompID & "'") 'Company Working StartDay Declare as that
        ListComboAll(cmbType, "select tDesc from tblSetEmpType order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")
        ListCombo(cmbDayType, "SELECT * FROM tblDayType WHERE Status = 0 Order By TypeID", "TypeName")

        'Load Information to grid
        Dim sqlTable As String = ""
        sqlTable = "SELECT 'False',ShiftID,Shiftname,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,InTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,OutTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar) FROM tblSetShiftH WHERE Status =  0 Order by ShiftID"
        Load_InformationtoGrid(sqlTable, dgvCrShifts, 5)
        clr_Grid(dgvCrShifts)

        'Load Yesr
        cmbYear.Items.Clear()
        For i As Integer = 2008 To 2020
            cmbYear.Items.Add(i.ToString)
        Next

        cmbYear.Text = intCurrentYear.ToString
        'Load Months 
        cmbMonth.Items.Clear()

        For i As Integer = 1 To 12
            cmbMonth.Items.Add(MonthName(i))
        Next

        'Load Work Shedule 
        ListCombo(cmbWrkCode, "Select * from tblWKSheduleH Order By ShdID", "ShdName")

        cmbMonth.SelectedIndex = 0
        txtSearch.Text = "K"
        txtSearch.Text = ""
        'intRegMode = 1

        ''Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        ''Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "RegID" Else If IsEpf = 1 Then sqlTag = "EpfNo" Else sqlTag = "EnrolNo"

        ''Dim strQuery As String = "SELECT RegID as 'EMPID'," & sqlTag & ",DispName,CASE WHEN WrkCode = '' THEN 'True' Else 'False' END  FROM tblEmployee WHERE EmpStatus <> 9 ORDER BY " & sqlTag & ""
        ''Load_InformationtoGrid(strQuery, dgvEmployee, 4)
        ''clr_Grid(dgvEmployee)
        ''lblRowCoun.Text = "Total Employees : " & dgvEmployee.RowCount

        'Select Case IsEpf
        '    Case 0
        '        dgvEmployee.Columns(0).Visible = True
        '        dgvEmployee.Columns(1).Visible = False
        '    Case 1
        '        dgvEmployee.Columns(0).Visible = False
        '        dgvEmployee.Columns(1).Visible = True
        'End Select

        'ListGRID("xx")

    End Sub

    Public Sub Load_Days(ByVal sqlMainQRY As String, ByVal SqlOrderQRY As String)

        set_Grid()

        If cmbYear.Text = "" Then Exit Sub
        intYear = CInt(cmbYear.Text)
        intMonth = cmbMonth.SelectedIndex + 1
        Dim inDayGap As Integer = 0 : Dim intBackGap As Integer = 0
        Dim dtFirstDay As Date = DateSerial(intYear, intMonth, 1) : Dim dtLastDay As Date = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtFirstDay))

        Dim iDay As Integer = dtFirstDay.DayOfWeek : Dim iLDay As Integer = dtLastDay.DayOfWeek
        intBackGap = (intStartDay + 6) - iLDay : inDayGap = intStartDay - iDay
        dtLoopStartday = DateAdd(DateInterval.Day, inDayGap, dtFirstDay)
        dtLoopsEnDday = DateAdd(DateInterval.Day, intBackGap, dtLastDay)

        'Check the Calendar Status for the Selected Date Range 
        Dim bolCal As Boolean = fk_CheckEx("SELECT * FROM tblCalendar WHERE [Date] Between '" & Format(dtLoopStartday, "yyyyMMdd") & "' AND '" & Format(dtLoopsEnDday, "yyyyMMdd") & "'")
        If bolCal = False Then MsgBox("Calendar information not found in the system", MsgBoxStyle.Information) : Exit Sub
        Dim dtRunDate As Date = DateSerial(1900, 1, 1)
        Dim intClrA As Integer = 0 : Dim intClrR As Integer = 0 : Dim intClrG As Integer = 0 : Dim intClrB As Integer = 0

        'Date Should be in a loop from frist date to last date 
        Dim iCol As Integer = 0 : Dim iRow As Integer = 0
        Dim StrDes As String = ""
        With dgvShdule
            StrDes = Format(dtLoopStartday, "dd/MMM") & "-" & Format(dtLoopStartday.AddDays(6), "dd/MMM")

            .Rows.Add(StrDes, "", "", "", "", "", "", "", "", "", "", "", "", "", "") : iCol = 1
            'Open the Calendar table from the system
            Dim cnCal As New SqlConnection(sqlConString)
            cnCal.Open()
            Dim sqlcal As String = sqlMainQRY & " Between '" & Format(dtLoopStartday, "yyyyMMdd") & "' AND '" & Format(dtLoopsEnDday, "yyyyMMdd") & "' " & SqlOrderQRY
            Try
                Dim cmCal As New SqlCommand(sqlcal, cnCal)
                Dim drCal As SqlDataReader = cmCal.ExecuteReader
                Do While drCal.Read = True
                    Dim StrShID As String = IIf(IsDBNull(drCal.Item("AllShifts")), "", drCal.Item("AllShifts"))
                    intClrA = IIf(IsDBNull(drCal.Item("ClrA")), 0, drCal.Item("ClrA")) : intClrR = IIf(IsDBNull(drCal.Item("ClrR")), 0, drCal.Item("ClrR")) : intClrG = IIf(IsDBNull(drCal.Item("ClrG")), 0, drCal.Item("ClrG")) : intClrB = IIf(IsDBNull(drCal.Item("ClrB")), 0, drCal.Item("ClrB"))
                    dtRunDate = IIf(IsDBNull(drCal.Item("Date")), DateSerial(1900, 1, 1), drCal.Item("Date"))
                    .Item(iCol, iRow).Value = dtRunDate : .Item(iCol + 1, iRow).Value = StrShID : .Item(iCol + 1, iRow).Style.BackColor = Color.FromArgb(intClrA, intClrR, intClrG, intClrB) : iCol = iCol + 2
                    If iCol = 15 Then iRow = iRow + 1 : iCol = 1 : StrDes = Format(dtRunDate.AddDays(1), "dd/MMM") & "-" & Format(dtRunDate.AddDays(7), "dd/MMM") : .Rows.Add(StrDes, "", "", "", "", "", "", "", "", "", "", "", "", "", "")
                Loop
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnCal.Close()
            End Try
            .Rows.RemoveAt(iRow)
        End With

    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged

        txtSearch.Text = cmbDept.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
        'txtSearch.Text = ""
        'ListGRID("xx")

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
        "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblCBranchs.BrName LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetEmpType.tDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSetTitle.titleDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        "dbo.tblSEtEmpCategory.CatDesc LIKE '%" & txtSearch.Text & "%') AND tblEmployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') " & _
        "order by " & sqlTag & ""

        Load_InformationtoGrid(strQuery, dgvEmployee, 7)
        clr_Grid(dgvEmployee)

        lblRowCoun.Text = "Total Employees : " & dgvEmployee.RowCount

    End Sub

    Public Sub ListGRID(ByVal StrBack As String)

        'Dim StrDesgID As String
        'Dim StrDeptID As String
        'Dim StrCatID As String
        'StrBack = fk_RetString("SELECT ShdID FROM tblWkSheduleH WHERE ShdName = '" & cmbWorkDay.Text & "'")
        'StrDesgID = fk_RetString("SELECT DesgID FROM tblDesig WHERE DesgDesc = '" & cmbDesig.Text & "'")
        'StrDeptID = fk_RetString("SELECT DeptID FROM tblSetDept WHERE deptName = '" & cmbDept.Text & "'")
        'StrCatID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbCat.Text & "'")
        'Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        'Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "RegID" Else If IsEpf = 1 Then sqlTag = "EpfNo" Else sqlTag = "EnrolNo"

        'Dim sqlList As String = ""

        'If txtSearch.Text = "" Then

        '    intRegMode = 0

        'ElseIf StrDesgID = "" And StrDeptID = "" And StrCatID = "" And txtSearch.Text <> "" Then

        '    intRegMode = 1

        'ElseIf txtSearch.Text <> "" And StrDesgID <> "" Or StrDeptID <> "" Or StrCatID <> "" Then

        '    intRegMode = 2

        'End If

        'Select Case intRegMode

        '    Case 0
        '        sqlList = "SELECT RegID as 'EMPID'," & sqlTag & ",DispName,CASE WHEN WrkCode = '" & StrBack & "' THEN 'True' Else 'False' END  FROM tblEmployee WHERE DeptID = '" & StrDeptID & "' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%' AND RegID LIKE '" & txtSearch.Text & "%' AND EmpStatus <> 9 ORDER BY " & sqlTag & ""
        '    Case 1
        '        StrDesgID = ""
        '        StrDeptID = ""
        '        StrCatID = ""
        '        sqlList = "SELECT RegID as 'EMPID'," & sqlTag & ",DispName,CASE WHEN WrkCode = '" & StrBack & "' THEN 'True' Else 'False' END FROM tblEmployee WHERE DeptID = '" & StrDeptID & "' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%' OR (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%')     AND EmpStatus <> 9  ORDER BY " & sqlTag & ""
        '    Case 2
        '        sqlList = "SELECT RegID as 'EMPID'," & sqlTag & ",DispName,CASE WHEN WrkCode = '" & StrBack & "' THEN 'True' Else 'False' END FROM tblEmployee WHERE DeptID = '" & StrDeptID & "' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%' AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        '        "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%')     AND EmpStatus <> 9  ORDER BY " & sqlTag & ""
        '        'sqlList = "SELECT RegID,EpfNo,DispName,CASE WHEN WrkCode = '" & StrBack & "' THEN 'True' Else 'False' END FROM tblEmployee WHERE DeptID = '" & StrDeptID & "' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%' AND EnrolNo LIKE " & txtSearch.Text & "% AND EmpStatus <> 9  ORDER BY RegID"

        'End Select

        'Load_InformationtoGrid(sqlList, dgvEmployee, 4)
        ''If StrDeptID = "" Then dgvEmployee.Rows.Clear()
        ''Color the Grid 
        'clr_Grid(dgvEmployee)

        'lblRowCoun.Text = "Total Employees : " & dgvEmployee.RowCount

    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged

        txtSearch.Text = cmbCat.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbDesig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesig.SelectedIndexChanged

        txtSearch.Text = cmbDesig.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub txtEmployee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        EmployeeSearch()
        'ListGRID("xx")
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged

        Load_Days("select tblCalendar.Date,'' As AllShifts,tblDayType.TypeID,tblDayType.ClrA,tblDayType.ClrR,tblDayType.ClrG,tblDayType.ClrB,tblDayType.WorkUnit From tblCalendar INNER JOIN tblDayType ON tblCalendar.DayType = tblDayType.TypeID WHERE tblCalendar.Date ", " Order By tblCalendar.Date")

    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged

        Load_Days("select tblCalendar.Date,'' As AllShifts,tblDayType.TypeID,tblDayType.ClrA,tblDayType.ClrR,tblDayType.ClrG,tblDayType.ClrB,tblDayType.WorkUnit From tblCalendar INNER JOIN tblDayType ON tblCalendar.DayType = tblDayType.TypeID WHERE tblCalendar.Date ", "  Order By tblCalendar.Date")

    End Sub

    Private Sub dgvShdule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvShdule.Click

        Try
            With dgvShdule
                iAtCol = .CurrentCell.ColumnIndex : iAtRow = .CurrentCell.RowIndex : If iAtCol = 0 Then dtSelectedDate = DateSerial(1900, 1, 1) : Exit Sub
                dtSelectedDate = CDate(.Item(iAtCol - 1, iAtRow).Value)
                If dtSelectedDate = DateSerial(1900, 1, 1) Then txtSeldate.Text = "" Else txtSeldate.Text = Format(dtSelectedDate, "dd/MM/yyyy")
                'Set Selected Shift to the selected date
                If StrSelectShift = "" Then Exit Sub
                .Item(iAtCol, .CurrentRow.Index).Value = StrSelectShift
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        If txtSeldate.Text = "" Then MsgBox("Please Select the Date First", MsgBoxStyle.Information) : Exit Sub
        StrOffDayShd = fk_RetString("SELECT ShdID FROM tblWKSheduleH WHERE shdName = '" & cmbWorkDay.Text & "'")
        If StrOffDayShd = "" Then MsgBox("Please select the Roster Pattern", MsgBoxStyle.Information) : Exit Sub
        If StrSelectShift = "" Then MsgBox("Select the Shift", MsgBoxStyle.Information) : Exit Sub
        dgvShdule.Item(iAtCol, iAtRow).Value = StrSelectShift

    End Sub

    'Private Sub dgvCrShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCrShifts.Click
    '    'StrSelectShift = dgvCrShifts.Item(0, dgvCrShifts.CurrentRow.Index).Value
    '    StrSelectShift = ""

    '    Dim iCount As Integer = 0
    '    With dgvCrShifts
    '        For i As Integer = 0 To .RowCount - 1
    '            If .Item(0, i).Value = True Then iCount = iCount + 1 : If StrSelectShift = "" Then StrSelectShift = .Item(1, i).Value Else StrSelectShift = StrSelectShift & "|" & .Item(1, i).Value
    '            If iCount >= 2 Then MsgBox("System Is Not allwoing to add more than 2 shifts per day !!", MsgBoxStyle.Information) : i = .RowCount - 1 : .Item(0, .CurrentRow.Index).Value = False
    '        Next
    '    End With
    '    txtSelShft.Text = StrSelectShift

    'End Sub

    Public Sub ret_days()

        Load_Days("select tblCalendar.Date,'' As ShiftID,tblDayType.TypeID,tblDayType.ClrA,tblDayType.ClrR,tblDayType.ClrG,tblDayType.ClrB,tblDayType.WorkUnit From tblCalendar INNER JOIN tblDayType ON tblCalendar.DayType = tblDayType.TypeID WHERE tblCalendar.Date ", " Order By tblCalendar.Date")

    End Sub

    Private Sub cmbWorkDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkDay.SelectedIndexChanged

        If StrChgMode = "01" Then StrChgMode = "00" : Exit Sub
        StrOffDayShd = fk_RetString("SELECT ShdID FROM tblWkSheduleH WHERE ShdName = '" & cmbWorkDay.Text & "'")
        'Dim q1 As String = "select tblCalendar.Date,'' As AllShifts,tblWkSheduleD.DayTypeID,tblDayType.ClrA,tblDayType.ClrR,tblDayType.ClrG,tblDayType.ClrB,tblDayType.WorkUnit From tblCalendar INNER JOIN tblWKSheduleD ON tblCalendar.DayLink = tblWkSheduleD.DayID " & _
        '" INNER JOIN tblDayType ON tblWkSheduleD.DayTypeID = tblDayType.TypeID WHERE tblWkSheduleD.ShdID = '" & StrOffDayShd & "' AND tblCalendar.Date "
        Dim q1 As String = "select tblCalendar.Date,'' As AllShifts,tblWkSheduleD.DayTypeID,tblDayType.ClrA,tblDayType.ClrR,tblDayType.ClrG,tblDayType.ClrB,tblDayType.WorkUnit From tblCalendar INNER JOIN tblWKSheduleD ON tblCalendar.DayLink = tblWkSheduleD.DayID " & _
       " INNER JOIN tblDayType ON tblWkSheduleD.DayTypeID = tblDayType.TypeID WHERE tblWkSheduleD.ShdID = '" & StrOffDayShd & "' AND tblCalendar.Date "

        Dim q2 As String = "  Order By tblCalendar.Date"
        Load_Days(q1, q2)
        ListGRID(StrOffDayShd)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Roster/ Shift", "Changing the roster pattern") = False Then Exit Sub

        Dim sqlQRY As String = ""
        'Read the 
        Dim inShift As Integer = 0 : Dim dtDate As Date : Dim StrShift As String = "" : Dim StrAddShift As String = ""
        Dim iTab As Integer = TabControl1.SelectedIndex
        Select Case iTab
            Case 0
                cmdEdit_Click(sender, e)
            Case 1

                StrEmpAll = ""
                'Add to New grid shift effecting employees 
                Dim dgvEmpUps As New DataGridView
                With dgvEmpUps
                End With
                With dgvEmployee
                    For i As Integer = 0 To .RowCount - 1
                        If .Item(0, i).Value = True Then If StrEmpAll = "" Then StrEmpAll = .Item(1, i).Value Else StrEmpAll = StrEmpAll & "','" & .Item(1, i).Value
                    Next
                End With

                If StrEmpAll = "" Then MsgBox("Please Select the Employee", MsgBoxStyle.Information) : Exit Sub

                With dgvShdule
                    dgvLineShift.Rows.Clear()

                    For iRow = 0 To .RowCount - 1

                        For iColumns As Integer = 1 To .ColumnCount - 1
                            dtDate = .Item(iColumns, iRow).Value
                            StrAddShift = .Item(iColumns + 1, iRow).Value
                            Dim nameArray As String() = StrAddShift.Split("|")
                            Dim initials As String = String.Empty
                            inShift = 0
                            For Each name As String In nameArray
                                StrShift = name.ToString
                                inShift = inShift + 1
                                dgvLineShift.Rows.Add(inShift.ToString, dtDate, StrShift)
                            Next
                            'Update All Shifts to the EmpRegister table 
                            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET AllShifts = '" & StrAddShift & "' WHERE EmpID In ('" & StrEmpAll & "') AND AtDate = '" & Format(dtDate, "yyyyMMdd") & "'"
                            'Change the Shift In/Out Time based on the parameters 
                            iColumns = iColumns + 1
                        Next
                    Next
                End With

                FK_EQ(sqlQRY, "S", "", False, True, True)
                'sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.sInTime = tblEmpRegister.AtDate+tblSetShiftH.inTime,tblEMpRegister.sOutTime = CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate+tblSetShiftH.OutTime ELSE DateAdd(Day,1,tblEmpRegister.AtDate) + tblSetShiftH.OutTime END FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblSetShiftH.ShiftID = tblEmpRegister.ShiftID WHERE tblEmpRegister.EmpID In ('" & StrEmpAll & "') AND tblEmpRegister.AtDate Between '" & Format(dtLoopStartday, "yyyyMMdd") & "' AND '" & Format(dtLoopsEnDday, "yyyyMMdd") & "'"
                'FK_EQ(sqlQRY, "P", "", False, True, True)

            Case 2
                If MsgBox("Do you want to run the process ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                _Change_CanderProfile()



        End Select

    End Sub

    Public Sub _Change_CanderProfile()
        StrEmpAll = ""
        'Add to New grid shift effecting employees 
        Dim dgvEmpUps As New DataGridView
        With dgvEmpUps
        End With
        With dgvEmployee
            For i As Integer = 0 To .RowCount - 1
                If .Item(0, i).Value = True Then If StrEmpAll = "" Then StrEmpAll = .Item(1, i).Value Else StrEmpAll = StrEmpAll & "','" & .Item(1, i).Value
            Next
        End With
        StrOffDayShd = fk_RetString("SELECT ShdID FROM tblWKSheduleH WHERE ShdName = '" & cmbWrkCode.Text & "'")
        If StrOffDayShd = "" Then MsgBox("Please Select the Profile", MsgBoxStyle.Critical) : Exit Sub

        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblEmployee SET WrkCode = '" & StrOffDayShd & "' WHERE RegID In ('" & StrEmpAll & "')"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        Dim dtSt As Date : Dim dtEd As Date
        If chkCrYears.CheckState = CheckState.Checked Then
            dtSt = DateSerial(CInt(cmbYear.Text), 1, 1)
            dtEd = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 1, dtSt))
        Else
            dtSt = DateSerial(CInt(cmbYear.Text), intMonth, 1)
            dtEd = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtSt))

        End If
        sqlQRY = ""
        Dim StrRunEmp As String = ""
        With dgvEmployee
            For i As Integer = 0 To .RowCount - 1
                If .Item(0, i).Value = True Then
                    StrRunEmp = .Item(1, i).Value
                    sqlQRY = sqlQRY & " Exec sp_ApplyShedule '" & StrRunEmp & "','" & StrOffDayShd & "','" & Format(dtSt, "yyyyMMdd") & "','" & Format(dtEd, "yyyyMMdd") & "'"
                End If
            Next
        End With

        FK_EQ(sqlQRY, "P", "", False, True, True)


        'Change the Calendar (tblEmpRegister based on selected calendar profile)


    End Sub

    Public Sub _Shift_Change_Save()

        'Get the Selected Employee List From the Grid 1 
        If dgvShdule.RowCount <= 0 Then MsgBox("No Shedule to Update", MsgBoxStyle.Information) : Exit Sub
        If StrOffDayShd = "" Then MsgBox("Please Select the Off Shift Mode", MsgBoxStyle.Information) : Exit Sub

        StrEmpAll = ""
        'Add to New grid shift effecting employees 
        Dim dgvEmpUps As New DataGridView
        With dgvEmpUps
        End With
        With dgvEmployee
            For i As Integer = 0 To .RowCount - 1
                If .Item(3, i).Value = True Then If StrEmpAll = "" Then StrEmpAll = .Item(0, i).Value Else StrEmpAll = StrEmpAll & "','" & .Item(0, i).Value
            Next
        End With

        If StrEmpAll = "" Then MsgBox("Please Select the Employee", MsgBoxStyle.Information) : Exit Sub

        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE AntStatus = 1 AND atDate Between '" & Format(dtLoopStartday, "yyyyMMdd") & "' AND '" & Format(dtLoopsEnDday, "yyyyMMdd") & "' AND EmpID In ('" & StrEmpAll & "')")
        If chkEditSelect.CheckState = CheckState.Unchecked Then
            If bolEx = True Then MsgBox("Found Attendance Information, Please Run Individually", MsgBoxStyle.Critical) : Exit Sub
        End If

        Dim dgvAllDays As New DataGridView
        With dgvAllDays
            .Columns.Add("aDate", "aDate")
            .Columns.Add("cYear", "cYear")
            .Columns.Add("cMonth", "cMonth")
        End With

        If chkEditSelect.CheckState = CheckState.Checked Then
            Load_InformationtoGrid("SELECT Date,cYear,cMonth FROM tblCalendar WHERE [Date] Between '" & Format(dtSelectedDate, "yyyyMMdd") & "' AND '" & Format(dtSelectedDate, "yyyyMMdd") & "' Order By [Date]", dgvAllDays, 3)
        Else
            Load_InformationtoGrid("SELECT Date,cYear,cMonth FROM tblCalendar WHERE [Date] Between '" & Format(dtLoopStartday, "yyyyMMdd") & "' AND '" & Format(dtLoopsEnDday, "yyyyMMdd") & "' Order By [Date]", dgvAllDays, 3)
        End If

        'Get the All Employee Who Assigned for the Shift

        'Add new datagrid view to the system
        Dim dgvSum As New DataGridView
        With dgvSum
            .Columns.Clear()
            .Columns.Add("atDate", "atdate")
            .Columns.Add("ShNumber", "Shift Number")
            .Columns.Add("shiftID", "Shift ID")
        End With

        Dim sqlQRY As String = ""
        'Read the 
        Dim inShift As Integer = 0
        Dim dtDate As Date
        Dim StrShift As String = ""
        Dim StrAddShift As String = ""
        Dim iRow As Integer
        If chkEditSelect.CheckState = CheckState.Checked Then
            dgvLineShift.Rows.Clear()
            StrAddShift = StrSelectShift
            Dim nameArray As String() = StrAddShift.Split("|")
            Dim initials As String = String.Empty
            inShift = 0
            For Each name As String In nameArray
                StrShift = name.ToString
                inShift = inShift + 1
                dgvLineShift.Rows.Add(inShift.ToString, dtSelectedDate, StrShift)
            Next
            'Update All Shifts to the EmpRegister table 
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET AllShifts = '" & StrAddShift & "' WHERE EmpID In ('" & StrEmpAll & "') AND AtDate = '" & Format(dtSelectedDate, "yyyyMMdd") & "'"
        Else
            With dgvShdule
                dgvLineShift.Rows.Clear()
                For iRow = 0 To .RowCount - 1
                    For iColumns As Integer = 1 To .ColumnCount - 1
                        dtDate = .Item(iColumns, iRow).Value
                        StrAddShift = .Item(iColumns + 1, iRow).Value
                        Dim nameArray As String() = StrAddShift.Split("|")
                        Dim initials As String = String.Empty
                        inShift = 0
                        For Each name As String In nameArray
                            StrShift = name.ToString
                            inShift = inShift + 1
                            dgvLineShift.Rows.Add(inShift.ToString, dtDate, StrShift)
                        Next
                        'Update All Shifts to the EmpRegister table 
                        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET AllShifts = '" & StrAddShift & "' WHERE EmpID In ('" & StrEmpAll & "') AND AtDate = '" & Format(dtDate, "yyyyMMdd") & "'"
                        iColumns = iColumns + 1
                    Next
                Next
            End With
        End If

        'Insert into the 
        'Create the midle table to keep the data and the date ranage employee information 
        Dim sqlTable As String

        sqlTable = "DROP TABLE tbltmpMidShift"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "CREATE TABLE tbltmpMidShift (EmpID Nvarchar (6),Atdate DateTime,ShiftNo Numeric (18,0),ShiftID Nvarchar (3))"
        FK_EQ(sqlTable, "S", "", False, False, False)

        With dgvLineShift
            For i As Integer = 0 To .RowCount - 1
                sqlQRY = sqlQRY & " INSERT INTO tbltmpMidShift SELECT EmpID,AtDate," & CInt(.Item(0, i).Value) & ",'" & .Item(2, i).Value & "' FROM tblEmpRegister WHERE EmpID In ('" & StrEmpAll & "') AND atDate = '" & Format(CDate(.Item(1, i).Value), "yyyyMMdd") & "'"
            Next
        End With

        'Edit Information for the Amangalla Resort 
        '01  - Delete tblGetInOut table for the loopStart Date and loopEndDate
        If chkEditSelect.CheckState = CheckState.Checked Then
            sqlQRY = sqlQRY & " DELETE FROM tblGetINOUT WHERE EmpID In ('" & StrEmpAll & "') AND AtDate Between '" & Format(dtSelectedDate, "yyyyMMdd") & "' AND '" & Format(dtSelectedDate, "yyyyMMdd") & "'"
        Else
            sqlQRY = sqlQRY & " DELETE FROM tblGetINOUT WHERE EmpID In ('" & StrEmpAll & "') AND AtDate Between '" & Format(dtLoopStartday, "yyyyMMdd") & "' AND '" & Format(dtLoopsEnDday, "yyyyMMdd") & "'"
        End If

        'Insert All Shift Details to the Generate Shift Table 
        sqlQRY = sqlQRY & " "
        'update selected roster to the employees 
        sqlQRY = sqlQRY & " UPDATE tblEmployee SET WrkCode = '" & StrOffDayShd & "',SorR = 1 WHERE RegID In ('" & StrEmpAll & "')"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.ShiftID = tbltmpMidShift.ShiftID,tblEmpRegister.ClockIn = tblSetShiftH.StartCIN,tblEmpRegister.ClockOut = tblSetShiftH.EndCOut FROM " & _
        " tbltmpMidShift INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = tbltmpMidShift.EmpID AND tblEmpRegister.AtDate = tbltmpMidShift.AtDate " & _
        " INNER JOIN tblSetShiftH ON tblSetShiftH.ShiftID = tbltmpMidShift.ShiftID"

        sqlQRY = sqlQRY & " insert into tblGetINOUT (EmpID,AtDate,AntStatus,ShiftID,InTime,OutDate,OutTime,sInTime,sOutTime,ClockIn,ClockOut," & _
        " WorkMin,LateMin,IsLate,EarlyMin,IsEarly,InUpdate,OutUpdate,mInUpdate,mOutUpdate,BOTMin,EOTMin,OTMin) select tbltmpMidShift.EmpID, " & _
        " tbltmpMidShift.AtDate,0,tbltmpMidShift.ShiftID,'','','',tbltmpMidShift.AtDate+tblSetShiftH.InTime, " & _
        " CASE tblSetShiftH.ShiftMode WHEN 0 THEN tbltmpMidShift.AtDate+tblSetShiftH.OutTime ELSE (dateAdd(day,1,tbltmpMidShift.AtDate)+tblSetShiftH.OutTime) END, " & _
        " tbltmpMidShift.AtDate+tblSetShiftH.StartCIN,CASE tblSetShiftH.ShiftMode WHEN 0 THEN tbltmpMidShift.AtDate+tblSetShiftH.EndCOUT ELSE (dateAdd(day,1,tbltmpMidShift.AtDate)+tblSetShiftH.EndCOUT) END, " & _
        " 0,0,0,0,0,0,0,0,0,0,0,0 FROM tbltmpMidShift INNER JOIN tblSetShiftH ON tbltmpMidShift.ShiftID = tblSetShiftH.ShiftID Order By tbltmpMidShift.EmpID,tbltmpMidShift.AtDate"

        'Generate Transaction ID
        Dim StrTrID As String = fk_GenSerial("SELECT NoTrs FROM tblControl", 10)
        Dim StrMess As String = "Edit Shift for " & cmbMonth.Text & " of " & Replace(Replace(StrEmpAll, ",", "|"), "'", "") & " Employee"
        sqlQRY = sqlQRY & " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES ('" & StrTrID & "', " & _
        " '" & Format(dtWorkingDate, "yyyyMMdd") & "','" & Me.Name & "','NF','" & StrMess & "', '" & StrUserID & "',0,0,'')"
        sqlQRY = sqlQRY & " UPDATE tblControl SET NoTrs = NoTrs + 1"

        FK_EQ(sqlQRY, "P", "", False, True, True)

    End Sub

    Private Sub dgvEmployee_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEmployee.DoubleClick

        'Get the Employee register number and shift information 
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlQRY As String = "SELECT * FROM tblEmployee WHERE RegID = '" & dgvEmployee.Item(1, dgvEmployee.CurrentRow.Index).Value & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlQRY, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            If drOpn.Read = True Then
                StrEmployeeID = IIf(IsDBNull(drOpn.Item("RegID")), "", drOpn.Item("RegID"))
                StrOffDayShd = IIf(IsDBNull(drOpn.Item("WrkCode")), "", drOpn.Item("WrkCode"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try
        'Get the Selected Shift OFf day Name
        StrChgMode = "01"
        cmbWorkDay.Text = fk_RetString("SELECT shdName FROM tblWkSheduleH WHERE shdID = '" & StrOffDayShd & "'")
        If StrOffDayShd = "" Then ret_days() : Exit Sub : cmbWorkDay.SelectedIndex = 0 : StrChgMode = "00"
        Dim q1 As String = "select tblEmpRegister.AtDate As Date,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblDayType.ClrA,tblDayType.ClrR,tblDayType.ClrG,tblDayType.ClrB,tblDayType.WorkUnit From tblEmpRegister INNER JOIN tblCalendar ON tblCalendar.Date = tblEmpRegister.AtDate INNER JOIN tblWKSheduleD ON tblCalendar.DayLink = tblWkSheduleD.DayID " & _
        " INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblWkSheduleD.ShdID = '" & StrOffDayShd & "' AND tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate "
        Dim q2 As String = "  Order By tblEmpRegister.AtDate"
        Load_Days(q1, q2)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cmbDayType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDayType.SelectedIndexChanged

        StrDTypeID = fk_RetString("SELECT TypeID FROM tblDayType WHERE typeName = '" & cmbDayType.Text & "'")

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        'Get the Selected Employess
        StrEmpAll = ""
        'Add to New grid shift effecting employees 
        Dim dgvEmpUps As New DataGridView
        With dgvEmpUps
        End With
        With dgvEmployee
            For i As Integer = 0 To .RowCount - 1
                If .Item(0, i).Value = True Then If StrEmpAll = "" Then StrEmpAll = .Item(1, i).Value Else StrEmpAll = StrEmpAll & "','" & .Item(1, i).Value
            Next
        End With

        If StrEmpAll = "" Then MsgBox("Please Select the Employee", MsgBoxStyle.Information) : Exit Sub

        If MsgBox("Do you want to change the Day Type of " & Format(dtSelectedDate, "yyyy-MM-dd") & " As " & cmbDayType.Text & " ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblEmpRegister SET DayTypeID = '" & StrDTypeID & "' WHERE EmpID In ('" & StrEmpAll & "') AND AtDate = '" & Format(dtSelectedDate, "yyyyMMdd") & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)

    End Sub

    Private Sub cmdEditOffDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditOffDay.Click

        Dim dtYearStart As Date = DateSerial(1900, 1, 1) : Dim dtYearEnd As Date = DateSerial(1900, 1, 1)
        dtYearStart = DateSerial(intYear, 1, 1) : dtYearEnd = DateSerial(intYear, 12, 31)
        StrOffDayShd = fk_RetString("SELECT ShdID FROM tblWKSheduleH WHERE shdName = '" & cmbWorkDay.Text & "'")
        If StrOffDayShd = "" Then MsgBox("Please select the Off day Pattern", MsgBoxStyle.Information) : Exit Sub
        With dgvEmployee
            For i As Integer = 0 To .RowCount - 1
                If .Item(3, i).Value = True Then If StrEmpAll = "" Then StrEmpAll = .Item(0, i).Value Else StrEmpAll = StrEmpAll & "','" & .Item(0, i).Value
            Next
        End With

        If StrEmpAll = "" Then MsgBox("Please Select the Employee", MsgBoxStyle.Information) : Exit Sub

        Dim sqlQRY As String = " UPDATE tblEmployee SET WrkCode = '" & StrOffDayShd & "' WHERE RegID in ('" & StrEmpAll & "')"
        FK_EQ(sqlQRY, "S", "", False, False, True)
        'Sync the Calendar
        sqlQRY = "CREATE TABLE #tblRosterUps (EmpID Nvarchar (6),AtDate DateTime,OldDayType Nvarchar (2),DayLink Numeric (18,0),NewDayType Nvarchar (2))"
        sqlQRY = sqlQRY & " INSERT INTO #tblRosterUps select tblEmpREgister.EmpID,tblEmpRegister.AtDate,tblEMpRegister.DayTypeID,tblCalendar.DayLink,tblWkSheduleD.DayTYpeID As NewDayType from tblEmpREgister INNER JOIN tblCalendar ON tblEmpRegister.AtDate = tblCalendar.Date INNER JOIN tblWkSheduleD ON tblCalendar.DayLink = tblWkSheduleD.DayID where tblEmpRegister.EmpID  In ('" & StrEmpAll & "') AND tblWkSheduleD.ShdID = '" & StrOffDayShd & "' AND tblEmpRegister.AtDate Between  '" & Format(dtYearStart, "yyyyMMdd") & "' AND '" & Format(dtYearEnd, "yyyyMMdd") & "'"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DayTypeID = #tblRosterUps.NewDayType FROM #tblRosterUps INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = #tblRosterUps.EmpID AND tblEmpRegister.AtDate = #tblRosterUps.AtDate "
        FK_EQ(sqlQRY, "S", "", False, True, True)

    End Sub

    Private Sub chkCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheck.CheckedChanged

        Dim iRw As Integer

        With dgvEmployee

            For iRw = 0 To .RowCount - 1

                If chkCheck.CheckState = CheckState.Checked Then

                    .Item(0, iRw).Value = True

                Else

                    .Item(0, iRw).Value = False

                End If

            Next

        End With

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

    Private Sub cmbWrkCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWrkCode.SelectedIndexChanged
        StrOffDayShd = fk_RetString("SELECT ShdID FROM tblWkSheduleH WHERE ShdName = '" & cmbWrkCode.Text & "'")
    End Sub

End Class