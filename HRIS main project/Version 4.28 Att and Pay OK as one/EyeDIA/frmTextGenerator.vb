Imports System.IO
Imports System.Data.SqlClient

Public Class frmTextGenerator

    Dim StrFileSavePath As String = ""
    Public bolRemoteConnection As Boolean = False
    Dim strAllBranchs As String = ""

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub Generete_TextFile()
        Dim sqlQRY As String = ""
        If MsgBox("Do you want process text files ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub

        sqlQRY = "SELECT tblDiMachine.MacID,3,tblNumberLink.LinkNo,1,tblDiMachine.cDate,tblDiMachine.cTime FROM tblDiMachine,tblNumberLink WHERE tblDiMachine.EmpID = tblNumberLink.OrigNo AND tblDiMachine.cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"
        Load_InformationtoGrid(sqlQRY, dgvData, 6)

        Dim strTxtName As String = dtWorkingDate
        strTxtName = Replace(dtWorkingDate, "/", "")
        Dim strTimeText As String = fk_RetString("select GetDate()")
        strTimeText = Replace(strTimeText, ":", "")
        strTxtName = Replace(strTxtName, " ", "")
        strTxtName = Replace(strTxtName, ":", "")
        StrFileSavePath = Application.StartupPath & "\" & strTxtName & ".TXT"

        Process_ToText(StrFileSavePath)
    End Sub

    Public Sub generate_TextFileZK()
        ' MessageBox.Show("fum in 1")
        lblLast.Text = ""
        strAllBranchs = fk_getGridCLICK(dgvBranches, 0, 1)
        strAllBranchs = fk_SplitToSQL_in(strAllBranchs)
        Dim sqlQRY As String = ""
        If MsgBox("Do you want process Data  ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub


        'sqlQRY = "SELECT tblDiMachine.MacID,3,tblNumberLink.LinkNo,1,tblDiMachine.cDate,tblDiMachine.cTime FROM tblDiMachine,tblNumberLink WHERE tblDiMachine.EmpID = tblNumberLink.OrigNo AND tblDiMachine.cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"

        'MessageBox.Show("DGV data lod")
        If StrLocationID = "" Or StrLocationID = 0 Then MessageBox.Show("Please select correct location ID", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : Exit Sub
        'use dimachine Data
        'sqlQRY = "SELECT tblDiMachine.MacID, tblDiMachine.EmpID,tblDiMachine.cDate,tblDiMachine.cTime,1,0,1,0 FROM tblDIMachine WHERE cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"
        sqlQRY = "SELECT tblDiMachine.MacID, tblDiMachine.EmpID,tblDiMachine.cDate,tblDiMachine.cTime,tbldimachine.vrfymode,0,1,0 FROM tblDIMachine LEFT OUTER JOIN tblEmployee ON tblEmployee.enrolNo=tblDiMachine.EmpID  WHERE  tblDIMachine.cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "' and tblDiMachine.macID='" & StrLocationID & "' AND tblEmployee.BrID In ('" & strAllBranchs & "') "

        Load_InformationtoGrid(sqlQRY, dgvData, 8)
        lblLast.Text = "Records count :" & dgvData.RowCount
        ''use alldaown data
        'sqlQRY = "SELECT tblallDownData.EmpID,tblallDownData.cDate,tblallDownData.cTime,1,0,1,0 FROM tblDIMachine WHERE cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"
        'Load_InformationtoGrid(sqlQRY, dgvData, 7)


        'MessageBox.Show("dgv LOAD Cmpt")

        Dim strTxtName As String = ""
        strTxtName = "Punched_Records" & Format(Now, "ddMMyyyy hhmmsstt") & ".txt"
        'Dim strTimeText As String = fk_RetString("select GetDate()")
        'strTimeText = Replace(strTimeText, ":", "")
        strTxtName = Replace(strTxtName, " ", "")
        strTxtName = Replace(strTxtName, ":", "")
        StrFileSavePath = Application.StartupPath & "\Text_File\" & strTxtName & ".TXT"

        Process_ToTextZK(StrFileSavePath)

        Dim sqlTable As String

        'sqlTable = "CREATE TABLE tblDownData (EmpNo VARCHAR(6), Ctime DATETIME, Data1 VARCHAR(20),Data2 VARCHAR(20),Data3 VARCHAR(20),Data4 VARCHAR(20))"
        'FK_EQ(sqlTable, "S", "", False, False, False)

        'data Tranfer Ready Table
        'sqlTable = "CREATE TABLE tblTransferData (MacID nvarchar(3) NULL,crLine numeric(18, 0) NULL,EmpID nvarchar(6) NULL," & _
        '            "VrfyMode nvarchar (10) NULL, Input nvarchar(10) NULL,cDate datetime NULL, " & _
        '            "cTime datetime NULL,WrkCode nvarchar(10) NULL,Capture numeric(18, 0) NOT NULL DEFAULT ((0)), " & _
        '            "EditMode numeric(18, 0) NOT NULL DEFAULT ((0)),tTime datetime NOT NULL DEFAULT (''), TraStatus numeric(18,0) )"
        'FK_EQ(sqlTable, "S", "", False, False, False)

        'sqlTable = "create table tblRemoteContral (TagID Numeric (18,0) , LTransferDate datetime,LDowndate datetime)"
        'FK_EQ(sqlTable, "S", "", False, False, False)
        ' Dim constring As String = "Server=PROCAT\SQLEXPRESS;Database=Rashika;User Id=sa;Password=HRIS@1212"

        

        'MessageBox.Show("Wile rum try")

        'While (x <= i - 1)
        '    sql = "Insert into tblDownData values('" & Me.dgvData.Item(0, x).Value & "','" & Me.dgvData.Item(1, x).Value & "','" & Me.dgvData.Item(2, x).Value & "','" & Me.dgvData.Item(3, x).Value & "','" & Me.dgvData.Item(4, x).Value & "','" & Me.dgvData.Item(5, x).Value & "')"
        '    cmd = New SqlCommand(sql, con)
        '    cmd.ExecuteNonQuery()
        '    x = x + 1
        'End While

        'MessageBox.Show("While end")


        'MsgBox("Data save DB complete", MsgBoxStyle.Information, MessageBoxButtons.OK)
        'con.Close()






    End Sub


    Private Sub frmTextGenerator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label13)
        ControlHandlers(Me)
        sSQL = " SELECT atnPrcDate FROM tblCompany"
        dtpFrDate.Value = (fk_RetDate(sSQL))
        dtpEndDate.Value = dtpFrDate.Value
        dtpFrDate.MaxDate = dtpFrDate.Value.Date
        dtpEndDate.MaxDate = dtpFrDate.Value.Date
        'cmdSave.Enabled = False
        rdDefault.Checked = True
        sSQL = "SELECT 'True',brID,brName FROM tblcbranchs WHERE Status = 0 AND compID = '" & StrCompID & "' and brid <> '999' Order By BrID"
        Load_InformationtoGrid(sSQL, dgvBranches, 3)
    End Sub

    Public Sub Process_ToTextZK(ByVal sPath As String)
        Dim StrEmployeeID As String : Dim strFiller1 As String : Dim StrFiller2 As String
        Dim dtpWorkDate As Date : Dim dtpWorkTime As Date
        Dim StrWorkDate As String : Dim StrWorkTime As String
        Dim StrDeviceID As String : Dim StrVerifeMode As String

        Try
            Dim writeFile As System.IO.TextWriter = New StreamWriter(sPath)

            With dgvData
                pgb.Minimum = 0 : pgb.Maximum = .RowCount
                Dim strFirstZero As String = "0" : Dim strSecondZero As String = "0" : Dim strSpace As String = ""
                ' Text file Generare for K14 Format 
                If rdbK14.Checked = True Then
                    For i As Integer = 0 To .RowCount - 1
                        pgb.Value = i
                        StrDeviceID = Replace(.Item(0, i).Value, "0", "")
                        'StrDeviceID = StrDeviceID.PadLeft(5, " ")
                        StrEmployeeID = .Item(1, i).Value
                        StrEmployeeID = StrEmployeeID.PadLeft(8, " ")
                        'strSpace = strSpace.PadLeft(5, " ")
                        dtpWorkDate = .Item(2, i).Value
                        dtpWorkTime = .Item(3, i).Value
                        StrWorkDate = Format(dtpWorkDate, "yyyy-MM-dd")
                        StrWorkTime = Format(dtpWorkTime, "HH:mm:ss")
                        StrVerifeMode = .Item(4, i).Value
                        'StrVerifeMode = StrVerifeMode.PadLeft(7, " ")
                        'strFirstZero = strFirstZero.PadLeft(7, " ")
                        'strSecondZero = strSecondZero.PadLeft(7, " ")

                        ' writeFile.WriteLine("" & StrEmployeeID & "	" & StrWorkDate & " " & StrWorkTime & "	  " & "0" & "   " & "1" & "   " & "0" & "   " & "1")

                        writeFile.WriteLine("" & StrEmployeeID & vbTab & StrWorkDate & " " & StrWorkTime & vbTab & StrDeviceID & vbTab & strFirstZero & vbTab & StrVerifeMode & vbTab & strSecondZero)

                    Next

                ElseIf rdbHRIS.Checked = True Then
                    ' Test File Generate For Datamantion Format
                    pgb.Minimum = 0 : pgb.Maximum = .RowCount
                    For i As Integer = 0 To .RowCount - 1
                        pgb.Value = i
                        StrEmployeeID = .Item(1, i).Value

                        dtpWorkDate = .Item(2, i).Value
                        dtpWorkTime = .Item(3, i).Value
                        StrWorkDate = Format(dtpWorkDate, "yyyyMMdd")
                        StrWorkTime = Format(dtpWorkTime, "HHmm00")

                        writeFile.WriteLine("" & StrEmployeeID & "	" & StrWorkDate & "     " & "FS" & "     " & StrWorkTime & "	  " & "1" & "")
                    Next

                ElseIf rdDefault.Checked = True Then
                    pgb.Minimum = 0 : pgb.Maximum = .RowCount
                    For i As Integer = 0 To .RowCount - 1
                        pgb.Value = i
                        StrDeviceID = .Item(0, i).Value
                        StrEmployeeID = .Item(1, i).Value

                        Dim StrEmployeeID_CAST As String = Strings.Right("00000" & StrEmployeeID.ToString(), 5)

                        dtpWorkDate = .Item(2, i).Value
                        dtpWorkTime = .Item(3, i).Value
                        StrWorkDate = Format(dtpWorkDate, "dd/MM/yyyy")
                        StrWorkTime = Format(dtpWorkTime, "HH:mm:ss")

                        ' writeFile.WriteLine("" & StrEmployeeID & "	" & StrWorkDate & " " & StrWorkTime & "	  " & "0" & "   " & "1" & "   " & "0" & "   " & "1")

                        writeFile.WriteLine(StrEmployeeID_CAST & "," & StrWorkDate & "," & StrWorkTime & "")

                    Next
                End If
                pgb.Value = pgb.Maximum

                writeFile.Flush()
                writeFile.Close()
                writeFile = Nothing
                MsgBox("File Created", MsgBoxStyle.Information)

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub generate_AttenData()
        Dim constring As String = "Server=PROCAT-PC\SQLEXPRESS;Database=Rashika;User Id=sa;Password=HRIS@1212"


        Dim con As New SqlConnection(constring)

        con.Open()
        Dim i As Integer
        Dim x As Integer = 0
        Dim sql As String

        Dim cmd As New SqlCommand
        i = Me.dgvData.Rows.Count
        While (x <= i - 1)
            sql = "Insert into tblDownData values('" & Me.dgvData.Item(0, x).Value & "','" & Me.dgvData.Item(1, x).Value & "','" & Me.dgvData.Item(2, x).Value & "','" & Me.dgvData.Item(3, x).Value & "','" & Me.dgvData.Item(4, x).Value & "','" & Me.dgvData.Item(5, x).Value & "')"
            cmd = New SqlCommand(sql, con)
            cmd.ExecuteNonQuery()
            x = x + 1
        End While
        MsgBox("Data save DB complete", MsgBoxStyle.Information, MessageBoxButtons.OK)
        con.Close()
    End Sub


    Public Sub Process_ToText(ByVal sPath As String)
        Dim StrMachineID As String : Dim StrEmployeeID As String : Dim strFiller1 As String : Dim StrFiller2 As String
        Dim dtpWorkDate As Date : Dim dtpWorkTime As Date
        Dim StrWorkDate As String : Dim StrWorkTime As String

        Try
            Dim writeFile As System.IO.TextWriter = New StreamWriter(sPath)

            With dgvData
                pgb.Minimum = 0 : pgb.Maximum = .RowCount

                For i As Integer = 0 To .RowCount - 1
                    pgb.Value = i
                    StrMachineID = .Item(0, i).Value
                    strFiller1 = .Item(1, i).Value
                    StrEmployeeID = fk_CreateSerial(5, CInt(.Item(2, i).Value))
                    StrFiller2 = .Item(3, i).Value
                    dtpWorkDate = .Item(4, i).Value
                    dtpWorkTime = .Item(5, i).Value
                    StrWorkDate = Format(dtpWorkDate, "MM/dd/yyyy")
                    StrWorkTime = Format(dtpWorkTime, "HH:mm:ss")
                    writeFile.WriteLine("" & StrMachineID & "," & strFiller1 & ":" & StrEmployeeID & "," & StrFiller2 & "," & StrWorkDate & "," & StrWorkTime)
                Next

                writeFile.Flush()
                writeFile.Close()
                writeFile = Nothing
                MsgBox("File Created", MsgBoxStyle.Information)

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim sqlQRY As String = ""
        If MsgBox("Do you want process Data  ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub


        'sqlQRY = "SELECT tblDiMachine.MacID,3,tblNumberLink.LinkNo,1,tblDiMachine.cDate,tblDiMachine.cTime FROM tblDiMachine,tblNumberLink WHERE tblDiMachine.EmpID = tblNumberLink.OrigNo AND tblDiMachine.cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"

        MessageBox.Show("DGV data lod")

        'use dimachine Data
        'sqlQRY = "SELECT tblDiMachine.EmpID,tblDiMachine.cDate,tblDiMachine.cTime,1,0,1,0 FROM tblDIMachine WHERE cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"
        'Load_InformationtoGrid(sqlQRY, dgvData, 7)

        ''use alldaown data
        'sqlQRY = "SELECT tblallDownData.EmpID,tblallDownData.cDate,tblallDownData.cTime,1,0,1,0 FROM tblDIMachine WHERE cDate between '" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'"
        'Load_InformationtoGrid(sqlQRY, dgvData, 7)


        MessageBox.Show("dgv LOAD Cmpt")



        Dim sqlTable As String

        'sqlTable = "CREATE TABLE tblDownData (EmpNo VARCHAR(6), Ctime DATETIME, Data1 VARCHAR(20),Data2 VARCHAR(20),Data3 VARCHAR(20),Data4 VARCHAR(20))"
        'FK_EQ(sqlTable, "S", "", False, False, False)

        'data Tranfer Ready Table
        'sqlTable = "CREATE TABLE tblTransferData (MacID nvarchar(3) NULL,crLine numeric(18, 0) NULL,EmpID nvarchar(6) NULL," & _
        '            "VrfyMode nvarchar (10) NULL, Input nvarchar(10) NULL,cDate datetime NULL, " & _
        '            "cTime datetime NULL,WrkCode nvarchar(10) NULL,Capture numeric(18, 0) NOT NULL DEFAULT ((0)), " & _
        '            "EditMode numeric(18, 0) NOT NULL DEFAULT ((0)),tTime datetime NOT NULL DEFAULT (''), TraStatus numeric(18,0) )"
        'FK_EQ(sqlTable, "S", "", False, False, False)

        'sqlTable = "create table tblRemoteContral (TagID Numeric (18,0) , LTransferDate datetime,LDowndate datetime)"
        'FK_EQ(sqlTable, "S", "", False, False, False)
        '' Dim constring As String = "Server=PROCAT\SQLEXPRESS;Database=Rashika;User Id=sa;Password=HRIS@1212"

        Dim sql As String
        Dim cmd As New SqlCommand
        Dim con As New SqlConnection(sqlConString)

        con.Open()

        sql = "insert into tblTransferData (MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode,Capture," & _
                  "EditMode,tTime)select MacID,crLine,EmpID,VrfyMode,Input,cDate,cTime,WrkCode,Capture, " & _
                  "EditMode,tTime  from tbldimachine,tblRemoteContral where tbldimachine.cDate between " & _
                  "'" & Format(dtpFrDate.Value, "yyyyMMdd") & "' AND '" & Format(dtpEndDate.Value, "yyyyMMdd") & "'" & _
                    " order by tbldimachine.cdate"
        cmd = New SqlCommand(sql, con)
        cmd.ExecuteNonQuery()


        MsgBox("Data save DB complete", MsgBoxStyle.Information, MessageBoxButtons.OK)
        con.Close()

    End Sub


    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For i As Integer = 0 To dgvBranches.RowCount - 1
            dgvBranches.Item(0, i).Value = chkAll.CheckState
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        generate_TextFileZK()

        'Generate_TOTable(dtpFrDate.Value, dtpEndDate.Value
    End Sub

End Class