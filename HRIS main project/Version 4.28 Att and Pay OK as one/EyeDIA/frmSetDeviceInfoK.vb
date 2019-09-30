Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI
Imports System.IO

Public Class frmDeviceInfo

    Dim StrSvStatus As String = "S"
    Dim StrmachineID As String = ""

    Private Sub frmDeviceInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sqll = "alter table tblDeviceInfo add downloadForm varchar(100);"
        FK_EQ(sqll, "E", "", False, False, False)
        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        IsDownloadFromServer = fk_sqlDbl("select IsDownloadFromServer from tblcompany where compID='" & StrCompID & "'")

        '===============Copied Start
        '' '' ''        Dim strQry As String = " create table tblDeviceInfo(" & _
        '' '' ''" machinID nvarchar (3) null," & _
        '' '' ''" mDesc nvarchar (30) null," & _
        '' '' ''" InstDate datetime null," & _
        '' '' ''" DivNo nvarchar (10) null," & _
        '' '' ''" ConType nvarchar (2) null," & _
        '' '' ''" IpAddress nvarchar (20) null," & _
        '' '' ''" Port nvarchar (10) null," & _
        '' '' ''" CompID nvarchar (3) null," & _
        '' '' ''" Status numeric (18,0) not null default ((0))" & _
        '' '' ''" )"
        '' '' ''        fk_CreateTableR(strQry, "tblDeviceInfo")

        '==============Copied Over
        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)
        pnlLeft.Width = 0
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

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

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick

        pbCount.Value = 0
        pbCount.Maximum = 100000

        If dgvData.RowCount = 0 Then Exit Sub

        StrmachineID = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        'Show device information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblDeviceInfo WHERE MachinID = '" & StrmachineID & "' AND compID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item("MachinID")), "", drShw.Item("MachinID"))
                txtDesc.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("mDesc")), "", drShw.Item("mDesc")))
                txtDivNo.Text = IIf(IsDBNull(drShw.Item("DivNo")), "", drShw.Item("DivNo"))
                txtIPAddress.Text = IIf(IsDBNull(drShw.Item("IPAddress")), "", drShw.Item("IPAddress"))
                txtPort.Text = IIf(IsDBNull(drShw.Item("Port")), "", drShw.Item("Port"))
                dtpInsDate.Value = IIf(IsDBNull(drShw.Item("InstDate")), DateSerial(1900, 1, 1), drShw.Item("InstDate"))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item("Status")), 0, drShw.Item("Status"))
                chkRemort.CheckState = IIf(IsDBNull(drShw.Item("RunLocal")), 0, drShw.Item("RunLocal"))
                cmbDownload.Text = IIf(IsDBNull(drShw.Item("downloadForm")), 0, drShw.Item("downloadForm"))
                '20180530 -- prasanna 
                chkIsNetwork.CheckState = IIf(IsDBNull(drShw.Item("IsNetwork")), 0, drShw.Item("IsNetwork"))
                txtLocationID.Text = IIf(IsDBNull(drShw.Item("LocationID")), "", drShw.Item("LocationID"))
                StrSvStatus = "E"

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

        Dim dblCoun As Double = fk_sqlDbl("select allRecords from tblControl  where grpid='" & StrCompID & "'")
        pbCount.Value = dblCoun

    End Sub

    Private Sub txtDivNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDivNo.KeyPress

        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtIPAddress.Focus()
        End If

    End Sub

    Private Sub txtIPAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIPAddress.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Or ((e.KeyChar) = ".") Then
            e.Handled = False
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtPort.Focus()
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDesc.Focus()
        End If
    End Sub

    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            dtpInsDate.Focus()
        End If
    End Sub

    Private Sub dtpInsDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpInsDate.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDivNo.Focus()
        End If
    End Sub

    Private Sub txtPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPort.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)

        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Information are saving here.....
        'if information save need to re generate the device number 

        'validate informatoin 
        If txtCode.Text = "" Then
            MsgBox("Required ID", MsgBoxStyle.Information)
            Exit Sub
        End If
        If txtDesc.Text = "" Then
            MsgBox("Requried Device Name", MsgBoxStyle.Information)
            txtDesc.Focus()
            Exit Sub
        End If
        If txtDivNo.Text = "" Then
            MsgBox("Requried Device No", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtIPAddress.Text = "" Then
            MsgBox("Required IP Address", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtPort.Text = "" Then
            MsgBox("Required Port", MsgBoxStyle.Information)
            Exit Sub
        End If
        If StrSvStatus = "S" Then
            Dim iD As Integer = fk_sqlDbl("SELECT NoDevice FROM tblCompany WHERE compID = '" & StrCompID & "'") + 1
            Dim StrD As String = fk_CreateSerial(3, iD)
            txtCode.Text = StrD
        End If

        If StrSvStatus = "S" Then
            txtCode.Text = fk_CreateSerial(3, (fk_sqlDbl("SELECT NoDevice FROM tblCompany WHERE compID = '" & StrCompID & "'") + 1))

        End If



        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        Dim sqlQRY As String
        cmSave.Transaction = trSave
        Try
            Select Case StrSvStatus
                Case "S"
                    'Information can save without any issue

                    '20180530----  prasanna --- insert is network multi device download
                    '20180817--- prasanna insert location ID for Cloud Data Downloan 
                    sqlQRY = "INSERT INTO tblDeviceInfo (MachinID,mDesc,InstDate,DivNo,ConType,IPAddress,Port,CompID,Status,RunLocal,downloadForm,IsNetwork,LocationID) " & _
                    " VALUES ('" & txtCode.Text & "','" & FK_Rep(txtDesc.Text) & "','" & Format(dtpInsDate.Value, "yyyyMMdd") & "', " & _
                    " '" & txtDivNo.Text & "','01','" & txtIPAddress.Text & "','" & txtPort.Text & "','" & StrCompID & "', " & chkStatus.CheckState & ", " & chkRemort.CheckState & ",'" & cmbDownload.Text & "','" & chkIsNetwork.CheckState & "','" & txtLocationID.Text & "')"
                    ' sqlQRY = "INSERT INTO tblDeviceInfo (MachinID,mDesc,InstDate,DivNo,ConType,IPAddress,Port,CompID,Status,RunLocal,downloadForm) " & _
                    ' " VALUES ('" & txtCode.Text & "','" & FK_Rep(txtDesc.Text) & "','" & Format(dtpInsDate.Value, "yyyyMMdd") & "', " & _
                    ' " '" & txtDivNo.Text & "','01','" & txtIPAddress.Text & "','" & txtPort.Text & "','" & StrCompID & "', " & chkStatus.CheckState & ", " & chkRemort.CheckState & ",'" & cmbDownload.Text & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblCompany SET NoDevice = NoDevice + 1 WHERE compID  = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)


                Case "E"
                    If chkStatus.CheckState = CheckState.Checked Then
                        If MsgBox("Do you want to Removed the Device ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Exit Sub
                            '    Else
                            '        sqlQRY = "UPDATE tblDeviceInfo SET mDesc = '" & txtDesc.Text & "',InstDate = '" & Format(dtpInsDate.Value, "yyyyMMdd") & "',DivNo = '" & txtDivNo.Text & "',IPAddress = '" & txtIPAddress.Text & "',Port = '" & txtPort.Text & "',Status = " & chkStatus.CheckState & " WHERE MachinID = '" & StrmachineID & "' AND compID = '" & StrCompID & "'"
                            '        cmSave.CommandText = sqlQRY
                            '        cmSave.ExecuteNonQuery()

                            '        trSave.Commit()
                            '        MsgBox("Information Modified", MsgBoxStyle.Information)
                            '        cmdRefresh_Click(sender, e)

                            '    End If
                            'Else 
                        End If
                    End If
                    '-- 20180530 prasanna Update Is Network
                    sqlQRY = "UPDATE tblDeviceInfo SET RunLocal = " & chkRemort.CheckState & ", mDesc = '" & FK_Rep(txtDesc.Text) & "',InstDate = '" & Format(dtpInsDate.Value, "yyyyMMdd") & "',DivNo = '" & txtDivNo.Text & "',IPAddress = '" & txtIPAddress.Text & "',Port = '" & txtPort.Text & "',Status = " & chkStatus.CheckState & ",downloadForm='" & cmbDownload.Text & "', IsNetwork ='" & chkIsNetwork.CheckState & "',LocationID = '" & txtLocationID.Text & "' WHERE MachinID = '" & StrmachineID & "' AND compID = '" & StrCompID & "'"
                    ' sqlQRY = "UPDATE tblDeviceInfo SET RunLocal = " & chkRemort.CheckState & ", mDesc = '" & FK_Rep(txtDesc.Text) & "',InstDate = '" & Format(dtpInsDate.Value, "yyyyMMdd") & "',DivNo = '" & txtDivNo.Text & "',IPAddress = '" & txtIPAddress.Text & "',Port = '" & txtPort.Text & "',Status = " & chkStatus.CheckState & ",downloadForm='" & cmbDownload.Text & "' WHERE MachinID = '" & StrmachineID & "' AND compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        pbCount.Value = 0

        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        chkStatus.Checked = False
        dtpInsDate.Value = dtWorkingDate

        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoDevice FROM tblCompany WHERE compID = '" & StrCompID & "'") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD
        txtDivNo.Text = "1"
        StrSvStatus = "S"
        If IsDownloadFromServer = 1 Then
            chkRemort.Visible = True
        End If

        Load_InformationtoGrid("SELECT machinID,mDesc FROM tblDeviceInfo where Status = 0 Order By machinID", dgvData, 2)
        clr_Grid(dgvData)
    End Sub

End Class