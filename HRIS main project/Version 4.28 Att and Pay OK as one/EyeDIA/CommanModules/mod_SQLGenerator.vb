Module mod_SQLGenerator

    Public Function _CreateTableStructure() As String
        Dim StrRVal As String = ""
        Dim sqlQRY As String = ""
        Try
            sqlQRY = "CREATE TABLE tblTableList (TableID Nvarchar (3),T_Name Nvarchar (100),T_Desc Nvarchar (200),F_Key Nvarchar (70),NoFlds Numeric (18,0),IsLinked Numeric (18,0),LinkFld Nvarchar (100),r_Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = " CREATE TABLE tblTableFeildList (TableID Nvarchar (3),Fld_ID Nvarchar (5),Fld_Name Nvarchar (60),fld_FullName Nvarchar (100),Fld_Desc Nvarchar (100),r_Status Numeric (18,0)) " : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = " CREATE TABLE tblTableLink (LinkID Nvarchar (3),M_TableID Nvarchar (3),M_FldID Nvarchar (5),S_TableID Nvarchar (3),S_FldID Nvarchar (5),r_Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)

            sqlQRY = " ALTER TABLE tblControl ADD NoSQLGenTbl Numeric (18,0) NOT NULL DEFAULT 0 " : FK_EQ(sqlQRY, "S", "", False, False, False)

            sqlQRY = "CREATE TABLE tblQryReportList (RepID nvarchar (3),RepName Nvarchar (100),RepFields Nvarchar (Max),RepFldIds Nvarchar (Max),r_Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = "ALTER TABLE tblControl ADD NoSQLRepNos Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)




        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return StrRVal
    End Function
End Module
