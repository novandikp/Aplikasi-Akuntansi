Public Class LaporanDetailPenawaranJual
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        If cbSub.SelectedIndex > 0 Then
            sql = "SELECT  tbldetailpenawaranjual.kodepenawaranjual as kode,tglpenawaranjual as tgl,produk, jumlahjual as jumlah,satuan, tbldetailpenawaranjual.hargajual as harga, jumlahpajak, diskondetailpersen, tblkontak.pelanggan as kontak from tbldetailpenawaranjual inner join tblpenawaranjual on tblpenawaranjual.kodepenawaranjual = tbldetailpenawaranjual.kodepenawaranjual inner join tblharga on tblharga.idharga = tbldetailpenawaranjual.idharga inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblkontak on tblkontak.idpelanggan = tblpenawaranjual.pelanggan
WHERE (tblpenawaranjual.kodepenawaranjual ILIKE '%" & eCari.Text & "%' or tblkontak.pelanggan ILIKE '%" & eCari.Text & "%'  )
          and kodedepartemen ='" & cbSub.SelectedValue & "' and tglpenawaranjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
        Else
            sql = "SELECT  tbldetailpenawaranjual.kodepenawaranjual as kode,tglpenawaranjual as tgl,produk, jumlahjual as jumlah,satuan, tbldetailpenawaranjual.hargajual as harga, jumlahpajak, diskondetailpersen, tblkontak.pelanggan as kontak from tbldetailpenawaranjual inner join tblpenawaranjual on tblpenawaranjual.kodepenawaranjual = tbldetailpenawaranjual.kodepenawaranjual inner join tblharga on tblharga.idharga = tbldetailpenawaranjual.idharga inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblkontak on tblkontak.idpelanggan = tblpenawaranjual.pelanggan
WHERE (tblpenawaranjual.kodepenawaranjual ILIKE '%" & eCari.Text & "%' or tblkontak.pelanggan ILIKE '%" & eCari.Text & "%'  )
           and tglpenawaranjual BETWEEN '" & dtAwal.Value.ToString("yyyy/MM/dd") & "' and 
        '" & dtAkhir.Value.ToString("yyyy/MM/dd") & "'"
        End If


        dataLaporan = getData(sql)
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine(sql)
        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Kode"
            ListSat.Columns(1).HeaderText = "Tanggal"
            ListSat.Columns(2).HeaderText = "Produk"
            ListSat.Columns(3).HeaderText = "Jumlah"
            ListSat.Columns(4).HeaderText = "Satuan"
            ListSat.Columns(5).HeaderText = "Harga"
            ListSat.Columns(6).HeaderText = "Pajak"
            ListSat.Columns(7).HeaderText = "Diskon(%)"
            ListSat.Columns(8).HeaderText = "Pelanggan"

        Catch ex As Exception

        End Try


    End Sub

    Public saldoawal As String = "0"

    Private Sub getSubKlasifikasi()
        Dim dt As DataTable = getData("select iddepartemen, departemen from tbldepartemen order by iddepartemen")
        Dim dr As DataRow = dt.NewRow
        dr.Item(0) = 0
        dr.Item(1) = "Semua"
        dt.Rows.InsertAt(dr, 0)
        cbSub.DataSource = dt
        cbSub.DisplayMember = "departemen"
        cbSub.ValueMember = "iddepartemen"
    End Sub

    Private Sub LaporanArusKas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getSubKlasifikasi()
        getDataLaporan()
    End Sub


    Private Sub dtAwal_ValueChanged(sender As Object, e As EventArgs) Handles dtAwal.ValueChanged
        getDataLaporan()
    End Sub

    Private Sub dtAkhir_ValueChanged(sender As Object, e As EventArgs) Handles dtAkhir.ValueChanged
        getDataLaporan()
    End Sub


    Private Sub eCari_TextChanged(sender As Object, e As EventArgs) Handles eCari.TextChanged
        getDataLaporan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreviewPenawaranJual.dataview = dv
        PreviewPenawaranJual.detail = True
        PreviewPenawaranJual.Show()
    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class