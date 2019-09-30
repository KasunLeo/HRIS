Imports System.Data.SqlClient

Public Class frmPayAdditemstoEmployee

    Private Sub frmAdditemstoEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label12)
        ControlHandlers(Me)
        RefreshForm()
    End Sub

    Private Sub RefreshForm()

        Dim Str As String = "SELECT DISTINCT dbo.tblSalaryItems.Description FROM         dbo.tblAttendenceFormula left JOIN    dbo.tblSalaryItems ON dbo.tblAttendenceFormula.SalaryItem = dbo.tblSalaryItems.ID where tblAttendenceFormula.status='0'"
        ' Call fk_comboItems(Str, cboSalaryItems)
        Str = "SELECT DISTINCT dbo.tblSalaryItems.Description+'='+cast(tblSalaryItems.ID as varchar) FROM         dbo.tblFixedField left JOIN                       dbo.tblSalaryItems ON dbo.tblFixedField.SalaryItem = dbo.tblSalaryItems.ID where tblFixedField.status='0'"
        Call fk_comboItems(Str, cboSalaryItemF)
        Str = "SELECT DISTINCT dbo.tblSalaryItems.Description+'='+cast(tblSalaryItems.ID as varchar) FROM         dbo.tblSalaryItems left JOIN                      dbo.tblFormula ON dbo.tblSalaryItems.ID = dbo.tblFormula.SalaryField        where tblFormula.status='0'"
        Call fk_comboItems(Str, cboSalaryItemFor)
        Str = "Select 'false',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName,tblPayrollEmployee.PrCatID,tblcBranchs.BrName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblcbranchs on tblcbranchs.BrID=tblPayrollEmployee.BrID where tblPayrollEmployee.status='0' order by regID asc  "
        Load_InformationtoGrid(Str, grdData, 8)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
        FillCom2(cmbSalaryScale, "Select scName+'='+scID from tblSalaryScale where Status='0'")
        fk_comboItems("Select DeptName+'='+DeptID from tblSetDept where status='0' order by DeptName asc", cmbDept)
        fk_comboItems("Select desgdesc+'='+DesgID from tblDesig where Status=0 order by desgdesc asc", cboDesignation)
        sSQL = "Select Description + '=' + cast(ID as varchar(5)) from tblProfileH where Status='0'  order by Description asc"
        FillCom2(cmbProfiles, sSQL)
        sSQL = "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status='0' and ID in (Select distinct SalID from tblNewAttFormula) order by Description asc;"
        FillCom2(cmbSalItems, sSQL)
        sSQL = "Select CatDesc+'='+CatID  from tblemp_subcategory"
        FillCom2(cmbSubCategory, sSQL)
        sSQL = ""
        FillCom2(cmbProcessCategory, "select CatDesc+'='+CatID from tblSetPrCategory  where status=0")

        'FillCom2(cmbProcessCategory, sSQL)


    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

   

    Private Sub cboProfileName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtProfile.Text = ""
        'txtProfile.Text = GetString("Select ID from tblProfileH where Description='" & cboProfileName.Text & "'")
        'Load Grid
        For I = 0 To grdData.RowCount - 1
            grdData.Rows(I).Cells(0).Value = False
        Next
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim Sql As String
            Sql = "Select * from tblEmployeeAttendenceItems where AttendenceItem='" & txtSalaryItem.Text & "' and Profile='" & txtProfile.Text & "' order by EmpID asc"
            'Sql = "Select dbo.tblEmployeeFormulaField.EmpID FROM         dbo.tblEmployeeFormulaField left JOIN                       dbo.tblFormula ON dbo.tblEmployeeFormulaField.ID = dbo.tblFormula.ID WHERE     (dbo.tblFormula.SalaryField = '" & txtSalaryItem.Text & "') AND (dbo.tblFormula.Profile ='" & txtProfile.Text & "') "
            'Sql = "SELECT     dbo.tblEmployeeFixedField.EmpID FROM         dbo.tblFixedField left JOIN                       dbo.tblEmployeeFixedField ON dbo.tblFixedField.ID = dbo.tblEmployeeFixedField.ID WHERE     (dbo.tblFixedField.SalaryItem =" & txtsalIDf.Text & ") AND (dbo.tblFixedField.Profile = " & txtProfileIDF.Text & ") "
            'Dim sqlQryCmb = "Select * from tblEmployeeFixedField where attendenceitem='" & txtSalartItem.Text & "' and profile='" & txtProfile.Text & "'"
            Dim sqlcombo_department As New SqlCommand(Sql, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            While redcombo_department.Read()
                For I = 0 To grdData.RowCount - 1
                    If Not grdData.Rows(I).Cells(0).Value = True Then
                        If redcombo_department.Item(0) = grdData.Rows(I).Cells(1).Value Then
                            grdData.Rows(I).Cells(0).Value = True
                            Exit For
                        End If
                    End If
                Next
            End While
            redcombo_department.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cboSalaryItemF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalaryItemF.SelectedIndexChanged
        cboProfileF.Text = ""
        '==========================Rajitha 2nd run
        Button8_Click(sender, e)

        '================
        txtsalIDf.Text = FK_GetIDR(cboSalaryItemF.Text)
        ' txtsalIDf.Text = GetString("Select ID from tblSalaryitems where Description='" & cboSalaryItemF.Text & "'")
        Dim Str As String = "        SELECT DISTINCT dbo.tblProfileH.Description+'='+cast(tblProfileH.ID as varchar), dbo.tblFixedField.SalaryItem FROM         dbo.tblProfileH left JOIN                       dbo.tblFixedField ON dbo.tblProfileH.ID = dbo.tblFixedField.Profile WHERE     (dbo.tblFixedField.SalaryItem = '" & txtsalIDf.Text & "') "
        Call fk_comboItems(Str, cboProfileF)
        rbAll.Checked = False
        rbNone.Checked = True

    End Sub

    Private Sub cboProfileF_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProfileF.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtProfileIDF.Text = FK_GetIDR(cboProfileF.Text)
        txtsalIDf.Text = FK_GetIDR(cboSalaryItemF.Text)
        'txtProfileIDF.Text = GetString("Select ID from tblProfileH where Description='" & cboProfileF.Text & "'")
        For I = 0 To grdData.RowCount - 1
            grdData.Rows(I).Cells(0).Value = False
        Next
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim Sql As String
            Sql = "Select EmpID,tblFixedField.SalaryItem,tblFixedField.Profile from tblEmployeeFixedField left join tblFixedField on tblFixedField.ID=tblEmployeeFixedField.ID where SalaryItem='" & txtsalIDf.Text & "' and Profile='" & txtProfileIDF.Text & "'"
            'Sql = "Select dbo.tblEmployeeFormulaField.EmpID FROM         dbo.tblEmployeeFormulaField left JOIN                       dbo.tblFormula ON dbo.tblEmployeeFormulaField.ID = dbo.tblFormula.ID WHERE     (dbo.tblFormula.SalaryField = '" & txtSalaryItem.Text & "') AND (dbo.tblFormula.Profile ='" & txtProfile.Text & "') "
            'Sql = "SELECT     dbo.tblEmployeeFixedField.EmpID FROM         dbo.tblFixedField left JOIN                       dbo.tblEmployeeFixedField ON dbo.tblFixedField.ID = dbo.tblEmployeeFixedField.ID WHERE     (dbo.tblFixedField.SalaryItem =" & txtsalIDf.Text & ") AND (dbo.tblFixedField.Profile = " & txtProfileIDF.Text & ") "
            'Dim sqlQryCmb = "Select * from tblEmployeeFixedField where attendenceitem='" & txtSalartItem.Text & "' and profile='" & txtProfile.Text & "'"
            Dim sqlcombo_department As New SqlCommand(Sql, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            While redcombo_department.Read()
                For I = 0 To grdData.RowCount - 1
                    If grdData.Rows(I).Cells(0).Value = False Then
                        If redcombo_department.Item(0) = grdData.Rows(I).Cells(1).Value Then
                            grdData.Rows(I).Cells(0).Value = True
                            Exit For
                            'Aruna'
                        End If
                    End If
                Next
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboSalaryItemFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSalaryItemFor.SelectedIndexChanged
        txtSalIDFor.Text = FK_GetIDR(cboSalaryItemFor.Text) 'GetString("Select ID from tblSalaryitems where Description='" & cboSalaryItemFor.Text & "' and status='0'")
        Dim Str As String = "SELECT DISTINCT dbo.tblProfileH.Description+'='+cast(tblProfileH.ID as varchar) FROM         dbo.tblFormula left JOIN                       dbo.tblProfileH ON dbo.tblFormula.Profile = dbo.tblProfileH.ID WHERE     (dbo.tblFormula.SalaryField = '" & txtSalIDFor.Text & "' and tblFormula.Status='0')"
        Call fk_comboItems(Str, cboFormulaFor)
        rbAll.Checked = False
        rbNone.Checked = True
    End Sub

    Private Sub cboFormulaFor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFormulaFor.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        txtProfileIDfor.Text = ""
        txtProfileIDfor.Text = FK_GetIDR(cboFormulaFor.Text) 'GetString("Select ID from tblProfileH where Description='" & cboFormulaFor.Text & "'")

        For I = 0 To grdData.RowCount - 1
            grdData.Rows(I).Cells(0).Value = False
        Next
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim Sql As String
            Sql = "Select EmpID from tblEmployeeFormulaField left join tblFormula on tblFormula.ID=tblEmployeeFormulaField.ID where SalaryField='" & txtSalIDFor.Text & "' and Profile='" & txtProfileIDfor.Text & "' order by empID asc"
            Dim sqlcombo_department As New SqlCommand(Sql, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            While redcombo_department.Read()
                For I = 0 To grdData.RowCount - 1
                    If grdData.Rows(I).Cells(0).Value = False Then
                        If redcombo_department.Item(0) = grdData.Rows(I).Cells(1).Value Then
                            grdData.Rows(I).Cells(0).Value = True
                            Exit For
                            'Aruna'
                        End If
                    End If
                Next
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If UP("Employee wise Fields Add.Remove", "Attendence Fields") = False Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        If txtSalaryItem.Text = "" Or txtProfile.Text = "" Then MsgBox("Please Select Salary Items and Profile First", MsgBoxStyle.Critical) : Exit Sub

        If MsgBox("Are you sure you want to Save this Record? ..... ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""

        For I = 0 To grdData.RowCount - 1
            Dim strQRY As String = "Delete from tblEmployeeAttendenceItems where EmpID='" & grdData.Rows(I).Cells(1).Value & "' and AttendenceItem='" & txtSalaryItem.Text & "' and profile='" & txtProfile.Text & "'"
            cmSave.CommandText = strQRY
            cmSave.ExecuteNonQuery()
            If grdData.Rows(I).Cells(0).Value = True Then
                'MsgBox(grdData.Rows(I).Cells(2).Value)
                strQRY = "Insert into tblEmployeeAttendenceItems (EMPID,AttendenceItem,Profile) values ('" & grdData.Rows(I).Cells(1).Value & "','" & txtSalaryItem.Text & "','" & txtProfile.Text & "')"
                cmSave.CommandText = strQRY
                cmSave.ExecuteNonQuery()
            End If
            wait(10)
        Next

        trSave.Commit()
        cnSave.Close()
        Cursor.Current = Cursors.Default
        MsgBox("Data Saved Successfully", MsgBoxStyle.Information)
        txtProfile.Text = ""
        txtSalaryItem.Text = ""
        'cboSalaryItems.Text = ""
        ' cboProfileName.Text = ""
        Dim Str As String = "SELECT DISTINCT dbo.tblSalaryItems.Description FROM         dbo.tblAttendenceFormula left JOIN    dbo.tblSalaryItems ON dbo.tblAttendenceFormula.SalaryItem = dbo.tblSalaryItems.ID"
        ' Call fk_comboItems(Str, cboSalaryItems)
        Str = "SELECT DISTINCT dbo.tblSalaryItems.Description FROM         dbo.tblFixedField left JOIN                       dbo.tblSalaryItems ON dbo.tblFixedField.SalaryItem = dbo.tblSalaryItems.ID"
        Call fk_comboItems(Str, cboSalaryItemF)
        Str = "SELECT DISTINCT dbo.tblSalaryItems.Description FROM         dbo.tblSalaryItems left JOIN                      dbo.tblFormula ON dbo.tblSalaryItems.ID = dbo.tblFormula.SalaryField        "
        Call fk_comboItems(Str, cboSalaryItemFor)
        '==========================Rajitha 2nd run
        Button8_Click(sender, e)

        '================
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim bSelected As Boolean = False
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Or Val(grdData.Item(0, X).Value) = 1 Then
                bSelected = True : Exit For
            End If
        Next
        If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub

        If UP("Employee wise Fields Add.Remove", "Fixed Fields") = False Then Exit Sub
        txtsalIDf.Text = FK_GetIDR(cboSalaryItemF.Text)
        txtProfileIDF.Text = FK_GetIDR(cboProfileF.Text)
        If txtsalIDf.Text = "" Then MsgBox("Invalid Salary Item", MsgBoxStyle.Critical) : cboSalaryItemFor.Focus() : Exit Sub
        If txtProfileIDF.Text = "" Then MsgBox("Invalid Profile", MsgBoxStyle.Critical) : cboProfileF.Focus() : Exit Sub
        If MsgBox("Are you sure you want to Save this Record? ..... ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim strID As String = GetString("Select ID from tblFixedField where SalaryItem='" & txtsalIDf.Text & "' and profile='" & txtProfileIDF.Text & "'  and status=0")
        For I = 0 To grdData.RowCount - 1
            '
            ' MsgBox(strID)
            Dim sqlQRY As String = ""
            Dim strQRY As String = "Delete from tblEmployeeFixedField where EmpID='" & grdData.Rows(I).Cells(1).Value & "' and ID='" & strID & "'"
            cmSave.CommandText = strQRY
            cmSave.ExecuteNonQuery()
            'MsgBox(grdData.Rows(I).Cells(2).Value)
            If grdData.Rows(I).Cells(0).Value = True Then
                strQRY = "Insert into tblEmployeeFixedField (EMPID,ID) values ('" & grdData.Rows(I).Cells(1).Value & "','" & strID & "')"
                cmSave.CommandText = strQRY
                cmSave.ExecuteNonQuery()
            End If
        Next
        trSave.Commit()
        cnSave.Close()
        MsgBox("Data Saved Successfully", MsgBoxStyle.Information)
        'cboSalaryItemF.Text = ""
        'cboProfileF.Text = ""
        txtsalIDf.Text = ""
        txtProfileIDF.Text = ""

        '=-=================2nd Run rajitha.
        ' Button8_Click(sender, e)

        '===============================
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Cursor = Cursors.WaitCursor
        PB.Value = 0
        PB.Maximum = grdData.RowCount
        For i = 0 To grdData.RowCount - 1
            PB.Value = i
            grdData.Item(0, i).Value = True
        Next
        PB.Value = PB.Maximum
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Cursor = Cursors.WaitCursor
        PB.Value = 0
        PB.Maximum = grdData.RowCount
        For I = 0 To grdData.RowCount - 1
            PB.Value = I
            grdData.Item(0, I).Value = False
        Next
        PB.Value = PB.Maximum
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim bSelected As Boolean = False
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Or Val(grdData.Item(0, X).Value) = 1 Then
                bSelected = True : Exit For
            End If
        Next
        If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub

        If UP("Employee wise Fields Add.Remove", "Formula Fields") = False Then Exit Sub
        txtSalIDFor.Text = FK_GetIDR(cboSalaryItemFor.Text)
        txtProfileIDfor.Text = FK_GetIDR(cboFormulaFor.Text)
        If txtSalIDFor.Text = "" Or txtProfileIDfor.Text = "" Then MsgBox("Please Select Salary Items and Profile First", MsgBoxStyle.Critical) : Exit Sub

        If MsgBox("Are you sure you want to Save this Record? ..... ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""
        Dim str As String = GetString("Select ID from tblformula where SalaryField='" & txtSalIDFor.Text & "' and profile='" & txtProfileIDfor.Text & "' and status=0 ")
        For I = 0 To grdData.RowCount - 1
            Dim strQRY As String = "Delete from tblEmployeeFormulaField where EmpID='" & grdData.Rows(I).Cells(1).Value & "' and ID='" & str & "'"
            cmSave.CommandText = strQRY
            cmSave.ExecuteNonQuery()
            If grdData.Rows(I).Cells(0).Value = True Then
                'MsgBox(grdData.Rows(I).Cells(2).Value)
                strQRY = "Insert into tblEmployeeFormulaField (EMPID,ID) values ('" & grdData.Rows(I).Cells(1).Value & "','" & str & "')"
                cmSave.CommandText = strQRY
                cmSave.ExecuteNonQuery()
            End If
        Next
        trSave.Commit()
        cnSave.Close()
        MsgBox("Data Saved Successfully", MsgBoxStyle.Information)
        cboFormulaFor.Text = ""
        cboFormulaFor.Text = ""
        txtSalIDFor.Text = "" : txtProfileIDfor.Text = ""
        '=-=================2nd Run rajitha.
        Button8_Click(sender, e)

        '===============================
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where tblPayrollEmployee.status=0 and  tblPayrollEmployee.SalViewLevel<=" & UserVal & " or tblPayrollEmployee.SalViewLevel is null"
        txtNo.Text = fk_browse(sSQL, "*", "RegID,DispName,EMPNo,EmIdNum,EpFno")
        If txtNo.Text = "" Then Exit Sub
        Dim Str As String = "Select 'true',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where regID='" & txtNo.Text & "' order by regID asc "
        Load_InformationtoGrid(Str, grdData, 6)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        Dim Str As String = "Select 'true',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName,tblPayrollEmployee.PrCatID,tblcBranchs.BrName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblcbranchs on tblcbranchs.BrID=tblPayrollEmployee.BrID where DeptName='" & FK_GetIDL(cmbDept.Text) & "'  order by regID asc "
        If ChkActive.Checked Then
            Str = "Select 'false',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName,tblPayrollEmployee.PrCatID,tblcBranchs.BrName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblcbranchs on tblcbranchs.BrID=tblPayrollEmployee.BrID where DeptName='" & FK_GetIDL(cmbDept.Text) & "' and tblPayrollEmployee.status='0'  order by regID asc "
        End If
        Load_InformationtoGrid(Str, grdData, 8)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
    End Sub

    Private Sub cboDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDesignation.SelectedIndexChanged
        Dim Str As String = "Select 'true',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName,tblPayrollEmployee.PrCatID,tblcBranchs.BrName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblcbranchs on tblcbranchs.BrID=tblPayrollEmployee.BrID where desgDesc='" & FK_GetIDL(cboDesignation.Text) & "' order by regID asc "
        If ChkActive.Checked Then
            Str = "Select 'false',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName,tblPayrollEmployee.PrCatID,tblcBranchs.BrName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID left join tblcbranchs on tblcbranchs.BrID=tblPayrollEmployee.BrID where desgDesc='" & FK_GetIDL(cboDesignation.Text) & "' and tblPayrollEmployee.status='0' order by regID asc "
        End If
        Load_InformationtoGrid(Str, grdData, 8)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim Str As String = "Select 'true',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID order by regID asc "
        Load_InformationtoGrid(Str, grdData, 6)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim bSelected As Boolean = False
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Or Val(grdData.Item(0, X).Value) = 1 Then
                bSelected = True : Exit For
            End If
        Next
        If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub

        If MsgBox("Are you sure you want to save changes", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        If FK_GetIDR(cmbSalaryScale.Text) = "" Then MsgBox("Please Select Salary Sheet From the List", MsgBoxStyle.Information) : cmbSalaryScale.Focus() : Exit Sub

        If UP("Employee wise Fields Add.Remove", "Attendence Fields") = True Then
            Cursor.Current = Cursors.WaitCursor
            If FK_ReadDB("Select Type1,SalID,ProID from tblScale where scID='" & FK_GetIDR(cmbSalaryScale.Text) & "' ") = True Then
                sSQL = ""
                PB.Value = 0
                PB.Maximum = grdData.RowCount
                For X = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
                    Dim sType = frmMainAttendance.dgvFillGridforRead.Item(0, X).Value.ToString
                    Dim sSalID = frmMainAttendance.dgvFillGridforRead.Item(1, X).Value.ToString
                    Dim sProID = frmMainAttendance.dgvFillGridforRead.Item(2, X).Value.ToString
                    If sType = "1" Then
                        sSQL = "Select Id,Formula from  tblNewAttFormula where SalID='" & sSalID & "' and ProID='" & sProID & "' and Status='0';"
                        FK_LoadGrid(sSQL, dgvFormula)
                        For I = 0 To grdData.RowCount - 1
                            PB.Value = I
                            If grdData.Item(0, I).Value = True Then
                                sSQL = sSQL & "Delete from tblEmpAdvAttFormula where RegID='" & grdData.Rows(I).Cells(1).Value & "' and SalID='" & sSalID & "' and Proid='" & sProID & "';"
                                For y = 0 To dgvFormula.RowCount - 1
                                    sSQL = sSQL & " Insert into tblEmpAdvAttFormula (RegID,Formula,SalID,ProID) values ('" & grdData.Rows(X).Cells(1).Value & "','" & dgvFormula.Rows(y).Cells(0).Value & "','" & sSalID & "','" & sProID & "');"
                                Next
                            End If
                        Next
                    End If
                Next
            End If
            PB.Value = PB.Maximum
            If FK_EQ(sSQL, "S", "", False, False, True) = True Then MsgBox("Attendence Fields Saved Successfully", MsgBoxStyle.Information)
        End If

        '############## - Fixed Fields

        If UP("Employee wise Fields Add.Remove", "Fixed Fields") = True Then
            If FK_ReadDB("Select Type1,SalID,ProID from tblScale where scID='" & FK_GetIDR(cmbSalaryScale.Text) & "' ") = True Then
                sSQL = ""
                PB.Value = 0
                PB.Maximum = grdData.RowCount
                For X = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
                    Dim sType = frmMainAttendance.dgvFillGridforRead.Item(0, X).Value.ToString
                    Dim sSalID = frmMainAttendance.dgvFillGridforRead.Item(1, X).Value.ToString
                    Dim sProID = frmMainAttendance.dgvFillGridforRead.Item(2, X).Value.ToString
                    If sType = "2" Then
                        Dim strID As String = GetString("Select ID from tblFixedField where SalaryItem='" & sSalID & "' and profile='" & sProID & "' ")

                        For I = 0 To grdData.RowCount - 1
                            PB.Value = I
                            If grdData.Item(0, I).Value = True Then
                                sSQL = sSQL & " Delete from tblEmployeeFixedField where EmpID='" & grdData.Rows(I).Cells(1).Value & "' and ID='" & strID & "';"
                                sSQL = sSQL & "Insert into tblEmployeeFixedField (EMPID,ID) values ('" & grdData.Rows(I).Cells(1).Value & "','" & strID & "')"
                            End If
                        Next
                    End If
                Next
            End If
            PB.Value = PB.Maximum
            If FK_EQ(sSQL, "S", "", False, False, True) = True Then MsgBox("Fixed Fields Saved Successfully", MsgBoxStyle.Information)
        End If
        '############### Formula Fields
        If UP("Employee wise Fields Add.Remove", "Formula Fields") = True Then
            If FK_ReadDB("Select Type1,SalID,ProID from tblScale where scID='" & FK_GetIDR(cmbSalaryScale.Text) & "' ") = True Then
                sSQL = ""
                PB.Value = 0
                PB.Maximum = grdData.RowCount
                For X = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
                    Dim sType = frmMainAttendance.dgvFillGridforRead.Item(0, X).Value.ToString
                    Dim sSalID = frmMainAttendance.dgvFillGridforRead.Item(1, X).Value.ToString
                    Dim sProID = frmMainAttendance.dgvFillGridforRead.Item(2, X).Value.ToString
                    If sType = "3" Then
                        Dim str As String = GetString("Select ID from tblformula where SalaryField='" & sSalID & "' and profile='" & sProID & "'")
                        For I = 0 To grdData.RowCount - 1
                            PB.Value = I
                            If grdData.Item(0, I).Value = True Then
                                sSQL = sSQL & " Delete from tblEmployeeFormulaField where EmpID='" & grdData.Rows(I).Cells(1).Value & "' and ID='" & str & "'"
                                sSQL = sSQL & "Insert into tblEmployeeFormulaField (EMPID,ID) values ('" & grdData.Rows(I).Cells(1).Value & "','" & str & "')"
                            End If
                        Next
                    End If
                Next
            End If
            PB.Value = PB.Maximum
            If FK_EQ(sSQL, "S", "", False, False, True) = True Then MsgBox("Formula Fields Saved Successfully", MsgBoxStyle.Information)
            Cursor.Current = Cursors.WaitCursor
            MsgBox("All Process Completed Successfully", MsgBoxStyle.Information)
        End If
        '=-=================2nd Run rajitha.
        Button8_Click(sender, e)
        '===============================
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim bSelected As Boolean = False
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Or Val(grdData.Item(0, X).Value) = 1 Then
                bSelected = True : Exit For
            End If
        Next
        If bSelected = False Then MsgBox("Please Select Employees from the List", MsgBoxStyle.Critical) : Exit Sub

        If UP("Employee wise Fields Add.Remove", "Advanced Attendence Fields") = False Then Exit Sub
        If cmbSalItems.Text = "" Or cmbProfiles.Text = "" Then MsgBox("Please Select Salary Items and Profile First", MsgBoxStyle.Critical) : Exit Sub
        ''sSQL = "Create table tblEmpAdvAttFormula (RegID varchar(20),Formula varchar(1000),SalID varchar(3),ProID varchar(3))"
        ''EQ(sSQL)

        If MsgBox("Are you sure you want to Save this Record? ..... ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        sSQL = ""
        PB.Value = 0
        PB.Maximum = grdData.RowCount + 2
        For X = 0 To grdData.RowCount - 1
            PB.Value = X
            sSQL = sSQL & "Delete from tblEmpAdvAttFormula where RegID='" & grdData.Rows(X).Cells(1).Value & "' and SalID='" & FK_GetIDR(cmbSalItems.Text) & "' and Proid='" & FK_GetIDR(cmbProfiles.Text) & "';"
            If grdData.Rows(X).Cells(0).Value = True Then
                For y = 0 To dgvFormula.RowCount - 1
                    sSQL = sSQL & " Insert into tblEmpAdvAttFormula (RegID,Formula,SalID,ProID) values ('" & grdData.Rows(X).Cells(1).Value & "','" & dgvFormula.Rows(y).Cells(0).Value & "','" & FK_GetIDR(cmbSalItems.Text) & "','" & FK_GetIDR(cmbProfiles.Text) & "');"
                Next
            End If
        Next
        PB.Value = PB.Maximum
        If FK_EQ(sSQL, "S", "", False, False, True) = True Then

            'End If



            'Dim cnSave As New SqlConnection(sqlConString)
            'cnSave.Open()
            'Dim cmSave As New SqlCommand
            'cmSave = cnSave.CreateCommand
            'Dim trSave As SqlTransaction = cnSave.BeginTransaction
            'cmSave.Transaction = trSave
            'Dim sqlQRY As String = ""
            'Dim str As String = GetString("Select ID from tblformula where SalaryField='" & txtSalIDFor.Text & "' and profile='" & txtProfileIDfor.Text & "' and status=0 ")
            'For I = 0 To grdData.RowCount - 1
            '    Dim strQRY As String = "Delete from tblEmployeeFormulaField where EmpID='" & grdData.Rows(I).Cells(1).Value & "' and ID='" & str & "'"
            '    cmSave.CommandText = strQRY
            '    cmSave.ExecuteNonQuery()
            '    If grdData.Rows(I).Cells(0).Value = True Then
            '        'MsgBox(grdData.Rows(I).Cells(2).Value)
            '        strQRY = "Insert into tblEmployeeFormulaField (EMPID,ID) values ('" & grdData.Rows(I).Cells(1).Value & "','" & str & "')"
            '        cmSave.CommandText = strQRY
            '        cmSave.ExecuteNonQuery()
            '    End If
            'Next
            'trSave.Commit()
            'cnSave.Close()
            MsgBox("Data Saved Successfully", MsgBoxStyle.Information)
            cboFormulaFor.Text = ""
            cboFormulaFor.Text = ""
            txtSalIDFor.Text = "" : txtProfileIDfor.Text = ""
            '=-=================2nd Run rajitha.
            Button8_Click(sender, e)
        End If
        '===============================
    End Sub

    Private Sub cmbProfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProfiles.SelectedIndexChanged

        sSQL = "Select Id,Formula from  tblNewAttFormula where SalID='" & FK_GetIDR(cmbSalItems.Text) & "' and ProID='" & FK_GetIDR(cmbProfiles.Text) & "' and Status='0';"
        FK_LoadGrid(sSQL, dgvFormula)
        For I = 0 To grdData.RowCount - 1
            grdData.Rows(I).Cells(0).Value = False
        Next
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim Sql As String
            Sql = "Select distinct RegID from tblEmpAdvAttFormula where SalID='" & FK_GetIDR(cmbSalItems.Text) & "' and ProID='" & FK_GetIDR(cmbProfiles.Text) & "' order by RegID asc;"
            Dim sqlcombo_department As New SqlCommand(Sql, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            While redcombo_department.Read()
                For I = 0 To grdData.RowCount - 1
                    If grdData.Rows(I).Cells(0).Value = False Then
                        If redcombo_department.Item(0) = grdData.Rows(I).Cells(1).Value Then
                            grdData.Rows(I).Cells(0).Value = True
                            Exit For
                        End If
                    End If
                Next
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubCategory.SelectedIndexChanged
        Dim Str As String = "Select 'true',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where Sub_category='" & FK_GetIDR(cmbSubCategory.Text) & "' order by regID asc "
        Load_InformationtoGrid(Str, grdData, 6)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
    End Sub

    Private Sub cmbProcessCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProcessCategory.SelectedIndexChanged
        Dim Str As String = "Select 'true',RegID,EPFNo,DispName,tblDesig.desgDesc,tblSetDept.DeptName from tblPayrollEmployee left join  tblSetdept on tblSetDept.DeptId=tblPayrollEmployee.DeptID left join tblDesig on tblDesig.DesgID=tblPayrollEmployee.DesigID where PrCatID='" & FK_GetIDR(cmbProcessCategory.Text) & "' order by regID asc "
        Load_InformationtoGrid(Str, grdData, 6)
        grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
    End Sub

    Private Sub rbAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.Click
        rbAll.Checked = True
        rbNone.Checked = False
        rbInverse.Checked = False
        Button7_Click(sender, e)
    End Sub

    Private Sub rbNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNone.Click
        rbAll.Checked = False
        rbNone.Checked = True
        rbInverse.Checked = False
        Button8_Click(sender, e)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If UP("Employee wise Fields Add.Remove", "Delete All Fixed Fields") = False Then Exit Sub

        If MsgBox("Are you sure you want to Delete All Fixed Fields for the Selected Employees", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Then
                sSQL = "Delete from tblEmployeeFixedField where EmpID='" & grdData.Rows(X).Cells(1).Value & "'"
                FK_EQ(sSQL, "D", "", False, False, True)
            End If
        Next
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If UP("Employee wise Fields Add.Remove", "Delete All Formula Fields") = False Then Exit Sub

        If MsgBox("Are you sure you want to Delete All Formula Fields for the Selected Employees", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Then
                sSQL = "Delete from tblEmployeeFormulaField where EmpID='" & grdData.Rows(X).Cells(1).Value & "'"
                FK_EQ(sSQL, "D", "", True, False, True)
            End If
        Next
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If UP("Employee wise Fields Add.Remove", "Delete All Advanced Attendence Fields") = False Then Exit Sub

        If MsgBox("Are you sure you want to Delete All Formula Fields for the Selected Employees", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        For X = 0 To grdData.RowCount - 1
            If grdData.Item(0, X).Value = True Then
                sSQL = "Delete from tblEmpAdvAttFormula where RegID='" & grdData.Rows(X).Cells(1).Value & "'"
                FK_EQ(sSQL, "D", "", False, False, True)
            End If
        Next
    End Sub

    Private Sub cmbSalItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSalItems.SelectedIndexChanged
        rbAll.Checked = False
        rbNone.Checked = True
    End Sub

    Public Sub SelctInverse()
        Me.Cursor = Cursors.WaitCursor
        Dim iBol As Boolean = False
        PB.Value = 0
        PB.Maximum = grdData.RowCount
        For X = 0 To grdData.RowCount - 1
            iBol = grdData.Item(0, X).Value
            PB.Value = X
            grdData.Item(0, X).Value = Not iBol
        Next
        lblCount.Text = "All Employeess : " & grdData.RowCount
        clr_Grid(grdData)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rbInverse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbInverse.Click
        SelctInverse()
        rbInverse.Checked = True
        rbAll.Checked = False
        rbNone.Checked = False
    End Sub

End Class