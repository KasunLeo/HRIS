
Module mod_EOPPrc
    'Extended Summary Leave Parts
    Public intIsExtSumRep As Integer = 0
    Public StrNpSumLvID As String = ""
    Public StrAnSumLvID As String = ""
    Public StrCaSumLvID As String = ""
    Public StrMdSumLvID As String = ""

    Public StrShortSumLvID As String = ""
    Public StrSickSumLvID As String = ""


    Public Function Process_EOM(ByVal tblName As String, ByVal dtStart As Date, ByVal dtEnd As Date, ByVal StrProcess As String, ByVal IntYear As Integer, ByVal intMonth As Integer) As Boolean
        'Process '01' Variance Process , '02' EOM Process
        Dim sqlTable As String
        sqlTable = "CREATE FUNCTION [dbo].[fk_ReturnLeaveSum] (@EmpID nvarchar(6), @stDate DateTime, @EdDate DateTime)  RETURNS Numeric (18,2)  " &
        " AS  BEGIN  declare @Return Numeric (18,2)  set @return = (select Sum(NoLeave) FROM tblLeaveTRD where EmpID = @EmpID AND  lvDate Between @StDate AND @edDate) AND tblLeaveTrd.Status = 1 " &
        " if @return is null 	set @return = 0 return @return  end  "
        FK_EQ(sqlTable, "S", "", False, False, False)

        Dim bolRes As Boolean = False
        'Insert Master Records for the Period to the Main Summary table
        Dim iMonth As Integer = Month(dtStart)
        Dim iYear As Integer = Year(dtStart)


        Dim sqlQRY As String = ""
        Dim StrLvType As String = "" : Dim StrfldName As String = ""

        sqlQRY = "DELETE FROM " & tblName
        sqlQRY = sqlQRY & " INSERT INTO " & tblName & " ( EmpID,cyear,cMonth,WrkDays,WrkedDays,WrkHours,OTHrs,Latedays,LateMins,EarlyDays,EarlyMins,NumOffDays,LvDays,NumUATLv,EmpOffs)" &
        " SELECT tblEmpRegister.EmpID," & iYear & "," & iMonth & ",Sum(tblDayType.WorkUnit),Sum(tblEmpRegister.NRWorkDay),Sum(tblEmpRegister.WorkHrs),Sum(tblEmpRegister.cOTHrs), " &
        " Sum(tblEmpRegister.IsLate),Sum(CASE tblEmpRegister.IsLate WHEN 1 THEN tblEmpRegister.LateMins ELSE 0 END),Sum(isEarly), Sum(CASE tblEmpRegister.IsEarly WHEN 1 THEN tblEmpRegister.EarlyMins ELSE 0 END ), " &
        " Sum(tblEmpRegister.AdWorkDay),dbo.fk_ReturnLeaveSum(tblEmpRegister.EmpID,'" & Format(dtStart, "yyyyMMdd") & "','" & Format(dtEnd, "yyyyMMdd") & "'),0,Sum(CASE WHEN tblDayType.WorkUnit = 0 THEN 1 WHEN tblDayType.WorkUnit = .5 THEN .5 Else 0 END) FROM tblEmpRegister " &
        " INNER JOIN tblDayType ON tblEmpRegister.DayTypeID = tblDayType.TypeID WHERE tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' GROUP By tblEmpRegister.EmpID"
        FK_EQ(sqlQRY, "S", "", False, False, True)


        Dim dgvLvTypes As New DataGridView
        With dgvLvTypes
            .Columns.Clear()
            .Columns.Add("lvType", "Leave Type")
            .Columns.Add("lvDesc", "Leave Descr")
            .Columns.Add("lvFld", "Leave Feild")
        End With
        sqlQRY = ""
        sqlTable = "SELECT lvID,lvDesc,lvFld FROM tblLeaveType WHERE Status = 0 Order By lvID"
        Load_InformationtoGrid(sqlTable, dgvLvTypes, 3)

        With dgvLvTypes
            For i As Integer = 0 To .RowCount - 2
                StrLvType = .Item(0, i).Value
                StrfldName = .Item(2, i).Value
                sqlQRY = sqlQRY & " DELETE FROM tblUpMidle"
                sqlQRY = sqlQRY & " INSERT INTO tblUpMidle SELECT tblLeaveTRD.EmpID,Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRD  INNER JOIN tblLeaveTRH ON tblLeaveTRD.RqID = tblLeaveTRH.RqID WHERE tblLeaveTRD.LvDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRD.lvType = '" & StrLvType & "' GROUP BY tblLeaveTRD.EmpID"
                sqlQRY = sqlQRY & " update " & tblName & " SET  " & tblName & "." & StrfldName & " = tblupMidle.cValue FROM tblUpMidle INNER JOIN " & tblName & " ON tblUpMidle.EmpID = " & tblName & ".EmpID "
            Next
        End With

        FK_EQ(sqlQRY, "S", "", False, True, True)


    End Function

End Module
