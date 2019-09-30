Public Class frmSetCurrency

    Dim sqlQRY As String = ""
    Dim StrSvStatus As String = "S"

    Private Sub frmDistricts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, pnlTop, Label13)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        _LoadDocs()
        'txtCode.Text = "" : txtDesc.Text = "" : chkStatus.CheckState = CheckState.Unchecked : txtRate.Text = 0
        'txtCode.Text = fk_GenSerial("SELECT NoDist FROM tblControl", 3)
        StrSvStatus = "S"

    End Sub

    Public Sub _LoadDocs()
        sqlQRY = "SELECT aID,cName ,symbol,rate   FROM tblCurrency Order by aID"
        Load_InformationtoGrid(sqlQRY, dgvData, 4) : clr_Grid(dgvData)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
      
    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        sqlQRY = "SELECT cID,cDesc,Status,CompID FROM tblCurrency WHERE cID = '" & txtCode.Text & "'"
        fk_Return_MultyString(sqlQRY, 4)
        txtCode.Text = fk_ReadGRID(0)
        txtDesc.Text = fk_ReadGRID(1)
        chkStatus.CheckState = fk_ReadGRID(2)
        StrSvStatus = "E"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtCode.Text = "" Then MsgBox("Enter Code", MsgBoxStyle.Information) : txtCode.Focus() : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : txtDesc.Focus() : Exit Sub
        If txtRate.Text = "" Then MsgBox("Enter Rate", MsgBoxStyle.Information) : txtRate.Focus() : Exit Sub

        Select Case StrSvStatus
            Case "S"
                'txtCode.Text = fk_GenSerial("SELECt NoDist FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblCurrency (cName ,symbol,rate,cStatus,userID) VALUES ('" & txtDesc.Text & "','" & txtCode.Text & "','" & txtRate.Text & "','" & chkStatus.CheckState & "','" & StrUserID & "')"
            Case "E"
                sqlQRY = "UPDATE tblCurrency SET cName = '" & txtDesc.Text & "',cStatus = " & chkStatus.CheckState & " ,symbol='" & txtCode.Text & "' ,rate='" & txtRate.Text & "',cStatus='" & chkStatus.CheckState & "' WHERe cID = '" & txtCode.Text & "'"
        End Select
        Dim bolSv As Boolean
        bolSv = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then Button2_Click(sender, e)
        'If txtCode.Text = "" Then MsgBox("Enter Code", MsgBoxStyle.Information) : txtCode.Focus() : Exit Sub
        'If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : txtDesc.Focus() : Exit Sub
        'If txtRate.Text = "" Then MsgBox("Enter Rate", MsgBoxStyle.Information) : txtRate.Focus() : Exit Sub

        'Select Case StrSvStatus
        '    Case "S"
        '        txtCode.Text = fk_GenSerial("SELECt NoDist FROM tblControl", 3)
        '        sqlQRY = "INSERT INTO tblCurrency (cID,cDesc,Status,CompID) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ",'" & StrCompID & "')"
        '        'sqlQRY = sqlQRY & "UPDATE tblControl SET NoDist = NoDist + 1"
        '    Case "E"
        '        sqlQRY = "UPDATe tblCurrency SET cDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERe cID = '" & txtCode.Text & "'"
        'End Select
        'Dim bolSv As Boolean
        'bolSv = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        'If bolSv = True Then cmdRefresh_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        _LoadDocs()
        txtCode.Text = "" : txtDesc.Text = "" : chkStatus.CheckState = CheckState.Unchecked : txtRate.Text = ""
        'txtCode.Text = fk_GenSerial("SELECT NoDist FROM tblControl", 3)
        StrSvStatus = "S"
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged

    End Sub
End Class