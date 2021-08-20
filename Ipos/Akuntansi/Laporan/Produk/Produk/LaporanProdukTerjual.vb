Public Class LaporanProdukTerjual
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT  tblproduk.idproduk,tblproduk.produk, tblsatuan.satuan,COALESCE( sum(jumlahjual), 0 ) as jumlah , COALESCE( sum(jumlahjual*tbldetailjual.hargajual), 0 ) as nilai from tblharga 
inner join tblproduk on  tblproduk.idproduk = tblharga.idbarang 
inner join tblsatuan on  tblsatuan.kodesatuan = tblharga.idsatuan
left join tbldetailjual on tblharga.idharga = tbldetailjual.idharga
inner join tbljual on tbljual.kodejual = tbldetailjual.kodejual 
where  (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tgljual BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' 
GROUP by tblharga.idharga, tblproduk.idproduk, tblsatuan.kodesatuan"
        Else
            sql = "SELECT  tblproduk.idproduk, tblproduk.produk, tblsatuan.satuan,COALESCE( sum(jumlahjual), 0 ) as jumlah , COALESCE( sum(jumlahjual*tbldetailjual.hargajual), 0 ) as nilai from tblharga 
inner join tblproduk on  tblproduk.idproduk = tblharga.idbarang 
inner join tblsatuan on  tblsatuan.kodesatuan = tblharga.idsatuan
left join tbldetailjual on tblharga.idharga = tbldetailjual.idharga
inner join tbljual on tbljual.kodejual = tbldetailjual.kodejual 
where  (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tgljual BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' and kodegudang = '" & cbSub.SelectedValue & "'
GROUP by tblharga.idharga, tblproduk.idproduk, tblsatuan.kodesatuan"
        End If




        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode Produk"
            ListSat.Columns(1).HeaderText = "Produk"
            ListSat.Columns(2).HeaderText = "Satuan"
            ListSat.Columns(3).HeaderText = "Jumlah"
            ListSat.Columns(4).HeaderText = "Nilai"
        Catch ex As Exception

        End Try
        makeFillDG(ListSat)

    End Sub

    Public saldoawal As String = "0"

    Private Sub getSubKlasifikasi()
        Dim dt As DataTable = getData("select idgudang, gudang from tblgudang order by idgudang")
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = 0
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "gudang"
        cbSub.ValueMember = "idgudang"
    End Sub

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSubKlasifikasi()
        getDataLaporan()
    End Sub



    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewDaftarProdukTerjual.dataview = dv
        PreviewDaftarProdukTerjual.Show()

    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub

    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
    End Sub
End Class