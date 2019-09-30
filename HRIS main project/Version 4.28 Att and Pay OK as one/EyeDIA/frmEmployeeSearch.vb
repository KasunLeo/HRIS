Public Class frmEmployeeSearch

    Private Sub frmEmployeeSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        Populate_DatatoGRID()

    End Sub

    Public Sub Populate_DatatoGRID()
        Dim IsEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        Dim sqlTag As String : If IsEpf = 0 Then sqlTag = "RegID" Else If IsEpf = 1 Then sqlTag = "EpfNo" Else If IsEpf = 2 Then sqlTag = "EnrolNo" Else sqlTag = "EmpNo"

        Dim sSQL As String = ""
        Select Case strReActEmp
            Case "Ra"
                sSQL = "select tblEmployee.RegID As [Register ID]," & sqlTag & " As [Employee ID],tblEmployee.Dispname As [Employee Name],tblSetDept.Deptname As [Department Name],tblDesig.DesgDesc As [Designation],tblEmployee.NICNumber As [NIC Number] FROM tblEmployee,tblSetDept,tblDesig" & _
                " WHERE tblEmployee.DeptID = tblSetDept.DeptID AND tblEmployee.DesigID = tblDesig.DesgID AND " & _
                " (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR tblDesig.DesgDesc LIKE '%" & txtSearch.Text & "%' OR " & sqlTag & " LIKE '%" & txtSearch.Text & "%') AND tblEmployee.EmpStatus = 9"

            Case Else
                sSQL = "select tblEmployee.RegID As [Register ID]," & sqlTag & " As [Employee ID],tblEmployee.Dispname As [Employee Name],tblSetDept.Deptname As [Department Name],tblDesig.DesgDesc As [Designation],tblEmployee.NICNumber As [NIC Number] FROM tblEmployee,tblSetDept,tblDesig" & _
                " WHERE tblEmployee.DeptID = tblSetDept.DeptID AND tblEmployee.DesigID = tblDesig.DesgID AND " & _
                " (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR tblSetDept.DeptName LIKE '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR tblDesig.DesgDesc LIKE '%" & txtSearch.Text & "%' OR " & sqlTag & " LIKE '%" & txtSearch.Text & "%') AND tblEmployee.EmpStatus <> 9"

        End Select
        
        Populate_DataGrid(sSQL, dgvEmAdd, "tblEmployee")

        fk_GridFormat1(dgvEmAdd)

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Populate_DatatoGRID()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Populate_DatatoGRID()
    End Sub

    Private Sub dgvEmAdd_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEmAdd.DoubleClick
        StrEmployeeID = dgvEmAdd.Item(0, dgvEmAdd.CurrentRow.Index).Value : Me.Close()
    End Sub
End Class