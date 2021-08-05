<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogPesananBeli
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
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.gbData = New System.Windows.Forms.GroupBox()
        Me.dtAwal = New MetroFramework.Controls.MetroDateTime()
        Me.dtAkhir = New MetroFramework.Controls.MetroDateTime()
        Me.eCari = New MetroFramework.Controls.MetroTextBox()
        Me.ListSat = New MetroFramework.Controls.MetroGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.gbData.SuspendLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel6})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 457)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(835, 22)
        Me.StatusStrip1.TabIndex = 92
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'gbData
        '
        Me.gbData.Controls.Add(Me.dtAwal)
        Me.gbData.Controls.Add(Me.dtAkhir)
        Me.gbData.Controls.Add(Me.eCari)
        Me.gbData.Controls.Add(Me.ListSat)
        Me.gbData.Controls.Add(Me.Label1)
        Me.gbData.Location = New System.Drawing.Point(12, 0)
        Me.gbData.Name = "gbData"
        Me.gbData.Size = New System.Drawing.Size(811, 442)
        Me.gbData.TabIndex = 94
        Me.gbData.TabStop = False
        '
        'dtAwal
        '
        Me.dtAwal.Location = New System.Drawing.Point(20, 65)
        Me.dtAwal.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtAwal.Name = "dtAwal"
        Me.dtAwal.Size = New System.Drawing.Size(300, 29)
        Me.dtAwal.TabIndex = 79
        '
        'dtAkhir
        '
        Me.dtAkhir.Location = New System.Drawing.Point(339, 65)
        Me.dtAkhir.MinimumSize = New System.Drawing.Size(0, 29)
        Me.dtAkhir.Name = "dtAkhir"
        Me.dtAkhir.Size = New System.Drawing.Size(300, 29)
        Me.dtAkhir.TabIndex = 78
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
        Me.ListSat.Size = New System.Drawing.Size(777, 316)
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
        'DialogPesananJual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(835, 479)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbData)
        Me.Name = "DialogPesananJual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daftar Pesanan Penjualan"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbData.ResumeLayout(False)
        Me.gbData.PerformLayout()
        CType(Me.ListSat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel6 As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents gbData As GroupBox
    Friend WithEvents dtAwal As MetroFramework.Controls.MetroDateTime
    Friend WithEvents dtAkhir As MetroFramework.Controls.MetroDateTime
    Friend WithEvents eCari As MetroFramework.Controls.MetroTextBox
    Friend WithEvents ListSat As MetroFramework.Controls.MetroGrid
    Friend WithEvents Label1 As Label
End Class
