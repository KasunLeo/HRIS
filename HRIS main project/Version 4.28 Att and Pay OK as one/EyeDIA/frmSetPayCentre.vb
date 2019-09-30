Imports System.Data.SqlClient

Public Class frmSetPayCentre

    Dim StrSvStatus As String = "S"

    Private Sub frmPayCentre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label3)
        ControlHandlers(Me)
        Button3_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click



    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click


    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress

        cleanInput(e)
        If ChrW(Keys.Enter) = e.KeyChar Then
            cmdSave_Click(sender, e)
        End If

    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick

        If dgvData.RowCount = 0 Then Exit Sub

        With dgvData
            txtCode.Text = .CurrentRow.Cells(0).Value.ToString
            txtDesc.Text = .CurrentRow.Cells(1).Value.ToString
            chkStatus.CheckState = CInt(.CurrentRow.Cells(2).Value)
            StrSvStatus = "E"
        End With

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtCode.Text = "" Then
            MsgBox("No Code found", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            Exit Sub
        End If

        If StrSvStatus = "S" Then
            If chkStatus.Checked = True Then
                MsgBox("Unable to save with Removed Status. Deselect Remove status and try again.")
                Exit Sub
            End If
        End If

        If chkStatus.Checked Then 'chk active employees exists
            If True = fk_CheckEx("select * from tblPayrollEmployee where Payid='" & txtCode.Text & "'") Then
                MsgBox("There are active employees with this pay centre. Please give them different centre and try again.")
                Exit Sub
            End If
        End If
        If StrSvStatus = "S" Then
            Dim iCnt As Integer = fk_sqlDbl("SELECT NoPayCnt FROM tblCOntrol") + 1
            Dim StrcID As String = fk_CreateSerial(2, iCnt)
            txtCode.Text = StrcID
        End If

        'Save Information 
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
                    'If UP("Set Pay Centre", "Create Pay Center") = False Then Exit Sub
                    sqlQRY = "INSERT INTO tblSetpCentre (pID,pDesc,Status) VALUES ('" & txtCode.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblControl SET NoPayCnt = NoPayCnt + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    Button3_Click(sender, e)
                Case "E"
                    'If UP("Set Pay Centre", "Edit Pay Center") = False Then Exit Sub
                    sqlQRY = "UPDATE tblSetPCentre SET pDesc = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERE pID = '" & txtCode.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    Button3_Click(sender, e)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkStatus.Checked = False
        Dim iCnt As Integer = fk_sqlDbl("SELECT NoPayCnt FROM tblCOntrol") + 1
        Dim StrcID As String = fk_CreateSerial(2, iCnt)
        txtCode.Text = StrcID


        StrSvStatus = "S"

        Dim sqlQ As String = "SELECT pID,pDesc,Status FROM tblSetpcentre Order By pID"
        Load_InformationtoGrid(sqlQ, dgvData, 3)
    End Sub

End Class