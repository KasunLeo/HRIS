Imports System.Data.SqlClient

Public Class frmHRMAdtionalInfomation

   
    Public Sub refrash()

        ListCombo(cmbAct, "select * from tblSetActTypesHRIS where Status = 0 order by Dscrb", "Dscrb")
        ListCombo(cmbSubCat, "select * from tblSetSubCatHRIS where Status = 0 order by Dscrb", "Dscrb")
        ListCombo(cmbNearestCity, "select * from tblSetNearsCitysHRIS where Status = 0 order by Dscrb", "Dscrb")
        ListCombo(cmbDisasterArea, " select * from tblSetDisasterTypesHRIS where Status = 0 order by Dscrb", "Dscrb")


        Dim RegDate As DateTime = "1900-01-01"
        Dim O_regDate As DateTime = "1900-01-01"
        CboxNewEmployee.CheckState = fk_sqlDbl("select IsOLDEmp from tblEmployee  where RegID = '" & StrEmployeeID & "'")
        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)

        txtEpfNo.Text = fk_ReadGRID(2)
        txtName.Text = fk_ReadGRID(4)
        'dtpFirstJoin.Value = fk_ReadGRID(3)
        cmbAct.Text = fk_ReadGRID(6)
        cmbSubCat.Text = fk_ReadGRID(7)
        cmbNearestCity.Text = fk_ReadGRID(9)
        cmbDisasterArea.Text = fk_ReadGRID(10)

        RegDate = fk_ReadGRID(0)
        O_regDate = fk_ReadGRID(3)
        Dim crDate As DateTime = Format(Date.Now(), "ddMMMyyyy")

        If fk_ReadGRID(5) = 1 Then
            dtpFirstJoin.Value = fk_ReadGRID(3)
            Dim intAge As Integer = DateDiff(DateInterval.Month, O_regDate, crDate)
            Dim intYear As Integer = intAge \ 12
            Dim intMonth As Integer = intAge Mod 12
            txtAgeFromFirstJoin.Text = intYear & " Y : " & intMonth & " M "
        Else
            dtpFirstJoin.Value = fk_ReadGRID(0)
            Dim intAge As Integer = DateDiff(DateInterval.Month, RegDate, crDate)
            Dim intYear As Integer = intAge \ 12
            Dim intMonth As Integer = intAge Mod 12
            txtAgeFromFirstJoin.Text = intYear & " Y : " & intMonth & " M "
        End If

        'Dim intAge As Integer = DateDiff(DateInterval.Month, RegDate, O_regDate)
        'Dim intYear As Integer = intAge \ 12
        'Dim intMonth As Integer = intAge Mod 12
        'txtAgeFromFirstJoin.Text = intYear & " Y : " & intMonth & " M "

        pnlMostRight.Visible = False

    End Sub

    Private Sub pbHeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbActEdit.Click
        '  If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        strExsisted = cmbAct.Text
        strExsistedCode = fk_RetString("select ActID from tblSetActTypesHRIS WHERE Dscrb = '" & cmbAct.Text & "'")

        'viewEditPanel()

        StrTTrMode = "021"
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
        cmbAct.Text = fk_ReadGRID(6)
    End Sub

    Private Sub pbSubCatEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSubCatEdit.Click
        '  If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        strExsisted = cmbSubCat.Text
        strExsistedCode = fk_RetString("select CatID from tblSetSubCatHRIS WHERE Dscrb = '" & cmbSubCat.Text & "'")

        ' viewEditPanel()

        StrTTrMode = "022"
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
        cmbSubCat.Text = fk_ReadGRID(7)  
    End Sub

   

    Private Sub pbNearCtyEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNearCtyEdit.Click
        '  If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        strExsisted = cmbNearestCity.Text
        strExsistedCode = fk_RetString("select CityID from tblSetNearsCitysHRIS where  Dscrb = '" & cmbNearestCity.Text & "'")

        ' viewEditPanel()

        StrTTrMode = "024"
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
        cmbNearestCity.Text = fk_ReadGRID(9)     
    End Sub

    Private Sub pbDisasEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbDisasEdit.Click
        '  If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        strExsisted = cmbDisasterArea.Text
        strExsistedCode = fk_RetString("SELECT DisID FROM tblSetDisasterTypesHRIS WHERE Dscrb = '" & cmbDisasterArea.Text & "'")

        'viewEditPanel()

        StrTTrMode = "025"
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
        cmbDisasterArea.Text = fk_ReadGRID(10)

    End Sub

    Private Sub pbDistan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEditEpf.Click
        If txtEpfNo.Text = "" Then : MessageBox.Show("Enter Epf No ", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub : End If
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        sSQL = "UPDATE tblEmployee SET O_EpfNo='" & txtEpfNo.Text & "' WHERE RegID='" & StrEmployeeID & "'; INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & txtEpfNo.Text & "','Change Employee Old EpfNo','','','" & StrUserID.Substring(0, 3) & "',getdate (), '" & txtEpfNo.Text & "','')"
        'Update tblControl Table `
        sSQL = sSQL & " UPDATE tblControl SET cTrCount = cTrCount + 1"
        FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub pbEditName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEditName.Click
        If txtName.Text = "" Then : MessageBox.Show("Enter Employee Name ", "", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub : End If
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        sSQL = "UPDATE tblEmployee SET O_DispName='" & txtName.Text & "' WHERE RegID='" & StrEmployeeID & "'; INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & txtEpfNo.Text & "','Change Employee Old Name','','','" & StrUserID.Substring(0, 3) & "',getdate (), '" & txtName.Text & "','')"
        'Update tblControl Table `
        sSQL = sSQL & " UPDATE tblControl SET cTrCount = cTrCount + 1"
        FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub pbEditFirstJoin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbEditFirstJoin.Click
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        sSQL = "UPDATE tblEmployee SET O_RegDate='" & dtpFirstJoin.Text & "' WHERE RegID='" & StrEmployeeID & "'; INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'Change Employee Old RegDate','','','" & StrUserID.Substring(0, 3) & "',getdate (), '" & dtpFirstJoin.Text & "','')"
        'Update tblControl Table ``
        sSQL = sSQL & " UPDATE tblControl SET cTrCount = cTrCount + 1"
        FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

   
 
    Private Sub pbAddNewAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbAddNewAct.Click
        '  If UP("Employee HRM Info", "Edit employee religion") = False Then Exit Sub
        'viewEditPanel()


        StrTTrMode = "00001"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmAddNewItems
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()
        frmAddNewItems.ShowDialog()
        ListCombo(cmbAct, "select * from tblSetActTypesHRIS where Status = 0 order by Dscrb", "Dscrb")
        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)
        cmbAct.Text = fk_ReadGRID(6)

    End Sub

    Private Sub pbNewSubCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNewSubCategory.Click

        ' viewEditPanel()

        StrTTrMode = "00002"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmAddNewItems
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmAddNewItems.ShowDialog()
        ListCombo(cmbSubCat, "select * from tblSetSubCatHRIS where Status = 0 order by Dscrb", "Dscrb")
        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)
        cmbSubCat.Text = fk_ReadGRID(7)    
    End Sub

    Private Sub pbNewNearCity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNewNearCity.Click

        ' viewEditPanel()

        StrTTrMode = "00003"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmAddNewItems
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmAddNewItems.ShowDialog()
        ListCombo(cmbNearestCity, "select * from tblSetNearsCitysHRIS where Status = 0 order by Dscrb", "Dscrb")
        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)
        cmbNearestCity.Text = fk_ReadGRID(9)
    End Sub

    Private Sub pbNewDisasterArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbNewDisasterArea.Click

        'viewEditPanel()

        StrTTrMode = "00004"
        'Me.pnlMostRight.Controls.Clear()
        'Dim frmReg As New frmAddNewItems
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized
        'frmReg.TopLevel = False
        'Me.pnlMostRight.Controls.Add(frmReg)
        'frmReg.Show()

        frmAddNewItems.ShowDialog()
        ListCombo(cmbDisasterArea, " select * from tblSetDisasterTypesHRIS where Status = 0 order by Dscrb", "Dscrb")
        sSQL = "SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName,tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb,tblSetDisasterTypesHRIS.Dscrb from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID = tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID  LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  WHERE tblEmployee.regID='" & StrEmployeeID & "'; "
        fk_Return_MultyString(sSQL, 11)
        cmbDisasterArea.Text = fk_ReadGRID(10)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        refrash()
    End Sub

    Public Sub frmHRMAdtionalInfomation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        refrash()
    End Sub


    Private Sub viewEditPanel()
        If pnlMostRight.Visible = False Then
            pnlMostRight.Visible = True
        Else
            pnlMostRight.Visible = False
        End If
    End Sub

    Private Sub CboxNewEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboxNewEmployee.Click
        sSQL = "UPDATE tblEmployee SET  IsOLDEmp = '" & CboxNewEmployee.CheckState & "'   WHERE RegID ='" & StrEmployeeID & "' " : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub pbnewGnDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'StrTTrMode = "00005"
        'frmAddNewItems.ShowDialog()
        'ListCombo(cmbDisasterArea, "  select * from tblGramaDivision where status = 0 order by gsdName", "gsdName")
        'sSQL = " SELECT tblemployee.RegDate,tblemployee.Dispname,tblemployee.O_EpfNo,tblemployee.O_RegDate,tblemployee.O_DispName, tblemployee.IsOLDEmp,tblSetActTypesHRIS.Dscrb,tblSetSubCatHRIS.Dscrb,tblCities.cDesc, tblSetNearsCitysHRIS.Dscrb, tblSetDisasterTypesHRIS.Dscrb , tblGramaDivision.gsdName from tblemployee  LEFT OUTER JOIN tblSetActTypesHRIS ON tblSetActTypesHRIS.ActID =  tblemployee.ActType  LEFT OUTER JOIN tblSetSubCatHRIS ON  tblSetSubCatHRIS.CatID = tblemployee.SubCatID   LEFT OUTER JOIN tblCities ON  tblCities.cID = tblemployee.DistrictID  LEFT OUTER JOIN tblSetNearsCitysHRIS ON  tblSetNearsCitysHRIS.CityID = tblemployee.NearestCityID LEFT OUTER JOIN  tblSetDisasterTypesHRIS ON  tblSetDisasterTypesHRIS.DisID = tblemployee.DisasterAreaID  LEFT OUTER JOIN tblGramaDivision on    tblGramaDivision.gsdID = tblemployee.GnDivision WHERE tblEmployee.regID ='" & StrEmployeeID & "'; "
        'fk_Return_MultyString(sSQL, 11)
        'cmbGNDevision.Text = fk_ReadGRID(10)
    End Sub
End Class
