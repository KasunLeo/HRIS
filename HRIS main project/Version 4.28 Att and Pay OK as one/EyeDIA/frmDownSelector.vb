Public Class frmDownSelector

    Dim StrDownForm As String
    Dim strWhereClause As String = ""

    Private Sub dgvData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'With dgvData
        '    strDiv_ID = .Item(0, .CurrentRow.Index).Value
        '    StrDownForm = .Item(2, .CurrentRow.Index).Value
        '    Form_Selector(StrDownForm)
        'End With

    End Sub

    Public Sub Form_Selector(ByVal DownForm As String)
        Me.pnlDynamic.Controls.Clear()

        If DownForm = "ZK K14 Device" Then
            Dim frmReg As New frmDataDownLzk14
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal
            frmReg.TopLevel = False
            frmReg.Location = New Point(0, 0)
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        ElseIf DownForm = "ZK Face Detection" Then
            Dim frmReg As New frmDataZKFace302D
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Normal
            frmReg.TopLevel = False
            frmReg.Location = New Point(0, 0)
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

    End Sub

    Private Sub frmDownSelector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlQRY As String = ""
        sqlQRY = "SELECT machinID,mDesc,downloadForm ,status FROM tblDeviceInfo WHERE Status = 0 Order By machinID"
        Load_InformationtoGrid(sqlQRY, dgvData, 4)

        With dgvData
            strDiv_ID = .Item(0, 0).Value
            StrDownForm = .Item(2, 0).Value
            Form_Selector(StrDownForm)
        End With

        sSQL = "select max(crTime) from tblDownloadHistory"
        dtpFromDate.Value = fk_RetDate(sSQL)

        sSQL = "select tblDownloadHistory.macid AS 'Mac ID',tbldeviceinfo.mDesc 'Machine Name',tbldeviceinfo.divNo AS 'Divice No',tblDownloadHistory.dDesc AS 'Description',tblDownloadHistory.crTime AS 'Last Download',tblDownloadHistory.crUser AS 'User',tblDownloadHistory.dCount AS 'Count',tblDownloadHistory.daID AS 'ID' from tblDownloadHistory,tbldeviceinfo WHERE tbldeviceinfo.machinID=tblDownloadHistory.Macid and convert(nvarchar(8),crTime,112)='" & Format(dtpFromDate.Value, "yyyyMMdd") & "' "
        Fk_FillGrid(sSQL, dgvDaySummary)
        clr_Grid(dgvDaySummary)

        'Load Process screen
        Me.pnlProcessk.Controls.Clear()
        Dim frmReg As New frmAttnProcess
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized

        frmReg.TopLevel = False
        Me.pnlProcessk.Controls.Add(frmReg)

        frmReg.Show()
        rdbDownload.Checked = True

    End Sub

    Private Sub cmdnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub dgvData_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellContentClick
        If rdbSync.Checked = True Then
            pnlDynamic.Controls.Clear()
            pnlDynamic.Controls.Add(pnlSyncData)
            strWhereClause = " AND tblDimachine.MacID='" & strDiv_ID & "'"
        ElseIf rdbDownload.Checked = True Then
            With dgvData
                strDiv_ID = Trim(.CurrentRow.Cells(0).Value)
                StrDownForm = .Item(2, .CurrentRow.Index).Value
                'Me.pnlDynamic2.Controls.Clear()
                Form_Selector(StrDownForm)
            End With
        ElseIf rbCloudSync.Checked = True Then
            ' frmCloudSync.Show()
            StrDivNoMachineID = (dgvData.Item(0, dgvData.CurrentRow.Index).Value)

            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmCloudSync
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized
            frmReg.TopLevel = False
            frmReg.Location = New Point(0, 0)
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If
    End Sub

    Private Sub dtpFromDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFromDate.ValueChanged
        sSQL = "select tblDownloadHistory.macid AS 'Terminal ID',tbldeviceinfo.mDesc AS 'Device Name',tbldeviceinfo.divNo AS 'Divice No',tblDownloadHistory.dDesc As 'Description',tblDownloadHistory.crTime AS 'Last Download Time',tblDownloadHistory.crUser AS 'User',tblDownloadHistory.dCount AS 'Count',tblDownloadHistory.daID AS 'ID' from tblDownloadHistory,tbldeviceinfo WHERE tbldeviceinfo.machinID=tblDownloadHistory.Macid and convert(nvarchar(8),crTime,112)='" & Format(dtpFromDate.Value, "yyyyMMdd") & "' "
        Fk_FillGrid(sSQL, dgvDaySummary)
        dgvDaySummary.Columns(0).Visible = False
        dgvDaySummary.Columns(2).Visible = False
        dgvDaySummary.Columns(5).Visible = False
        dgvDaySummary.Columns(6).Visible = False
        clr_Grid(dgvDaySummary)
    End Sub

    Private Sub dgvDaySummary_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDaySummary.CellClick
        sSQL = "select tbldimachine.empid AS 'Terminal No',tblemployee.DispName AS 'Employee Name',convert(nvarchar(10),tbldimachine.cDate,102) AS 'Date',convert(nvarchar(8),tbldimachine.cTime,108) AS 'Time' from tbldimachine left outer join tblemployee ON tblemployee.enrolNo=tblDiMachine.empID  where tblDiMachine.editMode=0 and tblDiMachine.daid=" & Val(dgvDaySummary.CurrentRow.Cells(7).Value) & " "
        Fk_FillGrid(sSQL, dgvDownloadHistory)
        lblSelectCount.Text = "Selected Date Punch Times Review " & dgvDownloadHistory.RowCount
    End Sub

    Private Sub btnSearchSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSync.Click
        sSQL = "DELETE FROM tblDiMachineMissed; INSERT INTO tblDiMachineMissed SELECT * FROM tblAllDownData WHERE empID+CONVERT(VARCHAR(24),(ttime),126) NOT IN (SELECT empID+CONVERT(VARCHAR (24),(ttime),126) FROM tblDiMachine WHERE cDate Between '" & Format(dtpFrSync.Value, "yyyyMMdd") & "' AND '" & Format(dtpToSync.Value, "yyyyMMdd") & "'  " & strWhereClause & ") AND cDate Between '" & Format(dtpFrSync.Value, "yyyyMMdd") & "' AND '" & Format(dtpToSync.Value, "yyyyMMdd") & "'  " & strWhereClause & ""
        FK_EQ(sSQL, "S", "", False, False, True)
        sSQL = "SELECT * FROM tblDiMachineMissed"
        Fk_FillGrid(sSQL, dgvSyncedData)
    End Sub

    Private Sub rdbSync_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbSync.MouseClick
        pnlDynamic.Controls.Clear()
        pnlDynamic.Controls.Add(pnlSyncData)
        strWhereClause = ""
    End Sub

    Private Sub btnSaveSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSync.Click
        sSQL = "INSERT INTO tblDiMachine SELECT * FROM tblDiMachineMissed" : FK_EQ(sSQL, "S", "", False, True, True)
        sSQL = "DELETE FROM tblDiMachineMissed" : FK_EQ(sSQL, "S", "", False, False, True)
    End Sub

    Private Sub rdbDownload_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbDownload.MouseClick
        With dgvData
            strDiv_ID = Trim(.CurrentRow.Cells(0).Value)
            StrDownForm = .Item(2, .CurrentRow.Index).Value
            'Me.pnlDynamic2.Controls.Clear()
            Form_Selector(StrDownForm)
        End With
    End Sub

    Private Sub rbCloudSync_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbCloudSync.MouseClick
        Me.pnlDynamic.Controls.Clear()
        Dim frmReg As New frmCloudSync
        frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmReg.WindowState = FormWindowState.Maximized
        frmReg.TopLevel = False
        frmReg.Location = New Point(0, 0)
        Me.pnlDynamic.Controls.Add(frmReg)
        frmReg.Show()
    End Sub

 
End Class