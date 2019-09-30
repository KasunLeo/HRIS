Public Class frmResign
    Dim intPrsYear As Integer = 0
    Dim intPrsMonth As Integer = 0

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        strReActEmp = "Ac"

        sSQL = "SELECT     dbo.tblEmployee.RegID As RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EpfNo,dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
        "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then

                'StrEmployeeID = FK_Read("RegID") 'fk_RetString("SELECT TOP 1 RegID FROM tblEmployee WHERE RegID = '" & FK_Read("RegID") & "'")
                show_Employee(StrEmployeeID)
                Load_InformationtoGrid("SELECT 'False',tblBenefits.tagID,tblSetBenefits.Descr,tblBenefits.remark FROM tblBenefits INNER JOIN tblSetBenefits ON tblBenefits.benID = tblSetBenefits.benID AND tblBenefits.Status <> 1 AND  tblBenefits.EmpID ='" & StrEmployeeID & "' ", dgvData, 4)

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try
    End Sub

    Public Sub show_Employee(ByVal StrEmp As String)
        Dim intIsEpf As Integer = fk_sqlDbl("SELECT isEpf FROM tblCompany")
        Dim sqlQV As String = ""
        sqlQV = "SELECT tblEmployee.RegID,CASE WHEN " & intIsEpf & " = 0 THEN tblEmployee.RegID WHEN " & intIsEpf & " = 1 THEN tblEmployee.EpfNo WHEN " & intIsEpf & " = 2 THEN Convert(Nvarchar(10),tblEmployee.EnrolNo) ELSE tblEmployee.EmpNo END ,tblEmployee.DispName,tblSetDept.DeptName FROM tblEmployee,tblSetDept WHERE tblEmployee.DeptID = tblSetDept.DeptID  AND tblEmployee.RegID = '" & StrEmployeeID & "'"

        fk_Return_MultyString(sqlQV, 4)
        txtEmpNo.Text = fk_ReadGRID(0)
        txtEpfno.Text = fk_ReadGRID(1)
        txtEmpName.Text = fk_ReadGRID(2)
        txtDeptName.Text = fk_ReadGRID(3)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        For Each crtl In Me.GroupBox1.Controls
            If TypeOf crtl Is TextBox Then crtl.text = ""
        Next

        fk_LoadYear(cmbYear)
        fk_LoadMonths(cmbMonth)
        rdbCancel.Checked = True

        Load_InformationtoGrid("SELECT 'False',tblBenefits.tagID,tblSetBenefits.Descr,tblBenefits.remark  FROM tblBenefits INNER JOIN tblSetBenefits ON tblBenefits.benID = tblSetBenefits.benID AND tblBenefits.Status <> 1 AND  tblBenefits.EmpID ='" & StrEmployeeID & "' ", dgvData, 4)


    End Sub

    Public Function fk_LoadYear(ByVal cmb As ComboBox) As Boolean
        cmb.Items.Clear()
        For i As Integer = (Year(Now.Date) - 1) To (Year(Now.Date) + 10)
            cmb.Items.Add(i.ToString)
        Next
    End Function

    Public Function fk_LoadMonths(ByVal cmb As ComboBox) As Integer
        cmb.Items.Clear()
        Dim StrMonth As String = ""
        For i As Integer = 1 To 12
            StrMonth = MonthName(i)
            cmb.Items.Add(StrMonth)
        Next
    End Function

    Private Sub frmResign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm(Me)
        CenterFormThemed(Me, Panel1, Label13)


        cmdRefresh_Click(sender, e)
        Dim sqlQ As String = ""
        'Create table to Store Resign Information 
        sqlQ = "CREATE TABLE tblResignEmp (RegID Nvarchar (6),ResDate DateTime, ResReason Nvarchar (100),LPayYear Numeric (18,0),LPayMonth Numeric (18,0),Status Numeric (18,0),UserID nvarchar (3),R_TrID NVarchar (6))" : FK_EQ(sqlQ, "S", "", False, False, False)
        sqlQ = "ALTER TABLE tblControl ADD NoResig Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQ, "S", "", False, False, False)

        'Create Table to Sture Employee File
        sqlQ = "CREATE TABLE tblREmpHist (RegID Nvarchar (6),RegDate dateTime,TitleID Nvarchar (3),SurName Nvarchar (100),FirstName Nvarchar (100)," & _
        " dispName Nvarchar (150),NICNumber Nvarchar (13),DofB DateTime,GenderID Nvarchar (3),CivilStID Nvarchar (3),EmpNo Nvarchar (10)," & _
        " EpfNo Nvarchar (10),CompID Nvarchar (3),DesigID Nvarchar (3),BrID Nvarchar (6),DeptID Nvarchar (3),CatID Nvarchar (3),EmpTypeID Nvarchar (3)," & _
        " DefAddID Nvarchar (3),homePhone Nvarchar (40),pMobile Nvarchar (40),OfficePhone Nvarchar (40),Email Nvarchar (40),CntrPeriod Numeric (18,0)," & _
        " ContractStart DateTime,ContractEnd DateTime,CardID Nvarchar (3),StatusDate DateTime,NoAdds Nvarchar (3),EmpStatus Numeric (18,0),NoCards Numeric (18,0)," & _
        " EnrolNo Numeric (18,0),AtPrType Nvarchar (3),wrkCode Nvarchar (3),IsEmpBOT Numeric (18,0),GivenOff Numeric (18,0),confirmDate DateTime,ResDate DateTime,Res_Reason Nvarchar (100),UserID Nvarchar (3))" : FK_EQ(sqlQ, "S", "", False, False, False)

        sqlQ = "ALTER TABLE tblREmpHist ADD LPrcYear Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQ, "S", "", False, False, False)
        sqlQ = "ALTER TABLE tblREmpHist ADD LPrcMonth Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQ, "S", "", False, False, False)

        sqlQ = "DROP PROC sp_Resing" : FK_EQ(sqlQ, "S", "", False, False, False)
        sqlQ = "CREATE PROCEDURE sp_Resing(@frDate DateTime, @EdDate DateTime,@s Numeric (18,0)) As " & _
        " Begin DELETE FROM tblR_Data " & _
        " INSERT INTO tblR_Data (EmpID,e_DispID,dispName,Deptname,jDate,rDate,rReasn,EmpStatus) " & _
        " SELECT tblEmployee.RegID,CASE WHEN @s = 0 THEN tblEmployee.RegID WHEN @s=1 THEN tblEmployee.EpfNo WHEN @s=2 THEN Convert(Nvarchar(10),tblEmployee.EnrolNo) ELSE tblEmployee.EmpNo END,tblEmployee.DispName,tblSetDept.DeptName,tblEmployee.RegDate,tblEmployee.StatusDate,tblEmployee.rReason,tblEmployee.EmpStatus FROM tblEmployee,tblSetDept WHERE tblEmployee.DeptID = tblSetDept.DeptID AND tblEmployee.RegDate Between @frDate AND @EdDate AND tblEmployee.EmpStatus <> 9 " & _
        " INSERT INTO tblR_Data (EmpID,e_DispID,dispName,Deptname,jDate,rDate,rReasn,EmpStatus) " & _
        " SELECT tblEmployee.RegID,CASE WHEN @s = 0 THEN tblEmployee.RegID WHEN @s=1 THEN tblEmployee.EpfNo WHEN @s=2 THEN Convert(Nvarchar(10),tblEmployee.EnrolNo) ELSE tblEmployee.EmpNo END,tblEmployee.DispName,tblSetDept.DeptName,tblEmployee.RegDate,tblEmployee.StatusDate,tblEmployee.rReason,tblEmployee.EmpStatus FROM tblEmployee,tblSetDept WHERE tblEmployee.DeptID = tblSetDept.DeptID AND tblEmployee.StatusDate Between @frDate AND @EdDate AND tblEmployee.EmpStatus = 9 END "
        FK_EQ(sqlQ, "S", "", False, False, False)

        FK_EQ("ALTER TABLE tblEmployee ADD rReason Nvarchar (50) NOT Null Default ''", "S", "", False, False, False)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cmbYear.Text = "" Then MessageBox.Show("Please select resign date", "Attention", MessageBoxButtons.OK) : Exit Sub

        intPrsYear = CInt(cmbYear.Text)
        intPrsMonth = cmbMonth.SelectedIndex + 1
        Dim bolSave As Boolean = False
        If txtSearch.Text = "" Then MsgBox("Please fill the reason", MsgBoxStyle.Information) : Exit Sub
        If cmbYear.Text = "" Then MsgBox("Please select last payroll year", MsgBoxStyle.Information) : cmbYear.Focus() : Exit Sub
        If cmbMonth.Text = "" Then MsgBox("Please select last payroll month", MsgBoxStyle.Information) : cmbMonth.Focus() : Exit Sub
        If MsgBox("Do you want to Process Resinging?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        If intPrsMonth = 0 Then MsgBox("Please select last payroll month", MsgBoxStyle.Information) : cmbMonth.Focus() : Exit Sub
        If intPrsYear = 0 Then MsgBox("Please select last payroll year", MsgBoxStyle.Information) : cmbYear.Focus() : Exit Sub

        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblEmployee SET EmpStatus = 9,StatusDate = '" & Format(dtpRsDate.Value, "yyyyMMdd") & "',rReason= '" & txtSearch.Text & "' WHERE RegID = '" & StrEmployeeID & "'"
        sqlQRY = sqlQRY & " INSERT INTO tblREmpHist (RegID,RegDate,TitleID,SurName,FirstName,dispName,NICNumber,DofB,GenderID,CivilStID,EmpNo,EpfNo,CompID,DesigID,BrID,DeptID,CatID,EmpTypeID," & _
" DefAddID,homePhone,pMobile,OfficePhone,Email,CntrPeriod,ContractStart,ContractEnd,CardID,StatusDate,NoAdds,EmpStatus,NoCards,EnrolNo,AtPrType," & _
        " wrkCode, IsEmpBOT, GivenOff, confirmDate, ResDate, Res_Reason, UserID,LPrcYear,LPrcMonth) SELECT RegID,RegDate,TitleID,SurName,FirstName,dispName,NICNumber,DofB,GenderID,CivilStID,EmpNo,EpfNo,CompID,DesigID,BrID,DeptID,CatID,EmpTypeID," & _
" DefAddID,homePhone,pMobile,OfficePhone,Email,CntrPeriod,ContractStart,ContractEnd,CardID,StatusDate,NoAdds,EmpStatus,NoCards,EnrolNo,AtPrType," & _
" wrkCode,IsEmpBOT,GivenOff,confirmDate,'" & Format(dtpRsDate.Value, "yyyyMMdd") & "', '" & txtSearch.Text & "','" & StrUserID & "', " & intPrsYear & "," & intPrsMonth & " FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "'"

        bolSave = FK_EQ(sqlQRY, "S", "", False, True, True)
        If bolSave = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub dtpRsDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRsDate.ValueChanged
        cmbYear.Text = dtpRsDate.Value.Year
        cmbMonth.Text = MonthName(dtpRsDate.Value.Month)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim bolSelect As Boolean = False
        Dim iRws As Integer
        Dim RIndex As Integer
        Dim CategoryName As String
        With dgvData
            '  pgb.Maximum = .RowCount - 1
            ' pgb.Value = 0
            For iRws = 0 To .RowCount - 1
                Dim iVal As Integer = .Item(1, iRws).Value
                bolSelect = .Item(0, iRws).Value
                RIndex = .Item(1, iRws).Value
                CategoryName = .Item(2, iRws).Value
                If bolSelect = True Then
                    MsgBox(RIndex)
                    sSQL = "UPDATE tblBenefits SET tblBenefits.Status = 1,CrCancelDate = getdate(),InActivelDate=getdate(),InactiveUser= '" & StrUserID & "' WHERE tagID = '" & RIndex & "' "
                    FK_EQ(sSQL, "E", "", False, True, True)

                    sSQL = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Inactive Benefit From Employee [Reg ID : " & StrEmployeeID & "] And [Name : " & FK_Rep(StrDispName) & "] Details Inactive [Benefit Category : " & CategoryName & "]' ,'" & StrUserID & "',getdate (),'" & StrEmployeeID & "')"
                    FK_EQ(sSQL, "U", "", True, True, True)

                End If
            Next
        End With
        Load_InformationtoGrid("SELECT 'False',tblBenefits.tagID,tblSetBenefits.Descr,tblBenefits.remark FROM tblBenefits INNER JOIN tblSetBenefits ON tblBenefits.benID = tblSetBenefits.benID AND tblBenefits.Status <> 1 AND  tblBenefits.EmpID ='" & StrEmployeeID & "' ", dgvData, 4)

    End Sub
End Class