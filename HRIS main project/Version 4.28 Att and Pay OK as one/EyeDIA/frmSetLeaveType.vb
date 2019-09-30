Imports System.Data.SqlClient
'Imports EAS_Hotel.GlassTableGDI

Public Class frmSetLeaveType

    Dim StrSvStatus As String = "S"
    Dim StrlvMode As String = ""
    Dim intLvLimit As Integer = 0
    Dim intOthLvAllw As Integer = 0
    Dim intChkLateEarly As Integer = 0
    Dim intAllowFutureLv As Integer = 0
    Dim intUpNextYear As Integer = 0

    Private Sub frmSetLeaveType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)

        'Create table to hold leave apply method
        Dim sqlTable As String = ""
        sqlTable = "CREATE TABLE tblLvAplMeth (mID nvarchar (2),MDesc Nvarchar (50),mCount Numeric (18,0))"
        sqlTable = sqlTable & " INSERT INTO tblLvAplMeth VALUES ('01','Monthly',12)"
        sqlTable = sqlTable & " INSERT INTO tblLvAplMeth VALUES ('02','Yearly',1)"
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblLeaveType ADD effDay Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType Add LvMode Nvarchar (2)"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType Add ChkLimit Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType ADD AllowOthLv Numeric (18,0) NOT NULL default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType ADD AllowFutureLv Numeric (18,0) NOT NULL default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType Add ChkLateEarly Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType ADD LateEarlyMin Numeric (18,0) NOT NULL default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "alter table tblLeaveType add shortCode nvarchar (4) not null default ''"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblLeaveType ADD UpNextYear Numeric (18,0) NOT NUll Default 0 " : FK_EQ(sqlTable, "S", "", False, False, False)

        Button3_Click(sender, e)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Open Employee to the grid
        Dim dgvEmp As DataGridView
        dgvEmp = New DataGridView
        With dgvEmp
            .Columns.Clear()
            .Columns.Add("EmpIDs", "Employee ID")
            .Columns.Add("CatIDs", "Category ID")
            .Columns.Add("CompIDs", "CompID")
        End With

        'Load Information to the grid 
        Load_InformationtoGrid("SELECT RegID,CatID,CompID FROM tblEmployee Order By RegID", dgvEmp, 3)

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
                Load_InformationtoGridNoClr("select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "','2012', " & _
                                       " tblLeaveType.lvID,dbo.fk_RetNoLeave('" & .Item(1, i).Value & "',tblLeaveType.LvID) as NoLv,dbo.fk_EmpRetNoLeave(tblLeaveType.LvID,'" & .Item(0, i).Value & "'," & intCurrentYear & "),0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLv, 7)
            Next
        End With

        'Insert all information to tblEmployee Leave File
        Dim sqlQRY As String
        With dgvLv
            'Update tblEm
            sqlQRY = "DELETE FROM tblEmpLeaveD"
            For i As Integer = 0 To .RowCount - 2
                sqlQRY = sqlQRY & " INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES ('" & .Item(0, i).Value & "', " & _
                " '" & .Item(1, i).Value & "'," & CDbl(.Item(2, i).Value) & ",'" & .Item(3, i).Value & "', " & CDbl(.Item(4, i).Value) & "," & CDbl(.Item(5, i).Value) & ",1)"
            Next
        End With
        FK_EQ(sqlQRY, "P", "", False, True, True)

    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick

        StrLeavSearchID = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        Dim sqlQRY As String = "select tblLeaveType.LvID,tblLeaveType.Lvdesc,tblLeaveType.ChkLimit,tblLeaveType.EffDay,tblLeaveType.AllowOthLv,tblLvAplMeth.mID,tblLvAplMeth.mDesc,tblLvAplMeth.mCount,tblLeaveType.AllowFutureLv,tblLeaveType.ChkLateEarly,tblLeaveType.LateEarlyMin,tblLeaveType.Status,tblLeaveType.shortCode,tblLeaveType.UpNextYear FROM tblLeaveType LEFT OUTER JOIN tblLvAplMeth ON tblLvAplMeth.mID = tblLeaveType.LvMode WHERE tblLeaveType.LvID = '" & StrLeavSearchID & "'"
        Dim cnLv As New SqlConnection(sqlConString)
        Try
            cnLv.Open()
            Dim cmLv As New SqlCommand(sqlQRY, cnLv)
            Dim drLv As SqlDataReader = cmLv.ExecuteReader
            If drLv.Read = True Then
                txtCode.Text = IIf(IsDBNull(drLv.Item("LvID")), "", drLv.Item("LvID"))
                txtDesc.Text = IIf(IsDBNull(drLv.Item("Lvdesc")), "", drLv.Item("Lvdesc"))
                StrlvMode = IIf(IsDBNull(drLv.Item("mID")), "", drLv.Item("mID"))
                cmbLvMode.Text = IIf(IsDBNull(drLv.Item("mDesc")), "", drLv.Item("mDesc"))
                cmbEffNos.Text = IIf(IsDBNull(drLv.Item("EffDay")), "", drLv.Item("EffDay"))
                cmbChkLimit.SelectedIndex = IIf(IsDBNull(drLv.Item("ChkLimit")), 0, drLv.Item("ChkLimit"))
                intOthLvAllw = IIf(IsDBNull(drLv.Item("AllowOthLv")), 0, drLv.Item("AllowOthLv"))
                cmbOthLv.SelectedIndex = intOthLvAllw
                intAllowFutureLv = IIf(IsDBNull(drLv.Item("AllowFutureLv")), 0, drLv.Item("AllowFutureLv"))
                cmbAlowFutureLv.SelectedIndex = intAllowFutureLv
                intChkLateEarly = IIf(IsDBNull(drLv.Item("ChkLateEarly")), 0, drLv.Item("ChkLateEarly"))
                cmbChkLateEarly.SelectedIndex = intChkLateEarly
                txtMaxLate.Text = IIf(IsDBNull(drLv.Item("LateEarlyMin")), "", drLv.Item("LateEarlyMin"))
                txtShortCod.Text = IIf(IsDBNull(drLv.Item("shortCode")), "", drLv.Item("shortCode"))
                chkStatus.CheckState = IIf(IsDBNull(drLv.Item("Status")), "", drLv.Item("Status"))
                intUpNextYear = IIf(IsDBNull(drLv.Item("UpNextYear")), 0, drLv.Item("UpNextYear"))
                cmbUpdateNextYear.SelectedIndex = intUpNextYear
                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnLv.Close()
        End Try

    End Sub

    Private Sub cmbLvMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLvMode.SelectedIndexChanged

        StrlvMode = fk_RetString("SELECT mID FROM tblLvAplMeth WHERE mDesc = '" & cmbLvMode.Text & "'")

    End Sub

    Private Sub cmbOthLv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOthLv.SelectedIndexChanged

        intOthLvAllw = cmbOthLv.SelectedIndex

    End Sub

    Private Sub cmbEffNos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEffNos.SelectedIndexChanged

    End Sub

    Private Sub cmbChkLimit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChkLimit.SelectedIndexChanged

        intLvLimit = cmbChkLimit.SelectedIndex

    End Sub

    Private Sub cmbAlowFutureLv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlowFutureLv.SelectedIndexChanged, cmbUpdateNextYear.SelectedIndexChanged

        intAllowFutureLv = cmbAlowFutureLv.SelectedIndex

    End Sub

    Private Sub cmbChkLateEarly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbChkLateEarly.SelectedIndexChanged

        intChkLateEarly = cmbChkLateEarly.SelectedIndex

        If intChkLateEarly = 1 Then

            txtMaxLate.Enabled = True

        Else

            txtMaxLate.Enabled = False
            txtMaxLate.Text = "0"

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If txtCode.Text = "" Then MsgBox("Press Refresh to Get Leave Type ID", MsgBoxStyle.Information) : Exit Sub
        If txtDesc.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : Exit Sub
        If txtShortCod.Text = "" Then MsgBox("Enter Short Code", MsgBoxStyle.Information) : txtShortCod.Focus() : Exit Sub
        StrlvMode = fk_RetString("SELECT mID FROM tblLvAplMeth WHERE mDesc = '" & cmbLvMode.Text & "'") : If StrlvMode = "" Then MsgBox("Select Leave mode", MsgBoxStyle.Information) : Exit Sub
        Dim sqlQRY As String = ""
        Select Case StrSvStatus
            Case "S"
                Dim iD As Integer = fk_sqlDbl("SELECT NoLeaveType FROM tblControl") + 1
                Dim StrD As String = fk_CreateSerial(3, iD)
                txtCode.Text = StrD

                sqlQRY = "INSERT INTO tblLeaveType (LvID,LvDesc,CompID,Status,effDay,LvMode,ChkLimit,AllowOthLv,AllowFutureLv,ChkLateEarly,LateEarlyMin,shortCode,UpNextYear) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "','" & StrCompID & "'," & chkStatus.CheckState & "," & CInt(cmbEffNos.Text) & ",'" & StrlvMode & "'," & intLvLimit & "," & intOthLvAllw & "," & intAllowFutureLv & "," & intChkLateEarly & ",'" & Val(txtMaxLate.Text) & "','" & Trim(txtShortCod.Text) & "', " & intUpNextYear & ")"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoLeaveType = NoLeavetype + 1"
            Case "E"
                sqlQRY = "UPDATE tblLeaveType SET LvDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & ",EffDay = " & CInt(cmbEffNos.Text) & ",LvMode = '" & StrlvMode & "',ChkLimit = " & intLvLimit & ",AllowOthLv = " & intOthLvAllw & ",AllowFutureLv= " & intAllowFutureLv & ",ChkLateEarly=" & intChkLateEarly & ",LateEarlyMin='" & Val(txtMaxLate.Text) & "',shortCode='" & Trim(txtShortCod.Text) & "', UpNextYear = " & intUpNextYear & " WHERE LvID = '" & txtCode.Text & "'"
        End Select

        Dim bolSave As Boolean = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True) : If bolSave = True Then cmdRefresh_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FK_Clear(Me)
        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoLeaveType FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        'Load Information 
        ListCombo(cmbLvMode, "SELECT * FROM tblLvAplMeth Order By mID", "mDesc")
        With cmbEffNos
            .Items.Clear()
            .Items.Add("0")
            .Items.Add("1")
            .SelectedIndex = 0
        End With

        With cmbChkLimit
            .Items.Clear()
            .Items.Add("NO")
            .Items.Add("YES")
            .SelectedIndex = 0
        End With

        With cmbOthLv
            .Items.Clear()
            .Items.Add("NO")
            .Items.Add("YES")
            .SelectedIndex = 0
        End With

        With cmbAlowFutureLv
            .Items.Clear()
            .Items.Add("NO")
            .Items.Add("YES")
            .SelectedIndex = 0
        End With

        With cmbChkLateEarly
            .Items.Clear()
            .Items.Add("NO")
            .Items.Add("YES")
            .SelectedIndex = 0
        End With

        With cmbUpdateNextYear
            .Items.Clear()
            .Items.Add("NO")
            .Items.Add("YES")
            .SelectedIndex = 0
        End With
        txtMaxLate.Text = "0"
        txtMaxLate.Enabled = False

        Load_InformationtoGrid("SELECT LvID,shortCode,LvDesc FROM tblLeaveType Order By LvID", dgvData, 3)
        chkStatus.Checked = False

        'clr_Grid(dgvData)
    End Sub
End Class