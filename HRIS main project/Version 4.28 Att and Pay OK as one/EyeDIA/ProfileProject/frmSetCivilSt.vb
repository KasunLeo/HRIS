'Imports EAS_2011.GlassTableGDI

Public Class frmSetCivilSt

    Dim StrSvStatus As String = "S"

    Private Sub frmAddCivilSt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim sqlTable As String = ""
        sqlTable = "create table tblCivilStatus (StID Nvarchar (3),stDesc Nvarchar (60),CompID Nvarchar (3),Status Numeric (18,0))"
        FK_EQ(sqlTable, "S", "", False, False, False)
        sqlTable = "ALTER TABLE tblControl ADD NoCivil Numeric (18,0) NOT NULL Default 0"
        FK_EQ(sqlTable, "S", "", False, False, False)

        'CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)

        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.BackColor, 90)
    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.BackColor
    'End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)
        txtID.Text = fk_GenSerial("SELECT NoCivil FROM tblControl", 3)
        StrSvStatus = "S"
        'Load Grid 
        Dim sqlLoad As String = "SELECT StID,StDesc FROM tblCivilStatus Order By StID"
        Load_InformationtoGrid(sqlLoad, dgvData, 2)
        clr_Grid(dgvData)

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim sqlQRY As String = ""
        If txtID.Text = "" Then MsgBox("Enter ID", MsgBoxStyle.Information) : cmdRefresh_Click(sender, e) : Exit Sub
        If txtName.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : txtName.Focus() : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtID.Text = fk_GenSerial("SELECT NoCivil FROM tblControl", 3)
                sqlQRY = sqlQRY & " INSERT INTO tblCivilStatus VALUES ('" & txtID.Text & "','" & txtName.Text & "','" & StrCompID & "'," & chkRemoved.CheckState & ")"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoCivil = NoCivil + 1"
            Case "E"
                sqlQRY = sqlQRY & " UPDATE tblCivilStatus SET StDesc = '" & txtName.Text & "',Status = " & chkRemoved.CheckState & " WHERE StID = '" & txtID.Text & "'"
        End Select

        Dim bolSave As Boolean = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True) : If bolSave = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub dgvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvData.DoubleClick
        txtID.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        txtName.Text = dgvData.Item(1, dgvData.CurrentRow.Index).Value
        StrSvStatus = "E"

        'Opn 

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqlQRY As String = ""
        If txtID.Text = "" Then MsgBox("Enter ID", MsgBoxStyle.Information) : cmdRefresh_Click(sender, e) : Exit Sub
        If txtName.Text = "" Then MsgBox("Enter Description", MsgBoxStyle.Information) : txtName.Focus() : Exit Sub

        Select Case StrSvStatus
            Case "S"
                txtID.Text = fk_GenSerial("SELECT NoCivil FROM tblControl", 3)
                sqlQRY = sqlQRY & " INSERT INTO tblCivilStatus VALUES ('" & txtID.Text & "','" & txtName.Text & "','" & StrCompID & "'," & chkRemoved.CheckState & ")"
                sqlQRY = sqlQRY & " UPDATE tblControl SET NoCivil = NoCivil + 1"
            Case "E"
                sqlQRY = sqlQRY & " UPDATE tblCivilStatus SET StDesc = '" & txtName.Text & "',Status = " & chkRemoved.CheckState & " WHERE StID = '" & txtID.Text & "'"
        End Select

        Dim bolSave As Boolean = FK_EQ(sqlQRY, StrSvStatus, "", False, True, True) : If bolSave = True Then cmdRefresh_Click(sender, e)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FK_Clear(Me)
        txtID.Text = fk_GenSerial("SELECT NoCivil FROM tblControl", 3)
        StrSvStatus = "S"
        'Load Grid 
        Dim sqlLoad As String = "SELECT StID,StDesc FROM tblCivilStatus Order By StID"
        Load_InformationtoGrid(sqlLoad, dgvData, 2)
        clr_Grid(dgvData)
    End Sub
End Class