Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmWeekShdl
    Dim StrShdID As String
    Dim StrSvStatus As String = "S"

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Dim crtl As Control
        For Each crtl In Me.GroupBox1.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""

        Next

        Dim ids As Integer = fk_sqlDbl("SELECT wkShdNos FROM tblControl") + 1
        StrShdID = fk_CreateSerial(3, ids)
        txtCode.Text = StrShdID

        'With dgvInfo
        '    .Columns.Clear()

        '    .Columns.Add("dID", "Day ID")
        '    .Columns.Add("dName", "Day Name")
        '    .Columns.Add("ShID", "Shift ID")
        '    .Columns(2).Visible = False
        '    .Columns.Add("Shfname", "Shift")

        '    .Columns(0).Visible = False

        'End With

        'Load Information to the Grid
        Dim sqlSd As String = "select TOP 7 tblDays.DayID,tblDays.DayDesc,'','' from tblDays  Order By tblDays.DayID"

        Load_GridCombo("SELECT TypeName FROM tblDayType WHERE Status = 0 Order By TypeID", cmbWorkDes)

        Load_InformationtoGrid(sqlSd, dgvInfo, 3)
        clr_Grid(dgvInfo)

        'With dgvData
        '    .Columns.Clear()

        '    .Columns.Add("shID", "Shedule ID") ' 0
        '    .Columns.Add("shName", "Short Name") ' 1
        '    .Columns.Add("shDesc", "Description") '2
        '    '.Columns.Add("dayID", "DayTypeID") '3
        '    '.Columns(3).Visible = True
        '    '.Columns.Add("DayType", "Day Type") ' 4


        '    .Columns(0).Visible = False

        'End With
        'load schedule infor
        Dim sqlSi As String = "SELECT ShdID,ShduName,ShdName FROM tblWKSheduleH WHERE Status = 0 Order By ShdID"
        Load_InformationtoGrid(sqlSi, dgvData, 3)
        clr_Grid(dgvData)

        StrSvStatus = "S"

    End Sub

    Private Sub frmWeekShdl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
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

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Roster/ Shift", "Create day type pattern") = False Then Exit Sub

        'Check for the Non Selected Shifts
        Dim bolCan As Boolean = False
        With dgvInfo
            For i As Integer = 0 To .RowCount - 1
                .Item(4, i).Value = fk_RetString("SELECT typeID FROM tblDayType WHERE TypeName = '" & .Item(5, i).Value & "'")
            Next
        End With
        With dgvInfo
            For i As Integer = 0 To .RowCount - 1
                If .Item(2, i).Value = "" Or .Item(2, i).Value = "NULL" Then
                    bolCan = True
                    i = .RowCount - 1
                End If
            Next
        End With

        'If bolCan = True Then
        '    MsgBox("Plz Select the Shift for Every Day", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        'Save information to the table
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
                    sqlQRY = "DELETE FROM tblRosterH WHERE RosterID = '" & txtCode.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblWKSheduleH (ShdID,ShduName,ShdName,Status) VALUES ('" & txtCode.Text & "','" & txtsName.Text & "','" & txtDesc.Text & "'," & chkStatus.CheckState & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblRosterH (rosterID,rName,CompID,Status) VALUES ('" & txtCode.Text & "','" & txtsName.Text & "','" & StrCompID & "',0)"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    'Insert grid data to the table 
                    sqlQRY = "DELETE FROM tblWkSheduleD WHERE shdID = '" & txtCode.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblControl SET wkShdNos = wkShdNos + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    Dim i As Integer
                    With dgvInfo
                        For i = 0 To .RowCount - 1
                            sqlQRY = "INSERT INTO tblWkSheduleD (shdID,ShiftID,DayID,DayTypeID) VALUES ('" & txtCode.Text & "','" & .Item(2, i).Value & "'," & CDbl(.Item(0, i).Value) & ",'" & .Item(4, i).Value & "')"
                            cmSave.CommandText = sqlQRY
                            cmSave.ExecuteNonQuery()

                        Next
                    End With

                    trSave.Commit()
                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    generate_Roster(txtCode.Text)
                    cmdRefresh_Click(sender, e)

                Case "E"

                    sqlQRY = "UPDATE  tblWKSheduleH SET ShduName = '" & txtsName.Text & "',ShdName = '" & txtDesc.Text & "',Status = " & chkStatus.CheckState & " WHERE shdID = '" & txtCode.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblRosterH SET rName = '" & txtsName.Text & "' WHERE RosterID = '" & txtCode.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "DELETE FROM tblWkSheduleD WHERE shdID = '" & txtCode.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    Dim i As Integer
                    With dgvInfo
                        For i = 0 To .RowCount - 1
                            sqlQRY = "INSERT INTO tblWkSheduleD (shdID,ShiftID,DayID,DayTypeID) VALUES ('" & txtCode.Text & "','" & .Item(2, i).Value & "'," & CDbl(.Item(0, i).Value) & ",'" & .Item(4, i).Value & "')"
                            cmSave.CommandText = sqlQRY
                            cmSave.ExecuteNonQuery()
                        Next
                    End With

                    trSave.Commit()
                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    generate_Roster(txtCode.Text)
                    cmdRefresh_Click(sender, e)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    'Generate information for the Year
    Public Sub generate_Roster(ByVal rID As String)
        'Generate Information for the RosterD table 
        Dim cnGen As New SqlConnection(sqlConString)
        cnGen.Open()
        Dim cmGen As New SqlCommand
        cmGen = cnGen.CreateCommand
        Dim trGen As SqlTransaction = cnGen.BeginTransaction
        cmGen.Transaction = trGen
        Dim sqlQRY As String
        Try
            sqlQRY = "DELETE FROM tblRosterD WHERE cDate >= '" & Format(dtpRegDate.Value, "yyyyMMdd") & "' AND RosterID = '" & rID & "'"
            cmGen.CommandText = sqlQRY
            cmGen.ExecuteNonQuery()

            'Insert to Information 
            sqlQRY = "insert into tblRosterD select '" & rID & "',Day(tblCalendar.[Date]),tblCalendar.cMonth,tblCalendar.cYear,tblCalendar.[Date],tblWkSheduleD.ShiftID,1 from tblCalendar INNER JOIN tblWkSheduleD ON tblCalendar.DayLink = tblWkSheduleD.DayID " & _
            " where tblCalendar.cYear = " & intCurrentYear & " AND tblCalendar.[Date] >= '" & Format(dtpRegDate.Value, "yyyyMMdd") & "' AND tblWkSheduleD.ShdID = '" & rID & "'"
            cmGen.CommandText = sqlQRY
            cmGen.ExecuteNonQuery()

            trGen.Commit()
        Catch ex As Exception
            trGen.Rollback()
            MsgBox(ex.Message)
        Finally
            cnGen.Close()
        End Try

    End Sub

    Private Sub dgvData_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellClick

        StrShdID = dgvData.Item(0, dgvData.CurrentRow.Index).Value

        'Load to text boxes
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "SELECT * FROM tblWKSheduleH WHERE shdID = '" & StrShdID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then

                txtCode.Text = IIf(IsDBNull(drShw.Item("ShdID")), "", drShw.Item("ShdID"))
                txtsName.Text = IIf(IsDBNull(drShw.Item("ShduName")), "", drShw.Item("ShduName"))
                txtDesc.Text = IIf(IsDBNull(drShw.Item("ShdName")), "", drShw.Item("ShdName"))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item("Status")), 0, drShw.Item("Status"))

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try


        'With dgvInfo
        '    .Columns.Clear()

        '    .Columns.Add("dID", "Day ID")
        '    .Columns.Add("dName", "Day Name")
        '    .Columns.Add("ShID", "Shift ID")
        '    .Columns.Add("Shif", "Shift Name")
        '    .Columns(2).Visible = False
        '    .Columns(0).Visible = False

        'End With

        'Load Information to the Grid
        Dim sqlSd As String = "select tblDays.DayID,tblDays.DayDesc,'','',tblDayType.TypeID,tblDayType.TypeName from tblDays LEFT OUTER JOIN " & _
 " tblWkSheduleD ON tblDays.DayID = tblWkSheduleD.DayID " & _
 " LEFT OUTER JOIN tblDayType ON tblWkSheduleD.DayTypeID = tblDayType.TypeID WHERE tblWkSheduleD.ShdID =  '" & StrShdID & "' Order By tblDays.DayID"

        Load_InformationtoGrid(sqlSd, dgvInfo, 6)
        clr_Grid(dgvInfo)

        StrSvStatus = "E"

    End Sub

    Private Sub dgvInfo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInfo.CellDoubleClick

        'Load Shift Borswer
        'Dim frmShB As New frmSelShift
        'frmShB.ShowDialog()

        dgvInfo.Item(2, dgvInfo.CurrentRow.Index).Value = StrSelectShift
        dgvInfo.Item(3, dgvInfo.CurrentRow.Index).Value = fk_RetString("SELECT shiftName FROM tblSetShiftH WHERE ShiftID = '" & StrSelectShift & "'")

    End Sub

End Class