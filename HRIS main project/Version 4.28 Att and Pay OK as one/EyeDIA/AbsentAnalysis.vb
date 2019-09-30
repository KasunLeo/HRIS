Imports System.Data.SqlClient
Imports System.Globalization

Public Class AbsentAnalysis
    Public intSearch As Integer = 1

    Private Sub btnPresent_Paint(sender As Object, e As PaintEventArgs) Handles btnPresent.Click
        intSearch = "1"
        btnSearch_Click(sender, e)
    End Sub

    Private Sub btnAbsent_Paint(sender As Object, e As PaintEventArgs) Handles btnAbsent.Click
        intSearch = "0"
        btnSearch_Click(sender, e)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        intSearch = 0
        sSQL = "exec [srAbCount] '" & Format(dtpFromDate.Value, "yyyyMMdd") & "', '" & Format(dtpToDate.Value, "yyyyMMdd") & "'," & intSearch & ""
        Fk_FillGrid(sSQL, dgvData)
    End Sub

End Class