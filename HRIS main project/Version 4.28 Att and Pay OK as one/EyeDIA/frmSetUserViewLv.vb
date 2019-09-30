Imports System.Data.SqlClient

Public Class frmSetUserViewLv

    Dim StrSvStatus As String = "S"
    Dim StrLvID As String = ""
    Dim StrAllDept As String : Dim StrAllShifts As String
    Dim StrAllBranches As String = ""

    Dim StrUlvID As String = ""

    Private Sub frmUserViewLv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Set user view level", "View details of user view levels") = False Then Exit Sub
        CenterFormThemed(Me, Panel1, Label1)
        ControlHandlers(Me)
        'Dim sqlTable As String
       
        Button7_Click(sender, e)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub dgvDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetails.DoubleClick
        txtID.Text = dgvDetails.Item(0, dgvDetails.CurrentRow.Index).Value

        fk_Return_MultyString("SELECT vID,vDesc FROM tblUserViewLv WHERE vID = '" & txtID.Text & "'", 2)
        txtID.Text = fk_ReadGRID(0)
        txtDesc.Text = fk_ReadGRID(1)

        StrSvStatus = "E"
    End Sub

    Private Sub cmbUserLv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserLv.SelectedIndexChanged

        Load_InformationtoGrid("SELECT 'False',DeptID,Deptname from tblsetDept where status=0 Order By Deptname", dgvDepts, 3)
        StrLvID = fk_RetString("SELECT vID FROM tblUserViewLv WHERE vDesc = '" & cmbUserLv.Text & "'")
        If StrLvID = "" Then Exit Sub
        fk_Return_MultyString("SELECT vID,vDept FROM tblUserViewLv WHERE vID = '" & StrLvID & "'", 2)
        StrLvID = fk_ReadGRID(0)
        StrAllDept = fk_ReadGRID(1)
        If StrAllDept <> "" Then fk_SetGridCLICK(dgvDepts, 0, 1, StrAllDept)
        'fk_SetGridCLICK
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim iTab As Integer
        iTab = TabControl1.SelectedIndex
        Select Case iTab
            Case 0
                Button7_Click(sender, e)
            Case 1
                Button9_Click(sender, e)
            Case 2
                Button11_Click(sender, e)
            Case 3
                Button13_Click(sender, e)
            Case 4
                Button19_Click(sender, e)
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Load_InformationtoGrid("SELECT 'False',ShiftID,ShortCode,ShiftName from tblSetShiftH  where status=0 Order By ShortCode", dgvShiftData, 4)
        StrLvID = fk_RetString("SELECT vID FROM tblUserViewLv WHERE vDesc = '" & ComboBox1.Text & "'")
        If StrLvID = "" Then Exit Sub
        fk_Return_MultyString("SELECT vID,vShiftID FROM tblUserViewLv WHERE vID = '" & StrLvID & "'", 2)
        StrLvID = fk_ReadGRID(0)
        StrAllShifts = fk_ReadGRID(1)
        If StrAllShifts <> "" Then fk_SetGridCLICK(dgvShiftData, 0, 1, StrAllShifts)
    End Sub

    Private Sub cmbUseViewBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUseViewBranch.SelectedIndexChanged
        Load_InformationtoGrid("SELECT 'False',BrID,Brname from tblcbranchs where status=0 Order By Brname", dgvBranch, 3)
        StrLvID = fk_RetString("SELECT vID FROM tblUserViewLv WHERE vDesc = '" & cmbUseViewBranch.Text & "'")
        If StrLvID = "" Then Exit Sub
        fk_Return_MultyString("SELECT vID,vBranchID FROM tblUserViewLv WHERE vID = '" & StrLvID & "'", 2)
        StrLvID = fk_ReadGRID(0)
        StrAllBranches = fk_ReadGRID(1)
        If StrAllBranches <> "" Then fk_SetGridCLICK(dgvBranch, 0, 1, StrAllBranches)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If UP("Set user view level", "Create user view levels") = False Then Exit Sub

        If txtID.Text = "" Then MsgBox("No ID found", MsgBoxStyle.Information) : Button7_Click(sender, e) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : txtDesc.Focus() : Exit Sub

        Dim sqlQRY As String = ""
        If StrSvStatus = "S" Then txtID.Text = fk_GenSerial("SELECT NovUlv FROM tblControl", 2)
        sqlQRY = "if not exists (select * from tblUserViewLv WHERE vID = '" & txtID.Text & "') " & _
            " begin insert into tblUserViewLv values ('" & txtID.Text & "','" & txtDesc.Text & "',0,'','','') UPDate tblCOntrol Set NovUlv = NovUlv + 1 end " & _
            " else begin update tblUserViewLv set vDesc = '" & txtDesc.Text & "' where vID = '" & txtID.Text & "' end"
        Dim bolSv As Boolean = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSv = True Then Button7_Click(sender, e)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        FK_Clear(Me)
        txtID.Text = fk_GenSerial("SELECT NovULv FROM tblControl", 2)
        'Load Details to grid 
        Load_InformationtoGrid("SELECT vID,vDesc FROM tblUserViewLv Order By vDesc", dgvDetails, 2)
        clr_Grid(dgvDetails)

        StrSvStatus = "S"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If UP("Set user view level", "Assign departments to user view levels") = False Then Exit Sub
        StrAllDept = fk_getGridCLICK(dgvDepts, 0, 1)
        Dim sqlQRY As String = "UPDATE tblUserViewLv SET vDept = '" & StrAllDept & "' WHERE vID = '" & StrLvID & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        ListCombo(cmbUserLv, "SELECT * FROM tblUserViewLv Order By vID", "vDesc")
        Load_InformationtoGrid("SELECT 'False',DeptID,Deptname from tblsetDept where status=0 Order By Deptname", dgvDepts, 3)
        clr_Grid(dgvDepts)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If UP("Set user view level", "Assign shifts to user view levels") = False Then Exit Sub
        StrAllShifts = fk_getGridCLICK(dgvShiftData, 0, 1)
        Dim sqlQRY As String = "UPDATE tblUserViewLv SET vShiftID = '" & StrAllShifts & "' WHERE vID = '" & StrLvID & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        ListCombo(ComboBox1, "SELECT * FROM tblUserViewLv Order By vID", "vDesc")
        Load_InformationtoGrid("SELECT 'False',ShiftID,ShortCode,ShiftName from tblSetShiftH where status=0 Order By ShortCode", dgvShiftData, 4)
        clr_Grid(dgvShiftData)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If UP("Set user view level", "Assign branches to user view levels") = False Then Exit Sub
        StrAllBranches = fk_getGridCLICK(dgvBranch, 0, 1)
        Dim sqlQRY As String = "UPDATE tblUserViewLv SET vBranchID = '" & StrAllBranches & "' WHERE vID = '" & StrLvID & "'"
        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        ListCombo(cmbUseViewBranch, "SELECT * FROM tblUserViewLv Order By vID", "vDesc")
        Load_InformationtoGrid("select 'False',brID,brName from tblcbranchs WHERE status=0 Order By brName", dgvBranch, 3)
        'clr_Grid(dg)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If UP("Set user view level", "Set user levels") = False Then Exit Sub
        'Save Information to the table 
        'If txtuLvID.Text = "" Then
        '    MsgBox("PLease Refresh", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        If txtuLvname.Text = "" Then
            MsgBox("Please Enter Description", MsgBoxStyle.Information)
            txtuLvname.Focus()
            Exit Sub
        End If

        'check existance userlevels before allowing to remove.
        If StrSvStatus = "E" Then
            If chkUlvStatus.Checked Then
                If True = fk_CheckEx("select uLvl from tblUsers where uLvl='" & txtuLvID.Text & "'") Then
                    MsgBox("Unable to Remove when there are active users with the selected user level. Please give them different user level and try again")
                    txtuLvID.Focus()
                    Exit Sub
                End If
            End If

        End If

        If StrSvStatus = "S" Then
            txtuLvID.Text = fk_CreateSerial(3, (fk_sqlDbl("SELECT NoUlv FROM tblCompany WHERE COmpID = '" & StrCompID & "'") + 1))
        End If


        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""
        Try

            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "INSERT INTO tblUserLevel (lvId,LvDesc,Status,CompID,levelValue) VALUES ('" & txtuLvID.Text & "','" & FK_Rep(txtuLvname.Text) & "', " & chkUlvStatus.CheckState & ",'" & StrCompID & "',0)"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblCompany SET NoUlv = NoUlv + 1 WHERE CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    Button19_Click(sender, e)
                Case "E"

                    'Update information 
                    sqlQRY = "UPDATE tblUserLevel SET LvDesc = '" & FK_Rep(txtuLvname.Text) & "',Status = " & chkUlvStatus.CheckState & " WHERE LvID = '" & txtuLvID.Text & "' AND compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    Button19_Click(sender, e)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim crtl As Control
        For Each crtl In Me.TabPage5.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkUlvStatus.Checked = False

        Dim iLv As Integer = fk_sqlDbl("SELECT NoUlv FROM tblCompany WHERE COmpID = '" & StrCompID & "'") + 1
        StrUlvID = fk_CreateSerial(3, iLv)
        txtuLvID.Text = StrUlvID

        StrSvStatus = "S"

        'Show information in the grid
        Dim sqlQ As String = "SELECT LvID,levelValue,LvDesc,status,1 FROM tblUserLevel WHERE COmpID = '" & StrCompID & "' Order By levelValue desc"
        Load_InformationtoGrid(sqlQ, dgvUlv, 5)
        clr_Grid(dgvUlv)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If dgvUlv.CurrentCell.RowIndex <> 0 Then
            MoveRow(-1)
        End If
        Dim Y = dgvUlv.RowCount + 5
        For X As Integer = 0 To dgvUlv.RowCount - 1
            dgvUlv.Item(4, X).Value = Y
            Y = Y - 1
            If dgvUlv.Item(2, X).Value = "System Administrator" Then dgvUlv.Item(4, X).Value = "9999"
        Next
        Column1.Width = 100
        sSQL = ""
        For X As Integer = 0 To dgvUlv.RowCount - 1
            sSQL = sSQL & " Update tbluserlevel set LevelValue='" & dgvUlv.Item(4, X).Value & "' where lvid='" & dgvUlv.Item(0, X).Value & "' "
        Next
        sSQL = sSQL & " Update tbluserlevel set LevelValue='9999' where lvid='000'"
        FK_EQ(sSQL, "S", "", False, False, True)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If dgvUlv.CurrentCell.RowIndex <> dgvUlv.RowCount - 1 Then
            MoveRow(1)
        End If
        Dim Y = dgvUlv.RowCount + 5
        For X As Integer = 0 To dgvUlv.RowCount - 1
            dgvUlv.Item(4, X).Value = Y
            Y = Y - 1
            If dgvUlv.Item(2, X).Value = "System Administrator" Then dgvUlv.Item(4, X).Value = "9999"
        Next
        Column1.Width = 100
        sSQL = ""
        For X As Integer = 0 To dgvUlv.RowCount - 1
            sSQL = sSQL & " Update tbluserlevel set LevelValue='" & dgvUlv.Item(4, X).Value & "' where lvid='" & dgvUlv.Item(0, X).Value & "' "
        Next
        sSQL = sSQL & " Update tbluserlevel set LevelValue='9999' where lvid='000'"
        FK_EQ(sSQL, "S", "", False, False, True)
    End Sub

    Private Sub MoveRow(ByVal i As Integer)

        Try
            If (Me.dgvUlv.SelectedCells.Count > 0) Then
                Dim curr_index As Integer = Me.dgvUlv.CurrentCell.RowIndex
                Dim curr_col_index As Integer = Me.dgvUlv.CurrentCell.ColumnIndex
                Dim curr_row As DataGridViewRow = Me.dgvUlv.CurrentRow
                Me.dgvUlv.Rows.Remove(curr_row)
                Me.dgvUlv.Rows.Insert(curr_index + i, curr_row)
                Me.dgvUlv.CurrentCell = Me.dgvUlv(curr_col_index, curr_index + i)
            End If
        Catch ex As Exception
            ' do nothing if error encountered while trying to move the row up or down
        End Try

    End Sub

    Private Sub dgvUlv_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUlv.CellClick

        If dgvUlv.RowCount = 0 Then Exit Sub
        StrSvStatus = "E"
        With dgvUlv
            txtuLvID.Text = .CurrentRow.Cells(0).Value.ToString
            txtuLvname.Text = FK_UndoRep(.CurrentRow.Cells(2).Value.ToString)
            chkUlvStatus.CheckState = CInt(fk_RetString("select status from tbluserlevel where lvid='" & txtuLvID.Text & "'"))

        End With

    End Sub

    Private Sub chkAllDept_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkAllDept.MouseClick
        For k As Integer = 0 To dgvDepts.RowCount - 1
            dgvDepts.Item(0, k).Value = chkAllDept.CheckState
        Next
    End Sub

    Private Sub chkAllBranch_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkAllBranch.MouseClick
        For i As Integer = 0 To dgvBranch.RowCount - 1
            dgvBranch.Item(0, i).Value = chkAllBranch.CheckState
        Next
    End Sub

    Private Sub chkAllShift_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkAllShift.MouseClick
        For k As Integer = 0 To dgvShiftData.RowCount - 1
            dgvShiftData.Item(0, k).Value = chkAllShift.CheckState
        Next
    End Sub

End Class