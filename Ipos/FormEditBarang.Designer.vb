<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditBarang
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.notsolded = New System.Windows.Forms.RadioButton()
        Me.solded = New System.Windows.Forms.RadioButton()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnEdt = New System.Windows.Forms.Button()
        Me.btnTmbh = New System.Windows.Forms.Button()
        Me.BtnHps = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TBPajak = New System.Windows.Forms.TextBox()
        Me.TBRak = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbMerk = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBNama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cbJenis = New System.Windows.Forms.ComboBox()
        Me.dgvSatuanBarang = New System.Windows.Forms.DataGridView()
        Me.TBKode = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblBagiHasil = New System.Windows.Forms.Label()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.edtBagiHasil = New System.Windows.Forms.TextBox()
        Me.stokMin = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.edtHargaJasa = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.AddBtn = New System.Windows.Forms.Button()
        Me.Flex1 = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.persenBagiHasil = New System.Windows.Forms.Label()
        CType(Me.dgvSatuanBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'notsolded
        '
        Me.notsolded.AutoSize = True
        Me.notsolded.BackColor = System.Drawing.Color.Transparent
        Me.notsolded.Location = New System.Drawing.Point(453, 214)
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
        Me.solded.Location = New System.Drawing.Point(97, 214)
        Me.solded.Name = "solded"
        Me.solded.Size = New System.Drawing.Size(88, 18)
        Me.solded.TabIndex = 43
        Me.solded.Text = "Masih dijual "
        Me.solded.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button10.BackColor = System.Drawing.SystemColors.Control
        Me.Button10.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Image = Global.Ipos.My.Resources.Resources.no_entry__2_
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(176, 623)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(106, 34)
        Me.Button10.TabIndex = 14
        Me.Button10.Text = "Hapus Satuan"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button11.BackColor = System.Drawing.SystemColors.Control
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button11.Image = Global.Ipos.My.Resources.Resources.logout__1_
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(687, 445)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(91, 37)
        Me.Button11.TabIndex = 22
        Me.Button11.Text = "Tutup"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button13.BackColor = System.Drawing.SystemColors.Control
        Me.Button13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button13.Image = Global.Ipos.My.Resources.Resources.diskette
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button13.Location = New System.Drawing.Point(140, 445)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(100, 36)
        Me.Button13.TabIndex = 21
        Me.Button13.Text = "Simpan"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.BackColor = System.Drawing.SystemColors.Control
        Me.Button8.Image = Global.Ipos.My.Resources.Resources.logout__1_
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(722, 534)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(91, 37)
        Me.Button8.TabIndex = 20
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
        Me.Button6.Location = New System.Drawing.Point(7, 534)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(91, 37)
        Me.Button6.TabIndex = 18
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
        Me.Button7.Location = New System.Drawing.Point(104, 534)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(91, 37)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "Batal"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = False
        '
        'btnEdt
        '
        Me.btnEdt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdt.BackColor = System.Drawing.SystemColors.Control
        Me.btnEdt.Image = Global.Ipos.My.Resources.Resources.pencil__2_
        Me.btnEdt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdt.Location = New System.Drawing.Point(100, 0)
        Me.btnEdt.Name = "btnEdt"
        Me.btnEdt.Size = New System.Drawing.Size(94, 36)
        Me.btnEdt.TabIndex = 30
        Me.btnEdt.Text = "Edit"
        Me.btnEdt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdt.UseVisualStyleBackColor = False
        '
        'btnTmbh
        '
        Me.btnTmbh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTmbh.BackColor = System.Drawing.SystemColors.Control
        Me.btnTmbh.Image = Global.Ipos.My.Resources.Resources.plus__2_
        Me.btnTmbh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTmbh.Location = New System.Drawing.Point(0, 0)
        Me.btnTmbh.Name = "btnTmbh"
        Me.btnTmbh.Size = New System.Drawing.Size(94, 36)
        Me.btnTmbh.TabIndex = 29
        Me.btnTmbh.Text = "Tambah"
        Me.btnTmbh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTmbh.UseVisualStyleBackColor = False
        '
        'BtnHps
        '
        Me.BtnHps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnHps.BackColor = System.Drawing.SystemColors.Control
        Me.BtnHps.Image = Global.Ipos.My.Resources.Resources.no_entry__2_
        Me.BtnHps.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnHps.Location = New System.Drawing.Point(200, 0)
        Me.BtnHps.Name = "BtnHps"
        Me.BtnHps.Size = New System.Drawing.Size(94, 36)
        Me.BtnHps.TabIndex = 28
        Me.BtnHps.Text = "Hapus"
        Me.BtnHps.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnHps.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button9.BackColor = System.Drawing.SystemColors.Control
        Me.Button9.Image = Global.Ipos.My.Resources.Resources.settings__2_
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button9.Location = New System.Drawing.Point(6, 623)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(164, 34)
        Me.Button9.TabIndex = 13
        Me.Button9.Text = "Hitung Harga Pokok Dasar"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(26, 215)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 14)
        Me.Label11.TabIndex = 42
        Me.Label11.Text = "Status Jual : "
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(372, 640)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 14)
        Me.Label27.TabIndex = 18
        Me.Label27.Text = "memenuhi kriteria."
        '
        'CheckBox3
        '
        Me.CheckBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(356, 633)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox3.TabIndex = 16
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(8, 495)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(0, 0)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(688, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 14)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "%"
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(476, 265)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Pajak Include :"
        Me.Label8.Visible = False
        '
        'TBPajak
        '
        Me.TBPajak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBPajak.Enabled = False
        Me.TBPajak.Location = New System.Drawing.Point(555, 261)
        Me.TBPajak.Name = "TBPajak"
        Me.TBPajak.Size = New System.Drawing.Size(121, 22)
        Me.TBPajak.TabIndex = 36
        Me.TBPajak.Text = "0"
        Me.TBPajak.Visible = False
        '
        'TBRak
        '
        Me.TBRak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBRak.Location = New System.Drawing.Point(97, 138)
        Me.TBRak.Name = "TBRak"
        Me.TBRak.Size = New System.Drawing.Size(121, 22)
        Me.TBRak.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(61, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 14)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Rak : "
        '
        'cbMerk
        '
        Me.cbMerk.BackColor = System.Drawing.SystemColors.Control
        Me.cbMerk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMerk.FormattingEnabled = True
        Me.cbMerk.Location = New System.Drawing.Point(453, 107)
        Me.cbMerk.Name = "cbMerk"
        Me.cbMerk.Size = New System.Drawing.Size(121, 22)
        Me.cbMerk.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(410, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Merek : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(38, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 14)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Kategori : "
        '
        'TBNama
        '
        Me.TBNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBNama.Location = New System.Drawing.Point(97, 76)
        Me.TBNama.Name = "TBNama"
        Me.TBNama.Size = New System.Drawing.Size(503, 22)
        Me.TBNama.TabIndex = 26
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(25, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Nama Item :"
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(372, 625)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(188, 14)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "Menggunakan harga pokok jika tidak "
        '
        'cbJenis
        '
        Me.cbJenis.BackColor = System.Drawing.SystemColors.Control
        Me.cbJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJenis.FormattingEnabled = True
        Me.cbJenis.Location = New System.Drawing.Point(97, 107)
        Me.cbJenis.Name = "cbJenis"
        Me.cbJenis.Size = New System.Drawing.Size(121, 22)
        Me.cbJenis.TabIndex = 28
        '
        'dgvSatuanBarang
        '
        Me.dgvSatuanBarang.AllowUserToAddRows = False
        Me.dgvSatuanBarang.AllowUserToDeleteRows = False
        Me.dgvSatuanBarang.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSatuanBarang.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSatuanBarang.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSatuanBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSatuanBarang.EnableHeadersVisualStyles = False
        Me.dgvSatuanBarang.Location = New System.Drawing.Point(3, 5)
        Me.dgvSatuanBarang.Name = "dgvSatuanBarang"
        Me.dgvSatuanBarang.ReadOnly = True
        Me.dgvSatuanBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSatuanBarang.Size = New System.Drawing.Size(797, 339)
        Me.dgvSatuanBarang.TabIndex = 11
        '
        'TBKode
        '
        Me.TBKode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBKode.Location = New System.Drawing.Point(97, 45)
        Me.TBKode.Name = "TBKode"
        Me.TBKode.Size = New System.Drawing.Size(203, 22)
        Me.TBKode.TabIndex = 24
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.TabPage2.BackgroundImage = Global.Ipos.My.Resources.Resources.bgform
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Button12)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.Button13)
        Me.TabPage2.Controls.Add(Me.Button11)
        Me.TabPage2.Controls.Add(Me.StatusStrip2)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.CheckBox3)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.dgvSatuanBarang)
        Me.TabPage2.Controls.Add(Me.Button10)
        Me.TabPage2.Controls.Add(Me.Button9)
        Me.TabPage2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(804, 524)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Satuan"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnTmbh)
        Me.Panel1.Controls.Add(Me.btnEdt)
        Me.Panel1.Controls.Add(Me.BtnHps)
        Me.Panel1.Location = New System.Drawing.Point(253, 400)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(294, 40)
        Me.Panel1.TabIndex = 60
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button12.BackColor = System.Drawing.SystemColors.Control
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button12.Location = New System.Drawing.Point(28, 445)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(108, 36)
        Me.Button12.TabIndex = 59
        Me.Button12.Text = "Sebelumnya"
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(485, 372)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(310, 15)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = " Dari konversi pertama hingga konversi terakhir"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(480, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(315, 15)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Input satuan mulai dari terkecil hingga terbesar."
        '
        'StatusStrip2
        '
        Me.StatusStrip2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel7})
        Me.StatusStrip2.Location = New System.Drawing.Point(3, 499)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(798, 22)
        Me.StatusStrip2.TabIndex = 31
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(72, 17)
        Me.ToolStripStatusLabel4.Text = "[F1] Tambah"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(50, 17)
        Me.ToolStripStatusLabel5.Text = "[F2] Edit"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(69, 17)
        Me.ToolStripStatusLabel6.Text = "[Del] Hapus"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(79, 17)
        Me.ToolStripStatusLabel2.Text = "[F11] Simpan,"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(96, 17)
        Me.ToolStripStatusLabel3.Text = "[Ctrl+end] Tutup"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(160, 17)
        Me.ToolStripStatusLabel7.Text = "[Ctrl + Page Up] Sebelumnya"
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(302, 633)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 14)
        Me.Label25.TabIndex = 15
        Me.Label25.Text = "Default :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(31, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Kode Item :"
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.TabPage1.BackgroundImage = Global.Ipos.My.Resources.Resources.bgform
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.persenBagiHasil)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.lblBagiHasil)
        Me.TabPage1.Controls.Add(Me.Button14)
        Me.TabPage1.Controls.Add(Me.edtBagiHasil)
        Me.TabPage1.Controls.Add(Me.stokMin)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.edtHargaJasa)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.AddBtn)
        Me.TabPage1.Controls.Add(Me.Flex1)
        Me.TabPage1.Controls.Add(Me.StatusStrip1)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.notsolded)
        Me.TabPage1.Controls.Add(Me.solded)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.TBPajak)
        Me.TabPage1.Controls.Add(Me.TBRak)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cbMerk)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cbJenis)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.TBNama)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.TBKode)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(804, 524)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Menu Utama"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(28, 445)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(108, 36)
        Me.Button3.TabIndex = 74
        Me.Button3.Text = "Simpan"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'lblBagiHasil
        '
        Me.lblBagiHasil.AutoSize = True
        Me.lblBagiHasil.BackColor = System.Drawing.Color.Transparent
        Me.lblBagiHasil.Location = New System.Drawing.Point(30, 142)
        Me.lblBagiHasil.Name = "lblBagiHasil"
        Me.lblBagiHasil.Size = New System.Drawing.Size(64, 14)
        Me.lblBagiHasil.TabIndex = 73
        Me.lblBagiHasil.Text = "Bagi Hasil : "
        '
        'Button14
        '
        Me.Button14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button14.BackColor = System.Drawing.SystemColors.Control
        Me.Button14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button14.Image = Global.Ipos.My.Resources.Resources.logout__1_
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button14.Location = New System.Drawing.Point(687, 445)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(91, 37)
        Me.Button14.TabIndex = 66
        Me.Button14.Text = "Tutup"
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button14.UseVisualStyleBackColor = False
        '
        'edtBagiHasil
        '
        Me.edtBagiHasil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.edtBagiHasil.Location = New System.Drawing.Point(96, 138)
        Me.edtBagiHasil.MaxLength = 3
        Me.edtBagiHasil.Name = "edtBagiHasil"
        Me.edtBagiHasil.Size = New System.Drawing.Size(45, 22)
        Me.edtBagiHasil.TabIndex = 72
        '
        'stokMin
        '
        Me.stokMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stokMin.Location = New System.Drawing.Point(97, 176)
        Me.stokMin.Name = "stokMin"
        Me.stokMin.Size = New System.Drawing.Size(45, 22)
        Me.stokMin.TabIndex = 64
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(14, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 40)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Stok Minimal (Satuan Dasar) : "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'edtHargaJasa
        '
        Me.edtHargaJasa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.edtHargaJasa.Location = New System.Drawing.Point(96, 104)
        Me.edtHargaJasa.Name = "edtHargaJasa"
        Me.edtHargaJasa.Size = New System.Drawing.Size(152, 22)
        Me.edtHargaJasa.TabIndex = 70
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(49, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 14)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Harga : "
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Image = Global.Ipos.My.Resources.Resources.plus__2_
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(576, 105)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 26)
        Me.Button2.TabIndex = 63
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'AddBtn
        '
        Me.AddBtn.BackColor = System.Drawing.SystemColors.Control
        Me.AddBtn.Image = Global.Ipos.My.Resources.Resources.plus__2_
        Me.AddBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddBtn.Location = New System.Drawing.Point(224, 105)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(26, 26)
        Me.AddBtn.TabIndex = 62
        Me.AddBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddBtn.UseVisualStyleBackColor = False
        '
        'Flex1
        '
        Me.Flex1.AutoSize = True
        Me.Flex1.BackColor = System.Drawing.Color.Transparent
        Me.Flex1.Checked = True
        Me.Flex1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Flex1.Location = New System.Drawing.Point(409, 144)
        Me.Flex1.Name = "Flex1"
        Me.Flex1.Size = New System.Drawing.Size(193, 18)
        Me.Flex1.TabIndex = 60
        Me.Flex1.Text = "Flexible (Bisa merubah Harga Jual)"
        Me.Flex1.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel8})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 497)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(796, 22)
        Me.StatusStrip1.TabIndex = 61
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(171, 17)
        Me.ToolStripStatusLabel1.Text = "[Ctrl + Page down] Selanjutnya"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabel8.Text = "[Ctrl + End] Tutup"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(28, 445)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 36)
        Me.Button1.TabIndex = 60
        Me.Button1.Text = "Selanjutnya"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, -23)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(812, 551)
        Me.TabControl1.TabIndex = 15
        '
        'persenBagiHasil
        '
        Me.persenBagiHasil.AutoSize = True
        Me.persenBagiHasil.BackColor = System.Drawing.Color.Transparent
        Me.persenBagiHasil.Font = New System.Drawing.Font("Microsoft PhagsPa", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.persenBagiHasil.Location = New System.Drawing.Point(144, 139)
        Me.persenBagiHasil.Name = "persenBagiHasil"
        Me.persenBagiHasil.Size = New System.Drawing.Size(23, 21)
        Me.persenBagiHasil.TabIndex = 75
        Me.persenBagiHasil.Text = "%"
        '
        'FormEditBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(811, 528)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEditBarang"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Barang"
        CType(Me.dgvSatuanBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents notsolded As RadioButton
    Friend WithEvents solded As RadioButton
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents btnEdt As Button
    Friend WithEvents btnTmbh As Button
    Friend WithEvents BtnHps As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TBPajak As TextBox
    Friend WithEvents TBRak As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbMerk As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TBNama As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents cbJenis As ComboBox
    Friend WithEvents dgvSatuanBarang As DataGridView
    Friend WithEvents TBKode As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents Label25 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button12 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Flex1 As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents AddBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents stokMin As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Button14 As Button
    Friend WithEvents ToolStripStatusLabel8 As ToolStripStatusLabel
    Friend WithEvents lblBagiHasil As Label
    Friend WithEvents edtBagiHasil As TextBox
    Friend WithEvents edtHargaJasa As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents persenBagiHasil As Label
End Class
