Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports System.Configuration
Imports HRISforBB.cls_ExtendadHeadCount
Imports System.Drawing.Drawing2D

Public Class frmMainAttendance

    Dim StrCrtlName As String
    Dim intAccess As Integer
    Dim strBtn As String = "" : Dim strAtnPrcDate As String = ""
    Dim picbyte1 As Byte()
    Dim intHeight As Integer = 0 : Dim intHeightK As Integer = 0
    Dim strSelctedMenu As String
    Dim intWidth As Integer = 0 : Dim intLoad As Integer = 0 : Dim strClicked As String = "Dashboard"
    Dim sTablek As New DataSet
    Dim strEmpName As String = "" : Public strGridStatus As String = "Absent"
    Dim intSelectedTab As Integer

    'Employee Profile variables
    Dim intEnrolNo As Integer
    Dim StrDefAddID As String
    Dim intActive As Integer
    Dim StrSvStatus As String
    Dim strSurNameClr As String
    Dim strFNamesClr As String
    Dim strIsEpf As String : Dim intExsEnNo As Integer
    Dim strExsNic As String : Dim StrDefaultShiftID As String
    Dim bolIsLoad As Boolean
    Dim picbyte2 As Byte()
    Dim strClickedEmp As String : Dim strShiftID As String
    Dim strWhereClause As String
    Dim strFirstName As String = ""
    Dim strLastName As String = ""
    Dim strOldDispName As String = ""
    Dim intTotShLvMinPerMonth As Integer
    Dim intMaxNoShLvPerMnth As Integer
    Dim intMinMnPerShLv As Integer

    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim oCropX As Integer
    Dim oCropY As Integer
    Dim cropBitmap As Bitmap

    Public cropPen As Pen
    Public cropPenSize As Integer = 1 '2
    Public cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Public cropPenColor As Color = Color.Yellow

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        If MessageBox.Show("Do You Want to Exit?", "Confirm...", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.LayoutMdi(MdiLayout.TileHorizontal)

    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

        Me.LayoutMdi(MdiLayout.ArrangeIcons)

    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next

    End Sub


    Private Function AlreadyRunning() As Boolean
        ' Get our process name.
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName
        Me.Text = "[" & my_name & "]"

        ' Get information about processes with this name.
        Dim procs() As Process = Process.GetProcessesByName(my_name)

        ' If there is only one, it's us.
        If procs.Length = 1 Then Return False

        ' If there is more than one process,
        ' see if one has a StartTime before ours.
        Dim i As Integer
        For i = 0 To procs.Length - 1
            If procs(i).StartTime < my_proc.StartTime Then Return True
        Next i

        ' If we get here, we were first.
        Return False

    End Function

    ' Return True if another instance
    ' of this program is already running.
    Private Function AlreadyRunning_Almost() As Boolean

        ' Get our process name.
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName

        ' If there is more than one process with this name,
        ' then there is another instance running.
        Return (Process.GetProcessesByName(my_name).Length > 1)

    End Function

    Private Sub LoadDashboadScreen()
        pnlAleka.Visible = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximumSize = Screen.FromRectangle(Me.Bounds).WorkingArea.Size
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ControlHandlers(Me)
        'ChartDay.Visible = False
        'ChartWeek.Visible = False

        If AlreadyRunning() Then
            MessageBox.Show("Another instance is already running. Please check it in system tray", "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End
        End If

        'Licence Cancel 2018-08-20 by prasanna from thilanka hotel dambulla 
        Licence.ShowDialog()

        'fk_CreateTableStructure()
        sSQL = "create table tblTheme (thID nvarchar(2),thName nvarchar(150),panelImage nvarchar(150),btnMsEnter nvarchar (150),btnMsLeave nvarchar (150),pbMsEnter nvarchar (150),pbMsLeave nvarchar (150),status numeric(18,0) not null default 0,focusColor nvarchar (60),isStrech nvarchar(4) not null default 0); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('01','Blue','KasunAt','kasunReplaceka','buttonklllk','new_file','addBig','1','LightSkyBlue','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('02','Green','KasunAtg','button2ind','buttonklllkgklllk','new_file','addBig','0','YellowGreen','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('03','Wooden','KasunAtorabn','kasunReplaceka','buttondum','new_file','addBig','0','Peru','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('04','Indigo','KasunAtindig','buttonklllk','button2ind','new_file','addBig','0','Plum','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('05','Kasper','untitledkasper','buttonklllk','button2kasper','new_file','addBig','0','SeaGreen','1'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('06','Black','Avast_7_Free_Antivirus','buttonklllk','buttonorangeklllkblack','new_file','addBig','0','Gray','1'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('07','Red','KasunAtRed','button2ind','button2red','new_file','addBig','0','FireBrick','0'); " & _
      "insert into tblTheme  (thID,thName,panelImage,btnMsEnter,btnMsLeave,pbMsEnter,pbMsLeave,status,focusColor,isStrech) values ('08','PlainBlue','kasun_05','kasunReplaceka','buttonklllk','new_file','addBig','0','Highlight','0')"
        FK_EQ(sSQL, "P", "", False, False, False)

        FK_EQ("alter table tblCompany add downFromFile numeric(18,0) not null default 0", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add chartBar numeric(18,0) not null default 11", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add chartDounut numeric(18,0) not null default 18", "S", "", False, False, False)
        FK_EQ("alter table tblDayType add shortCode nvarchar (4) not null default ''", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblControl ADD RemEarly Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblControl ADD CalLateEarly Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)

        FK_EQ("ALTER TABLE tblEmpRegister ADD TripleOT Numeric (18,2) NOT NULL Default 0", "S", "", False, False, False)
        FK_EQ("ALTER TABLE tblEmpRegister ADD TripleOTHrs Numeric (18,2) NOT NULL Default 0", "S", "", False, False, False)

        'strThemeID = fk_RetString("select thID from tblTheme where status=1")
        ChangeThemeka()
        'Me.pnlTop.BackColor = Color.Transparent
        'CenterFormThemed(Me, pnlTop, Label2)

        If bolLicenced = False Then

            MessageBox.Show("License error, Please contact software provider", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End

        End If

        LoginSteps()

        PreVentFlicker()
        pnlAleka.Visible = True
        'pnlAllDynamic.Visible = True

        labelAbsentClick()

        strClicked = "Dashboard"
        ButtonClicked()
        'lblDate.Text = Format(CDate(strAtnPrcDate), "yyyy MMM dd") & "   "
        'Added on 2018-07-11 Kasun for water garder requirement code 001
        CallToRestrictMenuItem()
        setMenuView()
    End Sub

    Public Sub setMenuView()
        If strLogedinTo = "Payroll" Then
            'pnlPayButtonSet.Height
            pnlAttendanceButtonSet.Height = 0
            'pnlP
        ElseIf strLogedinTo = "Attendance" Then
            pnlPayButtonSet.Height = 0
        ElseIf strLogedinTo = "Profile" Then
            pnlPayButtonSet.Height = 0
        End If
    End Sub

    Public Sub CircleProgressBar()
        sSQL = "SELECT COUNT(regID) FROM tblEmployee WHERE empStatus<>9"
        Dim intCarder As Integer = fk_sqlDbl(ssql1)
        cProgress1.Value = 4 / intCarder * 100
        cProgress2.Value = 5 / intCarder * 100
        cProgress3.Value = 2 / intCarder * 100
        cProgress4.Value = 5 / intCarder * 100

        pgTutnover.Value = 50
        pgAbsent.Value = 40
    End Sub

    Private Sub frmMainAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'tbMain.SelectedIndex = 0
        tbMain_SelectedIndexChanged(sender, e)

    End Sub


    Private Sub CallToRestrictMenuItem()
        'code 001
        restrictMenuItem(btn12Setting, "Main Screen", "Allow to view user creating screen")
        restrictMenuItem(btn13AnalyisData, "Main Screen", "Allow to view attendance analysis screen")
        restrictMenuItem(BTN6Leav, "Main Screen", "Allow to view leave apply screen")
        restrictMenuItem(btn8Calender, "Main Screen", "Allow to view administration screens")
        restrictMenuItem(btn10Payrol, "Main Screen", "Allow to view payroll system link")
        restrictMenuItem(btn1DashBd, "Main Screen", "View dashboard")
        restrictMenuItem(btn2EmpProfile, "Main Screen", "Allow to view employee profile")
        restrictMenuItem(btn4DailyAt, "Main Screen", "Allow to view daily attendance dashboard")
        'restrictMenuItem(btn5OT, "Main Screen", "Allow to view over time authorization screen")
        'restrictMenuItem(btn7Shift, "Main Screen", "Allow to view roster editing screen")
        restrictMenuItem(btn9Comp, "Main Screen", "Allow to view all company setup screens")
        restrictMenuItem(btn11Report, "Main Screen", "Allow to view report generating screen")
        restrictMenuItem(btn3HRM, "Main Screen", "Allow to view data download screen")
    End Sub

    Private Sub LoginSteps()

        IsEpf = fk_sqlDbl("SELECT IsEpf FROM tblCompany WHERE compID = '" & StrCompID & "'")
        If IsEpf = 0 Then sqlTag1 = "tblEmployee.RegID" Else If IsEpf = 1 Then sqlTag1 = "tblEmployee.EpfNo" Else If IsEpf = 2 Then sqlTag1 = "tblEmployee.EnrolNo" Else sqlTag1 = "tblEmployee.EmpNo"
        sqlTagName = "RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as '" & sqlTag1.Split("."c)(1) & "'"

        Me.pnlDynamic.Visible = False

        frmMenuSelector.ShowDialog()

        pnlAllButton.Controls.Clear()

        If strLogedinTo = "Payroll" Then
            If bolLoggedPay = True Then
                pnlAllButton.Controls.Add(pnlPayButtonSet)
                pnlPayButtonSet.Dock = DockStyle.Fill
            End If
            StrUlvlID = "HRIS"
        Else
            If bolLogged = True Then
                pnlAllButton.Controls.Add(pnlAttendanceButtonSet)
                pnlAttendanceButtonSet.Dock = DockStyle.Fill
            End If
        End If

        If bolLogged = False Then
            'MessageBox.Show("Access dinied", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            'End
        End If

        Timer1.Start()


        If StrUlvlID = "HRIS" Then

            Fk_FillGrid("SELECT 'True',deptID FROM tblSetDept WHERE status=0", dgvDept)
            Fk_FillGrid("SELECT 'True',shiftID FROM tblsetShiftH WHERE status=0", dgvShift)
            Fk_FillGrid("SELECT 'True',brID FROM tblCBranchs WHERE status=0", dgvBranch)
            Fk_FillGrid("SELECT 'True',repID FROM tblreports WHERE status=1", dgvReport)
            StrUserLvDept = fk_getGridCLICK(dgvDept, 0, 1) : StrUserLvDept = fk_SplitToSQL_in(StrUserLvDept)
            StrUserLvShifts = fk_getGridCLICK(dgvShift, 0, 1) : StrUserLvShifts = fk_SplitToSQL_in(StrUserLvShifts)
            StrUserLvBranch = fk_getGridCLICK(dgvBranch, 0, 1) : StrUserLvBranch = fk_SplitToSQL_in(StrUserLvBranch)
            StrUserLvReport = fk_getGridCLICK(dgvReport, 0, 1) : StrUserLvReport = fk_SplitToSQL_in(StrUserLvReport)
            intRosterOpt = 2
        Else
            Dim strViewLevelID As String = fk_RetString("SELECT nvlv FROM tblUsers where UserID = '" & StrUserID & "'")
            'report view level
            Dim strReportVLevelID As String = fk_RetString("SELECT vRepID FROM tblUsers where UserID = '" & StrUserID & "'")

            StrUserLvDept = fk_RetString("SELECT vDept FROM tblUserViewLv WHERE vID = '" & strViewLevelID & "'") : StrUserLvDept = fk_SplitToSQL_in(StrUserLvDept)
            StrUserLvShifts = fk_RetString("SELECT vShiftID FROM tblUserViewLv WHERE vID = '" & strViewLevelID & "'") : StrUserLvShifts = fk_SplitToSQL_in(StrUserLvShifts)
            StrUserLvBranch = fk_RetString("SELECT vBranchID FROM tblUserViewLv WHERE vID = '" & strViewLevelID & "'") : StrUserLvBranch = fk_SplitToSQL_in(StrUserLvBranch)
            StrUserLvReport = fk_RetString("SELECT vRepID FROM tblUserReporViewLv WHERE rID = '" & strReportVLevelID & "'") : StrUserLvReport = fk_SplitToSQL_in(StrUserLvReport)
            intRosterOpt = fk_sqlDbl("SELECT rOpt FROM tblUsers WHERE UserID = '" & StrUserID & "'")
        End If
        intIsNewLeaveC = fk_sqlDbl("SELECt IsSheLeave FROM tblControl")
        'tsDate.Text = Format(Now.Date, "dd-MM-yyyy") & "           "
        'tsTime.Text = DateTime.Now.ToLongTimeString & "           "
        'lblView.Text = fk_RetString("SELECT cName from tblCOmpany WHERE compID = '" & StrCompID & "'") + "                                                                                                       "
        ''tStatus.Text = "Active    "
        intCurrentYear = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        intMinErorCheckMin = fk_sqlDbl("SELECT MinErorCheckMin FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        dtLastProcessed = fk_RetDate("select AtnPrcDate from tblCompany where CompID ='" & StrCompID & "'")
        dtLastProcessed = Format(dtLastProcessed, "yyyy-MM-dd")
        strAtnPrcDate = dtLastProcessed
        ISRoundInOutMethod2 = fk_sqlDbl("select ISRoundInOutMethod2 from tblcompany where compID='" & StrCompID & "'")
        ISDispalyDepartmentASBranch = fk_sqlDbl("select ISDispalyDepartmentASBranch from tblcompany where compID='" & StrCompID & "'")
        ISViewActualWorkDayInSummary = fk_sqlDbl("select ISViewActualWorkDayInSummary from tblcompany where compID='" & StrCompID & "'")
        IsOTForRamada = fk_sqlDbl("select IsOTForRamada from tblcompany where compID='" & StrCompID & "'")
        IsDownloadFromServer = fk_sqlDbl("select IsDownloadFromServer from tblcompany where compID='" & StrCompID & "'")
        IsEmpWiseChart = fk_sqlDbl("select IsEmpWiseChart from tblcompany where compID='" & StrCompID & "'")
        IsLunchDinnerDeduct = fk_sqlDbl("select IsLunchDinnerDeduct from tblcompany where compID='" & StrCompID & "'")
        IsFamilyInfo = fk_sqlDbl("select IsFamilyInfo from tblcompany where compID='" & StrCompID & "'")
        IsAtAllowance = fk_sqlDbl("select IsAtAllowance from tblcompany where compID='" & StrCompID & "'")
        IsRemvDaily = fk_sqlDbl("select IsRemvDaily from tblcompany where compID='" & StrCompID & "'")
        IsRemvHourly = fk_sqlDbl("select IsRemvHourly from tblcompany where compID='" & StrCompID & "'")
        IsEthicalOT = fk_sqlDbl("select IsEthicalOT from tblcompany where compID='" & StrCompID & "'")
        IsSiftPatternAssign = fk_sqlDbl("select IsSiftPatternAssign from tblcompany where compID='" & StrCompID & "'")


        'Pay load data
        Dim strCompanyName As String = fk_RetString("select cName from tblcompany where compID='" & StrCompID & "'")
        'LblView.Text = "                                " & "< " & strCompanyName & " >"

        intIsSpecialAllowance = GetVal("SELECT SpecialAllowance FROM tblCompany WHERE CompID='" & StrCompID & "'")
        intRoundSalary = GetVal("SELECT isRoundSalary FROM tblCompany WHERE CompID='" & StrCompID & "'")
        isWithLogo = GetVal("SELECT isWithLogo FROM tblCompany WHERE CompID='" & StrCompID & "'")
        isWithSignature = GetVal("SELECT isWithSignature FROM tblCompany WHERE CompID='" & StrCompID & "'")
        strPrCategory = fk_RetString("select processategory from tblcompany where compID='" & StrCompID & "'")
        strReportBased = fk_RetString("select reportBased from tblcompany where compID='" & StrCompID & "'")
        isRoundBudget = GetVal("SELECT isRoundBudget FROM tblCompany WHERE CompID='" & StrCompID & "'")
        isRequestDeduct = GetVal("SELECT isRequestDeduct FROM tblCompany WHERE CompID='" & StrCompID & "'")
        'isSummaryToSLIP = GetVal("SELECT isSummaryToSLIP FROM tblCompany WHERE CompID='" & StrCompID & "'")
        'isMultipleServiceCharge = GetVal("SELECT isMultipleServiceCharge FROM tblCompany WHERE CompID='" & StrCompID & "'")
        strDefaultPageSize = fk_RetString("SELECT DefaultPageSize FROM tblCompany WHERE CompID='" & StrCompID & "'")
        isSeperateBranch = GetVal("SELECT isSeperateBranch FROM tblCompany WHERE CompID='" & StrCompID & "'")
        'isBonus = GetVal("SELECT isBonus FROM tblCompany WHERE CompID='" & StrCompID & "'")

        cBusiness = ReadKey("HRTime\Business")
        cAddress = ReadKey("HRTime\Address")
        cPhone = ReadKey("HRTime\Phone")

        'lblT1.ForeColor = clrFocused
        'lblT2.ForeColor = clrFocused
        'lblT3.ForeColor = clrFocused
        'lblT4.ForeColor = clrFocused
        'lblT5.ForeColor = clrFocused
        'lblT6.ForeColor = clrFocused
        'lblT7.ForeColor = clrFocused
        'lblT8.ForeColor = clrFocused
        'lblT9.ForeColor = clrFocused
        'lblT10.ForeColor = clrFocused
        'lblT11.ForeColor = clrFocused
        'lblT12.ForeColor = clrFocused

        'lblDatagridTitle.BackColor = clrFocused
        Try
            dtpToDate.Value = IIf(strAtnPrcDate = "", DateSerial(1900, 1, 1), strAtnPrcDate)
            'PRchartDay()
            'CreateMonthSum()
            'chartWeekK()
            'DashboadCount()
            'setProgreBars()
            'ViewGridStatus()
            'BirtdayList()
            'ContractList()

            lblCompanyName.Text = fk_RetString("SELECT cName FROM tblCompany where compID='001'").ToUpper

            'lblAbsent.ForeColor = clrFocused
            'lblPresent.ForeColor = clrFocused
            'lblLate.ForeColor = clrFocused
            'lblLeave.ForeColor = clrFocused
            'lblTot.ForeColor = clrFocused

            ''Last download processed status
            'lblDownCount.ForeColor = clrFocused
            'lblLstDownTimes.ForeColor = clrFocused
            'lblLstPrCount.ForeColor = clrFocused
            'lbllstPrTim.ForeColor = clrFocused
            'lblLstFixCount.ForeColor = clrFocused
            'Label16.ForeColor = clrFocused
            'Label21.ForeColor = clrFocused
            'Label18.ForeColor = clrFocused

            'lblCompanyName.ForeColor = Color.DimGray
            'FileMenu.ForeColor = Color.DimGray
            'TransactionMenu.ForeColor = Color.DimGray
            'ViewMenu.ForeColor = Color.DimGray
            'ProcessToolStripMenuItem.ForeColor = Color.DimGray
            'AToolStripMenuItem.ForeColor = Color.DimGray
            'SettingsToolStripMenuItem.ForeColor = Color.DimGray
            'HelpMenu.ForeColor = Color.DimGray

            'pntTopRight.BackColor = Color.White
            'lblDate.ForeColor = Color.DimGray
            'lblTime.ForeColor = Color.DimGray

            'dgvInformation.DefaultCellStyle.ForeColor = clrFocused
            'dgvInformation.DefaultCellStyle.BackColor = Color.White
            'dgvInformation.DefaultCellStyle.SelectionForeColor = Color.White
            'dgvInformation.DefaultCellStyle.SelectionBackColor = clrFocused

            dgvWeeklySummary.DefaultCellStyle.ForeColor = Color.DimGray
            dgvWeeklySummary.DefaultCellStyle.BackColor = Color.White
            dgvWeeklySummary.DefaultCellStyle.SelectionForeColor = Color.White
            dgvWeeklySummary.DefaultCellStyle.SelectionBackColor = Color.LightSeaGreen
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'MenuRead()
        'shortCut()
        ' pnlSubShort.Height = 0
        'intHeight = pnlMainShort.Height
        'SplitContainer1.Panel1.Width = 87
        'ChartDay.Visible = True
        'ChartWeek.Visible = True

        'DashBoard()


        'cmdSearch_Click(sender, e)

        'frmLogink.picEmpMain.Image = picEmpMain.Image
        Dim gp As New GraphicsPath()
        gp.AddEllipse(picEmpMain.DisplayRectangle)
        picEmpMain.Region = New Region(gp)

        'Dim gp1 As New GraphicsPath()
        'gp1.AddEllipse(pb1.DisplayRectangle)
        'pb1.Region = New Region(gp1)
        'GraphicsPath path = new GraphicsPath();
        '  path.AddEllipse(0,0,320,200);
        '  this.Region = new Region(path);

        NotifyIcon1.Visible = True
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
        NotifyIcon1.BalloonTipText = "HRISforBB is started by " & CurrentUser & ""
        NotifyIcon1.BalloonTipTitle = "HRISforBB"
        NotifyIcon1.ShowBalloonTip(1000)
        'BirtdayWish()

        ' Set up the Header Color and Font.
        dgvWeeklySummary.EnableHeadersVisualStyles = False
        With dgvWeeklySummary.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .BackColor = Color.LightSeaGreen
            .ForeColor = Color.White
            '.Font = New Font(.Font.FontFamily, .Font.Size, _
            '.Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With

        pnlAllButton.Enabled = True
        Me.pnlDynamic.Enabled = True
        Me.pnlDynamic.Visible = True
        lblState.Text = "Active"
        tsCurrentUser.Text = CurrentUser
        'Me.IsMdiContainer = False
        Me.btnLogin.Enabled = False
        Me.btnLogout.Enabled = True
    End Sub

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or 33554432
            Return cp
        End Get
    End Property

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub

    Private Sub DashboadCount()
        sSQL = "select  convert(int,sum(p)) as Present, convert(int,sum(lv)) as Leave, convert(int,sum(lt)) as Late, convert(int,sum(a)) as Absent, convert(int,sum(CASE WHEN a=1 and lv=0 and isOf=0 then 1 WHEN p=1 or  isOf=1 OR lv=1 then 0 END)) as Nopay  from tblViewTK,tblemployee where tblViewTK.regID=tblemployee.regid and tblViewTK.atdate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' and tblemployee.Empstatus<>9 and tblemployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        fk_Return_MultyString(sSQL, 5)
        lblAbsent.Text = fk_ReadGRID(3).ToString().PadLeft(3, "0")
        lblLate.Text = fk_ReadGRID(2).ToString().PadLeft(3, "0")
        lblNopay.Text = fk_ReadGRID(4).ToString().PadLeft(3, "0")
        lblLeave.Text = fk_ReadGRID(1).ToString().PadLeft(3, "0")
        lblPresent.Text = fk_ReadGRID(0).ToString().PadLeft(3, "0")

        'sSQL = "select CONVERT(VARCHAR(11),atDate,106) AS 'Date',datename(dw,atdate) AS 'Day',count(tot) as 'Cadre', sum(P) as 'Present',sum(A)  as 'Absent',sum(lt) as 'Lateness',sum (lv) as 'Leave'  from tblViewTK  group by atDate order by atDate"
        'Fk_FillGrid(sSQL, dgvWeeklySummary)
        'For X As Integer = 0 To dgvWeeklySummary.Columns.Count - 1
        '    dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '    'dgvEmployee.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'Next
        'clr_Grid(dgvWeeklySummary)
    End Sub

    'Private Sub setProgreBars()
    '    Try
    '        'Set Progress bar
    '        pbAbsent.Maximum = Val(lblTot.Text)
    '        pbAbsent.Minimum = 0
    '        pbAbsent.Value = Val(lblAbsent.Text)
    '        LBLPCAb.Text = CInt(Val(lblAbsent.Text) / Val(lblTot.Text) * 100) & "%"

    '        pbPresent.Maximum = Val(lblTot.Text)
    '        pbPresent.Minimum = 0
    '        pbPresent.Value = Val(lblPresent.Text)
    '        lblPCPr.Text = CInt(Val(lblPresent.Text) / Val(lblTot.Text) * 100) & "%"

    '        pbLate.Maximum = Val(lblTot.Text)
    '        pbLate.Minimum = 0
    '        pbLate.Value = Val(lblLate.Text)
    '        lblPCLt.Text = CInt(Val(lblLate.Text) / Val(lblTot.Text) * 100) & "%"

    '        pbLeave.Maximum = Val(lblTot.Text)
    '        pbLeave.Minimum = 0
    '        pbLeave.Value = Val(lblLeave.Text)
    '        lblPCLv.Text = CInt(Val(lblLeave.Text) / Val(lblTot.Text) * 100) & "%"

    '        pbCadre.Maximum = Val(lblTot.Text)
    '        pbCadre.Minimum = 0
    '        pbCadre.Value = Val(lblTot.Text)
    '        lblPCCd.Text = CInt(Val(lblTot.Text) / Val(lblTot.Text) * 100) & "%"
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub chartSet()
    '    Me.Cursor = Cursors.WaitCursor
    '    'PRchartweek()
    '    PRchartDay()
    '    PRchartA()
    '    PRchartCatA()
    '    PRchartPresent()
    '    PRchartCatPresent()
    '    PRchartAbsent()
    '    PRchartCatAbsent()
    '    PRchartLate()
    '    PRcharCattLate()
    '    PRchartLeave()
    '    PRchartCatLeave()
    '    PRchartLeaveSummary()
    '    PRGaugeSet()
    '    Me.Cursor = Cursors.Default
    'End Sub

    Public Sub EnableMenu()
        FK_EQ("alter table tblCompany add IsDayTypeConfig numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add IsNightPickEnabled numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add IsRosterEnabled numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add IsContractPeriod numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add IsNewRoster numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add isWeekShed numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add IsResignScreen numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add IsOTApprove numeric (18,0) not null default  0 ", "S", "", False, False, False)
        FK_EQ("alter table tblCompany add isDeleteShift numeric (18,0) not null default  0 ", "S", "", False, False, False)

        'Enable Menu according to menu capture screen
        'If fk_sqlDbl("select IsImportExtrDayToLv from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    ImportExtraDaysToLeaeToolStripMenuItem.Visible = True
        'Else
        '    ImportExtraDaysToLeaeToolStripMenuItem.Visible = False
        'End If

        intNewOTCOnfig = fk_sqlDbl("SELECT NewOTConfig FROM tblCOntrol")
        'If intNewOTCOnfig = 1 Then
        '    OTConfigurationToolStripMenuItem.Visible = True
        'Else
        '    OTConfigurationToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("select IsRandomReport from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    RandomReportViewToolStripMenuItem.Visible = True
        'Else
        '    RandomReportViewToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("select IsPayrollTextFile from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    TransferSummaryToTextFileForPayrollToolStripMenuItem.Visible = True
        'Else
        '    TransferSummaryToTextFileForPayrollToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("select IsImportOTHrToLv from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    ImportOTHoursToLeaveToolStripMenuItem.Visible = True
        'Else
        '    ImportOTHoursToLeaveToolStripMenuItem.Visible = False
        'End If

        intIsUserViewLevel = fk_sqlDbl("select IsUserViewLevel from tblcompany where compID='" & StrCompID & "'")
        If intIsUserViewLevel = 1 Then
            'SetUserViewLevelsToolStripMenuItem.Visible = True
        Else
            'SetUserViewLevelsToolStripMenuItem.Visible = False
            Dim dgvULVk As New DataGridView
            dgvULVk.Columns.Add("tr", "True")
            dgvULVk.Columns.Add("deptID", "ID")
            dgvULVk.Columns.Add("dept", "Departmen")
            Load_InformationtoGrid("SELECT 'True',deptID,Deptname from tblsetDept Order By deptID", dgvULVk, 3)
            Dim k = dgvULVk.RowCount
            Dim StrAllDept As String = fk_getGridCLICK(dgvULVk, 0, 1)
            sSQL = "UPDATE tblUserViewLv SET vDept='" & StrAllDept & "' WHERE vID='01'"
            FK_EQ(sSQL, "E", "", False, False, True)
        End If

        intIsBOTAccept = fk_sqlDbl("select isEmpBOT from tblcompany where compID='" & StrCompID & "'")
        IntIsPayrolDataEnabled = fk_sqlDbl("select IsPayrolDataEnabled from tblcompany where compID='" & StrCompID & "'")
        intIsMonthlyOT = fk_sqlDbl("select IsMonthlyOT from tblcompany where compID='" & StrCompID & "'")

        'If fk_sqlDbl("select IsDayTypeConfig from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    ConfigureDayWithShiftsToolStripMenuItem.Visible = True
        'Else
        '    ConfigureDayWithShiftsToolStripMenuItem.Visible = False
        'End If

        intIsNightPickEnabled = fk_sqlDbl("select IsNightPickEnabled from tblcompany where compID='" & StrCompID & "'")
        intOnShiftProcess = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")
        intBaseOnClockRecord = fk_sqlDbl("select IsDefaultShift from tblcompany where compID='" & StrCompID & "'")

        'If fk_sqlDbl("select IsRosterEnabled from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    AssignEmployeesToRosterToolStripMenuItem.Visible = True
        'Else
        '    AssignEmployeesToRosterToolStripMenuItem.Visible = False
        'End If

        intIsContractPeriod = fk_sqlDbl("select IsContractPeriod from tblcompany where compID='" & StrCompID & "'")
        IsAdditionalHRModule = fk_sqlDbl("select IsAdditionalHRModule from tblcompany where compID='" & StrCompID & "'")
        intDaySeperateOT = fk_sqlDbl("select DaySeperateOT from tblControl where grpID='" & StrCompID & "'")

        'If fk_sqlDbl("select IsOTApprove from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    OTApprovalToolStripMenuItem.Visible = True
        'Else
        '    OTApprovalToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("select IsResignScreen from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    ResignEmployeesToolStripMenuItem.Visible = True
        'Else
        '    ResignEmployeesToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("select isWeekShed from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    SetupRosterToolStripMenuItem.Visible = True
        'Else
        '    SetupRosterToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("select IsNewRoster from tblcompany where compID='" & StrCompID & "'") = 1 Then
        '    RostersToolStripMenuItem.Visible = True
        'Else
        '    RostersToolStripMenuItem.Visible = False
        'End If

        'If fk_sqlDbl("SELECT SelectMachine FROM tblControl") = 1 Then
        '    AssignToFingerMachineToolStripMenuItem.Visible = True
        'Else
        '    AssignToFingerMachineToolStripMenuItem.Visible = False
        'End If

    End Sub

    Public Sub BirtdayList()

        Try
            Dim strMonth As String = dtWorkingDate.Month
            Dim strDay As String = dtWorkingDate.Day

            sSQL = "select COUNT(regid) from tblemployee where  DATEPART(mm, DofB) = " & strMonth & " and DATEPART(dd, DofB) =" & strDay & " and empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') "

            'Dim dgvBirthDay As New DataGridView
            'dgvBirthDay.Columns.Add("empName", "RegID")
            'dgvBirthDay.Columns.Add("empID", "EmpID")
            'dgvBirthDay.Columns.Add("empnam", "Employee Name")
            'Load_InformationtoGrid(sSQL, dgvBirthDay, 3)

            'If fk_CheckEx(sSQL) = True Then

            lblBirtdayCount.Text = fk_sqlDbl(sSQL)

            'fk_Return_MultyString(sSQL, 2)
            'Dim strCustName As String = fk_ReadGRID(0)
            'Dim strRegID As String = fk_ReadGRID(1)

            'For i As Integer = 0 To dgvBirthDay.RowCount - 2
            If Val(lblBirtdayCount.Text) > 0 Then
                NotifyIcon1.Visible = True
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipText = "Today " & Val(lblBirtdayCount.Text) & " employee(s) has birthday!!"
                NotifyIcon1.BalloonTipTitle = "Birthday Alert"
                NotifyIcon1.ShowBalloonTip(100)
            End If
            '    Dim strCustName As String = dgvBirthDay.Item(0, i).Value
            '    Dim strRegID As String = dgvBirthDay.Item(1, i).Value

            '    NotifyIcon1.Visible = True
            '    NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            '    NotifyIcon1.BalloonTipText = "" & strCustName & " 's Birthday is today!"
            '    NotifyIcon1.BalloonTipTitle = "HRISforBB System"
            '    NotifyIcon1.ShowBalloonTip(100)

            '    MessageBox.Show("" & strCustName & " 's Birthday is today!", "Birthday Information", MessageBoxButtons.OK)

            'Next

            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub ContractList()

        Try
            Dim strMonth As String = dtWorkingDate.Month
            Dim strDay As String = dtWorkingDate.Day

            sSQL = "select COUNT(regid)  from tblemployee where  DATEPART(mm, contractEnd) = " & strMonth & " AND DATEPART(yy, contractEnd) = " & intCurrentYear & " AND empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') "

            'Dim dgvBirthDay As New DataGridView
            'dgvBirthDay.Columns.Add("empName", "RegID")
            'dgvBirthDay.Columns.Add("empID", "EmpID")
            'dgvBirthDay.Columns.Add("empnam", "Employee Name")
            'Load_InformationtoGrid(sSQL, dgvBirthDay, 3)

            'If fk_CheckEx(sSQL) = True Then

            lblContractCount.Text = fk_sqlDbl(sSQL)


            'fk_Return_MultyString(sSQL, 2)
            'Dim strCustName As String = fk_ReadGRID(0)
            'Dim strRegID As String = fk_ReadGRID(1)

            'For i As Integer = 0 To dgvBirthDay.RowCount - 2

            '    Dim strCustName As String = dgvBirthDay.Item(0, i).Value
            '    Dim strRegID As String = dgvBirthDay.Item(1, i).Value

            '    NotifyIcon1.Visible = True
            '    NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
            '    NotifyIcon1.BalloonTipText = "" & strCustName & " 's Birthday is today!"
            '    NotifyIcon1.BalloonTipTitle = "HRISforBB System"
            '    NotifyIcon1.ShowBalloonTip(100)

            '    MessageBox.Show("" & strCustName & " 's Birthday is today!", "Birthday Information", MessageBoxButtons.OK)

            'Next

            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = DateTime.Now.ToLongTimeString & " "
        Dim hours As Integer = DateTime.Now.Hour
        Dim str As String
        If hours < 12 Then
            str = "Good Morning "
        ElseIf hours < 17 Then
            str = "Good Afternoon "
        Else
            str = "Good Evening "
        End If
        tsCurrentUser.Text = "Hi " & str & " " & CurrentUser
        'lblView.Text = lblView.Text.Substring(1) & lblView.Text.Substring(0, 1)
        lblDate.Text = Format(Now.Date, "yyyy MMM dd") & "   "
    End Sub


    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'dtpToDate.Visible = False
        'txtSearch.Text = ""
        'txtSearch.Visible = True
        'cmdSearch.Visible = True
        'timerKt.Start()
    End Sub


    Private Sub cmdSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        'lvMain.Focus()

    End Sub

    Private Sub dtpToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Format(dtpToDate.Value, "yyyyMMdd") > Format(CDate(strAtnPrcDate), "yyyyMMdd") Then MessageBox.Show("You have exceeded the Maximum date, System will auto set the maximum date Now", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information) : dtpToDate.Value = strAtnPrcDate : Exit Sub
        Dim dtMinimumDate As DateTime = CDate(strAtnPrcDate)
        If Format(dtpToDate.Value, "yyyyMMdd") < Format(dtMinimumDate.AddDays(-30), "yyyyMMdd") Then MessageBox.Show("You have exceeded the Minimum date, System will auto set the Minimum date Now", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information) : dtpToDate.Value = dtMinimumDate.AddDays(-30) : Exit Sub
        'chartSet()

    End Sub

    Private Sub EmployeeInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmEmployeeInfo)

    End Sub

    Private Sub ManualAdjestmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'StrEmployeeID = ""
        'LoadForm(New frmChkDailyShift)

    End Sub

    Private Sub ApplyLeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmApplyLeavdatra)

    End Sub

    Private Sub CancelLeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmNewLeaveCancel)
        'LoadForm(New frmLeaveCancel)

    End Sub

    Private Sub AssignEmployeesToShiftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmShiftAsgn)

    End Sub

    Private Sub AddNewUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetUsers)

    End Sub

    Private Sub ConfigureLeaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmConfigLeave)

    End Sub

    Private Sub ConfigureCalenderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmCalendar)

    End Sub

    Private Sub SetupShiftToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetShiftType)

    End Sub

    Private Sub SetupRosterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmWeekShdl)

    End Sub

    Private Sub ReActivateEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmReActCancelEmp)

    End Sub

    Private Sub MenuCaptureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmMenuCapture)

    End Sub

    Private Sub ProcessDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmAttnProcess)
    End Sub

    Private Sub ViewReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmReportViewer)
    End Sub

    Private Sub BackupDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmBackupDB)
    End Sub

    Private Sub SetCompanyInfomationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetCompany)
    End Sub

    Private Sub SetBranchInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetCBranchs)
    End Sub

    Private Sub SetDepartmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetDepartment)
    End Sub

    Private Sub SetEmployeeCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetCategory)
    End Sub

    Private Sub SetEmployeeTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetEmpTypes)

    End Sub

    Private Sub SetDesignationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetDesignation)

    End Sub

    Private Sub SetTitlesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetTitle)

    End Sub

    Private Sub SetLeaveTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmSetLeaveType)

    End Sub

    Private Sub SetDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmDeviceInfo)

    End Sub

    Private Sub UserManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ' LoadForm(New frmHelp)

    End Sub

    Private Sub frmMainAttendance_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.WindowState = FormWindowState.Minimized
                NotifyIcon1.Visible = True
                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                NotifyIcon1.BalloonTipText = "HRISforBB is minimized to System tray by " & CurrentUser & ""
                NotifyIcon1.BalloonTipTitle = "HRISforBB"
                NotifyIcon1.ShowBalloonTip(1000)
                Me.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Try
            Me.Visible = True
            Me.WindowState = FormWindowState.Maximized
            NotifyIcon1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ConfigureDayWithShiftsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LoadForm(New frmConfgDayPrfVsShift)

    End Sub

    Private Sub ReportViewerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmReportViewer)
    End Sub

    Private Sub AssignEmployeesToRosterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmRosterAssign)
    End Sub

    Private Sub GenerateLeaveForCurrentYearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmLeaveImport)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmUserLvls)
    End Sub

    Private Sub AddUserDepartmentViewLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetUserViewLv)
    End Sub

    Private Sub SetCivilStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(frmSetCivilSt)
    End Sub

    Private Sub ReProcessSelectedEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmPrcSelectedlist)
    End Sub

    'Private Sub pnlChartTwo_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlChartTwo.SizeChanged

    '    pnlDay.Location = New System.Drawing.Point(0, 0)
    '    pnlDay.Size = New System.Drawing.Size((Me.pnlChartTwo.Width), (Me.pnlChartTwo.Height / 2))
    '    pnlDay.Width = (Me.pnlChartTwo.Width)
    '    pnlDay.Height = (Me.pnlChartTwo.Height / 2)

    '    pnlWeek.Location = New System.Drawing.Point(0, (Me.pnlChartTwo.Height / 2))
    '    pnlWeek.Width = (Me.pnlChartTwo.Width)
    '    pnlWeek.Height = (Me.pnlChartTwo.Height / 2)

    'End Sub

    Public Sub chartIndividual()
        'Dont display employee wise chart, if it isn't active from controlpanel
        'If IsEmpWiseChart = 0 Then
        '    Exit Sub
        'End If

        Dim dtpFromDate As DateTime = DateAdd(DateInterval.Month, -1, dtpToDate.Value)
        lblChartTitle.Text = strEmpName & "   -   " & "Recent 30 Days & " & strGridStatus & " & from : " & Format(dtpToDate.Value, "yyyy-MMM-dd")
        lblChartTitle.ForeColor = clrFocused

        Try

            'chartWeek.Palette = ChartColorPalette.Pastel
            ''Dim customPalette(4) As Color
            ''customPalette(0) = Color.Green
            ''customPalette(1) = Color.Red
            ''customPalette(2) = Color.Orange
            ''customPalette(3) = Color.Violet
            ''chartWeek.Palette = ChartColorPalette.None
            ''chartWeek.PaletteCustomColors = customPalette

            'lblWeekTitle.Text = "Last Week Attendance"
            'pnlWeekTitle.BackgroundImage = My.Resources.ResourceManager.GetObject(strPanelImage)
            Dim wcconn As New SqlClient.SqlConnection(sqlConString)
            Dim wcCommand As New SqlClient.SqlCommand

            Dim wcQuery As String = ""

            Select Case strGridStatus

                Case "Present"
                    wcQuery = "CREATE TABLE #ind (EmpID NVARCHAR (6),atDate DATETIME,WorkHrs NUMERIC (18,2),NOTHrs NUMERIC (18,2)); INSERT INTO #ind SELECT empID,atdate,workHrs,normalOTHrs from tblEmpregister where empid='" & StrEmployeeID & "' and atDate BETWEEN '" & Format(dtpFromDate, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND antStatus=1  ; SELECT convert (varchar(5),atdate,106) as 'atDate',workHrs FROM #ind order by year(atDate),month(atDate),day(atdate)"

                Case "Absent"
                    wcQuery = "CREATE TABLE #ind (EmpID NVARCHAR (6),atDate DATETIME,WorkHrs NUMERIC (18,2),NOTHrs NUMERIC (18,2)); INSERT INTO #ind SELECT empID,atdate,1,0 from tblEmpregister where empid='" & StrEmployeeID & "' and atDate BETWEEN '" & Format(dtpFromDate, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND antStatus=0 ;SELECT convert (varchar(5),atdate,106) as 'atDate',workHrs FROM #ind order by year(atDate),month(atDate),day(atdate)"

                Case "Late"
                    wcQuery = "CREATE TABLE #ind (EmpID NVARCHAR (6),atDate DATETIME,WorkHrs NUMERIC (18,2),NOTHrs NUMERIC (18,2)); INSERT INTO #ind SELECT empID,atdate,1,0 from tblEmpregister where empid='" & StrEmployeeID & "' and atDate BETWEEN '" & Format(dtpFromDate, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND isLate=1 ; SELECT convert (varchar(5),atdate,106) as 'atDate',workHrs FROM #ind order by year(atDate),month(atDate),day(atdate)"

                Case "Leave"
                    wcQuery = "CREATE TABLE #ind (EmpID NVARCHAR (6),atDate DATETIME,WorkHrs NUMERIC (18,2),NOTHrs NUMERIC (18,2)); INSERT INTO #ind SELECT empID,atdate,1,0 from tblEmpregister where empid='" & StrEmployeeID & "' and atDate BETWEEN '" & Format(dtpFromDate, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND isLeave=1 ;SELECT convert (varchar(5),atdate,106) as 'atDate',workHrs FROM #ind order by year(atDate),month(atDate),day(atdate)"

                Case "Nopay"
                    wcQuery = "CREATE TABLE #ind (EmpID NVARCHAR (6),atDate DATETIME,WorkHrs NUMERIC (18,2),NOTHrs NUMERIC (18,2)); INSERT INTO #ind SELECT empID,atdate,1,0 from tblEmpregister where empid='" & StrEmployeeID & "' and atDate BETWEEN '" & Format(dtpFromDate, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND autoleaveNo<>0 ; SELECT convert (varchar(5),atdate,106) as 'atDate',workHrs FROM #ind order by year(atDate),month(atDate),day(atdate)"

            End Select

            wcCommand.Connection = wcconn
            wcCommand.CommandText = wcQuery

            Dim wcAdapter As New SqlClient.SqlDataAdapter
            Dim wcData As New DataSet
            wcAdapter.SelectCommand = wcCommand
            wcAdapter.Fill(wcData, "tab03")

            'wcQuery = "select convert (varchar(10),atdate,101) as 'tt2' ,count (empid) as 'num2'  FROM [tblEmpRegister] where (atdate between '" & dtWorkingDate.Date.AddDays(-7) & "' and '" & dtWorkingDate.Date & "') and antstatus=0 group by atdate"
            'wcCommand.Connection = wcconn
            'wcCommand.CommandText = wcQuery
            'wcAdapter.SelectCommand = wcCommand
            'wcAdapter.Fill(wcData, "tab01")

            chartWeek.Series("Present").XValueMember = "atDate"
            'chartWeek.Series("NOTH").XValueMember = "atDate"
            'chartWeek.Series("Late").XValueMember = "atDate"
            'chartWeek.Series("Late").XValueMember = "atDate"
            chartWeek.Series("Present").YValueMembers = "workHrs"
            'chartWeek.Series("NOTH").YValueMembers = "NOTHrs"
            'chartWeek.Series("Late").YValueMembers = "LateK"
            'chartWeek.Series("Late").YValueMembers = "LeaveK"

            'chartWeek.Series("Series1").Name = "Present"
            'chartWeek.Series("Series2").Name = "Absent"

            chartWeek.Series(0).Points.AddXY("Present (" & wcData.Tables("tab03").Rows(0)("workHrs").ToString & ")", wcData.Tables("tab03").Rows(0)("workHrs").ToString)

            If wcData.Tables("tab03").Rows.Count > 1 Then

                'chartWeek.Series(1).Points.AddXY("NOTH (" & IIf(wcData.Tables("tab03").Rows.Count = 1, "0", wcData.Tables("tab03").Rows(1)("NOTHrs").ToString) & ")", IIf(wcData.Tables("tab03").Rows.Count = 1, "0", wcData.Tables("tab03").Rows(1)("NOTHrs").ToString))
                'chartWeek.Series(2).Points.AddXY("Late (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LateK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LateK").ToString))
                'chartWeek.Series(3).Points.AddXY("Leave (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LeaveK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LeaveK").ToString))

            End If

            ' Draw as 3D Cylinder
            'ChartWeek.Series(0)("DrawingStyle") = "Cylinder"
            'ChartWeek.Series(1)("DrawingStyle") = "Cylinder"
            chartWeek.Series(0).ChartType = SeriesChartType.RangeColumn
            'chartWeek.Series(1).ChartType = SeriesChartType.RangeColumn
            'chartWeek.Series(2).ChartType = SeriesChartType.RangeColumn
            'chartWeek.Series(3).ChartType = SeriesChartType.RangeColumn

            chartWeek.DataSource = wcData.Tables("tab03")
            ' Set series point width
            chartWeek.Series(0)("PointWidth") = "0.5"
            'chartWeek.Series(1)("PointWidth") = "1"
            'chartWeek.Series(2)("PointWidth") = "1"
            'chartWeek.Series(3)("PointWidth") = "1"

            ' Show chart with right-angled axes
            ' ChartWeek.ChartAreas("ChartArea1").Area3DStyle.IsRightAngleAxes = True
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.LightStyle = LightStyle.Realistic
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.PointDepth = 55

            ' Show columns as clustered
            ' ChartWeek.ChartAreas("ChartArea1").Area3DStyle.IsClustered = False

            ' Show X axis end labels
            'ChartWeek.ChartAreas("ChartArea1").AxisX.LabelStyle.IsEndLabelVisible = False

            ' Set rotational angles
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Inclination = 30
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Inclination = 30

            chartWeek.ChartAreas("ChartArea1").AxisX.Interval = 1

            'Dim intCount As Integer = fk_sqlDbl("select count(*) from tblemployee where empstatus <> 9 and tblemployee.deptID in ('" & StrUserLvDept & "')")
            'intCount = Math.Round(intCount / 10.0) * 10
            'Dim nCount As Integer = intCount / 10
            'nCount = Math.Round(nCount / 10.0) * 10

            chartWeek.ChartAreas("ChartArea1").AxisY.Interval = 14
            ' Show as 3D
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            chartWeek.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = 65

            'ChartWeek.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "dd"

            'ChartWeek.Series("Series1").SmartLabelStyle.Enabled = True

            'Chart3.DataSource = wcData.Tables("tab02")
            chartWeek.DataBind()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub CreateMonthSum()
        Dim dtpFromDate As DateTime = DateAdd(DateInterval.Month, -1, dtpToDate.Value)

        sSQL = "delete from tblViewTK;"
        sSQL = sSQL & " insert into tblViewTK SELECT tblEmpRegister.atDate,tblEmpRegister.EmpID,tblEmployee.DeptID,tblEmployee.CatID,tblEmployee.DesigID,tblEmpRegister.AllShifts,0,0,0,0,0,0 FroM tblEmployee,tblEmpRegister WHERE tblEmployee.RegID = tblEmpRegister.EmpID AND tblEmpRegister.AtDate BETWEEN '" & Format(dtpFromDate, "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "' and  tblemployee.empstatus <> 9 AND tblEmployee.DeptID In  ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "');"
        sSQL = sSQL & " UPDATE tblViewTK SET tblViewTK.p = 1 FROM tblEmpRegister,tblViewTK WHERE tblEmpRegister.EmpID = tblViewTK.RegID And tblEmpRegister.AtDate = tblViewTK.AtDate AND tblEmpRegister.AntStatus = 1"
        sSQL = sSQL & " UPDATE tblViewTK SET tblViewTK.a = 1 FROM tblEmpRegister,tblViewTK WHERE tblEmpRegister.EmpID = tblViewTK.RegID And tblEmpRegister.AtDate = tblViewTK.AtDate AND tblEmpRegister.AntStatus = 0"
        sSQL = sSQL & " UPDATE tblViewTK SET tblViewTK.lt = 1 FROM tblEmpRegister,tblViewTK WHERE tblEmpRegister.EmpID = tblViewTK.RegID And tblEmpRegister.AtDate = tblViewTK.AtDate AND tblEmpRegister.IsLate = 1"
        sSQL = sSQL & " UPDATE tblViewTK SET tblViewTK.lv = 1 FROM tblEmpRegister,tblViewTK WHERE tblEmpRegister.EmpID = tblViewTK.RegID And tblEmpRegister.AtDate = tblViewTK.AtDate AND tblEmpRegister.IsLeave = 1"
        sSQL = sSQL & " UPDATE tblViewTK SET tblViewTK.isOf = CASE WHEN tblDayType.WorkUnit = 0 THEN 1 ELSE tblDayType.WorkUnit END FROM tblEmpRegister,tblViewTK,tblDayType WHERE tblEmpRegister.EmpID = tblViewTK.RegID AND tblEmpRegister.DayTypeID = tblDayType.TypeID And tblEmpRegister.AtDate = tblViewTK.AtDate AND tblDayType.WorkUnit <> 1"
        sSQL = sSQL & " UPDATE tblViewTK SET Tot = p+a+lt+lv"
        FK_EQ(sSQL, "S", "", False, False, True)

    End Sub

    Public Sub chartWeekK()
        lblDashboadr.Text = "DASHBOARD OF : " & Format(dtpToDate.Value, "yyyy-MMM-dd")
        lblChartTitle.Text = "Recent 30 Days " & strGridStatus & " from : " & Format(dtpToDate.Value, "yyyy-MMM-dd")

        Try

            'chartWeek.Palette = ChartColorPalette.Pastel
            ''Dim customPalette(4) As Color
            ''customPalette(0) = Color.Green
            ''customPalette(1) = Color.Red
            ''customPalette(2) = Color.Orange
            ''customPalette(3) = Color.Violet
            ''chartWeek.Palette = ChartColorPalette.None
            ''chartWeek.PaletteCustomColors = customPalette

            'lblWeekTitle.Text = "Last Week Attendance"
            'pnlWeekTitle.BackgroundImage = My.Resources.ResourceManager.GetObject(strPanelImage)
            Dim wcconn As New SqlClient.SqlConnection(sqlConString)
            Dim wcCommand As New SqlClient.SqlCommand

            Dim wcQuery As String

            Select Case strGridStatus

                Case "Present"
                    wcQuery = "select convert (varchar(5),tblViewTK.atdate,106) as 'atDate',sum(p) as 'presentK' from tblViewTK  group by atDate order by year(atDate),month(atDate),day(atdate)"

                Case "Absent"
                    wcQuery = "select convert (varchar(5),tblViewTK.atdate,106) as 'atDate',sum(a) as 'presentK' from tblViewTK  group by atDate order by year(atDate),month(atDate),day(atdate)"

                Case "Late"
                    wcQuery = "select convert (varchar(5),tblViewTK.atdate,106) as 'atDate',sum(lt) as 'presentK' from tblViewTK  group by atDate order by year(atDate),month(atDate),day(atdate)"

                Case "Leave"
                    wcQuery = "select convert (varchar(5),tblViewTK.atdate,106) as 'atDate',sum(lv) as 'presentK' from tblViewTK  group by atDate order by year(atDate),month(atDate),day(atdate)"

                Case "Nopay"
                    wcQuery = "select convert (varchar(5),tblViewTK.atdate,106) as 'atDate',sum(a) as 'presentK' from tblViewTK  where a-(lv+isof)>0  group by atDate order by year(atDate),month(atDate),day(atdate)"

            End Select

            '            Dim wcQuery = "delete from tblChart " & _
            '"insert into tblChart select convert (varchar(11),tblEmpRegister.atdate,106) as 'tt2'  " & _
            '",case when tblEmpRegister.antstatus='1' then '1' else '0' end  as 'p'  " & _
            '",case when tblEmpRegister.antstatus='0' then '1' else '0' end  as 'a'  " & _
            '"FROM tblEmpRegister inner join tblemployee on tblEmpRegister.empID=tblemployee.regID where  " & _
            '"(tblEmpRegister.atdate between '" & Format(dtpToDate.Value.AddDays(-6), "yyyyMMdd") & "' and '" & Format(dtpToDate.Value, "yyyyMMdd") & "') and  " & _
            '"tblemployee.empstatus <> 9 AND tblEmployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') " & _
            '"select  DATEPART ( day , DATEADD(d,1,atdate)) as 'atDate',sum(presentK) as presentK ,sum(absentK) as absentK from tblChart group by atDate order by atDate"

            ''Dim wcQuery = "IF OBJECT_ID('tempDB..#tbltemp','U') IS NOT NULL drop table #tbltemp  " & _
            ''  "create table #tblTemp (dateka4  datetime,present numeric(18,0),absent numeric(18,0)) " & _
            ''  "insert into #tblTemp  " & _
            ''  "select convert (varchar(10),tblEmpRegister.atdate,101) as 'tt2' " & _
            ''  ",case when tblEmpRegister.antstatus='1' then '1' else '0' end  as 'p' " & _
            ''  ",case when tblEmpRegister.antstatus='0' then '1' else '0' end  as 'a' " & _
            ''  "FROM tblEmpRegister inner join tblemployee on tblEmpRegister.empID=tblemployee.regID where (tblEmpRegister.atdate between '" & dtWorkingDate.Date.AddDays(-6) & "' and '" & dtWorkingDate.Date & "') and tblemployee.empstatus <>9 " & _
            ''  "select dateka4,sum(present) as present ,sum(absent) as absent from #tbltemp group by dateka4 "

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

            chartWeek.Series("Present").XValueMember = "atDate"
            'chartWeek.Series("Absent").XValueMember = "atDate"
            'chartWeek.Series("Late").XValueMember = "atDate"
            'chartWeek.Series("Late").XValueMember = "atDate"
            chartWeek.Series("Present").YValueMembers = "presentK"
            'chartWeek.Series("Absent").YValueMembers = "absentK"
            'chartWeek.Series("Late").YValueMembers = "LateK"
            'chartWeek.Series("Late").YValueMembers = "LeaveK"

            'chartWeek.Series("Series1").Name = "Present"
            'chartWeek.Series("Series2").Name = "Absent"

            chartWeek.Series(0).Points.AddXY("Present (" & wcData.Tables("tab02").Rows(0)("presentK").ToString & ")", wcData.Tables("tab02").Rows(0)("presentK").ToString)

            If wcData.Tables("tab02").Rows.Count > 1 Then

                'chartWeek.Series(1).Points.AddXY("Absent (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("absentK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("absentK").ToString))
                'chartWeek.Series(2).Points.AddXY("Late (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LateK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LateK").ToString))
                'chartWeek.Series(3).Points.AddXY("Leave (" & IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LeaveK").ToString) & ")", IIf(wcData.Tables("tab02").Rows.Count = 1, "0", wcData.Tables("tab02").Rows(1)("LeaveK").ToString))

            End If

            ' Draw as 3D Cylinder
            'ChartWeek.Series(0)("DrawingStyle") = "Cylinder"
            'ChartWeek.Series(1)("DrawingStyle") = "Cylinder"
            chartWeek.Series(0).ChartType = SeriesChartType.RangeColumn
            'chartWeek.Series(1).ChartType = SeriesChartType.RangeColumn
            'chartWeek.Series(2).ChartType = SeriesChartType.RangeColumn
            'chartWeek.Series(3).ChartType = SeriesChartType.RangeColumn

            chartWeek.DataSource = wcData.Tables("tab02")
            ' Set series point width
            chartWeek.Series(0)("PointWidth") = "0.5"
            'chartWeek.Series(1)("PointWidth") = "1"
            'chartWeek.Series(2)("PointWidth") = "1"
            'chartWeek.Series(3)("PointWidth") = "1"

            ' Show chart with right-angled axes
            ' ChartWeek.ChartAreas("ChartArea1").Area3DStyle.IsRightAngleAxes = True
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.LightStyle = LightStyle.Realistic
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.PointDepth = 55

            ' Show columns as clustered
            ' ChartWeek.ChartAreas("ChartArea1").Area3DStyle.IsClustered = False

            ' Show X axis end labels
            'ChartWeek.ChartAreas("ChartArea1").AxisX.LabelStyle.IsEndLabelVisible = False

            ' Set rotational angles
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Inclination = 30
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Inclination = 30

            chartWeek.ChartAreas("ChartArea1").AxisX.Interval = 1

            Dim intCount As Integer = fk_sqlDbl("select count(*) from tblemployee where empstatus <> 9 and tblemployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')")
            intCount = Math.Round(intCount / 10.0) * 10
            Dim nCount As Integer = intCount / 10
            nCount = Math.Round(nCount / 10.0) * 10

            chartWeek.ChartAreas("ChartArea1").AxisY.Interval = nCount
            ' Show as 3D
            'ChartWeek.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

            chartWeek.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = 65

            'ChartWeek.ChartAreas("ChartArea1").AxisX.LabelStyle.Format = "dd"

            'ChartWeek.Series("Series1").SmartLabelStyle.Enabled = True

            'Chart3.DataSource = wcData.Tables("tab02")
            chartWeek.DataBind()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Public Sub chartTwo()

    '    Try
    '        'ChartDay.BackImage = strChartPath
    '        'ChartDay.ChartAreas("ChartArea1").BackImage = Nothing
    '        'ChartDay.Titles(0).Text = "Attendence of : " & Format(dtpToDate.Value, "yyyy/MM/dd")
    '        'ChartDay.Titles(0).BackImage = strPanelImage

    '        Dim customPalette(3) As Color
    '        customPalette(0) = clrFocused
    '        customPalette(1) = Color.LightGray
    '        'customPalette(2) = Color.Blue

    '        ChartDay.Palette = ChartColorPalette.None
    '        ChartDay.PaletteCustomColors = customPalette

    '        'ChartDay.Palette = chPala
    '        lblDayTitle.Text = "Attendence of : " & Format(dtpToDate.Value, "yyyy/MM/dd")
    '        'pnlDayTitle.BackgroundImage = My.Resources.ResourceManager.GetObject(strPanelImage)
    '        Dim wcconn As New SqlClient.SqlConnection(sqlConString)
    '        Dim wcCommand As New SqlClient.SqlCommand

    '        'Dim wcQuery = "select convert (varchar(10),atdate,101) as 'tt' ,count (empid) as 'num'  FROM [tblEmpRegister] where (atdate = '" & dtWorkingDate.Date & "' ) and antstatus=0 group by atdate"

    '        Dim wcQuery = "select convert (varchar(10),tblChart.atdate,101) as 'tt2',sum(presentK) as 'num2' from tblChart where atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' group by atDate"
    '        wcCommand.Connection = wcconn
    '        wcCommand.CommandText = wcQuery
    '        Dim wcAdapter As New SqlClient.SqlDataAdapter
    '        Dim wcData As New DataSet
    '        wcAdapter.SelectCommand = wcCommand
    '        wcAdapter.Fill(wcData, "tab01")

    '        'wcQuery = "select convert (varchar(10),atdate,101) as 'tt2' ,count (empid) as 'num2'  FROM [tblEmpRegister] where (atdate = '" & dtWorkingDate.Date & "' ) and antstatus=1 group by atdate"
    '        wcQuery = "select convert (varchar(10),tblChart.atdate,101)  as 'tt',sum(absentK)  as 'num' from tblChart where atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' group by atDate"
    '        wcCommand.Connection = wcconn
    '        wcCommand.CommandText = wcQuery
    '        wcAdapter.SelectCommand = wcCommand
    '        wcAdapter.Fill(wcData, "tab01")

    '        ChartDay.Series.Clear()
    '        ChartDay.Series.Add("Series1")

    '        ChartDay.Series("Series1").Points.AddXY("Pr (" & wcData.Tables("tab01").Rows(0)("num2").ToString & ")", wcData.Tables("tab01").Rows(0)("num2").ToString)

    '        If wcData.Tables("tab01").Rows.Count > 1 Then

    '            ChartDay.Series("Series1").Points.AddXY("Ab (" & IIf(wcData.Tables("tab01").Rows.Count = 1, "0", wcData.Tables("tab01").Rows(1)("num").ToString) & ")", IIf(wcData.Tables("tab01").Rows.Count = 1, "0", wcData.Tables("tab01").Rows(1)("num").ToString))

    '        End If
    '        'ChartDay.Series("Series1").ShadowColor = Color.Gray
    '        'ChartDay.Series("Series2").ShadowColor = Color.Gray
    '        'ChartDay.Series("Series1").ShadowOffset = 4

    '        ' Set Doughnut chart type
    '        ChartDay.Series("Series1").ChartType = strChartTypeDounut

    '        'ChartDay.Legends.Add(New Legend("Legend2"))

    '        '' Set Docking chart of the legend to the Default chart area.
    '        ''ChartDay.Legends("Legend2").DockToChartArea = "Default"

    '        '' Assign the legend to Series1.
    '        'ChartDay.Series("Series1").Legend = "Legend2"
    '        'ChartDay.Series("Series1").IsVisibleInLegend = True

    '        ' Set labels style
    '        'ChartDay.Series("Series1")("PieLabelStyle") = "Inside"
    '        'ChartDay.Series("Series1").SmartLabelStyle.Enabled = True
    '        ' Set Doughnut radius percentage
    '        ChartDay.Series("Series1")("DoughnutRadius") = "50"

    '        ' Explode data point with label "Italy"
    '        'ChartDay.Series("Series1").Points(1)("Exploded") = "true"

    '        ' Enable 3D
    '        ChartDay.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

    '        ' Set drawing style
    '        ChartDay.Series("Series1")("PieDrawingStyle") = "SoftEdge"

    '        ChartDay.ChartAreas("ChartArea1").Area3DStyle.Inclination = 60

    '        ChartDay.ChartAreas("ChartArea1").Area3DStyle.Rotation = 45

    '        'chartDay.ChartAreas("ChartArea1").InnerPlotPosition = New ElementPosition(0, 0, 100, 100)

    '        ChartDay.ChartAreas("ChartArea1").Area3DStyle.PointDepth = 100

    '        ChartDay.ChartAreas("ChartArea1").AxisX.IsMarginVisible = False

    '        ChartDay.DataBind()

    '    Catch ex As Exception

    '    End Try

    'End Sub

    ' Mouse Down Event
    'Private Sub chartDay_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    '    ' Call Hit Test Method
    '    Dim result As HitTestResult = ChartDay.HitTest(e.X, e.Y)

    '    Dim exploded As Boolean = False

    '    ' Check if data point is already exploded
    '    If result.PointIndex >= 0 Then

    '        If ChartDay.Series("Series1").Points(result.PointIndex).CustomProperties = "Exploded=true" Then
    '            exploded = True
    '        Else
    '            exploded = False
    '        End If

    '    End If

    '    ' Remove all exploded attributes
    '    Dim point As DataPoint
    '    For Each point In ChartDay.Series("Series1").Points
    '        point.CustomProperties = ""
    '    Next point

    '    ' If data point is already exploded get out.
    '    If exploded = False Then

    '        ' If data point is selected
    '        If result.ChartElementType = ChartElementType.DataPoint Then
    '            ' Set Attribute
    '            Dim pointk As DataPoint = ChartDay.Series("Series1").Points(result.PointIndex)
    '            pointk.CustomProperties = "Exploded = true"
    '        End If


    '        ' If legend item is selected
    '        If result.ChartElementType = ChartElementType.LegendItem Then
    '            ' Set Attribute
    '            Dim pointl As DataPoint = ChartDay.Series("Series1").Points(result.PointIndex)
    '            pointl.CustomProperties = "Exploded = true"
    '        End If

    '    End If

    '    If exploded = True Then

    '        ' If data point is selected
    '        If result.ChartElementType = ChartElementType.DataPoint Then
    '            ' Set Attribute
    '            Dim pointk As DataPoint = ChartDay.Series("Series1").Points(result.PointIndex)
    '            pointk.CustomProperties = "Exploded = false"
    '        End If


    '        ' If legend item is selected
    '        If result.ChartElementType = ChartElementType.LegendItem Then
    '            ' Set Attribute
    '            Dim pointl As DataPoint = ChartDay.Series("Series1").Points(result.PointIndex)
    '            pointl.CustomProperties = "Exploded = false"
    '        End If

    '    End If

    'End Sub 'chartDay_MouseDown

    'Private Sub vieww(ByVal StrEid As String)

    '    Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM [tblImgInfo] where [ImgID]='" & StrEid & "'")
    '    If bolEx = True Then
    '        Try
    '            Dim CN As New SqlConnection(sqlConString)
    '            CN.Open()

    '            Dim adapter As New SqlDataAdapter
    '            adapter.SelectCommand = New SqlCommand("SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & StrEid & "' and Status='0'", CN)
    '            Dim Data As New DataTable
    '            'adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn)

    '            Dim commandbuild As New SqlCommandBuilder(adapter)
    '            adapter.Fill(Data)
    '            ' MsgBox(Data.Rows.Count)


    '            Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("svImage")
    '            Dim lstr As New System.IO.MemoryStream(lb)
    '            picPa.Image = Image.FromStream(lstr)
    '            picPa.SizeMode = PictureBoxSizeMode.Zoom
    '            lstr.Close()

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    Else
    '        picPa.Image = Nothing
    '    End If

    'End Sub

    Public Sub ChangeThemeka()

        Dim intRandomTheme As Integer = fk_sqlDbl("select isRandomtheme from tblCompany")
        'If intRandomTheme = 1 Then
        'Dim intThemeID As Integer
        'strThemeID = fk_RetString("select thID from tblTheme where status=1") : intThemeID = CInt(strThemeID) : If intThemeID < 9 Then intThemeID += 1 Else intThemeID = 1
        'sSQL = "update tbltheme set status ='0';" : sSQL = sSQL & "update tbltheme set status=1 where thID='" & Format(intThemeID, "0#") & "'" : FK_EQ(sSQL, "E", "", False, False, True)
        'Else
        strThemeID = fk_RetString("select thID from tblTheme where status=1")
        'End If

        Dim strThemeName As String = ""

        strPanelImage = fk_RetString("select panelImage from tblTheme where ThID ='" & strThemeID & "'")
        strMouseEnter = fk_RetString("select btnMsEnter from tblTheme where ThID ='" & strThemeID & "'")
        strMouseLeave = fk_RetString("select btnMsLeave from tblTheme where ThID ='" & strThemeID & "'")
        strPBEnter = fk_RetString("select pbMsEnter from tblTheme where ThID ='" & strThemeID & "'")
        strPBLeave = fk_RetString("select pbMsLeave from tblTheme where ThID ='" & strThemeID & "'")
        strThemeName = fk_RetString("select thName from tblTheme where ThID ='" & strThemeID & "'")
        strColorName = fk_RetString("select focusColor from tblTheme where ThID ='" & strThemeID & "'")
        strStrech = fk_RetString("select isStrech from tblTheme where ThID ='" & strThemeID & "'")

        clrFocused = Color.FromName(strColorName)
        'chartOne()
        'chartTwo()
    End Sub

    Private Sub UpdateRemortLocationDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LoadForm(New frmDataSync)
    End Sub

    Private Sub INOUTReportToExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmQryReport)
    End Sub

    Private Sub pnlRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlRight.Click
        System.Diagnostics.Process.Start("http://www.HRIS.com")
    End Sub

    Private Sub pnlRight_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlRight.MouseEnter
        Cursor = Cursors.Hand
    End Sub

    Private Sub pnlRight_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlRight.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub timerK_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pnlSubShort.Height += 42
        ''pnlSubShort.Height = intHeightK
        'If pnlSubShort.Height >= intHeightK Then
        '    'pnlSubShort.Dock = DockStyle.Fill
        '    'intHeight = pnlSubShort.Height
        '    pnlSubShort.Height = intHeightK
        '    'pnlTopMAin.Visible = True
        '    timerK.Stop()
        'End If
    End Sub

    Private Sub timerKt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''pnlSubShort.Dock = DockStyle.None
        'pnlSubShort.Height -= 42
        ''pnlSubShort.Height = intHeightK
        'If pnlSubShort.Height <= 0 Then
        '    'pnlMainShort.Dock = DockStyle.Fill
        '    'intHeight = pnlMainShort.Height
        '    timerKt.Stop()
        'End If
    End Sub

    'Private Sub shortCut()
    '    lvMain.LargeImageList = Me.IMG6060
    '    lvMain.SmallImageList = Me.IMG6060
    '    lvMain.View = View.SmallIcon
    '    'lvMain.BorderStyle = BorderStyle.FixedSingle
    '    If FK_UI("Icon : Dashboard") = True Then lvMain.Items.Add("Dashboard", 1)
    '    If FK_UI("Icon : Employee Profile") = True Then lvMain.Items.Add("Employee Profile", 2)
    '    If FK_UI("Icon : Attendace Review") = True Then lvMain.Items.Add("Attendace Review", 3)
    '    If FK_UI("Icon : Roster Management") = True Then lvMain.Items.Add("Roster Management", 2)
    '    If FK_UI("Icon : Attendace Manager") = True Then lvMain.Items.Add("Attendace Manager", 3)
    '    If FK_UI("Icon : Leave Management") = True Then lvMain.Items.Add("Leave Management", 4)
    '    If FK_UI("Icon : Report Management") = True Then lvMain.Items.Add("Report Management", 2)
    '    If FK_UI("Icon : Payroll Management") = True Then lvMain.Items.Add("Payroll Management", 2)
    '    If FK_UI("Icon : Loan Management") = True Then lvMain.Items.Add("Loan Management", 3)
    '    'If FK_UI("Icon : Salary Process II ") = True Then lvSK.Items.Add("Salary Process II", 52)
    '    'If FK_UI("Icon : Monthly Transactions ") = True Then lvSK.Items.Add("Monthly Transections", 58)
    '    'If FK_UI("Icon : Edit Attendence Summery ") = True Then lvSK.Items.Add("Edit Atten. Summery", 11)
    '    'If FK_UI("Icon : User Icons ") = True Then lvSK.Items.Add("User Icons", 73)
    '    'If FK_UI("Icon : Banks.Branches ") = True Then lvSK.Items.Add("Manage Banks", 62)
    '    'If FK_UI("Icon : Set Users ") = True Then lvSK.Items.Add("Set Users", 24)
    '    'If FK_UI("Icon : Finalize Passenger Info") = True Then lvSK.Items.Add("Finalize Passenger Info", 1)
    '    'If FK_UI("Icon : Match Finger ") = True Then lvSK.Items.Add("Match Finger", 7)
    '    'If FK_UI("Icon : Recieved Cash") = True Then lvSK.Items.Add("Recieved Cash", 8)
    '    'If FK_UI("Icon : Medical Summary ") = True Then lvSK.Items.Add("Medical Summary", 11)
    '    'If FK_UI("Icon : EMP Items") = True Then lvSK.Items.Add("Get Excel", 63)
    '    'Menues
    '    'If FK_UI("Menu : Edit") = True Then Me.EditMenu.Visible = True

    '    '============================================================================================================

    '    'btntSearchB_Click(sender, e)
    '    'ViewGridStatus()
    'End Sub

    'Private Sub SelectSuitableForm()

    '    Select Case strSelctedMenu

    '        Case "Employee Profile"
    '            If EmployeeInformationToolStripMenuItem.Enabled = True Then
    '                LoadForm(New frmEmployeeInfo)
    '            End If
    '        Case "Attendace Review"
    '            'If AssignEmployeesToShiftToolStripMenuItem.Enabled = True Then
    '            LoadForm(New AttendanceDashBoard)
    '            'End If
    '        Case "Report Management"
    '            LoadForm(New frmReportViewer)
    '            'If DownloadDataToolStripMenuItem.Enabled = True Then
    '            '    If strDownlodform = "Realand 50 T" Then
    '            '        LoadForm(New frmDataRealand50T)
    '            '    ElseIf strDownlodform = "ZK Before INO1 Device" Then
    '            '        LoadForm(New frmBeforeINO1)
    '            '    ElseIf strDownlodform = "Realand Device New" Then
    '            '        LoadForm(New frmDataDRealandN)
    '            '    ElseIf strDownlodform = "Realand Face Detetion" Then
    '            '        'LoadForm(New frmDataDownLFD)
    '            '    ElseIf strDownlodform = "ZK K14 Device" Then
    '            '        LoadForm(New frmDataDownLzk14)
    '            '    ElseIf strDownlodform = "ZK Face Detection" Then
    '            '        LoadForm(New frmDataZKFace302D)
    '            '    ElseIf strDownlodform = "ZK Device File Only" Then
    '            '        LoadForm(New frmDatZKFromFile)
    '            '    End If
    '            'End If
    '        Case "Roster Management"
    '            'If ManualAdjestmentToolStripMenuItem.Enabled = True Then
    '            'StrEmployeeID = ""
    '            LoadForm(New frmNewRoster)
    '            'End If
    '        Case "Attendace Manager"
    '            'If ProcessDataToolStripMenuItem.Enabled = True Then
    '            LoadForm(New frmChkDailyShift)
    '            'End If
    '        Case "Report Selection"
    '            If ReportViewerToolStripMenuItem.Enabled = True Then
    '                LoadForm(New frmReportViewer)
    '            End If
    '        Case "Leave Management"
    '            'If ApplyLeaveToolStripMenuItem.Enabled = True Then
    '            LoadForm(New frmApplyLeav)
    '            'End If

    '    End Select

    'End Sub

    Private Sub lvMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'If e.Button = MouseButtons.Right Then
        'contextmenu
        ''cmEmployeeProperties.Items.Clear()
        ''lvSub.Items.Clear()
        ''lvSub.View = View.SmallIcon
        ''lvSub.LargeImageList = Me.IMG6060
        ''lvSub.SmallImageList = Me.IMG6060
        ''lvSub.ForeColor = Color.DimGray

        ''pnlSubShort.Height = 0
        ''intHeightK = pnlMainFilled.Height
        'cmKasun.Items.Add("&New")
        'If lvMain.SelectedItems.Count > 0 Then
        '    'timerK.Start()
        '    strSelctedMenu = (lvMain.FocusedItem.SubItems(0).Text)
        '    'cmKasun.Items.Add(strSelctedMenu)
        '    Select Case strSelctedMenu
        '        Case "Employee Profile"
        '            'cmKasun.Items.Add("Attendance Import")            
        '            If FK_UI("Icon : Back To Main") = True Then lvSub.Items.Add("Back To Main", 1)
        '            If FK_UI("Icon : Employee Data") = True Then lvSub.Items.Add("Employee Data", 2)
        '            If FK_UI("Icon : Assign Shift") = True Then lvSub.Items.Add("Assign Shift", 3)

        '        Case "Leave Management"
        '            If FK_UI("Icon : Back To Main") = True Then lvSub.Items.Add("Back To Main", 1)
        '            If FK_UI("Icon : Apply Leave") = True Then lvSub.Items.Add("Apply Leave", 2)
        '            If FK_UI("Icon : Cancel Leave") = True Then lvSub.Items.Add("Cancel Leave", 5)

        '        Case "Processes"
        '            If FK_UI("Icon : Back To Main") = True Then lvSub.Items.Add("Back To Main", 6)
        '            If FK_UI("Icon : Data Download") = True Then lvSub.Items.Add("Data Download", 4)
        '            If FK_UI("Icon : Process Data") = True Then lvSub.Items.Add("Process Data", 2)
        '            If FK_UI("Icon : Manual Adjestments") = True Then lvSub.Items.Add("Manual Adjestments", 1)

        '        Case "Report Management"
        '            If FK_UI("Icon : Back To Main") = True Then lvSub.Items.Add("Back To Main", 1)
        '            If FK_UI("Icon : Report Selection") = True Then lvSub.Items.Add("Report Selection", 2)

        '    End Select
        'Else
        '    'timerKt.Start()
        'End If

        ''cmEmployeeProperties.Show(lvMain, New Point(e.X, e.Y))
        'End If
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    'code here to GetItemAt. I am unsure as to what you mean by this?
        'End If
        'SelectSuitableForm()
    End Sub

    Private Sub cmEmployeeProperties_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        strSelctedMenu = e.ClickedItem.Text
        'SelectSuitableForm()
    End Sub

    Private Sub ImportExtraDaysToLeaeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmImportExtraDaystoLeave)
    End Sub

    Private Sub SetRandomReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmRandomReport)
    End Sub

    Private Sub RandomReportViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmRandomReport)
    End Sub

    Private Sub SetUserViewLevelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetUserViewLv)
    End Sub

    Private Sub RostersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmNewRoster)
    End Sub

    Private Sub ResignEmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmResign)
    End Sub

    Private Sub SetRandomReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmRandomReport)
    End Sub

    Private Sub OTApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmOTAuthorize)
    End Sub

    'Private Sub ViewGridStatus()
    '    Dim strLastDownload As String = fk_RetString("select ISNULL(max(CONVERT(VARCHAR(8),crTime,112)),0) from tblDownloadHistory")
    '    sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crTime,106)+',  '+CONVERT(VARCHAR(8), crTime,108) ),0) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "'"
    '    lblLstDownTime.Text = "Last : " & fk_RetString(sSQL)
    '    sSQL = "select dcount from tblDownloadHistory where crtime=(select max(crTime) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "')"
    '    lblDownCount.Text = " Records : " & fk_RetString(sSQL)
    '    sSQL = "select count(*) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)=(select max(CONVERT(VARCHAR(8),crTime,112)) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "')"
    '    lblLstDownTimes.Text = "No Of Times : " & fk_RetString(sSQL)
    '    If Format(dtWorkingDate, "yyyyMMdd") = strLastDownload Then
    '        'pnlLstDownload.BackgroundImage = My.Resources.PositiveStatus
    '    Else
    '        'pnlLstDownload.BackgroundImage = My.Resources.NegativeStatus
    '    End If

    '    Dim strLastProcessed As String = fk_RetString("select ISNULL(max(CONVERT(VARCHAR(8),crTime,112)),0) from tblProcessHistory")
    '    sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crTime,106)+',  '+CONVERT(VARCHAR(8), crTime,108) ),0) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastProcessed & "' "
    '    lblLstPrTime.Text = "Last : " & fk_RetString(sSQL)
    '    sSQL = "select pcount from tblProcessHistory where crtime=(select max(crTime) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastProcessed & "')"
    '    lblLstPrCount.Text = " Records : " & fk_RetString(sSQL)
    '    sSQL = "select count(*) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)=(select max(CONVERT(VARCHAR(8),crTime,112)) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastProcessed & "')"
    '    lbllstPrTim.Text = "No Of Times : " & fk_RetString(sSQL)
    '    If Format(dtWorkingDate, "yyyyMMdd") = strLastProcessed Then
    '        'pnlLstPrcessed.BackgroundImage = My.Resources.PositiveStatus
    '    Else
    '        'pnlLstPrcessed.BackgroundImage = My.Resources.NegativeStatus
    '    End If

    '    Dim strLastRpVivd As String = fk_RetString("select ISNULL(max(CONVERT(VARCHAR(8),crTime,112)),0) from tblReportViewHistory")
    '    sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crTime,106)+',  '+CONVERT(VARCHAR(8), crTime,108) ),0) from tblReportViewHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastRpVivd & "' "
    '    lblLstRpTime.Text = "Last : " & fk_RetString(sSQL)
    '    sSQL = "select rEmpcount from tblReportViewHistory where crtime=(select max(crTime) from tblReportViewHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastRpVivd & "')"
    '    lblLstVwCount.Text = " Records : " & fk_RetString(sSQL)
    '    sSQL = "select count(*) from tblReportViewHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastRpVivd & "'"
    '    lblLstViR.Text = "No Of Times : " & fk_RetString(sSQL)
    '    If Format(dtWorkingDate, "yyyyMMdd") = strLastRpVivd Then
    '        'pnlLstPrcessed.BackgroundImage = My.Resources.PositiveStatus
    '    Else
    '        'pnlLstPrcessed.BackgroundImage = My.Resources.NegativeStatus
    '    End If

    '    Dim strLastFix As String = fk_RetString("select ISNULL(max(CONVERT(VARCHAR(8),crDate,112)),0) from tbldimachineManual")
    '    sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crDate,106)+',  '+CONVERT(VARCHAR(8), crDate,108) ),0) from tbldimachineManual where CONVERT(VARCHAR(8),crDate,112)= '" & strLastFix & "'"
    '    lblLstFixTime.Text = "Last : " & fk_RetString(sSQL)
    '    sSQL = "select trid from tbldimachineManual where crDate=(select max(crDate) from tbldimachineManual where CONVERT(VARCHAR(8),crDate,112)= '" & strLastFix & "')"
    '    lbllstFixCounr.Text = " Records : " & fk_RetString(sSQL)
    '    sSQL = "select count(*) from tbldimachineManual where CONVERT(VARCHAR(8),crDate,112)= '" & strLastFix & "'"
    '    lblLstFixT.Text = "No Of Times : " & fk_RetString(sSQL)
    '    If Format(dtWorkingDate, "yyyyMMdd") = strLastFix Then
    '        'pnlLstDownload.BackgroundImage = My.Resources.PositiveStatus
    '    Else
    '        'pnlLstDownload.BackgroundImage = My.Resources.NegativeStatus
    '    End If

    '    intLoad = 1

    'End Sub

    Private Sub ViewSelectedGridStatus()
        'Dim strLastDownload As String = Format(dtpToDate.Value, "yyyyMMdd") 'fk_RetString("select max(CONVERT(VARCHAR(8),crTime,112)) from tblDownloadHistory")
        'sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crTime,106)+',  '+CONVERT(VARCHAR(8), crTime,108) ),0) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "'"
        'lblLstDownTime.Text = "Last : " & fk_RetString(sSQL)
        'sSQL = "select dcount from tblDownloadHistory where crtime=(select max(crTime) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "')"
        'lblDownCount.Text = " Records : " & fk_RetString(sSQL)
        'sSQL = "select count(*) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)=(select max(CONVERT(VARCHAR(8),crTime,112)) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "')"
        'lblLstDownTimes.Text = "No Of Times : " & fk_RetString(sSQL)
        'If Format(dtWorkingDate, "yyyyMMdd") = strLastDownload Then
        '    'pnlLstDownload.BackgroundImage = My.Resources.PositiveStatus
        'Else
        '    'pnlLstDownload.BackgroundImage = My.Resources.NegativeStatus
        'End If

        'Dim strLastProcessed As String = Format(dtpToDate.Value, "yyyyMMdd") 'fk_RetString("select max(CONVERT(VARCHAR(8),crTime,112)) from tblProcessHistory")
        'sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crTime,106)+',  '+CONVERT(VARCHAR(8), crTime,108) ),0) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastProcessed & "' "
        'lblLstPrTime.Text = "Last : " & fk_RetString(sSQL)
        'sSQL = "select pcount from tblProcessHistory where crtime=(select max(crTime) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastProcessed & "')"
        'lblLstPrCount.Text = " Records : " & fk_RetString(sSQL)
        'sSQL = "select count(*) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)=(select max(CONVERT(VARCHAR(8),crTime,112)) from tblProcessHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastProcessed & "')"
        'lbllstPrTim.Text = "No Of Times : " & fk_RetString(sSQL)
        'If Format(dtWorkingDate, "yyyyMMdd") = strLastProcessed Then
        '    'pnlLstPrcessed.BackgroundImage = My.Resources.PositiveStatus
        'Else
        '    'pnlLstPrcessed.BackgroundImage = My.Resources.NegativeStatus
        'End If

        'Dim strLastRpVivd As String = Format(dtpToDate.Value, "yyyyMMdd") 'fk_RetString("select ISNULL(max(CONVERT(VARCHAR(8),crTime,112)),0) from tblReportViewHistory")
        'sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crTime,106)+',  '+CONVERT(VARCHAR(8), crTime,108) ),0) from tblReportViewHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastRpVivd & "' "
        'lblLstRpTime.Text = "Last : " & fk_RetString(sSQL)
        'sSQL = "select rEmpcount from tblReportViewHistory where crtime=(select max(crTime) from tblReportViewHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastRpVivd & "')"
        'lblLstVwCount.Text = " Records : " & fk_RetString(sSQL)
        'sSQL = "select count(*) from tblReportViewHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastRpVivd & "'"
        'lblLstViR.Text = "No Of Times : " & fk_RetString(sSQL)
        'If Format(dtWorkingDate, "yyyyMMdd") = strLastRpVivd Then
        '    'pnlLstPrcessed.BackgroundImage = My.Resources.PositiveStatus
        'Else
        '    'pnlLstPrcessed.BackgroundImage = My.Resources.NegativeStatus
        'End If

        'Dim strLastFix As String = Format(dtpToDate.Value, "yyyyMMdd") 'fk_RetString("select ISNULL(max(CONVERT(VARCHAR(8),crDate,112)),0) from tbldimachineManual")
        'sSQL = "select ISNULL(max(CONVERT(VARCHAR(15),crDate,106)+',  '+CONVERT(VARCHAR(8), crDate,108) ),0) from tbldimachineManual where CONVERT(VARCHAR(8),crDate,112)= '" & strLastFix & "'"
        'lblLstFixTime.Text = "Last : " & fk_RetString(sSQL)
        'sSQL = "select trid from tbldimachineManual where crDate=(select max(crDate) from tbldimachineManual where CONVERT(VARCHAR(8),crDate,112)= '" & strLastFix & "')"
        'lbllstFixCounr.Text = " Records : " & fk_RetString(sSQL)
        'sSQL = "select count(*) from tbldimachineManual where CONVERT(VARCHAR(8),crDate,112)= '" & strLastFix & "'"
        'lblLstFixT.Text = "No Of Times : " & fk_RetString(sSQL)
        'If Format(dtWorkingDate, "yyyyMMdd") = strLastFix Then
        '    'pnlLstDownload.BackgroundImage = My.Resources.PositiveStatus
        'Else
        '    'pnlLstDownload.BackgroundImage = My.Resources.NegativeStatus
        'End If
    End Sub

    'Private Sub lblPresent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblViewTK.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Present Employees : " & dgvInformation.RowCount
    '    For X As Integer = 0 To dgvInformation.Columns.Count - 1
    '        dgvInformation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '    Next
    '    'clr_Grid(dgvInformation)
    'End Sub

    'Private Sub lblAbsent_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblViewTK.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Absent Employees : " & dgvInformation.RowCount
    '    For X As Integer = 0 To dgvInformation.Columns.Count - 1
    '        dgvInformation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '    Next
    '    'clr_Grid(dgvInformation)
    'End Sub

    'Private Sub lblLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblViewTK.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Late Employees : " & dgvInformation.RowCount
    '    For X As Integer = 0 To dgvInformation.Columns.Count - 1
    '        dgvInformation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '    Next
    '    'clr_Grid(dgvInformation)
    'End Sub

    'Private Sub lblLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblViewTK.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.DeptID IN ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Leave Employees : " & dgvInformation.RowCount
    '    For X As Integer = 0 To dgvInformation.Columns.Count - 1
    '        dgvInformation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '    Next
    '    'clr_Grid(dgvInformation)
    'End Sub

    'Private Sub lblTot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name',tblSetDept.shCode AS 'Department',tblSetEmpCategory.catDesc AS 'Category' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblViewTK.atDate='" & Format(dtpToDate.Value, "yyyyMMdd") & "' and tblemployee.Empstatus<>9 and tblemployee.DeptID IN ('" & f & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Total Employees : " & dgvInformation.RowCount
    '    For X As Integer = 0 To dgvInformation.Columns.Count - 1
    '        dgvInformation.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    '    Next
    '    'clr_Grid(dgvInformation)
    'End Sub

    'Private Sub lblTot_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width
    'End Sub

    'Private Sub lblDownCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strLastDownload As String = fk_RetString("select max(CONVERT(VARCHAR(8),crTime,112)) from tblDownloadHistory")
    '    sSQL = "SELECT dAID FROM tblDownloadHistory WHERE crTime=(select max(crTime) from tblDownloadHistory where CONVERT(VARCHAR(8),crTime,112)= '" & strLastDownload & "')"
    '    Dim intID As Integer = fk_sqlDbl(sSQL)
    '    sSQL = "SELECT tblDiMachine.empid,tblEmployee.dispName,CONVERT(VARCHAR(10),tblDiMachine.cDate,120),CONVERT(VARCHAR(8), tblDiMachine.cTime,108) FROM tblDiMachine LEFT OUTER JOIN tblEmployee ON tblDiMachine.empId=tblEmployee.enrolNo WHERE dAID=" & intID & " ORDER BY tTime"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Last Downloaded Data : " & dgvInformation.RowCount
    'End Sub

    'Private Sub lblLstDownTimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strLastDownload As String = fk_RetString("select max(CONVERT(VARCHAR(8),crTime,112)) from tblDownloadHistory")
    '    sSQL = "select CONVERT(VARCHAR(10),tblDownloadHistory.crTime,120) AS 'Date',CONVERT(VARCHAR(8), tblDownloadHistory.crTime,108) AS 'Time',tblDownloadHistory.dCount AS 'Records' ,tblDownloadHistory.crUser from tblDownloadHistory where  CONVERT(VARCHAR(8),crTime,112)='" & strLastDownload & "'"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Downloaded Times : " & dgvInformation.RowCount
    'End Sub

    'Private Sub lbllstPrTimes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim strLastProcessed As String = fk_RetString("select max(CONVERT(VARCHAR(8),crTime,112)) from tblProcessHistory")
    '    sSQL = "select CONVERT(VARCHAR(10),tblProcessHistory.crTime,120) AS 'Date',CONVERT(VARCHAR(8), tblProcessHistory.crTime,108) AS 'Time',tblProcessHistory.pCount AS 'Records' ,tblProcessHistory.crUser from tblProcessHistory where  CONVERT(VARCHAR(8),crTime,112)='" & strLastProcessed & "'"
    '    Fk_FillGrid(sSQL, dgvInformation)
    '    SplitContainer2.SplitterDistance = SplitContainer2.Width / 4 * 3
    '    lblDatagridTitle.Text = "Processed Times : " & dgvInformation.RowCount
    'End Sub

    Private Sub SetReportViewLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetReportViewLv)
    End Sub

    Private Sub SetEmployeeMealHabitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetMealHabit)
    End Sub

    Private Sub SetDocumentTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmSetDocType)
    End Sub

    Private Sub lblLstDownTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'shortCut()
    End Sub

    Private Sub DtpTodateValueChanged()
        'If intLoad = 1 Then
        strAtnPrcDate = Format(dtpToDate.Value, "yyyyMMdd")
        'PRchartDay()
        CreateMonthSum()
        chartWeekK()
        DashboadCount()
        BirtdayList()
        ContractList()
        'setProgreBars()
        ViewSelectedGridStatus()
        'End If
    End Sub



    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        sSQL = "INSERT INTO tblLoginHistory (trForm,task,crUser,crDate,regID,lgStatus) VALUES ('" & Me.Name & "','Log off from system by : " & CurrentUser & "' ,'" & StrUserID & "',getdate (),'" & strUsersRegID & "',1)" : FK_EQ(sSQL, "S", "", False, False, True)
        Me.Close()
    End Sub

    Private Sub pnlHiddenButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        ' btnHidden_Click(sender, e)
    End Sub

    Private Sub btnSearchEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadForm(New frmAttendanceManager)
    End Sub

    Private Sub pnlTopData_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlTopData.SizeChanged
        p1.Location = New System.Drawing.Point(22, 0)
        p1.Width = ((Me.pnlTopData.Width - 132) / 5)
        p1.Height = (Me.pnlTopData.Height)

        p2.Location = New System.Drawing.Point(((Me.p1.Width) * 1) + 44, 0)
        p2.Width = p1.Width
        p2.Height = (Me.pnlTopData.Height)

        p3.Location = New System.Drawing.Point(((Me.p1.Width) * 2) + 66, 0)
        p3.Width = p1.Width
        p3.Height = (Me.pnlTopData.Height)

        P4.Location = New System.Drawing.Point(((Me.p1.Width) * 3) + 88, 0)
        P4.Width = ((Me.pnlTopData.Width - 132) / 5)
        P4.Height = (Me.pnlTopData.Height)

        p5.Location = New System.Drawing.Point(((Me.p1.Width) * 4) + 110, 0)
        p5.Width = p1.Width
        p5.Height = (Me.pnlTopData.Height)
    End Sub


    Private Sub pnlBreakSeperator_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBreakSeperator.MouseEnter, pnlAllButton.MouseEnter
        If pnlLeft.Width = 10 Then
            pnlLeft.Width = 62
            pnlLeftSeperator.Width = 52
        End If
    End Sub

    Private Sub pnlBreakSeperator_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBreakSeperator.MouseLeave, pnlAllButton.MouseLeave
        'If pnlLeft.Width = 62 Then
        '    pnlLeft.Width = 10
        '    pnlLeftSeperator.Width = 0
        'End If
    End Sub

    Private Sub pnlLeft_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlLeft.SizeChanged
        If bolLogged = False Then Exit Sub

        Dim intHeight As Integer = 0
        btn1DashBd.Location = New System.Drawing.Point(0, 0)
        btn1DashBd.Width = (Me.pnlAllButton.Width)
        btn1DashBd.Height = 44
        intHeight = intHeight + 46

        btn2EmpProfile.Location = New System.Drawing.Point(0, intHeight)
        btn2EmpProfile.Width = (Me.pnlAllButton.Width)
        btn2EmpProfile.Height = 44
        intHeight = intHeight + 46

        btn3HRM.Location = New System.Drawing.Point(0, intHeight)
        btn3HRM.Width = (Me.pnlAllButton.Width)
        btn3HRM.Height = 44
        intHeight = intHeight + 46

        btn4DailyAt.Location = New System.Drawing.Point(0, intHeight)
        btn4DailyAt.Width = (Me.pnlAllButton.Width)
        btn4DailyAt.Height = 44
        intHeight = intHeight + 46

        'btn5OT.Location = New System.Drawing.Point(0, intHeight)
        'btn5OT.Width = (Me.pnlMainButton.Width)
        'btn5OT.Height = 44
        'intHeight = intHeight + 46

        BTN6Leav.Location = New System.Drawing.Point(0, intHeight)
        BTN6Leav.Width = (Me.pnlAllButton.Width)
        BTN6Leav.Height = 44
        intHeight = intHeight + 46

        'btn7Shift.Location = New System.Drawing.Point(0, intHeight)
        'btn7Shift.Width = (Me.pnlMainButton.Width)
        'btn7Shift.Height = 44
        'intHeight = intHeight + 46

        btn8Calender.Location = New System.Drawing.Point(0, intHeight)
        btn8Calender.Width = (Me.pnlAllButton.Width)
        btn8Calender.Height = 44
        intHeight = intHeight + 46

        btn9Comp.Location = New System.Drawing.Point(0, intHeight)
        btn9Comp.Width = (Me.pnlAllButton.Width)
        btn9Comp.Height = 44
        intHeight = intHeight + 46

        btn10Payrol.Location = New System.Drawing.Point(0, intHeight)
        btn10Payrol.Width = (Me.pnlAllButton.Width)
        btn10Payrol.Height = 44
        intHeight = intHeight + 46

        btn11Report.Location = New System.Drawing.Point(0, intHeight)
        btn11Report.Width = (Me.pnlAllButton.Width)
        btn11Report.Height = 44
        intHeight = intHeight + 46

        btn12Setting.Location = New System.Drawing.Point(0, intHeight)
        btn12Setting.Width = (Me.pnlAllButton.Width)
        btn12Setting.Height = 44
        intHeight = intHeight + 46

        btn13AnalyisData.Location = New System.Drawing.Point(0, intHeight)
        btn13AnalyisData.Width = (Me.pnlAllButton.Width)
        btn13AnalyisData.Height = 44
        intHeight = intHeight + 46
    End Sub

    Private Sub labelAbsentClick()
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tblViewTK.shiftID AND tblViewTK.atDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetDept.shCode," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        If dgvWeeklySummary.RowCount <= 0 Then Exit Sub
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Absent Employees : " & dgvWeeklySummary.RowCount
    End Sub

    Private Sub lbl1Ab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl1Ab.Click
        strGridStatus = "Absent"
        dtGlobalDate = dtpToDate.Value
        LoadForm(New frmAttendanceDashBoard1)
        moreLabelColor()
        lbl1Ab.ForeColor = clrFocused
    End Sub

    Private Sub moreLabelColor()
        lbl1Ab.ForeColor = Color.LightSeaGreen
        lbl2Pr.ForeColor = Color.LightSeaGreen
        lbl3Late.ForeColor = Color.LightSeaGreen
        lbl4Leave.ForeColor = Color.LightSeaGreen
        lbl5nP.ForeColor = Color.LightSeaGreen
    End Sub

    Private Sub btn4DailyAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view daily attendance dashboard") = False Then btn4DailyAt.Enabled = False : Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmAttendanceManager
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lbl2Pr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl2Pr.Click
        strGridStatus = "Present"
        dtGlobalDate = dtpToDate.Value
        LoadForm(New frmAttendanceDashBoard1)
        moreLabelColor()
        lbl2Pr.ForeColor = clrFocused
    End Sub

    Private Sub lbl3Late_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl3Late.Click
        strGridStatus = "Late"
        dtGlobalDate = dtpToDate.Value
        LoadForm(New frmAttendanceDashBoard1)
        moreLabelColor()
        lbl3Late.ForeColor = clrFocused
    End Sub

    Private Sub lbl4Leave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl4Leave.Click
        strGridStatus = "Leave"
        dtGlobalDate = dtpToDate.Value
        LoadForm(New frmAttendanceDashBoard1)
        moreLabelColor()
        lbl4Leave.ForeColor = clrFocused
    End Sub

    Private Sub btn13AnalyisData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view attendance analysis screen") = False Then btn13AnalyisData.Enabled = False : Exit Sub

    End Sub

    Private Sub DashboardButtonClick()
        'If UP("Main Screen", "Allow to view dashboard") = False Then btn1DashBd.Enabled = False : Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Me.pnlAllDynamic.Controls.Add(tbMain)
        'LoadDashboadScreen
        strClicked = "Dashboard"
        ButtonClicked()
        dtpToDate.Value = fk_RetDate("select atnPrcDate FROM tblCompany")
        'chartWeekK()
        'DtpTodateValueChanged()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btn1DashBd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btn2EmpProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        tbMain.SelectedIndex = 1
        tbMain_SelectedIndexChanged(sender, e)

        ' ''If UP("Main Screen", "Allow to view employee profile") = False Then btn2EmpProfile.Enabled = False : Exit Sub
        ''Me.pnlAllDynamic.Controls.Clear()
        ''Dim frmReg As New frmEmployeeInfo
        ''frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        ' ''frmReg.WindowState = FormWindowState.Maximized

        ' ''frmReg.TopLevel = False
        ' ''Me.Location = New Point(0, 0)
        ' ''Me.pnlAllDynamic.Controls.Add(frmReg)

        ''frmReg.ShowDialog()
        strClicked = "EmployeeProfile"
        ButtonClicked()
    End Sub

    Private Sub btn12Setting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view user creating screen") = False Then btn12Setting.Enabled = False : Exit Sub
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmSetUsers
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "Settings"
        ButtonClicked()
    End Sub

    Private Sub btn9Comp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view all company setup screens") = False Then btn9Comp.Enabled = False : Exit Sub

    End Sub

    Private Sub ButtonClicked()

        Select Case strClicked

            Case "Dashboard"
                Me.btn1DashBd.BackgroundImage = My.Resources.notcurved46kk
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "EmployeeProfile"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = My.Resources.notcurved46kk
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                ''Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "HRM"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = My.Resources.notcurved46kk
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "DailyAttendance"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = My.Resources.notcurved46kk
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                ' Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "OverTime"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = My.Resources.notcurved46kk
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "Leave"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = My.Resources.notcurved46kk
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "Shift"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = My.Resources.notcurved46kk
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "Calender"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = My.Resources.notcurved46kk
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "Company"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = My.Resources.notcurved46kk
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "Payroll"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = My.Resources.notcurved46kk
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing
'
            Case "Report"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = My.Resources.notcurved46kk
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "Settings"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = My.Resources.notcurved46kk
                Me.btn13AnalyisData.BackgroundImage = Nothing

            Case "AnalysisData"
                Me.btn1DashBd.BackgroundImage = Nothing
                Me.btn2EmpProfile.BackgroundImage = Nothing
                Me.btn3HRM.BackgroundImage = Nothing
                Me.btn4DailyAt.BackgroundImage = Nothing
                'Me.btn5OT.BackgroundImage = Nothing
                Me.BTN6Leav.BackgroundImage = Nothing
                'Me.btn7Shift.BackgroundImage = Nothing
                Me.btn8Calender.BackgroundImage = Nothing
                Me.btn9Comp.BackgroundImage = Nothing
                Me.btn10Payrol.BackgroundImage = Nothing
                Me.btn11Report.BackgroundImage = Nothing
                Me.btn12Setting.BackgroundImage = Nothing
                Me.btn13AnalyisData.BackgroundImage = My.Resources.notcurved46kk
        End Select

    End Sub

    Private Sub btn11Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view report generating screen") = False Then btn11Report.Enabled = False : Exit Sub

    End Sub

    Private Sub btn8Calender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view administration screens") = False Then btn8Calender.Enabled = False : Exit Sub

    End Sub

    Private Sub btn5OT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view over time authorization screen") = False Then btn5OT.Enabled = False : Exit Sub

        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmOTAuthorize
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)
        frmReg.Show()

        strClicked = "OverTime"
        ButtonClicked()
    End Sub

    Public Sub restrictMenuItem(ByVal btnButton As Button, ByVal sLocation As String, ByVal sEvent As String)
        'Code 001
        Dim sValue As Double = 0
        Dim CN As New SqlConnection(sqlConString)
        Try
            CN.Open()
            Dim sSQL As String = "Select Val from tblUserPermissionA where Loc='" & sLocation & "' and Evnt='" & sEvent & "'"
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            If RD.HasRows = True Then
                While RD.Read
                    sValue = RD.Item(0)
                End While
            End If
            If sValue <= UserVal Then
                btnButton.Enabled = True
            Else
                btnButton.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BTN6Leav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view leave apply screen") = False Then BTN6Leav.Enabled = False : Exit Sub


    End Sub

    Private Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Dim dr As DialogResult = MessageBox.Show("Do you really want to log out from system ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If dr = Windows.Forms.DialogResult.No Then Exit Sub

        UserVal = 0
        If UserVal = 0 Then pnlAllButton.Enabled = False Else pnlAllButton.Enabled = True
        Me.pnlDynamic.Enabled = False

        lblState.Text = "Log out"
        tsCurrentUser.Text = " None "
        'Me.IsMdiContainer = False
        Me.btnLogin.Enabled = True
        Me.btnLogout.Enabled = False
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        LoginSteps()
    End Sub

    Private Sub btn3HRM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3HRM.Click
        'If UP("Main Screen", "Allow to view data download screen") = False Then btn3HRM.Enabled = False : Exit Sub
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmDownSelector
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "HRM"
        ButtonClicked()
    End Sub

    Private Sub btn7Shift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view roster editing screen") = False Then btn7Shift.Enabled = False : Exit Sub
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmNewRoster
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "Shift"
        ButtonClicked()
    End Sub

    Private Sub lblAbsent_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPresent.MouseHover, lblLeave.MouseHover, lblLate.MouseHover, lblNopay.MouseHover, lblAbsent.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lblAbsent_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPresent.MouseLeave, lblLeave.MouseLeave, lblLate.MouseLeave, lblNopay.MouseLeave, lblAbsent.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lbl1Ab_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl4Leave.MouseHover, lbl3Late.MouseHover, lbl2Pr.MouseHover, lbl1Ab.MouseHover, lbl5nP.MouseHover
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub lbl1Ab_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl4Leave.MouseLeave, lbl3Late.MouseLeave, lbl2Pr.MouseLeave, lbl1Ab.MouseLeave, lbl5nP.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblAbsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAbsent.Click
        strGridStatus = "Absent"
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tblViewTK.shiftID AND tblViewTK.atDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetDept.shCode," & sqlTag1 & " "
        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        If dgvWeeklySummary.RowCount <= 0 Then Exit Sub
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Absent Employees : " & dgvWeeklySummary.RowCount
        chartWeekK()
        ColorChangeLabelAll()
        lblAbsent.ForeColor = clrFocused
    End Sub

    Private Sub lblPresent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPresent.Click
        strGridStatus = "Present"
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tblViewTK.shiftID AND tblViewTK.atDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND p=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Present Employees : " & dgvWeeklySummary.RowCount
        chartWeekK()
        ColorChangeLabelAll()
        lblPresent.ForeColor = clrFocused
    End Sub

    Private Sub lblLate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLate.Click
        strGridStatus = "Late"
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tblViewTK.shiftID AND tblViewTK.atDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lt=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Late Employees : " & dgvWeeklySummary.RowCount
        chartWeekK()
        ColorChangeLabelAll()
        lblLate.ForeColor = clrFocused
    End Sub

    Private Sub lblLeave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLeave.Click
        strGridStatus = "Leave"
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tblViewTK.shiftID AND tblViewTK.atDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Leave Employees : " & dgvWeeklySummary.RowCount
        chartWeekK()
        ColorChangeLabelAll()
        lblLeave.ForeColor = clrFocused
    End Sub

    Private Sub lblBirthday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNopay.Click
        strGridStatus = "Nopay"
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblViewTK,tblEmployee,tblSetDept,tblSetEmpCategory,tbldesig,tblSetShifth WHERE tblEmployee.regID=tblViewTK.regID AND tblSetDept.deptID=tblEmployee.DeptID AND tblSetEmpCategory.catID=tblEmployee.catID AND tblEmployee.DesigID=tbldesig.desgID AND tblSetShifth.shiftID=tblViewTK.shiftID AND tblViewTK.atDate = '" & Format(dtpToDate.Value, "yyyyMMdd") & "' AND lv=0 AND isOf=0 AND a=1 and tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "')  AND tblemployee.brID IN ('" & StrUserLvBranch & "') ORDER BY tblSetDept.shCode," & sqlTag1 & " "

        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Nopay Employees : " & dgvWeeklySummary.RowCount
        chartWeekK()
        ColorChangeLabelAll()
        lblNopay.ForeColor = clrFocused
    End Sub

    Private Sub cmdScrollToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrollToggle.Click
        If pnlLeft.Width = 177 Then
            pnlLeft.Width = 62
            pnlLeftSeperator.Width = 52
        ElseIf pnlLeft.Width = 62 Then
            pnlLeft.Width = 10
            pnlLeftSeperator.Width = 0
        ElseIf pnlLeft.Width = 10 Then
            pnlLeft.Width = 177
            pnlLeftSeperator.Width = 167
        End If

        Select Case strClicked
            Case "Shift"
                btn7Shift_Click(sender, e)

            Case "Leave"
                BTN6Leav_Click(sender, e)

            Case "OverTime"
                btn5OT_Click(sender, e)

            Case "Calender"
                btn8Calender_Click(sender, e)

            Case "Report"
                btn11Report_Click(sender, e)

            Case "Company"
                btn9Comp_Click(sender, e)

            Case "EmployeeProfile"
                btn2EmpProfile_Click(sender, e)

            Case "Dashboard"
                btn1DashBd_Click(sender, e)

            Case "AnalysisData"
                btn13AnalyisData_Click(sender, e)

            Case "DailyAttendance"
                btn4DailyAt_Click(sender, e)

            Case "HRM"
                btn3HRM_Click(sender, e)
        End Select
    End Sub

    Private Sub btnMinum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinum.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub lbl5nP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl5nP.Click
        strGridStatus = "Nopay"
        'dtGlobalDate = dtpToDate.Value
        'LoadForm(New frmAttendanceDashBoard1)
    End Sub

    Private Sub ColorChangeLabelAll()
        lblAbsent.ForeColor = Color.LightSeaGreen
        lblPresent.ForeColor = Color.LightSeaGreen
        lblLate.ForeColor = Color.LightSeaGreen
        lblLeave.ForeColor = Color.LightSeaGreen
        lblNopay.ForeColor = Color.LightSeaGreen
        lblChartTitle.ForeColor = Color.LightSeaGreen
    End Sub

    Private Sub Fk_FillDataSet(ByVal strSQLQuery As String)
        Dim CN As New SqlConnection(sqlConString)
        Dim sBol As Boolean = False
        Try
            sTablek.Clear()
            CN.Open()
            Dim ADP As New SqlDataAdapter
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTablek, "tblDashBoard")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Private Sub dgvWeeklySummary_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWeeklySummary.CellClick
        If dgvWeeklySummary.RowCount > 0 Then
            If strGridStatus = "Contract" Or strGridStatus = "Birthday" Then
                Exit Sub
            End If

            sSQL = "SELECT RegID from tblEmployee WHERE " & sqlTag1 & "='" & dgvWeeklySummary.CurrentRow.Cells(0).Value & "'"
            StrEmployeeID = fk_RetString(sSQL)
            strEmpName = dgvWeeklySummary.CurrentRow.Cells(1).Value
            chartIndividual()
        End If
    End Sub

    Private Sub lblContractCount_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblContractCount.MouseClick
        strGridStatus = "Contract"
        Dim strMonth As String = dtWorkingDate.Month
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblEmployee WHERE DATEPART(mm, contractEnd) = " & strMonth & " and empstatus<>9 AND DATEPART(yy, contractEnd) = " & intCurrentYear & " and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') "

        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Contract Ending This Month : " & dgvWeeklySummary.RowCount
    End Sub

    Private Sub lblBirtdayCount_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblBirtdayCount.MouseClick
        strGridStatus = "Birthday"
        Dim strMonth As String = dtWorkingDate.Month
        Dim strDay As String = dtWorkingDate.Day
        sSQL = "select " & sqlTagName & ",tblEmployee.dispName AS 'Employee Name' from tblEmployee where  DATEPART(mm, DofB) = " & strMonth & " and DATEPART(dd, DofB) =" & strDay & " and empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') "

        Fk_FillGrid(sSQL, dgvWeeklySummary)
        dgvWeeklySummary.Columns(0).Width = 68
        For X As Integer = 1 To dgvWeeklySummary.Columns.Count - 1
            dgvWeeklySummary.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Next
        lblCountDepartment.Text = "Born on Toady : " & dgvWeeklySummary.RowCount
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmRemovePunchTime
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnBulkRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmRemovePunchTime
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        'strClicked = "DailyAttendance"
        'ButtonClicked()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSpecialDSB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmSpecialDashboard
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        'strClicked = "DailyAttendance"
        'ButtonClicked()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btn10Payrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If UP("Main Screen", "Allow to view payroll system link") = False Then btn10Payrol.Enabled = False : Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmPayslipprocessold
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        'strClicked = "DailyAttendance"
        'ButtonClicked()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tbMain_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbMain.SelectedIndexChanged
        Dim iTab As Integer
        iTab = tbMain.SelectedIndex
        If iTab = 0 And intSelectedTab = 0 Then
            intSelectedTab = 2
            LoadDashboadScreen()
        ElseIf iTab = 0 And intSelectedTab > 1 Then
            DashboardButtonClick()

        ElseIf iTab = 1 Then
            LoadEmployeeScreen()
        End If
    End Sub

    'Employee form********************************************************************************************************************
    Private Sub LoadEmployeeScreen()
        Me.Cursor = Cursors.WaitCursor
        Me.pnlAllDynamic.Controls.Clear()
        Me.pnlAllDynamic.Controls.Add(tbMain)

        If UP("Employee Profile", "View employee profile") = False Then Exit Sub
        picEDesig.Visible = True
        ControlHandlers(Me)

        Dim crtl As Control
        For Each crtl In Me.pnlMyData.Controls
            If TypeOf crtl Is TextBox Then
                crtl.Text = ""
            End If
        Next

        'CenterFormThemed(Me, Panel1, Label25)
        ''If intIsBOTAccept = 1 Then chkIsBOT.Visible = True Else chkIsBOT.Visible = False
        If intIsMonthlyOT = 1 Then txtOTforMonth.Visible = True : lblMonthOT.Visible = True

        'MODIFY SYSTEM TO DISPLAY DEPATMENT AS BRANCH AND SECTION AS DEPARTMENT
        If ISDispalyDepartmentASBranch = 1 Then
            lblBranch.Text = "Department"
            lblDepartment.Text = "Section"
        End If
        bolIsLoad = True
        StrDefAddID = "001"
        StrSvStatus = "S"
        intActive = 1
        'Load Default Shift 
        StrDefaultShiftID = fk_RetString("SELECT DSID FROM tblCompany WHERE CompID = '" & StrCompID & "'")

        '20181009 enabl multi langu name form [prasanna]
        If 1 = fk_RetString("SELECT  multiplelangName FROM tblcontrol ") Then
            pbAddMultiLungName.Visible = True
        Else
            pbAddMultiLungName.Visible = False
        End If


        'Delete shift enable check
        intisDeleteShift = fk_sqlDbl("select isDeleteShift from tblcompany where compID='" & StrCompID & "'")
        If intisDeleteShift = 1 Then
            chkShift.Visible = True
        End If
        'If strKEmProfileID = "" Then
        '    sSQL = "SELECT min(REGID) FROM tblEmployee WHERE empStatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        '    strKEmProfileID = fk_RetString(sSQL)
        'End If

        strShiftID = "909"

        rdbActive.Checked = True
        ViewEmployee()
        Me.Cursor = Cursors.Default
        'If strKEmProfileID <> "" Then
        If StrEmployeeID <> "" Then
            Dim crtlk As Control
            For Each crtlk In Me.GroupBox1.Controls
                If TypeOf crtlk Is TextBox Then crtl.Text = ""
            Next

            For Each crtl In Me.GroupBox4.Controls
                If TypeOf crtl Is TextBox Then crtl.Text = ""
            Next

            For Each crtl In Me.GroupBox4.Controls
                If TypeOf crtl Is TextBox Then crtl.Text = ""
            Next

            chkCancel.Checked = False

            ListCombo(cmbTItle, "SELECT * FROM tblSetTitle WHERE Status = 0 Order By titleID", "titleDesc")
            'Gender
            ListCombo(cmbGender, "SELECT * FROM tblGender WHERE Status = 0 Order By GenID", "GenDesc")
            'Civil Status
            ListCombo(cmbCivilSt, "SELECT * FROM tblCivilStatus WHERE Status =  0 Order By StID", "StDesc")
            'Designations
            ListCombo(cmbDesignation, "select * from tblDesig where status = 0 order by desgID", "desgDesc")
            'Designation 
            ListCombo(cmbBranch, "SELECT * FROM tblCBranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID", "BrName")
            'Department
            ListCombo(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "DeptName")
            'Category inof
            ListCombo(cmbEmpCategory, "select * From tblSEtEmpCategory WHERE Status = 0 ORder By CatID", "catDesc")
            'Employee Type
            ListCombo(cmbEmpType, "SELECT * FROM tblSetEmpType WHERE Status = 0 Order By TypeID", "tDesc")

            ListCombo(cmbShift, "SELECT * FROM tblSetshifth WHERE Status = 0 Order By shiftID", "shiftName")

            txtCrPeriod.Text = "0"

            'Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
            'intEnrolNo = iEms
            'txtEnrolNo.Text = intEnrolNo.ToString
            'StrEmployeeID = fk_CreateSerial(6, iEms)
            'txtRegNo.Text = StrEmployeeID

            picEmpProfil.Image = Nothing
            'frmMasterEmployee.lblID.Text = StrEmployeeID
            'StrDispName = ""
            Me.lblName.Text = StrDispName

            StrSvStatus = "S"
            dtpCFrom.Value = dtWorkingDate.Date
            dtpCTo.Value = dtWorkingDate.Date
            dtpCTo.MinDate = dtpCFrom.Value.Date

            'StrEmployeeID = strKEmProfileID
            pb_ShowEmployee(StrEmployeeID)
            cmdPrevious.Enabled = False
            Me.Cursor = Cursors.Default
            'strKEmProfileID = ""
            'ElseIf strKEmProfileID = "" Then
        ElseIf StrEmployeeID = "" Then

            strIsEpf = fk_RetString("select isEpf from tblcompany where compId='" & StrCompID & "'")
            RefreshButtonEmployee()
            ''Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
            ''intEnrolNo = iEms
            ' ''If strIsFormLoad = "Refresh" Then
            ''txtEnrolNo.Text = intEnrolNo.ToString
            ''StrEmployeeID = fk_CreateSerial(6, iEms)
            ''txtRegNo.Text = StrEmployeeID
            ' ''End If
        End If

        strClickedEmp = "cmdEmployee"
        ButtonClicked()
        'cmdEmployee_Click(sender, e)
        'The relevant tables for this form has created at the frmMasterEmployee form.

        'if strIsEpf = 0 then Register number 
        'if 1 then EpfNo.
        'If 2 then Enroll no.
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'StrEmployeeID = ""
        'BackColor = Color.RoyalBlue
        'TransparencyKey = Me.BackColor



        Dim AdvanHRIDDetails As Integer = fk_sqlDbl("select AdvanHRIDDetails from tblControl ")
        If AdvanHRIDDetails = 1 Then
            cmdShifts.Text = "         Additional HR"
        Else
            cmdShifts.Text = "         Roster"
        End If



        'pnlMostRLeft.Visible = False
        pnlEditHistory.Height = 0
        Me.Cursor = Cursors.Default
    End Sub



    Public Sub ViewEmployee()
        If rdbActive.Checked = True Then
            strWhereClause = " AND tblemployee.Empstatus<>9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        ElseIf rdbCancel.Checked = True Then
            strWhereClause = " AND tblemployee.Empstatus=9 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        ElseIf rdbAbroad.Checked = True Then
            strWhereClause = " AND tblemployee.Empstatus=8 and tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')"
        End If

        sSQL = "select tblEmployee.RegID,RIGHT('00000'+CAST(" & sqlTag1 & " AS VARCHAR(6)),6) as '" & sqlTag1.Split("."c)(1) & "' ,tblEmployee.DispName AS 'Employee Name',tblEmployee.NICNumber AS 'NIC Number',tblEmployee.callName AS 'Calling Name',tblSetDept.DeptName AS 'Department',tblDesig.desgDesc AS 'Designation',CONVERT(VARCHAR(11),tblEmployee.regDate,106) AS 'Joining Date',CONVERT(VARCHAR(11),tblEmployee.dOFb,106) AS 'Birth Date' FROM tblEmployee,tblDesig,tblSetDept WHERE tblEmployee.desigID=tblDesig.DesgID AND tblSetDept.deptID=tblEmployee.DeptID " & strWhereClause & " AND (tblEmployee.DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR tblEmployee.NICNumber like '%" & txtSearch.Text & "%' OR tblEmployee.firstName like '%" & txtSearch.Text & "%' OR tblEmployee.surName like '%" & txtSearch.Text & "%' OR tblEmployee.callName like '%" & txtSearch.Text & "%' OR tblDesig.DesgDesc like '%" & txtSearch.Text & "%') ORDER BY " & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvAllEmp)
        dgvAllEmp.Columns(0).Visible = False
        For X As Integer = 0 To dgvAllEmp.Columns.Count - 1
            dgvAllEmp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Next
        lblEmpCount.Text = "Employee List : " & dgvAllEmp.RowCount
        pnlMostRLeft.Width = 357
    End Sub

    Public Sub sv_Leaves(ByVal empcat As String)

        Dim dgvEmp As DataGridView
        dgvEmp = New DataGridView

        With dgvEmp

            .Columns.Clear()
            .Columns.Add("EmpIDs", "Employee ID")
            .Columns.Add("CatIDs", "Category ID")
            .Columns.Add("CompIDs", "CompID")

        End With
        'Load Information to the grid 
        Load_InformationtoGrid("SELECT RegID,CatID,CompID FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "' Order By RegID", dgvEmp, 3)

        'Load Leave Information to the Leave GRID for  each Employee
        'Generate the Leave GRID
        Dim dgvLv As DataGridView
        dgvLv = New DataGridView

        With dgvLv

            .Columns.Clear()
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("CompID", "CompID")
            .Columns.Add("cYear", "cYear")
            .Columns.Add("LeaveID", "LeaveID")
            .Columns.Add("NoLeave", "NoLeave")
            .Columns.Add("TakenLv", "TakenLv")
            .Columns.Add("Status", "Status")

        End With

        With dgvEmp
            For i As Integer = 0 To .RowCount - 2
                Load_InformationtoGridNoClr("select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "'," & intCurrentYear & ", " &
                                       " tblLeaveType.lvID,dbo.fk_RetNoLeave('" & .Item(1, i).Value & "',tblLeaveType.LvID) as NoLv,dbo.fk_EmpRetNoLeave(tblLeaveType.LvID,'" & .Item(0, i).Value & "',2012),0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLv, 7)

            Next
        End With
        'Insert all information to tblEmployee Leave File
        Dim sqlQRY As String

        With dgvLv
            'Update tblEm
            sqlQRY = "DELETE FROM tblEmpLeaveD WHERE EmpID = '" & StrEmployeeID & "'"
            For i As Integer = 0 To .RowCount - 2
                sqlQRY = sqlQRY & " INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES ('" & .Item(0, i).Value & "', " &
                " '" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, i).Value & "', " & CDbl(.Item(4, i).Value) & "," & CDbl(.Item(5, i).Value) & ",1)"
            Next
        End With

        FK_EQ(sqlQRY, "P", "", False, False, False)

    End Sub

    'The following procedure has been commented by Rajitha. Kasun gave me updated one.
    '' '' ''    Public Sub sv_Leaves(ByVal empcat As String)
    '' '' ''        Dim sqlQv As String = "select '" & StrEmployeeID & "','" & StrCompID & "'," & intCurrentYear & ",tblLeaveType.LvID,tblSetLeave.NoLeave,0,0 FROM tblSetLeave " & _
    '' '' ''" INNER JOIN tblLeaveType ON tblSetLeave.LeaveID = tblLeaveType.LvID WHERE tblSetLeave.catID = '" & empcat & "'"

    '' '' ''        'Create grid table structuer
    '' '' ''        With grd
    '' '' ''            .Columns.Clear()
    '' '' ''            .Columns.Add("empID", "employee id")        '0
    '' '' ''            .Columns.Add("compID", "company id")        '1
    '' '' ''            .Columns.Add("cYear", "Current Year")       '2
    '' '' ''            .Columns.Add("LvType", "Leave Type")        '3
    '' '' ''            .Columns.Add("NoLv", "No Leaves")           '4
    '' '' ''            .Columns.Add("BalLv", "Leave Balance")      '5
    '' '' ''            .Columns.Add("St", "Status")                '6
    '' '' ''        End With

    '' '' ''        Load_InformationtoGrid(sqlQv, grd, 7)

    '' '' ''        'Check Existing Leave Information in the tblEmpLeave
    '' '' ''        Dim bolExEmp As Boolean
    '' '' ''        If StrSvStatus = "E" Then
    '' '' ''            bolExEmp = fk_CheckEx("SELECT * FROM tblEmpLeaveD WHERE EmpID = '" & StrEmployeeID & "'")

    '' '' ''        Else
    '' '' ''            bolExEmp = False
    '' '' ''        End If

    '' '' ''        Dim bolExL As Boolean = False
    '' '' ''        Dim iRw As Integer
    '' '' ''        If bolExEmp = True Then 'if employee already assig the records need to manage change
    '' '' ''            With grd
    '' '' ''                For iRw = 0 To .RowCount - 1
    '' '' ''                    bolExL = fk_CheckEx("SELECT * FROM tblEmpLeaveD WHERE empID = '" & StrEmployeeID & "' AND LeaveID = '" & .Item(3, iRw).Value & "' AND CompID = '" & StrCompID & "' AND cYear = " & intCurrentYear & "")
    '' '' ''                    If bolExL = True Then
    '' '' ''                        .Item(6, iRw).Value = 1
    '' '' ''                    Else
    '' '' ''                        .Item(6, iRw).Value = 0
    '' '' ''                    End If
    '' '' ''                Next
    '' '' ''            End With
    '' '' ''        End If


    '' '' ''        Dim cnSv As New SqlConnection(sqlConString)
    '' '' ''        cnSv.Open()
    '' '' ''        Dim sqlSv As String = ""
    '' '' ''        Dim cmSv As New SqlCommand
    '' '' ''        cmSv = cnSv.CreateCommand
    '' '' ''        Dim trSv As SqlTransaction = cnSv.BeginTransaction
    '' '' ''        cmSv.Transaction = trSv
    '' '' ''        Dim StrT As String
    '' '' ''        Try
    '' '' ''            With grd
    '' '' ''                For iRw = 0 To .RowCount - 1
    '' '' ''                    StrT = .Item(6, iRw).Value
    '' '' ''                    Select Case StrT
    '' '' ''                        Case "1" 'if information are exists
    '' '' ''                            'sqlSv = "UPDATE tblEmpLeaveD SET NoLeaves = " & CDbl(.Item(4, iRw).Value) & " WHERE EmpID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "' " & _
    '' '' ''                            '" AND cYear = " & intCurrentYear & " AND LeaveID = '" & .Item(3, iRw).Value & "'"
    '' '' ''                            'cmSv.CommandText = sqlSv
    '' '' ''                            'cmSv.ExecuteNonQuery()

    '' '' ''                        Case "0"
    '' '' ''                            sqlSv = "INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES " & _
    '' '' ''                            " ('" & StrEmployeeID & "','" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, iRw).Value & "'," & CDbl(.Item(4, iRw).Value) & ",0,0)"
    '' '' ''                            cmSv.CommandText = sqlSv
    '' '' ''                            cmSv.ExecuteNonQuery()
    '' '' ''                    End Select

    '' '' ''                Next

    '' '' ''                trSv.Commit()

    '' '' ''            End With
    '' '' ''        Catch ex As Exception
    '' '' ''            MsgBox(ex.Message)
    '' '' ''            trSv.Rollback()
    '' '' ''        Finally
    '' '' ''            cnSv.Close()
    '' '' ''        End Try
    '' '' ''    End Sub
    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshButtonEmployee()
    End Sub

    Public Sub RefreshButtonEmployee()

        Dim crtl As Control
        For Each crtl In Me.pnlMyData.Controls
            If TypeOf crtl Is TextBox Then
                crtl.Text = ""
            End If
        Next

        Dim crtlk As Control
        For Each crtlk In Me.pnlMyData.Controls
            If TypeOf crtlk Is ComboBox Then
                crtlk.Enabled = True
                crtlk.ForeColor = Color.Black
            End If
        Next

        'For Each crtl In Me.GroupBox4.Controls
        '    If TypeOf crtl Is TextBox Then crtl.Text = ""
        'Next

        chkCancel.Checked = False
        chkShift.Checked = False
        chkIsBOT.CheckState = CheckState.Unchecked
        ListCombo(cmbTItle, "SELECT * FROM tblSetTitle WHERE Status = 0 Order By titleID", "titleDesc")
        'Gender
        ListCombo(cmbGender, "SELECT * FROM tblGender WHERE Status = 0 Order By GenID", "GenDesc")
        'Civil Status
        ListCombo(cmbCivilSt, "SELECT * FROM tblCivilStatus WHERE Status =  0 Order By StID", "StDesc")
        'Designations
        ListCombo(cmbDesignation, "select * from tblDesig where status = 0 order by desgID", "desgDesc")
        'Designation 
        ListCombo(cmbBranch, "SELECT * FROM tblCBranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID", "BrName")
        'Department
        ListCombo(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "DeptName")
        'Category inof
        ListCombo(cmbEmpCategory, "select * From tblSEtEmpCategory WHERE Status = 0 ORder By CatID", "catDesc")
        'Employee Type
        ListCombo(cmbEmpType, "SELECT * FROM tblSetEmpType WHERE Status = 0 Order By TypeID", "tDesc")

        ListCombo(cmbShift, "SELECT * FROM tblSetshifth WHERE Status = 0 Order By shiftID", "shiftName")

        txtCrPeriod.Text = "0"

        Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        intEnrolNo = iEms

        'txtEnrolNo.Text = intEnrolNo.ToString
        StrEmployeeID = fk_CreateSerial(6, iEms)
        txtRegNo.Text = StrEmployeeID

        picEmpProfil.Image = My.Resources.User_Anonymous_Disabled
        StrDispName = ""

        StrSvStatus = "S"
        dtpCFrom.Value = dtWorkingDate.Date
        dtpCTo.Value = dtWorkingDate.Date
        dtpCTo.MinDate = dtpCFrom.Value.Date
        bolIsLoad = False

        lblName.Text = "Employee Name"
        lblBranchtop.Text = "Branch : "
        lblDesignation.Text = "Designation : "
        lblEmpNumb.Text = "Emp No : "
        lblAddres.Text = "Address : "
        lblBirth.Text = "Birthday : " & Format(dtpDofB.Value, "dd-MM-yyyy")
        lbldepeartment.Text = "Department : "
        lblEmail.Text = "Email : "
        txtEnrolNo.Text = fk_sqlDbl("SELECT max(enrolNo)+1 FROM tblEmployee  WHERE EmpStatus<>9")
        dtpRegDate.Value = Now.Date
        pnlEditHistory.Height = 0
    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        'crtl.FlatAppearance.BorderColor = Me.pnlAllData.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        'crtl.FlatAppearance.BorderColor = Me.pnlAllData.BackColor

    End Sub

    Private Sub cmbTItle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTItle.SelectedIndexChanged
        StrTitleID = fk_RetString("SELECT titleID FROM tblSetTitle WHERE titleDesc = '" & cmbTItle.Text & "'")
        get_FullName(cmbTItle.Text, txtFirstName.Text, txtLName.Text)
    End Sub

    Private Sub cmbGender_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGender.SelectedIndexChanged
        StrGenderID = fk_RetString("SELECT GenID FROM tblGender WHERE GenDesc = '" & cmbGender.Text & "'")
        If StrGenderID = "001" Then
            cmbTItle.SelectedIndex = 1
        Else
            cmbTItle.SelectedIndex = 2
        End If
    End Sub

    Private Sub cmbCivilSt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCivilSt.SelectedIndexChanged
        StrCivilStID = fk_RetString("SELECT StID FROM tblCivilStatus WHERE stDesc = '" & cmbCivilSt.Text & "'")
    End Sub

    Private Sub cmbDesignation_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDesignation.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Designation directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbDesignation.Text = "" : picEDesig_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignation.SelectedIndexChanged
        StrDesgID = fk_RetString("SELECT DesgID FROM tblDesig WHERE DesgDesc = '" & cmbDesignation.Text & "'")
    End Sub

    Private Sub cmbBranch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBranch.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Branch directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbBranch.Text = "" : picEBr_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbBranch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBranch.SelectedIndexChanged
        StrBranchID = fk_RetString("SELECT BrID FROM tblCBranchs WHERE BrName = '" & cmbBranch.Text & "' AND CompID = '" & StrCompID & "'")
    End Sub

    Private Sub cmbDept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Department directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbDept.Text = "" : PicEDept_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        StrDeptID = fk_RetString("SELECT DeptID FROM tblsetDept WHERE DeptName = '" & cmbDept.Text & "'")
    End Sub

    Private Sub cmbEmpCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpCategory.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Category directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbEmpCategory.Text = "" : picECat_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbEmpCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpCategory.SelectedIndexChanged
        StrCategoryID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbEmpCategory.Text & "'")
    End Sub

    Private Sub cmbEmpType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEmpType.Click
        'If StrSvStatus = "E" And bolIsLoad = False Then
        '    MessageBox.Show("You can't edit Employee Type directly here, Please use the edit screen", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmbEmpType.Text = "" : picEType_Click(sender, e) : Exit Sub
        'End If
    End Sub

    Private Sub cmbEmpType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpType.SelectedIndexChanged
        StrEmpTypeID = fk_RetString("SELECT TypeID FROM tblSetEmpType WHERE tDesc = '" & cmbEmpType.Text & "'")
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Employee Profile", "Add new employee profile") = False Then Exit Sub

        'chk if enroll no has not changed by the user the message says to confirm to save auto gen no. From Duminda.
        txtFirstName_Leave(sender, e)
        txtSName_Leave(sender, e)
        'txtNICNumber_Leave(sender, e)
        If chkCancel.Checked = True Then
            intActive = 9
        Else
            intActive = 1
        End If

        'Before save the employee information, requrired to validate 
        If txtRegNo.Text = "" Then
            MsgBox("Required Register No", MsgBoxStyle.Information)
            txtRegNo.Focus()
            Exit Sub
        End If

        If txtEnrolNo.Text = "" Then
            MsgBox("Required Terminal No", MsgBoxStyle.Information)
            txtRegNo.Focus()
            Exit Sub
        End If

        If cmbTItle.Text = "NONE" Then
            MsgBox("Please Select the Title", MsgBoxStyle.Information)
            cmbTItle.Focus()
            Exit Sub
        End If

        If txtLName.Text.Trim = "" Then
            MsgBox("Please Enter the Surname", MsgBoxStyle.Information)
            txtLName.Focus()
            Exit Sub
        End If

        'If txtFirstName.Text.Trim = "" Then
        '    MsgBox("Please Enter the First Names.", MsgBoxStyle.Information)
        '    txtFirstName.Focus()
        '    Exit Sub
        'End If

        If txtNICNumber.Text = "" Then
            MsgBox("Required NIC Number", MsgBoxStyle.Information)
            txtNICNumber.Focus()
            Exit Sub
        End If

        If cmbGender.Text = "NONE" Then
            MsgBox("Select the Gender", MsgBoxStyle.Information)
            cmbGender.Focus()
            Exit Sub
        End If

        If cmbCivilSt.Text = "NONE" Then
            MsgBox("Select the Civil Status", MsgBoxStyle.Information)
            cmbCivilSt.Focus()
            Exit Sub
        End If

        If cmbBranch.Text = "NONE" Then
            MsgBox("Select the Branch", MsgBoxStyle.Information)
            cmbBranch.Focus()
            Exit Sub
        End If

        'if tblCompany table isEpf field has 1 then all reports based on epfno. so make it required field
        'based on frmCompany form settings.
        If strIsEpf = 1 Then
            If txtEpfNo.Text.Trim = "" Then
                MsgBox("Please Enter the EPF No.")
                txtEpfNo.Focus()
                Exit Sub
            End If
        End If

        If cmbDesignation.Text = "NONE" Then
            MsgBox("Select the Designation", MsgBoxStyle.Information)
            cmbDesignation.Focus()
            Exit Sub
        End If

        If cmbDept.Text = "NONE" Then
            MsgBox("Select the Department.", MsgBoxStyle.Information)
            cmbDept.Focus()
            Exit Sub
        End If

        If cmbEmpCategory.Text = "NONE" Then
            MsgBox("Select the Employee Category", MsgBoxStyle.Information)
            cmbEmpCategory.Focus()
            Exit Sub
        End If

        If cmbEmpType.Text = "NONE" Then
            MsgBox("Select the Emloyee Type", MsgBoxStyle.Information)
            cmbEmpType.Focus()
            Exit Sub
        End If

        If cmbShift.Text = "NONE" Then
            MsgBox("Select the shift", MsgBoxStyle.Information)
            cmbShift.Focus()
            Exit Sub
        End If


        If cmbDesignation.Text = "" Then
            MsgBox("Select the Designation", MsgBoxStyle.Information)
            cmbDesignation.Focus()
            Exit Sub
        End If

        If cmbDept.Text = "" Then
            MsgBox("Select the Department.", MsgBoxStyle.Information)
            cmbDept.Focus()
            Exit Sub
        End If

        If cmbEmpCategory.Text = "" Then
            MsgBox("Select the Employee Category", MsgBoxStyle.Information)
            cmbEmpCategory.Focus()
            Exit Sub
        End If

        If cmbEmpType.Text = "" Then
            MsgBox("Select the Emloyee Type", MsgBoxStyle.Information)
            cmbEmpType.Focus()
            Exit Sub
        End If

        If cmbShift.Text = "" Then
            MsgBox("Select the shift", MsgBoxStyle.Information)
            cmbShift.Focus()
            Exit Sub
        End If

        If cmbBranch.Text = "" Then
            MsgBox("Select the branch", MsgBoxStyle.Information)
            cmbBranch.Focus()
            Exit Sub
        End If

        If txtEmail.Text.Trim <> "" Then
            If False = fk_EAdChk(txtEmail.Text) Then
                MsgBox("Please Enter a Valid E-Mail Address.")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        StrGenderID = fk_RetString("SELECT GenID FROM tblGender WHERE GenDesc = '" & cmbGender.Text & "'")
        StrCivilStID = fk_RetString("SELECT StID FROM tblCivilStatus WHERE stDesc = '" & cmbCivilSt.Text & "'")
        StrBranchID = fk_RetString("SELECT BrID FROM tblCBranchs WHERE BrName = '" & cmbBranch.Text & "' AND CompID = '" & StrCompID & "'")
        StrDeptID = fk_RetString("SELECT DeptID FROM tblsetDept WHERE DeptName = '" & cmbDept.Text & "'")
        StrCategoryID = fk_RetString("SELECT CatID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbEmpCategory.Text & "'")
        StrEmpTypeID = fk_RetString("SELECT TypeID FROM tblSetEmpType WHERE tDesc = '" & cmbEmpType.Text & "'")

        If txtEmpNo.Text = "" Then txtEmpNo.Text = "0"
        If txtEmpNo.Text = "" Then

            MsgBox("Required Feild Employee No", MsgBoxStyle.Information)
            txtEmpNo.Focus()
            Exit Sub
        End If

        Dim bolCalEx As Boolean = False

        '===========Following added by Rajitha.
        If StrSvStatus = "S" Then

            txtRegNo.Text = fk_CreateSerial(6, (fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1))

            'Ask from user to save auto gen enroll number?
            If intEnrolNo = txtEnrolNo.Text.Trim Then
                If MessageBox.Show("Enroll Number For " & cmbTItle.Text & " " & txtLName.Text.Trim & " has set to " & intEnrolNo & ". Are you sure to save this?", "Confirm...", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.Cancel Then
                    txtEnrolNo.Focus()
                    Exit Sub
                End If
            End If

            'Check Existing Enrol Number
            Dim bolExFinger As Boolean = fk_CheckEx("SELECT EnrolNo FROM tblEmployee WHERE EnrolNo = " & CInt(txtEnrolNo.Text) & "")
            If bolExFinger = True Then
                MsgBox("This Enroll Number has been Set for Another Employee.Please Select Different Enroll Number.", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Check NIC duplication.
            Dim bolExNIC As Boolean = fk_CheckEx("SELECT regid FROM tblEMployee WHERE NicNumber = '" & txtNICNumber.Text & "' AND compID = '" & StrCompID & "' AND tblEMployee.empStatus<>9")
            If bolExNIC = True Then
                MsgBox("The NIC Number has already been saved and can not be Duplicated.", MsgBoxStyle.Critical)
                txtNICNumber.Focus()
                Exit Sub
            End If
        End If


        If StrSvStatus = "E" Then
            'Check Edited NIC/Enroll numbers duplication...

            If intExsEnNo <> txtEnrolNo.Text.Trim Then
                If True = fk_CheckEx("select * from tblEmployee where compID='" & StrCompID & "' and enrolno = " & txtEnrolNo.Text.Trim & " and regid <> '" & txtRegNo.Text & "'") Then
                    MsgBox("This Enroll Number has been Set for Another Employee.Please Select Different Enroll Number.", MsgBoxStyle.Information)
                    txtEnrolNo.Focus()
                    Exit Sub
                End If
            End If
            'strExsNic
            If strExsNic <> txtNICNumber.Text.Trim Then
                If True = fk_CheckEx("select * from tblEmployee where compID='" & StrCompID & "' and NicNumber = '" & txtNICNumber.Text.Trim & "' and regid <> '" & txtRegNo.Text & "' AND empstatus<>9") Then
                    MsgBox("This NIC Number has been set for another active employee.Please eelect different NIC Number.", MsgBoxStyle.Information)
                    txtNICNumber.Focus()
                    Exit Sub
                End If
            End If
        End If

        '=================

        'If StrSvStatus = "S" Then

        '    'Dim iEms As Integer = fk_sqlDbl("SELECT NoEmps FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        '    'StrEmployeeID = fk_CreateSerial(6, iEms)
        '    'txtRegNo.Text = StrEmployeeID



        '    Dim bolExEnrl As Boolean = fk_CheckEx("SELECT * FROM tblEmployee WHERE EnrolNo = '" & txtEnrolNo.Text & "'")
        '    If bolExEnrl = True Then
        '        MsgBox("Enroll Number Already Exists", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If
        'Else
        '    'Check for the attendance calendar existance
        '    bolCalEx = fk_CheckEx("SELECT * FROM tblEmpRegister WHERE cyear = " & intCurrentYear & " AND CompID = '" & StrCompID & "' AND empID = '" & StrEmployeeID & "'")

        'End If
        'Check Enrol Number 


        'Save Coding
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "INSERT INTO tblEmployee (RegID,RegDate,TitleID,SurName,FirstName,dispName,NICNumber,DofB, " &
                    " GenderID,CivilStID,EmpNo,EpfNo,CompID,DesigID,BrID," &
                    " DeptID, CatID, EmpTypeID, DefAddID, homePhone, pMobile, OfficePhone, Email, CntrPeriod, CardID, " &
                    " StatusDate, NoAdds, EmpStatus,EnrolNo,ContractStart,ContractEnd,IsEmpBOT,confirmDate,empReqHours,isShifed,shiftID,callName) VALUES " &
                    " ('" & txtRegNo.Text & "','" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "','" & StrTitleID & "','" & FK_Rep(txtLName.Text) & "', " &
                    " '" & FK_Rep(txtFirstName.Text) & "','" & FK_Rep(StrDispName) & "','" & txtNICNumber.Text & "','" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " &
                    " '" & StrGenderID & "','" & StrCivilStID & "','" & txtEmpNo.Text & "','" & FK_Rep(txtEpfNo.Text) & "','" & StrCompID & "', " &
                    " '" & StrDesgID & "','" & StrBranchID & "','" & StrDeptID & "','" & StrCategoryID & "','" & StrEmpTypeID & "', " &
                    " '001', '" & txthPhone.Text & "','" & txtmPhone.Text & "','" & txtOfficePhone.Text & "','" & txtEmail.Text & "', " &
                    " " & CDbl(IIf(txtCrPeriod.Text = "", 0, txtCrPeriod.Text)) & ",'','" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "',1," & intActive & "," & CInt(txtEnrolNo.Text) & ",'" & Format(dtpCFrom.Value, strRetDateTimeFormat) & "','" & Format(dtpCTo.Value, strRetDateTimeFormat) & "'," & chkIsBOT.CheckState & ",'" & Format(dtpConfDate.Value, strRetDateTimeFormat) & "','" & Val(txtOTforMonth.Text) & "'," & chkShift.CheckState & ",'" & strShiftID & "','" & txtCallName.Text & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblCompany SET NoEmps = NoEmps + 1 WHERE compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Isert Address to Address table 
                    'mailing address id is 001
                    sqlQRY = "INSERT INTO tblEmpAddress (EmpID,AddID,AddType,Add1,Add2,Add3,Status,compID) VALUES " &
                    " ('" & txtRegNo.Text & "','001','001','" & FK_Rep(txtmAdd1.Text) & "','" & FK_Rep(txtmAdd2.Text) & "','" & FK_Rep(txtmAdd3.Text) & "',0,'" & StrCompID & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Insert records to payroll
                    Dim strContact As String = "Home : " & txthPhone.Text & " | Mobile : " & txtmPhone.Text & " | Office : " & txtOfficePhone.Text
                    sqlQRY = "INSERT INTO tblPayrollEmployee ([RegID] ,joiningDate,[DispName] ,[EmIdNum],birthDate,genderID,maritalID,[EMPNo] ,[EPFNo],[ETPNo],[ComID],[DesigID],[BrID],[DeptID],sub_CatID,Contact,[status],BankID,BranchID,ReligionID,BondPeriod,ProbationDate,points,otherIDs,accNumber,[BasicSalary], " &
                    " [DaysPay],[SalViewLevel],[EpfAllowed],[PayID],[CostID],Qualification,FinalSalary)     VALUES ('" & txtRegNo.Text & "','" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "', " &
                    " '" & FK_Rep(StrDispName) & "','" & txtNICNumber.Text & "','" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " &
                    " '" & StrGenderID & "','" & StrCivilStID & "','" & txtEmpNo.Text & "','" & FK_Rep(txtEpfNo.Text) & "','" & FK_Rep(txtEpfNo.Text) & "','" & StrCompID & "', " &
                    " '" & StrDesgID & "','" & StrBranchID & "','" & StrDeptID & "','" & StrCategoryID & "', " &
                    " '" & strContact & "'," & intActive & ",'01','001','001','19000101','19000101','0','','','0','0','001','0','01','01','','0')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    Dim dtEndDate As Date = DateSerial(intCurrentYear, 12, 31)
                    Dim dtStartDate As Date = DateSerial(intCurrentYear, 1, 1)
                    Dim intDay As Integer = dtStartDate.DayOfWeek
                    Dim intGap As Integer = 1 - intDay : If intGap > 0 Then intGap = 1 - 7
                    dtStartDate = DateAdd(DateInterval.Day, intGap, dtStartDate)
                    'Update Employee Information to default Open Shift.
                    sqlQRY = " INSERT INTO tblEmpRegister (EmpID,CompID,cMonth,cYear,AtDate,InDate,InTime1,OutDate,OutTime1,InTime2,OutTime2,ShiftID,DayID,DayTypeID,sInTime,sOutTime, " &
                    " StrInTime,StrOutTime,AntStatus,WorkMins,WorkHrs,IsLate,LateMins,IsEarly,EarlyMins,IsLeave,LeaveID,NoLeave,IsoffdayWork,IsNightWork, " &
                    " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,Status,BgOTHrs,EdOTHrs,cOTHrs,AtEdit,ClockIn,ClockOut,OTApved, " &
                    " cOTMins, LEStatus, AllShifts, NRWorkDay, AdWorkDay, InTimeAP, NormalOT, NOTHours, AutoLeaveNo, DoubleOT, NormalOTHrs, DoubleOTHrs) SELECT '" & StrEmployeeID & "' ,'" & StrCompID & "',Month(tblCalendar.Date),Year(tblCalendar.Date),tblCalendar.Date,'','','','','','','" & StrDefaultShiftID & "',tblCalendar.DayID,tblCalendar.DayType," &
                    " tblcalendar.Date+tblSetShiftH.InTime,tblCalendar.Date+tblSetShiftH.OutTime,'','',0,0,0,0,0,0,0,0,'',0,0,0,0,0,0,0,0,0,0,0,0,0,0,tblCalendar.Date+tblSetShiftH.StartCIN,DateAdd(Day,tblSetShiftH.ShiftMode,tblCalendar.Date)+tblSetShiftH.EndCOUT,0,0,'0|0', " &
                    " '" & strShiftID & "',0,0,'',0,0,0,0,0,0 FROM tblCalendar,tblSetShiftH WHERE tblCalendar.Date Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "' AND  " &
                    " tblSetShiftH.ShiftID = '" & StrDefaultShiftID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = " INSERT INTO tblGetInOut " &
            " (EmpID,AtDate,AntStatus,ShiftID,InTime,OutDate,OutTime,sInTime,sOutTime,ClockIn,ClockOut,WorkMin,LateMin,IsLate,EarlyMin,IsEarly, " &
            " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BOTMin,EOTMin,OTMin,InDate,AtEdit,OTApved,ShiftLine,DayTypeID) " &
        " SELECT EmpID,AtDate,AntStatus,ShiftID,InTime1,OutDate,OutTime1,sInTime,sOutTime,clockIn,ClockOut,WorkMins,LateMins,IsLate,EarlyMins,IsEarly, " &
        " InUpdate,OutUpdate,mInUpdate,mOutUpdate,BeginOT,EndOT,cOTMins,Indate,AtEdit,OTApved,0,DayTypeID FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND AtDate Between '" & Format(dtStartDate, strRetDateTimeFormat) & "' AND '" & Format(dtEndDate, strRetDateTimeFormat) & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Registered New Employee Reg ID : " & StrEmployeeID & " And Name : " & FK_Rep(StrDispName) & "','" & StrUserID & "',getdate ())"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblDocumentCollected (regID,allDocIDs,status,crUser) VALUES ('" & StrEmployeeID & "','',0,'" & StrUserID & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Generate short leave for current year automatically
                    sqlQRY = "EXEC [SP_GenShortLeaveSelected] " & intCurrentYear & ",1," & intTotShLvMinPerMonth & "," & intMaxNoShLvPerMnth & ",'" & StrEmployeeID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    Sv_Image(StrEmployeeID)
                    MsgBox("Employee Registered For " & StrDispName)
                    sv_Leaves(StrCategoryID)

                Case "E"

                    'Update information 
                    sqlQRY = "UPDATE tblEmployee SET RegDate = '" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "',TitleID = '" & StrTitleID & "', " &
                   " SurName = '" & FK_Rep(txtLName.Text) & "',FirstName = '" & FK_Rep(txtFirstName.Text) & "',dispName = '" & FK_Rep(StrDispName) & "',NICNumber = '" & txtNICNumber.Text & "',DofB = '" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " &
                   " GenderID = '" & StrGenderID & "',CivilStID = '" & StrCivilStID & "',EmpNo = '" & FK_Rep(txtEmpNo.Text) & "',EpfNo = '" & FK_Rep(txtEpfNo.Text) & "' , " &
                   " CompID = '" & StrCompID & "'," &
                   " DefAddID = '" & StrDefAddID & "', " &
                   " homePhone = '" & txthPhone.Text & "', pMobile = '" & txtmPhone.Text & "', OfficePhone = '" & txtOfficePhone.Text & "',EnrolNo = '" & txtEnrolNo.Text & "', " &
                   " Email = '" & txtEmail.Text & "', CntrPeriod = " & CDbl(IIf(txtCrPeriod.Text = "", 0, txtCrPeriod.Text)) & ", EmpStatus = " & intActive & " , ContractStart = '" & Format(dtpCFrom.Value, strRetDateTimeFormat) & "', ContractEnd = '" & Format(dtpCTo.Value, strRetDateTimeFormat) & "',IsEmpBOT = " & chkIsBOT.CheckState & ", confirmDate='" & Format(dtpConfDate.Value, strRetDateTimeFormat) & "',   empReqHours='" & Val(txtOTforMonth.Text) & "',isShifed=" & chkShift.CheckState & ",callName='" & txtCallName.Text & "',shiftID='" & strShiftID & "'  WHERE RegID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Update Address Information 
                    sqlQRY = "UPDATE tblEmpAddress SET Add1 = '" & FK_Rep(txtmAdd1.Text) & "',Add2 = '" & FK_Rep(txtmAdd2.Text) & "',Add3 = '" & FK_Rep(txtmAdd3.Text) & "' " &
                    " WHERE EmpID = '" & StrEmployeeID & "' AND AddID = '" & StrDefAddID & "' AND CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Update records to payroll
                    'Dim strContact As String = "Home : " & txthPhone.Text & " | Mobile : " & txtmPhone.Text & " | Office : " & txtOfficePhone.Text
                    'sqlQRY = "UPDATE tblPayrollEmployee SET  joiningDate='" & Format(dtpRegDate.Value, strRetDateTimeFormat) & "',[DispName]= '" & FK_Rep(StrDispName) & "' ,[EmIdNum]='" & txtNICNumber.Text & "',birthDate='" & Format(dtpDofB.Value, strRetDateTimeFormat) & "', " & _
                    '" genderID='" & StrGenderID & "',maritalID='" & StrCivilStID & "',[EMPNo]='" & txtEmpNo.Text & "' ,[EPFNo]='" & FK_Rep(txtEpfNo.Text) & "',[ETPNo]='" & FK_Rep(txtEpfNo.Text) & "', " & _
                    '" [DesigID]= '" & StrDesgID & "',[BrID]='" & StrBranchID & "',[DeptID]='" & StrDeptID & "',sub_CatID='" & StrCategoryID & "',Contact='" & strContact & "',[status]=" & intActive & " " & _
                    '" WHERE RegID = '" & StrEmployeeID & "'"
                    'cmSave.CommandText = sqlQRY
                    'cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Updated exsisting employee Reg ID : " & StrEmployeeID & " And Name : " & FK_Rep(StrDispName) & "','" & StrUserID & "',getdate ())"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'trMOde=1=First Name, trMode=2=Last Name, trMode=3= Accounr number
                    If Trim(strFirstName.ToUpper) <> Trim(txtFirstName.Text.ToUpper) Then
                        sqlQRY = "INSERT INTO tblChangesInEmp (RegID,trDate,oldData,newData,trMode,trDesc,crUser,stat,dispName,newDispName) VALUES ('" & StrEmployeeID & "',getdate (),'" & strFirstName & "','" & txtFirstName.Text & "','01','Change the employee first name','" & StrUserID & "',0,'" & FK_Rep(strOldDispName) & "','" & FK_Rep(StrDispName) & "')"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()
                    End If

                    If Trim(strLastName.ToUpper) <> Trim(txtLName.Text.ToUpper) Then
                        sqlQRY = "INSERT INTO tblChangesInEmp (RegID,trDate,oldData,newData,trMode,trDesc,crUser,stat,dispName,newDispName) VALUES ('" & StrEmployeeID & "',getdate (),'" & strLastName & "','" & txtLName.Text & "','02','Change the employee last name','" & StrUserID & "',0,'" & FK_Rep(strOldDispName) & "','" & FK_Rep(StrDispName) & "')"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()
                    End If
                    'If bolCalEx = False Then
                    '    sqlQRY = "insert into tblEmpRegister" & _
                    '    " select '" & StrEmployeeID & "','" & StrCompID & "',tblCalendar.cMonth,tblCalendar.cYear,tblCalendar.Date, " & _
                    '    " '19000101','19000101','19000101','19000101','19000101','19000101',0,0,0,0,'','',0,1,tblCalendar.DayID,tblCalendar.DayType,'','',0,0,0,0,0,'','',0,0 FROM tblCalendar WHERE cYear = " & intCurrentYear & ""
                    '    cmSave.CommandText = sqlQRY
                    '    cmSave.ExecuteNonQuery()
                    'End If

                    trSave.Commit()
                    Sv_Image(StrEmployeeID)
                    MsgBox("Employee Information Modified of " & StrDispName)
                    'sv_Leaves(StrCategoryID)
                    RefreshButtonEmployee()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Public Sub vieww(ByVal StrEid As String)

        Try
            Dim CN As New SqlConnection(sqlConString)
            CN.Open()

            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = New SqlCommand("SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & StrEid & "' and Status='0'", CN)
            Dim Data As New DataTable
            'adapter = New MySql.Data.MySqlClient.MySqlDataAdapter("select picture from [yourtable]", Conn)

            Dim commandbuild As New SqlCommandBuilder(adapter)
            adapter.Fill(Data)
            ' MsgBox(Data.Rows.Count)
            picEmpProfil.Image = My.Resources.User_Anonymous_Disabled
            If Data.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim lb() As Byte = Data.Rows(Data.Rows.Count - 1).Item("svImage")
            Dim lstr As New System.IO.MemoryStream(lb)
            picEmpProfil.Image = Image.FromStream(lstr)
            lstr.Close()
            ' picEmpProfil.SizeMode = PictureBoxSizeMode.Zoom

            ''Dim iH As Integer = picEmpProfil.Image.Height ' 648
            ''Dim iW As Integer = picEmpProfil.Image.Width ' 432

            picEmpProfil.SizeMode = PictureBoxSizeMode.Zoom
            ''If iH - iW < 0 Then
            ''    picEmpProfil.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            ''End If

            'Rounder corner
            'Dim gp As New GraphicsPath()
            'gp.AddEllipse(picEmpProfil.DisplayRectangle)
            'picEmpProfil.Region = New Region(gp)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ''End Sub

        ''Private Sub viewwk(ByVal StrEid As String)

        ''    Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM [tblImgInfo] where [ImgID]='" & StrEid & "'")
        ''    If bolEx = True Then
        ''        Dim quary As String = "SELECT [svImage] FROM [tblImgInfo] where [ImgID]='" & StrEid & "'"
        ''        Dim BytImag As Byte() = Nothing
        ''        Dim con As New SqlConnection(sqlConString)
        ''        Try
        ''            con.Open()
        ''            Dim selectCommand As New SqlCommand(quary, con)
        ''            Dim red As SqlDataReader = selectCommand.ExecuteReader()
        ''            While red.Read()
        ''                BytImag = red.Item(0)
        ''                picbyte2 = BytImag
        ''            End While

        ''        Catch ex As Exception
        ''            MessageBox.Show(ex.ToString())
        ''        Finally
        ''            con.Close()
        ''        End Try

        ''        picEmpProfil.Image = Nothing
        ''        Dim FS1 As FileStream
        ''        FS1 = New FileStream("image6.jpg", FileMode.OpenOrCreate)
        ''        ' FS1.WriteByte(BytImag)
        ''        FS1.Write(BytImag, 0, BytImag.Length)
        ''        picEmpProfil.Image = Image.FromStream(FS1)
        ''        picEmpProfil.SizeMode = PictureBoxSizeMode.Zoom
        ''        picEmpProfil.Refresh()
        ''        FS1.Close()
        ''        FS1 = Nothing
        ''    Else
        ''        picEmpProfil.Image = Nothing
        ''    End If

    End Sub

    Public Sub Sv_Image(ByVal StrEid As String)

        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblImgInfo WHERE ImgID = '" & StrEid & "'")

        Dim sqlQRY As String
        Dim sqlQRY1 As String

        If picEmpProfil.Image Is Nothing Then
            sqlQRY1 = "DELETE FROM tblImgInfo WHERE ImgID = '" & StrEid & "'"
            Dim cnDel As New SqlConnection(sqlConString)
            cnDel.Open()
            Dim cmDel As New SqlCommand(sqlQRY1, cnDel)
            cmDel.ExecuteNonQuery()
            Exit Sub
        End If

        If picbyte2 Is Nothing Then
            Exit Sub
        End If

        If bolEx = True Then
            sqlQRY = "UPDATE tblImgInfo SET SvImage = @SvImage WHERE ImgID = @imgID"

        Else
            sqlQRY = "INSERT INTO [tblImgInfo] ([ImgID],[svImage],[Status]) VALUES (@ImgID,@svImage,@Status)"
        End If

        Dim cnImgSv As New SqlConnection(sqlConString)
        cnImgSv.Open()
        Dim cmImgSv As New SqlCommand(sqlQRY, cnImgSv)
        Dim trImgSv As SqlTransaction = cnImgSv.BeginTransaction
        cmImgSv.Transaction = trImgSv
        Try
            With cmImgSv

                .Parameters.Add("@ImgID", SqlDbType.NVarChar)
                .Parameters.Add("@svImage", SqlDbType.Image)
                .Parameters.Add("@Status", SqlDbType.Int)

                .Parameters("@ImgID").Value = StrEid
                .Parameters("@svImage").Value = picbyte2
                .Parameters("@Status").Value = 0
                .ExecuteNonQuery()

            End With

            trImgSv.Commit()

        Catch ex As Exception
            MsgBox(ex.Message)
            trImgSv.Rollback()
        Finally
            cnImgSv.Close()
        End Try

    End Sub

    Public Sub pb_ShowEmployee(ByVal StrEmpNo As String)
        Dim crtlk As Control
        For Each crtlk In Me.pnlMyData.Controls
            If TypeOf crtlk Is ComboBox And crtlk.Tag = 4 Then
                crtlk.Enabled = False
                crtlk.ForeColor = Color.Blue
            End If
        Next

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.TitleID, dbo.tblSetTitle.titleDesc, dbo.tblEmployee.SurName, dbo.tblEmployee.FirstName, " &
                      " dbo.tblEmployee.dispName,dbo.tblEmployee.NICNumber, dbo.tblEmployee.isEmpBOT ,dbo.tblEmployee.DofB, dbo.tblEmployee.CivilStID, dbo.tblCivilStatus.StDesc, dbo.tblEmployee.EmpNo ,dbo.tblEmployee.RegDate,tblEmployee.confirmDate, " &
      "   dbo.tblEmployee.EnrolNo, dbo.tblEmployee.GenderID,  dbo.tblEmployee.epfNo, dbo.tblEmployee.callName,dbo.tblGender.GenDesc, EmpStatus, dbo.tblImgInfo.svImage, dbo.tblEmployee.empReqHours,dbo.tblEmployee.isShifed" &
" FROM         dbo.tblEmployee LEFT OUTER JOIN" &
  "                     dbo.tblCivilStatus ON dbo.tblEmployee.CivilStID = dbo.tblCivilStatus.StID LEFT OUTER JOIN" &
    "                   dbo.tblImgInfo ON dbo.tblEmployee.RegID = dbo.tblImgInfo.ImgID LEFT OUTER JOIN" &
      "                 dbo.tblGender ON dbo.tblEmployee.GenderID = dbo.tblGender.GenID LEFT OUTER JOIN" &
        "               dbo.tblSetTitle ON dbo.tblEmployee.TitleID = dbo.tblSetTitle.titleID" &
" WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"

        Dim sqlQRYSec2 As String = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.EpfNo,  dbo.tblEmployee.isEmpBOT ,dbo.tblEmployee.DesigID, dbo.tblDesig.desgDesc, dbo.tblEmployee.BrID, dbo.tblCBranchs.BrName, " &
                 " dbo.tblEmployee.DeptID, dbo.tblSetDept.DeptName, dbo.tblEmployee.CatID, dbo.tblSetEmpCategory.CatDesc, dbo.tblEmployee.EmpTypeID, " &
           " dbo.tblSetEmpType.tDesc, dbo.tblEmployee.ContractStart, dbo.tblEmployee.ContractEnd,dbo.tblEmployee.shiftID,tblSetShiftH.shiftName " &
" FROM         dbo.tblEmployee LEFT OUTER JOIN" &
                  " dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID LEFT OUTER JOIN" &
                 " dbo.tblCBranchs ON dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND dbo.tblEmployee.CompID = dbo.tblCBranchs.CompID LEFT OUTER JOIN" &
                 " dbo.tblSetDept ON dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID LEFT OUTER JOIN" &
                 " dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID LEFT OUTER JOIN" &
                  " dbo.tblSetShiftH ON dbo.tblEmployee.shiftID = dbo.tblSetShiftH.shiftID LEFT OUTER JOIN" &
                 " dbo.tblSetEmpType ON dbo.tblEmployee.EmpTypeID = dbo.tblSetEmpType.TypeID" &
" WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"


        Dim sqlQRYSec3 As String = "SELECT     dbo.tblEmployee.DefAddID, dbo.tblEmployee.homePhone, dbo.tblEmployee.pMobile, dbo.tblEmployee.CntrPeriod, dbo.tblEmployee.OfficePhone, dbo.tblEmployee.Email, " &
        " dbo.tblEmpAddress.Add1, dbo.tblEmpAddress.Add2, dbo.tblEmpAddress.Add3" &
" FROM         dbo.tblEmpAddress LEFT OUTER JOIN" &
                     " dbo.tblEmployee ON dbo.tblEmpAddress.AddID = dbo.tblEmployee.DefAddID AND dbo.tblEmpAddress.EmpID = dbo.tblEmployee.RegID" &
" WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"

        Try

            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader

            If drShw.Read = True Then
                txtRegNo.Text = StrEmployeeID
                dtpRegDate.Value = IIf(IsDBNull(drShw.Item("RegDate")), DateSerial(1900, 1, 1), drShw.Item("RegDate"))
                StrTitleID = IIf(IsDBNull(drShw.Item("TitleID")), "", drShw.Item("TitleID"))
                cmbTItle.Text = IIf(IsDBNull(drShw.Item("titleDesc")), "", drShw.Item("titleDesc"))
                txtLName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("SurName")), "", drShw.Item("SurName")))
                txtFirstName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("FirstName")), "", drShw.Item("FirstName")))
                strFirstName = txtFirstName.Text
                strLastName = txtLName.Text
                StrDispName = FK_UndoRep(IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName")))
                strOldDispName = FK_UndoRep(IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName")))
                strExsNic = IIf(IsDBNull(drShw.Item("NICNumber")), "", drShw.Item("NICNumber"))
                txtNICNumber.Text = strExsNic
                dtpDofB.Value = IIf(IsDBNull(drShw.Item("DofB")), DateSerial(1900, 1, 1), drShw.Item("DofB"))
                StrGenderID = IIf(IsDBNull(drShw.Item("GenderID")), "", drShw.Item("GenderID"))
                cmbGender.Text = IIf(IsDBNull(drShw.Item("GenDesc")), "", drShw.Item("GenDesc"))
                StrCivilStID = IIf(IsDBNull(drShw.Item("CivilStID")), "", drShw.Item("CivilStID"))
                cmbCivilSt.Text = IIf(IsDBNull(drShw.Item("StDesc")), "", drShw.Item("StDesc"))
                'txtAge.Text = DateDiff(DateInterval.Year, dtpDofB.Value, dtWorkingDate)
                Dim intAge As Integer = DateDiff(DateInterval.Month, dtpDofB.Value, dtWorkingDate)
                Dim intYear As Integer = intAge \ 12
                Dim intMonth As Integer = intAge Mod 12
                txtAge.Text = intYear & " Y : " & intMonth & " M "

                intExsEnNo = IIf(IsDBNull(drShw.Item("EnrolNo")), 0, drShw.Item("EnrolNo"))
                txtEnrolNo.Text = intExsEnNo
                txtEpfNo.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("EpfNo")), "", drShw.Item("EpfNo")))
                txtEmpNo.Text = IIf(IsDBNull(drShw.Item("EmpNo")), "", drShw.Item("EmpNo"))
                chkIsBOT.CheckState = IIf(IsDBNull(drShw.Item("IsEmpBOT")), 0, drShw.Item("IsEmpBOT"))
                dtpConfDate.Value = IIf(IsDBNull(drShw.Item("confirmDate")), DateSerial(1900, 1, 1), drShw.Item("confirmDate"))
                Dim intT As Integer = IIf(IsDBNull(drShw.Item("EmpStatus")), 1, drShw.Item("EmpStatus"))
                If intT = 9 Then
                    chkCancel.Checked = True
                Else
                    chkCancel.Checked = False
                End If
                txtOTforMonth.Text = IIf(IsDBNull(drShw.Item("empReqHours")), "", drShw.Item("empReqHours"))
                chkShift.CheckState = IIf(IsDBNull(drShw.Item("isShifed")), 0, drShw.Item("isShifed"))
                txtCallName.Text = IIf(IsDBNull(drShw.Item("callName")), "", drShw.Item("callName"))

                get_FullName(cmbTItle.Text, txtFirstName.Text, txtLName.Text)
                vieww(StrEmployeeID)

                StrSvStatus = "E"
                'sv_Leaves(StrCategoryID)
            Else
                StrSvStatus = "S"

            End If

            drShw.Close()

            'Second Section is filled
            Dim cmShwSec2 As New SqlCommand(sqlQRYSec2, cnShw)
            Dim drShwSec2 As SqlDataReader = cmShwSec2.ExecuteReader

            If drShwSec2.Read = True Then
                StrDesgID = IIf(IsDBNull(drShwSec2.Item("DesigID")), "", drShwSec2.Item("DesigID"))
                cmbDesignation.Text = IIf(IsDBNull(drShwSec2.Item("DesgDesc")), "", drShwSec2.Item("DesgDesc"))
                StrBranchID = IIf(IsDBNull(drShwSec2.Item("BrID")), "", drShwSec2.Item("BrID"))
                cmbBranch.Text = IIf(IsDBNull(drShwSec2.Item("BrName")), "", drShwSec2.Item("BrName"))
                StrDeptID = IIf(IsDBNull(drShwSec2.Item("DeptID")), "", drShwSec2.Item("DeptID"))
                cmbDept.Text = IIf(IsDBNull(drShwSec2.Item("DeptName")), "", drShwSec2.Item("DeptName"))
                StrCategoryID = IIf(IsDBNull(drShwSec2.Item("CatID")), "", drShwSec2.Item("CatID"))
                cmbEmpCategory.Text = IIf(IsDBNull(drShwSec2.Item("CatDesc")), "", drShwSec2.Item("CatDesc"))
                StrEmpTypeID = IIf(IsDBNull(drShwSec2.Item("EmpTypeID")), "", drShwSec2.Item("EmpTypeID"))
                cmbEmpType.Text = IIf(IsDBNull(drShwSec2.Item("TDesc")), "", drShwSec2.Item("TDesc"))
                dtpCFrom.Value = IIf(IsDBNull(drShwSec2.Item("ContractStart")), "1/1/1900", drShwSec2.Item("ContractStart"))
                dtpCTo.Value = IIf(IsDBNull(drShwSec2.Item("ContractEnd")), "1/1/1900", drShwSec2.Item("ContractEnd"))
                strShiftID = IIf(IsDBNull(drShwSec2.Item("shiftID")), "", drShwSec2.Item("shiftID"))
                cmbShift.Text = IIf(IsDBNull(drShwSec2.Item("shiftName")), "", drShwSec2.Item("shiftName"))
            End If
            drShwSec2.Close()

            Dim cmShwSec3 As New SqlCommand(sqlQRYSec3, cnShw)
            Dim drShwSec3 As SqlDataReader = cmShwSec3.ExecuteReader

            If drShwSec3.Read = True Then

                StrDefAddID = IIf(IsDBNull(drShwSec3.Item("DefAddID")), "", drShwSec3.Item("DefAddID"))
                txthPhone.Text = IIf(IsDBNull(drShwSec3.Item("homePhone")), "", drShwSec3.Item("homePhone"))
                txtmPhone.Text = IIf(IsDBNull(drShwSec3.Item("pMobile")), "", drShwSec3.Item("pMobile"))
                txtEmail.Text = IIf(IsDBNull(drShwSec3.Item("Email")), "", drShwSec3.Item("Email"))
                txtOfficePhone.Text = IIf(IsDBNull(drShwSec3.Item("OfficePhone")), "", drShwSec3.Item("OfficePhone"))
                txtCrPeriod.Text = IIf(IsDBNull(drShwSec3.Item("CntrPeriod")), "0", drShwSec3.Item("CntrPeriod"))
                txtmAdd1.Text = FK_UndoRep(IIf(IsDBNull(drShwSec3.Item("Add1")), "", drShwSec3.Item("Add1")))
                txtmAdd2.Text = FK_UndoRep(IIf(IsDBNull(drShwSec3.Item("Add2")), "", drShwSec3.Item("Add2")))
                txtmAdd3.Text = FK_UndoRep(IIf(IsDBNull(drShwSec3.Item("Add3")), "", drShwSec3.Item("Add3")))

            End If
            drShwSec3.Close()
            bolIsLoad = False

            lblName.Text = StrDispName
            lblBranchtop.Text = "Branch : " & cmbBranch.Text
            lblDesignation.Text = "Designation : " & cmbDesignation.Text
            lblEmpNumb.Text = "Emp No : " & txtEmpNo.Text
            lblAddres.Text = "Address : " & txtmAdd1.Text & " " & txtmAdd2.Text & " " & txtmAdd3.Text
            lblBirth.Text = "Birthday : " & Format(dtpDofB.Value, "dd-MM-yyyy")
            lbldepeartment.Text = "Department : " & cmbDept.Text
            lblEmail.Text = "Email : " & txtEmail.Text

        Catch ex As Exception
            MsgBox("Error Occured while Reading the Database. " + ex.Message)
        Finally
            cnShw.Close()
        End Try

        'sqlQRY = "SELECT tblEmployee.RegID,tblEmployee.RegDate,tblEmployee.TitleID,dbo.fk_RetTitle(tblEmployee.TitleID,'01') As 'tDesc', " & _
        '" tblEmployee.SurName,tblEmployee.FirstName,tblEmployee.dispName,tblEmployee.NICNumber,tblEmployee.DofB,tblEmployee.GenderID, " & _
        '" dbo.fk_RetGender(tblEmployee.GenderID,'01') As gDesc, " & _
        '" tblEmployee.CivilStID,dbo.fk_RetCStatus (tblEmployee.CivilStID,'01') As cStDesc, tblEmployee.EmpNo,tblEmployee.EpfNo,tblEmployee.CompID," & _
        '" tblEmployee.DesigID,dbo.fk_RetDesigs(tblEmployee.DesigID,'01') as DsgDesc,tblEmployee.BrID,dbo.fk_RetBranches(tblEmployee.CompID,BrID,'01') As BrName, " & _
        '" tblEmployee.DeptID,dbo.fk_RetDepts(tblEmployee.DeptID,'01') As DeptName, tblEmployee.CatID,dbo.fk_RetCategory(tblEmployee.CatID,'01') As CatDesc, " & _
        '" tblEmployee.EmpTypeID,dbo.fk_RetEmpTYpe(tblEmployee.EmpTypeID,'01') As TypeDesc, tblEmployee.DefAddID, tblEmployee.homePhone, " & _
        '" tblEmployee.pMobile, tblEmployee.OfficePhone,tblEmployee.EnrolNo, tblEmployee.Email, tblEmployee.CntrPeriod, tblEmployee.CardID, tblEmployee.StatusDate, tblEmployee.NoAdds, tblEmployee.EmpStatus, " & _
        '" tblEmpAddress.AddID,tblEmpAddress.Add1,tblEmpAddress.Add2,tblEmpAddress.Add3,tblEmployee.ContractStart ,tblEmployee.ContractEnd  " & _
        '" FROM tblEmployee INNER JOIN tblEmpAddress ON tblEmployee.RegID = tblEmpAddress.EmpID AND tblEmployee.CompID = tblEmpAddress.CompID AND tblEmpAddress.AddID = tblEmployee.DefAddID WHERE tblEmployee.RegID = '" & StrEmpNo & "' AND tblEmployee.CompID = '" & StrCompID & "'"


        'Try
        '    Dim cmShw As New SqlCommand(sqlQRY, cnShw)
        '    Dim drShw As SqlDataReader = cmShw.ExecuteReader
        '    If drShw.Read = True Then

        '        'RegID, , , , , , , , " & _"
        '        '    " ,,,,CompID,,," & _
        '        '    " , , , , , , , , , CardID, " & _
        '        '    " StatusDate, NoAdds, EmpStatus








        'StrSvStatus = "E"




        '    Else
        'StrSvStatus = "S"
        '    End If


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnShw.Close()
        'End Try

    End Sub

    Public Sub get_FullName(ByVal StrTl As String, ByVal StrFN As String, ByVal StrLN As String)

        StrDispName = StrTl & " " & GetInitialsFromString(RTrim(StrFN)) & " " & StrLN
        'StrFlName = RTrim(StrFN) & " " & StrLN

    End Sub

    Private Sub txtSName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLName.Leave

        strSurNameClr = txtLName.Text.Trim
        Do While (strSurNameClr.IndexOf(Space(2)) >= 0)
            strSurNameClr = strSurNameClr.Replace(Space(2), Space(1))
        Loop

        get_FullName(cmbTItle.Text, strFNamesClr, strSurNameClr)
        txtLName.Text = strSurNameClr

    End Sub

    Private Sub txtFirstName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFirstName.Leave

        strFNamesClr = txtFirstName.Text.Trim
        Do While (strFNamesClr.IndexOf(Space(2)) >= 0)
            strFNamesClr = strFNamesClr.Replace(Space(2), Space(1))
        Loop
        txtFirstName.Text = strFNamesClr
        get_FullName(cmbTItle.Text, strFNamesClr, strSurNameClr)

        lblName.Text = StrDispName
        lblBranchtop.Text = "Branch : " & cmbBranch.Text
        lblEmpNumb.Text = "Emp No : " & txtEmpNo.Text

    End Sub

    Private Sub txtNICNumber_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNICNumber.Leave

        Try
            Call IDNum_Results(txtNICNumber.Text)

            dtpDofB.Value = dtNICDoB
            cmbGender.Text = StrNICSex
            txtAge.Text = DateDiff(DateInterval.Year, dtpDofB.Value, dtWorkingDate)
            Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblEMployee WHERE NicNumber = '" & txtNICNumber.Text & "' AND compID = '" & StrCompID & "' AND tblEMployee.empStatus<>9")

            If StrSvStatus = "S" Then
                If bolEx = True Then
                    MsgBox("You Can't Process Save due to Duplicate NIC number", MsgBoxStyle.Critical)

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRegNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pb_ShowEmployee(txtRegNo.Text)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        'Dim crtl As Control
        'For Each crtl In Me.Panel3.Controls
        '    If TypeOf crtl Is Form Then

        '    End If
        'Next
        'GroupBox3.Visible = True

    End Sub

    Private Sub cmbTItle_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTItle.Leave
        get_FullName(cmbTItle.Text, txtFirstName.Text, txtLName.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'frmMasterEmployee.Timer1.Stop()

        strReActEmp = "Ac"

        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " &
        "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " &
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then

                'StrEmployeeID = FK_Read("RegID")
                pb_ShowEmployee(StrEmployeeID)
                'strKEmProfileID = StrEmployeeID

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try

        'frmMasterEmployee.Timer1.Start()
        'Dim frmBrs As New frmSrchEmployee
        'frmBrs.ShowDialog()

    End Sub

    'Private Sub txtEpfNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEpfNo.TextChanged
    '    txtEnrolNo.Text = txtEpfNo.Text
    'End Sub

    Private Sub cmdClrImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        picEmpProfil.Image = Nothing
    End Sub

    Private Sub txtSName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLName.TextChanged
        If StrSvStatus = "S" Then
            txtCallName.Text = txtLName.Text
        End If
    End Sub

    Private Sub txtAge_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAge.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If


    End Sub
    Private Sub txtEnrolNo_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEnrolNo.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

    End Sub

    Private Sub txtRegNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLName.KeyPress, txtOfficePhone.KeyPress, txtNICNumber.KeyPress, txtmPhone.KeyPress, txtmAdd3.KeyPress, txtmAdd2.KeyPress, txtmAdd1.KeyPress, txthPhone.KeyPress, txtFirstName.KeyPress, txtEpfNo.KeyPress, txtEnrolNo.KeyPress, txtEmail.KeyPress, txtCrPeriod.KeyPress, txtAge.KeyPress, dtpRegDate.KeyPress, dtpDofB.KeyPress, cmdSave.KeyPress, cmdRefresh.KeyPress, cmbTItle.KeyPress, cmbGender.KeyPress, cmbEmpType.KeyPress, cmbEmpCategory.KeyPress, cmbDesignation.KeyPress, cmbDept.KeyPress, cmbCivilSt.KeyPress, cmbBranch.KeyPress
        Dim crtl As Control
        crtl = sender
        If AscW(e.KeyChar) = 13 Then
            crtl = GetNextControl(sender, True)
            crtl.Focus()

        End If
    End Sub
    Private Sub txthPhone_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthPhone.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
    Private Sub txtmPhone_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmPhone.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub
    Private Sub txtOfficePhone_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOfficePhone.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
    End Sub

    Private Sub txtNICNumber_keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNICNumber.KeyPress

        If txtNICNumber.TextLength <= 8 Then
            If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
                e.Handled = True
            End If
            If (Asc(e.KeyChar) = 8) Then
                e.Handled = False
            End If
        End If
        If (Asc(e.KeyChar) = 39) Then
            e.Handled = True
        End If

    End Sub
    Private Sub txtCrPeriod_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCrPeriod.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

    End Sub

    Private Sub dtpCF_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCFrom.ValueChanged
        'txtCrPeriod.Text = DateDiff(DateInterval.Month, dtpCF.Value, dtpCt.Value)
        'Dim span As TimeSpan = dtpCt.Value.Subtract(dtpCF.Value)
        'txtCrPeriod.Text = (dtpCt.Value.Month - dtpCF.Value.Month).ToString
        Dim intMonth As Integer = 0
        Dim dtpCF2 As New DateTimePicker
        Dim dtpCt2 As New DateTimePicker
        dtpCF2.Value = dtpCFrom.Value
        dtpCt2.Value = dtpCTo.Value
        dtpCt2.Value = dtpCt2.Value.AddDays(2)

        While dtpCF2.Value.Date < dtpCt2.Value.Date
            dtpCF2.Value = dtpCF2.Value.AddMonths(1)
            intMonth = intMonth + 1
        End While
        intMonth = intMonth - 1
        txtCrPeriod.Text = (IIf(intMonth < 0, 0, intMonth)).ToString
        dtpCTo.MinDate = dtpCFrom.Value.Date
    End Sub

    Private Sub dtpCt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCTo.ValueChanged
        Dim intMonth As Integer = 0
        Dim dtpCF2 As New DateTimePicker
        Dim dtpCt2 As New DateTimePicker
        dtpCF2.Value = dtpCFrom.Value
        dtpCt2.Value = dtpCTo.Value
        dtpCt2.Value = dtpCt2.Value.AddDays(2)

        While dtpCF2.Value.Date < dtpCt2.Value.Date
            dtpCF2.Value = dtpCF2.Value.AddMonths(1)
            intMonth = intMonth + 1
        End While
        intMonth = intMonth - 1
        txtCrPeriod.Text = (IIf(intMonth < 0, 0, intMonth)).ToString

    End Sub

    Private Sub dtpRegDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRegDate.ValueChanged

        dtpCFrom.Value = dtpRegDate.Value.Date
        dtpConfDate.Value = DateAdd(DateInterval.Month, 12, dtpRegDate.Value.Date)

    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If frmMainAttendance.SetTitlesToolStripMenuItem.Enabled = True Then


        'End If

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetDesignation
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()

        'ListCombo(cmbDesignation, "select * from tblDesig where status = 0 order by desgID", "desgDesc")

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetCBranchs
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbBranch, "SELECT * FROM tblCBranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID", "BrName")

        'End If

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetDepartment
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbDept, "SELECT * FROM tblSetDept WHERE Status = 0 Order By DeptID", "DeptName")

    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetCategory
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbEmpCategory, "select * From tblSEtEmpCategory WHERE Status = 0 ORder By CatID", "catDesc")

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetEmpTypes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbEmpType, "SELECT * FROM tblSetEmpType WHERE Status = 0 Order By TypeID", "tDesc"

    End Sub

    Private Sub picEDesig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEDesig.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbDesignation.Text
        strExsistedCode = StrDesgID

        If StrSvStatus = "E" Then

            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "001"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()
            'End If
        Else
            Exit Sub
        End If

    End Sub

    Private Sub picEBr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEBr.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbBranch.Text
        strExsistedCode = StrBranchID
        If StrSvStatus = "E" Then

            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "002"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub PicEDept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEDept.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbDept.Text
        strExsistedCode = StrDeptID
        If StrSvStatus = "E" Then
            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "003"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub picECat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picECat.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbEmpCategory.Text
        strExsistedCode = StrCategoryID
        If StrSvStatus = "E" Then
            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True


            StrTTrMode = "004"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub picEType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEType.Click
        If UP("Employee Profile", "Edit employee profile") = False Then Exit Sub
        strExsisted = cmbEmpType.Text
        strExsistedCode = StrEmpTypeID
        If StrSvStatus = "E" Then
            pnlMostRLeft.Width = 357
            pnlEditHistory.Height = 244
            pnlMostRLeft.Visible = True

            StrTTrMode = "005"

            Me.pnlEditHistory.Controls.Clear()
            Dim frmReg As New frmChgCodes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlEditHistory.Controls.Add(frmReg)

            frmReg.Show()

        Else
            Exit Sub
        End If
    End Sub

    Private Sub chkCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCancel.Click
        If chkCancel.Checked = True Then
            'Get Transaction 
            Dim iTr As Integer = fk_sqlDbl("SELECT NoTrs FROM tblControl") + 1
            Dim StrTr As String = fk_CreateSerial(10, iTr)

            sSQL = "UPDATE tblEmployee SET EmpStatus = 9,StatusDate = '" & Format(dtWorkingDate, strRetDateTimeFormat) & "' WHERE RegID = '" & Trim(txtRegNo.Text) & "'" &
                " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES " &
                " ('" & StrTr & "','" & Format(dtWorkingDate, strRetDateTimeFormat) & "','" & Me.Name & "','CE','Cancel Employee','" & StrUserID & "',0,1,'" & Trim(txtRegNo.Text) & "')"
            FK_EQ(sSQL, "E", "", True, True, True)
        End If
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        cmdPrevious.Enabled = True
        If StrSvStatus = "S" Then MessageBox.Show("Please select employee first", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

        Try
            Dim Et As String = ""
            StrEmployeeID = fk_RetString("SELECT Min(isnull(regid,0)) FROM tblEmployee WHERE regid > '" & txtRegNo.Text & "' and tblemployee.empstatus<>9")
            If fk_RetString("SELECT Max(RegID) FROM tblEmployee WHERE tblemployee.empstatus<>9") = StrEmployeeID Then
                MessageBox.Show("You reached to last page", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmdNext.Enabled = False
            End If
            If StrEmployeeID <> "" Then
                Dim crtl As Control
                For Each crtl In Me.pnlMyData.Controls
                    If TypeOf crtl Is TextBox Then
                        crtl.Text = ""
                    End If
                Next
                pb_ShowEmployee(StrEmployeeID)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevious.Click
        cmdNext.Enabled = True
        Try
            Dim Et As String = ""
            StrEmployeeID = fk_RetString("SELECT Max(regID) FROM tblEmployee WHERE regID< '" & txtRegNo.Text & "' and tblemployee.empstatus<>9")
            If fk_RetString("SELECT Min(RegID) FROM tblEmployee WHERE tblemployee.empstatus<>9") = StrEmployeeID Then
                MessageBox.Show("You reached to first page", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : cmdPrevious.Enabled = False
            End If
            If StrEmployeeID <> "" Then
                Dim crtl As Control
                For Each crtl In Me.pnlMyData.Controls
                    If TypeOf crtl Is TextBox Then
                        crtl.Text = ""
                    End If
                Next
                pb_ShowEmployee(StrEmployeeID)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub picEmpProfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEmpProfil.DoubleClick
        'Method old*************************************************
        Dim dr As DialogResult = MessageBox.Show("Do you want add photo ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If dr = Windows.Forms.DialogResult.No Then
            picEmpProfil.Image = Nothing

        End If

        Dim imagename As String
        Try
            Dim fldlg As FileDialog = New OpenFileDialog()
            fldlg.InitialDirectory = "D:\"
            fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
            If fldlg.ShowDialog() = DialogResult.OK Then
                imagename = fldlg.FileName
                Dim newimg As New Bitmap(imagename)
                picEmpProfil.Image = newimg
                picEmpProfil.SizeMode = PictureBoxSizeMode.Zoom
                Dim fs As FileStream
                fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
                Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
                picbyte2 = picbyte
                fs.Close()
            End If
            fldlg = Nothing

        Catch ae As System.ArgumentException
            imagename = " "
            MessageBox.Show(ae.Message.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
        'Method old*************************************************

        ''Method isanka_________________________________________________________
        'Dim dr As DialogResult = MessageBox.Show("Do you want add photo ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        'If dr = Windows.Forms.DialogResult.No Then
        '    picEmpProfil.Image = Nothing

        'End If

        'Dim imagename As String
        'Dim StrFileNameOnly As String = ""
        'Dim StrFilePathOnly As String = ""
        'Dim StrNewFilePatha As String = ""
        'Try
        '    Dim fldlg As FileDialog = New OpenFileDialog()
        '    fldlg.InitialDirectory = "D:\"
        '    fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
        '    If fldlg.ShowDialog() = DialogResult.OK Then
        '        imagename = fldlg.FileName
        '        StrFileNameOnly = System.IO.Path.GetFileName(fldlg.FileName)
        '        StrFileNameOnly = "A_" & StrFileNameOnly
        '        StrFilePathOnly = System.IO.Path.GetDirectoryName(fldlg.FileName)
        '        StrNewFilePatha = StrFilePathOnly & "\" & StrFileNameOnly
        '        StrNewFilePatha = TestRotate(imagename, StrNewFilePatha)
        '        imagename = StrNewFilePatha
        '        Dim newimg As New Bitmap(imagename)
        '        picEmpProfil.Image = newimg
        '        '

        '        '
        '        Dim fs As FileStream
        '        fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
        '        Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
        '        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
        '        picbyte2 = picbyte
        '        fs.Close()
        '    End If
        '    fldlg = Nothing

        'Catch ae As System.ArgumentException
        '    imagename = " "
        '    MessageBox.Show(ae.Message.ToString())
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString())
        'End Try
        ''Method isanka_________________________________________________________

        '[20181018] remove by prasanna - for fantasia image insert 
        'Dim dr As DialogResult = MessageBox.Show("Do you want add photo ? ", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        'If dr = Windows.Forms.DialogResult.No Then
        '    picEmpProfil.Image = Nothing

        'End If

        'Dim imagename As String
        'Try
        '    Dim fldlg As FileDialog = New OpenFileDialog()
        '    fldlg.InitialDirectory = "D:\"
        '    fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
        '    If fldlg.ShowDialog() = DialogResult.OK Then
        '        '    imagename = fldlg.FileName
        '        '    Dim newimg As New Bitmap(imagename)
        '        '    picEmpProfil.Image = newimg
        '        '    picEmpProfil.SizeMode = PictureBoxSizeMode.Zoom
        '        '    Dim fs As FileStream
        '        '    fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
        '        '    Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
        '        '    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
        '        '    picbyte2 = picbyte
        '        '    fs.Close()
        '        'End If
        '        'fldlg = Nothing

        '        imagename = fldlg.FileName
        '        Dim newimg As New Bitmap(imagename)
        '        picEmpProfil.Image = newimg
        '        Dim iH As Integer = picEmpProfil.Image.Height ' 648
        '        Dim iW As Integer = picEmpProfil.Image.Width ' 432

        '        picEmpProfil.SizeMode = PictureBoxSizeMode.Zoom
        '        If iH - iW < 0 Then
        '            picEmpProfil.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        '        End If
        '        '
        '        Dim fs As FileStream
        '        fs = New FileStream(imagename, FileMode.Open, FileAccess.Read)
        '        Dim picbyte As Byte() = New Byte(fs.Length - 1) {}
        '        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length))
        '        picbyte2 = picbyte
        '        fs.Close()
        '    End If
        '    fldlg = Nothing


        'Catch ae As System.ArgumentException
        '    imagename = " "
        '    MessageBox.Show(ae.Message.ToString())
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message.ToString())
        'End Try

    End Sub

    Private Sub cmdEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEmployee.Click
        Me.pnlPublic.Controls.Clear()
        Me.pnlPublic.Controls.Add(pnlMyData)
        strClickedEmp = "cmdEmployee"
        ButtonClickedEmp()
    End Sub

    Private Sub ButtonClickedEmp()

        Select Case strClickedEmp

            Case "cmdEmployee"
                Me.cmdEmployee.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdEmployee.FlatStyle = FlatStyle.Standard
                'Me.cmdEmployee.FlatAppearance.BorderSize = 1
                'Me.cmdEmployee.Width = 89
                'Me.cmdEmployee.Height = 79
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdAddress"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdAddress.FlatStyle = FlatStyle.Standard
                'Me.cmdAddress.FlatAppearance.BorderSize = 1
                'Me.cmdAddress.Width = 89
                'Me.cmdAddress.Height = 79
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdCardData"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                'Me.cmdCardData.Width = 89
                'Me.cmdCardData.Height = 79
                Me.cmdCardData.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdCardData.FlatStyle = FlatStyle.Standard
                'Me.cmdCardData.FlatAppearance.BorderSize = 1
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdLeve"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdLeve.FlatStyle = FlatStyle.Standard
                'Me.cmdLeve.FlatAppearance.BorderSize = 1
                'Me.cmdLeve.Width = 89
                'Me.cmdLeve.Height = 79
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdShifts"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdShifts.FlatStyle = FlatStyle.Standard
                'Me.cmdShifts.FlatAppearance.BorderSize = 1
                'Me.cmdShifts.Width = 89
                'Me.cmdShifts.Height = 79
                Me.cmdAttns.BackgroundImage = Nothing
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing
            Case "cmdAttns"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = My.Resources.mainEmployeeInfo
                'Me.cmdAttns.FlatStyle = FlatStyle.Standard
                'Me.cmdAttns.FlatAppearance.BorderSize = 1
                'Me.cmdAttns.Width = 89
                'Me.cmdAttns.Height = 79
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = Nothing

            Case "cmdFamilly"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                'Me.cmdAttns.FlatStyle = FlatStyle.Standard
                'Me.cmdAttns.FlatAppearance.BorderSize = 1
                'Me.cmdAttns.Width = 89
                'Me.cmdAttns.Height = 79
                Me.cmdFamily.BackgroundImage = My.Resources.mainEmployeeInfo
                Me.cmdTraining.BackgroundImage = Nothing

            Case "cmdTraining"
                Me.cmdEmployee.BackgroundImage = Nothing
                Me.cmdAddress.BackgroundImage = Nothing
                Me.cmdCardData.BackgroundImage = Nothing
                Me.cmdLeve.BackgroundImage = Nothing
                Me.cmdShifts.BackgroundImage = Nothing
                Me.cmdAttns.BackgroundImage = Nothing
                'Me.cmdAttns.FlatStyle = FlatStyle.Standard
                'Me.cmdAttns.FlatAppearance.BorderSize = 1
                'Me.cmdAttns.Width = 89
                'Me.cmdAttns.Height = 79
                Me.cmdFamily.BackgroundImage = Nothing
                Me.cmdTraining.BackgroundImage = My.Resources.mainEmployeeInfo
        End Select

    End Sub

    Private Sub cmdShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShifts.Click
        'strClickedEmp = "cmdShifts"
        'Me.pnlPublic.Controls.Clear()
        'Dim frmReg As New frmEmpShift
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized

        'frmReg.TopLevel = False
        'Me.pnlPublic.Controls.Add(frmReg)

        'frmReg.Show()
        'ButtonClicked()



        Dim AdvanHRIDDetails As Integer = fk_sqlDbl("select AdvanHRIDDetails from tblControl ")
        If AdvanHRIDDetails = 1 Then
            strClickedEmp = "cmdShifts"
            Me.pnlPublic.Controls.Clear()
            Dim frmReg As New frmHRMAdtionalInfomation
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg)

            frmReg.Show()
            ButtonClickedEmp()

        Else
            strClickedEmp = "cmdShifts"
            Me.pnlPublic.Controls.Clear()
            Dim frmReg As New frmEmpShift
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg)

            frmReg.Show()
            ButtonClickedEmp()
        End If
    End Sub

    Private Sub cmdAttns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAttns.Click
        strClickedEmp = "cmdAttns"
        Me.pnlPublic.Controls.Clear()
        Dim frmReg As New frmEmpAttendance
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClickedEmp()
    End Sub

    Private Sub cmdAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddress.Click
        strClickedEmp = "cmdAddress"
        Me.pnlPublic.Controls.Clear()
        Dim frmReg As New frmEmpAddress
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClickedEmp()

        'strClickedEmp = "cmdAddress"
        'Me.pnlPublic.Controls.Clear()
        'Dim frmReg As New frmHRMAdtionalInfomation
        'frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'frmReg.WindowState = FormWindowState.Maximized

        'frmReg.TopLevel = False
        'Me.pnlPublic.Controls.Add(frmReg)

        'frmReg.Show()
        'ButtonClicked()
    End Sub

    Private Sub cmdCardData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCardData.Click
        strClickedEmp = "cmdCardData"
        Me.pnlPublic.Controls.Clear()
        If IntIsPayrolDataEnabled = 1 Then
            If UP("Payroll Data", "View payroll data from attendance") = False Then Exit Sub
            Dim frmReg As New frmPayrollData
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized
            frmReg.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg)
            frmReg.Show()
            ButtonClickedEmp()

        End If
    End Sub

    Private Sub cmdLeve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeve.Click
        strClickedEmp = "cmdLeve"
        Me.pnlPublic.Controls.Clear()
        Dim frmReg As New frmEmpLeave
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClickedEmp()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdFamily_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFamily.Click
        Try
            strClickedEmp = "cmdFamilly"
            If IsFamilyInfo = 0 Then
                Exit Sub
            End If
            Me.pnlPublic.Controls.Clear()
            Dim frmReg1 As New frmEmpRelationInfo
            frmReg1.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg1.WindowState = FormWindowState.Maximized

            frmReg1.TopLevel = False
            Me.pnlPublic.Controls.Add(frmReg1)

            frmReg1.Show()
            ButtonClickedEmp()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub cmdTraining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraining.Click
        strClickedEmp = "cmdTraining"
        ' If IsAdditionalHRModule = 0 Then
        'Exit Sub
        ' End If
        Me.pnlPublic.Controls.Clear()
        'Me.pnlPublic.Refresh()
        'Me.pnlPublic.Invalidate()
        Dim frmReg As New frmHRMInfomation
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlPublic.Controls.Add(frmReg)

        frmReg.Show()
        ButtonClickedEmp()
    End Sub

    Private Sub txtRegNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtEnrolNo.Text = CDbl(txtRegNo.Text)
    End Sub

    Private Sub txtEnrolNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEnrolNo.TextChanged
        txtEpfNo.Text = txtEnrolNo.Text.ToString.PadLeft(6, "0")
    End Sub

    Private Sub txtEpfNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEpfNo.TextChanged
        txtEmpNo.Text = txtEpfNo.Text
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetShiftType
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        'ListCombo(cmbShift, "SELECT * FROM tblsetShifth WHERE Status = 0 Order By shiftID", "shiftName")
    End Sub

    Private Sub cmbShift_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShift.SelectedIndexChanged
        strShiftID = fk_RetString("SELECT shiftID FROM tblSetShiftH WHERE shiftName = '" & cmbShift.Text & "'")
    End Sub

    Private Sub PictureBox26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox26.Click
        LoadForm(New frmSetTitle)
        ListCombo(cmbTItle, "SELECT * FROM tblSetTitle WHERE Status = 0 Order By titleID", "titleDesc")
    End Sub

    Private Sub PictureBox25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox25.Click
        LoadForm(New frmSetGender)
        ListCombo(cmbTItle, "SELECT * FROM tblGender WHERE Status = 0 Order By gendesc", "titleDesc")

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text.Length = 0 Or txtSearch.Text.Length Mod 2 = 1 Then
            ViewEmployee()
        End If
    End Sub

    Private Sub cmdScroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrollToggle.Click
        If pnlMostRLeft.Width = 357 Then
            pnlMostRLeft.Width = 0
        Else
            ViewEmployee()
        End If

        'If pnlEditHistory.Height = 244 Then
        pnlEditHistory.Height = 0
        'Else
        'pnlAllEmpInfo.Height = 28
        'End If

    End Sub

    Private Sub cmdScroll_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrollToggle.MouseHover
        cmdScroll_Click(sender, e)
    End Sub

    Private Sub dgvAllEmp_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellClick
        'StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value)
        'pb_ShowEmployee(StrEmployeeID)
    End Sub

    Private Sub dgvAllEmp_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellDoubleClick
        pnlMostRLeft.Width = 0
        pnlEditHistory.Height = 0

        If strClickedEmp = "cmdEmployee" Then
            cmdEmployee_Click(sender, e)
        ElseIf strClickedEmp = "cmdLeve" Then
            cmdLeve_Click(sender, e)
        ElseIf strClickedEmp = "cmdShifts" Then
            cmdShifts_Click(sender, e)
        ElseIf strClickedEmp = "cmdAttns" Then
            cmdAttns_Click(sender, e)
        ElseIf strClickedEmp = "cmdAddress" Then
            cmdAddress_Click(sender, e)
        ElseIf strClickedEmp = "cmdCardData" Then
            cmdCardData_Click(sender, e)
        ElseIf strClickedEmp = "cmdFamilly" Then
            cmdFamily_Click(sender, e)
        ElseIf strClickedEmp = "cmdTraining" Then
            cmdTraining_Click(sender, e)
        End If
    End Sub

    Private Sub txtEmpNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpNo.Leave
        lblName.Text = StrDispName
        lblBranchtop.Text = "Branch : " & cmbBranch.Text
        lblDesignation.Text = "Designation : " & cmbDesignation.Text
        lblEmpNumb.Text = "Emp No : " & txtEmpNo.Text
    End Sub

    Private Sub dgvAllEmp_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellEndEdit

    End Sub

    Private Sub dgvAllEmp_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllEmp.CellEnter
        Try
            If bolIsLoad = False Then
                If StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value) Then Exit Try
                StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value)
                pb_ShowEmployee(StrEmployeeID)
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub dgvAllEmp_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvAllEmp.RowPrePaint

    'Try
    '    If StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value) Then Exit Try
    '    StrEmployeeID = Trim(dgvAllEmp.Item(0, dgvAllEmp.CurrentRow.Index).Value)
    '    pb_ShowEmployee(StrEmployeeID)
    'Catch ex As Exception

    'End Try
    'End Sub

    Private Sub rdbCancel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCancel.Click
        ViewEmployee()
    End Sub

    Private Sub rdbActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbActive.Click
        ViewEmployee()
    End Sub

    Private Sub dtpToDate_ValueChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpToDate.ValueChanged
        DtpTodateValueChanged()
    End Sub


    Private Sub btnScrollEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScrollEmp.Click
        If pnlMostRLeft.Width = 357 Then
            pnlMostRLeft.Width = 0
        Else
            ViewEmployee()
        End If

        'If pnlEditHistory.Height = 244 Then
        pnlEditHistory.Height = 0
        'Else
        'pnlAllEmpInfo.Height = 28
        'End If
    End Sub

    Private Sub btnScrollEmp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnScrollEmp.MouseEnter
        'btnScrollEmp_Click(sender, e)
    End Sub

    Private Sub PictureBox20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox20.Click

        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetDesignation
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()

    End Sub

    Private Sub PictureBox23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox23.Click
        LoadForm(New frmSetCivilSt)
        'Civil Status
        ListCombo(cmbCivilSt, "SELECT * FROM tblCivilStatus WHERE Status =  0 Order By StID", "StDesc")
    End Sub

    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetCBranchs
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
        ''
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetDepartment
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetCategory
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        pnlMostRLeft.Width = 658
        pnlEditHistory.Height = 478
        pnlMostRLeft.Visible = True

        Me.pnlEditHistory.Controls.Clear()
        Dim frmReg As New frmSetEmpTypes
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlEditHistory.Controls.Add(frmReg)

        frmReg.Show()
    End Sub

    Private Sub btnRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotate.Click
        'If picEmpProfil IsNot Nothing Then
        '    picEmpProfil.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        '    picEmpProfil.Image = picEmpProfil.Image
        'End If
        LoadForm(New transpPrivewForm)
        'picEmpProfil.BackgroundImage = picEmpProfil.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        LoadForm(AutoEmail)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btn1DashBd_MouseEnter(sender As Object, e As EventArgs)
        pnlLeft.Width = 177
        pnlLeftSeperator.Width = 167
    End Sub

    Private Sub btn1DashBd_MouseLeave(sender As Object, e As EventArgs)
        pnlLeft.Width = 62
        pnlLeftSeperator.Width = 52
    End Sub

    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles Button8.MouseEnter, Button12.MouseEnter, Button11.MouseEnter, btnServiceChrge.MouseEnter, btnReqDeduction.MouseEnter, btn9Comp.MouseEnter, btn8Calender.MouseEnter, BTN6Leav.MouseEnter, btn4DailyAt.MouseEnter, btn3HRM.MouseEnter, btn2EmpProfile.MouseEnter, btn1DashBd.MouseEnter, btn13AnalyisData.MouseEnter, btn12Setting.MouseEnter, btn11Report.MouseEnter, btn10Payrol.MouseEnter
        pnlLeft.Width = 177
        pnlLeftSeperator.Width = 167
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave, Button12.MouseLeave, Button11.MouseLeave, btnServiceChrge.MouseLeave, btnReqDeduction.MouseLeave, btn9Comp.MouseLeave, btn8Calender.MouseLeave, BTN6Leav.MouseLeave, btn4DailyAt.MouseLeave, btn3HRM.MouseLeave, btn2EmpProfile.MouseLeave, btn1DashBd.MouseLeave, btn13AnalyisData.MouseLeave, btn12Setting.MouseLeave, btn11Report.MouseLeave, btn10Payrol.MouseLeave
        pnlLeft.Width = 62
        pnlLeftSeperator.Width = 52
    End Sub

    Private Sub btn12Setting_Click_1(sender As Object, e As EventArgs) Handles btn12Setting.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New AbsentAnalysis
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "HRM"
        ButtonClicked()
    End Sub

    Private Sub btn13AnalyisData_Click_1(sender As Object, e As EventArgs) Handles btn13AnalyisData.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmAttendanceDashBoard1
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "AnalysisData"
        ButtonClicked()
        'If UP("Main Screen", "Allow to view data download screen") = False Then btn3HRM.Enabled = False : Exit Sub

    End Sub

    Private Sub btn9Comp_Click_1(sender As Object, e As EventArgs) Handles btn9Comp.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmCompanyProfile
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "Company"
        ButtonClicked()
    End Sub

    Private Sub btn11Report_Click_1(sender As Object, e As EventArgs) Handles btn11Report.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmReportViewer
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "Report"
        ButtonClicked()
    End Sub

    Private Sub BTN6Leav_Click_1(sender As Object, e As EventArgs) Handles BTN6Leav.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmApplyLeavdatra
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "Leave"
        ButtonClicked()
    End Sub

    Private Sub btn8Calender_Click_1(sender As Object, e As EventArgs) Handles btn8Calender.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmShiftAsgn
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Normal

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "Calender"
        ButtonClicked()
    End Sub

    Private Sub btn10Payrol_Click_1(sender As Object, e As EventArgs) Handles btn10Payrol.Click

    End Sub

    Private Sub btn1DashBd_Click_1(sender As Object, e As EventArgs) Handles btn1DashBd.Click
        tbMain.SelectedIndex = 0
        tbMain_SelectedIndexChanged(sender, e)
        strClicked = "Dashboard"
        ButtonClicked()
    End Sub

    Private Sub btn2EmpProfile_Click_1(sender As Object, e As EventArgs) Handles btn2EmpProfile.Click
        tbMain.SelectedIndex = 1
        tbMain_SelectedIndexChanged(sender, e)

        ' ''If UP("Main Screen", "Allow to view employee profile") = False Then btn2EmpProfile.Enabled = False : Exit Sub
        ''Me.pnlAllDynamic.Controls.Clear()
        ''Dim frmReg As New frmEmployeeInfo
        ''frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        ' ''frmReg.WindowState = FormWindowState.Maximized

        ' ''frmReg.TopLevel = False
        ' ''Me.Location = New Point(0, 0)
        ' ''Me.pnlAllDynamic.Controls.Add(frmReg)

        ''frmReg.ShowDialog()
        strClicked = "EmployeeProfile"
        ButtonClicked()
    End Sub

    Private Sub btnServiceChrge_Click(sender As Object, e As EventArgs) Handles btnServiceChrge.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmBankFileGeneratork
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "AnalysisData"
        ButtonClicked()
    End Sub

    Private Sub frmMainAttendance_Enter(sender As Object, e As EventArgs) Handles Me.Enter

    End Sub

    Private Sub frmMainAttendance_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter

    End Sub

    Private Sub btn4DailyAt_Click_1(sender As Object, e As EventArgs) Handles btn4DailyAt.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmAttendanceManager
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmPayWorkingAllowances
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
    End Sub

    Private Sub btnReqDeduction_Click(sender As Object, e As EventArgs) Handles btnReqDeduction.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmEmpReDeductions
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmPayslipprocessold
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New frmEPFReport
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.pnlAllDynamic.Controls.Clear()
        Dim frmReg As New FrmPayETF
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.Location = New Point(0, 0)
        Me.pnlAllDynamic.Controls.Add(frmReg)

        frmReg.Show()
        strClicked = "DailyAttendance"
        ButtonClicked()
    End Sub
End Class
