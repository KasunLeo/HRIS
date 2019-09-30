Imports System.Data.SqlClient

Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared

Public Class FrmActiveAttendence
    Dim objRpt As New Rpt_Attendence '- Report Files name here 

    Private Sub FrmActiveAttendence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label12)
        ControlHandlers(Me)
        sSQL = "select distinct cYear from tblAttsum;"
        FillComboAll(cmbYear, sSQL)
        sSQL = "select distinct cMonth from tblAttsum;"
        FillComboAll(cmbMonth, sSQL)
        sSQL = "select CatDesc+'='+CatID from tblSetPrCategory where Status='0'"
        FillComboAll(cmbPrcat, sSQL)

        If cBusiness = "" Or cPhone = "" Or cAddress = "" Then MessageBox.Show("Please Set Business Information from Edit menu.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cmbSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New FrmFilterEmployees)
        sSQL = "Select Count(regID) from tblTempRegID"
        'lblEmployees.Text = "Total Employees :  " & GetVal(sSQL)

    End Sub

    Private Sub btn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn.Click

        Try
            Dim strQuery As String = ""
            If strReportBased = "01" Then strQuery = "tblPayrollEmployee.RegID" Else If strReportBased = "02" Then strQuery = "tblPayrollEmployee.EPFNo" Else If strReportBased = "03" Then strQuery = "tblPayrollEmployee.ETPNo" Else If strReportBased = "04" Then strQuery = "tblPayrollEmployee.EMPNo"

            sSQL = " Select tblPayrollEmployee.RegID,tblPayrollEmployee.DispName,RIGHT('00000'+CAST(" & strQuery & " AS VARCHAR(6)),6) as EMPNo, tblPayrollEmployee.EPFNo,tblPayrollEmployee.ETPNo,tblPayrollEmployee.ComID, tblCompany.cName,tblPayrollEmployee.DesigID,tblDesig.desgDesc,tblPayrollEmployee.BrID,tblCBranchs.BrName,tblPayrollEmployee.DeptID,tblSetDept.DeptName, tblPayrollEmployee.BasicSalary,tblPayrollEmployee.DaysPay,tblPayrollEmployee.EpfAllowed, tblPayrollEmployee.PayID,tblSetPCentre.pDesc,tblPayrollEmployee.CostID,tblSetCCentre.cntDesc, tblPayrollEmployee.EmIdNum,tblPayrollEmployee.Status,tblPayrollEmployee.PrCatID, tblSetPrCategory.CatDesc,tblUL.LevelName,tblPayrollEmployee.SalViewLevel from tblPayrollEmployee " & _
                    " left outer join tblCompany on tblPayrollEmployee.ComID = tblCompany.CompID " & _
                    " left outer join tblDesig on tblPayrollEmployee.DesigID = tblDesig.DesgID" & _
                    " left outer join tblCBranchs on tblPayrollEmployee.BrID = tblCBranchs.BrID" & _
                    " left outer join tblSetDept on tblPayrollEmployee.DeptID = tblSetDept.DeptID" & _
                    " left outer join tblSetPCentre on tblPayrollEmployee.PayID = tblSetPCentre.pID" & _
                    " left outer join tblSetCCentre on tblPayrollEmployee.CostID = tblSetCCentre.CntID" & _
                    " left outer join tblSetPrCategory on tblPayrollEmployee.PrCatID = tblSetPrCategory.CatID" & _
                    " left outer join tblUL on tblPayrollEmployee.SalViewLevel = tblUL.LevelValue" & _
                    " where tblPayrollEmployee.Status=0 and tblPayrollEmployee.PrCatID like '" & FK_GetIDR(cmbPrcat.Text) & "';"

            Dim CN As New SqlConnection(sqlConString)
            CN.Open()
            Dim adp As New SqlDataAdapter(sSQL, CN)
            Dim stable As New DS_Report
            adp.Fill(stable, "tblEmployee")
            objRpt = New Rpt_Attendence

            sSQL = "select (column_name),'' from Information_schema.columns where table_name='tblAttsum'  and Column_name not in ('cMonth','cYear','Status') order by Ordinal_position;"
            'Dim sDGV As New DataGridView
            Fk_FillGrid(sSQL, sDGV)
            For X = 0 To sDGV.RowCount - 1
                sDGV.Item(1, X).Value = "DataColumn" & X + 1
            Next
            sDGV.Item(1, 0).Value = "RegID"
            sSQL1 = ""
            For X = 0 To sDGV.RowCount - 1
                If sDGV.Item(0, X).Value <> "" Then
                    sSQL1 = Trim(sSQL1) & "tblAttsum." & sDGV.Item(0, X).Value.ToString & " as " & sDGV.Item(1, X).Value & ","
                End If
            Next
            sSQL1 = Trim(sSQL1)
            sSQL1 = Microsoft.VisualBasic.Left(sSQL1, (Len(sSQL1) - 1))
            sSQL = "Select " & sSQL1 & " from tblAttsum  inner join  tblPayrollEmployee on tblPayrollEmployee.RegID=tblAttsum.RegID where tblAttsum.cYear='" & Val(cmbYear.Text) & "' and tblAttsum.cMonth= '" & Val(cmbMonth.Text) & "'"
            ''sSQL = procesSQL(sSQL)
            adp = New SqlDataAdapter(sSQL, CN)
            adp.Fill(stable, "tblAttendence")
            'MsgBox(stable.Tables("tblEmployee").Rows.Count)
            'MsgBox(stable.Tables("tblAttendence").Rows.Count)
            objRpt.Database.Tables("tblEmployee").SetDataSource(stable.Tables("tblEmployee"))
            objRpt.Database.Tables("tblAttendence").SetDataSource(stable.Tables("tblAttendence"))

            sSQL = "select (column_name),'' from Information_schema.columns where table_name='tblAttsum'  and Column_name not in ('cMonth','cYear','Status','RegID') order by Ordinal_position;"
            'Dim sDGV As New DataGridView
            Fk_FillGrid(sSQL, sDGV)
            Dim dRows As Integer = sDGV.RowCount - 1
            If dRows >= 20 Then dRows = 20

            For X = 0 To dRows
                sDGV.Item(1, X).Value = "T" & X + 1
            Next
            'objRpt.Database.Tables("tblDepartment").SetDataSource(stable.Tables("tblDepartment"))

            'objRpt.SetDataSource(stable.Tables("tblEmployee")) ' - Data Set Table Name Here 
            Dim X1 As Integer
            For X = 0 To dRows
                objRpt.SetParameterValue(sDGV.Item(1, X).Value, sDGV.Item(0, X).Value)
                'sDGV.Item(1, X).Value = "T" & X + 1
                X1 = X
            Next
            If Not X1 > 20 Then
                For i = X1 + 1 To 20
                    objRpt.SetParameterValue("T" & i + 1, " ")
                Next
            End If
         
            objRpt.SetParameterValue("1", cBusiness)
            objRpt.SetParameterValue("2", cAddress)
            objRpt.SetParameterValue("3", cPhone)
            objRpt.SetParameterValue("4", "Active Attendence Details of Year : " & cmbYear.Text & " and Month :  " & cmbMonth.Text)
            objRpt.SetParameterValue("crUser", CurrentUser)
            frmRepContainer.crptView.ReportSource = objRpt
            frmRepContainer.crptView.Refresh()
            frmRepContainer.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function procesSQL(ByVal strSQL As String) As String
        Dim sql As String
        Dim inSql As String
        Dim firstPart As String
        Dim lastPart As String
        Dim selectStart As Integer
        Dim fromStart As Integer
        Dim fields As String()
        Dim i As Integer
        Dim MyText As TextObject
        inSql = strSQL
        inSql = inSql.ToUpper
        selectStart = inSql.IndexOf("SELECT")
        fromStart = inSql.IndexOf("FROM")
        selectStart = selectStart + 6
        firstPart = inSql.Substring(selectStart, (fromStart - selectStart))
        lastPart = inSql.Substring(fromStart, inSql.Length - fromStart)
        fields = firstPart.Split(",")
        firstPart = ""
        For i = 0 To fields.Length - 1
            If i > 0 Then
                firstPart = firstPart & " , " & fields(i).ToString() & "  AS DATACOLUMN" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = fields(i).ToString()
            Else
                firstPart = firstPart & fields(i).ToString() & "  AS DATACOLUMN" & i + 1
                MyText = CType(objRpt.ReportDefinition.ReportObjects("Text" & i + 1), TextObject)
                MyText.Text = fields(i).ToString()
            End If
        Next
        sql = "SELECT " & firstPart & " " & lastPart
        Return sql
    End Function

End Class