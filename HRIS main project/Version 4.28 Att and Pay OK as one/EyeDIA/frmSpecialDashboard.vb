Public Class frmSpecialDashboard

    Dim intLoad As Integer = 0
    Dim strClick As String = "Resign"
    Dim intSpliterPercentage As Integer = 2
    Dim bolSingle As Boolean = True
    Dim strComName As String
    Dim strComAddres As String
    Dim strClickID As String
    Dim dtStrat As Date
    Dim dtEnd As Date
    Dim StrTFormula As String
    Dim intNoDays As Integer
    Dim strThrough, strFrom, strCC1, strCC2 As String

    Private Sub AttendanceDashBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlAllK.Visible = False

        'Get company name and address
        sSQL = "SELECT cName,Add1 + ' ' +Add2 + ' ' + Add3 FROM tblcompany"
        fk_Return_MultyString(sSQL, 2)
        strComName = fk_ReadGRID(0)
        strComAddres = fk_ReadGRID(1)

        PreVentFlicker()
        ControlHandlers(Me)
        'CenterFormThemed(Me, pnlTopSet, Label6)
        If dtGlobalDate = "12:00:00 AM" Then
            dtGlobalDate = dtLastProcessed
        End If

        dtpFromDate.Value = DateSerial(dtGlobalDate.Year, dtGlobalDate.Month, 1)
        dtpToDate.Value = dtGlobalDate
        intLoad = 0
        ListComboAll(cmbDesign, "SELECT * FROM tblDesig WHERE Status = 0 Order By desgDesc", "desgDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0 Order By deptName", "deptName")
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By catDesc", "catDesc")
        ListComboAll(cmbBranch, "select brName from tblcBranchs WHERE Status = 0 Order By brName", "brName")
        ListComboAll(cmbThrough, "SELECT * FROM tblDesig WHERE Status = 0 Order By desgDesc", "desgDesc")
        ListComboAll(cmbFrom, "SELECT * FROM tblDesig WHERE Status = 0 Order By desgDesc", "desgDesc")
        ListComboAll(cmbCC1, "SELECT * FROM tblDesig WHERE Status = 0 Order By desgDesc", "desgDesc")
        ListComboAll(cmbCC2, "SELECT * FROM tblDesig WHERE Status = 0 Order By desgDesc", "desgDesc")
        intLoad = 1
        SplitContainer1.SplitterDistance = Me.Width / 4 * intSpliterPercentage
        Me.pnlDetail.Height = pnlBottomSet.Height
        '' ''TableLayoutPanel1.BackColor = Color.White
        '' ''TableLayoutPanel2.BackColor = Color.White
        '' ''TableLayoutPanel7.BackColor = Color.White
        '' ''TableLayoutPanel5.BackColor = Color.White

        ' '' ''Count label set font color
        '' ''lblCContractEnd.ForeColor = clrFocused
        '' ''lblCResign.ForeColor = clrFocused
        '' ''lblCBirthDay.ForeColor = clrFocused
        '' ''lblCConsecutiveAbsent.ForeColor = clrFocused
        '' ''lblCJoin.ForeColor = clrFocused
        '' ''lblCBirthday.ForeColor = clrFocused
        '' ''lblCContract.ForeColor = clrFocused
        '' ''lblCResign.ForeColor = clrFocused
        '' ''lblCJoin.ForeColor = clrFocused

        '' ''lblDepartment.ForeColor = Color.White
        '' ''lblCategory.ForeColor = Color.White
        '' ''lblDesignation.ForeColor = Color.White
        '' ''lblShuftName.ForeColor = Color.White
        '' ''lblShiftMode.ForeColor = Color.White

        '' ''lblDepartment.BackColor = clrFocused
        '' ''lblCategory.BackColor = clrFocused
        '' ''lblDesignation.BackColor = clrFocused
        '' ''lblShuftName.BackColor = clrFocused
        '' ''lblShiftMode.BackColor = clrFocused

        setProgreBars()
        'ClickedButton(pnlResignSet, Label42, lblCResign, lblPGResign)
        btnConsecutiveAbsent.Focus()
        ConsecutiveAbsentSearch()

        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=1") Then btnJoines.BackgroundImage = My.Resources.kLock : btnJoines.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=2") Then btnResign.BackgroundImage = My.Resources.kLock : btnResign.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=3") Then btnContract.BackgroundImage = My.Resources.kLock : btnContract.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=4") Then btnBirtday.BackgroundImage = My.Resources.kLock : btnBirtday.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=5") Then btnConsecutiveAbsent.BackgroundImage = My.Resources.kLock : btnConsecutiveAbsent.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=6") Then btnConsecutiveLate.BackgroundImage = My.Resources.kLock : btnConsecutiveLate.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=7") Then btnNopay.BackgroundImage = My.Resources.kLock : btnNopay.Enabled = False
        If 0 = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=8") Then btnLate.BackgroundImage = My.Resources.kLock : btnLate.Enabled = False


        ''btnBirtday.BackgroundImage = My.Resources.kLock
        ''btnBirtday.Enabled = False

        ''btnContract.BackgroundImage = My.Resources.kLock
        ''btnContract.Enabled = False

        'Load report history parameters
        cmbThrough.Text = fk_RetString("SELECT desgDesc FROM tblDesig WHERE desgID=(SELECT RIGHT('000'+CAST(isActiv AS VARCHAR(3)),3) FROM tblAdditionalOption	WHERE opID=9)")
        cmbFrom.Text = fk_RetString("SELECT desgDesc FROM tblDesig WHERE desgID=(SELECT RIGHT('000'+CAST(isActiv AS VARCHAR(3)),3) FROM tblAdditionalOption	WHERE opID=10)")
        cmbCC1.Text = fk_RetString("SELECT desgDesc FROM tblDesig WHERE desgID=(SELECT RIGHT('000'+CAST(isActiv AS VARCHAR(3)),3) FROM tblAdditionalOption	WHERE opID=11)")
        cmbCC2.Text = fk_RetString("SELECT desgDesc FROM tblDesig WHERE desgID=(SELECT RIGHT('000'+CAST(isActiv AS VARCHAR(3)),3) FROM tblAdditionalOption	WHERE opID=12)")

        pnlAllK.Visible = True
    End Sub

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub

    Private Sub ResignSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from  tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblEmployee.regID= tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvDepertment)
        Label1.Text = "Resign Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from  tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblEmployee.regID= tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvCategory)
        Label2.Text = "Resign Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from  tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblEmployee.regID= tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvDesignation)
        Label3.Text = "Resign Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblcBranchs.brName AS 'Branch Name',tblSetDept.shCode AS 'Department' from  tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblEmployee.regID= tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblcBranchs.brName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvShiftMod)
        Label5.Text = "Resign Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Shift Mode Wise Resign"

        SummaryFirstResign()
    End Sub

    Private Sub ContractEndSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.ContractEnd as 'Contracting Date', tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Contract Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Contract"

        'select regid,dispname,ContractEnd from tblEmployee where ContractEnd between '20170109' and '20170110' 
        'select deptID,count(*) from tblEmployee where ContractEnd between '20170109' and '20170110' group by deptID

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.ContractEnd as 'Contracting Date',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Contract Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Contract"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Contract Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Contract"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblcBranchs.brName AS 'Branch Name',tblSetDept.shCode AS 'Department' from  tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblcBranchs.brName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Contract Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Contract"

        SummaryFirstContractEnd()
    End Sub

    Private Sub BirthDaySearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.dOfB as 'Birth Date', tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Birthday Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.dOfB as 'Birth Date',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Birthday Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.dOfB as 'Birth Date',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Birthday Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.dOfB as 'Birth Date',tblcBranchs.brName AS 'Branch Name',tblSetDept.shCode AS 'Department' from  tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblcBranchs.brName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Birthday Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Birthday"

        SummaryFirstBirthDay()
    End Sub

    Private Sub ConsecutiveLateSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "EXEC Sp_ConsecutiveLate '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "',1" : FK_EQ(sSQL, "S", "", False, False, True)
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveLate.No_of_days AS 'Count',tblConsecutiveLate.[Late start],tblConsecutiveLate.[Late End],tblSetDept.shCode AS 'Department' from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Consecutive Late Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Consecutive Late"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveLate.No_of_days AS 'Count',tblConsecutiveLate.[Late start],tblConsecutiveLate.[Late End],tblSetEmpCategory.catDesc AS 'Category' from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Consecutive Late Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Consecutive Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveLate.No_of_days AS 'Count',tblConsecutiveLate.[Late start],tblConsecutiveLate.[Late End],tblDesig.desgDesc from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblDesig.desgDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Consecutive Late Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Consecutive Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveLate.No_of_days AS 'Count',tblConsecutiveLate.[Late start],tblConsecutiveLate.[Late End],tblcBranchs.brName from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblcBranchs.brName," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Consecutive Late Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Consecutive Late"

        SummaryFirstConsecutiveLate()
    End Sub

    Private Sub ConsecutiveAbsentSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "EXEC Sp_ConsecutiveAbsent '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "',2" : FK_EQ(sSQL, "S", "", False, False, True)
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveAbsent.No_of_days AS 'Count',tblConsecutiveAbsent.[Absent start],tblConsecutiveAbsent.[Absent End],tblSetDept.shCode AS 'Department' from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Consecutive Absent Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Consecutive Absent"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveAbsent.No_of_days AS 'Count',tblConsecutiveAbsent.[Absent start],tblConsecutiveAbsent.[Absent End],tblSetEmpCategory.catDesc AS 'Category' from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Consecutive Absent Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Consecutive Absent"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveAbsent.No_of_days AS 'Count',tblConsecutiveAbsent.[Absent start],tblConsecutiveAbsent.[Absent End],tblDesig.desgDesc from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblDesig.desgDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Consecutive Absent Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Consecutive Absent"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblConsecutiveAbsent.No_of_days AS 'Count',tblConsecutiveAbsent.[Absent start],tblConsecutiveAbsent.[Absent End],tblcBranchs.brName from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblcBranchs.brName," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Consecutive Absent Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Consecutive Absent"

        SummaryFirstConsecutiveAbsent()
    End Sub

    Private Sub JoinSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.regDate as 'Joining Date', tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Join Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Join"

        'select regid,dispname,regDate from tblEmployee where regDate between '20170109' and '20170110' 
        'select deptID,count(*) from tblEmployee where regDate between '20170109' and '20170110' group by deptID

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.regDate as 'Joining Date',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Join Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Join"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.regDate as 'Joining Date',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Join Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Join"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEmployee.regDate as 'Joining Date',tblcBranchs.brName AS 'Branch Name',tblSetDept.shCode AS 'Department' from  tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') ORDER BY tblcBranchs.brName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Join Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Join"

        SummaryFirstJoin()
    End Sub

    Private Sub BirthDaySearchOld()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND  tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetDept.deptName," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Birthday Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Birthday"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "' and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Birthday Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Birthday Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Birthday Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Shift Mode Wise Birthday"
    End Sub

    Private Sub ResignSearchold()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Resign Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Resign"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Resign Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Resign Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Resign Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Shift Mode Wise Resign"
    End Sub

    Private Sub btnResign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResign.Click
        strClick = "Resign"
        If bolSingle = True Then
            ResignSearch()
        Else
            'ResignSummary()
        End If
        ClickedButton(pnlResigntSet, lblResign, lblCResign)
    End Sub

    Private Sub ClickedButton(ByVal pnlClkd As Panel, ByVal lblText As Label, ByVal lblCount As Label)
        'pnlResignSet.BackColor = Color.Transparent
        'pnlContractEndSet.BackColor = Color.Transparent
        'pnlBirthDaySet.BackColor = Color.Transparent
        'pnlConsecutiveAbsentSet.BackColor = Color.Transparent
        'pnlJoin.BackColor = Color.Transparent
        'pnlContractSet.BackColor = Color.Transparent
        'pnlJoinSet.BackColor = Color.Transparent
        'pnlResign.BackColor = Color.Transparent
        'pnlBirthDaySET.BackColor = Color.Transparent
        pnlClkd.BackColor = clrFocused
        lblText.ForeColor = Color.OrangeRed
        lblCount.ForeColor = Color.OrangeRed
        lblCount.Text = dgvDepertment.RowCount
        'lblPercentage.ForeColor = Color.White
    End Sub

    Private Sub LostFocusButton(ByVal pnlClkd As Panel, ByVal lblText As Label, ByVal lblCount As Label)
        pnlClkd.BackColor = Color.Transparent
        lblText.ForeColor = clrFocused
        lblCount.ForeColor = clrFocused
    End Sub

    Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If intLoad = 1 Then

        'End If
        Me.Cursor = Cursors.WaitCursor
        sSQL = "delete from tAtReview; insert into tAtReview select convert (varchar(11),tblEmpRegister.atdate,106) as 'tt2'  ,tblEmployee.regid,tblEmployee.deptid,tblEmployee.catID,tblEmployee.desigID,tblEmpRegister.allShifts,case when tblEmpRegister.antstatus='1' then '1' else '0' end  as 'p'  ,case when tblEmpRegister.antstatus='0' then '1' else '0' end  as 'a',case when tblEmpRegister.isBirthDay='1' then '1' else '0' end  as 'lt' ,case when tblEmpRegister.isConsecutiveAbsent='1' then '1' else '0' end  as 'lv',0  as 'tot' FROM tblEmpRegister inner join tblemployee on tblEmpRegister.empID=tblemployee.regID where  atdate  BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' and  tblemployee.empstatus <> 9 AND tblEmployee.DeptID In  ('" & StrUserLvDept & "');"
        FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "select  convert(int,sum(p)) as Resign, convert(int,sum(lv)) as ConsecutiveAbsent, convert(int,sum(lt)) as BirthDay, convert(int,sum(a)) as ContractEnd, convert(int,count(atDate)) as Total from tAtReview,tblemployee where tAtReview.regID=tblemployee.regid and tAtReview.atdate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "')"
        fk_Return_MultyString(sSQL, 5)
        lblCContractEnd.Text = fk_ReadGRID(3).ToString().PadLeft(3, "0")
        lblCBirthDay.Text = fk_ReadGRID(2).ToString().PadLeft(3, "0")
        lblCResign.Text = fk_ReadGRID(0).ToString().PadLeft(3, "0")
        lblCConsecutiveAbsent.Text = fk_ReadGRID(1).ToString().PadLeft(3, "0")
        lblCJoin.Text = fk_ReadGRID(4).ToString().PadLeft(3, "0")


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnContractEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContract.Click
        'ResignSearch(sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 ORDER BY tblSetDept.shCode," & sqlTag1 & "")
        'Fk_FillGrid(sSQL, dgvDepertment)
        'Label1.Text = "Resign Employees : " & dgvDepertment.RowCount


        'sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        'Fk_FillGrid(sSQL, dgvCategory)
        ''SplitContainer1.SplitterDistance = Me.Width / 4 * 3
        'Label2.Text = "Resign Employees : " & dgvCategory.RowCount
        'Me.Close()
        strClick = "ContractEnd"
        If bolSingle = True Then
            ContractEndSearch()
        Else
            'ContractEndSummary()
        End If
        ClickedButton(pnlContractEndSet, lblContract, lblCContractEnd)
    End Sub

    'Private Sub cmbCat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCat.Click

    'End Sub

    'Private Sub cmbDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.Click
    '    SplitContainer1.SplitterDistance = Me.Width /4 * 4
    'End Sub

    'Private Sub cmbDesign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDesign.Click
    '    SplitContainer1.SplitterDistance = Me.Width /4 * 4
    'End Sub

    'Private Sub cmbShiftName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShiftName.Click
    'End Sub

    'Private Sub cmbShiftType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShiftType.Click
    '    SplitContainer1.SplitterDistance = Me.Width /4 * 2
    'End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 4 * intSpliterPercentage
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If

    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 4 * intSpliterPercentage
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmbDesign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesign.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 4 * intSpliterPercentage
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmbShiftName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SplitContainer1.SplitterDistance = Me.Width / 4 * 3
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmbShiftType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 4 * 3
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub btnBirthDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBirtday.Click
        strClick = "BirthDay"
        If bolSingle = True Then
            BirthDaySearch()
        Else
            'BirthDaySummary()
        End If
        ClickedButton(pnlBirthDaySet, lblBith, lblCBirthDay)
    End Sub

    Private Sub btnCrdre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoines.Click
        strClick = "Join"
        If bolSingle = True Then
            JoinSearch()
        Else
            'JoinSummary()
        End If
        ClickedButton(pnlJoin, lblJoin, lblCJoin)
    End Sub


    Private Sub cmdPrevDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dtpFromDate.Value = DateAdd(DateInterval.Day, -1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, -1, dtpToDate.Value)
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmdNextDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dtpFromDate.Value = DateAdd(DateInterval.Day, 1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        If intLoad = 1 Then
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub btnSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If pnlDetail.Height <> pnlBottomSet.Height Then
            Me.pnlDetail.Height = pnlBottomSet.Height
            bolSingle = True
            'Me.btnSummary.Text = "Summary"
        ElseIf Me.pnlDetail.Height = pnlBottomSet.Height Then
            Me.pnlDetail.Height = 0
            bolSingle = False
            'Me.btnSummary.Text = "Detaily"
            If strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSummary()
                End If
            ElseIf strClick = "ContractEnd" Then
                If bolSingle = True Then
                    ContractEndSearch()
                Else
                    'ContractEndSummary()
                End If
            ElseIf strClick = "BirthDay" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'BirthDaySummary()
                End If
            ElseIf strClick = "ConsecutiveAbsent" Then
                If bolSingle = True Then
                    ConsecutiveAbsentSearch()
                Else
                    'ConsecutiveAbsentSummary()
                End If
            ElseIf strClick = "Join" Then
                If bolSingle = True Then
                    JoinSearch()
                Else
                    'JoinSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'ResignSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'ResignSearch()
                End If
            End If
        End If
    End Sub

    Private Sub SummaryFirstResign()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' and tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblrempHist.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblrempHist,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblrempHist.RegID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblrempHist.ResDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblREmpHist.rStatus=0 AND tblEmployee.empStatus=9 and tblemployee.deptID in ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstContractEnd()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.ContractEnd BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstBirthDay()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND DATEPART(mm, DofB) = " & dtpFromDate.Value.Month & " and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstConsecutiveLate()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblcBranchs.brID=tblEmployee.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblConsecutiveLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblConsecutiveLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstExceedLate()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblcBranchs.brID=tblEmployee.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstExceedNopay()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblcBranchs.brID=tblEmployee.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstConsecutiveAbsent()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblcBranchs.brID=tblEmployee.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblConsecutiveAbsent,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblcBranchs,tblSetEmpType WHERE tblEmployee.regID=tblConsecutiveAbsent.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub SummaryFirstJoin()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblcBranchs.brName AS 'Branch Name',count(*) AS 'Total' from tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetEmpType,tblcBranchs WHERE tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblcBranchs.brID=tblEmployee.brID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tblEmployee.regDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblcBranchs.brName LIKE '" & strBranchName & "%') GROUP BY tblcBranchs.brName"
        Fk_FillGrid(sSQL, dgvSMBranch)
        For X As Integer = 0 To dgvSMBranch.Columns.Count - 1
            dgvSMBranch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMBranch)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvDepertment, dgvDepertment.ColumnCount - 1, strComName, "Department wise " & strClick & " Employees List - " & dgvDepertment.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub DgvSMDep_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSMDep.CellClick
        cmbDept.Text = Trim(DgvSMDep.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub dgvSmCat_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSmCat.CellClick
        cmbCat.Text = Trim(dgvSmCat.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub dgvSMDesg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        cmbDesign.Text = Trim(dgvSMDesg.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub dgvSMShiftM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        cmbBranch.Text = Trim(dgvSMBranch.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub setProgreBars()
        Try
            'Set Progress bar
            'pbContractEnd.Maximum = Val(lblCJoin.Text)
            'pbContractEnd.Minimum = 0
            'pbContractEnd.Value = Val(lblCContractEnd.Text)
            'lblPGContractEnd.Text = CInt(Val(lblCContractEnd.Text) / Val(lblCJoin.Text) * 100) & "%"

            'pbResign.Maximum = Val(lblCJoin.Text)
            'pbResign.Minimum = 0
            'pbResign.Value = Val(lblCResign.Text)
            'lblPGResign.Text = CInt(Val(lblCResign.Text) / Val(lblCJoin.Text) * 100) & "%"

            'pbBirthDay.Maximum = Val(lblCJoin.Text)
            'pbBirthDay.Minimum = 0
            'pbBirthDay.Value = Val(lblCBirthDay.Text)
            'lblPGBirthDay.Text = CInt(Val(lblCBirthDay.Text) / Val(lblCJoin.Text) * 100) & "%"

            'pbConsecutiveAbsent.Maximum = Val(lblCJoin.Text)
            'pbConsecutiveAbsent.Minimum = 0
            'pbConsecutiveAbsent.Value = Val(lblCConsecutiveAbsent.Text)
            'lblPGConsecutiveAbsent.Text = CInt(Val(lblCConsecutiveAbsent.Text) / Val(lblCJoin.Text) * 100) & "%"

            'pbJoin.Maximum = Val(lblCJoin.Text)
            'pbJoin.Minimum = 0
            'pbJoin.Value = Val(lblCJoin.Text)
            'lblPDJoin.Text = CInt(Val(lblCJoin.Text) / Val(lblCJoin.Text) * 100) & "%"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnResign_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResign.LostFocus
        LostFocusButton(pnlResigntSet, lblJoin, lblCResign)
    End Sub

    Private Sub btnContractEnd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContract.LostFocus
        LostFocusButton(pnlContractEndSet, lblJoin, lblCContractEnd)
    End Sub

    Private Sub btnBirthDay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBirtday.LostFocus
        LostFocusButton(pnlBirthDaySet, lblJoin, lblCBirthDay)
    End Sub

    Private Sub btnCrdre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnJoines.LostFocus
        LostFocusButton(pnlJoin, lblJoin, lblCJoin)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvCategory, dgvCategory.ColumnCount - 1, strComName, "Category wise " & strClick & " Employees List - " & dgvCategory.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvDesignation, dgvDesignation.ColumnCount - 1, strComName, "Designation wise " & strClick & " Employees List" & dgvDesignation.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvBrnch, dgvBrnch.ColumnCount - 1, strComName, "Shift Mode wise " & strClick & " Employees List - " & dgvBrnch.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub btnConsecutiveAbsent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsecutiveAbsent.LostFocus
        LostFocusButton(pnlConsecutiveAbsentSet, lblConsAbsent, lblCConsecutiveAbsent)
    End Sub

    Private Sub btnConsecutiveAbsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsecutiveAbsent.Click
        strClick = "ConsecutiveAbsent"
        If bolSingle = True Then
            ConsecutiveAbsentSearch()
        Else
            'ConsecutiveAbsentSummary()
        End If
        ClickedButton(pnlConsecutiveAbsentSet, lblConsAbsent, lblCConsecutiveAbsent)
    End Sub

    Private Sub btnConsecutiveLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsecutiveLate.Click
        strClick = "ConsecutiveLate"
        If bolSingle = True Then
            ConsecutiveLateSearch()
        Else
            'ConsecutiveAbsentSummary()
        End If
        ClickedButton(pnlConsecutiveLateSet, lblConsLate, lblCConsecutiveLate)
    End Sub

    Private Sub checkParameter()
        If cmbCC1.Text = "[ALL]" Then MessageBox.Show("Please select designation of 'CC1' person", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        If cmbCC2.Text = "[ALL]" Then MessageBox.Show("Please select designation of 'CC2' person", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        If cmbFrom.Text = "[ALL]" Then MessageBox.Show("Please select designation of 'from' person", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        If cmbThrough.Text = "[ALL]" Then MessageBox.Show("Please select designation of 'Through' person", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub setPrintPanel()
        If pnlBottomSet.Height = pnlDetail.Height Then
            pnlDetail.Height = pnlDetail.Height - 60

        ElseIf pnlDetail.Height = pnlBottomSet.Height - 60 Then
            pnlDetail.Height = pnlBottomSet.Height
        End If
    End Sub

    Private Sub dgvDepertment_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDepertment.CellDoubleClick
        CellDoubleClick(dgvDepertment)
    End Sub

    Private Sub CellDoubleClick(ByVal dgv As DataGridView)
        If strClick = "ConsecutiveAbsent" Or strClick = "ConsecutiveLate" Or strClick = "Nopay" Or strClick = "ExceedLate" Then
            strClickID = dgv.CurrentRow.Cells(0).Value
            setPrintPanel()
            StrEmployeeID = fk_RetString("SELECT RegID FROM tblEmployee WHERE " & sqlTag1 & "='" & strClickID & "'")
            dtStrat = CDate(dgv.CurrentRow.Cells(3).Value)
            dtEnd = CDate(dgv.CurrentRow.Cells(4).Value)
            intNoDays = CDbl(dgv.CurrentRow.Cells(2).Value)
            'checkParameter()

            sSQL = "DELETE FROM tblConsecutiveReport;INSERT INTO [tblConsecutiveReport] SELECT  '" & StrEmployeeID & "',tblEmployee.EmpNo,'" & Format(dtStrat, "yyyyMMdd") & "','" & Format(dtEnd, "yyyyMMdd") & "'," & intNoDays & ",'" & Format(dtpRpDate.Value, "yyyyMMdd") & "','" & cmbFrom.Text & "','" & cmbThrough.Text & "','" & cmbCC1.Text & "','" & cmbCC2.Text & "' FROM tblEmployee WHERE RegID='" & StrEmployeeID & "'" : FK_EQ(sSQL, "S", "", False, False, True)
            If strClick = "ConsecutiveAbsent" Then
                StrReportID = "092"
            ElseIf strClick = "ConsecutiveLate" Then
                StrReportID = "093"
            ElseIf strClick = "Nopay" Then
                StrReportID = "094"
            ElseIf strClick = "ExceedLate" Then
                StrReportID = "093"
            End If

            StrRpFromDate = dtStrat
            StrRpToDate = dtEnd
            mod_ReportAttendance.ReportID = StrReportID
            'RepClass.reportselecting(RepClass.ReportID)

            StrSelectionFomula = ""
            Dim frmRepCont As New frmRepContainerAttn
            frmRepCont.Show()

            If strThrough <> "" Then sSQL = "UPDATE tblAdditionalOption SET isActiv=" & strThrough & " WHERE opID=9" : FK_EQ(sSQL, "E", "", False, False, True)
            If strFrom <> "" Then sSQL = "UPDATE tblAdditionalOption SET isActiv=" & strFrom & " WHERE opID=10" : FK_EQ(sSQL, "E", "", False, False, True)
            If strCC1 <> "" Then sSQL = "UPDATE tblAdditionalOption SET isActiv=" & strCC1 & " WHERE opID=11" : FK_EQ(sSQL, "E", "", False, False, True)
            If strCC2 <> "" Then sSQL = "UPDATE tblAdditionalOption SET isActiv=" & strCC2 & " WHERE opID=12" : FK_EQ(sSQL, "E", "", False, False, True)
        End If
    End Sub

    Private Sub dgvBrnch_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBrnch.CellDoubleClick
        CellDoubleClick(dgvBrnch)
    End Sub

    Private Sub dgvCategory_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategory.CellDoubleClick
        CellDoubleClick(dgvCategory)
    End Sub

    Private Sub dgvDesignation_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDesignation.CellDoubleClick
        CellDoubleClick(dgvDesignation)
    End Sub

    Private Sub dgvBrnch_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvBrnch.MouseClick, dgvCategory.MouseClick, dgvDepertment.MouseClick, dgvDesignation.MouseClick
        If e.Button = MouseButtons.Right Then
            setPrintPanel()
        End If
    End Sub

    Private Sub cmdReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReport.Click
        setPrintPanel()
    End Sub

    Private Sub btnNopay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNopay.Click
        strClick = "Nopay"
        If bolSingle = True Then
            NopaySearch()
        Else
            'ConsecutiveAbsentSummary()
        End If
        ClickedButton(pnlNopaySet, lblNopay, lblCNopay)
    End Sub

    Private Sub NopaySearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "EXEC Sp_ExceedNopay '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "',2" : FK_EQ(sSQL, "S", "", False, False, True)
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedNopay.No_of_days AS 'Count',tblCountExceedNopay.[Range Start],tblCountExceedNopay.[Range End],tblSetDept.shCode AS 'Department' from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Nopay Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Nopay"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedNopay.No_of_days AS 'Count',tblCountExceedNopay.[Range Start],tblCountExceedNopay.[Range End],tblSetEmpCategory.catDesc AS 'Category' from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Nopay Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Nopay"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedNopay.No_of_days AS 'Count',tblCountExceedNopay.[Range Start],tblCountExceedNopay.[Range End],tblDesig.desgDesc from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblDesig.desgDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Nopay Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Nopay"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedNopay.No_of_days AS 'Count',tblCountExceedNopay.[Range Start],tblCountExceedNopay.[Range End],tblcBranchs.brName from tblCountExceedNopay,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedNopay.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblcBranchs.brName," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Nopay Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Nopay"

        SummaryFirstExceedNopay()
    End Sub

    Private Sub btnLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLate.Click
        strClick = "ExceedLate"
        If bolSingle = True Then
            ExceedLateSearch()
        Else
            'ConsecutiveAbsentSummary()
        End If
        ClickedButton(pnlLateSet, lblLate, lblCLate)
    End Sub

    Private Sub ExceedLateSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", FK_GetIDR(cmbBranch.Text))

        sSQL = "EXEC Sp_ExceedLate '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "',2" : FK_EQ(sSQL, "S", "", False, False, True)
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedLate.No_of_days AS 'Count',tblCountExceedLate.[Range Start],tblCountExceedLate.[Range End],tblSetDept.shCode AS 'Department' from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Late Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Late"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedLate.No_of_days AS 'Count',tblCountExceedLate.[Range Start],tblCountExceedLate.[Range End],tblSetEmpCategory.catDesc AS 'Category' from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Late Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedLate.No_of_days AS 'Count',tblCountExceedLate.[Range Start],tblCountExceedLate.[Range End],tblDesig.desgDesc from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblDesig.desgDesc," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Late Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCountExceedLate.No_of_days AS 'Count',tblCountExceedLate.[Range Start],tblCountExceedLate.[Range End],tblcBranchs.brName from tblCountExceedLate,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblCBranchs WHERE tblEmployee.regID=tblCountExceedLate.EmpID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblEmployee.brID=tblCBranchs.brID AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%'  AND tblCbranchs.brName LIKE '" & strBranchName & "%')  ORDER BY tblcBranchs.brName," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvBrnch)
        For X As Integer = 0 To dgvBrnch.Columns.Count - 1
            dgvBrnch.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvBrnch)
        Label5.Text = "Late Employees : " & dgvBrnch.RowCount
        lblShiftMode.Text = "Branch Wise Late"

        SummaryFirstExceedLate()
    End Sub

    Private Sub btnConsecutiveLate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsecutiveLate.LostFocus
        LostFocusButton(pnlConsecutiveLateSet, lblJoin, lblCConsecutiveLate)
    End Sub

    Private Sub btnLate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLate.LostFocus
        LostFocusButton(pnlLateSet, lblJoin, lblCLate)
    End Sub

    Private Sub btnNopay_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNopay.LostFocus
        LostFocusButton(pnlNopaySet, lblJoin, lblCNopay)
    End Sub

    Private Sub cmbThrough_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThrough.SelectedIndexChanged
        strThrough = fk_RetString("SELECT desgID FROM tblDesig WHERE desgDesc='" & cmbThrough.Text & "'")
    End Sub

    Private Sub cmbFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFrom.SelectedIndexChanged
        strFrom = fk_RetString("SELECT desgID FROM tblDesig WHERE desgDesc='" & cmbFrom.Text & "'")
    End Sub

    Private Sub cmbCC1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCC1.SelectedIndexChanged
        strCC1 = fk_RetString("SELECT desgID FROM tblDesig WHERE desgDesc='" & cmbCC1.Text & "'")
    End Sub

    Private Sub cmbCC2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCC2.SelectedIndexChanged
        strCC2 = fk_RetString("SELECT desgID FROM tblDesig WHERE desgDesc='" & cmbCC2.Text & "'")
    End Sub

    Private Sub MoonthDateAdjuest(ByVal ClickCrMonth As Integer)
        Dim NextMonth As Integer
        Dim iNextYear
        Dim cYear As Integer = Date.Today.Year
        If ClickCrMonth < 12 Then
            NextMonth = ClickCrMonth + 1
            iNextYear = cYear
        Else
            NextMonth = 1
            iNextYear = cYear + 1
        End If
        Dim AtnPrcDate As DateTime = fk_RetString("select AtnPrcDate from tblcompany")
        Dim StartDay As Integer = fk_RetString("SELECT StartDay FROM  tblcompany")
        Dim fromDate As DateTime = ClickCrMonth & "/" & StartDay & "/" & cYear
        Dim toDate As DateTime = NextMonth & "/" & StartDay & "/" & iNextYear

        dtpFromDate.Value = fromDate
        dtpToDate.Value = toDate.AddDays(-1)
        'End If

    End Sub


    Private Sub lblMonth1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth1.Click
        MoonthDateAdjuest(1)
    End Sub

    Private Sub lblMonth2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth2.Click
        MoonthDateAdjuest(2)
    End Sub

    Private Sub lblMonth3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth3.Click
        MoonthDateAdjuest(3)
    End Sub

    Private Sub lblMonth4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth4.Click
        MoonthDateAdjuest(4)
    End Sub

    Private Sub lblMonth5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth5.Click
        MoonthDateAdjuest(5)
    End Sub

    Private Sub lblMonth6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth6.Click
        MoonthDateAdjuest(6)
    End Sub

    Private Sub lblMonth7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth7.Click
        MoonthDateAdjuest(7)
    End Sub

    Private Sub lblMonth8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth8.Click
        MoonthDateAdjuest(8)
    End Sub

    Private Sub lblMonth9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth9.Click
        MoonthDateAdjuest(9)
    End Sub

    Private Sub lblMonth10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth10.Click
        MoonthDateAdjuest(10)
    End Sub

    Private Sub lblMonth11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth11.Click
        MoonthDateAdjuest(11)
    End Sub

    Private Sub lblMonth12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMonth12.Click
        MoonthDateAdjuest(12)
    End Sub

End Class