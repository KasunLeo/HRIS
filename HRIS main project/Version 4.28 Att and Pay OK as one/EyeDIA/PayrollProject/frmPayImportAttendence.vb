Imports System.Data.SqlClient

Public Class frmImportAttendence

    Private Sub frmImportAttendence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label12)
        ControlHandlers(Me)

        cmbMonth.Items.Clear()
        cmbMonthAs.Items.Clear()
        For X = 1 To 12
            cmbMonth.Items.Add(X)
            cmbMonthAs.Items.Add(X)
        Next
        cmbYear.Items.Clear()
        cmbYearAs.Items.Clear()
        For X = Now.Date.Year - 5 To Now.Date.Year + 5
            cmbYear.Items.Add(X)
            cmbYearAs.Items.Add(X)
        Next
        cmbYear.Text = Now.Date.Year
        cmbMonth.Text = Now.Date.Month
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If chkBlank.Checked Then
            Call Button4_Click(sender, e) : Exit Sub
        End If

        Dim intPrvMonth As Integer = Val(cmbMonth.Text) - 1
        Dim intYear As Integer = cmbYear.Text
        If Val(cmbMonth.Text) - 1 = 0 Then intYear = Val(cmbYear.Text) - 1 : intPrvMonth = 12
        sSQL1 = "select count(regid) from tblpayempmrecords where cyear=" & intYear & " and cmonth=" & intPrvMonth & " and status=0"
        Dim intPayEmpMRecord As Integer = fk_sqlDbl(sSQL1)
        sSQL1 = "select count(distinct regid) from tblsdall where cyear=" & intYear & " and cmonth=" & intPrvMonth & ""
        Dim intSdAll As Integer = fk_sqlDbl(sSQL1)

        If intPayEmpMRecord > intSdAll Then
            sSQL = "  INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Viewed error message to inform about employees that not in permanant location','" & StrUserID & "',0)"
            FK_EQ(sSQL, "E", "", False, False, True)
            Dim dr As DialogResult = MessageBox.Show("Did yo do the payroll permanant process for all process categories. Please check. Some employees hasn't in permanant location yet. If you continue you will lose the prvious month ssalary data of that employee(s). Do you want to continue ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
            If dr = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If UP("Import Attendence", "Import Attendence") = False Then Exit Sub
        If fk_CheckEx("Select * from tblAttSum where cMonth='" & cmbMonthAs.Text & "' and cyear='" & cmbYearAs.Text & "'") = True Then
            MsgBox("Attendence already exists for this month, Please delete before import", MsgBoxStyle.Information) : Exit Sub
        End If

        Dim sCyear As Integer = Val(cmbYear.Text)
        Dim sCmonth As Integer = Val(cmbMonth.Text)

        Dim dblCmonth As Double = fk_sqlDbl("SELECT distinct [cmonth] from tblsd")
        Dim dblCyear As Double = fk_sqlDbl("SELECT distinct[cyear] from tblsd")
        'sSQL = "select distinct  tblpayrollemployee.prCatID,tblsd.regID from tblsd INNER JOIN tblpayrollemployee ON tblpayrollemployee.RegID=tblsd.RegID  WHERE	tblSD.cyear='" & dblCyear & "' and tblSD.cmonth='" & dblCmonth & "'  and tblpayrollemployee.status=0 AND tblsd.regID not in (select distinct regid from tblsdall where cyear='" & dblCyear & "' and cmonth='" & dblCmonth & "' ) ORDER BY tblsd.regID"

        Dim bolProcessTwo As Boolean = fk_CheckEx(sSQL)
        If bolProcessTwo = True Then
            Dim dr As DialogResult = MessageBox.Show("Please do the process two for month of " & MonthName(dblCmonth) & " and year of " & dblCyear & " for employees in " & strPrCategory & " process category employee(s). Do you want to import attendance without permanent process ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If dr = Windows.Forms.DialogResult.Yes Then
                LoadForm(New frmProcessTwo)
                Exit Sub
            End If      
        End If

        sSQL = fk_RetString("Select AttFormula from tblControl")
        If Trim(sSQL) = "" Then MessageBox.Show("Attendance import formula doesn't exsist to import. Please set it.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        sSQL = Replace(sSQL, "`", "'")
        sSQL = Replace(sSQL, "sCmonth", sCmonth)
        sSQL = Replace(sSQL, "sCYear", sCyear)

        'Exit Sub
        ' Dim vDGV As New DataGridView

        Fk_FillGridLocal(sSQL, vDGV)

        For I = 0 To vDGV.ColumnCount - 1
            For X = 0 To vDGV.RowCount - 1
                If UCase(vDGV.Columns(I).HeaderText) = "CYEAR" Then
                    vDGV.Item(I, X).Value = cmbYearAs.Text
                End If
                If UCase(vDGV.Columns(I).HeaderText) = "CMONTH" Then
                    vDGV.Item(I, X).Value = cmbMonthAs.Text
                End If
            Next
        Next

        Dim sFQ, sSQ As String
        sFQ = "" : sSQ = ""
        For X = 0 To vDGV.ColumnCount - 1
            sFQ = sFQ & vDGV.Columns(X).HeaderText & ","
            'sSQ = sSQ & " vDGV.Item( " & X & " ,i).value  " & ","
        Next
        If vDGV.RowCount = 0 Then MsgBox("Attendence doesn't exsist for the selected month, Please check attendance output of selected month.", MsgBoxStyle.Information) : Exit Sub

        sFQ = Microsoft.VisualBasic.Left(sFQ, Len(sFQ) - 1)

        sSQL = ""
        sSQ = ""
        For X = 0 To vDGV.ColumnCount - 1
            PB.Value = 0
            PB.Maximum = vDGV.RowCount
            For i = 0 To vDGV.RowCount - 1
                PB.Value = i
                'sFQ = sFQ & vDGV.Columns(X).HeaderText & ","
                If vDGV.Item(X, i).Value.ToString = "" Then vDGV.Item(X, i).Value = "0"
            Next

        Next
        sSQL = ""
        PB.Value = 0
        PB.Maximum = vDGV.RowCount
        For i = 0 To vDGV.RowCount - 1
            PB.Value = i
            For X = 0 To vDGV.ColumnCount - 1
                'sFQ = sFQ & vDGV.Columns(X).HeaderText & ","
                'If vDGV.Item(X, i).Value.ToString = "" Then vDGV.Item(X, i).Value = "0"
                sSQ = sSQ & "'" & vDGV.Item(X, i).Value & "'" & ","
            Next
            sSQ = Microsoft.VisualBasic.Left(sSQ, Len(sSQ) - 1)
            sSQL = sSQL & "Insert into tblAttSum (" & sFQ & ") values (" & sSQ & ");"
            sSQ = ""
            If i Mod 30 = 0 Then
                If FK_EQ(sSQL, "P", "", False, False, True) = True Then sSQL = ""
            End If

            'MsgBox(sSQL)
        Next

        'sSQL = sSQL & "  update tblAttSum set cMonth='" & cmbMonthAs.Text & "' where cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "' "
        'MsgBox(sSQL)
        sSQL = sSQL & "INSERT INTO tblmonthend (PrCatID,cYear,cMonth,atP,salP,permP,[status])  select catID," & cmbYearAs.Text & "," & cmbMonthAs.Text & ",0,0,0,0 from tblsetprcategory"

        sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'FrmImportAttendance','Do the Import Process for  Year : " & cmbYearAs.Text & " and Month " & cmbMonthAs.Text & "','" & StrUserID & "',0,'' )"

        FK_EQ(sSQL, "P", "", False, False, True)

        PB.Value = PB.Maximum
        sSQL = "Select tblPayrollEmployee.DispName,tblPayrollEmployee.EmpNo,tblPayrollEmployee.EpfNo,tblSetDept.DeptName,tblDesig.DesgDesc,tblSetPrCategory.CatDesc,tblAttSum.*         from tblAttSum  Inner join tblPayrollEmployee on tblPayrollEmployee.RegID=tblAttSum.RegID Inner join tblSetDept on tblSetDept.DeptID=tblPayrollEmployee.DeptID Inner join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollemployee.PrCatID  where tblAttSum.cMonth='" & cmbMonthAs.Text & "' and cYear='" & cmbYearAs.Text & "'"

        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgv.DataSource = sTable.Tables(0)
            For X = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).Width = 150
            Next
            lblCount.Text = "All Employeess : " & dgv.RowCount
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub Fk_FillGridLocal(ByVal strSQLQuery As String, ByVal DataGridViewName As DataGridView)
        Dim strSqlServer = ReadKey("HRTime\SQLServer")
        Dim strSqlDatabase = ReadKey("HRTime\SQLDatabase")
        Dim strUserName = ReadKey("HRTime\UserName")
        Dim strPassword = ReadKey("HRTime\Password")
        If strSqlServer = "" Or strSqlDatabase = "" Or strUserName = "" Then MsgBox("Please Add Attendence Database Setting From the Edit menu", MsgBoxStyle.Critical) : Exit Sub

        Dim sqlConString1 = "Password= " & strPassword & ";Persist Security Info=True;User ID=" & strUserName & ";Initial Catalog=" & strSqlDatabase & ";Data Source= " & strSqlServer & ";TimeOut=12000"

        Dim CN As New SqlConnection(sqlConString1)
        Dim sBol As Boolean = False
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTable)
            DataGridViewName.DataSource = sTable.Tables(0)
            For X = 0 To DataGridViewName.Columns.Count - 1
                DataGridViewName.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If UP("Import Attendence", "Delete Attendence") = False Then Exit Sub
        If cmbYearAs.Text = "" Then MsgBox("Please Select Year to Delete", MsgBoxStyle.Critical) : cmbYearAs.Focus() : SendKeys.Send("{F4}") : Exit Sub
        If cmbMonthAs.Text = "" Then MsgBox("Please Select Month to Delete", MsgBoxStyle.Critical) : cmbMonthAs.Focus() : SendKeys.Send("{F4}") : Exit Sub

        sSQL1 = "select count(distinct regid) from tblsdall where cMonth='" & cmbMonth.Text & "' and cyear='" & cmbYear.Text & "'"
        Dim intSdAll As Integer = fk_sqlDbl(sSQL1)
        If intSdAll > 0 Then
            MessageBox.Show("You cant change data in permenant location", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        End If

        sSQL = "Delete from tblAttSum where cMonth='" & cmbMonthAs.Text & "' and cyear='" & cmbYearAs.Text & "'; DELETE FROM tblmonthend WHERE cMonth='" & cmbMonthAs.Text & "' and cyear='" & cmbYearAs.Text & "'"
        If FK_EQ(sSQL, "D", "", True, True, True) = True Then
            sSQL = "  INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Delete employee attendance summary for year of " & cmbYear.Text & " and month of " & cmbMonth.Text & " ','" & StrUserID & "',0)"
            FK_EQ(sSQL, "E", "", False, False, True)
        End If


        sSQL = "Select tblPayrollEmployee.DispName,tblPayrollEmployee.EmpNo,tblPayrollEmployee.EpfNo,tblSetDept.DeptName,tblDesig.DesgDesc,tblAttSum.*         from tblAttSum  Inner join tblPayrollEmployee on tblPayrollEmployee.RegID=tblAttSum.RegID Inner join tblSetDept on tblSetDept.DeptID=tblPayrollEmployee.DeptID Inner join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where tblAttSum.cMonth='" & cmbMonthAs.Text & "' and cYear='" & cmbYear.Text & "'"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgv.DataSource = sTable.Tables(0)
            For X = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).Width = 150
            Next
            lblCount.Text = "All Employeess : " & dgv.RowCount

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged

        sSQL = "Select tblPayrollEmployee.DispName,tblPayrollEmployee.EmpNo,tblPayrollEmployee.EpfNo,tblSetDept.DeptName,tblDesig.DesgDesc,tblSetPrCategory.CatDesc as 'Category',tblAttSum.*         from tblAttSum  Inner join tblPayrollEmployee on tblPayrollEmployee.RegID=tblAttSum.RegID Inner join tblSetDept on tblSetDept.DeptID=tblPayrollEmployee.DeptID Inner join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblSetPrCategory on  tblSetPrCategory.CatID=tblpayrollemployee.PrCatID where tblAttSum.cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "'"

        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgv.DataSource = sTable.Tables(0)
            For X = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).Width = 150
            Next
            lblCount.Text = "All Employeess : " & dgv.RowCount

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If MsgBox("Are you sure you want to Add blank Attendance to this month?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then chkBlank.Checked = False : Exit Sub
        If fk_CheckEx("Select * from tblAttSum where cMonth='" & cmbMonth.Text & "' and cyear='" & cmbYear.Text & "'") = True Then
            MsgBox("Attendence Already Exists for this Month, Please Delete Bofore Import", MsgBoxStyle.Information) : Exit Sub
        End If
        Try
            Fk_FillGrid("Select Fld from tblDayFields", dgv1)
            Fk_FillGrid("Select RegID from tblpayrollEmployee where status=0 order by regid asc", dgvEmp)
            Dim i = dgv1.RowCount - 1
            Dim nsSQL = ""
            '=========================Raitha added to give meaningfull messages to user
            If dgv1.RowCount = 0 Then MsgBox("Please Set Attendance Fields First and Try Again.", MsgBoxStyle.Critical) : Exit Sub
            If dgvEmp.RowCount = 0 Then MsgBox("Please Register Employees First and Try Again.", MsgBoxStyle.Critical) : Exit Sub

            '=========================
            For i = 0 To dgv1.RowCount - 1
                nsSQL = nsSQL & "0,"
            Next
            nsSQL = Microsoft.VisualBasic.Left(nsSQL, Len(nsSQL) - 1)
            sSQL = ""
            For X = 0 To dgvEmp.RowCount - 1
                sSQL = sSQL & "Insert into tblAttsum values ('" & dgvEmp.Item(0, X).Value.ToString & "','" & cmbMonth.Text & "','" & cmbYear.Text & "','0', " & nsSQL & ");"
            Next
            FK_EQ(sSQL, "S", "", False, False, True)
            'EQ(sSQL)

            sSQL = "INSERT INTO tblmonthend (PrCatID,cYear,cMonth,atP,salP,permP,[status])  select catID," & cmbYearAs.Text & "," & cmbMonthAs.Text & ",0,0,0,0 from tblsetprcategory"
            FK_EQ(sSQL, "P", "", False, False, True)

            MsgBox("Blank Attendance Successfully Added...")
            '================
            cmbMonth_SelectedIndexChanged(sender, e)
            '=============
            chkBlank.Checked = False

        Catch ex As Exception
            MsgBox("Unable To Add Blank Attendance. " + ex.Message)
        End Try


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If chkExport.Checked = True Then Button6_Click(sender, e) : Exit Sub
        LoadForm(New FrmActiveAttendence)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If MsgBox("Are you sure you want to Export this Data to Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then chkExport.Checked = False : Exit Sub
        ExporttoExcel(dgv, 9)
        lblCount.Text = "All Employeess : " & dgv.RowCount
        chkExport.Checked = False
    End Sub

    Private Sub chkExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkExport.Click
        'If MsgBox("Are you sure you want to Export this Data to Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then chkExport.Checked = False : Exit Sub
        'Button6_Click(sender, e)
        'chkExport.Checked = False
    End Sub

    Private Sub chkBlank_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBlank.Click
        'If MsgBox("Are you sure you want to Add blank Attendance to this month?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then chkBlank.Checked = False : Exit Sub
        'Button4_Click(sender, e)
        'chkBlank.Checked = False
    End Sub

End Class