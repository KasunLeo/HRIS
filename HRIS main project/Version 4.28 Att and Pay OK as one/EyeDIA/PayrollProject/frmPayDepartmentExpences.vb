Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmDepartmentExpences

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
            'sSQL = "Create table tblTempRegID (RegID varchar (15),cYear Decimal(18,0) not null Default 0,cMonth Decimal(18,0) not null Default 0)"
            'EQ(sSQL)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next

        saveFilteredToTemp()
        Me.Cursor = Cursors.WaitCursor
        'dgv.Columns.Clear()
        dgv.Rows.Clear()
        sSQL = "Select Item,ItemID,Type1,Format from tblSalarySheetStructure where SheetID='" & FK_GetIDR(cmbSalarySheet.Text) & "'   order by IOD"
        Fk_FillGrid(sSQL, dgv)
        sSQL = "Select Distinct (DeptID) from tblpayempmrecords where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and PrcatID='" & FK_GetIDR(cmbProcessCategory.Text) & "' and Status='0' and  RegID in (Select RegID from tblTempRegID) order by DeptID asc"
        Fk_FillGrid(sSQL, frmMainAttendance.dgvFillGridforRead)
        Dim TotDept = frmMainAttendance.dgvFillGridforRead.RowCount
        Dim sPages = TotDept \ 5 + 1
        ' dgvDept.Columns.Clear()
        dgvDept.Rows.Clear()
        For i = 1 To sPages
            dgvDept.Rows.Add(i, "", "", "", "", "")
        Next

        Dim X, Y As Int32
        X = 1 : Y = 0

        If frmMainAttendance.dgvFillGridforRead.RowCount = 0 Then MsgBox("Error") : Exit Sub
        For i = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1

            dgvDept.Item(X, Y).Value = frmMainAttendance.dgvFillGridforRead.Item(0, i).Value
            X = X + 1
            If X = 6 Then
                Y = Y + 1
                X = 1
            End If
        Next
        sSQL = "Delete from tblDeptSum"
        For X = 0 To dgvDept.RowCount - 1
            For I = 0 To dgv.RowCount - 1
                Dim sFormat As String = dgv.Item(3, I).Value

                sSQL = sSQL & " Insert into tblDeptSum (PageNo,item,ItemID,Type1,Format,Dept1,Amount1,Dept2,Amount2,Dept3,Amount3,Dept4,Amount4,Dept5,Amount5) values('" & dgvDept.Item(0, X).Value & "','" & dgv.Item(0, I).Value & "','" & dgv.Item(1, I).Value & "','" & dgv.Item(2, I).Value & "','" & FK_GetID(sFormat) & "','" & dgvDept.Item(1, X).Value & "','0','" & dgvDept.Item(2, X).Value & "','0','" & dgvDept.Item(3, X).Value & "','0','" & dgvDept.Item(4, X).Value & "','0','" & dgvDept.Item(5, X).Value & "','0'  );"
            Next
        Next

        FK_EQ(sSQL, "S", "", False, False, True)
        'Exit Sub
        sSQL = "Delete from tbldeptSummery; "

        For X = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
            For I = 0 To dgv.RowCount - 1
                sSQL = sSQL & " Insert into tbldeptSummery (DeptID,SalID,Type1) values ('" & frmMainAttendance.dgvFillGridforRead.Item(0, X).Value & "','" & dgv.Item(1, I).Value & "','" & dgv.Item(2, I).Value & "') ; "
            Next
        Next
        FK_EQ(sSQL, "S", "", False, False, True)

        If rdTemporary.Checked = True Then
            sSQL = "CREATE TABLE #Tbl (DeptID Nvarchar (10),Type1 Nvarchar (10),SalID Nvarchar (10),Amount Numeric (18,2)) INSERT INTO #Tbl select tblPayrollEmployee.DeptID,tblSD.Type1,tblSD.SalID,CASE WHEN SUM(tblSD.Amount) Is Null THEN 0 ELSE SUM(tblSD.Amount)  END FROM tblPayrollEmployee,tblSD where tblPayrollEmployee.RegID=tblSD.regID  AND   tblSd.cYear='" & cmbYear.Text & "' and tblSD.cMonth='" & cmbMonth.Text & "' and tblPayrollEmployee.PrcatID='" & FK_GetIDR(cmbProcessCategory.Text) & "' and tblPayrollEmployee.RegID in (Select RegID from tblTempRegID) GROUP BY tblPayrollEmployee.DeptID,tblSD.Type1,tblSD.SalID,tblPayrollEmployee.PrcatID Order By Type1,tblSD.SalID  UPDATE tbldeptSummery SET tbldeptSummery.Amount = #Tbl.Amount  FROM tbldeptSummery,#Tbl WHERE tbldeptSummery.DeptID = #Tbl.DeptID AND tbldeptSummery.SalID = #Tbl.SalID AND tbldeptSummery.Type1 = #Tbl.Type1 "
        Else
            sSQL = "CREATE TABLE #Tbl (DeptID Nvarchar (10),Type1 Nvarchar (10),SalID Nvarchar (10),Amount Numeric (18,2))" & _
            "CREATE TABLE #tblSDAll (RegID NVARCHAR (7),type1 numeric (18,0),salid NVARCHAR(3),amount NUMERIC (18,2),cYear numeric (18,0), cMonth numeric (18,0)); insert into #tblSDAll select regid,type1,salid,amount,cYear,cMonth from tblsdall where tblSDAll.cYear='" & cmbYear.Text & "' and tblsdAll.cMonth='" & cmbMonth.Text & "' and regid in (select regid from tblTempRegID) " & _
            "INSERT INTO #Tbl select tblPayEmpMrecords.DeptID,#tblSDAll.Type1,#tblSDAll.SalID,CASE WHEN SUM(#tblSDAll.Amount) Is Null THEN 0 ELSE SUM(#tblSDAll.Amount)  END FROM tblPayEmpMrecords,#tblSDAll where tblPayEmpMrecords.RegID=#tblSDAll.regID and tblPayEmpMrecords.cYear=#tblSDAll.cYear and tblPayEmpMrecords.cMonth=#tblSDAll.cMonth  AND   #tblSDAll.cYear='" & cmbYear.Text & "' and #tblSDAll.cMonth='" & cmbMonth.Text & "' and tblPayEmpMrecords.PrcatID='" & FK_GetIDR(cmbProcessCategory.Text) & "' and tblPayEmpMrecords.RegID in (Select RegID from tblTempRegID) GROUP BY tblPayEmpMrecords.DeptID,#tblSDAll.Type1,#tblSDAll.SalID,tblPayEmpMrecords.PrcatID Order By Type1,#tblSDAll.SalID UPDATE tbldeptSummery SET tbldeptSummery.Amount = #Tbl.Amount  FROM tbldeptSummery,#Tbl WHERE tbldeptSummery.DeptID = #Tbl.DeptID AND tbldeptSummery.SalID = #Tbl.SalID AND tbldeptSummery.Type1 = #Tbl.Type1 "
        End If

        For X = 1 To 5
            sSQL = sSQL & " update tblDeptSum set Amount" & X & "=tbldeptSummery.Amount from tbldeptSummery inner join tblDeptSum on tblDeptSum.ItemID=tbldeptSummery.SalID and tblDeptSum.Type1=tbldeptSummery.Type1 and tblDeptSum.Dept" & X & "=tbldeptSummery.DeptID "
        Next
        For X = 1 To 5
            sSQL = sSQL & " update  tblDeptSum set Dept" & X & "=tblSetDept.DeptName+'='+DeptID from tblSetDept inner join tblDeptSum on tblDeptSum.Dept" & X & "=tblSetDept.DeptID "
        Next
        FK_EQ(sSQL, "S", "", False, False, True)
        sSQL = "Update tblDeptSum set DeptTotal=Amount1+Amount2+Amount3+Amount4+Amount5;"
        EQ(sSQL)


        For X = 1 To sPages
            sSQL = "Drop table #tbl1;"
            EQ(sSQL)
            sSQL = "Update tblDeptSum set NettTotal=DeptCF+DeptTotal Select PageNo,ItemID,Type1,NettTotal into #tbl1 from tblDeptSum where pageNo='" & X & "';update #tbl1 set PageNo=PageNo+1;update tblDeptSum set DeptCF=#tbl1.NettTotal from #tbl1 inner join tblDeptSum on tblDeptSum.PageNo=#tbl1.PageNo and tblDeptSum.ItemID=#tbl1.ItemID and tblDeptSum.type1=#tbl1.type1 where tblDeptSum.PageNo='" & X + 1 & "'; Update tblDeptSum set NettTotal=DeptCF+DeptTotal"
            FK_EQ(sSQL, "S", "", False, False, True)
        Next

        Me.Cursor = Cursors.Default

        Dim CN As New SqlConnection(sqlConString)
        CN.Open()
        Dim adp As New SqlDataAdapter(sSQL, CN)
        Dim stable As New DS_Report
        adp.Fill(stable, "tblEmployee")
        sSQL = "Select * from tblDeptSum"

        adp = New SqlDataAdapter(sSQL, CN)
        adp.Fill(stable, "tblDeptSum")

        Dim objRpt As New rptDeptSum '- Report Files name here 

        objRpt.Database.Tables("tblDeptSum").SetDataSource(stable.Tables("tblDeptSum"))
        'objRpt.Database.Tables("tblSigSheet").SetDataSource(stable.Tables("tblSigSheet"))

        'objRpt.SetDataSource(DS.Tables("tblpayslips")) ' - Data Set Table Name Here 
        frmRepContainer.crptView.ReportSource = objRpt
        '=================Rajitha.
        objRpt.SetParameterValue("1", cBusiness)
        'objRpt.SetParameterValue("2", cAddress)
        sSQL = "Department Expenses of Month :" & cmbMonth.Text & "-" & cmbYear.Text & " (" & cmbProcessCategory.Text & ") "
        objRpt.SetParameterValue("2", sSQL)
        '' '' ''objRpt.SetParameterValue("sAdd3", sAdd3)
        '' '' ''objRpt.SetParameterValue("sSalAck", sSalAckn)
        '' '' ''objRpt.SetParameterValue("sPayMnth", sPayMonth)

        '===============
        objRpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFanfoldUS

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

        frmRepContainer.crptView.Refresh()
        frmRepContainer.ShowDialog()

    End Sub

    Private Sub frmPayslipprocess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        intPrcdMonth = fk_sqlDbl("select distinct cmonth from tblsd")
        strPrCategory = fk_RetString("select processategory from tblCompany where compID='" & StrCompID & "'")
        strPrCategory = fk_RetString("select '" & strPrCategory & "'+'='+catid from tblSetPrCategory where catDesc='" & strPrCategory & "'")
        Label12.BackColor = clrFocused
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
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
            FillComboAll(cmbSalarySheet, sSQL)

            FillComboAll(cmbDepartment, "select DeptName + '=' + DeptID from tblsetDept where status=0 order by DeptName asc")
            FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0 order by pDesc asc")
            FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0 order by cntDesc asc")
            'FillComboAll(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
            FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0 order by CName asc")
            FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0 order by BrName asc")
            FillComboAll(cmbDesignation, "Select DesgDesc + '=' + DesgID from tblDesig where status=0 order by DesgDesc asc")
            FillComboAll(cmbProcessCategory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0 order by CatDesc asc")
            FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc asc")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
            FillComboAll(cmbEmpType, "select tDesc + '=' +TypeID from tblSetEmpType WHERE Status=0 ORDER BY tDesc")
            FillComboAll(cmbGender, "select GenDesc + '=' + genID from tblGender WHERE Status=0 ORDER BY GenDesc")
            FillComboAll(cmbReligion, "select ReligDesc + '=' + ReligID from tblSetReligion WHERE Status=0 ORDER BY ReligDesc")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************

            LoadHistory()


            cmbProcessCategory.Text = strPrCategory
            chkTick.Checked = True
            isWithLogo = GetVal("SELECT isWithLogo FROM tblCompany WHERE CompID='" & StrCompID & "'")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub LoadHistory()
        Try
            sSQL = "SELECT rName,cyear,cmonth,salid,rdButton FROM tblreportparameters where rid='" & StrReportID & "'"
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

        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"

        Dim StrDeptname As String = IIf(cmbDepartment.Text = "[ALL]", "", FK_GetIDL(cmbDepartment.Text))
        Dim StrSubCatName As String = IIf(cmbSubCategory.Text = "[ALL]", "", FK_GetIDL(cmbSubCategory.Text))
        Dim StrDesigName As String = IIf(cmbDesignation.Text = "[ALL]", "", FK_GetIDL(cmbDesignation.Text))
        Dim StrBranchName As String = IIf(cmbbranch.Text = "[ALL]", "", FK_GetIDL(cmbbranch.Text))
        Dim StrCompany As String = IIf(cmbCompany.Text = "[ALL]", "", FK_GetIDL(cmbCompany.Text))
        Dim StrPrCategorya As String = IIf(cmbProcessCategory.Text = "[ALL]", "", FK_GetIDL(cmbProcessCategory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDL(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDL(cmbCostCenter.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
        Dim StrGender As String = IIf(cmbGender.Text = "[ALL]", "", FK_GetIDL(cmbGender.Text))
        Dim StrEmpType As String = IIf(cmbEmpType.Text = "[ALL]", "", FK_GetIDL(cmbEmpType.Text))
        Dim StrReligion As String = IIf(cmbReligion.Text = "[ALL]", "", FK_GetIDL(cmbReligion.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun >*********************************

        sSQL = "SELECT     'true',dbo.tblPayEmpMRecords.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayEmpMRecords.DispName, dbo.tblPayEmpMRecords.EmIdNum, " &
        "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary, " &
        "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM   " &
        "dbo.tblPayEmpMRecords,tblSetCCentre ,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblUL,tblSetEmpType,tblGender,tblSetReligion " &
        " where dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND" &
        " dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND  " &
        " dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND " &
        " dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND " &
        " dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND " &
        " dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND " &
        " dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND " &
        " dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND  " &
        " dbo.tblPayEmpMRecords.EmpTypeID = dbo.tblSetEmpType.typeID  AND " &
        " dbo.tblPayEmpMRecords.religionID = dbo.tblSetReligion.religID  AND " &
        " dbo.tblPayEmpMRecords.genderID = dbo.tblGender.GenID  AND " &
        " tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND " &
        " tblPayEmpMRecords.status=0 AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayEmpMRecords.SalViewLevel =0) " &
        "AND (dbo.tblPayEmpMRecords.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.DispName LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.EmIdNum LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.EPFNo LIKE '%" & txtSearch.Text & "%' OR  " &
        "dbo.tblPayEmpMRecords.BasicSalary LIKE '%" & txtSearch.Text & "%') " &
        "AND (dbo.tblCompany.cName LIKE '" & StrCompany & "%' AND  " &
        "dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND  " &
        "dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND  " &
        "dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND  " &
        "dbo.tblSetCCentre.cntDesc LIKE '" & StrCostC & "%' AND  " &
        "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND  " &
        "dbo.tblSetEmpType.tDesc LIKE '" & StrEmpType & "%' AND  " &
        "dbo.tblGender.genDesc LIKE '" & StrGender & "%' AND  " &
        "dbo.tblSetReligion.religDesc LIKE '" & StrReligion & "%' AND  " &
        "dbo.tblSetPCentre.pDesc LIKE '" & StrPayC & "%' AND  " &
        "tblSetPrCategory.CatDesc LIKE '" & StrPrCategorya & "%') " &
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

    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcessCategory.SelectedIndexChanged
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

    Private Sub rdPermanant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdPermanant.CheckedChanged
        If rdTemporary.Checked = True Then
            sSQL = "Select distinct cMonth from tblSD order by cMonth" ' where cYear='" & intCurrentYear & "'"
        Else
            sSQL = "Select distinct cmonth from tblSDAll order by cMonth" ' where cYear='" & intCurrentYear & "'"
        End If
        FillComboAll(cmbMonth, sSQL)
        cmbMonth.SelectedIndex = 0
        LoadCombo()
    End Sub

    Private Sub LoadCombo()
        If rdTemporary.Checked Then
            sSQL = "Select distinct cYear from tblSD"
            FillComboAll(cmbYear, sSQL)
            cmbYear.SelectedIndex = 0
        Else
            sSQL = "Select distinct cYear from tblSDAll"
            FillComboAll(cmbYear, sSQL)
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

    Private Sub cmbGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpType.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub cmbReligion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbReligion.SelectedIndexChanged
        SearchEmployee()
    End Sub

End Class