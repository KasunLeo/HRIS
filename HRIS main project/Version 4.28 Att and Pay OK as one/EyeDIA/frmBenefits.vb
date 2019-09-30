Imports System.Data.SqlClient

Public Class frmBenefits


    Dim BenifitsItemsIndex As String = ""
    Dim StrSvStatus As String = "S"
    Dim SelectedRowIndex As String = ""

    Private Sub frmBenefits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CREATE TABLE tblSetBenefits (benID VARCHAR(6),Descr VARCHAR(100),Status INT DEFAULT 0 )

        'CREATE TABLE tblBenefits (tagID INT IDENTITY , EmpID VARCHAR(12), benID VARCHAR(6), submitDate DATETIME , endDate DATETIME,remark VARCHAR(200),CrCancelDate DATETIME,InActivelDate DATETIME,InactiveUser VARCHAR(12), Status INT DEFAULT 0 ) 


        CenterFormThemed(Me, Panel1, Label25)
        ControlHandlers(Me)
        refresh()
    End Sub

    Private Sub refresh()
        ' Load_InformationtoGrid("SELECT tblSetDept.deptID,tblSetDept.deptName,tblSetDept.shCOde,tblEmployee.dispName FROM tblSetDept,tblEmployee WHERE tblSetDept.regID=tblEmployee.regID Order By DeptID", dgvData, 4)
        StrSvStatus = "S"
        txtRemark.Text = ""
        cboxBenifitsItems.Text = ""
        dtpRemoveDate.Visible = False
        lblInactiveDate.Visible = False
        chkStatus.Visible = False
        chkStatus.CheckState = CheckState.Unchecked
        Load_InformationtoGrid(" SELECT tblBenefits.tagID,tblSetBenefits.Descr , tblBenefits.submitDate ,tblBenefits.endDate,tblBenefits.remark  FROM tblSetBenefits INNER JOIN tblBenefits ON tblSetBenefits.benID  = tblBenefits.benID AND tblBenefits.Status <> 1 AND tblBenefits.EmpID ='" & StrEmployeeID & "'  ORDER BY tblBenefits.tagID ", dgvData, 5)
        ListCombo(cboxBenifitsItems, "select * from tblSetBenefits where Status <> 1 ORDER BY Descr", "Descr")


    End Sub

    Private Sub dgvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick

        SelectedRowIndex = dgvData.Item(0, dgvData.CurrentRow.Index).Value
        ' MsgBox(SelectedRowIndex)

        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "SELECT tblSetBenefits.Descr,tblBenefits.submitDate,tblBenefits.endDate,tblBenefits.remark FROM tblSetBenefits INNER JOIN tblBenefits ON  tblBenefits.benID =tblSetBenefits. benID AND tblBenefits.tagID = '" & SelectedRowIndex & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                cboxBenifitsItems.Text = IIf(IsDBNull(drShw.Item(0)), "", drShw.Item(0))
                dtpSubmithDate.Text = IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1))
                dtpReturnDate.Text = IIf(IsDBNull(drShw.Item(2)), "", drShw.Item(2))
                txtRemark.Text = IIf(IsDBNull(drShw.Item(3)), "", drShw.Item(3))

                ' dtpReturnDate.CheckState = IIf(IsDBNull(drShw.Item(3)), "", drShw.Item(3))
                ' dtpSubmithDate.Text = Format(SubmithDate, "yyyyMMdd")
                ' dtpReturnDate.Text = Format(ReturnDate, "yyyyMMdd")

                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
        chkStatus.Visible = True
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If cboxBenifitsItems.Text = "NONE" Then MsgBox("Select Benefites", MsgBoxStyle.Information) : cboxBenifitsItems.Focus() : Exit Sub
        If StrSvStatus = "S" Then
            sSQL = "INSERT INTO tblBenefits (EmpID , benID , submitDate, endDate,remark,AddUser ) VALUES ('" & StrEmployeeID & "','" & BenifitsItemsIndex & "','" & Format(dtpSubmithDate.Value, "yyyyMMdd") & "','" & Format(dtpReturnDate.Value, "yyyyMMdd") & "','" & txtRemark.Text & "','" & StrUserID & "')"
            FK_EQ(sSQL, "S", "", True, True, True)
        ElseIf StrSvStatus = "E" Then
            BenifitsItemsIndex = fk_RetString("select benID from tblSetBenefits WHERE Descr ='" & cboxBenifitsItems.Text & "'")
            If cboxBenifitsItems.Text = "NONE" Then MsgBox("Select Benefites", MsgBoxStyle.Information) : cboxBenifitsItems.Focus() : Exit Sub

            If Format(dtpRemoveDate.Value, "yyyyMMdd") = Format("1900/01/01", "yyyyMMdd") Then MsgBox("Select Inactive Date", MsgBoxStyle.Information) : cboxBenifitsItems.Focus() : Exit Sub

            ' If Format(dtpRemoveDate.Value, "yyyyMMdd") = Format("1900/01/01", "yyyyMMdd") Then MsgBox("Select Inactive Date", MsgBoxStyle.Information) : dtpRemoveDate.Focus() : Exit Sub
            sSQL = "UPDATE tblBenefits SET benID = '" & BenifitsItemsIndex & "' ,submitDate = '" & Format(dtpSubmithDate.Value, "yyyyMMdd") & "' ,endDate ='" & Format(dtpReturnDate.Value, "yyyyMMdd") & "' ,remark ='" & txtRemark.Text & "'  where tagID ='" & SelectedRowIndex & "'"
            FK_EQ(sSQL, "E", "", True, True, True)
            If chkStatus.Checked = True Then
                sSQL = "UPDATE tblBenefits SET InactiveUser = '" & StrUserID & "' ,CrCancelDate = getdate() ,InActivelDate ='" & Format(dtpRemoveDate.Value, "yyyyMMdd") & "' ,status='" & chkStatus.CheckState & "' where tagID ='" & SelectedRowIndex & "'"
                FK_EQ(sSQL, "E", "", True, True, True)

                sSQL = "INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate,empRegID) VALUES ('" & Me.Name & "','Inactive Benefit From Employee [Reg ID : " & StrEmployeeID & "] And [Name : " & FK_Rep(StrDispName) & "] Details Inactive [Benefit Category : " & cboxBenifitsItems.Text & "]' ,'" & StrUserID & "',getdate (),'" & StrEmployeeID & "')"
                FK_EQ(sSQL, "U", "", True, True, True)
            End If
        End If
        refresh()

    End Sub

    Private Sub cboxBenifitsItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxBenifitsItems.SelectedIndexChanged
        BenifitsItemsIndex = fk_RetString("select benID from tblSetBenefits WHERE Descr ='" & cboxBenifitsItems.Text & "'")
    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked = True Then
            dtpRemoveDate.Visible = True : lblInactiveDate.Visible = True
        ElseIf chkStatus.Checked = False Then
            dtpRemoveDate.Visible = False : lblInactiveDate.Visible = False
        End If
    End Sub

   
End Class