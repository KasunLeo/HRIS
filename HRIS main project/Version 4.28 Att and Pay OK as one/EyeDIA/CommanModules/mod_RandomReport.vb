Module mod_RandomReport

    Public Sub Create_RandomTable()
        '######## NEW MODIFICATION##############
        'Modified Date  : 23/March/2015
        'Modifeid By    : Kasun
        'Scope          : Generate table for Random Report Generate
        sSQL = "CREATE TABLE tblRandomReport (RegID Nvarchar (6),EmpID Nvarchar (6),EmpName Nvarchar (100),GrpID_1 Nvarchar (3),GrpDesc_1 Nvarchar (100),GrpID_2 Nvarchar (3),GrpDesc_2 Nvarchar (100)" : FK_EQ(sSQL, "S", "", False, False, False)
        Dim fldName As String = "Num"
        For i As Integer = 1 To 15
            Dim s As String = fldName & i
            sSQL = "ALTER TABLE tblRandomReport " & fldName & " Numeric (18,2) NOT NULL Default 0" : FK_EQ(sSQL, "S", "", False, False, False)
        Next
    End Sub

    Public Sub Generate_RandomValues(ByVal sReportID As String, ByVal stDate As Date, ByVal edDate As Date, ByVal cMonth As Integer, ByVal cYear As Integer)
        Dim sqlQRY As String = ""
        Dim isEpf As Integer = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        Dim sqlTag As String : If isEpf = 0 Then sqlTag = "tblEmployee.RegID" Else If isEpf = 1 Then sqlTag = "tblEmployee.EpfNo" Else If isEpf = 2 Then sqlTag = "tblEmployee.EnrolNo" Else sqlTag = "tblEmployee.EmpNo"

        Dim StrDefaultQRY As String = "SELECT tblEmployee.RegID," & sqlTag & ",tblEmployee.DispName, "
        Select Case sReportID
            Case "001" ' Summary Qry for the 
                StrDefaultQRY = StrDefaultQRY & " tblSetDept.DeptName,tblEmployee.BrID,tblCBranchs.BrName"
        End Select
    End Sub

End Module
