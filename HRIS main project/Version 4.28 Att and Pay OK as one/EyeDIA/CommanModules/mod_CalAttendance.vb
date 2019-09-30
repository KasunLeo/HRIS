Imports System.Data.SqlClient

Module mod_CalAttendance

    Public StrAccessDept As String
    Public dtGlobalDate As Date
    Public strDescriptionLabel As String = ""
    Public StrUserLvBranch As String = ""
    Public UserVal As Double = 0
    Public ISViewActualWorkDayInSummary As Integer = 0
    Public IsGetResignedToSummary As Integer
    Public IsRemoveNewFromSummary As Integer = 0
    Public strEditSetings As String = ""
    Public IsRunAutoCalculation As Integer = 0
    Public IsOTForRamada As Integer = 0
    Public IsDownloadFromServer As Integer = 0

    Public dbSqlConR As New SqlConnection
    Public strRemoteDatabase As String
    Public strRemoteUser As String
    Public strRemotePassword As String
    Public strRemoteServer As String
    Public sqlConStringRemote As String
    Public sqlRemotConStatus As String
    Public IsAdditionalHRModule As String
    Public IsLunchDinnerDeduct As Integer = 0
    Public IsFamilyInfo As Integer = 0
    Public IsAtAllowance As Integer = 0
    Public IsRemvDaily As Integer = 0
    Public IsRemvHourly As Integer = 0
    Public IsSiftPatternAssign As Integer = 0
    Public IsEthicalOT As Integer = 0

    Public intCheckMachine As Integer
    Public intNewOTCOnfig As Integer = 0
    Public dtNightFix As Date
    Public dtKfrDate As Date
    Public dtKtoDate As Date
    Public strLastTask As String = "Night Fix"
    Public intSelecTab As Integer = 0
    Public intOnShiftProcess As Integer = 0
    Public intMinErorCheckMin As Integer = 166
    Public ISRoundInOutMethod2 As Integer = 0
    Public ISDispalyDepartmentASBranch As Integer = 0
    Public strDealerName As String = "HRIS Business Solutions Pvt Ltd"
    Public IsEpf As Integer
    Public sqlTag1 As String
    Public sqlTagName As String
    Public dtLastProcessed As Date = dtWorkingDate
    Public strUsersRegID As String = "000000"
    Public StrUserLvReport As String = ""

    Public intGlbLateStatus As Integer
    Public intGlbEarlyStatus As Integer
    Public intGlbLateMinutes As Integer
    Public intGlbEarlyMinutes As Integer

    Public StrDivNoLocation As String = ""
    Public StrDivNoMachineID As String = ""
    Public strRetDateTimeFormat As String = "yyyyMMdd"
    Public strDispDateTimeFormat As String = "yyyy/MMM/dd"
    Public strLogedinTo As String = "Attendance"
    Public Sub Rmote_Fk_FillGrid(ByVal strSQLQuery As String, ByVal DataGridViewName As DataGridView)
        Dim CN As New SqlConnection(sqlConStringRemote)
        Dim sBol As Boolean = False
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTable)
            DataGridViewName.DataSource = sTable.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub


    Public Function fk_FixAttendanceTables(ByVal dtStart As Date, ByVal dtEnd As Date) As Boolean
        Dim bolReturn As Boolean
        Dim dgvMain As New DataGridView
        With dgvMain
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("AtDate", "AtDate")
            .Columns.Add("ShiftID", "ShiftID")
            .Columns.Add("DayTypeID", "DayTypeID")
        End With

        Dim sqlL As String = ""
        sqlL = "SELECT EmpID,AtDate,AllShifts,DayTypeID FROM tblEmpRegister WHERE atDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND Len(AllShifts) > 3"
        Load_InformationtoGrid(sqlL, dgvMain, 4)
        'Check the List to add Balance 
        Dim sqlQRY As String
        'Single Shift Assign
        sqlQRY = "delete from tblGetInOut where atDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
        sqlQRY = sqlQRY & " INSERT INTO tblGetInOut"
        sqlQRY = sqlQRY & " Select tblEMpRegister.EmpID,tblEmpRegister.AtDate,0,tblSetShiftH.ShiftID,'','','',tblEmpRegister.AtDate+tblSetShiftH.InTime,DateAdd(Day,tblShiftHeader.CountDay,tblEmpRegister.AtDate)+tblSetShiftH.OutTime, " &
        " tblEmpRegister.AtDate+tblShiftHeader.StartTime,DateAdd(Day,tblShiftHeader.CountDay,tblEmpRegister.AtDate)+tblShiftHeader.EndDate,0,0,0,0,0,0,0,0,0,0,0,0, " &
        " '',0,0,0,tblEmpRegister.DayTypeID From tblEmpRegister,tblSetShiftH,tblShiftHeader WHERE tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND tblSetShiftH.shiftMode = tblShiftHeader.ShiftMode " &
        " AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
        bolReturn = FK_EQ(sqlQRY, "S", "", False, False, True)

        sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AtDate DateTime,ShiftID Nvarchar (3),DayTYpeID Nvarchar (2))"
        Dim StrAllShift As String
        With dgvMain
            For i As Integer = 0 To .RowCount - 2
                StrAllShift = fk_SplitToSQL_in(.Item(2, i).Value)
                sqlQRY = sqlQRY & " DELETE FROM tblGetInOut WHERE AtDate = '" & .Item(1, i).Value & "' AND EmpID = '" & .Item(0, i).Value & "'"
                sqlQRY = sqlQRY & " INSERT INTO #Tmp (EmpID,AtDate,ShiftID,DayTypeID) Select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "',ShiftID, '" & .Item(3, i).Value & "' FROM tblSetShiftH WHERE ShiftID In ('" & StrAllShift & "')"
            Next
            sqlQRY = sqlQRY & " INSERT INTO tblGetInOut"
            sqlQRY = sqlQRY & " Select #Tmp.EmpID,#Tmp.AtDate,0,tblSetShiftH.ShiftID,'','','',#Tmp.AtDate+tblSetShiftH.InTime,DateAdd(Day,tblShiftHeader.CountDay,#Tmp.AtDate)+tblSetShiftH.OutTime, " &
                        " #Tmp.AtDate+tblShiftHeader.StartTime,DateAdd(Day,tblShiftHeader.CountDay,#Tmp.AtDate)+tblShiftHeader.EndDate,0,0,0,0,0,0,0,0,0,0,0,0, " &
                        " '',0,0,0,#Tmp.DayTypeID From #Tmp,tblSetShiftH,tblShiftHeader WHERE tblSetShiftH.ShiftID = #Tmp.ShiftID AND tblSetShiftH.shiftMode = tblShiftHeader.ShiftMode " &
            " AND #Tmp.AtDate  Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
        End With
        If bolReturn = True Then bolReturn = FK_EQ(sqlQRY, "P", "", False, True, True)
        Return bolReturn
    End Function

    Public Sub fk_SetGridCLICK(ByVal dgv As DataGridView, ByVal chkCol As Integer, ByVal resCol As Integer, ByVal StrResult As String)
        Dim tVal As String
        Try

            With dgv
                For i As Integer = 0 To .RowCount - 1
                    Dim nameArray As String() = StrResult.Split("|")
                    Dim initials As String = String.Empty
                    For Each name As String In nameArray
                        tVal = name.ToString
                        If tVal = .Item(resCol, i).Value Then .Item(chkCol, i).Value = True ' Else .Item(chkCol, i).Value = False
                    Next
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function fk_getGridCLICK(ByVal dgv As DataGridView, ByVal col As Integer, ByVal ResCol As Integer) As String
        Dim StrReturn As String = ""
        Try

            With dgv
                For i As Integer = 0 To .RowCount - 1
                    If CBool(.Item(col, i).Value) = True Or Val(.Item(col, i).Value) = 1 Then If StrReturn = "" Then StrReturn = .Item(ResCol, i).Value Else StrReturn = StrReturn & "|" & .Item(ResCol, i).Value
                Next
            End With


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return StrReturn
    End Function

    Public Function fk_SplitToSQL_in(ByVal Enter_Value As String) As String
        Dim StrResult As String = ""
        Dim tVal As String
        Dim nameArray As String() = Enter_Value.Split("|")
        Dim initials As String = String.Empty
        For Each name As String In nameArray
            tVal = name.ToString
            If StrResult = "" Then StrResult = tVal Else StrResult = StrResult & "','" & tVal

        Next
        Return StrResult
    End Function

    Public Function fk_SplitToSQL_inDash(ByVal Enter_Value As String) As String
        Dim StrResult As String = ""
        Dim tVal As String
        Dim nameArray As String() = Enter_Value.Split("|")
        Dim initials As String = String.Empty
        For Each name As String In nameArray
            tVal = name.ToString
            If StrResult = "" Then StrResult = tVal Else StrResult = StrResult & "','" & tVal

        Next
        Return StrResult
    End Function

    Public Sub _Recount_LeaveInfo(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "CREATE TABLE #Lv (EmpID Nvarchar (6),AtDate DateTime, LvNo Numeric (18,2),LeaveID Nvarchar (3))"
        sqlQRY = sqlQRY & " INSERt INtO #Lv SELECt tblLeaveTRD.EmpID ,tblLeaveTRD.LvDate,tblLeaveTRD.NoLeave,tblLeaveTRD.lvType FROM tblLeaveTRD,tblLeaveTRH WHERE tblLeaveTRD.RqID = tblLeaveTRH.RqID AND tblLeaveTRD.EmpID = tblLeaveTRH.EmpID AND tblLeaveTRD.LvDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tblLeaveTRH.Status = 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET IsLeave = 0,NoLeave = 0 WHERE AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
        sqlQRY = sqlQRY & " UPDATE tblEMpRegister SET tblEmpRegister.IsLeave = 1,tblEmpRegister.NoLeave = #Lv.LvNo,tblEmpRegister.LeaveID = #Lv.LeaveID FROM #Lv,tblEmpRegister WHERE #Lv.EmpID = tblEmpRegister.EmpID AND #Lv.AtDate = tblEmpRegister.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    Public Sub _Process_LateEarly(ByVal dtStart As Date, ByVal dtEnd As Date, ByVal intLate As Integer)

        Dim sqlQRY As String = ""
        sqlQRY = " CREATE TABLE #T (EmpID Nvarchar (6),EnrolNo Numeric (18,2),wDate DateTime,d_Name Nvarchar (100),ShiftName Nvarchar (100),Department Nvarchar (100),ShortCode Nvarchar (4),sInTime DateTime ,sOutTime DateTime, InTime DateTime, OutTime DateTime, WorkMin Numeric (18,2),OrigMin Numeric (18,0),LateMin Numeric (18,0),EarlyMin Numeric (18,0), MorningExtra Numeric (18,2),WorkDays Numeric (18,2),IsLeave Numeric (18,0),inUpdate Numeric (18,0),OutUpdate Numeric (18,0)) "
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmployee.RegID ,tblEmployee.EnrolNo,tblEmpRegister.AtDate,tblEmployee.dispName  ,tblSetShiftH.ShiftName ,tblSetDept.DeptName,tblSetshiftH.ShortCode ,  sInTime = tblEmpRegister.AtDate + tblSetshiftH.InTime  ,  sOutTime = CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate Else DATEAdd(day,1,tblEmpRegister.AtDate ) END+CASE WHEN tblDayType.WorkUnit = .5 THEn tblSetShiftH.EndCIN ELSE tblSetShiftH.OutTime  END  ,  InTime = tblEmpRegister.InTime1,OutTime =tblEmpRegister.OutTime1,tblEmpRegister.WorkMins ,tblEmpRegister.OrigMin ,0,0,0,tblEmpRegister.NRWorkDay,tblEmpRegister.IsLeave,tblEmpRegister.inUpdate,tblEmpRegister.OutUpdate  FROM tblEmployee,tblEmpRegister,tblSetShiftH,tblSetDept,tblDayType WHERE  tblEmployee.RegID = tblEmpRegister.EmpID And tblEmpRegister.AllShifts = tblSetShiftH.ShiftID And tblEmployee.DeptID = tblSetDept.DeptID And tblEmpRegister.DayTypeID = tblDayType.TypeID  AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tblEmpRegister.AntStatus = 1 AND tblEmpRegister.IsLeave = 0 AND tblDayType.WorkUnit <> 0 AND tblSetShiftH.CalWorkMin = 0 "
        sqlQRY = sqlQRY & " UPDATE #T SET LateMin = CASE WHEN DATEDIFF(MINUTE ,sInTime ,InTime )< " & intLate & " THEN  0 WHEN IsLeave = 1 THEN 0 ELSE DATEDIFF(MINUTE ,sInTime ,InTime ) END "
        sqlQRY = sqlQRY & " UPDATE #T SET EarlyMin = CASE WHEN  DateDiff(Minute,OutTime,sOutTime)< 0 THEN 0 WHEN isLeave = 1 THEN 0 WHEN OutUpdate = 0 THEN 0 ELSE  DateDiff(Minute,OutTime,sOutTime) END   "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.LateMins = (#T.LateMin+#T.EarlyMin), tblEmpRegister.IsLate = CASE WHEN #T.LateMin >0 THEN 1 ELSE 0 END FROM #T,tblEmpRegister WHERE #T.EMpID = tblEmpRegister.EmpID AND #T.wDate = tblEmpRegister.AtDate"
        'Update Late Early 0 for Off days 
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.LateMins = 0,tblEmpRegister.IsLate = 0 FROM tblEmpRegister,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tbldaytype.WorkUnit =0"
        FK_EQ(sqlQRY, "S", "", False, False, True)
    End Sub


    '******* EXTERNAL EXC Update Procedure
    'DATE   : 16/AUG/2017
    'MOD    : External Execution
    'BY     : Kasun

    Public Sub Proc_ExternalExecution(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim dgv As New DataGridView
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToAddRows = False

        With dgv
            .Columns.Add("rID", "rID")
            .Columns.Add("rName", "rName")
            .Columns.Add("rQry", "rQry")

        End With

        Dim sqlQRY As String = ""
        sqlQRY = "SELECT RepID,RepName,RpQRY From tblExeExecute WHERE r_Status = 0 Order by r_Order"
        Load_InformationtoGrid(sqlQRY, dgv, 3)
        Dim StrStDate As String
        Dim StrEdDate As String

        StrStDate = "'" & Format(dtStart, strRetDateTimeFormat) & "'"

        StrEdDate = "'" & Format(dtEnd, strRetDateTimeFormat) & "'"
        With dgv
            For i As Integer = 0 To .RowCount - 1

                sqlQRY = .Item(2, i).Value
                sqlQRY = Replace(sqlQRY, "@stDate", StrStDate)
                sqlQRY = Replace(sqlQRY, "@edDate", StrEdDate)
                sqlQRY = Replace(sqlQRY, "`", "'")

                If sqlQRY <> "" Then
                    FK_EQ(sqlQRY, "S", "", False, False, True)
                End If

            Next
        End With

    End Sub

    '**************************************
    Public Sub process_AttendanceParameters(ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal dblMinOT As Double, ByVal intOTRndOption As Integer, ByVal dblOTRound As Double, ByVal dblLateMins As Double)

        'This part is adding tosolve the problem that 'Work Hours and Day Calculating without in out time/ 20160215********************
        sSQL = "UPDATE tblGetInOut SET WorkMin=0 WHERE atDate BETWEEN  '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'; " &
        " UPDATE tblempregister SET WorkMins=0,nrWorkDay=0,cotHrs=0,normalot=0,normalOTHrs=0,doubleOT=0,doubleOTHrs=0,tripleOT=0,tripleOTHrs=0,isNightWork=0 WHERE atDate BETWEEN  '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"

        FK_EQ(sSQL, "S", "", False, False, True)
        '*********************************************************************************************************************
        Dim sqlQRY As String
        sqlQRY = "update tblGetINOUT SET tblGetINOUT.WorkMin = CASE WHEN tblGetINOUT.InUpdate = 0 THEN 0 WHEN tblGetINOUT.OutUpdate = 0 THEN 0 ELSE DateDiff(minute,tblGetINOUT.InTime,tblGetINOUT.OutTime) END," &
        " IsLate = 0," &
        " tblGetINOUT.LateMin = CASE WHEN tblGetINOUT.AntStatus = 0 THEN 0 WHEN tblGetINOUT.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblGetINOUT.sInTime,tblGetINOUT.InTime) - " & dblLateMins & " < 0 THEN 0 Else DateDiff(minute,tblGetINOUT.sInTime,tblGetINOUT.InTime) - " & dblLateMins & "  END," &
        " IsEarly = 0," &
        " tblGetINOUT.EarlyMin = CASE WHEN tblGetINOUT.AntStatus = 0 THEN 0 WHEN  tblGetINOUT.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblGetINOUT.OutTime,tblGetINOUT.sOutTime) <0 THEN 0 Else DateDiff(minute,tblGetINOUT.OutTime,tblGetINOUT.sOutTime) END," &
        " tblGetINOUT.BOTMin = CASE WHEN tblGetINOUT.AntStatus = 0 THEN 0 WHEN tblSetEmpCategory.OTAllc = 0 THEN 0 WHEN tblGetINOUT.InUpdate = 0 THEN 0 WHEN DateDiff(minute,tblGetINOUT.InTime,tblGetINOUT.sInTime) < 0 THEN 0 Else DateDiff(minute,tblGetINOUT.InTime,tblGetINOUT.sInTime) END," &
        " tblGetINOUT.EOTMin = CASE WHEN tblGetINOUT.AntStatus = 0 THEN 0 WHEN tblSetEmpCategory.OTAllc = 0 THEN 0 WHEN tblGetINOUT.OutUpdate = 0 THEN 0 WHEN DateDiff(minute,tblGetINOUT.sOutTime,tblGetINOUT.OutTime) < 0 THEN 0 Else  DateDiff(minute,tblGetINOUT.sOutTime,tblGetINOUT.OutTime) END" &
        " from tblGetINOUT " &
        " INNER JOIN tblSetShiftH ON tblGetINOUT.ShiftID = tblSetShiftH.ShiftID " &
        " INNER JOIN tblEmployee ON tblGetINOUT.EmpID  = tblEmployee.RegID " &
        " INNER JOIN tblSetEmpCategory ON tblEmployee.CatID = tblSetEmpCategory.CatID " &
        " WHERE tblGetINOUT.AntStatus = 1 AND tblGetINOUT.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"

        'Update to Summary Table 
        sqlQRY = sqlQRY & " DELETE FROM tblTmpAtnPrc"
        sqlQRY = sqlQRY & " insert into tblTmpAtnPrc " &
        " select EmpID,AtDate,sum(WorkMin),Sum(LateMin),Max(IsLate),Sum(EarlyMin),Max(IsEarly),Sum(BOTMin),Sum(EOTMin),Max(AntStatus) FROM tblGetinOut WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' GROUP by EmpID,AtDate"

        sqlQRY = sqlQRY & " update tblEmpRegister SET WorkMins = CASE WHEN tblTmpAtnPrc.WorkMin Is Null THEN 0 ELSE tblTmpAtnPrc.WorkMin END,IsLate = tblTmpAtnPrc.IsLate,LateMins = CASE WHEN tblTmpAtnPrc.LateMin Is Null THEN 0 ELSE tblTmpAtnPrc.LateMin END," &
        " EarlyMins = CASE WHEN tblTmpAtnPrc.EarlyMim Is Null THEN 0 ELSE tblTmpAtnPrc.EarlyMim END,IsEarly = CASE WHEN tblTmpAtnPrc.IsEarly Is Null THEN 0 ELSE tblTmpAtnPrc.IsEarly END, " &
        " BeginOT = CASE WHEN tblTmpAtnPrc.BOTMin Is Null THEN 0 ELSE tblTmpAtnPrc.BOTMin END ,EndOT = CASE WHEN tblTmpAtnPrc.EOTMin Is Null THEN 0 ELSE tblTmpAtnPrc.EOTMin END,AntStatus = CASE WHEN tblTmpAtnPrc.AntStatus Is Null  THEN 0 ELSE tblTmpAtnPrc.AntStatus END FROM tblTmpAtnPrc  " &
        " INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = tblTmpAtnPrc.EmpID AND tblEmpRegister.AtDate = tblTmpAtnPrc.AtDate"
        Dim bolPrc As Boolean

        bolPrc = FK_EQ(sqlQRY, "P", "", False, False, True)

        sqlQRY = ""

        'Update Late & Early Status ,Work Minuts 
        sqlQRY = sqlQRY & " update tblEmpRegister SET WorkHrs = CASE WHEN WorkMins < 0 THEN 0 Else Round(WorkMins/60,2) End,isLate = CASE  WHEN LateMins <=0 THEN 0 Else 1 END,isEarly = CASE  WHEN EarlyMins <= 0 THEN 0 Else 1 End FROM tblEmpRegister WHERE atDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"

        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET BgOTHrs = CASE  WHEN BeginOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN floor(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & " Else Round(ceiling(BeginOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"

        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET EdOTHrs = CASE  WHEN EndOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",1) Else Round(ceiling(EndOT/" & dblOTRound & ")/60*" & dblOTRound & ",0) END  END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"

        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET cOTHrs = CASE AtEdit WHEN 0 THEN bgOTHrs + EdOTHrs Else cOTHrs END FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
        bolPrc = FK_EQ(sqlQRY, "P", "", False, False, True)
        'Should Update the Summary of the INOUT table to the EmpRegiter 

        '******************* 22/Aug/2015 working hours related ******************
        'Modification   : 22/Aug/2015
        'By             : Kasun
        'Description    : Calculate Work hours based on employee In time, If employee in time is before shift in, with this this will calculate as based on day type Configuration panal day type configuration

        CalWorkingHrs_BasedOnShiftIN(dtStartDate, dtEndDate)

        '************** End working hours related ***********************

        'Clear Late Early for the Non  Working Days
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.IsLate = CASE tblDayType.WorkUnit WHEN 0 THEN 0 ELSE tblEmpRegister.IsLate END, " &
        " tblEmpRegister.LateMins= CASE tblDayType.WorkUnit WHEN 0 THEN 0 ELSE tblEmpRegister.LateMins END , " &
        " tblEmpRegister.IsEarly = CASE tblDayType.WorkUnit WHEN 0 THEN 0 ELSE tblEmpRegister.IsEarly END , " &
        " tblEmpRegister.EarlyMins = CASE tblDayType.WorkUnit WHEN 0 THEN 0 ELSE tblEmpRegister.Earlymins END FROM tblEmpRegister INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblDayType.WorkUnit = 0 "
        FK_EQ(sqlQRY, "S", "", False, False, False)

        'Phase To should completed
        'sqlQRY = " DELETE FROM tblTempPrc"
        'sqlQRY = sqlQRY & " INSERT INTO tbltempPrc select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblConfigDays.NrDays,tblConfigDays.OTYes,tblConfigDays.AddDays,tblConfigDays.AddLv  from tblEmpRegister INNER JOIN tblConfigDays ON tblEmpRegister.DayTypeID = tblConfigDays.TypeID AND tblEmpRegister.WorkMins Between tblConfigDays.FrHours AND tblConfigDays.ToHrs WHERE tblEmpRegister.atDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' Order By tblEmpRegister.EmpID,tblEmpRegister.AtDate"
        ''Update to Master Table 
        'sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.NRWorkDay = tbltempPrc.NRDay,tblEmpRegister.AdWorkDay = tblTempPrc.AdDay,tblEmpRegister.NoLeave = tblTempPrc.NoLv FROM tblTempPrc INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = tblTempprc.EmpID AND tblEmpRegister.AtDate = tblTempPrc.AtDate"
        'If bolPrc = True Then FK_EQ(sqlQRY, "P", "", False, True, True)

        'Calculate Late Mins

        sqlQRY = "Exec sp_GenOrigMin '" & Format(dtStartDate, strRetDateTimeFormat) & "','" & Format(dtEndDate, strRetDateTimeFormat) & "'," & dblLateMins : FK_EQ(sqlQRY, "S", "", False, False, True)

        If intNewOTCOnfig = 1 Then
            If intDaySeperateOT = 1 Then
                _DayilyOTProcess(dtStartDate, dtEndDate)
            Else
                New_OTCalMethod(dtStartDate, dtEndDate)
            End If
        Else
            OT_UpdateProcedure(dtStartDate, dtEndDate)
        End If

        'sqlQRY = "exec sp_RunOT '" & Format(dtStartDate, strRetDateTimeFormat) & "','" & Format(dtEndDate, strRetDateTimeFormat) & "'," & dblOTRound & "," & intOtCalMeth & "," & dblMinOT
        'FK_EQ(sqlQRY, "S", "", False, False, True)
        'Round & Conver OT Hours 

        'Meel Deductions
        Meal_Deduction(dtStartDate, dtEndDate)

        'Modification On 13/9/2014
        Dim intBeginOTGap As Integer = fk_sqlDbl("SELECT NoBOTGap FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),Atdate DateTime, BeginOT Numeric (18,2),CalBegin Numeric (18,0),OTAllow DateTime,sInTime DateTime,InTime DateTime,WorkUnit Numeric (18,0))"
        sqlQRY = sqlQRY & "  INSERT INTO #T Select tblEmployee.RegID,tblEmpRegister.AtDate,0,tblEmployee.IsEmpBOT,DateAdd(Minute,-" & intBeginOTGap & ",tblEmpRegister.AtDate+tblsetShiftH.InTime),tblEmpRegister.AtDate+tblsetShiftH.InTime,tblEmpRegister.InTime1,tblDayType.WorkUnit " &
         " FROM tblEmployee,tblEmpRegister,tblSetShiftH,tblDayType WHERE tblEmployee.RegID = tblEmpregister.EmpID AND tblEmpRegister.ShiftID = tblSetShiftH.ShiftID  AND tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.AntStatus = 1 "
        sqlQRY = sqlQRY & " UPDATE #T SET InTIme =  CASE WHEN DateDiff(Minute,OTAllow,INTime)<0 THEN OTAllow ELSE InTime END WHERE  calBegin = 1 AND WorkUnit <> 0"
        sqlQRY = sqlQRY & " UPDATE #T SET BeginOT = CASE WHEN DateDiff(Minute,InTime,sInTime) < 0 THEN 0 Else DateDiff(Minute,InTime,sInTime) END FROM #T WHERE calBegin = 1 "
        'sqlQRY = sqlQRY & " UPDATE #T SET BeginOT = CASE WHEN DateDiff(Minute,InTime,OTAllow)<0 THEN 0 WHEN DateDiff(Minute,InTime,sInTime) < 0 THEN 0 Else DateDiff(Minute,InTime,sInTime) END FROM #T WHERE calBegin = 1 AND WorkUnit <> 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.BeginOT = #T.BeginOT,tblEmpRegister.NormalOT = tblEmpRegister.NormalOT + #t.BeginOT FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate"
        'FK_EQ(sqlQRY, "S", "", False, False, True)

        'sqlQRY = " UPDATE tblEmpRegister SET NormalOTHrs = CASE  WHEN NormalOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(NormalOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(NormalOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END  END , " & _
        '" DoubleOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(DoubleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(DoubleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END, " & _
        '" TripleOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(TripleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(TripleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END,workHrs = workMins/60 FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
        'bolPrc = FK_EQ(sqlQRY, "P", "", False, False, True)
        ' Move from Here

        Calc_DueMinutes(dtStartDate, dtEndDate)

        'Calculate late Early
        ' _Process_LateEarly(dtStartDate, dtEndDate, dblLateMins)
        'Calculate Late Early Based On Configuration Panel
        CalLateEarlyWithCFP(dtStartDate, dtEndDate, dblLateMins)

        'Update Leave taken status 
        _Recount_LeaveInfo(dtStartDate, dtEndDate)

        'Arrange Shift Line in Split Shifts
        proc_ShiftLineOnSplit(dtStartDate, dtEndDate)
        'Calculate Gap Minutes between two shifts in tblGetInOut Table 
        Calc_GapOnTwoShift(dtStartDate, dtEndDate)

        Proc_ExternalExecution(dtStartDate, dtEndDate)
        'Move to there 
        sqlQRY = " UPDATE tblEmpRegister SET NormalOTHrs = CASE  WHEN NormalOT < " & dblMinOT & " THEN 0 ELSE CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(NormalOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(NormalOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END  END , " &
    " DoubleOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(DoubleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(DoubleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END, " &
    " BgOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(beginOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(beginOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END, " &
    " EdOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(endOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(endOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END, " &
    " TwoHalfOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(TwoHalfOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(TwoHalfOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END, " &
    " TripleOTHrs = CASE " & intOTRndOption & " WHEN 1 THEN Round(floor(TripleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) Else Round(ceiling(TripleOT/" & dblOTRound & ")/60*" & dblOTRound & ",2) END,workHrs = workMins/60 FROM tblEmpRegister WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
        bolPrc = FK_EQ(sqlQRY, "P", "", False, False, True)

        Update_ApprovedOTs(dtStartDate, dtEndDate)

        'Clear OT for Non Selected Employee category
        sqlQRY = "UPDATE tblEmpRegister SET  cOTHrs = 0,NOrmalOT =0 ,DoubleOT = 0,NormalOThrs =0,DoubleOTHrs =0,TripleOThrs =0 from tblEmpRegister,tblEmployee,tblSetEmpCategory " &
        " WHERE tblEmployee.RegID = tblEmpRegister.EmpID AND tblEmployee.CatID = tblSetEmpCategory.CatID AND tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblSetEmpCategory.OTAllc = 0"
        FK_EQ(sqlQRY, "S", "", False, False, True)


        'Clear OT for Non Selected Employee category
        sqlQRY = " UPDATE tblEmpRegister SET COTHrs = NormalOTHrs+DoubleOTHrs+TripleOTHrs WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

        'Author         : Kasun
        'Date           : 9/ March- 2016
        'Description    : Related KDU, New Option Give to Change Any Parameter Mannually, Here it's re uploading to EmpRegister After Auto Calculations
        '******************************************
        Dim dgvRUN As New DataGridView
        With dgvRUN
            .Columns.Add("CodeID", "CodeID")
            .Columns.Add("fldName", "fldName")

        End With
        Load_InformationtoGrid("SELECT c_ID,fldName FROM tblDaySettings ", dgvRUN, 2)
        Dim s_FldID As String = "" : Dim s_CodeID As String = ""
        sqlQRY = ""
        With dgvRUN
            For i As Integer = 0 To .RowCount - 2
                s_CodeID = .Item(0, i).Value
                s_FldID = .Item(1, i).Value

                sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister." & s_FldID & " = tblDayTrnsD.New_Value FROM tblDayTrnsD,tblEmpRegister WHERE tblDayTrnsD.EmpID = tblEmpRegister.EmpID AND tblDayTrnsD.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblDayTrnsD.c_ID = '" & s_CodeID & "' AND tblDayTrnsD.r_Status=0"

            Next

        End With
        FK_EQ(sqlQRY, "S", "", False, False, True)


        '************ END **********************
        sqlQRY = "UPDATE tblEmpRegister SET  cOTHrs = 0,NOrmalOT =0 ,DoubleOT = 0,NormalOThrs =0,DoubleOTHrs =0,TripleOThrs =0 from tblEmpRegister,tblEmployee,tblSetEmpCategory " &
        " WHERE tblEmployee.RegID = tblEmpRegister.EmpID AND tblEmployee.CatID = tblSetEmpCategory.CatID AND tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblSetEmpCategory.OTAllc = 0"
        FK_EQ(sqlQRY, "S", "", False, True, True)

        'Clear Late Early for Leave applied Days --Kasun 20160708
        'sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.IsLate = 0, " & _
        '" tblEmpRegister.LateMins= 0 , " & _
        '" tblEmpRegister.IsEarly = 0 , " & _
        '" tblEmpRegister.EarlyMins = 0  WHERE tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.isLeave=1 "
        sqlQRY = "CREATE TABLE #T (RegID NVARCHAR (6),atDate DATETIME,isleave NUMERIC (18,0),LEStatus NVARCHAR (3),isLate NUMERIC (18,0),lateMins NUMERIC (18,0),isEarly NUMERIC (18,0),earlyMins NUMERIC (18,0))" &
" INSERT INTO #T SELECT empID,atDate,isLeave,LEStatus,case when LEStatus='0|0'AND LateMins=0 then 0 when LEStatus='0|0'AND LateMins>0 then 1 when LEStatus='1|0' then 0 when LEStatus='1|1' then 0 when LEStatus='0|1' AND LateMins=0 then 0 when LEStatus='0|1' AND LateMins>0 then 1 end as 'isLate',lateMins,case when LEStatus='0|0' and earlyMins=0 then 0 when LEStatus='0|0' and earlyMins>0 then 1 when LEStatus='1|0' and earlyMins=0 then 0  when LEStatus='1|0' and earlyMins>0 then 1 when LEStatus='1|1' then 0 when LEStatus='0|1' then 0 end as 'isEarly',earlyMins from tblEmpRegister WHERE tblEmpRegister.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.isLeave=1 " &
" UPDATE #T SET isLate=0 FROM #T where lateMins=0 UPDATE #T SET isEarly=0 FROM #T where earlyMins=0 UPDATE #T SET LEStatus='0|0' WHERE lateMins=0 AND earlyMins=0 UPDATE tblEmpRegister SET tblEmpRegister.isLate=#T.isLate,tblEmpRegister.isEarly=#T.isEarly FROM tblEmpRegister,#T WHERE tblEmpRegister.EmpiD=#T.RegID AND #T.atDate=tblEmpRegister.AtDate UPDATE tblEmpRegister SET tblEmpRegister.LEStatus=#T.LEStatus FROM tblEmpRegister,#T WHERE tblEmpRegister.EmpiD=#T.RegID AND #T.atDate=tblEmpRegister.AtDate AND #T.LEStatus='0|0'"

        FK_EQ(sqlQRY, "S", "", False, False, False)


        'sqlQRY = "exec sp_DivMinutes '" & Format(dtStartDate, strRetDateTimeFormat) & "','" & Format(dtEndDate, strRetDateTimeFormat) & "'"
        'FK_EQ(sqlQRY, "S", "", False, True, True)

        'sqlQRY = sqlQRY & " UPDATE tblGetINOUT SET BeginOT = CASE WHEN tblGetINOUT.BeginOT>tblSetEmpCategory.MinBOT THEN tblSetEmpCategory.MinBOT ELSE tblGetINOUT.BeginOT END FROM tblGetINOUT INNER JOIN tblEmployee ON tblEmployee.Regid = tblGetINOUT.EmpID INNER JOIN tblSetEmpCategory ON tblEmployee.CatID = tblSetEmpCategory.CatID WHERE tblGetINOUT.AntStatus = 1 AND tblGetINOUT.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
    End Sub

    '************************** Late/Early Calculation Based On Day Vs Shift Configuration Panel ********************
    'Modification       : Late / Early Calculation Based On Shift Configuration 
    'Done By            : Kasun
    'Date               : 10/9/2015
    'Description        : Option given in Configuration Panel to mark Late/Early 

    Public Sub CalLateEarlyWithCFP(ByVal dtStart As Date, ByVal dtEnd As Date, ByVal CalGrase As Integer)
        Dim sqlQRY As String = ""
        sqlQRY = "Delete FROM tbllateCal" &
            " Insert into tblLateCal " &
            " select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.AllShifts,tblEmpRegister.InTime1,tblEmpRegister.OutTime1,ShiftIn = tblEmpRegister.AtDate+tblSetShiftH.InTime,ShiftOut = DateDiff(Day,tblSetShiftH.ShiftMode,tblEmpRegister.AtDate)+tblSetShiftH.OutTime,tblEmpRegister.WorkMins, " &
            " tblDayProfileD.CalLate,tblDayProfileD.CalEarly,IsCalLate = 0, CalLate = 0, IsCalEarly =0,CalEarly =0 from tblEmpRegister,tblSetShiftH,tblDayProfileD where  " &
            " tblEmpRegister.AllShifts = tblSetShiftH.ShiftID AND  " &
            " tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND tblEmpRegister.WorkMins Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'  Order By tblEmpRegister.EmpID,tblEmpRegister.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'UPDATE SHIFT OUT OF HALFDAYS
        sSQL = "CREATE TABLE #Tlate (EmpID NVARCHAR (6),atDate Datetime,shiftID NVARCHAR (3),shiftOut Datetime ,dayTypeID NVARCHAR (2),workUnit NUMERIC (18,2),shiftMode NUMERIC (18,0) ); INSERT INTO #Tlate SELECT empid,atdate,shiftid,shiftOut,0 ,0,0 FROM tblLateCal; UPDATE #Tlate SET #Tlate.daytypeID=tblEmpRegister.dayTypeID FROM tblEmpRegister,#Tlate WHERE tblEmpRegister.empID=#Tlate.empID AND tblEmpRegister.atDate=#Tlate.atDate AND tblEmpRegister.allShifts=#Tlate.shiftID ; UPDATE #Tlate SET #Tlate.workUnit=tblDayType.workUnit FROM tblDayType,#Tlate WHERE tblDayType.TypeID=#Tlate.dayTypeID ; UPDATE #Tlate set #Tlate.shiftOut=tblSetShiftH.EndCIn ,#Tlate.shiftMode=tblSetShiftH.shiftMode  FROM tblSetShiftH,#Tlate WHERE  tblSetShiftH.shiftID=#Tlate.shiftID AND #Tlate.workUnit=0.5 ; DELETE FROM #Tlate WHERE workUnit<>0.5; UPDATE tbllateCal set tbllateCal.shiftOut=DateDiff(Day,#Tlate.ShiftMode,#Tlate.AtDate)+#Tlate.shiftOut FROM #Tlate,tblLateCal  WHERE tblLateCal.EmpID=#Tlate.EmpID AND tblLateCal.atDate=#Tlate.atDate AND tblLateCal.shiftID=#Tlate.shiftID; "
        FK_EQ(sSQL, "S", "", False, False, True)

        'Calculate Late 
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,InTime DateTime,ShiftIn DateTime,CalLate Numeric (18,0),LateMin Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,InTime,ShiftIn,CASE WHEN DateDiff(Minute,ShiftIN,InTime) < " & CalGrase & " THEN 0 ELSE 1 END,CASE WHEN DateDiff(Minute,ShiftIN,InTime) < " & CalGrase & " THEN 0 ELSE DateDiff(Minute,ShiftIN,InTime) END FROM tblLateCal WHERE CalLate = 1"
        sqlQRY = sqlQRY & " UPDATE tblLateCal SET tblLateCal.IsCalLate = #T.CalLate ,tblLateCal.LateMin = #T.LateMin FROM #T,tblLateCal WHERE #T.EmpID = tblLateCal.EmpID AND #T.AtDate = tblLateCal.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Calculate Early
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,InTime DateTime,ShiftIn DateTime,CalEarly Numeric (18,0),EarlyMin Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,OutTime,ShiftOut,CASE WHEN DateDiff(Minute,OutTime,ShiftOut) < 0 THEN 0 ELSE 1 END,CASE WHEN DateDiff(Minute,OutTime,ShiftOut) < 0 THEN 0 ELSE DateDiff(Minute,OutTime,ShiftOut) END FROM tblLateCal WHERE CalEarly = 1"
        sqlQRY = sqlQRY & " UPDATE tblLateCal SET tblLateCal.IsCalEarly = #T.CalEarly ,tblLateCal.EarlyMin = #T.EarlyMin FROM #T,tblLateCal WHERE #T.EmpID = tblLateCal.EmpID AND #T.AtDate = tblLateCal.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update IsCalLate & IsCalEarly as 0 WHEN Late & Early Minutes are ZERO - 25/JUNE/2018
        sqlQRY = " UPDATE tblLateCal SET IsCalLate = 0 WHERE LateMin = 0"
        sqlQRY = sqlQRY & " UPDATE tblLateCal SEt IsCalEarly = 0 WHERE EarlyMin = 0"
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update tblEmpRegister Table 
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.IsLate = CASE WHEN tblEmpRegister.inUpdate=1 THEN tblLateCal.IsCalLate ELSE 0 END ,tblEmpRegister.IsEarly = CASE WHEN tblEmpRegister.outUpdate=1 THEN  tblLateCal.IsCalEarly ELSE 0 END,tblEmpregister.lateMins = CASE WHEN tblEmpRegister.inUpdate=1 THEN tblLateCal.LateMin ELSE 0 END, tblEmpRegister.EarlyMins =CASE WHEN tblEmpRegister.OutUpdate=1 THEN tblLateCal.EarlyMin ELSE 0 END FROM tblEmpRegister,tblLateCal WHERE  tblEmpRegister.EmpID = tblLateCal.EmpID AND tblEmpRegister.AtDate = tblLateCal.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)


    End Sub

    '******************************* Working Hours based *********************
    'Modifcation        : Recalculated Working based on Shift in time 
    'Done By            : Kasun
    'Date               : 22/8/2015
    'Description        : Calculate working hours based on shift in time

    Public Sub CalWorkingHrs_BasedOnShiftIN(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,InTime DateTime,sInTime DateTime,OutTime DateTime,sOutTime DateTime, WorkMin Numeric (18,2),nWorkMin Numeric (18,0))"
        sqlQRY = sqlQRY & "Insert into #T Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.InTime1, tblEmpRegister.AtDate+tblSetShiftH.InTime,tblEmpRegister.OutTime1,tblEmpRegister.AtDate+tblSetShiftH.OutTime,tblEmpRegister.WorkMins,0 from tblDayProfileD,tblEmpRegister,tblSetShiftH,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND " &
                " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin  AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tblDayProfileD.IsCalOnShiftIN = 1 AND tblEmpRegister.WorkMins > 0"

        sqlQRY = sqlQRY & " UPDATE #T SET nWorkMin = CASE WHEN Workmin-CASE WHEN DateDiff(Minute,InTime,sinTime) < 0 THEN 0 ELSE DateDiff(Minute,InTime,sinTime) END < 0 THEN 0 ELSE Workmin-CASE WHEN DateDiff(Minute,InTime,sinTime) < 0 THEN 0 ELSE DateDiff(Minute,InTime,sinTime) END END From #T "
        sqlQRY = sqlQRY & "UPDATE tblEmpRegister SET tblEmpRegister.WorkMins = #T.nWorkMin FROM #T,tblEmpRegister WHERE tblEmpRegister.EmpID = #T.EmpID ANd  tblEmpRegister.AtDate = #T.AtDate"

        FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    '********************* end working hours base *****************************
    Public Sub Meal_Deduction(ByVal dtStart As Date, ByVal dtEnd As Date)
        'INSERT RECORDS to the LCal Table
        '--------- Modified On  : 1-OCT-2017
        '--------- By           : Kasun
        '--------- Change       : Deducting Parameter was LDeductOT in Dinner Calculation, that should change to DDeductOT

        Dim sqlQRY As String = ""

        sqlQRY = "DELETE FROM LCal" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = " INSERT INTO LCal Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblEmpRegister.WorkMins,tblEmpRegister.InTime1,tblEmpRegister.OutTime1," &
        " tblDayProfileD.IsCalNight,DateAdd(Day,tblDayProfileD.NightWEF,tblEmpRegister.AtDate)+tblDayProfileD.NightTime,DateAdd(day,LunchWEF,tblEmpRegister.AtDate)+tblDayProfileD.LunchFrom,tblDayProfileD.IsLunch,CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpregister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE tblDayProfileD.LunchMins END,tblDayProfileD.LDedFROM," &
        " DateAdd(Day,tblDayProfileD.DinnerWEF,tblEmpRegister.AtDate)+tblDayProfileD.DinnerFrom,tblDayProfileD.IsDinner,CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpregister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE tblDayProfileD.DinnerMins END,tblDayProfileD.DDedFROM,tblEmpRegister.AntStatus,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate " &
        " FROM tblDayProfileD,tblEmpRegister WHERE tblEmpRegister.WorkMins Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND" &
        " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update Lunch Deducting into LCal
        sqlQRY = "UPDATE LCal SET  LunchMin= CASE WHEN LunchTime Between InTime AND OutTime THEN LunchMin ELSE 0 END,DinnerMin = CASE WHEN DinnerTime Between InTime AND OutTime THEN DinnerMin ELSE 0 END  " : FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update tblEmpRegister For Lunch Deductions
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.LunchMins = LCal.LunchMin, tblEmpRegister.DinnerMins = LCal.DinnerMin FROM LCal,tblEmpRegister WHERE LCal.EmpID = tblEmpRegister.EmpID AND LCal.AtDate = tblEmpRegister.AtDate" : FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update Lunch Deduction From NormalOT
        sqlQRY = " UPDATE tblEmpRegister SET tblEmpRegister.NormalOT = CASE WHEN tblEmpRegister.NormalOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.NormalOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DoubleOT = CASE WHEN tblEmpRegister.DoubleOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.DoubleOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 1"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TripleOT = CASE WHEN tblEmpRegister.TripleOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.TripleOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 2 "

        'IF DEDUCT DINNER AND LUNCH MINUTES FROM WORK HOURS IS ENABLED THEN WE MUST DEDUCT THEM FROM OT ALSO
        If IsLunchDinnerDeduct = 1 Then
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.LunchMin END  ,tblEmpRegister.NormalOT = CASE WHEN tblEmpRegister.NormalOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.NormalOT - LCal.LunchMin END,tblEmpRegister.DoubleOT = CASE WHEN tblEmpRegister.DoubleOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.DoubleOT - LCal.LunchMin END,tblEmpRegister.TripleOT = CASE WHEN tblEmpRegister.TripleOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.TripleOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 3 "
        Else
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 3 "
        End If
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'Update Dinner Deduction From NormalOT
        sqlQRY = " UPDATE tblEmpRegister SET tblEmpRegister.NormalOT = CASE WHEN tblEmpRegister.NormalOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.NormalOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.DDeductOT = 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DoubleOT = CASE WHEN tblEmpRegister.DoubleOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.DoubleOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.DDeductOT = 1 "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TripleOT = CASE WHEN tblEmpRegister.TripleOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.TripleOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.DDeductOT = 2"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.DDeductOT = 3 "
        If IsLunchDinnerDeduct = 1 Then
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.DinnerMin END,tblEmpRegister.NormalOT = CASE WHEN tblEmpRegister.NormalOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.NormalOT - LCal.DinnerMin END,tblEmpRegister.DoubleOT = CASE WHEN tblEmpRegister.DoubleOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.DoubleOT - LCal.DinnerMin END,tblEmpRegister.TripleOT = CASE WHEN tblEmpRegister.TripleOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.TripleOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.DDeductOT = 3 "
        Else
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.DDeductOT = 3 "
        End If
        FK_EQ(sqlQRY, "S", "", False, False, True)

        'UPDATE Night Allowance Payment Details
        sqlQRY = " CREATE TABLE #T (EMpID Nvarchar (6),AtDate DateTime, InTime DateTime,OutTime DateTime, NightTime DateTime, NightAll Numeric (18,0) ,PayNight Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #T select EmpID,AtDate,InTime,OutTime,Nighttime,NightCal,CASE WHEN Nighttime Between InTime AND OutTime THEN 1 ELSE 0 END  From LCAl WHERE NightCal = 1 "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.IsNightWork = #T.PayNight FROM #T,tblEmpRegister WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate " : FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    'Public Sub Meal_Deduction(ByVal dtStart As Date, ByVal dtEnd As Date)
    '    'INSERT RECORDS to the LCal Table 
    '    Dim sqlQRY As String = ""

    '    sqlQRY = "DELETE FROM LCal" : FK_EQ(sqlQRY, "S", "", False, False, False)
    '    sqlQRY = " INSERT INTO LCal Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblEmpRegister.WorkMins,tblEmpRegister.InTime1,tblEmpRegister.OutTime1," & _
    '    " tblDayProfileD.IsCalNight,DateAdd(Day,tblDayProfileD.NightWEF,tblEmpRegister.AtDate)+tblDayProfileD.NightTime,DateAdd(day,LunchWEF,tblEmpRegister.AtDate)+tblDayProfileD.LunchFrom,tblDayProfileD.IsLunch,CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpregister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE tblDayProfileD.LunchMins END,tblDayProfileD.LDedFROM," & _
    '    " DateAdd(Day,tblDayProfileD.DinnerWEF,tblEmpRegister.AtDate)+tblDayProfileD.DinnerFrom,tblDayProfileD.IsDinner,CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpregister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE tblDayProfileD.DinnerMins END,tblDayProfileD.DDedFROM,tblEmpRegister.AntStatus,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate " & _
    '    " FROM tblDayProfileD,tblEmpRegister WHERE tblEmpRegister.OrigMin Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND" & _
    '    " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

    '    'Update Lunch Deducting into LCal 
    '    sqlQRY = "UPDATE LCal SET  LunchMin= CASE WHEN LunchTime Between InTime AND OutTime THEN LunchMin ELSE 0 END,DinnerMin = CASE WHEN DinnerTime Between InTime AND OutTime THEN DinnerMin ELSE 0 END  " : FK_EQ(sqlQRY, "S", "", False, False, True)
    '    'Update tblEmpRegister For Lunch Deductions
    '    sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.LunchMins = LCal.LunchMin, tblEmpRegister.DinnerMins = LCal.DinnerMin FROM LCal,tblEmpRegister WHERE LCal.EmpID = tblEmpRegister.EmpID AND LCal.AtDate = tblEmpRegister.AtDate" : FK_EQ(sqlQRY, "S", "", False, False, True)
    '    'Update Lunch Deduction From NormalOT
    '    sqlQRY = " UPDATE tblEmpRegister SET tblEmpRegister.NormalOT = CASE WHEN tblEmpRegister.NormalOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.NormalOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 0"
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DoubleOT = CASE WHEN tblEmpRegister.DoubleOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.DoubleOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 1"
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TripleOT = CASE WHEN tblEmpRegister.TripleOT - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.TripleOT - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 2 "
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.LunchMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.LunchMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 3 " : FK_EQ(sqlQRY, "S", "", False, False, True)

    '    sqlQRY = " UPDATE tblEmpRegister SET tblEmpRegister.NormalOT = CASE WHEN tblEmpRegister.NormalOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.NormalOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 0"
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DoubleOT = CASE WHEN tblEmpRegister.DoubleOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.DoubleOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 1 "
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TripleOT = CASE WHEN tblEmpRegister.TripleOT - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.TripleOT - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 2"
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.workMins = CASE WHEN tblEmpRegister.workMins - LCal.DinnerMin < 0 THEN 0 ELSE tblEmpRegister.workMins - LCal.DinnerMin END FROM LCal,tblEmpRegister WHERE Lcal.EmpID = tblEmpRegister.EmpID AND lCal.AtDate = tblEmpRegister.AtDate AND LCal.LDeductOT = 3 " : FK_EQ(sqlQRY, "S", "", False, False, True)

    '    'UPDATE Night Allowance Payment Details 
    '    sqlQRY = " CREATE TABLE #T (EMpID Nvarchar (6),AtDate DateTime, InTime DateTime,OutTime DateTime, NightTime DateTime, NightAll Numeric (18,0) ,PayNight Numeric (18,0))"
    '    sqlQRY = sqlQRY & " INSERT INTO #T select EmpID,AtDate,InTime,OutTime,Nighttime,NightCal,CASE WHEN Nighttime Between InTime AND OutTime THEN 1 ELSE 0 END  From LCAl WHERE NightCal = 1 "
    '    sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.IsNightWork = #T.PayNight FROM #T,tblEmpRegister WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate " : FK_EQ(sqlQRY, "S", "", False, False, True)

    'End Sub
    'Imashi Pulication/ Cal Minutes between 2 shift gap 


    'Transfer Edited OT to the Actuals 

    Public Sub Update_ApprovedOTs(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.NormalOTHrs = tblAprovedOT.ApNOT,tblEmpRegister.DoubleOTHrs = tblAprovedOT.ApDOT , tblEmpRegister.TripleOTHrs = tblAprovedOT.ApTOT FROM tblEmpRegister,tblAprovedOT WHERE tblEmpRegister.EmpID = tblAprovedOT.EmpID AND tblEmpRegister.AtDate = tblAprovedOT.AtDate AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tblAprovedOT.Status = 0"
        FK_EQ(sqlQRY, "S", "", False, False, True)
    End Sub

    'Calculate Due Minutes
    Public Sub Calc_DueMinutes(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "UPDATE tblEMpRegister SET DivMin = 0 WHERE atdate between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' " : FK_EQ(sqlQRY, "S", "", False, False, True)
        sqlQRY = " CREATE TABLE #T (EmpID nvarchar (6),AtDate DateTime, InTime DateTime, OutTime DateTime,WorkMin Numeric (18,2),AlcMins Numeric (18,2),NrDays Numeric (18,2),DueMins Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmpRegister.Atdate,tblEmpRegister.inTime1,tblEmpRegister.OutTime1,tblEmpRegister.WOrkMins,tblSetShiftH.WrkMins," &
        " tblDayProfileD.NrDays,CASE WHEN tblEmpRegister.WOrkMins-tblSetShiftH.WrkMins < 0 THEN tblSetShiftH.WrkMins - tblEmpRegister.WOrkMins ELSE 0 END FROM tblEmpRegister,tblSetShiftH,tblDayProfileD " &
        " WHERE tblEmpRegister.allShifts = tblSetShiftH.ShiftID And tblEmpRegister.ShiftID = tblDayProfileD.ShiftID And tblEmpRegister.DayTypeID = tblDayProfileD.DayID " &
        " AND tblEmpRegister.WorkMins BEtween tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tblDayProfileD.NrDays = 1 "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DivMin = #T.DueMins FROM #T,tblEmpRegister WHERE #T.EMpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)
    End Sub

    Public Sub Calc_GapOnTwoShift(ByVal DtStart As Date, ByVal dtEnd As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "CREATE TABLE #TAll (EmpID Nvarchar (6),AtDate DateTime,WorkMin Numeric (18,0),Ac_WorkMin Numeric (18,0),GapMin Numeric (18,0)," &
 " AntStatus Numeric (18,0),InUpdate Numeric (18,0),OutUpdate Numeric (18,0),IsCalGrace Numeric (18,0),GraceOnSp Numeric (18,2),LateMin Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERt into #TAll Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.WorkMins,CASE WHEN tblEmpRegister.AntStatus = 0 THEN 0 WHEN tblEmpRegister.InUpdate = 0 THEN 0 WHEN tblEmpRegister.OutUpdate = 0 THEN 0 ELSE DateDiff(Minute,tblEmpRegister.InTime1,tblEmpRegister.OutTime1) END,0,tblEmpRegister.AntStatus,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate," &
        " tblDayProfileD.CalSplitGrace,GraseOnSplit,0 FROM tblEmpRegister,tblDayProfileD " &
        " WHERE tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND tblEmpRegister.AtDate Between '" & Format(DtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND " &
        " tblEmpRegister.WOrkMins Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin "
        sqlQRY = sqlQRY & " UPDATE #TAll SET GapMin = CASE WHEN Ac_WorkMin-WorkMin  < 0 THEN 0 ELSE Ac_WorkMin-WorkMin END"
        sqlQRY = sqlQRY & " UPDATe #tAll SET LateMin = CASE WHEN IsCalGrace = 0 THEN 0 ELSE CASE WHEN GapMin-GraceOnSp<0 THEN 0 ELSE GapMin-GraceOnSp END END"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.GapLateMin = #TAll.GapMin FROM #TAll,tblEmpRegister WHEre tblEmpRegister.EmpID = #TAll.EmpID AND tblEmpRegister.AtDate = #TAll.AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    'Public Sub OT_UpdateProcedure(ByVal dtStart As Date, ByVal dtEnd As Date)
    '    'Modification Done for the Aitken Spence with centralized OT mechanism
    '    'Get the Calculation Mechamism
    '    Dim intCalMeth As Integer = fk_sqlDbl("SELECT CalOnOrigMin FROM tblControl")
    '    Dim sqlQRY As String = ""
    '    Try
    '        sqlQRY = "DROP TABLE TData " : FK_EQ(sqlQRY, "S", "", False, False, False)
    '        sqlQRY = "select tblEmpregister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.AtDate+(Convert(nvarchar(10),tblEmpRegister.InTime1,114)) As InTime,tblEmpRegister.OutTime1 As OutTime,WorkMins = CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END,tblEmpRegister.ShiftID,tblEmpRegister.DayTypeID,tblDayProfileD.PrfID, " & _
    '            " tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblDayProfileD.NrDays,tblDayProfileD.LvDays,tblDayProfileD.IsNormalOT,tblDayProfileD.NOTMode,DateAdd(Day,NOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.NOTTime As NOTTime,tblDayProfileD.NOTMins,tblDayProfileD.IsDoubleOT, " & _
    '            " tblDayProfileD.DOTMode,DateAdd(Day,DOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.DOTTime As DOTTime,tblDayProfileD.DOTMins,tblDayProfileD.Status,tblDayProfileD.AddDay,tblDayProfileD.isTOT, " & _
    '            " tblDayProfileD.TOTMode,DateAdd(Day,TOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.TOTTime As TOTTime,tblDayProfileD.TOTMins INTO TData from tblDayProfileD,tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND " & _
    '            " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AntStatus = 1 AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
    '        sqlQRY = sqlQRY & " ALTER TABLE TData ADD NOTMin Numeric (18,2) NOT NULL Default 0"
    '        sqlQRY = sqlQRY & " ALTER TABLE TData ADD DOTMin Numeric (18,2) NOT NULL Default 0"
    '        sqlQRY = sqlQRY & " ALTER TABLE TData ADD TOTMin Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, True)

    '        'Normal OT Calculation
    '        sqlQRY = "UPDATE TData SET NOTMin = CASE WHEN IsNormalOT = 0 THEN 0 ELSE CASE WHEN NOTMode = 1 THEN CASE WHEN WorkMins - NOTMins <0 THEN 0 ELSE workmins - NOTMins END ELSE CASE WHEN DateDiff(Minute,NOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,NOTTime,OutTime) END END END "
    '        'Double OT Calculation
    '        sqlQRY = sqlQRY & " UPDATE TData SET DOTMin = CASE WHEN IsDoubleOT = 0 THEN 0 ELSE CASE WHEN DOTMode = 1 THEN CASE WHEN WorkMins - DOTMins <0 THEN 0 ELSE workmins - DOTMins END ELSE CASE WHEN DateDiff(Minute,DOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,DOTTime,OutTime) END END END "
    '        'Triple OT Calculation
    '        sqlQRY = sqlQRY & " UPDATE TData SET TOTMin = CASE WHEN IsTOT = 0 THEN 0 ELSE CASE WHEN TOTMode = 1 THEN CASE WHEN WorkMins - TOTMins <0 THEN 0 ELSE workmins - TOTMins END ELSE CASE WHEN DateDiff(Minute,TOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,TOTTime,OutTime) END END END "
    '        FK_EQ(sqlQRY, "S", "", False, False, True)
    '        'Balance Calculated Normal OT,Double OT,Triple OT for the Extract Values
    '        sqlQRY = "UPDATE TData SET NOTMin = CASE WHEN isDoubleOT = 1 THEN CASE WHEN NOTMin-DOTMin <0 THEN 0 ELSE NOTMin-DOTMin END ELSE NOTMin END, DOTMin = CASE WHEN isTOT = 1 THEN CASE WHEN DOTMin-TOTMin <0 THEN 0 ELSE DOTMin-TOTMin END ELSE DOTMin END " : FK_EQ(sqlQRY, "S", "", False, False, True)
    '        'Update Master Table Summary Details 
    '        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.NRWorkDay = TData.NrDays,tblEmpRegister.AutoLeaveNo = TData.LvDays,tblEmpRegister.AdWorkDay = TData.AddDay,tblEmpregister.NormalOT = TData.NOTMin,tblEmpRegister.DoubleOT = Tdata.DOTMin,tblEmpRegister.TripleOT = TData.TOTMin FROM TData,tblEmpRegister WHERE TData.EmpID = tblEmpRegister.EmpID AND TData.AtDate  = tblEmpRegister.AtDate" : FK_EQ(sqlQRY, "S", "", False, False, True)
    '        'Lunch Calculation

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Public Sub OT_UpdateProcedure(ByVal dtStart As Date, ByVal dtEnd As Date)
        'Modification Done for the Aitken Spence with centralized OT mechanism
        Dim sqlQRY As String = ""
        Try
            sqlQRY = "DROP TABLE TData " : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = " select tblEmpregister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.InTime1 As InTime,tblEmpRegister.OutTime1 As OutTime,WorkMins = CASE WHEN tblDayType.WorkUnit =0 THEN tblEmpRegister.WorkMins ELSE CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END END,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblDayProfileD.PrfID, " &
                " tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblDayProfileD.NrDays,tblDayProfileD.LvDays,tblDayProfileD.IsNormalOT,tblDayProfileD.NOTMode,DateAdd(Day,NOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.NOTTime As NOTTime,tblDayProfileD.NOTMins,tblDayProfileD.IsDoubleOT, " &
                " tblDayProfileD.DOTMode,DateAdd(Day,DOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.DOTTime As DOTTime,tblDayProfileD.DOTMins,tblDayProfileD.Status,tblDayProfileD.AddDay,tblDayProfileD.isTOT, " &
                " tblDayProfileD.TOTMode,DateAdd(Day,TOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.TOTTime As TOTTime,tblDayProfileD.TOTMins, " &
                " tblDayProfileD.IsUpOT,tblDayProfileD.UpOTMode,tblEmpRegister.AtDate+tblDayProfileD.UpOTTime As UpOTTime,tblDayProfileD.WEFUpOT,tblDayProfileD.UpOTMins,tblDayProfileD.IsOTStart,tblEmpRegister.AtDate+tblDayProfileD.OTStartTime As OTStartTime " &
                " INTO TData from tblDayProfileD,tblEmpRegister,tblSetShiftH,tblDayType WHERE tblEmpRegister.DayTypeID = tblDayType.TypeID AND tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND " &
                " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin  AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
            sqlQRY = sqlQRY & " ALTER TABLE TData ADD NOTMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE TData ADD DOTMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE TData ADD TOTMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE TData ADD UpMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE TData ADD DueMin Numeric (18,2) NOT NULL Default 0 "
            FK_EQ(sqlQRY, "S", "", False, False, True)

            'Reset Work Minus
            sqlQRY = "UPDATE TData SET DueMin = CASE WHEN DateDiff(Minute,InTime,OTStartTime) < 0 THEN 0 WHEN IsOTStart = 0 THEN 0 WHEN WorkMins = 0 THEN 0  ELSE DateDiff(Minute,InTime,OTStartTime) END "
            sqlQRY = sqlQRY & " UPDATE TData SET WorkMins = WorkMins - DueMin"

            'OT Time based On fixed In
            'Change Work Mins Based On New In Time
            sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,InTime DateTime)"
            sqlQRY = sqlQRY & " INSERT INTO #T select tblEmployee.RegID,TData.AtDate,N_InTime=CASE WHEN DateDiff(Minute,InTime,OTStartTime)>0 THEN TData.OTStartTime Else InTime END from tdata,tblEmployee WHERE TData.EmpID = tblEmployee.RegID AND tblEmployee.IsEmpBOT = 1 AND TData.IsOTStart = 1 AND DateDiff(Minute,InTime,OTStartTime) >0"
            sqlQRY = sqlQRY & " UPDATE TData SET TData.InTIme = #T.InTime FROM #T,TData WHERE #T.EmpID = TData.EmpID AND #T.AtDate = TData.AtDate"
            FK_EQ(sqlQRY, "S", "", False, False, True)
            'Re calculate Work Mins for edited In Time where Only calculate Begin OT
            sqlQRY = "UPDATE TData SET WorkMins = CASE WHEN WorkMins = 0 THEN 0 ELSE DateDiff(Minute,InTime,OutTime) END FROM TData where IsOTStart = 1" : FK_EQ(sqlQRY, "S", "", False, False, True)

            'Normal OT Calculation
            sqlQRY = "          UPDATE TData SET NOTMin = CASE WHEN IsNormalOT = 0 THEN 0 ELSE CASE WHEN NOTMode = 1 THEN CASE WHEN WorkMins - NOTMins <0 THEN 0 ELSE workmins - NOTMins END ELSE CASE WHEN DateDiff(Minute,NOTTime,InTime)>0 THEN DateDiff(Minute,InTime,OutTime) ELSE CASE WHEN DateDiff(Minute,NOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,NOTTime,OutTime) END END END END "
            'Double OT Calculation
            sqlQRY = sqlQRY & " UPDATE TData SET DOTMin = CASE WHEN IsDoubleOT = 0 THEN 0 ELSE CASE WHEN DOTMode = 1 THEN CASE WHEN WorkMins - DOTMins <0 THEN 0 ELSE workmins - DOTMins END ELSE CASE WHEN DateDiff(Minute,DOTTime,InTime)>0 THEN DateDiff(Minute,InTime,OutTime) ELSE CASE WHEN DateDiff(Minute,DOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,DOTTime,OutTime) END END END END"
            'Triple OT Calculation
            sqlQRY = sqlQRY & "    UPDATE TData SET TOTMin = CASE WHEN   IsTOT = 0 THEN 0 ELSE CASE WHEN TOTMode = 1 THEN CASE WHEN WorkMins - TOTMins <0 THEN 0 ELSE workmins - TOTMins END ELSE CASE WHEN DateDiff(Minute,TOTTime,InTime)>0 THEN DateDiff(Minute,InTime,OutTime) ELSE CASE WHEN DateDiff(Minute,TOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,TOTTime,OutTime) END END END END"
            sqlQRY = sqlQRY & " UPDATE TData SET UpMin = CASE WHEN IsUpOT = 0 THEN 0 ELSE CASE WHEN UpOTMode = 1 THEN CASE WHEN WorkMins - UpOTMins <0 THEN 0 ELSE workmins - UpOTMins END ELSE CASE WHEN DateDiff(Minute,UpOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,UpOTTime,OutTime) END END END "
            FK_EQ(sqlQRY, "S", "", False, False, True)
            'Balance Calculated Normal OT,Double OT,Triple OT for the Extract Values
            sqlQRY = "UPDATE TData SET NOTMin = CASE WHEN isDoubleOT = 1 THEN CASE WHEN NOTMin-DOTMin <0 THEN 0 ELSE NOTMin-DOTMin END ELSE NOTMin END, DOTMin = CASE WHEN isTOT = 1 THEN CASE WHEN DOTMin-TOTMin <0 THEN 0 ELSE DOTMin-TOTMin END ELSE DOTMin END " : FK_EQ(sqlQRY, "S", "", False, False, True)
            'Update Master Table Summary Details 
            sqlQRY = "UPDATE TData SET NOTMin = CASE WHEN isUpOT = 1 THEN NOTMin - UpMin Else NOTMin END" : FK_EQ(sqlQRY, "S", "", False, False, True)
            Dim intUpNOT As Integer = fk_sqlDbl("SELECT TrTOT FROM tblControl")
            If intUpNOT = 1 Then
                sqlQRY = "UPDATE TData SET NOTMin = NOTMin + TOTMin" : FK_EQ(sqlQRY, "S", "", False, False, True)
            End If
            sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.AdOTMin = Tdata.UpMin,tblEmpRegister.NRWorkDay = TData.NrDays,tblEmpRegister.AutoLeaveNo = TData.LvDays,tblEmpRegister.AdWorkDay = TData.AddDay,tblEmpregister.NormalOT = TData.NOTMin,tblEmpRegister.DoubleOT = Tdata.DOTMin,tblEmpRegister.TripleOT = TData.TOTMin FROM TData,tblEmpRegister WHERE TData.EmpID = tblEmpRegister.EmpID AND TData.AtDate  = tblEmpRegister.AtDate" : FK_EQ(sqlQRY, "S", "", False, False, True)

            'Calculate Begin OT
            sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,InTime DateTime,OutTime DateTime,sInTime DateTime,sOutTime DateTime,InUpdate Numeric (18,0),OutUpdate Numeric (18,0),CalBeginOT Numeric (18,0),MaxBeginOT Numeric (18,0),ShiftID Nvarchar(3))"
            sqlQRY = sqlQRY & " SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.InTime1,tblEmpRegister.OutTime1,tblEmpRegister.AtDate+tblSetShiftH.InTime," &
            " CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate +tblSetShiftH.OutTime ELSE DateDiff(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.OutTime END, " &
            " tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate,tblDayProfileD.CalBeginOT,tblDayProfileD.MaxBeginOT,tblEmpRegister.ShiftID FROM tblEmpRegister,tblDayProfileD,tblSetShiftH " &
            " WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpREgister.DayTypeID = tblDayProfileD.DayID AND tblEmpRegister.ShiftID = tblDayProfileD.ShiftID AND tblEmpRegister.WorkMins Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
            ' FK_EQ(sqlQRY, "S", "", False, False, True)

            'Lunch CalculationUPDATE TData SET NOTMin = CASE WHEN IsNormalOT = 0 THEN 0 ELSE CASE WHEN NOTMode = 1 THEN CASE WHEN WorkMins - NOTMins <0 THEN 0 ELSE workmins - NOTMins END ELSE CASE WHEN DateDiff(Minute,NOTTime,InTime)>0 THEN DateDiff(Minute,InTime,OutTime) ELSE CASE WHEN DateDiff(Minute,NOTTime,InTime)<0 THEN DateDiff(Minute,InTime,OutTime) ELSE CASE WHEN DateDiff(Minute,NOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,NOTTime,OutTime) END END END 

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub OT_TemporyOT(ByVal dtStart As Date, ByVal dtEnd As Date, ByVal StrEmpID As String)
        'Modification Done for the Aitken Spence with centralized OT mechanism
        Dim dblMinOT As Double = 0 : Dim dblOTRound As Double = 0

        Dim sqlQRY As String = ""
        sqlQRY = "select  MinHrsOT,OTRndOption,OTRound  From tblCompany where compID = '" & StrCompID & "'"
        fk_Return_MultyString(sqlQRY, 3)
        dblMinOT = fk_ReadGRID(0) : dblOTRound = fk_ReadGRID(2)
        Try
            sqlQRY = "DROP TABLE RData " : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = "select tblEmpregister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.AtDate+(Convert(nvarchar(10),tblEmpRegister.InTime1,114)) As InTime,tblEmpRegister.OutDate+(Convert(Nvarchar(10),tblEmpRegister.OutTime1,114)) As OutTime,tblEmpRegister.WorkMins,tblEmpRegister.ShiftID,tblEmpRegister.DayTypeID,tblDayProfileD.PrfID, " &
                " tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblDayProfileD.NrDays,tblDayProfileD.LvDays,tblDayProfileD.IsNormalOT,tblDayProfileD.NOTMode,DateAdd(Day,NOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.NOTTime As NOTTime,tblDayProfileD.NOTMins,tblDayProfileD.IsDoubleOT, " &
                " tblDayProfileD.DOTMode,DateAdd(Day,DOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.DOTTime As DOTTime,tblDayProfileD.DOTMins,tblDayProfileD.Status,tblDayProfileD.AddDay,tblDayProfileD.isTOT, " &
                " tblDayProfileD.TOTMode,DateAdd(Day,TOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.TOTTime As TOTTime,tblDayProfileD.TOTMins, " &
                " tblDayProfileD.IsUpOT,tblDayProfileD.UpOTMode,tblEmpRegister.AtDate+tblDayProfileD.UpOTTime As UpOTTime,tblDayProfileD.WEFUpOT,tblDayProfileD.UpOTMins,tblDayProfileD.IsOTStart,tblEmpRegister.AtDate+tblDayProfileD.OTStartTime As OTStartTime " &
                " INTO RData from tblDayProfileD,tblEmpRegister WHERE tblEmpRegister.ShiftID = tblDayProfileD.ShiftID AND " &
                " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND tblEmpRegister.WOrkMins Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin AND tblEmpRegister.AntStatus = 1 AND tblEmpRegister.AtDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID = '" & StrEmpID & "'"
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD NOTMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD DOTMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD TOTMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD NOTHrs Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD DOTHrs Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD TOTHrs Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD UpMin Numeric (18,2) NOT NULL Default 0 "
            sqlQRY = sqlQRY & " ALTER TABLE RData ADD DueMin Numeric (18,2) NOT NULL Default 0 " : FK_EQ(sqlQRY, "S", "", False, False, True)

            'Reset Work Minus
            sqlQRY = "UPDATE RData SET DueMin = CASE WHEN DateDiff(Minute,InTime,OTStartTime) < 0 THEN 0 WHEN IsOTStart = 0 THEN 0 WHEN WorkMins = 0 THEN 0  ELSE DateDiff(Minute,InTime,OTStartTime) END "
            sqlQRY = sqlQRY & " UPDATE RData SET WorkMins = WorkMins - DueMin"

            'Normal OT Calculation
            sqlQRY = "UPDATE RData SET NOTMin = CASE WHEN IsNormalOT = 0 THEN 0 ELSE CASE WHEN NOTMode = 1 THEN CASE WHEN WorkMins - NOTMins <0 THEN 0 ELSE workmins - NOTMins END ELSE CASE WHEN DateDiff(Minute,NOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,NOTTime,OutTime) END END END "
            'Double OT Calculation
            sqlQRY = sqlQRY & " UPDATE RData SET DOTMin = CASE WHEN IsDoubleOT = 0 THEN 0 ELSE CASE WHEN DOTMode = 1 THEN CASE WHEN WorkMins - DOTMins <0 THEN 0 ELSE workmins - DOTMins END ELSE CASE WHEN DateDiff(Minute,DOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,DOTTime,OutTime) END END END "
            'Triple OT Calculation
            sqlQRY = sqlQRY & " UPDATE RData SET TOTMin = CASE WHEN IsTOT = 0 THEN 0 ELSE CASE WHEN TOTMode = 1 THEN CASE WHEN WorkMins - TOTMins <0 THEN 0 ELSE workmins - TOTMins END ELSE CASE WHEN DateDiff(Minute,TOTTime,OutTime)<0 THEN 0 ELSE DateDiff(Minute,TOTTime,OutTime) END END END "
            FK_EQ(sqlQRY, "S", "", False, False, True)
            'Balance Calculated Normal OT,Double OT,Triple OT for the Extract Values
            sqlQRY = "UPDATE RData SET NOTMin = CASE WHEN isDoubleOT = 1 THEN CASE WHEN NOTMin-DOTMin <0 THEN 0 ELSE NOTMin-DOTMin END ELSE NOTMin END, DOTMin = CASE WHEN isTOT = 1 THEN CASE WHEN DOTMin-TOTMin <0 THEN 0 ELSE DOTMin-TOTMin END ELSE DOTMin END " : FK_EQ(sqlQRY, "S", "", False, False, True)
            'Update Master Table Summary Details 


            sqlQRY = "update RData SET NOTHrs = CASE WHEN NOTMin < " & dblMinOT & " THEN 0 ELSE CASE WHEN NOTMin Is Null THEN 0 ELSE  Round(floor(NOTMin/" & dblOTRound & ")/60*" & dblOTRound & ",2) END END WHERE atDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
            sqlQRY = sqlQRY & " Update RData SET DOTHrs = CASE WHEN DOTMin is Null THEN 0 ELSE Round(floor(DOTMin/" & dblOTRound & ")/60*" & dblOTRound & ",2) END WHERE atDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'"
            sqlQRY = sqlQRY & " Update RData SET TOTHrs = CASE WHEN TOTMin is Null THEN 0 ELSE Round(floor(TOTMin/" & dblOTRound & ")/60*" & dblOTRound & ",2) END WHERE atDate Between '" & Format(dtStart, strRetDateTimeFormat) & "' AND '" & Format(dtEnd, strRetDateTimeFormat) & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Process_Attendance(ByVal dtpStartDate As Date, ByVal dtpEndDate As Date, ByVal StrEmp As String, ByVal Mode_A_For_AllEmployee_O_For_Selected As String, ByVal pgb As ProgressBar)
        'Fix Table Structure 

        Dim sqlQRY As String
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            sqlQRY = "UPDATE tblGetInOut SET tblGetInOut.sInTime = tblGetInOut.AtDate+tblSetShiftH.InTime, " &
       " tblGetInOut.sOutTime = CASE WHEN tblDayType.WorkUnit = .5 THEN tblGetInOut.AtDate+tblSetShiftH.StartCOUT ELSE  CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblGetInOut.AtDate+tblSetShiftH.OutTime ELSE DateAdd(day,1,tblGetInOut.AtDate)+tblSetShiftH.OutTime END END, " &
       " tblGetInOut.ClockIn = tblGetInOut.AtDate+tblSetShiftH.StartCIN, tblGetInOut.ClockOut = CASE WHEN tblGetInOut.OTApved = 0 THEN CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblGetInOut.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblGetInOut.AtDate)+tblSetShiftH.EndCOUT END ELSE tblGetInOut.ClockOut END " &
       " FROM tblSetShiftH INNER JOIN tblGetInOut ON tblSetShiftH.ShiftID = tblGetInOut.ShiftID INNER JOIN tblDayType ON tblDayType.TypeID = tblGetInOut.DayTypeID WHERE tblGetInOut.AtDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEndDate, strRetDateTimeFormat) & "'"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        End If

        'New Modification : Remove Un Assign Employees from finger machines
        intCheckMachine = fk_sqlDbl("SELECT SelectMachine FROM tblControl")
        If intCheckMachine = 1 Then
            Remove_UnAssign_Machines(dtpStartDate, dtpEndDate, "")
        End If
        Dim intSelected As Integer = 0
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then intSelected = 0 Else intSelected = 1

        'Set MaxClockIn,ClockOut
        sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AtDate DateTime,ClockIn DateTime, ClockOut DateTime)"
        sqlQRY = sqlQRY & " INSERT INTO #Tmp select EmpID,AtDate,Min(ClockIn),Max(ClockOut) from tblGetInOut WHERE atDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEndDate, strRetDateTimeFormat) & "' GROUP by EMpID,AtDate "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = #Tmp.ClockIn,tblEmpRegister.ClockOut = CASE WHEN DateDiff(minute,tblEmpRegister.OutTime1,#Tmp.ClockOut)<0 THEN DateAdd(Second,1,tblEmpRegister.OutTime1) ELSE #Tmp.ClockOut END FROM #Tmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = #Tmp.EmpID AND tblEmpRegister.AtDate = #Tmp.AtDate"
        'FK_EQ(sqlQRY, "S", "", False, False, True)
        Gen_StraitShift(dtpStartDate, dtpEndDate, "", StrEmp, intSelected)
        Dim dblLateMins As Double
        Dim dblOTRound As Double
        Dim dblMinOT As Double
        Dim intOTRndOption As Double

        'Open Company Informatiion 
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        sqlQRY = "SELECT * FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlQRY, cnOpn)
            Dim drOPn As SqlDataReader = cmOpn.ExecuteReader
            If drOPn.Read = True Then
                dblLateMins = IIf(IsDBNull(drOPn.Item("Latemin")), 0, drOPn.Item("Latemin"))
                dblOTRound = IIf(IsDBNull(drOPn.Item("OTRound")), 0, drOPn.Item("OTRound"))
                dblMinOT = IIf(IsDBNull(drOPn.Item("MinHrsOT")), 0, drOPn.Item("MinHrsOT"))
                intOTRndOption = IIf(IsDBNull(drOPn.Item("OTRndOption")), 0, drOPn.Item("OTRndOption"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try
        Dim dgvEmpShift As New DataGridView
        With dgvEmpShift
            .Columns.Add("Row", "Row")
            .Columns.Add("ShiftID", "Shift ID")
            .Columns.Add("AtDate", "Attendance Date")
            .Columns.Add("ClockIn", "Clock In")
            .Columns.Add("ClockOut", "Clock Out")
            .Columns.Add("Total", "Total")
        End With

        Dim dtStartDate As Date : dtStartDate = dtpStartDate
        Dim dtEndDate As Date : dtEndDate = dtpEndDate

        'Generate the Selected Period Each day Shift And Attendance Time
        Dim sqlQRY1 As String
        sqlQRY1 = "if exists(select * from sys.objects where name = 'processShift') drop table processShift"
        FK_EQ(sqlQRY1, "S", "", False, False, False)
        sqlQRY1 = "UPDATE tblDiMachine SET tTime = cDate+cTime WHERE cDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEndDate, strRetDateTimeFormat) & "'"
        FK_EQ(sqlQRY1, "S", "", False, False, False)

        Select Case Mode_A_For_AllEmployee_O_For_Selected
            Case "A"

                sqlQRY1 = "select ROW_NUMBER() OVER(ORDER BY tblGetINOUT.AtDate,tblGetINOUT.ShiftID DESC) AS Row,tblGetINOUT.ShiftID,tblGetINOUT.AtDate,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,Count(tblGetINOUT.ShiftID) As Total INTO processShift FROM tblGetINOUT INNER JOIN tblEmployee ON tblGetINOUT.EmpID = tblEmployee.RegID " &
                " WHERE tblGetINOUT.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmployee.EmpStatus <> 9 GROUP by tblGetINOUT.ShiftID,tblGetINOUT.AtDate,tblGetINOUT.ClockIn,tblGetINOUT.Clockout  " &
                " Order By tblGetINOUT.AtDate,tblGetINOUT.ShiftID DESC"
                FK_EQ(sqlQRY1, "S", "", False, False, False)
                'Load Above to the Shift GRID
                Load_InformationtoGrid("SELECT Row,ShiftID,AtDate,ClockIn,ClockOut,Total FROM processShift Order By Row", dgvEmpShift, 6)
                sqlQRY1 = "delete from TestRun"
                FK_EQ(sqlQRY1, "S", "", False, False, False)
                sqlQRY1 = ""
                Dim bolError As Boolean = False
                Dim intRow As Integer = 0
                With dgvEmpShift
                    If .RowCount <= 1 Then Exit Sub
                    pgb.Minimum = 0
                    pgb.Maximum = .RowCount - 2
                    pgb.Value = 0

                    For i As Integer = 0 To .RowCount - 2
                        Dim iTot As Integer = .Item(5, i).Value
                        intRow = CInt(.Item(0, i).Value)
                        If .Item(1, i).Value <> "" Then
                            '    sqlQRY1 = " insert into TestRun select tblGetINOUT.EmpID,tblGetINOUT.AtDate,tblGetINOUT.ShiftID,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,tblGetINOUT.SInTime," & _
                            '" tblGetINOUT.sOutTime,tblEmployee.EnrolNo,dbo.fk_ReturnINOUT(tblEmployee.EnrolNo,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,'I') As InTime," & _
                            '" dbo.fk_ReturnINOUT(tblEmployee.EnrolNo,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,'O') As OutTime,0 As AntStatus, 0 As InUpdate, 0 As OutUpdate,'N' As Match FROM tblEmployee " & _
                            '" INNER JOIN tblGetINOUT ON tblEmployee.RegID = tblGetINOUT.EmpID " & _
                            '" INNER JOIN processShift ON tblGetINOUT.ShiftID = processShift.ShiftID AND tblGetINOUT.ClockIn = processShift.ClockIn AND tblGetINOUT.ClockOut = processShift.ClockOut " & _
                            '" where processshift.Row = " & intRow & " AND tblEmployee.EMpStatus <> 9"

                            '###### HRISforBB #####################
                            'Description    : Change Process without using InOut Taking Function 
                            sqlQRY1 = "insert into TestRun " &
                             " select tblGetINOUT.EmpID,tblGetINOUT.AtDate,tblGetINOUT.ShiftID,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,tblGetINOUT.SInTime, tblGetINOUT.sOutTime,tblEmployee.EnrolNo,'' As InTime,  '' As OutTime, " &
                             " 0 As AntStatus, 0 As InUpdate, 0 As OutUpdate,'N' As Match FROM tblEmployee   INNER JOIN tblGetINOUT ON tblEmployee.RegID = tblGetINOUT.EmpID  " &
                             " INNER JOIN processShift ON tblGetINOUT.ShiftID = processShift.ShiftID  AND tblGetINOUT.ClockIn = processShift.ClockIn AND tblGetINOUT.ClockOut = processShift.ClockOut  " &
                             " where processshift.Row = " & intRow & " AND tblEmployee.EMpStatus <> 1 Order By tblGetInOut.EmpID"
                            sqlQRY1 = sqlQRY1 & "  select tblDiMachine.EmpID,tblDiMachine.cDate,TestRun.ClockIn,TestRun.ClockOut,InTime  = Min(tblDiMachine.tTime),OutTime = Max(tblDiMachine.tTime),inUpdate = 0,OutUpdate = 0 Into #T_Time From TestRun,tblDiMachine " &
                                                " WHERE TestRun.EnrolNo = tblDiMachine.EmpID AND tblDiMachine.cDate = TestRun.AtDate GROUP BY tblDiMachine.EmpID ,tblDiMachine.cDate,TestRun.ClockIn,TestRun.ClockOut "
                            sqlQRY1 = sqlQRY1 & " UPDATE #T_Time Set InUpdate = 1 WHERE InTIme Between ClockIn AND ClockOut "
                            sqlQRY1 = sqlQRY1 & " UPDATE #T_Time SET OutUpdate = 1 WHERE OutTime Between DateAdd(Minute,1,InTime) AND ClockOut"
                            sqlQRY1 = sqlQRY1 & " UPDATE TestRun SET TestRun.InTime  =#T_Time.InTime,TestRun.OutTime = #T_Time.OutTime , TestRun.InUpdate = #T_Time.InUPdate,TestRun.OutUpdate = #T_Time.OutUpdate FROM #T_Time,TestRun WHERE #T_Time.EmpID = TestRun.EnrolNo AND #T_Time.cDate = TestRun.AtDate"

                        End If
                        bolError = FK_EQ(sqlQRY1, "S", "", False, False, True)
                        If bolError = False Then Exit Sub
                        pgb.Value = i
                    Next
                End With

            Case "O"

                'Update Clock In Clock Out from the Shift Header tables 
                sqlQRY1 = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,cIn DateTime,cOut DateTime)"
                sqlQRY1 = sqlQRY1 & " Insert into #T Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpREgister.AtDate+tblSetShiftH.StartCIN,CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpREgister.AtDate)+tblSetShiftH.EndCOUT END From tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID In ('" & StrEmp & "')"
                sqlQRY1 = sqlQRY1 & " UPDATE tblEmpRegister SET tblEmpREgister.ClockIn = #T.cIn ,tblEmpRegister.ClockOut = #T.cOut FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate"
                'New Query for KDU 20160325
                sqlQRY1 = sqlQRY1 & "UPDATE tblEmpRegister SET antStatus=0,inUpdate=0,outUpdate=0,isNightWork=1,workMins=0 WHERE tblEmpRegister.AtDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID In ('" & StrEmp & "')"
        End Select
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            'Modification Dashboard : Kasun 20160918
            Dim intTriD As Integer = fk_sqlDbl("SELECT procTrID+1 FROM tblControl")
            Dim intNewProcesedCount As Integer = fk_sqlDbl("SELECT count(*) FROM tblDiMachine WHERE cDate BETWEEN '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND dStatus=0")
            sSQL = "INSERT INTO tblProcessHistory (pAID,crUser,crTime,pDesc,pCount,pStatus) VALUES (" & intTriD & ",'" & StrUserID & "',getDate(),'Processed data in old manual night fix mode'," & intNewProcesedCount & ",0); UPDATE tblControl SET procTrID=" & intTriD & " WHERE GrpID='001';  UPDATE tblCompany SET AtnPrcDate = '" & Format(dtpEndDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'; UPDATE tblDiMachine SET dStatus=1 WHERE cDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND dStatus=0; UPDATE [tblDeviceInfo] SET [lastProcessed]='1900-01-01 00:00:00.000'" : FK_EQ(sSQL, "P", "", False, False, True)
        End If
        'NEW ON 10/16/2014 - Update tblDeviceInfo table for the Machine Maximum date 
        sqlQRY1 = "CREATE TABLE #T (MacID Nvarchar (3),lDate DateTime)"
        sqlQRY1 = sqlQRY1 & " INSERT INTO #T SELECT MacID,Max(ttime) FROM tblDiMachine WHERE EditMode = 0 Group By MacID"
        sqlQRY1 = sqlQRY1 & " UPDATE tblDeviceInfo SET tblDeviceInfo.LProcessDate = #T.lDate FROM #T,tblDeviceInfo WHERE #T.MacID = tblDeviceInfo.machinID"
        FK_EQ(sqlQRY1, "S", "", False, False, True)

        'Get OpenShift Seperatly
        Dim dgvAllDate As New DataGridView
        Dim iDayCount As Integer = DateDiff(DateInterval.Day, dtStartDate, dtEndDate)
        Dim dtDateM As Date = dtStartDate
        pgb.Minimum = 0 : pgb.Value = 0 : pgb.Maximum = iDayCount + 1
        For i As Integer = 0 To iDayCount
            If i > 0 Then dtDateM = DateAdd(DateInterval.Day, 1, dtDateM)
            pgb.Value = i + 1
            fk_Process_SplitShift(dtDateM, dtDateM, StrEmp, Mode_A_For_AllEmployee_O_For_Selected)
        Next

        '10/11/2014 - Split Shift Generation 
        proc_ShiftLineOnSplit(dtStartDate, dtEndDate)

        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            process_AttendanceParameters(dtStartDate, dtEndDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        ElseIf Mode_A_For_AllEmployee_O_For_Selected = "O" And IsRunAutoCalculation = 1 Then
            process_AttendanceParameters(dtStartDate, dtEndDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        Else
            MsgBox("Process Completed", MsgBoxStyle.Information)
        End If
        'fk_Process_SplitShift(dtStartDate, dtEndDate, StrEmp,Mode_A_For_AllEmployee_O_For_Selected)
        'process_AttendanceParameters(dtStartDate, dtEndDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)

    End Sub

    '########################## STRAIGHT ATTENDANCE IN/OUT GENERATION #############################
    'Ref Number     : #ISA-099
    'Start Date     : 25/5/ 2018
    'End Date       : 
    'Author         : Kasun Jayawardana
    'Module Desc    : Generate In/Out as Fist Time between clock in and clock out as In / Last As Out, this will abandon other all in out time bettween min & Max
    '                 Update Next Date Clock IN as Today Last Out time + 1 Min

    Public Function fk_ProcessStraght(ByVal dtStart As Date, ByVal dtEnd As Date, ByVal prcBar As ProgressBar, ByVal Mode_A_For_AllEmployee_O_For_Selected As String, ByVal StrEmps As String) As Boolean
        Dim sqlQRY As String = ""
        Dim intTotalDays As Integer
        Dim dblLateMins As Double
        Dim dblOTRound As Double
        Dim dblMinOT As Double
        Dim intOTRndOption As Double

        'Open Company Informatiion 
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        sqlQRY = "SELECT * FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlQRY, cnOpn)
            Dim drOPn As SqlDataReader = cmOpn.ExecuteReader
            If drOPn.Read = True Then
                dblLateMins = IIf(IsDBNull(drOPn.Item("Latemin")), 0, drOPn.Item("Latemin"))
                dblOTRound = IIf(IsDBNull(drOPn.Item("OTRound")), 0, drOPn.Item("OTRound"))
                dblMinOT = IIf(IsDBNull(drOPn.Item("MinHrsOT")), 0, drOPn.Item("MinHrsOT"))
                intOTRndOption = IIf(IsDBNull(drOPn.Item("OTRndOption")), 0, drOPn.Item("OTRndOption"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try
        Dim dtRunDate As Date
        dtRunDate = dtStart
        intTotalDays = DateDiff(DateInterval.Day, dtStart, dtEnd) + 2
        prcBar.Minimum = 0
        prcBar.Maximum = intTotalDays
        Dim iDayVal As Integer = 0
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),EnrolNo Numeric (18,0),AtDate DateTime , InTime DateTime ,OutTime DateTime ,OutDate DateTime ,ClockIn DateTime,ClockOut DateTime, nClockOut DateTime, NextDate DateTime, NextClockIn DateTime,InUpdate Numeric (18,0),OutUpdate Numeric (18,0),AntStatus Numeric (18,0))"
        sqlQRY = sqlQRY & " CREATE TABLE #IN (EmpID Nvarchar (6),EnrolNo Numeric (18,0),ClockIn DateTime, ClockOut DateTime, InTime DateTime)"
        sqlQRY = sqlQRY & " CREATE TABLE #OUT (EmpID Nvarchar (6),EnrolNo Numeric (18,0),ClockIn DateTime, ClockOut DateTime ,OutTime DateTime)"

        While dtRunDate <= dtEnd

            iDayVal = iDayVal + 1
            sqlQRY = sqlQRY & " DELETE FROM #T"
            sqlQRY = sqlQRY & " DELETE FROM #IN"
            sqlQRY = sqlQRY & " DELETE FROM #OUT"
            If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
                sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmployee.EnrolNo ,tblEmpRegister.AtDate,'','','',tblEmpRegister.ClockIn,tblEmpRegister.ClockOut,'',DateAdd(Day,1,tblEmpRegister.AtDate),'',0,0,0 FROM tblEmpRegister,tblEmployee WHERE tblEmployee.RegID = tblEmpRegister.EmpID AND tblEmpRegister.AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "' AND tblEmployee.EmpStatus <> 9"
            Else
                sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmployee.EnrolNo ,tblEmpRegister.AtDate,'','','',tblEmpRegister.ClockIn,tblEmpRegister.ClockOut,'',DateAdd(Day,1,tblEmpRegister.AtDate),'',0,0,0 FROM tblEmpRegister,tblEmployee WHERE tblEmployee.RegID = tblEmpRegister.EmpID AND tblEmpRegister.AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "' AND tblEmployee.EmpStatus <> 9 AND tblEmpRegister.EmpID In ('" & StrEmps & "')"
            End If
            sqlQRY = sqlQRY & " INSERT INTO #IN SELECT #T.EmpID,#T.EnrolNo,#T.ClockIn,#T.ClockOut,Min(tblDIMachine.tTime) FROM tblDiMachine,#T WHERE tblDiMachine.EmpID = #T.EnrolNo AND tblDiMachine.tTime Between #T.ClockIn AND #T.ClockOut AND tblDIMachine.Capture = 0 GROUP BY #T.EmpID,#T.EnrolNo,#T.ClockIn,#T.ClockOut "

            sqlQRY = sqlQRY & " UPDATE #IN SET ClockIN = DateAdd (Minute,10,InTime) "

            sqlQRY = sqlQRY & " UPDATE #T SET #T.InTime = #IN.InTime,#T.InUpdate = 1,#T.ClockIn = #IN.ClockIn,#T.AntStatus = 1 FROM #In,#T WHERE #T.EmpID = #IN.EmpID  "

            sqlQRY = sqlQRY & " INSERT INTO #OUT SELECT #T.EmpID,#T.EnrolNo ,#T.ClockIn,#T.ClockOut,Max(tblDimachine.tTime) FROM tblDiMachine,#T WHERE tblDiMachine.EmpID = #T.EnrolNo AND tblDimachine.tTime Between #T.ClockIn AND #T.ClockOut AND tblDIMachine.Capture = 0 GROUP BY #T.EmpID,#T.EnrolNo,#T.ClockIn,#T.ClockOut "

            sqlQRY = sqlQRY & " UPDATE #OUT SET ClockOut = DateAdd(Minute,10,OutTime) "

            sqlQRY = sqlQRY & " UPDATE #T SET #T.OutTime = #OUT.OutTime,#T.nClockOut = DateAdd(Minute,1,#OUT.ClockOut) ,#T.OutUpdate = 1 FROM #OUT,#T WHERE #T.EmpID = #OUT.EmpID "

            If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
                sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.InTime1 = #T.InTime,tblEmpRegister.OutTime1 = #T.OutTime,tblEmpRegister.InUpdate = #T.InUpdate ,tblEmpRegister.OutUpdate = #T.OutUpdate ,tblEmpRegister.AntStatus = #T.AntStatus FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate "
                'sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = #T.nClockOut FROM #T,tblEmpRegister WHERE #T.NextDate = tblEmpRegister.AtDate AND #T.AntStatus = 1 "
                sqlQRY = sqlQRY & " DELETE FROM tblGetInOut WHERE AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "' "
                sqlQRY = sqlQRY & " insert Into tblGetInOut (EmpID,AtDate,InDate,InTime,OutDate,OutTime,ShiftID,DayTypeID,sInTime,sOutTime,AntStatus,WorkMin,IsLate,LateMin,IsEarly,EarlyMin,ShiftLine,InUpdate,OutUpdate,mInUpdate,mOutUpdate,BOTMin,EOTMin,AtEdit,ClockIn,ClockOut,OTApved,OTMin)  select EmpID,AtDate,InDate,InTime1,OutDate,OutTime1,ShiftID,DayTypeID,sInTime,sOutTime,AntStatus,WorkMins,IsLate,LateMins,IsEarly,EarlyMins,1,InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,AtEdit,ClockIn,ClockOut,OTApved,cOTMins FROM tblEmpRegister WHERE AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "' "
            Else
                sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.InTime1 = #T.InTime,tblEmpRegister.OutTime1 = #T.OutTime,tblEmpRegister.InUpdate = #T.InUpdate ,tblEmpRegister.OutUpdate = #T.OutUpdate ,tblEmpRegister.AntStatus = #T.AntStatus FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.EmpID IN ('" & StrEmps & "')"
                'sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = #T.nClockOut FROM #T,tblEmpRegister WHERE #T.NextDate = tblEmpRegister.AtDate AND #T.AntStatus = 1 AND tblEmpRegister.EmpID In ('" & StrEmps & "')"
                sqlQRY = sqlQRY & " DELETE FROM tblGetInOut WHERE AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "' AND EmpID In ('" & StrEmps & "')"
                sqlQRY = sqlQRY & " insert Into tblGetInOut (EmpID,AtDate,InDate,InTime,OutDate,OutTime,ShiftID,DayTypeID,sInTime,sOutTime,AntStatus,WorkMin,IsLate,LateMin,IsEarly,EarlyMin,ShiftLine,InUpdate,OutUpdate,mInUpdate,mOutUpdate,BOTMin,EOTMin,AtEdit,ClockIn,ClockOut,OTApved,OTMin)  select EmpID,AtDate,InDate,InTime1,OutDate,OutTime1,ShiftID,DayTypeID,sInTime,sOutTime,AntStatus,WorkMins,IsLate,LateMins,IsEarly,EarlyMins,1,InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,AtEdit,ClockIn,ClockOut,OTApved,cOTMins FROM tblEmpRegister WHERE AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "' AND EmpID IN ('" & StrEmps & "')"
            End If

            prcBar.Value = iDayVal
            dtRunDate = dtRunDate.AddDays(1)

        End While
        FK_EQ(sqlQRY, "S", "", False, False, True)
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            process_AttendanceParameters(dtStart, dtEnd, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        ElseIf Mode_A_For_AllEmployee_O_For_Selected = "O" And IsRunAutoCalculation = 1 Then
            process_AttendanceParameters(dtStart, dtEnd, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        Else
            MsgBox("Process Completed", MsgBoxStyle.Information)
        End If
    End Function

    '########################## ATTENDANCE INFORMATION PROCESS ON CLOCK IN & CLOCK OUT #####################
    'Start Date     : 24/1/2016
    'End Date       : 24/1/2016
    'Author         : Kasun Jayawardana
    'Module Desc    : Generate In/Out based on clock in and clock out in tblempregister table

    Public Function fk_ProcessAttendanceNEW(ByVal sqlQRY As String, ByVal dtpStDate As Date, ByVal dtpEdDate As Date, ByVal prcBar As ProgressBar, ByVal intPrcFinally As Integer, ByVal endDay As Integer) As Boolean
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("EmpID", "Register ID")
            .Columns.Add("AtDate", "worked Date")
            .Columns.Add("EnrolNo", "Enrol Number")
        End With
        Load_InformationtoGrid(sqlQRY, dgv, 3)
        Dim bolSave As Boolean = False
        Try
            Dim intDayCount As Integer = 0
            intDayCount = DateDiff(DateInterval.Day, dtpStDate, dtpEdDate)
            Dim dtpVal As Date
            For i As Integer = 0 To intDayCount
                If i = 0 Then
                    dtpVal = dtpStDate
                Else
                    dtpVal = DateAdd(DateInterval.Day, 1, dtpVal)
                End If
                'Load Details
                Dim StrEmp As String
                prcBar.Minimum = 0
                prcBar.Maximum = dgv.RowCount - 1
                prcBar.Value = 0
                Dim sqlQ As String = ""
                For r As Integer = 0 To dgv.RowCount - 2
                    StrEmp = dgv.Item(0, r).Value
                    sqlQ = "exec sp_GetInOutValues '" & Format(dtpVal, strRetDateTimeFormat) & "','" & StrEmp & "'"
                    FK_EQ(sqlQ, "S", "", False, False, True)
                    prcBar.Value = r
                Next

            Next

            sSQL = "UPDATE tblEmpRegister SET InDate=  convert(varchar (8), InTime1, 112),OutDate=convert(varchar(8),outtime1,112) WHERE atDate BETWEEN '" & Format(dtpStDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEdDate, strRetDateTimeFormat) & "'" : FK_EQ(sSQL, "S", "", False, False, True)

            'Finally Calculate the Attendance Summary for the selected date range 

            Dim dblLateMins As Double : Dim dblOTRound As Double : Dim dblMinOT As Double : Dim intOTRndOption As Double
            If intPrcFinally = 1 Then
                sqlQRY = "SELECT Latemin,OTRound,MinHrsOT,OTRndOption FROM tblCompany WHERE CompID = '" & StrCompID & "'"
                fk_Return_MultyString(sqlQRY, 4)
                dblLateMins = CDbl(fk_ReadGRID(0)) : dblOTRound = CDbl(fk_ReadGRID(1)) : dblMinOT = CDbl(fk_ReadGRID(2)) : intOTRndOption = CDbl(fk_ReadGRID(3))
                process_AttendanceParameters(dtpStDate, dtpEdDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
            End If

            If endDay = 1 Then
                'Modification Dashboard : Kasun 20160918
                Dim intTriD As Integer = fk_sqlDbl("SELECT procTrID+1 FROM tblControl")
                Dim intNewProcesedCount As Integer = fk_sqlDbl("SELECT count(*) FROM tblDiMachine WHERE cDate BETWEEN '" & Format(dtpStDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEdDate, strRetDateTimeFormat) & "' AND dStatus=0")
                sSQL = "INSERT INTO tblProcessHistory (pAID,crUser,crTime,pDesc,pCount,pStatus) VALUES (" & intTriD & ",'" & StrUserID & "',getDate(),'Processed data in new auto night mode'," & intNewProcesedCount & ",0); UPDATE tblControl SET procTrID=" & intTriD & " WHERE GrpID='001'; UPDATE tblCompany SET atnPrcDate= '" & Format(dtpEdDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'; UPDATE tblDiMachine SET dStatus=1 WHERE cDate BETWEEN '" & Format(dtpStDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEdDate, strRetDateTimeFormat) & "' AND dStatus=0"
                FK_EQ(sSQL, "S", "", False, False, True)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    '#######################################################################################################
    '############################## END NEW PROCESS OF IN/OUT GENERATION ###################################

    Public Sub fk_Process_SplitShift(ByVal dtStartDate As Date, ByVal dtEndDate As Date, ByVal StEmpID As String, ByVal StrBR As String)
        Dim StrEmpID As String : Dim dtAtDate As Date : Dim dtCIn As Date : Dim dtCOut As Date : Dim intEnrolNo As Integer : Dim StrINOut As String = "IN"
        'Clear tblGetInOut Table 

        Dim dgvAllEmps As New DataGridView
        Try
            With dgvAllEmps
                .Columns.Add("Row", "Row")
                .Columns.Add("EmpID", "EmpID")
                .Columns.Add("EnrolNo", "EnrolNo")
                .Columns.Add("AtDate", "AtDate")
                .Columns.Add("ClockIn", "ClockIn")
                .Columns.Add("ClockOut", "ClockOut")
                .Columns.Add("Mark", "Mark")
            End With

            Dim dgvFilter As New DataGridView
            With dgvFilter
                .Columns.Add("Record", "Record")
                .Columns.Add("Employee", "Employee")
                .Columns.Add("AtDate", "AtDate")
                .Columns.Add("Time", "Time")
                .Columns.Add("InOut", "In/Out")
                .Columns.Add("Picked", "Picked")
            End With

            Dim sqlQRY As String
            Dim sqlQRY1 As String = ""
            Select Case StrBR
                Case "A"
                    sqlQRY = "select ROW_NUMBER() OVER(ORDER BY tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.AllShifts DESC) AS Row,tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.AllShifts,tblEmpRegister.AtDate,dbo.fk_PreviousCOUT(tblEmpRegister.EmpID,tblEmpRegister.AtDate),CASE WHEN tblEmpRegister.OutUpdate = 1 THEN tblEmpRegister.ClockOut ELSE CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT END END,Count(tblEmpRegister.ShiftID) As Total  FROM tblEmpRegister " &
           " INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID " &
           " INNER JOIN tblEmployee ON tblEmpRegister.EmpID = tblEmployee.RegID " &
           " WHERE  atdate between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblSetShiftH.OpenShift = 1 group by tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.AllShifts,tblEmpRegister.AtDate,tblSetShiftH.ShiftMode,tblSetShiftH.StartCIN,tblSetShiftH.EndCOUT,tblEmpRegister.OutUpdate,tblEmpRegister.ClockOut Order By tblEmpRegister.AtDate,tblEmpRegister.AllShifts DESC "
                    sqlQRY1 = "DELETE FROM tblGetInOut WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
                    sqlQRY1 = sqlQRY1 & " INSERT INTO tblGetInOut (EmpID,AtDate,AntStatus,SHiftID,ClockIn,ClockOut,WOrkMin,LateMin,IsLate,EarlyMin,Isearly,BOTMin,EOTMin,OTMin,InTime,OutTime,sInTime,sOutTime,OutDate,InUpdate,OutUpdate) select tblEmpRegister.EmpID,tblEmpRegister.AtDate,0,tblEmpRegister.AllShifts,dbo.fk_PreviousCOUT(tblEmpRegister.EmpID,tblEmpRegister.AtDate),CASE WHEN tblEmpRegister.OutUpdate = 1 THEN tblEmpRegister.ClockOut ELSE CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT END END,0,0,0,0,0,0,0,0,'','','','','',0,0  FROM tblEmpRegister  INNER JOIN tblSetShiftH ON tblEmpRegister.AllShifts = tblSetShiftH.ShiftID WHERE  atdate between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblSetShiftH.OpenShift = 1"

                Case "O"
                    '         sqlQRY = "select ROW_NUMBER() OVER(ORDER BY tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.AllShifts DESC) AS Row,tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.AllShifts,tblEmpRegister.AtDate,dbo.fk_PreviousCOUT(tblEmpRegister.EmpID,tblEmpRegister.AtDate),CASE WHEN tblEmpRegister.OutUpdate = 1 THEN tblEmpRegister.ClockOut ELSE CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT END END,Count(tblEmpRegister.ShiftID) As Total  FROM tblEmpRegister " & _
                    '" INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID " & _
                    '" INNER JOIN tblEmployee ON tblEmpRegister.EmpID = tblEmployee.RegID " & _
                    '" WHERE  atdate between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID In ('" & StEmpID & "') AND tblSetShiftH.OpenShift = 1 group by tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.AllShifts,tblEmpRegister.AtDate,tblSetShiftH.ShiftMode,tblSetShiftH.StartCIN,tblSetShiftH.EndCOUT,tblEmpRegister.OutUpdate,tblEmpRegister.ClockOut Order By tblEmpRegister.AtDate,tblEmpRegister.AllShifts DESC "

                    sqlQRY = "DELETE FROM T " : FK_EQ(sqlQRY, "S", "", False, False, False)
                    sqlQRY = "INSERt into T select ROW_NUMBER() OVER(ORDER BY tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.ShiftID DESC) AS Row,tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.ShiftID,tblEmpRegister.AtDate,'',ClockOut = CASE WHEN tblEmpRegister.OutUpdate = 1 THEN tblEmpRegister.ClockOut ELSE CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT END END,Count(tblEmpRegister.ShiftID) As Total,tblEmpRegister.OutUpdate,DateAdd(Day,-1,AtDate),tblEmpRegister.InTime1,''   FROM tblEmpRegister  INNER JOIN tblSetShiftH ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID  " &
                    " INNER JOIN tblEmployee ON tblEmpRegister.EmpID = tblEmployee.RegID  WHERE  atdate between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' " &
                    "  AND tblEmpRegister.EmpID In ('" & StEmpID & "') AND tblSetShiftH.OpenShift = 1 group by tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.ShiftID,tblEmpRegister.AtDate,tblSetShiftH.ShiftMode,tblSetShiftH.StartCIN,tblSetShiftH.EndCOUT,tblEmpRegister.OutUpdate,tblEmpRegister.ClockOut,tblEmpRegister.InTime1,tblEmpRegister.OutTime1  Order By tblEmpRegister.AtDate,tblEmpRegister.ShiftID DESC "
                    sqlQRY = sqlQRY & " UPDATE T SET T.ClockIn = T.AtDate+tblSetShiftH.StartCIN FROM tblSetShiftH,T WHERE tblSetShiftH.ShiftID = t.ShiftID"
                    sqlQRY = sqlQRY & " UPDATE T SET T.ClockIn = DateAdd(Second,1,tblEmpRegister.OutTime1) FROM tblEmpRegister,T WHERE tblEmpRegister.EmpID = t.EmpID AND tblEmpRegister.AtDate = t.OTDate AND tblEmpRegister.OutUpdate = 1"
                    FK_EQ(sqlQRY, "S", "", False, False, True)

                    sqlQRY = "SELECT RowNo,EmpID,EnrolNo,ShiftID,AtDate,ClockIn,ClockOut,Total FROM T Order By EmpID,AtDate"
                    sqlQRY1 = "UPDATE tblGetInOut SET InTime = '',OutTime = '' ,InUpdate = 0,OutUpdate = 0,AntStatus = 0 WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND EmpID In ('" & StEmpID & "')" : FK_EQ(sqlQRY1, "S", "", False, False, True)

                    'Dim words As String() = StEmpID.Split(New Char() {","c})
                    'Dim StrnEmp As String
                    'sqlQRY1 = ""
                    'Dim intCount As Integer
                    'For Each StrnEmp In words
                    '    StrnEmp = Replace(StrnEmp, "'", "")
                    '    sqlQRY1 = sqlQRY1 & "DELETE FROM tblGetInOut WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND EmpID In ('" & StrnEmp & "')"
                    '    sqlQRY1 = sqlQRY1 & " INSERT INTO tblGetInOut (EmpID,AtDate,AntStatus,SHiftID,ClockIn,ClockOut,WOrkMin,LateMin,IsLate,EarlyMin,Isearly,BOTMin,EOTMin,OTMin,InTime,OutTime,sInTime,sOutTime,OutDate,InUpdate,OutUpdate) select tblEmpRegister.EmpID,tblEmpRegister.AtDate,0,tblEmpRegister.AllShifts,dbo.fk_PreviousCOUT(tblEmpRegister.EmpID,tblEmpRegister.AtDate),CASE WHEN tblEmpRegister.OutUpdate = 1 THEN tblEmpRegister.ClockOut ELSE CASE tblSetShiftH.ShiftMode WHEN 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpRegister.AtDate)+tblSetShiftH.EndCOUT END END,0,0,0,0,0,0,0,0,'','','','','',0,0  FROM tblEmpRegister  INNER JOIN tblSetShiftH ON tblEmpRegister.AllShifts = tblSetShiftH.ShiftID WHERE  atdate between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID In ('" & StrnEmp & "') AND tblSetShiftH.OpenShift = 1"
                    '    intCount = intCount + 1
                    '    If intCount = 25 Then
                    '        'FK_EQ(sqlQRY1, "S", "", False, False, True) : intCount = 0 : sqlQRY1 = ""
                    '    End If
                    'Next

            End Select
            'If sqlQRY1 <> "" Then FK_EQ(sqlQRY1, "S", "", False, False, True)
            Load_InformationtoGrid(sqlQRY, dgvAllEmps, 8)
            Dim sqlT As String
            'Phase 2 will Run
            Dim iMode As Integer
            With dgvAllEmps
                For i As Integer = 0 To .RowCount - 2
                    StrEmpID = .Item(1, i).Value
                    intEnrolNo = CInt(.Item(2, i).Value)
                    dtAtDate = CDate(.Item(4, i).Value)
                    dtCIn = .Item(5, i).Value
                    ''Dim StrCIN As String = Format(dtCIn, strRetDateTimeFormat) + " " + Format(dtCIn, "hh:mm:ss tt")

                    dtCOut = .Item(6, i).Value
                    ''Dim StrCOUT As String = Format(dtCOut, strRetDateTimeFormat) + " " + Format(dtCOut, "hh:mm:ss tt")
                    'Load All Record From the tblDiMachine Table Related to the Shift 
                    'MORE TIME TAKEN THIS LOOP 1.15 MINS FOR ONE DAY
                    sqlT = "SELECT ROW_NUMBER() OVER(ORDER BY tblDiMachine.EmpID,tblDiMachine.tTime ASC) As Row,'" & StrEmpID & "','" & Format(dtStartDate, "yyyy-MM-dd") & "',tblDIMachine.tTime,'',0 FROM tblDiMachine WHERE EmpID = " & intEnrolNo & " AND tTime Between '" & Format(dtCIn, "yyyy-MM-dd hh:mm:ss tt") & "' AND '" & Format(dtCOut, "yyyy-MM-dd hh:mm:ss tt") & "' AND Capture = 0 Order by tTime"
                    Console.WriteLine(sqlT)
                    Load_InformationtoGridNoClr(sqlT, dgvFilter, 6)
                    With dgvFilter
                        For iM As Integer = 0 To .RowCount - 2
                            iMode = CInt(.Item(0, iM).Value) Mod 2
                            If iMode = 0 Then StrINOut = "OUT" Else StrINOut = "IN"
                            .Item(4, iM).Value = StrINOut

                        Next
                    End With
                Next
            End With

            'Phase 3 will run : data will be saved
            'Insert Into Temporary table above generated in Out Seperated Record 
            Dim sqlTable As String = "if exists (select * from sys.Objects where [name]  = 'tblTempINOUT')  Begin DROP TABLE tblTempINOUT END  CREATE TABLE tblTempINOUT (AtVal Numeric (18,0),EmpID Nvarchar (8),Atdate DateTime,AtTime DateTime, INOUT Nvarchar (3))"
            FK_EQ(sqlTable, "S", "", False, False, True)
            sqlQRY = ""
            With dgvFilter
                For i As Integer = 0 To .RowCount - 2
                    Dim Emp As String = .Item(1, i).Value
                    Dim dtDate As Date = .Item(2, i).Value
                    Dim dtTime As Date = .Item(3, i).Value
                    Dim StrIN As String = .Item(4, i).Value

                    sqlQRY = sqlQRY & " INSERT INTO tblTempINOUT (atval,EmpID,Atdate,AtTime,INOUT) VALUES (" & CInt(.Item(0, i).Value) & ",'" & .Item(1, i).Value & "','" & Format(dtDate, strRetDateTimeFormat) & "','" & Format(dtTime, "yyyy-MM-dd hh:mm:ss tt") & "','" & StrIN & "')"
                Next
            End With
            If sqlQRY <> "" Then
                FK_EQ(sqlQRY, "S", "", False, False, True)

                'Delete Original Record from the tblGetINOUT Table 
                sqlQRY = "CREATE TABLE #Temp1 (EmpID Nvarchar (6),AtDate DateTime)"
                sqlQRY = sqlQRY & " INSERT INTO #Temp1 select Max(EmpID),Max(AtDate) from tblTempINOUT GROUP BY EmpID,AtDate"
                sqlQRY = sqlQRY & " DELETE a FROM tblGetInOut a   JOIN #Temp1 z ON a.EmpID = z.EmpID AND a.AtDate = z.AtDate WHERE a.EmpID = z.EmpID AND a.AtDate = z.AtDate"
                sqlQRY = sqlQRY & " INSERT INTO tblGetInOut select tblTempINOUT.EmpID,tblTempINOUT.atDate,1,tblEmpRegister.ShiftID,tblTempINOUT.AtTime,tblTempINOUT.AtDate,dbo.fk_ReturnOUT(tblTempINOUT.EmpID,tblTempINOUT.AtDate,tblTempINOUT.AtVal+1,'OUT'),tblTempINOUT.AtTime,dbo.fk_ReturnOUT(tblTempINOUT.EmpID,tblTempINOUT.AtDate,tblTempINOUT.AtVal+1,'OUT'),tblTempINOUT.AtTime,'', " &
                " 0,0,0,0,0,1,CASE dbo.fk_ReturnOUT(tblTempINOUT.EmpID,tblTempINOUT.AtDate,tblTempINOUT.AtVal+1,'OUT') WHEN '' THEN 0 Else 1 END,0,0,0,0,0,tblTempINOUT.AtDate,0,0,ROW_NUMBER() OVER(ORDER BY tblTempINOUT.EmpID,tblTempINOUT.AtDate ASC),tblEmpRegister.DayTypeID  from tblTempINOUT INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = tblTempINOUT.EmpID AND tblEmpRegister.AtDate = tblTempINOUT.AtDate WHERE tblTempINOUT.InOut = 'IN'"

                FK_EQ(sqlQRY, "S", "", False, False, True)
            End If

            'Update tblEmpRegister according to the values in getinout
            sqlQRY = "CREATE TABLE #Tmp (EMpID Nvarchar (6),AtDate DateTime,InTime DateTime, OutTime DateTime, InUpdate Numeric (18,0),OutUpdate Numeric (18,0),AntStatus Numeric (18,0))"
            sqlQRY = sqlQRY & " INSERT INTO #Tmp SELECT EMpID,AtDate,Min(InTime),Max(OutTime),min(InUpdate),Min(OutUpdate),Min(AntStatus) FROM tblGetInOut WHERE AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "'  AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' GROUP by EmpID,AtDate Order by EmpID"
            sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.inTime1 = #Tmp.InTime,tblEmpRegister.OutTime1 = #Tmp.OutTime,tblEmpRegister.ClockOut = CASE WHEN DateDiff(minute,DateAdd(Second,1,#Tmp.OutTime),tblEmpRegister.ClockOut) < 0 THEN DateAdd(Second,1,#Tmp.OutTime) ELSE tblEmpRegister.ClockOut END ,tblEmpRegister.InUpdate = #Tmp.InUpdate,tblEmpRegister.OutUpdate = #Tmp.OutUpdate,tblEmpRegister.AntStatus = #Tmp.AntStatus FROM tblEmpRegister,#Tmp WHERE tblEmpregister.EmpID = #Tmp.EMpID AND tblEmpRegister.AtDate = #Tmp.AtDate"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Update tblDiMachine As Collected

    End Sub

    Public Sub Populate_DataGrid(ByVal sSQL As String, ByVal DGV As DataGridView, ByVal StrTable As String)
        Dim cnCon As New SqlConnection(sqlConString)
        Dim daCon As New SqlDataAdapter(sSQL, cnCon)
        Dim dsCon As New DataSet()
        daCon.Fill(dsCon, StrTable)
        DGV.DataSource = dsCon.Tables(0)




    End Sub

    Public Sub fk_GridFormat1(ByVal dgv As DataGridView)
        With dgv
            For i As Integer = 0 To .Columns.Count - 1
                Select Case i
                    Case 0
                        .Columns(i).Visible = False
                    Case 2
                        .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    Case Else
                        .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End Select
            Next
        End With
    End Sub


    ' Prasanna
    ' 2018-07-12
    'Add reprocess Without Msg For Tilakawardhana Fake 
    'funftion use form [frmEtitControl.vb]
    Public Sub Process_AttendanceEmpIDLoop(ByVal dtpStartDate As Date, ByVal dtpEndDate As Date, ByVal StrEmp As String, ByVal Mode_A_For_AllEmployee_O_For_Selected As String, ByVal pgb As ProgressBar)
        'Fix Table Structure 

        Dim sqlQRY As String
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            sqlQRY = "UPDATE tblGetInOut SET tblGetInOut.sInTime = tblGetInOut.AtDate+tblSetShiftH.InTime, " &
       " tblGetInOut.sOutTime = CASE WHEN tblDayType.WorkUnit = .5 THEN tblGetInOut.AtDate+tblSetShiftH.StartCOUT ELSE  CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblGetInOut.AtDate+tblSetShiftH.OutTime ELSE DateAdd(day,1,tblGetInOut.AtDate)+tblSetShiftH.OutTime END END, " &
       " tblGetInOut.ClockIn = tblGetInOut.AtDate+tblSetShiftH.StartCIN, tblGetInOut.ClockOut = CASE WHEN tblGetInOut.OTApved = 0 THEN CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblGetInOut.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblGetInOut.AtDate)+tblSetShiftH.EndCOUT END ELSE tblGetInOut.ClockOut END " &
       " FROM tblSetShiftH INNER JOIN tblGetInOut ON tblSetShiftH.ShiftID = tblGetInOut.ShiftID INNER JOIN tblDayType ON tblDayType.TypeID = tblGetInOut.DayTypeID WHERE tblGetInOut.AtDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEndDate, strRetDateTimeFormat) & "'"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        End If

        'New Modification : Remove Un Assign Employees from finger machines
        intCheckMachine = fk_sqlDbl("SELECT SelectMachine FROM tblControl")
        If intCheckMachine = 1 Then
            Remove_UnAssign_Machines(dtpStartDate, dtpEndDate, "")
        End If
        Dim intSelected As Integer = 0
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then intSelected = 0 Else intSelected = 1

        'Set MaxClockIn,ClockOut
        sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AtDate DateTime,ClockIn DateTime, ClockOut DateTime)"
        sqlQRY = sqlQRY & " INSERT INTO #Tmp select EmpID,AtDate,Min(ClockIn),Max(ClockOut) from tblGetInOut WHERE atDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEndDate, strRetDateTimeFormat) & "' GROUP by EMpID,AtDate "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.ClockIn = #Tmp.ClockIn,tblEmpRegister.ClockOut = CASE WHEN DateDiff(minute,tblEmpRegister.OutTime1,#Tmp.ClockOut)<0 THEN DateAdd(Second,1,tblEmpRegister.OutTime1) ELSE #Tmp.ClockOut END FROM #Tmp INNER JOIN tblEmpRegister ON tblEmpRegister.EmpID = #Tmp.EmpID AND tblEmpRegister.AtDate = #Tmp.AtDate"
        'FK_EQ(sqlQRY, "S", "", False, False, True)
        Gen_StraitShift(dtpStartDate, dtpEndDate, "", StrEmp, intSelected)
        Dim dblLateMins As Double
        Dim dblOTRound As Double
        Dim dblMinOT As Double
        Dim intOTRndOption As Double

        'Open Company Informatiion 
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        sqlQRY = "SELECT * FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlQRY, cnOpn)
            Dim drOPn As SqlDataReader = cmOpn.ExecuteReader
            If drOPn.Read = True Then
                dblLateMins = IIf(IsDBNull(drOPn.Item("Latemin")), 0, drOPn.Item("Latemin"))
                dblOTRound = IIf(IsDBNull(drOPn.Item("OTRound")), 0, drOPn.Item("OTRound"))
                dblMinOT = IIf(IsDBNull(drOPn.Item("MinHrsOT")), 0, drOPn.Item("MinHrsOT"))
                intOTRndOption = IIf(IsDBNull(drOPn.Item("OTRndOption")), 0, drOPn.Item("OTRndOption"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try
        Dim dgvEmpShift As New DataGridView
        With dgvEmpShift
            .Columns.Add("Row", "Row")
            .Columns.Add("ShiftID", "Shift ID")
            .Columns.Add("AtDate", "Attendance Date")
            .Columns.Add("ClockIn", "Clock In")
            .Columns.Add("ClockOut", "Clock Out")
            .Columns.Add("Total", "Total")
        End With

        Dim dtStartDate As Date : dtStartDate = dtpStartDate
        Dim dtEndDate As Date : dtEndDate = dtpEndDate

        'Generate the Selected Period Each day Shift And Attendance Time
        Dim sqlQRY1 As String
        sqlQRY1 = "if exists(select * from sys.objects where name = 'processShift') drop table processShift"
        FK_EQ(sqlQRY1, "S", "", False, False, False)
        sqlQRY1 = "UPDATE tblDiMachine SET tTime = cDate+cTime WHERE cDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtpEndDate, strRetDateTimeFormat) & "'"
        FK_EQ(sqlQRY1, "S", "", False, False, False)

        Select Case Mode_A_For_AllEmployee_O_For_Selected
            Case "A"

                sqlQRY1 = "select ROW_NUMBER() OVER(ORDER BY tblGetINOUT.AtDate,tblGetINOUT.ShiftID DESC) AS Row,tblGetINOUT.ShiftID,tblGetINOUT.AtDate,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,Count(tblGetINOUT.ShiftID) As Total INTO processShift FROM tblGetINOUT INNER JOIN tblEmployee ON tblGetINOUT.EmpID = tblEmployee.RegID " &
                " WHERE tblGetINOUT.AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmployee.EmpStatus <> 9 GROUP by tblGetINOUT.ShiftID,tblGetINOUT.AtDate,tblGetINOUT.ClockIn,tblGetINOUT.Clockout  " &
                " Order By tblGetINOUT.AtDate,tblGetINOUT.ShiftID DESC"
                FK_EQ(sqlQRY1, "S", "", False, False, False)
                'Load Above to the Shift GRID
                Load_InformationtoGrid("SELECT Row,ShiftID,AtDate,ClockIn,ClockOut,Total FROM processShift Order By Row", dgvEmpShift, 6)
                sqlQRY1 = "delete from TestRun"
                FK_EQ(sqlQRY1, "S", "", False, False, False)
                sqlQRY1 = ""
                Dim bolError As Boolean = False
                Dim intRow As Integer = 0
                With dgvEmpShift
                    If .RowCount <= 1 Then Exit Sub
                    pgb.Minimum = 0
                    pgb.Maximum = .RowCount - 2
                    pgb.Value = 0

                    For i As Integer = 0 To .RowCount - 2
                        Dim iTot As Integer = .Item(5, i).Value
                        intRow = CInt(.Item(0, i).Value)
                        If .Item(1, i).Value <> "" Then
                            '    sqlQRY1 = " insert into TestRun select tblGetINOUT.EmpID,tblGetINOUT.AtDate,tblGetINOUT.ShiftID,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,tblGetINOUT.SInTime," & _
                            '" tblGetINOUT.sOutTime,tblEmployee.EnrolNo,dbo.fk_ReturnINOUT(tblEmployee.EnrolNo,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,'I') As InTime," & _
                            '" dbo.fk_ReturnINOUT(tblEmployee.EnrolNo,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,'O') As OutTime,0 As AntStatus, 0 As InUpdate, 0 As OutUpdate,'N' As Match FROM tblEmployee " & _
                            '" INNER JOIN tblGetINOUT ON tblEmployee.RegID = tblGetINOUT.EmpID " & _
                            '" INNER JOIN processShift ON tblGetINOUT.ShiftID = processShift.ShiftID AND tblGetINOUT.ClockIn = processShift.ClockIn AND tblGetINOUT.ClockOut = processShift.ClockOut " & _
                            '" where processshift.Row = " & intRow & " AND tblEmployee.EMpStatus <> 9"

                            '###### HRISforBB #####################
                            'Description    : Change Process without using InOut Taking Function 
                            sqlQRY1 = "insert into TestRun " &
                             " select tblGetINOUT.EmpID,tblGetINOUT.AtDate,tblGetINOUT.ShiftID,tblGetINOUT.ClockIn,tblGetINOUT.ClockOut,tblGetINOUT.SInTime, tblGetINOUT.sOutTime,tblEmployee.EnrolNo,'' As InTime,  '' As OutTime, " &
                             " 0 As AntStatus, 0 As InUpdate, 0 As OutUpdate,'N' As Match FROM tblEmployee   INNER JOIN tblGetINOUT ON tblEmployee.RegID = tblGetINOUT.EmpID  " &
                             " INNER JOIN processShift ON tblGetINOUT.ShiftID = processShift.ShiftID  AND tblGetINOUT.ClockIn = processShift.ClockIn AND tblGetINOUT.ClockOut = processShift.ClockOut  " &
                             " where processshift.Row = " & intRow & " AND tblEmployee.EMpStatus <> 1 Order By tblGetInOut.EmpID"
                            sqlQRY1 = sqlQRY1 & "  select tblDiMachine.EmpID,tblDiMachine.cDate,TestRun.ClockIn,TestRun.ClockOut,InTime  = Min(tblDiMachine.tTime),OutTime = Max(tblDiMachine.tTime),inUpdate = 0,OutUpdate = 0 Into #T_Time From TestRun,tblDiMachine " &
                                                " WHERE TestRun.EnrolNo = tblDiMachine.EmpID AND tblDiMachine.cDate = TestRun.AtDate GROUP BY tblDiMachine.EmpID ,tblDiMachine.cDate,TestRun.ClockIn,TestRun.ClockOut "
                            sqlQRY1 = sqlQRY1 & " UPDATE #T_Time Set InUpdate = 1 WHERE InTIme Between ClockIn AND ClockOut "
                            sqlQRY1 = sqlQRY1 & " UPDATE #T_Time SET OutUpdate = 1 WHERE OutTime Between DateAdd(Minute,1,InTime) AND ClockOut"
                            sqlQRY1 = sqlQRY1 & " UPDATE TestRun SET TestRun.InTime  =#T_Time.InTime,TestRun.OutTime = #T_Time.OutTime , TestRun.InUpdate = #T_Time.InUPdate,TestRun.OutUpdate = #T_Time.OutUpdate FROM #T_Time,TestRun WHERE #T_Time.EmpID = TestRun.EnrolNo AND #T_Time.cDate = TestRun.AtDate"

                        End If
                        bolError = FK_EQ(sqlQRY1, "S", "", False, False, True)
                        If bolError = False Then Exit Sub
                        pgb.Value = i
                    Next
                End With

            Case "O"

                'Update Clock In Clock Out from the Shift Header tables 
                sqlQRY1 = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime,cIn DateTime,cOut DateTime)"
                sqlQRY1 = sqlQRY1 & " Insert into #T Select tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpREgister.AtDate+tblSetShiftH.StartCIN,CASE WHEN tblSetShiftH.ShiftMode = 0 THEN tblEmpRegister.AtDate+tblSetShiftH.EndCOUT ELSE DateAdd(Day,1,tblEmpREgister.AtDate)+tblSetShiftH.EndCOUT END From tblEmpRegister,tblSetShiftH WHERE tblEmpRegister.ShiftID = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID In ('" & StrEmp & "')"
                sqlQRY1 = sqlQRY1 & " UPDATE tblEmpRegister SET tblEmpREgister.ClockIn = #T.cIn ,tblEmpRegister.ClockOut = #T.cOut FROM #T,tblEmpRegister WHERE #T.EmpID = tblEmpRegister.EmpID AND #T.AtDate = tblEmpRegister.AtDate"
                'New Query for KDU 20160325
                sqlQRY1 = sqlQRY1 & "UPDATE tblEmpRegister SET antStatus=0,inUpdate=0,outUpdate=0,isNightWork=1,workMins=0 WHERE tblEmpRegister.AtDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND tblEmpRegister.EmpID In ('" & StrEmp & "')"
        End Select
        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            'Modification Dashboard : Kasun 20160918
            Dim intTriD As Integer = fk_sqlDbl("SELECT procTrID+1 FROM tblControl")
            Dim intNewProcesedCount As Integer = fk_sqlDbl("SELECT count(*) FROM tblDiMachine WHERE cDate BETWEEN '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND dStatus=0")
            sSQL = "INSERT INTO tblProcessHistory (pAID,crUser,crTime,pDesc,pCount,pStatus) VALUES (" & intTriD & ",'" & StrUserID & "',getDate(),'Processed data in old manual night fix mode'," & intNewProcesedCount & ",0); UPDATE tblControl SET procTrID=" & intTriD & " WHERE GrpID='001';  UPDATE tblCompany SET AtnPrcDate = '" & Format(dtpEndDate, strRetDateTimeFormat) & "' WHERE CompID = '" & StrCompID & "'; UPDATE tblDiMachine SET dStatus=1 WHERE cDate Between '" & Format(dtpStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND dStatus=0; UPDATE [tblDeviceInfo] SET [lastProcessed]='1900-01-01 00:00:00.000'" : FK_EQ(sSQL, "P", "", False, False, True)
        End If
        'NEW ON 10/16/2014 - Update tblDeviceInfo table for the Machine Maximum date 
        sqlQRY1 = "CREATE TABLE #T (MacID Nvarchar (3),lDate DateTime)"
        sqlQRY1 = sqlQRY1 & " INSERT INTO #T SELECT MacID,Max(ttime) FROM tblDiMachine WHERE EditMode = 0 Group By MacID"
        sqlQRY1 = sqlQRY1 & " UPDATE tblDeviceInfo SET tblDeviceInfo.LProcessDate = #T.lDate FROM #T,tblDeviceInfo WHERE #T.MacID = tblDeviceInfo.machinID"
        FK_EQ(sqlQRY1, "S", "", False, False, True)

        'Get OpenShift Seperatly
        Dim dgvAllDate As New DataGridView
        Dim iDayCount As Integer = DateDiff(DateInterval.Day, dtStartDate, dtEndDate)
        Dim dtDateM As Date = dtStartDate
        pgb.Minimum = 0 : pgb.Value = 0 : pgb.Maximum = iDayCount + 1
        For i As Integer = 0 To iDayCount
            If i > 0 Then dtDateM = DateAdd(DateInterval.Day, 1, dtDateM)
            pgb.Value = i + 1
            fk_Process_SplitShift(dtDateM, dtDateM, StrEmp, Mode_A_For_AllEmployee_O_For_Selected)
        Next

        '10/11/2014 - Split Shift Generation 
        proc_ShiftLineOnSplit(dtStartDate, dtEndDate)

        If Mode_A_For_AllEmployee_O_For_Selected = "A" Then
            process_AttendanceParameters(dtStartDate, dtEndDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        ElseIf Mode_A_For_AllEmployee_O_For_Selected = "O" And IsRunAutoCalculation = 1 Then
            process_AttendanceParameters(dtStartDate, dtEndDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)
        Else
            '  MsgBox("Process Completed", MsgBoxStyle.Information)
        End If
        'fk_Process_SplitShift(dtStartDate, dtEndDate, StrEmp,Mode_A_For_AllEmployee_O_For_Selected)
        'process_AttendanceParameters(dtStartDate, dtEndDate, dblMinOT, intOTRndOption, dblOTRound, dblLateMins)

    End Sub

    Public Function FK_GetIDLeftDash(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                For X = 1 To Len(sString)
                    If Mid(sString, X, 1) = "-" Then
                        sRetString = Left(sString, X - 1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function


End Module
