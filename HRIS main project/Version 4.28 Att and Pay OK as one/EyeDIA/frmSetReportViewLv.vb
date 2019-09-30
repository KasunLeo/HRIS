Public Class frmSetReportViewLv

    Dim StrSvStatus As String = "S"
    Dim StrLvID As String = ""
    Dim StrAllDept As String : Dim StrAllBranches As String

    Private Sub frmUserViewLv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label1)
        CenterFormThemed(Me, Panel5, Label6)
        ControlHandlers(Me)
        Dim sqlTable As String
        cmdrefresh_Click(sender, e)
    End Sub

    Private Sub cmdrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdrefresh.Click

        FK_Clear(Me)
        txtID.Text = fk_GenSerial("SELECT NovURLv FROM tblControl", 2)
        'Load Details to grid 
        Load_InformationtoGrid("SELECT rID,rDesc FROM [tblUserReporViewLv] Order By rDesc", dgvDetails, 2)
        clr_Grid(dgvDetails)

        StrSvStatus = "S"

    End Sub

    Private Sub dgvDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetails.DoubleClick
        txtID.Text = dgvDetails.Item(0, dgvDetails.CurrentRow.Index).Value

        fk_Return_MultyString("SELECT rID,rDesc FROM [tblUserReporViewLv] WHERE rID = '" & txtID.Text & "'", 2)
        txtID.Text = fk_ReadGRID(0)
        txtDesc.Text = fk_ReadGRID(1)

        StrSvStatus = "E"
    End Sub

    Private Sub cmbUserLv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReportLv.SelectedIndexChanged
        Load_InformationtoGrid("SELECT 'False',RepID,rname from tblreports Order By rname", dgvReport, 3)
        StrLvID = fk_RetString("SELECT rID FROM tblUserReporViewLv WHERE rDesc = '" & cmbReportLv.Text & "'")
        If StrLvID = "" Then Exit Sub
        fk_Return_MultyString("SELECT rID,VRepID FROM tblUserReporViewLv WHERE RID = '" & StrLvID & "'", 2)
        StrLvID = fk_ReadGRID(0)
        StrAllDept = fk_ReadGRID(1)
        If StrAllDept <> "" Then fk_SetGridCLICK(dgvReport, 0, 1, StrAllDept)
        'fk_SetGridCLICK
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim iTab As Integer
        iTab = TabControl1.SelectedIndex
        Select Case iTab
            Case 0
                cmdrefresh_Click(sender, e)
            Case 1
                cmduRefresh_Click(sender, e)
        End Select
    End Sub

    Private Sub cmduRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUrefresh.Click
        ListCombo(cmbReportLv, "SELECT * FROM [tblUserReporViewLv] Order By rDesc", "rDesc")
        Load_InformationtoGrid("SELECT 'False',RepID,rname from tblreports Order By rname", dgvReport, 3)
        clr_Grid(dgvReport)
    End Sub

    Private Sub cmdSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Set report view level", "Create report view levels") = False Then Exit Sub
        If txtID.Text = "" Then MsgBox("No ID found", MsgBoxStyle.Information) : cmdrefresh_Click(sender, e) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : txtDesc.Focus() : Exit Sub

        Dim sqlQRY As String = ""
        If StrSvStatus = "S" Then txtID.Text = fk_GenSerial("SELECT NovURlv FROM tblControl", 2)
        sqlQRY = "if not exists (select * from [tblUserReporViewLv] WHERE rID = '" & txtID.Text & "') " & _
            " begin insert into [tblUserReporViewLv] values ('" & txtID.Text & "','" & txtDesc.Text & "',0,'') UPDate tblCOntrol Set NovURlv = NovURlv + 1 end " & _
            " else begin update [tblUserReporViewLv] set rDesc = '" & txtDesc.Text & "' where rID = '" & txtID.Text & "' end"
        Dim bolSv As Boolean = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then cmdrefresh_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UP("Set report view level", "Assign reports to report view levels") = False Then Exit Sub
        StrAllDept = fk_getGridCLICK(dgvReport, 0, 1)
        Dim sqlQRY As String = "UPDATE tblUserReporViewLv SET VRepID = '" & StrAllDept & "' WHERE rID = '" & StrLvID & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub chkAllReport_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkAllReport.MouseClick
        For i As Integer = 0 To dgvReport.RowCount - 1
            dgvReport.Item(0, i).Value = chkAllReport.CheckState
        Next
    End Sub

End Class