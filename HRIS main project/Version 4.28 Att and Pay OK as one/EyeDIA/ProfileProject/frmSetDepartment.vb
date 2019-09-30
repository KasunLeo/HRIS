Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI


Public Class frmSetDepartment

    Dim StrSvStatus As String = "S"

    Private Sub frmSetDepts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CenterFormThemed(Me, Panel1, Label25)
        cmdRefresh_Click(sender, e)
        ControlHandlers(Me)
        'lblDesciption.Text = strDescriptionLabel
        Me.ActiveControl = Me.pnlAllData
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

        Me.Close()

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        FK_Clear(Me)

        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoDepts FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT tblSetDept.deptID,tblSetDept.deptName,tblSetDept.shCOde,tblEmployee.dispName FROM tblSetDept,tblEmployee WHERE tblSetDept.regID=tblEmployee.regID Order By DeptID", dgvData, 4)
        'clr_Grid(dgvData)

        ' Set up the Header Color and Font.
        dgvData.EnableHeadersVisualStyles = False
        With dgvData.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .BackColor = Color.White
            .ForeColor = clrFocused
            '.Font = New Font(.Font.FontFamily, .Font.Size, _
            '.Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With

    End Sub

    Private Sub DrawProgress(ByVal g As Graphics, ByVal rect As Rectangle, ByVal percentage As Single)
        'work out the angles for each arc
        Dim progressAngle = CSng(360 / 100 * percentage)
        Dim remainderAngle = 360 - progressAngle

        'create pens to use for the arcs
        Using progressPen As New Pen(Color.LightSeaGreen, 2), remainderPen As New Pen(Color.LightGray, 2)
            'set the smoothing to high quality for better output
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            'draw the blue and white arcs
            g.DrawArc(progressPen, rect, -90, progressAngle)
            g.DrawArc(remainderPen, rect, progressAngle - 90, remainderAngle)
        End Using

        'draw the text in the centre by working out how big it is and adjusting the co-ordinates accordingly
        Using fnt As New Font(Me.Font.FontFamily, 14)
            Dim text As String = percentage.ToString + "%"
            Dim textSize = g.MeasureString(text, fnt)
            Dim textPoint As New Point(CInt(rect.Left + (rect.Width / 2) - (textSize.Width / 2)), CInt(rect.Top + (rect.Height / 2) - (textSize.Height / 2)))
            'now we have all the values draw the text
            g.DrawString(text, fnt, Brushes.Black, textPoint)
        End Using
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

        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "SELECT tblSetDept.deptID,tblSetDept.deptName,tblSetDept.compID,tblSetDept.status,tblSetDept.regID,tblEmployee.dispName,tblSetDept.shCode FROM tblSetDept,tblEmployee WHERE tblSetDept.regID=tblEmployee.regID and tblSetDept.DeptID = '" & txtCode.Text & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item(0)), "", drShw.Item(0))
                txtDesc.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1)))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item(3)), "", drShw.Item(3))
                txtCod.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(4)), "", drShw.Item(4)))
                txtDeptHead.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(5)), "", drShw.Item(5)))
                txtshCode.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(6)), "", drShw.Item(6)))
                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub cmdBrsC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsC.Click
        sSQL = "SELECT     dbo.tblEmployee.RegID, dbo.tblEmployee.dispName, dbo.tblEmployee.NICNumber, dbo.tblEmployee.EnrolNo, dbo.tblDesig.desgDesc,dbo.tblSetEmpCategory.CatDesc " & _
        "FROM         dbo.tblEmployee LEFT OUTER JOIN dbo.tblDesig ON dbo.tblEmployee.DesigID = dbo.tblDesig.DesgID " & _
        "LEFT OUTER JOIN dbo.tblSetEmpCategory ON dbo.tblEmployee.CatID = dbo.tblSetEmpCategory.CatID where tblEmployee.compID ='" & StrCompID & "' and tblEmployee.empStatus <> 9 ORDER BY tblEmployee.RegID"

        Try
            If FK_Br(sSQL) = True Then


                'pb_ShowEmployee(StrEmployeeID)

            End If

        Catch ex As Exception
            MessageBox.Show("No Employees", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally

        End Try

        'StrEmployeeID = ""

        'Dim frmBrs As New frmSrchEmployee
        'frmBrs.ShowDialog()

        'cmdRefresh_Click(sender, e)

        'View Employee information using the EMployee
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "select tblEmployee.RegID,tblEmployee.DispName,tblEmployee.RegDate,tblEmployee.NICNumber,tblSetDept.DeptName,tblEmployee.DeptID,tblemployee.epfno " & _
        " FROM tblEmployee LEFT OUTER JOIN tblSetDept ON tblEmployee.DeptID = tblSetDept.DeptID WHERE tblEmployee.RegID = '" & StrEmployeeID & "' AND tblEmployee.CompID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCod.Text = IIf(IsDBNull(drShw.Item("RegID")), "", drShw.Item("RegID"))
                txtDeptHead.Text = IIf(IsDBNull(drShw.Item("dispName")), "", drShw.Item("dispName"))
                'txtDept.Text = IIf(IsDBNull(drShw.Item("DeptName")), "", drShw.Item("DeptName"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub

    Private Sub tvAllSetup_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)
        Dim strSelect As String = e.Node.Text

        If strSelect = "Add User" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetUsers
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Designation" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetDesignation
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Group" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetCompany
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Branch" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetCBranchs
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Employee Type" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetEmpTypes
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Employee Category" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetCategory
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Shift" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetShiftType
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Shift" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmSetShiftType
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

        If strSelect = "Add Terminal" Then
            Me.pnlDynamic.Controls.Clear()
            Dim frmReg As New frmDeviceInfo
            frmReg.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            frmReg.WindowState = FormWindowState.Maximized

            frmReg.TopLevel = False
            Me.pnlDynamic.Controls.Add(frmReg)
            frmReg.Show()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If UP("Company Profile", "Add department") = False Then Exit Sub

        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            txtDesc.Focus()
            Exit Sub
        End If

        If txtshCode.Text = "" Then
            MsgBox("Enter Short Code", MsgBoxStyle.Information)
            txtshCode.Focus()
            Exit Sub
        End If

        If txtCod.Text = "" Then
            MsgBox("Select HOD Name", MsgBoxStyle.Information)
            cmdBrsC_Click(sender, e)
            Exit Sub
        End If

        Dim bolAct As Boolean = False

        bolAct = fk_CheckEx("SELECT * FROM tblEmployee WHERE DeptID = '" & txtCode.Text & "' AND empStatus <> 9")

        Select Case StrSvStatus
            Case "S"
                'Can't process save with deleted status
                If chkStatus.CheckState = CheckState.Checked Then
                    MsgBox("Can't Save with Deleted Status", MsgBoxStyle.Information)
                    Exit Sub

                End If
            Case "E"
                If bolAct = True Then
                    '    MsgBox("Can't Process Delete when the Active Employee Informations are existing", MsgBoxStyle.Information)
                    '    Exit Sub
                    'Else
                    If MsgBox("Do you want to modify Information", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
        End Select
        Dim retMess As String
        If StrSvStatus = "E" Then
            sSQL = "UPDATE tblSetDept SET deptName='" & Trim(txtDesc.Text) & "',compID='" & StrCompID & "',status=" & chkStatus.CheckState & ",regID='" & txtCod.Text & "',shCode='" & txtshCode.Text & "' WHERE deptID='" & Trim(txtCode.Text) & "'; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Update Department info of DeptID : " & txtCode.Text & " and dept Name : " & txtDesc.Text & " and regid " & txtCod.Text & " and sortCode " & FK_Rep(txtshCode.Text) & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "E", "", False, True, True)
        Else
            sSQL = "INSERT INTO tblSetDept (deptID,deptName,compID,status,regID) VALUES ('" & Trim(txtCode.Text) & "', '" & Trim(txtDesc.Text) & "', '" & StrCompID & "'," & chkStatus.CheckState & ",'" & txtCod.Text & "') ; UPDATE tblControl SET NoDepts=NoDepts+1; INSERT INTO tblEmployeeTaskHistory (trForm,task,crUser,crDate) VALUES ('" & Me.Name & "','Insert Department info of DeptID : " & txtCode.Text & " and dept Name : " & txtDesc.Text & " and regid " & txtCod.Text & " and sortCode " & FK_Rep(txtshCode.Text) & "' ,'" & StrUserID & "',getdate ())  ;"
            FK_EQ(sSQL, "S", "", True, True, True)
        End If

        'retMess = Save_Codes(StrSvStatus, txtCode.Text, txtDesc.Text, chkStatus.CheckState, "NoDepts", "tblSetDept", "DeptID", "DeptName")

        'MsgBox(retMess, MsgBoxStyle.Information)
        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FK_Clear(Me)

        'Generate the Designation Number
        Dim iD As Integer = fk_sqlDbl("SELECT NoDepts FROM tblControl") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT tblSetDept.deptID,tblSetDept.deptName,tblSetDept.shCOde,tblEmployee.dispName FROM tblSetDept,tblEmployee WHERE tblSetDept.regID=tblEmployee.regID Order By DeptID", dgvData, 4)
        'clr_Grid(dgvData)

        ' Set up the Header Color and Font.
        dgvData.EnableHeadersVisualStyles = False
        With dgvData.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleLeft
            .BackColor = Color.White
            .ForeColor = clrFocused
            '.Font = New Font(.Font.FontFamily, .Font.Size, _
            '.Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
        End With

    End Sub
End Class