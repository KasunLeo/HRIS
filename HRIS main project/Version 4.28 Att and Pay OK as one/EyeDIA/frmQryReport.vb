Public Class frmQryReport

    Dim thread As System.Threading.Thread
    Dim intcolomncount As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rdbLetter.Checked = True Then
            Create_Report_Kasun()
            rdbLetter.Enabled = False
            rdbNOT.Enabled = False
            'thread = New System.Threading.Thread((AddressOf Create_Report_Kasun))
            'thread.Start()
        ElseIf rdbNOT.Checked = True Then
            Create_Report_OT()
            rdbLetter.Enabled = False
            rdbNOT.Enabled = False 'thread = New System.Threading.Thread((AddressOf Create_Report_OT))
            'thread.Start()
        ElseIf rdbDOT.Checked = True Then
            Create_Report_DOT()
            rdbLetter.Enabled = False
            rdbNOT.Enabled = False 'thread = New System.Threading.Thread((AddressOf Create_Report_OT))

        Else
            Create_Report()
            rdbLetter.Enabled = False
            rdbNOT.Enabled = False 'thread = New System.Threading.Thread((AddressOf Create_Report))
            'thread.Start()
        End If
    End Sub

    Public Sub Create_Report_DOT()
        Try
            Dim sqlTable As String
            sqlTable = "DROP TABLE tblkOTReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE TABLE tblkOTReport (EmpID Nvarchar (6),AtDate DateTime,PRAB numeric (18,2) not null default 0,DateCol numeric (18,2) not null default 0)" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "DROP PROC sp_CrossUpdate" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_CrossUpdate (@ColName Nvarchar (10),@RunDate DateTime)" & _
            " As BEGIN CREATE TABLE #T (EmpID Nvarchar (6),ColVal Nvarchar (100))" & _
            " INSERT INTO #T SELECT EmpID, DateCol FROM tblkOTReport WHERE AtDate = @RunDate" & _
            " Exec ('UPDATE tblInOutReport SET ' + @ColName + ' = #T.ColVal FROM #T,tblInOutReport WHERE #T.EmpID = tblInOutReport.EmpID') END" : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_GenReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_GenReport (@EmpID Nvarchar (6),@St DateTime, @Ed DateTime) As" & _
            " BEGIN INSERT INTO tblkOTReport SELECT @EmpID,tblCalendar.[Date],0,0 from tblCalendar WHERE [Date] Between @st AND @ed END " : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_OT_Report" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_OT_Report (@St DateTime,@Ed DateTime)" & _
            " As Begin  DELETE FROM tblkOTReport " & _
            " Declare @RegID nvarchar (6) Declare c Cursor for " & _
            " SELECT RegID FROM tblEmployee where empstatus <> '9' Open c" & _
            " Fetch next from c INTO @RegID " & _
            " WHILE @@Fetch_Status = 0 BEGIN  " & _
            " Exec sp_GenReport @RegID,@St,@Ed " & _
            " Fetch Next From c INTO @RegID END " & _
            " Close c Deallocate c  " & _
            "UPDATE tblkOTReport SET tblkOTReport.PRAB = tblEmpRegister.DoubleOTHrs FROM tblkOTReport,tblEmpRegister WHERE tblkOTReport.EmpID = tblEmpRegister.EMpID AND tblkOTReport.AtDate = tblEmpRegister.AtDate  AND tblEmpRegister.AtDate Between @St AND @Ed  " & _
            "UPDATE tblkOTReport SET DateCol = PRAB END" : FK_EQ(sqlTable, "S", "", False, False, False)

            PicKasun.Visible = True
            lblProcessing.Visible = True
            Button1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim intDayCount As Integer = 0 : Dim StrColString As String = "" : Dim dtRunDate As Date
            intDayCount = DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value)
            dtRunDate = dtpFromDate.Value : Dim intRunDay As Integer

            dgvReportG.Columns.Clear()

            With dgvReportG
                .Columns.Add("EmpID", "Emp ID")
                '.Columns.Add("WrkDays", "Worked Days")
                '.Columns.Add("OTHrs", "OT Hours")
            End With

            Dim sqlQRY As String
            sqlQRY = "EXEC sp_OT_Report '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "DROP TABLE tblInOutReport " : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "CREATE TABLE tblInOutReport (EmpID Nvarchar (6),EmpName nvarchar (226),totOT numeric (18,2) not null default 0)" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "INSERT INTO tblInOutReport SELECT tblkOTReport.EmpID,tblemployee.dispName,sum(tblkOTReport.PRAB) FROM tblkOTReport INNER JOIN tblemployee ON tblemployee.RegID=tblkOTReport.EmpID GROUP BY tblkOTReport.EmpID,tblemployee.dispName" : FK_EQ(sqlQRY, "S", "", False, False, True)

            sqlQRY = ""
            For i As Integer = 0 To intDayCount
                intRunDay = i + 1
                StrColString = "Day" & intRunDay.ToString
                DataGridView1.Rows.Add(dtRunDate.ToString, StrColString)
                sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Nvarchar (100) NOT NULL Default ''"
                dtRunDate = DateAdd(DateInterval.Day, 1, dtRunDate)
                dgvReportG.Columns.Add(StrColString, StrColString)
                dgvReportG.Columns(StrColString).DefaultCellStyle.WrapMode = DataGridViewTriState.True : dgvReportG.Columns(StrColString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgvReportG.RowTemplate.Height = 25
            FK_EQ(sqlQRY, "S", "", False, False, False)

            sSQL = "alter table tblInoutReport add SetofOTHours nvarchar (10) not null default ''"
            FK_EQ(sSQL, "S", "", False, False, False)
            'sqlQRY = ""
            'Dim sql As String = "SELECT LvID,LvDesc,shortcode FROM tblLeaveType WHERE Status = 0 Order By LvID"
            'Load_InformationtoGrid(sql, DataGridView2, 3)
            'With DataGridView2
            '    For iL As Integer = 0 To .RowCount - 1
            '        StrColString = .Item(2, iL).Value
            '        If StrColString <> "" Then
            '            sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Numeric (18,2) NOT NULL Default 0;"
            '        End If
            '    Next
            'End With
            'FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = ""
            With DataGridView1
                For i As Integer = 0 To .RowCount - 1
                    Dim StrColName As String = ""
                    StrColName = .Item(1, i).Value : dtRunDate = .Item(0, i).Value
                    sqlQRY = sqlQRY & "Exec sp_CrossUpdate '" & StrColName & "','" & Format(dtRunDate, "yyyyMMdd") & "'"
                Next
            End With
            FK_EQ(sqlQRY, "P", "", False, True, True)

            ''Update Leave Summary to the Main Table 
            'With DataGridView2
            '    For iL As Integer = 0 To .RowCount - 1
            '        Dim StrLvCode As String = .Item(0, iL).Value
            '        Dim StrShCode As String = .Item(2, iL).Value
            '        sqlQRY = "CREATE TABLE #T (EMpID Nvarchar (6),LvID Nvarchar (3),NoLv Numeric (18,2))"
            '        sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblLeaveTRD.EmpID,tblLeaveTRD.LvType,Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRH,tblLeaveTRD WHERE (tblLeaveTRH.EmpID = tblLeaveTRD.EmpID AND tblLeaveTRH.RqID = tblLeaveTRD.RqID) AND tblLeaveTRD.LvDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRD.LvType = '" & StrLvCode & "'  GROUP BY tblLeaveTRD.EmpID,tblLeaveTRD.LvType"
            '        sqlQRY = sqlQRY & " UPDATE tblInOutReport SET tblInOutReport." & StrShCode & " = #T.NoLv FROM #T,tblInOutReport WHERE #T.EMpID = tblInOutReport.EmpID"
            '        FK_EQ(sqlQRY, "S", "", False, False, True)
            '    Next
            'End With

            dgvReportG.Columns.Clear()

            Dim ColVal As Integer = CInt(dgvReportG.Columns.Count) + (DataGridView2.RowCount)
            Fk_FillGrid("SELECT * FROM tblInOutReport Order By EmpID", dgvReportG)

            With dgvReportG
                For i As Integer = 0 To dgvReportG.Columns.Count - 1
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End With

            intcolomncount = dgvReportG.ColumnCount
            PicKasun.Visible = False
            lblProcessing.Visible = False
            lblCoun.Text = "Total Records " & dgvReportG.RowCount
            Button3.Enabled = True
            dgvReportG.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub Create_Report()
        Try
            Dim sqlTable As String
            sqlTable = "DROP TABLE tblMReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE TABLE tblMReport (EmpID Nvarchar (6),AtDate DateTime,PRAB Nvarchar (10),WHours Numeric (18,2),TimeS Nvarchar (20),DateCol Nvarchar (40))" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "DROP PROC sp_CrossUpdate" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_CrossUpdate (@ColName Nvarchar (10),@RunDate DateTime)" & _
            " As BEGIN CREATE TABLE #T (EmpID Nvarchar (6),ColVal Nvarchar (100))" & _
            " INSERT INTO #T SELECT EmpID, DateCol FROM tblMReport WHERE AtDate = @RunDate" & _
            " Exec ('UPDATE tblInOutReport SET ' + @ColName + ' = #T.ColVal FROM #T,tblInOutReport WHERE #T.EmpID = tblInOutReport.EmpID') END" : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_GenReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_GenReport (@EmpID Nvarchar (6),@St DateTime, @Ed DateTime) As" & _
            " BEGIN INSERT INTO tblMReport SELECT @EmpID,tblCalendar.[Date],'',0,'','' from tblCalendar WHERE [Date] Between @st AND @ed END " : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_Run1" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_Run1 (@St DateTime,@Ed DateTime)" & _
            " As Begin  DELETE FROM tblMReport " & _
            " Declare @RegID nvarchar (6) Declare c Cursor for " & _
            " SELECT RegID FROM tblEmployee where empstatus <> '9' Open c" & _
            " Fetch next from c INTO @RegID " & _
            " WHILE @@Fetch_Status = 0 BEGIN  " & _
            " Exec sp_GenReport @RegID,@St,@Ed " & _
            " Fetch Next From c INTO @RegID END " & _
            " Close c Deallocate c  " & _
            " UPDATE tblMReport SET tblMReport.PRAB = CASE WHEN tblEmpRegister.AntStatus = 1 THEN Convert(Nvarchar(10),tblEmpRegister.WorkHrs) Else CASE WHEN tblDayType.WorkUnit = 0 THEN 'OFF' ELSE 'AB' END END FROM tblMReport,tblEmpRegister,tblDayType WHERE tblMReport.EmpID = tblEmpRegister.EMpID AND tblMReport.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.DayTypeID = tblDayType.TypeID  AND tblEmpRegister.AtDate Between @St AND @Ed " & _
            " CREATE TABLE #T1 (EmpID Nvarchar (6),AtDate DateTime, WrkTime Nvarchar (40))" & _
            " INSERT INTO #T1 SELECT EmpID,AtDate,Convert(nvarchar(5),inTime1,108) + Char(13)+ Convert(nvarchar(5),OutTime1 ,108)from tblEmpRegister WHERE AtDate Between @St AND @ed" & _
            " UPDATE tblMReport SET tblMReport.TimeS = #T1.WrkTime FROM #T1,tblMReport WHERE #T1.EmpID = tblMReport.EmpID AND #T1.AtDate =tblMReport.AtDate " & _
            " UPDATE tblMReport SET tblMReport.WHours = tblEmpRegister.NRWorkDay FROM tblEmpRegister,tblMReport WHERE tblEmpRegister.EmpID = tblMReport.EmpID AND tblEmpRegister.AtDate = tblMReport.AtDate " & _
            " UPDATE tblMReport SET DateCol = CASE WHEN PRAB = 'OFF' THEN 'OFF' WHEN PRAB= 'AB' THEN 'AB' ELSE Convert(Nvarchar(5),WHours)+' '+Char(13)+PRAB+' ' + Char(13)+ TimeS END END " : FK_EQ(sqlTable, "S", "", False, False, False)

            PicKasun.Visible = True
            lblProcessing.Visible = True
            Button1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim intDayCount As Integer = 0 : Dim StrColString As String = "" : Dim dtRunDate As Date
            intDayCount = DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value)
            dtRunDate = dtpFromDate.Value : Dim intRunDay As Integer

            dgvReportG.Columns.Clear()

            With dgvReportG
                .Columns.Add("EmpID", "Emp ID")
                .Columns.Add("dspNAme", "Employee Name")
                .Columns.Add("WrkDays", "Worked Days")
                .Columns.Add("OTHrs", "OT Hours")
            End With

            Dim sqlQRY As String
            sqlQRY = "EXEC sp_Run1 '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "DROP TABLE tblInOutReport " : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "CREATE TABLE tblInOutReport (EmpID Nvarchar (6),empName nvarchar (226),WrkedDays Numeric (18,2),OTHours Numeric (18,2))" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "INSERT INTO tblInOutReport SELECT tblMReport.EmpID,tblemployee.dispName,sum(tblMReport.WHOurs),0 FROM tblMReport INNER JOIN tblemployee ON tblemployee.RegID=tblMReport.EmpID GROUP BY tblMReport.EmpID,tblemployee.dispName" : FK_EQ(sqlQRY, "S", "", False, False, True)

            sqlQRY = ""
            For i As Integer = 0 To intDayCount
                intRunDay = i + 1
                StrColString = "Day" & intRunDay.ToString
                DataGridView1.Rows.Add(dtRunDate.ToString, StrColString)
                sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Nvarchar (100) NOT NULL Default ''"
                dtRunDate = DateAdd(DateInterval.Day, 1, dtRunDate)
                dgvReportG.Columns.Add(StrColString, StrColString)
                dgvReportG.Columns(StrColString).DefaultCellStyle.WrapMode = DataGridViewTriState.True : dgvReportG.Columns(StrColString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgvReportG.RowTemplate.Height = 60

            FK_EQ(sqlQRY, "S", "", False, False, False)

            sqlQRY = ""
            With DataGridView1
                For i As Integer = 0 To .RowCount - 1
                    Dim StrColName As String = ""
                    StrColName = .Item(1, i).Value : dtRunDate = .Item(0, i).Value
                    sqlQRY = sqlQRY & "Exec sp_CrossUpdate '" & StrColName & "','" & Format(dtRunDate, "yyyyMMdd") & "'"
                Next
            End With
            FK_EQ(sqlQRY, "P", "", False, True, True)
            Cursor.Current = Cursors.Default

            Dim ColVal As Integer = dgvReportG.Columns.Count
            Load_InformationtoGrid("SELECT * FROM tblInOutReport Order By EmpID", dgvReportG, ColVal)
            With dgvReportG
                For i As Integer = 0 To .Columns.Count - 1
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End With
            intcolomncount = dgvReportG.ColumnCount
            PicKasun.Visible = False
            lblProcessing.Visible = False
            lblCoun.Text = "Total Records " & dgvReportG.RowCount
            Button3.Enabled = True
            dgvReportG.Cursor = Cursors.Default
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub frmQryReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, pnlTop, Label13)
        ControlHandlers(Me)
        CheckForIllegalCrossThreadCalls = False
        Dim dtLastDate As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        dtpFromDate.Value = DateSerial(Year(dtLastDate), Month(dtLastDate), 1)
        dtpToDate.Value = dtLastDate
    End Sub

    Private Sub dtpFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromDate.ValueChanged
        dtpToDate.Value = DateSerial(dtpFromDate.Value.Year, dtpFromDate.Value.Month + 1, 0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("Are you sure you want to Export this Data to Excel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        ExporttoExcel(dgvReportG, intcolomncount)
        Button3.Enabled = False
    End Sub

    Public Sub Create_Report_Kasun()
        Try
            Dim strShortCode As String = fk_RetString("select shortcode from tbldaytype") : If strShortCode = "" Then MessageBox.Show("Please set short code in calendar settings before try this report", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : LoadForm(New frmCalendar) : Exit Sub
            Dim strShortCodeLeave As String = fk_RetString("select shortcode from tblleavetype") : If strShortCodeLeave = "" Then MessageBox.Show("Please set short code in Leave settings before try this report", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : LoadForm(New frmSetLeaveType) : Exit Sub

            Dim sqlTable As String
            sqlTable = "DROP TABLE tblkReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE TABLE tblkReport (EmpID Nvarchar (6),AtDate DateTime,PRAB Nvarchar (10),TimeS Nvarchar (20),wrkDay numeric (18,0) not null default 0,DateCol Nvarchar (40))" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "DROP PROC sp_CrossUpdate" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_CrossUpdate (@ColName Nvarchar (10),@RunDate DateTime)" & _
            " As BEGIN CREATE TABLE #T (EmpID Nvarchar (6),ColVal Nvarchar (100))" & _
            " INSERT INTO #T SELECT EmpID, DateCol FROM tblkReport WHERE AtDate = @RunDate" & _
            " Exec ('UPDATE tblInOutReport SET ' + @ColName + ' = #T.ColVal FROM #T,tblInOutReport WHERE #T.EmpID = tblInOutReport.EmpID') END" : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_GenReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_GenReport (@EmpID Nvarchar (6),@St DateTime, @Ed DateTime) As" & _
            " BEGIN INSERT INTO tblkReport SELECT @EmpID,tblCalendar.[Date],'','',0,'' from tblCalendar WHERE [Date] Between @st AND @ed END " : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_Run_Report" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_Run_Report (@St DateTime,@Ed DateTime)" & _
            " As Begin  DELETE FROM tblkReport " & _
            " Declare @RegID nvarchar (6) Declare c Cursor for " & _
            " SELECT RegID FROM tblEmployee where empstatus <> '9' Open c" & _
            " Fetch next from c INTO @RegID " & _
            " WHILE @@Fetch_Status = 0 BEGIN  " & _
            " Exec sp_GenReport @RegID,@St,@Ed " & _
            " Fetch Next From c INTO @RegID END " & _
            " Close c Deallocate c  " & _
            "UPDATE tblkReport SET tblkReport.PRAB = CASE WHEN tblEmpRegister.AntStatus = 1 THEN tblDayType.shortcode Else CASE WHEN tblDayType.WorkUnit = 0 THEN tblDayType.shortcode ELSE CASE WHEN tblDayType.WorkUnit = 0.5 THEN tblDayType.shortcode else 'OFF'  END END END,tblkReport.wrkDay=tblempregister.NRworkDay  FROM tblkReport,tblEmpRegister,tblDayType WHERE tblkReport.EmpID = tblEmpRegister.EMpID AND tblkReport.AtDate = tblEmpRegister.AtDate AND tblEmpRegister.DayTypeID = tblDayType.TypeID  AND tblEmpRegister.AtDate Between @St AND @Ed  " & _
            "CREATE TABLE #T1 (EmpID Nvarchar (6),AtDate DateTime, LvType Nvarchar (40)) " & _
            "INSERT INTO #T1 select TblLeaveTRD.EmpID,tblEmpRegister.AtDate,tblLeaveType.ShortCode FROM tblLeaveTRD INNER JOIN tblLeaveTRH ON tblLeaveTRH.RqID = tblLeaveTRD.RqID AND tblLeaveTRH.EmpID = tblLeaveTRD.EmpID INNER JOIN tblLeaveType ON tblLeaveTRD.LvType = tblLeaveType.LvID LEFT OUTER JOIN tblEmpRegister ON tblLeaveTRD.EmpID  = tblEmpRegister.EmpID AND tblLeaveTRD.LvDate = tblEmpRegister.AtDate where tblEmpRegister.AtDate Between @St AND @ed " & _
            "UPDATE tblkReport SET tblkReport.TimeS = ',' + #T1.LvType FROM #T1,tblkReport WHERE #T1.EmpID = tblkReport.EmpID AND #T1.AtDate =tblkReport.AtDate " & _
            "UPDATE tblkReport SET DateCol = CASE WHEN PRAB = 'OFF' THEN 'OFF' WHEN PRAB= 'AB' THEN 'AB' ELSE Char(13)+PRAB + Char(13)+ ' ' + TimeS END END " : FK_EQ(sqlTable, "S", "", False, False, False)

            'dgvReportG.Columns.Clear()
            'dgvReportG.Rows.Clear()
            PicKasun.Visible = True
            lblProcessing.Visible = True
            Button1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim intDayCount As Integer = 0 : Dim StrColString As String = "" : Dim dtRunDate As Date
            intDayCount = DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value)
            dtRunDate = dtpFromDate.Value : Dim intRunDay As Integer

            dgvReportG.Columns.Clear()

            With dgvReportG
                .Columns.Add("EmpID", "Emp ID")
                '.Columns.Add("WrkDays", "Worked Days")
                '.Columns.Add("OTHrs", "OT Hours")
            End With

            Dim sqlQRY As String
            sqlQRY = "EXEC sp_Run_Report '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "DROP TABLE tblInOutReport " : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "CREATE TABLE tblInOutReport (EmpID Nvarchar (6),empName nvarchar (226),workedDays numeric (18,2) not null default 0)" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "INSERT INTO tblInOutReport SELECT tblkReport.EmpID,tblemployee.dispName,sum(tblkReport.wrkDay) FROM tblkReport INNER JOIN tblemployee ON tblemployee.RegID=tblKreport.EmpID GROUP BY tblKreport.EmpID,tblemployee.dispName" : FK_EQ(sqlQRY, "S", "", False, False, True)

            sqlQRY = ""
            For i As Integer = 0 To intDayCount
                intRunDay = i + 1
                StrColString = "Day" & intRunDay.ToString
                DataGridView1.Rows.Add(dtRunDate.ToString, StrColString)
                sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Nvarchar (100) NOT NULL Default '';"
                dtRunDate = DateAdd(DateInterval.Day, 1, dtRunDate)
                dgvReportG.Columns.Add(StrColString, StrColString)
                dgvReportG.Columns(StrColString).DefaultCellStyle.WrapMode = DataGridViewTriState.True : dgvReportG.Columns(StrColString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            FK_EQ(sqlQRY, "S", "", False, False, False)

            sqlQRY = ""
            Dim sql As String = "SELECT LvID,LvDesc,shortcode FROM tblLeaveType WHERE Status = 0 Order By LvID"
            Load_InformationtoGrid(sql, DataGridView2, 3)
            With DataGridView2
                For iL As Integer = 0 To .RowCount - 1
                    StrColString = .Item(2, iL).Value
                    If StrColString <> "" Then
                        sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Numeric (18,2) NOT NULL Default 0;"
                    ElseIf StrColString = "" Then
                        MessageBox.Show("Please set short code in Leave settings before try this report", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : LoadForm(New frmSetLeaveType) : Exit Sub
                    End If
                Next
            End With
            FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = ""
            With DataGridView1
                For i As Integer = 0 To .RowCount - 1
                    Dim StrColName As String = ""
                    StrColName = .Item(1, i).Value : dtRunDate = .Item(0, i).Value
                    sqlQRY = sqlQRY & "Exec sp_CrossUpdate '" & StrColName & "','" & Format(dtRunDate, "yyyyMMdd") & "'"
                Next
            End With
            FK_EQ(sqlQRY, "P", "", False, True, True)

            'Update Leave Summary to the Main Table 
            With DataGridView2
                For iL As Integer = 0 To .RowCount - 1
                    Dim StrLvCode As String = .Item(0, iL).Value
                    Dim StrShCode As String = .Item(2, iL).Value
                    sqlQRY = "CREATE TABLE #T (EMpID Nvarchar (6),LvID Nvarchar (3),NoLv Numeric (18,2))"
                    sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblLeaveTRD.EmpID,tblLeaveTRD.LvType,Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRH,tblLeaveTRD WHERE (tblLeaveTRH.EmpID = tblLeaveTRD.EmpID AND tblLeaveTRH.RqID = tblLeaveTRD.RqID) AND tblLeaveTRD.LvDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRD.LvType = '" & StrLvCode & "'  GROUP BY tblLeaveTRD.EmpID,tblLeaveTRD.LvType"
                    sqlQRY = sqlQRY & " UPDATE tblInOutReport SET tblInOutReport." & StrShCode & " = #T.NoLv FROM #T,tblInOutReport WHERE #T.EMpID = tblInOutReport.EmpID"
                    FK_EQ(sqlQRY, "S", "", False, False, True)
                Next
            End With

            dgvReportG.RowTemplate.Height = 25

            dgvReportG.Columns.Clear()

            Dim ColVal As Integer = CInt(dgvReportG.Columns.Count) + (DataGridView2.RowCount)
            Fk_FillGrid("SELECT * FROM tblInOutReport Order By EmpID", dgvReportG)

            With dgvReportG
                For i As Integer = 0 To dgvReportG.Columns.Count - 1
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End With
            intcolomncount = dgvReportG.ColumnCount
            PicKasun.Visible = False
            lblProcessing.Visible = False
            lblCoun.Text = "Total Records " & dgvReportG.RowCount
            Button3.Enabled = True
            dgvReportG.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub Create_Report_OT()
        Try
            Dim sqlTable As String
            sqlTable = "DROP TABLE tblkOTReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE TABLE tblkOTReport (EmpID Nvarchar (6),AtDate DateTime,PRAB numeric (18,2) not null default 0,DateCol numeric (18,2) not null default 0)" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "DROP PROC sp_CrossUpdate" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_CrossUpdate (@ColName Nvarchar (10),@RunDate DateTime)" & _
            " As BEGIN CREATE TABLE #T (EmpID Nvarchar (6),ColVal Nvarchar (100))" & _
            " INSERT INTO #T SELECT EmpID, DateCol FROM tblkOTReport WHERE AtDate = @RunDate" & _
            " Exec ('UPDATE tblInOutReport SET ' + @ColName + ' = #T.ColVal FROM #T,tblInOutReport WHERE #T.EmpID = tblInOutReport.EmpID') END" : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_GenReport" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_GenReport (@EmpID Nvarchar (6),@St DateTime, @Ed DateTime) As" & _
            " BEGIN INSERT INTO tblkOTReport SELECT @EmpID,tblCalendar.[Date],0,0 from tblCalendar WHERE [Date] Between @st AND @ed END " : FK_EQ(sqlTable, "S", "", False, False, True)

            sqlTable = "DROP PROC sp_OT_Report" : FK_EQ(sqlTable, "S", "", False, False, False)
            sqlTable = "CREATE PROCEDURE sp_OT_Report (@St DateTime,@Ed DateTime)" & _
            " As Begin  DELETE FROM tblkOTReport " & _
            " Declare @RegID nvarchar (6) Declare c Cursor for " & _
            " SELECT RegID FROM tblEmployee where empstatus <> '9' Open c" & _
            " Fetch next from c INTO @RegID " & _
            " WHILE @@Fetch_Status = 0 BEGIN  " & _
            " Exec sp_GenReport @RegID,@St,@Ed " & _
            " Fetch Next From c INTO @RegID END " & _
            " Close c Deallocate c  " & _
            "UPDATE tblkOTReport SET tblkOTReport.PRAB = tblEmpRegister.NormalOTHrs FROM tblkOTReport,tblEmpRegister WHERE tblkOTReport.EmpID = tblEmpRegister.EMpID AND tblkOTReport.AtDate = tblEmpRegister.AtDate  AND tblEmpRegister.AtDate Between @St AND @Ed  " & _
            "UPDATE tblkOTReport SET DateCol = PRAB END" : FK_EQ(sqlTable, "S", "", False, False, False)

            PicKasun.Visible = True
            lblProcessing.Visible = True
            Button1.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            Dim intDayCount As Integer = 0 : Dim StrColString As String = "" : Dim dtRunDate As Date
            intDayCount = DateDiff(DateInterval.Day, dtpFromDate.Value, dtpToDate.Value)
            dtRunDate = dtpFromDate.Value : Dim intRunDay As Integer

            dgvReportG.Columns.Clear()

            With dgvReportG
                .Columns.Add("EmpID", "Emp ID")
                '.Columns.Add("WrkDays", "Worked Days")
                '.Columns.Add("OTHrs", "OT Hours")
            End With

            Dim sqlQRY As String
            sqlQRY = "EXEC sp_OT_Report '" & Format(dtpFromDate.Value, "yyyyMMdd") & "','" & Format(dtpToDate.Value, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "DROP TABLE tblInOutReport " : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "CREATE TABLE tblInOutReport (EmpID Nvarchar (6),EmpName nvarchar (226),totOT numeric (18,2) not null default 0)" : FK_EQ(sqlQRY, "S", "", False, False, True)
            sqlQRY = "INSERT INTO tblInOutReport SELECT tblkOTReport.EmpID,tblemployee.dispName,sum(tblkOTReport.PRAB) FROM tblkOTReport INNER JOIN tblemployee ON tblemployee.RegID=tblkOTReport.EmpID GROUP BY tblkOTReport.EmpID,tblemployee.dispName" : FK_EQ(sqlQRY, "S", "", False, False, True)

            sqlQRY = ""
            For i As Integer = 0 To intDayCount
                intRunDay = i + 1
                StrColString = "Day" & intRunDay.ToString
                DataGridView1.Rows.Add(dtRunDate.ToString, StrColString)
                sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Nvarchar (100) NOT NULL Default ''"
                dtRunDate = DateAdd(DateInterval.Day, 1, dtRunDate)
                dgvReportG.Columns.Add(StrColString, StrColString)
                dgvReportG.Columns(StrColString).DefaultCellStyle.WrapMode = DataGridViewTriState.True : dgvReportG.Columns(StrColString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgvReportG.RowTemplate.Height = 25
            FK_EQ(sqlQRY, "S", "", False, False, False)

            sSQL = "alter table tblInoutReport add SetofOTHours nvarchar (10) not null default ''"
            FK_EQ(sSQL, "S", "", False, False, False)
            'sqlQRY = ""
            'Dim sql As String = "SELECT LvID,LvDesc,shortcode FROM tblLeaveType WHERE Status = 0 Order By LvID"
            'Load_InformationtoGrid(sql, DataGridView2, 3)
            'With DataGridView2
            '    For iL As Integer = 0 To .RowCount - 1
            '        StrColString = .Item(2, iL).Value
            '        If StrColString <> "" Then
            '            sqlQRY = sqlQRY & " ALTER TABLE tblInOutReport ADD " & StrColString & " Numeric (18,2) NOT NULL Default 0;"
            '        End If
            '    Next
            'End With
            'FK_EQ(sqlQRY, "S", "", False, False, False)
            sqlQRY = ""
            With DataGridView1
                For i As Integer = 0 To .RowCount - 1
                    Dim StrColName As String = ""
                    StrColName = .Item(1, i).Value : dtRunDate = .Item(0, i).Value
                    sqlQRY = sqlQRY & "Exec sp_CrossUpdate '" & StrColName & "','" & Format(dtRunDate, "yyyyMMdd") & "'"
                Next
            End With
            FK_EQ(sqlQRY, "P", "", False, True, True)

            ''Update Leave Summary to the Main Table 
            'With DataGridView2
            '    For iL As Integer = 0 To .RowCount - 1
            '        Dim StrLvCode As String = .Item(0, iL).Value
            '        Dim StrShCode As String = .Item(2, iL).Value
            '        sqlQRY = "CREATE TABLE #T (EMpID Nvarchar (6),LvID Nvarchar (3),NoLv Numeric (18,2))"
            '        sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblLeaveTRD.EmpID,tblLeaveTRD.LvType,Sum(tblLeaveTRD.NoLeave) FROM tblLeaveTRH,tblLeaveTRD WHERE (tblLeaveTRH.EmpID = tblLeaveTRD.EmpID AND tblLeaveTRH.RqID = tblLeaveTRD.RqID) AND tblLeaveTRD.LvDate Between '" & Format(dtpFromDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND tblLeaveTRH.Status = 0 AND tblLeaveTRD.LvType = '" & StrLvCode & "'  GROUP BY tblLeaveTRD.EmpID,tblLeaveTRD.LvType"
            '        sqlQRY = sqlQRY & " UPDATE tblInOutReport SET tblInOutReport." & StrShCode & " = #T.NoLv FROM #T,tblInOutReport WHERE #T.EMpID = tblInOutReport.EmpID"
            '        FK_EQ(sqlQRY, "S", "", False, False, True)
            '    Next
            'End With

            dgvReportG.Columns.Clear()

            Dim ColVal As Integer = CInt(dgvReportG.Columns.Count) + (DataGridView2.RowCount)
            Fk_FillGrid("SELECT * FROM tblInOutReport Order By EmpID", dgvReportG)

            With dgvReportG
                For i As Integer = 0 To dgvReportG.Columns.Count - 1
                    .Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                Next
            End With

            intcolomncount = dgvReportG.ColumnCount
            PicKasun.Visible = False
            lblProcessing.Visible = False
            lblCoun.Text = "Total Records " & dgvReportG.RowCount
            Button3.Enabled = True
            dgvReportG.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        dgvMultiGRID.Rows.Clear()
        dgvReportG.DataSource = Nothing
        dgvReportG.Rows.Clear()
        dgvReportG.Columns.Clear()
        PicKasun.Visible = False
        lblProcessing.Visible = False
        Button1.Enabled = True
        Button1.Enabled = True
        Button3.Enabled = False
        Me.Cursor = Cursors.Default
        dgvReportG.Cursor = Cursors.Default
        rdbLetter.Checked = False
        rdbNOT.Checked = False
        rdbLetter.Enabled = True
        rdbNOT.Enabled = True
    End Sub

End Class