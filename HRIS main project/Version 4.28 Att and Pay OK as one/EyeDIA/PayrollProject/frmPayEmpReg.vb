Imports System.Data.SqlClient
Imports System.IO

Public Class frmEmpReg

    Public SEmpID As String = ""
    Dim strExcistedNIC As String = ""

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmPayCentre.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmCostCentre.ShowDialog()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmUserLvls.ShowDialog()
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FillCombo(cmbPayCenter, "select pDesc from tblsetpcentre")

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FillCombo(cmbCostCenter, "Select cntDesc from tblsetcCentre")

    End Sub

    Private Sub Referesh1()

        FK_Clear(Me)
        FillCombo(cmbPrCatagory, "select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0 order by CatDesc Asc ")
        FillCombo(cmbCompany, "Select CName+'='+CompID from tblCompany where status =0 order by cname Asc")
        FillCombo(cmbDesignation, "Select desgdesc+'='+DesgID from tblDesig where status='0' order by desgdesc Asc ")
        FillCombo(cmbbranch, "Select BrName+'='+BrID from tblCBranchs where compID='001' and status='0'  order by BrName asc")
        FillCombo(cmbDepartment, "select DeptName+'='+DeptID from tblsetDept where Status='0' order by DeptName asc")
        FillCombo(cmbPayCenter, "select pDesc+'='+pid from tblsetpcentre where status=0 order by pDesc asc")
        FillCombo(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc Asc")
        FillCombo(cmbSalaryViewLevel, " Select LevelName+'='+ID from tblUL where status=0 order by LevelName asc")
        FillCombo(cmbCostCenter, "Select cntDesc+'='+cntID from tblsetcCentre where status=0 order by cntDesc asc")
        FillCombo(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0 order by BankName asc")
        FillCombo(cmbReligion, "  Select ReligDesc+'='+ReligID from tblSetReligion where status=0 order by ReligDesc ")
        'FillCombo(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0")
        cmbBranchBank.Text = ""

        pbStSign.Image = Nothing
        tabOther.SelectedTab = tbpImportant
        'sSQL = "Select CatDesc+'='+CatID  from tblemp_subcategory"
        'FillCombo(cmbSubCategory, sSQL)
        strSaveStatus = "S"
        txtRegID.Text = Format(GetVal("Select max(convert(int,regId))+1  as 'ABC' from  TBLPAYROLLEMPLOYEE"), "00000#")
        SEmpID = txtRegID.Text
        txtRegID.Focus() : txtRegID.SelectAll()
        CHkRemove.Checked = False
        dtpBOndPeriod.Value = Now.Date
        dtpDofB.Value = Now.Date
        dtpJoin.Value = Now.Date
        dtpProbation.Value = Now.Date
        txtBasicSalary.BackColor = Color.White
        'cmbPrCatagory.Enabled = True
        'cmbBankNa.Enabled = True
        'cmbbranch.Enabled = True
        'cmbPayCenter.Enabled = True
        'cmbBranchBank.Enabled = True
        'cmbReligion.Enabled = True
        'cmbCompany.Enabled = True
        'cmbDepartment.Enabled = True
        'cmbDesignation.Enabled = True
        'cmbCostCenter.Enabled = True
        'cmbSalaryViewLevel.Enabled = True
        'cmbSubCategory.Enabled = True
    End Sub

    Public Sub ViewEmployeeImage()

        Try
            Dim CN As New SqlConnection(sqlConString)
            CN.Open()

            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = New SqlCommand("SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & txtRegID.Text & "' and Status='0'", CN)
            Dim Data As New DataTable
            'adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn)

            Dim commandbuild As New SqlCommandBuilder(adapter)
            adapter.Fill(Data)
            ' MsgBox(Data.Rows.Count)


            Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("svImage")
            Dim lstr As New System.IO.MemoryStream(lb)
            pbStSign.Image = Image.FromStream(lstr)
            pbStSign.SizeMode = PictureBoxSizeMode.Zoom
            lstr.Close()

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmEmployeeReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ControlHandlers(Me)
        CenterFormThemed(Me, Panel1, Label1)
        ''Dim sSQL As String = "Create table tblPayrollEmployee (RegID nvarchar(10),DispName nvarchar(250),EMPNo nvarchar(10),EPFNo nvarchar(15),ETPNo nvarchar(15),ComID nvarchar(3),DesigID nvarchar(3),BrID nvarchar(3),DeptID nvarchar(3),BasicSalary numeric(18,2)not null default 0,DaysPay Numeric(18,2)not null default 0,EpfAllowed Numeric(1,0) not null default 0,PayID nvarchar(2),CostID nvarchar(2),SalViewLevel decimal(18,0)null,Status Numeric(1,0) not null Default 0)"
        ''FK_QueryRun(sSQL, False, False)

        ''sSQL = "CREATE TABLE [dbo].[tblEmpImage]([EmpID] [nvarchar](6) NULL,[empPic] [image] NULL,[Status] [numeric](18, 0) NULL) "
        ''FK_QueryRun(sSQL, False, False)

        sSQL = "Alter table tblPayrollEmployee add sub_CatID nvarchar(3)"
        EQ(sSQL)

        sSQL = "Alter table tblPayrollEmployee add BankID nvarchar(3)"
        EQ(sSQL)

        sSQL = "Alter table tblPayrollEmployee add BranchID nvarchar(3)"
        EQ(sSQL)

        sSQL = "Alter table tblPayrollEmployee add ReligionID nvarchar(3)"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add birthDate datetime null"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add joiningDate datetime null"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add BondPeriod datetime null"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add ProbationDate datetime null"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add points numeric(18,0) null"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add genderID nvarchar(3)"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add maritalID nvarchar(3)"
        EQ(sSQL)

        sSQL = "alter table tblPayrollEmployee add otherIDs nvarchar(100)"
        EQ(sSQL)

        sSQL = "alter Table tblpayrollemployee add accNumber nvarchar(20) null"
        EQ(sSQL)

        sSQL = "alter Table tblpayrollemployee add Contact nvarchar(1000) null"
        EQ(sSQL)

        sSQL = "alter Table tblpayrollemployee add Qualification nvarchar(1000) null"
        EQ(sSQL)
        sSQL = "Alter table tblControl Add SubCatID decimal(18,0) not null default 0"
        EQ(sSQL)
        sSQL = "Alter table tblPayrollEmployee add FinalSalary decimal(18,0) not null default 0"
        EQ(sSQL)
        sSQL = "alter table [tblPayrollEmployee] alter column BankId nvarchar(5)"
        EQ(sSQL)

        If StrEmployeeID <> "" Then
            txtRegID.Text = StrEmployeeID
            FillCombo(cmbPrCatagory, "select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0 order by CatDesc Asc ")
            FillCombo(cmbCompany, "Select CName+'='+CompID from tblCompany where status =0 order by cname Asc")
            FillCombo(cmbDesignation, "Select desgdesc+'='+DesgID from tblDesig where status='0' order by desgdesc Asc ")
            FillCombo(cmbbranch, "Select BrName+'='+BrID from tblCBranchs where compID='001' and status='0'  order by BrName asc")
            FillCombo(cmbDepartment, "select DeptName+'='+DeptID from tblsetDept where Status='0' order by DeptName asc")
            FillCombo(cmbPayCenter, "select pDesc+'='+pid from tblsetpcentre where status=0 order by pDesc asc")
            FillCombo(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc Asc")
            FillCombo(cmbSalaryViewLevel, " Select LevelName+'='+ID from tblUL where status=0 order by LevelName asc")
            FillCombo(cmbCostCenter, "Select cntDesc+'='+cntID from tblsetcCentre where status=0 order by cntDesc asc")
            FillCombo(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0 order by BankName asc")
            FillCombo(cmbReligion, "  Select ReligDesc+'='+ReligID from tblSetReligion where status=0 order by ReligDesc ")
            FillCombo(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0")
            RefreshEmployee(txtRegID.Text)
            StrEmployeeID = ""

            'cmbPrCatagory.Enabled = False
            'cmbBankNa.Enabled = False
            'cmbbranch.Enabled = False
            'cmbPayCenter.Enabled = False
            'cmbBranchBank.Enabled = False
            'cmbReligion.Enabled = False
            'cmbCompany.Enabled = False
            'cmbDepartment.Enabled = False
            'cmbDesignation.Enabled = False
            'cmbCostCenter.Enabled = False
            'cmbSalaryViewLevel.Enabled = False
            'cmbSubCategory.Enabled = False
        Else
            Referesh1()
        End If

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmCompany)
        FillCombo(cmbCompany, "Select CName from tblCompany where status =0")

    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged

        FillCombo(cmbbranch, "Select BrName+'='+BrID from tblCBranchs where compID='" & FK_GetIDR(cmbCompany.Text) & "' and status='0' ")

    End Sub

    Private Sub cmbSalaryViewLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = ChrW(Keys.Enter) Then Call cmdSave_Click(sender, e)

    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub txtRegID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegID.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SEmpID = txtRegID.Text
            sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel is null"
            Dim CN As New SqlConnection(sqlConString)
            Try


                CN.Open()
                Dim CMD As New SqlCommand(sSQL, CN)
                Dim RD As SqlDataReader = CMD.ExecuteReader
                If RD.HasRows = True Then
                    Button16_Click(sender, e)

                    While RD.Read
                        strSaveStatus = "E"
                        txtRegID.Text = IIf(IsDBNull(RD.Item("regid")), "", RD.Item("regid"))
                        txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                        txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                        txtDisplayName.Text = IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                        txtETFNo.Text = IIf(IsDBNull(RD.Item("ETPNo")), "", RD.Item("ETPNo"))
                        cmbCompany.Text = IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                        cmbbranch.Text = IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                        cmbDesignation.Text = IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                        cmbDepartment.Text = IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                        'cmbbranch.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                        txtBasicSalary.Text = IIf(IsDBNull(RD.Item("BasicSalary")), "", RD.Item("BasicSalary"))
                        txtDaysPay.Text = IIf(IsDBNull(RD.Item("DaysPay")), "", RD.Item("DaysPay"))
                        txtEmpIDNum.Text = IIf(IsDBNull(RD.Item("EmIdNum")), "", RD.Item("EmIdNum"))
                        cmbPayCenter.Text = IIf(IsDBNull(RD.Item("pDesc")), "", RD.Item("pDesc"))
                        cmbCostCenter.Text = IIf(IsDBNull(RD.Item("cntDesc")), "", RD.Item("cntDesc"))
                        cmbSalaryViewLevel.Text = IIf(IsDBNull(RD.Item("LevelName")), "", RD.Item("LevelName"))
                        cmbPrCatagory.Text = IIf(IsDBNull(RD.Item("CatDesc")), "", RD.Item("CatDesc"))
                        txtDisplayName.Focus()
                    End While
                Else
                    MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

        ' If e.KeyChar = ChrW(Keys.Escape) Then dgvData.Visible = False
    End Sub

    'Private Sub dgvData_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    'txtDisplayName.Text = dgvData.CurrentRow.Index
    '    Try
    '        'dgvData.Rows(e.RowIndex)
    '        For X = 0 To e.RowIndex - 1
    '            dgvData.Rows(X).DefaultCellStyle.BackColor = Color.White
    '        Next
    '        dgvData.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gold
    '        For X = e.RowIndex + 1 To dgvData.RowCount - 1
    '            dgvData.Rows(X).DefaultCellStyle.BackColor = Color.White
    '        Next
    '        'dgvData.Rows(e.RowIndex + 1).DefaultCellStyle.BackColor = Color.White
    '        ' dgvData.Item(e.ColumnIndex, e.RowIndex).Selected = True
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub dgvData_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'On Error Resume Next
        'txtRegID.Text = dgvData.Item(2, dgvData.CurrentRow.Index).Value
        'dgvData.Visible = False
    End Sub

    Private Sub dgvData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    txtRegID.Text = dgvData.Item(2, dgvData.CurrentRow.Index).Value
        '    dgvData.Visible = False
        '    txtRegID.Focus()
        'End If
    End Sub

    Private Sub dgvData_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'If e.KeyChar = ChrW(Keys.Escape) Then
        '    dgvData.Visible = False : txtRegID.Focus()

        'End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'If SEmpID <> txtRegID.Text Then MsgBox("Invalid Employee Details. Please Check the Registeration ID.", MsgBoxStyle.Critical) : Exit Sub
        If Trim(txtRegID.Text) = "" Then MsgBox("Invalid Reg ID", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub
        If txtDisplayName.Text = "" Then MsgBox("Invalid Employee Name", MsgBoxStyle.Critical) : txtDisplayName.Focus() : Exit Sub
        If FK_GetIDR(cmbbranch.Text) = "" Then MsgBox("Invalid Branch", MsgBoxStyle.Critical) : cmbbranch.Focus() : Exit Sub
        'If FK_GetIDR(cmbCompany.Text) = "" Then MsgBox("Invalid Company", MsgBoxStyle.Critical) : cmbCompany.Focus() : Exit Sub
        If FK_GetIDR(cmbDepartment.Text) = "" Then MsgBox("Invalid Department", MsgBoxStyle.Information) : cmbDepartment.Focus() : Exit Sub
        If FK_GetIDR(cmbDesignation.Text) = "" Then MsgBox("Invalid Designation", MsgBoxStyle.Critical) : cmbDesignation.Focus() : Exit Sub
        If FK_GetIDR(cmbPrCatagory.Text) = "" Then MsgBox("Invalid Salary Process Category.", MsgBoxStyle.Critical) : cmbPrCatagory.Focus() : Exit Sub
        'If txtPoints.Text = "" Then MsgBox("Invalid Point", MsgBoxStyle.Critical) : txtPoints.Focus() : Exit Sub
        If FK_GetIDR(cmbGender.Text) = "" Then MsgBox("Invalid Gender", MsgBoxStyle.Critical) : cmbGender.Focus() : Exit Sub
        'If FK_GetIDR(cmbCostCenter.Text) = "" Then MsgBox("Invalid Cost Center", MsgBoxStyle.Critical) : cmbCostCenter.Focus() : Exit Sub
        'If iewLevel.Text = "" Then MsgBox("Invalid Salary View Level", MsgBoxStyle.Critical) : cmbSalaryViewLevel.Focus() : Exit Sub
        Dim FinalSalary As Integer = 0 ' Salary Cash
        If rdbBank.Checked Then FinalSalary = 1 ' Salary Bank
        If rdbCheque.Checked Then FinalSalary = 2 ' Salary Cheque

        Dim ETFN As String = txtEPFNo.Text
        Dim ifEx As Boolean = False
        ifEx = fk_CheckEx("Select * from tblPayrollEmployee where RegID='" & txtRegID.Text & "'")

        If ifEx = False Then

            'Check NIC duplication.
            Dim bolExNIC As Boolean = fk_CheckEx("select * from tblPayrollEmployee where comID='" & StrCompID & "' and EmIdNum = '" & txtEmpIDNum.Text.Trim & "'")
            If bolExNIC = True Then
                MsgBox("The NIC Number has already been saved and can not be Duplicated.", MsgBoxStyle.Critical)
                txtEmpIDNum.Focus()
                Exit Sub
            End If

            txtRegID.Text = Format(GetVal("Select max(convert(int,regId))+1  as 'ABC' from  TBLPAYROLLEMPLOYEE"), "00000#")

            If txtEmpNo.Text.Trim <> "" Then If fk_CheckEx("Select EMPNo from tblPayrollEmployee where empNo='" & txtEmpNo.Text & "'") = True Then MsgBox("Emp No Already Exists", MsgBoxStyle.Information) : txtEmpNo.Focus() : txtEmpNo.SelectAll() : Exit Sub
            If txtEPFNo.Text.Trim <> "" Then If fk_CheckEx("Select EPFNo from tblPayrollEmployee where EPFNo='" & txtEPFNo.Text & "'") = True Then MsgBox("EPF No Already Exists", MsgBoxStyle.Information) : txtEPFNo.Focus() : txtEPFNo.SelectAll() : Exit Sub
            If txtETFNo.Text.Trim <> "" Then If fk_CheckEx("Select ETPNo from tblPayrollEmployee where ETPNo='" & txtETFNo.Text & "'") = True Then MsgBox("ETF No Already Exists", MsgBoxStyle.Information) : txtETFNo.Focus() : txtETFNo.SelectAll() : Exit Sub
            Dim sCHKST As String = "0"
            Dim sSQL As String
            sSQL = "INSERT INTO tblPayrollEmployee ([RegID] ,[DispName] ,[EMPNo] ,[EPFNo],[ETPNo],[PrCatID],[EmIdNum],[ComID],[DesigID],[BrID],[DeptID],[BasicSalary],[DaysPay],[EpfAllowed],[PayID],[CostID],[SalViewLevel],sub_CatID,BankID,BranchID,ReligionID,birthDate,joiningDate,BondPeriod,ProbationDate,points,genderID,maritalID,otherIDs,accNumber,Contact,Qualification,FinalSalary)     VALUES ( " & _
            "   '" & txtRegID.Text & "', " & _
            "   '" & txtDisplayName.Text & "', " & _
            "   '" & txtEmpNo.Text & "', " & _
            "   '" & txtEPFNo.Text & "', " & _
            "   '" & ETFN & "', " & _
            "   '" & FK_GetIDR(cmbPrCatagory.Text) & "', " & _
            "   '" & txtEmpIDNum.Text & "', " & _
            "   '001', " & _
            "   '" & FK_GetIDR(cmbDesignation.Text) & "', " & _
            "   '" & FK_GetIDR(cmbbranch.Text) & "', " & _
            "   '" & FK_GetIDR(cmbDepartment.Text) & "', " & _
            "   '" & Val(txtBasicSalary.Text) & "', " & _
            "   '" & Val(txtDaysPay.Text) & "', " & _
            "   '" & sCHKST & "', " & _
            "   '" & IIf(FK_GetIDR(cmbPayCenter.Text) = "", "-", FK_GetIDR(cmbPayCenter.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbCostCenter.Text) = "", "-", FK_GetIDR(cmbCostCenter.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbSalaryViewLevel.Text) = "", "000", FK_GetIDR(cmbSalaryViewLevel.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbSubCategory.Text) = "", "-", FK_GetIDR(cmbSubCategory.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbBankNa.Text) = "", "-", FK_GetIDR(cmbBankNa.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbBranchBank.Text) = "", "-", FK_GetIDR(cmbBranchBank.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbReligion.Text) = "", "-", FK_GetIDR(cmbReligion.Text)) & "', " & _
            "   '" & Format(dtpDofB.Value, "yyyyMMdd") & "','" & Format(dtpJoin.Value, "yyyyMMdd") & "', " & _
            "   '" & Format(dtpBOndPeriod.Value, "yyyyMMdd") & "','" & Format(dtpProbation.Value, "yyyyMMdd") & "', " & _
            "   '" & IIf(txtPoints.Text = "", 0, Val(txtPoints.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbGender.Text) = "", "-", FK_GetIDR(cmbGender.Text)) & "', " & _
            "   '" & IIf(FK_GetIDR(cmbMarital.Text) = "", "-", FK_GetIDR(cmbMarital.Text)) & "', " & _
            "   '" & IIf(txtOtherID.Text = "", "-", txtOtherID.Text) & "', " & _
            "   '" & IIf(txtAccNumber.Text = "", "-", txtAccNumber.Text) & "', " & _
            "   '" & IIf(txtContactInf.Text = "", "-", UCase(txtContactInf.Text)) & "', " & _
            "   '" & IIf(txtQualification.Text = "", "-", UCase(txtQualification.Text)) & "' " & _
            "   ," & FinalSalary & ")"
            If UP("Employee Register", "Add Employees") = False Then Exit Sub
            If FK_EQ(sSQL, "S", True, True, True) = True Then Call Referesh1()
        Else
            If strExcistedNIC <> txtEmpIDNum.Text.Trim Then
                If True = fk_CheckEx("select * from tblPayrollEmployee where comID='" & StrCompID & "' and EmIdNum = '" & txtEmpIDNum.Text.Trim & "' and regid <> '" & txtRegID.Text & "'") Then
                    MsgBox("This NIC Number has been Set for Another Employee.Please Select Different NIC Number.", MsgBoxStyle.Information)
                    txtEmpIDNum.Focus()
                    Exit Sub
                End If
            End If
            Dim sSQl As String
            sSQl = "    Update [tblPayrollEmployee]  " & _
                    "   Set [DispName] = '" & txtDisplayName.Text & "'  " & _
                    "   ,[EMPNo] =    '" & txtEmpNo.Text & "'   " & _
                    "   ,[EPFNo] =    '" & txtEPFNo.Text & "'  " & _
                    "   ,[ETPNo] =    '" & ETFN & "'   " & _
                    "   ,[EmIdNum]=   '" & txtEmpIDNum.Text & "' " & _
                    "   ,[ComID] =    '001'  " & _
                    "   ,[EpfAllowed] = '0'" & _
                    " , Status='" & CHkRemove.CheckState & "' " & _
                    ",birthDate = '" & Format(dtpDofB.Value, "yyyyMMdd") & "' " & _
                    ",joiningDate = '" & Format(dtpJoin.Value, "yyyyMMdd") & "' " & _
                    ",BondPeriod  = '" & Format(dtpBOndPeriod.Value, "yyyyMMdd") & "' " & _
                    ",ProbationDate  = '" & Format(dtpProbation.Value, "yyyyMMdd") & "' " & _
                    ",genderID =   '" & IIf(FK_GetIDR(cmbGender.Text) = "", "-", FK_GetIDR(cmbGender.Text)) & "'  " & _
                    ",maritalID =   '" & IIf(FK_GetIDR(cmbMarital.Text) = "", "-", FK_GetIDR(cmbMarital.Text)) & "'  " & _
                    ",otherIDs =   '" & IIf(txtOtherID.Text = "", "-", txtOtherID.Text) & "'  " & _
                    ",Contact='" & IIf(txtContactInf.Text = "", "-", UCase(txtContactInf.Text)) & "',Qualification='" & IIf(txtQualification.Text = "", "-", UCase(txtQualification.Text)) & "' " & _
                    ",FinalSalary=" & FinalSalary & "  " & _
                    "   WHERE [RegID] = '" & txtRegID.Text & "'; "

            If UP("Employee Register", "Edit Employees") = False Then Exit Sub
            If FK_EQ(sSQl, "E", True, True, True) = True Then Call Referesh1()
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Me.Close()
    End Sub

    Private Sub txtComID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Button3_Click(sender, e)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Call Referesh1()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click

        Button16_Click(sender, e)

        'cmbPrCatagory.Enabled = False
        'cmbBankNa.Enabled = False
        'cmbbranch.Enabled = False
        'cmbPayCenter.Enabled = False
        'cmbBranchBank.Enabled = False
        'cmbReligion.Enabled = False
        'cmbCompany.Enabled = False
        'cmbDepartment.Enabled = False
        'cmbDesignation.Enabled = False
        'cmbCostCenter.Enabled = False
        'cmbSalaryViewLevel.Enabled = False
        'cmbSubCategory.Enabled = False
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"
        If CHKRemoved.Checked = False Then
            sSQL = "SELECT     dbo.tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc,dbo.tblPayrollEmployee.accNumber  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where  tblPayrollEmployee.status=0  AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0)  order by " & strQuery & ""
        Else
            sSQL = "SELECT     dbo.tblPayrollEmployee.RegID,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "' , dbo.tblPayrollEmployee.DispName,dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID,                       dbo.tblCompany.cName+'='+tblCompany.CompID as 'cName', dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc,dbo.tblPayrollEmployee.accNumber  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where  tblPayrollEmployee.status=1  AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0)  order by " & strQuery & ""
        End If
        If FK_Br(sSQL) = True Then
            txtRegID.Text = frmMain.dgvFillGridforRead.Item(0, 0).Value
            RefreshEmployee(txtRegID.Text)
        End If
        
    End Sub

    Public Sub RefreshEmployee(ByVal sRegID As String)
        If sRegID = "" Then Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum,  dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName+'='+tblCompany.CompID as 'cName', dbo.tblDesig.desgDesc+'='+tblDesig.DesgID as 'desgDesc', dbo.tblSetDept.DeptName+'='+tblSetDept.DeptID as 'DeptName', dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,dbo.tblPayrollEmployee.accNumber,dbo.tblPayrollEmployee.Contact, dbo.tblPayrollEmployee.Qualification,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc+'='+pid as 'pDesc', dbo.tblSetCCentre.cntDesc+'='+cntID as 'cntDesc', dbo.tblUL.LevelName+'='+tblUL.ID as 'LevelName', dbo.tblCBranchs.BrName+'='+tblCBranchs.BrID as 'BrName',tblSetPrCategory.CatDesc+'='+tblSetPrCategory.CatID as 'CatDesc',tblSetEmpCategory.CatDesc+'='+tblSetEmpCategory.catid as 'Sub_category' ,dbo.tblPayrollEmployee.birthDate, dbo.tblPayrollEmployee.joiningDate, dbo.tblPayrollEmployee.ProbationDate, dbo.tblPayrollEmployee.bondPeriod, dbo.tblPayrollEmployee.points,dbo.tblSetEmpCategory.catDesc+'='+tblSetEmpCategory.CatID as 'catDesc',dbo.tblBanks.BankName+'='+tblBanks.BankID as 'BankName',dbo.tblBranches.BranchName+'='+tblBranches.BrID as 'BranchName',dbo.tblPayrollEmployee.otherIDs,dbo.tblPayrollEmployee.genderID,dbo.tblPayrollEmployee.maritalID,dbo.tblsetreligion.ReligDesc+'='+tblsetreligion.ReligId as 'ReligDesc',FinalSalary,Contact,Qualification ,tblPayrollEmployee.status FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID   LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblPayrollEmployee.sub_catID = dbo.tblSetEmpCategory.catID       LEFT OUTER JOIN dbo.tblBanks ON dbo.tblPayrollEmployee.BankID = dbo.tblBanks.BankID     LEFT OUTER JOIN dbo.tblBranches ON dbo.tblPayrollEmployee.branchID = dbo.tblBranches.brID      LEFT OUTER JOIN dbo.tblsetreligion ON dbo.tblPayrollEmployee.religionID = dbo.tblsetreligion.religID WHERE     (dbo.tblPayrollEmployee.RegID = '" & sRegID & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.RegID = '" & sRegID & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("regid")), "", RD.Item("regid"))
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtDisplayName.Text = IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtETFNo.Text = IIf(IsDBNull(RD.Item("ETPNo")), "", RD.Item("ETPNo"))
                    txtPoints.Text = IIf(IsDBNull(RD.Item("points")), "", RD.Item("points"))
                    txtContactInf.Text = IIf(IsDBNull(RD.Item("Contact")), "", RD.Item("Contact"))
                    txtQualification.Text = IIf(IsDBNull(RD.Item("Qualification")), "", RD.Item("Qualification"))
                    cmbCompany.Text = IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    cmbbranch.Text = IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    cmbDesignation.Text = IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    cmbDepartment.Text = IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    'cmbbranch.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    If isViewBasic = 1 Then
                        txtBasicSalary.Text = IIf(IsDBNull(RD.Item("BasicSalary")), "", RD.Item("BasicSalary"))
                        pbBasic.Enabled = True
                        txtBasicSalary.BackColor = Color.White
                    Else
                        txtBasicSalary.Text = "Hidden"
                        pbBasic.Enabled = False
                        txtBasicSalary.BackColor = Color.Red
                    End If
                    txtDaysPay.Text = IIf(IsDBNull(RD.Item("DaysPay")), "", RD.Item("DaysPay"))
                    txtEmpIDNum.Text = IIf(IsDBNull(RD.Item("EmIdNum")), "", RD.Item("EmIdNum"))
                    strExcistedNIC = Trim(txtEmpIDNum.Text)
                    txtAccNumber.Text = IIf(IsDBNull(RD.Item("accNumber")), "", RD.Item("accNumber"))
                    txtOtherID.Text = IIf(IsDBNull(RD.Item("otherIDs")), "", RD.Item("otherIDs"))
                    dtpDofB.Value = IIf(IsDBNull(RD.Item("birthDate")), "1900/01/01", RD.Item("birthDate"))
                    dtpJoin.Value = IIf(IsDBNull(RD.Item("joiningDate")), "1900/01/01", RD.Item("joiningDate"))
                    dtpBOndPeriod.Value = IIf(IsDBNull(RD.Item("bondPeriod")), "1900/01/01", RD.Item("bondPeriod"))
                    dtpProbation.Value = IIf(IsDBNull(RD.Item("ProbationDate")), "1900/01/01", RD.Item("ProbationDate"))

                    Dim str As String = IIf(IsDBNull(RD.Item("EPFAllowed")), "", RD.Item("EPFAllowed"))
                    cmbPayCenter.Text = IIf(IsDBNull(RD.Item("pDesc")), "", RD.Item("pDesc"))
                    cmbCostCenter.Text = IIf(IsDBNull(RD.Item("cntDesc")), "", RD.Item("cntDesc"))
                    cmbSalaryViewLevel.Text = IIf(IsDBNull(RD.Item("LevelName")), "", RD.Item("LevelName"))
                    cmbPrCatagory.Text = IIf(IsDBNull(RD.Item("CatDesc")), "", RD.Item("CatDesc"))
                    cmbSubCategory.Text = IIf(IsDBNull(RD.Item("catDesc")), "", RD.Item("catDesc"))
                    cmbBankNa.Text = IIf(IsDBNull(RD.Item("bankName")), "", RD.Item("bankName"))
                    cmbBranchBank.Text = IIf(IsDBNull(RD.Item("brName")), "", RD.Item("brName"))
                    cmbReligion.Text = IIf(IsDBNull(RD.Item("religDesc")), "", RD.Item("religDesc"))
                    Dim sSC As String = IIf(IsDBNull(RD.Item("Sub_category")), "", RD.Item("Sub_category"))
                    sSQL = "select (BranchName+'='+BrID) from tblBranches where BankID='" & FK_GetIDR(cmbBankNa.Text) & "' and BrID=(select BranchID from tblPayrollemployee where RegID='" & txtRegID.Text & "')"
                    cmbBranchBank.Text = fk_RetString(sSQL)
                    Dim abc As String
                    If sSC <> Nothing Or sSC <> "" Then
                        abc = fk_RetString("select CatDesc from tblemp_subcategory where CatID='" & sSC & "'")
                        cmbSubCategory.Text = abc & "=" & sSC
                    End If

                    Dim strGenderID As String = IIf(IsDBNull(RD.Item("genderID")), "", RD.Item("genderID"))
                    If strGenderID = "002" Then
                        cmbGender.Text = "Female=002"
                    ElseIf strGenderID = "001" Then
                        cmbGender.Text = "Male=001"
                    End If

                    Dim strMaritalID As String = IIf(IsDBNull(RD.Item("maritalID")), "", RD.Item("maritalID"))
                    If strMaritalID = "001" Then
                        cmbMarital.Text = "Unmarried=001"
                    ElseIf strMaritalID = "002" Then
                        cmbMarital.Text = "Married=002"
                    End If

                    Dim strFinalSalary As String = IIf(IsDBNull(RD.Item("finalSalary")), "", RD.Item("finalSalary"))
                    If strFinalSalary = "0" Then
                        rdbCash.Checked = True
                    ElseIf strFinalSalary = "1" Then
                        rdbBank.Checked = True
                    ElseIf strFinalSalary = 2 Then
                        rdbCheque.Checked = True
                    End If

                    CHkRemove.CheckState = IIf(IsDBNull(RD.Item("status")), "", RD.Item("status"))
                    If CHkRemove.Checked = True Then
                        txtDisplayName.BackColor = Color.Red
                    Else
                        txtDisplayName.BackColor = Color.White
                    End If

                    'txtDisplayName.Focus()
                    ViewEmployeeImage()
                    'dtpProbation_ValueChanged(sender, e)

                End While

            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If UP("Employee Register", "Delete Employees") = False Then Exit Sub
        Dim sSQL As String
        sSQL = "Delete from tblPayrollEmployee where regid='" & txtRegID.Text & "'"
        FK_EQ(sSQL, "D", True, True, True)
        Call Referesh1()
    End Sub

    Private Sub txtEmpNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpNo.Leave
        '  If fk_CheckEx("Select EMPNo from tblPayrollEmployee where empNo='" & txtEmpNo.Text & "'") = True Then MsgBox("Emp No Already Exists", MsgBoxStyle.Information) : txtEmpNo.Focus() : txtEmpNo.SelectAll() : Exit Sub

    End Sub

    Private Sub txtEmpNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpNo.TextChanged

    End Sub

    Private Sub txtEPFNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEPFNo.Leave
        ' If fk_CheckEx("Select EPFNo from tblPayrollEmployee where EPFNo='" & txtEPFNo.Text & "'") = True Then MsgBox("EPF No Already Exists", MsgBoxStyle.Information) : txtEPFNo.Focus() : txtEPFNo.SelectAll() : Exit Sub

    End Sub

    Private Sub txtEPFNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPFNo.TextChanged
        txtETFNo.Text = txtEPFNo.Text
        txtEmpNo.Text = txtEPFNo.Text
    End Sub

    Private Sub txtEmpIDNum_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpIDNum.KeyDown
        If Len(Trim(txtEmpIDNum.Text)) > 5 Then
            IDNum_Results(txtEmpIDNum.Text)
            dtpDofB.Value = dtNICDoB
            cmbGender.Text = StrNICSex

        End If
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub txtETFNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtETFNo.Leave, txtEmpIDNum.Leave
        ' If fk_CheckEx("Select ETPNo from tblPayrollEmployee where ETPNo='" & txtETFNo.Text & "'") = True Then MsgBox("ETF No Already Exists", MsgBoxStyle.Information) : txtETFNo.Focus() : txtETFNo.SelectAll() : Exit Sub

    End Sub

    Private Sub txtETFNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtETFNo.TextChanged, txtEmpIDNum.TextChanged

    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSync.ShowDialog()


        'Dim sSQL As String
        'sSQL = "Insert into tblPayrollEmployee (RegID,DispName,EMPNO,EPFNo,ComID,DesigID,BrID,DeptID) Select RegID,DispName,EMpNo,EPFNo,CompID,DesigID,BrID,DeptID from tblEmployee"
        'FK_EQ(sSQL, "P", True, True, True)
    End Sub

    Private Sub cmbSalaryViewLevel_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSalaryViewLevel.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSync.Click
        frmSync.ShowDialog()
    End Sub

    Private Sub txtRegID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegID.TextChanged
        txtEPFNo.Text = txtRegID.Text
    End Sub

    Private Sub txtDisplayName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtETFNo.KeyPress, txtEPFNo.KeyPress, txtEmpNo.KeyPress, txtEmpIDNum.KeyPress, txtDisplayName.KeyPress, txtDaysPay.KeyPress, txtBasicSalary.KeyPress

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
    Private Sub chkEPF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkEPF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        cmbPrCatagory.Focus()
    End Sub

    Private Sub cmbPrCatagory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPrCatagory.KeyPress, cmbPayCenter.KeyPress, cmbDesignation.KeyPress, cmbDepartment.KeyPress, cmbCostCenter.KeyPress, cmbCompany.KeyPress, cmbbranch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        LoadForm(New frmSetProcesCategory)

        FillCombo(cmbPrCatagory, "select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0 ORDER BY CatDesc")

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click

        LoadForm(New frmCompany)

        FillCombo(cmbCompany, "Select CName+'='+CompID from tblCompany where status =0 ORDER BY CName")

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click

        LoadForm(New frmSetDesignation)

        FillCombo(cmbDesignation, "Select desgdesc+'='+DesgID from tblDesig where status='0' ORDER BY desgdesc")

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click

        LoadForm(New frmBranchs)

        FillCombo(cmbbranch, "Select BrName+'='+BrID from tblCBranchs where compID='" & FK_GetIDR(cmbCompany.Text) & "' and status='0' ")

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click

        LoadForm(New frmSetDepartments)

        FillCombo(cmbDepartment, "select DeptName+'='+DeptID from tblsetDept where Status='0' ORDER BY DeptName")

    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click

        LoadForm(New frmPayCentre)
        FillCombo(cmbPayCenter, "select pDesc+'='+pid from tblsetpcentre where status=0 ORDER BY pDesc")

    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click

        LoadForm(New frmCostCentre)
        FillCombo(cmbCostCenter, "Select cntDesc+'='+cntID from tblsetcCentre where status=0 ORDER BY cntDesc")

    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click

        LoadForm(New frmUserLvls)
        FillCombo(cmbSalaryViewLevel, " Select LevelName+'='+ID from tblUL where status=0 order by LevelName asc")

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click

        LoadForm(New frmEmpCategory)
        FillCombo(cmbSubCategory, "Select CatDesc+'='+catid from tblSetEmpCategory where status=0 ORDER BY CatDesc")

    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click

        LoadForm(New frmPayBanks1)
        FillCombo(cmbBankNa, "  Select BankName+'='+BankID from tblBanks where status=0 ORDER BY BankName")

    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click

        LoadForm(New frmPayBanks1)
        FillCombo(cmbBranchBank, "Select BranchName+'='+BrID from tblBranches where status='0' and BankID='" & FK_GetIDR(cmbBankNa.Text) & "' order by BranchName asc")

    End Sub

    

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetReligion)
        FillCombo(cmbReligion, "  Select ReligDesc+'='+ReligID from tblSetReligion where status=0 order by ReligDesc ")

    End Sub

    Private Sub txtPoints_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        proc_OnlyNumeric1(e)

    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click

        Try
            If txtRegID.Text = "" Then MsgBox("Search the Employee first", MsgBoxStyle.Critical, "error") : Exit Sub
            Dim CN As New SqlConnection(sqlConString)
            OFD.ShowDialog()
            'sSQL = "Alter table tblPayrollemployee add StudSignImage LongBlob;"
            'EQ(sSQL)

            Dim strEmployeeImage As String = OFD.FileName
            If System.IO.File.Exists(strEmployeeImage) = True Then
                'Dim stream As New FileStream(strStudentImage, FileMode.Open)
                'Dim image As Image = image.FromStream(stream)
                pbStSign.Image = Image.FromFile(strEmployeeImage)
                'stream.Close()
                'stream.Dispose()

                If MsgBox("Are you sure you want to Save This Image", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then

                    'Dim sql As String
                    Dim sqlcmd As New SqlCommand

                    'Dim filename As String = txtName.Text + ".jpg"
                    'Dim FileSize As UInt32


                    Dim mstream As New MemoryStream()
                    pbStSign.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim arrImage() As Byte = mstream.GetBuffer()
                    'FileSize = mstream.Length
                    mstream.Close()

                    Dim sqlQRY As String

                    'Check if this existing record
                    Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblImgInfo WHERE ImgID = '" & txtRegID.Text & "'")

                    If pbStSign.Image Is Nothing Then
                        sqlQRY = "DELETE FROM tblImgInfo WHERE ImgID = '" & txtRegID.Text & "'"
                        FK_EQ(sqlQRY, "D", False, True, True)
                        Exit Sub
                    End If

                    If bolEx = True Then
                        sqlQRY = "UPDATE tblImgInfo SET SvImage = @Image WHERE ImgID ='" & txtRegID.Text & "'"

                    Else
                        sqlQRY = "INSERT INTO [tblImgInfo] ([ImgID],[svImage],[Status]) VALUES ('" & txtRegID.Text & "',@Image,@Status)"
                    End If

                    'sql = "update  [tblImgInfo]  set [svImage]=@Image where [imgID]='" & txtRegID.Text & "'"

                    Try
                        CN.Open()
                        With sqlcmd
                            .CommandText = sqlQRY
                            .Connection = CN

                            .Parameters.AddWithValue("@Image", arrImage)
                            .Parameters.AddWithValue("@Status", 0)
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        CN.Close()
                    End Try

                End If

                Dim adapter As New SqlDataAdapter
                adapter.SelectCommand = New SqlCommand(" Select  [svImage] from [tblImgInfo] where [imgID]='" & txtRegID.Text & "' and Status='0'", CN)

                Dim Data As New DataTable
                'adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn)

                Dim commandbuild As New SqlCommandBuilder(adapter)
                adapter.Fill(Data)
                ' MsgBox(Data.Rows.Count)


                Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("svImage")
                Dim lstr As New System.IO.MemoryStream(lb)
                pbStSign.Image = Image.FromStream(lstr)
                pbStSign.SizeMode = PictureBoxSizeMode.Zoom
                lstr.Close()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click

        pbStSign.Image = Nothing

        If pbStSign.Image Is Nothing Then

            'Check if this existing record
            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblImgInfo WHERE ImgID = '" & txtRegID.Text & "'")
            If bolEx = True Then
                Dim sqlQRY As String = "DELETE FROM tblImgInfo WHERE ImgID = '" & txtRegID.Text & "'"
                FK_EQ(sqlQRY, "D", False, True, True)
                Exit Sub
            End If

        End If

    End Sub

    Private Sub cmbBankNa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBankNa.SelectedIndexChanged
        FillCombo(cmbBranchBank, "Select BranchName+'='+BrID from tblBranches where status='0' and BankID='" & FK_GetIDR(cmbBankNa.Text) & "' order by BranchName asc")

    End Sub

    Private Sub txtDaysPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDaysPay.TextChanged

    End Sub

    Private Sub cmbSubCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubCategory.SelectedIndexChanged

    End Sub

    Private Sub cmbSubCategory_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPoints.KeyPress, txtOtherID.KeyPress, txtAccNumber.KeyPress, dtpJoin.KeyPress, dtpDofB.KeyPress, dtpBOndPeriod.KeyPress, cmbSubCategory.KeyPress, cmbReligion.KeyPress, cmbMarital.KeyPress, cmbGender.KeyPress, cmbBranchBank.KeyPress, cmbBankNa.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then SendKeys.Send("{tab}")

    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtEPFNo.Text, "EPF No", s, "EPFNo", False, "Edit EPF No")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtEmpNo.Text, "EMP No", s, "EMPNo", False, "Edit Emp No")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtETFNo.Text, "ETF No", s, "ETPNo", False, "Edit ETF No")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbBasic.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtBasicSalary.Text, "BasSal", s, "BasicSalary", False, "Edit Basic Salary")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtDaysPay.Text, "DaysPay", s, "DaysPay", False, "Edit Days Pay")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("select CatDesc+'='+ cast(CatID as varchar) from tblSetPrCategory  where status=0 order by CatDesc", cmbPrCatagory.Text, "ProCat", s, "PrCatID", True, "Edit Process Category")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox21.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("Select CName+'='+CompID from tblCompany where status =0 order by CName", cmbCompany.Text, "Company", s, "ComID", True, "Edit Company")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox22.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("Select desgdesc+'='+DesgID from tblDesig where status='0' order by desgdesc", cmbDesignation.Text, "Designation", s, "DesigID", True, "Edit Designation")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox23.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("Select BrName+'='+BrID from tblCBranchs order by BrName", cmbbranch.Text, "Branch", s, "BrID", True, "Edit Branch")

        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox24.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("select DeptName+'='+DeptID from tblsetDept where Status='0' order by DeptName", cmbDepartment.Text, "Dept", s, "DeptID", True, "Edit Department")

        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("select pDesc+'='+pid from tblsetpcentre where status=0 order by pDesc", cmbPayCenter.Text, "PayCen", s, "PayID", True, "Edit Pay Center")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox30.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("Select cntDesc+'='+cntID from tblsetcCentre where status=0 order by cntDesc", cmbCostCenter.Text, "CostCen", s, "CostID", True, "Edit Cost Center")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox29.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee(" Select LevelName+'='+ID from tblUL where status=0 order by LevelName asc", cmbSalaryViewLevel.Text, "ViewLevel", s, "SalViewLevel", True, "Edit Salary View Level")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox28.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("Select CatDesc+'='+catid from tblSetEmpCategory where status=0 order by CatDesc", cmbSubCategory.Text, "SubCat", s, "Sub_CatID", True, "Edit Sub Category")

        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox27.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("  Select BankName+'='+BankID from tblBanks where status=0 order by BankName", cmbBankNa.Text, "Bank", s, "BankID", True, "Edit Banks")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("Select BranchName+'='+BrID from tblBranches where status='0' and BankID='" & FK_GetIDR(cmbBankNa.Text) & "' order by BranchName", cmbBranchBank.Text, "BankBran", s, "BranchID", True, "Edit Branch")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox31.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", dtpJoin.Value, "JoinDate", s, "JoiningDate", True, "Edit Join Date")
        RefreshEmployee(txtRegID.Text)

    End Sub

    Private Sub PictureBox32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox32.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", dtpBOndPeriod.Value, "BondPeriod", s, "BondPeriod", True, "Edit Bond Period")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox33.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtPoints.Text, "Points", s, "Points", False, "Edit Points")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub btnSync_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSync.MouseEnter
        btnSync.Height = 55
        btnSync.Width = 60
        btnSync.FlatAppearance.BorderSize = 1
        btnSync.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btnSync_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSync.MouseLeave
        btnSync.Height = 49
        btnSync.Width = 59
        btnSync.FlatAppearance.BorderSize = 0
        btnSync.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub txtEmpIDNum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpIDNum.LostFocus
        If Len(Trim(txtEmpIDNum.Text)) > 5 Then
            IDNum_Results(txtEmpIDNum.Text)
            dtpDofB.Value = dtNICDoB
            cmbGender.Text = StrNICSex
        End If
    End Sub

    Private Sub CHkRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHkRemove.Click
        sSQL = "UPDATE tblPayrollemployee SET Status='" & CHkRemove.CheckState & "' WHERE [RegID] = '" & txtRegID.Text & "'; " & _
        "  INSERT INTO tblPayAudit (trDate,trModule,trDescription,crUser,trStatus) VALUES (GETDATE(),'" & Me.Name & "','Changed status of regID : " & txtRegID.Text & " epfNO : " & txtEPFNo.Text & " Name : " & txtDisplayName.Text & " Status to : " & CHkRemove.CheckState & " ','" & UserID & "',0)"
        FK_EQ(sSQL, "E", True, True, True)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("", txtAccNumber.Text, "AccNum", s, "AccNumber", False, "Edit Account Number")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        Dim s = txtDisplayName.Text & "=" & txtRegID.Text
        EditEmployee("select ReligDesc+'='+ cast(ReligID as varchar) from tblSetReligion  where status=0 order by ReligDesc", cmbReligion.Text, "Relig", s, "religionID", True, "Edit Religion")
        RefreshEmployee(txtRegID.Text)
    End Sub

    Private Sub PictureBox19_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click
        LoadForm(New frmSetReligion)
        FillCombo(cmbReligion, "  Select ReligDesc+'='+ReligID from tblSetReligion where status=0 order by ReligDesc ")
    End Sub

End Class