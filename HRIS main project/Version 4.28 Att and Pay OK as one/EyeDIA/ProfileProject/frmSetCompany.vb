Imports System.Data.SqlClient

Public Class frmSetCompany

    'Check the Save status 
    Dim StrSvStatus As String = "S"
    Dim intBase As Integer = 0
    Dim intOTRndOption As Integer = 0
    Dim intStartDayID As Integer = 0
    Dim bolRq As Boolean = False
    Dim intRptSt As Integer = 0
    Dim StrCOffDayID As String

    Dim StrOffID As String = ""
    Dim StrPoyaID As String = ""
    Dim StrMercID As String = ""
    Dim StrNopayID As String = ""

    Private Sub frmCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        FK_EQ("ALTER TABLE tblCompany ADD OffID Nvarchar (2) NOT NULL Default ''", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblCompany ADD PoyaID Nvarchar (2) NOT NULL Default ''", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblCompany ADD MercID Nvarchar (2) NOT NULL Default ''", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblCompany ADD NopayID Nvarchar (3) NOT NULL Default ''", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblCompany ADD CalRoster Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)
        Dim bolEx As Boolean

        cmdRefresh_Click(sender, e)

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, _
                                              ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim handled As Boolean
        If keyData.Equals(Keys.Enter) Then
            handled = TypeOf Me.ActiveControl Is ComboBox
            Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        ElseIf keyData.Equals(Keys.Escape) Then
            Me.Close()
        End If
        Return MyBase.ProcessCmdKey(msg, keyData) OrElse handled
    End Function

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdClose.MouseDown
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdClose.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.BackColor

    End Sub

    Public Sub SaveCompanyParameters()
        'If Ot Rounding Min <0 not allowning to save 

        If (String.IsNullOrEmpty(txtLateMins.Text)) Then
            MsgBox("Can't Leave ' Late Minutes ' field Empty", MsgBoxStyle.Information)
            txtLateMins.Focus()
            Exit Sub
        End If

        'If txtLateMins.Text = 1 Then
        '    Dim dr As DialogResult = MessageBox.Show("Currently ' Late Minutes ' is set to 1, Do you want to change Late Minutes ?", "Basic Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        '    If dr = DialogResult.Yes Then
        '        txtLateMins.Focus()
        '        Exit Sub
        '    Else
        '        txtOTRound.Focus()
        '    End If
        'End If

        If (String.IsNullOrEmpty(txtOTRound.Text)) Then
            MsgBox("Can't Leave ' OT Rounding Minutes ' Empty", MsgBoxStyle.Information)
            txtOTRound.Focus()
            Exit Sub
        End If

        'If txtOTRound.Text = 1 Then
        '    Dim dr As DialogResult = MessageBox.Show("Currently ' OT Rounding Minutes ' is set to 1, Do you want to change OT Rounding Minutes ?", "Basic Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        '    If dr = DialogResult.Yes Then
        '        txtOTRound.Focus()
        '        Exit Sub
        '    Else
        '        optUp.Focus()
        '    End If
        'End If

        If CDbl(txtOTRound.Text) <= 0 Then
            MsgBox("' OT Rounding minute ' should be grater than 0")
            txtOTRound.Focus()
            Exit Sub
        End If

        If (String.IsNullOrEmpty(txtMinOT.Text)) Then
            MsgBox("Can't Leave ' Min Minutes to Calculate OT ' field Empty", MsgBoxStyle.Information)
            txtMinOT.Focus()
            Exit Sub
        End If

        'If txtMinOT.Text = 1 Then
        '    Dim dr As DialogResult = MessageBox.Show("Currently ' Min Minutes to Calculate OT ' is set to 1, Do you want to change Min Minutes to Calculate OT ?", "Basic Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        '    If dr = DialogResult.Yes Then
        '        txtMinOT.Focus()
        '        Exit Sub
        '    Else
        '        cmbWkBeginDay.Focus()
        '    End If
        'End If

        If CDbl(txtMinOT.Text) <= 0 Then
            MsgBox("' Min Minutes to Calculate OT ' should be grater than  0")
            txtMinOT.Focus()
            Exit Sub
        End If


        StrOffID = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbOffDayID.Text & "'")
        StrPoyaID = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbPoyaDay.Text & "'")
        StrMercID = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbMercDay.Text & "'")
        StrNopayID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE LvDesc = '" & cmbNoPayID.Text & "'")

        Dim cnUps As New SqlConnection(sqlConString)
        cnUps.Open()
        Dim cmUps As New SqlCommand
        cmUps = cnUps.CreateCommand
        Dim trUps As SqlTransaction = cnUps.BeginTransaction
        cmUps.Transaction = trUps
        Dim sqlQRY As String
        Try
            sqlQRY = "UPDATE tblCompany SET CalRoster = " & chkCalRoster.CheckState & ", OffID = '" & StrOffID & "', PoyaID = '" & StrPoyaID & "',MercID = '" & StrMercID & "', NopayID = '" & StrNopayID & "', WrkDayMin = " & CDbl(txtWorkDayMin.Text) & ", StartDay = " & intStartDayID & ", isEpf = " & intRptSt & ", LateMin = " & CDbl(txtLateMins.Text) & ", OTRound = " & CDbl(txtOTRound.Text) & ", " & _
            " OTAccept = " & chkOTAccept.CheckState & ",MinHrsOT = " & CDbl(txtMinOT.Text) & ",OTRndOption= " & intOTRndOption & ", BeginOT = " & chkBeginOT.CheckState & ",EndOT = " & chkEndOT.CheckState & ", SRBase = " & intBase & ",d_Gap= " & chkGap.CheckState & ", d_GapGrase = " & CDbl(txtGapGrase.Text) & ", NightShiftStart = '" & Format(dtpNightShift.Value, "hh:mm tt") & "',OffDayID='" & StrCOffDayID & "',minOTHrsToImport='" & Val(txtminOTHrsToImport.Text) & "',OTHrsForImportDay='" & Val(txtOTHrsForImportDay.Text) & "',NoBOTGap= " & CDbl(txtMaxBOT.Text) & ",isntRoundOTSeperately=" & chkotroundingMethod.CheckState & ",MinErorCheckMin=" & Val(txtErorCheck.Text) & " ,isRandomtheme='" & chkRndTh.CheckState & "',monthStart='" & Val(txtMonthStart.Text) & "',OTRepDevide='" & Val(txtOTDevider.Text) & "',MinBgOTMin=" & Val(txtMinBgOTForDay.Text) & " WHERE CompID = '" & StrCompID & "'"
            cmUps.CommandText = sqlQRY
            cmUps.ExecuteNonQuery()

            trUps.Commit()

            MsgBox("Information Saved", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
            trUps.Rollback()
        Finally
            cnUps.Close()
        End Try
    End Sub

    Public Sub Open_Company(ByVal cID As String)

        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlQRY As String = "SELECT * FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlQRY, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            If drOpn.Read = True Then
                txtCompID.Text = StrCompID
                txtcName.Text = IIf(IsDBNull(drOpn.Item("cName")), "", drOpn.Item("cName"))
                txtAdd1.Text = IIf(IsDBNull(drOpn.Item("Add1")), "", drOpn.Item("Add1"))
                txtAdd2.Text = IIf(IsDBNull(drOpn.Item("Add2")), "", drOpn.Item("Add2"))
                txtAdd3.Text = IIf(IsDBNull(drOpn.Item("Add3")), "", drOpn.Item("Add3"))
                txtPhone1.Text = IIf(IsDBNull(drOpn.Item("Phone1")), "", drOpn.Item("Phone1"))
                txtPh2.Text = IIf(IsDBNull(drOpn.Item("Phone2")), "", drOpn.Item("Phone2"))
                txtFax1.Text = IIf(IsDBNull(drOpn.Item("Fax")), "", drOpn.Item("Fax"))
                txtEmail1.Text = IIf(IsDBNull(drOpn.Item("Email")), "", drOpn.Item("Email"))
                txtcPerson.Text = IIf(IsDBNull(drOpn.Item("cPerson")), "", drOpn.Item("cPerson"))
                txtRegNo.Text = IIf(IsDBNull(drOpn.Item("EpfRegNo")), "", drOpn.Item("EpfRegNo"))
                txtOTRound.Text = IIf(IsDBNull(drOpn.Item("OTRound")), "", drOpn.Item("OTRound"))
                txtLateMins.Text = IIf(IsDBNull(drOpn.Item("LateMin")), "", drOpn.Item("LateMin"))
                intBase = IIf(IsDBNull(drOpn.Item("SRBase")), 0, drOpn.Item("SRBase"))
                chkOTAccept.CheckState = IIf(IsDBNull(drOpn.Item("OTAccept")), 0, drOpn.Item("OTAccept"))
                chkBeginOT.CheckState = IIf(IsDBNull(drOpn.Item("BeginOT")), 0, drOpn.Item("BeginOT"))
                chkEndOT.CheckState = IIf(IsDBNull(drOpn.Item("EndOT")), 0, drOpn.Item("EndOT"))
                intOTRndOption = IIf(IsDBNull(drOpn.Item("OTRndOption")), 0, drOpn.Item("OTRndOption"))
                txtWorkDayMin.Text = IIf(IsDBNull(drOpn.Item("WrkDayMin")), 0, drOpn.Item("WrkDayMin"))
                dtpNightShift.Value = IIf(IsDBNull(drOpn.Item("NightShiftStart")), DateSerial(1900, 1, 1), drOpn.Item("NightShiftStart"))
                If intOTRndOption = 1 Then optRDonw.Checked = True Else optUp.Checked = True
                txtMinOT.Text = IIf(IsDBNull(drOpn.Item("MinHrsOT")), "", drOpn.Item("MinHrsOT"))

                Dim intSt As Integer = IIf(IsDBNull(drOpn.Item("IsEpf")), 0, drOpn.Item("IsEpf"))
                intStartDayID = IIf(IsDBNull(drOpn.Item("startDay")), 0, drOpn.Item("StartDay"))
                cmbWkBeginDay.Text = fk_RetString("SELECT dayDesc FROM tblDays WHERE dayID = " & intStartDayID & "")
                StrCOffDayID = IIf(IsDBNull(drOpn.Item("OffDayID")), "", drOpn.Item("OffDayID"))
                cmbOffDay.Text = fk_RetString("SELECT TypeName FROM tblDayType WHERE TypeID = '" & StrCOffDayID & "'")
                txtminOTHrsToImport.Text = IIf(IsDBNull(drOpn.Item("minOTHrsToImport")), 0, drOpn.Item("minOTHrsToImport"))
                txtOTHrsForImportDay.Text = IIf(IsDBNull(drOpn.Item("OTHrsForImportDay")), 0, drOpn.Item("OTHrsForImportDay"))

                StrOffID = IIf(IsDBNull(drOpn.Item("OffID")), "", drOpn.Item("OffID")) : cmbOffDayID.Text = fk_RetString("SELECT TypeName FROM tblDayType WHERE TypeID = '" & StrOffID & "'")
                StrPoyaID = IIf(IsDBNull(drOpn.Item("PoyaID")), "", drOpn.Item("PoyaID")) : cmbPoyaDay.Text = fk_RetString("SELECT TypeName FROM tblDayType WHERE TypeID = '" & StrPoyaID & "'")
                StrMercID = IIf(IsDBNull(drOpn.Item("MercID")), "", drOpn.Item("MercID")) : cmbMercDay.Text = fk_RetString("SELECT TypeName FROM tblDayType WHERE TypeID = '" & StrMercID & "'")
                StrNopayID = IIf(IsDBNull(drOpn.Item("NopayID")), "", drOpn.Item("NopayID")) : cmbNoPayID.Text = fk_RetString("SELECT lvDesc FROM tblLeaveType WHERE lvID = '" & StrNopayID & "'")
                txtMaxBOT.Text = IIf(IsDBNull(drOpn.Item("NoBOTGap")), "0", drOpn.Item("NoBOTGap"))
                chkotroundingMethod.CheckState = IIf(IsDBNull(drOpn.Item("isntRoundOTSeperately")), "", drOpn.Item("isntRoundOTSeperately"))
                txtErorCheck.Text = IIf(IsDBNull(drOpn.Item("MinErorCheckMin")), "0", drOpn.Item("MinErorCheckMin"))
                chkRndTh.CheckState = IIf(IsDBNull(drOpn.Item("isRandomtheme")), "", drOpn.Item("isRandomtheme"))
                txtOTDevider.Text = IIf(IsDBNull(drOpn.Item("OTRepDevide")), 0, drOpn.Item("OTRepDevide"))
                txtMonthStart.Text = IIf(IsDBNull(drOpn.Item("monthStart")), 0, drOpn.Item("monthStart"))

                'IIf(intSt = 0, rdoRegno.Checked = True, (IIf(intSt = 1, rdoEpf.Checked = True, rdoEnroll.Checked = True)))
                cmbReportB.SelectedIndex = intSt
                'Select Case intSt
                '    Case 0
                '        rdoRegno.Checked = True
                '    Case 1
                '        rdoEpf.Checked = True
                '    Case 2
                '        rdoEnroll.Checked = True
                'End Select
                StrSvStatus = "E"
            Else

                StrSvStatus = "S"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub txtcName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim crtl As TextBox
        crtl = sender
        If crtl.Text = "" Then
            ErrorProvider1.SetError(crtl, "Cannot leave textbox blank")
        Else
            ErrorProvider1.SetError(crtl, "")
        End If

    End Sub

    Private Sub cmdBrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        With dgvCInfo
            If .Visible = False Then
                .Visible = True
                .Height = 200
            Else
                .Visible = False
            End If
        End With

        Dim sqlQ As String = "SELECT compID,cName FROM tblCompany ORDER BY compID"
        Load_InformationtoGrid(sqlQ, dgvCInfo, 2)

    End Sub

    Private Sub dgvCInfo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        StrCompID = dgvCInfo.Item(0, dgvCInfo.CurrentRow.Index).Value

        'Show information to the text boxes
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblCompany WHERE compID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCompID.Text = IIf(IsDBNull(drShw.Item("CompID")), "", drShw.Item("CompID"))
                txtcName.Text = IIf(IsDBNull(drShw.Item("cName")), "", drShw.Item("cName"))
                txtAdd1.Text = IIf(IsDBNull(drShw.Item("Add1")), "", drShw.Item("Add1"))
                txtAdd2.Text = IIf(IsDBNull(drShw.Item("Add2")), "", drShw.Item("Add2"))
                txtAdd3.Text = IIf(IsDBNull(drShw.Item("Add3")), "", drShw.Item("Add3"))
                txtcPerson.Text = IIf(IsDBNull(drShw.Item("cPerson")), "", drShw.Item("cPerson"))
                txtPhone1.Text = IIf(IsDBNull(drShw.Item("Phone1")), "", drShw.Item("Phone1"))
                txtPh2.Text = IIf(IsDBNull(drShw.Item("Phone2")), "", drShw.Item("Phone2"))
                txtFax1.Text = IIf(IsDBNull(drShw.Item("Fax")), "", drShw.Item("Fax"))
                txtEmail1.Text = IIf(IsDBNull(drShw.Item("Email")), "", drShw.Item("Email"))
                txtRegNo.Text = IIf(IsDBNull(drShw.Item("EpfRegNo")), "", drShw.Item("EpfRegNo"))
                'chkReportEpf.CheckState = IIf(IsDBNull(drShw.Item("isEpf")), 0, drShw.Item("isEpf"))
                txtOTRound.Text = IIf(IsDBNull(drShw.Item("OTRound")), "", drShw.Item("OTRound"))
                txtLateMins.Text = IIf(IsDBNull(drShw.Item("LateMin")), "", drShw.Item("LateMin"))
                intBase = IIf(IsDBNull(drShw.Item("SRBase")), 0, drShw.Item("SRBase"))
                chkOTAccept.CheckState = IIf(IsDBNull(drShw.Item("OTAccept")), 0, drShw.Item("OTAccept"))
                chkBeginOT.CheckState = IIf(IsDBNull(drShw.Item("BeginOT")), 0, drShw.Item("BeginOT"))
                chkEndOT.CheckState = IIf(IsDBNull(drShw.Item("EndOT")), 0, drShw.Item("EndOT"))
                intOTRndOption = IIf(IsDBNull(drShw.Item("OTRndOption")), 0, drShw.Item("OTRndOption"))
                chkCalRoster.CheckState = IIf(IsDBNull(drShw.Item("CalRoster")), 0, drShw.Item("Calroster"))
                StrSvStatus = "E"
                dgvCInfo.Visible = False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub optShiftB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim crtl As Control
        crtl = sender
        Select Case crtl.Name
            Case "optShiftB"
                intBase = 1
            Case "optRosterB"
                intBase = 2
        End Select

    End Sub

    Private Sub chkOTAccept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOTAccept.CheckedChanged

        If chkOTAccept.Checked = True Then
            gpbOT.Enabled = True
        Else
            gpbOT.Enabled = False
        End If

    End Sub

    Private Sub RDonw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRDonw.Click, optUp.Click

        Dim crtl As Control = sender
        Select Case crtl.Name
            Case "optUp"
                intOTRndOption = 0
            Case "optRDonw"
                intOTRndOption = 1
        End Select

    End Sub

    Private Sub cmbWkBeginDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWkBeginDay.SelectedIndexChanged

        intStartDayID = fk_sqlDbl("SELECT DayID FROM tblDays WHERE DayDesc = '" & cmbWkBeginDay.Text & "'")

    End Sub

    Private Sub cmdBrs_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrs.MouseEnter

        Me.cmdBrs.FlatStyle = FlatStyle.Standard
        Me.cmdBrs.FlatAppearance.BorderSize = 1
        Me.cmdBrs.Width = 24
        Me.cmdBrs.Height = 24

    End Sub

    Private Sub cmdBrs_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrs.MouseLeave

        Me.cmdBrs.FlatStyle = FlatStyle.Flat
        Me.cmdBrs.FlatAppearance.BorderSize = 0
        Me.cmdBrs.Width = 22
        Me.cmdBrs.Height = 22

    End Sub

    Private Sub cmbOffDay_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOffDay.SelectedIndexChanged
        StrCOffDayID = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbOffDay.Text & "'")
    End Sub

    Private Sub cmbOffDayID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOffDayID.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtGapGrase.Text = "" Then txtGapGrase.Text = "0"
        intRptSt = cmbReportB.SelectedIndex
        'intRptSt = IIf(rdoRegno.Checked = True, 0, IIf(rdoEpf.Checked = True, 1, 2))

        Dim intTab As Integer = TabControl1.SelectedIndex
        Select Case intTab
            Case 0
                If (String.IsNullOrEmpty(txtCompID.Text)) Then
                    MsgBox("Can't Leave Company ID Empty", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Validate the function 
                If txtcName.Text = "" Then
                    MsgBox("Can't Leave Company Name Empty", MsgBoxStyle.Information)
                    txtcName.Focus()
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(txtAdd1.Text)) Then
                    MsgBox("Can't Leave Address1 Empty", MsgBoxStyle.Information)
                    txtAdd1.Focus()
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(txtAdd2.Text)) Then
                    MsgBox("Can't Leave Address2 Empty", MsgBoxStyle.Information)
                    txtAdd2.Focus()
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(txtcPerson.Text)) Then
                    MsgBox("Can't Leave Contact Person Empty", MsgBoxStyle.Information)
                    txtcPerson.Focus()
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(txtPhone1.Text)) Then
                    MsgBox("Can't Leave Phone 1 Empty", MsgBoxStyle.Information)
                    txtPhone1.Focus()
                    Exit Sub
                End If

                If (String.IsNullOrEmpty(txtEmail1.Text)) Then
                    MsgBox("Can't Leave Email Empty", MsgBoxStyle.Information)
                    txtEmail1.Focus()
                    Exit Sub
                End If

                If StrSvStatus = "S" Then
                    Dim StrcID As String
                    Dim iC As Integer = fk_sqlDbl("SELECT NoCompany FROM tblControl") + 1
                    StrcID = fk_CreateSerial(3, iC)
                    txtCompID.Text = StrcID
                End If

                Dim cnSave As New SqlConnection(sqlConString)
                cnSave.Open()
                Dim cmSave As New SqlCommand
                cmSave = cnSave.CreateCommand
                Dim trSave As SqlTransaction = cnSave.BeginTransaction
                cmSave.Transaction = trSave
                Dim sqlQRY As String = ""
                Try
                    Select Case StrSvStatus
                        Case "S"
                            'Insert the Company Information 
                            sqlQRY = "INSERT INTO tblCompany (CompID,cName,Add1,Add2, " & _
                            " Add3,Phone1,Phone2,Fax,Email,cPerson,NoEmps,Nodept,NoReqst,EpfRegNo,Status,noBrs,NightShiftStart,isRandomtheme) VALUES " & _
                            " ('" & txtCompID.Text & "','" & txtcName.Text & "','" & txtAdd1.Text & "','" & txtAdd2.Text & "', " & _
                            " '" & txtAdd3.Text & "','" & txtPhone1.Text & "','" & txtPh2.Text & "','" & txtFax1.Text & "', " & _
                            " '" & txtEmail1.Text & "','" & txtcPerson.Text & "',0,0,0,'" & txtRegNo.Text & "',1,0,'" & Format(dtpNightShift.Value, "hh:mm tt") & "','" & chkRndTh.CheckState & "')"
                            cmSave.CommandText = sqlQRY : cmSave.ExecuteNonQuery()

                            sqlQRY = "UPDATE tblControl SET NoCompany = NoCompany + 1"
                            cmSave.CommandText = sqlQRY : cmSave.ExecuteNonQuery() : trSave.Commit()

                            MsgBox("Company Information Saved", MsgBoxStyle.Information)
                            cmdRefresh_Click(sender, e)
                        Case "E"
                            'Update Information of the company
                            sqlQRY = "UPDATE tblCompany SET cName = '" & txtcName.Text & "',Add1 = '" & txtAdd1.Text & "',Add2 = '" & txtAdd2.Text & "', " & _
                            " Add3 = '" & txtAdd3.Text & "',Phone1 = '" & txtPhone1.Text & "',Phone2 = '" & txtPh2.Text & "', " & _
                            " Fax = '" & txtFax1.Text & "',Email = '" & txtEmail1.Text & "',cPerson = '" & txtcPerson.Text & "',EpfRegNo = '" & txtRegNo.Text & "',NightShiftStart = '" & Format(dtpNightShift.Value, "hh:mm tt") & "',OffDayID = '" & StrCOffDayID & "',isRandomtheme='" & chkRndTh.CheckState & "' WHERE CompID = '" & txtCompID.Text & "'"
                            cmSave.CommandText = sqlQRY : cmSave.ExecuteNonQuery() : trSave.Commit()
                            MsgBox("Information Modified", MsgBoxStyle.Information)
                            cmdRefresh_Click(sender, e)
                    End Select
                Catch ex As Exception
                    MsgBox(ex.Message)
                    trSave.Rollback()
                Finally
                    cnSave.Close()
                End Try

            Case 1
                SaveCompanyParameters()
                cmdRefresh_Click(sender, e)
            Case 2
                SaveCompanyParameters()
                cmdRefresh_Click(sender, e)
        End Select

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        FK_Clear(Me)

        'Create the Company ID
        Dim StrcID As String
        Dim iC As Integer = fk_sqlDbl("SELECT NoCompany FROM tblControl") + 1
        StrcID = fk_CreateSerial(3, iC)
        txtCompID.Text = StrcID
        StrSvStatus = "S"

        'Load Days in to the day combo
        ListCombo(cmbWkBeginDay, "SELECT * FROM tblDays Order By DayID", "DayDesc")

        With cmbReportB
            .Items.Clear()
            .Items.Add("Employee Register Number")
            .Items.Add("Employee EPF Number")
            .Items.Add("Employee Enroll Number")
            .Items.Add("Employee Employee Number")
        End With
        'Load Week Days 


        ListCombo(cmbOffDay, "SELECT * FROM tblDayType WHERE Status = 0 Order By TypeID", "TypeName")
        ListCombo(cmbOffDayID, "SELECT * FROM tblDayType WHERE Status = 0 Order By TypeID", "TypeName")
        ListCombo(cmbPoyaDay, "SELECT * FROM tblDayType WHERE Status = 0 Order By TypeID", "TypeName")
        ListCombo(cmbMercDay, "SELECT * FROM tblDayType WHERE Status = 0 Order By TypeID", "TypeName")
        ListCombo(cmbNoPayID, "SELECT * FROM tblLeaveType WHERE Status = 0 Order By LvID", "LvDesc")
        Open_Company(StrCompID)
        'Open Information
        
    End Sub

End Class