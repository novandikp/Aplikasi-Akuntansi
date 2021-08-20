Public Class LaporanStokPersediaanUmum

    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        sql = "select tblharga.idharga,produk,refrensi,tglhistori, masuk, keluar, sum(masuk -keluar) over (PARTITION by tblhistoristok.idharga order by tblhistoristok.idharga,tblhistoristok, idhistoristok) as sisa,satuan,  tblhistoristok.hpp, sum(masuk -keluar) over (PARTITION by tblhistoristok.idharga order by tblhistoristok.idharga,tblhistoristok, idhistoristok) * tblhistoristok.hpp as nilai from tblhistoristok 
inner join tblharga on tblharga.idharga = tblhistoristok.idharga
inner join tblproduk on tblproduk.idproduk = tblharga.idbarang
inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan
where produk ILIKE '%" & cari & "%' AND tglhistori BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' and '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
        order by tblhistoristok.idharga, tblhistoristok, idhistoristok"

        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine("SQL CARI :" & sql)
        styliseDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Refrensi"
            ListSat.Columns(3).HeaderText = "Tanggal"
            ListSat.Columns(4).HeaderText = "Masuk"
            ListSat.Columns(5).HeaderText = "Keluar"
            ListSat.Columns(6).HeaderText = "Sisa"
            ListSat.Columns(7).HeaderText = "Satuan"
            ListSat.Columns(8).HeaderText = "HPP"
            ListSat.Columns(9).HeaderText = "Nilai"
        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        getDataLaporan()
    End Sub



    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewStok.dataview = dv

        PreviewStok.Show()

    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs)
        getDataLaporan()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
    End Sub
End Class