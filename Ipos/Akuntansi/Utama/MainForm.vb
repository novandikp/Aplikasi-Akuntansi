Public Class MainForm

    'Master ======================
    Sub showAkun()
        Datagridakun.ShowDialog()
        Datagridakun.Dispose()
    End Sub

    Sub showKontak()
        Datagridkontak.ShowDialog()
        Datagridkontak.Dispose()
    End Sub

    Sub showGudang()
        DataGridGudang.ShowDialog()
        DataGridGudang.Dispose()
    End Sub

    Sub showProjek()
        Datagridprojek.ShowDialog()
        Datagridprojek.Dispose()
    End Sub

    Sub showSatuan()
        DatagridSatuan.ShowDialog()
        DatagridSatuan.Dispose()
    End Sub

    Sub showPajak()
        DatagridPajak.ShowDialog()
        DatagridPajak.Dispose()
    End Sub

    Sub showDepartemen()
        Datagriddepartemen.ShowDialog()
        Datagriddepartemen.Dispose()
    End Sub

    Sub showProduk()
        DatagridBarang.ShowDialog()
        DatagridBarang.Dispose()
    End Sub

    Sub showKategori()
        DatagridKategori.ShowDialog()
        DatagridKategori.Dispose()
    End Sub

    Sub showStatus()
        DatagridStatus.ShowDialog()
        DatagridStatus.Dispose()
    End Sub

    Sub showSubKlasifikasi()
        DatagridSub.ShowDialog()
        DatagridSub.Dispose()
    End Sub

    Sub showBukuBesar()
        DatagridBukuBesar.ShowDialog()
        DatagridBukuBesar.Dispose()
    End Sub
    'Event
    Private Sub TileAkun_Click(sender As Object, e As EventArgs) Handles TileAkun.Click
        showAkun()
    End Sub

    Private Sub TileKontak_Click(sender As Object, e As EventArgs) Handles TileKontak.Click
        showKontak()
    End Sub

    Private Sub TileSatuan_Click(sender As Object, e As EventArgs) Handles TileSatuan.Click
        showSatuan()
    End Sub

    Private Sub TileGudang_Click(sender As Object, e As EventArgs) Handles TileGudang.Click
        showGudang()
    End Sub

    Private Sub TileDepartemen_Click(sender As Object, e As EventArgs) Handles TileDepartemen.Click
        showDepartemen()
    End Sub

    Private Sub TileProjek_Click(sender As Object, e As EventArgs) Handles TileProjek.Click
        showProjek()
    End Sub

    Private Sub TilePajak_Click(sender As Object, e As EventArgs) Handles TilePajak.Click
        showPajak()
    End Sub

    Private Sub TileProduk_Click(sender As Object, e As EventArgs) Handles TileProduk.Click
        showProduk()
    End Sub
    'Master =======================


    Sub showLaporanKeuangan()
        LaporanKeuangan.ShowDialog()
        LaporanKeuangan.Dispose()
    End Sub

    Sub showLaporanPenjualanPiutang()
        LaporanJual.ShowDialog()
        LaporanJual.Dispose()
    End Sub

    Sub showLaporanProduk()
        LaporanProduk.ShowDialog()
        LaporanProduk.Dispose()
    End Sub


    Sub showLaporanlainnya()
        LaporanLainnya.ShowDialog()
        LaporanLainnya.Dispose()
    End Sub

    Private Sub MetroTile8_Click(sender As Object, e As EventArgs) Handles MetroTile8.Click
        showLaporanKeuangan()
    End Sub

    Private Sub MetroTile6_Click(sender As Object, e As EventArgs) Handles MetroTile6.Click
        showLaporanPenjualanPiutang()
    End Sub

    Private Sub MetroTile7_Click(sender As Object, e As EventArgs) Handles MetroTile7.Click
        showLaporanProduk()
    End Sub

    Private Sub MetroTile29_Click(sender As Object, e As EventArgs) Handles MetroTile29.Click
        showLaporanlainnya()
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MetroTabControl1.TabPages(0).Show()

    End Sub

    Private Sub MetroTile33_Click(sender As Object, e As EventArgs) Handles MetroTile33.Click
        showKategori()
    End Sub

    Private Sub MetroTile32_Click(sender As Object, e As EventArgs) Handles MetroTile32.Click
        showStatus()
    End Sub

    Private Sub MetroTile31_Click(sender As Object, e As EventArgs) Handles MetroTile31.Click
        showBukuBesar()
    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        showSubKlasifikasi()
    End Sub





    'Transaksi ==================
    'Event
    Sub showPenawaranJual()
        DaftarPenawaranJual.ShowDialog()
        DaftarPenawaranJual.Dispose()
    End Sub


    Sub showPesananJual()
        DaftarPesananJual.ShowDialog()
        DaftarPesananJual.Dispose()
    End Sub
    Sub showPengirimanJual()
        DaftarPengirimanJual.ShowDialog()
        DaftarPengirimanJual.Dispose()
    End Sub
    Sub showFakturJual()
        DaftarFakturJual.ShowDialog()
        DaftarFakturJual.Dispose()
    End Sub


    Sub showReturJual()
        DaftarReturJual.ShowDialog()
        DaftarReturJual.Dispose()
    End Sub


    Sub showPiutangUsaha()
        DaftarPiutangUsaha.ShowDialog()
        DaftarPiutangUsaha.Dispose()
    End Sub

    Sub showBayarPiutangUsaha()
        DaftarHistoriBayarPiutang.ShowDialog()
        DaftarHistoriBayarPiutang.Dispose()
    End Sub

    Sub shoKelebihanBayar()
        DaftarKelebihanBayar.ShowDialog()
        DaftarKelebihanBayar.Dispose()
    End Sub

    Private Sub MetroTile14_Click(sender As Object, e As EventArgs) Handles MetroTile14.Click
        showPenawaranJual()
    End Sub

    Private Sub MetroTile13_Click(sender As Object, e As EventArgs) Handles MetroTile13.Click
        showPesananJual()
    End Sub

    Private Sub MetroTile12_Click(sender As Object, e As EventArgs) Handles MetroTile12.Click
        showPengirimanJual()
    End Sub

    Private Sub MetroTile11_Click(sender As Object, e As EventArgs) Handles MetroTile11.Click
        showFakturJual()
    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        showReturJual()
    End Sub

    Private Sub MetroTile10_Click(sender As Object, e As EventArgs) Handles MetroTile10.Click
        showPiutangUsaha()
    End Sub

    Private Sub MetroTile9_Click(sender As Object, e As EventArgs) Handles MetroTile9.Click
        showBayarPiutangUsaha()
    End Sub

    Private Sub MetroTile5_Click(sender As Object, e As EventArgs) Handles MetroTile5.Click
        shoKelebihanBayar()
    End Sub
End Class