Imports System.Data.SqlClient

Public Class frmPaySalaryProcess

    Public strEMPID As String
    Dim sqlCMD As SqlCommand
    Public srcFieldValue As Double
    Public srcAmount As Double
    Public SRCID As String
    Dim ForID As String

    Private Sub FRMSalaryProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label5)
        ControlHandlers(Me)
        Me.Width = 461
        Me.Height = 299
        '============
        cmbYear.Items.Clear()

        For X = Now.Date.Year - 5 To Now.Date.Year + 5
            cmbYear.Items.Add(X)
        Next
        '==========
        cmbYear.Text = Now.Date.Year

        cmbMonth.Items.Clear()
        Dim intLastPermanant As Integer = fk_sqlDbl("select isnull (max(CONVERT(decimal,cmonth)),0)  from tblsdall where cyear=" & cmbYear.Text & "")

        For X = intLastPermanant To 12
            cmbMonth.Items.Add(X)
        Next

        cmbMonth.Text = Now.Date.Month
        ''sSQL = "CREATE TABLE tblSD(	[RegID] [nvarchar](50)  NULL,	[Cyear] [nvarchar](50)  NULL,	[Cmonth] [nvarchar](50)  NULL,	[type1] [numeric](18, 0) NULL,	[SalID] [nvarchar](50)  NULL,	[AMOUNT] [numeric](18, 2) NULL) "
        ''EQ(sSQL)
        FillComboAll(cmbPrcat, "select CatDesc+'='+CatID from tblSetPrCategory where Status='0' ")

        PB.Value = 0
        PB1.Value = 0
        IsEnableExtendedLoan = GetVal("SELECT IsEnableExtendedLoan FROM tblCompany WHERE CompID='" & StrCompID & "'")
        Button1.Enabled = True
    End Sub

    Private Sub WorkingAllowances()
        sSQL = "Insert into tblsd (RegID,cYear,CMonth,Type1,SalID,Amount)" & _
        "Select tblWorkingAllowances.EmpID,tblWorkingAllowances.cyear,tblWorkingAllowances.cMonth,'2',tblWorkingAllowances.Salaryitem,tblWorkingAllowances.Amount from tblWorkingAllowances,tblPayrollEmployee  where tblWorkingAllowances.EmpID=tblPayrollEmployee.RegID AND tblWorkingAllowances.cMonth='" & cmbMonth.Text & "' and tblWorkingAllowances.cYear='" & cmbYear.Text & "' and tblWorkingAllowances.status='0' AND tblPayrollEmployee.status=0"
        FK_EQ(sSQL, "P", "", False, False, False)

        Console.WriteLine("Step1 Completed")
    End Sub

    Private Sub ServiceCharge()
        sSQL = "Insert into tblsd (RegID,cYear,CMonth,Type1,SalID,Amount)" & _
        "Select tblServiceCharge.RegID,tblServiceCharge.cyear,tblServiceCharge.cMonth,'2',tblServiceCharge.SalID,tblServiceCharge.Amount from tblServiceCharge,tblPayrollEmployee  where tblServiceCharge.RegID=tblPayrollEmployee.RegID AND tblServiceCharge.cMonth='" & cmbMonth.Text & "' and tblServiceCharge.cYear='" & cmbYear.Text & "' and tblServiceCharge.tstatus='0' AND tblPayrollEmployee.status=0 AND tblServiceCharge.prcatID='" & FK_GetIDR(cmbPrcat.Text) & "' "
        FK_EQ(sSQL, "P", "", False, False, False)

        Console.WriteLine("Step8 Completed")
    End Sub

    Private Sub BonusProcess()
        sSQL = "Insert into tblsd (RegID,cYear,CMonth,Type1,SalID,Amount)" & _
        "Select tblBonus.EmpID,tblBonus.cyear,tblBonus.cMonth,'2',tblBonus.Salaryitem,tblBonus.Amount from tblBonus,tblPayrollEmployee  where tblBonus.EmpID=tblPayrollEmployee.RegID AND tblBonus.cMonth='" & cmbMonth.Text & "' and tblBonus.cYear='" & cmbYear.Text & "' and tblBonus.status='0' AND tblPayrollEmployee.status=0 AND tblPayrollEmployee.prcatID='" & FK_GetIDR(cmbPrcat.Text) & "'"
        FK_EQ(sSQL, "P", "", False, False, False)

        Console.WriteLine("Step9 Completed")
    End Sub

    Private Sub TransferMinusSalary()
        Dim bolMinus As Boolean = False
        Dim StrList As String = ""
        sSQL = "SELECT Amount from tblsd where salID=7 and Amount<0"
        If fk_CheckEx(sSQL) = True Then
            bolMinus = True
            MessageBox.Show("The system is indicated employee(s) who has minus salary for  this month. Now system will display the name(s) of them", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'If DR = Windows.Forms.DialogResult.Yes Then
            sSQL = "SELECT tblSD.RegID AS 'Reg ID',tblPayrollemployee.dispName AS 'Employee Name',tblPayrollemployee.emIDNum AS 'NIC Number',tblSD.Amount AS 'Amount',tblPayrollemployee.BasicSalary AS 'Basic Salary' FROM tblSD INNER JOIN tblPayrollEmployee ON tblSD.RegID=tblPayrollEmployee.RegiD AND tblSD.type1=2 AND tblSD.salID=7 and tblSD.Amount<0"
            Fk_FillGrid(sSQL, dgvMinusList)
            If dgvMinusList.RowCount > 0 Then
                Me.Width = 461
                Me.Height = 435
            End If
            For k As Integer = 0 To dgvMinusList.RowCount - 1
                StrList = StrList & "" & dgvMinusList.Item(0, k).Value & "" & ","
            Next
            StrList = StrList.Substring(0, StrList.Length - 1)
            'End If

            sSQL = "DELETE FROM tblSDMinus WHERE cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "' AND REGID IN (" & StrList & ") ; Insert into tblSDMinus (RegID,cYear,CMonth,Type1,SalID,Amount,Des,Saldes)" &
       "Select RegID,cYear,CMonth,Type1,SalID,Amount,Des,Saldes from tblSD  where cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "' and amount<0 and salid=7; INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Displayed the message about minus salary in while process year of " & Val(cmbYear.Text) & " and month of " & Val(cmbMonth.Text) & " and employee(s) : " & StrList & " ','" & StrUserID & "',0)"
            FK_EQ(sSQL, "P", "", False, False, False)
        End If
        Console.WriteLine("Step10 Completed")

    End Sub

    Private Sub AttendenceFormula()

        Dim PrID As String = FK_GetIDR(cmbPrcat.Text) ' GetString("Select CatID from tblSetPrCategory where CatDesc = '" & cmbPrcat.Text & "'")
        sSQL = "Delete from  tblEmployeeAttendenceItems where AttendenceItem not in (Select SalaryItem from tblAttendenceFormula)" & _
        " Delete from  tblEmployeeAttendenceItems where Profile not in (Select ProfileName from tblAttendenceFormula)"
        EQ(sSQL)
        sSQL = "drop table tblAtten"    ''CREATE TABLE [dbo].[tblAtten](	[EMPID] [nvarchar](10)  NULL,	[Salitem] [numeric](18, 0) NULL,	[Prof] [numeric](18, 0) NULL,	[ActiveField] [numeric](18, 0) NULL,	[Days] [numeric](18, 0) NULL,	[Fld] [nvarchar](50)  NULL,	[Amount] [numeric](18, 2) NOT NULL DEFAULT ((0))) ON [PRIMARY]"
        FK_EQ(sSQL, "P", "", False, False, False) 'hear two lines below with where 
        sSQL = "Delete from tblAtten Delete from tblEmployeeAttendenceItems where AttendenceItem='' or Profile='' " & _
        " Insert into tblAtten (EMPID,SalItem,Prof) select EMPID,AttendenceItem,Profile from tblEmployeeAttendenceItems where empid in (Select RegID from tblPayrollEmployee where PrcatID='" & PrID & "')" & _
        " Update tblAtten set tblAtten.fld=tblAttendenceFormula.activeField from tblAttendenceFormula " & _
        " inner join tblAtten on tblAtten.salItem=tblAttendenceFormula.SalaryItem and " & _
        " tblAtten.Prof = tblAttendenceFormula.ProfileName "
        FK_EQ(sSQL, "P", "", False, False, True)
        PB.Value = 0
        PB.Maximum = grd.RowCount + 3
        dgvAtten.Rows.Clear()
        sSQL = "select * from tblAtten"
        'Fk_FillGrid(sSQL, dgvAtten)
        Load_InformationtoGrid(sSQL, dgvAtten, 6)
        sSQL = ""
        PB.Value = 0
        PB.Maximum = dgvAtten.RowCount
        For X = 0 To dgvAtten.RowCount - 1
            sSQL = sSQL & "        UPDATE    tblAtten SET              tblAtten.Days = tblAttsum." & dgvAtten.Item(5, X).Value.ToString() & "  FROM         tblAttsum INNER JOIN tblAtten ON tblAtten.empID = tblAttsum.RegID WHERE     cMonth = '" & cmbMonth.Text & "' AND cYear = '" & cmbYear.Text & "' "
            PB.Value = X
            If X Mod 25 = 0 Then FK_EQ(sSQL, "S", "", False, False, True) : sSQL = ""
        Next
        If sSQL <> "" Then FK_EQ(sSQL, "P", "", False, False, True)
        PB.Value = PB.Maximum
        Load_InformationtoGrid("select * from tblAtten order by EmpID", dgvAtten, 7)
        sSQL = "Select SalaryItem,ProfileName,ActiveField,NoofDays,GivenAmount,typeID from tblAttendenceFormula order by NoofDays Desc"
        Load_InformationtoGrid(sSQL, dgvForm, 6)
        'Fk_FillGrid(sSQL, dgvForm)
        PB.Value = 0
        PB.Maximum = dgvAtten.RowCount + 2
        For X = 0 To dgvAtten.RowCount - 1
            If (dgvAtten.Item(4, X).Value) <> "" Then

                For Y = 0 To dgvForm.RowCount - 1
                    'Type ID - Mean Grater than
                    If dgvForm.Item(5, Y).Value = 1 Then

                        ' Salary item                           'Salary Item               Profile                      Profile                           Active Field              ActiveField                   No of Days                     No of Days           
                        If dgvAtten.Item(1, X).Value = dgvForm.Item(0, Y).Value And dgvAtten.Item(2, X).Value = dgvForm.Item(1, Y).Value And dgvAtten.Item(5, X).Value = dgvForm.Item(2, Y).Value And dgvForm.Item(3, Y).Value <= dgvAtten.Item(4, X).Value Then
                            'MsgBox(dgvForm.Item(4, Y).Value)
                            '         Amount                      Given Amount
                            dgvAtten.Item(6, X).Value = dgvForm.Item(4, Y).Value
                            Exit For
                        End If
                        'Type ID Mean Less Than
                    ElseIf dgvForm.Item(5, Y).Value = 2 Then
                        ' Salary item                           'Salary Item               Profile                      Profile                           Active Field              ActiveField                   No of Days                     No of Days           
                        If dgvAtten.Item(1, X).Value = dgvForm.Item(0, Y).Value And dgvAtten.Item(2, X).Value = dgvForm.Item(1, Y).Value And dgvAtten.Item(5, X).Value = dgvForm.Item(2, Y).Value And dgvForm.Item(3, Y).Value >= dgvAtten.Item(4, X).Value Then
                            '         Amount                      Given Amount
                            dgvAtten.Item(6, X).Value = dgvForm.Item(4, Y).Value
                        End If
                    End If
                Next
            End If
            PB.Value = X
        Next
        PB.Value = PB.Maximum
        sSQL = ""
        PB.Value = 0
        PB.Maximum = dgvAtten.RowCount + 2
        For X = 0 To dgvAtten.RowCount - 1
            PB.Value = X
            sSQL = sSQL & " insert into tblsd (regid,cyear,cmonth,type1,salid,amount)" & _
            " values('" & dgvAtten.Item(0, X).Value & "','" & Val(cmbYear.Text) & "','" & Val(cmbMonth.Text) & "','2','" & dgvAtten.Item(1, X).Value & "','" & dgvAtten.Item(6, X).Value & "')"
            If X Mod 25 = 0 Then FK_EQ(sSQL, "S", "", False, False, True) : sSQL = ""
        Next
        FK_EQ(sSQL, "S", "", False, False, True)
        PB.Value = PB.Maximum
        'For X = 0 To dgvAtten.RowCount - 1
        '    dgv1.Rows.Add(, cmbYear.Text, cmbMonth.Text, 0, 2, dgvAtten.Item(1, X).Value, dgvAtten.Item(6, X).Value, "")
        'Next
        Fk_FillGrid("Select * from  tblDayFields", dgvAt)
        sSQL = ""
        For X = 0 To dgvAt.RowCount - 1
            sSQL = sSQL & "insert into tblsd (regid,cyear,cmonth,type1,salid,amount)  Select RegID,cYear,Cmonth,'1','" & dgvAt.Item(0, X).Value.ToString & "'," & dgvAt.Item(1, X).Value.ToString & " from tblAttsum where cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "'"

        Next
        FK_EQ(sSQL, "S", "", False, False, True)

        Console.WriteLine("Step2 Completed")

    End Sub

    Private Sub FixedFields()

        Dim sSQL As String
        sSQL = "Insert into tblsd (regid,cyear,cmonth,type1,salid,amount) SELECT DISTINCT dbo.tblEmployeeFixedField.EmpID, '" & cmbYear.Text & "' AS 'Year', '" & cmbMonth.Text & "' AS 'Month',  '2' AS 'Type', dbo.tblFixedField.SalaryItem, dbo.tblFixedField.Amount " & _
        " FROM         dbo.tblEmployeeFixedField INNER JOIN dbo.tblFixedField ON dbo.tblEmployeeFixedField.ID = dbo.tblFixedField.ID "
        FK_EQ(sSQL, "P", "", False, False, True)
        Console.WriteLine("Step3 Completed")
        sSQL = "Insert into tblSD (RegID,cYear,cMonth,Type1,SalID,Amount) select tblIndiFixedFields.RegID,'" & cmbYear.Text & "','" & cmbMonth.Text & "','2',tblIndiFixedFields.SalID,tblIndiFixedFields.Amount from tblIndiFixedFields,tblPayrollEmployee where tblIndiFixedFields.regID=tblPayrollEmployee.RegID AND tblIndiFixedFields.status='0' AND tblPayrollEmployee.Status=0 ORDER BY tblIndiFixedFields.REGID"
        FK_EQ(sSQL, "P", "", False, False, True)

    End Sub

    Private Sub EMPREQ()

        'New Line Addres by Aruna
        sSQL = "Insert into tblsd (RegID,cYear,CMonth,Type1,SalID,Amount)" & _
        "Select regid,cyear,cmonth,'2',salfield,amount from tblReqD where cyear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "' and sProcess='Yes'  and status='0' and fullSalary='0'"
        FK_EQ(sSQL, "P", "", False, False, True)
        Console.WriteLine("Step3 Completed")
        'New Line Added By Aruna

    End Sub

    Private Sub LoanProcess()
        ''sSQL = "Create table tblPaidLoan ( LoanNo varchar(20),EmpID varchar(20),InstNo Decimal(18,0),cMonth Decimal(18,0),cYear Decimal(18,0),LnAmt Decimal(18,2),IntAmt Decimal(18,2)); "
        ''EQ(sSQL)
        sSQL = "Alter table tblsd add Des varchar(100)"
        EQ(sSQL)
        If fk_CheckEx("Select * from tblPaidLoan where cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "'") = True Then
            sSQL = "Update tblLoanH set RecLnAmt=RecLnAmt-tblPaidLoan.LnAmt, RecIntAmt=RecIntAmt-tblPaidLoan.IntAmt from tblPaidLoan " & _
            " inner join tblLoanH on tblPaidLoan.LoanNo=tblLoanH.LoanNo and tblPaidLoan.EmpID=tblLoanH.EmpID " & _
            " Where tblPaidLoan.cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "'; Delete from tblPaidLoan Where tblPaidLoan.cYear='" & cmbYear.Text & "' and tblPaidLoan.cMonth='" & cmbMonth.Text & "' "
            FK_EQ(sSQL, "P", "", False, False, True)
        End If
        sSQL = "Insert into tblPaidLoan  Select LoanNo,EmpID,InstNo,cMonth,cYear,LnAmt,IntAmt from tblloanD where Status='0' and cMonth='" & Val(cmbMonth.Text) & "' and cYear='" & cmbYear.Text & "';"
        FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "Update tblLoanH set RecLnAmt=RecLnAmt+tblPaidLoan.LnAmt, RecIntAmt=RecIntAmt+tblPaidLoan.IntAmt from tblPaidLoan" & _
        " inner join tblLoanH on tblPaidLoan.LoanNo=tblLoanH.LoanNo and tblPaidLoan.EmpID=tblLoanH.EmpID" & _
        " Where tblPaidLoan.cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "';"
        FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "Create view tk as Select  tblLoanType.AmtID,tblLoanType.IntID,tblLoanH.LoanAmt,tblLoanH.RecLnAmt,tblLoanH.LoanAmt-tblLoanH.RecLnAmt as 'LoanBalance',tblLoanH.IntAmt-tblLoanH.RecIntAmt as 'IntBalance', tblLoanH.EmpID,tblPaidLoan.LnAmt,tblPaidLoan.IntAmt from tblPaidLoan inner join tblLoanH on tblPaidLoan.LoanNo=tblLoanH.LoanNo and tblPaidLoan.EmpID=tblLoanH.EmpID inner join tblLoanType on tblLoanType.TypeID=tblLoanH.LoanType  " & _
        " where  tblPaidLoan.cYear='" & cmbYear.Text & "' and tblPaidLoan.cMonth='" & cmbMonth.Text & "';"
        FK_EQ(sSQL, "P", "", False, False, True)
        sSQL = "Insert into tblsd (RegID,cYear,CMonth,Type1,SalID,Amount,Des) Select EmpID," & cmbYear.Text & "," & cmbMonth.Text & ",'2',AmtID,LnAmt,LoanBalance from tk; " & _
        " Insert into tblsd (RegID,cYear,CMonth,Type1,SalID,Amount,Des) Select EmpID," & cmbYear.Text & "," & cmbMonth.Text & ",'2',intID,IntAmt,IntBalance from tk; drop view tk; "
        FK_EQ(sSQL, "P", "", False, False, True)
        Console.WriteLine("Step4 Completed")

        'Various Loan
        sSQL = "insert into tblsd (RegID,cYear,cMonth,Type1,SalID,Amount,Des,Saldes) select tblvariousloanh.RegID, cYear,cMonth,'2',tblvariousloanh.SalID,Amount,'',tblsalaryItems.Description from tblvariousloand left join tblvariousloanh on tblvariousloanh.Loanid=tblvariousloand.Loanid left join tblsalaryitems on tblsalaryitems.id=tblvariousloanh.salid where cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "' and tblvariousloand.status='0'"
        FK_EQ(sSQL, "P", "", False, False, True)
    End Sub

    Private Sub Step6()

        For X = 0 To grd.RowCount - 1
            Dim strEMPID As String = grd.Item(0, X).Value
            Dim sqlstr As String = ""
            Dim CN3 As New SqlConnection
            'Formula Fields
            If CN3.State = ConnectionState.Open Then CN3.Close()
            CN3 = New SqlConnection(sqlConString)
            CN3.Open()
            sqlstr = "SELECT     TOP (100) PERCENT dbo.tblFormula.SalaryField, dbo.tblFormula.Formula, dbo.tblFormulaOrder.OrderID FROM         dbo.tblEmployeeFormulaField INNER JOIN                      dbo.tblFormula ON dbo.tblEmployeeFormulaField.ID = dbo.tblFormula.ID INNER JOIN                      dbo.tblFormulaOrder ON dbo.tblFormula.ID = dbo.tblFormulaOrder.ItemID WHERE     (dbo.tblEmployeeFormulaField.EmpID = '" & strEMPID & "')"
            'sqlstr = "SELECT     dbo.tblFormula.Formula, dbo.tblFormula.SalaryField FROM         dbo.tblEmployeeFormulaField INNER JOIN                   dbo.tblFormula ON dbo.tblEmployeeFormulaField.ID = dbo.tblFormula.ID WHERE     (dbo.tblEmployeeFormulaField.EmpID = '" & strEMPID & "') "
            sqlCMD = New SqlCommand(sqlstr, CN3)
            Dim sqlDtaReader1 As SqlDataReader
            sqlDtaReader1 = sqlCMD.ExecuteReader
            Dim strSALID As String
            While sqlDtaReader1.Read()
                txtFormula.Text = ""
                txtFormula.Text = sqlDtaReader1.Item(1)
                strSALID = sqlDtaReader1.Item(0)
                'MsgBox(strSALID)
                DG.Rows.Clear()
                'get data to Grid
                Dim strValue As Double = 0
                Dim y As Integer = 0
                For X1 = 1 To Len(txtFormula.Text)
                    If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 5) = "Field" Then
                        'MsgBox(X1)
                        For y = X1 To Len(txtFormula.Text)
                            Dim verStart, VerStop As Integer
                            If Mid((txtFormula.Text), y, 1) = "[" Then
                                verStart = y + 1
                            End If
                            If Mid((txtFormula.Text), y, 1) = "]" Then
                                VerStop = y - verStart
                                DG.Rows.Add((Mid(txtFormula.Text, verStart, VerStop)), "")
                                Exit For
                            End If
                        Next
                    End If

                    If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "+" Then
                        DG.Rows.Add("+", "")
                    End If
                    If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "-" Then
                        DG.Rows.Add("-", "")
                    End If
                    If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "X" Then
                        DG.Rows.Add("*", "")
                    End If
                    If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "/" Then
                        DG.Rows.Add("/", "")
                    End If
                    If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 8) = "External" Then
                        For y = X1 To Len(txtFormula.Text)

                            Dim verStart, VerStop As Integer
                            If Mid((txtFormula.Text), y, 1) = "[" Then
                                verStart = y + 1
                            End If
                            If Mid((txtFormula.Text), y, 1) = "]" Then
                                VerStop = y - verStart
                                DG.Rows.Add((Mid(txtFormula.Text, verStart, VerStop)), "")
                                Exit For
                            End If
                        Next
                    End If
                    If PB.Value <= PB.Maximum - 1 Then
                        PB.Value = PB.Value + 1
                    End If
                Next

                'Formula Fields
                Dim srcValue As Double = 0
                Dim srcValue1 As Double = 0
                For I = 0 To DG.RowCount - 1
                    ' Dim strString As String
                    'strString = Trim(DG.Rows(I).Cells(0).Value)
                    If Val(DG.Rows(I).Cells(0).Value) = 0 And Len(Trim(DG.Rows(I).Cells(0).Value)) > 1 Then
                        SRCID = GetVal("Select ID from tblSalaryitems where Description='" & Trim(DG.Rows(I).Cells(0).Value) & "'")
                        For j = 0 To dgv1.RowCount - 1
                            If dgv1.Item(0, j).Value = strEMPID And SRCID = dgv1.Item(5, j).Value Then
                                DG.Rows(I).Cells(1).Value = dgv1.Item(6, j).Value
                                'ElseIf dgv1.Item(0, j).Value = strEMPID And SRCID <> dgv1.Item(5, j).Value Then
                                'DG.Rows(I).Cells(1).Value = 0
                            End If
                        Next
                    Else
                        DG.Rows(I).Cells(1).Value = DG.Rows(I).Cells(0).Value
                    End If
                Next
                wait(10)
                '''''''''''''''''''''''''''''''''''''''''''''''
                Dim verTotal As Double = 0
                Dim verTotal1 As Double = 0
                verTotal = Val(DG.Rows(0).Cells(1).Value)
                'MsgBox(verTotal)
                For I = 0 To DG.RowCount - 3
                    If Trim(DG.Rows(I + 1).Cells(1).Value) = "+" Then
                        verTotal = verTotal + Val(DG.Rows(I + 2).Cells(1).Value)
                    End If
                    If Trim(DG.Rows(I + 1).Cells(1).Value) = "-" Then
                        verTotal = verTotal - Val(DG.Rows(I + 2).Cells(1).Value)
                    End If
                    If Trim(DG.Rows(I + 1).Cells(1).Value) = "*" Then
                        verTotal = verTotal * Val(DG.Rows(I + 2).Cells(1).Value)
                    End If
                    If Trim(DG.Rows(I + 1).Cells(1).Value) = "/" Then
                        verTotal = verTotal / Val(DG.Rows(I + 2).Cells(1).Value)
                    End If
                Next
                'MsgBox(verTotal)
                dgv1.Rows.Add(grd.Item(0, X).Value, cmbYear.Text, cmbMonth.Text, 0, 2, strSALID, verTotal, "")
                DG.Rows.Clear()
                SRCID = ""
            End While

        Next

        Console.WriteLine("Step5 Completed")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'LoadForm(New frmLicence)
        'If bolLicenced = False Then
        '    Label5.Text = "Licence Error"
        '    'MessageBox.Show("Your licence period has exceeded", "Attention", MessageBoxButtons.OK)
        '    Exit Sub
        'End If

        Try
            Me.Width = 461
            Me.Height = 299
            If UP("Salary Process", "Do Salary Process 01") = False Then Exit Sub
            If Val(cmbYear.Text) >= 2019 And Val(cmbMonth.Text) >= 12 Then MsgBox("Salary process can't continue. Erorr Code 00088x", MsgBoxStyle.Critical) : End
            If cmbMonth.Text = "" Then MsgBox("Please Select Month First!...", MsgBoxStyle.Critical) : cmbMonth.Focus() : Exit Sub
            If cmbYear.Text = "" Then MsgBox("Please Select Year First!...", MsgBoxStyle.Critical) : cmbYear.Focus() : Exit Sub
            If cmbPrcat.Text = "" Then MsgBox("Please Select Process Category from the List", MsgBoxStyle.Critical) : cmbPrcat.Focus() : Exit Sub
            Dim PrID As String = FK_GetIDR(cmbPrcat.Text) 'GetString("Select CatID from tblSetPrCategory where CatDesc = '" & cmbPrcat.Text & "'")
            'Month End
            'If fk_sqlDbl("select atP from tblmonthend WHERE PrCatID='" & PrID & "' AND cYear=" & cmbYear.Text & " AND cMonth=" & cmbMonth.Text & " AND status=0") = 0 Then MessageBox.Show("Please do the attendance allowance process before salary process", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : LoadForm(New FrmProcessAttendenceAllowances) : Exit Sub

            'Check for formula unassigned employees in selected process category
            sSQL = "select regID,dispname from tblpayrollemployee where PrCatID=" & PrID & " AND status =0 AND  regID NOT IN (select distinct empid from tblEmployeeFormulaField)"
            Fk_FillGrid(sSQL, frmMainAttendance.dgvFillGridforRead)
            If frmMainAttendance.dgvFillGridforRead.RowCount > 0 Then
                Dim dr As DialogResult = MessageBox.Show("There are " & frmMainAttendance.dgvFillGridforRead.RowCount & " employee(s) in the database, without any formula. Do you want to set pay items for them?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                If dr = Windows.Forms.DialogResult.Yes Then
                    sSQL = "DELETE FROM tbltempregid; INSERT INTO tbltempregid select regID,'" & cmbYear.Text & "','" & cmbMonth.Text & "' from tblpayrollemployee where PrCatID=" & PrID & " AND status =0 AND  regID NOT IN (select distinct empid from tblEmployeeFormulaField)"
                    FK_EQ(sSQL, "D", "", False, False, True) : bolUnAssignedFormula = True : LoadForm(New frmEmployeePayItem) : Exit Sub
                Else
                    Exit Sub
                End If
            End If

            Button1.Enabled = False
            PB.Value = 0

            'Get prrocessed employees for this month from permanant location 20150106 ************************************************************************************************************
            sSQL = "delete from tblTempRegID; insert into tblTempRegID select distinct regid,cYear,cmonth from tblsdall where cYear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' " : FK_EQ(sSQL, "D", "", False, False, True)
            'Delete only tempary location employees for this month 20150106
            sSQL = "Delete from tblPayEmpMRecords where cYear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' and PrcatID='" & PrID & "'   and regid not in (select regid from tblTempRegID) ;  Insert into  tblPayEmpMRecords  SELECT     RegID,'" & cmbYear.Text & "','" & cmbMonth.Text & "', DispName, EMPNo, EPFNo, ETPNo, ComID, DesigID, BrID, DeptID, BasicSalary, DaysPay, EpfAllowed, PayID, CostID, SalViewLevel, Status, PrCatID,     EmIdNum,sub_Catid,empTypeID,religionID,genderID FROM         dbo.tblPayrollEmployee where PrcatID='" & PrID & "'     and regid not in (select regid from tblTempRegID) and status=0" : FK_EQ(sSQL, "P", "", False, False, True)
            '************************************************************************************************************

            If isCheckEmpCountOfBoth = 1 Then
                Dim dblEmpAtCount As Double = fk_sqlDbl("select count(regid) from tblattsum where cYear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' ")
                Dim dblEmpPayCount As Double = fk_sqlDbl("select count(regid) from tblpayempmrecords where cYear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' and status=0")

                Dim dgvExcist As New DataGridView
                If dblEmpAtCount < dblEmpPayCount Then
                    Dim dr As DialogResult = MessageBox.Show("There are employees in Payroll System that not in Attendance System. Please Check and Synchronize. Do you want to know about those employee(s) ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                    If dr = Windows.Forms.DialogResult.Yes Then
                        sSQL = "select Regid,etpno,empNo,epfNo,dispName from tblpayempmrecords  where cmonth='" & cmbMonth.Text & "' and cyear='" & cmbYear.Text & "' and status=0 and regid not in (select Regid from tblattsum where  cmonth='" & cmbMonth.Text & "' and cyear='" & cmbYear.Text & "')"
                        Load_InformationtoGrid(sSQL, dgvComEmploye, 5)
                        sSQL1 = ""
                        For ik As Integer = 0 To dgvComEmploye.RowCount - 1
                            sSQL1 = sSQL1 & dgvComEmploye.Item(4, ik).Value & "/ "
                        Next
                        sSQL1 = Microsoft.VisualBasic.Left(sSQL1, sSQL1.Length - 4)
                        MessageBox.Show("Employee names are " & sSQL1, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                    Exit Sub
                ElseIf dblEmpAtCount > dblEmpPayCount Then
                    Dim dr As DialogResult = MessageBox.Show("There are employees in Attendance System that not in Payroll System. Please Check and Synchronize. Do you want to know about those employee(s) ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
                    If dr = Windows.Forms.DialogResult.Yes Then
                        sSQL = "select Regid,'','','',Regid from tblattsum where cmonth='" & cmbMonth.Text & "' and cyear='" & cmbYear.Text & "' and regid not in (select Regid from tblpayempmrecords  where cmonth='" & cmbMonth.Text & "' and cyear='" & cmbYear.Text & "' and status=0)"
                        Load_InformationtoGrid(sSQL, dgvComEmploye, 5)
                        sSQL1 = ""
                        For ik As Integer = 0 To dgvComEmploye.RowCount - 1
                            sSQL1 = sSQL1 & dgvComEmploye.Item(4, ik).Value & "/ "
                        Next
                        sSQL1 = Microsoft.VisualBasic.Left(sSQL1, sSQL1.Length - 4)
                        MessageBox.Show("Employee names are " & sSQL1, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    End If
                    Exit Sub
                End If
            End If
            '***************************************************************************************************************************

            '========adding is over
            sSQL = "Delete from tblSD;Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) " & _
    " Select RegID,'" & cmbYear.Text & "','" & cmbMonth.Text & "','2','1',BasicSalary from tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0'; Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) Select RegID,'" & cmbYear.Text & "','" & cmbMonth.Text & "','2','2',DaysPay from tblPayEmpMRecords   where PrcatID='" & PrID & "' and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0'; Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) Select EmpID,cyear,cmonth,'2','5',Amount from tblCoincf where cyear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' and EmpID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0') ;"
            FK_EQ(sSQL, "D", "", False, False, True)

            If isRoundBudget = 1 Then
                RoundBudjetFivePercentCWE()
            End If

            PB.Maximum = 100
            PB.Value = 25
            dgv1.Rows.Clear()
            'dgv2.Rows.Clear()
            DG.Rows.Clear()
            ' dgv3.Rows.Clear()
            grd.Rows.Clear()
            PB1.Value = 10
            'AttendenceFormula()
            lblCurrentProcessr.Text = "Attendance Allowances"
            NewAttFormula()
            PB1.Value = 20
            FixedFields()
            PB1.Value = 30

            If intIsSpecialAllowance = 1 Then
                'Processing Special Allowances 02
                sSQL = "exec SpecialAllowances '" & cmbYear.Text & "','" & cmbMonth.Text & "','16','18' "
                FK_EQ(sSQL, "P", "", True, True, True)
            End If

            lblCurrentProcessr.Text = "Monthly Allowances"
            WorkingAllowances()

            '20190308 | Bonus and lumpsum process
            BonusProcess()

            If isServiceCharge = 1 Then
                ServiceCharge()
            End If

            PB1.Value = 40
            '****************** LOAN UPDATE (EXTENED) ***************
            'NEW UPDATE By : Kasun
            'If IsEnableExtendedLoan = 1 Then
            '    _Process_ExLoan(cmbYear.Text, cmbMonth.Text)
            '    PB1.Value = 40
            'Else
            LoanProcess()
            'PB1.Value = 40
            'End If


            PB1.Value = 50
            If isRequestDeduct = 1 Then
                EMPREQ()
            End If
            PB1.Value = 60
            FormulaFieldData()
            PB1.Value = 90
            sSQL = "Delete from tblsd where RegID  in (Select RegID from tblPayEmpMRecords where PrcatID <> '" & PrID & "' and cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "')"
            FK_EQ(sSQL, "D", "", False, False, True)

            '===========added at second

            '================================Rajitha.
            '5th line tblPayEmpMRecords.brid=tblPayEmpMRecords.comid where     hear tblpayempmrecords.comid has changed to brid
            sSQL = "declare @ProCatID varchar(3) declare @ViewLevel decimal(18,0) declare @cMonth decimal(18,0)  declare @cYear decimal(18,0) " & _
            " set @ProCatID='" & PrID & "' set @ViewLevel=" & Val(UserVal) & " set @cMonth='" & cmbMonth.Text & "'set @cYear='" & cmbYear.Text & "' " & _
            " insert into tblsd (regid,cyear,cmonth,type1,salid,saldes) Select  RegID,@cYear,@cMonth,'3','10',tblcbranchs.brName from " & _
            " tblPayEmpMRecords  inner join tblcbranchs on tblcbranchs.compid=tblPayEmpMRecords.comid and " & _
    " tblPayEmpMRecords.brid=tblPayEmpMRecords.brid where PrcatID=@ProCatID and salviewLevel<=@ViewLevel  and tblPayEmpMRecords.cyear=@cYear and tblPayEmpMRecords.cMonth=@cMonth  insert into tblsd " & _
    " (regid,cyear,cmonth,type1,salid,saldes)  Select  RegID,@cYear,@cMonth,'3','6',tblcompany.cName from tblPayEmpMRecords  inner join tblcompany on tblcompany.compid=tblPayEmpMRecords.comid where PrcatID=@ProCatID and salviewLevel<=@ViewLevel  and tblPayEmpMRecords.cyear=@cYear and tblPayEmpMRecords.cMonth=@cMonth  "
            sSQL = sSQL & " insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','8',Desigid from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth update tblSd set  saldes=tblDesig.Desgdesc from tblDesig inner join tblSd on tblSD.SalDes=tblDesig.DesgID where Type1='3' and SalID='8' insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','12',DeptID from tblPayEmpMRecords  where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth   update tblSd set  saldes=tblsetDept.DeptName from tblsetDept inner join tblSd on tblSD.SalDes=tblsetDept.DeptID where Type1='3' and SalID='12' "
            sSQL = sSQL & " insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','1','Name: '+DispName from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','2','Emp No: '+EmpNo from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','3','Epf No: '+EpfNo from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','4','Etf No: '+EtpNo from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','5','Company ID: '+ComID from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth "
            sSQL = sSQL & "insert into tblsd (regid,cyear,cmonth,type1,salid,saldes) select RegID,cYear,cMonth,'3','9','Branch ID: '+brid from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes) select RegID,cYear,cMonth,'3','11','Dept ID: '+deptid from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','11',deptid from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','13',payid from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','15',costid from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth insert into tblsd (regid,cyear,cmonth,type1,salid,saldes)  select RegID,cYear,cMonth,'3','17','NIC No: '+EmIDNum from tblPayEmpMRecords where PrcatID=@ProCatID and salviewLevel<=@ViewLevel and cyear=@cyear and cmonth=@cmonth  "

            FK_EQ(sSQL, "P", "", False, False, True)
            '================adding part over

            If intRoundSalary = 1 Then
                RounSalary()
            End If

            If isDeleteNetSalryBank = 1 Then
                DeleteNetPayBankAcordingEmployee()
            End If

            TransferMinusSalary()

            'New Code by Aruna
            'In there Change Net Pay Amount As 'Pay by Cash' and 'Pay to Bank'
            'Dim sDGV As New DataGridView
            'sSQL = "select regid,amount from tblsd where  salid='7' and type1='2'"
            'Fk_FillGrid(sSQL, sDGV)
            'sSQL = ""
            'For X = 0 To sDGV.RowCount - 1
            '    If sDGV.Item(0, X).Value <> "" Then
            '        sSQL = sSQL & " Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) values ('" & sDGV.Item(0, X).Value & "','" & cmbYear.Text & "','" & cmbMonth.Text & "','2','8','" & sDGV.Item(1, X).Value & "')"
            '    End If
            'Next
            'FK_EQ(sSQL, "", False, False, True)
            'sSQL = "select regid,amount from tblsd where regid in (select regid from tblReqD where cyear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' and sProcess='Yes'  and status='0' and fullSalary='1') and salid='7' and type1='2'"
            'Fk_FillGrid(sSQL, sDGV)
            'sSQL = ""
            'For X = 0 To sDGV.RowCount - 1
            '    If sDGV.Item(0, X).Value <> "" Then
            '        sSQL = sSQL & " Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) values ('" & sDGV.Item(0, X).Value & "','" & cmbYear.Text & "','" & cmbMonth.Text & "','2','9','" & sDGV.Item(1, X).Value & "')"
            '        sSQL = sSQL & " update tblsd set Amount='0' where RegID='" & sDGV.Item(0, X).Value & "'  and cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "' and SalID='8' and Type1='2'"
            '    End If
            'Next
            'FK_EQ(sSQL, "", False, False, True)

            'End by Aruna
            sSQL = "update tblsd set saldes=tblsalaryitems.description from tblsalaryitems inner join tblsd on tblsalaryitems.id=tblsd.salid where  tblsd.type1='2' ; update tblsd set saldes=tblDayFields.Fld from tblDayFields inner join tblsd on tblDayFields.id=tblsd.salid where  tblsd.type1='1' ;"
            sSQL = sSQL & " update tblCompany set processategory='" & FK_GetIDL(cmbPrcat.Text) & "' where compID='" & StrCompID & "'"

            'Added for month end Process
            sSQL = sSQL & "UPDATE tblmonthend SET salP=1,permP=0 WHERE PrCatID='" & PrID & "' AND cYear=" & cmbYear.Text & " AND cMonth=" & cmbMonth.Text & " AND status=0"

            sSQL = sSQL & " INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus,regID) VALUES (GETDATE(),'FrmSalaryProcess','Do the Temparary Process for category :  " & cmbPrcat.Text & " and Year : " & cmbYear.Text & " and Month " & cmbMonth.Text & "','" & StrUserID & "',0,'' )"

            FK_EQ(sSQL, "S", "", False, False, True)
            PB.Value = PB.Maximum
            PB1.Value = PB1.Maximum
            '=======================Rajitha set the following msg from previous place
            'If 
            MessageBox.Show("Salary Process Completed Successfully.", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'LoadForm(New frmPayslipprocessk)
            'End If
            '=======================================
            Button1.Enabled = True
            ' Final()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
       
    End Sub

    Public Sub DeleteNetPayBankAcordingEmployee()
        'Aitken spence has requested to don't calculate net pa y salry for employees who pay money in cash
        Dim PrCID As String = FK_GetIDR(cmbPrcat.Text)
        sSQL = "delete from tblsd where salid=9 and type1=2 and cyear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' and regid in (select regid from tblPayrollEmployee where status=0 and finalsalary=0 and prcatid='" & PrCID & "')" : FK_EQ(sSQL, "D", "", False, False, True)
        sSQL = "delete from tblsd where salid=8 and type1=2 and cyear='" & cmbYear.Text & "' and cmonth='" & cmbMonth.Text & "' and regid in (select regid from tblPayrollEmployee where status=0 and finalsalary<>0 and prcatid='" & PrCID & "')" : FK_EQ(sSQL, "D", "", False, False, True)
    End Sub

    Public Sub RoundBudjetFivePercentCWE()
        'CWE has requested to round there budget special allowance to minimum as 750 and maximum as 2500---- salari ttem is 136
        Dim PrCID As String = FK_GetIDR(cmbPrcat.Text)
        sSQL = "Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) Select RegID,'" & cmbYear.Text & "','" & cmbMonth.Text & "','2','136',CASE WHEN (basicsalary*0.05)<750 THEN 750 WHEN (basicsalary*0.05)>2500 THEN 2500 ELSE basicsalary*0.05 END AS 'BLKA2013' from tblPayEmpMRecords   where PrcatID='" & PrCID & "' and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0'" : FK_EQ(sSQL, "S", "", False, False, True)
    End Sub

    Public Sub RounSalary()
        Load_InformationtoGrid("Select SalID,SalDes,Amount  from tblMoneyCat where status='0' order by Amount Desc", dgvCoins, 3)

        'SaveLine("CoinSummery", CmdSalField.Text)
        ''Dim sSQL = "create table tblCS1 (RegID varchar(10), Amount decimal(18,2) not null default 0, FinalAmount decimal(18,2) not null default 0, Coin decimal(18,0) not null default 0, Remain decimal(18,2) not null default 0   ); Create table tblCS2 (RegID varchar(10),CoinID varchar(10), Coins decimal(18,0) not null default 0)"
        'EQ(sSQL)
        sSQL = "Delete from  tblCS2; Delete from  tblCS1"
        FK_EQ(sSQL, "D", "", False, False, True)
        sSQL = "Insert into  tblCS1 (RegID) Select tblPayEmpMRecords.RegID from tblPayEmpMRecords,tblPayrollemployee  where tblPayEmpMRecords.regID=tblPayrollEmployee.RegID AND tblPayEmpMRecords.PrcatID='" & FK_GetIDR(cmbPrcat.Text) & "' and tblPayEmpMRecords.cYear='" & cmbYear.Text & "' and tblPayEmpMRecords.cMonth='" & cmbMonth.Text & "' AND tblPayrollEmployee.finalSalary=0" & _
        " update  tblCS1 set Amount=tblsd.Amount,Remain=tblsd.Amount from tblsd " & _
        " inner join tblCS1 on tblCS1.RegID=tblsd.RegID " & _
        " where tblsd.cYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and SalID=7 and Type1='2';" & _
        " Delete from tblCS1 where Amount='0'"
        FK_EQ(sSQL, "P", "", False, False, True)
        For X = 0 To dgvCoins.RowCount - 1
            sSQL = "Declare @CoinID varchar(10) Declare @CoinValue decimal(18,2)" & _
            " set @CoinID='" & dgvCoins.Item(0, X).Value & "' set @CoinValue='" & Val(dgvCoins.Item(2, X).Value) & "' " & _
            " update tblCS1 set FinalAmount=Remain " & _
            " update tblCS1 set  Coin=floor(FinalAmount/@CoinValue) " & _
            " update tblCS1 set Remain=(FinalAmount-(Coin*@CoinValue)) " & _
            " Insert into tblCS2 (RegID,CoinID,Coins) Select RegID, @CoinID,Coin from tblCS1 "
            FK_EQ(sSQL, "P", "", False, False, True)
        Next

        Try
            sSQL = "Delete From tblCoinCFT; delete from tblCS1 where remain=0"
            FK_EQ(sSQL, "D", "", False, False, True)

            sSQL = "Select tblCS1.RegID,tblsd.Amount,tblCS1.remain as coinCF,tblsd.Amount-tblCS1.remain as NewAmount  from tblsd INNER JOIN tblCS1 ON  tblCS1.regID=tblsd.RegID where tblsd.SalID=7 and tblsd.type1=2 and tblsd.amount >0 order by tblsd.regid asc"
            Fk_FillGrid(sSQL, dgvLast)
            PB.Value = 0
            PB.Maximum = dgvLast.RowCount
            Dim intk As Integer = 0

            sSQL = ""
            For i = 0 To dgvLast.RowCount - 1
                PB.Value = i
                intk = intk + 1
                sSQL = sSQL & "UPDATE tblsd SET Amount ='" & Val(dgvLast.Item(3, i).Value) & "' where  salid=7 and type1=2 and RegID='" & dgvLast.Item(0, i).Value.ToString & "';  "
                sSQL = sSQL & "UPDATE tblsd SET Amount ='" & Val(dgvLast.Item(3, i).Value) & "' where  salid=8 and type1=2 and RegID='" & dgvLast.Item(0, i).Value.ToString & "';  "
                sSQL = sSQL & "  Insert into tblCoinCFT values('" & dgvLast.Item(0, i).Value.ToString & "','" & dgvLast.Item(2, i).Value & "');"
                sSQL = sSQL & "insert into tblsd (regid,cyear,cmonth,type1,salid,amount)" & _
                "Values ('" & dgvLast.Item(0, i).Value.ToString() & "','" & cmbYear.Text & "','" & cmbMonth.Text & "','2','6','" & dgvLast.Item(2, i).Value & "')"
                If intk = 25 Then
                    FK_EQ(sSQL, "E", "", False, False, True) : sSQL = "" : intk = 0
                End If
            Next
            FK_EQ(sSQL, "E", "", False, False, True) : sSQL = ""

            PB.Value = PB.Maximum
            PB1.Value = PB1.Maximum
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    ' Loops for a specificied period of time (milliseconds)
    Private Sub Last()

        Dim LastCoin As Double = GetVal("Select Min(Amount) from tblMoneyCat")
        Dim sSQL = "Select RegID,Amount,'' as NewAmount,'' as Remain from tblsd where SalID=7 and type1=2 order by regid asc"
        Fk_FillGrid(sSQL, dgvLast)
        For i = 0 To dgvLast.RowCount - 1
            dgvLast.Item(3, i).Value = dgvLast.Item(1, i).Value Mod LastCoin
            dgvLast.Item(2, i).Value = dgvLast.Item(1, i).Value - dgvLast.Item(3, i).Value
        Next
        sSQL = "Delete From tblCoinCFT ; "
        PB.Value = 0
        PB.Maximum = dgvLast.RowCount
        For X = 0 To dgvLast.RowCount - 1
            PB.Value = X
            sSQL = sSQL & "Update tblsd set Amount='" & dgvLast.Item(2, X).Value & "' where  salid=7 and type1=2 and RegID='" & dgvLast.Item(0, X).Value.ToString & "'; "
            sSQL = sSQL & "  Insert into tblCoinCFT values('" & dgvLast.Item(0, X).Value.ToString & "','" & dgvLast.Item(3, X).Value & "');"
            sSQL = sSQL & "insert into tblsd (regid,cyear,cmonth,type1,salid,amount)" & _
            "Values ('" & dgvLast.Item(0, X).Value.ToString() & "','" & cmbYear.Text & "','" & cmbMonth.Text & "','2','6','" & dgvLast.Item(3, X).Value & "')"
            If X Mod 25 = 0 Then FK_EQ(sSQL, "P", "", False, False, True) : sSQL = ""
        Next
        FK_EQ(sSQL, "P", "", False, False, True) : sSQL = ""

        PB.Value = PB.Maximum
        PB1.Value = PB1.Maximum
        '==============Rajitha commented the follwing msg and added at last of process
        'MsgBox("Congratulations... Process Completed Successfully..", MsgBoxStyle.Information)

    End Sub

    Private Sub NewAttFormula()

        sSQL = " insert into tblsd (regid,cyear,cmonth,type1,salid,amount) select RegID," & Val(cmbYear.Text) & "," & Val(cmbMonth.Text) & ",'2',SalID,Amount from tblAttAllowances" ' where cYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "';"
        FK_EQ(sSQL, "S", "", False, False, True)
        PB.Value = PB.Maximum
        'For X = 0 To dgvAtten.RowCount - 1
        '    dgv1.Rows.Add(, cmbYear.Text, cmbMonth.Text, 0, 2, dgvAtten.Item(1, X).Value, dgvAtten.Item(6, X).Value, "")
        'Next
        Fk_FillGrid("Select * from  tblDayFields", dgvAt)
        sSQL = ""
        For X = 0 To dgvAt.RowCount - 1
            sSQL = sSQL & "insert into tblsd (regid,cyear,cmonth,type1,salid,amount)  Select RegID,cYear,Cmonth,'1','" & dgvAt.Item(0, X).Value.ToString & "'," & dgvAt.Item(1, X).Value.ToString & " from tblAttsum where cMonth='" & cmbMonth.Text & "' and cYear='" & cmbYear.Text & "'"
        Next
        FK_EQ(sSQL, "S", "", False, False, True)

    End Sub

    Private Sub FormulaFieldData()

        sSQL = "Select Cl,ID,Form from tblForOr order by Ord asc"
        Load_InformationtoGrid(sSQL, dgv, 3)

        For X = 0 To dgv.RowCount - 1
            If dgv.Item(0, X).Value = "Employee Formula" Then ForID = dgv.Item(1, X).Value : EmpFormula()
            If dgv.Item(0, X).Value = "Customized EPF Formula" Then ForID = dgv.Item(1, X).Value : epfFormula()
            If dgv.Item(0, X).Value = "PAYE TAX Formula" Then ForID = dgv.Item(1, X).Value : NewTax()
        Next
        Exit Sub

    End Sub

    Private Sub NewTax()
        Try
            sSQL = "Select Distinct TotSalID,DedSalID from tblNewtaxformula where Status='0'"
            Fk_FillGrid(sSQL, dgvTaxGrid1)
            sSQL = "Select RegID from tblPayrollEmployee where Status='0' AND RegID NOT IN (SELECT regID FROM tblstoplist)"
            Fk_FillGrid(sSQL, dgvTaxEmployee)
            ''sSQL = "Create table tblTempTax (TotSalID varchar(3), DedSalID varchar(3), RegID varchar(8),Amount Decimal(18,2) not null Default 0,DedSalAmount  Decimal(18,2) not null Default 0)"
            ''EQ(sSQL)
            sSQL = "Delete from tblTempTax;"
            For X = 0 To dgvTaxGrid1.RowCount - 1
                For I = 0 To dgvTaxEmployee.RowCount - 1
                    sSQL = sSQL & " Insert into tblTempTax (TotSalID,DedSalID,RegID) values ('" & dgvTaxGrid1.Item(0, X).Value & "','" & dgvTaxGrid1.Item(1, X).Value & "','" & dgvTaxEmployee.Item(0, I).Value & "'); "
                Next
            Next
            sSQL = sSQL & " Update tblTempTax set DedSalAmount=tblSD.Amount from tblSD inner join tblTempTax on tblSD.RegID=tblTempTax.RegID  where tblSD.SalID=tblTempTax.TotSalID and tblSD.type1='2'"
            FK_EQ(sSQL, "S", "", False, False, True)
            sSQL = "select Formula from tblNewtaxformula where Status='0';"
            Fk_FillGrid(sSQL, dgvTaxEmployee)
            sSQL = ""
            For I = 0 To dgvTaxEmployee.RowCount - 1
                sSQL = sSQL & dgvTaxEmployee.Item(0, I).Value
            Next
            sSQL = sSQL & " Delete  from tblTempTax Where Amount='0';"
            sSQL = sSQL & "Insert into tblSD (RegID,cYear,cMonth,type1,SalID,Amount) Select RegID,'" & cmbYear.Text & "','" & cmbMonth.Text & "','2',DedSalID,Amount from tblTempTax"
            FK_EQ(sSQL, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub epfFormula()

        sSQL = "CREATE  FUNCTION [dbo].[fk_getAmount]  (@RegID Nvarchar (10), @salID Numeric (18,0),@TypeID Nvarchar (2))  RETURNS Numeric (18,2)    AS    BEGIN    declare @Return Numeric (18,2) Begin SET @Return = (SELECT Amount FROM tblSD WHERE SalID = @SalID AND RegID = @RegID AND Type1 = @TypeID)END if @return is null    set @return = 0 return @return     end    "
        EQ(sSQL)
        Dim PrID As String = FK_GetIDR(cmbPrcat.Text) ' GetString("Select CatID from tblSetPrCategory where CatDesc = '" & cmbPrcat.Text & "'")

        sSQL = "insert into tblsd " & _
        " Select RegID," & Val(cmbYear.Text) & "," & cmbMonth.Text & ",'2',DedField,dbo.fk_getAmount(RegID,TotalField,'2')*Per/100,'','' from tblEpffor where RegID in (Select RegID from  tblPayEmpMRecords  where PrcatID='" & PrID & "'  and CYear='" & Val(cmbYear.Text) & "' and cMonth='" & Val(cmbMonth.Text) & "' and Status='0')"
        FK_EQ(sSQL, "S", "", False, False, True)

    End Sub

    Private Sub TaxFormula()

        sSQL = "Select RegiD,salid,Amount,'' as DedField,'' as DedAount from tblSd where salid=(Select distinct taxfield from tblPAYEFOR where status='0') and type1='2' order by regid asc"
        Fk_FillGrid(sSQL, dgvSD)
        sSQL = "Select * from tblPAYEFOR order by TaxField asc,Amt asc"
        Fk_FillGrid(sSQL, dgvSD1)
        Dim txtTestAmount As New TextBox
        Try
            For iY = 0 To dgvSD.RowCount - 1
                txtTestAmount.Text = dgvSD.Item(2, iY).Value
                dgvPaye.Rows.Clear() : txtFormula.Text = ""
                If Val(txtTestAmount.Text) <> 0 Then
                    For iX = 0 To dgvSD1.RowCount - 1
                        If dgvSD1.Item(3, iX).Value > Val(txtTestAmount.Text) Then
                            txtFormula.Text = dgvSD1.Item(4, iX).Value.ToString()
                            dgvSD.Item(3, iY).Value = dgvSD1.Item(2, iX).Value
                            Exit For
                        End If
                    Next

                    If txtFormula.Text <> "" Then
                        'sSQL = "Select top 1 ID,Amt,Formula  from tblpayeFor where Status=0 and Amt>'" & Val(txtTestAmount.Text) & "' order by Amt Asc, Id Asc"
                        'If FK_ReadDB(sSQL) = False Then Exit Sub
                        'txtFormula.Text = FK_Read("Formula")
                        'cmbID.Text = FK_Read("ID")
                        For X1 = 1 To Len(txtFormula.Text)
                            If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 5) = "Field" Then
                                For y = X1 To Len(txtFormula.Text)
                                    Dim verStart, VerStop As Integer
                                    If Mid((txtFormula.Text), y, 1) = "[" Then
                                        verStart = y + 1
                                    End If
                                    If Mid((txtFormula.Text), y, 1) = "]" Then
                                        VerStop = y - verStart
                                        dgvPaye.Rows.Add((Mid(txtFormula.Text, verStart, VerStop)), "", 2)
                                        Exit For
                                    End If
                                Next
                            End If

                            If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "+" Then
                                dgvPaye.Rows.Add("+", "")
                            End If
                            If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "-" Then
                                dgvPaye.Rows.Add("-", "")
                            End If
                            If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "x" Then
                                dgvPaye.Rows.Add("*", "")
                            End If
                            If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 1) = "/" Then
                                dgvPaye.Rows.Add("/", "")
                            End If
                            If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 8) = "External" Then
                                For y = X1 To Len(txtFormula.Text)
                                    Dim verStart, VerStop As Integer
                                    If Mid((txtFormula.Text), y, 1) = "[" Then
                                        verStart = y + 1
                                    End If
                                    If Mid((txtFormula.Text), y, 1) = "]" Then
                                        VerStop = y - verStart
                                        dgvPaye.Rows.Add((Mid(txtFormula.Text, verStart, VerStop)), "")
                                        Exit For
                                    End If
                                Next
                            End If
                            'If Mid((txtFormula.Text), X1, 1) = "," And Mid(txtFormula.Text, X1 + 1, 3) = "DAY" Then
                            '    For y = X1 To Len(txtFormula.Text)

                            '        Dim verStart, VerStop As Integer
                            '        If Mid((txtFormula.Text), y, 1) = "[" Then
                            '            verStart = y + 1
                            '        End If
                            '        If Mid((txtFormula.Text), y, 1) = "]" Then
                            '            VerStop = y - verStart
                            '            dgvPaye.Rows.Add((Mid(txtFormula.Text, verStart, VerStop)), "", 1)
                            '            Exit For
                            '        End If
                            '    Next
                            'End If
                        Next
                        For X = 0 To dgvPaye.RowCount - 1
                            dgvPaye.Item(1, X).Value = dgvPaye.Item(0, X).Value
                        Next
                        If dgvPaye.RowCount - 1 = 0 Then
                            dgvSD.Item(4, iY).Value = dgvPaye.Item(1, 0).Value : Exit Sub
                        Else

                            For X = 0 To dgvPaye.RowCount - 1
                                If dgvPaye.Item(2, X).Value = "2" Then dgvPaye.Item(1, X).Value = Val(txtTestAmount.Text)
                            Next

                            Dim verTotal As Double = 0
                            Dim verTotal1 As Double = 0
                            verTotal = Val(dgvPaye.Rows(0).Cells(1).Value)
                            'MsgBox(verTotal)
                            For i = 0 To dgvPaye.RowCount - 3
                                If Trim(dgvPaye.Rows(i + 1).Cells(1).Value) = "+" Then
                                    verTotal = verTotal + Val(dgvPaye.Rows(i + 2).Cells(1).Value)
                                End If
                                If Trim(dgvPaye.Rows(i + 1).Cells(1).Value) = "-" Then
                                    verTotal = verTotal - Val(dgvPaye.Rows(i + 2).Cells(1).Value)
                                End If
                                If Trim(dgvPaye.Rows(i + 1).Cells(1).Value) = "*" Then
                                    verTotal = verTotal * Val(dgvPaye.Rows(i + 2).Cells(1).Value)
                                End If
                                If Trim(dgvPaye.Rows(i + 1).Cells(1).Value) = "/" Then
                                    verTotal = verTotal / Val(dgvPaye.Rows(i + 2).Cells(1).Value)
                                End If
                            Next
                            MsgBox(verTotal)
                            verTotal = RoundUp(verTotal)

                            dgvSD.Item(4, iY).Value = verTotal
                        End If
                    End If
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub EmpFormula()

        Try
            '=added rajitha. following line to get only employees relevant to process category               'where empid in (Select RegID from tblPayrollEmployee where PrcatID='" & PrID & "')
            Dim PrID As String
            PrID = FK_GetIDR(cmbPrcat.Text) ' GetString("Select CatID from tblSetPrCategory where CatDesc = '" & cmbPrcat.Text & "'")
            '=====================
            'If ForID = "1" Then
            '    MsgBox("In")
            'End If
            sSQL = "Select  tblEmployeeformulaField.EmpID,tblFormula.SalaryField,tblFormula.Formula,'' from tblFormula " & _
            " inner join tblEmployeeformulaField on tblEmployeeformulaField.ID=tblFormula.ID where tblFormula.Status='0' and tblformula.id='" & ForID & "' and empid in (Select RegID from tblPayrollEmployee where PrcatID='" & PrID & "' and status=0) order by empid asc"
            Load_InformationtoGrid(sSQL, DgvNewForm, 4)

            PB.Value = 0
            PB.Maximum = DgvNewForm.RowCount

            If DgvNewForm.RowCount = 0 Then Exit Sub
            txtFormula.Text = DgvNewForm.Item(2, 0).Value

            'If txtFormula.Text.Contains("2-39") Then
            '    MsgBox("In")
            'End If
            'MsgBox(txtFormula.Text)
            Dim Fields As String()
            Fields = txtFormula.Text.Split(",")
            dgvFormula.Rows.Clear()
            For i = 0 To Fields.Length - 1
                If Len(Trim(Fields(i))) > 0 Then dgvFormula.Rows.Add(Fields(i), "", "", "")
            Next
            For X = 0 To dgvFormula.RowCount - 1
                If Len(dgvFormula.Item(0, X).Value.ToString()) > 8 And Microsoft.VisualBasic.Left(dgvFormula.Item(0, X).Value.ToString(), 8) = "Field[2-" Then
                    dgvFormula.Item(1, X).Value = "2"
                    dgvFormula.Item(0, X).Value = Replace(dgvFormula.Item(0, X).Value.ToString, "Field[2-", "")
                    dgvFormula.Item(0, X).Value = Replace(dgvFormula.Item(0, X).Value.ToString, "]", "")
                ElseIf Len(dgvFormula.Item(0, X).Value.ToString()) > 6 And Microsoft.VisualBasic.Left(dgvFormula.Item(0, X).Value.ToString(), 6) = "DAY[1-" Then
                    dgvFormula.Item(1, X).Value = "1"
                    dgvFormula.Item(0, X).Value = Replace(dgvFormula.Item(0, X).Value.ToString, "DAY[1-", "")
                    dgvFormula.Item(0, X).Value = Replace(dgvFormula.Item(0, X).Value.ToString, "]", "")
                ElseIf Len(dgvFormula.Item(0, X).Value.ToString()) > 9 And Microsoft.VisualBasic.Left(dgvFormula.Item(0, X).Value.ToString(), 9) = "External[" Then
                    dgvFormula.Item(1, X).Value = "3"
                    dgvFormula.Item(0, X).Value = Replace(dgvFormula.Item(0, X).Value.ToString, "External[", "")
                    dgvFormula.Item(0, X).Value = Replace(dgvFormula.Item(0, X).Value.ToString, "]", "")
                End If
            Next

            For iX = 0 To DgvNewForm.RowCount - 1

                PB.Value = iX

                Dim sRegID As String = DgvNewForm.Item(0, iX).Value

                sSQL = ""
                For X = 0 To dgvFormula.RowCount - 1
                    Dim salID As String = ""
                    If dgvFormula.Item(1, X).Value.ToString() = "2" Then
                        salID = FK_GetID1(dgvFormula.Item(0, X).Value.ToString())
                        'If salID = "33" Then
                        '    ' MsgBox("In")
                        'End If
                        dgvFormula.Item(2, X).Value = salID
                    End If
                    If salID <> "" Then
                        If sSQL = "" Then
                            sSQL = "Select * from tblsd where salid='" & salID & "' and  type1='2' and regID='" & sRegID & "'" : salID = ""
                        Else
                            sSQL = sSQL & " or salid='" & salID & "' and  type1='2' and  regID='" & sRegID & "'" : salID = ""
                        End If
                    End If
                Next
                If sSQL <> "" Then
                    sSQL = sSQL & "  Order by RegID Asc"

                    'MsgBox(sSQL)
                    Fk_FillGrid(sSQL, dgvSD)
                End If

                sSQL = ""
                For X = 0 To dgvFormula.RowCount - 1
                    Dim salID As String = ""
                    If dgvFormula.Item(1, X).Value.ToString() = "1" Then
                        salID = FK_GetID1(dgvFormula.Item(0, X).Value.ToString())
                        dgvFormula.Item(2, X).Value = salID
                    End If
                    If salID <> "" Then
                        If sSQL = "" Then
                            sSQL = "Select * from tblsd where salid='" & salID & "' and  type1='1' and regID='" & sRegID & "'" : salID = ""
                        Else
                            sSQL = sSQL & " or salid='" & salID & "' and  type1='1' and  regID='" & sRegID & "'" : salID = ""
                        End If
                    End If
                Next
                If sSQL <> "" Then
                    sSQL = sSQL & "  Order by RegID Asc"
                    'MsgBox(sSQL)
                    Fk_FillGrid(sSQL, dgvSD1)
                End If

                'For X = 0 To dgvFormula.RowCount - 1
                '    If dgvFormula.Item(0, X).Value = " " Or dgvFormula.Item(0, X).Value = Nothing Then
                '        dgvFormula.Rows.Remove(dgvFormula.Rows(X))
                '    End If
                'Next
                For X = 0 To dgvFormula.RowCount - 1
                    'MsgBox(dgvFormula.Item(1, X).Value.ToString())
                    If dgvFormula.Item(1, X).Value.ToString() = "2" Then
                        If dgvSD.RowCount = 0 Then dgvFormula.Rows(X).Cells(3).Value = 0
                        For D = 0 To dgvSD.RowCount - 1
                            'MsgBox(sRegID)
                            dgvFormula.Rows(X).Cells(3).Value = ""
                            'MsgBox(dgvFormula.Item(2, X).Value.ToString())
                            If sRegID = dgvSD.Item(0, D).Value.ToString() And dgvFormula.Item(2, X).Value.ToString() = dgvSD.Item(4, D).Value.ToString() Then
                                dgvFormula.Rows(X).Cells(3).Value = dgvSD.Item(5, D).Value
                                'MsgBox("Vlue" & dgvFormula.Rows(X).Cells(3).Value)
                                dgvSD.Rows.RemoveAt(D)
                                Exit For
                            End If
                        Next
                    ElseIf dgvFormula.Item(1, X).Value.ToString() = "1" Then
                        If dgvSD1.RowCount = 0 Then dgvFormula.Rows(X).Cells(3).Value = 0
                        For D = 0 To dgvSD1.RowCount - 1
                            dgvFormula.Rows(X).Cells(3).Value = ""
                            If sRegID = dgvSD1.Item(0, D).Value.ToString() And dgvFormula.Item(2, X).Value.ToString() = dgvSD1.Item(4, D).Value.ToString() Then
                                dgvFormula.Rows(X).Cells(3).Value = dgvSD1.Item(5, D).Value
                                dgvSD1.Rows.RemoveAt(D)
                                Exit For
                            End If
                        Next
                    Else ': dgvFormula.Item(1, X).Value.ToString() = ""
                        'MsgBox("New" & dgvFormula.Rows(X).Cells(0).Value)
                        dgvFormula.Rows(X).Cells(3).Value = dgvFormula.Rows(X).Cells(0).Value
                    End If
                Next

                Dim verTotal As Double = 0
                Dim verTotal1 As Double = 0
                verTotal = Val(dgvFormula.Rows(0).Cells(3).Value)
                For I = 0 To dgvFormula.RowCount - 3
                    If Trim(dgvFormula.Rows(I + 1).Cells(3).Value) = "+" Then
                        'MsgBox(Val(dgvFormula.Rows(I + 2).Cells(3).Value))
                        verTotal = verTotal + Val(dgvFormula.Rows(I + 2).Cells(3).Value)
                    End If
                    If Trim(dgvFormula.Rows(I + 1).Cells(3).Value) = "-" Then
                        verTotal = verTotal - Val(dgvFormula.Rows(I + 2).Cells(3).Value)
                    End If
                    If Trim(dgvFormula.Rows(I + 1).Cells(3).Value) = "X" Then
                        verTotal = verTotal * Val(dgvFormula.Rows(I + 2).Cells(3).Value)
                    End If
                    If Trim(dgvFormula.Rows(I + 1).Cells(3).Value) = "/" Then
                        If Val(dgvFormula.Rows(I + 2).Cells(3).Value) > 0 Then
                            verTotal = verTotal / Val(dgvFormula.Rows(I + 2).Cells(3).Value)
                        Else
                            verTotal = 0
                            MsgBox("Divide by Zero error found in the Formula : " & vbNewLine & txtFormula.Text & "Register ID : " & sRegID, MsgBoxStyle.Information)
                            Exit Sub
                        End If
                    End If
                Next
                'MsgBox(verTotal)
                DgvNewForm.Item(3, iX).Value = verTotal
                'MsgBox(DgvNewForm.Item(3, iX).Value)
            Next
            sSQL = ""
            PB.Value = 0
            PB.Maximum = DgvNewForm.RowCount
            If DgvNewForm.RowCount = 0 Then Exit Sub
            For n1 As Integer = 0 To DgvNewForm.RowCount - 1
                PB.Value = n1
                sSQL = sSQL & "Insert into tblsd (regid,cYear,cMonth,Type1,SalID,Amount) values ('" & DgvNewForm.Item(0, n1).Value.ToString() & "','" & cmbYear.Text & "','" & cmbMonth.Text & "','2','" & DgvNewForm.Item(1, n1).Value.ToString() & "','" & Val(DgvNewForm.Item(3, n1).Value) & "')"
                'If DgvNewForm.Item(1, n1).Value.ToString() = "45" Then MessageBox.Show("kASUN", "Test", MessageBoxButtons.OK)
                If n1 Mod 25 = 0 Then
                    FK_EQ(sSQL, "S", "", False, False, True) : sSQL = ""
                End If

            Next
            FK_EQ(sSQL, "S", "", False, False, False)
            PB.Value = PB.Maximum
        Catch ex As Exception
            MsgBox(ex.Message & sSQL & vbNewLine & txtFormula.Text)
        End Try

    End Sub

    Public Function FK_GetID1(ByVal sString As String)

        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                For X = 1 To Len(sString)
                    If Mid(sString, X, 1) = "." Then
                        sRetString = Microsoft.VisualBasic.Left(sString, X - 1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString

    End Function

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        FormulaFieldData()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Me.Close()

    End Sub

    Private Sub cmbPrcat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrcat.SelectedIndexChanged
        getPrCatSum
    End Sub

    Private Sub getPrCatSum()
        If cmbPrcat.Text = "" Then Exit Sub
        If cmbYear.Text = "" Then Exit Sub
        If cmbMonth.Text = "" Then Exit Sub
        lblCoun.Text = "Total Employees : " & fk_sqlDbl("select count(*) from tblpayEmpMrecords where prCatID='" & FK_GetIDR(cmbPrcat.Text) & "' and cYear='" & cmbYear.Text & "' and cMonth='" & cmbMonth.Text & "' and status=0  AND tblPayEmpMRecords.DeptID In ('" & StrUserLvDept & "') AND tblPayEmpMRecords.BrID In ('" & StrUserLvBranch & "')")
        If lblCoun.Text = "Total Employees : 0" Then
            lblCoun.Text = "Total Employees : " & fk_sqlDbl("select count(*) from tblpayrollemployee where prCatID='" & FK_GetIDR(cmbPrcat.Text) & "' and status=0 AND tblpayrollemployee.DeptID In ('" & StrUserLvDept & "') AND tblpayrollemployee.BrID In ('" & StrUserLvBranch & "')")
        End If
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbYear.SelectedIndexChanged
        getPrCatSum()
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        getPrCatSum()
    End Sub

End Class