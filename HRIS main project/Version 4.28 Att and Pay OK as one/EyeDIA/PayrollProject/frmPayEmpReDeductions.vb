Imports System.Data.SqlClient

Public Class frmEmpReDeductions
    Dim strSalItmID As String = ""
    Dim strEmpName As String = ""
    Dim strEmpIDForThis As String = ""
    Dim strSvStatus As String = "S"
    Dim strReqID As String = ""
    Public dtSysWorkingDte As Date
    Dim StrMsgSave As String
    Dim StrMsgModify As String
    'These are globle Variable
    Dim SEmpID As String
    Dim strExsistedAcc As String
    Dim strExsistedBranch As String
    Dim strExsistedBank As String

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        Me.Close()

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)
        ControlHandlers(Me)
        FillComboAll(cmbSalaryitem, "select description+'='+cast(id as char) from tblsalaryItems where status='0' AND isHead=9 order by  description asc ")
        FillComboAll(cmbBank, "select BankName+'='+BankID from tblbanks where status='0' order by BankName asc")
        FillComboAll(cmbBranch, "select distinct[branch] from tblSalDeductReq")

        txtSalDeduID.Text = fk_CreateSerial(4, CInt(fk_RetString("select NoEmpDeduct=NoEmpDeduct + 1 from tblControl")))
        dtpFrom.Text = dtSysWorkingDte
        dtpTo.Text = dtSysWorkingDte
        FillComboAll(cmbReason, "select distinct[reason] from tblsaldeductreq order by reason asc")
        FillComboAll(cmbApprovedBy, "select distinct[approvedby] from tblsaldeductreq order by approvedby asc")
        Dim strQry As String = "SELECT  tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayrollEmployee.dispName as 'Name', dbo.tblSalaryItems.Description as 'Salary Item', dbo.tblSalDeductReq.Amount,  dbo.tblSalDeductReq.BankAccount,dbo.tblSalDeductReq.Bank,   dbo.tblSalDeductReq.Branch ,  dbo.tblSalDeductReq.SlipDes as 'Payslip Des' ,  dbo.tblSalDeductReq.Reason,   dbo.tblSalDeductReq.ApprovedBy,dbo.tblSalDeductReq.FromDate,  dbo.tblSalDeductReq.ToDate, dbo.tblSalDeductReq.SalItmId,tblSalDeductReq.ReqID  FROM          dbo.tblSalDeductReq  INNER JOIN  dbo.tblSalaryItems ON dbo.tblSalDeductReq.SalItmId = dbo.tblSalaryItems.ID  INNER JOIN  dbo.tblpayrollEmployee ON dbo.tblSalDeductReq.EmpID = dbo.tblpayrollEmployee.RegID  where tblSalDeductReq.Status='0' order by ReqID desc"
        Fk_FillGrid(strQry, dgvReq)
        clr_Grid(dgvReq)
        For X = 0 To dgvReq.Columns.Count - 1
            'dgvSearchK.Columns(X).HeaderText = UCase(dgvSearchK.Columns(X).HeaderText)
            dgvReq.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        dgvReq.Columns(1).Visible = False
        lblCount.Text = "Total Employees : " & dgvReq.RowCount

        txtSalDeduID.Focus()
        strSaveStatus = "S"
        dgv.Rows.Clear()

    End Sub

    Private Sub frmSalDeduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''sSQL = "CREATE TABLE [dbo].[tblSalDeductReq](	[ReqID] [varchar](10) not NULL,	[SalItmId] [nvarchar](9) not NULL,	[EmpID] [nvarchar](10) not NULL,	[FromDate] [datetime] NULL,	[ToDate] [datetime] NULL,	[BankAccount] [nvarchar](50)  NULL,	[Branch] [nvarchar](max)  NULL,	[SlipDes] [nvarchar](10)  NULL,	[Amount] [numeric](18, 0) NULL,	[Reason] [nvarchar](max)  NULL,	[ApprovedBy] [nvarchar](max)  NULL,	[Bank] [nvarchar](100)  NULL,	[Status] [decimal](18, 0) NOT NULL DEFAULT ((0)),	[fullsalary] [decimal](1, 0) NOT NULL DEFAULT ((0)))"
        ''EQ(sSQL)
        ''sSQL = "CREATE TABLE [dbo].[tblreqd](	[reqid] [varchar](10) not NULL,	[regid] [varchar](10) not NULL,	[salfield] [decimal](18, 0) NULL,	[insno] [varchar](10) not NULL,	[cYear] [decimal](18, 0) NULL,	[cmonth] [decimal](18, 0) NULL,	[amount] [decimal](18, 0) NULL,	[fullsalary] [decimal](1, 0) NULL,	[sprocess] [varchar](3)  NULL,	[sDeduct] [varchar](3)  NULL,	[BankID] [varchar](100)  NULL,	[BranchID] [varchar](100)  NULL,	[BankAccount] [varchar](100)  NULL,	[description] [varchar](250)  NULL,	[remark] [varchar](250)  NULL,	[status] [decimal](18, 0) NOT NULL DEFAULT ((0)))"
        ''EQ(sSQL)
        CenterFormThemed(Me, Panel3, Label12)
        ControlHandlers(Me)
        txtRegID.Focus()
        cmdRefresh_Click(sender, e)
        Label17.BackColor = clrFocused
    End Sub

    Private Sub txtEmpNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegID.KeyPress
        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtRegID.Text = "" Then txtEpfNo.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEpfNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name: " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation: " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department: " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch: " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company: " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    dtpFrom.Focus()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Sub calc()
        dgv.Rows.Clear()
        Dim sNoofMonths = (-dtpFrom.Value.Year + dtpTo.Value.Year) * 12 + (-dtpFrom.Value.Month + dtpTo.Value.Month) + 1
        Dim cMonth = dtpFrom.Value.Month
        'Exit Sub
        Dim cYear = dtpFrom.Value.Year
        Dim STotalSalary As String
        If CheckBox1.Checked = True Then STotalSalary = "1" Else STotalSalary = "0"
        For X = 1 To sNoofMonths
            dgv.Rows.Add(X, cYear, cMonth, Format(Val(txtAmount.Text), "#0.00"), STotalSalary)
            cMonth = cMonth + 1
            If cMonth = 13 Then cMonth = 1 : cYear = cYear + 1
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            dgv.Rows.Clear()
            If FK_GetIDR(cmbSalaryitem.Text) = "" Then MsgBox("Please select salary item from the list", MsgBoxStyle.Information) : cmbSalaryitem.Focus() : Exit Sub
            Dim sNoofMonths = (-dtpFrom.Value.Year + dtpTo.Value.Year) * 12 + (-dtpFrom.Value.Month + dtpTo.Value.Month) + 1
            Dim cMonth = dtpFrom.Value.Month
            'Exit Sub
            Dim cYear = dtpFrom.Value.Year
            Dim STotalSalary As String
            If CheckBox1.Checked = True Then STotalSalary = "1" Else STotalSalary = "0"
            For X = 1 To sNoofMonths
                dgv.Rows.Add(X, cYear, cMonth, Format(Val(txtAmount.Text), "#0.00"), STotalSalary)
                cMonth = cMonth + 1
                If cMonth = 13 Then cMonth = 1 : cYear = cYear + 1
            Next

            If txtRegID.Text = "" Then : MsgBox("Please select the employee", MsgBoxStyle.Information) : txtRegID.Focus() : Exit Sub : End If
            If cmbSalaryitem.Text = "" Then MsgBox("Please Select Salary Items", MsgBoxStyle.Critical) : cmbSalaryitem.Focus() : Exit Sub
            ' If txtSalID.Text = "" Then txtSalID.Text = fk_RetString("Select ID  from tblSalaryItems where Description='" & cmbSalaryitem.Text & "' ")
            If FK_GetIDR(cmbBank.Text) = "" Then
                Dim dr As DialogResult = MessageBox.Show("Do you want to continue without selecting bank from the list", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                If dr = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
            If FK_GetIDR(cmbBranch.Text) = "" Then
                Dim dr As DialogResult = MessageBox.Show("Do you want to continue without selecting branch from the list", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                If dr = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If
            If dtpTo.Value.Date <= dtSysWorkingDte.Date Then : MsgBox("Please check the date field.", MsgBoxStyle.Information) : Exit Sub : End If
            If (dtpFrom.Value) = dtpTo.Value Then : MsgBox("Both Date from and Date to Field Cannot be Same Date", MsgBoxStyle.Critical) : Exit Sub : End If
            If dtpFrom.Value.Date < dtSysWorkingDte.Date Then : MsgBox("Please check the date field.", MsgBoxStyle.Information) : Exit Sub : End If
            If txtAmount.Text = "" Then : MsgBox("Please enter the amount", MsgBoxStyle.Information) : txtAmount.Focus() : Exit Sub : End If
            If cmbApprovedBy.Text = "" Then : MsgBox("Please enter the approved person", MsgBoxStyle.Information) : cmbApprovedBy.Focus() : Exit Sub : End If
            ' If txtBank.Text = "" Then : MsgBox("Please Select the Bank.") : cmbBank.Focus() : Exit Sub : End If
            If txtPSD.Text = "" Then : MsgBox("Please enter playslip description", MsgBoxStyle.Information) : txtPSD.Focus() : Exit Sub : End If
            If txtBAccount.Text = "" Then : MsgBox("Please enter the account no. ", MsgBoxStyle.Information) : txtBAccount.Focus() : Exit Sub : End If
            If cmbReason.Text = "" Then : MsgBox("Please enter the reason", MsgBoxStyle.Information) : cmbReason.Focus() : Exit Sub : End If
            txtSalDeduID.Text = fk_CreateSerial(4, CInt(fk_RetString("select NoEmpDeduct=NoEmpDeduct + 1 from tblControl")))

            sSQL = "Select SalItmid from tblSalDeductReq where empid='" & txtRegID.Text & "' and SalItmid='" & FK_GetIDR(cmbSalaryitem.Text) & "' and status='0'"
            If fk_CheckEx(sSQL) = True Then MsgBox("Sorry deductions already exists for this employee for this salary componant", MsgBoxStyle.Critical) : Exit Sub
            sSQL = ""
            If Val(dgv.Item(3, 0).Value) <= 0 Then MessageBox.Show("Please check the loan amount again", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
            For X = 0 To dgv.RowCount - 1
                sSQL = sSQL & " insert into tblreqd (reqid,regid,salfield,insno,cyear,cmonth,amount,fullsalary,sprocess,sdeduct,bankid,branchid,bankaccount) " &
                " values ('" & txtSalDeduID.Text & "','" & txtRegID.Text & "','" & FK_GetIDR(cmbSalaryitem.Text) & "','" & dgv.Item(0, X).Value & "','" & dgv.Item(1, X).Value & "','" & dgv.Item(2, X).Value & "','" & dgv.Item(3, X).Value & "','" & dgv.Item(4, X).Value & "','Yes','No','" & FK_GetIDR(cmbBank.Text) & "','" & FK_GetIDR(cmbBranch.Text) & "','" & (txtBAccount.Text) & "');"
            Next
            If UP("Employee Request Deductions", "Add Request Deductions") = False Then Exit Sub
            sSQL = sSQL & " insert into tblsaldeductreq (ReqID,SalItmId,EmpID,FromDate,ToDate,BankAccount,Branch,SlipDes,Amount,Reason,ApprovedBy,Bank)" &
            " values ('" & txtSalDeduID.Text & "','" & FK_GetIDR(cmbSalaryitem.Text) & "','" & txtRegID.Text & "','" & Format(dtpFrom.Value, "yyyyMMdd") & "','" & Format(dtpTo.Value, "yyyyMMdd") & "','" & (txtBAccount.Text) & "','" & FK_GetIDR(cmbBranch.Text) & "','" & txtPSD.Text & "'," & txtAmount.Text & ",'" & cmbReason.Text & "','" & (cmbApprovedBy.Text) & "','" & FK_GetIDR(cmbBank.Text) & "');update tblcontrol set noempdeduct=noempdeduct + 1; "
            If FK_EQ(sSQL, "S", "", True, True, True) = True Then Call cmdRefresh_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Or ((e.KeyChar) = ".") Then
            e.Handled = False
        End If
        If txtAmount.Text.Contains(".") And e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            'If e.KeyChar = ChrW(Keys.Enter) Then
            txtPSD.Focus()
            'End If
        End If
    End Sub




    Private Sub txtBAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbReason.Focus()
            'cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtSalDeduID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalDeduID.KeyPress
        '
    End Sub
    Private Sub cmbSalItems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtRegID.Focus()
        End If
    End Sub
    Private Sub dtpFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFrom.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            dtpTo.Focus()
        End If

    End Sub
    Private Sub dtpTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpTo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtAmount.Focus()
        End If

    End Sub
    Private Sub txtBAccount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBAccount.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbReason.Focus()
        End If
    End Sub
    Private Sub txtBranch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtAmount.Focus()
        End If
    End Sub

    Private Sub cmbReason_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbReason.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbApprovedBy.Focus()
        End If
    End Sub

    Private Sub dtpFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFrom.LostFocus
        dtpFrom.Value = GetFirstDayOfMonth(dtpFrom.Value)
    End Sub

    Sub calcR()
        Try
            dgv.Rows.Clear()
            Dim sNoofMonths = (-dtpFrom.Value.Year + dtpTo.Value.Year) * 12 + (-dtpFrom.Value.Month + dtpTo.Value.Month) + 1
            Dim cMonth = dtpFrom.Value.Month
            Dim cYear = dtpFrom.Value.Year
            Dim STotalSalary As String
            Dim dblTotal As Double = 0
            If CheckBox1.Checked = True Then STotalSalary = "1" Else STotalSalary = "0"

            For X = 1 To sNoofMonths
                dblTotal = dblTotal + Val(txtAmount.Text)
                dgv.Rows.Add(X, cYear, cMonth, Format(Val(txtAmount.Text), "#0.00"), STotalSalary)
                cMonth = cMonth + 1
                If cMonth = 13 Then cMonth = 1 : cYear = cYear + 1
            Next
            Label22.Text = "Installment Shedule : " & dgv.RowCount
            lblTotal.Text = "Total Amount : " & dblTotal
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CalTodate()
        Dim dtBirth As Date = fk_RetDate("SELECT dOfB from tblemployee where regID='" & txtRegID.Text & "'")
        'dtpFrom.Value = dtBirth
        Dim dtNewDate As Date = DateAdd(DateInterval.Year, 60, dtBirth)
        dtpTo.Value = dtNewDate
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        calcR()
        CalTodate()
    End Sub

    Private Sub dtpTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpTo.LostFocus
        dtpTo.Value = GetLastDayOfMonth(dtpTo.Value)
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        calcR()
    End Sub

    Private Sub txtBAccount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBAccount.TextChanged

    End Sub

    '' '' ''Private Sub cmbApprovedBy_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbApprovedBy.GotFocus
    '' '' ''    SendKeys.SendWait("{F4}")
    '' '' ''End Sub

    Private Sub cmbApprovedBy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbApprovedBy.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub txtAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        txtAmount.Text = Format(Val(txtAmount.Text), "#.00")
    End Sub

    '' '' ''Private Sub cmbBank_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBank.GotFocus
    '' '' ''    SendKeys.SendWait("{F4}")
    '' '' ''End Sub


    Private Sub cmbBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBank.KeyPress, cmbSalaryitem.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbBranch.Focus()
        End If
    End Sub

    Private Sub cmbBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBank.SelectedIndexChanged

        'txtBank.Text = fk_RetString("Select BankID from tblBanks where BankName='" & cmbBank.Text & "'")
        FillComboAll(cmbBranch, "select BranchName+'='+BrID from tblBranches where bankid='" & FK_GetIDR(cmbBank.Text) & "' and status='0' order by BranchName asc")
    End Sub

    '' '' ''Private Sub cmbBranch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBranch.GotFocus
    '' '' ''    SendKeys.SendWait("{F4}")
    '' '' ''End Sub

    Private Sub cmbBranch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbBranch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtBAccount.Focus()
        End If
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        'txtBranch.Text = fk_RetString("Select BrID from tblBranches where BranchName='" & cmbBranch.Text & "' and BankID='" & txtBank.Text & "'")
    End Sub

    Private Sub txtPSD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPSD.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbBank.Focus()
        End If
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sSQL, sSQL1 As String
        sSQL1 = " Request ID : " & dgvReq.Item(0, dgvReq.CurrentRow.Index).Value
        sSQL = "Delete from tblsaldeductreq where ReqID='" & dgvReq.Item(0, dgvReq.CurrentRow.Index).Value & "'"

        FK_EQ(sSQL, "D", "", sSQL1, True, True)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"
        sSQL = "SELECT  dbo.tblPayrollEmployee.RegID, RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' ,dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where tblPayrollEmployee.status=0 and  tblPayrollEmployee.SalViewLevel<=" & UserVal & " or tblPayrollEmployee.SalViewLevel is null order by " & strQuery & ""
        If FK_Br(sSQL) = True Then
            txtRegID.Text = frmMainAttendance.dgvFillGridforRead.Item(0, 0).Value
        End If

        If txtRegID.Text = "" Then Exit Sub

        sSQL = "SELECT dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEpfNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation" & vbTab & ": " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department" & vbTab & ": " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    dtpFrom.Value = Now.Date
                    CalTodate()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()

    End Sub

    Private Sub txtEpfNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEpfNo.KeyPress
        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtEpfNo.Text = "" Then txtEmpNo.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.epfno = '" & txtEpfNo.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.epfno = '" & txtEpfNo.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEpfNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name: " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation: " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department: " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch: " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company: " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    dtpFrom.Focus()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Private Sub txtEmpNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpNo.KeyPress
        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtEmpNo.Text = "" Then txtRegID.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.empNo = '" & txtEmpNo.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.empno = '" & txtEmpNo.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEpfNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name: " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation: " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department: " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch: " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company: " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    dtpFrom.Focus()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Private Sub cmbSalaryitem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSalaryitem.SelectedIndexChanged
        txtSalID.Text = fk_RetString("Select ID  from tblSalaryItems where Description='" & cmbSalaryitem.Text & "' ")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Try
        '    sSQL = "SELECT     dbo.tblSalDeductReq.ReqID, dbo.tblSalaryItems.Description as 'Salary Item',tblPayrollEmployee.RegID,tblPayrollEmployee.EpfNo,tblPayrollEmployee.EmpNo,  dbo.tblPayrollEmployee.dispName as 'Name',   dbo.tblSalDeductReq.BankAccount,   dbo.tblSalDeductReq.Branch ,  dbo.tblSalDeductReq.SlipDes as 'Payslip Des' ,  dbo.tblSalDeductReq.Reason,   dbo.tblSalDeductReq.ApprovedBy,  dbo.tblSalDeductReq.Amount,   dbo.tblSalDeductReq.FromDate,  dbo.tblSalDeductReq.ToDate, dbo.tblSalDeductReq.SalItmId  FROM          dbo.tblSalDeductReq  INNER JOIN  dbo.tblSalaryItems ON dbo.tblSalDeductReq.SalItmId = dbo.tblSalaryItems.ID  INNER JOIN  dbo.tblpayrollEmployee ON dbo.tblSalDeductReq.EmpID = dbo.tblpayrollEmployee.RegID  where tblSalDeductReq.Status='0' order by ReqID desc"
        '    'Procedure Use to Fill Dataset
        '    Dim ds As New DST_Report
        '    Dim t As DataTable = ds.Tables(0) '.Add("Datatable1")
        '    'For X = 0 To ds.Tables(0).Columns.Count - 1
        '    '    MsgBox(ds.Tables(0).Columns(X).ColumnName)
        '    'Next
        '    If FK_ReadDB(sSQL) = True Then
        '        Dim r As DataRow
        '        For X = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
        '            r = t.NewRow()
        '            For Y = 0 To frmMainAttendance.dgvFillGridforRead.Columns.Count - 1
        '                Dim sColumn = frmMainAttendance.dgvFillGridforRead.Columns(Y).HeaderText
        '                Dim sValue = frmMainAttendance.dgvFillGridforRead.Item(Y, X).Value
        '                r.Item(Y) = sValue
        '            Next
        '            t.Rows.Add(r)
        '        Next
        '    End If
        '    'End Procedure

        '    Dim objRpt As New Rpt_EmpReqDed '- Report Files name here 
        '    objRpt.SetDataSource(ds.Tables(0)) ' - Data Set Table Name Here 
        '    objRpt.SetParameterValue("1", cBusiness)
        '    objRpt.SetParameterValue("2", cAddress)
        '    objRpt.SetParameterValue("3", "Current Employee Request Deductions")
        '    objRpt.SetParameterValue("4", "")
        '    frmRepContainer.crptView.ReportSource = objRpt
        '    frmRepContainer.crptView.Refresh()
        '    frmRepContainer.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        'Try
        '    dgv.Rows.Clear()
        '    Dim sNoofMonths = (-dtpFrom.Value.Year + dtpTo.Value.Year) * 12 + (-dtpFrom.Value.Month + dtpTo.Value.Month) + 1
        '    Dim cMonth = dtpFrom.Value.Month
        '    Dim cYear = dtpFrom.Value.Year
        '    Dim STotalSalary As String
        '    If CheckBox1.Checked = True Then STotalSalary = "1" Else STotalSalary = "0"

        '    For X = 1 To sNoofMonths
        '        dgv.Rows.Add(X, cYear, cMonth, Format(Val(txtAmount.Text), "#0.00"), STotalSalary)
        '        cMonth = cMonth + 1
        '        If cMonth = 13 Then cMonth = 1 : cYear = cYear + 1
        '    Next

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        calcR()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        'Try
        '    dgv.Rows.Clear()
        '    Dim sNoofMonths = (-dtpFrom.Value.Year + dtpTo.Value.Year) * 12 + (-dtpFrom.Value.Month + dtpTo.Value.Month) + 1
        '    Dim cMonth = dtpFrom.Value.Month
        '    Dim cYear = dtpFrom.Value.Year
        '    Dim STotalSalary As String
        '    If CheckBox1.Checked = True Then STotalSalary = "1" Else STotalSalary = "0"
        '    Dim dblTotal As Double = 0
        '    For X = 1 To sNoofMonths
        '        dblTotal = dblTotal + Val(txtAmount.Text)
        '        dgv.Rows.Add(X, cYear, cMonth, Format(Val(txtAmount.Text), "#0.00"), STotalSalary)
        '        cMonth = cMonth + 1
        '        If cMonth = 13 Then cMonth = 1 : cYear = cYear + 1
        '    Next
        '    Label22.Text = "Installment Shedule : " & dgv.RowCount
        '    lblTotal.Text = "Total Amount : " & dblTotal
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        calcR()
    End Sub

    Private Sub dgvReq_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReq.CellClick
        'strSvStatus = "E"
        'txtSalDeduID.Text=
        'cmbSalaryitem.Text=
        'txtRegID.Text=
        'txtEpfNo.Text=
        'txtEmpNo.Text=
        'txtDetails.Text=
        'dtpFrom.Value=
        'dtpTo.Value=
        'txtAmount.Text=
        'txtPSD.Text=
        'CheckBox1.CheckState=
        'cmbApprovedBy.Text=

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LoadForm(New frmPayBanks)
        'FillComboAll(cmbBank, "select BankName+'='+BankID from tblbanks where status='0' order by BankName asc")
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LoadForm(New frmPayBanks1)
        'FillComboAll(cmbBank, "select BankName+'='+BankID from tblbanks where status='0' order by BankName asc")
    End Sub

    Private Sub dgvReq_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReq.CellDoubleClick
        txtBAccount.Text = Trim(dgvReq.CurrentRow.Cells(5).Value)
        strExsistedAcc = txtBAccount.Text
        txtSalDeduID.Text = Trim(dgvReq.CurrentRow.Cells(14).Value)
        txtRegID.Text = Trim(dgvReq.CurrentRow.Cells(0).Value)
        Dim strBank As String = Trim(dgvReq.CurrentRow.Cells(6).Value)
        sSQL = "select BankName+'='+BankID from tblBanks WHERE BankID='" & strBank & "'"
        cmbBank.Text = GetString(sSQL)
        strExsistedBank = cmbBank.Text
        Dim strBranch As String = Trim(dgvReq.CurrentRow.Cells(7).Value)
        cmbBranch.Text = GetString("select BranchName+'='+BRID  from tblBranches WHERE BrID='" & strBranch & "' and BankID='" & strBank & "'")
        strExsistedBranch = cmbBranch.Text
    End Sub

    Private Sub PictureBox22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAccount.Click
        If Trim(txtBAccount.Text) = strExsistedAcc Then
            MessageBox.Show("Please do the changes to account number to save, There is no any different between previous one and current one", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtBAccount.Focus() : Exit Sub
        End If

        sSQL = "UPDATE tblsaldeductreq SET BankAccount='" & txtBAccount.Text & "' WHERE EmpID='" & txtRegID.Text & "' and ReqID='" & txtSalDeduID.Text & "' ;"
        sSQL = sSQL & "UPDATE tblreqd SET BankAccount='" & txtBAccount.Text & "' WHERE regID='" & txtRegID.Text & "' and ReqID='" & txtSalDeduID.Text & "' ;"
        sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'Request deduction','Change account number from " & strExsistedAcc & " to  " & txtBAccount.Text & " and Employee ID is " & txtRegID.Text & "','" & StrUserID & "',0,'" & txtRegID.Text & "')"
        FK_EQ(sSQL, "E", "", True, True, True)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub pbBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBranch.Click
        If cmbBranch.Text = strExsistedBranch Then
            MessageBox.Show("Please do the changes to branch to save, There is no any different between previous one and current one", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtBAccount.Focus() : Exit Sub
        End If

        sSQL = "UPDATE tblsaldeductreq SET Branch='" & FK_GetIDR(cmbBranch.Text) & "' WHERE EmpID='" & txtRegID.Text & "' and ReqID='" & txtSalDeduID.Text & "' ;"
        sSQL = sSQL & "UPDATE tblreqd SET BranchID='" & FK_GetIDR(cmbBranch.Text) & "' WHERE regID='" & txtRegID.Text & "' and ReqID='" & txtSalDeduID.Text & "' ;"
        sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'Request deduction','Change b-branch from " & strExsistedBranch & " to  " & cmbBranch.Text & " and Employee ID is " & txtRegID.Text & "','" & StrUserID & "',0,'" & txtRegID.Text & "')"
        FK_EQ(sSQL, "E", "", True, True, True)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub pbBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBank.Click
        If cmbBank.Text = strExsistedBank Then
            MessageBox.Show("Please do the changes to bank to save, There is no any different between previous one and current one", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtBAccount.Focus() : Exit Sub
        End If

        sSQL = "UPDATE tblsaldeductreq SET Bank='" & FK_GetIDR(cmbBank.Text) & "' WHERE EmpID='" & txtRegID.Text & "' and ReqID='" & txtSalDeduID.Text & "' ;"
        sSQL = sSQL & "UPDATE tblreqd SET BankID='" & FK_GetIDR(cmbBank.Text) & "' WHERE regID='" & txtRegID.Text & "' and ReqID='" & txtSalDeduID.Text & "' ;"
        sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'Request deduction','Change bank from " & strExsistedBank & " to  " & cmbBank.Text & " and Employee ID is " & txtRegID.Text & "','" & StrUserID & "',0,'" & txtRegID.Text & "')"
        FK_EQ(sSQL, "E", "", True, True, True)
        cmdRefresh_Click(sender, e)
    End Sub

End Class