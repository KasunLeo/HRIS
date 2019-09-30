Imports System.Data.SqlClient

Public Class frmSetProcesCategory

    Dim StrSvStatus As String = "S"

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

       
    End Sub

    Private Sub frmSetProcesCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label3)
        ControlHandlers(Me)
        Button3_Click(sender, e)
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim sSQL As String
        'sSQL = "Update tblSetPrCategory set Status=1 where CatID='" & txtCode.Text & "'"
        'FK_EQ(sSQL, "D", "", True, True, True)
        'Button17.Enabled = False
        'Call Button1_Click(sender, e)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then Call cmdSave_Click(sender, e)
        CleanInput(e)

    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick

        'On Error Resume Next
        'StrSvStatus = "E"
        'txtCode.Text = dgvData.Item(0, dgvData.CurrentCell.RowIndex).Value
        'txtDesc.Text = dgvData.Item(1, dgvData.CurrentCell.RowIndex).Value
        'Button17.Enabled = True

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

       

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtDesc.Text.Trim = "" Then
            MsgBox("Please Enter the Description")
            txtDesc.Focus()
            Exit Sub
        End If

        Dim sSQL As String
        Select Case StrSvStatus
            Case "S"
                sSQL = "Insert into tblSetPrCategory (CatID,CatDesc,CompID,Status) values ('" & txtCode.Text & "','" & txtDesc.Text & "',00," & chkStatus.CheckState & ") upDate tblControl set NoPrCatagory=NoPrCatagory+1"
                FK_EQ(sSQL, "P", "", True, True, True)
                txtDesc.Focus()
                Call Button3_Click(sender, e)

            Case "E"
                'sSQL = " update tblSetPrcCategory set catDesc='" & txtDesc.Text & "', compid=00, status=" & chkStatus.CheckState & " where catid='" & txtCode.Text & "'"
                Save_Codes(StrSvStatus, txtCode.Text, txtDesc.Text, chkStatus.CheckState, "NoPrCatagory", "tblSetPrCategory", "CatID", "CatDesc")
                txtDesc.Focus()
                Call Button3_Click(sender, e)

        End Select

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        StrSvStatus = "S"
        txtCode.Text = GetVal("SELECT NoPrCatagory FROM tblControl") + 1
        txtDesc.Text = ""
        chkStatus.Checked = False
        Dim sSQL As String
        sSQL = "SELECT CatID,CatDesc FROM tblSetPrCategory where status=0 Order By CatID"
        Load_InformationtoGrid(sSQL, dgvData, 2)
    End Sub
End Class