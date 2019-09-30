Public Class frmEmployeePayItem

    Dim bolCombo As Boolean = False
    Dim strQueryPart As String = ""

    Private Sub frmEmployeeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If StrEmployeeID <> "" Then
            txtNo.Text = StrEmployeeID
            If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"

            fk_Return_MultyString("select " & strQuery & ",tblPayrollEmployee.DispName,tblsetdept.DeptName from tblPayrollEmployee,tblsetdept where tblsetdept.deptID=tblPayrollEmployee.deptID and tblPayrollEmployee.RegID='" & Trim(txtNo.Text) & "'", 3)
            txtName.Text = dgvMultiGRID.Item(1, 0).Value
            txtEmPnO.Text = dgvMultiGRID.Item(0, 0).Value
            txtDept.Text = dgvMultiGRID.Item(2, 0).Value
            sSQL = "SELECT * FROM tblEmployeeFormulaField WHERE EmpID = '" & StrEmployeeID & "'"
            Fk_FillGrid(sSQL, dgvFormula)

            sSQL = "SELECT * FROM tblEmployeeFixedField WHERE EmpID = '" & StrEmployeeID & "'"
            Fk_FillGrid(sSQL, dgvFixed)

            sSQL = "SELECT * FROM tblEmpAdvAttFormula WHERE RegID = '" & StrEmployeeID & "'"
            Fk_FillGrid(sSQL, dgvAdAtForm)

            btnRefresh_Click(sender, e)
        End If
        CenterFormThemed(Me, Panel1, Label12)
        ControlHandlers(Me)
        Label3.BackColor = clrFocused
        btnRefresh_Click(sender, e)

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click

        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
        FillComboAll(cmbDepartment, "select DeptName + '=' + DeptID from tblsetDept where status=0")
        FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0")
        FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0")
        'FillCombo(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
        FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0")
        FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0")
        FillComboAll(cmbDesignation, "Select DesgDesc + '=' + DesgID from tblDesig where status=0")
        FillComboAll(cmbPrCatagory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0")
        FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0")
        'txtSearch.Text = "k"
        'txtSearch.Text = ""
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
        FillComboAll(cmbEmpType, "select tDesc + '=' +TypeID from tblSetEmpType WHERE Status=0 ORDER BY tDesc")
        FillComboAll(cmbGender, "select GenDesc + '=' + genID from tblGender WHERE Status=0 ORDER BY GenDesc")
        FillComboAll(cmbReligion, "select Dscrb + '=' + actID from tblSetActTypesHRIS WHERE Status=0 ORDER BY Dscrb")
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************

        If bolUnAssignedFormula = True Then
            sSQL = "SELECT     'true',dbo.tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EmIdNum, " & _
         "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, " & _
                    "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM  " & _
        "dbo.tblPayrollEmployee " & _
        "Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID  " & _
        "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND  " & _
        "dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID " & _
        "LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID  " & _
        "LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID  " & _
        "LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID  " & _
        "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID  " & _
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblPayrollEmployee.sub_catID = dbo.tblSetEmpCategory.catID  " & _
        "LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID  " & _
        "LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID   " & _
        "LEFT OUTER JOIN dbo.tbltempregid ON dbo.tblPayrollEmployee.RegID = dbo.tbltempregid.RegID  " & _
        " where tblPayrollEmployee.status=0 AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0) AND tblPayrollEmployee.RegID in (select regid from tbltempregid) ORDER BY " & strQuery & ""
            bolUnAssignedFormula = False
            FK_LoadGrid(sSQL, dgvEmp)
            clr_Grid(dgvEmp)
            lblCount.Text = "Total Employees : " & dgvEmp.RowCount
            chkTick.CheckState = CheckState.Checked
            Exit Sub
        End If
        chkTick.CheckState = CheckState.Unchecked
        PB.Value = 0
        PB.Visible = False
        lblProgress.Visible = False
        StrEmployeeID = ""
        chkAttendanceAllowan.Checked = True
        chkFixed.Checked = True
        chkFormula.Checked = True
        cmbPrCatagory.SelectedIndex = 0
    End Sub

    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrCatagory.SelectedIndexChanged
        ' bolCombo = True
       SearchEmployee()
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
       SearchEmployee()
    End Sub

    Private Sub cmbDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignation.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbbranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbranch.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbPayCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPayCenter.SelectedIndexChanged
       SearchEmployee()
    End Sub

    Private Sub cmbCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostCenter.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbSubCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubCategory.SelectedIndexChanged
        SearchEmployee()
        'txtSearch.Text = FK_GetIDL(cmbSubCategory.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox1.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        SearchEmployee()
    End Sub

    Public Sub SearchEmployee()
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"
        Dim StrDeptname As String = IIf(cmbDepartment.Text = "[ALL]", "", FK_GetIDL(cmbDepartment.Text))
        Dim StrSubCatName As String = IIf(cmbSubCategory.Text = "[ALL]", "", FK_GetIDL(cmbSubCategory.Text))
        Dim StrDesigName As String = IIf(cmbDesignation.Text = "[ALL]", "", FK_GetIDL(cmbDesignation.Text))
        Dim StrBranchName As String = IIf(cmbbranch.Text = "[ALL]", "", FK_GetIDL(cmbbranch.Text))
        Dim StrCompany As String = IIf(cmbCompany.Text = "[ALL]", "", FK_GetIDL(cmbCompany.Text))
        Dim StrPrCategorya As String = IIf(cmbPrCatagory.Text = "[ALL]", "", FK_GetIDL(cmbPrCatagory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDL(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDL(cmbCostCenter.Text))

        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
        Dim StrGender As String = IIf(cmbGender.Text = "[ALL]", "", FK_GetIDR(cmbGender.Text))
        Dim StrEmpType As String = IIf(cmbEmpType.Text = "[ALL]", "", FK_GetIDR(cmbEmpType.Text))
        Dim StrReligion As String = IIf(cmbReligion.Text = "[ALL]", "", FK_GetIDR(cmbReligion.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun >*********************************

        If bolCombo = True Then
            sSQL = "SELECT     'False',dbo.tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EmIdNum, " & _
   "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, " & _
   "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM  " & _
   "dbo.tblPayrollEmployee " & _
   "Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID  " & _
   "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND  " & _
   "dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID " & _
   "LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue  " & _
   "LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID  " & _
   "LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID  " & _
   "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID  " & _
   "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblPayrollEmployee.sub_catID = dbo.tblSetEmpCategory.catID  " & _
   "LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblPayrollEmployee.EmpTypeID = dbo.tblSetEmpType.typeID " & _
   "LEFT OUTER JOIN dbo.tblSetActTypesHRIS ON dbo.tblPayrollEmployee.actID = dbo.tblSetActTypesHRIS.actID " & _
   "LEFT OUTER JOIN dbo.tblGender ON dbo.tblPayrollEmployee.genderID = dbo.tblGender.GenID " & _
   "LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID  " & _
   "LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID   " & _
   "where tblPayrollEmployee.status=0 AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0) "

        Else
            sSQL = "SELECT     'False',dbo.tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EmIdNum, " & _
                    "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, " & _
                    "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM  " & _
                    "dbo.tblPayrollEmployee " & _
                    "Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID  " & _
                    "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND  " & _
                    "dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID " & _
                    "LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID  " & _
                    "LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID  " & _
                    "LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID  " & _
                    "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID  " & _
                    "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblPayrollEmployee.sub_catID = dbo.tblSetEmpCategory.catID  " & _
                    "LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblPayrollEmployee.EmpTypeID = dbo.tblSetEmpType.typeID " & _
                    "LEFT OUTER JOIN dbo.tblSetActTypesHRIS ON dbo.tblPayrollEmployee.actID = dbo.tblSetActTypesHRIS.actID " & _
                    "LEFT OUTER JOIN dbo.tblGender ON dbo.tblPayrollEmployee.genderID = dbo.tblGender.GenID " & _
                    "LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID  " & _
                    "LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID   " & _
                    "where tblPayrollEmployee.status=0 AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0) " & _
                    "AND (dbo.tblPayrollEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayrollEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR  " & _
                    "dbo.tblPayrollEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayrollEmployee.EmIdNum LIKE '%" & txtSearch.Text & "%' OR  " & _
                    "dbo.tblPayrollEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND (dbo.tblCompany.cName LIKE '%" & StrCompany & "%' AND  " & _
                    "dbo.tblDesig.desgDesc LIKE '%" & StrDesigName & "%' AND  " & _
                    "dbo.tblSetDept.deptName LIKE '%" & StrDeptname & "%' AND  " & _
                    "dbo.tblSetEmpCategory.catDesc LIKE '%" & StrSubCatName & "%' AND  " & _
                    "dbo.tblSetCCentre.cntDesc LIKE '%" & StrCostC & "%' AND  " & _
                    "dbo.tblCBranchs.BrName LIKE '%" & StrBranchName & "%' AND  " & _
                    "dbo.tblSetEmpType.typeID LIKE '" & StrEmpType & "%' AND  " & _
                    "dbo.tblGender.genID LIKE '" & StrGender & "%' AND  " & _
                    "dbo.tblSetActTypesHRIS.actID LIKE '" & StrReligion & "%' AND  " & _
                    "dbo.tblSetPCentre.pDesc LIKE '%" & StrPayC & "%' AND  " & _
                    "tblSetPrCategory.CatDesc LIKE '%" & StrPrCategorya & "%') ORDER BY tblPayrollEmployee.RegID"
        End If
        
        FK_LoadGrid(sSQL, dgvEmp)
        clr_Grid(dgvEmp)
        For X = 0 To dgvEmp.Columns.Count - 1
            'dgvSearchK.Columns(X).HeaderText = UCase(dgvSearchK.Columns(X).HeaderText)
            dgvEmp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        dgvEmp.Columns(1).Visible = False
        If isViewBasic = 0 Then dgvEmp.Columns(8).Visible = False
        lblCount.Text = "Total Employees : " & dgvEmp.RowCount

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where tblPayrollEmployee.status=0  AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0) "
        txtNo.Text = fk_browse(sSQL, "*", "RegID,DispName,EMPNo,EmIdNum,EpFno")
        If txtNo.Text = "" Then Exit Sub
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"

        fk_Return_MultyString("select " & strQuery & ",tblPayrollEmployee.DispName,tblsetdept.DeptName from tblPayrollEmployee,tblsetdept where tblsetdept.deptID=tblPayrollEmployee.deptID and tblPayrollEmployee.RegID='" & Trim(txtNo.Text) & "'", 3)
        txtName.Text = dgvMultiGRID.Item(1, 0).Value
        txtEmPnO.Text = dgvMultiGRID.Item(0, 0).Value
        txtDept.Text = dgvMultiGRID.Item(2, 0).Value

        Dim strEmpID As String = Trim(txtNo.Text)
        sSQL = "SELECT * FROM tblEmployeeFormulaField WHERE EmpID = '" & strEmpID & "'"
        Fk_FillGrid(sSQL, dgvFormula)

        sSQL = "SELECT * FROM tblEmployeeFixedField WHERE EmpID = '" & strEmpID & "'"
        Fk_FillGrid(sSQL, dgvFixed)

        sSQL = "SELECT * FROM tblEmpAdvAttFormula WHERE RegID = '" & strEmpID & "'"
        Fk_FillGrid(sSQL, dgvAdAtForm)

    End Sub

    Private Sub chkTick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTick.CheckedChanged
        For i = 0 To dgvEmp.RowCount - 1
            dgvEmp.Item(0, i).Value = chkTick.CheckState
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If txtNo.Text = "" Then MessageBox.Show("Please Slect Employee First", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtNo.Focus() : Exit Sub
        PB.Visible = True
        lblProgress.Visible = False
        PB.Value = 0
        PB.Maximum = dgvEmp.RowCount
        Dim BOlHasREcord As Boolean = False
        Dim bolContinue As Boolean = False

        If chkFixed.CheckState = CheckState.Checked Then
            sSQL = ""
            For ik = 0 To dgvEmp.RowCount - 1
                PB.Value = ik
                If dgvEmp.Item(0, ik).Value = True Or Val(dgvEmp.Item(0, ik).Value) = 1 Then
                    sSQL = sSQL & "Delete from tblEmployeeFixedField where EmpID='" & dgvEmp.Rows(ik).Cells(1).Value & "'; "
                    For i = 0 To dgvFixed.RowCount - 1
                        If dgvFixed.Rows(i).Cells(0).Value = True Or Val(dgvFixed.Rows(i).Cells(0).Value) = 1 Then
                            sSQL = sSQL & "Insert into tblEmployeeFixedField (EMPID,ID) values ('" & dgvEmp.Rows(ik).Cells(1).Value & "','" & dgvFixed.Rows(i).Cells(1).Value & "');"
                            BOlHasREcord = True
                        End If
                    Next
                End If
            Next

            If sSQL <> "" Then
                If BOlHasREcord = False Then MessageBox.Show("You are tring to clear ALL FIXED FIELD ITEMS from selected employee(s), Please be care full", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If FK_EQ(sSQL, "P", "", True, True, True) = True Then bolContinue = True : PB.Value = PB.Maximum Else bolContinue = False
            End If

        End If

        If chkFormula.CheckState = CheckState.Checked Then
            'If bolContinue = True Then
            PB.Value = 0
            PB.Maximum = dgvEmp.RowCount
            BOlHasREcord = False
            sSQL = ""
            For ik = 0 To dgvEmp.RowCount - 1
                PB.Value = ik
                If dgvEmp.Item(0, ik).Value = True Or Val(dgvEmp.Item(0, ik).Value) = 1 Then
                    sSQL = sSQL & "Delete from tblEmployeeFormulaField where EmpID='" & dgvEmp.Rows(ik).Cells(1).Value & "'; "
                    For i = 0 To dgvFormula.RowCount - 1
                        If dgvFormula.Rows(i).Cells(0).Value = True Or Val(dgvFormula.Rows(i).Cells(0).Value) = 1 Then
                            sSQL = sSQL & "Insert into tblEmployeeFormulaField (EMPID,ID) values ('" & dgvEmp.Rows(ik).Cells(1).Value & "','" & dgvFormula.Rows(i).Cells(1).Value & "');"
                            BOlHasREcord = True
                        End If
                    Next
                End If
            Next

            If sSQL <> "" Then
                If BOlHasREcord = False Then MessageBox.Show("You are tring to clear ALL FORMULA ITEMS from selected employee(s), Please be care full", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If FK_EQ(sSQL, "P", "", True, True, True) = True Then bolContinue = True : PB.Value = PB.Maximum Else bolContinue = False
            End If
            'End If
        End If

        If chkAttendanceAllowan.CheckState = CheckState.Checked Then
            'If bolContinue = True Then
            PB.Value = 0
            PB.Maximum = dgvEmp.RowCount
            BOlHasREcord = False
            sSQL = ""
            For ik = 0 To dgvEmp.RowCount - 1
                PB.Value = ik
                If dgvEmp.Item(0, ik).Value = True Or Val(dgvEmp.Item(0, ik).Value) = 1 Then
                    sSQL = sSQL & "Delete from tblEmpAdvAttFormula where RegID='" & dgvEmp.Rows(ik).Cells(1).Value & "'; "
                    For i = 0 To dgvAdAtForm.RowCount - 1
                        If dgvAdAtForm.Rows(i).Cells(0).Value = True Or Val(dgvAdAtForm.Rows(i).Cells(0).Value) = 1 Then
                            sSQL = sSQL & "Insert into tblEmpAdvAttFormula (RegID,Formula,SalID,ProID) values ('" & dgvEmp.Rows(ik).Cells(1).Value & "','" & dgvAdAtForm.Rows(i).Cells(1).Value & "','" & dgvAdAtForm.Rows(i).Cells(2).Value & "','" & dgvAdAtForm.Rows(i).Cells(3).Value & "');"
                            BOlHasREcord = True
                        End If
                    Next
                End If
            Next

            If sSQL <> "" Then
                If BOlHasREcord = False Then MessageBox.Show("You are tring to clear ALL ATTENDANCE FORMULA ITEMS from selected employee(s), Please be care full", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                If FK_EQ(sSQL, "P", "", True, True, True) = True Then bolContinue = True : PB.Value = PB.Maximum : btnRefresh_Click(sender, e) Else bolContinue = False
            End If
            'End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpType.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbReligion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReligion.SelectedIndexChanged
        SearchEmployee()
    End Sub

End Class