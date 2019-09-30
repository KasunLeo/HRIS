Imports System.Data.SqlClient

Public Class frmAttendFields

    Dim strSvStatus As String = "S"

    Private Sub frmAttendFields_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label12)
        'ControlHandlers(Me)
        Label1.BackColor = clrFocused
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        strSvStatus = "S"
        txtDesc.Text = ""
        sSQL = "select column_name  as 'Attendance Fields' from information_schema.columns where table_name = 'tblAttSum' order by ordinal_position"
        Fk_FillGrid(sSQL, dgvAttnFields)
        For X = 0 To dgvAttnFields.Columns.Count - 1
            'dgvSearchK.Columns(X).HeaderText = UCase(dgvSearchK.Columns(X).HeaderText)
            dgvAttnFields.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        sSQL = "Alter table tblControl add DayID numeric(18,0) not null Default 0"
        EQ(sSQL)

        ''sSQL = "Create table tblDayFields (ID Numeric(18,0),Fld varchar(100))"
        ''EQ(sSQL)
        Dim sID As Integer = GetVal("Select DayID from tblControl") + 1
        If txtDesc.Text = "" Then MsgBox("Its Nothing to Save", MsgBoxStyle.Critical) : txtDesc.Focus() : Exit Sub

        sSQL = "Alter table tblAttSum Add " & txtDesc.Text & " Decimal(18,2) not null Default 0 "
        If FK_EQ(sSQL, "P", "", True, True, True) = True Then
            sSQL = "Insert into tblDayFields (ID,Fld) values ('" & sID & "','" & txtDesc.Text & "'); Update tblcontrol set DayID=DayID+1"
            If FK_EQ(sSQL, "S", "", False, False, True) = True Then cmdRefresh_Click(sender, e)
        End If
    End Sub

    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress
        cleanInput(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDesc.Focus()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class