Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmPayrollData

    Dim StrSvStatus As String = "S"
    Dim bolExE As Boolean = True

    Private Sub frmCardDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If StrUserID = "Eye" Then
            alterTable()
        End If
        ControlHandlers(Me)
        'CenterFormThemed(Me, Panel1, Label25)
        Button2_Click(sender, e)
        tabOther.TabPages.Remove(tbpContact)
        tabOther.TabPages.Remove(tbpQualification)
        pnlEdit.Height = 0
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
    End Sub

    Public Sub alterTable()
        sSQL = "Alter table tblPayrollEmployee add sub_CatID nvarchar(3)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "Alter table tblPayrollEmployee add BankID nvarchar(3)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "Alter table tblPayrollEmployee add BranchID nvarchar(3)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "Alter table tblPayrollEmployee add ReligionID nvarchar(3)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add birthDate datetime null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add joiningDate datetime null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add BondPeriod datetime null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add ProbationDate datetime null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add points numeric(18,0) null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add genderID nvarchar(3)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee alter column maritalID nvarchar(3)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add otherIDs nvarchar(100)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter Table tblpayrollemployee add accNumber nvarchar(20) null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter Table tblpayrollemployee add Contact nvarchar(1000) null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter Table tblpayrollemployee add Qualification nvarchar(1000) null"
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "Alter table tblControl Add SubCatID decimal(18,0) not null default 0"
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "Alter table tblPayrollEmployee add FinalSalary decimal(18,0) not null default 0"
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "alter table [tblPayrollEmployee] alter column BankId nvarchar(5)"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add incrementDate datetime null"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "alter table tblPayrollEmployee add incrementMonth nvarchar (2) not null default '01'"
        FK_EQ(sSQL, "P", "", False, False, False)

        sSQL = "CREATE TABLE [dbo].[tblSetPCentre]([pID] [nvarchar](2) NULL,[pDesc] [nvarchar](50) NULL,[Status] [numeric](18, 0) NULL) "
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "CREATE TABLE [dbo].[tblSetPrCategory]([CatID] [nvarchar](3) NULL,[CatDesc] [nvarchar](50) NULL,[CompID] [nvarchar](3) NULL,[Status] [numeric](18, 0) NOT NULL DEFAULT 0) "
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "CREATE TABLE [dbo].[tblUL]([ID] [varchar](3) NULL,[LevelName] [varchar](100) NULL,[Description] [varchar](100) NULL,[LogTime] [datetime] NULL,[LogoutTime] [datetime] NULL,[FullAccess] [decimal](1, 0) NULL,[LevelValue] [decimal](18, 0) NOT NULL DEFAULT ((0)),[Status] [decimal](1, 0) NOT NULL DEFAULT 0) "
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "CREATE TABLE [dbo].[tblSetCCentre]([CntID] [nvarchar](2) NULL,[cntDesc] [nvarchar](50) NULL,[Status] [numeric](18, 0) NULL)"
        FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "CREATE TABLE [dbo].[tblSetReligion]([ReligID] [nvarchar](3) NULL,[ReligDesc] [nvarchar](30) NULL,[compID] [nvarchar](3) NULL,[Status] [numeric](18, 0) NULL)"
        FK_EQ(sSQL, "P", "", False, False, False)
    End Sub

    Public Sub RefreshEmployee(ByVal sRegID As String)
        If sRegID = "" Then Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum,  dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo, tblPayrollEmployee.incrementDate , tblPayrollEmployee.passportNo ,  tblPayrollEmployee.passportExp,  dbo.tblSetnationality.NatDesc+'='+tblSetnationality.NatID as 'Nationality',  dbo.tblSetCurrency.curDesc+'='+tblSetCurrency.curID as 'Currency',               dbo.tblCompany.cName+'='+tblCompany.CompID as 'cName', dbo.tblDesig.desgDesc+'='+tblDesig.DesgID as 'desgDesc', dbo.tblSetDept.DeptName+'='+tblSetDept.DeptID as 'DeptName', dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,dbo.tblPayrollEmployee.accNumber,dbo.tblPayrollEmployee.Contact, dbo.tblPayrollEmployee.Qualification,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc+'='+pid as 'pDesc', dbo.tblSetCCentre.cntDesc+'='+cntID as 'cntDesc', dbo.tblUL.LevelName+'='+tblUL.ID as 'LevelName', dbo.tblCBranchs.BrName+'='+tblCBranchs.BrID as 'BrName',tblSetPrCategory.CatDesc+'='+tblSetPrCategory.CatID as 'CatDesc',tblSetEmpCategory.CatDesc+'='+tblSetEmpCategory.catid as 'Sub_category' ,dbo.tblPayrollEmployee.birthDate, dbo.tblPayrollEmployee.joiningDate, dbo.tblPayrollEmployee.incrementMonth,dbo.tblPayrollEmployee.ProbationDate, dbo.tblPayrollEmployee.bondPeriod, dbo.tblPayrollEmployee.points,dbo.tblSetEmpCategory.catDesc+'='+tblSetEmpCategory.CatID as 'catDesc',dbo.tblBanks.BankName+'='+tblBanks.BankID as 'BankName',dbo.tblBranches.BranchName+'='+tblBranches.BrID as 'BranchName',dbo.tblPayrollEmployee.otherIDs,dbo.tblPayrollEmployee.genderID,dbo.tblPayrollEmployee.maritalID,dbo.tblsetreligion.ReligDesc+'='+tblsetreligion.ReligId as 'ReligDesc',FinalSalary,Contact,Qualification  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblPayrollEmployee.sub_catID = dbo.tblSetEmpCategory.catID       LEFT OUTER JOIN dbo.tblBanks ON dbo.tblPayrollEmployee.BankID = dbo.tblBanks.BankID     LEFT OUTER JOIN dbo.tblBranches ON dbo.tblPayrollEmployee.branchID = dbo.tblBranches.brID      LEFT OUTER JOIN dbo.tblsetreligion ON dbo.tblPayrollEmployee.religionID = dbo.tblsetreligion.religID LEFT OUTER JOIN dbo.tblSetCurrency ON dbo.tblPayrollEmployee.currencyID = dbo.tblSetCurrency.curID LEFT OUTER JOIN dbo.tblSetnationality ON dbo.tblPayrollEmployee.nationalityID = dbo.tblSetnationality.NatID WHERE     (dbo.tblPayrollEmployee.RegID = '" & sRegID & "') "
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    sRegID = txtRegID.Text
                    StrSvStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("regid")), "", RD.Item("regid"))
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtETFNo.Text = IIf(IsDBNull(RD.Item("ETPNo")), "", RD.Item("ETPNo"))
                    txtPoints.Text = IIf(IsDBNull(RD.Item("points")), "", RD.Item("points"))
                    txtContactInf.Text = IIf(IsDBNull(RD.Item("Contact")), "", RD.Item("Contact"))
                    txtQualification.Text = IIf(IsDBNull(RD.Item("Qualification")), "", RD.Item("Qualification"))
                    txtBasicSalary.Text = IIf(IsDBNull(RD.Item("BasicSalary")), "", RD.Item("BasicSalary"))
                    txtDaysPay.Text = IIf(IsDBNull(RD.Item("DaysPay")), "", RD.Item("DaysPay"))
                    txtAccNumber.Text = IIf(IsDBNull(RD.Item("accNumber")), "", RD.Item("accNumber"))
                    txtOtherID.Text = IIf(IsDBNull(RD.Item("otherIDs")), "", RD.Item("otherIDs"))
                    dtpBOndPeriod.Value = IIf(IsDBNull(RD.Item("bondPeriod")), "1900/01/01", RD.Item("bondPeriod"))
                    dtpProbation.Value = IIf(IsDBNull(RD.Item("ProbationDate")), "1900/01/01", RD.Item("ProbationDate"))
                    dtpIncrementdat.Value = IIf(IsDBNull(RD.Item("incrementDate")), "1900/01/01", RD.Item("incrementDate"))

                    Dim str As String = IIf(IsDBNull(RD.Item("EPFAllowed")), "", RD.Item("EPFAllowed"))
                    cmbPayCenter.Text = IIf(IsDBNull(RD.Item("pDesc")), "", RD.Item("pDesc"))
                    cmbCostCenter.Text = IIf(IsDBNull(RD.Item("cntDesc")), "", RD.Item("cntDesc"))
                    cmbSalaryViewLevel.Text = IIf(IsDBNull(RD.Item("LevelName")), "", RD.Item("LevelName"))
                    cmbPrCatagory.Text = IIf(IsDBNull(RD.Item("CatDesc")), "", RD.Item("CatDesc"))
                    cmbSubCategory.Text = IIf(IsDBNull(RD.Item("catDesc")), "", RD.Item("catDesc"))
                    cmbBankNa.Text = IIf(IsDBNull(RD.Item("bankName")), "", RD.Item("bankName"))
                    cmbBranchBank.Text = IIf(IsDBNull(RD.Item("brName")), "", RD.Item("brName"))
                    cmbReligion.Text = IIf(IsDBNull(RD.Item("religDesc")), "", RD.Item("religDesc"))

                    cmbCurrency.Text = IIf(IsDBNull(RD.Item("currency")), "", RD.Item("currency"))
                    cmbNationality.Text = IIf(IsDBNull(RD.Item("Nationality")), "", RD.Item("Nationality"))
                    txtPassport.Text = IIf(IsDBNull(RD.Item("passportNo")), "", RD.Item("passportNo"))
                    dtpPassExp.Value = IIf(IsDBNull(RD.Item("passportExp")), "1900/01/01", RD.Item("passportExp"))

                    Dim sSC As String = IIf(IsDBNull(RD.Item("Sub_category")), "", RD.Item("Sub_category"))
                    sSQL = "select (BranchName+'='+BrID) from tblBranches where BankID='" & FK_GetIDR(cmbBankNa.Text) & "' and BrID=(select BranchID from tblPayrollemployee where RegID='" & txtRegID.Text & "')"
                    cmbBranchBank.Text = fk_RetString(sSQL)
                    Dim abc As String
                    If sSC <> Nothing Or sSC <> "" Then
                        abc = fk_RetString("select CatDesc from tblemp_subcategory where CatID='" & sSC & "'")
                        cmbSubCategory.Text = abc & "=" & sSC
                    End If

                    Dim strGenderID As String = IIf(IsDBNull(RD.Item("genderID")), "", RD.Item("genderID"))


                    Dim strIncrement As String = IIf(IsDBNull(RD.Item("incrementMonth")), "", RD.Item("incrementMonth"))
                    If strIncrement = "01" Then
                        cmbIncrementIN.SelectedIndex = 0
                    Else
                        cmbIncrementIN.SelectedIndex = 1
                    End If

                End While

            Else
                ''MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Information) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub
                txtRegID.Text = sRegID
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Private Sub txtEPFNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPFNo.TextChanged
        txtETFNo.Text = txtEPFNo.Text
    End Sub

    ''Private Sub txtEmpIDNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpIDNum.KeyDown
    ''    If Len(Trim(txtEmpIDNum.Text)) > 5 Then
    ''        IDNum_Results(txtEmpIDNum.Text)
    ''        dtpDofB.Value = dtNICDoB
    ''        cmbGender.Text = StrNICSex

    ''    End If
    ''    If e.KeyCode = Keys.Enter Then

    ''    End If
    ''End Sub

    Private Sub txtETFNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtETFNo.Leave
        ' If fk_CheckEx("Select ETPNo from tblPayrollEmployee where ETPNo='" & txtETFNo.Text & "'") = True Then MsgBox("ETF No Already Exists", MsgBoxStyle.Information) : txtETFNo.Focus() : txtETFNo.SelectAll() : Exit Sub

    End Sub

    Private Sub cmbSalaryViewLevel_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSalaryViewLevel.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub cmbPrCatagory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPrCatagory.SelectedIndexChanged

        ' FK_GetIDR(cmbPrCatagory.Text) = GetString("Select CatID from tblSetPrCategory where CatDesc = '" & cmbPrCatagory.Text & "'")

    End Sub

    Private Sub txtDisplayName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtETFNo.KeyPress, txtEPFNo.KeyPress, txtDaysPay.KeyPress, txtBasicSalary.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtBasicSalary_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBasicSalary.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Or ((e.KeyChar) = ".") Then
            e.Handled = False
        End If
        If txtBasicSalary.Text.Contains(".") And e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDaysPay_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDaysPay.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Or ((e.KeyChar) = ".") Then
            e.Handled = False
        End If
        If txtDaysPay.Text.Contains(".") And e.KeyChar = "." Then
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub chkEPF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        cmbPrCatagory.Focus()
    End Sub

    Private Sub cmbPrCatagory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPrCatagory.KeyPress, cmbPayCenter.KeyPress, cmbCostCenter.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetProcesCategory)
        FillComboPay(cmbPrCatagory, "select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0")
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        strEditSetings = "PayCenter"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        'LoadForm(New frmSetPayCentre)
        'FillComboPay(cmbPayCenter, "select pDesc+'='+pid from tblsetpcentre where status=0")
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        strEditSetings = "CostCenter"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        strEditSetings = "ViewLevel"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        strEditSetings = "SubCategory"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        strEditSetings = "BankName"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        strEditSetings = "BankBranch"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetReligion)
        FillComboPay(cmbReligion, "  Select ReligDesc+'='+ReligID from tblSetReligion where status=0 order by ReligDesc ")

    End Sub

    Private Sub txtPoints_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        proc_OnlyNumeric1(e)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        strEditSetings = "ProcessCategory"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        'LoadForm(New frmSetProcesCategory)
        'FillComboPay(cmbPrCatagory, "select catDesc+'='+catid from tblSetPrCategory where status=0")
    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If

        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0", cmbPrCatagory.Text, "ProCat", s, "PrCatID", True, "Edit Process Category")
        RefreshEmployee(txtRegID.Text)

        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()

    End Sub

    Private Sub PictureBox25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("select pDesc+'='+pid from tblsetpcentre where status=0", cmbPayCenter.Text, "PayCen", s, "PayID", True, "Edit Pay Center")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox30.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("Select cntDesc+'='+cntID from tblsetcCentre where status=0", cmbCostCenter.Text, "CostCen", s, "CostID", True, "Edit Cost Center")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox29.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee(" Select LevelName+'='+ID from tblUL where status=0 order by LevelName asc", cmbSalaryViewLevel.Text, "ViewLevel", s, "SalViewLevel", True, "Edit Salary View Level")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox28.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("Select CatDesc+'='+catid from tblSetEmpCategory where status=0", cmbSubCategory.Text, "SubCat", s, "Sub_CatID", True, "Edit Sub Category")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox27.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("  Select BankName+'='+BankID from tblBanks where status=0", cmbBankNa.Text, "Bank", s, "BankID", True, "Edit Banks")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("Select BranchName+'='+BrID from tblBranches where status='0' and BankID='" & FK_GetIDR(cmbBankNa.Text) & "'", cmbBranchBank.Text, "BankBran", s, "BranchID", True, "Edit Branch")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("", txtBasicSalary.Text, "BasSal", s, "BasicSalary", False, "Edit Basic Salary")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If
        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("", txtDaysPay.Text, "DaysPay", s, "DaysPay", False, "Edit Days Pay")
        RefreshEmployee(txtRegID.Text)
        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Trim(txtRegID.Text) = "" Then MsgBox("Invalid Reg ID", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub
        Dim FinalSalary As Integer = 0 ' Salary Cash
        If rdbBank.Checked Then FinalSalary = 1 ' Salary Bank
        If rdbCheque.Checked Then FinalSalary = 2 ' Salary Cheque

        Dim ETFN As String = txtEPFNo.Text
        Dim ifEx As Boolean = False
        sSQL = "Select regid from tblPayrollEmployee where RegID='" & txtRegID.Text & "'"
        ifEx = fk_CheckEx(sSQL)
        If ifEx = True Then
            Dim sSQl As String
            sSQl = "    Update [tblPayrollEmployee]  " & _
                    "   Set [ETPNo] =    '" & ETFN & "'   " & _
                    "   ,[EpfAllowed] = '0'" & _
                    " , Status='" & CHkRemove.CheckState & "' " & _
                    ",ReligionID =   '" & IIf(FK_GetIDR(cmbReligion.Text) = "", "-", FK_GetIDR(cmbReligion.Text)) & "'  " & _
                    ",BondPeriod  = '" & Format(dtpBOndPeriod.Value, "yyyyMMdd") & "' " & _
                    ",ProbationDate  = '" & Format(dtpProbation.Value, "yyyyMMdd") & "' " & _
                    ",points =   '" & IIf(txtPoints.Text = "", 0, Val(txtPoints.Text)) & "'  " & _
                    ",otherIDs =   '" & IIf(txtOtherID.Text = "", "-", txtOtherID.Text) & "'  " & _
                    ",Contact='" & IIf(txtContactInf.Text = "", "-", UCase(txtContactInf.Text)) & "',Qualification='" & IIf(txtQualification.Text = "", "-", UCase(txtQualification.Text)) & "' " & _
                    ",accNumber =   '" & IIf(txtAccNumber.Text = "", "-", txtAccNumber.Text) & "',FinalSalary=" & FinalSalary & ",incrementDate='" & Format(dtpIncrementdat.Value, "yyyyMMdd") & "' " & _
                    " ,incrementMonth='" & FK_GetIDR(cmbIncrementIN.Text) & "',passportNo =   '" & IIf(txtPassport.Text = "", "-", txtPassport.Text) & "',passportExp='" & Format(dtpPassExp.Value, "yyyyMMdd") & "'  " & _
                    "   WHERE [RegID] = '" & txtRegID.Text & "'; "

            ''If UP("Employee Register", "Edit Employees") = False Then Exit Sub
            If FK_EQ(sSQl, "E", "", True, True, True) = True Then Call Button2_Click(sender, e)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FK_Clear(Me)
        FillComboPay(cmbPrCatagory, "select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0 order by CatDesc Asc ")
        ''FillComboPay(cmbCompany, "Select CName+'='+CompID from tblCompany where status =0 order by cname Asc")
        ''FillComboPay(cmbDesignation, "Select desgdesc+'='+DesgID from tblDesig where status='0' order by desgdesc Asc ")
        ''FillComboPay(cmbbranch, "Select BrName+'='+BrID from tblCBranchs where compID='" & FK_GetIDR(cmbCompany.Text) & "' and status='0'  order by BrName asc")
        ''FillComboPay(cmbDepartment, "select DeptName+'='+DeptID from tblsetDept where Status='0' order by DeptName asc")
        FillComboPay(cmbPayCenter, "select pDesc+'='+pid from tblsetpcentre where status=0 order by pDesc asc")
        FillComboPay(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc Asc")
        FillComboPay(cmbSalaryViewLevel, " Select LevelName+'='+ID from tblUL where status=0 order by LevelName asc")
        FillComboPay(cmbCostCenter, "Select cntDesc+'='+cntID from tblsetcCentre where status=0 order by cntDesc asc")
        FillComboPay(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0 order by BankName asc")
        FillComboPay(cmbReligion, "  Select ReligDesc+'='+ReligID from tblSetReligion where status=0 order by ReligDesc ")
        'FillComboPay(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0")
        FillComboPay(cmbCurrency, "  Select curDesc+'='+curID from tblSetCurrency where status=0 order by curDesc ")
        FillComboPay(cmbNationality, "  Select NatDesc+'='+NatID from tblSetnationality where status=0 order by NatDesc ")
        cmbBranchBank.Text = ""

        tabOther.SelectedTab = tbpImportant
        'sSQL = "Select CatDesc+'='+CatID  from tblemp_subcategory"
        'FillComboPay(cmbSubCategory, sSQL)
        StrSvStatus = "S"
        ''''txtRegID.Text = Format(GetVal("Select max(convert(int,regId))+1  as 'ABC' from  TBLPAYROLLEMPLOYEE"), "000#")
        ''SEmpID = txtRegID.Text
        txtRegID.Focus() : txtRegID.SelectAll()
        CHkRemove.Checked = False
        dtpBOndPeriod.Value = Now.Date
        dtpProbation.Value = Now.Date
        RefreshEmployee(StrEmployeeID)
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If

        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("select religDesc+'='+ cast(religID as varchar) from tblSetReligion  where status=0", cmbReligion.Text, "relig", s, "religionID", True, "Edit Religion")
        RefreshEmployee(txtRegID.Text)

        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If

        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("select NatDesc+'='+ cast(NatID as varchar) from [tblSetNationality]  where status=0", cmbNationality.Text, "National", s, "nationalityID", True, "Edit Nationality")
        RefreshEmployee(txtRegID.Text)

        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub picEDesig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEDesig.Click
        If pnlEdit.Height = pnlRight.Height Then
            pnlEdit.Height = 0
        ElseIf pnlEdit.Height = 0 Then
            pnlEdit.Height = pnlRight.Height
        End If

        Dim s = StrDispName & "=" & txtRegID.Text
        EditEmployee("select curDesc+'='+ cast(curID as varchar) from [tblSetCurrency]  where status=0", cmbCurrency.Text, "Currency", s, "currencyID", True, "Edit CurrencyID")
        RefreshEmployee(txtRegID.Text)

        Me.pnlEdit.Controls.Clear()
        Dim frmReg As New FrmEditEmployee
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.pnlEdit.Controls.Add(frmReg)
        frmReg.Location = New Point(0, 96)
        frmReg.Show()
    End Sub

    Private Sub cmbBankNa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBankNa.SelectedIndexChanged
        FillComboPay(cmbBranchBank, "Select BranchName+'='+BrID from tblBranches where status='0' and BankID='" & FK_GetIDR(cmbBankNa.Text) & "' order by BranchName asc")
    End Sub

End Class