Public Class LaporanDaftarPRoduk
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()
        Dim cari As String = eCari.Text
        If cbSub.SelectedIndex > 0 Then
            sql = "select tblharga.idharga,idproduk, produk,   tblstok.stok,nilaidasar, satuan,hargajual, hargabeli,hpp from tblharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan  left join (SELECT idbarang,sum(stok * tblharga.nilaidasar) as stok from tblstokgudang inner join tblharga on tblharga.idharga = tblstokgudang.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang where tblstokgudang.idgudang='" & cbSub.SelectedValue.ToString & "'  group by idbarang) tblstok  on tblstok.idbarang = tblproduk.idproduk where (tblharga.idbarang ILIKE '%" & cari & "%' or produk ILIKE '%" & cari & "%') order by tblharga.idbarang,level"
        Else
            sql = "select tblharga.idharga,idproduk, produk,   tblstok.stok,nilaidasar, satuan,hargajual, hargabeli,hpp from tblharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan  left join (SELECT idbarang,sum(stok * tblharga.nilaidasar) as stok from tblstokgudang inner join tblharga on tblharga.idharga = tblstokgudang.idharga inner join tblproduk on tblproduk.idproduk = tblharga.idbarang  group by idbarang) tblstok  on tblstok.idbarang = tblproduk.idproduk where (tblharga.idbarang ILIKE '%" & cari & "%' or produk ILIKE '%" & cari & "%') order by tblharga.idbarang,level"
        End If


        dataLaporan = getData(sql)
        countStok()
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv

        styliseDG(ListSat)
        Try
            ListSat.Columns(0).Visible = False
            ListSat.Columns(1).HeaderText = "Kode Produk"
            ListSat.Columns(2).HeaderText = "Produk"
            ListSat.Columns(3).HeaderText = "Stok"
            ListSat.Columns(4).Visible = False
            ListSat.Columns(5).HeaderText = "Satuan"

            ListSat.Columns(6).HeaderText = "Harga Jual"
            ListSat.Columns(7).HeaderText = "Harga Beli"
            ListSat.Columns(8).HeaderText = "HPP"

            ListSat.Columns(6).DefaultCellStyle.Format = "c0"
            ListSat.Columns(7).DefaultCellStyle.Format = "c0"
            ListSat.Columns(8).DefaultCellStyle.Format = "c0"
        Catch ex As Exception

        End Try
        makeFillDG(ListSat)

    End Sub

    Public saldoawal As String = "0"

    Sub countStok()
        If Not IsNothing(dataLaporan) Then
            For Each row As DataRow In dataLaporan.Rows
                If Not IsDBNull(row.Item("stok")) And Not IsDBNull(row.Item("nilaidasar")) Then
                    If row.Item("stok") >= row.Item("nilaidasar") Then
                        row.Item("stok") = Math.Floor(row.Item("stok") / row.Item("nilaidasar"))
                    Else
                        row.Item("stok") = 0
                    End If
                Else
                    row.Item("stok") = 0
                End If

            Next
        End If
    End Sub

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
        PreviewDaftarProduk.dataview = dv
        PreviewDaftarProduk.Show()

    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class