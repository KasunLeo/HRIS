Public Class frmSetGender

    Dim sqlQRY As String = ""
    Dim StrSvStatus As String = "S"

    Private Sub frmDistricts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, pnlTop, Label13)
        ControlHandlers(Me)
        Button2_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        _LoadDocs()
        txtCode.Text = "" : txtDesc.Text = "" : chkStatus.CheckState = CheckState.Unchecked
        txtCode.Text = fk_GenSerial("SELECT NoGen FROM tblControl", 3)
        StrSvStatus = "S"

    End Sub

    Public Sub _LoadDocs()
        sqlQRY = "SELECT genID,genDesc ,Status FrOM tblGender Order by genID"
        Load_InformationtoGrid(sqlQRY, dgvData, 3) : clr_Grid(dgvData)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtCode.Text = "" Then MsgBox("Enter Code", MsgBoxStyle.Information) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtCode.Text = fk_GenSerial("SELECt NoGen FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblGender (genID,genDesc,Status,CompID) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ",'" & StrCompID & "')"
                sqlQRY = sqlQRY & "UPDATE tblControl SET NoGen = NoGen + 1"
            Case "E"
                sqlQRY = "UPDATe tblGender SET genDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERe genID = '" & txtCode.Text & "'"
        End Select
        Dim bolSv As Boolean
        bolSv = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        sqlQRY = "SELECT genID,genDesc,Status,CompID FROM tblGender WHERE genID = '" & txtCode.Text & "'"
        fk_Return_MultyString(sqlQRY, 4)
        txtCode.Text = fk_ReadGRID(0)
        txtDesc.Text = fk_ReadGRID(1)
        chkStatus.CheckState = fk_ReadGRID(2)
        StrSvStatus = "E"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtCode.Text = "" Then MsgBox("Enter Code", MsgBoxStyle.Information) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtCode.Text = fk_GenSerial("SELECt NoGen FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblGender (genID,genDesc,Status,CompID) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ",'" & StrCompID & "')"
                sqlQRY = sqlQRY & "UPDATE tblControl SET NoGen = NoGen + 1"
            Case "E"
                sqlQRY = "UPDATe tblGender SET genDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERe genID = '" & txtCode.Text & "'"
        End Select
        Dim bolSv As Boolean
        bolSv = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then cmdRefresh_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        _LoadDocs()
        txtCode.Text = "" : txtDesc.Text = "" : chkStatus.CheckState = CheckState.Unchecked
        txtCode.Text = fk_GenSerial("SELECT NoGen FROM tblControl", 3)
        StrSvStatus = "S"
    End Sub

End Class