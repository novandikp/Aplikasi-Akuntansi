<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogTransaksiBayar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogTransaksiBayar))
        Me.cbKasBiayaLain = New System.Windows.Forms.ComboBox()
        Me.panelDokumen = New System.Windows.Forms.Panel()
        Me.dtDokumen = New MetroFramework.Controls.MetroDateTime()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBNoDokumen = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbBiayaLain = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbAkunDiskon = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnCariAkun = New System.Windows.Forms.Button()
        Me.checkDokumen = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbLunas = New System.Windows.Forms.CheckBox()
        Me.btnCariAkunTerima = New System.Windows.Forms.Button()
        Me.cbAkunTerima = New System.Windows.Forms.ComboBox()
        Me.tbBayar = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblAkunTerima = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbPajak = New System.Windows.Forms.TextBox()
        Me.diskonNominal = New System.Windows.Forms.CheckBox()
        Me.tbGrand = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbTotal = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.panelDokumen.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbKasBiayaLain
        '
        Me.cbKasBiayaLain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbKasBiayaLain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbKasBiayaLain.FormattingEnabled = True
        Me.cbKasBiayaLain.Items.AddRange(New Object() {"Cash", "E-Money", "Debit"})
        Me.cbKasBiayaLain.Location = New System.Drawing.Point(18, 136)
        Me.cbKasBiayaLain.Name = "cbKasBiayaLain"
        Me.cbKasBiayaLain.Size = New System.Drawing.Size(262, 28)
        Me.cbKasBiayaLain.TabIndex = 9
        '
        'panelDokumen
        '
        Me.panelDokumen.Controls.Add(Me.dtDokumen)
        Me.panelDokumen.Controls.Add(Me.Label6)
        Me.panelDokumen.Controls.Add(Me.TBNoDokumen)
        Me.panelDokumen.Controls.Add(Me.Label4)
        Me.panelDokumen.Location = New System.Drawing.Point(5, 270)
        Me.panelDokumen.Name = "panelDokumen"
        Me.panelDokumen.Size = New System.Drawing.Size(381, 136)
        Me.panelDokumen.TabIndex = 38
        '
        'dtDokumen
        '
        Me.dtDokumen.Location = New System.Drawing.Point(10, 42)
        Me.dtDokumen.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtDokumen.Name = "dtDokumen"
        Me.dtDokumen.Size = New System.Drawing.Size(362, 29)
        Me.dtDokumen.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(10, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tanggal Dokumen :"
        '
        'TBNoDokumen
        '
        Me.TBNoDokumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBNoDokumen.Location = New System.Drawing.Point(10, 106)
        Me.TBNoDokumen.Name = "TBNoDokumen"
        Me.TBNoDokumen.Size = New System.Drawing.Size(362, 26)
        Me.TBNoDokumen.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(10, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 17)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Nomer Dokumen :"
        '
        'tbBiayaLain
        '
        Me.tbBiayaLain.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.tbBiayaLain.Location = New System.Drawing.Point(18, 50)
        Me.tbBiayaLain.Name = "tbBiayaLain"
        Me.tbBiayaLain.Size = New System.Drawing.Size(362, 38)
        Me.tbBiayaLain.TabIndex = 8
        Me.tbBiayaLain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(18, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Biaya Lain :"
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.SystemColors.Control
        Me.btnSimpan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSimpan.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimpan.Location = New System.Drawing.Point(3, 3)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(315, 32)
        Me.btnSimpan.TabIndex = 13
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(18, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Akun Biaya Lain :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        Me.TBDiskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TBDiskon.Location = New System.Drawing.Point(17, 210)
        Me.TBDiskon.Name = "TBDiskon"
        Me.TBDiskon.Size = New System.Drawing.Size(117, 38)
        Me.TBDiskon.TabIndex = 7
        Me.TBDiskon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(16, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Diskon :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(151, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 31)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "%"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 529)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1031, 22)
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
        Me.TBPotongan.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.TBPotongan.Location = New System.Drawing.Point(200, 210)
        Me.TBPotongan.Name = "TBPotongan"
        Me.TBPotongan.Size = New System.Drawing.Size(368, 38)
        Me.TBPotongan.TabIndex = 45
        Me.TBPotongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Tai Le", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(324, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(316, 32)
        Me.btnClose.TabIndex = 53
        Me.btnClose.Text = "Batal"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1031, 467)
        Me.Panel1.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cbAkunDiskon)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.btnCariAkun)
        Me.GroupBox2.Controls.Add(Me.checkDokumen)
        Me.GroupBox2.Controls.Add(Me.cbKasBiayaLain)
        Me.GroupBox2.Controls.Add(Me.panelDokumen)
        Me.GroupBox2.Controls.Add(Me.tbBiayaLain)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(609, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(403, 429)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(300, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 28)
        Me.Button1.TabIndex = 64
        Me.Button1.Text = "Cari Akun"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbAkunDiskon
        '
        Me.cbAkunDiskon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAkunDiskon.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAkunDiskon.FormattingEnabled = True
        Me.cbAkunDiskon.Items.AddRange(New Object() {"Cash", "E-Money", "Debit"})
        Me.cbAkunDiskon.Location = New System.Drawing.Point(18, 204)
        Me.cbAkunDiskon.Name = "cbAkunDiskon"
        Me.cbAkunDiskon.Size = New System.Drawing.Size(262, 28)
        Me.cbAkunDiskon.TabIndex = 62
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label11.Location = New System.Drawing.Point(18, 178)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 20)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "Akun Diskon :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnCariAkun
        '
        Me.btnCariAkun.Location = New System.Drawing.Point(300, 136)
        Me.btnCariAkun.Name = "btnCariAkun"
        Me.btnCariAkun.Size = New System.Drawing.Size(86, 28)
        Me.btnCariAkun.TabIndex = 61
        Me.btnCariAkun.Text = "Cari Akun"
        Me.btnCariAkun.UseVisualStyleBackColor = True
        '
        'checkDokumen
        '
        Me.checkDokumen.AutoSize = True
        Me.checkDokumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkDokumen.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.checkDokumen.Location = New System.Drawing.Point(14, 245)
        Me.checkDokumen.Name = "checkDokumen"
        Me.checkDokumen.Size = New System.Drawing.Size(133, 22)
        Me.checkDokumen.TabIndex = 57
        Me.checkDokumen.Text = "Pakai Dokumen"
        Me.checkDokumen.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbLunas)
        Me.GroupBox1.Controls.Add(Me.btnCariAkunTerima)
        Me.GroupBox1.Controls.Add(Me.cbAkunTerima)
        Me.GroupBox1.Controls.Add(Me.tbBayar)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblAkunTerima)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbPajak)
        Me.GroupBox1.Controls.Add(Me.diskonNominal)
        Me.GroupBox1.Controls.Add(Me.tbGrand)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TBPotongan)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TBDiskon)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.tbTotal)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 429)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'cbLunas
        '
        Me.cbLunas.AutoSize = True
        Me.cbLunas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLunas.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbLunas.Location = New System.Drawing.Point(502, 268)
        Me.cbLunas.Name = "cbLunas"
        Me.cbLunas.Size = New System.Drawing.Size(66, 21)
        Me.cbLunas.TabIndex = 70
        Me.cbLunas.Text = "Lunas"
        Me.cbLunas.UseVisualStyleBackColor = True
        '
        'btnCariAkunTerima
        '
        Me.btnCariAkunTerima.Location = New System.Drawing.Point(482, 376)
        Me.btnCariAkunTerima.Name = "btnCariAkunTerima"
        Me.btnCariAkunTerima.Size = New System.Drawing.Size(86, 28)
        Me.btnCariAkunTerima.TabIndex = 69
        Me.btnCariAkunTerima.Text = "Cari Akun"
        Me.btnCariAkunTerima.UseVisualStyleBackColor = True
        '
        'cbAkunTerima
        '
        Me.cbAkunTerima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAkunTerima.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAkunTerima.FormattingEnabled = True
        Me.cbAkunTerima.Items.AddRange(New Object() {"Cash", "E-Money", "Debit"})
        Me.cbAkunTerima.Location = New System.Drawing.Point(20, 376)
        Me.cbAkunTerima.Name = "cbAkunTerima"
        Me.cbAkunTerima.Size = New System.Drawing.Size(438, 28)
        Me.cbAkunTerima.TabIndex = 66
        '
        'tbBayar
        '
        Me.tbBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.tbBayar.Location = New System.Drawing.Point(17, 293)
        Me.tbBayar.Name = "tbBayar"
        Me.tbBayar.Size = New System.Drawing.Size(551, 38)
        Me.tbBayar.TabIndex = 65
        Me.tbBayar.Text = "0"
        Me.tbBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label12.Location = New System.Drawing.Point(16, 262)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 20)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "Pembayaran :"
        '
        'lblAkunTerima
        '
        Me.lblAkunTerima.AutoSize = True
        Me.lblAkunTerima.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAkunTerima.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblAkunTerima.Location = New System.Drawing.Point(16, 344)
        Me.lblAkunTerima.Name = "lblAkunTerima"
        Me.lblAkunTerima.Size = New System.Drawing.Size(143, 20)
        Me.lblAkunTerima.TabIndex = 68
        Me.lblAkunTerima.Text = "Akun Penerimaan :"
        Me.lblAkunTerima.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label10.Location = New System.Drawing.Point(349, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 20)
        Me.Label10.TabIndex = 60
        Me.Label10.Text = "Total Pajak :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(16, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Total :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbPajak
        '
        Me.tbPajak.BackColor = System.Drawing.Color.Yellow
        Me.tbPajak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbPajak.Enabled = False
        Me.tbPajak.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPajak.Location = New System.Drawing.Point(349, 129)
        Me.tbPajak.Name = "tbPajak"
        Me.tbPajak.Size = New System.Drawing.Size(219, 44)
        Me.tbPajak.TabIndex = 58
        Me.tbPajak.Text = "100.000.000"
        Me.tbPajak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'diskonNominal
        '
        Me.diskonNominal.AutoSize = True
        Me.diskonNominal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diskonNominal.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.diskonNominal.Location = New System.Drawing.Point(200, 187)
        Me.diskonNominal.Name = "diskonNominal"
        Me.diskonNominal.Size = New System.Drawing.Size(229, 21)
        Me.diskonNominal.TabIndex = 56
        Me.diskonNominal.Text = "Diskon dalam potongan nominal"
        Me.diskonNominal.UseVisualStyleBackColor = True
        Me.diskonNominal.Visible = False
        '
        'tbGrand
        '
        Me.tbGrand.BackColor = System.Drawing.Color.Yellow
        Me.tbGrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbGrand.Enabled = False
        Me.tbGrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbGrand.Location = New System.Drawing.Point(16, 42)
        Me.tbGrand.Name = "tbGrand"
        Me.tbGrand.Size = New System.Drawing.Size(552, 53)
        Me.tbGrand.TabIndex = 46
        Me.tbGrand.Text = "1.000.000.000.000"
        Me.tbGrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(16, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 20)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Grand Total :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbTotal
        '
        Me.tbTotal.BackColor = System.Drawing.Color.Yellow
        Me.tbTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbTotal.Enabled = False
        Me.tbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTotal.Location = New System.Drawing.Point(16, 129)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(308, 44)
        Me.tbTotal.TabIndex = 1
        Me.tbTotal.Text = "1.000.000.000.000"
        Me.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnClose, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSimpan, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(238, 479)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(643, 38)
        Me.TableLayoutPanel1.TabIndex = 56
        '
        'DialogTransaksiBayar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1031, 551)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogTransaksiBayar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembayaran"
        Me.panelDokumen.ResumeLayout(False)
        Me.panelDokumen.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbKasBiayaLain As ComboBox
    Friend WithEvents panelDokumen As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents TBNoDokumen As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents tbBiayaLain As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TBDiskon As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents TBPotongan As TextBox
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents btnClose As Button
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents diskonNominal As CheckBox
    Friend WithEvents tbGrand As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbTotal As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dtDokumen As MetroFramework.Controls.MetroDateTime
    Friend WithEvents checkDokumen As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbPajak As TextBox
    Friend WithEvents btnCariAkun As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cbAkunDiskon As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbLunas As CheckBox
    Friend WithEvents btnCariAkunTerima As Button
    Friend WithEvents cbAkunTerima As ComboBox
    Friend WithEvents tbBayar As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblAkunTerima As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
