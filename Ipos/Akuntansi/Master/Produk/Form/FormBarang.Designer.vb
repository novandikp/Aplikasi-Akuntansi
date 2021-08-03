<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBarang
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gbFormBarang = New System.Windows.Forms.GroupBox()
        Me.cbPajakJual = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbPajakBeli = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stokMin = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.notsolded = New System.Windows.Forms.RadioButton()
        Me.solded = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbJenis = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBNama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBKode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbFormSatuan = New System.Windows.Forms.GroupBox()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.cbSatuan = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.satuanBefore = New System.Windows.Forms.Label()
        Me.TBJual = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TBBeli = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbKonversi = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TBJenis = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.panelAction = New System.Windows.Forms.Panel()
        Me.btnSelesai = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.buttonTambah = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbFormBarang.SuspendLayout()
        Me.gbFormSatuan.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelAction.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(10, 537)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(0, 0)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(0, -23)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(815, 537)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.gbFormBarang)
        Me.TabPage1.Controls.Add(Me.gbFormSatuan)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.panelAction)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(807, 510)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu Utama"
        '
        'gbFormBarang
        '
        Me.gbFormBarang.Controls.Add(Me.cbPajakJual)
        Me.gbFormBarang.Controls.Add(Me.Label5)
        Me.gbFormBarang.Controls.Add(Me.cbPajakBeli)
        Me.gbFormBarang.Controls.Add(Me.Label1)
        Me.gbFormBarang.Controls.Add(Me.stokMin)
        Me.gbFormBarang.Controls.Add(Me.Label10)
        Me.gbFormBarang.Controls.Add(Me.notsolded)
        Me.gbFormBarang.Controls.Add(Me.solded)
        Me.gbFormBarang.Controls.Add(Me.Label11)
        Me.gbFormBarang.Controls.Add(Me.cbJenis)
        Me.gbFormBarang.Controls.Add(Me.Label4)
        Me.gbFormBarang.Controls.Add(Me.TBNama)
        Me.gbFormBarang.Controls.Add(Me.Label3)
        Me.gbFormBarang.Controls.Add(Me.TBKode)
        Me.gbFormBarang.Controls.Add(Me.Label2)
        Me.gbFormBarang.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbFormBarang.Location = New System.Drawing.Point(15, 11)
        Me.gbFormBarang.Name = "gbFormBarang"
        Me.gbFormBarang.Size = New System.Drawing.Size(409, 262)
        Me.gbFormBarang.TabIndex = 66
        Me.gbFormBarang.TabStop = False
        Me.gbFormBarang.Text = "Data Produk"
        '
        'cbPajakJual
        '
        Me.cbPajakJual.BackColor = System.Drawing.SystemColors.Control
        Me.cbPajakJual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPajakJual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbPajakJual.FormattingEnabled = True
        Me.cbPajakJual.Location = New System.Drawing.Point(88, 158)
        Me.cbPajakJual.Name = "cbPajakJual"
        Me.cbPajakJual.Size = New System.Drawing.Size(231, 22)
        Me.cbPajakJual.TabIndex = 65
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(25, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 14)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Pajak Jual :"
        '
        'cbPajakBeli
        '
        Me.cbPajakBeli.BackColor = System.Drawing.SystemColors.Control
        Me.cbPajakBeli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPajakBeli.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbPajakBeli.FormattingEnabled = True
        Me.cbPajakBeli.Location = New System.Drawing.Point(88, 126)
        Me.cbPajakBeli.Name = "cbPajakBeli"
        Me.cbPajakBeli.Size = New System.Drawing.Size(231, 22)
        Me.cbPajakBeli.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(23, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Pajak Beli : "
        '
        'stokMin
        '
        Me.stokMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stokMin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.stokMin.Location = New System.Drawing.Point(88, 191)
        Me.stokMin.Name = "stokMin"
        Me.stokMin.Size = New System.Drawing.Size(121, 22)
        Me.stokMin.TabIndex = 60
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(5, 188)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 40)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Stok Minimal (Satuan Dasar) : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'notsolded
        '
        Me.notsolded.AutoSize = True
        Me.notsolded.BackColor = System.Drawing.Color.Transparent
        Me.notsolded.Location = New System.Drawing.Point(211, 229)
        Me.notsolded.Name = "notsolded"
        Me.notsolded.Size = New System.Drawing.Size(149, 18)
        Me.notsolded.TabIndex = 44
        Me.notsolded.Text = "Tidak Dijual / discontinue"
        Me.notsolded.UseVisualStyleBackColor = False
        '
        'solded
        '
        Me.solded.AutoSize = True
        Me.solded.BackColor = System.Drawing.Color.Transparent
        Me.solded.Location = New System.Drawing.Point(88, 229)
        Me.solded.Name = "solded"
        Me.solded.Size = New System.Drawing.Size(88, 18)
        Me.solded.TabIndex = 43
        Me.solded.Text = "Masih dijual "
        Me.solded.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(8, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 14)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Status Jual : "
        '
        'cbJenis
        '
        Me.cbJenis.BackColor = System.Drawing.SystemColors.Control
        Me.cbJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJenis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbJenis.FormattingEnabled = True
        Me.cbJenis.Location = New System.Drawing.Point(88, 94)
        Me.cbJenis.Name = "cbJenis"
        Me.cbJenis.Size = New System.Drawing.Size(231, 22)
        Me.cbJenis.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(29, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Kategori : "
        '
        'TBNama
        '
        Me.TBNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBNama.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TBNama.Location = New System.Drawing.Point(88, 63)
        Me.TBNama.Name = "TBNama"
        Me.TBNama.Size = New System.Drawing.Size(231, 22)
        Me.TBNama.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Nama Item :"
        '
        'TBKode
        '
        Me.TBKode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBKode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TBKode.Location = New System.Drawing.Point(88, 32)
        Me.TBKode.Name = "TBKode"
        Me.TBKode.Size = New System.Drawing.Size(231, 22)
        Me.TBKode.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(22, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Kode Item :"
        '
        'gbFormSatuan
        '
        Me.gbFormSatuan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbFormSatuan.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.gbFormSatuan.Controls.Add(Me.btnBatal)
        Me.gbFormSatuan.Controls.Add(Me.cbSatuan)
        Me.gbFormSatuan.Controls.Add(Me.Label9)
        Me.gbFormSatuan.Controls.Add(Me.btnSimpan)
        Me.gbFormSatuan.Controls.Add(Me.satuanBefore)
        Me.gbFormSatuan.Controls.Add(Me.TBJual)
        Me.gbFormSatuan.Controls.Add(Me.Label12)
        Me.gbFormSatuan.Controls.Add(Me.TBBeli)
        Me.gbFormSatuan.Controls.Add(Me.Label13)
        Me.gbFormSatuan.Controls.Add(Me.tbKonversi)
        Me.gbFormSatuan.Controls.Add(Me.Label14)
        Me.gbFormSatuan.Controls.Add(Me.TBJenis)
        Me.gbFormSatuan.Controls.Add(Me.Label15)
        Me.gbFormSatuan.Controls.Add(Me.Label16)
        Me.gbFormSatuan.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbFormSatuan.Location = New System.Drawing.Point(430, 11)
        Me.gbFormSatuan.Name = "gbFormSatuan"
        Me.gbFormSatuan.Size = New System.Drawing.Size(357, 262)
        Me.gbFormSatuan.TabIndex = 65
        Me.gbFormSatuan.TabStop = False
        Me.gbFormSatuan.Text = "Form Satuan Barang"
        '
        'btnBatal
        '
        Me.btnBatal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBatal.BackColor = System.Drawing.SystemColors.Control
        Me.btnBatal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBatal.Image = Global.Ipos.My.Resources.Resources.no_entry__2_1
        Me.btnBatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBatal.Location = New System.Drawing.Point(179, 197)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(79, 36)
        Me.btnBatal.TabIndex = 40
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBatal.UseVisualStyleBackColor = False
        '
        'cbSatuan
        '
        Me.cbSatuan.BackColor = System.Drawing.SystemColors.Control
        Me.cbSatuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSatuan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbSatuan.FormattingEnabled = True
        Me.cbSatuan.Location = New System.Drawing.Point(94, 29)
        Me.cbSatuan.Name = "cbSatuan"
        Me.cbSatuan.Size = New System.Drawing.Size(221, 22)
        Me.cbSatuan.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(100, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(231, 13)
        Me.Label9.TabIndex = 36
        Me.Label9.Text = "*Input satuan mulai dari terkecil hingga terbesar."
        '
        'btnSimpan
        '
        Me.btnSimpan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSimpan.BackColor = System.Drawing.SystemColors.Control
        Me.btnSimpan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSimpan.Image = Global.Ipos.My.Resources.Resources.diskette1
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(94, 197)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(79, 36)
        Me.btnSimpan.TabIndex = 39
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'satuanBefore
        '
        Me.satuanBefore.AutoSize = True
        Me.satuanBefore.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.satuanBefore.Location = New System.Drawing.Point(288, 105)
        Me.satuanBefore.Name = "satuanBefore"
        Me.satuanBefore.Size = New System.Drawing.Size(26, 20)
        Me.satuanBefore.TabIndex = 14
        Me.satuanBefore.Text = "kg"
        '
        'TBJual
        '
        Me.TBJual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBJual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TBJual.Location = New System.Drawing.Point(94, 165)
        Me.TBJual.Name = "TBJual"
        Me.TBJual.Size = New System.Drawing.Size(220, 22)
        Me.TBJual.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 20)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Harga Jual :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBBeli
        '
        Me.TBBeli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBBeli.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TBBeli.Location = New System.Drawing.Point(94, 134)
        Me.TBBeli.Name = "TBBeli"
        Me.TBBeli.Size = New System.Drawing.Size(220, 22)
        Me.TBBeli.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(9, 134)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 20)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Harga Beli :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbKonversi
        '
        Me.tbKonversi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbKonversi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tbKonversi.Location = New System.Drawing.Point(94, 104)
        Me.tbKonversi.Name = "tbKonversi"
        Me.tbKonversi.Size = New System.Drawing.Size(167, 22)
        Me.tbKonversi.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(9, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 20)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Konversi :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TBJenis
        '
        Me.TBJenis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBJenis.Enabled = False
        Me.TBJenis.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TBJenis.Location = New System.Drawing.Point(94, 75)
        Me.TBJenis.Name = "TBJenis"
        Me.TBJenis.Size = New System.Drawing.Size(220, 22)
        Me.TBJenis.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(9, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 20)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Jenis Satuan :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(9, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 20)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Satuan :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(13, 279)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(774, 140)
        Me.DataGridView1.TabIndex = 64
        '
        'panelAction
        '
        Me.panelAction.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.panelAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelAction.Controls.Add(Me.btnSelesai)
        Me.panelAction.Controls.Add(Me.Button3)
        Me.panelAction.Controls.Add(Me.buttonTambah)
        Me.panelAction.Controls.Add(Me.Button15)
        Me.panelAction.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panelAction.Location = New System.Drawing.Point(3, 428)
        Me.panelAction.Name = "panelAction"
        Me.panelAction.Size = New System.Drawing.Size(799, 55)
        Me.panelAction.TabIndex = 63
        '
        'btnSelesai
        '
        Me.btnSelesai.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelesai.BackColor = System.Drawing.SystemColors.Control
        Me.btnSelesai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSelesai.Image = Global.Ipos.My.Resources.Resources.diskette
        Me.btnSelesai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSelesai.Location = New System.Drawing.Point(683, 7)
        Me.btnSelesai.Name = "btnSelesai"
        Me.btnSelesai.Size = New System.Drawing.Size(100, 36)
        Me.btnSelesai.TabIndex = 66
        Me.btnSelesai.Text = "Selesai"
        Me.btnSelesai.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSelesai.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!)
        Me.Button3.Image = Global.Ipos.My.Resources.Resources.pencil__2_
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(128, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 36)
        Me.Button3.TabIndex = 65
        Me.Button3.Text = "Edit"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'buttonTambah
        '
        Me.buttonTambah.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonTambah.BackColor = System.Drawing.SystemColors.Control
        Me.buttonTambah.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!)
        Me.buttonTambah.Image = Global.Ipos.My.Resources.Resources.plus__2_
        Me.buttonTambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonTambah.Location = New System.Drawing.Point(28, 7)
        Me.buttonTambah.Name = "buttonTambah"
        Me.buttonTambah.Size = New System.Drawing.Size(94, 36)
        Me.buttonTambah.TabIndex = 64
        Me.buttonTambah.Text = "Tambah"
        Me.buttonTambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonTambah.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button15.BackColor = System.Drawing.SystemColors.Control
        Me.Button15.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!)
        Me.Button15.Image = Global.Ipos.My.Resources.Resources.no_entry__2_
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button15.Location = New System.Drawing.Point(228, 7)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(94, 36)
        Me.Button15.TabIndex = 63
        Me.Button15.Text = "Hapus"
        Me.Button15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button15.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 483)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(799, 22)
        Me.StatusStrip1.TabIndex = 58
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(169, 17)
        Me.ToolStripStatusLabel3.Text = "[Ctrl +Page Down] Selanjutnya"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(105, 17)
        Me.ToolStripStatusLabel8.Text = "[Ctrl + End] Tutup "
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Image = Global.Ipos.My.Resources.Resources.logout__1_
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(727, 562)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(91, 37)
        Me.Button8.TabIndex = 11
        Me.Button8.Text = "Tutup"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button6.BackColor = System.Drawing.SystemColors.Control
        Me.Button6.Image = Global.Ipos.My.Resources.Resources.diskette
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(9, 562)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(91, 37)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "Simpan"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button7.BackColor = System.Drawing.SystemColors.Control
        Me.Button7.Image = Global.Ipos.My.Resources.Resources.cancel__1_
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(106, 562)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(91, 37)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "Batal"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = False
        '
        'FormBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(814, 514)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Barang"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbFormBarang.ResumeLayout(False)
        Me.gbFormBarang.PerformLayout()
        Me.gbFormSatuan.ResumeLayout(False)
        Me.gbFormSatuan.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelAction.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button8 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents notsolded As RadioButton
    Friend WithEvents solded As RadioButton
    Friend WithEvents Label11 As Label
    Friend WithEvents cbJenis As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TBNama As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TBKode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents stokMin As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ToolStripStatusLabel8 As ToolStripStatusLabel
    Friend WithEvents panelAction As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents gbFormBarang As GroupBox
    Friend WithEvents gbFormSatuan As GroupBox
    Friend WithEvents cbSatuan As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents satuanBefore As Label
    Friend WithEvents TBJual As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TBBeli As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tbKonversi As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TBJenis As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btnSelesai As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents buttonTambah As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents btnBatal As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents cbPajakJual As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbPajakBeli As ComboBox
    Friend WithEvents Label1 As Label
End Class
