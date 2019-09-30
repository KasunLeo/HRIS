Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmSetShiftType

    Dim StrShiftID As String = ""
    Dim StrSvstatus As String = "S"
    Dim intShiftMode As Integer = 0

    Private Sub frmShiftManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CenterFormThemed(Me, pnlTop, Label25)
        ControlHandlers(Me)
        Dim sqlTable As String
        sqlTable = "CREATE TABLE tblSetShiftH (ShiftID Nvarchar (3),ShiftMode Numeric (18,0),ShiftName Nvarchar (100),InTime DateTime,OutTime DateTime,StartCIN DateTime,EndCIN DateTime,StartCOUT DateTime,EndCOUT DateTime,WrkMins Numeric (18,2),DayCount Numeric (18,2),Status Numeric (18,0))"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblSetShiftH ADD OpenShift Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblSetShiftH ADD ShortCode NVarchar(3) NOT NULL Default ''"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblSetShiftH ADD StrShift Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblSetShiftH ADD sINEarly Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        TabControl1.TabPages.RemoveAt(1)
        sqlTable = "SELECT * INTO tblShiftHist FROM tblSetShiftH"
        FK_EQ(sqlTable, "S", "", False, False, False)

        sqlTable = "ALTER TABLE tblSetShiftH ADD CalWorkMin Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)


        Button4_Click(sender, e)

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Enter Then SendKeys.Send("{TAB}")
        If keyData = Keys.Escape Then Me.Close()
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click


    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub dgvShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvShifts.Click

        'Open Shifts 
        Dim cnOpn As New SqlConnection(sqlConString)
        cnOpn.Open()
        Dim sqlOpn As String = "SELECT * FROM tblSetShiftH WHERE ShiftID = '" & dgvShifts.Item(0, dgvShifts.CurrentRow.Index).Value & "'"
        Try
            Dim cmOpn As New SqlCommand(sqlOpn, cnOpn)
            Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
            If drOpn.Read = True Then
                StrShiftID = IIf(IsDBNull(drOpn.Item("ShiftID")), "", drOpn.Item("ShiftID"))
                txtShiftID.Text = StrShiftID
                txtShiftName.Text = IIf(IsDBNull(drOpn.Item("ShiftName")), "", drOpn.Item("ShiftName"))
                intShiftMode = IIf(IsDBNull(drOpn.Item("ShiftMode")), "", drOpn.Item("ShiftMode"))
                dtpShitStart.Value = IIf(IsDBNull(drOpn.Item("InTime")), "", drOpn.Item("InTime"))
                dtpShiftEnd.Value = IIf(IsDBNull(drOpn.Item("OutTime")), "", drOpn.Item("OutTime"))
                dtpStartCIN.Value = IIf(IsDBNull(drOpn.Item("StartCIN")), "", drOpn.Item("StartCIN"))
                dtpStartCOUT.Value = IIf(IsDBNull(drOpn.Item("EndCIN")), "", drOpn.Item("EndCIN"))
                dtpEndCIN.Value = IIf(IsDBNull(drOpn.Item("StartCOUT")), "", drOpn.Item("StartCOUT"))
                dtpEndCOUT.Value = IIf(IsDBNull(drOpn.Item("EndCOUT")), "", drOpn.Item("EndCOUT"))
                txtTotWMins.Text = IIf(IsDBNull(drOpn.Item("WrkMins")), "", drOpn.Item("WrkMins"))
                txtDayCount.Text = IIf(IsDBNull(drOpn.Item("DayCount")), "", drOpn.Item("DayCount"))
                chkOpenShift.CheckState = IIf(IsDBNull(drOpn.Item("OpenShift")), 0, drOpn.Item("OpenShift"))
                chkWrkMin.CheckState = IIf(IsDBNull(drOpn.Item("CalWorkMin")), 0, drOpn.Item("CalWorkMin"))
                txtShortCode.Text = IIf(IsDBNull(drOpn.Item("ShortCode")), "", drOpn.Item("ShortCode"))
                chkStrShift.CheckState = IIf(IsDBNull(drOpn.Item("StrShift")), 0, drOpn.Item("StrShift"))
                If intShiftMode = 0 Then
                    optDay.Checked = True
                ElseIf intShiftMode = 1 Then
                    optNight.Checked = True
                Else
                    opt24Hour.Checked = True
                End If

                txtShiftName.Focus()
                StrSvstatus = "E"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpn.Close()
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Save Information to the tblSetShiftH
        'Validate textboxes
        If txtShiftID.Text = "" Then MsgBox("No Shift ID", MsgBoxStyle.Information) : txtShiftID.Focus() : Exit Sub
        If txtShiftName.Text = "" Then MsgBox("Enter Shift Name", MsgBoxStyle.Information) : txtShiftName.Focus() : Exit Sub
        If txtTotWMins.Text = "" Or CDbl(txtTotWMins.Text) = 0 Then MsgBox("No Work Minutes", MsgBoxStyle.Information) : Exit Sub
        If txtDayCount.Text = "" Then MsgBox("Enter Day Mark ", MsgBoxStyle.Information) : Exit Sub

        If optDay.Checked = True Then
            intShiftMode = 0
        ElseIf optNight.Checked = True Then
            intShiftMode = 1
        Else
            intShiftMode = 2
        End If
        Dim sqlQRY As String = ""

        Dim intCrTab As String = TabControl1.SelectedTab.Name

        Select Case intCrTab
            Case "TabPage1"
                Select Case StrSvstatus
                    Case "S"
                        sqlQRY = "INSERT INTO tblSetShiftH (ShiftID,ShiftMode,ShiftName,InTime,OutTime,StartCIN,EndCIN,StartCOUT,EndCOUT,WrkMins,DayCount,CompID,Status,OpenShift,hasMeal,ShortCode,CalWorkMin,StrShift) VALUES " & _
                        " ('" & txtShiftID.Text & "', " & intShiftMode & ",'" & txtShiftName.Text & "','" & Format(dtpShitStart.Value, "hh:mm:ss tt") & "', '" & Format(dtpShiftEnd.Value, "hh:mm:ss tt") & "', " & _
                        " '" & Format(dtpStartCIN.Value, "hh:mm:ss tt") & "', '" & Format(dtpStartCOUT.Value, "hh:mm:ss tt") & "','" & Format(dtpEndCIN.Value, "hh:mm:ss tt") & "','" & Format(dtpEndCOUT.Value, "hh:mm:ss tt") & "', " & _
                        " " & CDbl(txtTotWMins.Text) & "," & CDbl(txtDayCount.Text) & ",'" & StrCompID & "',0," & chkOpenShift.CheckState & ",0,'" & txtShortCode.Text & "'," & chkWrkMin.CheckState & "," & chkStrShift.CheckState & ")"
                        sqlQRY = sqlQRY & " UPDATE tblCompany SET noShifts = NoShifts + 1 WHERE CompID = '" & StrCompID & "'"

                    Case "E" ' Update Information 
                        sqlQRY = "UPDATE tblSetShiftH SET ShortCode = '" & txtShortCode.Text & "', ShiftMode = " & intShiftMode & ",ShiftName = '" & txtShiftName.Text & "',InTime = '" & Format(dtpShitStart.Value, "hh:mm:ss tt") & "',OutTime = '" & Format(dtpShiftEnd.Value, "hh:mm:ss tt") & "', " & _
                        " StartCIN = '" & Format(dtpStartCIN.Value, "hh:mm:ss tt") & "',EndCIN='" & Format(dtpStartCOUT.Value, "hh:mm:ss tt") & "', " & _
                        " StartCOUT = '" & Format(dtpEndCIN.Value, "hh:mm:ss tt") & "',EndCOUT = '" & Format(dtpEndCOUT.Value, "hh:mm:ss tt") & "', " & _
                        " WrkMins = " & CDbl(txtTotWMins.Text) & ",DayCount = " & CDbl(txtDayCount.Text) & ",CompID = '" & StrCompID & "',Status = 0,OpenShift = " & chkOpenShift.CheckState & ",CalWorkMin = " & chkWrkMin.CheckState & ",StrShift = " & chkStrShift.CheckState & " WHERE ShiftID = '" & txtShiftID.Text & "'"

                End Select
            Case "TabPage2"
                MsgBox("Not Configured")
        End Select


        'Dim bolSave As Boolean
        If FK_EQ(sqlQRY, StrSvstatus, "", False, True, True) = True Then Button4_Click(sender, e) Else Exit Sub
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Clear Form Containg
        Dim sqlTable As String = ""

        FK_Clear(Me)
        'Generate Script
        Dim iTr As Integer = fk_sqlDbl("SELECT NoShifts FROM tblCompany WHERE CompID = '" & StrCompID & "'") + 1
        StrShiftID = fk_CreateSerial(3, iTr)
        txtShiftID.Text = StrShiftID

        'Load Shift Information 
        sqlTable = "select ShiftID,shiftName,Convert(Varchar(30),InTime,114),Convert(Varchar(30),OutTime,114),shortCode,Status FROM tblSetShiftH Order By ShiftID"
        Load_InformationtoGrid(sqlTable, dgvShifts, 6)
        clr_Grid(dgvShifts)

        Dim crtl As Control
        For Each crtl In Me.Controls
            If TypeOf crtl Is DateTimePicker Then crtl.Text = DateSerial(1900, 1, 1)
        Next
        StrSvstatus = "S"

        With dgvShifts
            For iRow As Integer = 0 To .RowCount - 1
                For iCol As Integer = 0 To .ColumnCount - 1
                    If iRow Mod 2 = 1 Then .Item(iCol, iRow).Style.BackColor = Color.LightGray Else .Item(iCol, iRow).Style.BackColor = Color.White
                Next
            Next
        End With
    End Sub

End Class