Imports System.Data
Imports System.Data.SqlClient

Module mod_ETConfig

    Public StrETConnectionString As String = ""
    Public cnETSQLConn As New SqlConnection

    Public StrDest_Table As String = "" : Public StrSour_Table As String = "" : Public StrDest_QRY As String = "" : Public StrSour_QRY As String = ""

    'Return String From Master Table 
    Public Function fk_GetETString(ByVal sqlSTR As String) As String
        Dim cnRetStr As New SqlConnection(StrETConnectionString)
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

    Public Function fk_GridDataToString(ByVal dgv As DataGridView, ByVal StrTable As String, ByVal pgb As ProgressBar) As String

        pgb.Minimum = 0
        pgb.Value = 0
        Dim sqlQRY As String = ""
        Dim StrColVal As String = ""
        With dgv
            pgb.Maximum = .RowCount
            For iRow As Integer = 0 To .RowCount - 2
                For iCol As Integer = 0 To .ColumnCount - 1
                    If iCol = 0 Then
                        StrColVal = "'" & .Item(iCol, iRow).Value & "'"
                    Else
                        StrColVal = StrColVal & "," & "'" & .Item(iCol, iRow).Value & "'"
                    End If

                Next
                Dim iInsert As Integer = 0
                pgb.Value = iRow
                sqlQRY = sqlQRY & " INSERT INTO " & StrTable & " VALUES (" & StrColVal & ")"
                iInsert = iRow Mod 100
                If iInsert = 0 Then
                    FK_EQ(sqlQRY, "S", "", False, False, True)
                    sqlQRY = ""
                End If
                'MsgBox(iRow)
                'FK_EQ(sqlQRY, "S", "", False, False, True)
            Next
        End With

        Return sqlQRY
    End Function

    'Gridwith DataSet 
    Public Sub FK_ETLoadGridWithDS(ByVal sqlString As String, ByVal dgv As DataGridView)
        Dim CN As New SqlConnection(StrETConnectionString)
        Try
            CN.Open()
            Dim ADP As New SqlDataAdapter
            Dim sTable As New DataSet
            ADP = New SqlDataAdapter(sqlString, CN)
            ADP.Fill(sTable)
            dgv.DataSource = sTable.Tables(0)
            For X As Integer = 0 To dgv.ColumnCount - 1
                dgv.Columns(X).Width = 150
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'Bulk Copy Procedure 


    Public Sub Bulk_Copy(ByVal strSourceTable As String, ByVal StrDestTable As String, ByVal sqlSourceQRY As String, ByVal sqlDestQRY As String, ByVal StrWhereClose As String, ByVal StrSumQRY As String, ByVal dtFrDate As Date, ByVal dtpToDate As Date, ByVal isBulkCopy As Integer, ByVal dgv As DataGridView, ByVal pgb As ProgressBar)
        Dim StrFromDate As String = ""
        Dim StrToDate As String = ""

        Dim sqlQRY As String = ""
        sqlQRY = "DELETE FROM " & StrDestTable

        StrFromDate = Format(dtFrDate, "yyyyMMdd")
        StrToDate = Format(dtpToDate, "yyyyMMdd")

        sqlSourceQRY = Replace(sqlSourceQRY, "`", "'")
        sqlSourceQRY = Replace(sqlSourceQRY, "@stDate", " '" & StrFromDate & "'  ")
        sqlSourceQRY = Replace(sqlSourceQRY, "@edDate", " '" & StrToDate & "'  ")

        sqlDestQRY = Replace(sqlDestQRY, "`", "'")
        sqlDestQRY = Replace(sqlDestQRY, "@stDate", " '" & StrFromDate & "'  ")
        sqlDestQRY = Replace(sqlDestQRY, "@edDate", " '" & StrToDate & "'  ")

        StrWhereClose = Replace(StrWhereClose, "`", "'")
        StrWhereClose = Replace(StrWhereClose, "@stDate", " '" & StrFromDate & "'  ")
        StrWhereClose = Replace(StrWhereClose, "@edDate", " '" & StrToDate & "'  ")

        sqlDestQRY = sqlDestQRY & " " & StrWhereClose
        sqlQRY = sqlQRY & " " & StrWhereClose
        FK_EQ(sqlQRY, "D", "", False, False, True)


        Dim connectionString As String = StrETConnectionString

        ' Open a connection to the AdventureWorks database.
        If isBulkCopy = 1 Then
            Try
                Using sourceConnection As SqlConnection =
              New SqlConnection(connectionString)
                    sourceConnection.Open()
                    Dim sqlGetData As String = ""
                    sqlGetData = sqlDestQRY
                    Dim commandSourceData As SqlCommand = New SqlCommand(
                       sqlGetData, sourceConnection)
                    Dim reader As SqlDataReader = commandSourceData.ExecuteReader

                    ' Open the destination connection. In the real world you would 
                    ' not use SqlBulkCopy to move data from one table to the other   
                    ' in the same database. This is for demonstration purposes only.
                    Using destinationConnection As SqlConnection =
                        New SqlConnection(sqlConString)
                        destinationConnection.Open()

                        ' Set up the bulk copy object. 
                        ' The column positions in the source data reader 
                        ' match the column positions in the destination table, 
                        ' so there is no need to map columns.
                        Using bulkCopy As SqlBulkCopy =
                          New SqlBulkCopy(destinationConnection)
                            bulkCopy.DestinationTableName =
                            StrDestTable

                            ' Set the BatchSize.
                            bulkCopy.BatchSize = 5000
                            Try
                                ' Write from the source to the destination.
                                bulkCopy.WriteToServer(reader)
                                MsgBox("Data Tranfered ")
                            Catch ex As Exception
                                MsgBox(ex.Message)

                            Finally
                                ' Close the SqlDataReader. The SqlBulkCopy
                                ' object is automatically closed at the end
                                ' of the Using block.
                                reader.Close()

                            End Try
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            FK_ETLoadGridWithDS(sqlDestQRY, dgv)
            Dim s As String = ""
            s = fk_GridDataToString(dgv, StrDestTable, pgb)
            sqlQRY = s
            sqlQRY = sqlQRY & StrSumQRY
            FK_EQ(sqlQRY, "S", "", False, True, True)

        End If

    End Sub

    'Get Selected Qery to Parameters
    Public Function fk_ReturnQRY(ByVal StrCode As String) As Boolean
        Dim sqlQRY As String = "SELECT hDesc,s_Table ,d_Table,s_QRY,d_QRY,WhereClose,SummaryQRY FROM tblImportHead WHERE hID = '" & StrCode & "'"
        fk_Return_MultyString(sqlQRY, 7)
        StrSour_Table = fk_ReadGRID(1)
        StrSour_Table = fk_ReadGRID(2)
        StrSour_QRY = Replace(fk_ReadGRID(3), "`", "'")
        StrDest_QRY = Replace(fk_ReadGRID(4), "`", "'")

    End Function

    Public Function fk_OpenDbSettings(ByVal a As Integer) As Boolean
        Dim StrSVR As String = ""
        Dim StrPW As String = ""
        Dim StrUN As String = ""
        Dim StrDB As String = ""

        StrSVR = ReadKey("HRTime\ETCSQLServer")
        StrDB = ReadKey("HRTime\ETCSQLDatabase")
        StrUN = ReadKey("HRTime\ETCUserName")
        StrPW = ReadKey("HRTime\ETCPassword")
        If StrSVR = "" Or StrPW = "" Or StrUN = "" Or StrDB = "" Then
            LoadForm(New frmDBConfig)
        End If


        StrSVR = CNT(StrSVR)
        StrDB = CNT(StrDB)
        StrUN = CNT(StrUN)
        StrPW = CNT(StrPW)
        Select Case a
            Case 0
                fk_ETConnect(StrPW, StrUN, StrDB, StrSVR)
            Case 1

                fk_CheckDBStatus(StrPW, StrUN, StrDB, StrSVR)
        End Select

    End Function

    Public Sub GRID_Load(ByVal sqlQ As String, ByVal grid As DataGridView, ByVal cols As Integer, ByVal DbType As String)
        grid.Rows.Clear()
        Dim sqlCString As String = ""
        Select Case DbType
            Case "E"
                sqlCString = StrETConnectionString
            Case "O"
                sqlCString = sqlConString
        End Select
        Dim dgv As New DataGridView
        With dgv
            .Columns.Add("xx", "Head")
        End With
        Dim iCol As Integer

        Dim cnPop As New SqlConnection(sqlCString)
        cnPop.Open()
        Try
            Dim cmPop As New SqlCommand(sqlQ, cnPop)
            cmPop.CommandTimeout = 0
            Dim drPop As SqlDataReader = cmPop.ExecuteReader
            Do While drPop.Read = True
                dgv.Rows.Clear()
                For iCol = 0 To cols - 1
                    Dim StrX As String = IIf(IsDBNull(drPop.Item(iCol)), "", drPop.Item(iCol))
                    dgv.Rows.Add(StrX)
                Next
                ', dgv.Item(0, 3)
                Dim nCol As Integer = cols - 1
                Select Case nCol
                    Case 1
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value)
                    Case 2
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value)
                    Case 3
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value)
                    Case 4
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value)
                    Case 5
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value)
                    Case 6
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value)
                    Case 7
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value)
                    Case 8
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value)
                    Case 9
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value)
                    Case 10
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value)
                    Case 11
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value)
                    Case 12
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value)
                    Case 13
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value)
                    Case 14
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value)
                    Case 15
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value)
                    Case 16
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value)
                    Case 17
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value)
                    Case 18
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value)
                    Case 19
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value)
                    Case 20
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value)
                    Case 21
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value)
                    Case 22
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value)
                    Case 23
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value)
                    Case 24
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value)
                    Case 25
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value)
                    Case 26
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value)
                    Case 27
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value)
                    Case 28
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value)
                    Case 29
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value)
                    Case 30
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value)
                    Case 31
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value)
                    Case 32
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value)
                    Case 33
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value)
                    Case 34
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value)
                    Case 35
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value)
                    Case 36
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value)
                    Case 37
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value)
                    Case 38
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value)
                    Case 39
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value)
                    Case 40
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value)
                    Case 41
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value)
                    Case 42
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value)
                    Case 43
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value)
                    Case 44
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value)
                    Case 45
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value)
                    Case 46
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value)
                    Case 47
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value)
                    Case 48
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value)
                    Case 49
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value)
                    Case 50
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value)
                    Case 51
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value)
                    Case 52
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value)
                    Case 53
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value)
                    Case 54
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value)
                    Case 55
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value)
                    Case 56
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value)
                    Case 57
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value)
                    Case 58
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value)
                    Case 59
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value)
                    Case 60
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value, dgv.Item(0, 60).Value)
                    Case 61
                        grid.Rows.Add(dgv.Item(0, 0).Value, dgv.Item(0, 1).Value, dgv.Item(0, 2).Value, dgv.Item(0, 3).Value, dgv.Item(0, 4).Value, dgv.Item(0, 5).Value, dgv.Item(0, 6).Value, dgv.Item(0, 7).Value, dgv.Item(0, 8).Value, dgv.Item(0, 9).Value, dgv.Item(0, 10).Value, dgv.Item(0, 11).Value, dgv.Item(0, 12).Value, dgv.Item(0, 13).Value, dgv.Item(0, 14).Value, dgv.Item(0, 15).Value, dgv.Item(0, 16).Value, dgv.Item(0, 17).Value, dgv.Item(0, 18).Value, dgv.Item(0, 19).Value, dgv.Item(0, 20).Value, dgv.Item(0, 21).Value, dgv.Item(0, 22).Value, dgv.Item(0, 23).Value, dgv.Item(0, 24).Value, dgv.Item(0, 25).Value, dgv.Item(0, 26).Value, dgv.Item(0, 27).Value, dgv.Item(0, 28).Value, dgv.Item(0, 29).Value, dgv.Item(0, 30).Value, dgv.Item(0, 31).Value, dgv.Item(0, 32).Value, dgv.Item(0, 33).Value, dgv.Item(0, 34).Value, dgv.Item(0, 35).Value, dgv.Item(0, 36).Value, dgv.Item(0, 37).Value, dgv.Item(0, 38).Value, dgv.Item(0, 39).Value, dgv.Item(0, 40).Value, dgv.Item(0, 41).Value, dgv.Item(0, 42).Value, dgv.Item(0, 43).Value, dgv.Item(0, 44).Value, dgv.Item(0, 45).Value, dgv.Item(0, 46).Value, dgv.Item(0, 47).Value, dgv.Item(0, 48).Value, dgv.Item(0, 49).Value, dgv.Item(0, 50).Value, dgv.Item(0, 51).Value, dgv.Item(0, 52).Value, dgv.Item(0, 53).Value, dgv.Item(0, 54).Value, dgv.Item(0, 55).Value, dgv.Item(0, 56).Value, dgv.Item(0, 57).Value, dgv.Item(0, 58).Value, dgv.Item(0, 59).Value, dgv.Item(0, 60).Value, dgv.Item(0, 61).Value)


                End Select
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnPop.Close()
        End Try
    End Sub


    Public Sub Get_ItemTOCombo(ByVal cMb As ComboBox, ByVal SQLString As String, ByVal feiLd As String, ByVal dbTYPE As String)
        cMb.Items.Clear()

        Dim ListSql As String
        ListSql = SQLString
        Dim StrSConnection As String = ""
        Select Case dbTYPE
            Case "E"
                StrSConnection = StrETConnectionString
            Case "O"
                StrSConnection = sqlConString
        End Select
        Dim SQLCCn As New SqlConnection(StrSConnection)


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

    Public Function fk_ETConnect(ByVal StrETpw As String, ByVal StrETun As String, ByVal StrETdb As String, ByVal StrETsqlserver As String) As Boolean

        Try
            StrETConnectionString = "Password= " & StrETpw & ";Persist Security Info=True;User ID=" & StrETun & ";Initial Catalog=" & StrETdb & ";Data Source= " & StrETsqlserver & ";TimeOut=12000"
            If dbSqlCon.State = ConnectionState.Open Then
                dbSqlCon.Close()
            End If
            cnETSQLConn.ConnectionString = StrETConnectionString
            cnETSQLConn.Open()
        Catch ex As Exception
            MsgBox("Connection Faild", MsgBoxStyle.Information)
        End Try
        If dbSqlCon.State = ConnectionState.Open Then
            dbSqlCon.Close()
        End If
    End Function

    Public Function fk_CheckDBStatus(ByVal StrETpw As String, ByVal StrETun As String, ByVal StrETdb As String, ByVal StrETsqlserver As String) As Boolean
        Dim bolResult As Boolean = False
        Try
            StrETConnectionString = "Password= " & StrETpw & ";Persist Security Info=True;User ID=" & StrETun & ";Initial Catalog=" & StrETdb & ";Data Source= " & StrETsqlserver & ";TimeOut=12000;"
            If cnETSQLConn.State = ConnectionState.Open Then
                cnETSQLConn.Close()
            End If
            cnETSQLConn.ConnectionString = StrETConnectionString
            cnETSQLConn.Open()
            MsgBox("Connected Successfully", MsgBoxStyle.Information)
            bolResult = True
        Catch ex As Exception
            MsgBox("Unable to Establish the Connection", MsgBoxStyle.Information)
            bolResult = False
        End Try
        If dbSqlCon.State = ConnectionState.Open Then
            dbSqlCon.Close()
        End If
        Return bolResult
    End Function

    Public Sub CreateKey(ByVal Folder As String, ByVal Value As String)
        Dim str1 As String
        str1 = "HKCU\Software\HRIS\" & Folder
        'Folder = "HCKU\Software\HRIS"
        'name1=readkey("Folder")
        'createkey "Folder",ext1
        Dim B As Object
        On Error Resume Next
        B = CreateObject("wscript.shell")
        B.RegWrite(str1, Value)
    End Sub


    Public Function fk_SaveETConfig(ByVal StrETpw As String, ByVal StrETun As String, ByVal StrETdb As String, ByVal StrETsqlserver As String) As Boolean
        If MsgBox("Do you want to Check Connection Status Before Save?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then
            CreateKey("HRTime\ETCSQLServer", CPT(StrETsqlserver))
            CreateKey("HRTime\ETCSQLDatabase", CPT(StrETdb))
            CreateKey("HRTime\ETCUserName", CPT(StrETun))
            CreateKey("HRTime\ETCPassword", CPT(StrETpw))
            MsgBox("Data Saved Suceessfully", MsgBoxStyle.Information)


        Else
            fk_CheckDBStatus(StrETpw, StrETun, StrETdb, StrETsqlserver)
        End If

    End Function
End Module
