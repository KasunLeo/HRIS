Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmEmpLeave

    Dim StrLvID As String 'Double Click LeaveID
    Dim StrLvSaveSt As String = "S"

    Private Sub frmEmpLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'check statement
        Button2_Click(sender, e)
        ControlHandlers(Me)
        'CenterFormThemed(Me, Panel1, Label25)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel3.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel3.BackColor, 90)

    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdReport.MouseDown

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.Panel3.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdReport.MouseUp

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.Panel3.BackColor

    'End Sub

    Public Sub sv_Leaves(ByVal empcat As String)

        Dim dgvEmp As DataGridView
        dgvEmp = New DataGridView
        With dgvEmp
            .Columns.Clear()
            .Columns.Add("EmpIDs", "Employee ID")
            .Columns.Add("CatIDs", "Category ID")
            .Columns.Add("CompIDs", "CompID")

        End With

        'Load Information to the grid 
        Load_InformationtoGrid("SELECT RegID,CatID,CompID FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "' Order By RegID", dgvEmp, 3)

        'Load Leave Information to the Leave GRID for  each Employee
        'Generate the Leave GRID
        Dim dgvLv As DataGridView
        dgvLv = New DataGridView

        With dgvLv
            .Columns.Clear()
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("CompID", "CompID")
            .Columns.Add("cYear", "cYear")
            .Columns.Add("LeaveID", "LeaveID")
            .Columns.Add("NoLeave", "NoLeave")
            .Columns.Add("TakenLv", "TakenLv")
            .Columns.Add("Status", "Status")

        End With
        With dgvEmp
            For i As Integer = 0 To .RowCount - 2
                Load_InformationtoGridNoClr("select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "'," & intCurrentYear & ", " & _
                                       " tblLeaveType.lvID,dbo.fk_RetNoLeave('" & .Item(1, i).Value & "',tblLeaveType.LvID) as NoLv,dbo.fk_EmpRetNoLeave(tblLeaveType.LvID,'" & .Item(0, i).Value & "',2012),0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLv, 7)

            Next
        End With
        'Insert all information to tblEmployee Leave File
        Dim sqlQRY As String
        With dgvLv
            'Update tblEm
            sqlQRY = "DELETE FROM tblEmpLeaveD WHERE EmpID = '" & StrEmployeeID & "'"
            For i As Integer = 0 To .RowCount - 2
                sqlQRY = sqlQRY & " INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES ('" & .Item(0, i).Value & "', " & _
                " '" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, i).Value & "', " & CDbl(.Item(4, i).Value) & "," & CDbl(.Item(5, i).Value) & ",1)"
            Next
        End With
        FK_EQ(sqlQRY, "P", "", False, False, False)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub dgvLvHist_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLvHist.CellDoubleClick

        'Modify Personal Leave Information 
        StrLvID = dgvLvHist.Item(0, dgvLvHist.CurrentRow.Index).Value

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave,(tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) as BalLeave " & _
            " from tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND " & _
            " tblEmpLeaveD.CompID = '" & StrCompID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " AND tblEmpLeaveD.LeaveID = '" & StrLvID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtLvName.Text = IIf(IsDBNull(drShw.Item("LvDesc")), "", drShw.Item("LvDesc"))
                txtLvQty.Text = IIf(IsDBNull(drShw.Item("NoLeaves")), "0", drShw.Item("NoLeaves"))

                StrLvSaveSt = "E"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub txtLvQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If AscW(e.KeyChar) <> 13 Then
            proc_OnlyNumeric1(e)

        End If
    End Sub

    Private Sub txtLvQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click

        strLoadReport = "rpt_EmpLeaveReport.rpt"
        If StrDeptID = "" Then 'If All Department
            StrSelectionFomula = "{tblLeaveTRD.LvDate}>= Date('" & Format(dtpFrDate.Value, "yyyy,MM,dd") & "') AND  {tblLeaveTRD.LvDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "') AND {tblLeaveTRH.Status} = 0 AND {tblEmployee.RegID} = '" & StrEmployeeID & "'"
        Else
            StrSelectionFomula = "{tblLeaveTRD.LvDate}>= Date('" & Format(dtpFrDate.Value, "yyyy,MM,dd") & "') AND  {tblLeaveTRD.LvDate} <= Date ('" & Format(dtpToDate.Value, "yyyy,MM,dd") & "') AND {tblEmployee.DeptID} = '" & StrDeptID & "' AND {tblLeaveTRH.Status} = 0 AND {tblEmployee.RegID} = '" & StrEmployeeID & "'"
        End If

        StrRpFromDate = Format(dtpFrDate.Value, "dd/MM/yyyy")
        StrRpToDate = Format(dtpToDate.Value, "dd/MM/yyyy")

        StrRepHeadPath = Application.StartupPath
        StrRepFile = StrRepHeadPath & "\Reports\" & strLoadReport
        Dim frmRep As New frmRepContainerAttn
        frmRep.WindowState = FormWindowState.Maximized
        frmRep.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtLvName.Text = "" Then
            MsgBox("Select the Leave", MsgBoxStyle.Information)
            Exit Sub

        End If

        If txtLvQty.Text = "" Then txtLvQty.Text = "0"
        If CDbl(txtLvQty.Text) = 0 Then
            If MsgBox("Do you want to continue with Zero Leave Qty ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        End If
        '0114344163

        If StrLvID = "" Then
            MsgBox("Select the Leave", MsgBoxStyle.Information)
            Exit Sub
        End If

        'Get the Sql Audit QRY
        Dim sqlAUDIT As String
        Dim StrMs As String = "Modify Leave of Emp " & StrEmployeeID & " of " & StrLvID

        sqlAUDIT = sv_Audit(Me.Name, "NF", StrMs, StrUserID, 0)


        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim sqlQRY As String
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Try
            'Update the Leave information 
            sqlQRY = "UPDATE tblEmpLeaveD Set NoLeaves = " & CDbl(txtLvQty.Text) & " WHERE EmpID = '" & StrEmployeeID & "' AND LeaveID = '" & StrLvID & "' AND CompID = '" & StrCompID & "' AND cYear = " & intCurrentYear & ""
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = sqlAUDIT
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            trSave.Commit()
            MsgBox("Leave information Modified", MsgBoxStyle.Information)
            Button2_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim crtl As Control
        For Each crtl In Me.TabPage1.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next

        '****** Modified On 29/Aug/2014 ****
        'Get Monthly Leave Balance for the selected month
        'FK_EQ("EXEC sp_SetLeaveBalance " & dtpFrDate.Value.Year & "," & dtpFrDate.Value.Month & ",'" & StrEmployeeID & "'", "S", "", False, False, True)

        '***** 
        sSQL = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave, CASE WHEN (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) < 0 THEN 0 Else (tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) END From tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID"
        Load_InformationtoGrid(sSQL, dgvLvHist, 5)
        clr_Grid(dgvLvHistory)

        'Dim sqlQR As String = "select tblEmpLeaveD.LeaveID,tblLeaveType.LvDesc,tblEmpLeaveD.NoLeaves,tblEmpLeaveD.TakenLeave,(tblEmpLeaveD.NoLeaves-tblEmpLeaveD.TakenLeave) as BalLeave " & _
        '    " from tblEmpLeaveD INNER JOIN tblLeaveType ON tblEmpLeaveD.LeaveID = tblLeaveType.LvID WHERE tblEmpLeaveD.EmpID = '" & StrEmployeeID & "' AND " & _
        '    " tblEmpLeaveD.CompID = '" & StrCompID & "' AND tblEmpLeaveD.cYear = " & intCurrentYear & " Order By tblEmpLeaveD.LeaveID"
        'Load_InformationtoGrid(sqlQR, dgvLvHist, 5)
        'clr_Grid(dgvLvHist)

        'Load Leave History of the selected Employee
        Dim sqlLv As String = "select tblLeaveTRD.Lvdate,tblLeaveTRD.LvType,tblLeaveType.LvDesc,tblLeaveTRD.NoLeave FROM tblLeaveTRD " & _
            " INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqiD AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID AND tblLeaveTRD.lvType =tblLeaveTRH.lvID" & _
            " INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.lvID WHERE tblLeaveTRH.EmpID = '" & StrEmployeeID & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRH.cYear = " & intCurrentYear & " Order By tblLeaveTRD.LvDate"

        Load_InformationtoGrid(sqlLv, dgvLvHistory, 4)
        clr_Grid(dgvLvHistory)

        StrLvSaveSt = "S"
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        cmdPrevious.Enabled = True

        Try
            Dim Et As String = ""
            Dim strExEmpID As String = StrEmployeeID
            StrEmployeeID = fk_RetString("SELECT Min(isnull(regid,0)) FROM tblEmployee WHERE regid > '" & strExEmpID & "' and tblemployee.empstatus<>9")
            If fk_RetString("SELECT Max(RegID) FROM tblEmployee WHERE tblemployee.empstatus<>9") = StrEmployeeID Then
                MessageBox.Show("You reached to last page", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmdNext.Enabled = False
            End If
            If StrEmployeeID <> "" Then
                Button2_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        cmdNext.Enabled = True
        Try
            Dim strExEmpID As String = StrEmployeeID
            StrEmployeeID = fk_RetString("SELECT Max(regID) FROM tblEmployee WHERE regID< '" & strExEmpID & "' and tblemployee.empstatus<>9")
            If fk_RetString("SELECT Min(RegID) FROM tblEmployee WHERE tblemployee.empstatus<>9") = StrEmployeeID Then
                MessageBox.Show("You reached to first page", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmdPrevious.Enabled = False
            End If
            If StrEmployeeID <> "" Then
                frmEmployeeInfo.pb_ShowEmployee(StrEmployeeID)
                Button2_Click(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class