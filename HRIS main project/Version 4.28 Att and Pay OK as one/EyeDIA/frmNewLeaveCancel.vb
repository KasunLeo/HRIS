Imports System.Data.SqlClient

Public Class frmNewLeaveCancel

    'Dim dgvLvD As DataGridView
    Dim intExsixted As Integer = 0
    Dim intSelectedYear As Integer = 0
    Dim StrAllSelect As String
    Dim MaxmunMonthEndDate As DateTime

    Private Sub frmNewLeaveCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, pnlTopone, Label16)
        ControlHandlers(Me)

        If strKEmployeeID <> "" Then
            StrEmployeeID = strKEmployeeID
            pb_ShowEmployee(StrEmployeeID)
        Else
            cmdRefresh_Click(sender, e)
        End If
        intExsixted = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE compID='001'")
        'intSelectedYear = intExsixted
        pnlBottom.Height = 1

        DateTimePickerMinDateControl()
    End Sub


    Private Sub DateTimePickerMinDateControl()
        '2018-08-03 DateTimePicker MinDate Control -prasanna
        Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")
        Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lAttendance = 1  )")

        MaxmunMonthEndDate = New DateTime(maxYear, maxMonth, 1).AddDays(-1)
        'dtpFD.MinDate = New DateTime(maxYear, maxMonth, 1).AddMonths(1)
        'dtpToD.MinDate = New DateTime(maxYear, maxMonth, 1).AddMonths(1)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim dtLastDate As DateTime = DateAdd(DateInterval.Month, -3, dtWorkingDate)

        If UserLevelID = "000" Then
            dtLastDate = DateAdd(DateInterval.Month, -6, dtWorkingDate)
        End If
        sSQL = "SELECT DISTINCT tblLeaveTRH.rqID,tblLeaveTRH.EmpID,tblEmployee.EMPNo as 'Emp No',tblEmployee.dispName AS 'Employee Name', tblLeaveTRH.RqDate AS 'Request Date',tblleavetype.lvdesc AS 'Leave Type',tblLeaveTRH.NoLveS AS 'Leave Count',tblCBranchs.brName AS 'Branch Name',tblLeaveTRH.remark AS 'Remark', tblSetEmpType.tDesc AS 'Employee Type',tblSetDept.DeptName AS 'Department' FROM tblLeaveTRH LEFT OUTER JOIN tblLeaveTRD ON tblLeaveTRH.RqID=tblLeaveTRD.RqID AND tblLeaveTRH.EmpID=tblLeaveTRD.EmpID LEFT OUTER JOIN tblEmployee ON tblEmployee.RegID= tblLeaveTRH.EmpID LEFT OUTER JOIN dbo.tblleavetype ON dbo.tblleavetype.lvID=dbo.tblLeaveTRH.lvID  LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID  LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  WHERE tblLeaveTRH.status=0 AND dbo.tblEmployee.empStatus=1  AND tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblLeaveTRD.LvDate > '" & Format(dtLastDate, "yyyyMMdd") & "' ORDER BY tblLeaveTRH.rqID"
        Fk_FillGrid(sSQL, dgvLeave)
        dgvLeave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        clr_Grid(dgvLeave)
        lblCount.Text = "Total Rows : " & dgvLeave.RowCount

        'dgvLvD = New DataGridView
        'With dgvLvD
        '    .Columns.Clear()
        '    .Columns.Add("EmpID", "EmpID")
        '    .Columns.Add("Lvdate", "LvDate")
        '    .Columns.Add("LvType", "LvType")
        '    .Columns.Add("NoLv", "NoLv")
        'End With
        pnlLeaveD.Height = 1
    End Sub

    Public Sub pb_ShowEmployee(ByVal StrEmployeeID)
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.empNo,tblEmployee.NICNumber,tblSetDept.DeptName,tblDesig.desgdesc,tblCBranchs.brName, tblSEtEmpCategory.catDesc, tblemployee.epfno,tblemployee.EnrolNo  FROM tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID  LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID  LEFT OUTER JOIN dbo.tblSetTitle ON dbo.tblSetTitle.titleID=dbo.tblemployee.TitleID LEFT OUTER JOIN dbo.tblSEtEmpCategory ON dbo.tblSEtEmpCategory.CatID=dbo.tblEmployee.CatID  where tblEmployee.CompID = '" & StrCompID & "' and tblEmployee.empstatus=1 and tblEmployee.regID='" & StrEmployeeID & "' "

        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtEmpID.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                txtDispNam.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                txtCategory.Text = IIf(IsDBNull(drShw.Item("catDesc")), "", drShw.Item("catDesc"))
                txtDepart.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))
                txtEMPNo.Text = IIf(IsDBNull(drShw.Item("empNo")), "", drShw.Item("empNo"))
                txtEpfNo.Text = IIf(IsDBNull(drShw.Item("epfNo")), "", drShw.Item("epfNo"))
                txtBran.Text = IIf(IsDBNull(drShw.Item("brName")), "", drShw.Item("brName"))
                txtDesignation.Text = IIf(IsDBNull(drShw.Item("desgdesc")), "", drShw.Item("desgdesc"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try


        '' leave cancle limit date -- prasanna 2018-0806
        'Dim maxMonth As Integer = fk_RetString(" SELECT CASE WHEN max(month)  Is null THEN 1  ELSE max(month) END  FROM tblAttMonthEnd WHERE  Id =(SELECT MAX(ID) FROM tblAttMonthEnd WHERE lLeaveApply = 1  )")
        'Dim maxYear As Integer = fk_RetString("SELECT CASE WHEN max(year)  Is null THEN 2000  ELSE max(year) END  FROM tblAttMonthEnd WHERE  Id = (SELECT MAX(ID) FROM tblAttMonthEnd WHERE lLeaveApply = 1  )")
        'Dim dateLimitEdit As DateTime = New Date(maxYear, maxMonth, 1)

        'Dim LeaveShowdays As Integer = DateDiff(DateInterval.Day, dateLimitEdit, dtLastProcessed)

        'Dim dtLastDate As DateTime = DateAdd(DateInterval.Day, -LeaveShowdays, dtWorkingDate)

        Dim dtLastDate As DateTime = DateAdd(DateInterval.Month, -6, dtWorkingDate)
        If UserLevelID = "000" Then
            dtLastDate = DateAdd(DateInterval.Month, -12, dtWorkingDate)
        End If

        sSQL = "SELECT DISTINCT tblLeaveTRH.rqID,tblLeaveTRH.EmpID,tblEmployee.EMPNo as 'Emp No',tblEmployee.dispName AS 'Employee Name', tblLeaveTRH.RqDate AS 'Request Date',tblleavetype.lvdesc AS 'Leave Type',tblLeaveTRH.NoLveS AS 'Leave Count',tblCBranchs.brName AS 'Branch Name',tblLeaveTRH.remark AS 'Remark', tblSetEmpType.tDesc AS 'Employee Type',tblSetDept.DeptName AS 'Department' FROM tblLeaveTRH LEFT OUTER JOIN tblLeaveTRD ON tblLeaveTRH.RqID=tblLeaveTRD.RqID AND tblLeaveTRH.EmpID=tblLeaveTRD.EmpID LEFT OUTER JOIN tblEmployee ON tblEmployee.RegID= tblLeaveTRH.EmpID LEFT OUTER JOIN dbo.tblleavetype ON dbo.tblleavetype.lvID=dbo.tblLeaveTRH.lvID  LEFT OUTER JOIN dbo.tblSetEmpType ON dbo.tblSetEmpType.TypeID=dbo.tblEmployee.EmpTypeID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblCBranchs.BrID=dbo.tblEmployee.BrID  LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  WHERE tblLeaveTRH.status=0 AND tblEmployee.regID='" & StrEmployeeID & "' AND dbo.tblEmployee.empStatus=1  AND tblLeaveTRD.LvDate > '" & Format(dtLastDate, "yyyyMMdd") & "' ORDER BY tblLeaveTRH.rqID"
        Fk_FillGrid(sSQL, dgvLeave)
        dgvLeave.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        clr_Grid(dgvLeave)
        lblCount.Text = "Total Rows : " & dgvLeave.RowCount

    End Sub

    Private Sub cmdBrsC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsC.Click
        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc,dbo.tblEmployee.epfNo,dbo.tblEmployee.empNo " & _
       "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
       "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 AND tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then
                StrEmployeeID = StrEmployeeID
                pb_ShowEmployee(StrEmployeeID)

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try
    End Sub

    ' Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    'sSQL = "DROP TABLE tblKPay;" : FK_EQ(sSQL, "P", "", False, False, False)
    'sSQL = "CREATE TABLE tblKPay ([RegID] [nvarchar](10) NULL,[EmpNo] [nvarchar](10) NULL,[EpfNo] [nvarchar](10) NULL,[EnrolNo] [numeric](18, 0) NOT NULL,[RegDate] [datetime] NULL,[dispName] [nvarchar](60) NULL,[NICNumber] [nvarchar](10) NULL,[DofB] [datetime] NULL,[homePhone] [nvarchar](12) NULL,[pMobile] [nvarchar](12) NULL,[OfficePhone] [nvarchar](12) NULL,[Email] [nvarchar](40) NULL,[stDesc] [nvarchar](20) NULL,[GenDesc] [nvarchar](10) NULL,[desgDesc] [nvarchar](30) NULL,[DeptName] [nvarchar](50) NULL,[tDesc] [nvarchar](30) NULL,[BasicSalary] [numeric](18, 2) NULL,[Oldness in Days] [int] NULL) ; INSERT INTO tblKPay SELECT    dbo.tblEmployee.RegID,dbo.tblEmployee.EmpNo, dbo.tblEmployee.EpfNo, dbo.tblEmployee.EnrolNo, dbo.tblEmployee.RegDate, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.DofB,  dbo.tblEmployee.homePhone, dbo.tblEmployee.pMobile, dbo.tblEmployee.OfficePhone, dbo.tblEmployee.Email, dbo.tblCivilStatus.stDesc, dbo.tblGender.GenDesc, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblSetEmpType.tDesc, dbo.tblPayrollEmployee.BasicSalary,datediff(day,tblEmployee.RegDate,getdate ()) as 'Oldness in Days' FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblCivilStatus ON dbo.tblEmployee.CivilStID = dbo.tblCivilStatus.StID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER  JOIN dbo.tblGender ON dbo.tblEmployee.GenderID = dbo.tblGender.GenID LEFT OUTER  JOIN dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER  JOIN  dbo.tblSetEmpType ON dbo.tblEmployee.EmpTypeID = dbo.tblSetEmpType.TypeID LEFT OUTER  JOIN dbo.tblPayrollEmployee ON dbo.tblEmployee.RegID = dbo.tblPayrollEmployee.RegID WHERE tblEmployee.compID = '001' AND tblEmployee.empStatus <> 9 " : FK_EQ(sSQL, "P", "", False, False, True)
    ''tblAttBasedIndiFixedField
    'sSQL = "SELECT DISTINCT tblSalaryItems.DESCRIPTION + '_' + tblAttBasedIndiFixedField.salID,''  FROM tblAttBasedIndiFixedField INNER JOIN  tblSalaryItems ON tblSalaryItems.ID=tblAttBasedIndiFixedField.salID"
    'Load_InformationtoGrid(sSQL, dgvColumn, 2)
    'sSQL = ""
    'For i As Integer = 0 To dgvColumn.RowCount - 1
    '    ssql1 = Replace(Trim(dgvColumn.Item(0, i).Value.ToString), " ", "")
    '    sSQL = sSQL & "ALTER TABLE tblKPay ADD " & ssql1 & " NUMERIC (18,2) NOT NULL DEFAULT 0;"
    'Next
    'FK_EQ(sSQL, "P", "", False, False, False)

    'For i As Integer = 0 To dgvColumn.RowCount - 1
    '    ssql1 = Replace(Trim(dgvColumn.Item(0, i).Value.ToString), " ", "")
    '    sSQL = sSQL & "UPDATE tblKPay SET tblKPay." & ssql1 & "=tblAttBasedIndiFixedField.Amount FROM tblKPay,tblAttBasedIndiFixedField WHERE tblKPay.RegID=tblAttBasedIndiFixedField.RegID "
    'Next
    'FK_EQ(sSQL, "P", "", False, False, False)
    ''tblIndiFixedFields
    'sSQL = "SELECT DISTINCT tblSalaryItems.DESCRIPTION + '_' + tblIndiFixedFields.salID,''  FROM tblIndiFixedFields INNER JOIN  tblSalaryItems ON tblSalaryItems.ID=tblIndiFixedFields.salID"
    'Load_InformationtoGridNoClr(sSQL, dgvColumn, 2)

    'sSQL = ""
    'For i As Integer = 0 To dgvColumn.RowCount - 1
    '    ssql1 = Replace(Trim(dgvColumn.Item(0, i).Value.ToString), " ", "")
    '    sSQL = sSQL & "ALTER TABLE tblKPay ADD " & ssql1 & " NUMERIC (18,2) NOT NULL DEFAULT 0;"
    'Next
    'FK_EQ(sSQL, "P", "", False, False, True)

    'sSQL = ""
    'For i As Integer = 0 To dgvColumn.RowCount - 1
    '    ssql1 = Replace(Trim(dgvColumn.Item(0, i).Value.ToString), " ", "")
    '    sSQL = sSQL & " UPDATE tblKPay SET tblKPay." & ssql1 & "=tblIndiFixedFields.Amount FROM tblKPay,tblIndiFixedFields WHERE tblKPay.RegID=tblIndiFixedFields.RegID "
    'Next
    'FK_EQ(sSQL, "P", "", False, False, True)

    'sSQL = "SELECT * FROM tblKPay"
    'Fk_FillGrid(sSQL, dgvLeave)
    'clr_Grid(dgvLeave)
    'End Sub

    Private Sub dgvLeave_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLeave.CellDoubleClick


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'StrLeavSearchID = ""
        'Dim frmNewLeave As New frmNewLeaveSearch
        'frmNewLeave.ShowDialog()
        'If StrLeavSearchID = "" Then
        '    Exit Sub
        'End If
        'Show information to the text boxes
        'Dim cnShw As New SqlConnection(sqlConString)
        'cnShw.Open()
        'Dim sqlQRY As String = "SELECT * FROM tblLeaveTRH WHERE rqID = '" & StrLeavSearchID & "' AND EmpID = '" & StrEmployeeID & "'"

        'Try
        '    Dim cmOpn As New SqlCommand(sqlQRY, cnShw)
        '    Dim drOPn As SqlDataReader = cmOpn.ExecuteReader
        '    If drOPn.Read = True Then
        '        txtLeaveID.Text = StrLeavSearchID
        '        DTPfrom.Value = IIf(IsDBNull(drOPn.Item("frDate")), DateSerial(1900, 1, 1), drOPn.Item("frDate"))
        '        txtLvFrm.Text = DTPfrom.Value
        '        DTPto.Value = IIf(IsDBNull(drOPn.Item("clsDate")), DateSerial(1900, 1, 1), drOPn.Item("clsDate"))
        '        txtLvTo.Text = DTPto.Value
        '        txtLeaveCount.Text = IIf(IsDBNull(drOPn.Item("NoLves")), "0", drOPn.Item("NoLves"))

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnShw.Close()
        'End Try

        'Load_InformationtoGrid("select EmpID,LvDate,LvType,NoLeave FROM tblLeaveTRD WHERE RqID  ='" & txtLeaveID.Text & "'", dgvLvD, 4)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtEmpID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpID.Leave
        txtEmpID.ReadOnly = True
    End Sub

    Private Sub txtEmpID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpID.TextChanged

        'If txtEmpID.Text = "" Then
        '    txtEmpName.Text = ""
        '    txtDep.Text = ""
        '    dgvEmp.Visible = False
        'End If
        'Compan Is Epf astat s
        'Dim intISEpf As Integer = fk_sqlDbl("SELECT isEpf FROM tblCompany")

        'If txtEmpID.Text.Length >= 6 Then
        '    Dim intNos As Integer = fk_sqlDbl("SELECT count(*) FROM tblEmployee WHERE RegID = '" & txtEmpID.Text & "' AND EmpStatus = 1")
        '    If intNos > 1 Then
        '        dgvEmp.Visible = True
        '        Dim sqlQ As String = "SELECT RegID ,EpfNo,dispName from tblEmployee WHERE RegID = '" & txtEmpID.Text & "' AND EmpStatus = 1"
        '        Load_InformationtoGrid(sqlQ, dgvEmp, 3)
        '        dgvEmp.Focus()
        '    Else
        '        Dim sqlQry1 As String = "SELECT RegID FROM tblEmployee Where RegID = '" & txtEmpID.Text & "' AND EmpStatus = 1"
        '        StrEmployeeID = fk_RetString(sqlQry1)

        '        Dim cnShw As New SqlConnection(sqlConString)
        '        cnShw.Open()
        '        Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblEmployee.EpfNo " & _
        '        " FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        '        Try
        '            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
        '            Dim drShw As SqlDataReader = cmShw.ExecuteReader
        '            If drShw.Read Then
        '                txtEmpID.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
        '                txtEmpName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
        '                txtDep.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))

        '            End If

        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        Finally
        '            cnShw.Close()
        '        End Try
        '    End If

        '    'dgvEmp.Visible = False
        'End If

    End Sub

    Private Sub dgvEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEmp.Click

        'If .RowCount <= 0 Then Exit Sub
        'StrEmployeeID = .Item(0, .CurrentRow.Index).Value

        'Dim cnShw As New SqlConnection(sqlConString)
        'cnShw.Open()
        'Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblEmployee.EpfNo " & _
        '" FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        'Try
        '    Dim cmShw As New SqlCommand(sqlQRY, cnShw)
        '    Dim drShw As SqlDataReader = cmShw.ExecuteReader
        '    If drShw.Read Then
        '        txtEmpID.Text = IIf(IsDBNull(drShw.Item("EpfNo")), "", drShw.Item("EpfNo"))
        '        txtEmpName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
        '        txtDep.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))

        '    End If
        '    dgvEmp.Visible = False
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnShw.Close()
        'End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub dgvLeave_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLeave.CellClick
        'Veiw all leave days from tblLeaveTRD at one time Kasun K01 - 2018-06-09
        pnlLeaveD.Height = 177
        StrLeavSearchID = Trim(dgvLeave.CurrentRow.Cells(0).Value)
        StrEmployeeID = Trim(dgvLeave.CurrentRow.Cells(1).Value)

        sSQL = "EXEC spLeaveData '" & StrLeavSearchID & "'"
        Load_InformationtoGrid(sSQL, dgvLeaveD, 12)
    End Sub

    Private Sub btnSav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSav.Click
        Dim dr As DialogResult = MessageBox.Show("Do you really want to cancel all the leave(s) under this application number", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If dr = Windows.Forms.DialogResult.No Then Exit Sub
        StrLeavSearchID = Trim(dgvLeave.CurrentRow.Cells(0).Value)
        StrEmployeeID = Trim(dgvLeave.CurrentRow.Cells(1).Value)

        Dim StrLvID As String '= fk_RetString("SELECT LvType FROM tblLeaveTRD WHERE rqID = '" & StrLeavSearchID & "' AND EmpID = '" & StrEmployeeID & "'")
        Dim dblNoLeave As Double
        Dim intLvMin As Integer
        fk_Return_MultyString("SELECT NoLves,LvID,LvMin FROM tblLeaveTRH WHERE rqID = '" & StrLeavSearchID & "' AND EmpID = '" & StrEmployeeID & "'", 3)
        dblNoLeave = fk_ReadGRID(0) : StrLvID = fk_ReadGRID(1) : intLvMin = fk_ReadGRID(2)

        sSQL = "select EmpID,LvDate,LvType,NoLeave FROM tblLeaveTRD WHERE RqID  ='" & StrLeavSearchID & "'"
        Load_InformationtoGrid(sSQL, dgvLvD, 4)

        '20180817 prasanna After month End Can't Apply Leave  preview days  
        If UserLevelID <> "000" Then
            With dgvLeaveD
                For i As Integer = 0 To .RowCount - 1
                    If .Item(3, i).Value <= MaxmunMonthEndDate Then
                        MsgBox("Can't Cancel Leaves  : Your Last Month ('" & MaxmunMonthEndDate & "') Is Over  ", MsgBoxStyle.Critical) : Exit Sub
                    End If
                Next
            End With
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""
        Try

            sqlQRY = "INSERT INTO [tblLvCancel] ([RqID],[EmpID],[CanCelDate],[Remarks],cncUser) VALUES ('" & StrLeavSearchID & "','" & StrEmployeeID & "', getdate(),'','" & StrUserID & "')"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "UPDATE tblCompany SET LVCancel = LVCancel + 1 WHERE CompID = '" & StrCompID & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            sqlQRY = "UPDATE [tblLeaveTRH] SET [Status] ='" & 1 & "' WHERE [RqID] = '" & StrLeavSearchID & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Update EmpRegister Leave Balance to Normal Status when Cancelling Leave 

            Dim dblLvCount As Double = 0
            Dim dtpLvDate As Date = DateSerial(1900, 1, 1)
            Dim intIsLate As Integer : Dim intIsEarly As Integer : Dim strExLeStatInEmpReg As String : Dim strLEStat As String

            With dgvLeaveD
                For i As Integer = 0 To .RowCount - 1
                    dblLvCount = CDbl(.Item(9, i).Value)
                    dtpLvDate = CDate(.Item(3, i).Value)
                    'if intisLate=1 then it covered the late
                    If Trim(.Item(5, i).Value) = "Yes" Then
                        intIsLate = 1
                    Else
                        intIsLate = 0
                    End If

                    'if intIsEarly=1 then it covered early
                    If Trim(.Item(7, i).Value) = "Yes" Then
                        intIsEarly = 1
                    Else
                        intIsEarly = 0
                    End If
                    'Check for leave applied days for both late and early Kasun K01 - 2018-06-09
                    strExLeStatInEmpReg = (.Item(11, i).Value.ToString)
                    Dim strNewLEStatus As String = ""
                    If strExLeStatInEmpReg = "1|1" Then
                        If intIsLate = 1 And intIsEarly = 1 Then
                            strNewLEStatus = "0|0"
                        ElseIf intIsLate = 1 And intIsEarly = 0 Then
                            strNewLEStatus = "0|1"
                        ElseIf intIsLate = 0 And intIsEarly = 1 Then
                            strNewLEStatus = "1|0"
                        End If
                    Else
                        strNewLEStatus = "0|0"
                    End If

                    Dim strLateEarly As String = ""
                    'update late and early based on LEStatus and isLeave/isEarly
                    If intIsLate = 1 And intIsEarly = 0 Then
                        strLateEarly = "isLate=" & intIsLate & ""
                    ElseIf intIsLate = 0 And intIsEarly = 1 Then
                        strLateEarly = "isEarly=" & intIsEarly & ""
                    Else
                        strLateEarly = "isLate=" & intIsLate & ",isEarly=" & intIsEarly & ""
                    End If

                    'check for same day double leave
                    Dim intLvCountForDay As Integer = 0
                    ' sSQL = "SELECT COUNT(LvDate) FROM tblLeaveTRD WHERE LvDate='" & dtpLvDate & "' AND EmpID='" & StrEmployeeID & "' AND status=0 group by empID,lvDate"
                    ' intLvCountForDay = fk_sqlDbl(sSQL)

                    Dim strCloseLeve As String = ""
                    If intLvCountForDay <= 1 Then
                        strCloseLeve = ",[IsLeave] = 0,[LeaveID] = ''"
                    End If
                    'changed Kasun K01 - 2018-06-09 
                    sqlQRY = "UPDATE [tblEmpRegister] SET NoLeave=CASE WHEN NoLeave- " & dblLvCount & "<0 THEN 0 ELSE NoLeave- " & dblLvCount & " END ,LEStatus='" & strNewLEStatus & "', " & strLateEarly & " " & strCloseLeve & "  WHERE [EmpID] ='" & StrEmployeeID & "' AND [AtDate] = '" & Format(dtpLvDate, "yyyyMMdd") & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'UPDATE tblLeaveTRD table --LEStatus ='0|0' Kasun K01 - 2018-06-09
                    sqlQRY = "UPDATE [tblLeaveTRD] SET [status] = '1' WHERE [EmpID] ='" & StrEmployeeID & "' AND [lvDate] = '" & Format(dtpLvDate, "yyyyMMdd") & "' AND [RqID]='" & StrLeavSearchID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                Next
            End With

            If StrShortSumLvID = StrLvID And intLvMin <> 0 Then
                'Update taken short leave
                sqlQRY = sqlQRY & " UPDATE tblEmpShortLeaveD SET usedMins = usedMins - " & CDbl(intLvMin) & ",balMin=balMin+" & CDbl(intLvMin) & ",usedQty=usedQty-" & CDbl(dblNoLeave) & ",balQty=balQty+" & CDbl(dblNoLeave) & " WHERE EmpID = '" & StrEmployeeID & "' AND cYear = " & dtpLvDate.Year & " AND cMonth=" & dtpLvDate.Month & ""
                cmSave.CommandText = sqlQRY
                cmSave.ExecuteNonQuery()
            End If
            sqlQRY = "UPDATE [tblEmpLeaveD]   SET [TakenLeave] = TakenLeave-" & CDbl(dblNoLeave) & " WHERE [EmpID] ='" & StrEmployeeID & "' and [CompID] ='" & StrCompID & "' and [cYear] =" & dtpLvDate.Year & " and [LeaveID]= '" & StrLvID & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()


            trSave.Commit()
            MsgBox("Information Saved", MsgBoxStyle.Information)
            cmdRefresh_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try
    End Sub

End Class
