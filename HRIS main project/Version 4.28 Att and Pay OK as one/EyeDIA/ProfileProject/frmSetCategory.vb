Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmSetCategory
    Dim StrSvStatus As String = "S"
    Dim StrOTAllc As String = ""

    Private Sub frmEmpCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        Button2_Click(sender, e)
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

       
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

        
    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick

        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        Dim StrWord As String
        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "SELECT * FROM tblSEtEmpCategory WHERE CatID = '" & txtCode.Text & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item(0)), "", drShw.Item(0))
                txtDesc.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1)))
                StrWord = IIf(IsDBNull(drShw.Item(2)), "", drShw.Item(2))
                chkOTAllow.CheckState = CInt(StrWord)
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item(4)), "", drShw.Item(4))

                'Uncheck all checks in the grid
                'Dim iRw As Integer
                'With dgvOT
                '    For iRw = 0 To .RowCount - 1
                '        .Item(2, iRw).Value = False
                '    Next
                'End With
                'Dim StrWrd As String()
                'StrWrd = StrWord.Split(New Char() {"|"})

                'Dim Wrds As String
                'For Each Wrds In StrWrd
                '    With dgvOT
                '        For iRw = 0 To .RowCount - 1
                '            If Wrds = .Item(0, iRw).Value Then
                '                .Item(2, iRw).Value = True
                '            End If
                '        Next
                '    End With
                'Next
                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UP("Company Profile", "Add category") = False Then Exit Sub

        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim bolAct As Boolean = False

        bolAct = fk_CheckEx("SELECT * FROM tblEmployee WHERE CatID = '" & txtCode.Text & "' AND empStatus <> 9")

        Select Case StrSvStatus
            Case "S"
                'Can't process save with deleted status
                If chkStatus.CheckState = CheckState.Checked Then
                    MsgBox("Can't Save with Deleted Status", MsgBoxStyle.Information)
                    Exit Sub

                End If
            Case "E"
                If chkStatus.CheckState = CheckState.Checked Then
                    If bolAct = True Then

                        Dim dr As DialogResult = MsgBox("There are employee(s) in database in this category. Do you really want to change employee category.", MsgBoxStyle.YesNo, "Attention")
                        If dr = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        End If
                    End If
                Else
                    If MsgBox("Do you want to modify Information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

        End Select
        Dim retMess As String
        Dim iRws As Integer
        With dgvOT
            For iRws = 0 To .RowCount - 1
                If .Item(2, iRws).Value = True Then
                    If StrOTAllc = "" Then
                        StrOTAllc = .Item(0, iRws).Value
                    Else
                        StrOTAllc = StrOTAllc & "|" & .Item(0, iRws).Value

                    End If
                End If
            Next
        End With

        If StrSvStatus = "E" Then
            sSQL = "UPDATE tblSEtEmpCategory SET catDesc='" & Trim(txtDesc.Text) & "',compID='" & StrCompID & "',status=" & chkStatus.CheckState & ",OTAllc= " & (chkOTAllow.CheckState) & " WHERE catID='" & Trim(txtCode.Text) & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Update employee category info of Cat ID : " & txtCode.Text & " and Category Name : " & txtDesc.Text & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "E", "", False, True, True)
        Else
            sSQL = "INSERT INTO tblSEtEmpCategory (catID,catDesc,OTAllc,compID,status) VALUES ('" & Trim(txtCode.Text) & "', '" & Trim(txtDesc.Text) & "'," & (chkOTAllow.CheckState) & ", '" & StrCompID & "'," & chkStatus.CheckState & "); UPDATE tblControl SET NoCatgs=NoCatgs+1; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Insert employee category of Cat ID : " & txtCode.Text & " and Category Name : " & txtDesc.Text & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "S", "", True, True, True)
        End If
        'retMess = Save_Codes3(StrSvStatus, txtCode.Text, txtDesc.Text, chkStatus.CheckState, "NoCatgs", "tblSEtEmpCategory", "CatID", "CatDesc", "OTAllc", CStr(chkOTAllow.CheckState))

        'MsgBox(retMess, MsgBoxStyle.Information)
        Button2_Click(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FK_Clear(Me)

        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoCatgs FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT CatID,CatDesc FROM tblSEtEmpCategory Order By CatID", dgvData, 2)
        clr_Grid(dgvData)
        chkOTAllow.Checked = False
        'Load OT Information 
        ' Load_InformationtoGrid("SELECT RefID,otDesc,'False' FROM tblSetOTInfo WHERE Status = 0", dgvOT, 3)

    End Sub
End Class