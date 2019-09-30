Imports System.Data.SqlClient

Public Class frmPayWorkingAllowances

    Dim SEmpID As String

    Private Sub frmWorkingAllowances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label4)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
        If StrEmployeeID <> "" Then
            txtRegID.Text = StrEmployeeID
            ViewEmployeeInfo()
            StrEmployeeID = ""
        End If
    End Sub

    Private Sub txtRegID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRegID.GotFocus

        txtRegID.SelectAll()

    End Sub

    Private Sub txtEmpID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegID.KeyPress

        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtRegID.Text = "" Then txtEmpNo.Focus() : Exit Sub
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
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation" & vbTab & ": " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department" & vbTab & ": " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                    txtRegID.ReadOnly = True
                End While
            Else
                txtRegID.ReadOnly = False
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()

    End Sub

    Private Sub LoadGrid()

        'Dim SQL As String = "SELECT     TOP (100)  dbo.tblWorkingAllowances.EmpID, dbo.tblEmployee.epfNo,dbo.tblEmployee.dispName, dbo.tblWorkingAllowances.Amount, dbo.tblWorkingAllowances.ID FROM         dbo.tblWorkingAllowances INNER JOIN                       dbo.tblEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblEmployee.RegID WHERE     (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") AND (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ")  ORDER BY dbo.tblWorkingAllowances.EmpID"
        'Load_InformationtoGrid(SQL, grdData, 5)

    End Sub

    Private Sub txtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then
            cboMonth.Focus()
        End If

    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim SQL As String = ""
        SQL = "SELECT     dbo.tblWorkingAllowances.EmpID,dbo.tblEmployee.epfNo, dbo.tblEmployee.dispName, dbo.tblWorkingAllowances.Amount, dbo.tblWorkingAllowances.ID, dbo.tblWorkingAllowances.cYear,          dbo.tblWorkingAllowances.cMonth, dbo.tblSalaryItems.Description, dbo.tblWorkingAllowances.Salaryitem FROM         dbo.tblWorkingAllowances INNER JOIN                       dbo.tblEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblEmployee.RegID CROSS JOIN         dbo.tblSalaryItems WHERE     (dbo.tblWorkingAllowances.cYear ='" & txtYear.Text & "')" ' AND (dbo.tblWorkingAllowances.cMonth = N'CM') AND (dbo.tblWorkingAllowances.Salaryitem = N'SI')
        Load_InformationtoGrid(SQL, grdData, 8)
        clr_Grid(grdData)
        lblCounteka.Text = "Total Rows : " & grdData.RowCount
    End Sub

    Private Sub cboMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboMonth.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            cboSalaryItem.Focus()
        End If

    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged

        If txtitemID.Text = "" Then Exit Sub
        Dim SQL As String = "SELECT       dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo,dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount, dbo.tblWorkingAllowances.ID FROM         dbo.tblWorkingAllowances INNER JOIN                       dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID WHERE     (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") AND (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ") AND (dbo.tblWorkingAllowances.Salaryitem = " & txtitemID.Text & ") ORDER BY dbo.tblWorkingAllowances.EmpID"
        Load_InformationtoGrid(SQL, grdData, 5)
        clr_Grid(grdData)
        lblCounteka.Text = "Total Rows : " & grdData.RowCount
    End Sub

    Private Sub cboSalaryItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboSalaryItem.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            txtRegID.Focus()
        End If

    End Sub

    Private Sub cboSalaryItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalaryItem.SelectedIndexChanged

        sSQL = "SELECT     dbo.tblWorkingAllowances.ID, dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo, " & _
" dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount ,tblWorkingAllowances.cyear,tblWorkingAllowances.cmonth,'', tblSalaryitems.description FROM         " & _
" dbo.tblWorkingAllowances INNER JOIN    dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID " & _
" inner join tblSalaryItems on tblWorkingAllowances.salaryItem=tblsalaryitems.id where (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") and " & _
" (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ") and (dbo.tblWorkingAllowances.Salaryitem = " & FK_GetIDR(cboSalaryItem.Text) & ") " & _
"  and tblWorkingAllowances.status='0' ORDER BY dbo.tblWorkingAllowances.ID Desc "
        Load_InformationtoGrid(sSQL, grdData, 10)
        clr_Grid(grdData)
        lblCounteka.Text = "Total Rows : " & grdData.RowCount
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        If UP("Monthly Allowances", "Add/Edit Monthly Allowance Amount") = False Then Exit Sub
        If txtRegID.Text = "" Then MsgBox("Invalid Reg ID", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub
        ' txtEmpName.Text = GetString("Select DispName from tblemployee where regid='" & txtEmpID.Text & "'")
        ' If txtEmpName.Text = "" Then MsgBox("Invalid Employee ID", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub
        If Val(txtAmount.Text) = 0 Then MsgBox("Invalid Amount", MsgBoxStyle.Critical) : txtAmount.Focus() : txtAmount.SelectAll() : Exit Sub
        If FK_GetIDR(cboSalaryItem.Text) = "" Then MsgBox("Invalid salary Items", MsgBoxStyle.Critical) : cboSalaryItem.Focus() : Exit Sub
        Dim strID As String = GetVal("Select WAID from tblControl")
        'Kasun
        If strID = "" Then MsgBox("Invalid ID", MsgBoxStyle.Critical) : txtRegID.Focus() : Exit Sub

        sSQL = "select amount from tblWorkingAllowances WHERE tblWorkingAllowances.EmpID='" & Trim(txtRegID.Text) & "' AND tblWorkingAllowances.salaryItem='" & FK_GetIDR(cboSalaryItem.Text) & "' AND tblWorkingAllowances.cYear =" & txtYear.Text & " and tblWorkingAllowances.cMonth = " & cboMonth.Text & ""

        If fk_CheckEx(sSQL) = True Then
            Dim strOldAmount As String = fk_RetString(sSQL)
            sSQL = ""
            Dim dr As DialogResult = MessageBox.Show("There is an amount of :  " & strOldAmount & " for :  " & FK_GetIDL(cboSalaryItem.Text) & " in database, Do you want to replace it with new amount?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            If dr = Windows.Forms.DialogResult.Yes Then
                sSQL = "UPDATE tblWorkingAllowances SET Amount=" & txtAmount.Text & " WHERE tblWorkingAllowances.EmpID='" & Trim(txtRegID.Text) & "' AND tblWorkingAllowances.salaryItem='" & FK_GetIDR(cboSalaryItem.Text) & "' AND tblWorkingAllowances.cYear =" & txtYear.Text & " and tblWorkingAllowances.cMonth = " & cboMonth.Text & "; INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'FrmWorkingAllowances','Updated working allowance field of regID : " & txtRegID.Text & " epfNO : " & txtEPFNo.Text & " Old Amount : " & strOldAmount & " New Amount : " & Val(txtAmount.Text) & "  Year : " & txtYear.Text & " Month :  " & cboMonth.Text & " salary Item  : " & cboSalaryItem.Text & "','" & StrUserID & "',0,'" & Trim(txtRegID.Text) & "')"
            End If

        Else
            sSQL = " Insert into tblWorkingAllowances (ID,cYear,cMonth,SalaryItem,EmpID,Amount,UserID) values ('" & strID & "','" & txtYear.Text & "','" & cboMonth.Text & "','" & FK_GetIDR(cboSalaryItem.Text) & "','" & txtRegID.Text & "'," & txtAmount.Text & ",'" & StrUserID & "') ; INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'FrmWorkingAllowances','Inserted working allowance field of regID : " & txtRegID.Text & " epfNO : " & txtEPFNo.Text & " Amount : " & Val(txtAmount.Text) & " Year : " & txtYear.Text & " Month :  " & cboMonth.Text & " salary Item  : " & cboSalaryItem.Text & "','" & StrUserID & "',0,'" & Trim(txtRegID.Text) & "')" &
                            " ; update tblControl set WAID=WAID+1"
        End If

        If FK_EQ(sSQL, "S", "", False, True, True) = True Then
            txtRegID.ReadOnly = True

            Dim SQL As String
            SQL = "SELECT    dbo.tblWorkingAllowances.ID, dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo, " &
" dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount ,tblWorkingAllowances.cyear,tblWorkingAllowances.cmonth,'', tblSalaryitems.description FROM         " &
" dbo.tblWorkingAllowances INNER JOIN    dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID " &
" inner join tblSalaryItems on tblWorkingAllowances.salaryItem=tblsalaryitems.id where (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") and " &
" (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ") and (dbo.tblWorkingAllowances.Salaryitem = " & FK_GetIDR(cboSalaryItem.Text) & ") " &
"  and tblWorkingAllowances.status='0' ORDER BY dbo.tblWorkingAllowances.ID Desc "
            Load_InformationtoGrid(SQL, grdData, 10)
            clr_Grid(grdData)
            lblCounteka.Text = "Total Rows : " & grdData.RowCount
            '' '' ''Dim SQL As String = "SELECT     TOP (100)  dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo, " & _
            '' '' ''" dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount, dbo.tblWorkingAllowances.ID FROM  " & _
            '' '' ''" dbo.tblWorkingAllowances INNER JOIN  dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID WHERE  " & _
            '' '' ''" (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") AND (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ") AND " & _
            '' '' ''" (dbo.tblWorkingAllowances.Salaryitem = " & txtitemID.Text & ") And (tblWorkingAllowances.status=0) ORDER BY dbo.tblWorkingAllowances.ID " & _
            '' '' ''" Desc"
            '' '' ''Load_InformationtoGrid(SQL, grdData, 6)
            txtRegID.Focus() : txtRegID.SelectAll()
            txtAmount.Text = ""
        Else
            'MsgBox("Data Saved Failed", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    '' '' ''Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
    '' '' ''    MsgBox("OK")
    '' '' ''End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If UP("Set Monthly Basis Allowances", "Delete Added Allowances.Deductions") = False Then Exit Sub

        'Save Procedure
        Dim srt1 As String = "Are you Sure you want to Delete this Employees Record? " & grdData.Item(0, grdData.CurrentRow.Index).Value
        If MsgBox(srt1, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sqlCMD As New SqlCommand
            sqlCMD = dbSqlCon.CreateCommand
            Dim strQRY As String = "Delete from tblWorkingAllowances where ID='" & grdData.Item(4, grdData.CurrentRow.Index).Value & "'"
            sqlCMD.CommandText = strQRY
            sqlCMD.ExecuteNonQuery()
            MsgBox("Data Deleted Successfully", MsgBoxStyle.Information)
            LoadGrid()
        End If

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Try
        '    sSQL = "SELECT     tblPayrollEmployee.RegID,tblPayrollEmployee.EpfNo,tblPayrollEmployee.EMPNo, tblPayrollEmployee.DispName,tblWorkingAllowances.SalaryItem,tblSalaryitems.Description,tblWorkingAllowances.Amount,tblWorkingAllowances.UserID,tblDesig.desgDesc,tblSetDept.DeptName, tblCBranchs.BrName, tblCompany.cName  FROM         dbo.tblworkingallowances inner join tblPayrollemployee on  tblworkingallowances.EmpID=tblPayrollemployee.RegID inner join tblSalaryitems on tblworkingallowances.Salaryitem=tblSalaryItems.ID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID  LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID  LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID  LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID  where tblWorkingAllowances.cYear='" & txtYear.Text & "' and tblworkingallowances.cmonth='" & cboMonth.Text & "' and tblworkingallowances.status='0' order by tblworkingallowances.id asc "
        '    'Procedure Use to Fill Dataset
        '    Dim ds As New DSMonAllDed
        '    Dim t As DataTable = ds.Tables(0) '.Add("Datatable1")
        '    If FK_ReadDB(sSQL) = True Then
        '        Dim r As DataRow
        '        For X = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
        '            r = t.NewRow()
        '            For Y = 0 To frmMainAttendance.dgvFillGridforRead.Columns.Count - 1
        '                Dim sColumn = frmMainAttendance.dgvFillGridforRead.Columns(Y).HeaderText
        '                Dim sValue = frmMainAttendance.dgvFillGridforRead.Item(Y, X).Value
        '                r(sColumn) = sValue
        '            Next
        '            t.Rows.Add(r)
        '        Next
        '    End If
        '    'End Procedure

        '    Dim objRpt As New Rpt_monAllDed '- Report Files name here 
        '    objRpt.SetDataSource(ds.Tables(0)) ' - Data Set Table Name Here 
        '    objRpt.SetParameterValue("1", cBusiness)
        '    objRpt.SetParameterValue("2", cAddress)
        '    objRpt.SetParameterValue("3", "Monthly Allowances Deductions in  : " & cboMonth.Text & " of " & txtYear.Text)
        '    objRpt.SetParameterValue("4", "")
        '    frmRepContainerAt.crptView.ReportSource = objRpt
        '    frmRepContainerAt.crptView.Refresh()
        '    frmRepContainerAt.ShowDialog()
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllk.Click
        fk_comboItems("Select Description+'='+convert(varchar(5),ID) from tblSalaryItems where  Status='0' AND isHead=4 order by Description asc", cboSalaryItem)
        cmdAllk.Enabled = False
    End Sub

    Public Sub ViewEmployeeInfo()
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
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation" & vbTab & ": " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department" & vbTab & ": " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' ,dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where tblPayrollEmployee.status=0 and  tblPayrollEmployee.SalViewLevel<=" & UserVal & " or tblPayrollEmployee.SalViewLevel is null order by " & strQuery & ""
        If FK_Br(sSQL) = True Then
            txtRegID.Text = frmMainAttendance.dgvFillGridforRead.Item(0, 0).Value
            ViewEmployeeInfo()

        End If

        'If txtRegID.Text = "" Then Exit Sub
    End Sub

    Private Sub txtEPFNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEPFNo.GotFocus

        txtEPFNo.SelectAll()

    End Sub

    Private Sub txtEPFNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEPFNo.KeyPress

        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtEPFNo.Text = "" Then txtEmpNo.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.epfno = '" & txtEPFNo.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.epfno = '" & txtEPFNo.Text & "') and tblPayrollEmployee.SalViewLevel is null"
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
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation" & vbTab & ": " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department" & vbTab & ": " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()

    End Sub

    Private Sub txtEmpNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpNo.GotFocus

        txtEmpNo.SelectAll()

    End Sub

    Private Sub txtEmpNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpNo.KeyPress

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
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation" & vbTab & ": " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department" & vbTab & ": " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()

    End Sub


    'Private Sub grdData_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdData.CellDoubleClick
    '    If grdData.RowCount = 0 Then Exit Sub
    '    Dim sQry As String
    '    With grdData
    '        If MessageBox.Show("Are You Sure to Delete the Record with the ID " & .CurrentRow.Cells(0).Value.ToString & ".", "Confirm..", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
    '            sQry = "update tblworkingAllowances set status='1'  where id='" & .CurrentRow.Cells(0).Value.ToString & "'"
    '            EQ(sQry)
    '            MsgBox("Deleted.")
    '            '                sQry = "SELECT     TOP (100) dbo.tblWorkingAllowances.ID, dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo, " & _
    '            '" dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount ,tblWorkingAllowances.cyear,tblWorkingAllowances.cmonth,'', tblSalaryitems.description FROM         " & _
    '            '" dbo.tblWorkingAllowances INNER JOIN    dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID " & _
    '            '" inner join tblSalaryItems on tblWorkingAllowances.salaryItem=tblsalaryitems.id where cMonth='" & cboMonth.Text & "' and tblWorkingAllowances.status='0' "
    '            '                Load_InformationtoGrid(sQry, grdData, 10)
    '            Dim SQL As String = "SELECT     TOP (100)  dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo,dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount, dbo.tblWorkingAllowances.ID FROM         dbo.tblWorkingAllowances INNER JOIN                       dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID WHERE     (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") AND (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ") AND (dbo.tblWorkingAllowances.Salaryitem = " & txtitemID.Text & ") ORDER BY dbo.tblWorkingAllowances.EmpID"
    '            Load_InformationtoGrid(SQL, grdData, 5)

    '        Else
    '            Exit Sub
    '        End If
    '    End With
    'End Sub

    Private Sub grdData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdData.DoubleClick

        If UP("Set Monthly Basis Allowances", "Delete Added Allowances.Deductions") = False Then Exit Sub

        'Kasun
        ''Dim strID As String = Trim(grdData.CurrentRow.Cells(0).Value) : If strID = "" Then
        ''    sSQL = "Delete from tblWorkingAllowances where ID is NULL and cYear =" & txtYear.Text & " and cMonth = " & cboMonth.Text & " and EmpID='" & Trim(grdData.CurrentRow.Cells(1).Value) & "' and Salaryitem = " & FK_GetIDR(cboSalaryItem.Text) & " "
        ''Else
        sSQL = "Delete from tblWorkingAllowances where ID='" & grdData.CurrentRow.Cells(0).Value & "'; INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'FrmWorkingAllowances','Deleted working allowance field of regID : " & grdData.CurrentRow.Cells(1).Value & " epfNO : " & grdData.CurrentRow.Cells(2).Value & " Amount : " & grdData.CurrentRow.Cells(5).Value & " salary Item  : " & cboSalaryItem.Text & "  Year : " & grdData.CurrentRow.Cells(6).Value & " Month : " & grdData.CurrentRow.Cells(7).Value & "','" & StrUserID & "',0)"
        ''End If

        If FK_EQ(sSQL, "D", "", True, True, True) = True Then
            sSQL = "SELECT      dbo.tblWorkingAllowances.ID, dbo.tblWorkingAllowances.EmpID, dbo.tblPayrollEmployee.epfNo, " &
" dbo.tblPayrollEmployee.EmpNo,dbo.tblPayrollEmployee.dispName, dbo.tblWorkingAllowances.Amount ,tblWorkingAllowances.cyear,tblWorkingAllowances.cmonth,'', tblSalaryitems.description FROM         " &
" dbo.tblWorkingAllowances INNER JOIN    dbo.tblpayrollEmployee ON dbo.tblWorkingAllowances.EmpID = dbo.tblpayrollEmployee.RegID " &
" inner join tblSalaryItems on tblWorkingAllowances.salaryItem=tblsalaryitems.id where (dbo.tblWorkingAllowances.cYear =" & txtYear.Text & ") and " &
" (dbo.tblWorkingAllowances.cMonth = " & cboMonth.Text & ") and (dbo.tblWorkingAllowances.Salaryitem = " & FK_GetIDR(cboSalaryItem.Text) & ") " &
"  and tblWorkingAllowances.status='0' ORDER BY dbo.tblWorkingAllowances.ID Desc "
            Load_InformationtoGrid(sSQL, grdData, 10)
            clr_Grid(grdData)
            lblCounteka.Text = "Total Rows : " & grdData.RowCount
        End If

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Try
            cboMonth.Items.Clear()
            For X = 1 To 12
                cboMonth.Items.Add(X)
            Next
            txtYear.Text = Now.Date.Year
            cboMonth.Text = Format(Now.Date.Month, "0")
            fk_comboItems("Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   Status='0' AND ID IN (select distinct salaryitem from tblWorkingAllowances)   order by Description asc", cboSalaryItem)
            'RefreshForm()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is TextBox Then ctrl.Text = ""
        Next
        If cboSalaryItem.Text <> "" Then txtEmpNo_KeyPress(sender, e)
        grdData.Rows.Clear()
        cmdAllk.Enabled = True
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LoadForm(New frmDailyTransaction)
    End Sub

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus
        If isLimitSalAdvanced = 1 Then
            If FK_GetIDR(cboSalaryItem.Text) = SalAdvancedID Then
                Dim dblMaxSalAdvanced As Double = GetVal("SELECT convert(numeric (18,2) ,basicSalary*50/100) as 'Limit'  FROM tblPayrollEmployee WHERE RegID='" & txtRegID.Text & "'")
                If Val(txtAmount.Text) > dblMaxSalAdvanced Then
                    MessageBox.Show("The employee (" & txtRegID.Text & ") is exceeding the maximum limit of salary advanced, Please check it again. System will set maximum value automatically.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txtAmount.Text = dblMaxSalAdvanced : Exit Sub
                End If
            End If
        End If
    End Sub

End Class