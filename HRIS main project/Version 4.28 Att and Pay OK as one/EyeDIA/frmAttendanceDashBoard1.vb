Public Class frmAttendanceDashBoard1

    Dim intLoad As Integer = 0
    Dim strClick As String = "Present"
    Dim intSpliterPercentage As Integer = 3
    Dim bolSingle As Boolean = True
    Dim strComName As String
    Dim strComAddres As String

    Private Sub AttendanceDashBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlAllK.Visible = False
        strClick = frmMainAttendance.strGridStatus
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

        dtpFromDate.Value = dtGlobalDate
        dtpToDate.Value = dtGlobalDate
        intLoad = 0
        ListComboAll(cmbDesign, "SELECT * FROM tblDesig WHERE Status = 0 Order By desgDesc", "desgDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0 Order By deptName", "deptName")
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By catDesc", "catDesc")
        ListComboAll(cmbShiftName, "select * From tblSEtShiftH WHERE Status = 0 Order By shiftName", "shiftName")
        ListComboAll(cmbShiftType, "select CASE WHEN shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'shiftMode' From tblSEtShiftH WHERE Status = 0 Order By shiftID", "shiftMode")
        intLoad = 1
        SplitContainer1.SplitterDistance = Me.Width / 5 * intSpliterPercentage
        Me.pnlDetail.Height = pnlBottomSet.Height
        '' ''TableLayoutPanel1.BackColor = Color.White
        '' ''TableLayoutPanel2.BackColor = Color.White
        '' ''TableLayoutPanel7.BackColor = Color.White
        '' ''TableLayoutPanel5.BackColor = Color.White

        setProgreBars()
        'ClickedButton(pnlPresentSet, Label42, lblCPresent, lblPGPresent)
        'btnPresent.Focus()
        'presentSearch()
        'PreVentFlicker()
        pnlAllK.Visible = True


        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
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

    Private Sub presentSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvDepertment)
        Label1.Text = "Present Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Present"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvCategory)
        Label2.Text = "Present Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Present"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvDesignation)
        Label3.Text = "Present Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Present"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetShifth.shiftName AS 'Shift Name',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvShift)
        Label4.Text = "Present Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Present"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        'clr_Grid(dgvShiftMod)
        Label5.Text = "Present Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Present"
        SummaryFirstPresent()
    End Sub

    Private Sub AbsentSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Absent Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Absent"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Absent Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Absent"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Absent Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Absent"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetShifth.shiftName AS 'Shift Name',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShift)
        Label4.Text = "Absent Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Absent"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShiftMod)
        Label5.Text = "Absent Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Absent"

        SummaryFirstAbsent()
    End Sub

    Private Sub LateSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Late Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Late"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Late Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Late Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetShifth.shiftName AS 'Shift Name',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShift)
        Label4.Text = "Late Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Late"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShiftMod)
        Label5.Text = "Late Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Late"

        SummaryFirstLate()
    End Sub

    Private Sub LeaveSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Leave Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Leave"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Leave Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Leave"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Leave Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Leave"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetShifth.shiftName AS 'Shift Name',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShift)
        Label4.Text = "Leave Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Leave"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND Lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShiftMod)
        Label5.Text = "Leave Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Leave"

        SummaryFirstLeave()
    End Sub

    Private Sub CadreSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Cadre Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Cadre"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Cadre Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Cadre"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Cadre Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Cadre"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetShifth.shiftName AS 'Shift Name',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShift)
        Label4.Text = "Cadre Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Cadre"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShiftMod)
        Label5.Text = "Cadre Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Cadre"

        SummaryFirstCadre()
    End Sub

    Private Sub BirthDaySearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND  tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetDept.deptName," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Birthday Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Birthday"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "' and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Birthday Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tbldesig.desgDesc AS 'Designation',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Birthday Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',tblSetShifth.shiftName AS 'Shift Name',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShift)
        Label4.Text = "Birthday Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Birthday"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CONVERT(VARCHAR(11),tblEmployee.dofB,106) AS 'Birthday',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tAtReview.regID=tblemployee.regid  AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND DATEPART(mm, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "MM") & "' AND '" & Format(dtpToDate.Value, "MM") & "' AND DATEPART(dd, .tblEmployee.DofB) BETWEEN '" & Format(dtpFromDate.Value, "dd") & "' AND '" & Format(dtpToDate.Value, "dd") & "'  and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and month(tAtReview.atdate) =month(tblEmployee.dofb)  and day(tAtReview.atdate) =day(tblEmployee.dofb) ORDER BY DATEPART(dd, tblEmployee.DofB),DATEPART(MM, tblEmployee.DofB),tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next
        clr_Grid(dgvShiftMod)
        Label5.Text = "Birthday Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Birthday"
    End Sub

    Private Sub ResignSearch()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvDepertment)
        For X As Integer = 0 To dgvDepertment.Columns.Count - 1
            dgvDepertment.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvDepertment)
        Label1.Text = "Resign Employees : " & dgvDepertment.RowCount
        lblDepartment.Text = "Department Wise Resign"


        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvCategory)
        For X As Integer = 0 To dgvCategory.Columns.Count - 1
            dgvCategory.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvCategory)
        Label2.Text = "Resign Employees : " & dgvCategory.RowCount
        lblCategory.Text = "Category Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tbldesig.desgDesc," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvDesignation)
        For X As Integer = 0 To dgvDesignation.Columns.Count - 1
            dgvDesignation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvDesignation)
        Label3.Text = "Resign Employees : " & dgvDesignation.RowCount
        lblDesignation.Text = "Designation Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetShifth.shiftName AS 'Shift Name',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetShifth.shiftName," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShift)
        For X As Integer = 0 To dgvShift.Columns.Count - 1
            dgvShift.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvShift)
        Label4.Text = "Resign Employees : " & dgvShift.RowCount
        lblShuftName.Text = "Shift Name Wise Resign"

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',CONVERT(VARCHAR(11),statusDate,106) AS 'Resign Day',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblEmployee.statusDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'  and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%')  and tAtReview.atdate =tblEmployee.StatusDate ORDER BY tblSetShifth.shiftMode," & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvShiftMod)
        For X As Integer = 0 To dgvShiftMod.Columns.Count - 1
            dgvShiftMod.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        clr_Grid(dgvShiftMod)
        Label5.Text = "Resign Employees : " & dgvShiftMod.RowCount
        lblShiftMode.Text = "Shift Mode Wise Resign"
    End Sub

    Private Sub btnPresent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPresent.Click
        strClick = "Present"
        If bolSingle = True Then
            presentSearch()
        Else
            PresentSummary()
        End If
        ClickedButton(pnlPresentSet, Label42, lblCPresent, lblPGPresent)
    End Sub

    Private Sub ClickedButton(ByVal pnlClkd As Panel, ByVal lblText As Label, ByVal lblCount As Label, ByVal lblPercentage As Label)
        'pnlPresentSet.BackColor = Color.Transparent
        'pnlAbsentSet.BackColor = Color.Transparent
        'pnlLateSet.BackColor = Color.Transparent
        'pnlLeaveSet.BackColor = Color.Transparent
        'pnlCadre.BackColor = Color.Transparent
        'pnlContractSet.BackColor = Color.Transparent
        'pnlJoinSet.BackColor = Color.Transparent
        'pnlResign.BackColor = Color.Transparent
        'pnlBirthDaySET.BackColor = Color.Transparent
        pnlClkd.BackColor = clrFocused
        lblText.ForeColor = Color.White
        lblCount.ForeColor = Color.White
        lblPercentage.ForeColor = Color.White
    End Sub

    Private Sub LostFocusButton(ByVal pnlClkd As Panel, ByVal lblText As Label, ByVal lblCount As Label, ByVal lblPercentage As Label)
        pnlClkd.BackColor = Color.Transparent
        lblText.ForeColor = clrFocused
        lblCount.ForeColor = clrFocused
        lblPercentage.ForeColor = clrFocused
    End Sub

    Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged
        'If intLoad = 1 Then

        'End If
        Me.Cursor = Cursors.WaitCursor
        sSQL = "delete from tAtReview; insert into tAtReview select convert (varchar(11),tblEmpRegister.atdate,106) as 'tt2'  ,tblEmployee.regid,tblEmployee.deptid,tblEmployee.catID,tblEmployee.desigID,tblEmpRegister.allShifts,case when tblEmpRegister.antstatus='1' then '1' else '0' end  as 'p'  ,case when tblEmpRegister.antstatus='0' then '1' else '0' end  as 'a',case when tblEmpRegister.islate='1' then '1' else '0' end  as 'lt' ,case when tblEmpRegister.isleave='1' then '1' else '0' end  as 'lv',0  as 'tot' FROM tblEmpRegister inner join tblemployee on tblEmpRegister.empID=tblemployee.regID where  atdate  BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' and  tblemployee.empstatus <> 9 AND tblEmployee.DeptID In  ('" & StrUserLvDept & "');"
        FK_EQ(sSQL, "P", "", False, False, True)

        sSQL = "select  convert(int,sum(p)) as Present, convert(int,sum(lv)) as Leave, convert(int,sum(lt)) as Late, convert(int,sum(a)) as Absent, convert(int,count(atDate)) as Total from tAtReview,tblemployee where tAtReview.regID=tblemployee.regid and tAtReview.atdate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "')"
        fk_Return_MultyString(sSQL, 5)
        lblCAbsent.Text = fk_ReadGRID(3).ToString().PadLeft(3, "0")
        lblCLate.Text = fk_ReadGRID(2).ToString().PadLeft(3, "0")
        lblCPresent.Text = fk_ReadGRID(0).ToString().PadLeft(3, "0")
        lblCLeave.Text = fk_ReadGRID(1).ToString().PadLeft(3, "0")
        lblCCadre.Text = fk_ReadGRID(4).ToString().PadLeft(3, "0")


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAbsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbsent.Click
        'presentSearch(sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 ORDER BY tblSetDept.shCode," & sqlTag1 & "")
        'Fk_FillGrid(sSQL, dgvDepertment)
        'Label1.Text = "Present Employees : " & dgvDepertment.RowCount


        'sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpCategory.catDesc AS 'Category',tblSetDept.shCode AS 'Department' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 ORDER BY tblSetEmpCategory.catDesc," & sqlTag1 & ""
        'Fk_FillGrid(sSQL, dgvCategory)
        ''SplitContainer1.SplitterDistance = Me.Width / 4 * 3
        'Label2.Text = "Present Employees : " & dgvCategory.RowCount
        'Me.Close()
        strClick = "Absent"
        If bolSingle = True Then
            AbsentSearch()
        Else
            AbsentSummary()
        End If
        ClickedButton(pnlAbsentSet, Label43, lblCAbsent, lblPGAbsent)
    End Sub

    'Private Sub cmbCat_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCat.Click

    'End Sub

    'Private Sub cmbDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.Click
    '    SplitContainer1.SplitterDistance = Me.Width / 5 * 4
    'End Sub

    'Private Sub cmbDesign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDesign.Click
    '    SplitContainer1.SplitterDistance = Me.Width / 5 * 4
    'End Sub

    'Private Sub cmbShiftName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShiftName.Click
    'End Sub

    'Private Sub cmbShiftType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShiftType.Click
    '    SplitContainer1.SplitterDistance = Me.Width / 5 * 2
    'End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 5 * intSpliterPercentage
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If

    End Sub

    Private Sub cmbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCat.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 5 * intSpliterPercentage
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmbDesign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesign.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 5 * intSpliterPercentage
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmbShiftName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShiftName.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 5 * 3
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmbShiftType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShiftType.TextChanged
        SplitContainer1.SplitterDistance = Me.Width / 5 * 3
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub btnLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLate.Click
        strClick = "Late"
        If bolSingle = True Then
            LateSearch()
        Else
            LateSummary()
        End If
        ClickedButton(pnlLateSet, Label51, lblCLate, lblPGLate)
    End Sub

    Private Sub btnLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeave.Click
        strClick = "Leave"
        If bolSingle = True Then
            LeaveSearch()
        Else
            LeaveSummary()
        End If
        ClickedButton(pnlLeaveSet, Label59, lblCLeave, lblPGLeave)
    End Sub

    Private Sub btnCrdre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrdre.Click
        strClick = "Cadre"
        If bolSingle = True Then
            CadreSearch()
        Else
            CadreSummary()
        End If
        ClickedButton(pnlCadre, Label63, lblCCadre, lblPDCadre)
    End Sub


    Private Sub cmdPrevDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevDay.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, -1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, -1, dtpToDate.Value)
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub cmdNextDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextDay.Click
        dtpFromDate.Value = DateAdd(DateInterval.Day, 1, dtpFromDate.Value)
        dtpToDate.Value = DateAdd(DateInterval.Day, 1, dtpToDate.Value)
        If intLoad = 1 Then
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub btnSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSummary.Click
        If pnlDetail.Height <> pnlBottomSet.Height Then
            Me.pnlDetail.Height = pnlBottomSet.Height
            'bolSingle = True
            'Me.btnSummary.Text = "Summary"
        ElseIf Me.pnlDetail.Height = pnlBottomSet.Height Then
            Me.pnlDetail.Height = 0
            bolSingle = False
            Me.btnSummary.Text = "Detaily"
            If strClick = "Present" Then
                If bolSingle = True Then
                    presentSearch()
                Else
                    PresentSummary()
                End If
            ElseIf strClick = "Absent" Then
                If bolSingle = True Then
                    AbsentSearch()
                Else
                    AbsentSummary()
                End If
            ElseIf strClick = "Late" Then
                If bolSingle = True Then
                    LateSearch()
                Else
                    LateSummary()
                End If
            ElseIf strClick = "Leave" Then
                If bolSingle = True Then
                    LeaveSearch()
                Else
                    LeaveSummary()
                End If
            ElseIf strClick = "Cadre" Then
                If bolSingle = True Then
                    CadreSearch()
                Else
                    CadreSummary()
                End If
            ElseIf strClick = "Birthday" Then
                If bolSingle = True Then
                    BirthDaySearch()
                Else
                    'presentSearch()
                End If
            ElseIf strClick = "Resign" Then
                If bolSingle = True Then
                    ResignSearch()
                Else
                    'presentSearch()
                End If
            End If
        End If
    End Sub

    Private Sub SummaryFirstPresent()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvSMDesg)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvSMShitN)
        For X As Integer = 0 To dgvSMShitN.Columns.Count - 1
            dgvSMShitN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvSMShitN)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvSMShiftM)
        For X As Integer = 0 To dgvSMShiftM.Columns.Count - 1
            dgvSMShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvSMShiftM)
    End Sub

    Private Sub SummaryFirstAbsent()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvSMShitN)
        For X As Integer = 0 To dgvSMShitN.Columns.Count - 1
            dgvSMShitN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShitN)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvSMShiftM)
        For X As Integer = 0 To dgvSMShiftM.Columns.Count - 1
            dgvSMShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShiftM)
    End Sub

    Private Sub SummaryFirstLate()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvSMShitN)
        For X As Integer = 0 To dgvSMShitN.Columns.Count - 1
            dgvSMShitN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShitN)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvSMShiftM)
        For X As Integer = 0 To dgvSMShiftM.Columns.Count - 1
            dgvSMShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShiftM)
    End Sub

    Private Sub SummaryFirstLeave()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvSMShitN)
        For X As Integer = 0 To dgvSMShitN.Columns.Count - 1
            dgvSMShitN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShitN)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvSMShiftM)
        For X As Integer = 0 To dgvSMShiftM.Columns.Count - 1
            dgvSMShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShiftM)
    End Sub

    Private Sub SummaryFirstCadre()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, DgvSMDep)
        For X As Integer = 0 To DgvSMDep.Columns.Count - 1
            DgvSMDep.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(DgvSMDep)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvSmCat)
        For X As Integer = 0 To dgvSmCat.Columns.Count - 1
            dgvSmCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSmCat)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvSMDesg)
        For X As Integer = 0 To dgvSMDesg.Columns.Count - 1
            dgvSMDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMDesg)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvSMShitN)
        For X As Integer = 0 To dgvSMShitN.Columns.Count - 1
            dgvSMShitN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShitN)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift=0' ELSE 'Night Shift=1' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "'   and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvSMShiftM)
        For X As Integer = 0 To dgvSMShiftM.Columns.Count - 1
            dgvSMShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvSMShiftM)
    End Sub

    Private Sub PresentSummary()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, dgvDepSummary)
        For X As Integer = 0 To dgvDepSummary.Columns.Count - 1
            dgvDepSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDepSummary)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvCatSummary)
        For X As Integer = 0 To dgvCatSummary.Columns.Count - 1
            dgvCatSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvCatSummary)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDesgSummary)
        For X As Integer = 0 To dgvDesgSummary.Columns.Count - 1
            dgvDesgSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDesgSummary)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvShiftNSummary)
        For X As Integer = 0 To dgvShiftNSummary.Columns.Count - 1
            dgvShiftNSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftNSummary)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvShMsummary)
        For X As Integer = 0 To dgvShMsummary.Columns.Count - 1
            dgvShMsummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShMsummary)


        'Second Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpType.tDesc  "
        Fk_FillGrid(sSQL, dgvDeptType)
        For X As Integer = 0 To dgvDeptType.Columns.Count - 1
            dgvDeptType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDeptType)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvCatTyp)
        For X As Integer = 0 To dgvCatTyp.Columns.Count - 1
            dgvCatTyp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvCatTyp)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvDesgType)
        For X As Integer = 0 To dgvDesgType.Columns.Count - 1
            dgvDesgType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDesgType)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftNtYPE)
        For X As Integer = 0 To dgvShiftNtYPE.Columns.Count - 1
            dgvShiftNtYPE.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftNtYPE)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftMType)
        For X As Integer = 0 To dgvShiftMType.Columns.Count - 1
            dgvShiftMType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftMType)


        'Third Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvDeptCat)
        For X As Integer = 0 To dgvDeptCat.Columns.Count - 1
            dgvDeptCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDeptCat)

        sSQL = "select tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvType)
        For X As Integer = 0 To dgvType.Columns.Count - 1
            dgvType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvType)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftName "
        Fk_FillGrid(sSQL, dgvDesgShiftN)
        For X As Integer = 0 To dgvDesgShiftN.Columns.Count - 1
            dgvDesgShiftN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDesgShiftN)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftNDept)
        For X As Integer = 0 To dgvShiftNDept.Columns.Count - 1
            dgvShiftNDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftNDept)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftMDept)
        For X As Integer = 0 To dgvShiftMDept.Columns.Count - 1
            dgvShiftMDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftMDept)


        'Fourth Row
        sSQL = "select tblSetDept.deptName AS 'Department',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDeptDesg)
        For X As Integer = 0 To dgvDeptDesg.Columns.Count - 1
            dgvDeptDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDeptDesg)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvCatDesg)
        For X As Integer = 0 To dgvCatDesg.Columns.Count - 1
            dgvCatDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvCatDesg)

        sSQL = "select tbldesig.desgDesc AS 'Designation',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvDesgShiftM)
        For X As Integer = 0 To dgvDesgShiftM.Columns.Count - 1
            dgvDesgShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvDesgShiftM)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftNCat)
        For X As Integer = 0 To dgvShiftNCat.Columns.Count - 1
            dgvShiftNCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftNCat)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftMCat)
        For X As Integer = 0 To dgvShiftMCat.Columns.Count - 1
            dgvShiftMCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        'clr_Grid(dgvShiftMCat)
    End Sub

    Private Sub AbsentSummary()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, dgvDepSummary)
        For X As Integer = 0 To dgvDepSummary.Columns.Count - 1
            dgvDepSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDepSummary)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvCatSummary)
        For X As Integer = 0 To dgvCatSummary.Columns.Count - 1
            dgvCatSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatSummary)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDesgSummary)
        For X As Integer = 0 To dgvDesgSummary.Columns.Count - 1
            dgvDesgSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgSummary)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvShiftNSummary)
        For X As Integer = 0 To dgvShiftNSummary.Columns.Count - 1
            dgvShiftNSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNSummary)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvShMsummary)
        For X As Integer = 0 To dgvShMsummary.Columns.Count - 1
            dgvShMsummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShMsummary)


        'Second Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpType.tDesc  "
        Fk_FillGrid(sSQL, dgvDeptType)
        For X As Integer = 0 To dgvDeptType.Columns.Count - 1
            dgvDeptType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptType)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvCatTyp)
        For X As Integer = 0 To dgvCatTyp.Columns.Count - 1
            dgvCatTyp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatTyp)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvDesgType)
        For X As Integer = 0 To dgvDesgType.Columns.Count - 1
            dgvDesgType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgType)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftNtYPE)
        For X As Integer = 0 To dgvShiftNtYPE.Columns.Count - 1
            dgvShiftNtYPE.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNtYPE)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftMType)
        For X As Integer = 0 To dgvShiftMType.Columns.Count - 1
            dgvShiftMType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMType)


        'Third Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvDeptCat)
        For X As Integer = 0 To dgvDeptCat.Columns.Count - 1
            dgvDeptCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptCat)

        sSQL = "select tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvType)
        For X As Integer = 0 To dgvType.Columns.Count - 1
            dgvType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvType)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftName "
        Fk_FillGrid(sSQL, dgvDesgShiftN)
        For X As Integer = 0 To dgvDesgShiftN.Columns.Count - 1
            dgvDesgShiftN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftN)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftNDept)
        For X As Integer = 0 To dgvShiftNDept.Columns.Count - 1
            dgvShiftNDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNDept)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftMDept)
        For X As Integer = 0 To dgvShiftMDept.Columns.Count - 1
            dgvShiftMDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMDept)


        'Fourth Row
        sSQL = "select tblSetDept.deptName AS 'Department',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDeptDesg)
        For X As Integer = 0 To dgvDeptDesg.Columns.Count - 1
            dgvDeptDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptDesg)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvCatDesg)
        For X As Integer = 0 To dgvCatDesg.Columns.Count - 1
            dgvCatDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatDesg)

        sSQL = "select tbldesig.desgDesc AS 'Designation',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvDesgShiftM)
        For X As Integer = 0 To dgvDesgShiftM.Columns.Count - 1
            dgvDesgShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftM)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftNCat)
        For X As Integer = 0 To dgvShiftNCat.Columns.Count - 1
            dgvShiftNCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNCat)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftMCat)
        For X As Integer = 0 To dgvShiftMCat.Columns.Count - 1
            dgvShiftMCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMCat)
    End Sub

    Private Sub LateSummary()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, dgvDepSummary)
        For X As Integer = 0 To dgvDepSummary.Columns.Count - 1
            dgvDepSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDepSummary)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvCatSummary)
        For X As Integer = 0 To dgvCatSummary.Columns.Count - 1
            dgvCatSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatSummary)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDesgSummary)
        For X As Integer = 0 To dgvDesgSummary.Columns.Count - 1
            dgvDesgSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgSummary)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvShiftNSummary)
        For X As Integer = 0 To dgvShiftNSummary.Columns.Count - 1
            dgvShiftNSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNSummary)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvShMsummary)
        For X As Integer = 0 To dgvShMsummary.Columns.Count - 1
            dgvShMsummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShMsummary)


        'Second Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpType.tDesc  "
        Fk_FillGrid(sSQL, dgvDeptType)
        For X As Integer = 0 To dgvDeptType.Columns.Count - 1
            dgvDeptType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptType)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvCatTyp)
        For X As Integer = 0 To dgvCatTyp.Columns.Count - 1
            dgvCatTyp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatTyp)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvDesgType)
        For X As Integer = 0 To dgvDesgType.Columns.Count - 1
            dgvDesgType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgType)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftNtYPE)
        For X As Integer = 0 To dgvShiftNtYPE.Columns.Count - 1
            dgvShiftNtYPE.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNtYPE)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftMType)
        For X As Integer = 0 To dgvShiftMType.Columns.Count - 1
            dgvShiftMType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMType)


        'Third Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvDeptCat)
        For X As Integer = 0 To dgvDeptCat.Columns.Count - 1
            dgvDeptCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptCat)

        sSQL = "select tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvType)
        For X As Integer = 0 To dgvType.Columns.Count - 1
            dgvType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvType)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftName "
        Fk_FillGrid(sSQL, dgvDesgShiftN)
        For X As Integer = 0 To dgvDesgShiftN.Columns.Count - 1
            dgvDesgShiftN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftN)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftNDept)
        For X As Integer = 0 To dgvShiftNDept.Columns.Count - 1
            dgvShiftNDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNDept)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftMDept)
        For X As Integer = 0 To dgvShiftMDept.Columns.Count - 1
            dgvShiftMDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMDept)


        'Fourth Row
        sSQL = "select tblSetDept.deptName AS 'Department',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDeptDesg)
        For X As Integer = 0 To dgvDeptDesg.Columns.Count - 1
            dgvDeptDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptDesg)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvCatDesg)
        For X As Integer = 0 To dgvCatDesg.Columns.Count - 1
            dgvCatDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatDesg)

        sSQL = "select tbldesig.desgDesc AS 'Designation',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvDesgShiftM)
        For X As Integer = 0 To dgvDesgShiftM.Columns.Count - 1
            dgvDesgShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftM)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftNCat)
        For X As Integer = 0 To dgvShiftNCat.Columns.Count - 1
            dgvShiftNCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNCat)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftMCat)
        For X As Integer = 0 To dgvShiftMCat.Columns.Count - 1
            dgvShiftMCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMCat)
    End Sub

    Private Sub LeaveSummary()
        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, dgvDepSummary)
        For X As Integer = 0 To dgvDepSummary.Columns.Count - 1
            dgvDepSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDepSummary)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvCatSummary)
        For X As Integer = 0 To dgvCatSummary.Columns.Count - 1
            dgvCatSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatSummary)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDesgSummary)
        For X As Integer = 0 To dgvDesgSummary.Columns.Count - 1
            dgvDesgSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgSummary)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvShiftNSummary)
        For X As Integer = 0 To dgvShiftNSummary.Columns.Count - 1
            dgvShiftNSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNSummary)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvShMsummary)
        For X As Integer = 0 To dgvShMsummary.Columns.Count - 1
            dgvShMsummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShMsummary)


        'Second Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpType.tDesc  "
        Fk_FillGrid(sSQL, dgvDeptType)
        For X As Integer = 0 To dgvDeptType.Columns.Count - 1
            dgvDeptType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptType)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvCatTyp)
        For X As Integer = 0 To dgvCatTyp.Columns.Count - 1
            dgvCatTyp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatTyp)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvDesgType)
        For X As Integer = 0 To dgvDesgType.Columns.Count - 1
            dgvDesgType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgType)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftNtYPE)
        For X As Integer = 0 To dgvShiftNtYPE.Columns.Count - 1
            dgvShiftNtYPE.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNtYPE)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftMType)
        For X As Integer = 0 To dgvShiftMType.Columns.Count - 1
            dgvShiftMType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMType)


        'Third Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvDeptCat)
        For X As Integer = 0 To dgvDeptCat.Columns.Count - 1
            dgvDeptCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptCat)

        sSQL = "select tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvType)
        For X As Integer = 0 To dgvType.Columns.Count - 1
            dgvType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvType)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftName "
        Fk_FillGrid(sSQL, dgvDesgShiftN)
        For X As Integer = 0 To dgvDesgShiftN.Columns.Count - 1
            dgvDesgShiftN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftN)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftNDept)
        For X As Integer = 0 To dgvShiftNDept.Columns.Count - 1
            dgvShiftNDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNDept)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftMDept)
        For X As Integer = 0 To dgvShiftMDept.Columns.Count - 1
            dgvShiftMDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMDept)


        'Fourth Row
        sSQL = "select tblSetDept.deptName AS 'Department',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDeptDesg)
        For X As Integer = 0 To dgvDeptDesg.Columns.Count - 1
            dgvDeptDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptDesg)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvCatDesg)
        For X As Integer = 0 To dgvCatDesg.Columns.Count - 1
            dgvCatDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatDesg)

        sSQL = "select tbldesig.desgDesc AS 'Designation',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvDesgShiftM)
        For X As Integer = 0 To dgvDesgShiftM.Columns.Count - 1
            dgvDesgShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftM)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftNCat)
        For X As Integer = 0 To dgvShiftNCat.Columns.Count - 1
            dgvShiftNCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNCat)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftMCat)
        For X As Integer = 0 To dgvShiftMCat.Columns.Count - 1
            dgvShiftMCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMCat)
    End Sub

    Private Sub CadreSummary()

        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", cmbDept.Text)
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", cmbCat.Text)
        Dim StrDesigName As String = IIf(cmbDesign.Text = "[ALL]", "", cmbDesign.Text)
        Dim strShiftName As String = IIf(cmbShiftName.Text = "[ALL]", "", cmbShiftName.Text)
        Dim strShiftMod As String = IIf(cmbShiftType.Text = "[ALL]", "", FK_GetIDR(cmbShiftType.Text))

        sSQL = "select tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName  "
        Fk_FillGrid(sSQL, dgvDepSummary)
        For X As Integer = 0 To dgvDepSummary.Columns.Count - 1
            dgvDepSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDepSummary)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvCatSummary)
        For X As Integer = 0 To dgvCatSummary.Columns.Count - 1
            dgvCatSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatSummary)

        sSQL = "select tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDesgSummary)
        For X As Integer = 0 To dgvDesgSummary.Columns.Count - 1
            dgvDesgSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgSummary)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName"
        Fk_FillGrid(sSQL, dgvShiftNSummary)
        For X As Integer = 0 To dgvShiftNSummary.Columns.Count - 1
            dgvShiftNSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNSummary)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvShMsummary)
        For X As Integer = 0 To dgvShMsummary.Columns.Count - 1
            dgvShMsummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShMsummary)


        'Second Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpType.tDesc  "
        Fk_FillGrid(sSQL, dgvDeptType)
        For X As Integer = 0 To dgvDeptType.Columns.Count - 1
            dgvDeptType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptType)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpCategory.catDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvCatTyp)
        For X As Integer = 0 To dgvCatTyp.Columns.Count - 1
            dgvCatTyp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatTyp)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvDesgType)
        For X As Integer = 0 To dgvDesgType.Columns.Count - 1
            dgvDesgType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgType)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftNtYPE)
        For X As Integer = 0 To dgvShiftNtYPE.Columns.Count - 1
            dgvShiftNtYPE.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNtYPE)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvShiftMType)
        For X As Integer = 0 To dgvShiftMType.Columns.Count - 1
            dgvShiftMType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMType)


        'Third Row
        sSQL = "select tblSetDept.deptName AS 'Department',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvDeptCat)
        For X As Integer = 0 To dgvDeptCat.Columns.Count - 1
            dgvDeptCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptCat)

        sSQL = "select tblSetEmpType.tDesc AS 'Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetEmpType.tDesc"
        Fk_FillGrid(sSQL, dgvType)
        For X As Integer = 0 To dgvType.Columns.Count - 1
            dgvType.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvType)

        sSQL = "select tbldesig.desgDesc AS 'Designation',tblSetShifth.shiftName AS 'Shift Name',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftName "
        Fk_FillGrid(sSQL, dgvDesgShiftN)
        For X As Integer = 0 To dgvDesgShiftN.Columns.Count - 1
            dgvDesgShiftN.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftN)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftNDept)
        For X As Integer = 0 To dgvShiftNDept.Columns.Count - 1
            dgvShiftNDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNDept)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetDept.deptName AS 'Department',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetDept.deptName"
        Fk_FillGrid(sSQL, dgvShiftMDept)
        For X As Integer = 0 To dgvShiftMDept.Columns.Count - 1
            dgvShiftMDept.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMDept)


        'Fourth Row
        sSQL = "select tblSetDept.deptName AS 'Department',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetDept.deptName,tbldesig.desgDesc"
        Fk_FillGrid(sSQL, dgvDeptDesg)
        For X As Integer = 0 To dgvDeptDesg.Columns.Count - 1
            dgvDeptDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDeptDesg)

        sSQL = "select tblSetEmpCategory.catDesc AS 'Category',tbldesig.desgDesc AS 'Designation',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetEmpCategory.catDesc "
        Fk_FillGrid(sSQL, dgvCatDesg)
        For X As Integer = 0 To dgvCatDesg.Columns.Count - 1
            dgvCatDesg.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvCatDesg)

        sSQL = "select tbldesig.desgDesc AS 'Designation',CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tbldesig.desgDesc,tblSetShifth.shiftMode"
        Fk_FillGrid(sSQL, dgvDesgShiftM)
        For X As Integer = 0 To dgvDesgShiftM.Columns.Count - 1
            dgvDesgShiftM.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvDesgShiftM)

        sSQL = "select tblSetShifth.shiftName AS 'Shift Name',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftName,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftNCat)
        For X As Integer = 0 To dgvShiftNCat.Columns.Count - 1
            dgvShiftNCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftNCat)

        sSQL = "select CASE WHEN tblSetShifth.shiftMode=0 THEN 'Day Shift' ELSE 'Night Shift' END AS 'Shift Type',tblSetEmpCategory.catDesc AS 'Category',count(*) AS 'Total' from tAtReview,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth,tblSetEmpType WHERE tblEmployee.regID=tAtReview.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblSetShifth.shiftID=tAtReview.shiftID AND tblSetEmpType.typeID=tblEmployee.EmpTypeID AND tAtReview.atDate BETWEEN '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblemployee.Empstatus<>9 and tblemployee.deptID in    ('" & StrUserLvDept & "')     AND      tblemployee.brID IN ('" & StrUserLvBranch & "') AND (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND tblSEtShiftH.shiftName LIKE '" & strShiftName & "%' AND tblSEtShiftH.shiftMode LIKE '" & strShiftMod & "%') GROUP BY tblSetShifth.shiftMode,tblSetEmpCategory.catDesc"
        Fk_FillGrid(sSQL, dgvShiftMCat)
        For X As Integer = 0 To dgvShiftMCat.Columns.Count - 1
            dgvShiftMCat.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        clr_Grid(dgvShiftMCat)
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

    Private Sub dgvSMDesg_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSMDesg.CellClick
        cmbDesign.Text = Trim(dgvSMDesg.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub dgvSMShitN_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSMShitN.CellClick
        cmbShiftName.Text = Trim(dgvSMShitN.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub dgvSMShiftM_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSMShiftM.CellClick
        cmbShiftType.Text = Trim(dgvSMShiftM.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub setProgreBars()
        Try
            'Set Progress bar
            pbAbsent.Maximum = Val(lblCCadre.Text)
            pbAbsent.Minimum = 0
            pbAbsent.Value = Val(lblCAbsent.Text)
            lblPGAbsent.Text = CInt(Val(lblCAbsent.Text) / Val(lblCCadre.Text) * 100) & "%"

            pbPresent.Maximum = Val(lblCCadre.Text)
            pbPresent.Minimum = 0
            pbPresent.Value = Val(lblCPresent.Text)
            lblPGPresent.Text = CInt(Val(lblCPresent.Text) / Val(lblCCadre.Text) * 100) & "%"

            pbLate.Maximum = Val(lblCCadre.Text)
            pbLate.Minimum = 0
            pbLate.Value = Val(lblCLate.Text)
            lblPGLate.Text = CInt(Val(lblCLate.Text) / Val(lblCCadre.Text) * 100) & "%"

            pbLeave.Maximum = Val(lblCCadre.Text)
            pbLeave.Minimum = 0
            pbLeave.Value = Val(lblCLeave.Text)
            lblPGLeave.Text = CInt(Val(lblCLeave.Text) / Val(lblCCadre.Text) * 100) & "%"

            pbCadre.Maximum = Val(lblCCadre.Text)
            pbCadre.Minimum = 0
            pbCadre.Value = Val(lblCCadre.Text)
            lblPDCadre.Text = CInt(Val(lblCCadre.Text) / Val(lblCCadre.Text) * 100) & "%"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnPresent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPresent.LostFocus
        LostFocusButton(pnlPresentSet, Label42, lblCPresent, lblPGPresent)
    End Sub

    Private Sub btnAbsent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbsent.LostFocus
        LostFocusButton(pnlAbsentSet, Label43, lblCAbsent, lblPGAbsent)
    End Sub

    Private Sub btnLate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLate.LostFocus
        LostFocusButton(pnlLateSet, Label51, lblCLate, lblPGLate)
    End Sub

    Private Sub btnLeave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeave.LostFocus
        LostFocusButton(pnlLeaveSet, Label59, lblCLeave, lblPGLeave)
    End Sub

    Private Sub btnCrdre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrdre.LostFocus
        LostFocusButton(pnlCadre, Label63, lblCCadre, lblPDCadre)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvCategory, dgvCategory.ColumnCount - 1, strComName, "Category wise " & strClick & " Employees List - " & dgvCategory.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvDesignation, dgvDesignation.ColumnCount - 1, strComName, "Designation wise " & strClick & " Employees List" & dgvDesignation.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvShift, dgvShift.ColumnCount - 1, strComName, "Shift Name wise " & strClick & " Employees List - " & dgvShift.RowCount, 0, strComAddres)
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim drk As DialogResult = MessageBox.Show("Do you really want to generate excel file with this data ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If drk = Windows.Forms.DialogResult.Yes Then
            ExporttoExcelWithHeader(dgvShiftMod, dgvShiftMod.ColumnCount - 1, strComName, "Shift Mode wise " & strClick & " Employees List - " & dgvShiftMod.RowCount, 0, strComAddres)
        End If
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

    Private Sub frmAttendanceDashBoard1_ImeModeChanged(sender As Object, e As EventArgs) Handles Me.ImeModeChanged

    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click

    End Sub
End Class