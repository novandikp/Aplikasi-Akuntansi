Public Class LaporanKeuangan


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
        LaporanArusKas.ShowDialog()
        LaporanArusKas.Dispose()

    End Sub

    Private Sub MetroLabel2_Click(sender As Object, e As EventArgs) Handles MetroLabel2.Click
        LaporanLabaRugiStandard.ShowDialog()
        LaporanLabaRugiStandard.Dispose()
    End Sub

    Private Sub MetroLabel4_Click(sender As Object, e As EventArgs) Handles MetroLabel4.Click
        LaporanNeraca.ShowDialog()
        LaporanNeraca.Dispose()
    End Sub



    Private Sub MetroLabel16_Click(sender As Object, e As EventArgs) Handles MetroLabel16.Click
        LaporanRekening.ShowDialog()
        LaporanNeracaSaldo.Dispose()
    End Sub

    Private Sub MetroLabel6_Click(sender As Object, e As EventArgs) Handles MetroLabel6.Click
        LaporanNeracaSaldo.ShowDialog()
        LaporanNeracaSaldo.Dispose()
    End Sub

    Private Sub MetroLabel14_Click(sender As Object, e As EventArgs) 
        LaporanJurnalSemua.ShowDialog()
        LaporanJurnalSemua.Dispose()
    End Sub

    Private Sub MetroLabel13_Click(sender As Object, e As EventArgs) Handles MetroLabel13.Click
        LaporanBukuBesar.ShowDialog()
        LaporanBukuBesar.Dispose()
    End Sub

    Private Sub MetroLabel12_Click(sender As Object, e As EventArgs) Handles MetroLabel12.Click

        LaporanBukuBesarLengkap.ShowDialog()
        LaporanBukuBesarLengkap.Dispose()
    End Sub

    Private Sub MetroLabel23_Click(sender As Object, e As EventArgs) Handles MetroLabel23.Click
        LaporanJurnalPemasukan.ShowDialog()
        LaporanJurnalPemasukan.Dispose()
    End Sub

    Private Sub MetroLabel24_Click(sender As Object, e As EventArgs) Handles MetroLabel24.Click
        LaporanJurnalPengeluaran.ShowDialog()
        LaporanJurnalPengeluaran.Dispose()
    End Sub
End Class