﻿Public Class LaporanJual


    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click

        TableLayoutPanel2.Visible = Not TableLayoutPanel2.Visible
        MetroPanel1.UseCustomBackColor = True
        MetroPanel1.BackColor = SystemColors.Control
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        TableLayoutPanel3.Visible = Not TableLayoutPanel3.Visible
        MetroPanel2.UseCustomBackColor = True
        MetroPanel2.BackColor = SystemColors.Control
    End Sub

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        TableLayoutPanel4.Visible = Not TableLayoutPanel4.Visible
        MetroPanel3.UseCustomBackColor = True
        MetroPanel3.BackColor = SystemColors.Control
    End Sub

    Private Sub MetroLink3_Click(sender As Object, e As EventArgs) Handles MetroLink3.Click
        LaporanPenawaranRingkas.ringkasan = True
        LaporanPenawaranRingkas.ShowDialog()
        LaporanPenawaranRingkas.Dispose()
    End Sub

    Private Sub MetroLabel2_Click(sender As Object, e As EventArgs) Handles MetroLabel2.Click
        LaporanPenawaranRingkas.ringkasan = False
        LaporanPenawaranRingkas.ShowDialog()
        LaporanPenawaranRingkas.Dispose()
    End Sub

    Private Sub MetroLabel4_Click(sender As Object, e As EventArgs) Handles MetroLabel4.Click
        LaporanPesananJual.ringkasan = True
        LaporanPesananJual.ShowDialog()
        LaporanPesananJual.Dispose()
    End Sub

    Private Sub MetroLabel5_Click(sender As Object, e As EventArgs) Handles MetroLabel5.Click
        LaporanPesananJual.ringkasan = False
        LaporanPesananJual.ShowDialog()
        LaporanPesananJual.Dispose()
    End Sub

    Private Sub MetroLabel24_Click(sender As Object, e As EventArgs) Handles MetroLabel24.Click
        LaporanPengiriman.ringkasan = True
        LaporanPengiriman.ShowDialog()
        LaporanPengiriman.Dispose()
    End Sub

    Private Sub MetroLabel23_Click(sender As Object, e As EventArgs) Handles MetroLabel23.Click
        LaporanPengiriman.ringkasan = False
        LaporanPengiriman.ShowDialog()
        LaporanPengiriman.Dispose()
    End Sub

    Private Sub MetroLabel1_Click(sender As Object, e As EventArgs) Handles MetroLabel1.Click
        LaporanPenjualanFaktur.ringkasan = True
        LaporanPenjualanFaktur.ShowDialog()
        LaporanPenjualanFaktur.Dispose()
    End Sub

    Private Sub MetroLabel7_Click(sender As Object, e As EventArgs) Handles MetroLabel7.Click
        LaporanPenjualanFaktur.ringkasan = False
        LaporanPenjualanFaktur.ShowDialog()
        LaporanPenjualanFaktur.Dispose()
    End Sub

    Private Sub MetroLabel16_Click(sender As Object, e As EventArgs) Handles MetroLabel16.Click
        LaporanUmurPiutang.ShowDialog()
        LaporanUmurPiutang.Dispose()
    End Sub

    Private Sub MetroLabel14_Click(sender As Object, e As EventArgs) Handles MetroLabel14.Click
        LaporanMutasiPiutang.ShowDialog()
        LaporanMutasiPiutang.Dispose()
    End Sub

    Private Sub MetroLabel12_Click(sender As Object, e As EventArgs) Handles MetroLabel12.Click
        LaporanPembayaranPiutangUsaha.ShowDialog()
        LaporanPembayaranPiutangUsaha.Dispose()
    End Sub

    Private Sub MetroLabel9_Click(sender As Object, e As EventArgs) Handles MetroLabel9.Click
        LaporanReturPenjualan.ringkasan = True
        LaporanReturPenjualan.ShowDialog()
        LaporanReturPenjualan.Dispose()
    End Sub

    Private Sub MetroLabel17_Click(sender As Object, e As EventArgs) Handles MetroLabel17.Click
        LaporanReturPenjualan.ringkasan = False
        LaporanReturPenjualan.ShowDialog()
        LaporanReturPenjualan.Dispose()
    End Sub

    Private Sub MetroLabel3_Click(sender As Object, e As EventArgs) Handles MetroLabel3.Click
        LaporanDetailPenawaranJual.ShowDialog()
        LaporanDetailPenawaranJual.Dispose()
    End Sub

    Private Sub MetroLabel6_Click(sender As Object, e As EventArgs) Handles MetroLabel6.Click
        LaporanDetailPesananJual.ShowDialog()
        LaporanDetailPesananJual.Dispose()
    End Sub

    Private Sub MetroLabel8_Click(sender As Object, e As EventArgs) Handles MetroLabel8.Click
        LaporanDetailPenjualanFaktur.ShowDialog()
        LaporanDetailPenjualanFaktur.Dispose()
    End Sub

    Private Sub MetroLabel25_Click(sender As Object, e As EventArgs) Handles MetroLabel25.Click
        LaporanDetailReturPenjualan.ShowDialog()
        LaporanDetailReturPenjualan.Dispose()
    End Sub

    Private Sub MetroLabel22_Click(sender As Object, e As EventArgs) Handles MetroLabel22.Click
        LaporanDetailPengirimanJual.ShowDialog()
        LaporanDetailPengirimanJual.Dispose()
    End Sub

    Private Sub MetroLabel21_Click(sender As Object, e As EventArgs) Handles MetroLabel21.Click
        LaporanDetailPesananJualKirim.ShowDialog()
        LaporanDetailPesananJualKirim.Dispose()
    End Sub
End Class