Imports System.Data.SqlClient

Public Class frmSetDesignation

    Dim StrSvStatus As String = "S"

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub frmSetDesignation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)

        '===============Copied Start
        '' '' ''        Dim strQry As String = "alter table tblControl add NoDesgs numeric (18,0) not null default 0"
        '' '' ''        fk_AddFieldToTbl(strQry, "tblControl", "NoDesgs")

        '' '' ''        strQry = " create table tblDesig(" & _
        '' '' ''" DesgID nvarchar (3) null," & _
        '' '' ''" desgDesc nvarchar (30) null," & _
        '' '' ''" compID nvarchar (3) null," & _
        '' '' ''" Status numeric (18,0)null" & _
        '' '' ''" )"
        '' '' ''        fk_CreateTableR(strQry, "tblDesig")
        '=================Copied over



        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkStatus.Checked = False

        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoDesgs FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD
        FillCombo(cmbOccupGroup, "Select GroupName+'='+ID from tblOccupationalGroup  order by GroupName", "GroupName")
        cmbLevel.SelectedIndex = 0
        StrSvStatus = "S"

        Load_InformationtoGrid("select tbldesig.desgID,tbldesig.desgDesc,case when tbldesig.mLevel='01' then 'Management Level=01' when tbldesig.mLevel='02' then 'Middle Level=02' else 'Bottom Level=03' End as 'mLevel',tblOccupationalGroup.groupName+'='+ tblOccupationalGroup.id from tbldesig,tblOccupationalGroup where tblDesig.ocgrpID=tblOccupationalGroup.id  Order By DesgID", dgvData, 4)
        clr_Grid(dgvData)

    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown

        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            Exit Sub
        End If

        If cmbOccupGroup.Text = "GroupName" Then
            MsgBox("Select Occupational Group", MsgBoxStyle.Information)
            cmbOccupGroup.Focus()
            Exit Sub
        End If

        If cmbLevel.Text = "None" Then
            MsgBox("Select Management Level", MsgBoxStyle.Information)
            cmbLevel.Focus()
            Exit Sub
        End If

        Dim bolAct As Boolean = False

        bolAct = fk_CheckEx("SELECT * FROM tblEmployee WHERE DesigID = '" & txtCode.Text & "' AND empStatus <> 9")

        Select Case StrSvStatus
            Case "S"
                'Can't process save with deleted status
                If chkStatus.CheckState = CheckState.Checked Then
                    MsgBox("Can't Save with Deleted Status", MsgBoxStyle.Information)
                    Exit Sub

                End If
                txtCode.Text = fk_CreateSerial(3, (fk_sqlDbl("SELECT NoDesgs FROM tblControl") + 1))

            Case "E"
                If bolAct = True Then
                    '    MsgBox("Can't Process Delete when the Active Employee Informations are existing", MsgBoxStyle.Information)
                    '    Exit Sub
                    'Else
                    If MsgBox("Do you want to modify Information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
        End Select
        Dim retMess As String

        If StrSvStatus = "E" Then
            sSQL = "UPDATE tbldesig SET desgDesc='" & Trim(txtDesc.Text) & "',compID='" & StrCompID & "',status=" & chkStatus.CheckState & ",ocgrpID='" & FK_GetIDR(cmbOccupGroup.Text) & "',mLevel='" & FK_GetIDR(cmbLevel.Text) & "' WHERE desgID='" & Trim(txtCode.Text) & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Update Designation info of Desig ID : " & txtCode.Text & " and Desig Name : " & txtDesc.Text & " and  OC Grup " & FK_Rep(cmbOccupGroup.Text) & " and  Level " & FK_Rep(cmbLevel.Text) & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "E", "", True, True, True)
        Else
            sSQL = "INSERT INTO tbldesig (desgID,desgDesc,compID,status,ocgrpID,Mlevel) VALUES ('" & Trim(txtCode.Text) & "', '" & Trim(txtDesc.Text) & "', '" & StrCompID & "'," & chkStatus.CheckState & ",'" & FK_GetIDR(cmbOccupGroup.Text) & "','" & FK_GetIDR(cmbLevel.Text) & "'); UPDATE tblControl SET NoDesgs=NoDesgs+1; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Insert Designation info of Desig ID : " & txtCode.Text & " and Desig Name : " & txtDesc.Text & " and  OC Grup : " & cmbOccupGroup.Text & " and  Level " & FK_Rep(cmbLevel.Text) & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "S", "", True, True, True)
        End If

        'retMess = Save_Codes(StrSvStatus, txtCode.Text, txtDesc.Text, chkStatus.CheckState, "NoDesgs", "tblDesig", "DesgID", "desgDesc")

        'MsgBox(retMess, MsgBoxStyle.Information)
        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        If dgvData.RowCount = 0 Then Exit Sub
        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value

        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "select tbldesig.desgID,tbldesig.desgDesc,tbldesig.compID,tbldesig.status,tbldesig.ocgrpID,case when tbldesig.mLevel='01' then 'Management Level=01' when tbldesig.mLevel='02' then 'Middle Level=02' else 'Bottom Level=03' End as 'mLevel',tblOccupationalGroup.groupName+'='+ tblOccupationalGroup.id from tbldesig,tblOccupationalGroup where tblDesig.ocgrpID=tblOccupationalGroup.id  and tblDesig.DesgID = '" & txtCode.Text & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item(0)), "", drShw.Item(0))
                txtDesc.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1)))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item(3)), 0, drShw.Item(3))
                cmbOccupGroup.Text = IIf(IsDBNull(drShw.Item(6)), 0, drShw.Item(6))
                cmbLevel.Text = IIf(IsDBNull(drShw.Item(5)), 0, drShw.Item(5))
                'cmbOccupGroup.Text = fk_RetString("Select GroupName+'='+ID from tblOccupationalGroup WHERE ID='" & cmbOccupGroup.Text & "'")

                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UP("Company Profile", "Add designation") = False Then Exit Sub

        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            Exit Sub
        End If

        If cmbOccupGroup.Text = "GroupName" Then
            MsgBox("Select Occupational Group", MsgBoxStyle.Information)
            cmbOccupGroup.Focus()
            Exit Sub
        End If

        If cmbLevel.Text = "Level" Then
            MsgBox("Select Occupational Group", MsgBoxStyle.Information)
            cmbLevel.Focus()
            Exit Sub
        End If

        Dim bolAct As Boolean = False

        bolAct = fk_CheckEx("SELECT * FROM tblEmployee WHERE DesigID = '" & txtCode.Text & "' AND empStatus <> 9")

        Select Case StrSvStatus
            Case "S"
                'Can't process save with deleted status
                If chkStatus.CheckState = CheckState.Checked Then
                    MsgBox("Can't Save with Deleted Status", MsgBoxStyle.Information)
                    Exit Sub

                End If
                txtCode.Text = fk_CreateSerial(3, (fk_sqlDbl("SELECT NoDesgs FROM tblControl") + 1))

            Case "E"
                If bolAct = True Then
                    '    MsgBox("Can't Process Delete when the Active Employee Informations are existing", MsgBoxStyle.Information)
                    '    Exit Sub
                    'Else
                    If MsgBox("Do you want to modify Information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
        End Select
        Dim retMess As String

        If StrSvStatus = "E" Then
            sSQL = "UPDATE tbldesig SET desgDesc='" & Trim(txtDesc.Text) & "',compID='" & StrCompID & "',status=" & chkStatus.CheckState & ",ocgrpID='" & FK_GetIDR(cmbOccupGroup.Text) & "',mLevel='" & FK_GetIDR(cmbLevel.Text) & "' WHERE desgID='" & Trim(txtCode.Text) & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Update Designation info of Desig ID : " & txtCode.Text & " and Desig Name : " & txtDesc.Text & " and  OC Grup " & FK_Rep(cmbOccupGroup.Text) & " and  Level " & FK_Rep(cmbLevel.Text) & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "E", "", True, True, True)
        Else
            sSQL = "INSERT INTO tbldesig (desgID,desgDesc,compID,status,ocgrpID,Mlevel) VALUES ('" & Trim(txtCode.Text) & "', '" & Trim(txtDesc.Text) & "', '" & StrCompID & "'," & chkStatus.CheckState & ",'" & FK_GetIDR(cmbOccupGroup.Text) & "','" & FK_GetIDR(cmbLevel.Text) & "'); UPDATE tblControl SET NoDesgs=NoDesgs+1; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Insert Designation info of Desig ID : " & txtCode.Text & " and Desig Name : " & txtDesc.Text & " and  OC Grup : " & cmbOccupGroup.Text & " and  Level " & FK_Rep(cmbLevel.Text) & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "S", "", True, True, True)
        End If

        'retMess = Save_Codes(StrSvStatus, txtCode.Text, txtDesc.Text, chkStatus.CheckState, "NoDesgs", "tblDesig", "DesgID", "desgDesc")

        'MsgBox(retMess, MsgBoxStyle.Information)
        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkStatus.Checked = False

        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoDesgs FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD
        FillCombo(cmbOccupGroup, "Select GroupName+'='+ID from tblOccupationalGroup  order by GroupName", "GroupName")
        cmbLevel.SelectedIndex = 0
        StrSvStatus = "S"

        Load_InformationtoGrid("select tbldesig.desgID,tbldesig.desgDesc,tbldesig.ocgrpID,case when tbldesig.mLevel='01' then 'Management Level=01' when tbldesig.mLevel='02' then 'Middle Level=02' else 'Bottom Level=03' End as 'mLevel',tblOccupationalGroup.groupName+'='+ tblOccupationalGroup.id from tbldesig,tblOccupationalGroup where tblDesig.ocgrpID=tblOccupationalGroup.id  Order By DesgID", dgvData, 2)
        clr_Grid(dgvData)
    End Sub
End Class