Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class frmBankFileGenerator

    Dim sTable As String = "tblSD"
    Dim bolTicked As Boolean = False

    Private Sub frmCoinSummery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        intPrcdMonth = fk_sqlDbl("select distinct cmonth from tblsd")
        strPrCategory = fk_RetString("select processategory from tblCompany where compID='" & StrCompID & "'")
        Label12.BackColor = clrFocused
        cmdRefresh_Click(sender, e)
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
        FillComboAll(cmbYear, sSQL)
    End Sub

    Private Sub rd1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadCombo()
    End Sub

    Private Sub rd2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        sSQL = "Select distinct cmonth from tblSDAll order by cMonth" ' where cYear='" & intCurrentYear & "'"
        FillComboAll(cmbMonth, sSQL)
        sSQL = "Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   Status='0' AND ID IN (select distinct salid from tblsdAll)   order by Description asc"
        FillComboAll(CmdSalField, sSQL)

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
            sSQL = "Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   Status='0' AND ID IN (select distinct salid from tblsd)   order by Description asc"
            FillComboAll(CmdSalField, sSQL)

            FillComboAll(cmbDepartment, "select DeptName + '=' + DeptID from tblsetDept where status=0")
            FillComboAll(cmbPayCenter, "select pDesc + '=' + pID from tblsetpcentre where status=0")
            FillComboAll(cmbCostCenter, "Select  cntDesc + '=' + cntID from tblsetcCentre where status=0")
            'FillComboAll(cmbSalaryViewLevel, " Select LevelName + '-' + ID from tblUL where LevelValue<=" & UserVal & "")
            FillComboAll(cmbCompany, "Select CName + '=' + CompID from tblCompany where status=0")
            FillComboAll(cmbbranch, "Select BrName + '=' + BrID from tblCBranchs where status=0")
            FillComboAll(cmbDesignation, "Select DesgDesc + '=' + DesgID from tblDesig where status=0")
            FillComboAll(cmbPrCatagory, "select CatDesc + '=' + CatID from tblSetPrCategory where status=0")
            FillComboAll(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0")
            FillComboAll(cmbTrCode, "Select TrDesc+'='+trid from tblSetBnkTransaction ")
            FillComboAll(cmbOrigBank, "Select HName+'='+ID from tblbankHead where Status='0'")

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
            txtParti.Text = "BANK LOANS "
            lblCountH.Text = ""
            lblLoanAmount.Visible = False
            lblLoanCount.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        dtpLoanStatrfrom.Enabled = False
        lblLoan.Enabled = False
        'LoadHistory()
    End Sub

    Public Sub LoadHistory()
        Try
            'rID = "01"
            sSQL = "SELECT rName,cyear,cmonth,salid,rdButton FROM tblreportparameters where rid='01'"
            FK_ReadDB(sSQL)
            cmbYear.Text = FK_Read("cyear")
            cmbMonth.Text = FK_Read("cmonth")
            Dim iSalID As Integer = FK_Read("salid")
            CmdSalField.Text = fk_RetString("Select Description+'='+convert(varchar(5),ID)  from tblSalaryItems where   id='" & iSalID & "'")
            rName = FK_Read("rName")
            Dim sRdButton As String = FK_Read("rdButton")
            'If sRdButton = "T" Then
            '    rdTemparary.Checked = True
            'Else
            '    rdPermanant.Checked = True
            'End If

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
        Dim StrPrCategorya As String = IIf(cmbPrCatagory.Text = "[ALL]", "", FK_GetIDL(cmbPrCatagory.Text))
        Dim StrPayC As String = IIf(cmbPayCenter.Text = "[ALL]", "", FK_GetIDL(cmbPayCenter.Text))
        Dim StrCostC As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDL(cmbCostCenter.Text))
        Dim StrBankID As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDR(cmbCostCenter.Text))
        Dim StrBranchID As String = IIf(cmbCostCenter.Text = "[ALL]", "", FK_GetIDR(cmbCostCenter.Text))

        sSQL = "SELECT     'true',dbo.tblPayEmpMRecords.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayEmpMRecords.DispName, dbo.tblPayEmpMRecords.EmIdNum, " &
        "dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayEmpMRecords.BasicSalary, " &
        "dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc,tblPayrollEmployee.accNumber,tblPayrollEmployee.BankID,tblPayrollEmployee.BranchID  FROM " &
        "dbo.tblPayEmpMRecords,tblSetCCentre ,tblCBranchs,tblSetPCentre,tblSetDept,tblDesig,tblSetPrCategory,tblSetEmpCategory,tblCompany,tblPayrollEmployee,tblUL " &
        " where dbo.tblPayEmpMRecords.CostID = dbo.tblSetCCentre.CntID  AND" &
        " dbo.tblPayEmpMRecords.ComID = dbo.tblCBranchs.CompID AND  " &
        " dbo.tblPayEmpMRecords.BrID = dbo.tblCBranchs.BrID AND " &
        " dbo.tblPayEmpMRecords.PayID = dbo.tblSetPCentre.pID  AND " &
        " dbo.tblPayEmpMRecords.DeptID = dbo.tblSetDept.DeptID  AND " &
        " dbo.tblPayEmpMRecords.DesigID = dbo.tblDesig.DesgID  AND " &
        " dbo.tblPayEmpMRecords.sub_catID = dbo.tblSetEmpCategory.catID AND " &
        " dbo.tblPayEmpMRecords.RegID= dbo.tblPayrollEmployee.RegID AND " &
        " dbo.tblPayEmpMRecords.SalViewLevel = dbo.tblUL.ID AND   " &
        " tblSetPrCategory.CatID=tblPayEmpMRecords.PrcatID  AND " &
        " tblPayEmpMRecords.status=0 AND tblPayrollEmployee.finalSalary=1 AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayEmpMRecords.SalViewLevel =0) " &
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
        "dbo.tblSetPCentre.pDesc LIKE '" & StrPayC & "%' AND  " &
        "tblSetPrCategory.CatDesc LIKE '" & StrPrCategorya & "%') " &
        " AND tblPayEmpMRecords.cYear=" & cmbYear.Text & " AND tblPayEmpMRecords.cMonth=" & cmbMonth.Text & " ORDER BY " & strQuery
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
        SFD.FileName = "HNBLOAN" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
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
                                Dim DaccNo As String = dgvData.Item(4, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                Dim trCode As String = dgvData.Item(5, X).Value 'StrDup(6 - Len(dgv.Item(5, X).Value.ToString), "0") & Trim(dgv.Item(5, X).Value.ToString)
                                Dim amount As String = dgvData.Item(6, X).Value
                                Dim datek As String = dgvData.Item(7, X).Value 'StrDup(6 - Len(dgv.Item(12, X).Value), "0") & dgv.Item(12, X).Value
                                Dim particular As String = dgvData.Item(8, X).Value 'StrDup(6 - Len(dgv.Item(13, X).Value.ToString), "0") & dgv.Item(13, X).Value.ToString

                                trID = trID.PadLeft(8, "0")
                                accName = accName.PadRight(20, " ")
                                bankCode = bankCode.PadRight(4, "0")
                                branchCode = branchCode.PadRight(3, "0")
                                DaccNo = DaccNo.PadRight(12, "0")
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
            'LoadForm(New frmAutomaticMail)
        End If

    End Sub

    Public Sub TextGeneratorPeople()
        SFD.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*"
        SFD.FilterIndex = 2
        SFD.RestoreDirectory = True
        SFD.FileName = "PEOPLELOAN" & Format(Now, "ddMMyyyy hhmmsstt") & ".dat"
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
                        sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBankLoan] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
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
        SFD.FileName = "BOCLOAN" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
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
        SFD.FileName = "COMMERCIALLOAN" & Format(Now, "ddMMyyyy hhmmsstt") & ".dat"
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
                        sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBankLoan] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
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
        SFD.FileName = "SAMPATHLOAN" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
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
                        'sSQL = "select SUM (CONVERT(numeric (18,2),amount))*100 from [tblFinalSalaryBankLoan] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
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
        If rdbCom.Checked = True Then
            CommercialTextGenerator()
        ElseIf rdbHNB.Checked = True Then
            HNBTextGenerator()
        End If
    End Sub

    Private Sub CommercialTextGenerator()
        saveFilteredToTemp()
        If bolTicked = False Then Exit Sub
        Dim strSalFixCode As Integer = "23"
        strSalFixCode = FK_GetIDR(cmbTrCode.Text)
        bolTicked = False

        Dim strReference As String = txtParti.Text & MonthName(Val(cmbMonth.Text))
        strReference = strReference.ToUpper
        strReference = Microsoft.VisualBasic.Left(strReference, 15)
        Dim strQuery As String = ""
        If strReportBased = "01" Then strQuery = "tblpayrollemployee.RegID" Else If strReportBased = "02" Then strQuery = "tblpayrollemployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblpayrollemployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblpayrollemployee.EMPNo"

        If cmbYear.Text = "" Then MessageBox.Show("Please select year", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbYear.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MessageBox.Show("Please select month", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbMonth.Focus() : Exit Sub
        If cmbOrigBank.Text = "" Then MessageBox.Show("Please select Originating Bank", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbOrigBank.Focus() : Exit Sub
        'If CmdSalField.Text = "" Then MessageBox.Show("Please select salary field", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : CmdSalField.Focus() : Exit Sub
        If txtParti.Text = "" Then MessageBox.Show("Please enter particular", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : txtParti.Focus() : Exit Sub

        sSQL = "select tblReqD.cYear,tblReqD.cMonth,tblsaldeductreq.EmpID,'1',tblPayrollEmployee.dispName,'INITIAL',tblsaldeductreq.Bank,tblsaldeductreq.Branch, tblsaldeductreq.BankAccount,'" & FK_GetIDR(cmbTrCode.Text) & "',0,'" & Format(dtpPayDate.Value, "yyMMdd") & "'," & strQuery & ",'BNo','BrN','origiACCNo','origiAccName', '0000','23','00','0',replace(CONVERT(DECIMAL(10,2),tblreqd.amount),'.',''),'SLR','      @','" & strReference & "' ,tblsaldeductreq.salItmID from tblsaldeductreq INNER JOIN tblReqd  ON tblsaldeductreq.reqID=tblreqd.reqID AND tblsaldeductreq.EmpID=tblReqD.regID INNER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblsaldeductreq.EmpID AND tblReqD.cYear=" & cmbYear.Text & " AND tblReqD.cMonth=" & cmbMonth.Text & " AND tblsaldeductreq.status=0 AND tblReqD.status=0 AND tblReqD.sProcess='Yes' AND tblsaldeductreq.SalItmId NOT IN (select salID from tblSummaryItem WHERE cStatus=1) ORDER BY tblsaldeductreq.EmpID,tblsaldeductreq.salItmID "
        Fk_FillGrid(sSQL, dgvData)
        Dim INTK As Integer = dgvData.RowCount
        ssql1 = "delete from [tblFinalSalaryBankLoan] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid);"
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
                        ssql1 = ssql1 & "INSERT INTO tblFinalSalaryBankLoan (cYear,cMonth,regid,accName,bankCode,brCode,accNumber,amount,Date,particular,bankCodeOr,brCodeOr,accNumberOr,accNameOr,filler1,filler2,filler3,filler4,filler5,slr,atSign,reference,salID) VALUES (" & Val(dgvData.Item(0, i).Value) & "," & Val(dgvData.Item(1, i).Value) & ",'" & dgvData.Item(2, i).Value & "','" & strAccName & "','" & dgvData.Item(6, i).Value & "','" & dgvData.Item(7, i).Value & "','" & dgvData.Item(8, i).Value & "','" & Val(dgvData.Item(21, i).Value) & "','" & Val(dgvData.Item(11, i).Value) & "','" & dgvData.Item(12, i).Value & "','" & dgvData.Item(13, i).Value & "','" & dgvData.Item(14, i).Value & "','" & dgvData.Item(15, i).Value & "','" & dgvData.Item(16, i).Value & "','" & dgvData.Item(17, i).Value & "','" & dgvData.Item(18, i).Value & "','" & dgvData.Item(19, i).Value & "','" & dgvData.Item(20, i).Value & "','" & dgvData.Item(21, i).Value & "','" & dgvData.Item(22, i).Value & "','" & dgvData.Item(23, i).Value & "','" & dgvData.Item(24, i).Value & "','" & Val(dgvData.Item(25, i).Value) & "');"

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

        'If rdTemporary.Checked = True Then

        '    Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblsd WHERE tblsd.salid=" & strsalid & " and tblsd.type1=2 and tblsd.cYear=" & cmbYear.Text & " and tblsd.cMonth=" & cmbMonth.Text & " and regid in (select regid from tblTempRegID)")

        '    If bolEx = False Then MessageBox.Show("There isn't data in Temparary location to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        '    sSQL = "UPDATE tblFinalSalaryBankLoan SET amount=tblsd.amount FROM tblsd,tblFinalSalaryBankLoan WHERE  tblFinalSalaryBankLoan.regID=tblsd.regID AND tblFinalSalaryBankLoan.cYear=tblsd.cYear AND tblFinalSalaryBankLoan.cMonth=tblsd.cMonth AND tblsd.salid=" & strsalid & " and tblsd.type1=2 and tblsd.cYear=" & cmbYear.Text & " and tblsd.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", False, False, True)

        'ElseIf rdPermanant.Checked = True Then

        '    Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblsdAll WHERE tblsdAll.salid=" & strsalid & " and tblsdAll.type1=2 and tblsdAll.cYear=" & cmbYear.Text & " and tblsdAll.cMonth=" & cmbMonth.Text & " and regid in (select regid from tblTempRegID)")

        '    If bolEx = False Then MessageBox.Show("There isn't data in Permenent location to generate bank detail file", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

        '    sSQL = "UPDATE tblFinalSalaryBankLoan SET amount=tblsdAll.amount FROM tblsdAll,tblFinalSalaryBankLoan WHERE  tblFinalSalaryBankLoan.regID=tblsdAll.regID AND tblFinalSalaryBankLoan.cYear=tblsdAll.cYear AND tblFinalSalaryBankLoan.cMonth=tblsdAll.cMonth AND tblsdAll.salid=" & strsalid & " and tblsdAll.type1=2 and tblsdAll.cYear=" & cmbYear.Text & " and tblsdAll.cMonth=" & cmbMonth.Text & " " : FK_EQ(sSQL, "P", False, False, True)

        'End If

        sSQL = "UPDATE tblFinalSalaryBankLoan SET bankCodeOr='" & strOriBankID & "',brCodeOr='" & strOriBranchID & "',accNumberOr='" & strOriAccNo & "',accNameOr='" & strOriAccName & "' WHERE cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)


        sSQL = "DELETE FROM tblFinalSalaryBankLoan WHERE CONVERT(decimal, amount)=0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid) " : FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "SELECT COUNT(cMonth) FROM tblFinalSalaryBankLoan WHERE CONVERT(NUMERIC (18,2),Amount)<0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid)"
        Dim intMinus = fk_sqlDbl(sSQL)
        If intMinus > 0 Then
            MessageBox.Show("There are " & intMinus & " employee(s) with minus salary, Please check it", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            sSQL = "INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Displayed the message about minus salary in  year of " & Val(cmbYear.Text) & " and month of " & Val(cmbMonth.Text) & " and employee(s) : " & intMinus & " ','" & StrUserID & "',0)" : FK_EQ(sSQL, "p", "", False, False, True)
        End If

        'sSQL = "SELECT tblFinalSalaryBankLoan.regID,'0000',RIGHT('0000'+ISNULL(tblFinalSalaryBankLoan.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBankLoan.brCode,''),3),RIGHT('000000000000'+ISNULL(tblFinalSalaryBankLoan.accNumber,''),12),RIGHT(''+ISNULL(tblFinalSalaryBankLoan.accName,''),30) , '23','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(tblFinalSalaryBankLoan.amount,''),12),'.',''),slr,RIGHT('0000'+ISNULL(bankCodeOr,''),4),RIGHT('000'+ISNULL(brCodeOr,''),3),accNumberOr,accNameOr,   CONVERT(INT, RIGHT('               '+ISNULL(tblFinalSalaryBankLoan.particular,''),15)),tblFinalSalaryBankLoan.reference,tblFinalSalaryBankLoan.Date,tblFinalSalaryBankLoan.atSign FROM [tblFinalSalaryBankLoan]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBankLoan.RegID   WHERE  tblFinalSalaryBankLoan.cYear=" & cmbYear.Text & " and tblFinalSalaryBankLoan.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBankLoan.regid in (select regid from tbltempregid) ORDER BY " & strQuery & ""
        'Fk_FillGrid(sSQL, dgvData)

        If rdbCom.Checked = True Then
            sSQL = "SELECT tblFinalSalaryBankLoan.regID,'0000',RIGHT('0000'+ISNULL(tblFinalSalaryBankLoan.bankCode,''),4),RIGHT('000'+ISNULL(tblFinalSalaryBankLoan.brCode,''),3),RIGHT('000000000000'+ISNULL(tblFinalSalaryBankLoan.accNumber,''),12),RIGHT(''+ISNULL(tblFinalSalaryBankLoan.accName,''),20) , '" & strSalFixCode & "','00','0','000000', REPLACE(RIGHT('000000000000'+ISNULL(tblFinalSalaryBankLoan.amount,''),12),'.',''),slr,RIGHT('0000'+ISNULL(bankCodeOr,''),4),RIGHT('000'+ISNULL(brCodeOr,''),3),accNumberOr,accNameOr,   CONVERT(INT, RIGHT('               '+ISNULL(tblFinalSalaryBankLoan.particular,''),15)),tblFinalSalaryBankLoan.reference,tblFinalSalaryBankLoan.Date,tblFinalSalaryBankLoan.atSign FROM [tblFinalSalaryBankLoan]  LEFT OUTER JOIN tblPayrollEmployee ON tblPayrollEmployee.RegID=tblFinalSalaryBankLoan.RegID   WHERE  tblFinalSalaryBankLoan.cYear=" & cmbYear.Text & " and tblFinalSalaryBankLoan.cMonth=" & cmbMonth.Text & "  and tblFinalSalaryBankLoan.regid in (select regid from tbltempregid) AND  CONVERT(NUMERIC (18,2),AMOUNT)>0 ORDER BY " & strQuery & ""
            Fk_FillGrid(sSQL, dgvData)
            lblCountH.Text = "Total Employees : " & dgvData.RowCount - 1

            Dim dr As DialogResult = MessageBox.Show("Do you want to create excel file with these data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dr = Windows.Forms.DialogResult.Yes Then
                ExporttoExcel(dgvData, 20)
            End If
            TextGeneratorCommercial()
            PB.Value = PB.Maximum

        End If

        Try
            sSQL = "select SUM (CONVERT(numeric (18,2),amount)) from [tblFinalSalaryBankLoan] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
            Dim dblTotAmount As Double = fk_sqlDbl(sSQL)
            sSQL = "select COUNT (amount) from [tblFinalSalaryBankLoan] where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & " and regid in (select regid from tbltempregid)"
            Dim dblToTCount As Double = fk_sqlDbl(sSQL)
            lblLoanAmount.Visible = True
            lblLoanCount.Visible = True
            lblLoanAmount.Text = "Loan Amount : " & dblTotAmount
            lblLoanCount.Text = "Loan Count : " & dblToTCount
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

        ssql1 = "delete from tblBankfileData where cyear=" & cmbYear.Text & " and cmonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid);"
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
                    If strAccName.Length > 20 Then MessageBox.Show("There are employee(s) with Long Names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub
                    If strAccNo.Length > 12 Then MessageBox.Show("There are employee(s) with Long Account Numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub
                    If strAccName = "" Then MessageBox.Show("There are employee(s) without names, Please check." & strAccName, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub
                    If strAccNo = "" Then MessageBox.Show("There are employee(s) without account numbers, Please check." & strAccName & " and " & strAccNo, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) ': Exit Sub

                    With dgvData
                        ssql1 = ssql1 & "INSERT INTO tblBankfileData (cYear,cMonth,regid,trID,accName,bankCode,brCode,accNumber,trnCode,amount,Date,particular) VALUES (" & Val(dgvData.Item(0, i).Value) & "," & Val(dgvData.Item(1, i).Value) & ",'" & dgvData.Item(2, i).Value & "'," & i + 1 & ",'" & strAccName & "','" & dgvData.Item(6, i).Value & "','" & dgvData.Item(7, i).Value & "','" & dgvData.Item(8, i).Value & "','" & strTrCode & "',0,'" & Val(dgvData.Item(11, i).Value) & "','" & dgvData.Item(12, i).Value & "');"
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

        sSQL = "SELECT COUNT(cMonth) FROM tblBankfileData WHERE CONVERT(NUMERIC (18,2),Amount)<0 AND cYear=" & cmbYear.Text & " and cMonth=" & cmbMonth.Text & "  and regid in (select regid from tbltempregid)"
        Dim intMinus = fk_sqlDbl(sSQL)
        If intMinus > 0 Then
            MessageBox.Show("There are " & intMinus & " employee(s) with minus salary, Please check it", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            sSQL = "INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Displayed the message about minus salary in  year of " & Val(cmbYear.Text) & " and month of " & Val(cmbMonth.Text) & " and employee(s) : " & intMinus & " ','" & StrUserID & "',0)" : FK_EQ(sSQL, "P", "", False, False, True)
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

    Private Sub cmbTrCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTrCode.SelectedIndexChanged

    End Sub
End Class