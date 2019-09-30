Public Class frmNewOTConfig
    Dim sqlTable As String = ""
    
    Dim intOTLevel As Integer = 0 : Dim intOTType As Integer = 0
    Dim StrSShiftID As String = "" : Dim StrDDayID As String = ""
    Dim StrConfigID As String = "" : Dim intColval As Integer = 0
    Dim StrSvStatus As String = "S"
    Dim intGSep As Integer = 0

    Private Sub frmNewOTConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, pnlTopp, Label13)
        ControlHandlers(Me)

        Dim sqlQRY As String = ""
        sqlQRY = "CREATE TABLE tblOTCal (d_ID Nvarchar (3),ShiftID nvarchar (3),daytypeID nvarchar (2),OTLevel Numeric (18,0),StTime DateTime, StWEF Numeric (18,0),EdDate DateTime , EdWEF numeric (18,0),OTType Numeric (18,0),MaxMin Numeric (18,0),Seq Numeric (18,0),s_Tatus Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "ALTER TABLE tblControl ADD N_OTNos Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "CREATE TABLE tblOTType (TypeID Nvarchar (3),TypeName Nvarchar (20),Num_Code Numeric (18,0),R_Status Numeric (18,0))" : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = "DELETE FROM tblOTType"
        sqlQRY = sqlQRY & " INSERT INTO tblOTType VALUES ('001','Normal OT',0,0)"
        sqlQRY = sqlQRY & " INSERT INTO tblOTType VALUES ('002','Double OT',1,0)"
        sqlQRY = sqlQRY & " INSERT INTO tblOTType VALUES ('003','Triple OT',2,0)"
        sqlQRY = sqlQRY & " INSERT INTO tblOTType VALUES ('004','Extra OT',3,0)"
        'Added Kasun from Isankas code | 2018-11-19***************************
        sqlQRY = sqlQRY & " INSERT INTO tblOTType VALUES ('005','Two & Half OT',4,0)" : FK_EQ(sqlQRY, "S", "", False, False, False)
        'Added Kasun from Isankas code | 2018-11-19***************************

        sqlTable = "ALTER TABLE tblOTCal ADD cMode Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblOTCal ADD StartMin Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblOTCal ADD EndMin Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlTable, "S", "", False, False, False)

        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'Load Items to the Grids
        Dim sqlQRY As String = ""
        sqlQRY = "SELECT TypeID ,TypeName FROM tblDayType WHERE Status = 0 Order By TypeID" : Load_InformationtoGrid(sqlQRY, dgvDayType, 2) : clr_Grid(dgvDayType)
        sqlQRY = "SELECT ShiftID,ShiftID as Code,ShiftName FROM tblSetShiftH WHERE Status = 0 Order By ShiftID" : Load_InformationtoGrid(sqlQRY, dgvShifts, 3) : clr_Grid(dgvShifts)
        sqlQRY = "SELECT * FROM tblOTType WHERE R_Status = 0 Order By TypeID" : ListCombo(cmbOTType, sqlQRY, "TypeName")
        sqlQRY = "SELECT * FROM tblOTType WHERE R_Status = 0 Order By TypeID" : ListCombo(cmbmOTType, sqlQRY, "TypeName")
        StrConfigID = fk_CreateSerial(3, fk_sqlDbl("SELECT N_OTNos FROM tblControl") + 1)

        sqlQRY = "SELECT * FROM tblSetShiftH WHERE Status = 0 AND ShiftID <> '" & StrSShiftID & "'" : ListCombo(cmbShiftData, sqlQRY, "ShiftName")

        StrSvStatus = "S"
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub dgvShifts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvShifts.Click
        StrSShiftID = dgvShifts.Item(0, dgvShifts.CurrentRow.Index).Value
        _LoadShiftData(StrSShiftID, StrDDayID, intGSep)
    End Sub

    Private Sub dgvDayType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDayType.Click
        StrDDayID = dgvDayType.Item(0, dgvDayType.CurrentRow.Index).Value
        _LoadShiftData(StrSShiftID, StrDDayID, intGSep)
    End Sub

    Public Sub _LoadShiftData(ByVal StrSID As String, ByVal StrDID As String, ByVal intSep As Integer)
        Dim sqlQRY As String = ""
        Select Case intSep
            Case 0
                sqlQRY = "select tblOTCal.d_ID,tblDayType.TypeName,tblSetShiftH.ShiftName,CASE WHEN tblOTCal.OTLevel = 0 THEN 'Begin OT' ELSE 'End OT' END,Convert(Nvarchar(5),StTime,108),Convert(Nvarchar(5),EdDate,108),tblOTType.TypeName FROM " & _
" tblOTCal,tblDayType,tblSetShiftH,tblOTType WHERE tblOTCal.ShiftID = tblSetShiftH.ShiftID AND tblOTCal.DayTypeID = tblDayType.TypeID AND  tblOTCal.OTType = tblOTType.Num_Code AND tblOTCal.ShiftID LIKE '%" & StrSID & "%' AND tblOTCal.DayTypeID LIKE '%" & StrDID & "%' AND tblOTCal.cMode = " & intGSep & " Order By tblOTCal.Seq"
                Load_InformationtoGrid(sqlQRY, dgvDetails, 7) : clr_Grid(dgvDetails)

            Case 1
                sqlQRY = "select tblOTCal.d_ID,tblDayType.TypeName,tblSetShiftH.ShiftName,CASE WHEN tblOTCal.OTLevel = 0 THEN 'Begin OT' ELSE 'End OT' END,StartMin,EndMin,tblOTType.TypeName FROM " & _
" tblOTCal,tblDayType,tblSetShiftH,tblOTType WHERE tblOTCal.ShiftID = tblSetShiftH.ShiftID AND tblOTCal.DayTypeID = tblDayType.TypeID AND  tblOTCal.OTType = tblOTType.Num_Code AND tblOTCal.ShiftID LIKE '%" & StrSID & "%' AND tblOTCal.DayTypeID LIKE '%" & StrDID & "%' AND tblOTCal.cMode = " & intGSep & " Order By tblOTCal.Seq"
                Load_InformationtoGrid(sqlQRY, dgvMinData, 7) : clr_Grid(dgvMinData)

        End Select
        
       
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If StrSShiftID = "" Then MsgBox("Please select Shift", MsgBoxStyle.Information) : Exit Sub
        If StrDDayID = "" Then MsgBox("Please select day type", MsgBoxStyle.Information) : Exit Sub
        intOTLevel = cmbOTLevel.SelectedIndex
        intOTType = fk_sqlDbl("SELECT Num_Code FROM tblOTType WHERE TypeName = '" & cmbOTType.Text & "'")

        Dim sqlQRY As String = ""


        Dim intWMinute As Integer = DateDiff(DateInterval.Minute, DateAdd(DateInterval.Day, chkWStart.CheckState, dtpStart.Value), DateAdd(DateInterval.Day, chkWEnd.CheckState, dtpEnd.Value))
        intColval = dgvDetails.RowCount + 1

        Select Case StrSvStatus
            Case "S"
                StrConfigID = fk_CreateSerial(3, fk_sqlDbl("SELECT N_OTNos FROM tblControl") + 1)
                If MsgBox("Do you want to save above information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sqlQRY = "UPDATE tblCOntrol SET N_OTNos = N_OTnos + 1"
                sqlQRY = sqlQRY & " INSERT INTO tblOTCal values ('" & StrConfigID & "','" & StrSShiftID & "','" & StrDDayID & "'," & intOTLevel & ", " & _
                " '" & Format(dtpStart.Value, "hh:mm:ss tt") & "'," & chkWStart.CheckState & ",'" & Format(dtpEnd.Value, "hh:mm:ss tt") & "'," & chkWEnd.CheckState & "," & intOTType & "," & intWMinute & "," & intColval & ",0,0,0,0)"

            Case "E"
                If MsgBox("Do you want to modify Infomation", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sqlQRY = " UPDATE tblOTCal SEt ShiftID = '" & StrSShiftID & "' ,daytypeID = '" & StrDDayID & "',OTLevel = " & intOTLevel & ", " & _
                " StTime = '" & Format(dtpStart.Value, "hh:mm:ss tt") & "',StWEF = " & chkWStart.CheckState & " ,EdDate = '" & Format(dtpEnd.Value, "hh:mm:ss tt") & "', " & _
                " EdWEF = " & chkWEnd.CheckState & " ,OTType = " & intOTType & ",MaxMin = " & intWMinute & "  WHERE d_ID = '" & StrConfigID & "'"

        End Select

        FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        _LoadShiftData(StrSShiftID, StrDDayID, intGSep)

    End Sub

    Private Sub dgvDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetails.DoubleClick
        Dim sqlQRY As String = ""
        With dgvDetails
            StrConfigID = .Item(0, .CurrentRow.Index).Value

        End With
        Try
            sqlQRY = "select tblOTCal.d_ID,tblDayType.TypeName,tblSetShiftH.ShiftName,tblOTCal.OTLevel,tblOtCal.StTime,tblOtCal.EdDate,tblOTType.TypeName,tblOTCal.stWEF,tblOTCal.EdWEF FROM " & _
" tblOTCal,tblDayType,tblSetShiftH,tblOTType WHERE tblOTType.Num_Code = tblOTCal.OTType AND tblOTCal.ShiftID = tblSetShiftH.ShiftID AND tblOTCal.DayTypeID = tblDayType.TypeID AND tblOTCal.d_ID = '" & StrConfigID & "'"
            fk_Return_MultyString(sqlQRY, 9)
            intOTLevel = fk_ReadGRID(3)
            cmbOTLevel.SelectedIndex = intOTLevel
            dtpStart.Value = fk_ReadGRID(4)
            dtpEnd.Value = fk_ReadGRID(5)
            cmbOTType.Text = fk_ReadGRID(6)
            chkWStart.CheckState = fk_ReadGRID(7)
            chkWEnd.CheckState = fk_ReadGRID(8)
            StrSvStatus = "E"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If dgvDetails.RowCount = 0 Then
            MsgBox("Please Add Items First and Then Try to Order Them.")
            Exit Sub
        End If

        If dgvDetails.CurrentRow.Index <> 0 Then
            MoveRow(-1)

        End If

    End Sub

    Private Sub MoveRow(ByVal i As Integer)
        Select Case intGSep
            Case 0
                Try
                    If (Me.dgvDetails.SelectedCells.Count > 0) Then  ' And (Me.dgv1.RowCount - 1 <> Me.dgv1.CurrentRow.Index)
                        Dim curr_index As Integer = Me.dgvDetails.CurrentCell.RowIndex
                        Dim curr_col_index As Integer = Me.dgvDetails.CurrentCell.ColumnIndex
                        Dim curr_row As DataGridViewRow = Me.dgvDetails.CurrentRow
                        Me.dgvDetails.Rows.Remove(curr_row)
                        Me.dgvDetails.Rows.Insert(curr_index + i, curr_row)
                        Me.dgvDetails.CurrentCell = Me.dgvDetails(curr_col_index, curr_index + i)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ' do nothing if error encountered while trying to move the row up or down

                End Try
            Case 1
                Try
                    If (Me.dgvMinData.SelectedCells.Count > 0) Then  ' And (Me.dgv1.RowCount - 1 <> Me.dgv1.CurrentRow.Index)
                        Dim curr_index As Integer = Me.dgvMinData.CurrentCell.RowIndex
                        Dim curr_col_index As Integer = Me.dgvMinData.CurrentCell.ColumnIndex
                        Dim curr_row As DataGridViewRow = Me.dgvMinData.CurrentRow
                        Me.dgvMinData.Rows.Remove(curr_row)
                        Me.dgvMinData.Rows.Insert(curr_index + i, curr_row)
                        Me.dgvMinData.CurrentCell = Me.dgvMinData(curr_col_index, curr_index + i)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    ' do nothing if error encountered while trying to move the row up or down

                End Try
        End Select
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If dgvDetails.RowCount = 0 Then
            MsgBox("Please Add Items First and Then Try to Order Them.")
            Exit Sub
        End If
        If (Me.dgvDetails.RowCount - 1 = Me.dgvDetails.CurrentRow.Index) Then
            Exit Sub
        End If

        MoveRow(1)


    End Sub

    Private Sub cmdReorder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReorder.Click
        If MsgBox("Do you want to Re-Order Details", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        _ReOrder()
    End Sub

    'Public Sub _CopyToNew()
    '    Dim sqlQRY As String = ""
    '    If MsgBox("Do you want to Copy ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '    sqlQRY = 

    'End Sub
    Public Sub _ReOrder()
        Dim sqlQRY As String = ""
        Select Case intGSep
            Case 0
                With dgvDetails
                    For i As Integer = 0 To .RowCount - 1
                        StrConfigID = .Item(0, i).Value
                        sqlQRY = sqlQRY & " UPDATE tblOTCal SET Seq = " & i + 1 & " WHERE d_ID = '" & StrConfigID & "'"
                    Next
                End With
            Case 1
                With dgvMinData
                    For i As Integer = 0 To .RowCount - 1
                        StrConfigID = .Item(0, i).Value
                        sqlQRY = sqlQRY & " UPDATE tblOTCal SET Seq = " & i + 1 & " WHERE d_ID = '" & StrConfigID & "'"
                    Next
                End With
        End Select

        FK_EQ(sqlQRY, "S", "", False, True, True)
    End Sub

    Private Sub cmdcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcopy.Click
        Dim StrCrShift As String = ""
        StrCrShift = fk_RetString("SELECT ShiftID FROM tblSetShiftH WHERE ShiftName = '" & cmbShiftData.Text & "'")
        If StrCrShift = "" Then MsgBox("Please select Desitination Shift", MsgBoxStyle.Information) : Exit Sub
        If StrSShiftID = "" Then MsgBox("Please select Source Shift", MsgBoxStyle.Information) : Exit Sub
        Dim StrRConfigID As String = ""
        Dim sqlQRY As String = ""
        sqlQRY = "DELETE FROM tblOTCal WHERE ShiftID = '" & StrCrShift & "' AND DayTypeID = '" & StrDDayID & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)
        With dgvDetails
            For i As Integer = 0 To .RowCount - 1
                StrRConfigID = .Item(0, i).Value
                StrConfigID = fk_CreateSerial(3, fk_sqlDbl("SELECT N_OTNos FROM tblControl") + 1)
                sqlQRY = " UPDATE tblCOntrol SET N_OTNos = N_OTnos + 1"
                sqlQRY = sqlQRY & " INSERT INTO tblOTCal SELECT '" & StrConfigID & "','" & StrCrShift & "',daytypeID,OTLevel,StTime,StWEF,EdDate,EdWEF,OTType,MaxMin,Seq,s_Tatus FROM tblOTCal WHERE d_ID = '" & StrRConfigID & "'"
                FK_EQ(sqlQRY, "S", "", False, False, True)
            Next
        End With
        MsgBox("Information Copied", MsgBoxStyle.Information)

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim sqlQRY As String = ""
        If MsgBox("Do you want to delete " & StrConfigID & ".", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        sqlQRY = "DELETE FROM tblOTCal WHERE d_ID = '" & StrConfigID & "'" : FK_EQ(sqlQRY, "D", "", False, True, True)
        _LoadShiftData(StrSShiftID, StrDDayID, intGSep)
    End Sub

    Private Sub dgvDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetails.Click
        StrConfigID = dgvDetails.Item(0, dgvDetails.CurrentRow.Index).Value

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGSave.Click
        If txtStartMin.Text = "" Then MsgBox("Enter Value for Start Minutes", MsgBoxStyle.Information) : Exit Sub
        If txtEndMins.Text = "" Then MsgBox("Enter Value for End Minutes", MsgBoxStyle.Information) : Exit Sub
        If StrSShiftID = "" Then MsgBox("Please select Shift", MsgBoxStyle.Information) : Exit Sub
        If StrDDayID = "" Then MsgBox("Please select day type", MsgBoxStyle.Information) : Exit Sub

        Select Case intGSep
            Case 0
                intOTLevel = cmbOTLevel.SelectedIndex
                intOTType = fk_sqlDbl("SELECT Num_Code FROM tblOTType WHERE TypeName = '" & cmbOTType.Text & "'")
            Case 1
                intOTLevel = cmbmOTLev.SelectedIndex
                intOTType = fk_sqlDbl("SELECT Num_Code FROM tblOTType WHERE TypeName = '" & cmbmOTType.Text & "'")
        End Select


        Dim sqlQRY As String = ""


        Dim intWMinute As Integer = DateDiff(DateInterval.Minute, DateAdd(DateInterval.Day, chkWStart.CheckState, dtpStart.Value), DateAdd(DateInterval.Day, chkWEnd.CheckState, dtpEnd.Value))
        intColval = dgvDetails.RowCount + 1

        Select Case StrSvStatus
            Case "S"
                StrConfigID = fk_CreateSerial(3, fk_sqlDbl("SELECT N_OTNos FROM tblControl") + 1)
                If MsgBox("Do you want to save above information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sqlQRY = "UPDATE tblCOntrol SET N_OTNos = N_OTnos + 1"
                sqlQRY = sqlQRY & " INSERT INTO tblOTCal values ('" & StrConfigID & "','" & StrSShiftID & "','" & StrDDayID & "'," & intOTLevel & ", " & _
                " '',0,'',0," & intOTType & "," & CInt(txtEndMins.Text) & "," & intColval & ",0,1," & CInt(txtStartMin.Text) & "," & CInt(txtEndMins.Text) & ")"

            Case "E"
                If MsgBox("Do you want to modify Infomation", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sqlQRY = " UPDATE tblOTCal SEt ShiftID = '" & StrSShiftID & "' ,daytypeID = '" & StrDDayID & "',OTLevel = " & intOTLevel & ", " & _
                " StTime = '',StWEF = 0 ,EdDate = '', " & _
                " EdWEF = 0 ,OTType = " & intOTType & ",MaxMin = " & intWMinute & ",StartMin = " & CInt(txtStartMin.Text) & ",EndMin = " & CInt(txtEndMins.Text) & "  WHERE d_ID = '" & StrConfigID & "'"

        End Select

        FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
        _LoadShiftData(StrSShiftID, StrDDayID, intGSep)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        intGSep = TabControl1.SelectedIndex
    End Sub

    Private Sub dgvMinData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMinData.DoubleClick
        Dim sqlQRY As String = ""
        With dgvMinData
            StrConfigID = .Item(0, .CurrentRow.Index).Value

        End With
        Try
            sqlQRY = "select tblOTCal.d_ID,tblDayType.TypeName,tblSetShiftH.ShiftName,tblOTCal.OTLevel,tblOtCal.StartMin,tblOtCal.EndMin,tblOTType.TypeName FROM " & _
" tblOTCal,tblDayType,tblSetShiftH,tblOTType WHERE tblOTType.Num_Code = tblOTCal.OTType AND tblOTCal.ShiftID = tblSetShiftH.ShiftID AND tblOTCal.DayTypeID = tblDayType.TypeID AND tblOTCal.d_ID = '" & StrConfigID & "'"
            fk_Return_MultyString(sqlQRY, 7)
            intOTLevel = fk_ReadGRID(3)
            cmbmOTLev.SelectedIndex = intOTLevel
            txtStartMin.Text = fk_ReadGRID(4)
            txtEndMins.Text = fk_ReadGRID(5)
            cmbmOTType.Text = fk_ReadGRID(6)
            StrSvStatus = "E"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If dgvMinData.RowCount = 0 Then
            MsgBox("Please Add Items First and Then Try to Order Them.")
            Exit Sub
        End If

        If dgvMinData.CurrentRow.Index <> 0 Then
            MoveRow(-1)

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If dgvMinData.RowCount = 0 Then
            MsgBox("Please Add Items First and Then Try to Order Them.")
            Exit Sub
        End If
        If (Me.dgvMinData.RowCount - 1 = Me.dgvMinData.CurrentRow.Index) Then
            Exit Sub
        End If

        MoveRow(1)
    End Sub

End Class