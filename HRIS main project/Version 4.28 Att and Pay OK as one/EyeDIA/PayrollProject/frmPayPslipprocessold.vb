Imports System.Data.SqlClient

Public Class frmPayslipprocessold

    Dim bolTicked As Boolean = False

    Public Sub saveFilteredToTemp()
        Try
            Dim bSelected As Boolean = False
            For X = 0 To dgvSearchK.RowCount - 1
                If dgvSearchK.Item(0, X).Value = True Or Val(dgvSearchK.Item(0, X).Value) = 1 Then
                    bSelected = True : Exit For
                End If
            Next
            If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub
            sSQL = "Create table tblTempRegID (RegID varchar (15),cYear Decimal(18,0) not null Default 0,cMonth Decimal(18,0) not null Default 0)"
            EQ(sSQL)
            sSQL = "DELETE FROM tblTempRegID; Declare @RegID varchar(15)          "
            bolTicked = True
            For X = 0 To dgvSearchK.RowCount - 1
                If dgvSearchK.Item(0, X).Value = True Or Val(dgvSearchK.Item(0, X).Value) = 1 Then sSQL = sSQL & "       Set @RegID='" & dgvSearchK.Item(1, X).Value & "'             IF not EXISTS (Select RegID from tblTempRegID where RegID=@RegID and cYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "')         BEGIN     Insert into tblTempRegID (regID,cYear,cMonth) values (@RegID,'" & Val(cmbYear.Text) & "','" & Val(cmbMonth.Text) & "')       End "
            Next
            FK_EQ(sSQL, "S", "", False, False, True)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OneColumn()
        saveFilteredToTemp()
        If bolTicked = False Then Exit Sub
        bolTicked = False
        '==========
        'Dim prid As String
        Try
            If UP("Payslip Process", "Do Payslip Process") = False Then Exit Sub
            If FK_GetIDR(cmbSalarySheet.Text) = "" Then MsgBox("Please Select Salary Sheet From the List", MsgBoxStyle.Information) : Exit Sub
            If "" = fk_RetString("select OBJECT_ID('tblsd')") Then
                MsgBox("Please Make Salary Process First Before Payslip Process. ")
                Exit Sub
            End If
            '=========
            Dim SNoEmp = GetVal("Select count(RegID) from tblTempRegID where cYear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "'")
            If SNoEmp = 0 Then MsgBox("Please Select Employees First", MsgBoxStyle.Critical) : Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim sPages = SNoEmp \ 1 + 1

            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"
            If chkDept.Checked = True Then
                strQuery = "tblPayEmpMRecords.deptID, " & strQuery
            End If
            sSQL = "select regid from tblPayEmpMRecords where cyear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "' and  regID in  (select regID from tblTempRegID where   cyear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "') order by " & strQuery & " asc " ' order by ComID asc, BrID asc, DeptID asc,RegID asc" ' and  PrcatID='" & PrID & "'
            Fk_FillGrid(sSQL, dgvregid)
            dgvEmp.Rows.Clear()
            For i = 1 To sPages
                dgvEmp.Rows.Add(i, "", "", "")
            Next
            Dim X, Y As Int32
            X = 1 : Y = 0

            PG.Minimum = 0
            PG.Value = 0
            If dgvEmp.RowCount = 0 Then MsgBox("Error") : Exit Sub
            PG.Maximum = dgvregid.RowCount
            For i = 0 To dgvregid.RowCount - 1
                PG.Value = i
                dgvEmp.Item(X, Y).Value = dgvregid.Item(0, i).Value
                X = X + 1
                If X = 2 Then
                    Y = Y + 1
                    X = 1
                End If
            Next

            sSQL = "Select ItemID,Type1,Format,Com from tblSalarySheetStructure where sheetID='" & FK_GetIDR(cmbSalarySheet.Text) & "' order by iod"
            Fk_FillGrid(sSQL, dgvSalSheet)
            PG.Minimum = 0
            PG.Value = 0
            PG.Maximum = dgvEmp.RowCount
            dgv.Rows.Clear()
            For X = 0 To dgvEmp.RowCount - 1
                PG.Value = X
                For Y = 0 To dgvSalSheet.RowCount - 1
                    dgv.Rows.Add(dgvEmp.Item(0, X).Value, Y + 1, dgvSalSheet.Item(0, Y).Value, dgvSalSheet.Item(1, Y).Value, dgvSalSheet.Item(2, Y).Value, dgvEmp.Item(1, X).Value, "", dgvEmp.Item(2, X).Value, "", dgvEmp.Item(3, X).Value, "", dgvSalSheet.Item(3, Y).Value)
                Next
            Next
            For X = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
            sSQL = "Delete from tblps;"
            PG.Minimum = 0
            PG.Value = 0
            PG.Maximum = dgv.RowCount
            For X = 0 To dgv.RowCount - 1
                Try
                    With dgv
                        sSQL = sSQL & "insert into tblps (PageNo,Order1,                          Type1,                  SalItem,                      Format,                                       RegID1,            Amount1,   SalDes1,       RegID2,         Amount2,SalDes2,RegID3,Amount3,SalDes3,Com)" & _
                        " values ('" & .Item(0, X).Value & "','" & .Item(1, X).Value & "','" & .Item(3, X).Value & "','" & .Item(2, X).Value & "','" & FK_GetID(.Item(4, X).Value.ToString) & "','" & .Item(5, X).Value & "','0','',    '" & .Item(7, X).Value & "','0','',      '" & .Item(9, X).Value & "','0','', '" & .Item(11, X).Value & "')"
                    End With
                    PG.Value = X
                    If X Mod 25 = 0 Then FK_EQ(sSQL, "P", "", False, False, True) : sSQL = ""

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
            PG.Value = PG.Maximum
            FK_EQ(sSQL, "P", "", False, False, True)
            sSQL = "drop table  tbls"
            EQ(sSQL)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim sqlCon As New SqlConnection(sqlConString)
        Try
            If rdTemporary.Checked = True Then ''====  " update tbls set saldes=saldes + '-' +  des " & _

                sSQL = "Declare @Cyear Decimal(18,0)" & _
                " Declare @cMonth Decimal(18,0)" & _
                "set @cYear='" & cmbYear.Text & "'" & _
                " set @cMonth='" & cmbMonth.Text & "'" & _
                " Create table  tbls(	RegID nvarchar(50) ,	Cyear nvarchar(50) ,	Cmonth nvarchar(50) ,	type1 numeric(18, 0) ,	SalID nvarchar(50) ,	AMOUNT numeric(18, 2) NULL,	Des varchar(100) ,	Saldes varchar(150) )" & _
                " insert into tbls select * from tblsd" & _
                " update tbls set des='' where des is null" & _
                        " update tblS SET SalDes = CASE WHEN Des <> ''  THEN saldes + ' (' +  des + ')' Else '' END from tblS where des <> ''" & _
                                " update tblps set Amount1=tbls.Amount,saldes1=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid1=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount2=tbls.Amount,saldes2=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid2=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount3=tbls.Amount,saldes3=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid3=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " drop table  tbls"
            Else
                sSQL = "Declare @Cyear Decimal(18,0)" & _
                " Declare @cMonth Decimal(18,0)" & _
                "set @cYear='" & cmbYear.Text & "'" & _
                " set @cMonth='" & cmbMonth.Text & "'" & _
                " Create table  tbls(	RegID nvarchar(50) ,	Cyear nvarchar(50) ,	Cmonth nvarchar(50) ,	type1 numeric(18, 0) ,	SalID nvarchar(50) ,	AMOUNT numeric(18, 2) NULL,	Des varchar(100) ,	Saldes varchar(150) )" & _
                " insert into tbls select * from tblsdall" & _
                " update tbls set des='' where des is null" & _
                        " update tblS SET SalDes = CASE WHEN Des <> ''  THEN saldes + ' (' +  des + ')' Else '' END from tblS where des <> ''" & _
                " update tblps set Amount1=tbls.Amount,saldes1=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid1=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount2=tbls.Amount,saldes2=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid2=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount3=tbls.Amount,saldes3=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid3=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " drop table  tbls"
            End If
            'If FK_EQ(sSQL, "P", False, True, False) = False Then

            'End If

            sqlCon.Open()
            Dim sqlCom As New SqlCommand(sSQL, sqlCon)
            sqlCom.ExecuteNonQuery()
            PG.Value = PG.Maximum

        Catch ex As Exception
            MsgBox("Error Occured While Payslip Processing. Please Make Salary Process and Try Again." & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
            'Finally()
            sqlCon.Close()
        End Try
        '=================================================================
        Call SecondProcess()

        Try
            sSQL = " Select tblPayrollEmployee.RegID,tblPayrollEmployee.DispName,tblPayrollEmployee.EMPNo,  " & _
            " tblPayrollEmployee.EPFNo,tblPayrollEmployee.ETPNo,tblPayrollEmployee.ComID, tblCompany.cName,  " & _
            " tblPayrollEmployee.DesigID,tblDesig.desgDesc,tblPayrollEmployee.BrID,tblCBranchs.BrName,  " & _
            " tblPayrollEmployee.DeptID,tblSetDept.DeptName, tblPayrollEmployee.BasicSalary,  " & _
            " tblPayrollEmployee.DaysPay,tblPayrollEmployee.EpfAllowed, tblPayrollEmployee.PayID,  " & _
            " tblSetPCentre.pDesc,tblPayrollEmployee.CostID,tblSetCCentre.cntDesc, tblPayrollEmployee.EmIdNum,  " & _
            " tblPayrollEmployee.Status,tblPayrollEmployee.PrCatID, tblSetPrCategory.CatDesc,tblUL.LevelName,  " & _
            " tblPayrollEmployee.SalViewLevel from tblPayrollEmployee " & _
                    " left outer join tblCompany on tblPayrollEmployee.ComID = tblCompany.CompID " & _
                    " left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID" & _
                    " left outer join tblCBranchs on tblPayrollEmployee.BrID = tblCBranchs.BrID" & _
                    " left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID" & _
                    " left outer join tblSetPCentre on tblPayrollEmployee.PayID = tblSetPCentre.pID" & _
                    " left outer join tblSetCCentre on tblPayrollEmployee.CostID = tblSetCCentre.CntID" & _
                    " left outer join tblSetPrCategory on tblPayrollEmployee.PrCatID = tblSetPrCategory.CatID" & _
                    " left outer join tblUL on tblPayrollEmployee.SalViewLevel = tblUL.LevelValue" & _
                    " where tblPayrollEmployee.Status=0"

            Dim CN As New SqlConnection(sqlConString)
            CN.Open()
            Dim adp As New SqlDataAdapter(sSQL, CN)
            Dim stable As New DataSet
            adp.Fill(stable, "tblEmployee")
            sSQL = "Select * from tblps"
            adp = New SqlDataAdapter(sSQL, CN)
            adp.Fill(stable, "tblpayslips")

            If FK_GetIDR(cmbColumns.Text) = "04" Then
                'Dim objRpt As New rptPayslipsTwoColBranPartic '- Report Files name here 
                'objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                'frmRepContainer.crptView.ReportSource = objRpt
                'objRpt.SetParameterValue("1", cBusiness)
                'objRpt.SetParameterValue("2", cAddress)
                'sSQL = "of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                'objRpt.SetParameterValue("3", sSQL)
                'objRpt.SetParameterValue("dtReport", dtReportDate)
                'frmRepContainer.crptView.Refresh()
                'frmRepContainer.ShowDialog()
                'Me.Cursor = Cursors.Default
                'Exit Sub
            End If

            'If isWithLogo = 3 Then 'single column payslip for aitken spence
            '    Dim objRpt As New rptPayslipsColumnLogo '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()

            'ElseIf isWithLogo = 5 Then 'single column payslip for Asliya printer
            '    Dim objRpt As New rptPayslipsAsliya '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()

            'ElseIf isWithLogo = 6 Then 'single column payslip for Thilakawardana
            '    Dim objRpt As New rptPayslipsColumnThilak '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()

            'ElseIf isWithLogo = 15 Then 'single column payslip for Lotusvilla
            '    Dim objRpt As New rptPayslipSingleLetter '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()

            'ElseIf isWithLogo = 16 Then 'single column payslip for Aitkenspence
            '    Dim objRpt As New rptPayslipSingleA4 '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()

            'ElseIf isWithLogo = 22 Then 'single column payslip for Lotus villa
            '    Dim objRpt As New rptPayslipSingleLetterLotus '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()

            'ElseIf isWithLogo = 24 Then 'single column payslip for Lotus villa
            '    Dim objRpt As New rptPayslipSingleLetteEDB '- Report Files name here 
            '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
            '    frmRepContainer.crptView.ReportSource = objRpt
            '    objRpt.SetParameterValue("1", cBusiness)
            '    objRpt.SetParameterValue("2", cAddress)
            '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            '    objRpt.SetParameterValue("3", sSQL)
            '    objRpt.SetParameterValue("dtReport", dtReportDate)
            '    frmRepContainer.crptView.Refresh()
            '    frmRepContainer.ShowDialog()
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Me.Cursor = Cursors.Default
        PG.Value = PG.Maximum
    End Sub

    ''Private Sub PayAdvice()
    ''    saveFilteredToTemp()
    ''    If bolTicked = False Then Exit Sub
    ''    bolTicked = False
    ''    '==========
    ''    'Dim prid As String
    ''    Try
    ''        If UP("Payslip Process", "Do Payslip Process") = False Then Exit Sub
    ''        If FK_GetIDR(cmbSalarySheet.Text) = "" Then MsgBox("Please Select Salary Sheet From the List", MsgBoxStyle.Information) : Exit Sub
    ''        If "" = fk_RetString("select OBJECT_ID('tblsd')") Then
    ''            MsgBox("Please Make Salary Process First Before Payslip Process. ")
    ''            Exit Sub
    ''        End If
    ''        '=========
    ''        Dim SNoEmp = GetVal("Select count(RegID) from tblTempRegID where cYear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "'")
    ''        If SNoEmp = 0 Then MsgBox("Please Select Employees First", MsgBoxStyle.Critical) : Exit Sub
    ''        Me.Cursor = Cursors.WaitCursor

    ''        sSQL = "CREATE TABLE tblPayAdvance (	[RegID] [nvarchar](50) NULL,[Cyear] [nvarchar](50) NULL,[Cmonth] [nvarchar](50) NULL,[type1] [numeric](18, 0) NULL,[SalID] [nvarchar](50) NULL,[AMOUNT] [numeric](18, 2) NULL,[Saldes] [varchar](150) NULL,itemType numeric (18,0),Allowance NVARCHAR (256),Deduction NVARCHAR (256),Other NVARCHAR (256)) ;"
    ''        FK_EQ(sSQL, "P", False, False, False)
    ''        sSQL = "delete from tblPayAdvance;INSERT INTO tblPayAdvance SELECT tblSD.RegID,tblSD.Cyear,tblSD.Cmonth,tblSD.type1,tblSD.SalID,tblSD.AMOUNT,tblSD.Saldes,tblsalaryItems.itemType,'','','' FROM tblSD LEFT OUTER JOIN tblsalaryItems ON tblsalaryItems.ID=tblSD.salID WHERE tblSD.RegID IN (select regID from tblTempRegID) ; UPDATE tblPayAdvance SET allowance =saldes,saldes='' where itemtype=0; UPDATE tblPayAdvance SET Deduction =saldes,saldes='' where itemtype=1; UPDATE tblPayAdvance SET Other =saldes,saldes='' where itemtype=2;"
    ''        FK_EQ(sSQL, "P", False, False, True)

    ''        Dim CN As New SqlConnection(sqlConString)
    ''        CN.Open()
    ''        sSQL = "select * from tblProsum"
    ''        Dim adp As New SqlDataAdapter(sSQL, CN)
    ''        Dim stable As New DataSet
    ''        adp.Fill(stable, "tblProsum")

    ''        'sSQL = "SELECT * FROM tblpayempmrecords  where cYear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "' and regid in (select regID from tblTempRegID) "
    ''        'adp = New SqlDataAdapter(sSQL, CN)
    ''        'adp.Fill(stable, "tblpayempmrecords")

    ''        'sSQL = "SELECT * FROM tblCBranchs"
    ''        'adp = New SqlDataAdapter(sSQL, CN)
    ''        'adp.Fill(stable, "tblCBranchs")

    ''        'sSQL = "SELECT * FROM tblAllowanceReport where regid in (select regID from tblTempRegID)"
    ''        'adp = New SqlDataAdapter(sSQL, CN)
    ''        'adp.Fill(stable, "tblAllowanceReport")

    ''        'sSQL = "SELECT * FROM tblDeductionReport where regid in (select regID from tblTempRegID)"
    ''        'adp = New SqlDataAdapter(sSQL, CN)
    ''        'adp.Fill(stable, "tblDeductionReport")

    ''        'sSQL = "SELECT * FROM tblOtherReport where regid in (select regID from tblTempRegID)"
    ''        'adp = New SqlDataAdapter(sSQL, CN)
    ''        'adp.Fill(stable, "tblOtherReport")

    ''        Dim objRpt As New rptPayAdvanced '- Report Files name here 

    ''        'objRpt.Database.Tables("tblCBranchs").SetDataSource(stable.Tables("tblCBranchs"))
    ''        'objRpt.Database.Tables("tblpayempmrecords").SetDataSource(stable.Tables("tblpayempmrecords"))
    ''        'objRpt.Database.Tables("tblCBranchs").SetDataSource(stable.Tables("tblCBranchs"))
    ''        'objRpt.Database.Tables("tblAllowanceReport").SetDataSource(stable.Tables("tblAllowanceReport"))
    ''        objRpt.Database.Tables("tblDeductionReport").SetDataSource(stable.Tables("tblDeductionReport"))
    ''        objRpt.Database.Tables("tblOtherReport").SetDataSource(stable.Tables("tblOtherReport"))

    ''        frmRepContainer.crptView.ReportSource = objRpt
    ''        objRpt.SetParameterValue("1", cBusiness)
    ''        objRpt.SetParameterValue("2", cAddress)
    ''        sSQL = "Payslips of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
    ''        objRpt.SetParameterValue("3", sSQL)

    ''        frmRepContainer.crptView.Refresh()
    ''        frmRepContainer.ShowDialog()
    ''    Catch ex As Exception
    ''        MsgBox(ex.Message, MsgBoxStyle.Critical)
    ''        Me.Cursor = Cursors.Default
    ''    End Try
    ''End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dtReportDate = dtpPayDate.Value.Date
        If cmbYear.Text = "" Then MsgBox("Please Select Salary Year", MsgBoxStyle.Information) : Exit Sub
        If cmbMonth.Text = "" Then MsgBox("Please Select Salary Month", MsgBoxStyle.Information) : Exit Sub

        'Load History*************************************************************************
        Dim isalid As Integer = FK_GetIDR(cmbSalarySheet.Text)
        Dim sRdButton As String = ""
        If rdPermanant.Checked = True Then
            sRdButton = "P"
        Else
            sRdButton = "T"
        End If
        sSQL = " update tblreportparameters set cyear=" & cmbYear.Text & ",cmonth=" & cmbMonth.Text & ",salid=" & isalid & ",rdButton='" & sRdButton & "' WHERE rID='" & StrReportID & "'" : FK_EQ(sSQL, "P", "", False, False, True)
        'Load History*************************************************************************

        If FK_GetIDR(cmbColumns.Text) = "01" Then ' two Columns
            TwoColumn()
            Exit Sub
        ElseIf FK_GetIDR(cmbColumns.Text) = "03" Then ' three Columns
            OneColumn()
        ElseIf FK_GetIDR(cmbColumns.Text) = "04" Then

            OneColumn()
            Exit Sub
            'ElseIf FK_GetIDR(cmbColumns.Text) = "04" Then 'Pay Advice
            '    PayAdvice()
            '    Exit Sub
        Else

            sSQL = "Alter table tblPS add Com Varchar(10)"
            EQ(sSQL)
            saveFilteredToTemp()
            If bolTicked = False Then Exit Sub
            bolTicked = False
            '==========
            'Dim prid As String
            If UP("Payslip Process", "Do Payslip Process") = False Then Exit Sub
            If FK_GetIDR(cmbSalarySheet.Text) = "" Then MsgBox("Please Select Salary Sheet From the List", MsgBoxStyle.Information) : Exit Sub
            'If cmbComp.Text = "NONE" Then MsgBox("Please Select the Company") : Exit Sub

            'rajitha commented this because tblsd has generated for a perticula process category and hear the 
            'calculations based on that table and no means of taking process category hear.
            'PrID = GetString("Select CatID from tblSetPrCategory where CatDesc = '" & cmbPrcat.Text & "'")

            If "" = fk_RetString("select OBJECT_ID('tblsd')") Then
                MsgBox("Please Make Salary Process First Before Payslip Process. ")
                Exit Sub
            End If
            '=========
            Dim SNoEmp = GetVal("Select count(RegID) from tblTempRegID where cYear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "'")
            If SNoEmp = 0 Then MsgBox("Please Select Employees First", MsgBoxStyle.Critical) : Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim sPages = SNoEmp \ 3 + 1

            If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"
            If chkDept.Checked = True Then
                strQuery = "tblPayEmpMRecords.deptID, " & strQuery
            End If
            sSQL = "select regid from tblPayEmpMRecords where cyear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "' and  regID in  (select regID from tblTempRegID where   cyear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "') order by " & strQuery & " " ' order by ComID asc, BrID asc, DeptID asc,RegID asc" ' and  PrcatID='" & PrID & "'
            Fk_FillGrid(sSQL, dgvregid)
            dgvEmp.Rows.Clear()
            For i = 1 To sPages
                dgvEmp.Rows.Add(i, "", "", "")
            Next
            Dim X, Y As Int32
            X = 1 : Y = 0

            PG.Minimum = 0
            PG.Value = 0
            If dgvEmp.RowCount = 0 Then MsgBox("Error") : Exit Sub
            PG.Maximum = dgvregid.RowCount
            For i = 0 To dgvregid.RowCount - 1
                PG.Value = i
                dgvEmp.Item(X, Y).Value = dgvregid.Item(0, i).Value
                X = X + 1
                If X = 4 Then
                    Y = Y + 1
                    X = 1
                End If
            Next

            sSQL = "Select ItemID,Type1,Format,Com from tblSalarySheetStructure where sheetID='" & FK_GetIDR(cmbSalarySheet.Text) & "' order by iod"
            Fk_FillGrid(sSQL, dgvSalSheet)
            PG.Minimum = 0
            PG.Value = 0
            PG.Maximum = dgvEmp.RowCount
            dgv.Rows.Clear()
            For X = 0 To dgvEmp.RowCount - 1
                PG.Value = X
                For Y = 0 To dgvSalSheet.RowCount - 1
                    dgv.Rows.Add(dgvEmp.Item(0, X).Value, Y + 1, dgvSalSheet.Item(0, Y).Value, dgvSalSheet.Item(1, Y).Value, dgvSalSheet.Item(2, Y).Value, dgvEmp.Item(1, X).Value, "", dgvEmp.Item(2, X).Value, "", dgvEmp.Item(3, X).Value, "", dgvSalSheet.Item(3, Y).Value)
                Next
            Next
            For X = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
            sSQL = "alter table tblps add com varchar (10) " : FK_EQ(sSQL, "", "", False, False, False)
            sSQL = "Delete from tblps;"
            PG.Minimum = 0
            PG.Value = 0
            PG.Maximum = dgv.RowCount
            For X = 0 To dgv.RowCount - 1
                Try
                    With dgv
                        sSQL = sSQL & "insert into tblps (PageNo,Order1,                          Type1,                  SalItem,                      Format,                                       RegID1,            Amount1,   SalDes1,       RegID2,         Amount2,SalDes2,RegID3,Amount3,SalDes3,Com)" & _
                        " values ('" & .Item(0, X).Value & "','" & .Item(1, X).Value & "','" & .Item(3, X).Value & "','" & .Item(2, X).Value & "','" & FK_GetID(.Item(4, X).Value.ToString) & "','" & .Item(5, X).Value & "','0','',    '" & .Item(7, X).Value & "','0','',      '" & .Item(9, X).Value & "','0','', '" & .Item(11, X).Value & "')"
                        'MsgBox("")
                    End With
                    PG.Value = X
                    If X Mod 25 = 0 Then FK_EQ(sSQL, "P", "", False, False, True) : sSQL = ""

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
            PG.Value = PG.Maximum
            FK_EQ(sSQL, "P", "", False, False, True)
            sSQL = "drop table  tbls"
            EQ(sSQL)
            '================  End If

            Dim sqlCon As New SqlConnection(sqlConString)
            Try

                If rdTemporary.Checked = True Then ''====  " update tbls set saldes=saldes + '-' +  des " & _

                    sSQL = "Declare @Cyear Decimal(18,0)" & _
                    " Declare @cMonth Decimal(18,0)" & _
                    "set @cYear='" & cmbYear.Text & "'" & _
                    " set @cMonth='" & cmbMonth.Text & "'" & _
                    " Create table  tbls(	RegID nvarchar(50) ,	Cyear nvarchar(50) ,	Cmonth nvarchar(50) ,	type1 numeric(18, 0) ,	SalID nvarchar(50) ,	AMOUNT numeric(18, 2) NULL,	Des varchar(100) ,	Saldes varchar(150) )" & _
                    " insert into tbls select * from tblsd" & _
                    " update tbls set des='' where des is null" & _
                            " update tblS SET SalDes = CASE WHEN Des <> ''  THEN saldes + ' (' +  des + ')' Else '' END from tblS where des <> ''" & _
                                    " update tblps set Amount1=tbls.Amount,saldes1=tbls.saldes  from tbls" & _
                    " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid1=tbls.regid" & _
                    " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                    " update tblps set Amount2=tbls.Amount,saldes2=tbls.saldes  from tbls" & _
                    " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid2=tbls.regid" & _
                    " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                    " update tblps set Amount3=tbls.Amount,saldes3=tbls.saldes  from tbls" & _
                    " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid3=tbls.regid" & _
                    " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                    " drop table  tbls"
                Else
                    sSQL = "Declare @Cyear Decimal(18,0)" & _
                    " Declare @cMonth Decimal(18,0)" & _
                    "set @cYear='" & cmbYear.Text & "'" & _
                    " set @cMonth='" & cmbMonth.Text & "'" & _
                    " Create table  tbls(	RegID nvarchar(50) ,	Cyear nvarchar(50) ,	Cmonth nvarchar(50) ,	type1 numeric(18, 0) ,	SalID nvarchar(50) ,	AMOUNT numeric(18, 2) NULL,	Des varchar(100) ,	Saldes varchar(150) )" & _
                    " insert into tbls select * from tblsdall" & _
                    " update tbls set des='' where des is null" & _
                            " update tblS SET SalDes = CASE WHEN Des <> ''  THEN saldes + ' (' +  des + ')' Else '' END from tblS where des <> ''" & _
                    " update tblps set Amount1=tbls.Amount,saldes1=tbls.saldes  from tbls" & _
                    " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid1=tbls.regid" & _
                    " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                    " update tblps set Amount2=tbls.Amount,saldes2=tbls.saldes  from tbls" & _
                    " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid2=tbls.regid" & _
                    " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                    " update tblps set Amount3=tbls.Amount,saldes3=tbls.saldes  from tbls" & _
                    " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid3=tbls.regid" & _
                    " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                    " drop table  tbls"
                End If
                'If FK_EQ(sSQL, "P", False, True, False) = False Then

                'End If

                sqlCon.Open()
                Dim sqlCom As New SqlCommand(sSQL, sqlCon)
                sqlCom.ExecuteNonQuery()
                PG.Value = PG.Maximum

            Catch ex As Exception
                MsgBox("Error Occured While Payslip Processing. Please Make Salary Process and Try Again." & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            Finally
                sqlCon.Close()
            End Try
            '=================================================================
            Button3_Click(sender, e)

            Try
                sSQL = " Select tblPayrollEmployee.RegID,tblPayrollEmployee.DispName,tblPayrollEmployee.EMPNo, tblPayrollEmployee.EPFNo,tblPayrollEmployee.ETPNo,tblPayrollEmployee.ComID, tblCompany.cName,tblPayrollEmployee.DesigID,tblDesig.desgDesc,tblPayrollEmployee.BrID,tblCBranchs.BrName,tblPayrollEmployee.DeptID,tblSetDept.DeptName, tblPayrollEmployee.BasicSalary,tblPayrollEmployee.DaysPay,tblPayrollEmployee.EpfAllowed, tblPayrollEmployee.PayID,tblSetPCentre.pDesc,tblPayrollEmployee.CostID,tblSetCCentre.cntDesc, tblPayrollEmployee.EmIdNum,tblPayrollEmployee.Status,tblPayrollEmployee.PrCatID, tblSetPrCategory.CatDesc,tblUL.LevelName,tblPayrollEmployee.SalViewLevel from tblPayrollEmployee " & _
                        " left outer join tblCompany on tblPayrollEmployee.ComID = tblCompany.CompID " & _
                        " left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID" & _
                        " left outer join tblCBranchs on tblPayrollEmployee.BrID = tblCBranchs.BrID" & _
                        " left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID" & _
                        " left outer join tblSetPCentre on tblPayrollEmployee.PayID = tblSetPCentre.pID" & _
                        " left outer join tblSetCCentre on tblPayrollEmployee.CostID = tblSetCCentre.CntID" & _
                        " left outer join tblSetPrCategory on tblPayrollEmployee.PrCatID = tblSetPrCategory.CatID" & _
                        " left outer join tblUL on tblPayrollEmployee.SalViewLevel = tblUL.LevelValue" & _
                        " where tblPayrollEmployee.Status=0"

                Dim CN As New SqlConnection(sqlConString)
                CN.Open()
                Dim adp As New SqlDataAdapter(sSQL, CN)
                Dim stable As New DataSet
                adp.Fill(stable, "tblEmployee")
                sSQL = "Select * from tblps"
                adp = New SqlDataAdapter(sSQL, CN)
                adp.Fill(stable, "tblpayslips")

                'Dim sqlCon2 As New SqlConnection(sqlConString)
                'Try
                '    sSQL = "Select * from tblps"

                '    Dim ds As New DS_Report
                '    Dim t As DataTable = ds.Tables("tblpayslips") '.Add("Datatable1")
                '    If FK_ReadDB(sSQL) = True Then
                '        Dim r As DataRow
                '        For X = 0 To frmMain.dgvFillGridforRead.RowCount - 1
                '            r = t.NewRow()
                '            For Y = 0 To frmMain.dgvFillGridforRead.Columns.Count - 1
                '                Dim sColumn = frmMain.dgvFillGridforRead.Columns(Y).HeaderText
                '                Dim sValue = frmMain.dgvFillGridforRead.Item(Y, X).Value
                '                r(Y) = sValue
                '            Next
                '            t.Rows.Add(r)
                '        Next
                '    End If
                'End Procedure
                '============================================Rajitha.
                '' '' ''Dim sCompName As String
                '' '' ''Dim sAdd1 As String
                '' '' ''Dim sAdd2 As String
                '' '' ''Dim sAdd3 As String

                '' '' ''Try
                '' '' ''    Dim sQry As String = "select cName,add1,add2,add3 from tblcompany where cName='" & cmbComp.Text & "'"
                '' '' ''    sqlCon2.Open()
                '' '' ''    Dim sqlCom As New SqlCommand(sQry, sqlCon2)
                '' '' ''    Dim sqlRead As SqlDataReader = sqlCom.ExecuteReader
                '' '' ''    While sqlRead.Read
                '' '' ''        sCompName = IIf(IsDBNull(sqlRead.Item("cName")), "", sqlRead.Item("cName"))
                '' '' ''        sAdd1 = IIf(IsDBNull(sqlRead.Item("add1")), "", sqlRead.Item("add1"))
                '' '' ''        sAdd2 = IIf(IsDBNull(sqlRead.Item("add1")), "", sqlRead.Item("add1"))
                '' '' ''        sAdd3 = IIf(IsDBNull(sqlRead.Item("add1")), "", sqlRead.Item("add1"))

                '' '' ''    End While

                '' '' ''Catch ex As Exception

                '' '' ''Finally
                '' '' ''    sqlCon2.Close()
                '' '' ''End Try
                '' '' ''Dim sPayMonth As String = "Pay Slip-" & cmbMonth.Text & "/" & txtYear.Text & ""
                '' '' ''Dim sSalAckn As String = "Salary Acknowledgment"

                '======================over.
                If isWithLogo = 13 Then
                    'Dim objRpt As New rptPayslips '- Report Files name here 
                    ''objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    'objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))

                    ''objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    'frmRepContainer.crptView.ReportSource = objRpt
                    ''=================Rajitha.
                    'objRpt.SetParameterValue("1", cBusiness)
                    'objRpt.SetParameterValue("2", cAddress)
                    'sSQL = "Payslips of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    'objRpt.SetParameterValue("3", sSQL)
                    ''' '' ''objRpt.SetParameterValue("sAdd3", sAdd3)
                    ''' '' ''objRpt.SetParameterValue("sSalAck", sSalAckn)
                    'frmRepContainer.crptView.Refresh()
                    'frmRepContainer.ShowDialog()

                    'ElseIf isWithLogo = 14 Then
                    '    Dim objRpt As New rptPayThreeColPayslips '- Report Files name here 
                    '    'objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))

                    '    'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    '    frmRepContainer.crptView.ReportSource = objRpt
                    '    '=================Rajitha.
                    '    objRpt.SetParameterValue("1", cBusiness)
                    '    objRpt.SetParameterValue("2", cAddress)
                    '    sSQL = "Payslips of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    '    objRpt.SetParameterValue("3", sSQL)
                    '    '' '' ''objRpt.SetParameterValue("sAdd3", sAdd3)
                    '    '' '' ''objRpt.SetParameterValue("sSalAck", sSalAckn)
                    '    frmRepContainer.crptView.Refresh()
                    '    frmRepContainer.ShowDialog()

                    'ElseIf isWithLogo = 29 Then
                    '    Dim objRpt As New Payslips_A3LakeHousek '- Lakehouse requirement
                    '    'objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
                    '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))

                    '    'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
                    '    frmRepContainer.crptView.ReportSource = objRpt
                    '    '=================Rajitha.
                    '    objRpt.SetParameterValue("1", cBusiness)
                    '    objRpt.SetParameterValue("2", cAddress)
                    '    sSQL = "Payslips of :" & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                    '    objRpt.SetParameterValue("3", sSQL)
                    '    '' '' ''objRpt.SetParameterValue("sAdd3", sAdd3)
                    '    '' '' ''objRpt.SetParameterValue("sSalAck", sSalAckn)
                    '    frmRepContainer.crptView.Refresh()
                    '    frmRepContainer.ShowDialog()

                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            Me.Cursor = Cursors.Default
            PG.Value = PG.Maximum
        End If

    End Sub

    Private Sub TwoColumn()
        sSQL = "Alter table tblPS add Com Varchar(10)"
        EQ(sSQL)
        saveFilteredToTemp()
        If bolTicked = False Then Exit Sub
        bolTicked = False
        '==========
        'Dim prid As String
        Try
            If UP("Payslip Process", "Do Payslip Process") = False Then Exit Sub
            If FK_GetIDR(cmbSalarySheet.Text) = "" Then MsgBox("Please Select Salary Sheet From the List", MsgBoxStyle.Information) : Exit Sub
            If "" = fk_RetString("select OBJECT_ID('tblsd')") Then
                MsgBox("Please Make Salary Process First Before Payslip Process. ")
                Exit Sub
            End If
            '=========
            Dim SNoEmp = GetVal("Select count(RegID) from tblTempRegID where cYear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "'")
            If SNoEmp = 0 Then MsgBox("Please Select Employees First", MsgBoxStyle.Critical) : Exit Sub
            Me.Cursor = Cursors.WaitCursor
            Dim sPages = SNoEmp / 2

            If SNoEmp Mod 2 = 1 Then
                sPages = (SNoEmp + 1) / 2
            End If

            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"
            If chkDept.Checked = True Then
                strQuery = "tblPayEmpMRecords.deptID, " & strQuery
            End If
            sSQL = "select regid from tblPayEmpMRecords where cyear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "' and  regID in  (select regID from tblTempRegID where   cyear='" & Val(cmbYear.Text) & "' and cmonth='" & Val(cmbMonth.Text) & "') order by " & strQuery & " asc " ' order by ComID asc, BrID asc, DeptID asc,RegID asc" ' and  PrcatID='" & PrID & "'
            Fk_FillGrid(sSQL, dgvregid)
            dgvEmp.Rows.Clear()
            For i = 1 To sPages
                dgvEmp.Rows.Add(i, "", "", "")
            Next
            Dim X, Y As Int32
            X = 1 : Y = 0

            PG.Minimum = 0
            PG.Value = 0
            If dgvEmp.RowCount = 0 Then MsgBox("Error") : Exit Sub
            PG.Maximum = dgvregid.RowCount
            For i = 0 To dgvregid.RowCount - 1
                PG.Value = i
                dgvEmp.Item(X, Y).Value = dgvregid.Item(0, i).Value
                X = X + 1
                If X = 3 Then
                    Y = Y + 1
                    X = 1
                End If
            Next

            sSQL = "Select ItemID,Type1,Format,Com from tblSalarySheetStructure where sheetID='" & FK_GetIDR(cmbSalarySheet.Text) & "' order by iod"
            Fk_FillGrid(sSQL, dgvSalSheet)
            PG.Minimum = 0
            PG.Value = 0
            PG.Maximum = dgvEmp.RowCount
            dgv.Rows.Clear()
            For X = 0 To dgvEmp.RowCount - 1
                PG.Value = X
                For Y = 0 To dgvSalSheet.RowCount - 1
                    dgv.Rows.Add(dgvEmp.Item(0, X).Value, Y + 1, dgvSalSheet.Item(0, Y).Value, dgvSalSheet.Item(1, Y).Value, dgvSalSheet.Item(2, Y).Value, dgvEmp.Item(1, X).Value, "", dgvEmp.Item(2, X).Value, "", dgvEmp.Item(3, X).Value, "", dgvSalSheet.Item(3, Y).Value)
                Next
            Next
            For X = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next

            sSQL = "Delete from tblps;"
            PG.Minimum = 0
            PG.Value = 0
            PG.Maximum = dgv.RowCount
            For X = 0 To dgv.RowCount - 1
                Try
                    With dgv
                        sSQL = sSQL & "insert into tblps (PageNo,Order1,                          Type1,                  SalItem,                      Format,                                       RegID1,            Amount1,   SalDes1,       RegID2,         Amount2,SalDes2,RegID3,Amount3,SalDes3,Com)" & _
                        " values ('" & .Item(0, X).Value & "','" & .Item(1, X).Value & "','" & .Item(3, X).Value & "','" & .Item(2, X).Value & "','" & FK_GetID(.Item(4, X).Value.ToString) & "','" & .Item(5, X).Value & "','0','',    '" & .Item(7, X).Value & "','0','',      '" & .Item(9, X).Value & "','0','', '" & .Item(11, X).Value & "')"
                    End With
                    PG.Value = X
                    If X Mod 25 = 0 Then FK_EQ(sSQL, "", "", False, False, True) : sSQL = ""

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
            PG.Value = PG.Maximum
            FK_EQ(sSQL, "P", "", False, False, True)
            sSQL = "drop table  tbls"
            EQ(sSQL)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Dim sqlCon As New SqlConnection(sqlConString)
        Try
            If rdTemporary.Checked = True Then ''====  " update tbls set saldes=saldes + '-' +  des " & _

                sSQL = "Declare @Cyear Decimal(18,0)" & _
                " Declare @cMonth Decimal(18,0)" & _
                "set @cYear='" & cmbYear.Text & "'" & _
                " set @cMonth='" & cmbMonth.Text & "'" & _
                " Create table  tbls(	RegID nvarchar(50) ,	Cyear nvarchar(50) ,	Cmonth nvarchar(50) ,	type1 numeric(18, 0) ,	SalID nvarchar(50) ,	AMOUNT numeric(18, 2) NULL,	Des varchar(100) ,	Saldes varchar(150) )" & _
                " insert into tbls select * from tblsd" & _
                " update tbls set des='' where des is null" & _
                        " update tblS SET SalDes = CASE WHEN Des <> ''  THEN saldes + ' (' +  des + ')' Else '' END from tblS where des <> ''" & _
                                " update tblps set Amount1=tbls.Amount,saldes1=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid1=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount2=tbls.Amount,saldes2=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid2=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount3=tbls.Amount,saldes3=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid3=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " drop table  tbls"
            Else
                sSQL = "Declare @Cyear Decimal(18,0)" & _
                " Declare @cMonth Decimal(18,0)" & _
                "set @cYear='" & cmbYear.Text & "'" & _
                " set @cMonth='" & cmbMonth.Text & "'" & _
                " Create table  tbls(	RegID nvarchar(50) ,	Cyear nvarchar(50) ,	Cmonth nvarchar(50) ,	type1 numeric(18, 0) ,	SalID nvarchar(50) ,	AMOUNT numeric(18, 2) NULL,	Des varchar(100) ,	Saldes varchar(150) )" & _
                " insert into tbls select * from tblsdall" & _
                " update tbls set des='' where des is null" & _
                        " update tblS SET SalDes = CASE WHEN Des <> ''  THEN saldes + ' (' +  des + ')' Else '' END from tblS where des <> ''" & _
                " update tblps set Amount1=tbls.Amount,saldes1=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid1=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount2=tbls.Amount,saldes2=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid2=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " update tblps set Amount3=tbls.Amount,saldes3=tbls.saldes  from tbls" & _
                " inner join tblps on  tblps.salitem=tbls.salid and  tblps.type1=tbls.type1 and tblps.regid3=tbls.regid" & _
                " where tbls.cyear=@cYear and tbls.cmonth=@cMonth" & _
                " drop table  tbls"
            End If
            'If FK_EQ(sSQL, "P", False, True, False) = False Then

            'End If

            sqlCon.Open()
            Dim sqlCom As New SqlCommand(sSQL, sqlCon)
            sqlCom.ExecuteNonQuery()
            PG.Value = PG.Maximum

        Catch ex As Exception
            MsgBox("Error Occured While Payslip Processing. Please Make Salary Process and Try Again." & ex.Message, MsgBoxStyle.Critical)
            Exit Sub
            'Finally()
            sqlCon.Close()
        End Try
        '=================================================================
        Call SecondProcess()

        Try
            sSQL = " Select tblPayrollEmployee.RegID,tblPayrollEmployee.DispName,tblPayrollEmployee.EMPNo,  " & _
            " tblPayrollEmployee.EPFNo,tblPayrollEmployee.ETPNo,tblPayrollEmployee.ComID, tblCompany.cName,  " & _
            " tblPayrollEmployee.DesigID,tblDesig.desgDesc,tblPayrollEmployee.BrID,tblCBranchs.BrName,  " & _
            " tblPayrollEmployee.DeptID,tblSetDept.DeptName, tblPayrollEmployee.BasicSalary,  " & _
            " tblPayrollEmployee.DaysPay,tblPayrollEmployee.EpfAllowed, tblPayrollEmployee.PayID,  " & _
            " tblSetPCentre.pDesc,tblPayrollEmployee.CostID,tblSetCCentre.cntDesc, tblPayrollEmployee.EmIdNum,  " & _
            " tblPayrollEmployee.Status,tblPayrollEmployee.PrCatID, tblSetPrCategory.CatDesc,tblUL.LevelName,  " & _
            " tblPayrollEmployee.SalViewLevel from tblPayrollEmployee " & _
                    " left outer join tblCompany on tblPayrollEmployee.ComID = tblCompany.CompID " & _
                    " left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID" & _
                    " left outer join tblCBranchs on tblPayrollEmployee.BrID = tblCBranchs.BrID" & _
                    " left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID" & _
                    " left outer join tblSetPCentre on tblPayrollEmployee.PayID = tblSetPCentre.pID" & _
                    " left outer join tblSetCCentre on tblPayrollEmployee.CostID = tblSetCCentre.CntID" & _
                    " left outer join tblSetPrCategory on tblPayrollEmployee.PrCatID = tblSetPrCategory.CatID" & _
                    " left outer join tblUL on tblPayrollEmployee.SalViewLevel = tblUL.LevelValue" & _
                    " where tblPayrollEmployee.Status=0"

            Dim CN As New SqlConnection(sqlConString)
            CN.Open()
            Dim adp As New SqlDataAdapter(sSQL, CN)
            Dim stable As New DataSet
            adp.Fill(stable, "tblEmployee")
            sSQL = "Select * from tblps"
            adp = New SqlDataAdapter(sSQL, CN)
            adp.Fill(stable, "tblpayslips")

            If rdbAlownslip.Checked = True Then
                isWithLogo = 4
            End If

            If isWithLogo = 1 Then 'stander payslp with age and designation
                'Dim objRpt As New rptPayslipsTwoColumn '- Report Files name here 
                'objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                'frmRepContainer.crptView.ReportSource = objRpt
                'objRpt.SetParameterValue("1", cBusiness)
                'objRpt.SetParameterValue("2", cAddress)
                'sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                'objRpt.SetParameterValue("3", sSQL)
                'objRpt.SetParameterValue("dtReport", dtReportDate)
                'frmRepContainer.crptView.Refresh()
                'frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 0 Then 'foundation payslip
                '    'Dim objRpt As New rptPayslipsTwoColumnfnd '- Report Files name here 
                '    Dim objRpt As New rptPayslipsTwoCLNewFND '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 2 Then 'standered payslip
                '    Dim objRpt As New rptPayslipsTwoColumnLogok '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 4 Then 'Thilakavardana with out Comany Name
                '    Dim objRpt As New rptPayslipsThilakavardana '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 7 Then 'CWE Economic
                '    Dim objRpt As New rptPayslipsTwoColCWEK '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 8 Then 'Earls Regen
                '    Dim objRpt As New rptPayslipsTwoColumnLoRegent '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 9 Then 'WITH BOX but with out bottom Part
                '    Dim objRpt As New rptPayslipsTwoColNoUnder '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 10 Then 'WITH BOX but with out bottom Part
                '    Dim objRpt As New rptPayslipsTwoColBranch '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 11 Then 'WITH BOX AITKEN
                '    Dim objRpt As New rptPayslipsTwoColBranchAitken '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 12 Then 'WITH BOX SINHALA
                '    Dim objRpt As New rptPayslipsTwColBrSin '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

                'ElseIf isWithLogo = 17 Then 'single column payslip for Aitkenspence
                '    Dim objRpt As New rptPayslipsTwoColBranchMonaSt '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

                'ElseIf isWithLogo = 18 Then 'Group wise report
                '    Dim objRpt As New rptPayslipsTwoColGroup '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

                'ElseIf isWithLogo = 19 Then 'Group wise report letter
                '    Dim objRpt As New rptPayslipsTwoColGroupLetr '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()


                'ElseIf isWithLogo = 20 Then 'Group wise report letter SIZE WITHOUT SHROFF
                '    Dim objRpt As New rptPayslipsTwoColGroupLetrNoFoot '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

                'ElseIf isWithLogo = 21 Then 'Group wise report letter SIZE with bottom part -lotus villa 2017 10 27
                '    Dim objRpt As New rptPayslipsTwoColGroupLetrWithBootom '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

                'ElseIf isWithLogo = 23 Then 'Branch wise report letter SIZE 2017 11 28
                '    Dim objRpt As New rptPayslipsTwoColBranchLetter '- Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

                'ElseIf isWithLogo = 25 Then 'Branch wise report letter SIZE 2017 11 28
                '    Dim objRpt As New rptPayslipsTwoColGPSignature 'Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 26 Then 'Group name report letter SIZE 2018 03 20 reaf egde
                '    Dim objRpt As New rptPayslipsTwoColReafEd 'Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 27 Then 'Group name report letter SIZE 2018 03 20 reaf egde
                '    Dim objRpt As New rptPayslipsTwoColStd 'Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()
                'ElseIf isWithLogo = 28 Then 'Group name report letter SIZE 2018 03 20 reaf egde
                '    Dim objRpt As New rptPayslipsTwoAcres 'Report Files name here 
                '    objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                '    frmRepContainer.crptView.ReportSource = objRpt
                '    objRpt.SetParameterValue("1", cBusiness)
                '    objRpt.SetParameterValue("2", cAddress)
                '    sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                '    objRpt.SetParameterValue("3", sSQL)
                '    objRpt.SetParameterValue("dtReport", dtReportDate)
                '    frmRepContainer.crptView.Refresh()
                '    frmRepContainer.ShowDialog()

            ElseIf isWithLogo = 27 Then 'Group name report letter SIZE 2019 04 02 NBRO
                Dim objRpt As New rptPayslipsTwoColNBRO 'Report Files name here 
                objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                frmRepContainer.crptView.ReportSource = objRpt
                objRpt.SetParameterValue("1", cBusiness)
                objRpt.SetParameterValue("2", cAddress)
                sSQL = "Payslip of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                objRpt.SetParameterValue("3", sSQL)
                objRpt.SetParameterValue("dtReport", dtReportDate)
                frmRepContainer.crptView.Refresh()
                frmRepContainer.ShowDialog()

            ElseIf isWithLogo = 31 Then 'Group name report letter SIZE 2019 04 02 NBRO
                Dim objRpt As New rptPayslipsTwoAverydeninson 'Report Files name here 
                objRpt.Database.Tables("tblpayslips").SetDataSource(stable.Tables("tblpayslips"))
                frmRepContainer.crptView.ReportSource = objRpt
                objRpt.SetParameterValue("1", cBusiness)
                objRpt.SetParameterValue("2", cAddress)
                sSQL = "Payslip for the month of  : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
                objRpt.SetParameterValue("3", sSQL)
                objRpt.SetParameterValue("dtReport", dtReportDate)
                frmRepContainer.crptView.Refresh()
                frmRepContainer.ShowDialog()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Me.Cursor = Cursors.Default
        PG.Value = PG.Maximum
    End Sub

    Private Sub frmPayslipprocess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        intPrcdMonth = fk_sqlDbl("select distinct cmonth from tblsd")
        strPrCategory = fk_RetString("select processategory from tblCompany where compID='" & StrCompID & "'")
        strPrCategory = fk_RetString("select '" & strPrCategory & "'+'='+catid from tblSetPrCategory where catDesc='" & strPrCategory & "'")
        Label12.BackColor = clrFocused
        cmdRefresh_Click(sender, e)
        If isWithLogo = 3 Or isWithLogo = 5 Or isWithLogo = 6 Or isWithLogo = 15 Or isWithLogo = 16 Or isWithLogo = 22 Or isWithLogo = 24 Then
            cmbColumns.SelectedIndex = 2
        ElseIf isWithLogo = 13 Or isWithLogo = 14 Or isWithLogo = 29 Then
            cmbColumns.SelectedIndex = 1
        End If
        If UserLevelID = "000" Then
            Button5.Visible = True
        End If
    End Sub

    Private Sub SecondProcess()
        Try
            sSQL = "Select RegID1,Amount1  from tblPs where SalItem='8' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPC1='" & dgvNet.Item(1, X).Value & "' where RegID1='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If sSQL <> "" Then If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "Select RegID1,Amount1  from tblPs where SalItem='9' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPb1='" & dgvNet.Item(1, X).Value & "' where RegID1='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If sSQL <> "" Then If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""

            sSQL = "Select RegID2,Amount2  from tblPs where SalItem='8' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPC2='" & dgvNet.Item(1, X).Value & "' where RegID2='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If sSQL <> "" Then If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "Select RegID2,Amount2  from tblPs where SalItem='9' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPb2='" & dgvNet.Item(1, X).Value & "' where RegID2='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""

            sSQL = "Select RegID3,Amount3  from tblPs where SalItem='8' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPC3='" & dgvNet.Item(1, X).Value & "' where RegID3='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "Select RegID3,Amount3  from tblPs where SalItem='9' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPb3='" & dgvNet.Item(1, X).Value & "' where RegID3='" & dgvNet.Item(0, X).Value & "'; "
            Next

            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"

            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""

            sSQL = " update tblPs set Emp1=RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6),Dept1=tblPayrollEmployee.DeptID,Category1=tblPayrollEmployee.sub_CatID,EType1=tblPayrollEmployee.sub_CatID,Name1=tblPayrollEmployee.DispName,Epf1=tblPayrollEmployee.EpfNo from tblPayrollEmployee " & _
            " inner join tblPs on tblPayrollEmployee.RegID=tblPs.RegID1 " & _
            "             where(tblPs.RegID1 = tblPayrollEmployee.RegID)" & _
" update tblPs set Emp2=RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6),Dept2=tblPayrollEmployee.DeptID,Category2=tblPayrollEmployee.sub_CatID,EType2=tblPayrollEmployee.sub_CatID,Name2=tblPayrollEmployee.DispName,Epf2=tblPayrollEmployee.EpfNo from tblPayrollEmployee " & _
" inner join tblPs on tblPayrollEmployee.RegID=tblPs.RegID2" & _
"             where(tblPs.RegID2 = tblPayrollEmployee.RegID)" & _
" update tblPs set Emp3=RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6),Dept3=tblPayrollEmployee.DeptID,Category3=tblPayrollEmployee.sub_CatID,EType3=tblPayrollEmployee.sub_CatID,Name3=tblPayrollEmployee.DispName,Epf3=tblPayrollEmployee.EpfNo from tblPayrollEmployee " & _
" inner join tblPs on tblPayrollEmployee.RegID=tblPs.RegID3" & _
"             where(tblPs.RegID3 = tblPayrollEmployee.RegID)" & _
" update tblPS set Dept1=tblSetDept.DeptName from tblSetDept" & _
" inner join tblPs on tblSetDept.DeptID=tblPs.Dept1" & _
"             where(tblPs.Dept1 = tblSetDept.DeptID)" & _
" update tblPS set Dept2=tblSetDept.DeptName from tblSetDept " & _
" inner join tblPs on tblSetDept.DeptID=tblPs.Dept2 " & _
"             where(tblPs.Dept2 = tblSetDept.DeptID)" & _
" update tblPS set Dept3=tblSetDept.DeptName from tblSetDept" & _
" inner join tblPs on tblSetDept.DeptID=tblPs.Dept3" & _
"            where(tblPs.Dept3 = tblSetDept.DeptID)"

            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "update tblPS set SalDes1=tblSalaryitems.Description from  tblSalaryitems left join tblps on tblps.SalItem=tblSalaryitems.ID where (tblPS.SalDes1='' or tblPS.SalDes1 is null) and Type1='2'  update tblPS set SalDes2=tblSalaryitems.Description from  tblSalaryitems left join tblps on tblps.SalItem=tblSalaryitems.ID where (tblPS.SalDes2='' or tblPS.SalDes2 is null) and Type1='2'  update tblPS set SalDes3=tblSalaryitems.Description from  tblSalaryitems left join tblps on tblps.SalItem=tblSalaryitems.ID where (tblPS.SalDes3='' or tblPS.SalDes3 is null) and Type1='2' "
            FK_EQ(sSQL, "S", "", False, False, True)

            sSQL = "update tblps set Bank1=tblpayrollemployee.BankID,Br1=tblpayrollemployee.BranchID,Acc1=tblpayrollemployee.AccNumber,Desig1=tblpayrollemployee.DesigID,Age1=datediff(year,tblpayrollemployee.birthDate,getdate()),brName1=tblpayrollemployee.brID,brAdress1=tblpayrollemployee.brID  from tblpayrollemployee left join tblPS on tblPS.RegID1=tblpayrollemployee.RegID " & _
            " update tblps set Bank2=tblpayrollemployee.BankID,Br2=tblpayrollemployee.BranchID,Acc2=tblpayrollemployee.AccNumber,Desig2=tblpayrollemployee.DesigID,Age2=datediff(year,tblpayrollemployee.birthDate,getdate()),brName2=tblpayrollemployee.brID,brAdress2=tblpayrollemployee.brID from tblpayrollemployee left join tblPS on tblPS.RegID2=tblpayrollemployee.RegID " & _
            " update tblps set Bank3=tblpayrollemployee.BankID,Br3=tblpayrollemployee.BranchID,Acc3=tblpayrollemployee.AccNumber,Desig3=tblpayrollemployee.DesigID,Age3=datediff(year,tblpayrollemployee.birthDate,getdate()),brName3=tblpayrollemployee.brID,brAdress3=tblpayrollemployee.brID from tblpayrollemployee left join tblPS on tblPS.RegID3=tblpayrollemployee.RegID " & _
            " update tblPS set Br1=tblBranches.BranchName from tblBranches left join  tblPS on tblPS.Br1=tblBranches.BrID and tblPS.Bank1=tblBranches.BankID " & _
            " update tblPS set Br2=tblBranches.BranchName from tblBranches left join  tblPS on tblPS.Br2=tblBranches.BrID and tblPS.Bank2=tblBranches.BankID  " & _
            " update tblPS set Br3=tblBranches.BranchName from tblBranches left join  tblPS on tblPS.Br3=tblBranches.BrID and tblPS.Bank3=tblBranches.BankID  " & _
            " update tblPS set Bank1=tblBanks.BankName from tblBanks left join tblps on tblps.Bank1=tblBanks.BankID " & _
            " update tblPS set Bank2=tblBanks.BankName from tblBanks left join tblps on tblps.Bank2=tblBanks.BankID " & _
            " update tblPS set Bank3=tblBanks.BankName from tblBanks left join tblps on tblps.Bank3=tblBanks.BankID " & _
            " update tblPS set Desig1=tblDesig.desgDesc from tblDesig left join tblps on tblps.Desig1=tblDesig.desgID " & _
            " update tblPS set Desig2=tblDesig.desgDesc from tblDesig left join tblps on tblps.Desig2=tblDesig.desgID " & _
            " update tblPS set Desig3=tblDesig.desgDesc from tblDesig left join tblps on tblps.Desig3=tblDesig.desgID " & _
            " update tblPS set brName1=tblcbranchs.brName from tblcbranchs left join tblps on tblps.brName1=tblcbranchs.brID " & _
            " update tblPS set brName2=tblcbranchs.brName from tblcbranchs left join tblps on tblps.brName2=tblcbranchs.brID " & _
            " update tblPS set brName3=tblcbranchs.brName from tblcbranchs left join tblps on tblps.brName3=tblcbranchs.brID " & _
            " update tblPS set brAdress1=tblcbranchs.Address from tblcbranchs left join tblps on tblps.brAdress1=tblcbranchs.brID " & _
            " update tblPS set brAdress2=tblcbranchs.Address from tblcbranchs left join tblps on tblps.brAdress2=tblcbranchs.brID " & _
            " update tblPS set brAdress3=tblcbranchs.Address from tblcbranchs left join tblps on tblps.brAdress3=tblcbranchs.brID " & _
            " update tblPS set Category1=tblsetempCategory.catDesc from tblsetempCategory left join tblps on tblps.Category1=tblsetempCategory.catID " & _
            " update tblPS set Category2=tblsetempCategory.catDesc from tblsetempCategory left join tblps on tblps.Category2=tblsetempCategory.catID  " & _
            " update tblPS set Category3=tblsetempCategory.catDesc from tblsetempCategory left join tblps on tblps.Category3=tblsetempCategory.catID " & _
            " update tblPS set EType1=tblsetemptype.tDesc from tblsetemptype left join tblps on tblps.EType1=tblsetemptype.typeID " & _
            " update tblPS set EType2=tblsetemptype.tDesc from tblsetemptype left join tblps on tblps.EType2=tblsetemptype.typeID " & _
            " update tblPS set EType3=tblsetemptype.tDesc from tblsetemptype left join tblps on tblps.EType3=tblsetemptype.typeID "

            FK_EQ(sSQL, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Try
            sSQL = "Select RegID1,Amount1  from tblPs where SalItem='8' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPC1='" & dgvNet.Item(1, X).Value & "' where RegID1='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "Select RegID1,Amount1  from tblPs where SalItem='9' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPb1='" & dgvNet.Item(1, X).Value & "' where RegID1='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""

            sSQL = "Select RegID2,Amount2  from tblPs where SalItem='8' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPC2='" & dgvNet.Item(1, X).Value & "' where RegID2='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "Select RegID2,Amount2  from tblPs where SalItem='9' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPb2='" & dgvNet.Item(1, X).Value & "' where RegID2='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""

            sSQL = "Select RegID3,Amount3  from tblPs where SalItem='8' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPC3='" & dgvNet.Item(1, X).Value & "' where RegID3='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "Select RegID3,Amount3  from tblPs where SalItem='9' and Type1='2';"
            FK_LoadGrid(sSQL, dgvNet)
            sSQL = ""
            For X = 0 To dgvNet.RowCount - 1
                sSQL = sSQL & "Update tblPs set NPb3='" & dgvNet.Item(1, X).Value & "' where RegID3='" & dgvNet.Item(0, X).Value & "'; "
            Next
            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""

            sSQL = " update tblPs set Emp1=tblPayrollEmployee.EmpNo,Dept1=tblPayrollEmployee.DeptID,Name1=tblPayrollEmployee.DispName,Epf1=tblPayrollEmployee.EpfNo from tblPayrollEmployee " & _
            " inner join tblPs on tblPayrollEmployee.RegID=tblPs.RegID1 " & _
            "             where(tblPs.RegID1 = tblPayrollEmployee.RegID)" & _
" update tblPs set Emp2=tblPayrollEmployee.EmpNo,Dept2=tblPayrollEmployee.DeptID,Name2=tblPayrollEmployee.DispName,Epf2=tblPayrollEmployee.EpfNo from tblPayrollEmployee " & _
" inner join tblPs on tblPayrollEmployee.RegID=tblPs.RegID2" & _
"             where(tblPs.RegID2 = tblPayrollEmployee.RegID)" & _
" update tblPs set Emp3=tblPayrollEmployee.EmpNo,Dept3=tblPayrollEmployee.DeptID,Name3=tblPayrollEmployee.DispName,Epf3=tblPayrollEmployee.EpfNo from tblPayrollEmployee " & _
" inner join tblPs on tblPayrollEmployee.RegID=tblPs.RegID3" & _
"             where(tblPs.RegID3 = tblPayrollEmployee.RegID)" & _
" update tblPS set Dept1=tblSetDept.DeptName from tblSetDept" & _
" inner join tblPs on tblSetDept.DeptID=tblPs.Dept1" & _
"             where(tblPs.Dept1 = tblSetDept.DeptID)" & _
" update tblPS set Dept2=tblSetDept.DeptName from tblSetDept " & _
" inner join tblPs on tblSetDept.DeptID=tblPs.Dept2 " & _
"             where(tblPs.Dept2 = tblSetDept.DeptID)" & _
" update tblPS set Dept3=tblSetDept.DeptName from tblSetDept" & _
" inner join tblPs on tblSetDept.DeptID=tblPs.Dept3" & _
"            where(tblPs.Dept3 = tblSetDept.DeptID)"

            If FK_EQ(sSQL, "S", "", False, False, True) Then sSQL = ""
            sSQL = "update tblPS set SalDes1=tblSalaryitems.Description from  tblSalaryitems left join tblps on tblps.SalItem=tblSalaryitems.ID where (tblPS.SalDes1='' or tblPS.SalDes1 is null) and Type1='2'  update tblPS set SalDes2=tblSalaryitems.Description from  tblSalaryitems left join tblps on tblps.SalItem=tblSalaryitems.ID where (tblPS.SalDes2='' or tblPS.SalDes2 is null) and Type1='2' update tblPS set SalDes3=tblSalaryitems.Description from  tblSalaryitems left join tblps on tblps.SalItem=tblSalaryitems.ID where (tblPS.SalDes3='' or tblPS.SalDes3 is null) and Type1='2' "
            FK_EQ(sSQL, "S", "", False, False, True)

            'Code Added to get ban ,Branch and Account No in Payslips
            sSQL = "Alter table tblPS add Bank1 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Bank2 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Bank3 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Br1 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Br2 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Br3 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Acc1 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Acc2 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add Acc3 varchar(50)"
            FK_EQ(sSQL, "S", "", False, False, False)

            sSQL = "Alter table tblPS add brName1 varchar(150)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add brName2 varchar(150)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add brName3 varchar(150)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add brAdress1 varchar(150)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add brAdress2 varchar(150)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add brAdress3 varchar(150)"
            FK_EQ(sSQL, "S", "", False, False, False)

            'Code added to get employee address and regDate
            sSQL = "Alter table tblPS add EmpAdress1 varchar(250)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add EmpAdress2 varchar(250)"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add EmpAdress3 varchar(250)"
            FK_EQ(sSQL, "S", "", False, False, False)

            sSQL = "Alter table tblPS add regDate1 dateTime"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add regDate2 dateTime"
            FK_EQ(sSQL, "S", "", False, False, False)
            sSQL = "Alter table tblPS add regDate3 dateTime"
            FK_EQ(sSQL, "S", "", False, False, False)

            sSQL = "update tblps set Bank1=tblpayrollemployee.BankID,Br1=tblpayrollemployee.BranchID,Acc1=tblpayrollemployee.AccNumber,brName1=tblpayrollemployee.brID,brAdress1=tblpayrollemployee.brID,regDate1=tblpayrollemployee.joiningDate from tblpayrollemployee left join tblPS on tblPS.RegID1=tblpayrollemployee.RegID " & _
            " update tblps set Bank2=tblpayrollemployee.BankID,Br2=tblpayrollemployee.BranchID,Acc2=tblpayrollemployee.AccNumber,brName2=tblpayrollemployee.brID,brAdress2=tblpayrollemployee.brID,regDate2=tblpayrollemployee.joiningDate from tblpayrollemployee left join tblPS on tblPS.RegID2=tblpayrollemployee.RegID  " & _
            " update tblps set Bank3=tblpayrollemployee.BankID,Br3=tblpayrollemployee.BranchID,Acc3=tblpayrollemployee.AccNumber,brName3=tblpayrollemployee.brID,brAdress3=tblpayrollemployee.brID,regDate3=tblpayrollemployee.joiningDate from tblpayrollemployee left join tblPS on tblPS.RegID3=tblpayrollemployee.RegID  " & _
            " update tblPS set Br1=tblBranches.BranchName from tblBranches left join  tblPS on tblPS.Br1=tblBranches.BrID and tblPS.Bank1=tblBranches.BankID  " & _
            " update tblPS set Br2=tblBranches.BranchName from tblBranches left join  tblPS on tblPS.Br2=tblBranches.BrID and tblPS.Bank2=tblBranches.BankID   " & _
            " update tblPS set Br3=tblBranches.BranchName from tblBranches left join  tblPS on tblPS.Br3=tblBranches.BrID and tblPS.Bank3=tblBranches.BankID   " & _
            " update tblPS set Bank1=tblBanks.BankName from tblBanks left join tblps on tblps.Bank1=tblBanks.BankID  " & _
            " update tblPS set Bank2=tblBanks.BankName from tblBanks left join tblps on tblps.Bank2=tblBanks.BankID  " & _
            " update tblPS set Bank3=tblBanks.BankName from tblBanks left join tblps on tblps.Bank3=tblBanks.BankID " & _
            " update tblPS set brName1=tblcbranchs.brName from tblcbranchs left join tblps on tblps.brName1=tblcbranchs.brID " & _
            " update tblPS set brName2=tblcbranchs.brName from tblcbranchs left join tblps on tblps.brName2=tblcbranchs.brID " & _
            " update tblPS set brName3=tblcbranchs.brName from tblcbranchs left join tblps on tblps.brName3=tblcbranchs.brID " & _
            " update tblPS set EmpAdress1=tblEmpAddress.Add1 + ' ' + tblEmpAddress.Add2 + ' ' + tblEmpAddress.Add3 from tblEmpAddress left join tblps on tblps.EmpAdress1=tblEmpAddress.addid  " & _
            " update tblPS set EmpAdress2=tblEmpAddress.Add1 + ' ' + tblEmpAddress.Add2 + ' ' + tblEmpAddress.Add3 from tblEmpAddress left join tblps on tblps.EmpAdress1=tblEmpAddress.addid  " & _
            " update tblPS set EmpAdress3=tblEmpAddress.Add1 + ' ' + tblEmpAddress.Add2 + ' ' + tblEmpAddress.Add3 from tblEmpAddress left join tblps on tblps.EmpAdress1=tblEmpAddress.addid " & _
            " update tblPS set brAdress1=tblcbranchs.Address from tblcbranchs left join tblps on tblps.brAdress1=tblcbranchs.brID " & _
            " update tblPS set brAdress2=tblcbranchs.Address from tblcbranchs left join tblps on tblps.brAdress2=tblcbranchs.brID " & _
            " update tblPS set brAdress3=tblcbranchs.Address from tblcbranchs left join tblps on tblps.brAdress3=tblcbranchs.brID "

            FK_EQ(sSQL, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        LoadForm(New FrmFilterEmployees)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Try
            Dim ctrl As Control
            For Each ctrl In GroupBox1.Controls
                If TypeOf ctrl Is ComboBox Then
                    ctrl.Text = ""
                End If
            Next

            'cmbYear.Text = Now.Year
            cmbMonth.Items.Clear()
            For X = 1 To 12
                cmbMonth.Items.Add(X)
            Next
            'cmbMonth.Text = Now.Month
            PG.Value = 0
            'cmbMonth.Text = Now.Date.Month
            cmbYear.Items.Clear()
            For X = Now.Date.Year - 5 To Now.Date.Year + 5
                cmbYear.Items.Add(X)
            Next
            'cmbYear.Text = Now.Date.Year
            sSQL = "Select SheetName+'='+ID from  tblSalarySheet where Status='0'"
            FillCom2(cmbSalarySheet, sSQL)

            FillComboAll(cmbDepartment, "select DeptName + '=' + DeptID from tblsetDept where status=0 order by DeptName asc")
            FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0 order by pDesc asc")
            FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0 order by cntDesc asc")
            'FillCombo(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
            FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0 order by CName asc")
            FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0 order by BrName asc")
            FillComboAll(cmbDesignation, "Select DesgDesc + '=' + DesgID from tblDesig where status=0 order by DesgDesc asc")
            FillComboAll(cmbPrCatagory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0 order by CatDesc asc")
            FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc asc")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
            FillComboAll(cmbEmpType, "select tDesc + '=' +TypeID from tblSetEmpType WHERE Status=0 ORDER BY tDesc")
            FillComboAll(cmbGender, "select GenDesc + '=' + genID from tblGender WHERE Status=0 ORDER BY GenDesc")
            FillComboAll(cmbReligion, "select ReligDesc + '=' + ReligID from tblSetReligion WHERE Status=0 ORDER BY ReligDesc")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************

            LoadHistory()
            rdbPayslip.Checked = True
            'txtSearch.Text = ""
            'cmbMonth.Text = intPrcdMonth
            cmbColumns.SelectedIndex = 0
            'cmbSalarySheet.SelectedIndex = 0

            cmbPrCatagory.Text = strPrCategory
            chkTick.Checked = True
            isWithLogo = GetVal("SELECT isWithLogo FROM tblCompany WHERE CompID='" & StrCompID & "'")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub LoadHistory()
        Try
            sSQL = "SELECT rName,cyear,cmonth,salid,rdButton FROM tblreportparameters where rid='" & strReportID & "'"
            FK_ReadDB(sSQL)
            rName = FK_Read("rName")
            Dim sRdButton As String = FK_Read("rdButton")
            If sRdButton = "T" Then
                rdTemporary.Checked = True
            ElseIf sRdButton = "P" Then
                rdPermanant.Checked = True
            End If
            cmbYear.Text = FK_Read("cyear")
            cmbMonth.Text = FK_Read("cmonth")
            Dim iSalID As Integer = FK_Read("salid")
            cmbSalarySheet.Text = fk_RetString("Select SheetName+'='+ID from  tblSalarySheet where Status='0' and  id=" & iSalID & "")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SearchEmployee()
        strReportBased = "01"
        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"

        Dim StrDeptname As String = IIf(cmbDepartment.Text = "[ALL]", "", FK_GetIDR(cmbDepartment.Text))
        Dim StrSubCatName As String = IIf(cmbSubCategory.Text = "[ALL]", "", FK_GetIDR(cmbSubCategory.Text))
        Dim StrDesigName As String = IIf(cmbDesignation.Text = "[ALL]", "", FK_GetIDR(cmbDesignation.Text))
        Dim StrBranchName As String = IIf(cmbbranch.Text = "[ALL]", "", FK_GetIDR(cmbbranch.Text))
        Dim StrCompany As String = IIf(cmbCompany.Text = "[ALL]", "", FK_GetIDR(cmbCompany.Text))
        Dim StrPrCategorya As String = IIf(cmbPrCatagory.Text = "[ALL]", "", FK_GetIDR(cmbPrCatagory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDR(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDR(cmbCostCenter.Text))

        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
        Dim StrGender As String = IIf(cmbGender.Text = "[ALL]", "", FK_GetIDR(cmbGender.Text))
        Dim StrEmpType As String = IIf(cmbEmpType.Text = "[ALL]", "", FK_GetIDR(cmbEmpType.Text))
        Dim StrReligion As String = IIf(cmbReligion.Text = "[ALL]", "", FK_GetIDR(cmbReligion.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun >*********************************

        sSQL = "SELECT 'true',dbo.tblPayEmpMRecords.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayEmpMRecords.DispName, dbo.tblPayEmpMRecords.EmIdNum, " &
        "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary, " &
        "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc FROM " &
        "dbo.tblPayEmpMRecords,tblSetCCentre ,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblUL,tblSetEmpType,tblGender,tblSetReligion  " &
        " where dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND" &
        " dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND  " &
        " dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND " &
        " dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND " &
        " dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND " &
        " dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND " &
        " dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND " &
        " dbo.tblPayEmpMRecords.EmpTypeID = dbo.tblSetEmpType.typeID  AND " &
        " dbo.tblPayEmpMRecords.religionID = dbo.tblSetReligion.religID  AND " &
        " dbo.tblPayEmpMRecords.genderID = dbo.tblGender.GenID  AND " &
        " dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND  " &
        " tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND " &
        " tblPayEmpMRecords.status=0 AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayEmpMRecords.SalViewLevel =0) " &
        "AND (dbo.tblPayEmpMRecords.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.DispName LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.EmIdNum LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.EPFNo LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.BasicSalary LIKE '%" & txtSearch.Text & "%') " &
        "AND (dbo.tblCompany.compID LIKE '" & StrCompany & "%' AND  " &
        "dbo.tblDesig.desgID LIKE '" & StrDesigName & "%' AND  " &
        "dbo.tblSetDept.DeptID LIKE '" & StrDeptname & "%' AND  " &
        "dbo.tblSetEmpCategory.catID LIKE '" & StrSubCatName & "%' AND  " &
        "dbo.tblSetCCentre.cntID LIKE '" & StrCostC & "%' AND  " &
        "dbo.tblCBranchs.brID LIKE '" & StrBranchName & "%' AND  " &
        "dbo.tblSetEmpType.typeID LIKE '" & StrEmpType & "%' AND  " &
        "dbo.tblGender.genID LIKE '" & StrGender & "%' AND  " &
        "dbo.tblSetReligion.religID LIKE '" & StrReligion & "%' AND  " &
        "dbo.tblSetPCentre.pID LIKE '" & StrPayC & "%' AND  " &
        "tblSetPrCategory.CatID LIKE '" & StrPrCategorya & "%') " &
        " AND tblPayEmpMRecords.cYear=" & cmbYear.Text & " AND tblPayEmpMRecords.cMonth=" & cmbMonth.Text & " ORDER BY " & strQuery
        FK_LoadGrid(sSQL, dgvSearchK)
        clr_Grid(dgvSearchK)
        For X = 0 To dgvSearchK.Columns.Count - 1
            'dgvSearchK.Columns(X).HeaderText = UCase(dgvSearchK.Columns(X).HeaderText)
            dgvSearchK.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        dgvSearchK.Columns(1).Visible = False
        If isViewBasic = 0 Then dgvSearchK.Columns(8).Visible = False
        lblCount.Text = "Total Employees : " & dgvSearchK.RowCount

    End Sub

    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrCatagory.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignation.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbbranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbranch.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartment.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbPayCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPayCenter.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbCostCenter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCostCenter.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbSubCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubCategory.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        SearchEmployee()
    End Sub

    Private Sub chkTick_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTick.CheckedChanged
        For i = 0 To dgvSearchK.RowCount - 1
            dgvSearchK.Item(0, i).Value = chkTick.CheckState
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            sSQL = "DROP TABLE tblKPay;" : FK_EQ(sSQL, "P", "", False, False, False)
            sSQL = "CREATE TABLE tblKPay ([RegID] [nvarchar](10) NULL,[EmpNo] [nvarchar](10) NULL,[EpfNo] [nvarchar](10) NULL,[EnrolNo] [numeric](18, 0) NOT NULL,[RegDate] [datetime] NULL,[dispName] [nvarchar](60) NULL,[NICNumber] [nvarchar](10) NULL,[DofB] [datetime] NULL,[homePhone] [nvarchar](12) NULL,[pMobile] [nvarchar](12) NULL,[OfficePhone] [nvarchar](12) NULL,[Email] [nvarchar](40) NULL,[stDesc] [nvarchar](20) NULL,[GenDesc] [nvarchar](10) NULL,[desgDesc] [nvarchar](30) NULL,[DeptName] [nvarchar](50) NULL,[tDesc] [nvarchar](30) NULL,[BasicSalary] [numeric](18, 2) NULL,[Oldness in Days] [int] NULL) ; INSERT INTO tblKPay SELECT    dbo.tblEmployee.RegID,dbo.tblEmployee.EmpNo, dbo.tblEmployee.EpfNo, dbo.tblEmployee.EnrolNo, dbo.tblEmployee.RegDate, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.DofB,  dbo.tblEmployee.homePhone, dbo.tblEmployee.pMobile, dbo.tblEmployee.OfficePhone, dbo.tblEmployee.Email, dbo.tblCivilStatus.stDesc, dbo.tblGender.GenDesc, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblSetEmpType.tDesc, dbo.tblPayrollEmployee.BasicSalary,datediff(day,tblEmployee.RegDate,getdate ()) as 'Oldness in Days' FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblCivilStatus ON dbo.tblEmployee.CivilStID = dbo.tblCivilStatus.StID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER  JOIN dbo.tblGender ON dbo.tblEmployee.GenderID = dbo.tblGender.GenID LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER  JOIN  dbo.tblSetEmpType ON dbo.tblEmployee.EmpTypeID = dbo.tblSetEmpType.TypeID LEFT OUTER  JOIN dbo.tblPayrollEmployee ON dbo.tblEmployee.RegID = dbo.tblPayrollEmployee.RegID WHERE tblEmployee.compID = '001' AND tblEmployee.empStatus <> 9 " : FK_EQ(sSQL, "P", "", False, False, True)
            'tblAttBasedIndiFixedField
            'Dim strPart As String = "A_"
            sSQL = "SELECT DISTINCT tblSalaryItems.Description,tblSalaryItems.ID  FROM tblAttBasedIndiFixedField INNER JOIN  tblSalaryItems ON tblSalaryItems.ID=tblAttBasedIndiFixedField.salID"
            Load_InformationtoGrid(sSQL, dgvColumn, 2)
            sSQL = ""
            Dim intSalIDK As Integer = 0
            For i As Integer = 0 To dgvColumn.RowCount - 1
                If dgvColumn.RowCount < 1 Then Exit Sub
                'sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Replace(sSQL1, " ", "")
                sSQL1 = Replace(sSQL1, "/", "")
                sSQL1 = Replace(sSQL1, ".", "")
                sSQL1 = Replace(sSQL1, "&", "")
                sSQL1 = Replace(sSQL1, "'", "")
                If sSQL1 <> "" Then
                    sSQL = sSQL & "ALTER TABLE tblKPay ADD " & sSQL1 & " NUMERIC (18,2) NOT NULL DEFAULT 0;"
                End If
            Next
            FK_EQ(sSQL, "P", "", False, False, True)

            sSQL = ""
            For i As Integer = 0 To dgvColumn.RowCount - 1
                If dgvColumn.RowCount < 1 Then Exit Sub
                'sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Replace(sSQL1, " ", "")
                intSalIDK = Val(dgvColumn.Item(1, i).Value)
                sSQL1 = Replace(sSQL1, "/", "")
                sSQL1 = Replace(sSQL1, ".", "")
                sSQL1 = Replace(sSQL1, "&", "")
                sSQL1 = Replace(sSQL1, "'", "")
                If sSQL1 <> "" Then
                    sSQL = sSQL & "UPDATE tblKPay SET tblKPay." & sSQL1 & "=tblAttBasedIndiFixedField.Amount FROM tblKPay,tblAttBasedIndiFixedField WHERE tblKPay.RegID=tblAttBasedIndiFixedField.RegID and tblAttBasedIndiFixedField.salid=" & intSalIDK & " "
                End If
            Next
            FK_EQ(sSQL, "P", "", False, False, False)

            'tblIndiFixedFields
            'strPart = "F_"
            dgvColumn.Rows.Clear()
            sSQL = "SELECT DISTINCT tblSalaryItems.Description,tblSalaryItems.ID  FROM tblIndiFixedFields INNER JOIN  tblSalaryItems ON tblSalaryItems.ID=tblIndiFixedFields.salID"
            Load_InformationtoGridNoClr(sSQL, dgvColumn, 2)

            sSQL = ""
            For i As Integer = 0 To dgvColumn.RowCount - 1
                If dgvColumn.RowCount < 1 Then Exit Sub
                'sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Replace(sSQL1, " ", "")
                sSQL1 = Replace(sSQL1, "/", "")
                sSQL1 = Replace(sSQL1, ".", "")
                sSQL1 = Replace(sSQL1, "&", "")
                sSQL1 = Replace(sSQL1, "'", "")
                If sSQL1 <> "" Then
                    sSQL = sSQL & "ALTER TABLE tblKPay ADD " & sSQL1 & " NUMERIC (18,2) NOT NULL DEFAULT 0;"
                End If
            Next
            FK_EQ(sSQL, "P", "", False, False, True)

            sSQL = ""
            For i As Integer = 0 To dgvColumn.RowCount - 1
                If dgvColumn.RowCount < 1 Then Exit Sub
                'sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Trim(dgvColumn.Item(0, i).Value)
                sSQL1 = Replace(sSQL1, " ", "")
                intSalIDK = Val(dgvColumn.Item(1, i).Value)
                sSQL1 = Replace(sSQL1, "/", "")
                sSQL1 = Replace(sSQL1, ".", "")
                sSQL1 = Replace(sSQL1, "&", "")
                sSQL1 = Replace(sSQL1, "'", "")
                If sSQL1 <> "" Then
                    sSQL = sSQL & " UPDATE tblKPay SET tblKPay." & sSQL1 & "=tblIndiFixedFields.Amount FROM tblKPay,tblIndiFixedFields WHERE tblKPay.RegID=tblIndiFixedFields.RegID and tblIndiFixedFields.salid=" & intSalIDK & ""
                End If
            Next
            FK_EQ(sSQL, "P", "", False, False, False)

            sSQL = "SELECT * FROM tblKPay"
            Fk_FillGrid(sSQL, dgvLeave)
            clr_Grid(dgvLeave)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub rdPermanant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPermanant.CheckedChanged
        If rdTemporary.Checked = True Then
            sSQL = "Select distinct cMonth from tblSD order by cMonth" ' where cYear='" & intCurrentYear & "'"
        Else
            sSQL = "Select distinct cmonth from tblSDAll order by cMonth" ' where cYear='" & intCurrentYear & "'"
        End If
        FillCom2(cmbMonth, sSQL)
        cmbMonth.SelectedIndex = 0
        LoadCombo()
    End Sub

    Private Sub LoadCombo()
        If rdTemporary.Checked Then
            sSQL = "Select distinct cYear from tblSD"
            FillCom2(cmbYear, sSQL)
            cmbYear.SelectedIndex = 0
        Else
            sSQL = "Select distinct cYear from tblSDAll"
            FillCom2(cmbYear, sSQL)
            cmbYear.SelectedIndex = 0
        End If
    End Sub

    Private Sub rdTemporary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTemporary.CheckedChanged
        'LoadCombo()
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbYear.Text <> "" And cmbMonth.Text <> "" Then
            Dim intLstDay As Integer = System.DateTime.DaysInMonth(cmbYear.Text, cmbMonth.Text)
            DateSerial(cmbYear.Text, cmbMonth.Text, intLstDay)
            SearchEmployee()
        End If
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If cmbYear.Text <> "" And cmbMonth.Text <> "" Then
            Dim intLstDay As Integer = System.DateTime.DaysInMonth(cmbYear.Text, cmbMonth.Text)
            dtpPayDate.Value = DateSerial(cmbYear.Text, cmbMonth.Text, intLstDay)
            SearchEmployee()
        End If
    End Sub

    Private Sub rdbPayslip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPayslip.Click
        isWithLogo = GetVal("SELECT isWithLogo FROM tblCompany WHERE CompID='" & StrCompID & "'")
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpType.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbReligion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReligion.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub dgvColumn_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvColumn.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        LoadForm(New frmBusiness)
    End Sub

End Class