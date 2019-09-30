Imports System.Data.SqlClient
Imports HRISforBB.GlassTableGDI

Public Class frmSetCBranchs
    Dim StrSvStatus As String = "S"

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

    End Sub

    Private Sub frmBranchs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)

        '=============Copied Start
        '' '' ''        Dim sqlQry As String = " CREATE TABLE [dbo].[tblCBranchs]( " & _
        '' '' '' " [BrID] [nvarchar](3)  NULL," & _
        '' '' '' " [CompID] [nvarchar](3)  NULL," & _
        '' '' '' " [BrName] [nvarchar](100)  NULL," & _
        '' '' '' " [Address] [nvarchar](150)  NULL," & _
        '' '' '' " [Phone] [nvarchar](12)  NULL," & _
        '' '' '' " [Fax] [nvarchar](12)  NULL," & _
        '' '' '' " [Mobile] [nvarchar](12)  NULL," & _
        '' '' '' " [cPerosn] [nvarchar](30)  NULL," & _
        '' '' '' " [Status] [numeric](18, 0) NULL," & _
        '' '' '' " [Email] [nvarchar](40)  NULL" & _
        '' '' ''" ) ON [PRIMARY]"

        '' '' ''        fk_CreateTableR(sqlQry, "tblCBranchs")

        '' '' ''        sqlQry = "insert into tblCBranchs (BrID,CompID,BrName,Address,Phone,Fax,Mobile,cPerosn,Status,Email) values " & _
        '' '' ''" ('999','" & StrCompID & "','NONE','','','','','',0,'')"
        '' '' ''        If False = (fk_CheckEx("select BrName from tblCBranchs where CompID='" & StrCompID & "' and BrID = '999'")) Then
        '' '' ''            fk_UpdateTblR(sqlQry)
        '' '' ''        End If



        '' '' ''        sqlQry = " CREATE TABLE [dbo].[tblEmployee](" & _
        '' '' '' " [RegID] [nvarchar](6)  NULL," & _
        '' '' '' " [RegDate] [datetime] NULL," & _
        '' '' '' " [TitleID] [nvarchar](3)  NULL," & _
        '' '' '' " [SurName] [nvarchar](60)  NULL," & _
        '' '' '' " [FirstName] [nvarchar](150)  NULL," & _
        '' '' '' " [dispName] [nvarchar](200)  NULL," & _
        '' '' '' " [NICNumber] [nvarchar](10)  NULL," & _
        '' '' '' " [DofB] [datetime] NULL," & _
        '' '' '' " [GenderID] [nvarchar](3)  NULL," & _
        '' '' '' " [CivilStID] [nvarchar](3)  NULL," & _
        '' '' '' " [EmpNo] [nvarchar](10)  NULL," & _
        '' '' '' " [EpfNo] [nvarchar](10)  NULL," & _
        '' '' '' " [CompID] [nvarchar](3)  NULL," & _
        '' '' '' " [DesigID] [nvarchar](3)  NULL," & _
        '' '' '' " [BrID] [nvarchar](3)  NULL," & _
        '' '' '' " [DeptID] [nvarchar](3)  NULL," & _
        '' '' '' " [CatID] [nvarchar](3)  NULL," & _
        '' '' '' " [EmpTypeID] [nvarchar](3)  NULL," & _
        '' '' '' " [DefAddID] [nvarchar](3)  NULL," & _
        '' '' '' " [homePhone] [nvarchar](12)  NULL," & _
        '' '' '' " [pMobile] [nvarchar](12)  NULL," & _
        '' '' '' " [OfficePhone] [nvarchar](12)  NULL," & _
        '' '' '' " [Email] [nvarchar](40)  NULL," & _
        '' '' '' " [CntrPeriod] [numeric](18, 0) NULL," & _
        '' '' ''" [ContractStart] [datetime] NULL," & _
        '' '' ''" [ContractEnd] [datetime] NULL," & _
        '' '' '' " [CardID] [nvarchar](3)  NULL," & _
        '' '' '' " [StatusDate] [datetime] NULL," & _
        '' '' '' " [NoAdds] [numeric](18, 0) NOT NULL DEFAULT ((0))," & _
        '' '' '' " [EmpStatus] [numeric](18, 0) NOT NULL DEFAULT ((1))," & _
        '' '' '' " [NoCards] [numeric](18, 0) NOT NULL DEFAULT ((0))," & _
        '' '' '' " [EnrolNo] [numeric](18, 0) NOT NULL DEFAULT ((0))," & _
        '' '' '' " [AtPrType] [numeric](18, 0) NOT NULL DEFAULT ((0))" & _
        '' '' ''" ) ON [PRIMARY]"
        '' '' ''        fk_CreateTableR(sqlQry, "tblEmployee")
        '========================Copied Over

        Button3_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, cmdClose.MouseDown
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 2
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdClose.MouseUp
        Dim crtl As Button
        crtl = sender
        crtl.FlatAppearance.BorderSize = 0
        crtl.FlatAppearance.BorderColor = Me.Panel2.BackColor

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validate control
        If txtCompID.Text = "" Then
            MsgBox("Select the Company", MsgBoxStyle.Information)
            txtCompID.Focus()
            Exit Sub
        End If

        If txtBranchName.Text = "" Then
            MsgBox("Required Branch Name", MsgBoxStyle.Information)
            txtBranchName.Focus()
            Exit Sub
        End If

        If txtBrAddress.Text = "" Then
            MsgBox("Required Branch Address", MsgBoxStyle.Information)
            txtBrAddress.Focus()
            Exit Sub
        End If

        If StrSvStatus = "S" Then
            Dim iB As Integer = fk_sqlDbl("SELECT NoBrs FROM tblCOmpany WHERE compID = '" & StrCompID & "'") + 1
            Dim StrB As String = fk_CreateSerial(3, iB)
            txtBranchID.Text = StrB

        End If

        If txtEmail.Text.Trim <> "" Then
            If False = fk_EAdChk(txtEmail.Text) Then
                MsgBox("Please Enter a Valid E-Mail Address.")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblEmployee WHERE BrID = '" & txtBranchID.Text & "' AND compID = '" & StrCompID & "' AND EmpStatus <> 9")

        'Save information to the table 
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "UPDATE tblCompany SET NoBrs = NoBrs + 1 WHERE compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblCBranchs (BrID, CompID, BrName, Address, Phone, Fax, Mobile, cPerosn, Status,email ) VALUES " & _
                    " ('" & txtBranchID.Text & "','" & StrCompID & "','" & FK_Rep(txtBranchName.Text) & "','" & FK_Rep(txtBrAddress.Text) & "','" & txtPhon.Text & "', " & _
                    " '" & txtMobile.Text & "','" & txtFax.Text & "','" & FK_Rep(txtcPersion.Text) & "'," & chkStatus.CheckState & ",'" & txtEmail.Text & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)

                Case "E"
                    If chkStatus.Checked = True Then
                        If bolEx = True Then
                            MsgBox("Can't Process Deletion when the related Employees are existing", MsgBoxStyle.Critical)
                            Exit Sub
                        ElseIf bolEx = False Then
                            If MsgBox("Do you want to Delete this Branch ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                Exit Sub
                            End If
                        End If
                    End If

                    'Process Update 
                    sqlQRY = "UPDATE tblCBranchs SET BrName = '" & FK_Rep(txtBranchName.Text) & "', Address = '" & FK_Rep(txtBrAddress.Text) & "' , " & _
                    " Phone = '" & txtPhon.Text & "' , Fax = '" & txtFax.Text & "' , Mobile = '" & txtMobile.Text & "', " & _
                    " cPerosn = '" & FK_Rep(txtcPersion.Text) & "', Status = " & chkStatus.CheckState & ",Email='" & txtEmail.Text & "' WHERE BrID = '" & txtBranchID.Text & "' AND CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    cmdRefresh_Click(sender, e)


            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try
    End Sub

    Private Sub cmdBrsB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBrsB.Click

        'With dgvBrInfo
        '    If .Visible = True Then
        '        .Visible = False
        '    Else
        '        .Visible = True
        '        .Height = 200
        '        Load_InformationtoGrid("SELECT BrID,BrName FROM tblCBranchs WHERE CompID = '" & txtCompID.Text & "' and BrID <> '999' Order By BrID", dgvBrInfo, 2)

        '    End If

        'End With

    End Sub

    Private Sub dgvBrInfo_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBrInfo.CellClick
        'If dgvBrInfo.RowCount = 0 Then
        '    dgvBrInfo.Visible = False
        '    Exit Sub
        'End If


        'show the branch information 
        Dim StrBrID As String = dgvBrInfo.Item(0, dgvBrInfo.CurrentRow.Index).Value

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblCBranchs WHERE brID = '" & StrBrID & "' AND compID = '" & StrCompID & "'"

        ', CompID, , , , , , , 
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtBranchID.Text = IIf(IsDBNull(drShw.Item("BrID")), "", drShw.Item("BrID"))
                txtBranchName.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("BrName")), "", drShw.Item("BrName")))
                txtBrAddress.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("Address")), "", drShw.Item("Address")))
                txtPhon.Text = IIf(IsDBNull(drShw.Item("Phone")), "", drShw.Item("Phone"))
                txtFax.Text = IIf(IsDBNull(drShw.Item("Fax")), "", drShw.Item("Fax"))
                txtMobile.Text = IIf(IsDBNull(drShw.Item("Mobile")), "", drShw.Item("Mobile"))
                txtcPersion.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item("cPerosn")), "", drShw.Item("cPerosn")))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item("Status")), 0, drShw.Item("Status"))
                txtEmail.Text = IIf(IsDBNull(drShw.Item("Email")), "", drShw.Item("Email"))

                StrSvStatus = "E"
                'dgvBrInfo.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
    End Sub

    Private Sub txtPhon_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhon.KeyPress, txtMobile.KeyPress, txtFax.KeyPress
        If (Asc(e.KeyChar) < 48) Or (Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If

    End Sub

    Private Sub cmdBrsB_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrsB.MouseEnter

        Me.cmdBrsB.FlatStyle = FlatStyle.Standard
        Me.cmdBrsB.FlatAppearance.BorderSize = 1
        Me.cmdBrsB.Width = 24
        Me.cmdBrsB.Height = 24

    End Sub

    Private Sub cmdBrsB_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrsB.MouseLeave

        Me.cmdBrsB.FlatStyle = FlatStyle.Flat
        Me.cmdBrsB.FlatAppearance.BorderSize = 0
        Me.cmdBrsB.Width = 22
        Me.cmdBrsB.Height = 22

    End Sub

    Private Sub cmdBrsC_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrsC.MouseEnter

        Me.cmdBrsC.FlatStyle = FlatStyle.Standard
        Me.cmdBrsC.FlatAppearance.BorderSize = 1
        Me.cmdBrsC.Width = 24
        Me.cmdBrsC.Height = 24

    End Sub

    Private Sub cmdBrsC_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBrsC.MouseLeave

        Me.cmdBrsC.FlatStyle = FlatStyle.Flat
        Me.cmdBrsC.FlatAppearance.BorderSize = 0
        Me.cmdBrsC.Width = 22
        Me.cmdBrsC.Height = 22

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If UP("Company Profile", "Add company branch") = False Then Exit Sub

        'Validate control
        If txtCompID.Text = "" Then
            MsgBox("Select the Company", MsgBoxStyle.Information)
            txtCompID.Focus()
            Exit Sub
        End If

        If txtBranchName.Text = "" Then
            MsgBox("Required Branch Name", MsgBoxStyle.Information)
            txtBranchName.Focus()
            Exit Sub
        End If

        If txtBrAddress.Text = "" Then
            MsgBox("Required Branch Address", MsgBoxStyle.Information)
            txtBrAddress.Focus()
            Exit Sub
        End If

        If StrSvStatus = "S" Then
            Dim iB As Integer = fk_sqlDbl("SELECT NoBrs FROM tblCOmpany WHERE compID = '" & StrCompID & "'") + 1
            Dim StrB As String = fk_CreateSerial(3, iB)
            txtBranchID.Text = StrB

        End If

        If txtEmail.Text.Trim <> "" Then
            If False = fk_EAdChk(txtEmail.Text) Then
                MsgBox("Please Enter a Valid E-Mail Address.")
                txtEmail.Focus()
                Exit Sub
            End If
        End If

        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblEmployee WHERE BrID = '" & txtBranchID.Text & "' AND compID = '" & StrCompID & "' AND EmpStatus <> 9")

        'Save information to the table 
        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvStatus
                Case "S"
                    sqlQRY = "UPDATE tblCompany SET NoBrs = NoBrs + 1 WHERE compID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "INSERT INTO tblCBranchs (BrID, CompID, BrName, Address, Phone, Fax, Mobile, cPerosn, Status,email ) VALUES " & _
                    " ('" & txtBranchID.Text & "','" & StrCompID & "','" & FK_Rep(txtBranchName.Text) & "','" & FK_Rep(txtBrAddress.Text) & "','" & txtPhon.Text & "', " & _
                    " '" & txtMobile.Text & "','" & txtFax.Text & "','" & FK_Rep(txtcPersion.Text) & "'," & chkStatus.CheckState & ",'" & txtEmail.Text & "')"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Saved", MsgBoxStyle.Information)
                    Button3_Click(sender, e)

                Case "E"
                    If chkStatus.Checked = True Then
                        If bolEx = True Then
                            MsgBox("Can't Process Deletion when the related Employees are existing", MsgBoxStyle.Critical)
                            Exit Sub
                        ElseIf bolEx = False Then
                            If MsgBox("Do you want to Delete this Branch ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                Exit Sub
                            End If
                        End If
                    End If

                    'Process Update 
                    sqlQRY = "UPDATE tblCBranchs SET BrName = '" & FK_Rep(txtBranchName.Text) & "', Address = '" & FK_Rep(txtBrAddress.Text) & "' , " & _
                    " Phone = '" & txtPhon.Text & "' , Fax = '" & txtFax.Text & "' , Mobile = '" & txtMobile.Text & "', " & _
                    " cPerosn = '" & FK_Rep(txtcPersion.Text) & "', Status = " & chkStatus.CheckState & ",Email='" & txtEmail.Text & "' WHERE BrID = '" & txtBranchID.Text & "' AND CompID = '" & StrCompID & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    MsgBox("Information Modified", MsgBoxStyle.Information)
                    Button3_Click(sender, e)


            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        chkStatus.Checked = False

        Dim crtl As Control
        For Each crtl In Me.Panel2.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next

        'Get the current cumpany information to the company form
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQRY As String = "SELECT * FROM tblCompany WHERE CompID = '" & StrCompID & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQRY, cnShw)
            Dim drshw As SqlDataReader = cmShw.ExecuteReader
            If drshw.Read = True Then
                txtCompID.Text = IIf(IsDBNull(drshw.Item("compID")), "", drshw.Item("compID"))
                txtcName.Text = IIf(IsDBNull(drshw.Item("cName")), "", drshw.Item("CName"))

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

        'Generate the Branch ID when selected
        Dim iB As Integer = fk_sqlDbl("SELECT NoBrs FROM tblCOmpany WHERE compID = '" & StrCompID & "'") + 1
        Dim StrB As String = fk_CreateSerial(3, iB)
        txtBranchID.Text = StrB

        StrSvStatus = "S"
        Load_InformationtoGrid("SELECT BrID,BrName FROM tblCBranchs WHERE CompID = '" & txtCompID.Text & "' and BrID <> '999' Order By BrID", dgvBrInfo, 2)

    End Sub

End Class