<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class transpPrivewForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cropCancelBtn1 = New System.Windows.Forms.Button
        Me.cropSaveBtn = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.resizingTrackBar = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.PreviewPictureBox = New System.Windows.Forms.PictureBox
        Me.crobPictureBox = New System.Windows.Forms.PictureBox
        Me.Panel1.SuspendLayout()
        CType(Me.resizingTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreviewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.crobPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cropCancelBtn1)
        Me.Panel1.Controls.Add(Me.cropSaveBtn)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.resizingTrackBar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PreviewPictureBox)
        Me.Panel1.Controls.Add(Me.crobPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(554, 380)
        Me.Panel1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(434, 216)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 23)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Rotate"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Schoolbook", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(149, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Croppable Image"
        '
        'cropCancelBtn1
        '
        Me.cropCancelBtn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cropCancelBtn1.Location = New System.Drawing.Point(242, 296)
        Me.cropCancelBtn1.Name = "cropCancelBtn1"
        Me.cropCancelBtn1.Size = New System.Drawing.Size(75, 23)
        Me.cropCancelBtn1.TabIndex = 19
        Me.cropCancelBtn1.Text = "Clear"
        Me.cropCancelBtn1.UseVisualStyleBackColor = True
        '
        'cropSaveBtn
        '
        Me.cropSaveBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cropSaveBtn.Location = New System.Drawing.Point(161, 296)
        Me.cropSaveBtn.Name = "cropSaveBtn"
        Me.cropSaveBtn.Size = New System.Drawing.Size(75, 23)
        Me.cropSaveBtn.TabIndex = 18
        Me.cropSaveBtn.Text = "Save"
        Me.cropSaveBtn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(90, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Open"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'resizingTrackBar
        '
        Me.resizingTrackBar.AutoSize = False
        Me.resizingTrackBar.LargeChange = 1
        Me.resizingTrackBar.Location = New System.Drawing.Point(434, 153)
        Me.resizingTrackBar.Name = "resizingTrackBar"
        Me.resizingTrackBar.Size = New System.Drawing.Size(79, 25)
        Me.resizingTrackBar.SmallChange = 0
        Me.resizingTrackBar.TabIndex = 15
        Me.resizingTrackBar.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Schoolbook", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(445, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 14)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Preview"
        '
        'PreviewPictureBox
        '
        Me.PreviewPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewPictureBox.Location = New System.Drawing.Point(404, 27)
        Me.PreviewPictureBox.Name = "PreviewPictureBox"
        Me.PreviewPictureBox.Size = New System.Drawing.Size(120, 120)
        Me.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PreviewPictureBox.TabIndex = 6
        Me.PreviewPictureBox.TabStop = False
        '
        'crobPictureBox
        '
        Me.crobPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.crobPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crobPictureBox.Cursor = System.Windows.Forms.Cursors.Cross
        Me.crobPictureBox.Location = New System.Drawing.Point(70, 40)
        Me.crobPictureBox.Name = "crobPictureBox"
        Me.crobPictureBox.Size = New System.Drawing.Size(204, 250)
        Me.crobPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.crobPictureBox.TabIndex = 0
        Me.crobPictureBox.TabStop = False
        '
        'transpPrivewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(553, 379)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "transpPrivewForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Cropping Demo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.resizingTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreviewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.crobPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents resizingTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PreviewPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents crobPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cropCancelBtn1 As System.Windows.Forms.Button
    Friend WithEvents cropSaveBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
