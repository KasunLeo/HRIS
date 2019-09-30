Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI
Imports System.IO
Imports System.Configuration
'Imports System.Drawing.Drawing2D

Public Class frmEmployeeInfo

    Dim intEnrolNo As Integer
    'Dim strKEmProfileID As String = ""
    Dim StrDefAddID As String
    'Dim grd As New DataGridView
    Dim intActive As Integer
    Dim StrSvStatus As String
    Dim strSurNameClr As String
    Dim strFNamesClr As String
    Dim strIsEpf As String : Dim intExsEnNo As Integer
    Dim strExsNic As String : Dim StrDefaultShiftID As String
    Dim bolIsLoad As Boolean
    Dim picbyte2 As Byte()
    Dim strClickedEmp As String : Dim strShiftID As String
    Dim strWhereClause As String
    'Save name change history 2017 12 06 Kasun
    Dim strFirstName As String = ""
    Dim strLastName As String = ""
    Dim strOldDispName As String = ""
    Dim intTotShLvMinPerMonth As Integer
    Dim intMaxNoShLvPerMnth As Integer
    Dim intMinMnPerShLv As Integer
    '' ''Public Sub perform_tab_on_enter(ByVal e As KeyEventArgs)
    '' ''    If e.KeyCode = Keys.Enter Then
    '' ''        SendKeys.Send("{TAB}")
    '' ''    Else
    '' ''        Exit Sub
    '' ''    End If
    '' ''    e.SuppressKeyPress = True 'this will prevent ding sound 
    '' ''End Sub

    Private Sub LoadEmployeeScreen()
        If UP("Employee Profile", "View employee profile") = False Then Exit Sub
        picEDesig.Visible = True
        ControlHandlers(Me)

        Dim crtl As Control
        For Each crtl In Me.pnlMyData.Controls
            If TypeOf crtl Is TextBox Then
                crtl.Text = ""
            End If
        Next

        'CenterFormThemed(Me, Panel1, Label25)
        ''If intIsBOTAccept = 1 Then chkIsBOT.Visible = True Else chkIsBOT.Visible = False
        If intIsMonthlyOT = 1 Then txtOTforMonth.Visible = True : lblMonthOT.Visible = True

        'MODIFY SYSTEM TO DISPLAY DEPATMENT AS BRANCH AND SECTION AS DEPARTMENT
        If ISDispalyDepartmentASBranch = 1 Then
            lblBranch.Text = "Department"
            lblDepartment.Text = "Section"
        End If
        bolIsLoad = True
        StrDefAddID = "001"
        StrSvStatus = "S"
        intActive = 1
        'Load Default Shift 
        StrDefaultShiftID = fk_RetString("SELECT DSID FROM tblCompany WHERE CompID = '" & StrCompID & "'")

        '20181009 enabl multi langu name form [prasanna]
        If 1 = fk_RetString("SELECT  multiplelangName FROM tblcontrol ") Then
            pbAddMultiLungName.Visible = True
        Else
            pbAddMultiLungName.Visible = False
        End If


        'Delete shift enable check
        intisDeleteShift = fk_sqlDbl("select isDeleteShift from tblcompany where compID='" & StrCompID & "'")
        If intisDeleteShift = 1 Then
            chkShift.Visible = True
        End If
        'If strKEmProfileID = "" Then
        '    sSQL = "SELECT min(REGID) FROM tblEmployee WHERE empStatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        '    strKEmProfileID = fk_RetString(sSQL)
        'End If

        strShiftID = "909"

        rdbActive.Checked = True
        ViewEmployee()
        'If strKEmProfileID <> "" Then
        If StrEmployeeID <> "" Then
            Dim crtlk As Control
            For Each crtlk In Me.GroupBox1.Controls
                If TypeOf crtlk Is TextBox Then crtl.Text = ""
            Next

            For Each crtl In Me.GroupBox4.Controls
                If TypeOf crtl Is TextBox Then crtl.Text = ""
            Next

            For Each crtl In Me.GroupBox4.Controls
                If TypeOf crtl Is TextBox Then crtl.Text = ""
            Next

            chkCancel.Checked = False

            ListCombo(cmbTItle, "SELECT * FROM tblSetTitle WHERE Status = 0 Order By titleID", "titleDesc")
            'Gender
            ListCombo(cmbGender, "SELECT * FROM tblGender WHERE Status = 0 Order By GenID", "GenDesc")
            'Civil Status
            ListCombo(cmbCivilSt, "SELECT * FROM tblCivilStatus WHERE Status =  0 Order By StID", "StDesc")
            'Designations
            ListCombo(cmbDesignation, "select * from tblDesig where status = 0 order by desgID", "desgDesc")
            'Designation 
            ListCombo(cmbBranch, "SELECT * FROM tblCBranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID", "BrName")
            'Department
            ListCombo(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "DeptName")
            'Category inof
            ListCombo(cmbEmpCategory, "select * From tblSEtEmpCategory WHERE Status = 0 ORder By CatID", "catDesc")
            'Employee Type
            ListCombo(cmbEmpType, "SELECT * FROM tblSetEmpType WHERE Status = 0 Order By TypeID", "tDesc")

            ListCombo(cmbShift, "SELECT * FROM tblSetshifth WHERE Status = 0 Order By shiftID", "shiftName")

            txtCrPeriod.Text = "0"

            'Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
            'intEnrolNo = iEms
            'txtEnrolNo.Text = intEnrolNo.ToString
            'StrEmployeeID = fk_CreateSerial(6, iEms)
            'txtRegNo.Text = StrEmployeeID

            picEmp.Image = Nothing
            'frmMasterEmployee.lblID.Text = StrEmployeeID
            'StrDispName = ""
            Me.lblName.Text = StrDispName

            StrSvStatus = "S"
            dtpCFrom.Value = dtWorkingDate.Date
            dtpCTo.Value = dtWorkingDate.Date
            dtpCTo.MinDate = dtpCFrom.Value.Date

            'StrEmployeeID = strKEmProfileID
            pb_ShowEmployee(StrEmployeeID)
            cmdPrevious.Enabled = False

            'strKEmProfileID = ""
            'ElseIf strKEmProfileID = "" Then
        ElseIf StrEmployeeID = "" Then

            strIsEpf = fk_RetString("select isEpf from tblcompany where compId='" & StrCompID & "'")
            ''2018-11cmdRefresh_Click(sender, EditEmployee)
            ''Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
            ''intEnrolNo = iEms
            ' ''If strIsFormLoad = "Refresh" Then
            ''txtEnrolNo.Text = intEnrolNo.ToString
            ''StrEmployeeID = fk_CreateSerial(6, iEms)
            ''txtRegNo.Text = StrEmployeeID
            ' ''End If
        End If

        strClickedEmp = "cmdEmployee"
        ButtonClicked()
        'cmdEmployee_Click(sender, e)
        'The relevant tables for this form has created at the frmMasterEmployee form.

        'if strIsEpf = 0 then Register number 
        'if 1 then EpfNo.
        'If 2 then Enroll no.
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'StrEmployeeID = ""
        'BackColor = Color.RoyalBlue
        'TransparencyKey = Me.BackColor



        Dim AdvanHRIDDetails As Integer = fk_sqlDbl("select AdvanHRIDDetails from tblControl ")
        If AdvanHRIDDetails = 1 Then
            cmdShifts.Text = "         Additional HR"
        Else
            cmdShifts.Text = "         Roster"
        End If



        'pnlMostRLeft.Visible = False
        pnlEditHistory.Height = 0
    End Sub

    Private Sub frmEmployeeInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadEmployeeScreen()
    End Sub

    Public Sub ViewEmployee()
        If rdbActive.Checked = True Then
            strWhereClause = " tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        ElseIf rdbCancel.Checked = True Then
            strWhereClause = "tblemployee.Empstatus=9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        ElseIf rdbAbroad.Checked = True Then
            strWhereClause = "tblemployee.Empstatus=8 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        End If

        sSQL = "select tblEmployee.RegID,RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as '" & sqlTag1.Split("."c)(1) & "' ,tblEmployee.DispName AS 'Employee Name',tblEmployee.NICNumber AS 'NIC Number',tblEmployee.callName AS 'Calling Name',tblSetDept.DeptName AS 'Department',tblDesig.desgDesc AS 'Designation',CONVERT(VARCHAR(11),tblEmployee.regDate,106) AS 'Joining Date',CONVERT(VARCHAR(11),tblEmployee.dOFb,106) AS 'Birth Date' FROM tblEmployee,tblDesig,tblSetDept WHERE tblEmployee.desigID=tblDesig.DesgID AND tblSetDept.deptID=tblEmployee.DeptID and " & strWhereClause & " AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' OR tblEmployee.firstName like '%" & txtSearch.Text & "%' OR tblEmployee.surName like '%" & txtSearch.Text & "%' OR tblEmployee.callName like '%" & txtSearch.Text & "%' OR tblDesig.DesgDesc like '%" & txtSearch.Text & "%') ORDER BY " & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvAllEmp)
        dgvAllEmp.Columns(0).Visible = False
        For X As Integer = 0 To dgvAllEmp.Columns.Count - 1
            dgvAllEmp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Next
        lblEmpCount.Text = "Employee List : " & dgvAllEmp.RowCount
        pnlMostRLeft.Width = 357
    End Sub

    Public Sub sv_Leaves(ByVal empcat As String)

        Dim dgvEmp As DataGridView
        dgvEmp = New DataGridView

        With dgvEmp

            .Columns.Clear()
            .Columns.Add("EmpIDs", "Employee ID")
            .Columns.Add("CatIDs", "Category ID")
            .Columns.Add("CompIDs", "CompID")

        End With
        'Load Information to the grid 
        Load_InformationtoGrid("SELECT RegID,CatID,CompID FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "' Order By RegID", dgvEmp, 3)

        'Load Leave Information to the Leave GRID for  each Employee
        'Generate the Leave GRID
        Dim dgvLv As DataGridView
        dgvLv = New DataGridView

        With dgvLv

            .Columns.Clear()
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("CompID", "CompID")
            .Columns.Add("cYear", "cYear")
            .Columns.Add("LeaveID", "LeaveID")
            .Columns.Add("NoLeave", "NoLeave")
            .Columns.Add("TakenLv", "TakenLv")
            .Columns.Add("Status", "Status")

        End With

        With dgvEmp
            For i As Integer = 0 To .RowCount - 2
                Load_InformationtoGridNoClr("select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "'," & intCurrentYear & ", " & _
                                       " tblLeaveType.lvID,dbo.fk_RetNoLeave('" & .Item(1, i).Value & "',tblLeaveType.LvID) as NoLv,dbo.fk_EmpRetNoLeave(tblLeaveType.LvID,'" & .Item(0, i).Value & "',2012),0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLv, 7)

            Next
        End With
        'Insert all information to tblEmployee Leave File
        Dim sqlQRY As String

        With dgvLv
            'Update tblEm
            sqlQRY = "DELETE FROM tblEmpLeaveD WHERE EmpID = '" & StrEmployeeID & "'"
            For i As Integer = 0 To .RowCount - 2
                sqlQRY = sqlQRY & " INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES ('" & .Item(0, i).Value & "', " & _
                " '" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, i).Value & "', " & CDbl(.Item(4, i).Value) & "," & CDbl(.Item(5, i).Value) & ",1)"
            Next
        End With

        FK_EQ(sqlQRY, "P", "", False, False, False)

    End Sub

    'The following procedure has been commented by Rajitha. Kasun gave me updated one.
    '' '' ''    Public Sub sv_Leaves(ByVal empcat As String)
    '' '' ''        Dim sqlQv As String = "select '" & StrEmployeeID & "','" & StrCompID & "'," & intCurrentYear & ",tblLeaveType.LvID,tblSetLeave.NoLeave,0,0 FROM tblSetLeave " & _
    '' '' ''" INNER JOIN tblLeaveType ON tblSetLeave.LeaveID = tblLeaveType.LvID WHERE tblSetLeave.catID = '" & empcat & "'"

    '' '' ''        'Create grid table structuer
    '' '' ''        With grd
    '' '' ''            .Columns.Clear()
    '' '' ''            .Columns.Add("empID", "employee id")        '0
    '' '' ''            .Columns.Add("compID", "company id")        '1
    '' '' ''            .Columns.Add("cYear", "Current Year")       '2
    '' '' ''            .Columns.Add("LvType", "Leave Type")        '3
    '' '' ''            .Columns.Add("NoLv", "No Leaves")           '4
    '' '' ''            .Columns.Add("BalLv", "Leave Balance")      '5
    '' '' ''            .Columns.Add("St", "Status")                '6
    '' '' ''        End With

    '' '' ''        Load_InformationtoGrid(sqlQv, grd, 7)

    '' '' ''        'Check Existing Leave Information in the tblEmpLeave
    '' '' ''        Dim bolExEmp As Boolean
    '' '' ''        If StrSvStatus = "E" Then
    '' '' ''            bolExEmp = fk_CheckEx("SELECT * FROM tblEmpLeaveD WHERE EmpID = '" & StrEmployeeID & "'")

    '' '' ''        Else
    '' '' ''            bolExEmp = False
    '' '' ''        End If

    '' '' ''        Dim bolExL As Boolean = False
    '' '' ''        Dim iRw As Integer
    '' '' ''        If bolExEmp = True Then 'if employee already assig the records need to manage change
    '' '' ''            With grd
    '' '' ''                For iRw = 0 To .RowCount - 1
    '' '' ''                    bolExL = fk_CheckEx("SELECT * FROM tblEmpLeaveD WHERE empID = '" & StrEmployeeID & "' AND LeaveID = '" & .Item(3, iRw).Value & "' AND CompID = '" & StrCompID & "' AND cYear = " & intCurrentYear & "")
    '' '' ''                    If bolExL = True Then
    '' '' ''                        .Item(6, iRw).Value = 1
    '' '' ''                    Else
    '' '' ''                        .Item(6, iRw).Value = 0
    '' '' ''                    End If
    '' '' ''                Next
    '' '' ''            End With
    '' '' ''        End If


    '' '' ''        Dim cnSv As New SqlConnection(sqlConString)
    '' '' ''        cnSv.Open()
    '' '' ''        Dim sqlSv As String = ""
    '' '' ''        Dim cmSv As New SqlCommand
    '' '' ''        cmSv = cnSv.CreateCommand
    '' '' ''        Dim trSv As SqlTransaction = cnSv.BeginTransaction
    '' '' ''        cmSv.Transaction = trSv
    '' '' ''        Dim StrT As String
    '' '' ''        Try
    '' '' ''            With grd
    '' '' ''                For iRw = 0 To .RowCount - 1
    '' '' ''                    StrT = .Item(6, iRw).Value
    '' '' ''                    Select Case StrT
    '' '' ''                        Case "1" 'if information are exists
    '' '' ''                            'sqlSv = "UPDATE tblEmpLeaveD SET NoLeaves = " & CDbl(.Item(4, iRw).Value) & " WHERE EmpID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "' " & _
    '' '' ''                            '" AND cYear = " & intCurrentYear & " AND LeaveID = '" & .Item(3, iRw).Value & "'"
    '' '' ''                            'cmSv.CommandText = sqlSv
    '' '' ''                            'cmSv.ExecuteNonQuery()

    '' '' ''                        Case "0"
    '' '' ''                            sqlSv = "INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES " & _
    '' '' ''                            " ('" & StrEmployeeID & "','" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, iRw).Value & "'," & CDbl(.Item(4, iRw).Value) & ",0,0)"
    '' '' ''                            cmSv.CommandText = sqlSv
    '' '' ''                            cmSv.ExecuteNonQuery()
    '' '' ''                    End Select

    '' '' ''                Next

    '' '' ''                trSv.Commit()

    '' '' ''            End With
    '' '' ''        Catch ex As Exception
    '' '' ''            MsgBox(ex.Message)
    '' '' ''            trSv.Rollback()
    '' '' ''        Finally
    '' '' ''            cnSv.Close()
    '' '' ''        End Try
    '' '' ''    End Sub
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

    End Sub

    Private Sub RefreshButtonEmployee()

        Dim crtl As Control
        For Each crtl In Me.pnlMyData.Controls
            If TypeOf crtl Is TextBox Then
                crtl.Text = ""
            End If
        Next

        Dim crtlk As Control
        For Each crtlk In Me.pnlMyData.Controls
            If TypeOf crtlk Is ComboBox Then
                crtlk.Enabled = True
                crtlk.ForeColor = Color.Black
            End If
        Next

        'For Each crtl In Me.GroupBox4.Controls
        '    If TypeOf crtl Is TextBox Then crtl.Text = ""
        'Next

        chkCancel.Checked = False
        chkShift.Checked = False
        chkIsBOT.CheckState = CheckState.Unchecked
        ListCombo(cmbTItle, "SELECT * FROM tblSetTitle WHERE Status = 0 Order By titleID", "titleDesc")
        'Gender
        ListCombo(cmbGender, "SELECT * FROM tblGender WHERE Status = 0 Order By GenID", "GenDesc")
        'Civil Status
        ListCombo(cmbCivilSt, "SELECT * FROM tblCivilStatus WHERE Status =  0 Order By StID", "StDesc")
        'Designations
        ListCombo(cmbDesignation, "select * from tblDesig where status = 0 order by desgID", "desgDesc")
        'Designation 
        ListCombo(cmbBranch, "SELECT * FROM tblCBranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID", "BrName")
        'Department
        ListCombo(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "DeptName")
        'Category inof
        ListCombo(cmbEmpCategory, "select * From tblSEtEmpCategory WHERE Status = 0 ORder By CatID", "catDesc")
        'Employee Type
        ListCombo(cmbEmpType, "SELECT * FROM tblSetEmpType WHERE Status = 0 Order By TypeID", "tDesc")

        ListCombo(cmbShift, "SELECT * FROM tblSetshifth WHERE Status = 0 Order By shiftID", "shiftName")

        txtCrPeriod.Text = "0"

        Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        intEnrolNo = iEms

        'txtEnrolNo.Text = intEnrolNo.ToString
        StrEmployeeID = fk_CreateSerial(6, iEms)
        txtRegNo.Text = StrEmployeeID

        picEmp.Image = My.Resources.User_Anonymous_Disabled
        StrDispName = ""

        StrSvStatus = "S"
        dtpCFrom.Value = dtWorkingDate.Date
        dtpCTo.Value = dtWorkingDate.Date
        dtpCTo.MinDate = dtpCFrom.Value.Date
        bolIsLoad = False

        lblName.Text = "Employee Name"
        lblBranchtop.Text = "Branch : "
        lblDesignation.Text = "Designation : "
        lblEmpNumb.Text = "Emp No : "
        lblAddres.Text = "Address : "
        lblBirth.Text = "Birthday : " & Format(dtpDofB.Value, "dd-MM-yyyy")
        lbldepeartment.Text = "Department : "
        lblEmail.Text = "Email : "
        txtEnrolNo.Text = fk_sqlDbl("SELECT max(enrolNo)+1 FROM tblEmployee  WHERE EmpStatus<>9")
        dtpRegDate.Value = Now.Date
    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        'crtl.FlatAppearance.BorderColor = Me.pnlAllData.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        'crtl.FlatAppearance.BorderColor = Me.pnlAllData.BackColor

    End Sub

    Private Sub cmbTItle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTItle.SelectedIndexChanged
        StrTitleID = fk_RetString("SELECT titleID FROM tblSetTitle WHERE titleDesc = '" & cmbTItle.Text & "'")
        get_FullName(cmbTItle.Text, txtFirstName.Text, txtLName.Text)
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged
        StrGenderID = fk_RetString("SELECT GenID FROM tblGender WHERE GenDesc = '" & cmbGender.Text & "'")
        If StrGenderID = "001" Then
            cmbTItle.SelectedIndex = 1
        Else
            cmbTItle.SelectedIndex = 2
        End If
    End Sub

    Private Sub cmbCivilSt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCivilSt.SelectedIndexChanged
        StrCivilStID = fk_RetString("SELECT StID FROM tblCivilStatus WHERE stDesc = '" & cmbCivilSt.Text & "'")
    End Sub

    Private Sub cmbDesignation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDesignation.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Designation directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbDesignation.Text = "" : picEDesig_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignation.SelectedIndexChanged
        StrDesgID = fk_RetString("SELECT DesgID FROM tblDesig WHERE DesgDesc = '" & cmbDesignation.Text & "'")
    End Sub

    Private Sub cmbBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBranch.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Branch directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbBranch.Text = "" : picEBr_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        StrBranchID = fk_RetString("SELECT BrID FROM tblCBranchs WHERE BrName = '" & cmbBranch.Text & "' AND CompID = '" & StrCompID & "'")
    End Sub

    Private Sub cmbDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Department directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbDept.Text = "" : PicEDept_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        StrDeptID = fk_RetString("SELECT DeptID FROM tblsetDept WHERE DeptName = '" & cmbDept.Text & "'")
    End Sub

    Private Sub cmbEmpCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpCategory.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Category directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbEmpCategory.Text = "" : picECat_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbEmpCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpCategory.SelectedIndexChanged
        StrCategoryID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbEmpCategory.Text & "'")
    End Sub

    Private Sub cmbEmpType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpType.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Employee Type directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbEmpType.Text = "" : picEType_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpType.SelectedIndexChanged
        StrEmpTypeID = fk_RetString("SELECT TypeID FROM tblSetEmpType WHERE tDesc = '" & cmbEmpType.Text & "'")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Employee Profile", "Add new employee profile") = False Then Exit Sub

        'chk if enroll no has not changed by the user the message says to confirm to save auto gen no. From Duminda.
        txtFirstName_Leave(sender, e)
        txtSName_Leave(sender, e)
        'txtNICNumber_Leave(sender, e)
        If chkCancel.Checked = True Then
            intActive = 9
        Else
            intActive = 1
        End If

        'Before save the employee information, requrired to validate 
        If txtRegNo.Text = "" Then
            MsgBox("Required Register No", MsgBoxStyle.Information)
            txtRegNo.Focus()
            Exit Sub
        End If

        If txtEnrolNo.Text = "" Then
            MsgBox("Required Terminal No", MsgBoxStyle.Information)
            txtRegNo.Focus()
            Exit Sub
        End If

        If cmbTItle.Text = "NONE" Then
            MsgBox("Please Select the Title", MsgBoxStyle.Information)
            cmbTItle.Focus()
            Exit Sub
        End If

        If txtLName.Text.Trim = "" Then
            MsgBox("Please Enter the Surname", MsgBoxStyle.Information)
            txtLName.Focus()
            Exit Sub
        End If

        'If txtFirstName.Text.Trim = "" Then
        '    MsgBox("Please Enter the First Names.", MsgBoxStyle.Information)
        '    txtFirstName.Focus()
        '    Exit Sub
        'End If

        If txtNICNumber.Text = "" Then
            MsgBox("Required NIC Number", MsgBoxStyle.Information)
            txtNICNumber.Focus()
            Exit Sub
        End If

        If cmbGender.Text = "NONE" Then
            MsgBox("Select the Gender", MsgBoxStyle.Information)
            cmbGender.Focus()
            Exit Sub
        End If

        If cmbCivilSt.Text = "NONE" Then
            MsgBox("Select the Civil Status", MsgBoxStyle.Information)
            cmbCivilSt.Focus()
            Exit Sub
        End If

        If cmbBranch.Text = "NONE" Then
            MsgBox("Select the Branch", MsgBoxStyle.Information)
            cmbBranch.Focus()
            Exit Sub
        End If

        'if tblCompany table isEpf field has 1 then all reports based on epfno. so make it required field
        'based on frmCompany form settings.
        If strIsEpf = 1 Then
            If txtEpfNo.Text.Trim = "" Then
                MsgBox("Please Enter the EPF No.")
                txtEpfNo.Focus()
                Exit Sub
            End If
        End If

        If cmbDesignation.Text = "NONE" Then
            MsgBox("Select the Designation", MsgBoxStyle.Information)
            cmbDesignation.Focus()
            Exit Sub
        End If

        If cmbDept.Text = "NONE" Then
            MsgBox("Select the Department.", MsgBoxStyle.Information)
            cmbDept.Focus()
            Exit Sub
        End If

        If cmbEmpCategory.Text = "NONE" Then
            MsgBox("Select the Employee Category", MsgBoxStyle.Information)
            cmbEmpCategory.Focus()
            Exit Sub
        End If

        If cmbEmpType.Text = "NONE" Then
            MsgBox("Select the Emloyee Type", MsgBoxStyle.Information)
            cmbEmpType.Focus()
            Exit Sub
        End If

        If cmbShift.Text = "NONE" Then
            MsgBox("Select the shift", MsgBoxStyle.Information)
            cmbShift.Focus()
            Exit Sub
        End If


        If cmbDesignation.Text = "" Then
            MsgBox("Select the Designation", MsgBoxStyle.Information)
            cmbDesignation.Focus()
            Exit Sub
        End If

        If cmbDept.Text = "" Then
            MsgBox("Select the Department.", MsgBoxStyle.Information)
            cmbDept.Focus()
            Exit Sub
        End If

        If cmbEmpCategory.Text = "" Then
            MsgBox("Select the Employee Category", MsgBoxStyle.Information)
            cmbEmpCategory.Focus()
            Exit Sub
        End If

        If cmbEmpType.Text = "" Then
            MsgBox("Select the Emloyee Type", MsgBoxStyle.Information)
            cmbEmpType.Focus()
            Exit Sub
        End If

        If cmbShift.Text = "" Then
            MsgBox("Select the shift", MsgBoxStyle.Information)
            cmbShift.Focus()
            Exit Sub
        End If

        If cmbBranch.Text = "" Then
            MsgBox("Select the branch", MsgBoxStyle.Information)
            cmbBranch.Focus()
            Exit Sub
        End If

        If txtEmail.Text.Trim <> "" Then
            If False = fk_EAdChk(txtEmail.Text) Then
                MsgBox("Please Enter a Valid E-Mail Address.")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        StrGenderID = fk_RetString("SELECT GenID FROM tblGender WHERE GenDesc = '" & cmbGender.Text & "'")
        StrCivilStID = fk_RetString("SELECT StID FROM tblCivilStatus WHERE stDesc = '" & cmbCivilSt.Text & "'")
        StrBranchID = fk_RetString("SELECT BrID FROM tblCBranchs WHERE BrName = '" & cmbBranch.Text & "' AND CompID = '" & StrCompID & "'")
        StrDeptID = fk_RetString("SELECT DeptID FROM tblsetDept WHERE DeptName = '" & cmbDept.Text & "'")
        StrCategoryID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbEmpCategory.Text & "'")
        StrEmpTypeID = fk_RetString("SELECT TypeID FROM tblSetEmpType WHERE tDesc = '" & cmbEmpType.Text & "'")

        If txtEmpNo.Text = "" Then txtEmpNo.Text = "0"
        If txtEmpNo.Text = "" Then

            MsgBox("Required Feild Employee No", MsgBoxStyle.Information)
            txtEmpNo.Focus()
            Exit Sub
        End If

        Dim bolCalEx As Boolean = False

        '===========Following added by Rajitha.
        If StrSvStatus = "S" Then

            txtRegNo.Text = fk_CreateSerial(6, (fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1))

            'Ask from user to save auto gen enroll number?
            If intEnrolNo = txtEnrolNo.Text.Trim Then
                If MessageBox.Show("Enroll Number For " & cmbTItle.Text & " " & txtLName.Text.Trim & " has set to " & intEnrolNo & ". Are you sure to save this?", "Confirm...", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                    txtEnrolNo.Focus()
                    Exit Sub
                End If
            End If

            'Check Existing Enrol Number
            Dim bolExFinger As Boolean = fk_CheckEx("SELECT EnrolNo FROM tblEmployee WHERE EnrolNo = " & CInt(txtEnrolNo.Text) & "")
            If bolExFinger = True Then
                MsgBox("This Enroll Number has been Set for Another Employee.Please Select Different Enroll Number.", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Check NIC duplication.
            Dim bolExNIC As Boolean = fk_CheckEx("SELECT regid FROM tblEMployee WHERE NicNumber = '" & txtNICNumber.Text & "' AND compID = '" & StrCompID & "' AND tblEMployee.empStatus<>9")
            If bolExNIC = True Then
                MsgBox("The NIC Number has already been saved and can not be Duplicated.", MsgBoxStyle.Critical)
                txtNICNumber.Focus()
                Exit Sub
            End If
        End If


        If StrSvStatus = "E" Then
            'Check Edited NIC/Enroll numbers duplication...

            If intExsEnNo <> txtEnrolNo.Text.Trim Then
                If True = fk_CheckEx("select * from tblEmployee where compID='" & StrCompID & "' and enrolno = " & txtEnrolNo.Text.Trim & " and regid <> '" & txtRegNo.Text & "'") Then
                    MsgBox("This Enroll Number has been Set for Another Employee.Please Select Different Enroll Number.", MsgBoxStyle.Information)
                    txtEnrolNo.Focus()
                    Exit Sub
                End If
            End If
            'strExsNic
            If strExsNic <> txtNICNumber.Text.Trim Then
                If True = fk_CheckEx("select * from tblEmployee where compID='" & StrCompID & "' and NicNumber = '" & txtNICNumber.Text.Trim & "' and regid <> '" & txtRegNo.Text & "' AND empstatus<>9") Then
                    MsgBox("This NIC Number has been set for another active employee.Please eelect different NIC Number.", MsgBoxStyle.Information)
                    txtNICNumber.Focus()
                    Exit Sub
                End If
            End If
        End If

        '=================

        'If StrSvStatus = "S" Then

        '    'Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        '    'StrEmployeeID = fk_CreateSerial(6, iEms)
        '    'txtRegNo.Text = StrEmployeeID



        '    Dim bolExEnrl As Boolean = fk_CheckEx("SELECT * FROM tblEmployee WHERE EnrolNo = '" & txtEnrolNo.Text & "'")
        '    If bolExEnrl = True Then
        '        MsgBox("Enroll Number Already Exists", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If
        'Else
        '    'Check for the attendance calendar existance
        '    bolCalEx = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE cyear = " & intCurrentYear & " AND CompID = '" & StrCompID & "' AND empID = '" & StrEmployeeID & "'")

        'End If
        'Check Enrol Number 


        'Save Coding
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "INSERT INTO tblEmployee (RegID,RegDate,TitleID,SurName,FirstName,dispName,NICNumber,DofB, " & _
                    " GenderID,CivilStID,EmpNo,EpfNo,CompID,DesigID,BrID," & _
                    " DeptID, CatID, EmpTypeID, DefAddID, homePhone, pMobile, OfficePhone, Email, CntrPeriod, CardID, " & _
                    " StatusDate, NoAdds, EmpStatus,EnrolNo,ContractStart,ContractEnd,IsEmpBOT,confirmDate,empReqHours,isShifed,shiftID,callName) VALUES " & _
                    " ('" & txtRegNo.Text & "','" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "','" & StrTitleID & "','" & FK_Rep(txtLName.Text) & "', " & _
                    " '" & FK_Rep(txtFirstName.Text) & "','" & FK_Rep(StrDispName) & "','" & txtNICNumber.Text & "','" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " & _
                    " '" & StrGenderID & "','" & StrCivilStID & "','" & txtEmpNo.Text & "','" & FK_Rep(txtEpfNo.Text) & "','" & StrCompID & "', " & _
                    " '" & StrDesgID & "','" & StrBranchID & "','" & StrDeptID & "','" & StrCategoryID & "','" & StrEmpTypeID & "', " & _
                    " '001', '" & txthPhone.Text & "','" & txtmPhone.Text & "','" & txtOfficePhone.Text & "','" & txtEmail.Text & "', " & _
                    " " & CDbl(IIf(txtCrPeriod.Text = "", 0, txtCrPeriod.Text)) & ",'','" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "',1," & intActive & "," & CInt(txtEnrolNo.Text) & ",'" & Format(dtpCFrom.Value, strRetDateTimeFormat) & "','" & Format(dtpCTo.Value, strRetDateTimeFormat) & "'," & chkIsBOT.CheckState & ",'" & Format(dtpConfDate.Value, strRetDateTimeFormat) & "','" & Val(txtOTforMonth.Text) & "'," & chkShift.CheckState & ",'" & strShiftID & "','" & txtCallName.Text & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblCompany SET NoEmps = NoEmps + 1 WHERE compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Isert Address to Address table 
                    'mailing address id is 001
                    sqlQRY = "INSERT INTO tblEmpAddress (EmpID,AddID,AddType,Add1,Add2,Add3,Status,compID) VALUES " & _
                    " ('" & txtRegNo.Text & "','001','001','" & FK_Rep(txtmAdd1.Text) & "','" & FK_Rep(txtmAdd2.Text) & "','" & FK_Rep(txtmAdd3.Text) & "',0,'" & StrCompID & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Insert records to payroll
                    Dim strContact As String = "Home : " & txthPhone.Text & " | Mobile : " & txtmPhone.Text & " | Office : " & txtOfficePhone.Text
                    sqlQRY = "INSERT INTO tblPayrollEmployee ([RegID] ,joiningDate,[DispName] ,[EmIdNum],birthDate,genderID,maritalID,[EMPNo] ,[EPFNo],[ETPNo],[ComID],[DesigID],[BrID],[DeptID],sub_CatID,Contact,[status],BankID,BranchID,ReligionID,BondPeriod,ProbationDate,points,otherIDs,accNumber,[BasicSalary], " & _
                    " [DaysPay],[SalViewLevel],[EpfAllowed],[PayID],[CostID],Qualification,FinalSalary)     VALUES ('" & txtRegNo.Text & "','" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "', " & _
                    " '" & FK_Rep(StrDispName) & "','" & txtNICNumber.Text & "','" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " & _
                    " '" & StrGenderID & "','" & StrCivilStID & "','" & txtEmpNo.Text & "','" & FK_Rep(txtEpfNo.Text) & "','" & FK_Rep(txtEpfNo.Text) & "','" & StrCompID & "', " & _
                    " '" & StrDesgID & "','" & StrBranchID & "','" & StrDeptID & "','" & StrCategoryID & "', " & _
                    " '" & strContact & "'," & intActive & ",'01','001','001','19000101','19000101','0','','','0','0','001','0','01','01','','0')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    Dim dtEndDate As Date = DateSerial(intCurrentYear, 12, 31)
                    Dim dtStartDate As Date = DateSerial(intCurrentYear, 1, 1)
                    Dim intDay As Integer = dtStartDate.DayOfWeek
                    Dim intGap As Integer = 1 - intDay : If intGap > 0 Then intGap = 1 - 7
                    dtStartDate = DateAdd(DateInterval.Day, intGap, dtStartDate)
                    'Update Employee Information to default Open Shift.
                    sqlQRY = " INSERT INTO tblEmpRegister (EmpID,CompID,cMonth,cYear,AtDate,InDate,InTime1,OutDate,OutTime1,InTime2,OutTime2,ShiftID,DayID,DayTypeID,sInTime,sOutTime, " & _
                    " StrInTime,StrOutTime,AntStatus,WorkMins,WorkHrs,IsLate,LateMins,IsEarly,EarlyMins,IsLeave,LeaveID,NoLeave,IsoffdayWork,IsNightWork, " & _
                    " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,Status,BgOTHrs,EdOTHrs,cOTHrs,AtEdit,ClockIn,ClockOut,OTApved, " & _
                    " cOTMins, LEStatus, AllShifts, NRWorkDay, AdWorkDay, InTimeAP, NormalOT, NOTHours, AutoLeaveNo, DoubleOT, NormalOTHrs, DoubleOTHrs) SELECT '" & StrEmployeeID & "' ,'" & StrCompID & "',Month(tblCalendar.Date),Year(tblCalendar.Date),tblCalendar.Date,'','','','','','','" & StrDefaultShiftID & "',tblCalendar.DayID,tblCalendar.DayType," & _
                    " tblcalendar.Date+tblSetShiftH.InTime,tblCalendar.Date+tblSetShiftH.OutTime,'','',0,0,0,0,0,0,0,0,'',0,0,0,0,0,0,0,0,0,0,0,0,0,0,tblCalendar.Date+tblSetShiftH.StartCIN,DateAdd(Day,tblSetShiftH.ShiftMode,tblCalendar.Date)+tblSetShiftH.EndCOUT,0,0,'0|0', " & _
                    " '" & strShiftID & "',0,0,'',0,0,0,0,0,0 FROM tblCalendar,tblSetShiftH WHERE tblCalendar.Date Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND  " & _
                    " tblSetShiftH.ShiftID = '" & StrDefaultShiftID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = " INSERT INTO tblGetInOut " & _
            " (EmpID,AtDate,AntStatus,ShiftID,InTime,OutDate,OutTime,sInTime,sOutTime,ClockIn,ClockOut,WorkMin,LateMin,IsLate,EarlyMin,IsEarly, " & _
            " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BOTMin,EOTMin,OTMin,InDate,AtEdit,OTApved,ShiftLine,DayTypeID) " & _
        " SELECT EmpID,AtDate,AntStatus,ShiftID,InTime1,OutDate,OutTime1,sInTime,sOutTime,clockIn,ClockOut,WorkMins,LateMins,IsLate,EarlyMins,IsEarly, " & _
        " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,cOTMins,Indate,AtEdit,OTApved,0,DayTypeID FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Registered New Employee Reg ID : " & StrEmployeeID & " And Name : " & FK_Rep(StrDispName) & "','" & StrUserID & "',getdate ())"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblDocumentCollected (regID,allDocIDs,status,crUser) VALUES ('" & StrEmployeeID & "','',0,'" & StrUserID & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Generate short leave for current year automatically
                    sqlQRY = "EXEC [SP_GenShortLeaveSelected] " & intCurrentYear & ",1," & intTotShLvMinPerMonth & "," & intMaxNoShLvPerMnth & ",'" & StrEmployeeID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    Sv_Image(StrEmployeeID)
                    MsgBox("Employee Registered For " & StrDispName)
                    sv_Leaves(StrCategoryID)

                Case "E"

                    'Update information 
                    sqlQRY = "UPDATE tblEmployee SET RegDate = '" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "',TitleID = '" & StrTitleID & "', " & _
                   " SurName = '" & FK_Rep(txtLName.Text) & "',FirstName = '" & FK_Rep(txtFirstName.Text) & "',dispName = '" & FK_Rep(StrDispName) & "',NICNumber = '" & txtNICNumber.Text & "',DofB = '" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " & _
                   " GenderID = '" & StrGenderID & "',CivilStID = '" & StrCivilStID & "',EmpNo = '" & FK_Rep(txtEmpNo.Text) & "',EpfNo = '" & FK_Rep(txtEpfNo.Text) & "' , " & _
                   " CompID = '" & StrCompID & "'," & _
                   " DefAddID = '" & StrDefAddID & "', " & _
                   " homePhone = '" & txthPhone.Text & "', pMobile = '" & txtmPhone.Text & "', OfficePhone = '" & txtOfficePhone.Text & "',EnrolNo = '" & txtEnrolNo.Text & "', " & _
                   " Email = '" & txtEmail.Text & "', CntrPeriod = " & CDbl(IIf(txtCrPeriod.Text = "", 0, txtCrPeriod.Text)) & ", EmpStatus = " & intActive & " , ContractStart = '" & Format(dtpCFrom.Value, strRetDateTimeFormat) & "', ContractEnd = '" & Format(dtpCTo.Value, strRetDateTimeFormat) & "',IsEmpBOT = " & chkIsBOT.CheckState & ", confirmDate='" & Format(dtpConfDate.Value, strRetDateTimeFormat) & "',   empReqHours='" & Val(txtOTforMonth.Text) & "',isShifed=" & chkShift.CheckState & ",callName='" & txtCallName.Text & "',shiftID='" & strShiftID & "'  WHERE RegID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Update Address Information 
                    sqlQRY = "UPDATE tblEmpAddress SET Add1 = '" & FK_Rep(txtmAdd1.Text) & "',Add2 = '" & FK_Rep(txtmAdd2.Text) & "',Add3 = '" & FK_Rep(txtmAdd3.Text) & "' " & _
                    " WHERE EmpID = '" & StrEmployeeID & "' AND AddID = '" & StrDefAddID & "' AND CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Update records to payroll
                    'Dim strContact As String = "Home : " & txthPhone.Text & " | Mobile : " & txtmPhone.Text & " | Office : " & txtOfficePhone.Text
                    'sqlQRY = "UPDATE tblPayrollEmployee SET  joiningDate='" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "',[DispName]= '" & FK_Rep(StrDispName) & "' ,[EmIdNum]='" & txtNICNumber.Text & "',birthDate='" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " & _
                    '" genderID='" & StrGenderID & "',maritalID='" & StrCivilStID & "',[EMPNo]='" & txtEmpNo.Text & "' ,[EPFNo]='" & FK_Rep(txtEpfNo.Text) & "',[ETPNo]='" & FK_Rep(txtEpfNo.Text) & "', " & _
                    '" [DesigID]= '" & StrDesgID & "',[BrID]='" & StrBranchID & "',[DeptID]='" & StrDeptID & "',sub_CatID='" & StrCategoryID & "',Contact='" & strContact & "',[status]=" & intActive & " " & _
                    '" WHERE RegID = '" & StrEmployeeID & "'"
                    'cmSave.CommandText = sqlQRY
                    'cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Updated exsisting employee Reg ID : " & StrEmployeeID & " And Name : " & FK_Rep(StrDispName) & "','" & StrUserID & "',getdate ())"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'trMOde=1=First Name, trMode=2=Last Name, trMode=3= Accounr number
                    If Trim(strFirstName.ToUpper) <> Trim(txtFirstName.Text.ToUpper) Then
                        sqlQRY = "INSERT INTO tblChangesInEmp (RegID,trDate,oldData,newData,trMode,trDesc,crUser,stat,dispName,newDispName) VALUES ('" & StrEmployeeID & "',getdate (),'" & strFirstName & "','" & txtFirstName.Text & "','01','Change the employee first name','" & StrUserID & "',0,'" & FK_Rep(strOldDispName) & "','" & FK_Rep(StrDispName) & "')"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()
                    End If

                    If Trim(strLastName.ToUpper) <> Trim(txtLName.Text.ToUpper) Then
                        sqlQRY = "INSERT INTO tblChangesInEmp (RegID,trDate,oldData,newData,trMode,trDesc,crUser,stat,dispName,newDispName) VALUES ('" & StrEmployeeID & "',getdate (),'" & strLastName & "','" & txtLName.Text & "','02','Change the employee last name','" & StrUserID & "',0,'" & FK_Rep(strOldDispName) & "','" & FK_Rep(StrDispName) & "')"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()
                    End If
                    'If bolCalEx = False Then
                    '    sqlQRY = "insert into tblEmpRegister" & _
                    '    " select '" & StrEmployeeID & "','" & StrCompID & "',tblCalendar.cMonth,tblCalendar.cYear,tblCalendar.Date, " & _
                    '    " '19000101','19000101','19000101','19000101','19000101','19000101',0,0,0,0,'','',0,1,tblCalendar.DayID,tblCalendar.DayType,'','',0,0,0,0,0,'','',0,0 FROM tblCalendar WHERE cYear = " & intCurrentYear & ""
                    '    cmSave.CommandText = sqlQRY
                    '    cmSave.ExecuteNonQuery()
                    'End If

                    trSave.Commit()
                    Sv_Image(StrEmployeeID)
                    MsgBox("Employee Information Modified of " & StrDispName)
                    'sv_Leaves(StrCategoryID)
                    cmdRefresh_Click(sender, e)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Public Sub vieww(ByVal StrEid As String)

        Try
            Dim CN As New SqlConnection(sqlConString)
            CN.Open()

            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = New SqlCommand("SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & StrEid & "' and Status='0'", CN)
            Dim Data As New DataTable
            'adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn)

            Dim commandbuild As New SqlCommandBuilder(adapter)
            adapter.Fill(Data)
            ' MsgBox(Data.Rows.Count)
            picEmp.Image = My.Resources.User_Anonymous_Disabled
            If Data.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("svImage")
            Dim lstr As New System.IO.MemoryStream(lb)
            picEmp.Image = Image.FromStream(lstr)
            lstr.Close()
            ' picEmp.SizeMode = PictureBoxSizeMode.Zoom

            Dim iH As Integer = picEmp.Image.Height ' 648
            Dim iW As Integer = picEmp.Image.Width ' 432

            picEmp.SizeMode = PictureBoxSizeMode.Zoom
            If iH - iW < 0 Then
                picEmp.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            End If

            'Rounder corner
            'Dim gp As New GraphicsPath()
            'gp.AddEllipse(picEmp.DisplayRectangle)
            'picEmp.Region = New Region(gp)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ''End Sub

        ''Private Sub viewwk(ByVal StrEid As String)

        ''    Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM [tblImgInfo] where [ImgID]='" & StrEid & "'")
        ''    If bolEx = True Then
        ''        Dim quary As String = "SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & StrEid & "'"
        ''        Dim BytImag As Byte() = Nothing
        ''        Dim con As New SqlConnection(sqlConString)
        ''        Try
        ''            con.Open()
        ''            Dim selectCommand As New SqlCommand(quary, con)
        ''            Dim red As SqlDataReader = selectCommand.ExecuteReader()
        ''            While red.Read()
        ''                BytImag = red.Item(0)
        ''                picbyte2 = BytImag
        ''            End While

        ''        Catch ex As Exception
        ''            MessageBox.Show(ex.ToString())
        ''        Finally
        ''            con.Close()
        ''        End Try

        ''        picEmp.Image = Nothing
        ''        Dim FS1 As FileStream
        ''        FS1 = New FileStream("image6.jpg", FileMode.OpenOrCreate)
        ''        ' FS1.WriteByte(BytImag)
        ''        FS1.Write(BytImag, 0, BytImag.Length)
        ''        picEmp.Image = Image.FromStream(FS1)
        ''        picEmp.SizeMode = PictureBoxSizeMode.Zoom
        ''        picEmp.Refresh()
        ''        FS1.Close()
        ''        FS1 = Nothing
        ''    Else
        ''        picEmp.Image = Nothing
        ''    End If

    End Sub

    Public Sub Sv_Image(ByVal StrEid As String)

        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblImgInfo WHERE ImgID = '" & StrEid & "'")

        Dim sqlQRY As String
        Dim sqlQRY1 As String

        If picEmp.Image Is Nothing Then
            sqlQRY1 = "DELETE FROM tblImgInfo WHERE ImgID = '" & StrEid & "'"
            Dim cnDel As New SqlConnection(sqlConString)
            cnDel.Open()
            Dim cmDel As New SqlCommand(sqlQRY1, cnDel)
            cmDel.ExecuteNonQuery()
            Exit Sub
        End If

        If picbyte2 Is Nothing Then
            Exit Sub
        End If

        If bolEx = True Then
            sqlQRY = "UPDATE tblImgInfo SET SvImage = @SvImage WHERE ImgID = @imgID"

        Else
            sqlQRY = "INSERT INTO [tblImgInfo] ([ImgID],[svImage],[Status]) VALUES (@ImgID,@svImage,@Status)"
        End If

        Dim cnImgSv As New SqlConnection(sqlConString)
        cnImgSv.Open()
        Dim cmImgSv As New SqlCommand(sqlQRY, cnImgSv)
        Dim trImgSv As SqlTransaction = cnImgSv.BeginTransaction
        cmImgSv.Transaction = trImgSv
        Try
            With cmImgSv

                .Parameters.Add("@ImgID", SqlDbType.NVarChar)
                .Parameters.Add("@svImage", SqlDbType.Image)
                .Parameters.Add("@Status", SqlDbType.Int)

                .Parameters("@ImgID").Value = StrEid
                .Parameters("@svImage").Value = picbyte2
                .Parameters("@Status").Value = 0
                .ExecuteNonQuery()

            End With

            trImgSv.Commit()

        Catch ex As Exception
            MsgBox(ex.Message)
            trImgSv.Rollback()
        Finally
            cnImgSv.Close()
        End Try

    End Sub

    Public Sub pb_ShowEmployee(ByVal StrEmpNo As String)
        Dim crtlk As Control
        For Each crtlk In Me.pnlMyData.Controls
            If TypeOf crtlk Is ComboBox And crtlk.Tag = 4 Then
                crtlk.Enabled = False
                crtlk.ForeColor = Color.Blue
            End If
        Next

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.TitleID, dbo.tblSetTitle.titleDesc, dbo.tblEmployee.SurName, dbo.tblEmployee.FirstName, " & _
                      " dbo.tblEmployee.dispName,dbo.tblEmployee.NICNumber, dbo.tblEmployee.isEmpBOT ,dbo.tblEmployee.DofB, dbo.tblEmployee.CivilStID, dbo.tblCivilStatus.StDesc, dbo.tblEmployee.EmpNo ,dbo.tblEmployee.RegDate,tblEmployee.confirmDate, " & _
      "   dbo.tblEmployee.EnrolNo, dbo.tblEmployee.GenderID,  dbo.tblEmployee.epfNo, dbo.tblEmployee.callName,dbo.tblGender.GenDesc, EmpStatus, dbo.tblImgInfo.svImage, dbo.tblEmployee.empReqHours,dbo.tblEmployee.isShifed" & _
" FROM         dbo.tblEmployee LEFT OUTER JOIN" & _
  "                     dbo.tblCivilStatus ON dbo.tblEmployee.CivilStID = dbo.tblCivilStatus.StID LEFT OUTER JOIN" & _
    "                   dbo.tblImgInfo ON dbo.tblEmployee.RegID = dbo.tblImgInfo.ImgID LEFT OUTER JOIN" & _
      "                 dbo.tblGender ON dbo.tblEmployee.GenderID = dbo.tblGender.GenID LEFT OUTER JOIN" & _
        "               dbo.tblSetTitle ON dbo.tblEmployee.TitleID = dbo.tblSetTitle.titleID" & _
" WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"

        Dim sqlQRYSec2 As String = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.EpfNo,  dbo.tblEmployee.isEmpBOT ,dbo.tblEmployee.DesigID, dbo.tblDesig.desgDesc, dbo.tblEmployee.BrID, dbo.tblCBranchs.BrName, " & _
                 " dbo.tblEmployee.DeptID, dbo.tblSetDept.DeptName, dbo.tblEmployee.CatID, dbo.tblSetEmpCategory.CatDesc, dbo.tblEmployee.EmpTypeID, " & _
           " dbo.tblSetEmpType.tDesc, dbo.tblEmployee.ContractStart, dbo.tblEmployee.ContractEnd,dbo.tblEmployee.shiftID,tblSetShiftH.shiftName " & _
" FROM         dbo.tblEmployee LEFT OUTER JOIN" & _
                  " dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN" & _
                 " dbo.tblCBranchs ON dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND dbo.tblEmployee.CompID = dbo.tblCBranchs.CompID LEFT OUTER JOIN" & _
                 " dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN" & _
                 " dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID LEFT OUTER JOIN" & _
                  " dbo.tblSetShiftH ON dbo.tblEmployee.shiftID = dbo.tblSetShiftH.shiftID LEFT OUTER JOIN" & _
                 " dbo.tblSetEmpType ON dbo.tblEmployee.EmpTypeID = dbo.tblSetEmpType.TypeID" & _
" WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"


        Dim sqlQRYSec3 As String = "SELECT     dbo.tblEmployee.DefAddID, dbo.tblEmployee.homePhone, dbo.tblEmployee.pMobile, dbo.tblEmployee.CntrPeriod, dbo.tblEmployee.OfficePhone, dbo.tblEmployee.Email, " & _
        " dbo.tblEmpAddress.Add1, dbo.tblEmpAddress.Add2, dbo.tblEmpAddress.Add3" & _
" FROM         dbo.tblEmpAddress LEFT OUTER JOIN" & _
                     " dbo.tblEmployee ON dbo.tblEmpAddress.AddID = dbo.tblEmployee.DefAddID AND dbo.tblEmpAddress.EmpID = dbo.tblEmployee.RegID" & _
" WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"

        Try

            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader

            If drShw.Read = True Then
                txtRegNo.Text = StrEmployeeID
                dtpRegDate.Value = IIf(IsDBNull(drShw.Item("RegDate")), DateSerial(1900, 1, 1), drShw.Item("RegDate"))
                StrTitleID = IIf(IsDBNull(drShw.Item("TitleID")), "", drShw.Item("TitleID"))
                cmbTItle.Text = IIf(IsDBNull(drShw.Item("titleDesc")), "", drShw.Item("titleDesc"))
                txtLName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("SurName")), "", drShw.Item("SurName")))
                txtFirstName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("FirstName")), "", drShw.Item("FirstName")))
                strFirstName = txtFirstName.Text
                strLastName = txtLName.Text
                StrDispName = FK_UndoRep(IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName")))
                strOldDispName = FK_UndoRep(IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName")))
                strExsNic = IIf(IsDBNull(drShw.Item("NICNumber")), "", drShw.Item("NICNumber"))
                txtNICNumber.Text = strExsNic
                dtpDofB.Value = IIf(IsDBNull(drShw.Item("DofB")), DateSerial(1900, 1, 1), drShw.Item("DofB"))
                StrGenderID = IIf(IsDBNull(drShw.Item("GenderID")), "", drShw.Item("GenderID"))
                cmbGender.Text = IIf(IsDBNull(drShw.Item("GenDesc")), "", drShw.Item("GenDesc"))
                StrCivilStID = IIf(IsDBNull(drShw.Item("CivilStID")), "", drShw.Item("CivilStID"))
                cmbCivilSt.Text = IIf(IsDBNull(drShw.Item("StDesc")), "", drShw.Item("StDesc"))
                'txtAge.Text = DateDiff(DateInterval.Year, dtpDofB.Value, dtWorkingDate)
                Dim intAge As Integer = DateDiff(DateInterval.Month, dtpDofB.Value, dtWorkingDate)
                Dim intYear As Integer = intAge \ 12
                Dim intMonth As Integer = intAge Mod 12
                txtAge.Text = intYear & " Y : " & intMonth & " M "

                intExsEnNo = IIf(IsDBNull(drShw.Item("EnrolNo")), 0, drShw.Item("EnrolNo"))
                txtEnrolNo.Text = intExsEnNo
                txtEpfNo.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("EpfNo")), "", drShw.Item("EpfNo")))
                txtEmpNo.Text = IIf(IsDBNull(drShw.Item("EmpNo")), "", drShw.Item("EmpNo"))
                chkIsBOT.CheckState = IIf(IsDBNull(drShw.Item("IsEmpBOT")), 0, drShw.Item("IsEmpBOT"))
                dtpConfDate.Value = IIf(IsDBNull(drShw.Item("confirmDate")), DateSerial(1900, 1, 1), drShw.Item("confirmDate"))
                Dim intT As Integer = IIf(IsDBNull(drShw.Item("EmpStatus")), 1, drShw.Item("EmpStatus"))
                If intT = 9 Then
                    chkCancel.Checked = True
                Else
                    chkCancel.Checked = False
                End If
                txtOTforMonth.Text = IIf(IsDBNull(drShw.Item("empReqHours")), "", drShw.Item("empReqHours"))
                chkShift.CheckState = IIf(IsDBNull(drShw.Item("isShifed")), 0, drShw.Item("isShifed"))
                txtCallName.Text = IIf(IsDBNull(drShw.Item("callName")), "", drShw.Item("callName"))

                get_FullName(cmbTItle.Text, txtFirstName.Text, txtLName.Text)
                vieww(StrEmployeeID)

                StrSvStatus = "E"
                'sv_Leaves(StrCategoryID)
            Else
                StrSvStatus = "S"

            End If

            drShw.Close()

            'Second Section is filled
            Dim cmShwSec2 As New SqlCommand(sqlQRYSec2, cnShw)
            Dim drShwSec2 As SqlDataReader = cmShwSec2.ExecuteReader

            If drShwSec2.Read = True Then
                StrDesgID = IIf(IsDBNull(drShwSec2.Item("DesigID")), "", drShwSec2.Item("DesigID"))
                cmbDesignation.Text = IIf(IsDBNull(drShwSec2.Item("DesgDesc")), "", drShwSec2.Item("DesgDesc"))
                StrBranchID = IIf(IsDBNull(drShwSec2.Item("BrID")), "", drShwSec2.Item("BrID"))
                cmbBranch.Text = IIf(IsDBNull(drShwSec2.Item("BrName")), "", drShwSec2.Item("BrName"))
                StrDeptID = IIf(IsDBNull(drShwSec2.Item("DeptID")), "", drShwSec2.Item("DeptID"))
                cmbDept.Text = IIf(IsDBNull(drShwSec2.Item("DeptName")), "", drShwSec2.Item("DeptName"))
                StrCategoryID = IIf(IsDBNull(drShwSec2.Item("CatID")), "", drShwSec2.Item("CatID"))
                cmbEmpCategory.Text = IIf(IsDBNull(drShwSec2.Item("CatDesc")), "", drShwSec2.Item("CatDesc"))
                StrEmpTypeID = IIf(IsDBNull(drShwSec2.Item("EmpTypeID")), "", drShwSec2.Item("EmpTypeID"))
                cmbEmpType.Text = IIf(IsDBNull(drShwSec2.Item("TDesc")), "", drShwSec2.Item("TDesc"))
                dtpCFrom.Value = IIf(IsDBNull(drShwSec2.Item("ContractStart")), "1/1/1900", drShwSec2.Item("ContractStart"))
                dtpCTo.Value = IIf(IsDBNull(drShwSec2.Item("ContractEnd")), "1/1/1900", drShwSec2.Item("ContractEnd"))
                strShiftID = IIf(IsDBNull(drShwSec2.Item("shiftID")), "", drShwSec2.Item("shiftID"))
                cmbShift.Text = IIf(IsDBNull(drShwSec2.Item("shiftName")), "", drShwSec2.Item("shiftName"))
            End If
            drShwSec2.Close()

            Dim cmShwSec3 As New SqlCommand(sqlQRYSec3, cnShw)
            Dim drShwSec3 As SqlDataReader = cmShwSec3.ExecuteReader

            If drShwSec3.Read = True Then

                StrDefAddID = IIf(IsDBNull(drShwSec3.Item("DefAddID")), "", drShwSec3.Item("DefAddID"))
                txthPhone.Text = IIf(IsDBNull(drShwSec3.Item("homePhone")), "", drShwSec3.Item("homePhone"))
                txtmPhone.Text = IIf(IsDBNull(drShwSec3.Item("pMobile")), "", drShwSec3.Item("pMobile"))
                txtEmail.Text = IIf(IsDBNull(drShwSec3.Item("Email")), "", drShwSec3.Item("Email"))
                txtOfficePhone.Text = IIf(IsDBNull(drShwSec3.Item("OfficePhone")), "", drShwSec3.Item("OfficePhone"))
                txtCrPeriod.Text = IIf(IsDBNull(drShwSec3.Item("CntrPeriod")), "0", drShwSec3.Item("CntrPeriod"))
                txtmAdd1.Text = FK_UndoRep(IIf(IsDBNull(drShwSec3.Item("Add1")), "", drShwSec3.Item("Add1")))
                txtmAdd2.Text = FK_UndoRep(IIf(IsDBNull(drShwSec3.Item("Add2")), "", drShwSec3.Item("Add2")))
                txtmAdd3.Text = FK_UndoRep(IIf(IsDBNull(drShwSec3.Item("Add3")), "", drShwSec3.Item("Add3")))

            End If
            drShwSec3.Close()
            bolIsLoad = False

            lblName.Text = StrDispName
            lblBranchtop.Text = "Branch : " & cmbBranch.Text
            lblDesignation.Text = "Designation : " & cmbDesignation.Text
            lblEmpNumb.Text = "Emp No : " & txtEmpNo.Text
            lblAddres.Text = "Address : " & txtmAdd1.Text & " " & txtmAdd2.Text & " " & txtmAdd3.Text
            lblBirth.Text = "Birthday : " & Format(dtpDofB.Value, "dd-MM-yyyy")
            lbldepeartment.Text = "Department : " & cmbDept.Text
            lblEmail.Text = "Email : " & txtEmail.Text

        Catch ex As Exception
            MsgBox("Error Occured while Reading the Database. " + ex.Message)
        Finally
            cnShw.Close()
        End Try

        'sqlQRY = "SELECT tblEmployee.RegID,tblEmployee.RegDate,tblEmployee.TitleID,dbo.fk_RetTitle(tblEmployee.TitleID,'01') As 'tDesc', " & _
        '" tblEmployee.SurName,tblEmployee.FirstName,tblEmployee.dispName,tblEmployee.NICNumber,tblEmployee.DofB,tblEmployee.GenderID, " & _
        '" dbo.fk_RetGender(tblEmployee.GenderID,'01') As gDesc, " & _
        '" tblEmployee.CivilStID,dbo.fk_RetCStatus (tblEmployee.CivilStID,'01') As cStDesc, tblEmployee.EmpNo,tblEmployee.EpfNo,tblEmployee.CompID," & _
        '" tblEmployee.DesigID,dbo.fk_RetDesigs(tblEmployee.DesigID,'01') as DsgDesc,tblEmployee.BrID,dbo.fk_RetBranches(tblEmployee.CompID,BrID,'01') As BrName, " & _
        '" tblEmployee.DeptID,dbo.fk_RetDepts(tblEmployee.DeptID,'01') As DeptName, tblEmployee.CatID,dbo.fk_RetCategory(tblEmployee.CatID,'01') As CatDesc, " & _
        '" tblEmployee.EmpTypeID,dbo.fk_RetEmpTYpe(tblEmployee.EmpTypeID,'01') As TypeDesc, tblEmployee.DefAddID, tblEmployee.homePhone, " & _
        '" tblEmployee.pMobile, tblEmployee.OfficePhone,tblEmployee.EnrolNo, tblEmployee.Email, tblEmployee.CntrPeriod, tblEmployee.CardID, tblEmployee.StatusDate, tblEmployee.NoAdds, tblEmployee.EmpStatus, " & _
        '" tblEmpAddress.AddID,tblEmpAddress.Add1,tblEmpAddress.Add2,tblEmpAddress.Add3,tblEmployee.ContractStart ,tblEmployee.ContractEnd  " & _
        '" FROM tblEmployee INNER JOIN tblEmpAddress ON tblEmployee.RegID = tblEmpAddress.EmpID AND tblEmployee.CompID = tblEmpAddress.CompID AND tblEmpAddress.AddID = tblEmployee.DefAddID WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"


        'Try
        '    Dim cmShw As New SqlCommand(sqlQRY, cnShw)
        '    Dim drShw As SqlDataReader = cmShw.ExecuteReader
        '    If drShw.Read = True Then

        '        'RegID, , , , , , , , " & _"
        '        '    " ,,,,CompID,,," & _
        '        '    " , , , , , , , , , CardID, " & _
        '        '    " StatusDate, NoAdds, EmpStatus








        'StrSvStatus = "E"




        '    Else
        'StrSvStatus = "S"
        '    End If


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnShw.Close()
        'End Try

    End Sub

    Public Sub get_FullName(ByVal StrTl As String, ByVal StrFN As String, ByVal StrLN As String)

        StrDispName = StrTl & " " & GetInitialsFromString(RTrim(StrFN)) & " " & StrLN
        'StrFlName = RTrim(StrFN) & " " & StrLN

    End Sub

    Private Sub txtSName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLName.Leave

        strSurNameClr = txtLName.Text.Trim
        Do While (strSurNameClr.IndexOf(Space(2)) >= 0)
            strSurNameClr = strSurNameClr.Replace(Space(2), Space(1))
        Loop

        get_FullName(cmbTItle.Text, strFNamesClr, strSurNameClr)
        txtLName.Text = strSurNameClr

    End Sub

    Private Sub txtFirstName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFirstName.Leave

        strFNamesClr = txtFirstName.Text.Trim
        Do While (strFNamesClr.IndexOf(Space(2)) >= 0)
            strFNamesClr = strFNamesClr.Replace(Space(2), Space(1))
        Loop
        txtFirstName.Text = strFNamesClr
        get_FullName(cmbTItle.Text, strFNamesClr, strSurNameClr)

        lblName.Text = StrDispName
        lblBranchtop.Text = "Branch : " & cmbBranch.Text
        lblEmpNumb.Text = "Emp No : " & txtEmpNo.Text

    End Sub

    Private Sub txtNICNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNICNumber.Leave

        Try
            Call IDNum_Results(txtNICNumber.Text)

            dtpDofB.Value = dtNICDoB
            cmbGender.Text = StrNICSex
            txtAge.Text = DateDiff(DateInterval.Year, dtpDofB.Value, dtWorkingDate)
            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblEMployee WHERE NicNumber = '" & txtNICNumber.Text & "' AND compID = '" & StrCompID & "' AND tblEMployee.empStatus<>9")

            If StrSvStatus = "S" Then
                If bolEx = True Then
                    MsgBox("You Can't Process Save due to Duplicate NIC number", MsgBoxStyle.Critical)

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRegNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pb_ShowEmployee(txtRegNo.Text)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim crtl As Control
        'For Each crtl In Me.Panel3.Controls
        '    If TypeOf crtl Is Form Then

        '    End If
        'Next
        'GroupBox3.Visible = True

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim crtl As Control
        'For Each crtl In Me.Panel3.Controls
        '    If TypeOf crtl Is GroupBox Then
        '        crtl.Controls.Clear()
        '    End If
        'Next
        Dim frmReg As New frmEmpAddress
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        'Me.Panel3.Controls.Add(frmReg)

        frmReg.Show()

    End Sub

    Private Sub cmbTItle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTItle.Leave
        get_FullName(cmbTItle.Text, txtFirstName.Text, txtLName.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'frmMasterEmployee.Timer1.Stop()

        strReActEmp = "Ac"

        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
        "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then

                'StrEmployeeID = FK_Read("RegID")
                pb_ShowEmployee(StrEmployeeID)
                'strKEmProfileID = StrEmployeeID

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try

        'frmMasterEmployee.Timer1.Start()
        'Dim frmBrs As New frmSrchEmployee
        'frmBrs.ShowDialog()

    End Sub

    'Private Sub txtEpfNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEpfNo.TextChanged
    '    txtEnrolNo.Text = txtEpfNo.Text
    'End Sub

    Private Sub cmdClrImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        picEmp.Image = Nothing
    End Sub

    Private Sub txtSName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLName.TextChanged
        If StrSvStatus = "S" Then
            txtCallName.Text = txtLName.Text
        End If
    End Sub

    Private Sub txtAge_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAge.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If


    End Sub
    Private Sub txtEnrolNo_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEnrolNo.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

    End Sub

    Private Sub txtRegNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLName.KeyPress, txtOfficePhone.KeyPress, txtNICNumber.KeyPress, txtmPhone.KeyPress, txtmAdd3.KeyPress, txtmAdd2.KeyPress, txtmAdd1.KeyPress, txthPhone.KeyPress, txtFirstName.KeyPress, txtEpfNo.KeyPress, txtEnrolNo.KeyPress, txtEmail.KeyPress, txtCrPeriod.KeyPress, txtAge.KeyPress, dtpRegDate.KeyPress, dtpDofB.KeyPress, cmdSave.KeyPress, cmdRefresh.KeyPress, cmbTItle.KeyPress, cmbGender.KeyPress, cmbEmpType.KeyPress, cmbEmpCategory.KeyPress, cmbDesignation.KeyPress, cmbDept.KeyPress, cmbCivilSt.KeyPress, cmbBranch.KeyPress
        Dim crtl As Control
        crtl = sender
        If AscW(e.KeyChar) = 13 Then
            crtl = GetNextControl(sender, True)
            crtl.Focus()

        End If
    End Sub
    Private Sub txthPhone_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthPhone.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
    Private Sub txtmPhone_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmPhone.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
    Private Sub txtOfficePhone_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOfficePhone.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtNICNumber_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNICNumber.KeyPress

        If txtNICNumber.TextLength <= 8 Then
            If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Asc(e.KeyChar) = 8) Then
                e.Handled = False
            End If
        End If
        If (Asc(e.KeyChar) = 39) Then
            e.Handled = True
        End If

    End Sub
    Private Sub txtCrPeriod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCrPeriod.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

    End Sub

    Private Sub dtpCF_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCFrom.ValueChanged
        'txtCrPeriod.Text = DateDiff(DateInterval.Month, dtpCF.Value, dtpCt.Value)
        'Dim span As TimeSpan = dtpCt.Value.Subtract(dtpCF.Value)
        'txtCrPeriod.Text = (dtpCt.Value.Month - dtpCF.Value.Month).ToString
        Dim intMonth As Integer = 0
        Dim dtpCF2 As New DateTimePicker
        Dim dtpCt2 As New DateTimePicker
        dtpCF2.Value = dtpCFrom.Value
        dtpCt2.Value = dtpCTo.Value
        dtpCt2.Value = dtpCt2.Value.AddDays(2)

        While dtpCF2.Value.Date < dtpCt2.Value.Date
            dtpCF2.Value = dtpCF2.Value.AddMonths(1)
            intMonth = intMonth + 1
        End While
        intMonth = intMonth - 1
        txtCrPeriod.Text = (IIf(intMonth < 0, 0, intMonth)).ToString
        dtpCTo.MinDate = dtpCFrom.Value.Date
    End Sub

    Private Sub dtpCt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCTo.ValueChanged
        Dim intMonth As Integer = 0
        Dim dtpCF2 As New DateTimePicker
        Dim dtpCt2 As New DateTimePicker
        dtpCF2.Value = dtpCFrom.Value
        dtpCt2.Value = dtpCTo.Value
        dtpCt2.Value = dtpCt2.Value.AddDays(2)

        While dtpCF2.Value.Date < dtpCt2.Value.Date
            dtpCF2.Value = dtpCF2.Value.AddMonths(1)
            intMonth = intMonth + 1
        End While
        intMonth = intMonth - 1
        txtCrPeriod.Text = (IIf(intMonth < 0, 0, intMonth)).ToString

    End Sub

    Private Sub dtpRegDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRegDate.ValueChanged

        dtpCFrom.Value = dtpRegDate.Value.Date
        dtpConfDate.Value = DateAdd(DateInterval.Month, 12, dtpRegDate.Value.Date)

    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If frmMainAttendance.SetTitlesToolStripMenuItem.Enabled = True Then


        'End If

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetDesignation
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()

        'ListCombo(cmbDesignation, "select * from tblDesig where status = 0 order by desgID", "desgDesc")

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetCBranchs
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbBranch, "SELECT * FROM tblCBranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID", "BrName")

        'End If

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetDepartment
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "DeptName")

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetCategory
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbEmpCategory, "select * From tblSEtEmpCategory WHERE Status = 0 ORder By CatID", "catDesc")

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetEmpTypes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbEmpType, "SELECT * FROM tblSetEmpType WHERE Status = 0 Order By TypeID", "tDesc"

    End Sub

    'Private Sub Button1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Me.Button1.FlatStyle = FlatStyle.Standard
    '    Me.Button1.FlatAppearance.BorderSize = 1
    '    Me.Button1.Width = 24
    '    Me.Button1.Height = 24

    'End Sub

    'Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)

    '    Me.Button1.FlatStyle = FlatStyle.Flat
    '    Me.Button1.FlatAppearance.BorderSize = 0
    '    Me.Button1.Width = 22
    '    Me.Button1.Height = 22

    'End Sub

    Private Sub picEDesig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEDesig.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbDesignation.Text
        strExsistedCode = StrDesgID

        If StrSvStatus = "E" Then

            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "001"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()
            'End If

        Else
            Exit Sub
        End If

    End Sub

    Private Sub picEBr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEBr.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbBranch.Text
        strExsistedCode = StrBranchID
        If StrSvStatus = "E" Then

            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "002"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub PicEDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEDept.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbDept.Text
        strExsistedCode = StrDeptID
        If StrSvStatus = "E" Then
            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "003"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub picECat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picECat.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbEmpCategory.Text
        strExsistedCode = StrCategoryID
        If StrSvStatus = "E" Then
            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True


            StrTTrMode = "004"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub picEType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEType.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbEmpType.Text
        strExsistedCode = StrEmpTypeID
        If StrSvStatus = "E" Then
            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "005"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub chkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCancel.Click
        If chkCancel.Checked = True Then
            'Get Transaction 
            Dim iTr As Integer = fk_sqlDbl("SELECT NoTrs FROM tblControl") + 1
            Dim StrTr As String = fk_CreateSerial(10, iTr)

            sSQL = "UPDATE tblEmployee SET EmpStatus = 9,StatusDate = '" & Format(dtWorkingDate, strRetDateTimeFormat) & "' WHERE RegID = '" & Trim(txtRegNo.Text) & "'" & _
                " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES " & _
                " ('" & StrTr & "','" & Format(dtWorkingDate, strRetDateTimeFormat) & "','" & Me.Name & "','CE','Cancel Employee','" & StrUserID & "',0,1,'" & Trim(txtRegNo.Text) & "')"
            FK_EQ(sSQL, "E", "", True, True, True)
        End If
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        cmdPrevious.Enabled = True
        If StrSvStatus = "S" Then MessageBox.Show("Please select employee first", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

        Try
            Dim Et As String = ""
            StrEmployeeID = fk_RetString("SELECT Min(isnull(regid,0)) FROM tblEmployee WHERE regid > '" & txtRegNo.Text & "' and tblemployee.empstatus<>9")
            If fk_RetString("SELECT Max(RegID) FROM tblEmployee WHERE tblemployee.empstatus<>9") = StrEmployeeID Then
                MessageBox.Show("You reached to last page", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmdNext.Enabled = False
            End If
            If StrEmployeeID <> "" Then
                Dim crtl As Control
                For Each crtl In Me.pnlMyData.Controls
                    If TypeOf crtl Is TextBox Then
                        crtl.Text = ""
                    End If
                Next
                pb_ShowEmployee(StrEmployeeID)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        cmdNext.Enabled = True
        Try
            Dim Et As String = ""
            StrEmployeeID = fk_RetString("SELECT Max(regID) FROM tblEmployee WHERE regID< '" & txtRegNo.Text & "' and tblemployee.empstatus<>9")
            If fk_RetString("SELECT Min(RegID) FROM tblEmployee WHERE tblemployee.empstatus<>9") = StrEmployeeID Then
                MessageBox.Show("You reached to first page", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmdPrevious.Enabled = False
            End If
            If StrEmployeeID <> "" Then
                Dim crtl As Control
                For Each crtl In Me.pnlMyData.Controls
                    If TypeOf crtl Is TextBox Then
                        crtl.Text = ""
                    End If
                Next
                pb_ShowEmployee(StrEmployeeID)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub picEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEmp.DoubleClick
        Dim dr As DialogResult = MessageBox.Show("Do you want add photo ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If dr = Windows.Forms.DialogResult.No Then
            picEmp.Image = Nothing

        End If

        Dim imagename As String
        Try
            Dim fldlg As FileDialog = New OpenFileDialog()
            fldlg.InitialDirectory = "D:\"
            fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
            If fldlg.ShowDialog() = DialogResult.OK Then
                imagename = fldlg.FileName
                Dim newimg As New Bitmap(imagename)
                picEmp.Image = newimg
                picEmp.SizeMode = PictureBoxSizeMode.Zoom
                Dim fs As FileStream
                fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
                Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
                picbyte2 = picbyte
                fs.Close()
            End If
            fldlg = Nothing

        Catch ae As System.ArgumentException
            imagename = " "
            MessageBox.Show(ae.Message.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        ''Dim dr As DialogResult = MessageBox.Show("Do you want add photo ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        ''If dr = Windows.Forms.DialogResult.No Then
        ''    picEmp.Image = Nothing

        ''End If

        ''Dim imagename As String
        ''Dim StrFileNameOnly As String = ""
        ''Dim StrFilePathOnly As String = ""
        ''Dim StrNewFilePatha As String = ""
        ''Try
        ''    Dim fldlg As FileDialog = New OpenFileDialog()
        ''    fldlg.InitialDirectory = "D:\"
        ''    fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
        ''    If fldlg.ShowDialog() = DialogResult.OK Then
        ''        imagename = fldlg.FileName
        ''        StrFileNameOnly = System.IO.Path.GetFileName(fldlg.FileName)
        ''        StrFileNameOnly = "A_" & StrFileNameOnly
        ''        StrFilePathOnly = System.IO.Path.GetDirectoryName(fldlg.FileName)
        ''        StrNewFilePatha = StrFilePathOnly & "\" & StrFileNameOnly
        ''        StrNewFilePatha = TestRotate(imagename, StrNewFilePatha)
        ''        imagename = StrNewFilePatha
        ''        Dim newimg As New Bitmap(imagename)
        ''        picEmp.Image = newimg

        ''        Dim fs As FileStream
        ''        fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
        ''        Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
        ''        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
        ''        picbyte2 = picbyte
        ''        fs.Close()
        ''    End If
        ''    fldlg = Nothing

        ''Catch ae As System.ArgumentException
        ''    imagename = " "
        ''    MessageBox.Show(ae.Message.ToString())
        ''Catch ex As Exception
        ''    MessageBox.Show(ex.Message.ToString())
        ''End Try

        '[20181018] remove by prasanna - for fantasia image insert 
        'Dim dr As DialogResult = MessageBox.Show("Do you want add photo ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        'If dr = Windows.Forms.DialogResult.No Then
        '    picEmp.Image = Nothing

        'End If

        'Dim imagename As String
        'Try
        '    Dim fldlg As FileDialog = New OpenFileDialog()
        '    fldlg.InitialDirectory = "D:\"
        '    fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
        '    If fldlg.ShowDialog() = DialogResult.OK Then
        '        '    imagename = fldlg.FileName
        '        '    Dim newimg As New Bitmap(imagename)
        '        '    picEmp.Image = newimg
        '        '    picEmp.SizeMode = PictureBoxSizeMode.Zoom
        '        '    Dim fs As FileStream
        '        '    fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
        '        '    Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
        '        '    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
        '        '    picbyte2 = picbyte
        '        '    fs.Close()
        '        'End If
        '        'fldlg = Nothing

        '        imagename = fldlg.FileName
        '        Dim newimg As New Bitmap(imagename)
        '        picEmp.Image = newimg
        '        Dim iH As Integer = picEmp.Image.Height ' 648
        '        Dim iW As Integer = picEmp.Image.Width ' 432

        '        picEmp.SizeMode = PictureBoxSizeMode.Zoom
        '        If iH - iW < 0 Then
        '            picEmp.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        '        End If
        '        '
        '        Dim fs As FileStream
        '        fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
        '        Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
        '        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
        '        picbyte2 = picbyte
        '        fs.Close()
        '    End If
        '    fldlg = Nothing


        'Catch ae As System.ArgumentException
        '    imagename = " "
        '    MessageBox.Show(ae.Message.ToString())
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString())
        'End Try

    End Sub

    Private Sub cmdEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmployee.Click
        Me.pnlPublic.Controls.Clear()
        Me.pnlPublic.Controls.Add(pnlMyData)
        strClickedEmp = "cmdEmployee"
        ButtonClicked()
    End Sub

    Private Sub ButtonClicked()

        Select Case strClickedEmp

            Case "cmdEmployee"
                Me.cmdEmployee.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdEmployee.FlatStyle = FlatStyle.Standard
                'Me.cmdEmployee.FlatAppearance.BorderSize = 1
                'Me.cmdEmployee.Width = 89
                'Me.cmdEmployee.Height = 79
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdAddress"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdAddress.FlatStyle = FlatStyle.Standard
                'Me.cmdAddress.FlatAppearance.BorderSize = 1
                'Me.cmdAddress.Width = 89
                'Me.cmdAddress.Height = 79
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdCardData"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                'Me.cmdCardData.Width = 89
                'Me.cmdCardData.Height = 79
                Me.cmdCardData.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdCardData.FlatStyle = FlatStyle.Standard
                'Me.cmdCardData.FlatAppearance.BorderSize = 1
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdLeve"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdLeve.FlatStyle = FlatStyle.Standard
                'Me.cmdLeve.FlatAppearance.BorderSize = 1
                'Me.cmdLeve.Width = 89
                'Me.cmdLeve.Height = 79
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdShifts"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdShifts.FlatStyle = FlatStyle.Standard
                'Me.cmdShifts.FlatAppearance.BorderSize = 1
                'Me.cmdShifts.Width = 89
                'Me.cmdShifts.Height = 79
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdAttns"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdAttns.FlatStyle = FlatStyle.Standard
                'Me.cmdAttns.FlatAppearance.BorderSize = 1
                'Me.cmdAttns.Width = 89
                'Me.cmdAttns.Height = 79
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing

            Case "cmdFamilly"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                'Me.cmdAttns.FlatStyle = FlatStyle.Standard
                'Me.cmdAttns.FlatAppearance.BorderSize = 1
                'Me.cmdAttns.Width = 89
                'Me.cmdAttns.Height = 79
                Me.cmdFamily.BackgroundImage = My.Resources.mainEmployeeInfo
                Me.cmdTraining.BackgroundImage = Nothing

            Case "cmdTraining"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                'Me.cmdAttns.FlatStyle = FlatStyle.Standard
                'Me.cmdAttns.FlatAppearance.BorderSize = 1
                'Me.cmdAttns.Width = 89
                'Me.cmdAttns.Height = 79
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = My.Resources.mainEmployeeInfo
        End Select

    End Sub

    Private Sub cmdShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShifts.Click
        'strClickedEmp = "cmdShifts"
        'Me.pnlPublic.Controls.Clear()
        'Dim frmReg As New frmEmpShift
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized

        'frmReg.TopLevel = False
        'Me.pnlPublic.Controls.Add(frmReg)

        'frmReg.Show()
        'ButtonClicked()

        Dim AdvanHRIDDetails As Integer = fk_sqlDbl("select AdvanHRIDDetails from tblControl ")
        If AdvanHRIDDetails = 1 Then
            'strClickedEmp = "cmdShifts"
            'Me.pnlPublic.Controls.Clear()
            'Dim frmReg As New frmHRMAdtionalInfomation
            'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'frmReg.WindowState = FormWindowState.Maximized

            'frmReg.TopLevel = False
            'Me.pnlPublic.Controls.Add(frmReg)

            'frmReg.Show()
            'ButtonClicked()

        Else
            strClickedEmp = "cmdShifts"
            Me.pnlPublic.Controls.Clear()
            Dim frmReg As New frmEmpShift
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg)

            frmReg.Show()
            ButtonClicked()
        End If
    End Sub

    Private Sub cmdAttns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAttns.Click
        strClickedEmp = "cmdAttns"
        Me.pnlPublic.Controls.Clear()
        Dim frmReg As New frmEmpAttendance
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClicked()
    End Sub

    Private Sub cmdAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddress.Click
        strClickedEmp = "cmdAddress"
        Me.pnlPublic.Controls.Clear()
        Dim frmReg As New frmEmpAddress
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClicked()

        'strClickedEmp = "cmdAddress"
        'Me.pnlPublic.Controls.Clear()
        'Dim frmReg As New frmHRMAdtionalInfomation
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized

        'frmReg.TopLevel = False
        'Me.pnlPublic.Controls.Add(frmReg)

        'frmReg.Show()
        'ButtonClicked()
    End Sub

    Private Sub cmdCardData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCardData.Click
        strClickedEmp = "cmdCardData"
        Me.pnlPublic.Controls.Clear()
        If IntIsPayrolDataEnabled = 1 Then
            If UP("Payroll Data", "View payroll data from attendance") = False Then Exit Sub
            Dim frmReg As New frmPayrollData
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized
            frmReg.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg)
            frmReg.Show()
            ButtonClicked()
        Else

        End If
    End Sub

    Private Sub cmdLeve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeve.Click
        strClickedEmp = "cmdLeve"
        Me.pnlPublic.Controls.Clear()
        Dim frmReg As New frmEmpLeave
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClicked()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdFamily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFamily.Click
        Try
            strClickedEmp = "cmdFamilly"
            If IsFamilyInfo = 0 Then
                Exit Sub
            End If
            Me.pnlPublic.Controls.Clear()
            Dim frmReg1 As New frmEmpRelationInfo
            frmReg1.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg1.WindowState = FormWindowState.Maximized

            frmReg1.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg1)

            frmReg1.Show()
            ButtonClicked()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub cmdTraining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraining.Click
        'strClickedEmp = "cmdTraining"
        '' If IsAdditionalHRModule = 0 Then
        ''Exit Sub
        '' End If
        'Me.pnlPublic.Controls.Clear()
        ''Me.pnlPublic.Refresh()
        ''Me.pnlPublic.Invalidate()
        'Dim frmReg As New frmHRMInfomation
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized

        'frmReg.TopLevel = False
        'Me.pnlPublic.Controls.Add(frmReg)

        'frmReg.Show()
        'ButtonClicked()
    End Sub

    Private Sub txtRegNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtEnrolNo.Text = CDbl(txtRegNo.Text)
    End Sub

    Private Sub txtEnrolNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnrolNo.TextChanged
        txtEpfNo.Text = txtEnrolNo.Text.ToString.PadLeft(6, "0")
    End Sub

    Private Sub txtEpfNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEpfNo.TextChanged
        txtEmpNo.Text = txtEpfNo.Text
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetShiftType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbShift, "SELECT * FROM tblsetShifth WHERE Status = 0 Order By shiftID", "shiftName")
    End Sub

    Private Sub cmbShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShift.SelectedIndexChanged
        strShiftID = fk_RetString("SELECT shiftID FROM tblSetShiftH WHERE shiftName = '" & cmbShift.Text & "'")
    End Sub

    Private Sub PictureBox26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.Click
        LoadForm(New frmSetTitle)
        ListCombo(cmbTItle, "SELECT * FROM tblSetTitle WHERE Status = 0 Order By titleID", "titleDesc")
    End Sub

    Private Sub PictureBox25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.Click
        LoadForm(New frmSetGender)
        ListCombo(cmbTItle, "SELECT * FROM tblGender WHERE Status = 0 Order By gendesc", "titleDesc")

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Length = 0 Or txtSearch.Text.Length Mod 2 = 1 Then
            ViewEmployee()
        End If
    End Sub

    Private Sub cmdScroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScroll.Click
        If pnlMostRLeft.Width = 357 Then
            pnlMostRLeft.Width = 0
        Else
            ViewEmployee()
        End If

        'If pnlEditHistory.Height = 244 Then
        pnlEditHistory.Height = 0
        'Else
        'pnlAllEmpInfo.Height = 28
        'End If

    End Sub

    Private Sub cmdScroll_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScroll.MouseHover
        cmdScroll_Click(sender, e)
    End Sub

    Private Sub dgvAllEmp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellClick
        'StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value)
        'pb_ShowEmployee(StrEmployeeID)
    End Sub

    Private Sub dgvAllEmp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellDoubleClick
        pnlMostRLeft.Width = 0
        pnlEditHistory.Height = 0

        If strClickedEmp = "cmdEmployee" Then
            cmdEmployee_Click(sender, e)
        ElseIf strClickedEmp = "cmdLeve" Then
            cmdLeve_Click(sender, e)
        ElseIf strClickedEmp = "cmdShifts" Then
            cmdShifts_Click(sender, e)
        ElseIf strClickedEmp = "cmdAttns" Then
            cmdAttns_Click(sender, e)
        ElseIf strClickedEmp = "cmdAddress" Then
            cmdAddress_Click(sender, e)
        ElseIf strClickedEmp = "cmdCardData" Then
            cmdCardData_Click(sender, e)
        ElseIf strClickedEmp = "cmdFamilly" Then
            cmdFamily_Click(sender, e)
        ElseIf strClickedEmp = "cmdTraining" Then
            cmdTraining_Click(sender, e)
        End If
    End Sub

    Private Sub txtEmpNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpNo.Leave
        lblName.Text = StrDispName
        lblBranchtop.Text = "Branch : " & cmbBranch.Text
        lblDesignation.Text = "Designation : " & cmbDesignation.Text
        lblEmpNumb.Text = "Emp No : " & txtEmpNo.Text
    End Sub

    Private Sub dgvAllEmp_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellEndEdit

    End Sub

    Private Sub dgvAllEmp_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellEnter
        Try
            If bolIsLoad = False Then
                If StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value) Then Exit Try
                StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value)
                pb_ShowEmployee(StrEmployeeID)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAllEmp_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvAllEmp.RowPrePaint

        'Try
        '    If StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value) Then Exit Try
        '    StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value)
        '    pb_ShowEmployee(StrEmployeeID)
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub rdbCancel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCancel.Click
        ViewEmployee()
    End Sub

    Private Sub rdbActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbActive.Click
        ViewEmployee()
    End Sub

End Class