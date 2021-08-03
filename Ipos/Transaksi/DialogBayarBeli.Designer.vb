<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogBayarBeli
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Keterangan = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StrukA = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Struk7 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Struk5 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tbAwal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbKembali = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbBayar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 504)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(746, 22)
        Me.StatusStrip1.TabIndex = 67
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel1.Text = "[F11] : Simpan,"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(135, 17)
        Me.ToolStripStatusLabel2.Text = "[F12] Simpan Surat Jalan"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(127, 17)
        Me.ToolStripStatusLabel4.Text = "[Ctrl+P] Cetak kembali"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(152, 17)
        Me.ToolStripStatusLabel3.Text = "[CTRL+END] : Batal / Keluar"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(392, 456)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(117, 32)
        Me.Button6.TabIndex = 65
        Me.Button6.Text = "Batal"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 312)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 18)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Keterangan :"
        '
        'Keterangan
        '
        Me.Keterangan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Keterangan.Location = New System.Drawing.Point(128, 304)
        Me.Keterangan.Multiline = True
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.Size = New System.Drawing.Size(560, 96)
        Me.Keterangan.TabIndex = 53
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(128, 256)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(560, 33)
        Me.DateTimePicker1.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Jatuh Tempo :"
        '
        'StrukA
        '
        Me.StrukA.DocumentMapWidth = 73
        Me.StrukA.Location = New System.Drawing.Point(139, 7)
        Me.StrukA.Name = "StrukA"
        Me.StrukA.ServerReport.BearerToken = Nothing
        Me.StrukA.Size = New System.Drawing.Size(17, 10)
        Me.StrukA.TabIndex = 50
        Me.StrukA.Visible = False
        '
        'Struk7
        '
        Me.Struk7.DocumentMapWidth = 8
        Me.Struk7.Location = New System.Drawing.Point(62, 13)
        Me.Struk7.Name = "Struk7"
        Me.Struk7.ServerReport.BearerToken = Nothing
        Me.Struk7.Size = New System.Drawing.Size(10, 18)
        Me.Struk7.TabIndex = 49
        Me.Struk7.Visible = False
        '
        'Struk5
        '
        Me.Struk5.DocumentMapWidth = 21
        Me.Struk5.LocalReport.ReportEmbeddedResource = "Ipos.Struk58.rdlc"
        Me.Struk5.Location = New System.Drawing.Point(6, 13)
        Me.Struk5.Name = "Struk5"
        Me.Struk5.ServerReport.BearerToken = Nothing
        Me.Struk5.Size = New System.Drawing.Size(10, 23)
        Me.Struk5.TabIndex = 48
        Me.Struk5.Visible = False
        '
        'tbAwal
        '
        Me.tbAwal.BackColor = System.Drawing.Color.Yellow
        Me.tbAwal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAwal.Enabled = False
        Me.tbAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAwal.Location = New System.Drawing.Point(129, 16)
        Me.tbAwal.Name = "tbAwal"
        Me.tbAwal.Size = New System.Drawing.Size(560, 53)
        Me.tbAwal.TabIndex = 46
        Me.tbAwal.Text = "50.000"
        Me.tbAwal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft PhagsPa", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 34)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Total :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbKembali
        '
        Me.tbKembali.Enabled = False
        Me.tbKembali.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.tbKembali.Location = New System.Drawing.Point(129, 189)
        Me.tbKembali.Name = "tbKembali"
        Me.tbKembali.Size = New System.Drawing.Size(560, 53)
        Me.tbKembali.TabIndex = 8
        Me.tbKembali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 20)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Uang Muka :"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(569, 136)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(117, 43)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Rp.100.000"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(425, 136)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(117, 43)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Rp.50.000"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(271, 136)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(117, 43)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Rp.20.000"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(129, 136)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 43)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Rp.10.000"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'tbBayar
        '
        Me.tbBayar.BackColor = System.Drawing.Color.LimeGreen
        Me.tbBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.tbBayar.Location = New System.Drawing.Point(129, 78)
        Me.tbBayar.Name = "tbBayar"
        Me.tbBayar.Size = New System.Drawing.Size(560, 53)
        Me.tbBayar.TabIndex = 2
        Me.tbBayar.Text = "60.000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Bayar :"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Keterangan)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.StrukA)
        Me.Panel1.Controls.Add(Me.Struk7)
        Me.Panel1.Controls.Add(Me.Struk5)
        Me.Panel1.Controls.Add(Me.tbAwal)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.tbKembali)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.tbBayar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(15, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(709, 440)
        Me.Panel1.TabIndex = 71
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(207, 456)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(117, 32)
        Me.Button5.TabIndex = 72
        Me.Button5.Text = "Simpan"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'DialogBayarBeli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(746, 526)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBayarBeli"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembayaran"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents Button6 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Keterangan As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents StrukA As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Struk7 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Struk5 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tbAwal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbKembali As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents tbBayar As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button5 As Button
End Class
