<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutoEmail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoEmail))
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblSetReligion = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.txtTO = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPasword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.ofdAttach = New System.Windows.Forms.OpenFileDialog()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(115, 479)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 13)
        Me.lblCount.TabIndex = 190
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 189
        Me.Label7.Text = "Attachments"
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(118, 230)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(519, 21)
        Me.txtFile.TabIndex = 187
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.HRISforBB.My.Resources.Resources.leftCorner
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Controls.Add(Me.lblSetReligion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(716, 66)
        Me.Panel3.TabIndex = 184
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(350, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(355, 57)
        Me.DataGridView1.TabIndex = 2
        Me.DataGridView1.Visible = False
        '
        'lblSetReligion
        '
        Me.lblSetReligion.AutoSize = True
        Me.lblSetReligion.BackColor = System.Drawing.Color.Transparent
        Me.lblSetReligion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetReligion.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblSetReligion.Location = New System.Drawing.Point(11, 27)
        Me.lblSetReligion.Name = "lblSetReligion"
        Me.lblSetReligion.Size = New System.Drawing.Size(167, 13)
        Me.lblSetReligion.TabIndex = 1
        Me.lblSetReligion.Text = "Automatic E mail Sender"
        Me.lblSetReligion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 183
        Me.Label6.Text = "Subject"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(118, 257)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(519, 210)
        Me.txtMessage.TabIndex = 182
        Me.txtMessage.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "......................" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "HR Manager"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Message"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(118, 203)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(519, 21)
        Me.txtSubject.TabIndex = 180
        Me.txtSubject.Text = "Roster Information Report"
        '
        'txtTO
        '
        Me.txtTO.Location = New System.Drawing.Point(118, 176)
        Me.txtTO.Name = "txtTO"
        Me.txtTO.Size = New System.Drawing.Size(519, 21)
        Me.txtTO.TabIndex = 179
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBrowse.FlatAppearance.BorderSize = 0
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBrowse.Location = New System.Drawing.Point(643, 227)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(25, 24)
        Me.btnBrowse.TabIndex = 188
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.txtFrom)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtPasword)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(716, 34)
        Me.Panel1.TabIndex = 186
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(118, 7)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(202, 21)
        Me.txtFrom.TabIndex = 36
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(425, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Gmail Password"
        '
        'txtPasword
        '
        Me.txtPasword.Location = New System.Drawing.Point(541, 7)
        Me.txtPasword.Name = "txtPasword"
        Me.txtPasword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(36)
        Me.txtPasword.Size = New System.Drawing.Size(164, 21)
        Me.txtPasword.TabIndex = 39
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Gmail Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(326, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "@gmail.com"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.BackgroundImage = CType(resources.GetObject("cmdRefresh.BackgroundImage"), System.Drawing.Image)
        Me.cmdRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRefresh.FlatAppearance.BorderSize = 0
        Me.cmdRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.ForeColor = System.Drawing.Color.White
        Me.cmdRefresh.Location = New System.Drawing.Point(629, 473)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(76, 24)
        Me.cmdRefresh.TabIndex = 185
        Me.cmdRefresh.Tag = "1"
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdSend
        '
        Me.cmdSend.BackgroundImage = CType(resources.GetObject("cmdSend.BackgroundImage"), System.Drawing.Image)
        Me.cmdSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSend.FlatAppearance.BorderSize = 0
        Me.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSend.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSend.ForeColor = System.Drawing.Color.White
        Me.cmdSend.Location = New System.Drawing.Point(547, 473)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(76, 24)
        Me.cmdSend.TabIndex = 178
        Me.cmdSend.Tag = "1"
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'AutoEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 507)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.txtTO)
        Me.Controls.Add(Me.cmdSend)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "AutoEmail"
        Me.Text = "AutoEmail"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCount As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtFile As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtFrom As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPasword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmdRefresh As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblSetReligion As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents txtTO As TextBox
    Friend WithEvents cmdSend As Button
    Friend WithEvents ofdAttach As OpenFileDialog
End Class
