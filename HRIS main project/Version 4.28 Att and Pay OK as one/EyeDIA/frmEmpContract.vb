Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Class frmEmpContract

    Dim strRelTypeID As String = ""
    Dim strDesigID As String = ""

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListCombo(cmbDept, "select * from tblSetDept order by deptDesc", "deptDesc")
    End Sub

End Class