Public Class FrmBankFileHeader

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        FK_Clear(Me)
        sSQL = "Alter table tblcontrol Add BHID decimal(18,0) not null Default 0"
        EQ(sSQL)
        ''sSQL = "create table tblbankHead (ID varchar(3), HName varchar(30),OrigiBankNo varchar(4),OrigiBranchNo varchar(3),OrigiAccNo varchar(12),OrigiAccName varchar(20),status  decimal(1,0) not null default 0)"
        ''EQ(sSQL)
        sSQL = "Select BHID+1 from tblcontrol"
        txtID.Text = Format(GetVal(sSQL), "00#")
        txtName.Focus()
        strSaveStatus = "S"
    End Sub

    Private Sub FrmBankFileHeaders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label4)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub txtOriginatingBankNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOriginatingBankNo.TextChanged
        T1.Text = Len(txtOriginatingBankNo.Text)
    End Sub

    Private Sub txtOriBranchNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOriBranchNo.TextChanged
        T2.Text = Len(txtOriBranchNo.Text)
    End Sub

    Private Sub txtOriAccNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOriAccNo.TextChanged
        T3.Text = Len(txtOriAccNo.Text)
    End Sub

    Private Sub txtOriAccName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOriAccName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Call btnSave_click(sender, e)
    End Sub

    Private Sub txtOriAccName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOriAccName.TextChanged
        T4.Text = Len(txtOriAccName.Text)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then MsgBox("Please Enter Name for the Bank Header", MsgBoxStyle.Information)
        If Len(txtOriginatingBankNo.Text) <> 4 Then MsgBox("Please Fill the Selected, Lenth is 4", MsgBoxStyle.Information) : txtOriginatingBankNo.Focus() : Exit Sub
        If Len(txtOriBranchNo.Text) <> 3 Then MsgBox("Please Fill the Selected, Lenth is 3", MsgBoxStyle.Information) : txtOriBranchNo.Focus() : Exit Sub
        If Len(txtOriAccNo.Text) <> 12 Then MsgBox("Please Enter Originating Account No", MsgBoxStyle.Information) : txtOriAccNo.Focus() : Exit Sub
        If Len(txtOriAccName.Text) <> 20 Then MsgBox("Please Enter Originating Account Name", MsgBoxStyle.Information) : txtOriAccName.Focus() : Exit Sub
        If strSaveStatus = "S" Then
            sSQL = "Select BHID+1 from tblcontrol"
            txtID.Text = Format(GetVal(sSQL), "00#")
            sSQL = "Insert into tblbankHead  (ID,HName,OrigiBankNo,OrigiBranchNo,OrigiAccNo,OrigiAccName) " & _
            " values ('" & txtID.Text & "','" & txtName.Text & "','" & txtOriginatingBankNo.Text & "','" & txtOriBranchNo.Text & "','" & txtOriAccNo.Text & "','" & txtOriAccName.Text & "'); update tblcontrol set BHID=BHID+1 "
            If FK_EQ(sSQL, "S", "", False, True, True) = True Then Call cmdRefresh_Click(sender, e)
        End If

        If strSaveStatus = "E" Then
            sSQL = " update tblbankHead set HName='" & txtName.Text & "',OrigiBankNo='" & txtOriginatingBankNo.Text & "' " & _
             " , OrigiBranchNo='" & txtOriBranchNo.Text & "',OrigiAccNo='" & txtOriAccNo.Text & "',OrigiAccName='" & txtOriAccName.Text & "' WHERE ID='" & txtID.Text & "';"
            If FK_EQ(sSQL, "E", "", True, True, True) = True Then Call cmdRefresh_Click(sender, e)
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        sSQL = "Select * from tblbankHead"
        If FK_Br(sSQL) = True Then
            strSaveStatus = "E"
            txtID.Text = FK_Read("ID")
            txtName.Text = FK_Read("HNAME")
            txtOriginatingBankNo.Text = FK_Read("OrigiBankNo")
            txtOriBranchNo.Text = FK_Read("OrigiBranchNo")
            txtOriAccNo.Text = FK_Read("OrigiAccNo")
            txtOriAccName.Text = FK_Read("OrigiAccName")
        End If
    End Sub
End Class