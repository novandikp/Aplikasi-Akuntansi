Imports Microsoft.Reporting.WinForms

Public Class PreviewBarangPer
    Public sql As String = ""
    Dim status = True

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        status = False
        ComboBox2.DataSource = Nothing
        ComboBox2.Items.Clear()

        If ComboBox1.SelectedIndex = 0 Then
            ComboBox2.Items.Add("STOK NOL")
            ComboBox2.Items.Add("STOK LEBIH DARI STOK MINIMAL")
            ComboBox2.Items.Add("STOK KURANG DARI STOK MINIMAL")
        Else
            ' ComboBox2.Items.Add("SEMUA")
            Dim dt As DataTable = getData("select idkategori,kategori from tblkategori")
            Dim dr As DataRow = dt.NewRow
            dr(0) = "0"
            dr(1) = "SEMUA"

            dt.Rows.InsertAt(dr, 0)
            ComboBox2.DataSource = dt
            ComboBox2.ValueMember = "idkategori"
            ComboBox2.DisplayMember = "kategori"
        End If
        ComboBox2.SelectedIndex = 0
        laporanBarangTanpaHarga()
        status = True
    End Sub


    Sub awal()
        laporanBarangTanpaHarga()

        Me.WindowState = FormWindowState.Maximized
        Return
        ComboBox1.SelectedIndex = 0
        If status Then
            laporanBarangTanpaHarga()
        End If
    End Sub

    Private Sub PreviewBarangPer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Sub laporanBarangTanpaHarga()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanBarang.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim cari = ""
        If ComboBox1.SelectedIndex = 0 Then
            If ComboBox2.SelectedIndex = 0 Then
                cari = "and (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) = 0"
            ElseIf ComboBox2.SelectedIndex = 1 Then
                cari = "and (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) > stokmin"
            Else
                cari = "and (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) < stokmin"

            End If
        Else
            If ComboBox2.SelectedIndex = 0 Then
                cari = ""
            Else
                cari = "and idkategori = " & ComboBox2.SelectedValue
            End If


        End If
        'Dim sql As String = "Select idproduk, produk, merk, kategori,  (stok1 + stok2 * konversi1 + stok3 * konversi1 * konversi2) As stokis from view_produk As T1 where (produk Like '%" & eCari.Text & "%' or idproduk like '%" & eCari.Text & "%') " & cari

        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(Sql), DataTable)))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomerToko",
                                                                    getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.RefreshReport()
    End Sub


    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        laporanBarangTanpaHarga()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        laporanBarangTanpaHarga()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles ReportViewer1.KeyDown, eCari.KeyDown, Button4.KeyDown, Me.KeyDown, ComboBox1.KeyDown, ComboBox2.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangTanpaHarga()

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If status Then
            laporanBarangTanpaHarga()
        End If
    End Sub
End Class