Public Class FrmPayETF

    Private Sub FrmETF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        'sSQL = "Select distinct 'False',cYear,CONVERT(int,cMonth) as k from tblSdALL ORDER BY cYear,k"
        'FK_LoadGrid(sSQL, dgvMonth)
        For X = 0 To dgvMonth.RowCount - 1
            dgvMonth.Columns(0).ReadOnly = False
        Next
        sSQL = "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status='0';"
        FillComboAll(cmbEmployee, sSQL)
        FillComboAll(cmbEmployer, sSQL)
        FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0")

        ''sSQL = "Create table tblETFData (RegNo varchar(25),Etf varchar(50), Total varchar(50))"
        ''EQ(sSQL)
        sSQL = "select * from tblETFData"
        If FK_ReadDB(sSQL) = True Then
            txtRegNo.Text = FK_Read("RegNo")
            cmbEmployer.Text = FK_Read("ETF")
            cmbEmployee.Text = FK_Read("Total")
        End If
        ''txtYear.Text = Now.Date.Year
        sSQL = "select distinct cYear from tblSdAll order by cYear Asc;"
        FillComboAll(cmbYear, sSQL)
        cmbYear.SelectedIndex = 0
        'cmbQuater.SelectedIndex = 0
        cmbNumber.SelectedIndex = 1
        rdbBranch.Checked = True
        rdbETF.Checked = True
    End Sub

    Private Sub MoveRow(ByVal i As Integer)
        Try
            If (Me.dgvMonth.SelectedCells.Count > 0) Then
                Dim curr_index As Integer = Me.dgvMonth.CurrentCell.RowIndex
                Dim curr_col_index As Integer = Me.dgvMonth.CurrentCell.ColumnIndex
                Dim curr_row As DataGridViewRow = Me.dgvMonth.CurrentRow
                Me.dgvMonth.Rows.Remove(curr_row)
                Me.dgvMonth.Rows.Insert(curr_index + i, curr_row)
                Me.dgvMonth.CurrentCell = Me.dgvMonth(curr_col_index, curr_index + i)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' do nothing if error encountered while trying to move the row up or down

        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If dgvMonth.CurrentRow.Index <> 0 Then
            MoveRow(-1)
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If dgvMonth.CurrentCell.RowIndex <> dgvMonth.RowCount - 1 Then
            MoveRow(1)
        End If
    End Sub

    Private Sub GroupReport()
        Try
            If dgvMonth.RowCount < 1 Then MessageBox.Show("There are no data relenant to this year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            Me.Cursor = Cursors.WaitCursor
            Me.PB.Visible = True
            Dim bolIsFirstRound As Boolean = True

            For ik As Integer = 0 To dgvMonth.RowCount - 1
                PB.Value = ik
                If dgvMonth.Item(0, ik).Value = True Then
                    If bolIsFirstRound = True Then
                        sSQL = "DELETE FROM T_Employee; INSERT INTO T_Employee select *  from tblpayempmRecords WHERE cMonth = '" & Val(dgvMonth.Item(2, ik).Value) & "' AND cYear = '" & Val(dgvMonth.Item(1, ik).Value) & "' AND Status = 0 "
                        FK_EQ(sSQL, "S", "", False, False, True)
                        bolIsFirstRound = False
                    End If
                    sSQL = "INSERT INTO T_Employee SELECT * FROM tblpayempmRecords WHERE cMonth = '" & Val(dgvMonth.Item(2, ik).Value) & "' AND CYear = '" & Val(dgvMonth.Item(1, ik).Value) & "' AND Status = 0 AND RegID Not In (SELECT regid from T_Employee)"
                    FK_EQ(sSQL, "S", "", False, False, True)
                End If
            Next

            'order by
            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "T_Employee.RegID" Else If strReportBased = "02" Then strQuery = "T_Employee.EPFNo" Else If strReportBased = "03" Then strQuery = "T_Employee.ETPNo" Else If strReportBased = "04" Then strQuery = "T_Employee.EMPNo"
            'reports besed on
            Dim strNumber As String = ""
            If FK_GetIDR(cmbNumber.Text) = "01" Then strNumber = "T_Employee.regID" Else If FK_GetIDR(cmbNumber.Text) = "02" Then strNumber = "T_Employee.EPFNo" Else If FK_GetIDR(cmbNumber.Text) = "03" Then strNumber = "T_Employee.ETPNo" Else If FK_GetIDR(cmbNumber.Text) = "04" Then strNumber = "T_Employee.EMPNo"

            ' ''remove other branch employees from list
            ''sSQL = "delete from T_Employee where regid not in (select regid from tblpayrollemployee where brid ='001')"
            sSQL = "select 'true',RegID,DispName,RIGHT('00000'+CAST(" & strNumber & " AS VARCHAR(6)),6) as 'EmpNO',EmIDNum,'','','','','','','','','','','','','' FROM [T_Employee] order by CONVERT(NUMERIC(18,0),EMPNO)"

            ' sSQL = "select 'true',RegID,DispName,RIGHT('00000'+CAST(" & strNumber & " AS VARCHAR(6)),6) as 'EMPNo',EmIDNum,'','','','','','','','','','','','','' FROM [T_Employee] order by CONVERT(NUMERIC(18,0),EMPNo"
            FK_LoadGrid(sSQL, dgv)
            lblCount.Text = "Total Employees : " & dgv.RowCount

            Dim sCol As Integer = 4
            PB.Value = 0
            PB.Maximum = dgv.RowCount - 1
            For I = 0 To dgvMonth.RowCount - 1
                sCol = sCol + 2
                If dgvMonth.Item(0, I).Value = True Then
                    For X = 0 To dgv.RowCount - 1
                        PB.Value = X
                        Dim EmpID = dgv.Item(1, X).Value
                        Dim cYear = dgvMonth.Item(1, I).Value
                        Dim cMonth = dgvMonth.Item(2, I).Value
                        Dim SalID = ""
                        SalID = FK_GetIDR(cmbEmployee.Text)
                        sSQL = "Select tblSDAll.Amount from  tblSdAll,tblPayEmpMrecords where tblPayEmpMrecords.cYear=tblSDAll.cYear and tblPayEmpMrecords.regid=tblSDAll.regid and tblPayEmpMrecords.cMonth=tblSDAll.cmonth and tblSDAll.cYear='" & cYear & "' and tblSDAll.cMonth='" & cMonth & "' and tblSDAll.RegID='" & EmpID & "' and tblSDAll.SalID='" & SalID & "' and tblSDAll.Type1='2';"
                        dgv.Item(sCol, X).Value = GetVal(sSQL)
                        SalID = FK_GetIDR(cmbEmployer.Text)
                        sSQL = "Select tblSDAll.Amount from  tblSdAll,tblPayEmpMrecords where tblPayEmpMrecords.cYear=tblSDAll.cYear and tblPayEmpMrecords.regid=tblSDAll.regid and tblPayEmpMrecords.cMonth=tblSDAll.cmonth and tblSDAll.cYear='" & cYear & "' and tblSDAll.cMonth='" & cMonth & "' and tblSDAll.RegID='" & EmpID & "' and tblSDAll.SalID='" & SalID & "' and tblSDAll.Type1='2';"
                        dgv.Item(sCol + 1, X).Value = GetVal(sSQL)
                    Next
                End If
                ' sCol = sCol + 1
            Next
            PB.Value = PB.Maximum

            For X = 5 To 17
                For I = 0 To dgv.RowCount - 1
                    If Val(dgv.Item(X, I).Value) = 0 Or IsDBNull(dgv.Item(X, I).Value) = True Then
                        dgv.Item(X, I).Value = 0
                    End If
                Next
            Next

            For X = 0 To dgv.RowCount - 1
                dgv.Item(5, X).Value = Val(dgv.Item(7, X).Value) + Val(dgv.Item(9, X).Value) + Val(dgv.Item(11, X).Value) + Val(dgv.Item(13, X).Value) + Val(dgv.Item(15, X).Value) + Val(dgv.Item(17, X).Value)
            Next
            Me.Cursor = Cursors.Default

            clr_Grid(dgv)
            lblCount.Text = "Total Employees : " & dgv.RowCount
            rdbAll.Checked = True
            printGroup()
            Me.PB.Visible = False

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        'Me.Cursor = Cursors.WaitCursor
        If FK_GetIDR(cmbEmployee.Text) = "" Then MsgBox("Invalid Salary for EPF Field", MsgBoxStyle.Critical) : cmbEmployee.Focus() : Exit Sub
        If FK_GetIDR(cmbEmployer.Text) = "" Then MsgBox("Invalid ETF Field", MsgBoxStyle.Critical) : cmbEmployer.Focus() : Exit Sub
        If txtRegNo.Text = "" Then MsgBox("Invalid EPF Register Number", MsgBoxStyle.Critical) : txtRegNo.Focus() : Exit Sub
        If cmbYear.Text = "" Then MsgBox("Invalid Year", MsgBoxStyle.Critical) : cmbEmployer.Focus() : Exit Sub
        If FK_GetIDR(cmbQuater.Text) = "" Then MsgBox("Invalid Session", MsgBoxStyle.Critical) : cmbQuater.Focus() : Exit Sub
        If cmbNumber.Text = "" Then MsgBox("Invalid Member Number", MsgBoxStyle.Critical) : cmbNumber.Focus() : Exit Sub
        If rdbBranch.Checked = False And rdbGroup.Checked = False Then MessageBox.Show("Please select report type from top of the screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : rdbBranch.Checked = True : Exit Sub
        If rdbBranch.Checked = True Then
            If FK_GetIDR(cmbbranch.Text) = "" Then MsgBox("Invalid Branch", MsgBoxStyle.Critical) : cmbbranch.Focus() : Exit Sub
            branchReport()
        ElseIf rdbGroup.Checked = True Then
            GroupReport()
        End If
    End Sub

    Private Sub branchReport()
        Try
            'Dim intFrom, intTO As Integer
            'intFrom = 0
            'intTO = dgvMonth.RowCount - 1
            'For intFrom = 0 To intTO
            '    Dim selRow As New DataGridViewRow
            '    Dim index As Integer = intFrom
            '    'selRow = dgvMonth.CurrentRow
            '    'index = dgvMonth.SelectedRows.Item(0).Index
            '    If index >= intFrom Then
            '        selRow = dgvMonth.Rows.Item(index)
            '        If dgvMonth.Item(0, intFrom).Value = False Then
            '            dgvMonth.Rows.Remove(selRow)
            '            intTO = dgvMonth.RowCount - 1
            '        End If
            '    End If

            'Next

            'Exit Sub
            If dgvMonth.RowCount < 1 Then MessageBox.Show("There are no data relenant to this year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            Me.Cursor = Cursors.WaitCursor
            Me.PB.Visible = True
            Dim bolIsFirstRound As Boolean = True

            For ik As Integer = 0 To dgvMonth.RowCount - 1
                PB.Value = ik
                If dgvMonth.Item(0, ik).Value = True Then
                    If bolIsFirstRound = True Then
                        sSQL = "DELETE FROM T_Employee; INSERT INTO T_Employee SELECT [RegID]   ,[cYear]     ,[cMonth]     ,[DispName]     ,[EMPNo]     ,[EPFNo]  ,[ETPNo] ,[ComID],[DesigID] ,[BrID] ,[DeptID],[BasicSalary],[DaysPay],[EpfAllowed],[PayID],[CostID],[SalViewLevel],[Status],[PrCatID],[EmIdNum],[sub_CatID] FROM tblPayEmpMRecords WHERE cMonth = '" & Val(dgvMonth.Item(2, ik).Value) & "' AND cYear = '" & Val(dgvMonth.Item(1, ik).Value) & "' AND Status = 0  AND brID = '" & FK_GetIDR(cmbbranch.Text) & "'"
                        FK_EQ(sSQL, "S", "", False, False, True)
                        bolIsFirstRound = False
                    End If
                    sSQL = "INSERT INTO T_Employee SELECT [RegID]   ,[cYear]     ,[cMonth]     ,[DispName]     ,[EMPNo]     ,[EPFNo]  ,[ETPNo] ,[ComID],[DesigID] ,[BrID] ,[DeptID],[BasicSalary],[DaysPay],[EpfAllowed],[PayID],[CostID],[SalViewLevel],[Status],[PrCatID],[EmIdNum],[sub_CatID] FROM [tblPayEmpMRecords] WHERE cMonth = '" & Val(dgvMonth.Item(2, ik).Value) & "' AND CYear = '" & Val(dgvMonth.Item(1, ik).Value) & "' AND Status = 0  AND brID = '" & FK_GetIDR(cmbbranch.Text) & "' AND RegID Not In (SELECT regid from T_Employee) order by CONVERT(NUMERIC(18,0),EMPNO)"
                    FK_EQ(sSQL, "S", "", False, False, True)
                End If
            Next

            'order by
            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "T_Employee.RegID" Else If strReportBased = "02" Then strQuery = "T_Employee.EPFNo" Else If strReportBased = "03" Then strQuery = "T_Employee.ETPNo" Else If strReportBased = "04" Then strQuery = "T_Employee.EMPNo"
            'reports besed on
            Dim strNumber As String = ""
            'If FK_GetIDR(cmbNumber.Text) = "01" Then strNumber = "convert(numeric(18,0),T_Employee.regID)" Else If FK_GetIDR(cmbNumber.Text) = "02" Then strNumber = "convert(numeric(18,0),T_Employee.EPFNo)" Else If FK_GetIDR(cmbNumber.Text) = "03" Then strNumber = "convert(numeric(18,0),T_Employee.ETPNo)" Else If FK_GetIDR(cmbNumber.Text) = "04" Then strNumber = "convert(numeric(18,0),T_Employee.EMPNo)"
            If FK_GetIDR(cmbNumber.Text) = "01" Then strNumber = "T_Employee.regID" Else If FK_GetIDR(cmbNumber.Text) = "02" Then strNumber = "T_Employee.EPFNo" Else If FK_GetIDR(cmbNumber.Text) = "03" Then strNumber = "T_Employee.ETPNo" Else If FK_GetIDR(cmbNumber.Text) = "04" Then strNumber = "T_Employee.EMPNo"

            ' ''remove other branch employees from list
            ''sSQL = "delete from T_Employee where regid not in (select regid from tblpayrollemployee where brid ='001')"

            sSQL = "select 'true',RegID,DispName,RIGHT('00000'+CAST(" & strNumber & " AS VARCHAR(6)),6) as 'EmpNO',EmIDNum,'','','','','','','','','','','','','' FROM [T_Employee] order by " & strNumber & ""
            FK_LoadGrid(sSQL, dgv)
            If dgv.RowCount = 0 Then
                MessageBox.Show("There isn't employee(s) in database for selected branch", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Me.Cursor = Cursors.Default : PB.Value = 0 : Exit Sub
            End If

            lblCount.Text = "Total Employees : " & dgv.RowCount

            Dim sCol As Integer = 4
            PB.Value = 0
            PB.Maximum = dgv.RowCount - 1
            For I = 0 To dgvMonth.RowCount - 1
                sCol = sCol + 2
                If dgvMonth.Item(0, I).Value = True Then
                    For X = 0 To dgv.RowCount - 1
                        PB.Value = X
                        Dim EmpID = dgv.Item(1, X).Value
                        Dim cYear = dgvMonth.Item(1, I).Value
                        Dim cMonth = dgvMonth.Item(2, I).Value
                        Dim SalID = ""
                        SalID = FK_GetIDR(cmbEmployee.Text)
                        sSQL = "Select tblSDAll.Amount from  tblSdAll,tblPayEmpMrecords where tblPayEmpMrecords.cYear=tblSDAll.cYear and tblPayEmpMrecords.regid=tblSDAll.regid and tblPayEmpMrecords.cMonth=tblSDAll.cmonth and tblPayEmpMrecords.brid= '" & FK_GetIDR(cmbbranch.Text) & "' and tblSDAll.cYear='" & cYear & "' and tblSDAll.cMonth='" & cMonth & "' and tblSDAll.RegID='" & EmpID & "' and tblSDAll.SalID='" & SalID & "' and tblSDAll.Type1='2';"
                        dgv.Item(sCol, X).Value = GetVal(sSQL)
                        SalID = FK_GetIDR(cmbEmployer.Text)
                        sSQL = "Select tblSDAll.Amount from  tblSdAll,tblPayEmpMrecords where tblPayEmpMrecords.cYear=tblSDAll.cYear and tblPayEmpMrecords.regid=tblSDAll.regid and tblPayEmpMrecords.cMonth=tblSDAll.cmonth and tblPayEmpMrecords.brid= '" & FK_GetIDR(cmbbranch.Text) & "' and tblSDAll.cYear='" & cYear & "' and tblSDAll.cMonth='" & cMonth & "' and tblSDAll.RegID='" & EmpID & "' and tblSDAll.SalID='" & SalID & "' and tblSDAll.Type1='2';"
                        dgv.Item(sCol + 1, X).Value = GetVal(sSQL)
                    Next
                End If
                ' sCol = sCol + 1
            Next
            PB.Value = PB.Maximum

            For X = 5 To 17
                For I = 0 To dgv.RowCount - 1
                    If Val(dgv.Item(X, I).Value) = 0 Or IsDBNull(dgv.Item(X, I).Value) = True Then
                        dgv.Item(X, I).Value = 0
                    End If
                Next
            Next

            For X = 0 To dgv.RowCount - 1
                dgv.Item(5, X).Value = Val(dgv.Item(7, X).Value) + Val(dgv.Item(9, X).Value) + Val(dgv.Item(11, X).Value) + Val(dgv.Item(13, X).Value) + Val(dgv.Item(15, X).Value) + Val(dgv.Item(17, X).Value)
            Next
            Me.Cursor = Cursors.Default

            clr_Grid(dgv)
            lblCount.Text = "Total Employees : " & dgv.RowCount
            rdbAll.Checked = True
            printBranchwise()
            Me.PB.Visible = False

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub printBranchwise()
        Try
            sSQL = "select brName,address,phone,fax from tblcbranchs where brid='" & FK_GetIDR(cmbbranch.Text) & "'"
            'sSQL = "Select ,,Add2,Add3,Phone1,Fax from tblcompany"
            Dim Company = ""
            Dim Add1 = ""
            Dim Add2 = ""
            Dim City = ""
            Dim Phone = ""
            Dim Fax = ""
            If FK_ReadDB(sSQL) = True Then
                Company = FK_Read("brName")
                Add1 = FK_Read("address")
                'Add2 = FK_Read("Add2")
                'City = FK_Read("Add3")
                Phone = FK_Read("phone")
                Fax = FK_Read("fax")
            End If

            Dim sMonth(5) As String         '\\ Created Array to Fill  SixMonths
            For X = 0 To dgvMonth.RowCount - 1
                If dgvMonth.Item(0, X).Value = True Then
                    Dim iMonthNo As Integer = Val(dgvMonth.Item(2, X).Value)
                    Dim dtDate As DateTime = New DateTime(Val(dgvMonth.Item(1, X).Value), iMonthNo, 1)
                    sMonth(X) = dtDate.ToString("MMM")
                    'Dim sMonthName = dtDate.ToString("MMM")
                    'Dim sMonthFullName = dtDate.ToString("MMMM")
                End If
            Next
            For X = 0 To dgv.RowCount - 1

            Next

            ''sSQL = "Create table tblETFData (RegNo varchar(25),Etf varchar(50), Total varchar(50))"
            ''EQ(sSQL)

            sSQL = "Delete from tblETFData;"
            sSQL = sSQL & "Insert into tblETFData (RegNo,Etf,Total) values " & _
            " ('" & txtRegNo.Text & "','" & cmbEmployer.Text & "','" & cmbEmployee.Text & "');"
            FK_EQ(sSQL, "S", "", False, False, True)

            Dim ds As New DS_Report
            Dim t As DataTable = ds.Tables("tblETF") '.Add("Datatable1")
            Dim intCountR As Integer = 0
            Dim intPage As Integer = 0
            For X = 0 To dgv.RowCount - 1
                If dgv.Item(0, X).Value = True Then
                    Dim r As DataRow
                    r = t.NewRow()
                    intCountR = intCountR + 1
                    For Y = 2 To 18
                        Dim sColumn As String = ""
                        Dim sValue As String = ""
                        If Y = 18 Then
                            sColumn = "Number"
                            sValue = intPage
                        Else
                            sColumn = dgv.Columns(Y).HeaderText
                            sValue = dgv.Item(Y, X).Value
                        End If
                        r(Y - 2) = sValue
                    Next
                    t.Rows.Add(r)
                    If intCountR = 28 Then
                        intCountR = 0
                        intPage = intPage + 1
                    End If
                End If
            Next
            Dim objRpt As New rptETFK '- Report Files name here 
            objRpt.SetDataSource(ds.Tables("tblETF"))
            'MsgBox(ds.Tables("tblETF").Rows.Count) ' - Data Set Table Name Here 
            'objRpt.SetParameterValue("Business", Company)
            'objRpt.SetParameterValue("Address1", Add1)
            'objRpt.SetParameterValue("Address2", Add2)
            'objRpt.SetParameterValue("City", City)
            'objRpt.SetParameterValue("Fax", Fax)
            objRpt.SetParameterValue("RegNo", txtRegNo.Text)
            For x = 0 To 5
                If sMonth(x) = Nothing Then sMonth(x) = ""
                objRpt.SetParameterValue("M" & x + 1, sMonth(x))
            Next
            sSQL = FK_GetIDL(cmbbranch.Text) & " Report of " & " " & FK_GetIDL(cmbEmployer.Text)

            Dim strActName As String = ""
            If rdbETF.Checked = True Then
                strActName = "EMPLOYEE'S TRUST FUND ACT NO. 46  OF 1980"
            ElseIf rdbEPF.Checked = True Then
                strActName = "EMPLOYEES’ PROVIDENT FUND Act No 15 of 1958 "
            End If

            objRpt.SetParameterValue("rName", sSQL)
            If FK_GetIDR(cmbQuater.Text) = 1 Then
                sSQL = "Return for Half-Year Ending June "
            ElseIf FK_GetIDR(cmbQuater.Text) = 2 Then
                sSQL = "Return for Half-Year Ending December "
            Else
            End If
            objRpt.SetParameterValue("rName2", sSQL & "of " & cmbYear.Text)
            objRpt.SetParameterValue("rAddressk", Add1)
            objRpt.SetParameterValue("rPhone", Phone)
            objRpt.SetParameterValue("rFax", Fax)
            objRpt.SetParameterValue("actName", strActName)

            'objRpt.SetParameterValue("Tel", Phone)
            'objRpt.SetParameterValue("EPFNo", txtRegNo.Text)
            'objRpt.SetParameterValue("Month", dtDate)

            'objRpt.SetParameterValue("Surcharge", Val(txtSurcharge.Text))
            'objRpt.SetParameterValue("TotRemitence", Val(txtTotRemittence.Text))
            'objRpt.SetParameterValue("Contribution", Val(txtContribution.Text))

            frmRepContainer.crptView.ReportSource = objRpt
            frmRepContainer.crptView.Refresh()
            frmRepContainer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub printGroup()
        Try
            sSQL = "Select cName,Add1 +' '+Add2+ ' ' + Add3 as 'Address',Phone1,Fax from tblcompany"
            Dim Company = ""
            Dim Add1 = ""
            Dim Add2 = ""
            Dim City = ""
            Dim Phone = ""
            Dim Fax = ""
            If FK_ReadDB(sSQL) = True Then
                Company = FK_Read("cName")
                Add1 = FK_Read("Address")
                'Add2 = FK_Read("Add2")
                'City = FK_Read("Add3")
                Phone = FK_Read("Phone1")
                Fax = FK_Read("Fax")
            End If

            Dim sMonth(5) As String         '\\ Created Array to Fill  SixMonths
            For X = 0 To dgvMonth.RowCount - 1
                If dgvMonth.Item(0, X).Value = True Then
                    Dim iMonthNo As Integer = Val(dgvMonth.Item(2, X).Value)
                    Dim dtDate As DateTime = New DateTime(Val(dgvMonth.Item(1, X).Value), iMonthNo, 1)
                    sMonth(X) = dtDate.ToString("MMM")
                    'Dim sMonthName = dtDate.ToString("MMM")
                    'Dim sMonthFullName = dtDate.ToString("MMMM")
                End If
            Next
            For X = 0 To dgv.RowCount - 1

            Next

            ''sSQL = "Create table tblETFData (RegNo varchar(25),Etf varchar(50), Total varchar(50))"
            ''EQ(sSQL)

            sSQL = "Delete from tblETFData;"
            sSQL = sSQL & "Insert into tblETFData (RegNo,Etf,Total) values " & _
            " ('" & txtRegNo.Text & "','" & cmbEmployer.Text & "','" & cmbEmployee.Text & "');"
            FK_EQ(sSQL, "S", "", False, False, True)

            Dim ds As New DS_Report
            Dim t As DataTable = ds.Tables("tblETF") '.Add("Datatable1")
            Dim intCountR As Integer = 0
            Dim intPage As Integer = 0
            For X = 0 To dgv.RowCount - 1
                If dgv.Item(0, X).Value = True Then
                    Dim r As DataRow
                    r = t.NewRow()
                    intCountR = intCountR + 1
                    For Y = 2 To 18
                        Dim sColumn As String = ""
                        Dim sValue As String = ""
                        If Y = 18 Then
                            sColumn = "Number"
                            sValue = intPage
                        Else
                            sColumn = dgv.Columns(Y).HeaderText
                            sValue = dgv.Item(Y, X).Value
                        End If
                        r(Y - 2) = sValue
                    Next
                    t.Rows.Add(r)
                    If intCountR = 28 Then
                        intCountR = 0
                        intPage = intPage + 1
                    End If
                End If
            Next
            Dim objRpt As New rptETFK '- Report Files name here 

            Dim strActName As String = ""
            If rdbETF.Checked = True Then
                strActName = "EMPLOYEE'S TRUST FUND ACT NO. 46  OF 1980"
            ElseIf rdbEPF.Checked = True Then
                strActName = "EMPLOYEES’ PROVIDENT FUND Act No 15 of 1958 "
            End If

            objRpt.SetDataSource(ds.Tables("tblETF"))
            'MsgBox(ds.Tables("tblETF").Rows.Count) ' - Data Set Table Name Here 
            'objRpt.SetParameterValue("Business", Company)
            'objRpt.SetParameterValue("Address1", Add1)
            'objRpt.SetParameterValue("Address2", Add2)
            'objRpt.SetParameterValue("City", City)
            'objRpt.SetParameterValue("Fax", Fax)
            objRpt.SetParameterValue("RegNo", txtRegNo.Text)
            For x = 0 To 5
                If sMonth(x) = Nothing Then sMonth(x) = ""
                objRpt.SetParameterValue("M" & x + 1, sMonth(x))
            Next
            sSQL = FK_GetIDL(cmbbranch.Text) & " Report of " & " " & Company

            objRpt.SetParameterValue("rName", sSQL)
            If FK_GetIDR(cmbQuater.Text) = 1 Then
                sSQL = "Return for Half-Year Ending June "
            ElseIf FK_GetIDR(cmbQuater.Text) = 2 Then
                sSQL = "Return for Half-Year Ending December "
            Else
            End If
            objRpt.SetParameterValue("rName2", sSQL & "of " & cmbYear.Text)
            objRpt.SetParameterValue("rAddressk", Add1)
            objRpt.SetParameterValue("rPhone", Phone)
            objRpt.SetParameterValue("rFax", Fax)

            objRpt.SetParameterValue("actName", strActName)
            'objRpt.SetParameterValue("Tel", Phone)
            'objRpt.SetParameterValue("EPFNo", txtRegNo.Text)
            'objRpt.SetParameterValue("Month", dtDate)

            'objRpt.SetParameterValue("Surcharge", Val(txtSurcharge.Text))
            'objRpt.SetParameterValue("TotRemitence", Val(txtTotRemittence.Text))
            'objRpt.SetParameterValue("Contribution", Val(txtContribution.Text))

            frmRepContainer.crptView.ReportSource = objRpt
            frmRepContainer.crptView.Refresh()
            frmRepContainer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub rdbAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbAll.Click
        Me.Cursor = Cursors.WaitCursor
        rdbAll.Checked = True
        rdbNone.Checked = False
        For X = 0 To dgv.RowCount - 1
            dgv.Item(0, X).Value = True
        Next
        clr_Grid(dgv)
        lblCount.Text = "Total Employees : " & dgv.RowCount
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rdbNone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbNone.Click
        Me.Cursor = Cursors.WaitCursor
        rdbAll.Checked = False
        rdbNone.Checked = True
        For X = 0 To dgv.RowCount - 1
            dgv.Item(0, X).Value = False
        Next
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQuater.SelectedIndexChanged
        If cmbQuater.Text <> "" Then
            Dim INTQuater As Integer
            INTQuater = FK_GetIDR(cmbQuater.Text)
            If INTQuater = 1 Then sSQL = "Select distinct 'True',cYear,CONVERT(int,cMonth) as k from tblSdALL WHERE cYear=" & Val(cmbYear.Text) & " and cMonth between " & INTQuater & " AND " & INTQuater + 5 & " ORDER BY cYear,k" Else sSQL = "Select distinct 'True',cYear,CONVERT(int,cMonth) as k from tblSdALL WHERE cYear=" & Val(cmbYear.Text) & " and cMonth between " & INTQuater + 5 & " AND " & INTQuater + 10 & " ORDER BY cYear,k"
            FK_LoadGrid(sSQL, dgvMonth)
            lblMonth.Text = "Total Month for this Quater : " & dgvMonth.RowCount
        End If
    End Sub

    Private Sub txtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboBox1_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        cmbQuater.SelectedIndex = 0
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If rdbBranch.Checked = True Then
            printBranchwise()
        Else
            printGroup()
        End If
    End Sub

End Class