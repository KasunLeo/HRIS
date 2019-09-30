Module mod_FantasiaReports
    'PUblic declaration 

    Public intFantasia As Integer = 1
    Public StrRBranchName As String = ""
    Public intOTApSeperate As Integer = 0
    Public StrRCatName As String = ""
    Public StrRActName As String = ""


    '********************* Fantasia New Customer Specific report generating codes********************
    'Author         : Kasun
    'Start Date     : 10/15/2018
    '------------------------------------------------------------------------------------------------

    Public Function fk_RetGridDuplicate_R(ByVal dgv As DataGridView, ByVal intCol As Integer, ByVal EnterVal As String, ByVal RetRq As String) As Boolean
        Dim bolReturn As Boolean = False : Dim StrCurrentVal As String = ""

        With dgv
            For i As Integer = 0 To .RowCount - 1
                StrCurrentVal = .Item(intCol, i).Value
                Select Case RetRq
                    Case "T"
                        If StrCurrentVal = EnterVal Then bolReturn = True : i = .RowCount - 1
                    Case "F"
                        If StrCurrentVal <> EnterVal Then bolReturn = True : i = .RowCount - 1
                End Select

            Next
        End With
        Return bolReturn
    End Function

    Public Function fk_GetDateACT_EmpsDTRange(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As String
        Dim sqlQRY As String = ""
        Dim dtRunDate As Date

        Try

            FK_EQ("if exists (SELECT * FROM sys.objects where name = 'tblERHist')  DROP TABLE tblERHist ;", "D", "", False, False, True)

            sqlQRY = "CREATE TABLE tblERHist (RegID Nvarchar (6),RegDate DateTime,EmpStatus Numeric (18,0),IsOldEmp Numeric (18,0),O_RegDate DateTime,GenderID Nvarchar (3),CatID Nvarchar (3),ActID Nvarchar (3),A_CatID Nvarchar (3),DeptID Nvarchar (3),BrID Nvarchar (3),RDate DateTime,ShiftID Nvarchar (3),NCityID Nvarchar (3))" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "CREATE TABLE #E (RegID Nvarchar (6),RegDate DateTime, EmpStatus Numeric (18,0),StatusDate DateTime,O_Regdate DateTime,IsOLDEmp Numeric (18,0),BrID Nvarchar (3),DeptID Nvarchar (3))"
            While (dtStart <= DtEnd)
                dtRunDate = dtStart

                sqlQRY = sqlQRY & " DELETE FROM #E"
                sqlQRY = sqlQRY & " INSERT INTO #E SELECT tblEmployee.RegID,CASE WHEN tblEmployee.IsOldEmp = 1 THEN tblEmployee.RegDate ELSE tblEmployee.O_RegDate END,tblEmployee.EmpStatus,tblEmployee.StatusDate,tblEmployee.O_RegDate,tblEmployee.IsOLDEmp,tblEmployee.BrID,tblEmployee.DeptID FROM dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany,tblsettitle,tblsetemptype,tblSetActTypesHRIS   " & _
                "where   dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
                " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
                " dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
                " dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
                " dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
                " dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
                " dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID AND   " & _
                " tblEmployee.ActType = tblSetActTypesHRIS.ActID AND " & _
                " tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
                " AND (dbo.tblEmployee.RegID LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.DispName LIKE '%" & StrSearchR & "%' OR     " & _
                " dbo.tblEmployee.EMPNo LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & StrSearchR & "%' OR    " & _
                " dbo.tblEmployee.EPFNo LIKE '%" & StrSearchR & "%') AND  " & _
                " (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
                " dbo.tblSetDept.deptName LIKE '" & StrDeptName & "%' AND   " & _
                " dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
                " dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
                " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND   " & _
                " dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND   " & _
                " dbo.tblSetActTypesHRIS.dscrb LIKE '" & StrActName & "%' ) "

                sqlQRY = sqlQRY & " delete from #E WHERE EmpStatus =9 AND StatusDate <'" & Format(dtRunDate, "yyyyMMdd") & "'"
                sqlQRY = sqlQRY & " update #E SET EmpStatus = 1 where EmpStatus = 9 AND StatusDate >='" & Format(dtRunDate, "yyyyMMdd") & "'"



                sqlQRY = sqlQRY & " delete from #E where O_RegDate >'" & Format(dtRunDate, "yyyyMMdd") & "' AND IsOLDEmp = 1"
                sqlQRY = sqlQRY & " delete from #E where RegDate >'" & Format(dtRunDate, "yyyyMMdd") & "' AND IsOLDEmp = 0"


                ' sqlQRY = sqlQRY & " INSERT INTO tblERHist select #E.RegID,#E.RegDate,#E.EmpStatus,#E.IsOldEmp,tblEmployee.O_RegDate,tblEmployee.GenderID,tblEmployee.CatID,tblEmployee.ActID,tblEmployee.A_CatID,tblEmployee.DeptID,tblEmployee.BrID, '" & Format(dtRunDate, "yyyyMMdd") & "','' From #E,tblEmployee where tblEmployee.RegID = #E.RegID AND #E.EmpStatus <> 9 order By #E.RegDate"
                sqlQRY = sqlQRY & " INSERT INTO tblERHist select #E.RegID,#E.RegDate,#E.EmpStatus,#E.IsOldEmp,tblEmployee.O_RegDate,tblEmployee.GenderID,tblEmployee.CatID,tblEmployee.ActType,tblEmployee.SubCatID,tblEmployee.DeptID,tblEmployee.BrID, '" & Format(dtRunDate, "yyyyMMdd") & "','',tblEmployee.NearestCityID From #E,tblEmployee where tblEmployee.RegID = #E.RegID AND #E.EmpStatus <> 9 order By #E.RegDate"

                dtStart = dtStart.AddDays(1)
            End While
            FK_EQ(sqlQRY, "S", "", False, False, True)

            sqlQRY = " ALTER TABLE tblERHist ADD AntStatus Numeric (18,0) NOT NULL Default 0"
            sqlQRY = sqlQRY & " ALTER TABLE tblERHist ADD Gender_D Nvarchar (20) NOT NULL Default ''"
            sqlQRY = sqlQRY & " ALTER TABLE tblERHist ADD Cat_D Nvarchar (20) NOT NULL Default ''"
            sqlQRY = sqlQRY & " ALTER TABLE tblERHist ADD Act_D Nvarchar (20) NOT NULL Default ''"
            sqlQRY = sqlQRY & " ALTER TABLE tblERHist ADD ACat_D Nvarchar (20) NOT NULL Default ''"
            sqlQRY = sqlQRY & " ALTER TABLE tblERHist ADD Dept_D Nvarchar (100) NOT NULL Default ''"
            sqlQRY = sqlQRY & " ALTER TABLE tblERHist ADD Br_D Nvarchar (20) NOT NULL Default '' "
            FK_EQ(sqlQRY, "S", "", False, False, True)


            sqlQRY = " UPDATE tblERHist SET Gender_D = CASE WHEN GenderID = '001' THEN 'Male' Else 'Female' END "
            sqlQRY = sqlQRY & " UPDATE tblERHist SET Cat_D = tblSetEmpCategory.CatDesc FROM tblSetEmpCategory,tblERHist WHERE tblSetEmpCategory.CatID = tblERHist.CatID "
            sqlQRY = sqlQRY & " UPDATE tblERHist SET Act_D = CASE WHEN ActID = '002' THEN 'Shop & Office' ELSE 'Wages Board' END "
            sqlQRY = sqlQRY & " UPDATE tblERHist SET Acat_D = CASE WHEN A_CatID = '001' THEN 'Direct' WHEN A_CatID = '002' THEN 'In-Direct' ELSE 'Admin' END "
            sqlQRY = sqlQRY & " UPDATE tblERHist SET tblERHist.Dept_D = tblSetDept.DeptName FROM tblSetDept,tblERHist WHERE tblSetDept.DeptID = tblERHist.DeptID "
            sqlQRY = sqlQRY & " UPDATE tblERHist SET tblERHist.Br_D = tblCbranchs.BrName FROM tblCbranchs,tblERHist WHERE tblCbranchs.BRID = tblERHist.BrID"
            sqlQRY = sqlQRY & " UPDATE tblERHist SET tblERHist.AntStatus = tblEmpRegister.AntStatus,tblERHist.ShiftID = tblEmpRegister.AllShifts FROM tblEmpRegister,tblERHist WHERE tblEmpRegister.EmpID=tblERHist.RegID AND tblEmpRegister.AtDate = tblERHist.RDate"


            FK_EQ(sqlQRY, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return sqlQRY
    End Function

    Public Function fk_GetDateInAct_Emps(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As String
        Dim SqlQRY As String = ""
        Try
            FK_EQ("if exists (SELECT * FROM sys.objects where name = 'tblERHist')  DROP TABLE tblERHist ;", "D", "", False, False, True)

            SqlQRY = "CREATE TABLE tblERHist (RegID Nvarchar (6),RegDate DateTime,EmpStatus Numeric (18,0),IsOldEmp Numeric (18,0),O_RegDate DateTime,GenderID Nvarchar (3),CatID Nvarchar (3),ActID Nvarchar (3),A_CatID Nvarchar (3),DeptID Nvarchar (3),BrID Nvarchar (3),RDate DateTime,ShiftID Nvarchar (3))" : FK_EQ(SqlQRY, "S", "", False, False, True)
            SqlQRY = "CREATE TABLE #E (RegID Nvarchar (6),RegDate DateTime, EmpStatus Numeric (18,0),StatusDate DateTime,O_Regdate DateTime,IsOLDEmp Numeric (18,0),BrID Nvarchar (3),DeptID Nvarchar (3))"
            SqlQRY = SqlQRY & " DELETE FROM #E"
            SqlQRY = SqlQRY & " INSERT INTO #E SELECT tblEmployee.RegID,CASE WHEN tblEmployee.IsOldEmp = 1 THEN tblEmployee.RegDate ELSE tblEmployee.O_RegDate END,tblEmployee.EmpStatus,tblEmployee.StatusDate,tblEmployee.O_RegDate,tblEmployee.IsOLDEmp,tblEmployee.BrID,tblEmployee.DeptID FROM dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany,tblsettitle,tblsetemptype,tblSetActTypesHRIS   " & _
            "where   dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
            " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
            " dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
            " dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
            " dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
            " dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
            " dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID AND   " & _
            " tblEmployee.ActType = tblSetActTypesHRIS.ActID AND " & _
            " tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
            " AND (dbo.tblEmployee.RegID LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.DispName LIKE '%" & StrSearchR & "%' OR     " & _
            " dbo.tblEmployee.EMPNo LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & StrSearchR & "%' OR    " & _
            " dbo.tblEmployee.EPFNo LIKE '%" & StrSearchR & "%') AND  " & _
            " (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
            " dbo.tblSetDept.deptName LIKE '" & StrDeptName & "%' AND   " & _
            " dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
            " dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
            " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND   " & _
            " dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND   " & _
            " dbo.tblSetActTypesHRIS.dscrb LIKE '" & StrActName & "%' ) AND tblEmployee.StatusDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(DtEnd, "yyyyMMdd") & "' "

            SqlQRY = SqlQRY & " delete from #E WHERE EmpStatus <>9 "
            'SqlQRY = SqlQRY & " Delete from #E WHERE StatusDate >='" & Format(dtStart, "yyyyMMdd") & "'"

            SqlQRY = SqlQRY & " INSERT INTO tblERHist select #E.RegID,#E.RegDate,#E.EmpStatus,#E.IsOldEmp,tblEmployee.O_RegDate,tblEmployee.GenderID,tblEmployee.CatID,tblEmployee.ActType,tblEmployee.SubCatID,tblEmployee.DeptID,tblEmployee.BrID, '" & Format(dtStart, "yyyyMMdd") & "','' From #E,tblEmployee where tblEmployee.RegID = #E.RegID  order By #E.RegDate"
            FK_EQ(SqlQRY, "S", "", False, False, True)

            SqlQRY = " ALTER TABLE tblERHist ADD AntStatus Numeric (18,0) NOT NULL Default 0"
            SqlQRY = SqlQRY & " ALTER TABLE tblERHist ADD Gender_D Nvarchar (20) NOT NULL Default ''"
            SqlQRY = SqlQRY & " ALTER TABLE tblERHist ADD Cat_D Nvarchar (20) NOT NULL Default ''"
            SqlQRY = SqlQRY & " ALTER TABLE tblERHist ADD Act_D Nvarchar (20) NOT NULL Default ''"
            SqlQRY = SqlQRY & " ALTER TABLE tblERHist ADD ACat_D Nvarchar (20) NOT NULL Default ''"
            SqlQRY = SqlQRY & " ALTER TABLE tblERHist ADD Dept_D Nvarchar (100) NOT NULL Default ''"
            SqlQRY = SqlQRY & " ALTER TABLE tblERHist ADD Br_D Nvarchar (20) NOT NULL Default '' "
            FK_EQ(SqlQRY, "S", "", False, False, True)


            SqlQRY = " UPDATE tblERHist SET Gender_D = CASE WHEN GenderID = '001' THEN 'Male' Else 'Female' END "
            SqlQRY = SqlQRY & " UPDATE tblERHist SET Cat_D = tblSetEmpCategory.CatDesc FROM tblSetEmpCategory,tblERHist WHERE tblSetEmpCategory.CatID = tblERHist.CatID "
            SqlQRY = SqlQRY & " UPDATE tblERHist SET Act_D = CASE WHEN ActID = '002' THEN 'Shop & Office' ELSE 'Wages Board' END "
            SqlQRY = SqlQRY & " UPDATE tblERHist SET Acat_D = CASE WHEN A_CatID = '001' THEN 'Direct' WHEN A_CatID = '002' THEN 'In-Direct' ELSE 'Admin' END "
            SqlQRY = SqlQRY & " UPDATE tblERHist SET tblERHist.Dept_D = tblSetDept.DeptName FROM tblSetDept,tblERHist WHERE tblSetDept.DeptID = tblERHist.DeptID "
            SqlQRY = SqlQRY & " UPDATE tblERHist SET tblERHist.Br_D = tblCbranchs.BrName FROM tblCbranchs,tblERHist WHERE tblCbranchs.BRID = tblERHist.BrID"
            SqlQRY = SqlQRY & " UPDATE tblERHist SET tblERHist.AntStatus = tblEmpRegister.AntStatus,tblERHist.ShiftID = tblEmpRegister.AllShifts FROM tblEmpRegister,tblERHist WHERE tblEmpRegister.EmpID=tblERHist.RegID AND tblEmpRegister.AtDate = tblERHist.RDate"
            FK_EQ(SqlQRY, "S", "", False, False, True)

            SqlQRY = "ALTER TABLE tblERHist ADD W_Age Numeric (18,2) NOT NULL Default 0" : FK_EQ(SqlQRY, "S", "", False, False, True)
            SqlQRY = " UPDATE tblERHist SET W_Age = (DateDiff(Month,CASE WHEN IsOldEmp = 1 THEN O_RegDate else RegDate END,RDate)) "
            FK_EQ(SqlQRY, "S", "", False, False, True)

        Catch ex As Exception
            MsgBox(ex.Message)


        End Try



    End Function

    Public Function fk_GetDateACT_Emps(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As String
        Dim StrRSql As String = ""
        Try
            FK_EQ("if exists (SELECT * FROM sys.objects where name = 'tblERHist')  DROP TABLE tblERHist ;", "D", "", False, False, True)

            StrRSql = "CREATE TABLE tblERHist (RegID Nvarchar (6),RegDate DateTime,EmpStatus Numeric (18,0),IsOldEmp Numeric (18,0),O_RegDate DateTime,GenderID Nvarchar (3),CatID Nvarchar (3),ActID Nvarchar (3),A_CatID Nvarchar (3),DeptID Nvarchar (3),BrID Nvarchar (3),RDate DateTime,ShiftID Nvarchar (3))" : FK_EQ(StrRSql, "S", "", False, False, True)
            StrRSql = "CREATE TABLE #E (RegID Nvarchar (6),RegDate DateTime, EmpStatus Numeric (18,0),StatusDate DateTime,O_Regdate DateTime,IsOLDEmp Numeric (18,0),BrID Nvarchar (3),DeptID Nvarchar (3))"


            '            StrRSql = "CREATE TABLE #E (RegID Nvarchar (6),RegDate DateTime, EmpStatus Numeric (18,0),StatusDate DateTime,O_Regdate DateTime,IsOLDEmp Numeric (18,0),BrID Nvarchar (3),DeptID Nvarchar (3))"
            '            StrRSql = StrRSql & " INSERT INTO #E SELECT RegID,CASE WHEN IsOldEmp = 1 THEN RegDate ELSE O_RegDate END,EmpStatus,StatusDate,O_RegDate,IsOLDEmp,BrID,DeptID FROM tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
            '         "AND (dbo.tblEmployee.RegID LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.DispName LIKE '%" & StrSearchR & "%' OR     " & _
            '         "dbo.tblEmployee.EMPNo LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & StrSearchR & "%' OR    " & _
            '         "dbo.tblEmployee.EPFNo LIKE '%" & StrSearchR & "%') AND  " & _
            '         "(dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
            '         "dbo.tblSetDept.deptName LIKE '" & StrDeptName & "%' AND   " & _
            '            "dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
            '         "dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
            '         " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND   " & _
            '         "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND   " & _
            '"dbo.tblSetShiftH.ShiftName LIKE '" & StrShiftNameR & "%' AND " & _
            '"dbo.tblSetActTypesHRIS LIKE '" & StrActName & "%' ) "

            StrRSql = StrRSql & " DELETE FROM #E"
            StrRSql = StrRSql & " INSERT INTO #E SELECT tblEmployee.RegID,CASE WHEN tblEmployee.IsOldEmp = 1 THEN tblEmployee.RegDate ELSE tblEmployee.O_RegDate END,tblEmployee.EmpStatus,tblEmployee.StatusDate,tblEmployee.O_RegDate,tblEmployee.IsOLDEmp,tblEmployee.BrID,tblEmployee.DeptID FROM dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany,tblsettitle,tblsetemptype,tblSetActTypesHRIS   " & _
            "where   dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
            " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
            " dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
            " dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
            " dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
            " dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
            " dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID AND   " & _
            " tblEmployee.ActType = tblSetActTypesHRIS.ActID AND " & _
            " tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
            " AND (dbo.tblEmployee.RegID LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.DispName LIKE '%" & StrSearchR & "%' OR     " & _
            " dbo.tblEmployee.EMPNo LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & StrSearchR & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & StrSearchR & "%' OR    " & _
            " dbo.tblEmployee.EPFNo LIKE '%" & StrSearchR & "%') AND  " & _
            " (dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
            " dbo.tblSetDept.deptName LIKE '" & StrDeptName & "%' AND   " & _
            " dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
            " dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
            " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND   " & _
            " dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%' AND   " & _
            " dbo.tblSetActTypesHRIS.dscrb LIKE '" & StrActName & "%' ) "

            StrRSql = StrRSql & " delete from #E WHERE EmpStatus =9 AND StatusDate <'" & Format(dtStart, "yyyyMMdd") & "'"
            StrRSql = StrRSql & " update #E SET EmpStatus = 1 where EmpStatus = 9 AND StatusDate >='" & Format(dtStart, "yyyyMMdd") & "'"



            StrRSql = StrRSql & " delete from #E where O_RegDate >'" & Format(dtStart, "yyyyMMdd") & "' AND IsOLDEmp = 1"
            StrRSql = StrRSql & " delete from #E where RegDate >'" & Format(dtStart, "yyyyMMdd") & "' AND IsOLDEmp = 0"

            'StrRSql = StrRSql & " CREATE TABLE tblERHist (RegID Nvarchar (6),RegDate DateTime,EmpStatus Numeric (18,0),IsOldEmp Numeric (18,0),O_RegDate DateTime,GenderID Nvarchar (3),CatID Nvarchar (3),ActID Nvarchar (3),A_CatID Nvarchar (3),DeptID Nvarchar (3),BrID Nvarchar (3),RDate DateTime,ShiftID Nvarchar (3))"
            'StrRSql = StrRSql & " INSERT INTO tblERHist select #E.RegID,#E.RegDate,#E.EmpStatus,#E.IsOldEmp,tblEmployee.O_RegDate,tblEmployee.GenderID,tblEmployee.CatID,tblEmployee.ActID,tblEmployee.A_CatID,tblEmployee.DeptID,tblEmployee.BrID, '" & Format(dtStart, "yyyyMMdd") & "','' From #E,tblEmployee where tblEmployee.RegID = #E.RegID AND #E.EmpStatus <> 9 order By #E.RegDate"
            StrRSql = StrRSql & " INSERT INTO tblERHist select #E.RegID,#E.RegDate,#E.EmpStatus,#E.IsOldEmp,tblEmployee.O_RegDate,tblEmployee.GenderID,tblEmployee.CatID,tblEmployee.ActType,tblEmployee.SubCatID,tblEmployee.DeptID,tblEmployee.BrID, '" & Format(dtStart, "yyyyMMdd") & "','' From #E,tblEmployee where tblEmployee.RegID = #E.RegID AND #E.EmpStatus <> 9 order By #E.RegDate"
            FK_EQ(StrRSql, "S", "", False, False, True)

            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD AntStatus Numeric (18,0) NOT NULL Default 0"
            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Gender_D Nvarchar (20) NOT NULL Default ''"
            'StrRSql = StrRSql & " UPDATE tblERHist SET Gender_D = CASE WHEN GenderID = '001' THEN 'Male' Else 'Female' END "
            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Cat_D Nvarchar (20) NOT NULL Default ''"
            'StrRSql = StrRSql & " UPDATE tblERHist SET Cat_D = tblSetEmpCategory.CatDesc FROM tblSetEmpCategory,tblERHist WHERE tblSetEmpCategory.CatID = tblERHist.CatID "
            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Act_D Nvarchar (20) NOT NULL Default ''"
            'StrRSql = StrRSql & " UPDATE tblERHist SET Act_D = CASE WHEN ActID = '002' THEN 'Shop & Office' ELSE 'Wages Board' END "
            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD ACat_D Nvarchar (20) NOT NULL Default ''"
            'StrRSql = StrRSql & " UPDATE tblERHist SET Acat_D = CASE WHEN A_CatID = '001' THEN 'Direct' WHEN A_CatID = '002' THEN 'In-Direct' ELSE 'Admin' END "
            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Dept_D Nvarchar (100) NOT NULL Default ''"
            'StrRSql = StrRSql & " UPDATE tblERHist SET tblERHist.Dept_D = tblSetDept.DeptName FROM tblSetDept,tblERHist WHERE tblSetDept.DeptID = tblERHist.DeptID "
            'StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Br_D Nvarchar (20) NOT NULL Default '' "
            'StrRSql = StrRSql & " UPDATE tblERHist SET tblERHist.Br_D = tblCbranchs.BrName FROM tblCbranchs,tblERHist WHERE tblCbranchs.BRID = tblERHist.BrID"

            'StrRSql = StrRSql & " UPDATE tblERHist SET tblERHist.AntStatus = tblEmpRegister.AntStatus,tblERHist.ShiftID = tblEmpRegister.AllShifts FROM tblEmpRegister,tblERHist WHERE tblEmpRegister.EmpID=tblERHist.RegID AND tblEmpRegister.AtDate = tblERHist.RDate"

            StrRSql = " ALTER TABLE tblERHist ADD AntStatus Numeric (18,0) NOT NULL Default 0"
            StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Gender_D Nvarchar (20) NOT NULL Default ''"
            StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Cat_D Nvarchar (20) NOT NULL Default ''"
            StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Act_D Nvarchar (20) NOT NULL Default ''"
            StrRSql = StrRSql & " ALTER TABLE tblERHist ADD ACat_D Nvarchar (20) NOT NULL Default ''"
            StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Dept_D Nvarchar (100) NOT NULL Default ''"
            StrRSql = StrRSql & " ALTER TABLE tblERHist ADD Br_D Nvarchar (20) NOT NULL Default '' "
            FK_EQ(StrRSql, "S", "", False, False, True)


            StrRSql = " UPDATE tblERHist SET Gender_D = CASE WHEN GenderID = '001' THEN 'Male' Else 'Female' END "
            StrRSql = StrRSql & " UPDATE tblERHist SET Cat_D = tblSetEmpCategory.CatDesc FROM tblSetEmpCategory,tblERHist WHERE tblSetEmpCategory.CatID = tblERHist.CatID "
            StrRSql = StrRSql & " UPDATE tblERHist SET Act_D = CASE WHEN ActID = '002' THEN 'Shop & Office' ELSE 'Wages Board' END "
            StrRSql = StrRSql & " UPDATE tblERHist SET Acat_D = CASE WHEN A_CatID = '001' THEN 'Direct' WHEN A_CatID = '002' THEN 'In-Direct' ELSE 'Admin' END "
            StrRSql = StrRSql & " UPDATE tblERHist SET tblERHist.Dept_D = tblSetDept.DeptName FROM tblSetDept,tblERHist WHERE tblSetDept.DeptID = tblERHist.DeptID "
            StrRSql = StrRSql & " UPDATE tblERHist SET tblERHist.Br_D = tblCbranchs.BrName FROM tblCbranchs,tblERHist WHERE tblCbranchs.BRID = tblERHist.BrID"
            StrRSql = StrRSql & " UPDATE tblERHist SET tblERHist.AntStatus = tblEmpRegister.AntStatus,tblERHist.ShiftID = tblEmpRegister.AllShifts FROM tblEmpRegister,tblERHist WHERE tblEmpRegister.EmpID=tblERHist.RegID AND tblEmpRegister.AtDate = tblERHist.RDate"


            FK_EQ(StrRSql, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Return StrRSql

    End Function

    Public Function fk_HistoryReportHR(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, ByVal StrShiftNameR As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As Boolean
        Dim bolReturn As Boolean = False
        Dim sqlQRY As String = ""
        Try
            FK_EQ("if Exists (SELECT * FROM sys.objects where Name = 'RENDER') DROP TABLE RENDER", "S", "", False, False, True)
            sqlQRY = fk_GetDateACT_EmpsDTRange(StrSearchR, StrDesigName, StrDeptName, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtStart, DtEnd)


            sqlQRY = sqlQRY & " CREATE TABLE RENDER (EmpID Nvarchar (6),TrMode Nvarchar (3),TRNS Nvarchar (1000)) "
            sqlQRY = sqlQRY & "  INSERT INTO RENDER SELECT " & _
            " SS.EmpID,SS.TrMode ," & _
            " (SELECT   Convert(Nvarchar (10),US.TrSetDate,111) + '  |  ' + US.OldExsist + ';'  " & _
            " FROM tblCodeTrHist US " & _
            " WHERE(US.EmpID = SS.EmpID And US.TrMode = SS.TrMode)" & _
            " FOR XML PATH('')) TRNS " & _
            " FROM   tblCodeTrHist SS " & _
            " GROUP BY SS.EmpID, SS.TrMode " & _
            " ORDER BY 1"

            sqlQRY = sqlQRY & " UPDATE RENDER SET TRNS = Replace(TRNS,';',Char(13))"
            sqlQRY = sqlQRY & "DELETE FROM RENDER WHERE EmpID Not In (SELECT RegID FROM tblERHist)"
            FK_EQ(sqlQRY, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        Return bolReturn
    End Function

    Public Function fk_HeadCountR1(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As Boolean
        Dim bolReturn As Boolean = False
        Dim sqlQRY As String = ""
        Try
            sqlQRY = fk_GetDateACT_Emps(StrSearchR, StrDesigName, StrDeptName, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtStart, DtEnd)
            sqlQRY = sqlQRY & " DROP TABLE tblHC1_R"
            sqlQRY = sqlQRY & " DROP TABLE tblORC"
            sqlQRY = sqlQRY & " SELECT DeptID,Dept_Total = Sum(AntStatus) INTO #M  FROM tblERHist GROUP BY DeptID"
            sqlQRY = sqlQRY & " CREATE TABLE tblHC1_R (DeptID Nvarchar (3),DeptName Nvarchar (100),Dept_Total Numeric (18,0),cDate DateTime)"
            sqlQRY = sqlQRY & " INSERT INTO tblHC1_R SELECT DeptID,DeptName ,0,'" & Format(dtStart, "yyyyMMdd") & "' FROM tblSetDept"
            sqlQRY = sqlQRY & " UPDATE tblHC1_R SET tblHC1_R.Dept_Total = #M.Dept_Total FROM #M,tblHC1_R WHERE #M.DeptID = tblHC1_R.DeptID"
            sqlQRY = sqlQRY & " CREATE TABLE tblORC (DeptID Nvarchar (3),ActID Nvarchar (3),CatID nvarchar (3),OtherID Nvarchar (5),LevelVal Numeric (18,0),fld_Name Nvarchar (20),RValue Numeric (18,0),Link Numeric (18,0))"

            'Load Departments to Grid 
            Dim dgv As New DataGridView
            Dim StrDPT As String = "" 'Department ID while running loop
            With dgv
                .Columns.Add("DeptID", "DepartID")
                .Columns.Add("DeptName", "DepartName")
            End With
            Load_InformationtoGrid("SELECT DeptID,DeptName FROM tblSetDept WHERE Status = 0 Order By DeptID", dgv, 2)
            With dgv
                For i As Integer = 0 To .RowCount - 2
                    StrDPT = .Item(0, i).Value
                    sqlQRY = sqlQRY & " INSERT INTO tblORC SELECT '" & StrDPT & "',ActID,CatID,OtherID,levelVal,fld_Name,0,Link FROM tblRHCFormat "

                Next
            End With

            sqlQRY = sqlQRY & " SELECT DeptID,ActID,CatID,GenderID,Total = Sum(AntStatus),LevelID = 1 INTO #GSum FROM tblERHist GROUP BY DeptID,ActID,CatID,GenderID"
            sqlQRY = sqlQRY & " INSERT INTO #GSum SELECT DeptID,ActID,CatID,A_CatID,Total = Sum(AntStatus),LevelID = 2  FROM tblERHist GROUP BY DeptID,ActID,CatID,A_CatID "
            sqlQRY = sqlQRY & " UPDATE tblORC SET tblORC.RValue = #GSum.Total FROM #GSum,tblORC WHERE #GSum.DeptID = tblORC.DeptID AND #GSum.ActID = tblORC.ActID AND #GSum.CatID = tblORC.CatID AND #GSum.GenderID = tblORC.OtherID AND #GSum.LevelID = tblORC.LevelVal "
            sqlQRY = sqlQRY & " UPDATE tblORC SET OtherID = LTrim(LevelVal) + LTrim(OtherID) "

            bolReturn = FK_EQ(sqlQRY, "S", "", False, False, True)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    '-- Absentism Reports
    'Department wise absent analysis
    Public Function fk_DeptAgeAnalisys(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As Boolean
        Dim bolReturn As Boolean = False
        Dim sqlQRY As String = ""
        Try
            'DROP TABLE 
            FK_EQ("if Exists (SELECT * FROM sys.objects where Name = 'tblAgeHC') DROP TABLE tblAgeHC", "S", "", False, False, True)

            sqlQRY = fk_GetDateACT_EmpsDTRange(StrSearchR, StrDesigName, StrDeptName, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtStart, DtEnd)

            sqlQRY = sqlQRY & " CREATE TABLE tblAgeHC (DeptID Nvarchar (3),AbsentP Numeric (18,2),TotalHC Numeric (18,2),TotAB Numeric (18,2),ComHC Numeric (18,2),ComAB Numeric (18,2))"
            sqlQRY = sqlQRY & " INSERT INTO tblAgeHC SELECT DeptID,ABP=0.00,TotHC=Count(AntStatus),TotAB = Sum(Case WHEN AntStatus = 0 THEN 1 ELSE 0 END),ComHC = 0,0  FROM tblERHist GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET ComHC = (SELECT Count(AntStatus) FROM tblERHist)"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET ComAB = (SELECT Count(AntStatus) FROM tblERHist WHERE AntStatus = 0)"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET AbsentP = (TotAB/TotalHC)*100"

            sqlQRY = sqlQRY & "  ALTER TABLE tblAgeHC ADD AgeCat1 Numeric (18,2) NOT NULL Default 0"
            sqlQRY = sqlQRY & " ALTER TABLE tblAgeHC ADD AgeCat2 Numeric (18,2) NOT NULL Default 0"
            sqlQRY = sqlQRY & " ALTER TABLE tblAgeHC ADD AgeCat3 Numeric (18,2) NOT NULL Default 0"
            sqlQRY = sqlQRY & " ALTER TABLE tblAgeHC ADD AgeCat4 Numeric (18,2) NOT NULL Default 0"
            sqlQRY = sqlQRY & " ALTER TABLE tblAgeHC ADD AgeCat5 Numeric (18,2) NOT NULL Default 0"
            sqlQRY = sqlQRY & " ALTER TABLE tblAgeHC ADD AgeCat6 Numeric (18,2) NOT NULL Default 0"

            sqlQRY = sqlQRY & " CREATE TABLE #N (RegID Nvarchar (6),DeptID Nvarchar (3),AntStatus Numeric (18,0),IsOldEmp Numeric (18,2),O_Reg DateTime, Reg DateTime, RDate DateTime, AgeMonth Numeric (18,2),AgeYear Numeric (18,2),BalMonth Numeric (18,2),AgeCat Numeric (18,0))"
            sqlQRY = sqlQRY & " INSERT INTO #N select RegID,DeptID,AntStatus,IsOldEmp,O_RegDate,RegDate,RDate,AgeMonths = Round((DateDiff(Month,CASE WHEN IsOldEmp = 1 THEN O_RegDate else RegDate END,RDate))/12,2),AgeYears =(DateDiff(Month,CASE WHEN IsOldEmp = 1 THEN O_RegDate else RegDate END,RDate)-DateDiff(Month,CASE WHEN IsOldEmp = 1 THEN O_RegDate else RegDate END,RDate)%12)/12,BalMonth = DateDiff(Month,CASE WHEN IsOldEmp = 1 THEN O_RegDate else RegDate END,RDate)%12,0 From tblERHist"

            sqlQRY = sqlQRY & " UPDATE #N SET AgeCat = CASE WHEN AgeYear = 0 THEN CASE WHEN BalMonth < = 6 THEN 0 ELSE 1 END ELSE CASE WHEN AgeYear <=1 THEN 1 WHEN AgeYear <=2 THEN 2 WHEN AgeYear <=5 THEN 3 WHEN AgeYear <=10 THEN 4 ELSE 5 END END from #N"

            sqlQRY = sqlQRY & " SELECT DeptID,Total=Count(AntStatus) INTO #Cat0 FROM #N WHERE AgeCat = 0 GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AgeCat1 = #Cat0.Total FROM #Cat0,tblAgeHC WHERE #Cat0.DeptID = tblAgeHC.DeptID"

            sqlQRY = sqlQRY & " SELECT DeptID,Total=Count(AntStatus) INTO #Cat1 FROM #N WHERE AgeCat = 1 GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AgeCat2 = #Cat1.Total FROM #Cat1,tblAgeHC WHERE #Cat1.DeptID = tblAgeHC.DeptID"

            sqlQRY = sqlQRY & " SELECT DeptID,Total=Count(AntStatus) INTO #Cat2 FROM #N WHERE AgeCat = 2 GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AgeCat3 = #Cat2.Total FROM #Cat2,tblAgeHC WHERE #Cat2.DeptID = tblAgeHC.DeptID"

            sqlQRY = sqlQRY & " SELECT DeptID,Total=Count(AntStatus) INTO #Cat3 FROM #N WHERE AgeCat = 3 GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AgeCat4 = #Cat3.Total FROM #Cat3,tblAgeHC WHERE #Cat3.DeptID = tblAgeHC.DeptID"

            sqlQRY = sqlQRY & " SELECT DeptID,Total=Count(AntStatus) INTO #Cat4 FROM #N WHERE AgeCat = 4 GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AgeCat5 = #Cat4.Total FROM #Cat4,tblAgeHC WHERE #Cat4.DeptID = tblAgeHC.DeptID"

            sqlQRY = sqlQRY & " SELECT DeptID,Total=Count(AntStatus) INTO #Cat5 FROM #N WHERE AgeCat = 5 GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AgeCat6 = #Cat5.Total FROM #Cat5,tblAgeHC WHERE #Cat5.DeptID = tblAgeHC.DeptID"

            FK_EQ(sqlQRY, "S", "", False, False, True)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function


    Public Function fk_DeptNCityAnalysis(ByVal StrSearchR As String, ByVal StrDesigName As String, _
                                               ByVal StrDeptName As String, ByVal StrTitle As String, ByVal StrType As String, _
                                               ByVal StrSubCatName As String, ByVal StrBranchName As String, _
                                               ByVal StrActName As String, ByVal dtStart As Date, ByVal DtEnd As Date) As Boolean
        Dim bolReturn As Boolean = False
        Dim sqlQRY As String = ""
        FK_EQ("if Exists (SELECT * FROM sys.objects where Name = 'tblAgeHC') DROP TABLE tblAgeHC", "S", "", False, False, True)
        sqlQRY = " CREATE TABLE tblAgeHC (DeptID Nvarchar (3),AbsentP Numeric (18,2),TotalHC Numeric (18,2),TotAB Numeric (18,2),ComHC Numeric (18,2),ComAB Numeric (18,2),CityID Nvarchar (3),CityValue Numeric (18,2))" : FK_EQ(sqlQRY, "S", "", False, False, True)
        Try
            'DROP TABLE 


            sqlQRY = fk_GetDateACT_EmpsDTRange(StrSearchR, StrDesigName, StrDeptName, StrTitle, StrType, StrSubCatName, StrBranchName, StrActName, dtStart, DtEnd)


            sqlQRY = " INSERT INTO tblAgeHC SELECT DeptID,ABP=0.00,TotHC=0,TotAB = 0,ComHC = 0,0,NCityID,Sum(CASE WHEN AntStatus = 1 THEN 0 ELSE 1 END)  FROM tblERHist  GROUP By DeptID,NCityID" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = ""
            'sqlQRY = sqlQRY & " UPDATE tblAgeHC SET ComHC = (SELECT Count(AntStatus) FROM tblERHist )"
            'sqlQRY = sqlQRY & " UPDATE tblAgeHC SET TotalHC = (SELECT Count(AntStatus) FROM tblERHist )"
            'sqlQRY = sqlQRY & " UPDATE tblAgeHC SET TotAB = (SELECT Sum(Case WHEN AntStatus = 0 THEN 1 ELSE 0 END) FROM tblERHist)"
            'sqlQRY = sqlQRY & " UPDATE tblAgeHC SET ComAB = (SELECT Count(AntStatus) FROM tblERHist WHERE AntStatus = 0 )"
            sqlQRY = sqlQRY & " CREATE TABLE #TM (DeptID Nvarchar (3),AbsentP Numeric (18,2),TotalHC Numeric (18,2),TotAB Numeric (18,2),ComHC Numeric (18,2),ComAB Numeric (18,2))"
            sqlQRY = sqlQRY & " INSERT INTO #TM SELECT DeptID,AbsentP=Convert(Numeric (18,2),0),TotalHC=Count(AntStatus),TotAB = Sum(Case WHEN AntStatus = 0 THEN 1 ELSE 0 END),ComHC = 0,ComAB =0 FROM tblERHist GROUP By DeptID"
            sqlQRY = sqlQRY & " UPDATE #TM SET ComHC = (SELECT Count(AntStatus) FROM tblERHist)"
            sqlQRY = sqlQRY & " UPDATE #TM SET ComAB = (SELECT Count(AntStatus) FROM tblERHist WHERE AntStatus = 0)"
            sqlQRY = sqlQRY & "UPDATE #TM SET AbsentP = Round((TotAB/TotalHC)*100,2)"
            sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC.AbsentP = #TM.AbsentP,tblAgeHC.TotalHC = #TM.TotalHC, " & _
            " tblAgeHC.TotAB = #TM.TotAB, " & _
            " tblAgeHC.ComHC = #TM.ComHC, " & _
            " tblAgeHC.ComAB = #TM.ComAB " & _
            " FROM #TM,tblAgeHC WHERE #TM.DeptID = tblAgeHC.DeptID"



            ' ''Dim dgv As New DataGridView
            ' ''With dgv
            ' ''    .Columns.Add("NCityID", "New City ID")
            ' ''    .Columns.Add("CityName", "City Name")
            ' ''    .Columns.Add("ColName", "Column Name")

            ' ''End With
            ' ''Dim sqlQ As String = "SELECT CityID,Dscrb,'C_'+LTrim(CityID)  FROM tblSetNearsCitysHRIS WHERE Status = 0 Order By CityID"
            ' ''Load_InformationtoGrid(sqlQ, dgv, 3)
            ' ''Dim StrRCityID As String = "" : Dim StrRColName As String = "" : Dim StrTTable As String = ""
            ' ''With dgv
            ' ''    For i As Integer = 0 To .RowCount - 2
            ' ''        StrRCityID = .Item(0, i).Value
            ' ''        'StrRColName = "[" + .Item(1, i).Value + "]"
            ' ''        'StrTTable = "#tbl" & Trim(.Item(2, i).Value)



            ' ''        'sqlQRY = sqlQRY & " ALTER TABLE tblAgeHC ADD " & StrRColName & " Numeric (18,2) NOT NULL Default 0"
            ' ''        'sqlQRY = sqlQRY & "CREATE TABLE " & StrTTable & " (DeptID Nvarchar(3),NoVal Numeric (18,2))"
            ' ''        'sqlQRY = sqlQRY & " INSERT INTO " & StrTTable & " SELECT DeptID,Sum(AntStatus) FROM tblERHist WHERE NCityID = '" & StrRCityID & "' GROUP By DeptID"
            ' ''        'sqlQRY = sqlQRY & " UPDATE tblAgeHC SET tblAgeHC." & StrRColName & " = " & StrTTable & ".NoVal FROM " & StrTTable & ",tblAgeHC WHERE tblAgeHC.DeptID = " & StrTTable & ".DeptID"

            ' ''    Next
            ' ''End With

            FK_EQ(sqlQRY, "S", "", False, False, True)

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Function


End Module
