Public Class LaporanDaftarProdukGudang
    Dim dataLaporan As New DataTable
    Dim dv As DataView
    Dim sql As String

    Public ringkasan As Boolean = False
    Sub getDataLaporan()

        If cbSub.SelectedIndex > 0 Then
            sql = "select tblgudang.gudang as gudang,idproduk, produk,   tblstok.stok,nilaidasar, satuan,hargajual, hargabeli,hpp from tblharga 
        inner join tblproduk on tblproduk.idproduk = tblharga.idbarang 
        inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan  
        cross join tblgudang
        left join 
        (SELECT idbarang,idgudang,sum(stok * tblharga.nilaidasar) as stok from tblstokgudang 
        inner join tblharga on tblharga.idharga = tblstokgudang.idharga 
        inner join tblproduk on tblproduk.idproduk = tblharga.idbarang 
        group by idbarang,idgudang) 
        tblstok  on tblstok.idbarang = tblproduk.idproduk and tblstok.idgudang =tblgudang.idgudang 
        where produk ilike '%" & eCari.Text & "%' and tblgudang.idgudang = '" & cbSub.SelectedValue & "'
        order by tblgudang.idgudang, tblharga.idbarang,level"
        Else
            sql = "select tblgudang.gudang,idproduk, produk,   tblstok.stok,nilaidasar, satuan,hargajual, hargabeli,hpp from tblharga 
        inner join tblproduk on tblproduk.idproduk = tblharga.idbarang 
        inner join tblsatuan on tblsatuan.kodesatuan = tblharga.idsatuan  
        cross join tblgudang
        left join 
        (SELECT idbarang,idgudang,sum(stok * tblharga.nilaidasar) as stok from tblstokgudang 
        inner join tblharga on tblharga.idharga = tblstokgudang.idharga 
        inner join tblproduk on tblproduk.idproduk = tblharga.idbarang 
        group by idbarang,idgudang) 
        tblstok  on tblstok.idbarang = tblproduk.idproduk and tblstok.idgudang =tblgudang.idgudang 
        where produk ilike '%" & eCari.Text & "%'
        order by tblgudang.idgudang, tblharga.idbarang,level"
        End If


        dataLaporan = getData(sql)
        countStok()
        dv = New DataView(dataLaporan)
        ListSat.DataSource = dv
        Debug.WriteLine(sql)
        styliseDG(ListSat)
        Try
            ListSat.Columns(0).HeaderText = "Gudang"
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


    End Sub

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
        PreviewDaftarProdukGudang.dataview = dv
        PreviewDaftarProdukGudang.Show()

    End Sub

    Private Sub cbSub_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSub.SelectedIndexChanged
        getDataLaporan()
    End Sub
End Class