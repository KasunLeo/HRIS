Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI

Public Class frmEmpShift
#Region "Info"
    'Created By : Kasun
    'Create Date :


    'Modifications
    'By : Rajitha 
    'Date : 


#End Region

    Private Sub frmChangeShift_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ControlHandlers(Me)
        'CenterFormThemed(Me, Panel1, Label25)
        cmdRefresh_Click(sender, e)

        'cmdSave.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdSave.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdRefresh.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdRefresh.BackgroundImage, Me.Panel2.BackColor, 90)
        'cmdClose.BackgroundImage = ImageEffectsHelper.DrawReflection(cmdClose.BackgroundImage, Me.Panel2.BackColor, 90)
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

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'optRoster.Checked = True
        'optShift.Checked = True
        'optShift_CheckedChanged(optShift, e)
        Dim iCOl As Integer = 0
        Dim StrCol As String
        Dim StrConN As String
        Dim StrLvType As String
        'Generate Datagrid Column Structure 
        With dgvCals
            .Rows.Clear()
            .Columns.Clear()
            .Columns.Add("Mnth", "Date")
            .Columns(0).Width = 55
            .Columns(0).Frozen = True
            For iCOl = 1 To 12

                StrCol = "D" & iCOl.ToString
                StrConN = MonthName(iCOl)
                .Columns.Add(StrCol, StrConN)
                .Columns(iCOl).Width = 78

            Next

            'Add 31 Rows
            Dim IRw As Integer
            For IRw = 1 To 31
                .Rows.Add(IRw, "", "", "", "", "", "", "", "", "", "", "", "")
                '.BackgroundColor = Color.Black

            Next
            Dim iX As Integer
            Dim iY As Integer

            For iY = 0 To .RowCount - 1
                .Item(0, iY).Style.BackColor = Color.DimGray
            Next

        End With

        'Open Date Order By Month
        Dim cnLoad As New SqlConnection(sqlConString)
        cnLoad.Open()
        Dim dtDate As Date
        Dim iMonth As Integer
        Dim dtDay As Integer
        Dim intType As Integer
        Dim StrADisp As String
        Dim StrShfID As String = "999"
        Dim StrLvD As String
        Dim strRostName As String = ""

        Dim sqlQ As String = "SELECT AtDate,cMonth,AntStatus,LeaveID,DayTypeID,shiftID,AllShifts FROM tblEmpRegister WHERE EmpID = '" & StrEmployeeID & "' AND cYear = " & intCurrentYear & " AND CompID = '" & StrCompID & "' Order By DayID"
        Try
            Dim cmLoad As New SqlCommand(sqlQ, cnLoad)
            Dim drLoad As SqlDataReader = cmLoad.ExecuteReader
            Do While drLoad.Read = True
                dtDate = IIf(IsDBNull(drLoad.Item("AtDate")), DateSerial(1900, 1, 1), drLoad.Item("atDate"))
                iMonth = IIf(IsDBNull(drLoad.Item("cMonth")), DateSerial(1900, 1, 1), drLoad.Item("cMonth"))
                dtDay = CInt(Format(dtDate, "dd"))
                intType = IIf(IsDBNull(drLoad.Item("AntStatus")), DateSerial(1900, 1, 1), drLoad.Item("AntStatus"))
                StrADisp = fk_RtDayType(intType)
                StrLvType = IIf(IsDBNull(drLoad.Item("LeaveID")), "", drLoad.Item("LeaveID"))
                StrLvD = fk_RetString("SELECT LvDesc FROM tblLeaveType WHERE LvID = '" & StrLvType & "'")
                StrLvD = get_FirstLetter(StrLvD)
                StrSelDayTypeID = IIf(IsDBNull(drLoad.Item("DayTypeID")), "", drLoad.Item("DayTypeID"))

                StrShfID = IIf(IsDBNull(drLoad.Item("AllShifts")), "", drLoad.Item("AllShifts"))
                strRostName = fk_RetString("SELECT shortcode FROM tblsetShiftH WHERE SHIFTid = '" & StrShfID & "'")
                With dgvCals
                    .ForeColor = Color.Black
                    .Item(iMonth, dtDay - 1).Value = "      " & strRostName
                    Select Case StrADisp
                        Case "XX" 'No any record
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.White
                        Case "PR"
                            .Item(iMonth, dtDay - 1).Style.BackColor = clrFocused
                        Case "AB"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Red
                        Case "LV"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Green
                        Case "NP"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Orange
                        Case "ER"
                            .Item(iMonth, dtDay - 1).Style.BackColor = Color.Blue
                    End Select

                End With
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnLoad.Close()
        End Try


    End Sub

    Public Function fk_RtDayType(ByVal StrT As Double) As String
        Dim StrR As String
        Select Case StrT
            Case 0 ' Not Updated
                StrR = "XX"
            Case 1 'Mark Present
                StrR = "PR"
            Case 2 'Absent
                StrR = "AB"
            Case 3 'Process Leave
                StrR = "LV"
            Case 4 '
                StrR = "NP"
            Case Else 'if not all above
                StrR = "ER"
        End Select
        Return StrR

    End Function

    Private Sub dgvCals_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCals.CellDoubleClick

        Dim iDay As Integer
        Dim iMonth As Integer
        Dim iYear As Integer = intCurrentYear
        Dim dtSelDate As Date
        With dgvCals
            iDay = CInt(.Item(0, .CurrentRow.Index).Value)
            iMonth = .CurrentCell.ColumnIndex
            dtSelDate = DateSerial(iYear, iMonth, iDay)


        End With

        StrSelDayTypeID = fk_RetString("SELECT DayTypeID FROM tblEmpRegister WHERE AtDate = '" & Format(dtSelDate, "yyyyMMdd") & "'")

        'Dim frmSS As New frmSelShift
        'frmSS.ShowDialog()

        Dim cnSave As New SqlConnection(sqlConString)
        cnSave.Open()
        Dim cmSave As New SqlCommand
        cmSave = cnSave.CreateCommand
        Dim trSave As SqlTransaction = cnSave.BeginTransaction
        cmSave.Transaction = trSave
        Dim sqlQRY As String
        Try
            sqlQRY = "UPDATE tblEmpRegister SET ShiftID = '" & StrSelectShift & "',DayTypeID = '" & StrSelDayTypeID & "' WHERE EmpID = '" & StrEmployeeID & "' AND atDate = '" & Format(dtSelDate, "yyyyMMdd") & "'" & _
            " UPDATE tblEmpRegister SET tblEmpRegister.sInTime = tblSetShiftH.InTime,tblEmpRegister.sOutTime = tblSetShiftH.OutTime FROM tblSetShiftH INNER JOIN tblEmpRegister ON tblEmpRegister.ShiftID = tblSetShiftH.ShiftID WHERE tblEmpRegister.EmpID = '" & StrEmployeeID & "' AND tblEmpRegister.AtDate = '" & Format(dtSelDate, "yyyyMMdd") & "'"

            cmSave.CommandText = sqlQRY
            cmSave.ExecuteNonQuery()
            trSave.Commit()
            cmdRefresh_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message)
            trSave.Rollback()
        Finally
            cnSave.Close()
        End Try

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub

End Class