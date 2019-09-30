Imports System.Data.SqlClient


Public Class frmHRMInfomation

   
    Public myString As String
    Public myStrings As String
    Public rdValue As String
    'Public itemChecked As Object
    Dim StrProvinceID As String = ""
    Dim StrCityID As String = ""
    Dim StrAllDoc As String = ""
    Dim StrDocID As String = ""

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        strEditSetings = "BloodGroup"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        strEditSetings = "Meal"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        strEditSetings = "Religion"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        strEditSetings = "Race"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        strEditSetings = "PreWorked"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click, pbAddDS.Click, pbGNAdd.Click
        strEditSetings = "Province"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        strEditSetings = "City"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        strEditSetings = "PostalCode"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        strEditSetings = "Electrorate"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        strEditSetings = "TransportMode"

        frmMainAttendance.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        frmMainAttendance.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        ''Dim crtl As Control
        ''For Each crtl In Me.Controls
        ''    If TypeOf crtl Is TextBox Then crtl.Text = ""
        ''Next



        ListCombo(cmbBlood, "select * from tblBloodType order by cDesc", "cDesc")
        ListCombo(cmbReligiontxt, "select * from tblsetReligion order by ReligDesc", "ReligDesc")
        ListCombo(cmbProvincetxt, "select * from tblSetProvince order by cDesc", "cDesc")
        ListCombo(cmbMealtxt, "select * from tblMHabit order by Scode", "sDesc")
        ListCombo(cmbRacetxt, "select * from tblRace order by cID", "cDesc")
        ListCombo(cmbElectorate, "select * from tblElectorate order by cDesc", "cDesc")
        ListCombo(cmbPreWork, "select * from tblSetPreWorked order by cDesc", "cDesc")
        ListCombo(cmbCitytxt, "select * from tblCities order by cID", "cDesc")
        ListCombo(cmbPostalCod, "select * from tblPostalCodes order by area", "area")
        ListCombo(cmbTransport, "select * from tblTransportType order by cDesc", "cDesc")
        ListCombo(cmbDistrict, " select * from tblCities where Status = 0 order by cDesc", "cDesc")
        ListCombo(cboxDSArea, " select * from tblDiviSecretariat where Status = 0 order by cDesc", "cDesc")
        ListCombo(cboxGNArea, " select * from tblGramaDivision where Status = 0 order by cDesc", "cDesc")


        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        ' sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS 'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate FROM tblEmployee LEFT OUTER JOIN tblBloodType ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        'StrLvID = fk_ReadGRID(0)
        txtHeighttxt.Text = fk_ReadGRID(1)
        txtWeighttxt.Text = fk_ReadGRID(2)
        txtDistancetxt.Text = fk_ReadGRID(3)
        cmbBlood.Text = fk_ReadGRID(4)
        cmbReligiontxt.Text = fk_ReadGRID(5)
        cmbProvincetxt.Text = fk_ReadGRID(6)
        cmbCitytxt.Text = fk_ReadGRID(7)
        cmbMealtxt.Text = fk_ReadGRID(8)
        cmbRacetxt.Text = fk_ReadGRID(9)
        cmbElectorate.Text = fk_ReadGRID(10)
        cmbPostalCod.Text = fk_ReadGRID(11)
        cmbTransport.Text = fk_ReadGRID(12)
        cboxDSArea.Text = fk_ReadGRID(14)
        cboxGNArea.Text = fk_ReadGRID(15)

        Dim dtRegDate As Date = fk_ReadGRID(13)
        'dtRegDate = IIf(IsDBNull(drShw.Item("DofB")), DateSerial(1900, 1, 1), drShw.Item("DofB"))
        Dim intAge As Integer = DateDiff(DateInterval.Month, dtRegDate, dtWorkingDate)
        Dim intYear As Integer = intAge \ 12
        Dim intMonth As Integer = intAge Mod 12
        txtServAge.Text = intYear & " Y : " & intMonth & " M "

        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)
        cmbDistrict.Text = fk_ReadGRID(8)


        txtServAge.Enabled = False
        ViewDocuments()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        If UP("Employee HRM Info", "Edit employee blood type") = False Then Exit Sub
        strExsisted = cmbBlood.Text
        strExsistedCode = fk_RetString("SELECT cID FROM tblBloodType WHERE cDesc='" & Trim(cmbBlood.Text) & "'")
        pnlMostRight.Visible = True

        StrTTrMode = "007"
        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmChgCodes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized
        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        'ViewDocuments()
        Dim StrAllDocs As String = ""
        'StrAllBranches = fk_getGridCLICK(dgvBranch, 0, 1)
        'Dim sqlQRY As String = "UPDATE tblUserViewLv SET vBranchID = '" & StrAllBranches & "' WHERE vID = '" & StrLvID & "'"
        'FK_EQ(sqlQRY, "S", "", False, True, True)

        Dim bolEx As Boolean = False

        StrAllDocs = fk_getGridCLICK(dgvDocumentk, 0, 1)
        sSQL = "SELECT regID FROM tblDocumentCollected WHERE regID='" & StrEmployeeID & "'"
        bolEx = fk_CheckEx(sSQL)
        If bolEx = True Then
            sSQL = "UPDATE tblDocumentCollected SET allDocIDs = '" & StrAllDocs & "' WHERE regID = '" & StrEmployeeID & "'"
            FK_EQ(sSQL, "E", "", False, True, True)
        Else
            sSQL = "INSERT INTO tblDocumentCollected (regID,allDocIDs,crUser,status) VALUES ('" & StrEmployeeID & "','" & StrAllDocs & "','" & StrUserID & "', 0)"
            FK_EQ(sSQL, "S", "", False, True, True)
        End If

    End Sub

    Private Sub ViewDocuments()
        sSQL = "select 'False',cID,cDesc from tblDocType WHERE status=0 Order By cDesc"
        Load_InformationtoGrid(sSQL, dgvDocumentk, 3)
        If StrEmployeeID = "" Then Exit Sub
        sSQL = "select regID,allDocIDs from tblDocumentCollected WHERE regID= '" & StrEmployeeID & "'"
        fk_Return_MultyString(sSQL, 2)
        StrDocID = fk_ReadGRID(0)
        StrAllDoc = fk_ReadGRID(1)

        If StrAllDoc <> "" Then fk_SetGridCLICK(dgvDocumentk, 0, 1, StrAllDoc)
    End Sub

    Private Sub cmbProvincetxt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincetxt.SelectedIndexChanged, cboxDSArea.SelectedIndexChanged, cboxGNArea.SelectedIndexChanged
        'StrProvinceID = fk_RetString("SELECT cID FROM tblSetProvince WHERE cDesc = '" & cmbProvincetxt.Text & "' AND CompID = '" & StrCompID & "'")
        ' ListCombo(cmbCitytxt, "select * from tblCities WHERE ProvinceID= '" & StrProvinceID & "' order by cDesc", "cDesc")
        ' ListCombo(cmbCitytxt, "select * from tblCities order by cDesc", "cDesc")

    End Sub

    Private Sub cmbCitytxt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCitytxt.SelectedIndexChanged
        ' StrCityID = fk_RetString("SELECT short_code FROM tblCities WHERE cDesc = '" & cmbCitytxt.Text & "' AND CompID = '" & StrCompID & "'")
        ' sSQL = "select * from tblPostalCodes WHERE short_code= '" & StrCityID & "' order by short_code"
        sSQL = "select * from tblPostalCodes order by short_code"
        ListCombo(cmbPostalCod, sSQL, "Area")
    End Sub

    Private Sub txtHeighttxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHeighttxt.LostFocus
        If Val(txtHeighttxt.Text) > 200 Then MessageBox.Show("Please check the entered value as height again, It seems to be abnormal.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub txtWeighttxt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeighttxt.LostFocus
        If Val(txtWeighttxt.Text) > 150 Then MessageBox.Show("Please check the entered value as weight again, It seems to be abnormal.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub picECat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picECat.Click
        If UP("Employee HRM Info", "Edit employee meal habbit") = False Then Exit Sub
        strExsisted = cmbMealtxt.Text
        strExsistedCode = fk_RetString("SELECT sCode FROM tblMHabit WHERE sDesc='" & Trim(cmbMealtxt.Text) & "'")

        pnlMostRight.Visible = True

        StrTTrMode = "008"
        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmChgCodes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized
        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        strExsisted = cmbReligiontxt.Text
        strExsistedCode = fk_RetString("SELECT religID FROM tblSetReligion WHERE religDesc='" & Trim(cmbReligiontxt.Text) & "'")

        pnlMostRight.Visible = True

        StrTTrMode = "009"
        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmChgCodes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized
        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub picEType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEType.Click
        If UP("Employee HRM Info", "Edit employee race") = False Then Exit Sub
        strExsisted = cmbRacetxt.Text
        strExsistedCode = fk_RetString("SELECT cID FROM tblRace WHERE cDesc='" & Trim(cmbRacetxt.Text) & "'")
        pnlMostRight.Visible = True

        StrTTrMode = "010"
        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmChgCodes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized
        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        If UP("Employee HRM Info", "Edit employee pre worked company") = False Then Exit Sub
        strExsisted = cmbPreWork.Text
        strExsistedCode = fk_RetString("SELECT cID FROM tblSetPreWorked WHERE cDesc='" & Trim(cmbPreWork.Text) & "'")

        pnlMostRight.Visible = True

        StrTTrMode = "011"
        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmChgCodes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized
        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub


    Private Sub picEDesig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbGNEdit.Click
        strExsisted = cboxGNArea.Text
        strExsistedCode = fk_RetString("select gsdID from  tblGramaDivision where cDesc = '" & cboxGNArea.Text & "'")

        ' viewEditPanel()

        StrTTrMode = "027"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cboxGNArea.Text = fk_ReadGRID(15)

    End Sub

    Private Sub PicEDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEDept.Click
        If UP("Employee HRM Info", "Edit employee city") = False Then Exit Sub
        strExsisted = cmbCitytxt.Text
        strExsistedCode = fk_RetString("SELECT cID FROM tblCities WHERE cDesc='" & Trim(cmbCitytxt.Text) & "'")

        'pnlMostRight.Visible = True

        StrTTrMode = "013"
        'Me.pnlEditHistory.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlEditHistory.Controls.Add(frmReg)

        'frmReg.Show()



        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cmbCitytxt.Text = fk_ReadGRID(7)
      
    End Sub

    Private Sub picEBr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEBr.Click
        If UP("Employee HRM Info", "Edit employee postalcode") = False Then Exit Sub
        'Dim strCity As String = fk_RetString("SELECT short_code FROM tblCities WHERE cDesc='" & Trim(cmbCitytxt.Text) & "'")
        strExsisted = cmbPostalCod.Text
        strExsistedCode = fk_RetString("SELECT postal_id FROM tblPostalCodes WHERE Area='" & Trim(cmbPostalCod.Text) & "'")

        pnlMostRight.Visible = True

        StrTTrMode = "015"
        'Me.pnlEditHistory.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlEditHistory.Controls.Add(frmReg)

        'frmReg.Show()


       
        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cmbPostalCod.Text = fk_ReadGRID(11)
      
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        If UP("Employee HRM Info", "Edit employee electorate") = False Then Exit Sub
        strExsisted = cmbElectorate.Text
        strExsistedCode = fk_RetString("SELECT cID FROM tblElectorate WHERE cDesc='" & Trim(cmbElectorate.Text) & "'")

        'pnlMostRight.Visible = True

        StrTTrMode = "016"
        'Me.pnlEditHistory.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlEditHistory.Controls.Add(frmReg)

        'frmReg.Show()


        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cmbElectorate.Text = fk_ReadGRID(10)
       
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        If UP("Employee HRM Info", "Edit employee transport mode") = False Then Exit Sub
        strExsisted = cmbTransport.Text
        strExsistedCode = fk_RetString("SELECT cID FROM tblTransportType WHERE cDesc='" & Trim(cmbTransport.Text) & "'")

        'pnlMostRight.Visible = True

        StrTTrMode = "017"
        'Me.pnlEditHistory.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlEditHistory.Controls.Add(frmReg)

        'frmReg.Show()

        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cmbTransport.Text = fk_ReadGRID(12)
       
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmHRISDashboard)
    End Sub

    Private Sub pbHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbHeight.Click
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        sSQL = "UPDATE tblEmployee SET height='" & txtHeighttxt.Text & "' WHERE RegID='" & StrEmployeeID & "'; INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & txtHeighttxt.Text & "','Change Employee Height','021','','" & StrUserID.Substring(0, 3) & "',getdate (), '" & strExsisted & "','')"
        'Update tblControl Table `
        sSQL = sSQL & " UPDATE tblControl SET cTrCount = cTrCount + 1"
        FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub pbWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbWeight.Click
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        sSQL = "UPDATE tblEmployee SET weight='" & txtWeighttxt.Text & "' WHERE RegID='" & StrEmployeeID & "'; INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & txtWeighttxt.Text & "','Change Employee weight','022','','" & StrUserID.Substring(0, 3) & "',getdate (), '" & strExsisted & "','')"
        'Update tblControl Table `
        sSQL = sSQL & " UPDATE tblControl SET cTrCount = cTrCount + 1"
        FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub pbDistan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDistan.Click
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        sSQL = "UPDATE tblEmployee SET distance='" & txtDistancetxt.Text & "' WHERE RegID='" & StrEmployeeID & "'; INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & txtDistancetxt.Text & "','Change Employee distance','023','','" & StrUserID.Substring(0, 3) & "',getdate (), '" & strExsisted & "','')"
        'Update tblControl Table `
        sSQL = sSQL & " UPDATE tblControl SET cTrCount = cTrCount + 1"
        FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub frmHRMInfomation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ControlHandlers(Me)

        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub pbDistcEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDistcEdit.Click
        '  If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        strExsisted = cmbDistrict.Text
        strExsistedCode = fk_RetString("select cID from tblCities where cDesc  = '" & cmbDistrict.Text & "'")

        ' viewEditPanel()

        StrTTrMode = "023"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)
        cmbDistrict.Text = fk_ReadGRID(8)
    End Sub

    Private Sub pbEditDS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEditDS.Click
        strExsisted = cboxDSArea.Text
        strExsistedCode = fk_RetString("select DSID from tblDiviSecretariat where cDesc = '" & cboxDSArea.Text & "'")

        ' viewEditPanel()

        StrTTrMode = "026"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cboxDSArea.Text = fk_ReadGRID(14)
      
      

    End Sub

    Private Sub picEDesig_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEDesig.Click
        strExsisted = cmbProvincetxt.Text
        strExsistedCode = fk_RetString("select cID from tblSetProvince where status <> 0 and  cDesc =  '" & cmbProvincetxt.Text & "'")

        ' viewEditPanel()

        StrTTrMode = "012"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmChgCodes
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmChgCodes.ShowDialog()

        sSQL = "SELECT tblEmployee.regID,tblEmployee.height,tblEmployee.weight,tblEmployee.distance,tblBloodType.cdesc as 'Blood Type',tblsetReligion.religDesc as 'Religion',tblSetProvince.cDesc as 'Province', tblCities.cDesc as 'City',tblMHabit.sDesc as 'Meal',tblRace.cDesc AS 'Race',tblElectorate.cDesc AS 'Electorate',tblPostalCodes.Area AS  'Village',tblTransportType.cDesc AS 'Transport',tblEmployee.regDate ,tblDiviSecretariat.cDesc AS 'DSDivision',tblGramaDivision.cDesc AS 'GnDivision' FROM tblEmployee LEFT OUTER JOIN tblBloodType  ON tblBloodType.cID=tblEmployee.bloodID LEFT OUTER JOIN tblsetReligion ON tblsetReligion.religID=tblEmployee.religID LEFT OUTER JOIN tblSetProvince ON tblSetProvince.cID=tblEmployee.ProvID LEFT OUTER JOIN tblCities ON  tblCities.cID=tblEmployee.cityID LEFT OUTER JOIN tblMHabit ON tblMHabit.sCode=tblEmployee.MHabitID   LEFT OUTER JOIN tblRace ON tblRace.cID=tblEmployee.raceID LEFT OUTER JOIN tblElectorate ON tblElectorate.cID=tblEmployee.electoID LEFT OUTER JOIN tblPostalCodes ON tblPostalCodes.postal_id=tblEmployee.postalID LEFT OUTER JOIN tblTransportType ON tblTransportType.cID=tblEmployee.transpID  LEFT OUTER JOIN tblDiviSecretariat ON tblDiviSecretariat.DSID = tblemployee.DSDivision  LEFT OUTER JOIN  tblGramaDivision ON tblGramaDivision.gsdID = tblEmployee.GnDivision   WHERE tblEmployee.regID='" & StrEmployeeID & "' "
        fk_Return_MultyString(sSQL, 16)
        cmbProvincetxt.Text = fk_ReadGRID(6)

 
    End Sub
End Class
