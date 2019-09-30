Public Class frmImportExtraDaystoLeave

    Dim dblEntitledLeve As Double = 0
    Dim dblTotImport As Double = 0
    Dim strTrID As String = ""
    Dim strLeaveTID As String = ""

    Private Sub frmImportExtraDaystoLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Public Sub EmployeeSearch()

        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag = "tblEmployee.EPFNo" Else sqlTag = "tblEmployee.enrolNo"

        Dim strQuery As String = "select  distinct 'true',dbo.tblEmployee.RegID,dbo." & sqlTag & ", dbo.tblEmployee.dispName," & _
        "dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName,1 FROM dbo.tblEmployee " & _
        "LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID " & _
        "LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID " & _
        "LEFT OUTER JOIN dbo.tblSetTitle ON dbo.tblSetTitle.titleID=dbo.tblemployee.TitleID " & _
        "LEFT OUTER JOIN dbo.tblSEtEmpCategory ON dbo.tblSEtEmpCategory.CatID=dbo.tblEmployee.CatID " & _
        "LEFT OUTER JOIN dbo.tblEmpRegister ON dbo.tblEmpRegister.empID=dbo.tblemployee.regID " & _
        "WHERE tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND tblEmpRegister.adWorkDay<>0 AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR " & _
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

        GroupBox3.Text = "Listed Employee(s) : " & dgvEmps.RowCount

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        EmployeeSearch()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next

        ListComboAll(cmbDesg, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "desgDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0 Order By DeptID", "deptName")
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")

        txtSearch.Text = "K"
        txtSearch.Text = ""
        chkCheck.CheckState = CheckState.Unchecked

        Dim dtLastDate As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        dtpFrDate.Value = DateSerial(Year(dtLastDate), Month(dtLastDate), 1)
        dtpToDate.Value = dtLastDate

        dgvExtraDay.Rows.Clear()
        dgvLvTypes.Rows.Clear()
        Label2.Text = "All Leave Types"
        Label5.Text = "Extra Days Summary"
        chkCheck.Checked = True
        dblEntitledLeve = 0
        dblTotImport = 0
        txtEntitled.Text = "0"
        txtTotImported.Text = "0"
        txtNewEntitlement.Text = "0"
        strLeaveTID = ""

        strTrID = fk_CreateSerial(6, fk_sqlDbl("SELECT NoExtraDay+1 FROM tblCompany WHERE CompID = '" & StrCompID & "'"))
        chkCheck.CheckState = CheckState.Checked
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

    Private Sub cmbDesg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesg.SelectedIndexChanged
        txtSearch.Text = cmbDesg.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        txtSearch.Text = cmbCat.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        txtSearch.Text = cmbDept.Text
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox3.Controls
            If TypeOf ctrl Is ComboBox Then ctrl.Text = ""
        Next
        'txtSearch.Text = cmbDept.Text
    End Sub

    Private Sub dgvEmps_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmps.CellClick
        Try
            StrEmployeeID = Trim(dgvEmps.CurrentRow.Cells(1).Value)
            Label5.Text = "Extra Days Summary of : " & StrEmployeeID
            Label2.Text = "All Leave Types of : " & StrEmployeeID
            Load_InformationtoGrid("select tblempregister.EmpID,tblempregister.AtDate,(tblempregister.AdWorkDay-tblempregister.ExtrDayUsed) as 'Extra Days' from tblempregister where atdate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblempregister.AdWorkDay-tblempregister.ExtrDayUsed>0 and EmpID='" & StrEmployeeID & "'", dgvExtraDay, 3)
            Load_InformationtoGrid("select tblleavetype.LvID,tblleavetype.LvDesc,tblempleaved.NoLeaves,tblempleaved.TakenLeave from tblempleaved LEFT OUTER JOIN tblleavetype ON tblleavetype.lViD=tblempleaved.LeaveID WHERE tblempleaved.cYear='" & intCurrentYear & "' and tblempleaved.CompID='" & StrCompID & "' and EmpID='" & StrEmployeeID & "'", dgvLvTypes, 4)
            txtEntitled.Text = "0"
            txtTotImported.Text = "0"
            txtNewEntitlement.Text = "0"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvLvTypes_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLvTypes.CellClick
        Try
            strLeaveTID = dgvLvTypes.CurrentRow.Cells(0).Value
            dblEntitledLeve = dgvLvTypes.CurrentRow.Cells(2).Value
            txtEntitled.Text = dblEntitledLeve
            txtNewEntitlement.Text = Val(txtTotImported.Text) + Val(txtEntitled.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'If dblEntitledLeve = 0 Then MessageBox.Show("Please select leave type to import from extra days", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgvLvTypes.Focus() : Exit Sub
        If dblTotImport = 0 Then MessageBox.Show("Please choose extra days to import", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgvExtraDay.Focus() : Exit Sub
        If strLeaveTID = "" Then MessageBox.Show("Please select leave type to increase", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgvLvTypes.Focus() : Exit Sub

        sSQL = "INSERT INTO tblExtraLeaveDaysH (TrID,EmpID,extraDays,LvType,crUser,crDate,status) VALUES ('" & strTrID & "','" & StrEmployeeID & "','" & dblTotImport & "','" & strLeaveTID & "','" & StrUserID & "', GETDATE(),0); UPDATE tblCompany SET NoExtraDay=NoExtraDay+1 WHERE CompID='" & StrCompID & "'; " & _
        "UPDATE tblEmpLeaveD set NoLeaves=Noleaves+" & dblTotImport & " WHERE EmpID='" & StrEmployeeID & "' and cYear='" & intCurrentYear & "' and compid='" & StrCompID & "' and LeaveID='" & strLeaveTID & "'"
        For kl As Integer = 0 To dgvExtraDay.RowCount - 1
            If dgvExtraDay.Item(3, kl).Value = 1 Or dgvExtraDay.Item(3, kl).Value = True Then
                sSQL = sSQL & "INSERT INTO tblExtraLeaveDays (TrID,EmpID,atDate,NoLv,status) VALUES ('" & strTrID & "','" & StrEmployeeID & "','" & CDate(dgvExtraDay.Item(1, kl).Value) & "','" & Val(dgvExtraDay.Item(2, kl).Value) & "',0); UPDATE tblEmpRegister set ExtrDayUsed='" & Val(dgvExtraDay.Item(2, kl).Value) & "' where EmpID='" & StrEmployeeID & "' AND AtDate='" & CDate(dgvExtraDay.Item(1, kl).Value) & "'"
            End If
        Next

        If True = FK_EQ(sSQL, "S", "", True, True, True) Then
            cmdRefresh_Click(sender, e)
        End If
    End Sub

    Private Sub dgvExtraDay_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraDay.CellValueChanged
        'Dim checkCell As DataGridViewCheckBoxCell = CType(dgvExtraDay.Rows(e.RowIndex).Cells("CheckBoxes"), DataGridViewCheckBoxCell)
        'buttonCell.Enabled = Not CType(checkCell.Value, [Boolean])
        'dgvExtraDay.Invalidate()

        Try
            dblTotImport = 0
            With dgvExtraDay
                For k As Integer = 0 To .RowCount - 1
                    If .Item(3, k).Value = 1 Or .Item(3, k).Value = True Then
                        dblTotImport = dblTotImport + Val(.Item(2, k).Value)
                    End If
                Next
            End With
            txtTotImported.Text = dblTotImport
            txtNewEntitlement.Text = Val(txtTotImported.Text) + Val(txtEntitled.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgvExtraDay_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvExtraDay.CurrentCellDirtyStateChanged
        If dgvExtraDay.IsCurrentCellDirty Then
            dgvExtraDay.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Load_InformationtoGrid("select tblempregister.EmpID,tblempregister.AtDate,(tblempregister.AdWorkDay-tblempregister.ExtrDayUsed) as 'Extra Days' from tblempregister where atdate Between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblempregister.AdWorkDay<>0 and EmpID='" & StrEmployeeID & "'", dgvExtraDay, 3)
    End Sub

    Private Sub chkCheck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheck.CheckedChanged
        For k As Integer = 0 To dgvEmps.RowCount - 1
            dgvEmps.Item(0, k).Value = chkCheck.CheckState
        Next
    End Sub

End Class