Public Class frmConfigLeaveProf
    Dim StrPrfCID As String = "" ' Profile Configuration Number 
    Dim StrSvStatus As String = "S"
    Dim StrLCatID As String = "" : Dim StrLType As String = "" : Dim StrLPrfID As String = "" : Dim StrLLeaveID As String = ""
    Dim StrlvProfileID As String = "" : Dim intLLocation As Integer = 0


    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        ListComboAll(cmbcategory, "SELECT * FROM tblSetEmpCategory WHERE status = 0 Order By CatID", "CatDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType order by tDesc asc", "tDesc")
        ListComboAll(cmbLeaveType, "select * from tblLeaveType order by lvID asc", "lvDesc")
        'Create Profile Configuration Number 
        StrPrfCID = fk_GenSerial("SELECT NoLPrfConfig FROM tblControl", 4)

        txtEnd.Text = "0"
        txtStart.Text = "0"
        txtEntQty.Text = "0"
        With cmbEffMeth
            .Items.Clear()
            .Items.Add("Monthly Increasing")
            .Items.Add("Full Entitlement Effect")
            .SelectedIndex = 0
        End With

        With cmbEntLeave
            .Items.Clear()
            .Items.Add("Monthly Increasing")
            .Items.Add("Full Entitlement Effect")
            .SelectedIndex = 0
        End With
        'Add Months
        cmbStartMonth.Items.Clear()
        cmbEndMonth.Items.Clear()

        For i As Integer = 1 To 12
            cmbStartMonth.Items.Add(MonthName(i))
            cmbEndMonth.Items.Add(MonthName(i))
        Next
        cmbStartMonth.SelectedIndex = 0
        cmbEndMonth.SelectedIndex = 1
        fk_LoadConfigToGrid()
        StrSvStatus = "S"
    End Sub

    Private Sub frmConfigLeaveProf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqlQRY As String = ""
        fk_CreateLvRelatedTables()
        'ALTER tblControl to Add profile configuration number 
        sqlQRY = "ALTER TABLE tblControl ADD NoLPrfConfig Numeric (18,0) NOT NULL Default 0" : FK_EQ(sqlQRY, "S", "", False, False, False)
        cmdRefresh_Click(sender, e)

    End Sub

    Public Function fk_LoadConfigToGrid() As Boolean
        Dim bolRet As Boolean = False
        StrLCatID = fk_RetString("SELECT CatID from tblsetEmpCategory WHERE CatDesc = '" & cmbcategory.Text & "'")
        StrLType = fk_RetString("SELECT TypeID from tblSetEmpType WHERE tDesc = '" & cmbType.Text & "'")
        StrLLeaveID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbLeaveType.Text & "'")

        Dim sqlQRY As String = ""
        sqlQRY = "select tblLvPrfTerms.TrID,tblLeaveType.lvDesc,tblSetEmpCategory.CatDesc,tblSetEmpType.tDesc,tblLvPrfTerms.St_Month,tblLvPrfTerms.Ed_Month,tblLvPrfTerms.Lv_Entlment,tblLvPrfTerms.r_status " & _
 " FROM tblLvPrfTerms,tblLeaveType,tblSetEmpCategory,tblSetEmpType WHERE tblLvPrfTerms.LeaveID = tblLeaveType.lvID AND tblLvPrfTerms.EmpTypeID = tblSetEmpType.TypeID AND tblLvPrfTerms.EmpCatID = tblSetEmpCategory.CatID AND " & _
" (tblLvPrfTerms.EmpCatID LIKE '%" & StrLCatID & "%' OR tblLvPrfTerms.EmpTypeID LIKE '%" & StrLType & "%' OR tblLvPrfTerms.LeaveID LIKE '%" & StrLLeaveID & "%' ) AND tblLvPrfTerms.LLocation = 0"
        Load_InformationtoGrid(sqlQRY, dgvData, 8)

        sqlQRY = "select tblLvPrfTerms.TrID,tblLeaveType.lvDesc,tblSetEmpCategory.CatDesc,tblSetEmpType.tDesc,tblLvPrfTerms.St_Month,tblLvPrfTerms.Ed_Month,tblLvPrfTerms.Lv_Entlment,tblLvPrfTerms.r_status " & _
" FROM tblLvPrfTerms,tblLeaveType,tblSetEmpCategory,tblSetEmpType WHERE tblLvPrfTerms.LeaveID = tblLeaveType.lvID AND tblLvPrfTerms.EmpTypeID = tblSetEmpType.TypeID AND tblLvPrfTerms.EmpCatID = tblSetEmpCategory.CatID AND " & _
" (tblLvPrfTerms.EmpCatID LIKE '%" & StrLCatID & "%' OR tblLvPrfTerms.EmpTypeID LIKE '%" & StrLType & "%' OR tblLvPrfTerms.LeaveID LIKE '%" & StrLLeaveID & "%') AND tblLvPrfTerms.LLocation = 1"
        Load_InformationtoGrid(sqlQRY, dgvMMData, 8)

        Return bolRet
    End Function

    Public Function fk_ReturnExLeave(ByVal TypeID As String, ByVal CatID As String, ByVal LeaveID As String) As Boolean
        Dim bolExists As Boolean = False
        Try
            bolExists = fk_CheckEx("SELECT * FROM tblLvPrfTerms WHERE EmpCatID = '" & CatID & "' AND EmpTypeID = '" & TypeID & "' AND LeaveID = '" & LeaveID & "'")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return bolExists
    End Function

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        intLLocation = TabControl1.SelectedIndex
        Dim intCLStart As Integer = 0
        Dim intCLEnd As Integer = 0
        Dim bolExLeave As Boolean = False

        'Get the Selected Number 
        Dim sqlQRY As String = ""
        Dim StrMsgText As String = ""
        intCLStart = cmbStartMonth.SelectedIndex + 1
        intCLEnd = cmbEndMonth.SelectedIndex + 1
        Select Case intLLocation
            Case 0
                StrLCatID = fk_RetString("SELECT CatID from tblsetEmpCategory WHERE CatDesc = '" & cmbcategory.Text & "'")
                StrLType = fk_RetString("SELECT TypeID from tblSetEmpType WHERE tDesc = '" & cmbType.Text & "'")
                StrLLeaveID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbLeaveType.Text & "'")
                bolExLeave = fk_ReturnExLeave(StrLType, StrLCatID, StrLLeaveID)
                If bolExLeave = True Then MsgBox("You Can't Add duplicate Entry !!!", MsgBoxStyle.Exclamation) : Exit Sub

                If StrLCatID = "" Or StrLType = "" Or StrLLeaveID = "" Then
                    MsgBox("Please select main parameters", MsgBoxStyle.Information) : Exit Sub

                End If
                If txtStart.Text = "" Then txtStart.Text = "0"
                If txtEnd.Text = "" Then txtEnd.Text = "0"
                If txtEntQty.Text = "" Then txtEntQty.Text = "0"

                Try
                    Select Case StrSvStatus
                        Case "S"
                            sqlQRY = "INSERT INTO tblLvPrfTerms VALUES ('" & StrPrfCID & "','" & StrLCatID & "','" & StrLType & "','" & StrLLeaveID & "', " & CDbl(txtStart.Text) & "," & CDbl(txtEnd.Text) & ", " & cmbEffMeth.SelectedIndex & ", " & CDbl(txtEntQty.Text) & "," & intLLocation & "," & chkMStatus.CheckState & ")"
                            sqlQRY = sqlQRY & " UPDATE tblControl SET NoLPrfConfig = NoLPrfConfig + 1"
                            StrMsgText = "Do You want to Save Data ?"
                        Case "E"
                            sqlQRY = "UPDATE tblLvPrfTerms SET EmpCatID = '" & StrLCatID & "',EmpTypeID = '" & StrLType & "', LeaveID = '" & StrLLeaveID & "',St_month =" & CDbl(txtStart.Text) & ", Ed_Month = " & CDbl(txtEnd.Text) & ",IsMonthlyLv = " & CDbl(cmbEffMeth.SelectedIndex) & ", Lv_Entlment = " & CDbl(txtEntQty.Text) & ",r_Status = " & chkMStatus.CheckState & ""
                            StrMsgText = "Do you update Data ?"
                    End Select
                    Dim bolSave As Boolean = False
                    If MsgBox(StrMsgText, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        bolSave = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
                    End If
                    If bolSave = True Then cmdRefresh_Click(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Case 1

                StrLCatID = fk_RetString("SELECT CatID from tblsetEmpCategory WHERE CatDesc = '" & cmbcategory.Text & "'")
                StrLType = fk_RetString("SELECT TypeID from tblSetEmpType WHERE tDesc = '" & cmbType.Text & "'")
                StrLLeaveID = fk_RetString("SELECT LvID FROM tblLeaveType WHERE lvDesc = '" & cmbLeaveType.Text & "'")
                bolExLeave = fk_ReturnExLeave(StrLType, StrLCatID, StrLLeaveID)
                If StrLCatID = "" Or StrLType = "" Then
                    MsgBox("Please select main parameters", MsgBoxStyle.Information) : Exit Sub

                End If

                If txtLvQty.Text = "" Then txtEntQty.Text = "0"

                Try
                    Select Case StrSvStatus
                        Case "S"
                            sqlQRY = "INSERT INTO tblLvPrfTerms VALUES ('" & StrPrfCID & "','" & StrLCatID & "','" & StrLType & "','" & StrLLeaveID & "', " & intCLStart & "," & intCLEnd & ", " & cmbEntLeave.SelectedIndex & ", " & CDbl(txtLvQty.Text) & "," & intLLocation & "," & chkStatus.CheckState & ")"
                            sqlQRY = sqlQRY & " UPDATE tblControl SET NoLPrfConfig = NoLPrfConfig + 1"
                            StrMsgText = "Do You want to Save Data ?"
                        Case "E"
                            StrPrfCID = dgvMMData.Item(0, dgvMMData.CurrentRow.Index).Value
                            If StrPrfCID = "" Then MsgBox("Please Select the existing Leave Detail !!!", MsgBoxStyle.Information) : Exit Sub
                            sqlQRY = "UPDATE tblLvPrfTerms SET EmpCatID = '" & StrLCatID & "',EmpTypeID = '" & StrLType & "', LeaveID = '" & StrLLeaveID & "',St_month =" & intCLStart & ", Ed_Month = " & intCLEnd & ",IsMonthlyLv = " & CDbl(cmbEntLeave.SelectedIndex) & ", Lv_Entlment = " & CDbl(txtLvQty.Text) & ",r_Status = " & chkStatus.CheckState & " WHERE TrID = '" & StrPrfCID & "'"
                            StrMsgText = "Do you update Data ?"
                    End Select
                    Dim bolSave As Boolean = False
                    'Remove All removed status from the Database
                    'sqlQRY = sqlQRY & " DELETE FROM tblLvPrfTerms WHERE r_Status = 1"
                    If MsgBox(StrMsgText, MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        bolSave = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
                    End If
                    If bolSave = True Then cmdRefresh_Click(sender, e)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
        End Select

    End Sub

    Private Sub cmbProfName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'fk_LoadConfigToGrid()
    End Sub

    Private Sub cmbcategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcategory.SelectedIndexChanged
        'fk_LoadConfigToGrid()
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        'fk_LoadConfigToGrid()
    End Sub

    Private Sub cmbLeaveType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLeaveType.SelectedIndexChanged
        'fk_LoadConfigToGrid()
    End Sub

    Private Sub dgvMMData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMMData.DoubleClick
        Dim sqlQRY As String = ""
        Dim StrGetID As String = ""
        StrGetID = dgvMMData.Item(0, dgvMMData.CurrentRow.Index).Value
        sqlQRY = " SELECT TrID,tblSetEmpCategory.CatDesc,tblLvPrfTerms.EmpCatID,tblLvPrfTerms.EmpTypeID,tblSetEmpType.tDesc, " & _
" tblLeaveType.LvDesc,tblLvPrfTerms.LeaveID,tblLvPrfTerms.St_month,tblLvPrfTerms.Ed_Month,tblLvPrfTerms.IsMonthlyLv,tblLvPrfTerms.Lv_Entlment FROM tblLvPrfTerms,tblSetEmpCategory,tblSetEmpType,tblLeaveType " & _
        " where tblLvPrfTerms.EmpCatID = tblSetEmpCategory.CatID And tblLvPrfTerms.EmpTypeID = tblSetEmpType.TypeID And tblLvPrfTerms.LeaveID = tblLeaveType.lvID And tblLvPrfTerms.LLOcation = 1 AND TrID = '" & StrGetID & "'"

        fk_Return_MultyString(sqlQRY, 11)
        cmbcategory.Text = fk_ReadGRID(1)
        cmbType.Text = fk_ReadGRID(4)
        cmbLeaveType.Text = fk_ReadGRID(5)
        Dim intStMnth As Integer = Val(fk_ReadGRID(7))
        cmbStartMonth.Text = MonthName(IIf(Val(fk_ReadGRID(7)) = 0, 1, Val(fk_ReadGRID(7))))
        cmbEndMonth.Text = MonthName(IIf(Val(fk_ReadGRID(8)) = 0, 1, Val(fk_ReadGRID(8))))
        cmbEntLeave.SelectedIndex = IIf(Val(fk_ReadGRID(9)) = 0, 1, Val(fk_ReadGRID(9)))
        txtLvQty.Text = fk_ReadGRID(10)

        StrSvStatus = "E"


    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        Dim sqlQRY As String = ""
        Dim StrGetID As String = ""
        StrGetID = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        sqlQRY = " SELECT TrID,tblSetEmpCategory.CatDesc,tblLvPrfTerms.EmpCatID,tblLvPrfTerms.EmpTypeID,tblSetEmpType.tDesc, " & _
 " tblLeaveType.LvDesc,tblLvPrfTerms.LeaveID,tblLvPrfTerms.St_month,tblLvPrfTerms.Ed_Month,tblLvPrfTerms.IsMonthlyLv,tblLvPrfTerms.Lv_Entlment FROM tblLvPrfTerms,tblSetEmpCategory,tblSetEmpType,tblLeaveType " & _
         " where tblLvPrfTerms.EmpCatID = tblSetEmpCategory.CatID And tblLvPrfTerms.EmpTypeID = tblSetEmpType.TypeID And tblLvPrfTerms.LeaveID = tblLeaveType.lvID And tblLvPrfTerms.LLOcation = 0 AND TrID = '" & StrGetID & "'"

        fk_Return_MultyString(sqlQRY, 11)
        cmbcategory.Text = fk_ReadGRID(1)
        cmbType.Text = fk_ReadGRID(4)
        cmbLeaveType.Text = fk_ReadGRID(5)
        txtStart.Text = fk_ReadGRID(7)
        txtEnd.Text = fk_ReadGRID(8)
        txtEntQty.Text = fk_ReadGRID(10)
        cmbEffMeth.SelectedIndex = CInt(fk_ReadGRID(9))


    End Sub

    Private Sub cmdCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCopy.Click
        Dim StrSCatID As String = ""
        StrSCatID = fk_RetString("SELECT catID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbcategory.Text & "'")
        dgvCopy.Visible = True
        cmdPrcCopy.Visible = True
        Dim sqlQRY As String = ""
        'Load to Grid 
        sqlQRY = "select CatID,CatDesc,'False' From tblSetEmpCategory WHERE catID <> '" & StrSCatID & "' AND Status =0"
        Load_InformationtoGrid(sqlQRY, dgvCopy, 3)

    End Sub

    Private Sub cmdPrcCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrcCopy.Click
        If MsgBox("Do you want to process Copy ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        Dim StrSCatID As String = ""
        StrSCatID = fk_RetString("SELECT catID FROM tblSetEmpCategory WHERE CatDesc = '" & cmbcategory.Text & "'")
        Dim sqlQRY As String = ""
        Dim StrDCatID As String = ""
        Dim bolSelected As Boolean = False
        With dgvCopy
            For i As Integer = 0 To .RowCount - 1
                StrDCatID = .Item(0, i).Value
                bolSelected = .Item(2, i).Value
                If bolSelected = True Then
                    sqlQRY = " Exec sp_CopyLeaveStructure '" & StrDCatID & "','" & StrSCatID & "'," & TabControl1.SelectedIndex & ""
                    FK_EQ(sqlQRY, "S", "", False, False, True)
                End If
            Next
            MsgBox("Information Copied", MsgBoxStyle.Information)
        End With
        dgvCopy.Visible = False
        cmdPrcCopy.Visible = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        sSQL = " DELETE FROM tblLvPrfTerms WHERE r_Status = 1" : FK_EQ(sSQL, "S", "", False, False, True)
    End Sub

End Class