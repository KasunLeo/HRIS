Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmSetBanks1

    Public svStatus As String = "S"
    Dim sBrIDR As String

    'Dim objRpt As CrystalReport1
    Private Sub frmBanks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        RefreshData()
        Refresh1()
    End Sub

    'Public Function procesSQL() As String
    '    Dim sql As String
    '    Dim inSql As String
    '    Dim firstPart As String
    '    Dim lastPart As String
    '    Dim selectStart As Integer
    '    Dim fromStart As Integer
    '    Dim fields As String()
    '    Dim i As Integer
    '    Dim MyText As TextObject

    '    inSql = TextBox1.Text
    '    inSql = inSql.ToUpper

    '    selectStart = inSql.IndexOf("SELECT")
    '    fromStart = inSql.IndexOf("FROM")
    '    selectStart = selectStart + 6
    '    firstPart = inSql.Substring(selectStart, (fromStart - selectStart))
    '    lastPart = inSql.Substring(fromStart, inSql.Length - fromStart)

    '    fields = firstPart.Split(",")
    '    firstPart = ""
    '    For i = 0 To fields.Length - 1
    '        If i > 0 Then
    '            firstPart = firstPart & " , " _
    '& fields(i).ToString() & "  AS DATACOLUMN" & i + 1
    '            MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
    '            MyText.Text = fields(i).ToString()
    '        Else
    '            firstPart = firstPart & fields(i).ToString() & _
    '"  AS DATACOLUMN" & i + 1
    '            MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
    '            MyText.Text = fields(i).ToString()
    '        End If
    '    Next
    '    sql = "SELECT " & firstPart & " " & lastPart
    '    Return sql
    'End Function

    Private Sub txtBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBank.KeyPress
        'If UP("Set Banks", "Add Banks") = False Then Exit Sub
        cleanInput(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSav_Click(sender, e)
        End If
    End Sub

    Private Sub Refresh1()
        FillComboPay(cmbBank, "Select BankName+'-'+BankID from tblBanks where status='0' order by BankName asc")
        txtBrID.Text = GetVal("Select BranchID from tblControl") + 1
        cmbBank.Text = ""
        ' txtBankID1.Text = ""
        cmbBrName.Text = ""
        txtAddress.Text = ""
        txtContactPerson.Text = ""
        txtTel.Text = ""
        'Button1.Text = "Search"
        cmbBank.Focus()
    End Sub

    Private Sub RefreshData()
        txtBankID.Text = Format(GetVal("Select NoBanks from tblControl") + 1, "0#")
        Dim sSQL As String = "Select BankID,BankName from tblbanks where status='0' order by BankID asc"
        Load_InformationtoGrid(sSQL, dgvBank, 2)
        txtBank.Text = ""
        svStatus = "S"
    End Sub

    Private Sub dgvBank_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBank.DoubleClick
        'If UP("Set Banks", "Delete Banks") = False Then Exit Sub
        If dgvBank.RowCount = 0 Then Exit Sub
        txtBankID.Text = dgvBank.CurrentRow.Cells(0).Value.ToString
        txtBank.Text = dgvBank.CurrentRow.Cells(1).Value.ToString
        svStatus = "E"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmbBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBank.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cmbBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedIndexChanged
        FillComboPay(cmbBrName, "Select BranchName from tblBranches where bankID='" & FK_GetID(cmbBank.Text) & "'")
        txtBrID.Text = GetVal("Select BranchID from tblControl") + 1
        cmbBrName.Text = ""
        txtAddress.Text = ""
        txtTel.Text = ""
        txtContactPerson.Text = ""
        Button1.Text = "Search"
    End Sub

    Private Sub cmbBrName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBrName.KeyPress
        cleanInput(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cmbBrName.Text = "" Then MsgBox(" Branch Fields Cannot be Blank Value", MsgBoxStyle.Critical) : cmbBrName.Focus() : Exit Sub
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cmbBrName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrName.SelectedIndexChanged
        'select id from tbl wher bnkid='txtbid' and bname=cmb.text
        sBrIDR = Str(fk_RetString("select BrID from tblBranches where bankid='" & FK_GetID(cmbBank.Text) & "' and branchName='" & cmbBrName.Text & "'"))
        'cmbBank.Text = fk_RetString(" select bankName from tblBanks where bankId='" & txtBankID1.Text & "' ")
        txtBrID.Text = sBrIDR
        Button1_Click(sender, e)
    End Sub

    Private Sub txtAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtAddress.Text = "" Then MsgBox("Address Field Cannot be Blank", MsgBoxStyle.Critical) : txtAddress.Focus() : Exit Sub
            SendKeys.Send("{tab}")

        End If
        If (e.KeyChar = CChar("'")) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTel.KeyPress
        cleanInput(e)
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtContactPerson_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactPerson.KeyPress
        cleanInput(e)
        If e.KeyChar = ChrW(Keys.Enter) Then Call cmdSave_Click(sender, e)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
       
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Button1.Text = "Refresh" Then Call Refresh1() : svStatus = "S" : Button1.Text = "Search" : Exit Sub
        Dim sListbox As New ListBox
        GetMultiVal("Select BrID,Address,Tel,ContactPerson from tblBranches where BankID='" & FK_GetID(cmbBank.Text) & "' and BranchName='" & cmbBrName.Text & "'", sListbox, 4)
        If sListbox.Items.Count = 4 Then
            txtBrID.Text = sListbox.Items(0)
            txtAddress.Text = sListbox.Items(1)
            txtTel.Text = sListbox.Items(2)
            txtContactPerson.Text = sListbox.Items(3)
        End If
        sListbox.Dispose()
        'Button4.Enabled = True
        svStatus = "E"
        Button1.Text = "Refresh"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Set Banks", "Print Branches") = False Then Exit Sub

        StrRepFile = Application.StartupPath & "\Reports\rptBankBranch.rpt"
        StrSelectionFomula = ""
        'cTitle = "Bank / Branches Information"
        'cSubTitle = " "
        frmRepContainerAttn.WindowState = FormWindowState.Maximized
        frmRepContainerAttn.ShowDialog()
        'Dim FS As New frmRepContainer
        'FS.ShowDialog()
        'frmRepContainer.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try

        '    objRpt = New CrystalReport1
        '    Dim cnn As SqlConnection
        '    Dim sql As String
        '    cnn = New SqlConnection(sqlConString)
        '    cnn.Open()
        '    sql = procesSQL()
        '    Dim dscmd As New SqlDataAdapter(sql, cnn)
        '    Dim ds As New DataSet1
        '    dscmd.Fill(ds, "tblPayrollEmployee")
        '    objRpt.SetDataSource(ds.Tables(1))
        '    frmRepContainer.crptView.ReportSource = objRpt
        '    frmRepContainer.crptView.Refresh()
        '    frmRepContainer.ShowDialog()

        '    dscmd.Dispose()
        '    ds.Dispose()
        '    cnn.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        'End Try
        'Dim ds As New DataSet1
        'Dim t As DataTable = ds.Tables.Add("Items")
        't.Columns.Add("RegID", Type.GetType("System.String"))
        't.Columns.Add("Name", Type.GetType("System.String"))
        't.Columns.Add("EpFNo", Type.GetType("System.String"))

        'If FK_ReadDB("Select * from tblPayrollEmployee") = True Then
        '    For X = 0 To frmMain.dgvFillGridforRead.RowCount - 1
        '        For i = 1 To 100
        '            Dim r As DataRow
        '            Dim i As Integer

        '            r = t.NewRow()
        '            r("RegID") = frmMain.dgvFillGridforRead.Item("RegID", X).Value
        '            r("Name") = frmMain.dgvFillGridforRead.Item("DispName", X).Value
        '            r("EpFNo") = frmMain.dgvFillGridforRead.Item("EPFNo", X).Value
        '            t.Rows.Add(r)
        '        Next

        '    Next
        '    For i = 0 To 100000

        '    Next
        'End If

        'Dim objRpt As New CrystalReport1
        'objRpt.SetDataSource(ds.Tables(1))
        'frmRepContainer.crptView.ReportSource = objRpt

        'frmRepContainer.crptView.Refresh()
        'frmRepContainer.ShowDialog()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefrsh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshData()
    End Sub

    Private Sub cmdSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSav.Click
        
        
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Refresh1()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    End Sub

    Public Function FK_QueryRun(ByVal sString As String, ByVal ProcessConformationMessage As Boolean, ByVal ProcessCompletedMessage As Boolean) As Boolean
        If ProcessConformationMessage = True Then
            If MsgBox("Are you sure you want to Start This Process", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Function
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        Dim cmSave As New SqlCommand
        Dim trSave As SqlTransaction
        Dim strStatus As Boolean = False
        Try
            cnSave.Open()
            trSave = cnSave.BeginTransaction
            cmSave = cnSave.CreateCommand
            cmSave.Transaction = trSave
            Dim sqlQRY As String = sString
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            trSave.Commit()
            strStatus = (True)
        Catch ex As Exception

            'trSave.Rollback()
            strStatus = False
            Console.WriteLine(ex.Message)
            If ProcessCompletedMessage = True Then
                If strStatus = False Then MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If

        Finally
            cnSave.Close()
            cmSave.Dispose()
            FK_QueryRun = strStatus
            If ProcessCompletedMessage = True Then
                If strStatus = True Then MsgBox("Process Completed Successfully", MsgBoxStyle.Information)
            End If
        End Try

    End Function

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'If UP("Set Banks", "Add Banks") = False Then Exit Sub
        Dim sSQL As String
        If svStatus = "S" Then
            If txtBank.Text.Trim = "" Then MsgBox("Please Enter the Name of the Bank.") : txtBank.Focus() : Exit Sub
            sSQL = " Insert into tblBanks(BankID,BankName,NoBrs,Status) Values ('" & txtBankID.Text & "','" & txtBank.Text & "','0','0') update tblControl set NoBanks=NoBanks+1"
            FK_QueryRun(sSQL, False, True)
            RefreshData()
        End If
        If svStatus = "E" Then
            sSQL = " update tblBanks set bankName='" & txtBank.Text & "',Status='" & CHKRemove.CheckState & "' where bankid='" & txtBankID.Text & "'"
            FK_QueryRun(sSQL, False, True)
            RefreshData()
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RefreshData()
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'If UP("Set Banks", "Add Branches") = False Then Exit Sub
        If txtAddress.Text = "" Then MsgBox("Address Field Cannot be Blank", MsgBoxStyle.Critical) : txtAddress.Focus() : Exit Sub
        If cmbBrName.Text = "" Then MsgBox(" Branch Fields Cannot be Blank Value", MsgBoxStyle.Critical) : cmbBrName.Focus() : Exit Sub
        If txtAddress.Text = "" Then MsgBox("Address Field Cannot be Blank", MsgBoxStyle.Critical) : txtAddress.Focus() : Exit Sub
        If FK_GetID(cmbBank.Text) = "" Then MsgBox("Please Select Bank from the List", MsgBoxStyle.Information) : Exit Sub
        Dim sSQL As String = ""
        If svStatus = "S" Then
            sSQL = "Insert into tblBranches (BrID,BankID,BranchName,Address,Status,Tel,ContactPerson) values('" & txtBrID.Text & "','" & FK_GetID(cmbBank.Text) & "','" & cmbBrName.Text & "','" & txtAddress.Text & "','0','" & txtTel.Text & "','" & txtContactPerson.Text & "')"
            'FK_QueryRun(sSQL, False, True)
            If FK_EQ(sSQL, "S", "", True, True, True) = True Then
                Refresh1()
            End If
        End If
        If svStatus = "E" Then
            'sSQL = "Update tblBranches set BranchName='" & cmbBrName.Text & "',Address='" & txtAddress.Text & "',tel='" & txtTel.Text & "',Contactperson='" & txtContactPerson.Text & "'"
            sSQL = " update tblBranches set BranchName='" & cmbBrName.Text & "', Address='" & txtAddress.Text & "',Status=0,Tel='" & txtTel.Text & "',ContactPerson='" & txtContactPerson.Text & "' where BrID='" & txtBrID.Text & "' and BankID='" & FK_GetID(cmbBank.Text) & "'"
            FK_EQ(sSQL, "S", "", True, True, True)
        End If
        'FK_QueryRun(sSQL, False, True)
        Refresh1()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Refresh1()
    End Sub
End Class