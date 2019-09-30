Public Class frmDBConfig

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Dim bolRetResult As Boolean = False
        bolRetResult = fk_CheckDBStatus(txtPassword.Text, txtUserName.Text, txtSqlDatabase.Text, txtSqlServer.Text)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        fk_SaveETConfig(txtPassword.Text, txtUserName.Text, txtSqlDatabase.Text, txtSqlServer.Text)
    End Sub

End Class