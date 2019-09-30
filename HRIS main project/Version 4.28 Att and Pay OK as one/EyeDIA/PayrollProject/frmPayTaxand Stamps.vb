Imports System.Data.SqlClient

Public Class FrmTaxand_Stamps

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'FK_Clear(Me)
        FillCom2(cmbID, "Select ID from tblNewTaxFormula where Status=0 ")
        cmbID.Items.Add(GetVal("Select PAYETAXID from tblControl") + 1)
        cmbID.Text = GetVal("Select PAYETAXID from tblControl") + 1
        strSaveStatus = "S"
        txtFormula.Text = "update tblTempTax set Amount=(DedSalAmount*2/100)-2000 where DedSalAmount>50000"

        sSQL = "Select ID from  tblNewTaxFormula where Status='0'"
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            LstAll.Items.Clear()
            Dim sqlcombo_department As New SqlCommand(sSQL, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()

            While redcombo_department.Read()
                LstAll.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        cmbSalItem2_SelectedIndexChanged(sender, e)
        CHKRemove.Checked = False
    End Sub

    Private Sub FrmTaxand_Stamps_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label2)
        ControlHandlers(Me)
        sSQL = "Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where Status='0' order by Description asc;"
        FillCom2(cmbSalItem1, sSQL)
        FillCom2(cmbSalItem2, sSQL)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If FK_GetIDR(cmbSalItem1.Text) = "" Then MsgBox("Please Select Salary Items from the List", MsgBoxStyle.Critical) : Exit Sub
        If FK_GetIDR(cmbSalItem2.Text) = "" Then MsgBox("Please SelectProfile from the List", MsgBoxStyle.Critical) : Exit Sub
        If txtFormula.Text = "" Then MsgBox("Please Enter Formula to Process", MsgBoxStyle.Critical) : Exit Sub
        If strSaveStatus = "S" Then
            cmbID.Text = Format(GetVal("Select PAYETAXID from tblControl") + 1, "00#")
            sSQL = "insert into tblNewTaxFormula (ID,TotSalID,DedSalID,Formula,Status) values ('" & cmbID.Text & "','" & FK_GetIDR(cmbSalItem1.Text) & "','" & FK_GetIDR(cmbSalItem2.Text) & "','" & txtFormula.Text & "','0');update tblcontrol set PAYETAXID=PAYETAXID+1"
            If FK_EQ(sSQL, "S", "", True, True, True) = True Then txtFormula.Text = "" : cmdRefresh_Click(sender, e)
        End If
        If strSaveStatus = "E" Then
            sSQL = "Update tblNewTaxFormula set TotSalID='" & FK_GetIDR(cmbSalItem1.Text) & "',DedSalID='" & FK_GetIDR(cmbSalItem2.Text) & "',Formula='" & txtFormula.Text & "',Status='" & CHKRemove.CheckState & "' where ID='" & cmbID.Text & "'"
            If FK_EQ(sSQL, "E", "", True, True, True) = True Then txtFormula.Text = "" : cmdRefresh_Click(sender, e)
        End If
        sSQL = "Select ID from  tblNewTaxFormula where Status='0'"
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            LstAll.Items.Clear()
            Dim sqlcombo_department As New SqlCommand(sSQL, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()

            While redcombo_department.Read()
                LstAll.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        cmbSalItem2_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub cmbSalItem2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSalItem2.SelectedIndexChanged
        sSQL = "Select ID from  tblNewTaxFormula where Status='0' and TotSalID='" & FK_GetIDR(cmbSalItem1.Text) & "' and DedSalID='" & FK_GetIDR(cmbSalItem2.Text) & "'"
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            LstCurrent.Items.Clear()
            Dim sqlcombo_department As New SqlCommand(sSQL, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()

            While redcombo_department.Read()
                LstCurrent.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LstCurrent_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCurrent.DoubleClick
        If LstCurrent.Items.Count = 0 Then Exit Sub
        cmbID.Text = LstCurrent.Text
        cmbSalItem1.Text = fk_RetString("Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where ID in (Select TotSalID from  tblNewTaxFormula where id='" & LstCurrent.Text & "')")
        cmbSalItem2.Text = fk_RetString("Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where ID in (Select DedSalID from  tblNewTaxFormula where id='" & LstCurrent.Text & "')")

        txtFormula.Text = fk_RetString("Select Formula from  tblNewTaxFormula where id='" & LstCurrent.Text & "'")
        strSaveStatus = "E"

    End Sub

    Private Sub LstCurrent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstCurrent.SelectedIndexChanged

    End Sub

    Private Sub LstAll_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstAll.DoubleClick
        If LstAll.Items.Count = 0 Then Exit Sub
        cmbID.Text = LstAll.Text
        cmbSalItem1.Text = fk_RetString("Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where ID in (Select TotSalID from  tblNewTaxFormula where id='" & LstAll.Text & "')")
        cmbSalItem2.Text = fk_RetString("Select Description + '=' + cast(ID as varchar(5)) from tblSalaryItems where ID in (Select DedSalID from  tblNewTaxFormula where id='" & LstAll.Text & "')")

        txtFormula.Text = fk_RetString("Select Formula from  tblNewTaxFormula where id='" & LstAll.Text & "'")
        strSaveStatus = "E"

    End Sub

    Private Sub LstAll_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstAll.SelectedIndexChanged

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

       
            sSQL = "Select Distinct TotSalID,DedSalID from tblNewtaxformula where Status='0'"
            Fk_FillGrid(sSQL, dgvTaxGrid1)
            sSQL = "Select RegID from tblPayrollEmployee where Status='0'"
            Fk_FillGrid(sSQL, dgvTaxEmployee)
            sSQL = "Create table tblTempTax (TotSalID varchar(3), DedSalID varchar(3), RegID varchar(8),Amount Decimal(18,2) not null Default 0,DedSalAmount  Decimal(18,2) not null Default 0)"
            EQ(sSQL)
            sSQL = "Delete from tblTempTax;"
            For X = 0 To dgvTaxGrid1.RowCount - 1
                For I = 0 To dgvTaxEmployee.RowCount - 1
                    sSQL = sSQL & " Insert into tblTempTax (TotSalID,DedSalID,RegID) values ('" & dgvTaxGrid1.Item(0, X).Value & "','" & dgvTaxGrid1.Item(1, X).Value & "','" & dgvTaxEmployee.Item(0, I).Value & "'); "
                Next
            Next
            sSQL = sSQL & " Update tblTempTax set DedSalAmount=tblSD.Amount from tblSD inner join tblTempTax on tblSD.RegID=tblTempTax.RegID  where tblSD.SalID=tblTempTax.TotSalID and tblSD.type1='2'"
            FK_EQ(sSQL, "S", "", False, False, True)
            sSQL = "select Formula from tblNewtaxformula where Status='0';"
            Fk_FillGrid(sSQL, dgvTaxEmployee)
            sSQL = ""
            For I = 0 To dgvTaxEmployee.RowCount - 1
                sSQL = sSQL & dgvTaxEmployee.Item(0, I).Value
            Next
            FK_EQ(sSQL, "S", "", False, False, True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub txtFormula_TextChanged(sender As Object, e As EventArgs) Handles txtFormula.TextChanged

    End Sub
End Class