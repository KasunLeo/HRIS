Public Class FrmFilterEmployees

   
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FillComboAll(cmbDepartment, "select DeptName + '-' + DeptID from tblsetDept where status=0")
        FillComboAll(cmbPayCenter, "select pDesc + '-' + pID from tblsetpcentre where status=0")
        FillComboAll(cmbCostCenter, "Select  cntDesc + '-' + cntID from tblsetcCentre where status=0")
        'FillComboAll(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
        FillComboAll(cmbCompany, "Select CName + '-' + CompID from tblCompany where status=0")
        FillComboAll(cmbbranch, "Select BrName + '-' + BrID from tblCBranchs where status=0")
        FillComboAll(cmbDesignation, "Select DesgDesc + '-' + DesgID from tblDesig where status=0")
        FillComboAll(cmbPrCatagory, "select CatDesc + '-' + CatID from tblSetPrCategory where status=0")
        FilterRecord()

    End Sub

    Private Sub FrmFilterEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Visible = False
        Me.Cursor = Cursors.WaitCursor
        CenterForm(Me)
        ControlHandlers(Me)
        Label13.BackColor = clrFocused

        FillComboAll(cmbDepartment, "select DeptName + '-' + DeptID from tblsetDept where status=0")
        FillComboAll(cmbPayCenter, "select pDesc + '-' + pID from tblsetpcentre where status=0")
        FillComboAll(cmbCostCenter, "Select  cntDesc + '-' + cntID from tblsetcCentre where status=0")
        'FillComboAll(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
        FillComboAll(cmbCompany, "Select CName + '-' + CompID from tblCompany where status=0")
        FillComboAll(cmbbranch, "Select BrName + '-' + BrID from tblCBranchs where status=0")
        FillComboAll(cmbDesignation, "Select DesgDesc + '-' + DesgID from tblDesig where status=0")
        FillComboAll(cmbPrCatagory, "select CatDesc + '-' + CatID from tblSetPrCategory where status=0")
        Dim Str = "Select 'false',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName from tblPayrollEmployee   inner join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID inner join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where tblPayrollEmployee.status='0' and salviewlevel<='" & UserVal & "' order by regID asc "
        Load_InformationtoGrid(Str, grdData, 6)
        sSQL = " Delete from tblTempRegID "
        EQ(sSQL)
        Me.Visible = True
        For X = 1 To 12
            cmbMonth.Items.Add(X)
        Next
        cmbMonth.Text = Now.Date.Month
        For X = Now.Date.Year - 5 To Now.Date.Year + 5
            cmbYear.Items.Add(X)
        Next
        cmbYear.Text = Now.Date.Year
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        For X = 0 To grdData.RowCount - 1
            If CheckBox1.Checked = True Then
                grdData.Item(0, X).Value = True
            Else
                grdData.Item(0, X).Value = False
            End If
        Next

    End Sub
    Private Sub FilterRecord()
        If cmbYear.Text = "" Or cmbMonth.Text = "" Then Exit Sub
        Dim Str = "Select 'false',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName from tblPayEmpMRecords   inner join  tblSetdept on tblSetDept.DeptId=tblPayEmpMRecords.DeptID inner join tblDesig on tblDesig.DesgID=tblPayEmpMRecords.DesigID where tblPayEmpMRecords.status='0' and salviewlevel<='" & UserVal & "' and  " & _
        "  tblPayEmpMRecords.ComID like '%" & FK_GetID(cmbCompany.Text) & "%' and  tblPayEmpMRecords.DesigID like '%" & FK_GetID(cmbDesignation.Text) & "%' and tblPayEmpMRecords.BrID like '%" & FK_GetID(cmbCompany.Text) & "%' and tblPayEmpMRecords.DeptID like '%" & FK_GetID(cmbDepartment.Text) & "%' and tblPayEmpMRecords.PayID like '%" & FK_GetID(cmbPayCenter.Text) & "%' and tblPayEmpMRecords.CostID like '%" & FK_GetID(cmbCostCenter.Text) & "%' and tblPayEmpMRecords.PrCatID like '%" & FK_GetID(cmbPrCatagory.Text) & "%' and tblPayEmpMRecords.cYear='" & Val(cmbYear.Text) & "' and tblPayEmpMRecords.cMonth='" & Val(cmbMonth.Text) & "' and salviewlevel <='" & UserVal & "' " & _
        "order by tblPayEmpMRecords.regID asc "
        Load_InformationtoGrid(Str, grdData, 6)
        LBL.Text = "Employees " & grdData.RowCount & " Selected"
    End Sub
    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrCatagory.SelectedIndexChanged
        FilterRecord()

    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub cmbDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignation.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub cmbbranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbranch.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub cmbPayCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPayCenter.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub cmbCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostCenter.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim bSelected As Boolean = False
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Then
                bSelected = True : Exit For
            End If
        Next
        If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub
        sSQL = "Create table tblTempRegID (RegID varchar (15),cYear Decimal(18,0) not null Default 0,cMonth Decimal(18,0) not null Default 0)"
        EQ(sSQL)
        sSQL = " Declare @RegID varchar(15)          "
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Then sSQL = sSQL & "       Set @RegID='" & grdData.Item(1, X).Value & "'             IF not EXISTS (Select RegID from tblTempRegID where RegID=@RegID and cYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "')         BEGIN     Insert into tblTempRegID (regID,cYear,cMonth) values (@RegID,'" & Val(cmbYear.Text) & "','" & Val(cmbMonth.Text) & "')       End "
        Next
        FK_EQ(sSQL, "S", "", False, True, True)

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        FilterRecord()
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        For X = 0 To grdData.RowCount - 1
            If CheckBox2.Checked Then grdData.Item(0, X).Value = True Else grdData.Item(0, X).Value = False
        Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FilterRecord()
    End Sub

End Class