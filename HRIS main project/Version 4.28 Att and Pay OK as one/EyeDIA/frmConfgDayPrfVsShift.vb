Public Class frmConfgDayPrfVsShift

    Dim StrSelShiftID As String = ""
    Dim StrSelDayID As String = ""
    Dim StrSvStatus As String = "S"
    Dim StrPrfID As String = ""
    Dim intNormalOT As Integer = 0 : Dim intDoubleOT As Integer = 0 : Dim intTripleOT As Integer = 0
    Dim StrTranID As String = "" : Dim intCalOnShiftIN As Integer = 0
    Dim intSelTab As Integer = 0
    Dim intLDedFROM As Integer = 0 : Dim intDDedFROM As Integer = 0
    Dim StrPageName As String = ""

    Private Sub frmDayPrfVsShift_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Shift Configuration", "View shift configuration") = False Then Exit Sub
        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)

        'Create Tables 
        Dim sqlTable As String = ""
        sqlTable = "ALTER TABLE tblEmpRegister ADD InTimeAP DateTime NOT NULL Default '19000101'"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "CREATE TABLE tblClockData (AtDate DateTime,InTime DateTime, OutTime DateTime, PastTime DateTime)"
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "CREATE PROC sp_GenerateClock ( @stDate DateTime ,@EdDate DateTime) AS Delete From tblClockData Declare @date DateTime " & _
        " Declare c Cursor Read_Only for Select Distinct AtDate FROM tblEmpRegister where AtDate Between @stDate AND @edDate Order By AtDate " & _
        " Open c Fetch Next From c INTO @Date WHILE @@Fetch_Status = 0 Begin " & _
        " INSERT INTO tblClockData SELECT @date,@date+InTime,@date+OutTime,@date+TrueIn FROM tblClockProf " & _
        " Fetch Next From c INTO @date End Close c Deallocate c "
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "CREATE TABLE tblDayProfileD (PrfID Nvarchar (3),ShiftID Nvarchar (3),DayID Nvarchar (2),StartMin Numeric (18,2),EndMin Numeric (18,2),NrDays Numeric (18,1),LvDays Numeric (18,1),IsNormalOT Numeric (18,0),NOTMode Numeric (18,0),NOTTime DateTime,NOTMins Numeric (18,0),IsDoubleOT Numeric (18,0),DOTMode Numeric (18,0),DOTTime DateTime,DOTMins Numeric (18,0),Status Numeric (18,0))"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD AddDay Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblControl ADD PrfNumbers Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD isTOT Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD TOTMode Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD TOTTime DateTime NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD TOTMins Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD IsCalLate Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD LateMins Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD IsCalNight Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD IsCalLate Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD NightWEF Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD NightTime DateTime NOT NULL Default ''" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD notWEF Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD dotWEF Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD totWEF Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblDayProfileD ADD IsLunch Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD LunchMins Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD LunchFrom DateTime NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD LunchWEF Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblDayProfileD ADD IsDinner Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD DinnerMins Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD DinnerFrom DateTime NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD DinnerWEF Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD calLate Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD CalEarly Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblDayProfileD ADD IsUpOT Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD UpOTMode Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD UpOTTime DateTime NOT NULL Default ''" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD WEFUpOT Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD UpOTMins Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD CalBeginOT Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD MaxBeginOT Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblDayProfileD ADD IsOTStart Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD OTStartTime DateTime NOT NULL Default ''" : FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblDayProfileD ADD LDedFROM Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD DDedFROM Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblDayProfileD ADD IsCalOnShiftIN Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False) 'Calculate Work hours based on shift in

        'CREATE LUNCH PROFILE TABLE 
        sqlTable = "CREATE TABLE LCal (EmpID Nvarchar (6),AtDate DateTime, sMin Numeric (18,0),eMin Numeric (18,0),wMin Numeric (18,0),InTime DateTime, OutTime DateTime," & _
" NightCal Numeric (18,0),NightTime DateTime,LunchTime DateTime,LunchCal Numeric (18,0),LunchMin Numeric (18,0),LDeductOT Numeric (18,0)," & _
" DinnerTime DateTime,DinnerCal Numeric (18,0),DinnerMin Numeric (18,0),DDeductOT Numeric (18,0),AntStatus Numeric (18,0),InUpdate Numeric (18,0),OutUpdate Numeric (18,0))" : FK_EQ(sqlTable, "S", "", False, False, False)



        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'Clear Form
        FK_Clear(Me)
        'Load Shift Information to the Shift Combo 
        ListCombo(cmbShiftName, "SELECT ShiftID + ' - ' + ShiftName As ShiftM FROM tblSetShiftH WHERE Status = 0 Order By ShiftID", "ShiftM")
        'ListCombo(cmbCopy, "SELECT ShiftID + ' - ' + ShiftName As ShiftM FROM tblSetShiftH WHERE Status = 0 Order By ShiftID", "ShiftM")
        'Load Day Types to the Combo 
        ListCombo(cmbDayType, "SELECT TypeID + ' - ' + TypeName As DayTypes FROM tblDayType WHERE Status = 0 Order By TypeID", "DayTypes")
        ListCombo(cmbCopy, "SELECT ShiftID + ' - ' + ShiftName As ShiftM FROM tblSetShiftH WHERE Status = 0 Order By ShiftID", "ShiftM")
        StrSvStatus = "S"
        chkCalShiftIN.CheckState = CheckState.Unchecked

        StrPrfID = fk_GenSerial("SELECT PrfNumbers FROM tblControl", 3)

        chkDoubleOT.CheckState = CheckState.Unchecked
        chkNormalOT.CheckState = CheckState.Unchecked
        chkOTStart.CheckState = CheckState.Unchecked

        list_Processed("", "")
        clr_Grid(dgvDetails)

        cmbShiftName.Focus()

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



    Private Sub cmbShiftName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShiftName.SelectedIndexChanged
        StrSelShiftID = cmbShiftName.Text.Substring(0, 3)
        list_Processed(StrSelShiftID, StrSelDayID)
    End Sub


    Public Sub list_Processed(ByVal StrShID As String, ByVal StrDID As String)
        If StrDID = "NO" Then StrDID = "" : If StrShID = "NO" Then StrShID = ""
        Dim sqlLoad As String = "select tblDayProfileD.PrfID,tblDayType.TypeName,tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblDayProfileD.NrDays,tblDayProfileD.LvDays FROM tblDayProfileD,tblDayType WHERE tblDayProfileD.DayID = tblDayType.TypeID AND tblDayProfileD.Status = 0 AND tblDayProfileD.ShiftID LIKE '%" & StrShID & "%' AND tblDayProfileD.DayID LIKE '%" & StrDID & "%' Order By tblDayProfileD.DayID,tblDayProfileD.StartMin"
        Load_InformationtoGrid(sqlLoad, dgvDetails, 6)

    End Sub

    Private Sub cmbDayType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDayType.SelectedIndexChanged, cmbCopy.SelectedIndexChanged
        StrSelDayID = cmbDayType.Text.Substring(0, 2)
        list_Processed(StrSelShiftID, StrSelDayID)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Shift Configuration", "Create shift configuration") = False Then Exit Sub
        'Set OT Param
        StrTranID = fk_GenSerial("SELECT NoTrs FROM tblControl", 10)
        If optNOutTime.Checked = True Then intNormalOT = 0 Else intNormalOT = 1
        If optDOutTime.Checked = True Then intDoubleOT = 0 Else intDoubleOT = 1
        If txtStartMins.Text = "" Then MsgBox("Enter Starting Minutes", MsgBoxStyle.Information) : Exit Sub
        If txtEndMins.Text = "" Then MsgBox("Enter Ending Minutes", MsgBoxStyle.Information) : Exit Sub
        If StrSelShiftID = "" Then MsgBox("Select Shift ", MsgBoxStyle.Information) : Exit Sub
        If StrSelDayID = "" Then MsgBox("Select Day", MsgBoxStyle.Information) : Exit Sub
        If txtNWorkMins.Text = "" Then txtNWorkMins.Text = "0"
        If txtDWorkMins.Text = "" Then txtDWorkMins.Text = "0"
        If chkCalShiftIN.CheckState = CheckState.Checked Then intCalOnShiftIN = 1 Else intCalOnShiftIN = 0
        If cmbNrWorkDays.Text = "" Then MsgBox("Select earning day count", MsgBoxStyle.Information) : cmbNrWorkDays.Focus() : Exit Sub
        If cmbLvDays.Text = "" Then MsgBox("Select auto nopay day count", MsgBoxStyle.Information) : cmbLvDays.Focus() : Exit Sub
        If cmbAddDay.Text = "" Then MsgBox("Select additional day count", MsgBoxStyle.Information) : cmbAddDay.Focus() : Exit Sub

        If chkNormalOT.Checked = True Then
            If optNWorkMins.Checked = True Then If CDbl(txtNWorkMins.Text) = 0 Then MsgBox("Enter Value for the Normal OT", MsgBoxStyle.Information) : Exit Sub
        End If
        If chkDoubleOT.Checked = True Then
            If optDOutTime.Checked = True Then If CDbl(txtDWorkMins.Text) = 0 Then MsgBox("Enter Value for the Double OT", MsgBoxStyle.Information) : Exit Sub
        End If

        Dim StrMess As String = ""
        Dim sqlQRY As String = ""
        Select Case StrSvStatus

            Case "S"
                StrMess = "INSERT NEW Configuration " & StrPrfID
                sqlQRY = "INSERT INTO tblDayProfileD (PrfID,ShiftID,DayID,StartMin,EndMin,NrDays,LvDays,IsNormalOT,NOTMode, " & _
                " NOTTime,NOTMins,IsDoubleOT,DOTMode,DOTTime,DOTMins,AddDay,Status,IsCalOnShiftIN,[LDedFROM],[DDedFROM],[CalSplitGrace],[GraseOnSplit],[isTOT],[TOTMode],[TOTTime],[TOTMins],[IsCalLate],[LateMins],[IsCalNight],[NightWEF],[NightTime],[notWEF],[dotWEF],[totWEF],[IsLunch],[LunchMins],[LunchFrom],[LunchWEF],[IsDinner],[DinnerMins],[DinnerFrom],[DinnerWEF],[calLate],[CalEarly],[IsUpOT],[UpOTMode],[UpOTTime],[WEFUpOT],[UpOTMins],[CalBeginOT] ,[MaxBeginOT],[IsOTStart],[OTStartTime]) VALUES ('" & StrPrfID & "', " & _
                " '" & StrSelShiftID & "','" & StrSelDayID & "'," & CDbl(txtStartMins.Text) & "," & CDbl(txtEndMins.Text) & "," & CDbl(cmbNrWorkDays.Text) & "," & CDbl(cmbLvDays.Text) & "," & chkNormalOT.CheckState & ", " & _
                " " & intNormalOT & ",'" & Format(dtpNOutTime.Value, "hh:mm tt") & "'," & CDbl(txtNWorkMins.Text) & ", " & _
                " " & chkDoubleOT.CheckState & "," & intDoubleOT & ",'" & Format(dtpDOutTime.Value, "hh:mm tt") & "'," & CDbl(txtDWorkMins.Text) & ", " & CDbl(cmbAddDay.Text) & ", 0," & intCalOnShiftIN & "	  ,0,0,0,0,0,0,'1900-01-01',0,0,0,0,0,'1900-01-01',0,0,0,0,0,'1900-01-01',0,0,0,'1900-01-01',0,0,0,0,0,'1900-01-01',0,0,0,0,0,'1900-01-01')"

                sqlQRY = sqlQRY & " UPDATE tblControl SET PrfNumbers = PrfNumbers + 1"
                'Insert to Adit table 
                sqlQRY = sqlQRY & " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES ('" & StrTranID & "', " & _
                " '" & Format(dtWorkingDate, "yyyyMMdd") & "','" & Me.Name & "','CN','" & StrMess & "','" & StrUserID & "',0,0,'" & StrPrfID & "')"

                sqlQRY = sqlQRY & " UPDATE tblControl SET NoTrs = NoTrs + 1"
            Case "E"
                StrMess = "Modify Configuration " & StrPrfID
                sqlQRY = "UPDATE tblDayProfileD SET ShiftID = '" & StrSelShiftID & "',DayID = '" & StrSelDayID & "',StartMin = " & CDbl(txtStartMins.Text) & ", " & _
                " EndMin = " & CDbl(txtEndMins.Text) & ",NrDays = " & CDbl(cmbNrWorkDays.Text) & ",LvDays = " & CDbl(cmbLvDays.Text) & ",IsNormalOT = " & chkNormalOT.CheckState & ", " & _
                " NOTMode = " & intNormalOT & ",NOTTime = '" & Format(dtpNOutTime.Value, "hh:mm tt") & "',NOTMins = " & CDbl(txtNWorkMins.Text) & ", " & _
                " IsDoubleOT = " & chkDoubleOT.CheckState & ",AddDay = " & CDbl(cmbAddDay.Text) & ",DOTMode = " & intDoubleOT & ",DOTTime = '" & Format(dtpDOutTime.Value, "hh:mm tt") & "',DOTMins = " & CDbl(txtDWorkMins.Text) & ",IsCalOnShiftIN = " & intCalOnShiftIN & " WHERE PrfID = '" & StrPrfID & "'"

                sqlQRY = sqlQRY & " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES ('" & StrTranID & "', " & _
               " '" & Format(dtWorkingDate, "yyyyMMdd") & "','" & Me.Name & "','CN','" & StrMess & "','" & StrUserID & "',0,0,'" & StrPrfID & "')"

                sqlQRY = sqlQRY & " UPDATE tblControl SET NoTrs = NoTrs + 1"
        End Select

        Dim bolSave As Boolean = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        If bolSave = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub optNOutTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optNOutTime.CheckedChanged

    End Sub

    Private Sub dgvDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellContentClick

    End Sub

    Private Sub dgvDetails_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetails.DoubleClick
        StrPrfID = dgvDetails.Item(0, dgvDetails.CurrentRow.Index).Value
        Dim sqlList As String = "select tblDayProfileD.PrfID,tblDayProfileD.ShiftID,tblDayProfileD.DayID,tblDayProfileD.StartMin,tblDayProfileD.EndMin, " & _
        " tblDayProfileD.NrDays,tblDayProfileD.LvDays,tblDayProfileD.IsNormalOT,tblDayProfileD.NOTMode,tblDayProfileD.NOTTime,tblDayProfileD.NOTMins, " & _
        " tblDayProfileD.IsDoubleOT,tblDayProfileD.DOTMode,tblDayProfileD.DOTTime,tblDayProfileD.DOTMins,tblDayProfileD.Status,tblDayType.TypeName, " & _
        " tblSetShiftH.ShiftName,tblDayProfileD.AddDay,tblDayProfileD.CalLate,tblDayProfileD.Calearly,tblDayProfileD.CalBeginOT,tblDayProfileD.MaxBeginOT, " & _
        " tblDayProfileD.IsOTStart,tblDayProfileD.OTStartTime,tblDayProfileD.LDedFROM,tblDayProfileD.DDedFROM,tblDayProfileD.IsCalOnShiftIN from tblDayProfileD INNER JOIN tblDayType ON tblDayProfileD.DayID = tblDayType.TypeID INNER JOIN tblSetShiftH ON tblDayProfileD.ShiftID = tblSetShiftH.ShiftID WHERE tblDayProfileD.PrfID = '" & StrPrfID & "'"

        fk_Return_MultyString(sqlList, 28) : StrSelShiftID = fk_ReadGRID(1)
        StrSelDayID = fk_ReadGRID(2) : txtStartMins.Text = fk_ReadGRID(3)
        txtEndMins.Text = fk_ReadGRID(4) : cmbNrWorkDays.Text = fk_ReadGRID(5)
        cmbLvDays.Text = fk_ReadGRID(6) : chkNormalOT.CheckState = fk_ReadGRID(7)
        intNormalOT = fk_ReadGRID(8) : If intNormalOT = 1 Then optNWorkMins.Checked = True Else optNOutTime.Checked = True
        dtpNOutTime.Value = fk_ReadGRID(9) : txtNWorkMins.Text = fk_ReadGRID(10)
        chkDoubleOT.CheckState = fk_ReadGRID(11) : intDoubleOT = fk_ReadGRID(12)
        If intDoubleOT = 1 Then optDWorkMins.Checked = True Else optDOutTime.Checked = True
        dtpDOutTime.Value = fk_ReadGRID(13) : txtDWorkMins.Text = fk_ReadGRID(14)
        cmbShiftName.Text = StrSelShiftID & " " & fk_ReadGRID(17) : cmbDayType.Text = StrSelDayID & " " & fk_ReadGRID(16)
        cmbAddDay.Text = fk_ReadGRID(18)
        Dim intCalLate As Integer = fk_ReadGRID(19) : Dim intcalEarly As Integer = fk_ReadGRID(20)
        Dim intCalBeginOT As Integer = fk_ReadGRID(21) : chkCalBegin.CheckState = intCalBeginOT
        txtMaxBeginOT.Text = fk_ReadGRID(22)
        Dim intOTStart As Integer = fk_ReadGRID(23) : chkOTStart.CheckState = intOTStart
        dtpOTStart.Value = fk_ReadGRID(24)
        chkCalLateMin.CheckState = intCalLate : chkCalearlyMin.CheckState = intcalEarly
        intLDedFROM = fk_ReadGRID(25) : intDDedFROM = fk_ReadGRID(26)
        intCalOnShiftIN = fk_ReadGRID(27) : chkCalShiftIN.CheckState = intCalOnShiftIN
        Try
            chkLDedFrom.SelectedIndex = intLDedFROM : chkDDedFrom.SelectedIndex = intDDedFROM
        Catch ex As Exception

        End Try
        sqlList = "select NrDays,LvDays,AddDay,IsCalLate,LateMins,IsCalNight,NightTime,NightWEF from tblDayProfileD WHERE PrfID = '" & StrPrfID & "'"
        fk_Return_MultyString(sqlList, 8)
        cmbNrWorkDays.Text = fk_ReadGRID(0) : cmbLvDays.Text = fk_ReadGRID(1)
        cmbAddDay.Text = fk_ReadGRID(2) : chkCalLate.CheckState = fk_ReadGRID(3)
        txtLateGrase.Text = fk_ReadGRID(4) : chkCalNight.CheckState = fk_ReadGRID(5)
        dtpNightStart.Value = fk_ReadGRID(6) : chkNightWEF.CheckState = fk_ReadGRID(7)

        sqlList = "select IsNormalOT,NOTMode,NOTTime,NotMins,NOTWEF,IsDoubleOT,DOTMode,DOTTime,DOTMins,dotWEF,isTOT,TOTMode,TOTTime,TOTMins,totWEF,tblDayProfileD.IsUpOT,tblDayProfileD.UpOTMode,tblDayProfileD.UpOTTime,tblDayProfileD.WEFUpOT,tblDayProfileD.UpOTMins from tblDayProfileD WHERE PrfID = '" & StrPrfID & "'"
        fk_Return_MultyString(sqlList, 20)
        chkNormalOT.CheckState = fk_ReadGRID(0) : intNormalOT = fk_ReadGRID(1) : dtpNOutTime.Value = fk_ReadGRID(2) : txtNWorkMins.Text = fk_ReadGRID(3) : chkNOTFrom.CheckState = fk_ReadGRID(4)
        chkDoubleOT.CheckState = fk_ReadGRID(5) : intDoubleOT = fk_ReadGRID(6) : dtpDOutTime.Value = fk_ReadGRID(7) : txtDWorkMins.Text = fk_ReadGRID(8) : chkDOtFrom.CheckState = fk_ReadGRID(9)
        chkIsTOT.CheckState = fk_ReadGRID(10) : intTripleOT = fk_ReadGRID(11) : dtpTOTTime.Value = fk_ReadGRID(12) : txtTotMinutes.Text = fk_ReadGRID(13) : chkTOTFrom.CheckState = fk_ReadGRID(14)
        chkUpOT.CheckState = fk_ReadGRID(15) : Dim intUpMode As Integer = fk_ReadGRID(16)
        If intUpMode = 0 Then optUaOTTime.Checked = True Else optUpOTMins.Checked = True
        dtpWEFUpOT.Value = fk_ReadGRID(17) : chkWEFUpOT.CheckState = fk_ReadGRID(18) : txtUpOTmin.Text = fk_ReadGRID(19)

        sqlList = "select isLunch,LunchMins,LunchFrom,LunchWeF,IsDinner,DinnerMins,DinnerFrom,DinnerWEF,LDedFROM,DDedFROM from tblDayProfileD WHERE PrfID = '" & StrPrfID & "'"
        fk_Return_MultyString(sqlList, 10)
        chkIsLunch.CheckState = fk_ReadGRID(0) : txtDedLunchMin.Text = fk_ReadGRID(1)
        dtpDedLunchTime.Value = fk_ReadGRID(2) : chkLunchWEF.CheckState = fk_ReadGRID(3)
        chkIsDinner.CheckState = fk_ReadGRID(4) : txtDinnerMins.Text = fk_ReadGRID(5)
        dtpDinnerTime.Text = fk_ReadGRID(6) : chkDinnerWEF.CheckState = fk_ReadGRID(7)
        intLDedFROM = fk_ReadGRID(8) : intDDedFROM = fk_ReadGRID(9)
        chkLDedFrom.SelectedIndex = intLDedFROM : chkDDedFrom.SelectedIndex = intDDedFROM



        StrSvStatus = "E"

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        Dim StrSave As String = "S"
        Dim StrCopyShiftID As String = ""
        StrCopyShiftID = cmbCopy.Text.Substring(0, 3)
        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblDayProfileD WHERE ShiftID = '" & StrCopyShiftID & "' AND DayID = '" & StrSelDayID & "'")
        If bolEx = True Then
            If MsgBox("Information found for coping shift and day type, Do you want to Edit Details ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            StrSave = "E"

            Dim StrCopyPrf As String = ""
            Dim sqlQRY As String = ""
            Dim intPrf As Integer = fk_sqlDbl("SELECT PrfNumbers FROM tblControl")
            sqlQRY = " DELETE FROM tblDayProfileD WHERE ShiftID = '" & StrCopyShiftID & "' AND DayID = '" & StrSelDayID & "'"
            With dgvDetails
                For i As Integer = 0 To .RowCount - 1
                    StrCopyPrf = .Item(0, i).Value
                    intPrf = intPrf + 1
                    StrPrfID = fk_CreateSerial(3, intPrf)
                    sqlQRY = sqlQRY & " INSERT INTO tblDayProfileD (PrfID,ShiftID,DayID,StartMin,EndMin,NrDays,LvDays,IsNormalOT,NOTMode,NOTTime,NOTMins,IsDoubleOT,DOTMode,DOTTime,DOTMins,Status)  SELECT '" & StrPrfID & "','" & StrCopyShiftID & "',DayID,StartMin,EndMin,NrDays,LvDays,IsNormalOT,NOTMode,NOTTime,NOTMins,IsDoubleOT,DOTMode,DOTTime,DOTMins,Status FROM tblDayProfileD WHERE PrfID = '" & StrCopyPrf & "'"
                Next
            End With

            sqlQRY = sqlQRY & " UPDATE tblControl SET PrfNumbers = " & intPrf & ""
            FK_EQ(sqlQRY, "P", "", False, True, True)
        Else
            Dim StrCopyPrf As String = ""
            Dim sqlQRY As String = ""
            Dim intPrf As Integer = fk_sqlDbl("SELECT PrfNumbers FROM tblControl")
            With dgvDetails
                For i As Integer = 0 To .RowCount - 1
                    StrCopyPrf = .Item(0, i).Value
                    intPrf = intPrf + 1
                    StrPrfID = fk_CreateSerial(3, intPrf)
                    sqlQRY = sqlQRY & " INSERT INTO tblDayProfileD (PrfID,ShiftID,DayID,StartMin,EndMin,NrDays,LvDays,IsNormalOT,NOTMode,NOTTime,NOTMins,IsDoubleOT,DOTMode,DOTTime,DOTMins,Status)  SELECT '" & StrPrfID & "','" & StrCopyShiftID & "',DayID,StartMin,EndMin,NrDays,LvDays,IsNormalOT,NOTMode,NOTTime,NOTMins,IsDoubleOT,DOTMode,DOTTime,DOTMins,Status FROM tblDayProfileD WHERE PrfID = '" & StrCopyPrf & "'"
                Next
            End With
            sqlQRY = sqlQRY & " UPDATE tblControl SET PrfNumbers = " & intPrf & ""
            FK_EQ(sqlQRY, "P", "", False, True, True)
        End If



    End Sub

    Private Sub cmdCopyPrf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopyPrf.Click
        cmdCopy_Click(sender, e)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateRule.Click

        If chkCalShiftIN.CheckState = CheckState.Checked Then intCalOnShiftIN = 1 Else intCalOnShiftIN = 0

        Try

            intLDedFROM = chkLDedFrom.SelectedIndex : intDDedFROM = chkDDedFrom.SelectedIndex

        Catch ex As Exception
            intLDedFROM = 0 : intDDedFROM = 0
        End Try
        Dim intIsUpOT As Integer = 0
        If StrPrfID = "" Then MsgBox("Please select Profile for the configuration", MsgBoxStyle.Information) : Exit Sub
        If MsgBox("Do you want to Update Selected Profile ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If StrSvStatus = "S" Then MsgBox("System is not In Data Save Mode", MsgBoxStyle.Information) : Exit Sub
        Dim sqlQRY As String = ""
        Dim bolSave As Boolean
        If txtMaxBeginOT.Text = "" Then txtMaxBeginOT.Text = "0"
        intSelTab = TabControl1.SelectedIndex
        Select Case intSelTab
            Case 0 ' Select General Information
                sqlQRY = "UPDATE tblDayProfileD SET IsCalOnShiftIN = " & intCalOnShiftIN & ", isOTStart = " & chkOTStart.CheckState & ",OTStartTime = '" & Format(dtpOTStart.Value, "hh:mm tt") & "', CalBeginOT = " & chkCalBegin.CheckState & ",MaxBeginOT = " & CDbl(txtMaxBeginOT.Text) & ", StartMin = " & CDbl(txtStartMins.Text) & ",EndMin = " & CDbl(txtEndMins.Text) & ",CalLate = " & chkCalLateMin.CheckState & ", CalEarly = " & chkCalearlyMin.CheckState & ",IsCalNight = " & chkCalNight.CheckState & ",NightWEF = " & chkNightWEF.CheckState & ",NightTime = '" & Format(dtpNightStart.Value, "hh:mm tt") & "',NrDays = " & CDbl(cmbNrWorkDays.Text) & ",LvDays = " & CDbl(cmbLvDays.Text) & ",AddDay = " & CDbl(cmbAddDay.Text) & ",IsCalLate = " & chkCalLate.CheckState & ",LateMins = " & CDbl(txtLateGrase.Text) & " WHERE PrfID = '" & StrPrfID & "'" : bolSave = FK_EQ(sqlQRY, "P", "", False, True, True)

            Case 1 'Save OT Information
                If optNOutTime.Checked = True Then intNormalOT = 0 Else intNormalOT = 1
                If optDOutTime.Checked = True Then intDoubleOT = 0 Else intDoubleOT = 1
                If optTOTTIme.Checked = True Then intTripleOT = 0 Else intTripleOT = 1
                If optUaOTTime.Checked = True Then intIsUpOT = 0 Else intIsUpOT = 1


                If txtNWorkMins.Text = "" Then txtNWorkMins.Text = "0" : If txtDWorkMins.Text = "" Then txtDWorkMins.Text = "0" : If txtTotMinutes.Text = "" Then txtTotMinutes.Text = "0"
                If intNormalOT = 1 Then If txtNWorkMins.Text = "0" Then MsgBox("Please enter value for the Normal OT Minutes", MsgBoxStyle.Information) : Exit Sub
                If intDoubleOT = 1 Then If txtDWorkMins.Text = "0" Then MsgBox("Please enter value for the Double OT minutes", MsgBoxStyle.Information) : Exit Sub
                If intTripleOT = 1 Then If txtTotMinutes.Text = "0" Then MsgBox("Please Enter Value for the Triple OT minutes", MsgBoxStyle.Information) : Exit Sub


                sqlQRY = "UPDATE tblDayProfileD SET StartMin = " & CDbl(txtStartMins.Text) & ",EndMin = " & CDbl(txtEndMins.Text) & ", IsNormalOT = " & chkNormalOT.CheckState & ",NOTMode = " & intNormalOT & " , " & _
                " NOTTime = '" & Format(dtpNOutTime.Value, "hh:mm tt") & "',NOTMins = " & CDbl(txtNWorkMins.Text) & ", " & _
                " IsDoubleOT = " & chkDoubleOT.CheckState & ",DOTMode = " & intDoubleOT & ",DOTTime = '" & Format(dtpDOutTime.Value, "hh:mm tt") & "',DOTMins = " & CDbl(txtDWorkMins.Text) & ", " & _
                " isTOT = " & chkIsTOT.CheckState & ",TOTMode = " & intTripleOT & ",TOTTime = '" & Format(dtpTOTTime.Value, "hh:mm tt") & "',TOTMins = " & CDbl(txtTotMinutes.Text) & ", " & _
                " notWEF = " & chkNOTFrom.CheckState & ",dotWEF = " & chkDOtFrom.CheckState & ",totWEF = " & chkTOTFrom.CheckState & ", " & _
                " IsUpOT = " & chkUpOT.CheckState & ",UpOTMode = " & intIsUpOT & ",UpOTTime = '" & Format(dtpWEFUpOT.Value, "hh:mm tt") & "',WEFUpOT = " & chkWEFUpOT.CheckState & ",UpOTMins = " & CDbl(txtUpOTmin.Text) & "  WHERE PrfID = '" & StrPrfID & "'"
                bolSave = FK_EQ(sqlQRY, "P", "", False, True, True)
            Case 2 'Meal Deductions
                If txtDedLunchMin.Text = "" Then txtDedLunchMin.Text = "0"
                If txtDinnerMins.Text = "" Then txtDinnerMins.Text = "0"

                sqlQRY = "UPDATE tblDayProfileD SET LDedFROM = " & intLDedFROM & ", DDedFROM = " & intDDedFROM & ", IsLunch = " & chkIsLunch.CheckState & ",LunchMins = " & CDbl(txtDedLunchMin.Text) & ",LunchFrom = '" & Format(dtpDedLunchTime.Value, "hh:mm tt") & "',LunchWEF = " & chkLunchWEF.CheckState & ", " & _
                " IsDinner = " & chkIsDinner.CheckState & ",DinnerMins = " & CDbl(txtDinnerMins.Text) & ",DinnerFrom = '" & Format(dtpDinnerTime.Value, "hh:mm tt") & "',DinnerWEF = " & chkDinnerWEF.CheckState & " WHERE PrfID = '" & StrPrfID & "'"
                bolSave = FK_EQ(sqlQRY, "P", "", False, True, True)
        End Select

        'If bolSave = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        StrPageName = TabControl1.TabIndex

    End Sub

    Private Sub cmdDeleteRule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteRule.Click
        If UP("Shift Configuration", "Delete shift configuration") = False Then Exit Sub
        If MsgBox("Do you want to Delete Selected Profile ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        Dim sqlQRY As String = ""
        sqlQRY = "DELETE FROM tblDayProfileD WHERE PrfID =  '" & StrPrfID & "'" : FK_EQ(sqlQRY, "D", "", False, True, True)

    End Sub

End Class