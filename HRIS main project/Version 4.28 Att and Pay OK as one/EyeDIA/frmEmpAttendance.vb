Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports System.Configuration

Public Class frmEmpAttendance

    Private Sub frmEmpAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
        'CenterFormThemed(Me, Panel1, Label25)
        'Me.BackColor = clrFocused

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)

    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown

    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    'End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim iCOl As Integer = 0
        Dim StrCol As String
        Dim StrConN As String
        Dim StrLvType As String
        'Generate Datagrid Column Structure 
        With dgvCals
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("Mnth", "Date")
            .Columns(0).Width = 55
            .Columns(0).Frozen = True
            For iCOl = 1 To 12

                StrCol = "D" & iCOl.ToString
                StrConN = MonthName(iCOl)
                .Columns.Add(StrCol, StrConN)
                .Columns(iCOl).Width = 78
            Next

            'Add 31 Rows
            Dim IRw As Integer
            For IRw = 1 To 31
                .Rows.Add(IRw, "", "", "", "", "", "", "", "", "", "", "", "")
                '.BackgroundColor = Color.Black

            Next
            Dim iX As Integer
            Dim iY As Integer
            For iX = 0 To .Columns.Count - 1
                For iY = 0 To .RowCount - 1
                    .Item(iX, iY).Style.BackColor = Color.DimGray
                Next
            Next
        End With

        'Open Date Order By Month
        Dim cnLoad As New SqlConnection(sqlConString)
        cnLoad.Open()
        Dim dtDate As Date
        Dim iMonth As Integer
        Dim dtDay As Integer
        Dim intType As Integer
        Dim StrADisp As String
        Dim StrLvD As String
        Dim dblWorkHrs As Double = 0
        Dim sqlQ As String = "SELECT AtDate,cMonth,case when antstatus=0 and isleave=0 then 2 when antstatus=0 and isleave=1 then 3 when autoLeaveNo<>0 then 4 when antStatus=1 then 1 end 'AntStatus',LeaveID,workHrs FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND cYear = " & intCurrentYear & " AND CompID = '" & StrCompID & "' Order By DayID"
        Try
            Dim cmLoad As New SqlCommand(sqlQ, cnLoad)
            Dim drLoad As SqlDataReader = cmLoad.ExecuteReader
            Do While drLoad.Read = True
                dtDate = IIf(IsDBNull(drLoad.Item("AtDate")), DateSerial(1900, 1, 1), drLoad.Item("atDate"))
                iMonth = IIf(IsDBNull(drLoad.Item("cMonth")), DateSerial(1900, 1, 1), drLoad.Item("cMonth"))
                dtDay = CInt(Format(dtDate, "dd"))
               
                intType = IIf(IsDBNull(drLoad.Item("AntStatus")), DateSerial(1900, 1, 1), drLoad.Item("AntStatus"))
                StrADisp = fk_RtDayType(intType)
                StrLvType = IIf(IsDBNull(drLoad.Item("LeaveID")), "", drLoad.Item("LeaveID"))
                StrLvD = fk_RetString("SELECT LvDesc FROM tblLeaveType WHERE LvID = '" & StrLvType & "'")
                StrLvD = get_FirstLetter(StrLvD)
                dblWorkHrs = IIf(IsDBNull(drLoad.Item("workHrs")), "", drLoad.Item("workHrs"))

                With dgvCals

                    If dblWorkHrs <> 0 Then
                        .Item(iMonth, dtDay - 1).Value = dblWorkHrs
                    End If
                    '.Item(0, 0).Value = Format(dtDate, "yyyy/MM/dd")
                    '.Item(iMonth, dtDay - 1).Value = StrLvD
                    Select Case StrADisp

                        Case "XX" 'No any record
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.White
                        Case "PR"
                            .Item(iMonth, dtDay - 1).Style.BackColor = clrFocused
                        Case "AB"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.White
                        Case "LV"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Green
                        Case "NP"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Red
                        Case "ER"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Blue

                    End Select

                End With
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnLoad.Close()
        End Try

        pnlChart.Visible = False
        dgvCals.Visible = True

    End Sub

    Public Function fk_RtDayType(ByVal StrT As Double) As String
        Dim StrR As String
        Select Case StrT
            Case 0 ' Not Updated
                StrR = "XX"
            Case 1 'Mark Present
                StrR = "PR"
            Case 2 'Absent
                StrR = "AB"
            Case 3 'Process Leave
                StrR = "LV"
            Case 4 '
                StrR = "NP"
            Case Else 'if not all above
                StrR = "ER"
        End Select
        Return StrR

    End Function

    Private Sub btnChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChart.Click
        dgvCals.Visible = False
        pnlChart.Visible = True
        sSQL = "create table tblEmpChart (empID nvarchar (6),atDate datetime,cMonth  numeric(18,0) not null default 0,antStatus numeric (18,0) not null default 0,workDay numeric (18,0) not null default 0,isLeave numeric (18,0) not null default 0)"
        FK_EQ(sSQL, "P", "", False, False, False)
        chartEmployeeSummary()
        chartMonth()
    End Sub

    Public Sub chartEmployeeSummary()

        Try
            'chartEmployee.BackImage = strChartPath
            'chartEmployee.ChartAreas("ChartArea1").BackImage = strChartPath
            'chartEmployee.Legends(0).BackImage = strChartPath
            chartEmployee.Titles(0).ForeColor = clrFocused
            Dim customPalette(3) As Color
            customPalette(0) = clrFocused
            customPalette(1) = Color.LightGray
            customPalette(2) = Color.Black
            chartEmployee.Palette = ChartColorPalette.None
            chartEmployee.PaletteCustomColors = customPalette

            Dim wcconn As New SqlClient.SqlConnection(sqlConString)
            Dim wcCommand As New SqlClient.SqlCommand
            Dim dtFirstDay As Date = New Date(intCurrentYear, 1, 1)
            Dim wcQuery = "delete from tblEmpChart " & _
            "insert into tblEmpChart select tblEmpRegister.empid,tblEmpRegister.atDate,tblEmpRegister.cMonth,tblEmpRegister.antstatus, " & _
            "case when tblDayType.WorkUnit = 1 then '1'  WHEN tblDayType.WorkUnit = .5 then'1' else '0' end,isLeave from " & _
            "tblempregister left outer join tblDayType on tblEmpRegister.dayTypeID = tblDayType.TypeID  where " & _
            "tblEmpRegister.empid='" & StrEmployeeID & "'   AND  " & _
            "tblEmpRegister.cYear = '" & intCurrentYear & "' AND tblEmpRegister.CompID = '" & StrCompID & "' Order By tblEmpRegister.atdate " & _
            "select empid as 'tt',sum(antstatus) as 'num' from tblEmpChart where atdate between '" & Format(dtFirstDay, "yyyyMMdd") & "' and  '" & Format(dtWorkingDate, "yyyyMMdd") & "'  group by empid "
            wcCommand.Connection = wcconn
            wcCommand.CommandText = wcQuery

            Dim wcAdapter As New SqlClient.SqlDataAdapter
            Dim wcData As New DataSet
            wcAdapter.SelectCommand = wcCommand
            wcAdapter.Fill(wcData, "tab01")

            'wcQuery = "select convert (varchar(10),atdate,101) as 'tt2' ,count (empid) as 'num2'  FROM [tblEmpRegister] where (atdate = '" & dtWorkingDate.Date & "' ) and antstatus=1 group by atdate"
            wcQuery = "select empid  as 'tt2',sum(workDay)-sum(antstatus) as 'num2' from tblEmpChart group by empid"
            wcCommand.Connection = wcconn
            wcCommand.CommandText = wcQuery
            wcAdapter.SelectCommand = wcCommand
            wcAdapter.Fill(wcData, "tab01")

            wcQuery = "select empid  as 'tt3',sum(isLeave) as 'num3' from tblEmpChart group by empid"
            wcCommand.Connection = wcconn
            wcCommand.CommandText = wcQuery
            wcAdapter.SelectCommand = wcCommand
            wcAdapter.Fill(wcData, "tab01")

            chartEmployee.Series.Clear()
            chartEmployee.Series.Add("Series1")

            chartEmployee.Series("Series1").Points.AddXY("Worked Days : (" & wcData.Tables("tab01").Rows(0)("num").ToString & ")", wcData.Tables("tab01").Rows(0)("num").ToString)

            If wcData.Tables("tab01").Rows.Count > 1 Then

                chartEmployee.Series("Series1").Points.AddXY("Absent Days :  (" & IIf(wcData.Tables("tab01").Rows.Count = 1, "0", wcData.Tables("tab01").Rows(1)("num2").ToString) & ")", IIf(wcData.Tables("tab01").Rows.Count = 1, "0", wcData.Tables("tab01").Rows(1)("num2").ToString))
                chartEmployee.Series("Series1").Points.AddXY("Leave Days : (" & IIf(wcData.Tables("tab01").Rows.Count = 1, "0", wcData.Tables("tab01").Rows(2)("num3").ToString) & ")", IIf(wcData.Tables("tab01").Rows.Count = 1, "0", wcData.Tables("tab01").Rows(2)("num3").ToString))

            End If
            'ChartDay.Series("Series1").ShadowColor = Color.Gray
            'ChartDay.Series("Series2").ShadowColor = Color.Gray
            'ChartDay.Series("Series1").ShadowOffset = 4

            ' Set Doughnut chart type
            chartEmployee.Series("Series1").ChartType = strChartTypeDounut

            ' Set labels style
            chartEmployee.Series("Series1")("PieLabelStyle") = "Inside"

            ' Set Doughnut radius percentage
            chartEmployee.Series("Series1")("DoughnutRadius") = "50"

            ' Explode data point with label "Italy"
            'ChartDay.Series("Series1").Points(1)("Exploded") = "true"

            ' Enable 3D
            chartEmployee.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            ' Set drawing style
            chartEmployee.Series("Series1")("PieDrawingStyle") = "SoftEdge"

            chartEmployee.ChartAreas("ChartArea1").Area3DStyle.Inclination = 60

            chartEmployee.ChartAreas("ChartArea1").Area3DStyle.Rotation = 47

            'chartDay.ChartAreas("ChartArea1").InnerPlotPosition = New ElementPosition(0, 0, 100, 100)

            chartEmployee.ChartAreas("ChartArea1").Area3DStyle.PointDepth = 100

            chartEmployee.ChartAreas("ChartArea1").AxisX.IsMarginVisible = False

            chartEmployee.DataBind()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Sub chartMonth()

        Try
            'ChartMonthEmp.BackImage = strChartPath
            'ChartMonthEmp.ChartAreas("ChartArea1").BackImage = strChartPath
            ChartMonthEmp.Titles(0).ForeColor = clrFocused
            Dim customPalette(3) As Color
            customPalette(0) = clrFocused
            customPalette(1) = Color.LightGray
            ChartMonthEmp.Palette = ChartColorPalette.None
            ChartMonthEmp.PaletteCustomColors = customPalette

            Dim wcconn As New SqlClient.SqlConnection(sqlConString)
            Dim wcCommand As New SqlClient.SqlCommand

            Dim wcQuery = "select DateName( month , DateAdd( month , cMonth , 0 ) - 1 ) as 'atDate',sum(antstatus) as 'presentK',sum(workday)-sum(antstatus) as 'absentK',sum(isLeave) as 'leaveK' from tblEmpChart group by cMonth order by cMonth"
            '"select cMonth as 'atDate',sum(antstatus) as 'presentK',sum(workday)-sum(antstatus) as 'absentK',sum(isLeave) as 'leaveK' from tblEmpChart group by cMonth order by cMonth"

            wcCommand.Connection = wcconn
            wcCommand.CommandText = wcQuery

            Dim wcAdapter As New SqlClient.SqlDataAdapter
            Dim wcData As New DataSet
            wcAdapter.SelectCommand = wcCommand
            wcAdapter.Fill(wcData, "tab02")

            'wcQuery = "select convert (varchar(10),atdate,101) as 'tt2' ,count (empid) as 'num2'  FROM [tblEmpRegister] where (atdate between '" & dtWorkingDate.Date.AddDays(-7) & "' and '" & dtWorkingDate.Date & "') and antstatus=0 group by atdate"
            'wcCommand.Connection = wcconn
            'wcCommand.CommandText = wcQuery
            'wcAdapter.SelectCommand = wcCommand
            'wcAdapter.Fill(wcData, "tab01")

            ChartMonthEmp.Series("Series1").XValueMember = "atDate"
            ChartMonthEmp.Series("Series2").XValueMember = "atDate"
            ChartMonthEmp.Series("Series3").XValueMember = "atDate"
            ChartMonthEmp.Series("Series1").YValueMembers = "presentK"
            ChartMonthEmp.Series("Series2").YValueMembers = "absentK"
            ChartMonthEmp.Series("Series3").YValueMembers = "leaveK"

            ChartMonthEmp.ChartAreas("ChartArea1").AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Auto

            'ChartMonthEmp.Series("Series1").XValueType = DataVisualization.Charting.ChartValueType.Int32
            'ChartMonthEmp.Series("Series2").XValueType = DataVisualization.Charting.ChartValueType.Int32
            'ChartMonthEmp.Series("Series3").XValueType = DataVisualization.Charting.ChartValueType.Int32
            'ChartWeek.Series("Series1").Name = "Present"
            'ChartWeek.Series("Series2").Name = "Absent"

            ChartMonthEmp.Series(0).Points.AddXY("Present (" & wcData.Tables("tab02").Rows(0)("presentK").ToString & ")", wcData.Tables("tab02").Rows(0)("presentK").ToString)

            If wcData.Tables("tab02").Rows.Count > 1 Then

                ChartMonthEmp.Series(1).Points.AddXY("Absent (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("absentK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("absentK").ToString))
                ChartMonthEmp.Series(2).Points.AddXY("Leave (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(2)("leaveK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(2)("leaveK").ToString))

            End If

            ' Draw as 3D Cylinder
            'ChartWeek.Series(0)("DrawingStyle") = "Cylinder"
            'ChartWeek.Series(1)("DrawingStyle") = "Cylinder"

            ChartMonthEmp.Series(0).ChartType = strChartTypeBar
            ChartMonthEmp.Series(1).ChartType = strChartTypeBar
            ChartMonthEmp.Series(2).ChartType = strChartTypeBar

            ChartMonthEmp.DataSource = wcData.Tables("tab02")
            ' Set series point width
            ChartMonthEmp.Series(0)("PointWidth") = "0.5"
            ChartMonthEmp.Series(1)("PointWidth") = "0.4"
            ChartMonthEmp.Series(2)("PointWidth") = "0.3"

            ' Show chart with right-angled axes
            ChartMonthEmp.ChartAreas("ChartArea1").Area3DStyle.IsRightAngleAxes = True
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.LightStyle = LightStyle.Realistic
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.PointDepth = 55

            ChartMonthEmp.ChartAreas("ChartArea1").AxisX.LabelStyle.IsEndLabelVisible = False
            'ChartMonthEmp.ChartAreas("ChartArea1").AxisX.IsMarginVisible = False
            'ChartMonthEmp.ChartAreas("ChartArea1").AxisX.LabelAutoFitStyle = LabelAutoFitStyles.IncreaseFont

            ' Show columns as clustered
            ChartMonthEmp.ChartAreas("ChartArea1").Area3DStyle.IsClustered = False

            ' Show X axis end labels
            ChartMonthEmp.ChartAreas("ChartArea1").AxisX.LabelStyle.IsEndLabelVisible = True
            ChartMonthEmp.ChartAreas("ChartArea1").AxisY.Maximum = 31
            ChartMonthEmp.ChartAreas("ChartArea1").AxisX.Maximum = 12.5
            ' Set rotational angles
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Inclination = 30
            ChartMonthEmp.ChartAreas("ChartArea1").Area3DStyle.Inclination = 30

            ChartMonthEmp.ChartAreas("ChartArea1").AxisX.Interval = 1
            ChartMonthEmp.ChartAreas("ChartArea1").AxisY.Interval = 2

            ' Show as 3D
            ChartMonthEmp.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            ChartMonthEmp.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = 55
            'ChartMonthEmp.ChartAreas("ChartArea1").AxisX.LabelSty
            'Chart3.DataSource = wcData.Tables("tab02")
            ChartMonthEmp.DataBind()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    ' Mouse Down Event
    Private Sub chartEmployee_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chartEmployee.MouseDown

        ' Call Hit Test Method
        Dim result As HitTestResult = chartEmployee.HitTest(e.X, e.Y)

        Dim exploded As Boolean = False

        ' Check if data point is already exploded
        If result.PointIndex >= 0 Then

            If chartEmployee.Series("Series1").Points(result.PointIndex).CustomProperties = "Exploded=true" Then
                exploded = True
            Else
                exploded = False
            End If

        End If

        ' Remove all exploded attributes
        Dim point As DataPoint
        For Each point In chartEmployee.Series("Series1").Points
            point.CustomProperties = ""
        Next point

        ' If data point is already exploded get out.
        If exploded = False Then

            ' If data point is selected
            If result.ChartElementType = ChartElementType.DataPoint Then
                ' Set Attribute
                Dim pointk As DataPoint = chartEmployee.Series("Series1").Points(result.PointIndex)
                pointk.CustomProperties = "Exploded = true"
            End If


            ' If legend item is selected
            If result.ChartElementType = ChartElementType.LegendItem Then
                ' Set Attribute
                Dim pointl As DataPoint = chartEmployee.Series("Series1").Points(result.PointIndex)
                pointl.CustomProperties = "Exploded = true"
            End If

        End If

        If exploded = True Then

            ' If data point is selected
            If result.ChartElementType = ChartElementType.DataPoint Then
                ' Set Attribute
                Dim pointk As DataPoint = chartEmployee.Series("Series1").Points(result.PointIndex)
                pointk.CustomProperties = "Exploded = false"
            End If


            ' If legend item is selected
            If result.ChartElementType = ChartElementType.LegendItem Then
                ' Set Attribute
                Dim pointl As DataPoint = chartEmployee.Series("Series1").Points(result.PointIndex)
                pointl.CustomProperties = "Exploded = false"
            End If

        End If

    End Sub 'chartDay_MouseDown

End Class