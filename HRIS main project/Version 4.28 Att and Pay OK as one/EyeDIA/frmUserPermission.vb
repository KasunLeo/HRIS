Imports System.Data.SqlClient

Public Class frmUserPermission
    'Declare the variables
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub frmUserPermission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If UP("User Permission for Events", "View User Permission") = False Then Me.Close()
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        'Label3.BackColor = clrFocused
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Try
            sSQL = "Select Loc,Evnt,tblUserLevel.lvDesc from tblUserPermissionA Left join tblUserLevel on tblUserLevel.LevelValue=tblUserPermissionA.Val order by Loc Asc"
            Load_InformationtoGrid(sSQL, dgv, 3)
            For X As Integer = 0 To dgv.RowCount - 1
                If X Mod 2 = 0 Then dgv.Rows(X).DefaultCellStyle.BackColor = Color.AliceBlue
            Next
            sSQL = "Select lvDesc,LevelValue from tblUserLevel where Status='0'"
            Dim CN As New SqlConnection(sqlConString)
            Dim sBol As Boolean = False
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgvUser.DataSource = sTable.Tables(0)
            CN.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            sSQL = "SELECT lvDesc FROM tblUserLevel where Status='0' "
            Dim sqlcon As New SqlConnection(sqlConString)
            sqlcon.Open()
            Dim sqlCmd As New SqlCommand(sSQL, sqlcon)
            Dim sqlReader As SqlDataReader = sqlCmd.ExecuteReader
            With dgv
                DirectCast(dgv.Columns(2), DataGridViewComboBoxColumn).Items.Clear()
                While sqlReader.Read
                    ' DirectCast(dgvCheque.Columns(3), DataGridViewComboBoxColumn).Items.Add(sqlReader.Item(0))
                    DirectCast(dgv.Columns(2), DataGridViewComboBoxColumn).Items.Add(sqlReader.Item(0))
                End While
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        'drag = True 'Sets the variable drag to true.
        'mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        'mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        'If drag is set to true then move the form accordingly.
        'If drag Then
        ' Me.Top = Windows.Forms.Cursor.Position.Y - mousey
        ' Me.Left = Windows.Forms.Cursor.Position.X - mousex
        'End If
    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        'drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("User Permission for Events", "Edit User Permission") = False Then Exit Sub
        sSQL = ""
        For X As Integer = 0 To dgv.RowCount - 1
            Dim sUserval As Double = 0
            If dgv.Item(2, X).Value.ToString <> "" Then
                For Y As Integer = 0 To dgvUser.RowCount - 1
                    If dgv.Item(2, X).Value.ToString = dgvUser.Item(0, Y).Value.ToString Then
                        sUserval = dgvUser.Item(1, Y).Value
                        Exit For
                    End If
                Next
            End If
            sSQL = sSQL & "Update tblUserPermissionA Set Val='" & sUserval & "' where Loc='" & dgv.Item(0, X).Value.ToString & "' and Evnt='" & dgv.Item(1, X).Value.ToString & "';"
        Next
        If FK_EQ(sSQL, "E", "", True, True, True) = True Then
            cmdRefresh_Click(sender, e)
        End If
    End Sub

    Private Sub frmUserPermission_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'drag = True 'Sets the variable drag to true.
        'mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        'mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub frmUserPermission_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'If drag is set to true then move the form accordingly.
        'If drag Then
        ' Me.Top = Windows.Forms.Cursor.Position.Y - mousey
        ' Me.Left = Windows.Forms.Cursor.Position.X - mousex
        'End If
    End Sub

    Private Sub frmUserPermission_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        'drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgv.DataError
    End Sub

End Class