Module mod_NewLeaveApplication
    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    'Module Name    : New Leave Module
    'Description    : Generate Leave based on employee joined date and spent months (Earn Leave)
    '                 Leave Type will generate based on employee type feild
    'Author         : Kasun
    'Start Date     : 29/Jun/2017
    'End Date       :
    'Modification   :
    'Reason         : Leave Module as per the request of the Seroton
    '#############################################################


    'Create New Leave Structures 
    Public intIsNewLeaveC As Integer = 0

    Public Function fk_CreateLvRelatedTables() As Boolean
        Dim bolRet As Boolean = False
        Dim sqlQRY As String = ""
        'ALTER tblControl to Add PrfID
        sqlQRY = "ALTER TABLE tblControl ADD NoLvProf Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)

        'ALTER tblEmployee table to Keep Leave Start Date
        sqlQRY = "ALTER TABLE tblEmployee ADD LVPrfST_Date DateTime NOT NULL Default ''" : FK_EQ(sqlQRY, "S", "", False, False, False)
        'CREATE tblLvProfile TABLE
        sqlQRY = "CREATE TABLE tblLeaveProfile ( PrfID Nvarchar (3),pr_Name Nvarchar (50),r_Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        'CREATE tblLeaveProfile Data Table
        sqlQRY = "CREATE TABLE tblLvPrfTerms (TrID Nvarchar (4),EmpCatID nvarchar (3),EmpTypeID Nvarchar (3),LeaveID nvarchar (3),St_Month Numeric (18,0),Ed_Month Numeric (18,0),IsMonthlyLv Numeric (18,0),Lv_Entlment Numeric (18,2),LLocation Numeric (18,0),R_Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        'ADD Feield In tblEmpLeaveD to Contain the Brought Forward leave 
        sqlQRY = "ALTER TABLE tblEmpLeaveD ADD BFLvQty Numeric (18,2) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)

        'Leave Calculation Procuedure 
        'sqlQRY = "DROP PROC sp_CalLeave" : FK_EQ(sqlQRY, "S", "", False, False, False)
        'sSQL = "CREATE PROC sp_CalLeave (@StMonth Numeric (18,0),@MinAge Numeric (18,0),@AnlMinAge Numeric (18,0),@cYear Numeric (18,0),@RegID Nvarchar(6)) As BEGIN Select tblEmployee.RegID,tblEmployee.CatID,tblEmployee.EmpTypeID,tblEmployee.DispName,tblEmployee.RegDate,JoinAge = DateDiff(Month,RegDate,GetDate()),RunJan = CASE WHEN DateDiff(Month,tblEmployee.RegDate,Convert(Nvarchar(8),(Year(GetDate())))+'01'+'01')<0 THEN 'N' ELSE 'Y' END ,CanANL = CASE WHEN DateDiff(Month,tblEmployee.RegDate,GetDate()) > @AnlMinAge THEN 'Y' ELSE 'N' END,JoinMonth = CASE WHEN DateDiff(Month,RegDate,GetDate()) <=12 THEN Month(RegDate) ELSE 1 END,tblLvPrfTerms.LeaveID,tblLvPrfTerms.IsMonthlyLv,tblLvPrfTerms.Lv_Entlment,tblLvPrfTerms.LLocation,cYear = @cYear,Fx_Ent = CASE WHEN tblLvPrfTerms.LLocation=0 THEN (tblLvPrfTerms.Lv_Entlment * DateDiff(Month,RegDate,GetDate())) ELSE tblLvPrfTerms.Lv_Entlment END INTO #R_N from tblEmployee,tblLvPrfTerms WHERE (tblEmployee.CatID = tblLvPrfTerms.EmpCatID AND tblEmployee.EmpTypeID = tblLvPrfTerms.EmpTypeID) AND tblEmployee.EmpStatus <> 9 AND CASE WHEN DateDiff(Month,RegDate,GetDate()) <=12 THEN Month(RegDate) ELSE 1 END Between tblLvPrfTerms.St_Month AND tblLvPrfTerms.Ed_Month AND tblLvPrfTerms.R_Status = 0 AND tblEmployee.RegID = @RegID Order By tblEmployee.RegID DELETE FROM #R_N WHERE RunJan='N' AND LLocation = 1 DELETE FROM #R_N WHERE RunJan='Y' AND LLocation = 0 UPDATE tblEmpLeaveD SET NoLeaves = 0 WHERE EmpID = @RegID AND cYear = @cYear UPDATE tblEmpLeaveD SET tblEmpLeaveD.NoLeaves = #R_N.Fx_Ent FROM #R_N,tblEmpLeaveD WHERE #R_N.LeaveID = tblEmpLeaveD.LeaveID AND #R_N.RegID = tblEmpLeaveD.EmpID AND #R_N.cYear = tblEmpLeaveD.cYear  END" : FK_EQ(sSQL, "S", "", False, False, False)
        'Function to Create sql Serial Number for the leave 

        sqlQRY = "DROP FUNCTION dbo.fnNumPadLeft" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "CREATE FUNCTION dbo.fnNumPadLeft (@input INT, @pad tinyint)" &
        " RETURNS VARCHAR(250) " &
        " AS BEGIN" &
        " DECLARE @NumStr VARCHAR(250)" &
        " SET @NumStr = LTRIM(@input)" &
        " IF(@pad > LEN(@NumStr))" &
        " SET @NumStr = REPLICATE('0', @Pad - LEN(@NumStr)) + @NumStr;" &
        " RETURN @NumStr;" &
        " End " : FK_EQ(sqlQRY, "S", "", False, False, False)

        'Create sql Procedure to Copy existing Category to new category of leave configuration Structure 
        sqlQRY = "DROP PROC sp_CopyLeaveStructure" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "  CREATE PROC sp_CopyLeaveStructure (@DCatID Nvarchar (3),@SCatID Nvarchar (3),@Location Numeric (18,0))" &
        " AS BEGIN " &
        " Declare @MaxLen Numeric (18,0)" &
        " SET @MaxLen = (SELECT NoLPrfConfig FROM tblControl ) +1;" &
        " DELETE FROM tblLvPrfTerms where EmpCatID = @dCatID AND LLocation = @Location" &
        " insert into tblLvPrfTerms select TrID = dbo.fnNumPadLeft((ROW_NUMBER() OVER(ORDER BY TRID)+@MaxLen),4),EmpCatID = @DCatID,EmpTypeID,LeaveID,St_Month,Ed_Month,IsMonthlyLv,Lv_Entlment,LLocation,R_Status From tblLvPrfTerms where EmpCatID = @sCatID AND LLocation = @Location" &
        " UPDATE tblControl SET NoLPrfConfig = (SELECT max(TrID) FROM tblLvPrfTerms) END" : FK_EQ(sqlQRY, "S", "", False, False, False)

        sqlQRY = "ALTER TABLE tblControl ADD IsSheLeave NUMERIC (18,0) NOT NULL DEFAULT 0" : FK_EQ(sqlQRY, "S", "", False, False, False)

        Return bolRet

    End Function


End Module
