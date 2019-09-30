Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration

Public Class frmEmpRelationInfo

    Dim strRelTypeID As String = ""
    Dim strDesigID As String = ""

    Private Sub pbRelSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbRelSave.Click
        Dim dblRelID As Double = 0
        If txtRelName.Text = "" Then MsgBox("Enter relation's name", MsgBoxStyle.Information) : txtRelName.Focus() : Exit Sub
        If rdbYes.Checked = False And rdbNo.Checked = False Then MsgBox("Please select occupation type", MsgBoxStyle.Information) : rdbNo.Checked = True : Exit Sub
        If txtNIC.Text = "" Then MsgBox("Enter NIC number", MsgBoxStyle.Information) : txtNIC.Focus() : Exit Sub
        If txtRemark.Text = "" Then MsgBox("Enter remark", MsgBoxStyle.Information) : txtRemark.Focus() : Exit Sub
        If cmbRelation.Text = "" Then MsgBox("Enter relationship type", MsgBoxStyle.Information) : cmbRelation.Focus() : Exit Sub

        sSQL = "select count(empid)+1 FROM tblEmpRelations WHERE empID='" & StrEmployeeID & "'"
        dblRelID = fk_sqlDbl(sSQL)
        Dim intOccupied As Integer
        If rdbYes.Checked = True Then
            intOccupied = 1
        ElseIf rdbNo.Checked = True Then
            intOccupied = 0
        End If
        sSQL = "INSERT INTO tblRelationsDetail (empID,RelID,RelTypeID,RName,RAddress,rPhone1,Status,crUser,crTime,desigID,remark,isEmergency,isOccupied,RlNIC,RlDofB) VALUES ('" & StrEmployeeID & "','" & dblRelID & "','" & strRelTypeID & "','" & txtRelName.Text & "','" & txtAddres.Text & "','" & txtMob.Text & "','0','" & StrUserID & "', getdate(),'" & strDesigID & "','" & txtRemark.Text & "','" & chkEmergency.CheckState & "','" & intOccupied & "','" & txtNIC.Text & "','" & Format(dtpBirth.Value, "yyyyMMdd") & "')"
        FK_EQ(sSQL, "S", "", False, True, True)
        Button2_Click(sender, e)
    End Sub

    Private Sub cmbRelation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRelation.SelectedIndexChanged
        strRelTypeID = fk_RetString("select rTypeID  from tblRelTypes WHERE rDesc='" & cmbRelation.Text & "'")
    End Sub

    Private Sub cmbDesig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOccupation.SelectedIndexChanged
        strDesigID = fk_RetString("select desgID  from tbldesig WHERE desgDesc='" & cmbOccupation.Text & "'")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        txtNIC.Text = ""
        txtMob.Text = ""
        txtAddres.Text = ""
        txtRelName.Text = ""
        txtRemark.Text = ""
        ListCombo(cmbOccupation, "select *  from tbldesig order by desgDesc", "desgDesc")
        ListCombo(cmbRelation, "select * from tblRelTypes order by rDesc", "rDesc")
        cmbRelation.SelectedIndex = 0
        
        sSQL = "SELECT tblRelationsDetail.[RName]  ,tblRelTypes.rDesc,tblRelationsDetail.rlDofB,tblRelationsDetail.RlNIC,tblRelationsDetail.rPhone1,tblRelationsDetail.[RAddress]     ,'',tblRelationsDetail.remark      FROM [tblRelationsDetail],tblRelTypes  WHERE tblRelationsDetail.relTypeID=tblRelTypes.rTypeID AND  tblRelationsDetail.EmpID='" & StrEmployeeID & "'"
        Load_InformationtoGrid(sSQL, dgvData, 8)
        cmbOccupation.Enabled = False
    End Sub

    Private Sub frmEmpRelationInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Button2_Click(sender, e)
    End Sub

    Private Sub rdbYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbYes.CheckedChanged
        If rdbYes.Checked = True Then
            cmbOccupation.Enabled = True
        Else
            cmbOccupation.Enabled = False
        End If
    End Sub

    Private Sub txtNIC_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNIC.MouseLeave
        Try
            Call IDNum_Results(txtNIC.Text)

            dtpBirth.Value = dtNICDoB
            Dim bolEx As Boolean = fk_CheckEx("SELECT RlNIC FROM tblRelationsDetail WHERE RlNIC = '" & txtNIC.Text & "'")

            If bolEx = True Then
                MsgBox("This relation has another relationship also in dtabase", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class