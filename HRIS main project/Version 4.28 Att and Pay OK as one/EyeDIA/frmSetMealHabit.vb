Public Class frmSetMealHabit
    Dim sqlQRY As String : Dim StrSvStatus As String = "S"

    Private Sub frmMealHabit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        sqlQRY = "CREATE TABLE tblMHabit (sCode Nvarchar (3),sDesc Nvarchar (50),Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD noMHabit Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblEmployee ADD mHabitID Nvarchar (3) NOT NULL Default ''" : FK_EQ(sqlQRY, "S", "", False, False, False)

        Button3_Click(sender, e)


    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
       
    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        If dgvData.RowCount = 0 Then Exit Sub
        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        sqlQRY = "SELECT sCode,sDesc,Status FROM tblMHabit WHERE sCode = '" & txtCode.Text & "'"
        fk_Return_MultyString(sqlQRY, 3)
        txtCode.Text = fk_ReadGRID(0) : txtDesc.Text = fk_ReadGRID(1) : chkStatus.CheckState = fk_ReadGRID(2)
        StrSvStatus = "E"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtCode.Text = "" Then MsgBox("Refresh Form", MsgBoxStyle.Information) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description ", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtCode.Text = fk_GenSerial("SELECT NoMHabit FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblMHabit (sCode,sDesc,compid,status) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "','" & StrCompID & "'," & chkStatus.CheckState & ")"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoMHabit = NoMHabit + 1"

            Case "E"
                sqlQRY = "UPDATE tblMHabit SET sDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERE sCode = '" & txtCode.Text & "'"

        End Select
        Dim bolSave As Boolean
        bolSave = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSave = True Then Button3_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FK_Clear(Me)

        txtCode.Text = fk_GenSerial("SELECT NoMHabit FROM tblControl", 3)
        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT sCode,sDesc FROM tblMHabit Order By sCode", dgvData, 2)
        clr_Grid(dgvData)
    End Sub
End Class
