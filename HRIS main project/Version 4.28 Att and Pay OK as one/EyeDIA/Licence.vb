Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Data
Imports Microsoft.Win32

Public Class Licence

    Private Sub Licence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'CenterForm(Me)
        ControlHandlers(Me)

        intTotalDevice = 1

        '=========================Date Format setting
        'Dim keyName As String = Registry.CurrentUser.ToString() & "\Control Panel\International"
        'Dim valueName As String = "sShortDate"
        '' Dim s As String = Registry.GetValue(keyName, valueName, String.Empty).ToString()
        'Registry.SetValue(keyName, valueName, "M/d/yyyy")

        'valueName = "sLongDate"
        'Registry.SetValue(keyName, valueName, "dddd, MMMM dd, yyyy")

        'valueName = "sTimeFormat"
        'Registry.SetValue(keyName, valueName, "h:mm:ss tt")
        '=========================

        StrCompID = "001"
        ControlHandlers(Me)
        CenterForm(Me)

        ConnecttoDataBase()
        '========================================
        Dim strQry As String = " CREATE TABLE [dbo].[tblusers](" & _
" [userID] [nvarchar](3)  NULL," & _
" [userName] [nvarchar](20)  NULL," & _
" [logName] [nvarchar](10)  NULL," & _
" [pw] [nvarchar](10)  NULL," & _
" [comID] [nvarchar](3)  NULL," & _
" [uLvl] [nvarchar](3)  NULL," & _
" [Status] [numeric](18, 0) NULL" & _
" ) ON [PRIMARY]"
        fk_CreateTableR(strQry, "tblusers")

        strQry = " create table tblControl ( " & _
 " GrpID nvarchar (3) null , NoCompany numeric (18,0) not null )"
        fk_CreateTableR(strQry, "tblControl")

        Dim CompIDR As String = fk_RetString("Select GrpID from tblControl where GrpID='001'")
        If CompIDR = "" Then
            fk_UpdateTblR("insert into tblcontrol (GrpID,noCompany) values('001',1)")
        End If


        '======================================

        Timer1.Start()
        lblCompany.Text = "Copyright by " & strDealerName & "                                                   "

        Dim StrFile As String = Application.StartupPath & "\gender.dat"
        Dim MyFile As New FileInfo(StrFile)

        If MyFile.Exists() Then ' check file
        Else
            Dim writeFile As System.IO.TextWriter = New StreamWriter(StrFile)
            writeFile.WriteLine("HRIS")
        End If

        dgv.Columns.Add("MAC", "MAC")

        'add textpad id to datagriedvied
        Dim sr As StreamReader = New StreamReader(StrFile)
        Dim StrVal As String = ""


        dtpExDat.CustomFormat = "dd/MM/yyyy"
        dtpExDat.Format = DateTimePickerFormat.Custom

        Try
            Dim line As String
            Do
                line = sr.ReadLine()
                If line = Nothing Then
                    Exit Do
                End If
                mod_Encrypt.pathway = "freeway"
                Dim dcrip As String = mod_Encrypt.decrip(line)

                If dcrip.Length < 17 Then

                    Dim dd = dcrip.Substring(0, 2)
                    Dim mm = dcrip.Substring(2, 2)
                    Dim yyyy = dcrip.Substring(4, 4)
                    dtpExDat.Value = dtpExDat.Value
                    dtpExDat.Value = mm & "/" & dd & "/" & yyyy
                    intTotalDevice = dcrip.Substring(8, 2)
                    strAllMachine = "00" & intTotalDevice

                Else
                    dgv.Rows.Add(dcrip.Substring(17))
                End If

            Loop Until line Is Nothing
            sr.Close()
            sr.Dispose()
        Catch Ex As Exception
            sr.Close()
            sr.Dispose()
            licen_error()
            Exit Sub
        End Try

        'match actual id and textpad id
        Dim match As Boolean = False
        For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
            Dim StrNIC = nic.Id.ToString

            For i As Integer = 0 To dgv.RowCount - 1
                If dgv.Rows(i).Cells(0).Value = StrNIC Then
                    match = True
                End If
            Next
        Next

        Dim d = fk_RetString("SELECT CONVERT(VARCHAR(10), GETDATE(), 120) AS [YYYY-MM-DD]")

        If match = True Then
            If dtpExDat.Value < d Then
                match = False
            End If
        End If

        If match = True Then

            Label1.Text = "Licence"
            'Me.Visible = False
            bolLicenced = True
            Timer1.Stop()
            frmSplash.ShowDialog()
            Me.Close()
            Exit Sub

        Else

            licen_error()

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Hide()

    End Sub

    Public Sub licen_error()

        Label1.Text = "Licence"
        'Me.Visible = False
        bolLicenced = True
        Timer1.Stop()
        frmSplash.ShowDialog()
        Me.Close()
        Exit Sub

        Label1.Text = "Licence Error"
        TextBox1.Text = ""
        Dim iE As Integer = 0
        For Each nic As System.Net.NetworkInformation.NetworkInterface In System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
            Dim StrNIC = nic.Id.ToString
            If StrNIC = "MS TCP Loopback interface" Then
                Exit Sub
            End If
            If StrNIC = "" Then
                Exit Sub
            End If

            Dim CurrentFormDinamicKey As String = ""
            Dim dtp As New DateTimePicker
            dtp.Value = dtp.Value.AddHours(iE)
            'Encript S
            CurrentFormDinamicKey = dtp.Value.ToString("ddMMyyyy hhmmss")

            mod_Encrypt.pathway = "freeway" 'public Key
            Dim DinamicKeyEn As String = mod_Encrypt.encrip(CurrentFormDinamicKey & StrNIC) 'public Key


            If TextBox1.Text = "" Then
                TextBox1.Text = DinamicKeyEn
            Else
                TextBox1.Text += Environment.NewLine + DinamicKeyEn
            End If

            iE = iE + 1
        Next

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        lblCompany.Text = lblCompany.Text.Substring(1) & lblCompany.Text.Substring(0, 1)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim path As String = Application.StartupPath & "\gender.dat"
            Dim writeFile As System.IO.TextWriter = New StreamWriter(path)

            writeFile.WriteLine(TextBox2.Text)
            writeFile.Flush()
            writeFile.Close()
            writeFile = Nothing

            Call Licence_Load(sender, e)

        Catch ex As Exception
            MsgBox("Error, Call - 0114381385, email - info@HRIS.com")
            System.Diagnostics.Process.Start("http://www.HRIS.com")
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

End Class