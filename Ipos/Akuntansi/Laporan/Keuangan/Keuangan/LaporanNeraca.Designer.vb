﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LaporanNeraca
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtAkhir = New MetroFramework.Controls.MetroDateTime()
        Me.eCari = New MetroFramework.Controls.MetroTextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ListSat = New MetroFramework.Controls.MetroGrid()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtAwal = New MetroFramework.Controls.MetroDateTime()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tblTotal = New MetroFramework.Controls.MetroLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MetroCheckBox1 = New MetroFramework.Controls.MetroCheckBox()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Location = New System.Drawing.Point(328, 440)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 32)
        Me.Button1.TabIndex = 119
        Me.Button1.Text = "Cetak"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dtAkhir
        '
        Me.dtAkhir.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText
        Me.dtAkhir.Location = New System.Drawing.Point(352, 48)
        Me.dtAkhir.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtAkhir.Name = "dtAkhir"
        Me.dtAkhir.Size = New System.Drawing.Size(320, 29)
        Me.dtAkhir.TabIndex = 118
        Me.dtAkhir.UseCustomForeColor = True
        '
        'eCari
        '
        '
        '
        '
        Me.eCari.CustomButton.Image = Nothing
        Me.eCari.CustomButton.Location = New System.Drawing.Point(446, 2)
        Me.eCari.CustomButton.Name = ""
        Me.eCari.CustomButton.Size = New System.Drawing.Size(15, 15)
        Me.eCari.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.eCari.CustomButton.TabIndex = 1
        Me.eCari.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.eCari.CustomButton.UseSelectable = True
        Me.eCari.CustomButton.Visible = False
        Me.eCari.Lines = New String(-1) {}
        Me.eCari.Location = New System.Drawing.Point(112, 11)
        Me.eCari.MaxLength = 32767
        Me.eCari.Name = "eCari"
        Me.eCari.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.eCari.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.eCari.SelectedText = ""
        Me.eCari.SelectionLength = 0
        Me.eCari.SelectionStart = 0
        Me.eCari.ShortcutsEnabled = True
        Me.eCari.Size = New System.Drawing.Size(464, 20)
        Me.eCari.TabIndex = 111
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
        Me.Button4.Location = New System.Drawing.Point(600, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(69, 26)
        Me.Button4.TabIndex = 114
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
        Me.ListSat.Location = New System.Drawing.Point(12, 120)
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
        Me.ListSat.Size = New System.Drawing.Size(776, 270)
        Me.ListSat.TabIndex = 110
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
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel5.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(61, 17)
        Me.ToolStripStatusLabel5.Text = "[F6] : Grid,"
        '
        'dtAwal
        '
        Me.dtAwal.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText
        Me.dtAwal.Location = New System.Drawing.Point(12, 48)
        Me.dtAwal.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtAwal.Name = "dtAwal"
        Me.dtAwal.Size = New System.Drawing.Size(324, 29)
        Me.dtAwal.TabIndex = 117
        Me.dtAwal.UseCustomForeColor = True
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
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(0, 3, 3, 2)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(62, 17)
        Me.ToolStripStatusLabel2.Text = "[F2] : Edit, "
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.tblTotal, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 390)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(776, 40)
        Me.TableLayoutPanel1.TabIndex = 115
        '
        'tblTotal
        '
        Me.tblTotal.AutoSize = True
        Me.tblTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblTotal.Location = New System.Drawing.Point(3, 0)
        Me.tblTotal.Name = "tblTotal"
        Me.tblTotal.Size = New System.Drawing.Size(770, 40)
        Me.tblTotal.TabIndex = 0
        Me.tblTotal.Text = "MetroLabel1"
        Me.tblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Kata Kunci : "
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel5, Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 493)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 112
        Me.StatusStrip1.Text = "StatusStrip1"
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
        'MetroCheckBox1
        '
        Me.MetroCheckBox1.AutoSize = True
        Me.MetroCheckBox1.Checked = True
        Me.MetroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MetroCheckBox1.Location = New System.Drawing.Point(16, 96)
        Me.MetroCheckBox1.Name = "MetroCheckBox1"
        Me.MetroCheckBox1.Size = New System.Drawing.Size(126, 15)
        Me.MetroCheckBox1.TabIndex = 116
        Me.MetroCheckBox1.Text = "Tampilkan Saldo (0)"
        Me.MetroCheckBox1.UseSelectable = True
        '
        'LaporanNeraca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Ipos.My.Resources.Resources.bgform
        Me.ClientSize = New System.Drawing.Size(800, 515)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtAkhir)
        Me.Controls.Add(Me.eCari)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ListSat)
        Me.Controls.Add(Me.dtAwal)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MetroCheckBox1)
        Me.Name = "LaporanNeraca"
        Me.Text = "LaporanNeraca"
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents dtAkhir As MetroFramework.Controls.MetroDateTime
    Friend WithEvents eCari As MetroFramework.Controls.MetroTextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents ListSat As MetroFramework.Controls.MetroGrid
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As ToolStripStatusLabel
    Friend WithEvents dtAwal As MetroFramework.Controls.MetroDateTime
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents tblTotal As MetroFramework.Controls.MetroLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents MetroCheckBox1 As MetroFramework.Controls.MetroCheckBox
End Class