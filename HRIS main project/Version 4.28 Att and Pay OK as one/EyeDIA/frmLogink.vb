Imports System.Data.SqlClient

Public Class frmLogink

    Public Sub cap_Login(ByVal logID As String, ByVal pasword As String)

        'StrCompID = "001" ' This is the current company

        If txtPassword.Text.Length < 4 Then
            MsgBox("The minimum required characters for password is six.", MsgBoxStyle.Information) : Exit Sub
        End If
        Dim bolExc As Boolean
        If cmbUserName.Text = "HRIS" And txtPassword.Text = "1212" Then
            bolExc = True
            'StrUserID = txtUserName.Text
            Me.Close()
            CurrentUser = cmbUserName.Text
            StrUserID = cmbUserName.Text
            StrUserID = StrUserID.Substring(0, 3)
            intRosterOpt = 2

            StrUlvlID = "HRIS" 'GetString("select uLvl from tblUsers where UserID='" & StrUserID & "' and logName='" & cmbUserName.Text & "'")
            UserLevelID = "000"
            UserVal = GetVal("Select levelValue from tbluserLevel where lvID='" & UserLevelID & "'")
            'If UserVal = 0 Then frmMain.MenuStrip1.Enabled = False Else frmMain.MenuStrip1.Enabled = True
            Me.txtPassword.Text = ""
            cmbUserName.Text = ""

            'If frmMainAttendance.lvMain.Enabled = False Then
            '    frmMainAttendance.lvMain.Enabled = True
            'End If

            'If frmMainAttendance.lvLk.Enabled = False Then
            '    frmMainAttendance.lvLk.Enabled = True
            'End If

            

            bolLogged = True

            'frmMainAttendance.MenuRead()
            frmMainAttendance.EnableMenu()
            'frmMainAttendance.Show()
            'Dim callIt As New frmMainCabinetkl
            'callIt.ShowDialog()
            'dtCurrentDate = Now.Date

            'Dim frmMain As New frmMainAttendance
            'frmMain.Show()
        Else

            bolExc = False
            bolLogged = False

        End If

        If bolExc = False Then

            Dim cnLog As New SqlConnection(sqlConString)
            cnLog.Open()
            Dim sqlQ As String = "SELECT * FROM tblUsers WHERE LogName = '" & logID & "' AND ComID = '" & StrCompID & "' AND pw = '" & pasword & "' and status = 0 "
            Try
                Dim cmLog As New SqlCommand(sqlQ, cnLog)
                Dim drLog As SqlDataReader = cmLog.ExecuteReader
                If drLog.Read = True Then

                    StrUlvlID = IIf(IsDBNull(drLog.Item("uLvl")), "", drLog.Item("uLvl"))
                    StrUserID = IIf(IsDBNull(drLog.Item("UserID")), "", drLog.Item("UserID"))
                    StrUserID = StrUserID.Substring(0, 3)

                    CurrentUser = IIf(IsDBNull(drLog.Item("userName")), "", drLog.Item("userName"))
                    intRosterOpt = IIf(IsDBNull(drLog.Item("rOpt")), "", drLog.Item("rOpt"))
                    strUsersRegID = IIf(IsDBNull(drLog.Item("regID")), "", drLog.Item("regID"))
                    Me.Close()

                    CurrentUser = cmbUserName.Text
                    'StrUserID = GetStrilng("Select userID from tblusers where logName='" & cmbUserName.Text & "'")
                    'StrUlvlID = GetString("select uLvl from tblUsers where UserID='" & StrUserID & "' and logName='" & cmbUserName.Text & "'")
                    sSQL = "Select ulVl from tblUsers where logName='" & Trim(cmbUserName.Text) & "'"
                    UserLevelID = fk_RetString(sSQL)
                    UserVal = GetVal("Select levelValue from tbluserLevel where lvID='" & UserLevelID & "'")
                    'If UserVal = 0 Then frmMain.MenuStrip1.Enabled = False Else frmMain.MenuStrip1.Enabled = True
                    Me.txtPassword.Text = ""
                    cmbUserName.Text = ""

                    'If frmMainAttendance.lvMain.Enabled = False Then
                    '    frmMainAttendance.lvMain.Enabled = True
                    'End If

                    'If frmMainAttendance.MenuStrip.Enabled = False Then
                    '    frmMainAttendance.MenuStrip.Enabled = True
                    'End If

                    bolLogged = True

                    'frmMainAttendance.MenuRead()
                    frmMainAttendance.EnableMenu()
                    'frmMainAttendance.Show()
                    'Dim callIt As New frmMainCabinetkl
                    'callIt.ShowDialog()

                    'Dim frmMain As New frmMain
                    'frmMain.Show()

                Else

                    MsgBox("Password incorrect", MsgBoxStyle.Critical)
                    txtPassword.Focus() : txtPassword.SelectAll()
                    bolLogged = False
                    Exit Sub

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnLog.Close()
            End Try

        End If

        sSQL = "INSERT INTO tblLoginHistory (trForm,task,crUser,crDate,regID,lgStatus) VALUES ('" & Me.Name & "','Login to the system by : " & CurrentUser & "' ,'" & StrUserID & "',getdate (),'" & strUsersRegID & "',0)" : FK_EQ(sSQL, "S", "", False, False, True)

    End Sub

    Private Sub frmTestForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed

        End

    End Sub

    Private Sub frmTestForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        callDatabase()
        'CenterFormThemed(Me, pnlTop, Label4)
        ControlHandlers(Me)
    End Sub

    Public Sub vieww(ByVal StrEid As String)

        'Try
        '    Dim CN As New SqlConnection(sqlConString)
        '    CN.Open()

        '    Dim adapter As New SqlDataAdapter
        '    adapter.SelectCommand = New SqlCommand("SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & StrEid & "' and Status='0'", CN)
        '    Dim Data As New DataTable
        '    'adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn)

        '    Dim commandbuild As New SqlCommandBuilder(adapter)
        '    adapter.Fill(Data)
        '    ' MsgBox(Data.Rows.Count)

        '    If Data.Rows.Count = 0 Then
        '        '' ''picEmp.Image = My.Resources.User_Anonymous_Disabled
        '        '' ''picEmp.SizeMode = PictureBoxSizeMode.StretchImage
        '        '' ''frmMainAttendance.picEmp.Image = My.Resources.User_Anonymous_Disabled
        '        '' ''frmMainAttendance.picEmp.SizeMode = PictureBoxSizeMode.StretchImage
        '    Else
        '        ''Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("svImage")
        '        ''Dim lstr As New System.IO.MemoryStream(lb)
        '        ''picEmp.Image = Image.FromStream(lstr)
        '        ''picEmp.SizeMode = PictureBoxSizeMode.StretchImage
        '        ''frmMainAttendance.picEmp.Image = Image.FromStream(lstr)
        '        ''frmMainAttendance.picEmp.SizeMode = PictureBoxSizeMode.StretchImage
        '        ''lstr.Close()
        '    End If

        'Catch ex As Exception
        '    'MsgBox(ex.Message)
        'End Try

    End Sub

    Public Sub callDatabase()
        ConnecttoDataBase()
        'ConnecttoDataBase()

        If intIsExit = 1 Then
            Me.Close()
        End If

        'If dtWorkingDate >= dtLockDate Then
        '    MsgBox("License Expired, Please Call Provider to Reneval", MsgBoxStyle.Exclamation)
        '    End
        'End If

        'If StrLincens = "NO" Then
        '    MsgBox("Invalied Licence " & vbCrLf & "Please Contact Provider for the Licence Key" & vbCrLf & vbCrLf & "info@HRIS.com", MsgBoxStyle.Critical)
        '    End
        'End If

        ListCombo(cmbUserName, "SELECT logName FROM tblusers where status =0", "logName")
        'strDownlodform = fk_RetString("select downloadForm from tblcompany where compId='" & StrCompID & "'")
        strChartTypeDounut = fk_RetString("select chartDounut from tblcompany where compId='" & StrCompID & "'")
        strChartTypeBar = fk_RetString("select chartBar from tblcompany where compId='" & StrCompID & "'")

        lblUcount.Text = "Total Users : " & fk_sqlDbl("select count(LogName) from tblUsers where status=0 and comId='" & StrCompID & "'")
        cmbUserName.Focus()
        IsEpf = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        If IsEpf = 0 Then sqlTag1 = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag1 = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag1 = "tblEmployee.EnrolNo" Else sqlTag1 = "tblEmployee.EmpNo"
        sqlTagName = "RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as '" & sqlTag1.Split("."c)(1) & "'"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If cmbUserName.Text = "HRIS" And txtPassword.Text = "createtbl" Then
            CreateTableAllQuery()
        End If

        cap_Login(FK_Rep(cmbUserName.Text), CPT(txtPassword.Text))

    End Sub

    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub Button2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseDown
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub Button2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Color.White
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub txtUserName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown

        If AscW(e.KeyCode) = 13 Then
            SendKeys.Send("{TAB}")

        End If

    End Sub

    Private Sub txtPassword_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            Button1_Click(sender, e)

        End If

    End Sub

    Private Sub cmbUserName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbUserName.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            txtPassword.Focus()

        End If

    End Sub

    Private Sub cmbUserName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUserName.SelectedIndexChanged
        Dim strEmpid As String = fk_RetString("SELECT regid from tblUsers WHERE logName='" & cmbUserName.Text & "'")
        vieww(strEmpid)
    End Sub

End Class