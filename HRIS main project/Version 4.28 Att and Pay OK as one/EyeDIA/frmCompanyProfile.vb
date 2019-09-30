Public Class frmCompanyProfile

    Dim clrSelcetedColor As Color = Color.DimGray
    Dim clrDefaultColor As Color = Color.Orange

    Private Sub frmCompanyProfile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Company", "View company settings") = False Then Exit Sub
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCompany
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()
        GetLoadCount()

        If IsFamilyInfo = 1 Then
            lblRelationship.Enabled = True
        Else
            lblRelationship.Enabled = False
        End If

        If IsAdditionalHRModule = 0 Then
            'lblTitles.Enabled = False
            lblEducation.Enabled = False
            lblBlood.Enabled = False
            lblMeal.Enabled = False
            lblDocument.Enabled = False
            lblElectrorate.Enabled = False
            lblTransport.Enabled = False
            lblRaces.Enabled = False
            lblPostal.Enabled = False
            lblCurrency.Enabled = False
            lblProvince.Enabled = False
            lblCity.Enabled = False
            lblPay.Enabled = False
            lblCost.Enabled = False
            lblBank.Enabled = False
            'lblGender.Enabled = False
            'lblReligion.Enabled = False
            lblBenifitis.Enabled = True
        End If

        If strEditSetings = "" Then
            sSQL = "SELECT TBLCOMPANY.cName AS 'Company Name',COUNT(TBLEMPLOYEE.compID) AS 'Employee Count' FROM TBLEMPLOYEE,TBLCOMPANY WHERE TBLCOMPANY.compID=TBLEMPLOYEE.compID  AND TBLEMPLOYEE.EMPSTATUS<>9 GROUP BY TBLCOMPANY.compID,TBLCOMPANY.cName"
            GridSetupCount(sSQL, "Company")

            sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',TBLCOMPANY.CName AS 'Comapay Name' FROM TBLEMPLOYEE,TBLCOMPANY WHERE TBLCOMPANY.compID=TBLEMPLOYEE.compID AND TBLEMPLOYEE.EMPSTATUS<>9 ORDER BY TBLCOMPANY.cName"
            GridDetaily(sSQL, "Company")

        Else

            Select Case strEditSetings

                Case "Designation"
                    lblDesignation_Click(sender, e)
                    strEditSetings = ""
                Case "Department"
                    lblDeparment_Click(sender, e)
                    strEditSetings = ""
                Case "Branch"
                    lblBranch_Click(sender, e)
                    strEditSetings = ""
                Case "EmployeeType"
                    lblEmpTypes_Click(sender, e)
                    strEditSetings = ""
                Case "Category"
                    lblCategory_Click(sender, e)
                    strEditSetings = ""
                Case "Shift"
                    lblShifts_Click(sender, e)
                    strEditSetings = ""
                Case "ProcessCategory"
                    lblProcesCategory_Click(sender, e)
                    strEditSetings = ""
                Case "SubCategory"
                    lblCategory_Click(sender, e)
                    strEditSetings = ""
                Case "ViewLevel"
                    lblShifts_Click(sender, e)
                    strEditSetings = ""
                Case "CostCenter"
                    lblCost_Click(sender, e)
                    strEditSetings = ""
                Case "PayCenter"
                    lblPay_Click(sender, e)
                    strEditSetings = ""
                Case "BloodGroup"
                    lblBlood_Click(sender, e)
                    strEditSetings = ""
                Case "Meal"
                    lblMeal_Click(sender, e)
                    strEditSetings = ""
                Case "Religion"
                    lblReligion_Click(sender, e)
                    strEditSetings = ""
                Case "Race"
                    lblRaces_Click(sender, e)
                    strEditSetings = ""
                Case "Benefits"
                    lblBenifitis_Click(sender, e)
                    strEditSetings = ""
                Case "Province"
                    lblProvince_Click(sender, e)
                    strEditSetings = ""
                Case "City"
                    lblCity_Click(sender, e)
                    strEditSetings = ""
                Case "PostalCode"
                    lblPostal_Click(sender, e)
                    strEditSetings = ""
                Case "Electrorate"
                    lblElectrorate_Click(sender, e)
                    strEditSetings = ""
                Case "TransportMode"
                    lblTransport_Click(sender, e)
                    strEditSetings = ""

            End Select

        End If

    End Sub

    Private Sub GetLoadCount()
        sSQL = "select count(brid) from tblcBranchs where status=0 and tblcBranchs.brID in ('" & StrUserLvBranch & "') "
        lblBranch.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(desgid) from tbldesig where status=0"
        lblDesignation.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(deptid) from tblsetdept where status=0 and tblsetdept.deptID in ('" & StrUserLvDept & "') "
        lblDeparment.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(TYPEid) from tblSetEmpType where status=0"
        lblEmpTypes.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(catid) from tblSEtEmpCategory where status=0"
        lblCategory.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(cntID) from tblSetCCentre where status=0"
        lblCost.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(PID) from tblSetPCentre where status=0"
        lblPay.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(catID) from tblSetPrCategory where status=0"
        lblProcesCategory.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(shiftID) from tblsetShifth where status=0"
        lblShifts.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(titleid) from tblSetTitle where status=0"
        lblTitles.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(religID) from tblSetReligion where status=0"
        lblReligion.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(STid) from tblCivilStatus where status=0"
        lblCivil.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(sCode) from tblEduType where status=0"
        lblEducation.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(cid) from tblBloodType where status=0"
        lblBlood.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(cid) from tblDocType where status=0"
        lblDocument.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(cid) from tblElectorate where status=0"
        lblElectrorate.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(cid) from tblTransportType where status=0"
        lblTransport.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(cid) from tblRace where status=0"
        lblRaces.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(titleID) from tblSetTitle where status=0"
        lblTitles.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(cid) from tblSetProvince where status=0"
        lblProvince.Text = fk_sqlDbl(sSQL)

        sSQL = "select count(genid) from tblGender where status=0"
        lblGender.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(bankID) from tblBanks where status=0"
        lblBank.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(cid) from tblCities where status=0"
        lblCity.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(PostalCode) from tblPostalCodes where status=0"
        lblPostal.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(scode) from tblMHabit where status=0"
        lblMeal.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(Descr) from tblSetBenefits where status=0"
        lblBenifitis.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(rDesc) from tblRelTypes where status=0"
        lblRelationship.Text = fk_sqlDbl(sSQL)

        sSQL = "select  count(cName) from tblCurrency where cstatus=0"
        lblCurrency.Text = fk_sqlDbl(sSQL)
    End Sub

    Private Function GridDetaily(ByVal sql As String, ByVal countLabel As String) As Double
        Try
            Fk_FillGrid(sql, dgvDetaily)
            lblDetail.Text = "Employees Allocation of " & countLabel & " : " & dgvDetaily.RowCount
            For X As Integer = 0 To dgvDetaily.Columns.Count - 1
                dgvDetaily.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
            clr_Grid(dgvDetaily)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return True
    End Function

    Private Function GridSetupCount(ByVal sql As String, ByVal countLabel As String) As Double
        Try
            Fk_FillGrid(sql, dgvSummary)
            lblSummary.Text = "Total " & countLabel & " : " & dgvSummary.RowCount
            For X As Integer = 0 To dgvSummary.Columns.Count - 1
                dgvSummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next
            'clr_Grid(dgvSummary)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Return True
    End Function

    Private Sub lblDeparment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDeparment.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetDepartment
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT TBLSETDEPT.DEPTNAME AS 'Department',COUNT(TBLEMPLOYEE.DEPTID) AS 'Employee Count' FROM TBLEMPLOYEE,TBLSETDEPT WHERE TBLSETDEPT.DEPTID=TBLEMPLOYEE.DEPTID and tblsetdept.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND TBLEMPLOYEE.EMPSTATUS<>9 GROUP BY TBLSETDEPT.DEPTID,TBLSETDEPT.DEPTNAME"
        GridSetupCount(sSQL, "Departments")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.DEPTNAME AS 'Department' FROM TBLEMPLOYEE,TBLSETDEPT WHERE TBLSETDEPT.DEPTID=TBLEMPLOYEE.DEPTID AND TBLEMPLOYEE.EMPSTATUS<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY DEPTNAME"
        GridDetaily(sSQL, "Departments")
    End Sub

    Private Sub lblBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBranch.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCBranchs
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblcbranchs.brName AS 'Branch Name',COUNT(TBLEMPLOYEE.brID) AS 'Employee Count' FROM TBLEMPLOYEE,tblcbranchs WHERE tblcbranchs.brID=TBLEMPLOYEE.BRID and TBLEMPLOYEE.brID in ('" & StrUserLvBranch & "') AND tblcbranchs.STATUS=0 AND TBLEMPLOYEE.EMPSTATUS<>9 GROUP BY tblcbranchs.BRID,tblcbranchs.BrName"
        GridSetupCount(sSQL, "Branches")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblcbranchs.brName AS 'Branch Name' FROM TBLEMPLOYEE,tblcbranchs WHERE tblcbranchs.brID=TBLEMPLOYEE.BRID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.brID in ('" & StrUserLvBranch & "') ORDER BY tblcbranchs.BrName"
        GridDetaily(sSQL, "Branches")
    End Sub

    Private Sub lblDesignation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDesignation.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetDesignation
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tbldesig.desgDesc AS 'Designation',COUNT(TBLEMPLOYEE.desigID) AS 'Employee Count' FROM TBLEMPLOYEE,tbldesig WHERE tbldesig.desgID=TBLEMPLOYEE.desigID and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tbldesig.STATUS=0  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  GROUP BY tbldesig.desgID,tbldesig.desgDesc"
        GridSetupCount(sSQL, "Designations")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tbldesig.desgDesc AS 'Designation' FROM TBLEMPLOYEE,tbldesig WHERE tbldesig.desgID=TBLEMPLOYEE.desigID AND TBLEMPLOYEE.EMPSTATUS<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  ORDER BY tbldesig.desgDesc"
        GridDetaily(sSQL, "Designations")
    End Sub

    Private Sub lblCivil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCivil.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCivilSt
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblCivilStatus.stDesc AS 'Civil Status',COUNT(TBLEMPLOYEE.civilStID) AS 'Employee Count' FROM TBLEMPLOYEE,tblCivilStatus WHERE tblCivilStatus.stID=TBLEMPLOYEE.civilStID AND tblCivilStatus.STATUS=0 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  GROUP BY tblCivilStatus.stID,tblCivilStatus.stDesc"
        GridSetupCount(sSQL, "Civil Status")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCivilStatus.stDesc AS 'Civil Status' FROM TBLEMPLOYEE,tblCivilStatus WHERE tblCivilStatus.stID=TBLEMPLOYEE.civilStID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblCivilStatus.stDesc"
        GridDetaily(sSQL, "Civil Status")
    End Sub

    Private Sub lblEducation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEducation.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetEduTypes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblEduType.sDesc AS 'Education Type',COUNT(TBLEMPLOYEE.eduid) AS 'Employee Count' FROM TBLEMPLOYEE,tblEduType WHERE tblEduType.scode=TBLEMPLOYEE.eduid AND tblEduType.STATUS=0 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  GROUP BY tblEduType.scode,tblEduType.sDesc"
        GridSetupCount(sSQL, "Education Type")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblEduType.sDesc AS 'Education Type' FROM TBLEMPLOYEE,tblEduType WHERE tblEduType.scode=TBLEMPLOYEE.eduid AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  ORDER BY tblEduType.sDesc"
        GridDetaily(sSQL, "Education Type")
    End Sub

    Private Sub lblBlood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBlood.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetBloodType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblBloodType.cDesc AS 'Blood Type',COUNT(TBLEMPLOYEE.bloodID) AS 'Employee Count' FROM TBLEMPLOYEE,tblBloodType WHERE tblBloodType.cID=TBLEMPLOYEE.bloodID AND tblBloodType.STATUS=0  and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblBloodType.cid,tblBloodType.cDesc	"
        GridSetupCount(sSQL, "Blood Type")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Blood Type',tblBloodType.cDesc AS 'Blood Type' FROM TBLEMPLOYEE,tblBloodType WHERE tblBloodType.cID=TBLEMPLOYEE.bloodID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblBloodType.CDESC"
        GridDetaily(sSQL, "Blood Type")
    End Sub

    Private Sub lblMeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMeal.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetMealHabit
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblMHabit.sDesc AS 'Meal Habbit',COUNT(TBLEMPLOYEE.MHabitID) AS 'Employee Count' FROM TBLEMPLOYEE,tblMHabit WHERE tblMHabit.sCode=TBLEMPLOYEE.MHabitID AND tblMHabit.STATUS=0  and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblMHabit.sCode,tblMHabit.sDesc"
        GridSetupCount(sSQL, "Meal Habbit")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Meal Habbit',tblMHabit.sDesc AS 'Meal Habbit' FROM TBLEMPLOYEE,tblMHabit WHERE tblMHabit.sCode=TBLEMPLOYEE.MHabitID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblMHabit.sDesc"
        GridDetaily(sSQL, "Meal Habbit")
    End Sub

    Private Sub lblDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDocument.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetDocType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblDocType.cDesc AS 'Document Type',COUNT(TBLEMPLOYEE.docID) AS 'Employee Count' FROM TBLEMPLOYEE,tblDocType WHERE tblDocType.cID=TBLEMPLOYEE.docID AND tblDocType.STATUS=0 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblDocType.cID,tblDocType.CDesc"
        GridSetupCount(sSQL, "Document Type")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Document Type',tblDocType.CDesc AS 'Meal Habbit' FROM TBLEMPLOYEE,tblDocType WHERE tblDocType.cID=TBLEMPLOYEE.MHabitID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  ORDER BY tblDocType.CDesc"
        GridDetaily(sSQL, "Document Type")
    End Sub

    Private Sub lblElectrorate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblElectrorate.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetElectorate
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblELECTORATE.cDesc AS 'Electorate',COUNT(TBLEMPLOYEE.electoID) AS 'Employee Count' FROM TBLEMPLOYEE,tblELECTORATE WHERE tblELECTORATE.cID=TBLEMPLOYEE.electoID AND tblELECTORATE.STATUS=0 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  GROUP BY tblELECTORATE.cID,tblELECTORATE.CDesc"
        GridSetupCount(sSQL, "Electorate")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblELECTORATE.CDesc AS 'Electorate' FROM TBLEMPLOYEE,tblELECTORATE WHERE tblELECTORATE.cID=TBLEMPLOYEE.electoID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  ORDER BY tblELECTORATE.CDesc"
        GridDetaily(sSQL, "Electorate")
    End Sub

    Private Sub lblTransport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTransport.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetTransportType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblTransportType.cDesc AS 'Transport Type',COUNT(TBLEMPLOYEE.transpID) AS 'Employee Count' FROM TBLEMPLOYEE,tblTransportType WHERE tblTransportType.cID=TBLEMPLOYEE.transpID AND tblTransportType.STATUS=0 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblTransportType.cID,tblTransportType.CDesc"
        GridSetupCount(sSQL, "Transport Type")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Transport Type',tblTransportType.CDesc AS 'Electorate' FROM TBLEMPLOYEE,tblTransportType WHERE tblTransportType.cID=TBLEMPLOYEE.MHabitID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblTransportType.CDesc"

        GridDetaily(sSQL, "Transport Type")
    End Sub

    Private Sub lblRaces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRaces.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetRace
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblrace.cDesc AS 'Race',COUNT(TBLEMPLOYEE.raceID) AS 'Employee Count' FROM TBLEMPLOYEE,tblrace WHERE tblrace.cID=TBLEMPLOYEE.raceID AND tblrace.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') GROUP BY tblrace.cID,tblrace.CDesc"
        GridSetupCount(sSQL, "Races")

        sSQL = "select " & sqlTagName & "," & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblrace.CDesc AS 'Race' FROM TBLEMPLOYEE,tblrace WHERE tblrace.cID=TBLEMPLOYEE.raceID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "') ORDER BY tblrace.CDesc"
        GridDetaily(sSQL, "Races")
    End Sub

    Private Sub lblTitles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitles.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetTitle
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetTitle.titleDesc AS 'Title',COUNT(TBLEMPLOYEE.titleID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetTitle WHERE tblSetTitle.titleid=TBLEMPLOYEE.titleid AND tblSetTitle.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetTitle.titleID,tblSetTitle.titleDesc"
        GridSetupCount(sSQL, "Title")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetTitle.titleDesc AS 'Title' FROM TBLEMPLOYEE,tblSetTitle WHERE tblSetTitle.titleID=TBLEMPLOYEE.titleID AND TBLEMPLOYEE.EMPSTATUS<>9  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  ORDER BY tblSetTitle.titleDesc"
        GridDetaily(sSQL, "Title")
    End Sub

    Private Sub lblCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCategory.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCategory
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSEtEmpCategory.CATDesc AS 'Category',COUNT(TBLEMPLOYEE.catid) AS 'Employee Count' FROM TBLEMPLOYEE,tblSEtEmpCategory WHERE tblSEtEmpCategory.catid=TBLEMPLOYEE.catid AND tblSEtEmpCategory.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSEtEmpCategory.catID,tblSEtEmpCategory.catDesc"
        GridSetupCount(sSQL, "Category")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSEtEmpCategory.catDesc AS 'Category' FROM TBLEMPLOYEE,tblSEtEmpCategory WHERE tblSEtEmpCategory.catID=TBLEMPLOYEE.catID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSEtEmpCategory.catDesc"
        GridDetaily(sSQL, "Category")
    End Sub

    Private Sub lblEmpTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEmpTypes.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetEmpTypes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetEmpType.TDesc AS 'Employee Type',COUNT(TBLEMPLOYEE.emptypeid) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetEmpType WHERE tblSetEmpType.typeid=TBLEMPLOYEE.emptypeid AND tblSetEmpType.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetEmpType.typeID,tblSetEmpType.tDesc"
        GridSetupCount(sSQL, "Employee Type")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetEmpType.tDesc AS 'Employee Type' FROM TBLEMPLOYEE,tblSetEmpType WHERE tblSetEmpType.typeID=TBLEMPLOYEE.emptypeid AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetEmpType.tDesc"
        GridDetaily(sSQL, "Employee Type")
    End Sub

    Private Sub lblReligion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblReligion.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetReligion
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetReligion.religDesc AS 'Religion',COUNT(TBLEMPLOYEE.religID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetReligion WHERE tblSetReligion.religID=TBLEMPLOYEE.religID AND tblSetReligion.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetReligion.religID,tblSetReligion.religDesc"
        GridSetupCount(sSQL, "Religion")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetReligion.religDesc AS 'Religion' FROM TBLEMPLOYEE,tblSetReligion WHERE tblSetReligion.religID=TBLEMPLOYEE.religID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetReligion.religDesc"
        GridDetaily(sSQL, "Religion")
    End Sub

    Private Sub lblProvince_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProvince.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetProvince
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetProvince.cDesc AS 'Province',COUNT(TBLEMPLOYEE.ProvID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetProvince WHERE tblSetProvince.cID=TBLEMPLOYEE.ProvID AND tblSetProvince.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetProvince.cID,tblSetProvince.cDesc"
        GridSetupCount(sSQL, "Province")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetProvince.cDesc AS 'Province' FROM TBLEMPLOYEE,tblSetProvince WHERE tblSetProvince.cID=TBLEMPLOYEE.ProvID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetProvince.cDesc"
        GridDetaily(sSQL, "Province")
    End Sub

    Private Sub lblCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCity.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCities
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblCities.cDesc AS 'City',COUNT(TBLEMPLOYEE.cityID) AS 'Employee Count' FROM TBLEMPLOYEE,tblCities WHERE tblCities.cID=TBLEMPLOYEE.cityID AND tblCities.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  GROUP BY tblCities.cID,tblCities.cDesc"
        GridSetupCount(sSQL, "City")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblCities.cDesc AS 'City' FROM TBLEMPLOYEE,tblCities WHERE tblCities.cID=TBLEMPLOYEE.cityID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "')  ORDER BY tblCities.cDesc"
        GridDetaily(sSQL, "City")
    End Sub

    Private Sub lblProcesCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProcesCategory.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetProcesCategory
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetPrCategory.catDesc AS 'Process Category',COUNT(TBLEMPLOYEE.prCatID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetPrCategory WHERE tblSetPrCategory.catID=TBLEMPLOYEE.prCatID AND tblSetPrCategory.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetPrCategory.catID,tblSetPrCategory.catDesc"
        GridSetupCount(sSQL, "Process Category")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetPrCategory.catDesc AS 'Process Category' FROM TBLEMPLOYEE,tblSetPrCategory WHERE tblSetPrCategory.catID=TBLEMPLOYEE.prCatID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetPrCategory.catDesc"
        GridDetaily(sSQL, "Process Category")
    End Sub

    Private Sub lblPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPay.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetPayCentre
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetPCentre.pDesc AS 'Pay Center',COUNT(TBLEMPLOYEE.payID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetPCentre WHERE tblSetPCentre.pID=TBLEMPLOYEE.payID AND tblSetPCentre.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetPCentre.pID,tblSetPCentre.pDesc"
        GridSetupCount(sSQL, "Pay Center")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetPCentre.pDesc AS 'Pay Center' FROM TBLEMPLOYEE,tblSetPCentre WHERE tblSetPCentre.pID=TBLEMPLOYEE.payID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetPCentre.pDesc"
        GridDetaily(sSQL, "Pay Center")
    End Sub

    Private Sub lblCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCost.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCostCentre
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetCCentre.cntDesc AS 'Cost Center',COUNT(TBLEMPLOYEE.costID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetCCentre WHERE tblSetCCentre.cntID=TBLEMPLOYEE.costID AND tblSetCCentre.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetCCentre.cntID,tblSetCCentre.cntDesc"
        GridSetupCount(sSQL, "Cost Center")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetCCentre.cntDesc AS 'Cost Center' FROM TBLEMPLOYEE,tblSetCCentre WHERE tblSetCCentre.cntID=TBLEMPLOYEE.costID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetCCentre.cntDesc"
        GridDetaily(sSQL, "Cost Centers")
    End Sub

    Private Sub lblBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBank.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetBanks1
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblbanks.bankname AS 'Bank Name',COUNT(TBLEMPLOYEE.costID) AS 'Employee Count' FROM TBLEMPLOYEE,tblbanks WHERE tblbanks.bankid=TBLEMPLOYEE.bankid AND tblbanks.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblbanks.bankID,tblbanks.bankName"
        GridSetupCount(sSQL, "Bank Name")

        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblbanks.bankName AS 'Bank Name' FROM TBLEMPLOYEE,tblbanks WHERE tblbanks.bankid=TBLEMPLOYEE.bankid AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblbanks.bankName"
        GridDetaily(sSQL, "Bank Name")
    End Sub

    Private Sub lblGender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGender.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetGender
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblgender.genDesc AS 'Gender',COUNT(TBLEMPLOYEE.genderID) AS 'Employee Count' FROM TBLEMPLOYEE,tblgender WHERE tblgender.genid=TBLEMPLOYEE.genderid AND tblgender.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblgender.genid,tblgender.gendesc"
        GridSetupCount(sSQL, "Gender")

        sSQL = "select " & sqlTagName & ", tblEmployee.dispName AS 'Employee Name',tblgender.gendesc AS 'Gender' FROM TBLEMPLOYEE,tblgender WHERE tblgender.genID=TBLEMPLOYEE.genderid AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblgender.genDesc"
        GridDetaily(sSQL, "Gender")
    End Sub

    Private Sub lblShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShifts.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetShiftType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetShiftH.shiftName AS 'Shift',COUNT(TBLEMPLOYEE.shiftID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetShiftH WHERE tblSetShiftH.shiftID=TBLEMPLOYEE.shiftID AND tblSetShiftH.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetShiftH.shiftID,tblSetShiftH.shiftname"
        GridSetupCount(sSQL, "Shift")

        sSQL = "select " & sqlTagName & ", tblEmployee.dispName AS 'Employee Name',tblSetShiftH.shiftName AS 'Shift' FROM TBLEMPLOYEE,tblSetShiftH WHERE tblSetShiftH.shiftID=TBLEMPLOYEE.shiftID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetShiftH.shiftName"
        GridDetaily(sSQL, "Shift")
    End Sub

    Private Sub lblRelationship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRelationship.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetRelationshpTypes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblSetShiftH.shiftName AS 'Shift',COUNT(TBLEMPLOYEE.shiftID) AS 'Employee Count' FROM TBLEMPLOYEE,tblSetShiftH WHERE tblSetShiftH.shiftID=TBLEMPLOYEE.shiftID AND tblSetShiftH.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblSetShiftH.shiftID,tblSetShiftH.shiftname"
        GridSetupCount(sSQL, "Shift")

        sSQL = "select " & sqlTagName & ", tblEmployee.dispName AS 'Employee Name',tblSetShiftH.shiftName AS 'Shift' FROM TBLEMPLOYEE,tblSetShiftH WHERE tblSetShiftH.shiftID=TBLEMPLOYEE.shiftID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetShiftH.shiftName"
        GridDetaily(sSQL, "Shift")
    End Sub

    Private Sub lblCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCurrency.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetCurrency
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        sSQL = "SELECT tblCurrency.cName AS 'Currency',COUNT(TBLEMPLOYEE.currencyID) AS 'Employee Count' FROM TBLEMPLOYEE,tblCurrency WHERE tblCurrency.aID=TBLEMPLOYEE.currencyID AND tblCurrency.cSTATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblCurrency.aID,tblCurrency.cname"
        GridSetupCount(sSQL, "Currency")

        sSQL = "select " & sqlTagName & ", tblEmployee.dispName AS 'Employee Name',tblCurrency.cName AS 'Currency' FROM TBLEMPLOYEE,tblCurrency WHERE tblCurrency.aID=TBLEMPLOYEE.currencyID AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblCurrency.cName"
        GridDetaily(sSQL, "Currency")
    End Sub

    Private Sub lblBenifitis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblBenifitis.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetBenefits
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)
        frmReg.Show()
        sSQL = " SELECT tblSetBenefits.descr ,COUNT(tblBenefits.benID )  from tblSetBenefits,tblBenefits Where tblSetBenefits.benID = tblBenefits.benID AND tblBenefits.Status = 0  GROUP BY tblBenefits.benID,tblBenefits.EmpID, tblSetBenefits.descr"
        GridSetupCount(sSQL, "Benefits")

        sSQL = "    select RIGHT('00000'+CAST(tblEmployee.EnrolNo AS VARCHAR(6)),6) as 'EnrolNo',tblEmployee.dispName AS 'Employee Name',tblSetBenefits.descr AS 'Benifits Category' FROM tblEmployee,tblSetBenefits,tblBenefits  WHERE  tblEmployee.regid = tblBenefits.EmpID AND  tblSetBenefits.benID =  tblBenefits.benID  AND tblBenefits.Status = 0 "
        GridDetaily(sSQL, "Benefits")
    End Sub

    Private Sub lblPostal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPostal.Click

    End Sub

    Private Sub lblShiftPatern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblShiftPatern.Click
        Me.pnlAllData.Controls.Clear()
        Dim frmReg As New frmSetRosterPatern
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximize
        frmReg.TopLevel = False
        Me.pnlAllData.Controls.Add(frmReg)

        frmReg.Show()

        'sSQL = "SELECT tblgender.genDesc AS 'Gender',COUNT(TBLEMPLOYEE.genderID) AS 'Employee Count' FROM TBLEMPLOYEE,tblgender WHERE tblgender.genid=TBLEMPLOYEE.genderid AND tblgender.STATUS=0  AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') GROUP BY tblgender.genid,tblgender.gendesc"
        'GridSetupCount(sSQL, "Gender")

        'sSQL = "select " & sqlTagName & ", tblEmployee.dispName AS 'Employee Name',tblgender.gendesc AS 'Gender' FROM TBLEMPLOYEE,tblgender WHERE tblgender.genID=TBLEMPLOYEE.genderid AND TBLEMPLOYEE.EMPSTATUS<>9 and TBLEMPLOYEE.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblgender.genDesc"
        'GridDetaily(sSQL, "Gender")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'frmEmployeeInfo.pnlAllEmpInfo.Height = 646
        'Me.Close()
    End Sub

    Private Sub ProcessControls(ByVal ctrlContainer As Control)
        For Each ctrl As Control In ctrlContainer.Controls
            If TypeOf ctrl Is Label Then
                If ctrl.Tag = 2 Then
                    ctrl.ForeColor = clrDefaultColor
                End If
            End If
            ' If the control has children, 
            ' recursively call this function 
            If ctrl.HasChildren Then
                ProcessControls(ctrl)
            End If
        Next
    End Sub

    Private Sub lblBranch_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTransport.MouseClick, lblTitles.MouseClick, lblShifts.MouseClick, lblShiftPatern.MouseClick, lblReligion.MouseClick, lblRelationship.MouseClick, lblRaces.MouseClick, lblProvince.MouseClick, lblProcesCategory.MouseClick, lblBenifitis.MouseClick, lblPostal.MouseClick, lblPay.MouseClick, lblMeal.MouseClick, lblGender.MouseClick, lblEmpTypes.MouseClick, lblElectrorate.MouseClick, lblEducation.MouseClick, lblDocument.MouseClick, lblDesignation.MouseClick, lblDeparment.MouseClick, lblCurrency.MouseClick, lblCost.MouseClick, lblCivil.MouseClick, lblCity.MouseClick, lblCategory.MouseClick, lblBranch.MouseClick, lblBlood.MouseClick, lblBank.MouseClick
        ProcessControls(TableLayoutPanel4)
    End Sub

    Private Sub lblBranch_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBranch.MouseUp
        lblBranch.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblDeparment_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDeparment.MouseUp
        lblDeparment.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblDesignation_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDesignation.MouseUp
        lblDesignation.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblCivil_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCivil.MouseUp
        lblCivil.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblEducation_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEducation.MouseUp
        lblEducation.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblBlood_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBlood.MouseUp
        lblBlood.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblMeal_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblMeal.MouseUp
        lblMeal.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblDocument_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblDocument.MouseUp
        lblDocument.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblElectrorate_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblElectrorate.MouseUp
        lblElectrorate.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblTransport_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTransport.MouseUp
        lblTransport.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblRaces_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblRaces.MouseUp
        lblRaces.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblTitles_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTitles.MouseUp
        lblTitles.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblPostal_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblPostal.MouseUp
        lblPostal.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblCurrency_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCurrency.MouseUp
        lblCurrency.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblCategory_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCategory.MouseUp
        lblCategory.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblEmpTypes_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblEmpTypes.MouseUp
        lblEmpTypes.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblShifts_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShifts.MouseUp
        lblShifts.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblReligion_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblReligion.MouseUp
        lblReligion.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblProvince_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblProvince.MouseUp
        lblProvince.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblCity_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCity.MouseUp
        lblCity.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblProcesCategory_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblProcesCategory.MouseUp
        lblProcesCategory.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblPay_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblPay.MouseUp
        lblPay.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblCost_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCost.MouseUp
        lblCost.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblBank_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBank.MouseUp
        lblBank.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblGender_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblGender.MouseUp
        lblGender.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblRelationship_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblRelationship.MouseUp
        lblRelationship.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblPreWorked_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBenifitis.MouseUp
        lblBenifitis.ForeColor = clrSelcetedColor
    End Sub

    Private Sub lblShiftPatern_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblShiftPatern.MouseUp
        lblShiftPatern.ForeColor = clrSelcetedColor
    End Sub

  
End Class