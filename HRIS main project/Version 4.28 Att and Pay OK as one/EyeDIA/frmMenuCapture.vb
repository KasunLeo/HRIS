Imports System.Data.SqlClient

Public Class frmMenuCapture
    Dim StrMenuID As String
    Dim StrOrigID As String
    Dim StrSvStatus As String = "S"
    Dim StrHeadID As String
    Dim intMLevel As Integer = 0
    Dim StrISHead As String = "Y"

    'Leave Type Parameters


    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim crtl As Control
        For Each crtl In Me.GroupBox1.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next

        'Set Menu ID
        'Dim intMenu As Integer = fk_sqlDbl("SELECT NoMenu FROM tblCompany") + 1
        'StrMenuID = fk_CreateSerial(3, intMenu)

        txtMenuID.Text = StrMenuID
        StrOrigID = StrMenuID
        StrHeadID = StrMenuID
        intMLevel = 0
        'Open Control Table 
        Dim sqlQRY As String
        sqlQRY = "SELECT RemEarly,CalLateEarly FROM tblControl"
        fk_Return_MultyString(sqlQRY, 2)
        ChkRemEarlyMin.CheckState = fk_ReadGRID(0) : chkCalLateEarly.CheckState = fk_ReadGRID(1)

        chkAllowFil.CheckState = fk_sqlDbl("select downFromFile from tblcompany where compID='" & StrCompID & "'")
        ListCombo(cmbTheme, "select * From tblTheme Order By thID", "thName")
        cmbTheme.Text = fk_RetString("select thName from tbltheme where status=1")
        cmbDownload.Text = fk_RetString("select downloadform from tblcompany where compid='" & StrCompID & "'")
        sSQL = "select case when status='1' then 'True' else 'False' end as 'st',pnlName from [tblDashboardPanel] "
        Load_InformationtoGrid(sSQL, dgvDBPaneleka, 2)
        chkImportExtraDaysToLeave.CheckState = fk_sqlDbl("select IsImportExtrDayToLv from tblcompany where compID='" & StrCompID & "'")
        chkRandomReportMenu.CheckState = fk_sqlDbl("select IsRandomReport from tblcompany where compID='" & StrCompID & "'")
        chkCalBeginOT.CheckState = fk_sqlDbl("select isEmpBOT from tblcompany where compID='" & StrCompID & "'")
        chkVeiwPayrollTextfile.CheckState = fk_sqlDbl("select IsPayrollTextFile from tblcompany where compID='" & StrCompID & "'")
        chkImportOTtoLeave.CheckState = fk_sqlDbl("select IsImportOTHrToLv from tblcompany where compID='" & StrCompID & "'")
        chkUserViewlevel.CheckState = fk_sqlDbl("select IsUserViewLevel from tblcompany where compID='" & StrCompID & "'")
        chkOrigMin.CheckState = fk_sqlDbl("SELECT CalOnOrigMin FROM tblControl")
        chkCalLateEarly.CheckState = fk_sqlDbl("SELECT CalLareEarly FROM tblControl")
        chkUserViewlevel.CheckState = fk_sqlDbl("select IsPayrolDataEnabled from tblcompany where compID='" & StrCompID & "'")
        chkRoster.CheckState = fk_sqlDbl("select IsRosterEnabled from tblcompany where compID='" & StrCompID & "'")
        chkContractPeriod.CheckState = fk_sqlDbl("select IsContractPeriod from tblcompany where compID='" & StrCompID & "'")
        chkDayTypeConfiger.CheckState = fk_sqlDbl("select IsDayTypeConfig from tblcompany where compID='" & StrCompID & "'")
        chkNightPick.CheckState = fk_sqlDbl("select IsNightPickEnabled from tblcompany where compID='" & StrCompID & "'")
        chkMultiDevice.CheckState = fk_sqlDbl("SELECT MultiD FROM tblControl")
        chkNewRoster.CheckState = fk_sqlDbl("select IsNewRoster from tblcompany where compID='" & StrCompID & "'")
        chkWeekShed.CheckState = fk_sqlDbl("select isWeekShed from tblcompany where compID='" & StrCompID & "'")
        chkResignScreen.CheckState = fk_sqlDbl("select IsResignScreen from tblcompany where compID='" & StrCompID & "'")
        chkORApprov.CheckState = fk_sqlDbl("select IsOTApprove from tblcompany where compID='" & StrCompID & "'")
        chkAttchOp.CheckState = fk_sqlDbl("SELECT SelectMachine FROM tblControl")
        chkOTMonthlyHours.CheckState = fk_sqlDbl("select IsMonthlyOT from tblcompany where compID='" & StrCompID & "'")
        chkDeleteShift.CheckState = fk_sqlDbl("select isDeleteShift from tblcompany where compID='" & StrCompID & "'")
        chkNewOTConfig.CheckState = fk_sqlDbl("SELECT NewOTCOnfig FROM tblCOntrol")
        chkRoundInOutMethod2.CheckState = fk_sqlDbl("select ISRoundInOutMethod2 from tblcompany where compID='" & StrCompID & "'")
        chkDispalyDepartmentASBranch.CheckState = fk_sqlDbl("select ISDispalyDepartmentASBranch from tblcompany where compID='" & StrCompID & "'")
        chkViewActualWorkDayInSummary.CheckState = fk_sqlDbl("select ISViewActualWorkDayInSummary from tblcompany where compID='" & StrCompID & "'")
        chkSpecialOTorRamada.CheckState = fk_sqlDbl("select IsOTForRamada from tblcompany where compID='" & StrCompID & "'")
        chkGetResignedToSummary.CheckState = fk_sqlDbl("select IsGetResignedToSummary from tblcompany where compID='" & StrCompID & "'")
        chkRemoveNewFromSummary.CheckState = fk_sqlDbl("select IsRemoveNewFromSummary from tblcompany where compID='" & StrCompID & "'")
        chkIsDownloadFromServer.CheckState = fk_sqlDbl("select IsDownloadFromServer from tblcompany where compID='" & StrCompID & "'")
        chkEmpWiseChart.CheckState = fk_sqlDbl("select IsEmpWiseChart from tblcompany where compID='" & StrCompID & "'")
        chkAdditionalHRModule.CheckState = fk_sqlDbl("select IsAdditionalHRModule from tblcompany where compID='" & StrCompID & "'")
        chkLunchDinnerDeduct.CheckState = fk_sqlDbl("select IsLunchDinnerDeduct from tblcompany where compID='" & StrCompID & "'")
        chkFamilyInfo.CheckState = fk_sqlDbl("select IsFamilyInfo from tblcompany where compID='" & StrCompID & "'")
        chkAddAllowance.CheckState = fk_sqlDbl("select IsAtAllowance from tblcompany where compID='" & StrCompID & "'")
        chkRemovDaily.CheckState = fk_sqlDbl("select IsRemvDaily from tblcompany where compID='" & StrCompID & "'")
        chkRemovPunchHourly.CheckState = fk_sqlDbl("select IsRemvHourly from tblcompany where compID='" & StrCompID & "'")
        chkIsSiftPatternAssign.CheckState = fk_sqlDbl("select IsSiftPatternAssign from tblcompany where compID='" & StrCompID & "'")
        chkShLvBalMin.CheckState = fk_sqlDbl("select IsChkShLvBalMin from tblControl where grpID='" & StrCompID & "'")

        chkNewjoineesView.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=1")
        chkResigneesview.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=2")
        chkContrctEndView.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=3")
        chkBirthdayView.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=4")
        chkConsecutiveabsenview.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=5")
        chkConsecutivepLate.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=6")
        chkTotalNopayDays.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=7")
        chkTotalLate.CheckState = fk_sqlDbl("SELECT isActiv FROM tblAdditionalOption WHERE opID=8")

        CboxDaySeperateOT.CheckState = fk_sqlDbl("select DaySeperateOT  from tblcontrol")

        '20181009 multiLangName and advanHRISFantasia [prasanna]
        cBoxMultiLanguName.CheckState = fk_sqlDbl("select multiplelangName  from tblcontrol")
        cBoxAdvanceHrisFantasia.CheckState = fk_sqlDbl("select AdvanHRIDDetails  from tblcontrol")
        chkOTAuthFactory.CheckState = fk_sqlDbl("select OTAuthFactory from tblControl where grpID='" & StrCompID & "'")

        Dim sqlV As String = ""
        sqlV = "SELECT IsSpecialDB,IsVOPLetter FROM tblCOntrol"
        fk_Return_MultyString(sqlV, 2)
        chkSpecialDashboard.CheckState = fk_ReadGRID(0)
        chkLetterVOP.CheckState = fk_ReadGRID(1)

        'Comment Code By Kasun #ISA-099
        '' ''If fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '' ''    rdbDefault.Checked = True
        '' ''Else
        '' ''    rdbSeleted.Checked = True
        '' ''End If

        ' New Code By Kasun #ISA-099
        Dim intV As Integer = 0
        intV = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
        cmbAtCalMeth.SelectedIndex = intV


        '################# Exteded Summary Report Modification #####################
        'Start ON       : 18/09/2017
        'By             : Kasun
        'Description    : Add Leave Summary to the Payroll Summary For Attendance
        'Other Ref      : modEOPPrc for all parameters related to this modification
        'Alter Control Table
        sqlQRY = "ALTER TABLE tblControl ADD NopayID nvarchar (3) NOT NULL Default ''" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD AnlLvID nvarchar (3) NOT NULL Default ''" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD CasLvID nvarchar (3) NOT NULL default ''" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD MedLvID Nvarchar (3) NOT NULL default ''" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD isExtSumRep Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)

        'Load Leave Details
        ListCombo(cmbNoPayID, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")
        ListCombo(cmbAnlLeave, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")
        ListCombo(cmbCasLeave, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")
        ListCombo(cmbMedLeave, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")
        ListCombo(cmbShortLeave, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")
        ListCombo(cmbSickLv, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")

        sqlQRY = "SELECT NoPayID,AnlLvID,CasLvID,MedLvID,IsExtSumRep FROM tblControl"
        fk_Return_MultyString(sqlQRY, 5)

        StrNpSumLvID = fk_ReadGRID(0) : StrAnSumLvID = fk_ReadGRID(1) : StrCaSumLvID = fk_ReadGRID(2) : StrMdSumLvID = fk_ReadGRID(3) : intIsExtSumRep = fk_ReadGRID(4)
        chkExtenSummary.CheckState = intIsExtSumRep

        cmbNoPayID.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE LvID = '" & StrNpSumLvID & "'") : If StrNpSumLvID = "" Then cmbNoPayID.Text = "NONE"
        cmbAnlLeave.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE LvID = '" & StrAnSumLvID & "'") : If StrAnSumLvID = "" Then cmbAnlLeave.Text = "NONE"
        cmbCasLeave.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE LvID = '" & StrCaSumLvID & "'") : If StrCaSumLvID = "" Then cmbCasLeave.Text = "NONE"
        cmbMedLeave.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE LvID = '" & StrMdSumLvID & "'") : If StrMdSumLvID = "" Then cmbMedLeave.Text = "NONE"
        cmbShortLeave.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE LvID = '" & StrShortSumLvID & "'") : If StrMdSumLvID = "" Then cmbShortLeave.Text = "NONE"
        cmbSickLv.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE LvID = '" & StrSickSumLvID & "'") : If StrSickSumLvID = "" Then cmbSickLv.Text = "NONE"

        ' Set Leave Types to the Control Parameters 

        sSQL = "SELECT totShLvMinPerMonth,maxNoShLvPerMnth,minMnPerShLv,IsChkShLvBalMin FROM tblControl"
        fk_Return_MultyString(sSQL, 4)
        txtShLvMinPerMnth.Text = fk_ReadGRID(0) : txtMaxShLvPrMonth.Text = fk_ReadGRID(1) : txtMinMnPerLv.Text = fk_ReadGRID(2) ': chkShLvBalMin.CheckState = fk_ReadGRID(3)
    End Sub

    Private Sub cmbNoPayID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNoPayID.SelectedIndexChanged
        StrNpSumLvID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbNoPayID.Text & "'")
    End Sub

    Private Sub cmbAnlLeave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAnlLeave.SelectedIndexChanged
        StrAnSumLvID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbAnlLeave.Text & "'")
    End Sub

    Private Sub cmbCasLeave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCasLeave.SelectedIndexChanged
        StrCaSumLvID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbCasLeave.Text & "'")
    End Sub

    Private Sub cmbMedLeave_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMedLeave.SelectedIndexChanged
        StrMdSumLvID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbMedLeave.Text & "'")
    End Sub

    '###### END ###################

    Private Sub cmdBrsHead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With dgvMenuSelect
            If .Visible = False Then
                .Visible = True
                .Height = 300
            Else
                .Visible = False
            End If
        End With
    End Sub

    Private Sub frmMenuCapture_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMainAttendance.EnableMenu()
    End Sub

    Private Sub frmMenuCapture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        CenterFormThemed(Me, Panel1, Label16)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
        FK_EQ("ALTER TABLE tblControl ADD TRTOT numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblControl ADD SelectMachine numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)

        FK_EQ("ALTER TABLE tblControl ADD NewOTConfig numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)

        '---- Kasun Added new feild to contain new leave module for sheroton
        FK_EQ("ALTER TABLE tblControl ADD IsSheLeave Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblControl ADD IsSpecialDB Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblControl ADD IsVOPLetter Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)


    End Sub

    Private Sub cmdSavfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSavfe.Click
        If txtDescription.Text = "" Then
            MsgBox("Please Enter Description", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtMenuName.Text = "" Then
            MsgBox("Please Enter menu Name", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtMenuID.Text = "" Then
            MsgBox("Menu id note generated", MsgBoxStyle.Information)
            Exit Sub
        End If

        If StrSvStatus = "S" Then
            Dim intMenu As Integer = fk_sqlDbl("SELECT NoMenu FROM tblCompany") + 1
            StrMenuID = fk_CreateSerial(3, intMenu)

            txtMenuID.Text = StrMenuID
            StrOrigID = StrMenuID
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "INSERT INTO tblMenus (MenuID,OMenuID,MenuName,MenuText,HeadMenu,MenuLevel,IsHead,NoSubs,Status) VALUES " & _
                    " ('" & txtMenuID.Text & "','" & StrOrigID & "','" & txtMenuName.Text & "','" & txtMenuText.Text & "','" & StrHeadID & "'," & intMLevel & ",'" & StrISHead & "',0," & chkStatus.CheckState & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    If txtHeadMenu.Text <> "" Then
                        sqlQRY = "UPDATE tblMenus SET NoSubs = NoSubs + 1 WHERE OmenuID = '" & StrHeadID & "'"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()

                    End If

                    sqlQRY = "UPDATE tblCompany SET NoMenu = NoMenu + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)
                Case "E"

                    'edit menu information 
                    sqlQRY = "UPDATE tblMenus SET OMenuID = '" & StrOrigID & "',MenuName = '" & txtMenuName.Text & "', " & _
                    " MenuText = '" & txtMenuText.Text & "',HeadMenu = '" & StrHeadID & "',MenuLevel = " & intMLevel & "', " & _
                    " IsHead = '" & StrISHead & "',Status = " & chkStatus.CheckState & " WHERE MenuID = '" & StrMenuID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        'Select Case TabControl1.SelectedIndex
        'Case 0

        'Case 1
        '    dgvMenuData.Rows.Clear()
        '    Dim i As Integer
        '    Dim i2 As Integer
        '    Dim i3 As Integer
        '    Dim StrOrigID As String
        '    Dim iCount As Integer

        '    Dim StrHeadID As String
        '    Dim StrSubID As String
        '    Dim StrSub1Id As String

        '    Dim StrMID As String
        '    Dim StrT As String
        '    Dim StrTName As String
        '    Dim StrSub As String
        '    Dim StrSubName As String
        '    Dim StrSub1 As String
        '    Dim StrSub1Name As String
        '    Dim vStatus As Integer

        '    Dim iLev As Integer

        '    With frmMainAttendance
        '        '            For i = 0 To .MenuStrip.Items.Count - 1
        '        '                iCount = iCount + 1
        '        '                StrOrigID = fk_CreateSerial(3, iCount)

        '        '                StrHeadID = i.ToString
        '        '                StrMID = StrHeadID
        '        '                iLev = 0
        '        '                StrT = .MenuStrip.Items(i).Text
        '                Dim bolE As Boolean = .MenuStrip.Items(i).Visible
        '                If .MenuStrip.Items(i).Visible = True Then
        '                    vStatus = 1
        '                Else
        '                    vStatus = 0
        '                End If
        '                vStatus = 1
        '                StrTName = .MenuStrip.Items(i).Name
        '                If vStatus = 1 Then
        '                    dgvMenuData.Rows.Add(StrOrigID, StrMID, StrT, StrTName, StrHeadID, iLev, "S", 0)
        '                End If
        '                For i2 = 0 To CInt(CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems.Count - 1)
        '                    iCount = iCount + 1
        '                    StrOrigID = fk_CreateSerial(3, iCount)
        '                    iLev = 1
        '                    StrSubID = i2.ToString
        '                    StrMID = StrHeadID & StrSubID
        '                    StrSub = CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2).Text
        '                    If CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2).Visible = True Then
        '                        vStatus = 1
        '                    Else
        '                        vStatus = 0
        '                    End If
        '                    vStatus = 1
        '                    StrSubName = CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2).Name
        '                    If vStatus = 1 Then
        '                        dgvMenuData.Rows.Add(StrOrigID, StrMID, StrSub, StrSubName, StrHeadID, iLev, "S", 0)
        '                    End If
        '                    If StrSub <> "" Then
        '                        For i3 = 0 To CType(CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2), ToolStripMenuItem).DropDownItems.Count - 1
        '                            iCount = iCount + 1
        '                            StrOrigID = fk_CreateSerial(3, iCount)
        '                            iLev = 2
        '                            StrSub1Id = i3.ToString
        '                            StrMID = StrHeadID & StrSubID & StrSub1Id
        '                            StrSub1 = CType(CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2), ToolStripMenuItem).DropDownItems.Item(i3).Text
        '                            If CType(CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2), ToolStripMenuItem).DropDownItems.Item(i3).Visible = True Then
        '                                vStatus = 1
        '                            Else
        '                                vStatus = 0
        '                            End If
        '                            vStatus = 1
        '                            StrSub1Name = CType(CType(.MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(i2), ToolStripMenuItem).DropDownItems.Item(i3).Name
        '                            If vStatus = 1 Then
        '                                dgvMenuData.Rows.Add(StrOrigID, StrMID, StrSub1, StrSub1Name, StrHeadID, iLev, "S", 0)
        '                            End If
        '                        Next
        '                    End If
        '                Next
        '            Next
        '        End With

        '        'Match the Grid Against the Database 
        '        Dim nRw As Integer
        '        Dim bolEx As Boolean
        '        Dim StrmName As String
        '        Dim iCol As Integer
        '        With dgvMenuData
        '            For nRw = 0 To .RowCount - 1
        '                StrmName = .Item(3, nRw).Value
        '                bolEx = fk_CheckEx("SELECT * FROM tblMenus WHERE MenuName = '" & StrmName & "'")
        '                If bolEx = True Then
        '                    .Item(6, nRw).Value = "E"
        '                    For iCol = 0 To .ColumnCount - 1
        '                        .Item(iCol, nRw).Style.BackColor = Color.Aqua
        '                    Next
        '                Else
        '                    .Item(6, nRw).Value = "S"
        '                    For iCol = 0 To .ColumnCount - 1
        '                        .Item(iCol, nRw).Style.BackColor = Color.White
        '                    Next
        '                End If
        '            Next
        '        End With
        'End Select
        'End Sub

        ' Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim frmDes As New frmUpdateLv
        'With frmDes
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .MinimizeBox = False
        '    .MaximizeBox = False
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim frmDes As New frmEomProfiles
        'With frmDes
        '    .StartPosition = FormStartPosition.CenterScreen
        '    .MinimizeBox = False
        '    .MaximizeBox = False
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With DataGridView2
            If .RowCount = 0 Then
                Dim sqlQ As String = "SELECT RegID,EpfNo FROM tblEMployee Order By RegID"
                Load_InformationtoGrid(sqlQ, DataGridView2, 2)
                'Fix A to Z
                For i As Integer = 0 To .RowCount - 1
                    Dim iVal As Integer = CInt(.Item(1, i).Value)
                    .Item(1, i).Value = fk_CreateSerial(6, iVal)
                Next
            Else
                If MsgBox("Do you want to Save ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim sqlQR As String = ""
                For i As Integer = 0 To .RowCount - 1
                    sqlQR = sqlQR & " UPDATE tblEmployee SET EpfNo = '" & .Item(1, i).Value & "' WHERE RegID = '" & .Item(0, i).Value & "'"

                Next
                FK_EQ(sqlQR, "S", "", False, True, True)
            End If
        End With

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        strDownlodform = cmbDownload.Text
        Dim strQury As String = "update tblcompany set downloadForm='" & strDownlodform & "'"
        FK_EQ(strQury, "E", "", False, True, True)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If cmbTheme.Text <> "NONE" Then

            sSQL = "update tbltheme set status ='0';"
            sSQL = sSQL & "update tbltheme set status=1 where thName='" & cmbTheme.Text & "'"
            FK_EQ(sSQL, "E", "", True, True, True)

        End If
        cmdRefresh_Click(sender, e)
        strThemeID = fk_RetString("select thID from tblTheme where status=1")
        frmMainAttendance.ChangeThemeka()
    End Sub

    Private Sub chkAllowFil_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkAllowFil.MouseClick

        Dim strQuery As String = "UPDATE tblCompany SET downFromFile='" & chkAllowFil.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        strChartTypeDounut = _ReturnCode(cmbDounut.Text)
        Dim strQuery As String = "UPDATE tblCompany SET chartDounut='" & strChartTypeDounut & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
    End Sub

    Public Function _ReturnCode(ByVal cText As String) As String
        Dim strRetun As String = ""
        Try
            Dim intDounut As String() = cText.Split("-")
            Dim StrM As String = ""
            Dim iVal As Integer = 0
            For Each name As String In intDounut
                If iVal > 0 Then StrM = name
                iVal = iVal + 1
            Next
            strRetun = StrM
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return strRetun
    End Function

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        strChartTypeBar = _ReturnCode(cmbBar.Text)
        Dim strQuery As String = "UPDATE tblCompany SET chartBar='" & strChartTypeBar & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
    End Sub

    Private Sub btnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        sSQL = "drop table tbldashboardpanel" : FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "drop table tblTheme" : FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "create table tblTheme (thID nvarchar(2),thName nvarchar(150),panelImage nvarchar(150),btnMsEnter nvarchar (150),btnMsLeave nvarchar (150),pbMsEnter nvarchar (150),pbMsLeave nvarchar (150),status numeric(18,0) not null default 0,focusColor nvarchar (60),isStrech nvarchar(4) not null default 0); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('01','Blue','KasunAt','kasunReplaceka','buttonklllk','new_file','addBig','1','LightSkyBlue','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('02','Green','KasunAtg','button2ind','buttonklllkgklllk','new_file','addBig','0','LightGreen','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('03','Wooden','KasunAtorabn','kasunReplaceka','buttondum','new_file','addBig','0','Goldenrod','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('04','Indigo','KasunAtindig','buttonklllk','button2ind','new_file','addBig','0','Plum','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('05','Kasper','untitledkasper','buttonklllk','button2kasper','new_file','addBig','0','SeaGreen','1'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('06','Black','Avast_7_Free_Antivirus','buttonklllk','buttonorangeklllkblack','new_file','addBig','0','Gray','1'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('07','Red','KasunAtRed','button2ind','button2red','new_file','addBig','0','FireBrick','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('08','PlainBlue','kasun_05','kasunReplaceka','buttonklllk','new_file','addBig','0','Highlight','0')"
        FK_EQ(sSQL, "P", "", False, False, False)

        Dim strThemeName As String = ""
        strPanelImage = fk_RetString("select panelImage from tblTheme where ThID ='" & strThemeID & "'")
        strMouseEnter = fk_RetString("select btnMsEnter from tblTheme where ThID ='" & strThemeID & "'")
        strMouseLeave = fk_RetString("select btnMsLeave from tblTheme where ThID ='" & strThemeID & "'")
        strPBEnter = fk_RetString("select pbMsEnter from tblTheme where ThID ='" & strThemeID & "'")
        strPBLeave = fk_RetString("select pbMsLeave from tblTheme where ThID ='" & strThemeID & "'")
        strThemeName = fk_RetString("select thName from tblTheme where ThID ='" & strThemeID & "'")
        strColorName = fk_RetString("select focusColor from tblTheme where ThID ='" & strThemeID & "'")
        strStrech = fk_RetString("select isStrech from tblTheme where ThID ='" & strThemeID & "'")

        sSQL = "UPDATE tblCompany SET chartBar='11' where compID='" & StrCompID & "';"
        sSQL = sSQL & "UPDATE tblCompany SET chartDounut='18' where compID='" & StrCompID & "';"
        'sSQL = sSQL & "UPDATE tblCompany SET downFromFile='0' where compID='" & StrCompID & "';"
        sSQL = sSQL & "update tbltheme set status ='0';"
        sSQL = sSQL & "update tbltheme set status=1 where thName='Blue';"
        FK_EQ(sSQL, "E", "", False, True, True)
        strChartTypeDounut = fk_RetString("select chartDounut from tblcompany where compId='" & StrCompID & "'")
        strChartTypeBar = fk_RetString("select chartBar from tblcompany where compId='" & StrCompID & "'")
        strThemeID = fk_RetString("select thID from tblTheme where status=1")
        frmMainAttendance.ChangeThemeka()
        'frmMainAttendance.chartOne()
        'frmMainAttendance.chartTwo()
    End Sub

    Private Sub cmdConfiSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfiSave.Click
        Dim sqlQRY As String
        sqlQRY = "UPDATE tblControl SET RemEarly = " & ChkRemEarlyMin.CheckState & " ,CalLateEarly = " & chkCalLateEarly.CheckState & ""
        FK_EQ(sqlQRY, "E", "", False, False, True)

        sSQL = "UPDATE [tblDashboardPanel] SET Status='0';"
        For i As Integer = 0 To dgvDBPaneleka.RowCount - 1
            If dgvDBPaneleka.Item(0, i).Value = True Or dgvDBPaneleka.Item(0, i).Value = "1" Then
                sSQL = sSQL & "UPDATE tblDashboardPanel SET Status = '1' WHERE pnlName='" & Trim(dgvDBPaneleka.Item(1, i).Value) & "';"
            End If
        Next
        FK_EQ(sSQL, "P", "", False, True, True)
    End Sub

    Private Sub chkImportExtraDaysToLeave_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkImportExtraDaysToLeave.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsImportExtrDayToLv='" & chkImportExtraDaysToLeave.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        LoadForm(New frmSQLInterface)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        LoadForm(New frmDeviceManagement)
    End Sub

    Private Sub chkRandomReportMenu_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkRandomReportMenu.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsRandomReport='" & chkRandomReportMenu.CheckState & "'  where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "E", "", False, True, True)
    End Sub

    Private Sub chkCalBeginOT_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkCalBeginOT.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsEmpBOT='" & chkCalBeginOT.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
        intIsBOTAccept = fk_sqlDbl("select isEmpBOT from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkVeiwPayrollTextfile_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkVeiwPayrollTextfile.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsPayrollTextFile='" & chkVeiwPayrollTextfile.CheckState & "'  where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "E", "", False, True, True)
    End Sub

    Private Sub chkImportOTtoLeave_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkImportOTtoLeave.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsImportOTHrToLv='" & chkImportOTtoLeave.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
    End Sub

    Private Sub chkUserViewlevel_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkUserViewlevel.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsUserViewLevel='" & chkUserViewlevel.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        ' LoadForm(New frmDisplayNameFixer)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'LoadForm(New frmDisplayNameFixer)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim sqlQRY As String = ""
        sqlQRY = " CREATE TABLE tblT1 (EmpID nvarchar (6),AtDate DateTime,ClockIn DateTime, ClockOut DateTime)" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "UPDATE tblEmpRegister SET ShiftID = '909'" : FK_EQ(sqlQRY, "S", "", False, True, True)
        sqlQRY = sqlQRY & " Insert Into tblT1 select tblEmpRegister.EmpID,AtDate,tblEmpRegister.AtDate+StartCIN, tblEmPRegister.AtDate+EndCOUT FROM tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = tblT1.ClockIn,tblEmpRegister.ClockOut = tblT1.ClockOut FROM tblT1,tblEmpRegister WHERE tblT1.EmpID = tblEmpRegister.EmpID AND tblT1.AtDate=tblEmPRegister.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, False)
    End Sub


    Private Sub chkOrigMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOrigMin.Click
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblCOntrol SET CalOnOrigMin = " & chkOrigMin.CheckState : FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub chkCalLateEarly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCalLateEarly.CheckedChanged

    End Sub

    Private Sub chkCalLateEarly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCalLateEarly.Click
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblCOntrol SET CalLareEarly = " & chkCalLateEarly.CheckState : FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub chkAttchOp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAttchOp.Click
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblControl SET SelectMachine = " & chkAttchOp.CheckState & "" : FK_EQ(sqlQRY, "S", "", False, False, True)
        intCheckMachine = fk_sqlDbl("SELECT SelectMachine FROM tblControl")
    End Sub

    Private Sub chkPayrolData_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkPayrolData.MouseClick, chkTrOTTrs.MouseClick, chkAttchOp.MouseClick
        Dim strQuery As String = "UPDATE tblCompany SET IsPayrolDataEnabled='" & chkPayrolData.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(strQuery, "S", "", False, True, True)
        IntIsPayrolDataEnabled = fk_sqlDbl("select IsPayrolDataEnabled from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkTrOTTrs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrOTTrs.CheckedChanged
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblControl SET TrTOT = " & chkTrOTTrs.CheckState & "" : FK_EQ(sqlQRY, "S", "", False, False, True)
    End Sub

    Private Sub chkDayTypeConfiger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDayTypeConfiger.Click
        sSQL = "UPDATE tblCompany SET IsDayTypeConfig='" & chkDayTypeConfiger.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsDayTypeConfig = fk_sqlDbl("select IsDayTypeConfig from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkNightPick_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNightPick.Click
        sSQL = "UPDATE tblCompany SET IsNightPickEnabled='" & chkNightPick.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsNightPickEnabled = fk_sqlDbl("select IsNightPickEnabled from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkRoster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRoster.Click
        sSQL = "UPDATE tblCompany SET IsRosterEnabled='" & chkRoster.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsRosterEnabled = fk_sqlDbl("select IsRosterEnabled from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkContractPeriod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkContractPeriod.Click
        sSQL = "UPDATE tblCompany SET IsContractPeriod='" & chkContractPeriod.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsContractPeriod = fk_sqlDbl("select IsContractPeriod from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkMultiDevice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkMultiDevice.Click
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblControl SET MultiD = " & chkMultiDevice.CheckState & "" : FK_EQ(sqlQRY, "S", "", False, True, True)
        intMultiD = fk_sqlDbl("SELECT MultiD FROM tblControl")
    End Sub

    Private Sub chkORApprov_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkORApprov.Click
        sSQL = "UPDATE tblCompany SET IsOTApprove='" & chkORApprov.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsOTApprove = fk_sqlDbl("select IsOTApprove from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkResignScreen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkResignScreen.Click
        sSQL = "UPDATE tblCompany SET IsResignScreen='" & chkResignScreen.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsResignScreen = fk_sqlDbl("select IsResignScreen from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkFingerprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkWeekShed.Click
        sSQL = "UPDATE tblCompany SET isWeekShed='" & chkWeekShed.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intisWeekShed = fk_sqlDbl("select isWeekShed from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkNewRoster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNewRoster.Click
        sSQL = "UPDATE tblCompany SET IsNewRoster='" & chkNewRoster.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsNewRoster = fk_sqlDbl("select IsNewRoster from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkDeleteShift_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDeleteShift.Click
        sSQL = "UPDATE tblCompany SET isDeleteShift='" & chkDeleteShift.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intisDeleteShift = fk_sqlDbl("select isDeleteShift from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkOTMonthlyHours_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOTMonthlyHours.Click
        sSQL = "UPDATE tblCompany SET IsMonthlyOT='" & chkOTMonthlyHours.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsMonthlyOT = fk_sqlDbl("select IsMonthlyOT from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkNewOTConfig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNewOTConfig.Click
        sSQL = "UPDATE tblControl SET NewOTConfig = " & chkNewOTConfig.CheckState & "" : FK_EQ(sSQL, "S", "", False, True, True)
        intNewOTCOnfig = fk_sqlDbl("SELECT NewOTCOnfig FROM tblCOntrol")
    End Sub

    '           Change Code By Kasun ON 25/May /2018
    '           Reason : to Impliment Staight Shift In/Out Calculation 
    'REFERENCE : #ISA-099

    '' '' ''Private Sub rdbSeleted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbSeleted.Click
    '' '' ''    If rdbDefault.Checked = True Then
    '' '' ''        sSQL = "UPDATE tblCompany SET IsDefaultShift=1 where compID='" & StrCompID & "'"
    '' '' ''        FK_EQ(sSQL, "S", "", False, True, True)
    '' '' ''    Else
    '' '' ''        sSQL = "UPDATE tblCompany SET IsDefaultShift=0 where compID='" & StrCompID & "'"
    '' '' ''        FK_EQ(sSQL, "S", "", False, True, True)
    '' '' ''    End If
    '' '' ''    intOnShiftProcess = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
    '' '' ''    intBaseOnClockRecord = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
    '' '' ''End Sub

    '' '' ''Private Sub rdbDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbDefault.Click
    '' '' ''    If rdbDefault.Checked = True Then
    '' '' ''        sSQL = "UPDATE tblCompany SET IsDefaultShift=1 where compID='" & StrCompID & "'"
    '' '' ''        FK_EQ(sSQL, "S", "", False, True, True)
    '' '' ''    Else
    '' '' ''        sSQL = "UPDATE tblCompany SET IsDefaultShift=0 where compID='" & StrCompID & "'"
    '' '' ''        FK_EQ(sSQL, "S", "", False, True, True)
    '' '' ''    End If
    '' '' ''    intOnShiftProcess = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
    '' '' ''    intBaseOnClockRecord = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
    '' '' ''End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        LoadForm(New frmConfigDaysProf)
    End Sub

    Private Sub chkRoundInOutMethod2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRoundInOutMethod2.Click
        sSQL = "UPDATE tblCompany SET ISRoundInOutMethod2='" & chkRoundInOutMethod2.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        ISRoundInOutMethod2 = fk_sqlDbl("select ISRoundInOutMethod2 from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkDispalyDepartmentASBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDispalyDepartmentASBranch.Click
        sSQL = "UPDATE tblCompany SET ISDispalyDepartmentASBranch='" & chkDispalyDepartmentASBranch.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        ISDispalyDepartmentASBranch = fk_sqlDbl("select ISDispalyDepartmentASBranch from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkViewActualWorkDayInSummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkViewActualWorkDayInSummary.Click
        sSQL = "UPDATE tblCompany SET ISViewActualWorkDayInSummary='" & chkViewActualWorkDayInSummary.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        ISViewActualWorkDayInSummary = fk_sqlDbl("select ISViewActualWorkDayInSummary from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkSpecialOTorRamada_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSpecialOTorRamada.Click
        sSQL = "UPDATE tblCompany SET IsOTForRamada='" & chkSpecialOTorRamada.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsOTForRamada = fk_sqlDbl("select IsOTForRamada from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkGetResignedToSummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkGetResignedToSummary.Click
        sSQL = "UPDATE tblCompany SET IsGetResignedToSummary='" & chkGetResignedToSummary.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsGetResignedToSummary = fk_sqlDbl("select IsGetResignedToSummary from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkRemoveNewFromSummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRemoveNewFromSummary.Click
        sSQL = "UPDATE tblCompany SET IsRemoveNewFromSummary='" & chkRemoveNewFromSummary.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsRemoveNewFromSummary = fk_sqlDbl("select IsRemoveNewFromSummary from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkRemoteServerDownload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsDownloadFromServer.Click
        sSQL = "UPDATE tblCompany SET IsDownloadFromServer='" & chkIsDownloadFromServer.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsDownloadFromServer = fk_sqlDbl("select IsDownloadFromServer from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkEmpWiseChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEmpWiseChart.Click
        sSQL = "UPDATE tblCompany SET IsEmpWiseChart='" & chkEmpWiseChart.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsEmpWiseChart = fk_sqlDbl("select IsEmpWiseChart from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkAdditionalHRModule_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAdditionalHRModule.Click
        sSQL = "UPDATE tblCompany SET IsAdditionalHRModule='" & chkAdditionalHRModule.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsAdditionalHRModule = fk_sqlDbl("select IsAdditionalHRModule from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub ChkLeaveMode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkLeaveMode.Click
        sSQL = "UPDATE tblControl SET IsSheLeave = " & ChkLeaveMode.CheckState & ""
        FK_EQ(sSQL, "S", "", False, True, True)
        intIsNewLeaveC = fk_sqlDbl("SELECT IsSheLeave FROM tblCOntrol")
    End Sub

    Private Sub cmdPrSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrSave.Click
       
        sSQL = "UPDATE tblControl SET  NoPayID = '" & StrNpSumLvID & "',AnlLvID = '" & StrAnSumLvID & "',CasLvID = '" & StrCaSumLvID & "',MedLvID = '" & StrMdSumLvID & "',IsExtSumRep = " & chkExtenSummary.CheckState & ",ShortLvID='" & StrShortSumLvID & "',sickLvID='" & StrSickSumLvID & "',totShLvMinPerMonth='" & Val(txtShLvMinPerMnth.Text) & "',maxNoShLvPerMnth='" & Val(txtMaxShLvPrMonth.Text) & "',minMnPerShLv='" & Val(txtMinMnPerLv.Text) & "' WHERE GrpID='001'"
        FK_EQ(sSQL, "S", "", True, True, True)

    End Sub

    Private Sub chkLunchDinnerDeduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkLunchDinnerDeduct.Click
        sSQL = "UPDATE tblCompany SET IsLunchDinnerDeduct='" & chkLunchDinnerDeduct.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsLunchDinnerDeduct = fk_sqlDbl("select IsLunchDinnerDeduct from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkFamilyInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFamilyInfo.Click
        sSQL = "UPDATE tblCompany SET IsFamilyInfo='" & chkFamilyInfo.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsFamilyInfo = fk_sqlDbl("select IsFamilyInfo from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub cmbShortLeave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbShortLeave.SelectedIndexChanged
        StrShortSumLvID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbShortLeave.Text & "'")
    End Sub

    Private Sub cmbSickLv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSickLv.SelectedIndexChanged
        StrSickSumLvID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbSickLv.Text & "'")
    End Sub

    Private Sub chkAddAllowance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAddAllowance.Click
        sSQL = "UPDATE tblCompany SET IsAtAllowance='" & chkAddAllowance.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsAtAllowance = fk_sqlDbl("select IsAtAllowance from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkRemovDaily_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRemovDaily.Click
        sSQL = "UPDATE tblCompany SET IsRemvDaily='" & chkRemovDaily.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsRemvDaily = fk_sqlDbl("select IsRemvDaily from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkRemovPunchHourly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRemovPunchHourly.Click
        sSQL = "UPDATE tblCompany SET IsRemvHourly='" & chkRemovPunchHourly.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsRemvHourly = fk_sqlDbl("select IsRemvHourly from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkIsEthicalOT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsEthicalOT.Click
        sSQL = "UPDATE tblCompany SET IsEthicalOT='" & chkIsEthicalOT.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsEthicalOT = fk_sqlDbl("select IsEthicalOT from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkIsSiftPatternAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIsSiftPatternAssign.Click
        sSQL = "UPDATE tblCompany SET IsSiftPatternAssign='" & chkIsSiftPatternAssign.CheckState & "' where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        IsSiftPatternAssign = fk_sqlDbl("select IsSiftPatternAssign from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub chkNewjoineesView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNewjoineesView.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkNewjoineesView.CheckState & "' WHERE opID=1" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkResigneesview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkResigneesview.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkResigneesview.CheckState & "' WHERE opID=2" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkContrctEndView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkContrctEndView.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkContrctEndView.CheckState & "' WHERE opID=3" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkBirthdayView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBirthdayView.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkBirthdayView.CheckState & "' WHERE opID=4" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkConsecutiveabsenview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConsecutiveabsenview.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkConsecutiveabsenview.CheckState & "' WHERE opID=5" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkConsecutivepLate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConsecutivepLate.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkConsecutivepLate.CheckState & "' WHERE opID=6" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkTotalNopayDays_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTotalNopayDays.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkTotalNopayDays.CheckState & "' WHERE opID=7" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkTotalLate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTotalLate.Click
        sSQL = "UPDATE tblAdditionalOption SET isActiv='" & chkTotalLate.CheckState & "' WHERE opID=8" : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkShLvBalMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShLvBalMin.Click
        sSQL = "UPDATE tblControl SET IsChkShLvBalMin='" & chkShLvBalMin.CheckState & "' where grpID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)
        'IsSiftPatternAssign = fk_sqlDbl("select IsSiftPatternAssign from tblcompany where compID='" & StrCompID & "'")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim intVal As Integer = 0
        intVal = cmbAtCalMeth.SelectedIndex


        sSQL = "UPDATE tblCompany SET IsDefaultShift= " & intVal & " where compID='" & StrCompID & "'"
        FK_EQ(sSQL, "S", "", False, True, True)

        intOnShiftProcess = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
        intBaseOnClockRecord = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")

    End Sub

    Private Sub CboxDaySeperateOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboxDaySeperateOT.Click
        sSQL = "UPDATE tblControl  SET DaySeperateOT = '" & CboxDaySeperateOT.CheckState & "' " : FK_EQ(sSQL, "S", "", False, True, True)
        intDaySeperateOT = fk_sqlDbl("select DaySeperateOT from tblControl where grpID='" & StrCompID & "'")
    End Sub

    Private Sub cBoxMultiLanguName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cBoxMultiLanguName.Click
        sSQL = "UPDATE tblControl  SET multiplelangName = '" & cBoxMultiLanguName.CheckState & "' " : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub cBoxAdvanceHrisFantasia_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cBoxAdvanceHrisFantasia.Click
        sSQL = "UPDATE tblControl  SET AdvanHRIDDetails = '" & cBoxAdvanceHrisFantasia.CheckState & "' " : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkOTAuthFactory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkOTAuthFactory.Click
        sSQL = "UPDATE tblControl  SET OTAuthFactory = '" & chkOTAuthFactory.CheckState & "' " : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub chkSpecialDashboard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpecialDashboard.Click
        sSQL = "UPDATE tblControl  SET IsSpecialDB = '" & chkSpecialDashboard.CheckState & "' " : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

    Private Sub cmdLetterModule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLetterVOP.Click
        sSQL = "UPDATE tblControl  SET IsVOPLetter = '" & chkLetterVOP.CheckState & "' " : FK_EQ(sSQL, "S", "", False, True, True)
    End Sub

End Class