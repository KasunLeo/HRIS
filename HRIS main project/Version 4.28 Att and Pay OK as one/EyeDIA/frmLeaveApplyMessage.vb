Public Class frmLeaveApplyMessage

    Private Sub frmLeaveApplyMessage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'bolLate = chkLate.CheckState
        'bolEarly = chkEarly.CheckState
    End Sub

    Private Sub frmLeaveApplyMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel11, Label16)
        ControlHandlers(Me)
        sSQL = "select " & sqlTag1 & " ,dispName from tblEmployee WHERE regiD='" & StrEmployeeID & "'"
        fk_Return_MultyString(sSQL, 2)
        lblEmpNo.Text = fk_ReadGRID(0) : lblName.Text = fk_ReadGRID(1)
        lblDate.Text = dtGlobalDate
        If intGlbLateMinutes = 0 Then chkLate.Visible = False
        If intGlbEarlyMinutes = 0 Then chkEarly.Visible = False
        lblLate.Text = "Late Minutes : " & intGlbLateMinutes
        lblEarly.Text = "Early Minutes : " & intGlbEarlyMinutes
        intGlbLateStatus = 0
        intGlbEarlyStatus = 0
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If chkLate.Checked = False And chkEarly.Checked = False Then
            Dim dr As DialogResult = MessageBox.Show("You didn't right off late or early, Do you want to continue without changes ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            If dr = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
        If chkLate.Checked = True Then
            intGlbLateStatus = 1
        End If
        If chkEarly.Checked = True Then
            intGlbEarlyStatus = 1
        End If
        Me.Close()
    End Sub
End Class