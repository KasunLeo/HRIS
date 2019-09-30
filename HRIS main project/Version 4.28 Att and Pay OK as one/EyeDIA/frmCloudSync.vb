Public Class frmCloudSync

    
    Dim LastDownloadDate As DateTime

    Public Sub getDeviceID()

        LastDownloadDate = fk_RetDate("select  DownloadDate from tbldeviceInfo  where  MachinID = '" & StrDivNoMachineID & "' ")
        LastDownloadDate = LastDownloadDate.AddDays(-1)

        StrDivNoLocation = fk_sqlDbl("select LocationID from tbldeviceinfo WHERE MachinID = '" & StrDivNoMachineID & "' ")
        StrDivNoLocation = fk_CreateSerial(3, StrDivNoLocation)
    End Sub


    Private Sub btnConnectrmtSvr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnectrmtSvr.Click

        'ConnectToRemoteServer()
        lblStatus.Text = sqlRemotConStatus
        btnDownload_Click(sender, e)
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        sSQL = "SELECT    [MacID] AS 'LocationID',[crLine],[EmpID],[VrfyMode],[Input],[cDate],[cTime],[WrkCode] ,[capture],[tTime],[EditMode],[dAID],[dStatus] FROM  tblTransferedColuddb WHERE MacID = '" & StrDivNoLocation & "' AND cDate > '" & LastDownloadDate & "'  "
        Rmote_Fk_FillGrid(sSQL, dgvDownCloud)
        lblRowCount.Text = "Count : " & dgvDownCloud.RowCount
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim iRw As Integer
        Dim bolProcess As Boolean = False
        Dim intBLKCount As Integer = 0
        pgbUpdate.Minimum = 0
        pgbUpdate.Value = 0
        pgbUpdate.Maximum = dgvDownCloud.RowCount
        sSQL = ""
        Dim dtpLastProcessDate As Date : Dim dtpMaximumDate As Date
        Dim intTriD As Integer = fk_sqlDbl("SELECT dnldTrID+1 FROM tblControl")

        sSQL = "DELETE tblAllDownData  WHERE MacID = '" & StrDivNoLocation & "'" : FK_EQ(sSQL, "P", "", False, False, True)


        With dgvDownCloud
            For iRw = 0 To .RowCount - 1
                sSQL = sSQL & " INSERT INTO tblAllDownData (MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode,Capture,tTime,EditMode,dAID,dStatus) VALUES " & _
               " ('" & .Item(0, iRw).Value & "'," & CInt(.Item(1, iRw).Value) & ",'" & .Item(2, iRw).Value & "','" & .Item(3, iRw).Value & "', " & _
               " '" & .Item(4, iRw).Value & "', '" & CDate(.Item(5, iRw).Value) & "','" & CDate(.Item(6, iRw).Value) & "','" & .Item(7, iRw).Value & "','" & .Item(8, iRw).Value & "','" & CDate(.Item(9, iRw).Value) & "','" & .Item(10, iRw).Value & "','" & intTriD & "','" & .Item(12, iRw).Value & "')"
                pgbUpdate.Value = pgbUpdate.Value + 1
                intBLKCount = intBLKCount + 1

                If intBLKCount = 100 Then
                    bolProcess = FK_EQ(sSQL, "P", "", False, False, True) : intBLKCount = 0 : sSQL = ""
                End If
            Next

        End With
        If sSQL <> "" Then
            bolProcess = FK_EQ(sSQL, "P", "", False, False, True) : intBLKCount = 0 : sSQL = ""
        End If

        FK_EQ("UPDATE tblControl SET dnldTrID = '" & intTriD & "'  ", "P", "", False, False, True)


        '----------------------------------

        Dim dgvEmp As New DataGridView
        With dgvEmp
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("Total", "Total")
        End With


        '----------------------

        Try
            dtpLastProcessDate = fk_RetDate("SELECT downloadDate FROM tblDeviceInfo WHERE LocationID = '" & StrDivNoLocation & "'")
            dtpLastProcessDate = DateAdd(DateInterval.Day, -1, dtpLastProcessDate)
            dtpMaximumDate = fk_RetDate("SELECT Max(cDate) FROM tblAllDownData WHERE MacID = '" & StrDivNoLocation & "'")


            Dim sqlLoad As String = "SELECT EmpID,Count(*) FROM tblAllDownData WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' and MacID = '" & StrDivNoLocation & "' Group by EmpID"
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
                        sSQL = sSQL & " INSERT INTO tblDiMachine SELECT * FROM tblAllDownData WHERE Ltrim(tTime) " & _
                         " NOT IN (SELECT Ltrim(tTime) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNoLocation & "' AND EmpID = " & intEmp & " )" & _
                         " AND cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNoLocation & "' AND EmpID = " & intEmp & ""
                        intBLKCount = intBLKCount + 1 : pgbUpdate.Value = i
                        If intBLKCount = 25 Then
                            bolHasRecord = FK_EQ(sSQL, "P", "", False, False, True) : intBLKCount = 0
                            sSQL = ""
                        End If
                    Next
                    If sSQL <> "" Then
                        bolHasRecord = FK_EQ(sSQL, "P", "", False, False, True)
                    End If

                End With
            End If

            'sqlQRY = "delete from tbldiMachine WHERE cDate between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "' AND EditMode = 0"
            'sqlQRY = sqlQRY & " insert into tblDiMachine SELECT * FROM tblAllDownData WHERE cDate between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' AND MacID = '" & StrDivNo & "'"

            'Modification Transaction Number : Kasun 20160918
            'sSQL = "SELECT count(*) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' and MacID = '" & StrDivNo & "'  AND dStatus=0 AND dAID=" & intTriD & ""
            sSQL = "SELECT count(*) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' and MacID = '" & StrDivNoLocation & "'  AND dStatus=0 "

            Dim intNewDownload As Integer = fk_sqlDbl(sSQL)
            sSQL = "INSERT INTO tblDownloadHistory (dAID,crUser,crTime,dDesc,dCount,dStatus,macID) VALUES (" & intTriD & ",'" & StrUserID & "',getDate(),'Download Data K14'," & intNewDownload & ",0,'" & StrDivNoMachineID & "')" : FK_EQ(sSQL, "P", "", False, False, True)

            'Update last downlod date for processed data 20170808
            sSQL = "declare @ldate as datetime; select @ldate= isnull([lastprocessed],'1900-01-01') from [tblDeviceInfo] WHERE [MachinID]='" & StrDivNoMachineID & "' " & _
            " if @ldate='1900-01-01' UPDATE [tblDeviceInfo] SET [DownloadDate]=(select isnull(max([cDate]+[cTime]),'1900-01-01') FROM [tblDiMachine] where [MacID]='" & StrDivNoLocation & "'),[lastprocessed]=(select isnull(max([cDate]+[cTime]),'1900-01-01') FROM [tblDiMachine] where [MacID]='" & StrDivNoLocation & "') WHERE [MachinID]='" & StrDivNoMachineID & "'" : FK_EQ(sSQL, "P", "", False, False, True)

            If bolHasRecord = False Then MsgBox("Process Completed Sucesfully!", MsgBoxStyle.Exclamation)
            If bolHasRecord = True Then MsgBox("Process Completed Sucesfully", MsgBoxStyle.Information)
            'If intFromServer = 1 Then
            'sSQL = "DELETE FROM tblTransferedData WHERE MacID ='" & StrDivNo & "'" : FK_EQRemote(sSQL, "P", "", False, False, True)
            ' End If
            'sqlQRY = "INSERT INTO tblDiMachine SELECT * FROM tblAllDownData WHERE MacID+Ltrim(EmpID)+Ltrim(tTime) " & _
            '" NOT IN (SELECT MacID+Ltrim(EmpID)+Ltrim(tTime) FROM tblDiMachine WHERE cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "' )" & _
            '" AND cDate Between '" & Format(dtpLastProcessDate, "yyyyMMdd") & "' AND '" & Format(dtpMaximumDate, "yyyyMMdd") & "'"

        Catch ex As Exception
            MsgBox("Process Completed With Errors", MsgBoxStyle.Exclamation)
        End Try


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub frmCloudSync_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getDeviceID()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If StrDivNoLocation <> "000" Then
            If My.Computer.Network.Ping("8.8.8.8", 3000) Then
                btnConnectrmtSvr_Click(sender, e)
            Else
                MsgBox("Internet Connection Fail..! ", MsgBoxStyle.Exclamation)
            End If

        Else
            MsgBox("Please Select Location.. ", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If dgvDownCloud.RowCount < 1 Then
            MsgBox("New Data Not Find..! ", MsgBoxStyle.Exclamation)
        Else
            btnSave_Click(sender, e)
        End If

    End Sub
End Class