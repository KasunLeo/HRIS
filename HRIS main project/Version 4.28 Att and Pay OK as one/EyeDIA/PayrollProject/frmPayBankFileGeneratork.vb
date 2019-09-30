Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class frmBankFileGeneratork

    Dim sTable As String = "tblSD"
    Dim bolTicked As Boolean = False

    Private Sub frmCoinSummery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        intPrcdMonth = fk_sqlDbl("select distinct cmonth from tblsd")
        strPrCategory = fk_RetString("select processategory from tblCompany where compID='" & StrCompID & "'")
        Label12.BackColor = clrFocused
        cmdRefresh_Click(sender, e)
        'If isSummaryToSLIP = 0 Then
        '    chkSummaryToSlip.Visible = False
        'End If
    End Sub

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

    'ultimate programming tutorials
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LoadCombo()

        sSQL = "Select distinct cYear from tblSDAll"
        FillCom2(cmbYear, sSQL)
    End Sub

    Private Sub rd1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadCombo()
    End Sub

    Private Sub rd2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

       
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New FrmFilterEmployees)
    End Sub

    Private Sub AllSummary()
        Try
            sSQL = " Select * from tblMoneyCat where status='0' "
            Dim CN As New SqlConnection(sqlConString)
            CN.Open()
            Dim adp As New SqlDataAdapter(sSQL, CN)
            Dim stable As New DataSet
            adp.Fill(stable, "tblMoneyCat")
            sSQL = " Select * from tblcs2 "
            adp = New SqlDataAdapter(sSQL, CN)
            adp.Fill(stable, "tblcs2")
            Dim objRpt As New rptCaoinSummeryBankReport

            objRpt.Database.Tables("tblMoneyCat").SetDataSource(stable.Tables("tblMoneyCat"))
            objRpt.Database.Tables("tblcs2").SetDataSource(stable.Tables("tblcs2"))

            objRpt.SetParameterValue("1", cBusiness)
            objRpt.SetParameterValue("2", cAddress)
            sSQL = "Coin Analysis Report of : " & MonthName(Val(cmbMonth.Text)) & "-" & cmbYear.Text
            objRpt.SetParameterValue("3", sSQL)
            frmRepContainer.crptView.ReportSource = objRpt
            frmRepContainer.crptView.Refresh()
            frmRepContainer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Try
            cmbYear.Text = Now.Year
            cmbMonth.Items.Clear()
            For X = 1 To 12
                cmbMonth.Items.Add(X)
            Next
            cmbMonth.Text = Now.Month
            cmbMonth.Text = Now.Date.Month
            For X = Now.Date.Year - 5 To Now.Date.Year + 5
                cmbYear.Items.Add(X)
            Next
            cmbYear.Text = Now.Date.Year
            sSQL = "Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   Status='0' AND ID IN (select distinct salid from tblsdAll)   order by Description asc"
            FillCom2(CmdSalField, sSQL)

            FillComboAll(cmbDepartment, "select DeptName + '=' + DeptID from tblsetDept where status=0")
            FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0")
            FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0")
            'FillCombo(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
            FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0")
            FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0")
            FillComboAll(cmbDesignation, "Select DesgDesc + '=' + DesgID from tblDesig where status=0")
            FillComboAll(cmbPrCatagory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0")
            FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0")
            FillComboAll(cmbTrCode, "Select TrDesc+'='+trid from tblSetBnkTransaction ")
            FillComboAll(cmbOrigBank, "Select HName+'='+ID from tblbankHead where Status='0'")

            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
            FillComboAll(cmbEmpType, "select tDesc + '=' +TypeID from tblSetEmpType WHERE Status=0 ORDER BY tDesc")
            FillComboAll(cmbGender, "select GenDesc + '=' + genID from tblGender WHERE Status=0 ORDER BY GenDesc")
            FillComboAll(cmbReligion, "select ReligDesc + '=' + ReligID from tblSetReligion WHERE Status=0 ORDER BY ReligDesc")
            'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************


            'txtSearch.Text = strPrCategory
            'txtSearch.Text = ""
            'cmbMonth.Text = intPrcdMonth
            'rd1_CheckedChanged(sender, e)
            Dim ctrl As Control
            For Each ctrl In GroupBox1.Controls
                If TypeOf ctrl Is ComboBox Then
                    ctrl.Text = ""
                End If
            Next
            chkTick.Checked = True
            rdbCom.Checked = True
            rdTemporary.Checked = True

            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "Register ID" Else If strReportBased = "02" Then strQuery = "EPF No" Else If strReportBased = "03" Then strQuery = "ETP No" Else If strReportBased = "04" Then strQuery = "EMP No"
            txtParti.Text = "SALARY "
            lblCountH.Text = ""
            lblLoanAmount.Visible = False
            lblLoanCount.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        dtpLoanStatrfrom.Enabled = False
        lblLoan.Enabled = False
        LoadHistory()

        dgvSearchK.Height = 235
        dgvSearchK.Width = 992
        dgvSearchK.Location = New Point(0, 147)

        dgvData.Height = 0
        dgvData.Width = 992
        dgvData.Location = New Point(0, 150)
    End Sub

    Public Sub LoadHistory()
        Try
            StrReportID = "54"
            sSQL = "SELECT rName,cyear,cmonth,salid,rdButton FROM tblreportparameters where rid='" & StrReportID & "'"
            FK_ReadDB(sSQL)
            cmbYear.Text = FK_Read("cyear")
            cmbMonth.Text = FK_Read("cmonth")
            Dim iSalID As Integer = FK_Read("salid")
            CmdSalField.Text = fk_RetString("Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   id='" & iSalID & "'")
            rName = FK_Read("rName")
            Dim sRdButton As String = FK_Read("rdButton")
            If sRdButton = "T" Then
                rdTemporary.Checked = True
            Else
                rdPermanant.Checked = True
            End If
            cmbTrCode.Text = "Salaries=023"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub SearchEmployee()
        Dim strQuery As String = ""
        'Multiple paying account | 2018-12-12 ***********************
        Dim strMultiAccount As String = ""
        If chkMultiAcc.Checked = True Then
            strMultiAccount = " AND tblPayEmpMRecords.RegID IN (SELECT RegID FROM tblAccNumAssign WHERE AcTypID='" & FK_GetIDR(cmbOrigBank.Text) & "') "
        End If
        If strReportBased = "01" Then strQuery = "tblPayEmpMRecords.RegID" Else If strReportBased = "02" Then strQuery = "tblPayEmpMRecords.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayEmpMRecords.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayEmpMRecords.EMPNo"

        Dim StrDeptname As String = IIf(cmbDepartment.Text = "[ALL]", "", FK_GetIDL(cmbDepartment.Text))
        Dim StrSubCatName As String = IIf(cmbSubCategory.Text = "[ALL]", "", FK_GetIDL(cmbSubCategory.Text))
        Dim StrDesigName As String = IIf(cmbDesignation.Text = "[ALL]", "", FK_GetIDL(cmbDesignation.Text))
        Dim StrBranchName As String = IIf(cmbbranch.Text = "[ALL]", "", FK_GetIDL(cmbbranch.Text))
        Dim StrCompany As String = IIf(cmbCompany.Text = "[ALL]", "", FK_GetIDL(cmbCompany.Text))
        Dim StrPrCategorya As String = IIf(cmbPrCatagory.Text = "[ALL]", "", FK_GetIDL(cmbPrCatagory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDL(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDL(cmbCostCenter.Text))
        Dim StrBankID As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDR(cmbCostCenter.Text))
        Dim StrBranchID As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDR(cmbCostCenter.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun <*********************************
        Dim StrGender As String = IIf(cmbGender.Text = "[ALL]", "", FK_GetIDL(cmbGender.Text))
        Dim StrEmpType As String = IIf(cmbEmpType.Text = "[ALL]", "", FK_GetIDL(cmbEmpType.Text))
        Dim StrReligion As String = IIf(cmbReligion.Text = "[ALL]", "", FK_GetIDL(cmbReligion.Text))
        'Added new search options gender,type and religion wise | 2019-01-23 | Kasun >*********************************

        sSQL = "SELECT     'true',dbo.tblPayEmpMRecords.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayEmpMRecords.DispName, dbo.tblPayEmpMRecords.EmIdNum, " & _
        "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary, " & _
        "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc,tblPayrollEmployee.accNumber,tblPayrollEmployee.BankID,tblPayrollEmployee.BranchID  FROM " & _
        "dbo.tblPayEmpMRecords,tblSetCCentre ,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblPayrollEmployee,tblUL,tblSetEmpType,tblGender,tblSetReligion  " & _
        " where dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND" & _
        " dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND  " & _
        " dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND " & _
        " dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND " & _
        " dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND " & _
        " dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND " & _
        " dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND " & _
        " dbo.tblPayEmpMRecords.RegID= dbo.tblPayrollEmployee.RegID AND " & _
        " dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND   " & _
        " tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND " & _
        " dbo.tblPayEmpMRecords.EmpTypeID = dbo.tblSetEmpType.typeID  AND " & _
        " dbo.tblPayEmpMRecords.religionID = dbo.tblSetReligion.religID  AND " & _
        " dbo.tblPayEmpMRecords.genderID = dbo.tblGender.GenID  AND " & _
        " tblPayEmpMRecords.status=0 AND tblPayrollEmployee.finalSalary=1 AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayEmpMRecords.SalViewLevel =0) " & _
        "AND (dbo.tblPayEmpMRecords.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.DispName LIKE '%" & txtSearch.Text & "%' OR  " & _
        "dbo.tblPayEmpMRecords.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblPayEmpMRecords.EmIdNum LIKE '%" & txtSearch.Text & "%' OR  " & _
        "dbo.tblPayEmpMRecords.EPFNo LIKE '%" & txtSearch.Text & "%' OR  " & _
        "dbo.tblPayEmpMRecords.BasicSalary LIKE '%" & txtSearch.Text & "%') " & _
        "AND (dbo.tblCompany.cName LIKE '" & StrCompany & "%' AND  " & _
        "dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND  " & _
        "dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND  " & _
        "dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND  " & _
        "dbo.tblSetCCentre.cntDesc LIKE '" & StrCostC & "%' AND  " & _
        "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND  " & _
        "dbo.tblSetEmpType.tDesc LIKE '" & StrEmpType & "%' AND  " & _
        "dbo.tblGender.genDesc LIKE '" & StrGender & "%' AND  " & _
        "dbo.tblSetReligion.religDesc LIKE '" & StrReligion & "%' AND  " & _
        "dbo.tblSetPCentre.pDesc LIKE '" & StrPayC & "%' AND  " & _
        "tblSetPrCategory.CatDesc LIKE '" & StrPrCategorya & "%') " & _
        " AND tblPayEmpMRecords.cYear=" & cmbYear.Text & " AND tblPayEmpMRecords.cMonth=" & cmbMonth.Text & " " & strMultiAccount & " ORDER BY " & strQuery
        FK_LoadGrid(sSQL, dgvSearchK)
        clr_Grid(dgvSearchK)

        ' "dbo.tblPayrollEmployee.BankID LIKE '" & StrBankID & "%' AND  " & _
        '"dbo.tblPayrollEmployee.BranchID LIKE '" & StrBranchID & "%' AND  " & _

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

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbYear.Text <> "" And cmbMonth.Text <> "" Then
            SearchEmployee()
        End If
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If cmbYear.Text <> "" And cmbMonth.Text <> "" Then
            SearchEmployee()
        End If
    End Sub

    Public Sub TextGeneratorHNB()
        SFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "HNB" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
        Dim myStream As System.IO.Stream
        Dim bolEr As Boolean = False
        If SFD.ShowDialog() = DialogResult.OK Then

            myStream = SFD.OpenFile()

            If (myStream IsNot Nothing) Then
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(myStream)
                    Try
                        PB.Value = 0
                        PB.Maximum = dgvData.RowCount
                        Dim strOriBankID As String = "" : Dim strOriBranchID As String = "" : Dim strOriAccNo As String = "" : Dim strOriAccName As String = "" : Dim strDate As String = ""
                        fk_Return_MultyString("SELECT OrigiBankNo,OrigiBranchNo,OrigiAccNo,OrigiAccName FROM tblbankHead WHERE ID='" & FK_GetIDR(cmbOrigBank.Text) & "'", 4)
                        strOriBankID = fk_ReadGRID(0)
                        strOriBranchID = fk_ReadGRID(1)
                        strOriAccNo = fk_ReadGRID(2)
                        strOriAccName = fk_ReadGRID(3)
                        strDate = Format(dtpPayDate.Value, "yyMMdd")
                        Dim strTotal As String = fk_sqlDbl("select SUM (CONVERT(numeric (18,2),amount))*100 from tblBankfileData where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)")
                        strTotal = strTotal.PadLeft(11, "0")
                        Dim strHashTotal As String = fk_sqlDbl("SELECT SUM (CONVERT(decimal,accNumber)) FROM tblBankfileData where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)")
                        strHashTotal = strTotal.PadLeft(14, "0")
                        Dim strTrCount As String = fk_sqlDbl("SELECT  count(*) FROM tblBankfileData where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)")
                        strTrCount = strTrCount.PadLeft(5, "0")
                        Dim strTrCode As String = "223"

                        Dim sstrFirst As String = strOriAccName & strTotal & strOriAccNo & strDate & strHashTotal & strTrCount & strOriBankID & strOriBranchID & strTrCode & vbNewLine : sw.Write(sstrFirst)
                        For X = 0 To dgvData.RowCount - 1
                            If dgvData.Item(0, X).Value <> "" Then
                                PB.Value = X
                                Dim trID As String = dgvData.Item(0, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                Dim accName As String = dgvData.Item(1, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)
                                Dim bankCode As String = dgvData.Item(2, X).Value 'StrDup(20 - Len(dgv.Item(4, X).Value.ToString), " ") & dgv.Item(4, X).Value.ToString
                                Dim branchCode As String = dgvData.Item(3, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                Dim DaccNo As String = Trim(dgvData.Item(4, X).Value) 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                Dim trCode As String = dgvData.Item(5, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                Dim amount As String = dgvData.Item(6, X).Value
                                Dim datek As String = dgvData.Item(7, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                Dim particular As String = dgvData.Item(8, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString

                                trID = trID.PadLeft(8, "0")
                                accName = accName.PadRight(20, " ")
                                bankCode = bankCode.PadRight(4, "0")
                                branchCode = branchCode.PadRight(3, "0")
                                DaccNo = DaccNo.PadLeft(12, "0")
                                trCode = trCode.PadRight(3, "0")
                                amount = amount.PadLeft(11, "0")
                                datek = datek.PadRight(6, "0")
                                particular = particular.PadLeft(13, "0")

                                Dim sstr As String = trID & accName & bankCode & branchCode & DaccNo & trCode & amount & datek & particular & vbNewLine : sw.Write(sstr)
                            End If
                        Next
                        Dim strLastRow As String = "00000000000000000000000000000000000000000000000000000000000000000000000000000000" : sw.Write(strLastRow)

                    Catch ex As Exception
                        bolEr = True
                        MsgBox(ex.Message)
                    End Try
                    sw.Close()
                End Using
                myStream.Close()
                '''''''''''''''''For X = 0 To dgv2.RowCount - 1
            End If
        End If

        If bolEr = False Then MessageBox.Show("The Bank Detail Text file has successfully generated in " & SFD.FileName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        If GetVal("SELECT isAutoMail FROM tblCompany WHERE CompID='" & StrCompID & "'") = 1 Then
            'strAttachment = SFD.FileName
            'LoadForm(New AutoEmail)
        End If

    End Sub

    Public Sub TextGeneratorPeople()
        SFD.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "People" & Format(Now, "ddMMyyyy hhmmsstt") & ".dat"
        Dim myStream As System.IO.Stream
        Dim bolEr As Boolean = False
        If SFD.ShowDialog() = DialogResult.OK Then

            myStream = SFD.OpenFile()

            Dim filler1 As String : Dim filler2 As String : Dim filler3 As String : Dim filler4 As String : Dim filler5 As String : Dim SLR As String
            Dim accName As String : Dim bankCode As String : Dim branchCode As String : Dim DaccNo As String : Dim amount As String : Dim OriBankID As String
            Dim OriBranchID As String : Dim OriAccNo As String : Dim OriAccName As String : Dim particular As String : Dim reference As String : Dim datek As String : Dim atSign As String
            If (myStream IsNot Nothing) Then
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(myStream)
                    Try
                        PB.Value = 0
                        PB.Maximum = dgvData.RowCount
                        For X = 0 To dgvData.RowCount - 1
                            If dgvData.Item(0, X).Value <> "" Then
                                PB.Value = X
                                filler1 = dgvData.Item(3, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler2 = dgvData.Item(6, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler3 = dgvData.Item(7, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler4 = dgvData.Item(12, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler5 = dgvData.Item(13, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                accName = dgvData.Item(5, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)
                                bankCode = dgvData.Item(1, X).Value 'StrDup(20 - Len(dgv.Item(4, X).Value.ToString), " ") & dgv.Item(4, X).Value.ToString
                                amount = dgvData.Item(8, X).Value
                                particular = dgvData.Item(9, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                reference = dgvData.Item(10, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                datek = dgvData.Item(11, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                branchCode = dgvData.Item(2, X).Value
                                DaccNo = dgvData.Item(4, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)

                                filler1 = filler1.PadLeft(3, "0")
                                filler2 = filler2.PadLeft(2, "0")
                                filler3 = filler3.PadLeft(1, "0")
                                filler4 = filler4.PadLeft(6, "0")
                                filler5 = filler5.PadLeft(29, " ")
                                accName = accName.PadRight(20, " ")
                                bankCode = bankCode.PadRight(4, "0")
                                branchCode = branchCode.PadRight(2, "0")
                                amount = amount.PadLeft(12, "0")
                                particular = particular.PadLeft(15, " ")
                                reference = reference.PadLeft(15, " ")
                                datek = datek.PadRight(6, "0")
                                DaccNo = DaccNo.PadLeft(12, "0")

                                Dim sstr As String = bankCode & branchCode & filler1 & DaccNo & accName & filler2 & filler3 & amount & particular & reference & datek & filler4 & filler5 & vbNewLine
                                sw.Write(sstr)

                            End If
                        Next

                        filler4 = "1"
                        particular = "               "
                        sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
                        Dim strTotal As String = fk_sqlDbl(sSQL)
                        'dblTotal = Format(dblTotal, "#.00")
                        strTotal = Replace(strTotal, ".", "").PadLeft(12, "0")
                        'Dim strLast As String = filler1 & OriBankID & OriBranchID & OriAccNo & OriAccName & filler2 & filler3 & filler4 & filler5 & strTotal & SLR & OriBankID & OriBranchID & OriAccNo & OriAccName & particular & reference & datek & atSign & vbNewLine : sw.Write(strLast)

                    Catch ex As Exception
                        bolEr = True
                        MsgBox(ex.Message)
                    End Try
                    sw.Close()
                End Using
                myStream.Close()
                '''''''''''''''''For X = 0 To dgv2.RowCount - 1
            End If
        End If

        If bolEr = False Then MessageBox.Show("The Salary ToBank DAT file has successfully generated in " & SFD.FileName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'SalAdPercen = GetVal("SELECT isAutoMail FROM tblCompany WHERE CompID='" & StrCompID & "'")

    End Sub

    Public Sub TextGeneratorBOC()
        SFD.Filter = "dat files (*.txt)|*.txt|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "BOC" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
        Dim myStream As System.IO.Stream
        Dim bolEr As Boolean = False
        If SFD.ShowDialog() = DialogResult.OK Then

            myStream = SFD.OpenFile()

            Dim filler1 As String : Dim filler2 As String : Dim filler3 As String : Dim filler4 As String : Dim filler5 As String : Dim SLR As String
            Dim accName As String : Dim bankCode As String : Dim branchCode As String : Dim DaccNo As String : Dim amount As String : Dim OriBankID As String
            Dim OriBranchID As String : Dim OriAccNo As String : Dim OriAccName As String : Dim particular As String : Dim reference As String : Dim datek As String : Dim atSign As String
            If (myStream IsNot Nothing) Then
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(myStream, System.Text.Encoding.ASCII)
                    Try
                        PB.Value = 0
                        PB.Maximum = dgvData.RowCount
                        For X = 0 To dgvData.RowCount - 1
                            If dgvData.Item(0, X).Value <> "" Then
                                PB.Value = X
                                filler1 = dgvData.Item(1, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler2 = dgvData.Item(6, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler3 = dgvData.Item(7, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler4 = dgvData.Item(8, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler5 = dgvData.Item(9, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                SLR = dgvData.Item(11, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                accName = dgvData.Item(5, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)
                                bankCode = dgvData.Item(2, X).Value 'StrDup(20 - Len(dgv.Item(4, X).Value.ToString), " ") & dgv.Item(4, X).Value.ToString
                                branchCode = dgvData.Item(3, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                DaccNo = dgvData.Item(4, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                amount = dgvData.Item(10, X).Value
                                OriBankID = dgvData.Item(12, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                OriBranchID = dgvData.Item(13, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                OriAccNo = dgvData.Item(14, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                OriAccName = dgvData.Item(15, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                particular = dgvData.Item(16, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                reference = dgvData.Item(17, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                datek = dgvData.Item(18, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                atSign = dgvData.Item(19, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString

                                filler1 = filler1.PadLeft(4, "0")
                                filler2 = filler2.PadLeft(2, "0")
                                filler3 = filler3.PadLeft(2, "0")
                                filler4 = filler4.PadLeft(1, "0")
                                filler5 = filler5.PadLeft(6, "0")
                                SLR = SLR.PadLeft(3, "0")
                                accName = accName.PadRight(20, " ")
                                bankCode = bankCode.PadRight(4, "0")
                                branchCode = branchCode.PadRight(3, "0")
                                DaccNo = DaccNo.PadLeft(12, "0")
                                amount = amount.PadLeft(12, "0")
                                OriBankID = OriBankID.PadRight(4, "0")
                                OriBranchID = OriBranchID.PadRight(3, "0")
                                OriAccNo = OriAccNo.PadRight(12, "0")
                                OriAccName = OriAccName.PadRight(20, "0")
                                particular = particular.PadRight(15, " ")
                                reference = reference.PadRight(15, " ")
                                datek = datek.PadRight(6, "0")
                                atSign = "000000"

                                Dim sstr As String = filler1 & bankCode & branchCode & DaccNo & accName & filler2 & filler3 & filler4 & filler5 & amount & SLR & OriBankID & OriBranchID & OriAccNo & OriAccName & particular & reference & datek & atSign & vbNewLine
                                sw.Write(sstr)

                            End If
                        Next

                        'filler4 = "1"
                        'particular = "               "


                    Catch ex As Exception
                        bolEr = True
                        MsgBox(ex.Message)
                    End Try
                    sw.Close()
                End Using
                myStream.Close()
                '''''''''''''''''For X = 0 To dgv2.RowCount - 1
            End If
        End If

        If bolEr = False Then MessageBox.Show("The Salary ToBank text file has successfully generated in " & SFD.FileName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'SalAdPercen = GetVal("SELECT isAutoMail FROM tblCompany WHERE CompID='" & StrCompID & "'")

    End Sub

    Public Sub TextGeneratorCommercial()
        SFD.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "Commercial" & Format(Now, "ddMMyyyy hhmmsstt") & ".dat"
        Dim myStream As System.IO.Stream
        Dim bolEr As Boolean = False
        If SFD.ShowDialog() = DialogResult.OK Then

            myStream = SFD.OpenFile()

            Dim filler1 As String : Dim filler2 As String : Dim filler3 As String : Dim filler4 As String : Dim filler5 As String : Dim SLR As String
            Dim accName As String : Dim bankCode As String : Dim branchCode As String : Dim DaccNo As String : Dim amount As String : Dim OriBankID As String
            Dim OriBranchID As String : Dim OriAccNo As String : Dim OriAccName As String : Dim particular As String : Dim reference As String : Dim datek As String : Dim atSign As String
            If (myStream IsNot Nothing) Then
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(myStream)
                    Try
                        PB.Value = 0
                        PB.Maximum = dgvData.RowCount
                        For X = 0 To dgvData.RowCount - 1
                            If dgvData.Item(0, X).Value <> "" Then
                                PB.Value = X
                                filler1 = dgvData.Item(1, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler2 = dgvData.Item(6, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler3 = dgvData.Item(7, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler4 = dgvData.Item(8, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler5 = dgvData.Item(9, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                SLR = dgvData.Item(11, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                accName = dgvData.Item(5, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)
                                bankCode = dgvData.Item(2, X).Value 'StrDup(20 - Len(dgv.Item(4, X).Value.ToString), " ") & dgv.Item(4, X).Value.ToString
                                branchCode = dgvData.Item(3, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                DaccNo = dgvData.Item(4, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                amount = dgvData.Item(10, X).Value
                                OriBankID = dgvData.Item(12, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                OriBranchID = dgvData.Item(13, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                OriAccNo = dgvData.Item(14, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                OriAccName = dgvData.Item(15, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                particular = dgvData.Item(16, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                reference = dgvData.Item(17, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                datek = dgvData.Item(18, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                atSign = dgvData.Item(19, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString

                                filler1 = filler1.PadLeft(4, "0")
                                filler2 = filler2.PadLeft(2, "0")
                                filler3 = filler3.PadLeft(2, "0")
                                filler4 = filler4.PadLeft(1, "0")
                                filler5 = filler5.PadLeft(6, "0")
                                SLR = SLR.PadLeft(3, "0")
                                accName = accName.PadRight(20, " ")
                                bankCode = bankCode.PadRight(4, "0")
                                branchCode = branchCode.PadRight(3, "0")
                                DaccNo = DaccNo.PadLeft(12, "0")
                                amount = amount.PadLeft(12, "0")
                                OriBankID = OriBankID.PadRight(4, "0")
                                OriBranchID = OriBranchID.PadRight(3, "0")
                                OriAccNo = OriAccNo.PadRight(12, "0")
                                OriAccName = OriAccName.PadRight(20, "0")
                                particular = particular.PadLeft(15, " ")
                                reference = reference.PadLeft(15, " ")
                                datek = datek.PadRight(6, "0")
                                atSign = atSign.PadLeft(7, "0")

                                Dim sstr As String = filler1 & bankCode & branchCode & DaccNo & accName & filler2 & filler3 & filler4 & filler5 & amount & SLR & OriBankID & OriBranchID & OriAccNo & OriAccName & particular & reference & datek & atSign & vbNewLine
                                sw.Write(sstr)

                            End If
                        Next

                        filler4 = "1"
                        particular = "               "
                        sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
                        Dim strTotal As String = fk_sqlDbl(sSQL)
                        'dblTotal = Format(dblTotal, "#.00")
                        strTotal = Replace(strTotal, ".", "").PadLeft(12, "0")
                        Dim strLast As String = filler1 & OriBankID & OriBranchID & OriAccNo & OriAccName & filler2 & filler3 & filler4 & filler5 & strTotal & SLR & OriBankID & OriBranchID & OriAccNo & OriAccName & particular & reference & datek & atSign & vbNewLine : sw.Write(strLast)

                    Catch ex As Exception
                        bolEr = True
                        MsgBox(ex.Message)
                    End Try
                    sw.Close()
                End Using
                myStream.Close()
                '''''''''''''''''For X = 0 To dgv2.RowCount - 1
            End If
        End If

        If bolEr = False Then MessageBox.Show("The Salary ToBank DAT file has successfully generated in " & SFD.FileName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'SalAdPercen = GetVal("SELECT isAutoMail FROM tblCompany WHERE CompID='" & StrCompID & "'")

    End Sub

    Public Sub TextGenerateSampath()
        SFD.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "Samapath" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
        Dim myStream As System.IO.Stream
        Dim bolEr As Boolean = False
        If SFD.ShowDialog() = DialogResult.OK Then

            myStream = SFD.OpenFile()

            Dim filler1 As String : Dim filler2 As String : Dim filler3 As String : Dim filler4 As String : Dim filler5 As String : Dim SLR As String
            Dim accName As String : Dim bankCode As String : Dim branchCode As String : Dim DaccNo As String : Dim amount As String : Dim OriBankID As String
            Dim OriBranchID As String : Dim OriAccNo As String : Dim OriAccName As String : Dim particular As String : Dim reference As String : Dim datek As String : Dim atSign As String
            If (myStream IsNot Nothing) Then
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(myStream)
                    Try
                        PB.Value = 0
                        PB.Maximum = dgvData.RowCount
                        For X = 0 To dgvData.RowCount - 1
                            If dgvData.Item(0, X).Value <> "" Then
                                PB.Value = X
                                filler1 = dgvData.Item(3, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler2 = dgvData.Item(4, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'filler3 = dgvData.Item(7, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'filler4 = dgvData.Item(8, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'filler5 = dgvData.Item(9, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'SLR = dgvData.Item(11, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                accName = dgvData.Item(1, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)
                                'bankCode = dgvData.Item(2, X).Value 'StrDup(20 - Len(dgv.Item(4, X).Value.ToString), " ") & dgv.Item(4, X).Value.ToString
                                'branchCode = dgvData.Item(3, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                DaccNo = dgvData.Item(2, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                amount = dgvData.Item(5, X).Value
                                'OriBankID = dgvData.Item(12, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                'OriBranchID = dgvData.Item(13, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                'OriAccNo = dgvData.Item(14, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                'OriAccName = dgvData.Item(15, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                'particular = dgvData.Item(16, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                'reference = dgvData.Item(17, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                'datek = dgvData.Item(18, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                'atSign = dgvData.Item(19, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString

                                filler1 = filler1.PadRight(4, " ")
                                filler2 = filler2.PadRight(10, " ")
                                'filler3 = filler3.PadLeft(2, "0")
                                'filler4 = filler4.PadLeft(1, "0")
                                'filler5 = filler5.PadLeft(6, "0")
                                'SLR = SLR.PadLeft(3, "0")
                                accName = accName.PadRight(20, " ")
                                'bankCode = bankCode.PadRight(4, "0")
                                'branchCode = branchCode.PadRight(3, "0")
                                DaccNo = DaccNo.PadLeft(12, "0")
                                amount = amount.PadLeft(8, " ")
                                'OriBankID = OriBankID.PadRight(4, "0")
                                'OriBranchID = OriBranchID.PadRight(3, "0")
                                'OriAccNo = OriAccNo.PadRight(12, "0")
                                'OriAccName = OriAccName.PadRight(20, "0")
                                'particular = particular.PadLeft(15, " ")
                                'reference = reference.PadLeft(15, " ")
                                'datek = datek.PadRight(6, "0")
                                'atSign = atSign.PadLeft(7, "0")

                                Dim sstr As String = accName & " " & DaccNo & " " & filler1 & " " & filler2 & " " & amount & vbNewLine
                                sw.Write(sstr)

                            End If
                        Next

                        'filler4 = "1"
                        'particular = "               "
                        'sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
                        'Dim strTotal As String = fk_sqlDbl(sSQL)
                        'dblTotal = Format(dblTotal, "#.00")
                        'strTotal = Replace(strTotal, ".", "").PadLeft(12, "0")
                        'Dim strLast As String = filler1 & OriBankID & OriBranchID & OriAccNo & OriAccName & filler2 & filler3 & filler4 & filler5 & strTotal & SLR & OriBankID & OriBranchID & OriAccNo & OriAccName & particular & reference & datek & atSign & vbNewLine : sw.Write(strLast)

                    Catch ex As Exception
                        bolEr = True
                        MsgBox(ex.Message)
                    End Try
                    sw.Close()
                End Using
                myStream.Close()
                '''''''''''''''''For X = 0 To dgv2.RowCount - 1
            End If
        End If

        If bolEr = False Then MessageBox.Show("The Salary ToBank DAT file has successfully generated in " & SFD.FileName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'SalAdPercen = GetVal("SELECT isAutoMail FROM tblCompany WHERE CompID='" & StrCompID & "'")

    End Sub

    Private Sub cmdProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProcess.Click
        lblLoanAmount.Visible = False
        lblLoanCount.Visible = False
        If rdbCom.Checked = True Or rdbHSBC.Checked = True Then
            CommercialTextGenerator()
        ElseIf rdbHNB.Checked = True Then
            HNBTextGenerator()

        End If

        Dim isalid As Integer = FK_GetIDR(CmdSalField.Text)
        Dim sRdButton As String = ""
        If rdPermanant.Checked = True Then
            sRdButton = "P"
        Else
            sRdButton = "T"
        End If
        sSQL = " update tblreportparameters set cyear=" & cmbYear.Text & ",cmonth=" & cmbMonth.Text & ",salid=" & isalid & ",rdButton='" & sRdButton & "' WHERE rID='54'" : FK_EQ(sSQL, "P", "", False, False, True)

    End Sub

    Private Sub CommercialLoanTextGenerator()
        saveFilteredToTemp()
        If bolTicked = False Then Exit Sub
        bolTicked = False

        Dim strReference As String = "SALARY " & MonthName(Val(cmbMonth.Text))
        strReference = Microsoft.VisualBasic.Left(strReference, 15)
        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblpayrollemployee.RegID" Else If strReportBased = "02" Then strQuery = "tblpayrollemployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblpayrollemployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblpayrollemployee.EMPNo"

        If cmbYear.Text = "" Then MessageBox.Show("Please select year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbYear.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MessageBox.Show("Please select month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbMonth.Focus() : Exit Sub
        If cmbOrigBank.Text = "" Then MessageBox.Show("Please select Originating Bank", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbOrigBank.Focus() : Exit Sub
        If CmdSalField.Text = "" Then MessageBox.Show("Please select salary field", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : CmdSalField.Focus() : Exit Sub
        If txtParti.Text = "" Then MessageBox.Show("Please enter particular", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtParti.Focus() : Exit Sub

        sSQL = "select " & cmbYear.Text & "," & cmbMonth.Text & ",regid,1,dispName,'INITIAL',bankID,branchID,accNumber,'" & FK_GetIDR(cmbTrCode.Text) & "',0,'" & Format(dtpPayDate.Value, "yyMMdd") & "'," & strQuery & ",'BNo','BrN','origiACCNo','origiAccName', '0000','23','00','0',tblReqD.Amount,'SLR','      @','" & strReference & "'  from tblpayrollemployee where regid in (select regid from tblTempRegID) and tblpayrollemployee.status=0 AND tblPayrollEmployee.finalsalary=1 order by " & strQuery & ""
        Fk_FillGrid(sSQL, dgvData)

        sSQL1 = "delete from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid);"
        Dim strTrCode As String = FK_GetIDR(cmbTrCode.Text)
        PB.Value = 0
        PB.Maximum = dgvData.RowCount
        For i As Integer = 0 To dgvData.RowCount - 1
            PB.Value = i
            If dgvData.Item(4, i).Value <> "" Then

                Dim strSirName As String = dgvData.Item(4, i).Value
                Dim strInitialPart As String = ""
                Dim strOldPart As String = ""
                Dim strExtraPart As String = ""
                Dim strExtraPartTwo As String = ""

                Try
                    If isWithLogo = 0 Then
                        'Foundation database
                        If Len(strSirName) > 1 Then
                            Dim K, Y, Z As Integer
                            Y = Len(strSirName)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strSirName, K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Right(strSirName, Y - Z)
                            strSirName = Microsoft.VisualBasic.Left(strSirName, Z)
                            strSirName = strSirName.ToLower

                        End If
                    Else
                        'Normal Database
                        If Len(strSirName) > 1 Then
                            Dim K, Y, Z As Integer
                            Y = Len(strSirName)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strSirName, Y - K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Left(strSirName, Y - Z)
                            strSirName = Microsoft.VisualBasic.Right(strSirName, Z)
                            strSirName = strSirName.ToLower
                            Y = Len(strInitialPart)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strInitialPart, K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Right(strInitialPart, Y - Z)
                            strInitialPart = Replace(strInitialPart, ".", " ")
                        End If
                        strInitialPart = Trim(strInitialPart)
                        strInitialPart = Replace(strInitialPart, "  ", " ")
                        strInitialPart = GetInitialsFromString(strInitialPart)
                        strInitialPart = Replace(strInitialPart, ".", " ")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message + dgvData.Item(3, i).Value)
                End Try

                strSirName = UppercaseFirstLetter(strSirName)
                strInitialPart = Trim(strInitialPart) 'strSirName = Replace(strSirName, ".", "").ToUpper 'If strSirName.Length > 40 Then dgv.Rows(X).DefaultCellStyle.BackColor = Color.OrangeRed : dgv.Item(0, X).Value = False : bolCase = True
                dgvData.Item(4, i).Value = strSirName
                dgvData.Item(5, i).Value = strInitialPart

                Try
                    Dim strSt As String = ""
                    Dim strAccName As String = strInitialPart + " " + strSirName
                    Dim strAccNo As String = dgvData.Item(8, i).Value
                    If chkLongName.Checked = True Then
                        If strAccName.Length > 20 Then MessageBox.Show("There are employee(s) with Long Names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : strSt = "LongN" ': Exit Sub
                    End If
                    If strAccNo.Length > 12 Then MessageBox.Show("There are employee(s) with Long Account Numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : strSt = "LongA" ': Exit Sub

                    With dgvData
                        sSQL1 = sSQL1 & "INSERT INTO tblFinalSalaryBank (cYear,cMonth,regid,accName,bankCode,brCode,accNumber,amount,Date,particular,bankCodeOr,brCodeOr,accNumberOr,accNameOr,filler1,filler2,filler3,filler4,filler5,slr,atSign,reference) VALUES (" & Val(dgvData.Item(0, i).Value) & "," & Val(dgvData.Item(1, i).Value) & ",'" & dgvData.Item(2, i).Value & "','" & strAccName & "','" & dgvData.Item(6, i).Value & "','" & dgvData.Item(7, i).Value & "','" & dgvData.Item(8, i).Value & "',0,'" & Val(dgvData.Item(11, i).Value) & "','" & dgvData.Item(12, i).Value & "','" & dgvData.Item(13, i).Value & "','" & dgvData.Item(14, i).Value & "','" & dgvData.Item(15, i).Value & "','" & dgvData.Item(16, i).Value & "','" & dgvData.Item(17, i).Value & "','" & dgvData.Item(18, i).Value & "','" & dgvData.Item(19, i).Value & "','" & dgvData.Item(20, i).Value & "','" & dgvData.Item(21, i).Value & "','" & dgvData.Item(22, i).Value & "','" & dgvData.Item(23, i).Value & "','" & dgvData.Item(24, i).Value & "');"

                    End With

                    'For iCols As Integer = 0 To dgvData.ColumnCount - 1

                    '    Select Case strSt
                    '        Case "LongN"
                    '            dgvData.Item(5, i).Style.BackColor = Color.Pink
                    '        Case "LongA"
                    '            dgvData.Item(8, i).Style.BackColor = Color.LemonChiffon
                    '        Case ""
                    '            dgvData.Item(8, i).Style.BackColor = Color.White
                    '    End Select
                    'Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        Next

        FK_EQ(ssql1, "P", "", False, False, True) : ssql1 = ""

        Dim strsalid As String = FK_GetIDR(CmdSalField.Text)

        Dim strOriBankID As String = "" : Dim strOriBranchID As String = "" : Dim strOriAccNo As String = "" : Dim strOriAccName As String = ""
        fk_Return_MultyString("SELECT OrigiBankNo,OrigiBranchNo,OrigiAccNo,OrigiAccName FROM tblbankHead WHERE ID='" & FK_GetIDR(cmbOrigBank.Text) & "'", 4)
        strOriBankID = fk_ReadGRID(0)
        strOriBranchID = fk_ReadGRID(1)
        strOriAccNo = fk_ReadGRID(2)
        strOriAccName = fk_ReadGRID(3)

        'UPDATE LOAN AMOUNT FROM LOAN TABLE**********************************************
        Dim bolEx As Boolean = fk_CheckEx("select * from tblVariousLoanH where  tblVariousLoanH.status=0 and tblVariousLoanH.startFrom >=  '" & Format(dtpLoanStatrfrom.Value, "yyyyMMdd") & "' and regid in (select regid from tblTempRegID)")

        If bolEx = False Then MessageBox.Show("There isn't active loans to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        sSQL = "UPDATE tblFinalSalaryBank SET amount=tblVariousLoanH.Loanamount FROM tblVariousLoanH,tblFinalSalaryBank WHERE  tblFinalSalaryBank.regID=tblVariousLoanH.regID AND  tblVariousLoanH.salid=" & strsalid & "  and tblVariousLoanH.startFrom >=  '" & Format(dtpLoanStatrfrom.Value, "yyyyMMdd") & "' and tblVariousLoanH.status=0 AND  tblFinalSalaryBank.cYear=" & cmbYear.Text & " and tblFinalSalaryBank.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", "", False, False, True)
        'UPDATE LOAN AMOUNT FROM LOAN TABLE**********************************************


        sSQL = "UPDATE tblFinalSalaryBank SET bankCodeOr='" & strOriBankID & "',brCodeOr='" & strOriBranchID & "',accNumberOr='" & strOriAccNo & "',accNameOr='" & strOriAccName & "' WHERE cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "DELETE FROM tblFinalSalaryBank WHERE CONVERT(decimal, amount)=0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "SELECT tblFinalSalaryBank.regID,'0000',RIGHT('0000'+ISNULL(tblFinalSalaryBank.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBank.brCode,''),3),RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.accNumber,''),12),RIGHT(''+ISNULL(tblFinalSalaryBank.accName,''),20) , '23','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.amount,''),12),'.',''),slr,RIGHT('0000'+ISNULL(bankCodeOr,''),4),RIGHT('000'+ISNULL(brCodeOr,''),3),accNumberOr,accNameOr,   CONVERT(INT, RIGHT('               '+ISNULL(tblFinalSalaryBank.particular,''),15)),tblFinalSalaryBank.reference,tblFinalSalaryBank.Date,tblFinalSalaryBank.atSign FROM [tblFinalSalaryBank]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBank.RegID   WHERE  tblFinalSalaryBank.cYear=" & cmbYear.Text & " and tblFinalSalaryBank.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBank.regid in (select regid from tbltempregid) ORDER BY " & strQuery & ""
        Fk_FillGrid(sSQL, dgvData)

        lblCountH.Text = "Total Employees : " & dgvData.RowCount - 1

        Dim dr As DialogResult = MessageBox.Show("Do you want to create excel file with these data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.Yes Then
            ExporttoExcel(dgvData, 20)
        End If
        TextGeneratorCommercial()
        'Dim strReference As String = "SALARY " & MonthName(Val(cmbMonth.Text))
        'strReference = Microsoft.VisualBasic.Left(strReference, 9)
        'sSQL = "INSERT INTO [tblFinalSalaryBank] SELECT " & cmbYear.Text & "," & cmbMonth.Text & ",regID,'0000',RIGHT('0000'+ISNULL(bankCode,''),4),RIGHT('000'+ISNULL(brCode,''),3),RIGHT('         '+ISNULL(accNumber,''),12),RIGHT(''+ISNULL(accName,''),20) , '23','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(amount,''),12),'.',''),'SLR',tblbankHead.origiBankNo,tblbankHead.origiBranchNo,tblbankHead.origiACCNo,tblbankHead.origiAccName,   regID,'" & strReference & "',Date,'      @' FROM tblBankfileData,tblbankHead where tblbankHead.origiBankNo=tblBankfileData.bankcode"

        'TextGeneratorHNB()
        PB.Value = PB.Maximum
    End Sub

    Private Sub CommercialTextGenerator()
        dgvSearchK.Height = 0
        dgvSearchK.Width = 992
        dgvSearchK.Location = New Point(0, 150)

        dgvData.Height = 235
        dgvData.Width = 992
        dgvData.Location = New Point(0, 147)

        saveFilteredToTemp()
        If bolTicked = False Then Exit Sub
        Dim strSalFixCode As Integer = "23"
        strSalFixCode = FK_GetIDR(cmbTrCode.Text)
        bolTicked = False

        Dim strReference As String = txtParti.Text & MonthName(Val(cmbMonth.Text))
        strReference = Microsoft.VisualBasic.Left(strReference, 15)
        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblpayrollemployee.RegID" Else If strReportBased = "02" Then strQuery = "tblpayrollemployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblpayrollemployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblpayrollemployee.EMPNo"

        If cmbYear.Text = "" Then MessageBox.Show("Please select year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbYear.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MessageBox.Show("Please select month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbMonth.Focus() : Exit Sub
        If cmbOrigBank.Text = "" Then MessageBox.Show("Please select Originating Bank", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbOrigBank.Focus() : Exit Sub
        If CmdSalField.Text = "" Then MessageBox.Show("Please select salary field", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : CmdSalField.Focus() : Exit Sub
        If txtParti.Text = "" Then MessageBox.Show("Please enter particular", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtParti.Focus() : Exit Sub

        sSQL = "select " & cmbYear.Text & "," & cmbMonth.Text & ",regid,1,dispName,'INITIAL',bankID,branchID,accNumber,'" & FK_GetIDR(cmbTrCode.Text) & "',0,'" & Format(dtpPayDate.Value, "yyMMdd") & "'," & strQuery & ",'BNo','BrN','origiACCNo','origiAccName', '0000','23','00','0','000000','SLR','      @','" & strReference & "'  from tblpayrollemployee where regid in (select regid from tblTempRegID) and tblpayrollemployee.status=0  order by " & strQuery & ""
        Fk_FillGrid(sSQL, dgvData)

        sSQL1 = "delete from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & "  ;" 'and regid in (select regid from tbltempregid)
        Dim strTrCode As String = FK_GetIDR(cmbTrCode.Text)
        PB.Value = 0
        PB.Maximum = dgvData.RowCount
        For i As Integer = 0 To dgvData.RowCount - 1
            PB.Value = i
            If dgvData.Item(4, i).Value <> "" Then

                Dim strSirName As String = dgvData.Item(4, i).Value
                Dim strInitialPart As String = ""
                Dim strOldPart As String = ""
                Dim strExtraPart As String = ""
                Dim strExtraPartTwo As String = ""

                Try
                    If isWithLogo = 0 Then
                        'Foundation database
                        If Len(strSirName) > 1 Then
                            Dim K, Y, Z As Integer
                            Y = Len(strSirName)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strSirName, K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Right(strSirName, Y - Z)
                            strSirName = Microsoft.VisualBasic.Left(strSirName, Z)
                            strSirName = strSirName.ToLower

                        End If
                    Else
                        'Normal Database
                        If Len(strSirName) > 1 Then
                            Dim K, Y, Z As Integer
                            Y = Len(strSirName)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strSirName, Y - K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Left(strSirName, Y - Z)
                            strSirName = Microsoft.VisualBasic.Right(strSirName, Z)
                            strSirName = strSirName.ToLower
                            Y = Len(strInitialPart)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strInitialPart, K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Right(strInitialPart, Y - Z)
                            strInitialPart = Replace(strInitialPart, ".", " ")
                        End If
                        strInitialPart = Trim(strInitialPart)
                        strInitialPart = Replace(strInitialPart, "  ", " ")
                        strInitialPart = GetInitialsFromString(strInitialPart)
                        strInitialPart = Replace(strInitialPart, ".", " ")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message + dgvData.Item(3, i).Value)
                End Try

                strSirName = UppercaseFirstLetter(strSirName)
                strInitialPart = Trim(strInitialPart) 'strSirName = Replace(strSirName, ".", "").ToUpper 'If strSirName.Length > 40 Then dgv.Rows(X).DefaultCellStyle.BackColor = Color.OrangeRed : dgv.Item(0, X).Value = False : bolCase = True
                dgvData.Item(4, i).Value = strSirName
                dgvData.Item(5, i).Value = strInitialPart

                Try
                    Dim strSt As String = ""
                    Dim strAccName As String = strInitialPart + " " + strSirName
                    Dim strAccNo As String = dgvData.Item(8, i).Value
                    If chkLongName.Checked = True Then
                        If strAccName.Length > 20 Then MessageBox.Show("There are employee(s) with Long Names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : strSt = "LongN" ': Exit Sub
                        If strAccNo.Length > 12 Then MessageBox.Show("There are employee(s) with Long Account Numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : strSt = "LongA" ': Exit Sub
                    End If
                    If strAccName = "" Then MessageBox.Show("There are employee(s) without names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : strSt = "LongN" ': Exit Sub
                    If strAccNo = "" Then MessageBox.Show("There are employee(s) without account numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : strSt = "LongA" ': Exit Sub

                    With dgvData
                        sSQL1 = sSQL1 & "INSERT INTO tblFinalSalaryBank (cYear,cMonth,regid,accName,bankCode,brCode,accNumber,amount,Date,particular,bankCodeOr,brCodeOr,accNumberOr,accNameOr,filler1,filler2,filler3,filler4,filler5,slr,atSign,reference) VALUES (" & Val(dgvData.Item(0, i).Value) & "," & Val(dgvData.Item(1, i).Value) & ",'" & dgvData.Item(2, i).Value & "','" & strAccName & "','" & dgvData.Item(6, i).Value & "','" & dgvData.Item(7, i).Value & "','" & dgvData.Item(8, i).Value & "',0,'" & Val(dgvData.Item(11, i).Value) & "','" & dgvData.Item(12, i).Value & "','" & dgvData.Item(13, i).Value & "','" & dgvData.Item(14, i).Value & "','" & dgvData.Item(15, i).Value & "','" & dgvData.Item(16, i).Value & "','" & dgvData.Item(17, i).Value & "','" & dgvData.Item(18, i).Value & "','" & dgvData.Item(19, i).Value & "','" & dgvData.Item(20, i).Value & "','" & dgvData.Item(21, i).Value & "','" & dgvData.Item(22, i).Value & "','" & dgvData.Item(23, i).Value & "','" & dgvData.Item(24, i).Value & "');"

                    End With

                    'For iCols As Integer = 0 To dgvData.ColumnCount - 1

                    '    Select Case strSt
                    '        Case "LongN"
                    '            dgvData.Item(5, i).Style.BackColor = Color.Pink
                    '        Case "LongA"
                    '            dgvData.Item(8, i).Style.BackColor = Color.LemonChiffon
                    '        Case ""
                    '            dgvData.Item(8, i).Style.BackColor = Color.White
                    '    End Select
                    'Next

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

        Next

        FK_EQ(ssql1, "P", "", False, False, True) : ssql1 = ""

        'calculate welfare sum to SLIP Transfer
        sSQL = "SELECT " & cmbYear.Text & "," & cmbMonth.Text & ",id+99800,accName,'INITIAL',bankCode,brCode,accNumber,'" & FK_GetIDR(cmbTrCode.Text) & "',0,'" & Format(dtpPayDate.Value, "yyMMdd") & "',id+99800,'BNo','BrN','origiACCNo','origiAccName', '0000','23','00','0','000000','SLR','      @','" & strReference & "'  from tblSummaryItem WHERE cStatus=1"


        Dim strsalid As String = FK_GetIDR(CmdSalField.Text)

        Dim strOriBankID As String = "" : Dim strOriBranchID As String = "" : Dim strOriAccNo As String = "" : Dim strOriAccName As String = ""
        fk_Return_MultyString("SELECT OrigiBankNo,OrigiBranchNo,OrigiAccNo,OrigiAccName FROM tblbankHead WHERE ID='" & FK_GetIDR(cmbOrigBank.Text) & "'", 4)
        strOriBankID = fk_ReadGRID(0)
        strOriBranchID = fk_ReadGRID(1)
        strOriAccNo = fk_ReadGRID(2)
        strOriAccName = fk_ReadGRID(3)

        If rdTemporary.Checked = True Then

            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblsd WHERE tblsd.salid=" & strsalid & " and tblsd.type1=2 and tblsd.cYear=" & cmbYear.Text & " and tblsd.cMonth=" & cmbMonth.Text & " and regid in (select regid from tblTempRegID)")

            If bolEx = False Then MessageBox.Show("There isn't data in Temparary location to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            sSQL = "UPDATE tblFinalSalaryBank SET amount=tblsd.amount FROM tblsd,tblFinalSalaryBank WHERE  tblFinalSalaryBank.regID=tblsd.regID AND tblFinalSalaryBank.cYear=tblsd.cYear AND tblFinalSalaryBank.cMonth=tblsd.cMonth AND tblsd.salid=" & strsalid & " and tblsd.type1=2 and tblsd.cYear=" & cmbYear.Text & " and tblsd.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", "", False, False, True)

        ElseIf rdPermanant.Checked = True Then

            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblsdAll WHERE tblsdAll.salid=" & strsalid & " and tblsdAll.type1=2 and tblsdAll.cYear=" & cmbYear.Text & " and tblsdAll.cMonth=" & cmbMonth.Text & " and regid in (select regid from tblTempRegID)")

            If bolEx = False Then MessageBox.Show("There isn't data in Permenent location to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            sSQL = "UPDATE tblFinalSalaryBank SET amount=tblsdAll.amount FROM tblsdAll,tblFinalSalaryBank WHERE  tblFinalSalaryBank.regID=tblsdAll.regID AND tblFinalSalaryBank.cYear=tblsdAll.cYear AND tblFinalSalaryBank.cMonth=tblsdAll.cMonth AND tblsdAll.salid=" & strsalid & " and tblsdAll.type1=2 and tblsdAll.cYear=" & cmbYear.Text & " and tblsdAll.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", "", False, False, True)

        End If

        sSQL = "UPDATE tblFinalSalaryBank SET bankCodeOr='" & strOriBankID & "',brCodeOr='" & strOriBranchID & "',accNumberOr='" & strOriAccNo & "',accNameOr='" & strOriAccName & "' WHERE cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)


        sSQL = "DELETE FROM tblFinalSalaryBank WHERE CONVERT(decimal, amount)=0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "SELECT COUNT(cMonth) FROM tblFinalSalaryBank WHERE CONVERT(NUMERIC (18,2),Amount)<0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid)"
        Dim intMinus = fk_sqlDbl(sSQL)
        If intMinus > 0 Then
            MessageBox.Show("There are " & intMinus & " employee(s) with minus salary, Please check it", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            sSQL = "INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Displayed the message about minus salary in  year of " & Val(cmbYear.Text) & " and month of " & Val(cmbMonth.Text) & " and employee(s) : " & intMinus & " ','" & StrUserID & "',0)" : FK_EQ(sSQL, "p", "", False, False, True)
        End If

        'sSQL = "SELECT tblFinalSalaryBank.regID,'0000',RIGHT('0000'+ISNULL(tblFinalSalaryBank.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBank.brCode,''),3),RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.accNumber,''),12),RIGHT(''+ISNULL(tblFinalSalaryBank.accName,''),30) , '23','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.amount,''),12),'.',''),slr,RIGHT('0000'+ISNULL(bankCodeOr,''),4),RIGHT('000'+ISNULL(brCodeOr,''),3),accNumberOr,accNameOr,   CONVERT(INT, RIGHT('               '+ISNULL(tblFinalSalaryBank.particular,''),15)),tblFinalSalaryBank.reference,tblFinalSalaryBank.Date,tblFinalSalaryBank.atSign FROM [tblFinalSalaryBank]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBank.RegID   WHERE  tblFinalSalaryBank.cYear=" & cmbYear.Text & " and tblFinalSalaryBank.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBank.regid in (select regid from tbltempregid) ORDER BY " & strQuery & ""
        'Fk_FillGrid(sSQL, dgvData)

        dgvSearchK.Height = 1
        dgvSearchK.Width = 992
        dgvSearchK.Location = New Point(0, 150)

        dgvData.Height = 235
        dgvData.Width = 992
        dgvData.Location = New Point(0, 147)

        If rdbCom.Checked = True Then
            Try
                If chkSortBank.Checked = True Then
                    strQuery = "tblPayrollEmployee.BankID,tblPayrollEmployee.sub_CatID," & strQuery
                End If
                sSQL = "SELECT tblFinalSalaryBank.regID,'0000',RIGHT('0000'+ISNULL(tblFinalSalaryBank.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBank.brCode,''),3),RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.accNumber,''),12),RIGHT(''+ISNULL(tblFinalSalaryBank.accName,''),20) , '" & strSalFixCode & "','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.amount,''),12),'.',''),slr,RIGHT('0000'+ISNULL(bankCodeOr,''),4),RIGHT('000'+ISNULL(brCodeOr,''),3),accNumberOr,accNameOr,   CONVERT(INT, RIGHT('               '+ISNULL(tblFinalSalaryBank.particular,''),15)),tblFinalSalaryBank.reference,tblFinalSalaryBank.Date,tblFinalSalaryBank.atSign FROM [tblFinalSalaryBank]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBank.RegID   WHERE  tblFinalSalaryBank.cYear=" & cmbYear.Text & " and tblFinalSalaryBank.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBank.regid in (select regid from tbltempregid) AND  CONVERT(NUMERIC (18,2),AMOUNT)>0 ORDER BY " & strQuery & ""
                Fk_FillGrid(sSQL, dgvData)
                lblCountH.Text = "Total Employees : " & dgvData.RowCount - 1

                Dim dr As DialogResult = MessageBox.Show("Do you want to create excel file with these data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dr = Windows.Forms.DialogResult.Yes Then
                    ExporttoExcel(dgvData, 20)
                End If
                TextGeneratorCommercial()
                PB.Value = PB.Maximum
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'sSQL = "SELECT tblFinalSalaryBank.regID,'0000',RIGHT('0000'+ISNULL(tblFinalSalaryBank.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBank.brCode,''),3),RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.accNumber,''),12),LEFT(''+ISNULL(tblFinalSalaryBank.accName,''),20) , '" & strSalFixCode & "','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.amount,''),12),'.',''),slr,RIGHT('0000'+ISNULL(bankCodeOr,''),4),RIGHT('000'+ISNULL(brCodeOr,''),3),accNumberOr,accNameOr,   'AUGUST SALARY  ' , 'FU/SAL/2017    ' ,tblFinalSalaryBank.Date,tblFinalSalaryBank.atSign FROM [tblFinalSalaryBank]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBank.RegID   WHERE  tblFinalSalaryBank.cYear=" & cmbYear.Text & " and tblFinalSalaryBank.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBank.regid in (select regid from tbltempregid) AND  CONVERT(NUMERIC (18,2),AMOUNT)>0 ORDER BY " & strQuery & ""
            'Fk_FillGrid(sSQL, dgvData)
            'lblCountH.Text = "Total Employees : " & dgvData.RowCount - 1

            'Dim dr As DialogResult = MessageBox.Show("Do you want to create excel file with these data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If dr = Windows.Forms.DialogResult.Yes Then
            '    ExporttoExcel(dgvData, 20)
            'End If
            'TextGeneratorBOC()
            'PB.Value = PB.Maximu

        ElseIf rdbHSBC.Checked = True Then 'HSBC FORMAT
            sSQL = "SELECT tblFinalSalaryBank.regID,RIGHT('0000'+ISNULL(tblFinalSalaryBank.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBank.brCode,''),3),right('00000'+convert(varchar(6),.tblPayrollemployee.epfno),5),RIGHT('000000000000'+ISNULL(tblFinalSalaryBank.accNumber,''),12),tblFinalSalaryBank.accName, '" & strSalFixCode & "','0', FORMAT(CONVERT(NUMERIC (18,2),tblFinalSalaryBank.amount),'##.##'),   CONVERT(INT, RIGHT('               '+ISNULL(tblFinalSalaryBank.particular,''),15)) ,tblFinalSalaryBank.reference,tblFinalSalaryBank.Date,'000000','                             ' FROM [tblFinalSalaryBank]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBank.RegID    WHERE  tblFinalSalaryBank.cYear=" & cmbYear.Text & " and tblFinalSalaryBank.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBank.regid in (select regid from tbltempregid) AND  CONVERT(NUMERIC (18,2),AMOUNT)>0 ORDER BY " & strQuery & ""
            Fk_FillGrid(sSQL, dgvData)
            lblCountH.Text = "Total Employees : " & dgvData.RowCount - 1

            Dim dr As DialogResult = MessageBox.Show("Do you want to create excel file with these data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dr = Windows.Forms.DialogResult.Yes Then
                ExporttoExcel(dgvData, 20)
            End If
            TextGeneratorHSBC()
            PB.Value = PB.Maximum
        End If

        Try
            sSQL = "select SUM (CONVERT(numeric (18,2),amount)) from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
            Dim dblTotAmount As Double = fk_sqlDbl(sSQL)
            sSQL = "select COUNT (amount) from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
            Dim dblToTCount As Double = fk_sqlDbl(sSQL)
            lblLoanAmount.Visible = True
            lblLoanCount.Visible = True
            lblLoanAmount.Text = "Amount : " & dblTotAmount
            lblLoanCount.Text = "Count : " & dblToTCount

            Dim isalid As Integer = FK_GetIDR(CmdSalField.Text)
            Dim sRdButton As String = ""
            If rdPermanant.Checked = True Then
                sRdButton = "P"
            Else
                sRdButton = "T"
            End If
            sSQL = " update tblreportparameters set cyear=" & cmbYear.Text & ",cmonth=" & cmbMonth.Text & ",salid=" & isalid & ",rdButton='" & sRdButton & "' WHERE rID='54'" : FK_EQ(sSQL, "P", "", False, False, True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub HNBTextGenerator()
        saveFilteredToTemp()
        If bolTicked = False Then Exit Sub
        bolTicked = False
        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblpayrollemployee.RegID" Else If strReportBased = "02" Then strQuery = "tblpayrollemployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblpayrollemployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblpayrollemployee.EMPNo"

        sSQL = "select " & cmbYear.Text & "," & cmbMonth.Text & ",regid,1,dispName,'INITIAL',bankID,branchID,accNumber,'" & FK_GetIDR(cmbTrCode.Text) & "',0,'" & Format(dtpPayDate.Value, "yyMMdd") & "','EPF No'+ epfNo from tblpayrollemployee where regid in (select regid from tblTempRegID) and status=0 order by " & strQuery & ""
        Fk_FillGrid(sSQL, dgvData)
        If cmbYear.Text = "" Then MessageBox.Show("Please select year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbYear.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MessageBox.Show("Please select month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbMonth.Focus() : Exit Sub
        If cmbTrCode.Text = "" Then MessageBox.Show("Please select transaction code", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbTrCode.Focus() : Exit Sub
        If CmdSalField.Text = "" Then MessageBox.Show("Please select salary field", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : CmdSalField.Focus() : Exit Sub
        If cmbOrigBank.Text = "" Then MessageBox.Show("Please select Originating Bank", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbOrigBank.Focus() : Exit Sub

        sSQL1 = "delete from tblBankfileData where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid);"
        Dim strTrCode As String = FK_GetIDR(cmbTrCode.Text)
        PB.Value = 0
        PB.Maximum = dgvData.RowCount
        For i As Integer = 0 To dgvData.RowCount - 1
            PB.Value = i
            If dgvData.Item(4, i).Value <> "" Then

                Dim strSirName As String = dgvData.Item(4, i).Value
                Dim strInitialPart As String = ""
                Dim strOldPart As String = ""
                Dim strExtraPart As String = ""
                Dim strExtraPartTwo As String = ""

                Try
                    If isWithLogo = 0 Then
                        'Foundation database
                        If Len(strSirName) > 1 Then
                            Dim K, Y, Z As Integer
                            Y = Len(strSirName)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strSirName, K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Right(strSirName, Y - Z)
                            strSirName = Microsoft.VisualBasic.Left(strSirName, Z)
                            strSirName = strSirName.ToLower

                        End If
                    Else
                        'Normal Database
                        If Len(strSirName) > 1 Then
                            Dim K, Y, Z As Integer
                            Y = Len(strSirName)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strSirName, Y - K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Left(strSirName, Y - Z)
                            strSirName = Microsoft.VisualBasic.Right(strSirName, Z)
                            strSirName = strSirName.ToLower
                            Y = Len(strInitialPart)
                            K = 1
                            Z = 0
                            While K < Y
                                If Mid(strInitialPart, K, 1) = " " Then
                                    Z = K
                                    Exit While
                                End If
                                K += 1
                            End While
                            strInitialPart = Microsoft.VisualBasic.Right(strInitialPart, Y - Z)
                            strInitialPart = Replace(strInitialPart, ".", " ")
                        End If
                        strInitialPart = Trim(strInitialPart)
                        strInitialPart = Replace(strInitialPart, "  ", " ")
                        strInitialPart = GetInitialsFromString(strInitialPart)
                        strInitialPart = Replace(strInitialPart, ".", " ")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message + dgvData.Item(3, i).Value)
                End Try

                strSirName = UppercaseFirstLetter(strSirName)
                strInitialPart = Trim(strInitialPart) 'strSirName = Replace(strSirName, ".", "").ToUpper 'If strSirName.Length > 40 Then dgv.Rows(X).DefaultCellStyle.BackColor = Color.OrangeRed : dgv.Item(0, X).Value = False : bolCase = True
                dgvData.Item(4, i).Value = strSirName
                dgvData.Item(5, i).Value = strInitialPart

                Try
                    Dim strAccName As String = strInitialPart + " " + strSirName
                    Dim strAccNo As String = dgvData.Item(8, i).Value
                    If chkLongName.Checked = True Then
                        If strAccName.Length > 20 Then MessageBox.Show("There are employee(s) with Long Names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub
                        If strAccNo.Length > 12 Then MessageBox.Show("There are employee(s) with Long Account Numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub

                    End If
                    If strAccName = "" Then MessageBox.Show("There are employee(s) without names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub
                    If strAccNo = "" Then MessageBox.Show("There are employee(s) without account numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub

                    With dgvData
                        sSQL1 = sSQL1 & "INSERT INTO tblBankfileData (cYear,cMonth,regid,trID,accName,bankCode,brCode,accNumber,trnCode,amount,Date,particular) VALUES (" & Val(dgvData.Item(0, i).Value) & "," & Val(dgvData.Item(1, i).Value) & ",'" & dgvData.Item(2, i).Value & "'," & i + 1 & ",'" & strAccName & "','" & dgvData.Item(6, i).Value & "','" & dgvData.Item(7, i).Value & "','" & dgvData.Item(8, i).Value & "','" & strTrCode & "',0,'" & Val(dgvData.Item(11, i).Value) & "','" & dgvData.Item(12, i).Value & "');"
                    End With

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If

            'sSQL = sSQL & "INSERT INTO tblBankfileData select " & cmbYear.Text & "," & cmbMonth.Text & ",regid,1,dispName,bankID,branchID,accNumber,'" & FK_GetIDR(cmbTrCode.Text) & "',0,'151016','jan sal epf' from tblpayrollemployee where regid in (select regid from tblTempRegID)"
            'FK_EQ(sSQL, "P", False, False, True)
        Next

        FK_EQ(ssql1, "P", "", False, False, True) : ssql1 = ""

        Dim strsalid As String = FK_GetIDR(CmdSalField.Text)

        If rdTemporary.Checked = True Then

            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblsd WHERE tblsd.salid=" & strsalid & " and tblsd.type1=2 and tblsd.cYear=" & cmbYear.Text & " and tblsd.cMonth=" & cmbMonth.Text & " and regid in (select regid from tblTempRegID)")

            If bolEx = False Then MessageBox.Show("There isn't data in Temparary location to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            sSQL = "UPDATE tblBankfileData SET amount=tblsd.amount FROM tblsd,tblBankfileData WHERE  tblBankfileData.regID=tblsd.regID AND tblBankfileData.cYear=tblsd.cYear AND tblBankfileData.cMonth=tblsd.cMonth AND tblsd.salid=" & strsalid & " and tblsd.type1=2 and tblsd.cYear=" & cmbYear.Text & " and tblsd.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", "", False, False, True)

        ElseIf rdPermanant.Checked = True Then

            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblsdAll WHERE tblsdAll.salid=" & strsalid & " and tblsdAll.type1=2 and tblsdAll.cYear=" & cmbYear.Text & " and tblsdAll.cMonth=" & cmbMonth.Text & " and regid in (select regid from tblTempRegID)")

            If bolEx = False Then MessageBox.Show("There isn't data in Permenent location to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

            sSQL = "UPDATE tblBankfileData SET amount=tblsdAll.amount FROM tblsdAll,tblBankfileData WHERE  tblBankfileData.regID=tblsdAll.regID AND tblBankfileData.cYear=tblsdAll.cYear AND tblBankfileData.cMonth=tblsdAll.cMonth AND tblsdAll.salid=" & strsalid & " and tblsdAll.type1=2 and tblsdAll.cYear=" & cmbYear.Text & " and tblsdAll.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", "", False, False, True)

        End If

        sSQL = "DELETE FROM tblBankfileData WHERE CONVERT(decimal, amount)=0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)

        'Update next working date | 2019-01-22
        Dim strOriginalBankID As String = ""
        strOriginalBankID = fk_RetString("SELECT OrigiBankNo FROM tblbankHead WHERE ID='" & FK_GetIDR(cmbOrigBank.Text) & "'")

        sSQL = "UPDATE tblBankfileData SET Date='" & Format(dtpNextWork.Value, "yyMMdd") & "' WHERE bankcode<>'" & strOriginalBankID & "'" : FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "SELECT COUNT(cMonth) FROM tblBankfileData WHERE CONVERT(NUMERIC (18,2),Amount)<0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid)"
        Dim intMinus = fk_sqlDbl(sSQL)
        If intMinus > 0 Then
            MessageBox.Show("There are " & intMinus & " employee(s) with minus salary, Please check it", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            sSQL = "INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Displayed the message about minus salary in  year of " & Val(cmbYear.Text) & " and month of " & Val(cmbMonth.Text) & " and employee(s) : " & intMinus & " ','" & StrUserID & "',0)" : FK_EQ(sSQL, "p", "", False, False, True)
        End If


        sSQL = "SELECT RIGHT('00000000'+ISNULL(tblBankfileData.TRID,''),8),RIGHT(''+ISNULL(tblBankfileData.accName,''),20) ,RIGHT('0000'+ISNULL(tblBankfileData.bankCode,''),4),RIGHT('000'+ISNULL(tblBankfileData.brCode,''),3),RIGHT('         '+ISNULL(tblBankfileData.accNumber,''),12),trnCode,REPLACE(RIGHT('00000000000'+ISNULL(tblBankfileData.amount,''),11),'.',''),Date,RIGHT('             '+ISNULL(tblBankfileData.particular,''),13) FROM tblBankfileData LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblBankfileData.RegID WHERE  tblBankfileData.cYear=" & cmbYear.Text & " and tblBankfileData.cMonth=" & cmbMonth.Text & " and tblBankfileData.regid in (select regid from tbltempregid) ORDER BY  " & strQuery & ""
        Fk_FillGrid(sSQL, dgvData)

        lblCountH.Text = "Total Employees : " & dgvData.RowCount - 1

        Dim dr As DialogResult = MessageBox.Show("Do you want to create excel file with these data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.Yes Then
            ExporttoExcel(dgvData, 8)
        End If

        TextGeneratorHNB()
        PB.Value = PB.Maximum
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbOrigBank.Click
        LoadForm(New FrmBankFileHeader)
        FillComboAll(cmbOrigBank, "Select HName+'='+ID from tblbankHead where Status='0'")
    End Sub

    Private Sub rdbLong_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbCom.Click
        If rdbCom.Checked = True Then
            'lblTrcode.Enabled = True
            'cmbTrCode.Enabled = True
            'cmbOrigBank.Enabled = True
            'pbOrigBank.Enabled = True
            'lblOrigBank.Enabled = True
        Else
            'lblTrcode.Enabled = True
            'cmbTrCode.Enabled = True
            'cmbOrigBank.Enabled = False
            'pbOrigBank.Enabled = False
            'lblOrigBank.Enabled = False
        End If
    End Sub

    Private Sub rdbShort_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbHNB.Click
        If rdbHNB.Checked = True Then
            'lblTrcode.Enabled = True
            'cmbTrCode.Enabled = True
            'cmbOrigBank.Enabled = False
            'pbOrigBank.Enabled = False
            'lblOrigBank.Enabled = False
        Else
            'lblTrcode.Enabled = False
            'cmbTrCode.Enabled = False
            'cmbOrigBank.Enabled = True
            'pbOrigBank.Enabled = True
            'lblOrigBank.Enabled = True
        End If
    End Sub

    Private Sub rdbLoan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dtpLoanStatrfrom.Enabled = False Then
            dtpLoanStatrfrom.Enabled = True
            lblLoan.Enabled = True
        End If
    End Sub

    Private Sub rdbLong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCom.Click
        If dtpLoanStatrfrom.Enabled = True Then
            dtpLoanStatrfrom.Enabled = False
            lblLoan.Enabled = False
        End If
    End Sub

    Private Sub rdbShort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbHNB.Click
        If dtpLoanStatrfrom.Enabled = True Then
            dtpLoanStatrfrom.Enabled = False
            lblLoan.Enabled = False
        End If
    End Sub

    Private Sub cmbOrigBank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrigBank.SelectedIndexChanged
        SearchEmployee()
    End Sub

    Private Sub rdPermanant_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdPermanant.CheckedChanged
        If rdPermanant.Checked = True Then
            sSQL = "Select distinct cmonth from tblSDAll order by cMonth" ' where cYear='" & intCurrentYear & "'"
            FillComboAll(cmbMonth, sSQL)
            sSQL = "Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   Status='0' AND ID IN (select distinct salid from tblsdAll)   order by Description asc"
            FillComboAll(CmdSalField, sSQL)

        Else
            sSQL = "Select distinct cmonth from tblSD" ' where cYear='" & intCurrentYear & "'"
            FillComboAll(cmbMonth, sSQL)
            sSQL = "Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   Status='0' AND ID IN (select distinct salid from tblsd)   order by Description asc"
            FillComboAll(CmdSalField, sSQL)

        End If
       
    End Sub

    Private Sub dtpPayDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPayDate.ValueChanged
        dtpNextWork.Value = dtpPayDate.Value
    End Sub

    Private Sub rdbHNB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbHNB.CheckedChanged
        If rdbHNB.Checked = True Then
            dtpNextWork.Enabled = True
            lblNextDate.Enabled = True
        Else
            dtpNextWork.Enabled = False
            lblNextDate.Enabled = False
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

    'Kasun | AD requirement | 2019-06-03
    Public Sub TextGeneratorHSBC()
        SFD.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "HSBC" & Format(Now, "ddMMyyyy hhmmsstt") & ".dat"
        Dim myStream As System.IO.Stream
        Dim bolEr As Boolean = False
        If SFD.ShowDialog() = DialogResult.OK Then

            myStream = SFD.OpenFile()

            Dim filler1 As String : Dim filler2 As String : Dim filler3 As String : Dim filler4 As String : Dim filler5 As String : Dim SLR As String
            Dim accName As String : Dim bankCode As String : Dim branchCode As String : Dim DaccNo As String : Dim amount As Decimal : Dim OriBankID As String
            Dim OriBranchID As String : Dim OriAccNo As String : Dim OriAccName As String : Dim particular As String : Dim reference As String : Dim datek As String : Dim atSign As String : Dim Damount As String
            If (myStream IsNot Nothing) Then
                Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(myStream)
                    Try
                        PB.Value = 0
                        PB.Maximum = dgvData.RowCount
                        For X = 0 To dgvData.RowCount - 1
                            If dgvData.Item(0, X).Value <> "" Then
                                PB.Value = X
                                filler1 = dgvData.Item(3, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'filler2 = dgvData.Item(4, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'filler3 = dgvData.Item(7, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                filler4 = dgvData.Item(12, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                'filler5 = dgvData.Item(13, X).Value 'StrDup(20 - Len(dgv.Item(2, X).Value.ToString), " ") & Trim(dgv.Item(2, X).Value.ToString)
                                accName = dgvData.Item(5, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)
                                bankCode = dgvData.Item(1, X).Value 'StrDup(20 - Len(dgv.Item(4, X).Value.ToString), " ") & dgv.Item(4, X).Value.ToString
                                amount = dgvData.Item(8, X).Value
                                particular = "PAY" 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                'reference = dgvData.Item(10, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString
                                datek = dgvData.Item(11, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                branchCode = dgvData.Item(2, X).Value
                                DaccNo = dgvData.Item(4, X).Value 'StrDup(40 - Len(dgv.Item(3, X).Value.ToString), " ") & Trim(dgv.Item(3, X).Value.ToString)

                                'filler1 = filler1.PadLeft(5, "0")
                                'filler2 = filler2.PadLeft(2, "0")
                                'filler3 = filler3.PadLeft(1, "0")
                                filler4 = filler4.PadLeft(6, "0")
                                'filler5 = filler5.PadLeft(29, " ")
                                'accName = accName.PadRight(20, " ")
                                bankCode = bankCode.PadRight(4, "0")
                                branchCode = branchCode.PadRight(2, "0")
                                Damount = amount.ToString("####0.00")
                                'particular = particular.PadLeft(15, " ")
                                'reference = reference.PadLeft(15, " ")
                                datek = datek.PadRight(6, "0")
                                DaccNo = DaccNo.PadLeft(12, "0")

                                Dim sstr As String = filler1 & "," & bankCode & branchCode & "," & DaccNo & "," & accName & "," & Damount & "," & particular & vbNewLine
                                sw.Write(sstr)

                            End If
                        Next

                        'filler4 = "1"
                        'particular = "               "
                        sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBank] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
                        Dim strTotal As String = fk_sqlDbl(sSQL)
                        'dblTotal = Format(dblTotal, "#.00")
                        strTotal = Replace(strTotal, ".", "").PadLeft(12, "0")
                        'Dim strLast As String = filler1 & OriBankID & OriBranchID & OriAccNo & OriAccName & filler2 & filler3 & filler4 & filler5 & strTotal & SLR & OriBankID & OriBranchID & OriAccNo & OriAccName & particular & reference & datek & atSign & vbNewLine : sw.Write(strLast)

                    Catch ex As Exception
                        bolEr = True
                        MsgBox(ex.Message)
                    End Try
                    sw.Close()
                End Using
                myStream.Close()
                '''''''''''''''''For X = 0 To dgv2.RowCount - 1
            End If
        End If

        If bolEr = False Then MessageBox.Show("The Salary ToBank DAT file has successfully generated in " & SFD.FileName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        'SalAdPercen = GetVal("SELECT isAutoMail FROM tblCompany WHERE CompID='" & StrCompID & "'")

    End Sub

End Class