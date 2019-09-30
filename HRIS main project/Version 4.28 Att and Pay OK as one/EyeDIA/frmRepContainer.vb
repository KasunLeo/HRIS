'Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports CrystalDecisions.Windows.Forms
'Imports CrystalDecisions.ReportSource

Public Class frmRepContainer
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmRepContainer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'frmPaySheetpror.Close()
    End Sub

    Private Sub NewReportParameter()
        Try


            If strReportID = "16" Or strReportID = "37" Or strReportID = "40" Or strReportID = "41" Or strReportID = "42" Or strReportID = "43" Or strReportID = "51" Or strReportID = "56" Or strReportID = "57" Or strReportID = "58" Or strReportID = "59" Or strReportID = "60" Or strReportID = "61" Then
                Dim strdate As String = "Month of " & MonthName(dtReportDate.Month) & " - " & dtReportDate.Year
                'Call report Name
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID)
                mod_NewReportOption.newcaseClass.SetParameterValue("cDate", strdate)
                mod_NewReportOption.newcaseClass.SetParameterValue("crUser", CurrentUser)
            ElseIf StrReportID = "26" Or StrReportID = "38" Or StrReportID = "20" Then
                'Call report Name
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID)
                If StrReportID = "20" Then
                    mod_NewReportOption.newcaseClass.SetParameterValue("crUser", CurrentUser)
                End If
            ElseIf StrReportID = "31" Or StrReportID = "36" Or StrReportID = "44" Or StrReportID = "62" Then
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID)
                Dim strC01 As String = frmMainAttendance.dgvFillGridforRead.Item(0, 0).Value
                Dim strC02 As String = frmMainAttendance.dgvFillGridforRead.Item(0, 1).Value
                Dim strC03 As String = frmMainAttendance.dgvFillGridforRead.Item(0, 2).Value
                Dim strC04 As String = frmMainAttendance.dgvFillGridforRead.Item(0, 3).Value
                Dim strC05 As String = frmMainAttendance.dgvFillGridforRead.Item(0, 4).Value
                Dim strC06 As String = frmMainAttendance.dgvFillGridforRead.Item(0, 5).Value
                mod_NewReportOption.newcaseClass.SetParameterValue("cBusiness", strDispCompany)
                mod_NewReportOption.newcaseClass.SetParameterValue("C0", strC01)
                mod_NewReportOption.newcaseClass.SetParameterValue("C1", strC02)
                mod_NewReportOption.newcaseClass.SetParameterValue("C2", strC03)
                mod_NewReportOption.newcaseClass.SetParameterValue("C3", strC04)
                mod_NewReportOption.newcaseClass.SetParameterValue("C4", strC05)
                mod_NewReportOption.newcaseClass.SetParameterValue("C5", strC06)
                mod_NewReportOption.newcaseClass.SetParameterValue("crUser", CurrentUser)
            ElseIf StrReportID = "34" Or StrReportID = "50" Then
                Dim strdate As String = "Month of " & MonthName(dtReportDate.Month) & " - " & dtReportDate.Year
                Dim strdate2 As DateTime = dtReportDate2
                'Call report Name
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID)
                mod_NewReportOption.newcaseClass.SetParameterValue("cDate", strdate)
                mod_NewReportOption.newcaseClass.SetParameterValue("Month1", dtReportDate)
                mod_NewReportOption.newcaseClass.SetParameterValue("Month2", strdate2)
                mod_NewReportOption.newcaseClass.SetParameterValue("crUser", CurrentUser)
            ElseIf StrReportID = "46" Then
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID) '46=Annual payroll
                mod_NewReportOption.newcaseClass.SetParameterValue("Company", strDispCompany)
            ElseIf StrReportID = "45" Or StrReportID = "47" Or StrReportID = "48" Then '45=Request deduction report 47=Request deduction bank wise report
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID)
                mod_NewReportOption.newcaseClass.SetParameterValue("Company", strDispCompany)
                Dim strdate As String = "Month of " & MonthName(intCMonth) & " - " & intCyear
                mod_NewReportOption.newcaseClass.SetParameterValue("cDate", strdate)
            ElseIf StrReportID = "100" Or StrReportID = "101" Or StrReportID = "102" Then
                mod_NewReportOption.reportselecting(mod_NewReportOption.ReportID)


                'mod_NewReportOption.newcaseClass.SetParameterValue("isCurMonth", frmDEptwiseSummary.intHistory)
                'mod_NewReportOption.newcaseClass.SetParameterValue("cMonth", frmDEptwiseSummary.Val(cmbMonth.Text))
                'mod_NewReportOption.newcaseClass.SetParameterValue("cYear", frmDEptwiseSummary.Val(cmbYear.Text))
                'mod_NewReportOption.newcaseClass.SetParameterValue("SlipStru", frmDEptwiseSummary.FK_GetIDR(cmbSalarySheet.Text))
                'mod_NewReportOption.newcaseClass.SetParameterValue("PrcCat", frmDEptwiseSummary.FK_GetIDR(cmbPrCatagory.Text))

            End If

            'Call report Name
            mod_NewReportOption.newcaseClass.DataSourceConnections(0).SetConnection(sServer, sDatabase, False)
            mod_NewReportOption.newcaseClass.DataSourceConnections(0).SetLogon(sUserName, sPassword)
            mod_NewReportOption.newcaseClass.DataSourceConnections(0).IntegratedSecurity = False

            'mod_NewReportOption.newcaseClass.SetParameterValue("frDate", StrRpFromDate)
            'mod_NewReportOption.newcaseClass.SetParameterValue("toDate", StrRpToDate)
            crptView.ReportSource = mod_NewReportOption.newcaseClass 'cryRpt
            crptView.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmRepContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, lblReport)
        ControlHandlers(Me)
       
        If strReportID = "16" Then
            NewReportParameter()
        ElseIf strReportID = "26" Then
            NewReportParameter()
        ElseIf strReportID = "31" Then
            NewReportParameter()
        ElseIf strReportID = "34" Then
            NewReportParameter()
        ElseIf strReportID = "36" Then
            NewReportParameter()
        ElseIf strReportID = "37" Then
            NewReportParameter()
        ElseIf strReportID = "38" Then
            NewReportParameter()
        ElseIf strReportID = "40" Then
            NewReportParameter()
        ElseIf strReportID = "20" Then
            NewReportParameter()
        ElseIf strReportID = "41" Then
            NewReportParameter()
        ElseIf strReportID = "42" Then
            NewReportParameter()
        ElseIf strReportID = "43" Then
            NewReportParameter()
        ElseIf strReportID = "44" Then
            NewReportParameter()
        ElseIf strReportID = "45" Then
            NewReportParameter()
        ElseIf strReportID = "46" Then
            NewReportParameter()
        ElseIf strReportID = "47" Then
            NewReportParameter()
        ElseIf strReportID = "48" Then
            NewReportParameter()
        ElseIf strReportID = "50" Then
            NewReportParameter()
        ElseIf strReportID = "51" Then
            NewReportParameter()
        ElseIf strReportID = "56" Then
            NewReportParameter()
        ElseIf strReportID = "57" Then
            NewReportParameter()
        ElseIf strReportID = "58" Then
            NewReportParameter()
        ElseIf strReportID = "59" Then
            NewReportParameter()
        ElseIf strReportID = "60" Then
            NewReportParameter()
        ElseIf strReportID = "61" Then
            NewReportParameter()
        ElseIf strReportID = "62" Then
            NewReportParameter()
        ElseIf strReportID = "100" Then
            NewReportParameter()
        ElseIf strReportID = "101" Then
            NewReportParameter()
        ElseIf strReportID = "102" Then
            NewReportParameter()
        End If

    End Sub

End Class