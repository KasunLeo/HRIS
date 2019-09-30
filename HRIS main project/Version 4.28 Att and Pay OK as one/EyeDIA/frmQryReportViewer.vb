Public Class frmQryReportViewer
    Dim StrFullFld As String = ""

    Private Sub frmQryReportViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

   

    Private Sub dgvAllFldList_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAllFldList.CurrentCellDirtyStateChanged
        If dgvAllFldList.IsCurrentCellDirty Then
            dgvAllFldList.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub


    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        ListComboAll(cmbDesg, "SELECT * FROM tblDesig WHERE Status = 0 Order By DesgID", "desgDesc")
        ListComboAll(cmbDept, "select * From tblSetDept WHERE Status = 0  AND deptid in ('" & StrUserLvDept & "') Order By DeptID", "deptName")
        ListComboAll(cmbCat, "select * From tblSEtEmpCategory WHERE Status = 0 Order By CatID", "catDesc")
        ListComboAll(cmbType, "select tDesc from tblSetEmpType WHERE Status = 0 order by tDesc asc", "tDesc")
        ListComboAll(cmbBranch, "SELECT BrName FROM [tblCBranchs] WHERE Status = 0 order by BrID asc", "BrName")
        ListComboAll(cmbTitle, "SELECT titleDesc FROM [tblSetTitle] order by titleID asc", "titleDesc")

        ListComboAll(cmbEmpAct, "SELECT Dscrb FROM [tblSetActTypesHRIS] WHERE Status = 0 order by ActID asc", "Dscrb")
        ListComboAll(cmbEmpSubCat, "SELECT Dscrb FROM [tblSetSubCatHRIS] WHERE Status = 0 order by CatID asc", "Dscrb")
        ListComboAll(cmbNearCity, "SELECT Dscrb FROM [tblSetNearsCitysHRIS] WHERE Status = 0 order by CityID asc", "Dscrb")

        Dim sqlQRY As String = ""
        sqlQRY = "select 'false',tblTableFeildList.Fld_ID,tblTableFeildList.fld_FullName,tblTableList.T_Desc,tblTableFeildList.Fld_Desc From tblTableList,tblTableFeildList" & _
        " WHERE tblTableList.TableID = tblTableFeildList.TableID AND tblTableFeildList.r_Status  = 1 Order By tblTableFeildList.TableID,tblTableFeildList.fld_ID"

        Load_InformationtoGrid(sqlQRY, dgvAllFldList, 5)

    End Sub

    Private Sub dgvAllFldList_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAllFldList.CellValueChanged
        StrFullFld = ""
        Dim StrFldDesc As String = ""

        If dgvAllFldList.Columns(e.ColumnIndex).Name = "fCheckBox" Then
            Dim count1 As Integer = 0
            Dim StrCurrentFld As String = ""

            For Each row As DataGridViewRow In dgvAllFldList.Rows
                StrCurrentFld = row.Cells(2).Value
                StrFldDesc = row.Cells(4).Value
                StrCurrentFld = StrCurrentFld & "[" & StrFldDesc & "]"
                If row.Cells("fCheckBox").Value IsNot Nothing And row.Cells("fCheckBox").Value = True Then
                    If StrFullFld = "" Then StrFullFld = StrCurrentFld Else StrFullFld = StrFullFld + "," & StrCurrentFld
                    count1 += 1
                End If
            Next
        End If

        Dim StrWhereCLOSE As String = "" : Dim StrTableLIST As String = ""

        Dim StrDeptname As String = IIf(cmbDept.Text = "[ALL]", "", (cmbDept.Text))
        Dim StrSubCatName As String = IIf(cmbCat.Text = "[ALL]", "", (cmbCat.Text))
        Dim StrDesigName As String = IIf(cmbDesg.Text = "[ALL]", "", (cmbDesg.Text))
        Dim StrBranchName As String = IIf(cmbBranch.Text = "[ALL]", "", (cmbBranch.Text))
        Dim StrType As String = IIf(cmbType.Text = "[ALL]", "", (cmbType.Text))
        Dim StrTitle As String = IIf(cmbTitle.Text = "[ALL]", "", (cmbTitle.Text))
        Dim StrRAct As String = IIf(cmbEmpAct.Text = "[ALL]", "", (cmbEmpAct.Text))
        Dim StrRSubCat As String = IIf(cmbEmpSubCat.Text = "[ALL]", "", (cmbEmpSubCat.Text))
        Dim StrRNCityName As String = IIf(cmbNearCity.Text = "[ALL]", "", (cmbNearCity.Text))


        StrTableLIST = "dbo.tblEmployee,tblCBranchs,tblSetDept,tblDesig,tblSetEmpCategory,tblCompany, " & _
         " tblsettitle,tblsetemptype,tblSetSubCatHRIS,tblSetActTypesHRIS"

        StrWhereCLOSE = " dbo.tblEmployee.ComPID = dbo.tblCBranchs.CompID AND    " & _
            " dbo.tblEmployee.BrID = dbo.tblCBranchs.BrID AND   " & _
            "dbo.tblEmployee.DeptID = dbo.tblSetDept.DeptID  AND    " & _
            "dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID  AND   " & _
            "dbo.tblEmployee.titleID = dbo.tblsettitle.titleID  AND   " & _
            "dbo.tblEmployee.catID = dbo.tblSetEmpCategory.catID  AND   " & _
            "dbo.tblEmployee.EmpTypeID = dbo.tblsetemptype.typeID AND   " & _
            "dbo.tblEmployee.SubCatID = dbo.tblSetSubCatHRIS.CatID AND   " & _
            "dbo.tblEmployee.ActType = dbo.tblSetActTypesHRIS.ActID AND   " & _
            "tblEmployee.DeptID IN    ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "')  " & _
            "AND (dbo.tblEmployee.RegID LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.DispName LIKE '%" & txtSearch.Text & "%' OR     " & _
            "dbo.tblEmployee.EMPNo LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.NICNumber LIKE '%" & txtSearch.Text & "%' OR dbo.tblEmployee.enrolNo LIKE '%" & txtSearch.Text & "%' OR    " & _
            "dbo.tblEmployee.EPFNo LIKE '%" & txtSearch.Text & "%') AND  " & _
            "(dbo.tblDesig.desgDesc LIKE '" & StrDesigName & "%' AND    " & _
            "dbo.tblSetDept.deptName LIKE '" & StrDeptname & "%' AND   " & _
            "dbo.tblsettitle.titleDesc LIKE '" & StrTitle & "%' AND   " & _
            "dbo.tblsetemptype.tDesc LIKE '" & StrType & "%' AND   " & _
            " dbo.tblSetEmpCategory.catDesc LIKE '" & StrSubCatName & "%' AND   " & _
            " dbo.tblSetSubCatHRIS.Dscrb LIKE '" & StrRSubCat & "%' AND   " & _
            " dbo.tblSetActTypesHRIS.Dscrb LIKE '" & StrRAct & "%' AND   " & _
            "dbo.tblCBranchs.BrName LIKE '" & StrBranchName & "%')   "

        Dim sqlQ As String = ""
        sqlQ = _FKReportVIEW(StrFullFld, StrTableLIST, StrWhereCLOSE)
        dgvFldAllList.Columns.Clear()
        If StrFullFld = "" Then Exit Sub
        FK_LoadGridWithDS(sqlQ, dgvFldAllList)
    End Sub

    Public Function _FKReportVIEW(ByVal StrFldList As String, ByVal StrTableList As String, ByVal StrWhereList As String) As String


        Dim StrRETURNVAL As String = ""
        Dim StrMainQRY As String = ""
        Try
            StrMainQRY = "SELECT " & StrFldList & " FROM " & StrTableList & " WHERE " & StrWhereList

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        StrRETURNVAL = StrMainQRY
        Return StrRETURNVAL
    End Function

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

End Class