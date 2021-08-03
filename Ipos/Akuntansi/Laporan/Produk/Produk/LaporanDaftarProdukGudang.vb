Public Class LaporanDaftarProdukGudang
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        If cbSub.SelectedIndex > 0 Then
            sql = "SELECT tblgudang.gudang,tblproduk.idproduk,tblproduk.produk, COALESCE(stok,0) as stok, tblsatuan.satuan,hpp,hargajual from tblharga INNER join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan cross join tblgudang left join tblstokgudang on tblstokgudang.idgudang = tblgudang.idgudang and tblstokgudang.idproduk = tblproduk.idproduk and tblstokgudang.idsatuan = tblsatuan.kodesatuan where produk ilike '%" & eCari.Text & "%' and tblgudang.idgudang = '" & cbSub.SelectedValue & "' order by tblgudang.idgudang, tblgudang.gudang, produk"
        Else
            sql = "SELECT tblgudang.gudang,tblproduk.idproduk,tblproduk.produk, COALESCE(stok,0) as stok, tblsatuan.satuan,hpp,hargajual from tblharga INNER join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan cross join tblgudang left join tblstokgudang on tblstokgudang.idgudang = tblgudang.idgudang and tblstokgudang.idproduk = tblproduk.idproduk and tblstokgudang.idsatuan = tblsatuan.kodesatuan where produk ilike '%" & eCari.Text & "%'  order by tblgudang.idgudang, tblgudang.gudang, produk"
        End If


        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine(sql)
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
End Class