Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Configuration

Public Class transpPrivewForm

    Dim tempCnt As Boolean         'check weather the roller is used or not

    Dim bm_dest As Bitmap
    Dim bm_source As Bitmap
    Dim i As Int16 = 0.0

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.PreviewPictureBox.Image = Nothing
    End Sub

#Region "Image Resizing"
    Private Sub resizingTrackBar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resizingTrackBar.ValueChanged
        Try

            Dim scale_factor As Integer
            Dim img1 As New PictureBox

            scale_factor = Integer.Parse(resizingTrackBar.Value)
            img1.Image = cropBitmap
            bm_source = New Bitmap(img1.Image)
            bm_dest = New Bitmap( _
                CInt(bm_source.Width * scale_factor), _
                CInt(bm_source.Height * scale_factor))

            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + i, bm_dest.Height + i)

            PreviewPictureBox.Image = bm_dest

            tempCnt = True
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Image Cropping"
    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer

    Dim oCropX As Integer
    Dim oCropY As Integer
    Dim cropBitmap As Bitmap

    Public cropPen As Pen
    Public cropPenSize As Integer = 1 '2
    Public cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Public cropPenColor As Color = Color.Yellow

    Private Sub crobPictureBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles crobPictureBox.MouseDown
        Try

            If e.Button = Windows.Forms.MouseButtons.Left Then

                cropX = e.X
                cropY = e.Y

                cropPen = New Pen(cropPenColor, cropPenSize)
                cropPen.DashStyle = DashStyle.DashDotDot
                Cursor = Cursors.Cross

            End If
            crobPictureBox.Refresh()
        Catch exc As Exception
        End Try
    End Sub
    Dim tmppoint As Point
    Private Sub crobPictureBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles crobPictureBox.MouseMove
        Try

            If crobPictureBox.Image Is Nothing Then Exit Sub

            If e.Button = Windows.Forms.MouseButtons.Left Then

                crobPictureBox.Refresh()
                cropWidth = e.X - cropX
                cropHeight = e.Y - cropY
                crobPictureBox.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
            End If
            ' GC.Collect()

        Catch exc As Exception

            If Err.Number = 5 Then Exit Sub
        End Try

    End Sub

    Private Sub crobPictureBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles crobPictureBox.MouseUp
        Try
            Cursor = Cursors.Default
            Try

                If cropWidth < 1 Then
                    Exit Sub
                End If

                Dim rect As Rectangle = New Rectangle(cropX, cropY, cropWidth, cropHeight)
                Dim bit As Bitmap = New Bitmap(crobPictureBox.Image, crobPictureBox.Width, crobPictureBox.Height)

                cropBitmap = New Bitmap(cropWidth, cropHeight)
                Dim g As Graphics = Graphics.FromImage(cropBitmap)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
                PreviewPictureBox.Image = cropBitmap

            Catch exc As Exception
            End Try
        Catch exc As Exception
        End Try
    End Sub
#End Region


    Private Sub transpPrivewForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim str As String = Application.StartupPath & "\img1.gif"
        'PreviewPictureBox.Image = System.Drawing.Bitmap.FromFile(str)
        crobPictureBox.Image = frmMainAttendance.picEmpProfil.Image
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cropSaveBtn.Click
        'Dim tempFileName As String
        'Dim svdlg As New SaveFileDialog()
        'svdlg.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*"
        'svdlg.FilterIndex = 1
        'svdlg.RestoreDirectory = True
        'If svdlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
        'tempFileName = svdlg.FileName           'check the file exist else save the cropped image
        Try
            Dim img As Image = crobPictureBox.Image
            frmMainAttendance.picEmpProfil.Image = img
            'SavePhoto(img, tempFileName, 225)
        Catch exc As Exception
            MsgBox("Error on Saving: " & exc.Message)
        End Try
        'End If
    End Sub

    Private Sub cropCancelBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cropCancelBtn1.Click
        PreviewPictureBox.Image = Nothing
        cropBitmap = Nothing
        crobPictureBox.Image = Nothing
    End Sub

    Public Function SavePhoto(ByVal src As Image, ByVal dest As String, ByVal w As Integer) As Boolean
        Try
            Dim imgTmp As System.Drawing.Image
            Dim imgFoto As System.Drawing.Bitmap

            imgTmp = src
            imgFoto = New System.Drawing.Bitmap(w, 225)
            Dim recDest As New Rectangle(0, 0, w, imgFoto.Height)
            Dim gphCrop As Graphics = Graphics.FromImage(imgFoto)
            gphCrop.SmoothingMode = SmoothingMode.HighQuality
            gphCrop.CompositingQuality = CompositingQuality.HighQuality
            gphCrop.InterpolationMode = InterpolationMode.High

            gphCrop.DrawImage(imgTmp, recDest, 0, 0, imgTmp.Width, imgTmp.Height, GraphicsUnit.Pixel)

            Dim myEncoder As System.Drawing.Imaging.Encoder
            Dim myEncoderParameter As System.Drawing.Imaging.EncoderParameter
            Dim myEncoderParameters As System.Drawing.Imaging.EncoderParameters

            Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
            Dim jpegICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
            Dim x As Integer = 0
            For x = 0 To arrayICI.Length - 1
                If (arrayICI(x).FormatDescription.Equals("JPEG")) Then
                    jpegICI = arrayICI(x)
                    Exit For
                End If
            Next
            myEncoder = System.Drawing.Imaging.Encoder.Quality
            myEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
            myEncoderParameter = New System.Drawing.Imaging.EncoderParameter(myEncoder, 60L)
            myEncoderParameters.Param(0) = myEncoderParameter
            imgFoto.Save(dest, jpegICI, myEncoderParameters)
            imgFoto.Dispose()
            imgTmp.Dispose()

        Catch ex As Exception

        End Try
    End Function

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        crobPictureBox.Enabled = True
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim openDlg As New System.Windows.Forms.OpenFileDialog
        openDlg.Filter = "JPEG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|Bitmap Files (*.bmp)|*.bmp"
        If openDlg.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If Not openDlg.FileName Is Nothing Then
            PreviewPictureBox.Image = System.Drawing.Bitmap.FromFile(openDlg.FileName)
            crobPictureBox.Image = System.Drawing.Bitmap.FromFile(openDlg.FileName)
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim newimg As New Bitmap(crobPictureBox.Image)


        'crobPictureBox.Image = newimg
        crobPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        'picEmp.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class