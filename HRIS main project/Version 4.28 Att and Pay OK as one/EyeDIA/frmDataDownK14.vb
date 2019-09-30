Imports System.Data.SqlClient
Imports System.IO

Public Class frmDataDownLzk14
    Public axCZKEM1 As New zkemkeeper.CZKEM
    Dim StrDivNo As String

    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    Dim StrOFile As String = "D/"
    ''Dim intControlV As Integer = 0
    Dim intFromServer As Integer = 0

    Dim bIsCon As Boolean = False

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click

        If txtIP.Text.Trim() = "" Or txtPort.Text.Trim() = "" Then
            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If cmdConnect.Text = "Disconnect" Then
            axCZKEM1.Disconnect()
            bIsConnected = False
            cmdConnect.Text = "Connect"
            lblState.Text = "Current State : Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = axCZKEM1.Connect_Net(txtIP.Text.Trim(), Convert.ToInt32(txtPort.Text.Trim()))
        If bIsConnected = True Then
            cmdConnect.Text = "Disconnect"
            cmdConnect.Refresh()
            lblState.Text = "Current State : Connected"
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            Button3_Click(sender, e)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub connetToRemoteServerNow()
        Me.Cursor = Cursors.WaitCursor
        If sqlRemotConStatus = "Current State : Connected to Server" Then
            If dbSqlConR.State = ConnectionState.Open Then
                dbSqlConR.Close()
                sqlRemotConStatus = "Current State : Not Connected to Server"
                lblServerTest.Text = sqlRemotConStatus
                Me.Cursor = Cursors.Default
                bIsCon = False
                Exit Sub
            End If
        End If
        'ConnectToRemoteServer()
        txtServer.Text = strRemoteServer
        txtDatabase.Text = strRemoteDatabase
        lblServerTest.Text = sqlRemotConStatus
        If sqlRemotConStatus = "Current State : Connected to Server" Then
            bIsCon = True
        Else
            bIsCon = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim crtl As Control
        For Each crtl In Me.GroupBox2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        optDevice_CheckedChanged(sender, e)
        Dim sqlQ As String = "select MachinID,mDesc,IpAddress,Port,'Disconnected',Status From tblDeviceInfo where machinID = '" & strDiv_ID & "' Order By MachinID"
        Load_InformationtoGrid(sqlQ, dgvInfo, 6)
        txtServer.Text = mod_ConnectionAt.CNT(ReadKey("HRTime\RemoteSQLServer"))
        txtDatabase.Text = mod_ConnectionAt.CNT(ReadKey("HRTime\RemoteSQLDatabase"))
    End Sub

    Private Sub dgvInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvInfo.Click
        StrDivNo = dgvInfo.Item(0, dgvInfo.CurrentRow.Index).Value
        'OPen device 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblDeviceInfo WHERE MachinID = '" & StrDivNo & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtIP.Text = IIf(IsDBNull(drShw.Item("IPAddress")), "", drShw.Item("IPAddress"))
                txtPort.Text = IIf(IsDBNull(drShw.Item("Port")), "", drShw.Item("Port"))
                iMachineNumber = IIf(IsDBNull(drShw.Item("DivNo")), "", drShw.Item("DivNo"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
    End Sub

    Private Sub cmdDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownload.Click, Button1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim dtpLastProcessDate As Date : Dim dtpMaximumDate As Date
        'dtpLastProcessDate = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        'dtpLastProcessDate = DateAdd(DateInterval.Day, -1, dtpLastProcessDate)

        If StrDivNo = "" Then MsgBox("Please select the device", MsgBoxStyle.Information)
        Dim dtAtDate As Date = Nothing
        Dim dtAtTime As Date = Nothing
        Dim StrEmp As String = ""
        Dim intMode As Integer = 0

        Dim sdwEnrollNumber As String = ""
        'Dim idwVerifyMode As Integer
        'Dim idwInOutMode As Integer
        'Dim idwYear As Integer
        'Dim idwMonth As Integer
        'Dim idwDay As Integer
        'Dim idwHour As Integer
        'Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer

        Dim idwTMachineNumber As Integer
        Dim idwEnrollNumber As Integer
        Dim idwEMachineNumber As Integer
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwErrorCode As Integer
        Dim idwReserved As Integer
        Dim iGLCount = 0
        Dim lvItem As New ListViewItem("Items", 0)
        pgbUpdate.Minimum = 0
        pgbUpdate.Value = 0
        pgbUpdate.Maximum = 100000

        '########## Get the Last Download data information from the Device Infor Table########
        dtpLastProcessDate = fk_RetDate("SELECT downloadDate FROM tblDeviceInfo WHERE MachinID = '" & StrDivNo & "'")
        dtpLastProcessDate = DateAdd(DateInterval.Day, -1, dtpLastProcessDate)

        If intFromServer = 1 Then
            If bIsCon = False Then
                MsgBox("Please connect to the server first", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            sSQL = "SELECT  row_number() over (order by ttime) as Count,[EmpID],[VrfyMode],[Input], [cDate],[cTime] FROM tblTransferedData WHERE MacID='" & StrDivNo & "'"
            Load_InformationtoGridFromRemote(sSQL, dgvData, 6)
            sqlRemotConStatus = "Total data : " & dgvData.RowCount
            lblServerTest.Text = sqlRemotConStatus
            If dgvData.RowCount <= 0 Then Exit Sub
        Else
            If optDevice.Checked = True Then
                If bIsConnected = False Then
                    MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
                    Return
                End If
                Cursor = Cursors.WaitCursor
                dgvData.Rows.Clear()
                axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
                Dim StrEnrNO As String
                'If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read the records to the memory
                '    'get the records from memory
                '    'While axCZKEM1.GetGeneralExtLogData(iMachineNumber, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode, idwReserved)
                '    '    'iGLCount += 1
                '    '    'lvItem = lvLogs.Items.Add(iGLCount.ToString())
                '    '    StrEnrNO = idwEnrollNumber.ToString()
                '    '    'lvItem.SubItems.Add(idwVerifyMode.ToString())
                '    '    'lvItem.SubItems.Add(idwInOutMode.ToString())
                '    '    'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())
                '    '    'lvItem.SubItems.Add(idwWorkcode.ToString())
                '    '    'lvItem.SubItems.Add(idwReserved.ToString())
                '    '    iGLCount += 1
                '    '    pgbUpdate.Value = pgbUpdate.Value + 1
                '    '    dgvData.Rows.Add(iGLCount.ToString(), idwEnrollNumber.ToString(), idwVerifyMode.ToString(), idwInOutMode.ToString(), idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString(), idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString(), idwWorkcode.ToString())
                '    'End While
                '    pgbUpdate.Value = 0
                'Else
                If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then 'read all the attendance records to the memory
                    'get records from the memory
                    If MsgBox("You are downloading data from " & StrDivNo & ", Continue ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                    Try
                        ''Select Case intControlV
                        ''Case 0
                        While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                            iGLCount += 1
                            pgbUpdate.Value = pgbUpdate.Value + 1
                            dgvData.Rows.Add(iGLCount.ToString(), sdwEnrollNumber, idwVerifyMode.ToString(), idwInOutMode.ToString(), idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString(), idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString(), idwWorkcode.ToString())
                        End While
                        ''Case 1
                        ''While axCZKEM1.GetGeneralLogData(iMachineNumber, idwTMachineNumber, idwEnrollNumber, idwEMachineNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute)
                        ''    iGLCount += 1
                        ''    'lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString())
                        ''    dgvData.Rows.Add(iGLCount.ToString(), idwEnrollNumber.ToString(), idwVerifyMode.ToString(), idwInOutMode.ToString(), idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString(), idwHour.ToString() & ":" & idwMinute.ToString(), "")
                        ''End While
                        ''End Select

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                    'While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                    'iGLCount += 1
                    'pgbUpdate.Value = pgbUpdate.Value + 1
                    'dgvData.Rows.Add(iGLCount.ToString(), sdwEnrollNumber, idwVerifyMode.ToString(), idwInOutMode.ToString(), idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString(), idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString(), idwWorkcode.ToString())
                    'End While

                    pgbUpdate.Value = 0
                Else
                    Cursor = Cursors.Default
                    axCZKEM1.GetLastError(idwErrorCode)
                    If idwErrorCode <> 0 Then
                        MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
                    Else
                        MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
                    End If
                End If

                axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
                Cursor = Cursors.Default
            Else
                Cursor = Cursors.WaitCursor
                dgvData.Rows.Clear()

                Dim StrLine As String
                Dim objReader As New StreamReader(StrOFile)
                Do While objReader.EndOfStream = False
                    Try
                        StrLine = LTrim(objReader.ReadLine)
                        StrLine = Replace(StrLine, "	", " ")
                        Dim iVal As Integer = 0

                        Dim words As String() = StrLine.Split(New Char() {" "})

                        ' Use For Each loop over words and display them
                        Dim word As String
                        For Each word In words
                            Console.WriteLine(word)
                            If Microsoft.VisualBasic.Left(word, 5) = "MONTH" Then iVal = 7 : Exit For
                            If word = "" Then iVal = 7 : Exit For
                            iVal = iVal + 1
                            Select Case iVal
                                Case 1
                                    StrEmp = word
                                Case 2
                                    dtAtDate = CDate(word)
                                Case 3
                                    dtAtTime = CDate(word)
                                Case 4
                                    intMode = CInt(word)
                                Case Else
                                    Dim StrV As String = word

                            End Select
                        Next

                        idwYear = Year(dtAtDate)
                        idwMonth = Month(dtAtDate)
                        idwDay = Format(dtAtDate, "dd")

                        idwHour = Hour(dtAtTime)
                        idwMinute = Minute(dtAtTime)
                        idwSecond = Second(dtAtTime)
                        idwWorkcode = 1

                        If iMachineNumber <> intMode Then
                            MessageBox.Show("Please check the device number of attendance terminal. Then select correct download form. Current selection is incorrect", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
                        End If
                        pgbUpdate.Value = pgbUpdate.Value + 1
                        iGLCount += 1
                        If StrEmp <> "" Then
                            dgvData.Rows.Add(iGLCount.ToString(), StrEmp.ToString(), 1, 1, idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString(), idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString(), idwWorkcode.ToString())
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message + " Last record is : " + StrEmp + " Line : " & iGLCount & " " + dtAtDate, MsgBoxStyle.Information)
                        Exit Sub
                    End Try
                Loop

                pgbUpdate.Value = 0
                Cursor = Cursors.Default
            End If
        End If

        'Save Data to the tblDimachine
        'Load Information to the Database
        pgbUpdate.Minimum = 0
        pgbUpdate.Maximum = dgvData.RowCount
        Dim sqlQRY As String

        'Modification Transaction Number : Kasun 20160918
        Dim intTriD As Integer = fk_sqlDbl("SELECT dnldTrID+1 FROM tblControl")

        Dim iRw As Integer
        Dim bolProcess As Boolean = False
        Dim intBLKCount As Integer = 0
        sqlQRY = "DELETE FROM tblAllDownData WHERE MacID = '" & StrDivNo & "'"
        With dgvData
            For iRw = 0 To .RowCount - 1
                sqlQRY = sqlQRY & " INSERT INTO tblAllDownData (MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode,Capture,tTime,EditMode,dAID,dStatus) VALUES " &
               " ('" & StrDivNo & "'," & CInt(.Item(0, iRw).Value) & ",'" & .Item(1, iRw).Value & "','" & .Item(2, iRw).Value & "', " &
               " '" & .Item(3, iRw).Value & "', '" & Format(CDate(.Item(4, iRw).Value), strRetDateTimeFormat) & "','" & CDate(.Item(5, iRw).Value) & "','" & .Item(6, iRw).Value & "',0,'',0," & intTriD & ",0)"
                pgbUpdate.Value = pgbUpdate.Value + 1 : intBLKCount = intBLKCount + 1

                If intBLKCount = 500 Then
                    bolProcess = FK_EQ(sqlQRY, "P", "", False, False, True) : intBLKCount = 0 : sqlQRY = ""
                End If
            Next
        End With
        If sqlQRY <> "" Then
            bolProcess = FK_EQ(sqlQRY, "P", "", False, False, True)
        End If

        dtpMaximumDate = fk_RetDate("SELECT Max(cDate) FROM tblAllDownData WHERE MacID = '" & StrDivNo & "'")
        'sqlQRY = "UPDATE tblAllDownData SET tTime = cDate+cTime WHERE cDate between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

        'Modification Transaction Number : Kasun 20160918
        sqlQRY = "UPDATE tblAllDownData SET tTime = cDate+cTime WHERE MacID = '" & StrDivNo & "'; UPDATE tblControl SET dnldTrID=" & intTriD & " WHERE GrpID='001'" : FK_EQ(sqlQRY, "S", "", False, False, True)


        'Check with the DiMachine table and update from the Download data
        'Load All Employee Information to the Grid
        Dim dgvEmp As New DataGridView
        With dgvEmp
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("Total", "Total")

        End With
        Try
            Dim sqlLoad As String = "SELECT EmpID,Count(*) FROM tblAllDownData WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' and MacID = '" & StrDivNo & "' Group by EmpID"
            Load_InformationtoGrid(sqlLoad, dgvEmp, 2)
            Dim intEmp As Integer = 0
            intBLKCount = 0
            pgbUpdate.Minimum = 0
            pgbUpdate.Value = 0
            Dim bolHasRecord As Boolean = False
            If dgvEmp.RowCount - 1 > 0 Then
                pgbUpdate.Maximum = dgvEmp.RowCount - 1

                With dgvEmp

                    For i As Integer = 0 To .RowCount - 1
                        intEmp = .Item(0, i).Value
                        sqlQRY = sqlQRY & " INSERT INTO tblDiMachine SELECT * FROM tblAllDownData WHERE Ltrim(tTime) " &
                         " NOT IN (SELECT Ltrim(tTime) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "' AND EmpID = " & intEmp & " )" &
                         " AND cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "' AND EmpID = " & intEmp & ""
                        intBLKCount = intBLKCount + 1 : pgbUpdate.Value = i
                        If intBLKCount = 25 Then
                            bolHasRecord = FK_EQ(sqlQRY, "P", "", False, False, True) : intBLKCount = 0
                            sqlQRY = ""
                        End If
                    Next
                    If sqlQRY <> "" Then
                        bolHasRecord = FK_EQ(sqlQRY, "P", "", False, False, True)
                    End If

                End With
            End If

            'sqlQRY = "delete from tbldiMachine WHERE cDate between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "' AND EditMode = 0"
            'sqlQRY = sqlQRY & " insert into tblDiMachine SELECT * FROM tblAllDownData WHERE cDate between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "'"

            'Modification Transaction Number : Kasun 20160918
            sSQL = "SELECT count(*) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' and MacID = '" & StrDivNo & "'  AND dStatus=0 AND dAID=" & intTriD & ""
            Dim intNewDownload As Integer = fk_sqlDbl(sSQL)
            sSQL = "INSERT INTO tblDownloadHistory (dAID,crUser,crTime,dDesc,dCount,dStatus,macID) VALUES (" & intTriD & ",'" & StrUserID & "',getDate(),'Download Data K14'," & intNewDownload & ",0,'" & StrDivNo & "')" : FK_EQ(sSQL, "P", "", False, False, True)

            'Update last downlod date for processed data 20170808
            sSQL = "declare @ldate as datetime; select @ldate= isnull([lastprocessed],'1900-01-01') from [tblDeviceInfo] WHERE [MachinID]='" & StrDivNo & "' " &
            " if @ldate='1900-01-01' UPDATE [tblDeviceInfo] SET [DownloadDate]=(select isnull(max([cDate]+[cTime]),'1900-01-01') FROM [tblDiMachine] where [MacID]='" & StrDivNo & "'),[lastprocessed]=(select isnull(max([cDate]+[cTime]),'1900-01-01') FROM [tblDiMachine] where [MacID]='" & StrDivNo & "') WHERE [MachinID]='" & StrDivNo & "'" : FK_EQ(sSQL, "P", "", False, False, True)

            If bolHasRecord = False Then MsgBox("Process Completed Sucesfully!", MsgBoxStyle.Exclamation)
            If bolHasRecord = True Then MsgBox("Process Completed Sucesfully", MsgBoxStyle.Information)
            If intFromServer = 1 Then
                sSQL = "DELETE FROM tblTransferedData WHERE MacID ='" & StrDivNo & "'" : FK_EQRemote(sSQL, "P", "", False, False, True)
            End If
            'sqlQRY = "INSERT INTO tblDiMachine SELECT * FROM tblAllDownData WHERE MacID+Ltrim(EmpID)+Ltrim(tTime) " & _
            '" NOT IN (SELECT MacID+Ltrim(EmpID)+Ltrim(tTime) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' )" & _
            '" AND cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "'"

        Catch ex As Exception
            MsgBox("Process Completed With Errors", MsgBoxStyle.Exclamation)
        End Try


        Me.Cursor = Cursors.Default
    End Sub

    Public Function NormalizeName(ByVal fullName As String) As String
        Dim name As String() = fullName.Split(" ")
        Return String.Format("{0} {1}", Trim(name(1)), Trim(name(0)))
    End Function

    Private Sub frmDataDownL_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If UP("Daily Download", "View Download form") = False Then Exit Sub

        CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)
        'Alter Control table to Version Controls 
        FK_EQ("ALTER TABLE tblCompany ADD vHard Numeric (18,0) NOT NULL Default 0", "S", "", False, False, False)
        ''intControlV = fk_sqlDbl("SELECT 000000000000000000000000000000000000000000000000000000000000 FROM tblCompany")

        cmdRefresh_Click(sender, e)
        intDownloadFromFile = fk_sqlDbl("select downFromFile from tblcompany where compID='" & StrCompID & "'")

        Load_DeviceInfo(strDiv_ID)

        If intDownloadFromFile = 1 Then
            optFile.Visible = True
        End If
        cmdOpen.Visible = False
        StrDivNo = strDiv_ID

        intFromServer = fk_sqlDbl("select runLocal from tblDeviceInfo where compID='" & StrCompID & "' and machinID='" & strDiv_ID & "'")
        If intFromServer = 1 Then
            OptServer.Visible = True
            OptServer.Checked = True
        End If
        txtServer.Text = mod_ConnectionAt.CNT(ReadKey("HRTime\RemoteSQLServer"))
        txtDatabase.Text = mod_ConnectionAt.CNT(ReadKey("HRTime\RemoteSQLDatabase"))
    End Sub

    Public Sub Load_DeviceInfo(ByVal StrDvID As String)
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblDeviceInfo WHERE MachinID = '" & StrDvID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtIP.Text = IIf(IsDBNull(drShw.Item("IPAddress")), "", drShw.Item("IPAddress"))
                txtPort.Text = IIf(IsDBNull(drShw.Item("Port")), "", drShw.Item("Port"))
                iMachineNumber = IIf(IsDBNull(drShw.Item("DivNo")), "", drShw.Item("DivNo"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
    End Sub

    Private Sub optDevice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDevice.CheckedChanged, optFile.CheckedChanged, OptServer.CheckedChanged

        If optDevice.Checked = True Then
            cmdOpen.Visible = False
            lnkClear.Visible = True
            With grbDevice
                .Visible = True
                .Width = 267
                .Height = 140
                .Location = New Point(263, 12)
                grbFileka.Visible = False
                grbServer.Visible = False
            End With

        ElseIf optFile.Checked = True Then
            cmdOpen.Visible = True
            lnkClear.Visible = False
            With grbFileka
                .Visible = True
                .Width = 267
                .Height = 140
                .Location = New Point(263, 12)
                grbDevice.Visible = False
                grbServer.Visible = False
            End With
        ElseIf OptServer.Checked = True Then
            cmdOpen.Visible = False
            lnkClear.Visible = False
            With grbServer
                .Visible = True
                .Width = 267
                .Height = 140
                .Location = New Point(263, 12)
                grbDevice.Visible = False
                grbFileka.Visible = False
            End With
        End If

    End Sub

    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        With ofdFile
            .ShowDialog()
            StrOFile = .FileName
            TextBox1.Text = StrOFile
        End With
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim dtpLastProcessDate As Date : Dim dtpMaximumDate As Date
        dtpLastProcessDate = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        dtpLastProcessDate = DateAdd(DateInterval.Day, -1, dtpLastProcessDate)
        dtpMaximumDate = fk_RetDate("select max(cDate) from tblAllDownData WHERE MacID = '" & StrDivNo & "'")
        Dim dgvEmp As New DataGridView
        With dgvEmp
            .Columns.Add("EmpID", "EMpID")
            .Columns.Add("Total", "Total")
        End With
        Dim intBLKCount As Integer
        Dim sqlQRY As String = ""

        Dim sqlLoad As String = "SELECT EmpID,Count(*) FROM tblAllDownData WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' and MacID = '" & StrDivNo & "' Group by EmpID"
        Load_InformationtoGrid(sqlLoad, dgvEmp, 2)
        Dim intEmp As Integer = 0
        intBLKCount = 0
        With dgvEmp
            For i As Integer = 0 To .RowCount - 2
                intEmp = .Item(0, i).Value
                sqlQRY = sqlQRY & " INSERT INTO tblDiMachine SELECT * FROM tblAllDownData WHERE Ltrim(tTime) " & _
     " NOT IN (SELECT Ltrim(tTime) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "' AND EmpID = " & intEmp & " )" & _
     " AND cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "' AND EmpID = " & intEmp & ""
                intBLKCount = intBLKCount + 1
                If intBLKCount = 500 Then FK_EQ(sqlQRY, "P", "", False, False, True) : intBLKCount = 0 : sqlQRY = ""
            Next
            FK_EQ(sqlQRY, "P", "", False, True, True)
        End With
    End Sub

    Private Sub cmdnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdnClose.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClear.LinkClicked
        If UP("Daily Download", "Clear all times from terminal") = False Then Exit Sub
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim dr As DialogResult = MessageBox.Show("Did you download and processed the all attendance data from this device ? This process will clear all attendance log from this device. Any way do you really want to clear all attendance data from fingerprint device ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dr = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        'lvLogs.Items.Clear()

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ClearGLog(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("All att Logs have been cleared from teiminal!", MsgBoxStyle.Information, "Success")
            sSQL = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Delete attendance data from fingerprint machine','" & StrUserID & "',getdate ())" : FK_EQ(sSQL, "S", "", False, False, True)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If intFromServer = 1 Then
            connetToRemoteServerNow()
        Else
            cmdConnect_Click(sender, e)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If UP("Daily Download", "Download data from terminal") = False Then Exit Sub
        cmdDownload_Click(sender, e)
    End Sub

    Private Sub OptServer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptServer.CheckedChanged

    End Sub

    Private Sub pgbUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pgbUpdate.Click

    End Sub

    Private Sub cmdOpen_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.VisibleChanged
        If cmdOpen.Visible = True Then Button4.Visible = False : Button3.Visible = True
        If cmdOpen.Visible = False Then Button4.Visible = True : Button3.Visible = False
    End Sub
End Class