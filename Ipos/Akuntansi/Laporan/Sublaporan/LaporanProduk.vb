Public Class LaporanProduk
    Private Sub MetroLink3_Click(sender As Object, e As EventArgs) Handles MetroLink3.Click
        LaporanDaftarPRoduk.ShowDialog()
        LaporanDaftarPRoduk.Dispose()
    End Sub

    Private Sub MetroLabel2_Click(sender As Object, e As EventArgs) Handles MetroLabel2.Click
        LaporanDaftarProdukGudang.ShowDialog()
        LaporanDaftarProdukGudang.Dispose()
    End Sub

    Private Sub MetroLabel3_Click(sender As Object, e As EventArgs) Handles MetroLabel3.Click
        LaporanProdukTerjual.ShowDialog()
        LaporanProdukTerjual.Dispose()
    End Sub

    Private Sub MetroLabel16_Click(sender As Object, e As EventArgs) Handles MetroLabel16.Click
        LaporanStokPersediaanUmum.ShowDialog()
        LaporanStokPersediaanUmum.Dispose()
    End Sub

    Private Sub MetroLabel15_Click(sender As Object, e As EventArgs) Handles MetroLabel15.Click
        LaporanStokOpname.ShowDialog()
        LaporanStokOpname.Dispose()
    End Sub
End Class