Public Class frmMenuSelector
    Private Sub pnlHrMid_Paint(sender As Object, e As PaintEventArgs) Handles pnlHrMid.Paint

    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        frmLogink.ShowDialog()
        If bolLogged = True Then
            strLogedinTo = "Profile"
            btnProf.Enabled = True
            btnLeave2.Enabled = True
        End If
        Me.Close()
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        frmLogink.ShowDialog()
        If bolLogged = True Then
            strLogedinTo = "Attendance"
            btnDownl3.Enabled = True
            btnDashb4.Enabled = True
            btnSync5.Enabled = True
        End If
        Me.Close()
    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        frmLogin.ShowDialog()
        If bolLoggedPay = True Then
            strLogedinTo = "Payroll"
            btnPayEPF.Enabled = True
            btnPayMonthly6.Enabled = True
            btnPayProces7.Enabled = True
            btnPaySLIP.Enabled = True
        End If
        Me.Close()
    End Sub

End Class