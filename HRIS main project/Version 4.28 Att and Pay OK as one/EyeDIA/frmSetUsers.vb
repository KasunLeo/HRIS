Imports System.Data.SqlClient

Public Class frmSetUsers

    Dim StrUid As String
    Dim StrUlvl As String
    Dim StrSvStatus As String = "S"
    Dim StrUserVLv As String = ""
    Dim StrRepVLv As String = ""

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        Dim crtl As Control
        For Each crtl In Me.Panel5.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkUlvStatus.Checked = False

        'populate the user levels to combo 
        ListCombo(cmbUserLevel, "Select * FROM tblUserLevel where status = 0 AND CompID = '" & StrCompID & "' Order By LvDesc asc", "LvDesc")
        ListCombo(cmbUserVLv, "SELECT * FROM tblUserViewLv WHERE Status = 0 Order By vID", "vDesc")
        Dim intU As Integer = fk_sqlDbl("SELECT NoUsers FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        StrUid = fk_CreateSerial(3, intU)
        txtUserID.Text = StrUid
        ListCombo(cmbReporVlV, "select rDesc FROM tblUserReporViewLv WHERE status=0 Order By rID", "rDesc")

        Dim sqlQ As String = "select tblusers.userID,tblusers.userName,tblusers.logName,tbluserlevel.LvDesc,tblUserViewLv.vDesc,CASE WHEN tblUsers.rOpt=0 then 'View Permission' WHEN tblUsers.rOpt= 1 then'Confirm Permission' WHEN tblUsers.rOpt= 2 then 'Confirm & Approval Permission' end as'rOpt',tblUserReporViewLv.rDesc,tblUsers.status FROM tblusers LEFT OUTER JOIN   tbluserlevel ON tbluserlevel.lvID=tblUsers.ulvl LEFT OUTER JOIN tblUserViewLv ON tblUserViewLv.vID=tblUsers.nvlv  LEFT OUTER JOIN tblUserReporViewLv ON tblUserReporViewLv.rID=tblUsers.vrepID  where   tblUsers.ComID = '" & StrCompID & "' Order By UserID"
        Load_InformationtoGrid(sqlQ, dgvUlv, 8)
        clr_Grid(dgvUlv)

        Me.pnlBranchLevel.Controls.Clear()
        Dim frmReg As New frmSetUserViewLv
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal
        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlBranchLevel.Controls.Add(frmReg)
        frmReg.Show()


        Me.pnlReportLevel.Controls.Clear()
        Dim frmReg2 As New frmSetReportViewLv
        frmReg2.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg2.WindowState = FormWindowState.Normal
        frmReg2.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlReportLevel.Controls.Add(frmReg2)
        frmReg2.Show()

        txtUserName.Focus()
        StrSvStatus = "S"
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'If txtUserID.Text = "" Then
        '    MsgBox("No User ID", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        If txtPw.Text.Length < 4 Then
            MsgBox("The minimum required characters for password is six.", MsgBoxStyle.Information) : Exit Sub
        End If

        If txtUserName.Text = "" Then
            MsgBox("Enter User Name", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtLogName.Text = "" Then
            MsgBox("Enter Login Name", MsgBoxStyle.Information)
            Exit Sub
        End If


        If cmbUserLevel.Text = "NONE" Then
            MsgBox("Please Select the User Level", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtPw.Text.Trim = "" Then
            MsgBox("Please Enter The Password.")
            txtPw.Focus()
            Exit Sub
        End If

        If txtPw.Text.Trim <> txtRePw.Text.Trim Then
            MsgBox("Passwords do not match. Please Re-enter the passwords")
            txtPw.Focus()
            Exit Sub
        End If

        If cmbRosterOpt.Text = "NONE" Then
            MsgBox("Please select roster edit level", MsgBoxStyle.Information)
            Exit Sub
        End If

        If cmbUserVLv.Text = "" Then
            StrUserVLv = "01"
            'MsgBox("Please Select the User Level", MsgBoxStyle.Information)
            'Exit Sub
        End If

        If cmbReporVlV.Text = "NONE" Then
            MsgBox("Please select report view level", MsgBoxStyle.Information) : cmbReporVlV.Focus()
            Exit Sub
        End If

        intRosterOpt = cmbRosterOpt.SelectedIndex
        'check whether there is at least one active user for the system before removing.
        If StrSvStatus = "E" Then
            If chkUlvStatus.Checked Then
                If 1 = CInt(fk_RetString("select count (*) from tblUsers where status=0 ")) Then
                    MsgBox("There should be at least one active user for the system. Please set one as an Active User and try again.")
                    txtUserID.Focus()
                    Exit Sub
                End If
            End If
        End If

        If StrSvStatus = "S" Then
            Dim intU As Integer = fk_sqlDbl("SELECT NoUsers FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
            StrUid = fk_CreateSerial(3, intU)
            txtUserID.Text = StrUid
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "INSERT INTO tblUsers (userID,userName,logName,comID,uLvl,Pw,nvlv,Status,rOpt,regID,vRepID) VALUES " & _
                    " ('" & txtUserID.Text & "','" & FK_Rep(txtUserName.Text) & "','" & FK_Rep(txtLogName.Text) & "','" & StrCompID & "','" & StrUlvl & "', '" & CPT(txtPw.Text) & "','" & StrUserVLv & "'," & chkUlvStatus.CheckState & "," & intRosterOpt & ",'" & txtCod.Text & "','" & StrRepVLv & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblCOmpany SET NoUsers = NoUsers + 1 WHERE CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    MsgBox("New User Added", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)
                Case "E"

                    sqlQRY = "UPDATE tblusers set userName = '" & FK_Rep(txtUserName.Text) & "',logName = '" & FK_Rep(txtLogName.Text) & "' ,rOpt = " & intRosterOpt & ",uLvl = '" & StrUlvl & "', Pw = '" & CPT(txtPw.Text) & "',nvlv='" & StrUserVLv & "', Status = " & chkUlvStatus.CheckState & ",regID='" & txtCod.Text & "',vRepID='" & StrRepVLv & "' WHERE userID = '" & txtUserID.Text & "' AND comID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)

        'tblUsers table has already been created at the frmTestForm.

        cmdRefresh_Click(sender, e)
        If intIsUserViewLevel = 1 Then
            cmbUserVLv.Visible = True
            Label8.Visible = True
        End If
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.GroupBox1.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.GroupBox1.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.GroupBox1.BackColor, 90)

    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.GroupBox1.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.GroupBox1.BackColor

    'End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub dgvUlv_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUlv.CellDoubleClick


        If dgvUlv.RowCount = 0 Then Exit Sub
        'Select Information from the user ID
        Dim StrUID As String = dgvUlv.Item(0, dgvUlv.CurrentRow.Index).Value

        Dim cnShw As New SqlConnection(sqlConString)
        Dim sqlShw As String = "select tblusers.userID,tblusers.userName,tblusers.logName,tblusers.pw,tblusers.comID,tbluserlevel.LvDesc AS 'uLvl',tblUsers.status,tblUserViewLv.vDesc AS 'nvLv',tblUsers.rOpt,tblUserReporViewLv.rDesc FROM tblusers LEFT OUTER JOIN   tbluserlevel ON tbluserlevel.lvID=tblUsers.ulvl LEFT OUTER JOIN tblUserViewLv ON tblUserViewLv.vID=tblUsers.nvlv  LEFT OUTER JOIN tblUserReporViewLv ON tblUserReporViewLv.rID=tblUsers.vrepID  where   tblUsers.ComID = '001' AND tblUsers.userID = '" & StrUID & "' Order By UserID"
        cnShw.Open()
        Try
            Dim cmShw As New SqlCommand(sqlShw, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtUserID.Text = IIf(IsDBNull(drShw.Item("userID")), "", drShw.Item("userID"))
                txtUserName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("userName")), "", drShw.Item("userName")))
                txtLogName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("logName")), "", drShw.Item("logName")))
                'Dim strUlv As String
                cmbUserLevel.Text = IIf(IsDBNull(drShw.Item("uLvl")), "", drShw.Item("uLvl"))
                intRosterOpt = IIf(IsDBNull(drShw.Item("rOpt")), 0, drShw.Item("rOpt"))
                'Dim struvlv As String 
                cmbUserVLv.Text = IIf(IsDBNull(drShw.Item("nVLV")), "", drShw.Item("nVLV"))
                txtPw.Text = CNT(IIf(IsDBNull(drShw.Item("pw")), "", drShw.Item("pw")))
                txtRePw.Text = CNT(IIf(IsDBNull(drShw.Item("pw")), "", drShw.Item("pw")))
                Dim iSt As Integer = IIf(IsDBNull(drShw.Item("Status")), 0, drShw.Item("Status"))
                cmbRosterOpt.SelectedIndex = intRosterOpt
                chkUlvStatus.CheckState = iSt
                cmbReporVlV.Text = IIf(IsDBNull(drShw.Item("rDesc")), "", drShw.Item("rDesc"))
                StrSvStatus = "E"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtLogName.Focus()
        End If
    End Sub
    Private Sub txtlogName_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLogName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbUserLevel.Focus()
        End If
    End Sub
    Private Sub cmbUserLevel_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUserLevel.KeyPress, cmbUserVLv.KeyPress, cmbRosterOpt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPw.Focus()
        End If
    End Sub
    Private Sub txtPw_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPw.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtRePw.Focus()
        End If
    End Sub
    Private Sub txtRePw_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRePw.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub cmbUserVLv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserVLv.SelectedIndexChanged, cmbRosterOpt.SelectedIndexChanged
        StrUserVLv = fk_RetString("SELECT vID FROM tblUserViewLv WHERE vDesc = '" & cmbUserVLv.Text & "'")
    End Sub

    Private Sub cmbUserLevel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserLevel.SelectedIndexChanged
        StrUlvl = fk_RetString("SELECT lvID FROM tblUserLevel WHERE lvDesc = '" & cmbUserLevel.Text & "'")
    End Sub

    Private Sub cmdBrsC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsC.Click
        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
       "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
       "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then


                'pb_ShowEmployee(StrEmployeeID)

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try

        'View Employee information using the EMployee
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno " & _
        " FROM tblEmployee LEFT OUTER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCod.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                txtUserName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                'txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub cmbReporVlV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReporVlV.SelectedIndexChanged
        StrRepVLv = fk_RetString("select rID FROM tblUserReporViewLv WHERE rDesc='" & cmbReporVlV.Text & "'")
    End Sub

End Class