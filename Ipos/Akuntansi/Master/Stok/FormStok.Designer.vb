<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStok
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.jumlahFisik = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbAkun = New MetroFramework.Controls.MetroComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.jumlahBuku = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtTanggal = New MetroFramework.Controls.MetroDateTime()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.eCari = New MetroFramework.Controls.MetroTextBox()
        Me.ListSat = New MetroFramework.Controls.MetroGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbForm = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbDepartemen = New MetroFramework.Controls.MetroComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.hpp = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.cbGudang = New MetroFramework.Controls.MetroComboBox()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbForm.SuspendLayout()
        Me.gbData.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(13, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Tambahan"
        '
        'jumlahFisik
        '
        Me.jumlahFisik.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jumlahFisik.Location = New System.Drawing.Point(13, 165)
        Me.jumlahFisik.Name = "jumlahFisik"
        Me.jumlahFisik.Size = New System.Drawing.Size(291, 29)
        Me.jumlahFisik.TabIndex = 44
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button4.Location = New System.Drawing.Point(235, 288)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 29)
        Me.Button4.TabIndex = 43
        Me.Button4.Text = "Cari"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(15, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 17)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Akun"
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.ItemHeight = 23
        Me.cbAkun.Location = New System.Drawing.Point(16, 289)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(217, 29)
        Me.cbAkun.TabIndex = 39
        Me.cbAkun.UseSelectable = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label5.Location = New System.Drawing.Point(13, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Jumlah Saat ini"
        '
        'jumlahBuku
        '
        Me.jumlahBuku.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jumlahBuku.Location = New System.Drawing.Point(13, 103)
        Me.jumlahBuku.Name = "jumlahBuku"
        Me.jumlahBuku.ReadOnly = True
        Me.jumlahBuku.Size = New System.Drawing.Size(291, 29)
        Me.jumlahBuku.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label4.Location = New System.Drawing.Point(13, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Tanggal"
        '
        'dtTanggal
        '
        Me.dtTanggal.Location = New System.Drawing.Point(12, 42)
        Me.dtTanggal.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtTanggal.Name = "dtTanggal"
        Me.dtTanggal.Size = New System.Drawing.Size(292, 29)
        Me.dtTanggal.TabIndex = 35
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(91, 17)
        Me.ToolStripStatusLabel1.Text = "[F1] : Cari Akun,"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 483)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(967, 22)
        Me.StatusStrip1.TabIndex = 102
        Me.StatusStrip1.Text = "StatusStrip1"
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
        'eCari
        '
        '
        '
        '
        Me.eCari.CustomButton.Image = Nothing
        Me.eCari.CustomButton.Location = New System.Drawing.Point(471, 2)
        Me.eCari.CustomButton.Name = ""
        Me.eCari.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.eCari.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.eCari.CustomButton.TabIndex = 1
        Me.eCari.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.eCari.CustomButton.UseSelectable = True
        Me.eCari.CustomButton.Visible = False
        Me.eCari.Lines = New String(-1) {}
        Me.eCari.Location = New System.Drawing.Point(116, 33)
        Me.eCari.MaxLength = 32767
        Me.eCari.Name = "eCari"
        Me.eCari.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.eCari.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.eCari.SelectedText = ""
        Me.eCari.SelectionLength = 0
        Me.eCari.SelectionStart = 0
        Me.eCari.ShortcutsEnabled = True
        Me.eCari.Size = New System.Drawing.Size(489, 20)
        Me.eCari.TabIndex = 66
        Me.eCari.UseSelectable = True
        Me.eCari.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.eCari.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'ListSat
        '
        Me.ListSat.AllowUserToAddRows = False
        Me.ListSat.AllowUserToDeleteRows = False
        Me.ListSat.AllowUserToResizeRows = False
        Me.ListSat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListSat.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListSat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListSat.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.ListSat.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ListSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListSat.DefaultCellStyle = DataGridViewCellStyle2
        Me.ListSat.EnableHeadersVisualStyles = False
        Me.ListSat.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ListSat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListSat.Location = New System.Drawing.Point(17, 109)
        Me.ListSat.MultiSelect = False
        Me.ListSat.Name = "ListSat"
        Me.ListSat.ReadOnly = True
        Me.ListSat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ListSat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ListSat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListSat.Size = New System.Drawing.Size(588, 340)
        Me.ListSat.TabIndex = 65
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(17, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Kata Kunci : "
        '
        'gbForm
        '
        Me.gbForm.Controls.Add(Me.Label7)
        Me.gbForm.Controls.Add(Me.cbDepartemen)
        Me.gbForm.Controls.Add(Me.Label6)
        Me.gbForm.Controls.Add(Me.hpp)
        Me.gbForm.Controls.Add(Me.Button2)
        Me.gbForm.Controls.Add(Me.Label2)
        Me.gbForm.Controls.Add(Me.jumlahFisik)
        Me.gbForm.Controls.Add(Me.Button4)
        Me.gbForm.Controls.Add(Me.Button1)
        Me.gbForm.Controls.Add(Me.btnSimpan)
        Me.gbForm.Controls.Add(Me.Label8)
        Me.gbForm.Controls.Add(Me.cbAkun)
        Me.gbForm.Controls.Add(Me.Label5)
        Me.gbForm.Controls.Add(Me.jumlahBuku)
        Me.gbForm.Controls.Add(Me.Label4)
        Me.gbForm.Controls.Add(Me.dtTanggal)
        Me.gbForm.Location = New System.Drawing.Point(646, 0)
        Me.gbForm.Name = "gbForm"
        Me.gbForm.Size = New System.Drawing.Size(309, 465)
        Me.gbForm.TabIndex = 104
        Me.gbForm.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label7.Location = New System.Drawing.Point(19, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 17)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Departemen"
        '
        'cbDepartemen
        '
        Me.cbDepartemen.FormattingEnabled = True
        Me.cbDepartemen.ItemHeight = 23
        Me.cbDepartemen.Location = New System.Drawing.Point(17, 353)
        Me.cbDepartemen.Name = "cbDepartemen"
        Me.cbDepartemen.Size = New System.Drawing.Size(288, 29)
        Me.cbDepartemen.TabIndex = 51
        Me.cbDepartemen.UseSelectable = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label6.Location = New System.Drawing.Point(16, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(157, 17)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Harga Pokok Penjualan"
        '
        'hpp
        '
        Me.hpp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hpp.Location = New System.Drawing.Point(16, 230)
        Me.hpp.Name = "hpp"
        Me.hpp.Size = New System.Drawing.Size(291, 29)
        Me.hpp.TabIndex = 49
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button2.Location = New System.Drawing.Point(238, 345)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(0, 0)
        Me.Button2.TabIndex = 48
        Me.Button2.Text = "Cari"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Image = Global.Ipos.My.Resources.Resources.no_entry__2_
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(224, 403)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 36)
        Me.Button1.TabIndex = 41
        Me.Button1.Text = "Batal"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnSimpan
        '
        Me.btnSimpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSimpan.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSimpan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSimpan.Image = Global.Ipos.My.Resources.Resources.diskette
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(17, 403)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(79, 36)
        Me.btnSimpan.TabIndex = 42
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'cbGudang
        '
        Me.cbGudang.FormattingEnabled = True
        Me.cbGudang.ItemHeight = 23
        Me.cbGudang.Location = New System.Drawing.Point(116, 68)
        Me.cbGudang.Name = "cbGudang"
        Me.cbGudang.Size = New System.Drawing.Size(217, 29)
        Me.cbGudang.TabIndex = 46
        Me.cbGudang.UseSelectable = True
        '
        'gbData
        '
        Me.gbData.Controls.Add(Me.Label9)
        Me.gbData.Controls.Add(Me.eCari)
        Me.gbData.Controls.Add(Me.ListSat)
        Me.gbData.Controls.Add(Me.Label1)
        Me.gbData.Controls.Add(Me.cbGudang)
        Me.gbData.Location = New System.Drawing.Point(12, 0)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(622, 465)
        Me.gbData.TabIndex = 103
        Me.gbData.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label9.Location = New System.Drawing.Point(17, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Gudang : "
        '
        'FormStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(967, 505)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbForm)
        Me.Controls.Add(Me.gbData)
        Me.Name = "FormStok"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DatagridStokOpname"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbForm.ResumeLayout(False)
        Me.gbForm.PerformLayout()
        Me.gbData.ResumeLayout(False)
        Me.gbData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents jumlahFisik As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents cbAkun As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents jumlahBuku As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtTanggal As MetroFramework.Controls.MetroDateTime
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents eCari As MetroFramework.Controls.MetroTextBox
    Friend WithEvents ListSat As MetroFramework.Controls.MetroGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents gbForm As GroupBox
    Friend WithEvents gbData As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbDepartemen As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents hpp As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents cbGudang As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label9 As Label
End Class
