Public Class frmSqlGenerator

    Dim StrSvStatus As String = "S"
    Dim StrR_TableID As String = "" : Dim StrR_TableName As String = ""




    Private Sub frmSqlGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _CreateTableStructure()
        cmdRefresh_Click(sender, e)


    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim sqlQRY As String = ""
        Dim bolEx As Boolean = False : Dim bolSave As Boolean = False
        Select Case TabControl1.SelectedIndex
            Case 0
                'Check Existing Record for Added Tables 
                Select Case StrSvStatus
                    Case "S"
                        bolEx = fk_CheckEx("SELECT * FROM tblTableList WHERE T_Name = '" & cmbTableList.Text & "'")
                        If bolEx = True Then MsgBox("Found Same Table in the System, Please Edit Information", MsgBoxStyle.Critical) : Exit Sub
                        sqlQRY = "INSERT INTO tblTableList VALUES ('" & txtTableID.Text & "','" & cmbTableList.Text & "','" & txtTableName.Text & "','" & cmbTableList.Text & "." & cmbTFldList.Text & "' ,0," & chkLinkTable.CheckState & ",'" & txtTableLink.Text & "', " & chkRemove.CheckState & ")"
                        sqlQRY = sqlQRY & " UPDATE tblControl SET NoSQLGenTbl = NoSQLGenTbl + 1"

                    Case "E"
                        sqlQRY = " UPDATE tblTableList SET T_Desc = '" & txtTableName.Text & "',F_Key = '" & cmbTableList.Text & "." & cmbTFldList.Text & "',r_Status = " & chkRemove.CheckState & " WHERE TableID = '" & txtTableID.Text & "'"

                End Select

                bolSave = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
                If bolSave = True Then cmdRefresh_Click(sender, e)
            Case 1
                'Save Information
                If MsgBox("Do you want to save table information ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                sqlQRY = " DELETE FROM tblTableFeildList WHERE TableID = '" & StrR_TableID & "'"
                With dgvAllFldList
                    For i As Integer = 0 To .RowCount - 1
                        sqlQRY = sqlQRY & " INSERT INTO tblTableFeildList VALUES ('" & StrR_TableID & "','" & .Item(1, i).Value & "','" & .Item(2, i).Value & "','" & .Item(3, i).Value & "','" & .Item(4, i).Value & "',CASE WHEN '" & .Item(0, i).Value & "' = 'TRUE' THEN 1 ELSE 0 END)"
                    Next
                End With
                bolSave = FK_EQ(sqlQRY, "S", "", False, True, True)

            Case 2

                Dim StrSelFld As String = ""
                StrSelFld = fk_getGridCLICK(dgvRepSelection, 0, 2)

                Select Case StrSvStatus
                    Case "S"
                        sqlQRY = "INSERT INTO tblQryReportList VALUES ('" & txtReportID.Text & "','" & txtReportName.Text & "','" & StrSelFld & "',''," & chkRemvReport.CheckState & ")"
                        sqlQRY = sqlQRY & " UPDATE tblControl SET NoSQLRepNos = NoSQLRepNos + 1"
                    Case "E"
                        sqlQRY = " UPDATE tblQryReportList SET RepName = '" & txtReportName.Text & "',RepFields  = '" & Replace(txtReportFields.Text, ",", "|") & "',r_Status = " & chkRemvReport.CheckState & " WHERE RepID = '" & txtReportID.Text & "'"
                End Select
                bolSave = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True)
                If bolSave = True Then cmdRefresh_Click(sender, e)
        End Select
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        Dim sqlQRY As String = ""
        'Generate Table ID
        txtTableID.Clear() : txtTableName.Clear() : chkRemove.CheckState = CheckState.Unchecked : txtTableLink.Clear() : chkLinkTable.CheckState = CheckState.Unchecked
        txtTableID.Text = fk_GenSerial("SELECT NoSQLGenTbl FROM tblControl", 3)

        'Load Table List to the Combo
        cmbTableList.Text = ""
        sqlQRY = "SELECT Name FROM sys.Objects WHERE Type = 'U' AND Len(Name) > 3 Order By Name "
        ListCombo(cmbTableList, sqlQRY, "Name")
        cmbTFldList.Items.Clear()
        cmbTFldList.Text = "NONE"
        'Load Added Table List to the Data Grid View

        sqlQRY = "select TableID,T_name,T_Desc,F_Key,r_Status from tblTableList Order By TableID"
        Load_InformationtoGrid(sqlQRY, dgvTableList, 5)

        'Load to Orig Table List 
        sqlQRY = "SELECT 'False',TableID,T_Desc,T_Name FROM tblTableList WHERE r_Status = 0 Order by TableID"
        Load_InformationtoGrid(sqlQRY, dgvAllTableList, 4)

        'Report Adding Screen
        sqlQRY = "SELECT NoSQLRepNos FROM tblControl"
        txtReportID.Text = fk_GenSerial(sqlQRY, 3)
        'List Reports to the Combo

        ListCombo(cmbSavedReports, "select RepName From tblQryReportList where r_Status = 0", "RepName")

        StrSvStatus = "S"

    End Sub

    Private Sub cmbTableList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTableList.SelectedIndexChanged
        Dim sqlQRY As String = ""
        sqlQRY = "SELECT Column_Name FROM INFORMATION_SCHEMA.COLUMNS where Table_Name = '" & cmbTableList.Text & "'"
        cmbTFldList.Text = ""
        ListCombo(cmbTFldList, sqlQRY, "Column_Name")

    End Sub

    Private Sub dgvTableList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvTableList.DoubleClick
        Dim sqlQRY As String = ""
        sqlQRY = "SELECT TableID,T_Name,T_Desc,F_Key,r_Status,IsLinked,LinkFld FROM tblTableList WHERE TableID = '" & dgvTableList.Item(0, dgvTableList.CurrentRow.Index).Value & "'"
        fk_Return_MultyString(sqlQRY, 7)
        txtTableID.Text = fk_ReadGRID(0)
        cmbTableList.Text = fk_ReadGRID(1)
        txtTableName.Text = fk_ReadGRID(2)
        cmbTFldList.Text = fk_ReadGRID(3)
        Dim StrT As String = fk_ReadGRID(3)

        Dim parts As String() = StrT.Split(New Char() {"."c})
        Dim i As Integer = 0
        Dim word As String
        For Each word In parts
            If i = 1 Then
                cmbTFldList.Text = word
            End If
            i = i + 1
        Next

        Dim intChecked As Integer = fk_ReadGRID(4)
        chkRemove.CheckState = intChecked
        Dim intLinked As Integer = fk_ReadGRID(5)
        chkLinkTable.CheckState = intLinked
        txtTableLink.Text = fk_ReadGRID(6)
        StrSvStatus = "E"
    End Sub

    Private Sub dgvAllTableList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAllTableList.Click
        Dim sqlQRY As String = ""

        StrR_TableID = dgvAllTableList.Item(1, dgvAllTableList.CurrentRow.Index).Value
        StrR_TableName = dgvAllTableList.Item(3, dgvAllTableList.CurrentRow.Index).Value

        'Select All Columns
        sqlQRY = "CREATE TABLE #T (TableID Nvarchar (3),FldID Nvarchar (3),Column_Name Nvarchar (100),FullName Nvarchar (200),Fld_Desc Nvarchar (200),R_St Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #T select TableID ='" & StrR_TableID & "',FldID=RIGHT('000'+CAST(ORDINAL_POSITION AS VARCHAR(3)),3),column_name,FullName='" & StrR_TableName & ".'+LTrim(Column_Name),Fld_Desc='',R_St=0 from information_Schema.columns where table_name = '" & StrR_TableName & "'"
        sqlQRY = sqlQRY & " UPDATE #T SET #T.fld_Desc = tblTableFeildList.fld_Desc,#T.R_St = tblTableFeildList.r_Status FROM tblTableFeildList,#T WHERE tblTableFeildList.fld_Name = Column_Name AND tblTableFeildList.TableID = '" & StrR_TableID & "'"
        sqlQRY = sqlQRY & " SELECT CASE WHEN R_St = 0 THEN 'False' Else 'True' END,FldID,Column_Name,FullName,fld_Desc FROM #T Order By fldID"
        FK_LoadGrid(sqlQRY, dgvAllFldList)
    End Sub



    Private Sub dgvAllTableList_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAllTableList.CurrentCellDirtyStateChanged
        If dgvAllTableList.IsCurrentCellDirty Then
            dgvAllTableList.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

 
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim iTabIndex As Integer = 0
        Dim sqlQRY As String = ""
        iTabIndex = TabControl1.SelectedIndex
        Select Case iTabIndex

            Case 0

            Case 1

            Case 2
                'Select Table Control
                sqlQRY = "select 'false',tblTableFeildList.Fld_ID,tblTableFeildList.fld_FullName,tblTableList.T_Name,tblTableList.T_Desc,tblTableFeildList.Fld_Desc From tblTableList,tblTableFeildList " & _
" WHERE tblTableList.TableID = tblTableFeildList.TableID AND tblTableFeildList.r_Status  = 1 Order By tblTableFeildList.TableID,tblTableFeildList.fld_ID"
                Load_InformationtoGrid(sqlQRY, dgvRepSelection, 6)
        End Select
    End Sub

    Private Sub dgvRepSelection_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvRepSelection.CurrentCellDirtyStateChanged
        If dgvRepSelection.IsCurrentCellDirty Then
            dgvRepSelection.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvRepSelection_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRepSelection.CellValueChanged
 

        If dgvRepSelection.Columns(e.ColumnIndex).Name = "DataGridViewCheckBoxColumn1" Then
            Dim count1 As Integer = 0
            Dim StrCurrentFld As String = ""
            Dim StrFullFld As String = ""
            For Each row As DataGridViewRow In dgvRepSelection.Rows
                StrCurrentFld = row.Cells(2).Value
                If row.Cells("DataGridViewCheckBoxColumn1").Value IsNot Nothing And row.Cells("DataGridViewCheckBoxColumn1").Value = True Then
                    If StrFullFld = "" Then StrFullFld = StrCurrentFld Else StrFullFld = StrFullFld + "," & StrCurrentFld
                    count1 += 1
                End If
            Next
            Dim intDBCount As Integer = 0
            txtReportFields.Text = StrFullFld
            'intDBCount = fk_sqlDbl("SELECT AddHC FROM tblOTRequestH WHERE ReqID = '" & txtRequestID.Text & "'")

        End If
    End Sub

    Private Sub cmbSavedReports_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSavedReports.SelectedIndexChanged
        txtReportID.Text = fk_RetString("SELECT RepID FROM tblQryReportList WHERE RepName = '" & cmbSavedReports.Text & "'")

        Dim sqlQRY As String = ""
        sqlQRY = "SELECT RepID,RepName,RepFields FROM tblQryReportList WHERE RepID = '" & txtReportID.Text & "'"
        fk_Return_MultyString(sqlQRY, 3)
        txtReportName.Text = fk_ReadGRID(1)
        txtReportFields.Text = fk_ReadGRID(2)
        fk_SetGridCLICK(dgvRepSelection, 0, 2, txtReportFields.Text)
        txtReportFields.Text = Replace(txtReportFields.Text, "|", ",")
        StrSvStatus = "E"

    End Sub
End Class