Public Class frmProcessTwo

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmProcessTwo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strPrCategory = fk_RetString("select processategory from tblCompany where compID='" & StrCompID & "'")
        CenterFormThemed(Me, Panel1, Label12)
        ControlHandlers(Me)
        FillComboAll(cmbMonth, "SELECT distinct[cmonth] from tblsd")
        cmbMonth.SelectedIndex = 0
        FillComboAll(cmbYear, "SELECT distinct[cyear] from tblsd")
        cmbYear.SelectedIndex = 0
        FillComboAll(cmbPrcat, "Select CatDesc+'='+catid from tblSetPrCategory where status='0' and CatDesc='" & strPrCategory & "' order by CatDesc asc")
        cmbPrcat.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If UP("Salary Process", "Do Salary Process 02") = False Then Exit Sub
        Dim PrID As String = FK_GetIDR(cmbPrcat.Text)

        'Month End
        If fk_sqlDbl("select atP from tblmonthend WHERE PrCatID='" & PrID & "' AND cYear=" & cmbYear.Text & " AND cMonth=" & cmbMonth.Text & " AND status=0") = 0 Or fk_sqlDbl("select salP from tblmonthend WHERE PrCatID='" & PrID & "' AND cYear=" & cmbYear.Text & " AND cMonth=" & cmbMonth.Text & " AND status=0") = 0 Then MessageBox.Show("Please do the attendance allowance process and temparary process before permanent process", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : LoadForm(New frmPaySalaryProcess) : Exit Sub

        If cmbYear.Text = "" Then MsgBox("Please Select Current Year", MsgBoxStyle.Information) : Exit Sub
        If cmbMonth.Text = "" Then MsgBox("Please Select Current Month", MsgBoxStyle.Information) : Exit Sub
        Try
            PB.Value = 10
          
            'Check if Data Exists and Exit if Data has
            sSQL = "CREATE TABLE #SD (REGID NVARCHAR (6)); INSERT INTO #SD Select DISTINCT REGID from tblSDALL where cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "'; CREATE TABLE #EM (REGID NVARCHAR (6)); INSERT INTO #EM Select RegID from  tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "' and Status='0'; SELECT #SD.REGID FROM #SD WHERE REGID IN (SELECT #EM.REGID FROM #EM)"
            'sSQL = "Select REGID from tblSDALL where cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "' and RegID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0')"
            If fk_CheckEx(sSQL) = True Then
                MsgBox("Data Already Exits in the Database cannot Process!...", MsgBoxStyle.Information) : Exit Sub
            End If
            'Coping Data to Permanat Database
            sSQL = "Insert into tblSDALL (RegID,cYear,cMonth,Type1,SalID,Amount,Des,SalDes)  Select RegID,cYear,cMonth,Type1,SalID,Amount,Des,SalDes from tblSD where RegID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0')"
            FK_EQ(sSQL, "S", "", False, False, True)
            PB.Value = 60

            'Coping Data to table Coins C/F
            Dim vYear, vMonth As Double
            vYear = Val(cmbYear.Text)
            vMonth = Val(cmbMonth.Text) + 1
            If vMonth = 13 Then
                vMonth = 1
                vYear = vYear + 1
            End If
            Load_InformationtoGrid("Select * from tblCoinCFT where EmpID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0')", dgvCoins, 2)
            sSQL = "Delete from tblCoinCFT "
            For X = 0 To dgvCoins.RowCount - 1
                dgvCoins.Item(2, X).Value = vYear
                dgvCoins.Item(3, X).Value = vMonth
                sSQL = sSQL & " Delete from tblCoinCF where EMPID='" & dgvCoins.Item(0, X).Value & "' and CYEAR='" & dgvCoins.Item(2, X).Value & "' and CMONTH='" & dgvCoins.Item(3, X).Value & "'; "
                sSQL = sSQL & " Insert into tblCoinCF(EMPID,AMOUNT,CYEAR,CMONTH) Values ('" & dgvCoins.Item(0, X).Value & "','" & dgvCoins.Item(1, X).Value & "','" & dgvCoins.Item(2, X).Value & "','" & dgvCoins.Item(3, X).Value & "')"
                If X Mod 25 = 0 Then FK_EQ(sSQL, "P", "", False, False, True) : sSQL = ""
            Next

            'Added for month end Process
            sSQL = sSQL & "; UPDATE tblmonthend SET permP=1 WHERE PrCatID='" & PrID & "' AND cYear=" & cmbYear.Text & " AND cMonth=" & cmbMonth.Text & " AND status=0"

            sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'FrmProcessTwo','Do the Process two for category :  " & cmbPrcat.Text & " and Year : " & cmbYear.Text & " and Month " & cmbMonth.Text & "','" & StrUserID & "',0,'' )"

            Dim bolEx As Boolean = FK_EQ(sSQL, "P", "", False, False, True)

            If bolEx = True Then
                AutoCanclLoan()
            End If

            PB.Value = PB.Maximum
            MsgBox("Process Completed Succesfully", MsgBoxStyle.Information)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub AutoCanclLoan() 'Loan canccel | Request deduction cancel | Various loan cancel
        Dim dtDate As DateTime
        dtDate = DateSerial(cmbYear.Text, cmbMonth.Text, 15)
        'Auto cancel expired request deductions | Kasun | 2019-05-14 | MID 101
        sSQL = "UPDATE tblSalDeductReq SET status=1 WHERE toDate<'" & Format(dtDate, "yyyyMMdd") & "' AND status<>1 " : FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "UPDATE tblReqd SET status=1,sProcess='No' WHERE reqid in (SELECT reqID from  tblSalDeductReq WHERE status=1) AND status<>1 " : FK_EQ(sSQL, "P", "", False, False, True)

        'Auto cancel expired various loans | Kasun | 2019-05-14 | MID 101
        sSQL = "UPDATE tblvariousloanh SET status=1 where dateadd(month,Months,startFrom)<'" & Format(dtDate, "yyyyMMdd") & "' AND status<>1 " : FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "UPDATE tblvariousloanD SET status=1 where loanID IN (SELECT LoanID FROM tblVariousLoanH where dateadd(month,Months,startFrom)<'" & Format(dtDate, "yyyyMMdd") & "') AND status<>1 " : FK_EQ(sSQL, "P", "", False, False, True)

        'Auto cancel expired extended loans | Kasun | 2019-05-14 | MID 101
        sSQL = "UPDATE tblLoanHN SET Loand_Status=9 WHERE dateADD(MONTH,no_Install,pay_startDate) < '" & Format(dtDate, "yyyyMMdd") & "' AND Loand_Status<>9 " : FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "UPDATE tblLoanDN SET Status = 9 WHERE LoanID IN (SELECT LoanID FROM tblLoanHN WHERE Loand_Status=9) AND status<>9" : FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "UPDATE tblGuranterH SET r_Status=9 WHERE lnNumber IN (SELECT LoanID FROM tblLoanHN WHERE Loand_Status=9) AND r_Status<>9 " : FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'CancelALoan','Cancelled bulk loan up to " & Format(dtDate, "yyyyMMdd") & "','" & StrUserID & "',0,'')" : FK_EQ(sSQL, "P", "", False, False, True)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If UP("Salary Process", "Delete Saved Salary Info") = False Then Exit Sub

        Try
            If MsgBox("Are you sure you want to do this?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
           
            If fk_CheckEx("Select REGID from tblSDALL where cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "' and RegID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & FK_GetIDR(cmbPrcat.Text) & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0')") = False Then
                MsgBox("Data Does Not exists to Delete", MsgBoxStyle.Information) : Exit Sub
            End If
            'Coping Data to Permanat Database
            sSQL = "Delete from  tblSDALL  where RegID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & FK_GetIDR(cmbPrcat.Text) & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0') and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "'"
            If FK_EQ(sSQL, "P", "", False, False, True) = True Then
                sSQL = "  INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Delete payroll data from permanant location for process category of " & FK_GetIDR(cmbPrcat.Text) & "  and year of " & Val(cmbYear.Text) & " and month of " & Val(cmbMonth.Text) & " ','" & StrUserID & "',0)"
                FK_EQ(sSQL, "E", "", False, False, True)
            End If

            PB.Value = PB.Maximum
            MsgBox("Process Completed Succesfully", MsgBoxStyle.Information)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Help.ShowHelp(Me, HelpProvider1.HelpNameSpace)
    End Sub
End Class