Imports System.Data.SqlClient
Imports HRISforBB.GlassTableGDI

Public Class frmShiftAsgn

    Dim StrCatID As String
    Dim StrDeptID As String
    Dim StrDsgID As String

    Dim catSel As String = "0"
    Dim DesgSel As String = "0"
    Dim DeptSel As String = "0"

    Dim StrSelShiftID As String = "001"
    Dim intShiftMode As Integer = 0

    Dim StrSelection As String


    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)

        ''Dim crtl As Control
        ''For Each crtl In Me.GroupBox2.Controls
        ''    If TypeOf crtl Is TextBox Then crtl.Text = " "
        ''Next
        'Load Information 
        ListComboAll(cmbDesg, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "desgDesc")
        'Load Department
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0 Order By DeptID", "deptName")
        'Load Category
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")

        ListCombo(cmbOffDay, "select * from tblWkSheduleH where status = 0 ORder by ShdID", "ShduName")

        'Load Shift
        Dim sqlQ As String = "select ShiftID,ShiftName,0 from tblSetShiftH WHERE status = 0 order By ShiftID"
        Load_InformationtoGrid(sqlQ, dgvShiftAvbl, 3)
        clr_Grid(dgvShiftAvbl)

        txtSearch.Text = "K"
        txtSearch.Text = ""
        dtpEffdate.Value = DateSerial(Now.Year, 1, 1)
        cmdFind_Click(sender, e)
        
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged

        txtSearch.Text = cmbCat.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
        ''StrCatID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbCat.Text & "'")
        ''txtSearch.Text = cmbCat.Text

    End Sub

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged

        txtSearch.Text = cmbDesg.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged

        txtSearch.Text = cmbDept.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

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

    ''    Public Sub Process_Search()

    ''        StrSelection = catSel & DesgSel & DeptSel
    ''        StrCatID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbCat.Text & "'")
    ''        StrDesgID = fk_RetString("SELECT desgID FROM tblDesig WHERE DesgDesc = '" & cmbDesg.Text & "'")
    ''        StrDeptID = fk_RetString("SELECT DeptID FROM tblSetDept WHERE DeptName = '" & cmbDept.Text & "'")
    ''        Dim sqlQRY As String = ""

    ''        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
    ''        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EpfNo" Else sqlTag = "tblEmployee.EnrolNo"

    ''        Select Case StrSelection
    ''            Case "000"
    ''                sqlQRY = "SELECT     'false',dbo.tblEmployee.RegID," & sqlTag & ", dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9"
    ''            Case "001"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ",dbo.tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DeptID = '" & StrDeptID & "'"
    ''            Case "011"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ",dbo.tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DeptID = '" & StrDeptID & "' AND tblEmployee.DesigID = '" & StrDesgID & "'"
    ''            Case "111"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ",dbo.tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DeptID = '" & StrDeptID & "' AND tblEmployee.DesigID = '" & StrDesgID & "' AND tblEmployee.CatID = '" & StrCatID & "'"
    ''            Case "110"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ",dbo.tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DesigID = '" & StrDesgID & "' AND tblEmployee.CatID = '" & StrCatID & "'"
    ''            Case "100"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ",dbo.tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.CatID = '" & StrCatID & "'"
    ''            Case "010"
    ''                sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ",dbo.tblEmployee.EpfNo, dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
    ''" FROM         dbo.tblEmployee INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID INNER JOIN " & _
    ''" dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.EmpStatus <> 9 AND tblEmployee.DesigID = '" & StrDesgID & "'"
    ''        End Select

    ''        sqlQRY = sqlQRY + " order by " & sqlTag & " "

    ''        Load_InformationtoGrid(sqlQRY, dgvEmps, 7)

    ''        lblCount.Text = "Total Employees : " & dgvEmps.RowCount

    ''        'If sqlQRY = "" Then Exit Sub

    ''        'Load_InformationtoGrid(sqlQRY, dgvEmps, 7)

    ''    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        'Process_Search()
    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor
    'End Sub

    Private Sub dgvShiftAvbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvShiftAvbl.Click

        If dgvShiftAvbl.RowCount = 0 Then Exit Sub

        StrSelShiftID = dgvShiftAvbl.Item(0, dgvShiftAvbl.CurrentRow.Index).Value

        For i As Integer = 0 To dgvEmps.RowCount - 1

            dgvEmps.Item(0, i).Value = False

        Next

        Dim cnSh As New SqlConnection(sqlConString)
        cnSh.Open()
        Dim sqlQ As String = "SELECT * FROM tblSetShiftH WHERE ShiftID = '" & StrSelShiftID & "'"
        Try
            Dim cmSh As New SqlCommand(sqlQ, cnSh)
            Dim drSh As SqlDataReader = cmSh.ExecuteReader

            If drSh.Read = True Then

                txtStTime.Text = Format(IIf(IsDBNull(drSh.Item("InTime")), "", drSh.Item("InTime")), "hh:mm tt")
                txtEdTime.Text = Format(IIf(IsDBNull(drSh.Item("OutTime")), "", drSh.Item("OutTime")), "hh:mm tt")
                intShiftMode = IIf(IsDBNull(drSh.Item("ShiftMode")), 0, drSh.Item("ShiftMode"))

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnSh.Close()
        End Try

        Dim iRws As Integer
        Dim StrEmp As String
        Dim bolEx As Boolean = False

        With dgvEmps

            For iRws = 0 To .RowCount - 1
                StrEmp = .Item(1, iRws).Value
                bolEx = fk_CheckEx("SELECT * FROM tblEmpShifts WHERE EmpID = '" & StrEmp & "' AND ShiftID = '" & StrSelShiftID & "' AND Status = 1 AND RorS = 0")
                For iCols As Integer = 0 To .ColumnCount - 1

                    If bolEx = True Then

                        .Item(iCols, iRws).Style.BackColor = Color.LightBlue 'Item(0, iRws).Value = True

                    Else

                        .Item(iCols, iRws).Style.BackColor = Color.White

                    End If


                Next

            Next

        End With

    End Sub

    Private Sub frmShiftAsgn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        If intisDeleteShift = 1 Then lnlbDeleteShift.Visible = True
        cmdRefresh_Click(sender, e)
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)
        pnlTopIcon.Height = 70

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Roster/ Shift", "Assign shift to employee(s)") = False Then Exit Sub
        Dim StrDefShiftID As String = ""
        StrDefShiftID = fk_RetString("SELECT DSID FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        Dim dgvShData As DataGridView
        dgvShData = New DataGridView
        'intOnShiftProcess = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")

        With dgvShData
            .Columns.Add("EmpID", "Employee ID")
            .Columns.Add("AtDate", "Attendance Date")
            .Columns.Add("DayTypeID", "Day Type ID")
            .Columns.Add("WrkUnit", "Work Unit")
            .Columns.Add("ShiftID", "Shift ID")

        End With
        Dim dtYrEndDate As Date = DateSerial(intCurrentYear, 12, 31)

        Dim sqlQ As String
        'Dim iERs As Integer 'Grid Rows
        'Dim StrEmpID As String 'Temporary Employee ID value
        'With dgvEmps
        '    For iERs = 0 To .RowCount - 1
        '        Dim bolSel As Boolean
        '        bolSel = .Item(0, iERs).Value
        '        StrEmpID = .Item(1, iERs).Value
        '        If bolSel = True Then



        '        End If
        '    Next
        'End With

        Dim StrShID As String
        Dim dtStart As Date
        Dim dtEnd As Date

        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlOpn As String = "SELECT * FROM tblSetShiftH WHERE ShiftName = '" & StrDefShiftID & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlOpn, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            If drOpn.Read = True Then
                StrShID = IIf(IsDBNull(drOpn.Item("ShiftID")), "", drOpn.Item("ShiftID"))
                dtStart = IIf(IsDBNull(drOpn.Item("InTime")), "19000101", drOpn.Item("InTime"))
                dtEnd = IIf(IsDBNull(drOpn.Item("OutTime")), "19000101", drOpn.Item("OutTime"))
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            cnOpn.Close()

        End Try

        Dim dtMonth As Integer = Month(dtpEffdate.Value)

        If txtEdTime.Text = "" Then
            MsgBox("No Shift selected", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim bolExAttn As Boolean
        Dim bolPic As Boolean
        With dgvEmps
            For irws As Integer = 0 To .RowCount - 1
                Dim iVal As Integer = .Item(6, irws).Value
                bolPic = .Item(0, irws).Value
                If bolPic = True Then
                    StrEmployeeID = .Item(1, irws).Value
                    bolExAttn = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE AntStatus = 1 AND AtDate between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "' AND EmpID = '" & StrEmployeeID & "'")
                    If bolExAttn = True Then MsgBox("You are not allowing Add Shift because attendance are exists", MsgBoxStyle.Information) : Exit Sub
                End If
            Next
        End With
        'intBaseOnClockRecord changed 1 to zero on 2018-03-17
        If intOnShiftProcess = 0 Then
            StrDefShiftID = StrSelShiftID
        End If

        pgb.Visible = True
        pgb.Minimum = 0
        Dim bolSelect As Boolean = False
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Dim iRws As Integer
            With dgvEmps
                pgb.Maximum = .RowCount - 1
                pgb.Value = 0
                For iRws = 0 To .RowCount - 1
                    Dim iVal As Integer = .Item(6, iRws).Value
                    bolSelect = .Item(0, iRws).Value
                    StrEmployeeID = .Item(1, iRws).Value
                    If bolSelect = True Then
                        pgb.Value = iRws
                        'Clear the Existing Shifts
                        sqlQRY = "UPDATE tblEmpShifts SET Status = 0 WHERE EmpID = '" & StrEmployeeID & "'"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()

                        'Insert new shift information to the system
                        sqlQRY = "INSERT INTO tblEmpSHifts (EmpID,ShiftID,AsgDate,Status,RorS) VALUES " & _
                        "('" & StrEmployeeID & "','" & StrSelShiftID & "','" & Format(dtWorkingDate, "yyyyMMdd") & "',1,0)"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()

                        sqlQRY = "DELETE FROM tblEmpRegister WHERE AtDate >= '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND empID = '" & StrEmployeeID & "'"
                        'Insert information from the Caleder 
                        sqlQRY = sqlQRY & " insert into tblEmpRegister (EmpID,CompID,cMonth,cYear,AtDate,InDate,InTime1,OutDate,OutTime1,InTime2,OutTime2," & _
                        " ShiftID,DayID,DayTypeID,sInTime,sOutTime,StrInTime,StrOutTime,AntStatus,WorkMins," & _
                        " WorkHrs,IsLate,LateMins,IsEarly,EarlyMins,IsLeave,LeaveID,NoLeave,IsoffdayWork,IsNightWork," & _
                        " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,Status,AllShifts)" & _
                        " Select '" & StrEmployeeID & "','" & StrCompID & "',cMonth,cYear,[date],'','','','','','','" & StrDefShiftID & "',DayID,daytype,'" & dtStart & "','" & dtEnd & "','','',0,0,0,0,0,0,0,0,'',0,0,0," & _
                        " 0,0,0,0,0,0,0,'" & StrSelShiftID & "' from tblCalendar WHERE [Date] between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "'"

                        sqlQRY = sqlQRY & " UPDATE tblEmployee SET WrkCode = '001' WHERE RegID = '" & StrEmployeeID & "'"
                        'sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET ShiftID = '999' WHERE DayTypeID = '02' AND EmpID = '" & StrEmployeeID & "'"
                        'Update shift In time & out time according toi the shift
                        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.sInTime = tblSetShiftH.InTime,tblEmpRegister.sOutTime = tblsetShiftH.OutTime FROM tblSetShiftH INNER JOIN tblEMpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE tblEmpRegister.AtDate >= '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND  tblEmpRegister.EmpID = '" & StrEmployeeID & "'"
                        'sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET AllShifts = ShiftID WHERE EmpID = '" & StrEmployeeID & "'"
                        sqlQRY = sqlQRY & " DELETE FROM tblGetInOut WHERE EmpID= '" & StrEmployeeID & "' AND AtDate Between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "'"
                        sqlQRY = sqlQRY & " INSERT INTO tblGetInOut " & _
            " (EmpID,AtDate,AntStatus,ShiftID,InTime,OutDate,OutTime,sInTime,sOutTime,ClockIn,ClockOut,WorkMin,LateMin,IsLate,EarlyMin,IsEarly, " & _
            " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BOTMin,EOTMin,OTMin,InDate,AtEdit,OTApved,ShiftLine,DayTypeID) " & _
        " SELECT EmpID,AtDate,AntStatus,ShiftID,InTime1,OutDate,OutTime1,sInTime,sOutTime,clockIn,ClockOut,WorkMins,LateMins,IsLate,EarlyMins,IsEarly, " & _
        " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,cOTMins,Indate,AtEdit,OTApved,0,DayTypeID FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate Between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "'"

                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()
                    End If

                    'Update tblEmpRegister (Attendance table for the shift from the period from effective date 

                    'When Update the Shift Mode it's Checking the Calendar File to Insert the Data.
                    '    If intShiftMode <> 2 Then 'When 24 HourShift is going other shift should be seperated
                    '        sqlQRY = "UPDATE tblEmpRegister SET ShiftID = '" & StrSelShiftID & "' WHERE EmpID = '" & StrEmployeeID & "' AND AtDate >= '" & Format(dtpEffdate.Value, "yyyyMMdd") & "'"
                    '        cmSave.CommandText = sqlQRY
                    '        cmSave.ExecuteNonQuery()


                    '    Else 'If 24 Hour Shift is going it need to assign one day off day
                    '        sqlQ = "select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.DayTypeID,tblDayType.WorkUnit,'' From tblEmpRegister " & _
                    '        " INNER JOIN tblEmployee On tblEmpRegister.EmpID = tblEmployee.RegID " & _
                    '        " INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate >= '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' " & _
                    '        " Order By tblEmpRegister.EmpID,tblEmpRegister.Atdate"

                    '        Load_InformationtoGrid(sqlQ, dgvShData, 4)
                    '        Dim iShR As Integer 'Shift Datagrid Raws value
                    '        Dim iAddShift As Integer = 1
                    '        Dim dtShiftDate As Date
                    '        With dgvShData
                    '            For iShR = 0 To .RowCount - 2
                    '                dtShiftDate = .Item(1, iShR).Value
                    '                If CDbl(.Item(3, iShR).Value) <> 0 Then
                    '                    If iAddShift = 1 Then
                    '                        .Item(4, iShR).Value = StrSelShiftID
                    '                        'Update Employee Register Table for the selected Values

                    '                        sqlQRY = "UPDATE tblEmpRegister SET ShiftID = '" & StrSelShiftID & "' WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtShiftDate, "yyyyMMdd") & "'"
                    '                        cmSave.CommandText = sqlQRY
                    '                        cmSave.ExecuteNonQuery()
                    '                        iAddShift = 0

                    '                    Else
                    '                        iAddShift = 1
                    '                        .Item(4, iShR).Value = "999" 'No Shift Assign (off Day)

                    '                        'Update the Employee Register Table for the selected values 
                    '                        sqlQRY = "UPDATE tblEmpRegister SET ShiftID = '999' WHERE EmpID = '" & StrEmployeeID & "' AND AtDate = '" & Format(dtShiftDate, "yyyyMMdd") & "'"
                    '                        cmSave.CommandText = sqlQRY
                    '                        cmSave.ExecuteNonQuery()
                    '                    End If

                    '                End If
                    '            Next
                    '        End With
                    '    End If


                    '    'Else
                    '    '    'Cancel Exisitng shift


                    '    '    sqlQRY = "UPDATE tblEmpShifts SET Status = 1 WHERE EmpID = '" & StrEmployeeID & "'"
                    '    '    cmSave.CommandText = sqlQRY
                    '    '    cmSave.ExecuteNonQuery()

                    'End If
                Next

                trSave.Commit()

                'Update ClockIn/ClockOut for the assign Shifts 
                Dim StrAllEmps As String = ""
                Dim dtYrEnd As Date
                dtYrEnd = DateSerial(intCurrentYear, 12, 31)
                StrAllEmps = fk_getGridCLICK(dgvEmps, 0, 1)
                StrAllEmps = fk_SplitToSQL_in(StrAllEmps)
                'sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN,tblEmpRegister.ClockOut = tblEmpRegister.Atdate + tblSetShiftH.EndCOUT FROM tblEMpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID  = tblSetShiftH.ShiftID AND tblEmpRegister.EmpID in ('" & StrAllEmps & "') AND tblEmpRegister.AtDate between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEnd, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

                sSQL = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+ tblSetShiftH.StartCIN, tblEmpregister.ClockOUT = DateAdd(Day,tblSetShiftH.ShiftMode,tblEmpRegister.AtDate) + tblSetShiftH.EndCOUT FROM tblSetShiftH,tblEmpRegister WHERE tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND tblEmpRegister.AtDate Between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEnd, "yyyyMMdd") & "'"
                FK_EQ(sSQL, "S", "", False, True, True)

                '20160128
                'sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblEmpRegister.AtDate+tblSetShiftH.StartCIN,tblEmpRegister.ClockOut = DateAdd(Day,tblSetShiftH.ShiftMode, tblEmpRegister.AtDate)+tblSetShiftH.EndCOut FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEnd, "yyyyMMdd") & "' AND tblEmpRegister.EmpID In ('" & StrAllEmps & "')" : FK_EQ(sqlQRY, "S", "", False, False, True)
                'MsgBox("Information Saved", MsgBoxStyle.Information)
                pgb.Visible = False
                'Update to shift ID to All Shifts 

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub chkCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheck.CheckedChanged

        'If chkCheck.CheckState = CheckState.Checked Then
        '    chkCheck.Text = "Un-Check All"
        'Else
        '    chkCheck.Text = "Check All"
        'End If

        Dim iRw As Integer
        With dgvEmps
            For iRw = 0 To .RowCount - 1
                If chkCheck.CheckState = CheckState.Checked Then
                    .Item(0, iRw).Value = True
                Else
                    .Item(0, iRw).Value = False
                End If

            Next

        End With

    End Sub

    Private Sub cmdPrintList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintList.Click

        strLoadReport = "rpt_ShiftInfo.rpt"
        StrSelectionFomula = "{tblEmpShifts.ShiftID}= '" & StrSelShiftID & "' AND {tblEmpShifts.RorS} =1 AND {tblEmpShifts.Status}=0"
        StrRepTitle = "Roster Information Report"
        StrRepFile = Application.StartupPath & "\Reports\" & strLoadReport
        Dim frmRep As New frmRepContainerAttn
        With frmRep
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With

    End Sub

    Private Sub cmdNoShiftEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNoShiftEmp.Click

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else sqlTag = "tblEmployee.enrolNo"

        Dim sqlQRY As String
        sqlQRY = "SELECT     'False',dbo.tblEmployee.RegID," & sqlTag & ", dbo.tblEmployee.dispName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 " & _
        " FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN " & _
        " dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID WHERE tblEmployee.RegID NOT IN (SELECT EmpID FROM tblEmpShifts WHERE Status = 1)"

        Load_InformationtoGrid(sqlQRY, dgvEmps, 6)
        clr_Grid(dgvEmps)
        lblCount.Text = "Total Employees : " & dgvEmps.RowCount

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        EmployeeSearch()
        ''Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        ''Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else sqlTag = "tblEmployee.enrolNo"

        ''Dim strQuery As String = "select  'false',dbo.tblEmployee.RegID,dbo." & sqlTag & ", dbo.tblEmployee.dispName," & _
        ''"dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 FROM dbo.tblEmployee " & _
        ''"INNER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        ''"INNER JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        ''"WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        ''"dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR " & _
        ''"dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR " & _
        ''"dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
        ''"dbo.tblEmployee.dispName LIKE '%" & txtSearch.Text & "%' OR " & _
        ''"dbo.tblDesig.desgDesc LIKE '%" & txtSearch.Text & "%' OR " & _
        ''"dbo.tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%') " & _
        ''"order by " & sqlTag & ""

        ''Load_InformationtoGrid(strQuery, dgvEmps, 7)

        ''lblCount.Text = "Total Employees : " & dgvEmps.RowCount

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
        "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <>9 AND isShifed=0 AND tblEmployee.DeptID In ('" & StrUserLvDept & "') AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
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

        lblCount.Text = "Total Employees : " & dgvEmps.RowCount

    End Sub

    Private Sub chkAssigned_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAssigned.CheckedChanged

        If chkAssigned.CheckState = CheckState.Checked Then

            cmdNoShiftEmp_Click(sender, e)

        Else

            EmployeeSearch()

        End If

    End Sub

    Private Sub dgvShiftAvbl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvShiftAvbl.DoubleClick

        Dim StrEmp As String
        Dim bolEx As Boolean = False

        With dgvEmps

            For iRws = 0 To .RowCount - 1
                StrEmp = .Item(1, iRws).Value
                bolEx = fk_CheckEx("SELECT * FROM tblEmpShifts WHERE EmpID = '" & StrEmp & "' AND ShiftID = '" & StrSelShiftID & "' AND Status = 1 AND RorS = 0")

                For iCols As Integer = 0 To .ColumnCount - 1

                    If bolEx = True Then

                        .Item(0, iRws).Value = True

                    Else

                        .Item(0, iRws).Value = False

                    End If

                Next

            Next

        End With

    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged

        txtSearch.Text = cmbBranch.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged

        txtSearch.Text = cmbType.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    Private Sub cmbTitle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTitle.SelectedIndexChanged

        txtSearch.Text = cmbTitle.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

    End Sub

    'Private Sub dgvEmps_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmps.CellEndEdit
    '    If dgvEmps.CurrentRow.Cells(0).Value = True Then
    '        dgvEmps.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LightGreen
    '    End If
    'End Sub

    Private Sub lnlbDeleteShift_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnlbDeleteShift.LinkClicked

        Dim dr As DialogResult = MsgBox("Do you really want to delete shifts?", MsgBoxStyle.YesNo)
        If dr = Windows.Forms.DialogResult.No Then Exit Sub
        Try
            Dim dtYrEndDate As Date = DateSerial(intCurrentYear, 12, 31)
            'Dim bolExAttn As Boolean
            Dim bolPic As Boolean
            With dgvEmps
                For irws As Integer = 0 To .RowCount - 1
                    Dim iVal As Integer = .Item(6, irws).Value
                    bolPic = .Item(0, irws).Value
                    If bolPic = True Then
                        StrEmployeeID = .Item(1, irws).Value
                        'bolExAttn = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE AntStatus = 1 AND AtDate between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "' AND EmpID = '" & StrEmployeeID & "'")
                        'If bolExAttn = True Then

                        sSQL = "DELETE FROM tblEmpRegister WHERE EmpID= '" & StrEmployeeID & "' AND AtDate Between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "'; DELETE FROM tblGetInOut WHERE EmpID= '" & StrEmployeeID & "' AND AtDate Between '" & Format(dtpEffdate.Value, "yyyyMMdd") & "' AND '" & Format(dtYrEndDate, "yyyyMMdd") & "' ;UPDATE tblEmployee SET isShifed=1 WHERE RegID= '" & StrEmployeeID & "';"

                        FK_EQ(sSQL, "D", "", False, False, True)
                        'End If
                    End If
                Next
            End With
            MessageBox.Show("Information Saved", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel43_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel43.MouseClick
        pnlTopIcon.Height = 140
        pnlViewk.Width = 460
        pnlViewk.Controls.Clear()
        pnlViewk.Controls.Add(pnl1)
        pnl1.Dock = DockStyle.Fill
        pnl1.Visible = True
    End Sub

    Private Sub Panel7_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel7.MouseClick
        pnlTopIcon.Height = 140
        pnlViewk.Controls.Clear()
        pnlViewk.Controls.Add(pnl2)
        pnlViewk.Width = 460
        pnl2.Dock = DockStyle.Fill
        pnl2.Visible = True
    End Sub

    Private Sub Panel8_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel8.MouseClick
        pnlTopIcon.Height = 140
        pnlViewk.Controls.Clear()
        pnlViewk.Controls.Add(pnl3)
        pnlViewk.Width = 460
        pnl3.Dock = DockStyle.Fill
        pnl3.Visible = True
    End Sub

    Private Sub Panel9_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel9.MouseClick
        pnlTopIcon.Height = 140
        pnlViewk.Controls.Clear()
        pnlViewk.Controls.Add(pnl4)
        pnlViewk.Width = 460
        pnl4.Dock = DockStyle.Fill
        pnl4.Visible = True
    End Sub

    Private Sub Panel10_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel10.MouseClick
        pnlTopIcon.Height = 140
        pnlViewk.Controls.Clear()
        pnlViewk.Controls.Add(pnl5)
        pnlViewk.Width = 460
        pnl5.Dock = DockStyle.Fill
        pnl5.Visible = True
    End Sub

    Private Sub Panel11_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel11.MouseClick
        pnlTopIcon.Height = 140
        pnlViewk.Controls.Clear()
        pnlViewk.Controls.Add(pnl6)
        pnlViewk.Width = 460
        pnl6.Dock = DockStyle.Fill
        pnl6.Visible = True
    End Sub

    Private Sub pnlShift_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlShift.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Me.pnlDynamic.Controls.Add(pnlAllk)
    End Sub

    Private Sub pnlRoster_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlRoster.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmRosterAssign
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub


    Private Sub pnlResign_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlResign.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmResign
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlReActiv_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlReActiv.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmReActCancelEmp
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlDayCon_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlDayCon.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmConfgDayPrfVsShift
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlOTCon_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmNewOTConfig
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlOther_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlOther.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmCalendar
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlReproc_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlReproc.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmPrcSelectedlist
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlSummary_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlSummary.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmNewPayrollSummary
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlGenLeae_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlGenLeae.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmLeaveImport
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlLvConfig_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmWeekShdl
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlEzcelReport_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmQryReport
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlDynReport_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmRandomReport
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel43_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel9.MouseHover, Panel8.MouseHover, Panel7.MouseHover, Panel43.MouseHover, Panel11.MouseHover, Panel10.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Panel43_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel9.MouseLeave, Panel8.MouseLeave, Panel7.MouseLeave, Panel43.MouseLeave, Panel11.MouseLeave, Panel10.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pnlUseLevel_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlUseLevel.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmUserPermission
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel14_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel14.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        If intIsNewLeaveC = 0 Then
            Dim frmReg As New frmConfigLeave
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)

            frmReg.Show()
        Else
            Dim frmReg As New frmConfigLeaveProf
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)

            frmReg.Show()
        End If
    End Sub

    Private Sub pnlShift_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlUseLevel.MouseHover, pnlSummary.MouseHover, pnlShift.MouseHover, pnlRoster.MouseHover, pnlResign.MouseHover, pnlReproc.MouseHover, pnlReActiv.MouseHover, pnlOther.MouseHover, pnlGenLeae.MouseHover, pnlDayCon.MouseHover, pnlCrtParameter.MouseHover, Panel14.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub pnlShift_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlUseLevel.MouseLeave, pnlSummary.MouseLeave, pnlShift.MouseLeave, pnlRoster.MouseLeave, pnlResign.MouseLeave, pnlReproc.MouseLeave, pnlReActiv.MouseLeave, pnlOther.MouseLeave, pnlGenLeae.MouseLeave, pnlDayCon.MouseLeave, pnlCrtParameter.MouseLeave, Panel14.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pnlParameter_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlCrtParameter.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmSetAttnParam
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel4_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlConfPara.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmConfigAtnParam
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel5_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlDeviceInfo.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmDeviceInfo
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel25_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If StrUlvlID <> "HRIS" Then
            Exit Sub
        End If
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmMenuCapture
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel4_MouseClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel4.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmSetLeaveType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlQuary_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmSQLInterface
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub Panel5_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Panel5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub pnlExtraDayImport_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If UP("Leave", "Import extra days as leave") = False Then Exit Sub
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmImportExtraDaystoLeave
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlBackup_MouseClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlBackup.MouseClick
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmBackupDB
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pntTextGen_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If UP("Text Genarate", "Text file with attendance summary") = False Then Exit Sub
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmTextGenerator
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlMonthEnd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If UP("Text Genarate", "Text file with attendance summary") = False Then Exit Sub
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmMonthEndProcess
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlSqlGenerator_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If UP("Addtitional", "Design excel reports") = False Then Exit Sub
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmSqlGenerator
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub pnlExcelReport_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If UP("Addtitional", "View designed excel reports") = False Then Exit Sub
        pnlTopIcon.Height = 70
        'strClicked = "cmdLeve"
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmQryReportViewer
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

End Class