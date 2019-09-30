Imports System.Data.SqlClient

Public Class frmEPFReport

    'Dim Thread1 As System.Threading.Thread
    Dim bolTicked As Boolean = False

    Public Sub saveFilteredToTemp()
        Try
            Dim bSelected As Boolean = False
            For X = 0 To dgvSearchK.RowCount - 1
                If dgvSearchK.Item(0, X).Value = True Or Val(dgvSearchK.Item(0, X).Value) = 1 Then
                    bSelected = True : Exit For
                End If
            Next
            If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub
            sSQL = "Create table tblTempRegID (RegID varchar (15),cYear Decimal(18,0) not null Default 0,cMonth Decimal(18,0) not null Default 0)"
            EQ(sSQL)
            sSQL = "DELETE FROM tblTempRegID; Declare @RegID varchar(15)          "
            bolTicked = True
            For X = 0 To dgvSearchK.RowCount - 1
                If dgvSearchK.Item(0, X).Value = True Or Val(dgvSearchK.Item(0, X).Value) = 1 Then sSQL = sSQL & "       Set @RegID='" & dgvSearchK.Item(1, X).Value & "'             IF not EXISTS (Select RegID from tblTempRegID where RegID=@RegID and cYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "')         BEGIN     Insert into tblTempRegID (regID,cYear,cMonth) values (@RegID,'" & Val(cmbYear.Text) & "','" & Val(cmbMonth.Text) & "')       End "
            Next
            FK_EQ(sSQL, "S", "", False, False, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Try
            cmbYear.Text = Now.Year
            cmbMonth.Items.Clear()
            For X = 1 To 12
                cmbMonth.Items.Add(X)
            Next
            cmbMonth.Text = Now.Month
            cmbMonth.Text = Now.Date.Month

            For X = Now.Date.Year - 5 To Now.Date.Year + 5
                cmbYear.Items.Add(X)
            Next

            FillComboAll(cmbDepartment, "select DeptName + '=' + DeptID from tblsetDept where status=0")
            FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0")
            FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0")
            'FillComboAll(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
            FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0")
            FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0")
            FillComboAll(cmbDesignation, "Select DesgDesc + '=' + DesgID from tblDesig where status=0")
            FillComboAll(cmbPrCatagory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0")
            FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0")

            FillComboAll(cmb8, "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status=0 order by Description;")
            FillComboAll(cmb12, "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status=0 order by Description;")
            FillComboAll(cmbTotal, "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status=0 order by Description;")
            FillComboAll(cmb15, "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status=0 order by Description;")
            FillComboAll(cmb20, "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status=0 order by Description;")
            FillComboAll(cmb3, "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status=0 order by Description;")
            FillComboAll(cmbBank, "  Select BankName+'='+BankID from tblBanks where status=0")
            FillComboAll(cmbBBranch, "Select BranchName+'='+BrID from tblBranches where status='0' ")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
            FillComboAll(cmbEmpType, "select tDesc + '=' +TypeID from tblSetEmpType WHERE Status=0 ORDER BY tDesc")
            FillComboAll(cmbGender, "select GenDesc + '=' + genID from tblGender WHERE Status=0 ORDER BY GenDesc")
            FillComboAll(cmbReligion, "select ReligDesc + '=' + ReligID from tblSetReligion WHERE Status=0 ORDER BY ReligDesc")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************

            Dim ctrl As Control
            For Each ctrl In GroupBox1.Controls
                If TypeOf ctrl Is ComboBox Then
                    ctrl.Text = ""
                End If
            Next

            sSQL = "Select RegNo,cYear,right('00' + convert(varchar(3),cmonth),2) as 'cmonth',EPF3,EPF8,EPF12,EPF15,EPF20,TotEar,chqNo,bankName,brancName from [tblEPFAllData]"
            If FK_ReadDB(sSQL) = True Then
                txtRegNo.Text = FK_Read("RegNo")
                cmbYear.Text = FK_Read("cYear")
                cmbMonth.Text = FK_Read("cMonth")
                cmb3.Text = FK_Read("EPF3")
                cmb8.Text = FK_Read("EPF8")
                cmb12.Text = FK_Read("EPF12")
                cmb15.Text = FK_Read("EPF15")
                cmb20.Text = FK_Read("EPF20")
                cmbTotal.Text = FK_Read("TotEar")
                txtChqNo.Text = FK_Read("chqNo")
                cmbBank.Text = FK_Read("bankName")
                cmbBBranch.Text = FK_Read("brancName")
            End If

            'txtSearch.Text = ""
            intPrcdMonth = fk_sqlDbl("select distinct cmonth from tblsd")
            cmbMonth.Text = intPrcdMonth
            'cmbColumns.SelectedIndex = 0
            cmbPrCatagory.Text = strPrCategory
            chkTick.Checked = True

            strPrCategory = fk_RetString("select processategory from tblCompany where compID='" & StrCompID & "'")
            strPrCategory = fk_RetString("select '" & strPrCategory & "'+'='+catid from tblSetPrCategory where catDesc='" & strPrCategory & "'")

            Button1.Enabled = True
            Button2.Enabled = True
            cmdRefresh.Enabled = True
            CheckForIllegalCrossThreadCalls = False
            rdbEPFRepotr.Checked = True
            bolSelectBranch = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub SearchEmployee()
        If cmbYear.Text = "" Then MessageBox.Show("Please select year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        If cmbMonth.Text = "" Then MessageBox.Show("Please select month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        PB.Value = 0
        PB1.Value = 0
        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"

        Dim StrDeptname As String = IIf(cmbDepartment.Text = "[ALL]", "", FK_GetIDR(cmbDepartment.Text))
        Dim StrSubCatName As String = IIf(cmbSubCategory.Text = "[ALL]", "", FK_GetIDR(cmbSubCategory.Text))
        Dim StrDesigName As String = IIf(cmbDesignation.Text = "[ALL]", "", FK_GetIDR(cmbDesignation.Text))
        Dim StrBranchName As String = IIf(cmbbranch.Text = "[ALL]", "", FK_GetIDR(cmbbranch.Text))
        Dim StrCompany As String = IIf(cmbCompany.Text = "[ALL]", "", FK_GetIDR(cmbCompany.Text))
        Dim StrPrCategorya As String = IIf(cmbPrCatagory.Text = "[ALL]", "", FK_GetIDR(cmbPrCatagory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDR(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDR(cmbCostCenter.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
        Dim StrGender As String = IIf(cmbGender.Text = "[ALL]", "", FK_GetIDR(cmbGender.Text))
        Dim StrEmpType As String = IIf(cmbEmpType.Text = "[ALL]", "", FK_GetIDR(cmbEmpType.Text))
        Dim StrReligion As String = IIf(cmbReligion.Text = "[ALL]", "", FK_GetIDR(cmbReligion.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun >*********************************

        sSQL = "SELECT     'true',dbo.tblPayEmpMRecords.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayEmpMRecords.DispName, dbo.tblPayEmpMRecords.EmIdNum, " &
        "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary, " &
        "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM   " &
        "dbo.tblPayEmpMRecords,tblSetCCentre ,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblUL,tblSetEmpType,tblGender,tblSetReligion  " &
        " where dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND" &
        " dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND  " &
        " dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND " &
        " dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND " &
        " dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND " &
        " dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND " &
        " dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND " &
        " dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND   " &
        " dbo.tblPayEmpMRecords.EmpTypeID = dbo.tblSetEmpType.typeID  AND " &
        " dbo.tblPayEmpMRecords.religionID = dbo.tblSetReligion.religID  AND " &
        " dbo.tblPayEmpMRecords.genderID = dbo.tblGender.GenID  AND " &
        " tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND " &
        " tblPayEmpMRecords.status=0 AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayEmpMRecords.SalViewLevel =0) " &
        "AND (dbo.tblPayEmpMRecords.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.DispName LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.EmIdNum LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.EPFNo LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.BasicSalary LIKE '%" & txtSearch.Text & "%') " &
        "AND (dbo.tblCompany.compID LIKE '" & StrCompany & "%' AND  " &
        "dbo.tblDesig.desgID LIKE '" & StrDesigName & "%' AND  " &
        "dbo.tblSetDept.DeptID LIKE '" & StrDeptname & "%' AND  " &
        "dbo.tblSetEmpCategory.catID LIKE '" & StrSubCatName & "%' AND  " &
        "dbo.tblSetCCentre.cntID LIKE '" & StrCostC & "%' AND  " &
        "dbo.tblCBranchs.brID LIKE '" & StrBranchName & "%' AND  " &
        "dbo.tblSetEmpType.typeID LIKE '" & StrEmpType & "%' AND  " &
        "dbo.tblGender.genID LIKE '" & StrGender & "%' AND  " &
        "dbo.tblSetReligion.religID LIKE '" & StrReligion & "%' AND  " &
        "dbo.tblSetPCentre.pID LIKE '" & StrPayC & "%' AND  " &
        "tblSetPrCategory.CatID LIKE '" & StrPrCategorya & "%') " &
        " AND tblPayEmpMRecords.cYear=" & cmbYear.Text & " AND tblPayEmpMRecords.cMonth=" & cmbMonth.Text & " ORDER BY " & strQuery
        FK_LoadGrid(sSQL, dgvSearchK)
        clr_Grid(dgvSearchK)
        For X = 0 To dgvSearchK.Columns.Count - 1
            'dgvSearchK.Columns(X).HeaderText = UCase(dgvSearchK.Columns(X).HeaderText)
            dgvSearchK.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        dgvSearchK.Columns(1).Visible = False
        If isViewBasic = 0 Then dgvSearchK.Columns(8).Visible = False
        GroupBox1.Text = "Filtered Employee(s) : " & dgvSearchK.RowCount

    End Sub

    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrCatagory.SelectedIndexChanged
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
        If cmbbranch.Text = "[ALL]" Then bolSelectBranch = False Else bolSelectBranch = True
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
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        SearchEmployee()
    End Sub

    Private Sub chkTick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTick.CheckedChanged
        For i = 0 To dgvSearchK.RowCount - 1
            dgvSearchK.Item(0, i).Value = chkTick.CheckState
        Next
    End Sub

    Private Sub rdPermanant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPermanant.CheckedChanged
        If rdTemporary.Checked = True Then
            ssql1 = "Select distinct cMonth from tblSD"
        Else
            ssql1 = "Select distinct cmonth from tblSDAll"
        End If
        FillComboAll(cmbMonth, ssql1)
    End Sub

    Private Sub LoadCombo()
        If rdTemporary.Checked Then
            sSQL = "Select distinct cYear from tblSD"
            FillComboAll(cmbYear, sSQL)
        Else
            sSQL = "Select distinct cYear from tblSDAll"
            FillComboAll(cmbYear, sSQL)
        End If
    End Sub

    Private Sub rdTemporary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTemporary.CheckedChanged
        LoadCombo()
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbYear.Text <> "" And cmbMonth.Text <> "" Then
            SearchEmployee()
        End If
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If cmbYear.Text <> "" And cmbMonth.Text <> "" Then
            SearchEmployee()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UP("Payslip Process", "Do Payslip Process") = False Then Exit Sub
        If cmbYear.Text = "" Then MsgBox("Please Select Year", MsgBoxStyle.Information) : cmbYear.Focus() : Exit Sub
        'If FK_GetIDR(cmbSalarySheet.Text) = "" Then MsgBox("Please Select Salary Sheet From the List", MsgBoxStyle.Information) : cmbSalarySheet.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MsgBox("Please Select month", MsgBoxStyle.Information) : cmbMonth.Focus() : Exit Sub
        If cmb12.Text = "" Or cmb12.Text = "[ALL]" Then MsgBox("Please Select EPF 12%", MsgBoxStyle.Information) : cmb12.Focus() : Exit Sub
        If cmb15.Text = "" Or cmb15.Text = "[ALL]" Then MsgBox("Please Select EPF 15%", MsgBoxStyle.Information) : cmb15.Focus() : Exit Sub
        If cmb20.Text = "" Or cmb20.Text = "[ALL]" Then MsgBox("Please Select EPF 20%", MsgBoxStyle.Information) : cmb20.Focus() : Exit Sub
        If cmb3.Text = "" Or cmb3.Text = "[ALL]" Then MsgBox("Please Select EPF 3%", MsgBoxStyle.Information) : cmb3.Focus() : Exit Sub
        If cmb8.Text = "" Or cmb8.Text = "[ALL]" Then MsgBox("Please Select EPF 8%", MsgBoxStyle.Information) : cmb8.Focus() : Exit Sub
        If cmb15.Text = "" Or cmb15.Text = "[ALL]" Then MsgBox("Please Select EPF 15%", MsgBoxStyle.Information) : cmb15.Focus() : Exit Sub
        If cmbTotal.Text = "" Then MsgBox("Please Select Total for EPF Item %", MsgBoxStyle.Information) : cmbTotal.Focus() : Exit Sub
        If rdbCForm.Checked = True Then
            If cmbBank.Text = "" Then MsgBox("Please Select Bank name", MsgBoxStyle.Information) : cmbBank.Focus() : Exit Sub
            If cmbBBranch.Text = "" Then MsgBox("Please Select Branch name", MsgBoxStyle.Information) : cmbBank.Focus() : Exit Sub
            If txtChqNo.Text = "" Then MsgBox("Please Type Cheque Number", MsgBoxStyle.Information) : txtChqNo.Focus() : Exit Sub
        End If
        Filling()
        'Thread1 = New System.Threading.Thread(AddressOf Filling)
        'Thread1.IsBackground = True
        'Thread1.Start()
    End Sub

    Private Sub Filling()
        Try
            Button1.Enabled = False
            Button2.Enabled = False
            cmdRefresh.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            saveFilteredToTemp()
            If bolTicked = False Then Exit Sub
            bolTicked = False

            Try
                If rdPermanant.Checked = True Then
                    sSQL = "EXEC sp_EPFAll '" & cmbYear.Text & "'," & cmbMonth.Text & "," & FK_GetIDR(cmb8.Text) & "," & FK_GetIDR(cmb12.Text) & "," & FK_GetIDR(cmb3.Text) & "," & FK_GetIDR(cmb15.Text) & "," & FK_GetIDR(cmb20.Text) & "," & FK_GetIDR(cmbTotal.Text) & ""
                    FK_EQ(sSQL, "P", "", False, False, True)
                ElseIf rdTemporary.Checked = True Then
                    sSQL = "EXEC sp_EPFAllTemp '" & cmbYear.Text & "'," & cmbMonth.Text & "," & FK_GetIDR(cmb8.Text) & "," & FK_GetIDR(cmb12.Text) & "," & FK_GetIDR(cmb3.Text) & "," & FK_GetIDR(cmb15.Text) & "," & FK_GetIDR(cmb20.Text) & "," & FK_GetIDR(cmbTotal.Text) & ""
                    FK_EQ(sSQL, "P", "", False, False, True)
                End If

                'AITKENSPENCE EPF15=EPF8% OR EPF %10
                If isWithLogo = 11 Or isWithLogo = 16 Then
                    txtTotContribution.Text = fk_sqlDbl("select sum(epf8)+sum(epf12)+sum(epf15) from tblEPFReport where regid in (select regid from tbltempregid)")
                    If rdbCForm.Checked = True Then
                        sSQL = "UPDATE tblEPFReport SET epf12=epf15 WHERE EPF12=0" : FK_EQ(sSQL, "E", "", False, False, True)
                    End If
                Else
                    txtTotContribution.Text = fk_sqlDbl("select sum(epf8)+sum(epf12) from tblEPFReport where regid in (select regid from tbltempregid)")
                End If
                txtRemittance.Text = Val(txtTotContribution.Text) - Val(txtSerCharge.Text)

                Dim strQuery As String = ""
                If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"

                'sSQL = " Select tblPayrollEmployee.RegID,tblPayrollEmployee.DispName,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "', tblPayrollEmployee.EPFNo,tblPayrollEmployee.ETPNo,tblPayrollEmployee.ComID, tblCompany.cName,tblPayrollEmployee.DesigID,tblDesig.desgDesc,tblPayrollEmployee.BrID,tblCBranchs.BrName,tblPayrollEmployee.DeptID,tblSetDept.DeptName, tblPayrollEmployee.BasicSalary,tblPayrollEmployee.DaysPay,tblPayrollEmployee.EpfAllowed, tblPayrollEmployee.PayID,tblSetPCentre.pDesc,tblPayrollEmployee.CostID,tblSetCCentre.cntDesc, tblPayrollEmployee.EmIdNum,tblPayrollEmployee.Status,tblPayrollEmployee.PrCatID, tblSetPrCategory.CatDesc,tblUL.LevelName,tblPayrollEmployee.SalViewLevel from tblPayrollEmployee " & _
                '          " left outer join tblCompany on tblPayrollEmployee.ComID = tblCompany.CompID " & _
                '          " left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID" & _
                '          " left outer join tblCBranchs on tblPayrollEmployee.BrID = tblCBranchs.BrID" & _
                '          " left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID" & _
                '          " left outer join tblSetPCentre on tblPayrollEmployee.PayID = tblSetPCentre.pID" & _
                '          " left outer join tblSetCCentre on tblPayrollEmployee.CostID = tblSetCCentre.CntID" & _
                '          " left outer join tblSetPrCategory on tblPayrollEmployee.PrCatID = tblSetPrCategory.CatID" & _
                '          " left outer join tblUL on tblPayrollEmployee.SalViewLevel = tblUL.LevelValue" & _
                '          " where tblPayrollEmployee.Status=0 and tblPayrollEmployee.RegID in (select regid from tblTempRegID)"

                'sSQL = "SELECT  dbo.tblPayEmpMRecords.RegID,dbo.tblPayEmpMRecords.DispName,RIGHT('00000'+CAST(tblPayEmpMRecords.EMPNo AS VARCHAR(6)),6) as 'EMPNo' , tblPayrollemployee.EPFNo,tblPayrollemployee.ETPNo,tblPayrollemployee.comID,dbo.tblCompany.cName,tblPayrollemployee.desigID, dbo.tblDesig.desgDesc, tblPayrollemployee.brID, dbo.tblCBranchs.BrName,tblPayrollemployee.deptID,dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary,tblPayrollemployee.daysPay,tblPayrollemployee.epfAllowed,tblPayrollemployee.payID,tblSetPCentre.pDesc,tblPayrollemployee.costID,'',tblPayrollemployee.emIDNum,0,tblPayrollemployee.prCatID,tblSetPrCategory.CatDesc,'',tblPayrollemployee.salViewLevel  FROM   dbo.tblPayEmpMRecords,tblSetCCentre,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblUL,tblPayrollemployee  where  dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND   dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND  dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND  dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND  dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND  dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND  dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND   tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND   tblPayrollemployee.regID=tblPayEmpMRecords.regID  AND  tblPayEmpMRecords.status=0 AND tblPayEmpMRecords.DeptID In ('001','002','003','004','005','006','007','008','009','012','013','014','015','016','017','018','019','020','021','025','026') AND tblPayEmpMRecords.BrID In ('001','002','003','004','005') AND (tblUL.LevelValue  <= 9999 Or tblPayEmpMRecords.SalViewLevel =0) AND (dbo.tblPayEmpMRecords.RegID LIKE '%%' OR dbo.tblPayEmpMRecords.DispName LIKE '%%' OR  dbo.tblPayEmpMRecords.EMPNo LIKE '%%' OR dbo.tblPayEmpMRecords.EmIdNum LIKE '%%' OR  dbo.tblPayEmpMRecords.EPFNo LIKE '%%' OR  dbo.tblPayEmpMRecords.BasicSalary LIKE '%%') AND (dbo.tblCompany.cName LIKE '%' AND  dbo.tblDesig.desgDesc LIKE '%' AND  dbo.tblSetDept.deptName LIKE '%' AND  dbo.tblSetEmpCategory.catDesc LIKE '%' AND  dbo.tblSetCCentre.cntDesc LIKE '%' AND  dbo.tblCBranchs.BrName LIKE '%' AND  dbo.tblSetPCentre.pDesc LIKE '%' AND  tblSetPrCategory.CatDesc LIKE 'AITKEN SPENCE PRINTING AND PACKAGING %')  AND tblPayEmpMRecords.cYear=2015 AND tblPayEmpMRecords.cMonth=11 and tblPayEmpMRecords.regid in (SELECT REGID FROM tblTempRegID) ORDER BY tblPayEmpMRecords.EMPNo"
                sSQL = "SELECT    dbo.tblPayEmpMRecords.RegID,dbo.tblPayEmpMRecords.DispName,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , " &
        " tblPayrollemployee.EPFNo,tblPayrollemployee.ETPNo,tblPayrollemployee.comID,dbo.tblCompany.cName,tblPayrollemployee.desigID, dbo.tblDesig.desgDesc, tblPayrollemployee.brID, dbo.tblCBranchs.BrName,tblPayrollemployee.deptID,dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary,tblPayrollemployee.daysPay,tblPayrollemployee.epfAllowed,tblPayrollemployee.payID,tblSetPCentre.pDesc,tblPayrollemployee.costID,'',tblPayrollemployee.emIDNum,0,tblPayrollemployee.prCatID,tblSetPrCategory.CatDesc,'',tblPayrollemployee.salViewLevel  FROM   dbo.tblPayEmpMRecords,tblSetCCentre,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblUL,tblPayrollemployee  " &
        " where dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND" &
        " dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND  " &
        " dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND " &
        " dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND " &
        " dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND " &
        " dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND " &
        " dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND " &
        " dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND  " &
        " tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND    tblPayrollemployee.regID=tblPayEmpMRecords.regID  AND  " &
        " tblPayEmpMRecords.status=0 AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayEmpMRecords.SalViewLevel =0) " &
        "AND tblPayEmpMRecords.cYear=" & cmbYear.Text & " AND tblPayEmpMRecords.cMonth=" & cmbMonth.Text & " and  tblPayrollEmployee.RegID in (select regid from tblTempRegID) ORDER BY " & strQuery

                Dim CN As New SqlConnection(sqlConString)
                CN.Open()
                Dim adp As New SqlDataAdapter(sSQL, CN)
                Dim stable As New DataSet
                adp.Fill(stable, "tblEmployee")

                sSQL = "SELECT * FROM tblCBranchs"
                adp = New SqlDataAdapter(sSQL, CN)
                adp.Fill(stable, "tblCBranchs")

                sSQL = "select deptID,deptName from tblsetdept"
                adp = New SqlDataAdapter(sSQL, CN)
                adp.Fill(stable, "tblDepartment")

                sSQL = "select * from tblEPFReport"
                adp = New SqlDataAdapter(sSQL, CN)
                adp.Fill(stable, "tblEPFReport")

                'Set randomly company name and address | 20190422
                If bolSelectBranch = True And isSeperateBranch = 1 Then
                    strDispCompany = FK_GetIDL(cmbbranch.Text)
                    strDispComAddress = fk_RetString("select Address from tblcbranchs where BrID='" & FK_GetIDR(cmbbranch.Text) & "'")
                Else
                    strDispCompany = cBusiness
                    strDispComAddress = cAddress
                End If

                If rdbCForm.Checked = True Then
                    Dim objRpt As New rptEPFCForm '- Report Files name here 

                    objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    objRpt.Database.Tables("tblCBranchs").SetDataSource(stable.Tables("tblCBranchs"))
                    objRpt.Database.Tables("tblDepartment").SetDataSource(stable.Tables("tblDepartment"))
                    objRpt.Database.Tables("tblEPFReport").SetDataSource(stable.Tables("tblEPFReport"))

                    'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    frmRepContainer.crptView.ReportSource = objRpt
                    objRpt.SetParameterValue("1", cBusiness)
                    objRpt.SetParameterValue("2", cAddress)
                    objRpt.SetParameterValue("crUser", CurrentUser)
                    sSQL = "EPF Act No 15 of 1958 - Report of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    objRpt.SetParameterValue("3", sSQL)

                    objRpt.SetParameterValue("CHQNo", txtChqNo.Text)
                    objRpt.SetParameterValue("Bank", cmbBank.Text)
                    objRpt.SetParameterValue("Branch", cmbBBranch.Text)
                    objRpt.SetParameterValue("EPFNo", txtRegNo.Text)
                    objRpt.SetParameterValue("Month", DateSerial(cmbYear.Text, cmbMonth.Text, 1))

                    objRpt.SetParameterValue("Surcharge", Val(txtSerCharge.Text))
                    objRpt.SetParameterValue("TotRemitence", Val(txtRemittance.Text))
                    objRpt.SetParameterValue("Contribution", Val(txtTotContribution.Text))

                    'Set pare size
                    If strDefaultPageSize = "PaperA4" Then
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

                    Else
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    End If

                    frmRepContainer.crptView.Refresh()
                    frmRepContainer.ShowDialog()

                ElseIf rdbEPFRepotr.Checked = True Then
                    Dim objRpt As New rptEPFAllReport '- Report Files name here 

                    objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    objRpt.Database.Tables("tblCBranchs").SetDataSource(stable.Tables("tblCBranchs"))
                    objRpt.Database.Tables("tblDepartment").SetDataSource(stable.Tables("tblDepartment"))
                    objRpt.Database.Tables("tblEPFReport").SetDataSource(stable.Tables("tblEPFReport"))

                    'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    frmRepContainer.crptView.ReportSource = objRpt
                    objRpt.SetParameterValue("1", strDispCompany)
                    objRpt.SetParameterValue("2", strDispComAddress)
                    objRpt.SetParameterValue("crUser", CurrentUser)
                    sSQL = "EPF Report of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    objRpt.SetParameterValue("3", sSQL)

                    'Set pare size
                    If strDefaultPageSize = "PaperA4" Then
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

                    Else
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    End If

                    frmRepContainer.crptView.Refresh()
                    frmRepContainer.ShowDialog()

                ElseIf rdbCformAl.Checked = True Then
                    Dim objRpt As New rptEPFCFormAllk '- Report Files name here 

                    objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    objRpt.Database.Tables("tblCBranchs").SetDataSource(stable.Tables("tblCBranchs"))
                    objRpt.Database.Tables("tblDepartment").SetDataSource(stable.Tables("tblDepartment"))
                    objRpt.Database.Tables("tblEPFReport").SetDataSource(stable.Tables("tblEPFReport"))

                    'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    frmRepContainer.crptView.ReportSource = objRpt
                    objRpt.SetParameterValue("1", cBusiness)
                    objRpt.SetParameterValue("2", cAddress)
                    objRpt.SetParameterValue("crUser", CurrentUser)
                    sSQL = "C Form act No 15 of 1958 Report of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    objRpt.SetParameterValue("3", sSQL)

                    objRpt.SetParameterValue("CHQNo", txtChqNo.Text)
                    objRpt.SetParameterValue("Bank", cmbBank.Text)
                    objRpt.SetParameterValue("Branch", cmbBBranch.Text)
                    objRpt.SetParameterValue("EPFNo", txtRegNo.Text)
                    objRpt.SetParameterValue("Month", DateSerial(cmbYear.Text, cmbMonth.Text, 1))

                    objRpt.SetParameterValue("Surcharge", Val(txtSerCharge.Text))
                    objRpt.SetParameterValue("TotRemitence", Val(txtRemittance.Text))
                    objRpt.SetParameterValue("Contribution", Val(txtTotContribution.Text))

                    'Set pare size
                    If strDefaultPageSize = "PaperA4" Then
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

                    Else
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    End If

                    frmRepContainer.crptView.Refresh()
                    frmRepContainer.ShowDialog()

                ElseIf rdbCformOld.Checked = True Then
                    Dim objRpt As New rptEPFCFormAsOld '- Requested by lake houeas their old report format

                    objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    objRpt.Database.Tables("tblCBranchs").SetDataSource(stable.Tables("tblCBranchs"))
                    objRpt.Database.Tables("tblDepartment").SetDataSource(stable.Tables("tblDepartment"))
                    objRpt.Database.Tables("tblEPFReport").SetDataSource(stable.Tables("tblEPFReport"))

                    'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    frmRepContainer.crptView.ReportSource = objRpt
                    objRpt.SetParameterValue("1", cBusiness)
                    objRpt.SetParameterValue("2", cAddress)
                    objRpt.SetParameterValue("crUser", CurrentUser)
                    sSQL = "EPF Act No 15 of 1958 - Report of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    objRpt.SetParameterValue("3", sSQL)

                    objRpt.SetParameterValue("CHQNo", txtChqNo.Text)
                    objRpt.SetParameterValue("Bank", cmbBank.Text)
                    objRpt.SetParameterValue("Branch", cmbBBranch.Text)
                    objRpt.SetParameterValue("EPFNo", txtRegNo.Text)
                    objRpt.SetParameterValue("Month", DateSerial(cmbYear.Text, cmbMonth.Text, 1))

                    objRpt.SetParameterValue("Surcharge", Val(txtSerCharge.Text))
                    objRpt.SetParameterValue("TotRemitence", Val(txtRemittance.Text))
                    objRpt.SetParameterValue("Contribution", Val(txtTotContribution.Text))

                    'Set pare size
                    If strDefaultPageSize = "PaperA4" Then
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

                    Else
                        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                        objRpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                    End If

                    frmRepContainer.crptView.Refresh()
                    frmRepContainer.ShowDialog()
                End If

                sSQL = "Delete from tblEPFAllData;Insert into [tblEPFAllData] (RegNo,cYear,cMonth,EPF3,EPF8,EPF12,EPF15,EPF20,TotEar,chqNo,bankName,brancName) values " &
                " ('" & txtRegNo.Text & "','" & cmbYear.Text & "','" & cmbMonth.Text & "','" & cmb3.Text & "','" & cmb8.Text & "','" & cmb12.Text & "','" & cmb15.Text & "','" & cmb20.Text & "','" & cmbTotal.Text & "','" & txtChqNo.Text & "','" & cmbBank.Text & "','" & cmbBBranch.Text & "');"
                FK_EQ(sSQL, "S", "", False, False, True)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Button1.Enabled = True
        Button2.Enabled = True
        cmdRefresh.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmPaysheetprocess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)

        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub rdbCForm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCForm.CheckedChanged
        If rdbCForm.Checked = True Then
            pnlTop.Height = 165
            pnlTop.Width = 967
            Me.Height = 640
            Me.Width = 977
        Else
            pnlTop.Height = 115
            pnlTop.Width = 967
            Me.Height = 590
            Me.Width = 977
        End If

    End Sub

    Private Sub cmbBank_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedValueChanged
        FillComboAll(cmbBBranch, "Select BranchName+'='+BrID from tblBranches where status='0' and BankID='" & FK_GetIDR(cmbBank.Text) & "'")
    End Sub

    Private Sub txtSerCharge_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSerCharge.TextChanged
        txtRemittance.Text = Val(txtTotContribution.Text) - Val(txtSerCharge.Text)
    End Sub

    Private Sub rdbCformAl_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbCformAl.CheckedChanged
        If rdbCformAl.Checked = True Then
            pnlTop.Height = 165
            pnlTop.Width = 967
            Me.Height = 640
            Me.Width = 977
        Else
            pnlTop.Height = 115
            pnlTop.Width = 967
            Me.Height = 590
            Me.Width = 977
        End If
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