Public Class frmSetEduTypes
    Dim StrSvStatus As String = "S"
    Dim sqlQRY As String = ""

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

       
    End Sub

    Private Sub frmEduTypes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        Button2_Click(sender, e)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtCode.Text = "" Then MsgBox("Enter Code", MsgBoxStyle.Information) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtCode.Text = fk_GenSerial("SELECt NoEduType FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblEduType (sCode,sDesc,Status,CompID) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ",'" & StrCompID & "')"
                sqlQRY = sqlQRY & "UPDATE tblControl SET NoTransport = NoTransport + 1"
            Case "E"
                sqlQRY = "UPDATe tblTransportType SET cDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERe sCode = '" & txtCode.Text & "'"
        End Select
        Dim bolSv As Boolean
        bolSv = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then cmdRefresh_Click(sender, e)
    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        If dgvData.RowCount = 0 Then Exit Sub
        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        sqlQRY = "SELECT sCode,sDesc,Status FROM tblEduType WHERE DeptID = '" & txtCode.Text & "'"
        fk_Return_MultyString(sqlQRY, 3)
        txtCode.Text = fk_ReadGRID(0) : txtDesc.Text = fk_ReadGRID(1) : chkStatus.CheckState = fk_ReadGRID(2)
        StrSvStatus = "E"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If txtCode.Text = "" Then MsgBox("Refresh Form", MsgBoxStyle.Information) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description ", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtCode.Text = fk_GenSerial("SELECT NoEduType FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblEduType (sCode,sDesc,compid,status) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "','" & StrCompID & "'," & chkStatus.CheckState & ")"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoEduType = NoEduType + 1"

            Case "E"
                sqlQRY = "UPDATE tblEduType SET sDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERE sCode = '" & txtCode.Text & "'"

        End Select
        Dim bolSave As Boolean
        bolSave = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSave = True Then Button2_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkStatus.Checked = False
        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoEduType FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT sCode,sDesc FROM tblEduType Order By sDesc", dgvData, 2)
        clr_Grid(dgvData)
    End Sub

End Class