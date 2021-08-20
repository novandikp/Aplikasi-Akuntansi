Public Class LaporanKontak


    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String
    Public klasifikasi As String = "Pelanggan"

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        sql = "SELECT  pelanggan, alamat, notelp, posisi from tblkontak where posisi ilike '%" & klasifikasi & "%' and (pelanggan ilike '%" & cari & "%' or alamat ilike '%" & cari & "%' or notelp ilike '%" & cari & "%')"

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)

        ListSat.DataSource = dv
        Debug.WriteLine("SQL CARI :" & sql)
        styliseDG(ListSat)
        ListSat.Columns(0).HeaderText = "Kontak"
        ListSat.Columns(1).HeaderText = "Alamat"
        ListSat.Columns(2).HeaderText = "No Telp"
        ListSat.Columns(3).HeaderText = "Posisi"
        makeFillDG(ListSat)

    End Sub

    Public saldoawal As String = "0"

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getDataLaporan()
    End Sub



    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewLaporanKontak.dataview = dv
        PreviewLaporanKontak.judul = klasifikasi
        PreviewLaporanKontak.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

End Class