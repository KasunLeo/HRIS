Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmEditAttendenceSummery

    Dim SEmpID As String

    Private Sub frmWorkingDays_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label4)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
        cmbMonth.Items.Clear()
        For X = 1 To 12
            cmbMonth.Items.Add(X)
        Next
        txtYear.Text = (Now.Date.Year)
        cmbMonth.Text = (Now.Date.Month)
        If StrEmployeeID <> "" Then
            txtRegID.Text = StrEmployeeID
            ViewEmployee()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then SendKeys.Send("{TAB}")
        If keyData = Keys.Escape Then Me.Close()
        If keyData = Keys.F2 Then clickBrowse()
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub SearchATTSum()
        sSQL = " select " & cmbAttnFields.Text & " from tblAttSum where cMonth='" & cmbMonth.Text & "' and CYear='" & txtYear.Text & "' and RegID='" & txtRegID.Text & "'; "
        txtAvailable.Text = GetVal(sSQL)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click   
        If cmbAttnFields.Text <> "" Then cmbAttnFields_SelectedIndexChanged(sender, e)
        Dim ctrl As Control
        For Each ctrl In Me.GroupBox1.Controls
            If TypeOf ctrl Is TextBox Then ctrl.Text = ""
        Next
        FillComboAll(cmbAttnFields, "select column_name from information_schema.columns  where table_name = 'tblAttSum' order by ordinal_position")
        cmbAttnFields.Items.Remove("Status")
        cmbAttnFields.Items.Remove("cMonth")
        cmbAttnFields.Items.Remove("CYear")
        cmbAttnFields.Items.Remove("RegID")
        chkAllUpdat.Checked = False
    End Sub

    Private Sub txtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cmbAttnFields_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAttnFields.Click

    End Sub

    Private Sub cmbAttnFields_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAttnFields.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cmbAttnFields_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAttnFields.SelectedIndexChanged

        ''Dim ctrl As Control
        ''For Each ctrl In Me.GroupBox1.Controls
        ''    If TypeOf ctrl Is TextBox Then ctrl.Text = ""
        ''Next

        sSQL = " select EmpNo,EPFNo,tblAttSum.RegID,DispName as 'Name',tblAttSum." & cmbAttnFields.Text & " from tblAttSum inner join tblPayrollEmployee on tblAttSum.RegID=tblPayrollEmployee.RegID where cMonth='" & cmbMonth.Text & "' and CYear='" & txtYear.Text & "' and tblPayrollEmployee.Salviewlevel<=" & UserVal & " or cMonth='" & cmbMonth.Text & "' and CYear='" & txtYear.Text & "' and tblPayrollEmployee.Salviewlevel is null "
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgvWork.DataSource = sTable.Tables(0)
            For Each col As DataGridViewColumn In dgvWork.Columns
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, False)
            Next
            For X = 0 To dgvWork.ColumnCount - 1
                If dgvWork.Columns(X).Width < 100 Then dgvWork.Columns(X).Width = 158
            Next
            lblCount.Text = "All Employeess : " & dgvWork.RowCount

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtEmpNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRegID.KeyPress

        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtRegID.Text = "" Then txtEPFNo.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name: " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation: " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department: " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch: " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company: " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                    SearchATTSum()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub
                txtDetails.Text = ""
                txtRegID.Text = ""
                txtEPFNo.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        sSQL = "Select RegID from tblAttSum where cyear='" & txtYear.Text & "' and cMonth='" & cmbMonth.Text & "'"
        If fk_CheckEx(sSQL) = False Then MsgBox("Attendence Does not exists for the Current Month ", MsgBoxStyle.Critical) : Exit Sub
        If txtYear.Text = "" Then
            MsgBox("Please enter the year")
            txtYear.Focus()
            Exit Sub
        End If
        If cmbMonth.Text = "NONE" Then
            MsgBox("Please select the month")
            cmbMonth.Focus()
            Exit Sub
        End If
        '===========================
        If cmbAttnFields.Text = "" Then
            MsgBox("Please Select the Attendence Field")
            cmbAttnFields.Focus()
            Exit Sub
        End If
        '=========================
        If txtRegID.Text = "" Then
            MsgBox("Please enter the employee")
            txtRegID.Focus()
            Exit Sub
        End If
        If Not txtRegID.Text = fk_RetString("Select RegID from tblAttSum where RegID='" & txtRegID.Text & "'") Then
            MsgBox("Employee Number Does Not Exits in the Database", MsgBoxStyle.Information)
        End If
        Dim strQry As String = ""

        If UP("Set Monthly Attendece Summery", "Edit Monthly Attendence") = False Then Exit Sub
        Dim sID As Integer = GetVal("Select AtnsumID from tblControl") + 1
        Dim sValue As Double = GetVal("Select " & cmbAttnFields.Text & " from tblAttSum where RegID='" & txtRegID.Text & "' and cYear='" & txtYear.Text & "' and cMonth='" & cmbMonth.Text & "' ")
        sSQL = "Insert into tbloldattsum (id,regid,field,stuatus,amount,userid,cMonth,cyear) values('" & sID & "','" & txtRegID.Text & "','" & cmbAttnFields.Text & "','Old','" & sValue & "','" & StrUserID & "','" & cmbMonth.Text & "','" & txtYear.Text & "');"
        sSQL = sSQL & "Insert into tbloldattsum (id,regid,field,stuatus,amount,userid,cMonth,cyear) values('" & sID & "','" & txtRegID.Text & "','" & cmbAttnFields.Text & "','New','" & Val(txtAmount.Text) & "','" & StrUserID & "','" & cmbMonth.Text & "','" & txtYear.Text & "');"
        sSQL = sSQL & "Update tblAttSum set " & cmbAttnFields.Text & "= '" & Val(txtAmount.Text) & "' where RegID='" & txtRegID.Text & "' and cYear='" & txtYear.Text & "' and cMonth='" & cmbMonth.Text & "'"
        sSQL = sSQL & " Update tblControl set AtnsumID=AtnsumID+1 "
        FK_EQ(sSQL, "E", "", True, True, True)
        sSQL = " select EmpNo,EPFNo,tblAttSum.RegID,DispName,tblAttSum." & cmbAttnFields.Text & " from tblAttSum inner join tblPayrollEmployee on tblAttSum.RegID=tblPayrollEmployee.RegID where cMonth='" & cmbMonth.Text & "' and CYear='" & txtYear.Text & "'"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgvWork.DataSource = sTable.Tables(0)
            For Each col As DataGridViewColumn In dgvWork.Columns
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, False)
            Next
            For X = 0 To dgvWork.ColumnCount - 1
                If dgvWork.Columns(X).Width < 100 Then dgvWork.Columns(X).Width = 158
            Next
            lblCount.Text = "All Employeess : " & dgvWork.RowCount
            txtAmount.Text = ""
            'cmdRefresh_Click(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmbMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbMonth.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged

        ''Dim ctrl As Control
        ''For Each ctrl In Me.GroupBox1.Controls
        ''    If TypeOf ctrl Is TextBox Then ctrl.Text = ""
        ''Next

        sSQL = " select EmpNo,EPFNo,DispName,tblAttSum.* from tblAttSum inner join tblPayrollEmployee on tblAttSum.RegID=tblPayrollEmployee.RegID where cMonth='" & cmbMonth.Text & "' and CYear='" & txtYear.Text & "'"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            dgvWork.DataSource = sTable.Tables(0)
            For Each col As DataGridViewColumn In dgvWork.Columns
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCellsExceptHeader, False)
            Next
            For X = 0 To dgvWork.ColumnCount - 1
                If dgvWork.Columns(X).Width < 100 Then dgvWork.Columns(X).Width = 158
            Next
            lblCount.Text = "All Employeess : " & dgvWork.RowCount

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.GotFocus
        txtAmount.SelectAll()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress

        '=====================
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Or ((e.KeyChar) = ".") Then
            e.Handled = False
        End If
        If txtAmount.Text.Contains(".") And e.KeyChar = "." Then
            e.Handled = True
        End If
        '========================

        If e.KeyChar = ChrW(Keys.Enter) Then

            Call cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim SQL As String
        'SQL = "SELECT     dbo.tblPrSum.EmpID, dbo.tblPayrollEmployee.dispName, dbo.tblPrSum.cYear, dbo.tblPrSum.cMonth,dbo.tblPrSum." & txtItem.Text & "          FROM dbo.tblPrSum   INNER JOIN                 dbo.tblPayrollEmployee ON dbo.tblPrSum.EmpID = dbo.tblPayrollEmployee.RegID  where tblPrSum.cMonth='5' and tblPrSum.cyear='2012' "
        'Load_InformationtoGrid(SQL, dgvWork, 5)

    End Sub

    Private Sub ViewEmployee()
        If txtRegID.Text = "" Then Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo,dbo.tblCBranchs.BrName, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.RegID = '" & txtRegID.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation" & vbTab & ": " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department" & vbTab & ": " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company" & vbTab & vbTab & ": " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    If StrEmployeeID = "" Then
                        SearchATTSum()
                    End If
                    StrEmployeeID = ""
                End While
                txtAmount.Focus()

            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Public Sub clickBrowse()
        If Trim(cmbAttnFields.Text) = "" Then MessageBox.Show("Please Select Attendance Field first", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbAttnFields.Focus() : Exit Sub
        If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as '" & strQuery.Split("."c)(1) & "'  ,dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo,dbo.tblCBranchs.BrName, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.ID LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID  where tblPayrollEmployee.status=0  AND tblPayrollEmployee.DeptID In ('" & StrUserLvDept & "') AND tblPayrollEmployee.BrID In ('" & StrUserLvBranch & "') AND (tblUL.LevelValue  <= " & UserVal & " Or tblPayrollEmployee.SalViewLevel =0)  order by " & strQuery & ""
        If FK_Br(sSQL) = True Then
            txtRegID.Text = frmMainAttendance.dgvFillGridforRead.Item(0, 0).Value
            ViewEmployee()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clickBrowse()
    End Sub

    Private Sub txtEmpNo_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpNo.KeyPress
        txtDetails.Text = ""
        txtEPFNo.Text = ""
        txtRegID.Text = ""

        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtEmpNo.Text = "" Then txtRegID.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.empNo = '" & txtEmpNo.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.empno = '" & txtEmpNo.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name: " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation: " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department: " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch: " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company: " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                    SearchATTSum()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()

    End Sub

    Private Sub txtEmpNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpNo.TextChanged

    End Sub

    Private Sub txtEPFNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEPFNo.KeyPress
        txtDetails.Text = ""
        txtRegID.Text = ""
        txtEmpNo.Text = ""

        If Not e.KeyChar = ChrW(Keys.Enter) Then Exit Sub
        If txtEPFNo.Text = "" Then txtEmpNo.Focus() : Exit Sub
        sSQL = "SELECT     dbo.tblPayrollEmployee.RegID, dbo.tblPayrollEmployee.DispName, dbo.tblPayrollEmployee.EMPNo, dbo.tblPayrollEmployee.EmIdNum, dbo.tblPayrollEmployee.PrCatID, dbo.tblPayrollEmployee.EPFNo, dbo.tblPayrollEmployee.ETPNo,                       dbo.tblCompany.cName, dbo.tblDesig.desgDesc, dbo.tblSetDept.DeptName, dbo.tblPayrollEmployee.BasicSalary, dbo.tblPayrollEmployee.DaysPay,                       dbo.tblPayrollEmployee.EpfAllowed, dbo.tblSetPCentre.pDesc, dbo.tblSetCCentre.cntDesc, dbo.tblUL.LevelName, dbo.tblCBranchs.BrName,tblSetPrCategory.CatDesc  FROM         dbo.tblPayrollEmployee Left Outer JOIN dbo.tblSetCCentre ON dbo.tblPayrollEmployee.CostID = dbo.tblSetCCentre.CntID LEFT OUTER JOIN dbo.tblCBranchs ON dbo.tblPayrollEmployee.ComID = dbo.tblCBranchs.CompID AND dbo.tblPayrollEmployee.BrID = dbo.tblCBranchs.BrID LEFT OUTER JOIN dbo.tblUL ON dbo.tblPayrollEmployee.SalViewLevel = dbo.tblUL.LevelValue LEFT OUTER JOIN dbo.tblSetPCentre ON dbo.tblPayrollEmployee.PayID = dbo.tblSetPCentre.pID LEFT OUTER JOIN dbo.tblSetDept ON dbo.tblPayrollEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN dbo.tblDesig ON dbo.tblPayrollEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN dbo.tblCompany ON dbo.tblPayrollEmployee.ComID = dbo.tblCompany.CompID LEFT OUTER JOIN  tblSetPrCategory on tblSetPrCategory.CatID=tblpayrollEmployee.PrcatID WHERE     (dbo.tblPayrollEmployee.epfno = '" & txtEPFNo.Text & "') and tblPayrollEmployee.SalViewLevel<=" & UserVal & " or (dbo.tblPayrollEmployee.epfno = '" & txtEPFNo.Text & "') and tblPayrollEmployee.SalViewLevel is null"
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    SEmpID = txtRegID.Text
                    strSaveStatus = "E"
                    txtRegID.Text = IIf(IsDBNull(RD.Item("RegID")), "", RD.Item("RegID"))
                    txtEmpNo.Text = IIf(IsDBNull(RD.Item("EMPNO")), "", RD.Item("EMPNO"))
                    txtEPFNo.Text = IIf(IsDBNull(RD.Item("EPFNO")), "", RD.Item("EPFNO"))
                    txtDetails.Text = "Name: " & IIf(IsDBNull(RD.Item("DispName")), "", RD.Item("DispName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Designation: " & IIf(IsDBNull(RD.Item("desgDesc")), "", RD.Item("desgDesc"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Department: " & IIf(IsDBNull(RD.Item("DeptName")), "", RD.Item("DeptName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Branch: " & IIf(IsDBNull(RD.Item("BrName")), "", RD.Item("BrName"))
                    txtDetails.Text = txtDetails.Text & vbNewLine & "Company: " & IIf(IsDBNull(RD.Item("cName")), "", RD.Item("cName"))
                    txtAmount.Focus()
                    SearchATTSum()
                End While
            Else
                MsgBox("Data Does not exits in the Database.", MsgBoxStyle.Critical) : txtRegID.Focus() : txtRegID.SelectAll() : Exit Sub

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Sub

    Private Sub txtEPFNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEPFNo.TextChanged

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click




        Try
            sSQL = " Select tblPayrollEmployee.RegID,tblPayrollEmployee.DispName,tblPayrollEmployee.EMPNo, tblPayrollEmployee.EPFNo,tblPayrollEmployee.ETPNo,tblPayrollEmployee.ComID, tblCompany.cName,tblPayrollEmployee.DesigID,tblDesig.desgDesc,tblPayrollEmployee.BrID,tblCBranchs.BrName,tblPayrollEmployee.DeptID,tblSetDept.DeptName, tblPayrollEmployee.BasicSalary,tblPayrollEmployee.DaysPay,tblPayrollEmployee.EpfAllowed, tblPayrollEmployee.PayID,tblSetPCentre.pDesc,tblPayrollEmployee.CostID,tblSetCCentre.cntDesc, tblPayrollEmployee.EmIdNum,tblPayrollEmployee.Status,tblPayrollEmployee.PrCatID, tblSetPrCategory.CatDesc,tblUL.LevelName,tblPayrollEmployee.SalViewLevel from tblPayrollEmployee " & _
            " left outer join tblCompany on tblPayrollEmployee.ComID = tblCompany.CompID " & _
            " left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID" & _
            " left outer join tblCBranchs on tblPayrollEmployee.BrID = tblCBranchs.BrID" & _
            " left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID" & _
            " left outer join tblSetPCentre on tblPayrollEmployee.PayID = tblSetPCentre.pID" & _
            " left outer join tblSetCCentre on tblPayrollEmployee.CostID = tblSetCCentre.CntID" & _
            " left outer join tblSetPrCategory on tblPayrollEmployee.PrCatID = tblSetPrCategory.CatID" & _
            " left outer join tblUL on tblPayrollEmployee.SalViewLevel = tblUL.LevelValue" & _
            " where tblPayrollEmployee.Status='0' ;"
            Dim CN As New SqlConnection(sqlConString)
            CN.Open()
            Dim adp As New SqlDataAdapter(sSQL, CN)
            Dim stable As New DataSet1
            adp.Fill(stable, "tblEmployee")
            sSQL = "select * from tbloldattsum where cyear='" & txtYear.Text & "' and cMonth='" & cmbMonth.Text & "';"
            adp = New SqlDataAdapter(sSQL, CN)
            adp.Fill(stable, "tbloldattsum")

            Dim objRpt As New rptEditAttendance '- Report Files name here 
            objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
            objRpt.Database.Tables("tbloldattsum").SetDataSource(stable.Tables("tbloldattsum"))
            ' objRpt.SetDataSource(stable.Tables("tblEmployee")) ' - Data Set Table Name Here 
            'objRpt.Database.Tables("tblDepartment").SetDataSource(stable.Tables("tblDepartment"))
            objRpt.SetParameterValue("1", cBusiness)
            'objRpt.SetParameterValue("2", cAddress)
            'objRpt.SetParameterValue("3", cPhone)
            objRpt.SetParameterValue("2", "Edit Attendance Details....")
            frmRepContainer.crptView.ReportSource = objRpt
            frmRepContainer.crptView.Refresh()
            frmRepContainer.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MsgBox("Are you sure you want to Export this Data to Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        sSQL = "Select tblPayrollEmployee.EPFNo,tblPayrollEmployee.DispName, tblDesig.desgDesc,tblSetDept.DeptName,tblAttSum.* from tblPayrollEmployee  left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID left outer join tblAttSum on tblAttSum.RegID=tblPayrollEmployee.RegID where cYear='" & txtYear.Text & "' and cMonth='" & cmbMonth.Text & "' order by tblSetDept.DeptID asc, EPFNo asc"
        Fk_FillGrid(sSQL, dgv)
        ExporttoExcel(dgv, 5)
    End Sub

    Private Sub btnAllUpdat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllUpdat.Click
        If UP("Set Monthly Attendece Summery", "Edit Monthly Attendence All At Once") = False Then Exit Sub
        sSQL = sSQL & "Update tblAttSum set " & cmbAttnFields.Text & "= '" & Val(txtAllAmount.Text) & "' where cYear='" & txtYear.Text & "' and cMonth='" & cmbMonth.Text & "'"
        If FK_EQ(sSQL, "E", "", True, True, True) = True Then txtRegID.Focus()
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub chkAllUpdat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllUpdat.CheckedChanged
        If chkAllUpdat.Checked = True Then
            txtAllAmount.Text = txtAmount.Text
            txtAllAmount.Location = New Point(81, 80)
            txtAllAmount.Visible = True
            btnAllUpdat.Visible = True
            txtAmount.Visible = False
        Else
            txtAmount.Text = txtAllAmount.Text
            txtAmount.Location = New Point(81, 80)
            txtAmount.Visible = True
            txtAllAmount.Visible = False
            btnAllUpdat.Visible = False
        End If
    End Sub

End Class