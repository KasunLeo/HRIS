Imports System.IO
Imports System.Data.OleDb

Public Class FrmEmployeeFromExcel

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim ExcelDataSet As System.Data.DataSet
    Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter
    Dim bolBad As Boolean = False
    Dim strEror As String = ""
    Dim iRo As Integer = 0
    Dim iCo As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        txtExcelFile.Text = ""
        Dim strPath As String = ""
        'OFD.InitialDirectory
        OFD.ShowDialog()
        strPath = OFD.FileName
        txtExcelFile.Text = strPath
        Dim FILE_NAME As String = strPath
        Dim TextLine As String = ""
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim filePath As String = FILE_NAME
            Dim connString As String = String.Empty
            If filePath.EndsWith(".xlsx") Then
                '2007 Format
                connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No'", filePath)
            Else
                '2003 Format
                connString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No'", filePath)
            End If
            Dim connExcel As New OleDbConnection(connString)
            Dim cmdExcel As New OleDbCommand()
            Dim oda As New OleDbDataAdapter()
            cmdExcel.Connection = connExcel
            connExcel.Open()
            cmbSheet.DataSource = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            cmbSheet.DisplayMember = "TABLE_NAME"
            cmbSheet.ValueMember = "TABLE_NAME"
            connExcel.Close()
        End If

    End Sub

    Private Sub FrmFromExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormThemed(Me, Panel1, Label12)
        ControlHandlers(Me)
        Button4_Click(sender, e)
    End Sub

    Private Sub cmbSheet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSheet.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim strPath = txtExcelFile.Text
        Dim FILE_NAME As String = strPath
        Dim TextLine As String = ""
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim filePath As String = FILE_NAME
            Dim connString As String = String.Empty
            If filePath.EndsWith(".xlsx") Then
                '2007 Format
                connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No'", filePath)
            Else
                '2003 Format
                connString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No'", filePath)
            End If
            Try
                ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("select * from [" & cmbSheet.Text & "]", connString)
                ' ExcelAdapter.TableMappings.Add("Table", "Excel Data")
                ExcelDataSet = New System.Data.DataSet
                ExcelAdapter.Fill(ExcelDataSet)
                dgv.DataSource = ExcelDataSet.Tables(0)
                'connString.Close()
                lblCoun.Text = "Total rows : " & dgv.RowCount

            Catch ex As Exception
                ' MessageBox.Show("Error: " + ex.ToString, "Importing Excel", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
        Me.Cursor = Cursors.Default
        'cmbIDColumn.Items.Clear()
        'cmbAmountColumn.Items.Clear()
        'For X = 0 To dgv.ColumnCount - 1
        '    cmbIDColumn.Items.Add(dgv.Columns(X).HeaderText)
        '    cmbAmountColumn.Items.Add(dgv.Columns(X).HeaderText)
        '    cmbEPFNo.Items.Add(dgv.Columns(X).HeaderText)
        '    cmbRegID1.Items.Add(dgv.Columns(X).HeaderText)
        'Next

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dgv.DataSource = Nothing
        btnSave.Enabled = False
        btnSync.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If dgv.RowCount < 1 Then MessageBox.Show("Please select excel file to import", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgv.Focus() : Exit Sub
            sSQL = ""
            Dim k As Integer = 0 : Dim l As Integer = 0
            Dim bolComplete As Boolean = True
            Dim strQ As String = ""
            With dgv
                For k = 0 To dgv.RowCount - 1
                    l = l + 1
                    strEror = "Row number : " & k + 1 & " and after this Employee ID : " & Replace(Trim(.Item(0, k).Value), "`", "") & ""
                    strQ = "SELECT RegID from tblExcelImportEmployee WHERE RegID='" & Replace(Trim(.Item(0, k).Value), "`", "") & "'"
                    If k = 0 And .Item(0, k).Value = "RegID" Then

                    ElseIf fk_CheckEx(strQ) = False Then
                        sSQL = sSQL & "INSERT INTO [tblExcelImportEmployee]  ([RegID],[EnrolNo] ,[EpfNo],[SurName],[NICNumber],[FirstName],[TitleID],[CiviStID],[GenderID], [pMobile],[EmpStatus]) VALUES " & _
                                          " ('" & Replace(Trim(.Item(0, k).Value), "`", "") & "','" & Replace(Trim(.Item(1, k).Value), "`", "") & "','" & Replace(Trim(.Item(2, k).Value), "`", "") & "','" & Trim(.Item(3, k).Value) & "','" & Trim(.Item(4, k).Value) & "','" & Trim(.Item(5, k).Value) & "','" & Replace(Trim(.Item(6, k).Value), "`", "") & "','" & Replace(Trim(.Item(7, k).Value), "`", "") & "','" & Replace(Trim(.Item(8, k).Value), "`", "") & "','" & Replace(Val(.Item(9, k).Value), "`", "") & "','" & Trim(.Item(10, k).Value) & "');"
                    End If
                    If l = 100 Then
                        If bolComplete = True And sSQL <> "" Then bolComplete = FK_EQ(sSQL, "S", "", True, True, True) : sSQL = "" : l = 0
                    End If
                Next

            End With

            If bolComplete = True And sSQL <> "" Then sSQL = sSQL & "update tblcompany SET NoEmps=" & dgv.RowCount - 1 & " WHERE compID = '" & StrCompID & "';" : FK_EQ(sSQL, "S", "", True, True, True) : btnSync.Enabled = True
            If sSQL = "" Then MessageBox.Show("There are no new data to import", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Catch ex As Exception
            strEror = " Please check  " & strEror
            MessageBox.Show(ex.Message & strEror)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            With dgv
                For Me.iCo = 0 To .ColumnCount - 1
                    For Me.iRo = 0 To .RowCount - 1
                        If .Item(iCo, iRo).Value.ToString.Length = 0 Then
                            If iCo = 4 Then .Item(iCo, iRo).Value = "0" Else .Item(iCo, iRo).Value = "0"
                        End If
                    Next
                Next
            End With
            btnSave.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & " Coloumn number: " & iCo + 1 & " Row number : " & iRo + 1)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSync.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            sSQL = "ALTER table tblemployee alter column nicnumber nvarchar (15); " & _
            "ALTER table tblemployee alter column SurName nvarchar (556); " & _
            "ALTER table tblemployee alter column FirstName nvarchar (556); " & _
            "ALTER table tblemployee alter column pMobile nvarchar (15); " & _
            "INSERT INTO tblEmployee (RegID,RegDate,TitleID, SurName,FirstName,dispName,NICNumber,dofB,GenderID,CivilStID,EmpNo,EpfNo,CompID,DesigID,BrID,DeptID,CatID,EmpTypeID,DefAddID,homePhone,pMobile,OfficePhone,Email,CntrPeriod,CardID,NoAdds,EmpStatus,NoCards,EnrolNo,AtPrType,ContractStart,ContractEnd,sub_catID,IsEmpBOT) " & _
            "select tblExcelImportEmployee.RegID,'19000101',tblExcelImportEmployee.TitleID,tblExcelImportEmployee.SurName,tblExcelImportEmployee.FirstName,'dispName',tblExcelImportEmployee.NICNumber,'19000101',tblExcelImportEmployee.GenderID,tblExcelImportEmployee.CiviStID,'-',tblExcelImportEmployee.EpfNo,'001','001','001','001','001','001','001','0',tblExcelImportEmployee.pMobile,'0','-','19000101','0','1',tblExcelImportEmployee.EmpStatus,'0',tblExcelImportEmployee.EnrolNo,'0','19000101','19000101','001','0' " & _
            "from  tblExcelImportEmployee left outer join tblEmployee on tblExcelImportEmployee.RegID=tblEmployee.RegID;"
            FK_EQ(sSQL, "S", "", True, True, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAtendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtendance.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If dgv.RowCount < 1 Then MessageBox.Show("Please select excel file to import", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dgv.Focus() : Exit Sub
            sSQL = ""
            Dim k As Integer = 0 : Dim l As Integer = 0
            Dim bolComplete As Boolean = True
            Dim strQ As String = ""
            With dgv
                For k = 0 To dgv.RowCount - 1
                    l = l + 1
                    strEror = "Row number : " & k + 1 & " and after this Employee ID : " & Replace(Trim(.Item(2, k).Value), "`", "") & ""
                    'strQ = "SELECT RegID from tblExcelImportEmployee WHERE RegID='" & Replace(Trim(.Item(0, k).Value), "`", "") & "'"
                    If k = 0 And .Item(0, k).Value = "RegID" Then

                    Else 'If fk_CheckEx(strQ) = False Then
                        sSQL = sSQL & "INSERT INTO [tblDiMachine] ([MacID],[crLine],[EmpID],[VrfyMode],[Input],[cDate],[cTime],[WrkCode],[Capture],[tTime],[EditMode])  VALUES " & _
                                          " ('" & Replace(Trim(.Item(0, k).Value), "'", "") & "','" & Replace(Trim(.Item(1, k).Value), "'", "") & "','" & Replace(Trim(.Item(2, k).Value), "`", "") & "','" & Trim(.Item(3, k).Value) & "','" & Trim(.Item(4, k).Value) & "','" & CDate(Trim(.Item(5, k).Value)) & "','" & CDate(Trim(.Item(6, k).Value)) & "','" & Replace(Trim(.Item(7, k).Value), "`", "") & "','" & Replace(Trim(.Item(8, k).Value), "`", "") & "','" & CDate(Trim(.Item(9, k).Value)) & "','" & Trim(.Item(10, k).Value) & "');"
                    End If
                    If l = 1000 Then
                        If bolComplete = True And sSQL <> "" Then bolComplete = FK_EQ(sSQL, "S", "", True, True, True) : sSQL = "" : l = 0
                    End If
                Next

            End With

            If bolComplete = True And sSQL <> "" Then sSQL = sSQL & "update tblcompany SET NoEmps=" & dgv.RowCount - 1 & " WHERE compID = '" & StrCompID & "';" : FK_EQ(sSQL, "S", "", True, True, True) : btnSync.Enabled = True
            If sSQL = "" Then MessageBox.Show("There are no new data to import", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        Catch ex As Exception
            strEror = " Please check  " & strEror
            MessageBox.Show(ex.Message & strEror)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

End Class