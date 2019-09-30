Public Class frmSetAttnParam
    Dim sqlQRY As String = "" : Dim StrSvStatus As String = "S"

    Private Sub frmAttnParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sqlQRY = "CREATE TABLE tblATTParam (pID Nvarchar (3),Descr Nvarchar (100),fldName Nvarchar (40),Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD NoAttPara Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False) : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblATTParam ADD VisibleInR Numeric (18,0) NOT NULL Default 1" : FK_EQ(sqlQRY, "S", "", False, False, False)

        CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        FK_Clear(Me)
        txtID.Text = fk_GenSerial("SELECT NoAttPara FROM tblControl", 3)
        StrSvStatus = "S"
        'Load Grid 
        Dim sqlLoad As String = "SELECT pID,Descr,fldName FROM tblATTParam Order By pID"
        Load_InformationtoGrid(sqlLoad, dgvData, 3)
        clr_Grid(dgvData)
    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        sqlQRY = "SELECT pID,Descr,fldname,Status,VisibleInR FROM tblATTParam WHERE pID = '" & dgvData.Item(0, dgvData.CurrentRow.Index).Value & "'"
        fk_Return_MultyString(sqlQRY, 5)
        txtID.Text = fk_ReadGRID(0) : txtName.Text = fk_ReadGRID(1) : txtfldName.Text = fk_ReadGRID(2) : chkRemoved.CheckState = CInt(fk_ReadGRID(3)) : chkVisibleInRep.CheckState = CInt(fk_ReadGRID(4)) : StrSvStatus = "E"
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Attendance Summary", "Create summary parameter(s)") = False Then Exit Sub
        'Check Existing Items 
        Dim bolEx As Boolean = False
        bolEx = fk_CheckEx("SELECT * FROM tblAttParam WHERE pID = '" & txtID.Text & "'")
        If txtID.Text = "" Then MsgBox("Enter ID", MsgBoxStyle.Information) : Exit Sub
        If txtName.Text = "" Then MsgBox("Enter Name", MsgBoxStyle.Information) : Exit Sub
        If txtfldName.Text = "" Then MsgBox("Enter Feild Name", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                If bolEx = True Then MsgBox("Record Duplicating", MsgBoxStyle.Information) : Exit Sub
                sqlQRY = "INSERT INTO tblAttParam VALUES ('" & txtID.Text & "','" & txtName.Text & "','" & txtfldName.Text & "'," & chkRemoved.CheckState & "," & chkVisibleInRep.CheckState & ")"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoAttPara = NoAttPara + 1"
            Case "E"
                If bolEx = False Then MsgBox("No Record Found", MsgBoxStyle.Information) : Exit Sub
                sqlQRY = " UPDATE tblAttParam SET VisibleInR = " & chkVisibleInRep.CheckState & ", Descr = '" & txtName.Text & "',fldName = '" & txtfldName.Text & "',Status = " & chkRemoved.CheckState & " WHERE pID = '" & txtID.Text & "'"
        End Select
        FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class