Public Class frmSetElectorate
    Dim sqlQRY As String = ""
    Dim StrSvStatus As String = "S"

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmElectorate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sqlQRY = "CREATE TABLE tblElectorate (cID Nvarchar (3),cDesc Nvarchar (100),Status Numeric (18,0),CompID Nvarchar (3))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD NoElect Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)

        'CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        _LoadDocs()
        txtCode.Text = "" : txtDesc.Text = "" : chkStatus.CheckState = CheckState.Unchecked
        txtCode.Text = fk_GenSerial("SELECT NoElect FROM tblControl", 3)
        StrSvStatus = "S"

    End Sub

    Public Sub _LoadDocs()
        sqlQRY = "SELECT cID,cDesc ,Status FrOM tblElectorate Order by cID"
        Load_InformationtoGrid(sqlQRY, dgvData, 3) : clr_Grid(dgvData)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
       
    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        sqlQRY = "SELECT cID,cDesc,Status,CompID FROM tblElectorate WHERE cID = '" & txtCode.Text & "'"
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
                txtCode.Text = fk_GenSerial("SELECt NoElect FROM tblControl", 3)
                sqlQRY = "INSERT INTO tblElectorate (cID,cDesc,Status,CompID) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ",'" & StrCompID & "')"
                sqlQRY = sqlQRY & "UPDATE tblControl SET NoElect = NoElect + 1"
            Case "E"
                sqlQRY = "UPDATe tblElectorate SET cDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERe cID = '" & txtCode.Text & "'"
        End Select
        Dim bolSv As Boolean
        bolSv = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        _LoadDocs()
        txtCode.Text = "" : txtDesc.Text = "" : chkStatus.CheckState = CheckState.Unchecked
        txtCode.Text = fk_GenSerial("SELECT NoElect FROM tblControl", 3)
        StrSvStatus = "S"
    End Sub

End Class