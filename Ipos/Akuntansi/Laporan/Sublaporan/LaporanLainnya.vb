Public Class LaporanLainnya
    Private Sub MetroLink3_Click(sender As Object, e As EventArgs) Handles MetroLink3.Click
        LaporanKontak.klasifikasi = "Pegawai"
        LaporanKontak.ShowDialog()
        LaporanKontak.Dispose()
    End Sub

    Private Sub MetroLabel2_Click(sender As Object, e As EventArgs) Handles MetroLabel2.Click
        LaporanKontak.klasifikasi = "Supplier"
        LaporanKontak.ShowDialog()
        LaporanKontak.Dispose()
    End Sub

    Private Sub MetroLabel3_Click(sender As Object, e As EventArgs) Handles MetroLabel3.Click
        LaporanKontak.klasifikasi = "Pelanggan"
        LaporanKontak.ShowDialog()
        LaporanKontak.Dispose()
    End Sub

    Private Sub MetroLabel16_Click(sender As Object, e As EventArgs) Handles MetroLabel16.Click
        LaporanProjek.ShowDialog()
        LaporanProjek.Dispose()
    End Sub

    Private Sub MetroLabel15_Click(sender As Object, e As EventArgs) Handles MetroLabel15.Click
        LaporanAktifitasProjek.ShowDialog()
        LaporanAktifitasProjek.Dispose()
    End Sub

    Private Sub MetroLabel24_Click(sender As Object, e As EventArgs) Handles MetroLabel24.Click
        LaporanDepartemen.ShowDialog()
        LaporanDepartemen.Dispose()
    End Sub

    Private Sub MetroLabel23_Click(sender As Object, e As EventArgs) Handles MetroLabel23.Click
        LaporanAktifitasDepartemen.ShowDialog()
        LaporanAktifitasDepartemen.Dispose()
    End Sub
End Class