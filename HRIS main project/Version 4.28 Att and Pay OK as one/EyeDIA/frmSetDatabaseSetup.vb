Public Class frmSetDatabaseSetup

    Private Sub frmDatabaseSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        On Error Resume Next
        CenterFormThemed(Me, pnlTop, Label8)
        ControlHandlers(Me)
        frmSplash.Visible = False
        txtSqlServer.Text = ReadKey("HRTime\SQLServer")
        txtSqlDatabase.Text = ReadKey("HRTime\SQLDatabase")
        txtUserName.Text = ReadKey("HRTime\UserName")
        txtPassword.Text = ReadKey("HRTime\Password")

        txtSqlServer.Text = CNT(txtSqlServer.Text)
        txtSqlDatabase.Text = CNT(txtSqlDatabase.Text)
        txtUserName.Text = CNT(txtUserName.Text)
        txtPassword.Text = CNT(txtPassword.Text)
        txtSqlServer.Focus()
        lblCompany.Text = "Copyright by " & strDealerName & "                         "
        Timer1.Start()

    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Public Sub CreateKey(ByVal Folder As String, ByVal Value As String)
        Dim str1 As String
        str1 = "HKCU\Software\HRIS\" & Folder
        'Folder = "HCKU\Software\HRIS"
        'name1=readkey("Folder")
        'createkey "Folder",ext1
        Dim B As Object
        On Error Resume Next
        B = CreateObject("wscript.shell")
        B.RegWrite(str1, Value)
    End Sub

    Public Sub CreateIntegerKey(ByVal Folder As String, ByVal Value As Integer)
        Dim B As Object
        On Error Resume Next
        B = CreateObject("wscript.shell")
        B.RegWrite(Folder, Value, "REG_DWORD")
    End Sub

    Public Function ReadKey(ByVal Value As String) As String
        Dim str1 As String
        str1 = "HKCU\Software\HRIS\" & Value
        Dim B As Object
        Dim R As Object
        On Error Resume Next
        B = CreateObject("wscript.shell")
        R = B.RegRead(str1)
        ReadKey = R
    End Function

    Private Sub cmdSave_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        '  If UP("Database Settings", "Change Database Settings") = False Then Exit Sub
        If txtAdminkey.Text = "hrishris" Then
            CreateKey("HRTime\SQLServer", CPT(txtSqlServer.Text))
            CreateKey("HRTime\SQLDatabase", CPT(txtSqlDatabase.Text))
            CreateKey("HRTime\UserName", CPT(txtUserName.Text))
            CreateKey("HRTime\Password", CPT(txtPassword.Text))
            MsgBox("Data Saved Suceessfully", MsgBoxStyle.Information)
            End
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            sqlConString = "Password= " & txtPassword.Text & ";Persist Security Info=True;User ID=" & txtUserName.Text & ";Initial Catalog=" & txtSqlDatabase.Text & ";Data Source= " & txtSqlServer.Text & ";TimeOut=12000"
            If dbSqlCon.State = ConnectionState.Open Then
                dbSqlCon.Close()
            End If
            dbSqlCon.ConnectionString = sqlConString
            dbSqlCon.Open()
            MsgBox("Connected Successfully", MsgBoxStyle.Information)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox("Unable to Establish the Connection", MsgBoxStyle.Information)
            Me.Cursor = Cursors.Default
        End Try
        If dbSqlCon.State = ConnectionState.Open Then
            dbSqlCon.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub txtAdminkey_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdminkey.KeyPress
        If AscW(e.KeyChar) = 13 Then
            cmdSave_Click_1(sender, e)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If AscW(e.KeyChar) = 13 Then
            Button1_Click(sender, e)
        End If
    End Sub
End Class