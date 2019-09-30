Imports System.Data.SqlClient
Imports HRISforBB.GlassTableGDI

Public Class frmSetTitle
    Dim StrSvStatus As String = "S"

    Private Sub frmSetTitle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button2_Click(sender, e)
        'CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
   
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

      

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

       
    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick

        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value

        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "SELECT * FROM tblSetTitle WHERE TitleID = '" & txtCode.Text & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item(0)), "", drShw.Item(0))
                txtDesc.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1)))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item(3)), "", drShw.Item(3))

                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim bolAct As Boolean = False

        bolAct = fk_CheckEx("SELECT * FROM tblEmployee WHERE titleID = '" & txtCode.Text & "' AND empStatus <> 9")

        Select Case StrSvStatus
            Case "S"
                'Can't process save with deleted status
                If chkStatus.CheckState = CheckState.Checked Then
                    MsgBox("Can't Save with Deleted Status", MsgBoxStyle.Information)
                    Exit Sub

                End If
            Case "E"
                If bolAct = True Then
                    MsgBox("Can't Process Delete when the Active Employee Informations are existing", MsgBoxStyle.Information)
                    Exit Sub
                Else
                    If MsgBox("Do you want to modify Information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
        End Select
        Dim retMess As String

        retMess = Save_Codes(StrSvStatus, txtCode.Text, txtDesc.Text, chkStatus.CheckState, "NoTitles", "tblSetTitle", "titleID", "titleDesc")

        MsgBox(retMess, MsgBoxStyle.Information)
        Button2_Click(sender, e)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FK_Clear(Me)
        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoTitles FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT titleID,titleDesc FROM tblSetTitle Order By TitleID", dgvData, 2)
        clr_Grid(dgvData)
    End Sub
End Class