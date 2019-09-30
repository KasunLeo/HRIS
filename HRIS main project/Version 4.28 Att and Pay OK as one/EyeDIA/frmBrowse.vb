Imports System.Data.SqlClient

Public Class frmBrowse
    '
    Public strSearch1 As String = ""
    Public sSearchCriteria, ConstantCriteria As String

    Private Sub frmBrowse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
            sSearch = ""
        End If
    End Sub

    Private Sub frmBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, txtTitle)
        ControlHandlers(Me)
        strSearch1 = sSearch
        sSearch = ""
        If strSearchText <> "" Then txtSearch.Text = strSearchText
        If NetworkType = 0 Then
            Dim sSQL As String
            sSQL = " Select top 100 " & sSelect & " from " & CurrentUser
            If sSQL = "" Then Exit Sub

            Dim CN As New SqlConnection(sqlConString)
            Dim sBol As Boolean = False
            Try
                CN.Open()
                Dim ADP As New SqlDataAdapter
                Dim sTable As New DataSet
                ADP = New SqlDataAdapter(sSQL, CN)
                ADP.Fill(sTable)
                dgvSearch.DataSource = sTable.Tables(0)
                dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                For X = 0 To dgvSearch.Columns.Count - 1
                    If dgvSearch.Columns(X).Width < 150 Then dgvSearch.Columns(X).Width = 150
                    dgvSearch.Columns(X).HeaderText = UCase(dgvSearch.Columns(X).HeaderText)
                Next
                lblCount.Text = "Total Searched : " & dgvSearch.RowCount

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            CN.Close()
        End If
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.GotFocus
        'Dim strSearch As String
        'If sSearch = "" Then Exit Sub
        'strSearch = sSearch
        'dgv.Rows.Clear()
        'Dim verStop As Double
        'If Microsoft.VisualBasic.Right(strSearch, 1) <> "," Then strSearch = strSearch & ","
        'While Len(strSearch) > 1
        '    For Y = 1 To Len(strSearch)
        '        If Mid((strSearch), Y, 1) = "," Then
        '            'VerStop = Y - verStart - 1
        '            verStop = Y - 1
        '            dgv.Rows.Add(Mid(strSearch, 1, verStop))
        '            strSearch = Mid(strSearch, Y + 1, Len(strSearch))
        '            Exit For
        '        End If
        '    Next
        'End While
        'sSearchCriteria = " "
        'If dgv.RowCount = 0 Then Exit Sub
        'sSearchCriteria = " Where "
        'Dim X As Integer
        'For X = 0 To dgv.RowCount - 1
        '    sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' or "
        'Next
        'X = X - 1
        'sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' "
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            dgvSearch.Focus()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
            sSearch = ""
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            If NetworkType = 1 Then
                Dim strSearch As String
                If sSearch = "" Then Exit Sub
                strSearch = sSearch
                sSearch = ""
                dgv.Rows.Clear()
                Dim verStop As Double
                If Microsoft.VisualBasic.Right(strSearch, 1) <> "," Then strSearch = strSearch & ","
                While Len(strSearch) > 1
                    For Y = 1 To Len(strSearch)
                        If Mid((strSearch), Y, 1) = "," Then
                            'VerStop = Y - verStart - 1
                            verStop = Y - 1
                            dgv.Rows.Add(Mid(strSearch, 1, verStop))
                            strSearch = Mid(strSearch, Y + 1, Len(strSearch))
                            Exit For
                        End If
                    Next
                End While
                sSearchCriteria = " "
                If dgv.RowCount = 0 Then Exit Sub
                sSearchCriteria = " Where "
                Dim X As Integer
                For X = 0 To dgv.RowCount - 1
                    sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' or "
                Next
                X = X - 1
                sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' "
                If ConstantCriteria <> "" Then
                    sSearchCriteria = sSearchCriteria & " and " & ConstantCriteria
                    ConstantCriteria = ""
                End If
                Dim sSQL As String
                sSQL = sSelect & " " & sSearchCriteria
                Dim CN As New SqlConnection(sqlConString)
                Dim sBol As Boolean = False
                Try
                    CN.Open()
                    Dim ADP As New SqlDataAdapter
                    Dim sTable As New DataSet
                    ADP = New SqlDataAdapter(sSQL, CN)
                    ADP.Fill(sTable)
                    dgvSearch.DataSource = sTable.Tables(0)
                    dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                CN.Close()
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If networktype = 0 Then
            If Len(txtSearch.Text) Mod 2 = 0 Then
                Dim strSearch As String = ""
                If strSearch1 = "" Then Exit Sub
                strSearch = strSearch1
                'sSearch = ""
                dgv.Rows.Clear()
                Dim verStop As Double
                If Microsoft.VisualBasic.Right(strSearch, 1) <> "," Then strSearch = strSearch & ","
                While Len(strSearch) > 1
                    For Y = 1 To Len(strSearch)
                        If Mid((strSearch), Y, 1) = "," Then
                            'VerStop = Y - verStart - 1
                            verStop = Y - 1
                            dgv.Rows.Add(Mid(strSearch, 1, verStop))
                            strSearch = Mid(strSearch, Y + 1, Len(strSearch))
                            Exit For
                        End If
                    Next
                End While
                sSearchCriteria = " "
                If dgv.RowCount = 0 Then Exit Sub
                sSearchCriteria = " Where "
                Dim X As Integer
                For X = 0 To dgv.RowCount - 1
                    sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' or "
                Next
                X = X - 1
                sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' "
                If constantcriteria <> "" Then
                    sSearchCriteria = sSearchCriteria & " and " & constantcriteria
                End If
                Dim sSQL As String
                Dim sSel As String = " Select " & sselect & " from " & currentuser
                sSQL = sSel & " " & sSearchCriteria
                Dim CN As New SqlConnection(sqlConString)
                Dim sBol As Boolean = False
                Try
                    CN.Open()
                    Dim ADP As New SqlDataAdapter
                    Dim sTable As New DataSet
                    ADP = New SqlDataAdapter(sSQL, CN)
                    ADP.Fill(sTable)
                    dgvSearch.DataSource = sTable.Tables(0)
                    dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                    lblCount.Text = "Total Searched : " & dgvSearch.RowCount
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                CN.Close()
            End If

        End If
    End Sub

    Private Sub dgvSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSearch.DoubleClick
        If dgvSearch.RowCount = 0 Then Exit Sub
        sSearch = dgvSearch.CurrentRow.Cells(0).Value.ToString()
        Me.Close()
    End Sub

    Private Sub dgvSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvSearch.KeyPress
        On Error Resume Next
        If e.KeyChar = ChrW(Keys.Enter) Then
            sSearch = dgvSearch.Item(0, dgvSearch.CurrentRow.Index - 1).Value.ToString 'dgvSearch.CurrentRow.Cells(0).Value.ToString()
            Me.Close()
        End If
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
            sSearch = ""
        End If
    End Sub

End Class