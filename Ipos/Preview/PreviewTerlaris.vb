﻿Imports Microsoft.Reporting.WinForms

Public Class PreviewTerlaris
    Public sql As String = ""

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DTawal.ValueChanged
        laporanBarangLengkap()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DtAkhir.ValueChanged
        laporanBarangLengkap()
    End Sub

    Private Sub PreviewReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyBase.WindowState = FormWindowState.Maximized
        'DTawal.Value = New DateTime(Now.Year, Now.Month, 1)
        laporanBarangLengkap()
    End Sub


    Sub laporanBarangLengkap()
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.ReportEmbeddedResource = "Ipos.LaporanLaku.rdlc"
        Dim sqlidentitas As String =
                "select idtoko, namatoko, alamatoko, notoko, caption1, caption2, caption3, printstruk, logo, kota from tblidentitas where idtoko=1"
        Dim awal = DTawal.Value.ToString("yyyy/MM/dd")
        Dim akhir = DtAkhir.Value.ToString("yyyy/MM/dd")
        'Dim sql As String = "SELECT view_detailjual.barcode, (select tblproduk.produk from tblproduk where tblproduk.idproduk =view_detailjual.barcode) as `produk`, sum(view_detailjual.jumlahjual) as `stok1`, satuanjual,  (select view_harga.hargajual from view_harga where view_harga.satuan = view_detailjual.satuanjual and view_harga.idproduk =view_detailjual.barcode) as `hargajual`  from view_detailjual  where tgljual between ('" & awal & " 00:00:00') and ('" & akhir & " 23:59:59') and flag=1 and (produk like '%" & eCari.Text & "%' or fakturjual like '%" & eCari.Text & "%') group by barcode,satuanjual ORDER BY sum(view_detailjual.jumlahjual) desc;"
        ReportViewer1.LocalReport.EnableExternalImages = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("DataSet1", CType(getData(Sql), DataTable)))
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

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)
    End Sub

    Private Sub eCari_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        laporanBarangLengkap()
    End Sub

    Private Sub ReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) _
        Handles ReportViewer1.KeyDown, eCari.KeyDown, Button4.KeyDown, DTawal.KeyDown, DtAkhir.KeyDown, Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.End Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            laporanBarangLengkap()

        End If
    End Sub
End Class