'Imports EAS_Hotel.GlassTableGDI

Public Class frmLeaveImport

    Dim intTotShLvMinPerMonth As Integer
    Dim intMaxNoShLvPerMnth As Integer

    Private Sub frmLeaveImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Leave", "Generate leave for current year") = False Then Exit Sub

        CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)

        cmdRefresh_Click(sender, e)
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.BackColor, 90)

    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.BackColor

    'End Sub

    Public Sub ListGRID(ByVal StrBack As String)

        Dim StrDesgID As String
        Dim StrDeptID As String
        Dim StrCatID As String

        StrDesgID = fk_RetString("SELECT DesgID FROM tblDesig WHERE DesgDesc = '" & cmbDesig.Text & "'")
        StrDeptID = fk_RetString("SELECT DeptID FROM tblSetDept WHERE deptName = '" & cmbDept.Text & "'")
        StrCatID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbCat.Text & "'")

        Dim sqlList As String = ""
        Dim StrYes As String
        If chkAll.Checked = True Then StrYes = "True" Else StrYes = "False"
        Select Case intRegMode
            Case 0
                sqlList = "SELECT RegID,EpfNo,DispName,'" & StrYes & "',CatID  FROM tblEmployee WHERE DeptID LIKE '" & StrDeptID & "%' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%'  AND EmpStatus <> 9  AND tblEmployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY RegID"
            Case 1
                sqlList = "SELECT RegID,EpfNo,DispName,'" & StrYes & "',CatID FROM tblEmployee WHERE DeptID LIKE '" & StrDeptID & "%' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%' AND EmpStatus <> 9  AND tblEmployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY RegID"
            Case 2
                sqlList = "SELECT RegID,EpfNo,DispName,'" & StrYes & "',CatID FROM tblEmployee WHERE DeptID LIKE '" & StrDeptID & "%' AND CatID LIKE '" & StrCatID & "%' AND DesigID LIKE '" & StrDesgID & "%' AND EmpStatus <> 9   AND tblEmployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY RegID"
        End Select

        Load_InformationtoGrid(sqlList, dgvEmployee, 5)
        clr_Grid(dgvEmployee)

        lblRowCoun.Text = "Number of Rows : " & dgvEmployee.RowCount

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        ListComboAll(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "deptName")
        ListComboAll(cmbCat, "SELECT * FROM tblSetEmpCategory WHERE status = 0 Order By CatID", "CatDesc")
        ListComboAll(cmbDesig, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "DesgDesc")

        ListGRID("xx")
        lblYear.Text = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE compID='001'")

        sSQL = "SELECT totShLvMinPerMonth,maxNoShLvPerMnth FROM tblControl"
        fk_Return_MultyString(sSQL, 2)
        intTotShLvMinPerMonth = fk_ReadGRID(0) : intMaxNoShLvPerMnth = fk_ReadGRID(1)
        txtShLvMinPerMnth.Text = intTotShLvMinPerMonth
        txtMaxShLvPrMonth.Text = intMaxNoShLvPerMnth
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        pgb.Minimum = 0
        pgb.Value = 0
        Dim bolStatus As Boolean = False
        'sSQL = "select * into tblTLvProcess FROM tblEmpLeaveD WHERE cYear  = " & intCurrentYear & ";" : FK_EQ(sSQL, "P", "", False, False, True)
        With dgvEmployee
            pgb.Maximum = .RowCount - 1
            For i As Integer = 0 To .RowCount - 1
                bolStatus = .Item(3, i).Value
                If bolStatus = True Then
                    sv_Leaves(.Item(4, i).Value, .Item(0, i).Value)
                End If
                pgb.Value = i
            Next
            MsgBox("Leave Generated Successfully", MsgBoxStyle.Information)

            'Generate short leave for current year : 2018-05-03 : Kasun
            
            sSQL = "EXEC SP_GenShortLeave " & intCurrentYear & ",1," & intTotShLvMinPerMonth & "," & intMaxNoShLvPerMnth & ""
            FK_EQ(sSQL, "P", "", False, False, True)
            'sSQL = "UPDATE tblEmpLeaveD SET tblEmpLeaveD.NoLeaves = tblTLvProcess.NoLeaves FROM tblTLvProcess,tblEmpLeaveD WHERE tblEmpLeaveD.EmpID = tblTLvProcess.EmpID AND tblEmpLeaveD.LeaveID = tblTLvProcess.LeaveID AND tblEmpLeaveD.cYear = tblTLvProcess.cYear; DROP TABLE tblTLvProcess" : FK_EQ(sSQL, "P", "", False, False, True)

            'MsgBox("Information Saved", MsgBoxStyle.Information)

        End With
    End Sub

    Public Sub sv_Leaves(ByVal empcat As String, ByVal strEmp As String)

        Dim dgvEmp As DataGridView
        dgvEmp = New DataGridView
        With dgvEmp
            .Columns.Clear()
            .Columns.Add("EmpIDs", "Employee ID")
            .Columns.Add("CatIDs", "Category ID")
            .Columns.Add("CompIDs", "CompID")

        End With
        'Load Information to the grid 
        Load_InformationtoGrid("SELECT RegID,CatID,CompID FROM tblEmployee WHERE RegID = '" & strEmp & "' Order By RegID", dgvEmp, 3)

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

        Dim StrAllEmp As String = ""
        StrAllEmp = fk_getGridCLICK(dgvEmployee, 3, 0)
        StrAllEmp = fk_SplitToSQL_in(StrAllEmp)

        Dim sqlQRY As String
        sqlQRY = "DROP TABLE T_Lv" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "SELECT * INTO T_Lv FROM tblEmpLeaveD WHERE cYear = " & intCurrentYear & " AND EmpID In ('" & StrAllEmp & "')" : FK_EQ(sqlQRY, "S", "", False, False, True)


        With dgvEmp
            For i As Integer = 0 To .RowCount - 2
                Load_InformationtoGridNoClr("select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "'," & intCurrentYear & ", " & _
                                       " tblLeaveType.lvID,dbo.fk_RetNoLeave('" & .Item(1, i).Value & "',tblLeaveType.LvID) as NoLv,dbo.fk_EmpRetNoLeave(tblLeaveType.LvID,'" & .Item(0, i).Value & "'," & intCurrentYear & "),0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLv, 7)

            Next
        End With
        'Insert all information to tblEmployee Leave File

        With dgvLv
            'Update tblEm
            sqlQRY = "DELETE FROM tblEmpLeaveD WHERE EmpID = '" & strEmp & "' AND cYear = " & intCurrentYear & ""
            For i As Integer = 0 To .RowCount - 2
                sqlQRY = sqlQRY & " INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES ('" & .Item(0, i).Value & "', " & _
                " '" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, i).Value & "', " & CDbl(.Item(4, i).Value) & "," & CDbl(.Item(5, i).Value) & ",1)"
            Next
        End With

        FK_EQ(sqlQRY, "P", "", False, False, True)

        sqlQRY = "UPDATE tblEmpLeaveD SET tblEmpLeaveD.NoLeaves = T_Lv.NoLeaves FROM T_Lv,tblEmpLeaveD WHERE T_Lv.EmpID = tblEmpLeaveD.EmpID AND T_Lv.cYear  = tblEmpLeaveD.cYear AND T_Lv.LeaveID = tblEmpLeaveD.LeaveID" : FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        ListGRID("xx")
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        ListGRID("xx")
    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.SelectedIndexChanged
        ListGRID("xx")
    End Sub

    Private Sub cmbDesig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesig.SelectedIndexChanged
        ListGRID("xx")
    End Sub
End Class