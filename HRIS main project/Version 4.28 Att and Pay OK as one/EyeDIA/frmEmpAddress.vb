Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmEmpAddress

    Dim StrSvStatus As String = "S"
    Dim StrAdTypeID As String = ""
    Dim strDefAd As String = ""
    Dim strExAdType As String = ""
    Dim StrAdID As String = ""

    Private Sub frmEmpAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label25)
        cmdRefresh_Click(sender, e)
        ControlHandlers(Me)
    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown

        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkRemove.Checked = False
        chkStDef.Checked = False
        'Get the Employee Adddress details 
        Dim iAds As Integer = fk_sqlDbl("SELECT NoAdds FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "'") + 1
        Dim StrAdID As String = fk_CreateSerial(3, iAds)
        txtAdID.Text = StrAdID

        ListCombo(cmbAddType, "SELECT * FROM tblAddTypes WHERE Status = 0 Order By TypeID", "TypeDesc")

        Dim sqlQ As String = "Select AddID,AddType,dbo.fk_RetAddTypes(AddType,'01'),Add1,Add2,Add3,Status FROM tblEmpAddress WHERE EmpID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "' order by addID"
        Load_InformationtoGrid(sqlQ, dgvEmAdd, 7)
        clr_Grid(dgvEmAdd)

        StrSvStatus = "S"

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        'validate information
        If txtAdID.Text = "" Then
            MsgBox("Requried Address ID", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtLine1.Text = "" Then
            MsgBox("Required Line 1", MsgBoxStyle.Information)
            txtLine1.Focus()
            Exit Sub
        End If

        If cmbAddType.Text = "NONE" Then
            MsgBox("Required Type", MsgBoxStyle.Information)
            cmbAddType.Focus()
            Exit Sub
        End If

        If False = fk_CheckEx("select * from tblemployee where regid='" & StrEmployeeID & "'") Then
            MsgBox("Please Select the Employee First.")
            Exit Sub
        End If

        StrAdTypeID = fk_RetString("SELECT TypeID FROM tblAddTypes WHERE TypeDesc = '" & cmbAddType.Text & "'")

        If StrSvStatus = "S" Then
            With dgvEmAdd
                For i As Integer = 0 To .RowCount - 1
                    If .Item(2, i).Value.ToString = cmbAddType.Text Then
                        MsgBox("Selected Address Type has already been Set.")
                        cmbAddType.Focus()
                        Exit Sub
                    End If
                Next
            End With
            txtAdID.Text = fk_CreateSerial(3, (fk_sqlDbl("SELECT NoAdds FROM tblEmployee WHERE RegID = '" & StrEmployeeID & "' AND CompID = '" & StrCompID & "'") + 1))
        End If

        If chkRemove.Checked = True Then
            If strDefAd = txtAdID.Text.Trim Then
                MsgBox("You are going to remove the default address. Please set one as default and try again")
                chkRemove.Checked = False
                chkStDef.Checked = True
                Exit Sub
            End If
        End If

        'when editing, same addtype can not be duplicated.
        If StrSvStatus = "E" Then
            With dgvEmAdd
                For i As Integer = 0 To .RowCount - 1
                    If cmbAddType.Text = .Item(2, i).Value.ToString Then
                        If StrAdID = .Item(0, i).Value.ToString Then
                        Else
                            MsgBox("Selected Address Type has already been Set.")
                            cmbAddType.Focus()
                            Exit Sub
                        End If
                    End If
                Next
            End With
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Dim strMsg As String = ""

        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "INSERT INTO tblEmpAddress (EmpID, AddID, AddType, Add1, Add2, Add3, Status, compID) VALUES " & _
                    " ('" & StrEmployeeID & "','" & txtAdID.Text & "','" & StrAdTypeID & "','" & FK_Rep(txtLine1.Text) & "','" & FK_Rep(txtLine2.Text) & "','" & FK_Rep(txtLine3.Text) & "',0,'" & StrCompID & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblEmployee SET NoAdds = NoAdds + 1 WHERE RegID = '" & StrEmployeeID & "' AND compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    strMsg = "Information Saved"

                Case "E"
                    'If information are edit .......
                    If chkRemove.CheckState = CheckState.Checked Then
                        If MsgBox("Do you want to remove address ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    sqlQRY = "UPDATE tblEmpAddress SET  AddType = '" & StrAdTypeID & "', " & _
                    " Add1 = '" & FK_Rep(txtLine1.Text) & "', Add2 = '" & FK_Rep(txtLine2.Text) & "', Add3 = '" & FK_Rep(txtLine3.Text) & "', " & _
" Status = " & chkRemove.CheckState & " WHERE compID = '" & StrCompID & "' AND EmpID = '" & StrEmployeeID & "' and AddID = '" & txtAdID.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    strMsg = "Information Modified"
            End Select

            Dim strQrySetDef As String
            If chkStDef.Checked = True Then
                strQrySetDef = "update tblEmployee set DefAddID='" & txtAdID.Text & "' where regid='" & StrEmployeeID & "'"
                cmSave.CommandText = strQrySetDef
                cmSave.ExecuteNonQuery()
            End If

            trSave.Commit()
            MsgBox(strMsg, MsgBoxStyle.Information)
            cmdRefresh_Click(sender, e)
        Catch ex As Exception
            trSave.Rollback()
            MsgBox(ex.Message)
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub cmbAddType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAddType.SelectedIndexChanged

        StrAdTypeID = fk_RetString("SELECT TypeID FROM tblAddTypes WHERE TypeDesc = '" & cmbAddType.Text & "'")

    End Sub

    Private Sub dgvEmAdd_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmAdd.CellDoubleClick

        If dgvEmAdd.RowCount = 0 Then Exit Sub
        strDefAd = fk_RetString("select DefAddID from tblEmployee where regid='" & StrEmployeeID & "'")
        If dgvEmAdd.CurrentRow.Cells(0).Value.ToString = strDefAd Then
            chkStDef.Checked = True
        Else
            chkStDef.Checked = False
        End If
        StrAdID = dgvEmAdd.Item(0, dgvEmAdd.CurrentRow.Index).Value
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "select tblEmpAddress.AddID,tblEmpAddress.AddType,tblAddTypes.TypeDesc,tblEmpAddress.Add1,tblEmpAddress.Add2," & _
        " tblEmpAddress.Add3,tblEmpAddress.Status from tblEmpAddress INNER JOIN tblAddTypes ON tblEmpAddress.AddType = tblAddTypes.TypeID " & _
        " WHERE tblEmpAddress.EmpID = '" & StrEmployeeID & "' AND tblEmpAddress.AddID = '" & StrAdID & "'"

        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                StrAdTypeID = IIf(IsDBNull(drShw.Item("AddType")), "", drShw.Item("AddType"))
                strExAdType = IIf(IsDBNull(drShw.Item("TypeDesc")), "", drShw.Item("TypeDesc"))
                cmbAddType.Text = strExAdType
                txtAdID.Text = IIf(IsDBNull(drShw.Item("AddID")), "", drShw.Item("AddID"))
                txtLine1.Text = IIf(IsDBNull(drShw.Item("Add1")), "", drShw.Item("Add1"))
                txtLine2.Text = IIf(IsDBNull(drShw.Item("Add2")), "", drShw.Item("Add2"))
                txtLine3.Text = IIf(IsDBNull(drShw.Item("Add3")), "", drShw.Item("Add3"))
                chkRemove.Checked = IIf(IsDBNull(drShw.Item("Status")), 0, drShw.Item("Status"))
                StrSvStatus = "E"
            End If
            drShw.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub chkRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkRemove.Click

        chkStDef.Checked = False

    End Sub

    Private Sub chkStDef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkStDef.Click

        chkRemove.Checked = False

    End Sub

End Class