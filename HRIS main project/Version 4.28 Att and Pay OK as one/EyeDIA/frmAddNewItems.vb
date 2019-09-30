Imports System.Data.SqlClient

Public Class frmAddNewItems
    'New Form to keep transaction changes in each main codes 
    Dim StrNCode As String = "" : Dim StrEDescT As String = ""
    Dim StrTFldName, StrTTable, StrTSrcID, StrTSrcDesc As String
    Dim StrSvStatus As String = "S"
    Dim sqlQRY As String = ""

    Private Sub refh()
        CenterFormThemed(Me, pnlTop, lblTitle)
        ControlHandlers(Me)


        Dim sqlQ As String = ""

        sqlQ = "Select ERef,EDesc,ESDesc,EUsers,mTable,SchID,SchDesc FROM tblAddSeq WHERE ERef = '" & StrTTrMode & "'"
        fk_Return_MultyString(sqlQ, 7) : StrEDescT = fk_ReadGRID(1) : StrTFldName = fk_ReadGRID(3) : StrTTable = fk_ReadGRID(4) : StrTSrcID = fk_ReadGRID(5) : StrTSrcDesc = fk_ReadGRID(6)
        lblTitle.Text = fk_ReadGRID(1)

        sSQL = "select " & StrTSrcID & "," & StrTSrcDesc & " from " & StrTTable & " ORDER BY " & StrTSrcID & ""
        Load_InformationtoGrid(sSQL, dgvData, 2)

        txtID.Text = fk_GenSerial("SELECT MAX(" & StrTSrcID & ") FROM " & StrTTable & "", 3)

    End Sub

    'Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Close()
    'End Sub

    'Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    '    If StrNCode = "" Then MsgBox("Please Select New Code") : Exit Sub
    '    If strExsistedCode = StrNCode Then MessageBox.Show("There is no different with your exsisted data, Please retry", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
    '    If StrEmployeeID = "" Then MsgBox("No Employee Information found", MsgBoxStyle.Information) : Exit Sub
    '    Dim StrNDesc As String = ""
    '    StrNDesc = StrEDescT & " to " & StrNCode
    '    'Get the Transaction ID 
    '    Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
    '    Dim sqlQRY As String = ""
    '    'Update tblEmployee table 
    '    sqlQRY = "UPDATE tblEmployee SET " & StrTFldName & " = '" & StrNCode & "'  WHERE RegID = '" & StrEmployeeID & "'"
    '    'Insert Detail to the Transaction Table 
    '    sqlQRY = sqlQRY & " INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
    '    " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & StrNCode & "','" & StrNDesc & "','" & StrTTrMode & "','" & txtDescription.Text & "','" & StrUserID.Substring(0, 3) & "','" & Format(dtpTrDate.Value, "yyyyMMdd") & "', '" & strExsisted & "','" & strExsistedCode & "')"
    '    'Update tblControl Table 
    '    sqlQRY = sqlQRY & " UPDATE tblControl SET cTrCount = cTrCount + 1"

    '    Dim bolSave As Boolean = False
    '    bolSave = FK_EQ(sqlQRY, "S", "", False, True, True) : If bolSave = True Then Me.Close()
    '    strNewCode = fk_RetString("SELECT " & StrTSrcDesc & " FROM " & StrTTable & " WHERE " & StrTSrcID & "='" & Trim(StrNCode) & "'")
    '    'frmEmployeeInfo.pb_ShowEmployee(StrEmployeeID)
    'End Sub

    'Private Sub cmbDetail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetail.SelectedIndexChanged
    '    StrNCode = fk_RetString("SELECT " & StrTSrcID & " FROM " & StrTTable & " WHERE " & StrTSrcDesc & " = '" & cmbDetail.Text & "'")
    'End Sub

    'Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sqlQ As String = "Select tblCodeTrHist.EmpID,tblCodeTrHist.TrDate,tblCodeTrHist.nCode,tblCodeTrHist.TrDesc,tblCodeTrHist.Narration,tblCodeTrHist.UserID," & StrTTable & "." & StrTSrcDesc & " from tblCodeTrHist," & StrTTable & " WHERE tblCodeTrHist.nCode = " & StrTTable & "." & StrTSrcID & " AND tblCodeTrHist.TrMode = '" & StrTTrMode & "' AND tblCodeTrHist.EmpID = '" & StrEmployeeID & "'"
    'End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        txtID.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value

        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "select " & StrTSrcID & "," & StrTSrcDesc & ",Status,ShtCD from " & StrTTable & " WHERE " & StrTSrcID & " = '" & txtID.Text & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtDescription.Text = IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1))
                cBoxRemove.CheckState = IIf(IsDBNull(drShw.Item(2)), "", drShw.Item(2))
                txtShortCode.Text = IIf(IsDBNull(drShw.Item(3)), "", drShw.Item(3))

                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim bolSave As Boolean = False
        If txtDescription.Text = "" Then : Exit Sub : End If


        If StrSvStatus = "S" Then
            sqlQRY = "INSERT INTO " & StrTTable & " (" & StrTSrcID & "," & StrTSrcDesc & ",ShtCD) VALUES ('" & txtID.Text & "','" & txtDescription.Text & "','" & txtShortCode.Text & "') ;"
            bolSave = FK_EQ(sqlQRY, "S", "", False, True, True)
        ElseIf StrSvStatus = "E" Then
            sqlQRY = " UPDATE " & StrTTable & " SET " & StrTSrcDesc & " = '" & txtDescription.Text & "' , Status = '" & cBoxRemove.CheckState & "',ShtCD = '" & txtShortCode.Text & "' WHERE " & StrTSrcID & " = '" & txtID.Text & "' "
            bolSave = FK_EQ(sqlQRY, "E", "", False, True, True)
        Else
        End If

        'If StrSvStatus = "S" Then
        '    sqlQRY = "INSERT INTO " & StrTTable & " (" & StrTSrcID & "," & StrTSrcDesc & ") VALUES ('" & txtID.Text & "','" & txtDescription.Text & "') "
        '    bolSave = FK_EQ(sqlQRY, "S", "", False, True, True)
        'ElseIf StrSvStatus = "E" Then
        '    sqlQRY = " UPDATE " & StrTTable & " SET " & StrTSrcDesc & " = '" & txtDescription.Text & "' , Status = '" & cBoxRemove.CheckState & "' WHERE " & StrTSrcID & " = '" & txtID.Text & "' "
        '    bolSave = FK_EQ(sqlQRY, "E", "", False, True, True)
        'Else
        'End If





        If bolSave = True Then Me.Close()


    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        refh()
    End Sub

    Private Sub frmAddNewItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescription.Text = ""
        txtShortCode.Text = ""
        StrSvStatus = "S"
        refh()
    End Sub

  

    Private Sub cmdRefresh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgvData.KeyPress, cBoxRemove.KeyPress, cmdRefresh.KeyPress, cmdSave.KeyPress, txtID.KeyPress, txtDescription.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    
End Class