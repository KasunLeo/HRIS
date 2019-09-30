Imports System.Data.SqlClient

Public Class frmBackupDB

    Private Sub frmBackupDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Timer1.Start()

        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        txtUser.Text = CurrentUser
        txtK.Text = Format(Now.Date, "dd-MM-yyyy") & "     "
        lblCompany.Text = "Copyright by " & strDealerName & "                         "
        Open_Comp()

    End Sub

    Public Sub Open_Comp()

        Dim cnOpen As New SqlConnection(sqlConString)
        cnOpen.Open()
        Dim sqlQRY As String = "SELECT * FROM tblCompany WHERE compID = '" & StrCompID & "'"
        Try
            Dim cmOpen As New SqlCommand(sqlQRY, cnOpen)
            Dim drOpen As SqlDataReader = cmOpen.ExecuteReader
            If drOpen.Read = True Then
                txtCompName.Text = IIf(IsDBNull(drOpen.Item("cName")), "", drOpen.Item("cName"))
                txtBkpPath.Text = IIf(IsDBNull(drOpen.Item("Backpath")), "", drOpen.Item("BackPath"))

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpen.Close()
        End Try

    End Sub

    Private Sub cmdBrsPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsPath.Click

        fbdPath.ShowDialog()
        Dim strPath As String
        strPath = fbdPath.SelectedPath
        txtBkpPath.Text = strPath

    End Sub

    Private Sub cmdBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackup.Click
    

    End Sub

    Public Sub Backup_DB()

        Dim StrFileName As String
        Dim StrBackupPath As String
        Dim mins As Integer = Minute(Now.Date)
        'Dim Hrs As Integer = Hour(Now.Date)
        'Dim Secs As Integer = Second(Now.Date)
        'Dim StrTim As String = Hrs.ToString & "_" & mins.ToString & "_" & Secs.ToString
        Dim strCompName As String = fk_RetString("select cName from tblCompany where compID='" & StrCompID & "'")
        strCompName = Microsoft.VisualBasic.Left(strCompName, 32)
        StrFileName = strCompName & Format(dtWorkingDate, "Mddyyyy hmmss tt")
        'StrFileName = "ek_Attendance.DB_Backup_On_" & Format(Now.Date, "yyyy_mm_dd").ToString & "_" & StrTim & ".bkp"
        StrBackupPath = txtBkpPath.Text & "\" & StrFileName
        Dim sqlQRY As String
        Dim cnBkp As New SqlConnection(sqlConString)
        cnBkp.Open()
        Try
            sqlQRY = "USE " & sDatabase & ";" & _
                " BACKUP DATABASE " & sDatabase & " " & _
          " TO DISK = '" & StrBackupPath & "' " & _
          " WITH FORMAT, " & _
          " MEDIANAME = 'Z_SQLServerBackups', " & _
          " NAME = 'Full Backup of " & sDatabase & "';"

            Dim cmBkp As New SqlCommand(sqlQRY, cnBkp)
            cmBkp.ExecuteNonQuery()

            MsgBox("Successfully Backup Database")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnBkp.Close()
        End Try

        sSQL = "INSERT INTO tblBackupHistory (trForm,task,crUser,crDate,regID) VALUES ('" & Me.Name & "','Backup generated' ,'" & StrUserID & "',getdate (),'" & strUsersRegID & "')" : FK_EQ(sSQL, "S", "", False, False, True)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        lblCompany.Text = lblCompany.Text.Substring(1) & lblCompany.Text.Substring(0, 1)

    End Sub

    Private Sub cmdBrsPath_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrsPath.MouseEnter

        Me.cmdBrsPath.FlatStyle = FlatStyle.Standard
        Me.cmdBrsPath.FlatAppearance.BorderSize = 1
        Me.cmdBrsPath.Width = 24
        Me.cmdBrsPath.Height = 24

    End Sub

    Private Sub cmdBrsPath_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrsPath.MouseLeave

        Me.cmdBrsPath.FlatStyle = FlatStyle.Flat
        Me.cmdBrsPath.FlatAppearance.BorderSize = 0
        Me.cmdBrsPath.Width = 22
        Me.cmdBrsPath.Height = 22

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UP("Backup", "Generate backup") = False Then Exit Sub
        Dim cnUps As New SqlConnection(sqlConString)
        cnUps.Open()
        Dim cmUps As New SqlCommand
        cmUps = cnUps.CreateCommand
        Dim trUps As SqlTransaction = cnUps.BeginTransaction
        cmUps.Transaction = trUps
        Dim sqlQRY As String
        Try
            sqlQRY = "UPDATE tblCompany SET BackPath = '" & txtBkpPath.Text & "' WHERE CompID = '" & StrCompID & "'"
            cmUps.CommandText = sqlQRY
            cmUps.ExecuteNonQuery()

            'Backup database 

            trUps.Commit()


        Catch ex As Exception
            MsgBox(ex.Message)
            trUps.Rollback()
        Finally
            cnUps.Close()
        End Try

        Backup_DB()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub txtCompName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompName.TextChanged

    End Sub
End Class