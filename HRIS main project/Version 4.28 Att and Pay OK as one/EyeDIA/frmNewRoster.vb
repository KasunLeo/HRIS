Public Class frmNewRoster

    Dim dtLongString As String = "" : Dim StrAllColumn As String = "" ' All Column List
    Dim intNoDay As Integer : Dim StrSelShiftID As String = "" : Dim intTabSelected As Integer = 0
    Dim StrEmpAll As String = ""
    Dim bolOK As Boolean = False
    Dim intload As Integer = 0
    Dim MaxmunMonthEndDate As DateTime

    Private Sub frmNewRoster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        strKEmployeeID = ""
    End Sub

    Private Sub frmNewRoster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Edit tblEmpRegister to Keep,Work Summary String 
        CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)

        cmdRefresh_Click(sender, e)
        'If strKEmployeeID <> "" Then
        '    txtSearch.Text = strKEmployeeID
        'End If
        'strKEmployeeID = ""
        'txtSearch.Text = cmbDept.
        intload = 1
        pnlLeft.Width = 0

        DateTimePickerMinDateControl()

    End Sub

    Private Sub DateTimePickerMinDateControl()
        '2018-08-03 DateTimePicker MinDate Control -prasanna
        Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lRoster = 1  )")
        Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lRoster = 1  )")

        MaxmunMonthEndDate = New DateTime(maxYear, maxMonth, 1).AddDays(-1)

        '  dtpFrDate.MinDate = New DateTime(maxYear, maxMonth, 1)
        '  dtpToDate.MinDate = New DateTime(maxYear, maxMonth, 1)
    End Sub


    Public Sub EmployeeSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesig.Text = "[ALL]", "", cmbDesig.Text)
        Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", cmbBranch.Text)
        Dim StrTypeName As String = IIf(cmbType.Text = "[ALL]", "", cmbType.Text)
        Dim StrTitleName As String = IIf(cmbTitle.Text = "[ALL]", "", cmbTitle.Text)

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else If IsEpf = 2 Then sqlTag = "tblEmployee.enrolNo" Else sqlTag = "tblEmployee.EmpNo"

        Dim sqlQry As String = "select  dbo.tblEmployee.RegID,RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as 'EmpNO', dbo.tblEmployee.dispName," & _
        " dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName INTO tblTRun FROM dbo.tblEmployee " & _
        " LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        " LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        " LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID " & _
        " LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID " & _
        " LEFT OUTER JOIN dbo.tblSetTitle ON dbo.tblSetTitle.titleID=dbo.tblemployee.TitleID " & _
        " LEFT OUTER JOIN dbo.tblSEtEmpCategory ON dbo.tblSEtEmpCategory.CatID=dbo.tblEmployee.CatID " & _
        " WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9  AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND (" & sqlTag & " LIKE '%" & txtSearch.Text & "%'  OR " & _
        " dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.EmpNo LIKE '%" & txtSearch.Text & "%') AND (" & _
        " dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND " & _
        " dbo.tblSetDept.DeptName LIKE '" & StrDeptname & "%' AND " & _
        " dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND " & _
        " dbo.tblSetEmpType.tDesc LIKE '" & StrTypeName & "%' AND " & _
        " dbo.tblSEtEmpCategory.CatDesc LIKE '" & StrCatName & "%') " & _
        " order by " & sqlTag & ""

        Dim strQuery As String = "select  dbo.tblEmployee.RegID,RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as 'EmpNO', dbo.tblEmployee.dispName," & _
        "dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 FROM dbo.tblEmployee " & _
        "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID " & _
        "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID " & _
        "LEFT OUTER JOIN dbo.tblSetTitle ON dbo.tblSetTitle.titleID=dbo.tblemployee.TitleID " & _
        "LEFT OUTER JOIN dbo.tblSEtEmpCategory ON dbo.tblSEtEmpCategory.CatID=dbo.tblEmployee.CatID " & _
        "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  AND (" & sqlTag1 & " LIKE '" & txtSearch.Text & "%' OR " & _
        "dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.EmpNo LIKE '%" & txtSearch.Text & "%') AND " & _
        "( dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%'  OR  " & _
        "dbo.tblSetDept.DeptName LIKE '" & StrDeptname & "%' OR " & _
        "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' OR " & _
        "dbo.tblSetEmpType.tDesc LIKE '" & StrTypeName & "%' OR " & _
        "dbo.tblSetTitle.titleDesc LIKE '" & StrTitleName & "%' OR " & _
        "dbo.tblSEtEmpCategory.CatDesc LIKE '" & StrCatName & "%') " & _
        "order by " & sqlTag & ""

        Load_InformationtoGrid(strQuery, dgvEmployee, 3)
        'clr_Grid(dgvEmployee)

        GroupBox3.Text = "Roster Review of " & dgvEmployee.RowCount & " Selected Employee(s) "
        fk_CreateTblStructure(sqlQry, dtpFrDate.Value, dtpToDate.Value)
    End Sub

    Public Function fk_CreateTblStructure(ByVal sqlTable As String, ByVal dtstart As Date, ByVal dtEnd As Date) As Boolean
        Dim sqlQRY As String = ""
        sqlQRY = "DROP TABLE tblTRun" : FK_EQ(sqlQRY, "S", "", False, False, False) : FK_EQ(sqlTable, "S", "", False, False, False)
        Dim StrColName As String = ""
        Dim dtRun As Date = DateAdd(DateInterval.Day, -1, dtstart) : Dim dtRunString As String = ""
        sqlQRY = ""
        intNoDay = DateDiff(DateInterval.Day, dtstart, dtEnd)
        StrAllColumn = ""
        For i As Integer = 0 To intNoDay
            dtRun = dtRun.AddDays(1)
            dtRunString = "D" & Format(dtRun, "yyyyMMdd")
            sqlQRY = " ALTER TABLE tblTRun ADD " & dtRunString & " Nvarchar (50) NOT NULL Default ''" : FK_EQ(sqlQRY, "S", "", False, False, True)
            fk_RetriveShifttoTemp(dtRun, dtRunString)
            StrAllColumn = StrAllColumn & "," & dtRunString
        Next
    End Function

    'Get the Shift ID from tblEmpRegister table and update the tblTRun
    Public Function fk_RetriveShifttoTemp(ByVal dtpDate As Date, ByVal StrColName As String) As Boolean
        Dim sqlQRY As String = ""
        sqlQRY = "DROP TABLE tblTMain" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "CREATE TABLE tblTMain (EmpID Nvarchar (6),ShiftID Nvarchar(3),cColor Nvarchar (30),leaveID nvarchar (3),isLeave NUMERIC (18,0))"

        'SELECT tblTRun.RegID,tblEmpRegister.ShiftID  FROM tblEmpRegister,tblTRun WHERE tblEmpRegister.EmpID = tblTRun.RegID AND tblEmpRegister.AtDate

        sqlQRY = sqlQRY & " INSERT INTO tblTMain SELECT tblTRun.RegID,tblSetShiftH.ShortCode, (Convert(Nvarchar(3),tblDayType.ClrA)+'.'+Convert(Nvarchar(3),tblDayType.ClrR)+'.'+Convert(Nvarchar(3),tblDayType.ClrG)+'.'+Convert(Nvarchar(3),tblDayType.ClrB)),tblEmpRegister.leaveID,tblEmpRegister.isLeave FROM tblEmpRegister,tblTRun,tblSetShiftH,tblDayType WHERE tblEmpRegister.EmpID = tblTRun.RegID AND tblSetShiftH.ShiftID = tblEmpRegister.allShifts AND tblEmpRegister.DayTypeID =  tblDayType.TypeID AND tblEmpRegister.AtDate  = '" & Format(dtpDate, "yyyyMMdd") & "'"
        sqlQRY = sqlQRY & " UPDATE tblTmain SET tblTmain.shiftID=tblLeaveType.shortCode FROM tblLeaveType,tblTmain WHERE tblLeaveType.lvID=tblTmain.leaveID AND tblTmain.isLeave=1"
        sqlQRY = sqlQRY & " UPDATE tblTRun SET tblTRun." & StrColName & " = tblTMain.ShiftID FROM tblTMain,tblTrun WHERE tblTMain.EmpID = tblTRun.RegID "

        FK_EQ(sqlQRY, "S", "", False, False, True)
    End Function

    Public Sub Color_GridwithDayType()
        Dim StrCname As String : Dim dtRDate As Date
        With dgvEmployee
            For i As Integer = 3 To .ColumnCount - 1
                StrCname = .Columns(i).Name
                dtRDate = CDate(StrCname)
                fk_RetriveColorTemp(dtRDate, StrCname)
            Next
        End With
    End Sub

    Public Function fk_RetriveColorTemp(ByVal dtpDate As Date, ByVal StrColName As String) As Boolean
        Dim StrGenError As String = "N"
        Dim sqlQRY As String = ""
        Dim intClrA As Integer = 0 : Dim intClrR As Integer = 0 : Dim intClrG As Integer = 0 : Dim intClrB As Integer = 0
        sqlQRY = "DROP TABLE tblTMain" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "CREATE TABLE tblTMain (EmpID Nvarchar (6),ShiftID Nvarchar(3),cColor Nvarchar (30))"
        Dim StrColor As String = ""
        'SELECT tblTRun.RegID,tblEmpRegister.ShiftID  FROM tblEmpRegister,tblTRun WHERE tblEmpRegister.EmpID = tblTRun.RegID AND tblEmpRegister.AtDate
        sqlQRY = sqlQRY & " INSERT INTO tblTMain SELECT tblTRun.RegID,tblSetShiftH.ShortCode, (Convert(Nvarchar(3),tblDayType.ClrA)+'.'+Convert(Nvarchar(3),tblDayType.ClrR)+'.'+Convert(Nvarchar(3),tblDayType.ClrG)+'.'+Convert(Nvarchar(3),tblDayType.ClrB)) FROM tblEmpRegister,tblTRun,tblSetShiftH,tblDayType WHERE tblEmpRegister.EmpID = tblTRun.RegID AND tblSetShiftH.ShiftID = tblEmpRegister.ShiftID AND tblEmpRegister.DayTypeID =  tblDayType.TypeID AND tblEmpRegister.AtDate  = '" & Format(dtpDate, "yyyyMMdd") & "'"
        Dim StrEmp As String = ""
        Dim iValue As Integer = 0
        Try
            FK_EQ(sqlQRY, "S", "", False, False, True)
            With dgvEmployee
                For i As Integer = 0 To .RowCount - 1
                    StrEmp = .Item(0, i).Value
                    StrColor = fk_RetString("SELECT cColor FROM tblTMain WHERE EmpID = '" & StrEmp & "'")
                    Dim nameArray As String() = StrColor.Split(".")
                    iValue = 0
                    Dim initials As String = String.Empty
                    For Each name As String In nameArray
                        initials = name
                        Select Case iValue
                            Case 0
                                intClrA = CInt(name)
                            Case 1
                                intClrR = CInt(name)
                            Case 2
                                intClrG = CInt(name)
                            Case 3
                                intClrB = CInt(name)
                        End Select
                        iValue = iValue + 1
                    Next
                    .Item(StrColName, i).Style.BackColor = Color.FromArgb(intClrA, intClrR, intClrG, intClrB)
                Next

            End With
        Catch ex As Exception
            StrGenError = "Y"

        End Try

        'If StrGenError = "Y" Then MsgBox("System Found Days without Assing Shifts", MsgBoxStyle.Information)
    End Function

    Public Function fk_CreateGrdStructure(ByVal dtStart As Date, ByVal dtEnd As Date) As Boolean
        'Clear All the Columns before create the table
        With dgvEmployee
            .Columns.Clear()
            .Columns.Add("EmpID", "Employee ID") : .Columns(0).Visible = False : .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Columns.Add("RelID", "Emp ID") : .Columns(1).Width = 50 '57
            .Columns.Add("EmpName", "Name") : .Columns(2).Width = 130 '148
        End With
        EmployeeSearch()

        Dim intDay As Integer = 0 : Dim dtRunString As String = ""
        intDay = DateDiff(DateInterval.Day, dtStart, dtEnd) + 1
        Dim dtRun As Date
        dtRun = dtStart
        dtRunString = Format(dtRun, "M/dd")
        dtLongString = Format(dtRun, "dd/MMM/yyyy")
        Dim intColNumber As Integer
        dgvEmployee.RowTemplate.Height = 30

        '20180907 prasanna change datagrdvew font size
        dgvEmployee.DefaultCellStyle.Font = New Font("Verdana", 6, FontStyle.Bold, GraphicsUnit.Point)
        dgvEmployee.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 6)

        For i As Integer = 1 To intDay
            intColNumber = i + 2
            dgvEmployee.Columns.Add(dtLongString, dtRunString)
            dgvEmployee.Columns(intColNumber).ReadOnly = True
            dtRun = dtRun.AddDays(1)
            dtRunString = Format(dtRun, "M/dd")
            dtLongString = Format(dtRun, "dd/MMM/yyyy")

            '20180907 prasanna change datagrdvew coloum  size oldsize 42
            dgvEmployee.Columns(intColNumber).Width = 32 '42
        Next


        'Load Information to the GRID
        Dim sqlQ As String
        sqlQ = "SELECT RegID,EmpNO,dispName " & StrAllColumn & " FROM tblTRun Order By EmpNO"
        Dim intAllCol As Integer = 3 + intDay
        Load_InformationtoGrid(sqlQ, dgvEmployee, intAllCol)
        'clr_Grid(dgvEmployee)
        Dim intA As Integer = dgvEmployee.ColumnCount
        GroupBox3.Text = "Roster Review of " & dgvEmployee.RowCount & " Selected Employee(s)"
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        fk_CreateGrdStructure(dtpFrDate.Value, dtpToDate.Value)
        Color_GridwithDayType()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If intload = 1 Then
            If txtSearch.Text.Length Mod 6 = 0 Then
                Button1_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        If intload = 1 Then

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        If intload = 1 Then

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub cmbDesig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesig.SelectedIndexChanged
        If intload = 1 Then

            Button1_Click(sender, e)

        End If
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        If intload = 1 Then

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        If intload = 1 Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub cmbTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTitle.SelectedIndexChanged
        If intload = 1 Then

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub dgvEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEmployee.Click
        If dgvEmployee.RowCount > 0 Then
            strKEmployeeID = dgvEmployee.CurrentRow.Cells(0).Value
            dtKfrDate = dtpFrDate.Value.Date
            dtKtoDate = dtpToDate.Value.Date
        End If
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

    Public Function fk_SaveSelectedShift(ByVal StrnEmpID As String, ByVal strAllDate As String, ByVal StrnShiftID As String, ByVal intWatSave As Integer) As Boolean
        Dim sqlQRY As String
        'Check Approved Options
        Dim bolAllw As Boolean = False
        sSQL = "SELECT * FROM tblEmpRegister WHERE EmpID = '" & StrnEmpID & "' AND AtDate in  (" & strAllDate & ") AND rOption = 2"
        bolAllw = fk_CheckEx(sSQL)
        If bolAllw = True Then MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Function

        If intRosterOpt <= 1 Then
            MsgBox("You can't change the approved roster details", MsgBoxStyle.Critical) : Exit Function
        End If

        Select Case intWatSave
            Case 0
                StrnShiftID = fk_ReturnShiftID(StrnShiftID)
                sqlQRY = "UPDATE tblEmpRegister SET AllShifts = '" & StrnShiftID & "' WHERE EmpID = '" & StrnEmpID & "' AND AtDate in (" & strAllDate & ");  INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Change Employee Roster of  " & StrnEmpID & " to shift " & StrnShiftID & " of days " & Replace(strAllDate, "'", "") & "' ,'" & StrUserID & "',getdate ())"
                If FK_EQ(sqlQRY, "S", "", False, False, True) = True Then
                    bolOK = True
                Else
                    bolOK = False
                End If
            Case 1
                sqlQRY = "UPDATE tblEmpRegister SET DayTypeID = '" & StrnShiftID & "' WHERE EmpID = '" & StrnEmpID & "' AND AtDate in (" & strAllDate & ");  INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Change Employee Day Type of  " & StrnEmpID & " to Type " & StrnShiftID & " of days " & Replace(strAllDate, "'", "") & "' ,'" & StrUserID & "',getdate ())"
                If FK_EQ(sqlQRY, "S", "", False, False, True) = True Then
                    bolOK = True
                Else
                    bolOK = False
                End If
                'Color Cell
        End Select

    End Function

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        ListComboAll(cmbDept, "SELECT * FROM tblSetDept WHERE deptID in ('" & StrUserLvDept & "') AND Status = 0  Order By DeptID", "deptName")
        ListComboAll(cmbCat, "SELECT * FROM tblSetEmpCategory WHERE status = 0 Order By CatID", "CatDesc")
        ListComboAll(cmbDesig, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "DesgDesc")
        ListCombo(cmbWorkDay, "SELECT * FROM tblWkSheduleH WHERE Status = 0 Order By ShdID", "ShdName")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] WHERE brID IN ('" & StrUserLvBranch & "') order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")
        ListCombo(cmbDayType, "SELECT * FROM tblDayType WHERE Status = 0 Order By TypeID", "TypeName")

        Dim sqlTable As String = ""
        sqlTable = "SELECT ShiftID,ShortCode,Shiftname,cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,InTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar),cast(REPLACE(REPLACE(RIGHT('0'+LTRIM(RIGHT(CONVERT(varchar,OutTime,100),7)),7),'AM',' AM'),'PM',' PM') as varchar) FROM tblSetShiftH WHERE shiftID IN ('" & StrUserLvShifts & "') AND Status =  0 Order by ShiftID"
        Load_InformationtoGrid(sqlTable, dgvCrShifts, 5)

        clr_Grid(dgvCrShifts)
        sqlTable = "select typeId,TypeName,Clra,clrr,clrg,clrb from tblDayType where status = 0 order by typeid "
        Load_InformationtoGrid(sqlTable, dgvType, 6)
        Dim iCol As Integer = 0
        With dgvType
            For Each row As DataGridViewRow In .Rows

                row.DefaultCellStyle.BackColor = Color.FromArgb(CInt(.Item(2, iCol).Value), CInt(.Item(3, iCol).Value), CInt(.Item(4, iCol).Value), CInt(.Item(5, iCol).Value))
                iCol = iCol + 1
            Next
        End With

        dtpFrDate.Value = DateSerial(Now.Year, Now.Month, 1)
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpFrDate.Value)
        ' dtpToDate.Value = DateAdd(DateInterval.Day, -1, dtpToDate.Value)

        'cmbDept.SelectedIndex = 1
        rdbDay.Checked = True
        'strKEmployeeID = ""
        'Dim strRID As String = fk_RetString("select min(regid) from tblemployee where empstatus<>9 ")
        'txtSearch.Text = strRID
        cmbDept.SelectedIndex = 1
    End Sub

    Private Sub dgvCrShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCrShifts.Click
        StrSelShiftID = dgvCrShifts.Item(1, dgvCrShifts.CurrentRow.Index).Value
        lblShift.Text = "Selected shift is : " & dgvCrShifts.Item(2, dgvCrShifts.CurrentRow.Index).Value
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        intTabSelected = TabControl1.SelectedIndex
        'intSelecTab = TabControl1.SelectedIndex
        StrSelShiftID = ""
    End Sub

    Private Sub cmbDayType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDayType.SelectedIndexChanged
        StrSelShiftID = fk_RetString("SELECT TypeID FROM tblDayType WHERE typeName = '" & cmbDayType.Text & "'")

    End Sub

    Private Sub dgvType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvType.Click
        Try
            StrSelShiftID = dgvType.Item(0, dgvType.CurrentRow.Index).Value
            lblC.BackColor = Color.FromArgb(CInt(dgvType.Item(2, dgvType.CurrentRow.Index).Value), dgvType.Item(3, dgvType.CurrentRow.Index).Value, dgvType.Item(4, dgvType.CurrentRow.Index).Value, dgvType.Item(5, dgvType.CurrentRow.Index).Value)
            lblShift.Text = "Selected Day Type is : " & dgvType.Item(1, dgvType.CurrentRow.Index).Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub loadSearch()
        If rdbDay.Checked = True Then
            intSelecTab = 1
        ElseIf rdbShift.Checked = True Then
            intSelecTab = 2
        ElseIf rdbDayAndShift.Checked = True Then
            intSelecTab = 3
        End If

        If pnlLeft.Width = 0 Then
            pnlLeft.Width = 406
            Me.pnlLeft.Controls.Clear()
            Dim frmReg As New frmCopyNewRoster
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlLeft.Controls.Add(frmReg)
            frmReg.Show()
            'Button1_Click(sender, e)

        ElseIf pnlLeft.Width = 406 Then
            pnlLeft.Width = 0
        End If
    End Sub

    Private Sub cmdConfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfirm.Click
        loadSearch()
    End Sub

    'Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
    '    StrEmpAll = fk_getGridCLICK(dgvEmployee, 0, 0)
    '    StrEmpAll = fk_SplitToSQL_in(StrEmpAll)
    '    If intRosterOpt > 1 Then
    '        'Check Un confirmed Shifts
    '        Dim bolExp As Boolean = False
    '        Dim intSvOpt As Integer = 0
    '        bolExp = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE EmpID In ('" & StrEmpAll & "') AND rOption = 0")
    '        If bolExp = True Then
    '            If MsgBox("System found some un-confirm roster details, do you want to approve all,press YES or only confirms press NO", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Question) Then
    '                If MsgBoxResult.Yes Then
    '                    intSvOpt = 1
    '                ElseIf MsgBoxResult.No Then
    '                    intSvOpt = 2
    '                Else
    '                    intSvOpt = 0
    '                End If
    '            End If
    '        Else
    '            intSvOpt = 2
    '        End If
    '        If intSvOpt = 0 Then Exit Sub
    '        _svOption(2, intSvOpt)
    '    Else
    '        MsgBox("You don't have permission to approve the roster", MsgBoxStyle.Information) : Exit Sub

    '    End If
    'End Sub

    Public Sub _svOption(ByVal intROpt As Integer, ByVal svOption As Integer)
        Dim sqlQRY As String = ""

        Select Case intROpt
            Case 1 'Confirm Rosters
                sqlQRY = "UPDATE tblEmpRegister SET rOption = 1 WHERE EmpID in ('" & StrEmpAll & "')"
            Case 2 'Approve Rosters
                If svOption = 1 Then
                    sqlQRY = "UPDATE tblEmpRegister SET rOption = 2 WHERE EmpID in ('" & StrEmpAll & "') AND rOption = 1"
                Else
                    sqlQRY = "UPDATE tblEmpRegister SET rOption = 2 WHERE EmpID in ('" & StrEmpAll & "')"
                End If
        End Select
        FK_EQ(sqlQRY, "P", "", False, True, True)
    End Sub

    Private Sub dgvEmployee_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvEmployee.DoubleClick
        'Dim intRow As Integer : Dim intColumn As Integer : Dim strCellName As String
        'Dim StrcEmpID As String = "" : Dim dtcDate As Date
        'Try
        '    With dgvEmployee
        '        intRow = .CurrentRow.Index : intColumn = .CurrentCell.ColumnIndex
        '        strCellName = .Columns(intColumn).Name : dtcDate = strCellName
        '        StrcEmpID = .Item(0, intRow).Value
        '        If StrSelShiftID = "" Then MsgBox("Please select the Shift", MsgBoxStyle.Information) : Exit Sub
        '        If intTabSelected = 0 Then .Item(intColumn, intRow).Value = StrSelShiftID Else .Item(intColumn, intRow).Style.BackColor = lblC.BackColor
        '        fk_SaveSelectedShift(StrcEmpID, dtcDate, StrSelShiftID, intTabSelected)
        '    End With
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Try
            If dgvEmployee.RowCount > 0 Then
                strKEmployeeID = dgvEmployee.CurrentRow.Cells(0).Value
                dtKfrDate = dtpFrDate.Value.Date
                dtKtoDate = dtpToDate.Value.Date
            End If
            pnlLeft.Width = 406


            Me.pnlLeft.Controls.Clear()
            Dim frmReg As New frmCopyNewRoster
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlLeft.Controls.Add(frmReg)
            frmReg.Show()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub getSelectedArea()
        Dim selectedCellCount As Integer = _
        dgvEmployee.GetCellCount(DataGridViewElementStates.Selected)
        Dim intRow As Integer : Dim intColumn As Integer : Dim strCellName As String
        Dim StrcEmpID As String = "" : Dim dtDate As Date
        Dim strSelDate As String
        'Dim selectedRowCount As Integer = _
        'dgvEmployee.SelectedRows.Count
        Try
            If dgvEmployee.RowCount <= 0 Then Exit Sub
            Dim intCurrentRow As Integer = dgvEmployee.CurrentRow.Index
            If selectedCellCount > 0 Then

                If dgvEmployee.AreAllCellsSelected(True) Then
                    MessageBox.Show("All cells are selected", "Selected Cells")
                Else
                    strCellName = ""
                    Dim i As Integer
                    For i = 0 To selectedCellCount - 1

                        intRow = (dgvEmployee.SelectedCells(i).RowIndex _
                            .ToString())
                        intColumn = (dgvEmployee.SelectedCells(i).ColumnIndex _
                            .ToString())
                        If intColumn < 3 Then Exit Sub
                        dtDate = CDate(dgvEmployee.Columns(intColumn).Name)
                        strSelDate = Format(dtDate, "yyyyMMdd")
                        strCellName = strCellName & "'" & strSelDate & "'" & ","
                    Next i

                    strCellName = Microsoft.VisualBasic.Left(strCellName, strCellName.Length - 1)
                    StrcEmpID = dgvEmployee.CurrentRow.Cells(0).Value

                    '20180817 prasanna After month End Can't Change preview days roster 
                    If UserLevelID <> "000" Then
                        If dtDate <= MaxmunMonthEndDate Then MsgBox("Cant Change Roster : Your Last Month ('" & MaxmunMonthEndDate & "') Is Over  ", MsgBoxStyle.Information) : Exit Sub
                    End If
                    '-----------------

                    If StrSelShiftID = "" Then MsgBox("Please select the Shift", MsgBoxStyle.Information) : Exit Sub

                    fk_SaveSelectedShift(StrcEmpID, strCellName, StrSelShiftID, intTabSelected)

                    If bolOK = False Then Exit Sub

                    If intTabSelected = 0 Then
                        Dim k As Integer
                        For k = 0 To selectedCellCount - 1

                            intRow = (dgvEmployee.SelectedCells(k).RowIndex _
                                .ToString())
                            intColumn = (dgvEmployee.SelectedCells(k).ColumnIndex _
                                .ToString())
                            If intCurrentRow = intRow Then
                                dgvEmployee.Item(intColumn, intRow).Value = StrSelShiftID
                            End If
                        Next k

                    Else
                        Dim l As Integer
                        For l = 0 To selectedCellCount - 1

                            intRow = (dgvEmployee.SelectedCells(l).RowIndex _
                                .ToString())
                            intColumn = (dgvEmployee.SelectedCells(l).ColumnIndex _
                                .ToString())
                            If intCurrentRow = intRow Then
                                dgvEmployee.Item(intColumn, intRow).Style.BackColor = lblC.BackColor
                            End If
                            'dgvEmployee.Item(intColumn, intRow).Value = StrSelShiftID
                        Next l

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApprove.Click
        Dim sqlQRY As String = ""
    End Sub

    Private Sub dgvEmployee_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvEmployee.MouseUp
        getSelectedArea()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        StrSelShiftID = ""
        lblShift.Text = "Selected shift is None"
    End Sub

    Private Sub cmdShiftProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShiftProcess.Click
        'this will process attendance information 
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+ tblSetShiftH.StartCIN, tblEmpregister.ClockOUT = DateAdd(Day,tblSetShiftH.ShiftMode,tblEmpRegister.AtDate) + tblSetShiftH.EndCOUT FROM tblSetShiftH,tblEmpRegister WHERE tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND tblEmpRegister.AtDate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub rdbDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDay.MouseClick
        pnlLeft.Width = 0
        loadSearch()
    End Sub

    Private Sub rdbShift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbShift.MouseClick
        pnlLeft.Width = 0
        loadSearch()
    End Sub

    Private Sub rdbDayAndShift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDayAndShift.MouseClick
        'If rdbDayAndShift.Checked = True Then
        '    intSelecTab = 3
        '    LoadForm(New frmCopyNewRoster)
        'End If
        pnlLeft.Width = 0
        loadSearch()
    End Sub

    Private Sub rdbDay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDay.MouseClick
        'If rdbDay.Checked = True Then
        '    If intload <> 0 Then
        '        intSelecTab = 1
        '        LoadForm(New frmCopyNewRoster)
        '    End If

        'End If
        'intSelecTab = 1
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Button1_Click(sender, e)
    End Sub

    Private Sub dgvEmployee_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvEmployee.MouseClick
        If e.Button = MouseButtons.Right Then
            If pnlLeft.Width = 406 Then
                pnlLeft.Width = 0
            ElseIf pnlLeft.Width = 0 Then
                pnlLeft.Width = 406
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmMonthEndProcess.Show()
    End Sub
End Class