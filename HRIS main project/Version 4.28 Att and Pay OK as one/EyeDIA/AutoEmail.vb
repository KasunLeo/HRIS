Imports System.Net.Mail
Imports Microsoft.Office.Interop

Public Class AutoEmail

    Dim strAttachment As String
    Dim strComName As String
    Dim strComAddres As String
    Dim StrSubHead As String = "Absent Report -Auto generated"
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click
        ' ''Try

        'Try
        '    Dim Mail As New MailMessage
        '    Mail.Subject = "Subject"
        '    Mail.To.Add("rhlakshika1@gmail.com") 'Replace here
        '    Mail.From = New MailAddress("kasunsliate1@gmail.com")
        '    Mail.Body = "Hello"

        '    Dim SMTP As New SmtpClient("smtp.gmail.com") 'server of GMAIL
        '    SMTP.DeliveryMethod = SmtpDeliveryMethod.Network
        '    SMTP.UseDefaultCredentials = False
        '    SMTP.EnableSsl = True
        '    SMTP.Credentials = New System.Net.NetworkCredential("kasunsliate1@gmail.com", "kasunLuckTest") 'replace here
        '    SMTP.Port = 587 'port GMAIL
        '    SMTP.Send(Mail)
        '    MsgBox("Message has been sent with sucess", vbOKOnly + vbInformation, "Sent") 'Finally show a MessageBox

        'Catch ex As Exception
        '    MsgBox(ex.Message, vbOK + vbCritical, "Error")
        'End Try
        Try
            'ALTER TABLE tblCompany ADD automaticEmail NVARCHAR (256) NOT NULL DEFAULT 'rhlakshika1@gmail.com;signhrteam@gmail.com'
            Dim smtpServer As New SmtpClient()
            Dim mail As New MailMessage
            smtpServer.Credentials = New Net.NetworkCredential(txtFrom.Text & "@gmail.com", txtPasword.Text)
            smtpServer.Port = 587
            smtpServer.Host = "smtp.gmail.com"
            smtpServer.EnableSsl = True
            mail.From = New MailAddress(txtFrom.Text & "@gmail.com")
            'If RadioButton1.Checked = True Then
            '    mail.To.Add("94" & TextBox3.Text & "@m3m.in")
            'ElseIf RadioButton2.Checked = True Then
            mail.To.Add(txtTO.Text)
            'End If
            mail.Subject = txtSubject.Text
            mail.Body = txtMessage.Text()
            'ADD AN ATTACHMENT.
            strAttachment = txtFile.Text
            If strAttachment <> "" Then
                Dim oAttch As Attachment = New Attachment(strAttachment, "")
                mail.Attachments.Add(oAttch)
            End If

            smtpServer.Send(mail)
            MsgBox("mail is sent", MsgBoxStyle.OkOnly, "Report")

            sSQL = "Update tblCompany SET lastEmail='" & txtFrom.Text & "' WHERE compid='" & StrCompID & "'"
            FK_EQ(sSQL, "E", "", False, False, False)

            txtFile.Text = ""
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub AutoEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel3, lblSetReligion)
        ControlHandlers(Me)
        cmdRefresh_Click(sender, e)
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        txtFrom.Text = fk_RetString("SELECT lastEmail FROM tblCompany WHERE compid='" & StrCompID & "'")
        txtSubject.Text = "Roster Information Report"
        txtMessage.Text = " .....................   HR Manager"
        Dim strEmpIDs As String = ""
        FK_ReadDB("SELECT automaticEmail FROM tblcompany")
        'For i As Integer = 0 To frmMainAttendance.dgvFillGridforRead.RowCount - 1
        '    strEmpIDs = strEmpIDs + "," + IIf(IsDBNull(frmMainAttendance.dgvFillGridforRead.Item(0, i).Value), "", frmMainAttendance.dgvFillGridforRead.Item(0, i).Value)
        'Next
        strEmpIDs = "rhlakshika1@gmail.com,signhrteam@gmail.com" 'fk_RetString("SELECT automaticEmail FROM tblcompany where compID='" & StrCompID & "'")
        txtTO.Text = strEmpIDs
        txtPasword.Text = "kasunLuckTest" 'fk_RetString("Select EmailPassword FROM tblcompany where compID='" & StrCompID & "'")

        Dim dtLastDate As Date = fk_RetDate("SELECT AtnPrcDate FROM tblCompany WHERE CompID = '" & StrCompID & "'")
        sSQL = "CREATE TABLE #T (regID nvarchar (6),empNO NVARCHAR (6),atDate DATETIME,DispName NVARCHAR (156),department nvarchar (156),desig NVARCHAR (6)) " &
" INSERT INTO #T SELECT tblEmpregister.empID,tblEmployee.empNo,tblEmpregister.atDate,tblEmployee.dispName,tblEmployee.deptID,tblEmployee.desigID FROM tblEmpregister,tblEmployee WHERE tblEmpregister.empID=tblEmployee.regID AND tblEmployee.empStatus <> 9  AND tblempregister.ANTStatus=0 AND tblemployee.deptID in ('" & StrUserLvDept & "') AND tblemployee.brID IN ('" & StrUserLvBranch & "') AND tblempregister.atDate ='" & Format(dtLastDate, "yyyyMMdd") & "' ORDER BY " & sqlTag1 & " SELECT * FROM #T "
        Fk_FillGrid(sSQL, DataGridView1)

        lblCount.Text = "Total records in auto generated excel : " & DataGridView1.RowCount

        ''Get company name and address
        'sSQL = "SELECT cName,Add1 + ' ' +Add2 + ' ' + Add3 FROM tblcompany"
        'fk_Return_MultyString(sSQL, 2)
        'strComName = fk_ReadGRID(0)
        'strComAddres = fk_ReadGRID(1)
        'Try

        '    'verfying the datagridview having data or not
        '    If ((DataGridView1.Columns.Count = 0) Or (DataGridView1.Rows.Count = 0)) Then
        '        Exit Sub
        '    End If

        '    'Creating dataset to export
        '    Dim dset As New DataSet
        '    'add table to dataset
        '    dset.Tables.Add()
        '    'add column to that table
        '    For i As Integer = 0 To DataGridView1.ColumnCount - 1
        '        dset.Tables(0).Columns.Add(DataGridView1.Columns(i).HeaderText)
        '    Next
        '    'add rows to the table
        '    Dim dr1 As DataRow
        '    For i As Integer = 0 To DataGridView1.RowCount - 1
        '        dr1 = dset.Tables(0).NewRow
        '        For j As Integer = 0 To DataGridView1.Columns.Count - 1
        '            dr1(j) = DataGridView1.Rows(i).Cells(j).Value
        '        Next
        '        dset.Tables(0).Rows.Add(dr1)
        '    Next

        '    Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
        '    Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        '    Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        '    wBook = excel.Workbooks.Add()
        '    wSheet = wBook.ActiveSheet()

        '    Dim dt As System.Data.DataTable = dset.Tables(0)
        '    Dim dc As System.Data.DataColumn
        '    Dim dr As System.Data.DataRow
        '    Dim colIndex As Integer = 0
        '    Dim rowIndex As Integer = 0

        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        excel.Cells(1, colIndex) = dc.ColumnName
        '    Next

        '    For Each dr In dt.Rows
        '        rowIndex = rowIndex + 1
        '        colIndex = 0
        '        For Each dc In dt.Columns
        '            colIndex = colIndex + 1
        '            excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

        '        Next
        '    Next

        '    wSheet.Rows("1:1").Font.FontStyle = "Bold"
        '    wSheet.Rows("1:1").Font.Size = 10
        '    wSheet.Cells.Columns.AutoFit()
        '    wSheet.Cells.Select()
        '    wSheet.Cells.EntireColumn.AutoFit()
        '    wSheet.Cells(1, 1).Select()

        '    'Insert Sub Header 


        '    If strAddress <> "" Then
        '        .Range("1:1").Insert(Shift:=excel.XlDirection.xlDown)
        '        .Range("A1").Value = strAddress
        '        .Rows("1:1").Font.FontStyle = "Bold"
        '        .Rows("1:1").Font.Size = 12
        '    End If

        '    If StrMainHead <> "" Then
        '        .Range("1:1").Insert(Shift:=excel.XlDirection.xlDown)
        '        .Range("A1").Value = StrMainHead
        '        .Rows("1:1").Font.FontStyle = "Bold"
        '        .Rows("1:1").Font.Size = 14
        '    End If

        '    wSheet.Columns.AutoFit()

        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        Try
            Dim excelBook As Microsoft.Office.Interop.Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Microsoft.Office.Interop.Excel.Worksheet = CType(excelBook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)
            'xlApp.Visible = True
            rowsTotal = DataGridView1.RowCount - 1
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()

                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText.ToUpper
                Next
                For I = 0 To rowsTotal
                    For X As Integer = 1 To 6
                        .Cells(I + 2, X).NumberFormat = "@"
                    Next
                    For j = 0 To colsTotal
                        '.Cells(I + 2, 1).NumberFormat = "@"
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value
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

                If strComAddres <> "" Then
                    .Range("1:1").Insert(Shift:=Excel.XlDirection.xlDown)
                    .Range("A1").Value = strComAddres
                    .Rows("1:1").Font.FontStyle = "Bold"
                    .Rows("1:1").Font.Size = 12
                End If

                If strComName <> "" Then
                    .Range("1:1").Insert(Shift:=Excel.XlDirection.xlDown)
                    .Range("A1").Value = strColorName
                    .Rows("1:1").Font.FontStyle = "Bold"
                    .Rows("1:1").Font.Size = 14
                End If

                'Range(excelSheet.Cells(1, 1),excelSheet.Cells(1, 10)).Merge

                'MsgBox("Exported Successfully", MsgBoxStyle.Information)
            End With

            Dim strFileName As String

            strFileName = Application.StartupPath & "\Auto Email\AbsentReport" & Format(Now.Date + Now.TimeOfDay, "Mddyyyy hmmss tt") & ".xls"

            excelBook.SaveAs(strFileName)
            'excel.Workbooks.Open(strFileName)
            'excel.Visible = True
            excelBook.Close()

            txtFile.Text = strFileName
            If txtTO.Text <> "" And txtPasword.Text <> "" Then
                cmdSave_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox("Export Excel Error " & ex.Message)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try


    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        'ofdAttach.ShowDialog()
        If ofdAttach.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFile.Text = ofdAttach.FileName
            strAttachment = txtFile.Text
        End If

    End Sub

    Private Sub txtSubject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSubject.Click
        txtSubject.Text = ""
    End Sub

End Class