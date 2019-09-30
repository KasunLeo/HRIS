Public Class FrmEditEmployee

    Private Sub FrmEditEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ControlHandlers(Me)
        CenterFormThemed(Me, Panel1, Label1)
        Me.Text = strEditWhat
        lblEditWhat.Text = strEditWhat
        If strFillComboString <> "" Then
            FillComboAll(cmbExisting, strFillComboString)
            FillComboAll(cmbNew, strFillComboString)
        End If
        cmbExisting.Text = sDefaultComboText
        txtEmployee.Text = strEmployee
        ''sSQL = "create table tblEmpHistory (ID int identity(1,1), RegID varchar(10), Change varchar(10), FromValue varchar(50) , ToValue varchar(50), Comments varchar(250), AddDate DateTime not null default getdate(),UserID varchar(10));"
        EQ(sSQL)
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cmbExisting.Text = cmbNew.Text Then MsgBox("There is no chage in the both Fields", MsgBoxStyle.Information) : Exit Sub

        sSQL = ""
        If strIfIDValue = False Then
            sSQL = " update tblpayrollemployee set " & strUpdateField & "='" & cmbNew.Text & "' where RegID='" & FK_GetIDR(strEmployee) & "'"
            sSQL = sSQL & " insert into tblemphistory (regid,change,Fromvalue,ToValue,Comments,UserID,effDate) values ('" & FK_GetIDR(txtEmployee.Text) & "','" & strChange & "','" & cmbExisting.Text & "','" & cmbNew.Text & "','" & txtComment.Text & "','" & StrUserID & "','" & Format(dtpEfctDat.Value, "yyyyMMdd") & "');"
        Else
            sSQL = " update tblpayrollemployee set " & strUpdateField & "='" & FK_GetIDR(cmbNew.Text) & "' where RegID='" & FK_GetIDR(strEmployee) & "'"
            sSQL = sSQL & " insert into tblemphistory (regid,change,Fromvalue,ToValue,Comments,UserID,effDate) values ('" & FK_GetIDR(txtEmployee.Text) & "','" & strChange & "','" & FK_GetIDR(cmbExisting.Text) & "','" & FK_GetIDR(cmbNew.Text) & "','" & txtComment.Text & "','" & StrUserID & "','" & Format(dtpEfctDat.Value, "yyyyMMdd") & "');"

        End If
        If FK_EQ(sSQL, "E", "", True, True, True) = True Then
            Me.Close()
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

End Class