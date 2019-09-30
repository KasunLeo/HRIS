Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.ReportSource

Public Class frmRepContainerAttn

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub frmRepContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, pnlTop, lblReport)

        Try
            '    lblReport.Text = StrRepTitle
            '    Dim cr As New ReportDocument
            '    cr.Load(StrRepFile)
            '    cr.SetDatabaseLogon(sUserName, sPassword)
            '    crptViewer.ReportSource = cr 'StrReportFileName
            '    If StrSelectionFomula <> "" Then
            '        crptViewer.SelectionFormula = StrSelectionFomula
            '    End If

            '    cr.SetParameterValue("frDate", StrRpFromDate)
            '    cr.SetParameterValue("toDate", StrRpToDate)
            '    crptViewer.Refresh()

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            If mod_ReportAttendance.ReportID = "" Then
                MsgBox("Error with Report")
                Exit Sub
            End If

            mod_ReportAttendance.reportselecting(mod_ReportAttendance.ReportID)

            'RepClass.newcaseClass.DataSourceConnections(0).Clear()
            mod_ReportAttendance.newcaseClass.DataSourceConnections(0).SetConnection(sServer, sDatabase, False)
            mod_ReportAttendance.newcaseClass.DataSourceConnections(0).SetLogon(sUserName, sPassword)
            mod_ReportAttendance.newcaseClass.DataSourceConnections(0).IntegratedSecurity = False

            mod_ReportAttendance.newcaseClass.SetParameterValue("frDate", StrRpFromDate)
            mod_ReportAttendance.newcaseClass.SetParameterValue("toDate", StrRpToDate)
            mod_ReportAttendance.newcaseClass.SetParameterValue("crUser", CurrentUser)

            If StrReportID = "039" Then
                mod_ReportAttendance.newcaseClass.SetParameterValue("TotEmps", intTotEmps)
            End If

            If StrReportID = "046" Or StrReportID = "047" Or StrReportID = "048" Or StrReportID = "049" Or StrReportID = "050" Or StrReportID = "053" Or StrReportID = "070" Then
                Dim strCompany As String = fk_RetString("select cName from  tblcompany WHERE compid='" & StrCompID & "'")
                mod_ReportAttendance.newcaseClass.SetParameterValue("comapany", strCompany)
            End If

            'Select case Option for Report Viewer
            Select Case StrReportID
                Case "039"

                Case "046"

                Case "301"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "302"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "303"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "304"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "305"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "306"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "307"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                Case "308"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("ActName", StrRActName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("Catname", StrRCatName)
                Case "309"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("ActName", StrRActName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("Catname", StrRCatName)
                Case "310"

                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("ActName", StrRActName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("Catname", StrRCatName)
                Case "311"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("ActName", StrRActName)
                    mod_ReportAttendance.newcaseClass.SetParameterValue("Catname", StrRCatName)

                Case "312"
                    mod_ReportAttendance.newcaseClass.SetParameterValue("brName", StrRBranchName)
            End Select
            If StrSelectionFomula <> "" Then
                crptViewer.SelectionFormula = StrSelectionFomula
            End If

            crptViewer.ReportSource = mod_ReportAttendance.newcaseClass 'cryRpt

            crptViewer.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        '0762244136
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub
End Class