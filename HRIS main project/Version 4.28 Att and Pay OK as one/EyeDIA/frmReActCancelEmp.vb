Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmReActCancelEmp

    Dim empID As String

    Private Sub frmReActCancelEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UP("Resign Employee", "View risigned employee(s)") = False Then Exit Sub

        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)

        '==================Copied Start
        '' '' ''Dim strQry As String = "alter table tblControl add NoTrs numeric (18,0) not null default 0"
        '' '' ''fk_AddFieldToTbl(strQry, "tblControl", "NoTrs")

        '=================Copied Over
        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        chkActive.Checked = False

        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next

        txtCode.Focus()
        dtpRjDate.Value = Now.Date
    End Sub

    Private Sub txtCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged

        'If txtCode.Text.Length >= 6 Then
        '    Dim intNos As Integer = fk_sqlDbl("SELECT count(*) FROM tblEmployee WHERE epfNo = '" & txtCode.Text & "' AND EmpStatus = 9")
        '    If intNos > 1 Then
        '        dgvEmp.Visible = True
        '        Dim sqlQ As String = "SELECT RegID ,EpfNo,dispName from tblEmployee WHERE epfNo = '" & txtCode.Text & "' AND EmpStatus = 9"
        '        Load_InformationtoGrid(sqlQ, dgvEmp, 3)
        '        dgvEmp.Focus()
        '    Else
        '        StrEmployeeID = fk_RetString("SELECT RegID FROM tblEmployee Where EpfNo = '" & txtCode.Text & "' AND EmpStatus = 9")

        '        Dim cnShw As New SqlConnection(sqlConString)
        '        cnShw.Open()
        '        Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID " & _
        '        " FROM tblEmployee INNER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        '        Try
        '            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
        '            Dim drShw As SqlDataReader = cmShw.ExecuteReader
        '            If drShw.Read = True Then
        '                txtCode.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
        '                txtempName.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
        '                txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))

        '            End If
        '            chkActive.Focus()

        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        Finally
        '            cnShw.Close()
        '        End Try
        '    End If


        'End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If txtCode.Text = "" Then
            MsgBox("Please Select the Cancelled the Employee.")
            txtCode.Focus()
            Exit Sub
        End If

        If UP("Resign Employee", "View risigned employee(s)") = False Then Exit Sub

        If chkActive.CheckState = CheckState.Unchecked Then
            MsgBox("Not Check as Active", MsgBoxStyle.Information)
            Exit Sub
        End If


        'The following section added by Rajitha.
        Dim strTitleEx As String = ""
        Dim strDesgEx As String = ""
        Dim sBrEx As String = ""
        Dim sDepEx As String = ""
        Dim sCatEx As String = ""
        Dim sEmpTypEx As String = ""
        Dim sDefAdIdEx As String = ""
        Dim strQry As String = "Select TitleID,DesigID,BrID,DeptId,CatID,EmpTypeID,DefAddId from tblEmployee where regid='" & txtCode.Text & "' and compId='" & StrCompID & "'"
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim sqlComnd As New SqlCommand(strQry, cnSave)
        Dim sqlR As SqlDataReader = sqlComnd.ExecuteReader
        If sqlR.Read Then 'TitleID,DesigID,BrID,DeptId,CatID,EmpTypeID,DefAddId,
            strTitleEx = IIf(IsDBNull(sqlR.Item("titleId")), "", sqlR.Item("titleId"))
            strDesgEx = IIf(IsDBNull(sqlR.Item("DesigID")), "", sqlR.Item("DesigID"))
            sBrEx = IIf(IsDBNull(sqlR.Item("BrID")), "", sqlR.Item("BrID"))
            sDepEx = IIf(IsDBNull(sqlR.Item("DeptID")), "", sqlR.Item("DeptID"))
            sCatEx = IIf(IsDBNull(sqlR.Item("CatID")), "", sqlR.Item("CatID"))
            sEmpTypEx = IIf(IsDBNull(sqlR.Item("EmpTypeID")), "", sqlR.Item("EmpTypeID"))
            sDefAdIdEx = IIf(IsDBNull(sqlR.Item("DefAddID")), "", sqlR.Item("DefAddID"))
        End If
        sqlR.Close()
        'check the cancelled employee's settings active or not..
        'chk the designation
        'strQry = "update tblSetTitle set status=0 where titleId='" & strTitleEx & "' and compId='" & StrCompID & "'" & _
        '" update tblDesig set Status=0 where desgId='" & strDesgEx & "' and compId='" & StrCompID & "'" & _
        '" update tblCBranchs set status=0 where Brid='" & sBrEx & "' and compid='" & StrCompID & "'" & _
        '" update tblSetDept set status=0 where deptID='" & sDepEx & "' and compid='" & StrCompID & "'" & _
        '" update tblSetEmpCategory set status=0 where catId='" & sCatEx & "' and compid='" & StrCompID & "'" & _
        '" update tblSetEmpType set status=0 where typeId='" & sEmpTypEx & "' and compId='" & StrCompID & "'"



        'Get Transaction 
        Dim iTr As Integer = fk_sqlDbl("SELECT NoTrs FROM tblControl") + 1
        Dim StrTr As String = fk_CreateSerial(10, iTr)

        If MsgBox("Do you want to Active This", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            Dim cmSave As New SqlCommand
            cmSave = cnSave.CreateCommand
            Dim trSave As SqlTransaction = cnSave.BeginTransaction
            cmSave.Transaction = trSave
            
            Dim sqlQRY As String
            Try
                If Format(dtpRjDate.Value, "yyyyMMdd") = "19000101" Then
                    sqlQRY = "UPDATE tblEmployee SET EmpStatus = 1 ,statusDate='1900-01-01 00:00:00.000' WHERE RegID = '" & empID & "'" & _
                                   " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES " & _
                                   " ('" & StrTr & "','" & Format(dtWorkingDate, "yyyyMMdd") & "','" & Me.Name & "','AE','Activate Canceled Employee Effect From " & Format(dtpRjDate.Value, "yyyyMMdd") & "','" & StrUserID & "',0,1,'" & empID & "')" & _
                                   " UPDATE tblControl SET NoTrs = NoTrs + 1; UPDATE tblREmpHist SET rStatus=1 WHERE regid='" & empID & "' AND rStatus=0"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                Else
                    sqlQRY = "UPDATE tblEmployee SET EmpStatus = 1 ,statusDate='1900-01-01 00:00:00.000',regDate='" & Format(dtpRjDate.Value, "yyyyMMdd") & "' WHERE RegID = '" & empID & "'" & _
               " INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status,EmpID) VALUES " & _
               " ('" & StrTr & "','" & Format(dtWorkingDate, "yyyyMMdd") & "','" & Me.Name & "','AE','Activate Canceled Employee Effect From " & Format(dtpRjDate.Value, "yyyyMMdd") & "','" & StrUserID & "',0,1,'" & empID & "')" & _
               " UPDATE tblControl SET NoTrs = NoTrs + 1; UPDATE tblREmpHist SET rStatus=1 WHERE regid='" & empID & "' AND rStatus=0"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                End If
               

                trSave.Commit()

                MsgBox("Employee Activated", MsgBoxStyle.Information)
                cmdRefresh_Click(sender, e)

            Catch ex As Exception
                MsgBox(ex.Message)
                trSave.Rollback()
            Finally
                cnSave.Close()
            End Try
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        strReActEmp = "Ra"

        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
       "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
       "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus = 9 ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then

                'StrEmployeeID = FK_Read("RegID")
                'pb_ShowEmployee(StrEmployeeID)

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try

        ''Dim frmBrs As New frmSrchEmployee
        ''frmBrs.ShowDialog()
        txtCode.Text = StrEmployeeID

        ' strReActEmp = "Ac"

        Dim sqlconq As New SqlConnection(sqlConString)

        sqlconq.Open()
        Dim sqlQ As String = "SELECT  tblEmployee.[regid],tblEmployee.[dispName] ,tblEmployee.[EpfNo],(select dbo.tblSetDept.DeptName from dbo.tblSetDept where dbo.tblSetDept.DeptID=tblEmployee.[DeptID]) as 'depName',tblEmployee.[EmpStatus]  FROM tblEmployee where regid='" & txtCode.Text & "'"
        Try

            Dim cmLog As New SqlCommand(sqlQ, sqlconq)
            Dim drLog As SqlDataReader = cmLog.ExecuteReader
            If drLog.Read = True Then
                empID = IIf(IsDBNull(drLog.Item("regid")), "", drLog.Item("regid"))
                'txtCode.Text = IIf(IsDBNull(drLog.Item("EpfNo")), "", drLog.Item("EpfNo"))
                txtDept.Text = IIf(IsDBNull(drLog.Item("depName")), "", drLog.Item("depName"))
                txtempName.Text = IIf(IsDBNull(drLog.Item("dispName")), "", drLog.Item("dispName"))
                Dim intVal As Integer = IIf(IsDBNull(drLog.Item("EmpStatus")), "", drLog.Item("EmpStatus"))
                chkActive.Checked = IIf(intVal = 9, "False", "True")

            End If
        Catch
        Finally
            sqlconq.Close()
        End Try

    End Sub

    Private Sub Button1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter

        Me.Button1.FlatStyle = FlatStyle.Standard
        Me.Button1.FlatAppearance.BorderSize = 1
        Me.Button1.Width = 24
        Me.Button1.Height = 24

    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave

        Me.Button1.FlatStyle = FlatStyle.Flat
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Width = 22
        Me.Button1.Height = 22

    End Sub

    Public Sub ViewEmployee()
       
        sSQL = "select RegID," & sqlTagName & ",DispName AS 'Employee Name',NICNumber AS 'NIC Number' FROM tblEmployee WHERE (DispName like '%" & txtSearch.Text & "%' OR " & sqlTag1 & " like '%" & txtSearch.Text & "%' OR NICNumber like '%" & txtSearch.Text & "%' ) and EmpStatus=9 ORDER BY " & sqlTag1 & ""
        Fk_FillGrid(sSQL, dgvAllEmp)
        dgvAllEmp.Columns(0).Visible = False
        For X As Integer = 0 To dgvAllEmp.Columns.Count - 1
            dgvAllEmp.Columns(X).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        ViewEmployee()
    End Sub
End Class