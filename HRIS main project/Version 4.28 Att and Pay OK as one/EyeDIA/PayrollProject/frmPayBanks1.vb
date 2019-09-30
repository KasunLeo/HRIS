Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmBanks1

    Public svStatus As String = "S"
    Dim sBrIDR As String
    Dim intAID As Integer
    Dim strSelBank As String
    Dim cTitle As String
    Dim cSubTitle As String

    'Dim objRpt As CrystalReport1
    Private Sub frmBanks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
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
        If UP("Set Banks", "Add Banks") = False Then Exit Sub
        cleanInput(e)
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSav_Click(sender, e)

        End If
    End Sub
    Private Sub Refresh1()
        Dim sSQL As String = "Select tblbanks.ID,tblbanks.BankID,tblbanks.BankName,tblbanks.HOB from tblbanks WHERE status=0 ORDER BY bankID"
        Load_InformationtoGrid(sSQL, dgvforBranch, 4)

        ''FillComboAll(cmbBank, "Select BankName+'-'+BankID from tblBanks where status='0' order by BankName asc")
        'txtBrID.Text = GetVal("Select BranchID from tblControl") + 1
        txtBrID.Text = ""
        ' txtBankID1.Text = ""
        cmbBrName.Text = ""
        txtAddress.Text = ""
        txtContactPerson.Text = ""
        txtTel.Text = ""
        'Button1.Text = "Search"
        strSaveStatus = "S"
    End Sub
    Private Sub RefreshData()
        'txtBankID.Text = Format(GetVal("Select NoBanks from tblControl") + 1, "0#")
        Dim sSQL As String = "Select tblbanks.ID,tblbanks.BankID,tblbanks.BankName,tblBranches.BranchName+'='+tblBranches.BrID from tblbanks LEFT OUTER JOIN tblBranches ON tblBranches.BankID=tblBanks.BankID and tblBranches.brID=tblBanks.HOB WHERE  tblbanks.status='0' order by tblBanks.bankName,tblBranches.BranchName asc"
        Load_InformationtoGrid(sSQL, dgvBank, 4)
        txtBank.Text = ""
        txtAutID.Enabled = False
        txtBankID.Text = GetVal("Select max(id) from tblbanks") + 1
        txtAutID.Text = txtBankID.Text
        cmbBBranch.Text = ""
        svStatus = "S"
    End Sub

    Private Sub dgvBank_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBank.DoubleClick
        If UP("Set Banks", "Delete Banks") = False Then Exit Sub
        If dgvBank.RowCount = 0 Then Exit Sub
        intAID = dgvBank.CurrentRow.Cells(0).Value
        txtAutID.Text = intAID
        txtBankID.Text = dgvBank.CurrentRow.Cells(1).Value.ToString
        txtBank.Text = dgvBank.CurrentRow.Cells(2).Value.ToString
        'Dim strBrID As String = dgvBank.CurrentRow.Cells(3).Value.ToString

        'sSQL = "select brID+'='+BranchName from tblBranches where bankid='" & txtBankID.Text & "' and brID='" & strBrID & "'"
        cmbBBranch.Text = dgvBank.CurrentRow.Cells(3).Value.ToString
        svStatus = "E"
        FillComboAll(cmbBBranch, "Select BranchName+'='+brID from tblBranches where bankID='" & txtBankID.Text & "' ORDER BY BranchName")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub cmbBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    'Private Sub cmbBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FillComboAll(cmbBrName, "Select BranchName+'='+brID from tblBranches where bankID='" & FK_GetID(cmbBank.Text) & "' ORDER BY BranchName")
    '    'cmbBrName.SelectedIndex = 0

    '    'txtBrID.Text = GetVal("Select BranchID from tblControl") + 1
    '    cmbBrName.Text = ""
    '    txtAddress.Text = ""
    '    txtTel.Text = ""
    '    txtContactPerson.Text = ""
    '    txtBrID.Text = ""
    '    txtABID.Text = ""
    '    'Button1.Text = "Search"

    'End Sub

    Private Sub cmbBrName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBrName.KeyPress
        'cleanInput(e)
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    If cmbBrName.Text = "" Then MsgBox(" Branch Fields Cannot be Blank Value", MsgBoxStyle.Critical) : cmbBrName.Focus() : Exit Sub
        '    SendKeys.Send("{tab}")
        'End If
    End Sub

    Private Sub cmbBrName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBrName.SelectedIndexChanged
        'select id from tbl wher bnkid='txtbid' and bname=cmb.text

        sBrIDR = FK_GetIDR(cmbBrName.Text) ' & "' 'Str(fk_RetString("select BrID from tblBranches where bankid='" & FK_GetID(cmbBank.Text) & "' and branchName='" & cmbBrName.Text & "'"))
        'cmbBank.Text = fk_RetString(" select bankName from tblBanks where bankId='" & txtBankID1.Text & "' ")
        txtBrID.Text = sBrIDR
        strSaveStatus = "E"
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

    Private Sub txtAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private Sub txtTel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTel.KeyPress
        cleanInput(e)

        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")

    End Sub

    Private Sub txtTel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTel.TextChanged

    End Sub

    Private Sub txtContactPerson_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactPerson.KeyPress
        cleanInput(e)

        If e.KeyChar = ChrW(Keys.Enter) Then Call cmdSave_Click(sender, e)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Set Banks", "Add Branches") = False Then Exit Sub
        If txtAddress.Text = "" Then MsgBox("Address Field Cannot be Blank", MsgBoxStyle.Critical) : txtAddress.Focus() : Exit Sub
        If cmbBrName.Text = "" Then MsgBox(" Branch Fields Cannot be Blank Value", MsgBoxStyle.Critical) : cmbBrName.Focus() : Exit Sub
        If txtAddress.Text = "" Then MsgBox("Address Field Cannot be Blank", MsgBoxStyle.Critical) : txtAddress.Focus() : Exit Sub
        'If FK_GetID(cmbBank.Text) = "" Then MsgBox("Please Select Bank from the List", MsgBoxStyle.Information) : Exit Sub
        Dim sSQL As String = ""
        If svStatus = "S" Then
            sSQL = "SELECT Brid FROM tblBranches WHERE brid='" & txtBrID.Text & "' and BankID='" & strSelBank & "'"
            If fk_CheckEx(sSQL) = True Then
                MessageBox.Show("This branch ID is already exsist in database", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            sSQL = "Insert into tblBranches (BrID,BankID,BranchName,Address,Status,Tel,ContactPerson) values('" & txtBrID.Text & "','" & strSelBank & "','" & cmbBrName.Text & "','" & txtAddress.Text & "','0','" & txtTel.Text & "','" & txtContactPerson.Text & "')"
            'FK_QueryRun(sSQL, False, True)
            If FK_EQ(sSQL, "S", "", True, True, True) = True Then
                Refresh1()
            End If
        End If
        If svStatus = "E" Then

            'sSQL = "Update tblBranches set BranchName='" & cmbBrName.Text & "',Address='" & txtAddress.Text & "',tel='" & txtTel.Text & "',Contactperson='" & txtContactPerson.Text & "'"
            sSQL = " update tblBranches set BranchName='" & FK_GetIDL(cmbBrName.Text) & "', Address='" & txtAddress.Text & "',Status=0,Tel='" & txtTel.Text & "',ContactPerson='" & txtContactPerson.Text & "',BrID='" & txtBrID.Text & "' where aID='" & txtABID.Text & "' and BankID='" & strSelBank & "'"
            FK_EQ(sSQL, "E", "", True, True, True)
        End If
        'FK_QueryRun(sSQL, False, True)
        Refresh1()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'If Button1.Text = "Refresh" Then Call Refresh1() : svStatus = "S" : Button1.Text = "Search" : Exit Sub
            Dim sListbox As New ListBox
            sSQL = "Select BrID,Address,Tel,ContactPerson,aID from tblBranches where BankID='" & strSelBank & "' and brID='" & FK_GetIDR(cmbBrName.Text) & "'"
            GetMultiVal(sSQL, sListbox, 5)
            If sListbox.Items.Count = 5 Then
                txtBrID.Text = sListbox.Items(0)
                txtAddress.Text = sListbox.Items(1)
                txtTel.Text = sListbox.Items(2)
                txtContactPerson.Text = sListbox.Items(3)
                txtABID.Text = sListbox.Items(4)
                svStatus = "E"
                'Button1.Text = "Refresh"
            End If
            sListbox.Dispose()
            'Button4.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If UP("Set Banks", "Print Branches") = False Then Exit Sub

        StrRepFile = Application.StartupPath & "\Reports\rptBankBranch.rpt"
        StrSelectionFomula = ""
        cTitle = "Bank / Branches Information"
        cSubTitle = " "
        frmRepContainer.WindowState = FormWindowState.Maximized
        frmRepContainer.ShowDialog()
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

        If UP("Set Banks", "Add Banks") = False Then Exit Sub
        If txtBank.Text = "" Then MessageBox.Show("Please type bank name", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        Dim sSQL As String
        If svStatus = "S" Then

            'sSQL = "SELECT COUNT(bankID) FROM tblBanks" : intID = fk_sqlDbl(sSQL)
            sSQL = "SELECT BankID FROM tblBanks WHERE BankID='" & txtBankID.Text & "'"
            If fk_CheckEx(sSQL) = True Then
                MessageBox.Show("This bank is already exsist in database", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            If txtBank.Text.Trim = "" Then MsgBox("Please Enter the Name of the Bank.") : txtBank.Focus() : Exit Sub
            sSQL = "Insert into tblBanks(BankID,BankName,NoBrs,Status,HOB) Values ('" & txtBankID.Text & "','" & txtBank.Text & "','0','0','" & FK_GetIDR(cmbBBranch.Text) & "'); update tblControl set NoBanks=NoBanks+1"
            FK_QueryRun(sSQL, False, True)
            RefreshData()
        End If

        If svStatus = "E" Then
            sSQL = " update tblBanks set bankName='" & txtBank.Text & "',Status='" & CHKRemove.CheckState & "',bankid='" & txtBankID.Text & "',HOB='" & FK_GetIDR(cmbBBranch.Text) & "'  where ID=" & intAID & ""
            FK_QueryRun(sSQL, False, True)
            RefreshData()
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Refresh1()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Refresh1()
    End Sub

    Private Sub txtBankID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBankID.LostFocus
        FillComboAll(cmbBBranch, "Select BranchName+'='+brID from tblBranches where bankID='" & txtBankID.Text & "' ORDER BY BranchName")

    End Sub

    Private Sub dgvforBranch_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvforBranch.DoubleClick
        If dgvforBranch.RowCount = 0 Then Exit Sub
        txtABID.Text = dgvforBranch.CurrentRow.Cells(0).Value
        strSelBank = dgvforBranch.CurrentRow.Cells(1).Value
        FillComboAll(cmbBrName, "Select BranchName+'='+brID from tblBranches where bankID='" & strSelBank & "' ORDER BY BranchName")
        svStatus = "S"
    End Sub

End Class