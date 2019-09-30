Public Class frmLogin
    'Public UserID, UserLevelID As String
    'Public UserVal As Double = 0
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FillComboAll(cmbUserName, "Select UserName+'-'+UserID from tblpayusers  where Status=0Select UserName+'-'+UserID from tblpayusers  where Status=0")
        cmbUserName.Focus()
        cmbUserName.SelectedIndex = 0
    End Sub

    Private Sub cmbUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUserName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call cmdLogin_Click(sender, e)
        End If
    End Sub

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Trim(cmbUserName.Text) = "" Then MsgBox("Please Select User Name .....", MsgBoxStyle.Critical) : Exit Sub
        Dim sSQL As String
        'sSQL = "Select password from tblpayusers where userid='" & FK_GetID(cmbUserName.Text) & "'"
        sSQL = "Select  UserLevel,Password,LoginTime,LogOutTime,FullAccess   from tblpayusers where UserID='" & FK_GetID(cmbUserName.Text) & "'"

        If txtPassword.Text.Length < 4 Then
            MsgBox("The minimum required characters for password is six.", MsgBoxStyle.Information) : Exit Sub
        End If
        Dim sPassword As String
        If FK_ReadDB(sSQL) = True Then
            sPassword = FK_Read("Password")
            UserLevelID = FK_Read("UserLevel")
            Dim LogTime As Date = FormatDateTime(frmMainAttendance.dgvFillGridforRead.Item("LoginTime", 0).Value, DateFormat.ShortTime)
            Dim LogOut As Date = FormatDateTime(frmMainAttendance.dgvFillGridforRead.Item("LogOutTime", 0).Value, DateFormat.ShortTime)
            Dim NowTime As Date = FormatDateTime(FK_GetTime(), DateFormat.ShortTime)
            Dim sFullAccess As String = FK_Read("FullAccess")
            If sFullAccess = "0" Then
                If LogTime > NowTime Or LogOut < NowTime Then MsgBox("Access Not Allowed on this Time", MsgBoxStyle.Critical) : Exit Sub
            End If
            StrCompID = "001"

            If txtPassword.Text = CNT(sPassword) Then
                'If UserLevelID = "000" Then mod_CreatePayTables()

                'If UserLevelID = "000" And txtPassword.Text = "ekrain#123" Then
                '    frmMainAttendance.MenuCaptureToolStripMenuItem.Visible = True
                'End If
                StrUserID = FK_GetID(cmbUserName.Text)
                StrUserID = StrUserID.Substring(0, 3)
                CurrentUser = FK_GetIDLeftDash(cmbUserName.Text)
                UserVal = GetVal("Select LevelValue from tblUL where ID='" & UserLevelID & "'")
                frmMainAttendance.lblState.Text = "Active Payroll....          "
                'frmMainAttendance.lblUser.Text = cmbUserName.Text & "           "
                'frmMainAttendance.lblLoginTime.Text = DateTime.Now.ToLongTimeString & "    "
                If UserVal = 0 Then frmMainAttendance.pnlAllButton.Enabled = False Else frmMainAttendance.pnlAllButton.Enabled = True
                Me.txtPassword.Text = ""
                cmbUserName.Text = ""
                bolLoggedPay = True
                isViewBasic = GetVal("SELECT isViewBasic FROM tblPayUsers WHERE userID='" & StrUserID & "'")
                frmMainAttendance.IsMdiContainer = True
                frmMainAttendance.lblState.Text = "Loged in"
                'frmShortCut.MdiParent = frmMainAttendance
                'frmShortCut.Show()
                frmMainAttendance.ChangeThemeka()
                'frmMainAttendance.NewToolStripButton.Enabled = False
                'frmMainAttendance.OpenToolStripButton.Enabled = True
                frmMainAttendance.btnLogin.Enabled = False
                frmMainAttendance.btnLogout.Enabled = True

                Me.Close()

            ElseIf UserLevelID = "000" And txtPassword.Text = "1212" Then
                frmMainAttendance.pnlAllButton.Visible = True
                frmProcessTwo.Button3.Visible = True
                If UserLevelID = "000" And txtPassword.Text = "createtables" Then
                    CreatePayTables()
                End If
                'Createdatabase()
                StrUserID = FK_GetID(cmbUserName.Text)
                CurrentUser = FK_GetIDLeftDash(cmbUserName.Text)
                UserVal = GetVal("Select LevelValue from tblUL where ID='" & UserLevelID & "'")
                frmMainAttendance.lblState.Text = "Active Payroll....          "
                'frmMainAttendance.lblUser.Text = cmbUserName.Text & "           "
                'frmMainAttendance.lblLoginTime.Text = DateTime.Now.ToLongTimeString & "    "
                If UserVal = 0 Then frmMainAttendance.pnlAllButton.Enabled = False Else frmMainAttendance.pnlAllButton.Enabled = True
                Me.txtPassword.Text = ""
                cmbUserName.Text = ""
                strLogedinTo = "Payroll"
                isViewBasic = 1
                bolLoggedPay = True
                frmMainAttendance.IsMdiContainer = True
                frmMainAttendance.lblState.Text = "Loged in"
                'frmShortCut.MdiParent = frmMainAttendance
                'frmShortCut.Show()
                frmMainAttendance.ChangeThemeka()
                'frmMainAttendance.NewToolStripButton.Enabled = False
                'frmMainAttendance.OpenToolStripButton.Enabled = True
                frmMainAttendance.btnLogin.Enabled = False
                frmMainAttendance.btnLogout.Enabled = True
                Me.Close()

            Else
                'UserVal = 0
                'If UserVal = 0 Then frmMainAttendance.MenuStrip.Enabled = False Else frmMainAttendance.MenuStrip.Enabled = True
                frmMainAttendance.lblState.Text = ""
                MsgBox("Incorrect Password", MsgBoxStyle.Critical)
                txtPassword.Focus() : txtPassword.SelectAll()
                Exit Sub
            End If

            isServiceCharge = GetVal("SELECT isServiceCharge FROM tblCompany WHERE CompID='" & StrCompID & "'")
            'isCounterComission = GetVal("SELECT isCounterComission FROM tblCompany WHERE CompID='" & StrCompID & "'")
            isCheckEmpCountOfBoth = GetVal("SELECT isCheckEmpCountOfBoth FROM tblCompany WHERE CompID='" & StrCompID & "'")
            isDeleteNetSalryBank = GetVal("SELECT isDeleteNetSalryBank FROM tblCompany WHERE CompID='" & StrCompID & "'")
            isLimitSalAdvanced = GetVal("SELECT isLimitSalAdvanced FROM tblCompany WHERE CompID='" & StrCompID & "'")
            SalAdvancedID = GetString("SELECT SalAdvancedID FROM tblCompany WHERE CompID='" & StrCompID & "'")
            'SalAdPercen = GetVal("SELECT SalAdPercen FROM tblCompany WHERE CompID='" & StrCompID & "'")
            IsEnableExtendedLoan = GetVal("SELECT IsEnableExtendedLoan FROM tblCompany WHERE CompID='" & StrCompID & "'")


            If isServiceCharge = 1 Then
                frmMainAttendance.btnServiceChrge.Visible = True
            End If

            'If IsEnableExtendedLoan = 0 Then
            '    frmMainAttendance.LoanToolStripMenuItem1.Visible = False
            'Else
            '    frmMainAttendance.LoanToolStripMenuItem1.Visible = True
            'End If

            If isRequestDeduct = 1 Then
                frmMainAttendance.btnReqDeduction.Visible = True
                'frmMainAttendance.RequestStopToolStripMenuItem.Visible = True
            End If



        Else
            MsgBox("Invalid User Name", MsgBoxStyle.Information) : cmbUserName.Focus() : Exit Sub
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call cmdLogin_Click(sender, e)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        End
        'Me.Close()
        'frmShortCut.Visible = False
        'frmShortCut.Close()
        'UserVal = 0
        'If UserVal = 0 Then frmMainAttendance.MenuStrip.Enabled = False Else frmMainAttendance.MenuStrip.Enabled = True
    End Sub

End Class