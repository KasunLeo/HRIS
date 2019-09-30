Imports System.Data.SqlClient
'Imports EAS_2011.GlassTableGDI


Public Class frmSetBenefits

    Dim StrSvStatus As String = "S"

    Private Sub frmSetDepts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        sSQL = "CREATE TABLE tblSetBenefits (benID varchar(6),Descr varchar(100),Status int DEFAULT 0)" : FK_EQ(sSQL, "P", "", False, False, False)
        sSQL = "CREATE TABLE tblBenefits(tagID int IDENTITY(1,1) NOT NULL,EmpID varchar(12),benID varchar(6),submitDate DATETIME DEFAULT(1900-01-01),endDate DATETIME DEFAULT(1900-01-01),remark varchar(200),Status int DEFAULT (0),CrCancelDate DATETIME DEFAULT(1900-01-01),InActivelDate DATETIME DEFAULT(1900-01-01),InactiveUser varchar(12),AddUser varchar(12))" : FK_EQ(sSQL, "P", "", False, False, False)

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
        Dim iD As Integer = fk_sqlDbl("SELECT max(benID) FROM tblSetBenefits") + 1
        Dim StrD As String = fk_CreateSerial(3, iD)
        txtCode.Text = StrD

        StrSvStatus = "S"

        Load_InformationtoGrid("SELECT  tblSetBenefits.benID, tblSetBenefits.Descr,tblSetBenefits.status FROM tblSetBenefits  ", dgvData, 2)
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




    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click


    End Sub

    Private Sub dgvData_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick

        txtCode.Text = dgvData.Item(0, dgvData.CurrentRow.Index).Value

        'Show Information 
        Dim cnShw As New SqlConnection(sqlConString)
        cnShw.Open()
        Dim sqlQ As String = "SELECT  tblSetBenefits.benID, tblSetBenefits.Descr,tblSetBenefits.status FROM tblSetBenefits  WHERE tblSetBenefits.benID = '" & txtCode.Text & "'"
        Try
            Dim cmShw As New SqlCommand(sqlQ, cnShw)
            Dim drShw As SqlDataReader = cmShw.ExecuteReader
            If drShw.Read = True Then
                txtCode.Text = IIf(IsDBNull(drShw.Item(0)), "", drShw.Item(0))
                txtDesc.Text = FK_UndoRep(IIf(IsDBNull(drShw.Item(1)), "", drShw.Item(1)))
                chkStatus.CheckState = IIf(IsDBNull(drShw.Item(2)), "", drShw.Item(2))
                StrSvStatus = "E"
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cnShw.Close()
        End Try

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        If txtDesc.Text = "" Then
            MsgBox("Enter Description", MsgBoxStyle.Information)
            txtDesc.Focus()
            Exit Sub
        End If

       

        Dim bolAct As Boolean = False


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
            sSQL = "UPDATE tblSetBenefits SET Descr='" & Trim(txtDesc.Text) & "',status='" & chkStatus.CheckState & "' WHERE benID='" & Trim(txtCode.Text) & "';"
            FK_EQ(sSQL, "E", "", False, True, True)
        Else
            sSQL = "INSERT INTO tblSetBenefits (benID,Descr,Status) VALUES ('" & Trim(txtCode.Text) & "', '" & Trim(txtDesc.Text) & "','" & chkStatus.CheckState & "'); "
            FK_EQ(sSQL, "S", "", True, True, True)
        End If


        cmdRefresh_Click(sender, e)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cmdRefresh_Click(sender, e)
    End Sub

End Class