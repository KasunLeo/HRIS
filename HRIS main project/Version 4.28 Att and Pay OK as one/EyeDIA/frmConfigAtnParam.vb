Public Class frmConfigAtnParam
    Dim sqlQRY As String = "" : Dim StrSvStatus As String = "S" : Dim StrFldName As String = "" : Dim StrFldID As String = ""


    Private Sub frmConfigAtnParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sqlQRY = "CREATE TABLE tblAttnFldConfig (cID nvarchar (4),fldID Nvarchar (3),fldDesc Nvarchar (100),sqlQRY Varchar(8000),Status Numeric (18,0) NOT NULL Default 0)" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD NoAtnCPrf Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)

        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        txtFldNames.Clear() : txtID.Clear() : txtQry.Clear() : txtSpDesc.Clear()
        txtID.Text = fk_GenSerial("SELECT NoAtnCPrf FROM tblControl", 4)
        StrSvStatus = "S"
        'Load Grid 
        Dim sqlLoad As String = "SELECT cID,fldDesc FROM tblAttnFldConfig Order By cID"
        Load_InformationtoGrid(sqlLoad, dgvData, 2)
        FillCombo(cmbAttFeild, "SELECT Descr FROM tblATTParam WHERE Status = 0", "NONE")
        clr_Grid(dgvData)
    End Sub

    Private Sub cmbAttFeild_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAttFeild.SelectedIndexChanged
        fk_Return_MultyString("SELECT pID,fldname,Descr FROM tblATTParam WHERE Descr = '" & cmbAttFeild.Text & "'", 3)
        StrFldID = fk_ReadGRID(0) : StrFldName = fk_ReadGRID(1) : txtSpDesc.Text = fk_ReadGRID(2) : txtFldNames.Text = "tblMonthlySummary." & StrFldName
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Attendance Summary", "Configure attendance parameters") = False Then Exit Sub
        If txtID.Text = "" Then MsgBox("Enter ID", MsgBoxStyle.Information) : Exit Sub
        If txtQry.Text = "" Then MsgBox("Enter Query", MsgBoxStyle.Information) : Exit Sub

        Select Case StrSvStatus
            Case "S"
                sqlQRY = "INSERT INTO tblAttnFldConfig VALUES ('" & txtID.Text & "','" & StrFldID & "','" & txtSpDesc.Text & "','" & txtQry.Text & "',0)"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoAtnCPrf = NoAtnCPrf + 1"
            Case "E"
                sqlQRY = "UPDATE tblAttnFldConfig SET fldID = '" & StrFldID & "',fldDesc = '" & txtSpDesc.Text & "',sqlQRY = '" & txtQry.Text & "' WHERE cID = '" & txtID.Text & "'"

        End Select
        FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub dgvData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.Click
        txtID.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick

        Try
            sqlQRY = "select tblAttnFldConfig.cID,tblAttnFldConfig.fldID,tblATTParam.Descr,tblAttParam.FldName,tblAttnFldConfig.fldDesc,tblAttnFldConfig.sqlQRY FROM tblATTParam,tblAttnFldConfig WHERE tblATTParam.pID = tblAttnFldConfig.fldID AND tblAttnFldConfig.cID = '" & txtID.Text & "'"
            fk_Return_MultyString(sqlQRY, 6)

            txtID.Text = fk_ReadGRID(0) : cmbAttFeild.Text = fk_ReadGRID(2) : StrFldID = fk_ReadGRID(1) : txtFldNames.Text = fk_ReadGRID(3) : txtSpDesc.Text = fk_ReadGRID(4) : txtQry.Text = fk_ReadGRID(5)
            StrSvStatus = "E"

        Catch ex As Exception


        End Try
    End Sub

End Class