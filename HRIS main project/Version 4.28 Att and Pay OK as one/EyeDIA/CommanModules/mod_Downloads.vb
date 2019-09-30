Module mod_Downloads

    Public intMultiD As Integer = 0
    Public dtRepGStart As Date
    Public dtRepGEnd As Date

    Public Sub Gen_StraitShift(ByVal StDate As Date, ByVal EdDate As Date, ByVal MacID As String, ByVal EmpID As String, ByVal intIsSelected As Integer)
        'Get the All Employees Related to Strait Shift
        Dim sqlQRY As String = ""
        If intIsSelected = 1 Then
            sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),EnrolNo Numeric (18,0),Atdate DateTime, ShiftID Nvarchar (3), StTime DateTime, EdTIme DateTime,ClockIn DateTime, ClockOut DateTime) "
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.AtDate,tblEmpRegister.AllShifts,'','',tblEmpRegister.ClockIn,tblEmpRegister.ClockOut FROM tblEmpRegister,tblEmployee,tblSetShiftH WHERE tblEmpRegister.EmpID = tblEmployee.RegID AND tblEmpRegister.AllShifts = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(StDate, "yyyyMMdd") & "' AND '" & Format(EdDate, "yyyyMMdd") & "' AND tblSetShiftH.StrShift = 1 AND tblEmployee.RegID In ('" & EmpID & "') "

        Else
            sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),EnrolNo Numeric (18,0),Atdate DateTime, ShiftID Nvarchar (3), StTime DateTime, EdTIme DateTime,ClockIn DateTime, ClockOut DateTime) "
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmployee.EnrolNo,tblEmpRegister.AtDate,tblEmpRegister.AllShifts,'','',tblEmpRegister.ClockIn,tblEmpRegister.ClockOut FROM tblEmpRegister,tblEmployee,tblSetShiftH WHERE tblEmpRegister.EmpID = tblEmployee.RegID AND tblEmpRegister.AllShifts = tblSetShiftH.ShiftID AND tblEmpRegister.AtDate Between '" & Format(StDate, "yyyyMMdd") & "' AND '" & Format(EdDate, "yyyyMMdd") & "' AND tblSetShiftH.StrShift = 1 AND tblEmployee.RegID In ('" & EmpID & "') "
        End If
        'Get the Minimum In Time From the tblDiMachine
        sqlQRY = sqlQRY & " CREATE TABLE #T1 (EmpID Nvarchar (6),EnrolNo Numeric (18,0),AtDate DateTime,sTime DateTime)"
        sqlQRY = sqlQRY & " INSERT INTO #T1 SELECT #T.EmpID,tblEmployee.EnrolNo,#T.AtDate,Min(tblDiMachine.tTime) FROM #T,tblEmployee,tblDiMachine WHERe tblEmployee.RegID = #T.EmpID AND tblEmployee.EnrolNo = tblDiMachine.EmpID AND #T.AtDate = tblDiMachine.cDate AND tblDiMachine.tTime Between #T.ClockIn AND #T.ClockOut GROUP By #T.EmpID,tblEmployee.EnrolNo,#T.AtDate "
        sqlQRY = sqlQRY & " UPDATE #T SET #T.StTime = #T1.sTime FROM #T1,#T WHERE #T1.EmpID = #T.EmpID AND #T1.AtDate = #T.AtDate"
        'Get the Maximum as Out Time from the tblDiMachine
        sqlQRY = sqlQRY & " CREATE TABLE #T2 (EmpID Nvarchar (6),EnrolNo Numeric (18,0),AtDate DateTime,sTime DateTime)"
        sqlQRY = sqlQRY & " INSERT INTO #T2 SELECT #T.EmpID,tblEmployee.EnrolNo,#T.AtDate,Max(tblDiMachine.tTime) FROM #T,tblEmployee,tblDiMachine WHERe tblEmployee.RegID = #T.EmpID AND tblEmployee.EnrolNo = tblDiMachine.EmpID AND #T.AtDate = tblDIMachine.cDate AND tblDiMachine.tTime Between #T.StTime AND #T.ClockOut GROUP By #T.EmpID,tblEmployee.EnrolNo,#T.AtDate "
        sqlQRY = sqlQRY & " UPDATE #T SET #T.EdTime = #T2.sTime FROM #T2,#T WHERE #T2.EmpID = #T.EmpID AND #T2.AtDate = #T.AtDate"

        sqlQRY = sqlQRY & " UPDATE tblDiMachine SEt tblDiMachine.Capture = 9 FROM #T,tblDiMachine WHERE tblDiMachine.EmpID = #T.EnrolNo AND tblDiMachine.cDate = #T.AtDate AND tblDiMachine.tTime Between DateAdd(Second,1,#T.StTime) AND DateAdd(Second,-1,#T.EdTime)"
        FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    Public Sub Remove_UnAssign_Machines(ByVal stDate As Date, ByVal EdDate As Date, ByVal MacID As String)
        Dim sqlQRY As String
        sqlQRY = "CREATE TABLE #Tmp (EmpID Nvarchar (6),AtDate DateTime,EnrolNo Nvarchar (10),fpMacID Nvarchar (3),EmpMacID Nvarchar (3),r_Status Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #Tmp SELECT tblEmployee.RegID,tblDiMachine.cDate,tblDiMachine.EmpID,tblDiMachine.MacID,tblEmployee.f_Machine,0 FROM tblEmployee,tblDiMachine WHERE tblEmployee.EnrolNo = tblDiMachine.EmpID AND tblDimachine.cDate Between '" & Format(stDate, "yyyyMMdd") & "' AND '" & Format(EdDate, "yyyyMMdd") & "' AND tblDiMachine.Capture <> 9"
        sqlQRY = sqlQRY & " UPDATE #TMp SET r_Status = 9 WHERE fpMacID <> EmpMacID"
        sqlQRY = sqlQRY & " UPDATE tblDiMachine SET tblDiMachine.Capture = #Tmp.r_Status FROM tblDiMachine,#Tmp WHERE tblDiMachine.cDate = #Tmp.AtDate AND tblDiMachine.EmpID = #Tmp.EnrolNo AND tblDIMachine.MacID = #Tmp.fpMacID AND tblDIMachine.Capture <> 9"
        FK_EQ(sqlQRY, "S", "", False, False, True)
    End Sub
End Module
