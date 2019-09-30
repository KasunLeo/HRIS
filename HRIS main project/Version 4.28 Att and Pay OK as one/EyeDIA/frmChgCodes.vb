'------------------------------------------------------------------------------------
'Project        : Attendance Factory Mode 
'Module         : Employee 
'Description    : New Module to Keep the Code Change History of the Employee, Report also only can take from this screen
'Start Date     : 8/7/2013
'Close Date     : 
'Author         : Kasun
'------------------------------------------------------------------------------------

Public Class frmChgCodes

    'New Form to keep transaction changes in each main codes 
    Dim StrNCode As String = "" : Dim StrEDescT As String = ""

    Private Sub frmChgCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, pnlTop, lblTitle)
        ControlHandlers(Me)

        Dim sqlQ As String = ""
        
        sqlQ = "Select ERef,EDesc,ESDesc,EUsers,mTable,SchID,SchDesc FROM tblEditSeq WHERE ERef = '" & StrTTrMode & "'"
        fk_Return_MultyString(sqlQ, 7) : StrEDescT = fk_ReadGRID(1) : StrTFldName = fk_ReadGRID(3) : StrTTable = fk_ReadGRID(4) : StrTSrcID = fk_ReadGRID(5) : StrTSrcDesc = fk_ReadGRID(6)
        lblTitle.Text = fk_ReadGRID(1)
        'Load Information to the Combo Box 
        sqlQ = "SELECT * FROM " & StrTTable & " WHERE Status = 0 Order By " & StrTSrcID
        ListCombo(cmbDetail, sqlQ, StrTSrcDesc)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If StrNCode = "" Then MsgBox("Please Select New Code") : Exit Sub
        If strExsistedCode = StrNCode Then MessageBox.Show("There is no different with your exsisted data, Please retry", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        If StrEmployeeID = "" Then MsgBox("No Employee Information found", MsgBoxStyle.Information) : Exit Sub
        Dim StrNDesc As String = ""
        StrNDesc = StrEDescT & " to " & StrNCode
        'Get the Transaction ID 
        Dim StrTrID As String = "" : StrTrID = fk_GenSerial("SELECT cTrCount FROM tblControl", 10)
        Dim sqlQRY As String = ""
        'Update tblEmployee table 
        sqlQRY = "UPDATE tblEmployee SET " & StrTFldName & " = '" & StrNCode & "'  WHERE RegID = '" & StrEmployeeID & "'"
        'Insert Detail to the Transaction Table 
        sqlQRY = sqlQRY & " INSERT INTO tblCodeTrHist (TrID,EmpID, TrDate, nCode,TrDesc, TrMode, Narration, UserID,trSetDate,oldExsist,oldCode) " & _
        " VALUES ('" & StrTrID & "','" & StrEmployeeID & "',getdate (),'" & StrNCode & "','" & StrNDesc & "','" & StrTTrMode & "','" & txtDescription.Text & "','" & StrUserID.Substring(0, 3) & "','" & Format(dtpTrDate.Value, "yyyyMMdd") & "', '" & strExsisted & "','" & strExsistedCode & "')"
        'Update tblControl Table 
        sqlQRY = sqlQRY & " UPDATE tblControl SET cTrCount = cTrCount + 1"

        Dim bolSave As Boolean = False
        bolSave = FK_EQ(sqlQRY, "S", "", False, True, True) : If bolSave = True Then Me.Close()
        strNewCode = fk_RetString("SELECT " & StrTSrcDesc & " FROM " & StrTTable & " WHERE " & StrTSrcID & "='" & Trim(StrNCode) & "'")
        'frmEmployeeInfo.pb_ShowEmployee(StrEmployeeID)
        frmMainAttendance.RefreshButtonEmployee()


    End Sub

    Private Sub cmbDetail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDetail.SelectedIndexChanged
        StrNCode = fk_RetString("SELECT " & StrTSrcID & " FROM " & StrTTable & " WHERE " & StrTSrcDesc & " = '" & cmbDetail.Text & "'")
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sqlQ As String = "Select tblCodeTrHist.EmpID,tblCodeTrHist.TrDate,tblCodeTrHist.nCode,tblCodeTrHist.TrDesc,tblCodeTrHist.Narration,tblCodeTrHist.UserID," & StrTTable & "." & StrTSrcDesc & " from tblCodeTrHist," & StrTTable & " WHERE tblCodeTrHist.nCode = " & StrTTable & "." & StrTSrcID & " AND tblCodeTrHist.TrMode = '" & StrTTrMode & "' AND tblCodeTrHist.EmpID = '" & StrEmployeeID & "'"
    End Sub




  
    Private Sub txtDescription_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress, cmbDetail.KeyPress, dtpTrDate.KeyPress, cmdSave.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

   
    'Private Sub frmChgCodes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    '    If e.KeyChar = ChrW(Keys.Escape) Then
    '        Me.Close()
    '    End If
    '  End Sub
End Class