Public Class frmSQLInterface

    Dim intcolomncount As Integer = 0

    Private Sub frmSQLInterface_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        CenterFormThemed(Me, Panel1, Label8)
        ControlHandlers(Me)
    End Sub

    Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        Me.Cursor = Cursors.WaitCursor
        pgBar.Value = 0
        sSQL = txtQuery.Text
        Fk_FillGrid(sSQL, dgvQuery)
        clr_Grid(dgvQuery)
        intcolomncount = dgvQuery.ColumnCount
        lblcount.Text = "Total rows : " & dgvQuery.RowCount - 1
        pgBar.Value = pgBar.Maximum
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRun.Click
        Me.Cursor = Cursors.WaitCursor
        pgBar.Value = 0
        sSQL = txtQuery.Text
        FK_EQ(sSQL, "S", "", True, True, True)
        pgBar.Value = pgBar.Maximum
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtQuery_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQuery.LostFocus
        Dim strK As String = Microsoft.VisualBasic.Left(txtQuery.Text.ToUpper, 6)
        If strK = "SELECT" Then
            cmdRun.Enabled = False
            cmdView.Enabled = True
        Else
            cmdRun.Enabled = True
            cmdView.Enabled = False
        End If
    End Sub

    Private Sub dgvQuery_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQuery.CellClick
        lblRow.Text = "Current row : " & dgvQuery.CurrentRow.Index + 1
        lblColumn.Text = "Current cell : " & dgvQuery.CurrentCell.ColumnIndex + 1
    End Sub

    Private Sub btnToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToExcel.Click
        If dgvQuery.RowCount < 1 Then MessageBox.Show("Please load data to gridview by typing correct select query", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgvQuery.Focus() : Exit Sub
        If MsgBox("Are you sure you want to Export this Data to Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ExporttoExcel(dgvQuery, intcolomncount)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtQuery.Text = ""
        dgvQuery.DataSource = Nothing
        dgvQuery.Columns.Clear()
        dgvQuery.Rows.Clear()
        lblColumn.Text = "Column"
        lblRow.Text = "Row"
        lblcount.Text = "Count"
        pgBar.Value = 0
    End Sub

End Class