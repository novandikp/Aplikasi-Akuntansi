<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DetailPiutangUsaha
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListDetail = New MetroFramework.Controls.MetroGrid()
        Me.eCari = New MetroFramework.Controls.MetroTextBox()
        Me.ListSat = New MetroFramework.Controls.MetroGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbForm = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbAkun = New MetroFramework.Controls.MetroComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbProjek = New MetroFramework.Controls.MetroComboBox()
        Me.cbDepartemen = New MetroFramework.Controls.MetroComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.jumlahPiutang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpPenghapusan = New MetroFramework.Controls.MetroDateTime()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbKode = New System.Windows.Forms.TextBox()
        Me.gbData.SuspendLayout()
        CType(Me.ListDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.gbForm.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbData
        '
        Me.gbData.Controls.Add(Me.Label2)
        Me.gbData.Controls.Add(Me.ListDetail)
        Me.gbData.Controls.Add(Me.eCari)
        Me.gbData.Controls.Add(Me.ListSat)
        Me.gbData.Controls.Add(Me.Label1)
        Me.gbData.Location = New System.Drawing.Point(12, 0)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(743, 502)
        Me.gbData.TabIndex = 100
        Me.gbData.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(20, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Refrensi : "
        '
        'ListDetail
        '
        Me.ListDetail.AllowUserToAddRows = False
        Me.ListDetail.AllowUserToDeleteRows = False
        Me.ListDetail.AllowUserToResizeRows = False
        Me.ListDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListDetail.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListDetail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.ListDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.ListDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListDetail.DefaultCellStyle = DataGridViewCellStyle14
        Me.ListDetail.EnableHeadersVisualStyles = False
        Me.ListDetail.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ListDetail.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListDetail.Location = New System.Drawing.Point(20, 295)
        Me.ListDetail.MultiSelect = False
        Me.ListDetail.Name = "ListDetail"
        Me.ListDetail.ReadOnly = True
        Me.ListDetail.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.ListDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ListDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListDetail.Size = New System.Drawing.Size(705, 194)
        Me.ListDetail.TabIndex = 70
        '
        'eCari
        '
        '
        '
        '
        Me.eCari.CustomButton.Image = Nothing
        Me.eCari.CustomButton.Location = New System.Drawing.Point(505, 2)
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
        Me.eCari.Size = New System.Drawing.Size(523, 20)
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
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.ListSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListSat.DefaultCellStyle = DataGridViewCellStyle17
        Me.ListSat.EnableHeadersVisualStyles = False
        Me.ListSat.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ListSat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListSat.Location = New System.Drawing.Point(20, 75)
        Me.ListSat.MultiSelect = False
        Me.ListSat.Name = "ListSat"
        Me.ListSat.ReadOnly = True
        Me.ListSat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.ListSat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ListSat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListSat.Size = New System.Drawing.Size(705, 177)
        Me.ListSat.TabIndex = 65
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(20, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 69
        Me.Label1.Text = "Kata Kunci : "
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 522)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1115, 22)
        Me.StatusStrip1.TabIndex = 98
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(102, 17)
        Me.ToolStripStatusLabel1.Text = "[F1] : Cari Refrensi"
        '
        'gbForm
        '
        Me.gbForm.Controls.Add(Me.Button4)
        Me.gbForm.Controls.Add(Me.Button1)
        Me.gbForm.Controls.Add(Me.btnSimpan)
        Me.gbForm.Controls.Add(Me.Label8)
        Me.gbForm.Controls.Add(Me.cbAkun)
        Me.gbForm.Controls.Add(Me.Label7)
        Me.gbForm.Controls.Add(Me.Label6)
        Me.gbForm.Controls.Add(Me.cbProjek)
        Me.gbForm.Controls.Add(Me.cbDepartemen)
        Me.gbForm.Controls.Add(Me.Label5)
        Me.gbForm.Controls.Add(Me.jumlahPiutang)
        Me.gbForm.Controls.Add(Me.Label4)
        Me.gbForm.Controls.Add(Me.dtpPenghapusan)
        Me.gbForm.Controls.Add(Me.Label3)
        Me.gbForm.Controls.Add(Me.tbKode)
        Me.gbForm.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbForm.Location = New System.Drawing.Point(771, 4)
        Me.gbForm.Name = "gbForm"
        Me.gbForm.Size = New System.Drawing.Size(330, 498)
        Me.gbForm.TabIndex = 101
        Me.gbForm.TabStop = False
        Me.gbForm.Text = "Penghapusan Utang"
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button4.Location = New System.Drawing.Point(256, 357)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(68, 29)
        Me.Button4.TabIndex = 34
        Me.Button4.Text = "Cari"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Button1.Image = Global.Ipos.My.Resources.Resources.no_entry__2_
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(232, 449)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 36)
        Me.Button1.TabIndex = 30
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
        Me.btnSimpan.Location = New System.Drawing.Point(23, 449)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(79, 36)
        Me.btnSimpan.TabIndex = 31
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(25, 337)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(184, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Akun Penghapusan Piutang"
        '
        'cbAkun
        '
        Me.cbAkun.FormattingEnabled = True
        Me.cbAkun.ItemHeight = 23
        Me.cbAkun.Location = New System.Drawing.Point(24, 357)
        Me.cbAkun.Name = "cbAkun"
        Me.cbAkun.Size = New System.Drawing.Size(226, 29)
        Me.cbAkun.TabIndex = 18
        Me.cbAkun.UseSelectable = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Departemen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 271)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Projek"
        '
        'cbProjek
        '
        Me.cbProjek.FormattingEnabled = True
        Me.cbProjek.ItemHeight = 23
        Me.cbProjek.Location = New System.Drawing.Point(23, 291)
        Me.cbProjek.Name = "cbProjek"
        Me.cbProjek.Size = New System.Drawing.Size(300, 29)
        Me.cbProjek.TabIndex = 15
        Me.cbProjek.UseSelectable = True
        '
        'cbDepartemen
        '
        Me.cbDepartemen.FormattingEnabled = True
        Me.cbDepartemen.ItemHeight = 23
        Me.cbDepartemen.Location = New System.Drawing.Point(20, 228)
        Me.cbDepartemen.Name = "cbDepartemen"
        Me.cbDepartemen.Size = New System.Drawing.Size(304, 29)
        Me.cbDepartemen.TabIndex = 14
        Me.cbDepartemen.UseSelectable = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 17)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Jumlah"
        '
        'jumlahPiutang
        '
        Me.jumlahPiutang.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.jumlahPiutang.Location = New System.Drawing.Point(20, 168)
        Me.jumlahPiutang.Name = "jumlahPiutang"
        Me.jumlahPiutang.ReadOnly = True
        Me.jumlahPiutang.Size = New System.Drawing.Size(291, 29)
        Me.jumlahPiutang.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Tanggal"
        '
        'dtpPenghapusan
        '
        Me.dtpPenghapusan.Location = New System.Drawing.Point(20, 110)
        Me.dtpPenghapusan.MinimumSize = New System.Drawing.Size(4, 29)
        Me.dtpPenghapusan.Name = "dtpPenghapusan"
        Me.dtpPenghapusan.Size = New System.Drawing.Size(292, 29)
        Me.dtpPenghapusan.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Kode Refrensi"
        '
        'tbKode
        '
        Me.tbKode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbKode.Location = New System.Drawing.Point(20, 55)
        Me.tbKode.Name = "tbKode"
        Me.tbKode.ReadOnly = True
        Me.tbKode.Size = New System.Drawing.Size(291, 26)
        Me.tbKode.TabIndex = 8
        '
        'DetailPiutangUsaha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1115, 544)
        Me.Controls.Add(Me.gbForm)
        Me.Controls.Add(Me.gbData)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "DetailPiutangUsaha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Piutang Usaha"
        Me.gbData.ResumeLayout(False)
        Me.gbData.PerformLayout()
        CType(Me.ListDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbForm.ResumeLayout(False)
        Me.gbForm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbData As GroupBox
    Friend WithEvents eCari As MetroFramework.Controls.MetroTextBox
    Friend WithEvents ListSat As MetroFramework.Controls.MetroGrid
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents ListDetail As MetroFramework.Controls.MetroGrid
    Friend WithEvents gbForm As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbKode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpPenghapusan As MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label5 As Label
    Friend WithEvents jumlahPiutang As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbAkun As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbProjek As MetroFramework.Controls.MetroComboBox
    Friend WithEvents cbDepartemen As MetroFramework.Controls.MetroComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents Button4 As Button
End Class
