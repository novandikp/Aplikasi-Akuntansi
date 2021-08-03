Public Class LaporanProdukTerjual
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        Dim cari As String = eCari.Text
        If cbSub.SelectedIndex = 0 Then
            sql = "SELECT  tblproduk.produk, tblsatuan.satuan,
SUM(tbldetailjual.jumlahjual) as jumlahjual,
SUM(tbldetailjual.hargajual* tbldetailjual.jumlahjual)  as nilaipenjualan from tbldetailjual 
inner join tblproduk on  tblproduk.idproduk = tbldetailjual.idbarang 
inner join tblsatuan on  tblsatuan.kodesatuan = tbldetailjual.idsatuan
inner join tbljual on tbljual.kodejual = tbldetailjual.kodejual
where (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tgljual BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "'
GROUP by tblproduk.idproduk, tblsatuan.kodesatuan"
        Else
            sql = "SELECT  tblproduk.produk, tblsatuan.satuan,
SUM(tbldetailjual.jumlahjual) as jumlahjual,
SUM(tbldetailjual.hargajual* tbldetailjual.jumlahjual)  as nilaipenjualan from tbldetailjual 
inner join tblproduk on  tblproduk.idproduk = tbldetailjual.idbarang 
inner join tblsatuan on  tblsatuan.kodesatuan = tbldetailjual.idsatuan
inner join tbljual on tbljual.kodejual = tbldetailjual.kodejual
where (tblproduk.idproduk like '%" & cari & "%' OR tblproduk.produk like '%" & cari & "%') and  tgljual BETWEEN '" & dtAwal.Value.ToString("yyyy-MM-dd") & "' AND  '" & dtAkhir.Value.ToString("yyyy-MM-dd") & "' and kodegudang = '" & cbSub.SelectedValue & "'
GROUP by tblproduk.idproduk, tblsatuan.kodesatuan"
        End If




        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine("SQL CARI :" & sql)
        styliseDG(ListSat)
        Try
            'ListSat.Columns(0).HeaderText = "Tipe"
            'ListSat.Columns(1).HeaderText = "Kode Akun"
            'ListSat.Columns(2).HeaderText = "Akun"
            'ListSat.Columns(3).HeaderText = "Tanggal"
            'ListSat.Columns(4).HeaderText = "Deskripsi"
            'ListSat.Columns(5).HeaderText = "Kode Refrensi"
            'ListSat.Columns(6).HeaderText = "Kode Departemen"
            'ListSat.Columns(7).HeaderText = "Debit"
            'ListSat.Columns(8).HeaderText = "Kredit"
            'ListSat.Columns(9).HeaderText = "Kode Projek"
        Catch ex As Exception

        End Try


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
        PreviewPenawaran.dataview = dv
        PreviewPenawaran.ringkasan = Me.ringkasan
        PreviewPenawaran.Show()
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