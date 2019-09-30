Imports System.Data.SqlClient

Public Class frmAttendenceFields

    Public X As Integer = 0

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmAttendenceFields_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        Label8.BackColor = clrFocused
        Label10.BackColor = clrFocused
        Label11.BackColor = clrFocused
        Label12.BackColor = clrFocused
        'New Code added secondary
        Dim strSqlServer = ReadKey("HRTime\SQLServer")
        Dim strSqlDatabase = ReadKey("HRTime\SQLDatabase")
        Dim strUserName = ReadKey("HRTime\UserName")
        Dim strPassword = ReadKey("HRTime\Password")
        If strSqlServer = "" Or strSqlDatabase = "" Or strUserName = "" Then MsgBox("Please Add Attendence Database Setting From the Edit menu", MsgBoxStyle.Information) : Me.Close() : Exit Sub

        Try
            Dim sqlConString1 = "Password= " & strPassword & ";Persist Security Info=True;User ID=" & strUserName & ";Initial Catalog=" & strSqlDatabase & ";Data Source= " & strSqlServer & ";TimeOut=12000"

            If dbSqlCon.State = ConnectionState.Open Then dbSqlCon.Close()
            dbSqlCon.ConnectionString = sqlConString1
            cmbTable.Items.Clear()
            sSQL = "SELECT Name FROM sys.Tables order by Name asc"
            Dim con As New SqlConnection(sqlConString1)
            Try
                con.Open()
                Dim sqlcombo_department As New SqlCommand(sSQL, con)
                Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()

                While redcombo_department.Read()
                    cmbTable.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
                End While
                redcombo_department.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
            '''''''''''''''''''''''
            'FillCombo(cmbTable, "SELECT Name FROM sys.Tables order by Name asc")
            FillComboAll(ComboBox1, "select column_name from information_schema.columns  where table_name = 'tblAttSum' order by ordinal_position")

            cmbTable.Text = fk_RetString("Select FirstTB from tblAtFor")

            Load_InformationtoGrid("Select FirstCl,SecondCl from tblAtFor ", dgvData, 2)
            Call Button6_Click(sender, e)

        Catch ex As Exception
            MsgBox("Databse Connection Failed", MsgBoxStyle.Information)
        End Try
        If dbSqlCon.State = ConnectionState.Open Then
            dbSqlCon.Close()
        End If

    End Sub

    Private Sub dgvData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.Click
        On Error Resume Next
        X = dgvData.CurrentRow.Index
    End Sub

    Private Sub dgvData_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.DockChanged

    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        Dim strMessage As String = "Are you sure you want to Delete this ID :" & dgvData.Item(1, dgvData.CurrentRow.Index).Value
        If MsgBox(strMessage, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        Dim sqlQry As String
        '=================================Rajitha edited hear instead of id i changed to fieldname
        ' and the second query newly added .
        sqlQry = "Delete from tblAttendenceRow where FieldName='" & dgvData.Item(1, dgvData.CurrentRow.Index).Value & "'"
        sqlQry = sqlQry & " update tblatfor set secondCl='' where secondCl='" & dgvData.Item(1, dgvData.CurrentRow.Index).Value & "'"
        Try
            If FK_Delete(sqlQry, False, False) = True Then
                MsgBox("Data Deleted Successfully..", MsgBoxStyle.Information)
                Load_InformationtoGrid("Select FirstCl,SecondCl from tblAtFor ", dgvData, 2)
                'loadData()
            Else
                MsgBox("Data Delete Failed", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Error Occured." + ex.Message)

        End Try


    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then Call Button1_Click_1(sender, e)
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub dgvEPF_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvEPF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbTable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTable.SelectedIndexChanged
        sSQL = "select column_name from information_schema.columns  where table_name = '" & cmbTable.Text & "' order by ordinal_position"
        Load_InformationtoGridLocal(sSQL, dgvData, 1)

        TextBox2.Text = "Where " & cmbTable.Text & ".cMonth=sCmonth  and " & cmbTable.Text & ".cYear=sCYear"
    End Sub
    Public Sub Load_InformationtoGridLocal(ByVal sqlQ As String, ByVal grid As DataGridView, ByVal cols As Integer)
        Dim strSqlServer = ReadKey("HRTime\SQLServer")
        Dim strSqlDatabase = ReadKey("HRTime\SQLDatabase")
        Dim strUserName = ReadKey("HRTime\UserName")
        Dim strPassword = ReadKey("HRTime\Password")
        If strSqlServer = "" Or strSqlDatabase = "" Or strUserName = "" Then MsgBox("Please Add Attendence Database Setting From the Edit menu", MsgBoxStyle.Critical) : Exit Sub

        Dim sqlConString1 = "Password= " & strPassword & ";Persist Security Info=True;User ID=" & strUserName & ";Initial Catalog=" & strSqlDatabase & ";Data Source= " & strSqlServer & ";TimeOut=12000"




        grid.Rows.Clear()
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("xx", "Head")
        End With
        Dim iCol As Integer
        Dim cnPop As New SqlConnection(sqlConString1)
        cnPop.Open()
        Try
            Dim cmPop As New SqlCommand(sqlQ, cnPop)
            Dim drPop As SqlDataReader = cmPop.ExecuteReader
            Do While drPop.Read = True
                dgv.Rows.Clear()
                For iCol = 0 To cols - 1
                    Dim StrX As String = IIf(IsDBNull(drPop.Item(iCol)), "", drPop.Item(iCol))
                    dgv.Rows.Add(StrX)
                Next
                ', dgv.Item(0, 3)
                Dim nCol As Integer = cols - 1
                Select Case nCol
                    Case 0
                        grid.Rows.Add(dgv.Item(0, 0).Value)
                    Case 1
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value)
                    Case 2
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value)
                    Case 3
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value)
                    Case 4
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value)
                    Case 5
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value)
                    Case 6
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value)
                    Case 7
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value)
                    Case 8
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value)
                    Case 9
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value)
                    Case 10
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value)
                    Case 11
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value)
                    Case 12
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value)
                    Case 13
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value)
                End Select
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnPop.Close()
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Try
            dgvData.Item(1, X).Value = ComboBox1.Text
            Call Button6_Click(sender, e)
            '    'sSQL = "Insert into tblAttSum "
            '    sSQL1 = ""
            '    For i = 0 To dgvData.RowCount - 1
            '        If dgvData.Item(1, i).Value <> "" Then
            '            sSQL1 = sSQL1 & dgvData.Item(0, i).Value.ToString & ","
            '        End If
            '    Next
            '    sSQL1 = Microsoft.VisualBasic.Left(sSQL1, Len(sSQL1) - 1)
            '    sSQL = ""
            '    For i = 0 To dgvData.RowCount - 1
            '        If dgvData.Item(1, i).Value <> "" Then
            '            sSQL = sSQL & dgvData.Item(1, i).Value.ToString & ","
            '        End If
            '    Next
            '    sSQL = Microsoft.VisualBasic.Left(sSQL, Len(sSQL) - 1)

            '    sSQL = "Insert into tblAttSum ( " & sSQL & " ) Select   " & sSQL1 & "  from " & cmbTable.Text

            '    TextBox1.Text = sSQL
            '    'MsgBox(sSQL1)


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Call Button5_Click(sender, e)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            sSQL1 = ""
            For i = 0 To dgvData.RowCount - 1
                If dgvData.Item(1, i).Value <> "" Then
                    sSQL1 = sSQL1 & dgvData.Item(0, i).Value.ToString & " as '" & dgvData.Item(1, i).Value.ToString & "',"
                End If
            Next
            sSQL1 = Microsoft.VisualBasic.Left(sSQL1, Len(sSQL1) - 1)
            sSQL = ""
            For i = 0 To dgvData.RowCount - 1
                If dgvData.Item(1, i).Value <> "" Then
                    sSQL = sSQL & dgvData.Item(1, i).Value.ToString & ","
                End If
            Next
            sSQL = Microsoft.VisualBasic.Left(sSQL, Len(sSQL) - 1)

            sSQL = " Select   " & sSQL1 & "  from " & cmbTable.Text
            sSQL = Replace(sSQL, "'", "`")
            TextBox1.Text = sSQL
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''sSQL = "Create table tblAtFor (Firsttb varchar(100),FirstCl varchar(100),SecondTb Varchar(100),SecondCl Varchar(100))"
        ''FK_EQ(sSQL, "", False, False, False)

        If UP("Attendence Summery", "Add Attendence Summery Formula") = True Then
            sSQL = "Delete from tblAtfor "
            For i = 0 To dgvData.RowCount - 1
                sSQL = sSQL & " Insert into tblAtfor Values ('" & cmbTable.Text & "','" & dgvData.Item(0, i).Value & "','tblAttSum','" & dgvData.Item(1, i).Value & "') "
            Next
            sSQL1 = "'" & TextBox1.Text & " " & TextBox2.Text & "'"

            sSQL = sSQL & " Update tblControl Set AttFormula=" & ssql1

            If FK_EQ(sSQL, "S", "", True, True, True) = True Then Me.Close()
        End If
    End Sub

End Class