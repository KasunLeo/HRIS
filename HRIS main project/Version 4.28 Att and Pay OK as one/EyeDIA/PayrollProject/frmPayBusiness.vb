Public Class frmBusiness

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CenterFormThemed(Me, Panel1, Label1)
            ControlHandlers(Me)
            txtBusiness.Text = ReadKey("HRTime\Business")
            txtAddress.Text = ReadKey("HRTime\Address")
            txtPhone.Text = ReadKey("HRTime\Phone")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        txtBusiness.Text = fk_RetString("Select cName from tblCompany")
        txtAddress.Text = fk_RetString("Select Add1 from tblCompany")
        txtAddress.Text = txtAddress.Text & ", " & fk_RetString("Select Add2 from tblCompany")
        txtAddress.Text = txtAddress.Text & ", " & fk_RetString("Select Add3 from tblCompany")
        txtPhone.Text = fk_RetString("Select Phone1 from tblCompany")
        txtPhone.Text = txtPhone.Text & ", " & fk_RetString("Select Phone2 from tblCompany")
        txtPhone.Text = txtPhone.Text & ", " & fk_RetString("Select fax from tblCompany")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Set Business Info", "Add Business Info") = False Then Exit Sub

        Try
            If txtAdminKey.Text = "hrishris" Then
                CreateKey("HRTime\Business", txtBusiness.Text)
                CreateKey("HRTime\Address", txtAddress.Text)
                CreateKey("HRTime\Phone", txtPhone.Text)
                MsgBox("Data Saved Suceessfully", MsgBoxStyle.Information)

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    Private Sub txtBusiness_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBusiness.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtPhone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhone.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtAdminKey_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdminKey.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then cmdExit_Click(sender, e)
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        Button1_Click(sender, e)
    End Sub

End Class