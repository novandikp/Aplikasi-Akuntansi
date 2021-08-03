Imports Microsoft.Reporting.WinForms

Public Class PreviewReport
    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        laporanBarangLengkap()
    End Sub

    Sub laporanBarangTanpaHarga()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanBarang.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        Dim sql As String = "SELECT idproduk, produk, merk, kategori,  stok1, stok2, stok3 from view_produk as T1"

        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
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

    Sub laporanBarangLengkap()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanBarangLengkap.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        Dim sql As String =
                "SELECT idproduk, produk,  IIF(tipedata = 1,  view_harga.stok1 , IIF(tipedata = 2, view_harga.stok2, view_harga.stok3 )) as stok1, hargajual, hargabeli, satuan from view_harga  where produk like '%" &
                eCari.Text & "%'"
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(sql), DataTable)))
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("namaToko",
                                                                    getValue(sqlidentitas, "namatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("alamatToko",
                                                                    getValue(sqlidentitas, "alamatoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("nomerToko",
                                                                    getValue(sqlidentitas, "notoko").ToString))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("username", Form1.username))
        ReportViewer1.LocalReport.SetParameters(New ReportParameter("logo", New Uri(getLogo()).AbsoluteUri))
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        laporanBarangLengkap()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles ReportViewer1.KeyDown, eCari.KeyDown, Button4.KeyDown, Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangLengkap()

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
    End Sub
End Class