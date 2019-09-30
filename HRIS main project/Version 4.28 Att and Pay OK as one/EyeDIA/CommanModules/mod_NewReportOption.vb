Public Class mod_NewReportOption
    Public Shared newcaseClass
    Public Shared rcPath As Boolean = False
    Public Shared ReportID As String = ""

    Public Shared Function reportselecting(ByVal RepID As String)

        rcPath = True
        If rcPath = True Then
            If RepID = "16" Then
                newcaseClass = New rptDynamicComBranchk
            ElseIf RepID = "26" Then
                newcaseClass = New rptLoanDetailedReport
            ElseIf RepID = "31" Then
                newcaseClass = New rptProfileReport2
            ElseIf RepID = "34" Then
                newcaseClass = New rptDynamicComptwoMonth
            ElseIf RepID = "36" Then
                newcaseClass = New rptProfileDepartment
            ElseIf RepID = "37" Then
                newcaseClass = New rptDynamicDepartmentCostingReport
            ElseIf RepID = "38" Then
                newcaseClass = New rptLoan
            ElseIf RepID = "40" Then
                newcaseClass = New rptDynamicEmpTypeCostingReport
            ElseIf RepID = "20" Then
                newcaseClass = New rptFixDeductionEmployeewise
            ElseIf RepID = "41" Then
                newcaseClass = New rptDynamicGenderCostingReport
            ElseIf RepID = "42" Then
                newcaseClass = New rptDynamicGenderDeptReport
            ElseIf RepID = "43" Then
                newcaseClass = New rptDynamicComGroup
            ElseIf RepID = "44" Then
                newcaseClass = New rptProfileReport3
            ElseIf RepID = "45" Then
                newcaseClass = New rptRequestDeductionBanked
            ElseIf RepID = "46" Then
                newcaseClass = New rptAnualPayrollReport
            ElseIf RepID = "47" Then
                newcaseClass = New rptRequestDeductionSummary
            ElseIf RepID = "48" Then
                newcaseClass = New rptRequestDeductionBankTransferSummary
            ElseIf RepID = "50" Then
                newcaseClass = New rptDynamicComptwoMonthDept
            ElseIf RepID = "51" Then
                newcaseClass = New rptDynamicDepartmentCostingReportA3
            ElseIf RepID = "56" Then
                newcaseClass = New rptDynamicBranchCostingReport
            ElseIf RepID = "57" Then
                newcaseClass = New rptDynamicDepartmentCostingReportk
            ElseIf RepID = "58" Then
                newcaseClass = New rptDynamicCategoryCostingRep ' remove count
            ElseIf RepID = "59" Then
                newcaseClass = New rptDynamicCategoryCostingReportCount 'c
            ElseIf RepID = "60" Then
                newcaseClass = New rptDynamicBranchCostingRep 'check group 
            ElseIf RepID = "61" Then
                newcaseClass = New rptDynamicBranchCostingReportCount 'dont group to branch
            ElseIf RepID = "62" Then
                'Employee category wise profile
                newcaseClass = New rptProfileReport4
            ElseIf RepID = "100" Then
                newcaseClass = New rpt_DeptWiseSummary
            ElseIf RepID = "101" Then
                newcaseClass = New rpt_EmployeewisePS
            ElseIf RepID = "102" Then
                newcaseClass = New rpt_DeptWiseSummaryCX
            End If
        Else

        End If

    End Function


End Class
