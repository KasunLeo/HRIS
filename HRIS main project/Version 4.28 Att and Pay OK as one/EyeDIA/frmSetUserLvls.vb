Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmUserLvls

    Dim StrUlvID As String = ""
    Dim StrSvStatus As String = "S"

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

       

    End Sub


    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
       
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub frmUserLvls_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)

        '==========Copied Start
        '' '' ''        Dim strQry As String = " create table tblUserLevel(" & _
        '' '' ''" lvId nvarchar(3) null," & _
        '' '' ''" LvDesc nvarchar (30) null," & _
        '' '' ''" Status numeric (18,0) null," & _
        '' '' ''" compID nvarchar (3) null" & _
        '' '' ''" )" ' " UserVal numeric (18,0) Not null default ((0))" & _
        '' '' ''        fk_CreateTableR(strQry, "tblUserLevel")

        '==============Copied Over

        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.BackColor, 90)

    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown

        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp

        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.BackColor

    End Sub

   

    Private Sub txtuLvname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuLvname.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'If UP("Users", "Set user level") = False Then Exit Sub
        ''Save Information to the table 
        ''If txtuLvID.Text = "" Then
        ''    MsgBox("PLease Refresh", MsgBoxStyle.Information)
        ''    Exit Sub
        ''End If

        'If txtuLvname.Text = "" Then
        '    MsgBox("Please Enter Description", MsgBoxStyle.Information)
        '    txtuLvname.Focus()
        '    Exit Sub
        'End If

        ''check existance userlevels before allowing to remove.
        'If StrSvStatus = "E" Then
        '    If chkUlvStatus.Checked Then
        '        If True = fk_CheckEx("select uLvl from tblUsers where uLvl='" & txtuLvID.Text & "'") Then
        '            MsgBox("Unable to Remove when there are active users with the selected user level. Please give them different user level and try again")
        '            txtuLvID.Focus()
        '            Exit Sub
        '        End If
        '    End If

        'End If

        'If StrSvStatus = "S" Then
        '    txtuLvID.Text = fk_CreateSerial(3, (fk_sqlDbl("SELECT NoUlv FROM tblCompany WHERE COmpID = '" & StrCompID & "'") + 1))
        'End If


        'Dim cnSave As New SqlConnection(sqlConString)
        'cnSave.Open()
        'Dim cmSave As New SqlCommand
        'cmSave = cnSave.CreateCommand
        'Dim trSave As SqlTransaction = cnSave.BeginTransaction
        'cmSave.Transaction = trSave
        'Dim sqlQRY As String = ""
        'Try

        '    Select Case StrSvStatus
        '        Case "S"
        '            sqlQRY = "INSERT INTO tblUserLevel (lvId,LvDesc,Status,CompID,levelValue) VALUES ('" & txtuLvID.Text & "','" & FK_Rep(txtuLvname.Text) & "', " & chkUlvStatus.CheckState & ",'" & StrCompID & "')"
        '            cmSave.CommandText = sqlQRY
        '            cmSave.ExecuteNonQuery()

        '            sqlQRY = "UPDATE tblCompany SET NoUlv = NoUlv + 1 WHERE CompID = '" & StrCompID & "'"
        '            cmSave.CommandText = sqlQRY
        '            cmSave.ExecuteNonQuery()

        '            trSave.Commit()
        '            MsgBox("Information Saved", MsgBoxStyle.Information)
        '            cmdRefresh_Click(sender, e)
        '        Case "E"

        '            'Update information 
        '            sqlQRY = "UPDATE tblUserLevel SET LvDesc = '" & FK_Rep(txtuLvname.Text) & "',Status = " & chkUlvStatus.CheckState & " WHERE LvID = '" & txtuLvID.Text & "' AND compID = '" & StrCompID & "'"
        '            cmSave.CommandText = sqlQRY
        '            cmSave.ExecuteNonQuery()

        '            trSave.Commit()
        '            MsgBox("Information Modified", MsgBoxStyle.Information)
        '            cmdRefresh_Click(sender, e)

        '    End Select
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    trSave.Rollback()
        'Finally
        '    cnSave.Close()
        'End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim crtl As Control
        'For Each crtl In Me.Controls
        '    If TypeOf crtl Is TextBox Then crtl.Text = ""
        'Next
        'chkUlvStatus.Checked = False

        'Dim iLv As Integer = fk_sqlDbl("SELECT NoUlv FROM tblCompany WHERE COmpID = '" & StrCompID & "'") + 1
        'StrUlvID = fk_CreateSerial(3, iLv)
        'txtuLvID.Text = StrUlvID

        'StrSvStatus = "S"

        ''Show information in the grid
        'Dim sqlQ As String = "SELECT LvID,LvDesc,Status FROM tblUserLevel WHERE COmpID = '" & StrCompID & "' Order By LvID"
        'Load_InformationtoGrid(sqlQ, dgvUlv, 3)
        'clr_Grid(dgvUlv)
    End Sub

   

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
       
    End Sub

End Class