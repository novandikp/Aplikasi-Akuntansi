<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatagridGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatagridGroup))
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ListSat = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.MasterCheck = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.TransaksiCheck = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox2 = New System.Windows.Forms.CheckedListBox()
        Me.GudangCheck = New System.Windows.Forms.CheckBox()
        Me.Laporan = New System.Windows.Forms.CheckBox()
        Me.UtilCheck = New System.Windows.Forms.CheckBox()
        Me.CheckedListBox3 = New System.Windows.Forms.CheckedListBox()
        Me.TBpelanggan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.EdtBtn = New System.Windows.Forms.Button()
        Me.AddBtn = New System.Windows.Forms.Button()
        Me.HpsBtn = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel6.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(115, 17)
        Me.ToolStripStatusLabel6.Text = "[CTRL+END] : Keluar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(81, 17)
        Me.ToolStripStatusLabel1.Text = "[F1] : Tambah,"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(62, 17)
        Me.ToolStripStatusLabel2.Text = "[F2] : Edit, "
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(81, 17)
        Me.ToolStripStatusLabel3.Text = "[DEL] : Hapus,"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel4.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel4.Text = "[F11] : Simpan,"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel7, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 30
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel5.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(61, 17)
        Me.ToolStripStatusLabel5.Text = "[F6] : Grid,"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(61, 17)
        Me.ToolStripStatusLabel7.Text = "[Esc] Batal"
        '
        'ListSat
        '
        Me.ListSat.AllowUserToAddRows = False
        Me.ListSat.AllowUserToDeleteRows = False
        Me.ListSat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListSat.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ListSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListSat.EnableHeadersVisualStyles = False
        Me.ListSat.GridColor = System.Drawing.SystemColors.Control
        Me.ListSat.Location = New System.Drawing.Point(400, 16)
        Me.ListSat.MultiSelect = False
        Me.ListSat.Name = "ListSat"
        Me.ListSat.ReadOnly = True
        Me.ListSat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListSat.Size = New System.Drawing.Size(388, 328)
        Me.ListSat.TabIndex = 28
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Controls.Add(Me.MasterCheck)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckedListBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TransaksiCheck)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckedListBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GudangCheck)
        Me.FlowLayoutPanel1.Controls.Add(Me.Laporan)
        Me.FlowLayoutPanel1.Controls.Add(Me.UtilCheck)
        Me.FlowLayoutPanel1.Controls.Add(Me.CheckedListBox3)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(24, 56)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(352, 288)
        Me.FlowLayoutPanel1.TabIndex = 41
        Me.FlowLayoutPanel1.WrapContents = False
        '
        'MasterCheck
        '
        Me.MasterCheck.AutoSize = True
        Me.MasterCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MasterCheck.Location = New System.Drawing.Point(13, 13)
        Me.MasterCheck.Name = "MasterCheck"
        Me.MasterCheck.Size = New System.Drawing.Size(61, 19)
        Me.MasterCheck.TabIndex = 0
        Me.MasterCheck.Text = "Master"
        Me.MasterCheck.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"Supplier", "Satuan", "Kategori", "Merk", "Produk", "Tambah Produk", "Pelanggan", "Level Pelanggan", "Dokter"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(25, 38)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(248, 144)
        Me.CheckedListBox1.TabIndex = 42
        '
        'TransaksiCheck
        '
        Me.TransaksiCheck.AutoSize = True
        Me.TransaksiCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TransaksiCheck.Location = New System.Drawing.Point(13, 188)
        Me.TransaksiCheck.Name = "TransaksiCheck"
        Me.TransaksiCheck.Size = New System.Drawing.Size(76, 19)
        Me.TransaksiCheck.TabIndex = 43
        Me.TransaksiCheck.Text = "Transaksi"
        Me.TransaksiCheck.UseVisualStyleBackColor = True
        '
        'CheckedListBox2
        '
        Me.CheckedListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox2.FormattingEnabled = True
        Me.CheckedListBox2.Items.AddRange(New Object() {"Daftar Beli", "Kulakan", "Retur Pembelian", "Daftar Penjualan", "Penjualan", "Retur Penjualan", "Hutang", "Piutang"})
        Me.CheckedListBox2.Location = New System.Drawing.Point(25, 213)
        Me.CheckedListBox2.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.CheckedListBox2.Name = "CheckedListBox2"
        Me.CheckedListBox2.Size = New System.Drawing.Size(248, 144)
        Me.CheckedListBox2.TabIndex = 44
        '
        'GudangCheck
        '
        Me.GudangCheck.AutoSize = True
        Me.GudangCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GudangCheck.Location = New System.Drawing.Point(13, 363)
        Me.GudangCheck.Name = "GudangCheck"
        Me.GudangCheck.Size = New System.Drawing.Size(98, 19)
        Me.GudangCheck.TabIndex = 45
        Me.GudangCheck.Text = "Stok Opname"
        Me.GudangCheck.UseVisualStyleBackColor = True
        '
        'Laporan
        '
        Me.Laporan.AutoSize = True
        Me.Laporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Laporan.Location = New System.Drawing.Point(13, 388)
        Me.Laporan.Name = "Laporan"
        Me.Laporan.Size = New System.Drawing.Size(69, 19)
        Me.Laporan.TabIndex = 46
        Me.Laporan.Text = "Laporan"
        Me.Laporan.UseVisualStyleBackColor = True
        '
        'UtilCheck
        '
        Me.UtilCheck.AutoSize = True
        Me.UtilCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UtilCheck.Location = New System.Drawing.Point(13, 413)
        Me.UtilCheck.Name = "UtilCheck"
        Me.UtilCheck.Size = New System.Drawing.Size(60, 19)
        Me.UtilCheck.TabIndex = 47
        Me.UtilCheck.Text = "Utilitas"
        Me.UtilCheck.UseVisualStyleBackColor = True
        '
        'CheckedListBox3
        '
        Me.CheckedListBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox3.FormattingEnabled = True
        Me.CheckedListBox3.Items.AddRange(New Object() {"Identitas", "User dan Cabang", "Role", "Backup", "Restore ", "Reset"})
        Me.CheckedListBox3.Location = New System.Drawing.Point(25, 438)
        Me.CheckedListBox3.Margin = New System.Windows.Forms.Padding(15, 3, 3, 30)
        Me.CheckedListBox3.Name = "CheckedListBox3"
        Me.CheckedListBox3.Size = New System.Drawing.Size(248, 96)
        Me.CheckedListBox3.TabIndex = 48
        '
        'TBpelanggan
        '
        Me.TBpelanggan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBpelanggan.Location = New System.Drawing.Point(104, 16)
        Me.TBpelanggan.Name = "TBpelanggan"
        Me.TBpelanggan.Size = New System.Drawing.Size(272, 20)
        Me.TBpelanggan.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(32, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Nama Role :"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Image = Global.Ipos.My.Resources.Resources.no_entry_sign
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(304, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 36)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "Batal"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnSimpan
        '
        Me.btnSimpan.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSimpan.BackColor = System.Drawing.SystemColors.Control
        Me.btnSimpan.Image = Global.Ipos.My.Resources.Resources.diskette
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(208, 368)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(86, 36)
        Me.btnSimpan.TabIndex = 44
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'EdtBtn
        '
        Me.EdtBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.EdtBtn.BackColor = System.Drawing.SystemColors.Control
        Me.EdtBtn.Image = Global.Ipos.My.Resources.Resources.pencil__2_
        Me.EdtBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EdtBtn.Location = New System.Drawing.Point(477, 368)
        Me.EdtBtn.Name = "EdtBtn"
        Me.EdtBtn.Size = New System.Drawing.Size(79, 36)
        Me.EdtBtn.TabIndex = 40
        Me.EdtBtn.Text = "Edit"
        Me.EdtBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EdtBtn.UseVisualStyleBackColor = False
        '
        'AddBtn
        '
        Me.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.AddBtn.BackColor = System.Drawing.SystemColors.Control
        Me.AddBtn.Image = Global.Ipos.My.Resources.Resources.plus__2_
        Me.AddBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.AddBtn.Location = New System.Drawing.Point(392, 368)
        Me.AddBtn.Name = "AddBtn"
        Me.AddBtn.Size = New System.Drawing.Size(79, 36)
        Me.AddBtn.TabIndex = 39
        Me.AddBtn.Text = "Tambah"
        Me.AddBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.AddBtn.UseVisualStyleBackColor = False
        '
        'HpsBtn
        '
        Me.HpsBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.HpsBtn.BackColor = System.Drawing.SystemColors.Control
        Me.HpsBtn.Image = Global.Ipos.My.Resources.Resources.no_entry__2_
        Me.HpsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.HpsBtn.Location = New System.Drawing.Point(562, 368)
        Me.HpsBtn.Name = "HpsBtn"
        Me.HpsBtn.Size = New System.Drawing.Size(79, 36)
        Me.HpsBtn.TabIndex = 31
        Me.HpsBtn.Text = "Hapus"
        Me.HpsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.HpsBtn.UseVisualStyleBackColor = False
        '
        'DatagridGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.TBpelanggan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.EdtBtn)
        Me.Controls.Add(Me.AddBtn)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListSat)
        Me.Controls.Add(Me.HpsBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DatagridGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hak Akses"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EdtBtn As Button
    Friend WithEvents AddBtn As Button
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ListSat As DataGridView
    Friend WithEvents HpsBtn As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents MasterCheck As CheckBox
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents TransaksiCheck As CheckBox
    Friend WithEvents CheckedListBox2 As CheckedListBox
    Friend WithEvents GudangCheck As CheckBox
    Friend WithEvents Laporan As CheckBox
    Friend WithEvents UtilCheck As CheckBox
    Friend WithEvents CheckedListBox3 As CheckedListBox
    Friend WithEvents TBpelanggan As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolStripStatusLabel7 As ToolStripStatusLabel
End Class
