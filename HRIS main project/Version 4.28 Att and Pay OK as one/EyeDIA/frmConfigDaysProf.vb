Public Class frmConfigDaysProf

    Dim StrSv_Status As String = "S"
    Dim StrCode As String = ""

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        dgvData.Rows.Clear()
        txtCode.Clear()
        txtDesc.Clear()

        'Load Details to Combo
        Dim sqlQRY As String = ""
        sqlQRY = "select Column_name  from information_Schema.columns where table_name = 'tblEmpRegister' AND Data_Type  = 'Numeric' order by Column_name"
        ListCombo(cmbFildName, sqlQRY, "Column_Name")

        'Generate Serial Number  for the Existing values 
        StrCode = fk_GenSerial("SELECT p_NoCfg FROM tblControl", 3)
        txtCode.Text = StrCode

        'Load to Grid 
        sqlQRY = "SELECT c_ID,c_Desc FROM tblDaySettings WHERE r_status =0 "
        Load_InformationtoGrid(sqlQRY, dgvData, 2) : clr_Grid(dgvData)
        StrSv_Status = "S"
    End Sub

    Private Sub frmConfigDaysProf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlQRY As String = ""
        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)

        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim BolSave As Boolean = False
        Dim sqlQRY As String = ""

        Select Case StrSv_Status
            Case "S"

                'Insert into Details
                sqlQRY = "INSERT INTO tblDaySettings (c_ID,c_desc,fldName,r_Status)  VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "','" & cmbFildName.Text & "',0)"
                sqlQRY = sqlQRY & "UPDATE tblControl SET p_NoCfg = p_NoCfg + 1"

            Case "E"

                sqlQRY = "UPDATE tblDaySettings SEt c_desc = '" & cmbFildName.Text & "',fldName = '" & cmbFildName.Text & "' WHERE c_ID = '" & txtCode.Text & "'"

        End Select
        BolSave = FK_EQ(sqlQRY, StrSv_Status, "", False, True, True)
        If BolSave = True Then cmdRefresh_Click(sender, e)
    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        StrCode = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        Dim sqlQRY As String = "SELECT c_ID,c_Desc,fldName,r_Status FROM tblDaySettings WHERE c_ID = '" & StrCode & "'"
        fk_Return_MultyString(sqlQRY, 4)
        txtCode.Text = fk_ReadGRID(0) : txtDesc.Text = fk_ReadGRID(1) : cmbFildName.Text = fk_ReadGRID(2) : chkStatus.CheckState = fk_ReadGRID(3)
        StrSv_Status = "E"
    End Sub

End Class