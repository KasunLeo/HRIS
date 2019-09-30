Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Windows.Forms.DataVisualization.Charting

Module mod_ConnectionAt
    Public StrLincens As String

    Public intIsBOTAccept As Integer = 0
    Public intBaseOnClockRecord As Integer = 0

    Public StrFile As String = Application.StartupPath & "\gender.dat"
    Public StrPw As String
    Public StrUs As String
    Public StrDs As String
    Public StrCompID As String
    Public intIsExit As Integer = 0
    Public StrLocationID As String
    Public dtLockDate As Date = DateSerial(2013, 1, 15)
    Public StrLeavSearchID As String
    Public StrSelectShift As String
    Public StrReportID As String

    Public mac_Address As String
    Public sqlConString As String
    Public dbSqlCon As New SqlConnection
    Public dtWorkingDate As Date
    Public intMinWorkMin As Integer = 60
    Public StrSelDayTypeID As String = ""
    Public strReActEmp As String = ""
    Public StrSearchText As String = ""

    Public intFormX As Integer
    Public intFormY As Integer
    Public intRegMode As Integer
    Public sUserName, sPassword, sServer, sDatabase As String
    Public bolLicenced As Boolean = False
    Public intTotalDevice As Integer = 1
    Public dtpExDat As New DateTimePicker
    Public strAllMachine As String = ""
    Public strDownlodform As String = ""
    Public intDownloadFromFile As Integer = 0
    Public strPanelImage As String = ""
    Public strMouseEnter As String = ""
    Public strMouseLeave As String = ""
    Public strPBEnter As String = ""
    Public strPBLeave As String = ""
    Public strThemeID As String = ""
    Public clrFocused As Color = Color.White
    Public strColorName As String = "White"
    Public strChartPath As String = Application.StartupPath & "\chartBack.jpg"
    Public strChartTypeDounut As SeriesChartType = 18
    Public strChartTypeBar As SeriesChartType = 16
    Public strStrech As String = "0"
    Public intIsDispMinutes As Integer = 0
    Public strKBranchID As String = ""
    Public intIsUserViewLevel As Integer = 0
    Public IntIsPayrolDataEnabled As Integer = 0
    Public intIsRosterEnabled, intIsDayTypeConfig, intIsNightPickEnabled, intIsContractPeriod As Integer
    Public intIsOTApprove, intIsResignScreen, intisWeekShed, intIsNewRoster, intisDeleteShift, intIsMonthlyOT As Integer
    Public intDaySeperateOT As Integer
    Public strReportBased As String = ""
    Public strQuery As String = ""
    Public isLimitSalAdvanced As Integer = 0
    Public SalAdvancedID As String = "01"
    Public cBusiness As String = "BBH"
    Public cAddress As String
    Public strPrCategory As String
    Public isWithLogo As Integer
    Public intPrcdMonth As Integer
    Public rName As String
    Public isViewBasic As Integer
    Public dtReportDate As DateTime
    Public dtReportDate2 As DateTime
    Public strDispCompany As String
    Public intCMonth As Integer
    Public intCyear As Integer
    Public intIsSpecialAllowance As Integer
    Public intRoundSalary As Integer
    Public isWithSignature As Integer
    Public isRoundBudget As Integer
    Public isRequestDeduct As Integer
    Public strDefaultPageSize As String
    Public bolSelectBranch As Boolean = False
    Public strDispComAddress As String
    Public isSeperateBranch As Integer
    Public bolUnAssignedFormula As Boolean = False
    Public IsEnableExtendedLoan As Integer = 0
    Public isCheckEmpCountOfBoth As Integer = 0
    Public isServiceCharge As Integer = 0
    Public isDeleteNetSalryBank As Integer = 0

    Public Function ConnecttoDataBase() As Boolean

        ConnecttoDataBase = False

        sServer = ReadKey("HRTime\SQLServer")
        sDatabase = ReadKey("HRTime\SQLDatabase")
        sUserName = ReadKey("HRTime\UserName")
        sPassword = ReadKey("HRTime\Password")

        sServer = CNT(sServer)
        sDatabase = CNT(sDatabase)
        sUserName = CNT(sUserName)
        sPassword = CNT(sPassword)

        If sServer = "" Or sDatabase = "" Or sUserName = "" Or sPassword = "" Then frmSetDatabaseSetup.ShowDialog()

        Try
            'Dim objReader As New StreamReader(StrFile)
            'StrLincens = objReader.ReadLine
            'StrPw = objReader.ReadLine
            'StrUs = objReader.ReadLine
            'StrDs = objReader.ReadLine

            StrLocationID = StrCompID

            mac_Address = fk_GetMacAddress()

            'Dim DBPath As String = Application.StartupPath
            'DBPath = DBPath '+ "\" + sDatabase
            'Dim DataSource As String = ".\SQLEXPRESS"
            Dim intLogMeth As Integer = 1
            Select Case intLogMeth
                Case 0
                    sqlConString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=" & sDatabase & ";Data Source=" & sServer & ";"

                Case 1
                    sqlConString = "Password= " & sPassword & ";Persist Security Info=True;User ID=" & sUserName & ";Initial Catalog=" & sDatabase & ";Data Source= " & sServer & ";"
            End Select

            'sqlConString = "Data Source=" & DataSource & ";AttachDbFilename=" & DBPath & "\AttendanceDB.mdf;Integrated Security=True;User Instance=True"
            'sqlConString = "Password= 'HRIS#123';Persist Security Info=True;User ID='sa';Initial Catalog=EK_Attendace;Data Source= 'localhost';TimeOut=12000"

            If dbSqlCon.State = ConnectionState.Open Then
                dbSqlCon.Close()
            End If

            dbSqlCon.ConnectionString = sqlConString
            dbSqlCon.Open()

            'Open Current Time
            Dim cnDate As New SqlConnection(sqlConString)
            cnDate.Open()

            Dim strQry As String = "CREATE TABLE [dbo].[tblCompany](" &
 " [CompID] [nvarchar](3)  NULL," &
 " [cName] [nvarchar](100)  NULL," &
 " [Add1] [nvarchar](30)  NULL," &
 " [Add2] [nvarchar](30)  NULL," &
 " [Add3] [nvarchar](30)  NULL," &
 " [Phone1] [nvarchar](12)  NULL," &
 " [Phone2] [nvarchar](12)  NULL," &
 " [Fax] [nvarchar](12)  NULL," &
 " [Email] [nvarchar](30)  NULL," &
 " [cPerson] [nvarchar](30)  NULL," &
 " [NoEmps] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [Nodept] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [NoReqst] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [EpfRegNo] [nvarchar](10)  NULL," &
 " [Status] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [noBrs] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [NoDevice] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [NoShifts] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [NoUlv] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [NoUsers] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [NoAplLv] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [AtnPrcDate] [datetime] NULL," &
 " [BackPath] [nvarchar](100)  NOT NULL DEFAULT ('')," &
 " [NoRoster] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [cYear] [numeric](18, 0) NOT NULL DEFAULT ((2011))," &
 " [cMonth] [numeric](18, 0) NOT NULL DEFAULT ((12))," &
 " [OTRound] [numeric](18, 0) NOT NULL DEFAULT ((1))," &
 " [Latemin] [numeric](18, 2) NOT NULL DEFAULT ((0))," &
 " [SRBase] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [OTAccept] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [BeginOT] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [EndOT] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [MinHrsOT] [numeric](18, 0) NOT NULL DEFAULT ((1))," &
 " [OTRndOption] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [StartDay] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
 " [IsEpf] [numeric](18, 0) NOT NULL DEFAULT ((0))," &
" LvCancel numeric (18,0) not null default 0" &
" ) ON [PRIMARY]"
            'fk_CreateTableR(strQry, "tblCompany")

            Dim sqlDate As String = "SELECT GetDate()"
            Dim sqlyear As String = "Select datepart(year,getdate())"
            Dim strYrchk As String = "select cyear from tblcompany"
            Dim intChkYr As Integer
            Dim intYearR As Integer = 0
            Try
                Dim cmDate As New SqlCommand(sqlDate, cnDate)
                Dim drDate As SqlDataReader = cmDate.ExecuteReader
                If drDate.Read = True Then
                    dtWorkingDate = IIf(IsDBNull(drDate.Item(0)), DateSerial(1900, 1, 1), drDate.Item(0))
                End If
                drDate.Close()

                Dim cmDate1 As New SqlCommand(sqlyear, cnDate)
                Dim drDate1 As SqlDataReader = cmDate1.ExecuteReader
                If drDate1.Read = True Then
                    intYearR = IIf(IsDBNull(drDate1.Item(0)), 0, drDate1.Item(0))
                End If
                drDate1.Close()

                Dim cmDateChk As New SqlCommand(strYrchk, cnDate)
                Dim drChkYr As SqlDataReader = cmDateChk.ExecuteReader
                If drChkYr.Read = True Then
                    intChkYr = IIf(IsDBNull(drChkYr.Item(0)), 0, drChkYr.Item(0))
                End If
                drChkYr.Close()

                Dim sqlQry As String = "insert into tblCompany (compid,cyear,AtnPrcDate) values ('" & StrCompID & "','2010','1/1/1900')"
                If intChkYr = Nothing Then
                    Dim cmSetYear As New SqlCommand(sqlQry, cnDate)
                    cmSetYear.ExecuteNonQuery()
                End If

                If intChkYr = Nothing Or intYearR <> intChkYr Then
                    If DialogResult.OK = MessageBox.Show("The server year or the CURRENT YEAR has changed from " & intChkYr & " to " & intYearR & " . Are you sure to contiue? ", "Confirmation!", MessageBoxButtons.OKCancel) Then
                        sqlQry = "update tblCompany set cyear=" & intYearR & " where compid='" & StrCompID & "'"

                        Dim cmSetYear As New SqlCommand(sqlQry, cnDate)
                        cmSetYear.ExecuteNonQuery()
                        MsgBox("The current year of the system has changed from " & intChkYr & " to " & intYearR & "")
                    Else
                        MsgBox("Please Check the system year. For more information contact system administrator.")
                        'intIsExit = 1

                    End If

                End If

                'intCurrentYear = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE compID = '" & StrCompID & "'")
                intCurrentYear = fk_RetString("SELECT cYear FROM tblCompany WHERE CompID = '" & StrCompID & "'")

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnDate.Close()
            End Try

            IsMealAvbl = 0
            Dim s As String
            'Open Control Table 
            s = "SELECT RemEarly,CalLateEarly FROM tblControl"
            fk_Return_MultyString(s, 2)
            intOtCalMeth = fk_ReadGRID(0)
        Catch ex As Exception
            'MessageBox.Show(ex.ToString())
            MessageBox.Show("Database is offline, Please contact your system administrator", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : End
            End
        End Try

    End Function

    Public Sub fk_ChangeGRIDColor(ByVal dgv As DataGridView)
        Dim intVal As Integer = 0
        With dgv
            For iRow As Integer = 0 To .RowCount - 1
                For iCol As Integer = 0 To .ColumnCount - 1
                    If iRow Mod 2 = 1 Then .Item(iCol, iRow).Style.BackColor = Color.LightGray Else .Item(iCol, iRow).Style.BackColor = Color.White
                Next
            Next
        End With
    End Sub

    Public Function fk_GetMacAddress() As String
        Dim StrHost As String
        Dim mcAdd As String = ""
        Dim nMac As String = ""
        Try
            Dim nic As NetworkInterface = Nothing
            StrHost = System.Net.Dns.GetHostName.ToString
            Dim myIPs() As System.Net.IPAddress = System.Net.Dns.GetHostAddresses(StrHost)
            For Each nic In NetworkInterface.GetAllNetworkInterfaces
                If nic.OperationalStatus = OperationalStatus.Up Then
                    nMac = nic.GetPhysicalAddress().ToString
                End If
                If nMac <> "" And nMac.Length = 12 Then
                    mcAdd = nMac
                End If
            Next
            nic = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return mcAdd
    End Function

    Public Sub Load_InformationtoGrid(ByVal sqlQ As String, ByVal grid As DataGridView, ByVal cols As Integer)
        grid.Rows.Clear()
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("xx", "Head")
        End With
        Dim iCol As Integer
        Dim cnPop As New SqlConnection(sqlConString)
        cnPop.Open()
        Try
            Dim cmPop As New SqlCommand(sqlQ, cnPop)
            cmPop.CommandTimeout = 0
            Dim drPop As SqlDataReader = cmPop.ExecuteReader
            Do While drPop.Read = True
                dgv.Rows.Clear()
                For iCol = 0 To cols - 1
                    Dim StrX As String = IIf(IsDBNull(drPop.Item(iCol)), "", drPop.Item(iCol))
                    dgv.Rows.Add(StrX)
                Next
                ', dgv.Item(0, 3)
                Dim nCol As Integer = cols - 1
                Select Case nCol
                    Case 1
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value)
                    Case 2
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value)
                    Case 3
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value)
                    Case 4
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value)
                    Case 5
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value)
                    Case 6
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value)
                    Case 7
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value)
                    Case 8
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value)
                    Case 9
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value)
                    Case 10
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value)
                    Case 11
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value)
                    Case 12
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value)
                    Case 13
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value)
                    Case 14
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value)
                    Case 15
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value)
                    Case 16
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value)
                    Case 17
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value)
                    Case 18
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value)
                    Case 19
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value)
                    Case 20
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value)
                    Case 21
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value)
                    Case 22
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value)
                    Case 23
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value)
                    Case 24
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value)
                    Case 25
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value)
                    Case 26
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value)
                    Case 27
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value)
                    Case 28
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value)
                    Case 29
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value)
                    Case 30
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value)
                    Case 31
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value)
                    Case 32
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value)
                    Case 33
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value)
                    Case 34
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value)
                    Case 35
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value)
                    Case 36
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value)
                    Case 37
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value)
                    Case 38
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value)
                    Case 39
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value)
                    Case 40
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value)
                    Case 41
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value)
                    Case 42
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value)
                    Case 43
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value)
                    Case 44
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value)
                    Case 45
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value)
                    Case 46
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value)
                    Case 47
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value)
                    Case 48
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value)
                    Case 49
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value)
                    Case 50
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value)
                    Case 51
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value)
                    Case 52
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value)
                    Case 53
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value)
                    Case 54
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value)
                    Case 55
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value)
                    Case 56
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value)
                    Case 57
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value)
                    Case 58
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value)
                    Case 59
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value)
                    Case 60
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value, dgv.Item(0, 60).Value)
                    Case 61
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value, dgv.Item(0, 60).Value, dgv.Item(0, 61).Value)


                End Select
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnPop.Close()
        End Try
    End Sub

    Public Sub clr_Grid(ByVal dgv As DataGridView)

        With dgv
            For Each row As DataGridViewRow In .Rows
                If row.Index Mod 2 = 0 Then row.DefaultCellStyle.BackColor = Color.Gainsboro Else row.DefaultCellStyle.BackColor = Color.White
            Next
        End With

    End Sub

    Public Sub Load_InformationtoGridNoClr(ByVal sqlQ As String, ByVal grid As DataGridView, ByVal cols As Integer)

        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("xx", "Head")
        End With
        Dim iCol As Integer
        Dim cnPop As New SqlConnection(sqlConString)
        cnPop.Open()
        Try
            Dim cmPop As New SqlCommand(sqlQ, cnPop)
            Dim drPop As SqlDataReader = cmPop.ExecuteReader
            Do While drPop.Read = True
                dgv.Rows.Clear()
                For iCol = 0 To cols - 1
                    Dim StrX As String = IIf(IsDBNull(drPop.Item(iCol)), "", drPop.Item(iCol))
                    dgv.Rows.Add(StrX)
                Next
                ', dgv.Item(0, 3)
                Dim nCol As Integer = cols - 1
                Select Case nCol
                    Case 1
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value)
                    Case 2
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value)
                    Case 3
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value)
                    Case 4
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value)
                    Case 5
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value)
                    Case 6
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value)
                    Case 7
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value)
                    Case 8
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value)
                    Case 9
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value)
                    Case 10
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value)
                    Case 11
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value)
                    Case 12
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value)
                    Case 13
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value)
                    Case 14
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value)
                    Case 15
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value)
                    Case 16
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value)

                End Select
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnPop.Close()
        End Try
    End Sub

    Public Sub Fk_FillGrid(ByVal strSQLQuery As String, ByVal DataGridViewName As DataGridView)
        Dim CN As New SqlConnection(sqlConString)
        Dim sBol As Boolean = False
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(strSQLQuery, CN)
            ADP.Fill(sTable)
            DataGridViewName.DataSource = sTable.Tables(0)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
    End Sub

    Public Function FK_GetMacID(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                Dim X, Y, Z As Integer
                Y = Len(sString)
                X = 1
                While X < Y
                    If Mid(sString, Y - X, 1) = "_" Then
                        Z = X
                        Exit While
                    End If
                    X += 1
                End While

                sRetString = Left(sString, Y - (Z + 1))
                sRetString = Right(sRetString, 4)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Function FK_GetLeftFromSpace(ByVal sString As String)
        'Dim sRetString As String = ""
        'Try
        '    If Len(sString) > 1 Then
        '        Dim X, Y, Z As Integer
        '        Y = Len(sString)
        '        X = 1
        '        While X < Y
        '            If Mid(sString, Y - X, 1) = "" Then
        '                Z = X
        '                Exit While
        '            End If
        '            X += 1
        '        End While

        '        sRetString = Left(sString, Z)
        '        sRetString = Left(sRetString, 4)
        '    End If
        'Catch ex As Exception
        ''    MsgBox(ex.Message)
        'End Try
        'Return sRetString
    End Function

    Public Function FK_GetIDR(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                Dim X, Y, Z As Integer
                Y = Len(sString)
                X = 1
                While X < Y
                    If Mid(sString, Y - X, 1) = "=" Then
                        Z = X
                        Exit While
                    End If
                    X += 1
                End While
                sRetString = Right(sString, Z)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Function FK_GetIDRDot(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                Dim X, Y, Z As Integer
                Y = Len(sString)
                X = 1
                While X < Y
                    If Mid(sString, Y - X, 1) = "." Then
                        Z = X
                        Exit While
                    End If
                    X += 1
                End While
                sRetString = Right(sString, Z)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Function UP(ByVal sLocation As String, ByVal sEvent As String) As Boolean
        ''FK_EQ("CREATE TABLE [dbo].[tblUserPermissionD](	[LOC] [nvarchar](200)  NULL,	[EVNT] [nvarchar](200)  NULL	) ON [PRIMARY]", "P", False, False, False)
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
            Else
                sValue = 9999
                'SAVE DATA
                Dim CN1 As New SqlConnection(sqlConString)
                CN1.Open()
                Dim sqlCMD As SqlCommand
                sqlCMD = CN1.CreateCommand
                sqlCMD.CommandText = "INSERT INTO tblUserPermissionA VALUES('" & sLocation & "','" & sEvent & "','9999')"
                sqlCMD.ExecuteNonQuery()
                If fk_CheckEx("Select * from tblUserPermissionDA where Loc='" & sLocation & "' and Evnt='" & sEvent & "'") = False Then
                    FK_EQ("Insert into tblUserPermissionDA Values ('" & sLocation & "','" & sEvent & "') ", "S", "", False, False, True)
                End If

                'SAVE DATA
            End If
            If sValue <= UserVal Then Return True Else MsgBox(" Sorry ! .  Access is Denied   !.  ", MsgBoxStyle.Information, "HRIS Business Solutions..") : Exit Function
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        CN.Close()
    End Function

    Public Sub FillComboPay(ByVal srcComboBox As ComboBox, ByVal srcSqlString As String)
        srcComboBox.Items.Clear()
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim sqlcombo_department As New SqlCommand(srcSqlString, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()

            While redcombo_department.Read()
                srcComboBox.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        'Return com_items.Items.Add
    End Sub

    Public Sub cleanInput(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim str As String = e.KeyChar
        Dim x As Integer
        Dim str1 As String = "<>?;:'#~]}[{=+)(*&^%$£!`¬|-_/,."""
        For x = 1 To Len(str1)
            If str.Contains(Microsoft.VisualBasic.Mid(str1, x, 1)) Then
                e.Handled = True
                Return
            End If
        Next
        e.Handled = False
    End Sub

    Public Function GetMultiVal(ByVal sSQL As String, ByVal sListbox As ListBox, ByVal sNoofItems As Double) As Boolean
        Dim sBOl As Boolean = False
        Try
            Dim CN As New SqlConnection(sqlConString)

            CN.Open()
            sListbox.Items.Clear()
            Dim CMD As New SqlCommand(sSQL, CN)
            Dim Rd As SqlDataReader = CMD.ExecuteReader()
            If Rd.HasRows = True Then
                sBOl = True
                While Rd.Read

                    For X As Integer = 0 To sNoofItems - 1
                        Dim str As String
                        str = IIf(IsDBNull(Rd.Item(X)), "", Rd.Item(X))
                        sListbox.Items.Add(str)
                    Next

                End While
            Else
                sBOl = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return sBOl
    End Function

    Public Sub wait(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Public Function FK_GetID(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                Dim X, Y, Z As Integer
                Y = Len(sString)
                X = 1
                While X < Y
                    If Mid(sString, Y - X, 1) = "-" Then
                        Z = X
                        Exit While
                    End If
                    X += 1
                End While
                sRetString = Right(sString, Z)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Function FK_GetIDL(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                For X As Integer = 1 To Len(sString)
                    If Mid(sString, X, 1) = "=" Then
                        sRetString = Left(sString, X - 1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Function FK_GetIDLDot(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                For X As Integer = 1 To Len(sString)
                    If Mid(sString, X, 1) = "." Then
                        sRetString = Left(sString, X - 1)
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Function FK_GetIDDot(ByVal sString As String)
        Dim sRetString As String = ""
        Try
            If Len(sString) > 1 Then
                Dim X, Y, Z As Integer
                Y = Len(sString)
                X = 1
                While X < Y
                    If Mid(sString, Y - X, 1) = "." Then
                        Z = X
                        Exit While
                    End If
                    X += 1
                End While
                sRetString = Right(sString, Z)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sRetString
    End Function

    Public Sub FK_LoadGrid(ByVal sqlq As String, ByVal grid As DataGridView)
        grid.Rows.Clear()
        Dim cols As Integer
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("xx", "head")
        End With
        Dim icol As Integer
        Dim cnpop As New SqlConnection(sqlConString)
        cnpop.Open()
        Try
            Dim cmpop As New SqlCommand(sqlq, cnpop)
            Dim drpop As SqlDataReader = cmpop.ExecuteReader
            cols = drpop.FieldCount
            Do While drpop.Read = True
                dgv.Rows.Clear()
                For icol = 0 To cols - 1
                    Dim strx As String = IIf(IsDBNull(drpop.Item(icol)), "", drpop.Item(icol))
                    dgv.Rows.Add(strx)
                Next
                ', dgv.item(0, 3)
                Dim ncol As Integer = cols - 1
                Select Case ncol
                    Case 0
                        grid.Rows.Add(dgv.Item(0, 0).Value)
                    Case 1
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value)
                    Case 2
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value)
                    Case 3
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value)
                    Case 4
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value)
                    Case 5
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value)
                    Case 6
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value)
                    Case 7
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value)
                    Case 8
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value)
                    Case 9
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value)
                    Case 10
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value)
                    Case 11
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value)
                    Case 12
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value)
                    Case 13
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value)
                    Case 14
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value)
                    Case 15
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value)
                    Case 16
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value)
                    Case 17
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value)
                    Case 18
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value)
                    Case 19
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value)
                    Case 20
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value)
                    Case 21
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value)
                    Case 22
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value)
                    Case 23
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value)
                    Case 24
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value)
                    Case 25
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value)
                    Case 26
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value)
                    Case 27
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value)
                    Case 28
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value)
                    Case 29
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value)
                    Case 30
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value)
                    Case 31
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value)
                    Case 32
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value)
                    Case 33
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value)
                    Case 34
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value)
                    Case 35
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value)
                    Case 36
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value)
                    Case 37
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value)



                End Select
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnpop.Close()
        End Try

    End Sub

    Public Sub FillComboAll(ByVal srcComboBox As ComboBox, ByVal srcSqlString As String)
        srcComboBox.Items.Clear()
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim sqlcombo_department As New SqlCommand(srcSqlString, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            srcComboBox.Items.Add("[ALL]")
            While redcombo_department.Read()
                srcComboBox.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            'srcComboBox.SelectedIndex = 0
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        'Return com_items.Items.Add
    End Sub

    Public Function EQ(ByVal SQLString As String) As Boolean
        If SQLString = "" Then Exit Function

        Dim cnSave As New SqlConnection(sqlConString)
        Dim cmSave As New SqlCommand
        Dim trSave As SqlTransaction
        Dim strStatus As Boolean = False
        Try
            cnSave.Open()
            'trSave = cnSave.BeginTransaction
            cmSave = cnSave.CreateCommand
            'cmSave.Transaction = trSave
            Dim sqlQRY As String = SQLString
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            trSave.Commit()
            strStatus = (True)

        Catch ex As Exception
            'trSave.Rollback()
            strStatus = False
            Console.WriteLine(ex.Message)

        Finally
            cnSave.Close()
            cmSave.Dispose()
            EQ = strStatus
        End Try
    End Function

    Public Function CNT(ByVal Password As String) As String
        'Procedure Pass 
        'text=cpt(text)
        Dim pw As Integer
        Dim code As String
        Dim bit As String
        Dim pass As String = ""
        For pw = 1 To Len(Password)
            code = Mid(Password, pw, 1)
            bit = Chr(Asc(code) - 13)
            pass = pass + bit
        Next pw
        CNT = pass
    End Function

    Public Function CPT(ByVal Password As String) As String
        'Procedure Pass 
        'text=cpt(text)
        Dim pw As Integer
        Dim code As String
        Dim bit As String
        Dim pass As String = ""
        For pw = 1 To Len(Password)
            code = Mid(Password, pw, 1)
            bit = Chr(Asc(code) + 13)
            pass = pass + bit
        Next pw
        CPT = pass

    End Function

    Public Sub Load_InformationtoGridFromRemote(ByVal sqlQ As String, ByVal grid As DataGridView, ByVal cols As Integer)
        grid.Rows.Clear()
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("xx", "Head")
        End With
        Dim iCol As Integer
        Dim cnPop As New SqlConnection(sqlConStringRemote)
        cnPop.Open()
        Try
            Dim cmPop As New SqlCommand(sqlQ, cnPop)
            cmPop.CommandTimeout = 0
            Dim drPop As SqlDataReader = cmPop.ExecuteReader
            Do While drPop.Read = True
                dgv.Rows.Clear()
                For iCol = 0 To cols - 1
                    Dim StrX As String = IIf(IsDBNull(drPop.Item(iCol)), "", drPop.Item(iCol))
                    dgv.Rows.Add(StrX)
                Next
                ', dgv.Item(0, 3)
                Dim nCol As Integer = cols - 1
                Select Case nCol
                    Case 1
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value)
                    Case 2
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value)
                    Case 3
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value)
                    Case 4
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value)
                    Case 5
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value)
                    Case 6
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value)
                    Case 7
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value)
                    Case 8
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value)
                    Case 9
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value)
                    Case 10
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value)
                    Case 11
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value)
                    Case 12
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value)
                    Case 13
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value)
                    Case 14
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value)
                    Case 15
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value)
                    Case 16
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value)
                    Case 17
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value)
                    Case 18
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value)
                    Case 19
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value)
                    Case 20
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value)
                    Case 21
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value)
                    Case 22
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value)
                    Case 23
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value)
                    Case 24
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value)
                    Case 25
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value)
                    Case 26
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value)
                    Case 27
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value)
                    Case 28
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value)
                    Case 29
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value)
                    Case 30
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value)
                    Case 31
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value)
                    Case 32
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value)
                    Case 33
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value)
                    Case 34
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value)
                    Case 35
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value)
                    Case 36
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value)
                    Case 37
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value)
                    Case 38
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value)
                    Case 39
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value)
                    Case 40
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value)
                    Case 41
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value)
                    Case 42
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value)
                    Case 43
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value)
                    Case 44
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value)
                    Case 45
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value)
                    Case 46
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value)
                    Case 47
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value)
                    Case 48
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value)
                    Case 49
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value)
                    Case 50
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value)
                    Case 51
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value)
                    Case 52
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value)
                    Case 53
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value)
                    Case 54
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value)
                    Case 55
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value)
                    Case 56
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value)
                    Case 57
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value)
                    Case 58
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value)
                    Case 59
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value)
                    Case 60
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value, dgv.Item(0, 60).Value)
                    Case 61
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value, dgv.Item(0, 60).Value, dgv.Item(0, 61).Value)


                End Select
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnPop.Close()
        End Try
    End Sub
End Module
