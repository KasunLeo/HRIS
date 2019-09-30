Public Class mod_ReportAttendance

    Public Shared newcaseClass
    Public Shared rcPath As Boolean = False
    Public Shared ReportID As String = ""

    Public Shared Function reportselecting(ByVal RepID As String)

        rcPath = True
        If rcPath = True Then
            If RepID = "001" Then
                newcaseClass = New rpt_HeadCount_Dept
            ElseIf RepID = "021" Then
                newcaseClass = New rpt_EmployeeINOUTOT
            ElseIf RepID = "031" Then
                newcaseClass = New rpt_HeadCount_DeptAB
            ElseIf RepID = "032" Then
                newcaseClass = New rpt_EmployeeLateEarly_Report
            ElseIf RepID = "019" Then
                'newcaseClass = New rpt_movement
            ElseIf RepID = "016" Then
                'newcaseClass = New rpt_AttendanceSummary
                Dim iGap As Integer = DateDiff(DateInterval.Day, dtRepGStart, dtRepGEnd) + 1

                Select Case iGap
                    Case 28
                        newcaseClass = New crosstab28
                    Case 29
                        newcaseClass = New crosstab29
                    Case 30
                        newcaseClass = New crosstab30
                    Case 31
                        newcaseClass = New crosstab31
                End Select

            ElseIf RepID = "015" Then
                newcaseClass = New rpt_OTAllSummary
            ElseIf RepID = "007" Then
                newcaseClass = New rpt_EmpAbsAnlisys_Dept
            ElseIf RepID = "008" Then
                newcaseClass = New rpt_LeaveRep_Dept
            ElseIf RepID = "009" Then
                newcaseClass = New rpt_LeaveBalReport
            ElseIf RepID = "011" Then
                newcaseClass = New rpt_EmpInfo_Dept
            ElseIf RepID = "022" Then
                If intIsExtSumRep = 0 Then
                    newcaseClass = New rpt_PayrollSummary
                Else
                    newcaseClass = New rpt_PayrollSummary_New
                End If

              
            ElseIf RepID = "012" Then
                'newcaseClass = New rpt_Manual
            ElseIf RepID = "014" Then
                newcaseClass = New rpt_DeptSummary
            ElseIf RepID = "037" Then
                newcaseClass = New rpt_RosterView
            ElseIf RepID = "029" Then
                newcaseClass = New rpt_EmployeeINOUTOTASum
            ElseIf RepID = "039" Then
                newcaseClass = New rpt_TurnOverReport
            ElseIf RepID = "040" Then
                newcaseClass = New rpt_OTCostingR
            ElseIf RepID = "041" Then
                newcaseClass = New rpt_EmployeeINOUTOTOnly
            ElseIf RepID = "042" Then
                newcaseClass = New rpt_AttendanceSummary
            ElseIf RepID = "043" Then
                newcaseClass = New rptManualAdjustReport
            ElseIf RepID = "044" Then
                newcaseClass = New rpt_TimeBaseHC
            ElseIf RepID = "046" Then
                newcaseClass = New rptDepartmentAndCategoryViseAttendan
            ElseIf RepID = "047" Then
                newcaseClass = New rptDepartmentCategorAttendan
            ElseIf RepID = "048" Then
                newcaseClass = New rptDepartViseAttendan
            ElseIf RepID = "049" Then
                newcaseClass = New rptCategoryViseAttendan
            ElseIf RepID = "050" Then
                newcaseClass = New rptAllLeaveBalance
            ElseIf RepID = "051" Then
                newcaseClass = New rpt_EmplINOUTOTSinglk
            ElseIf RepID = "052" Then
                newcaseClass = New rpt_EmpAbType_Dept
            ElseIf RepID = "053" Then
                newcaseClass = New rptDepShiftAndCatViseAttendan
            ElseIf RepID = "055" Then
                newcaseClass = New rptDepDayAndAttendan
            ElseIf RepID = "056" Then
                newcaseClass = New rptOTAutorideNaration
            ElseIf RepID = "060" Then
                newcaseClass = New rpt_PresentINOUTOT
            ElseIf RepID = "061" Then
                newcaseClass = New rpt_AbsentOUTOT
            ElseIf RepID = "062" Then
                newcaseClass = New rpt_OTNarrationEmployee
            ElseIf RepID = "065" Then
                newcaseClass = New rptNewTimesheet
            ElseIf RepID = "066" Then
                'newcaseClass = New rpt_AttendanceSummary
                Dim iGap As Integer = DateDiff(DateInterval.Day, dtRepGStart, dtRepGEnd) + 1

                Select Case iGap
                    Case 28
                        newcaseClass = New crosstab28Legal
                    Case 29
                        newcaseClass = New crosstab29Legal
                    Case 30
                        newcaseClass = New crosstab30Legal
                    Case 31
                        newcaseClass = New crosstab31Legal
                End Select
            ElseIf RepID = "067" Then
                Dim dr As DialogResult = MessageBox.Show("Do you want to print ID card with photograph ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If dr = DialogResult.Yes Then
                    newcaseClass = New rptEmiIDCard
                Else
                    newcaseClass = New rptEmSimpIDCard
                End If
           


            ElseIf RepID = "068" Then
                newcaseClass = New rpt_EmpResignList
            ElseIf RepID = "069" Then
                newcaseClass = New rpt_EmpJoinList

            ElseIf RepID = "070" Then ' OT Report
                newcaseClass = New rptBataReport
            ElseIf RepID = "071" Then ' OT Actual Absent
                newcaseClass = New rpt_ActualAbsent
            ElseIf RepID = "072" Then ' Confirmation due
                newcaseClass = New rpt_Confirm_Due_Report
            ElseIf RepID = "073" Then ' Gender and category wise
                newcaseClass = New rptGenderWiseCat
            ElseIf RepID = "074" Then
                newcaseClass = New rptRejoinedEmployee
            ElseIf RepID = "075" Then
                newcaseClass = New rptMovementLog
            ElseIf RepID = "076" Then
                newcaseClass = New rptRelatonship
            ElseIf RepID = "077" Then
                newcaseClass = New rpt_LeaveTypewise
            ElseIf RepID = "078" Then
                newcaseClass = New crosstab15Legal
            ElseIf RepID = "079" Then
                'BOC Wanted to display all employees as list and want to Approved OT display as OT
                Dim iGap As Integer = DateDiff(DateInterval.Day, dtRepGStart, dtRepGEnd) + 1

                Select Case iGap
                    Case 28
                        newcaseClass = New crosstab28ApprovedOT
                    Case 29
                        newcaseClass = New crosstab29ApprovedOT
                    Case 30
                        newcaseClass = New crosstab30ApprovedOT
                    Case 31
                        newcaseClass = New crosstab31ApprovedOT
                End Select

            ElseIf RepID = "080" Then
                newcaseClass = New rpt_lINOUTOTSinglkLand
            ElseIf RepID = "081" Then
                newcaseClass = New rptTypeViseAttendan
            ElseIf RepID = "082" Then
                newcaseClass = New rpt_AbsentDeatilsReport_PRA
            ElseIf RepID = "083" Then
                newcaseClass = New rpt_AbsentSummaryReport_PRA
            ElseIf RepID = "084" Then
                newcaseClass = New rpt_approvalOT
            ElseIf RepID = "085" Then
                newcaseClass = New rptGenderWiseAll 'Gender wise all employee
          

                'unauthorised nopay prasanna
            ElseIf RepID = "086" Then
                newcaseClass = New rpt_UnauthorisedNoPayReport
            ElseIf RepID = "087" Then
                newcaseClass = New rpt_EmpIDCard_Fantasia
            ElseIf RepID = "088" Then
                newcaseClass = New rpt_EmployeeProfileInformation
                'Kasun | 2018-11-02 | based on lake house | this report will display leave category wise summary for each month of the year-----------------------
            ElseIf RepID = "090" Then 'First nopay
                newcaseClass = New rpt_LeaveAllReport
                'Kasun | 2018-11-02 | based on lake house | this report will display leave category wise summary for each month of the year-----------------------

                'Prasannas code by Kasun|2018-11-08|Add new report for fantasia***************************
            ElseIf RepID = "091" Then
                newcaseClass = New rpt_EmployeeTimeCardOT
                'Prasannas code by Kasun|2018-11-08|Add new report for fantasia***************************

                'Kasun | 2018-05-15 | based on sun match | this report will display -----------------------
            ElseIf RepID = "092" Then 'Vacation of post
                newcaseClass = New rptVOP
            ElseIf RepID = "093" Then 'Late of post
                newcaseClass = New rptVOPLatek
            ElseIf RepID = "094" Then 'First nopay
                newcaseClass = New rptVOPFirstNopay
                'Kasun | 2018-05-15 | based on sun match | this report will display -----------------------

            ElseIf RepID = "301" Then ' Employee Maste File
                newcaseClass = New EmployeeMasterF
            ElseIf RepID = "302" Then ' Fantasia Head COUnt Report I
                newcaseClass = New HeadCountR_I
            ElseIf RepID = "303" Then ' Fantasia Head Count report II
                newcaseClass = New HeadCountR_II
            ElseIf RepID = "304" Then ' Fantasia Head Count report III
                newcaseClass = New HeadCountR_III
            ElseIf RepID = "305" Then ' Fantasia Head Count report III
                newcaseClass = New EmployeeServiceRV1
            ElseIf RepID = "306" Then

            ElseIf RepID = "307" Then

            ElseIf RepID = "308" Then
                newcaseClass = New MonthlyAbsRV1
            ElseIf RepID = "309" Then
                newcaseClass = New DailyAbsRV1
            ElseIf RepID = "310" Then
                newcaseClass = New DailyAbsNCity
            ElseIf RepID = "311" Then
                newcaseClass = New TerminationRep
            ElseIf RepID = "V01" Then ' Appointment letter
                newcaseClass = New AppLetterV2
            ElseIf RepID = "V02" Then ' VOP Letter 1 1st Reminding Letter on absent 
                newcaseClass = New VOPLetter1
            ElseIf RepID = "V03" Then ' VOP Letter 2 2nd Reminding Letter ON asbent 
                newcaseClass = New VOPLetter2
                'Ethical OT Report------------------------------------
            ElseIf RepID = "810" Then
                newcaseClass = New tblComplReport1
            ElseIf RepID = "811" Then
                newcaseClass = New rpt_ETCTimeSheet
            ElseIf RepID = "812" Then
                newcaseClass = New rpt_EthicalOUTOTSinglk
                'Ethical OT Report------------------------------------
            End If

        Else
            If RepID = "001" Then
                newcaseClass = New rpt_HeadCount_Cat
            ElseIf RepID = "021" Then
                newcaseClass = New rpt_EmployeeINOUTOT
            ElseIf RepID = "031" Then
                newcaseClass = New rpt_HeadCount_Cat
            ElseIf RepID = "019" Then
                newcaseClass = New rpt_movement
            ElseIf RepID = "016" Then
                newcaseClass = New rpt_AttendanceSummary
            ElseIf RepID = "015" Then
                newcaseClass = New rpt_OTAllSummary
            ElseIf RepID = "007" Then
                newcaseClass = New rpt_EmpAbsAnlisys_Cat
            ElseIf RepID = "008" Then
                'newcaseClass = New rpt_LeaveRep_Cat
            ElseIf RepID = "009" Then
                'newcaseClass = New rpt_LeaveReport_Cat
            ElseIf RepID = "011" Then
                newcaseClass = New rpt_EmpInfo_Cat
            ElseIf RepID = "022" Then
                If intIsExtSumRep = 0 Then
                    newcaseClass = New rpt_PayrollSummary
                Else
                    newcaseClass = New rpt_PayrollSummary_New
                End If
            ElseIf RepID = "012" Then
                newcaseClass = New rpt_Manual
            ElseIf RepID = "014" Then
                newcaseClass = New rpt_DeptSummary
            ElseIf RepID = "037" Then
                newcaseClass = New rpt_RosterView
            ElseIf RepID = "029" Then
                newcaseClass = New rpt_EmployeeINOUTOTASum
            ElseIf RepID = "040" Then
                newcaseClass = New rpt_OTCostingR
            ElseIf RepID = "041" Then
                newcaseClass = New rpt_EmployeeINOUTOTOnly
            ElseIf RepID = "044" Then
                newcaseClass = New rpt_TimeBaseHC
            End If

        End If

    End Function

End Class
