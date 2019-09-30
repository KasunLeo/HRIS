Imports System.Data.SqlClient

Public Class FrmNewBrowse

    Public strSearch1 As String = ""
    Public sSearchCriteria As String

    Private Sub frmBrowse_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
            ssearch = ""
        End If

    End Sub

    Private Sub frmBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CenterFormThemed(Me, pnlTopk, txtTitle)
        ControlHandlers(Me)
        'Dim CN As New MySqlConnection(sqlconstring)
        'Dim ADP As New MySqlDataAdapter(ssql, CN)
        'CN.Open()
        'ADP.Fill(ds)
        dgvSearch.DataSource = DS.Tables(0)
        Dim Width1 As Double = 0
        For X As Integer = 0 To dgvSearch.ColumnCount - 1
            Width1 += dgvSearch.Columns(X).Width
        Next
        If Width1 > dgvSearch.Width Then
            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Else
            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        'Public sSelect As String'GLoble Variable
        'Public sSearch As String'GLoble Variable
        'CenterForm(Me)
        'strSearch1 = sSearch
        'sSearch = ""
        'If NetworkType = 0 Then
        '    Dim sSQL As String
        '    sSQL = " Select " & sselect & " from " & currentuser & " Limit 50 "
        '    If sSQL = "" Then Exit Sub

        '    Dim CN As New MySqlConnection(sqlConString)
        '    Dim sBol As Boolean = False
        '    Try
        '        CN.Open()
        '        Dim ADP As New MySqlDataAdapter
        '        Dim sTable As New DataSet
        '        ADP = New MySqlDataAdapter(sSQL, CN)
        '        ADP.Fill(sTable)
        '        dgvSearch.DataSource = sTable.Tables(0)
        '        'dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '        Fk_GridsizeAuto(dgvSearch)
        '        For X = 0 To dgvSearch.Columns.Count - 1
        '            dgvSearch.Columns(X).HeaderText = UCase(dgvSearch.Columns(X).HeaderText)
        '            'sdgv.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '        Next
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        '    CN.Close()
        'End If

        lblCount.Text = "Number of Employees : " & dgvSearch.RowCount
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
        'If e.KeyChar = ChrW(Keys.Escape) Then
        '    Me.Close()
        '    sSearch = ""
        'End If
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If NetworkType = 1 Then
        '        Dim strSearch As String
        '        If sSearch = "" Then Exit Sub
        '        strSearch = sSearch
        '        sSearch = ""
        '        dgv.Rows.Clear()
        '        Dim verStop As Double
        '        If Microsoft.VisualBasic.Right(strSearch, 1) <> "," Then strSearch = strSearch & ","
        '        While Len(strSearch) > 1
        '            For Y = 1 To Len(strSearch)
        '                If Mid((strSearch), Y, 1) = "," Then
        '                    'VerStop = Y - verStart - 1
        '                    verStop = Y - 1
        '                    dgv.Rows.Add(Mid(strSearch, 1, verStop))
        '                    strSearch = Mid(strSearch, Y + 1, Len(strSearch))
        '                    Exit For
        '                End If
        '            Next
        '        End While
        '        sSearchCriteria = " "
        '        If dgv.RowCount = 0 Then Exit Sub
        '        sSearchCriteria = " Where "
        '        Dim X As Integer
        '        For X = 0 To dgv.RowCount - 1
        '            sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' or "
        '        Next
        '        X = X - 1
        '        sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' "
        '        If ConstantCriteria <> "" Then
        '            sSearchCriteria = sSearchCriteria & " and " & ConstantCriteria
        '            ConstantCriteria = ""
        '        End If
        '        Dim sSQL As String
        '        sSQL = sSelect & " " & sSearchCriteria
        '        Dim CN As New MySqlConnection(sqlConString)
        '        Dim sBol As Boolean = False
        '        Try
        '            CN.Open()
        '            Dim ADP As New MySqlDataAdapter
        '            Dim sTable As New DataSet
        '            ADP = New MySqlDataAdapter(sSQL, CN)
        '            ADP.Fill(sTable)
        '            dgvSearch.DataSource = sTable.Tables(0)
        '            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        End Try
        '        CN.Close()
        '    End If
        'End If

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        Try
            sSQL = ""
            Dim Order1 As String = ""
            For X As Integer = 0 To DS.Tables(0).Columns.Count - 1
                ssql1 = DS.Tables(0).Columns(X).DataType.ToString()
                If sSQL <> "" And Microsoft.VisualBasic.Right(Trim(sSQL), 2) <> "or" Then sSQL = sSQL & " or "
                If DS.Tables(0).Columns(X).DataType.ToString() = "System.String" Then sSQL = sSQL & DS.Tables(0).Columns(X).ColumnName.ToString() & " Like '%" & txtSearch.Text & "%' "
                If DS.Tables(0).Columns(X).DataType.ToString() = "System.Decimal" Then sSQL = sSQL & DS.Tables(0).Columns(X).ColumnName.ToString() & " =" & Val(txtSearch.Text)
            Next
            sSQL = Trim(sSQL)
            If sSQL <> "" And Microsoft.VisualBasic.Right(Trim(sSQL), 2) = "or" Then sSQL = Microsoft.VisualBasic.Left(sSQL, Len(sSQL) - 2)
            'MsgBox(ssql)
            Order1 = DS.Tables(0).Columns(0).ColumnName.ToString() & " Asc "
            Dim dv As DataView
            'ssql = "ItemCode like '%" & TextBox1.Text & "%' "
            dv = New DataView(DS.Tables(0), sSQL, Order1, DataViewRowState.CurrentRows)
            dgvSearch.DataSource = dv
            Dim Width1 As Double = 0
            For X As Integer = 0 To dgvSearch.ColumnCount - 1
                Width1 += dgvSearch.Columns(X).Width
            Next
            If Width1 > dgvSearch.Width Then
                dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Else
                dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'If networktype = 0 Then
        '    If Len(txtSearch.Text) Mod 2 = 0 Then
        '        Dim strSearch As String = ""
        '        If strSearch1 = "" Then Exit Sub
        '        strSearch = strSearch1
        '        'sSearch = ""
        '        dgv.Rows.Clear()
        '        Dim verStop As Double
        '        If Microsoft.VisualBasic.Right(strSearch, 1) <> "," Then strSearch = strSearch & ","
        '        While Len(strSearch) > 1
        '            For Y = 1 To Len(strSearch)
        '                If Mid((strSearch), Y, 1) = "," Then
        '                    'VerStop = Y - verStart - 1
        '                    verStop = Y - 1
        '                    dgv.Rows.Add(Mid(strSearch, 1, verStop))
        '                    strSearch = Mid(strSearch, Y + 1, Len(strSearch))
        '                    Exit For
        '                End If
        '            Next
        '        End While
        '        sSearchCriteria = " "
        '        If dgv.RowCount = 0 Then Exit Sub
        '        sSearchCriteria = " Where "
        '        Dim X As Integer
        '        For X = 0 To dgv.RowCount - 1
        '            sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' or "
        '        Next
        '        X = X - 1
        '        sSearchCriteria = sSearchCriteria & dgv.Item(0, X).Value.ToString() & " like '%" & txtSearch.Text & "%' "
        '        If constantcriteria <> "" Then
        '            sSearchCriteria = sSearchCriteria & " and " & constantcriteria
        '        End If
        '        Dim sSQL As String
        '        Dim sSel As String = " Select " & sselect & " from " & currentuser
        '        sSQL = sSel & " " & sSearchCriteria
        '        Dim CN As New MySqlConnection(sqlconstring)
        '        Dim sBol As Boolean = False
        '        Try
        '            CN.Open()
        '            Dim ADP As New MySqlDataAdapter
        '            Dim sTable As New DataSet
        '            ADP = New MySqlDataAdapter(sSQL, CN)
        '            ADP.Fill(sTable)
        '            dgvSearch.DataSource = sTable.Tables(0)
        '            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        End Try
        '        CN.Close()
        '    End If

        'End If

        lblCount.Text = "Number of Employees : " & dgvSearch.RowCount

    End Sub

    Private Sub dgvSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSearch.Click

        lblEmpNam.Text = "Selected Employee : " & dgvSearch.CurrentRow.Cells(1).Value.ToString

    End Sub

    Private Sub dgvSearch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSearch.DoubleClick

        BrowseTrue = True
        StrEmployeeID = dgvSearch.Item(0, dgvSearch.CurrentRow.Index).Value
        'Try
        '    sSQL = ""
        '    Dim Order1 As String = ""
        '    For X = 0 To DS.Tables(0).Columns.Count - 1
        '        ssql1 = DS.Tables(0).Columns(X).DataType.ToString()
        '        If sSQL <> "" And Microsoft.VisualBasic.Right(Trim(sSQL), 3) <> "and" Then sSQL = sSQL & " and "
        '        If DS.Tables(0).Columns(X).DataType.ToString() = "System.String" Then sSQL = sSQL & DS.Tables(0).Columns(X).ColumnName.ToString() & " ='" & dgvSearch.Item(X, dgvSearch.CurrentRow.Index).Value & "' "
        '        If DS.Tables(0).Columns(X).DataType.ToString() = "System.Decimal" Then sSQL = sSQL & DS.Tables(0).Columns(X).ColumnName.ToString() & " =" & Val(dgvSearch.Item(X, dgvSearch.CurrentRow.Index).Value)
        '    Next
        '    sSQL = Trim(sSQL)

        '    If sSQL <> "" And Microsoft.VisualBasic.Right(Trim(sSQL), 3) = "and" Then sSQL = Microsoft.VisualBasic.Left(sSQL, Len(sSQL) - 3)
        '    'MsgBox(ssql)
        '    Order1 = DS.Tables(0).Columns(0).ColumnName.ToString() & " Asc "
        '    Dim dv As DataView
        '    'ssql = "ItemCode like '%" & TextBox1.Text & "%' "
        '    dv = New DataView(DS.Tables(0), sSQL, Order1, DataViewRowState.CurrentRows)
        '    frmMainAttendance.dgvFillGridforRead.DataSource = dv
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        ''ssearch = dgvSearch.CurrentRow.Cells(0).Value.ToString()
        Me.Close()
    End Sub




    Private Sub dgvSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSearch.KeyDown
        'On Error Resume Next
        BrowseTrue = True
        If e.KeyCode = (Keys.Enter) Then
            Try
                sSQL = ""
                Dim Order1 As String = ""
                For X As Integer = 0 To DS.Tables(0).Columns.Count - 1
                    ssql1 = DS.Tables(0).Columns(X).DataType.ToString()
                    If sSQL <> "" And Microsoft.VisualBasic.Right(Trim(sSQL), 2) <> "or" Then sSQL = sSQL & " or "
                    If DS.Tables(0).Columns(X).DataType.ToString() = "System.String" Then sSQL = sSQL & DS.Tables(0).Columns(X).ColumnName.ToString() & " Like '%" & dgvSearch.Item(X, dgvSearch.CurrentRow.Index).Value & "%' "
                    If DS.Tables(0).Columns(X).DataType.ToString() = "System.Decimal" Then sSQL = sSQL & DS.Tables(0).Columns(X).ColumnName.ToString() & " =" & Val(dgvSearch.Item(X, dgvSearch.CurrentRow.Index).Value)
                Next
                sSQL = Trim(sSQL)
                If sSQL <> "" And Microsoft.VisualBasic.Right(Trim(sSQL), 2) = "or" Then sSQL = Microsoft.VisualBasic.Left(sSQL, Len(sSQL) - 2)
                'MsgBox(ssql)
                Order1 = DS.Tables(0).Columns(0).ColumnName.ToString() & " Asc "
                Dim dv As DataView
                'ssql = "ItemCode like '%" & TextBox1.Text & "%' "
                dv = New DataView(DS.Tables(0), sSQL, Order1, DataViewRowState.CurrentRows)
                frmMainAttendance.dgvFillGridforRead.DataSource = dv
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'ssearch = dgvSearch.CurrentRow.Cells(0).Value.ToString()
            Me.Close()
        End If

        If e.KeyCode = (Keys.Escape) Then
            Me.Close()
            ssearch = ""
        End If

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class
