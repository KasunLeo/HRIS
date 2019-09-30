Public Class frmSplash

    Dim bolJump As Boolean = False

    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.BackColor = Color.White
        TransparencyKey = Me.BackColor
        CenterForm(Me)

        'Try
        '    Dim sourceName As String = "ExampleText.txt"
        '    ' The second file parameter to the executable
        '    Dim targetName As String = "Example.gz"
        '    ' New ProcessStartInfo created
        '    Dim p As New ProcessStartInfo
        '    ' Specify the location of the binary
        '    p.FileName = Application.StartupPath & "\Licences.exe"
        '    ' Use these arguments for the process
        '    p.Arguments = "a -tgzip """ & targetName & """ """ & sourceName & """ -mx=9"
        '    ' Use a hidden window
        '    p.WindowStyle = ProcessWindowStyle.Hidden
        '    ' Start the process
        '    Process.Start(p)
        'Catch ex As Exception
        '    'MessageBox.Show(ex.Message)
        '    MessageBox.Show("There is error with Connection", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

        'Button1.BackColor = Color.WhiteSmoke
        'Button2.BackColor = Color.WhiteSmoke

        StrCompID = "001"

        Timer1.Start()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Me.Close()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If bolJump = True Then Timer1.Stop()

        If PictureBox6.Visible = True Then

            bolJump = True
            Me.Close()

        End If

        If PictureBox5.Visible = True Then

            PictureBox6.Visible = True
            Pb.Value = Pb.Maximum

        End If

        If PictureBox4.Visible = True Then

            PictureBox5.Visible = True

        End If

        If PictureBox3.Visible = True Then

            PictureBox4.Visible = True

        End If

        If PictureBox2.Visible = True Then

            PictureBox3.Visible = True

        End If

        If PictureBox1.Visible = True Then

            PictureBox2.Visible = True

        End If

        If PictureBox1.Visible = False Then

            PictureBox1.Visible = True

        End If

        If Not Pb.Value >= 85 Then

            Pb.Value += 14

            If Pb.Value = Pb.Maximum Then

                Exit Sub

            End If

        End If

    End Sub

    Private Sub PictureBox8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Me.Close()
    End Sub

End Class