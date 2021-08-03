<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBayar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogBayar))
        Me.cbMetode = New System.Windows.Forms.ComboBox()
        Me.panelNonCash = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbAkun = New System.Windows.Forms.ComboBox()
        Me.TBNoAkun = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbKembali = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbBayar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbTotal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBDiskon = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TBPotongan = New System.Windows.Forms.TextBox()
        Me.tbAwal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Struk5 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Struk7 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.StrukA = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.diskonNominal = New System.Windows.Forms.CheckBox()
        Me.panelNonCash.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbMetode
        '
        Me.cbMetode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMetode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbMetode.FormattingEnabled = True
        Me.cbMetode.Items.AddRange(New Object() {"Cash", "E-Money", "Debit"})
        Me.cbMetode.Location = New System.Drawing.Point(129, 424)
        Me.cbMetode.Name = "cbMetode"
        Me.cbMetode.Size = New System.Drawing.Size(560, 28)
        Me.cbMetode.TabIndex = 9
        '
        'panelNonCash
        '
        Me.panelNonCash.Controls.Add(Me.Label6)
        Me.panelNonCash.Controls.Add(Me.cbAkun)
        Me.panelNonCash.Controls.Add(Me.TBNoAkun)
        Me.panelNonCash.Controls.Add(Me.Label4)
        Me.panelNonCash.Location = New System.Drawing.Point(6, 459)
        Me.panelNonCash.Name = "panelNonCash"
        Me.panelNonCash.Size = New System.Drawing.Size(700, 85)
        Me.panelNonCash.TabIndex = 38
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(58, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Akun :"
        '
        'cbAkun
        '
        Me.cbAkun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAkun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.Items.AddRange(New Object() {"Tunai", "E-Money", "Debit"})
        Me.cbAkun.Location = New System.Drawing.Point(123, 11)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(560, 28)
        Me.cbAkun.TabIndex = 10
        '
        'TBNoAkun
        '
        Me.TBNoAkun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBNoAkun.Location = New System.Drawing.Point(123, 54)
        Me.TBNoAkun.Name = "TBNoAkun"
        Me.TBNoAkun.Size = New System.Drawing.Size(560, 26)
        Me.TBNoAkun.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Nomer Akun :"
        '
        'tbKembali
        '
        Me.tbKembali.Enabled = False
        Me.tbKembali.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.tbKembali.Location = New System.Drawing.Point(129, 366)
        Me.tbKembali.Name = "tbKembali"
        Me.tbKembali.Size = New System.Drawing.Size(560, 53)
        Me.tbKembali.TabIndex = 8
        Me.tbKembali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 370)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 20)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Kembali :"
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(21, 560)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(117, 32)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Batal"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(143, 560)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(141, 32)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "(Bayar+Struk)"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 424)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Metode :"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(569, 313)
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
        Me.Button3.Location = New System.Drawing.Point(425, 313)
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
        Me.Button2.Location = New System.Drawing.Point(271, 313)
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
        Me.Button1.Location = New System.Drawing.Point(129, 313)
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
        Me.tbBayar.Location = New System.Drawing.Point(129, 255)
        Me.tbBayar.Name = "tbBayar"
        Me.tbBayar.Size = New System.Drawing.Size(560, 53)
        Me.tbBayar.TabIndex = 2
        Me.tbBayar.Text = "60.000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 20)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Bayar :"
        '
        'tbTotal
        '
        Me.tbTotal.BackColor = System.Drawing.Color.Yellow
        Me.tbTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTotal.Enabled = False
        Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotal.Location = New System.Drawing.Point(129, 98)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(560, 53)
        Me.tbTotal.TabIndex = 1
        Me.tbTotal.Text = "50.000"
        Me.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft PhagsPa", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 28)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Total Akhir :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TBDiskon
        '
        Me.TBDiskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.TBDiskon.Location = New System.Drawing.Point(129, 156)
        Me.TBDiskon.Name = "TBDiskon"
        Me.TBDiskon.Size = New System.Drawing.Size(117, 53)
        Me.TBDiskon.TabIndex = 7
        Me.TBDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(46, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Diskon :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.Label8.Location = New System.Drawing.Point(252, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 46)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "%"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 611)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(740, 22)
        Me.StatusStrip1.TabIndex = 44
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
        'TBPotongan
        '
        Me.TBPotongan.Enabled = False
        Me.TBPotongan.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!)
        Me.TBPotongan.Location = New System.Drawing.Point(306, 157)
        Me.TBPotongan.Name = "TBPotongan"
        Me.TBPotongan.Size = New System.Drawing.Size(383, 53)
        Me.TBPotongan.TabIndex = 45
        Me.TBPotongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbAwal
        '
        Me.tbAwal.BackColor = System.Drawing.Color.Yellow
        Me.tbAwal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbAwal.Enabled = False
        Me.tbAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAwal.Location = New System.Drawing.Point(129, 37)
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
        Me.Label9.Location = New System.Drawing.Point(24, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 34)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Total :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Enabled = False
        Me.Button8.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(440, 559)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(141, 32)
        Me.Button8.TabIndex = 52
        Me.Button8.Text = "Cetak Kembali"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Enabled = False
        Me.Button9.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(584, 558)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(141, 32)
        Me.Button9.TabIndex = 53
        Me.Button9.Text = "Tutup"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Enabled = False
        Me.Button7.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(293, 560)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(141, 32)
        Me.Button7.TabIndex = 54
        Me.Button7.Text = "Surat jalan"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.diskonNominal)
        Me.Panel1.Controls.Add(Me.StrukA)
        Me.Panel1.Controls.Add(Me.Struk7)
        Me.Panel1.Controls.Add(Me.Struk5)
        Me.Panel1.Controls.Add(Me.tbAwal)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TBPotongan)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TBDiskon)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cbMetode)
        Me.Panel1.Controls.Add(Me.panelNonCash)
        Me.Panel1.Controls.Add(Me.tbKembali)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.tbBayar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.tbTotal)
        Me.Panel1.Location = New System.Drawing.Point(15, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(709, 552)
        Me.Panel1.TabIndex = 55
        '
        'diskonNominal
        '
        Me.diskonNominal.AutoSize = True
        Me.diskonNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diskonNominal.Location = New System.Drawing.Point(128, 216)
        Me.diskonNominal.Name = "diskonNominal"
        Me.diskonNominal.Size = New System.Drawing.Size(240, 22)
        Me.diskonNominal.TabIndex = 56
        Me.diskonNominal.Text = "Diskon dalam potongan nominal"
        Me.diskonNominal.UseVisualStyleBackColor = True
        '
        'DialogBayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(740, 633)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembayaran"
        Me.panelNonCash.ResumeLayout(False)
        Me.panelNonCash.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbMetode As ComboBox
    Friend WithEvents panelNonCash As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents cbAkun As ComboBox
    Friend WithEvents TBNoAkun As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbKembali As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents tbBayar As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tbTotal As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TBDiskon As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents TBPotongan As TextBox
    Friend WithEvents tbAwal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Struk5 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Struk7 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents StrukA As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents diskonNominal As CheckBox
End Class
