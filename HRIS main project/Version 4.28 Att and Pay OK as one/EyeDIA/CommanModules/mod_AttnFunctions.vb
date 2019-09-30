Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports System.Drawing.Imaging

Module mod_AttnFunctions
    Public intRosterOpt As Integer = 0
    Public dtSelDate As Date
    Public DS As New DataSet
    Public BrowseTrue As Boolean = False
    Public ssearch, ssql1 As String
    Public StrTFldName As String = "" : Public StrTTrMode As String = "" : Public StrTTable As String = "" : Public StrTSrcID As String = "" : Public StrTSrcDesc As String = ""
    Public StrUserLvShifts As String = ""
    Public intTotEmps As Integer = 0

    Public StrEmployeeID As String
    Public strKEmployeeID As String = ""
    Public StrUserLvDept As String
    Public StrDispName As String
    Public CurrentUser As String
    Public StrNICSex As String
    Public dtNICDoB As Date
    Public StrUserID As String
    Public StrUlvlID As String
    Public intCurrentYear As Integer
    Public strFormula As String = ""
    Public UserLevelID As String = ""
    Public StrOffShiftID As String = "999" ' Off Shift ID is the ID which assign in 24 Hour Shift as 
    Public StrSelectionFormula As String = ""
    Public sSQL As String
    Public StrTitleID As String
    Public bolLogged As Boolean = False
    Public StrGenderID As String
    Public StrDesgID As String
    Public StrBranchID As String
    Public StrDeptID As String
    Public StrCategoryID As String
    Public StrEmpTypeID As String
    Public StrCivilStID As String
    Public IsMealAvbl As Integer = 0
    Public dtShiftdate As Date
    Public strLoadReport As String = ""
    Public dtSelFrDate As Date
    Public dtSelToDate As Date
    Public dgvMultiGRID As DataGridView
    Public intOtCalMeth As Integer = 0

    Public StrRpFromDate As String
    Public StrRpToDate As String

    'Crystal Report Related
    '-------------------------------------------
    Public StrRepFile As String
    Public StrRepTitle As String
    Public StrSelectionFomula As String

    Public intWorkingYear As Integer
    Public intWorkingMonth As Integer
    Public StrRepHeadPath As String = Application.StartupPath & "\Reports\"
    Public dgvFillGridforRead As New DataGridView
    Public IsEmpWiseChart As Integer = 0
    Public strExsisted As String = ""
    Public strExsistedCode As String = ""
    Public strNewCode As String = ""
    Public sSelect As String 'Use for Globle Pickup Form
    Public NetworkType As String = "0"
    Public strSaveStatus As String = "S"
    Public cPhone As String
    Public bolLoggedPay As Boolean = False

    Dim dblRmvBeginOT As Double = 1

#Region "Handlers"

    Public Sub ControlHandlers(ByVal Container As Control)

        Dim C As Control

        For Each C In Container.Controls
            If TypeOf C Is TextBox Then
                AddHandler C.GotFocus, AddressOf TextBoxGotFocus
                AddHandler C.LostFocus, AddressOf TextBoxLostFocus
            ElseIf TypeOf C Is MaskedTextBox Then
                AddHandler C.GotFocus, AddressOf MaskedBoxGotFocus
                AddHandler C.LostFocus, AddressOf MaskedBoxLostFocus
            ElseIf TypeOf C Is ComboBox Then
                AddHandler C.GotFocus, AddressOf ComboBoxGotFocus
                AddHandler C.LostFocus, AddressOf ComboBoxLostFocus
            ElseIf TypeOf C Is Button And C.Tag = "1" Then
                AddHandler C.MouseEnter, AddressOf ButtonMouseEnter
                AddHandler C.MouseLeave, AddressOf ButtonMouseLeve
                AddHandler C.MouseDown, AddressOf ButtonMouseDown
                AddHandler C.MouseUp, AddressOf ButtonMouseUp
            ElseIf TypeOf C Is Button And C.Tag = "2" Then
                AddHandler C.MouseEnter, AddressOf CloseButtonMouseEnter
                AddHandler C.MouseLeave, AddressOf CloseButtonMouseLeve
                AddHandler C.MouseDown, AddressOf CloseButtonMouseDown
                AddHandler C.MouseUp, AddressOf CloseButtonMouseUp
            ElseIf TypeOf C Is Button And C.Tag = "3" Then
                AddHandler C.MouseEnter, AddressOf NewButtonMouseEnter
                AddHandler C.MouseLeave, AddressOf NewButtonMouseLeve
                AddHandler C.MouseDown, AddressOf NewButtonMouseDown
                AddHandler C.MouseUp, AddressOf NewButtonMouseUp
            ElseIf TypeOf C Is PictureBox And C.Tag = "1" Then
                AddHandler C.MouseEnter, AddressOf pictureboxMouseEnter
                AddHandler C.MouseLeave, AddressOf pictureboxMouseLeve
            ElseIf TypeOf C Is DataGridView And C.Tag = "1" Then
                AddHandler C.GotFocus, AddressOf dataGridGotFocus
                AddHandler C.LostFocus, AddressOf dataGridLostFocus
            End If

            ' recursively
            If C.HasChildren Then
                ControlHandlers(C)
            End If

        Next

    End Sub

    Public Sub ComboBoxGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            clrFocused = Color.FromName(strColorName)
            CType(sender, ComboBox).BackColor = clrFocused

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ComboBoxLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        CType(sender, ComboBox).BackColor = Color.Empty

    End Sub
    'ComboBox
    Public Sub TextBoxGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        clrFocused = Color.FromName(strColorName)
        CType(sender, TextBox).BackColor = clrFocused
        'CType(sender, TextBox).BorderStyle = BorderStyle.Fixed3D
    End Sub

    Public Sub TextBoxLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, TextBox).BackColor = Color.Empty
        'CType(sender, TextBox).BorderStyle = BorderStyle.FixedSingle
    End Sub

    Public Sub MaskedBoxGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        clrFocused = Color.FromName(strColorName)
        CType(sender, MaskedTextBox).BackColor = clrFocused

    End Sub

    Public Sub MaskedBoxLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        CType(sender, MaskedTextBox).BackColor = Color.Empty

    End Sub

    Public Sub NewButtonMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(sender, Button).BackgroundImage = Nothing
        CType(sender, Button).BackColor = Color.Transparent
        CType(sender, Button).FlatAppearance.MouseOverBackColor = Color.Transparent
        'CType(sender, Button).FlatAppearance.BorderColor = clrFocused
        'CType(sender, Button).ForeColor = Color.White
    End Sub

    Public Sub NewButtonMouseLeve(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(sender, Button).BackgroundImage = Nothing
        CType(sender, Button).BackColor = Color.Transparent
        CType(sender, Button).FlatAppearance.BorderSize = 0
        'CType(sender, Button).FlatAppearance.BorderColor = clrFocused
        'CType(sender, Button).ForeColor = clrFocused
    End Sub

    Public Sub NewButtonMouseDown(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(sender, Button).BackgroundImage = Nothing
        'CType(sender, Button).ForeColor = Color.DimGray
        'CType(sender, Button).FlatAppearance.BorderColor = Color.DimGray
        CType(sender, Button).FlatAppearance.BorderSize = 1
    End Sub

    Public Sub NewButtonMouseUp(ByVal sender As Object, ByVal e As System.EventArgs)
        'CType(sender, Button).BackgroundImage = Nothing
        'CType(sender, Button).ForeColor = clrFocused
        'CType(sender, Button).FlatAppearance.BorderColor = clrFocused
        CType(sender, Button).FlatAppearance.BorderSize = 0
    End Sub

    Public Sub ButtonMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = Nothing
        CType(sender, Button).BackColor = clrFocused
        CType(sender, Button).FlatAppearance.BorderSize = 1
        CType(sender, Button).FlatAppearance.BorderColor = clrFocused
        CType(sender, Button).ForeColor = Color.White
    End Sub

    Public Sub ButtonMouseLeve(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = Nothing
        CType(sender, Button).BackColor = Color.White
        CType(sender, Button).FlatAppearance.BorderSize = 1
        CType(sender, Button).FlatAppearance.BorderColor = clrFocused
        CType(sender, Button).ForeColor = clrFocused
    End Sub

    Public Sub ButtonMouseDown(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = Nothing
        CType(sender, Button).ForeColor = Color.DimGray
        CType(sender, Button).FlatAppearance.BorderColor = Color.DimGray
        CType(sender, Button).FlatAppearance.BorderSize = 1
    End Sub

    Public Sub ButtonMouseUp(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = Nothing
        CType(sender, Button).ForeColor = clrFocused
        CType(sender, Button).FlatAppearance.BorderColor = clrFocused
        CType(sender, Button).FlatAppearance.BorderSize = 1
    End Sub

    Public Sub CloseButtonMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = My.Resources.button_exit
        CType(sender, Button).BackgroundImageLayout = ImageLayout.Zoom
        CType(sender, Button).FlatAppearance.MouseDownBackColor = Color.Transparent
        CType(sender, Button).FlatAppearance.MouseOverBackColor = Color.Transparent
    End Sub

    Public Sub CloseButtonMouseLeve(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = My.Resources.button_login
        CType(sender, Button).BackgroundImageLayout = ImageLayout.Zoom
        CType(sender, Button).FlatAppearance.MouseDownBackColor = Color.Transparent
        CType(sender, Button).FlatAppearance.MouseOverBackColor = Color.Transparent
    End Sub

    Public Sub CloseButtonMouseDown(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = My.Resources.button_login
        ' CType(sender, Button).PerformClic
    End Sub

    Public Sub CloseButtonMouseUp(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, Button).BackgroundImage = My.Resources.button_exit
    End Sub

    Public Sub pictureboxMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, PictureBox).BackgroundImage = My.Resources.ResourceManager.GetObject(strPBEnter)
    End Sub

    Public Sub pictureboxMouseLeve(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, PictureBox).BackgroundImage = My.Resources.ResourceManager.GetObject(strPBLeave)
    End Sub

    Public Sub dataGridGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, DataGridView).DefaultCellStyle.SelectionBackColor = clrFocused
    End Sub

    Public Sub dataGridLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(sender, DataGridView).DefaultCellStyle.SelectionForeColor = Color.White
    End Sub

#End Region

#Region "Aruna New Function "
    Public Function FillCombo(ByVal sComboBox As ComboBox, ByVal sSQL As String, ByVal sComboboxText As String) As Boolean
        Dim sBOl As Boolean
        sComboBox.Items.Clear()
        If sComboboxText <> "" Then
            sComboBox.Text = sComboboxText
        End If
        Dim Con As New SqlConnection(sqlConString)
        Try
            Con.Open()
            Dim sqlcombo_department As New SqlCommand(sSQL, Con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            sBOl = redcombo_department.HasRows
            While redcombo_department.Read()
                sComboBox.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Con.Close()
        End Try
        Return sBOl
    End Function

    Public Sub FillCom2(ByVal srcComboBox As ComboBox, ByVal srcSqlString As String)
        srcComboBox.Items.Clear()
        Dim con As New SqlConnection(sqlConString)
        Try
            con.Open()
            Dim sqlcombo_department As New SqlCommand(srcSqlString, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()
            While redcombo_department.Read()
                srcComboBox.Items.Add(IIf(IsDBNull(redcombo_department.Item(0)), "", redcombo_department.Item(0)))
            End While
            redcombo_department.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        'Return com_items.Items.Add
    End Sub

    Public Function fk_EAdChk(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            fk_EAdChk = True
        Else
            fk_EAdChk = False
        End If

    End Function

    Public Sub sv_Leaves_Global(ByVal empcat As String, ByVal EmpID As String)

        Dim dgvEmp As DataGridView
        dgvEmp = New DataGridView
        With dgvEmp
            .Columns.Clear()
            .Columns.Add("EmpIDs", "Employee ID")
            .Columns.Add("CatIDs", "Category ID")
            .Columns.Add("CompIDs", "CompID")

        End With
        'Load Information to the grid 
        Load_InformationtoGrid("SELECT RegID,CatID,CompID FROM tblEmployee WHERE RegID = '" & EmpID & "' Order By RegID", dgvEmp, 3)

        'Load Leave Information to the Leave GRID for  each Employee
        'Generate the Leave GRID
        Dim dgvLv As DataGridView
        dgvLv = New DataGridView
        With dgvLv
            .Columns.Clear()
            .Columns.Add("EmpID", "EmpID")
            .Columns.Add("CompID", "CompID")
            .Columns.Add("cYear", "cYear")
            .Columns.Add("LeaveID", "LeaveID")
            .Columns.Add("NoLeave", "NoLeave")
            .Columns.Add("TakenLv", "TakenLv")
            .Columns.Add("Status", "Status")
        End With

        With dgvEmp
            For i As Integer = 0 To .RowCount - 2
                Load_InformationtoGridNoClr("select '" & .Item(0, i).Value & "','" & .Item(1, i).Value & "'," & intCurrentYear & ", " &
                                       " tblLeaveType.lvID,dbo.fk_RetNoLeave('" & .Item(1, i).Value & "',tblLeaveType.LvID) as NoLv,dbo.fk_EmpRetNoLeave(tblLeaveType.LvID,'" & .Item(0, i).Value & "',2012),0 From tblLeaveType WHERE Status = 0 Order By LvID", dgvLv, 7)

            Next
        End With
        'Insert all information to tblEmployee Leave File
        Dim sqlQRY As String
        With dgvLv
            'Update tblEm
            sqlQRY = "DELETE FROM tblEmpLeaveD WHERE EmpID = '" & EmpID & "'"
            For i As Integer = 0 To .RowCount - 2
                sqlQRY = sqlQRY & " INSERT INTO tblEmpLeaveD (EmpID,CompID,cYear,LeaveID,NoLeaves,TakenLeave,Status) VALUES ('" & .Item(0, i).Value & "', " &
                " '" & StrCompID & "'," & intCurrentYear & ",'" & .Item(3, i).Value & "', " & CDbl(.Item(4, i).Value) & "," & CDbl(.Item(5, i).Value) & ",1)"
            Next
        End With
        FK_EQ(sqlQRY, "P", "", False, False, False)
    End Sub

    Public Function FK_Br(ByVal sString As String) As Boolean

        Try
            'FK_Br = False
            BrowseTrue = False
            Cursor.Current = Cursors.WaitCursor
            Dim CN As New SqlConnection(sqlConString)
            Dim ADP As New SqlDataAdapter(sString, CN)
            CN.Open()
            DS.Clear()
            'DS = New dsReportCristal
            ADP.Fill(DS)
            FrmNewBrowse.dgvSearch.DataSource = DS.Tables(0)
            CN.Close()
            Dim fb As New FrmNewBrowse
            fb.FormBorderStyle = FormBorderStyle.Fixed3D
            Cursor.Current = Cursors.Default
            fb.ShowDialog()
            Return BrowseTrue

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Function FK_UI(ByVal sLocation As String) As Boolean

        FK_EQ("Create table tblUserIconD (Location nvarchar(200))", "P", False, False, False, False)
        FK_EQ("CREATE TABLE [dbo].[tblUserIcons]([UserName] [nvarchar](20)  NULL,[Location] [nvarchar](50)  NULL,[Status] [numeric](18, 0) NULL) ON [PRIMARY]", "P", False, False, False, False)

        FK_UI = False
        Dim tBol As Boolean = False
        Dim sSQL As String = "Select Status from tblUserIcons where Location='" & sLocation & "' and UserName='" & UserLevelID & "'"
        tBol = fk_CheckEx(sSQL)
        If tBol = False Then
            sSQL = "Select Status from tblUserIcons where Location='" & sLocation & "' and UserName='" & UserLevelID & "'"
            tBol = fk_CheckEx(sSQL)
            If tBol = False Then
                sSQL = "insert into tblUserIcons values ('" & UserLevelID & "','" & sLocation & "','1')"
                FK_EQ(sSQL, "S", False, False, False, False)
            End If
            sSQL = "Select * from tblUserIconD where Location='" & sLocation & "'"
            tBol = fk_CheckEx(sSQL)
            If tBol = False Then
                sSQL = "insert into tblUserIconD values ('" & sLocation & "')"
                FK_EQ(sSQL, "S", False, False, False, False)
            End If
        End If

        sSQL = "Select Status from tblUserIcons where Location='" & sLocation & "' and UserName='" & UserLevelID & "'"
        Dim sVal As String = fk_RetString(sSQL)
        If sVal = "1" Then
            Return True
        ElseIf sVal = "0" Then
            Return False
        Else
        End If

    End Function


    '


    Public Function FK_ReadDB(ByVal sSQL As String) As Boolean
        'I Create this functions to Read multiple values at once
        'Please make FK_Read Function to Read dgv Data Easily
        'First Create DGV Globelly
        'Public dgvFillGridforRead As New DataGridView ' This Grid use to Run FK_ReadDB Fucnction and FK_Read Function
        'Use Procedure
        'FK_ReadDB(sSQL)
        'FK_Read("Item Code")
        Dim CN As New SqlConnection(sqlConString)
        Dim sBol As Boolean = False
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sSQL, CN)
            ADP.Fill(sTable)
            frmMainAttendance.dgvFillGridforRead.DataSource = sTable.Tables(0)
            If frmMainAttendance.dgvFillGridforRead.RowCount = 0 Then
                sBol = False
            Else
                sBol = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        CN.Close()
        Return sBol
    End Function

    Public Function FK_Read(ByVal sFields As String) As String
        'This Functions Attached with FK_ReadDB
        'Use Procedure
        'FK_Read("ItemCode")
        Dim sSTR As String = ""
        Try
            sSTR = IIf(IsDBNull(frmMainAttendance.dgvFillGridforRead.Item(sFields, 0).Value), "", frmMainAttendance.dgvFillGridforRead.Item(sFields, 0).Value)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        Return sSTR
    End Function

    Public Sub FK_Clear(ByVal container As Control)
        Dim c As Control
        For Each c In container.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            ElseIf TypeOf c Is MaskedTextBox Then
                c.Text = ""
            ElseIf TypeOf c Is ComboBox Then
                c.Text = ""
            End If
            If c.HasChildren Then
                FK_Clear(c)
            End If
        Next
    End Sub

    Public Sub CenterForm(ByVal sForm As Form)

        'In the Form Load
        'CENTERFORM (ME)

        sForm.Left = (Screen.PrimaryScreen.WorkingArea.Width - sForm.Width) / 2
        sForm.Top = (Screen.PrimaryScreen.WorkingArea.Height - sForm.Height) / 2
        sForm.Icon = frmMainAttendance.Icon

    End Sub

    Public Sub DisplayDescription(ByVal strText As String)

        If strText = "cmdSave" Then

            strDescriptionLabel = "You can save"

        ElseIf strText = "cmdRefresh" Then

            strDescriptionLabel = "Refresh all controls"

        End If

    End Sub

    Public Sub LoadForm(ByVal sForm As Form)

        'LoadForm (FRM)
        On Error Resume Next
        'sForm.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
        sForm.MinimizeBox = False
        sForm.MaximizeBox = False
        sForm.HelpButton = True
        sForm.ShowDialog()
    End Sub

    Public Function Get_Index(ByVal sText As String) As Double
        Dim vVal As Double
        vVal = GetVal("Select " & sText & " from tblControl")
        If vVal = 0 Then
            Dim sS As String = "CREATE TABLE if not exists tblControl(ID numeric(18, 0) NOT NULL DEFAULT 0); Insert into tblControl values('1')"
            FK_EQ(sS, "", "", False, False, False)
            If sText <> "" Then
                sS = "Alter table tblControl Add " & sText & " numeric(18, 0) NOT NULL DEFAULT 0"
                FK_EQ(sS, "", "", False, False, False)
            End If
            vVal = GetVal("Select " & sText & " from tblControl")
        End If
        Return vVal
    End Function

    Public Function GetVal(ByVal SQLString As String)
        'listcombo "Sql String","Output String"
        Dim srcValue As Double
        Try
            Dim SQLCCn As New SqlConnection(sqlConString)
            SQLCCn.Open()
            Dim sqlCmd As New SqlCommand(SQLString, SQLCCn)
            Dim sqlDtaRdr As SqlDataReader = sqlCmd.ExecuteReader
            If sqlDtaRdr.Read Then
                srcValue = IIf(IsDBNull(sqlDtaRdr.Item(0)), 0, sqlDtaRdr.Item(0))
            Else
                srcValue = 0
            End If
            sqlCmd.Dispose()
            sqlDtaRdr.Close()
            SQLCCn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return srcValue
    End Function

    Public Function FK_EQ(ByVal SQLString As String, ByVal S4Save_E4Update_D4Delete_P4Process As String, ByVal sMsgText As String, ByVal BeginMsg As Boolean, ByVal EndMsg As Boolean, ByVal ErrMsg As Boolean) As Boolean
        Dim s As String
        s = UCase(S4Save_E4Update_D4Delete_P4Process)

        If BeginMsg = True Then
            If sMsgText = "" Then
                If s = "S" Then If MsgBox("Are you sure you want to Save this Data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
                If s = "E" Then If MsgBox("Are you sure you want to Update this Data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
                If s = "D" Then If MsgBox("Are you sure you want to Delete this Data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
                If s = "P" Then If MsgBox("Do you want to Start this Process ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
            End If
            If sMsgText <> "" Then
                Dim sS As String = ""
                If s = "S" Then sS = "Are you sure you want to Save this Data ?" & vbCrLf & sMsgText
                If s = "E" Then sS = "Are you sure you want to Update this Data ?" & vbCrLf & sMsgText
                If s = "D" Then sS = "Are you sure you want to Delete this Data ?" & vbCrLf & sMsgText
                If s = "P" Then sS = "Do you want to Start this Process ? " & vbCrLf & sMsgText
                If MsgBox(sS, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
            End If
        End If
        Dim cnSave As New SqlConnection(sqlConString)
        Dim cmSave As New SqlCommand
        Dim trSave As SqlTransaction
        Dim strStatus As Boolean = False
        Try
            cmSave.CommandTimeout = 0

            cnSave.Open()
            trSave = cnSave.BeginTransaction
            cmSave = cnSave.CreateCommand
            cmSave.Transaction = trSave
            Dim sqlQRY As String = SQLString
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            trSave.Commit()
            strStatus = (True)
            If strStatus = True Then
                If EndMsg = True Then
                    If s = "S" Then MsgBox("Save Process Completed Successfully.", MsgBoxStyle.Information)
                    If s = "E" Then MsgBox("Update Process Completed Successfully.", MsgBoxStyle.Information)
                    If s = "D" Then MsgBox("Delete Process Completed Successfully.", MsgBoxStyle.Information)
                    If s = "P" Then MsgBox("Process Completed Successfully.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            'trSave.Rollback()
            strStatus = False
            Console.WriteLine(ex.Message)
            If ErrMsg = True Then
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
        Finally
            cnSave.Close()
            cmSave.Dispose()
            FK_EQ = strStatus
        End Try
    End Function

    Public Function FK_EQRemote(ByVal SQLString As String, ByVal S4Save_E4Update_D4Delete_P4Process As String, ByVal sMsgText As String, ByVal BeginMsg As Boolean, ByVal EndMsg As Boolean, ByVal ErrMsg As Boolean) As Boolean
        Dim s As String
        s = UCase(S4Save_E4Update_D4Delete_P4Process)

        If BeginMsg = True Then
            If sMsgText = "" Then
                If s = "S" Then If MsgBox("Are you sure you want to Save this Data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
                If s = "E" Then If MsgBox("Are you sure you want to Update this Data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
                If s = "D" Then If MsgBox("Are you sure you want to Delete this Data ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
                If s = "P" Then If MsgBox("Do you want to Start this Process ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
            End If
            If sMsgText <> "" Then
                Dim sS As String = ""
                If s = "S" Then sS = "Are you sure you want to Save this Data ?" & vbCrLf & sMsgText
                If s = "E" Then sS = "Are you sure you want to Update this Data ?" & vbCrLf & sMsgText
                If s = "D" Then sS = "Are you sure you want to Delete this Data ?" & vbCrLf & sMsgText
                If s = "P" Then sS = "Do you want to Start this Process ? " & vbCrLf & sMsgText
                If MsgBox(sS, MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Function
            End If
        End If
        Dim cnSave As New SqlConnection(sqlConStringRemote)
        Dim cmSave As New SqlCommand
        Dim trSave As SqlTransaction
        Dim strStatus As Boolean = False
        Try
            cmSave.CommandTimeout = 0

            cnSave.Open()
            trSave = cnSave.BeginTransaction
            cmSave = cnSave.CreateCommand
            cmSave.Transaction = trSave
            Dim sqlQRY As String = SQLString
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            trSave.Commit()
            strStatus = (True)
            If strStatus = True Then
                If EndMsg = True Then
                    If s = "S" Then MsgBox("Save Process Completed Successfully.", MsgBoxStyle.Information)
                    If s = "E" Then MsgBox("Update Process Completed Successfully.", MsgBoxStyle.Information)
                    If s = "D" Then MsgBox("Delete Process Completed Successfully.", MsgBoxStyle.Information)
                    If s = "P" Then MsgBox("Process Completed Successfully.", MsgBoxStyle.Information)
                End If
            End If
        Catch ex As Exception
            'trSave.Rollback()
            strStatus = False
            Console.WriteLine(ex.Message)
            If ErrMsg = True Then
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
        Finally
            cnSave.Close()
            cmSave.Dispose()
            FK_EQRemote = strStatus
        End Try
    End Function

#End Region

    Public Structure st_GeneralEmpInfo
        Dim StrRegNo As String
        Dim dtRegDate As Date
        Dim StrTtlID As String
        Dim StrSName As String
        Dim StrFname As String
        Dim StrDName As String
        Dim StrNIC As String
        Dim dtDB As Date
        Dim intAgs As Double
        Dim StrGid As String
        Dim StrCvID As String
    End Structure

    'GEt the Attendance Time From the tblGetInOut Table 
    Public Function fk_Return_ATTime(ByVal sEmpID As String, ByVal sAtDate As Date) As String
        Dim sqlString As String = "SELECT Convert(Nvarchar (5),InTime,108) + '-' + Convert(Nvarchar(5),OutTime,108) FROM tblGetInOut WHERE ATdate  = '" & Format(sAtDate, "yyyyMMdd") & "' AND EmpID = '" & sEmpID & "' Order by InTime"
        Dim StrReturnVal As String = ""
        Dim cnOpen As New SqlConnection(sqlConString)
        Try
            cnOpen.Open()
            Dim cmOpen As New SqlCommand(sqlString, cnOpen)
            Dim drOpen As SqlDataReader = cmOpen.ExecuteReader
            Do While drOpen.Read = True
                If StrReturnVal = "" Then StrReturnVal = drOpen.Item(0) Else StrReturnVal = StrReturnVal & vbCrLf & drOpen.Item(0)
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnOpen.Close()
        End Try
        Return StrReturnVal
    End Function


    '#########################################################################
    'Mod ID = MOD2018108
    'By     = Kasun
    'Ref    = Perform Day Seperate OT, if midnight transfer should identify the next day ot configuration
    'Lakehouse

    Public Function fk_DayOTProcessQRY(ByVal dtRunDate As Date) As String
        Dim dtS As Date
        dtS = "00:00:01"
        Dim StrOQRY As String = ""
        'New QRY 
        StrOQRY = StrOQRY + " CREATE TABLE #R (EmpID nVarchar (6),AtDate DateTime, InTime DateTime, OutTime DateTime,ShiftID Nvarchar (3),DayTypeID Nvarchar(2),InUpdate numeric (18,0),OutUpdate Numeric (18,0),S_IN DateTime, S_Out DateTime,RVal Numeric (18,0),RunDate DateTime) "
        StrOQRY = StrOQRY + " INSERT INTO #R SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.InTime1,Convert(Nvarchar(8),tblEmpRegister.OutTime1,112) + ' ' + '00:00:00',tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate,'','',1,Convert(Nvarchar(8),tblEmpRegister.InTime1,112) FROM tblEmpRegister WHERE DateDiff(Day,InTime1,OutTime1)>0 AND AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "'"
        StrOQRY = StrOQRY + " INSERT INTO #R SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,DateAdd(s,1,Convert(Nvarchar(8),tblEmpRegister.OutTime1,112)) + ' ' + '00:00:00',tblEmpRegister.OutTime1,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate,'','',1,Convert(Nvarchar(8),tblEmpRegister.OutTime1,112) FROM tblEmpRegister WHERE DateDiff(Day,InTime1,OutTime1)>0 AND AtDate = '" & Format(dtRunDate, strRetDateTimeFormat) & "'"
        StrOQRY = StrOQRY + " UPDATE #R SET #R.DayTypeID = tblEmpRegister.DayTypeID,#R.ShiftID = tblEmpRegister.AllShifts FROM tblEmpRegister,#R WHERE tblEmpRegister.EmpID = #R.EmpID AND tblEmpRegister.AtDate = #R.RunDate"
        StrOQRY = StrOQRY + " SELECT #R.*,tblOTCal.OTLevel,ShiftIN =DateAdd(Day,tblOTCal.StWEF,#R.RunDate)+tblOTCal.StTime,ShiftOUT = DateAdd(Day,tblOTCal.EdWEF,#R.RunDate)+tblOTCal.EdDate,tblOTCal.OTType,tblOTCal.Seq,tblOTCal.MaxMin INTO #M FROM tblOTCal,#R WHERE tblOTCal.DayTypeID = #R.DayTypeID AND tblOTCal.ShiftID = #R.ShiftID"
        StrOQRY = StrOQRY + " ALTER TABLE #M ADD OTVal Numeric (18,2) NOT NULL Default 0 "
        StrOQRY = StrOQRY + " UPDATE #M SET S_IN = CASE WHEN DateDiff(Minute,InTime,ShiftIN)>0 THEN ShiftIN ELSE InTime END, S_OUT = CASE WHEN DateDiff(Minute,ShiftOut,OutTime)<0 THEN OutTime ELSE ShiftOUT END FROM #M"
        StrOQRY = StrOQRY + " UPDATE #M SET OTVAL =  DateDiff(Minute,S_In,S_Out)"
        StrOQRY = StrOQRY + " DELETE FROM #M WHERE OTVAL < 0"
        StrOQRY = StrOQRY + " DELETE FROM #M WHERE OTVAL < 90 AND OTLevel = 0"
        StrOQRY = StrOQRY + " DELETe FROM #T WHERE DateDiff(d,S_Time,E_Time) = 1 "
        StrOQRY = StrOQRY + " INSERT INTO #T SELECT EmpID,AtDate,InTime,OutTime,ShiftID,DayTypeID,OTLevel,S_IN,S_Out,OTtype,MaxMin,Seq,InTime,OutTime,OTVal,inUpdate,OutUpdate FROM #M"
        Return StrOQRY

    End Function


    '#########################################################################

    Public Sub New_OTCalMethod(ByVal dtStart As Date, ByVal dtEnd As Date)

        Dim intOTRndMin As Integer = 0 : Dim isntRoundOTSeperately As Integer = 0
        Dim intBgGAP As Integer = 0 : Dim intEdGAP As Integer = 0 : Dim intMinimumMin As Integer = 0
        Dim sqlQ As String = ""
        sqlQ = "select OTRound,MinHrsOT,OTRndOption,BeginGAP,EndGAP,isntRoundOTSeperately FROM tblCOmpany WHERE CompID = '" & StrCompID & "'"
        fk_Return_MultyString(sqlQ, 6)
        intOTRndMin = fk_ReadGRID(0) : intMinimumMin = fk_ReadGRID(1)
        intBgGAP = fk_ReadGRID(3) : intEdGAP = fk_ReadGRID(4) : isntRoundOTSeperately = fk_ReadGRID(5)

        '*********************************************************
        'Mode No    : MOD-OT0001
        'By         : Kasun
        'Date Create    : 17/11/2014
        'Description    : Calculate Normal OT,Double OT, Triple OT any given Order based on In/Out Time

        '******* Add Feature ON 3/12/2014 
        'Description    : Calculate given period based on work minute, Eg for holidays

        '*********************************************************
        Dim sqlQRY As String

        'Update day type configuration 
        sqlQRY = "DROP TABLE TData " : FK_EQ(sqlQRY, "S", "", False, False, False)
        sqlQRY = " select tblEmpregister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.InTime1 As InTime,tblEmpRegister.OutTime1 As OutTime,WorkMins = CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblDayProfileD.PrfID, " &
            " tblDayProfileD.StartMin,tblDayProfileD.EndMin,tblDayProfileD.NrDays,tblDayProfileD.LvDays,tblDayProfileD.IsNormalOT,tblDayProfileD.NOTMode,DateAdd(Day,NOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.NOTTime As NOTTime,tblDayProfileD.NOTMins,tblDayProfileD.IsDoubleOT, " &
            " tblDayProfileD.DOTMode,DateAdd(Day,DOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.DOTTime As DOTTime,tblDayProfileD.DOTMins,tblDayProfileD.Status,tblDayProfileD.AddDay,tblDayProfileD.isTOT, " &
            " tblDayProfileD.TOTMode,DateAdd(Day,TOTWEF,tblEmpRegister.AtDate)+tblDayProfileD.TOTTime As TOTTime,tblDayProfileD.TOTMins, " &
            " tblDayProfileD.IsUpOT,tblDayProfileD.UpOTMode,tblEmpRegister.AtDate+tblDayProfileD.UpOTTime As UpOTTime,tblDayProfileD.WEFUpOT,tblDayProfileD.UpOTMins,tblDayProfileD.IsOTStart,tblEmpRegister.AtDate+tblDayProfileD.OTStartTime As OTStartTime " &
            " INTO TData from tblDayProfileD,tblEmpRegister,tblSetShiftH WHERE tblSetShiftH.ShiftID = tblEmpRegister.AllShifts AND tblEmpRegister.AllShifts = tblDayProfileD.ShiftID AND " &
            " tblEmpRegister.DayTypeID = tblDayProfileD.DayID AND CASE WHEN tblSetShiftH.CalWorkMin = 1 THEN tblEmpRegister.WorkMins ELSE tblEmpRegister.OrigMin END Between tblDayProfileD.StartMin AND tblDayProfileD.EndMin  AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'"
        sqlQRY = sqlQRY & " ALTER TABLE TData ADD NOTMin Numeric (18,2) NOT NULL Default 0 "
        sqlQRY = sqlQRY & " ALTER TABLE TData ADD DOTMin Numeric (18,2) NOT NULL Default 0 "
        sqlQRY = sqlQRY & " ALTER TABLE TData ADD TOTMin Numeric (18,2) NOT NULL Default 0 "
        sqlQRY = sqlQRY & " ALTER TABLE TData ADD UpMin Numeric (18,2) NOT NULL Default 0 "
        sqlQRY = sqlQRY & " ALTER TABLE TData ADD DueMin Numeric (18,2) NOT NULL Default 0 " : FK_EQ(sqlQRY, "S", "", False, False, True)

        sqlQRY = "UPDATE tblEmpRegister SET tblEmpRegister.NRWorkDay = TData.NrDays,tblEmpRegister.AutoLeaveNo = TData.LvDays,tblEmpRegister.AdWorkDay = TData.AddDay FROM TData,tblEmpRegister WHERE TData.EmpID = tblEmpRegister.EmpID AND TData.AtDate  = tblEmpRegister.AtDate" : FK_EQ(sqlQRY, "S", "", False, False, True)
        'Clear the existing OT for the first time
        Dim intInOutRound As Integer = 1
        Dim intOTInterval As Integer = 0
        sqlQRY = "UPDATE tblEmpRegister SET NormalOT = 0,NormalOThrs =0,DoubleOT = 0,DoubleOTHrs =0 ,TripleOT =0,TripleOThrs =0,AdOTmin=0,BeginOT=0,EndOT=0 WHERE atDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'" : FK_EQ(sqlQRY, "S", "", False, False, True)

        '$$$$$$$$$$$$$$ CALCULATE OT BASED ON In/Out Times $$$$$$$$$$$$$$$$$$


        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, S_Time DateTime,E_Time DateTime,ShiftID nvarchar (3),DayTypeID Nvarchar (2),OTLevel Numeric (18,0),StTime DateTIme,EdTime DateTime ,OTtype Numeric (18,0),MaxMin Numeric (18,0),Seq Numeric (18,0),vIn DateTime, vOut DateTime,c_OT Numeric (18,0),inUpdate Numeric (18,0),OutUpdate Numeric (18,0))"

        'OT CALCULATION BASED ON ROUNDING INTIME = REQUIREMENT FROM MICRO ENTERPRICES, 20160328, KASUN, EFFECT TO NEW OT CONFIQURATION (TME BASED CALCULATION)
        'ISRoundInOutMethod2 IN tblCompany is altered for this process and RoundTime30 function also added
        If ISRoundInOutMethod2 = 1 Then
            'Based on rounded time if 5 then 8.41 to 8.40 8.44 to 8.40
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,CASE WHEN DateDiff(Minute,dbo.RoundTime(tblEmpRegister.inTime1," & intInOutRound & " ),tblEmpRegister.InTime1) < " & intBgGAP & " THEN dbo.RoundTime(tblEmpRegister.inTime1," & intInOutRound & ") ELSE DateAdd(Minute," & intOTInterval & ",dbo.RoundTime(tblEmpRegister.inTime1," & intInOutRound & ")) END,CASE WHEN DateDiff(Minute,dbo.RoundTime(OutTime1," & intInOutRound & "),OutTime1) < " & intEdGAP & " THEN dbo.RoundTime(OutTime1," & intInOutRound & ") ELSE DateAdd(Minute," & intInOutRound & ",dbo.RoundTime(OutTime1," & intInOutRound & ")) END ,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblOTCal.OTLevel," &
       " stTime = DateAdd(Day,tblOTCal.StWEF,tblEmpRegister.AtDate)+tblOTCal.StTime,EdTime = DateAdd(Day,tblOTCal.EdWEF,tblEmpRegister.AtDate)+tblOtCal.EdDate," &
       " tblOTCal.OTType,tblOTCal.MaxMin,tblOTCal.Seq,'','',0,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate FROM tblEmpRegister,tblOTCal WHERE tblEmpRegister.AllShifts = tblOTcal.ShiftID AND tblEmpRegister.DayTypeID = tblOTCal.DayTypeID" &
       " AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND tblOTCal.cMode = 0"
            If intDaySeperateOT = 1 Then sqlQRY = sqlQRY + fk_DayOTProcessQRY(dtStart)
        ElseIf ISRoundInOutMethod2 = 0 Then
            'Based on Actual Out time
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,InTime1, OutTime1 ,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblOTCal.OTLevel," &
     " stTime = DateAdd(Day,tblOTCal.StWEF,tblEmpRegister.AtDate)+tblOTCal.StTime,EdTime = DateAdd(Day,tblOTCal.EdWEF,tblEmpRegister.AtDate)+tblOtCal.EdDate," &
     " tblOTCal.OTType,tblOTCal.MaxMin,tblOTCal.Seq,'','',0,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate FROM tblEmpRegister,tblOTCal WHERE tblEmpRegister.AllShifts = tblOTcal.ShiftID AND tblEmpRegister.DayTypeID = tblOTCal.DayTypeID" &
     " AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND tblOTCal.cMode = 0"
            If intDaySeperateOT = 1 Then sqlQRY = sqlQRY + fk_DayOTProcessQRY(dtStart)
        ElseIf ISRoundInOutMethod2 = 2 Then
            'Based on Round Out time to 8.44 to 8.30 and 8.46 to 9.00
            sqlQRY = sqlQRY & " INSERT INTO #T SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,CASE WHEN DateDiff(minute,dbo.RoundTime30(InTime1,.5),intime1) >5 THEN DateAdd(minute,30,dbo.RoundTime30(InTime1,.5)) ELSE dbo.RoundTime30(InTime1,.5) END, CASE WHEN DateDiff(minute,OutTime1,dbo.RoundTime30(OutTime1,-.5)) > 5 THEN DateAdd(Minute,-30,dbo.RoundTime30(OutTime1,-.5)) ELSE dbo.RoundTime30(OutTime1,-.5) END ,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID,tblOTCal.OTLevel," &
       " stTime = DateAdd(Day,tblOTCal.StWEF,tblEmpRegister.AtDate)+tblOTCal.StTime,EdTime = DateAdd(Day,tblOTCal.EdWEF,tblEmpRegister.AtDate)+tblOtCal.EdDate," &
       " tblOTCal.OTType,tblOTCal.MaxMin,tblOTCal.Seq,'','',0,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate FROM tblEmpRegister,tblOTCal WHERE tblEmpRegister.AllShifts = tblOTcal.ShiftID AND tblEmpRegister.DayTypeID = tblOTCal.DayTypeID" &
       " AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND tblOTCal.cMode = 0"
            If intDaySeperateOT = 1 Then sqlQRY = sqlQRY + fk_DayOTProcessQRY(dtStart)
        End If

        '---------------------- Day Seperate OT Remove Begin OT --------------------------------
        If intDaySeperateOT = 1 Then sqlQRY = sqlQRY & " DELETE FROM #T WHERE AtDate = '" & Format(dtStart, "yyyyMMdd") & "' AND OTLevel = 0 AND c_OT < " & dblRmvBeginOT & " and DayTypeID='01'"


        'Update OT Approval Query
        '--------------------- OT Approval Query ------------------
        ' By    : Kasun
        ' Date  : 2/11/2018

        sqlQRY = sqlQRY & " SELECT #T.* INTO #TN FROM  #T,tblOTRequestD WHERE #T.EmpID = tblOTRequestD.RegID AND #T.AtDate = tblOTRequestD.WorkDate AND tblOTRequestD.r_Status = 1"
        sqlQRY = sqlQRY & " DELETE FROM #TN WHERE OTType = 3"
        sqlQRY = sqlQRY & " SELECT EmpID,AtDate,Seq = Max(Seq) INTO #k FROM #TN GROUP BY EmpID,AtDate"
        sqlQRY = sqlQRY & " Select #k.*,tblOTRequestD.RegID,tblOTRequestD.WorkDate, OffTime = tblOTRequestD.WorkDate+tblOTRequestH.OffTime INTO #OT From #k,tblOTRequestD,tblOTRequestH WHERE #k.EmpID = tblOTRequestD.RegID AND #k.AtDate = tblOTRequestD.WorkDate AND tblOTRequestH.ReqID = tblOTRequestD.ReqID AND tblOTRequestH.a_Status = 1 AND tblOTRequestD.r_Status = 1"
        sqlQRY = sqlQRY & " UPDATE #T SET #T.EdTime = #OT.OffTime FROM #OT,#T WHERE #OT.RegID = #T.EmpID AND #OT.WorkDate = #T.AtDate AND #T.Seq = #OT.Seq "

        '---------------------------------------------------------------




        sqlQRY = sqlQRY & " CREATE TABLE #E (EmpID Nvarchar (6),AtDate DateTime, InTime DateTime, OutTime DateTime, vIn DateTime ,vOut DateTime, Seq Numeric (18,0),InUpdate Numeric (18,0),OutUpdate Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #E select EmpID,AtDate,s_Time,e_Time,vIN = CASE WHEN DateDiff(MInute,s_time,StTime) <0 THEN s_Time ELSE StTime END, vOut = CASE WHEN DateDiff(Minute,E_Time,EdTime) < 0 THEN EdTime ELSE E_Time  END,Seq,InUpdate,OutUpdate  From #T"
        sqlQRY = sqlQRY & " UPDATE #T SET #T.vIn = #E.vIN,#T.vOut = #E.vOut FROM #T,#E WHERE #T.EMpID = #E.EmpID AND #T.AtDate = #E.AtDate AND #T.Seq = #E.Seq"
        sqlQRY = sqlQRY & " UPDATE #T SET c_OT = CASE WHEN DateDiff(Day,AtDate,s_time) < 0 THEN 0 WHEN DateDiff(Day,AtDate,e_Time) < 0 THEN 0 WHEN InUpdate = 0  THEN 0 WHEN OutUpdate = 0 THEN 0 WHEN DateDiff(Minute,vIn,vOut) < 0 THEN 0 ELSE DateDiff(Minute,vIn,vOut) END "
        If isntRoundOTSeperately = 1 Then sqlQRY = sqlQRY & "UPDATE #T SET c_OT= CASE WHEN c_OT<" & intMinimumMin & " THEN 0 ELSE c_OT-c_OT%" & intOTRndMin & " END"
        sqlQRY = sqlQRY & " CREATE TABLE #All (EmpID nvarchar (6),AtDate DateTime,OTType Numeric (18,0),TotalOT Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #All select EmpID,AtDate,OTType,Sum(c_OT) As cOTs from #T group by empid,atdate,ottype"
        'Update All OT Detail to the Header table 
        'Update Normal OT
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.NormalOT = #All.TotalOT FROM tblEmpRegister,#All WHERE tblEmpRegister.EmpID = #All.EmpID AND tblEmpRegister.AtDate = #All.AtDate AND #All.OTType = 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DoubleOT = #All.TotalOT FROM tblEmpRegister,#All WHERE tblEmpRegister.EmpID = #All.EmpID AND tblEmpRegister.AtDate = #All.AtDate AND #All.OTType = 1"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TripleOT = #All.TotalOT FROM tblEmpRegister,#All WHERE tblEmpRegister.EmpID = #All.EmpID AND tblEmpRegister.AtDate = #All.AtDate AND #All.OTType = 2"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.AdOTmin = #All.TotalOT FROM tblEmpRegister,#All WHERE tblEmpRegister.EmpID = #All.EmpID AND tblEmpRegister.AtDate = #All.AtDate AND #All.OTType = 3"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TwoHalfOT = #All.TotalOT FROM tblEmpRegister,#All WHERE tblEmpRegister.EmpID = #All.EmpID AND tblEmpRegister.AtDate = #All.AtDate AND #All.OTType =4"

        'UPDATE BEGIN OT AND END OT SEPERATELY TO RELEVANT COLUMNS (REQUESTER BY ANURADHA AGENCY 2017 02 11
        sqlQRY = sqlQRY & " CREATE TABLE #Allk (EmpID nvarchar (6),AtDate DateTime,OTLevel Numeric (18,0),TotalOT Numeric (18,2)) "
        sqlQRY = sqlQRY & " INSERT INTO #Allk select EmpID,AtDate,OTLevel,Sum(c_OT) As cOTs from #T group by empid,atdate,OTLevel "
        'Update All OT Detail to the Header table 
        'Update Begin OT and End OT
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.BeginOT = #Allk.TotalOT FROM tblEmpRegister,#Allk WHERE tblEmpRegister.EmpID = #Allk.EmpID AND tblEmpRegister.AtDate = #Allk.AtDate AND #Allk.OTLevel = 0 "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.EndOT = #Allk.TotalOT FROM tblEmpRegister,#Allk WHERE tblEmpRegister.EmpID = #Allk.EmpID AND tblEmpRegister.AtDate = #Allk.AtDate AND #Allk.OTLevel = 1 "

        FK_EQ(sqlQRY, "S", "", False, False, True)

        '$$$$$$$$$$$$$ CALCULATE OT BASED ON Work Minute $$$$$$$$$$$$$$$$$$$$$$

        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, S_Time DateTime,E_Time DateTime,ShiftID nvarchar (3),DayTypeID Nvarchar (2),OTLevel Numeric (18,0)," &
        " StTime Numeric(18,0),EdTime Numeric(18,0),OTtype Numeric (18,0),MaxMin Numeric (18,0),Seq Numeric (18,0),BFMin Numeric(18,0), CFMin Numeric(18,0),c_OT Numeric (18,0),InUpdate Numeric (18,0),OutUpdate Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #T        SELECT tblEmpRegister.EmpID,tblEmpRegister.AtDate,tblEmpRegister.InTime1,tblEmpRegister.OutTime1,tblEmpRegister.AllShifts,tblEmpRegister.DayTypeID, " &
        " tblOTCal.OTLevel,tblOTCal.StartMin,tblOtCal.EndMin,tblOTCal.OTType,tblOTCal.MaxMin,tblOTCal.Seq,0,0,0,tblEmpRegister.InUpdate,tblEmpRegister.OutUpdate FROM tblEmpRegister,tblOTCal WHERE tblEmpRegister.AllShifts = tblOTcal.ShiftID AND tblEmpRegister.DayTypeID = tblOTCal.DayTypeID AND tblEmpRegister.AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND tblOTCal.cMode = 1"

        'sqlQRY = sqlQRY & " UPDATE #T SET MaxMin  = DateDiff(Minute,s_Time,E_Time)"

        sqlQRY = sqlQRY & " UPDATE #T SET MaxMin = tblEmpRegister.workmins from tblEmpRegister,#T WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate"

        'Update Sequence 1 values
        ' sqlQRY = sqlQRY & "UPDATE #T SET c_OT=CASE WHEN MaxMin=0 THEN 0 WHEN InUpdate = 0 THEN 0 WHEN OutUpdate = 0 THEN 0 WHEN EdTime-MaxMin < 0 THEN EdTime Else EdTime-MaxMin END,BFMin=CASE WHEN MaxMin-CASE WHEN EdTime-MaxMin < 0 THEN EdTime Else EdTime-MaxMin END < 0 THEN 0 ELSE MaxMin-CASE WHEN EdTime-MaxMin < 0 THEN EdTime Else EdTime-MaxMin END END  WHERE Seq = 1"
        'Changed By Kasun MaxMin-StTime On 15/2/2016
        sqlQRY = sqlQRY & " UPDATE #T SET c_OT=CASE WHEN MaxMin=0 THEN 0 WHEN EdTime-MaxMin < 0 THEN EdTime Else MaxMin-StTime END,BFMin= CASE WHEN MaxMin- EDTime < 0 THEN 0 ELSE MaxMin- EDTime END WHERE Seq = 1"
        sqlQRY = sqlQRY & " CREATE TABLE #T1 (EmpID Nvarchar(6),AtDate DateTime,BFMin Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #T1 SELECT EmpID,AtDate,BFMin FROM #T WHERE Seq = 1"
        sqlQRY = sqlQRY & " UPDATE #T SET #T.CFMin = #T1.BFMin FROM #T1,#T WHERE #T1.EmpID = #T.EMpID AND #T1.AtDate = #T.AtDate AND Seq = 2"
        sqlQRY = sqlQRY & " UPDATE #T SET c_OT=CASE WHEN MaxMin=0 THEN 0 WHEN EdTime-CFMin < 0 THEN EdTime-StTime Else CFMin END,BFMin=CASE WHEN CFMin-CASE WHEN EdTime-CFMin < 0 THEN EdTime Else EdTime-CFMin END < 0 THEN 0 ELSE CFMin-CASE WHEN EdTime-CFMin < 0 THEN EdTime Else EdTime-CFMin END END  WHERE Seq = 2"

        Dim intNextVal As Integer = 0
        For i As Integer = 2 To 4
            intNextVal = i + 1
            Dim StrTName As String = "#T" & i
            sqlQRY = sqlQRY & " CREATE TABLE " & StrTName & " (EmpID Nvarchar(6),AtDate DateTime,BFMin Numeric (18,0))"
            sqlQRY = sqlQRY & " INSERT INTO " & StrTName & " SELECT EmpID,AtDate,BFMin FROM #T WHERE Seq = " & i & ""
            sqlQRY = sqlQRY & " UPDATE #T SET #T.CFMin = " & StrTName & ".BFMin FROM " & StrTName & ",#T WHERE " & StrTName & ".EmpID = #T.EMpID AND " & StrTName & ".AtDate = #T.AtDate AND Seq = " & intNextVal & ""
            sqlQRY = sqlQRY & " UPDATE #T SET c_OT=CASE WHEN MaxMin=0 THEN 0 WHEN EdTime-CFMin < 0 THEN EdTime-StTime Else CFMin END,BFMin=CASE WHEN CFMin-CASE WHEN EdTime-CFMin < 0 THEN EdTime Else EdTime-CFMin END < 0 THEN 0 ELSE CFMin-CASE WHEN EdTime-CFMin < 0 THEN EdTime Else EdTime-CFMin END END  WHERE Seq = " & intNextVal & ""
        Next
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.NormalOT = #T.c_OT FROM tblEmpRegister,#T WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate AND #T.OTType = 0"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.DoubleOT = #T.c_OT FROM tblEmpRegister,#T WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate AND #T.OTType = 1"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.TripleOT = #T.c_OT FROM tblEmpRegister,#T WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate AND #T.OTType = 2"
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.AdOTmin = #T.c_OT FROM tblEmpRegister,#T WHERE tblEmpRegister.EmpID = #T.EmpID AND tblEmpRegister.AtDate = #T.AtDate AND #T.OTType = 3"

        'UPDATE BEGIN OT AND END OT SEPERATELY TO RELEVANT COLUMNS (REQUESTER BY ANURADHA AGENCY 2017 02 11
        sqlQRY = sqlQRY & " CREATE TABLE #Allk (EmpID nvarchar (6),AtDate DateTime,OTLevel Numeric (18,0),TotalOT Numeric (18,2)) "
        sqlQRY = sqlQRY & " INSERT INTO #Allk select EmpID,AtDate,OTLevel,Sum(c_OT) As cOTs from #T group by empid,atdate,OTLevel "
        'Update All OT Detail to the Header table 
        'Update Begin OT and End OT
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.BeginOT = #Allk.TotalOT FROM tblEmpRegister,#Allk WHERE tblEmpRegister.EmpID = #Allk.EmpID AND tblEmpRegister.AtDate = #Allk.AtDate AND #Allk.OTLevel = 0 "
        sqlQRY = sqlQRY & " UPDATE tblEmpRegister SET tblEmpRegister.EndOT = #Allk.TotalOT FROM tblEmpRegister,#Allk WHERE tblEmpRegister.EmpID = #Allk.EmpID AND tblEmpRegister.AtDate = #Allk.AtDate AND #Allk.OTLevel = 1 "

        FK_EQ(sqlQRY, "S", "", False, False, True)

    End Sub

    Public Sub proc_ShiftLineOnSplit(ByVal dtStart As Date, ByVal dtEnd As Date)
        Dim sqlQRY As String = ""
        sqlQRY = "CREATE TABLE #T (EmpID Nvarchar (6),AtDate DateTime, Total Numeric (18,2))"
        sqlQRY = sqlQRY & " INSERT INTO #T SELECT EmpID,AtDate,Count(AtDate) FROM tblGetInOut WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "' AND antStatus = 1 GROUP By EmpID,AtDate"
        sqlQRY = sqlQRY & " UPDATE tblGetInOut SET ShiftLine = 1 WHERE AtDate Between '" & Format(dtStart, "yyyyMMdd") & "' AND '" & Format(dtEnd, "yyyyMMdd") & "'"
        sqlQRY = sqlQRY & " CREATE TABLE #T1 (EmpID Nvarchar (6),AtDate DateTime ,InTime DateTime,ShiftLine Numeric (18,0))"
        sqlQRY = sqlQRY & " INSERT INTO #T1 SELECT tblGetInOut.EmpID,tblGetInOut.AtDate,tblGetInOut.InTime,ROW_NUMBER() OVER (PARTITION BY tblGetInOut.EmpID,CONVERT(NVARCHAR(25), tblGetInOut.AtDate, 111) ORDER BY tblGetInOut.InTime ASC) TwinCode  FROM tblGetInOut,#T WHERE tblGetInOut.EmpID = #T.EmpID AND tblGetInOut.AtDate=#T.AtDate AND #T.Total>1"
        sqlQRY = sqlQRY & " UPDATE tblGetInOut SET tblGetInOut.ShiftLine = #T1.ShiftLine FROM tblGetInOut,#T1 WHERE tblGetInOut.EmpID = #T1.EmpID AND tblGetInOut.InTime = #T1.InTime"
        FK_EQ(sqlQRY, "S", "", False, False, True)
    End Sub

    Public Sub proc_AttendanceSummary(ByVal stDate As Date, ByVal EdDate As Date)
        Dim sqlQRY As String = ""
        sqlQRY = " DELETE FROM tblSumAttendance"
        sqlQRY = sqlQRY & " INSERT INTO tblSumAttendance Select EmpID,AtDate,Count(*),'' from tblGetInOut WHERE AtDate Between '" & Format(stDate, "yyyyMMdd") & "' AND  '" & Format(EdDate, "yyyyMMdd") & "' GROUP BY EmpID,AtDate"
        FK_EQ(sqlQRY, "S", "", False, False, False)
        ' 02. Get the InOut Information for the 1 Marked Employees
        sqlQRY = "CREATE TABLE #TmpProc (EmpID Nvarchar (6),AtDate DateTime,TimeString Nvarchar (50))"
        sqlQRY = sqlQRY & " INSERT INTO #TmpProc Select tblSumAttendance.EMpID,tblSumAttendance.AtDate,Convert(Nvarchar (5),tblGetInOut.InTime,108) + '-' + Convert(Nvarchar(5),tblGetInOut.OutTime,108) FROM tblGetInOut INNER JOIN tblSumAttendance ON tblGetInOut.EmpID = tblSumAttendance.EmpID AND tblGetInOut.AtDate = tblSumAttendance.AtDate WHERE tblSumAttendance.Total = 1"
        sqlQRY = sqlQRY & " UPDATE tblSumAttendance SET tblSumAttendance.TimeDetail = #TmpProc.TimeString FROM #tmpProc INNER JOIN tblSumAttendance  ON tblSumAttendance.EmpID = #TmpProc.EmpID AND tblSumAttendance.AtDate = #TmpProc.AtDate WHERE tblSumAttendance.Total = 1"
        FK_EQ(sqlQRY, "S", "", False, False, False)

        'Load Other Information to the GRID And Update Details
        Dim dgvAll As New DataGridView
        dgvAll = New DataGridView
        With dgvAll
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .Columns.Add("EmpID", "Employee Name")
            .Columns.Add("AtDate", "Attendance Date")
            .Columns.Add("Total", "Total")
            .Columns.Add("InOut", "Time Detail")
        End With

        'Load Other Information to Above Grid
        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblSumAttendance WHERE Total > 1")
        If bolEx = True Then
            Load_InformationtoGrid("SELECT EmpID,AtDate,Total FROM tblSumAttendance WHERE Total > 1 Order By EmpID,AtDate", dgvAll, 3)
            Dim StrEmp As String = "" : Dim dtAtDate As Date
            Dim StrReturnValue As String
            Dim sqlUpString As String = ""
            With dgvAll
                For i As Integer = 0 To .RowCount - 1
                    StrEmp = .Item(0, i).Value : dtAtDate = .Item(1, i).Value
                    StrReturnValue = fk_Return_ATTime(StrEmp, dtAtDate)
                    sqlUpString = sqlUpString & " UPDATE tblSumAttendance SET TimeDetail = '" & StrReturnValue & "' WHERE EmpID = '" & StrEmp & "' AND AtDate = '" & Format(dtAtDate, "yyyyMMdd") & "'"
                Next
            End With
            FK_EQ(sqlUpString, "S", "", False, False, True)
        End If
    End Sub

    Public Sub FK_LoadGridWithDS(ByVal sqlString As String, ByVal dgv As DataGridView)
        Dim cnDS As New SqlConnection(sqlConString)
        Try
            Dim dsDataset As New DataSet
            Dim sqlAdapter As New SqlDataAdapter(sqlString, cnDS)
            sqlAdapter.Fill(dsDataset)
            dgv.DataSource = sqlAdapter

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnDS.Close()
        End Try

    End Sub

    Public Function fk_GenSerial(ByVal sqlString As String, ByVal Len As Integer) As String
        Dim StrRetVal As String
        Dim iTr As Integer = fk_sqlDbl(sqlString) + 1
        StrRetVal = fk_CreateSerial(Len, iTr)
        Return StrRetVal
    End Function

    Public Function fk_Return_MultyString(ByVal sqlQRY As String, ByVal intNoCol As Integer) As Boolean
        'Create Datagrid according to the requirment 
        dgvMultiGRID = New DataGridView : Dim IntColum As Integer = 0
        Try
            With dgvMultiGRID
                For iCol As Integer = 1 To intNoCol
                    .Columns.Add("Col" & iCol, "ColName" & iCol)
                Next
            End With
            Load_InformationtoGrid(sqlQRY, dgvMultiGRID, intNoCol)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function fk_ReadGRID(ByVal intCol As Integer) As String
        Dim StrRVal As String = ""
        With dgvMultiGRID
            StrRVal = .Item(intCol, 0).Value
        End With
        Return StrRVal
    End Function


    Public Function FK_Rep(ByVal strText As String)

        Dim strTxtValue As String = ""
        strTxtValue = Replace(strText, "'", "`")
        Return strTxtValue

    End Function

    Public Function ReadKey(ByVal Value As String) As String
        Dim str1 As String
        str1 = "HKCU\Software\HRIS\" & Value
        Dim B As Object
        Dim R As Object
        On Error Resume Next
        B = CreateObject("wscript.shell")
        R = B.RegRead(str1)
        ReadKey = R
    End Function

    Public Function FK_UndoRep(ByVal strText As String)

        Dim strTxtValue As String = ""
        strTxtValue = Replace(strText, "`", "'")
        Return strTxtValue

    End Function

    Public Sub IDNum_Results(ByVal StrIDNum As String)
        Dim iYear As Integer
        Dim iSex, iFeb As Integer
        If StrIDNum = "" Then
            Exit Sub
        End If

        Dim intLength As Integer = Trim(StrIDNum).Length
        'Old NIC
        If intLength <= 10 Then
            iYear = Left(StrIDNum, 2)
            If iYear <= 99 Then
                iYear = 1900 + iYear
            Else
                iYear = 2000 + iYear
            End If

            iFeb = DateDiff(DateInterval.Day, DateSerial(iYear, 1, 31), DateAdd(DateInterval.Day, -1, DateSerial(iYear, 3, 1)))
            iSex = Mid(Left(StrIDNum, 5), 3, 5)
            If iSex <= 500 Then
                StrNICSex = "Male"
                If iFeb >= 29 Then
                    iSex = iSex - 1
                Else
                    iSex = iSex - 2
                End If
            Else
                StrNICSex = "Female"
                iSex = (iSex - 500) - 1
                If iFeb >= 29 Then
                    iSex = iSex
                Else
                    iSex = iSex - 1
                End If
            End If
        ElseIf intLength > 10 Then
            iYear = Left(StrIDNum, 4)
            'If iYear <= 99 Then
            '    iYear = 1900 + iYear
            'Else
            '    iYear = 2000 + iYear
            'End If

            iFeb = DateDiff(DateInterval.Day, DateSerial(iYear, 1, 31), DateAdd(DateInterval.Day, -1, DateSerial(iYear, 3, 1)))
            iSex = Mid(Left(StrIDNum, 7), 5, 7)
            If iSex <= 500 Then
                StrNICSex = "Male"
                If iFeb >= 29 Then
                    iSex = iSex - 1
                Else
                    iSex = iSex - 2
                End If
            Else
                StrNICSex = "Female"
                iSex = (iSex - 500) - 1
                If iFeb >= 29 Then
                    iSex = iSex
                Else
                    iSex = iSex - 1
                End If
            End If
        End If


        dtNICDoB = Format(DateAdd(DateInterval.Day, iSex, DateSerial(iYear, 1, 1)), "dd/MMM/yyyy")

    End Sub

    Public Function fk_CheckEx(ByVal sqlSTR As String) As Boolean
        Dim cnCon As New SqlConnection(sqlConString)
        Try
            cnCon.Open()
            Dim cmDbl As New SqlCommand(sqlSTR, cnCon)
            Dim drDbl As SqlDataReader = cmDbl.ExecuteReader
            If drDbl.Read = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            cnCon.Close()
        End Try
    End Function

    Public Sub proc_OnlyNumeric1(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim intK As Integer = AscW(e.KeyChar)
        If (intK >= 48 And intK <= 57) Or intK = 46 Or intK = 8 Then
            e.Handled = False
            Return
        End If
        e.Handled = True
    End Sub

    'Insert to SQL Audit
    Public Function sv_Audit(ByVal trModuel As String, ByVal trMode As String, ByVal trDesc As String, ByVal uID As String, ByVal EffAmt As Double) As String
        Dim StrQR As String
        'Generate the Transaction No
        Dim iTr As Integer = fk_sqlDbl("SELECT NoTrs FROM tblControl") + 1
        Dim StrTr As String = fk_CreateSerial(10, iTr)

        StrQR = "INSERT INTO tblAudit (TrID,TrDate,TrModule,Mode,TrDesc,UserID,EffAmt,Status) VALUES " &
        " ('" & StrTr & "','" & Format(dtWorkingDate, "yyyyMMdd") & "','" & trModuel & "','" & trMode & "','" & trDesc & "','" & uID & "'," & EffAmt & ",0) " &
        " UPDATE tblControl SET noTrs = NoTrs + 1"


        Return StrQR

        'Ge
    End Function

    Public Function fk_CreateSerial(ByVal intLen As Integer, ByVal intVal As Integer) As String
        Dim StrSer As String
        StrSer = StrDup(intLen - Len(CStr(intVal)), "0") & CStr(intVal)
        Return StrSer
    End Function
    'pass control value
    Public Function fk_sqlDbl(ByVal sqlSTR As String) As Double
        Dim cnCon As New SqlConnection(sqlConString)
        Try
            cnCon.Open()
            Dim cmDbl As New SqlCommand(sqlSTR, cnCon)
            Dim drDbl As SqlDataReader = cmDbl.ExecuteReader
            If drDbl.Read = True Then
                Return IIf(IsDBNull(drDbl.Item(0)), 0, drDbl.Item(0))
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnCon.Close()
        End Try
    End Function

    Public Function fk_RetDate(ByVal sqlSTR As String) As Date
        Dim cnCon As New SqlConnection(sqlConString)
        Try
            cnCon.Open()
            Dim cmDbl As New SqlCommand(sqlSTR, cnCon)
            Dim drDbl As SqlDataReader = cmDbl.ExecuteReader
            If drDbl.Read = True Then
                Return IIf(IsDBNull(drDbl.Item(0)), DateSerial(1900, 1, 1), drDbl.Item(0))
            Else
                Return DateSerial(1900, 1, 1)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnCon.Close()
        End Try
    End Function

    Public Function fk_RetString(ByVal sqlSTR As String) As String
        Dim cnRetStr As New SqlConnection(sqlConString)
        cnRetStr.Open()
        Dim strRs As String = ""
        Try
            Dim cmRetStr As New SqlCommand(sqlSTR, cnRetStr)
            Dim drRetStr As SqlDataReader = cmRetStr.ExecuteReader
            If drRetStr.Read = True Then
                strRs = drRetStr.Item(0)
            Else
                strRs = ""
            End If
            drRetStr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally

            cnRetStr.Close()
        End Try
        Return strRs
        cnRetStr.Close()
    End Function

    Public Sub ListCombo(ByVal cMb As ComboBox, ByVal SQLString As String, ByVal feiLd As String)
        cMb.Items.Clear()

        Dim ListSql As String
        ListSql = SQLString
        Dim SQLCCn As New SqlConnection(sqlConString)
        SQLCCn.Open()
        Try
            Dim sqlCmd As New SqlCommand(ListSql, SQLCCn)
            Dim sqlDtaRdr As SqlDataReader = sqlCmd.ExecuteReader
            cMb.Items.Add("NONE")

            Do While sqlDtaRdr.Read
                Dim StraddToCombo As String
                StraddToCombo = sqlDtaRdr.Item(feiLd)
                cMb.Items.Add(StraddToCombo)
            Loop

            If cMb.Items.Count > 0 Then
                cMb.SelectedText = "NONE"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ListComboAll(ByVal cMb As ComboBox, ByVal SQLString As String, ByVal feiLd As String)
        cMb.Items.Clear()

        Dim ListSql As String
        ListSql = SQLString
        Dim SQLCCn As New SqlConnection(sqlConString)
        SQLCCn.Open()

        Dim sqlCmd As New SqlCommand(ListSql, SQLCCn)
        Dim sqlDtaRdr As SqlDataReader = sqlCmd.ExecuteReader
        cMb.Items.Add("[ALL]")

        Do While sqlDtaRdr.Read
            Dim StraddToCombo As String
            StraddToCombo = sqlDtaRdr.Item(feiLd)
            cMb.Items.Add(StraddToCombo)
        Loop
        Try
            cMb.SelectedIndex = 0
        Catch ex As Exception

        End Try
        sqlDtaRdr.Close()
    End Sub

    Public Sub ButtonLoad(ByVal sContainer As Control)

        Dim ctrlk As Control
        For Each ctrlk In sContainer.Controls

            If TypeOf ctrlk Is Button Then
                If ctrlk.Tag = "1" Then
                    CType(ctrlk, Button).ForeColor = clrFocused
                    CType(ctrlk, Button).FlatAppearance.BorderColor = clrFocused
                    CType(ctrlk, Button).FlatAppearance.BorderSize = 1
                    CType(ctrlk, Button).BackgroundImage = Nothing
                    CType(ctrlk, Button).BackColor = Color.White
                End If
            End If

            If TypeOf ctrlk Is Panel Then
                If ctrlk.Tag = "1" Then
                    ctrlk.BackColor = clrFocused
                End If
            End If

            If ctrlk.HasChildren Then
                ButtonLoad(ctrlk)
            End If

        Next

    End Sub

    'Public Sub CenterFormThemedK(ByVal sForm As Form, ByVal sPanel As Panel, ByVal sLabel As Label, ByVal tPanel As Panel, ByVal tLabel As Label)

    '    Try
    '        'In the Form Load
    '        'CENTERFORM (ME,panel_name)
    '        sForm.Left = (Screen.PrimaryScreen.WorkingArea.Width - sForm.Width) / 2
    '        sForm.Top = (Screen.PrimaryScreen.WorkingArea.Height - sForm.Height) / 2
    '        sForm.Icon = frmMainAttendance.Icon

    '        sPanel.BackgroundImage = Nothing
    '        sPanel.BackColor = Color.OrangeRed
    '        If strStrech = "0" Then sPanel.BackgroundImageLayout = Windows.Forms.ImageLayout.Tile Else If strStrech = "1" Then sPanel.BackgroundImageLayout = Windows.Forms.ImageLayout.Stretch
    '        sLabel.Font = New Font(sLabel.Font.FontFamily, 8)
    '        sLabel.Font = New System.Drawing.Font(sLabel.Font, FontStyle.Bold)
    '        sLabel.ForeColor = Color.White
    '        sForm.Text = "HRIS Attendance Manager-> " & sLabel.Text
    '        sForm.FormBorderStyle = FormBorderStyle.None

    '        tLabel.ForeColor = Color.White
    '        tPanel.BackgroundImage = Nothing
    '        tPanel.BackColor = Color.OrangeRed
    '        ButtonLoad(sForm)

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message)

    '    End Try

    'End Sub

    Public Sub CenterFormThemed(ByVal sForm As Form, ByVal sPanel As Panel, ByVal sLabel As Label)

        Try
            'In the Form Load
            'CENTERFORM (ME,panel_name)
            ''sForm.Left = (Screen.PrimaryScreen.WorkingArea.Width - sForm.Width) / 2
            ''sForm.Top = (Screen.PrimaryScreen.WorkingArea.Height - sForm.Height) / 2
            sForm.Icon = frmMainAttendance.Icon

            sPanel.BackgroundImage = My.Resources.leftCorner
            If strStrech = "0" Then sPanel.BackgroundImageLayout = Windows.Forms.ImageLayout.Tile Else If strStrech = "1" Then sPanel.BackgroundImageLayout = Windows.Forms.ImageLayout.Stretch
            sLabel.Font = New Font(sLabel.Font.FontFamily, 8)
            sLabel.Font = New System.Drawing.Font(sLabel.Font, FontStyle.Bold)
            sLabel.ForeColor = Color.White
            sForm.Text = "HRISforBB -> " & sLabel.Text
            sForm.FormBorderStyle = FormBorderStyle.None
            'sForm.MaximumSize = Screen.FromRectangle(sForm.Bounds).WorkingArea.Size
            'sForm.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
            ''ButtonLoad(sForm)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Public Function Save_Codes(ByVal StrSvSt As String, ByVal StrCode As String, ByVal StrDesc As String, ByVal intStatus As Integer, ByVal CrtlFldName As String, ByVal InsertTable As String, ByVal codeFld As String, ByVal descFld As String) As String
        Dim StrMess As String = ""

        'First need to save the informaiton 
        If StrSvSt = "S" Then
            'Need to regenerate the Save Number
            Dim iC As Integer = fk_sqlDbl("SELECT " & CrtlFldName & " FROM tblCOntrol") + 1
            StrCode = fk_CreateSerial(3, iC)

        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvSt
                Case "S"
                    sqlQRY = "INSERT INTO " & InsertTable & " VALUES ('" & StrCode & "','" & FK_Rep(StrDesc) & "',''," & intStatus & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblControl SET " & CrtlFldName & " = " & CrtlFldName & " + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    StrMess = "Information Saved"

                Case "E"

                    sqlQRY = "UPDATE " & InsertTable & " SET " & descFld & " = '" & FK_Rep(StrDesc) & "',Status = " & intStatus & " WHERE " & codeFld & " = '" & StrCode & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    StrMess = "Information Modified"
            End Select
        Catch ex As Exception
            StrMess = ex.Message
            trSave.Rollback()
        Finally
            cnSave.Close()

        End Try

        Return StrMess


    End Function

    Public Sub _GeneratePayrollSummary()

    End Sub
    'New 3 Feild Updating QRY
    Public Function Save_Codes3(ByVal StrSvSt As String, ByVal StrCode As String, ByVal StrDesc As String, ByVal intStatus As Integer, ByVal CrtlFldName As String, ByVal InsertTable As String, ByVal codeFld As String, ByVal descFld As String, ByVal addFld As String, ByVal AddFldValue As String) As String
        Dim StrMess As String = ""

        'First need to save the informaiton 
        If StrSvSt = "S" Then
            'Need to regenerate the Save Number
            Dim iC As Integer = fk_sqlDbl("SELECT " & CrtlFldName & " FROM tblCOntrol") + 1
            StrCode = fk_CreateSerial(3, iC)
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvSt
                Case "S"
                    sqlQRY = "INSERT INTO " & InsertTable & " VALUES ('" & StrCode & "','" & FK_Rep(StrDesc) & "', '" & AddFldValue & "', ''," & intStatus & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblControl SET " & CrtlFldName & " = " & CrtlFldName & " + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()
                    StrMess = "Information Saved"

                Case "E"

                    sqlQRY = "UPDATE " & InsertTable & " SET " & descFld & " = '" & FK_Rep(StrDesc) & "', " & addFld & " = '" & AddFldValue & "',Status = " & intStatus & " WHERE " & codeFld & " = '" & StrCode & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    trSave.Commit()

                    StrMess = "Information Modified"
            End Select
        Catch ex As Exception
            StrMess = ex.Message
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try
        Return StrMess
    End Function

    Public Function GetInitialsFromString(ByVal fullName As String) As String
        Dim StrIns As String = ""
        If fullName <> "" Then

            If fullName.Contains("/[¬!£$%^&*()`{}\[\]:@~;\'#<>?,.\/\\-=_+\|]/") Then
                fullName = NormalizeName(fullName)
            End If
            Dim nameArray As String() = fullName.Split(" ")
            Dim initials As String = String.Empty
            For Each name As String In nameArray
                initials += name.Chars(0) & "."
            Next
            StrIns = initials.ToUpper()
        End If
        Return StrIns

    End Function

    Public Sub getLastNameFromString(ByVal dispName As String)
        If dispName <> "" Then
            Dim nameArray As String() = dispName.Split(" ")
        End If
    End Sub


    Public Function get_FirstLetter(ByVal fullName As String) As String
        Dim StrIns As String = ""
        If fullName <> "" Then
            If fullName.Contains("/[¬!£$%^&*()`{}\[\]:@~;\'#<>?,.\/\\-=_+\|]/") Then
                fullName = NormalizeName(fullName)
            End If
            Dim nameArray As String() = fullName.Split(" ")
            Dim initials As String = String.Empty
            For Each name As String In nameArray
                initials += name.Chars(0)
            Next
            StrIns = initials.ToUpper()
        End If
        Return StrIns

    End Function

    Public Function NormalizeName(ByVal fullName As String) As String
        Dim name As String() = fullName.Split(",")
        Return String.Format("{0} {1}", Trim(name(1)), Trim(name(0)))
    End Function

    Public Function Save_CodesInt(ByVal StrSvSt As String, ByVal StrCode As String, ByVal StrDesc As String, ByVal intStatus As Integer, ByVal CrtlFldName As String, ByVal InsertTable As String, ByVal codeFld As String, ByVal descFld As String, ByVal addFld As String, ByVal AddFldValue As Double) As String
        Dim StrMess As String = ""

        'First need to save the informaiton 
        If StrSvSt = "S" Then
            'Need to regenerate the Save Number
            Dim iC As Integer = fk_sqlDbl("SELECT " & CrtlFldName & " FROM tblCOntrol") + 1
            StrCode = fk_CreateSerial(3, iC)

        End If

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            Select Case StrSvSt
                Case "S"
                    sqlQRY = "INSERT INTO " & InsertTable & " VALUES ('" & StrCode & "','" & StrDesc & "', '" & AddFldValue & "', ''," & intStatus & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                    sqlQRY = "UPDATE tblControl SET " & CrtlFldName & " = " & CrtlFldName & " + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                    trSave.Commit()
                    StrMess = "Information Saved"

                Case "E"
                    sqlQRY = "UPDATE " & InsertTable & " SET " & descFld & " = '" & StrDesc & "', " & addFld & " = '" & AddFldValue & "',Status = " & intStatus & " WHERE " & codeFld & " = '" & StrCode & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()
                    trSave.Commit()

                    StrMess = "Information Modified"
            End Select
        Catch ex As Exception
            StrMess = ex.Message
            trSave.Rollback()
        Finally
            cnSave.Close()

        End Try

        Return StrMess

    End Function

    Public Function fk_Savedata(ByVal sqlQRY As String, ByVal StrSvSt As String) As String
        Dim StrRetVal As String

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Try
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            trSave.Commit()
            If StrSvSt = "S" Then
                MsgBox("Information Saved", MsgBoxStyle.Information)
            Else
                MsgBox("Information Modified", MsgBoxStyle.Information)
            End If
            StrRetVal = "S" ' Transaction sucesses
        Catch ex As Exception
            trSave.Rollback()
            MsgBox(ex.Message)
            StrRetVal = "F" ' transaction fail

        Finally
            cnSave.Close()
        End Try

    End Function

    Public Function fk_Savedata1(ByVal sqlQRY As String, ByVal StrSvSt As String) As String
        Dim StrRetVal As String

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Try
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            trSave.Commit()

            StrRetVal = "S" ' Transaction sucesses
        Catch ex As Exception
            trSave.Rollback()
            MsgBox(ex.Message)
            StrRetVal = "F" ' transaction fail

        Finally
            cnSave.Close()
        End Try
        Return StrRetVal
    End Function

    Public Sub Load_GridCombo(ByVal sqlQRY As String, ByVal dgv As DataGridViewComboBoxColumn)

        Dim cnLoad As New SqlConnection(sqlConString)
        cnLoad.Open()
        Try
            Dim cmLoad As New SqlCommand(sqlQRY, cnLoad)
            Dim drLoad As SqlDataReader = cmLoad.ExecuteReader
            dgv.Items.Clear()
            Do While drLoad.Read = True
                dgv.Items.Add(IIf(IsDBNull(drLoad.Item(0)), "", drLoad.Item(0)))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnLoad.Close()
        End Try

    End Sub

    Public Function fk_CreateTableR(ByVal strQry As String, ByVal strTblName As String) As Boolean

        Dim sqlCon As New SqlConnection(sqlConString)
        Try
            sqlCon.Open()
            Dim sqlComnd As New SqlCommand("select OBJECT_ID('" & strTblName & "')", sqlCon)
            Dim sqlReader As SqlDataReader = sqlComnd.ExecuteReader
            Dim strTblID As String = ""
            If sqlReader.Read Then strTblID = IIf(IsDBNull(sqlReader.Item(0)), "", sqlReader.Item(0))
            sqlReader.Close()
            If strTblID = "" Then
                Try
                    Dim sqlComnd1 As New SqlCommand(strQry, sqlCon)
                    sqlComnd1.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error Occured while creating a table. Error is " + ex.Message)
                Finally
                    sqlCon.Close()
                End Try
            End If
        Catch ex As Exception
            MsgBox("Error Occured While Creating Table. Please Check the Connection with Database." + ex.Message)
        End Try

    End Function

    Public Function fk_UpdateTblR(ByVal strQry As String) As Boolean

        Dim boolMsg As Boolean = True

        Dim sqlCon As New SqlConnection(sqlConString)
        Try
            sqlCon.Open()
            Dim sqlComnd As New SqlCommand
            sqlComnd = sqlCon.CreateCommand

            Try

                sqlComnd.CommandText = strQry
                sqlComnd.ExecuteNonQuery()

                boolMsg = True
            Catch ex As Exception
                MsgBox("Error occured while updating the table. " + ex.Message)
                boolMsg = False
            Finally
                sqlCon.Close()
            End Try
        Catch ex As Exception
            MsgBox("Unable to open the connection")
        End Try

        Return boolMsg

    End Function

    Public Sub ExporttoExcel(ByVal dgvExistingItems As DataGridView, ByVal sTextColumnUpto As Integer)
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim excelBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(excelBook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
            xlApp.Visible = True
            rowsTotal = dgvExistingItems.RowCount - 1
            colsTotal = dgvExistingItems.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()

                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgvExistingItems.Columns(iC).HeaderText.ToUpper
                Next
                For I = 0 To rowsTotal
                    For X As Integer = 1 To sTextColumnUpto
                        .Cells(I + 2, X).NumberFormat = "@"
                    Next
                    For j = 0 To colsTotal
                        '.Cells(I + 2, 1).NumberFormat = "@"
                        .Cells(I + 2, j + 1).value = dgvExistingItems.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 10
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
                MsgBox("Exported Successfully", MsgBoxStyle.Information)
            End With
        Catch ex As Exception
            MsgBox("Export Excel Error " & ex.Message)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Public Sub HL_MouseLine(ByVal sGrid As DataGridView, ByVal sRow As Integer)
        'txtDisplayName.Text = dgvData.CurrentRow.Index
        Try
            'dgvData.Rows(e.RowIndex)
            'For X As Integer = 0 To sRow - 1
            sGrid.Rows(sRow - 1).DefaultCellStyle.BackColor = Color.White
            'Next
            sGrid.Rows(sRow).DefaultCellStyle.BackColor = Color.Khaki
            'For X1 As Integer = sRow + 1 To sGrid.RowCount - 1
            sGrid.Rows(sRow + 1).DefaultCellStyle.BackColor = Color.White
            'Next
            'sGrid.Rows(sRow).DefaultCellStyle.BackColor = Color.Khaki
            'dgvData.Item(e.ColumnIndex, e.RowIndex).Selected = True
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ExporttoExcelWithHeader(ByVal dgvExistingItems As DataGridView, ByVal sTextColumnUpto As Integer, ByVal StrMainHead As String, ByVal StrSubHead As String, ByVal intIsHead As Integer, ByVal strAddress As String)
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim excelBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(excelBook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
            xlApp.Visible = True
            rowsTotal = dgvExistingItems.RowCount - 1
            colsTotal = dgvExistingItems.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()

                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgvExistingItems.Columns(iC).HeaderText.ToUpper
                Next
                For I = 0 To rowsTotal
                    For X As Integer = 1 To sTextColumnUpto
                        .Cells(I + 2, X).NumberFormat = "@"
                    Next
                    For j = 0 To colsTotal
                        '.Cells(I + 2, 1).NumberFormat = "@"
                        .Cells(I + 2, j + 1).value = dgvExistingItems.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 10
                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()

                'Insert Sub Header 
                If StrSubHead <> "" Then
                    .Range("1:1").Insert(Shift:=Excel.XlDirection.xlDown)
                    .Range("A1").Value = ""
                    '.Rows("1:1").Font.FontStyle = "Bold"
                    .Rows("1:1").Font.Size = 12
                End If

                If StrSubHead <> "" Then
                    .Range("1:1").Insert(Shift:=Excel.XlDirection.xlDown)
                    .Range("A1").Value = StrSubHead
                    .Rows("1:1").Font.FontStyle = "Bold"
                    .Rows("1:1").Font.Size = 12
                End If

                If strAddress <> "" Then
                    .Range("1:1").Insert(Shift:=Excel.XlDirection.xlDown)
                    .Range("A1").Value = strAddress
                    .Rows("1:1").Font.FontStyle = "Bold"
                    .Rows("1:1").Font.Size = 12
                End If

                If StrMainHead <> "" Then
                    .Range("1:1").Insert(Shift:=Excel.XlDirection.xlDown)
                    .Range("A1").Value = StrMainHead
                    .Rows("1:1").Font.FontStyle = "Bold"
                    .Rows("1:1").Font.Size = 14
                End If

                'Range(excelSheet.Cells(1, 1),excelSheet.Cells(1, 10)).Merge

                MsgBox("Exported Successfully", MsgBoxStyle.Information)
            End With
        Catch ex As Exception
            MsgBox("Export Excel Error " & ex.Message)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Public Sub _DayilyOTProcess(ByVal dtStart As Date, ByVal EdDate As Date)

        While (dtStart <= EdDate)

            Console.WriteLine(dtStart.ToShortDateString)

            New_OTCalMethod(dtStart, dtStart)
            dtStart = dtStart.AddDays(1)
        End While

    End Sub

    Public Function TestRotate(ByVal sImageFilePath As String, ByVal sImageNewPath As String) As String
        Dim rft As RotateFlipType = RotateFlipType.RotateNoneFlipNone
        Dim img As Bitmap = Image.FromFile(sImageFilePath)
        Dim properties As PropertyItem() = img.PropertyItems
        Dim bReturn As Boolean = False
        Dim iH As Integer = img.Height ' 648
        Dim iW As Integer = img.Width ' 432
        If iH - iW < 0 Then
            For Each p As PropertyItem In properties
                If p.Id = 274 Then
                    Dim orientation As Short = BitConverter.ToInt16(p.Value, 0)
                    Select Case orientation
                        Case 1
                            rft = RotateFlipType.RotateNoneFlipNone
                        Case 3
                            rft = RotateFlipType.Rotate180FlipNone
                        Case 6
                            rft = RotateFlipType.Rotate90FlipNone
                        Case 8
                            rft = RotateFlipType.Rotate270FlipNone
                    End Select
                End If
            Next
        Else
            rft = RotateFlipType.RotateNoneFlipNone
            sImageNewPath = sImageFilePath
        End If

        If rft <> RotateFlipType.RotateNoneFlipNone Then
            img.RotateFlip(rft)

            img.Save(sImageNewPath, System.Drawing.Imaging.ImageFormat.Jpeg)
            'System.IO.File.Delete(sImageNewPath)
        End If
        Return sImageNewPath
    End Function

    Public Sub fk_comboItems(ByVal sqlQryCmb As String, ByVal com_items As ComboBox)

        Dim con As New SqlConnection(sqlConString)
        com_items.Items.Clear()
        Try
            con.Open()
            Dim sqlcombo_department As New SqlCommand(sqlQryCmb, con)
            Dim redcombo_department As SqlDataReader = sqlcombo_department.ExecuteReader()

            While redcombo_department.Read()
                com_items.Items.Add(redcombo_department.Item(0))
            End While
            redcombo_department.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        'Return com_items.Items.Add
    End Sub

    Public Function GetString(ByVal SQLString As String) As String
        Dim srcValue As String = ""
        Dim strOutput As String = ""
        Dim ListSql As String
        Try
            'listcombo "Sql String","Output String"
            ListSql = SQLString
            Dim SQLCCn As New SqlConnection(sqlConString)
            SQLCCn.Open()
            Dim sqlCmd As New SqlCommand(ListSql, SQLCCn)
            Dim sqlDtaRdr As SqlDataReader = sqlCmd.ExecuteReader
            If sqlDtaRdr.Read Then
                srcValue = IIf(IsDBNull(sqlDtaRdr.Item(0)), "", sqlDtaRdr.Item(0))
            End If
            Return srcValue
            sqlCmd.Dispose()
            SQLCCn.Close()
            sqlDtaRdr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return srcValue
    End Function

    Public Function fk_browse(ByVal sloadstring As String, ByVal selectstring As String, ByVal searchstring As String) As String
        Cursor.Current = Cursors.WaitCursor
        'cursor.current = cursors.default
        If Not sloadstring = "" Then
            CurrentUser = Replace(CurrentUser, ".", "")
            CurrentUser = Replace(CurrentUser, "_", "")
            CurrentUser = Replace(CurrentUser, "-", "")
            CurrentUser = Replace(CurrentUser, " ", "")
            'abc = replace(abc, "", "")
            sSQL = "create view  " & CurrentUser & " as " & sloadstring
            FK_EQ(sSQL, "P", "", False, False, False)
            sSelect = selectstring
            ssearch = searchstring
            Dim fb As New frmBrowse
            fb.ShowDialog()
            sSQL = " drop  view  " & CurrentUser
            FK_EQ(sSQL, "P", "", False, False, False)
        End If
        'cursor.current = cursors.waitcursor
        Cursor.Current = Cursors.Default
        Return ssearch

    End Function

    Function UppercaseFirstLetter(ByVal val As String) As String
        ' Test for nothing or empty.
        If String.IsNullOrEmpty(val) Then
            Return val
        End If

        ' Convert to character array.
        Dim array() As Char = val.ToCharArray

        ' Uppercase first character.
        array(0) = Char.ToUpper(array(0))

        ' Return new string.
        Return New String(array)
    End Function

    Public Function FK_QueryRun(ByVal sString As String, ByVal ProcessConformationMessage As Boolean, ByVal ProcessCompletedMessage As Boolean) As Boolean
        If ProcessConformationMessage = True Then
            If MsgBox("Are you sure you want to Start This Process", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Function
        End If

        Dim cnSave As New SqlConnection(sqlConString)
        Dim cmSave As New SqlCommand
        Dim trSave As SqlTransaction
        Dim strStatus As Boolean = False
        Try
            cnSave.Open()
            trSave = cnSave.BeginTransaction
            cmSave = cnSave.CreateCommand
            cmSave.Transaction = trSave
            Dim sqlQRY As String = sString
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            trSave.Commit()
            strStatus = (True)
        Catch ex As Exception

            'trSave.Rollback()
            strStatus = False
            Console.WriteLine(ex.Message)
            If ProcessCompletedMessage = True Then
                If strStatus = False Then MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If

        Finally
            cnSave.Close()
            cmSave.Dispose()
            FK_QueryRun = strStatus
            If ProcessCompletedMessage = True Then
                If strStatus = True Then MsgBox("Process Completed Successfully", MsgBoxStyle.Information)
            End If
        End Try

    End Function


    Public Function FK_Delete(ByVal sqlQry As String, ByVal beforeConfirmMessage As Boolean, ByVal DeletedMessage As Boolean) As Boolean
        If beforeConfirmMessage = True Then
            If MsgBox("Are you sure you want to Delete this Record", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Function
        End If

        Dim tempSqlConnection As New SqlConnection(sqlConString)
        Dim strStatus As Boolean = False
        Try
            tempSqlConnection.Open()
            Dim sqlCMD As SqlCommand
            sqlCMD = tempSqlConnection.CreateCommand
            Dim sqlTrans As SqlTransaction = tempSqlConnection.BeginTransaction
            sqlCMD.Transaction = sqlTrans
            sqlCMD.CommandText = sqlQry
            sqlCMD.ExecuteNonQuery()
            sqlTrans.Commit()

            strStatus = True
        Catch ex As Exception

            strStatus = (False)
            MsgBox(ex.Message)

        Finally
            tempSqlConnection.Close()
        End Try
        If DeletedMessage = True Then
            If strStatus = True Then MsgBox("Data Deleted Successfully", MsgBoxStyle.Information)
            If strStatus = False Then MsgBox("Data Deleted Failed", MsgBoxStyle.Critical)
        End If
        Return strStatus
        'End If
    End Function

    Public Function GetFirstDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtFrom As DateTime = dtDate
        dtFrom = dtFrom.AddDays(-(dtFrom.Day - 1))
        Return dtFrom
    End Function

    Public Function GetLastDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtTo As New DateTime(dtDate.Year, dtDate.Month, 1)
        dtTo = dtTo.AddMonths(1)
        dtTo = dtTo.AddDays(-(dtTo.Day))
        Return dtTo
    End Function

    Public Function RoundUp(ByVal num As Double) As Integer
        Try
            'Temp variable to hold the decimal portion of the parameter
            Dim temp As Double
            'Get the decimal portion
            temp = num - Math.Truncate(num)
            'If there is a decimal portion then we add 1 to force it to round up
            num = IIf(temp > 0, num + 1, num)
            'return the truncated version of the double which should be the number rounded up
            Return Math.Truncate(num)
        Catch ex As Exception
            MessageBox.Show("Error occured in: " & ex.StackTrace & vbCrLf & vbCrLf & "Error: " & ex.Message,
                "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function FK_GetTime() As Date
        Dim CN As New SqlConnection(sqlConString)
        Dim SQLQR As String = "Select getdate() "
        Dim sDate As Date
        Try
            CN.Open()
            Dim CMD As New SqlCommand(SQLQR, CN)
            Dim RD As SqlDataReader = CMD.ExecuteReader
            While RD.Read
                sDate = RD.Item(0)
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return sDate
    End Function

End Module
