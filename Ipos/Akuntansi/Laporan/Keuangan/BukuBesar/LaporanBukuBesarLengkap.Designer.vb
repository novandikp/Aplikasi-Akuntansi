﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanBukuBesarLengkap
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtAkhir = New MetroFramework.Controls.MetroDateTime()
        Me.dtAwal = New MetroFramework.Controls.MetroDateTime()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.eCari = New MetroFramework.Controls.MetroTextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ListSat = New MetroFramework.Controls.MetroGrid()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(358, 530)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 32)
        Me.Button1.TabIndex = 129
        Me.Button1.Text = "Cetak"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dtAkhir
        '
        Me.dtAkhir.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText
        Me.dtAkhir.Location = New System.Drawing.Point(372, 64)
        Me.dtAkhir.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtAkhir.Name = "dtAkhir"
        Me.dtAkhir.Size = New System.Drawing.Size(320, 29)
        Me.dtAkhir.TabIndex = 128
        Me.dtAkhir.UseCustomForeColor = True
        '
        'dtAwal
        '
        Me.dtAwal.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText
        Me.dtAwal.Location = New System.Drawing.Point(18, 64)
        Me.dtAwal.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtAwal.Name = "dtAwal"
        Me.dtAwal.Size = New System.Drawing.Size(324, 29)
        Me.dtAwal.TabIndex = 127
        Me.dtAwal.UseCustomForeColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(18, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Kata Kunci : "
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 607)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(860, 22)
        Me.StatusStrip1.TabIndex = 124
        Me.StatusStrip1.Text = "StatusStrip1"
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
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(60, 17)
        Me.ToolStripStatusLabel4.Text = "[F5] : Cari,"
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
        Me.eCari.CustomButton.Location = New System.Drawing.Point(462, 2)
        Me.eCari.CustomButton.Name = ""
        Me.eCari.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.eCari.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.eCari.CustomButton.TabIndex = 1
        Me.eCari.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.eCari.CustomButton.UseSelectable = True
        Me.eCari.CustomButton.Visible = False
        Me.eCari.Lines = New String(-1) {}
        Me.eCari.Location = New System.Drawing.Point(118, 18)
        Me.eCari.MaxLength = 32767
        Me.eCari.Name = "eCari"
        Me.eCari.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.eCari.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.eCari.SelectedText = ""
        Me.eCari.SelectionLength = 0
        Me.eCari.SelectionStart = 0
        Me.eCari.ShortcutsEnabled = True
        Me.eCari.Size = New System.Drawing.Size(480, 20)
        Me.eCari.TabIndex = 123
        Me.eCari.UseSelectable = True
        Me.eCari.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.eCari.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Image = Global.Ipos.My.Resources.Resources.refresh__2_
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(622, 16)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(69, 26)
        Me.Button4.TabIndex = 126
        Me.Button4.Text = "Refresh"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft PhagsPa", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ListSat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListSat.DefaultCellStyle = DataGridViewCellStyle5
        Me.ListSat.EnableHeadersVisualStyles = False
        Me.ListSat.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.ListSat.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ListSat.Location = New System.Drawing.Point(-2, 108)
        Me.ListSat.MultiSelect = False
        Me.ListSat.Name = "ListSat"
        Me.ListSat.ReadOnly = True
        Me.ListSat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(247, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListSat.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.ListSat.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ListSat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ListSat.Size = New System.Drawing.Size(864, 392)
        Me.ListSat.TabIndex = 122
        '
        'LaporanBukuBesarLengkap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(860, 629)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtAkhir)
        Me.Controls.Add(Me.dtAwal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.eCari)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListSat)
        Me.Name = "LaporanBukuBesarLengkap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Buku Besar Lengkap"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents dtAkhir As MetroFramework.Controls.MetroDateTime
    Friend WithEvents dtAwal As MetroFramework.Controls.MetroDateTime
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents eCari As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents ListSat As MetroFramework.Controls.MetroGrid
End Class
