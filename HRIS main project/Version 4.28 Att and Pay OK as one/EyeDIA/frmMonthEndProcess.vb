Public Class frmMonthEndProcess

    Private Sub frmMonthEndProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refsh()
    End Sub

 
    Private Sub refsh()
        ListCombo(CboxYear, "SELECT year FROM tblAttMonthEnd GROUP BY year", "year")
        ListCombo(CboxMonth, "SELECT Month FROM tblAttMonthEnd GROUP BY month ", "month")

        Dim LvCanclLastEnd As DateTime = fk_RetString(" SELECT CONVERT(DATETIME,CAST([Year] AS VARCHAR(4))+ RIGHT('00'+CAST([Month] AS VARCHAR(2)),2)+ RIGHT('00'+CAST(1 AS VARCHAR(2)),2)) from tblAttMonthEnd  WHERE id = (SELECT MAX(id) from tblAttMonthEnd where lLeaveCancel = 1)")
        lblLvCancelDate.Text = Format(LvCanclLastEnd.AddDays(-1), "dd/MM/yyyy")
        Dim LvApplyLastEnd As DateTime = fk_RetString(" SELECT CONVERT(DATETIME,CAST([Year] AS VARCHAR(4))+ RIGHT('00'+CAST([Month] AS VARCHAR(2)),2)+ RIGHT('00'+CAST(1 AS VARCHAR(2)),2)) from tblAttMonthEnd  WHERE id = (SELECT MAX(id) from tblAttMonthEnd where lLeaveApply = 1)")
        lblLvApplyDate.Text = Format(LvApplyLastEnd.AddDays(-1), "dd/MM/yyyy")
        Dim RosterLastEnd As DateTime = fk_RetString(" SELECT CONVERT(DATETIME,CAST([Year] AS VARCHAR(4))+ RIGHT('00'+CAST([Month] AS VARCHAR(2)),2)+ RIGHT('00'+CAST(1 AS VARCHAR(2)),2)) from tblAttMonthEnd  WHERE id = (SELECT MAX(id) from tblAttMonthEnd where lRoster = 1)")
        lblRosterChange.Text = Format(RosterLastEnd.AddDays(-1), "dd/MM/yyyy")
        Dim AttAdjustLastEnd As DateTime = fk_RetString(" SELECT CONVERT(DATETIME,CAST([Year] AS VARCHAR(4))+ RIGHT('00'+CAST([Month] AS VARCHAR(2)),2)+ RIGHT('00'+CAST(1 AS VARCHAR(2)),2)) from tblAttMonthEnd  WHERE id = (SELECT MAX(id) from tblAttMonthEnd where lAttendance = 1)")
        lblAttenAdust.Text = Format(AttAdjustLastEnd.AddDays(-1), "dd/MM/yyyy")

    End Sub

    Private Sub CboxMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboxMonth.SelectedIndexChanged
        chkLeaveCancel.CheckState = fk_sqlDbl(" SELECT  lLeaveCancel  from tblAttMonthEnd  WHERE year ='" & CboxYear.Text & "' AND month ='" & CboxMonth.Text & "'  ")
        chkAttendanceAdjuest.CheckState = fk_sqlDbl(" SELECT  lAttendance  from tblAttMonthEnd  WHERE year ='" & CboxYear.Text & "' AND month ='" & CboxMonth.Text & "'  ")
        chkLeaveApply.CheckState = fk_sqlDbl(" SELECT  lLeaveApply  from tblAttMonthEnd  WHERE year ='" & CboxYear.Text & "' AND month ='" & CboxMonth.Text & "'  ")
        chkRosterChange.CheckState = fk_sqlDbl(" SELECT  lRoster  from tblAttMonthEnd  WHERE year ='" & CboxYear.Text & "' AND month ='" & CboxMonth.Text & "'  ")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sSQL = "UPDATE tblAttMonthEnd SET lRoster = '" & chkRosterChange.CheckState & "' ,lLeaveApply = '" & chkLeaveApply.CheckState & "' ,lLeaveCancel = '" & chkLeaveCancel.CheckState & "' , lAttendance = '" & chkAttendanceAdjuest.CheckState & "' WHERE year = '" & CboxYear.Text & "' AND month ='" & CboxMonth.Text & "' "
        FK_EQ(sSQL, "E", "", True, True, True)

        sSQL = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Month End For : Year : " & CboxYear.Text & " / Month : " & CboxMonth.Text & " End Task : Attendance Adjustment : " & chkAttendanceAdjuest.CheckState & " / Roster Change : " & chkRosterChange.CheckState & " / Leave Apply : " & chkLeaveApply.CheckState & " / Leave Cancel : " & chkLeaveCancel.CheckState & "' ,'" & StrUserID & "',getdate ())"
        FK_EQ(sSQL, "E", "", False, False, False)

    End Sub
End Class