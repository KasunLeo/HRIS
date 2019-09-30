Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmCalendar

    Dim StrSvStatus As String = "S"
    Dim iCrMonth As Integer
    Dim iCrYear As Integer
    Dim intDefHoliday As Integer
    Dim intDefHalfday As Integer
    Dim dtSelDate As Date
    Dim SelDayType As String

    Dim ClrA As Integer
    Dim ClrR As Integer
    Dim ClrG As Integer
    Dim ClrB As Integer

    Dim StrSnD As String    '1
    Dim StrMnD As String    '2
    Dim StrThD As String    '3
    Dim StrWnD As String    '4
    Dim StrTuD As String    '5
    Dim StrFrD As String    '6
    Dim StrStD As String    '7
    Dim StrdTypeID As String ' '01'

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

        ClrA = 0
        ClrR = 0
        ClrG = 0
        ClrB = 0

        Dim crtl As Control
        For Each crtl In Me.TabPage3.Controls
            If TypeOf crtl Is TextBox Then crtl.Text = ""
        Next
        cmbWorkUnit.SelectedIndex = 0
        chkRemove.Checked = False

        pnlColor.BackColor = Color.FromArgb(192, 255, 192)

        Dim DyNos As Integer = fk_RetDbl("SELECT DyType FROM tblControl") + 1
        Dim StrDi As String = fk_CreateSerial(2, DyNos)

        txtID.Text = StrDi
        dgvType.Rows.Clear()

        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open() 'TypeID,TypeName,CompID,Status,clrA,clrR,clrG,clrB,WorkUnit
        Dim sqlQ As String = "select TypeID,TypeName,CompID,Status,clrA,clrR,clrG,clrB,WorkUnit from tblDayType Order By TypeID"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            Do While drShw.Read = True '================================================ change index to col name
                Dim StrT1 As String = IIf(IsDBNull(drShw.Item("TypeID")), "", drShw.Item("TypeID"))
                Dim StrT2 As String = IIf(IsDBNull(drShw.Item("TypeName")), "", drShw.Item("TypeName"))
                Dim StrT3 As String = IIf(IsDBNull(drShw.Item("clrA")), "", drShw.Item("clrA"))
                Dim StrT4 As String = IIf(IsDBNull(drShw.Item("clrR")), "", drShw.Item("clrR"))
                Dim StrT5 As String = IIf(IsDBNull(drShw.Item("clrG")), "", drShw.Item("clrG"))
                Dim StrT6 As String = IIf(IsDBNull(drShw.Item("clrB")), 0, drShw.Item("clrB"))

                dgvType.Rows.Add(StrT1, StrT2, StrT3, StrT4, StrT5, StrT6)
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try
        clr_Grid(dgvType)

        StrSvStatus = "S"
        txtName.Focus()

    End Sub

    Public Function fk_RetDbl(ByVal sqlQ As String) As Double
        Dim val As Double
        Dim cnVal As New SqlConnection(sqlConString)
        cnVal.Open()
        Try
            Dim cmVal As New SqlCommand(sqlQ, cnVal)
            Dim drVal As SqlDataReader = cmVal.ExecuteReader
            If drVal.Read = True Then
                val = IIf(IsDBNull(drVal.Item(0)), 0, drVal.Item(0))
            Else
                val = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnVal.Close()
        End Try

        Return val
    End Function

    Private Sub pnlColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlColor.Click

        If clrDg.ShowDialog = Windows.Forms.DialogResult.OK Then

            pnlColor.BackColor = clrDg.Color
            ClrA = pnlColor.BackColor.A
            ClrR = pnlColor.BackColor.R
            ClrG = pnlColor.BackColor.G
            ClrB = pnlColor.BackColor.B

        End If

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If UP("Calender", "Create day types") = False Then Exit Sub
        If txtID.Text = "" Then
            MsgBox("No ID", MsgBoxStyle.Information)
            Exit Sub
        End If

        If txtName.Text = "" Then
            MsgBox("Please Enter the Description. ", MsgBoxStyle.Information)
            txtName.Focus()
            Exit Sub
        End If
        '======================== chek active records of the daytype before remove
        'select DayType from tblCalendar where DayType='' Rajitha.
        If chkRemove.Checked = True Then
            If True = fk_CheckEx("select DayType from tblCalendar where DayType='" & txtID.Text & "'") Then
                MsgBox("This Can not Remove when Active Records Exist.")
                cmdRefresh_Click(sender, e)
                Exit Sub
            End If
        End If

        If StrSvStatus = "S" Then
            txtID.Text = fk_CreateSerial(2, (fk_RetDbl("SELECT DyType FROM tblControl") + 1))
        End If

        If txtShortCod.Text = "" Then MsgBox("Enter Short Code", MsgBoxStyle.Information) : txtShortCod.Focus() : Exit Sub

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim sqlQRY As String
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave

        Try
            Select Case StrSvStatus

                Case "S" 'TypeID,TypeName,CompID,Status,clrA,clrR,clrG,clrB,WorkUnit
                    sqlQRY = "INSERT INTO tblDayType (TypeID,TypeName,CompID,Status,clrA,ClrR,ClrG,ClrB,WorkUnit,NoSub,shortCode,isInReport) VALUES ( '" & txtID.Text & "','" & FK_Rep(txtName.Text) & "','" & StrCompID & "'," & chkRemove.CheckState & ", " & ClrA & "," & ClrR & "," & ClrG & ", " & ClrB & "," & CDbl(cmbWorkUnit.Text) & ",0,'" & Trim(txtShortCod.Text) & "'," & chkView.CheckState & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()


                    sqlQRY = "UPDATE tblControl SET DyType = DyType + 1"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                Case "E"
                    sqlQRY = "UPDATE tblDayType SET TypeName ='" & FK_Rep(txtName.Text) & "',Status=" & chkRemove.CheckState & ",clrA = " & ClrA & ", ClrR = " & ClrR & ", ClrG = " & ClrG & ",ClrB = " & ClrB & ", WorkUnit = " & CDbl(cmbWorkUnit.Text) & ",shortCode='" & Trim(txtShortCod.Text) & "',isInReport=" & chkView.CheckState & " WHERE TypeID = '" & txtID.Text & "'"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

            End Select

            trSave.Commit()
            MsgBox("Saved", MsgBoxStyle.Information)
            cmdRefresh_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub frmCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label18)
        ControlHandlers(Me)

        '===================Copied Start
        '' '' ''        Dim strQry As String = "create table tblDayType(" & _
        '' '' ''    " TypeID nvarchar (2) null," & _
        '' '' ''    " TypeName nvarchar(40) null," & _
        '' '' ''    " CompID nvarchar (3)null," & _
        '' '' ''    " Status numeric (18,0)null," & _
        '' '' ''    " clrA numeric (18,0)null," & _
        '' '' ''    " clrR numeric (18,0)null, " & _
        '' '' ''    " clrG numeric (18,0)null," & _
        '' '' ''    " clrB numeric (18,0)null," & _
        '' '' ''    " WorkUnit numeric (18,1) not null default ((0))" & _
        '' '' ''    " )"
        '' '' ''        fk_CreateTableR(strQry, "tblDayType")


        '' '' ''        strQry = " create table tblCalendar(" & _
        '' '' ''" DayID numeric (18,0)null," & _
        '' '' ''" cYear numeric (18,0)null, " & _
        '' '' ''" cMonth numeric (18,0)null," & _
        '' '' ''" Date datetime null," & _
        '' '' ''" DayType nvarchar (2) null," & _
        '' '' ''" workingType numeric (18,1)null," & _
        '' '' ''" Status numeric (18,0)null, " & _
        '' '' ''" DayLink numeric (18,0) not null default ((0))" & _
        '' '' ''" )"
        '' '' ''        fk_CreateTableR(strQry, "tblCalendar")

        '' '' ''        strQry = " alter table tblControl add DyType numeric (18,0) not null default 0"
        '' '' ''        fk_AddFieldToTbl(strQry, "tblControl", "DyType")


        '' '' ''        strQry = " CREATE TABLE tblEmpRegister(" & _
        '' '' '' " EmpID nvarchar(6)  NULL," & _
        '' '' '' " CompID nvarchar(3)  NULL," & _
        '' '' '' " cMonth numeric(18, 0) NULL," & _
        '' '' '' " cYear numeric(18, 0) NULL," & _
        '' '' '' " AtDate datetime NULL," & _
        '' '' '' " InDate datetime NULL," & _
        '' '' '' " InTime1 datetime NULL," & _
        '' '' '' " OutDate datetime NULL," & _
        '' '' ''" 	OutTime1 datetime NULL," & _
        '' '' ''" 	InTime2 datetime NULL," & _
        '' '' ''" 	OutTime2 datetime NULL," & _
        '' '' ''" 	ShiftID nvarchar(3) NULL," & _
        '' '' ''" 	DayID numeric(18, 0) NULL," & _
        '' '' ''" 	DayTypeID nvarchar(2)  NULL," & _
        '' '' ''" 	WorkHrs numeric(18, 2) NULL," & _
        '' '' ''" 	sInTime datetime NULL," & _
        '' '' ''" 	sOutTime datetime NULL," & _
        '' '' ''" 	StrInTime nvarchar(10)  NULL," & _
        '' '' ''" 	StrOutTime nvarchar(10)  NULL," & _
        '' '' ''" 	AntStatus numeric(18, 0) NULL," & _
        '' '' ''" 	WorkMins numeric(18, 0) NULL," & _
        '' '' ''" 	IsLate numeric(18, 0) NULL," & _
        '' '' ''" 	LateMins numeric(18, 0) NULL," & _
        '' '' ''" 	IsEarly numeric(18, 0) NULL," & _
        '' '' ''" 	EarlyMins numeric(18, 0) NULL," & _
        '' '' ''" 	IsLeave numeric(18, 0) NULL," & _
        '' '' ''" 	LeaveID nvarchar(3)  NULL," & _
        '' '' ''" 	NoLeave numeric(18, 2) NULL," & _
        '' '' ''" 	IsoffdayWork numeric(18, 0) NULL," & _
        '' '' ''" 	IsNightWork numeric(18, 0) NULL," & _
        '' '' ''" 	InUpdate numeric(18, 0) NULL," & _
        '' '' ''" 	OutUpdate numeric(18, 0) NULL," & _
        '' '' ''" 	mInUpdate numeric(18, 0) NULL," & _
        '' '' ''" 	mOutUpdate numeric(18, 0) NULL," & _
        '' '' ''" 	BeginOT numeric(18, 0) NULL," & _
        '' '' ''" 	EndOT numeric(18, 0) NULL," & _
        '' '' ''" 	Status numeric(18, 0) NULL," & _
        '' '' ''" 	BgOTHrs numeric(18, 2) NOT NULL   DEFAULT ((0))," & _
        '' '' ''" 	EdOTHrs numeric(18, 2) NOT NULL   DEFAULT ((0))," & _
        '' '' '' " NumOffDayWrk numeric(18, 2) NOT NULL DEFAULT ((0))" & _
        '' '' ''" ) "

        '' '' ''        fk_CreateTableR(strQry, "tblEmpRegister")

        '=============================Copied Over
        cmdRefrDates_Click(sender, e)

        'cmdGenerate.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdGenerate.BackgroundImage, Me.GroupBox1.BackColor, 90)
        'Button2.BackgroundImage = ImageEffectsHelper.DrawReflection(Button2.BackgroundImage, Me.GroupBox1.BackColor, 90)
        'cmdRefrDates.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefrDates.BackgroundImage, Me.GroupBox1.BackColor, 90)
        'cmdUpdate.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdUpdate.BackgroundImage, Me.GroupBox3.BackColor, 90)
        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.GroupBox2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.GroupBox2.BackColor, 90)
        'cmdDel.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdDel.BackgroundImage, Me.GroupBox2.BackColor, 90)

        'If StrUserID = "HRIS" Then
        '    cmdSave.Enabled = True
        'Else
        '    cmdSave.Enabled = False
        'End If
        ''Check Default Halfday & Holidays
        'Dim cnOpn As New SqlConnection(sqlConString)
        'cnOpn.Open()

        'Try
        '    Dim cmOpn As New SqlCommand("select * from tblCalHead WHERE cYear = " & Year(Now.Date) & "", cnOpn)
        '    Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
        '    If drOpn.Read = True Then
        '        intDefHalfday = IIf(IsDBNull(drOpn.Item("DefHalfDay")), 0, drOpn.Item("DefHalfDay"))
        '        intDefHoliday = IIf(IsDBNull(drOpn.Item("DefholiDay")), 0, drOpn.Item("DefholiDay"))
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    cnOpn.Close()
        'End Try

        cmdRefresh_Click(sender, e)

    End Sub

    'Private Sub cmdSave_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseDown, cmdRefresh.MouseDown, Button1.MouseDown, Button2.MouseDown, Button3.MouseDown, Button4.MouseDown, Button9.MouseDown, cmdDel.MouseDown
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 2
    '    crtl.FlatAppearance.BorderColor = Me.GroupBox1.BackColor

    'End Sub

    'Private Sub cmdSave_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSave.MouseUp, cmdRefresh.MouseUp, cmdGenerate.MouseUp, Button2.MouseUp, cmdUpdate.MouseUp, Button4.MouseUp, cmdRefrDates.MouseUp, cmdDel.MouseUp
    '    Dim crtl As Button
    '    crtl = sender
    '    crtl.FlatAppearance.BorderSize = 0
    '    crtl.FlatAppearance.BorderColor = Me.GroupBox1.BackColor

    'End Sub


    Public Sub Pop_CmbSp(ByVal SqlQ As String, ByVal crlt As ComboBox)
        Dim cnPop As New SqlConnection(sqlConString)
        cnPop.Open()
        crlt.Items.Clear()
        crlt.Items.Add("ANY")
        Try
            Dim cmPop As New SqlCommand(SqlQ, cnPop)
            Dim drPOp As SqlDataReader = cmPop.ExecuteReader
            Do While drPOp.Read = True
                Dim StrVal As String
                StrVal = IIf(IsDBNull(drPOp.Item(0)), "", drPOp.Item(0))
                crlt.Items.Add(StrVal)

            Loop

            crlt.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnPop.Close()
        End Try
    End Sub



    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            cmbHoliday.Enabled = True
        Else
            cmbHoliday.SelectedIndex = 0
            cmbHoliday.Enabled = False
        End If




    End Sub

    Public Function fk_CheckEx(ByVal sqlQ As String) As Boolean
        Dim res As Boolean = False
        Dim cnSv As New SqlConnection(sqlConString)
        cnSv.Open()
        Try
            Dim cmSv As New SqlCommand(sqlQ, cnSv)
            Dim drSv As SqlDataReader = cmSv.ExecuteReader
            If drSv.Read = True Then
                res = True
            Else
                res = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnSv.Close()
        End Try
        Return res

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerate.Click
        If UP("Calender", "Generate calender") = False Then Exit Sub
        If cmbsDay.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Sunday.")
            cmbsDay.Focus()
            Exit Sub
        End If
        If cmbmDay.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Monday.")
            cmbmDay.Focus()
            Exit Sub
        End If
        If cmbTuDay.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Tuesday.")
            cmbTuDay.Focus()
            Exit Sub
        End If
        If cmbWday.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Wednesday.")
            cmbWday.Focus()
            Exit Sub
        End If
        If cmbthDay.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Thursday.")
            cmbthDay.Focus()
            Exit Sub
        End If
        If cmbFday.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Friday.")
            cmbFday.Focus()
            Exit Sub
        End If
        If cmbstDay.Text = "ANY" Then
            MsgBox("Please Select the Day Type for the Day Saturday.")
            cmbstDay.Focus()
            Exit Sub
        End If





        'Get the Current year
        Dim dtStDate As Date
        Dim dtEndDate As Date
        Dim dtCrDate As Date
        Dim IntcrMonth As Integer
        Dim intCrYear As Integer
        Dim intDayID As Integer
        Dim StrDayName As String
        Dim noDays As Integer
        'Dim IntHoliday As Integer
        'Dim intHalfday As Integer
        'Dim intDType As Integer
        Dim dblWrkType As Double


        'IntHoliday = cmbHoliday.SelectedIndex
        'intHalfday = cmbHalfDay.SelectedIndex
        'Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblCalHead WHERE cYear = " & CInt(cmbYear.Text) & "")
        Dim bolEx As Boolean = fk_CheckEx("SELECT * FROM tblCalendar WHERE cYear = " & CInt(cmbYear.Text) & "")

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction

        Dim sqlQRY As String

        'Create Data grid view 
        'Dim dgvDays As DataGridView
        'dgvDays = New DataGridView
        'With dgvDays
        '    .Columns.Add("DayNo", "Day No")
        '    .Columns.Add("DayNm", "Day Name")
        '    .Columns.Add("DayType", "Day TYpe")

        'End With

        ''Load Information to grid from the tblDays 
        'Load_InformationtoGrid("SELECT DayID,DayDesc,DayTypeID FROM tblDays Order By dayID", dgvDays, 3)
        Dim sqlUPs As String = ""
        cmSave.Transaction = trSave
        Try
            'If bolEx = True Then
            '    If MsgBox("Found Information, Do you need to reprocess", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            '        Exit Sub

            '    End If
            'End If

            If bolEx = True Then
                If MsgBox("Found Information, Do you need to reprocess", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub

                End If
            End If

            'Delete information from Calander 
            sqlQRY = "DELETE FROM tblCalendar WHERE cYear = " & CInt(cmbYear.Text) & ""
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()

            'sqlQRY = "DELETE FROM tblCalHead WHERE cYear = " & CInt(cmbYear.Text) & ""
            'cmSave.CommandText = sqlQRY
            'cmSave.ExecuteNonQuery()

            'Header Record First 'cYear,DefHoliday,RecSt,Status,
            'sqlQRY = "INSERT INTO tblCalHead VALUES (" & CInt(cmbYear.Text) & ", " & IntHoliday & "," & intHalfday & ",0,1)"
            'cmSave.CommandText = sqlQRY
            'cmSave.ExecuteNonQuery()

            StrSnD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbsDay.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrSnD & "' WHERE DayDesc = 'Sunday'"
            StrMnD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbmDay.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrMnD & "' WHERE DayDesc = 'Monday'"
            StrThD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbthDay.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrThD & "' WHERE DayDesc = 'Thursday'"
            StrWnD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbWday.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrWnD & "' WHERE DayDesc = 'Wednesday'"
            StrTuD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbTuDay.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrTuD & "' WHERE DayDesc = 'Tuesday'"
            StrFrD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbFday.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrFrD & "' WHERE DayDesc = 'Friday'"
            StrStD = fk_RetString("SELECT TypeID FROM tblDayType WHERE TypeName = '" & cmbstDay.Text & "'")
            sqlUPs = sqlUPs & " UPDATE tblDays SET DayTYpeID = '" & StrStD & "' WHERE DayDesc = 'Saturday'"


            sqlQRY = " update tblempregister set daytypeid= '" & StrSnD & "' where datepart(dw, atdate )=1 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            sqlQRY = sqlQRY & " update tblempregister set daytypeid= '" & StrMnD & "' where datepart(dw, atdate )=2 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            sqlQRY = sqlQRY & " update tblempregister set daytypeid= '" & StrTuD & "' where datepart(dw, atdate )=3 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            sqlQRY = sqlQRY & " update tblempregister set daytypeid= '" & StrWnD & "' where datepart(dw, atdate )=4 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            sqlQRY = sqlQRY & " update tblempregister set daytypeid= '" & StrThD & "' where datepart(dw, atdate )=5 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            sqlQRY = sqlQRY & " update tblempregister set daytypeid= '" & StrFrD & "' where datepart(dw, atdate )=6 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            sqlQRY = sqlQRY & " update tblempregister set daytypeid= '" & StrStD & "' where datepart(dw, atdate )=7 and datepart(yyyy, atdate )='" & cmbYear.Text & "'"
            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()


            Dim iMonth As Integer
            For iMonth = 1 To 12
                dtStDate = DateSerial(CInt(cmbYear.Text), iMonth, 1)
                Dim dt As Date = DateAdd(DateInterval.Month, 1, dtStDate)
                dtEndDate = DateAdd(DateInterval.Day, -1, dt)
                noDays = DateDiff(DateInterval.Day, dtStDate, dtEndDate) + 1
                Dim iDs As Integer
                IntcrMonth = iDs
                intCrYear = CInt(cmbYear.Text)

                For iDs = 1 To noDays


                    dtCrDate = DateSerial(intCrYear, iMonth, iDs)
                    StrDayName = dtCrDate.DayOfWeek.ToString
                    Select Case StrDayName
                        Case "Sunday"
                            StrdTypeID = StrSnD
                        Case "Monday"
                            StrdTypeID = StrMnD
                        Case "Tuesday"
                            StrdTypeID = StrTuD
                        Case "Thursday"
                            StrdTypeID = StrThD
                        Case "Wednesday"
                            StrdTypeID = StrWnD
                        Case "Friday"
                            StrdTypeID = StrFrD
                        Case "Saturday"
                            StrdTypeID = StrStD
                    End Select

                    'Select Case StrdTypeID
                    '    Case "01"
                    '        dblWrkType = 1
                    '    Case "05" 'Halfday
                    '        dblWrkType = 0.5
                    '    Case Else
                    '        dblWrkType = 0
                    'End Select

                    dblWrkType = fk_RetString("select WorkUnit from tblDayType where typeid='" & StrdTypeID & "'")


                    intDayID = dtCrDate.DayOfWeek + 1

                    'If intDayID = IntHoliday Then
                    '    intDType = 1 ' Default holiday
                    '    dblWrkType = 0
                    'ElseIf intDayID = intHalfday Then
                    '    intDType = 2 'Default Half day
                    '    dblWrkType = 0.5
                    'Else
                    '    intDType = 3 'Working Day
                    '    dblWrkType = 1
                    'End If
                    Dim dID As Integer = iMonth.ToString & iDs.ToString

                    'DayID,cYear,cMonth,Date,DayType,workingType,DayLink
                    sqlQRY = "INSERT INTO tblCalendar (DayID,cYear,cMonth,Date,DayType,WorkingType,Status,DayLink) VALUES (" & dID & "," & intCrYear & "," & iMonth & ",'" & Format(dtCrDate, "yyyyMMdd") & "','" & StrdTypeID & "'," & dblWrkType & ",0," & dtCrDate.DayOfWeek & ")"
                    cmSave.CommandText = sqlQRY
                    cmSave.ExecuteNonQuery()

                Next
            Next
            cmSave.CommandText = sqlUPs
            cmSave.ExecuteNonQuery()

            trSave.Commit()
            MsgBox("Information Generated", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            cmbHalfDay.Enabled = True
        Else
            cmbHalfDay.SelectedIndex = 0
            cmbHalfDay.Enabled = False
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        cmdRefrDates_Click(sender, e)
        Dim iTab As Integer
        iTab = TabControl1.SelectedIndex
        iCrYear = Year(Now.Date)
        iCrMonth = Month(Now.Date)
        Select Case iTab
            Case 2
                'ButtonLoad(TabPage2)
                cmdcYear.Text = iCrYear.ToString
                cmdcMonth.Text = MonthName(iCrMonth)
                Pop_Calendar(iCrYear, iCrMonth)
                'Show day types 
                With dgvDataType
                    'Add Columns
                    .Columns.Clear()
                    .Columns.Add("TypeID", "TypeID") : .Columns(0).Visible = False
                    .Columns.Add("TypeD", "Day Type") : .Columns(1).Width = .Width - 5
                    .Columns.Add("cA", "cA") : .Columns(2).Visible = False
                    .Columns.Add("cR", "cR") : .Columns(3).Visible = False
                    .Columns.Add("cG", "cG") : .Columns(4).Visible = False
                    .Columns.Add("cB", "cB") : .Columns(5).Visible = False
                End With

                'Load Details to grid 
                Load_InformationtoGrid("SELECT TypeID,TypeName,clrA,ClrR,clrG,clrB FROM tblDayType WHERE Status = 0 Order By TypeID", dgvDataType, 6)

                'Color the data grid
                With dgvDataType
                    For i As Integer = 0 To .RowCount - 1
                        .Item(1, i).Style.BackColor = Color.FromArgb(CInt(.Item(2, i).Value), CInt(.Item(3, i).Value), CInt(.Item(4, i).Value), CInt(.Item(5, i).Value))

                    Next
                End With

            Case 1
                cmdRefresh_Click(sender, e)
        End Select
    End Sub


    Public Sub Pop_Calendar(ByVal iY As Integer, ByVal iM As Integer)
        Dim BolExMonth As Boolean = fk_CheckEx("SELECT * FROM tblCalendar WHERE cYear = " & iY & " AND cMonth = " & iM & "")

        Dim iDT As Integer
        Dim dNos As Integer
        Dim stDt As Date = DateSerial(iY, iM, 1)
        iDT = stDt.DayOfWeek

        Dim edDt As Date = DateAdd(DateInterval.Month, 1, stDt)
        edDt = DateAdd(DateInterval.Day, -1, edDt)
        dNos = DateDiff(DateInterval.Day, stDt, edDt) + 1
        Dim iDs As Integer = 1
        Dim dtBank As Date
        Dim iCls As Integer
        Dim irs As Integer
        dgvCal.Rows.Clear()
        For irs = 0 To 5
            dgvCal.Rows.Add()
        Next
        Dim bolChk As Boolean = False
        With dgvCal
            If BolExMonth = True Then
                For irs = 0 To 5
                    For iCls = 0 To 6
                        If iDs = 1 Then
                            If iCls = iDT Then
                                bolChk = True
                                .Item(iCls, irs).Value = iDs.ToString
                                'iDs = iDs + 1
                            End If

                        Else
                            If iDs > dNos Then
                                .Item(iCls, irs).Value = ""
                                bolChk = False
                            Else
                                bolChk = True
                                .Item(iCls, irs).Value = iDs.ToString

                            End If
                        End If
                        dtBank = DateSerial(iCrYear, iCrMonth, iDs)
                        If bolChk = True Then
                            Dim cnOpn As New SqlConnection(sqlConString)
                            cnOpn.Open()
                            Dim sqlQ As String = "SELECT tblCalendar.DayID,tblCalendar.cYear,tblCalendar.cMonth,tblCalendar.Date,tblCalendar.DayType,tblCalendar.WorkingType, " & _
                            " tblCalendar.Status, tblDayType.TypeID, tblDayType.TypeName, tblDayType.ClrA, tblDayType.ClrR, tblDayType.ClrG, tblDayType.ClrB " & _
                            " FROM tblCalendar INNER JOIN tblDayType ON tblCalendar.DayType = tblDayType.TypeID WHERE tblCalendar.Date = '" & Format(dtBank, "yyyyMMdd") & "'"
                            Try
                                Dim cmOpn As New SqlCommand(sqlQ, cnOpn)
                                Dim drOpn As SqlDataReader = cmOpn.ExecuteReader
                                If drOpn.Read = True Then
                                    'tblDayTypes.ClrR, tblDayTypes.ClrR, tblDayTypes.CrlG, tblDayTypes.ClrB
                                    ClrA = IIf(IsDBNull(drOpn.Item("ClrA")), 0, drOpn.Item("ClrA"))
                                    ClrR = IIf(IsDBNull(drOpn.Item("ClrR")), 0, drOpn.Item("ClrR"))
                                    ClrG = IIf(IsDBNull(drOpn.Item("ClrG")), 0, drOpn.Item("ClrG"))
                                    ClrB = IIf(IsDBNull(drOpn.Item("ClrB")), 0, drOpn.Item("ClrB"))

                                    .Item(iCls, irs).Style.BackColor = Color.FromArgb(ClrA, ClrR, ClrG, ClrB)
                                    iDs = iDs + 1
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                cnOpn.Close()
                            End Try

                        End If
                    Next
                Next
            Else
                For irs = 0 To 5
                    For iCls = 0 To 6
                        If iDs = 1 Then
                            If iCls = iDT Then
                                bolChk = True
                                .Item(iCls, irs).Value = iDs.ToString

                                iDs = iDs + 1

                            End If

                        Else
                            If iDs > dNos Then
                                .Item(iCls, irs).Value = ""
                                bolChk = False
                            Else
                                bolChk = True
                                .Item(iCls, irs).Value = iDs.ToString
                                iDs = iDs + 1
                            End If
                        End If
                    Next
                Next

            End If

        End With

    End Sub

    Private Sub cmdYearUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYearUp.Click

        iCrYear = iCrYear + 1
        cmdcYear.Text = iCrYear.ToString
        Pop_Calendar(iCrYear, iCrMonth)

    End Sub

    Private Sub cmdMonthUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMonthUp.Click

        If iCrMonth = 12 Then
            iCrMonth = 1
        Else
            iCrMonth = iCrMonth + 1
        End If

        cmdcMonth.Text = MonthName(iCrMonth)
        Pop_Calendar(iCrYear, iCrMonth)

    End Sub

    Private Sub cmdYearDonw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYearDonw.Click

        iCrYear = iCrYear - 1
        cmdcYear.Text = iCrYear.ToString
        Pop_Calendar(iCrYear, iCrMonth)

    End Sub

    Private Sub cmdMonthDonw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMonthDonw.Click

        If iCrMonth = 1 Then
            iCrMonth = 12
        Else
            iCrMonth = iCrMonth - 1
        End If

        cmdcMonth.Text = MonthName(iCrMonth)
        Pop_Calendar(iCrYear, iCrMonth)

    End Sub

    Private Sub dgvType_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvType.CellClick
        If dgvType.RowCount = 0 Then Exit Sub
        With dgvType
            txtID.Text = .Item(0, .CurrentRow.Index).Value
            txtName.Text = FK_UndoRep(.Item(1, .CurrentRow.Index).Value.ToString)

            Dim cnShw As New SqlConnection(sqlConString)
            cnShw.Open() 'TypeID,TypeName,CompID,Status,clrA,clrR,clrG,clrB,WorkUnit
            Dim sqlQRY As String = "SELECT * FROM tbldayType WHERE typeID = '" & txtID.Text & "'"
            Try
                Dim cmShw As New SqlCommand(sqlQRY, cnShw)
                Dim drShw As SqlDataReader = cmShw.ExecuteReader
                If drShw.Read = True Then

                    Dim intWrkU As Double = IIf(IsDBNull(drShw.Item("WorkUnit")), 0, drShw.Item("WorkUnit"))
                    cmbWorkUnit.Text = Format(intWrkU, "##,##0.00")
                    ClrA = IIf(IsDBNull(drShw.Item("ClrA")), 0, drShw.Item("ClrA"))
                    ClrR = IIf(IsDBNull(drShw.Item("ClrR")), 0, drShw.Item("ClrR"))
                    ClrG = IIf(IsDBNull(drShw.Item("ClrG")), 0, drShw.Item("ClrG"))
                    ClrB = IIf(IsDBNull(drShw.Item("ClrB")), 0, drShw.Item("ClrB"))
                    chkRemove.Checked = CInt(IIf(IsDBNull(drShw.Item("Status")), 0, drShw.Item("Status")))
                    txtShortCod.Text = IIf(IsDBNull(drShw.Item("shortCode")), 0, drShw.Item("shortCode"))
                    chkView.Checked = CInt(IIf(IsDBNull(drShw.Item("isInReport")), 0, drShw.Item("isInReport")))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                cnShw.Close()
            End Try

            pnlColor.BackColor = Color.FromArgb(ClrA, ClrR, ClrG, ClrB)
            StrSvStatus = "E"
        End With

    End Sub



    Private Sub dgvCal_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCal.CellClick

        Dim iVal As String
        iVal = dgvCal.CurrentCell.Value
        If iVal <> "" Then
            dtSelDate = DateSerial(iCrYear, iCrMonth, CInt(iVal))
            TextBox1.Text = Format(dtSelDate, "dd/MMM/yyyy")

        End If

    End Sub

    Private Sub cmbYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbYear.KeyPress, cmbWday.KeyPress, cmbTuDay.KeyPress, cmbthDay.KeyPress, cmbstDay.KeyPress, cmbsDay.KeyPress, cmbmDay.KeyPress, cmbFday.KeyPress
        If AscW(e.KeyChar) = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub dgvDataType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDataType.Click
        If dgvDataType.RowCount = 0 Then Exit Sub
        SelDayType = dgvDataType.Item(0, dgvDataType.CurrentRow.Index).Value
        TxtType.Text = fk_RetString("select TypeName from dbo.tblDayType where typeId='" & SelDayType & "'")

    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtName.Focus()
        End If
    End Sub
    Private Sub txtName_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmbWorkUnit.Focus()
        End If
    End Sub
    Private Sub cmbWorkUnit_keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbWorkUnit.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cmdSave_Click(sender, e)
        End If
    End Sub

    Private Sub cmdRefrDates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefrDates.Click
        Dim iYear As Integer = 2005
        cmbYear.Items.Clear()

        For iYear = Now.Year - 5 To Now.Year + 5
            cmbYear.Items.Add(iYear.ToString)
        Next

        'FK_EQ("ALTER TABLE tblDays ADD DayTypeID Nvarchar (2)", "S", "", False, False, False)

        'Load Currnet Year to the Combo 
        cmbYear.Text = fk_sqlDbl("SELECT cYear FROM tblCompany WHERE compID = '" & StrCompID & "'")

        'Pop_CmbSp("SELECT DayDesc FROM tblDays Order By DayID", cmbHoliday)
        'Pop_CmbSp("SELECT DayDesc FROM tblDays Order By DayID", cmbHalfDay)
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbsDay)
        cmbsDay.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'SunDay'")
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbmDay)
        cmbmDay.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'MonDay'")
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbTuDay)
        cmbTuDay.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'Tuesday'")
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbWday)
        cmbWday.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'Wednesday'")
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbthDay)
        cmbthDay.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'Thursday'")
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbFday)
        cmbFday.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'Friday'")
        Pop_CmbSp("select TypeName from tblDayType WHERE Status = 0 Order By TypeID", cmbstDay)
        cmbstDay.Text = fk_RetString("SELECT tblDayType.TypeName FROM tblDayType INNER JOIN tblDays ON tblDayType.TypeID = tblDays.DayTypeID WHERE tblDays.DayDesc = 'Saturday'")
        'Get Years
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        If UP("Calender", "Edit day type for company") = False Then Exit Sub

        If TextBox1.Text = "" Then
            MsgBox("Please Select a Date.")
            Exit Sub
        End If
        If TxtType.Text = "" Then
            MsgBox("Please Select the Day Type")
            Exit Sub
        End If

        Dim cnUps As New SqlConnection(sqlConString)
        cnUps.Open()
        Dim cmUps As New SqlCommand
        cmUps = cnUps.CreateCommand
        Dim trUps As SqlTransaction = cnUps.BeginTransaction

        cmUps.Transaction = trUps
        Dim sqlQ As String
        Try
            sqlQ = "UPDATE tblCalendar SET dayType = '" & SelDayType & "' WHERE [Date] = '" & Format(dtSelDate, "yyyyMMdd") & "'"
            cmUps.CommandText = sqlQ
            cmUps.ExecuteNonQuery()

            sqlQ = " UPDATE tblEmpRegister SET DayTypeID = '" & SelDayType & "' WHERE atDate = '" & Format(dtSelDate, "yyyyMMdd") & "'"
            cmUps.CommandText = sqlQ
            cmUps.ExecuteNonQuery()

            'The following added by Rajitha. confirmed Kasun. update tblCalendar the relavant work unit(0.0/0.5/0.1)
            sqlQ = sqlQ & " update tblCalendar set workingType=(select WorkUnit from tblDayType where TypeName='" & TxtType.Text & "') where " & _
" tblCalendar.date='" & TextBox1.Text & "'"
            cmUps.CommandText = sqlQ
            cmUps.ExecuteNonQuery()

            trUps.Commit()
            MsgBox("Information Saved", MsgBoxStyle.Information)
            TextBox1.Text = ""
            TxtType.Text = ""

        Catch ex As Exception
            MsgBox(ex.Message)
            trUps.Rollback()
        Finally
            cnUps.Close()
        End Try

        Pop_Calendar(iCrYear, iCrMonth)
    End Sub

    Private Sub cmdSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim dtFrDate As Date : Dim dtToDate As Date
        dtFrDate = DateSerial(iCrMonth, iCrMonth, 1) : dtToDate = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, dtFrDate))
        If MsgBox("Do you want to Copy New Calendar Information for all employee for the selected month ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            Dim sqlQRY As String = ""
            sqlQRY = "update tblEmpRegister SET tblEmpRegister.DayTypeID = tblCalendar.DayType from tblEmpRegister,tblCalendar  WHERE tblEmpRegister.AtDate = tblCalendar.Date AND tblCalendar.Date Between '" & Format(dtFrDate, "yyyyMMdd") & "' AND '" & Format(dtToDate, "yyyyMMdd") & "'"
            FK_EQ(sqlQRY, "P", "", False, True, True)
        Else
            Exit Sub
        End If

    End Sub

    Private Sub chkSyncronize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSyncronize.CheckedChanged

        If chkSyncronize.Checked = True Then

            cmdSync_Click(sender, e)

        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

End Class