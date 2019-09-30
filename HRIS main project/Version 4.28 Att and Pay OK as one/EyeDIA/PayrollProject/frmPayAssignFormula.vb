Public Class frmAssignFormula

    Dim intCountk As Integer = 0

    Private Sub FrmMonthlyAllowancesAll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControlHandlers(Me)
        CenterFormThemed(Me, Panel1, Label4)
        'sSQL = "CREATE TABLE tbltempWorkingAllowance ([RegID] [nvarchar](10) NULL,	[EMPNO] [nvarchar](10) NULL,[EPFNo] [nvarchar](15) NULL,	[DispName] [nvarchar](250) NULL,[desgdesc] [nvarchar](30) NULL,	[Amount] [varchar](19) NOT NULL) "
        'FK_EQ(sSQL, "P", False, False, False)
        cmdRefresh_Click(sender, e)
        'If StrEmployeeID <> "" Then

        'End If

    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        proc_OnlyNumeric1(e)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Str As String = "Select 'false',RegID,EMPNO,EPFNo,DispName,tblDesig.desgdesc,'' from tblPayrollEmployee  left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID order by regID asc "
        FK_LoadGrid(Str, dgv)
        CalSelected()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = Cursors.WaitCursor
        PB.Value = 0
        PB.Maximum = dgv.RowCount

        For X = 0 To dgv.RowCount - 1
            dgv.Item(0, X).Value = True
            PB.Value = X
        Next
        CalSelected()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim iBol As Boolean = False
        PB.Value = 0
        PB.Maximum = dgv.RowCount
        For X = 0 To dgv.RowCount - 1
            iBol = dgv.Item(0, X).Value
            PB.Value = X
            dgv.Item(0, X).Value = Not iBol
        Next
        CalSelected()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        PB.Value = 0
        PB.Maximum = dgv.RowCount
        For X = 0 To dgv.RowCount - 1
            PB.Value = X
            dgv.Item(0, X).Value = False
        Next
        CalSelected()
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        ComboLoad()
        'txtSearch.Text = FK_GetIDL(cmbDept.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox2.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub cboDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignation.SelectedIndexChanged
        ComboLoad()
        'txtSearch.Text = FK_GetIDL(cboDesignation.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox2.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'If MsgBox("Are you Sure you want to Save", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If cmbFormula.Text = "" Then MsgBox("Please Select the Service Charge Category From the List", MsgBoxStyle.Information) : Exit Sub
        'If Val(txtAmount.Text) = 0 Then MsgBox("Invalid Amount", MsgBoxStyle.Critical) : txtAmount.Focus() : txtAmount.SelectAll() : Exit Sub

        If UP("Assign Selected one formula to employee", "Assign Employee Formula") = False Then Exit Sub

        'validation
        'For kl As Integer = 0 To dgv.RowCount - 1
        '    If Trim(dgv.Item(6, kl).Value) <> "" Then

        '    End If
        'Next

        'For k As Integer = 0 To dgv.RowCount - 1
        '    If Val(dgv.Item(6, k).Value) <> 0 Then
        '        dgv.Item(0, k).Value = True
        '    End If
        'Next

        Try
            Dim bSelected As Boolean = False
            For X = 0 To dgv.RowCount - 1
                If dgv.Item(0, X).Value = True Or Val(dgv.Item(0, X).Value) = 1 Then
                    bSelected = True : Exit For
                End If
            Next
            If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub
            sSQL = ""
            Dim sitem As String = FK_GetIDR(cmbFormula.Text)
            PB.Value = 0
            PB.Maximum = dgv.RowCount
            Dim kl As Integer = 0
            For ik = 0 To dgv.RowCount - 1

                PB.Value = ik
                sSQL = sSQL & " Delete from tblEmployeeFormulaField where ID='" & sitem & "' and EmpID='" & dgv.Item(1, ik).Value & "' ;"
                If dgv.Item(0, ik).Value = True Or Val(dgv.Item(0, ik).Value) = 1 Then
                    kl = kl + 1
                    sSQL = sSQL & "INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'frmAssignFormula','Changed assigned formula of regID : " & DGV.Item(1, ik).Value & " epfNO : " & DGV.Item(1, ik).Value & " formula : " & Val(DGV.Item(6, ik).Value) & " main FORMULA  : " & cmbFormula.Text & "','" & StrUserID & "',0,'" & DGV.Item(1, ik).Value & "')"
                    sSQL = sSQL & " Insert into tblEmployeeFormulaField (ID,EmpID) VALUES ('" & sitem & "','" & dgv.Item(1, ik).Value & "');"
                End If
            Next
            'sSQL = sSQL & " DELETE FROM tblAccNumAssign WHERE accNumber='0' AND acTypID='" & sitem & "'"
            FK_EQ(sSQL, "S", "", True, True, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
        ComboLoad()

    End Sub

    Public Sub ComboLoad()
        rdbAll.Checked = False
        intCountk = 0

        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"

        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", FK_GetIDL(cmbDept.Text))
        Dim StrSubCatName As String = IIf(cmbSubCategory.Text = "[ALL]", "", FK_GetIDL(cmbSubCategory.Text))
        Dim StrDesigName As String = IIf(cmbDesignation.Text = "[ALL]", "", FK_GetIDL(cmbDesignation.Text))
        Dim StrBranchName As String = IIf(cmbbranch.Text = "[ALL]", "", FK_GetIDL(cmbbranch.Text))
        Dim StrCompany As String = IIf(cmbCompany.Text = "[ALL]", "", FK_GetIDL(cmbCompany.Text))
        Dim StrPrCategorya As String = IIf(cmbPrCatagory.Text = "[ALL]", "", FK_GetIDL(cmbPrCatagory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDL(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDL(cmbCostCenter.Text))

        Try
            sSQL = "CREATE Table #T (EmpID Nvarchar (6),EmpNo NVarchar (6),NIC Nvarchar (14),DispName NVarchar (200),descript Nvarchar (150),assigned NVARCHAR (14),desigName Nvarchar (214),DeptName Nvarchar (155)); INSERT INTO #T " & _
        "SELECT dbo.tblPayrollEmployee.RegID, RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' ,dbo.tblPayrollEmployee.EmIDNum, dbo.tblPayrollEmployee.DispName,'" & cmbFormula.Text & "', 0, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName  FROM  " & _
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
        "where   tblPayrollEmployee.status=0  AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0) " & _
        "AND (dbo.tblPayrollEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayrollEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR  " & _
        "dbo.tblPayrollEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayrollEmployee.EmIdNum LIKE '%" & txtSearch.Text & "%' OR  " & _
        "dbo.tblPayrollEmployee.EPFNo LIKE '%" & txtSearch.Text & "%' OR  dbo.tblPayrollEmployee.BasicSalary LIKE '%" & txtSearch.Text & "%') AND (dbo.tblCompany.cName LIKE '%" & StrCompany & "%' AND  " & _
        "dbo.tblDesig.desgDesc LIKE '%" & StrDesigName & "%' AND " & _
        "dbo.tblSetDept.deptName LIKE '%" & StrDeptname & "%' AND  " & _
            "dbo.tblSetCCentre.cntDesc LIKE '%" & StrCostC & "%' AND  " & _
                "dbo.tblSetPCentre.pDesc LIKE '%" & StrPayC & "%' AND  " & _
"dbo.tblSetEmpCategory.catDesc LIKE '%" & StrSubCatName & "%' AND  " & _
        "dbo.tblCBranchs.BrName LIKE '%" & StrBranchName & "%' AND  " & _
        "tblSetPrCategory.CatDesc LIKE '%" & StrPrCategorya & "%') ORDER BY tblPayrollEmployee.RegID; " & _
        "UPDATE #T SET #T.assigned = tblEmployeeFormulaField.id FROM  #T,tblEmployeeFormulaField WHERE #T.EmpID = tblEmployeeFormulaField.EmpID AND tblEmployeeFormulaField.ID ='" & FK_GetIDR(cmbFormula.Text) & "'; SELECT CASE WHEN assigned='0' THEN 'False' ELSE 'True' END,* FROM #T order by assigned desc"
            FK_LoadGrid(sSQL, dgv)

            ' ''sSQL = "DELETE FROM tbltempWorkingAllowance; INSERT INTO tbltempWorkingAllowance Select RegID,EMPNO,EPFNo,DispName,tblDesig.desgdesc,'0' as Amount  from tblPayrollEmployee  left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID WHERE tblPayrollEmployee.status='0'; UPDATE tbltempWorkingAllowance SET aMOUNT=TBLWORKINGALLOWANCES.AMOUNT FROM TBLWORKINGALLOWANCES LEFT JOIN tbltempWorkingAllowance ON tbltempWorkingAllowance.REGID=TBLWORKINGALLOWANCES.EMPID WHERE TBLWORKINGALLOWANCES.CYEAR='" & Trim(txtYear.Text) & "' AND TBLWORKINGALLOWANCES.CMONTH='" & Trim(cboMonth.Text) & "' AND TBLWORKINGALLOWANCES.SALARYITEM='" & FK_GetIDR(cboSalaryItem.Text) & "'; SELECT  case when amount='0' then 'false' else 'true' end as 'Tick',RegID,EMPNO,EPFNo,DispName,desgdesc,amount  FROM tbltempWorkingAllowance;"
            ''sSQL = "SELECT     'TRUE',dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.EMPNo,dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.DispName,tblsalaryItems.Description, tblIndiFixedFields.Amount, dbo.tblPayrollEmployee.EmIdNum,                   dbo.tblSetDept.DeptName  FROM         dbo.tblPayrollEmployee LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID INNER JOIN  tblIndiFixedFields on tblIndiFixedFields.RegID=tblpayrollEmployee.RegID LEFT OUTER JOIN  tblsalaryItems on tblsalaryItems.ID=tblIndiFixedFields.salID  where tblsalaryItems.ID='" & FK_GetIDR(cboSalaryItem.Text) & "' AND tblPayrollEmployee.SalViewLevel<= " & UserVal & " or tblPayrollEmployee.SalViewLevel is null"
            ''For X = 0 To dgv.RowCount - 1
            ''    dgv.Item(0, X).Value = False
            ''Next

            ''If FK_ReadDB(sSQL) = True Then
            ''    For X = 0 To frmMain.dgvFillGridforRead.RowCount - 1
            ''        For I = 0 To dgv.RowCount - 1
            ''            If Val(frmMain.dgvFillGridforRead.Item(6, X).Value) = Val(dgv.Item(6, I).Value) Then
            ''                dgv.Item(0, I).Value = True
            ''            End If
            ''        Next
            ''    Next
            ''End If
            ' ''Load_InformationtoGrid(sSQL, dgv, 7)
            CalSelected()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub CalSelected()
        intCountk = 0
        For i = 0 To dgv.RowCount - 1
            dgv.Item(6, i).Style.BackColor = clrFocused
            If dgv.Item(0, i).Value = True Or Val(dgv.Item(0, i).Value) = 1 Then
                intCountk = intCountk + 1
                dgv.Item(5, i).Style.BackColor = clrFocused
            End If
        Next
        lblCount.Text = "All Employeess : " & dgv.RowCount & " Total selected rows : " & intCountk
        clr_Grid(dgv)
    End Sub

    Private Sub cboSalaryItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFormula.SelectedIndexChanged
        ComboLoad()
       
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    sSQL = "Select EmpID,Amount from tblWorkingAllowances where Status='0' and Salaryitem='" & FK_GetIDR(cboSalaryItem.Text) & "' and cYear='" & txtYear.Text & "' and cMonth='" & cboMonth.Text & "' order by EmpID Asc;"
        '    Fk_FillGrid(sSQL, dgvAmount)
        '    For X = 0 To dgv.RowCount - 1
        '        dgv.Item(6, X).Value = 0
        '        dgv.Item(0, X).Value = True
        '    Next
        '    PB.Value = 0
        '    PB.Maximum = dgv.RowCount
        '    For X = 0 To dgv.RowCount - 1
        '        PB.Value = X
        '        For I = 0 To dgvAmount.RowCount - 1
        '            If dgv.Item(1, X).Value = dgvAmount.Item(0, I).Value Then
        '                dgv.Item(6, X).Value = dgvAmount.Item(1, I).Value
        '                dgv.Item(0, X).Value = True
        '                dgvAmount.Rows.RemoveAt(I)
        '                Exit For
        '            End If
        '        Next
        '    Next
        '    Me.Cursor = Cursors.Default
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub dgv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgv_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)

        HL_MouseLine(DGV, e.RowIndex)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'LoadForm(New FrmMonthlyTransections)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub rdbAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAll.Click

        Button7_Click(sender, e)
        rdbNone.Checked = False
        rdbInverse.Checked = False

    End Sub

    Private Sub rdbInverse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbInverse.Click
        Button4_Click(sender, e)
        rdbAll.Checked = False
        rdbNone.Checked = False
    End Sub

    Private Sub rdbNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNone.Click

        Button3_Click(sender, e)
        rdbAll.Checked = False
        rdbInverse.Checked = False

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Try
            Dim ctrl As Control
            For Each ctrl In Me.GroupBox2.Controls
                If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
            Next

            fk_comboItems("SELECT tblSalaryItems.description+'='+tblFormula.id FROM tblFormula,tblSalaryItems where tblFormula.SalaryField=tblSalaryItems.id ORDER BY tblSalaryItems.description", cmbFormula)
            'RefreshForm()

            rdbAll.Checked = True
            'grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            FillComboAll(cmbDept, "Select (DeptName+'='+DeptID) from tblSetDept where Status=0 order by deptName asc")
            FillComboAll(cmbDesignation, "Select (desgdesc+'='+DesgID) from tblDesig where Status=0 order by desgdesc asc")
            FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0 order by pDesc asc")
            'FillCombo(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")9 v
            FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0 order by CName asc")
            FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0 order by BrName asc")
            FillComboAll(cmbPrCatagory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0 order by CatDesc asc")
            FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc asc")
            FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0 order by cntDesc asc")
            dgv.Rows.Clear()
            txtSearch.Text = ""
            If cmbFormula.Items.Count > 0 Then
                cmbFormula.SelectedIndex = 0
            End If
            ' rdbAll.Checked = True
            'Dim Str As String = "SELECT     'TRUE',dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.EMPNo,dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.DispName,tblsalaryItems.Description, tblIndiFixedFields.Amount, dbo.tblPayrollEmployee.EmIdNum,                   dbo.tblSetDept.DeptName  FROM         dbo.tblPayrollEmployee LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID LEFT OUTER JOIN  tblIndiFixedFields on tblIndiFixedFields.RegID=tblpayrollEmployee.RegID LEFT OUTER JOIN  tblsalaryItems on tblsalaryItems.ID=tblIndiFixedFields.salID  where  tblPayrollEmployee.SalViewLevel<= " & UserVal & " or tblPayrollEmployee.SalViewLevel is null"
            'Load_InformationtoGrid(Str, dgv, 9)
            'lblCount.Text = "All Employeess : " & dgv.RowCount
            'clr_Grid(dgv)
            'StrEmployeeID = ""
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub cmbbranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbranch.SelectedIndexChanged
        ComboLoad()
        'Dim Str As String = "Select 'false',RegID,EMPNO,EPFNo,DispName,tblDesig.desgdesc,'' from tblPayrollEmployee  left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where BrID='" & FK_GetIDR(cmbbranch.Text) & "'   AND tblPayrollEmployee.status='0' order by regID asc "
        'Load_InformationtoGrid(Str, dgv, 6)
        'lblCount.Text = "All Employeess : " & dgv.RowCount
        'clr_Grid(dgv)
        ''txtSearch.Text = FK_GetIDL(cmbbranch.Text)
        ''Dim ctrl As Control
        ''For Each ctrl In Me.GroupBox2.Controls
        ''    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        ''Next
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        ComboLoad()
        'Dim Str As String = "Select 'false',RegID,EMPNO,EPFNo,DispName,tblDesig.desgdesc,'' from tblPayrollEmployee  left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where ComID='" & FK_GetIDR(cmbCompany.Text) & "'  AND tblPayrollEmployee.status='0'  order by regID asc "
        'Load_InformationtoGrid(Str, dgv, 6)
        'lblCount.Text = "All Employeess : " & dgv.RowCount
        'clr_Grid(dgv)
    End Sub

    Private Sub cmbPayCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPayCenter.SelectedIndexChanged
        ComboLoad()
        'txtSearch.Text = FK_GetIDL(cmbPayCenter.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox2.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrCatagory.SelectedIndexChanged
        ComboLoad()
        'txtSearch.Text = FK_GetIDL(cmbPrCatagory.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox2.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.TextLength > 2 Then
            ComboLoad()
        End If
    End Sub

    Private Sub cmbSubCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubCategory.SelectedIndexChanged
        ComboLoad()
        'txtSearch.Text = FK_GetIDL(cmbSubCategory.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox2.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub cmbCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostCenter.SelectedIndexChanged
        ComboLoad()
        'txtSearch.Text = FK_GetIDL(cmbCostCenter.Text)
        'Dim ctrl As Control
        'For Each ctrl In Me.GroupBox2.Controls
        '    If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        'Next
    End Sub

    Private Sub cmdAllk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllk.Click
        fk_comboItems("select HName+'='+ID from tblbankHead WHERE status=0 order by HName asc", cmbFormula)
        'cmdAllk.Enabled = False
    End Sub

    Private Sub dgv_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMonth.CheckedChanged
        For i = 0 To dgv.RowCount - 1
            dgv.Item(0, i).Value = chkMonth.CheckState
        Next
    End Sub

End Class