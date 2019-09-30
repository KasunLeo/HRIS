Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmConfigLeave

    Dim StrSvStatus As String = "S"
    Dim StrCat As String = ""
    Dim txtedit As TextBox

    Private Sub frmConfigLeave_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterFormThemed(Me, Panel1, Label19)
        ControlHandlers(Me)

        '==================Copied Start
        '' '' ''        Dim strQry As String = " Create FUNCTION [dbo].[fk_RetNoLeave]   " & _
        '' '' ''" (@CatID nvarchar(3)," & _
        '' '' ''" @LeaveID Nvarchar (3))  " & _
        '' '' ''" RETURNS Numeric (18,2)  " & _
        '' '' ''" AS   " & _
        '' '' ''" BEGIN   " & _
        '' '' ''" declare @Return Numeric (18,2)   " & _
        '' '' ''" set @return = (select Sum(NoLeave) FROM tblSetLeave where CatID = @CatID AND  LeaveID = @LeaveID)  " & _
        '' '' ''" if @return is null  " & _
        '' '' ''"	set @return = 0  " & _
        '' '' ''" return @return   " & _
        '' '' ''" end  "

        '' '' ''        fk_CreateTableR(strQry, "fk_RetNoLeave")

        '' '' ''        strQry = "create table tblSetLeave(" & _
        '' '' ''" CatID nvarchar (3) null," & _
        '' '' ''" LeaveID nvarchar (3) null," & _
        '' '' ''" NoLeave numeric (18,2) null," & _
        '' '' ''" Status numeric (18,0) null" & _
        '' '' ''" )"
        '' '' ''        fk_CreateTableR(strQry, "tblSetLeave")

        '===================Copied Over

        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)

    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        'Dim crtl As Control
        'For Each crtl In Me.GroupBox1.Controls
        '    If TypeOf crtl Is TextBox Then crtl.Text = ""
        'Next
        Load_InformationtoGrid("SELECT CatID,CatDesc FROM tblSEtEmpCategory WHERE Status = 0 Order By CatID", dgvCat, 2)
        clr_Grid(dgvCat)

        Load_InformationtoGrid("select lvID,LvDesc,0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLvType, 3)
        clr_Grid(dgvLvType)

    End Sub

    Private Sub dgvCat_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCat.CellClick

        If dgvCat.RowCount = 0 Then Exit Sub
        StrCat = dgvCat.Item(0, dgvCat.CurrentRow.Index).Value
        Load_InformationtoGrid("select lvID,LvDesc,dbo.fk_RetNoLeave('" & StrCat & "',LvID) as NoLv From tblLeaveType WHERE Status = 0 Order By LvID", dgvLvType, 3)
        clr_Grid(dgvLvType)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Leave", "Allocate leave amounts") = False Then Exit Sub

        If StrCat = Nothing Then
            MsgBox("Select the category", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("This Process will Update  the employee leave information (only Asign Leave Qty) Related to " & vbCrLf & " selected employee Category." & vbCrLf & vbCrLf & "Do you want to Continue ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String = ""
        Try
            'Fist Delete the Existing information in the setup table related to the selected employee category
            sqlQRY = "DELETE FROM tblSetLeave WHERE CatID = '" & StrCat & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'Then Save the information to the table where the No Leave More than ZWRO
            Dim iRw As Integer
            Dim NoLeave As Double
            With dgvLvType
                For iRw = 0 To .RowCount - 1
                    NoLeave = CDbl(.Item(2, iRw).Value)
                    If NoLeave > 0 Then
                        sqlQRY = "INSERT INTO tblSetLeave VALUES ('" & StrCat & "','" & .Item(0, iRw).Value & "'," & NoLeave & ",0)"
                        cmSave.CommandText = sqlQRY
                        cmSave.ExecuteNonQuery()
                    End If
                Next
            End With

            trSave.Commit()
            MsgBox("Information Saved", MsgBoxStyle.Information)
            cmdRefresh_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try
    End Sub


    Private Sub dgvLvType_EditingControlShowing1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvLvType.EditingControlShowing
        If dgvLvType.CurrentCell.ColumnIndex = 2 Then
            txtedit = DirectCast(e.Control, TextBox)
            AddHandler txtedit.KeyPress, AddressOf txtEdit_KeyPress
        End If
    End Sub

    Private Sub txtEdit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        If dgvLvType.CurrentCell.ColumnIndex = 2 Then
            If ("0123456789\b".IndexOf(e.KeyChar) = -1) Then
                If e.KeyChar <> Convert.ToChar(Keys.Back) Then
                    e.Handled = True
                End If
            End If
            If (Asc(e.KeyChar) = 8) Or ((e.KeyChar) = ".") Then
                e.Handled = False
            End If
            If txtedit.Text.Contains(".") And e.KeyChar = "." Then
                e.Handled = True
            End If

        End If

    End Sub

End Class